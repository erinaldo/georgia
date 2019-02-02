<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDistribuidoresInactivos
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
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.Calendario = New System.Windows.Forms.MonthCalendar
        Me.btnGenerar = New System.Windows.Forms.Button
        Me.lstVendedores = New System.Windows.Forms.CheckedListBox
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuMarcarTodos = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuDesmarcarTodos = New System.Windows.Forms.ToolStripMenuItem
        Me.dgv = New System.Windows.Forms.DataGridView
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuUltimaCompra = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuSaldoCuenta = New System.Windows.Forms.ToolStripMenuItem
        Me.colCodigo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCliente = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colLocalidad = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colProvincia = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colEstado = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.colVendedor = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colTipo = New System.Windows.Forms.DataGridViewComboBoxColumn
        Label1 = New System.Windows.Forms.Label
        Label2 = New System.Windows.Forms.Label
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.ContextMenuStrip2.SuspendLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Label1.Location = New System.Drawing.Point(3, 9)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(173, 47)
        Label1.TabIndex = 4
        Label1.Text = "Clientes distribuidores y supermercados que no compran desde:"
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Location = New System.Drawing.Point(3, 218)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(67, 13)
        Label2.TabIndex = 5
        Label2.Text = "Vendedores:"
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
        Me.SplitContainer1.Panel1.Controls.Add(Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Label1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Calendario)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnGenerar)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lstVendedores)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgv)
        Me.SplitContainer1.Size = New System.Drawing.Size(892, 521)
        Me.SplitContainer1.SplitterDistance = 179
        Me.SplitContainer1.TabIndex = 8
        '
        'Calendario
        '
        Me.Calendario.Location = New System.Drawing.Point(3, 54)
        Me.Calendario.MaxSelectionCount = 1
        Me.Calendario.MinDate = New Date(2007, 12, 1, 0, 0, 0, 0)
        Me.Calendario.Name = "Calendario"
        Me.Calendario.TabIndex = 0
        '
        'btnGenerar
        '
        Me.btnGenerar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGenerar.Enabled = False
        Me.btnGenerar.Location = New System.Drawing.Point(56, 484)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(75, 23)
        Me.btnGenerar.TabIndex = 3
        Me.btnGenerar.Text = "Generar"
        Me.btnGenerar.UseVisualStyleBackColor = True
        '
        'lstVendedores
        '
        Me.lstVendedores.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstVendedores.CheckOnClick = True
        Me.lstVendedores.ContextMenuStrip = Me.ContextMenuStrip2
        Me.lstVendedores.FormattingEnabled = True
        Me.lstVendedores.Location = New System.Drawing.Point(3, 234)
        Me.lstVendedores.Name = "lstVendedores"
        Me.lstVendedores.Size = New System.Drawing.Size(173, 244)
        Me.lstVendedores.TabIndex = 2
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuMarcarTodos, Me.mnuDesmarcarTodos})
        Me.ContextMenuStrip2.Name = "ContextMenuStrip2"
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(167, 48)
        '
        'mnuMarcarTodos
        '
        Me.mnuMarcarTodos.Name = "mnuMarcarTodos"
        Me.mnuMarcarTodos.Size = New System.Drawing.Size(166, 22)
        Me.mnuMarcarTodos.Text = "Marcar todos"
        '
        'mnuDesmarcarTodos
        '
        Me.mnuDesmarcarTodos.Name = "mnuDesmarcarTodos"
        Me.mnuDesmarcarTodos.Size = New System.Drawing.Size(166, 22)
        Me.mnuDesmarcarTodos.Text = "Desmarcar todos"
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToDeleteRows = False
        Me.dgv.AllowUserToResizeRows = False
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colCodigo, Me.colCliente, Me.colLocalidad, Me.colProvincia, Me.colEstado, Me.colVendedor, Me.colTipo})
        Me.dgv.ContextMenuStrip = Me.ContextMenuStrip1
        Me.dgv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv.Location = New System.Drawing.Point(0, 0)
        Me.dgv.Name = "dgv"
        Me.dgv.ReadOnly = True
        Me.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv.Size = New System.Drawing.Size(709, 521)
        Me.dgv.TabIndex = 0
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuUltimaCompra, Me.mnuSaldoCuenta})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(269, 48)
        '
        'mnuUltimaCompra
        '
        Me.mnuUltimaCompra.Name = "mnuUltimaCompra"
        Me.mnuUltimaCompra.Size = New System.Drawing.Size(268, 22)
        Me.mnuUltimaCompra.Text = "Consultar última compra"
        '
        'mnuSaldoCuenta
        '
        Me.mnuSaldoCuenta.Name = "mnuSaldoCuenta"
        Me.mnuSaldoCuenta.Size = New System.Drawing.Size(268, 22)
        Me.mnuSaldoCuenta.Text = "Consultar Saldo de la cuenta corriente"
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
        Me.colCliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colCliente.HeaderText = "Cliente"
        Me.colCliente.Name = "colCliente"
        Me.colCliente.ReadOnly = True
        Me.colCliente.Width = 64
        '
        'colLocalidad
        '
        Me.colLocalidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colLocalidad.HeaderText = "Localidad"
        Me.colLocalidad.Name = "colLocalidad"
        Me.colLocalidad.ReadOnly = True
        Me.colLocalidad.Width = 78
        '
        'colProvincia
        '
        Me.colProvincia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colProvincia.HeaderText = "Provincia"
        Me.colProvincia.Name = "colProvincia"
        Me.colProvincia.ReadOnly = True
        Me.colProvincia.Width = 76
        '
        'colEstado
        '
        Me.colEstado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colEstado.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.colEstado.HeaderText = "Estado"
        Me.colEstado.Name = "colEstado"
        Me.colEstado.ReadOnly = True
        Me.colEstado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colEstado.Width = 65
        '
        'colVendedor
        '
        Me.colVendedor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.colVendedor.HeaderText = "Vendedor"
        Me.colVendedor.Name = "colVendedor"
        Me.colVendedor.ReadOnly = True
        Me.colVendedor.Width = 78
        '
        'colTipo
        '
        Me.colTipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colTipo.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.colTipo.HeaderText = "Tipo"
        Me.colTipo.Name = "colTipo"
        Me.colTipo.ReadOnly = True
        Me.colTipo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colTipo.Width = 53
        '
        'frmDistribuidoresInactivos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(892, 521)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "frmDistribuidoresInactivos"
        Me.Text = "Distribuidores inactivos"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.ContextMenuStrip2.ResumeLayout(False)
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Calendario As System.Windows.Forms.MonthCalendar
    Friend WithEvents btnGenerar As System.Windows.Forms.Button
    Friend WithEvents lstVendedores As System.Windows.Forms.CheckedListBox
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents ContextMenuStrip2 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuMarcarTodos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesmarcarTodos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuUltimaCompra As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSaldoCuenta As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents colCodigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colLocalidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colProvincia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colEstado As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colVendedor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTipo As System.Windows.Forms.DataGridViewComboBoxColumn
End Class
