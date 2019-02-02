<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUsuarios
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
        Me.btnSalir = New System.Windows.Forms.Button
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.btnRegistrar = New System.Windows.Forms.Button
        Me.dgvADX = New System.Windows.Forms.DataGridView
        Me.colADXusr = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colADXNombre = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnAddSel = New System.Windows.Forms.Button
        Me.dgvNET = New System.Windows.Forms.DataGridView
        Me.colNETusr = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colNETnombre = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colNETclave = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnDelSel = New System.Windows.Forms.Button
        Me.mnuContext = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuCambiarClave = New System.Windows.Forms.ToolStripMenuItem
        Label1 = New System.Windows.Forms.Label
        Label2 = New System.Windows.Forms.Label
        CType(Me.dgvADX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvNET, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnuContext.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(12, 19)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(86, 13)
        Label1.TabIndex = 0
        Label1.Text = "Usuarios Adonix:"
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Location = New System.Drawing.Point(407, 19)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(106, 13)
        Label2.TabIndex = 4
        Label2.Text = "Usuarios Habilitados:"
        '
        'btnSalir
        '
        Me.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnSalir.Location = New System.Drawing.Point(652, 415)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(79, 23)
        Me.btnSalir.TabIndex = 8
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Enabled = False
        Me.btnCancelar.Location = New System.Drawing.Point(567, 415)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(79, 23)
        Me.btnCancelar.TabIndex = 7
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnRegistrar
        '
        Me.btnRegistrar.Enabled = False
        Me.btnRegistrar.Location = New System.Drawing.Point(482, 415)
        Me.btnRegistrar.Name = "btnRegistrar"
        Me.btnRegistrar.Size = New System.Drawing.Size(79, 23)
        Me.btnRegistrar.TabIndex = 6
        Me.btnRegistrar.Text = "&Registrar"
        Me.btnRegistrar.UseVisualStyleBackColor = True
        '
        'dgvADX
        '
        Me.dgvADX.AllowUserToAddRows = False
        Me.dgvADX.AllowUserToDeleteRows = False
        Me.dgvADX.AllowUserToResizeRows = False
        Me.dgvADX.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvADX.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colADXusr, Me.colADXNombre})
        Me.dgvADX.Location = New System.Drawing.Point(12, 35)
        Me.dgvADX.Name = "dgvADX"
        Me.dgvADX.ReadOnly = True
        Me.dgvADX.Size = New System.Drawing.Size(321, 365)
        Me.dgvADX.TabIndex = 1
        '
        'colADXusr
        '
        Me.colADXusr.HeaderText = "Código"
        Me.colADXusr.Name = "colADXusr"
        Me.colADXusr.ReadOnly = True
        Me.colADXusr.Width = 50
        '
        'colADXNombre
        '
        Me.colADXNombre.HeaderText = "Nombre"
        Me.colADXNombre.Name = "colADXNombre"
        Me.colADXNombre.ReadOnly = True
        Me.colADXNombre.Width = 190
        '
        'btnAddSel
        '
        Me.btnAddSel.Location = New System.Drawing.Point(349, 175)
        Me.btnAddSel.Name = "btnAddSel"
        Me.btnAddSel.Size = New System.Drawing.Size(41, 23)
        Me.btnAddSel.TabIndex = 2
        Me.btnAddSel.Text = ">"
        Me.btnAddSel.UseVisualStyleBackColor = True
        '
        'dgvNET
        '
        Me.dgvNET.AllowUserToAddRows = False
        Me.dgvNET.AllowUserToDeleteRows = False
        Me.dgvNET.AllowUserToResizeRows = False
        Me.dgvNET.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvNET.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colNETusr, Me.colNETnombre, Me.colNETclave})
        Me.dgvNET.Location = New System.Drawing.Point(410, 35)
        Me.dgvNET.Name = "dgvNET"
        Me.dgvNET.ReadOnly = True
        Me.dgvNET.Size = New System.Drawing.Size(321, 365)
        Me.dgvNET.TabIndex = 5
        '
        'colNETusr
        '
        Me.colNETusr.HeaderText = "Código"
        Me.colNETusr.Name = "colNETusr"
        Me.colNETusr.ReadOnly = True
        Me.colNETusr.Width = 50
        '
        'colNETnombre
        '
        Me.colNETnombre.HeaderText = "Nombre"
        Me.colNETnombre.Name = "colNETnombre"
        Me.colNETnombre.ReadOnly = True
        Me.colNETnombre.Width = 190
        '
        'colNETclave
        '
        Me.colNETclave.HeaderText = "Clave"
        Me.colNETclave.Name = "colNETclave"
        Me.colNETclave.ReadOnly = True
        Me.colNETclave.Visible = False
        '
        'btnDelSel
        '
        Me.btnDelSel.Location = New System.Drawing.Point(349, 204)
        Me.btnDelSel.Name = "btnDelSel"
        Me.btnDelSel.Size = New System.Drawing.Size(41, 23)
        Me.btnDelSel.TabIndex = 3
        Me.btnDelSel.Text = "<"
        Me.btnDelSel.UseVisualStyleBackColor = True
        '
        'mnuContext
        '
        Me.mnuContext.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuCambiarClave})
        Me.mnuContext.Name = "mnuContext"
        Me.mnuContext.Size = New System.Drawing.Size(194, 26)
        '
        'mnuCambiarClave
        '
        Me.mnuCambiarClave.Name = "mnuCambiarClave"
        Me.mnuCambiarClave.Size = New System.Drawing.Size(193, 22)
        Me.mnuCambiarClave.Text = "Cambiar contraseña..."
        '
        'frmUsuarios
        '
        Me.AcceptButton = Me.btnRegistrar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnSalir
        Me.ClientSize = New System.Drawing.Size(746, 450)
        Me.Controls.Add(Me.btnDelSel)
        Me.Controls.Add(Me.dgvNET)
        Me.Controls.Add(Label2)
        Me.Controls.Add(Label1)
        Me.Controls.Add(Me.btnAddSel)
        Me.Controls.Add(Me.dgvADX)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnRegistrar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmUsuarios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Usuarios"
        CType(Me.dgvADX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvNET, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mnuContext.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnRegistrar As System.Windows.Forms.Button
    Friend WithEvents dgvADX As System.Windows.Forms.DataGridView
    Friend WithEvents btnAddSel As System.Windows.Forms.Button
    Friend WithEvents dgvNET As System.Windows.Forms.DataGridView
    Friend WithEvents btnDelSel As System.Windows.Forms.Button
    Friend WithEvents colADXusr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colADXNombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNETusr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNETnombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNETclave As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents mnuContext As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuCambiarClave As System.Windows.Forms.ToolStripMenuItem
End Class
