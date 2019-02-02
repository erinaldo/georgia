<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPermisos
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
        Me.tree = New System.Windows.Forms.TreeView
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuPermisosSecundarios = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuEliminarPermisoSecundario = New System.Windows.Forms.ToolStripMenuItem
        Me.btnSalir = New System.Windows.Forms.Button
        Me.btnRegistrar = New System.Windows.Forms.Button
        Me.lstUsuarios = New System.Windows.Forms.ListBox
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tree
        '
        Me.tree.CheckBoxes = True
        Me.tree.ContextMenuStrip = Me.ContextMenuStrip1
        Me.tree.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tree.Location = New System.Drawing.Point(0, 0)
        Me.tree.Margin = New System.Windows.Forms.Padding(0)
        Me.tree.Name = "tree"
        Me.tree.Size = New System.Drawing.Size(458, 412)
        Me.tree.TabIndex = 1
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuPermisosSecundarios, Me.mnuEliminarPermisoSecundario})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(239, 48)
        '
        'mnuPermisosSecundarios
        '
        Me.mnuPermisosSecundarios.Name = "mnuPermisosSecundarios"
        Me.mnuPermisosSecundarios.Size = New System.Drawing.Size(238, 22)
        Me.mnuPermisosSecundarios.Text = "Editar permisos secundarios..."
        '
        'mnuEliminarPermisoSecundario
        '
        Me.mnuEliminarPermisoSecundario.Name = "mnuEliminarPermisoSecundario"
        Me.mnuEliminarPermisoSecundario.Size = New System.Drawing.Size(238, 22)
        Me.mnuEliminarPermisoSecundario.Text = "Eliminar permisos secundarios..."
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnSalir.Location = New System.Drawing.Point(605, 418)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(75, 23)
        Me.btnSalir.TabIndex = 2
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnRegistrar
        '
        Me.btnRegistrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRegistrar.Enabled = False
        Me.btnRegistrar.Location = New System.Drawing.Point(515, 418)
        Me.btnRegistrar.Name = "btnRegistrar"
        Me.btnRegistrar.Size = New System.Drawing.Size(75, 23)
        Me.btnRegistrar.TabIndex = 3
        Me.btnRegistrar.Text = "&Registrar"
        Me.btnRegistrar.UseVisualStyleBackColor = True
        '
        'lstUsuarios
        '
        Me.lstUsuarios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstUsuarios.FormattingEnabled = True
        Me.lstUsuarios.Location = New System.Drawing.Point(0, 0)
        Me.lstUsuarios.Name = "lstUsuarios"
        Me.lstUsuarios.Size = New System.Drawing.Size(230, 407)
        Me.lstUsuarios.TabIndex = 6
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.lstUsuarios)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.tree)
        Me.SplitContainer1.Size = New System.Drawing.Size(692, 412)
        Me.SplitContainer1.SplitterDistance = 230
        Me.SplitContainer1.TabIndex = 7
        '
        'frmPermisos
        '
        Me.AcceptButton = Me.btnRegistrar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnSalir
        Me.ClientSize = New System.Drawing.Size(693, 453)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.btnRegistrar)
        Me.Controls.Add(Me.btnSalir)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPermisos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Permisos"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tree As System.Windows.Forms.TreeView
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents btnRegistrar As System.Windows.Forms.Button
    Friend WithEvents lstUsuarios As System.Windows.Forms.ListBox
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuPermisosSecundarios As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuEliminarPermisoSecundario As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
End Class
