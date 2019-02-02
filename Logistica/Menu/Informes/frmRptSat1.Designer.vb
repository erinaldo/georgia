<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSat1
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
        Me.btnGenerar = New System.Windows.Forms.Button
        Me.Calendario = New System.Windows.Forms.MonthCalendar
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuMarcarFeriado = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuQuitarFeriado = New System.Windows.Forms.ToolStripMenuItem
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.Label1 = New System.Windows.Forms.Label
        Me.lstVendedores = New System.Windows.Forms.CheckedListBox
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuMarcarTodos = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuDesmarcarTodos = New System.Windows.Forms.ToolStripMenuItem
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.crv = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Label2 = New System.Windows.Forms.Label
        Me.ContextMenuStrip1.SuspendLayout()
        Me.ContextMenuStrip2.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Location = New System.Drawing.Point(6, 173)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(67, 13)
        Label2.TabIndex = 1
        Label2.Text = "Vendedores:"
        '
        'btnGenerar
        '
        Me.btnGenerar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGenerar.Enabled = False
        Me.btnGenerar.Location = New System.Drawing.Point(149, 437)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(75, 23)
        Me.btnGenerar.TabIndex = 3
        Me.btnGenerar.Text = "Generar"
        Me.btnGenerar.UseVisualStyleBackColor = True
        '
        'Calendario
        '
        Me.Calendario.ContextMenuStrip = Me.ContextMenuStrip1
        Me.Calendario.Dock = System.Windows.Forms.DockStyle.Top
        Me.Calendario.Location = New System.Drawing.Point(0, 0)
        Me.Calendario.MaxSelectionCount = 1
        Me.Calendario.MinDate = New Date(2007, 12, 1, 0, 0, 0, 0)
        Me.Calendario.Name = "Calendario"
        Me.Calendario.TabIndex = 0
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuMarcarFeriado, Me.mnuQuitarFeriado})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(186, 48)
        '
        'mnuMarcarFeriado
        '
        Me.mnuMarcarFeriado.Name = "mnuMarcarFeriado"
        Me.mnuMarcarFeriado.Size = New System.Drawing.Size(185, 22)
        Me.mnuMarcarFeriado.Text = "Marcar como feriado"
        '
        'mnuQuitarFeriado
        '
        Me.mnuQuitarFeriado.Name = "mnuQuitarFeriado"
        Me.mnuQuitarFeriado.Size = New System.Drawing.Size(185, 22)
        Me.mnuQuitarFeriado.Text = "Quitar como feriado"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProgressBar1.Location = New System.Drawing.Point(6, 489)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(220, 23)
        Me.ProgressBar1.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.Location = New System.Drawing.Point(6, 453)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(223, 33)
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
        Me.lstVendedores.Location = New System.Drawing.Point(3, 189)
        Me.lstVendedores.Name = "lstVendedores"
        Me.lstVendedores.Size = New System.Drawing.Size(226, 124)
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.Calendario)
        Me.SplitContainer1.Panel1.Controls.Add(Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnGenerar)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lstVendedores)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ProgressBar1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.crv)
        Me.SplitContainer1.Size = New System.Drawing.Size(892, 521)
        Me.SplitContainer1.SplitterDistance = 232
        Me.SplitContainer1.TabIndex = 7
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
        Me.crv.Size = New System.Drawing.Size(656, 521)
        Me.crv.TabIndex = 6
        Me.crv.ViewTimeSelectionFormula = ""
        '
        'frmSat1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(892, 521)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "frmSat1"
        Me.Text = "Reporte de Ventas"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ContextMenuStrip2.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnGenerar As System.Windows.Forms.Button
    Friend WithEvents Calendario As System.Windows.Forms.MonthCalendar
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuMarcarFeriado As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuQuitarFeriado As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lstVendedores As System.Windows.Forms.CheckedListBox
    Friend WithEvents ContextMenuStrip2 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuMarcarTodos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesmarcarTodos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents crv As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
