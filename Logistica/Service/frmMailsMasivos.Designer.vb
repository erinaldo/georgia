<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMailsMasivos
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
        Dim Label5 As System.Windows.Forms.Label
        Me.txtDe = New System.Windows.Forms.TextBox
        Me.txtAsunto = New System.Windows.Forms.TextBox
        Me.btnDestinos = New System.Windows.Forms.Button
        Me.btnPlantilla = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.lstMail = New System.Windows.Forms.ListBox
        Me.pb = New System.Windows.Forms.ProgressBar
        Me.btnEnviar = New System.Windows.Forms.Button
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.btnTest = New System.Windows.Forms.Button
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.txtResponder = New System.Windows.Forms.TextBox
        Label1 = New System.Windows.Forms.Label
        Label2 = New System.Windows.Forms.Label
        Label3 = New System.Windows.Forms.Label
        Label5 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(12, 15)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(24, 13)
        Label1.TabIndex = 0
        Label1.Text = "De:"
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Location = New System.Drawing.Point(12, 40)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(32, 13)
        Label2.TabIndex = 2
        Label2.Text = "Para:"
        '
        'Label3
        '
        Label3.AutoSize = True
        Label3.Location = New System.Drawing.Point(12, 95)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(43, 13)
        Label3.TabIndex = 6
        Label3.Text = "Asunto:"
        '
        'Label5
        '
        Label5.AutoSize = True
        Label5.Location = New System.Drawing.Point(12, 69)
        Label5.Name = "Label5"
        Label5.Size = New System.Drawing.Size(71, 13)
        Label5.TabIndex = 4
        Label5.Text = "Responder a:"
        '
        'txtDe
        '
        Me.txtDe.Location = New System.Drawing.Point(94, 12)
        Me.txtDe.Name = "txtDe"
        Me.txtDe.Size = New System.Drawing.Size(205, 20)
        Me.txtDe.TabIndex = 1
        '
        'txtAsunto
        '
        Me.txtAsunto.Location = New System.Drawing.Point(94, 92)
        Me.txtAsunto.Name = "txtAsunto"
        Me.txtAsunto.Size = New System.Drawing.Size(205, 20)
        Me.txtAsunto.TabIndex = 7
        '
        'btnDestinos
        '
        Me.btnDestinos.Location = New System.Drawing.Point(94, 35)
        Me.btnDestinos.Name = "btnDestinos"
        Me.btnDestinos.Size = New System.Drawing.Size(205, 23)
        Me.btnDestinos.TabIndex = 3
        Me.btnDestinos.Text = "Cargar Destinatarios"
        Me.btnDestinos.UseVisualStyleBackColor = True
        '
        'btnPlantilla
        '
        Me.btnPlantilla.Location = New System.Drawing.Point(12, 118)
        Me.btnPlantilla.Name = "btnPlantilla"
        Me.btnPlantilla.Size = New System.Drawing.Size(287, 23)
        Me.btnPlantilla.TabIndex = 8
        Me.btnPlantilla.Text = "Cargar Plantilla"
        Me.btnPlantilla.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 144)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Label4"
        Me.Label4.Visible = False
        '
        'lstMail
        '
        Me.lstMail.FormattingEnabled = True
        Me.lstMail.Location = New System.Drawing.Point(305, 12)
        Me.lstMail.Name = "lstMail"
        Me.lstMail.Size = New System.Drawing.Size(372, 264)
        Me.lstMail.TabIndex = 14
        Me.lstMail.TabStop = False
        '
        'pb
        '
        Me.pb.Location = New System.Drawing.Point(12, 217)
        Me.pb.Name = "pb"
        Me.pb.Size = New System.Drawing.Size(287, 23)
        Me.pb.TabIndex = 10
        '
        'btnEnviar
        '
        Me.btnEnviar.Location = New System.Drawing.Point(143, 246)
        Me.btnEnviar.Name = "btnEnviar"
        Me.btnEnviar.Size = New System.Drawing.Size(75, 23)
        Me.btnEnviar.TabIndex = 12
        Me.btnEnviar.Text = "Enviar"
        Me.btnEnviar.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'btnTest
        '
        Me.btnTest.Location = New System.Drawing.Point(12, 246)
        Me.btnTest.Name = "btnTest"
        Me.btnTest.Size = New System.Drawing.Size(75, 23)
        Me.btnTest.TabIndex = 11
        Me.btnTest.Text = "Test..."
        Me.btnTest.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(224, 246)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 13
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'txtResponder
        '
        Me.txtResponder.Location = New System.Drawing.Point(94, 66)
        Me.txtResponder.Name = "txtResponder"
        Me.txtResponder.Size = New System.Drawing.Size(205, 20)
        Me.txtResponder.TabIndex = 5
        '
        'frmMailsMasivos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(681, 281)
        Me.Controls.Add(Label5)
        Me.Controls.Add(Me.txtResponder)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnTest)
        Me.Controls.Add(Me.btnEnviar)
        Me.Controls.Add(Me.pb)
        Me.Controls.Add(Me.lstMail)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnPlantilla)
        Me.Controls.Add(Label3)
        Me.Controls.Add(Label2)
        Me.Controls.Add(Label1)
        Me.Controls.Add(Me.btnDestinos)
        Me.Controls.Add(Me.txtAsunto)
        Me.Controls.Add(Me.txtDe)
        Me.Name = "frmMailsMasivos"
        Me.Text = "Mails Masivos"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtDe As System.Windows.Forms.TextBox
    Friend WithEvents txtAsunto As System.Windows.Forms.TextBox
    Friend WithEvents btnDestinos As System.Windows.Forms.Button
    Friend WithEvents btnPlantilla As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lstMail As System.Windows.Forms.ListBox
    Friend WithEvents pb As System.Windows.Forms.ProgressBar
    Friend WithEvents btnEnviar As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnTest As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents txtResponder As System.Windows.Forms.TextBox
End Class
