<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRptVtasfliaA
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
        Dim Label3 As System.Windows.Forms.Label
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.Label1 = New System.Windows.Forms.Label
        Me.nudAno = New System.Windows.Forms.NumericUpDown
        Me.chkCosto = New System.Windows.Forms.CheckBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rbRpt2 = New System.Windows.Forms.RadioButton
        Me.rbRpt1 = New System.Windows.Forms.RadioButton
        Me.btnGenerar = New System.Windows.Forms.Button
        Me.lstVendedores = New System.Windows.Forms.CheckedListBox
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.crv = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Label3 = New System.Windows.Forms.Label
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.nudAno, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label3
        '
        Label3.AutoSize = True
        Label3.Location = New System.Drawing.Point(23, 21)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(29, 13)
        Label3.TabIndex = 18
        Label3.Text = "Año:"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1.Controls.Add(Label3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.nudAno)
        Me.SplitContainer1.Panel1.Controls.Add(Me.chkCosto)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnGenerar)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lstVendedores)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ProgressBar1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.crv)
        Me.SplitContainer1.Size = New System.Drawing.Size(925, 466)
        Me.SplitContainer1.SplitterDistance = 217
        Me.SplitContainer1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(26, 71)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(168, 33)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Label1"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.Label1.Visible = False
        '
        'nudAno
        '
        Me.nudAno.Location = New System.Drawing.Point(58, 19)
        Me.nudAno.Maximum = New Decimal(New Integer() {2007, 0, 0, 0})
        Me.nudAno.Minimum = New Decimal(New Integer() {2007, 0, 0, 0})
        Me.nudAno.Name = "nudAno"
        Me.nudAno.Size = New System.Drawing.Size(64, 20)
        Me.nudAno.TabIndex = 17
        Me.nudAno.Value = New Decimal(New Integer() {2007, 0, 0, 0})
        '
        'chkCosto
        '
        Me.chkCosto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkCosto.AutoSize = True
        Me.chkCosto.Checked = True
        Me.chkCosto.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkCosto.Location = New System.Drawing.Point(60, 107)
        Me.chkCosto.Name = "chkCosto"
        Me.chkCosto.Size = New System.Drawing.Size(91, 17)
        Me.chkCosto.TabIndex = 16
        Me.chkCosto.Text = "Mostrar Costo"
        Me.chkCosto.UseVisualStyleBackColor = True
        Me.chkCosto.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.rbRpt2)
        Me.GroupBox1.Controls.Add(Me.rbRpt1)
        Me.GroupBox1.Location = New System.Drawing.Point(26, 363)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(135, 69)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tipo de Reporte"
        Me.GroupBox1.Visible = False
        '
        'rbRpt2
        '
        Me.rbRpt2.AutoSize = True
        Me.rbRpt2.Location = New System.Drawing.Point(6, 42)
        Me.rbRpt2.Name = "rbRpt2"
        Me.rbRpt2.Size = New System.Drawing.Size(147, 17)
        Me.rbRpt2.TabIndex = 1
        Me.rbRpt2.Text = "Seguimiento de Extintores"
        Me.rbRpt2.UseVisualStyleBackColor = True
        '
        'rbRpt1
        '
        Me.rbRpt1.AutoSize = True
        Me.rbRpt1.Checked = True
        Me.rbRpt1.Location = New System.Drawing.Point(6, 19)
        Me.rbRpt1.Name = "rbRpt1"
        Me.rbRpt1.Size = New System.Drawing.Size(119, 17)
        Me.rbRpt1.TabIndex = 0
        Me.rbRpt1.TabStop = True
        Me.rbRpt1.Text = "Reportes de Ventas"
        Me.rbRpt1.UseVisualStyleBackColor = True
        '
        'btnGenerar
        '
        Me.btnGenerar.Enabled = False
        Me.btnGenerar.Location = New System.Drawing.Point(128, 16)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(75, 23)
        Me.btnGenerar.TabIndex = 13
        Me.btnGenerar.Text = "Generar"
        Me.btnGenerar.UseVisualStyleBackColor = True
        '
        'lstVendedores
        '
        Me.lstVendedores.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstVendedores.CheckOnClick = True
        Me.lstVendedores.FormattingEnabled = True
        Me.lstVendedores.Location = New System.Drawing.Point(29, 143)
        Me.lstVendedores.Name = "lstVendedores"
        Me.lstVendedores.Size = New System.Drawing.Size(139, 214)
        Me.lstVendedores.TabIndex = 12
        Me.lstVendedores.Visible = False
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(35, 45)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(174, 23)
        Me.ProgressBar1.TabIndex = 14
        '
        'crv
        '
        Me.crv.ActiveViewIndex = -1
        Me.crv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crv.DisplayGroupTree = False
        Me.crv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crv.Location = New System.Drawing.Point(0, 0)
        Me.crv.Name = "crv"
        Me.crv.SelectionFormula = ""
        Me.crv.ShowCloseButton = False
        Me.crv.ShowGroupTreeButton = False
        Me.crv.ShowRefreshButton = False
        Me.crv.Size = New System.Drawing.Size(704, 466)
        Me.crv.TabIndex = 7
        Me.crv.ViewTimeSelectionFormula = ""
        '
        'frmRptVtasfliaA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(925, 466)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "frmRptVtasfliaA"
        Me.Text = "frmRptVtasFliaA"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.nudAno, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents crv As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents chkCosto As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbRpt2 As System.Windows.Forms.RadioButton
    Friend WithEvents rbRpt1 As System.Windows.Forms.RadioButton
    Friend WithEvents btnGenerar As System.Windows.Forms.Button
    Friend WithEvents lstVendedores As System.Windows.Forms.CheckedListBox
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents nudAno As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
