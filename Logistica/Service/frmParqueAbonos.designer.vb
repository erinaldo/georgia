<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmParqueAbonos
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
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.dgvSectores = New System.Windows.Forms.DataGridView
        Me.col1RegID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col1Cliente = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col1Sucursal = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col1Sector = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cmenuSectores = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuSectorNuevo = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuSectorEditar = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuSectorEliminar = New System.Windows.Forms.ToolStripMenuItem
        Me.dgvPuestos = New System.Windows.Forms.DataGridView
        Me.col2Regid = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col2Sector = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.col2Puesto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col2Tipo = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.col2Serie = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col2Articulo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col2Equipo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col2Cilindro = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col2Fab = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col2Vto1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col2Ph = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col2Baliza = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.col2Soporte = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.col2Gabinete = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.col2Cartel = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.col2Tarjeta = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.col2Lanza = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.col2Pico = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.col2Llave = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.col2Vidrio = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.col2Valvula = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.col2Estado = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.col2Obs = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col2Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cmenuPuestos = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuNuevoEquipo = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator
        Me.mnuAsociarEquipo = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuPuestoVacio = New System.Windows.Forms.ToolStripMenuItem
        Me.AsociarVariosEquiposToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.btnRegistrar = New System.Windows.Forms.Button
        Me.txtNombre = New System.Windows.Forms.TextBox
        Me.btnAbrir = New System.Windows.Forms.Button
        Me.cboSuc = New System.Windows.Forms.ComboBox
        Me.btnSectores = New System.Windows.Forms.Button
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.txtCliente = New System.Windows.Forms.TextBox
        Me.txtBusqueda = New System.Windows.Forms.TextBox
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Label1 = New System.Windows.Forms.Label
        Label2 = New System.Windows.Forms.Label
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.dgvSectores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmenuSectores.SuspendLayout()
        CType(Me.dgvPuestos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmenuPuestos.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(3, 10)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(49, 13)
        Label1.TabIndex = 0
        Label1.Text = "Sectores"
        '
        'Label2
        '
        Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Label2.AutoSize = True
        Label2.Location = New System.Drawing.Point(826, 13)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(57, 13)
        Label2.TabIndex = 13
        Label2.Text = "Buscar Cil."
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 36)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.dgvSectores)
        Me.SplitContainer1.Panel1.Controls.Add(Label1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgvPuestos)
        Me.SplitContainer1.Size = New System.Drawing.Size(996, 512)
        Me.SplitContainer1.SplitterDistance = 255
        Me.SplitContainer1.TabIndex = 5
        '
        'dgvSectores
        '
        Me.dgvSectores.AllowUserToAddRows = False
        Me.dgvSectores.AllowUserToDeleteRows = False
        Me.dgvSectores.AllowUserToResizeColumns = False
        Me.dgvSectores.AllowUserToResizeRows = False
        Me.dgvSectores.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvSectores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSectores.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col1RegID, Me.col1Cliente, Me.col1Sucursal, Me.col1Sector})
        Me.dgvSectores.ContextMenuStrip = Me.cmenuSectores
        Me.dgvSectores.Enabled = False
        Me.dgvSectores.Location = New System.Drawing.Point(2, 26)
        Me.dgvSectores.MultiSelect = False
        Me.dgvSectores.Name = "dgvSectores"
        Me.dgvSectores.ReadOnly = True
        Me.dgvSectores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSectores.Size = New System.Drawing.Size(247, 481)
        Me.dgvSectores.TabIndex = 1
        '
        'col1RegID
        '
        Me.col1RegID.HeaderText = "RegID"
        Me.col1RegID.Name = "col1RegID"
        Me.col1RegID.ReadOnly = True
        Me.col1RegID.Visible = False
        '
        'col1Cliente
        '
        Me.col1Cliente.HeaderText = "Cliente"
        Me.col1Cliente.Name = "col1Cliente"
        Me.col1Cliente.ReadOnly = True
        Me.col1Cliente.Visible = False
        '
        'col1Sucursal
        '
        Me.col1Sucursal.HeaderText = "Sucursal"
        Me.col1Sucursal.Name = "col1Sucursal"
        Me.col1Sucursal.ReadOnly = True
        Me.col1Sucursal.Visible = False
        '
        'col1Sector
        '
        Me.col1Sector.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.col1Sector.HeaderText = "Sector"
        Me.col1Sector.Name = "col1Sector"
        Me.col1Sector.ReadOnly = True
        '
        'cmenuSectores
        '
        Me.cmenuSectores.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSectorNuevo, Me.mnuSectorEditar, Me.mnuSectorEliminar})
        Me.cmenuSectores.Name = "cmenuSectores"
        Me.cmenuSectores.Size = New System.Drawing.Size(118, 70)
        '
        'mnuSectorNuevo
        '
        Me.mnuSectorNuevo.Name = "mnuSectorNuevo"
        Me.mnuSectorNuevo.Size = New System.Drawing.Size(117, 22)
        Me.mnuSectorNuevo.Text = "Nuevo"
        '
        'mnuSectorEditar
        '
        Me.mnuSectorEditar.Name = "mnuSectorEditar"
        Me.mnuSectorEditar.Size = New System.Drawing.Size(117, 22)
        Me.mnuSectorEditar.Text = "Editar"
        '
        'mnuSectorEliminar
        '
        Me.mnuSectorEliminar.Name = "mnuSectorEliminar"
        Me.mnuSectorEliminar.Size = New System.Drawing.Size(117, 22)
        Me.mnuSectorEliminar.Text = "Eliminar"
        '
        'dgvPuestos
        '
        Me.dgvPuestos.AllowUserToResizeRows = False
        Me.dgvPuestos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPuestos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPuestos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col2Regid, Me.col2Sector, Me.col2Puesto, Me.col2Tipo, Me.col2Serie, Me.col2Articulo, Me.col2Equipo, Me.col2Cilindro, Me.col2Fab, Me.col2Vto1, Me.col2Ph, Me.col2Baliza, Me.col2Soporte, Me.col2Gabinete, Me.col2Cartel, Me.col2Tarjeta, Me.col2Lanza, Me.col2Pico, Me.col2Llave, Me.col2Vidrio, Me.col2Valvula, Me.col2Estado, Me.col2Obs, Me.col2Fecha})
        Me.dgvPuestos.ContextMenuStrip = Me.cmenuPuestos
        Me.dgvPuestos.Enabled = False
        Me.dgvPuestos.Location = New System.Drawing.Point(0, 0)
        Me.dgvPuestos.Name = "dgvPuestos"
        Me.dgvPuestos.Size = New System.Drawing.Size(735, 507)
        Me.dgvPuestos.TabIndex = 0
        '
        'col2Regid
        '
        Me.col2Regid.HeaderText = "Regid"
        Me.col2Regid.Name = "col2Regid"
        Me.col2Regid.Visible = False
        '
        'col2Sector
        '
        Me.col2Sector.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.col2Sector.DisplayStyleForCurrentCellOnly = True
        Me.col2Sector.HeaderText = "Sector"
        Me.col2Sector.Name = "col2Sector"
        Me.col2Sector.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.col2Sector.Width = 63
        '
        'col2Puesto
        '
        Me.col2Puesto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.col2Puesto.HeaderText = "Puesto"
        Me.col2Puesto.Name = "col2Puesto"
        Me.col2Puesto.Width = 65
        '
        'col2Tipo
        '
        Me.col2Tipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.col2Tipo.DisplayStyleForCurrentCellOnly = True
        Me.col2Tipo.HeaderText = "Tipo"
        Me.col2Tipo.Name = "col2Tipo"
        Me.col2Tipo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.col2Tipo.Width = 53
        '
        'col2Serie
        '
        Me.col2Serie.HeaderText = "Serie"
        Me.col2Serie.Name = "col2Serie"
        Me.col2Serie.Visible = False
        '
        'col2Articulo
        '
        Me.col2Articulo.HeaderText = "Articulo"
        Me.col2Articulo.Name = "col2Articulo"
        Me.col2Articulo.Visible = False
        '
        'col2Equipo
        '
        Me.col2Equipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.col2Equipo.HeaderText = "Equipo"
        Me.col2Equipo.Name = "col2Equipo"
        Me.col2Equipo.ReadOnly = True
        Me.col2Equipo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.col2Equipo.Width = 65
        '
        'col2Cilindro
        '
        Me.col2Cilindro.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.col2Cilindro.HeaderText = "Cilindro"
        Me.col2Cilindro.Name = "col2Cilindro"
        Me.col2Cilindro.ReadOnly = True
        Me.col2Cilindro.Width = 66
        '
        'col2Fab
        '
        Me.col2Fab.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.col2Fab.HeaderText = "Fabricación"
        Me.col2Fab.Name = "col2Fab"
        Me.col2Fab.ReadOnly = True
        Me.col2Fab.Width = 87
        '
        'col2Vto1
        '
        Me.col2Vto1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle9.Format = "MM/yyyy"
        DataGridViewCellStyle9.NullValue = Nothing
        Me.col2Vto1.DefaultCellStyle = DataGridViewCellStyle9
        Me.col2Vto1.HeaderText = "Vto"
        Me.col2Vto1.Name = "col2Vto1"
        Me.col2Vto1.ReadOnly = True
        Me.col2Vto1.Width = 48
        '
        'col2Ph
        '
        Me.col2Ph.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle10.Format = "MM/yyyy"
        Me.col2Ph.DefaultCellStyle = DataGridViewCellStyle10
        Me.col2Ph.HeaderText = "PH"
        Me.col2Ph.Name = "col2Ph"
        Me.col2Ph.ReadOnly = True
        Me.col2Ph.Width = 47
        '
        'col2Baliza
        '
        Me.col2Baliza.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.col2Baliza.DisplayStyleForCurrentCellOnly = True
        Me.col2Baliza.HeaderText = "Baliza"
        Me.col2Baliza.Name = "col2Baliza"
        Me.col2Baliza.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.col2Baliza.Width = 60
        '
        'col2Soporte
        '
        Me.col2Soporte.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.col2Soporte.DisplayStyleForCurrentCellOnly = True
        Me.col2Soporte.HeaderText = "Soporte"
        Me.col2Soporte.Name = "col2Soporte"
        Me.col2Soporte.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.col2Soporte.Width = 69
        '
        'col2Gabinete
        '
        Me.col2Gabinete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.col2Gabinete.DisplayStyleForCurrentCellOnly = True
        Me.col2Gabinete.HeaderText = "Gabinete"
        Me.col2Gabinete.Name = "col2Gabinete"
        Me.col2Gabinete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.col2Gabinete.Width = 75
        '
        'col2Cartel
        '
        Me.col2Cartel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.col2Cartel.DisplayStyleForCurrentCellOnly = True
        Me.col2Cartel.HeaderText = "Cartel"
        Me.col2Cartel.Name = "col2Cartel"
        Me.col2Cartel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.col2Cartel.Width = 59
        '
        'col2Tarjeta
        '
        Me.col2Tarjeta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.col2Tarjeta.DisplayStyleForCurrentCellOnly = True
        Me.col2Tarjeta.HeaderText = "Tarjeta"
        Me.col2Tarjeta.Name = "col2Tarjeta"
        Me.col2Tarjeta.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.col2Tarjeta.Width = 65
        '
        'col2Lanza
        '
        Me.col2Lanza.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.col2Lanza.DisplayStyleForCurrentCellOnly = True
        Me.col2Lanza.HeaderText = "Lanza"
        Me.col2Lanza.Name = "col2Lanza"
        Me.col2Lanza.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.col2Lanza.Width = 61
        '
        'col2Pico
        '
        Me.col2Pico.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.col2Pico.DisplayStyleForCurrentCellOnly = True
        Me.col2Pico.HeaderText = "Pico"
        Me.col2Pico.Name = "col2Pico"
        Me.col2Pico.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.col2Pico.Width = 53
        '
        'col2Llave
        '
        Me.col2Llave.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.col2Llave.DisplayStyleForCurrentCellOnly = True
        Me.col2Llave.HeaderText = "Llave"
        Me.col2Llave.Name = "col2Llave"
        Me.col2Llave.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.col2Llave.Width = 58
        '
        'col2Vidrio
        '
        Me.col2Vidrio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.col2Vidrio.DisplayStyleForCurrentCellOnly = True
        Me.col2Vidrio.HeaderText = "Vidrio"
        Me.col2Vidrio.Name = "col2Vidrio"
        Me.col2Vidrio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.col2Vidrio.Width = 58
        '
        'col2Valvula
        '
        Me.col2Valvula.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.col2Valvula.DisplayStyleForCurrentCellOnly = True
        Me.col2Valvula.HeaderText = "Valvula"
        Me.col2Valvula.Name = "col2Valvula"
        Me.col2Valvula.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.col2Valvula.Width = 67
        '
        'col2Estado
        '
        Me.col2Estado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.col2Estado.DisplayStyleForCurrentCellOnly = True
        Me.col2Estado.HeaderText = "Estado"
        Me.col2Estado.Name = "col2Estado"
        Me.col2Estado.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.col2Estado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.col2Estado.Width = 65
        '
        'col2Obs
        '
        Me.col2Obs.HeaderText = "Observaciones"
        Me.col2Obs.Name = "col2Obs"
        '
        'col2Fecha
        '
        Me.col2Fecha.HeaderText = "Fecha"
        Me.col2Fecha.Name = "col2Fecha"
        Me.col2Fecha.Visible = False
        '
        'cmenuPuestos
        '
        Me.cmenuPuestos.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuNuevoEquipo, Me.ToolStripMenuItem1, Me.mnuAsociarEquipo, Me.AsociarVariosEquiposToolStripMenuItem, Me.ToolStripSeparator1, Me.mnuPuestoVacio})
        Me.cmenuPuestos.Name = "cmenuPuestos"
        Me.cmenuPuestos.Size = New System.Drawing.Size(203, 126)
        '
        'mnuNuevoEquipo
        '
        Me.mnuNuevoEquipo.Name = "mnuNuevoEquipo"
        Me.mnuNuevoEquipo.Size = New System.Drawing.Size(193, 22)
        Me.mnuNuevoEquipo.Text = "Nuevo equipo..."
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(190, 6)
        '
        'mnuAsociarEquipo
        '
        Me.mnuAsociarEquipo.Name = "mnuAsociarEquipo"
        Me.mnuAsociarEquipo.Size = New System.Drawing.Size(193, 22)
        Me.mnuAsociarEquipo.Text = "Asociar equipo..."
        '
        'mnuPuestoVacio
        '
        Me.mnuPuestoVacio.Name = "mnuPuestoVacio"
        Me.mnuPuestoVacio.Size = New System.Drawing.Size(193, 22)
        Me.mnuPuestoVacio.Text = "Poner puesto vacio"
        '
        'AsociarVariosEquiposToolStripMenuItem
        '
        Me.AsociarVariosEquiposToolStripMenuItem.Name = "AsociarVariosEquiposToolStripMenuItem"
        Me.AsociarVariosEquiposToolStripMenuItem.Size = New System.Drawing.Size(202, 22)
        Me.AsociarVariosEquiposToolStripMenuItem.Text = "Asociar Varios Equipos..."
        '
        'btnRegistrar
        '
        Me.btnRegistrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRegistrar.Enabled = False
        Me.btnRegistrar.Location = New System.Drawing.Point(833, 550)
        Me.btnRegistrar.Name = "btnRegistrar"
        Me.btnRegistrar.Size = New System.Drawing.Size(75, 23)
        Me.btnRegistrar.TabIndex = 6
        Me.btnRegistrar.Text = "Registrar"
        Me.btnRegistrar.UseVisualStyleBackColor = True
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(59, 8)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.ReadOnly = True
        Me.txtNombre.Size = New System.Drawing.Size(333, 20)
        Me.txtNombre.TabIndex = 7
        '
        'btnAbrir
        '
        Me.btnAbrir.Location = New System.Drawing.Point(396, 8)
        Me.btnAbrir.Name = "btnAbrir"
        Me.btnAbrir.Size = New System.Drawing.Size(75, 23)
        Me.btnAbrir.TabIndex = 8
        Me.btnAbrir.Text = "Abrir Cliente"
        Me.btnAbrir.UseVisualStyleBackColor = True
        '
        'cboSuc
        '
        Me.cboSuc.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboSuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSuc.FormattingEnabled = True
        Me.cboSuc.Location = New System.Drawing.Point(479, 8)
        Me.cboSuc.Name = "cboSuc"
        Me.cboSuc.Size = New System.Drawing.Size(341, 21)
        Me.cboSuc.TabIndex = 9
        '
        'btnSectores
        '
        Me.btnSectores.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSectores.Location = New System.Drawing.Point(3, 550)
        Me.btnSectores.Name = "btnSectores"
        Me.btnSectores.Size = New System.Drawing.Size(120, 23)
        Me.btnSectores.TabIndex = 7
        Me.btnSectores.Tag = "1"
        Me.btnSectores.Text = "Ocultar Sectores"
        Me.btnSectores.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.Location = New System.Drawing.Point(914, 550)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 10
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'txtCliente
        '
        Me.txtCliente.Location = New System.Drawing.Point(3, 8)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(50, 20)
        Me.txtCliente.TabIndex = 11
        '
        'txtBusqueda
        '
        Me.txtBusqueda.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBusqueda.Location = New System.Drawing.Point(889, 8)
        Me.txtBusqueda.Name = "txtBusqueda"
        Me.txtBusqueda.Size = New System.Drawing.Size(100, 20)
        Me.txtBusqueda.TabIndex = 12
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(190, 6)
        '
        'frmParqueAbonos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(996, 578)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Label2)
        Me.Controls.Add(Me.txtCliente)
        Me.Controls.Add(Me.txtBusqueda)
        Me.Controls.Add(Me.btnSectores)
        Me.Controls.Add(Me.btnRegistrar)
        Me.Controls.Add(Me.btnAbrir)
        Me.Controls.Add(Me.cboSuc)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "frmParqueAbonos"
        Me.Text = "Parque de clientes abonados"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.dgvSectores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmenuSectores.ResumeLayout(False)
        CType(Me.dgvPuestos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmenuPuestos.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents dgvSectores As System.Windows.Forms.DataGridView
    Friend WithEvents col1RegID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col1Cliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col1Sucursal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col1Sector As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnRegistrar As System.Windows.Forms.Button
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents btnAbrir As System.Windows.Forms.Button
    Friend WithEvents cboSuc As System.Windows.Forms.ComboBox
    Friend WithEvents btnSectores As System.Windows.Forms.Button
    Friend WithEvents dgvPuestos As System.Windows.Forms.DataGridView
    Friend WithEvents cmenuSectores As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuSectorNuevo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSectorEditar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSectorEliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents cmenuPuestos As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuNuevoEquipo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuAsociarEquipo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPuestoVacio As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents col2Regid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col2Sector As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents col2Puesto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col2Tipo As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents col2Serie As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col2Articulo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col2Equipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col2Cilindro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col2Fab As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col2Vto1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col2Ph As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col2Baliza As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents col2Soporte As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents col2Gabinete As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents col2Cartel As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents col2Tarjeta As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents col2Lanza As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents col2Pico As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents col2Llave As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents col2Vidrio As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents col2Valvula As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents col2Estado As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents col2Obs As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col2Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtBusqueda As System.Windows.Forms.TextBox
    Friend WithEvents AsociarVariosEquiposToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
End Class
