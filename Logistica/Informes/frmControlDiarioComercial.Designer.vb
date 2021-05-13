<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmControlDiarioComercial
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
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.pBar = New System.Windows.Forms.ProgressBar
        Me.btnGenerar = New System.Windows.Forms.Button
        Me.mCal = New System.Windows.Forms.MonthCalendar
        Me.crv = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.pBar)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnGenerar)
        Me.SplitContainer1.Panel1.Controls.Add(Me.mCal)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.crv)
        Me.SplitContainer1.Size = New System.Drawing.Size(970, 452)
        Me.SplitContainer1.SplitterDistance = 267
        Me.SplitContainer1.TabIndex = 0
        '
        'pBar
        '
        Me.pBar.Location = New System.Drawing.Point(9, 183)
        Me.pBar.Name = "pBar"
        Me.pBar.Size = New System.Drawing.Size(248, 23)
        Me.pBar.TabIndex = 2
        '
        'btnGenerar
        '
        Me.btnGenerar.Location = New System.Drawing.Point(91, 219)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(75, 23)
        Me.btnGenerar.TabIndex = 1
        Me.btnGenerar.Text = "Consultar"
        Me.btnGenerar.UseVisualStyleBackColor = True
        '
        'mCal
        '
        Me.mCal.Location = New System.Drawing.Point(9, 9)
        Me.mCal.MaxSelectionCount = 1
        Me.mCal.Name = "mCal"
        Me.mCal.TabIndex = 0
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
        Me.crv.Size = New System.Drawing.Size(699, 452)
        Me.crv.TabIndex = 0
        Me.crv.ViewTimeSelectionFormula = ""
        '
        'frmControlDiarioComercial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(970, 452)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "frmControlDiarioComercial"
        Me.Text = "Control Diario Comercial"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents pBar As System.Windows.Forms.ProgressBar
    Friend WithEvents btnGenerar As System.Windows.Forms.Button
    Friend WithEvents mCal As System.Windows.Forms.MonthCalendar
    Friend WithEvents crv As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
