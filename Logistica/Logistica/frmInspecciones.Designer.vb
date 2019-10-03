<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInspecciones
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
        Dim Label1 As System.Windows.Forms.Label
        Dim Label2 As System.Windows.Forms.Label
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.dgvSigex = New System.Windows.Forms.DataGridView
        Me.col1Id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col1Intervencion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col1Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col1Relevador = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col1Estado = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.col1Cliente = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.mnu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuForzarFinalizado = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuTransferir = New System.Windows.Forms.ToolStripMenuItem
        Me.btnRefrescar = New System.Windows.Forms.Button
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.btnEliminar = New System.Windows.Forms.Button
        Me.btnTransferirFinalizados = New System.Windows.Forms.Button
        Me.dgvAdonix = New System.Windows.Forms.DataGridView
        Me.col2Intervencion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col2Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col2Cliente = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col2Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col2Sucursal = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col2Direccion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Label1 = New System.Windows.Forms.Label
        Label2 = New System.Windows.Forms.Label
        CType(Me.dgvSigex, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnu.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.dgvAdonix, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(3, 9)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(121, 13)
        Label1.TabIndex = 3
        Label1.Text = "Relevamientos en Sigex"
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Location = New System.Drawing.Point(3, 9)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(197, 13)
        Label2.TabIndex = 4
        Label2.Text = "Relevamientos en Adonix para confirmar"
        '
        'dgvSigex
        '
        Me.dgvSigex.AllowUserToAddRows = False
        Me.dgvSigex.AllowUserToDeleteRows = False
        Me.dgvSigex.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSigex.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvSigex.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSigex.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col1Id, Me.col1Intervencion, Me.col1Fecha, Me.col1Relevador, Me.col1Estado, Me.col1Cliente})
        Me.dgvSigex.ContextMenuStrip = Me.mnu
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvSigex.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvSigex.Location = New System.Drawing.Point(3, 28)
        Me.dgvSigex.Name = "dgvSigex"
        Me.dgvSigex.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSigex.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvSigex.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSigex.Size = New System.Drawing.Size(1119, 414)
        Me.dgvSigex.TabIndex = 0
        '
        'col1Id
        '
        Me.col1Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.col1Id.HeaderText = "Id"
        Me.col1Id.Name = "col1Id"
        Me.col1Id.ReadOnly = True
        Me.col1Id.Width = 41
        '
        'col1Intervencion
        '
        Me.col1Intervencion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.col1Intervencion.HeaderText = "Intervencion"
        Me.col1Intervencion.Name = "col1Intervencion"
        Me.col1Intervencion.ReadOnly = True
        Me.col1Intervencion.Width = 91
        '
        'col1Fecha
        '
        Me.col1Fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.col1Fecha.HeaderText = "Fecha"
        Me.col1Fecha.Name = "col1Fecha"
        Me.col1Fecha.ReadOnly = True
        Me.col1Fecha.Width = 62
        '
        'col1Relevador
        '
        Me.col1Relevador.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.col1Relevador.HeaderText = "Relevador"
        Me.col1Relevador.Name = "col1Relevador"
        Me.col1Relevador.ReadOnly = True
        Me.col1Relevador.Width = 81
        '
        'col1Estado
        '
        Me.col1Estado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.col1Estado.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.col1Estado.HeaderText = "Estado"
        Me.col1Estado.Name = "col1Estado"
        Me.col1Estado.ReadOnly = True
        Me.col1Estado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.col1Estado.Width = 65
        '
        'col1Cliente
        '
        Me.col1Cliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.col1Cliente.HeaderText = "Cliente"
        Me.col1Cliente.Name = "col1Cliente"
        Me.col1Cliente.ReadOnly = True
        Me.col1Cliente.Width = 64
        '
        'mnu
        '
        Me.mnu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuForzarFinalizado, Me.mnuTransferir})
        Me.mnu.Name = "mnu"
        Me.mnu.Size = New System.Drawing.Size(172, 48)
        '
        'mnuForzarFinalizado
        '
        Me.mnuForzarFinalizado.Name = "mnuForzarFinalizado"
        Me.mnuForzarFinalizado.Size = New System.Drawing.Size(171, 22)
        Me.mnuForzarFinalizado.Text = "Forzar Finalizado..."
        '
        'mnuTransferir
        '
        Me.mnuTransferir.Name = "mnuTransferir"
        Me.mnuTransferir.Size = New System.Drawing.Size(171, 22)
        Me.mnuTransferir.Text = "Transferir"
        '
        'btnRefrescar
        '
        Me.btnRefrescar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnRefrescar.Location = New System.Drawing.Point(12, 448)
        Me.btnRefrescar.Name = "btnRefrescar"
        Me.btnRefrescar.Size = New System.Drawing.Size(75, 43)
        Me.btnRefrescar.TabIndex = 1
        Me.btnRefrescar.Text = "Refrescar"
        Me.btnRefrescar.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnEliminar)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnTransferirFinalizados)
        Me.SplitContainer1.Panel1.Controls.Add(Label1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnRefrescar)
        Me.SplitContainer1.Panel1.Controls.Add(Me.dgvSigex)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgvAdonix)
        Me.SplitContainer1.Panel2.Controls.Add(Label2)
        Me.SplitContainer1.Panel2Collapsed = True
        Me.SplitContainer1.Size = New System.Drawing.Size(1125, 494)
        Me.SplitContainer1.SplitterDistance = 587
        Me.SplitContainer1.TabIndex = 2
        '
        'btnEliminar
        '
        Me.btnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnEliminar.Location = New System.Drawing.Point(191, 448)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(92, 43)
        Me.btnEliminar.TabIndex = 5
        Me.btnEliminar.Text = "Eliminar Seleccionados"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnTransferirFinalizados
        '
        Me.btnTransferirFinalizados.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnTransferirFinalizados.Location = New System.Drawing.Point(93, 448)
        Me.btnTransferirFinalizados.Name = "btnTransferirFinalizados"
        Me.btnTransferirFinalizados.Size = New System.Drawing.Size(92, 43)
        Me.btnTransferirFinalizados.TabIndex = 4
        Me.btnTransferirFinalizados.Text = "Transferir Finalizados"
        Me.btnTransferirFinalizados.UseVisualStyleBackColor = True
        '
        'dgvAdonix
        '
        Me.dgvAdonix.AllowUserToAddRows = False
        Me.dgvAdonix.AllowUserToDeleteRows = False
        Me.dgvAdonix.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvAdonix.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvAdonix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAdonix.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col2Intervencion, Me.col2Fecha, Me.col2Cliente, Me.col2Nombre, Me.col2Sucursal, Me.col2Direccion})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvAdonix.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvAdonix.Location = New System.Drawing.Point(3, 28)
        Me.dgvAdonix.Name = "dgvAdonix"
        Me.dgvAdonix.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvAdonix.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvAdonix.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvAdonix.Size = New System.Drawing.Size(528, 414)
        Me.dgvAdonix.TabIndex = 5
        '
        'col2Intervencion
        '
        Me.col2Intervencion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.col2Intervencion.HeaderText = "Intervención"
        Me.col2Intervencion.Name = "col2Intervencion"
        Me.col2Intervencion.ReadOnly = True
        Me.col2Intervencion.Width = 91
        '
        'col2Fecha
        '
        Me.col2Fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.col2Fecha.HeaderText = "Fecha"
        Me.col2Fecha.Name = "col2Fecha"
        Me.col2Fecha.ReadOnly = True
        Me.col2Fecha.Width = 62
        '
        'col2Cliente
        '
        Me.col2Cliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.col2Cliente.HeaderText = "Cliente"
        Me.col2Cliente.Name = "col2Cliente"
        Me.col2Cliente.ReadOnly = True
        Me.col2Cliente.Width = 64
        '
        'col2Nombre
        '
        Me.col2Nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.col2Nombre.HeaderText = "Nombre"
        Me.col2Nombre.Name = "col2Nombre"
        Me.col2Nombre.ReadOnly = True
        Me.col2Nombre.Width = 69
        '
        'col2Sucursal
        '
        Me.col2Sucursal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.col2Sucursal.HeaderText = "Sucursal"
        Me.col2Sucursal.Name = "col2Sucursal"
        Me.col2Sucursal.ReadOnly = True
        Me.col2Sucursal.Width = 73
        '
        'col2Direccion
        '
        Me.col2Direccion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.col2Direccion.HeaderText = "Dirección"
        Me.col2Direccion.Name = "col2Direccion"
        Me.col2Direccion.ReadOnly = True
        Me.col2Direccion.Width = 77
        '
        'frmInspecciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1125, 494)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "frmInspecciones"
        Me.Text = "Inspecciones"
        CType(Me.dgvSigex, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mnu.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.dgvAdonix, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvSigex As System.Windows.Forms.DataGridView
    Friend WithEvents btnRefrescar As System.Windows.Forms.Button
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents dgvAdonix As System.Windows.Forms.DataGridView
    Friend WithEvents mnu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents col2Intervencion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col2Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col2Cliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col2Nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col2Sucursal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col2Direccion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents mnuTransferir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuForzarFinalizado As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnTransferirFinalizados As System.Windows.Forms.Button
    Friend WithEvents col1Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col1Intervencion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col1Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col1Relevador As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col1Estado As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents col1Cliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
End Class
