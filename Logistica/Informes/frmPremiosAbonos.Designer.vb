<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPremiosAbonos
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
        Me.btnCalcular = New System.Windows.Forms.Button
        Me.crv = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.mCalDesde = New System.Windows.Forms.DateTimePicker
        Me.mCalHasta = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.mCalHasta)
        Me.SplitContainer1.Panel1.Controls.Add(Me.mCalDesde)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnCalcular)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.crv)
        Me.SplitContainer1.Size = New System.Drawing.Size(914, 465)
        Me.SplitContainer1.SplitterDistance = 270
        Me.SplitContainer1.TabIndex = 0
        '
        'btnCalcular
        '
        Me.btnCalcular.Location = New System.Drawing.Point(85, 93)
        Me.btnCalcular.Name = "btnCalcular"
        Me.btnCalcular.Size = New System.Drawing.Size(75, 23)
        Me.btnCalcular.TabIndex = 0
        Me.btnCalcular.Text = "Calcular"
        Me.btnCalcular.UseVisualStyleBackColor = True
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
        Me.crv.Size = New System.Drawing.Size(640, 465)
        Me.crv.TabIndex = 0
        Me.crv.ViewTimeSelectionFormula = ""
        '
        'mCalDesde
        '
        Me.mCalDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.mCalDesde.Location = New System.Drawing.Point(61, 12)
        Me.mCalDesde.Name = "mCalDesde"
        Me.mCalDesde.Size = New System.Drawing.Size(112, 20)
        Me.mCalDesde.TabIndex = 2
        '
        'mCalHasta
        '
        Me.mCalHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.mCalHasta.Location = New System.Drawing.Point(61, 45)
        Me.mCalHasta.Name = "mCalHasta"
        Me.mCalHasta.Size = New System.Drawing.Size(112, 20)
        Me.mCalHasta.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Desde:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Hasta:"
        '
        'frmPremiosAbonos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(914, 465)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "frmPremiosAbonos"
        Me.Text = "Premios Abonos"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents btnCalcular As System.Windows.Forms.Button
    Friend WithEvents crv As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents mCalHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents mCalDesde As System.Windows.Forms.DateTimePicker
End Class
