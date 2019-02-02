<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCotizadorV2
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
        Dim SplitContainer1 As System.Windows.Forms.SplitContainer
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim Label14 As System.Windows.Forms.Label
        Dim Label9 As System.Windows.Forms.Label
        Dim Label8 As System.Windows.Forms.Label
        Dim Label6 As System.Windows.Forms.Label
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim Label3 As System.Windows.Forms.Label
        Dim Label2 As System.Windows.Forms.Label
        Dim Label7 As System.Windows.Forms.Label
        Dim Label5 As System.Windows.Forms.Label
        Dim Label22 As System.Windows.Forms.Label
        Dim Label21 As System.Windows.Forms.Label
        Dim Label13 As System.Windows.Forms.Label
        Dim Label12 As System.Windows.Forms.Label
        Dim Label25 As System.Windows.Forms.Label
        Dim Label4 As System.Windows.Forms.Label
        Dim Label11 As System.Windows.Forms.Label
        Dim Label20 As System.Windows.Forms.Label
        Dim Label1 As System.Windows.Forms.Label
        Me.grTipo = New System.Windows.Forms.GroupBox
        Me.rbVendedores = New System.Windows.Forms.RadioButton
        Me.rbCaa = New System.Windows.Forms.RadioButton
        Me.rbTodo = New System.Windows.Forms.RadioButton
        Me.chkRecargas = New System.Windows.Forms.CheckBox
        Me.chkPedidos = New System.Windows.Forms.CheckBox
        Me.chkPendiente = New System.Windows.Forms.CheckBox
        Me.btnBuscar = New System.Windows.Forms.Button
        Me.txtBuscar = New System.Windows.Forms.TextBox
        Me.dgv2 = New System.Windows.Forms.DataGridView
        Me.col2Nro = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col2Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col2Cliente = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.suc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col2Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col2Vend = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cboTipo2 = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.lblReferencia = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtIntervencionRechazo = New System.Windows.Forms.TextBox
        Me.btnRechazo = New System.Windows.Forms.Button
        Me.gbxLicitacion = New System.Windows.Forms.GroupBox
        Me.txtLicitacion = New System.Windows.Forms.TextBox
        Me.cms = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuSeleccionar = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuEditar = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuAbrirPresupuesto = New System.Windows.Forms.ToolStripMenuItem
        Me.cboLicitacion = New System.Windows.Forms.ComboBox
        Me.txtDesaprobado = New System.Windows.Forms.Label
        Me.btnDesaprobar = New System.Windows.Forms.Button
        Me.btnFlete = New System.Windows.Forms.Button
        Me.btnPresupuesto = New System.Windows.Forms.Button
        Me.txtPresupuesto = New System.Windows.Forms.TextBox
        Me.dgv = New System.Windows.Forms.DataGridView
        Me.colNro = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colLinea = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCodigo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colDescripcion = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.colCant = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colPrecio = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colSugerido = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colTotal = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.txtPedido = New System.Windows.Forms.TextBox
        Me.btnPedido = New System.Windows.Forms.Button
        Me.gbxSociedad = New System.Windows.Forms.GroupBox
        Me.cboSociedad = New System.Windows.Forms.ComboBox
        Me.cboEntrega = New System.Windows.Forms.ComboBox
        Me.chkH = New System.Windows.Forms.CheckBox
        Me.txtTotalII = New System.Windows.Forms.TextBox
        Me.gbxOc = New System.Windows.Forms.GroupBox
        Me.txtOC = New System.Windows.Forms.TextBox
        Me.btnVerOt = New System.Windows.Forms.Button
        Me.btnExaminarOt = New System.Windows.Forms.Button
        Me.btnBorrarOt = New System.Windows.Forms.Button
        Me.txtTotalAI = New System.Windows.Forms.TextBox
        Me.btnDuplicar = New System.Windows.Forms.Button
        Me.btnNuevoPedido = New System.Windows.Forms.Button
        Me.btnBorrar = New System.Windows.Forms.Button
        Me.gbxSucursal = New System.Windows.Forms.GroupBox
        Me.txtLocalidad = New System.Windows.Forms.TextBox
        Me.txtNombreExpreso = New System.Windows.Forms.TextBox
        Me.txtCodigoExpreso = New System.Windows.Forms.TextBox
        Me.txtDomicilio = New System.Windows.Forms.TextBox
        Me.txtCodigoSucursal = New System.Windows.Forms.TextBox
        Me.txtHasta2 = New System.Windows.Forms.TextBox
        Me.txtCelularContacto = New System.Windows.Forms.TextBox
        Me.txtDesde2 = New System.Windows.Forms.TextBox
        Me.txtDesde1 = New System.Windows.Forms.TextBox
        Me.txtNombreContacto = New System.Windows.Forms.TextBox
        Me.txtHasta1 = New System.Windows.Forms.TextBox
        Me.cboEstado = New System.Windows.Forms.ComboBox
        Me.btnGrabar = New System.Windows.Forms.Button
        Me.gbxCliente = New System.Windows.Forms.GroupBox
        Me.txtClase = New System.Windows.Forms.TextBox
        Me.lblHonorarios = New System.Windows.Forms.Label
        Me.chkAVentas = New System.Windows.Forms.CheckBox
        Me.chkFcRto = New System.Windows.Forms.CheckBox
        Me.txtNombreCliente = New System.Windows.Forms.TextBox
        Me.txtCodigoCliente = New System.Windows.Forms.TextBox
        Me.cboCondicionPago = New System.Windows.Forms.ComboBox
        Me.txtObs = New System.Windows.Forms.TextBox
        Me.btnNuevoPresupuesto = New System.Windows.Forms.Button
        Me.cboTipo = New System.Windows.Forms.ComboBox
        Me.txtFecha = New System.Windows.Forms.TextBox
        Me.txtNro = New System.Windows.Forms.TextBox
        Me.mnu2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuSeleccionArticulo = New System.Windows.Forms.ToolStripMenuItem
        SplitContainer1 = New System.Windows.Forms.SplitContainer
        Label14 = New System.Windows.Forms.Label
        Label9 = New System.Windows.Forms.Label
        Label8 = New System.Windows.Forms.Label
        Label6 = New System.Windows.Forms.Label
        Label3 = New System.Windows.Forms.Label
        Label2 = New System.Windows.Forms.Label
        Label7 = New System.Windows.Forms.Label
        Label5 = New System.Windows.Forms.Label
        Label22 = New System.Windows.Forms.Label
        Label21 = New System.Windows.Forms.Label
        Label13 = New System.Windows.Forms.Label
        Label12 = New System.Windows.Forms.Label
        Label25 = New System.Windows.Forms.Label
        Label4 = New System.Windows.Forms.Label
        Label11 = New System.Windows.Forms.Label
        Label20 = New System.Windows.Forms.Label
        Label1 = New System.Windows.Forms.Label
        SplitContainer1.Panel1.SuspendLayout()
        SplitContainer1.Panel2.SuspendLayout()
        SplitContainer1.SuspendLayout()
        Me.grTipo.SuspendLayout()
        CType(Me.dgv2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.gbxLicitacion.SuspendLayout()
        Me.cms.SuspendLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxSociedad.SuspendLayout()
        Me.gbxOc.SuspendLayout()
        Me.gbxSucursal.SuspendLayout()
        Me.gbxCliente.SuspendLayout()
        Me.mnu2.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        SplitContainer1.Location = New System.Drawing.Point(0, 0)
        SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        SplitContainer1.Panel1.Controls.Add(Me.grTipo)
        SplitContainer1.Panel1.Controls.Add(Me.chkRecargas)
        SplitContainer1.Panel1.Controls.Add(Me.chkPedidos)
        SplitContainer1.Panel1.Controls.Add(Me.chkPendiente)
        SplitContainer1.Panel1.Controls.Add(Me.btnBuscar)
        SplitContainer1.Panel1.Controls.Add(Me.txtBuscar)
        SplitContainer1.Panel1.Controls.Add(Me.dgv2)
        SplitContainer1.Panel1.Controls.Add(Label14)
        '
        'SplitContainer1.Panel2
        '
        SplitContainer1.Panel2.Controls.Add(Me.lblReferencia)
        SplitContainer1.Panel2.Controls.Add(Me.GroupBox1)
        SplitContainer1.Panel2.Controls.Add(Me.gbxLicitacion)
        SplitContainer1.Panel2.Controls.Add(Me.txtDesaprobado)
        SplitContainer1.Panel2.Controls.Add(Me.btnDesaprobar)
        SplitContainer1.Panel2.Controls.Add(Me.btnFlete)
        SplitContainer1.Panel2.Controls.Add(Me.btnPresupuesto)
        SplitContainer1.Panel2.Controls.Add(Label6)
        SplitContainer1.Panel2.Controls.Add(Me.txtPresupuesto)
        SplitContainer1.Panel2.Controls.Add(Me.dgv)
        SplitContainer1.Panel2.Controls.Add(Me.txtPedido)
        SplitContainer1.Panel2.Controls.Add(Me.btnPedido)
        SplitContainer1.Panel2.Controls.Add(Label3)
        SplitContainer1.Panel2.Controls.Add(Me.gbxSociedad)
        SplitContainer1.Panel2.Controls.Add(Me.txtTotalII)
        SplitContainer1.Panel2.Controls.Add(Me.gbxOc)
        SplitContainer1.Panel2.Controls.Add(Me.txtTotalAI)
        SplitContainer1.Panel2.Controls.Add(Me.btnDuplicar)
        SplitContainer1.Panel2.Controls.Add(Me.btnNuevoPedido)
        SplitContainer1.Panel2.Controls.Add(Me.btnBorrar)
        SplitContainer1.Panel2.Controls.Add(Me.gbxSucursal)
        SplitContainer1.Panel2.Controls.Add(Me.cboEstado)
        SplitContainer1.Panel2.Controls.Add(Me.btnGrabar)
        SplitContainer1.Panel2.Controls.Add(Me.gbxCliente)
        SplitContainer1.Panel2.Controls.Add(Me.txtObs)
        SplitContainer1.Panel2.Controls.Add(Me.btnNuevoPresupuesto)
        SplitContainer1.Panel2.Controls.Add(Label4)
        SplitContainer1.Panel2.Controls.Add(Label11)
        SplitContainer1.Panel2.Controls.Add(Me.cboTipo)
        SplitContainer1.Panel2.Controls.Add(Me.txtFecha)
        SplitContainer1.Panel2.Controls.Add(Label20)
        SplitContainer1.Panel2.Controls.Add(Me.txtNro)
        SplitContainer1.Panel2.Controls.Add(Label1)
        SplitContainer1.Size = New System.Drawing.Size(1153, 612)
        SplitContainer1.SplitterDistance = 327
        SplitContainer1.TabIndex = 0
        '
        'grTipo
        '
        Me.grTipo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grTipo.Controls.Add(Me.rbVendedores)
        Me.grTipo.Controls.Add(Me.rbCaa)
        Me.grTipo.Controls.Add(Me.rbTodo)
        Me.grTipo.Location = New System.Drawing.Point(12, 510)
        Me.grTipo.Name = "grTipo"
        Me.grTipo.Size = New System.Drawing.Size(303, 57)
        Me.grTipo.TabIndex = 11
        Me.grTipo.TabStop = False
        Me.grTipo.Text = "Tipos"
        '
        'rbVendedores
        '
        Me.rbVendedores.AutoSize = True
        Me.rbVendedores.Location = New System.Drawing.Point(197, 26)
        Me.rbVendedores.Name = "rbVendedores"
        Me.rbVendedores.Size = New System.Drawing.Size(82, 17)
        Me.rbVendedores.TabIndex = 2
        Me.rbVendedores.Text = "Vendedores"
        Me.rbVendedores.UseVisualStyleBackColor = True
        '
        'rbCaa
        '
        Me.rbCaa.AutoSize = True
        Me.rbCaa.Location = New System.Drawing.Point(103, 26)
        Me.rbCaa.Name = "rbCaa"
        Me.rbCaa.Size = New System.Drawing.Size(71, 17)
        Me.rbCaa.TabIndex = 1
        Me.rbCaa.Text = "CA / CAA"
        Me.rbCaa.UseVisualStyleBackColor = True
        '
        'rbTodo
        '
        Me.rbTodo.AutoSize = True
        Me.rbTodo.Checked = True
        Me.rbTodo.Location = New System.Drawing.Point(22, 27)
        Me.rbTodo.Name = "rbTodo"
        Me.rbTodo.Size = New System.Drawing.Size(55, 17)
        Me.rbTodo.TabIndex = 0
        Me.rbTodo.TabStop = True
        Me.rbTodo.Text = "Todos"
        Me.rbTodo.UseVisualStyleBackColor = True
        '
        'chkRecargas
        '
        Me.chkRecargas.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkRecargas.AutoSize = True
        Me.chkRecargas.Location = New System.Drawing.Point(115, 487)
        Me.chkRecargas.Name = "chkRecargas"
        Me.chkRecargas.Size = New System.Drawing.Size(85, 17)
        Me.chkRecargas.TabIndex = 10
        Me.chkRecargas.Text = "P. Recargas"
        Me.chkRecargas.UseVisualStyleBackColor = True
        '
        'chkPedidos
        '
        Me.chkPedidos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkPedidos.AutoSize = True
        Me.chkPedidos.Location = New System.Drawing.Point(12, 487)
        Me.chkPedidos.Name = "chkPedidos"
        Me.chkPedidos.Size = New System.Drawing.Size(77, 17)
        Me.chkPedidos.TabIndex = 9
        Me.chkPedidos.Text = "P. Pedidos"
        Me.chkPedidos.UseVisualStyleBackColor = True
        '
        'chkPendiente
        '
        Me.chkPendiente.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkPendiente.AutoSize = True
        Me.chkPendiente.Checked = True
        Me.chkPendiente.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPendiente.Location = New System.Drawing.Point(12, 461)
        Me.chkPendiente.Name = "chkPendiente"
        Me.chkPendiente.Size = New System.Drawing.Size(97, 17)
        Me.chkPendiente.TabIndex = 8
        Me.chkPendiente.Text = "Solo pendiente"
        Me.chkPendiente.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnBuscar.Location = New System.Drawing.Point(12, 573)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(303, 36)
        Me.btnBuscar.TabIndex = 7
        Me.btnBuscar.TabStop = False
        Me.btnBuscar.Text = "Actualizar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'txtBuscar
        '
        Me.txtBuscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtBuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBuscar.Location = New System.Drawing.Point(233, 457)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(82, 20)
        Me.txtBuscar.TabIndex = 2
        Me.txtBuscar.TabStop = False
        '
        'dgv2
        '
        Me.dgv2.AllowUserToAddRows = False
        Me.dgv2.AllowUserToDeleteRows = False
        Me.dgv2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv2.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col2Nro, Me.col2Fecha, Me.col2Cliente, Me.suc, Me.col2Nombre, Me.col2Vend, Me.cboTipo2})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv2.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgv2.Location = New System.Drawing.Point(3, 3)
        Me.dgv2.Name = "dgv2"
        Me.dgv2.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv2.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgv2.Size = New System.Drawing.Size(321, 448)
        Me.dgv2.TabIndex = 0
        Me.dgv2.TabStop = False
        '
        'col2Nro
        '
        Me.col2Nro.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.col2Nro.DefaultCellStyle = DataGridViewCellStyle2
        Me.col2Nro.HeaderText = "Nro"
        Me.col2Nro.Name = "col2Nro"
        Me.col2Nro.ReadOnly = True
        Me.col2Nro.Width = 49
        '
        'col2Fecha
        '
        Me.col2Fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.col2Fecha.HeaderText = "Fecha"
        Me.col2Fecha.Name = "col2Fecha"
        Me.col2Fecha.ReadOnly = True
        Me.col2Fecha.Width = 62
        '
        'col2Cliente
        '
        Me.col2Cliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.col2Cliente.HeaderText = "Cliente"
        Me.col2Cliente.Name = "col2Cliente"
        Me.col2Cliente.ReadOnly = True
        Me.col2Cliente.Width = 64
        '
        'suc
        '
        Me.suc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.suc.HeaderText = "Suc"
        Me.suc.Name = "suc"
        Me.suc.ReadOnly = True
        Me.suc.Width = 51
        '
        'col2Nombre
        '
        Me.col2Nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.col2Nombre.HeaderText = "Nombre"
        Me.col2Nombre.Name = "col2Nombre"
        Me.col2Nombre.ReadOnly = True
        Me.col2Nombre.Width = 69
        '
        'col2Vend
        '
        Me.col2Vend.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.col2Vend.HeaderText = "Vend"
        Me.col2Vend.Name = "col2Vend"
        Me.col2Vend.ReadOnly = True
        Me.col2Vend.Width = 57
        '
        'cboTipo2
        '
        Me.cboTipo2.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.cboTipo2.HeaderText = "Tipo"
        Me.cboTipo2.Name = "cboTipo2"
        Me.cboTipo2.ReadOnly = True
        '
        'Label14
        '
        Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Label14.AutoSize = True
        Label14.Location = New System.Drawing.Point(158, 461)
        Label14.Name = "Label14"
        Label14.Size = New System.Drawing.Size(69, 13)
        Label14.TabIndex = 1
        Label14.Text = "Filtrar cliente:"
        '
        'lblReferencia
        '
        Me.lblReferencia.AutoSize = True
        Me.lblReferencia.Location = New System.Drawing.Point(399, 517)
        Me.lblReferencia.Name = "lblReferencia"
        Me.lblReferencia.Size = New System.Drawing.Size(0, 13)
        Me.lblReferencia.TabIndex = 17
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtIntervencionRechazo)
        Me.GroupBox1.Controls.Add(Me.btnRechazo)
        Me.GroupBox1.Location = New System.Drawing.Point(708, 158)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(96, 82)
        Me.GroupBox1.TabIndex = 31
        Me.GroupBox1.TabStop = False
        '
        'txtIntervencionRechazo
        '
        Me.txtIntervencionRechazo.Location = New System.Drawing.Point(7, 52)
        Me.txtIntervencionRechazo.Name = "txtIntervencionRechazo"
        Me.txtIntervencionRechazo.ReadOnly = True
        Me.txtIntervencionRechazo.Size = New System.Drawing.Size(83, 20)
        Me.txtIntervencionRechazo.TabIndex = 1
        '
        'btnRechazo
        '
        Me.btnRechazo.Enabled = False
        Me.btnRechazo.Location = New System.Drawing.Point(11, 13)
        Me.btnRechazo.Name = "btnRechazo"
        Me.btnRechazo.Size = New System.Drawing.Size(79, 35)
        Me.btnRechazo.TabIndex = 0
        Me.btnRechazo.Text = "Rechazo"
        Me.btnRechazo.UseVisualStyleBackColor = True
        '
        'gbxLicitacion
        '
        Me.gbxLicitacion.Controls.Add(Me.txtLicitacion)
        Me.gbxLicitacion.Controls.Add(Label9)
        Me.gbxLicitacion.Controls.Add(Me.cboLicitacion)
        Me.gbxLicitacion.Controls.Add(Label8)
        Me.gbxLicitacion.Location = New System.Drawing.Point(9, 246)
        Me.gbxLicitacion.Name = "gbxLicitacion"
        Me.gbxLicitacion.Size = New System.Drawing.Size(801, 41)
        Me.gbxLicitacion.TabIndex = 30
        Me.gbxLicitacion.TabStop = False
        Me.gbxLicitacion.Text = "Licitación"
        '
        'txtLicitacion
        '
        Me.txtLicitacion.ContextMenuStrip = Me.cms
        Me.txtLicitacion.Location = New System.Drawing.Point(443, 16)
        Me.txtLicitacion.Name = "txtLicitacion"
        Me.txtLicitacion.Size = New System.Drawing.Size(196, 20)
        Me.txtLicitacion.TabIndex = 16
        '
        'cms
        '
        Me.cms.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSeleccionar, Me.mnuEditar, Me.mnuAbrirPresupuesto})
        Me.cms.Name = "cms"
        Me.cms.Size = New System.Drawing.Size(178, 70)
        '
        'mnuSeleccionar
        '
        Me.mnuSeleccionar.Name = "mnuSeleccionar"
        Me.mnuSeleccionar.Size = New System.Drawing.Size(177, 22)
        Me.mnuSeleccionar.Text = "Seleccionar..."
        '
        'mnuEditar
        '
        Me.mnuEditar.Name = "mnuEditar"
        Me.mnuEditar.Size = New System.Drawing.Size(177, 22)
        Me.mnuEditar.Text = "Editar..."
        '
        'mnuAbrirPresupuesto
        '
        Me.mnuAbrirPresupuesto.Name = "mnuAbrirPresupuesto"
        Me.mnuAbrirPresupuesto.Size = New System.Drawing.Size(177, 22)
        Me.mnuAbrirPresupuesto.Text = "Abrir presupuesto..."
        '
        'Label9
        '
        Label9.AutoSize = True
        Label9.Location = New System.Drawing.Point(342, 19)
        Label9.Name = "Label9"
        Label9.Size = New System.Drawing.Size(95, 13)
        Label9.TabIndex = 7
        Label9.Text = "Número Licitación:"
        '
        'cboLicitacion
        '
        Me.cboLicitacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLicitacion.FormattingEnabled = True
        Me.cboLicitacion.Location = New System.Drawing.Point(103, 14)
        Me.cboLicitacion.Name = "cboLicitacion"
        Me.cboLicitacion.Size = New System.Drawing.Size(220, 21)
        Me.cboLicitacion.TabIndex = 6
        '
        'Label8
        '
        Label8.AutoSize = True
        Label8.Location = New System.Drawing.Point(13, 19)
        Label8.Name = "Label8"
        Label8.Size = New System.Drawing.Size(79, 13)
        Label8.TabIndex = 5
        Label8.Text = "Tipo Licitación:"
        '
        'txtDesaprobado
        '
        Me.txtDesaprobado.AutoSize = True
        Me.txtDesaprobado.Location = New System.Drawing.Point(721, 563)
        Me.txtDesaprobado.Name = "txtDesaprobado"
        Me.txtDesaprobado.Size = New System.Drawing.Size(71, 13)
        Me.txtDesaprobado.TabIndex = 29
        Me.txtDesaprobado.Text = "Desaprobado"
        Me.txtDesaprobado.Visible = False
        '
        'btnDesaprobar
        '
        Me.btnDesaprobar.Enabled = False
        Me.btnDesaprobar.Location = New System.Drawing.Point(256, 585)
        Me.btnDesaprobar.Name = "btnDesaprobar"
        Me.btnDesaprobar.Size = New System.Drawing.Size(72, 22)
        Me.btnDesaprobar.TabIndex = 28
        Me.btnDesaprobar.Text = "Desaprobar"
        Me.btnDesaprobar.UseVisualStyleBackColor = True
        '
        'btnFlete
        '
        Me.btnFlete.Enabled = False
        Me.btnFlete.Location = New System.Drawing.Point(742, 523)
        Me.btnFlete.Name = "btnFlete"
        Me.btnFlete.Size = New System.Drawing.Size(75, 23)
        Me.btnFlete.TabIndex = 27
        Me.btnFlete.TabStop = False
        Me.btnFlete.Text = "Flete"
        Me.btnFlete.UseVisualStyleBackColor = True
        '
        'btnPresupuesto
        '
        Me.btnPresupuesto.Enabled = False
        Me.btnPresupuesto.Location = New System.Drawing.Point(521, 558)
        Me.btnPresupuesto.Name = "btnPresupuesto"
        Me.btnPresupuesto.Size = New System.Drawing.Size(75, 23)
        Me.btnPresupuesto.TabIndex = 20
        Me.btnPresupuesto.TabStop = False
        Me.btnPresupuesto.Text = "Presupuesto"
        Me.btnPresupuesto.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Label6.AutoSize = True
        Label6.Location = New System.Drawing.Point(362, 562)
        Label6.Name = "Label6"
        Label6.Size = New System.Drawing.Size(44, 13)
        Label6.TabIndex = 16
        Label6.Text = "Total AI"
        '
        'txtPresupuesto
        '
        Me.txtPresupuesto.ContextMenuStrip = Me.cms
        Me.txtPresupuesto.Location = New System.Drawing.Point(602, 558)
        Me.txtPresupuesto.Name = "txtPresupuesto"
        Me.txtPresupuesto.ReadOnly = True
        Me.txtPresupuesto.Size = New System.Drawing.Size(113, 20)
        Me.txtPresupuesto.TabIndex = 21
        Me.txtPresupuesto.TabStop = False
        '
        'dgv
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colNro, Me.colLinea, Me.colCodigo, Me.colDescripcion, Me.colCant, Me.colPrecio, Me.colSugerido, Me.colTotal})
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv.DefaultCellStyle = DataGridViewCellStyle10
        Me.dgv.Location = New System.Drawing.Point(9, 293)
        Me.dgv.Name = "dgv"
        Me.dgv.ReadOnly = True
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv.RowHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.dgv.Size = New System.Drawing.Size(802, 221)
        Me.dgv.TabIndex = 13
        '
        'colNro
        '
        Me.colNro.HeaderText = "Numero"
        Me.colNro.Name = "colNro"
        Me.colNro.ReadOnly = True
        Me.colNro.Visible = False
        '
        'colLinea
        '
        Me.colLinea.HeaderText = "Linea"
        Me.colLinea.Name = "colLinea"
        Me.colLinea.ReadOnly = True
        Me.colLinea.Visible = False
        '
        'colCodigo
        '
        Me.colCodigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colCodigo.HeaderText = "Codigo"
        Me.colCodigo.Name = "colCodigo"
        Me.colCodigo.ReadOnly = True
        Me.colCodigo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colCodigo.Width = 65
        '
        'colDescripcion
        '
        Me.colDescripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.colDescripcion.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.colDescripcion.HeaderText = "Descripción"
        Me.colDescripcion.Name = "colDescripcion"
        Me.colDescripcion.ReadOnly = True
        Me.colDescripcion.Width = 69
        '
        'colCant
        '
        Me.colCant.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colCant.DefaultCellStyle = DataGridViewCellStyle6
        Me.colCant.HeaderText = "Cantidad"
        Me.colCant.Name = "colCant"
        Me.colCant.ReadOnly = True
        Me.colCant.Width = 74
        '
        'colPrecio
        '
        Me.colPrecio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "N2"
        Me.colPrecio.DefaultCellStyle = DataGridViewCellStyle7
        Me.colPrecio.HeaderText = "Precio"
        Me.colPrecio.Name = "colPrecio"
        Me.colPrecio.ReadOnly = True
        Me.colPrecio.Width = 62
        '
        'colSugerido
        '
        Me.colSugerido.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Format = "N2"
        Me.colSugerido.DefaultCellStyle = DataGridViewCellStyle8
        Me.colSugerido.HeaderText = "Sugerido"
        Me.colSugerido.Name = "colSugerido"
        Me.colSugerido.ReadOnly = True
        Me.colSugerido.Width = 74
        '
        'colTotal
        '
        Me.colTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.Format = "N2"
        Me.colTotal.DefaultCellStyle = DataGridViewCellStyle9
        Me.colTotal.HeaderText = "Total"
        Me.colTotal.Name = "colTotal"
        Me.colTotal.ReadOnly = True
        Me.colTotal.Width = 56
        '
        'txtPedido
        '
        Me.txtPedido.Location = New System.Drawing.Point(603, 587)
        Me.txtPedido.Name = "txtPedido"
        Me.txtPedido.ReadOnly = True
        Me.txtPedido.Size = New System.Drawing.Size(113, 20)
        Me.txtPedido.TabIndex = 23
        Me.txtPedido.TabStop = False
        '
        'btnPedido
        '
        Me.btnPedido.Enabled = False
        Me.btnPedido.Location = New System.Drawing.Point(522, 585)
        Me.btnPedido.Name = "btnPedido"
        Me.btnPedido.Size = New System.Drawing.Size(75, 23)
        Me.btnPedido.TabIndex = 22
        Me.btnPedido.TabStop = False
        Me.btnPedido.Text = "Pedido"
        Me.btnPedido.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Label3.AutoSize = True
        Label3.Location = New System.Drawing.Point(362, 587)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(40, 13)
        Label3.TabIndex = 18
        Label3.Text = "Total II"
        '
        'gbxSociedad
        '
        Me.gbxSociedad.Controls.Add(Me.cboSociedad)
        Me.gbxSociedad.Controls.Add(Label2)
        Me.gbxSociedad.Controls.Add(Me.cboEntrega)
        Me.gbxSociedad.Controls.Add(Label7)
        Me.gbxSociedad.Controls.Add(Me.chkH)
        Me.gbxSociedad.Enabled = False
        Me.gbxSociedad.Location = New System.Drawing.Point(354, 158)
        Me.gbxSociedad.Name = "gbxSociedad"
        Me.gbxSociedad.Size = New System.Drawing.Size(346, 82)
        Me.gbxSociedad.TabIndex = 12
        Me.gbxSociedad.TabStop = False
        '
        'cboSociedad
        '
        Me.cboSociedad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSociedad.FormattingEnabled = True
        Me.cboSociedad.Location = New System.Drawing.Point(69, 19)
        Me.cboSociedad.Name = "cboSociedad"
        Me.cboSociedad.Size = New System.Drawing.Size(231, 21)
        Me.cboSociedad.TabIndex = 1
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Location = New System.Drawing.Point(8, 22)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(55, 13)
        Label2.TabIndex = 0
        Label2.Text = "Sociedad:"
        '
        'cboEntrega
        '
        Me.cboEntrega.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEntrega.FormattingEnabled = True
        Me.cboEntrega.Location = New System.Drawing.Point(69, 45)
        Me.cboEntrega.Name = "cboEntrega"
        Me.cboEntrega.Size = New System.Drawing.Size(231, 21)
        Me.cboEntrega.TabIndex = 4
        '
        'Label7
        '
        Label7.AutoSize = True
        Label7.Location = New System.Drawing.Point(12, 50)
        Label7.Name = "Label7"
        Label7.Size = New System.Drawing.Size(47, 13)
        Label7.TabIndex = 3
        Label7.Text = "Entrega:"
        '
        'chkH
        '
        Me.chkH.AutoSize = True
        Me.chkH.Enabled = False
        Me.chkH.Location = New System.Drawing.Point(306, 22)
        Me.chkH.Name = "chkH"
        Me.chkH.Size = New System.Drawing.Size(34, 17)
        Me.chkH.TabIndex = 2
        Me.chkH.Text = "H"
        Me.chkH.UseVisualStyleBackColor = True
        '
        'txtTotalII
        '
        Me.txtTotalII.Location = New System.Drawing.Point(427, 585)
        Me.txtTotalII.Name = "txtTotalII"
        Me.txtTotalII.ReadOnly = True
        Me.txtTotalII.Size = New System.Drawing.Size(84, 20)
        Me.txtTotalII.TabIndex = 19
        Me.txtTotalII.TabStop = False
        Me.txtTotalII.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'gbxOc
        '
        Me.gbxOc.Controls.Add(Me.txtOC)
        Me.gbxOc.Controls.Add(Me.btnVerOt)
        Me.gbxOc.Controls.Add(Me.btnExaminarOt)
        Me.gbxOc.Controls.Add(Me.btnBorrarOt)
        Me.gbxOc.Enabled = False
        Me.gbxOc.Location = New System.Drawing.Point(9, 158)
        Me.gbxOc.Name = "gbxOc"
        Me.gbxOc.Size = New System.Drawing.Size(337, 82)
        Me.gbxOc.TabIndex = 11
        Me.gbxOc.TabStop = False
        Me.gbxOc.Text = "Orden de Compra"
        '
        'txtOC
        '
        Me.txtOC.Location = New System.Drawing.Point(6, 19)
        Me.txtOC.MaxLength = 20
        Me.txtOC.Name = "txtOC"
        Me.txtOC.Size = New System.Drawing.Size(244, 20)
        Me.txtOC.TabIndex = 0
        '
        'btnVerOt
        '
        Me.btnVerOt.Location = New System.Drawing.Point(10, 50)
        Me.btnVerOt.Name = "btnVerOt"
        Me.btnVerOt.Size = New System.Drawing.Size(75, 23)
        Me.btnVerOt.TabIndex = 2
        Me.btnVerOt.TabStop = False
        Me.btnVerOt.Text = "Ver"
        Me.btnVerOt.UseVisualStyleBackColor = True
        '
        'btnExaminarOt
        '
        Me.btnExaminarOt.Location = New System.Drawing.Point(256, 19)
        Me.btnExaminarOt.Name = "btnExaminarOt"
        Me.btnExaminarOt.Size = New System.Drawing.Size(75, 23)
        Me.btnExaminarOt.TabIndex = 1
        Me.btnExaminarOt.Text = "Examinar"
        Me.btnExaminarOt.UseVisualStyleBackColor = True
        '
        'btnBorrarOt
        '
        Me.btnBorrarOt.Location = New System.Drawing.Point(91, 50)
        Me.btnBorrarOt.Name = "btnBorrarOt"
        Me.btnBorrarOt.Size = New System.Drawing.Size(75, 23)
        Me.btnBorrarOt.TabIndex = 3
        Me.btnBorrarOt.TabStop = False
        Me.btnBorrarOt.Text = "Borrar"
        Me.btnBorrarOt.UseVisualStyleBackColor = True
        '
        'txtTotalAI
        '
        Me.txtTotalAI.Location = New System.Drawing.Point(427, 558)
        Me.txtTotalAI.Name = "txtTotalAI"
        Me.txtTotalAI.ReadOnly = True
        Me.txtTotalAI.Size = New System.Drawing.Size(84, 20)
        Me.txtTotalAI.TabIndex = 17
        Me.txtTotalAI.TabStop = False
        Me.txtTotalAI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnDuplicar
        '
        Me.btnDuplicar.Enabled = False
        Me.btnDuplicar.Location = New System.Drawing.Point(97, 584)
        Me.btnDuplicar.Name = "btnDuplicar"
        Me.btnDuplicar.Size = New System.Drawing.Size(75, 23)
        Me.btnDuplicar.TabIndex = 25
        Me.btnDuplicar.Text = "Duplicar"
        Me.btnDuplicar.UseVisualStyleBackColor = True
        '
        'btnNuevoPedido
        '
        Me.btnNuevoPedido.Location = New System.Drawing.Point(9, 12)
        Me.btnNuevoPedido.Name = "btnNuevoPedido"
        Me.btnNuevoPedido.Size = New System.Drawing.Size(109, 23)
        Me.btnNuevoPedido.TabIndex = 0
        Me.btnNuevoPedido.TabStop = False
        Me.btnNuevoPedido.Text = "Nuevo Pedido"
        Me.btnNuevoPedido.UseVisualStyleBackColor = True
        '
        'btnBorrar
        '
        Me.btnBorrar.Enabled = False
        Me.btnBorrar.Location = New System.Drawing.Point(178, 585)
        Me.btnBorrar.Name = "btnBorrar"
        Me.btnBorrar.Size = New System.Drawing.Size(72, 22)
        Me.btnBorrar.TabIndex = 26
        Me.btnBorrar.Text = "Borrar"
        Me.btnBorrar.UseVisualStyleBackColor = True
        '
        'gbxSucursal
        '
        Me.gbxSucursal.Controls.Add(Me.txtLocalidad)
        Me.gbxSucursal.Controls.Add(Me.txtNombreExpreso)
        Me.gbxSucursal.Controls.Add(Me.txtCodigoExpreso)
        Me.gbxSucursal.Controls.Add(Label5)
        Me.gbxSucursal.Controls.Add(Me.txtDomicilio)
        Me.gbxSucursal.Controls.Add(Me.txtCodigoSucursal)
        Me.gbxSucursal.Controls.Add(Me.txtHasta2)
        Me.gbxSucursal.Controls.Add(Label22)
        Me.gbxSucursal.Controls.Add(Me.txtCelularContacto)
        Me.gbxSucursal.Controls.Add(Me.txtDesde2)
        Me.gbxSucursal.Controls.Add(Me.txtDesde1)
        Me.gbxSucursal.Controls.Add(Me.txtNombreContacto)
        Me.gbxSucursal.Controls.Add(Me.txtHasta1)
        Me.gbxSucursal.Controls.Add(Label21)
        Me.gbxSucursal.Controls.Add(Label13)
        Me.gbxSucursal.Controls.Add(Label12)
        Me.gbxSucursal.Enabled = False
        Me.gbxSucursal.Location = New System.Drawing.Point(353, 41)
        Me.gbxSucursal.Name = "gbxSucursal"
        Me.gbxSucursal.Size = New System.Drawing.Size(458, 111)
        Me.gbxSucursal.TabIndex = 10
        Me.gbxSucursal.TabStop = False
        Me.gbxSucursal.Text = "Sucursal"
        '
        'txtLocalidad
        '
        Me.txtLocalidad.Location = New System.Drawing.Point(301, 23)
        Me.txtLocalidad.Name = "txtLocalidad"
        Me.txtLocalidad.ReadOnly = True
        Me.txtLocalidad.Size = New System.Drawing.Size(149, 20)
        Me.txtLocalidad.TabIndex = 15
        Me.txtLocalidad.TabStop = False
        '
        'txtNombreExpreso
        '
        Me.txtNombreExpreso.Location = New System.Drawing.Point(116, 81)
        Me.txtNombreExpreso.Name = "txtNombreExpreso"
        Me.txtNombreExpreso.ReadOnly = True
        Me.txtNombreExpreso.Size = New System.Drawing.Size(179, 20)
        Me.txtNombreExpreso.TabIndex = 14
        Me.txtNombreExpreso.TabStop = False
        '
        'txtCodigoExpreso
        '
        Me.txtCodigoExpreso.ContextMenuStrip = Me.cms
        Me.txtCodigoExpreso.Location = New System.Drawing.Point(63, 81)
        Me.txtCodigoExpreso.Name = "txtCodigoExpreso"
        Me.txtCodigoExpreso.Size = New System.Drawing.Size(47, 20)
        Me.txtCodigoExpreso.TabIndex = 13
        '
        'Label5
        '
        Label5.AutoSize = True
        Label5.Location = New System.Drawing.Point(9, 87)
        Label5.Name = "Label5"
        Label5.Size = New System.Drawing.Size(48, 13)
        Label5.TabIndex = 12
        Label5.Text = "Expreso:"
        '
        'txtDomicilio
        '
        Me.txtDomicilio.Location = New System.Drawing.Point(63, 23)
        Me.txtDomicilio.Name = "txtDomicilio"
        Me.txtDomicilio.ReadOnly = True
        Me.txtDomicilio.Size = New System.Drawing.Size(232, 20)
        Me.txtDomicilio.TabIndex = 1
        '
        'txtCodigoSucursal
        '
        Me.txtCodigoSucursal.ContextMenuStrip = Me.cms
        Me.txtCodigoSucursal.Location = New System.Drawing.Point(10, 23)
        Me.txtCodigoSucursal.Name = "txtCodigoSucursal"
        Me.txtCodigoSucursal.Size = New System.Drawing.Size(47, 20)
        Me.txtCodigoSucursal.TabIndex = 0
        '
        'txtHasta2
        '
        Me.txtHasta2.Location = New System.Drawing.Point(403, 81)
        Me.txtHasta2.MaxLength = 4
        Me.txtHasta2.Name = "txtHasta2"
        Me.txtHasta2.Size = New System.Drawing.Size(47, 20)
        Me.txtHasta2.TabIndex = 7
        '
        'Label22
        '
        Label22.AutoSize = True
        Label22.Location = New System.Drawing.Point(173, 53)
        Label22.Name = "Label22"
        Label22.Size = New System.Drawing.Size(39, 13)
        Label22.TabIndex = 10
        Label22.Text = "Celular"
        '
        'txtCelularContacto
        '
        Me.txtCelularContacto.Location = New System.Drawing.Point(218, 52)
        Me.txtCelularContacto.MaxLength = 10
        Me.txtCelularContacto.Name = "txtCelularContacto"
        Me.txtCelularContacto.ReadOnly = True
        Me.txtCelularContacto.Size = New System.Drawing.Size(77, 20)
        Me.txtCelularContacto.TabIndex = 11
        '
        'txtDesde2
        '
        Me.txtDesde2.Location = New System.Drawing.Point(353, 81)
        Me.txtDesde2.MaxLength = 4
        Me.txtDesde2.Name = "txtDesde2"
        Me.txtDesde2.Size = New System.Drawing.Size(44, 20)
        Me.txtDesde2.TabIndex = 6
        '
        'txtDesde1
        '
        Me.txtDesde1.Location = New System.Drawing.Point(353, 52)
        Me.txtDesde1.MaxLength = 4
        Me.txtDesde1.Name = "txtDesde1"
        Me.txtDesde1.Size = New System.Drawing.Size(44, 20)
        Me.txtDesde1.TabIndex = 3
        '
        'txtNombreContacto
        '
        Me.txtNombreContacto.Location = New System.Drawing.Point(63, 52)
        Me.txtNombreContacto.MaxLength = 50
        Me.txtNombreContacto.Name = "txtNombreContacto"
        Me.txtNombreContacto.ReadOnly = True
        Me.txtNombreContacto.Size = New System.Drawing.Size(104, 20)
        Me.txtNombreContacto.TabIndex = 9
        '
        'txtHasta1
        '
        Me.txtHasta1.Location = New System.Drawing.Point(403, 52)
        Me.txtHasta1.MaxLength = 4
        Me.txtHasta1.Name = "txtHasta1"
        Me.txtHasta1.Size = New System.Drawing.Size(47, 20)
        Me.txtHasta1.TabIndex = 4
        '
        'Label21
        '
        Label21.AutoSize = True
        Label21.Location = New System.Drawing.Point(7, 55)
        Label21.Name = "Label21"
        Label21.Size = New System.Drawing.Size(50, 13)
        Label21.TabIndex = 8
        Label21.Text = "Contacto"
        '
        'Label13
        '
        Label13.AutoSize = True
        Label13.Location = New System.Drawing.Point(302, 59)
        Label13.Name = "Label13"
        Label13.Size = New System.Drawing.Size(45, 13)
        Label13.TabIndex = 2
        Label13.Text = "Franja 1"
        '
        'Label12
        '
        Label12.AutoSize = True
        Label12.Location = New System.Drawing.Point(302, 84)
        Label12.Name = "Label12"
        Label12.Size = New System.Drawing.Size(45, 13)
        Label12.TabIndex = 5
        Label12.Text = "Franja 2"
        '
        'cboEstado
        '
        Me.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cboEstado.Enabled = False
        Me.cboEstado.FormattingEnabled = True
        Me.cboEstado.Location = New System.Drawing.Point(724, 12)
        Me.cboEstado.Name = "cboEstado"
        Me.cboEstado.Size = New System.Drawing.Size(87, 21)
        Me.cboEstado.TabIndex = 8
        Me.cboEstado.TabStop = False
        '
        'btnGrabar
        '
        Me.btnGrabar.Enabled = False
        Me.btnGrabar.Location = New System.Drawing.Point(16, 584)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(75, 23)
        Me.btnGrabar.TabIndex = 24
        Me.btnGrabar.Text = "Grabar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'gbxCliente
        '
        Me.gbxCliente.Controls.Add(Me.txtClase)
        Me.gbxCliente.Controls.Add(Me.lblHonorarios)
        Me.gbxCliente.Controls.Add(Me.chkAVentas)
        Me.gbxCliente.Controls.Add(Me.chkFcRto)
        Me.gbxCliente.Controls.Add(Me.txtNombreCliente)
        Me.gbxCliente.Controls.Add(Me.txtCodigoCliente)
        Me.gbxCliente.Controls.Add(Me.cboCondicionPago)
        Me.gbxCliente.Controls.Add(Label25)
        Me.gbxCliente.Location = New System.Drawing.Point(9, 41)
        Me.gbxCliente.Name = "gbxCliente"
        Me.gbxCliente.Size = New System.Drawing.Size(337, 111)
        Me.gbxCliente.TabIndex = 9
        Me.gbxCliente.TabStop = False
        Me.gbxCliente.Text = "Cliente"
        '
        'txtClase
        '
        Me.txtClase.Location = New System.Drawing.Point(298, 19)
        Me.txtClase.Name = "txtClase"
        Me.txtClase.ReadOnly = True
        Me.txtClase.Size = New System.Drawing.Size(27, 20)
        Me.txtClase.TabIndex = 17
        Me.txtClase.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblHonorarios
        '
        Me.lblHonorarios.AutoSize = True
        Me.lblHonorarios.Location = New System.Drawing.Point(202, 76)
        Me.lblHonorarios.Name = "lblHonorarios"
        Me.lblHonorarios.Size = New System.Drawing.Size(61, 13)
        Me.lblHonorarios.TabIndex = 16
        Me.lblHonorarios.Text = "Honorarios:"
        '
        'chkAVentas
        '
        Me.chkAVentas.AutoSize = True
        Me.chkAVentas.Enabled = False
        Me.chkAVentas.Location = New System.Drawing.Point(10, 87)
        Me.chkAVentas.Name = "chkAVentas"
        Me.chkAVentas.Size = New System.Drawing.Size(57, 17)
        Me.chkAVentas.TabIndex = 5
        Me.chkAVentas.Text = "A Vtas"
        Me.chkAVentas.UseVisualStyleBackColor = True
        '
        'chkFcRto
        '
        Me.chkFcRto.AutoSize = True
        Me.chkFcRto.Enabled = False
        Me.chkFcRto.Location = New System.Drawing.Point(10, 72)
        Me.chkFcRto.Name = "chkFcRto"
        Me.chkFcRto.Size = New System.Drawing.Size(119, 17)
        Me.chkFcRto.TabIndex = 4
        Me.chkFcRto.TabStop = False
        Me.chkFcRto.Text = "Factura con Remito"
        Me.chkFcRto.UseVisualStyleBackColor = True
        '
        'txtNombreCliente
        '
        Me.txtNombreCliente.Location = New System.Drawing.Point(81, 19)
        Me.txtNombreCliente.Name = "txtNombreCliente"
        Me.txtNombreCliente.ReadOnly = True
        Me.txtNombreCliente.Size = New System.Drawing.Size(211, 20)
        Me.txtNombreCliente.TabIndex = 1
        '
        'txtCodigoCliente
        '
        Me.txtCodigoCliente.ContextMenuStrip = Me.cms
        Me.txtCodigoCliente.Location = New System.Drawing.Point(10, 19)
        Me.txtCodigoCliente.Name = "txtCodigoCliente"
        Me.txtCodigoCliente.ReadOnly = True
        Me.txtCodigoCliente.Size = New System.Drawing.Size(65, 20)
        Me.txtCodigoCliente.TabIndex = 0
        '
        'cboCondicionPago
        '
        Me.cboCondicionPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCondicionPago.Enabled = False
        Me.cboCondicionPago.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboCondicionPago.FormattingEnabled = True
        Me.cboCondicionPago.Location = New System.Drawing.Point(80, 45)
        Me.cboCondicionPago.Name = "cboCondicionPago"
        Me.cboCondicionPago.Size = New System.Drawing.Size(251, 21)
        Me.cboCondicionPago.TabIndex = 3
        Me.cboCondicionPago.TabStop = False
        '
        'Label25
        '
        Label25.AutoSize = True
        Label25.Location = New System.Drawing.Point(10, 53)
        Label25.Name = "Label25"
        Label25.Size = New System.Drawing.Size(63, 13)
        Label25.TabIndex = 2
        Label25.Text = "Cond. Pago"
        '
        'txtObs
        '
        Me.txtObs.Location = New System.Drawing.Point(15, 536)
        Me.txtObs.MaxLength = 200
        Me.txtObs.Multiline = True
        Me.txtObs.Name = "txtObs"
        Me.txtObs.Size = New System.Drawing.Size(337, 47)
        Me.txtObs.TabIndex = 15
        '
        'btnNuevoPresupuesto
        '
        Me.btnNuevoPresupuesto.Location = New System.Drawing.Point(124, 12)
        Me.btnNuevoPresupuesto.Name = "btnNuevoPresupuesto"
        Me.btnNuevoPresupuesto.Size = New System.Drawing.Size(109, 23)
        Me.btnNuevoPresupuesto.TabIndex = 1
        Me.btnNuevoPresupuesto.TabStop = False
        Me.btnNuevoPresupuesto.Text = "Nuevo Presupuesto"
        Me.btnNuevoPresupuesto.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Label4.AutoSize = True
        Label4.Location = New System.Drawing.Point(675, 15)
        Label4.Name = "Label4"
        Label4.Size = New System.Drawing.Size(43, 13)
        Label4.TabIndex = 7
        Label4.Text = "Estado:"
        '
        'Label11
        '
        Label11.AutoSize = True
        Label11.Location = New System.Drawing.Point(19, 520)
        Label11.Name = "Label11"
        Label11.Size = New System.Drawing.Size(78, 13)
        Label11.TabIndex = 14
        Label11.Text = "Observaciones"
        '
        'cboTipo
        '
        Me.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipo.Enabled = False
        Me.cboTipo.FormattingEnabled = True
        Me.cboTipo.Location = New System.Drawing.Point(582, 12)
        Me.cboTipo.Name = "cboTipo"
        Me.cboTipo.Size = New System.Drawing.Size(87, 21)
        Me.cboTipo.TabIndex = 6
        Me.cboTipo.TabStop = False
        '
        'txtFecha
        '
        Me.txtFecha.Location = New System.Drawing.Point(432, 11)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.ReadOnly = True
        Me.txtFecha.Size = New System.Drawing.Size(75, 20)
        Me.txtFecha.TabIndex = 4
        Me.txtFecha.TabStop = False
        '
        'Label20
        '
        Label20.AutoSize = True
        Label20.Location = New System.Drawing.Point(533, 15)
        Label20.Name = "Label20"
        Label20.Size = New System.Drawing.Size(31, 13)
        Label20.TabIndex = 5
        Label20.Text = "Tipo:"
        '
        'txtNro
        '
        Me.txtNro.Location = New System.Drawing.Point(351, 11)
        Me.txtNro.Name = "txtNro"
        Me.txtNro.ReadOnly = True
        Me.txtNro.Size = New System.Drawing.Size(75, 20)
        Me.txtNro.TabIndex = 3
        Me.txtNro.TabStop = False
        Me.txtNro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(286, 15)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(59, 13)
        Label1.TabIndex = 2
        Label1.Text = "Cotización:"
        '
        'mnu2
        '
        Me.mnu2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSeleccionArticulo})
        Me.mnu2.Name = "mnu"
        Me.mnu2.Size = New System.Drawing.Size(125, 26)
        '
        'mnuSeleccionArticulo
        '
        Me.mnuSeleccionArticulo.Name = "mnuSeleccionArticulo"
        Me.mnuSeleccionArticulo.Size = New System.Drawing.Size(124, 22)
        Me.mnuSeleccionArticulo.Text = "Selección"
        '
        'frmCotizadorV2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1153, 612)
        Me.Controls.Add(SplitContainer1)
        Me.Name = "frmCotizadorV2"
        Me.Tag = "frmCotizador"
        Me.Text = "Cotizador"
        SplitContainer1.Panel1.ResumeLayout(False)
        SplitContainer1.Panel1.PerformLayout()
        SplitContainer1.Panel2.ResumeLayout(False)
        SplitContainer1.Panel2.PerformLayout()
        SplitContainer1.ResumeLayout(False)
        Me.grTipo.ResumeLayout(False)
        Me.grTipo.PerformLayout()
        CType(Me.dgv2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gbxLicitacion.ResumeLayout(False)
        Me.gbxLicitacion.PerformLayout()
        Me.cms.ResumeLayout(False)
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxSociedad.ResumeLayout(False)
        Me.gbxSociedad.PerformLayout()
        Me.gbxOc.ResumeLayout(False)
        Me.gbxOc.PerformLayout()
        Me.gbxSucursal.ResumeLayout(False)
        Me.gbxSucursal.PerformLayout()
        Me.gbxCliente.ResumeLayout(False)
        Me.gbxCliente.PerformLayout()
        Me.mnu2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents txtNombreCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtFecha As System.Windows.Forms.TextBox
    Friend WithEvents txtNro As System.Windows.Forms.TextBox
    Friend WithEvents txtPedido As System.Windows.Forms.TextBox
    Friend WithEvents cboEstado As System.Windows.Forms.ComboBox
    Friend WithEvents txtTotalAI As System.Windows.Forms.TextBox
    Friend WithEvents dgv2 As System.Windows.Forms.DataGridView
    Friend WithEvents txtHasta2 As System.Windows.Forms.TextBox
    Friend WithEvents txtDesde2 As System.Windows.Forms.TextBox
    Friend WithEvents txtHasta1 As System.Windows.Forms.TextBox
    Friend WithEvents txtDesde1 As System.Windows.Forms.TextBox
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents btnPedido As System.Windows.Forms.Button
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents btnNuevoPedido As System.Windows.Forms.Button
    Friend WithEvents txtObs As System.Windows.Forms.TextBox
    Friend WithEvents txtOC As System.Windows.Forms.TextBox
    Friend WithEvents btnPresupuesto As System.Windows.Forms.Button
    Friend WithEvents txtPresupuesto As System.Windows.Forms.TextBox
    Friend WithEvents btnNuevoPresupuesto As System.Windows.Forms.Button
    Friend WithEvents cboTipo As System.Windows.Forms.ComboBox
    Friend WithEvents cboCondicionPago As System.Windows.Forms.ComboBox
    Friend WithEvents btnBorrar As System.Windows.Forms.Button
    Friend WithEvents btnDuplicar As System.Windows.Forms.Button
    Friend WithEvents btnExaminarOt As System.Windows.Forms.Button
    Friend WithEvents btnVerOt As System.Windows.Forms.Button
    Friend WithEvents btnBorrarOt As System.Windows.Forms.Button
    Friend WithEvents txtCodigoCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtDomicilio As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigoSucursal As System.Windows.Forms.TextBox
    Friend WithEvents gbxSucursal As System.Windows.Forms.GroupBox
    Friend WithEvents gbxCliente As System.Windows.Forms.GroupBox
    Friend WithEvents gbxOc As System.Windows.Forms.GroupBox
    Friend WithEvents cboEntrega As System.Windows.Forms.ComboBox
    Friend WithEvents chkH As System.Windows.Forms.CheckBox
    Friend WithEvents cboSociedad As System.Windows.Forms.ComboBox
    Friend WithEvents txtNombreExpreso As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigoExpreso As System.Windows.Forms.TextBox
    Friend WithEvents txtCelularContacto As System.Windows.Forms.TextBox
    Friend WithEvents txtNombreContacto As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalII As System.Windows.Forms.TextBox
    Friend WithEvents gbxSociedad As System.Windows.Forms.GroupBox
    Friend WithEvents cms As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuSeleccionar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuEditar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuAbrirPresupuesto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chkFcRto As System.Windows.Forms.CheckBox
    Friend WithEvents mnu2 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuSeleccionArticulo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtLocalidad As System.Windows.Forms.TextBox
    Friend WithEvents colNro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colLinea As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCodigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDescripcion As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colCant As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPrecio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSugerido As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTotal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col2Nro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col2Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col2Cliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents suc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col2Nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col2Vend As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cboTipo2 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents chkPendiente As System.Windows.Forms.CheckBox
    Friend WithEvents chkRecargas As System.Windows.Forms.CheckBox
    Friend WithEvents chkPedidos As System.Windows.Forms.CheckBox
    Friend WithEvents btnFlete As System.Windows.Forms.Button
    Friend WithEvents btnDesaprobar As System.Windows.Forms.Button
    Friend WithEvents txtDesaprobado As System.Windows.Forms.Label
    Friend WithEvents gbxLicitacion As System.Windows.Forms.GroupBox
    Friend WithEvents cboLicitacion As System.Windows.Forms.ComboBox
    Friend WithEvents txtLicitacion As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnRechazo As System.Windows.Forms.Button
    Friend WithEvents txtIntervencionRechazo As System.Windows.Forms.TextBox
    Friend WithEvents chkAVentas As System.Windows.Forms.CheckBox
    Friend WithEvents lblHonorarios As System.Windows.Forms.Label
    Friend WithEvents lblReferencia As System.Windows.Forms.Label
    Friend WithEvents grTipo As System.Windows.Forms.GroupBox
    Friend WithEvents rbTodo As System.Windows.Forms.RadioButton
    Friend WithEvents rbVendedores As System.Windows.Forms.RadioButton
    Friend WithEvents rbCaa As System.Windows.Forms.RadioButton
    Friend WithEvents txtClase As System.Windows.Forms.TextBox
End Class
