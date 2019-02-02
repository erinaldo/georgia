<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsorcios
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
        Me.dgv = New System.Windows.Forms.DataGridView
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DatosClienteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.IntervencionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PedidosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PresupuestosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.FacturasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.FacturasCToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.FacturasDelClienteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToDeleteRows = False
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.ContextMenuStrip = Me.ContextMenuStrip1
        Me.dgv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv.Location = New System.Drawing.Point(0, 0)
        Me.dgv.Name = "dgv"
        Me.dgv.ReadOnly = True
        Me.dgv.RowHeadersVisible = False
        Me.dgv.Size = New System.Drawing.Size(543, 449)
        Me.dgv.TabIndex = 0
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DatosClienteToolStripMenuItem, Me.IntervencionesToolStripMenuItem, Me.PedidosToolStripMenuItem, Me.PresupuestosToolStripMenuItem, Me.FacturasToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(153, 136)
        '
        'DatosClienteToolStripMenuItem
        '
        Me.DatosClienteToolStripMenuItem.Name = "DatosClienteToolStripMenuItem"
        Me.DatosClienteToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.DatosClienteToolStripMenuItem.Text = "Datos cliente"
        '
        'IntervencionesToolStripMenuItem
        '
        Me.IntervencionesToolStripMenuItem.Name = "IntervencionesToolStripMenuItem"
        Me.IntervencionesToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.IntervencionesToolStripMenuItem.Text = "Intervenciones"
        '
        'PedidosToolStripMenuItem
        '
        Me.PedidosToolStripMenuItem.Name = "PedidosToolStripMenuItem"
        Me.PedidosToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.PedidosToolStripMenuItem.Text = "Pedidos"
        '
        'PresupuestosToolStripMenuItem
        '
        Me.PresupuestosToolStripMenuItem.Name = "PresupuestosToolStripMenuItem"
        Me.PresupuestosToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.PresupuestosToolStripMenuItem.Text = "Presupuestos"
        '
        'FacturasToolStripMenuItem
        '
        Me.FacturasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FacturasCToolStripMenuItem, Me.FacturasDelClienteToolStripMenuItem})
        Me.FacturasToolStripMenuItem.Name = "FacturasToolStripMenuItem"
        Me.FacturasToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.FacturasToolStripMenuItem.Text = "Facturas"
        '
        'FacturasCToolStripMenuItem
        '
        Me.FacturasCToolStripMenuItem.Name = "FacturasCToolStripMenuItem"
        Me.FacturasCToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.FacturasCToolStripMenuItem.Text = "Facturas de la sucursal"
        '
        'FacturasDelClienteToolStripMenuItem
        '
        Me.FacturasDelClienteToolStripMenuItem.Name = "FacturasDelClienteToolStripMenuItem"
        Me.FacturasDelClienteToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.FacturasDelClienteToolStripMenuItem.Text = "Facturas del cliente"
        '
        'frmConsorcios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(543, 449)
        Me.Controls.Add(Me.dgv)
        Me.Name = "frmConsorcios"
        Me.Text = "frmConsorcios"
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DatosClienteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IntervencionesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PedidosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PresupuestosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FacturasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FacturasCToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FacturasDelClienteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
