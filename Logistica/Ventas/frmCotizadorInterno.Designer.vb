<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCotizadorInterno
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.BtnNuevaCotizacion = New System.Windows.Forms.Button
        Me.TxtBoxNumeroCotizacion = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtBoxCodigoCliente = New System.Windows.Forms.TextBox
        Me.TxtBoxRep = New System.Windows.Forms.TextBox
        Me.TxtBoxObs = New System.Windows.Forms.TextBox
        Me.Dgv = New System.Windows.Forms.DataGridView
        Me.colNro = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colLinea = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColCodigoArticulo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColDescripcion = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.ColProveedor = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColCantidad = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColPrecioUnitario = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColSugerido = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColPrecioTotal = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dtpFechaCotizacion = New System.Windows.Forms.DateTimePicker
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.DgvLateral = New System.Windows.Forms.DataGridView
        Me.BtnCotizar = New System.Windows.Forms.Button
        Me.cboEstado = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.TxtboxNombreRep = New System.Windows.Forms.TextBox
        Me.TxtBoxCliente = New System.Windows.Forms.TextBox
        Me.BtnRechazar = New System.Windows.Forms.Button
        Me.BtnAprobar = New System.Windows.Forms.Button
        Me.BtnRegistrarCotizacion = New System.Windows.Forms.Button
        Me.TxtBoxCotizador = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.dtpVigenciaPresupuesto = New System.Windows.Forms.DateTimePicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.dtpFechaRespuestaCotizacion = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.mnu2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SeleccionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ColNumero = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColCliente = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColFechaCot = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColFechaRespuesta = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColFechaVigencia = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColEstado = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.ColObs = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColCotizador = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColUsuario = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.Dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.DgvLateral, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.mnu2.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnNuevaCotizacion
        '
        Me.BtnNuevaCotizacion.Location = New System.Drawing.Point(19, 12)
        Me.BtnNuevaCotizacion.Name = "BtnNuevaCotizacion"
        Me.BtnNuevaCotizacion.Size = New System.Drawing.Size(101, 23)
        Me.BtnNuevaCotizacion.TabIndex = 0
        Me.BtnNuevaCotizacion.Text = "Nueva Cotizacion"
        Me.BtnNuevaCotizacion.UseVisualStyleBackColor = True
        '
        'TxtBoxNumeroCotizacion
        '
        Me.TxtBoxNumeroCotizacion.Enabled = False
        Me.TxtBoxNumeroCotizacion.Location = New System.Drawing.Point(81, 45)
        Me.TxtBoxNumeroCotizacion.Name = "TxtBoxNumeroCotizacion"
        Me.TxtBoxNumeroCotizacion.Size = New System.Drawing.Size(65, 20)
        Me.TxtBoxNumeroCotizacion.TabIndex = 1
        Me.TxtBoxNumeroCotizacion.Text = "0"
        Me.TxtBoxNumeroCotizacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(25, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Numero :"
        '
        'TxtBoxCodigoCliente
        '
        Me.TxtBoxCodigoCliente.Enabled = False
        Me.TxtBoxCodigoCliente.Location = New System.Drawing.Point(81, 71)
        Me.TxtBoxCodigoCliente.Name = "TxtBoxCodigoCliente"
        Me.TxtBoxCodigoCliente.Size = New System.Drawing.Size(50, 20)
        Me.TxtBoxCodigoCliente.TabIndex = 3
        '
        'TxtBoxRep
        '
        Me.TxtBoxRep.Enabled = False
        Me.TxtBoxRep.Location = New System.Drawing.Point(81, 96)
        Me.TxtBoxRep.Name = "TxtBoxRep"
        Me.TxtBoxRep.Size = New System.Drawing.Size(22, 20)
        Me.TxtBoxRep.TabIndex = 4
        '
        'TxtBoxObs
        '
        Me.TxtBoxObs.Location = New System.Drawing.Point(6, 19)
        Me.TxtBoxObs.Multiline = True
        Me.TxtBoxObs.Name = "TxtBoxObs"
        Me.TxtBoxObs.Size = New System.Drawing.Size(491, 41)
        Me.TxtBoxObs.TabIndex = 6
        '
        'Dgv
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Dgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colNro, Me.colLinea, Me.ColCodigoArticulo, Me.ColDescripcion, Me.ColProveedor, Me.ColCantidad, Me.ColPrecioUnitario, Me.ColSugerido, Me.ColPrecioTotal})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Dgv.DefaultCellStyle = DataGridViewCellStyle2
        Me.Dgv.Enabled = False
        Me.Dgv.Location = New System.Drawing.Point(19, 157)
        Me.Dgv.Name = "Dgv"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Dgv.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Dgv.RowHeadersVisible = False
        Me.Dgv.Size = New System.Drawing.Size(503, 115)
        Me.Dgv.TabIndex = 7
        '
        'colNro
        '
        Me.colNro.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.colNro.Frozen = True
        Me.colNro.HeaderText = "Nro"
        Me.colNro.Name = "colNro"
        Me.colNro.ReadOnly = True
        Me.colNro.Visible = False
        '
        'colLinea
        '
        Me.colLinea.Frozen = True
        Me.colLinea.HeaderText = "Linea"
        Me.colLinea.Name = "colLinea"
        Me.colLinea.Visible = False
        '
        'ColCodigoArticulo
        '
        Me.ColCodigoArticulo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.ColCodigoArticulo.HeaderText = "Articulo"
        Me.ColCodigoArticulo.Name = "ColCodigoArticulo"
        Me.ColCodigoArticulo.Width = 67
        '
        'ColDescripcion
        '
        Me.ColDescripcion.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.ColDescripcion.HeaderText = "Descripcion"
        Me.ColDescripcion.Name = "ColDescripcion"
        Me.ColDescripcion.ReadOnly = True
        Me.ColDescripcion.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ColDescripcion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'ColProveedor
        '
        Me.ColProveedor.HeaderText = "Proveedor"
        Me.ColProveedor.Name = "ColProveedor"
        '
        'ColCantidad
        '
        Me.ColCantidad.HeaderText = "Cantidad"
        Me.ColCantidad.Name = "ColCantidad"
        Me.ColCantidad.Width = 60
        '
        'ColPrecioUnitario
        '
        Me.ColPrecioUnitario.HeaderText = "P. Unit"
        Me.ColPrecioUnitario.Name = "ColPrecioUnitario"
        Me.ColPrecioUnitario.Width = 50
        '
        'ColSugerido
        '
        Me.ColSugerido.HeaderText = "Sugerido"
        Me.ColSugerido.Name = "ColSugerido"
        Me.ColSugerido.Width = 50
        '
        'ColPrecioTotal
        '
        Me.ColPrecioTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.ColPrecioTotal.HeaderText = "Precio Total"
        Me.ColPrecioTotal.Name = "ColPrecioTotal"
        Me.ColPrecioTotal.Width = 89
        '
        'dtpFechaCotizacion
        '
        Me.dtpFechaCotizacion.Enabled = False
        Me.dtpFechaCotizacion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaCotizacion.Location = New System.Drawing.Point(430, 45)
        Me.dtpFechaCotizacion.Name = "dtpFechaCotizacion"
        Me.dtpFechaCotizacion.Size = New System.Drawing.Size(86, 20)
        Me.dtpFechaCotizacion.TabIndex = 8
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.DgvLateral)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.BtnCotizar)
        Me.SplitContainer1.Panel2.Controls.Add(Me.cboEstado)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label7)
        Me.SplitContainer1.Panel2.Controls.Add(Me.TxtboxNombreRep)
        Me.SplitContainer1.Panel2.Controls.Add(Me.TxtBoxCliente)
        Me.SplitContainer1.Panel2.Controls.Add(Me.BtnRechazar)
        Me.SplitContainer1.Panel2.Controls.Add(Me.BtnAprobar)
        Me.SplitContainer1.Panel2.Controls.Add(Me.BtnRegistrarCotizacion)
        Me.SplitContainer1.Panel2.Controls.Add(Me.TxtBoxCotizador)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label8)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label6)
        Me.SplitContainer1.Panel2.Controls.Add(Me.dtpVigenciaPresupuesto)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label5)
        Me.SplitContainer1.Panel2.Controls.Add(Me.dtpFechaRespuestaCotizacion)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label4)
        Me.SplitContainer1.Panel2.Controls.Add(Me.GroupBox1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label3)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Dgv)
        Me.SplitContainer1.Panel2.Controls.Add(Me.dtpFechaCotizacion)
        Me.SplitContainer1.Panel2.Controls.Add(Me.TxtBoxCodigoCliente)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.TxtBoxRep)
        Me.SplitContainer1.Panel2.Controls.Add(Me.TxtBoxNumeroCotizacion)
        Me.SplitContainer1.Panel2.Controls.Add(Me.BtnNuevaCotizacion)
        Me.SplitContainer1.Size = New System.Drawing.Size(807, 397)
        Me.SplitContainer1.SplitterDistance = 269
        Me.SplitContainer1.TabIndex = 9
        '
        'DgvLateral
        '
        Me.DgvLateral.AllowUserToAddRows = False
        Me.DgvLateral.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.DgvLateral.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DgvLateral.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvLateral.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColNumero, Me.ColCliente, Me.ColFechaCot, Me.ColFechaRespuesta, Me.ColFechaVigencia, Me.ColEstado, Me.ColObs, Me.ColCotizador, Me.ColUsuario})
        Me.DgvLateral.Location = New System.Drawing.Point(12, 28)
        Me.DgvLateral.MultiSelect = False
        Me.DgvLateral.Name = "DgvLateral"
        Me.DgvLateral.ReadOnly = True
        Me.DgvLateral.RowHeadersVisible = False
        Me.DgvLateral.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DgvLateral.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvLateral.ShowEditingIcon = False
        Me.DgvLateral.Size = New System.Drawing.Size(240, 316)
        Me.DgvLateral.TabIndex = 0
        '
        'BtnCotizar
        '
        Me.BtnCotizar.Enabled = False
        Me.BtnCotizar.Location = New System.Drawing.Point(360, 350)
        Me.BtnCotizar.Name = "BtnCotizar"
        Me.BtnCotizar.Size = New System.Drawing.Size(75, 23)
        Me.BtnCotizar.TabIndex = 28
        Me.BtnCotizar.Text = "Cotizar"
        Me.BtnCotizar.UseVisualStyleBackColor = True
        '
        'cboEstado
        '
        Me.cboEstado.Enabled = False
        Me.cboEstado.FormattingEnabled = True
        Me.cboEstado.Location = New System.Drawing.Point(330, 122)
        Me.cboEstado.Name = "cboEstado"
        Me.cboEstado.Size = New System.Drawing.Size(121, 21)
        Me.cboEstado.TabIndex = 27
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(281, 126)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 13)
        Me.Label7.TabIndex = 26
        Me.Label7.Text = "Estado:"
        '
        'TxtboxNombreRep
        '
        Me.TxtboxNombreRep.Enabled = False
        Me.TxtboxNombreRep.Location = New System.Drawing.Point(109, 97)
        Me.TxtboxNombreRep.Name = "TxtboxNombreRep"
        Me.TxtboxNombreRep.Size = New System.Drawing.Size(162, 20)
        Me.TxtboxNombreRep.TabIndex = 24
        '
        'TxtBoxCliente
        '
        Me.TxtBoxCliente.Enabled = False
        Me.TxtBoxCliente.Location = New System.Drawing.Point(137, 71)
        Me.TxtBoxCliente.Name = "TxtBoxCliente"
        Me.TxtBoxCliente.Size = New System.Drawing.Size(134, 20)
        Me.TxtBoxCliente.TabIndex = 23
        '
        'BtnRechazar
        '
        Me.BtnRechazar.Enabled = False
        Me.BtnRechazar.Location = New System.Drawing.Point(106, 350)
        Me.BtnRechazar.Name = "BtnRechazar"
        Me.BtnRechazar.Size = New System.Drawing.Size(75, 23)
        Me.BtnRechazar.TabIndex = 22
        Me.BtnRechazar.Text = "Rechazar"
        Me.BtnRechazar.UseVisualStyleBackColor = True
        '
        'BtnAprobar
        '
        Me.BtnAprobar.Enabled = False
        Me.BtnAprobar.Location = New System.Drawing.Point(28, 350)
        Me.BtnAprobar.Name = "BtnAprobar"
        Me.BtnAprobar.Size = New System.Drawing.Size(75, 23)
        Me.BtnAprobar.TabIndex = 21
        Me.BtnAprobar.Text = "Aprobar"
        Me.BtnAprobar.UseVisualStyleBackColor = True
        '
        'BtnRegistrarCotizacion
        '
        Me.BtnRegistrarCotizacion.Enabled = False
        Me.BtnRegistrarCotizacion.Location = New System.Drawing.Point(441, 350)
        Me.BtnRegistrarCotizacion.Name = "BtnRegistrarCotizacion"
        Me.BtnRegistrarCotizacion.Size = New System.Drawing.Size(75, 23)
        Me.BtnRegistrarCotizacion.TabIndex = 20
        Me.BtnRegistrarCotizacion.Text = "Registrar"
        Me.BtnRegistrarCotizacion.UseVisualStyleBackColor = True
        '
        'TxtBoxCotizador
        '
        Me.TxtBoxCotizador.Enabled = False
        Me.TxtBoxCotizador.Location = New System.Drawing.Point(81, 123)
        Me.TxtBoxCotizador.Name = "TxtBoxCotizador"
        Me.TxtBoxCotizador.Size = New System.Drawing.Size(100, 20)
        Me.TxtBoxCotizador.TabIndex = 19
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(25, 126)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(51, 13)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "Cotizador"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(281, 96)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(110, 13)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Vigencia Presupuesto"
        '
        'dtpVigenciaPresupuesto
        '
        Me.dtpVigenciaPresupuesto.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpVigenciaPresupuesto.Location = New System.Drawing.Point(430, 90)
        Me.dtpVigenciaPresupuesto.Name = "dtpVigenciaPresupuesto"
        Me.dtpVigenciaPresupuesto.Size = New System.Drawing.Size(86, 20)
        Me.dtpVigenciaPresupuesto.TabIndex = 15
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(281, 71)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(143, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Fecha Respuesta Cotizacion"
        '
        'dtpFechaRespuestaCotizacion
        '
        Me.dtpFechaRespuestaCotizacion.Enabled = False
        Me.dtpFechaRespuestaCotizacion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaRespuestaCotizacion.Location = New System.Drawing.Point(430, 68)
        Me.dtpFechaRespuestaCotizacion.Name = "dtpFechaRespuestaCotizacion"
        Me.dtpFechaRespuestaCotizacion.Size = New System.Drawing.Size(86, 20)
        Me.dtpFechaRespuestaCotizacion.TabIndex = 13
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(281, 45)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Fecha Cotizacion"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TxtBoxObs)
        Me.GroupBox1.Location = New System.Drawing.Point(19, 278)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(503, 66)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Observaciones"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(25, 99)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Vendedor:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(25, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Cliente :"
        '
        'mnu2
        '
        Me.mnu2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SeleccionToolStripMenuItem})
        Me.mnu2.Name = "cms1"
        Me.mnu2.Size = New System.Drawing.Size(134, 26)
        '
        'SeleccionToolStripMenuItem
        '
        Me.SeleccionToolStripMenuItem.Name = "SeleccionToolStripMenuItem"
        Me.SeleccionToolStripMenuItem.Size = New System.Drawing.Size(133, 22)
        Me.SeleccionToolStripMenuItem.Text = "Seleccion..."
        '
        'ColNumero
        '
        Me.ColNumero.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.ColNumero.HeaderText = "Numero"
        Me.ColNumero.Name = "ColNumero"
        Me.ColNumero.ReadOnly = True
        Me.ColNumero.Width = 69
        '
        'ColCliente
        '
        Me.ColCliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.ColCliente.HeaderText = "Cliente"
        Me.ColCliente.Name = "ColCliente"
        Me.ColCliente.ReadOnly = True
        Me.ColCliente.Width = 64
        '
        'ColFechaCot
        '
        Me.ColFechaCot.HeaderText = "fecha cotizacion"
        Me.ColFechaCot.Name = "ColFechaCot"
        Me.ColFechaCot.ReadOnly = True
        Me.ColFechaCot.Visible = False
        Me.ColFechaCot.Width = 110
        '
        'ColFechaRespuesta
        '
        Me.ColFechaRespuesta.HeaderText = "Fecha Respuesta"
        Me.ColFechaRespuesta.Name = "ColFechaRespuesta"
        Me.ColFechaRespuesta.ReadOnly = True
        Me.ColFechaRespuesta.Visible = False
        Me.ColFechaRespuesta.Width = 116
        '
        'ColFechaVigencia
        '
        Me.ColFechaVigencia.HeaderText = "Fecha Vigencia"
        Me.ColFechaVigencia.Name = "ColFechaVigencia"
        Me.ColFechaVigencia.ReadOnly = True
        Me.ColFechaVigencia.Visible = False
        Me.ColFechaVigencia.Width = 106
        '
        'ColEstado
        '
        Me.ColEstado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ColEstado.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.ColEstado.HeaderText = "Estado"
        Me.ColEstado.Name = "ColEstado"
        Me.ColEstado.ReadOnly = True
        Me.ColEstado.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ColEstado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'ColObs
        '
        Me.ColObs.HeaderText = "obs"
        Me.ColObs.Name = "ColObs"
        Me.ColObs.ReadOnly = True
        Me.ColObs.Visible = False
        Me.ColObs.Width = 49
        '
        'ColCotizador
        '
        Me.ColCotizador.HeaderText = "Cotizador"
        Me.ColCotizador.Name = "ColCotizador"
        Me.ColCotizador.ReadOnly = True
        Me.ColCotizador.Visible = False
        Me.ColCotizador.Width = 76
        '
        'ColUsuario
        '
        Me.ColUsuario.HeaderText = "Usuario"
        Me.ColUsuario.Name = "ColUsuario"
        Me.ColUsuario.ReadOnly = True
        Me.ColUsuario.Visible = False
        Me.ColUsuario.Width = 68
        '
        'frmCotizadorInterno
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(807, 397)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "frmCotizadorInterno"
        Me.Text = "frmCotizadorInterno"
        CType(Me.Dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.DgvLateral, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.mnu2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtnNuevaCotizacion As System.Windows.Forms.Button
    Friend WithEvents TxtBoxNumeroCotizacion As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtBoxCodigoCliente As System.Windows.Forms.TextBox
    Friend WithEvents TxtBoxRep As System.Windows.Forms.TextBox
    Friend WithEvents TxtBoxObs As System.Windows.Forms.TextBox
    Friend WithEvents Dgv As System.Windows.Forms.DataGridView
    Friend WithEvents dtpFechaCotizacion As System.Windows.Forms.DateTimePicker
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents DgvLateral As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtpVigenciaPresupuesto As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaRespuestaCotizacion As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtBoxCotizador As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents BtnRegistrarCotizacion As System.Windows.Forms.Button
    Friend WithEvents BtnRechazar As System.Windows.Forms.Button
    Friend WithEvents BtnAprobar As System.Windows.Forms.Button
    Friend WithEvents TxtBoxCliente As System.Windows.Forms.TextBox
    Friend WithEvents TxtboxNombreRep As System.Windows.Forms.TextBox
    Friend WithEvents mnu2 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents SeleccionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboEstado As System.Windows.Forms.ComboBox
    Friend WithEvents BtnCotizar As System.Windows.Forms.Button
    Friend WithEvents colNro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colLinea As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColCodigoArticulo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColDescripcion As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents ColProveedor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColCantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColPrecioUnitario As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColSugerido As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColPrecioTotal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColNumero As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColCliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColFechaCot As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColFechaRespuesta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColFechaVigencia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColEstado As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents ColObs As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColCotizador As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColUsuario As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
