<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTransferencia
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
        Dim Label2 As System.Windows.Forms.Label
        Me.btnTransferir = New System.Windows.Forms.Button
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.txtCliente1 = New System.Windows.Forms.TextBox
        Me.txtSuc1 = New System.Windows.Forms.TextBox
        Me.txtSuc2 = New System.Windows.Forms.TextBox
        Me.txtCliente2 = New System.Windows.Forms.TextBox
        Me.txtClienteDe = New System.Windows.Forms.TextBox
        Me.txtSucDe = New System.Windows.Forms.TextBox
        Me.txtSucHacia = New System.Windows.Forms.TextBox
        Me.txtClienteHacia = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Label1 = New System.Windows.Forms.Label
        Label2 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(12, 14)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(24, 13)
        Label1.TabIndex = 0
        Label1.Text = "De:"
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Location = New System.Drawing.Point(12, 66)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(38, 13)
        Label2.TabIndex = 5
        Label2.Text = "Hacia:"
        '
        'btnTransferir
        '
        Me.btnTransferir.Location = New System.Drawing.Point(307, 134)
        Me.btnTransferir.Name = "btnTransferir"
        Me.btnTransferir.Size = New System.Drawing.Size(75, 23)
        Me.btnTransferir.TabIndex = 10
        Me.btnTransferir.Text = "Transferir"
        Me.btnTransferir.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Location = New System.Drawing.Point(388, 134)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 11
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'txtCliente1
        '
        Me.txtCliente1.Location = New System.Drawing.Point(12, 30)
        Me.txtCliente1.MaxLength = 6
        Me.txtCliente1.Name = "txtCliente1"
        Me.txtCliente1.Size = New System.Drawing.Size(52, 20)
        Me.txtCliente1.TabIndex = 1
        '
        'txtSuc1
        '
        Me.txtSuc1.Location = New System.Drawing.Point(70, 30)
        Me.txtSuc1.MaxLength = 3
        Me.txtSuc1.Name = "txtSuc1"
        Me.txtSuc1.Size = New System.Drawing.Size(28, 20)
        Me.txtSuc1.TabIndex = 2
        '
        'txtSuc2
        '
        Me.txtSuc2.Location = New System.Drawing.Point(70, 82)
        Me.txtSuc2.MaxLength = 3
        Me.txtSuc2.Name = "txtSuc2"
        Me.txtSuc2.Size = New System.Drawing.Size(28, 20)
        Me.txtSuc2.TabIndex = 7
        '
        'txtCliente2
        '
        Me.txtCliente2.Location = New System.Drawing.Point(12, 82)
        Me.txtCliente2.MaxLength = 6
        Me.txtCliente2.Name = "txtCliente2"
        Me.txtCliente2.Size = New System.Drawing.Size(52, 20)
        Me.txtCliente2.TabIndex = 6
        '
        'txtClienteDe
        '
        Me.txtClienteDe.Location = New System.Drawing.Point(104, 30)
        Me.txtClienteDe.Name = "txtClienteDe"
        Me.txtClienteDe.ReadOnly = True
        Me.txtClienteDe.Size = New System.Drawing.Size(359, 20)
        Me.txtClienteDe.TabIndex = 3
        Me.txtClienteDe.TabStop = False
        '
        'txtSucDe
        '
        Me.txtSucDe.Location = New System.Drawing.Point(104, 56)
        Me.txtSucDe.Name = "txtSucDe"
        Me.txtSucDe.ReadOnly = True
        Me.txtSucDe.Size = New System.Drawing.Size(359, 20)
        Me.txtSucDe.TabIndex = 4
        Me.txtSucDe.TabStop = False
        '
        'txtSucHacia
        '
        Me.txtSucHacia.Location = New System.Drawing.Point(104, 108)
        Me.txtSucHacia.Name = "txtSucHacia"
        Me.txtSucHacia.ReadOnly = True
        Me.txtSucHacia.Size = New System.Drawing.Size(359, 20)
        Me.txtSucHacia.TabIndex = 9
        Me.txtSucHacia.TabStop = False
        '
        'txtClienteHacia
        '
        Me.txtClienteHacia.Location = New System.Drawing.Point(104, 82)
        Me.txtClienteHacia.Name = "txtClienteHacia"
        Me.txtClienteHacia.ReadOnly = True
        Me.txtClienteHacia.Size = New System.Drawing.Size(359, 20)
        Me.txtClienteHacia.TabIndex = 8
        Me.txtClienteHacia.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 139)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(224, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Transferencia en proceso. Por favor, espere..."
        Me.Label3.Visible = False
        '
        'frmTransferencia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(478, 166)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Label2)
        Me.Controls.Add(Label1)
        Me.Controls.Add(Me.txtSucHacia)
        Me.Controls.Add(Me.txtClienteHacia)
        Me.Controls.Add(Me.txtSucDe)
        Me.Controls.Add(Me.txtClienteDe)
        Me.Controls.Add(Me.txtSuc2)
        Me.Controls.Add(Me.txtCliente2)
        Me.Controls.Add(Me.txtSuc1)
        Me.Controls.Add(Me.txtCliente1)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnTransferir)
        Me.Name = "frmTransferencia"
        Me.Text = "Transferencia de Parque"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnTransferir As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents txtCliente1 As System.Windows.Forms.TextBox
    Friend WithEvents txtSuc1 As System.Windows.Forms.TextBox
    Friend WithEvents txtSuc2 As System.Windows.Forms.TextBox
    Friend WithEvents txtCliente2 As System.Windows.Forms.TextBox
    Friend WithEvents txtClienteDe As System.Windows.Forms.TextBox
    Friend WithEvents txtSucDe As System.Windows.Forms.TextBox
    Friend WithEvents txtSucHacia As System.Windows.Forms.TextBox
    Friend WithEvents txtClienteHacia As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
