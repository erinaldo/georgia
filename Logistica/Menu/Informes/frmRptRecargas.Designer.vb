<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRptRecargas
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
        Dim Label2 As System.Windows.Forms.Label
        Dim Label5 As System.Windows.Forms.Label
        Dim Label6 As System.Windows.Forms.Label
        Dim Label7 As System.Windows.Forms.Label
        Dim Label8 As System.Windows.Forms.Label
        Dim Label9 As System.Windows.Forms.Label
        Dim Label12 As System.Windows.Forms.Label
        Dim Label13 As System.Windows.Forms.Label
        Dim Label14 As System.Windows.Forms.Label
        Dim Label15 As System.Windows.Forms.Label
        Dim Label16 As System.Windows.Forms.Label
        Dim Label17 As System.Windows.Forms.Label
        Dim Label19 As System.Windows.Forms.Label
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.lblTot1 = New System.Windows.Forms.Label
        Me.lblTot2 = New System.Windows.Forms.Label
        Me.lblTot3 = New System.Windows.Forms.Label
        Me.lblTotal = New System.Windows.Forms.Label
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.clbTipo = New System.Windows.Forms.CheckedListBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.clbEstados = New System.Windows.Forms.CheckedListBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.clbAbonado = New System.Windows.Forms.CheckedListBox
        Me.btnVer = New System.Windows.Forms.Button
        Me.dgv = New System.Windows.Forms.DataGridView
        Me.colTab4Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colTab4Itn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colTab4Ot = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colTab4Tipo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colTab4Rto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colTab4Cliente = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colTab4Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colTab4Equipos = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colTab4ExtOk = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colTab4ExtBaja = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colTab4MangaOk = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colTab4MangaBaja = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colTab4Estado = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.colTab4Abonado = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.colTab4Sector = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colTab4Ruta = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.dgvSectores = New System.Windows.Forms.DataGridView
        Me.colTab4Sectores = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.colTab4Intervenciones = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.txtTot3 = New System.Windows.Forms.TextBox
        Me.txtTot5 = New System.Windows.Forms.TextBox
        Me.txtTot4 = New System.Windows.Forms.TextBox
        Me.txtTot2 = New System.Windows.Forms.TextBox
        Me.txtTot1 = New System.Windows.Forms.TextBox
        Me.dgvSeguimiento = New System.Windows.Forms.DataGridView
        Me.btnConsultar = New System.Windows.Forms.Button
        Me.dtpHasta = New System.Windows.Forms.DateTimePicker
        Me.dtpDesde = New System.Windows.Forms.DateTimePicker
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.txt6Entregado = New System.Windows.Forms.TextBox
        Me.txt6Facturado = New System.Windows.Forms.TextBox
        Me.txt6Procesado = New System.Windows.Forms.TextBox
        Me.txt6Ingreso = New System.Windows.Forms.TextBox
        Me.txt6Retiro = New System.Windows.Forms.TextBox
        Me.txt6Creacion = New System.Windows.Forms.TextBox
        Me.dgvHistorial = New System.Windows.Forms.DataGridView
        Me.col6Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col6Hora = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col6De = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.col6Para = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtBuscarItn = New System.Windows.Forms.TextBox
        Me.dgvBusqueda = New System.Windows.Forms.DataGridView
        Me.col5Itn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col5Ot = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col5Cliente = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col5Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label10 = New System.Windows.Forms.Label
        Me.TabPage4 = New System.Windows.Forms.TabPage
        Me.btnRefrescar = New System.Windows.Forms.Button
        Me.Label20 = New System.Windows.Forms.Label
        Me.txtAboRuta = New System.Windows.Forms.TextBox
        Me.txtTotalPlanta = New System.Windows.Forms.TextBox
        Me.txtNoAboProceso = New System.Windows.Forms.TextBox
        Me.txtTotalGeneral = New System.Windows.Forms.TextBox
        Me.txtTotalRuta = New System.Windows.Forms.TextBox
        Me.txtNoAboFacturacion = New System.Windows.Forms.TextBox
        Me.txtTotalFacturacion = New System.Windows.Forms.TextBox
        Me.txtTotalProceso = New System.Windows.Forms.TextBox
        Me.txtNoAboRuta = New System.Windows.Forms.TextBox
        Me.txtTotalAbonados = New System.Windows.Forms.TextBox
        Me.txtAboPlanta = New System.Windows.Forms.TextBox
        Me.txtTotalNoAbonados = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtAboFacturacion = New System.Windows.Forms.TextBox
        Me.txtNoAboPlanta = New System.Windows.Forms.TextBox
        Me.txtAboProceso = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.btnSalir = New System.Windows.Forms.Button
        Me.col5Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col5Retirados = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col5Ingresados = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col5Prefacturacion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col5Logistica = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col5Entregados = New System.Windows.Forms.DataGridViewTextBoxColumn
        Label2 = New System.Windows.Forms.Label
        Label5 = New System.Windows.Forms.Label
        Label6 = New System.Windows.Forms.Label
        Label7 = New System.Windows.Forms.Label
        Label8 = New System.Windows.Forms.Label
        Label9 = New System.Windows.Forms.Label
        Label12 = New System.Windows.Forms.Label
        Label13 = New System.Windows.Forms.Label
        Label14 = New System.Windows.Forms.Label
        Label15 = New System.Windows.Forms.Label
        Label16 = New System.Windows.Forms.Label
        Label17 = New System.Windows.Forms.Label
        Label19 = New System.Windows.Forms.Label
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSectores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgvSeguimiento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.dgvHistorial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvBusqueda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Location = New System.Drawing.Point(8, 16)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(41, 13)
        Label2.TabIndex = 2
        Label2.Text = "Desde:"
        '
        'Label5
        '
        Label5.AutoSize = True
        Label5.Location = New System.Drawing.Point(157, 16)
        Label5.Name = "Label5"
        Label5.Size = New System.Drawing.Size(38, 13)
        Label5.TabIndex = 3
        Label5.Text = "Hasta:"
        '
        'Label6
        '
        Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Label6.AutoSize = True
        Label6.Location = New System.Drawing.Point(10, 346)
        Label6.Name = "Label6"
        Label6.Size = New System.Drawing.Size(79, 13)
        Label6.TabIndex = 9
        Label6.Text = "Total Retirados"
        '
        'Label7
        '
        Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Label7.AutoSize = True
        Label7.Location = New System.Drawing.Point(105, 346)
        Label7.Name = "Label7"
        Label7.Size = New System.Drawing.Size(86, 13)
        Label7.TabIndex = 11
        Label7.Text = "Total Ingresados"
        '
        'Label8
        '
        Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Label8.AutoSize = True
        Label8.Location = New System.Drawing.Point(341, 346)
        Label8.Name = "Label8"
        Label8.Size = New System.Drawing.Size(76, 13)
        Label8.TabIndex = 13
        Label8.Text = "Total Logistica"
        '
        'Label9
        '
        Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Label9.AutoSize = True
        Label9.Location = New System.Drawing.Point(469, 346)
        Label9.Name = "Label9"
        Label9.Size = New System.Drawing.Size(91, 13)
        Label9.TabIndex = 15
        Label9.Text = "Total: Entregados"
        '
        'Label12
        '
        Label12.AutoSize = True
        Label12.Location = New System.Drawing.Point(316, 190)
        Label12.Name = "Label12"
        Label12.Size = New System.Drawing.Size(84, 13)
        Label12.TabIndex = 12
        Label12.Text = "Fecha creación:"
        '
        'Label13
        '
        Label13.AutoSize = True
        Label13.Location = New System.Drawing.Point(316, 216)
        Label13.Name = "Label13"
        Label13.Size = New System.Drawing.Size(86, 13)
        Label13.TabIndex = 13
        Label13.Text = "Fecha de Retiro:"
        '
        'Label14
        '
        Label14.AutoSize = True
        Label14.Location = New System.Drawing.Point(316, 242)
        Label14.Name = "Label14"
        Label14.Size = New System.Drawing.Size(78, 13)
        Label14.TabIndex = 14
        Label14.Text = "Fecha Ingreso:"
        '
        'Label15
        '
        Label15.AutoSize = True
        Label15.Location = New System.Drawing.Point(316, 268)
        Label15.Name = "Label15"
        Label15.Size = New System.Drawing.Size(94, 13)
        Label15.TabIndex = 15
        Label15.Text = "Fecha Procesado:"
        '
        'Label16
        '
        Label16.AutoSize = True
        Label16.Location = New System.Drawing.Point(316, 294)
        Label16.Name = "Label16"
        Label16.Size = New System.Drawing.Size(88, 13)
        Label16.TabIndex = 16
        Label16.Text = "Fecha Remitado:"
        '
        'Label17
        '
        Label17.AutoSize = True
        Label17.Location = New System.Drawing.Point(316, 320)
        Label17.Name = "Label17"
        Label17.Size = New System.Drawing.Size(92, 13)
        Label17.TabIndex = 17
        Label17.Text = "Fecha Entregado:"
        '
        'Label19
        '
        Label19.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Label19.AutoSize = True
        Label19.Location = New System.Drawing.Point(218, 346)
        Label19.Name = "Label19"
        Label19.Size = New System.Drawing.Size(103, 13)
        Label19.TabIndex = 16
        Label19.Text = "Total Prefacturación"
        '
        'lblTot1
        '
        Me.lblTot1.AutoSize = True
        Me.lblTot1.Location = New System.Drawing.Point(87, 25)
        Me.lblTot1.Name = "lblTot1"
        Me.lblTot1.Size = New System.Drawing.Size(61, 13)
        Me.lblTot1.TabIndex = 1
        Me.lblTot1.Text = "En proceso"
        '
        'lblTot2
        '
        Me.lblTot2.AutoSize = True
        Me.lblTot2.Location = New System.Drawing.Point(206, 25)
        Me.lblTot2.Name = "lblTot2"
        Me.lblTot2.Size = New System.Drawing.Size(91, 13)
        Me.lblTot2.TabIndex = 2
        Me.lblTot2.Text = "En prefacturación"
        '
        'lblTot3
        '
        Me.lblTot3.AutoSize = True
        Me.lblTot3.Location = New System.Drawing.Point(329, 25)
        Me.lblTot3.Name = "lblTot3"
        Me.lblTot3.Size = New System.Drawing.Size(103, 13)
        Me.lblTot3.TabIndex = 3
        Me.lblTot3.Text = "Terminados en Ruta"
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Location = New System.Drawing.Point(585, 25)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(42, 13)
        Me.lblTotal.TabIndex = 5
        Me.lblTotal.Text = "Totales"
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(895, 474)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox3)
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.btnVer)
        Me.TabPage1.Controls.Add(Me.dgv)
        Me.TabPage1.Controls.Add(Me.dgvSectores)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(887, 448)
        Me.TabPage1.TabIndex = 5
        Me.TabPage1.Text = "Int. por sector"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.clbTipo)
        Me.GroupBox3.Location = New System.Drawing.Point(661, 6)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(120, 132)
        Me.GroupBox3.TabIndex = 6
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Tipo"
        '
        'clbTipo
        '
        Me.clbTipo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.clbTipo.CheckOnClick = True
        Me.clbTipo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.clbTipo.FormattingEnabled = True
        Me.clbTipo.Location = New System.Drawing.Point(3, 16)
        Me.clbTipo.Name = "clbTipo"
        Me.clbTipo.Size = New System.Drawing.Size(114, 105)
        Me.clbTipo.TabIndex = 3
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.clbEstados)
        Me.GroupBox2.Location = New System.Drawing.Point(535, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(120, 132)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Estado"
        '
        'clbEstados
        '
        Me.clbEstados.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.clbEstados.CheckOnClick = True
        Me.clbEstados.Dock = System.Windows.Forms.DockStyle.Fill
        Me.clbEstados.FormattingEnabled = True
        Me.clbEstados.Location = New System.Drawing.Point(3, 16)
        Me.clbEstados.Name = "clbEstados"
        Me.clbEstados.Size = New System.Drawing.Size(114, 105)
        Me.clbEstados.TabIndex = 3
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.clbAbonado)
        Me.GroupBox1.Location = New System.Drawing.Point(409, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(120, 132)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Abonado"
        '
        'clbAbonado
        '
        Me.clbAbonado.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.clbAbonado.CheckOnClick = True
        Me.clbAbonado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.clbAbonado.FormattingEnabled = True
        Me.clbAbonado.Location = New System.Drawing.Point(3, 16)
        Me.clbAbonado.Name = "clbAbonado"
        Me.clbAbonado.Size = New System.Drawing.Size(114, 105)
        Me.clbAbonado.TabIndex = 3
        '
        'btnVer
        '
        Me.btnVer.Location = New System.Drawing.Point(787, 115)
        Me.btnVer.Name = "btnVer"
        Me.btnVer.Size = New System.Drawing.Size(75, 23)
        Me.btnVer.TabIndex = 2
        Me.btnVer.Text = "Ver"
        Me.btnVer.UseVisualStyleBackColor = True
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToDeleteRows = False
        Me.dgv.AllowUserToResizeRows = False
        Me.dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colTab4Fecha, Me.colTab4Itn, Me.colTab4Ot, Me.colTab4Tipo, Me.colTab4Rto, Me.colTab4Cliente, Me.colTab4Nombre, Me.colTab4Equipos, Me.colTab4ExtOk, Me.colTab4ExtBaja, Me.colTab4MangaOk, Me.colTab4MangaBaja, Me.colTab4Estado, Me.colTab4Abonado, Me.colTab4Sector, Me.colTab4Ruta})
        Me.dgv.Location = New System.Drawing.Point(3, 144)
        Me.dgv.Name = "dgv"
        Me.dgv.ReadOnly = True
        Me.dgv.Size = New System.Drawing.Size(878, 298)
        Me.dgv.TabIndex = 1
        '
        'colTab4Fecha
        '
        Me.colTab4Fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colTab4Fecha.HeaderText = "Fecha"
        Me.colTab4Fecha.Name = "colTab4Fecha"
        Me.colTab4Fecha.ReadOnly = True
        Me.colTab4Fecha.Width = 62
        '
        'colTab4Itn
        '
        Me.colTab4Itn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colTab4Itn.HeaderText = "Intervencion"
        Me.colTab4Itn.Name = "colTab4Itn"
        Me.colTab4Itn.ReadOnly = True
        Me.colTab4Itn.Width = 91
        '
        'colTab4Ot
        '
        Me.colTab4Ot.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colTab4Ot.HeaderText = "OT"
        Me.colTab4Ot.Name = "colTab4Ot"
        Me.colTab4Ot.ReadOnly = True
        Me.colTab4Ot.Width = 47
        '
        'colTab4Tipo
        '
        Me.colTab4Tipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colTab4Tipo.HeaderText = "Tipo"
        Me.colTab4Tipo.Name = "colTab4Tipo"
        Me.colTab4Tipo.ReadOnly = True
        Me.colTab4Tipo.Width = 53
        '
        'colTab4Rto
        '
        Me.colTab4Rto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colTab4Rto.HeaderText = "Remito"
        Me.colTab4Rto.Name = "colTab4Rto"
        Me.colTab4Rto.ReadOnly = True
        Me.colTab4Rto.Width = 65
        '
        'colTab4Cliente
        '
        Me.colTab4Cliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colTab4Cliente.HeaderText = "Cliente"
        Me.colTab4Cliente.Name = "colTab4Cliente"
        Me.colTab4Cliente.ReadOnly = True
        Me.colTab4Cliente.Width = 64
        '
        'colTab4Nombre
        '
        Me.colTab4Nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colTab4Nombre.HeaderText = "Nombre"
        Me.colTab4Nombre.Name = "colTab4Nombre"
        Me.colTab4Nombre.ReadOnly = True
        '
        'colTab4Equipos
        '
        Me.colTab4Equipos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colTab4Equipos.HeaderText = "Equipos"
        Me.colTab4Equipos.Name = "colTab4Equipos"
        Me.colTab4Equipos.ReadOnly = True
        Me.colTab4Equipos.Width = 70
        '
        'colTab4ExtOk
        '
        Me.colTab4ExtOk.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colTab4ExtOk.HeaderText = "Ext. Ok"
        Me.colTab4ExtOk.Name = "colTab4ExtOk"
        Me.colTab4ExtOk.ReadOnly = True
        Me.colTab4ExtOk.Width = 67
        '
        'colTab4ExtBaja
        '
        Me.colTab4ExtBaja.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colTab4ExtBaja.HeaderText = "Ext. Baja"
        Me.colTab4ExtBaja.Name = "colTab4ExtBaja"
        Me.colTab4ExtBaja.ReadOnly = True
        Me.colTab4ExtBaja.Width = 74
        '
        'colTab4MangaOk
        '
        Me.colTab4MangaOk.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colTab4MangaOk.HeaderText = "Manga Ok"
        Me.colTab4MangaOk.Name = "colTab4MangaOk"
        Me.colTab4MangaOk.ReadOnly = True
        Me.colTab4MangaOk.Width = 82
        '
        'colTab4MangaBaja
        '
        Me.colTab4MangaBaja.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colTab4MangaBaja.HeaderText = "Manga Baja"
        Me.colTab4MangaBaja.Name = "colTab4MangaBaja"
        Me.colTab4MangaBaja.ReadOnly = True
        Me.colTab4MangaBaja.Width = 89
        '
        'colTab4Estado
        '
        Me.colTab4Estado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colTab4Estado.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.colTab4Estado.HeaderText = "Estado"
        Me.colTab4Estado.Name = "colTab4Estado"
        Me.colTab4Estado.ReadOnly = True
        Me.colTab4Estado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colTab4Estado.Width = 65
        '
        'colTab4Abonado
        '
        Me.colTab4Abonado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colTab4Abonado.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.colTab4Abonado.HeaderText = "Abonado"
        Me.colTab4Abonado.Name = "colTab4Abonado"
        Me.colTab4Abonado.ReadOnly = True
        Me.colTab4Abonado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colTab4Abonado.Width = 75
        '
        'colTab4Sector
        '
        Me.colTab4Sector.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.colTab4Sector.HeaderText = "Sector"
        Me.colTab4Sector.Name = "colTab4Sector"
        Me.colTab4Sector.ReadOnly = True
        Me.colTab4Sector.Width = 63
        '
        'colTab4Ruta
        '
        Me.colTab4Ruta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colTab4Ruta.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.colTab4Ruta.HeaderText = "Ruta"
        Me.colTab4Ruta.Name = "colTab4Ruta"
        Me.colTab4Ruta.ReadOnly = True
        Me.colTab4Ruta.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colTab4Ruta.Width = 55
        '
        'dgvSectores
        '
        Me.dgvSectores.AllowUserToAddRows = False
        Me.dgvSectores.AllowUserToDeleteRows = False
        Me.dgvSectores.AllowUserToResizeRows = False
        Me.dgvSectores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSectores.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colTab4Sectores, Me.colTab4Intervenciones})
        Me.dgvSectores.Location = New System.Drawing.Point(3, 6)
        Me.dgvSectores.Name = "dgvSectores"
        Me.dgvSectores.ReadOnly = True
        Me.dgvSectores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSectores.Size = New System.Drawing.Size(400, 132)
        Me.dgvSectores.TabIndex = 0
        '
        'colTab4Sectores
        '
        Me.colTab4Sectores.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colTab4Sectores.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.colTab4Sectores.HeaderText = "Sector"
        Me.colTab4Sectores.Name = "colTab4Sectores"
        Me.colTab4Sectores.ReadOnly = True
        '
        'colTab4Intervenciones
        '
        Me.colTab4Intervenciones.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "N0"
        Me.colTab4Intervenciones.DefaultCellStyle = DataGridViewCellStyle7
        Me.colTab4Intervenciones.HeaderText = "Intervenciones"
        Me.colTab4Intervenciones.Name = "colTab4Intervenciones"
        Me.colTab4Intervenciones.ReadOnly = True
        Me.colTab4Intervenciones.Width = 102
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.txtTot3)
        Me.TabPage2.Controls.Add(Label19)
        Me.TabPage2.Controls.Add(Label9)
        Me.TabPage2.Controls.Add(Me.txtTot5)
        Me.TabPage2.Controls.Add(Label8)
        Me.TabPage2.Controls.Add(Me.txtTot4)
        Me.TabPage2.Controls.Add(Label7)
        Me.TabPage2.Controls.Add(Me.txtTot2)
        Me.TabPage2.Controls.Add(Label6)
        Me.TabPage2.Controls.Add(Me.txtTot1)
        Me.TabPage2.Controls.Add(Me.dgvSeguimiento)
        Me.TabPage2.Controls.Add(Me.btnConsultar)
        Me.TabPage2.Controls.Add(Label5)
        Me.TabPage2.Controls.Add(Label2)
        Me.TabPage2.Controls.Add(Me.dtpHasta)
        Me.TabPage2.Controls.Add(Me.dtpDesde)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(887, 448)
        Me.TabPage2.TabIndex = 3
        Me.TabPage2.Text = "Seguimiento"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'txtTot3
        '
        Me.txtTot3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtTot3.Location = New System.Drawing.Point(221, 362)
        Me.txtTot3.Name = "txtTot3"
        Me.txtTot3.ReadOnly = True
        Me.txtTot3.Size = New System.Drawing.Size(90, 20)
        Me.txtTot3.TabIndex = 17
        Me.txtTot3.Text = "0"
        Me.txtTot3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTot5
        '
        Me.txtTot5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtTot5.Location = New System.Drawing.Point(472, 362)
        Me.txtTot5.Name = "txtTot5"
        Me.txtTot5.ReadOnly = True
        Me.txtTot5.Size = New System.Drawing.Size(91, 20)
        Me.txtTot5.TabIndex = 14
        Me.txtTot5.Text = "0"
        Me.txtTot5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTot4
        '
        Me.txtTot4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtTot4.Location = New System.Drawing.Point(344, 362)
        Me.txtTot4.Name = "txtTot4"
        Me.txtTot4.ReadOnly = True
        Me.txtTot4.Size = New System.Drawing.Size(100, 20)
        Me.txtTot4.TabIndex = 12
        Me.txtTot4.Text = "0"
        Me.txtTot4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTot2
        '
        Me.txtTot2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtTot2.Location = New System.Drawing.Point(108, 362)
        Me.txtTot2.Name = "txtTot2"
        Me.txtTot2.ReadOnly = True
        Me.txtTot2.Size = New System.Drawing.Size(86, 20)
        Me.txtTot2.TabIndex = 10
        Me.txtTot2.Text = "0"
        Me.txtTot2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTot1
        '
        Me.txtTot1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtTot1.Location = New System.Drawing.Point(13, 362)
        Me.txtTot1.Name = "txtTot1"
        Me.txtTot1.ReadOnly = True
        Me.txtTot1.Size = New System.Drawing.Size(74, 20)
        Me.txtTot1.TabIndex = 8
        Me.txtTot1.Text = "0"
        Me.txtTot1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dgvSeguimiento
        '
        Me.dgvSeguimiento.AllowUserToAddRows = False
        Me.dgvSeguimiento.AllowUserToDeleteRows = False
        Me.dgvSeguimiento.AllowUserToResizeRows = False
        Me.dgvSeguimiento.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvSeguimiento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSeguimiento.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col5Fecha, Me.col5Retirados, Me.col5Ingresados, Me.col5Prefacturacion, Me.col5Logistica, Me.col5Entregados})
        Me.dgvSeguimiento.Location = New System.Drawing.Point(3, 40)
        Me.dgvSeguimiento.Name = "dgvSeguimiento"
        Me.dgvSeguimiento.ReadOnly = True
        Me.dgvSeguimiento.Size = New System.Drawing.Size(852, 303)
        Me.dgvSeguimiento.TabIndex = 5
        '
        'btnConsultar
        '
        Me.btnConsultar.Location = New System.Drawing.Point(314, 11)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(75, 23)
        Me.btnConsultar.TabIndex = 4
        Me.btnConsultar.Text = "Consultar"
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'dtpHasta
        '
        Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpHasta.Location = New System.Drawing.Point(201, 12)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(96, 20)
        Me.dtpHasta.TabIndex = 1
        '
        'dtpDesde
        '
        Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDesde.Location = New System.Drawing.Point(55, 12)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(96, 20)
        Me.dtpDesde.TabIndex = 0
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Label17)
        Me.TabPage3.Controls.Add(Label16)
        Me.TabPage3.Controls.Add(Label15)
        Me.TabPage3.Controls.Add(Label14)
        Me.TabPage3.Controls.Add(Label13)
        Me.TabPage3.Controls.Add(Label12)
        Me.TabPage3.Controls.Add(Me.txt6Entregado)
        Me.TabPage3.Controls.Add(Me.txt6Facturado)
        Me.TabPage3.Controls.Add(Me.txt6Procesado)
        Me.TabPage3.Controls.Add(Me.txt6Ingreso)
        Me.TabPage3.Controls.Add(Me.txt6Retiro)
        Me.TabPage3.Controls.Add(Me.txt6Creacion)
        Me.TabPage3.Controls.Add(Me.dgvHistorial)
        Me.TabPage3.Controls.Add(Me.Label11)
        Me.TabPage3.Controls.Add(Me.txtBuscarItn)
        Me.TabPage3.Controls.Add(Me.dgvBusqueda)
        Me.TabPage3.Controls.Add(Me.Label10)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(887, 448)
        Me.TabPage3.TabIndex = 4
        Me.TabPage3.Text = "Búsquedas"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'txt6Entregado
        '
        Me.txt6Entregado.Location = New System.Drawing.Point(432, 317)
        Me.txt6Entregado.Name = "txt6Entregado"
        Me.txt6Entregado.ReadOnly = True
        Me.txt6Entregado.Size = New System.Drawing.Size(100, 20)
        Me.txt6Entregado.TabIndex = 11
        '
        'txt6Facturado
        '
        Me.txt6Facturado.Location = New System.Drawing.Point(432, 291)
        Me.txt6Facturado.Name = "txt6Facturado"
        Me.txt6Facturado.ReadOnly = True
        Me.txt6Facturado.Size = New System.Drawing.Size(100, 20)
        Me.txt6Facturado.TabIndex = 10
        '
        'txt6Procesado
        '
        Me.txt6Procesado.Location = New System.Drawing.Point(432, 265)
        Me.txt6Procesado.Name = "txt6Procesado"
        Me.txt6Procesado.ReadOnly = True
        Me.txt6Procesado.Size = New System.Drawing.Size(100, 20)
        Me.txt6Procesado.TabIndex = 9
        '
        'txt6Ingreso
        '
        Me.txt6Ingreso.Location = New System.Drawing.Point(432, 239)
        Me.txt6Ingreso.Name = "txt6Ingreso"
        Me.txt6Ingreso.ReadOnly = True
        Me.txt6Ingreso.Size = New System.Drawing.Size(100, 20)
        Me.txt6Ingreso.TabIndex = 8
        '
        'txt6Retiro
        '
        Me.txt6Retiro.Location = New System.Drawing.Point(432, 213)
        Me.txt6Retiro.Name = "txt6Retiro"
        Me.txt6Retiro.ReadOnly = True
        Me.txt6Retiro.Size = New System.Drawing.Size(100, 20)
        Me.txt6Retiro.TabIndex = 7
        '
        'txt6Creacion
        '
        Me.txt6Creacion.Location = New System.Drawing.Point(432, 187)
        Me.txt6Creacion.Name = "txt6Creacion"
        Me.txt6Creacion.ReadOnly = True
        Me.txt6Creacion.Size = New System.Drawing.Size(100, 20)
        Me.txt6Creacion.TabIndex = 6
        '
        'dgvHistorial
        '
        Me.dgvHistorial.AllowUserToAddRows = False
        Me.dgvHistorial.AllowUserToDeleteRows = False
        Me.dgvHistorial.AllowUserToResizeRows = False
        Me.dgvHistorial.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvHistorial.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col6Fecha, Me.col6Hora, Me.col6De, Me.col6Para})
        Me.dgvHistorial.Location = New System.Drawing.Point(316, 31)
        Me.dgvHistorial.Name = "dgvHistorial"
        Me.dgvHistorial.ReadOnly = True
        Me.dgvHistorial.Size = New System.Drawing.Size(534, 150)
        Me.dgvHistorial.TabIndex = 5
        '
        'col6Fecha
        '
        Me.col6Fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.col6Fecha.HeaderText = "Fecha"
        Me.col6Fecha.Name = "col6Fecha"
        Me.col6Fecha.ReadOnly = True
        Me.col6Fecha.Width = 62
        '
        'col6Hora
        '
        Me.col6Hora.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.col6Hora.HeaderText = "Hora"
        Me.col6Hora.Name = "col6Hora"
        Me.col6Hora.ReadOnly = True
        Me.col6Hora.Width = 55
        '
        'col6De
        '
        Me.col6De.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.col6De.HeaderText = "De"
        Me.col6De.Name = "col6De"
        Me.col6De.ReadOnly = True
        Me.col6De.Width = 27
        '
        'col6Para
        '
        Me.col6Para.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.col6Para.HeaderText = "Para"
        Me.col6Para.Name = "col6Para"
        Me.col6Para.ReadOnly = True
        Me.col6Para.Width = 35
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(313, 15)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(120, 13)
        Me.Label11.TabIndex = 4
        Me.Label11.Text = "Historial del documento:"
        '
        'txtBuscarItn
        '
        Me.txtBuscarItn.Location = New System.Drawing.Point(11, 31)
        Me.txtBuscarItn.Name = "txtBuscarItn"
        Me.txtBuscarItn.Size = New System.Drawing.Size(278, 20)
        Me.txtBuscarItn.TabIndex = 3
        '
        'dgvBusqueda
        '
        Me.dgvBusqueda.AllowUserToAddRows = False
        Me.dgvBusqueda.AllowUserToDeleteRows = False
        Me.dgvBusqueda.AllowUserToResizeRows = False
        Me.dgvBusqueda.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgvBusqueda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBusqueda.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col5Itn, Me.col5Ot, Me.col5Cliente, Me.col5Nombre})
        Me.dgvBusqueda.Location = New System.Drawing.Point(11, 57)
        Me.dgvBusqueda.MultiSelect = False
        Me.dgvBusqueda.Name = "dgvBusqueda"
        Me.dgvBusqueda.ReadOnly = True
        Me.dgvBusqueda.RowHeadersVisible = False
        Me.dgvBusqueda.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvBusqueda.Size = New System.Drawing.Size(278, 350)
        Me.dgvBusqueda.TabIndex = 2
        '
        'col5Itn
        '
        Me.col5Itn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.col5Itn.HeaderText = "Intervencion"
        Me.col5Itn.Name = "col5Itn"
        Me.col5Itn.ReadOnly = True
        Me.col5Itn.Width = 91
        '
        'col5Ot
        '
        Me.col5Ot.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.col5Ot.HeaderText = "OT"
        Me.col5Ot.Name = "col5Ot"
        Me.col5Ot.ReadOnly = True
        Me.col5Ot.Width = 47
        '
        'col5Cliente
        '
        Me.col5Cliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.col5Cliente.HeaderText = "Cliente"
        Me.col5Cliente.Name = "col5Cliente"
        Me.col5Cliente.ReadOnly = True
        Me.col5Cliente.Width = 64
        '
        'col5Nombre
        '
        Me.col5Nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.col5Nombre.HeaderText = "Nombre"
        Me.col5Nombre.Name = "col5Nombre"
        Me.col5Nombre.ReadOnly = True
        Me.col5Nombre.Width = 69
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(8, 15)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(272, 13)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "Búsqueda por Intervención / Orden de Trabajo / Cliente"
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.btnRefrescar)
        Me.TabPage4.Controls.Add(Me.Label20)
        Me.TabPage4.Controls.Add(Me.txtAboRuta)
        Me.TabPage4.Controls.Add(Me.txtTotalPlanta)
        Me.TabPage4.Controls.Add(Me.txtNoAboProceso)
        Me.TabPage4.Controls.Add(Me.lblTot1)
        Me.TabPage4.Controls.Add(Me.txtTotalGeneral)
        Me.TabPage4.Controls.Add(Me.lblTot2)
        Me.TabPage4.Controls.Add(Me.txtTotalRuta)
        Me.TabPage4.Controls.Add(Me.txtNoAboFacturacion)
        Me.TabPage4.Controls.Add(Me.txtTotalFacturacion)
        Me.TabPage4.Controls.Add(Me.lblTot3)
        Me.TabPage4.Controls.Add(Me.txtTotalProceso)
        Me.TabPage4.Controls.Add(Me.txtNoAboRuta)
        Me.TabPage4.Controls.Add(Me.txtTotalAbonados)
        Me.TabPage4.Controls.Add(Me.lblTotal)
        Me.TabPage4.Controls.Add(Me.txtAboPlanta)
        Me.TabPage4.Controls.Add(Me.txtTotalNoAbonados)
        Me.TabPage4.Controls.Add(Me.Label1)
        Me.TabPage4.Controls.Add(Me.txtAboFacturacion)
        Me.TabPage4.Controls.Add(Me.txtNoAboPlanta)
        Me.TabPage4.Controls.Add(Me.txtAboProceso)
        Me.TabPage4.Controls.Add(Me.Label4)
        Me.TabPage4.Controls.Add(Me.Label18)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(887, 448)
        Me.TabPage4.TabIndex = 6
        Me.TabPage4.Text = "Totales"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'btnRefrescar
        '
        Me.btnRefrescar.Location = New System.Drawing.Point(357, 168)
        Me.btnRefrescar.Name = "btnRefrescar"
        Me.btnRefrescar.Size = New System.Drawing.Size(75, 23)
        Me.btnRefrescar.TabIndex = 24
        Me.btnRefrescar.Text = "Calcular"
        Me.btnRefrescar.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(7, 96)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(42, 13)
        Me.Label20.TabIndex = 18
        Me.Label20.Text = "Totales"
        '
        'txtAboRuta
        '
        Me.txtAboRuta.Location = New System.Drawing.Point(332, 41)
        Me.txtAboRuta.Name = "txtAboRuta"
        Me.txtAboRuta.ReadOnly = True
        Me.txtAboRuta.Size = New System.Drawing.Size(100, 20)
        Me.txtAboRuta.TabIndex = 9
        Me.txtAboRuta.TabStop = False
        Me.txtAboRuta.Text = "0"
        Me.txtAboRuta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalPlanta
        '
        Me.txtTotalPlanta.Location = New System.Drawing.Point(454, 93)
        Me.txtTotalPlanta.Name = "txtTotalPlanta"
        Me.txtTotalPlanta.ReadOnly = True
        Me.txtTotalPlanta.Size = New System.Drawing.Size(100, 20)
        Me.txtTotalPlanta.TabIndex = 22
        Me.txtTotalPlanta.TabStop = False
        Me.txtTotalPlanta.Text = "0"
        Me.txtTotalPlanta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNoAboProceso
        '
        Me.txtNoAboProceso.Location = New System.Drawing.Point(90, 67)
        Me.txtNoAboProceso.Name = "txtNoAboProceso"
        Me.txtNoAboProceso.ReadOnly = True
        Me.txtNoAboProceso.Size = New System.Drawing.Size(100, 20)
        Me.txtNoAboProceso.TabIndex = 13
        Me.txtNoAboProceso.TabStop = False
        Me.txtNoAboProceso.Text = "0"
        Me.txtNoAboProceso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalGeneral
        '
        Me.txtTotalGeneral.Location = New System.Drawing.Point(588, 93)
        Me.txtTotalGeneral.Name = "txtTotalGeneral"
        Me.txtTotalGeneral.ReadOnly = True
        Me.txtTotalGeneral.Size = New System.Drawing.Size(100, 20)
        Me.txtTotalGeneral.TabIndex = 23
        Me.txtTotalGeneral.TabStop = False
        Me.txtTotalGeneral.Text = "0"
        Me.txtTotalGeneral.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalRuta
        '
        Me.txtTotalRuta.Location = New System.Drawing.Point(332, 93)
        Me.txtTotalRuta.Name = "txtTotalRuta"
        Me.txtTotalRuta.ReadOnly = True
        Me.txtTotalRuta.Size = New System.Drawing.Size(100, 20)
        Me.txtTotalRuta.TabIndex = 21
        Me.txtTotalRuta.TabStop = False
        Me.txtTotalRuta.Text = "0"
        Me.txtTotalRuta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNoAboFacturacion
        '
        Me.txtNoAboFacturacion.Location = New System.Drawing.Point(209, 67)
        Me.txtNoAboFacturacion.Name = "txtNoAboFacturacion"
        Me.txtNoAboFacturacion.ReadOnly = True
        Me.txtNoAboFacturacion.Size = New System.Drawing.Size(100, 20)
        Me.txtNoAboFacturacion.TabIndex = 14
        Me.txtNoAboFacturacion.TabStop = False
        Me.txtNoAboFacturacion.Text = "0"
        Me.txtNoAboFacturacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalFacturacion
        '
        Me.txtTotalFacturacion.Location = New System.Drawing.Point(209, 93)
        Me.txtTotalFacturacion.Name = "txtTotalFacturacion"
        Me.txtTotalFacturacion.ReadOnly = True
        Me.txtTotalFacturacion.Size = New System.Drawing.Size(100, 20)
        Me.txtTotalFacturacion.TabIndex = 20
        Me.txtTotalFacturacion.TabStop = False
        Me.txtTotalFacturacion.Text = "0"
        Me.txtTotalFacturacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalProceso
        '
        Me.txtTotalProceso.Location = New System.Drawing.Point(90, 93)
        Me.txtTotalProceso.Name = "txtTotalProceso"
        Me.txtTotalProceso.ReadOnly = True
        Me.txtTotalProceso.Size = New System.Drawing.Size(100, 20)
        Me.txtTotalProceso.TabIndex = 19
        Me.txtTotalProceso.TabStop = False
        Me.txtTotalProceso.Text = "0"
        Me.txtTotalProceso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNoAboRuta
        '
        Me.txtNoAboRuta.Location = New System.Drawing.Point(332, 67)
        Me.txtNoAboRuta.Name = "txtNoAboRuta"
        Me.txtNoAboRuta.ReadOnly = True
        Me.txtNoAboRuta.Size = New System.Drawing.Size(100, 20)
        Me.txtNoAboRuta.TabIndex = 15
        Me.txtNoAboRuta.TabStop = False
        Me.txtNoAboRuta.Text = "0"
        Me.txtNoAboRuta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalAbonados
        '
        Me.txtTotalAbonados.Location = New System.Drawing.Point(588, 41)
        Me.txtTotalAbonados.Name = "txtTotalAbonados"
        Me.txtTotalAbonados.ReadOnly = True
        Me.txtTotalAbonados.Size = New System.Drawing.Size(100, 20)
        Me.txtTotalAbonados.TabIndex = 11
        Me.txtTotalAbonados.TabStop = False
        Me.txtTotalAbonados.Text = "0"
        Me.txtTotalAbonados.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAboPlanta
        '
        Me.txtAboPlanta.Location = New System.Drawing.Point(454, 41)
        Me.txtAboPlanta.Name = "txtAboPlanta"
        Me.txtAboPlanta.ReadOnly = True
        Me.txtAboPlanta.Size = New System.Drawing.Size(100, 20)
        Me.txtAboPlanta.TabIndex = 10
        Me.txtAboPlanta.TabStop = False
        Me.txtAboPlanta.Text = "0"
        Me.txtAboPlanta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalNoAbonados
        '
        Me.txtTotalNoAbonados.Location = New System.Drawing.Point(588, 67)
        Me.txtTotalNoAbonados.Name = "txtTotalNoAbonados"
        Me.txtTotalNoAbonados.ReadOnly = True
        Me.txtTotalNoAbonados.Size = New System.Drawing.Size(100, 20)
        Me.txtTotalNoAbonados.TabIndex = 17
        Me.txtTotalNoAbonados.TabStop = False
        Me.txtTotalNoAbonados.Text = "0"
        Me.txtTotalNoAbonados.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(451, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(110, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Terminados en Planta"
        '
        'txtAboFacturacion
        '
        Me.txtAboFacturacion.Location = New System.Drawing.Point(209, 41)
        Me.txtAboFacturacion.Name = "txtAboFacturacion"
        Me.txtAboFacturacion.ReadOnly = True
        Me.txtAboFacturacion.Size = New System.Drawing.Size(100, 20)
        Me.txtAboFacturacion.TabIndex = 8
        Me.txtAboFacturacion.TabStop = False
        Me.txtAboFacturacion.Text = "0"
        Me.txtAboFacturacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNoAboPlanta
        '
        Me.txtNoAboPlanta.Location = New System.Drawing.Point(454, 67)
        Me.txtNoAboPlanta.Name = "txtNoAboPlanta"
        Me.txtNoAboPlanta.ReadOnly = True
        Me.txtNoAboPlanta.Size = New System.Drawing.Size(100, 20)
        Me.txtNoAboPlanta.TabIndex = 16
        Me.txtNoAboPlanta.TabStop = False
        Me.txtNoAboPlanta.Text = "0"
        Me.txtNoAboPlanta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAboProceso
        '
        Me.txtAboProceso.Location = New System.Drawing.Point(90, 41)
        Me.txtAboProceso.Name = "txtAboProceso"
        Me.txtAboProceso.ReadOnly = True
        Me.txtAboProceso.Size = New System.Drawing.Size(100, 20)
        Me.txtAboProceso.TabIndex = 7
        Me.txtAboProceso.TabStop = False
        Me.txtAboProceso.Text = "0"
        Me.txtAboProceso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 44)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Abonados:"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(7, 70)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(77, 13)
        Me.Label18.TabIndex = 12
        Me.Label18.Text = "NO Abonados:"
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnSalir.Location = New System.Drawing.Point(816, 480)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(75, 23)
        Me.btnSalir.TabIndex = 25
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'col5Fecha
        '
        Me.col5Fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.col5Fecha.HeaderText = "Fecha"
        Me.col5Fecha.Name = "col5Fecha"
        Me.col5Fecha.ReadOnly = True
        Me.col5Fecha.Width = 62
        '
        'col5Retirados
        '
        Me.col5Retirados.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.col5Retirados.DefaultCellStyle = DataGridViewCellStyle8
        Me.col5Retirados.HeaderText = "Retirados"
        Me.col5Retirados.Name = "col5Retirados"
        Me.col5Retirados.ReadOnly = True
        Me.col5Retirados.Width = 77
        '
        'col5Ingresados
        '
        Me.col5Ingresados.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.col5Ingresados.DefaultCellStyle = DataGridViewCellStyle9
        Me.col5Ingresados.HeaderText = "Ingresados"
        Me.col5Ingresados.Name = "col5Ingresados"
        Me.col5Ingresados.ReadOnly = True
        Me.col5Ingresados.Width = 84
        '
        'col5Prefacturacion
        '
        Me.col5Prefacturacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.col5Prefacturacion.DefaultCellStyle = DataGridViewCellStyle10
        Me.col5Prefacturacion.HeaderText = "Prefacturación"
        Me.col5Prefacturacion.Name = "col5Prefacturacion"
        Me.col5Prefacturacion.ReadOnly = True
        Me.col5Prefacturacion.Width = 101
        '
        'col5Logistica
        '
        Me.col5Logistica.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.col5Logistica.DefaultCellStyle = DataGridViewCellStyle11
        Me.col5Logistica.HeaderText = "Logistica"
        Me.col5Logistica.Name = "col5Logistica"
        Me.col5Logistica.ReadOnly = True
        Me.col5Logistica.Width = 74
        '
        'col5Entregados
        '
        Me.col5Entregados.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.col5Entregados.DefaultCellStyle = DataGridViewCellStyle12
        Me.col5Entregados.HeaderText = "Entregados"
        Me.col5Entregados.Name = "col5Entregados"
        Me.col5Entregados.ReadOnly = True
        Me.col5Entregados.Width = 86
        '
        'frmRptRecargas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnSalir
        Me.ClientSize = New System.Drawing.Size(895, 508)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.TabControl1)
        Me.MinimumSize = New System.Drawing.Size(874, 542)
        Me.Name = "frmRptRecargas"
        Me.Text = "Seguimientos de Recargas"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSectores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.dgvSeguimiento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        CType(Me.dgvHistorial, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvBusqueda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents txtNoAboProceso As System.Windows.Forms.TextBox
    Friend WithEvents txtNoAboFacturacion As System.Windows.Forms.TextBox
    Friend WithEvents txtNoAboRuta As System.Windows.Forms.TextBox
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents dtpHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnConsultar As System.Windows.Forms.Button
    Friend WithEvents dgvSeguimiento As System.Windows.Forms.DataGridView
    Friend WithEvents txtTot5 As System.Windows.Forms.TextBox
    Friend WithEvents txtTot4 As System.Windows.Forms.TextBox
    Friend WithEvents txtTot2 As System.Windows.Forms.TextBox
    Friend WithEvents txtTot1 As System.Windows.Forms.TextBox
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtBuscarItn As System.Windows.Forms.TextBox
    Friend WithEvents dgvBusqueda As System.Windows.Forms.DataGridView
    Friend WithEvents col5Itn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col5Ot As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col5Cliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col5Nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvHistorial As System.Windows.Forms.DataGridView
    Friend WithEvents col6Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col6Hora As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col6De As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents col6Para As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txt6Entregado As System.Windows.Forms.TextBox
    Friend WithEvents txt6Facturado As System.Windows.Forms.TextBox
    Friend WithEvents txt6Procesado As System.Windows.Forms.TextBox
    Friend WithEvents txt6Ingreso As System.Windows.Forms.TextBox
    Friend WithEvents txt6Retiro As System.Windows.Forms.TextBox
    Friend WithEvents txt6Creacion As System.Windows.Forms.TextBox
    Friend WithEvents txtTot3 As System.Windows.Forms.TextBox
    Friend WithEvents btnRefrescar As System.Windows.Forms.Button
    Friend WithEvents txtTotalNoAbonados As System.Windows.Forms.TextBox
    Friend WithEvents lblTot1 As System.Windows.Forms.Label
    Friend WithEvents lblTot2 As System.Windows.Forms.Label
    Friend WithEvents lblTot3 As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents txtNoAboPlanta As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtAboProceso As System.Windows.Forms.TextBox
    Friend WithEvents txtAboFacturacion As System.Windows.Forms.TextBox
    Friend WithEvents txtAboRuta As System.Windows.Forms.TextBox
    Friend WithEvents txtAboPlanta As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalAbonados As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalPlanta As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalGeneral As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalRuta As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalFacturacion As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalProceso As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents dgvSectores As System.Windows.Forms.DataGridView
    Friend WithEvents colTab4Sectores As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colTab4Intervenciones As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents btnVer As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents clbEstados As System.Windows.Forms.CheckedListBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents clbAbonado As System.Windows.Forms.CheckedListBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents clbTipo As System.Windows.Forms.CheckedListBox
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents colTab4Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTab4Itn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTab4Ot As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTab4Tipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTab4Rto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTab4Cliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTab4Nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTab4Equipos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTab4ExtOk As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTab4ExtBaja As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTab4MangaOk As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTab4MangaBaja As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTab4Estado As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colTab4Abonado As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colTab4Sector As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTab4Ruta As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents col5Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col5Retirados As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col5Ingresados As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col5Prefacturacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col5Logistica As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col5Entregados As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
