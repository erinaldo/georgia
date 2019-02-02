<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCertificadoMantenimiento
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
        Dim Label3 As System.Windows.Forms.Label
        Dim Label4 As System.Windows.Forms.Label
        Dim Label5 As System.Windows.Forms.Label
        Dim Label6 As System.Windows.Forms.Label
        Me.btnOperativo = New System.Windows.Forms.Button
        Me.btnInoperativo = New System.Windows.Forms.Button
        Me.btnDefectuoso = New System.Windows.Forms.Button
        Me.txtBpc = New System.Windows.Forms.TextBox
        Me.txtCliente = New System.Windows.Forms.TextBox
        Me.txtDomicilio = New System.Windows.Forms.TextBox
        Me.txtBpa = New System.Windows.Forms.TextBox
        Me.txtItn = New System.Windows.Forms.TextBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Label1 = New System.Windows.Forms.Label
        Label3 = New System.Windows.Forms.Label
        Label4 = New System.Windows.Forms.Label
        Label5 = New System.Windows.Forms.Label
        Label6 = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(12, 108)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(256, 13)
        Label1.TabIndex = 4
        Label1.Text = "Seleccione el estado en que se encuentra el sistema"
        '
        'Label3
        '
        Label3.AutoSize = True
        Label3.Location = New System.Drawing.Point(12, 8)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(42, 13)
        Label3.TabIndex = 9
        Label3.Text = "Cliente:"
        '
        'Label4
        '
        Label4.AutoSize = True
        Label4.Location = New System.Drawing.Point(12, 51)
        Label4.Name = "Label4"
        Label4.Size = New System.Drawing.Size(51, 13)
        Label4.TabIndex = 12
        Label4.Text = "Sucursal:"
        '
        'Label5
        '
        Label5.AutoSize = True
        Label5.Location = New System.Drawing.Point(332, 8)
        Label5.Name = "Label5"
        Label5.Size = New System.Drawing.Size(62, 13)
        Label5.TabIndex = 13
        Label5.Text = "Documento"
        '
        'Label6
        '
        Label6.Dock = System.Windows.Forms.DockStyle.Fill
        Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label6.Location = New System.Drawing.Point(0, 0)
        Label6.Name = "Label6"
        Label6.Size = New System.Drawing.Size(561, 195)
        Label6.TabIndex = 15
        Label6.Text = "Enviando mail al vendedor..." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Por favor espere"
        Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnOperativo
        '
        Me.btnOperativo.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnOperativo.Location = New System.Drawing.Point(12, 124)
        Me.btnOperativo.Name = "btnOperativo"
        Me.btnOperativo.Size = New System.Drawing.Size(178, 60)
        Me.btnOperativo.TabIndex = 0
        Me.btnOperativo.Text = "OPERATIVO"
        Me.btnOperativo.UseVisualStyleBackColor = False
        '
        'btnInoperativo
        '
        Me.btnInoperativo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnInoperativo.Location = New System.Drawing.Point(380, 124)
        Me.btnInoperativo.Name = "btnInoperativo"
        Me.btnInoperativo.Size = New System.Drawing.Size(168, 60)
        Me.btnInoperativo.TabIndex = 1
        Me.btnInoperativo.Text = "INOPERATIVO"
        Me.btnInoperativo.UseVisualStyleBackColor = False
        '
        'btnDefectuoso
        '
        Me.btnDefectuoso.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnDefectuoso.Location = New System.Drawing.Point(196, 124)
        Me.btnDefectuoso.Name = "btnDefectuoso"
        Me.btnDefectuoso.Size = New System.Drawing.Size(178, 60)
        Me.btnDefectuoso.TabIndex = 2
        Me.btnDefectuoso.Text = "DEFECTUOSO"
        Me.btnDefectuoso.UseVisualStyleBackColor = False
        '
        'txtBpc
        '
        Me.txtBpc.Location = New System.Drawing.Point(15, 24)
        Me.txtBpc.Name = "txtBpc"
        Me.txtBpc.ReadOnly = True
        Me.txtBpc.Size = New System.Drawing.Size(52, 20)
        Me.txtBpc.TabIndex = 6
        '
        'txtCliente
        '
        Me.txtCliente.Location = New System.Drawing.Point(73, 24)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(230, 20)
        Me.txtCliente.TabIndex = 7
        '
        'txtDomicilio
        '
        Me.txtDomicilio.Location = New System.Drawing.Point(73, 67)
        Me.txtDomicilio.Name = "txtDomicilio"
        Me.txtDomicilio.ReadOnly = True
        Me.txtDomicilio.Size = New System.Drawing.Size(230, 20)
        Me.txtDomicilio.TabIndex = 11
        '
        'txtBpa
        '
        Me.txtBpa.Location = New System.Drawing.Point(15, 67)
        Me.txtBpa.Name = "txtBpa"
        Me.txtBpa.ReadOnly = True
        Me.txtBpa.Size = New System.Drawing.Size(52, 20)
        Me.txtBpa.TabIndex = 10
        '
        'txtItn
        '
        Me.txtItn.Location = New System.Drawing.Point(335, 24)
        Me.txtItn.Name = "txtItn"
        Me.txtItn.ReadOnly = True
        Me.txtItn.Size = New System.Drawing.Size(150, 20)
        Me.txtItn.TabIndex = 14
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txtBpc)
        Me.Panel1.Controls.Add(Me.txtItn)
        Me.Panel1.Controls.Add(Me.btnOperativo)
        Me.Panel1.Controls.Add(Label5)
        Me.Panel1.Controls.Add(Me.btnInoperativo)
        Me.Panel1.Controls.Add(Label4)
        Me.Panel1.Controls.Add(Me.btnDefectuoso)
        Me.Panel1.Controls.Add(Me.txtDomicilio)
        Me.Panel1.Controls.Add(Me.txtBpa)
        Me.Panel1.Controls.Add(Label1)
        Me.Panel1.Controls.Add(Label3)
        Me.Panel1.Controls.Add(Me.txtCliente)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(561, 195)
        Me.Panel1.TabIndex = 15
        '
        'frmCertificadoMantenimiento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(561, 195)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Label6)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmCertificadoMantenimiento"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Resultado del mantenimiento"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnOperativo As System.Windows.Forms.Button
    Friend WithEvents btnInoperativo As System.Windows.Forms.Button
    Friend WithEvents btnDefectuoso As System.Windows.Forms.Button
    Friend WithEvents txtBpc As System.Windows.Forms.TextBox
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtDomicilio As System.Windows.Forms.TextBox
    Friend WithEvents txtBpa As System.Windows.Forms.TextBox
    Friend WithEvents txtItn As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
