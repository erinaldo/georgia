<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConFacturas
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
        Me.btnconsulta = New System.Windows.Forms.Button
        Me.txtfechaini = New System.Windows.Forms.TextBox
        Me.txtcliente = New System.Windows.Forms.TextBox
        Me.txtfechafin = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtsocie = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'btnconsulta
        '
        Me.btnconsulta.Location = New System.Drawing.Point(449, 7)
        Me.btnconsulta.Name = "btnconsulta"
        Me.btnconsulta.Size = New System.Drawing.Size(75, 23)
        Me.btnconsulta.TabIndex = 0
        Me.btnconsulta.Text = "Consulta"
        Me.btnconsulta.UseVisualStyleBackColor = True
        '
        'txtfechaini
        '
        Me.txtfechaini.Location = New System.Drawing.Point(129, 10)
        Me.txtfechaini.Name = "txtfechaini"
        Me.txtfechaini.Size = New System.Drawing.Size(100, 20)
        Me.txtfechaini.TabIndex = 1
        '
        'txtcliente
        '
        Me.txtcliente.Location = New System.Drawing.Point(129, 36)
        Me.txtcliente.Name = "txtcliente"
        Me.txtcliente.Size = New System.Drawing.Size(100, 20)
        Me.txtcliente.TabIndex = 2
        '
        'txtfechafin
        '
        Me.txtfechafin.Location = New System.Drawing.Point(302, 10)
        Me.txtfechafin.Name = "txtfechafin"
        Me.txtfechafin.Size = New System.Drawing.Size(100, 20)
        Me.txtfechafin.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(33, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Fecha Inicio"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(33, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Cliente"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(243, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Fecha Fin"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(243, 39)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Planta" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'txtsocie
        '
        Me.txtsocie.Location = New System.Drawing.Point(302, 36)
        Me.txtsocie.Name = "txtsocie"
        Me.txtsocie.Size = New System.Drawing.Size(100, 20)
        Me.txtsocie.TabIndex = 11
        '
        'frmConFacturas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(546, 71)
        Me.Controls.Add(Me.txtsocie)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtfechafin)
        Me.Controls.Add(Me.txtcliente)
        Me.Controls.Add(Me.txtfechaini)
        Me.Controls.Add(Me.btnconsulta)
        Me.Name = "frmConFacturas"
        Me.Text = "Consultas de listado de Facturas"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnconsulta As System.Windows.Forms.Button
    Friend WithEvents txtfechaini As System.Windows.Forms.TextBox
    Friend WithEvents txtcliente As System.Windows.Forms.TextBox
    Friend WithEvents txtfechafin As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtsocie As System.Windows.Forms.TextBox
End Class
