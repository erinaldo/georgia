Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.OracleClient

Public Class frmControlDiarioComercial
    Private daPpal As OracleDataAdapter
    Private dtPpal As New DataTable
    Private DiasHabilesAcumulados As Integer = 0
    Private DiasHabilesTotales As Integer = 0
    Private rpt As ReportDocument
    Private FechaInicio As Date
    Private FechaFinal As Date

    Private Function BuscarFeriado(ByVal Fecha As Date, ByVal dt As DataTable) As Boolean
        Dim flg As Boolean = False
        Dim dr As DataRow

        For Each dr In dt.Rows
            If CDate(dr("dat_0")) = Fecha Then
                flg = True
                Exit For
            End If
        Next

        Return flg

    End Function
    Private Sub Adaptadores()
        Dim Sql As String

        Sql = "SELECT * FROM xtmpvtas WHERE usr_0 = :usr_0"
        daPpal = New OracleDataAdapter(Sql, cn)
        daPpal.SelectCommand.Parameters.Add("usr_0", OracleType.VarChar)
        daPpal.InsertCommand = New OracleCommandBuilder(daPpal).GetInsertCommand
        daPpal.UpdateCommand = New OracleCommandBuilder(daPpal).GetUpdateCommand
        daPpal.DeleteCommand = New OracleCommandBuilder(daPpal).GetDeleteCommand

    End Sub
    Private Sub AbrirTablaPrincipal()
        Dim da As OracleDataAdapter
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim dr1 As DataRow
        Dim Sql As String = ""

        'Recupero la estructura de la tabla con registros anteriores (si existen)
        daPpal.SelectCommand.Parameters("usr_0").Value = USR.Codigo
        dtPpal.Clear()
        daPpal.Fill(dtPpal)

        'Recupero las familias 4 y 5
        Sql = "SELECT DISTINCT ' ' AS tsicod_1, ' ' AS tsicod_2, tsicod_3, tsicod_4 "
        Sql &= "FROM itmmaster "
        Sql &= "WHERE tsicod_3 <> ' ' AND tsicod_4 <> ' ' "
        Sql &= "ORDER BY tsicod_3, tsicod_4"

        da = New OracleDataAdapter(Sql, cn)
        da.Fill(dt)

        'Elimino todos los registros anteriores
        For Each dr1 In dtPpal.Rows
            dr1.Delete()
        Next

        'Agrego las familias 4 y 5 a la tabla
        For Each dr In dt.Rows
            dr1 = dtPpal.NewRow
            dr1("usr_0") = Usr.Codigo
            dr1("tsicod1_0") = dr("tsicod_1").ToString 'Fam 2
            dr1("tsicod2_0") = dr("tsicod_2").ToString 'Fam 3
            dr1("tsicod3_0") = dr("tsicod_3").ToString 'Fam 4
            dr1("tsicod4_0") = dr("tsicod_4").ToString 'Fam 5
            dr1("qtydia_0") = 0
            dr1("predia_0") = 0
            dr1("impdia_0") = 0
            dr1("mardia_0") = 0
            dr1("qtyacu_0") = 0
            dr1("preacu_0") = 0
            dr1("impacu_0") = 0
            dr1("maracu_0") = 0
            dr1("qtypro_0") = 0
            dr1("imppro_0") = 0
            dr1("marpro_0") = 0
            dr1("qtyhis_0") = 0
            dr1("prehis_0") = 0
            dr1("imphis_0") = 0
            dr1("fecha_0") = mCal.SelectionStart
            dtPpal.Rows.Add(dr1)
        Next

        With pBar
            .Value = 0
            .Minimum = 0
            .Maximum = dtPpal.Rows.Count
        End With

    End Sub
    Private Sub CalcularVentasDia()
        Dim Sql As String
        Dim dt As New DataTable
        Dim da As OracleDataAdapter
        Dim dv As DataView
        Dim dr As DataRow
        Dim itm As New Articulo(cn)

        FechaFinal = mCal.SelectionStart
        FechaInicio = New Date(FechaFinal.Year, FechaFinal.Month, 1)

        'Consulta de pedidos cargados en el mes
        Sql = "select soh.orddat_0 as fecha, "
        Sql &= "      itm.tsicod_3, "
        Sql &= "      itm.tsicod_4, "
        Sql &= "      soq.qty_0 as cantidad, "
        Sql &= "      soq.qty_0 * sop.netprinot_0 as precio "
        Sql &= "from sorder soh inner join "
        Sql &= "     sorderq soq on (soh.sohnum_0 = soq.sohnum_0) inner join "
        Sql &= "     sorderp sop on (soq.sohnum_0 = sop.sohnum_0 and soq.soplin_0 = sop.soplin_0) inner join "
        Sql &= "     itmmaster itm on (soq.itmref_0 = itm.itmref_0) "
        Sql &= "where soh.orddat_0 >= :desde and "
        Sql &= "      soh.orddat_0 <= :hasta and "
        Sql &= "      sohtyp_0 IN ('PED', 'PFD') and "
        Sql &= "      ((soqsta_0 <> 3) or (soqsta_0 = 3 and sdhnum_0 <> ' '))"

        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("desde", OracleType.VarChar).Value = FechaInicio.ToString("dd/MM/yyyy")
        da.SelectCommand.Parameters.Add("hasta", OracleType.VarChar).Value = FechaFinal.ToString("dd/MM/yyyy")

        dt.Clear()
        da.Fill(dt)


        'INTERVENCIONES
        Sql = "select itn.credat_0 as fecha, "
        Sql &= "       itm.tsicod_3, "
        Sql &= "       itm.tsicod_4, "
        Sql &= "       yit.tqty_0 as cantidad, "
        Sql &= "       yit.tqty_0 * yit.amt_0 as precio "
        Sql &= "from interven itn inner join "
        Sql &= "     yitndet yit on (itn.num_0 = yit.num_0) inner join "
        Sql &= "     itmmaster itm on (yit.itmref_0 = itm.itmref_0) "
        Sql &= "where  itn.credat_0 >= :desde and itn.credat_0 <= :hasta and "
        'Sql &= "       itn.typ_0 in ('B1', 'C1', 'D1') and "
        Sql &= "       itn.zflgtrip_0 <> 8 "
        Sql &= "order by itn.Credat_0"
        da.SelectCommand.CommandText = Sql
        da.Fill(dt)

        dv = New DataView(dtPpal)

        Application.DoEvents()

        'Barra de progreso
        pBar.Maximum = dt.Rows.Count

        Application.DoEvents()

        'CALCULO DE VENTAS DEL DIA Y ACUMULADO MENSUAL
        For Each dr In dt.Rows

            dv.RowFilter = "tsicod3_0 = '" & dr("tsicod_3").ToString & "' AND tsicod4_0 = '" & dr("tsicod_4").ToString & "'"

            If dv.Count = 1 Then

                With dv.Item(0).Row
                    .BeginEdit()

                    'Calculo venta del dia
                    If CDate(dr("fecha")) = FechaFinal Then
                        .Item("qtydia_0") = CDbl(.Item("qtydia_0")) + CDbl(dr("cantidad"))
                        .Item("impdia_0") = CDbl(.Item("impdia_0")) + CDbl(dr("precio"))

                    End If

                    'Calculo venta acumulada
                    .Item("qtyacu_0") = CDbl(.Item("qtyacu_0")) + CDbl(dr("cantidad"))
                    .Item("impacu_0") = CDbl(.Item("impacu_0")) + CDbl(dr("precio"))

                    .EndEdit()

                End With

            End If

            pBar.Value += 1
            Application.DoEvents()
        Next

        'Barra de progreso
        With pBar
            .Value = 0
            .Minimum = 0
            .Maximum = dtPpal.Rows.Count
        End With

        Application.DoEvents()

        'CALCULO PROMEDIOS Y ELIMINO REGISTROS SIN CANTIDADES
        For i As Integer = dtPpal.Rows.Count - 1 To 0 Step -1
            dr = dtPpal.Rows(i)

            If dr.RowState <> DataRowState.Deleted Then

                'If CInt(dr("qtydia_0")) = 0 And CInt(dr("qtyacu_0")) = 0 And CInt(dr("qtyhis_0")) = 0 Then
                If CDbl(dr("impdia_0")) = 0 And CDbl(dr("impacu_0")) = 0 And CDbl(dr("imphis_0")) = 0 Then
                    'Elimino registro sin cantidades
                    dr.Delete()
                Else
                    'Calculo precios promedios
                    dr.BeginEdit()
                    If CDbl(dr("qtydia_0")) <> 0 Then dr("predia_0") = CDbl(dr("predia_0")) / CDbl(dr("qtydia_0"))
                    If CDbl(dr("qtyacu_0")) <> 0 Then dr("preacu_0") = CDbl(dr("preacu_0")) / CDbl(dr("qtyacu_0"))
                    dr("fecha_0") = mCal.SelectionStart
                    dr.EndEdit()
                End If

            End If

            pBar.Value += 1
        Next

    End Sub
    Private Sub CalcularProyectados()
        Dim Fecha As Date = mCal.SelectionStart
        Dim i As Integer
        Dim da As OracleDataAdapter
        Dim dt As New DataTable
        Dim dr As DataRow

        da = New OracleDataAdapter("SELECT * FROM xferiados WHERE EXTRACT(YEAR FROM dat_0) = :YY AND EXTRACT(MONTH FROM dat_0) = :MM", cn)
        da.SelectCommand.Parameters.Add("YY", OracleType.Int16).Value = mCal.SelectionStart.Year
        da.SelectCommand.Parameters.Add("MM", OracleType.Int16).Value = mCal.SelectionStart.Month

        da.Fill(dt)

        'CALCULO DE DIAS HABILES TOTALES Y ACUMULADOS
        DiasHabilesAcumulados = 0
        DiasHabilesTotales = 0

        Fecha = New Date(Fecha.Year, Fecha.Month, 1)

        For i = 1 To Date.DaysInMonth(Fecha.Year, Fecha.Month)

            'El dia es entre lunes y viernes
            If Fecha.DayOfWeek >= DayOfWeek.Monday And Fecha.DayOfWeek <= DayOfWeek.Friday Then
                'Miro si es feriado
                If Not BuscarFeriado(Fecha, dt) Then
                    'Calculo habiles Acumulados
                    If Fecha <= mCal.SelectionStart Then DiasHabilesAcumulados += 1
                    'Calculo habiles totales
                    DiasHabilesTotales += 1
                End If
            End If

            Fecha = Fecha.AddDays(1)
        Next

        With pBar
            .Value = 0
            .Minimum = 0
            .Maximum = dtPpal.Rows.Count
        End With

        'CALCULO LOS CAMPOS PROYECTADOS
        For Each dr In dtPpal.Rows
            If dr.RowState <> DataRowState.Deleted Then
                dr.BeginEdit()
                dr("qtypro_0") = CDbl(dr("qtyacu_0")) * DiasHabilesTotales / DiasHabilesAcumulados
                dr("imppro_0") = CDbl(dr("impacu_0")) * DiasHabilesTotales / DiasHabilesAcumulados
                dr("marpro_0") = CDbl(dr("maracu_0")) * DiasHabilesTotales / DiasHabilesAcumulados
                dr.EndEdit()
            End If

            pBar.Value += 1

        Next

        dt.Dispose()
        da.Dispose()

    End Sub
    Private Sub CargarFeriados()
        Dim Sql As String = "SELECT dat_0 FROM xferiados"
        Dim da As New OracleDataAdapter(Sql, cn)
        Dim dt As New DataTable

        'Consulto los feriados
        da.Fill(dt)

        'Si la tabla contiene feriados los agrego al control calendario
        If dt.Rows.Count > 0 Then

            'Matriz para almacenar las fechas de los feriados
            Dim Feriados(dt.Rows.Count) As Date

            'Recorro la tabla y guardo las fechas en la matriz
            For i As Integer = 0 To dt.Rows.Count - 1
                Feriados(i) = CDate(dt.Rows(i).Item("dat_0"))
            Next

            'Asigno la matriz a la propiedad del calendario
            mCal.BoldedDates = Feriados

        Else
            mCal.BoldedDates = Nothing

        End If

        da.Dispose()
        dt.Dispose()
    End Sub
    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click

        Me.UseWaitCursor = True
        Application.DoEvents()
        btnGenerar.Enabled = False

        If rpt IsNot Nothing Then rpt.Dispose()
        rpt = New ReportDocument
        crv.ReportSource = Nothing

        Application.DoEvents()

        AbrirTablaPrincipal()
        CalcularVentasDia()
        CalcularProyectados()

        daPpal.Update(dtPpal)

        rpt.Load(RPTX3 & "XCDC.rpt") 'Reporte normal

        rpt.SetParameterValue("X3USR", usr.Codigo)
        rpt.SetParameterValue("X3TIT", "Control diario Comercial")
        rpt.SetParameterValue("DHACU", DiasHabilesAcumulados)
        rpt.SetParameterValue("DHTOT", DiasHabilesTotales)

        rpt.SetDatabaseLogon(DB_USR, DB_PWD)
        crv.ReportSource = rpt

        Me.UseWaitCursor = False
        btnGenerar.Enabled = True

    End Sub

    Private Sub frmRptVtas_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        On Error Resume Next
        CType(crv.ReportSource, ReportDocument).Dispose()
        crv.Dispose()
        GC.Collect()
    End Sub
    Private Sub frmRptVtas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Adaptadores()

        Try
            CargarFeriados()

            btnGenerar.Enabled = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub AplicarPresupuesto()
        Dim Sql As String
        Dim da As OracleDataAdapter
        Dim dt As New DataTable
        Dim dv As DataView

        Sql = "SELECT * FROM presupues WHERE ano_0 = :ano AND mes_0 = :mes"
        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("ano", OracleType.Number).Value = FechaInicio.Year
        da.SelectCommand.Parameters.Add("mes", OracleType.Number).Value = FechaInicio.Month
        da.Fill(dt)
        dv = New DataView(dt)

        For Each dr As DataRow In dtPpal.Rows
            If dr.RowState = DataRowState.Deleted Then Continue For

            Dim f As String = "tsicod3_0 = '{3}' and tsicod4_0 = '{4}'"
            f = f.Replace("{3}", dr("tsicod3_0").ToString)
            f = f.Replace("{4}", dr("tsicod4_0").ToString)

            dv.RowFilter = f

            If dv.Count = 0 Then
                dr.BeginEdit()
                dr("qtyhis_0") = 0
                dr("prehis_0") = 0
                dr("imphis_0") = 0
                dr.EndEdit()
            Else
                Dim q As Double = CDbl(dv.Item(0).Item(4))
                Dim i As Double = CDbl(dv.Item(0).Item(5))
                Dim p As Double = CDbl(IIf(q > 0, i / q, 0))

                dr.BeginEdit()
                dr("qtyhis_0") = q
                dr("prehis_0") = p
                dr("imphis_0") = i
                dr.EndEdit()
            End If

        Next

    End Sub

End Class