<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExportarControles
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
        Me.mcal = New System.Windows.Forms.MonthCalendar
        Me.btnExportar = New System.Windows.Forms.Button
        Me.sd = New System.Windows.Forms.SaveFileDialog
        Me.lbl = New System.Windows.Forms.Label
        Me.cboTipo = New System.Windows.Forms.ComboBox
        Me.SuspendLayout()
        '
        'mcal
        '
        Me.mcal.Location = New System.Drawing.Point(18, 18)
        Me.mcal.Name = "mcal"
        Me.mcal.TabIndex = 0
        '
        'btnExportar
        '
        Me.btnExportar.Location = New System.Drawing.Point(88, 236)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(91, 23)
        Me.btnExportar.TabIndex = 1
        Me.btnExportar.Text = "Exportar..."
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'sd
        '
        Me.sd.DefaultExt = "txt"
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.Location = New System.Drawing.Point(15, 216)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(39, 13)
        Me.lbl.TabIndex = 2
        Me.lbl.Text = "Label1"
        Me.lbl.Visible = False
        '
        'cboTipo
        '
        Me.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipo.FormattingEnabled = True
        Me.cboTipo.Location = New System.Drawing.Point(18, 192)
        Me.cboTipo.Name = "cboTipo"
        Me.cboTipo.Size = New System.Drawing.Size(227, 21)
        Me.cboTipo.TabIndex = 3
        '
        'frmExportarControles
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(264, 288)
        Me.Controls.Add(Me.cboTipo)
        Me.Controls.Add(Me.lbl)
        Me.Controls.Add(Me.btnExportar)
        Me.Controls.Add(Me.mcal)
        Me.Name = "frmExportarControles"
        Me.Text = "Exportar Controles"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents mcal As System.Windows.Forms.MonthCalendar
    Friend WithEvents btnExportar As System.Windows.Forms.Button
    Friend WithEvents sd As System.Windows.Forms.SaveFileDialog
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents cboTipo As System.Windows.Forms.ComboBox
End Class
