Imports System.Data.OracleClient

Public Class frmReporteServicios
    Private dtRecargas As New DataTable
    Private Fecha As Date
    Private dv As DataView

    Private Sub frmReporteSistemasFijos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtpFecha.Value = New Date(Today.Year, Today.Month, 1).AddYears(-1)
        CargarVendedores()

        AddHandler dgv.RowPostPaint, AddressOf NumeracionGrillas

    End Sub
    Private Sub btnFiltro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFiltro.Click
        ApplicarFiltros()
    End Sub
    Private Sub CargarVendedores()
        Dim i As Integer
        Dim dr As DataRow
        Dim da As OracleDataAdapter
        Dim Sql As String = ""
        Dim dt As New DataTable

        Sql = "SELECT repnum_0, repnam_0 FROM salesrep WHERE activo_0 = 2 ORDER BY repnam_0"
        da = New OracleDataAdapter(Sql, cn)

        'Cargo combo de vendedores
        da.Fill(dt)

        'Si el usuario es vendedor, elimino de la tabla los demás vendedores
        If usr.Codigo.Length = 2 Then
            For i = dt.Rows.Count - 1 To 0 Step -1
                dr = dt.Rows(i)

                If usr.Codigo <> dr("repnum_0").ToString Then
                    dt.Rows.Remove(dr)
                End If
            Next
        End If

        'Enlazo la tabla al ListBox
        With lstVendedores
            .DataSource = dt
            .ValueMember = "repnum_0"
            .DisplayMember = "repnam_0"
        End With

        'Recorro todos los vendedores y los chequeo
        For i = 0 To lstVendedores.Items.Count - 1
            lstVendedores.SetItemChecked(i, True)
        Next

    End Sub
    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Fecha = dtpFecha.Value

        btnBuscar.Enabled = False
        Application.DoEvents()
        Application.DoEvents()

        Recargas()
        Agua()
        Deteccion()
        Cocinas()

        If dv Is Nothing Then
            dv = New DataView(dtRecargas)
            ApplicarFiltros()
        End If

        If dgv.DataSource Is Nothing Then
            colCliente.DataPropertyName = "bpc_0"
            colNombre.DataPropertyName = "bpcnam_0"
            colSucursal.DataPropertyName = "bpaadd_0"
            colDireccion.DataPropertyName = "bpaaddlig_0"
            colVendedor.DataPropertyName = "rep_0"
            colRecarga.DataPropertyName = "recarga"
            colAgua.DataPropertyName = "agua"
            colDeteccion.DataPropertyName = "deteccion"
            colCocinas.DataPropertyName = "cocinas"
            dgv.DataSource = dv
        End If

        btnBuscar.Enabled = True

    End Sub

    Private Sub Recargas()
        Dim Sql As String
        Dim da As OracleDataAdapter

        Sql = "SELECT DISTINCT itn.bpc_0, bpc.bpcnam_0, itn.bpaadd_0, bpa.bpaaddlig_0, bpc.rep_0, 1 as recarga, 0 as agua, 0 as deteccion, 0 as cocinas "
        Sql &= "FROM interven itn INNER JOIN "
        Sql &= "	 yitndet yit ON (yit.num_0 = itn.num_0 AND yit.typlig_0 = 1) INNER JOIN "
        Sql &= "	 itmmaster itm ON (itm.itmref_0 = yit.itmref_0) INNER JOIN "
        Sql &= "	 bpcustomer bpc on (itn.bpc_0 = bpc.bpcnum_0) INNER JOIN "
        Sql &= "     bpaddress bpa on (bpa.bpanum_0 = itn.bpc_0 and bpa.bpaadd_0 = itn.bpaadd_0) "
        Sql &= "WHERE itn.dat_0 >= :fecha AND "
        'Sql &= "	  itn.zflgtrip_0 = 5 AND "
        Sql &= "      itm.cfglin_0 = '451'"

        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("fecha", OracleType.DateTime).Value = Fecha

        da.Fill(dtRecargas)
        da.Dispose()
    End Sub
    Private Sub Agua()
        Dim Sql As String
        Dim da As OracleDataAdapter
        Dim dt As New DataTable

        Sql = "SELECT DISTINCT itn.bpc_0, bpc.bpcnam_0, itn.bpaadd_0, bpa.bpaaddlig_0, bpc.rep_0 "
        Sql &= "FROM interven itn INNER JOIN "
        Sql &= "	 yitndet yit ON (yit.num_0 = itn.num_0 AND yit.typlig_0 = 1) INNER JOIN "
        Sql &= "	 itmmaster itm ON (itm.itmref_0 = yit.itmref_0) INNER JOIN "
        Sql &= "	 bpcustomer bpc on (itn.bpc_0 = bpc.bpcnum_0) INNER JOIN "
        Sql &= "     bpaddress bpa on (bpa.bpanum_0 = itn.bpc_0 and bpa.bpaadd_0 = itn.bpaadd_0) "
        Sql &= "WHERE itn.dat_0 >= :fecha AND "
        'Sql &= "	  itn.zflgtrip_0 = 5 AND "
        Sql &= "      itm.tsicod_1 = '161' and "
        Sql &= "      itm.tsicod_2 = '233' and "
        Sql &= "      itm.tsicod_3 = '304'"


        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("fecha", OracleType.DateTime).Value = Fecha
        da.Fill(dt)
        da.Dispose()

        Procesar(dt, "agua")

    End Sub
    Private Sub Deteccion()
        Dim Sql As String
        Dim da As OracleDataAdapter
        Dim dt As New DataTable

        Sql = "SELECT DISTINCT itn.bpc_0, bpc.bpcnam_0, itn.bpaadd_0, bpa.bpaaddlig_0, bpc.rep_0 "
        Sql &= "FROM interven itn INNER JOIN "
        Sql &= "	 yitndet yit ON (yit.num_0 = itn.num_0 AND yit.typlig_0 = 1) INNER JOIN "
        Sql &= "	 itmmaster itm ON (itm.itmref_0 = yit.itmref_0) INNER JOIN "
        Sql &= "	 bpcustomer bpc on (itn.bpc_0 = bpc.bpcnum_0) INNER JOIN "
        Sql &= "     bpaddress bpa on (bpa.bpanum_0 = itn.bpc_0 and bpa.bpaadd_0 = itn.bpaadd_0) "
        Sql &= "WHERE itn.dat_0 >= :fecha AND "
        'Sql &= "	  itn.zflgtrip_0 = 5 AND "
        Sql &= "      itm.tsicod_1 = '181' and "
        Sql &= "      itm.tsicod_2 = '233' and "
        Sql &= "      itm.tsicod_3 = '304'"

        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("fecha", OracleType.DateTime).Value = Fecha
        da.Fill(dt)
        da.Dispose()

        Procesar(dt, "deteccion")

    End Sub
    Private Sub Cocinas()
        Dim Sql As String
        Dim da As OracleDataAdapter
        Dim dt As New DataTable

        Sql = "SELECT DISTINCT itn.bpc_0, bpc.bpcnam_0, itn.bpaadd_0, bpa.bpaaddlig_0, bpc.rep_0 "
        Sql &= "FROM interven itn INNER JOIN "
        Sql &= "	 hdktask hdk ON (hdk.itnnum_0 = itn.num_0) INNER JOIN "
        Sql &= "	 itmmaster itm ON (itm.itmref_0 = hdk.hdtitm_0) INNER JOIN "
        Sql &= "	 bpcustomer bpc on (itn.bpc_0 = bpc.bpcnum_0) INNER JOIN "
        Sql &= "     bpaddress bpa on (bpa.bpanum_0 = itn.bpc_0 and bpa.bpaadd_0 = itn.bpaadd_0) "
        Sql &= "WHERE itn.dat_0 >= :fecha AND "
        Sql &= "      itm.tsicod_1 = '171' and "
        Sql &= "      itm.tsicod_2 = '233' and "
        Sql &= "      itm.tsicod_3 = '304'"

        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("fecha", OracleType.DateTime).Value = Fecha
        da.Fill(dt)
        da.Dispose()

        Procesar(dt, "cocinas")

    End Sub
    Private Sub Procesar(ByVal dt As DataTable, ByVal Campo As String)
        Dim dv As New DataView(dtRecargas)
        Dim dr1 As DataRow

        For Each dr As DataRow In dt.Rows
            'Busco si existe el clilente sucursal en la tabla principal
            dv.RowFilter = "bpc_0 = '" & dr("bpc_0").ToString & "' AND bpaadd_0 = '" & dr("bpaadd_0").ToString & "'"

            If dv.Count > 0 Then
                dr1 = CType(dv.Item(0), DataRowView).Row
                dr.BeginEdit()
                dr1(Campo) = 1
                dr.EndEdit()
            Else
                dr1 = dtRecargas.NewRow
                dr1("bpc_0") = dr("bpc_0").ToString
                dr1("bpcnam_0") = dr("bpcnam_0").ToString
                dr1("bpaadd_0") = dr("bpaadd_0").ToString
                dr1("bpaaddlig_0") = dr("bpaaddlig_0").ToString
                dr1("rep_0") = dr("rep_0").ToString

                dr1("recarga") = IIf(Campo = "recarga", 1, 0)
                dr1("agua") = IIf(Campo = "agua", 1, 0)
                dr1("deteccion") = IIf(Campo = "deteccion", 1, 0)
                dr1("cocinas") = IIf(Campo = "cocinas", 1, 0)
                dtRecargas.Rows.Add(dr1)
            End If
        Next

    End Sub
    Private Sub ApplicarFiltros()
        Dim f As String = ""

        Select Case chkRecargas.CheckState
            Case CheckState.Checked
                f = "recarga = 1"

            Case CheckState.Unchecked
                f = "recarga = 0"

            Case CheckState.Indeterminate
                f = "recarga in (0,1)"

        End Select

        f &= " and "

        Select Case chkAgua.CheckState
            Case CheckState.Checked
                f &= "agua = 1"

            Case CheckState.Unchecked
                f &= "agua = 0"

            Case CheckState.Indeterminate
                f &= " agua in (0,1)"

        End Select

        f &= " and "

        Select Case chkDeteccion.CheckState
            Case CheckState.Checked
                f &= "deteccion = 1"

            Case CheckState.Unchecked
                f &= "deteccion = 0"

            Case CheckState.Indeterminate
                f &= "deteccion in (0,1)"

        End Select

        f &= " and "

        Select Case chkCocinas.CheckState
            Case CheckState.Checked
                f &= "cocinas = 1"

            Case CheckState.Unchecked
                f &= "cocinas = 0"

            Case CheckState.Indeterminate
                f &= "cocinas in (0,1)"

        End Select

        Dim v As String = ""

        For Each dr As DataRowView In lstVendedores.CheckedItems
            v &= "'" & dr("repnum_0").ToString & "',"
        Next

        If v.Length > 0 Then
            v = v.Substring(0, v.Length - 1)
            f &= " AND rep_0 in (" & v & ")"
        End If

        If dv IsNot Nothing Then
            dv.RowFilter = f
        End If

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