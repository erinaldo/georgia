Imports System.Data.OracleClient
Imports WSAFIP
Imports System.IO

Public Class frmSucursal
    Private bpc As Cliente
    Private bpa As Sucursal
    Private puc As PadronAfip = Nothing

    'Array de Provincia
    Private Provincias(24) As String

    'Usada cuando se edita un registro que debe ser actualizado al registrar y cerrar la ventana
    Public GrabarAlSalir As Boolean = False

    Public Sub New(ByVal bpc As Cliente, Optional ByVal puc As PadronAfip = Nothing)
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.bpc = bpc


        If bpc.Sucursales.Count = 0 Then
            chkPrincipal.Checked = True
            chkPrincipal.Enabled = False
            chkEntrega.Checked = True
            chkEntrega.Enabled = False
            txtNombreSucursal.Text = "PRINCIPAL"
        End If
        txtCodigoSucursal.Text = bpc.Sucursales.SiguienteCodigoSucursal

        bpa = New Sucursal(cn)
        bpa.Nuevo(bpc.Codigo)

        Me.puc = puc

    End Sub
    Public Sub New(ByVal bpc As Cliente, ByVal bpa As Sucursal)
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.bpc = bpc
        Me.bpa = bpa

    End Sub
    Private Sub AltaSucursal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim tb As TablaVaria

        Provincias(0) = "CFE"
        Provincias(1) = "BUE"
        Provincias(2) = "CTC"
        Provincias(3) = "CBA"
        Provincias(4) = "COR"
        Provincias(5) = "ERI"
        Provincias(6) = "JJY"
        Provincias(7) = "MDZ"
        Provincias(8) = "LRJ"
        Provincias(9) = "SLA"
        Provincias(10) = "SJN"
        Provincias(11) = "SLS"
        Provincias(12) = "SFE"
        Provincias(13) = "SDE"
        Provincias(14) = "TUC"
        Provincias(16) = "CHA"
        Provincias(17) = "CHU"
        Provincias(18) = "FMA"
        Provincias(19) = "MIS"
        Provincias(20) = "NQN"
        Provincias(21) = "LPA"
        Provincias(22) = "RNG"
        Provincias(23) = "SCZ"
        Provincias(24) = "TDF"


        'Enlace de ComboBox de Provincias
        tb = New TablaVaria(cn, 364, True)
        tb.EnlazarComboBox(cboProvincia)

        'Enlace de ComboBox Callejero GCBA
        cboGcba.DataSource = GCBA()
        cboGcba.ValueMember = "calle_0"
        cboGcba.DisplayMember = "nombre_0"
        cboGcba.SelectedValue = 0

        If bpa.Sucursal.Trim <> "" Then
            MostrarDatos()

            If cboProvincia.SelectedValue.ToString = "CFE" Then
                cboGcba.Enabled = True
                txtAltura.Enabled = True
            End If
        End If

        EstadoControles()

    End Sub
    Private Sub MostrarDatos()
        With bpa
            txtCodigoSucursal.Text = .Sucursal.Trim
            txtNombreSucursal.Text = .Nombre.Trim

            'No se permite deschequear
            chkPrincipal.Checked = bpa.SucursalPrincipal
            chkPrincipal.Enabled = Not chkPrincipal.Checked
            chkEntrega.Checked = bpa.EntregaFactura
            chkEntrega.Enabled = Not chkEntrega.Checked

            cboProvincia.SelectedValue = .Provincia
            txtCiudad.Text = .Ciudad.Trim
            txtCp.Text = .CodigoPostal.Trim
            cboGcba.SelectedValue = .CallejeroGCBA
            txtAltura.Text = .AlturaGCBA.ToString.Trim
            txtDireccion.Text = .Direccion.Trim
            txtTelefono.Text = .Telefono.Trim
            txtMail.Text = .Mail.Trim
            txtMailFc.Text = .MailFC.Trim
            txtExpreso.Text = .Expreso.Trim
            txtNombreContacto.Text = .Portero.Trim
            txtTelefonoContacto.Text = .Telefono_Portero.Trim
            txtFranja1Desde.Text = bpa.TurnoMananaDesde.Trim
            txtFranja1Hasta.Text = bpa.TurnoMananaHasta.Trim
            txtFranja2Desde.Text = bpa.TurnoTardeDesde.Trim
            txtFranja2Hasta.Text = bpa.TurnoTardeHasta.Trim

            chkLun.Checked = bpa.AtencionLunes
            chkMar.Checked = bpa.AtencionMartes
            chkMie.Checked = bpa.AtencionMiercoles
            chkJue.Checked = bpa.AtencionJueves
            chkVie.Checked = bpa.AtencionViernes
            chkSab.Checked = bpa.AtencionSabado

        End With

    End Sub
    Private Sub EstadoControles()
        txtMailFc.Enabled = bpc IsNot Nothing AndAlso bpc.Tipo = 1
        txtExpreso.Enabled = bpc IsNot Nothing AndAlso bpc.Tipo = 1
        gbTildes.Enabled = bpc IsNot Nothing AndAlso bpc.Tipo = 1
        gbHorarios.Enabled = bpc IsNot Nothing AndAlso bpc.Tipo = 1
        gbDias.Enabled = bpc IsNot Nothing AndAlso bpc.Tipo = 1
    End Sub
    Private Function GCBA() As DataTable
        Dim da As OracleDataAdapter
        Dim dt As New DataTable
        Dim sql As String = "SELECT * FROM xcallejero ORDER BY nombre_0"
        da = New OracleDataAdapter(sql, cn)
        da.Fill(dt)

        Dim dr As DataRow = dt.NewRow
        dr(0) = 0
        dr(1) = " "
        dr(2) = 0
        dr(3) = 0
        dt.Rows.InsertAt(dr, 0)

        Return dt

    End Function
    Private Function Validar() As Boolean
        Dim txt As String = ""
        Dim flg As Boolean = True

        If flg AndAlso txtNombreSucursal.Text.Trim = "" Then
            txt = "Falta completar el nombre de sucursal"
            txtNombreContacto.Focus()
            flg = False
        End If
        If flg AndAlso cboProvincia.SelectedValue.ToString.Trim = "" Then
            txt = "Falta seleccionar la provincia"
            cboProvincia.Focus()
            flg = False
        End If
        If flg AndAlso txtCiudad.Text.Trim = "" Then
            txt = "Falta completar la ciudad"
            txtCiudad.Focus()
            flg = False
        End If
        If flg AndAlso txtCp.Text.Trim = "" Then
            txt = "Falta completar código postal"
            txtCp.Focus()
            flg = False
        End If
        If flg AndAlso cboProvincia.SelectedValue.ToString = "CFE" AndAlso CInt(cboGcba.SelectedValue) = 0 Then
            cboGcba.Focus()
            txt = "Falta seleccionar la calle en el callejero GCBA"
            flg = False
        End If
        If flg AndAlso cboProvincia.SelectedValue.ToString = "CFE" AndAlso txtAltura.ToString.Trim = "" Then
            txt = "Falta seleccionar la altura en el callejero GCBA"
            txtAltura.Focus()
            flg = False
        End If
        If flg AndAlso txtDireccion.Text.Trim = "" Then
            txt = "Falta completar el domicilio"
            txtDireccion.Focus()
            flg = False
        End If
        'If flg AndAlso Not Utiles.ValidarTelefono(txtTelefono.Text) Then
        '    txt = "Falta completar teléfono o es inválido"
        '    txtTelefono.Focus()
        '    flg = False
        'End If

        '--
        If bpc.Tipo = 1 Then


            If flg AndAlso txtNombreContacto.Text.Trim = "" Then
                txt = "Falta completar nombre del contacto"
                txtNombreContacto.Focus()
                flg = False
            End If
            If flg AndAlso Not Utiles.ValidarTelefono(txtTelefonoContacto.Text) Then
                txt = "Falta completar teléfono del contacto o es inválido"
                txtTelefonoContacto.Focus()
                flg = False
            End If

            If flg AndAlso Not ValidarHora(txtFranja1Desde.Text) Then
                txt = "Hora inválida"
                txtFranja1Desde.Focus()
                flg = False
            End If
            If flg AndAlso Not ValidarHora(txtFranja1Hasta.Text) Then
                txt = "Hora inválida"
                txtFranja1Hasta.Focus()
                flg = False
            End If
            If flg AndAlso Not ValidarHora(txtFranja2Desde.Text) Then
                txt = "Hora inválida"
                txtFranja2Desde.Focus()
                flg = False
            End If
            If flg AndAlso Not ValidarHora(txtFranja2Hasta.Text) Then
                txt = "Hora inválida"
                txtFranja2Hasta.Focus()
                flg = False
            End If
            'Al menos una franja horaria
            If txtFranja1Desde.Text = "0000" AndAlso txtFranja1Hasta.Text = "0000" AndAlso _
               txtFranja2Desde.Text = "0000" AndAlso txtFranja2Hasta.Text = "0000" Then

                txt = "Al menos debe existir una franja horaria"
                flg = False
            End If
            'Validación de primer franja horaria
            If txtFranja1Desde.Text <> "0000" AndAlso txtFranja1Hasta.Text <> "0000" And _
               txtFranja1Desde.Text >= txtFranja1Hasta.Text Then

                txt = "Error en Franja Horaria 1"
                flg = False
            End If
            'Validación de segunda franja horaria
            If txtFranja2Desde.Text <> "0000" OrElse txtFranja2Hasta.Text <> "0000" Then
                If txtFranja1Hasta.Text < txtFranja2Desde.Text AndAlso txtFranja2Desde.Text < txtFranja2Hasta.Text Then
                    'ok
                Else
                    txt = "Error en Franja Horaria 2"
                    flg = False
                End If

            End If

            If flg AndAlso _
                chkLun.Checked = False AndAlso _
                chkMar.Checked = False AndAlso _
                chkMie.Checked = False AndAlso _
                chkJue.Checked = False AndAlso _
                chkVie.Checked = False Then

                txt = "Debe tildar al menos un dia de atención"
                flg = False

            End If
        End If

        If txt <> "" Then
            MessageBox.Show(txt, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

        Return flg

    End Function
    Private Sub cboProvincia_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboProvincia.SelectionChangeCommitted
        HabilitarCallejero()
    End Sub
    Private Sub HabilitarCallejero()
        If cboProvincia.SelectedValue.ToString = "CFE" Then
            txtCiudad.Text = "CAPITAL FEDERAL"
            txtAltura.Enabled = True
            cboGcba.Enabled = True

        Else
            txtCiudad.Clear()
            txtAltura.Enabled = False
            cboGcba.Enabled = False
            cboGcba.SelectedValue = " "

        End If
    End Sub
    Private Sub cboGcba_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboGcba.SelectionChangeCommitted
        CompletarCampoDireccion()
    End Sub
    Private Sub txtAltura_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAltura.LostFocus
        CompletarCampoDireccion()
    End Sub
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If Not Validar() Then Exit Sub

        With bpa

            .NombreCliente = bpc.Nombre
            .Sucursal = txtCodigoSucursal.Text.Trim
            .Nombre = txtNombreSucursal.Text
            .EntregaFactura = chkEntrega.Checked
            .SucursalPrincipal = chkPrincipal.Checked
            .Provincia = cboProvincia.SelectedValue.ToString
            .Ciudad = txtCiudad.Text
            .CodigoPostal = txtCp.Text
            If cboProvincia.SelectedValue.ToString = "CFE" Then
                .CallejeroGCBA = cboGcba.SelectedValue.ToString
                .AlturaGCBA = CInt(txtAltura.Text)
            End If
            .Direccion = txtDireccion.Text
            .Telefono = txtTelefono.Text
            .Mail = txtMail.Text
            .MailFC = txtMailFc.Text
            .Expreso = txtExpreso.Text
            .Portero = txtNombreContacto.Text
            .Telefono_Portero = txtTelefonoContacto.Text
            .TurnoMananaDesde = txtFranja1Desde.Text
            .TurnoMananaHasta = txtFranja1Hasta.Text
            .TurnoTardeDesde = txtFranja2Desde.Text
            .TurnoTardeHasta = txtFranja2Hasta.Text

            .AtencionLunes = chkLun.Checked
            .AtencionMartes = chkMar.Checked
            .AtencionMiercoles = chkMie.Checked
            .AtencionJueves = chkJue.Checked
            .AtencionViernes = chkVie.Checked
            .AtencionSabado = chkSab.Checked

            If GrabarAlSalir Then .Grabar()

        End With

        DialogResult = Windows.Forms.DialogResult.OK

        Me.Close()
    End Sub
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub CompletarCampoDireccion()
        'Completa el campo Dirección con la calle y altura seleccionado en el Callejero GCBA

        'El ComboBox callejero debe tener un valor seleccionado
        If cboGcba.SelectedValue.ToString = " " Then Exit Sub

        'El Campo de Altura del callejero debe tener un valor
        If txtAltura.Text.Trim = "" Then Exit Sub

        'Se completa el campo domicilio
        Dim dr As DataRow

        dr = CType(cboGcba.SelectedItem, DataRowView).Row
        txtDireccion.Text = dr("nombre_0").ToString
        txtDireccion.Text &= " " & txtAltura.Text

    End Sub
    Public ReadOnly Property Sucursal() As Sucursal
        Get
            Return bpa
        End Get
    End Property
    Private Sub txtTelefonoContacto_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtTelefonoContacto.Validating
        Dim txt As TextBox = CType(sender, TextBox)

        If txt.Text.Trim = "" Then Exit Sub
        If Not Utiles.ValidarTelefono(txt.Text) Then
            MessageBox.Show("Teléfono inválido", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            e.Cancel = True
        End If

    End Sub
    Private Sub txtMail_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtMail.Validating, txtMailFc.Validating
        Dim txt As TextBox = CType(sender, TextBox)

        If txt.Text.Trim = "" Then Exit Sub

        If Not Utiles.ValidarMails(txt.Text) Then
            MessageBox.Show("Mail inválido", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            e.Cancel = True
        End If

    End Sub
    Private Sub txtFranja1Desde_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtFranja1Desde.Validating, _
                                                                                                                             txtFranja1Hasta.Validating, _
                                                                                                                             txtFranja2Desde.Validating, _
                                                                                                                             txtFranja2Hasta.Validating

        Dim txt As TextBox = CType(sender, TextBox)

        If txt.Text.Trim = "" Then Exit Sub

        If Not ValidarHora(txt.Text) Then
            MessageBox.Show("Hora inválida", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            e.Cancel = True
        End If

    End Sub
    Private Sub txtFranja1Desde_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFranja1Desde.Validated, _
                                                                                                       txtFranja1Hasta.Validated, _
                                                                                                       txtFranja2Desde.Validated, _
                                                                                                       txtFranja2Hasta.Validated
        Dim txt As TextBox = CType(sender, TextBox)

        If txt.Text.Trim = "" Then txt.Text = "0000"

    End Sub
    Private Sub txtCp_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCp.Validating
        Dim txt As TextBox = CType(sender, TextBox)

        If txt.Text.Trim = "" Then Exit Sub

        If Not Utiles.ValidarCP(txt.Text) Then
            MessageBox.Show("Código inválido", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            e.Cancel = True
        End If
    End Sub
    Private Sub cboGcba_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboGcba.Validating

        e.Cancel = IsNothing(cboGcba.SelectedValue)

    End Sub
    Private Sub txtExpreso_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtExpreso.KeyUp
        If e.KeyCode = Keys.F12 Then AbrirSelectorExpresos()
    End Sub
    Private Sub txtExpreso_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtExpreso.Validated
        With txtExpreso
            If .Text.Trim = "" Then txtNombreExpreso.Clear()
        End With
    End Sub
    Private Sub txtExpreso_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtExpreso.Validating
        Dim exp As New Expreso(cn)

        With txtExpreso
            If .Text.Trim <> "" Then
                If exp.Abrir(.Text.Trim) Then
                    txtNombreExpreso.Text = exp.Nombre
                Else
                    MessageBox.Show("Expreso no encontrado", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    e.Cancel = True
                End If
            End If
        End With
    End Sub
    Private Sub AbrirSelectorExpresos()
        Dim f As New frmSelectorExpreso()

        f.ShowDialog()

        If f.DialogResult = Windows.Forms.DialogResult.OK Then
            txtExpreso.Text = f.Seleccion
        End If
        f.Dispose()

    End Sub
    Private Sub mnuSeleccionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSeleccionar.Click
        AbrirSelectorExpresos()
    End Sub

    Private Sub btnAuto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAuto.Click
        On Error Resume Next

        If puc Is Nothing AndAlso bpc.TipoDoc = "80" Then ConsultarPadron(CLng(bpc.CUIT))

        If puc.SucursalFiscal IsNot Nothing Then
            
            With puc.SucursalFiscal
                cboProvincia.SelectedValue = Provincias(.idProvincia)
                txtCiudad.Text = .localidad
                txtCp.Text = .codPostal
                txtDireccion.Text = .direccion
            End With

            HabilitarCallejero()

        End If

    End Sub
    Private Function ConsultarPadron(ByVal Cuit As Long) As Boolean
        Dim wsas As ServidorAutorizacion
        Dim ta As Ticket = Nothing
        Dim Path As String = "CERTIFICADOS\"
        Dim NombreTicket As String = ""
        Dim NombreCertificado As String = ""

        NombreTicket = "puc_dny.xml"
        NombreCertificado = "dny.p12"

        If File.Exists(NombreTicket) Then
            ta = New Ticket
            ta.Load(NombreTicket)
        End If

        'Pido nuevo ticket al servidor de afip
        If ta Is Nothing OrElse ta.ExpirationTime <= Now Then

            Try
                wsas = New ServidorAutorizacion(Path & NombreCertificado, "1234")

                ta = wsas.SolicitarTicket("ws_sr_padron_a4")

                If ta IsNot Nothing Then
                    ta.Save(NombreTicket)

                End If

            Catch ex As Exception
                ta = Nothing
                Return False

            End Try

        End If

        Try
            If ta IsNot Nothing Then

                puc = New PadronAfip(ta, 20255807308)
                puc.Consultar(Cuit)

            End If

        Catch ex As Exception
            Return False

        End Try

        Return True

    End Function

    Private Sub txtAltura_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtAltura.Validating
        Dim txt As TextBox = CType(sender, TextBox)
        Dim flg As Boolean = False

        txt.Text = txt.Text.Trim

        For i = 0 To txt.Text.Length - 1
            If Not IsNumeric(txt.Text.Substring(i, 1)) Then
                flg = True
                Exit For
            End If
        Next

        If flg Then
            MessageBox.Show("Valor inválido. Sólo números", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

        e.Cancel = flg

    End Sub

   
End Class