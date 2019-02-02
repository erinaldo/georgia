Imports System.Data.OracleClient
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine

Public Class frmTicket
    Private tk As Ticket
    Private Modificado As Boolean = False

    Public Sub New(Optional ByVal NroTicket As Integer = 0)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Dim mnu As New MenuLocal(cn)
        mnu.AbrirMenu(9200, True)
        mnu.Enlazar(cboMotivos)

        mnu = New MenuLocal(cn)
        mnu.AbrirMenu(2409, False)
        mnu.ModificarTexto(1, "Abierto")
        mnu.ModificarTexto(2, "Resuelto")
        mnu.ModificarTexto(3, "Cerrado")
        mnu.Enlazar(cboEstado)

        CargarComboAsignar()

        tk = New Ticket(cn)

        If NroTicket = 0 Then
            tk.Nuevo()
        Else
            tk.Abrir(NroTicket)
        End If
        
        If dgv.DataSource Is Nothing Then
            colTicket.DataPropertyName = "nro_0"
            colLinea.DataPropertyName = "lig_0"
            colFecha.DataPropertyName = "dat_0"
            colHora.DataPropertyName = "hora_0"
            colUsuario.DataPropertyName = "usr_0"
            colComentarios.DataPropertyName = "msg_0"

            dgv.DataSource = tk.dt2

        End If

    End Sub
    Private Sub frmTicket_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If tk.Numero <> 0 Then
            MostrarDatos()
            Modificado = False
        End If

        EstadoControles()
    End Sub
    Private Sub CargarComboAsignar()
        Dim Sql As String
        Dim dr As DataRow
        Dim da As OracleDataAdapter
        Dim dt As New DataTable

        'Recupero todos los sectores que tienen usuario asignado para verlo
        Sql = "SELECT DISTINCT ident2_0 AS cod, texte_0 AS des "
        Sql &= "FROM atextra ate INNER JOIN "
        Sql &= "	 xtickets xts on (ident2_0 = xsector_0) "
        Sql &= "WHERE codfic_0 = 'ATABDIV' AND zone_0 = 'LNGDES' AND langue_0 = 'SPA' AND ident1_0 = 5004"
        da = New OracleDataAdapter(Sql, cn)
        da.Fill(dt)

        Sql = "SELECT usr_0 as cod, nomusr_0 as des "
        Sql &= "FROM autilis "
        Sql &= "WHERE xticket_0 = 2 "
        Sql &= "ORDER BY usr_0"
        da = New OracleDataAdapter(Sql, cn)
        da.Fill(dt)

        'agrego un registro en blanco al comienzo
        dr = dt.NewRow
        dr(0) = " "
        dr(1) = " "
        dt.Rows.InsertAt(dr, 0)

        With cboAsignar
            .DataSource = dt
            .DisplayMember = "des"
            .ValueMember = "cod"
        End With
    End Sub
    Private Sub txtCodigoCliente_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodigoCliente.LostFocus
        EstadoControles()
    End Sub
    Private Sub txtCodigoCliente_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodigoCliente.Validating
        Dim txt As TextBox = CType(sender, TextBox)
        Dim bpc As New Cliente(cn)

        If txt.Text.Trim = "" Then Exit Sub
        If txt.ReadOnly Then Exit Sub

        If bpc.Abrir(txtCodigoCliente.Text) Then
            txtNombreCliente.Text = bpc.Nombre
            txtTipoAbc.Text = bpc.TerceroGrupo.TipoAbcStr
            If bpc.Vendedor3Codigo <> "11" Then
                txtVendedorAnterior.Text = bpc.Vendedor3.Nombre
            End If

            txtVendedorActual.Text = bpc.Vendedor.Nombre

            Modificado = True

        Else
            MessageBox.Show("Codigo inválido", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            e.Cancel = True

        End If

    End Sub
    Private Sub txtCodigoSucursal_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodigoSucursal.LostFocus
        EstadoControles()
    End Sub
    Private Sub txtCodigoSucursal_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodigoSucursal.Validating
        Dim txt As TextBox = CType(sender, TextBox)

        If txt.Text.Trim = "" Then Exit Sub
        If txt.ReadOnly Then Exit Sub
        If txtCodigoCliente.Text.Trim = "" Then Exit Sub

        Dim bpc As New Cliente(cn)
        Dim bpa As Sucursal

        bpc.Abrir(txtCodigoCliente.Text)

        If bpc.ExisteSucursal(txtCodigoSucursal.Text.Trim) Then

            bpa = bpc.Sucursal(txtCodigoSucursal.Text.Trim)

            txtDomicilio.Text = bpa.Direccion

            EditarSucursal(bpc, bpa)

            'Buscar si existe otro ticket abierto
            BuscarTicketAbierto()

            Modificado = True

        Else
            MessageBox.Show("Codigo inválido", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            e.Cancel = True

        End If

        bpc = Nothing
        bpa = Nothing

    End Sub
    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Dim txt As String

        txt = "¿Confirma cerrar este ticket?"

        If MessageBox.Show(txt, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            tk.Estado = 3
            Grabar()
        End If
    End Sub
    Private Sub dgv_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellDoubleClick

        If e.RowIndex < 0 Then Exit Sub

        'salto si ticket está cerrado
        If tk.Estado = 3 Then Exit Sub

        'Obtengo el id del registro
        Dim dr As DataRow
        Dim f As frmComentario

        'Obtengo el registro a editar
        dr = CType(CType(dgv.Rows(e.RowIndex), DataGridViewRow).DataBoundItem, DataRowView).Row

        f = New frmComentario()
        f.txtComentario.Text = dr("msg_0").ToString
        f.ShowDialog()

        If f.DialogResult = Windows.Forms.DialogResult.OK Then

            dr.BeginEdit()
            dr("msg_0") = f.txtComentario.Text
            dr.EndEdit()

            tk.Grabar()

        End If

    End Sub
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub btnRegistrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegistrar.Click
        If Not ValidacionesOK() Then Exit Sub
        Grabar()
    End Sub
    Private Sub frmTicket_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim txt As String
        Dim res As DialogResult

        If Modificado Then
            txt = "¿Desea guardar las modificaciones?"

            res = MessageBox.Show(txt, Me.Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3)

            Select Case res
                Case Windows.Forms.DialogResult.Yes
                    tk.Grabar()
                    e.Cancel = False

                Case Windows.Forms.DialogResult.No
                    e.Cancel = False

                Case Windows.Forms.DialogResult.Cancel
                    e.Cancel = True

            End Select
        End If

    End Sub
    Private Sub txtObservaciones_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtObservaciones.TextChanged
        btnAgregarComentario.Enabled = txtObservaciones.Text.Trim.Length > 0
    End Sub
    Private Sub Abrir(ByVal NroTicket As Integer)
        tk.Abrir(NroTicket)
        Modificado = False

    End Sub
    Private Sub MostrarDatos()
        'Carga los datos del ticket en los controles del formulario
        txtTicketNumero.Text = tk.Numero.ToString
        txtFecha.Text = tk.Fecha.ToString("dd/MM/yyyy")
        txtHora.Text = tk.Hora
        txtAsignado.Text = tk.AsignadoA
        cboEstado.SelectedValue = tk.Estado
        cboMotivos.SelectedValue = tk.Tipo

        txtCodigoCliente.Text = tk.ClienteCodigo
        txtNombreCliente.Text = tk.Cliente.Nombre
        txtTipoAbc.Text = tk.Cliente.TerceroGrupo.TipoAbcStr
        txtVendedorAnterior.Text = tk.Cliente.Vendedor3.Nombre
        txtVendedorActual.Text = tk.Cliente.Vendedor.Nombre
        txtCodigoSucursal.Text = tk.SucursalCodigo
        txtDomicilio.Text = tk.Sucursal.Direccion

        txtContacto.Text = tk.Contacto.Trim
        txtTelefono.Text = tk.Telefono.Trim
        txtMail.Text = tk.Mail.Trim

        txtPedido1.Text = tk.Pedido(0)
        txtPedido2.Text = tk.Pedido(1)
        txtPedido3.Text = tk.Pedido(2)

        txtEntrega1.Text = tk.Entrega(0)
        txtEntrega2.Text = tk.Entrega(1)
        txtEntrega3.Text = tk.Entrega(2)

        txtFactura1.Text = tk.Factura(0)
        txtFactura2.Text = tk.Factura(1)
        txtFactura3.Text = tk.Factura(2)

        txtIntervencion1.Text = tk.Intervencion(0)
        txtIntervencion2.Text = tk.Intervencion(1)
        txtIntervencion3.Text = tk.Intervencion(2)

        txtObservaciones.Clear()

        txtCodigoCliente.ReadOnly = True
        txtCodigoSucursal.ReadOnly = True
        cboMotivos.Enabled = False

        EstadoControles()

    End Sub
    Private Sub EstadoControles()
        'Activa/Desactiva el estado de los controles segun estado del ticket

        Select Case tk.Estado
            Case 3 'Cerrado
                txtContacto.Enabled = False
                txtTelefono.Enabled = False
                txtMail.Enabled = False

                txtObservaciones.Enabled = False
                btnAgregarComentario.Enabled = False

                btnResolver.Enabled = False
                btnCerrar.Enabled = False
                btnAbrir.Enabled = usr.CierraTicket

                btnAsignar.Enabled = False
                gpDocumentos.Enabled = False

            Case Else
                btnRegistrar.Enabled = Modificado
                btnCerrar.Enabled = usr.CierraTicket
                btnAbrir.Enabled = False
                btnResolver.Enabled = tk.Estado = 1
        End Select

    End Sub
    Private Sub BuscarTicketAbierto()
        Dim Sql As String
        Dim da As OracleDataAdapter
        Dim dt As DataTable
        Dim dr As DataRow

        If txtCodigoCliente.Text <> "" And txtCodigoSucursal.Text <> "" And txtTicketNumero.Text = "" Then
            Sql = "SELECT * "
            Sql &= "FROM xticketh "
            Sql &= "WHERE bpcnum_0 = :bpcnum AND "
            Sql &= "      bpaadd_0 = :bpaadd AND "
            Sql &= "      estado_0 <> 3"

            If cboMotivos.SelectedValue.ToString.Trim <> "" Then
                Sql &= " AND motivo_0 = " & cboMotivos.SelectedValue.ToString.Trim
            End If

            da = New OracleDataAdapter(Sql, cn)
            da.SelectCommand.Parameters.Add("bpcnum", OracleType.VarChar).Value = txtCodigoCliente.Text.Trim
            da.SelectCommand.Parameters.Add("bpaadd", OracleType.VarChar).Value = txtCodigoSucursal.Text.Trim
            dt = New DataTable
            da.Fill(dt)

            If dt.Rows.Count > 0 Then
                dr = dt.Rows(0)
                Abrir(CInt(dr("nro_0")))
            End If


        End If

    End Sub
    Private Sub EditarCliente(ByVal bpc As String)
        Dim f As New frmCliente(bpc)
        f.ShowDialog()
    End Sub
    Private Sub EditarSucursal(ByVal bpc As Cliente, ByVal bpa As Sucursal)
        Dim f As New frmSucursal(bpc, bpa)
        f.GrabarAlSalir = True
        f.ShowDialog()
    End Sub
    Private Sub AbrirSelectorCliente()
        Dim f As New frmSelectorClientes
        f.ShowDialog(Me)

        If f.DialogResult = Windows.Forms.DialogResult.OK Then
            txtCodigoCliente.Text = f.ClienteSeleccionado
        End If
        f.Dispose()
    End Sub
    Private Sub AbrirSelectorSucursal()
        If txtCodigoCliente.Text = "" Then Exit Sub

        Dim f As New frmSelectorSucursal(txtCodigoCliente.Text)
        f.ShowDialog(Me)

        If f.DialogResult = Windows.Forms.DialogResult.OK Then
            txtCodigoSucursal.Text = f.SucursalSeleccionada
        End If
        f.Dispose()
    End Sub
    Private Sub AbrirSelectorEntrega(ByVal txt As TextBox)
        Dim f As New frmBuscadorEntregas(txtCodigoCliente.Text, txtCodigoSucursal.Text)

        f.ShowDialog(Me)

        If f.DialogResult = Windows.Forms.DialogResult.OK Then
            txt.Text = f.Seleccionado
            tk.Entrega(CInt(txt.Tag)) = f.Seleccionado
            Modificado = True
            txtCodigoCliente.ReadOnly = True
            txtCodigoSucursal.ReadOnly = True

            EstadoControles()
        End If

    End Sub
    Private Sub AbrirSelectorFactura(ByVal txt As TextBox)
        Dim f As New frmBuscadorFacturas(txtCodigoCliente.Text)

        f.ShowDialog(Me)

        If f.DialogResult = Windows.Forms.DialogResult.OK Then
            txt.Text = f.Seleccionado
            tk.Factura(CInt(txt.Tag)) = f.Seleccionado
            Modificado = True

            txtCodigoCliente.ReadOnly = True
            txtCodigoSucursal.ReadOnly = True

            EstadoControles()
        End If

    End Sub
    Private Sub AbrirSelectorIntervencion(ByVal txt As TextBox)
        Dim f As New frmBuscadorIntervenciones(txtCodigoCliente.Text, txtCodigoSucursal.Text)

        f.ShowDialog(Me)

        If f.DialogResult = Windows.Forms.DialogResult.OK Then
            txt.Text = f.Seleccionado
            tk.Intervencion(CInt(txt.Tag)) = f.Seleccionado
            Modificado = True
            txtCodigoCliente.ReadOnly = True
            txtCodigoSucursal.ReadOnly = True

            EstadoControles()
        End If

    End Sub
    Private Sub AbrirSelectorPedidos(ByVal txt As TextBox)
        Dim f As New frmBuscadorPedidos(txtCodigoCliente.Text, txtCodigoSucursal.Text)

        f.ShowDialog(Me)

        If f.DialogResult = Windows.Forms.DialogResult.OK Then
            txt.Text = f.Seleccionado
            tk.Pedido(CInt(txt.Tag)) = f.Seleccionado
            Modificado = True
            txtCodigoCliente.ReadOnly = True
            txtCodigoSucursal.ReadOnly = True

            EstadoControles()
        End If

    End Sub
    Private Sub Grabar()
        With tk
            If tk.Numero = 0 Then
                .Estado = 1
                .UsuarioCreacion = usr.Codigo
                .ClienteCodigo = txtCodigoCliente.Text
                .SucursalCodigo = txtCodigoSucursal.Text
                .Tipo = CInt(cboMotivos.SelectedValue)
            End If

            .Contacto = txtContacto.Text
            .Telefono = txtTelefono.Text
            .Mail = txtMail.Text

            .Grabar()

            Modificado = False
            MostrarDatos()

        End With

    End Sub
    Private Function ValidacionesOK() As Boolean
        If cboMotivos.SelectedValue.ToString.Trim = "0" Then
            MessageBox.Show("Falta seleccionar motivo", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            cboMotivos.Focus()
            Return False
        End If
        If txtCodigoCliente.Text.Trim = "" Then
            MessageBox.Show("Falta código de cliente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtCodigoCliente.Focus()
            Return False
        End If
        If txtCodigoSucursal.Text.Trim = "" Then
            MessageBox.Show("Falta código de sucursal", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtCodigoSucursal.Focus()
            Return False
        End If
        If txtContacto.Text.Trim = "" Then
            MessageBox.Show("Falta nombre del contacto", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtContacto.Focus()
            Return False

        End If
        If txtTelefono.Text.Trim = "" And txtMail.Text.Trim = "" Then
            MessageBox.Show("Falta teléfono o mail", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtTelefono.Focus()
            Return False
        End If
        If tk.dt2.Rows.Count = 0 Then
            MessageBox.Show("Falta observaciones", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtObservaciones.Focus()
            Return False
        End If

        Return True

    End Function
    Private Sub VerEntrega(ByVal txt As TextBox)
        Dim Archivo As String

        If txt.Text.Trim = "" Then Exit Sub

        Archivo = txt.Text.Trim

        'Miro si es intervencion o remito de nuevo
        If Not Archivo.Substring(3, 3) = "RMR" Then

            Dim itn As New Intervencion(cn)

            If itn.Abrir(txt.Text) Then
                If itn.Remito.Trim <> "" Then
                    Archivo = itn.Remito

                Else
                    Archivo = "null"

                End If
            End If

        End If

        Archivo &= ".pdf"

        If File.Exists(PATH_SCAN & Archivo) Then

            Try
                Process.Start(PATH_SCAN & Archivo)

            Catch ex As Exception
                MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        Else

            MessageBox.Show("No se encontró el documento escaneado", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)

        End If

    End Sub
    Private Sub VerFactura(ByVal txt As TextBox)
        If txt.Text.Trim = "" Then Exit Sub

        Dim crystal As frmCrystal
        Dim rpt As New ReportDocument
        Dim sih As New Factura(cn)


        If sih.Abrir(txt.Text.Trim) Then

            If sih.EsFacturaElectronica Then

                rpt.Load(RPTX3 & "XFACT_ELEC.rpt")
                rpt.SetDatabaseLogon(DB_USR, DB_PWD)
                rpt.SetParameterValue("facturedeb", sih.Numero)
                rpt.SetParameterValue("facturefin", sih.Numero)
                rpt.SetParameterValue("cero", False)
                rpt.SetParameterValue("enviar", False)
                rpt.SetParameterValue("ocultar_barras", True)

            Else

                rpt.Load(RPTX3 & "SBONFACP.rpt")
                rpt.SetDatabaseLogon(DB_USR, DB_PWD)
                rpt.SetParameterValue("facturedeb", sih.Numero)
                rpt.SetParameterValue("facturefin", sih.Numero)
                rpt.SetParameterValue("Leyenda", 0)
                rpt.SetParameterValue("X3DOS", X3DOS)

            End If

        End If

        crystal = New frmCrystal(rpt)
        crystal.MdiParent = Me.ParentForm
        crystal.Show()

    End Sub
    Private Sub VerIntervencion(ByVal txt As TextBox)
        Dim Archivo As String
        Dim crystal As frmCrystal
        Dim rpt As New ReportDocument

        If txt.Text.Trim = "" Then Exit Sub

        Archivo = txt.Text & ".pdf"

        If File.Exists(PATH_SCAN & Archivo) Then

            Try
                Process.Start(PATH_SCAN & Archivo)

            Catch ex As Exception
                MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        Else

            rpt.Load(RPTX3 & "ITN1.rpt")
            rpt.SetDatabaseLogon(DB_USR, DB_PWD)
            rpt.SetParameterValue("ITN", txt.Text)
            rpt.SetParameterValue("X3USR", usr.Codigo)
            rpt.SetParameterValue("X3DOS", X3DOS)

            crystal = New frmCrystal(rpt)
            crystal.MdiParent = Me.ParentForm
            crystal.Show()

        End If

    End Sub

    'MENU: CLIENTE
    Private Sub cmsCliente_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmsCliente.Opening
        mnuSeleccionarCliente.Enabled = Not txtCodigoCliente.ReadOnly
        mnuEditarCliente.Enabled = txtCodigoCliente.Text.Trim <> ""

    End Sub
    Private Sub mnuSeleccionarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSeleccionarCliente.Click
        AbrirSelectorCliente()
    End Sub
    Private Sub mnuEditarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEditarCliente.Click
        EditarCliente(txtCodigoCliente.Text)
    End Sub
    'MENU: PEDIDOS
    Private Sub cmdPedidos_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmdPedidos.Opening
        Dim txt As TextBox = Nothing

        If txtPedido1.Focused Then txt = txtPedido1
        If txtPedido2.Focused Then txt = txtPedido2
        If txtPedido3.Focused Then txt = txtPedido3

        If txt Is Nothing Then
            e.Cancel = True
            Exit Sub
        End If
    End Sub
    Private Sub mnuSeleccionarPedidos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSeleccionarPedidos.Click
        Dim txt As TextBox = Nothing

        If txtPedido1.Focused Then txt = txtPedido1
        If txtPedido2.Focused Then txt = txtPedido2
        If txtPedido3.Focused Then txt = txtPedido3

        If txt IsNot Nothing Then AbrirSelectorPedidos(txt)
    End Sub
    'MENU: SUCURSAL
    Private Sub cmsSucursal_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmsSucursal.Opening
        mnuSeleccionarSucursal.Enabled = Not txtCodigoSucursal.ReadOnly
        mnuEditarSucursal.Enabled = txtCodigoSucursal.Text.Trim <> ""
    End Sub
    Private Sub mnuSeleccionarSucursal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSeleccionarSucursal.Click
        AbrirSelectorSucursal()
    End Sub
    Private Sub mnuEditarSucursal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEditarSucursal.Click
        Dim bpc As New Cliente(cn)
        Dim bpa As Sucursal

        bpc.Abrir(txtCodigoCliente.Text)
        bpa = bpc.Sucursal(txtCodigoSucursal.Text)

        EditarSucursal(bpc, bpa)

        bpc = Nothing
        bpa = Nothing
    End Sub
    'MENU: ENTREGAS
    Private Sub cmsEntregas_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmsEntregas.Opening
        Dim txt As TextBox = Nothing

        If txtEntrega1.Focused Then txt = txtEntrega1
        If txtEntrega2.Focused Then txt = txtEntrega2
        If txtEntrega3.Focused Then txt = txtEntrega3

        If txt Is Nothing Then
            e.Cancel = True
            Exit Sub
        End If

        mnuVerEntrega.Enabled = txt.Text.Trim <> ""
        mnuEstadoEntrega.Enabled = txt.Text.Trim <> ""
    End Sub
    Private Sub mnuSeleccionarEntrega_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSeleccionarEntrega.Click
        Dim txt As TextBox = Nothing

        If txtEntrega1.Focused Then txt = txtEntrega1
        If txtEntrega2.Focused Then txt = txtEntrega2
        If txtEntrega3.Focused Then txt = txtEntrega3

        If txt IsNot Nothing Then AbrirSelectorEntrega(txt)
    End Sub
    Private Sub mnuVerEntrega_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuVerEntrega.Click
        Dim txt As TextBox = Nothing

        If txtEntrega1.Focused Then txt = txtEntrega1
        If txtEntrega2.Focused Then txt = txtEntrega2
        If txtEntrega3.Focused Then txt = txtEntrega3

        If txt IsNot Nothing Then VerEntrega(txt)

    End Sub
    Private Sub mnuEstadoEntrega_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEstadoEntrega.Click
        MessageBox.Show("Falta programar")
    End Sub
    'MENU: FACTURAS
    Private Sub cmsFacturas_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmsFacturas.Opening
        Dim txt As TextBox = Nothing

        If txtFactura1.Focused Then txt = txtFactura1
        If txtFactura2.Focused Then txt = txtFactura2
        If txtFactura3.Focused Then txt = txtFactura3

        If txt Is Nothing Then
            e.Cancel = True
            Exit Sub
        End If

        mnuVerFactura.Enabled = txt.Text.Trim <> ""
        mnuEstadoFactura.Enabled = txt.Text.Trim <> ""

    End Sub
    Private Sub mnuSeleccionarFacturas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSeleccionarFacturas.Click
        Dim txt As TextBox = Nothing

        If txtFactura1.Focused Then txt = txtFactura1
        If txtFactura2.Focused Then txt = txtFactura2
        If txtFactura3.Focused Then txt = txtFactura3

        If txt IsNot Nothing Then AbrirSelectorFactura(txt)
    End Sub
    Private Sub mnuVerFactura_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuVerFactura.Click
        Dim txt As TextBox = Nothing

        If txtFactura1.Focused Then txt = txtFactura1
        If txtFactura2.Focused Then txt = txtFactura2
        If txtFactura3.Focused Then txt = txtFactura3

        If txt IsNot Nothing Then VerFactura(txt)
    End Sub
    Private Sub mnuEstadoFactura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEstadoFactura.Click
        MessageBox.Show("Falta programar")
    End Sub
    'MENU: INTERVENCIONES
    Private Sub cmsIntervencion_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmsIntervencion.Opening
        Dim txt As TextBox = Nothing

        If txtIntervencion1.Focused Then txt = txtIntervencion1
        If txtIntervencion2.Focused Then txt = txtIntervencion2
        If txtIntervencion3.Focused Then txt = txtIntervencion3

        If txt Is Nothing Then
            e.Cancel = True
            Exit Sub
        End If


        mnuVerIntervencion.Enabled = txt.Text.Trim <> ""
        mnuEstadoIntervencion.Enabled = txt.Text.Trim <> ""

    End Sub
    Private Sub mnuSeleccionarIntervenciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSeleccionarIntervenciones.Click
        Dim txt As TextBox = Nothing

        If txtIntervencion1.Focused Then txt = txtIntervencion1
        If txtIntervencion2.Focused Then txt = txtIntervencion2
        If txtIntervencion3.Focused Then txt = txtIntervencion3

        If txt IsNot Nothing Then AbrirSelectorIntervencion(txt)
    End Sub
    Private Sub mnuVerIntervencion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuVerIntervencion.Click
        Dim txt As TextBox = Nothing

        If txtIntervencion1.Focused Then txt = txtIntervencion1
        If txtIntervencion2.Focused Then txt = txtIntervencion2
        If txtIntervencion3.Focused Then txt = txtIntervencion3

        If txt IsNot Nothing Then VerIntervencion(txt)
    End Sub
    Private Sub mnuEstadoIntervencion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEstadoIntervencion.Click
        Dim txt As TextBox = Nothing

        If txtIntervencion1.Focused Then txt = txtIntervencion1
        If txtIntervencion2.Focused Then txt = txtIntervencion2
        If txtIntervencion3.Focused Then txt = txtIntervencion3

        Dim itn As New Intervencion(cn)

        itn.Abrir(txt.Text.Trim)

        MessageBox.Show(itn.AnalizarEstado, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

        itn.Dispose()
        itn = Nothing

    End Sub

    Private Sub btnResolver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResolver.Click

        If MessageBox.Show("¿Marca el ticket como resuelto?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            tk.Estado = 2 'Resuelto
            tk.AsignarA(tk.UsuarioCreacion)
            Grabar()
        End If

    End Sub
    Private Sub btnAbrir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbrir.Click
        If MessageBox.Show("¿Desea abrir el ticket nuevamente?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            tk.Estado = 1 'Abierto
            Grabar()
        End If
    End Sub
    Private Sub btnAsignar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAsignar.Click
        Dim Asignar As String = cboAsignar.SelectedValue.ToString.Trim

        If Asignar.Trim = "" Then
            MessageBox.Show("Debe seleccionar a quien asignar el ticket", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)

        Else

            tk.AsignarA(cboAsignar.SelectedValue.ToString)
            txtAsignado.Text = tk.Asignado

            Modificado = True

            EstadoControles()
        End If

    End Sub
    Private Sub btnAgregarComentario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarComentario.Click
        tk.AgregarComentario(txtObservaciones.Text.Trim, usr.Codigo)
        txtObservaciones.Clear()
        Modificado = True
        EstadoControles()
    End Sub
    Private Sub txtCodigoCliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigoCliente.TextChanged
        Modificado = True
    End Sub
    Private Sub txtCodigoSucursal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigoSucursal.TextChanged
        Modificado = True
    End Sub
    Private Sub txtContacto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtContacto.LostFocus
        EstadoControles()
    End Sub
    Private Sub txtContacto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtContacto.TextChanged
        Modificado = True
    End Sub
    Private Sub txtTelefono_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTelefono.LostFocus

    End Sub
    Private Sub txtTelefono_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTelefono.TextChanged
        Modificado = True
    End Sub
    Private Sub txtMail_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMail.LostFocus
        EstadoControles()
    End Sub
    Private Sub txtMail_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMail.TextChanged
        Modificado = True
    End Sub

End Class