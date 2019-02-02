Imports System.Data.OracleClient

Public Class frmRptRecargas '948 - 880
    Private cn As New OracleConnection(DB)

    Private Sub frmRptRecargas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AddHandler dgvSeguimiento.RowPostPaint, AddressOf NumeracionGrillas
        AddHandler dgvHistorial.RowPostPaint, AddressOf NumeracionGrillas
        AddHandler dgv.RowPostPaint, AddressOf NumeracionGrillas

        AddHandler txtAboProceso.TextChanged, AddressOf Totales
        AddHandler txtNoAboProceso.TextChanged, AddressOf Totales
        AddHandler txtAboFacturacion.TextChanged, AddressOf Totales
        AddHandler txtNoAboFacturacion.TextChanged, AddressOf Totales
        AddHandler txtAboRuta.TextChanged, AddressOf Totales
        AddHandler txtNoAboRuta.TextChanged, AddressOf Totales
        AddHandler txtAboPlanta.TextChanged, AddressOf Totales
        AddHandler txtNoAboPlanta.TextChanged, AddressOf Totales

        For Each Tab As TabPage In TabControl1.TabPages
            AddHandler Tab.Enter, AddressOf TabPage_Enter
        Next

        dtpDesde.MinDate = #1/1/2010# : dtpDesde.MaxDate = Date.Today
        dtpHasta.MinDate = #1/1/2010# : dtpHasta.MaxDate = Date.Today

    End Sub

    Private Sub TabPage_Enter(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim Tab As TabPage = CType(sender, TabPage)

        If Tab Is TabPage1 Then
            CalcularTab1()

        ElseIf Tab Is TabPage2 Then

            Dim dt As DataTable
            Dim Sql As String = "SELECT dat_0 AS fecha, equipos_0 AS retirado, equipos_0 AS ingresados, equipos_0 AS prefacturacion, equipos_0 AS logistica, equipos_0 AS entregados FROM xsegto2 WHERE 1 = 2"
            Dim da As OracleDataAdapter

            Me.UseWaitCursor = True
            Application.DoEvents()

            If dgvSeguimiento.DataSource Is Nothing Then
                dt = New DataTable
                da = New OracleDataAdapter(Sql, cn)
                da.Fill(dt)

                'Enlazo las columnas
                col5Fecha.DataPropertyName = "fecha"
                col5Retirados.DataPropertyName = "retirado"
                col5Ingresados.DataPropertyName = "ingresados"
                col5Prefacturacion.DataPropertyName = "prefacturacion"
                col5Logistica.DataPropertyName = "logistica"
                col5Entregados.DataPropertyName = "entregados"

                dgvSeguimiento.DataSource = dt
            End If

            dt = Nothing
            da = Nothing

            Me.UseWaitCursor = False

        End If

    End Sub
    Private Sub Totales(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim i As Integer

        'Totales - Proceso
        i = CInt(txtAboProceso.Text) + CInt(txtNoAboProceso.Text)
        txtTotalProceso.Text = i.ToString("N0")
        'Totales Prefacturacion
        i = CInt(txtAboFacturacion.Text) + CInt(txtNoAboFacturacion.Text)
        txtTotalFacturacion.Text = i.ToString("N0")
        'Totales Ruta
        i = CInt(txtAboRuta.Text) + CInt(txtNoAboRuta.Text)
        txtTotalRuta.Text = i.ToString("N0")
        'Totales Planta
        i = CInt(txtAboPlanta.Text) + CInt(txtNoAboPlanta.Text)
        txtTotalPlanta.Text = i.ToString("N0")
        'Totales Abonados
        i = CInt(txtAboProceso.Text) + CInt(txtAboFacturacion.Text) + CInt(txtAboRuta.Text) + CInt(txtAboPlanta.Text)
        txtTotalAbonados.Text = i.ToString("N0")
        'Totales No Abonados
        i = CInt(txtNoAboProceso.Text) + CInt(txtNoAboFacturacion.Text) + CInt(txtNoAboRuta.Text) + CInt(txtNoAboPlanta.Text)
        txtTotalNoAbonados.Text = i.ToString("N0")

        'Total General
        i = CInt(txtTotalAbonados.Text) + CInt(txtTotalNoAbonados.Text)
        txtTotalGeneral.Text = i.ToString("N0")

    End Sub

    'BOTONES
    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        Dim dt As DataTable
        Dim dr As DataRow
        Dim Fecha As Date
        Dim Tot1 As Integer = 0
        Dim Tot2 As Integer = 0
        Dim Tot3 As Integer = 0
        Dim Tot4 As Integer = 0
        Dim tot5 As Integer = 0

        Me.UseWaitCursor = True
        btnConsultar.Enabled = False
        Application.DoEvents()

        'Obtengo la tabla asociada a la grilla
        dt = CType(dgvSeguimiento.DataSource, DataTable)

        dt.Clear() 'Limpio los resultados anteriores

        'Armo la grilla con los nuevos resultados
        Fecha = dtpDesde.Value
        Do
            If EsDiaHabil(Fecha) Then
                dr = dt.NewRow
                dr("fecha") = Fecha.Date
                dr("retirado") = ObtenerRetirados(Fecha.Date)
                dr("ingresados") = ObtenerIngresados(Fecha.Date)
                dr("prefacturacion") = ObtenerPrefacturacion(Fecha.Date)
                dr("logistica") = ObtenerLogistica(Fecha.Date)
                dr("entregados") = ObtenerEntregados(Fecha.Date)
                dt.Rows.Add(dr)
            End If

            Fecha = Fecha.AddDays(1)
        Loop Until Fecha > dtpHasta.Value Or Fecha > Date.Today

        'Calculo de totales
        For Each dr In dt.Rows
            Tot1 += CInt(dr("retirado"))
            Tot2 += CInt(dr("ingresados"))
            Tot3 += CInt(dr("prefacturacion"))
            Tot4 += CInt(dr("logistica"))
            tot5 += CInt(dr("entregados"))
        Next

        txtTot1.Text = Tot1.ToString("N0")
        txtTot2.Text = Tot2.ToString("N0")
        txtTot3.Text = Tot3.ToString("N0")
        txtTot4.Text = Tot4.ToString("N0")
        txtTot5.Text = tot5.ToString("N0")

        btnConsultar.Enabled = True
        Me.UseWaitCursor = False

    End Sub
    Private Sub btnRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefrescar.Click

        btnRefrescar.Enabled = False
        Me.UseWaitCursor = True
        Application.DoEvents()

        CalcularProceso()
        CalcularPrefacturacion()
        CalcularEntregar()

        btnRefrescar.Enabled = True
        Me.UseWaitCursor = False

    End Sub
    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    'CALENDARIOS
    Private Sub dtpDesde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDesde.ValueChanged
        'La fecha del segundo no puede ser menor a la fecha del primero
        dtpHasta.Value = dtpDesde.Value
    End Sub
    Private Sub dtpHasta_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpHasta.ValueChanged
        'La fecha del segundo calendario no puedo ser menor al primero
        If dtpHasta.Value < dtpDesde.Value Then dtpDesde.Value = dtpHasta.Value
    End Sub

    Private Sub CalcularProceso() 'En proceso
        Dim Sql As String
        Dim dt As New DataTable
        Dim da As OracleDataAdapter
        Dim dr As DataRow

        Sql = "SELECT xsg.dat_0, itn_0, yotr_0, bpcnum_0, bpcnam_0, equipos_0, cant_0, rech_0, cant_1, rech_1, xabo_0 "
        Sql &= "FROM (xsegto2 xsg INNER JOIN interven itn ON (xsg.itn_0 = itn.num_0)) INNER JOIN bpcustomer bpc ON (itn.bpc_0 = bpc.bpcnum_0) "
        Sql &= "WHERE dat_2 = to_date('31/12/1599', 'dd/mm/yyyy') AND "
        Sql &= "      dat_3 = to_date('31/12/1599', 'dd/mm/yyyy') AND "
        Sql &= "      dat_4 = to_date('31/12/1599', 'dd/mm/yyyy') AND "
        Sql &= "      zflgtrip_0 < 3 "
        Sql &= "ORDER BY xsg.dat_0"

        da = New OracleDataAdapter(Sql, cn)
        da.Fill(dt)
        da.Dispose()

        Dim i(1) As Integer
        i(0) = 0 'Abonado
        i(1) = 0 'No Abonado
        For Each dr In dt.Rows
            If CInt(dr("xabo_0")) = 2 Then
                i(0) += CInt(dr("equipos_0"))
            Else
                i(1) += CInt(dr("equipos_0"))
            End If

        Next
        txtAboProceso.Text = i(0).ToString("N0")
        txtNoAboProceso.Text = i(1).ToString("N0")

        dt.Dispose()

    End Sub
    Private Sub CalcularPrefacturacion() 'En prefacturacion
        Dim Sql As String
        Dim dt As New DataTable
        Dim da As OracleDataAdapter
        Dim dr As DataRow

        'Sql Anterior
        Sql = "SELECT xsg.dat_2, itn_0, yotr_0, ysdhdeb_0, bpcnum_0, bpcnam_0, equipos_0, xabo_0 "
        Sql &= "FROM (xsegto2 xsg INNER JOIN interven itn ON (xsg.itn_0 = itn.num_0)) INNER JOIN bpcustomer bpc ON (itn.bpc_0 = bpc.bpcnum_0) "
        Sql &= "WHERE dat_1 <> to_date('31/12/1599', 'dd/mm/yyyy') AND "
        Sql &= "      dat_2 <> to_date('31/12/1599', 'dd/mm/yyyy') AND "
        Sql &= "      dat_3 = to_date('31/12/1599', 'dd/mm/yyyy') AND "
        Sql &= "      dat_4 = to_date('31/12/1599', 'dd/mm/yyyy') AND "
        Sql &= "      zflgtrip_0 < 5 "
        Sql &= "ORDER BY xsg.dat_2"

        'Sql Nuevo
        Sql = "SELECT xsg.dat_2, itn_0, yotr_0, ysdhdeb_0, bpcnum_0, bpcnam_0, equipos_0, xabo_0 "
        Sql &= "FROM (interven itn INNER JOIN xsegto2 xsg ON (itn.num_0 = xsg.itn_0)) INNER JOIN bpcustomer bpc ON (itn.bpc_0 = bpc.bpcnum_0) "
        Sql &= "WHERE xsector_0 = 'ADM' AND zflgtrip_0 < 5 "
        Sql &= "ORDER BY xsg.dat_2"

        da = New OracleDataAdapter(Sql, cn)
        da.Fill(dt)
        da.Dispose()

        Dim i(1) As Integer
        i(0) = 0 'Abonado
        i(1) = 0 'No Abonado
        For Each dr In dt.Rows
            If CInt(dr("xabo_0")) = 2 Then
                i(0) += CInt(dr("equipos_0"))
            Else
                i(1) += CInt(dr("equipos_0"))
            End If

        Next
        txtAboFacturacion.Text = i(0).ToString("N0")
        txtNoAboFacturacion.Text = i(1).ToString("N0")

        dt.Dispose()

    End Sub
    Private Sub CalcularEntregar() ' A entregar
        Dim Sql As String
        Dim dt As New DataTable
        Dim da As OracleDataAdapter
        Dim dr As DataRow

        Sql = "SELECT xsg.dat_3, itn_0, yotr_0, ysdhdeb_0, bpcnum_0, bpcnam_0, equipos_0, 'LOG' AS sector_0, xabo_0, (SELECT COUNT(*) AS CANTI FROM xrutad WHERE tipo_0 = 'ENT' AND vcrnum_0 = xsg.itn_0) AS rutas "
        Sql &= "FROM (xsegto2 xsg INNER JOIN interven itn ON (xsg.itn_0 = itn.num_0)) INNER JOIN bpcustomer bpc ON (itn.bpc_0 = bpc.bpcnum_0) "
        Sql &= "WHERE dat_1 <> to_date('31/12/1599', 'dd/mm/yyyy') AND "
        Sql &= "      dat_2 <> to_date('31/12/1599', 'dd/mm/yyyy') AND "
        Sql &= "      dat_3 <> to_date('31/12/1599', 'dd/mm/yyyy') AND "
        Sql &= "      dat_4 = to_date('31/12/1599', 'dd/mm/yyyy') AND "
        Sql &= "      zflgtrip_0 < 8 "
        Sql &= "ORDER BY xsg.dat_3"

        da = New OracleDataAdapter(Sql, cn)
        da.Fill(dt)
        da.Dispose()

        For Each dr In dt.Rows
            ObtenerSectorEntrega(dr)
        Next

        Dim i(1, 1) As Integer
        i(0, 0) = 0 ' Abonado - Ruta
        i(0, 1) = 0 ' No Abonado - Ruta
        i(1, 0) = 0 ' Abonados - Planta
        i(1, 1) = 0 ' No Abonados - Planta

        For Each dr In dt.Rows

            If CInt(dr("xabo_0")) = 2 Then

                If CInt(dr("rutas")) > 0 Then
                    i(0, 0) += CInt(dr("equipos_0"))
                Else
                    i(1, 0) += CInt(dr("equipos_0"))
                End If

            Else

                If CInt(dr("rutas")) > 0 Then
                    i(0, 1) += CInt(dr("equipos_0"))
                Else
                    i(1, 1) += CInt(dr("equipos_0"))
                End If

            End If

        Next
        txtAboPlanta.Text = i(1, 0).ToString("N0")
        txtNoAboPlanta.Text = i(1, 1).ToString("N0")
        txtNoAboRuta.Text = i(0, 1).ToString("N0")
        txtAboRuta.Text = i(0, 0).ToString("N0")

    End Sub
    Private Sub CalcularTab1()
        Dim Sql As String

        Sql = "SELECT xsector_0, COUNT(num_0) AS cantidad "
        Sql &= "FROM interven "
        Sql &= "WHERE xsector_0 NOT IN (' ', 'ACH') AND zflgtrip_0 <> 8 "
        Sql &= "GROUP BY xsector_0 "
        Sql &= "ORDER BY xsector_0"

        Dim dt As New DataTable
        Dim da As New OracleDataAdapter(Sql, cn)

        da.Fill(dt)
        da.Dispose()

        With colTab4Sectores
            .DataPropertyName = "xsector_0"
            .ValueMember = "ident2_0"
            .DisplayMember = "texte_0"
            .DataSource = TablaVaria(cn, 5004)
        End With
        colTab4Intervenciones.DataPropertyName = "cantidad"
        dgvSectores.DataSource = dt

        colTab4Fecha.DataPropertyName = "dat"
        colTab4Itn.DataPropertyName = "num_0"
        colTab4Ot.DataPropertyName = "yotr_0"
        colTab4Tipo.DataPropertyName = "typ_0"
        colTab4Rto.DataPropertyName = "ysdhdeb_0"
        colTab4Cliente.DataPropertyName = "bpcnum_0"
        colTab4Nombre.DataPropertyName = "bpcnam_0"
        colTab4Equipos.DataPropertyName = "equipos_0"
        colTab4ExtOk.DataPropertyName = "cant_0"
        colTab4ExtBaja.DataPropertyName = "rech_0"
        colTab4MangaOk.DataPropertyName = "cant_1"
        colTab4MangaBaja.DataPropertyName = "rech_1"

        MenuLocal(cn, 1, colTab4Abonado)
        colTab4Abonado.DataPropertyName = "xabo_0"

        MenuLocal(cn, 2406, colTab4Estado)
        colTab4Estado.DataPropertyName = "zflgtrip_0"

        MenuLocal(cn, 1, colTab4Ruta)
        colTab4Ruta.DataPropertyName = "ruta"

        colTab4Sector.DataPropertyName = "xsector_0"

        With clbAbonado
            .DataSource = MenuLocal(cn, 1)
            .DisplayMember = "lanmes_0"
            .ValueMember = "lannum_0"

            For i = 0 To .Items.Count - 1
                .SetItemChecked(i, True)
            Next

        End With

        With clbEstados
            Dim dt2 As New DataTable
            dt2 = MenuLocal(cn, 2406)
            dt2.Rows.RemoveAt(7)

            .DataSource = dt2
            .DisplayMember = "lanmes_0"
            .ValueMember = "lannum_0"

            For i = 0 To .Items.Count - 1
                .SetItemChecked(i, True)
            Next

        End With

        'Lleno combo Tipos
        With clbTipo
            .DataSource = TablaVaria(cn, 407)
            .ValueMember = "ident2_0"
            .DisplayMember = "ident2_0"

            For i = 0 To .Items.Count - 1
                .SetItemChecked(i, True)
            Next

        End With

    End Sub

    'FUNCTION
    Private Function EsDiaHabil(ByVal Fecha As Date) As Boolean

        If Fecha.DayOfWeek = DayOfWeek.Sunday OrElse Fecha.DayOfWeek = DayOfWeek.Saturday Then
            Return False

        Else
            Dim dt As New DataTable
            Dim da As New OracleDataAdapter("SELECT dat_0 FROM xferiados WHERE dat_0 = :dat_0", cn)
            da.SelectCommand.Parameters.Add("dat_0", OracleType.DateTime).Value = Fecha.Date
            da.Fill(dt)
            da.Dispose()

            Return (dt.Rows.Count = 0)
        End If

    End Function
    Private Sub ObtenerSectorEntrega(ByVal dr As DataRow)
        Dim dt As New DataTable
        Dim da As New OracleDataAdapter("SELECT * FROM xsegto WHERE itn_0 = :itn_0 ORDER BY fecha_0 DESC, hora_0 DESC", cn)

        da.SelectCommand.Parameters.Add("itn_0", OracleType.VarChar).Value = dr("itn_0").ToString

        da.Fill(dt)
        da.Dispose()

        If dt.Rows.Count > 0 Then
            dr.BeginEdit()
            dr("sector_0") = dt.Rows(0).Item("para_0").ToString
            dr.EndEdit()
        End If

    End Sub
    Private Function ObtenerRetirados(ByVal Fecha As Date) As Integer
        Dim dt As New DataTable
        Dim da As New OracleDataAdapter("SELECT SUM(equipos_0) FROM xsegto2 WHERE dat_0 = :dat", cn)
        da.SelectCommand.Parameters.Add("dat", OracleType.DateTime).Value = Fecha

        da.Fill(dt)
        da.Dispose()

        If IsDBNull(dt.Rows(0).Item(0)) Then
            Return 0

        Else
            Return CInt(dt.Rows(0).Item(0))

        End If

    End Function
    Private Function ObtenerIngresados(ByVal Fecha As Date) As Integer
        Dim dt As New DataTable
        Dim da As New OracleDataAdapter("SELECT * FROM sremac WHERE creusr_0 = 'RECEP' AND credat_0 = :dat", cn)
        da.SelectCommand.Parameters.Add("dat", OracleType.DateTime).Value = Fecha

        da.Fill(dt)
        da.Dispose()

        Return dt.Rows.Count

    End Function
    Private Function ObtenerPrefacturacion(ByVal Fecha As Date) As Integer
        Dim dt As New DataTable
        Dim da As New OracleDataAdapter("SELECT SUM(cant_0+cant_1+rech_0+rech_1) FROM xsegto2 WHERE dat_2 = :dat", cn)
        da.SelectCommand.Parameters.Add("dat", OracleType.DateTime).Value = Fecha

        da.Fill(dt)
        da.Dispose()

        If IsDBNull(dt.Rows(0).Item(0)) Then
            Return 0

        Else
            Return CInt(dt.Rows(0).Item(0))

        End If

    End Function
    Private Function ObtenerLogistica(ByVal Fecha As Date) As Integer
        Dim dt As New DataTable
        Dim da As New OracleDataAdapter("SELECT SUM(cant_0+cant_1+rech_0+rech_1) FROM xsegto2 WHERE dat_3 = :dat", cn)
        da.SelectCommand.Parameters.Add("dat", OracleType.DateTime).Value = Fecha

        da.Fill(dt)
        da.Dispose()

        If IsDBNull(dt.Rows(0).Item(0)) Then
            Return 0

        Else
            Return CInt(dt.Rows(0).Item(0))

        End If

    End Function
    Private Function ObtenerEntregados(ByVal Fecha As Date) As Integer
        Dim dt As New DataTable
        Dim da As New OracleDataAdapter("SELECT SUM(cant_0+cant_1+rech_0+rech_1) FROM xsegto2 WHERE dat_4 = :dat", cn)
        da.SelectCommand.Parameters.Add("dat", OracleType.DateTime).Value = Fecha

        da.Fill(dt)
        da.Dispose()

        If IsDBNull(dt.Rows(0).Item(0)) Then
            Return 0

        Else
            Return CInt(dt.Rows(0).Item(0))

        End If

    End Function

    'TAB DE BUSQUEDA - PROGRAMACION
    Private Sub txtBuscarItn_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBuscarItn.KeyUp
        If e.KeyCode = Keys.Enter Then
            Dim Sql As String
            Dim dt As DataTable
            Dim da As OracleDataAdapter


            'Si la cadena tiene solo numeros
            If IsNumeric(txtBuscarItn.Text) Then
                Sql = "SELECT num_0, yotr_0, bpc_0, bpcnam_0 "
                Sql &= "FROM interven itn INNER JOIN bpcustomer bpc ON (bpc_0 = bpcnum_0) "
                Sql &= "WHERE num_0 LIKE :num_0 OR yotr_0 = :yotr_0 OR bpc_0 = :bpc_0 "
                Sql &= "ORDER BY bpc_0, num_0"

                da = New OracleDataAdapter(Sql, cn)
                da.SelectCommand.Parameters.Add("num_0", OracleType.VarChar).Value = "%" & txtBuscarItn.Text
                da.SelectCommand.Parameters.Add("yotr_0", OracleType.VarChar).Value = txtBuscarItn.Text
                da.SelectCommand.Parameters.Add("bpc_0", OracleType.VarChar).Value = txtBuscarItn.Text

            Else
                Sql = "SELECT num_0, yotr_0, bpc_0, bpcnam_0 "
                Sql &= "FROM interven itn INNER JOIN bpcustomer bpc ON (bpc_0 = bpcnum_0) "
                Sql &= "WHERE num_0 LIKE :num_0 "
                Sql &= "ORDER BY bpc_0, num_0"

                da = New OracleDataAdapter(Sql, cn)
                da.SelectCommand.Parameters.Add("num_0", OracleType.VarChar).Value = "%" & txtBuscarItn.Text

            End If


            If dgvBusqueda.DataSource Is Nothing Then
                dt = New DataTable

                col5Itn.DataPropertyName = "num_0"
                col5Ot.DataPropertyName = "yotr_0"
                col5Cliente.DataPropertyName = "bpc_0"
                col5Nombre.DataPropertyName = "bpcnam_0"
                dgvBusqueda.DataSource = dt

            Else
                dt = CType(dgvBusqueda.DataSource, DataTable)

            End If

            dt.Clear()
            da.Fill(dt)
            da.Dispose()

            txtBuscarItn.Clear()

        End If
    End Sub
    Private Sub dgvBusqueda_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvBusqueda.CellEnter

        '***********************************************************************
        ' HISTORIAL LOGISTICO
        '***********************************************************************

        Dim dt As DataTable
        Dim dr As DataRow = CType(dgvBusqueda.Rows(e.RowIndex).DataBoundItem, DataRowView).Row
        Dim da As OracleDataAdapter
        Dim Sql As String

        Sql = "SELECT fecha_0, hora_0, de_0, para_0 "
        Sql &= "FROM xsegto "
        Sql &= "WHERE itn_0 = :itn_0 "
        Sql &= "ORDER BY fecha_0, hora_0"

        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("itn_0", OracleType.VarChar).Value = dr("num_0").ToString

        If dgvHistorial.DataSource Is Nothing Then
            dt = New DataTable

            col6Fecha.DataPropertyName = "fecha_0"
            col6Hora.DataPropertyName = "hora_0"
            col6De.DataSource = Sectores(cn)
            col6De.ValueMember = "ident2_0"
            col6De.DisplayMember = "texte_0"
            col6De.DataPropertyName = "de_0"
            col6Para.DataSource = Sectores(cn)
            col6Para.ValueMember = "ident2_0"
            col6Para.DisplayMember = "texte_0"
            col6Para.DataPropertyName = "para_0"
            dgvHistorial.DataSource = dt

        Else
            dt = CType(dgvHistorial.DataSource, DataTable)

        End If

        dt.Clear()
        da.Fill(dt)
        da.Dispose()

        '***********************************************************************
        ' HISTORIAL LOGISTICO
        '***********************************************************************
        Sql = "SELECT * FROM xsegto2 WHERE itn_0 = :itn_0"
        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("itn_0", OracleType.VarChar).Value = dr("num_0").ToString

        dt = New DataTable
        da.Fill(dt)
        da.Dispose()

        If dt.Rows.Count = 0 Then
            txt6Creacion.Clear()
            txt6Retiro.Clear()
            txt6Ingreso.Clear()
            txt6Procesado.Clear()
            txt6Facturado.Clear()
            txt6Entregado.Clear()

        Else
            dr = dt.Rows(0)

            txt6Creacion.Clear()

            If CDate(dr("dat_0")) = #12/31/1599# Then
                txt6Retiro.Clear()

            Else
                txt6Retiro.Text = CDate(dr("dat_0")).ToString("dd/MM/yyyy")

            End If

            If CDate(dr("dat_1")) = #12/31/1599# Then
                txt6Ingreso.Clear()

            Else
                txt6Ingreso.Text = CDate(dr("dat_1")).ToString("dd/MM/yyyy")

            End If

            If CDate(dr("dat_2")) = #12/31/1599# Then
                txt6Procesado.Clear()

            Else
                txt6Procesado.Text = CDate(dr("dat_2")).ToString("dd/MM/yyyy")

            End If
            If CDate(dr("dat_3")) = #12/31/1599# Then
                txt6Facturado.Clear()

            Else
                txt6Facturado.Text = CDate(dr("dat_3")).ToString("dd/MM/yyyy")

            End If
            If CDate(dr("dat_4")) = #12/31/1599# Then
                txt6Entregado.Clear()

            Else
                txt6Entregado.Text = CDate(dr("dat_4")).ToString("dd/MM/yyyy")

            End If

        End If

    End Sub

    Private Sub btnVer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVer.Click
        Dim Sql(6) As String
        Dim dt As DataTable

        btnVer.Enabled = False
        Me.UseWaitCursor = True

        dt = New DataTable

        If SectorSeleccionado("SRV") Then
            Sql(0) = "SELECT xsg.dat_0 AS dat, num_0, yotr_0, typ_0, ysdhdeb_0, bpcnum_0, bpcnam_0, equipos_0, cant_0, rech_0, cant_1, rech_1, xabo_0, zflgtrip_0, itn.xsector_0, 1 AS ruta "
            Sql(0) &= "FROM (xsegto2 xsg RIGHT JOIN interven itn ON (xsg.itn_0 = itn.num_0)) INNER JOIN bpcustomer bpc ON (itn.bpc_0 = bpc.bpcnum_0) "
            Sql(0) &= "WHERE itn.xsector_0 = 'SRV' AND typ_0 IN ({typ}) AND zflgtrip_0 IN ({zflgtrip}) AND xabo_0 IN ({abo})"
        Else
            Sql(0) = ""
        End If

        If SectorSeleccionado("ADM") Then
            Sql(1) &= "SELECT xsg.dat_2 AS dat, num_0, yotr_0, typ_0, ysdhdeb_0, bpcnum_0, bpcnam_0, equipos_0, cant_0, rech_0, cant_1, rech_1, xabo_0, zflgtrip_0, itn.xsector_0, 1 AS ruta "
            Sql(1) &= "FROM (xsegto2 xsg RIGHT JOIN interven itn ON (xsg.itn_0 = itn.num_0)) INNER JOIN bpcustomer bpc ON (itn.bpc_0 = bpc.bpcnum_0) "
            Sql(1) &= "WHERE itn.xsector_0 = 'ADM' AND typ_0 IN ({typ}) AND zflgtrip_0 IN ({zflgtrip}) AND xabo_0 IN ({abo})"
        Else
            Sql(1) = ""
        End If

        If SectorSeleccionado("LOG") Then
            Sql(2) &= "SELECT xsg.dat_3 AS dat, num_0, yotr_0, typ_0, ysdhdeb_0, bpcnum_0, bpcnam_0, equipos_0, cant_0, rech_0, cant_1, rech_1, xabo_0, zflgtrip_0, itn.xsector_0, "
            Sql(2) &= "(SELECT COUNT(*) FROM xrutad WHERE tipo_0 IN ('ENT', 'CTL','INS', 'NCI', 'NUE') AND vcrnum_0 = xsg.itn_0) AS ruta "
            Sql(2) &= "FROM (xsegto2 xsg RIGHT JOIN interven itn ON (xsg.itn_0 = itn.num_0)) INNER JOIN bpcustomer bpc ON (itn.bpc_0 = bpc.bpcnum_0) "
            Sql(2) &= "WHERE itn.xsector_0 = 'LOG' AND typ_0 IN ({typ}) AND zflgtrip_0 IN ({zflgtrip}) AND xabo_0 IN ({abo})"
        Else
            Sql(2) = ""
        End If

        If SectorSeleccionado("CTD") Then
            Sql(3) &= "SELECT (SELECT MAX(fecha_0) FROM xsegto WHERE itn_0 = itn.num_0 AND para_0 = 'CTD') AS dat, "
            Sql(3) &= "num_0, yotr_0, typ_0, ysdhdeb_0, bpcnum_0, bpcnam_0, equipos_0, cant_0, rech_0, cant_1, rech_1, xabo_0, zflgtrip_0, itn.xsector_0, 1 AS ruta "
            Sql(3) &= "FROM (xsegto2 xsg RIGHT JOIN interven itn ON (xsg.itn_0 = itn.num_0)) INNER JOIN bpcustomer bpc ON (itn.bpc_0 = bpc.bpcnum_0) "
            Sql(3) &= "WHERE itn.xsector_0 = 'CTD' AND typ_0 IN ({typ}) AND zflgtrip_0 IN ({zflgtrip}) AND xabo_0 IN ({abo})"
        Else
            Sql(3) = ""
        End If

        If SectorSeleccionado("MOS") Then
            Sql(4) &= "SELECT (SELECT MAX(fecha_0) FROM xsegto WHERE itn_0 = itn.num_0 AND para_0 = 'MOS') AS dat, "
            Sql(4) &= "num_0, yotr_0, typ_0, ysdhdeb_0, bpcnum_0, bpcnam_0, equipos_0, cant_0, rech_0, cant_1, rech_1, xabo_0, zflgtrip_0, itn.xsector_0, 1 AS ruta "
            Sql(4) &= "FROM (xsegto2 xsg RIGHT JOIN interven itn ON (xsg.itn_0 = itn.num_0)) INNER JOIN bpcustomer bpc ON (itn.bpc_0 = bpc.bpcnum_0) "
            Sql(4) &= "WHERE itn.xsector_0 = 'MOS' AND typ_0 IN ({typ}) AND zflgtrip_0 IN ({zflgtrip}) AND xabo_0 IN ({abo})"
        Else
            Sql(4) = ""
        End If

        If SectorSeleccionado("ING") Then
            Sql(5) &= "SELECT (SELECT MAX(fecha_0) FROM xsegto WHERE itn_0 = itn.num_0 AND para_0 = 'ING') AS dat, "
            Sql(5) &= "num_0, yotr_0, typ_0, ysdhdeb_0, bpcnum_0, bpcnam_0, equipos_0, cant_0, rech_0, cant_1, rech_1, xabo_0, zflgtrip_0, itn.xsector_0, 1 AS ruta "
            Sql(5) &= "FROM (xsegto2 xsg RIGHT JOIN interven itn ON (xsg.itn_0 = itn.num_0)) INNER JOIN bpcustomer bpc ON (itn.bpc_0 = bpc.bpcnum_0) "
            Sql(5) &= "WHERE itn.xsector_0 = 'ING' AND typ_0 IN ({typ}) AND zflgtrip_0 IN ({zflgtrip}) AND xabo_0 IN ({abo})"
        Else
            Sql(5) = ""
        End If

        If SectorSeleccionado("DEP") Then
            Sql(6) &= "SELECT (SELECT MAX(fecha_0) FROM xsegto WHERE itn_0 = itn.num_0 AND para_0 = 'DEP') AS dat, "
            Sql(6) &= "num_0, yotr_0, typ_0, ysdhdeb_0, bpcnum_0, bpcnam_0, equipos_0, cant_0, rech_0, cant_1, rech_1, xabo_0, zflgtrip_0, itn.xsector_0, 1 AS ruta "
            Sql(6) &= "FROM (xsegto2 xsg RIGHT JOIN interven itn ON (xsg.itn_0 = itn.num_0)) INNER JOIN bpcustomer bpc ON (itn.bpc_0 = bpc.bpcnum_0) "
            Sql(6) &= "WHERE itn.xsector_0 = 'DEP' AND typ_0 IN ({typ}) AND zflgtrip_0 IN ({zflgtrip}) AND xabo_0 IN ({abo})"
        Else
            Sql(6) = ""
        End If


        Try
            Dim da As OracleDataAdapter = Nothing

            dt.Clear()

            For i As Integer = 0 To 6
                If Sql(i).Length = 0 Then Continue For

                Sql(i) = Replace(Sql(i), "{typ}", FiltrarTipo)
                Sql(i) = Replace(Sql(i), "{zflgtrip}", FiltrarEstado)
                Sql(i) = Replace(Sql(i), "{abo}", FiltrarAbonado)

                da = New OracleDataAdapter(Sql(i), cn)
                da.Fill(dt)
                da.Dispose()
            Next

            'Marco flg de ruta para logistica con 1=No; 2=Si
            For Each dr As DataRow In dt.Rows
                If dr("xsector_0").ToString = "LOG" Then
                    dr.BeginEdit()
                    If CInt(dr("ruta")) = 0 Then
                        dr("ruta") = 1
                    Else
                        dr("ruta") = 2
                    End If
                    dr.EndEdit()
                End If
            Next

            dgv.DataSource = dt

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            btnVer.Enabled = True
            Me.UseWaitCursor = False

        End Try

    End Sub

    Private Function SectorSeleccionado(ByVal Sector As String) As Boolean
        Dim dgvr As DataGridViewRow
        Dim dr As DataRowView
        Dim Flg As Boolean = False

        For Each dgvr In dgvSectores.SelectedRows
            dr = CType(dgvr.DataBoundItem, DataRowView)

            If dr("xsector_0").ToString = Sector Then
                Flg = True
                Exit For
            End If

        Next

        Return Flg

    End Function
    Private Function FiltrarAbonado() As String
        Dim flg As Boolean = False
        Dim drv As DataRowView
        Dim txt As String = ""

        For i As Integer = 0 To clbAbonado.CheckedItems.Count - 1
            drv = CType(clbAbonado.CheckedItems(i), DataRowView)

            If flg Then txt &= ", " 'Pongo coma de separacion de valores

            txt &= drv(0).ToString 'Agrego el valor

            flg = True

        Next

        Return txt

    End Function
    Private Function FiltrarEstado() As String
        Dim flg As Boolean = False
        Dim j As Integer
        Dim drv As DataRowView
        Dim txt As String = ""

        For j = 0 To clbEstados.CheckedItems.Count - 1
            drv = CType(clbEstados.CheckedItems(j), DataRowView)

            If flg Then txt &= ", " 'Pongo coma de separacion de valores

            txt &= drv(0).ToString

            flg = True

        Next

        Return txt

    End Function
    Private Function FiltrarTipo() As String
        Dim flg As Boolean = False
        Dim drv As DataRowView
        Dim txt As String = ""

        For j As Integer = 0 To clbTipo.CheckedItems.Count - 1
            drv = CType(clbTipo.CheckedItems(j), DataRowView)

            If flg Then txt &= ", " 'Pongo coma de separacion de valores

            txt &= "'" & drv(0).ToString & "'"

            flg = True

        Next

        Return txt

    End Function

End Class