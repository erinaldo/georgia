Imports System.Data.OracleClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class frmSumasSaldos
    Private Fecha1 As Date
    Private Fecha2 As Date
    Private rpt As ReportDocument

    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click

        'Al menos una sociedad debe estar seleccionada
        If chkDNY.Checked OrElse chkMON.Checked OrElse chkGRU.Checked Then
            Dim dt As New DataTable

            Me.UseWaitCursor = True

            dtp.Enabled = False
            GroupBox1.Enabled = False
            btnConsultar.Text = "Calculando..."
            btnConsultar.Enabled = False

            CalcularFechaInicio()
            CuentasContables(dt)
            ValoresCuentas(dt)
            GrabarDatos(dt)

            Me.UseWaitCursor = False
            dtp.Enabled = True
            GroupBox1.Enabled = True
            btnConsultar.Text = btnConsultar.Tag.ToString
            btnConsultar.Enabled = True

            'Creo el reporte
            If rpt IsNot Nothing Then rpt.Dispose()
            rpt = New ReportDocument

            rpt.Load(RPTX3 & "XSS.rpt")
            rpt.SetParameterValue("USR", usr.Codigo)
            'Lanzo el reporte dentro de su ventana
            Dim f As New frmCrystal(rpt)
            f.MdiParent = Me.ParentForm
            f.Show()

        Else
            MessageBox.Show("Debe seleccionar al menos una sociedad", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        End If

    End Sub
    Private Sub CuentasContables(ByVal dt As DataTable)
        'Recupero todas las cuentas contables activas
        Dim Sql As String
        Dim da As OracleDataAdapter

        Sql = "SELECT acc_0, des_0, 0 as d, 0 as h, 0 as s, 0 as dd, 0 as hh, 0 as ss "
        Sql &= "FROM gaccount "
        Sql &= "WHERE vlyend_0 >= :fecha OR vlyend_0 = to_date('31/12/1599', 'dd/mm/yyyy') "
        Sql &= "ORDER BY acc_0"

        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("fecha", OracleType.DateTime).Value = Fecha2

        Try
            dt.Clear()
            da.Fill(dt)

        Catch ex As Exception

        End Try

    End Sub
    Private Sub ValoresCuentas(ByVal dt As DataTable)
        Dim Sql As String
        Dim da As OracleDataAdapter
        Dim dt2 As New DataTable
        Dim q As String = ""

        Sql = "SELECT d.acc_0, c.des_0, d.accdat_0, d.sns_0, d.amtloc_0 "
        Sql &= "FROM gaccentryd d INNER JOIN gaccount c ON (d.acc_0 = c.acc_0) "
        Sql &= "WHERE accdat_0 >= :fecha1 AND accdat_0 <= :fecha2 AND cpy_0 IN ({FILTRO}) "
        Sql &= "ORDER BY acc_0"

        If chkDNY.Checked Then
            If q <> "" Then q &= ", "
            q &= "'DNY'"
        End If
        If chkMON.Checked Then
            If q <> "" Then q &= ", "
            q &= "'MON'"
        End If
        If chkGRU.Checked Then
            If q <> "" Then q &= ", "
            q &= "'GRU'"
        End If
        Sql = Sql.Replace("{FILTRO}", q)

        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("fecha1", OracleType.DateTime).Value = Fecha1
        da.SelectCommand.Parameters.Add("fecha2", OracleType.DateTime).Value = Fecha2

        Try
            da.Fill(dt2)

        Catch ex As Exception
            Exit Sub
        End Try

        For Each dr As DataRow In dt2.Rows
            AgregarValor(dr, dt)
        Next

    End Sub
    Private Sub AgregarValor(ByVal dr As DataRow, ByVal dt As DataTable)
        Dim flg As Boolean = False

        For Each dr2 As DataRow In dt.Rows

            If dr2("acc_0").ToString = dr("acc_0").ToString Then
                flg = True

                dr2.BeginEdit()
                If CDate(dr("accdat_0")).Month = Fecha2.Month Then
                    'Mes actual
                    If CInt(dr("sns_0")) > 0 Then
                        dr2("d") = CDbl(dr2("d")) + CDbl(dr("amtloc_0"))
                    Else
                        dr2("h") = CDbl(dr2("h")) + CDbl(dr("amtloc_0"))
                    End If

                    dr2("s") = CDbl(dr2("d")) - CDbl(dr2("h"))

                Else
                    'Acumulado
                    If CInt(dr("sns_0")) > 0 Then
                        dr2("dd") = CDbl(dr2("dd")) + CDbl(dr("amtloc_0"))
                    Else
                        dr2("hh") = CDbl(dr2("hh")) + CDbl(dr("amtloc_0"))
                    End If

                    dr2("ss") = CDbl(dr2("dd")) - CDbl(dr2("hh"))

                End If
                dr2.EndEdit()

                If flg Then Exit Sub

            End If

        Next

    End Sub
    Private Sub CalcularFechaInicio()
        Dim p As Date

        Fecha2 = dtp.Value

        p = New Date(Fecha2.Year, 6, 1)

        If Fecha2 >= p Then
            Fecha1 = p
        Else
            Fecha1 = p.AddYears(-1)
        End If

    End Sub
    Private Sub GrabarDatos(ByVal dt As DataTable)
        Dim Sql As String
        Dim da As OracleDataAdapter
        Dim dt2 As New DataTable
        Dim dr1, dr2 As DataRow

        Sql = "SELECT * FROM xtmpvtas WHERE usr_0 = :usr"
        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("usr", OracleType.VarChar).Value = usr.Codigo
        da.InsertCommand = New OracleCommandBuilder(da).GetInsertCommand
        da.DeleteCommand = New OracleCommandBuilder(da).GetDeleteCommand
        da.UpdateCommand = New OracleCommandBuilder(da).GetUpdateCommand

        Try
            da.Fill(dt2)

            For Each dr2 In dt2.Rows
                dr2.Delete()
            Next

            For Each dr1 In dt.Rows
                dr2 = dt2.NewRow
                dr2("usr_0") = usr.Codigo
                dr2("tsicod1_0") = dr1("acc_0").ToString
                dr2("tsicod2_0") = " "
                dr2("tsicod3_0") = " "
                dr2("tsicod4_0") = " "
                dr2("qtydia_0") = CDbl(dr1("d"))
                dr2("predia_0") = CDbl(dr1("h"))
                dr2("impdia_0") = CDbl(dr1("s"))
                dr2("mardia_0") = 0
                dr2("qtyacu_0") = CDbl(dr1("dd"))
                dr2("preacu_0") = CDbl(dr1("hh"))
                dr2("impacu_0") = CDbl(dr1("ss"))
                dr2("maracu_0") = 0
                dr2("qtypro_0") = 0
                dr2("imppro_0") = 0
                dr2("marpro_0") = 0
                dr2("qtyhis_0") = 0
                dr2("prehis_0") = 0
                dr2("imphis_0") = 0
                dr2("fecha_0") = Fecha2.Date
                dt2.Rows.Add(dr2)
            Next

            da.Update(dt2)

        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try

    End Sub
    

End Class