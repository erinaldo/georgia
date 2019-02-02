<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPresupuestos639
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
        Me.dgv = New System.Windows.Forms.DataGridView
        Me.colPresupuesto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colFecha = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCliente = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colSucursal = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colNombre = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colDomicilio = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colVendedor = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colImporte = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colEstado = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.colDeteccion = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.col639 = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.colTipo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colHidrantes = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cm = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuVerPresupuesto = New System.Windows.Forms.ToolStripMenuItem
        Me.munQuitar = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuQuitar1 = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuQuitar2 = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuQuitar3 = New System.Windows.Forms.ToolStripMenuItem
        Me.btnBuscar = New System.Windows.Forms.Button
        Me.gbPago = New System.Windows.Forms.GroupBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtObs = New System.Windows.Forms.TextBox
        Me.cboCondicionPago = New System.Windows.Forms.ComboBox
        Me.txtDescuento = New System.Windows.Forms.TextBox
        Me.btnAprobar = New System.Windows.Forms.Button
        Me.btnActualizar = New System.Windows.Forms.Button
        Me.txtPrecio = New System.Windows.Forms.TextBox
        Me.rbOpcion2 = New System.Windows.Forms.RadioButton
        Me.rbOpcion1 = New System.Windows.Forms.RadioButton
        Me.rbContado = New System.Windows.Forms.RadioButton
        Label1 = New System.Windows.Forms.Label
        Label2 = New System.Windows.Forms.Label
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cm.SuspendLayout()
        Me.gbPago.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(19, 71)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(77, 13)
        Label1.TabIndex = 3
        Label1.Text = "Cambiar precio"
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Location = New System.Drawing.Point(19, 98)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(59, 13)
        Label2.TabIndex = 7
        Label2.Text = "Descuento"
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToDeleteRows = False
        Me.dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colPresupuesto, Me.colFecha, Me.colCliente, Me.colSucursal, Me.colNombre, Me.colDomicilio, Me.colVendedor, Me.colImporte, Me.colEstado, Me.colDeteccion, Me.col639, Me.colTipo, Me.colHidrantes})
        Me.dgv.ContextMenuStrip = Me.cm
        Me.dgv.Location = New System.Drawing.Point(12, 12)
        Me.dgv.Name = "dgv"
        Me.dgv.ReadOnly = True
        Me.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv.Size = New System.Drawing.Size(887, 372)
        Me.dgv.TabIndex = 0
        '
        'colPresupuesto
        '
        Me.colPresupuesto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colPresupuesto.HeaderText = "Presupuesto"
        Me.colPresupuesto.Name = "colPresupuesto"
        Me.colPresupuesto.ReadOnly = True
        Me.colPresupuesto.Width = 91
        '
        'colFecha
        '
        Me.colFecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colFecha.HeaderText = "Fecha"
        Me.colFecha.Name = "colFecha"
        Me.colFecha.ReadOnly = True
        Me.colFecha.Width = 62
        '
        'colCliente
        '
        Me.colCliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.colCliente.HeaderText = "Cliente"
        Me.colCliente.Name = "colCliente"
        Me.colCliente.ReadOnly = True
        Me.colCliente.Width = 64
        '
        'colSucursal
        '
        Me.colSucursal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.colSucursal.HeaderText = "Sucursal"
        Me.colSucursal.Name = "colSucursal"
        Me.colSucursal.ReadOnly = True
        Me.colSucursal.Width = 73
        '
        'colNombre
        '
        Me.colNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colNombre.HeaderText = "Nombre"
        Me.colNombre.Name = "colNombre"
        Me.colNombre.ReadOnly = True
        Me.colNombre.Width = 69
        '
        'colDomicilio
        '
        Me.colDomicilio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colDomicilio.HeaderText = "Domicilio"
        Me.colDomicilio.Name = "colDomicilio"
        Me.colDomicilio.ReadOnly = True
        Me.colDomicilio.Width = 74
        '
        'colVendedor
        '
        Me.colVendedor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.colVendedor.HeaderText = "Vendedor"
        Me.colVendedor.Name = "colVendedor"
        Me.colVendedor.ReadOnly = True
        Me.colVendedor.Width = 78
        '
        'colImporte
        '
        Me.colImporte.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Format = "N2"
        Me.colImporte.DefaultCellStyle = DataGridViewCellStyle1
        Me.colImporte.HeaderText = "Importe"
        Me.colImporte.Name = "colImporte"
        Me.colImporte.ReadOnly = True
        Me.colImporte.Width = 67
        '
        'colEstado
        '
        Me.colEstado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colEstado.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.colEstado.HeaderText = "Estado"
        Me.colEstado.Name = "colEstado"
        Me.colEstado.ReadOnly = True
        Me.colEstado.Width = 46
        '
        'colDeteccion
        '
        Me.colDeteccion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colDeteccion.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.colDeteccion.HeaderText = "Deteccion"
        Me.colDeteccion.Name = "colDeteccion"
        Me.colDeteccion.ReadOnly = True
        Me.colDeteccion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colDeteccion.Width = 81
        '
        'col639
        '
        Me.col639.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.col639.HeaderText = "639"
        Me.col639.Name = "col639"
        Me.col639.ReadOnly = True
        Me.col639.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.col639.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'colTipo
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colTipo.DefaultCellStyle = DataGridViewCellStyle2
        Me.colTipo.HeaderText = "Tipo"
        Me.colTipo.Name = "colTipo"
        Me.colTipo.ReadOnly = True
        '
        'colHidrantes
        '
        Me.colHidrantes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colHidrantes.DefaultCellStyle = DataGridViewCellStyle3
        Me.colHidrantes.HeaderText = "Hidrantes"
        Me.colHidrantes.Name = "colHidrantes"
        Me.colHidrantes.ReadOnly = True
        Me.colHidrantes.Width = 77
        '
        'cm
        '
        Me.cm.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuVerPresupuesto, Me.munQuitar})
        Me.cm.Name = "cm"
        Me.cm.Size = New System.Drawing.Size(169, 48)
        '
        'mnuVerPresupuesto
        '
        Me.mnuVerPresupuesto.Name = "mnuVerPresupuesto"
        Me.mnuVerPresupuesto.Size = New System.Drawing.Size(168, 22)
        Me.mnuVerPresupuesto.Text = "Ver presupuesto..."
        '
        'munQuitar
        '
        Me.munQuitar.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuQuitar1, Me.mnuQuitar2, Me.mnuQuitar3})
        Me.munQuitar.Name = "munQuitar"
        Me.munQuitar.Size = New System.Drawing.Size(168, 22)
        Me.munQuitar.Text = "Quitar de la lista"
        '
        'mnuQuitar1
        '
        Me.mnuQuitar1.Name = "mnuQuitar1"
        Me.mnuQuitar1.Size = New System.Drawing.Size(210, 22)
        Me.mnuQuitar1.Text = "Acompañar"
        '
        'mnuQuitar2
        '
        Me.mnuQuitar2.Name = "mnuQuitar2"
        Me.mnuQuitar2.Size = New System.Drawing.Size(210, 22)
        Me.mnuQuitar2.Text = "No lo hace"
        '
        'mnuQuitar3
        '
        Me.mnuQuitar3.Name = "mnuQuitar3"
        Me.mnuQuitar3.Size = New System.Drawing.Size(210, 22)
        Me.mnuQuitar3.Text = "Perdido con otra empresa"
        '
        'btnBuscar
        '
        Me.btnBuscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBuscar.Location = New System.Drawing.Point(820, 407)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(75, 23)
        Me.btnBuscar.TabIndex = 1
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'gbPago
        '
        Me.gbPago.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gbPago.Controls.Add(Me.GroupBox1)
        Me.gbPago.Controls.Add(Me.cboCondicionPago)
        Me.gbPago.Controls.Add(Label2)
        Me.gbPago.Controls.Add(Me.txtDescuento)
        Me.gbPago.Controls.Add(Me.btnAprobar)
        Me.gbPago.Controls.Add(Label1)
        Me.gbPago.Controls.Add(Me.btnActualizar)
        Me.gbPago.Controls.Add(Me.txtPrecio)
        Me.gbPago.Controls.Add(Me.rbOpcion2)
        Me.gbPago.Controls.Add(Me.rbOpcion1)
        Me.gbPago.Controls.Add(Me.rbContado)
        Me.gbPago.Enabled = False
        Me.gbPago.Location = New System.Drawing.Point(12, 390)
        Me.gbPago.Name = "gbPago"
        Me.gbPago.Size = New System.Drawing.Size(802, 121)
        Me.gbPago.TabIndex = 2
        Me.gbPago.TabStop = False
        Me.gbPago.Text = "Opciones de pago"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtObs)
        Me.GroupBox1.Location = New System.Drawing.Point(288, 50)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(359, 64)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Observaciones"
        '
        'txtObs
        '
        Me.txtObs.Location = New System.Drawing.Point(6, 18)
        Me.txtObs.Multiline = True
        Me.txtObs.Name = "txtObs"
        Me.txtObs.Size = New System.Drawing.Size(347, 40)
        Me.txtObs.TabIndex = 0
        '
        'cboCondicionPago
        '
        Me.cboCondicionPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCondicionPago.Enabled = False
        Me.cboCondicionPago.FormattingEnabled = True
        Me.cboCondicionPago.Location = New System.Drawing.Point(38, 41)
        Me.cboCondicionPago.Name = "cboCondicionPago"
        Me.cboCondicionPago.Size = New System.Drawing.Size(222, 21)
        Me.cboCondicionPago.TabIndex = 9
        '
        'txtDescuento
        '
        Me.txtDescuento.Location = New System.Drawing.Point(101, 95)
        Me.txtDescuento.Name = "txtDescuento"
        Me.txtDescuento.ReadOnly = True
        Me.txtDescuento.Size = New System.Drawing.Size(58, 20)
        Me.txtDescuento.TabIndex = 8
        Me.txtDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnAprobar
        '
        Me.btnAprobar.Enabled = False
        Me.btnAprobar.Location = New System.Drawing.Point(653, 75)
        Me.btnAprobar.Name = "btnAprobar"
        Me.btnAprobar.Size = New System.Drawing.Size(143, 39)
        Me.btnAprobar.TabIndex = 6
        Me.btnAprobar.Text = "Aprobar"
        Me.btnAprobar.UseVisualStyleBackColor = True
        '
        'btnActualizar
        '
        Me.btnActualizar.Location = New System.Drawing.Point(207, 66)
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(75, 23)
        Me.btnActualizar.TabIndex = 5
        Me.btnActualizar.Text = "Actualizar"
        Me.btnActualizar.UseVisualStyleBackColor = True
        '
        'txtPrecio
        '
        Me.txtPrecio.Location = New System.Drawing.Point(101, 68)
        Me.txtPrecio.Name = "txtPrecio"
        Me.txtPrecio.Size = New System.Drawing.Size(100, 20)
        Me.txtPrecio.TabIndex = 4
        Me.txtPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'rbOpcion2
        '
        Me.rbOpcion2.AutoSize = True
        Me.rbOpcion2.Location = New System.Drawing.Point(518, 19)
        Me.rbOpcion2.Name = "rbOpcion2"
        Me.rbOpcion2.Size = New System.Drawing.Size(68, 17)
        Me.rbOpcion2.TabIndex = 2
        Me.rbOpcion2.TabStop = True
        Me.rbOpcion2.Text = "Opción 2"
        Me.rbOpcion2.UseVisualStyleBackColor = True
        '
        'rbOpcion1
        '
        Me.rbOpcion1.AutoSize = True
        Me.rbOpcion1.Location = New System.Drawing.Point(279, 19)
        Me.rbOpcion1.Name = "rbOpcion1"
        Me.rbOpcion1.Size = New System.Drawing.Size(68, 17)
        Me.rbOpcion1.TabIndex = 1
        Me.rbOpcion1.TabStop = True
        Me.rbOpcion1.Text = "Opcion 1"
        Me.rbOpcion1.UseVisualStyleBackColor = True
        '
        'rbContado
        '
        Me.rbContado.AutoSize = True
        Me.rbContado.Location = New System.Drawing.Point(18, 19)
        Me.rbContado.Name = "rbContado"
        Me.rbContado.Size = New System.Drawing.Size(97, 17)
        Me.rbContado.TabIndex = 0
        Me.rbContado.TabStop = True
        Me.rbContado.Text = "Precio contado"
        Me.rbContado.UseVisualStyleBackColor = True
        '
        'frmPresupuestos639
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(907, 516)
        Me.Controls.Add(Me.gbPago)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.dgv)
        Me.Name = "frmPresupuestos639"
        Me.Text = "Presupuestos 639"
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cm.ResumeLayout(False)
        Me.gbPago.ResumeLayout(False)
        Me.gbPago.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents gbPago As System.Windows.Forms.GroupBox
    Friend WithEvents rbOpcion2 As System.Windows.Forms.RadioButton
    Friend WithEvents rbOpcion1 As System.Windows.Forms.RadioButton
    Friend WithEvents rbContado As System.Windows.Forms.RadioButton
    Friend WithEvents txtPrecio As System.Windows.Forms.TextBox
    Friend WithEvents btnActualizar As System.Windows.Forms.Button
    Friend WithEvents btnAprobar As System.Windows.Forms.Button
    Friend WithEvents txtDescuento As System.Windows.Forms.TextBox
    Friend WithEvents cm As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuVerPresupuesto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cboCondicionPago As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtObs As System.Windows.Forms.TextBox
    Friend WithEvents munQuitar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuQuitar1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuQuitar2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuQuitar3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents colPresupuesto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSucursal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDomicilio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colVendedor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colImporte As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colEstado As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colDeteccion As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents col639 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colTipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colHidrantes As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
