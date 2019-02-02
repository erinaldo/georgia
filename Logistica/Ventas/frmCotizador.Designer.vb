<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCotizador
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
        Dim SplitContainer1 As System.Windows.Forms.SplitContainer
        Dim Label16 As System.Windows.Forms.Label
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim Label15 As System.Windows.Forms.Label
        Dim Label14 As System.Windows.Forms.Label
        Dim SplitContainer2 As System.Windows.Forms.SplitContainer
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCotizador))
        Dim Label25 As System.Windows.Forms.Label
        Dim Label24 As System.Windows.Forms.Label
        Dim Label23 As System.Windows.Forms.Label
        Dim Label22 As System.Windows.Forms.Label
        Dim Label21 As System.Windows.Forms.Label
        Dim Label20 As System.Windows.Forms.Label
        Dim Label19 As System.Windows.Forms.Label
        Dim Label18 As System.Windows.Forms.Label
        Dim Label12 As System.Windows.Forms.Label
        Dim Label13 As System.Windows.Forms.Label
        Dim Label8 As System.Windows.Forms.Label
        Dim Label10 As System.Windows.Forms.Label
        Dim Label4 As System.Windows.Forms.Label
        Dim Label3 As System.Windows.Forms.Label
        Dim Label7 As System.Windows.Forms.Label
        Dim Label6 As System.Windows.Forms.Label
        Dim Label5 As System.Windows.Forms.Label
        Dim Label1 As System.Windows.Forms.Label
        Dim Label2 As System.Windows.Forms.Label
        Dim SplitContainer3 As System.Windows.Forms.SplitContainer
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim Label17 As System.Windows.Forms.Label
        Dim Label9 As System.Windows.Forms.Label
        Dim Label11 As System.Windows.Forms.Label
        Dim Label26 As System.Windows.Forms.Label
        Me.chkrecargas = New System.Windows.Forms.CheckBox
        Me.chkpresu = New System.Windows.Forms.CheckBox
        Me.btnBuscar = New System.Windows.Forms.Button
        Me.cboBuscarVend = New System.Windows.Forms.ComboBox
        Me.cboBuscarEstado = New System.Windows.Forms.ComboBox
        Me.txtBuscar = New System.Windows.Forms.TextBox
        Me.dgv2 = New System.Windows.Forms.DataGridView
        Me.col2Nro = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col2Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col2Cliente = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.suc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col2Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col2Vend = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.chkOC = New System.Windows.Forms.CheckBox
        Me.txtboxNumAnterior = New System.Windows.Forms.TextBox
        Me.btver = New System.Windows.Forms.Button
        Me.btborrar = New System.Windows.Forms.Button
        Me.pb = New System.Windows.Forms.PictureBox
        Me.btn_examinar = New System.Windows.Forms.Button
        Me.cboCondicionPago = New System.Windows.Forms.ComboBox
        Me.txtNom_fanta = New System.Windows.Forms.TextBox
        Me.btnActualizar = New System.Windows.Forms.Button
        Me.txtMail_FC = New System.Windows.Forms.TextBox
        Me.txtPortero_celu = New System.Windows.Forms.TextBox
        Me.txtNombre_portero = New System.Windows.Forms.TextBox
        Me.cboTipo = New System.Windows.Forms.ComboBox
        Me.btnNuevoPresupuesto = New System.Windows.Forms.Button
        Me.txtPresupuesto = New System.Windows.Forms.TextBox
        Me.txtOC = New System.Windows.Forms.TextBox
        Me.btnNuevoPedido = New System.Windows.Forms.Button
        Me.txtHasta2 = New System.Windows.Forms.TextBox
        Me.txtDesde2 = New System.Windows.Forms.TextBox
        Me.txtHasta1 = New System.Windows.Forms.TextBox
        Me.txtDesde1 = New System.Windows.Forms.TextBox
        Me.txtFecha = New System.Windows.Forms.TextBox
        Me.cboEntrega = New System.Windows.Forms.ComboBox
        Me.cboEstado = New System.Windows.Forms.ComboBox
        Me.txtPedido = New System.Windows.Forms.TextBox
        Me.cboSucursal = New System.Windows.Forms.ComboBox
        Me.txtNro = New System.Windows.Forms.TextBox
        Me.txtBpcnam = New System.Windows.Forms.TextBox
        Me.chkH = New System.Windows.Forms.CheckBox
        Me.cboFcRto = New System.Windows.Forms.ComboBox
        Me.cboSociedad = New System.Windows.Forms.ComboBox
        Me.dgv = New System.Windows.Forms.DataGridView
        Me.colNro = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colLinea = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCodigo = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.colDescripcion = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.colCant = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colPrecio = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colSugerido = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colTotal = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnDuplicar = New System.Windows.Forms.Button
        Me.btnborrar = New System.Windows.Forms.Button
        Me.btnPresu = New System.Windows.Forms.Button
        Me.btnPedido = New System.Windows.Forms.Button
        Me.btnGrabar = New System.Windows.Forms.Button
        Me.txtTotalII = New System.Windows.Forms.TextBox
        Me.txtObs = New System.Windows.Forms.TextBox
        Me.txtTotalAI = New System.Windows.Forms.TextBox
        Me.cboExpreso = New System.Windows.Forms.ComboBox
        SplitContainer1 = New System.Windows.Forms.SplitContainer
        Label16 = New System.Windows.Forms.Label
        Label15 = New System.Windows.Forms.Label
        Label14 = New System.Windows.Forms.Label
        SplitContainer2 = New System.Windows.Forms.SplitContainer
        Label25 = New System.Windows.Forms.Label
        Label24 = New System.Windows.Forms.Label
        Label23 = New System.Windows.Forms.Label
        Label22 = New System.Windows.Forms.Label
        Label21 = New System.Windows.Forms.Label
        Label20 = New System.Windows.Forms.Label
        Label19 = New System.Windows.Forms.Label
        Label18 = New System.Windows.Forms.Label
        Label12 = New System.Windows.Forms.Label
        Label13 = New System.Windows.Forms.Label
        Label8 = New System.Windows.Forms.Label
        Label10 = New System.Windows.Forms.Label
        Label4 = New System.Windows.Forms.Label
        Label3 = New System.Windows.Forms.Label
        Label7 = New System.Windows.Forms.Label
        Label6 = New System.Windows.Forms.Label
        Label5 = New System.Windows.Forms.Label
        Label1 = New System.Windows.Forms.Label
        Label2 = New System.Windows.Forms.Label
        SplitContainer3 = New System.Windows.Forms.SplitContainer
        Label17 = New System.Windows.Forms.Label
        Label9 = New System.Windows.Forms.Label
        Label11 = New System.Windows.Forms.Label
        Label26 = New System.Windows.Forms.Label
        SplitContainer1.Panel1.SuspendLayout()
        SplitContainer1.Panel2.SuspendLayout()
        SplitContainer1.SuspendLayout()
        CType(Me.dgv2, System.ComponentModel.ISupportInitialize).BeginInit()
        SplitContainer2.Panel1.SuspendLayout()
        SplitContainer2.Panel2.SuspendLayout()
        SplitContainer2.SuspendLayout()
        CType(Me.pb, System.ComponentModel.ISupportInitialize).BeginInit()
        SplitContainer3.Panel1.SuspendLayout()
        SplitContainer3.Panel2.SuspendLayout()
        SplitContainer3.SuspendLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        SplitContainer1.Location = New System.Drawing.Point(0, 0)
        SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        SplitContainer1.Panel1.Controls.Add(Me.chkrecargas)
        SplitContainer1.Panel1.Controls.Add(Me.chkpresu)
        SplitContainer1.Panel1.Controls.Add(Me.btnBuscar)
        SplitContainer1.Panel1.Controls.Add(Label16)
        SplitContainer1.Panel1.Controls.Add(Me.cboBuscarVend)
        SplitContainer1.Panel1.Controls.Add(Me.cboBuscarEstado)
        SplitContainer1.Panel1.Controls.Add(Me.txtBuscar)
        SplitContainer1.Panel1.Controls.Add(Me.dgv2)
        SplitContainer1.Panel1.Controls.Add(Label15)
        SplitContainer1.Panel1.Controls.Add(Label14)
        '
        'SplitContainer1.Panel2
        '
        SplitContainer1.Panel2.Controls.Add(SplitContainer2)
        SplitContainer1.Size = New System.Drawing.Size(1048, 554)
        SplitContainer1.SplitterDistance = 327
        SplitContainer1.TabIndex = 0
        '
        'chkrecargas
        '
        Me.chkrecargas.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkrecargas.AutoSize = True
        Me.chkrecargas.Location = New System.Drawing.Point(191, 523)
        Me.chkrecargas.Name = "chkrecargas"
        Me.chkrecargas.Size = New System.Drawing.Size(85, 17)
        Me.chkrecargas.TabIndex = 46
        Me.chkrecargas.Text = "P. Recargas"
        Me.chkrecargas.UseVisualStyleBackColor = True
        '
        'chkpresu
        '
        Me.chkpresu.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkpresu.AutoSize = True
        Me.chkpresu.Location = New System.Drawing.Point(100, 523)
        Me.chkpresu.Name = "chkpresu"
        Me.chkpresu.Size = New System.Drawing.Size(77, 17)
        Me.chkpresu.TabIndex = 45
        Me.chkpresu.Text = "P. Pedidos"
        Me.chkpresu.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnBuscar.Location = New System.Drawing.Point(12, 519)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(75, 23)
        Me.btnBuscar.TabIndex = 44
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Label16.AutoSize = True
        Label16.Location = New System.Drawing.Point(262, 478)
        Label16.Name = "Label16"
        Label16.Size = New System.Drawing.Size(55, 13)
        Label16.TabIndex = 43
        Label16.Text = "Pendiente"
        '
        'cboBuscarVend
        '
        Me.cboBuscarVend.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cboBuscarVend.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBuscarVend.FormattingEnabled = True
        Me.cboBuscarVend.Location = New System.Drawing.Point(100, 494)
        Me.cboBuscarVend.Name = "cboBuscarVend"
        Me.cboBuscarVend.Size = New System.Drawing.Size(159, 21)
        Me.cboBuscarVend.TabIndex = 42
        '
        'cboBuscarEstado
        '
        Me.cboBuscarEstado.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cboBuscarEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBuscarEstado.FormattingEnabled = True
        Me.cboBuscarEstado.Location = New System.Drawing.Point(265, 494)
        Me.cboBuscarEstado.Name = "cboBuscarEstado"
        Me.cboBuscarEstado.Size = New System.Drawing.Size(50, 21)
        Me.cboBuscarEstado.TabIndex = 41
        '
        'txtBuscar
        '
        Me.txtBuscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtBuscar.Location = New System.Drawing.Point(12, 494)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(82, 20)
        Me.txtBuscar.TabIndex = 8
        '
        'dgv2
        '
        Me.dgv2.AllowUserToAddRows = False
        Me.dgv2.AllowUserToDeleteRows = False
        Me.dgv2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col2Nro, Me.col2Fecha, Me.col2Cliente, Me.suc, Me.col2Nombre, Me.col2Vend})
        Me.dgv2.Location = New System.Drawing.Point(3, 3)
        Me.dgv2.Name = "dgv2"
        Me.dgv2.ReadOnly = True
        Me.dgv2.Size = New System.Drawing.Size(321, 460)
        Me.dgv2.TabIndex = 0
        '
        'col2Nro
        '
        Me.col2Nro.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.col2Nro.DefaultCellStyle = DataGridViewCellStyle6
        Me.col2Nro.HeaderText = "Nro"
        Me.col2Nro.Name = "col2Nro"
        Me.col2Nro.ReadOnly = True
        Me.col2Nro.Width = 49
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
        'suc
        '
        Me.suc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.suc.HeaderText = "suc"
        Me.suc.Name = "suc"
        Me.suc.ReadOnly = True
        Me.suc.Width = 49
        '
        'col2Nombre
        '
        Me.col2Nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.col2Nombre.HeaderText = "Nombre"
        Me.col2Nombre.Name = "col2Nombre"
        Me.col2Nombre.ReadOnly = True
        Me.col2Nombre.Width = 69
        '
        'col2Vend
        '
        Me.col2Vend.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.col2Vend.HeaderText = "Vend"
        Me.col2Vend.Name = "col2Vend"
        Me.col2Vend.ReadOnly = True
        Me.col2Vend.Width = 57
        '
        'Label15
        '
        Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Label15.AutoSize = True
        Label15.Location = New System.Drawing.Point(97, 478)
        Label15.Name = "Label15"
        Label15.Size = New System.Drawing.Size(53, 13)
        Label15.TabIndex = 2
        Label15.Text = "Vendedor"
        '
        'Label14
        '
        Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Label14.AutoSize = True
        Label14.Location = New System.Drawing.Point(12, 478)
        Label14.Name = "Label14"
        Label14.Size = New System.Drawing.Size(39, 13)
        Label14.TabIndex = 2
        Label14.Text = "Cliente"
        '
        'SplitContainer2
        '
        SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        SplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        SplitContainer2.Location = New System.Drawing.Point(0, 0)
        SplitContainer2.Name = "SplitContainer2"
        SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        SplitContainer2.Panel1.Controls.Add(Label26)
        SplitContainer2.Panel1.Controls.Add(Me.cboExpreso)
        SplitContainer2.Panel1.Controls.Add(Me.chkOC)
        SplitContainer2.Panel1.Controls.Add(Me.txtboxNumAnterior)
        SplitContainer2.Panel1.Controls.Add(Me.btver)
        SplitContainer2.Panel1.Controls.Add(Me.btborrar)
        SplitContainer2.Panel1.Controls.Add(Me.pb)
        SplitContainer2.Panel1.Controls.Add(Me.btn_examinar)
        SplitContainer2.Panel1.Controls.Add(Label25)
        SplitContainer2.Panel1.Controls.Add(Me.cboCondicionPago)
        SplitContainer2.Panel1.Controls.Add(Me.txtNom_fanta)
        SplitContainer2.Panel1.Controls.Add(Label24)
        SplitContainer2.Panel1.Controls.Add(Me.btnActualizar)
        SplitContainer2.Panel1.Controls.Add(Me.txtMail_FC)
        SplitContainer2.Panel1.Controls.Add(Label23)
        SplitContainer2.Panel1.Controls.Add(Me.txtPortero_celu)
        SplitContainer2.Panel1.Controls.Add(Me.txtNombre_portero)
        SplitContainer2.Panel1.Controls.Add(Label22)
        SplitContainer2.Panel1.Controls.Add(Label21)
        SplitContainer2.Panel1.Controls.Add(Label20)
        SplitContainer2.Panel1.Controls.Add(Me.cboTipo)
        SplitContainer2.Panel1.Controls.Add(Me.btnNuevoPresupuesto)
        SplitContainer2.Panel1.Controls.Add(Label19)
        SplitContainer2.Panel1.Controls.Add(Me.txtPresupuesto)
        SplitContainer2.Panel1.Controls.Add(Me.txtOC)
        SplitContainer2.Panel1.Controls.Add(Label18)
        SplitContainer2.Panel1.Controls.Add(Label12)
        SplitContainer2.Panel1.Controls.Add(Me.btnNuevoPedido)
        SplitContainer2.Panel1.Controls.Add(Label13)
        SplitContainer2.Panel1.Controls.Add(Me.txtHasta2)
        SplitContainer2.Panel1.Controls.Add(Me.txtDesde2)
        SplitContainer2.Panel1.Controls.Add(Me.txtHasta1)
        SplitContainer2.Panel1.Controls.Add(Me.txtDesde1)
        SplitContainer2.Panel1.Controls.Add(Label8)
        SplitContainer2.Panel1.Controls.Add(Me.txtFecha)
        SplitContainer2.Panel1.Controls.Add(Label10)
        SplitContainer2.Panel1.Controls.Add(Label4)
        SplitContainer2.Panel1.Controls.Add(Label3)
        SplitContainer2.Panel1.Controls.Add(Me.cboEntrega)
        SplitContainer2.Panel1.Controls.Add(Me.cboEstado)
        SplitContainer2.Panel1.Controls.Add(Me.txtPedido)
        SplitContainer2.Panel1.Controls.Add(Label7)
        SplitContainer2.Panel1.Controls.Add(Me.cboSucursal)
        SplitContainer2.Panel1.Controls.Add(Label6)
        SplitContainer2.Panel1.Controls.Add(Me.txtNro)
        SplitContainer2.Panel1.Controls.Add(Me.txtBpcnam)
        SplitContainer2.Panel1.Controls.Add(Label5)
        SplitContainer2.Panel1.Controls.Add(Me.chkH)
        SplitContainer2.Panel1.Controls.Add(Me.cboFcRto)
        SplitContainer2.Panel1.Controls.Add(Me.cboSociedad)
        SplitContainer2.Panel1.Controls.Add(Label1)
        SplitContainer2.Panel1.Controls.Add(Label2)
        '
        'SplitContainer2.Panel2
        '
        SplitContainer2.Panel2.Controls.Add(SplitContainer3)
        SplitContainer2.Size = New System.Drawing.Size(717, 554)
        SplitContainer2.SplitterDistance = 242
        SplitContainer2.TabIndex = 0
        '
        'chkOC
        '
        Me.chkOC.AutoSize = True
        Me.chkOC.Enabled = False
        Me.chkOC.Location = New System.Drawing.Point(389, 184)
        Me.chkOC.Name = "chkOC"
        Me.chkOC.Size = New System.Drawing.Size(94, 17)
        Me.chkOC.TabIndex = 64
        Me.chkOC.Text = "OC Obligatoria"
        Me.chkOC.UseVisualStyleBackColor = True
        '
        'txtboxNumAnterior
        '
        Me.txtboxNumAnterior.Location = New System.Drawing.Point(298, 6)
        Me.txtboxNumAnterior.Name = "txtboxNumAnterior"
        Me.txtboxNumAnterior.ReadOnly = True
        Me.txtboxNumAnterior.Size = New System.Drawing.Size(87, 20)
        Me.txtboxNumAnterior.TabIndex = 63
        Me.txtboxNumAnterior.TabStop = False
        Me.txtboxNumAnterior.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtboxNumAnterior.Visible = False
        Me.txtboxNumAnterior.WordWrap = False
        '
        'btver
        '
        Me.btver.Enabled = False
        Me.btver.Location = New System.Drawing.Point(288, 183)
        Me.btver.Name = "btver"
        Me.btver.Size = New System.Drawing.Size(33, 19)
        Me.btver.TabIndex = 62
        Me.btver.Text = "Ver"
        Me.btver.UseVisualStyleBackColor = True
        '
        'btborrar
        '
        Me.btborrar.Enabled = False
        Me.btborrar.Location = New System.Drawing.Point(239, 183)
        Me.btborrar.Name = "btborrar"
        Me.btborrar.Size = New System.Drawing.Size(47, 19)
        Me.btborrar.TabIndex = 61
        Me.btborrar.Text = "Borrar"
        Me.btborrar.UseVisualStyleBackColor = True
        '
        'pb
        '
        Me.pb.Image = CType(resources.GetObject("pb.Image"), System.Drawing.Image)
        Me.pb.Location = New System.Drawing.Point(239, 7)
        Me.pb.Name = "pb"
        Me.pb.Size = New System.Drawing.Size(23, 34)
        Me.pb.TabIndex = 60
        Me.pb.TabStop = False
        Me.pb.Visible = False
        '
        'btn_examinar
        '
        Me.btn_examinar.Enabled = False
        Me.btn_examinar.Location = New System.Drawing.Point(327, 183)
        Me.btn_examinar.Name = "btn_examinar"
        Me.btn_examinar.Size = New System.Drawing.Size(58, 19)
        Me.btn_examinar.TabIndex = 59
        Me.btn_examinar.Text = "Examinar"
        Me.btn_examinar.UseVisualStyleBackColor = True
        '
        'Label25
        '
        Label25.AutoSize = True
        Label25.Location = New System.Drawing.Point(6, 212)
        Label25.Name = "Label25"
        Label25.Size = New System.Drawing.Size(99, 13)
        Label25.TabIndex = 58
        Label25.Text = "Condicion de pago:"
        '
        'cboCondicionPago
        '
        Me.cboCondicionPago.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboCondicionPago.FormattingEnabled = True
        Me.cboCondicionPago.Location = New System.Drawing.Point(111, 209)
        Me.cboCondicionPago.Name = "cboCondicionPago"
        Me.cboCondicionPago.Size = New System.Drawing.Size(274, 21)
        Me.cboCondicionPago.TabIndex = 57
        '
        'txtNom_fanta
        '
        Me.txtNom_fanta.Location = New System.Drawing.Point(87, 100)
        Me.txtNom_fanta.Name = "txtNom_fanta"
        Me.txtNom_fanta.Size = New System.Drawing.Size(298, 20)
        Me.txtNom_fanta.TabIndex = 56
        '
        'Label24
        '
        Label24.AutoSize = True
        Label24.Location = New System.Drawing.Point(6, 103)
        Label24.Name = "Label24"
        Label24.Size = New System.Drawing.Size(75, 13)
        Label24.TabIndex = 55
        Label24.Text = "Nom Fantasia:"
        '
        'btnActualizar
        '
        Me.btnActualizar.Location = New System.Drawing.Point(629, 209)
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(79, 19)
        Me.btnActualizar.TabIndex = 54
        Me.btnActualizar.Text = "Actualizar"
        Me.btnActualizar.UseVisualStyleBackColor = True
        Me.btnActualizar.Visible = False
        '
        'txtMail_FC
        '
        Me.txtMail_FC.Location = New System.Drawing.Point(468, 157)
        Me.txtMail_FC.Name = "txtMail_FC"
        Me.txtMail_FC.Size = New System.Drawing.Size(237, 20)
        Me.txtMail_FC.TabIndex = 53
        '
        'Label23
        '
        Label23.AutoSize = True
        Label23.Location = New System.Drawing.Point(393, 160)
        Label23.Name = "Label23"
        Label23.Size = New System.Drawing.Size(69, 13)
        Label23.TabIndex = 52
        Label23.Text = "Mail FC Elec:"
        '
        'txtPortero_celu
        '
        Me.txtPortero_celu.Location = New System.Drawing.Point(579, 180)
        Me.txtPortero_celu.MaxLength = 10
        Me.txtPortero_celu.Name = "txtPortero_celu"
        Me.txtPortero_celu.Size = New System.Drawing.Size(126, 20)
        Me.txtPortero_celu.TabIndex = 51
        '
        'txtNombre_portero
        '
        Me.txtNombre_portero.Location = New System.Drawing.Point(537, 131)
        Me.txtNombre_portero.MaxLength = 50
        Me.txtNombre_portero.Name = "txtNombre_portero"
        Me.txtNombre_portero.Size = New System.Drawing.Size(168, 20)
        Me.txtNombre_portero.TabIndex = 50
        '
        'Label22
        '
        Label22.AutoSize = True
        Label22.Location = New System.Drawing.Point(489, 185)
        Label22.Name = "Label22"
        Label22.Size = New System.Drawing.Size(91, 13)
        Label22.TabIndex = 49
        Label22.Text = "Celular Contacto :"
        '
        'Label21
        '
        Label21.AutoSize = True
        Label21.Location = New System.Drawing.Point(393, 134)
        Label21.Name = "Label21"
        Label21.Size = New System.Drawing.Size(138, 13)
        Label21.TabIndex = 48
        Label21.Text = "Nombre Contacto / Portero:"
        '
        'Label20
        '
        Label20.AutoSize = True
        Label20.Location = New System.Drawing.Point(391, 64)
        Label20.Name = "Label20"
        Label20.Size = New System.Drawing.Size(31, 13)
        Label20.TabIndex = 47
        Label20.Text = "Tipo:"
        '
        'cboTipo
        '
        Me.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipo.Enabled = False
        Me.cboTipo.FormattingEnabled = True
        Me.cboTipo.Location = New System.Drawing.Point(444, 58)
        Me.cboTipo.Name = "cboTipo"
        Me.cboTipo.Size = New System.Drawing.Size(73, 21)
        Me.cboTipo.TabIndex = 46
        '
        'btnNuevoPresupuesto
        '
        Me.btnNuevoPresupuesto.Location = New System.Drawing.Point(124, 12)
        Me.btnNuevoPresupuesto.Name = "btnNuevoPresupuesto"
        Me.btnNuevoPresupuesto.Size = New System.Drawing.Size(109, 23)
        Me.btnNuevoPresupuesto.TabIndex = 45
        Me.btnNuevoPresupuesto.Text = "Nuevo Presupuesto"
        Me.btnNuevoPresupuesto.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Label19.AutoSize = True
        Label19.Location = New System.Drawing.Point(523, 65)
        Label19.Name = "Label19"
        Label19.Size = New System.Drawing.Size(66, 13)
        Label19.TabIndex = 44
        Label19.Text = "Presupuesto"
        '
        'txtPresupuesto
        '
        Me.txtPresupuesto.Location = New System.Drawing.Point(595, 61)
        Me.txtPresupuesto.Name = "txtPresupuesto"
        Me.txtPresupuesto.ReadOnly = True
        Me.txtPresupuesto.Size = New System.Drawing.Size(113, 20)
        Me.txtPresupuesto.TabIndex = 43
        Me.txtPresupuesto.TabStop = False
        '
        'txtOC
        '
        Me.txtOC.Location = New System.Drawing.Point(40, 184)
        Me.txtOC.MaxLength = 20
        Me.txtOC.Name = "txtOC"
        Me.txtOC.ReadOnly = True
        Me.txtOC.Size = New System.Drawing.Size(193, 20)
        Me.txtOC.TabIndex = 42
        '
        'Label18
        '
        Label18.AutoSize = True
        Label18.Location = New System.Drawing.Point(6, 187)
        Label18.Name = "Label18"
        Label18.Size = New System.Drawing.Size(28, 13)
        Label18.TabIndex = 41
        Label18.Text = "O.C."
        '
        'Label12
        '
        Label12.AutoSize = True
        Label12.Location = New System.Drawing.Point(391, 105)
        Label12.Name = "Label12"
        Label12.Size = New System.Drawing.Size(106, 13)
        Label12.TabIndex = 38
        Label12.Text = "Horario Turno Tarde:"
        '
        'btnNuevoPedido
        '
        Me.btnNuevoPedido.Location = New System.Drawing.Point(9, 12)
        Me.btnNuevoPedido.Name = "btnNuevoPedido"
        Me.btnNuevoPedido.Size = New System.Drawing.Size(109, 23)
        Me.btnNuevoPedido.TabIndex = 16
        Me.btnNuevoPedido.Text = "Nuevo Pedido"
        Me.btnNuevoPedido.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Label13.AutoSize = True
        Label13.Location = New System.Drawing.Point(391, 86)
        Label13.Name = "Label13"
        Label13.Size = New System.Drawing.Size(117, 13)
        Label13.TabIndex = 35
        Label13.Text = "Horario Turno Mañana:"
        '
        'txtHasta2
        '
        Me.txtHasta2.Location = New System.Drawing.Point(576, 105)
        Me.txtHasta2.MaxLength = 4
        Me.txtHasta2.Name = "txtHasta2"
        Me.txtHasta2.ReadOnly = True
        Me.txtHasta2.Size = New System.Drawing.Size(47, 20)
        Me.txtHasta2.TabIndex = 40
        '
        'txtDesde2
        '
        Me.txtDesde2.Location = New System.Drawing.Point(526, 105)
        Me.txtDesde2.MaxLength = 4
        Me.txtDesde2.Name = "txtDesde2"
        Me.txtDesde2.ReadOnly = True
        Me.txtDesde2.Size = New System.Drawing.Size(44, 20)
        Me.txtDesde2.TabIndex = 39
        '
        'txtHasta1
        '
        Me.txtHasta1.Location = New System.Drawing.Point(576, 83)
        Me.txtHasta1.MaxLength = 4
        Me.txtHasta1.Name = "txtHasta1"
        Me.txtHasta1.ReadOnly = True
        Me.txtHasta1.Size = New System.Drawing.Size(47, 20)
        Me.txtHasta1.TabIndex = 37
        '
        'txtDesde1
        '
        Me.txtDesde1.Location = New System.Drawing.Point(526, 83)
        Me.txtDesde1.MaxLength = 4
        Me.txtDesde1.Name = "txtDesde1"
        Me.txtDesde1.ReadOnly = True
        Me.txtDesde1.Size = New System.Drawing.Size(44, 20)
        Me.txtDesde1.TabIndex = 36
        '
        'Label8
        '
        Label8.AutoSize = True
        Label8.Location = New System.Drawing.Point(551, 37)
        Label8.Name = "Label8"
        Label8.Size = New System.Drawing.Size(40, 13)
        Label8.TabIndex = 12
        Label8.Text = "Pedido"
        '
        'txtFecha
        '
        Me.txtFecha.Location = New System.Drawing.Point(596, 6)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.ReadOnly = True
        Me.txtFecha.Size = New System.Drawing.Size(112, 20)
        Me.txtFecha.TabIndex = 11
        Me.txtFecha.TabStop = False
        '
        'Label10
        '
        Label10.AutoSize = True
        Label10.Location = New System.Drawing.Point(279, 51)
        Label10.Name = "Label10"
        Label10.Size = New System.Drawing.Size(45, 13)
        Label10.TabIndex = 10
        Label10.Text = "Fc c/rto"
        '
        'Label4
        '
        Label4.AutoSize = True
        Label4.Location = New System.Drawing.Point(391, 37)
        Label4.Name = "Label4"
        Label4.Size = New System.Drawing.Size(43, 13)
        Label4.TabIndex = 12
        Label4.Text = "Estado:"
        '
        'Label3
        '
        Label3.AutoSize = True
        Label3.Location = New System.Drawing.Point(551, 9)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(37, 13)
        Label3.TabIndex = 10
        Label3.Text = "Fecha"
        '
        'cboEntrega
        '
        Me.cboEntrega.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEntrega.FormattingEnabled = True
        Me.cboEntrega.Location = New System.Drawing.Point(238, 126)
        Me.cboEntrega.Name = "cboEntrega"
        Me.cboEntrega.Size = New System.Drawing.Size(146, 21)
        Me.cboEntrega.TabIndex = 9
        '
        'cboEstado
        '
        Me.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cboEstado.Enabled = False
        Me.cboEstado.FormattingEnabled = True
        Me.cboEstado.Location = New System.Drawing.Point(444, 31)
        Me.cboEstado.Name = "cboEstado"
        Me.cboEstado.Size = New System.Drawing.Size(87, 21)
        Me.cboEstado.TabIndex = 0
        '
        'txtPedido
        '
        Me.txtPedido.Location = New System.Drawing.Point(595, 34)
        Me.txtPedido.Name = "txtPedido"
        Me.txtPedido.ReadOnly = True
        Me.txtPedido.Size = New System.Drawing.Size(113, 20)
        Me.txtPedido.TabIndex = 5
        Me.txtPedido.TabStop = False
        '
        'Label7
        '
        Label7.AutoSize = True
        Label7.Location = New System.Drawing.Point(189, 129)
        Label7.Name = "Label7"
        Label7.Size = New System.Drawing.Size(44, 13)
        Label7.TabIndex = 8
        Label7.Text = "Entrega"
        '
        'cboSucursal
        '
        Me.cboSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSucursal.FormattingEnabled = True
        Me.cboSucursal.Location = New System.Drawing.Point(38, 126)
        Me.cboSucursal.Name = "cboSucursal"
        Me.cboSucursal.Size = New System.Drawing.Size(144, 21)
        Me.cboSucursal.TabIndex = 7
        '
        'Label6
        '
        Label6.AutoSize = True
        Label6.Location = New System.Drawing.Point(6, 128)
        Label6.Name = "Label6"
        Label6.Size = New System.Drawing.Size(26, 13)
        Label6.TabIndex = 6
        Label6.Text = "Suc"
        '
        'txtNro
        '
        Me.txtNro.Location = New System.Drawing.Point(444, 6)
        Me.txtNro.Name = "txtNro"
        Me.txtNro.ReadOnly = True
        Me.txtNro.Size = New System.Drawing.Size(87, 20)
        Me.txtNro.TabIndex = 5
        Me.txtNro.TabStop = False
        Me.txtNro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtBpcnam
        '
        Me.txtBpcnam.Location = New System.Drawing.Point(61, 74)
        Me.txtBpcnam.Name = "txtBpcnam"
        Me.txtBpcnam.ReadOnly = True
        Me.txtBpcnam.Size = New System.Drawing.Size(324, 20)
        Me.txtBpcnam.TabIndex = 5
        Me.txtBpcnam.TabStop = False
        '
        'Label5
        '
        Label5.AutoSize = True
        Label5.Location = New System.Drawing.Point(6, 77)
        Label5.Name = "Label5"
        Label5.Size = New System.Drawing.Size(39, 13)
        Label5.TabIndex = 3
        Label5.Text = "Cliente"
        '
        'chkH
        '
        Me.chkH.AutoSize = True
        Me.chkH.Location = New System.Drawing.Point(239, 51)
        Me.chkH.Name = "chkH"
        Me.chkH.Size = New System.Drawing.Size(34, 17)
        Me.chkH.TabIndex = 1
        Me.chkH.Text = "H"
        Me.chkH.UseVisualStyleBackColor = True
        '
        'cboFcRto
        '
        Me.cboFcRto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFcRto.FormattingEnabled = True
        Me.cboFcRto.Location = New System.Drawing.Point(327, 47)
        Me.cboFcRto.Name = "cboFcRto"
        Me.cboFcRto.Size = New System.Drawing.Size(58, 21)
        Me.cboFcRto.TabIndex = 0
        '
        'cboSociedad
        '
        Me.cboSociedad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSociedad.FormattingEnabled = True
        Me.cboSociedad.Location = New System.Drawing.Point(61, 47)
        Me.cboSociedad.Name = "cboSociedad"
        Me.cboSociedad.Size = New System.Drawing.Size(172, 21)
        Me.cboSociedad.TabIndex = 0
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(391, 9)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(47, 13)
        Label1.TabIndex = 2
        Label1.Text = "Número:"
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Location = New System.Drawing.Point(6, 50)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(52, 13)
        Label2.TabIndex = 2
        Label2.Text = "Sociedad"
        '
        'SplitContainer3
        '
        SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        SplitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        SplitContainer3.Location = New System.Drawing.Point(0, 0)
        SplitContainer3.Name = "SplitContainer3"
        SplitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer3.Panel1
        '
        SplitContainer3.Panel1.Controls.Add(Me.dgv)
        '
        'SplitContainer3.Panel2
        '
        SplitContainer3.Panel2.Controls.Add(Me.btnDuplicar)
        SplitContainer3.Panel2.Controls.Add(Me.btnborrar)
        SplitContainer3.Panel2.Controls.Add(Me.btnPresu)
        SplitContainer3.Panel2.Controls.Add(Me.btnPedido)
        SplitContainer3.Panel2.Controls.Add(Me.btnGrabar)
        SplitContainer3.Panel2.Controls.Add(Me.txtTotalII)
        SplitContainer3.Panel2.Controls.Add(Label17)
        SplitContainer3.Panel2.Controls.Add(Me.txtObs)
        SplitContainer3.Panel2.Controls.Add(Label9)
        SplitContainer3.Panel2.Controls.Add(Me.txtTotalAI)
        SplitContainer3.Panel2.Controls.Add(Label11)
        SplitContainer3.Size = New System.Drawing.Size(717, 308)
        SplitContainer3.SplitterDistance = 201
        SplitContainer3.TabIndex = 0
        '
        'dgv
        '
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colNro, Me.colLinea, Me.colCodigo, Me.colDescripcion, Me.colCant, Me.colPrecio, Me.colSugerido, Me.colTotal})
        Me.dgv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv.Location = New System.Drawing.Point(0, 0)
        Me.dgv.Name = "dgv"
        Me.dgv.ReadOnly = True
        Me.dgv.Size = New System.Drawing.Size(717, 201)
        Me.dgv.TabIndex = 7
        '
        'colNro
        '
        Me.colNro.HeaderText = "Numero"
        Me.colNro.Name = "colNro"
        Me.colNro.ReadOnly = True
        Me.colNro.Visible = False
        '
        'colLinea
        '
        Me.colLinea.HeaderText = "Linea"
        Me.colLinea.Name = "colLinea"
        Me.colLinea.ReadOnly = True
        Me.colLinea.Visible = False
        '
        'colCodigo
        '
        Me.colCodigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colCodigo.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.colCodigo.HeaderText = "Codigo"
        Me.colCodigo.Name = "colCodigo"
        Me.colCodigo.ReadOnly = True
        Me.colCodigo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colCodigo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colCodigo.Width = 65
        '
        'colDescripcion
        '
        Me.colDescripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.colDescripcion.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.colDescripcion.HeaderText = "Descripción"
        Me.colDescripcion.Name = "colDescripcion"
        Me.colDescripcion.ReadOnly = True
        Me.colDescripcion.Width = 69
        '
        'colCant
        '
        Me.colCant.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colCant.DefaultCellStyle = DataGridViewCellStyle7
        Me.colCant.HeaderText = "Cantidad"
        Me.colCant.Name = "colCant"
        Me.colCant.ReadOnly = True
        Me.colCant.Width = 74
        '
        'colPrecio
        '
        Me.colPrecio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Format = "N2"
        Me.colPrecio.DefaultCellStyle = DataGridViewCellStyle8
        Me.colPrecio.HeaderText = "Precio"
        Me.colPrecio.Name = "colPrecio"
        Me.colPrecio.ReadOnly = True
        Me.colPrecio.Width = 62
        '
        'colSugerido
        '
        Me.colSugerido.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.Format = "N2"
        Me.colSugerido.DefaultCellStyle = DataGridViewCellStyle9
        Me.colSugerido.HeaderText = "Sugerido"
        Me.colSugerido.Name = "colSugerido"
        Me.colSugerido.ReadOnly = True
        Me.colSugerido.Width = 74
        '
        'colTotal
        '
        Me.colTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.Format = "N2"
        Me.colTotal.DefaultCellStyle = DataGridViewCellStyle10
        Me.colTotal.HeaderText = "Total"
        Me.colTotal.Name = "colTotal"
        Me.colTotal.ReadOnly = True
        Me.colTotal.Width = 56
        '
        'btnDuplicar
        '
        Me.btnDuplicar.Location = New System.Drawing.Point(187, 76)
        Me.btnDuplicar.Name = "btnDuplicar"
        Me.btnDuplicar.Size = New System.Drawing.Size(75, 23)
        Me.btnDuplicar.TabIndex = 21
        Me.btnDuplicar.Text = "Duplicar"
        Me.btnDuplicar.UseVisualStyleBackColor = True
        '
        'btnborrar
        '
        Me.btnborrar.Location = New System.Drawing.Point(414, 79)
        Me.btnborrar.Name = "btnborrar"
        Me.btnborrar.Size = New System.Drawing.Size(72, 22)
        Me.btnborrar.TabIndex = 20
        Me.btnborrar.Text = "Borrar"
        Me.btnborrar.UseVisualStyleBackColor = True
        '
        'btnPresu
        '
        Me.btnPresu.Location = New System.Drawing.Point(574, 78)
        Me.btnPresu.Name = "btnPresu"
        Me.btnPresu.Size = New System.Drawing.Size(75, 23)
        Me.btnPresu.TabIndex = 19
        Me.btnPresu.Text = "Presupuesto"
        Me.btnPresu.UseVisualStyleBackColor = True
        '
        'btnPedido
        '
        Me.btnPedido.Location = New System.Drawing.Point(493, 78)
        Me.btnPedido.Name = "btnPedido"
        Me.btnPedido.Size = New System.Drawing.Size(75, 23)
        Me.btnPedido.TabIndex = 18
        Me.btnPedido.Text = "Pedido"
        Me.btnPedido.UseVisualStyleBackColor = True
        '
        'btnGrabar
        '
        Me.btnGrabar.Location = New System.Drawing.Point(9, 76)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(75, 23)
        Me.btnGrabar.TabIndex = 17
        Me.btnGrabar.Text = "Grabar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'txtTotalII
        '
        Me.txtTotalII.Location = New System.Drawing.Point(565, 47)
        Me.txtTotalII.Name = "txtTotalII"
        Me.txtTotalII.ReadOnly = True
        Me.txtTotalII.Size = New System.Drawing.Size(84, 20)
        Me.txtTotalII.TabIndex = 15
        Me.txtTotalII.TabStop = False
        Me.txtTotalII.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Label17.AutoSize = True
        Label17.Location = New System.Drawing.Point(509, 50)
        Label17.Name = "Label17"
        Label17.Size = New System.Drawing.Size(40, 13)
        Label17.TabIndex = 14
        Label17.Text = "Total II"
        '
        'txtObs
        '
        Me.txtObs.Location = New System.Drawing.Point(9, 23)
        Me.txtObs.MaxLength = 200
        Me.txtObs.Multiline = True
        Me.txtObs.Name = "txtObs"
        Me.txtObs.Size = New System.Drawing.Size(474, 47)
        Me.txtObs.TabIndex = 13
        '
        'Label9
        '
        Label9.AutoSize = True
        Label9.Location = New System.Drawing.Point(509, 17)
        Label9.Name = "Label9"
        Label9.Size = New System.Drawing.Size(44, 13)
        Label9.TabIndex = 12
        Label9.Text = "Total AI"
        '
        'txtTotalAI
        '
        Me.txtTotalAI.Location = New System.Drawing.Point(565, 14)
        Me.txtTotalAI.Name = "txtTotalAI"
        Me.txtTotalAI.ReadOnly = True
        Me.txtTotalAI.Size = New System.Drawing.Size(84, 20)
        Me.txtTotalAI.TabIndex = 5
        Me.txtTotalAI.TabStop = False
        Me.txtTotalAI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Label11.AutoSize = True
        Label11.Location = New System.Drawing.Point(6, 7)
        Label11.Name = "Label11"
        Label11.Size = New System.Drawing.Size(78, 13)
        Label11.TabIndex = 8
        Label11.Text = "Observaciones"
        '
        'cboExpreso
        '
        Me.cboExpreso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboExpreso.FormattingEnabled = True
        Me.cboExpreso.Location = New System.Drawing.Point(74, 153)
        Me.cboExpreso.Name = "cboExpreso"
        Me.cboExpreso.Size = New System.Drawing.Size(310, 21)
        Me.cboExpreso.TabIndex = 65
        '
        'Label26
        '
        Label26.AutoSize = True
        Label26.Location = New System.Drawing.Point(6, 156)
        Label26.Name = "Label26"
        Label26.Size = New System.Drawing.Size(45, 13)
        Label26.TabIndex = 66
        Label26.Text = "Expreso"
        '
        'frmCotizador
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1048, 554)
        Me.Controls.Add(SplitContainer1)
        Me.Name = "frmCotizador"
        Me.Tag = "frmCotizador"
        Me.Text = "Cotizador"
        SplitContainer1.Panel1.ResumeLayout(False)
        SplitContainer1.Panel1.PerformLayout()
        SplitContainer1.Panel2.ResumeLayout(False)
        SplitContainer1.ResumeLayout(False)
        CType(Me.dgv2, System.ComponentModel.ISupportInitialize).EndInit()
        SplitContainer2.Panel1.ResumeLayout(False)
        SplitContainer2.Panel1.PerformLayout()
        SplitContainer2.Panel2.ResumeLayout(False)
        SplitContainer2.ResumeLayout(False)
        CType(Me.pb, System.ComponentModel.ISupportInitialize).EndInit()
        SplitContainer3.Panel1.ResumeLayout(False)
        SplitContainer3.Panel2.ResumeLayout(False)
        SplitContainer3.Panel2.PerformLayout()
        SplitContainer3.ResumeLayout(False)
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents cboSociedad As System.Windows.Forms.ComboBox
    Friend WithEvents chkH As System.Windows.Forms.CheckBox
    Friend WithEvents txtBpcnam As System.Windows.Forms.TextBox
    Friend WithEvents cboEntrega As System.Windows.Forms.ComboBox
    Friend WithEvents txtFecha As System.Windows.Forms.TextBox
    Friend WithEvents txtNro As System.Windows.Forms.TextBox
    Friend WithEvents txtPedido As System.Windows.Forms.TextBox
    Friend WithEvents cboEstado As System.Windows.Forms.ComboBox
    Friend WithEvents txtTotalAI As System.Windows.Forms.TextBox
    Friend WithEvents cboFcRto As System.Windows.Forms.ComboBox
    Friend WithEvents dgv2 As System.Windows.Forms.DataGridView
    Friend WithEvents txtHasta2 As System.Windows.Forms.TextBox
    Friend WithEvents txtDesde2 As System.Windows.Forms.TextBox
    Friend WithEvents txtHasta1 As System.Windows.Forms.TextBox
    Friend WithEvents txtDesde1 As System.Windows.Forms.TextBox
    Friend WithEvents cboBuscarVend As System.Windows.Forms.ComboBox
    Friend WithEvents cboBuscarEstado As System.Windows.Forms.ComboBox
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents btnPedido As System.Windows.Forms.Button
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents btnNuevoPedido As System.Windows.Forms.Button
    Friend WithEvents txtObs As System.Windows.Forms.TextBox
    Friend WithEvents txtOC As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalII As System.Windows.Forms.TextBox
    Friend WithEvents btnPresu As System.Windows.Forms.Button
    Friend WithEvents txtPresupuesto As System.Windows.Forms.TextBox
    Friend WithEvents btnNuevoPresupuesto As System.Windows.Forms.Button
    Friend WithEvents cboTipo As System.Windows.Forms.ComboBox
    Friend WithEvents btnActualizar As System.Windows.Forms.Button
    Friend WithEvents txtMail_FC As System.Windows.Forms.TextBox
    Friend WithEvents txtPortero_celu As System.Windows.Forms.TextBox
    Friend WithEvents txtNombre_portero As System.Windows.Forms.TextBox
    Friend WithEvents txtNom_fanta As System.Windows.Forms.TextBox
    Friend WithEvents cboCondicionPago As System.Windows.Forms.ComboBox
    Friend WithEvents btnborrar As System.Windows.Forms.Button
    Friend WithEvents btnDuplicar As System.Windows.Forms.Button
    Friend WithEvents cboSucursal As System.Windows.Forms.ComboBox
    Friend WithEvents btn_examinar As System.Windows.Forms.Button
    Friend WithEvents pb As System.Windows.Forms.PictureBox
    Friend WithEvents btver As System.Windows.Forms.Button
    Friend WithEvents btborrar As System.Windows.Forms.Button
    Friend WithEvents colNro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colLinea As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCodigo As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colDescripcion As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colCant As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPrecio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSugerido As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTotal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chkpresu As System.Windows.Forms.CheckBox
    Friend WithEvents chkrecargas As System.Windows.Forms.CheckBox
    Friend WithEvents txtboxNumAnterior As System.Windows.Forms.TextBox
    Friend WithEvents col2Nro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col2Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col2Cliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents suc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col2Nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col2Vend As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chkOC As System.Windows.Forms.CheckBox
    Friend WithEvents cboExpreso As System.Windows.Forms.ComboBox
End Class
