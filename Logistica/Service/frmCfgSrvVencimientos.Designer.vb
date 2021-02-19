<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCfgSrvVencimientos
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
        Dim Label2 As System.Windows.Forms.Label
        Me.dgvVendedores = New System.Windows.Forms.DataGridView
        Me.colUsr = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colRep = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colNombre = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colAbo = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.colNoAbo = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.btnRegistrar = New System.Windows.Forms.Button
        Me.btnSalir = New System.Windows.Forms.Button
        Me.lstUsuarios = New System.Windows.Forms.ListBox
        Label2 = New System.Windows.Forms.Label
        CType(Me.dgvVendedores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Location = New System.Drawing.Point(296, 9)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(241, 13)
        Label2.TabIndex = 10
        Label2.Text = "Marcar a que vendedores el usuario tiene acceso"
        '
        'dgvVendedores
        '
        Me.dgvVendedores.AllowUserToAddRows = False
        Me.dgvVendedores.AllowUserToDeleteRows = False
        Me.dgvVendedores.AllowUserToResizeRows = False
        Me.dgvVendedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvVendedores.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colUsr, Me.colRep, Me.colNombre, Me.colAbo, Me.colNoAbo})
        Me.dgvVendedores.Location = New System.Drawing.Point(299, 25)
        Me.dgvVendedores.Name = "dgvVendedores"
        Me.dgvVendedores.RowHeadersVisible = False
        Me.dgvVendedores.Size = New System.Drawing.Size(451, 445)
        Me.dgvVendedores.TabIndex = 7
        '
        'colUsr
        '
        Me.colUsr.HeaderText = "Usuario"
        Me.colUsr.Name = "colUsr"
        Me.colUsr.ReadOnly = True
        Me.colUsr.Visible = False
        '
        'colRep
        '
        Me.colRep.HeaderText = "Cod"
        Me.colRep.Name = "colRep"
        Me.colRep.ReadOnly = True
        Me.colRep.Width = 50
        '
        'colNombre
        '
        Me.colNombre.HeaderText = "Vendedor"
        Me.colNombre.Name = "colNombre"
        Me.colNombre.ReadOnly = True
        Me.colNombre.Width = 200
        '
        'colAbo
        '
        Me.colAbo.FalseValue = "0"
        Me.colAbo.HeaderText = "Abonado"
        Me.colAbo.Name = "colAbo"
        Me.colAbo.TrueValue = "1"
        Me.colAbo.Width = 80
        '
        'colNoAbo
        '
        Me.colNoAbo.FalseValue = "0"
        Me.colNoAbo.HeaderText = "No Abonado"
        Me.colNoAbo.Name = "colNoAbo"
        Me.colNoAbo.TrueValue = "1"
        Me.colNoAbo.Width = 80
        '
        'btnRegistrar
        '
        Me.btnRegistrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRegistrar.Enabled = False
        Me.btnRegistrar.Location = New System.Drawing.Point(593, 476)
        Me.btnRegistrar.Name = "btnRegistrar"
        Me.btnRegistrar.Size = New System.Drawing.Size(75, 23)
        Me.btnRegistrar.TabIndex = 8
        Me.btnRegistrar.Text = "&Registrar"
        Me.btnRegistrar.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnSalir.Location = New System.Drawing.Point(676, 476)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(75, 23)
        Me.btnSalir.TabIndex = 9
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'lstUsuarios
        '
        Me.lstUsuarios.FormattingEnabled = True
        Me.lstUsuarios.Location = New System.Drawing.Point(12, 25)
        Me.lstUsuarios.Name = "lstUsuarios"
        Me.lstUsuarios.Size = New System.Drawing.Size(281, 446)
        Me.lstUsuarios.TabIndex = 11
        '
        'frmCfgSrvVencimientos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnSalir
        Me.ClientSize = New System.Drawing.Size(766, 511)
        Me.Controls.Add(Me.lstUsuarios)
        Me.Controls.Add(Label2)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnRegistrar)
        Me.Controls.Add(Me.dgvVendedores)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCfgSrvVencimientos"
        Me.Tag = ""
        Me.Text = "Configuraccion de accesos"
        CType(Me.dgvVendedores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvVendedores As System.Windows.Forms.DataGridView
    Friend WithEvents btnRegistrar As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents lstUsuarios As System.Windows.Forms.ListBox
    Friend WithEvents colUsr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRep As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAbo As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colNoAbo As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
