<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmInforme693
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
        Me.Button1 = New System.Windows.Forms.Button
        Me.Cliente = New System.Windows.Forms.TextBox
        Me.Sucursal = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        Me.TextoCliente = New System.Windows.Forms.TextBox
        Me.textoSucursal = New System.Windows.Forms.TextBox
        Me.dtp = New System.Windows.Forms.DateTimePicker
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.Button3 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(246, 104)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(186, 29)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Adjuntar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Cliente
        '
        Me.Cliente.Location = New System.Drawing.Point(73, 17)
        Me.Cliente.MaxLength = 6
        Me.Cliente.Name = "Cliente"
        Me.Cliente.Size = New System.Drawing.Size(100, 20)
        Me.Cliente.TabIndex = 2
        '
        'Sucursal
        '
        Me.Sucursal.Location = New System.Drawing.Point(73, 60)
        Me.Sucursal.MaxLength = 3
        Me.Sucursal.Name = "Sucursal"
        Me.Sucursal.Size = New System.Drawing.Size(100, 20)
        Me.Sucursal.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Nro Cliente"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 63)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Nro Suc"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(462, 4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(213, 29)
        Me.Button2.TabIndex = 11
        Me.Button2.Text = "Ver"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'TextoCliente
        '
        Me.TextoCliente.Enabled = False
        Me.TextoCliente.Location = New System.Drawing.Point(179, 17)
        Me.TextoCliente.Name = "TextoCliente"
        Me.TextoCliente.Size = New System.Drawing.Size(253, 20)
        Me.TextoCliente.TabIndex = 12
        '
        'textoSucursal
        '
        Me.textoSucursal.Enabled = False
        Me.textoSucursal.Location = New System.Drawing.Point(179, 60)
        Me.textoSucursal.Name = "textoSucursal"
        Me.textoSucursal.Size = New System.Drawing.Size(253, 20)
        Me.textoSucursal.TabIndex = 13
        '
        'dtp
        '
        Me.dtp.Enabled = False
        Me.dtp.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp.Location = New System.Drawing.Point(11, 113)
        Me.dtp.Name = "dtp"
        Me.dtp.Size = New System.Drawing.Size(90, 20)
        Me.dtp.TabIndex = 14
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(462, 38)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(213, 95)
        Me.ListBox1.TabIndex = 15
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(135, 104)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(105, 29)
        Me.Button3.TabIndex = 16
        Me.Button3.Text = "Limpiar"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'FrmInforme693
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(687, 161)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.dtp)
        Me.Controls.Add(Me.textoSucursal)
        Me.Controls.Add(Me.TextoCliente)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Sucursal)
        Me.Controls.Add(Me.Cliente)
        Me.Controls.Add(Me.Button1)
        Me.Name = "FrmInforme693"
        Me.Text = "Informes 639"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Cliente As System.Windows.Forms.TextBox
    Friend WithEvents Sucursal As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents TextoCliente As System.Windows.Forms.TextBox
    Friend WithEvents textoSucursal As System.Windows.Forms.TextBox
    Friend WithEvents dtp As System.Windows.Forms.DateTimePicker
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
End Class
