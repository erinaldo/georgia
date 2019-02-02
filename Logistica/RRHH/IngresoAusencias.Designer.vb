<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IngresoAusencias
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
        Me.dtp = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txt_ausentes = New System.Windows.Forms.TextBox
        Me.txt_Dotacion = New System.Windows.Forms.TextBox
        Me.btn_Registrar = New System.Windows.Forms.Button
        Me.Btn_Modificar = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'dtp
        '
        Me.dtp.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp.Location = New System.Drawing.Point(109, 25)
        Me.dtp.Name = "dtp"
        Me.dtp.Size = New System.Drawing.Size(98, 20)
        Me.dtp.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(63, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Fecha:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(63, 94)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Dotacion"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(63, 70)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Ausentes"
        '
        'txt_ausentes
        '
        Me.txt_ausentes.Location = New System.Drawing.Point(120, 67)
        Me.txt_ausentes.Name = "txt_ausentes"
        Me.txt_ausentes.Size = New System.Drawing.Size(47, 20)
        Me.txt_ausentes.TabIndex = 4
        '
        'txt_Dotacion
        '
        Me.txt_Dotacion.Location = New System.Drawing.Point(119, 93)
        Me.txt_Dotacion.Name = "txt_Dotacion"
        Me.txt_Dotacion.Size = New System.Drawing.Size(48, 20)
        Me.txt_Dotacion.TabIndex = 5
        '
        'btn_Registrar
        '
        Me.btn_Registrar.Location = New System.Drawing.Point(132, 159)
        Me.btn_Registrar.Name = "btn_Registrar"
        Me.btn_Registrar.Size = New System.Drawing.Size(75, 23)
        Me.btn_Registrar.TabIndex = 6
        Me.btn_Registrar.Text = "Registrar"
        Me.btn_Registrar.UseVisualStyleBackColor = True
        '
        'Btn_Modificar
        '
        Me.Btn_Modificar.Location = New System.Drawing.Point(132, 130)
        Me.Btn_Modificar.Name = "Btn_Modificar"
        Me.Btn_Modificar.Size = New System.Drawing.Size(75, 23)
        Me.Btn_Modificar.TabIndex = 7
        Me.Btn_Modificar.Text = "Modificar"
        Me.Btn_Modificar.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(39, 130)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "Ver dia"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'IngresoAusencias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(232, 218)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Btn_Modificar)
        Me.Controls.Add(Me.btn_Registrar)
        Me.Controls.Add(Me.txt_Dotacion)
        Me.Controls.Add(Me.txt_ausentes)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtp)
        Me.Name = "IngresoAusencias"
        Me.Tag = ""
        Me.Text = "Ingreso Ausencias"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtp As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_ausentes As System.Windows.Forms.TextBox
    Friend WithEvents txt_Dotacion As System.Windows.Forms.TextBox
    Friend WithEvents btn_Registrar As System.Windows.Forms.Button
    Friend WithEvents Btn_Modificar As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
