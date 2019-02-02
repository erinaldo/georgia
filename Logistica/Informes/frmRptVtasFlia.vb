Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.OracleClient

Public Class frmRptVtasFlia
    Private daPpal As OracleDataAdapter
    Private dtPpal As New DataTable
    Private daVend As OracleDataAdapter
    Private dtVend As New DataTable
    Private DiasHabilesAcumulados As Integer = 0
    Private DiasHabilesTotales As Integer = 0
    Private rpt As ReportDocument
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
    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
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

        rpt.Load(RPTX3 & "XRPTVTASFLIA.rpt")
        rpt.SetParameterValue("X3USR", usr.Codigo)
        rpt.SetParameterValue("X3TIT", "Reporte de ventas por flia")
        rpt.SetParameterValue("DHACU", DiasHabilesAcumulados)
        rpt.SetParameterValue("DHTOT", DiasHabilesTotales)
        rpt.SetDatabaseLogon(DB_USR, DB_PWD)
        crv.ReportSource = rpt

        Me.UseWaitCursor = False
        btnGenerar.Enabled = True
        Label1.Visible = False
    End Sub
    Private Sub AbrirTablaPrincipal()
        Dim da As OracleDataAdapter
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim dr1 As DataRow
        Dim Sql As String = ""

        daPpal.SelectCommand.Parameters("usr_0").Value = usr.Codigo
        dtPpal.Clear()
        daPpal.Fill(dtPpal)

        'Recupero las familias 4 y 5
        Sql = "SELECT DISTINCT ' ' AS tsicod_1, ident2_0 AS tsicod_2, tsicod_3, tsicod_4 "
        Sql &= "FROM itmmaster, atextra "
        Sql &= "WHERE tsicod_3 <> ' ' AND tsicod_4 <> ' ' and "
        Sql &= "      ident1_0 = '31' and"
        Sql &= "	  zone_0 = 'LNGDES' and"
        Sql &= "	  langue_0 = 'SPA' and"
        Sql &= "	  ident2_0 <> ' '"
        Sql &= "ORDER BY tsicod_2, tsicod_3, tsicod_4"

        da = New OracleDataAdapter(Sql, cn)
        da.Fill(dt)

        'Elimino todos los registros anteriores
        For Each dr1 In dtPpal.Rows
            dr1.Delete()
        Next

        'Agrego las familias 4 y 5 a la tabla
        For Each dr In dt.Rows
            dr1 = dtPpal.NewRow
            dr1("usr_0") = usr.Codigo
            dr1("tsicod1_0") = dr("tsicod_1").ToString   'Fam 2
            dr1("tsicod2_0") = dr("tsicod_2").ToString   'Fam 3
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
            dr1("fecha_0") = Calendario.Value
            dtPpal.Rows.Add(dr1)
        Next
    End Sub
    Private Sub CalcularVentasDia()
        Dim Sql As String
        Dim dt As New DataTable
        Dim da As OracleDataAdapter
        Dim dv As DataView
        Dim dr As DataRow
        Dim FechaInicio As Date
        Dim FechaFinal As Date
        Dim itm As New Articulo(cn)

        FechaFinal = New Date(Calendario.Value.Year, Calendario.Value.Month, 1)
        FechaFinal = FechaFinal.AddMonths(1)
        FechaFinal = FechaFinal.AddDays(-1)
        FechaInicio = New Date(Calendario.Value.Year, Calendario.Value.Month, 1)

        'Consulta para recuperar ventas del mes actual y del año anterior
        Sql = "SELECT  qty_0 * sns_0 AS cant, "
        Sql &= "       qty_0 * sns_0 * netpri_0 * ratcur_0 AS punit, "
        Sql &= "       {amtatilin_0} * sns_0 * ratcur_0 AS impii,"
        Sql &= "       itm.tsicod_1, itm.tsicod_2, itm.tsicod_3, itm.tsicod_4, accdat_0, rep1_0, "
        Sql &= "       qty_0 * sns_0 * pfm_0 * ratcur_0 AS margen  , sid.itmref_0 , tsccod_1 as flia "
        Sql &= "FROM ((sinvoice siv INNER JOIN sinvoiced sid ON (siv.num_0 = sid.num_0)) INNER JOIN itmmaster itm ON (sid.itmref_0 = itm.itmref_0)) INNER JOIN bpcustomer bpc ON (siv.bpr_0 = bpc.bpcnum_0)"
        Sql &= "WHERE accdat_0 >= to_date(:datdeb1, 'dd/mm/yyyy') AND accdat_0 <= to_date(:datfin1, 'dd/mm/yyyy') AND sivtyp_0 <> 'PRF'"
        Sql &= "UNION ALL "
        Sql &= "SELECT qty_0 * sns_0 AS cant, "
        Sql &= "       qty_0 * sns_0 * netpri_0 * ratcur_0 AS punit, "
        Sql &= "       {amtatilin_0} * sns_0 * ratcur_0 AS impii, "
        Sql &= "       itm.tsicod_1, itm.tsicod_2, itm.tsicod_3, itm.tsicod_4, accdat_0, rep1_0, "
        Sql &= "       qty_0 * sns_0 * pfm_0 * ratcur_0 AS margen , sid.itmref_0  , tsccod_1 as flia "
        Sql &= "FROM ((sinvoice siv INNER JOIN sinvoiced sid ON (siv.num_0 = sid.num_0)) INNER JOIN itmmaster itm ON (sid.itmref_0 = itm.itmref_0)) INNER JOIN bpcustomer bpc ON (siv.bpr_0 = bpc.bpcnum_0)"
        Sql &= "WHERE accdat_0 >=  to_date(:datdeb2, 'dd/mm/yyyy') AND accdat_0 <= to_date(:datfin2, 'dd/mm/yyyy') AND sivtyp_0 <> 'PRF'"

        Sql = Strings.Replace(Sql, "{amtatilin_0}", "amtatilin_0")


        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("datdeb1", OracleType.VarChar).Value = FechaInicio.ToString("dd/MM/yyyy")
        da.SelectCommand.Parameters.Add("datfin1", OracleType.VarChar).Value = FechaFinal.ToString("dd/MM/yyyy")
        da.SelectCommand.Parameters.Add("datdeb2", OracleType.VarChar).Value = FechaInicio.AddYears(-1).ToString("dd/MM/yyyy")
        da.SelectCommand.Parameters.Add("datfin2", OracleType.VarChar).Value = New Date(FechaInicio.Year - 1, FechaInicio.Month, Date.DaysInMonth(FechaInicio.Year - 1, FechaInicio.Month)).ToString("dd/MM/yyyy")
        dt.Clear()
        da.Fill(dt)

        dv = New DataView(dtPpal)
        'CALCULO DE VENTAS DEL DIA Y ACUMULADO MENSUAL
        For Each dr In dt.Rows
            'Proceso el registro si el vendedor está chequeado
            dv.RowFilter = "tsicod2_0 = '" & dr("flia").ToString & "' AND tsicod3_0 = '" & dr("tsicod_3").ToString & "' AND tsicod4_0 = '" & dr("tsicod_4").ToString & "' "
            If dv.Count = 1 Then
                With dv.Item(0).Row
                    .BeginEdit()
                    If CDate(dr("accdat_0")).Year = FechaInicio.Year Then
                        'Calculo venta del dia
                        Dim Costo As Double = 0
                        'If itm.Abrir(dr("itmref_0").ToString) Then
                        '    Costo = CDbl(dr("cant")) * itm.Costo
                        'End If
                        If CDate(dr("accdat_0")) = FechaFinal Then
                            .Item("qtydia_0") = CDbl(.Item("qtydia_0")) + CDbl(dr("cant"))
                            .Item("predia_0") = CDbl(.Item("predia_0")) + CDbl(dr("punit"))
                            .Item("impdia_0") = CDbl(.Item("impdia_0")) + CDbl(dr("impii"))
                            '.Item("mardia_0") = CDbl(.Item("mardia_0")) + Costo
                            .Item("mardia_0") = CDbl(.Item("mardia_0")) + CDbl(dr("margen"))
                        End If

                        'Calculo venta acumulada
                        .Item("qtyacu_0") = CDbl(.Item("qtyacu_0")) + CDbl(dr("cant"))
                        .Item("preacu_0") = CDbl(.Item("preacu_0")) + CDbl(dr("punit"))
                        .Item("impacu_0") = CDbl(.Item("impacu_0")) + CDbl(dr("impii"))
                        '.Item("maracu_0") = CDbl(.Item("maracu_0")) + Costo
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
        Next
        'CALCULO PROMEDIOS Y ELIMINO REGISTROS SIN CANTIDADES
        For i As Integer = dtPpal.Rows.Count - 1 To 0 Step -1
            dr = dtPpal.Rows(i)

            If dr.RowState <> DataRowState.Deleted Then

                If CInt(dr("qtydia_0")) = 0 And CInt(dr("qtyacu_0")) = 0 And CInt(dr("qtyhis_0")) = 0 And CInt(dr("impdia_0")) = 0 And CInt(dr("impacu_0")) = 0 And CInt(dr("imphis_0")) = 0 Then
                    'Elimino registro sin cantidades
                    dr.Delete()
                Else
                    'Calculo precios promedios
                    dr.BeginEdit()
                    If CDbl(dr("qtydia_0")) <> 0 Then dr("predia_0") = CDbl(dr("predia_0")) / CDbl(dr("qtydia_0"))
                    If CDbl(dr("qtyacu_0")) <> 0 Then dr("preacu_0") = CDbl(dr("preacu_0")) / CDbl(dr("qtyacu_0"))
                    If CDbl(dr("qtyhis_0")) <> 0 Then dr("prehis_0") = CDbl(dr("prehis_0")) / CDbl(dr("qtyhis_0"))
                    dr("fecha_0") = Calendario.Value
                    dr.EndEdit()
                End If

            End If
        Next

    End Sub
    Private Sub CalcularProyectados()
        Dim i As Integer
        Dim da As OracleDataAdapter
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim Fecha As Date = Calendario.Value
        da = New OracleDataAdapter("SELECT * FROM xferiados WHERE EXTRACT(YEAR FROM dat_0) = :YY AND EXTRACT(MONTH FROM dat_0) = :MM", cn)
        da.SelectCommand.Parameters.Add("YY", OracleType.Int16).Value = fecha.Year
        da.SelectCommand.Parameters.Add("MM", OracleType.Int16).Value = fecha.Month

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
                    If fecha <= fecha Then DiasHabilesAcumulados += 1
                    'Calculo habiles totales
                    DiasHabilesTotales += 1
                End If
            End If

            Fecha = Fecha.AddDays(1)
        Next

        'CALCULO LOS CAMPOS PROYECTADOS
        For Each dr In dtPpal.Rows
            If dr.RowState <> DataRowState.Deleted Then
                dr.BeginEdit()
                dr("qtypro_0") = CDbl(dr("qtyacu_0")) * DiasHabilesTotales / DiasHabilesAcumulados
                dr("imppro_0") = CDbl(dr("impacu_0")) * DiasHabilesTotales / DiasHabilesAcumulados
                dr("marpro_0") = CDbl(dr("maracu_0")) * DiasHabilesTotales / DiasHabilesAcumulados
                dr.EndEdit()
            End If

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

        End If

        da.Dispose()
        dt.Dispose()
    End Sub
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
    Private Sub frmRptVtasFlia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Adaptadores()

        Try
            CargarFeriados()

            btnGenerar.Enabled = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub
End Class