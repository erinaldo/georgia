Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.OracleClient

'REPORTE DE VENTAS ANUAL
Public Class frmRptVtasTipoA

    Private cn As New OracleConnection(DB)
    Private daPpal As OracleDataAdapter
    Private dtPpal As New DataTable
    Private daVend As OracleDataAdapter
    Private dtVend As New DataTable
    Private DiasHabilesAcumulados As Integer = 0
    Private DiasHabilesTotales As Integer = 0
    Private AnoConsulta As Integer = 0

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

        Sql = "SELECT repnum_0, repnam_0 FROM salesrep WHERE length(repnum_0) = 2 ORDER BY repnam_0"
        daVend = New OracleDataAdapter(Sql, cn)

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

        cn.Open()
        AbrirTablaPrincipal()
        ObtenerVentas()
        CalcularProyectados()

        daPpal.Update(dtPpal)

        cn.Close()

        Dim rpt As New ReportDocument
        rpt.Load(RPTX3 & "\XRPTVTASTIPOA.rpt")
        rpt.SetParameterValue("X3TIT", "Ventas por tipo de cliente del año")
        rpt.SetParameterValue("X3USR", Usr.Codigo)
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

        'Recupero la estructura de la tabla con registros anteriores (si existen)
        daPpal.SelectCommand.Parameters("usr_0").Value = Usr.Codigo
        dtPpal.Clear()
        daPpal.Fill(dtPpal)

        'Elimino todos los registros anteriores
        For Each dr1 In dtPpal.Rows
            dr1.Delete()
        Next

        'Recupero las familias 4 y 5
        'Sql = "SELECT ident2_0, texte_0 FROM atextra WHERE codfic_0 = 'ATABDIV' AND zone_0 = 'LNGDES' AND ident1_0 = '31' AND ident2_0 <> '10' ORDER BY ident2_0"
        Sql = "SELECT ident2_0, texte_0 FROM atextra WHERE codfic_0 = 'ATABDIV' AND zone_0 = 'LNGDES' AND ident1_0 = '31' ORDER BY ident2_0"

        da = New OracleDataAdapter(Sql, cn)
        da.Fill(dt)

        'Agrego las familias 4 y 5 a la tabla
        For Each dr In dt.Rows
            dr1 = dtPpal.NewRow
            dr1("usr_0") = Usr.Codigo
            dr1("tsicod1_0") = dr("ident2_0").ToString
            dr1("tsicod2_0") = dr("texte_0").ToString
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
            dr1("fecha_0") = New Date(CInt(nudAno.Value), 1, 1)
            dtPpal.Rows.Add(dr1)
        Next


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

        AnoConsulta = CInt(nudAno.Value)

        'Consulta para recuperar ventas del AÑO actual y del año anterior
        Sql = "SELECT  qty_0 * sns_0 AS cant, qty_0 * sns_0 * netpri_0 * ratcur_0 AS punit, amtatilin_0 * sns_0 * ratcur_0 AS impii, accdat_0, rep1_0, tsccod_1 "
        Sql &= "FROM (sinvoice siv INNER JOIN sinvoiced sid ON (siv.num_0 = sid.num_0)) INNER JOIN bpcustomer bpc ON (siv.bpr_0 = bpc.bpcnum_0) "
        Sql &= "WHERE EXTRACT(YEAR FROM accdat_0) = :dat AND sivtyp_0 <> 'PRF' "
        Sql &= "ORDER BY accdat_0"

        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("dat", OracleType.Number)

        Label1.Text = "Recuperando datos año " & AnoConsulta.ToString & "..."
        Application.DoEvents() : Application.DoEvents()
        da.SelectCommand.Parameters("dat").Value = AnoConsulta 'Venta año
        da.Fill(dt)

        Label1.Text = "Recuperando datos año anterior..."
        Application.DoEvents() : Application.DoEvents()
        da.SelectCommand.Parameters("dat").Value = AnoConsulta - 1 'Venta año
        da.Fill(dt)


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

                'Filtro el tipo cliente al que voy a sumar las cantidades
                Select Case dr("tsccod_1").ToString
                    Case "10", "11"
                        dv.RowFilter = "tsicod1_0 = '11'"

                    Case Else
                        dv.RowFilter = "tsicod1_0 = '" & dr("tsccod_1").ToString & "'"

                End Select


                If dv.Count = 1 Then 'Encontre la provincia
                    With dv.Item(0).Row
                        .BeginEdit()
                        'Calculo venta de año consultado
                        If CDate(dr("accdat_0")).Year = AnoConsulta Then
                            .Item("qtydia_0") = CDbl(.Item("qtydia_0")) + CDbl(dr("cant"))
                            .Item("predia_0") = CDbl(.Item("predia_0")) + CDbl(dr("punit"))
                            .Item("impdia_0") = CDbl(.Item("impdia_0")) + CDbl(dr("impii"))

                            .Item("qtyacu_0") = CDbl(.Item("qtyacu_0")) + CDbl(dr("cant"))
                            .Item("preacu_0") = CDbl(.Item("preacu_0")) + CDbl(dr("punit"))
                            .Item("impacu_0") = CDbl(.Item("impacu_0")) + CDbl(dr("impii"))

                        Else
                            'Calculo de venta del año anterior
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

        Label1.Text = "Calculando promedios..."
        Label1.Refresh()
        Application.DoEvents()

        'CALCULO PROMEDIOS Y ELIMINO REGISTROS SIN CANTIDADES
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
    Private Sub CalcularProyectados()
        Dim Fecha As Date
        Dim FechaFin As Date
        Dim da As OracleDataAdapter
        Dim dt As New DataTable 'Tabla con los feriados del año consultado
        Dim dr As DataRow

        'Si el año consultado es igual al año actual
        If Today.Year <> AnoConsulta Then

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
                    dr("qtypro_0") = CDbl(dr("qtyacu_0")) ' * DiasHabilesTotales / DiasHabilesAcumulados
                    dr("imppro_0") = CDbl(dr("impacu_0")) ' * DiasHabilesTotales / DiasHabilesAcumulados
                    dr.EndEdit()
                End If

                ProgressBar1.Value += 1

            Next

        Else

            da = New OracleDataAdapter("SELECT * FROM xferiados WHERE EXTRACT(YEAR FROM dat_0) = :YY", cn)
            da.SelectCommand.Parameters.Add("YY", OracleType.Int16).Value = AnoConsulta

            da.Fill(dt)
            da.Dispose()

            'CALCULO DE DIAS HABILES TOTALES Y ACUMULADOS
            DiasHabilesAcumulados = 0
            DiasHabilesTotales = 0

            Fecha = New Date(AnoConsulta, 1, 1)
            FechaFin = New Date(AnoConsulta, 12, 31)

            Label1.Text = "Calculando días hábiles..."
            Label1.Refresh()

            Do
                'El dia es entre lunes y viernes
                If Fecha.DayOfWeek >= DayOfWeek.Monday And Fecha.DayOfWeek <= DayOfWeek.Friday AndAlso Not BuscarFeriado(Fecha, dt) Then

                    If Fecha <= Today Then DiasHabilesAcumulados += 1

                    DiasHabilesTotales += 1

                End If

                Fecha = Fecha.AddDays(1)

            Loop Until Fecha > FechaFin

            dt.Clear()

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
                    dr.EndEdit()
                End If

                ProgressBar1.Value += 1

            Next


        End If

    End Sub
    Private Sub CargarVendedores()
        Dim i As Integer
        Dim dr As DataRow

        'Cargo combo de vendedores
        daVend.Fill(dtVend)

        'Si el usuario es vendedor, elimino de la tabla los demás vendedores
        If Usr.Codigo.Length = 2 Then
            For i = dtVend.Rows.Count - 1 To 0 Step -1
                dr = dtVend.Rows(i)

                If Usr.Codigo <> dr("repnum_0").ToString Then
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

    Private Sub frmRptVtas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Adaptadores()

        nudAno.Maximum = Date.Today.Year
        nudAno.Value = Date.Today.Year

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

End Class