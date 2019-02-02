<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAutoCompleta
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
        Me.btnbuscar = New System.Windows.Forms.Button
        Me.cboxCliente = New System.Windows.Forms.ComboBox
        Me.SuspendLayout()
        '
        'btnbuscar
        '
        Me.btnbuscar.Location = New System.Drawing.Point(45, 73)
        Me.btnbuscar.Name = "btnbuscar"
        Me.btnbuscar.Size = New System.Drawing.Size(228, 28)
        Me.btnbuscar.TabIndex = 0
        Me.btnbuscar.Text = "Aceptar"
        Me.btnbuscar.UseVisualStyleBackColor = True
        '
        'cboxCliente
        '
        Me.cboxCliente.FormattingEnabled = True
        Me.cboxCliente.Location = New System.Drawing.Point(12, 29)
        Me.cboxCliente.Name = "cboxCliente"
        Me.cboxCliente.Size = New System.Drawing.Size(321, 21)
        Me.cboxCliente.TabIndex = 2
        '
        'frmAutoCompleta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(345, 120)
        Me.Controls.Add(Me.cboxCliente)
        Me.Controls.Add(Me.btnbuscar)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAutoCompleta"
        Me.Text = "Eleccion Cliente"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnbuscar As System.Windows.Forms.Button
    Friend WithEvents cboxCliente As System.Windows.Forms.ComboBox
End Class
