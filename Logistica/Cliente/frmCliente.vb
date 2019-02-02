Imports System.Data.OracleClient
Imports System.Collections
Imports WSAFIP
Imports System.IO

Public Class frmCliente
    Private CerrarAlGrabar As Boolean = False
    Private bpc As Cliente = Nothing

    Public NUEVO_CLIENTE As Boolean = False
    Public NUEVO_PROSPECTO As Boolean = False
    Public CONVERTIR As Boolean = False
    Public BUSCAR As Boolean = False
    Private mail As New CorreoElectronico

    'Private puc As PadronAfip

    Public Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        NUEVO_PROSPECTO = True

        If usr.PermisoAltaCliente > 1 Then
            NUEVO_CLIENTE = True
            CONVERTIR = True
            BUSCAR = True
        End If

    End Sub
    Public Sub New(ByVal bpc As Cliente)
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.bpc = bpc

        CerrarAlGrabar = True

    End Sub
    Public Sub New(ByVal Codigo As String)
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
        Dim mnu As MenuLocal

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

        'Sociedad de facturacion para el cliente
        Sociedad.Sociedades(cn, cboSociedad, True)

        'Combo Categoria ABC
        mnu = New MenuLocal(cn)
        mnu.AbrirMenu(212, False)
        mnu.Enlazar(cboABC)

        'Carga los campos de pantalla con los datos del cliente actual
        MostrarDatosCliente()

        EstadoControles()

        If usr.PermisoAltaCliente = 3 Then
            chkActivo.Enabled = False
        Else
            chkActivo.Enabled = True
        End If

    End Sub
    Private Sub AbrirCliente(ByVal Codigo As String)
        If bpc Is Nothing Then bpc = New Cliente(cn)
        bpc.Abrir(Codigo)

        EstadoControles()
        MostrarDatosCliente()
    End Sub
    Private Sub MostrarDatosCliente()
        If bpc Is Nothing Then Exit Sub

        chkActivo.Checked = bpc.Activo

        cboFamilia1.SelectedValue = bpc.Familia1
        cboFamilia2.SelectedValue = bpc.Familia2
        cboFamilia3.SelectedValue = bpc.Familia3
        txtCodigoCliente.Text = bpc.Codigo.Trim
        'Deshabilito el campo si es edicion de cliente
        'txtCodigoCliente.ReadOnly = (bpc.Codigo.Trim <> "")
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

        cboSociedad.SelectedValue = bpc.EmpresaFacturacionObligatoria

        cboABC.SelectedValue = bpc.TipoAbc

        'Enlace de la grilla de sucursales
        EnlazarSucursales()

    End Sub
    Private Sub Nuevo(ByVal TipoCliente As Integer)
        'puc = Nothing

        bpc = New Cliente(cn)
        bpc.Nuevo(TipoCliente)
        bpc.Tipo = TipoCliente
        bpc.EsCliente = TipoCliente = 1
        bpc.EsProspecto = TipoCliente = 4
        bpc.Activo = bpc.Tipo = 4

        EstadoControles()
        MostrarDatosCliente()

        lblIb.Text = "IIBB"
    End Sub
    'Function
    Private Function ProponerSiguienteCodigo(ByVal Tipo As String) As String
        Dim da As OracleDataAdapter
        Dim dt As New DataTable
        Dim dv As DataView
        Dim sql As String = "SELECT bprnum_0 FROM bpartner"
        Dim j, i As Integer
        Dim s As String = ""

        da = New OracleDataAdapter(sql, cn)
        da.Fill(dt)
        da.Dispose()

        dv = New DataView(dt)

        Select Case Tipo
            Case "10"
                Tipo = "102022"
            Case "11"
                Tipo = "118879"
            Case "20"
                Tipo = "201238"
            Case "40"
                Tipo = "407144"
            Case "50"
                Tipo = "501620"
            Case "60"
                Tipo = "616541"
            Case "80"
                Tipo = "803896"
        End Select

        Tipo = Strings.Left(Tipo & "000000", 6)
        j = CInt(Tipo)

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
        Dim AltaCompleta As Boolean = usr.PermisoAltaCliente <> 3

        'Quito espacio en blanco a TextBox
        For Each o As Object In gbIdentidad.Controls
            If TypeOf o Is TextBox Then
                Dim txt As TextBox = CType(o, TextBox)
                txt.Text = txt.Text.Trim
            End If
        Next
        'Familias Estadisticas
        If flg AndAlso bpc.Tipo = 1 AndAlso cboFamilia1.SelectedValue.ToString.Trim = "" Then
            flg = False
            msg = "Falta seleccionar Familia Estadistica 1"
        End If
        If flg AndAlso cboFamilia2.SelectedValue.ToString.Trim = "" Then
            flg = False
            msg = "Falta seleccionar Familia Estadistica 2"
        End If
        If flg AndAlso bpc.Tipo = 1 AndAlso cboFamilia3.SelectedValue.ToString.Trim = "" Then
            flg = False
            msg = "Falta seleccionar Familia Estadistica 3"
        End If
        If flg AndAlso txtNombre.Text = "" Then
            flg = False
            msg = "El nombre del cliente no puede estar vacío"
        End If
        If flg AndAlso cboVendedor.SelectedValue.ToString.Trim = "" Then
            flg = False
            msg = "Debe seleccionar un vendedor"
        End If
        'Controla que el tipo de responsable sea compatible con el tipo de documento (CUIT, DNI, etc)
        If bpc.Tipo = 1 AndAlso AltaCompleta Then
            If flg Then
                Select Case cboIva.SelectedValue.ToString
                    Case "CF"
                        Select Case cboTipoDoc.SelectedValue.ToString
                            Case "86", "96", "99"
                            Case Else
                                flg = False
                                msg = "Tipo de Responsable incompatible con tipo de documento"
                        End Select

                    Case Else
                        'No Consumidores finales deben tener CUIT
                        If cboTipoDoc.SelectedValue.ToString <> "80" Then
                            flg = False
                            msg = "Tipo de Responsable incompatible con tipo de documento"
                        End If

                End Select
            End If

            If flg AndAlso txtNumDoc.Text = "" And cboTipoDoc.SelectedValue.ToString <> "99" Then
                flg = False
                msg = "Falta completar número de DNI/CUIT/CUIL"
            End If

            If flg AndAlso cboIva.SelectedValue.ToString = "RI" AndAlso " 0".IndexOf(cboCondicionIb.SelectedValue.ToString) > -1 Then
                flg = False
                msg = "Falta ingresar Condición de IB"
            End If
            If flg AndAlso "124".IndexOf(cboCondicionIb.SelectedValue.ToString) > -1 And ValidarNumeroIB() = False Then
                flg = False
                msg = "La condición de IB o número de inscripción es incorrecta"
            End If
            If flg AndAlso cboCondicionPago.SelectedValue.ToString.Trim = "" Then
                flg = False
                msg = "Falta seleccionar Condición de Pago"
            ElseIf flg AndAlso cboCondicionPago.SelectedValue.ToString = "062" Then
                flg = False
                msg = "Condición de pago no permitida"
            End If
            If flg AndAlso chkRequiereFactura.Checked = False AndAlso txtMailFc.Text = "" Then
                flg = False
                msg = "Mail obligatorio si Requiere Factura Fisica está desactivado"
                txtMailFc.Focus()
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
        End If

        If flg AndAlso AltaCompleta AndAlso bpc.Sucursales.Count = 0 Then
            flg = False
            msg = "Al menos debe existir una sucursal"
        End If

        If cboSociedad.SelectedValue.ToString = "GRU" Then
            flg = False
            msg = "Sociedad de facturación no permitida"
            cboSociedad.Focus()
        End If

        'Muestro mensaje de error
        If Not flg Then MessageBox.Show(msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)

        Return flg

    End Function
    Private Sub btnRegistrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegistrar.Click

        If ValidacionDeCampos() Then
            lblEspere.Visible = True
            lblEspere.BringToFront()
            Me.UseWaitCursor = True
            Application.DoEvents()
            Application.DoEvents()

            If txtCodigoCliente.Text.Trim = "" Then
                txtCodigoCliente.Text = ProponerSiguienteCodigo(cboFamilia2.SelectedValue.ToString)
                'Pasar codigo a sucursales
                For Each suc As Sucursal In bpc.Sucursales
                    suc.Codigo = txtCodigoCliente.Text
                    suc.NombreCliente = txtNombre.Text
                Next
            End If

            If txtCodigoPagador.Text.Trim = "" AndAlso bpc.Tipo = 1 Then
                txtCodigoPagador.Text = txtCodigoCliente.Text
            End If

            With bpc
                .Activo = chkActivo.Checked

                .Codigo = txtCodigoCliente.Text
                If .Tipo = 1 Then
                    .Pagador = txtCodigoPagador.Text
                    .TerceroFactura = txtCodigoCliente.Text
                    .TerceroGrupoCodigo = txtCodigoCliente.Text
                End If
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
                .EmpresaFacturacionObligatoria = cboSociedad.SelectedValue.ToString
                .TipoAbc = CInt(cboABC.SelectedValue)

                'Alicuotas de IB
                If bpc.Tipo = 1 AndAlso Not bpc.Percepciones.Existe("CFE") And .TipoDoc = "80" Then
                    Dim p As New Padron(cn)
                    'Flag usado para determinar si se le debe cargar el impuesto al cliente
                    Dim AgregarImpuesto As Boolean = False

                    If p.Buscar(.CUIT) Then
                        'Se encontró el cuit en el padron 
                        AgregarImpuesto = True
                    Else
                        'Al no encontrarse el cuit en el padron, puede tratarse de un contribuyente local
                        'en jurisdiccion ajena. Se recorren todas las sucursales y se carga el impuesto 
                        'solo si se encuentra una sucursal en CFE
                        For Each s As Sucursal In bpc.Sucursales
                            If s.Provincia = "CFE" Then
                                AgregarImpuesto = True
                                Exit For
                            End If
                        Next

                    End If

                    If AgregarImpuesto Then
                        lblIb.Text = "IIBB (Alícuota: " & p.AlicuotaPercepcion.ToString("N2") & "%)"
                        bpc.Percepciones.Agregar("CFE", p.AlicuotaPercepcion, p.PercepcionDesde, p.PercepcionHasta)
                        bpc.Percepciones.Grabar()
                    End If

                End If

                bpc.Grabar()

            End With

            DialogResult = Windows.Forms.DialogResult.OK

            lblEspere.Visible = False
            Me.UseWaitCursor = False
            Application.DoEvents()

            EstadoControles()
            If CerrarAlGrabar Then Me.Close()
            If usr.PermisoAltaCliente = 3 Then EnviarMail()
        End If

    End Sub
    Private Sub EnviarMail()
        With mail
            .Nuevo()
            .Remitente("noreply@matafuegosgeorgia.com", "Matafuegos Georgia")
            .AgregarDestinatarioArchivo("mails\CreacionCliente.txt", 0)
            .Asunto = "Se creo un nuevo cliente"
            .EsHtml = False
            .Cuerpo = usr.Nombre & " creo un nuevo cliente: " & bpc.Codigo & " - " & bpc.Nombre & ", el mismo no esta activo, por favor, completar y activar."
            .Enviar()
        End With
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

    Private Sub txtNumDoc_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumDoc.Validated
        'Consulto cuit

        'If txtCodigoCliente.Text = "" And cboTipoDoc.SelectedValue.ToString = "80" Then
        '    If ConsultarPadron(CLng(txtNumDoc.Text)) Then
        '        txtNombre.Text = Strings.Left(puc.RazonSocial, 35)
        '        cboIva.SelectedValue = puc.CondicionIva
        '    End If
        'End If

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

        If bpc.Sucursales.Count < 410 Then
            Dim f As New frmSucursal(bpc)
            f.ShowDialog(Me)

            If f.DialogResult = Windows.Forms.DialogResult.OK Then
                bpc.Sucursales.Add(f.Sucursal)
                VerificarTildes(f.Sucursal)
                f.Dispose()
            End If

        Else
            MessageBox.Show("Se alcanzó la cantidad máxima de sucursales", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)

        End If
    End Sub
    Private Sub btnEditarSucursal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditarSucursal.Click
        Dim f As frmSucursal
        Dim bpa As Sucursal

        If dgv.SelectedRows.Count = 1 Then
            bpa = CType(dgv.SelectedRows(0).DataBoundItem, Sucursal)

            f = New frmSucursal(bpc, bpa)
            f.btnAuto.Visible = False

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

            Case "03" 'Adrian Minuet
                If cboFamilia2.SelectedValue.ToString = "20" Then
                    i = 6 'Comun Distribuidor
                Else
                    i = 1 'Común
                End If

            Case "05" 'Patricio Reilly
                If cboFamilia2.SelectedValue.ToString = "20" Then
                    i = 18 ' Patricio Distribuidor
                Else
                    i = 17 'Patricio
                End If

            Case "06" 'Ignacio Szapiro
                i = 8 'Ignacio Distribuidor

            Case "08" 'Silvana Caracini
                If cboFamilia2.SelectedValue.ToString = "20" Then
                    i = 7 'Administraciones Distribuidor
                Else
                    i = 2 'Administraciones
                End If

            Case "12"
                i = 19 'Andres B

            Case "13" 'Susana Ortega
                If cboFamilia2.SelectedValue.ToString = "20" Then
                    i = 7 'Administraciones Distribuidor
                Else
                    i = 2 'Administraciones
                End If

            Case "14" 'Rosario Tomagra
                If cboFamilia2.SelectedValue.ToString = "20" Then
                    i = 7 'Administraciones Distribuidor
                Else
                    i = 2 'Administraciones
                End If

            Case "15"
                i = 16 'Hector Regueiro

            Case "16"
                i = 10 'Nuevo vendedores

            Case "17" 'Daniel Vernik
                i = 12

            Case "19" 'Monica Ferrari
                i = 20

            Case "CA", "CAA"
                i = 12

            Case "22"
                i = 12

            Case "23"
                i = 12

            Case "24"
                i = 13 'Distribuidores

            Case "25"
                Select Case cboFamilia2.SelectedValue.ToString
                    Case "20"
                        i = 6 'Común Distribuidor

                    Case "50"
                        i = 4 'Licit/ SA

                    Case Else
                        i = 1 'Común

                End Select

            Case "27" 'Fabiana Monzalve
                Select Case cboFamilia2.SelectedValue.ToString
                    Case "10", "11"
                        i = 13 'Distribuidores

                    Case Else
                        i = 11 'Fabiana M.

                End Select

            Case "28" 'Jaim
                i = 21 'Mercadolibre

            Case "30" 'Luciana Rodriguez
                i = 13

            Case "32" 'Gabiel Viñas
                i = 13

            Case "33" 'Federico Henze
                i = 3

            Case Else
                i = 12

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
        c.Add(chkRequiereFactura)
        c.Add(dgv)

        For Each o As Object In Me.Controls
            If TypeOf o Is GroupBox Then BloquearControles(CType(o, GroupBox), c)
        Next

    End Sub
    Private Sub EstadoControles()

        For Each o As Object In Me.Controls
            If TypeOf o Is GroupBox Then
                CType(o, GroupBox).Enabled = bpc IsNot Nothing
            End If
        Next

        cboFamilia1.Enabled = bpc IsNot Nothing AndAlso bpc.Tipo = 1
        cboFamilia3.Enabled = bpc IsNot Nothing AndAlso bpc.Tipo = 1
        cboTipoDoc.Enabled = bpc IsNot Nothing
        txtNumDoc.Enabled = bpc IsNot Nothing
        txtCodigoPagador.Enabled = bpc IsNot Nothing AndAlso bpc.Tipo = 1
        cboCondicionIb.Enabled = bpc IsNot Nothing AndAlso bpc.Tipo = 1
        txtIIBB.Enabled = bpc IsNot Nothing AndAlso bpc.Tipo = 1
        cboCondicionPago.Enabled = bpc IsNot Nothing AndAlso bpc.Tipo = 1
        txtMailFc.Enabled = bpc IsNot Nothing AndAlso bpc.Tipo = 1
        chkRequiereFactura.Enabled = bpc IsNot Nothing AndAlso bpc.Tipo = 1
        cboSociedad.Enabled = bpc IsNot Nothing AndAlso bpc.Tipo = 1

        btnNuevoCliente.Enabled = NUEVO_CLIENTE
        btnNuevoProspecto.Enabled = NUEVO_PROSPECTO
        btnConvertir.Enabled = bpc IsNot Nothing AndAlso (bpc.Tipo = 4 AndAlso bpc.Codigo.Trim <> "") AndAlso CONVERTIR
        btnBuscar.Enabled = BUSCAR
        btnRegistrar.Enabled = bpc IsNot Nothing

        chkActivo.Enabled = usr.PermisoAltaCliente <> 3

    End Sub

    Private Sub btnNuevoCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevoCliente.Click
        Nuevo(1)
    End Sub
    Private Sub btnNuevoProspecto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevoProspecto.Click
        Nuevo(4)
    End Sub
    Private Sub btnConvertir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConvertir.Click
        bpc.ConvetirEnCliente()
        EstadoControles()
    End Sub
    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Dim f As New frmSelectorClientes

        f.ShowDialog()
        If f.DialogResult = Windows.Forms.DialogResult.OK Then
            AbrirCliente(f.ClienteSeleccionado)
        End If

    End Sub

    Private Function ValidarNumeroIB() As Boolean

        With txtIIBB

            'Quito espacios en blanco y guiones
            .Text = .Text.Replace(" ", "")
            .Text = .Text.Replace("-", "")

            'Verifico que todos los caracteres sea numeros
            For i = 0 To .Text.Length - 1
                If Not IsNumeric(.Text.Substring(i, 1)) Then
                    Return False
                End If
            Next

            Select Case cboCondicionIb.SelectedValue.ToString
                Case "1" 'Regimen General

                    If .Text.Length >= 6 And .Text.Length <= 9 Then
                        Return True
                    Else
                        Return False
                    End If

                Case "2" 'Convenio Multilateral

                    'Debe comenzar con 9 y tener longitud 11
                    If .Text.StartsWith("9") And .Text.Length = 11 Then
                        Return True

                    Else
                        Return False

                    End If

                Case "4" 'Otros

                    Return .Text.Trim = ""

                Case Else
                    Return True

            End Select
        End With


    End Function

End Class