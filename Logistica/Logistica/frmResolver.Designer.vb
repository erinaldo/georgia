<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmResolver
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmResolver))
        Me.dgv = New System.Windows.Forms.DataGridView
        Me.cmnu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuReactivar = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuCerrar = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator
        Me.mnuVerDocumento = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuHistorial = New System.Windows.Forms.ToolStripMenuItem
        Me.clbTipos = New System.Windows.Forms.CheckedListBox
        Me.cmdActualizar = New System.Windows.Forms.Button
        Me.cmdFiltrar = New System.Windows.Forms.Button
        Me.Sector = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.fecha = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colNum = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colTipo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colBpcnum = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCliente = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colSuc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colDireccion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCty = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colTel = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colRep = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colHD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colHH1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colHD2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colHH2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmnu.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToDeleteRows = False
        Me.dgv.AllowUserToResizeColumns = False
        Me.dgv.AllowUserToResizeRows = False
        Me.dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Sector, Me.fecha, Me.colNum, Me.colTipo, Me.colBpcnum, Me.colCliente, Me.colSuc, Me.colDireccion, Me.colCty, Me.colTel, Me.colRep, Me.colHD1, Me.colHH1, Me.colHD2, Me.colHH2})
        Me.dgv.ContextMenuStrip = Me.cmnu
        Me.dgv.Location = New System.Drawing.Point(12, 12)
        Me.dgv.MultiSelect = False
        Me.dgv.Name = "dgv"
        Me.dgv.ReadOnly = True
        Me.dgv.RowHeadersVisible = False
        Me.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv.Size = New System.Drawing.Size(786, 452)
        Me.dgv.TabIndex = 1
        '
        'cmnu
        '
        Me.cmnu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuReactivar, Me.mnuCerrar, Me.ToolStripMenuItem1, Me.mnuVerDocumento, Me.mnuHistorial})
        Me.cmnu.Name = "ContextMenu"
        Me.cmnu.Size = New System.Drawing.Size(170, 98)
        '
        'mnuReactivar
        '
        Me.mnuReactivar.Name = "mnuReactivar"
        Me.mnuReactivar.Size = New System.Drawing.Size(169, 22)
        Me.mnuReactivar.Text = "Reactivar"
        '
        'mnuCerrar
        '
        Me.mnuCerrar.Name = "mnuCerrar"
        Me.mnuCerrar.Size = New System.Drawing.Size(169, 22)
        Me.mnuCerrar.Text = "Cerrar"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(166, 6)
        '
        'mnuVerDocumento
        '
        Me.mnuVerDocumento.Name = "mnuVerDocumento"
        Me.mnuVerDocumento.Size = New System.Drawing.Size(169, 22)
        Me.mnuVerDocumento.Text = "Ver Documento"
        '
        'mnuHistorial
        '
        Me.mnuHistorial.Name = "mnuHistorial"
        Me.mnuHistorial.Size = New System.Drawing.Size(169, 22)
        Me.mnuHistorial.Text = "Historial Logístico"
        '
        'clbTipos
        '
        Me.clbTipos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.clbTipos.CheckOnClick = True
        Me.clbTipos.FormattingEnabled = True
        Me.clbTipos.Location = New System.Drawing.Point(804, 67)
        Me.clbTipos.Name = "clbTipos"
        Me.clbTipos.Size = New System.Drawing.Size(75, 79)
        Me.clbTipos.TabIndex = 2
        '
        'cmdActualizar
        '
        Me.cmdActualizar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdActualizar.Location = New System.Drawing.Point(804, 12)
        Me.cmdActualizar.Name = "cmdActualizar"
        Me.cmdActualizar.Size = New System.Drawing.Size(75, 23)
        Me.cmdActualizar.TabIndex = 3
        Me.cmdActualizar.Text = "Actualizar"
        Me.cmdActualizar.UseVisualStyleBackColor = True
        '
        'cmdFiltrar
        '
        Me.cmdFiltrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdFiltrar.Location = New System.Drawing.Point(804, 152)
        Me.cmdFiltrar.Name = "cmdFiltrar"
        Me.cmdFiltrar.Size = New System.Drawing.Size(75, 23)
        Me.cmdFiltrar.TabIndex = 4
        Me.cmdFiltrar.Text = "Filtrar"
        Me.cmdFiltrar.UseVisualStyleBackColor = True
        '
        'Sector
        '
        Me.Sector.HeaderText = "Sector"
        Me.Sector.Name = "Sector"
        Me.Sector.ReadOnly = True
        '
        'fecha
        '
        Me.fecha.HeaderText = "fecha"
        Me.fecha.Name = "fecha"
        Me.fecha.ReadOnly = True
        '
        'colNum
        '
        Me.colNum.HeaderText = "Intervención"
        Me.colNum.Name = "colNum"
        Me.colNum.ReadOnly = True
        '
        'colTipo
        '
        Me.colTipo.HeaderText = "Tipo"
        Me.colTipo.Name = "colTipo"
        Me.colTipo.ReadOnly = True
        '
        'colBpcnum
        '
        Me.colBpcnum.HeaderText = "Codigo"
        Me.colBpcnum.Name = "colBpcnum"
        Me.colBpcnum.ReadOnly = True
        '
        'colCliente
        '
        Me.colCliente.HeaderText = "Cliente"
        Me.colCliente.Name = "colCliente"
        Me.colCliente.ReadOnly = True
        '
        'colSuc
        '
        Me.colSuc.HeaderText = "Suc"
        Me.colSuc.Name = "colSuc"
        Me.colSuc.ReadOnly = True
        '
        'colDireccion
        '
        Me.colDireccion.HeaderText = "Dirección"
        Me.colDireccion.Name = "colDireccion"
        Me.colDireccion.ReadOnly = True
        '
        'colCty
        '
        Me.colCty.HeaderText = "Localidad"
        Me.colCty.Name = "colCty"
        Me.colCty.ReadOnly = True
        '
        'colTel
        '
        Me.colTel.HeaderText = "Telefono"
        Me.colTel.Name = "colTel"
        Me.colTel.ReadOnly = True
        '
        'colRep
        '
        Me.colRep.HeaderText = "Vend"
        Me.colRep.Name = "colRep"
        Me.colRep.ReadOnly = True
        '
        'colHD1
        '
        Me.colHD1.HeaderText = "H Desde"
        Me.colHD1.Name = "colHD1"
        Me.colHD1.ReadOnly = True
        '
        'colHH1
        '
        Me.colHH1.HeaderText = "H Hasta"
        Me.colHH1.Name = "colHH1"
        Me.colHH1.ReadOnly = True
        '
        'colHD2
        '
        Me.colHD2.HeaderText = "H Desde"
        Me.colHD2.Name = "colHD2"
        Me.colHD2.ReadOnly = True
        Me.colHD2.Visible = False
        '
        'colHH2
        '
        Me.colHH2.HeaderText = "H Hasta"
        Me.colHH2.Name = "colHH2"
        Me.colHH2.ReadOnly = True
        Me.colHH2.Visible = False
        '
        'frmResolver
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(886, 476)
        Me.Controls.Add(Me.cmdFiltrar)
        Me.Controls.Add(Me.cmdActualizar)
        Me.Controls.Add(Me.clbTipos)
        Me.Controls.Add(Me.dgv)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmResolver"
        Me.ShowInTaskbar = False
        Me.Tag = ""
        Me.Text = "No conformidades a Resolver"
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmnu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents clbTipos As System.Windows.Forms.CheckedListBox
    Friend WithEvents cmdActualizar As System.Windows.Forms.Button
    Friend WithEvents cmdFiltrar As System.Windows.Forms.Button
    Friend WithEvents cmnu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuReactivar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuCerrar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuVerDocumento As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuHistorial As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Sector As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNum As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBpcnum As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSuc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDireccion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRep As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colHD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colHH1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colHD2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colHH2 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
