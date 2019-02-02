<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmArcibaNc
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
        Me.btnAbrir = New System.Windows.Forms.Button
        Me.lblArchivo = New System.Windows.Forms.Label
        Me.btnCorregir = New System.Windows.Forms.Button
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(12, 9)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(327, 13)
        Label1.TabIndex = 0
        Label1.Text = "Corrije redondeo en los importes del TXT que se importa en ARCIBA"
        '
        'btnAbrir
        '
        Me.btnAbrir.Location = New System.Drawing.Point(15, 53)
        Me.btnAbrir.Name = "btnAbrir"
        Me.btnAbrir.Size = New System.Drawing.Size(75, 23)
        Me.btnAbrir.TabIndex = 1
        Me.btnAbrir.Text = "Abrir..."
        Me.btnAbrir.UseVisualStyleBackColor = True
        '
        'lblArchivo
        '
        Me.lblArchivo.AutoSize = True
        Me.lblArchivo.Location = New System.Drawing.Point(12, 79)
        Me.lblArchivo.Name = "lblArchivo"
        Me.lblArchivo.Size = New System.Drawing.Size(0, 13)
        Me.lblArchivo.TabIndex = 2
        '
        'btnCorregir
        '
        Me.btnCorregir.Location = New System.Drawing.Point(96, 53)
        Me.btnCorregir.Name = "btnCorregir"
        Me.btnCorregir.Size = New System.Drawing.Size(75, 23)
        Me.btnCorregir.TabIndex = 3
        Me.btnCorregir.Text = "Corregir"
        Me.btnCorregir.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'frmArcibaNc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(392, 122)
        Me.Controls.Add(Me.btnCorregir)
        Me.Controls.Add(Me.lblArchivo)
        Me.Controls.Add(Me.btnAbrir)
        Me.Controls.Add(Label1)
        Me.Name = "frmArcibaNc"
        Me.Text = "Arciba Notas de Crédito"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnAbrir As System.Windows.Forms.Button
    Friend WithEvents lblArchivo As System.Windows.Forms.Label
    Friend WithEvents btnCorregir As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
End Class
