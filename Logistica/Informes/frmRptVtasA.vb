Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.OracleClient

'REPORTE DE VENTAS ANUAL
Public Class frmRptVtasA

    Private daPpal As OracleDataAdapter
    Private dtPpal As New DataTable
    Private daVend As OracleDataAdapter
    Private dtVend As New DataTable
    Private DiasHabilesAcumulados As Integer = 0
    Private DiasHabilesTotales As Integer = 0
    Private AnoConsulta As Integer = 0
    Private rpt As ReportDocument
    Private Desde As Date
    Private Hasta As Date

    Private Function IsVendedorCheck(ByVal Rep As String) As Boolean
        Dim flg As Boolean = False

        With lstVendedores
            For Each dr As DataRowView In .CheckedItems
                If Rep = dr("repnum_0").ToString Then
                    flg = True
                    Exit For
                End If
            Next
        End With

        Return flg

    End Function
    Private Function ListadoVendedoresChequeados() As String
        Dim str As String = ""
        Dim dr As DataRowView

        With lstVendedores
            If .Items.Count = .CheckedItems.Count Then
                str = "Todos"

            Else
                For Each dr In .CheckedItems
                    str &= dr("repnum_0").ToString & ", "
                Next

                str = str.Substring(0, str.Length - 2)

            End If
        End With

        Return str

    End Function
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

        Sql = "SELECT repnum_0, repnam_0 FROM salesrep WHERE activo_0 = 2 ORDER BY repnam_0"
        daVend = New OracleDataAdapter(Sql, cn)

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

        'Elimino todos los registros anteriores
        For Each dr1 In dtPpal.Rows
            dr1.Delete()
        Next

        If rbRpt1.Checked Then
            'Recupero las familias 4 y 5
            Sql = "SELECT DISTINCT ' ' AS tsicod_1, ' ' AS tsicod_2, tsicod_3, tsicod_4 "
            Sql &= "FROM itmmaster "
            Sql &= "WHERE tsicod_3 <> ' ' AND tsicod_4 <> ' ' "
            Sql &= "ORDER BY tsicod_3, tsicod_4"

            da = New OracleDataAdapter(Sql, cn)
            da.Fill(dt)

            'Agrego las familias 4 y 5 a la tabla
            For Each dr In dt.Rows
                dr1 = dtPpal.NewRow
                dr1("usr_0") = Usr.Codigo
                dr1("tsicod1_0") = " "
                dr1("tsicod2_0") = " "
                dr1("tsicod3_0") = dr("tsicod_3")
                dr1("tsicod4_0") = dr("tsicod_4")
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
                dr1("fecha_0") = Hasta.AddDays(-1)
                dtPpal.Rows.Add(dr1)
            Next
        Else
            'Recupero las familias 4 y 5
            'Sql = "SELECT DISTINCT ' ' AS tsicod_1, ' ' AS tsicod_2, tsicod_3, tsicod_4 "
            'Sql &= "FROM itmmaster "
            'Sql &= "WHERE tsicod_3 <> ' ' AND tsicod_4 <> ' ' "
            'Sql &= "ORDER BY tsicod_3, tsicod_4"
            Sql = " SELECT EXTRACT(MONTH FROM accdat_0) AS MES, itm.tsicod_4, itm.tsicod_2, itm.tsicod_1, ' ' AS cant  "
            Sql &= "FROM (sinvoice siv INNER JOIN sinvoiced sid ON (siv.num_0 = sid.num_0)) INNER JOIN itmmaster itm ON (sid.itmref_0 = itm.itmref_0) "
            Sql &= "WHERE EXTRACT(YEAR FROM accdat_0) = :accdat_0 AND sivtyp_0 <> 'PRF' AND tsicod_3 = '301' "
            Sql &= "GROUP BY EXTRACT(MONTH FROM accdat_0), itm.tsicod_4, itm.tsicod_2, itm.tsicod_1 "
            Sql &= "ORDER BY mes, tsicod_4, tsicod_2, tsicod_1"

            da = New OracleDataAdapter(Sql, cn)
            da.SelectCommand.Parameters.Add("accdat_0", OracleType.Number).Value = nudAno.Value
            da.Fill(dt)

            'Agrego las familias 4 y 5 a la tabla
            For Each dr In dt.Rows
                dr1 = dtPpal.NewRow
                dr1("usr_0") = usr.Codigo
                dr1("tsicod1_0") = dr("tsicod_1")
                dr1("tsicod2_0") = dr("tsicod_2")
                dr1("tsicod3_0") = dr("mes")
                dr1("tsicod4_0") = dr("tsicod_4")
                dr1("qtydia_0") = 0
                dr1("predia_0") = dr("mes")
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
                dr1("fecha_0") = Hasta.AddDays(-1)
                dtPpal.Rows.Add(dr1)
            Next
        End If

        With ProgressBar1
            .Value = 0
            .Minimum = 0
            .Maximum = dtPpal.Rows.Count
        End With

    End Sub
    Private Sub ObtenerVentas()
        Dim Sql As String
        Dim dt As New DataTable
        Dim da As OracleDataAdapter
        Dim dv As DataView
        Dim dr As DataRow
        Dim itm As New Articulo(cn)
        Dim Costo As Double = 0

        'Consulta para recuperar ventas del AÑO actual y del año anterior
        Sql = "SELECT  qty_0 * sns_0 AS cant, qty_0 * sns_0 * netpri_0 * ratcur_0 AS punit, "
        Sql &= "       {amtatilin_0} * sns_0 * ratcur_0 AS impii, "
        Sql &= "       itm.tsicod_3, itm.tsicod_4, accdat_0, rep1_0, sid.itmref_0 "
        Sql &= "FROM (sinvoice siv INNER JOIN sinvoiced sid ON (siv.num_0 = sid.num_0)) INNER JOIN itmmaster itm ON (sid.itmref_0 = itm.itmref_0) "
        Sql &= "WHERE accdat_0 >= :desde AND "
        Sql &= "      accdat_0 < :hasta AND "
        Sql &= "      sivtyp_0 <> 'PRF' "
        Sql &= "ORDER BY accdat_0"

        If chkIVA.Checked Then
            Sql = Strings.Replace(Sql, "{amtatilin_0}", "amtatilin_0")
        Else
            Sql = Strings.Replace(Sql, "{amtatilin_0}", "amtnotlin_0")
        End If

        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("desde", OracleType.DateTime)
        da.SelectCommand.Parameters.Add("hasta", OracleType.DateTime)

        Label1.Text = "Recuperando datos año " & AnoConsulta.ToString & "..."
        Application.DoEvents() : Application.DoEvents()
        da.SelectCommand.Parameters("desde").Value = Desde
        da.SelectCommand.Parameters("hasta").Value = Hasta
        da.Fill(dt)

        If Not chkPresupuesto.Checked Then
            Label1.Text = "Recuperando datos año anterior..."
            Application.DoEvents() : Application.DoEvents()
            da.SelectCommand.Parameters("desde").Value = Desde.AddYears(-1)
            da.SelectCommand.Parameters("hasta").Value = Hasta.AddYears(-1)
            da.Fill(dt)
        End If

        dv = New DataView(dtPpal)

        Application.DoEvents()

        'Barra de progreso
        ProgressBar1.Maximum += dt.Rows.Count

        Label1.Text = "Procesando los datos..."
        Label1.Refresh()
        Application.DoEvents()

        'CALCULO DE VENTAS DEL AÑO Y AÑO ANTERIOR
        For Each dr In dt.Rows
            'Proceso el registro si el vendedor está chequeado
            If IsVendedorCheck(dr("rep1_0").ToString) Then

                'Filtro la familia a la que voy a sumar las cantidades
                dv.RowFilter = "tsicod3_0 = '" & dr("tsicod_3").ToString & "' AND tsicod4_0 = '" & dr("tsicod_4").ToString & "'"

                If dv.Count = 1 Then 'Encontre la familia
                    With dv.Item(0).Row
                        .BeginEdit()
                        'Calculo venta de año consultado
                        If CDate(dr("accdat_0")).Year = AnoConsulta Then

                            .Item("qtydia_0") = CDbl(.Item("qtydia_0")) + CDbl(dr("cant"))
                            '.Item("predia_0") = CDbl(.Item("predia_0")) + CDbl(dr("punit"))
                            .Item("impdia_0") = CDbl(.Item("impdia_0")) + CDbl(dr("impii"))

                            .Item("qtyacu_0") = CDbl(.Item("qtyacu_0")) + CDbl(dr("cant"))
                            '.Item("preacu_0") = CDbl(.Item("preacu_0")) + CDbl(dr("punit"))
                            .Item("impacu_0") = CDbl(.Item("impacu_0")) + CDbl(dr("impii"))

                            If chkCosto.Checked Then
                                If itm.Abrir(dr("itmref_0").ToString) Then
                                    Costo = CDbl(dr("cant")) * itm.Costo
                                    .Item("mardia_0") = CDbl(.Item("mardia_0")) + Costo
                                End If
                            End If

                        Else
                            .Item("qtyhis_0") = CDbl(.Item("qtyhis_0")) + CDbl(dr("cant"))
                            '.Item("prehis_0") = CDbl(.Item("prehis_0")) + CDbl(dr("punit"))
                            .Item("imphis_0") = CDbl(.Item("imphis_0")) + CDbl(dr("impii"))

                        End If
                        .EndEdit()
                    End With

                End If

            End If

            ProgressBar1.Value += 1
            Application.DoEvents()
        Next

        If chkPresupuesto.Checked Then
            Label1.Text = "Aplicando presupuesto..."
            Label1.Refresh()
            Application.DoEvents()
            AplicarPresupuesto(Hasta)
        End If

        'Barra de progreso
        With ProgressBar1
            .Value = 0
            .Minimum = 0
            .Maximum = dtPpal.Rows.Count
        End With

        Label1.Text = "Calculando promedios..."
        Label1.Refresh()
        Application.DoEvents()

        'Elimino registros sin cantidades
        For i As Integer = dtPpal.Rows.Count - 1 To 0 Step -1
            dr = dtPpal.Rows(i)

            If dr.RowState <> DataRowState.Deleted Then

                If CInt(dr("qtydia_0")) = 0 And CInt(dr("qtyacu_0")) = 0 And CInt(dr("qtyhis_0")) = 0 Then
                    'Elimino registro sin cantidades
                    dr.Delete()
                End If

            End If

            ProgressBar1.Value += 1
        Next

    End Sub
    Private Sub ObtenerVentasExtintor()
        'Obtiene las cantidades vendidas por familias por mes
        Dim Sql As String
        Dim dt As New DataTable
        Dim da As OracleDataAdapter
        Dim dv As DataView
        Dim dr1 As DataRow

        Sql = "SELECT EXTRACT(MONTH FROM accdat_0) AS MES, itm.tsicod_4, itm.tsicod_2, itm.tsicod_1, sum(qty_0 * sns_0) AS cant, REP1_0  "
        Sql &= "FROM (sinvoice siv INNER JOIN sinvoiced sid ON (siv.num_0 = sid.num_0)) INNER JOIN itmmaster itm ON (sid.itmref_0 = itm.itmref_0) "
        Sql &= "WHERE EXTRACT(YEAR FROM accdat_0) = :accdat_0 AND sivtyp_0 <> 'PRF' AND tsicod_3 = '301' "
        Sql &= "GROUP BY EXTRACT(MONTH FROM accdat_0), itm.tsicod_4, itm.tsicod_2, itm.tsicod_1 , REP1_0 "
        Sql &= "ORDER BY mes, tsicod_4, tsicod_2, tsicod_1"

        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("accdat_0", OracleType.Number).Value = nudAno.Value
        da.Fill(dt)
        da.Dispose()

        dv = New DataView(dtPpal)
        For Each dr1 In dt.Rows
            'Proceso el registro si el vendedor está chequeado
            If IsVendedorCheck(dr1("rep1_0").ToString) Then

                'Filtro la familia a la que voy a sumar las cantidades
                dv.RowFilter = "tsicod1_0 = '" & dr1("tsicod_1").ToString & "' AND tsicod2_0 = '" & dr1("tsicod_2").ToString & "' AND tsicod3_0 = '" & dr1("mes").ToString & "' AND tsicod4_0 = '" & dr1("tsicod_4").ToString & "'"

                If dv.Count = 1 Then 'Encontre la familia
                    With dv.Item(0).Row
                        .BeginEdit()
                        'Calculo venta de año consultado

                        .Item("qtydia_0") = CDbl(.Item("qtydia_0")) + CDbl(dr1("cant"))
                        .EndEdit()
                    End With

                End If

            End If

            'ProgressBar1.Value += 1
            Application.DoEvents()
        Next
        'For Each dr2 In dt.Rows
        '    dr1 = dtPpal.NewRow
        '    dr1("usr_0") = Usr.Codigo
        '    dr1("tsicod1_0") = dr2("tsicod_1").ToString
        '    dr1("tsicod2_0") = dr2("tsicod_2").ToString
        '    dr1("tsicod3_0") = dr2("mes").ToString
        '    dr1("tsicod4_0") = dr2("tsicod_4").ToString
        '    dr1("qtydia_0") = CLng(dr2("cant"))
        '    dr1("predia_0") = CInt(dr2("mes"))
        '    dr1("impdia_0") = 0
        '    dr1("mardia_0") = 0
        '    dr1("qtyacu_0") = 0
        '    dr1("preacu_0") = 0
        '    dr1("impacu_0") = 0
        '    dr1("maracu_0") = 0
        '    dr1("qtypro_0") = 0
        '    dr1("imppro_0") = 0
        '    dr1("marpro_0") = 0
        '    dr1("qtyhis_0") = 0
        '    dr1("prehis_0") = 0
        '    dr1("imphis_0") = 0
        '    dr1("fecha_0") = New Date(CInt(nudAno.Value), 1, 1)
        '    dtPpal.Rows.Add(dr1)
        'Next

    End Sub
    Private Sub CargarVendedores()
        Dim i As Integer
        Dim dr As DataRow

        'Cargo combo de vendedores
        daVend.Fill(dtVend)

        'Si el usuario es vendedor, elimino de la tabla los demás vendedores
        If usr.Codigo.Length = 2 Then
            For i = dtVend.Rows.Count - 1 To 0 Step -1
                dr = dtVend.Rows(i)

                If usr.Codigo <> dr("repnum_0").ToString Then
                    dtVend.Rows.Remove(dr)
                End If
            Next
        End If

        'Enlazo la tabla al ListBox
        With lstVendedores
            .DataSource = dtVend
            .ValueMember = "repnum_0"
            .DisplayMember = "repnam_0"
        End With

        'Recorro todos los vendedores y los chequeo
        For i = 0 To lstVendedores.Items.Count - 1
            lstVendedores.SetItemChecked(i, True)
        Next

    End Sub
    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click

        'Valido que al menos haya seleccionado un vendedor
        If lstVendedores.CheckedItems.Count = 0 Then
            MessageBox.Show("Debe seleccionar al menos un vendedor", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        Me.UseWaitCursor = True
        Application.DoEvents()
        btnGenerar.Enabled = False
        Label1.Text = "Recuperando datos..."
        Label1.Visible = True

        If rpt IsNot Nothing Then rpt.Dispose()
        rpt = New ReportDocument
        crv.ReportSource = Nothing

        Application.DoEvents()

        AnoConsulta = CInt(nudAno.Value)

        If AnoConsulta = Date.Today.Year Then
            Desde = New Date(Today.Year, 1, 1)
            Hasta = New Date(Today.Year, Today.Month, 1)
        Else
            Desde = New Date(AnoConsulta, 1, 1)
            Hasta = Desde.AddYears(1)
        End If

        If rbRpt1.Checked Then
            AbrirTablaPrincipal()
            ObtenerVentas()

        Else
            AbrirTablaPrincipal()
            ObtenerVentasExtintor()

        End If

        daPpal.Update(dtPpal)

        If rbRpt1.Checked Then
            rpt.Load(RPTX3 & "XRPTVTASA.rpt")
            rpt.SetParameterValue("X3TIT", "Ventas por línea del año")
        Else
            rpt.Load(RPTX3 & "XRPTVTASA2.rpt")
            rpt.SetParameterValue("X3TIT", "Seguimiento de extintores")
        End If

        rpt.SetParameterValue("X3USR", Usr.Codigo)
        rpt.SetDatabaseLogon(DB_USR, DB_PWD)
        crv.ReportSource = rpt

        Me.UseWaitCursor = False
        btnGenerar.Enabled = True
        Label1.Visible = False

    End Sub
    Private Sub frmRptVtasA_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If rpt IsNot Nothing Then rpt.Dispose()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub frmRptVtas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Adaptadores()

        nudAno.Maximum = Date.Today.Year
        nudAno.Value = Date.Today.Year

        chkCosto.Visible = usr.Codigo.Length <> 2

        Try
            CargarVendedores()

            btnGenerar.Enabled = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    'MENU CONTEXTUAL DE LA LISTA DE VENDEDORES
    Private Sub mnuMarcarTodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMarcarTodos.Click
        For i As Integer = 0 To lstVendedores.Items.Count - 1
            lstVendedores.SetItemChecked(i, True)
        Next
    End Sub
    Private Sub mnuDesmarcarTodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDesmarcarTodos.Click
        For i As Integer = 0 To lstVendedores.Items.Count - 1
            lstVendedores.SetItemChecked(i, False)
        Next
    End Sub

    Private Sub rbRpt1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbRpt1.CheckedChanged
        If rbRpt1.Checked Then
            lstVendedores.Enabled = True
            chkCosto.Enabled = True
            chkPresupuesto.Enabled = True
            chkIVA.Enabled = True

        Else
            'For i As Integer = 0 To lstVendedores.Items.Count - 1
            '    lstVendedores.SetItemChecked(i, True)
            'Next
            'lstVendedores.Enabled = False

            chkCosto.Enabled = False
            chkCosto.Checked = False
            chkPresupuesto.Enabled = False
            chkPresupuesto.Checked = False
            chkIVA.Enabled = False
            chkIVA.Checked = False
        End If
    End Sub
    Private Sub chkPresupuesto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPresupuesto.CheckedChanged
        If chkPresupuesto.Checked Then chkIVA.Checked = False
    End Sub
    Private Sub chkIVA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIVA.CheckedChanged
        If chkIVA.Checked Then chkPresupuesto.Checked = False
    End Sub
    Private Sub AplicarPresupuesto(ByVal Fecha As Date)
        Dim Sql As String
        Dim da As OracleDataAdapter
        Dim dt As New DataTable
        Dim dv As DataView

        Fecha = Fecha.AddDays(-1)

        Sql = "select tsicod3_0, tsicod4_0, sum(qty_0) as qty, sum(imp_0) as imp "
        Sql &= "from presupues "
        Sql &= "where ano_0 = :ano and "
        Sql &= "	  mes_0 <= :mes "
        Sql &= "group by tsicod3_0, tsicod4_0"

        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("ano", OracleType.Number).Value = Fecha.Year
        da.SelectCommand.Parameters.Add("mes", OracleType.Number).Value = Fecha.Month

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
                Dim q As Double = CDbl(dv.Item(0).Item(2))
                Dim i As Double = CDbl(dv.Item(0).Item(3))

                dr.BeginEdit()
                dr("qtyhis_0") = q
                dr("imphis_0") = i
                dr.EndEdit()
            End If

        Next

    End Sub

End Class