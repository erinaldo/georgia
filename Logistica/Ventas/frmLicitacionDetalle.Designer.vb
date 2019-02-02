<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLicitacionDetalle
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.dgv = New System.Windows.Forms.DataGridView
        Me.cms = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuTildarTodo = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuDestildarTodo = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.btnGrabar = New System.Windows.Forms.Button
        Me.colNro = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colLig = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colArticulo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colDescripcion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCantidad = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colPrecio = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colGanada = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.colCantidad2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colPrecio2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colEmpresa = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cms.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToDeleteRows = False
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colNro, Me.colLig, Me.colArticulo, Me.colDescripcion, Me.colCantidad, Me.colPrecio, Me.colGanada, Me.colCantidad2, Me.colPrecio2, Me.colEmpresa})
        Me.dgv.ContextMenuStrip = Me.cms
        Me.dgv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv.Location = New System.Drawing.Point(0, 0)
        Me.dgv.Name = "dgv"
        Me.dgv.Size = New System.Drawing.Size(992, 395)
        Me.dgv.TabIndex = 0
        '
        'cms
        '
        Me.cms.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuTildarTodo, Me.mnuDestildarTodo, Me.ToolStripMenuItem1})
        Me.cms.Name = "cms"
        Me.cms.Size = New System.Drawing.Size(149, 54)
        '
        'mnuTildarTodo
        '
        Me.mnuTildarTodo.Name = "mnuTildarTodo"
        Me.mnuTildarTodo.Size = New System.Drawing.Size(148, 22)
        Me.mnuTildarTodo.Text = "Tildar todo"
        '
        'mnuDestildarTodo
        '
        Me.mnuDestildarTodo.Name = "mnuDestildarTodo"
        Me.mnuDestildarTodo.Size = New System.Drawing.Size(148, 22)
        Me.mnuDestildarTodo.Text = "Destildar todo"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(145, 6)
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.dgv)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnGrabar)
        Me.SplitContainer1.Size = New System.Drawing.Size(992, 454)
        Me.SplitContainer1.SplitterDistance = 395
        Me.SplitContainer1.TabIndex = 1
        '
        'btnGrabar
        '
        Me.btnGrabar.Location = New System.Drawing.Point(635, 20)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(75, 23)
        Me.btnGrabar.TabIndex = 0
        Me.btnGrabar.Text = "Grabar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'colNro
        '
        Me.colNro.HeaderText = "Nro"
        Me.colNro.Name = "colNro"
        Me.colNro.Visible = False
        '
        'colLig
        '
        Me.colLig.HeaderText = "Linea"
        Me.colLig.Name = "colLig"
        Me.colLig.Visible = False
        '
        'colArticulo
        '
        Me.colArticulo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colArticulo.HeaderText = "Articulo"
        Me.colArticulo.Name = "colArticulo"
        Me.colArticulo.Width = 67
        '
        'colDescripcion
        '
        Me.colDescripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colDescripcion.HeaderText = "Descripción"
        Me.colDescripcion.Name = "colDescripcion"
        Me.colDescripcion.Width = 88
        '
        'colCantidad
        '
        Me.colCantidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colCantidad.DefaultCellStyle = DataGridViewCellStyle1
        Me.colCantidad.HeaderText = "Cantidad"
        Me.colCantidad.Name = "colCantidad"
        Me.colCantidad.Width = 74
        '
        'colPrecio
        '
        Me.colPrecio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N2"
        Me.colPrecio.DefaultCellStyle = DataGridViewCellStyle2
        Me.colPrecio.HeaderText = "Precio"
        Me.colPrecio.Name = "colPrecio"
        Me.colPrecio.Width = 62
        '
        'colGanada
        '
        Me.colGanada.FalseValue = "0"
        Me.colGanada.HeaderText = "Ganada"
        Me.colGanada.Name = "colGanada"
        Me.colGanada.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colGanada.TrueValue = "1"
        '
        'colCantidad2
        '
        Me.colCantidad2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colCantidad2.DefaultCellStyle = DataGridViewCellStyle3
        Me.colCantidad2.HeaderText = "Cantidad"
        Me.colCantidad2.Name = "colCantidad2"
        Me.colCantidad2.Width = 74
        '
        'colPrecio2
        '
        Me.colPrecio2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N2"
        Me.colPrecio2.DefaultCellStyle = DataGridViewCellStyle4
        Me.colPrecio2.HeaderText = "Precio"
        Me.colPrecio2.Name = "colPrecio2"
        Me.colPrecio2.Width = 62
        '
        'colEmpresa
        '
        Me.colEmpresa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colEmpresa.HeaderText = "Empresa"
        Me.colEmpresa.Name = "colEmpresa"
        Me.colEmpresa.Width = 73
        '
        'frmLicitacionDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(992, 454)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "frmLicitacionDetalle"
        Me.Text = "Detalle de Licitación"
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cms.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents cms As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuTildarTodo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDestildarTodo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents colNro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colLig As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colArticulo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDescripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPrecio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colGanada As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colCantidad2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPrecio2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colEmpresa As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
