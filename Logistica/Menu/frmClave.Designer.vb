<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmClave
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
        Dim Label1 As System.Windows.Forms.Label
        Dim Label2 As System.Windows.Forms.Label
        Dim Label3 As System.Windows.Forms.Label
        Me.btnAceptar = New System.Windows.Forms.Button
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.txtAnterior = New System.Windows.Forms.TextBox
        Me.txtNueva = New System.Windows.Forms.TextBox
        Me.txtNueva2 = New System.Windows.Forms.TextBox
        Label1 = New System.Windows.Forms.Label
        Label2 = New System.Windows.Forms.Label
        Label3 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(17, 15)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(97, 13)
        Label1.TabIndex = 0
        Label1.Text = "Contraseña Actual:"
        Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Location = New System.Drawing.Point(17, 55)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(99, 13)
        Label2.TabIndex = 2
        Label2.Text = "Contraseña Nueva:"
        Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label3
        '
        Label3.AutoSize = True
        Label3.Location = New System.Drawing.Point(17, 81)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(100, 13)
        Label3.TabIndex = 4
        Label3.Text = "Repetir contraseña:"
        Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(358, 7)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 6
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Location = New System.Drawing.Point(358, 36)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 7
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'txtAnterior
        '
        Me.txtAnterior.Location = New System.Drawing.Point(120, 12)
        Me.txtAnterior.MaxLength = 10
        Me.txtAnterior.Name = "txtAnterior"
        Me.txtAnterior.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtAnterior.Size = New System.Drawing.Size(187, 20)
        Me.txtAnterior.TabIndex = 1
        '
        'txtNueva
        '
        Me.txtNueva.Location = New System.Drawing.Point(120, 52)
        Me.txtNueva.MaxLength = 10
        Me.txtNueva.Name = "txtNueva"
        Me.txtNueva.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtNueva.Size = New System.Drawing.Size(187, 20)
        Me.txtNueva.TabIndex = 3
        '
        'txtNueva2
        '
        Me.txtNueva2.Location = New System.Drawing.Point(120, 78)
        Me.txtNueva2.MaxLength = 10
        Me.txtNueva2.Name = "txtNueva2"
        Me.txtNueva2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtNueva2.Size = New System.Drawing.Size(187, 20)
        Me.txtNueva2.TabIndex = 5
        '
        'frmClave
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(457, 121)
        Me.Controls.Add(Label3)
        Me.Controls.Add(Label2)
        Me.Controls.Add(Label1)
        Me.Controls.Add(Me.txtNueva2)
        Me.Controls.Add(Me.txtNueva)
        Me.Controls.Add(Me.txtAnterior)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmClave"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Cambio de contraseña"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents txtAnterior As System.Windows.Forms.TextBox
    Friend WithEvents txtNueva As System.Windows.Forms.TextBox
    Friend WithEvents txtNueva2 As System.Windows.Forms.TextBox
End Class
