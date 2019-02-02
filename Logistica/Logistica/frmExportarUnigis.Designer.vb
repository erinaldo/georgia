<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExportarUnigis
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
        Me.lstTipoIntervencion = New System.Windows.Forms.ListBox
        Me.chkExportarRemitos = New System.Windows.Forms.CheckBox
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
        Me.btnExportar.Location = New System.Drawing.Point(87, 214)
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
        Me.lbl.Location = New System.Drawing.Point(15, 189)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(39, 13)
        Me.lbl.TabIndex = 2
        Me.lbl.Text = "Label1"
        Me.lbl.Visible = False
        '
        'lstTipoIntervencion
        '
        Me.lstTipoIntervencion.FormattingEnabled = True
        Me.lstTipoIntervencion.Location = New System.Drawing.Point(257, 18)
        Me.lstTipoIntervencion.Name = "lstTipoIntervencion"
        Me.lstTipoIntervencion.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstTipoIntervencion.Size = New System.Drawing.Size(172, 160)
        Me.lstTipoIntervencion.TabIndex = 3
        '
        'chkExportarRemitos
        '
        Me.chkExportarRemitos.AutoSize = True
        Me.chkExportarRemitos.Checked = True
        Me.chkExportarRemitos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkExportarRemitos.Location = New System.Drawing.Point(257, 185)
        Me.chkExportarRemitos.Name = "chkExportarRemitos"
        Me.chkExportarRemitos.Size = New System.Drawing.Size(101, 17)
        Me.chkExportarRemitos.TabIndex = 4
        Me.chkExportarRemitos.Text = "Exportar remitos"
        Me.chkExportarRemitos.UseVisualStyleBackColor = True
        '
        'frmExportarUnigis
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(441, 249)
        Me.Controls.Add(Me.chkExportarRemitos)
        Me.Controls.Add(Me.lstTipoIntervencion)
        Me.Controls.Add(Me.lbl)
        Me.Controls.Add(Me.btnExportar)
        Me.Controls.Add(Me.mcal)
        Me.Name = "frmExportarUnigis"
        Me.Text = "Exportar a Unigis"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents mcal As System.Windows.Forms.MonthCalendar
    Friend WithEvents btnExportar As System.Windows.Forms.Button
    Friend WithEvents sd As System.Windows.Forms.SaveFileDialog
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents lstTipoIntervencion As System.Windows.Forms.ListBox
    Friend WithEvents chkExportarRemitos As System.Windows.Forms.CheckBox
End Class
