<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSaldos
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.btnEnviar = New System.Windows.Forms.Button
        Me.cboTipos = New System.Windows.Forms.ComboBox
        Me.btnSaldos = New System.Windows.Forms.Button
        Me.dgvSaldos = New System.Windows.Forms.DataGridView
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuSaldos = New System.Windows.Forms.ToolStripMenuItem
        Me.dgvDetalle = New System.Windows.Forms.DataGridView
        Me.colTipo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colFecha = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCodigo2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colConsorcio = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colMonto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colAplicado = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colDeuda = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCodigo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colAdministracion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colSaldo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colRep = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colMail = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colMail2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.dgvSaldos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.ProgressBar1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnEnviar)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cboTipos)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnSaldos)
        Me.SplitContainer1.Panel1.Controls.Add(Me.dgvSaldos)
        Me.SplitContainer1.Panel1MinSize = 400
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgvDetalle)
        Me.SplitContainer1.Size = New System.Drawing.Size(1034, 585)
        Me.SplitContainer1.SplitterDistance = 400
        Me.SplitContainer1.TabIndex = 0
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProgressBar1.Location = New System.Drawing.Point(3, 549)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(311, 23)
        Me.ProgressBar1.TabIndex = 1
        Me.ProgressBar1.Visible = False
        '
        'btnEnviar
        '
        Me.btnEnviar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEnviar.Location = New System.Drawing.Point(320, 549)
        Me.btnEnviar.Name = "btnEnviar"
        Me.btnEnviar.Size = New System.Drawing.Size(75, 23)
        Me.btnEnviar.TabIndex = 2
        Me.btnEnviar.Text = "Enviar Mail"
        Me.btnEnviar.UseVisualStyleBackColor = True
        '
        'cboTipos
        '
        Me.cboTipos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboTipos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipos.FormattingEnabled = True
        Me.cboTipos.Location = New System.Drawing.Point(3, 8)
        Me.cboTipos.MaxDropDownItems = 10
        Me.cboTipos.Name = "cboTipos"
        Me.cboTipos.Size = New System.Drawing.Size(311, 21)
        Me.cboTipos.TabIndex = 2
        '
        'btnSaldos
        '
        Me.btnSaldos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSaldos.Location = New System.Drawing.Point(320, 8)
        Me.btnSaldos.Name = "btnSaldos"
        Me.btnSaldos.Size = New System.Drawing.Size(75, 23)
        Me.btnSaldos.TabIndex = 1
        Me.btnSaldos.Text = "Ver saldos"
        Me.btnSaldos.UseVisualStyleBackColor = True
        '
        'dgvSaldos
        '
        Me.dgvSaldos.AllowUserToAddRows = False
        Me.dgvSaldos.AllowUserToDeleteRows = False
        Me.dgvSaldos.AllowUserToResizeRows = False
        Me.dgvSaldos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvSaldos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSaldos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colCodigo, Me.colAdministracion, Me.colSaldo, Me.colRep, Me.colMail, Me.colMail2})
        Me.dgvSaldos.ContextMenuStrip = Me.ContextMenuStrip1
        Me.dgvSaldos.Location = New System.Drawing.Point(0, 37)
        Me.dgvSaldos.Name = "dgvSaldos"
        Me.dgvSaldos.ReadOnly = True
        Me.dgvSaldos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSaldos.Size = New System.Drawing.Size(395, 506)
        Me.dgvSaldos.TabIndex = 0
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSaldos})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(136, 26)
        '
        'mnuSaldos
        '
        Me.mnuSaldos.Name = "mnuSaldos"
        Me.mnuSaldos.Size = New System.Drawing.Size(135, 22)
        Me.mnuSaldos.Text = "Ver saldos..."
        '
        'dgvDetalle
        '
        Me.dgvDetalle.AllowUserToAddRows = False
        Me.dgvDetalle.AllowUserToDeleteRows = False
        Me.dgvDetalle.AllowUserToResizeRows = False
        Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colTipo, Me.colComprobante, Me.colFecha, Me.colCodigo2, Me.colConsorcio, Me.colMonto, Me.colAplicado, Me.colDeuda})
        Me.dgvDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDetalle.Location = New System.Drawing.Point(0, 0)
        Me.dgvDetalle.Name = "dgvDetalle"
        Me.dgvDetalle.ReadOnly = True
        Me.dgvDetalle.Size = New System.Drawing.Size(628, 583)
        Me.dgvDetalle.TabIndex = 0
        '
        'colTipo
        '
        Me.colTipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colTipo.HeaderText = "Tipo"
        Me.colTipo.Name = "colTipo"
        Me.colTipo.ReadOnly = True
        Me.colTipo.Width = 53
        '
        'colComprobante
        '
        Me.colComprobante.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colComprobante.HeaderText = "Comprobante"
        Me.colComprobante.Name = "colComprobante"
        Me.colComprobante.ReadOnly = True
        Me.colComprobante.Width = 95
        '
        'colFecha
        '
        Me.colFecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colFecha.HeaderText = "Fecha"
        Me.colFecha.Name = "colFecha"
        Me.colFecha.ReadOnly = True
        Me.colFecha.Width = 62
        '
        'colCodigo2
        '
        Me.colCodigo2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colCodigo2.HeaderText = "Codigo"
        Me.colCodigo2.Name = "colCodigo2"
        Me.colCodigo2.ReadOnly = True
        Me.colCodigo2.Width = 65
        '
        'colConsorcio
        '
        Me.colConsorcio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colConsorcio.HeaderText = "Tercero facturado"
        Me.colConsorcio.Name = "colConsorcio"
        Me.colConsorcio.ReadOnly = True
        '
        'colMonto
        '
        Me.colMonto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N2"
        Me.colMonto.DefaultCellStyle = DataGridViewCellStyle3
        Me.colMonto.HeaderText = "Monto"
        Me.colMonto.Name = "colMonto"
        Me.colMonto.ReadOnly = True
        Me.colMonto.Width = 62
        '
        'colAplicado
        '
        Me.colAplicado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N2"
        Me.colAplicado.DefaultCellStyle = DataGridViewCellStyle4
        Me.colAplicado.HeaderText = "Aplicado"
        Me.colAplicado.Name = "colAplicado"
        Me.colAplicado.ReadOnly = True
        Me.colAplicado.Width = 73
        '
        'colDeuda
        '
        Me.colDeuda.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N2"
        Me.colDeuda.DefaultCellStyle = DataGridViewCellStyle5
        Me.colDeuda.HeaderText = "Saldo"
        Me.colDeuda.Name = "colDeuda"
        Me.colDeuda.ReadOnly = True
        Me.colDeuda.Width = 59
        '
        'colCodigo
        '
        Me.colCodigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colCodigo.HeaderText = "Codigo"
        Me.colCodigo.Name = "colCodigo"
        Me.colCodigo.ReadOnly = True
        Me.colCodigo.Width = 65
        '
        'colAdministracion
        '
        Me.colAdministracion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colAdministracion.HeaderText = "Pagador"
        Me.colAdministracion.Name = "colAdministracion"
        Me.colAdministracion.ReadOnly = True
        '
        'colSaldo
        '
        Me.colSaldo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Format = "N2"
        Me.colSaldo.DefaultCellStyle = DataGridViewCellStyle1
        Me.colSaldo.HeaderText = "Saldo"
        Me.colSaldo.Name = "colSaldo"
        Me.colSaldo.ReadOnly = True
        Me.colSaldo.Width = 59
        '
        'colRep
        '
        Me.colRep.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colRep.DefaultCellStyle = DataGridViewCellStyle2
        Me.colRep.HeaderText = "Vend"
        Me.colRep.Name = "colRep"
        Me.colRep.ReadOnly = True
        Me.colRep.Width = 57
        '
        'colMail
        '
        Me.colMail.HeaderText = "Mail"
        Me.colMail.Name = "colMail"
        Me.colMail.ReadOnly = True
        Me.colMail.Visible = False
        '
        'colMail2
        '
        Me.colMail2.HeaderText = "Mail2"
        Me.colMail2.Name = "colMail2"
        Me.colMail2.ReadOnly = True
        Me.colMail2.Visible = False
        '
        'frmSaldos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1034, 585)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "frmSaldos"
        Me.Text = "Saldos de Cuentas Corrientes"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.dgvSaldos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents btnSaldos As System.Windows.Forms.Button
    Friend WithEvents dgvSaldos As System.Windows.Forms.DataGridView
    Friend WithEvents dgvDetalle As System.Windows.Forms.DataGridView
    Friend WithEvents btnEnviar As System.Windows.Forms.Button
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuSaldos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents cboTipos As System.Windows.Forms.ComboBox
    Friend WithEvents colTipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colComprobante As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCodigo2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsorcio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMonto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAplicado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDeuda As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCodigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAdministracion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSaldo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRep As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMail As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMail2 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
