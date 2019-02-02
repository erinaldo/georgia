<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmIntervencion
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
        Dim Label14 As System.Windows.Forms.Label
        Dim Label3 As System.Windows.Forms.Label
        Dim Label2 As System.Windows.Forms.Label
        Dim Label4 As System.Windows.Forms.Label
        Dim Label21 As System.Windows.Forms.Label
        Dim Label13 As System.Windows.Forms.Label
        Dim Label1 As System.Windows.Forms.Label
        Dim Label18 As System.Windows.Forms.Label
        Dim Label17 As System.Windows.Forms.Label
        Dim Label22 As System.Windows.Forms.Label
        Dim Label11 As System.Windows.Forms.Label
        Dim Label12 As System.Windows.Forms.Label
        Dim Label23 As System.Windows.Forms.Label
        Dim Label16 As System.Windows.Forms.Label
        Dim Label5 As System.Windows.Forms.Label
        Dim Label15 As System.Windows.Forms.Label
        Dim Label6 As System.Windows.Forms.Label
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim ListViewGroup1 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Solicitud de Servicio Abiertas", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup2 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Intervenciones Abiertas", System.Windows.Forms.HorizontalAlignment.Left)
        Me.btnCrear = New System.Windows.Forms.Button
        Me.dgvRetiros = New System.Windows.Forms.DataGridView
        Me.colNumlig = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colNum = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colItmref = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colDescripcion = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.colQty = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colUom = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colTqty = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colTuom = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colYqty2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colFactura = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.colTypLig = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colAmt = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colSre = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.txtNombreFantasia = New System.Windows.Forms.TextBox
        Me.txtSucursal = New System.Windows.Forms.TextBox
        Me.mnu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuSeleccion = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuEditar = New System.Windows.Forms.ToolStripMenuItem
        Me.txtCodigoCliente = New System.Windows.Forms.TextBox
        Me.txtDireccion = New System.Windows.Forms.TextBox
        Me.txtNombreCliente = New System.Windows.Forms.TextBox
        Me.cboSociedad = New System.Windows.Forms.ComboBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cboCondicionPago = New System.Windows.Forms.ComboBox
        Me.txtMailSucursal = New System.Windows.Forms.TextBox
        Me.txtTelefonoSucursal = New System.Windows.Forms.TextBox
        Me.lvDocumentos = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader4 = New System.Windows.Forms.ColumnHeader
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtPortero = New System.Windows.Forms.TextBox
        Me.txtPorteroCelu = New System.Windows.Forms.TextBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.chkH = New System.Windows.Forms.CheckBox
        Me.btnVerOC = New System.Windows.Forms.Button
        Me.btnExaminar = New System.Windows.Forms.Button
        Me.btnBorrarOC = New System.Windows.Forms.Button
        Me.txtOC = New System.Windows.Forms.TextBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.chkReclamo = New System.Windows.Forms.CheckBox
        Me.txtOT = New System.Windows.Forms.TextBox
        Me.cboTipo = New System.Windows.Forms.ComboBox
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.cboModoEntrega = New System.Windows.Forms.ComboBox
        Me.txtCarrito = New System.Windows.Forms.TextBox
        Me.btnCarrito = New System.Windows.Forms.Button
        Me.txtHasta2 = New System.Windows.Forms.TextBox
        Me.txtDesde2 = New System.Windows.Forms.TextBox
        Me.txtHasta1 = New System.Windows.Forms.TextBox
        Me.txtDesde1 = New System.Windows.Forms.TextBox
        Me.dtpTarea = New System.Windows.Forms.DateTimePicker
        Me.GroupBox8 = New System.Windows.Forms.GroupBox
        Me.txtObj = New System.Windows.Forms.TextBox
        Me.GroupBox9 = New System.Windows.Forms.GroupBox
        Me.multiline = New System.Windows.Forms.TextBox
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.btnNueva = New System.Windows.Forms.Button
        Me.txtIntervencion = New System.Windows.Forms.TextBox
        Me.btnImprimir = New System.Windows.Forms.Button
        Me.mnu2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuSeleccionArticulo = New System.Windows.Forms.ToolStripMenuItem
        Label14 = New System.Windows.Forms.Label
        Label3 = New System.Windows.Forms.Label
        Label2 = New System.Windows.Forms.Label
        Label4 = New System.Windows.Forms.Label
        Label21 = New System.Windows.Forms.Label
        Label13 = New System.Windows.Forms.Label
        Label1 = New System.Windows.Forms.Label
        Label18 = New System.Windows.Forms.Label
        Label17 = New System.Windows.Forms.Label
        Label22 = New System.Windows.Forms.Label
        Label11 = New System.Windows.Forms.Label
        Label12 = New System.Windows.Forms.Label
        Label23 = New System.Windows.Forms.Label
        Label16 = New System.Windows.Forms.Label
        Label5 = New System.Windows.Forms.Label
        Label15 = New System.Windows.Forms.Label
        Label6 = New System.Windows.Forms.Label
        CType(Me.dgvRetiros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnu.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.mnu2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label14
        '
        Label14.AutoSize = True
        Label14.Location = New System.Drawing.Point(39, 47)
        Label14.Name = "Label14"
        Label14.Size = New System.Drawing.Size(105, 13)
        Label14.TabIndex = 3
        Label14.Text = "Nombre de Fantasia:"
        '
        'Label3
        '
        Label3.AutoSize = True
        Label3.Location = New System.Drawing.Point(93, 75)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(51, 13)
        Label3.TabIndex = 5
        Label3.Text = "Sucursal:"
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Location = New System.Drawing.Point(102, 21)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(42, 13)
        Label2.TabIndex = 0
        Label2.Text = "Cliente:"
        '
        'Label4
        '
        Label4.AutoSize = True
        Label4.Location = New System.Drawing.Point(15, 22)
        Label4.Name = "Label4"
        Label4.Size = New System.Drawing.Size(129, 13)
        Label4.TabIndex = 0
        Label4.Text = "Sociedad de Facturación:"
        '
        'Label21
        '
        Label21.AutoSize = True
        Label21.Location = New System.Drawing.Point(52, 25)
        Label21.Name = "Label21"
        Label21.Size = New System.Drawing.Size(92, 13)
        Label21.TabIndex = 0
        Label21.Text = "Nombre / Portero:"
        '
        'Label13
        '
        Label13.AutoSize = True
        Label13.Location = New System.Drawing.Point(102, 53)
        Label13.Name = "Label13"
        Label13.Size = New System.Drawing.Size(42, 13)
        Label13.TabIndex = 2
        Label13.Text = "Celular:"
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(48, 103)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(96, 13)
        Label1.TabIndex = 8
        Label1.Text = "Teléfono Sucursal:"
        '
        'Label18
        '
        Label18.AutoSize = True
        Label18.Location = New System.Drawing.Point(48, 132)
        Label18.Name = "Label18"
        Label18.Size = New System.Drawing.Size(70, 13)
        Label18.TabIndex = 10
        Label18.Text = "Mail Sucursal"
        '
        'Label17
        '
        Label17.AutoSize = True
        Label17.Location = New System.Drawing.Point(51, 62)
        Label17.Name = "Label17"
        Label17.Size = New System.Drawing.Size(93, 13)
        Label17.TabIndex = 2
        Label17.Text = "Orden de Compra:"
        '
        'Label22
        '
        Label22.AutoSize = True
        Label22.Location = New System.Drawing.Point(3, 94)
        Label22.Name = "Label22"
        Label22.Size = New System.Drawing.Size(108, 13)
        Label22.TabIndex = 4
        Label22.Text = "Primer Franja Horaria:"
        '
        'Label11
        '
        Label11.AutoSize = True
        Label11.Location = New System.Drawing.Point(3, 120)
        Label11.Name = "Label11"
        Label11.Size = New System.Drawing.Size(122, 13)
        Label11.TabIndex = 7
        Label11.Text = "Segunda Franja Horaria:"
        '
        'Label12
        '
        Label12.AutoSize = True
        Label12.Location = New System.Drawing.Point(3, 69)
        Label12.Name = "Label12"
        Label12.Size = New System.Drawing.Size(75, 13)
        Label12.TabIndex = 2
        Label12.Text = "Imprimir el día:"
        '
        'Label23
        '
        Label23.AutoSize = True
        Label23.Location = New System.Drawing.Point(11, 190)
        Label23.Name = "Label23"
        Label23.Size = New System.Drawing.Size(137, 13)
        Label23.TabIndex = 11
        Label23.Text = "Fecha de retiro coordinada:"
        '
        'Label16
        '
        Label16.AutoSize = True
        Label16.Location = New System.Drawing.Point(418, 24)
        Label16.Name = "Label16"
        Label16.Size = New System.Drawing.Size(25, 13)
        Label16.TabIndex = 2
        Label16.Text = "OT:"
        '
        'Label5
        '
        Label5.AutoSize = True
        Label5.Location = New System.Drawing.Point(9, 18)
        Label5.Name = "Label5"
        Label5.Size = New System.Drawing.Size(108, 13)
        Label5.TabIndex = 0
        Label5.Text = "Tipo de Intervención:"
        '
        'Label15
        '
        Label15.AutoSize = True
        Label15.Location = New System.Drawing.Point(44, 160)
        Label15.Name = "Label15"
        Label15.Size = New System.Drawing.Size(100, 13)
        Label15.TabIndex = 12
        Label15.Text = "Condición de Pago:"
        '
        'Label6
        '
        Label6.AutoSize = True
        Label6.Location = New System.Drawing.Point(3, 27)
        Label6.Name = "Label6"
        Label6.Size = New System.Drawing.Size(77, 13)
        Label6.TabIndex = 0
        Label6.Text = "Modo Entrega:"
        '
        'btnCrear
        '
        Me.btnCrear.Location = New System.Drawing.Point(839, 541)
        Me.btnCrear.Name = "btnCrear"
        Me.btnCrear.Size = New System.Drawing.Size(75, 23)
        Me.btnCrear.TabIndex = 0
        Me.btnCrear.Text = "Crear"
        Me.btnCrear.UseVisualStyleBackColor = True
        '
        'dgvRetiros
        '
        Me.dgvRetiros.AllowUserToResizeRows = False
        Me.dgvRetiros.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvRetiros.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvRetiros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRetiros.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colNumlig, Me.colNum, Me.colItmref, Me.colDescripcion, Me.colQty, Me.colUom, Me.colTqty, Me.colTuom, Me.colYqty2, Me.colFactura, Me.colTypLig, Me.colAmt, Me.colSre})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvRetiros.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvRetiros.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvRetiros.Location = New System.Drawing.Point(3, 16)
        Me.dgvRetiros.Name = "dgvRetiros"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvRetiros.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvRetiros.Size = New System.Drawing.Size(507, 250)
        Me.dgvRetiros.TabIndex = 0
        '
        'colNumlig
        '
        Me.colNumlig.HeaderText = "Numlig"
        Me.colNumlig.Name = "colNumlig"
        Me.colNumlig.Visible = False
        Me.colNumlig.Width = 64
        '
        'colNum
        '
        Me.colNum.HeaderText = "Num"
        Me.colNum.Name = "colNum"
        Me.colNum.Visible = False
        Me.colNum.Width = 54
        '
        'colItmref
        '
        Me.colItmref.HeaderText = "Codigo"
        Me.colItmref.Name = "colItmref"
        Me.colItmref.Width = 65
        '
        'colDescripcion
        '
        Me.colDescripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colDescripcion.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.colDescripcion.HeaderText = "Descripción"
        Me.colDescripcion.Name = "colDescripcion"
        Me.colDescripcion.ReadOnly = True
        Me.colDescripcion.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colDescripcion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'colQty
        '
        Me.colQty.HeaderText = "Qty"
        Me.colQty.Name = "colQty"
        Me.colQty.Visible = False
        Me.colQty.Width = 48
        '
        'colUom
        '
        Me.colUom.HeaderText = "Uom"
        Me.colUom.Name = "colUom"
        Me.colUom.Visible = False
        Me.colUom.Width = 54
        '
        'colTqty
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colTqty.DefaultCellStyle = DataGridViewCellStyle2
        Me.colTqty.HeaderText = "Cantidad"
        Me.colTqty.Name = "colTqty"
        Me.colTqty.Width = 74
        '
        'colTuom
        '
        Me.colTuom.HeaderText = "Tuom"
        Me.colTuom.Name = "colTuom"
        Me.colTuom.Visible = False
        Me.colTuom.Width = 59
        '
        'colYqty2
        '
        Me.colYqty2.HeaderText = "Yqty2"
        Me.colYqty2.Name = "colYqty2"
        Me.colYqty2.Visible = False
        Me.colYqty2.Width = 59
        '
        'colFactura
        '
        Me.colFactura.FalseValue = "0"
        Me.colFactura.HeaderText = "Facturable"
        Me.colFactura.Name = "colFactura"
        Me.colFactura.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colFactura.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colFactura.TrueValue = "1"
        Me.colFactura.Width = 82
        '
        'colTypLig
        '
        Me.colTypLig.HeaderText = "Typlig"
        Me.colTypLig.Name = "colTypLig"
        Me.colTypLig.Visible = False
        Me.colTypLig.Width = 60
        '
        'colAmt
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.colAmt.DefaultCellStyle = DataGridViewCellStyle3
        Me.colAmt.HeaderText = "Precio"
        Me.colAmt.Name = "colAmt"
        Me.colAmt.Width = 62
        '
        'colSre
        '
        Me.colSre.HeaderText = "Solicitud"
        Me.colSre.Name = "colSre"
        Me.colSre.Visible = False
        Me.colSre.Width = 72
        '
        'txtNombreFantasia
        '
        Me.txtNombreFantasia.Location = New System.Drawing.Point(150, 44)
        Me.txtNombreFantasia.Name = "txtNombreFantasia"
        Me.txtNombreFantasia.ReadOnly = True
        Me.txtNombreFantasia.Size = New System.Drawing.Size(307, 20)
        Me.txtNombreFantasia.TabIndex = 4
        Me.txtNombreFantasia.TabStop = False
        '
        'txtSucursal
        '
        Me.txtSucursal.ContextMenuStrip = Me.mnu
        Me.txtSucursal.Location = New System.Drawing.Point(150, 72)
        Me.txtSucursal.Name = "txtSucursal"
        Me.txtSucursal.Size = New System.Drawing.Size(78, 20)
        Me.txtSucursal.TabIndex = 6
        '
        'mnu
        '
        Me.mnu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSeleccion, Me.mnuEditar})
        Me.mnu.Name = "mnu"
        Me.mnu.Size = New System.Drawing.Size(125, 48)
        '
        'mnuSeleccion
        '
        Me.mnuSeleccion.Name = "mnuSeleccion"
        Me.mnuSeleccion.Size = New System.Drawing.Size(124, 22)
        Me.mnuSeleccion.Text = "Selección"
        '
        'mnuEditar
        '
        Me.mnuEditar.Name = "mnuEditar"
        Me.mnuEditar.Size = New System.Drawing.Size(124, 22)
        Me.mnuEditar.Text = "Editar"
        '
        'txtCodigoCliente
        '
        Me.txtCodigoCliente.ContextMenuStrip = Me.mnu
        Me.txtCodigoCliente.Location = New System.Drawing.Point(150, 18)
        Me.txtCodigoCliente.Name = "txtCodigoCliente"
        Me.txtCodigoCliente.Size = New System.Drawing.Size(78, 20)
        Me.txtCodigoCliente.TabIndex = 1
        '
        'txtDireccion
        '
        Me.txtDireccion.Location = New System.Drawing.Point(236, 72)
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.ReadOnly = True
        Me.txtDireccion.Size = New System.Drawing.Size(221, 20)
        Me.txtDireccion.TabIndex = 7
        Me.txtDireccion.TabStop = False
        '
        'txtNombreCliente
        '
        Me.txtNombreCliente.Location = New System.Drawing.Point(236, 18)
        Me.txtNombreCliente.Name = "txtNombreCliente"
        Me.txtNombreCliente.ReadOnly = True
        Me.txtNombreCliente.Size = New System.Drawing.Size(221, 20)
        Me.txtNombreCliente.TabIndex = 2
        Me.txtNombreCliente.TabStop = False
        '
        'cboSociedad
        '
        Me.cboSociedad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSociedad.Enabled = False
        Me.cboSociedad.FormattingEnabled = True
        Me.cboSociedad.Location = New System.Drawing.Point(150, 19)
        Me.cboSociedad.Name = "cboSociedad"
        Me.cboSociedad.Size = New System.Drawing.Size(226, 21)
        Me.cboSociedad.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboCondicionPago)
        Me.GroupBox1.Controls.Add(Me.txtMailSucursal)
        Me.GroupBox1.Controls.Add(Label18)
        Me.GroupBox1.Controls.Add(Me.txtTelefonoSucursal)
        Me.GroupBox1.Controls.Add(Label1)
        Me.GroupBox1.Controls.Add(Label15)
        Me.GroupBox1.Controls.Add(Me.txtNombreFantasia)
        Me.GroupBox1.Controls.Add(Me.txtNombreCliente)
        Me.GroupBox1.Controls.Add(Me.txtDireccion)
        Me.GroupBox1.Controls.Add(Me.txtCodigoCliente)
        Me.GroupBox1.Controls.Add(Label14)
        Me.GroupBox1.Controls.Add(Me.txtSucursal)
        Me.GroupBox1.Controls.Add(Label3)
        Me.GroupBox1.Controls.Add(Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 44)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(467, 187)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos del Cliente"
        '
        'cboCondicionPago
        '
        Me.cboCondicionPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCondicionPago.Enabled = False
        Me.cboCondicionPago.FormattingEnabled = True
        Me.cboCondicionPago.Location = New System.Drawing.Point(150, 157)
        Me.cboCondicionPago.Name = "cboCondicionPago"
        Me.cboCondicionPago.Size = New System.Drawing.Size(307, 21)
        Me.cboCondicionPago.TabIndex = 14
        '
        'txtMailSucursal
        '
        Me.txtMailSucursal.Location = New System.Drawing.Point(150, 129)
        Me.txtMailSucursal.MaxLength = 80
        Me.txtMailSucursal.Name = "txtMailSucursal"
        Me.txtMailSucursal.ReadOnly = True
        Me.txtMailSucursal.Size = New System.Drawing.Size(307, 20)
        Me.txtMailSucursal.TabIndex = 11
        Me.txtMailSucursal.TabStop = False
        '
        'txtTelefonoSucursal
        '
        Me.txtTelefonoSucursal.Location = New System.Drawing.Point(150, 100)
        Me.txtTelefonoSucursal.Name = "txtTelefonoSucursal"
        Me.txtTelefonoSucursal.ReadOnly = True
        Me.txtTelefonoSucursal.Size = New System.Drawing.Size(78, 20)
        Me.txtTelefonoSucursal.TabIndex = 9
        Me.txtTelefonoSucursal.TabStop = False
        '
        'lvDocumentos
        '
        Me.lvDocumentos.CheckBoxes = True
        Me.lvDocumentos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4})
        Me.lvDocumentos.FullRowSelect = True
        ListViewGroup1.Header = "Solicitud de Servicio Abiertas"
        ListViewGroup1.Name = "lvgSS"
        ListViewGroup2.Header = "Intervenciones Abiertas"
        ListViewGroup2.Name = "lvgITN"
        Me.lvDocumentos.Groups.AddRange(New System.Windows.Forms.ListViewGroup() {ListViewGroup1, ListViewGroup2})
        Me.lvDocumentos.Location = New System.Drawing.Point(12, 421)
        Me.lvDocumentos.MultiSelect = False
        Me.lvDocumentos.Name = "lvDocumentos"
        Me.lvDocumentos.Size = New System.Drawing.Size(467, 143)
        Me.lvDocumentos.TabIndex = 6
        Me.lvDocumentos.UseCompatibleStateImageBehavior = False
        Me.lvDocumentos.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Documento"
        Me.ColumnHeader1.Width = 120
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Fecha"
        Me.ColumnHeader2.Width = 73
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Tipo"
        Me.ColumnHeader3.Width = 50
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Creado por"
        Me.ColumnHeader4.Width = 83
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtPortero)
        Me.GroupBox2.Controls.Add(Label21)
        Me.GroupBox2.Controls.Add(Label13)
        Me.GroupBox2.Controls.Add(Me.txtPorteroCelu)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 237)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(467, 84)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Datos de Contacto"
        '
        'txtPortero
        '
        Me.txtPortero.Location = New System.Drawing.Point(150, 22)
        Me.txtPortero.Name = "txtPortero"
        Me.txtPortero.ReadOnly = True
        Me.txtPortero.Size = New System.Drawing.Size(307, 20)
        Me.txtPortero.TabIndex = 1
        Me.txtPortero.TabStop = False
        '
        'txtPorteroCelu
        '
        Me.txtPorteroCelu.Location = New System.Drawing.Point(150, 50)
        Me.txtPorteroCelu.MaxLength = 10
        Me.txtPorteroCelu.Name = "txtPorteroCelu"
        Me.txtPorteroCelu.ReadOnly = True
        Me.txtPorteroCelu.Size = New System.Drawing.Size(307, 20)
        Me.txtPorteroCelu.TabIndex = 3
        Me.txtPorteroCelu.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.chkH)
        Me.GroupBox3.Controls.Add(Me.btnVerOC)
        Me.GroupBox3.Controls.Add(Me.cboSociedad)
        Me.GroupBox3.Controls.Add(Me.btnExaminar)
        Me.GroupBox3.Controls.Add(Label4)
        Me.GroupBox3.Controls.Add(Me.btnBorrarOC)
        Me.GroupBox3.Controls.Add(Me.txtOC)
        Me.GroupBox3.Controls.Add(Label17)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 327)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(467, 88)
        Me.GroupBox3.TabIndex = 5
        Me.GroupBox3.TabStop = False
        '
        'chkH
        '
        Me.chkH.AutoSize = True
        Me.chkH.Location = New System.Drawing.Point(383, 22)
        Me.chkH.Name = "chkH"
        Me.chkH.Size = New System.Drawing.Size(34, 17)
        Me.chkH.TabIndex = 7
        Me.chkH.Text = "H"
        Me.chkH.UseVisualStyleBackColor = True
        '
        'btnVerOC
        '
        Me.btnVerOC.Location = New System.Drawing.Point(301, 59)
        Me.btnVerOC.Name = "btnVerOC"
        Me.btnVerOC.Size = New System.Drawing.Size(75, 23)
        Me.btnVerOC.TabIndex = 5
        Me.btnVerOC.TabStop = False
        Me.btnVerOC.Text = "Ver"
        Me.btnVerOC.UseVisualStyleBackColor = True
        '
        'btnExaminar
        '
        Me.btnExaminar.Location = New System.Drawing.Point(220, 59)
        Me.btnExaminar.Name = "btnExaminar"
        Me.btnExaminar.Size = New System.Drawing.Size(75, 23)
        Me.btnExaminar.TabIndex = 4
        Me.btnExaminar.TabStop = False
        Me.btnExaminar.Text = "Examinar"
        Me.btnExaminar.UseVisualStyleBackColor = True
        '
        'btnBorrarOC
        '
        Me.btnBorrarOC.Location = New System.Drawing.Point(382, 59)
        Me.btnBorrarOC.Name = "btnBorrarOC"
        Me.btnBorrarOC.Size = New System.Drawing.Size(75, 23)
        Me.btnBorrarOC.TabIndex = 6
        Me.btnBorrarOC.TabStop = False
        Me.btnBorrarOC.Text = "Borrar"
        Me.btnBorrarOC.UseVisualStyleBackColor = True
        '
        'txtOC
        '
        Me.txtOC.Location = New System.Drawing.Point(150, 59)
        Me.txtOC.MaxLength = 20
        Me.txtOC.Name = "txtOC"
        Me.txtOC.Size = New System.Drawing.Size(64, 20)
        Me.txtOC.TabIndex = 3
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.dgvRetiros)
        Me.GroupBox4.Location = New System.Drawing.Point(485, 70)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(513, 269)
        Me.GroupBox4.TabIndex = 8
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Retiros y Sustitutos"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.chkReclamo)
        Me.GroupBox6.Controls.Add(Me.txtOT)
        Me.GroupBox6.Controls.Add(Me.cboTipo)
        Me.GroupBox6.Controls.Add(Label5)
        Me.GroupBox6.Controls.Add(Label16)
        Me.GroupBox6.Location = New System.Drawing.Point(485, 1)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(513, 52)
        Me.GroupBox6.TabIndex = 7
        Me.GroupBox6.TabStop = False
        '
        'chkReclamo
        '
        Me.chkReclamo.AutoSize = True
        Me.chkReclamo.Location = New System.Drawing.Point(320, 20)
        Me.chkReclamo.Name = "chkReclamo"
        Me.chkReclamo.Size = New System.Drawing.Size(68, 17)
        Me.chkReclamo.TabIndex = 4
        Me.chkReclamo.Text = "Reclamo"
        Me.chkReclamo.UseVisualStyleBackColor = True
        '
        'txtOT
        '
        Me.txtOT.Location = New System.Drawing.Point(449, 18)
        Me.txtOT.Name = "txtOT"
        Me.txtOT.Size = New System.Drawing.Size(58, 20)
        Me.txtOT.TabIndex = 3
        '
        'cboTipo
        '
        Me.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipo.FormattingEnabled = True
        Me.cboTipo.Location = New System.Drawing.Point(123, 17)
        Me.cboTipo.Name = "cboTipo"
        Me.cboTipo.Size = New System.Drawing.Size(191, 21)
        Me.cboTipo.TabIndex = 1
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Label6)
        Me.GroupBox7.Controls.Add(Me.cboModoEntrega)
        Me.GroupBox7.Controls.Add(Label23)
        Me.GroupBox7.Controls.Add(Me.txtCarrito)
        Me.GroupBox7.Controls.Add(Me.btnCarrito)
        Me.GroupBox7.Controls.Add(Label12)
        Me.GroupBox7.Controls.Add(Label11)
        Me.GroupBox7.Controls.Add(Me.txtHasta2)
        Me.GroupBox7.Controls.Add(Me.txtDesde2)
        Me.GroupBox7.Controls.Add(Label22)
        Me.GroupBox7.Controls.Add(Me.txtHasta1)
        Me.GroupBox7.Controls.Add(Me.txtDesde1)
        Me.GroupBox7.Controls.Add(Me.dtpTarea)
        Me.GroupBox7.Location = New System.Drawing.Point(491, 345)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(248, 219)
        Me.GroupBox7.TabIndex = 10
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Logistica"
        '
        'cboModoEntrega
        '
        Me.cboModoEntrega.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboModoEntrega.FormattingEnabled = True
        Me.cboModoEntrega.Location = New System.Drawing.Point(102, 24)
        Me.cboModoEntrega.Name = "cboModoEntrega"
        Me.cboModoEntrega.Size = New System.Drawing.Size(140, 21)
        Me.cboModoEntrega.TabIndex = 1
        '
        'txtCarrito
        '
        Me.txtCarrito.Location = New System.Drawing.Point(164, 187)
        Me.txtCarrito.MaxLength = 20
        Me.txtCarrito.Name = "txtCarrito"
        Me.txtCarrito.ReadOnly = True
        Me.txtCarrito.Size = New System.Drawing.Size(69, 20)
        Me.txtCarrito.TabIndex = 12
        Me.txtCarrito.TabStop = False
        '
        'btnCarrito
        '
        Me.btnCarrito.Location = New System.Drawing.Point(6, 143)
        Me.btnCarrito.Name = "btnCarrito"
        Me.btnCarrito.Size = New System.Drawing.Size(239, 31)
        Me.btnCarrito.TabIndex = 10
        Me.btnCarrito.Text = "Dejar coordinada una fecha de retiro"
        Me.btnCarrito.UseVisualStyleBackColor = True
        '
        'txtHasta2
        '
        Me.txtHasta2.Location = New System.Drawing.Point(198, 117)
        Me.txtHasta2.MaxLength = 4
        Me.txtHasta2.Name = "txtHasta2"
        Me.txtHasta2.Size = New System.Drawing.Size(47, 20)
        Me.txtHasta2.TabIndex = 9
        '
        'txtDesde2
        '
        Me.txtDesde2.Location = New System.Drawing.Point(148, 117)
        Me.txtDesde2.MaxLength = 4
        Me.txtDesde2.Name = "txtDesde2"
        Me.txtDesde2.Size = New System.Drawing.Size(44, 20)
        Me.txtDesde2.TabIndex = 8
        '
        'txtHasta1
        '
        Me.txtHasta1.Location = New System.Drawing.Point(198, 91)
        Me.txtHasta1.MaxLength = 4
        Me.txtHasta1.Name = "txtHasta1"
        Me.txtHasta1.Size = New System.Drawing.Size(47, 20)
        Me.txtHasta1.TabIndex = 6
        '
        'txtDesde1
        '
        Me.txtDesde1.Location = New System.Drawing.Point(148, 91)
        Me.txtDesde1.MaxLength = 4
        Me.txtDesde1.Name = "txtDesde1"
        Me.txtDesde1.Size = New System.Drawing.Size(44, 20)
        Me.txtDesde1.TabIndex = 5
        '
        'dtpTarea
        '
        Me.dtpTarea.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTarea.Location = New System.Drawing.Point(148, 63)
        Me.dtpTarea.Name = "dtpTarea"
        Me.dtpTarea.Size = New System.Drawing.Size(97, 20)
        Me.dtpTarea.TabIndex = 3
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.txtObj)
        Me.GroupBox8.Location = New System.Drawing.Point(753, 345)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(248, 89)
        Me.GroupBox8.TabIndex = 11
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Observaciones"
        '
        'txtObj
        '
        Me.txtObj.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtObj.Location = New System.Drawing.Point(3, 16)
        Me.txtObj.Multiline = True
        Me.txtObj.Name = "txtObj"
        Me.txtObj.Size = New System.Drawing.Size(242, 70)
        Me.txtObj.TabIndex = 0
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.multiline)
        Me.GroupBox9.Location = New System.Drawing.Point(753, 446)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(248, 89)
        Me.GroupBox9.TabIndex = 12
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "Comentarios Internos"
        '
        'multiline
        '
        Me.multiline.Dock = System.Windows.Forms.DockStyle.Fill
        Me.multiline.Location = New System.Drawing.Point(3, 16)
        Me.multiline.Multiline = True
        Me.multiline.Name = "multiline"
        Me.multiline.Size = New System.Drawing.Size(242, 70)
        Me.multiline.TabIndex = 0
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(921, 541)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 1
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'btnNueva
        '
        Me.btnNueva.Location = New System.Drawing.Point(96, 10)
        Me.btnNueva.Name = "btnNueva"
        Me.btnNueva.Size = New System.Drawing.Size(130, 23)
        Me.btnNueva.TabIndex = 0
        Me.btnNueva.Text = "Nueva Intervención"
        Me.btnNueva.UseVisualStyleBackColor = True
        '
        'txtIntervencion
        '
        Me.txtIntervencion.Location = New System.Drawing.Point(331, 12)
        Me.txtIntervencion.Name = "txtIntervencion"
        Me.txtIntervencion.ReadOnly = True
        Me.txtIntervencion.Size = New System.Drawing.Size(138, 20)
        Me.txtIntervencion.TabIndex = 1
        Me.txtIntervencion.TabStop = False
        '
        'btnImprimir
        '
        Me.btnImprimir.Enabled = False
        Me.btnImprimir.Location = New System.Drawing.Point(753, 541)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(75, 23)
        Me.btnImprimir.TabIndex = 13
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'mnu2
        '
        Me.mnu2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSeleccionArticulo})
        Me.mnu2.Name = "mnu"
        Me.mnu2.Size = New System.Drawing.Size(125, 26)
        '
        'mnuSeleccionArticulo
        '
        Me.mnuSeleccionArticulo.Name = "mnuSeleccionArticulo"
        Me.mnuSeleccionArticulo.Size = New System.Drawing.Size(124, 22)
        Me.mnuSeleccionArticulo.Text = "Selección"
        '
        'frmIntervencion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 572)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.txtIntervencion)
        Me.Controls.Add(Me.btnNueva)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.GroupBox9)
        Me.Controls.Add(Me.GroupBox8)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.lvDocumentos)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnCrear)
        Me.Name = "frmIntervencion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Intervencion"
        CType(Me.dgvRetiros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mnu.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        Me.mnu2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCrear As System.Windows.Forms.Button
    Friend WithEvents dgvRetiros As System.Windows.Forms.DataGridView
    Friend WithEvents txtNombreFantasia As System.Windows.Forms.TextBox
    Friend WithEvents txtSucursal As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigoCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtDireccion As System.Windows.Forms.TextBox
    Friend WithEvents txtNombreCliente As System.Windows.Forms.TextBox
    Friend WithEvents cboSociedad As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lvDocumentos As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtPortero As System.Windows.Forms.TextBox
    Friend WithEvents txtPorteroCelu As System.Windows.Forms.TextBox
    Friend WithEvents txtTelefonoSucursal As System.Windows.Forms.TextBox
    Friend WithEvents txtMailSucursal As System.Windows.Forms.TextBox
    Friend WithEvents btnVerOC As System.Windows.Forms.Button
    Friend WithEvents btnExaminar As System.Windows.Forms.Button
    Friend WithEvents btnBorrarOC As System.Windows.Forms.Button
    Friend WithEvents txtOC As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents dtpTarea As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtHasta1 As System.Windows.Forms.TextBox
    Friend WithEvents txtDesde1 As System.Windows.Forms.TextBox
    Friend WithEvents txtHasta2 As System.Windows.Forms.TextBox
    Friend WithEvents txtDesde2 As System.Windows.Forms.TextBox
    Friend WithEvents btnCarrito As System.Windows.Forms.Button
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents txtCarrito As System.Windows.Forms.TextBox
    Friend WithEvents txtObj As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents multiline As System.Windows.Forms.TextBox
    Friend WithEvents cboTipo As System.Windows.Forms.ComboBox
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents txtOT As System.Windows.Forms.TextBox
    Friend WithEvents mnu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuSeleccion As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuEditar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnNueva As System.Windows.Forms.Button
    Friend WithEvents txtIntervencion As System.Windows.Forms.TextBox
    Friend WithEvents cboModoEntrega As System.Windows.Forms.ComboBox
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents mnu2 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuSeleccionArticulo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chkH As System.Windows.Forms.CheckBox
    Friend WithEvents chkReclamo As System.Windows.Forms.CheckBox
    Friend WithEvents cboCondicionPago As System.Windows.Forms.ComboBox
    Friend WithEvents colNumlig As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNum As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItmref As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDescripcion As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUom As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTqty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTuom As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colYqty2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFactura As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colTypLig As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAmt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSre As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
