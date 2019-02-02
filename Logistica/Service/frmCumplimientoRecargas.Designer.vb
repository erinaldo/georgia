<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCumplimientoRecargas
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
        Dim Label4 As System.Windows.Forms.Label
        Dim Label5 As System.Windows.Forms.Label
        Dim Label6 As System.Windows.Forms.Label
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim Label7 As System.Windows.Forms.Label
        Dim Label8 As System.Windows.Forms.Label
        Me.dtp = New System.Windows.Forms.DateTimePicker
        Me.btnConsultar = New System.Windows.Forms.Button
        Me.Tab = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.dgv1 = New System.Windows.Forms.DataGridView
        Me.col1Cod = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col1suc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col1Cliente = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col1Domicilio = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col1Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.dgv2 = New System.Windows.Forms.DataGridView
        Me.col2cod = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col2suc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col2cliente = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col2domicilio = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col2intervencion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col2estado = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.col2ruta = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col2cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.mnu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuIntervencion = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuSegto = New System.Windows.Forms.ToolStripMenuItem
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.dgv3 = New System.Windows.Forms.DataGridView
        Me.col3cod = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col3suc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col3cliente = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col3domicilio = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col3intervencion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col3Retiro = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col3estado = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.col3ruta = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col3cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TabPage4 = New System.Windows.Forms.TabPage
        Me.dgv4 = New System.Windows.Forms.DataGridView
        Me.col4cod = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col4suc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col4cliente = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col4domicilio = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col4intervencion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col4cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.lbl = New System.Windows.Forms.Label
        Me.txtTotal1 = New System.Windows.Forms.TextBox
        Me.txtTotal2 = New System.Windows.Forms.TextBox
        Me.txtTotal3 = New System.Windows.Forms.TextBox
        Me.txtTotal4 = New System.Windows.Forms.TextBox
        Me.txtTotal5 = New System.Windows.Forms.TextBox
        Me.txtPorc1 = New System.Windows.Forms.TextBox
        Me.txtPorc2 = New System.Windows.Forms.TextBox
        Me.txtPorc3 = New System.Windows.Forms.TextBox
        Me.txtPorc4 = New System.Windows.Forms.TextBox
        Me.txtPorc5 = New System.Windows.Forms.TextBox
        Me.cboDe = New System.Windows.Forms.ComboBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cboHasta = New System.Windows.Forms.ComboBox
        Label1 = New System.Windows.Forms.Label
        Label2 = New System.Windows.Forms.Label
        Label3 = New System.Windows.Forms.Label
        Label4 = New System.Windows.Forms.Label
        Label5 = New System.Windows.Forms.Label
        Label6 = New System.Windows.Forms.Label
        Label7 = New System.Windows.Forms.Label
        Label8 = New System.Windows.Forms.Label
        Me.Tab.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgv2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnu.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        CType(Me.dgv3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        CType(Me.dgv4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(6, 21)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(85, 13)
        Label1.TabIndex = 0
        Label1.Text = "Mes a consultar:"
        '
        'Label2
        '
        Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Label2.AutoSize = True
        Label2.Location = New System.Drawing.Point(6, 421)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(140, 13)
        Label2.TabIndex = 6
        Label2.Text = "Pendientes sin intervención:"
        '
        'Label3
        '
        Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Label3.AutoSize = True
        Label3.Location = New System.Drawing.Point(203, 421)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(135, 13)
        Label3.TabIndex = 9
        Label3.Text = "Con intervención sin retirar:"
        '
        'Label4
        '
        Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Label4.AutoSize = True
        Label4.Location = New System.Drawing.Point(395, 421)
        Label4.Name = "Label4"
        Label4.Size = New System.Drawing.Size(50, 13)
        Label4.TabIndex = 12
        Label4.Text = "Retirado:"
        '
        'Label5
        '
        Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Label5.AutoSize = True
        Label5.Location = New System.Drawing.Point(502, 421)
        Label5.Name = "Label5"
        Label5.Size = New System.Drawing.Size(59, 13)
        Label5.TabIndex = 15
        Label5.Text = "Entregado:"
        '
        'Label6
        '
        Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Label6.AutoSize = True
        Label6.Location = New System.Drawing.Point(618, 421)
        Label6.Name = "Label6"
        Label6.Size = New System.Drawing.Size(34, 13)
        Label6.TabIndex = 18
        Label6.Text = "Total:"
        '
        'dtp
        '
        Me.dtp.CustomFormat = "MMMM/yyyy"
        Me.dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp.Location = New System.Drawing.Point(104, 17)
        Me.dtp.Name = "dtp"
        Me.dtp.Size = New System.Drawing.Size(149, 20)
        Me.dtp.TabIndex = 1
        '
        'btnConsultar
        '
        Me.btnConsultar.Location = New System.Drawing.Point(451, 16)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(75, 23)
        Me.btnConsultar.TabIndex = 3
        Me.btnConsultar.Text = "Consultar"
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'Tab
        '
        Me.Tab.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Tab.Controls.Add(Me.TabPage1)
        Me.Tab.Controls.Add(Me.TabPage2)
        Me.Tab.Controls.Add(Me.TabPage3)
        Me.Tab.Controls.Add(Me.TabPage4)
        Me.Tab.Location = New System.Drawing.Point(2, 46)
        Me.Tab.Name = "Tab"
        Me.Tab.SelectedIndex = 0
        Me.Tab.Size = New System.Drawing.Size(816, 351)
        Me.Tab.TabIndex = 5
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dgv1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(808, 325)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Pendientes sin intervención"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'dgv1
        '
        Me.dgv1.AllowUserToAddRows = False
        Me.dgv1.AllowUserToDeleteRows = False
        Me.dgv1.AllowUserToResizeColumns = False
        Me.dgv1.AllowUserToResizeRows = False
        Me.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col1Cod, Me.col1suc, Me.col1Cliente, Me.col1Domicilio, Me.col1Cantidad})
        Me.dgv1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv1.Location = New System.Drawing.Point(3, 3)
        Me.dgv1.MultiSelect = False
        Me.dgv1.Name = "dgv1"
        Me.dgv1.ReadOnly = True
        Me.dgv1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv1.Size = New System.Drawing.Size(802, 319)
        Me.dgv1.TabIndex = 0
        '
        'col1Cod
        '
        Me.col1Cod.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.col1Cod.HeaderText = "Cod."
        Me.col1Cod.Name = "col1Cod"
        Me.col1Cod.ReadOnly = True
        Me.col1Cod.Width = 54
        '
        'col1suc
        '
        Me.col1suc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.col1suc.HeaderText = "Suc"
        Me.col1suc.Name = "col1suc"
        Me.col1suc.ReadOnly = True
        Me.col1suc.Width = 51
        '
        'col1Cliente
        '
        Me.col1Cliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.col1Cliente.HeaderText = "Nombre"
        Me.col1Cliente.Name = "col1Cliente"
        Me.col1Cliente.ReadOnly = True
        '
        'col1Domicilio
        '
        Me.col1Domicilio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.col1Domicilio.HeaderText = "Domicilio"
        Me.col1Domicilio.Name = "col1Domicilio"
        Me.col1Domicilio.ReadOnly = True
        Me.col1Domicilio.Width = 74
        '
        'col1Cantidad
        '
        Me.col1Cantidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle13.Format = "N0"
        Me.col1Cantidad.DefaultCellStyle = DataGridViewCellStyle13
        Me.col1Cantidad.HeaderText = "Cant"
        Me.col1Cantidad.Name = "col1Cantidad"
        Me.col1Cantidad.ReadOnly = True
        Me.col1Cantidad.Width = 54
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.dgv2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(808, 325)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Con intervención sin retirar"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'dgv2
        '
        Me.dgv2.AllowUserToAddRows = False
        Me.dgv2.AllowUserToDeleteRows = False
        Me.dgv2.AllowUserToResizeColumns = False
        Me.dgv2.AllowUserToResizeRows = False
        Me.dgv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col2cod, Me.col2suc, Me.col2cliente, Me.col2domicilio, Me.col2intervencion, Me.col2estado, Me.col2ruta, Me.col2cantidad})
        Me.dgv2.ContextMenuStrip = Me.mnu
        Me.dgv2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv2.Location = New System.Drawing.Point(3, 3)
        Me.dgv2.MultiSelect = False
        Me.dgv2.Name = "dgv2"
        Me.dgv2.ReadOnly = True
        Me.dgv2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv2.Size = New System.Drawing.Size(802, 319)
        Me.dgv2.TabIndex = 0
        '
        'col2cod
        '
        Me.col2cod.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.col2cod.HeaderText = "Cod"
        Me.col2cod.Name = "col2cod"
        Me.col2cod.ReadOnly = True
        Me.col2cod.Width = 51
        '
        'col2suc
        '
        Me.col2suc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.col2suc.HeaderText = "Suc"
        Me.col2suc.Name = "col2suc"
        Me.col2suc.ReadOnly = True
        Me.col2suc.Width = 51
        '
        'col2cliente
        '
        Me.col2cliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.col2cliente.HeaderText = "Cliente"
        Me.col2cliente.Name = "col2cliente"
        Me.col2cliente.ReadOnly = True
        '
        'col2domicilio
        '
        Me.col2domicilio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.col2domicilio.HeaderText = "Domicilio"
        Me.col2domicilio.Name = "col2domicilio"
        Me.col2domicilio.ReadOnly = True
        Me.col2domicilio.Width = 74
        '
        'col2intervencion
        '
        Me.col2intervencion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.col2intervencion.HeaderText = "Intervencion"
        Me.col2intervencion.Name = "col2intervencion"
        Me.col2intervencion.ReadOnly = True
        Me.col2intervencion.Width = 91
        '
        'col2estado
        '
        Me.col2estado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.col2estado.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.col2estado.HeaderText = "Estado"
        Me.col2estado.Name = "col2estado"
        Me.col2estado.ReadOnly = True
        Me.col2estado.Width = 46
        '
        'col2ruta
        '
        Me.col2ruta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle14.Format = "N0"
        Me.col2ruta.DefaultCellStyle = DataGridViewCellStyle14
        Me.col2ruta.HeaderText = "Ruta"
        Me.col2ruta.Name = "col2ruta"
        Me.col2ruta.ReadOnly = True
        Me.col2ruta.Width = 55
        '
        'col2cantidad
        '
        Me.col2cantidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle15.Format = "N0"
        Me.col2cantidad.DefaultCellStyle = DataGridViewCellStyle15
        Me.col2cantidad.HeaderText = "Cantidad"
        Me.col2cantidad.Name = "col2cantidad"
        Me.col2cantidad.ReadOnly = True
        Me.col2cantidad.Width = 74
        '
        'mnu
        '
        Me.mnu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuIntervencion, Me.mnuSegto})
        Me.mnu.Name = "mnu"
        Me.mnu.Size = New System.Drawing.Size(245, 48)
        '
        'mnuIntervencion
        '
        Me.mnuIntervencion.Name = "mnuIntervencion"
        Me.mnuIntervencion.Size = New System.Drawing.Size(244, 22)
        Me.mnuIntervencion.Text = "Intervención"
        '
        'mnuSegto
        '
        Me.mnuSegto.Name = "mnuSegto"
        Me.mnuSegto.Size = New System.Drawing.Size(244, 22)
        Me.mnuSegto.Text = "Seguimiento de documentación"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.dgv3)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(808, 325)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Retirados"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'dgv3
        '
        Me.dgv3.AllowUserToAddRows = False
        Me.dgv3.AllowUserToDeleteRows = False
        Me.dgv3.AllowUserToResizeColumns = False
        Me.dgv3.AllowUserToResizeRows = False
        Me.dgv3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv3.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col3cod, Me.col3suc, Me.col3cliente, Me.col3domicilio, Me.col3intervencion, Me.col3Retiro, Me.col3estado, Me.col3ruta, Me.col3cantidad})
        Me.dgv3.ContextMenuStrip = Me.mnu
        Me.dgv3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv3.Location = New System.Drawing.Point(3, 3)
        Me.dgv3.MultiSelect = False
        Me.dgv3.Name = "dgv3"
        Me.dgv3.ReadOnly = True
        Me.dgv3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv3.Size = New System.Drawing.Size(802, 319)
        Me.dgv3.TabIndex = 0
        '
        'col3cod
        '
        Me.col3cod.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.col3cod.HeaderText = "Cod"
        Me.col3cod.Name = "col3cod"
        Me.col3cod.ReadOnly = True
        Me.col3cod.Width = 51
        '
        'col3suc
        '
        Me.col3suc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.col3suc.HeaderText = "Suc"
        Me.col3suc.Name = "col3suc"
        Me.col3suc.ReadOnly = True
        Me.col3suc.Width = 51
        '
        'col3cliente
        '
        Me.col3cliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.col3cliente.HeaderText = "Cliente"
        Me.col3cliente.Name = "col3cliente"
        Me.col3cliente.ReadOnly = True
        '
        'col3domicilio
        '
        Me.col3domicilio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.col3domicilio.HeaderText = "Domicilio"
        Me.col3domicilio.Name = "col3domicilio"
        Me.col3domicilio.ReadOnly = True
        Me.col3domicilio.Width = 74
        '
        'col3intervencion
        '
        Me.col3intervencion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.col3intervencion.HeaderText = "Intervencion"
        Me.col3intervencion.Name = "col3intervencion"
        Me.col3intervencion.ReadOnly = True
        Me.col3intervencion.Width = 91
        '
        'col3Retiro
        '
        Me.col3Retiro.HeaderText = "Retirado"
        Me.col3Retiro.Name = "col3Retiro"
        Me.col3Retiro.ReadOnly = True
        '
        'col3estado
        '
        Me.col3estado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.col3estado.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.col3estado.HeaderText = "Estado"
        Me.col3estado.Name = "col3estado"
        Me.col3estado.ReadOnly = True
        Me.col3estado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.col3estado.Width = 65
        '
        'col3ruta
        '
        Me.col3ruta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle16.Format = "N0"
        Me.col3ruta.DefaultCellStyle = DataGridViewCellStyle16
        Me.col3ruta.HeaderText = "Ruta"
        Me.col3ruta.Name = "col3ruta"
        Me.col3ruta.ReadOnly = True
        Me.col3ruta.Width = 55
        '
        'col3cantidad
        '
        Me.col3cantidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle17.Format = "N0"
        Me.col3cantidad.DefaultCellStyle = DataGridViewCellStyle17
        Me.col3cantidad.HeaderText = "Cantidad"
        Me.col3cantidad.Name = "col3cantidad"
        Me.col3cantidad.ReadOnly = True
        Me.col3cantidad.Width = 74
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.dgv4)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(808, 325)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Entregados"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'dgv4
        '
        Me.dgv4.AllowUserToAddRows = False
        Me.dgv4.AllowUserToDeleteRows = False
        Me.dgv4.AllowUserToResizeColumns = False
        Me.dgv4.AllowUserToResizeRows = False
        Me.dgv4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv4.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col4cod, Me.col4suc, Me.col4cliente, Me.col4domicilio, Me.col4intervencion, Me.col4cantidad})
        Me.dgv4.ContextMenuStrip = Me.mnu
        Me.dgv4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv4.Location = New System.Drawing.Point(3, 3)
        Me.dgv4.MultiSelect = False
        Me.dgv4.Name = "dgv4"
        Me.dgv4.ReadOnly = True
        Me.dgv4.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv4.Size = New System.Drawing.Size(802, 319)
        Me.dgv4.TabIndex = 0
        '
        'col4cod
        '
        Me.col4cod.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.col4cod.HeaderText = "Cod"
        Me.col4cod.Name = "col4cod"
        Me.col4cod.ReadOnly = True
        Me.col4cod.Width = 51
        '
        'col4suc
        '
        Me.col4suc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.col4suc.HeaderText = "Suc"
        Me.col4suc.Name = "col4suc"
        Me.col4suc.ReadOnly = True
        Me.col4suc.Width = 51
        '
        'col4cliente
        '
        Me.col4cliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.col4cliente.HeaderText = "Cliente"
        Me.col4cliente.Name = "col4cliente"
        Me.col4cliente.ReadOnly = True
        '
        'col4domicilio
        '
        Me.col4domicilio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.col4domicilio.HeaderText = "Domicilio"
        Me.col4domicilio.Name = "col4domicilio"
        Me.col4domicilio.ReadOnly = True
        Me.col4domicilio.Width = 74
        '
        'col4intervencion
        '
        Me.col4intervencion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.col4intervencion.HeaderText = "Intervencion"
        Me.col4intervencion.Name = "col4intervencion"
        Me.col4intervencion.ReadOnly = True
        Me.col4intervencion.Width = 91
        '
        'col4cantidad
        '
        Me.col4cantidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle18.Format = "N0"
        Me.col4cantidad.DefaultCellStyle = DataGridViewCellStyle18
        Me.col4cantidad.HeaderText = "Cantidad"
        Me.col4cantidad.Name = "col4cantidad"
        Me.col4cantidad.ReadOnly = True
        Me.col4cantidad.Width = 74
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.Location = New System.Drawing.Point(539, 22)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(39, 13)
        Me.lbl.TabIndex = 4
        Me.lbl.Text = "Label2"
        Me.lbl.Visible = False
        '
        'txtTotal1
        '
        Me.txtTotal1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtTotal1.Location = New System.Drawing.Point(152, 418)
        Me.txtTotal1.Name = "txtTotal1"
        Me.txtTotal1.ReadOnly = True
        Me.txtTotal1.Size = New System.Drawing.Size(45, 20)
        Me.txtTotal1.TabIndex = 7
        Me.txtTotal1.Text = "0"
        Me.txtTotal1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotal2
        '
        Me.txtTotal2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtTotal2.Location = New System.Drawing.Point(344, 418)
        Me.txtTotal2.Name = "txtTotal2"
        Me.txtTotal2.ReadOnly = True
        Me.txtTotal2.Size = New System.Drawing.Size(45, 20)
        Me.txtTotal2.TabIndex = 10
        Me.txtTotal2.Text = "0"
        Me.txtTotal2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotal3
        '
        Me.txtTotal3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtTotal3.Location = New System.Drawing.Point(451, 418)
        Me.txtTotal3.Name = "txtTotal3"
        Me.txtTotal3.ReadOnly = True
        Me.txtTotal3.Size = New System.Drawing.Size(45, 20)
        Me.txtTotal3.TabIndex = 13
        Me.txtTotal3.Text = "0"
        Me.txtTotal3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotal4
        '
        Me.txtTotal4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtTotal4.Location = New System.Drawing.Point(567, 418)
        Me.txtTotal4.Name = "txtTotal4"
        Me.txtTotal4.ReadOnly = True
        Me.txtTotal4.Size = New System.Drawing.Size(45, 20)
        Me.txtTotal4.TabIndex = 16
        Me.txtTotal4.Text = "0"
        Me.txtTotal4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotal5
        '
        Me.txtTotal5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtTotal5.Location = New System.Drawing.Point(658, 418)
        Me.txtTotal5.Name = "txtTotal5"
        Me.txtTotal5.ReadOnly = True
        Me.txtTotal5.Size = New System.Drawing.Size(45, 20)
        Me.txtTotal5.TabIndex = 20
        Me.txtTotal5.Text = "0"
        Me.txtTotal5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPorc1
        '
        Me.txtPorc1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtPorc1.Location = New System.Drawing.Point(152, 444)
        Me.txtPorc1.Name = "txtPorc1"
        Me.txtPorc1.ReadOnly = True
        Me.txtPorc1.Size = New System.Drawing.Size(45, 20)
        Me.txtPorc1.TabIndex = 8
        Me.txtPorc1.Text = "0.00%"
        Me.txtPorc1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPorc2
        '
        Me.txtPorc2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtPorc2.Location = New System.Drawing.Point(344, 444)
        Me.txtPorc2.Name = "txtPorc2"
        Me.txtPorc2.ReadOnly = True
        Me.txtPorc2.Size = New System.Drawing.Size(45, 20)
        Me.txtPorc2.TabIndex = 11
        Me.txtPorc2.Text = "0.00%"
        Me.txtPorc2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPorc3
        '
        Me.txtPorc3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtPorc3.Location = New System.Drawing.Point(451, 444)
        Me.txtPorc3.Name = "txtPorc3"
        Me.txtPorc3.ReadOnly = True
        Me.txtPorc3.Size = New System.Drawing.Size(45, 20)
        Me.txtPorc3.TabIndex = 14
        Me.txtPorc3.Text = "0.00%"
        Me.txtPorc3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPorc4
        '
        Me.txtPorc4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtPorc4.Location = New System.Drawing.Point(567, 444)
        Me.txtPorc4.Name = "txtPorc4"
        Me.txtPorc4.ReadOnly = True
        Me.txtPorc4.Size = New System.Drawing.Size(45, 20)
        Me.txtPorc4.TabIndex = 17
        Me.txtPorc4.Text = "0.00%"
        Me.txtPorc4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPorc5
        '
        Me.txtPorc5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtPorc5.Location = New System.Drawing.Point(658, 444)
        Me.txtPorc5.Name = "txtPorc5"
        Me.txtPorc5.ReadOnly = True
        Me.txtPorc5.Size = New System.Drawing.Size(45, 20)
        Me.txtPorc5.TabIndex = 19
        Me.txtPorc5.Text = "0.00%"
        Me.txtPorc5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboDe
        '
        Me.cboDe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDe.FormattingEnabled = True
        Me.cboDe.Location = New System.Drawing.Point(33, 15)
        Me.cboDe.Name = "cboDe"
        Me.cboDe.Size = New System.Drawing.Size(55, 21)
        Me.cboDe.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboHasta)
        Me.GroupBox1.Controls.Add(Label8)
        Me.GroupBox1.Controls.Add(Label7)
        Me.GroupBox1.Controls.Add(Me.cboDe)
        Me.GroupBox1.Location = New System.Drawing.Point(259, 1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(186, 42)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Abonados"
        Me.GroupBox1.UseCompatibleTextRendering = True
        '
        'Label7
        '
        Label7.AutoSize = True
        Label7.Location = New System.Drawing.Point(6, 21)
        Label7.Name = "Label7"
        Label7.Size = New System.Drawing.Size(21, 13)
        Label7.TabIndex = 0
        Label7.Text = "De"
        '
        'Label8
        '
        Label8.AutoSize = True
        Label8.Location = New System.Drawing.Point(94, 21)
        Label8.Name = "Label8"
        Label8.Size = New System.Drawing.Size(13, 13)
        Label8.TabIndex = 2
        Label8.Text = "a"
        '
        'cboHasta
        '
        Me.cboHasta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboHasta.FormattingEnabled = True
        Me.cboHasta.Location = New System.Drawing.Point(113, 15)
        Me.cboHasta.Name = "cboHasta"
        Me.cboHasta.Size = New System.Drawing.Size(55, 21)
        Me.cboHasta.TabIndex = 3
        '
        'frmCumplimientoRecargas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(817, 470)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtPorc5)
        Me.Controls.Add(Me.txtPorc4)
        Me.Controls.Add(Me.txtPorc3)
        Me.Controls.Add(Me.txtPorc2)
        Me.Controls.Add(Me.txtPorc1)
        Me.Controls.Add(Me.txtTotal5)
        Me.Controls.Add(Label6)
        Me.Controls.Add(Me.txtTotal4)
        Me.Controls.Add(Label5)
        Me.Controls.Add(Me.txtTotal3)
        Me.Controls.Add(Label4)
        Me.Controls.Add(Me.txtTotal2)
        Me.Controls.Add(Label3)
        Me.Controls.Add(Label2)
        Me.Controls.Add(Me.txtTotal1)
        Me.Controls.Add(Me.Tab)
        Me.Controls.Add(Me.lbl)
        Me.Controls.Add(Me.btnConsultar)
        Me.Controls.Add(Me.dtp)
        Me.Controls.Add(Label1)
        Me.Name = "frmCumplimientoRecargas"
        Me.Text = "Cumplimiento Recargas"
        Me.Tab.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.dgv2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mnu.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        CType(Me.dgv3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage4.ResumeLayout(False)
        CType(Me.dgv4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtp As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnConsultar As System.Windows.Forms.Button
    Friend WithEvents Tab As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents dgv1 As System.Windows.Forms.DataGridView
    Friend WithEvents dgv2 As System.Windows.Forms.DataGridView
    Friend WithEvents dgv3 As System.Windows.Forms.DataGridView
    Friend WithEvents dgv4 As System.Windows.Forms.DataGridView
    Friend WithEvents col1Cod As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col1suc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col1Cliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col1Domicilio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col1Cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col4cod As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col4suc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col4cliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col4domicilio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col4intervencion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col4cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents col2cod As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col2suc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col2cliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col2domicilio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col2intervencion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col2estado As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents col2ruta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col2cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtTotal1 As System.Windows.Forms.TextBox
    Friend WithEvents txtTotal2 As System.Windows.Forms.TextBox
    Friend WithEvents txtTotal3 As System.Windows.Forms.TextBox
    Friend WithEvents txtTotal4 As System.Windows.Forms.TextBox
    Friend WithEvents txtTotal5 As System.Windows.Forms.TextBox
    Friend WithEvents mnu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuIntervencion As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSegto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtPorc1 As System.Windows.Forms.TextBox
    Friend WithEvents txtPorc2 As System.Windows.Forms.TextBox
    Friend WithEvents txtPorc3 As System.Windows.Forms.TextBox
    Friend WithEvents txtPorc4 As System.Windows.Forms.TextBox
    Friend WithEvents txtPorc5 As System.Windows.Forms.TextBox
    Friend WithEvents col3cod As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col3suc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col3cliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col3domicilio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col3intervencion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col3Retiro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col3estado As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents col3ruta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col3cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cboDe As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboHasta As System.Windows.Forms.ComboBox
End Class
