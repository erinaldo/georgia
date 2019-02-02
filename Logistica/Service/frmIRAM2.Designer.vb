<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmIRAM2
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
        Me.txtItn = New System.Windows.Forms.TextBox
        Me.btnImprimir = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.chkCumple = New System.Windows.Forms.CheckBox
        Me.txtObs = New System.Windows.Forms.TextBox
        Label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(10, 9)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(69, 13)
        Label1.TabIndex = 1
        Label1.Text = "Intervención:"
        '
        'txtItn
        '
        Me.txtItn.Location = New System.Drawing.Point(13, 25)
        Me.txtItn.Name = "txtItn"
        Me.txtItn.Size = New System.Drawing.Size(158, 20)
        Me.txtItn.TabIndex = 0
        '
        'btnImprimir
        '
        Me.btnImprimir.Enabled = False
        Me.btnImprimir.Location = New System.Drawing.Point(258, 100)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(75, 23)
        Me.btnImprimir.TabIndex = 2
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 97)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Label2"
        '
        'chkCumple
        '
        Me.chkCumple.AutoSize = True
        Me.chkCumple.Checked = True
        Me.chkCumple.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkCumple.Location = New System.Drawing.Point(13, 51)
        Me.chkCumple.Name = "chkCumple"
        Me.chkCumple.Size = New System.Drawing.Size(144, 17)
        Me.chkCumple.TabIndex = 4
        Me.chkCumple.Text = "Cumple con norma IRAM"
        Me.chkCumple.UseVisualStyleBackColor = True
        '
        'txtObs
        '
        Me.txtObs.Enabled = False
        Me.txtObs.Location = New System.Drawing.Point(13, 74)
        Me.txtObs.Name = "txtObs"
        Me.txtObs.Size = New System.Drawing.Size(320, 20)
        Me.txtObs.TabIndex = 5
        '
        'frmIRAM2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(345, 133)
        Me.Controls.Add(Me.txtObs)
        Me.Controls.Add(Me.chkCumple)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Label1)
        Me.Controls.Add(Me.txtItn)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "frmIRAM2"
        Me.Text = "Impresión Planilla Controles"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtItn As System.Windows.Forms.TextBox
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkCumple As System.Windows.Forms.CheckBox
    Friend WithEvents txtObs As System.Windows.Forms.TextBox
End Class
