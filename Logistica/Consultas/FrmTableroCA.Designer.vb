<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTableroCA
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
        Me.Calendar = New System.Windows.Forms.MonthCalendar
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtBoxCantidadOperaciones = New System.Windows.Forms.TextBox
        Me.TxtBoxCantRecargasFacturadas = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtBoxCant639 = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtBoxFacturacion = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxtBoxClientes = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Calendar
        '
        Me.Calendar.Location = New System.Drawing.Point(9, 18)
        Me.Calendar.Name = "Calendar"
        Me.Calendar.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(217, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(127, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Cantidad de Operaciones"
        '
        'TxtBoxCantidadOperaciones
        '
        Me.TxtBoxCantidadOperaciones.Location = New System.Drawing.Point(350, 18)
        Me.TxtBoxCantidadOperaciones.Name = "TxtBoxCantidadOperaciones"
        Me.TxtBoxCantidadOperaciones.Size = New System.Drawing.Size(100, 20)
        Me.TxtBoxCantidadOperaciones.TabIndex = 2
        '
        'TxtBoxCantRecargasFacturadas
        '
        Me.TxtBoxCantRecargasFacturadas.Location = New System.Drawing.Point(392, 44)
        Me.TxtBoxCantRecargasFacturadas.Name = "TxtBoxCantRecargasFacturadas"
        Me.TxtBoxCantRecargasFacturadas.Size = New System.Drawing.Size(100, 20)
        Me.TxtBoxCantRecargasFacturadas.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(217, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(169, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Cantidad de Recargas Facturadas"
        '
        'TxtBoxCant639
        '
        Me.TxtBoxCant639.Location = New System.Drawing.Point(350, 70)
        Me.TxtBoxCant639.Name = "TxtBoxCant639"
        Me.TxtBoxCant639.Size = New System.Drawing.Size(100, 20)
        Me.TxtBoxCant639.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(217, 73)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(124, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Cantidad 639 Aprobadas"
        '
        'TxtBoxFacturacion
        '
        Me.TxtBoxFacturacion.Location = New System.Drawing.Point(286, 96)
        Me.TxtBoxFacturacion.Name = "TxtBoxFacturacion"
        Me.TxtBoxFacturacion.Size = New System.Drawing.Size(100, 20)
        Me.TxtBoxFacturacion.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(217, 99)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Facturacion"
        '
        'TxtBoxClientes
        '
        Me.TxtBoxClientes.Location = New System.Drawing.Point(376, 122)
        Me.TxtBoxClientes.Name = "TxtBoxClientes"
        Me.TxtBoxClientes.Size = New System.Drawing.Size(100, 20)
        Me.TxtBoxClientes.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(217, 125)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(153, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Clientes nuevos o recuperados"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(220, 158)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "Calcular"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'FrmTableroCA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(819, 213)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TxtBoxClientes)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TxtBoxFacturacion)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtBoxCant639)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtBoxCantRecargasFacturadas)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtBoxCantidadOperaciones)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Calendar)
        Me.Name = "FrmTableroCA"
        Me.Text = "TableroCA"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Calendar As System.Windows.Forms.MonthCalendar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtBoxCantidadOperaciones As System.Windows.Forms.TextBox
    Friend WithEvents TxtBoxCantRecargasFacturadas As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtBoxCant639 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtBoxFacturacion As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtBoxClientes As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
