<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMailClientes
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
        Me.btnAceptar = New System.Windows.Forms.Button
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.txtNota = New System.Windows.Forms.TextBox
        Me.lstMotivos = New System.Windows.Forms.ListBox
        Me.txtCodigo = New System.Windows.Forms.TextBox
        Me.txtNombre = New System.Windows.Forms.TextBox
        Me.txtDireccion = New System.Windows.Forms.TextBox
        Me.txtCiudad = New System.Windows.Forms.TextBox
        Me.txtSuc = New System.Windows.Forms.TextBox
        Label1 = New System.Windows.Forms.Label
        Label2 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(12, 287)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(65, 13)
        Label1.TabIndex = 8
        Label1.Text = "Comentarios"
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Location = New System.Drawing.Point(12, 95)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(100, 13)
        Label2.TabIndex = 9
        Label2.Text = "Motivos del llamado"
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(550, 303)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 6
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Location = New System.Drawing.Point(550, 332)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 7
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'txtNota
        '
        Me.txtNota.Location = New System.Drawing.Point(12, 303)
        Me.txtNota.Multiline = True
        Me.txtNota.Name = "txtNota"
        Me.txtNota.Size = New System.Drawing.Size(524, 53)
        Me.txtNota.TabIndex = 5
        '
        'lstMotivos
        '
        Me.lstMotivos.FormattingEnabled = True
        Me.lstMotivos.Location = New System.Drawing.Point(12, 111)
        Me.lstMotivos.Name = "lstMotivos"
        Me.lstMotivos.Size = New System.Drawing.Size(613, 173)
        Me.lstMotivos.TabIndex = 4
        '
        'txtCodigo
        '
        Me.txtCodigo.Location = New System.Drawing.Point(12, 12)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.ReadOnly = True
        Me.txtCodigo.Size = New System.Drawing.Size(56, 20)
        Me.txtCodigo.TabIndex = 0
        Me.txtCodigo.TabStop = False
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(74, 12)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.ReadOnly = True
        Me.txtNombre.Size = New System.Drawing.Size(551, 20)
        Me.txtNombre.TabIndex = 1
        Me.txtNombre.TabStop = False
        '
        'txtDireccion
        '
        Me.txtDireccion.Location = New System.Drawing.Point(74, 38)
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.ReadOnly = True
        Me.txtDireccion.Size = New System.Drawing.Size(341, 20)
        Me.txtDireccion.TabIndex = 2
        Me.txtDireccion.TabStop = False
        '
        'txtCiudad
        '
        Me.txtCiudad.Location = New System.Drawing.Point(424, 38)
        Me.txtCiudad.Name = "txtCiudad"
        Me.txtCiudad.ReadOnly = True
        Me.txtCiudad.Size = New System.Drawing.Size(201, 20)
        Me.txtCiudad.TabIndex = 3
        Me.txtCiudad.TabStop = False
        '
        'txtSuc
        '
        Me.txtSuc.Location = New System.Drawing.Point(12, 38)
        Me.txtSuc.Name = "txtSuc"
        Me.txtSuc.ReadOnly = True
        Me.txtSuc.Size = New System.Drawing.Size(56, 20)
        Me.txtSuc.TabIndex = 10
        Me.txtSuc.TabStop = False
        '
        'frmMailClientes
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(638, 368)
        Me.Controls.Add(Me.txtSuc)
        Me.Controls.Add(Label2)
        Me.Controls.Add(Label1)
        Me.Controls.Add(Me.txtCiudad)
        Me.Controls.Add(Me.txtDireccion)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.txtCodigo)
        Me.Controls.Add(Me.lstMotivos)
        Me.Controls.Add(Me.txtNota)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMailClientes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Motivo de llamada"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents txtNota As System.Windows.Forms.TextBox
    Friend WithEvents lstMotivos As System.Windows.Forms.ListBox
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents txtDireccion As System.Windows.Forms.TextBox
    Friend WithEvents txtCiudad As System.Windows.Forms.TextBox
    Friend WithEvents txtSuc As System.Windows.Forms.TextBox
End Class
