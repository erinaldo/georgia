<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmControles
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
        Me.mCal = New System.Windows.Forms.MonthCalendar
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.dtpInicio = New System.Windows.Forms.DateTimePicker
        Me.SuspendLayout()
        '
        'btn
        '
        Me.btn.Location = New System.Drawing.Point(18, 209)
        Me.btn.Name = "btn"
        Me.btn.Size = New System.Drawing.Size(227, 23)
        Me.btn.TabIndex = 0
        Me.btn.Text = "Generar Intervenciones"
        Me.btn.UseVisualStyleBackColor = True
        '
        'mCal
        '
        Me.mCal.Location = New System.Drawing.Point(18, 18)
        Me.mCal.MaxSelectionCount = 1
        Me.mCal.Name = "mCal"
        Me.mCal.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(3, 235)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(249, 24)
        Me.Label1.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(24, 189)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Fecha de impresión"
        '
        'dtpInicio
        '
        Me.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpInicio.Location = New System.Drawing.Point(159, 183)
        Me.dtpInicio.Name = "dtpInicio"
        Me.dtpInicio.Size = New System.Drawing.Size(86, 20)
        Me.dtpInicio.TabIndex = 4
        '
        'frmControles
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(264, 264)
        Me.Controls.Add(Me.dtpInicio)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.mCal)
        Me.Controls.Add(Me.btn)
        Me.Name = "frmControles"
        Me.Text = "Intervenciones Controles"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn As System.Windows.Forms.Button
    Friend WithEvents mCal As System.Windows.Forms.MonthCalendar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpInicio As System.Windows.Forms.DateTimePicker
End Class
