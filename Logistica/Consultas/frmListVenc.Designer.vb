<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListVenc
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
        Me.btn = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.TXTREP = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.dtpini = New System.Windows.Forms.DateTimePicker
        Me.dtpfin = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'btn
        '
        Me.btn.Location = New System.Drawing.Point(314, 20)
        Me.btn.Name = "btn"
        Me.btn.Size = New System.Drawing.Size(72, 34)
        Me.btn.TabIndex = 0
        Me.btn.Text = "Buscar"
        Me.btn.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(51, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Representante"
        '
        'TXTREP
        '
        Me.TXTREP.Location = New System.Drawing.Point(134, 48)
        Me.TXTREP.Name = "TXTREP"
        Me.TXTREP.Size = New System.Drawing.Size(100, 20)
        Me.TXTREP.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(51, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Fecha"
        '
        'dtpini
        '
        Me.dtpini.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpini.Location = New System.Drawing.Point(94, 14)
        Me.dtpini.Name = "dtpini"
        Me.dtpini.Size = New System.Drawing.Size(84, 20)
        Me.dtpini.TabIndex = 4
        '
        'dtpfin
        '
        Me.dtpfin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpfin.Location = New System.Drawing.Point(203, 14)
        Me.dtpfin.Name = "dtpfin"
        Me.dtpfin.Size = New System.Drawing.Size(84, 20)
        Me.dtpfin.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(184, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(13, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "a"
        '
        'frmListVenc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(426, 81)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dtpfin)
        Me.Controls.Add(Me.dtpini)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TXTREP)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn)
        Me.Name = "frmListVenc"
        Me.Text = "Listado de Vencimientos"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TXTREP As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpini As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpfin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
