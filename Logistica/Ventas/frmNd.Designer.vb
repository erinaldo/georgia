<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNd
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
        Me.txtNd = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtFc = New System.Windows.Forms.TextBox
        Me.btnAsociar = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'txtNd
        '
        Me.txtNd.Location = New System.Drawing.Point(12, 27)
        Me.txtNd.Name = "txtNd"
        Me.txtNd.Size = New System.Drawing.Size(153, 20)
        Me.txtNd.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Nota de Débito"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(172, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Factura"
        '
        'txtFc
        '
        Me.txtFc.Location = New System.Drawing.Point(171, 27)
        Me.txtFc.Name = "txtFc"
        Me.txtFc.Size = New System.Drawing.Size(153, 20)
        Me.txtFc.TabIndex = 2
        '
        'btnAsociar
        '
        Me.btnAsociar.Enabled = False
        Me.btnAsociar.Location = New System.Drawing.Point(340, 27)
        Me.btnAsociar.Name = "btnAsociar"
        Me.btnAsociar.Size = New System.Drawing.Size(75, 23)
        Me.btnAsociar.TabIndex = 4
        Me.btnAsociar.Text = "Asociar"
        Me.btnAsociar.UseVisualStyleBackColor = True
        '
        'frmNd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(509, 73)
        Me.Controls.Add(Me.btnAsociar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtFc)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtNd)
        Me.Name = "frmNd"
        Me.Text = "Asociar ND"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtNd As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtFc As System.Windows.Forms.TextBox
    Friend WithEvents btnAsociar As System.Windows.Forms.Button
End Class
