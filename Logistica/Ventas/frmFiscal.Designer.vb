<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFiscal
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
        Me.btnFcA = New System.Windows.Forms.Button
        Me.btnCierreZ = New System.Windows.Forms.Button
        Me.txtFCA = New System.Windows.Forms.TextBox
        Me.txtFCB = New System.Windows.Forms.TextBox
        Me.txtNCB = New System.Windows.Forms.TextBox
        Me.txtNCA = New System.Windows.Forms.TextBox
        Me.grpNumeradores = New System.Windows.Forms.GroupBox
        Me.grpImprimir = New System.Windows.Forms.GroupBox
        Me.btnNdB = New System.Windows.Forms.Button
        Me.btnNdA = New System.Windows.Forms.Button
        Me.btnNcB = New System.Windows.Forms.Button
        Me.btnNcA = New System.Windows.Forms.Button
        Me.btnFcB = New System.Windows.Forms.Button
        Me.txtPuerto = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Label1 = New System.Windows.Forms.Label
        Label2 = New System.Windows.Forms.Label
        Label3 = New System.Windows.Forms.Label
        Label4 = New System.Windows.Forms.Label
        Me.grpNumeradores.SuspendLayout()
        Me.grpImprimir.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(10, 23)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(48, 13)
        Label1.TabIndex = 0
        Label1.Text = "Fc/Nd A"
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Location = New System.Drawing.Point(10, 49)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(48, 13)
        Label2.TabIndex = 2
        Label2.Text = "Fc/Nd B"
        '
        'Label3
        '
        Label3.AutoSize = True
        Label3.Location = New System.Drawing.Point(165, 49)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(31, 13)
        Label3.TabIndex = 6
        Label3.Text = "Nc B"
        '
        'Label4
        '
        Label4.AutoSize = True
        Label4.Location = New System.Drawing.Point(165, 23)
        Label4.Name = "Label4"
        Label4.Size = New System.Drawing.Size(31, 13)
        Label4.TabIndex = 4
        Label4.Text = "Nc A"
        '
        'btnFcA
        '
        Me.btnFcA.Location = New System.Drawing.Point(12, 23)
        Me.btnFcA.Name = "btnFcA"
        Me.btnFcA.Size = New System.Drawing.Size(75, 23)
        Me.btnFcA.TabIndex = 0
        Me.btnFcA.Text = "Fact A"
        Me.btnFcA.UseVisualStyleBackColor = True
        '
        'btnCierreZ
        '
        Me.btnCierreZ.Location = New System.Drawing.Point(366, 23)
        Me.btnCierreZ.Name = "btnCierreZ"
        Me.btnCierreZ.Size = New System.Drawing.Size(75, 52)
        Me.btnCierreZ.TabIndex = 6
        Me.btnCierreZ.Text = "Cierre Z"
        Me.btnCierreZ.UseVisualStyleBackColor = True
        '
        'txtFCA
        '
        Me.txtFCA.Location = New System.Drawing.Point(78, 23)
        Me.txtFCA.Name = "txtFCA"
        Me.txtFCA.ReadOnly = True
        Me.txtFCA.Size = New System.Drawing.Size(81, 20)
        Me.txtFCA.TabIndex = 1
        Me.txtFCA.TabStop = False
        '
        'txtFCB
        '
        Me.txtFCB.Location = New System.Drawing.Point(78, 49)
        Me.txtFCB.Name = "txtFCB"
        Me.txtFCB.ReadOnly = True
        Me.txtFCB.Size = New System.Drawing.Size(81, 20)
        Me.txtFCB.TabIndex = 3
        Me.txtFCB.TabStop = False
        '
        'txtNCB
        '
        Me.txtNCB.Location = New System.Drawing.Point(203, 49)
        Me.txtNCB.Name = "txtNCB"
        Me.txtNCB.ReadOnly = True
        Me.txtNCB.Size = New System.Drawing.Size(83, 20)
        Me.txtNCB.TabIndex = 7
        Me.txtNCB.TabStop = False
        '
        'txtNCA
        '
        Me.txtNCA.Location = New System.Drawing.Point(203, 23)
        Me.txtNCA.Name = "txtNCA"
        Me.txtNCA.ReadOnly = True
        Me.txtNCA.Size = New System.Drawing.Size(83, 20)
        Me.txtNCA.TabIndex = 5
        Me.txtNCA.TabStop = False
        '
        'grpNumeradores
        '
        Me.grpNumeradores.Controls.Add(Me.txtFCA)
        Me.grpNumeradores.Controls.Add(Label3)
        Me.grpNumeradores.Controls.Add(Label1)
        Me.grpNumeradores.Controls.Add(Me.txtNCB)
        Me.grpNumeradores.Controls.Add(Me.txtFCB)
        Me.grpNumeradores.Controls.Add(Label4)
        Me.grpNumeradores.Controls.Add(Label2)
        Me.grpNumeradores.Controls.Add(Me.txtNCA)
        Me.grpNumeradores.Location = New System.Drawing.Point(12, 9)
        Me.grpNumeradores.Name = "grpNumeradores"
        Me.grpNumeradores.Size = New System.Drawing.Size(304, 82)
        Me.grpNumeradores.TabIndex = 0
        Me.grpNumeradores.TabStop = False
        Me.grpNumeradores.Text = "Numeradores"
        '
        'grpImprimir
        '
        Me.grpImprimir.Controls.Add(Me.btnNdB)
        Me.grpImprimir.Controls.Add(Me.btnNdA)
        Me.grpImprimir.Controls.Add(Me.btnNcB)
        Me.grpImprimir.Controls.Add(Me.btnNcA)
        Me.grpImprimir.Controls.Add(Me.btnFcB)
        Me.grpImprimir.Controls.Add(Me.btnFcA)
        Me.grpImprimir.Controls.Add(Me.btnCierreZ)
        Me.grpImprimir.Location = New System.Drawing.Point(12, 97)
        Me.grpImprimir.Name = "grpImprimir"
        Me.grpImprimir.Size = New System.Drawing.Size(448, 85)
        Me.grpImprimir.TabIndex = 2
        Me.grpImprimir.TabStop = False
        Me.grpImprimir.Text = "Imprimir"
        '
        'btnNdB
        '
        Me.btnNdB.Enabled = False
        Me.btnNdB.Location = New System.Drawing.Point(174, 52)
        Me.btnNdB.Name = "btnNdB"
        Me.btnNdB.Size = New System.Drawing.Size(75, 23)
        Me.btnNdB.TabIndex = 5
        Me.btnNdB.Text = "Nd B"
        Me.btnNdB.UseVisualStyleBackColor = True
        '
        'btnNdA
        '
        Me.btnNdA.Enabled = False
        Me.btnNdA.Location = New System.Drawing.Point(174, 23)
        Me.btnNdA.Name = "btnNdA"
        Me.btnNdA.Size = New System.Drawing.Size(75, 23)
        Me.btnNdA.TabIndex = 4
        Me.btnNdA.Text = "Nd A"
        Me.btnNdA.UseVisualStyleBackColor = True
        '
        'btnNcB
        '
        Me.btnNcB.Location = New System.Drawing.Point(93, 52)
        Me.btnNcB.Name = "btnNcB"
        Me.btnNcB.Size = New System.Drawing.Size(75, 23)
        Me.btnNcB.TabIndex = 3
        Me.btnNcB.Text = "Nc B"
        Me.btnNcB.UseVisualStyleBackColor = True
        '
        'btnNcA
        '
        Me.btnNcA.Location = New System.Drawing.Point(93, 23)
        Me.btnNcA.Name = "btnNcA"
        Me.btnNcA.Size = New System.Drawing.Size(75, 23)
        Me.btnNcA.TabIndex = 2
        Me.btnNcA.Text = "Nc A"
        Me.btnNcA.UseVisualStyleBackColor = True
        '
        'btnFcB
        '
        Me.btnFcB.Location = New System.Drawing.Point(12, 52)
        Me.btnFcB.Name = "btnFcB"
        Me.btnFcB.Size = New System.Drawing.Size(75, 23)
        Me.btnFcB.TabIndex = 1
        Me.btnFcB.Text = "Fact B"
        Me.btnFcB.UseVisualStyleBackColor = True
        '
        'txtPuerto
        '
        Me.txtPuerto.Location = New System.Drawing.Point(5, 39)
        Me.txtPuerto.MaxLength = 1
        Me.txtPuerto.Name = "txtPuerto"
        Me.txtPuerto.Size = New System.Drawing.Size(126, 20)
        Me.txtPuerto.TabIndex = 0
        Me.txtPuerto.Text = "1"
        Me.txtPuerto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtPuerto)
        Me.GroupBox1.Location = New System.Drawing.Point(322, 9)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(138, 82)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Puerto COM"
        '
        'frmFiscal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(467, 187)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grpImprimir)
        Me.Controls.Add(Me.grpNumeradores)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "frmFiscal"
        Me.Text = "Controlador Fiscal"
        Me.grpNumeradores.ResumeLayout(False)
        Me.grpNumeradores.PerformLayout()
        Me.grpImprimir.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnFcA As System.Windows.Forms.Button
    Friend WithEvents btnCierreZ As System.Windows.Forms.Button
    Friend WithEvents txtFCA As System.Windows.Forms.TextBox
    Friend WithEvents txtFCB As System.Windows.Forms.TextBox
    Friend WithEvents txtNCB As System.Windows.Forms.TextBox
    Friend WithEvents txtNCA As System.Windows.Forms.TextBox
    Friend WithEvents grpNumeradores As System.Windows.Forms.GroupBox
    Friend WithEvents grpImprimir As System.Windows.Forms.GroupBox
    Friend WithEvents btnNdB As System.Windows.Forms.Button
    Friend WithEvents btnNdA As System.Windows.Forms.Button
    Friend WithEvents btnNcB As System.Windows.Forms.Button
    Friend WithEvents btnNcA As System.Windows.Forms.Button
    Friend WithEvents btnFcB As System.Windows.Forms.Button
    Friend WithEvents txtPuerto As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
End Class
