<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmfacturas2
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
        Dim Label2 As System.Windows.Forms.Label
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.cmdBuscar1 = New System.Windows.Forms.Button
        Me.MonthCalendar1 = New System.Windows.Forms.MonthCalendar
        Me.cmdBuscar2 = New System.Windows.Forms.Button
        Me.txtCliente = New System.Windows.Forms.TextBox
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.cmdEnviar = New System.Windows.Forms.Button
        Me.cmdGuardar = New System.Windows.Forms.Button
        Me.dgv = New System.Windows.Forms.DataGridView
        Me.colFecha = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCodigo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colTercero = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colImporte = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colOrigen = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.colNumeroOrigen = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colPte = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colMail1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colMail2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Label1 = New System.Windows.Forms.Label
        Label2 = New System.Windows.Forms.Label
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(8, 68)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(161, 13)
        Label1.TabIndex = 2
        Label1.Text = "Búsqueda por Código de cliente:"
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Location = New System.Drawing.Point(8, 161)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(148, 13)
        Label2.TabIndex = 3
        Label2.Text = "Búsqueda por Fecha Factura:"
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.TabControl1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.ProgressBar1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.cmdEnviar)
        Me.SplitContainer1.Panel2.Controls.Add(Me.cmdGuardar)
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgv)
        Me.SplitContainer1.Size = New System.Drawing.Size(819, 492)
        Me.SplitContainer1.SplitterDistance = 253
        Me.SplitContainer1.TabIndex = 0
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(253, 492)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.CheckBox1)
        Me.TabPage1.Controls.Add(Me.cmdBuscar1)
        Me.TabPage1.Controls.Add(Me.MonthCalendar1)
        Me.TabPage1.Controls.Add(Me.cmdBuscar2)
        Me.TabPage1.Controls.Add(Label2)
        Me.TabPage1.Controls.Add(Label1)
        Me.TabPage1.Controls.Add(Me.txtCliente)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(245, 466)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Buscador"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(8, 18)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(173, 17)
        Me.CheckBox1.TabIndex = 7
        Me.CheckBox1.Text = "Contado c/entrega (001 a 027)"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'cmdBuscar1
        '
        Me.cmdBuscar1.Location = New System.Drawing.Point(81, 110)
        Me.cmdBuscar1.Name = "cmdBuscar1"
        Me.cmdBuscar1.Size = New System.Drawing.Size(75, 23)
        Me.cmdBuscar1.TabIndex = 6
        Me.cmdBuscar1.Text = "Buscar"
        Me.cmdBuscar1.UseVisualStyleBackColor = True
        '
        'MonthCalendar1
        '
        Me.MonthCalendar1.Location = New System.Drawing.Point(6, 183)
        Me.MonthCalendar1.Name = "MonthCalendar1"
        Me.MonthCalendar1.TabIndex = 5
        '
        'cmdBuscar2
        '
        Me.cmdBuscar2.Location = New System.Drawing.Point(81, 357)
        Me.cmdBuscar2.Name = "cmdBuscar2"
        Me.cmdBuscar2.Size = New System.Drawing.Size(75, 23)
        Me.cmdBuscar2.TabIndex = 2
        Me.cmdBuscar2.Text = "Buscar"
        Me.cmdBuscar2.UseVisualStyleBackColor = True
        '
        'txtCliente
        '
        Me.txtCliente.Location = New System.Drawing.Point(8, 84)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(225, 20)
        Me.txtCliente.TabIndex = 1
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProgressBar1.Location = New System.Drawing.Point(14, 423)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(536, 23)
        Me.ProgressBar1.TabIndex = 4
        '
        'cmdEnviar
        '
        Me.cmdEnviar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdEnviar.Location = New System.Drawing.Point(475, 457)
        Me.cmdEnviar.Name = "cmdEnviar"
        Me.cmdEnviar.Size = New System.Drawing.Size(75, 23)
        Me.cmdEnviar.TabIndex = 3
        Me.cmdEnviar.Text = "Enviar Mail"
        Me.cmdEnviar.UseVisualStyleBackColor = True
        '
        'cmdGuardar
        '
        Me.cmdGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdGuardar.Location = New System.Drawing.Point(394, 457)
        Me.cmdGuardar.Name = "cmdGuardar"
        Me.cmdGuardar.Size = New System.Drawing.Size(75, 23)
        Me.cmdGuardar.TabIndex = 2
        Me.cmdGuardar.Text = "Guardar"
        Me.cmdGuardar.UseVisualStyleBackColor = True
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToDeleteRows = False
        Me.dgv.AllowUserToResizeRows = False
        Me.dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colFecha, Me.colComprobante, Me.colCodigo, Me.colTercero, Me.colImporte, Me.colOrigen, Me.colNumeroOrigen, Me.colPte, Me.colMail1, Me.colMail2})
        Me.dgv.Location = New System.Drawing.Point(14, 22)
        Me.dgv.Name = "dgv"
        Me.dgv.ReadOnly = True
        Me.dgv.Size = New System.Drawing.Size(536, 395)
        Me.dgv.TabIndex = 1
        '
        'colFecha
        '
        Me.colFecha.HeaderText = "Fecha"
        Me.colFecha.Name = "colFecha"
        Me.colFecha.ReadOnly = True
        Me.colFecha.Width = 62
        '
        'colComprobante
        '
        Me.colComprobante.HeaderText = "Comprobante"
        Me.colComprobante.Name = "colComprobante"
        Me.colComprobante.ReadOnly = True
        Me.colComprobante.Width = 95
        '
        'colCodigo
        '
        Me.colCodigo.HeaderText = "Código"
        Me.colCodigo.Name = "colCodigo"
        Me.colCodigo.ReadOnly = True
        Me.colCodigo.Width = 65
        '
        'colTercero
        '
        Me.colTercero.HeaderText = "Cliente"
        Me.colTercero.Name = "colTercero"
        Me.colTercero.ReadOnly = True
        Me.colTercero.Width = 64
        '
        'colImporte
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Format = "N2"
        Me.colImporte.DefaultCellStyle = DataGridViewCellStyle1
        Me.colImporte.HeaderText = "Importe"
        Me.colImporte.Name = "colImporte"
        Me.colImporte.ReadOnly = True
        Me.colImporte.Width = 67
        '
        'colOrigen
        '
        Me.colOrigen.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.colOrigen.HeaderText = "Origen"
        Me.colOrigen.Name = "colOrigen"
        Me.colOrigen.ReadOnly = True
        Me.colOrigen.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colOrigen.Width = 63
        '
        'colNumeroOrigen
        '
        Me.colNumeroOrigen.HeaderText = "Documento Origen"
        Me.colNumeroOrigen.Name = "colNumeroOrigen"
        Me.colNumeroOrigen.ReadOnly = True
        Me.colNumeroOrigen.Width = 111
        '
        'colPte
        '
        Me.colPte.HeaderText = "CondiPago"
        Me.colPte.Name = "colPte"
        Me.colPte.ReadOnly = True
        Me.colPte.Width = 84
        '
        'colMail1
        '
        Me.colMail1.HeaderText = "Mail 1"
        Me.colMail1.Name = "colMail1"
        Me.colMail1.ReadOnly = True
        Me.colMail1.Visible = False
        Me.colMail1.Width = 51
        '
        'colMail2
        '
        Me.colMail2.HeaderText = "Mail 2"
        Me.colMail2.Name = "colMail2"
        Me.colMail2.ReadOnly = True
        Me.colMail2.Visible = False
        Me.colMail2.Width = 51
        '
        'frmFacturas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(819, 492)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "frmFacturas"
        Me.Tag = "frmFacElec"
        Me.Text = "Facturas Electrónicas"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents MonthCalendar1 As System.Windows.Forms.MonthCalendar
    Friend WithEvents cmdBuscar2 As System.Windows.Forms.Button
    Friend WithEvents cmdGuardar As System.Windows.Forms.Button
    Friend WithEvents cmdEnviar As System.Windows.Forms.Button
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents cmdBuscar1 As System.Windows.Forms.Button
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents colFecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colComprobante As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCodigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTercero As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colImporte As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOrigen As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colNumeroOrigen As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPte As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMail1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMail2 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
