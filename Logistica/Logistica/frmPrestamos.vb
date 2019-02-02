Imports System.Data.OracleClient

Public Class frmPrestamos
    Private dt1 As DataTable
    Private da1 As OracleDataAdapter
    Private dt2 As DataTable
    Private da2 As OracleDataAdapter

    Private Sub frmPrestamos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Sql As String

        AddHandler dgv1.RowPostPaint, AddressOf NumeracionGrillas
        AddHandler dgv2.RowPostPaint, AddressOf NumeracionGrillas

        TablitaAcciones(cboAcciones)

        Refrescar()

        Sql = "SELECT * FROM xprestamod WHERE itn_0 = :itn_0"
        da2 = New OracleDataAdapter(Sql, cn)
        da2.SelectCommand.Parameters.Add("itn_0", OracleType.VarChar)
        da2.InsertCommand = New OracleCommandBuilder(da2).GetInsertCommand

    End Sub
    Private Sub frmPrestamos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        da1.Dispose()
        da2.Dispose()
        dt1.Dispose()
        dt2.Dispose()
    End Sub
    Private Sub dgv1_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv1.RowEnter
        CargarDetalle()
    End Sub
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If dgv1.SelectedRows.Count = 0 Then Exit Sub

        Select Case cboAcciones.SelectedValue.ToString
            Case "REC"
                If Not IngresarRecupero() Then Exit Sub

            Case "FAC"
                If Not IngresarFacturacion() Then Exit Sub

            Case "PER"
                If Not IngresarPerdonado() Then Exit Sub

            Case "PAS"
                If Not IngresarConvertido() Then Exit Sub

            Case Else
                MessageBox.Show("Debe seleccionar una acción", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                cboAcciones.Focus()
                Exit Sub

        End Select

        dtpFecha.Value = Date.Today
        cboAcciones.SelectedValue = "---"
        txtRuta.Text = "0"
        txtExt.Text = "0"
        txtMang.Text = "0"
        txtDocumento.Clear()
        txtObs.Clear()

    End Sub
    Private Sub btnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizar.Click
        Refrescar()
    End Sub
    Private Sub txtDocumento_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDocumento.KeyUp
        If e.KeyCode = Keys.Enter AndAlso txtDocumento.Text.Trim <> "" Then ValidarDocumento()
    End Sub
    Private Sub txtDocumento_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDocumento.Leave
        If txtDocumento.Text.Trim <> "" Then ValidarDocumento()
    End Sub
    Private Sub cboAcciones_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAcciones.SelectedIndexChanged

        Select Case cboAcciones.SelectedValue.ToString
            Case "REC"
                txtDocumento.Enabled = True
                txtRuta.Enabled = True

            Case "FAC"
                txtDocumento.Enabled = True
                txtRuta.Enabled = True

            Case Else
                txtDocumento.Enabled = False
                txtRuta.Enabled = False
        End Select
    End Sub
    Private Sub txt_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRuta.Leave, txtExt.Leave, txtMang.Leave
        Dim txt As String = ""
        Dim c As String
        Dim i As Integer

        With CType(sender, TextBox)

            For i = 0 To .TextLength - 1
                c = Mid(.Text, i + 1, 1)
                If ("0123456789").Contains(c) Then txt &= c
            Next

            .Text = txt
            If .TextLength = 0 Then .Text = "0"

        End With

    End Sub

    Private Function IngresarRecupero() As Boolean
        Dim reg As New SeguimientoPrestamos(cn)
        Dim dr As DataRow = CType(dgv1.SelectedRows(0).DataBoundItem, DataRowView).Row

        reg.Abrir(dr("itn_0").ToString)

        'Miro si se recupero todo
        If txtExt.Text = "0" AndAlso txtMang.Text = "0" Then
            MessageBox.Show("Debe ingresar las cantidades de extintores y mangueras", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False

        ElseIf reg.ExtintoresFaltantes > CLng(txtExt.Text) OrElse reg.ManguerasFaltantes > CLng(txtMang.Text) Then
            If MessageBox.Show("¿Confirma que aún no se han recuperado todos los préstamos?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                Return False
            End If

        End If

        'Miro si se cargo la intervencion
        txtDocumento.Text = txtDocumento.Text.Trim
        If txtDocumento.Text = "" Then
            MessageBox.Show("Debe cargar la intervención", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False

        End If

        'Miro si se cargo la ruta
        If txtRuta.Text = "0" Then
            MessageBox.Show("Debe cargar el número de ruta", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False

        End If

        '********************************
        ' INGRESO EL RECUPERO
        '********************************
        AgregarDetalle(dtpFecha.Value, dr("itn_0").ToString, "REC", CLng(txtExt.Text), CLng(txtMang.Text), txtDocumento.Text, CLng(txtRuta.Text), txtObs.Text)
        da2.Update(dt2)

        With reg
            .RecuperoExtintor += CLng(txtExt.Text)
            .RecuperoManguera += CLng(txtMang.Text)

            If .RecuperoExtintor < 0 Then .RecuperoExtintor = 0
            If .RecuperoManguera < 0 Then .RecuperoManguera = 0

            .Grabar()
        End With

        ActualizarParquePrestamo(dr("itn_0").ToString, ARTICULO_PRESTAMO_EXT, CInt(txtExt.Text))
        ActualizarParquePrestamo(dr("itn_0").ToString, ARTICULO_PRESTAMO_MAN, CInt(txtMang.Text))

        Refrescar()
        CargarDetalle()

        Return True

    End Function
    Private Function IngresarFacturacion() As Boolean
        Dim reg As New SeguimientoPrestamos(cn)
        Dim dr As DataRow = CType(dgv1.SelectedRows(0).DataBoundItem, DataRowView).Row

        reg.Abrir(dr("itn_0").ToString)

        'Miro si se recupero todo
        If txtExt.Text = "0" AndAlso txtMang.Text = "0" Then
            MessageBox.Show("Debe ingresar las cantidades de extintores y mangueras", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False

        ElseIf reg.ExtintoresFaltantes > CLng(txtExt.Text) OrElse reg.ManguerasFaltantes > CLng(txtMang.Text) Then
            If MessageBox.Show("¿Confirma que aún no se han recuperado todos los préstamos?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                Return False
            End If

        End If

        'Miro si se cargo la intervencion
        txtDocumento.Text = txtDocumento.Text.Trim
        If txtDocumento.Text = "" Then
            MessageBox.Show("Debe cargar la factura", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False

        End If

        'Miro si se cargo la ruta
        If txtRuta.Text = "0" Then
            MessageBox.Show("Debe cargar el número de ruta", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False

        End If

        '********************************
        ' INGRESO EL RECUPERO
        '********************************
        AgregarDetalle(dtpFecha.Value, dr("itn_0").ToString, "FAC", CLng(txtExt.Text), CLng(txtMang.Text), txtDocumento.Text, CLng(txtRuta.Text), txtObs.Text)
        da2.Update(dt2)

        With reg
            .FacturadoExtintor += CLng(txtExt.Text)
            .FacturadoManguera += CLng(txtMang.Text)

            If .FacturadoExtintor < 0 Then .FacturadoExtintor = 0
            If .FacturadoManguera < 0 Then .FacturadoManguera = 0

            .Grabar()
        End With

        ActualizarParquePrestamo(dr("itn_0").ToString, ARTICULO_PRESTAMO_EXT, CInt(txtExt.Text))
        ActualizarParquePrestamo(dr("itn_0").ToString, ARTICULO_PRESTAMO_MAN, CInt(txtMang.Text))

        Refrescar()
        CargarDetalle()

        Return True

    End Function
    Private Function IngresarPerdonado() As Boolean
        Dim reg As New SeguimientoPrestamos(cn)
        Dim dr As DataRow = CType(dgv1.SelectedRows(0).DataBoundItem, DataRowView).Row

        reg.Abrir(dr("itn_0").ToString)

        'Miro si se recupero todo
        If txtExt.Text = "0" AndAlso txtMang.Text = "0" Then
            MessageBox.Show("Debe ingresar las cantidades de extintores y mangueras", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False

        ElseIf reg.ExtintoresFaltantes > CLng(txtExt.Text) OrElse reg.ManguerasFaltantes > CLng(txtMang.Text) Then
            If MessageBox.Show("¿Confirma que aún no se han recuperado todos los préstamos?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                Return False
            End If

        End If

        '********************************
        ' INGRESO EL RECUPERO
        '********************************
        AgregarDetalle(dtpFecha.Value, dr("itn_0").ToString, "FAC", CLng(txtExt.Text), CLng(txtMang.Text), txtDocumento.Text, CLng(txtRuta.Text), txtObs.Text)
        da2.Update(dt2)

        With reg
            .OkExtintor += CLng(txtExt.Text)
            .OkManguera += CLng(txtMang.Text)

            If .OkExtintor < 0 Then .OkExtintor = 0
            If .OkManguera < 0 Then .OkManguera = 0

            .Grabar()
        End With

        ActualizarParquePrestamo(dr("itn_0").ToString, ARTICULO_PRESTAMO_EXT, CInt(txtExt.Text))
        ActualizarParquePrestamo(dr("itn_0").ToString, ARTICULO_PRESTAMO_MAN, CInt(txtMang.Text))

        Refrescar()
        CargarDetalle()

        Return True

    End Function
    Private Function IngresarConvertido() As Boolean
        Dim reg As New SeguimientoPrestamos(cn)
        Dim dr As DataRow = CType(dgv1.SelectedRows(0).DataBoundItem, DataRowView).Row

        reg.Abrir(dr("itn_0").ToString)

        'Miro si se recupero todo
        If txtExt.Text = "0" AndAlso txtMang.Text = "0" Then
            MessageBox.Show("Debe ingresar las cantidades de extintores y mangueras", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False

        ElseIf reg.ExtintoresFaltantes > CLng(txtExt.Text) OrElse reg.ManguerasFaltantes > CLng(txtMang.Text) Then
            If MessageBox.Show("¿Confirma que aún no se han recuperado todos los préstamos?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                Return False
            End If

        End If

        '********************************
        ' INGRESO EL RECUPERO
        '********************************
        AgregarDetalle(dtpFecha.Value, dr("itn_0").ToString, "FAC", CLng(txtExt.Text), CLng(txtMang.Text), txtDocumento.Text, CLng(txtRuta.Text), txtObs.Text)
        da2.Update(dt2)

        With reg
            .ConvertidoExtintor += CLng(txtExt.Text)
            .ConvertidoManguera += CLng(txtMang.Text)

            If .ConvertidoExtintor < 0 Then .ConvertidoExtintor = 0
            If .ConvertidoManguera < 0 Then .ConvertidoManguera = 0

            .Grabar()
        End With

        ActualizarParquePrestamo(dr("itn_0").ToString, ARTICULO_PRESTAMO_EXT, CInt(txtExt.Text))
        ActualizarParquePrestamo(dr("itn_0").ToString, ARTICULO_PRESTAMO_MAN, CInt(txtMang.Text))

        Refrescar()
        CargarDetalle()

        Return True

    End Function
    Private Sub ValidarDocumento()
        If dgv1.SelectedRows.Count = 0 Then Exit Sub

        Dim dt As New DataTable
        Dim dr As DataRow
        Dim da As OracleDataAdapter
        Dim Sql As String

        dr = CType(dgv1.SelectedRows(0).DataBoundItem, DataRowView).Row

        Select Case cboAcciones.SelectedValue.ToString
            Case "REC"
                Sql = "SELECT num_0 FROM interven WHERE bpc_0 = :bpc_0 AND num_0 LIKE :num_0"
                da = New OracleDataAdapter(Sql, cn)
                With da.SelectCommand.Parameters
                    .Add("bpc_0", OracleType.VarChar).Value = dr("bpcnum_0").ToString
                    .Add("num_0", OracleType.VarChar).Value = "%" & txtDocumento.Text
                End With

            Case "FAC"
                Sql = "SELECT num_0 FROM sinvoice WHERE sivtyp_0 = 'FAC' AND bpr_0 = :bpr_0 AND num_0 LIKE :num_0"
                da = New OracleDataAdapter(Sql, cn)
                With da.SelectCommand.Parameters
                    .Add("bpr_0", OracleType.VarChar).Value = dr("bpcnum_0").ToString
                    .Add("num_0", OracleType.VarChar).Value = "%" & txtDocumento.Text
                End With

            Case Else
                Exit Sub

        End Select

        'Busco el documento
        Try
            da.Fill(dt)

            Select Case dt.Rows.Count
                Case 0
                    MessageBox.Show("No se encontro ningun documento", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtDocumento.SelectAll()
                    txtDocumento.Focus()

                Case 1
                    dr = dt.Rows(0)
                    txtDocumento.Text = dr(0).ToString

                Case Else
                    MessageBox.Show("Se encontraron varios documentos. Ingrese el numero completo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtDocumento.SelectAll()
                    txtDocumento.Focus()

            End Select

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub AgregarDetalle(ByVal Fecha As Date, ByVal Itn As String, ByVal Accion As String, ByVal Ext As Long, ByVal Mang As Long, ByVal Documento As String, ByVal Ruta As Long, ByVal Obs As String)
        Dim dr As DataRow

        dr = dt2.NewRow
        dr("fecha_0") = Fecha.Date
        dr("itn_0") = Itn
        dr("accion_0") = Accion
        dr("recuperado_0") = Ext
        dr("recuperado_1") = Mang
        dr("vcrnum_0") = IIf(Documento = "", " ", Documento)
        dr("ruta_0") = CLng(txtRuta.Text)
        dr("obs_0") = IIf(Obs = "", " ", Obs)
        dt2.Rows.Add(dr)

    End Sub
    Private Sub CargarDetalle()

        Dim dr As DataRow

        grpAcciones.Enabled = (dgv1.SelectedRows.Count = 1)

        If dgv1.SelectedRows.Count <= 0 Then
            If dt2 IsNot Nothing Then dt2.Clear()

        Else
            dr = CType(dgv1.SelectedRows(0).DataBoundItem, DataRowView).Row
            grpAcciones.Enabled = True

            'Consultar detalle
            da2.SelectCommand.Parameters("itn_0").Value = dr("itn_0").ToString
            If dt2 Is Nothing Then dt2 = New DataTable Else dt2.Clear()
            da2.Fill(dt2)

            If dgv2.DataSource Is Nothing Then
                col2Fecha.DataPropertyName = "fecha_0"
                col2Itn.DataPropertyName = "itn_0"
                TablitaAcciones(col2Accion)
                col2Accion.DataPropertyName = "accion_0"
                col2Ext.DataPropertyName = "recuperado_0"
                col2Mang.DataPropertyName = "recuperado_1"
                col2Documento.DataPropertyName = "vcrnum_0"
                col2Ruta.DataPropertyName = "ruta_0"
                col2Obs.DataPropertyName = "obs_0"
                dgv2.DataSource = dt2

            End If

        End If

    End Sub

    Private Sub Refrescar()
        Dim Sql As String = ""

        If RadioButton1.Checked Then
            Sql = "SELECT fecha_0, itn_0, xpr.ruta_0, bpcnum_0, bpcnam_0, faltante_0, retencion_0, recuperado_0, facturado_0, ok_0, convertido_0, faltante_1, retencion_1, recuperado_1, facturado_1, ok_1, convertido_1, bpaadd_0, add_0, srerep_0, chofer_0, acomp_0 "
            Sql &= "FROM ((((xprestamos xpr INNER JOIN interven itn ON (xpr.itn_0 = itn.num_0)) INNER JOIN serrequest sre ON (itn.srvdemnum_0 = sre.srenum_0)) INNER JOIN bpcustomer bpc ON (sre.srebpc_0 = bpc.bpcnum_0)) INNER JOIN xrutac rtc ON (xpr.ruta_0 = rtc.ruta_0)) INNER JOIN  zunitrans ON (transporte_0 = bptnum_0 AND patente_0 = patnum_0) "
            Sql &= "WHERE ((recuperado_0 + facturado_0 + ok_0 + convertido_0) < faltante_0) OR ((recuperado_1 + facturado_1 + ok_1 + convertido_1) < faltante_1) "
            Sql &= "ORDER BY fecha_0"
        ElseIf RadioButton2.Checked Then
            Sql = "SELECT fecha_0, itn_0, xpr.ruta_0, bpcnum_0, bpcnam_0, faltante_0, retencion_0, recuperado_0, facturado_0, ok_0, convertido_0, faltante_1, retencion_1, recuperado_1, facturado_1, ok_1, convertido_1, bpaadd_0, add_0, srerep_0, chofer_0, acomp_0 "
            Sql &= "FROM ((((xprestamos xpr INNER JOIN interven itn ON (xpr.itn_0 = itn.num_0)) INNER JOIN serrequest sre ON (itn.srvdemnum_0 = sre.srenum_0)) INNER JOIN bpcustomer bpc ON (sre.srebpc_0 = bpc.bpcnum_0)) INNER JOIN xrutac rtc ON (xpr.ruta_0 = rtc.ruta_0)) INNER JOIN  zunitrans ON (transporte_0 = bptnum_0 AND patente_0 = patnum_0) "
            Sql &= "WHERE bpc.xabo_0 = '2' and ((recuperado_0 + facturado_0 + ok_0 + convertido_0) < faltante_0) OR ((recuperado_1 + facturado_1 + ok_1 + convertido_1) < faltante_1) "
            Sql &= "ORDER BY fecha_0"
        ElseIf RadioButton3.Checked Then
            Sql = "SELECT fecha_0, itn_0, xpr.ruta_0, bpcnum_0, bpcnam_0, faltante_0, retencion_0, recuperado_0, facturado_0, ok_0, convertido_0, faltante_1, retencion_1, recuperado_1, facturado_1, ok_1, convertido_1, bpaadd_0, add_0, srerep_0, chofer_0, acomp_0 "
            Sql &= "FROM ((((xprestamos xpr INNER JOIN interven itn ON (xpr.itn_0 = itn.num_0)) INNER JOIN serrequest sre ON (itn.srvdemnum_0 = sre.srenum_0)) INNER JOIN bpcustomer bpc ON (sre.srebpc_0 = bpc.bpcnum_0)) INNER JOIN xrutac rtc ON (xpr.ruta_0 = rtc.ruta_0)) INNER JOIN  zunitrans ON (transporte_0 = bptnum_0 AND patente_0 = patnum_0) "
            Sql &= "WHERE bpc.xabo_0 <> '2' and ((recuperado_0 + facturado_0 + ok_0 + convertido_0) < faltante_0) OR ((recuperado_1 + facturado_1 + ok_1 + convertido_1) < faltante_1) "
            Sql &= "ORDER BY fecha_0"
        End If

        
        da1 = New OracleDataAdapter(Sql, cn)

        If dt1 Is Nothing Then dt1 = New DataTable
        dt1.Clear()
        da1.Fill(dt1)

        If dgv1.DataSource Is Nothing Then
            col1Fecha.DataPropertyName = "fecha_0"
            col1Intervencion.DataPropertyName = "itn_0"
            col1Ruta.DataPropertyName = "ruta_0"
            col1Codigo.DataPropertyName = "bpcnum_0"
            col1Cliente.DataPropertyName = "bpcnam_0"
            col1FaltanteExt.DataPropertyName = "faltante_0"
            col1FaltanteMan.DataPropertyName = "faltante_1"
            col1Retencion1.DataPropertyName = "retencion_0"
            col1Retencion2.DataPropertyName = "retencion_1"
            col1Recuperado1.DataPropertyName = "recuperado_0"
            col1Recuperado2.DataPropertyName = "recuperado_1"
            col1Facturado1.DataPropertyName = "facturado_0"
            col1Facturado2.DataPropertyName = "facturado_1"
            col1Ok1.DataPropertyName = "ok_0"
            col1Ok2.DataPropertyName = "ok_1"
            col1Convertido1.DataPropertyName = "convertido_0"
            col1Convertido2.DataPropertyName = "convertido_1"
            col1Suc.DataPropertyName = "bpaadd_0"
            col1Domicilio.DataPropertyName = "add_0"
            col1Rep.DataPropertyName = "srerep_0"
            col1Fletero.DataPropertyName = "chofer_0"

            MenuLocal(cn, 2408, col1Responsable, True)
            col1Responsable.DataPropertyName = "acomp_0"

            dgv1.DataSource = dt1
        End If

    End Sub
    Private Sub TablitaAcciones(ByVal cbo As ComboBox)
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim IDs(4) As String

        IDs(0) = "---"
        IDs(1) = "RECUPERADO"
        IDs(2) = "FACTURADO"
        IDs(3) = "PERDONADO"
        IDs(4) = "PASADO A PRESTAMO"

        dt.Columns.Add("id", GetType(String)).MaxLength = 3
        dt.Columns.Add("desc", GetType(String)).MaxLength = 20

        For i = LBound(IDs) To UBound(IDs)
            dr = dt.NewRow
            dr("id") = IDs(i).Substring(0, 3)
            dr("desc") = IDs(i)
            dt.Rows.Add(dr)
        Next
        dt.AcceptChanges()

        cbo.DataSource = dt
        cbo.ValueMember = "id"
        cbo.DisplayMember = "desc"

    End Sub
    Private Sub TablitaAcciones(ByVal cbo As DataGridViewComboBoxColumn)
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim IDs(4) As String

        IDs(0) = "---"
        IDs(1) = "RECUPERADO"
        IDs(2) = "FACTURADO"
        IDs(3) = "PERDONADO"
        IDs(4) = "PASADO A PRESTAMO"

        dt.Columns.Add("id", GetType(String)).MaxLength = 3
        dt.Columns.Add("desc", GetType(String)).MaxLength = 20

        For i = LBound(IDs) To UBound(IDs)
            dr = dt.NewRow
            dr("id") = IDs(i).Substring(0, 3)
            dr("desc") = IDs(i)
            dt.Rows.Add(dr)
        Next
        dt.AcceptChanges()

        cbo.DataSource = dt
        cbo.ValueMember = "id"
        cbo.DisplayMember = "desc"

    End Sub
    Private Sub ActualizarParquePrestamo(ByVal itn As String, ByVal Articulo As String, ByVal Cantidad As Integer)
        Dim mac As New Parque(cn)

        If mac.Abrir(mac.ObtenerParquePrestamo(itn, Articulo)) Then
            mac.Cantidad -= Cantidad
            If mac.Cantidad <= 0 Then
                mac.Borrar()
            Else
                mac.Grabar()
            End If
        End If

        mac = Nothing

    End Sub

End Class