<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReporteServicios
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
        Dim GroupBox2 As System.Windows.Forms.GroupBox
        Dim GroupBox1 As System.Windows.Forms.GroupBox
        Me.btnFiltro = New System.Windows.Forms.Button
        Me.chkRecargas = New System.Windows.Forms.CheckBox
        Me.chkCocinas = New System.Windows.Forms.CheckBox
        Me.chkAgua = New System.Windows.Forms.CheckBox
        Me.chkDeteccion = New System.Windows.Forms.CheckBox
        Me.lstVendedores = New System.Windows.Forms.CheckedListBox
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker
        Me.btnBuscar = New System.Windows.Forms.Button
        Me.dgv = New System.Windows.Forms.DataGridView
        Me.colCliente = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colNombre = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colSucursal = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colDireccion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colVendedor = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colRecarga = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.colAgua = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.colDeteccion = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.colCocinas = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuMarcarTodos = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuDesmarcarTodos = New System.Windows.Forms.ToolStripMenuItem
        SplitContainer1 = New System.Windows.Forms.SplitContainer
        GroupBox2 = New System.Windows.Forms.GroupBox
        GroupBox1 = New System.Windows.Forms.GroupBox
        SplitContainer1.Panel1.SuspendLayout()
        SplitContainer1.Panel2.SuspendLayout()
        SplitContainer1.SuspendLayout()
        GroupBox2.SuspendLayout()
        GroupBox1.SuspendLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip2.SuspendLayout()
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
        SplitContainer1.Panel1.Controls.Add(Me.btnFiltro)
        SplitContainer1.Panel1.Controls.Add(GroupBox2)
        SplitContainer1.Panel1.Controls.Add(GroupBox1)
        SplitContainer1.Panel1.Controls.Add(Me.dtpFecha)
        SplitContainer1.Panel1.Controls.Add(Me.btnBuscar)
        '
        'SplitContainer1.Panel2
        '
        SplitContainer1.Panel2.Controls.Add(Me.dgv)
        SplitContainer1.Size = New System.Drawing.Size(869, 470)
        SplitContainer1.SplitterDistance = 236
        SplitContainer1.TabIndex = 2
        '
        'btnFiltro
        '
        Me.btnFiltro.Location = New System.Drawing.Point(12, 421)
        Me.btnFiltro.Name = "btnFiltro"
        Me.btnFiltro.Size = New System.Drawing.Size(210, 23)
        Me.btnFiltro.TabIndex = 3
        Me.btnFiltro.Text = "Aplicar Filtro"
        Me.btnFiltro.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        GroupBox2.Controls.Add(Me.chkRecargas)
        GroupBox2.Controls.Add(Me.chkCocinas)
        GroupBox2.Controls.Add(Me.chkAgua)
        GroupBox2.Controls.Add(Me.chkDeteccion)
        GroupBox2.Location = New System.Drawing.Point(12, 283)
        GroupBox2.Name = "GroupBox2"
        GroupBox2.Size = New System.Drawing.Size(210, 132)
        GroupBox2.TabIndex = 0
        GroupBox2.TabStop = False
        GroupBox2.Text = "Servicios"
        '
        'chkRecargas
        '
        Me.chkRecargas.AutoSize = True
        Me.chkRecargas.Checked = True
        Me.chkRecargas.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.chkRecargas.Location = New System.Drawing.Point(15, 32)
        Me.chkRecargas.Name = "chkRecargas"
        Me.chkRecargas.Size = New System.Drawing.Size(72, 17)
        Me.chkRecargas.TabIndex = 1
        Me.chkRecargas.Text = "Recargas"
        Me.chkRecargas.ThreeState = True
        Me.chkRecargas.UseVisualStyleBackColor = True
        '
        'chkCocinas
        '
        Me.chkCocinas.AutoSize = True
        Me.chkCocinas.Checked = True
        Me.chkCocinas.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.chkCocinas.Location = New System.Drawing.Point(15, 101)
        Me.chkCocinas.Name = "chkCocinas"
        Me.chkCocinas.Size = New System.Drawing.Size(64, 17)
        Me.chkCocinas.TabIndex = 7
        Me.chkCocinas.Text = "Cocinas"
        Me.chkCocinas.ThreeState = True
        Me.chkCocinas.UseVisualStyleBackColor = True
        '
        'chkAgua
        '
        Me.chkAgua.AutoSize = True
        Me.chkAgua.Checked = True
        Me.chkAgua.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.chkAgua.Location = New System.Drawing.Point(15, 55)
        Me.chkAgua.Name = "chkAgua"
        Me.chkAgua.Size = New System.Drawing.Size(51, 17)
        Me.chkAgua.TabIndex = 5
        Me.chkAgua.Text = "Agua"
        Me.chkAgua.ThreeState = True
        Me.chkAgua.UseVisualStyleBackColor = True
        '
        'chkDeteccion
        '
        Me.chkDeteccion.AutoSize = True
        Me.chkDeteccion.Checked = True
        Me.chkDeteccion.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.chkDeteccion.Location = New System.Drawing.Point(15, 78)
        Me.chkDeteccion.Name = "chkDeteccion"
        Me.chkDeteccion.Size = New System.Drawing.Size(75, 17)
        Me.chkDeteccion.TabIndex = 6
        Me.chkDeteccion.Text = "Deteccion"
        Me.chkDeteccion.ThreeState = True
        Me.chkDeteccion.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        GroupBox1.Controls.Add(Me.lstVendedores)
        GroupBox1.Location = New System.Drawing.Point(12, 91)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New System.Drawing.Size(210, 186)
        GroupBox1.TabIndex = 0
        GroupBox1.TabStop = False
        GroupBox1.Text = "Vendedores"
        '
        'lstVendedores
        '
        Me.lstVendedores.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstVendedores.CheckOnClick = True
        Me.lstVendedores.ContextMenuStrip = Me.ContextMenuStrip2
        Me.lstVendedores.FormattingEnabled = True
        Me.lstVendedores.Location = New System.Drawing.Point(6, 25)
        Me.lstVendedores.Name = "lstVendedores"
        Me.lstVendedores.Size = New System.Drawing.Size(198, 154)
        Me.lstVendedores.TabIndex = 3
        '
        'dtpFecha
        '
        Me.dtpFecha.Location = New System.Drawing.Point(12, 23)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(210, 20)
        Me.dtpFecha.TabIndex = 2
        '
        'btnBuscar
        '
        Me.btnBuscar.Location = New System.Drawing.Point(12, 62)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(210, 23)
        Me.btnBuscar.TabIndex = 0
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToDeleteRows = False
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colCliente, Me.colNombre, Me.colSucursal, Me.colDireccion, Me.colVendedor, Me.colRecarga, Me.colAgua, Me.colDeteccion, Me.colCocinas})
        Me.dgv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv.Location = New System.Drawing.Point(0, 0)
        Me.dgv.Name = "dgv"
        Me.dgv.ReadOnly = True
        Me.dgv.Size = New System.Drawing.Size(629, 470)
        Me.dgv.TabIndex = 0
        '
        'colCliente
        '
        Me.colCliente.HeaderText = "Cliente"
        Me.colCliente.Name = "colCliente"
        Me.colCliente.ReadOnly = True
        '
        'colNombre
        '
        Me.colNombre.HeaderText = "Nombre"
        Me.colNombre.Name = "colNombre"
        Me.colNombre.ReadOnly = True
        '
        'colSucursal
        '
        Me.colSucursal.HeaderText = "Sucursal"
        Me.colSucursal.Name = "colSucursal"
        Me.colSucursal.ReadOnly = True
        '
        'colDireccion
        '
        Me.colDireccion.HeaderText = "Direccion"
        Me.colDireccion.Name = "colDireccion"
        Me.colDireccion.ReadOnly = True
        '
        'colVendedor
        '
        Me.colVendedor.HeaderText = "Vendedor"
        Me.colVendedor.Name = "colVendedor"
        Me.colVendedor.ReadOnly = True
        '
        'colRecarga
        '
        Me.colRecarga.HeaderText = "Recarga"
        Me.colRecarga.Name = "colRecarga"
        Me.colRecarga.ReadOnly = True
        '
        'colAgua
        '
        Me.colAgua.HeaderText = "Agua"
        Me.colAgua.Name = "colAgua"
        Me.colAgua.ReadOnly = True
        '
        'colDeteccion
        '
        Me.colDeteccion.HeaderText = "Deteccion"
        Me.colDeteccion.Name = "colDeteccion"
        Me.colDeteccion.ReadOnly = True
        '
        'colCocinas
        '
        Me.colCocinas.HeaderText = "Cocinas"
        Me.colCocinas.Name = "colCocinas"
        Me.colCocinas.ReadOnly = True
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuMarcarTodos, Me.mnuDesmarcarTodos})
        Me.ContextMenuStrip2.Name = "ContextMenuStrip2"
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(164, 48)
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
        'frmReporteSistemasFijos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(869, 470)
        Me.Controls.Add(SplitContainer1)
        Me.Name = "frmReporteSistemasFijos"
        Me.Text = "Reporte Sistemas Fijos"
        SplitContainer1.Panel1.ResumeLayout(False)
        SplitContainer1.Panel2.ResumeLayout(False)
        SplitContainer1.ResumeLayout(False)
        GroupBox2.ResumeLayout(False)
        GroupBox2.PerformLayout()
        GroupBox1.ResumeLayout(False)
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents chkRecargas As System.Windows.Forms.CheckBox
    Friend WithEvents chkCocinas As System.Windows.Forms.CheckBox
    Friend WithEvents chkDeteccion As System.Windows.Forms.CheckBox
    Friend WithEvents chkAgua As System.Windows.Forms.CheckBox
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents colCliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSucursal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDireccion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colVendedor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRecarga As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colAgua As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colDeteccion As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colCocinas As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents btnFiltro As System.Windows.Forms.Button
    Friend WithEvents lstVendedores As System.Windows.Forms.CheckedListBox
    Friend WithEvents ContextMenuStrip2 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuMarcarTodos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesmarcarTodos As System.Windows.Forms.ToolStripMenuItem
End Class
