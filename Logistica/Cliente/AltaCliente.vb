Imports System.Data.OracleClient
Imports System.Collections
Imports WSAFIP

Public Class AltaCliente
    Private CerrarAlGrabar As Boolean = False
    Private bpc As Cliente = Nothing

    Public Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        bpc = New Cliente(cn)
        bpc.Nuevo()
    End Sub
    Public Sub New(ByVal bpc As Cliente)
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.bpc = bpc

        CerrarAlGrabar = True
    End Sub
    Public Sub New(ByVal Codigo As String)
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        bpc = New Cliente(cn)
        bpc.Abrir(Codigo)

        CerrarAlGrabar = True
    End Sub

    'Sub
    Private Sub AltaCliente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim tb As TablaVaria
        Dim dt As DataTable

        'Enlace ComboBox de Familias Estadisticas
        tb = New TablaVaria(cn, 30, True)
        tb.EnlazarComboBox(cboFamilia1)
        cboFamilia1.SelectedValue = " "
        tb = New TablaVaria(cn, 31, True)
        tb.EnlazarComboBox(cboFamilia2)
        cboFamilia2.SelectedValue = " "
        tb = New TablaVaria(cn, 32, True)
        tb.EnlazarComboBox(cboFamilia3)
        cboFamilia3.SelectedValue = " "
        'Enlace ComboBox Tipo Documento
        tb = New TablaVaria(cn, 1002, True)
        tb.EnlazarComboBox(cboTipoDoc)
        cboTipoDoc.SelectedValue = " "

        'Enlace ComboBox de IVA
        tb = New TablaVaria(cn, 1, True)
        tb.EnlazarComboBox(cboIva)
        'Elimino los registro que no se usan
        dt = CType(cboIva.DataSource, DataTable)
        For i As Integer = dt.Rows.Count - 1 To 0 Step -1
            Dim dr As DataRow = dt.Rows(i)
            Select Case dr("ident2_0").ToString
                Case "CF", "EP", "EX", "RI", "RIE", "RM", " "
                    'ok
                Case Else
                    dt.Rows.Remove(dr)
            End Select
        Next
        '---
        'Enlace Combo Condición de Pago
        CondicionPago.LlenarComboBox(cn, cboCondicionPago, True)
        cboCondicionPago.SelectedValue = " "
        'Enlace ComboBox vendedor
        Vendedor.Enlazar(cn, cboVendedor, True)
        cboVendedor.SelectedValue = " "
        'Enlace CombBox Tipo IB
        tb = New TablaVaria(cn, 8504, True)
        tb.EnlazarComboBox(cboCondicionIb)

        'Elimino los tipos de documentos que no se usan
        dt = CType(cboTipoDoc.DataSource, DataTable)
        For i As Integer = dt.Rows.Count - 1 To 0 Step -1
            Dim dr As DataRow = dt.Rows(i)
            Select Case dr("ident2_0").ToString
                Case "80", "86", "96", "99", " "
                    'ok
                Case Else
                    dt.Rows.Remove(dr)
            End Select
        Next

        'Carga los campos de pantalla con los datos del cliente actual
        MostrarDatosCliente()

        'Enlace de la grilla de sucursales
        EnlazarSucursales()

    End Sub

    Private Sub MostrarDatosCliente()
        cboFamilia1.SelectedValue = bpc.Familia1
        cboFamilia2.SelectedValue = bpc.Familia2
        cboFamilia3.SelectedValue = bpc.Familia3
        txtCodigoCliente.Text = bpc.Codigo.Trim
        'Deshabilito el campo si es edicion de cliente
        txtCodigoCliente.ReadOnly = (bpc.Codigo.Trim <> "")
        btnProponer.Enabled = bpc.Codigo.Trim = ""
        '---
        txtCodigoPagador.Text = bpc.TerceroPagador.Codigo.Trim
        txtNombre.Text = bpc.Nombre.Trim
        txtFantasia.Text = bpc.NombreFantasia.Trim
        cboTipoDoc.SelectedValue = bpc.TipoDoc
        txtNumDoc.Text = bpc.CUIT.Trim
        cboCondicionIb.SelectedValue = bpc.CondicionIb
        txtIIBB.Text = bpc.IIBB.Trim
        txtMailFc.Text = bpc.MailFC.Trim
        cboCondicionPago.SelectedValue = bpc.CondicionPago.Codigo
        cboIva.SelectedValue = bpc.RegimenImpuesto
        cboVendedor.SelectedValue = bpc.Vendedor.Codigo
        txtObservaciones.Text = bpc.Observaciones.Trim

        chkRequiereFactura.Checked = bpc.RequiereFacturaFisica
    End Sub

    'Function
    Private Function ProponerSiguienteCodigo(ByVal Tipo As String) As String
        Dim da As OracleDataAdapter
        Dim dt As New DataTable
        Dim dv As DataView
        Dim sql As String = "select bprnum_0 from bpartner where bprnum_0 like :p "
        Dim j, i As Integer
        Dim s As String = ""

        da = New OracleDataAdapter(sql, cn)
        da.SelectCommand.Parameters.Add("p", OracleType.VarChar).Value = Tipo & "%"
        da.Fill(dt)
        da.Dispose()

        dv = New DataView(dt)

        j = CInt(Tipo)
        j *= 10000

        For i = j + 1 To j + 9999
            s = i.ToString
            dv.RowFilter = "bprnum_0 = '" & s & "'"
            If dv.Count = 0 Then Exit For
            s = ""
        Next

        Return s

    End Function
    Private Function ValidacionDeCampos() As Boolean
        Dim flg As Boolean = True
        Dim msg As String = ""

        'Quito espacio en blanco a TextBox
        For Each o As Object In gbIdentidad.Controls
            If TypeOf o Is TextBox Then
                Dim txt As TextBox = CType(o, TextBox)
                txt.Text = txt.Text.Trim
            End If
        Next
        'Familias Estadisticas
        If flg AndAlso cboFamilia1.SelectedValue.ToString.Trim = "" Then
            flg = False
            msg = "Falta seleccionar Familia Estadistica 1"
        End If
        If flg AndAlso cboFamilia2.SelectedValue.ToString.Trim = "" Then
            flg = False
            msg = "Falta seleccionar Familia Estadistica 2"
        End If
        If flg AndAlso cboFamilia3.SelectedValue.ToString.Trim = "" Then
            flg = False
            msg = "Falta seleccionar Familia Estadistica 3"
        End If
        'Identidad
        If flg AndAlso txtCodigoCliente.Text = "" Then
            flg = False
            msg = "El codigo de cliente no puede estar vacío"
        End If
        If flg AndAlso txtCodigoPagador.Text = "" Then
            flg = False
            msg = "El codigo de tercero pagador no puede estar vacío"
        End If
        If flg AndAlso txtNombre.Text = "" Then
            flg = False
            msg = "El nombre del cliente no puede estar vacío"
        End If
        If flg AndAlso txtNumDoc.Text = "" And cboTipoDoc.SelectedValue.ToString <> "99" Then
            flg = False
            msg = "Falta completar número de DNI/CUIT/CUIL"
        End If
        If flg AndAlso cboIva.SelectedValue.ToString = "RI" AndAlso cboCondicionIb.SelectedValue.ToString = "0" Then
            flg = False
            msg = "Condición de IB requerida para RI"
        End If
        If flg AndAlso txtIIBB.Text = "" And cboCondicionIb.SelectedValue.ToString.IndexOf("12") > -1 Then
            flg = False
            msg = "El número de IIBB es requerido"
        End If
        If flg AndAlso cboCondicionPago.SelectedValue.ToString.Trim = "" Then
            flg = False
            msg = "Falta seleccionar Condición de Pago"
        ElseIf flg AndAlso cboCondicionPago.SelectedValue.ToString = "062" Then
            flg = False
            msg = "Condición de pago no permitida"
        End If
        If flg AndAlso cboVendedor.SelectedValue.ToString.Trim = "" Then
            flg = False
            msg = "Debe seleccionar un vendedor"
        End If
        'Controla que el tipo de responsable sea compatible con el tipo de documento (CUIT, DNI, etc)
        If flg Then
            Select Case cboIva.SelectedValue.ToString
                Case "CF"
                    'Select Case cboTipoDoc.SelectedValue.ToString
                    '    Case "86", "96", "99"
                    '    Case Else
                    '        flg = False
                    '        msg = "Tipo de Responsable incompatible con tipo de documento"
                    'End Select

                Case Else
                    'No Consumidores finales deben tener CUIT
                    If cboTipoDoc.SelectedValue.ToString <> "80" Then
                        flg = False
                        msg = "Tipo de Responsable incompatible con tipo de documento"
                    End If

            End Select
        End If

        If flg AndAlso chkRequiereFactura.Checked = False AndAlso txtMailFc.Text = "" Then
            flg = False
            msg = "Mail obligatorio de Requiere Factura Fisica está desactivado"
        End If

        If flg AndAlso txtCodigoCliente.Text <> txtCodigoPagador.Text Then
            Dim pyr As New Cliente(cn)
            If pyr.Abrir(txtCodigoPagador.Text) Then
                If pyr.Vendedor1Codigo <> cboVendedor.SelectedValue.ToString Then
                    flg = False
                    msg = "Tercero Pagador no pertenece al vendedor seleccionado"
                End If
            End If
            pyr.Dispose()
        End If

        If flg AndAlso bpc.Sucursales.Count = 0 Then
            flg = False
            msg = "Al menos debe existir una sucursal"
        End If

        'Muestro mensaje de error
        If Not flg Then MessageBox.Show(msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)

        Return flg

    End Function

    Private Sub btnProponer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProponer.Click
        If cboFamilia2.SelectedValue.ToString = " " Then
            MessageBox.Show("Debe seleccionar un tipo de cliente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            cboFamilia2.Focus()

        ElseIf txtCodigoCliente.Text.Trim <> "" Then
            MessageBox.Show("Ya existe un codigo de cliente cargado", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtCodigoCliente.Focus()

        Else
            Dim x As String

            With btnProponer
                x = .Text
                .Text = "Buscando..."
                txtCodigoCliente.Focus()
                .Enabled = False
                Me.UseWaitCursor = True
                Application.DoEvents()

                txtCodigoCliente.Text = ProponerSiguienteCodigo(cboFamilia2.SelectedValue.ToString)
                txtCodigoPagador.Text = txtCodigoCliente.Text
                txtNombre.Focus()

                Me.UseWaitCursor = False
                .Enabled = True
                .Text = x

            End With


        End If

    End Sub
    Private Sub btnRegistrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegistrar.Click

        If ValidacionDeCampos() Then
            With bpc
                .Codigo = txtCodigoCliente.Text
                .Pagador = txtCodigoPagador.Text
                .TerceroFactura = txtCodigoCliente.Text
                .TerceroGrupo = txtCodigoCliente.Text
                .Nombre = txtNombre.Text
                .Familia1 = cboFamilia1.SelectedValue.ToString
                .Familia2 = cboFamilia2.SelectedValue.ToString
                .Familia3 = cboFamilia3.SelectedValue.ToString
                .NombreFantasia = txtFantasia.Text
                .TipoDoc = cboTipoDoc.SelectedValue.ToString
                .CUIT = txtNumDoc.Text
                .CondicionIb = cboCondicionIb.SelectedValue.ToString
                .IIBB = txtIIBB.Text
                .MailFC = txtMailFc.Text.Trim
                .CondicionDePago = cboCondicionPago.SelectedValue.ToString
                .RegimenImpuesto = cboIva.SelectedValue.ToString
                .Vendedor1Codigo = cboVendedor.SelectedValue.ToString
                .Vendedor2Codigo = cboVendedor.SelectedValue.ToString
                .Vendedor3Codigo = "11"
                .CategoriaComision = CategoriaComsion()
                .Observaciones = txtObservaciones.Text
                .RequiereFacturaFisica = chkRequiereFactura.Checked
                bpc.Grabar()
            End With

            DialogResult = Windows.Forms.DialogResult.OK

            If CerrarAlGrabar Then
                Me.Close()
            Else
                MessageBox.Show("Grabación correcta", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        End If

    End Sub

    Private Sub txtCodigoCliente_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodigoCliente.Validating
        Dim txt As TextBox = CType(sender, TextBox)
        If txt.Text.Trim = "" Then Exit Sub

        If Not ValidarCodigoCliente(txt.Text) Then
            MessageBox.Show("Código inválido", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            e.Cancel = True
        End If

        If txt.Text <> bpc.Codigo AndAlso ExisteCliente(txt.Text.Trim) Then
            MessageBox.Show("Ya existe código de cliente " & txt.Text, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            e.Cancel = True
        End If

    End Sub
    Private Sub txtCodigoPagador_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodigoPagador.Validated
        If txtCodigoPagador.Text.Trim = "" Then
            txtNombrePagador.Clear()
            Exit Sub
        End If

        If txtCodigoPagador.Text <> txtCodigoCliente.Text Then
            If txtCodigoPagador.Tag Is Nothing OrElse txtCodigoPagador.Tag.ToString <> txtCodigoPagador.Text Then
                txtCodigoPagador.Tag = txtCodigoPagador.Text

                Dim bpc As New Cliente(cn)
                bpc.Abrir(txtCodigoPagador.Text)
                txtNombrePagador.Text = bpc.Nombre
                bpc.Dispose()

                txtNombrePagador.Visible = True
            End If

        Else
            txtNombrePagador.Visible = False
        End If

    End Sub
    Private Sub txtCodigoPagador_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodigoPagador.Validating
        Dim txt As TextBox = CType(sender, TextBox)
        If txt.Text.Trim = "" Then Exit Sub
        If txt.Text <> txtCodigoCliente.Text AndAlso ValidarCodigoCliente(txt.Text, True) = False Then
            MessageBox.Show("Codigo inválido", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            e.Cancel = True
        End If
    End Sub
    Private Sub txtNumDoc_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtNumDoc.Validating
        Dim txt As TextBox = CType(sender, TextBox)
        txt.Text = txt.Text.Trim
        If txt.Text = "" Then Exit Sub

        If Not ValidarDocumento() Then
            MessageBox.Show("Número inválido", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            e.Cancel = True

        Else
            'No se permite crear cliente con cuit duplicado
            Dim dt As DataTable = bpc.ExisteCuit(txt.Text)
            If dt.Rows.Count > 0 Then

                Dim t As String = "Ya existe un cliente con el número: " & txt.Text & vbCrLf & vbCrLf

                For Each dr As DataRow In dt.Rows
                    If dr("bpcnum_0").ToString <> txtCodigoCliente.Text Then e.Cancel = True

                    t &= dr("bpcnum_0").ToString & " - " & dr("bpcnam_0").ToString & vbCrLf
                Next

                If e.Cancel Then
                    MessageBox.Show(t, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If


            End If

        End If
    End Sub
    Private Sub txtIIBB_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtIIBB.Validating

    End Sub
    Private Sub txtMailFc_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtMailFc.Validating
        Dim txt As TextBox = CType(sender, TextBox)

        If txt.Text.Trim = "" Then Exit Sub

        If Not Utiles.ValidarMails(txt.Text) Then
            MessageBox.Show("Mail inválido", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            e.Cancel = True
        End If
    End Sub
    Private Function ValidarCodigoCliente(ByVal CodigoCliente As String, Optional ByVal ExisteCliente As Boolean = False) As Boolean
        'Verifico que el codig tenga 6 digitos
        CodigoCliente = CodigoCliente.Trim
        If CodigoCliente.Length <> 6 Then Return False
        'Verifico que el codigo sea numerico
        For i = 0 To CodigoCliente.Length - 1
            If Not IsNumeric(CodigoCliente.Substring(i, 1)) Then Return False
        Next

        'Chequeo que el cliente exista
        If ExisteCliente Then
            If Not Me.ExisteCliente(CodigoCliente) Then
                Return False
            End If
        End If

        Return True

    End Function
    Private Function ExisteCliente(ByVal CodigoCliente As String) As Boolean
        Dim bpc As New Cliente(cn)

        Return bpc.Abrir(CodigoCliente)

    End Function
    Private Function ValidarDocumento() As Boolean
        Select Case cboTipoDoc.SelectedValue.ToString
            Case "80", "86" 'CUIT - CUIL
                Return Cliente.CheckCuit(txtNumDoc.Text.Trim)

            Case "96" 'DNI
                Return Cliente.CheckDni(txtNumDoc.Text.Trim)

            Case "99" '
                Return txtNumDoc.Text.Trim = ""
        End Select
    End Function
    Private Sub btnAgregarSucursal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarSucursal.Click
        If txtCodigoCliente.Text.Trim = "" Then
            MessageBox.Show("Primero debe ingresar un número de cliente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        bpc.Codigo = txtCodigoCliente.Text
        txtCodigoCliente.ReadOnly = True

        Dim f As New AltaSucursal(bpc)
        f.ShowDialog(Me)

        If f.DialogResult = Windows.Forms.DialogResult.OK Then
            bpc.Sucursales.Add(f.Sucursal)
            VerificarTildes(f.Sucursal)
            f.Dispose()
            txtCodigoCliente.ReadOnly = True
        End If

    End Sub

    Private Sub btnEditarSucursal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditarSucursal.Click
        Dim f As AltaSucursal
        Dim bpa As Sucursal

        If dgv.SelectedRows.Count = 1 Then
            bpa = CType(dgv.SelectedRows(0).DataBoundItem, Sucursal)
            f = New AltaSucursal(bpc, bpa)

            f.ShowDialog(Me)

            If f.DialogResult = Windows.Forms.DialogResult.OK Then
                VerificarTildes(bpa)
            End If

        End If

    End Sub
    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
    Private Function CategoriaComsion() As Integer
        Dim i As Integer = 1

        'Devuelve el tipo de comisión dependiendo del vendedor y tipo de cliente
        Select Case cboVendedor.SelectedValue.ToString
            Case "01", "02", "04", "07", "11", "22", "23", "26"
                i = 12

            Case "03"
                If cboFamilia2.SelectedValue.ToString = "20" Then
                    i = 6
                Else
                    i = 1
                End If

            Case "05"
                If cboFamilia2.SelectedValue.ToString = "20" Then
                    i = 18
                Else
                    i = 17
                End If

            Case "06"
                If cboFamilia2.SelectedValue.ToString = "20" Then
                    i = 8
                Else
                    i = 3
                End If

            Case "08", "09", "13", "14"
                If cboFamilia2.SelectedValue.ToString = "20" Then
                    i = 7
                Else
                    i = 2
                End If

            Case "10", "17", "19"
                i = 20

            Case "12"
                i = 19

            Case "15"
                i = 16

            Case "16"
                i = 10

            Case "20", "21", "24", "27", "29", "30"
                i = 5

            Case "25"
                Select Case cboFamilia2.SelectedValue.ToString
                    Case "20"
                        i = 6

                    Case "50"
                        i = 4

                    Case Else
                        i = 1

                End Select

            Case "28"
                i = 21

            Case "18"
                i = 4

        End Select

        Return i

    End Function

    Private Sub EnlazarSucursales()

        If Not gbSucursales.Enabled Then Exit Sub

        dgv.DataSource = bpc.Sucursales

        For i = 0 To dgv.Columns.Count - 1
            Dim c As DataGridViewColumn = dgv.Columns(i)

            Select Case c.Name
                Case "Sucursal"
                    c.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

                Case "Direccion"
                    c.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

                Case "Ciudad"
                    c.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                Case Else
                    c.Visible = False

            End Select
        Next

    End Sub
    Private Sub VerificarTildes(ByVal Suc As Sucursal)
        If Suc.SucursalPrincipal = False And Suc.EntregaFactura = False Then Exit Sub

        'Marco la sucursal principal en el cliente
        bpc.SetSucursalPrincipal(Suc.Sucursal)

        For Each s As Sucursal In bpc.Sucursales
            If s.Sucursal = Suc.Sucursal Then Continue For

            If s.SucursalPrincipal And Suc.SucursalPrincipal Then
                s.SucursalPrincipal = False
            End If

            If s.EntregaFactura And Suc.EntregaFactura Then
                s.EntregaFactura = False
            End If
        Next
    End Sub
    Private Sub BloquearControles(ByVal Controles As GroupBox, ByVal Excluir As ArrayList)

        For Each o As Object In Controles.Controls
            'Controles que se permiten la edicion
            If Excluir.IndexOf(o) <> -1 Then Continue For

            'Deshabilito los controles
            If TypeOf o Is TextBox Then
                CType(o, TextBox).Enabled = False
                Continue For
            End If

            If TypeOf o Is ComboBox Then
                CType(o, ComboBox).Enabled = False
                Continue For
            End If

            If TypeOf o Is CheckBox Then
                CType(o, CheckBox).Enabled = False
                Continue For
            End If

            If TypeOf o Is Button Then
                CType(o, Button).Enabled = False
                Continue For
            End If

            If TypeOf o Is DataGridView Then
                CType(o, DataGridView).Enabled = False
                Continue For
            End If
        Next
    End Sub
    Public Sub BloquearEdicionDeCampos()
        'Controles que se permiten editar
        Dim c As New ArrayList
        c.Add(btnRegistrar)
        c.Add(btnSalir)
        c.Add(cboCondicionIb)
        c.Add(txtIIBB)
        c.Add(txtObservaciones)
        c.Add(txtFantasia)
        c.Add(txtMailFc)
        c.Add(btnAgregarSucursal)

        For Each o As Object In Me.Controls
            If TypeOf o Is GroupBox Then BloquearControles(CType(o, GroupBox), c)
        Next

    End Sub

End Class