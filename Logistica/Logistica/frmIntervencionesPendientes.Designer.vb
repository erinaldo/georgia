<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmIntervencionesPendientes
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
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.dgv = New System.Windows.Forms.DataGridView
        Me.btnActualizar = New System.Windows.Forms.Button
        Me.colNum = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colTyp = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colBpcnum = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colBpcNam = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colDat = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colBpaAdd = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colAdd = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCantidad = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colObservaciones = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cms = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuObservaciones = New System.Windows.Forms.ToolStripMenuItem
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cms.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.dgv)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnActualizar)
        Me.SplitContainer1.Size = New System.Drawing.Size(976, 496)
        Me.SplitContainer1.SplitterDistance = 435
        Me.SplitContainer1.TabIndex = 0
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToDeleteRows = False
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colNum, Me.colTyp, Me.colBpcnum, Me.colBpcNam, Me.colDat, Me.colBpaAdd, Me.colAdd, Me.colCantidad, Me.colObservaciones})
        Me.dgv.ContextMenuStrip = Me.cms
        Me.dgv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv.Location = New System.Drawing.Point(0, 0)
        Me.dgv.Name = "dgv"
        Me.dgv.ReadOnly = True
        Me.dgv.Size = New System.Drawing.Size(976, 435)
        Me.dgv.TabIndex = 0
        '
        'btnActualizar
        '
        Me.btnActualizar.Location = New System.Drawing.Point(889, 22)
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(75, 23)
        Me.btnActualizar.TabIndex = 0
        Me.btnActualizar.Text = "Actualizar"
        Me.btnActualizar.UseVisualStyleBackColor = True
        '
        'colNum
        '
        Me.colNum.HeaderText = "Numero"
        Me.colNum.Name = "colNum"
        Me.colNum.ReadOnly = True
        '
        'colTyp
        '
        Me.colTyp.HeaderText = "Tipo"
        Me.colTyp.Name = "colTyp"
        Me.colTyp.ReadOnly = True
        '
        'colBpcnum
        '
        Me.colBpcnum.HeaderText = "Cliente"
        Me.colBpcnum.Name = "colBpcnum"
        Me.colBpcnum.ReadOnly = True
        '
        'colBpcNam
        '
        Me.colBpcNam.HeaderText = "Nombre"
        Me.colBpcNam.Name = "colBpcNam"
        Me.colBpcNam.ReadOnly = True
        '
        'colDat
        '
        Me.colDat.HeaderText = "Fecha"
        Me.colDat.Name = "colDat"
        Me.colDat.ReadOnly = True
        '
        'colBpaAdd
        '
        Me.colBpaAdd.HeaderText = "Sucursal"
        Me.colBpaAdd.Name = "colBpaAdd"
        Me.colBpaAdd.ReadOnly = True
        '
        'colAdd
        '
        Me.colAdd.HeaderText = "Dirección"
        Me.colAdd.Name = "colAdd"
        Me.colAdd.ReadOnly = True
        '
        'colCantidad
        '
        Me.colCantidad.HeaderText = "Cantidad"
        Me.colCantidad.Name = "colCantidad"
        Me.colCantidad.ReadOnly = True
        '
        'colObservaciones
        '
        Me.colObservaciones.HeaderText = "Observaciones"
        Me.colObservaciones.Name = "colObservaciones"
        Me.colObservaciones.ReadOnly = True
        '
        'cms
        '
        Me.cms.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuObservaciones})
        Me.cms.Name = "cms"
        Me.cms.Size = New System.Drawing.Size(161, 26)
        '
        'mnuObservaciones
        '
        Me.mnuObservaciones.Name = "mnuObservaciones"
        Me.mnuObservaciones.Size = New System.Drawing.Size(160, 22)
        Me.mnuObservaciones.Text = "Observaciones..."
        '
        'frmIntervencionesPendientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(976, 496)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "frmIntervencionesPendientes"
        Me.Text = "Intervenciones Pendientes"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cms.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents btnActualizar As System.Windows.Forms.Button
    Friend WithEvents colNum As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTyp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBpcnum As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBpcNam As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDat As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBpaAdd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAdd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colObservaciones As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cms As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuObservaciones As System.Windows.Forms.ToolStripMenuItem
End Class
