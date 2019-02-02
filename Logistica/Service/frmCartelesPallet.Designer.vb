<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCartelesPallet
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
        Me.btn1 = New System.Windows.Forms.Button
        Me.nudCantidad = New System.Windows.Forms.NumericUpDown
        Me.crv = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.btn2 = New System.Windows.Forms.Button
        Label1 = New System.Windows.Forms.Label
        CType(Me.nudCantidad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn1
        '
        Me.btn1.Location = New System.Drawing.Point(144, 28)
        Me.btn1.Name = "btn1"
        Me.btn1.Size = New System.Drawing.Size(75, 23)
        Me.btn1.TabIndex = 0
        Me.btn1.Text = "Generar"
        Me.btn1.UseVisualStyleBackColor = True
        '
        'nudCantidad
        '
        Me.nudCantidad.Location = New System.Drawing.Point(25, 28)
        Me.nudCantidad.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudCantidad.Name = "nudCantidad"
        Me.nudCantidad.Size = New System.Drawing.Size(75, 20)
        Me.nudCantidad.TabIndex = 1
        Me.nudCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nudCantidad.Value = New Decimal(New Integer() {20, 0, 0, 0})
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
        Me.crv.ShowGotoPageButton = False
        Me.crv.ShowGroupTreeButton = False
        Me.crv.ShowRefreshButton = False
        Me.crv.ShowTextSearchButton = False
        Me.crv.ShowZoomButton = False
        Me.crv.Size = New System.Drawing.Size(774, 388)
        Me.crv.TabIndex = 2
        Me.crv.ViewTimeSelectionFormula = ""
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.btn2)
        Me.SplitContainer1.Panel1.Controls.Add(Label1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btn1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.nudCantidad)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.crv)
        Me.SplitContainer1.Size = New System.Drawing.Size(774, 458)
        Me.SplitContainer1.SplitterDistance = 66
        Me.SplitContainer1.TabIndex = 3
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(25, 9)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(104, 13)
        Label1.TabIndex = 2
        Label1.Text = "Cantidad de carteles"
        '
        'btn2
        '
        Me.btn2.Location = New System.Drawing.Point(248, 28)
        Me.btn2.Name = "btn2"
        Me.btn2.Size = New System.Drawing.Size(208, 23)
        Me.btn2.TabIndex = 3
        Me.btn2.Text = "Ver últimos carteles generados"
        Me.btn2.UseVisualStyleBackColor = True
        '
        'frmCartelesPallet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(774, 458)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "frmCartelesPallet"
        Me.Text = "Impresión Carteles de Pallet"
        CType(Me.nudCantidad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn1 As System.Windows.Forms.Button
    Friend WithEvents nudCantidad As System.Windows.Forms.NumericUpDown
    Friend WithEvents crv As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents btn2 As System.Windows.Forms.Button
End Class
