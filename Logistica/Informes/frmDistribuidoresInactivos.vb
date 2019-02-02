Imports System.Data.OracleClient

Public Class frmDistribuidoresInactivos

    Private Sub frmDistribuidoresInactivos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            CargarFeriados()
            CargarVendedores()

            MenuLocal(cn, 234, colEstado, True)
            MenuLocal(cn, 401, colTipo, False)

            btnGenerar.Enabled = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        AddHandler dgv.RowPostPaint, AddressOf NumeracionGrillas

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
        Dim Sql As String = "SELECT repnum_0, repnam_0 FROM salesrep WHERE length(repnum_0) = 2 ORDER BY repnam_0"
        Dim i As Integer
        Dim dr As DataRow
        Dim dt As New DataTable
        Dim da As New OracleDataAdapter(Sql, cn)

        'Cargo combo de vendedores
        da.Fill(dt)

        'Si el usuario es vendedor, elimino de la tabla los demás vendedores
        If USR.Codigo.Length = 2 Then
            For i = dt.Rows.Count - 1 To 0 Step -1
                dr = dt.Rows(i)

                If Usr.Codigo = "24" Then 'Monica Ferrari. 
                    'Patch para que le parezcan los dos numeros de vendedores
                    If dr("repnum_0").ToString <> "19" AndAlso dr("repnum_0").ToString <> "24" Then
                        dt.Rows.Remove(dr)
                    End If

                Else
                    If Usr.Codigo <> dr("repnum_0").ToString Then
                        dt.Rows.Remove(dr)
                    End If

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

        da.Dispose()

    End Sub
    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        'Valido que por lo menos haya un vendedor seleccionado
        If lstVendedores.CheckedItems.Count = 0 Then
            MessageBox.Show("Debe seleccionar al menos un vendedor", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        Dim Sql As String
        Dim da As OracleDataAdapter
        Dim dt As DataTable
        Dim dv As DataView
        Dim dr As DataRowView

        btnGenerar.Enabled = False
        Me.UseWaitCursor = True

        Sql = "SELECT bpcnum_0, bpcnam_0, bpa.cty_0, bpa.sat_0, ostctl_0, rep_0, bpctyp_0 "
        Sql &= "FROM (bpcustomer bpc INNER JOIN bpartner bpr ON (bpc.bpcnum_0 = bpr.bprnum_0)) INNER JOIN bpaddress bpa ON (bpa.bpanum_0 = bpr.bprnum_0 AND bpa.bpaadd_0 = bpr.bpaadd_0) "
        Sql &= "WHERE tsccod_1 IN ('20', '30') AND bpcsta_0 = 2 AND "
        Sql &= "bpcnum_0 NOT IN (SELECT DISTINCT bpr_0 FROM sinvoice WHERE sivtyp_0 = 'FAC' AND accdat_0 >= to_date(:dat, 'dd/mm/yyyy'))"

        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("dat", OracleType.VarChar).Value = Calendario.SelectionRange.Start.ToString("dd/MM/yyyy")

        If dgv.DataSource Is Nothing Then
            dt = New DataTable
            dv = New DataView(dt)

            colCodigo.DataPropertyName = "bpcnum_0"
            colCliente.DataPropertyName = "bpcnam_0"
            colLocalidad.DataPropertyName = "cty_0"
            colProvincia.DataPropertyName = "sat_0"
            colVendedor.DataPropertyName = "rep_0"
            colEstado.DataPropertyName = "ostctl_0"
            colTipo.DataPropertyName = "bpctyp_0"
            dgv.DataSource = dv

        Else
            dv = CType(dgv.DataSource, DataView)
            dt = dv.Table
            dt.Clear()

        End If

        da.Fill(dt)

        'Aplicar filtro
        Sql = ""
        For i = 0 To lstVendedores.CheckedItems.Count - 1
            dr = CType(lstVendedores.CheckedItems(i), DataRowView)

            Sql &= "'" & dr("repnum_0").ToString & "'"
            If i < lstVendedores.CheckedItems.Count - 1 Then Sql &= ","

        Next

        dv.RowFilter = "rep_0 IN (" & Sql & ")"

        btnGenerar.Enabled = True
        Me.UseWaitCursor = False

    End Sub

#Region "MENU CONTEXTUAL VENDEDORES"
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

#End Region
#Region "MENU CONTEXTUAL: GRILLA"
    Private Sub ContextMenuStrip1_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        'Cancelo la apertura del menu si no hay fila seleccionada
        e.Cancel = (dgv.SelectedRows.Count <> 1)

        Dim dr As DataRow = CType(dgv.CurrentRow.DataBoundItem, DataRowView).Row

        If CInt(dr("bpctyp_0")) <> 1 Then
            e.Cancel = True
            MessageBox.Show("El tercero es un prospecto", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

    End Sub
    Private Sub mnuUltimaCompra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuUltimaCompra.Click
        Dim txt As String
        Dim da As OracleDataAdapter
        Dim dt As New DataTable
        Dim dr As DataRow = CType(dgv.SelectedRows(0).DataBoundItem, DataRowView).Row

        Me.UseWaitCursor = True
        Application.DoEvents()

        txt = "SELECT accdat_0, sih.num_0, amtati_0 "
        txt &= "FROM sinvoice sih INNER JOIN sinvoicev siv ON (sih.num_0 = siv.num_0)"
        txt &= "WHERE bpcord_0 = :bpcord_0 AND sih.sivtyp_0 = 'FAC' AND rownum =1"
        txt &= "ORDER BY accdat_0 DESC"

        da = New OracleDataAdapter(txt, cn)
        da.SelectCommand.Parameters.Add("bpcord_0", OracleType.VarChar).Value = dr("bpcnum_0").ToString
        da.Fill(dt)

        Me.UseWaitCursor = False

        If dt.Rows.Count = 1 Then
            txt = "Última compra del cliente: {bpcnum} {bpcnam}" & vbCrLf & vbCrLf
            txt &= "Fecha:   {fecha}" & vbCrLf
            txt &= "Factura: {factura}" & vbCrLf
            txt &= "Importe: {importe}"

            txt = txt.Replace("{bpcnum}", dr("bpcnum_0").ToString)
            txt = txt.Replace("{bpcnam}", dr("bpcnam_0").ToString)

            dr = dt.Rows(0)

            txt = txt.Replace("{fecha}", CDate(dr("accdat_0")).ToString("dd/MM/yyyy"))
            txt = txt.Replace("{factura}", dr("num_0").ToString)
            txt = txt.Replace("{importe}", CLng(dr("amtati_0").ToString).ToString("N2"))

            MessageBox.Show(txt, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

        Else
            MessageBox.Show("Este cliente no registra compras", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

        da.Dispose()


    End Sub
    Private Sub mnuSaldoCuenta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSaldoCuenta.Click
        Dim txt As String
        Dim da As OracleDataAdapter
        Dim dt As New DataTable
        Dim dr As DataRow = CType(dgv.SelectedRows(0).DataBoundItem, DataRowView).Row

        Me.UseWaitCursor = True
        Application.DoEvents()

        txt = "SELECT sum((amtloc_0 - payloc_0) * sns_0) "
        txt &= "FROM gaccdudate "
        txt &= "WHERE bpr_0 = :bpr_0 AND sac_0 = 'DVL'"

        da = New OracleDataAdapter(txt, cn)
        da.SelectCommand.Parameters.Add("bpr_0", OracleType.VarChar).Value = dr("bpcnum_0").ToString

        da.Fill(dt)

        Me.UseWaitCursor = False

        txt = "Saldo de la cuenta del cliente: {bpcnum} {bpcnam}" & vbCrLf & vbCrLf
        txt &= "Saldo: {saldo}"
        txt = txt.Replace("{bpcnum}", dr("bpcnum_0").ToString)
        txt = txt.Replace("{bpcnam}", dr("bpcnam_0").ToString)

        dr = dt.Rows(0)

        If IsDBNull(dr(0)) Then
            txt = txt.Replace("{saldo}", CLng("0").ToString("N2"))
        Else
            txt = txt.Replace("{saldo}", CLng(dr(0)).ToString("N2"))
        End If


        MessageBox.Show(txt, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

        da.Dispose()

    End Sub
#End Region

End Class