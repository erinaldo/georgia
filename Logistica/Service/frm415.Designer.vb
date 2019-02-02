<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm415
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
        Me.dtpInicio = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.mCal = New System.Windows.Forms.MonthCalendar
        Me.btn = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'dtpInicio
        '
        Me.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpInicio.Location = New System.Drawing.Point(166, 180)
        Me.dtpInicio.Name = "dtpInicio"
        Me.dtpInicio.Size = New System.Drawing.Size(86, 20)
        Me.dtpInicio.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(31, 186)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Fecha de impresión"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(10, 232)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(249, 24)
        Me.Label1.TabIndex = 7
        '
        'mCal
        '
        Me.mCal.Location = New System.Drawing.Point(25, 15)
        Me.mCal.MaxSelectionCount = 1
        Me.mCal.Name = "mCal"
        Me.mCal.TabIndex = 6
        '
        'btn
        '
        Me.btn.Location = New System.Drawing.Point(25, 206)
        Me.btn.Name = "btn"
        Me.btn.Size = New System.Drawing.Size(227, 23)
        Me.btn.TabIndex = 5
        Me.btn.Text = "Generar Intervenciones"
        Me.btn.UseVisualStyleBackColor = True
        '
        'frm415
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(268, 270)
        Me.Controls.Add(Me.dtpInicio)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.mCal)
        Me.Controls.Add(Me.btn)
        Me.Name = "frm415"
        Me.Text = "Intervenciones 639"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtpInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents mCal As System.Windows.Forms.MonthCalendar
    Friend WithEvents btn As System.Windows.Forms.Button
End Class
