<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRptVtasA
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
        Me.components = New System.ComponentModel.Container
        Dim Label2 As System.Windows.Forms.Label
        Dim Label3 As System.Windows.Forms.Label
        Me.btnGenerar = New System.Windows.Forms.Button
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.Label1 = New System.Windows.Forms.Label
        Me.lstVendedores = New System.Windows.Forms.CheckedListBox
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuMarcarTodos = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuDesmarcarTodos = New System.Windows.Forms.ToolStripMenuItem
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.chkCosto = New System.Windows.Forms.CheckBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rbRpt2 = New System.Windows.Forms.RadioButton
        Me.rbRpt1 = New System.Windows.Forms.RadioButton
        Me.nudAno = New System.Windows.Forms.NumericUpDown
        Me.crv = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.chkPresupuesto = New System.Windows.Forms.CheckBox
        Me.chkIVA = New System.Windows.Forms.CheckBox
        Label2 = New System.Windows.Forms.Label
        Label3 = New System.Windows.Forms.Label
        Me.ContextMenuStrip2.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.nudAno, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Location = New System.Drawing.Point(12, 38)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(67, 13)
        Label2.TabIndex = 1
        Label2.Text = "Vendedores:"
        '
        'Label3
        '
        Label3.AutoSize = True
        Label3.Location = New System.Drawing.Point(9, 9)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(29, 13)
        Label3.TabIndex = 9
        Label3.Text = "Año:"
        '
        'btnGenerar
        '
        Me.btnGenerar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGenerar.Enabled = False
        Me.btnGenerar.Location = New System.Drawing.Point(97, 443)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(75, 23)
        Me.btnGenerar.TabIndex = 3
        Me.btnGenerar.Text = "Generar"
        Me.btnGenerar.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProgressBar1.Location = New System.Drawing.Point(9, 443)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(82, 23)
        Me.ProgressBar1.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.Location = New System.Drawing.Point(9, 407)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(163, 33)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Label1"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.Label1.Visible = False
        '
        'lstVendedores
        '
        Me.lstVendedores.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstVendedores.CheckOnClick = True
        Me.lstVendedores.ContextMenuStrip = Me.ContextMenuStrip2
        Me.lstVendedores.FormattingEnabled = True
        Me.lstVendedores.Location = New System.Drawing.Point(0, 54)
        Me.lstVendedores.Name = "lstVendedores"
        Me.lstVendedores.Size = New System.Drawing.Size(174, 184)
        Me.lstVendedores.TabIndex = 2
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuMarcarTodos, Me.mnuDesmarcarTodos})
        Me.ContextMenuStrip2.Name = "ContextMenuStrip2"
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(164, 48)
        '
        'mnuMarcarTodos
        '
        Me.mnuMarcarTodos.Name = "mnuMarcarTodos"
        Me.mnuMarcarTodos.Size = New System.Drawing.Size(163, 22)
        Me.mnuMarcarTodos.Text = "Marcar todos"
        '
        'mnuDesmarcarTodos
        '
        Me.mnuDesmarcarTodos.Name = "mnuDesmarcarTodos"
        Me.mnuDesmarcarTodos.Size = New System.Drawing.Size(163, 22)
        Me.mnuDesmarcarTodos.Text = "Desmarcar todos"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.chkIVA)
        Me.SplitContainer1.Panel1.Controls.Add(Me.chkPresupuesto)
        Me.SplitContainer1.Panel1.Controls.Add(Me.chkCosto)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox1)
        Me.SplitContainer1.Panel1.Controls.Add(Label3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.nudAno)
        Me.SplitContainer1.Panel1.Controls.Add(Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnGenerar)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lstVendedores)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ProgressBar1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.crv)
        Me.SplitContainer1.Size = New System.Drawing.Size(890, 475)
        Me.SplitContainer1.SplitterDistance = 177
        Me.SplitContainer1.TabIndex = 7
        '
        'chkCosto
        '
        Me.chkCosto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkCosto.AutoSize = True
        Me.chkCosto.Location = New System.Drawing.Point(9, 319)
        Me.chkCosto.Name = "chkCosto"
        Me.chkCosto.Size = New System.Drawing.Size(90, 17)
        Me.chkCosto.TabIndex = 11
        Me.chkCosto.Text = "Mostrar costo"
        Me.chkCosto.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.rbRpt2)
        Me.GroupBox1.Controls.Add(Me.rbRpt1)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 244)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(169, 69)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tipo de Reporte"
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
        'nudAno
        '
        Me.nudAno.Location = New System.Drawing.Point(44, 7)
        Me.nudAno.Maximum = New Decimal(New Integer() {2007, 0, 0, 0})
        Me.nudAno.Minimum = New Decimal(New Integer() {2007, 0, 0, 0})
        Me.nudAno.Name = "nudAno"
        Me.nudAno.Size = New System.Drawing.Size(64, 20)
        Me.nudAno.TabIndex = 8
        Me.nudAno.Value = New Decimal(New Integer() {2007, 0, 0, 0})
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
        Me.crv.Size = New System.Drawing.Size(709, 475)
        Me.crv.TabIndex = 6
        Me.crv.ViewTimeSelectionFormula = ""
        '
        'chkPresupuesto
        '
        Me.chkPresupuesto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkPresupuesto.AutoSize = True
        Me.chkPresupuesto.Location = New System.Drawing.Point(9, 342)
        Me.chkPresupuesto.Name = "chkPresupuesto"
        Me.chkPresupuesto.Size = New System.Drawing.Size(85, 17)
        Me.chkPresupuesto.TabIndex = 12
        Me.chkPresupuesto.Text = "Presupuesto"
        Me.chkPresupuesto.UseVisualStyleBackColor = True
        '
        'chkIVA
        '
        Me.chkIVA.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkIVA.AutoSize = True
        Me.chkIVA.Checked = True
        Me.chkIVA.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkIVA.Location = New System.Drawing.Point(9, 365)
        Me.chkIVA.Name = "chkIVA"
        Me.chkIVA.Size = New System.Drawing.Size(65, 17)
        Me.chkIVA.TabIndex = 13
        Me.chkIVA.Text = "Con IVA"
        Me.chkIVA.UseVisualStyleBackColor = True
        '
        'frmRptVtasA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(890, 475)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "frmRptVtasA"
        Me.Text = "Reporte de Ventas"
        Me.ContextMenuStrip2.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.nudAno, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnGenerar As System.Windows.Forms.Button
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lstVendedores As System.Windows.Forms.CheckedListBox
    Friend WithEvents ContextMenuStrip2 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuMarcarTodos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesmarcarTodos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents crv As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents nudAno As System.Windows.Forms.NumericUpDown
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbRpt2 As System.Windows.Forms.RadioButton
    Friend WithEvents rbRpt1 As System.Windows.Forms.RadioButton
    Friend WithEvents chkCosto As System.Windows.Forms.CheckBox
    Friend WithEvents chkPresupuesto As System.Windows.Forms.CheckBox
    Friend WithEvents chkIVA As System.Windows.Forms.CheckBox
End Class
