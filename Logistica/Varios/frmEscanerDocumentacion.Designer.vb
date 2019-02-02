<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEscanerDocumentacion
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
        Me.btn = New System.Windows.Forms.Button
        Me.lst = New System.Windows.Forms.ListBox
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuVer = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuEliminar = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator
        Me.mnuRenombrar = New System.Windows.Forms.ToolStripMenuItem
        Label1 = New System.Windows.Forms.Label
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(1, 10)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(40, 13)
        Label1.TabIndex = 2
        Label1.Text = "Errores"
        '
        'btn
        '
        Me.btn.Location = New System.Drawing.Point(446, 29)
        Me.btn.Name = "btn"
        Me.btn.Size = New System.Drawing.Size(159, 225)
        Me.btn.TabIndex = 0
        Me.btn.Text = "Procesar"
        Me.btn.UseVisualStyleBackColor = True
        '
        'lst
        '
        Me.lst.ContextMenuStrip = Me.ContextMenuStrip1
        Me.lst.FormattingEnabled = True
        Me.lst.Location = New System.Drawing.Point(1, 29)
        Me.lst.Name = "lst"
        Me.lst.Size = New System.Drawing.Size(439, 225)
        Me.lst.TabIndex = 1
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuVer, Me.ToolStripMenuItem1, Me.mnuRenombrar, Me.mnuEliminar})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(174, 76)
        '
        'mnuVer
        '
        Me.mnuVer.Name = "mnuVer"
        Me.mnuVer.Size = New System.Drawing.Size(173, 22)
        Me.mnuVer.Text = "Ver archivo..."
        '
        'mnuEliminar
        '
        Me.mnuEliminar.Name = "mnuEliminar"
        Me.mnuEliminar.Size = New System.Drawing.Size(173, 22)
        Me.mnuEliminar.Text = "Eliminar..."
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(170, 6)
        '
        'mnuRenombrar
        '
        Me.mnuRenombrar.Name = "mnuRenombrar"
        Me.mnuRenombrar.Size = New System.Drawing.Size(173, 22)
        Me.mnuRenombrar.Text = "Cambiar nombre..."
        '
        'frmEscanerDocumentacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(611, 262)
        Me.Controls.Add(Label1)
        Me.Controls.Add(Me.lst)
        Me.Controls.Add(Me.btn)
        Me.Name = "frmEscanerDocumentacion"
        Me.Text = "Procesar Documentación Escaneada"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn As System.Windows.Forms.Button
    Friend WithEvents lst As System.Windows.Forms.ListBox
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuVer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuRenombrar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuEliminar As System.Windows.Forms.ToolStripMenuItem
End Class
