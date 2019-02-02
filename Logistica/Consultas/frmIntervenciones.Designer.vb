<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmIntervenciones
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
        Me.btn_buscar_itn = New System.Windows.Forms.Button
        Me.txtbox_itn = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.rbnumero = New System.Windows.Forms.RadioButton
        Me.rbcliente = New System.Windows.Forms.RadioButton
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.SuspendLayout()
        '
        'btn_buscar_itn
        '
        Me.btn_buscar_itn.Location = New System.Drawing.Point(288, 13)
        Me.btn_buscar_itn.Name = "btn_buscar_itn"
        Me.btn_buscar_itn.Size = New System.Drawing.Size(75, 23)
        Me.btn_buscar_itn.TabIndex = 3
        Me.btn_buscar_itn.Text = "Buscar"
        Me.btn_buscar_itn.UseVisualStyleBackColor = True
        '
        'txtbox_itn
        '
        Me.txtbox_itn.Location = New System.Drawing.Point(101, 15)
        Me.txtbox_itn.Name = "txtbox_itn"
        Me.txtbox_itn.Size = New System.Drawing.Size(169, 20)
        Me.txtbox_itn.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(51, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Numero"
        '
        'rbnumero
        '
        Me.rbnumero.AutoSize = True
        Me.rbnumero.Checked = True
        Me.rbnumero.Location = New System.Drawing.Point(101, 41)
        Me.rbnumero.Name = "rbnumero"
        Me.rbnumero.Size = New System.Drawing.Size(62, 17)
        Me.rbnumero.TabIndex = 1
        Me.rbnumero.TabStop = True
        Me.rbnumero.Text = "Numero" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.rbnumero.UseVisualStyleBackColor = True
        '
        'rbcliente
        '
        Me.rbcliente.AutoSize = True
        Me.rbcliente.Location = New System.Drawing.Point(197, 41)
        Me.rbcliente.Name = "rbcliente"
        Me.rbcliente.Size = New System.Drawing.Size(57, 17)
        Me.rbcliente.TabIndex = 2
        Me.rbcliente.Text = "Cliente"
        Me.rbcliente.UseVisualStyleBackColor = True
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.DisplayGroupTree = False
        Me.CrystalReportViewer1.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(12, 101)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.ShowCloseButton = False
        Me.CrystalReportViewer1.ShowExportButton = False
        Me.CrystalReportViewer1.ShowGroupTreeButton = False
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(383, 0)
        Me.CrystalReportViewer1.TabIndex = 0
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'frmIntervenciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(411, 70)
        Me.Controls.Add(Me.rbcliente)
        Me.Controls.Add(Me.rbnumero)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtbox_itn)
        Me.Controls.Add(Me.btn_buscar_itn)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Name = "frmIntervenciones"
        Me.Text = "Busqueda de intervenciones"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_buscar_itn As System.Windows.Forms.Button
    Friend WithEvents txtbox_itn As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents rbnumero As System.Windows.Forms.RadioButton
    Friend WithEvents rbcliente As System.Windows.Forms.RadioButton
    Private WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
