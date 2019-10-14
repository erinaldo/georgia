<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStock
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
        Dim Label3 As System.Windows.Forms.Label
        Dim Label4 As System.Windows.Forms.Label
        Dim Label5 As System.Windows.Forms.Label
        Me.btnConsultar = New System.Windows.Forms.Button
        Me.txtCodigo = New System.Windows.Forms.TextBox
        Me.txtPaternalStock = New System.Windows.Forms.TextBox
        Me.txtMunroStock = New System.Windows.Forms.TextBox
        Me.txtMunroPedidos = New System.Windows.Forms.TextBox
        Me.txtPaternalPedidos = New System.Windows.Forms.TextBox
        Label1 = New System.Windows.Forms.Label
        Label2 = New System.Windows.Forms.Label
        Label3 = New System.Windows.Forms.Label
        Label4 = New System.Windows.Forms.Label
        Label5 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(12, 9)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(44, 13)
        Label1.TabIndex = 0
        Label1.Text = "Artículo"
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Location = New System.Drawing.Point(12, 56)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(77, 13)
        Label2.TabIndex = 3
        Label2.Text = "Stock Paternal"
        '
        'Label3
        '
        Label3.AutoSize = True
        Label3.Location = New System.Drawing.Point(167, 56)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(71, 13)
        Label3.TabIndex = 7
        Label3.Text = "Stock Munro:"
        '
        'btnConsultar
        '
        Me.btnConsultar.Location = New System.Drawing.Point(177, 6)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(75, 23)
        Me.btnConsultar.TabIndex = 2
        Me.btnConsultar.Text = "Consultar"
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'txtCodigo
        '
        Me.txtCodigo.Location = New System.Drawing.Point(62, 6)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(100, 20)
        Me.txtCodigo.TabIndex = 1
        '
        'txtPaternalStock
        '
        Me.txtPaternalStock.Location = New System.Drawing.Point(108, 53)
        Me.txtPaternalStock.Name = "txtPaternalStock"
        Me.txtPaternalStock.ReadOnly = True
        Me.txtPaternalStock.Size = New System.Drawing.Size(54, 20)
        Me.txtPaternalStock.TabIndex = 4
        Me.txtPaternalStock.TabStop = False
        Me.txtPaternalStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMunroStock
        '
        Me.txtMunroStock.Location = New System.Drawing.Point(263, 53)
        Me.txtMunroStock.Name = "txtMunroStock"
        Me.txtMunroStock.ReadOnly = True
        Me.txtMunroStock.Size = New System.Drawing.Size(54, 20)
        Me.txtMunroStock.TabIndex = 8
        Me.txtMunroStock.TabStop = False
        Me.txtMunroStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMunroPedidos
        '
        Me.txtMunroPedidos.Location = New System.Drawing.Point(263, 84)
        Me.txtMunroPedidos.Name = "txtMunroPedidos"
        Me.txtMunroPedidos.ReadOnly = True
        Me.txtMunroPedidos.Size = New System.Drawing.Size(54, 20)
        Me.txtMunroPedidos.TabIndex = 10
        Me.txtMunroPedidos.TabStop = False
        Me.txtMunroPedidos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPaternalPedidos
        '
        Me.txtPaternalPedidos.Location = New System.Drawing.Point(108, 84)
        Me.txtPaternalPedidos.Name = "txtPaternalPedidos"
        Me.txtPaternalPedidos.ReadOnly = True
        Me.txtPaternalPedidos.Size = New System.Drawing.Size(54, 20)
        Me.txtPaternalPedidos.TabIndex = 6
        Me.txtPaternalPedidos.TabStop = False
        Me.txtPaternalPedidos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Label4.AutoSize = True
        Label4.Location = New System.Drawing.Point(167, 87)
        Label4.Name = "Label4"
        Label4.Size = New System.Drawing.Size(81, 13)
        Label4.TabIndex = 9
        Label4.Text = "Pedidos Munro:"
        '
        'Label5
        '
        Label5.AutoSize = True
        Label5.Location = New System.Drawing.Point(12, 87)
        Label5.Name = "Label5"
        Label5.Size = New System.Drawing.Size(87, 13)
        Label5.TabIndex = 5
        Label5.Text = "Pedidos Paternal"
        '
        'frmStock
        '
        Me.AcceptButton = Me.btnConsultar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(329, 120)
        Me.Controls.Add(Me.txtMunroPedidos)
        Me.Controls.Add(Me.txtPaternalPedidos)
        Me.Controls.Add(Label4)
        Me.Controls.Add(Label5)
        Me.Controls.Add(Me.txtMunroStock)
        Me.Controls.Add(Me.txtPaternalStock)
        Me.Controls.Add(Label3)
        Me.Controls.Add(Label2)
        Me.Controls.Add(Label1)
        Me.Controls.Add(Me.txtCodigo)
        Me.Controls.Add(Me.btnConsultar)
        Me.Name = "frmStock"
        Me.Text = "Consulta de stock"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnConsultar As System.Windows.Forms.Button
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents txtPaternalStock As System.Windows.Forms.TextBox
    Friend WithEvents txtMunroStock As System.Windows.Forms.TextBox
    Friend WithEvents txtMunroPedidos As System.Windows.Forms.TextBox
    Friend WithEvents txtPaternalPedidos As System.Windows.Forms.TextBox
End Class
