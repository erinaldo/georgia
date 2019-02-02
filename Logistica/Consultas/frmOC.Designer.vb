<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOC
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
        Me.btnbuscar = New System.Windows.Forms.Button
        Me.txtbusqueda = New System.Windows.Forms.TextBox
        Me.rbcliente = New System.Windows.Forms.RadioButton
        Me.rboc = New System.Windows.Forms.RadioButton
        Me.rbpedido = New System.Windows.Forms.RadioButton
        Me.dtpdesde = New System.Windows.Forms.DateTimePicker
        Me.dtphasta = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.rbInter = New System.Windows.Forms.RadioButton
        Me.SuspendLayout()
        '
        'btnbuscar
        '
        Me.btnbuscar.Location = New System.Drawing.Point(195, 129)
        Me.btnbuscar.Name = "btnbuscar"
        Me.btnbuscar.Size = New System.Drawing.Size(79, 20)
        Me.btnbuscar.TabIndex = 0
        Me.btnbuscar.Text = "Buscar"
        Me.btnbuscar.UseVisualStyleBackColor = True
        '
        'txtbusqueda
        '
        Me.txtbusqueda.Location = New System.Drawing.Point(43, 34)
        Me.txtbusqueda.Name = "txtbusqueda"
        Me.txtbusqueda.Size = New System.Drawing.Size(262, 20)
        Me.txtbusqueda.TabIndex = 1
        '
        'rbcliente
        '
        Me.rbcliente.AutoSize = True
        Me.rbcliente.Location = New System.Drawing.Point(44, 60)
        Me.rbcliente.Name = "rbcliente"
        Me.rbcliente.Size = New System.Drawing.Size(57, 17)
        Me.rbcliente.TabIndex = 2
        Me.rbcliente.TabStop = True
        Me.rbcliente.Text = "Cliente"
        Me.rbcliente.UseVisualStyleBackColor = True
        '
        'rboc
        '
        Me.rboc.AutoSize = True
        Me.rboc.Location = New System.Drawing.Point(43, 129)
        Me.rboc.Name = "rboc"
        Me.rboc.Size = New System.Drawing.Size(107, 17)
        Me.rboc.TabIndex = 3
        Me.rboc.TabStop = True
        Me.rboc.Text = "Orden de compra"
        Me.rboc.UseVisualStyleBackColor = True
        '
        'rbpedido
        '
        Me.rbpedido.AutoSize = True
        Me.rbpedido.Location = New System.Drawing.Point(44, 83)
        Me.rbpedido.Name = "rbpedido"
        Me.rbpedido.Size = New System.Drawing.Size(58, 17)
        Me.rbpedido.TabIndex = 4
        Me.rbpedido.TabStop = True
        Me.rbpedido.Text = "Pedido"
        Me.rbpedido.UseVisualStyleBackColor = True
        '
        'dtpdesde
        '
        Me.dtpdesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpdesde.Location = New System.Drawing.Point(219, 60)
        Me.dtpdesde.Name = "dtpdesde"
        Me.dtpdesde.Size = New System.Drawing.Size(86, 20)
        Me.dtpdesde.TabIndex = 5
        Me.dtpdesde.Visible = False
        '
        'dtphasta
        '
        Me.dtphasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtphasta.Location = New System.Drawing.Point(219, 83)
        Me.dtphasta.Name = "dtphasta"
        Me.dtphasta.Size = New System.Drawing.Size(86, 20)
        Me.dtphasta.TabIndex = 6
        Me.dtphasta.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(175, 66)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Desde"
        Me.Label1.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(175, 85)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Hasta"
        Me.Label2.Visible = False
        '
        'rbInter
        '
        Me.rbInter.AutoSize = True
        Me.rbInter.Location = New System.Drawing.Point(43, 106)
        Me.rbInter.Name = "rbInter"
        Me.rbInter.Size = New System.Drawing.Size(84, 17)
        Me.rbInter.TabIndex = 9
        Me.rbInter.TabStop = True
        Me.rbInter.Text = "Intervencion"
        Me.rbInter.UseVisualStyleBackColor = True
        '
        'frmOC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(328, 162)
        Me.Controls.Add(Me.rbInter)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtphasta)
        Me.Controls.Add(Me.dtpdesde)
        Me.Controls.Add(Me.rbpedido)
        Me.Controls.Add(Me.rboc)
        Me.Controls.Add(Me.rbcliente)
        Me.Controls.Add(Me.txtbusqueda)
        Me.Controls.Add(Me.btnbuscar)
        Me.Name = "frmOC"
        Me.Text = "Busqueda por Orden de Compra"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnbuscar As System.Windows.Forms.Button
    Friend WithEvents txtbusqueda As System.Windows.Forms.TextBox
    Friend WithEvents rbcliente As System.Windows.Forms.RadioButton
    Friend WithEvents rboc As System.Windows.Forms.RadioButton
    Friend WithEvents rbpedido As System.Windows.Forms.RadioButton
    Friend WithEvents dtpdesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtphasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents rbInter As System.Windows.Forms.RadioButton
End Class
