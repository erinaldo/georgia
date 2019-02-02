<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRemitos
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
        Me.btn_buscar_rto = New System.Windows.Forms.Button
        Me.rbnumero = New System.Windows.Forms.RadioButton
        Me.rbcliente = New System.Windows.Forms.RadioButton
        Me.txtrto = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'btn_buscar_rto
        '
        Me.btn_buscar_rto.Location = New System.Drawing.Point(256, 22)
        Me.btn_buscar_rto.Name = "btn_buscar_rto"
        Me.btn_buscar_rto.Size = New System.Drawing.Size(82, 27)
        Me.btn_buscar_rto.TabIndex = 0
        Me.btn_buscar_rto.Text = "Buscar"
        Me.btn_buscar_rto.UseVisualStyleBackColor = True
        '
        'rbnumero
        '
        Me.rbnumero.AutoSize = True
        Me.rbnumero.Location = New System.Drawing.Point(50, 53)
        Me.rbnumero.Name = "rbnumero"
        Me.rbnumero.Size = New System.Drawing.Size(62, 17)
        Me.rbnumero.TabIndex = 1
        Me.rbnumero.TabStop = True
        Me.rbnumero.Text = "Numero"
        Me.rbnumero.UseVisualStyleBackColor = True
        '
        'rbcliente
        '
        Me.rbcliente.AutoSize = True
        Me.rbcliente.Location = New System.Drawing.Point(146, 53)
        Me.rbcliente.Name = "rbcliente"
        Me.rbcliente.Size = New System.Drawing.Size(57, 17)
        Me.rbcliente.TabIndex = 2
        Me.rbcliente.TabStop = True
        Me.rbcliente.Text = "Cliente"
        Me.rbcliente.UseVisualStyleBackColor = True
        '
        'txtrto
        '
        Me.txtrto.Location = New System.Drawing.Point(34, 26)
        Me.txtrto.Name = "txtrto"
        Me.txtrto.Size = New System.Drawing.Size(202, 20)
        Me.txtrto.TabIndex = 3
        '
        'frmRemitos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(350, 82)
        Me.Controls.Add(Me.txtrto)
        Me.Controls.Add(Me.rbcliente)
        Me.Controls.Add(Me.rbnumero)
        Me.Controls.Add(Me.btn_buscar_rto)
        Me.Name = "frmRemitos"
        Me.Text = "Busqueda de Remitos"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_buscar_rto As System.Windows.Forms.Button
    Friend WithEvents rbnumero As System.Windows.Forms.RadioButton
    Friend WithEvents rbcliente As System.Windows.Forms.RadioButton
    Friend WithEvents txtrto As System.Windows.Forms.TextBox
End Class
