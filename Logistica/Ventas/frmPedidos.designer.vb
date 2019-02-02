<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPedidos
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
        Me.pedido_txtbox = New System.Windows.Forms.TextBox
        Me.cons_btn = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblsuc = New System.Windows.Forms.Label
        Me.txtsuc = New System.Windows.Forms.TextBox
        Me.ano_check = New System.Windows.Forms.CheckBox
        Me.cliente_radio = New System.Windows.Forms.RadioButton
        Me.pedido_radio = New System.Windows.Forms.RadioButton
        Me.cuadro_datagrid = New System.Windows.Forms.DataGridView
        Me.cliente_col = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cliente_principal_col = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Sucursal = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NumPedido_col = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EstadoEntrega_col = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.EstadoFactura_col = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.FechaEntrega_col = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.obs_principal_col = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.VerPedidoToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.VerPedidoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.adiciona_datagrid = New System.Windows.Forms.DataGridView
        Me.pedido_col = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.remito_col = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ruta_col = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colEstado = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.colnoconform = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.obs_adicional_col = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.sector_datagrid = New System.Windows.Forms.DataGridView
        Me.fecha_sector_col = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.hora_sector_col = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.remito_sector_col = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.desde_sector_col = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Para_sector_col = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VerRemitoEscaneadoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.GroupBox1.SuspendLayout()
        CType(Me.cuadro_datagrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip2.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.adiciona_datagrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sector_datagrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pedido_txtbox
        '
        Me.pedido_txtbox.Location = New System.Drawing.Point(62, 19)
        Me.pedido_txtbox.Name = "pedido_txtbox"
        Me.pedido_txtbox.Size = New System.Drawing.Size(142, 20)
        Me.pedido_txtbox.TabIndex = 0
        Me.pedido_txtbox.Text = "pedido"
        '
        'cons_btn
        '
        Me.cons_btn.Location = New System.Drawing.Point(147, 108)
        Me.cons_btn.Name = "cons_btn"
        Me.cons_btn.Size = New System.Drawing.Size(100, 23)
        Me.cons_btn.TabIndex = 4
        Me.cons_btn.Text = "Consultar"
        Me.cons_btn.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblsuc)
        Me.GroupBox1.Controls.Add(Me.txtsuc)
        Me.GroupBox1.Controls.Add(Me.ano_check)
        Me.GroupBox1.Controls.Add(Me.cons_btn)
        Me.GroupBox1.Controls.Add(Me.cliente_radio)
        Me.GroupBox1.Controls.Add(Me.pedido_txtbox)
        Me.GroupBox1.Controls.Add(Me.pedido_radio)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 16)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(262, 150)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Busqueda"
        '
        'lblsuc
        '
        Me.lblsuc.AutoSize = True
        Me.lblsuc.Enabled = False
        Me.lblsuc.Location = New System.Drawing.Point(62, 51)
        Me.lblsuc.Name = "lblsuc"
        Me.lblsuc.Size = New System.Drawing.Size(48, 13)
        Me.lblsuc.TabIndex = 9
        Me.lblsuc.Text = "Sucursal"
        '
        'txtsuc
        '
        Me.txtsuc.Enabled = False
        Me.txtsuc.Location = New System.Drawing.Point(116, 48)
        Me.txtsuc.Name = "txtsuc"
        Me.txtsuc.Size = New System.Drawing.Size(88, 20)
        Me.txtsuc.TabIndex = 8
        '
        'ano_check
        '
        Me.ano_check.AutoSize = True
        Me.ano_check.Checked = True
        Me.ano_check.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ano_check.Location = New System.Drawing.Point(42, 112)
        Me.ano_check.Name = "ano_check"
        Me.ano_check.Size = New System.Drawing.Size(78, 17)
        Me.ano_check.TabIndex = 7
        Me.ano_check.Text = "Año Actual"
        Me.ano_check.UseVisualStyleBackColor = True
        '
        'cliente_radio
        '
        Me.cliente_radio.AutoSize = True
        Me.cliente_radio.Location = New System.Drawing.Point(147, 71)
        Me.cliente_radio.Name = "cliente_radio"
        Me.cliente_radio.Size = New System.Drawing.Size(57, 17)
        Me.cliente_radio.TabIndex = 1
        Me.cliente_radio.Text = "Cliente"
        Me.cliente_radio.UseVisualStyleBackColor = True
        '
        'pedido_radio
        '
        Me.pedido_radio.AutoSize = True
        Me.pedido_radio.Checked = True
        Me.pedido_radio.Location = New System.Drawing.Point(62, 71)
        Me.pedido_radio.Name = "pedido_radio"
        Me.pedido_radio.Size = New System.Drawing.Size(58, 17)
        Me.pedido_radio.TabIndex = 0
        Me.pedido_radio.TabStop = True
        Me.pedido_radio.Text = "Pedido"
        Me.pedido_radio.UseVisualStyleBackColor = True
        '
        'cuadro_datagrid
        '
        Me.cuadro_datagrid.AllowUserToAddRows = False
        Me.cuadro_datagrid.AllowUserToDeleteRows = False
        Me.cuadro_datagrid.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cuadro_datagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.cuadro_datagrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cliente_col, Me.cliente_principal_col, Me.Sucursal, Me.NumPedido_col, Me.EstadoEntrega_col, Me.EstadoFactura_col, Me.FechaEntrega_col, Me.obs_principal_col})
        Me.cuadro_datagrid.ContextMenuStrip = Me.ContextMenuStrip2
        Me.cuadro_datagrid.Location = New System.Drawing.Point(285, 16)
        Me.cuadro_datagrid.Name = "cuadro_datagrid"
        Me.cuadro_datagrid.ReadOnly = True
        Me.cuadro_datagrid.RowHeadersVisible = False
        Me.cuadro_datagrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.cuadro_datagrid.Size = New System.Drawing.Size(808, 218)
        Me.cuadro_datagrid.TabIndex = 6
        '
        'cliente_col
        '
        Me.cliente_col.HeaderText = "Cliente"
        Me.cliente_col.Name = "cliente_col"
        Me.cliente_col.ReadOnly = True
        '
        'cliente_principal_col
        '
        Me.cliente_principal_col.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.cliente_principal_col.HeaderText = "Nombre Cliente"
        Me.cliente_principal_col.Name = "cliente_principal_col"
        Me.cliente_principal_col.ReadOnly = True
        Me.cliente_principal_col.Width = 96
        '
        'Sucursal
        '
        Me.Sucursal.HeaderText = "Sucursal"
        Me.Sucursal.Name = "Sucursal"
        Me.Sucursal.ReadOnly = True
        '
        'NumPedido_col
        '
        Me.NumPedido_col.HeaderText = "Numero de Pedido"
        Me.NumPedido_col.Name = "NumPedido_col"
        Me.NumPedido_col.ReadOnly = True
        '
        'EstadoEntrega_col
        '
        Me.EstadoEntrega_col.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.EstadoEntrega_col.HeaderText = "Estado Entrega"
        Me.EstadoEntrega_col.Name = "EstadoEntrega_col"
        Me.EstadoEntrega_col.ReadOnly = True
        Me.EstadoEntrega_col.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.EstadoEntrega_col.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'EstadoFactura_col
        '
        Me.EstadoFactura_col.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.EstadoFactura_col.HeaderText = "Estado Factura"
        Me.EstadoFactura_col.Name = "EstadoFactura_col"
        Me.EstadoFactura_col.ReadOnly = True
        Me.EstadoFactura_col.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.EstadoFactura_col.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'FechaEntrega_col
        '
        Me.FechaEntrega_col.HeaderText = "Fecha"
        Me.FechaEntrega_col.Name = "FechaEntrega_col"
        Me.FechaEntrega_col.ReadOnly = True
        '
        'obs_principal_col
        '
        Me.obs_principal_col.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.obs_principal_col.HeaderText = "Observaciones "
        Me.obs_principal_col.Name = "obs_principal_col"
        Me.obs_principal_col.ReadOnly = True
        Me.obs_principal_col.Width = 106
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.VerPedidoToolStripMenuItem1})
        Me.ContextMenuStrip2.Name = "ContextMenuStrip2"
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(132, 26)
        '
        'VerPedidoToolStripMenuItem1
        '
        Me.VerPedidoToolStripMenuItem1.Name = "VerPedidoToolStripMenuItem1"
        Me.VerPedidoToolStripMenuItem1.Size = New System.Drawing.Size(131, 22)
        Me.VerPedidoToolStripMenuItem1.Text = "Ver pedido"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.VerPedidoToolStripMenuItem, Me.VerRemitoEscaneadoToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(192, 70)
        '
        'VerPedidoToolStripMenuItem
        '
        Me.VerPedidoToolStripMenuItem.Name = "VerPedidoToolStripMenuItem"
        Me.VerPedidoToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
        Me.VerPedidoToolStripMenuItem.Text = "Ver pedido"
        '
        'adiciona_datagrid
        '
        Me.adiciona_datagrid.AllowUserToAddRows = False
        Me.adiciona_datagrid.AllowUserToDeleteRows = False
        Me.adiciona_datagrid.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.adiciona_datagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.adiciona_datagrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.pedido_col, Me.remito_col, Me.ruta_col, Me.Fecha, Me.colEstado, Me.colnoconform, Me.obs_adicional_col})
        Me.adiciona_datagrid.ContextMenuStrip = Me.ContextMenuStrip1
        Me.adiciona_datagrid.Location = New System.Drawing.Point(12, 246)
        Me.adiciona_datagrid.Name = "adiciona_datagrid"
        Me.adiciona_datagrid.ReadOnly = True
        Me.adiciona_datagrid.RowHeadersVisible = False
        Me.adiciona_datagrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.adiciona_datagrid.Size = New System.Drawing.Size(637, 149)
        Me.adiciona_datagrid.TabIndex = 7
        '
        'pedido_col
        '
        Me.pedido_col.HeaderText = "Numero de pedido"
        Me.pedido_col.Name = "pedido_col"
        Me.pedido_col.ReadOnly = True
        '
        'remito_col
        '
        Me.remito_col.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.remito_col.HeaderText = "Numero de remito"
        Me.remito_col.Name = "remito_col"
        Me.remito_col.ReadOnly = True
        Me.remito_col.Width = 80
        '
        'ruta_col
        '
        Me.ruta_col.HeaderText = "Numero de Ruta"
        Me.ruta_col.Name = "ruta_col"
        Me.ruta_col.ReadOnly = True
        '
        'Fecha
        '
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.ReadOnly = True
        '
        'colEstado
        '
        Me.colEstado.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.colEstado.HeaderText = "estado"
        Me.colEstado.Name = "colEstado"
        Me.colEstado.ReadOnly = True
        '
        'colnoconform
        '
        Me.colnoconform.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.colnoconform.HeaderText = "Motivo"
        Me.colnoconform.Name = "colnoconform"
        Me.colnoconform.ReadOnly = True
        '
        'obs_adicional_col
        '
        Me.obs_adicional_col.HeaderText = "observaciones"
        Me.obs_adicional_col.Name = "obs_adicional_col"
        Me.obs_adicional_col.ReadOnly = True
        '
        'sector_datagrid
        '
        Me.sector_datagrid.AllowUserToAddRows = False
        Me.sector_datagrid.AllowUserToDeleteRows = False
        Me.sector_datagrid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sector_datagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.sector_datagrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.fecha_sector_col, Me.hora_sector_col, Me.remito_sector_col, Me.desde_sector_col, Me.Para_sector_col})
        Me.sector_datagrid.Location = New System.Drawing.Point(655, 246)
        Me.sector_datagrid.Name = "sector_datagrid"
        Me.sector_datagrid.ReadOnly = True
        Me.sector_datagrid.RowHeadersVisible = False
        Me.sector_datagrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.sector_datagrid.Size = New System.Drawing.Size(438, 149)
        Me.sector_datagrid.TabIndex = 8
        '
        'fecha_sector_col
        '
        Me.fecha_sector_col.HeaderText = "Fecha"
        Me.fecha_sector_col.Name = "fecha_sector_col"
        Me.fecha_sector_col.ReadOnly = True
        '
        'hora_sector_col
        '
        Me.hora_sector_col.HeaderText = "Hora"
        Me.hora_sector_col.Name = "hora_sector_col"
        Me.hora_sector_col.ReadOnly = True
        '
        'remito_sector_col
        '
        Me.remito_sector_col.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.remito_sector_col.HeaderText = "Remito"
        Me.remito_sector_col.Name = "remito_sector_col"
        Me.remito_sector_col.ReadOnly = True
        Me.remito_sector_col.Width = 65
        '
        'desde_sector_col
        '
        Me.desde_sector_col.HeaderText = "Desde"
        Me.desde_sector_col.Name = "desde_sector_col"
        Me.desde_sector_col.ReadOnly = True
        '
        'Para_sector_col
        '
        Me.Para_sector_col.HeaderText = "Para"
        Me.Para_sector_col.Name = "Para_sector_col"
        Me.Para_sector_col.ReadOnly = True
        '
        'VerRemitoEscaneadoToolStripMenuItem
        '
        Me.VerRemitoEscaneadoToolStripMenuItem.Name = "VerRemitoEscaneadoToolStripMenuItem"
        Me.VerRemitoEscaneadoToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
        Me.VerRemitoEscaneadoToolStripMenuItem.Text = "Ver Remito Escaneado"
        '
        'frmPedidos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1117, 434)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.adiciona_datagrid)
        Me.Controls.Add(Me.sector_datagrid)
        Me.Controls.Add(Me.cuadro_datagrid)
        Me.Name = "frmPedidos"
        Me.Text = "Pedidos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.cuadro_datagrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip2.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.adiciona_datagrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sector_datagrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pedido_txtbox As System.Windows.Forms.TextBox
    Friend WithEvents cons_btn As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cliente_radio As System.Windows.Forms.RadioButton
    Friend WithEvents pedido_radio As System.Windows.Forms.RadioButton
    Friend WithEvents cuadro_datagrid As System.Windows.Forms.DataGridView
    Friend WithEvents ano_check As System.Windows.Forms.CheckBox
    Friend WithEvents adiciona_datagrid As System.Windows.Forms.DataGridView
    Friend WithEvents sector_datagrid As System.Windows.Forms.DataGridView
    Friend WithEvents fecha_sector_col As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents hora_sector_col As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents remito_sector_col As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents desde_sector_col As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Para_sector_col As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents VerPedidoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuStrip2 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents VerPedidoToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblsuc As System.Windows.Forms.Label
    Friend WithEvents txtsuc As System.Windows.Forms.TextBox
    Friend WithEvents pedido_col As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents remito_col As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ruta_col As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colEstado As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colnoconform As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents obs_adicional_col As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cliente_col As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cliente_principal_col As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Sucursal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NumPedido_col As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EstadoEntrega_col As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents EstadoFactura_col As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents FechaEntrega_col As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents obs_principal_col As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VerRemitoEscaneadoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
