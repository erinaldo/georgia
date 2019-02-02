Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.OracleClient

Public Class frmRptVtas

    Private daPpal As OracleDataAdapter
    Private dtPpal As New DataTable
    Private daVend As OracleDataAdapter
    Private dtVend As New DataTable
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

        If rbRpt1.Checked Then
            'Recupero las familias 4 y 5
            Sql = "SELECT DISTINCT ' ' AS tsicod_1, ' ' AS tsicod_2, tsicod_3, tsicod_4 "
            Sql &= "FROM itmmaster "
            Sql &= "WHERE tsicod_3 <> ' ' AND tsicod_4 <> ' ' "
            Sql &= "ORDER BY tsicod_3, tsicod_4"

        ElseIf rbRpt2.Checked Then
            'Recupero las familias 2, 3, 4 y 5
            Sql = "SELECT DISTINCT tsicod_1, tsicod_2, tsicod_3, tsicod_4 "
            Sql &= "FROM itmmaster "
            Sql &= "WHERE tsicod_1 <> ' ' AND tsicod_2 <> ' ' AND tsicod_3 = '301' AND tsicod_4 <> ' ' "
            Sql &= "ORDER BY tsicod_4, tsicod_2, tsicod_1"

        Else
            'Recupero las familias 2, 3, 4 y 5
            Sql = "SELECT DISTINCT tsicod_1, tsicod_2, tsicod_3, tsicod_4 "
            Sql &= "FROM itmmaster "
            Sql &= "WHERE tsicod_1 BETWEEN '133' AND '195' AND "
            Sql &= "      tsicod_2 <> ' ' AND "
            Sql &= "      tsicod_3 = '304' AND "
            Sql &= "      tsicod_4 <> ' ' "
            Sql &= "ORDER BY tsicod_4, tsicod_2, tsicod_1"

        End If

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
            dr1("fecha_0") = Calendario.SelectionStart
            dtPpal.Rows.Add(dr1)
        Next

        With ProgressBar1
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

        FechaFinal = Calendario.SelectionStart
        FechaInicio = New Date(FechaFinal.Year, FechaFinal.Month, 1)

        'Consulta para recuperar ventas del mes actual y del año anterior
        Sql = "SELECT  qty_0 * sns_0 AS cant, "
        Sql &= "       qty_0 * sns_0 * netpri_0 * ratcur_0 AS punit, "
        Sql &= "       {amtatilin_0} * sns_0 * ratcur_0 AS impii,"
        Sql &= "       itm.tsicod_1, itm.tsicod_2, itm.tsicod_3, itm.tsicod_4, accdat_0, rep1_0, "
        Sql &= "       qty_0 * sns_0 * pfm_0 * ratcur_0 AS margen, sid.itmref_0 "
        Sql &= "FROM (sinvoice siv INNER JOIN sinvoiced sid ON (siv.num_0 = sid.num_0)) INNER JOIN itmmaster itm ON (sid.itmref_0 = itm.itmref_0) "
        Sql &= "WHERE accdat_0 >= to_date(:datdeb1, 'dd/mm/yyyy') AND accdat_0 <= to_date(:datfin1, 'dd/mm/yyyy') AND sivtyp_0 <> 'PRF'"

        If Not chkMargen.Checked Then
            Sql &= "UNION ALL "
            Sql &= "SELECT qty_0 * sns_0 AS cant, "
            Sql &= "       qty_0 * sns_0 * netpri_0 * ratcur_0 AS punit, "
            Sql &= "       {amtatilin_0} * sns_0 * ratcur_0 AS impii, "
            Sql &= "       itm.tsicod_1, itm.tsicod_2, itm.tsicod_3, itm.tsicod_4, accdat_0, rep1_0, "
            Sql &= "       qty_0 * sns_0 * pfm_0 * ratcur_0 AS margen, sid.itmref_0 "
            Sql &= "FROM (sinvoice siv INNER JOIN sinvoiced sid ON (siv.num_0 = sid.num_0)) INNER JOIN itmmaster itm ON (sid.itmref_0 = itm.itmref_0) "
            Sql &= "WHERE accdat_0 >=  to_date(:datdeb2, 'dd/mm/yyyy') AND accdat_0 <= to_date(:datfin2, 'dd/mm/yyyy') AND sivtyp_0 <> 'PRF'"
        End If

        If chkIVA.Checked Then
            Sql = Strings.Replace(Sql, "{amtatilin_0}", "amtatilin_0")
        Else
            Sql = Strings.Replace(Sql, "{amtatilin_0}", "amtnotlin_0")
        End If

        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("datdeb1", OracleType.VarChar).Value = FechaInicio.ToString("dd/MM/yyyy")
        da.SelectCommand.Parameters.Add("datfin1", OracleType.VarChar).Value = FechaFinal.ToString("dd/MM/yyyy")

        If Not chkMargen.Checked Then
            da.SelectCommand.Parameters.Add("datdeb2", OracleType.VarChar).Value = FechaInicio.AddYears(-1).ToString("dd/MM/yyyy")
            da.SelectCommand.Parameters.Add("datfin2", OracleType.VarChar).Value = New Date(FechaInicio.Year - 1, FechaInicio.Month, Date.DaysInMonth(FechaInicio.Year - 1, FechaInicio.Month)).ToString("dd/MM/yyyy")
        End If

        Sql = Sql

        dt.Clear()
        da.Fill(dt)

        dv = New DataView(dtPpal)

        Application.DoEvents()

        'Barra de progreso
        ProgressBar1.Maximum += dt.Rows.Count

        Label1.Text = "Calculando venta del dia y acumulado mensual..."
        Label1.Refresh()
        Application.DoEvents()

        'CALCULO DE VENTAS DEL DIA Y ACUMULADO MENSUAL
        For Each dr In dt.Rows

            'Proceso el registro si el vendedor está chequeado
            If IsVendedorCheck(dr("rep1_0").ToString) Then

                If rbRpt1.Checked Then
                    dv.RowFilter = "tsicod3_0 = '" & dr("tsicod_3").ToString & "' AND tsicod4_0 = '" & dr("tsicod_4").ToString & "'"

                Else
                    dv.RowFilter = "tsicod1_0 = '" & dr("tsicod_1").ToString & "' AND tsicod2_0 = '" & dr("tsicod_2").ToString & "' AND tsicod3_0 = '" & dr("tsicod_3").ToString & "' AND tsicod4_0 = '" & dr("tsicod_4").ToString & "'"

                End If


                If dv.Count = 1 Then

                    With dv.Item(0).Row
                        .BeginEdit()
                        If CDate(dr("accdat_0")).Year = FechaInicio.Year Then
                            Dim Costo As Double = 0

                            If chkCosto.Checked Then
                                If itm.Abrir(dr("itmref_0").ToString) Then
                                    Costo = CDbl(dr("cant")) * itm.Costo
                                End If
                            End If

                            'Calculo venta del dia
                            If CDate(dr("accdat_0")) = FechaFinal Then
                                .Item("qtydia_0") = CDbl(.Item("qtydia_0")) + CDbl(dr("cant"))
                                .Item("predia_0") = CDbl(.Item("predia_0")) + CDbl(dr("punit"))
                                .Item("impdia_0") = CDbl(.Item("impdia_0")) + CDbl(dr("impii"))

                                'Calculo el costo de la mercaderia vendida
                                If chkCosto.Checked Then
                                    .Item("mardia_0") = CDbl(.Item("mardia_0")) + Costo

                                Else
                                    .Item("mardia_0") = CDbl(.Item("mardia_0")) + CDbl(dr("margen"))

                                End If

                            End If

                            'Calculo venta acumulada
                            .Item("qtyacu_0") = CDbl(.Item("qtyacu_0")) + CDbl(dr("cant"))
                            .Item("preacu_0") = CDbl(.Item("preacu_0")) + CDbl(dr("punit"))
                            .Item("impacu_0") = CDbl(.Item("impacu_0")) + CDbl(dr("impii"))

                            If chkCosto.Checked Then
                                .Item("maracu_0") = CDbl(.Item("maracu_0")) + Costo
                            Else
                                .Item("maracu_0") = CDbl(.Item("maracu_0")) + CDbl(dr("margen"))
                            End If

                        Else
                            'Calculo de venta historia del mismo mes del año anterior
                            .Item("qtyhis_0") = CDbl(.Item("qtyhis_0")) + CDbl(dr("cant"))
                            .Item("prehis_0") = CDbl(.Item("prehis_0")) + CDbl(dr("punit"))
                            .Item("imphis_0") = CDbl(.Item("imphis_0")) + CDbl(dr("impii"))
                        End If
                        .EndEdit()

                    End With

                End If

            End If

            ProgressBar1.Value += 1
            Application.DoEvents()
        Next

        'Barra de progreso
        With ProgressBar1
            .Value = 0
            .Minimum = 0
            .Maximum = dtPpal.Rows.Count
        End With


        If chkPresupuesto.Checked Then AplicarPresupuesto()

        Label1.Text = "Calculando calculando promedios..."
        Label1.Refresh()
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
                    If Not chkPresupuesto.Checked Then
                        If CDbl(dr("qtyhis_0")) <> 0 Then dr("prehis_0") = CDbl(dr("prehis_0")) / CDbl(dr("qtyhis_0"))
                    End If
                    dr("fecha_0") = Calendario.SelectionStart
                    dr.EndEdit()
                End If

            End If

            ProgressBar1.Value += 1
        Next

    End Sub
    Private Sub CalcularProyectados()
        Dim Fecha As Date = Calendario.SelectionStart
        Dim i As Integer
        Dim da As OracleDataAdapter
        Dim dt As New DataTable
        Dim dr As DataRow

        da = New OracleDataAdapter("SELECT * FROM xferiados WHERE EXTRACT(YEAR FROM dat_0) = :YY AND EXTRACT(MONTH FROM dat_0) = :MM", cn)
        da.SelectCommand.Parameters.Add("YY", OracleType.Int16).Value = Calendario.SelectionStart.Year
        da.SelectCommand.Parameters.Add("MM", OracleType.Int16).Value = Calendario.SelectionStart.Month

        da.Fill(dt)

        'CALCULO DE DIAS HABILES TOTALES Y ACUMULADOS
        DiasHabilesAcumulados = 0
        DiasHabilesTotales = 0

        Fecha = New Date(Fecha.Year, Fecha.Month, 1)

        Label1.Text = "Calculando días hábiles..."
        Label1.Refresh()

        For i = 1 To Date.DaysInMonth(Fecha.Year, Fecha.Month)

            'El dia es entre lunes y viernes
            If Fecha.DayOfWeek >= DayOfWeek.Monday And Fecha.DayOfWeek <= DayOfWeek.Friday Then
                'Miro si es feriado
                If Not BuscarFeriado(Fecha, dt) Then
                    'Calculo habiles Acumulados
                    If Fecha <= Calendario.SelectionStart Then DiasHabilesAcumulados += 1
                    'Calculo habiles totales
                    DiasHabilesTotales += 1
                End If
            End If

            Fecha = Fecha.AddDays(1)
        Next

        Label1.Text = "Calculando proyectados..."
        Label1.Refresh()

        With ProgressBar1
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

            ProgressBar1.Value += 1

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
            Calendario.BoldedDates = Feriados

        Else
            Calendario.BoldedDates = Nothing

        End If

        da.Dispose()
        dt.Dispose()
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

        AbrirTablaPrincipal()
        CalcularVentasDia()
        CalcularProyectados()

        daPpal.Update(dtPpal)

        If rbRpt1.Checked Then  'Reporte de Ventas por linea de productos
            If chkMargen.Checked Then
                rpt.Load(RPTX3 & "XRPTVTASM.rpt") 'Reporte con margen
            ElseIf chkCosto.Checked Then
                rpt.Load(RPTX3 & "XRPTVTASC.rpt") 'Reporte con costo
            Else
                rpt.Load(RPTX3 & "XRPTVTAS.rpt") 'Reporte normal
            End If

            rpt.SetParameterValue("X3TIT", "Ventas por línea del día")

        ElseIf rbRpt2.Checked Then   'Reporte de seguimiento de extintores

            If chkMargen.Checked Then
                rpt.Load(RPTX3 & "XRPTVTAS2M.rpt") 'Reporte con margen
            Else
                rpt.Load(RPTX3 & "XRPTVTAS2.rpt") 'Reporte normal
            End If

            rpt.SetParameterValue("X3TIT", "Seguimiento de extintores")

        Else 'Reporte de seguimiento de sistemas fijos

            If chkMargen.Checked Then
                rpt.Load(RPTX3 & "XRPTVTAS3M.rpt") 'Reporte con margen
            Else
                rpt.Load(RPTX3 & "XRPTVTAS3.rpt") 'Reporte normal
            End If

            rpt.SetParameterValue("X3TIT", "Seguimiento de Sistemas Fijos")

        End If

        rpt.SetParameterValue("X3USR", usr.Codigo)
        rpt.SetParameterValue("DHACU", DiasHabilesAcumulados)
        rpt.SetParameterValue("DHTOT", DiasHabilesTotales)
        rpt.SetDatabaseLogon(DB_USR, DB_PWD)
        crv.ReportSource = rpt

        Me.UseWaitCursor = False
        btnGenerar.Enabled = True
        Label1.Visible = False

    End Sub

    Private Sub frmRptVtas_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        On Error Resume Next
        CType(crv.ReportSource, ReportDocument).Dispose()
        crv.Dispose()
        GC.Collect()
    End Sub
    Private Sub frmRptVtas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Adaptadores()

        chkCosto.Visible = usr.Codigo.Length <> 2

        Try
            CargarFeriados()
            CargarVendedores()

            'Si el usuario es vendedor desactivo el CheckBox Mostrar Margen
            If Usr.Codigo.Length = 2 Then
                chkMargen.Enabled = False
                chkMargen.Checked = False
                rbRpt2.Enabled = False
            End If

            btnGenerar.Enabled = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    'MENU CONTEXTUAL DEL CALENDARIO
    Private Sub ContextMenuStrip1_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening

        If Array.IndexOf(Calendario.BoldedDates, Calendario.SelectionStart) >= 0 Then
            mnuMarcarFeriado.Visible = False
            mnuQuitarFeriado.Visible = True
        Else
            mnuMarcarFeriado.Visible = True
            mnuQuitarFeriado.Visible = False
        End If

    End Sub
    Private Sub mnuMarcarFeriado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMarcarFeriado.Click
        Dim cm As New OracleCommand("INSERT INTO xferiados VALUES (:dat_0, :usr_0)", cn)
        cm.Parameters.Add("dat_0", OracleType.DateTime).Value = Calendario.SelectionStart
        cm.Parameters.Add("usr_0", OracleType.VarChar).Value = USR.Codigo

        Try
            'Agrego la fecha a la tabla de feriados
            cm.ExecuteNonQuery()

            CargarFeriados()

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            cm.Dispose()

        End Try

    End Sub
    Private Sub mnuQuitarFeriado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuQuitarFeriado.Click
        Dim cm As New OracleCommand("DELETE FROM xferiados WHERE dat_0 = :dat_0", cn)
        cm.Parameters.Add("dat_0", OracleType.DateTime).Value = Calendario.SelectionStart

        Try
            cm.ExecuteNonQuery()

            CargarFeriados()

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
    Private Sub rbRpt1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbRpt1.CheckedChanged, rbRpt2.CheckedChanged
        Dim o As RadioButton = CType(sender, RadioButton)

        If o Is rbRpt1 Then
            chkCosto.Enabled = rbRpt1.Checked
            If Not chkCosto.Enabled Then chkCosto.Checked = False
        End If
    End Sub
    Private Sub chkPresupuesto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPresupuesto.CheckedChanged
        If chkPresupuesto.Checked Then chkIVA.Checked = False
    End Sub
    Private Sub chkIVA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIVA.CheckedChanged
        If chkIVA.Checked Then chkPresupuesto.Checked = False
    End Sub

End Class