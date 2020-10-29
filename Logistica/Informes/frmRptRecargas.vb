Imports System.Data.OracleClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class frmRptRecargas '948 - 880

    Private Sub frmRptRecargas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AddHandler dgvHistorial.RowPostPaint, AddressOf NumeracionGrillas
        AddHandler dgv.RowPostPaint, AddressOf NumeracionGrillas
        AddHandler dgv5.RowPostPaint, AddressOf NumeracionGrillas

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

            dtpDesde.Value = New Date(Today.Year, Today.Month, 1)
            dtpHasta.Value = Today

        End If

    End Sub
    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        Dim tmp As Temporal
        Dim rr As New ReporteRecargas(cn)
        Dim rpt As New ReportDocument
        Dim Fecha As Date

        Me.UseWaitCursor = True
        btnConsultar.Enabled = False
        Application.DoEvents()

        tmp = New Temporal(cn, usr.Codigo, "SRV")
        tmp.Abrir()
        tmp.LimpiarTabla()

        'Armo la grilla con los nuevos resultados
        Fecha = dtpDesde.Value
        Do
            tmp.Nuevo()
            tmp.Fecha(0) = Fecha.Date

            rr.BuscarRetirados(Fecha.Date)
            tmp.Numero(0) = rr.Extintores
            tmp.Numero(1) = rr.Mangueras

            rr.BuscarRecepcionados(Fecha.Date)
            tmp.Numero(2) = rr.Extintores
            tmp.Numero(3) = rr.ExtintoresRechazados
            tmp.Numero(4) = rr.ExtintoresSustitutos

            tmp.Numero(5) = rr.Mangueras
            tmp.Numero(6) = rr.ManguerasRechazadas
            tmp.Numero(7) = rr.ManguerasSustitutas

            rr.BuscarAPrefacturacion(Fecha.Date)
            tmp.Numero(8) = rr.Extintores + rr.ExtintoresRechazados
            tmp.Numero(9) = rr.Mangueras + rr.ManguerasRechazadas

            rr.BuscarALogistica(Fecha.Date)
            tmp.Numero(10) = rr.TotalExtintores
            tmp.Numero(11) = rr.TotalMangueras

            rr.BuscarEntregados(Fecha.Date)
            tmp.Numero(12) = rr.TotalExtintores
            tmp.Numero(13) = rr.TotalMangueras

            Fecha = Fecha.AddDays(1)
        Loop Until Fecha > dtpHasta.Value Or Fecha > Date.Today

        tmp.Grabar()

        rpt.Load(RPTX3 & "xrptsrv.rpt")
        rpt.SetParameterValue("USR", usr.Codigo)
        rpt.SetDatabaseLogon(DB_USR, DB_PWD)
        crv.ReportSource = rpt

        btnConsultar.Enabled = True
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
        Dim Sql As String
        Dim dt As New DataTable
        Dim da As OracleDataAdapter

        Sql = "SELECT SUM(equipos_0) "
        Sql &= "FROM xsegto2 xsg inner join "
        Sql &= "     interven itn on (xsg.itn_0 = itn.num_0) "
        Sql &= "WHERE xsg.dat_0 = :dat and "
        Sql &= "      itn.bpc_0 <> '402000'"

        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("dat", OracleType.DateTime).Value = Fecha
        da.Fill(dt)
        da.Dispose()

        If IsDBNull(dt.Rows(0).Item(0)) Then
            Return 0

        Else
            Return CInt(dt.Rows(0).Item(0))

        End If

    End Function
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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim i As Integer = 0

        Button1.Enabled = False
        Me.UseWaitCursor = True

        txt1a.Text = Calculo1(" ").ToString
        i += CInt(txt1a.Text)
        Application.DoEvents()

        txt1b.Text = Calculo1("SRV").ToString
        i += CInt(txt1b.Text)
        Application.DoEvents()

        txt2.Text = Calculo2("ADM").ToString
        i += CInt(txt2.Text)
        Application.DoEvents()

        txt2b.Text = Calculo2("VEN").ToString
        i += CInt(txt2b.Text)
        Application.DoEvents()

        txt3.Text = Calculo2("CTD").ToString
        i += CInt(txt3.Text)
        Application.DoEvents()
        txt4a.Text = CalculoLogistica("LOG").ToString
        i += CInt(txt4a.Text)
        Application.DoEvents()

        txt4b.Text = CalculoLogistica("ABO").ToString
        i += CInt(txt4b.Text)
        Application.DoEvents()

        txt4c.Text = Calculo2("ING").ToString
        i += CInt(txt4c.Text)
        Application.DoEvents()

        txt5a.Text = Calculo3("LOG").ToString
        i += CInt(txt5a.Text)
        txt5b.Text = Calculo3("ABO").ToString
        i += CInt(txt5b.Text)
        txt5c.Text = Calculo3("ING").ToString
        i += CInt(txt5c.Text)

        txt6.Text = Calculo4("MOS").ToString
        i += CInt(txt6.Text)

        txtTot.Text = i.ToString

        Application.DoEvents()

        Button1.Enabled = True
        Me.UseWaitCursor = False

    End Sub
    Private Sub txt1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt1a.DoubleClick, txt1b.DoubleClick, txt2.DoubleClick, txt2b.DoubleClick, txt3.DoubleClick, txt4a.DoubleClick, txt4b.DoubleClick, txt4c.DoubleClick, txt5a.DoubleClick, txt5b.DoubleClick, txt5c.DoubleClick, txt6.DoubleClick
        Dim txt As TextBox = CType(sender, TextBox)
        Dim dt As DataTable
        Dim flg As Boolean = False

        If dgv5.DataSource IsNot Nothing Then
            dt = CType(dgv5.DataSource, DataTable)

        Else
            col7Fecha.DataPropertyName = "dat_0"
            col7Intervencion.DataPropertyName = "num_0"
            col7Codigo.DataPropertyName = "bpc_0"
            col7Cliente.DataPropertyName = "bpcnam_0"
            col7Cantidad.DataPropertyName = "cant"
            col7Sucursal.DataPropertyName = "dire"
            col7Fecha2.DataPropertyName = "credat_0"
            col7Obs.DataPropertyName = "yobsrec_0"
            col7Rep.DataPropertyName = "rep_0"

            dt = New DataTable
            dgv5.DataSource = dt
        End If

        Me.UseWaitCursor = True
        With lblBuscando
            .Top = dgv5.Top + (dgv5.Height - .Height) \ 2
            .Left = dgv5.Left + (dgv5.Width - .Width) \ 2
            .Visible = True
            .BringToFront()
            Application.DoEvents()
            Application.DoEvents()
        End With

        If txt Is txt1a Then
            Calculo1(" ", dt)
            FechasRetiros(dt)
            lblTitulo.Text = "ESPERA DE PROCESO"

        ElseIf txt Is txt1b Then
            Calculo1("SRV", dt)
            FechasRetiros(dt)
            lblTitulo.Text = "EN PROCESO"

        ElseIf txt Is txt2 Then
            Calculo2("ADM", dt)
            FechaPistoleo(dt, "ADM")
            lblTitulo.Text = "ADMINISTRACION DE VENTA"

        ElseIf txt Is txt2b Then
            Calculo2("VEN", dt)
            FechaPistoleo(dt, "VEN")
            lblTitulo.Text = "VENTAS"

        ElseIf txt Is txt3 Then
            Calculo2("CTD", dt)
            FechaPistoleo(dt, "CTD")
            lblTitulo.Text = "CONTADOS"

        ElseIf txt Is txt4a Then
            Calculo2("LOG", dt)
            FechaPistoleo(dt, "LOG")
            lblTitulo.Text = "PENDIENTE - LOGISTICA"

        ElseIf txt Is txt4b Then
            Calculo2("ABO", dt)
            FechaPistoleo(dt, "ABO")
            lblTitulo.Text = "PENDIENTE - ABONOS"

        ElseIf txt Is txt4c Then
            Calculo2("ING", dt)
            FechaPistoleo(dt, "ING")
            lblTitulo.Text = "PENDIENTE - SISTEMAS FIJO"

        ElseIf txt Is txt5a Then
            Calculo3("LOG", dt)
            FechaPistoleo(dt, "LOG")
            lblTitulo.Text = "PENDIENTE CON RUTA - LOGISTICA"

        ElseIf txt Is txt5b Then
            Calculo3("ABO", dt)
            FechaPistoleo(dt, "ABO")
            lblTitulo.Text = "PENDIENTE CON RUTA - ABONOS"

        ElseIf txt Is txt5c Then
            Calculo3("ING", dt)
            FechaPistoleo(dt, "ING")
            lblTitulo.Text = "PENDIENTE CON RUTA - SISTEMAS FIJO"

        ElseIf txt Is txt6 Then
            Calculo4("MOS", dt)
            FechaPistoleo(dt, "MOS")
            lblTitulo.Text = "MOSTRADOR"
        End If

        lblBuscando.Visible = False
        Me.UseWaitCursor = False

        With dgv5
            .DataSource = dt
            .Columns(.Columns.Count - 1).Visible = False
        End With

    End Sub

    Private Function Calculo1(ByVal sector As String, Optional ByRef xdt As DataTable = Nothing, Optional ByVal txt As String = "") As Integer
        Dim da As OracleDataAdapter
        Dim Sql As String
        Dim dt As New DataTable
        Dim i As Integer = 0

        Sql = "select itn.dat_0, itn.num_0, itn.bpc_0, bpcnam_0, itn.bpaadd_0 || '-' || itn.add_0 as dire, equipos_1 + equipos_3 as cant, itn.credat_0, yobsrec_0, bpc.rep_0, itn.add_0 as sector "
        Sql &= "from interven itn  inner join "
        Sql &= "     xrutad xrd on (itn.num_0 = xrd.vcrnum_0) inner join "
        Sql &= "     bpcustomer bpc on (itn.bpc_0 = bpc.bpcnum_0) "
        Sql &= "where tipo_0 = 'RET' and "
        Sql &= "      typ_0 <> 'G1' and "
        Sql &= "      estado_0 = 3 and "
        Sql &= "      zflgtrip_0 = 2 and "
        Sql &= "      xsector_0 = :xsector and "
        Sql &= "      itn.bpc_0 <> '402000' "
        Sql &= "order by num_0"
        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("xsector", OracleType.VarChar).Value = sector
        da.Fill(dt)
        da.Dispose()

        Sql = "select itn.dat_0, itn.num_0, itn.bpc_0, bpcnam_0, itn.bpaadd_0 || '-' || itn.add_0 as dire, itn.credat_0, yobsrec_0, bpc.rep_0, itn.add_0 as sector, sum(tqty_0) as cant "
        Sql &= "from interven itn inner join "
        Sql &= "     yitndet yit on (itn.num_0 = yit.num_0 and typlig_0 = 1) inner join "
        Sql &= "     bpcustomer bpc on (itn.bpc_0 = bpc.bpcnum_0) "
        Sql &= "where zflgtrip_0 = 1 and "
        Sql &= "      typ_0 = 'D1' and "
        'Sql &= "      yotr_0 <> 0 and "
        Sql &= "      xsector_0 = :xsector and "
        Sql &= "      itn.bpc_0 <> '402000'"
        Sql &= "group by itn.dat_0, itn.num_0, itn.bpc_0, bpcnam_0, itn.bpaadd_0 || '-' || itn.add_0, itn.credat_0, yobsrec_0, bpc.rep_0, itn.add_0 "
        Sql &= "order by num_0"
        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("xsector", OracleType.VarChar).Value = sector
        da.Fill(dt)
        da.Dispose()

        For Each dr As DataRow In dt.Rows
            i += CInt(dr("cant"))

            If txt <> "" Then
                dr.BeginEdit()
                dr("sector") = txt
                dr.EndEdit()
            End If
        Next

        If xdt IsNot Nothing Then
            xdt = dt
        End If

        Return i

    End Function
    Private Function Calculo2(ByVal Sector As String, Optional ByRef xdt As DataTable = Nothing, Optional ByVal txt As String = "") As Integer
        Dim da As OracleDataAdapter
        Dim Sql As String
        Dim dt As DataTable
        Dim i As Integer = 0

        Sql = "select itn.dat_0, itn.num_0, itn.bpc_0, bpcnam_0, itn.bpaadd_0 || '-' || itn.add_0 as dire, xrd.equipos_1 + xrd.equipos_3 as cant, itn.credat_0, yobsrec_0, bpc.rep_0, itn.add_0 as sector "
        Sql &= "from interven itn inner join "
        Sql &= "     xrutad xrd on (itn.num_0 = xrd.vcrnum_0) inner join "
        Sql &= "	 xrutac xrc on (xrd.ruta_0 = xrc.ruta_0) inner join "
        Sql &= "     bpcustomer bpc on (itn.bpc_0 = bpc.bpcnum_0) "
        Sql &= "where xsector_0 = '" & Sector & "' and "
        Sql &= "	  (zflgtrip_0 IN (2,3,4,6) or ((ysdhdeb_0) <> ' ' and zflgtrip_0 = 7)) and "
        Sql &= "	  estado_0 = 3 and "
        Sql &= "	  valid_0 = 1 and "
        Sql &= "	  itn.tripnum_0 = ' ' and "
        Sql &= "	  tipo_0 = 'RET' and "
        Sql &= "      typ_0 <> 'G1' and "
        Sql &= "      itn.bpc_0 <> '402000' "
        Sql &= "order by num_0"

        da = New OracleDataAdapter(Sql, cn)
        dt = New DataTable
        da.Fill(dt)

        '2016.08.31 se quita para que no aparezca duplicado
        '--------------------------------------------------
        If Sector <> "LOG" And Sector <> "ING" And Sector <> "ABO" Then
            Sql = "select itn.dat_0, itn.num_0, itn.bpc_0, bpcnam_0, itn.bpaadd_0 || '-' || itn.add_0 as dire, itn.credat_0, yobsrec_0, bpc.rep_0, itn.add_0 as sector, sum(tqty_0) as cant "
            Sql &= "from (interven itn inner join yitndet yit on (itn.num_0 = yit.num_0 and typlig_0 = 1)) "
            Sql &= "     inner join bpcustomer bpc on (itn.bpc_0 = bpc.bpcnum_0) "
            Sql &= "where zflgtrip_0 IN (2,3,4,6) and typ_0 = 'D1' and xsector_0 = :xsector "
            Sql &= "group by itn.dat_0, itn.num_0, itn.bpc_0, bpcnam_0, itn.bpaadd_0 || '-' || itn.add_0, itn.credat_0, yobsrec_0, bpc.rep_0, itn.add_0  "
            Sql &= "order by num_0"
            da = New OracleDataAdapter(Sql, cn)
            da.SelectCommand.Parameters.Add("xsector", OracleType.VarChar).Value = Sector
            da.Fill(dt)
            da.Dispose()
        End If

        'Eliminacion de documentos duplicados
        For Each dr As DataRow In dt.Rows
            i += CInt(dr("cant"))

            If txt <> "" Then
                dr.BeginEdit()
                dr("sector") = txt
                dr.EndEdit()
            End If

        Next

        da.Dispose()
        dt.Dispose()

        If xdt IsNot Nothing Then xdt = dt
        Return i

    End Function
    Private Function CalculoLogistica(ByVal Sector As String, Optional ByRef xdt As DataTable = Nothing, Optional ByVal txt As String = "") As Integer
        Dim da As OracleDataAdapter
        Dim Sql As String
        Dim dt As DataTable
        Dim i As Integer = 0

        Sql = "select itn.dat_0, itn.num_0, itn.bpc_0, bpcnam_0, itn.bpaadd_0 || '-' || itn.add_0 as dire, xrd.equipos_1 + xrd.equipos_3 as cant, itn.credat_0, yobsrec_0, bpc.rep_0, itn.add_0 as sector "
        Sql &= "from interven itn inner join "
        Sql &= "     xrutad xrd on (itn.num_0 = xrd.vcrnum_0) inner join "
        Sql &= "	 xrutac xrc on (xrd.ruta_0 = xrc.ruta_0) inner join "
        Sql &= "     bpcustomer bpc on (itn.bpc_0 = bpc.bpcnum_0) "
        Sql &= "where xsector_0 = '" & Sector & "' and "
        Sql &= "	  (zflgtrip_0 IN (3,4,6) or ((ysdhdeb_0) <> ' ' and zflgtrip_0 = 7)) and "
        Sql &= "	  estado_0 = 3 and "
        Sql &= "	  valid_0 = 1 and "
        Sql &= "	  itn.tripnum_0 = ' ' and "
        Sql &= "	  tipo_0 = 'RET' and "
        Sql &= "      typ_0 <> 'G1' and "
        Sql &= "      itn.bpc_0 <> '402000' "
        Sql &= "order by num_0"

        da = New OracleDataAdapter(Sql, cn)
        dt = New DataTable
        da.Fill(dt)

        '2016.08.31 se quita para que no aparezca duplicado
        '--------------------------------------------------
        If Sector <> "LOG" And Sector <> "ING" And Sector <> "ABO" Then
            Sql = "select itn.dat_0, itn.num_0, itn.bpc_0, bpcnam_0, itn.bpaadd_0 || '-' || itn.add_0 as dire, itn.credat_0, yobsrec_0, bpc.rep_0, itn.add_0 as sector, sum(tqty_0) as cant "
            Sql &= "from (interven itn inner join yitndet yit on (itn.num_0 = yit.num_0 and typlig_0 = 1)) "
            Sql &= "     inner join bpcustomer bpc on (itn.bpc_0 = bpc.bpcnum_0) "
            Sql &= "where zflgtrip_0 IN (2,3,4,6) and typ_0 = 'D1' and xsector_0 = :xsector "
            Sql &= "group by itn.dat_0, itn.num_0, itn.bpc_0, bpcnam_0, itn.bpaadd_0 || '-' || itn.add_0, itn.credat_0, yobsrec_0, bpc.rep_0, itn.add_0  "
            Sql &= "order by num_0"
            da = New OracleDataAdapter(Sql, cn)
            da.SelectCommand.Parameters.Add("xsector", OracleType.VarChar).Value = Sector
            da.Fill(dt)
            da.Dispose()
        End If

        'Eliminacion de documentos duplicados
        For Each dr As DataRow In dt.Rows
            i += CInt(dr("cant"))

            If txt <> "" Then
                dr.BeginEdit()
                dr("sector") = txt
                dr.EndEdit()
            End If

        Next

        da.Dispose()
        dt.Dispose()

        If xdt IsNot Nothing Then xdt = dt
        Return i

    End Function
    Private Function Calculo3(ByVal Sector As String, Optional ByRef xdt As DataTable = Nothing, Optional ByVal txt As String = "") As Integer
        Dim da As OracleDataAdapter
        Dim Sql As String
        Dim dt As DataTable
        Dim i As Integer = 0

        Sql = "select itn.dat_0, itn.num_0, itn.bpc_0, bpcnam_0, itn.bpaadd_0 || '-' || itn.add_0 as dire, xrd.equipos_1 + xrd.equipos_3 as cant, itn.credat_0, yobsrec_0, bpc.rep_0, itn.add_0 as sector "
        Sql &= "from ((interven itn  inner join xrutad xrd on (itn.num_0 = xrd.vcrnum_0)) "
        Sql &= "	 inner join xrutac xrc on (xrd.ruta_0 = xrc.ruta_0)) "
        Sql &= "     inner join bpcustomer bpc on (itn.bpc_0 = bpc.bpcnum_0) "
        Sql &= "where xsector_0 = '" & Sector & "' and "
        Sql &= "	  (zflgtrip_0 IN (2,3,4,6) or ((ysdhdeb_0) <> ' ' and zflgtrip_0 = 7)) and "
        Sql &= "	  estado_0 = 3 and "
        Sql &= "	  valid_0 = 1 and "
        Sql &= "	  itn.tripnum_0 <> ' ' and "
        Sql &= "	  tipo_0 = 'RET' and "
        Sql &= "      typ_0 <> 'G1' and "
        Sql &= "      itn.bpc_0 <> '402000' "
        Sql &= "order by num_0"

        da = New OracleDataAdapter(Sql, cn)
        dt = New DataTable
        da.Fill(dt)

        Sql = "select itn.dat_0, itn.num_0, itn.bpc_0, bpcnam_0, itn.bpaadd_0 || '-' || itn.add_0 as dire, itn.credat_0, yobsrec_0, bpc.rep_0, itn.add_0 as sector, sum(tqty_0) as cant "
        Sql &= "from (interven itn inner join yitndet yit on (itn.num_0 = yit.num_0 and typlig_0 = 1)) "
        Sql &= "     inner join bpcustomer bpc on (itn.bpc_0 = bpc.bpcnum_0) "
        Sql &= "where zflgtrip_0 IN (2,3,4,6) and typ_0 = 'D1' and xsector_0 = :xsector "
        Sql &= "group by itn.dat_0, itn.num_0, itn.bpc_0, bpcnam_0, itn.bpaadd_0 || '-' || itn.add_0, itn.credat_0, yobsrec_0, bpc.rep_0, itn.add_0  "
        Sql &= "order by num_0"
        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("xsector", OracleType.VarChar).Value = Sector
        da.Fill(dt)
        da.Dispose()

        For Each dr As DataRow In dt.Rows
            i += CInt(dr("cant"))

            If txt <> "" Then
                dr.BeginEdit()
                dr("sector") = txt
                dr.EndEdit()
            End If
        Next

        da.Dispose()

        If xdt IsNot Nothing Then xdt = dt
        Return i

    End Function
    Private Function Calculo4(ByVal Sector As String, Optional ByRef xdt As DataTable = Nothing, Optional ByVal txt As String = "") As Integer
        Dim da As OracleDataAdapter
        Dim Sql As String
        Dim dt As DataTable
        Dim i As Integer = 0

        Sql = "select dat_0, itn.num_0, itn.bpc_0, bpcnam_0, itn.bpaadd_0 || '-' || itn.add_0 as dire, sum(tqty_0) as cant, itn.credat_0, yobsrec_0, bpc.rep_0, itn.add_0 as sector "
        Sql &= "from (interven itn  inner join yitndet yit on (itn.num_0 = yit.num_0)) "
        Sql &= "	 inner join bpcustomer bpc on (itn.bpc_0 = bpc.bpcnum_0) "
        Sql &= "where xsector_0 = '" & Sector & "' and "
        Sql &= "	  (zflgtrip_0 IN (2,3,4,6) or ((ysdhdeb_0) <> ' ' and zflgtrip_0 = 7)) and "
        Sql &= "	  yit.typlig_0 = 1 and "
        Sql &= "      typ_0 <> 'G1' and "
        Sql &= "      itn.bpc_0 <> '402000' "
        Sql &= "group by dat_0, itn.num_0, itn.bpc_0, bpcnam_0, itn.bpaadd_0 || '-' || itn.add_0, itn.credat_0, yobsrec_0, bpc.rep_0, itn.add_0 "
        Sql &= "order by dat_0, num_0"

        da = New OracleDataAdapter(Sql, cn)
        dt = New DataTable
        da.Fill(dt)

        For Each dr As DataRow In dt.Rows
            i += CInt(dr("cant"))

            If txt <> "" Then
                dr.BeginEdit()
                dr("sector") = txt
                dr.EndEdit()
            End If
        Next

        da.Dispose()
        dt.Dispose()

        If xdt IsNot Nothing Then xdt = dt
        Return i

    End Function
    Private Sub FechasRetiros(ByVal dt1 As DataTable)
        Dim da As OracleDataAdapter
        Dim sql As String
        Dim dt2 As New DataTable
        Dim dr2 As DataRow
        Dim dr1 As DataRow

        sql = "SELECT xc.* "
        sql &= "FROM xrutac xc INNER JOIN xrutad xd ON (xc.ruta_0 = xd.ruta_0) "
        sql &= "WHERE vcrnum_0 = :vcrnum AND estado_0 = 3 AND tipo_0 = 'RET'"

        da = New OracleDataAdapter(sql, cn)
        da.SelectCommand.Parameters.Add("vcrnum", OracleType.VarChar)

        For Each dr1 In dt1.Rows
            da.SelectCommand.Parameters("vcrnum").Value = dr1("num_0").ToString
            dt2.Clear()
            da.Fill(dt2)

            dr1.BeginEdit()
            If dt2.Rows.Count > 0 Then
                dr2 = dt2.Rows(0)

                dr1("credat_0") = CDate(dr2("fecha_0"))

            Else
                dr1("credat_0") = #12/31/1599#

            End If
            dr1.EndEdit()

        Next

    End Sub
    Private Sub FechaPistoleo(ByVal dt1 As DataTable, ByVal sector As String)
        Dim da As OracleDataAdapter
        Dim sql As String
        Dim dt2 As New DataTable
        Dim dr2 As DataRow
        Dim dr1 As DataRow

        sql = "select * "
        sql &= "from xsegto "
        sql &= "where itn_0 = :itn and para_0 = :sector "
        sql &= "order by fecha_0 desc, hora_0 desc "

        da = New OracleDataAdapter(sql, cn)
        da.SelectCommand.Parameters.Add("itn", OracleType.VarChar)
        da.SelectCommand.Parameters.Add("sector", OracleType.VarChar)

        For Each dr1 In dt1.Rows
            da.SelectCommand.Parameters("itn").Value = dr1("num_0").ToString
            da.SelectCommand.Parameters("sector").Value = sector
            dt2.Clear()
            da.Fill(dt2)

            dr1.BeginEdit()
            If dt2.Rows.Count > 0 Then
                dr2 = dt2.Rows(0)

                dr1("credat_0") = CDate(dr2("fecha_0"))

            Else
                dr1("credat_0") = #12/31/1599#

            End If
            dr1.EndEdit()

        Next

    End Sub

    Private Sub cms_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cms.Opening
        If dgv5.SelectedCells Is Nothing Then e.Cancel = True
        e.Cancel = dgv5.SelectedCells.Count = 0
    End Sub
    Private Sub mnuVer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuVer.Click
        Dim rpt As New ReportDocument
        Dim f As frmCrystal
        Dim t As String = dgv5.CurrentRow.Cells("col7Intervencion").Value.ToString

        Try
            rpt.Load(RPTX3 & "itn1.rpt")
            rpt.SetParameterValue("ITN", t)
            rpt.SetParameterValue("X3USR", usr.Codigo)

            f = New frmCrystal(rpt)
            f.MdiParent = Me.ParentForm
            f.Show()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            rpt.Close()
            rpt.Dispose() : rpt = Nothing

        End Try
    End Sub
    Private Sub mnuSegto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSegto.Click
        Dim rpt As New ReportDocument
        Dim t As String = dgv5.CurrentRow.Cells("col7Intervencion").Value.ToString
        Dim f As frmCrystal

        Try
            rpt.Load(RPTX3 & "xsegto_itn.rpt")
            rpt.SetParameterValue("itn", t)

            f = New frmCrystal(rpt)
            f.MdiParent = Me.ParentForm
            f.Show()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            rpt.Dispose() : rpt = Nothing

        End Try
    End Sub
    Private Sub mnuComentarios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuComentarios.Click
        Dim f As frmComentarios
        Dim dr As DataRow = CType(dgv5.SelectedRows(0).DataBoundItem, DataRowView).Row
        Dim itn As New Intervencion(cn)

        If Not itn.Abrir(dr("num_0").ToString) Then Exit Sub

        f = New frmComentarios(dr("yobsrec_0").ToString.Trim)
        f.ShowDialog(Me)

        If f.DialogResult = Windows.Forms.DialogResult.OK Then
            itn.ComentarioRec = f.txtComentario.Text
            itn.Grabar()

            dr.BeginEdit()
            dr("yobsrec_0") = itn.ComentarioRec
            dr.EndEdit()
            dr.AcceptChanges()
        End If

        f.Dispose()
        itn.Dispose()

    End Sub

    Private Sub dgv5_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgv5.CellFormatting

        If e.ColumnIndex = 1 Then

            If dgv5.Rows(e.RowIndex).Cells(7).Value.ToString.Trim = "" Then
                e.CellStyle.BackColor = Drawing.Color.White
            Else
                e.CellStyle.BackColor = Drawing.Color.Yellow
            End If

        End If

    End Sub

    Private Sub mnuPallet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPallet.Click
        Dim num As String = CType(dgv5.SelectedRows(0).DataBoundItem, DataRowView).Row("num_0").ToString
        Dim da As OracleDataAdapter
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim sql As String

        sql = "SELECT DISTINCT pallet_0 FROM sremac WHERE yitnnum_0 = :yitnnum AND pallet_0 > 0 ORDER BY pallet_0"
        da = New OracleDataAdapter(sql, cn)
        da.SelectCommand.Parameters.Add("yitnnum", OracleType.VarChar).Value = num
        da.Fill(dt)

        If dt.Rows.Count = 0 Then
            sql = "No hay información de pallet"
        Else
            sql = "Pallet:"
            For Each dr In dt.Rows
                sql &= " "
                sql &= dr("pallet_0").ToString
            Next
        End If

        da.Dispose() : da = Nothing
        dt.Dispose() : dt = Nothing

        MessageBox.Show(sql, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim dt As DataTable
        Dim dtx As New DataTable
        Dim txt As String

        If dgv5.DataSource IsNot Nothing Then
            dt = CType(dgv5.DataSource, DataTable)

        Else
            col7Fecha.DataPropertyName = "dat_0"
            col7Intervencion.DataPropertyName = "num_0"
            col7Codigo.DataPropertyName = "bpc_0"
            col7Cliente.DataPropertyName = "bpcnam_0"
            col7Cantidad.DataPropertyName = "cant"
            col7Sucursal.DataPropertyName = "dire"
            col7Fecha2.DataPropertyName = "credat_0"
            col7Obs.DataPropertyName = "yobsrec_0"
            col7Rep.DataPropertyName = "rep_0"

            dt = New DataTable
            dgv5.DataSource = dt
        End If

        dt.Clear()

        Me.UseWaitCursor = True
        With lblBuscando
            .Top = dgv5.Top + (dgv5.Height - .Height) \ 2
            .Left = dgv5.Left + (dgv5.Width - .Width) \ 2
            .Visible = True
            .BringToFront()
            Application.DoEvents()
            Application.DoEvents()
        End With

        txt = "ESPERA DE PROCESO"
        Calculo1(" ", dtx, txt)
        FechasRetiros(dtx)
        dt.Merge(dtx)

        txt = "EN PROCESO"
        Calculo1("SRV", dtx, txt)
        FechasRetiros(dtx)
        dt.Merge(dtx)

        txt = "ADMINISTRACION DE VENTA"
        Calculo2("ADM", dtx, txt)
        FechaPistoleo(dtx, "ADM")
        dt.Merge(dtx)

        txt = "VENTAS"
        Calculo2("VEN", dtx, txt)
        FechaPistoleo(dtx, "VEN")
        dt.Merge(dtx)

        txt = "CONTADOS"
        Calculo2("CTD", dtx, txt)
        FechaPistoleo(dtx, "CTD")
        dt.Merge(dtx)

        txt = "PENDIENTE - LOGISTICA"
        Calculo2("LOG", dtx, txt)
        FechaPistoleo(dtx, "LOG")
        dt.Merge(dtx)

        txt = "PENDIENTE - ABONOS"
        Calculo2("ABO", dtx, txt)
        FechaPistoleo(dtx, "ABO")
        dt.Merge(dtx)

        txt = "PENDIENTE - SISTEMAS FIJO"
        Calculo2("ING", dtx, txt)
        FechaPistoleo(dtx, "ING")
        dt.Merge(dtx)

        txt = "PENDIENTE CON RUTA - LOGISTICA"
        Calculo3("LOG", dtx, txt)
        FechaPistoleo(dtx, "LOG")
        dt.Merge(dtx)

        txt = "PENDIENTE CON RUTA - ABONOS"
        Calculo3("ABO", dtx, txt)
        FechaPistoleo(dtx, "ABO")
        dt.Merge(dtx)

        txt = "PENDIENTE CON RUTA - SISTEMAS FIJO"
        Calculo3("ING", dtx, txt)
        FechaPistoleo(dtx, "ING")
        dt.Merge(dtx)

        txt = "MOSTRADOR"
        Calculo4("MOS", dtx, txt)
        FechaPistoleo(dtx, "MOS")
        dt.Merge(dtx)

        lblBuscando.Visible = False
        Me.UseWaitCursor = False

        With dgv5
            .DataSource = dt
            .Columns(.Columns.Count - 1).Visible = True
        End With

    End Sub

End Class