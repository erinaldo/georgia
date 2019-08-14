<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRecepcion
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
        Dim Label3 As System.Windows.Forms.Label
        Dim txtSucursal As System.Windows.Forms.Label
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.mnuAcciones = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuAbrir = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator
        Me.mnuCilindro = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuAlta = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator
        Me.mnuStock = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator
        Me.mnuConsulta = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem7 = New System.Windows.Forms.ToolStripSeparator
        Me.mnuRecargadores = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuPatente = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem8 = New System.Windows.Forms.ToolStripSeparator
        Me.CambiarPalletToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ImprimirPalletToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ResumenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem9 = New System.Windows.Forms.ToolStripSeparator
        Me.mnuPuerto = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem10 = New System.Windows.Forms.ToolStripSeparator
        Me.mnuRastreo = New System.Windows.Forms.ToolStripMenuItem
        Me.txtItn = New System.Windows.Forms.TextBox
        Me.txtSre = New System.Windows.Forms.TextBox
        Me.txtNombre = New System.Windows.Forms.TextBox
        Me.txtDireccion = New System.Windows.Forms.TextBox
        Me.txtCodigo = New System.Windows.Forms.TextBox
        Me.dgv = New System.Windows.Forms.DataGridView
        Me.srenum_0 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.itngru_0 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.macnum_0 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.pblnum_0 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.covflg_0 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.covspt_0 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.covvcr_0 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.maccovren_0 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.credat_0 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.creusr_0 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.upddat_0 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.updusr_0 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.yflgmrk_0 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.yflgtrj_0 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.macpdtcod_0 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.macdes_0 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ynrocil_0 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.yfabdat_0 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.yitnnum_0 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.macitntyp_0 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.srelig_0 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.recargador_0 = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.pallet_0 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.patente_0 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.nroiram_0 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.largo_0 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ok_0 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.presion_0 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.obs_0 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.usuario_0 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ContextMenuGrilla = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuEditar = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripSeparator
        Me.mnuBaja = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuAnularBaja = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripSeparator
        Me.mnuImprimir = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem6 = New System.Windows.Forms.ToolStripSeparator
        Me.mnuRecargador = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuPallet = New System.Windows.Forms.ToolStripMenuItem
        Me.txtBuscar = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtSuc = New System.Windows.Forms.TextBox
        Me.Tab = New System.Windows.Forms.TabControl
        Me.TabIntervencion = New System.Windows.Forms.TabPage
        Me.tabMangueras = New System.Windows.Forms.TabPage
        Me.dgvMangas = New System.Windows.Forms.DataGridView
        Me.cmnMangas = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuAddToIntervencion = New System.Windows.Forms.ToolStripMenuItem
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cboRecargador = New System.Windows.Forms.ComboBox
        Me.lblPallet = New System.Windows.Forms.Label
        Me.lblPatente = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.txtPuesto = New System.Windows.Forms.TextBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Label1 = New System.Windows.Forms.Label
        Label2 = New System.Windows.Forms.Label
        Label3 = New System.Windows.Forms.Label
        txtSucursal = New System.Windows.Forms.Label
        Me.MenuStrip1.SuspendLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuGrilla.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Tab.SuspendLayout()
        Me.TabIntervencion.SuspendLayout()
        Me.tabMangueras.SuspendLayout()
        CType(Me.dgvMangas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmnMangas.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(12, 17)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(69, 13)
        Label1.TabIndex = 0
        Label1.Text = "Intervención:"
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Location = New System.Drawing.Point(12, 42)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(50, 13)
        Label2.TabIndex = 2
        Label2.Text = "Solicitud:"
        '
        'Label3
        '
        Label3.AutoSize = True
        Label3.Location = New System.Drawing.Point(239, 17)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(42, 13)
        Label3.TabIndex = 4
        Label3.Text = "Cliente:"
        '
        'txtSucursal
        '
        txtSucursal.AutoSize = True
        txtSucursal.Location = New System.Drawing.Point(239, 45)
        txtSucursal.Name = "txtSucursal"
        txtSucursal.Size = New System.Drawing.Size(51, 13)
        txtSucursal.TabIndex = 7
        txtSucursal.Text = "Sucursal:"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuAcciones})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(928, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        Me.MenuStrip1.Visible = False
        '
        'mnuAcciones
        '
        Me.mnuAcciones.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.mnuAcciones.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuAbrir, Me.ToolStripMenuItem1, Me.mnuCilindro, Me.mnuAlta, Me.ToolStripMenuItem2, Me.mnuStock, Me.ToolStripMenuItem3, Me.mnuConsulta, Me.ToolStripMenuItem7, Me.mnuRecargadores, Me.mnuPatente, Me.ToolStripMenuItem8, Me.CambiarPalletToolStripMenuItem, Me.ImprimirPalletToolStripMenuItem, Me.ResumenToolStripMenuItem, Me.ToolStripMenuItem9, Me.mnuPuerto, Me.ToolStripMenuItem10, Me.mnuRastreo})
        Me.mnuAcciones.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.mnuAcciones.ForeColor = System.Drawing.SystemColors.ControlText
        Me.mnuAcciones.MergeIndex = 6
        Me.mnuAcciones.Name = "mnuAcciones"
        Me.mnuAcciones.Size = New System.Drawing.Size(61, 20)
        Me.mnuAcciones.Text = "Acciones"
        '
        'mnuAbrir
        '
        Me.mnuAbrir.Name = "mnuAbrir"
        Me.mnuAbrir.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.mnuAbrir.Size = New System.Drawing.Size(223, 22)
        Me.mnuAbrir.Text = "Abrir Intervención..."
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(220, 6)
        '
        'mnuCilindro
        '
        Me.mnuCilindro.Enabled = False
        Me.mnuCilindro.Name = "mnuCilindro"
        Me.mnuCilindro.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.mnuCilindro.Size = New System.Drawing.Size(223, 22)
        Me.mnuCilindro.Text = "Buscar cilindro..."
        '
        'mnuAlta
        '
        Me.mnuAlta.Enabled = False
        Me.mnuAlta.Name = "mnuAlta"
        Me.mnuAlta.ShortcutKeys = System.Windows.Forms.Keys.F6
        Me.mnuAlta.Size = New System.Drawing.Size(223, 22)
        Me.mnuAlta.Text = "Alta de Parque..."
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(220, 6)
        '
        'mnuStock
        '
        Me.mnuStock.Name = "mnuStock"
        Me.mnuStock.Size = New System.Drawing.Size(223, 22)
        Me.mnuStock.Text = "Stock de Cliente en Planta..."
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(220, 6)
        '
        'mnuConsulta
        '
        Me.mnuConsulta.Name = "mnuConsulta"
        Me.mnuConsulta.Size = New System.Drawing.Size(223, 22)
        Me.mnuConsulta.Text = "Equipos procesador en el día..."
        '
        'ToolStripMenuItem7
        '
        Me.ToolStripMenuItem7.Name = "ToolStripMenuItem7"
        Me.ToolStripMenuItem7.Size = New System.Drawing.Size(220, 6)
        '
        'mnuRecargadores
        '
        Me.mnuRecargadores.Name = "mnuRecargadores"
        Me.mnuRecargadores.ShortcutKeys = System.Windows.Forms.Keys.F11
        Me.mnuRecargadores.Size = New System.Drawing.Size(223, 22)
        Me.mnuRecargadores.Text = "Cambiar Recargador..."
        '
        'mnuPatente
        '
        Me.mnuPatente.CheckOnClick = True
        Me.mnuPatente.Name = "mnuPatente"
        Me.mnuPatente.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.J), System.Windows.Forms.Keys)
        Me.mnuPatente.Size = New System.Drawing.Size(223, 22)
        Me.mnuPatente.Text = "Patente"
        '
        'ToolStripMenuItem8
        '
        Me.ToolStripMenuItem8.Name = "ToolStripMenuItem8"
        Me.ToolStripMenuItem8.Size = New System.Drawing.Size(220, 6)
        '
        'CambiarPalletToolStripMenuItem
        '
        Me.CambiarPalletToolStripMenuItem.Name = "CambiarPalletToolStripMenuItem"
        Me.CambiarPalletToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
        Me.CambiarPalletToolStripMenuItem.Size = New System.Drawing.Size(223, 22)
        Me.CambiarPalletToolStripMenuItem.Text = "Cambiar Pallet..."
        '
        'ImprimirPalletToolStripMenuItem
        '
        Me.ImprimirPalletToolStripMenuItem.Name = "ImprimirPalletToolStripMenuItem"
        Me.ImprimirPalletToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.I), System.Windows.Forms.Keys)
        Me.ImprimirPalletToolStripMenuItem.Size = New System.Drawing.Size(223, 22)
        Me.ImprimirPalletToolStripMenuItem.Text = "Imprimir Pallet..."
        '
        'ResumenToolStripMenuItem
        '
        Me.ResumenToolStripMenuItem.Name = "ResumenToolStripMenuItem"
        Me.ResumenToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
        Me.ResumenToolStripMenuItem.Size = New System.Drawing.Size(223, 22)
        Me.ResumenToolStripMenuItem.Text = "Resumen..."
        '
        'ToolStripMenuItem9
        '
        Me.ToolStripMenuItem9.Name = "ToolStripMenuItem9"
        Me.ToolStripMenuItem9.Size = New System.Drawing.Size(220, 6)
        '
        'mnuPuerto
        '
        Me.mnuPuerto.Name = "mnuPuerto"
        Me.mnuPuerto.Size = New System.Drawing.Size(223, 22)
        Me.mnuPuerto.Text = "Puerto de impresora..."
        '
        'ToolStripMenuItem10
        '
        Me.ToolStripMenuItem10.Name = "ToolStripMenuItem10"
        Me.ToolStripMenuItem10.Size = New System.Drawing.Size(220, 6)
        '
        'mnuRastreo
        '
        Me.mnuRastreo.Name = "mnuRastreo"
        Me.mnuRastreo.Size = New System.Drawing.Size(223, 22)
        Me.mnuRastreo.Text = "Rastreo de equipo..."
        '
        'txtItn
        '
        Me.txtItn.Location = New System.Drawing.Point(87, 14)
        Me.txtItn.Name = "txtItn"
        Me.txtItn.ReadOnly = True
        Me.txtItn.Size = New System.Drawing.Size(88, 20)
        Me.txtItn.TabIndex = 1
        Me.txtItn.TabStop = False
        '
        'txtSre
        '
        Me.txtSre.Location = New System.Drawing.Point(87, 39)
        Me.txtSre.Name = "txtSre"
        Me.txtSre.ReadOnly = True
        Me.txtSre.Size = New System.Drawing.Size(146, 20)
        Me.txtSre.TabIndex = 3
        Me.txtSre.TabStop = False
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(393, 14)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.ReadOnly = True
        Me.txtNombre.Size = New System.Drawing.Size(172, 20)
        Me.txtNombre.TabIndex = 6
        Me.txtNombre.TabStop = False
        '
        'txtDireccion
        '
        Me.txtDireccion.Location = New System.Drawing.Point(296, 42)
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.ReadOnly = True
        Me.txtDireccion.Size = New System.Drawing.Size(269, 20)
        Me.txtDireccion.TabIndex = 8
        Me.txtDireccion.TabStop = False
        '
        'txtCodigo
        '
        Me.txtCodigo.Location = New System.Drawing.Point(296, 14)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.ReadOnly = True
        Me.txtCodigo.Size = New System.Drawing.Size(50, 20)
        Me.txtCodigo.TabIndex = 5
        Me.txtCodigo.TabStop = False
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToResizeColumns = False
        Me.dgv.AllowUserToResizeRows = False
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.srenum_0, Me.itngru_0, Me.macnum_0, Me.pblnum_0, Me.covflg_0, Me.covspt_0, Me.covvcr_0, Me.maccovren_0, Me.credat_0, Me.creusr_0, Me.upddat_0, Me.updusr_0, Me.yflgmrk_0, Me.yflgtrj_0, Me.macpdtcod_0, Me.macdes_0, Me.ynrocil_0, Me.yfabdat_0, Me.yitnnum_0, Me.macitntyp_0, Me.srelig_0, Me.recargador_0, Me.pallet_0, Me.patente_0, Me.nroiram_0, Me.largo_0, Me.ok_0, Me.presion_0, Me.obs_0, Me.usuario_0})
        Me.dgv.ContextMenuStrip = Me.ContextMenuGrilla
        Me.dgv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv.Enabled = False
        Me.dgv.Location = New System.Drawing.Point(3, 3)
        Me.dgv.Name = "dgv"
        Me.dgv.ReadOnly = True
        Me.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv.Size = New System.Drawing.Size(910, 397)
        Me.dgv.StandardTab = True
        Me.dgv.TabIndex = 11
        '
        'srenum_0
        '
        Me.srenum_0.HeaderText = "srenum"
        Me.srenum_0.Name = "srenum_0"
        Me.srenum_0.ReadOnly = True
        Me.srenum_0.Visible = False
        '
        'itngru_0
        '
        Me.itngru_0.HeaderText = "itngru"
        Me.itngru_0.Name = "itngru_0"
        Me.itngru_0.ReadOnly = True
        Me.itngru_0.Visible = False
        '
        'macnum_0
        '
        Me.macnum_0.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.macnum_0.HeaderText = "Serie"
        Me.macnum_0.Name = "macnum_0"
        Me.macnum_0.ReadOnly = True
        Me.macnum_0.Width = 56
        '
        'pblnum_0
        '
        Me.pblnum_0.HeaderText = "pblnum"
        Me.pblnum_0.Name = "pblnum_0"
        Me.pblnum_0.ReadOnly = True
        Me.pblnum_0.Visible = False
        '
        'covflg_0
        '
        Me.covflg_0.HeaderText = "covflg"
        Me.covflg_0.Name = "covflg_0"
        Me.covflg_0.ReadOnly = True
        Me.covflg_0.Visible = False
        '
        'covspt_0
        '
        Me.covspt_0.HeaderText = "covspt"
        Me.covspt_0.Name = "covspt_0"
        Me.covspt_0.ReadOnly = True
        Me.covspt_0.Visible = False
        '
        'covvcr_0
        '
        Me.covvcr_0.HeaderText = "covvcr"
        Me.covvcr_0.Name = "covvcr_0"
        Me.covvcr_0.ReadOnly = True
        Me.covvcr_0.Visible = False
        '
        'maccovren_0
        '
        Me.maccovren_0.HeaderText = "maccovren"
        Me.maccovren_0.Name = "maccovren_0"
        Me.maccovren_0.ReadOnly = True
        Me.maccovren_0.Visible = False
        '
        'credat_0
        '
        Me.credat_0.HeaderText = "credat"
        Me.credat_0.Name = "credat_0"
        Me.credat_0.ReadOnly = True
        Me.credat_0.Visible = False
        '
        'creusr_0
        '
        Me.creusr_0.HeaderText = "creusr"
        Me.creusr_0.Name = "creusr_0"
        Me.creusr_0.ReadOnly = True
        Me.creusr_0.Visible = False
        '
        'upddat_0
        '
        Me.upddat_0.HeaderText = "upddat"
        Me.upddat_0.Name = "upddat_0"
        Me.upddat_0.ReadOnly = True
        Me.upddat_0.Visible = False
        '
        'updusr_0
        '
        Me.updusr_0.HeaderText = "updusr"
        Me.updusr_0.Name = "updusr_0"
        Me.updusr_0.ReadOnly = True
        Me.updusr_0.Visible = False
        '
        'yflgmrk_0
        '
        Me.yflgmrk_0.HeaderText = "yflgmrk"
        Me.yflgmrk_0.Name = "yflgmrk_0"
        Me.yflgmrk_0.ReadOnly = True
        Me.yflgmrk_0.Visible = False
        '
        'yflgtrj_0
        '
        Me.yflgtrj_0.HeaderText = "yflgtrj"
        Me.yflgtrj_0.Name = "yflgtrj_0"
        Me.yflgtrj_0.ReadOnly = True
        Me.yflgtrj_0.Visible = False
        '
        'macpdtcod_0
        '
        Me.macpdtcod_0.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.macpdtcod_0.HeaderText = "Articulo"
        Me.macpdtcod_0.Name = "macpdtcod_0"
        Me.macpdtcod_0.ReadOnly = True
        Me.macpdtcod_0.Width = 67
        '
        'macdes_0
        '
        Me.macdes_0.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.macdes_0.HeaderText = "Equipo"
        Me.macdes_0.Name = "macdes_0"
        Me.macdes_0.ReadOnly = True
        '
        'ynrocil_0
        '
        Me.ynrocil_0.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.ynrocil_0.HeaderText = "Cilindro"
        Me.ynrocil_0.Name = "ynrocil_0"
        Me.ynrocil_0.ReadOnly = True
        Me.ynrocil_0.Width = 66
        '
        'yfabdat_0
        '
        Me.yfabdat_0.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.yfabdat_0.HeaderText = "Fabricación"
        Me.yfabdat_0.Name = "yfabdat_0"
        Me.yfabdat_0.ReadOnly = True
        Me.yfabdat_0.Width = 87
        '
        'yitnnum_0
        '
        Me.yitnnum_0.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.yitnnum_0.HeaderText = "Intervención"
        Me.yitnnum_0.Name = "yitnnum_0"
        Me.yitnnum_0.ReadOnly = True
        Me.yitnnum_0.Width = 91
        '
        'macitntyp_0
        '
        Me.macitntyp_0.HeaderText = "macitntyp"
        Me.macitntyp_0.Name = "macitntyp_0"
        Me.macitntyp_0.ReadOnly = True
        Me.macitntyp_0.Visible = False
        '
        'srelig_0
        '
        Me.srelig_0.HeaderText = "Linea"
        Me.srelig_0.Name = "srelig_0"
        Me.srelig_0.ReadOnly = True
        Me.srelig_0.Visible = False
        '
        'recargador_0
        '
        Me.recargador_0.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.recargador_0.HeaderText = "Recargador"
        Me.recargador_0.Name = "recargador_0"
        Me.recargador_0.ReadOnly = True
        Me.recargador_0.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.recargador_0.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'pallet_0
        '
        Me.pallet_0.HeaderText = "Pallet"
        Me.pallet_0.Name = "pallet_0"
        Me.pallet_0.ReadOnly = True
        '
        'patente_0
        '
        Me.patente_0.HeaderText = "Patente"
        Me.patente_0.MaxInputLength = 6
        Me.patente_0.Name = "patente_0"
        Me.patente_0.ReadOnly = True
        '
        'nroiram_0
        '
        Me.nroiram_0.HeaderText = "Iram"
        Me.nroiram_0.Name = "nroiram_0"
        Me.nroiram_0.ReadOnly = True
        Me.nroiram_0.Visible = False
        '
        'largo_0
        '
        Me.largo_0.HeaderText = "Largo"
        Me.largo_0.Name = "largo_0"
        Me.largo_0.ReadOnly = True
        Me.largo_0.Visible = False
        '
        'ok_0
        '
        Me.ok_0.HeaderText = "Ok"
        Me.ok_0.Name = "ok_0"
        Me.ok_0.ReadOnly = True
        Me.ok_0.Visible = False
        '
        'presion_0
        '
        Me.presion_0.HeaderText = "Presion"
        Me.presion_0.Name = "presion_0"
        Me.presion_0.ReadOnly = True
        Me.presion_0.Visible = False
        '
        'obs_0
        '
        Me.obs_0.HeaderText = "Obs"
        Me.obs_0.Name = "obs_0"
        Me.obs_0.ReadOnly = True
        Me.obs_0.Visible = False
        '
        'usuario_0
        '
        Me.usuario_0.HeaderText = "Usuario"
        Me.usuario_0.Name = "usuario_0"
        Me.usuario_0.ReadOnly = True
        Me.usuario_0.Visible = False
        '
        'ContextMenuGrilla
        '
        Me.ContextMenuGrilla.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuEditar, Me.ToolStripMenuItem4, Me.mnuBaja, Me.mnuAnularBaja, Me.ToolStripMenuItem5, Me.mnuImprimir, Me.ToolStripMenuItem6, Me.mnuRecargador, Me.mnuPallet})
        Me.ContextMenuGrilla.Name = "ContextMenuGrilla"
        Me.ContextMenuGrilla.Size = New System.Drawing.Size(239, 154)
        '
        'mnuEditar
        '
        Me.mnuEditar.Name = "mnuEditar"
        Me.mnuEditar.ShortcutKeys = System.Windows.Forms.Keys.F12
        Me.mnuEditar.Size = New System.Drawing.Size(238, 22)
        Me.mnuEditar.Text = "Editar..."
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(235, 6)
        '
        'mnuBaja
        '
        Me.mnuBaja.Name = "mnuBaja"
        Me.mnuBaja.ShortcutKeys = System.Windows.Forms.Keys.F8
        Me.mnuBaja.Size = New System.Drawing.Size(238, 22)
        Me.mnuBaja.Text = "Baja..."
        '
        'mnuAnularBaja
        '
        Me.mnuAnularBaja.Name = "mnuAnularBaja"
        Me.mnuAnularBaja.ShortcutKeys = System.Windows.Forms.Keys.F9
        Me.mnuAnularBaja.Size = New System.Drawing.Size(238, 22)
        Me.mnuAnularBaja.Text = "Anular Baja"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(235, 6)
        '
        'mnuImprimir
        '
        Me.mnuImprimir.Name = "mnuImprimir"
        Me.mnuImprimir.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.mnuImprimir.Size = New System.Drawing.Size(238, 22)
        Me.mnuImprimir.Text = "Imprimir etiqueta"
        '
        'ToolStripMenuItem6
        '
        Me.ToolStripMenuItem6.Name = "ToolStripMenuItem6"
        Me.ToolStripMenuItem6.Size = New System.Drawing.Size(235, 6)
        '
        'mnuRecargador
        '
        Me.mnuRecargador.Name = "mnuRecargador"
        Me.mnuRecargador.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
        Me.mnuRecargador.Size = New System.Drawing.Size(238, 22)
        Me.mnuRecargador.Text = "Modificar Recargador..."
        '
        'mnuPallet
        '
        Me.mnuPallet.Name = "mnuPallet"
        Me.mnuPallet.Size = New System.Drawing.Size(238, 22)
        Me.mnuPallet.Text = "Modificar Pallet..."
        '
        'txtBuscar
        '
        Me.txtBuscar.Enabled = False
        Me.txtBuscar.Location = New System.Drawing.Point(9, 16)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(254, 20)
        Me.txtBuscar.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtBuscar)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 74)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(269, 42)
        Me.GroupBox2.TabIndex = 9
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Buscar serie"
        '
        'txtSuc
        '
        Me.txtSuc.Location = New System.Drawing.Point(352, 14)
        Me.txtSuc.Name = "txtSuc"
        Me.txtSuc.ReadOnly = True
        Me.txtSuc.Size = New System.Drawing.Size(35, 20)
        Me.txtSuc.TabIndex = 12
        Me.txtSuc.TabStop = False
        '
        'Tab
        '
        Me.Tab.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Tab.Controls.Add(Me.TabIntervencion)
        Me.Tab.Controls.Add(Me.tabMangueras)
        Me.Tab.Location = New System.Drawing.Point(3, 141)
        Me.Tab.Name = "Tab"
        Me.Tab.SelectedIndex = 0
        Me.Tab.Size = New System.Drawing.Size(924, 429)
        Me.Tab.TabIndex = 13
        Me.Tab.TabStop = False
        '
        'TabIntervencion
        '
        Me.TabIntervencion.Controls.Add(Me.dgv)
        Me.TabIntervencion.Location = New System.Drawing.Point(4, 22)
        Me.TabIntervencion.Name = "TabIntervencion"
        Me.TabIntervencion.Padding = New System.Windows.Forms.Padding(3)
        Me.TabIntervencion.Size = New System.Drawing.Size(916, 403)
        Me.TabIntervencion.TabIndex = 0
        Me.TabIntervencion.Text = "Intervención"
        Me.TabIntervencion.UseVisualStyleBackColor = True
        '
        'tabMangueras
        '
        Me.tabMangueras.Controls.Add(Me.dgvMangas)
        Me.tabMangueras.Location = New System.Drawing.Point(4, 22)
        Me.tabMangueras.Name = "tabMangueras"
        Me.tabMangueras.Padding = New System.Windows.Forms.Padding(3)
        Me.tabMangueras.Size = New System.Drawing.Size(916, 403)
        Me.tabMangueras.TabIndex = 1
        Me.tabMangueras.Text = "Parque Mangueras"
        Me.tabMangueras.UseVisualStyleBackColor = True
        '
        'dgvMangas
        '
        Me.dgvMangas.AllowUserToAddRows = False
        Me.dgvMangas.AllowUserToDeleteRows = False
        Me.dgvMangas.AllowUserToResizeRows = False
        Me.dgvMangas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvMangas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMangas.ContextMenuStrip = Me.cmnMangas
        Me.dgvMangas.Location = New System.Drawing.Point(3, 6)
        Me.dgvMangas.Name = "dgvMangas"
        Me.dgvMangas.ReadOnly = True
        Me.dgvMangas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvMangas.Size = New System.Drawing.Size(645, 394)
        Me.dgvMangas.TabIndex = 0
        '
        'cmnMangas
        '
        Me.cmnMangas.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuAddToIntervencion})
        Me.cmnMangas.Name = "cmnMangas"
        Me.cmnMangas.Size = New System.Drawing.Size(195, 26)
        '
        'mnuAddToIntervencion
        '
        Me.mnuAddToIntervencion.Name = "mnuAddToIntervencion"
        Me.mnuAddToIntervencion.Size = New System.Drawing.Size(194, 22)
        Me.mnuAddToIntervencion.Text = "Agregar a intervencion"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboRecargador)
        Me.GroupBox1.Location = New System.Drawing.Point(296, 74)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(269, 42)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Último Recargador (F11)"
        '
        'cboRecargador
        '
        Me.cboRecargador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRecargador.Enabled = False
        Me.cboRecargador.FormattingEnabled = True
        Me.cboRecargador.Location = New System.Drawing.Point(6, 16)
        Me.cboRecargador.Name = "cboRecargador"
        Me.cboRecargador.Size = New System.Drawing.Size(257, 21)
        Me.cboRecargador.TabIndex = 0
        '
        'lblPallet
        '
        Me.lblPallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPallet.Location = New System.Drawing.Point(9, 16)
        Me.lblPallet.Name = "lblPallet"
        Me.lblPallet.Size = New System.Drawing.Size(150, 33)
        Me.lblPallet.TabIndex = 16
        Me.lblPallet.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblPatente
        '
        Me.lblPatente.AutoSize = True
        Me.lblPatente.BackColor = System.Drawing.Color.Lime
        Me.lblPatente.Location = New System.Drawing.Point(302, 123)
        Me.lblPatente.Name = "lblPatente"
        Me.lblPatente.Size = New System.Drawing.Size(57, 13)
        Me.lblPatente.TabIndex = 17
        Me.lblPatente.Text = "PATENTE"
        Me.lblPatente.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtPuesto)
        Me.GroupBox3.Location = New System.Drawing.Point(571, 74)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(58, 42)
        Me.GroupBox3.TabIndex = 18
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Puesto"
        '
        'txtPuesto
        '
        Me.txtPuesto.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPuesto.Location = New System.Drawing.Point(9, 16)
        Me.txtPuesto.MaxLength = 1
        Me.txtPuesto.Name = "txtPuesto"
        Me.txtPuesto.Size = New System.Drawing.Size(42, 20)
        Me.txtPuesto.TabIndex = 0
        Me.txtPuesto.TabStop = False
        Me.txtPuesto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.lblPallet)
        Me.GroupBox4.Location = New System.Drawing.Point(571, 4)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(165, 58)
        Me.GroupBox4.TabIndex = 19
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Palet"
        '
        'frmRecepcion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(928, 572)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.lblPatente)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Tab)
        Me.Controls.Add(Me.txtSuc)
        Me.Controls.Add(Me.txtCodigo)
        Me.Controls.Add(Me.txtDireccion)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(txtSucursal)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Label3)
        Me.Controls.Add(Me.txtSre)
        Me.Controls.Add(Label2)
        Me.Controls.Add(Me.txtItn)
        Me.Controls.Add(Label1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MinimumSize = New System.Drawing.Size(676, 487)
        Me.Name = "frmRecepcion"
        Me.ShowInTaskbar = False
        Me.Tag = "frmRecepcion"
        Me.Text = "Ingreso de equipos a Planta"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuGrilla.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Tab.ResumeLayout(False)
        Me.TabIntervencion.ResumeLayout(False)
        Me.tabMangueras.ResumeLayout(False)
        CType(Me.dgvMangas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmnMangas.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents mnuAcciones As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuAbrir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtItn As System.Windows.Forms.TextBox
    Friend WithEvents txtSre As System.Windows.Forms.TextBox
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents txtDireccion As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtSuc As System.Windows.Forms.TextBox
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuAlta As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuStock As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuConsulta As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuGrilla As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuEditar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuBaja As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuAnularBaja As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuImprimir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuCilindro As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Tab As System.Windows.Forms.TabControl
    Friend WithEvents TabIntervencion As System.Windows.Forms.TabPage
    Friend WithEvents tabMangueras As System.Windows.Forms.TabPage
    Friend WithEvents dgvMangas As System.Windows.Forms.DataGridView
    Friend WithEvents cmnMangas As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuAddToIntervencion As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuRecargador As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuRecargadores As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboRecargador As System.Windows.Forms.ComboBox
    Friend WithEvents lblPallet As System.Windows.Forms.Label
    Friend WithEvents ToolStripMenuItem8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CambiarPalletToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImprimirPalletToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPatente As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblPatente As System.Windows.Forms.Label
    Friend WithEvents mnuPallet As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuPuerto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ResumenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents srenum_0 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents itngru_0 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents macnum_0 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pblnum_0 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents covflg_0 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents covspt_0 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents covvcr_0 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents maccovren_0 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents credat_0 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents creusr_0 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents upddat_0 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents updusr_0 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents yflgmrk_0 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents yflgtrj_0 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents macpdtcod_0 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents macdes_0 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ynrocil_0 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents yfabdat_0 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents yitnnum_0 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents macitntyp_0 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents srelig_0 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents recargador_0 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents pallet_0 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents patente_0 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nroiram_0 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents largo_0 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ok_0 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents presion_0 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents obs_0 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents usuario_0 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToolStripMenuItem10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuRastreo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtPuesto As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
End Class
