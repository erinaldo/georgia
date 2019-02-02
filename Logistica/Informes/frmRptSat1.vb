Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.OracleClient

Public Class frmSat1

    Private daPpal As OracleDataAdapter
    Private dtPpal As New DataTable
    Private daVend As OracleDataAdapter
    Private dtVend As New DataTable
    Private DiasHabilesAcumulados As Integer = 0
    Private DiasHabilesTotales As Integer = 0
    Private rpt As ReportDocument

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

        Sql = "SELECT repnum_0, repnam_0 FROM salesrep WHERE length(repnum_0) = 2 ORDER BY repnam_0"
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

        'Recupero todas las provincias
        Sql = "SELECT ident2_0, texte_0 FROM atextra WHERE codfic_0 = 'ATABDIV' AND ident1_0 = '364' AND zone_0 = 'LNGDES'"
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
            dr1("tsicod1_0") = dr("ident2_0").ToString   'Cod. provincia
            dr1("tsicod2_0") = dr("texte_0").ToString   'Des. provincia
            dr1("tsicod3_0") = " "
            dr1("tsicod4_0") = " "
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
        Dim FechaInicio As Date
        Dim FechaFinal As Date

        FechaFinal = Calendario.SelectionStart
        FechaInicio = New Date(FechaFinal.Year, FechaFinal.Month, 1)

        'Consulta para recuperar ventas del mes actual y del año anterior
        Sql = "SELECT  qty_0 * sns_0 AS cant, qty_0 * sns_0 * netpri_0 * ratcur_0 AS punit, amtatilin_0 * sns_0 * ratcur_0 AS impii, accdat_0, rep1_0, qty_0 * sns_0 * pfm_0 * ratcur_0 AS margen, sat_0 "
        Sql &= "FROM ((sinvoice siv INNER JOIN sinvoiced sid ON (siv.num_0 = sid.num_0)) INNER JOIN itmmaster itm ON (sid.itmref_0 = itm.itmref_0)) INNER JOIN bpcustomer bpc ON (siv.bpr_0 = bpc.bpcnum_0) "
        Sql &= "WHERE accdat_0 >= to_date(:datdeb1, 'dd/mm/yyyy') AND accdat_0 <= to_date(:datfin1, 'dd/mm/yyyy') AND sivtyp_0 <> 'PRF' AND tsicod_4 <> '593' AND tsccod_1 = '20' "
        Sql &= "UNION ALL "
        Sql &= "SELECT qty_0 * sns_0 AS cant, qty_0 * sns_0 * netpri_0 * ratcur_0 AS punit, amtatilin_0 * sns_0 * ratcur_0 AS impii, accdat_0, rep1_0, qty_0 * sns_0 * pfm_0 * ratcur_0 AS margen, sat_0 "
        Sql &= "FROM ((sinvoice siv INNER JOIN sinvoiced sid ON (siv.num_0 = sid.num_0)) INNER JOIN itmmaster itm ON (sid.itmref_0 = itm.itmref_0)) INNER JOIN bpcustomer bpc ON (siv.bpr_0 = bpc.bpcnum_0) "
        Sql &= "WHERE accdat_0 >=  to_date(:datdeb2, 'dd/mm/yyyy') AND accdat_0 <= to_date(:datfin2, 'dd/mm/yyyy') AND sivtyp_0 <> 'PRF' AND tsicod_4 <> '593' AND tsccod_1 = '20' "

        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("datdeb1", OracleType.VarChar).Value = FechaInicio.ToString("dd/MM/yyyy")
        da.SelectCommand.Parameters.Add("datfin1", OracleType.VarChar).Value = FechaFinal.ToString("dd/MM/yyyy")

        da.SelectCommand.Parameters.Add("datdeb2", OracleType.VarChar).Value = FechaInicio.AddYears(-1).ToString("dd/MM/yyyy")
        da.SelectCommand.Parameters.Add("datfin2", OracleType.VarChar).Value = New Date(FechaInicio.Year - 1, FechaInicio.Month, Date.DaysInMonth(FechaInicio.Year - 1, FechaInicio.Month)).ToString("dd/MM/yyyy")


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

                dv.RowFilter = "tsicod1_0 = '" & dr("sat_0").ToString & "'"

                If dv.Count = 1 Then
                    With dv.Item(0).Row
                        .BeginEdit()
                        If CDate(dr("accdat_0")).Year = FechaInicio.Year Then

                            'Calculo venta del dia
                            If CDate(dr("accdat_0")) = FechaFinal Then
                                .Item("qtydia_0") = CDbl(.Item("qtydia_0")) + CDbl(dr("cant"))
                                .Item("predia_0") = CDbl(.Item("predia_0")) + CDbl(dr("punit"))
                                .Item("impdia_0") = CDbl(.Item("impdia_0")) + CDbl(dr("impii"))
                                .Item("mardia_0") = CDbl(.Item("mardia_0")) + CDbl(dr("margen"))
                            End If

                            'Calculo venta acumulada
                            .Item("qtyacu_0") = CDbl(.Item("qtyacu_0")) + CDbl(dr("cant"))
                            .Item("preacu_0") = CDbl(.Item("preacu_0")) + CDbl(dr("punit"))
                            .Item("impacu_0") = CDbl(.Item("impacu_0")) + CDbl(dr("impii"))
                            .Item("maracu_0") = CDbl(.Item("maracu_0")) + CDbl(dr("margen"))

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

        Label1.Text = "Calculando calculando promedios..."
        Label1.Refresh()
        Application.DoEvents()

        'CALCULO PROMEDIOS Y ELIMINO REGISTROS SIN CANTIDADES
        For i As Integer = dtPpal.Rows.Count - 1 To 0 Step -1
            dr = dtPpal.Rows(i)

            If dr.RowState <> DataRowState.Deleted Then

                If CInt(dr("qtydia_0")) = 0 And CInt(dr("qtyacu_0")) = 0 And CInt(dr("qtyhis_0")) = 0 Then
                    'Elimino registro sin cantidades
                    'dr.Delete()
                Else
                    'Calculo precios promedios
                    dr.BeginEdit()
                    If CDbl(dr("qtydia_0")) <> 0 Then dr("predia_0") = CDbl(dr("predia_0")) / CDbl(dr("qtydia_0"))
                    If CDbl(dr("qtyacu_0")) <> 0 Then dr("preacu_0") = CDbl(dr("preacu_0")) / CDbl(dr("qtyacu_0"))
                    If CDbl(dr("qtyhis_0")) <> 0 Then dr("prehis_0") = CDbl(dr("prehis_0")) / CDbl(dr("qtyhis_0"))
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
        If USR.Codigo.Length = 2 Then
            For i = dtVend.Rows.Count - 1 To 0 Step -1
                dr = dtVend.Rows(i)

                If USR.Codigo <> dr("repnum_0").ToString Then
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

        crv.ReportSource = Nothing

        Application.DoEvents()

        AbrirTablaPrincipal()
        CalcularVentasDia()
        CalcularProyectados()

        daPpal.Update(dtPpal)

        If rpt IsNot Nothing Then rpt.Dispose()
        rpt = New ReportDocument

        rpt.Load(RPTX3 & "XRPTSAT1.rpt") 'Reporte normal
        rpt.SetParameterValue("X3TIT", "Ventas a distribuidores por provincias")
        rpt.SetParameterValue("X3USR", Usr.Codigo)
        rpt.SetParameterValue("DHACU", DiasHabilesAcumulados)
        rpt.SetParameterValue("DHTOT", DiasHabilesTotales)
        rpt.SetDatabaseLogon(DB_USR, DB_PWD)
        crv.ReportSource = rpt

        Me.UseWaitCursor = False
        btnGenerar.Enabled = True
        Label1.Visible = False

    End Sub

    Private Sub frmSat1_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If rpt IsNot Nothing Then rpt.Dispose()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub frmRptVtas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Adaptadores()

        Try
            CargarFeriados()
            CargarVendedores()

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

End Class