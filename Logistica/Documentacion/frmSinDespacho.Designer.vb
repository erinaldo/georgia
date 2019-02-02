<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSinDespacho
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.dgv = New System.Windows.Forms.DataGridView
        Me.mnuContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuVerDocumento = New System.Windows.Forms.ToolStripMenuItem
        Me.btnFiltrar = New System.Windows.Forms.Button
        Me.txtFiltrar = New System.Windows.Forms.TextBox
        Me.btnActualizar = New System.Windows.Forms.Button
        Me.colFecha = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colRemito = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCodigo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCliente = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colDireccion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colSector = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.colFechaEnvio = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colRuta = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colFechaRuta = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colVendedor = New System.Windows.Forms.DataGridViewTextBoxColumn
        Label1 = New System.Windows.Forms.Label
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnuContextMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(3, 14)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(32, 13)
        Label1.TabIndex = 1
        Label1.Text = "Filtro:"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.IsSplitterFixed = True
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
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnFiltrar)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtFiltrar)
        Me.SplitContainer1.Panel2.Controls.Add(Label1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnActualizar)
        Me.SplitContainer1.Size = New System.Drawing.Size(837, 462)
        Me.SplitContainer1.SplitterDistance = 414
        Me.SplitContainer1.TabIndex = 0
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToDeleteRows = False
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colFecha, Me.colRemito, Me.colCodigo, Me.colCliente, Me.colDireccion, Me.colSector, Me.colFechaEnvio, Me.colRuta, Me.colFechaRuta, Me.colVendedor})
        Me.dgv.ContextMenuStrip = Me.mnuContextMenu
        Me.dgv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv.Location = New System.Drawing.Point(0, 0)
        Me.dgv.Name = "dgv"
        Me.dgv.ReadOnly = True
        Me.dgv.Size = New System.Drawing.Size(837, 414)
        Me.dgv.TabIndex = 0
        '
        'mnuContextMenu
        '
        Me.mnuContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuVerDocumento})
        Me.mnuContextMenu.Name = "ContextMenu"
        Me.mnuContextMenu.Size = New System.Drawing.Size(158, 26)
        '
        'mnuVerDocumento
        '
        Me.mnuVerDocumento.Name = "mnuVerDocumento"
        Me.mnuVerDocumento.Size = New System.Drawing.Size(157, 22)
        Me.mnuVerDocumento.Text = "Ver documento"
        '
        'btnFiltrar
        '
        Me.btnFiltrar.Enabled = False
        Me.btnFiltrar.Location = New System.Drawing.Point(271, 9)
        Me.btnFiltrar.Name = "btnFiltrar"
        Me.btnFiltrar.Size = New System.Drawing.Size(75, 23)
        Me.btnFiltrar.TabIndex = 3
        Me.btnFiltrar.Text = "Filtrar"
        Me.btnFiltrar.UseVisualStyleBackColor = True
        '
        'txtFiltrar
        '
        Me.txtFiltrar.Enabled = False
        Me.txtFiltrar.Location = New System.Drawing.Point(41, 11)
        Me.txtFiltrar.Name = "txtFiltrar"
        Me.txtFiltrar.Size = New System.Drawing.Size(224, 20)
        Me.txtFiltrar.TabIndex = 2
        '
        'btnActualizar
        '
        Me.btnActualizar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnActualizar.Location = New System.Drawing.Point(750, 9)
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(75, 23)
        Me.btnActualizar.TabIndex = 0
        Me.btnActualizar.Text = "Actualizar"
        Me.btnActualizar.UseVisualStyleBackColor = True
        '
        'colFecha
        '
        Me.colFecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colFecha.HeaderText = "Fecha"
        Me.colFecha.Name = "colFecha"
        Me.colFecha.ReadOnly = True
        Me.colFecha.Width = 62
        '
        'colRemito
        '
        Me.colRemito.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colRemito.HeaderText = "Remito"
        Me.colRemito.Name = "colRemito"
        Me.colRemito.ReadOnly = True
        Me.colRemito.Width = 65
        '
        'colCodigo
        '
        Me.colCodigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colCodigo.HeaderText = "Codigo"
        Me.colCodigo.Name = "colCodigo"
        Me.colCodigo.ReadOnly = True
        Me.colCodigo.Width = 65
        '
        'colCliente
        '
        Me.colCliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colCliente.HeaderText = "Cliente"
        Me.colCliente.Name = "colCliente"
        Me.colCliente.ReadOnly = True
        '
        'colDireccion
        '
        Me.colDireccion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colDireccion.HeaderText = "Direccion"
        Me.colDireccion.Name = "colDireccion"
        Me.colDireccion.ReadOnly = True
        '
        'colSector
        '
        Me.colSector.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colSector.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.colSector.HeaderText = "Sector"
        Me.colSector.Name = "colSector"
        Me.colSector.ReadOnly = True
        Me.colSector.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colSector.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colSector.Width = 63
        '
        'colFechaEnvio
        '
        Me.colFechaEnvio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colFechaEnvio.HeaderText = "Fecha Envio"
        Me.colFechaEnvio.Name = "colFechaEnvio"
        Me.colFechaEnvio.ReadOnly = True
        Me.colFechaEnvio.Width = 92
        '
        'colRuta
        '
        Me.colRuta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colRuta.HeaderText = "Ruta"
        Me.colRuta.Name = "colRuta"
        Me.colRuta.ReadOnly = True
        Me.colRuta.Width = 55
        '
        'colFechaRuta
        '
        Me.colFechaRuta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle1.Format = "dd/MM/yyyy"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.colFechaRuta.DefaultCellStyle = DataGridViewCellStyle1
        Me.colFechaRuta.HeaderText = "Fecha Ruta"
        Me.colFechaRuta.Name = "colFechaRuta"
        Me.colFechaRuta.ReadOnly = True
        Me.colFechaRuta.Width = 88
        '
        'colVendedor
        '
        Me.colVendedor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.colVendedor.HeaderText = "Vendedor"
        Me.colVendedor.Name = "colVendedor"
        Me.colVendedor.ReadOnly = True
        Me.colVendedor.Width = 78
        '
        'frmSinDespacho
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(837, 462)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "frmSinDespacho"
        Me.Text = "Remitos sin despachar"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mnuContextMenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents btnActualizar As System.Windows.Forms.Button
    Friend WithEvents btnFiltrar As System.Windows.Forms.Button
    Friend WithEvents txtFiltrar As System.Windows.Forms.TextBox
    Friend WithEvents mnuContextMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuVerDocumento As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents colFecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRemito As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCodigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDireccion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSector As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colFechaEnvio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRuta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFechaRuta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colVendedor As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
