<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTicket
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim Label1 As System.Windows.Forms.Label
        Dim Label2 As System.Windows.Forms.Label
        Dim Label3 As System.Windows.Forms.Label
        Dim Label5 As System.Windows.Forms.Label
        Dim Label6 As System.Windows.Forms.Label
        Dim Label4 As System.Windows.Forms.Label
        Dim Label8 As System.Windows.Forms.Label
        Dim Label11 As System.Windows.Forms.Label
        Dim Label10 As System.Windows.Forms.Label
        Dim Label9 As System.Windows.Forms.Label
        Dim Label7 As System.Windows.Forms.Label
        Dim Label12 As System.Windows.Forms.Label
        Dim Label13 As System.Windows.Forms.Label
        Dim Label16 As System.Windows.Forms.Label
        Dim GroupBox3 As System.Windows.Forms.GroupBox
        Dim GroupBox4 As System.Windows.Forms.GroupBox
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.cboAsignar = New System.Windows.Forms.ComboBox
        Me.btnAsignar = New System.Windows.Forms.Button
        Me.btnResolver = New System.Windows.Forms.Button
        Me.btnCerrar = New System.Windows.Forms.Button
        Me.btnAbrir = New System.Windows.Forms.Button
        Me.txtTicketNumero = New System.Windows.Forms.TextBox
        Me.cboMotivos = New System.Windows.Forms.ComboBox
        Me.cboEstado = New System.Windows.Forms.ComboBox
        Me.txtAsignado = New System.Windows.Forms.TextBox
        Me.txtFecha = New System.Windows.Forms.TextBox
        Me.txtHora = New System.Windows.Forms.TextBox
        Me.dgv = New System.Windows.Forms.DataGridView
        Me.colTicket = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colLinea = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colFecha = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colHora = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colUsuario = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colComentarios = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.txtCodigoCliente = New System.Windows.Forms.TextBox
        Me.cmsCliente = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuSeleccionarCliente = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuEditarCliente = New System.Windows.Forms.ToolStripMenuItem
        Me.txtNombreCliente = New System.Windows.Forms.TextBox
        Me.txtCodigoSucursal = New System.Windows.Forms.TextBox
        Me.cmsSucursal = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuSeleccionarSucursal = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuEditarSucursal = New System.Windows.Forms.ToolStripMenuItem
        Me.txtDomicilio = New System.Windows.Forms.TextBox
        Me.gpDocumentos = New System.Windows.Forms.GroupBox
        Me.txtPedido3 = New System.Windows.Forms.TextBox
        Me.cmdPedidos = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuSeleccionarPedidos = New System.Windows.Forms.ToolStripMenuItem
        Me.txtPedido2 = New System.Windows.Forms.TextBox
        Me.txtPedido1 = New System.Windows.Forms.TextBox
        Me.txtIntervencion3 = New System.Windows.Forms.TextBox
        Me.cmsIntervencion = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuSeleccionarIntervenciones = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuVerIntervencion = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuEstadoIntervencion = New System.Windows.Forms.ToolStripMenuItem
        Me.txtIntervencion2 = New System.Windows.Forms.TextBox
        Me.txtFactura3 = New System.Windows.Forms.TextBox
        Me.cmsFacturas = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuSeleccionarFacturas = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuVerFactura = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuEstadoFactura = New System.Windows.Forms.ToolStripMenuItem
        Me.txtFactura2 = New System.Windows.Forms.TextBox
        Me.txtEntrega3 = New System.Windows.Forms.TextBox
        Me.cmsEntregas = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuSeleccionarEntrega = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuVerEntrega = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuEstadoEntrega = New System.Windows.Forms.ToolStripMenuItem
        Me.txtEntrega2 = New System.Windows.Forms.TextBox
        Me.txtIntervencion1 = New System.Windows.Forms.TextBox
        Me.txtEntrega1 = New System.Windows.Forms.TextBox
        Me.txtFactura1 = New System.Windows.Forms.TextBox
        Me.txtContacto = New System.Windows.Forms.TextBox
        Me.txtTelefono = New System.Windows.Forms.TextBox
        Me.txtMail = New System.Windows.Forms.TextBox
        Me.btnRegistrar = New System.Windows.Forms.Button
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.txtObservaciones = New System.Windows.Forms.TextBox
        Me.txtVendedorActual = New System.Windows.Forms.TextBox
        Me.txtVendedorAnterior = New System.Windows.Forms.TextBox
        Me.txtTipoAbc = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btnAgregarComentario = New System.Windows.Forms.Button
        Label1 = New System.Windows.Forms.Label
        Label2 = New System.Windows.Forms.Label
        Label3 = New System.Windows.Forms.Label
        Label5 = New System.Windows.Forms.Label
        Label6 = New System.Windows.Forms.Label
        Label4 = New System.Windows.Forms.Label
        Label8 = New System.Windows.Forms.Label
        Label11 = New System.Windows.Forms.Label
        Label10 = New System.Windows.Forms.Label
        Label9 = New System.Windows.Forms.Label
        Label7 = New System.Windows.Forms.Label
        Label12 = New System.Windows.Forms.Label
        Label13 = New System.Windows.Forms.Label
        Label16 = New System.Windows.Forms.Label
        GroupBox3 = New System.Windows.Forms.GroupBox
        GroupBox4 = New System.Windows.Forms.GroupBox
        GroupBox3.SuspendLayout()
        GroupBox4.SuspendLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsCliente.SuspendLayout()
        Me.cmsSucursal.SuspendLayout()
        Me.gpDocumentos.SuspendLayout()
        Me.cmdPedidos.SuspendLayout()
        Me.cmsIntervencion.SuspendLayout()
        Me.cmsFacturas.SuspendLayout()
        Me.cmsEntregas.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(9, 9)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(77, 13)
        Label1.TabIndex = 0
        Label1.Text = "Ticket Número"
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Location = New System.Drawing.Point(17, 136)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(39, 13)
        Label2.TabIndex = 25
        Label2.Text = "Motivo"
        '
        'Label3
        '
        Label3.AutoSize = True
        Label3.Location = New System.Drawing.Point(462, 9)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(43, 13)
        Label3.TabIndex = 7
        Label3.Text = "Estado:"
        '
        'Label5
        '
        Label5.AutoSize = True
        Label5.Location = New System.Drawing.Point(348, 9)
        Label5.Name = "Label5"
        Label5.Size = New System.Drawing.Size(63, 13)
        Label5.TabIndex = 5
        Label5.Text = "Asignado a:"
        '
        'Label6
        '
        Label6.AutoSize = True
        Label6.Location = New System.Drawing.Point(198, 9)
        Label6.Name = "Label6"
        Label6.Size = New System.Drawing.Size(40, 13)
        Label6.TabIndex = 2
        Label6.Text = "Fecha;"
        '
        'Label4
        '
        Label4.AutoSize = True
        Label4.Location = New System.Drawing.Point(13, 50)
        Label4.Name = "Label4"
        Label4.Size = New System.Drawing.Size(42, 13)
        Label4.TabIndex = 9
        Label4.Text = "Cliente:"
        '
        'Label8
        '
        Label8.AutoSize = True
        Label8.Location = New System.Drawing.Point(13, 99)
        Label8.Name = "Label8"
        Label8.Size = New System.Drawing.Size(29, 13)
        Label8.TabIndex = 16
        Label8.Text = "Suc:"
        '
        'Label11
        '
        Label11.AutoSize = True
        Label11.Location = New System.Drawing.Point(5, 152)
        Label11.Name = "Label11"
        Label11.Size = New System.Drawing.Size(69, 13)
        Label11.TabIndex = 12
        Label11.Text = "Intervención:"
        '
        'Label10
        '
        Label10.AutoSize = True
        Label10.Location = New System.Drawing.Point(5, 110)
        Label10.Name = "Label10"
        Label10.Size = New System.Drawing.Size(46, 13)
        Label10.TabIndex = 8
        Label10.Text = "Factura:"
        '
        'Label9
        '
        Label9.AutoSize = True
        Label9.Location = New System.Drawing.Point(5, 68)
        Label9.Name = "Label9"
        Label9.Size = New System.Drawing.Size(47, 13)
        Label9.TabIndex = 4
        Label9.Text = "Entrega:"
        '
        'Label7
        '
        Label7.AutoSize = True
        Label7.Location = New System.Drawing.Point(355, 46)
        Label7.Name = "Label7"
        Label7.Size = New System.Drawing.Size(53, 13)
        Label7.TabIndex = 19
        Label7.Text = "Contacto:"
        '
        'Label12
        '
        Label12.AutoSize = True
        Label12.Location = New System.Drawing.Point(355, 72)
        Label12.Name = "Label12"
        Label12.Size = New System.Drawing.Size(52, 13)
        Label12.TabIndex = 21
        Label12.Text = "Telefono:"
        '
        'Label13
        '
        Label13.AutoSize = True
        Label13.Location = New System.Drawing.Point(355, 98)
        Label13.Name = "Label13"
        Label13.Size = New System.Drawing.Size(29, 13)
        Label13.TabIndex = 23
        Label13.Text = "Mail:"
        '
        'Label16
        '
        Label16.AutoSize = True
        Label16.Location = New System.Drawing.Point(5, 26)
        Label16.Name = "Label16"
        Label16.Size = New System.Drawing.Size(48, 13)
        Label16.TabIndex = 0
        Label16.Text = "Pedidos:"
        '
        'GroupBox3
        '
        GroupBox3.Controls.Add(Me.cboAsignar)
        GroupBox3.Controls.Add(Me.btnAsignar)
        GroupBox3.Location = New System.Drawing.Point(617, 214)
        GroupBox3.Name = "GroupBox3"
        GroupBox3.Size = New System.Drawing.Size(437, 91)
        GroupBox3.TabIndex = 29
        GroupBox3.TabStop = False
        GroupBox3.Text = "Asignar"
        '
        'cboAsignar
        '
        Me.cboAsignar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAsignar.FormattingEnabled = True
        Me.cboAsignar.Location = New System.Drawing.Point(6, 36)
        Me.cboAsignar.Name = "cboAsignar"
        Me.cboAsignar.Size = New System.Drawing.Size(334, 21)
        Me.cboAsignar.TabIndex = 0
        '
        'btnAsignar
        '
        Me.btnAsignar.Location = New System.Drawing.Point(346, 36)
        Me.btnAsignar.Name = "btnAsignar"
        Me.btnAsignar.Size = New System.Drawing.Size(85, 23)
        Me.btnAsignar.TabIndex = 1
        Me.btnAsignar.Text = "Asignar"
        Me.btnAsignar.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        GroupBox4.Controls.Add(Me.btnResolver)
        GroupBox4.Controls.Add(Me.btnCerrar)
        GroupBox4.Controls.Add(Me.btnAbrir)
        GroupBox4.Location = New System.Drawing.Point(617, 311)
        GroupBox4.Name = "GroupBox4"
        GroupBox4.Size = New System.Drawing.Size(437, 91)
        GroupBox4.TabIndex = 30
        GroupBox4.TabStop = False
        GroupBox4.Text = "Acciones"
        '
        'btnResolver
        '
        Me.btnResolver.Location = New System.Drawing.Point(82, 36)
        Me.btnResolver.Name = "btnResolver"
        Me.btnResolver.Size = New System.Drawing.Size(79, 23)
        Me.btnResolver.TabIndex = 0
        Me.btnResolver.Text = "Resuelto"
        Me.btnResolver.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.Location = New System.Drawing.Point(167, 36)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(79, 23)
        Me.btnCerrar.TabIndex = 1
        Me.btnCerrar.Text = "Cerrar Ticket"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnAbrir
        '
        Me.btnAbrir.Location = New System.Drawing.Point(252, 36)
        Me.btnAbrir.Name = "btnAbrir"
        Me.btnAbrir.Size = New System.Drawing.Size(79, 23)
        Me.btnAbrir.TabIndex = 2
        Me.btnAbrir.Text = "Abrir Ticket"
        Me.btnAbrir.UseVisualStyleBackColor = True
        '
        'txtTicketNumero
        '
        Me.txtTicketNumero.Location = New System.Drawing.Point(92, 6)
        Me.txtTicketNumero.Name = "txtTicketNumero"
        Me.txtTicketNumero.ReadOnly = True
        Me.txtTicketNumero.Size = New System.Drawing.Size(100, 20)
        Me.txtTicketNumero.TabIndex = 1
        Me.txtTicketNumero.TabStop = False
        Me.txtTicketNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboMotivos
        '
        Me.cboMotivos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMotivos.FormattingEnabled = True
        Me.cboMotivos.Location = New System.Drawing.Point(97, 133)
        Me.cboMotivos.Name = "cboMotivos"
        Me.cboMotivos.Size = New System.Drawing.Size(253, 21)
        Me.cboMotivos.TabIndex = 26
        '
        'cboEstado
        '
        Me.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cboEstado.Enabled = False
        Me.cboEstado.FormattingEnabled = True
        Me.cboEstado.Location = New System.Drawing.Point(511, 6)
        Me.cboEstado.Name = "cboEstado"
        Me.cboEstado.Size = New System.Drawing.Size(100, 21)
        Me.cboEstado.TabIndex = 8
        Me.cboEstado.TabStop = False
        '
        'txtAsignado
        '
        Me.txtAsignado.Location = New System.Drawing.Point(417, 6)
        Me.txtAsignado.Name = "txtAsignado"
        Me.txtAsignado.ReadOnly = True
        Me.txtAsignado.Size = New System.Drawing.Size(39, 20)
        Me.txtAsignado.TabIndex = 6
        Me.txtAsignado.TabStop = False
        Me.txtAsignado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtFecha
        '
        Me.txtFecha.Location = New System.Drawing.Point(238, 6)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.ReadOnly = True
        Me.txtFecha.Size = New System.Drawing.Size(57, 20)
        Me.txtFecha.TabIndex = 3
        Me.txtFecha.TabStop = False
        Me.txtFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtHora
        '
        Me.txtHora.Location = New System.Drawing.Point(301, 6)
        Me.txtHora.Name = "txtHora"
        Me.txtHora.ReadOnly = True
        Me.txtHora.Size = New System.Drawing.Size(41, 20)
        Me.txtHora.TabIndex = 4
        Me.txtHora.TabStop = False
        Me.txtHora.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToDeleteRows = False
        Me.dgv.AllowUserToResizeColumns = False
        Me.dgv.AllowUserToResizeRows = False
        Me.dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colTicket, Me.colLinea, Me.colFecha, Me.colHora, Me.colUsuario, Me.colComentarios})
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv.DefaultCellStyle = DataGridViewCellStyle11
        Me.dgv.Location = New System.Drawing.Point(8, 90)
        Me.dgv.Name = "dgv"
        Me.dgv.ReadOnly = True
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.dgv.Size = New System.Drawing.Size(585, 237)
        Me.dgv.TabIndex = 2
        '
        'colTicket
        '
        Me.colTicket.HeaderText = "Ticket"
        Me.colTicket.Name = "colTicket"
        Me.colTicket.ReadOnly = True
        Me.colTicket.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colTicket.Visible = False
        '
        'colLinea
        '
        Me.colLinea.HeaderText = "Linea"
        Me.colLinea.Name = "colLinea"
        Me.colLinea.ReadOnly = True
        Me.colLinea.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colLinea.Visible = False
        '
        'colFecha
        '
        Me.colFecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colFecha.HeaderText = "Fecha"
        Me.colFecha.Name = "colFecha"
        Me.colFecha.ReadOnly = True
        Me.colFecha.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colFecha.Width = 43
        '
        'colHora
        '
        Me.colHora.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colHora.HeaderText = "Hora"
        Me.colHora.Name = "colHora"
        Me.colHora.ReadOnly = True
        Me.colHora.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colHora.Width = 36
        '
        'colUsuario
        '
        Me.colUsuario.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colUsuario.HeaderText = "Usuario"
        Me.colUsuario.Name = "colUsuario"
        Me.colUsuario.ReadOnly = True
        Me.colUsuario.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colUsuario.Width = 49
        '
        'colComentarios
        '
        Me.colComentarios.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colComentarios.DefaultCellStyle = DataGridViewCellStyle10
        Me.colComentarios.HeaderText = "Comentario"
        Me.colComentarios.Name = "colComentarios"
        Me.colComentarios.ReadOnly = True
        Me.colComentarios.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'txtCodigoCliente
        '
        Me.txtCodigoCliente.ContextMenuStrip = Me.cmsCliente
        Me.txtCodigoCliente.Location = New System.Drawing.Point(97, 47)
        Me.txtCodigoCliente.Name = "txtCodigoCliente"
        Me.txtCodigoCliente.Size = New System.Drawing.Size(47, 20)
        Me.txtCodigoCliente.TabIndex = 10
        Me.txtCodigoCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmsCliente
        '
        Me.cmsCliente.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSeleccionarCliente, Me.mnuEditarCliente})
        Me.cmsCliente.Name = "cms"
        Me.cmsCliente.Size = New System.Drawing.Size(144, 48)
        '
        'mnuSeleccionarCliente
        '
        Me.mnuSeleccionarCliente.Name = "mnuSeleccionarCliente"
        Me.mnuSeleccionarCliente.Size = New System.Drawing.Size(143, 22)
        Me.mnuSeleccionarCliente.Text = "Seleccionar..."
        '
        'mnuEditarCliente
        '
        Me.mnuEditarCliente.Name = "mnuEditarCliente"
        Me.mnuEditarCliente.Size = New System.Drawing.Size(143, 22)
        Me.mnuEditarCliente.Text = "Editar..."
        '
        'txtNombreCliente
        '
        Me.txtNombreCliente.Location = New System.Drawing.Point(152, 47)
        Me.txtNombreCliente.Name = "txtNombreCliente"
        Me.txtNombreCliente.ReadOnly = True
        Me.txtNombreCliente.Size = New System.Drawing.Size(176, 20)
        Me.txtNombreCliente.TabIndex = 11
        Me.txtNombreCliente.TabStop = False
        '
        'txtCodigoSucursal
        '
        Me.txtCodigoSucursal.ContextMenuStrip = Me.cmsSucursal
        Me.txtCodigoSucursal.Location = New System.Drawing.Point(97, 95)
        Me.txtCodigoSucursal.Name = "txtCodigoSucursal"
        Me.txtCodigoSucursal.Size = New System.Drawing.Size(47, 20)
        Me.txtCodigoSucursal.TabIndex = 17
        Me.txtCodigoSucursal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmsSucursal
        '
        Me.cmsSucursal.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSeleccionarSucursal, Me.mnuEditarSucursal})
        Me.cmsSucursal.Name = "cms"
        Me.cmsSucursal.Size = New System.Drawing.Size(144, 48)
        '
        'mnuSeleccionarSucursal
        '
        Me.mnuSeleccionarSucursal.Name = "mnuSeleccionarSucursal"
        Me.mnuSeleccionarSucursal.Size = New System.Drawing.Size(143, 22)
        Me.mnuSeleccionarSucursal.Text = "Seleccionar..."
        '
        'mnuEditarSucursal
        '
        Me.mnuEditarSucursal.Name = "mnuEditarSucursal"
        Me.mnuEditarSucursal.Size = New System.Drawing.Size(143, 22)
        Me.mnuEditarSucursal.Text = "Editar..."
        '
        'txtDomicilio
        '
        Me.txtDomicilio.Location = New System.Drawing.Point(152, 95)
        Me.txtDomicilio.Name = "txtDomicilio"
        Me.txtDomicilio.ReadOnly = True
        Me.txtDomicilio.Size = New System.Drawing.Size(198, 20)
        Me.txtDomicilio.TabIndex = 18
        Me.txtDomicilio.TabStop = False
        '
        'gpDocumentos
        '
        Me.gpDocumentos.Controls.Add(Me.txtPedido3)
        Me.gpDocumentos.Controls.Add(Me.txtPedido2)
        Me.gpDocumentos.Controls.Add(Me.txtPedido1)
        Me.gpDocumentos.Controls.Add(Label16)
        Me.gpDocumentos.Controls.Add(Me.txtIntervencion3)
        Me.gpDocumentos.Controls.Add(Me.txtIntervencion2)
        Me.gpDocumentos.Controls.Add(Me.txtFactura3)
        Me.gpDocumentos.Controls.Add(Me.txtFactura2)
        Me.gpDocumentos.Controls.Add(Me.txtEntrega3)
        Me.gpDocumentos.Controls.Add(Me.txtEntrega2)
        Me.gpDocumentos.Controls.Add(Me.txtIntervencion1)
        Me.gpDocumentos.Controls.Add(Me.txtEntrega1)
        Me.gpDocumentos.Controls.Add(Label11)
        Me.gpDocumentos.Controls.Add(Me.txtFactura1)
        Me.gpDocumentos.Controls.Add(Label10)
        Me.gpDocumentos.Controls.Add(Label9)
        Me.gpDocumentos.Location = New System.Drawing.Point(621, 6)
        Me.gpDocumentos.Name = "gpDocumentos"
        Me.gpDocumentos.Size = New System.Drawing.Size(437, 202)
        Me.gpDocumentos.TabIndex = 28
        Me.gpDocumentos.TabStop = False
        Me.gpDocumentos.Text = "Documentos Relacionados"
        '
        'txtPedido3
        '
        Me.txtPedido3.ContextMenuStrip = Me.cmdPedidos
        Me.txtPedido3.Location = New System.Drawing.Point(286, 44)
        Me.txtPedido3.Name = "txtPedido3"
        Me.txtPedido3.ReadOnly = True
        Me.txtPedido3.Size = New System.Drawing.Size(131, 20)
        Me.txtPedido3.TabIndex = 3
        Me.txtPedido3.Tag = "2"
        Me.txtPedido3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmdPedidos
        '
        Me.cmdPedidos.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSeleccionarPedidos})
        Me.cmdPedidos.Name = "cms"
        Me.cmdPedidos.Size = New System.Drawing.Size(184, 26)
        '
        'mnuSeleccionarPedidos
        '
        Me.mnuSeleccionarPedidos.Name = "mnuSeleccionarPedidos"
        Me.mnuSeleccionarPedidos.Size = New System.Drawing.Size(183, 22)
        Me.mnuSeleccionarPedidos.Text = "Seleccionar pedido..."
        '
        'txtPedido2
        '
        Me.txtPedido2.ContextMenuStrip = Me.cmdPedidos
        Me.txtPedido2.Location = New System.Drawing.Point(145, 44)
        Me.txtPedido2.Name = "txtPedido2"
        Me.txtPedido2.ReadOnly = True
        Me.txtPedido2.Size = New System.Drawing.Size(133, 20)
        Me.txtPedido2.TabIndex = 2
        Me.txtPedido2.Tag = "1"
        Me.txtPedido2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPedido1
        '
        Me.txtPedido1.ContextMenuStrip = Me.cmdPedidos
        Me.txtPedido1.Location = New System.Drawing.Point(6, 44)
        Me.txtPedido1.Name = "txtPedido1"
        Me.txtPedido1.ReadOnly = True
        Me.txtPedido1.Size = New System.Drawing.Size(135, 20)
        Me.txtPedido1.TabIndex = 1
        Me.txtPedido1.Tag = "0"
        Me.txtPedido1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtIntervencion3
        '
        Me.txtIntervencion3.ContextMenuStrip = Me.cmsIntervencion
        Me.txtIntervencion3.Location = New System.Drawing.Point(288, 168)
        Me.txtIntervencion3.Name = "txtIntervencion3"
        Me.txtIntervencion3.ReadOnly = True
        Me.txtIntervencion3.Size = New System.Drawing.Size(131, 20)
        Me.txtIntervencion3.TabIndex = 15
        Me.txtIntervencion3.Tag = "2"
        Me.txtIntervencion3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmsIntervencion
        '
        Me.cmsIntervencion.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSeleccionarIntervenciones, Me.mnuVerIntervencion, Me.mnuEstadoIntervencion})
        Me.cmsIntervencion.Name = "cms"
        Me.cmsIntervencion.Size = New System.Drawing.Size(213, 70)
        '
        'mnuSeleccionarIntervenciones
        '
        Me.mnuSeleccionarIntervenciones.Name = "mnuSeleccionarIntervenciones"
        Me.mnuSeleccionarIntervenciones.Size = New System.Drawing.Size(212, 22)
        Me.mnuSeleccionarIntervenciones.Text = "Seleccionar intervención..."
        '
        'mnuVerIntervencion
        '
        Me.mnuVerIntervencion.Name = "mnuVerIntervencion"
        Me.mnuVerIntervencion.Size = New System.Drawing.Size(212, 22)
        Me.mnuVerIntervencion.Text = "Ver intervencion..."
        '
        'mnuEstadoIntervencion
        '
        Me.mnuEstadoIntervencion.Name = "mnuEstadoIntervencion"
        Me.mnuEstadoIntervencion.Size = New System.Drawing.Size(212, 22)
        Me.mnuEstadoIntervencion.Text = "Ver estado..."
        '
        'txtIntervencion2
        '
        Me.txtIntervencion2.ContextMenuStrip = Me.cmsIntervencion
        Me.txtIntervencion2.Location = New System.Drawing.Point(147, 168)
        Me.txtIntervencion2.Name = "txtIntervencion2"
        Me.txtIntervencion2.ReadOnly = True
        Me.txtIntervencion2.Size = New System.Drawing.Size(133, 20)
        Me.txtIntervencion2.TabIndex = 14
        Me.txtIntervencion2.Tag = "1"
        Me.txtIntervencion2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFactura3
        '
        Me.txtFactura3.ContextMenuStrip = Me.cmsFacturas
        Me.txtFactura3.Location = New System.Drawing.Point(288, 128)
        Me.txtFactura3.Name = "txtFactura3"
        Me.txtFactura3.ReadOnly = True
        Me.txtFactura3.Size = New System.Drawing.Size(135, 20)
        Me.txtFactura3.TabIndex = 11
        Me.txtFactura3.Tag = "2"
        Me.txtFactura3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmsFacturas
        '
        Me.cmsFacturas.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSeleccionarFacturas, Me.mnuVerFactura, Me.mnuEstadoFactura})
        Me.cmsFacturas.Name = "cms"
        Me.cmsFacturas.Size = New System.Drawing.Size(184, 70)
        '
        'mnuSeleccionarFacturas
        '
        Me.mnuSeleccionarFacturas.Name = "mnuSeleccionarFacturas"
        Me.mnuSeleccionarFacturas.Size = New System.Drawing.Size(183, 22)
        Me.mnuSeleccionarFacturas.Text = "Seleccionar factura..."
        '
        'mnuVerFactura
        '
        Me.mnuVerFactura.Name = "mnuVerFactura"
        Me.mnuVerFactura.Size = New System.Drawing.Size(183, 22)
        Me.mnuVerFactura.Text = "Ver factura..."
        '
        'mnuEstadoFactura
        '
        Me.mnuEstadoFactura.Name = "mnuEstadoFactura"
        Me.mnuEstadoFactura.Size = New System.Drawing.Size(183, 22)
        Me.mnuEstadoFactura.Text = "Ver estado..."
        '
        'txtFactura2
        '
        Me.txtFactura2.ContextMenuStrip = Me.cmsFacturas
        Me.txtFactura2.Location = New System.Drawing.Point(147, 128)
        Me.txtFactura2.Name = "txtFactura2"
        Me.txtFactura2.ReadOnly = True
        Me.txtFactura2.Size = New System.Drawing.Size(135, 20)
        Me.txtFactura2.TabIndex = 10
        Me.txtFactura2.Tag = "1"
        Me.txtFactura2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtEntrega3
        '
        Me.txtEntrega3.ContextMenuStrip = Me.cmsEntregas
        Me.txtEntrega3.Location = New System.Drawing.Point(286, 86)
        Me.txtEntrega3.Name = "txtEntrega3"
        Me.txtEntrega3.ReadOnly = True
        Me.txtEntrega3.Size = New System.Drawing.Size(133, 20)
        Me.txtEntrega3.TabIndex = 7
        Me.txtEntrega3.Tag = "2"
        Me.txtEntrega3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmsEntregas
        '
        Me.cmsEntregas.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSeleccionarEntrega, Me.mnuVerEntrega, Me.mnuEstadoEntrega})
        Me.cmsEntregas.Name = "cms"
        Me.cmsEntregas.Size = New System.Drawing.Size(187, 70)
        '
        'mnuSeleccionarEntrega
        '
        Me.mnuSeleccionarEntrega.Name = "mnuSeleccionarEntrega"
        Me.mnuSeleccionarEntrega.Size = New System.Drawing.Size(186, 22)
        Me.mnuSeleccionarEntrega.Text = "Seleccionar entrega..."
        '
        'mnuVerEntrega
        '
        Me.mnuVerEntrega.Name = "mnuVerEntrega"
        Me.mnuVerEntrega.Size = New System.Drawing.Size(186, 22)
        Me.mnuVerEntrega.Text = "Ver entrega..."
        '
        'mnuEstadoEntrega
        '
        Me.mnuEstadoEntrega.Name = "mnuEstadoEntrega"
        Me.mnuEstadoEntrega.Size = New System.Drawing.Size(186, 22)
        Me.mnuEstadoEntrega.Text = "Ver estado..."
        '
        'txtEntrega2
        '
        Me.txtEntrega2.ContextMenuStrip = Me.cmsEntregas
        Me.txtEntrega2.Location = New System.Drawing.Point(147, 86)
        Me.txtEntrega2.Name = "txtEntrega2"
        Me.txtEntrega2.ReadOnly = True
        Me.txtEntrega2.Size = New System.Drawing.Size(133, 20)
        Me.txtEntrega2.TabIndex = 6
        Me.txtEntrega2.Tag = "1"
        Me.txtEntrega2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtIntervencion1
        '
        Me.txtIntervencion1.ContextMenuStrip = Me.cmsIntervencion
        Me.txtIntervencion1.Location = New System.Drawing.Point(8, 168)
        Me.txtIntervencion1.Name = "txtIntervencion1"
        Me.txtIntervencion1.ReadOnly = True
        Me.txtIntervencion1.Size = New System.Drawing.Size(135, 20)
        Me.txtIntervencion1.TabIndex = 13
        Me.txtIntervencion1.Tag = "0"
        Me.txtIntervencion1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtEntrega1
        '
        Me.txtEntrega1.ContextMenuStrip = Me.cmsEntregas
        Me.txtEntrega1.Location = New System.Drawing.Point(8, 86)
        Me.txtEntrega1.Name = "txtEntrega1"
        Me.txtEntrega1.ReadOnly = True
        Me.txtEntrega1.Size = New System.Drawing.Size(133, 20)
        Me.txtEntrega1.TabIndex = 5
        Me.txtEntrega1.Tag = "0"
        Me.txtEntrega1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFactura1
        '
        Me.txtFactura1.ContextMenuStrip = Me.cmsFacturas
        Me.txtFactura1.Location = New System.Drawing.Point(8, 128)
        Me.txtFactura1.Name = "txtFactura1"
        Me.txtFactura1.ReadOnly = True
        Me.txtFactura1.Size = New System.Drawing.Size(135, 20)
        Me.txtFactura1.TabIndex = 9
        Me.txtFactura1.Tag = "0"
        Me.txtFactura1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtContacto
        '
        Me.txtContacto.Location = New System.Drawing.Point(439, 43)
        Me.txtContacto.MaxLength = 50
        Me.txtContacto.Name = "txtContacto"
        Me.txtContacto.Size = New System.Drawing.Size(172, 20)
        Me.txtContacto.TabIndex = 20
        '
        'txtTelefono
        '
        Me.txtTelefono.Location = New System.Drawing.Point(439, 69)
        Me.txtTelefono.MaxLength = 20
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.Size = New System.Drawing.Size(172, 20)
        Me.txtTelefono.TabIndex = 22
        '
        'txtMail
        '
        Me.txtMail.Location = New System.Drawing.Point(439, 95)
        Me.txtMail.MaxLength = 70
        Me.txtMail.Name = "txtMail"
        Me.txtMail.Size = New System.Drawing.Size(172, 20)
        Me.txtMail.TabIndex = 24
        '
        'btnRegistrar
        '
        Me.btnRegistrar.Enabled = False
        Me.btnRegistrar.Location = New System.Drawing.Point(878, 470)
        Me.btnRegistrar.Name = "btnRegistrar"
        Me.btnRegistrar.Size = New System.Drawing.Size(75, 23)
        Me.btnRegistrar.TabIndex = 31
        Me.btnRegistrar.Text = "Registar"
        Me.btnRegistrar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Location = New System.Drawing.Point(959, 470)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 32
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Location = New System.Drawing.Point(8, 26)
        Me.txtObservaciones.MaxLength = 250
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(499, 58)
        Me.txtObservaciones.TabIndex = 0
        '
        'txtVendedorActual
        '
        Me.txtVendedorActual.Location = New System.Drawing.Point(232, 69)
        Me.txtVendedorActual.Name = "txtVendedorActual"
        Me.txtVendedorActual.ReadOnly = True
        Me.txtVendedorActual.Size = New System.Drawing.Size(118, 20)
        Me.txtVendedorActual.TabIndex = 15
        Me.txtVendedorActual.TabStop = False
        '
        'txtVendedorAnterior
        '
        Me.txtVendedorAnterior.Location = New System.Drawing.Point(97, 69)
        Me.txtVendedorAnterior.Name = "txtVendedorAnterior"
        Me.txtVendedorAnterior.ReadOnly = True
        Me.txtVendedorAnterior.Size = New System.Drawing.Size(112, 20)
        Me.txtVendedorAnterior.TabIndex = 13
        Me.txtVendedorAnterior.TabStop = False
        '
        'txtTipoAbc
        '
        Me.txtTipoAbc.Location = New System.Drawing.Point(333, 47)
        Me.txtTipoAbc.Name = "txtTipoAbc"
        Me.txtTipoAbc.ReadOnly = True
        Me.txtTipoAbc.Size = New System.Drawing.Size(17, 20)
        Me.txtTipoAbc.TabIndex = 12
        Me.txtTipoAbc.TabStop = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(215, 72)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(16, 13)
        Me.Label15.TabIndex = 14
        Me.Label15.Text = "->"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnAgregarComentario)
        Me.GroupBox2.Controls.Add(Me.dgv)
        Me.GroupBox2.Controls.Add(Me.txtObservaciones)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 160)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(599, 333)
        Me.GroupBox2.TabIndex = 27
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Comentarios"
        '
        'btnAgregarComentario
        '
        Me.btnAgregarComentario.Enabled = False
        Me.btnAgregarComentario.Location = New System.Drawing.Point(508, 26)
        Me.btnAgregarComentario.Name = "btnAgregarComentario"
        Me.btnAgregarComentario.Size = New System.Drawing.Size(85, 58)
        Me.btnAgregarComentario.TabIndex = 1
        Me.btnAgregarComentario.Text = "Agregar"
        Me.btnAgregarComentario.UseVisualStyleBackColor = True
        '
        'frmTicket
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(1064, 505)
        Me.Controls.Add(GroupBox4)
        Me.Controls.Add(GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.txtTipoAbc)
        Me.Controls.Add(Me.txtVendedorAnterior)
        Me.Controls.Add(Me.txtVendedorActual)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.btnRegistrar)
        Me.Controls.Add(Me.gpDocumentos)
        Me.Controls.Add(Me.txtNombreCliente)
        Me.Controls.Add(Me.txtHora)
        Me.Controls.Add(Me.txtMail)
        Me.Controls.Add(Me.txtCodigoCliente)
        Me.Controls.Add(Me.txtAsignado)
        Me.Controls.Add(Label4)
        Me.Controls.Add(Label13)
        Me.Controls.Add(Me.txtFecha)
        Me.Controls.Add(Label6)
        Me.Controls.Add(Me.txtTelefono)
        Me.Controls.Add(Label12)
        Me.Controls.Add(Me.txtContacto)
        Me.Controls.Add(Label7)
        Me.Controls.Add(Me.cboMotivos)
        Me.Controls.Add(Me.txtDomicilio)
        Me.Controls.Add(Label5)
        Me.Controls.Add(Me.cboEstado)
        Me.Controls.Add(Me.txtCodigoSucursal)
        Me.Controls.Add(Label8)
        Me.Controls.Add(Label3)
        Me.Controls.Add(Label1)
        Me.Controls.Add(Me.txtTicketNumero)
        Me.Controls.Add(Label2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmTicket"
        Me.Text = "Ticket"
        GroupBox3.ResumeLayout(False)
        GroupBox4.ResumeLayout(False)
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsCliente.ResumeLayout(False)
        Me.cmsSucursal.ResumeLayout(False)
        Me.gpDocumentos.ResumeLayout(False)
        Me.gpDocumentos.PerformLayout()
        Me.cmdPedidos.ResumeLayout(False)
        Me.cmsIntervencion.ResumeLayout(False)
        Me.cmsFacturas.ResumeLayout(False)
        Me.cmsEntregas.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtTicketNumero As System.Windows.Forms.TextBox
    Friend WithEvents cboMotivos As System.Windows.Forms.ComboBox
    Friend WithEvents cboEstado As System.Windows.Forms.ComboBox
    Friend WithEvents txtAsignado As System.Windows.Forms.TextBox
    Friend WithEvents txtFecha As System.Windows.Forms.TextBox
    Friend WithEvents txtHora As System.Windows.Forms.TextBox
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents txtCodigoCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtNombreCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigoSucursal As System.Windows.Forms.TextBox
    Friend WithEvents txtDomicilio As System.Windows.Forms.TextBox
    Friend WithEvents cmsCliente As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuSeleccionarCliente As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtEntrega1 As System.Windows.Forms.TextBox
    Friend WithEvents txtIntervencion1 As System.Windows.Forms.TextBox
    Friend WithEvents txtFactura1 As System.Windows.Forms.TextBox
    Friend WithEvents txtContacto As System.Windows.Forms.TextBox
    Friend WithEvents txtTelefono As System.Windows.Forms.TextBox
    Friend WithEvents txtMail As System.Windows.Forms.TextBox
    Friend WithEvents btnRegistrar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents txtIntervencion3 As System.Windows.Forms.TextBox
    Friend WithEvents txtIntervencion2 As System.Windows.Forms.TextBox
    Friend WithEvents txtFactura3 As System.Windows.Forms.TextBox
    Friend WithEvents txtFactura2 As System.Windows.Forms.TextBox
    Friend WithEvents txtEntrega3 As System.Windows.Forms.TextBox
    Friend WithEvents txtEntrega2 As System.Windows.Forms.TextBox
    Friend WithEvents cmsSucursal As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuSeleccionarSucursal As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsIntervencion As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuSeleccionarIntervenciones As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuVerIntervencion As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuEstadoIntervencion As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsFacturas As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuSeleccionarFacturas As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuVerFactura As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuEstadoFactura As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsEntregas As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuVerEntrega As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuEstadoEntrega As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuEditarCliente As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuEditarSucursal As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSeleccionarEntrega As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtVendedorActual As System.Windows.Forms.TextBox
    Friend WithEvents txtVendedorAnterior As System.Windows.Forms.TextBox
    Friend WithEvents txtTipoAbc As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents btnResolver As System.Windows.Forms.Button
    Friend WithEvents btnAbrir As System.Windows.Forms.Button
    Friend WithEvents txtPedido3 As System.Windows.Forms.TextBox
    Friend WithEvents txtPedido2 As System.Windows.Forms.TextBox
    Friend WithEvents txtPedido1 As System.Windows.Forms.TextBox
    Friend WithEvents cmdPedidos As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuSeleccionarPedidos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnAsignar As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents colTicket As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colLinea As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colHora As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUsuario As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colComentarios As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cboAsignar As System.Windows.Forms.ComboBox
    Friend WithEvents btnAgregarComentario As System.Windows.Forms.Button
    Friend WithEvents gpDocumentos As System.Windows.Forms.GroupBox
End Class
