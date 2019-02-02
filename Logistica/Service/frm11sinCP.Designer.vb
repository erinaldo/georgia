<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm11sinCP
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
        Dim Label2 As System.Windows.Forms.Label
        Dim Label1 As System.Windows.Forms.Label
        Dim Label3 As System.Windows.Forms.Label
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.btnBuscar = New System.Windows.Forms.Button
        Me.lstVendedores = New System.Windows.Forms.CheckedListBox
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuMarcarTodos = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuDesmarcarTodos = New System.Windows.Forms.ToolStripMenuItem
        Me.btn2 = New System.Windows.Forms.Button
        Me.btnCrear = New System.Windows.Forms.Button
        Me.cboTipo = New System.Windows.Forms.ComboBox
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.dgv = New System.Windows.Forms.DataGridView
        Me.colCodigo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colConsorcio = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colDomicilio = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colVendedor = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCodigoAdmin = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colAdministracion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colSuc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.activo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RecuperadoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PerdidoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Label2 = New System.Windows.Forms.Label
        Label1 = New System.Windows.Forms.Label
        Label3 = New System.Windows.Forms.Label
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Location = New System.Drawing.Point(9, 6)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(67, 13)
        Label2.TabIndex = 3
        Label2.Text = "Vendedores:"
        '
        'Label1
        '
        Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(3, 458)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(32, 13)
        Label1.TabIndex = 6
        Label1.Text = "Crear"
        '
        'Label3
        '
        Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Label3.AutoSize = True
        Label3.Location = New System.Drawing.Point(240, 458)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(28, 13)
        Label3.TabIndex = 8
        Label3.Text = "para"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnBuscar)
        Me.SplitContainer1.Panel1.Controls.Add(Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lstVendedores)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.btn2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnCrear)
        Me.SplitContainer1.Panel2.Controls.Add(Label3)
        Me.SplitContainer1.Panel2.Controls.Add(Me.cboTipo)
        Me.SplitContainer1.Panel2.Controls.Add(Label1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.DateTimePicker1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgv)
        Me.SplitContainer1.Size = New System.Drawing.Size(927, 488)
        Me.SplitContainer1.SplitterDistance = 206
        Me.SplitContainer1.TabIndex = 0
        '
        'btnBuscar
        '
        Me.btnBuscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnBuscar.Location = New System.Drawing.Point(57, 453)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(75, 23)
        Me.btnBuscar.TabIndex = 5
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'lstVendedores
        '
        Me.lstVendedores.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstVendedores.CheckOnClick = True
        Me.lstVendedores.ContextMenuStrip = Me.ContextMenuStrip1
        Me.lstVendedores.FormattingEnabled = True
        Me.lstVendedores.Location = New System.Drawing.Point(12, 22)
        Me.lstVendedores.Name = "lstVendedores"
        Me.lstVendedores.Size = New System.Drawing.Size(183, 424)
        Me.lstVendedores.TabIndex = 4
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuMarcarTodos, Me.mnuDesmarcarTodos})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip2"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(164, 48)
        '
        'mnuMarcarTodos
        '
        Me.mnuMarcarTodos.Name = "mnuMarcarTodos"
        Me.mnuMarcarTodos.Size = New System.Drawing.Size(163, 22)
        Me.mnuMarcarTodos.Text = "Marcar todos"
        '
        'mnuDesmarcarTodos
        '
        Me.mnuDesmarcarTodos.Name = "mnuDesmarcarTodos"
        Me.mnuDesmarcarTodos.Size = New System.Drawing.Size(163, 22)
        Me.mnuDesmarcarTodos.Text = "Desmarcar todos"
        '
        'btn2
        '
        Me.btn2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn2.Enabled = False
        Me.btn2.Location = New System.Drawing.Point(527, 452)
        Me.btn2.Name = "btn2"
        Me.btn2.Size = New System.Drawing.Size(178, 23)
        Me.btn2.TabIndex = 9
        Me.btn2.Text = "Crear Parque e ir a vencimientos"
        Me.btn2.UseVisualStyleBackColor = True
        '
        'btnCrear
        '
        Me.btnCrear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCrear.Enabled = False
        Me.btnCrear.Location = New System.Drawing.Point(410, 453)
        Me.btnCrear.Name = "btnCrear"
        Me.btnCrear.Size = New System.Drawing.Size(107, 23)
        Me.btnCrear.TabIndex = 6
        Me.btnCrear.Text = "Crear Parque"
        Me.btnCrear.UseVisualStyleBackColor = True
        '
        'cboTipo
        '
        Me.cboTipo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipo.Enabled = False
        Me.cboTipo.FormattingEnabled = True
        Me.cboTipo.Location = New System.Drawing.Point(41, 453)
        Me.cboTipo.Name = "cboTipo"
        Me.cboTipo.Size = New System.Drawing.Size(193, 21)
        Me.cboTipo.TabIndex = 7
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.DateTimePicker1.CustomFormat = "MMMM yyyy"
        Me.DateTimePicker1.Enabled = False
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker1.Location = New System.Drawing.Point(274, 454)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(130, 20)
        Me.DateTimePicker1.TabIndex = 1
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToDeleteRows = False
        Me.dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colCodigo, Me.colConsorcio, Me.colDomicilio, Me.colVendedor, Me.colCodigoAdmin, Me.colAdministracion, Me.colSuc, Me.activo})
        Me.dgv.ContextMenuStrip = Me.ContextMenuStrip2
        Me.dgv.Location = New System.Drawing.Point(0, 0)
        Me.dgv.Name = "dgv"
        Me.dgv.ReadOnly = True
        Me.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv.Size = New System.Drawing.Size(717, 446)
        Me.dgv.TabIndex = 0
        '
        'colCodigo
        '
        Me.colCodigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colCodigo.HeaderText = "Codigo"
        Me.colCodigo.Name = "colCodigo"
        Me.colCodigo.ReadOnly = True
        Me.colCodigo.Width = 65
        '
        'colConsorcio
        '
        Me.colConsorcio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colConsorcio.HeaderText = "Consorcio"
        Me.colConsorcio.Name = "colConsorcio"
        Me.colConsorcio.ReadOnly = True
        '
        'colDomicilio
        '
        Me.colDomicilio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colDomicilio.HeaderText = "Domicilio"
        Me.colDomicilio.Name = "colDomicilio"
        Me.colDomicilio.ReadOnly = True
        '
        'colVendedor
        '
        Me.colVendedor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colVendedor.HeaderText = "Vendedor"
        Me.colVendedor.Name = "colVendedor"
        Me.colVendedor.ReadOnly = True
        Me.colVendedor.Width = 78
        '
        'colCodigoAdmin
        '
        Me.colCodigoAdmin.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colCodigoAdmin.HeaderText = "Codigo"
        Me.colCodigoAdmin.Name = "colCodigoAdmin"
        Me.colCodigoAdmin.ReadOnly = True
        Me.colCodigoAdmin.Width = 65
        '
        'colAdministracion
        '
        Me.colAdministracion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colAdministracion.HeaderText = "Administracion"
        Me.colAdministracion.Name = "colAdministracion"
        Me.colAdministracion.ReadOnly = True
        '
        'colSuc
        '
        Me.colSuc.HeaderText = "Sucursal"
        Me.colSuc.Name = "colSuc"
        Me.colSuc.ReadOnly = True
        Me.colSuc.Visible = False
        '
        'activo
        '
        Me.activo.HeaderText = "activo"
        Me.activo.Name = "activo"
        Me.activo.ReadOnly = True
        Me.activo.Visible = False
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RecuperadoToolStripMenuItem, Me.PerdidoToolStripMenuItem})
        Me.ContextMenuStrip2.Name = "ContextMenuStrip2"
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(138, 48)
        '
        'RecuperadoToolStripMenuItem
        '
        Me.RecuperadoToolStripMenuItem.Name = "RecuperadoToolStripMenuItem"
        Me.RecuperadoToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
        Me.RecuperadoToolStripMenuItem.Text = "Recuperado"
        '
        'PerdidoToolStripMenuItem
        '
        Me.PerdidoToolStripMenuItem.Name = "PerdidoToolStripMenuItem"
        Me.PerdidoToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
        Me.PerdidoToolStripMenuItem.Text = "Perdido"
        '
        'frm11sinCP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(927, 488)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "frm11sinCP"
        Me.Text = "Consorcios sin Controles Periódicos"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents lstVendedores As System.Windows.Forms.CheckedListBox
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuMarcarTodos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesmarcarTodos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cboTipo As System.Windows.Forms.ComboBox
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnCrear As System.Windows.Forms.Button
    Friend WithEvents colCodigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsorcio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDomicilio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colVendedor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCodigoAdmin As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAdministracion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSuc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents activo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContextMenuStrip2 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents RecuperadoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PerdidoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btn2 As System.Windows.Forms.Button
End Class
