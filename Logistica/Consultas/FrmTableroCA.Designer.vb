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
        Dim Label1 As System.Windows.Forms.Label
        Dim Label2 As System.Windows.Forms.Label
        Dim Label3 As System.Windows.Forms.Label
        Dim Label4 As System.Windows.Forms.Label
        Dim Label5 As System.Windows.Forms.Label
        Me.Calendar = New System.Windows.Forms.MonthCalendar
        Me.TxtBoxCantidadOperaciones = New System.Windows.Forms.TextBox
        Me.TxtBoxCantRecargasFacturadas = New System.Windows.Forms.TextBox
        Me.TxtBoxCant639 = New System.Windows.Forms.TextBox
        Me.TxtBoxFacturacion = New System.Windows.Forms.TextBox
        Me.TxtBoxClientes = New System.Windows.Forms.TextBox
        Me.btnCalcular = New System.Windows.Forms.Button
        Me.lbl = New System.Windows.Forms.Label
        Label1 = New System.Windows.Forms.Label
        Label2 = New System.Windows.Forms.Label
        Label3 = New System.Windows.Forms.Label
        Label4 = New System.Windows.Forms.Label
        Label5 = New System.Windows.Forms.Label
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
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(248, 48)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(127, 13)
        Label1.TabIndex = 1
        Label1.Text = "Cantidad de Operaciones"
        '
        'TxtBoxCantidadOperaciones
        '
        Me.TxtBoxCantidadOperaciones.Location = New System.Drawing.Point(423, 45)
        Me.TxtBoxCantidadOperaciones.Name = "TxtBoxCantidadOperaciones"
        Me.TxtBoxCantidadOperaciones.Size = New System.Drawing.Size(78, 20)
        Me.TxtBoxCantidadOperaciones.TabIndex = 2
        Me.TxtBoxCantidadOperaciones.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtBoxCantRecargasFacturadas
        '
        Me.TxtBoxCantRecargasFacturadas.Location = New System.Drawing.Point(423, 71)
        Me.TxtBoxCantRecargasFacturadas.Name = "TxtBoxCantRecargasFacturadas"
        Me.TxtBoxCantRecargasFacturadas.Size = New System.Drawing.Size(78, 20)
        Me.TxtBoxCantRecargasFacturadas.TabIndex = 4
        Me.TxtBoxCantRecargasFacturadas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Location = New System.Drawing.Point(248, 74)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(169, 13)
        Label2.TabIndex = 3
        Label2.Text = "Cantidad de Recargas Facturadas"
        '
        'TxtBoxCant639
        '
        Me.TxtBoxCant639.Location = New System.Drawing.Point(423, 100)
        Me.TxtBoxCant639.Name = "TxtBoxCant639"
        Me.TxtBoxCant639.Size = New System.Drawing.Size(78, 20)
        Me.TxtBoxCant639.TabIndex = 6
        Me.TxtBoxCant639.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Label3.AutoSize = True
        Label3.Location = New System.Drawing.Point(248, 100)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(124, 13)
        Label3.TabIndex = 5
        Label3.Text = "Cantidad 639 Aprobadas"
        '
        'TxtBoxFacturacion
        '
        Me.TxtBoxFacturacion.Location = New System.Drawing.Point(423, 126)
        Me.TxtBoxFacturacion.Name = "TxtBoxFacturacion"
        Me.TxtBoxFacturacion.Size = New System.Drawing.Size(78, 20)
        Me.TxtBoxFacturacion.TabIndex = 8
        Me.TxtBoxFacturacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Label4.AutoSize = True
        Label4.Location = New System.Drawing.Point(248, 126)
        Label4.Name = "Label4"
        Label4.Size = New System.Drawing.Size(63, 13)
        Label4.TabIndex = 7
        Label4.Text = "Facturacion"
        '
        'TxtBoxClientes
        '
        Me.TxtBoxClientes.Location = New System.Drawing.Point(423, 152)
        Me.TxtBoxClientes.Name = "TxtBoxClientes"
        Me.TxtBoxClientes.Size = New System.Drawing.Size(78, 20)
        Me.TxtBoxClientes.TabIndex = 10
        Me.TxtBoxClientes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Label5.AutoSize = True
        Label5.Location = New System.Drawing.Point(248, 152)
        Label5.Name = "Label5"
        Label5.Size = New System.Drawing.Size(153, 13)
        Label5.TabIndex = 9
        Label5.Text = "Clientes nuevos o recuperados"
        '
        'btnCalcular
        '
        Me.btnCalcular.Location = New System.Drawing.Point(426, 178)
        Me.btnCalcular.Name = "btnCalcular"
        Me.btnCalcular.Size = New System.Drawing.Size(75, 23)
        Me.btnCalcular.TabIndex = 11
        Me.btnCalcular.Text = "Calcular"
        Me.btnCalcular.UseVisualStyleBackColor = True
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.Location = New System.Drawing.Point(248, 18)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(106, 13)
        Me.lbl.TabIndex = 12
        Me.lbl.Text = "[Fechas de consulta]"
        Me.lbl.Visible = False
        '
        'FrmTableroCA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(523, 213)
        Me.Controls.Add(Me.lbl)
        Me.Controls.Add(Me.btnCalcular)
        Me.Controls.Add(Me.TxtBoxClientes)
        Me.Controls.Add(Label5)
        Me.Controls.Add(Me.TxtBoxFacturacion)
        Me.Controls.Add(Label4)
        Me.Controls.Add(Me.TxtBoxCant639)
        Me.Controls.Add(Label3)
        Me.Controls.Add(Me.TxtBoxCantRecargasFacturadas)
        Me.Controls.Add(Label2)
        Me.Controls.Add(Me.TxtBoxCantidadOperaciones)
        Me.Controls.Add(Label1)
        Me.Controls.Add(Me.Calendar)
        Me.Name = "FrmTableroCA"
        Me.Text = "Tablero CA"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Calendar As System.Windows.Forms.MonthCalendar
    Friend WithEvents TxtBoxCantidadOperaciones As System.Windows.Forms.TextBox
    Friend WithEvents TxtBoxCantRecargasFacturadas As System.Windows.Forms.TextBox
    Friend WithEvents TxtBoxCant639 As System.Windows.Forms.TextBox
    Friend WithEvents TxtBoxFacturacion As System.Windows.Forms.TextBox
    Friend WithEvents TxtBoxClientes As System.Windows.Forms.TextBox
    Friend WithEvents btnCalcular As System.Windows.Forms.Button
    Friend WithEvents lbl As System.Windows.Forms.Label
End Class
