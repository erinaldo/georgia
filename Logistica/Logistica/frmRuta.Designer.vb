<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRuta
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
        Dim Label2 As System.Windows.Forms.Label
        Dim Label1 As System.Windows.Forms.Label
        Dim Label3 As System.Windows.Forms.Label
        Dim Label4 As System.Windows.Forms.Label
        Dim Label5 As System.Windows.Forms.Label
        Dim Label7 As System.Windows.Forms.Label
        Dim Label8 As System.Windows.Forms.Label
        Dim Label13 As System.Windows.Forms.Label
        Dim Label12 As System.Windows.Forms.Label
        Dim Label11 As System.Windows.Forms.Label
        Dim Label14 As System.Windows.Forms.Label
        Dim Label15 As System.Windows.Forms.Label
        Dim Label16 As System.Windows.Forms.Label
        Dim Label17 As System.Windows.Forms.Label
        Dim Label18 As System.Windows.Forms.Label
        Dim Label19 As System.Windows.Forms.Label
        Dim Label6 As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRuta))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.lstTransportes = New System.Windows.Forms.ListBox
        Me.lstVehiculos = New System.Windows.Forms.ListBox
        Me.cboAcompante1 = New System.Windows.Forms.ComboBox
        Me.cboAcompante2 = New System.Windows.Forms.ComboBox
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker
        Me.txtDescripcion = New System.Windows.Forms.TextBox
        Me.txtVarios = New System.Windows.Forms.TextBox
        Me.txtRuta = New System.Windows.Forms.TextBox
        Me.nudPrestamosExt = New System.Windows.Forms.NumericUpDown
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtPrestamosExtR = New System.Windows.Forms.TextBox
        Me.txtPrestamosExtE = New System.Windows.Forms.TextBox
        Me.txtBuscar = New System.Windows.Forms.TextBox
        Me.mnuContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuVerDocumento = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuRelevamiento = New System.Windows.Forms.ToolStripMenuItem
        Me.Tool = New System.Windows.Forms.ToolStrip
        Me.toolNuevo = New System.Windows.Forms.ToolStripButton
        Me.toolAbrir = New System.Windows.Forms.ToolStripButton
        Me.toolGrabar = New System.Windows.Forms.ToolStripButton
        Me.toolDeshacer = New System.Windows.Forms.ToolStripButton
        Me.tooBorrar = New System.Windows.Forms.ToolStripButton
        Me.toolImprimir = New System.Windows.Forms.ToolStripButton
        Me.toolPreparacion2 = New System.Windows.Forms.ToolStripButton
        Me.toolPreparacion = New System.Windows.Forms.ToolStripButton
        Me.ToolGenEtiqu = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.tooTarea = New System.Windows.Forms.ToolStripButton
        Me.Grilla = New System.Windows.Forms.DataGridView
        Me.colRuta = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colOrden = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colSuc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colDomicilio = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colLocalidad = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCliente = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colNombre = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colTipo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colDocumento = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colEquipos = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colMangas = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colPrestamoExt = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colPrestamoMan = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colInstalaciones = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colRetencion1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colRetencion2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colRechazoExt = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colRechazoMan = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCobranza = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.colVarios = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.colPrioridad = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.colHorario = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colPeso = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colEstado = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colNoConform = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colObs = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtPrestamosManR = New System.Windows.Forms.TextBox
        Me.txtPrestamosManE = New System.Windows.Forms.TextBox
        Me.nudPrestamosMan = New System.Windows.Forms.NumericUpDown
        Me.cboAcompante3 = New System.Windows.Forms.ComboBox
        Me.cboZonas = New System.Windows.Forms.ComboBox
        Me.btnZonaSelec = New System.Windows.Forms.Button
        Me.dgvZonas = New System.Windows.Forms.DataGridView
        Me.col3Itn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col3Cant = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col3Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnCamioneta = New System.Windows.Forms.Button
        Me.btnCourier = New System.Windows.Forms.Button
        Me.chkMicrocentro = New System.Windows.Forms.CheckBox
        Me.btnEnviar = New System.Windows.Forms.Button
        Me.cboRelevador = New System.Windows.Forms.ComboBox
        Label2 = New System.Windows.Forms.Label
        Label1 = New System.Windows.Forms.Label
        Label3 = New System.Windows.Forms.Label
        Label4 = New System.Windows.Forms.Label
        Label5 = New System.Windows.Forms.Label
        Label7 = New System.Windows.Forms.Label
        Label8 = New System.Windows.Forms.Label
        Label13 = New System.Windows.Forms.Label
        Label12 = New System.Windows.Forms.Label
        Label11 = New System.Windows.Forms.Label
        Label14 = New System.Windows.Forms.Label
        Label15 = New System.Windows.Forms.Label
        Label16 = New System.Windows.Forms.Label
        Label17 = New System.Windows.Forms.Label
        Label18 = New System.Windows.Forms.Label
        Label19 = New System.Windows.Forms.Label
        Label6 = New System.Windows.Forms.Label
        CType(Me.nudPrestamosExt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.mnuContextMenu.SuspendLayout()
        Me.Tool.SuspendLayout()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.nudPrestamosMan, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvZonas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Label2.AutoSize = True
        Label2.Location = New System.Drawing.Point(818, 35)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(40, 13)
        Label2.TabIndex = 3
        Label2.Text = "Fecha:"
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(9, 35)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(96, 13)
        Label1.TabIndex = 1
        Label1.Text = "Nro. Hoja de Ruta:"
        '
        'Label3
        '
        Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Label3.AutoSize = True
        Label3.Location = New System.Drawing.Point(779, 304)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(61, 13)
        Label3.TabIndex = 9
        Label3.Text = "Transporte:"
        '
        'Label4
        '
        Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Label4.AutoSize = True
        Label4.Location = New System.Drawing.Point(779, 444)
        Label4.Name = "Label4"
        Label4.Size = New System.Drawing.Size(53, 13)
        Label4.TabIndex = 12
        Label4.Text = "Vehículo:"
        '
        'Label5
        '
        Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Label5.AutoSize = True
        Label5.Location = New System.Drawing.Point(497, 439)
        Label5.Name = "Label5"
        Label5.Size = New System.Drawing.Size(122, 13)
        Label5.TabIndex = 20
        Label5.Text = "Segundo Acompañante:"
        '
        'Label7
        '
        Label7.AutoSize = True
        Label7.Location = New System.Drawing.Point(9, 61)
        Label7.Name = "Label7"
        Label7.Size = New System.Drawing.Size(66, 13)
        Label7.TabIndex = 7
        Label7.Text = "Descripción:"
        '
        'Label8
        '
        Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Label8.AutoSize = True
        Label8.Location = New System.Drawing.Point(15, 386)
        Label8.Name = "Label8"
        Label8.Size = New System.Drawing.Size(39, 13)
        Label8.TabIndex = 14
        Label8.Text = "Varios:"
        '
        'Label13
        '
        Label13.AutoSize = True
        Label13.Location = New System.Drawing.Point(31, 81)
        Label13.Name = "Label13"
        Label13.Size = New System.Drawing.Size(65, 13)
        Label13.TabIndex = 4
        Label13.Text = "A recuperar:"
        '
        'Label12
        '
        Label12.AutoSize = True
        Label12.Location = New System.Drawing.Point(31, 28)
        Label12.Name = "Label12"
        Label12.Size = New System.Drawing.Size(39, 13)
        Label12.TabIndex = 0
        Label12.Text = "Salida:"
        '
        'Label11
        '
        Label11.AutoSize = True
        Label11.Location = New System.Drawing.Point(31, 55)
        Label11.Name = "Label11"
        Label11.Size = New System.Drawing.Size(59, 13)
        Label11.TabIndex = 2
        Label11.Text = "A entregar:"
        '
        'Label14
        '
        Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Label14.AutoSize = True
        Label14.Location = New System.Drawing.Point(515, 35)
        Label14.Name = "Label14"
        Label14.Size = New System.Drawing.Size(65, 13)
        Label14.TabIndex = 5
        Label14.Text = "Documento:"
        '
        'Label15
        '
        Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Label15.AutoSize = True
        Label15.Location = New System.Drawing.Point(483, 412)
        Label15.Name = "Label15"
        Label15.Size = New System.Drawing.Size(136, 13)
        Label15.TabIndex = 18
        Label15.Text = "Responsable de Recorrido:"
        '
        'Label16
        '
        Label16.AutoSize = True
        Label16.Location = New System.Drawing.Point(31, 81)
        Label16.Name = "Label16"
        Label16.Size = New System.Drawing.Size(65, 13)
        Label16.TabIndex = 4
        Label16.Text = "A recuperar:"
        '
        'Label17
        '
        Label17.AutoSize = True
        Label17.Location = New System.Drawing.Point(31, 28)
        Label17.Name = "Label17"
        Label17.Size = New System.Drawing.Size(39, 13)
        Label17.TabIndex = 0
        Label17.Text = "Salida:"
        '
        'Label18
        '
        Label18.AutoSize = True
        Label18.Location = New System.Drawing.Point(31, 55)
        Label18.Name = "Label18"
        Label18.Size = New System.Drawing.Size(59, 13)
        Label18.TabIndex = 2
        Label18.Text = "A entregar:"
        '
        'Label19
        '
        Label19.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Label19.AutoSize = True
        Label19.Location = New System.Drawing.Point(509, 467)
        Label19.Name = "Label19"
        Label19.Size = New System.Drawing.Size(110, 13)
        Label19.TabIndex = 31
        Label19.Text = "Tercer Acompañante:"
        '
        'Label6
        '
        Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Label6.AutoSize = True
        Label6.Location = New System.Drawing.Point(448, 507)
        Label6.Name = "Label6"
        Label6.Size = New System.Drawing.Size(59, 13)
        Label6.TabIndex = 42
        Label6.Text = "Relevador:"
        '
        'lstTransportes
        '
        Me.lstTransportes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstTransportes.FormattingEnabled = True
        Me.lstTransportes.Location = New System.Drawing.Point(779, 320)
        Me.lstTransportes.Name = "lstTransportes"
        Me.lstTransportes.Size = New System.Drawing.Size(225, 121)
        Me.lstTransportes.TabIndex = 10
        '
        'lstVehiculos
        '
        Me.lstVehiculos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstVehiculos.FormattingEnabled = True
        Me.lstVehiculos.Location = New System.Drawing.Point(779, 463)
        Me.lstVehiculos.Name = "lstVehiculos"
        Me.lstVehiculos.Size = New System.Drawing.Size(225, 69)
        Me.lstVehiculos.TabIndex = 13
        '
        'cboAcompante1
        '
        Me.cboAcompante1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboAcompante1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAcompante1.FormattingEnabled = True
        Me.cboAcompante1.Location = New System.Drawing.Point(625, 409)
        Me.cboAcompante1.Name = "cboAcompante1"
        Me.cboAcompante1.Size = New System.Drawing.Size(143, 21)
        Me.cboAcompante1.TabIndex = 19
        '
        'cboAcompante2
        '
        Me.cboAcompante2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboAcompante2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAcompante2.FormattingEnabled = True
        Me.cboAcompante2.Location = New System.Drawing.Point(625, 436)
        Me.cboAcompante2.Name = "cboAcompante2"
        Me.cboAcompante2.Size = New System.Drawing.Size(143, 21)
        Me.cboAcompante2.TabIndex = 21
        '
        'dtpFecha
        '
        Me.dtpFecha.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(867, 34)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(96, 20)
        Me.dtpFecha.TabIndex = 4
        Me.dtpFecha.Value = New Date(2009, 6, 2, 0, 0, 0, 0)
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDescripcion.Location = New System.Drawing.Point(111, 58)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(657, 20)
        Me.txtDescripcion.TabIndex = 8
        '
        'txtVarios
        '
        Me.txtVarios.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtVarios.Location = New System.Drawing.Point(60, 383)
        Me.txtVarios.Name = "txtVarios"
        Me.txtVarios.Size = New System.Drawing.Size(708, 20)
        Me.txtVarios.TabIndex = 15
        '
        'txtRuta
        '
        Me.txtRuta.Location = New System.Drawing.Point(111, 31)
        Me.txtRuta.Name = "txtRuta"
        Me.txtRuta.ReadOnly = True
        Me.txtRuta.Size = New System.Drawing.Size(78, 20)
        Me.txtRuta.TabIndex = 2
        Me.txtRuta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'nudPrestamosExt
        '
        Me.nudPrestamosExt.Location = New System.Drawing.Point(140, 26)
        Me.nudPrestamosExt.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
        Me.nudPrestamosExt.Name = "nudPrestamosExt"
        Me.nudPrestamosExt.Size = New System.Drawing.Size(48, 20)
        Me.nudPrestamosExt.TabIndex = 1
        Me.nudPrestamosExt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Label13)
        Me.GroupBox1.Controls.Add(Me.txtPrestamosExtR)
        Me.GroupBox1.Controls.Add(Label12)
        Me.GroupBox1.Controls.Add(Label11)
        Me.GroupBox1.Controls.Add(Me.txtPrestamosExtE)
        Me.GroupBox1.Controls.Add(Me.nudPrestamosExt)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 412)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(210, 115)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Préstamos Extintores"
        '
        'txtPrestamosExtR
        '
        Me.txtPrestamosExtR.Location = New System.Drawing.Point(140, 78)
        Me.txtPrestamosExtR.Name = "txtPrestamosExtR"
        Me.txtPrestamosExtR.ReadOnly = True
        Me.txtPrestamosExtR.Size = New System.Drawing.Size(33, 20)
        Me.txtPrestamosExtR.TabIndex = 5
        Me.txtPrestamosExtR.Text = "0"
        Me.txtPrestamosExtR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPrestamosExtE
        '
        Me.txtPrestamosExtE.Location = New System.Drawing.Point(140, 52)
        Me.txtPrestamosExtE.Name = "txtPrestamosExtE"
        Me.txtPrestamosExtE.ReadOnly = True
        Me.txtPrestamosExtE.Size = New System.Drawing.Size(33, 20)
        Me.txtPrestamosExtE.TabIndex = 3
        Me.txtPrestamosExtE.Text = "0"
        Me.txtPrestamosExtE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtBuscar
        '
        Me.txtBuscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBuscar.Location = New System.Drawing.Point(586, 32)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(182, 20)
        Me.txtBuscar.TabIndex = 6
        '
        'mnuContextMenu
        '
        Me.mnuContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuVerDocumento, Me.mnuRelevamiento})
        Me.mnuContextMenu.Name = "ContextMenu"
        Me.mnuContextMenu.Size = New System.Drawing.Size(196, 48)
        '
        'mnuVerDocumento
        '
        Me.mnuVerDocumento.Name = "mnuVerDocumento"
        Me.mnuVerDocumento.Size = New System.Drawing.Size(195, 22)
        Me.mnuVerDocumento.Text = "Ver documento"
        '
        'mnuRelevamiento
        '
        Me.mnuRelevamiento.Name = "mnuRelevamiento"
        Me.mnuRelevamiento.Size = New System.Drawing.Size(195, 22)
        Me.mnuRelevamiento.Text = "Imprimir Relevamiento"
        '
        'Tool
        '
        Me.Tool.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolNuevo, Me.toolAbrir, Me.toolGrabar, Me.toolDeshacer, Me.tooBorrar, Me.toolImprimir, Me.toolPreparacion2, Me.toolPreparacion, Me.ToolGenEtiqu, Me.ToolStripSeparator1, Me.tooTarea})
        Me.Tool.Location = New System.Drawing.Point(0, 0)
        Me.Tool.Name = "Tool"
        Me.Tool.Size = New System.Drawing.Size(1016, 25)
        Me.Tool.TabIndex = 0
        '
        'toolNuevo
        '
        Me.toolNuevo.Image = CType(resources.GetObject("toolNuevo.Image"), System.Drawing.Image)
        Me.toolNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolNuevo.Name = "toolNuevo"
        Me.toolNuevo.Size = New System.Drawing.Size(62, 22)
        Me.toolNuevo.Text = "Nuevo"
        '
        'toolAbrir
        '
        Me.toolAbrir.Image = CType(resources.GetObject("toolAbrir.Image"), System.Drawing.Image)
        Me.toolAbrir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolAbrir.Name = "toolAbrir"
        Me.toolAbrir.Size = New System.Drawing.Size(53, 22)
        Me.toolAbrir.Text = "Abrir"
        '
        'toolGrabar
        '
        Me.toolGrabar.Enabled = False
        Me.toolGrabar.Image = CType(resources.GetObject("toolGrabar.Image"), System.Drawing.Image)
        Me.toolGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolGrabar.Name = "toolGrabar"
        Me.toolGrabar.Size = New System.Drawing.Size(62, 22)
        Me.toolGrabar.Text = "Grabar"
        '
        'toolDeshacer
        '
        Me.toolDeshacer.Enabled = False
        Me.toolDeshacer.Image = CType(resources.GetObject("toolDeshacer.Image"), System.Drawing.Image)
        Me.toolDeshacer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolDeshacer.Name = "toolDeshacer"
        Me.toolDeshacer.Size = New System.Drawing.Size(75, 22)
        Me.toolDeshacer.Text = "Deshacer"
        '
        'tooBorrar
        '
        Me.tooBorrar.Enabled = False
        Me.tooBorrar.Image = CType(resources.GetObject("tooBorrar.Image"), System.Drawing.Image)
        Me.tooBorrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tooBorrar.Name = "tooBorrar"
        Me.tooBorrar.Size = New System.Drawing.Size(86, 22)
        Me.tooBorrar.Text = "Borrar Ruta"
        '
        'toolImprimir
        '
        Me.toolImprimir.Enabled = False
        Me.toolImprimir.Image = CType(resources.GetObject("toolImprimir.Image"), System.Drawing.Image)
        Me.toolImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolImprimir.Name = "toolImprimir"
        Me.toolImprimir.Size = New System.Drawing.Size(100, 22)
        Me.toolImprimir.Text = "Imprimir Ruta"
        '
        'toolPreparacion2
        '
        Me.toolPreparacion2.Enabled = False
        Me.toolPreparacion2.Image = CType(resources.GetObject("toolPreparacion2.Image"), System.Drawing.Image)
        Me.toolPreparacion2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolPreparacion2.Name = "toolPreparacion2"
        Me.toolPreparacion2.Size = New System.Drawing.Size(187, 22)
        Me.toolPreparacion2.Text = "Imprimir Preparación (Service)"
        '
        'toolPreparacion
        '
        Me.toolPreparacion.Enabled = False
        Me.toolPreparacion.Image = CType(resources.GetObject("toolPreparacion.Image"), System.Drawing.Image)
        Me.toolPreparacion.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolPreparacion.Name = "toolPreparacion"
        Me.toolPreparacion.Size = New System.Drawing.Size(190, 22)
        Me.toolPreparacion.Text = "Imprimir Preparación (Nuevos)"
        '
        'ToolGenEtiqu
        '
        Me.ToolGenEtiqu.Enabled = False
        Me.ToolGenEtiqu.Image = CType(resources.GetObject("ToolGenEtiqu.Image"), System.Drawing.Image)
        Me.ToolGenEtiqu.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolGenEtiqu.Name = "ToolGenEtiqu"
        Me.ToolGenEtiqu.Size = New System.Drawing.Size(75, 22)
        Me.ToolGenEtiqu.Text = "Etiquetas"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'tooTarea
        '
        Me.tooTarea.Enabled = False
        Me.tooTarea.Image = CType(resources.GetObject("tooTarea.Image"), System.Drawing.Image)
        Me.tooTarea.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tooTarea.Name = "tooTarea"
        Me.tooTarea.Size = New System.Drawing.Size(101, 22)
        Me.tooTarea.Text = "Agregar Tarea"
        '
        'Grilla
        '
        Me.Grilla.AllowUserToAddRows = False
        Me.Grilla.AllowUserToDeleteRows = False
        Me.Grilla.AllowUserToResizeRows = False
        Me.Grilla.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grilla.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colRuta, Me.colOrden, Me.colSuc, Me.colDomicilio, Me.colLocalidad, Me.colCliente, Me.colNombre, Me.colTipo, Me.colDocumento, Me.colEquipos, Me.colMangas, Me.colPrestamoExt, Me.colPrestamoMan, Me.colInstalaciones, Me.colRetencion1, Me.colRetencion2, Me.colRechazoExt, Me.colRechazoMan, Me.colCobranza, Me.colVarios, Me.colPrioridad, Me.colHorario, Me.colPeso, Me.colEstado, Me.colNoConform, Me.colObs})
        Me.Grilla.ContextMenuStrip = Me.mnuContextMenu
        Me.Grilla.Location = New System.Drawing.Point(12, 84)
        Me.Grilla.Name = "Grilla"
        Me.Grilla.RowHeadersVisible = False
        Me.Grilla.Size = New System.Drawing.Size(756, 293)
        Me.Grilla.TabIndex = 29
        '
        'colRuta
        '
        Me.colRuta.HeaderText = "Ruta"
        Me.colRuta.Name = "colRuta"
        Me.colRuta.Visible = False
        '
        'colOrden
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colOrden.DefaultCellStyle = DataGridViewCellStyle1
        Me.colOrden.HeaderText = "Orden"
        Me.colOrden.Name = "colOrden"
        Me.colOrden.Width = 40
        '
        'colSuc
        '
        Me.colSuc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colSuc.HeaderText = "Suc"
        Me.colSuc.Name = "colSuc"
        Me.colSuc.ReadOnly = True
        Me.colSuc.Width = 51
        '
        'colDomicilio
        '
        Me.colDomicilio.HeaderText = "Domicilio"
        Me.colDomicilio.Name = "colDomicilio"
        Me.colDomicilio.ReadOnly = True
        '
        'colLocalidad
        '
        Me.colLocalidad.HeaderText = "Localidad"
        Me.colLocalidad.Name = "colLocalidad"
        Me.colLocalidad.ReadOnly = True
        '
        'colCliente
        '
        Me.colCliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colCliente.HeaderText = "Cliente"
        Me.colCliente.Name = "colCliente"
        Me.colCliente.ReadOnly = True
        Me.colCliente.Width = 64
        '
        'colNombre
        '
        Me.colNombre.HeaderText = "Nombre"
        Me.colNombre.Name = "colNombre"
        Me.colNombre.ReadOnly = True
        '
        'colTipo
        '
        Me.colTipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colTipo.HeaderText = "Tipo"
        Me.colTipo.Name = "colTipo"
        Me.colTipo.ReadOnly = True
        Me.colTipo.Width = 53
        '
        'colDocumento
        '
        Me.colDocumento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colDocumento.HeaderText = "Documento"
        Me.colDocumento.Name = "colDocumento"
        Me.colDocumento.ReadOnly = True
        Me.colDocumento.Width = 87
        '
        'colEquipos
        '
        Me.colEquipos.HeaderText = "Extintores"
        Me.colEquipos.Name = "colEquipos"
        Me.colEquipos.ReadOnly = True
        Me.colEquipos.Width = 60
        '
        'colMangas
        '
        Me.colMangas.HeaderText = "Mangueras"
        Me.colMangas.Name = "colMangas"
        Me.colMangas.ReadOnly = True
        '
        'colPrestamoExt
        '
        Me.colPrestamoExt.HeaderText = "Extintores Préstamos"
        Me.colPrestamoExt.Name = "colPrestamoExt"
        Me.colPrestamoExt.ReadOnly = True
        Me.colPrestamoExt.Width = 60
        '
        'colPrestamoMan
        '
        Me.colPrestamoMan.HeaderText = "Mangueras Préstamo"
        Me.colPrestamoMan.Name = "colPrestamoMan"
        Me.colPrestamoMan.ReadOnly = True
        '
        'colInstalaciones
        '
        Me.colInstalaciones.HeaderText = "Instalación"
        Me.colInstalaciones.Name = "colInstalaciones"
        Me.colInstalaciones.ReadOnly = True
        Me.colInstalaciones.Width = 60
        '
        'colRetencion1
        '
        Me.colRetencion1.HeaderText = "Retencion Extintor"
        Me.colRetencion1.Name = "colRetencion1"
        Me.colRetencion1.ReadOnly = True
        Me.colRetencion1.Visible = False
        '
        'colRetencion2
        '
        Me.colRetencion2.HeaderText = "Retencion Manguera"
        Me.colRetencion2.Name = "colRetencion2"
        Me.colRetencion2.ReadOnly = True
        Me.colRetencion2.Visible = False
        '
        'colRechazoExt
        '
        Me.colRechazoExt.HeaderText = "Extintores Rechazados"
        Me.colRechazoExt.Name = "colRechazoExt"
        Me.colRechazoExt.ReadOnly = True
        Me.colRechazoExt.Width = 60
        '
        'colRechazoMan
        '
        Me.colRechazoMan.HeaderText = "Mangueras Rechazadas"
        Me.colRechazoMan.Name = "colRechazoMan"
        Me.colRechazoMan.ReadOnly = True
        '
        'colCobranza
        '
        Me.colCobranza.FalseValue = "0"
        Me.colCobranza.HeaderText = "Cobranza"
        Me.colCobranza.Name = "colCobranza"
        Me.colCobranza.ReadOnly = True
        Me.colCobranza.TrueValue = "1"
        Me.colCobranza.Width = 60
        '
        'colVarios
        '
        Me.colVarios.FalseValue = "0"
        Me.colVarios.HeaderText = "Varios"
        Me.colVarios.Name = "colVarios"
        Me.colVarios.ReadOnly = True
        Me.colVarios.TrueValue = "1"
        Me.colVarios.Width = 60
        '
        'colPrioridad
        '
        Me.colPrioridad.FalseValue = "0"
        Me.colPrioridad.HeaderText = "Prioridad"
        Me.colPrioridad.Name = "colPrioridad"
        Me.colPrioridad.TrueValue = "1"
        Me.colPrioridad.Width = 60
        '
        'colHorario
        '
        Me.colHorario.HeaderText = "Horario"
        Me.colHorario.Name = "colHorario"
        Me.colHorario.ReadOnly = True
        '
        'colPeso
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colPeso.DefaultCellStyle = DataGridViewCellStyle2
        Me.colPeso.HeaderText = "Peso (Kg)"
        Me.colPeso.Name = "colPeso"
        Me.colPeso.ReadOnly = True
        Me.colPeso.Width = 80
        '
        'colEstado
        '
        Me.colEstado.HeaderText = "Estado"
        Me.colEstado.Name = "colEstado"
        Me.colEstado.Visible = False
        '
        'colNoConform
        '
        Me.colNoConform.HeaderText = "Rebote"
        Me.colNoConform.Name = "colNoConform"
        Me.colNoConform.Visible = False
        '
        'colObs
        '
        Me.colObs.HeaderText = "Observaciones"
        Me.colObs.Name = "colObs"
        Me.colObs.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Label16)
        Me.GroupBox2.Controls.Add(Me.txtPrestamosManR)
        Me.GroupBox2.Controls.Add(Label17)
        Me.GroupBox2.Controls.Add(Label18)
        Me.GroupBox2.Controls.Add(Me.txtPrestamosManE)
        Me.GroupBox2.Controls.Add(Me.nudPrestamosMan)
        Me.GroupBox2.Location = New System.Drawing.Point(232, 412)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(210, 115)
        Me.GroupBox2.TabIndex = 17
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Préstamos Mangueras"
        '
        'txtPrestamosManR
        '
        Me.txtPrestamosManR.Location = New System.Drawing.Point(140, 78)
        Me.txtPrestamosManR.Name = "txtPrestamosManR"
        Me.txtPrestamosManR.ReadOnly = True
        Me.txtPrestamosManR.Size = New System.Drawing.Size(33, 20)
        Me.txtPrestamosManR.TabIndex = 5
        Me.txtPrestamosManR.Text = "0"
        Me.txtPrestamosManR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPrestamosManE
        '
        Me.txtPrestamosManE.Location = New System.Drawing.Point(140, 52)
        Me.txtPrestamosManE.Name = "txtPrestamosManE"
        Me.txtPrestamosManE.ReadOnly = True
        Me.txtPrestamosManE.Size = New System.Drawing.Size(33, 20)
        Me.txtPrestamosManE.TabIndex = 3
        Me.txtPrestamosManE.Text = "0"
        Me.txtPrestamosManE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'nudPrestamosMan
        '
        Me.nudPrestamosMan.Location = New System.Drawing.Point(140, 26)
        Me.nudPrestamosMan.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
        Me.nudPrestamosMan.Name = "nudPrestamosMan"
        Me.nudPrestamosMan.Size = New System.Drawing.Size(48, 20)
        Me.nudPrestamosMan.TabIndex = 1
        Me.nudPrestamosMan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboAcompante3
        '
        Me.cboAcompante3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboAcompante3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAcompante3.FormattingEnabled = True
        Me.cboAcompante3.Location = New System.Drawing.Point(625, 463)
        Me.cboAcompante3.Name = "cboAcompante3"
        Me.cboAcompante3.Size = New System.Drawing.Size(143, 21)
        Me.cboAcompante3.TabIndex = 30
        '
        'cboZonas
        '
        Me.cboZonas.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboZonas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboZonas.FormattingEnabled = True
        Me.cboZonas.Location = New System.Drawing.Point(779, 57)
        Me.cboZonas.Name = "cboZonas"
        Me.cboZonas.Size = New System.Drawing.Size(225, 21)
        Me.cboZonas.TabIndex = 32
        '
        'btnZonaSelec
        '
        Me.btnZonaSelec.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnZonaSelec.Location = New System.Drawing.Point(779, 270)
        Me.btnZonaSelec.Name = "btnZonaSelec"
        Me.btnZonaSelec.Size = New System.Drawing.Size(222, 23)
        Me.btnZonaSelec.TabIndex = 35
        Me.btnZonaSelec.Text = "Agregar Seleccion"
        Me.btnZonaSelec.UseVisualStyleBackColor = True
        '
        'dgvZonas
        '
        Me.dgvZonas.AllowUserToAddRows = False
        Me.dgvZonas.AllowUserToDeleteRows = False
        Me.dgvZonas.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvZonas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvZonas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col3Itn, Me.col3Cant, Me.col3Fecha})
        Me.dgvZonas.Location = New System.Drawing.Point(774, 120)
        Me.dgvZonas.Name = "dgvZonas"
        Me.dgvZonas.ReadOnly = True
        Me.dgvZonas.RowHeadersVisible = False
        Me.dgvZonas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvZonas.Size = New System.Drawing.Size(230, 144)
        Me.dgvZonas.TabIndex = 36
        '
        'col3Itn
        '
        Me.col3Itn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.col3Itn.HeaderText = "Intervención"
        Me.col3Itn.Name = "col3Itn"
        Me.col3Itn.ReadOnly = True
        Me.col3Itn.Width = 91
        '
        'col3Cant
        '
        Me.col3Cant.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.col3Cant.DefaultCellStyle = DataGridViewCellStyle3
        Me.col3Cant.HeaderText = "Cant"
        Me.col3Cant.Name = "col3Cant"
        Me.col3Cant.ReadOnly = True
        Me.col3Cant.Width = 54
        '
        'col3Fecha
        '
        Me.col3Fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.col3Fecha.HeaderText = "Fecha"
        Me.col3Fecha.Name = "col3Fecha"
        Me.col3Fecha.ReadOnly = True
        Me.col3Fecha.Width = 62
        '
        'btnCamioneta
        '
        Me.btnCamioneta.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCamioneta.Location = New System.Drawing.Point(779, 84)
        Me.btnCamioneta.Name = "btnCamioneta"
        Me.btnCamioneta.Size = New System.Drawing.Size(106, 23)
        Me.btnCamioneta.TabIndex = 37
        Me.btnCamioneta.Text = "Camioneta"
        Me.btnCamioneta.UseVisualStyleBackColor = True
        '
        'btnCourier
        '
        Me.btnCourier.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCourier.Location = New System.Drawing.Point(906, 84)
        Me.btnCourier.Name = "btnCourier"
        Me.btnCourier.Size = New System.Drawing.Size(95, 23)
        Me.btnCourier.TabIndex = 38
        Me.btnCourier.Text = "Courier"
        Me.btnCourier.UseVisualStyleBackColor = True
        '
        'chkMicrocentro
        '
        Me.chkMicrocentro.AutoSize = True
        Me.chkMicrocentro.Location = New System.Drawing.Point(208, 33)
        Me.chkMicrocentro.Name = "chkMicrocentro"
        Me.chkMicrocentro.Size = New System.Drawing.Size(82, 17)
        Me.chkMicrocentro.TabIndex = 39
        Me.chkMicrocentro.Text = "Microcentro"
        Me.chkMicrocentro.UseVisualStyleBackColor = True
        '
        'btnEnviar
        '
        Me.btnEnviar.Location = New System.Drawing.Point(693, 504)
        Me.btnEnviar.Name = "btnEnviar"
        Me.btnEnviar.Size = New System.Drawing.Size(75, 23)
        Me.btnEnviar.TabIndex = 40
        Me.btnEnviar.Text = "Enviar"
        Me.btnEnviar.UseVisualStyleBackColor = True
        '
        'cboRelevador
        '
        Me.cboRelevador.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboRelevador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRelevador.FormattingEnabled = True
        Me.cboRelevador.Location = New System.Drawing.Point(510, 504)
        Me.cboRelevador.Name = "cboRelevador"
        Me.cboRelevador.Size = New System.Drawing.Size(177, 21)
        Me.cboRelevador.TabIndex = 41
        '
        'frmRuta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1016, 547)
        Me.Controls.Add(Me.cboRelevador)
        Me.Controls.Add(Me.chkMicrocentro)
        Me.Controls.Add(Label6)
        Me.Controls.Add(Me.btnEnviar)
        Me.Controls.Add(Me.btnCourier)
        Me.Controls.Add(Me.dgvZonas)
        Me.Controls.Add(Me.btnCamioneta)
        Me.Controls.Add(Me.cboZonas)
        Me.Controls.Add(Me.btnZonaSelec)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Grilla)
        Me.Controls.Add(Label19)
        Me.Controls.Add(Me.cboAcompante3)
        Me.Controls.Add(Me.Tool)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtRuta)
        Me.Controls.Add(Label15)
        Me.Controls.Add(Me.txtVarios)
        Me.Controls.Add(Label14)
        Me.Controls.Add(Me.txtBuscar)
        Me.Controls.Add(Label8)
        Me.Controls.Add(Me.txtDescripcion)
        Me.Controls.Add(Label7)
        Me.Controls.Add(Me.dtpFecha)
        Me.Controls.Add(Me.cboAcompante2)
        Me.Controls.Add(Label4)
        Me.Controls.Add(Me.cboAcompante1)
        Me.Controls.Add(Label5)
        Me.Controls.Add(Me.lstVehiculos)
        Me.Controls.Add(Me.lstTransportes)
        Me.Controls.Add(Label1)
        Me.Controls.Add(Label2)
        Me.Controls.Add(Label3)
        Me.Name = "frmRuta"
        Me.Tag = "Hoja de Ruta"
        Me.Text = "frmRuta"
        CType(Me.nudPrestamosExt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.mnuContextMenu.ResumeLayout(False)
        Me.Tool.ResumeLayout(False)
        Me.Tool.PerformLayout()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.nudPrestamosMan, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvZonas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lstTransportes As System.Windows.Forms.ListBox
    Friend WithEvents lstVehiculos As System.Windows.Forms.ListBox
    Friend WithEvents cboAcompante1 As System.Windows.Forms.ComboBox
    Friend WithEvents cboAcompante2 As System.Windows.Forms.ComboBox
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents txtVarios As System.Windows.Forms.TextBox
    Friend WithEvents txtRuta As System.Windows.Forms.TextBox
    Friend WithEvents nudPrestamosExt As System.Windows.Forms.NumericUpDown
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtPrestamosExtE As System.Windows.Forms.TextBox
    Friend WithEvents txtPrestamosExtR As System.Windows.Forms.TextBox
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents mnuContextMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuVerDocumento As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Tool As System.Windows.Forms.ToolStrip
    Friend WithEvents toolNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolAbrir As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolGrabar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolDeshacer As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents Grilla As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tooTarea As System.Windows.Forms.ToolStripButton
    Friend WithEvents tooBorrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtPrestamosManR As System.Windows.Forms.TextBox
    Friend WithEvents txtPrestamosManE As System.Windows.Forms.TextBox
    Friend WithEvents nudPrestamosMan As System.Windows.Forms.NumericUpDown
    Friend WithEvents cboAcompante3 As System.Windows.Forms.ComboBox
    Friend WithEvents toolPreparacion As System.Windows.Forms.ToolStripButton
    Friend WithEvents colRuta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOrden As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSuc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDomicilio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colLocalidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDocumento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colEquipos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMangas As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPrestamoExt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPrestamoMan As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colInstalaciones As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRetencion1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRetencion2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRechazoExt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRechazoMan As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCobranza As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colVarios As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colPrioridad As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colHorario As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPeso As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colEstado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNoConform As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colObs As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents mnuRelevamiento As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolPreparacion2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents cboZonas As System.Windows.Forms.ComboBox
    Friend WithEvents btnZonaSelec As System.Windows.Forms.Button
    Friend WithEvents dgvZonas As System.Windows.Forms.DataGridView
    Friend WithEvents btnCamioneta As System.Windows.Forms.Button
    Friend WithEvents btnCourier As System.Windows.Forms.Button
    Friend WithEvents col3Itn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col3Cant As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col3Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToolGenEtiqu As System.Windows.Forms.ToolStripButton
    Friend WithEvents chkMicrocentro As System.Windows.Forms.CheckBox
    Friend WithEvents btnEnviar As System.Windows.Forms.Button
    Friend WithEvents cboRelevador As System.Windows.Forms.ComboBox
End Class
