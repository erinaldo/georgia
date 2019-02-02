<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVencimientos
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
        Dim Label3 As System.Windows.Forms.Label
        Dim Label2 As System.Windows.Forms.Label
        Dim Label1 As System.Windows.Forms.Label
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.tree = New System.Windows.Forms.TreeView
        Me.cmArbol = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuDistribucion = New System.Windows.Forms.ToolStripMenuItem
        Me.dtp = New System.Windows.Forms.DateTimePicker
        Me.btnBuscar = New System.Windows.Forms.Button
        Me.btnRecuperar = New System.Windows.Forms.Button
        Me.btnPerdido = New System.Windows.Forms.Button
        Me.btnReagendar = New System.Windows.Forms.Button
        Me.dgvResumen = New System.Windows.Forms.DataGridView
        Me.colCodigo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colDescripcion = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.colCantidad = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colAgente = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colKilos = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.txtSuc = New System.Windows.Forms.TextBox
        Me.txtCodigo = New System.Windows.Forms.TextBox
        Me.txtDireccion = New System.Windows.Forms.TextBox
        Me.txtCliente = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.lstTipos = New System.Windows.Forms.ListBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.dgvDetalle = New System.Windows.Forms.DataGridView
        Me.colSeriec = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCilindro = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colTipo = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.colCapacidad = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.colFabricacion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colItn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colIngreso = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.lblRep = New System.Windows.Forms.Label
        Me.txtTelefono = New System.Windows.Forms.TextBox
        Me.btnCrearIntervención = New System.Windows.Forms.Button
        Me.btnPresupuesto = New System.Windows.Forms.Button
        Me.lblCanje = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.gbComentarios = New System.Windows.Forms.GroupBox
        Me.btnRegistrarComentario = New System.Windows.Forms.Button
        Me.txtComentario = New System.Windows.Forms.TextBox
        Me.lbl639 = New System.Windows.Forms.Label
        Label3 = New System.Windows.Forms.Label
        Label2 = New System.Windows.Forms.Label
        Label1 = New System.Windows.Forms.Label
        Me.cmArbol.SuspendLayout()
        CType(Me.dgvResumen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.gbComentarios.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label3
        '
        Label3.AutoSize = True
        Label3.Location = New System.Drawing.Point(3, 46)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(51, 13)
        Label3.TabIndex = 3
        Label3.Text = "Sucursal:"
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Location = New System.Drawing.Point(4, 23)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(42, 13)
        Label2.TabIndex = 0
        Label2.Text = "Cliente:"
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(3, 72)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(49, 13)
        Label1.TabIndex = 6
        Label1.Text = "Teléfono"
        '
        'tree
        '
        Me.tree.ContextMenuStrip = Me.cmArbol
        Me.tree.Location = New System.Drawing.Point(8, 41)
        Me.tree.Name = "tree"
        Me.tree.Size = New System.Drawing.Size(302, 296)
        Me.tree.TabIndex = 2
        '
        'cmArbol
        '
        Me.cmArbol.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuDistribucion})
        Me.cmArbol.Name = "cmArbol"
        Me.cmArbol.Size = New System.Drawing.Size(230, 26)
        '
        'mnuDistribucion
        '
        Me.mnuDistribucion.Name = "mnuDistribucion"
        Me.mnuDistribucion.Size = New System.Drawing.Size(229, 22)
        Me.mnuDistribucion.Text = "Distribución de Vencimientos"
        '
        'dtp
        '
        Me.dtp.CustomFormat = "MMM/yyyy"
        Me.dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp.Location = New System.Drawing.Point(8, 15)
        Me.dtp.Name = "dtp"
        Me.dtp.Size = New System.Drawing.Size(97, 20)
        Me.dtp.TabIndex = 0
        '
        'btnBuscar
        '
        Me.btnBuscar.Location = New System.Drawing.Point(111, 12)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(75, 23)
        Me.btnBuscar.TabIndex = 1
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'btnRecuperar
        '
        Me.btnRecuperar.Location = New System.Drawing.Point(382, 3)
        Me.btnRecuperar.Name = "btnRecuperar"
        Me.btnRecuperar.Size = New System.Drawing.Size(120, 36)
        Me.btnRecuperar.TabIndex = 54
        Me.btnRecuperar.Text = "Recuperar"
        Me.btnRecuperar.UseVisualStyleBackColor = True
        '
        'btnPerdido
        '
        Me.btnPerdido.Location = New System.Drawing.Point(508, 3)
        Me.btnPerdido.Name = "btnPerdido"
        Me.btnPerdido.Size = New System.Drawing.Size(120, 36)
        Me.btnPerdido.TabIndex = 55
        Me.btnPerdido.Text = "Perdido"
        Me.btnPerdido.UseVisualStyleBackColor = True
        '
        'btnReagendar
        '
        Me.btnReagendar.Location = New System.Drawing.Point(256, 3)
        Me.btnReagendar.Name = "btnReagendar"
        Me.btnReagendar.Size = New System.Drawing.Size(120, 36)
        Me.btnReagendar.TabIndex = 53
        Me.btnReagendar.Text = "Reagendar"
        Me.btnReagendar.UseVisualStyleBackColor = True
        '
        'dgvResumen
        '
        Me.dgvResumen.AllowUserToAddRows = False
        Me.dgvResumen.AllowUserToDeleteRows = False
        Me.dgvResumen.AllowUserToResizeRows = False
        Me.dgvResumen.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvResumen.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.dgvResumen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvResumen.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colCodigo, Me.colDescripcion, Me.colCantidad, Me.colAgente, Me.colKilos})
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvResumen.DefaultCellStyle = DataGridViewCellStyle14
        Me.dgvResumen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvResumen.Location = New System.Drawing.Point(3, 16)
        Me.dgvResumen.Name = "dgvResumen"
        Me.dgvResumen.ReadOnly = True
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvResumen.RowHeadersDefaultCellStyle = DataGridViewCellStyle15
        Me.dgvResumen.Size = New System.Drawing.Size(470, 152)
        Me.dgvResumen.TabIndex = 21
        '
        'colCodigo
        '
        Me.colCodigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.colCodigo.HeaderText = "Codigo"
        Me.colCodigo.Name = "colCodigo"
        Me.colCodigo.ReadOnly = True
        Me.colCodigo.Width = 65
        '
        'colDescripcion
        '
        Me.colDescripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colDescripcion.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.colDescripcion.HeaderText = "Descripción"
        Me.colDescripcion.Name = "colDescripcion"
        Me.colDescripcion.ReadOnly = True
        '
        'colCantidad
        '
        Me.colCantidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colCantidad.DefaultCellStyle = DataGridViewCellStyle13
        Me.colCantidad.HeaderText = "Cantidad"
        Me.colCantidad.Name = "colCantidad"
        Me.colCantidad.ReadOnly = True
        Me.colCantidad.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colCantidad.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colCantidad.Width = 55
        '
        'colAgente
        '
        Me.colAgente.HeaderText = "Agente"
        Me.colAgente.Name = "colAgente"
        Me.colAgente.ReadOnly = True
        Me.colAgente.Visible = False
        Me.colAgente.Width = 66
        '
        'colKilos
        '
        Me.colKilos.HeaderText = "Kilos"
        Me.colKilos.Name = "colKilos"
        Me.colKilos.ReadOnly = True
        Me.colKilos.Visible = False
        Me.colKilos.Width = 54
        '
        'txtSuc
        '
        Me.txtSuc.Location = New System.Drawing.Point(57, 43)
        Me.txtSuc.Name = "txtSuc"
        Me.txtSuc.ReadOnly = True
        Me.txtSuc.Size = New System.Drawing.Size(53, 20)
        Me.txtSuc.TabIndex = 4
        '
        'txtCodigo
        '
        Me.txtCodigo.Location = New System.Drawing.Point(57, 19)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.ReadOnly = True
        Me.txtCodigo.Size = New System.Drawing.Size(53, 20)
        Me.txtCodigo.TabIndex = 1
        '
        'txtDireccion
        '
        Me.txtDireccion.Location = New System.Drawing.Point(116, 43)
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.ReadOnly = True
        Me.txtDireccion.Size = New System.Drawing.Size(213, 20)
        Me.txtDireccion.TabIndex = 5
        '
        'txtCliente
        '
        Me.txtCliente.Location = New System.Drawing.Point(116, 19)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(186, 20)
        Me.txtCliente.TabIndex = 2
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgvResumen)
        Me.GroupBox1.Location = New System.Drawing.Point(316, 117)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(476, 171)
        Me.GroupBox1.TabIndex = 56
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Resumen de vencimientos"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lstTipos)
        Me.GroupBox2.Location = New System.Drawing.Point(798, 120)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(181, 168)
        Me.GroupBox2.TabIndex = 57
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Tipos de intervenciones"
        '
        'lstTipos
        '
        Me.lstTipos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstTipos.FormattingEnabled = True
        Me.lstTipos.Location = New System.Drawing.Point(3, 16)
        Me.lstTipos.Name = "lstTipos"
        Me.lstTipos.Size = New System.Drawing.Size(175, 147)
        Me.lstTipos.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.dgvDetalle)
        Me.GroupBox3.Location = New System.Drawing.Point(316, 341)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(660, 191)
        Me.GroupBox3.TabIndex = 57
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Detalle de vencimientos"
        '
        'dgvDetalle
        '
        Me.dgvDetalle.AllowUserToAddRows = False
        Me.dgvDetalle.AllowUserToDeleteRows = False
        Me.dgvDetalle.AllowUserToResizeRows = False
        Me.dgvDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDetalle.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle16
        Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colSeriec, Me.colCilindro, Me.colTipo, Me.colCapacidad, Me.colFabricacion, Me.colItn, Me.colIngreso})
        DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDetalle.DefaultCellStyle = DataGridViewCellStyle21
        Me.dgvDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDetalle.Location = New System.Drawing.Point(3, 16)
        Me.dgvDetalle.Name = "dgvDetalle"
        Me.dgvDetalle.ReadOnly = True
        DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDetalle.RowHeadersDefaultCellStyle = DataGridViewCellStyle22
        Me.dgvDetalle.Size = New System.Drawing.Size(654, 172)
        Me.dgvDetalle.TabIndex = 21
        '
        'colSeriec
        '
        Me.colSeriec.HeaderText = "Serie"
        Me.colSeriec.Name = "colSeriec"
        Me.colSeriec.ReadOnly = True
        Me.colSeriec.Width = 56
        '
        'colCilindro
        '
        Me.colCilindro.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colCilindro.DefaultCellStyle = DataGridViewCellStyle17
        Me.colCilindro.HeaderText = "Cilindro"
        Me.colCilindro.Name = "colCilindro"
        Me.colCilindro.ReadOnly = True
        Me.colCilindro.Width = 66
        '
        'colTipo
        '
        Me.colTipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.colTipo.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.colTipo.HeaderText = "Tipo"
        Me.colTipo.Name = "colTipo"
        Me.colTipo.ReadOnly = True
        Me.colTipo.Width = 34
        '
        'colCapacidad
        '
        Me.colCapacidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colCapacidad.DefaultCellStyle = DataGridViewCellStyle18
        Me.colCapacidad.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.colCapacidad.HeaderText = "Capacidad"
        Me.colCapacidad.Name = "colCapacidad"
        Me.colCapacidad.ReadOnly = True
        Me.colCapacidad.Width = 64
        '
        'colFabricacion
        '
        Me.colFabricacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle19.Format = "yyyy"
        Me.colFabricacion.DefaultCellStyle = DataGridViewCellStyle19
        Me.colFabricacion.HeaderText = "Fabricación"
        Me.colFabricacion.Name = "colFabricacion"
        Me.colFabricacion.ReadOnly = True
        Me.colFabricacion.Width = 87
        '
        'colItn
        '
        Me.colItn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.colItn.HeaderText = "Ultima Intervención"
        Me.colItn.Name = "colItn"
        Me.colItn.ReadOnly = True
        Me.colItn.Width = 113
        '
        'colIngreso
        '
        Me.colIngreso.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle20.Format = "dd/MM/yy"
        DataGridViewCellStyle20.NullValue = Nothing
        Me.colIngreso.DefaultCellStyle = DataGridViewCellStyle20
        Me.colIngreso.HeaderText = "Último Ingreso"
        Me.colIngreso.Name = "colIngreso"
        Me.colIngreso.ReadOnly = True
        Me.colIngreso.Width = 91
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.lblRep)
        Me.GroupBox4.Controls.Add(Me.txtTelefono)
        Me.GroupBox4.Controls.Add(Label1)
        Me.GroupBox4.Controls.Add(Me.txtCodigo)
        Me.GroupBox4.Controls.Add(Me.txtSuc)
        Me.GroupBox4.Controls.Add(Me.txtDireccion)
        Me.GroupBox4.Controls.Add(Label2)
        Me.GroupBox4.Controls.Add(Me.txtCliente)
        Me.GroupBox4.Controls.Add(Label3)
        Me.GroupBox4.Location = New System.Drawing.Point(316, 12)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(340, 99)
        Me.GroupBox4.TabIndex = 58
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Cliente"
        '
        'lblRep
        '
        Me.lblRep.AutoSize = True
        Me.lblRep.Location = New System.Drawing.Point(308, 23)
        Me.lblRep.Name = "lblRep"
        Me.lblRep.Size = New System.Drawing.Size(0, 13)
        Me.lblRep.TabIndex = 65
        '
        'txtTelefono
        '
        Me.txtTelefono.Location = New System.Drawing.Point(58, 69)
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.ReadOnly = True
        Me.txtTelefono.Size = New System.Drawing.Size(271, 20)
        Me.txtTelefono.TabIndex = 7
        '
        'btnCrearIntervención
        '
        Me.btnCrearIntervención.Location = New System.Drawing.Point(4, 3)
        Me.btnCrearIntervención.Name = "btnCrearIntervención"
        Me.btnCrearIntervención.Size = New System.Drawing.Size(120, 36)
        Me.btnCrearIntervención.TabIndex = 59
        Me.btnCrearIntervención.Text = "Crear Intervención"
        Me.btnCrearIntervención.UseVisualStyleBackColor = True
        '
        'btnPresupuesto
        '
        Me.btnPresupuesto.Location = New System.Drawing.Point(130, 3)
        Me.btnPresupuesto.Name = "btnPresupuesto"
        Me.btnPresupuesto.Size = New System.Drawing.Size(120, 36)
        Me.btnPresupuesto.TabIndex = 60
        Me.btnPresupuesto.Text = "Crear Presupuesto"
        Me.btnPresupuesto.UseVisualStyleBackColor = True
        '
        'lblCanje
        '
        Me.lblCanje.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblCanje.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCanje.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCanje.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCanje.Location = New System.Drawing.Point(677, 23)
        Me.lblCanje.Name = "lblCanje"
        Me.lblCanje.Size = New System.Drawing.Size(296, 35)
        Me.lblCanje.TabIndex = 63
        Me.lblCanje.Text = "APTO PARA CANJE"
        Me.lblCanje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblCanje.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnPresupuesto)
        Me.Panel1.Controls.Add(Me.btnReagendar)
        Me.Panel1.Controls.Add(Me.btnPerdido)
        Me.Panel1.Controls.Add(Me.btnRecuperar)
        Me.Panel1.Controls.Add(Me.btnCrearIntervención)
        Me.Panel1.Enabled = False
        Me.Panel1.Location = New System.Drawing.Point(319, 291)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(660, 46)
        Me.Panel1.TabIndex = 62
        '
        'gbComentarios
        '
        Me.gbComentarios.Controls.Add(Me.btnRegistrarComentario)
        Me.gbComentarios.Controls.Add(Me.txtComentario)
        Me.gbComentarios.Location = New System.Drawing.Point(8, 357)
        Me.gbComentarios.Name = "gbComentarios"
        Me.gbComentarios.Size = New System.Drawing.Size(302, 172)
        Me.gbComentarios.TabIndex = 63
        Me.gbComentarios.TabStop = False
        Me.gbComentarios.Text = "Comentarios"
        '
        'btnRegistrarComentario
        '
        Me.btnRegistrarComentario.Location = New System.Drawing.Point(221, 135)
        Me.btnRegistrarComentario.Name = "btnRegistrarComentario"
        Me.btnRegistrarComentario.Size = New System.Drawing.Size(75, 23)
        Me.btnRegistrarComentario.TabIndex = 1
        Me.btnRegistrarComentario.Text = "Registrar"
        Me.btnRegistrarComentario.UseVisualStyleBackColor = True
        '
        'txtComentario
        '
        Me.txtComentario.Location = New System.Drawing.Point(6, 19)
        Me.txtComentario.Multiline = True
        Me.txtComentario.Name = "txtComentario"
        Me.txtComentario.Size = New System.Drawing.Size(290, 110)
        Me.txtComentario.TabIndex = 0
        '
        'lbl639
        '
        Me.lbl639.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbl639.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl639.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl639.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lbl639.Location = New System.Drawing.Point(677, 66)
        Me.lbl639.Name = "lbl639"
        Me.lbl639.Size = New System.Drawing.Size(296, 35)
        Me.lbl639.TabIndex = 64
        Me.lbl639.Text = "NO TIENE 639"
        Me.lbl639.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbl639.Visible = False
        '
        'frmVencimientos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(988, 543)
        Me.Controls.Add(Me.lbl639)
        Me.Controls.Add(Me.lblCanje)
        Me.Controls.Add(Me.gbComentarios)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.tree)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.dtp)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnBuscar)
        Me.Name = "frmVencimientos"
        Me.ShowInTaskbar = False
        Me.Text = "Vencimientos"
        Me.cmArbol.ResumeLayout(False)
        CType(Me.dgvResumen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.gbComentarios.ResumeLayout(False)
        Me.gbComentarios.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tree As System.Windows.Forms.TreeView
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents dtp As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtDireccion As System.Windows.Forms.TextBox
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents txtSuc As System.Windows.Forms.TextBox
    Friend WithEvents dgvResumen As System.Windows.Forms.DataGridView
    Friend WithEvents btnReagendar As System.Windows.Forms.Button
    Friend WithEvents btnPerdido As System.Windows.Forms.Button
    Friend WithEvents btnRecuperar As System.Windows.Forms.Button
    Friend WithEvents cmArbol As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuDistribucion As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents colCodigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDescripcion As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colCantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lstTipos As System.Windows.Forms.ListBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvDetalle As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btnCrearIntervención As System.Windows.Forms.Button
    Friend WithEvents btnPresupuesto As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblCanje As System.Windows.Forms.Label
    Friend WithEvents gbComentarios As System.Windows.Forms.GroupBox
    Friend WithEvents txtComentario As System.Windows.Forms.TextBox
    Friend WithEvents btnRegistrarComentario As System.Windows.Forms.Button
    Friend WithEvents colSeriec As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCilindro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTipo As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colCapacidad As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colFabricacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIngreso As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtTelefono As System.Windows.Forms.TextBox
    Friend WithEvents lbl639 As System.Windows.Forms.Label
    Friend WithEvents colAgente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colKilos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblRep As System.Windows.Forms.Label
End Class
