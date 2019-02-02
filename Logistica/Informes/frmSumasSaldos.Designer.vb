<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSumasSaldos
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
        Me.btnConsultar = New System.Windows.Forms.Button
        Me.chkDNY = New System.Windows.Forms.CheckBox
        Me.chkMON = New System.Windows.Forms.CheckBox
        Me.chkGRU = New System.Windows.Forms.CheckBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtp
        '
        Me.dtp.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp.Location = New System.Drawing.Point(74, 12)
        Me.dtp.Name = "dtp"
        Me.dtp.Size = New System.Drawing.Size(106, 20)
        Me.dtp.TabIndex = 3
        '
        'btnConsultar
        '
        Me.btnConsultar.Location = New System.Drawing.Point(15, 142)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(165, 23)
        Me.btnConsultar.TabIndex = 4
        Me.btnConsultar.Tag = "Consultar"
        Me.btnConsultar.Text = "Consultar"
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'chkDNY
        '
        Me.chkDNY.AutoSize = True
        Me.chkDNY.Checked = True
        Me.chkDNY.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDNY.Location = New System.Drawing.Point(17, 19)
        Me.chkDNY.Name = "chkDNY"
        Me.chkDNY.Size = New System.Drawing.Size(49, 17)
        Me.chkDNY.TabIndex = 9
        Me.chkDNY.Text = "DNY"
        Me.chkDNY.UseVisualStyleBackColor = True
        '
        'chkMON
        '
        Me.chkMON.AutoSize = True
        Me.chkMON.Checked = True
        Me.chkMON.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkMON.Location = New System.Drawing.Point(17, 42)
        Me.chkMON.Name = "chkMON"
        Me.chkMON.Size = New System.Drawing.Size(51, 17)
        Me.chkMON.TabIndex = 10
        Me.chkMON.Text = "MON"
        Me.chkMON.UseVisualStyleBackColor = True
        '
        'chkGRU
        '
        Me.chkGRU.AutoSize = True
        Me.chkGRU.Checked = True
        Me.chkGRU.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkGRU.Location = New System.Drawing.Point(18, 65)
        Me.chkGRU.Name = "chkGRU"
        Me.chkGRU.Size = New System.Drawing.Size(50, 17)
        Me.chkGRU.TabIndex = 11
        Me.chkGRU.Text = "GRU"
        Me.chkGRU.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkDNY)
        Me.GroupBox1.Controls.Add(Me.chkGRU)
        Me.GroupBox1.Controls.Add(Me.chkMON)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 38)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(168, 84)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Sociedades"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Fecha"
        '
        'frmSumasSaldos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(198, 181)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnConsultar)
        Me.Controls.Add(Me.dtp)
        Me.Name = "frmSumasSaldos"
        Me.Text = "Sumas y Saldos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtp As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnConsultar As System.Windows.Forms.Button
    Friend WithEvents chkDNY As System.Windows.Forms.CheckBox
    Friend WithEvents chkMON As System.Windows.Forms.CheckBox
    Friend WithEvents chkGRU As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
End Class
