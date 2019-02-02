<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMotors
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
        Me.txtCliente = New System.Windows.Forms.TextBox
        Me.dtp = New System.Windows.Forms.DateTimePicker
        Me.btnImprimir = New System.Windows.Forms.Button
        Me.btnBuscar = New System.Windows.Forms.Button
        Me.dgv = New System.Windows.Forms.DataGridView
        Me.colRto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colSuc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colDireccion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colLoc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColProv = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtCliente)
        Me.SplitContainer1.Panel1.Controls.Add(Me.dtp)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnImprimir)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnBuscar)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgv)
        Me.SplitContainer1.Size = New System.Drawing.Size(612, 373)
        Me.SplitContainer1.TabIndex = 0
        '
        'txtCliente
        '
        Me.txtCliente.Location = New System.Drawing.Point(134, 17)
        Me.txtCliente.MaxLength = 6
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(129, 20)
        Me.txtCliente.TabIndex = 3
        '
        'dtp
        '
        Me.dtp.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp.Location = New System.Drawing.Point(12, 17)
        Me.dtp.Name = "dtp"
        Me.dtp.Size = New System.Drawing.Size(116, 20)
        Me.dtp.TabIndex = 2
        '
        'btnImprimir
        '
        Me.btnImprimir.Location = New System.Drawing.Point(359, 15)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(75, 23)
        Me.btnImprimir.TabIndex = 1
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Location = New System.Drawing.Point(278, 15)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(75, 23)
        Me.btnBuscar.TabIndex = 0
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToResizeRows = False
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colRto, Me.colSuc, Me.colDireccion, Me.colLoc, Me.ColProv})
        Me.dgv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv.Location = New System.Drawing.Point(0, 0)
        Me.dgv.Name = "dgv"
        Me.dgv.ReadOnly = True
        Me.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv.Size = New System.Drawing.Size(612, 319)
        Me.dgv.TabIndex = 0
        '
        'colRto
        '
        Me.colRto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colRto.HeaderText = "Remito"
        Me.colRto.Name = "colRto"
        Me.colRto.ReadOnly = True
        Me.colRto.Width = 65
        '
        'colSuc
        '
        Me.colSuc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.colSuc.HeaderText = "Suc"
        Me.colSuc.Name = "colSuc"
        Me.colSuc.ReadOnly = True
        Me.colSuc.Width = 51
        '
        'colDireccion
        '
        Me.colDireccion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colDireccion.HeaderText = "Direccion"
        Me.colDireccion.Name = "colDireccion"
        Me.colDireccion.ReadOnly = True
        '
        'colLoc
        '
        Me.colLoc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colLoc.HeaderText = "Localidad"
        Me.colLoc.Name = "colLoc"
        Me.colLoc.ReadOnly = True
        '
        'ColProv
        '
        Me.ColProv.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.ColProv.HeaderText = "Provincia"
        Me.ColProv.Name = "ColProv"
        Me.ColProv.ReadOnly = True
        Me.ColProv.Width = 76
        '
        'frmMotors
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(612, 373)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "frmMotors"
        Me.Text = "Etiquetas Gral Motors"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents dtp As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents colRto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSuc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDireccion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colLoc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColProv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
End Class
