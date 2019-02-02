<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelectorClientes
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
        Dim GroupBox1 As System.Windows.Forms.GroupBox
        Dim GroupBox2 As System.Windows.Forms.GroupBox
        Me.btnBuscar = New System.Windows.Forms.Button
        Me.txtBuscar = New System.Windows.Forms.TextBox
        Me.lst = New System.Windows.Forms.ListBox
        Me.btnSeleccionar = New System.Windows.Forms.Button
        Me.btnCerrar = New System.Windows.Forms.Button
        GroupBox1 = New System.Windows.Forms.GroupBox
        GroupBox2 = New System.Windows.Forms.GroupBox
        GroupBox1.SuspendLayout()
        GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnBuscar
        '
        Me.btnBuscar.Location = New System.Drawing.Point(593, 20)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(75, 23)
        Me.btnBuscar.TabIndex = 1
        Me.btnBuscar.TabStop = False
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'txtBuscar
        '
        Me.txtBuscar.Location = New System.Drawing.Point(6, 22)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(564, 20)
        Me.txtBuscar.TabIndex = 0
        '
        'GroupBox1
        '
        GroupBox1.Controls.Add(Me.txtBuscar)
        GroupBox1.Controls.Add(Me.btnBuscar)
        GroupBox1.Location = New System.Drawing.Point(12, 12)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New System.Drawing.Size(674, 59)
        GroupBox1.TabIndex = 0
        GroupBox1.TabStop = False
        GroupBox1.Text = "Buscar"
        '
        'GroupBox2
        '
        GroupBox2.Controls.Add(Me.lst)
        GroupBox2.Location = New System.Drawing.Point(12, 77)
        GroupBox2.Name = "GroupBox2"
        GroupBox2.Size = New System.Drawing.Size(674, 298)
        GroupBox2.TabIndex = 1
        GroupBox2.TabStop = False
        GroupBox2.Text = "Resultados"
        '
        'lst
        '
        Me.lst.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lst.FormattingEnabled = True
        Me.lst.Location = New System.Drawing.Point(3, 16)
        Me.lst.Name = "lst"
        Me.lst.Size = New System.Drawing.Size(668, 277)
        Me.lst.TabIndex = 0
        '
        'btnSeleccionar
        '
        Me.btnSeleccionar.Location = New System.Drawing.Point(527, 389)
        Me.btnSeleccionar.Name = "btnSeleccionar"
        Me.btnSeleccionar.Size = New System.Drawing.Size(75, 23)
        Me.btnSeleccionar.TabIndex = 2
        Me.btnSeleccionar.TabStop = False
        Me.btnSeleccionar.Text = "Seleccionar"
        Me.btnSeleccionar.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.Location = New System.Drawing.Point(608, 389)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(75, 23)
        Me.btnCerrar.TabIndex = 3
        Me.btnCerrar.TabStop = False
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'frmSelectorClientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(698, 424)
        Me.Controls.Add(Me.btnSeleccionar)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(GroupBox2)
        Me.Controls.Add(GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSelectorClientes"
        Me.Text = "Selector de clientes"
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents btnSeleccionar As System.Windows.Forms.Button
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents lst As System.Windows.Forms.ListBox
End Class
