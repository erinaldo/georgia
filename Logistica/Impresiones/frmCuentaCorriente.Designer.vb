<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCuentaCorriente
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
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.txtbox_ctacte = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btn_acuse = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtbox_ctacte2 = New System.Windows.Forms.TextBox
        Me.cbox_sociedad = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.chkfac = New System.Windows.Forms.CheckBox
        Me.SuspendLayout()
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.DisplayGroupTree = False
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(12, 64)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.ShowCloseButton = False
        Me.CrystalReportViewer1.ShowExportButton = False
        Me.CrystalReportViewer1.ShowZoomButton = False
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(874, 412)
        Me.CrystalReportViewer1.TabIndex = 9
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'txtbox_ctacte
        '
        Me.txtbox_ctacte.Location = New System.Drawing.Point(338, 11)
        Me.txtbox_ctacte.Name = "txtbox_ctacte"
        Me.txtbox_ctacte.Size = New System.Drawing.Size(100, 20)
        Me.txtbox_ctacte.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(288, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Numero"
        '
        'btn_acuse
        '
        Me.btn_acuse.Location = New System.Drawing.Point(458, 35)
        Me.btn_acuse.Name = "btn_acuse"
        Me.btn_acuse.Size = New System.Drawing.Size(75, 23)
        Me.btn_acuse.TabIndex = 6
        Me.btn_acuse.Text = "Buscar"
        Me.btn_acuse.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(288, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Sociedad"
        '
        'txtbox_ctacte2
        '
        Me.txtbox_ctacte2.Location = New System.Drawing.Point(458, 11)
        Me.txtbox_ctacte2.Name = "txtbox_ctacte2"
        Me.txtbox_ctacte2.Size = New System.Drawing.Size(100, 20)
        Me.txtbox_ctacte2.TabIndex = 12
        '
        'cbox_sociedad
        '
        Me.cbox_sociedad.FormattingEnabled = True
        Me.cbox_sociedad.Location = New System.Drawing.Point(338, 37)
        Me.cbox_sociedad.Name = "cbox_sociedad"
        Me.cbox_sociedad.Size = New System.Drawing.Size(100, 21)
        Me.cbox_sociedad.TabIndex = 13
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(444, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(13, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "a"
        '
        'chkfac
        '
        Me.chkfac.AutoSize = True
        Me.chkfac.Location = New System.Drawing.Point(550, 40)
        Me.chkfac.Name = "chkfac"
        Me.chkfac.Size = New System.Drawing.Size(112, 17)
        Me.chkfac.TabIndex = 17
        Me.chkfac.Text = "Facturas saldadas"
        Me.chkfac.UseVisualStyleBackColor = True
        '
        'frmCuentaCorriente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(898, 488)
        Me.Controls.Add(Me.chkfac)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cbox_sociedad)
        Me.Controls.Add(Me.txtbox_ctacte2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Controls.Add(Me.txtbox_ctacte)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn_acuse)
        Me.Name = "frmCuentaCorriente"
        Me.Text = "Consulta Cuenta Corriente"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents txtbox_ctacte As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_acuse As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtbox_ctacte2 As System.Windows.Forms.TextBox
    Friend WithEvents cbox_sociedad As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chkfac As System.Windows.Forms.CheckBox
End Class
