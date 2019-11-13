<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSectoresPuestos
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
        Dim Label3 As System.Windows.Forms.Label
        Dim Label4 As System.Windows.Forms.Label
        Dim Label2 As System.Windows.Forms.Label
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer
        Me.dgvSectores = New System.Windows.Forms.DataGridView
        Me.colSectorId = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colSectorNro = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colSectorNombre = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colSectorCliente = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colSectorSucursal = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.mnuSectores = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuSectorNuevo = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuSectorEditar = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuSectorEliminar = New System.Windows.Forms.ToolStripMenuItem
        Me.dgvInspecciones = New System.Windows.Forms.DataGridView
        Me.colInspeccionesFecha = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colInspeccionesIntervencion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colInspeccionesRelevador = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.mnuInspecciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuVerInspeccion = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuEditarInspeccion = New System.Windows.Forms.ToolStripMenuItem
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer
        Me.dgvPuestosExtintores = New System.Windows.Forms.DataGridView
        Me.colPuestoExtintorId = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colPuestoExtintorNro = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colPuestoExtintorUbicacion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colPuestoExtintorOrden = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colPuestoExtintorSector = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colPuestoExtintorTipo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colPuestoExtintorAgente = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.colPuestoExtintorCapacidad = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.colPuestoExtintorCilindro = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colPuestoExtintorEquipo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colPuestoExtintorInspeccion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.mnuPuestosExtintores = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuNuevoPuestoExtintor = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuEditarPuestoExtintor = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuCambiarSectorExtintor = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator
        Me.mnuNuevoEquipo = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuAsociarEquipo = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.mnuPuestoVacio = New System.Windows.Forms.ToolStripMenuItem
        Me.dgvPuestosHidrantes = New System.Windows.Forms.DataGridView
        Me.mnuPuestosHidrantes = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuNuevoPuestoHidrante = New System.Windows.Forms.ToolStripMenuItem
        Me.EditarPuestoHidranteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuCambiarSectorHidrante = New System.Windows.Forms.ToolStripMenuItem
        Me.btnRegistrar = New System.Windows.Forms.Button
        Me.txtNombre = New System.Windows.Forms.TextBox
        Me.btnAbrir = New System.Windows.Forms.Button
        Me.cboSucursales = New System.Windows.Forms.ComboBox
        Me.btnSectores = New System.Windows.Forms.Button
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.txtCliente = New System.Windows.Forms.TextBox
        Me.btnSalir = New System.Windows.Forms.Button
        Me.colPuestoHidranteId = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colPuestoHidranteNro = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colPuestoHidranteUbicacion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colPuestoHidranteOrden = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colPuestoHidranteSector = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colPuestoHidranteTipo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colPuestoHidranteAgente = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colPuestoHidranteCapacidad = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colPuestoHidranteEquipo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colPuestoHidranteInspeccion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colPuestoHidranteCilindro = New System.Windows.Forms.DataGridViewTextBoxColumn
        Label1 = New System.Windows.Forms.Label
        Label3 = New System.Windows.Forms.Label
        Label4 = New System.Windows.Forms.Label
        Label2 = New System.Windows.Forms.Label
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        CType(Me.dgvSectores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnuSectores.SuspendLayout()
        CType(Me.dgvInspecciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnuInspecciones.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.dgvPuestosExtintores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnuPuestosExtintores.SuspendLayout()
        CType(Me.dgvPuestosHidrantes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnuPuestosHidrantes.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(4, 7)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(49, 13)
        Label1.TabIndex = 0
        Label1.Text = "Sectores"
        '
        'Label3
        '
        Label3.AutoSize = True
        Label3.Location = New System.Drawing.Point(3, 10)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(109, 13)
        Label3.TabIndex = 2
        Label3.Text = "Puestos de Extintores"
        '
        'Label4
        '
        Label4.AutoSize = True
        Label4.Location = New System.Drawing.Point(3, 9)
        Label4.Name = "Label4"
        Label4.Size = New System.Drawing.Size(108, 13)
        Label4.TabIndex = 3
        Label4.Text = "Puestos de Hidrantes"
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Location = New System.Drawing.Point(4, 10)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(70, 13)
        Label2.TabIndex = 1
        Label2.Text = "Inspecciones"
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.SplitContainer3)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Size = New System.Drawing.Size(1191, 512)
        Me.SplitContainer1.SplitterDistance = 304
        Me.SplitContainer1.TabIndex = 5
        '
        'SplitContainer3
        '
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer3.Name = "SplitContainer3"
        Me.SplitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.dgvSectores)
        Me.SplitContainer3.Panel1.Controls.Add(Label1)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.dgvInspecciones)
        Me.SplitContainer3.Panel2.Controls.Add(Label2)
        Me.SplitContainer3.Size = New System.Drawing.Size(302, 510)
        Me.SplitContainer3.SplitterDistance = 254
        Me.SplitContainer3.TabIndex = 2
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
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSectores.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvSectores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSectores.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colSectorId, Me.colSectorNro, Me.colSectorNombre, Me.colSectorCliente, Me.colSectorSucursal})
        Me.dgvSectores.ContextMenuStrip = Me.mnuSectores
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvSectores.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvSectores.Enabled = False
        Me.dgvSectores.Location = New System.Drawing.Point(2, 26)
        Me.dgvSectores.MultiSelect = False
        Me.dgvSectores.Name = "dgvSectores"
        Me.dgvSectores.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSectores.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvSectores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSectores.Size = New System.Drawing.Size(296, 225)
        Me.dgvSectores.TabIndex = 1
        '
        'colSectorId
        '
        Me.colSectorId.HeaderText = "RegID"
        Me.colSectorId.Name = "colSectorId"
        Me.colSectorId.ReadOnly = True
        Me.colSectorId.Visible = False
        '
        'colSectorNro
        '
        Me.colSectorNro.HeaderText = "Nro"
        Me.colSectorNro.Name = "colSectorNro"
        Me.colSectorNro.ReadOnly = True
        '
        'colSectorNombre
        '
        Me.colSectorNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colSectorNombre.HeaderText = "Nombre"
        Me.colSectorNombre.Name = "colSectorNombre"
        Me.colSectorNombre.ReadOnly = True
        '
        'colSectorCliente
        '
        Me.colSectorCliente.HeaderText = "Cliente"
        Me.colSectorCliente.Name = "colSectorCliente"
        Me.colSectorCliente.ReadOnly = True
        Me.colSectorCliente.Visible = False
        '
        'colSectorSucursal
        '
        Me.colSectorSucursal.HeaderText = "Sucursal"
        Me.colSectorSucursal.Name = "colSectorSucursal"
        Me.colSectorSucursal.ReadOnly = True
        Me.colSectorSucursal.Visible = False
        '
        'mnuSectores
        '
        Me.mnuSectores.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSectorNuevo, Me.mnuSectorEditar, Me.mnuSectorEliminar})
        Me.mnuSectores.Name = "cmenuSectores"
        Me.mnuSectores.Size = New System.Drawing.Size(118, 70)
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
        'dgvInspecciones
        '
        Me.dgvInspecciones.AllowUserToAddRows = False
        Me.dgvInspecciones.AllowUserToDeleteRows = False
        Me.dgvInspecciones.AllowUserToResizeColumns = False
        Me.dgvInspecciones.AllowUserToResizeRows = False
        Me.dgvInspecciones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInspecciones.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvInspecciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvInspecciones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colInspeccionesFecha, Me.colInspeccionesIntervencion, Me.colInspeccionesRelevador})
        Me.dgvInspecciones.ContextMenuStrip = Me.mnuInspecciones
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvInspecciones.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvInspecciones.Location = New System.Drawing.Point(2, 28)
        Me.dgvInspecciones.MultiSelect = False
        Me.dgvInspecciones.Name = "dgvInspecciones"
        Me.dgvInspecciones.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInspecciones.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvInspecciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvInspecciones.Size = New System.Drawing.Size(296, 221)
        Me.dgvInspecciones.TabIndex = 2
        '
        'colInspeccionesFecha
        '
        Me.colInspeccionesFecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colInspeccionesFecha.HeaderText = "Fecha"
        Me.colInspeccionesFecha.Name = "colInspeccionesFecha"
        Me.colInspeccionesFecha.ReadOnly = True
        Me.colInspeccionesFecha.Width = 62
        '
        'colInspeccionesIntervencion
        '
        Me.colInspeccionesIntervencion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colInspeccionesIntervencion.HeaderText = "Intervención"
        Me.colInspeccionesIntervencion.Name = "colInspeccionesIntervencion"
        Me.colInspeccionesIntervencion.ReadOnly = True
        Me.colInspeccionesIntervencion.Width = 91
        '
        'colInspeccionesRelevador
        '
        Me.colInspeccionesRelevador.HeaderText = "Relevador"
        Me.colInspeccionesRelevador.Name = "colInspeccionesRelevador"
        Me.colInspeccionesRelevador.ReadOnly = True
        '
        'mnuInspecciones
        '
        Me.mnuInspecciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuVerInspeccion, Me.mnuEditarInspeccion})
        Me.mnuInspecciones.Name = "cmenuPuestos"
        Me.mnuInspecciones.Size = New System.Drawing.Size(174, 48)
        '
        'mnuVerInspeccion
        '
        Me.mnuVerInspeccion.Name = "mnuVerInspeccion"
        Me.mnuVerInspeccion.Size = New System.Drawing.Size(173, 22)
        Me.mnuVerInspeccion.Text = "Ver inspección..."
        '
        'mnuEditarInspeccion
        '
        Me.mnuEditarInspeccion.Name = "mnuEditarInspeccion"
        Me.mnuEditarInspeccion.Size = New System.Drawing.Size(173, 22)
        Me.mnuEditarInspeccion.Text = "Editar inspección..."
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Label3)
        Me.SplitContainer2.Panel1.Controls.Add(Me.dgvPuestosExtintores)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.dgvPuestosHidrantes)
        Me.SplitContainer2.Panel2.Controls.Add(Label4)
        Me.SplitContainer2.Size = New System.Drawing.Size(881, 510)
        Me.SplitContainer2.SplitterDistance = 255
        Me.SplitContainer2.TabIndex = 3
        '
        'dgvPuestosExtintores
        '
        Me.dgvPuestosExtintores.AllowUserToAddRows = False
        Me.dgvPuestosExtintores.AllowUserToResizeRows = False
        Me.dgvPuestosExtintores.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPuestosExtintores.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvPuestosExtintores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPuestosExtintores.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colPuestoExtintorId, Me.colPuestoExtintorNro, Me.colPuestoExtintorUbicacion, Me.colPuestoExtintorOrden, Me.colPuestoExtintorSector, Me.colPuestoExtintorTipo, Me.colPuestoExtintorAgente, Me.colPuestoExtintorCapacidad, Me.colPuestoExtintorCilindro, Me.colPuestoExtintorEquipo, Me.colPuestoExtintorInspeccion})
        Me.dgvPuestosExtintores.ContextMenuStrip = Me.mnuPuestosExtintores
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvPuestosExtintores.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgvPuestosExtintores.Enabled = False
        Me.dgvPuestosExtintores.Location = New System.Drawing.Point(3, 26)
        Me.dgvPuestosExtintores.Name = "dgvPuestosExtintores"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPuestosExtintores.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgvPuestosExtintores.Size = New System.Drawing.Size(868, 226)
        Me.dgvPuestosExtintores.TabIndex = 0
        '
        'colPuestoExtintorId
        '
        Me.colPuestoExtintorId.HeaderText = "Id"
        Me.colPuestoExtintorId.Name = "colPuestoExtintorId"
        Me.colPuestoExtintorId.Visible = False
        '
        'colPuestoExtintorNro
        '
        Me.colPuestoExtintorNro.HeaderText = "Nro"
        Me.colPuestoExtintorNro.Name = "colPuestoExtintorNro"
        '
        'colPuestoExtintorUbicacion
        '
        Me.colPuestoExtintorUbicacion.HeaderText = "Ubicacion"
        Me.colPuestoExtintorUbicacion.Name = "colPuestoExtintorUbicacion"
        '
        'colPuestoExtintorOrden
        '
        Me.colPuestoExtintorOrden.HeaderText = "Orden"
        Me.colPuestoExtintorOrden.Name = "colPuestoExtintorOrden"
        '
        'colPuestoExtintorSector
        '
        Me.colPuestoExtintorSector.HeaderText = "Sector"
        Me.colPuestoExtintorSector.Name = "colPuestoExtintorSector"
        Me.colPuestoExtintorSector.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colPuestoExtintorSector.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colPuestoExtintorSector.Visible = False
        '
        'colPuestoExtintorTipo
        '
        Me.colPuestoExtintorTipo.HeaderText = "Tipo"
        Me.colPuestoExtintorTipo.Name = "colPuestoExtintorTipo"
        Me.colPuestoExtintorTipo.Visible = False
        '
        'colPuestoExtintorAgente
        '
        Me.colPuestoExtintorAgente.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.colPuestoExtintorAgente.HeaderText = "Agente"
        Me.colPuestoExtintorAgente.Name = "colPuestoExtintorAgente"
        Me.colPuestoExtintorAgente.ReadOnly = True
        Me.colPuestoExtintorAgente.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colPuestoExtintorAgente.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'colPuestoExtintorCapacidad
        '
        Me.colPuestoExtintorCapacidad.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.colPuestoExtintorCapacidad.HeaderText = "Capacidad"
        Me.colPuestoExtintorCapacidad.Name = "colPuestoExtintorCapacidad"
        Me.colPuestoExtintorCapacidad.ReadOnly = True
        Me.colPuestoExtintorCapacidad.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'colPuestoExtintorCilindro
        '
        Me.colPuestoExtintorCilindro.HeaderText = "Cilindro"
        Me.colPuestoExtintorCilindro.Name = "colPuestoExtintorCilindro"
        '
        'colPuestoExtintorEquipo
        '
        Me.colPuestoExtintorEquipo.HeaderText = "Serie"
        Me.colPuestoExtintorEquipo.Name = "colPuestoExtintorEquipo"
        Me.colPuestoExtintorEquipo.ReadOnly = True
        '
        'colPuestoExtintorInspeccion
        '
        Me.colPuestoExtintorInspeccion.HeaderText = "Inspeccion"
        Me.colPuestoExtintorInspeccion.Name = "colPuestoExtintorInspeccion"
        Me.colPuestoExtintorInspeccion.ReadOnly = True
        '
        'mnuPuestosExtintores
        '
        Me.mnuPuestosExtintores.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuNuevoPuestoExtintor, Me.mnuEditarPuestoExtintor, Me.mnuCambiarSectorExtintor, Me.ToolStripMenuItem1, Me.mnuNuevoEquipo, Me.mnuAsociarEquipo, Me.ToolStripSeparator1, Me.mnuPuestoVacio})
        Me.mnuPuestosExtintores.Name = "cmenuPuestos"
        Me.mnuPuestosExtintores.Size = New System.Drawing.Size(201, 148)
        '
        'mnuNuevoPuestoExtintor
        '
        Me.mnuNuevoPuestoExtintor.Name = "mnuNuevoPuestoExtintor"
        Me.mnuNuevoPuestoExtintor.Size = New System.Drawing.Size(200, 22)
        Me.mnuNuevoPuestoExtintor.Text = "Nuevo Puesto Extintor..."
        '
        'mnuEditarPuestoExtintor
        '
        Me.mnuEditarPuestoExtintor.Name = "mnuEditarPuestoExtintor"
        Me.mnuEditarPuestoExtintor.Size = New System.Drawing.Size(200, 22)
        Me.mnuEditarPuestoExtintor.Text = "Editar Puesto Extintor..."
        '
        'mnuCambiarSectorExtintor
        '
        Me.mnuCambiarSectorExtintor.Name = "mnuCambiarSectorExtintor"
        Me.mnuCambiarSectorExtintor.Size = New System.Drawing.Size(200, 22)
        Me.mnuCambiarSectorExtintor.Text = "Cambiar sector..."
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(197, 6)
        '
        'mnuNuevoEquipo
        '
        Me.mnuNuevoEquipo.Name = "mnuNuevoEquipo"
        Me.mnuNuevoEquipo.Size = New System.Drawing.Size(200, 22)
        Me.mnuNuevoEquipo.Text = "Nuevo equipo..."
        '
        'mnuAsociarEquipo
        '
        Me.mnuAsociarEquipo.Name = "mnuAsociarEquipo"
        Me.mnuAsociarEquipo.Size = New System.Drawing.Size(200, 22)
        Me.mnuAsociarEquipo.Text = "Asociar equipo..."
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(197, 6)
        '
        'mnuPuestoVacio
        '
        Me.mnuPuestoVacio.Name = "mnuPuestoVacio"
        Me.mnuPuestoVacio.Size = New System.Drawing.Size(200, 22)
        Me.mnuPuestoVacio.Text = "Poner puesto vacio"
        '
        'dgvPuestosHidrantes
        '
        Me.dgvPuestosHidrantes.AllowUserToAddRows = False
        Me.dgvPuestosHidrantes.AllowUserToResizeRows = False
        Me.dgvPuestosHidrantes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPuestosHidrantes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.dgvPuestosHidrantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPuestosHidrantes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colPuestoHidranteId, Me.colPuestoHidranteNro, Me.colPuestoHidranteUbicacion, Me.colPuestoHidranteOrden, Me.colPuestoHidranteSector, Me.colPuestoHidranteTipo, Me.colPuestoHidranteAgente, Me.colPuestoHidranteCapacidad, Me.colPuestoHidranteEquipo, Me.colPuestoHidranteInspeccion, Me.colPuestoHidranteCilindro})
        Me.dgvPuestosHidrantes.ContextMenuStrip = Me.mnuPuestosHidrantes
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvPuestosHidrantes.DefaultCellStyle = DataGridViewCellStyle11
        Me.dgvPuestosHidrantes.Enabled = False
        Me.dgvPuestosHidrantes.Location = New System.Drawing.Point(3, 26)
        Me.dgvPuestosHidrantes.Name = "dgvPuestosHidrantes"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPuestosHidrantes.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.dgvPuestosHidrantes.Size = New System.Drawing.Size(868, 226)
        Me.dgvPuestosHidrantes.TabIndex = 3
        '
        'mnuPuestosHidrantes
        '
        Me.mnuPuestosHidrantes.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuNuevoPuestoHidrante, Me.EditarPuestoHidranteToolStripMenuItem, Me.mnuCambiarSectorHidrante})
        Me.mnuPuestosHidrantes.Name = "mnuPuestosHidrantes"
        Me.mnuPuestosHidrantes.Size = New System.Drawing.Size(205, 70)
        '
        'mnuNuevoPuestoHidrante
        '
        Me.mnuNuevoPuestoHidrante.Name = "mnuNuevoPuestoHidrante"
        Me.mnuNuevoPuestoHidrante.Size = New System.Drawing.Size(204, 22)
        Me.mnuNuevoPuestoHidrante.Text = "Nuevo puesto hidrante..."
        '
        'EditarPuestoHidranteToolStripMenuItem
        '
        Me.EditarPuestoHidranteToolStripMenuItem.Name = "EditarPuestoHidranteToolStripMenuItem"
        Me.EditarPuestoHidranteToolStripMenuItem.Size = New System.Drawing.Size(204, 22)
        Me.EditarPuestoHidranteToolStripMenuItem.Text = "Editar puesto hidrante..."
        '
        'mnuCambiarSectorHidrante
        '
        Me.mnuCambiarSectorHidrante.Name = "mnuCambiarSectorHidrante"
        Me.mnuCambiarSectorHidrante.Size = New System.Drawing.Size(204, 22)
        Me.mnuCambiarSectorHidrante.Text = "Cambiar sector..."
        '
        'btnRegistrar
        '
        Me.btnRegistrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRegistrar.Enabled = False
        Me.btnRegistrar.Location = New System.Drawing.Point(940, 550)
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
        'cboSucursales
        '
        Me.cboSucursales.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboSucursales.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSucursales.FormattingEnabled = True
        Me.cboSucursales.Location = New System.Drawing.Point(479, 8)
        Me.cboSucursales.Name = "cboSucursales"
        Me.cboSucursales.Size = New System.Drawing.Size(335, 21)
        Me.cboSucursales.TabIndex = 9
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
        Me.btnCancelar.Enabled = False
        Me.btnCancelar.Location = New System.Drawing.Point(1023, 550)
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
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.Location = New System.Drawing.Point(1104, 550)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(75, 23)
        Me.btnSalir.TabIndex = 12
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'colPuestoHidranteId
        '
        Me.colPuestoHidranteId.HeaderText = "Id"
        Me.colPuestoHidranteId.Name = "colPuestoHidranteId"
        Me.colPuestoHidranteId.Visible = False
        '
        'colPuestoHidranteNro
        '
        Me.colPuestoHidranteNro.HeaderText = "Nro"
        Me.colPuestoHidranteNro.Name = "colPuestoHidranteNro"
        '
        'colPuestoHidranteUbicacion
        '
        Me.colPuestoHidranteUbicacion.HeaderText = "Ubicacion"
        Me.colPuestoHidranteUbicacion.Name = "colPuestoHidranteUbicacion"
        '
        'colPuestoHidranteOrden
        '
        Me.colPuestoHidranteOrden.HeaderText = "Orden"
        Me.colPuestoHidranteOrden.Name = "colPuestoHidranteOrden"
        '
        'colPuestoHidranteSector
        '
        Me.colPuestoHidranteSector.HeaderText = "Sector"
        Me.colPuestoHidranteSector.Name = "colPuestoHidranteSector"
        Me.colPuestoHidranteSector.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colPuestoHidranteSector.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colPuestoHidranteSector.Visible = False
        '
        'colPuestoHidranteTipo
        '
        Me.colPuestoHidranteTipo.HeaderText = "Tipo"
        Me.colPuestoHidranteTipo.Name = "colPuestoHidranteTipo"
        Me.colPuestoHidranteTipo.Visible = False
        '
        'colPuestoHidranteAgente
        '
        Me.colPuestoHidranteAgente.HeaderText = "Agente"
        Me.colPuestoHidranteAgente.Name = "colPuestoHidranteAgente"
        Me.colPuestoHidranteAgente.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colPuestoHidranteAgente.Visible = False
        '
        'colPuestoHidranteCapacidad
        '
        Me.colPuestoHidranteCapacidad.HeaderText = "Capacidad"
        Me.colPuestoHidranteCapacidad.Name = "colPuestoHidranteCapacidad"
        Me.colPuestoHidranteCapacidad.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colPuestoHidranteCapacidad.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colPuestoHidranteCapacidad.Visible = False
        '
        'colPuestoHidranteEquipo
        '
        Me.colPuestoHidranteEquipo.HeaderText = "Equipo"
        Me.colPuestoHidranteEquipo.Name = "colPuestoHidranteEquipo"
        Me.colPuestoHidranteEquipo.Visible = False
        '
        'colPuestoHidranteInspeccion
        '
        Me.colPuestoHidranteInspeccion.HeaderText = "Inspeccion"
        Me.colPuestoHidranteInspeccion.Name = "colPuestoHidranteInspeccion"
        Me.colPuestoHidranteInspeccion.ReadOnly = True
        '
        'colPuestoHidranteCilindro
        '
        Me.colPuestoHidranteCilindro.HeaderText = "Cilindro"
        Me.colPuestoHidranteCilindro.Name = "colPuestoHidranteCilindro"
        Me.colPuestoHidranteCilindro.Visible = False
        '
        'frmSectoresPuestos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1191, 578)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.txtCliente)
        Me.Controls.Add(Me.btnSectores)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAbrir)
        Me.Controls.Add(Me.cboSucursales)
        Me.Controls.Add(Me.btnRegistrar)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "frmSectoresPuestos"
        Me.Text = "Parque de clientes abonados"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel1.PerformLayout()
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        Me.SplitContainer3.Panel2.PerformLayout()
        Me.SplitContainer3.ResumeLayout(False)
        CType(Me.dgvSectores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mnuSectores.ResumeLayout(False)
        CType(Me.dgvInspecciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mnuInspecciones.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.PerformLayout()
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.Panel2.PerformLayout()
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.dgvPuestosExtintores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mnuPuestosExtintores.ResumeLayout(False)
        CType(Me.dgvPuestosHidrantes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mnuPuestosHidrantes.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents dgvSectores As System.Windows.Forms.DataGridView
    Friend WithEvents btnRegistrar As System.Windows.Forms.Button
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents btnAbrir As System.Windows.Forms.Button
    Friend WithEvents cboSucursales As System.Windows.Forms.ComboBox
    Friend WithEvents btnSectores As System.Windows.Forms.Button
    Friend WithEvents dgvPuestosExtintores As System.Windows.Forms.DataGridView
    Friend WithEvents mnuSectores As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuSectorNuevo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSectorEditar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSectorEliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents mnuPuestosExtintores As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuNuevoEquipo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuAsociarEquipo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPuestoVacio As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents colSectorId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSectorNro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSectorNombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSectorCliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSectorSucursal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents dgvPuestosHidrantes As System.Windows.Forms.DataGridView
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents mnuNuevoPuestoExtintor As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPuestosHidrantes As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuNuevoPuestoHidrante As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuEditarPuestoExtintor As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditarPuestoHidranteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
    Friend WithEvents dgvInspecciones As System.Windows.Forms.DataGridView
    Friend WithEvents mnuInspecciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuVerInspeccion As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuCambiarSectorExtintor As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuCambiarSectorHidrante As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents colInspeccionesFecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colInspeccionesIntervencion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colInspeccionesRelevador As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents mnuEditarInspeccion As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents colPuestoExtintorId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPuestoExtintorNro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPuestoExtintorUbicacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPuestoExtintorOrden As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPuestoExtintorSector As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPuestoExtintorTipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPuestoExtintorAgente As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colPuestoExtintorCapacidad As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colPuestoExtintorCilindro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPuestoExtintorEquipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPuestoExtintorInspeccion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPuestoHidranteId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPuestoHidranteNro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPuestoHidranteUbicacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPuestoHidranteOrden As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPuestoHidranteSector As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPuestoHidranteTipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPuestoHidranteAgente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPuestoHidranteCapacidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPuestoHidranteEquipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPuestoHidranteInspeccion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPuestoHidranteCilindro As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
