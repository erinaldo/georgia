<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmItnList
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
        Me.ImprimirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SeguimientoDocumentacionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.VerEscaneadosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.VerRemitoEscaneadoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EquiposRechazadosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.VerOCEscaneadaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.VerDetalleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
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
        Me.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv.Size = New System.Drawing.Size(643, 372)
        Me.dgv.TabIndex = 0
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImprimirToolStripMenuItem, Me.SeguimientoDocumentacionToolStripMenuItem, Me.VerEscaneadosToolStripMenuItem, Me.VerRemitoEscaneadoToolStripMenuItem, Me.EquiposRechazadosToolStripMenuItem, Me.VerOCEscaneadaToolStripMenuItem, Me.VerDetalleToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(229, 180)
        '
        'ImprimirToolStripMenuItem
        '
        Me.ImprimirToolStripMenuItem.Name = "ImprimirToolStripMenuItem"
        Me.ImprimirToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.ImprimirToolStripMenuItem.Text = "Imprimir"
        '
        'SeguimientoDocumentacionToolStripMenuItem
        '
        Me.SeguimientoDocumentacionToolStripMenuItem.Name = "SeguimientoDocumentacionToolStripMenuItem"
        Me.SeguimientoDocumentacionToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.SeguimientoDocumentacionToolStripMenuItem.Text = "Seguimiento documentacion"
        '
        'VerEscaneadosToolStripMenuItem
        '
        Me.VerEscaneadosToolStripMenuItem.Name = "VerEscaneadosToolStripMenuItem"
        Me.VerEscaneadosToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.VerEscaneadosToolStripMenuItem.Text = "Ver Escaneados"
        '
        'VerRemitoEscaneadoToolStripMenuItem
        '
        Me.VerRemitoEscaneadoToolStripMenuItem.Name = "VerRemitoEscaneadoToolStripMenuItem"
        Me.VerRemitoEscaneadoToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.VerRemitoEscaneadoToolStripMenuItem.Text = "Ver Remito Escaneado"
        '
        'EquiposRechazadosToolStripMenuItem
        '
        Me.EquiposRechazadosToolStripMenuItem.Name = "EquiposRechazadosToolStripMenuItem"
        Me.EquiposRechazadosToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.EquiposRechazadosToolStripMenuItem.Text = "Equipos Rechazados"
        '
        'VerOCEscaneadaToolStripMenuItem
        '
        Me.VerOCEscaneadaToolStripMenuItem.Name = "VerOCEscaneadaToolStripMenuItem"
        Me.VerOCEscaneadaToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.VerOCEscaneadaToolStripMenuItem.Text = "Ver OC escaneada"
        '
        'VerDetalleToolStripMenuItem
        '
        Me.VerDetalleToolStripMenuItem.Name = "VerDetalleToolStripMenuItem"
        Me.VerDetalleToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.VerDetalleToolStripMenuItem.Text = "Ver detalle"
        '
        'frmItnList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(643, 372)
        Me.Controls.Add(Me.dgv)
        Me.Name = "frmItnList"
        Me.Text = "Formulario Intervenciones"
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ImprimirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SeguimientoDocumentacionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EquiposRechazadosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VerEscaneadosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VerRemitoEscaneadoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VerOCEscaneadaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VerDetalleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
