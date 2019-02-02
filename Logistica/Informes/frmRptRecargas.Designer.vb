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
        Me.components = New System.ComponentModel.Container
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
        Dim Label31 As System.Windows.Forms.Label
        Dim Label28 As System.Windows.Forms.Label
        Dim Label29 As System.Windows.Forms.Label
        Dim Label30 As System.Windows.Forms.Label
        Dim Label27 As System.Windows.Forms.Label
        Dim Label26 As System.Windows.Forms.Label
        Dim Label25 As System.Windows.Forms.Label
        Dim Label24 As System.Windows.Forms.Label
        Dim Label23 As System.Windows.Forms.Label
        Dim Label22 As System.Windows.Forms.Label
        Dim Label21 As System.Windows.Forms.Label
        Dim Label3 As System.Windows.Forms.Label
        Dim Label32 As System.Windows.Forms.Label
        Dim Label1 As System.Windows.Forms.Label
        Dim Label4 As System.Windows.Forms.Label
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
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
        Me.col5Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col5Retirados = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col5Ingresados = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col5Prefacturacion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col5Logistica = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col5Entregados = New System.Windows.Forms.DataGridViewTextBoxColumn
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
        Me.TabPage5 = New System.Windows.Forms.TabPage
        Me.Button2 = New System.Windows.Forms.Button
        Me.lblTitulo = New System.Windows.Forms.Label
        Me.txt2b = New System.Windows.Forms.TextBox
        Me.txt1a = New System.Windows.Forms.TextBox
        Me.lblBuscando = New System.Windows.Forms.Label
        Me.txtTot = New System.Windows.Forms.TextBox
        Me.dgv5 = New System.Windows.Forms.DataGridView
        Me.col7Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col7Intervencion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col7Codigo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col7Cliente = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col7Sucursal = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col7Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col7Fecha2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col7Obs = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col7Rep = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cms = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuVer = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuSegto = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuComentarios = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator
        Me.mnuPallet = New System.Windows.Forms.ToolStripMenuItem
        Me.Button1 = New System.Windows.Forms.Button
        Me.txt6 = New System.Windows.Forms.TextBox
        Me.txt5c = New System.Windows.Forms.TextBox
        Me.txt5b = New System.Windows.Forms.TextBox
        Me.txt5a = New System.Windows.Forms.TextBox
        Me.txt4c = New System.Windows.Forms.TextBox
        Me.txt4b = New System.Windows.Forms.TextBox
        Me.txt4a = New System.Windows.Forms.TextBox
        Me.txt3 = New System.Windows.Forms.TextBox
        Me.txt2 = New System.Windows.Forms.TextBox
        Me.txt1b = New System.Windows.Forms.TextBox
        Me.btnSalir = New System.Windows.Forms.Button
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
        Label31 = New System.Windows.Forms.Label
        Label28 = New System.Windows.Forms.Label
        Label29 = New System.Windows.Forms.Label
        Label30 = New System.Windows.Forms.Label
        Label27 = New System.Windows.Forms.Label
        Label26 = New System.Windows.Forms.Label
        Label25 = New System.Windows.Forms.Label
        Label24 = New System.Windows.Forms.Label
        Label23 = New System.Windows.Forms.Label
        Label22 = New System.Windows.Forms.Label
        Label21 = New System.Windows.Forms.Label
        Label3 = New System.Windows.Forms.Label
        Label32 = New System.Windows.Forms.Label
        Label1 = New System.Windows.Forms.Label
        Label4 = New System.Windows.Forms.Label
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
        Me.TabPage5.SuspendLayout()
        CType(Me.dgv5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cms.SuspendLayout()
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
        'Label31
        '
        Label31.AutoSize = True
        Label31.Location = New System.Drawing.Point(21, 438)
        Label31.Name = "Label31"
        Label31.Size = New System.Drawing.Size(69, 13)
        Label31.TabIndex = 70
        Label31.Text = "6. Mostrador:"
        '
        'Label28
        '
        Label28.AutoSize = True
        Label28.Location = New System.Drawing.Point(21, 393)
        Label28.Name = "Label28"
        Label28.Size = New System.Drawing.Size(63, 13)
        Label28.TabIndex = 59
        Label28.Text = "5C. S. Fijos:"
        '
        'Label29
        '
        Label29.AutoSize = True
        Label29.Location = New System.Drawing.Point(19, 367)
        Label29.Name = "Label29"
        Label29.Size = New System.Drawing.Size(65, 13)
        Label29.TabIndex = 58
        Label29.Text = "5B. Abonos:"
        '
        'Label30
        '
        Label30.AutoSize = True
        Label30.Location = New System.Drawing.Point(19, 338)
        Label30.Name = "Label30"
        Label30.Size = New System.Drawing.Size(71, 13)
        Label30.TabIndex = 57
        Label30.Text = "5A. Logistica:"
        '
        'Label27
        '
        Label27.AutoSize = True
        Label27.Location = New System.Drawing.Point(21, 272)
        Label27.Name = "Label27"
        Label27.Size = New System.Drawing.Size(44, 13)
        Label27.TabIndex = 56
        Label27.Text = "S. Fijos:"
        '
        'Label26
        '
        Label26.AutoSize = True
        Label26.Location = New System.Drawing.Point(21, 246)
        Label26.Name = "Label26"
        Label26.Size = New System.Drawing.Size(46, 13)
        Label26.TabIndex = 55
        Label26.Text = "Abonos:"
        '
        'Label25
        '
        Label25.AutoSize = True
        Label25.Location = New System.Drawing.Point(19, 307)
        Label25.Name = "Label25"
        Label25.Size = New System.Drawing.Size(128, 13)
        Label25.TabIndex = 54
        Label25.Text = "PENDIENTE CON RUTA"
        '
        'Label24
        '
        Label24.AutoSize = True
        Label24.Location = New System.Drawing.Point(21, 219)
        Label24.Name = "Label24"
        Label24.Size = New System.Drawing.Size(52, 13)
        Label24.TabIndex = 53
        Label24.Text = "Logistica:"
        '
        'Label23
        '
        Label23.AutoSize = True
        Label23.Location = New System.Drawing.Point(19, 193)
        Label23.Name = "Label23"
        Label23.Size = New System.Drawing.Size(69, 13)
        Label23.TabIndex = 52
        Label23.Text = "PENDIENTE"
        '
        'Label22
        '
        Label22.AutoSize = True
        Label22.Location = New System.Drawing.Point(21, 162)
        Label22.Name = "Label22"
        Label22.Size = New System.Drawing.Size(70, 13)
        Label22.TabIndex = 51
        Label22.Text = "En contados:"
        '
        'Label21
        '
        Label21.AutoSize = True
        Label21.Location = New System.Drawing.Point(19, 113)
        Label21.Name = "Label21"
        Label21.Size = New System.Drawing.Size(145, 13)
        Label21.TabIndex = 50
        Label21.Text = "En Administración de Ventas:"
        '
        'Label3
        '
        Label3.AutoSize = True
        Label3.Location = New System.Drawing.Point(19, 75)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(64, 13)
        Label3.TabIndex = 49
        Label3.Text = "En proceso:"
        '
        'Label32
        '
        Label32.AutoSize = True
        Label32.Location = New System.Drawing.Point(151, 490)
        Label32.Name = "Label32"
        Label32.Size = New System.Drawing.Size(31, 13)
        Label32.TabIndex = 74
        Label32.Text = "Total"
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(19, 49)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(99, 13)
        Label1.TabIndex = 76
        Label1.Text = "Espera de proceso:"
        '
        'Label4
        '
        Label4.AutoSize = True
        Label4.Location = New System.Drawing.Point(21, 138)
        Label4.Name = "Label4"
        Label4.Size = New System.Drawing.Size(56, 13)
        Label4.TabIndex = 77
        Label4.Text = "En Ventas"
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1062, 544)
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
        Me.TabPage1.Size = New System.Drawing.Size(1054, 518)
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
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Format = "N0"
        Me.colTab4Intervenciones.DefaultCellStyle = DataGridViewCellStyle1
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
        Me.TabPage2.Size = New System.Drawing.Size(1054, 518)
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
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.col5Retirados.DefaultCellStyle = DataGridViewCellStyle2
        Me.col5Retirados.HeaderText = "Retirados"
        Me.col5Retirados.Name = "col5Retirados"
        Me.col5Retirados.ReadOnly = True
        Me.col5Retirados.Width = 77
        '
        'col5Ingresados
        '
        Me.col5Ingresados.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.col5Ingresados.DefaultCellStyle = DataGridViewCellStyle3
        Me.col5Ingresados.HeaderText = "Ingresados"
        Me.col5Ingresados.Name = "col5Ingresados"
        Me.col5Ingresados.ReadOnly = True
        Me.col5Ingresados.Width = 84
        '
        'col5Prefacturacion
        '
        Me.col5Prefacturacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.col5Prefacturacion.DefaultCellStyle = DataGridViewCellStyle4
        Me.col5Prefacturacion.HeaderText = "Prefacturación"
        Me.col5Prefacturacion.Name = "col5Prefacturacion"
        Me.col5Prefacturacion.ReadOnly = True
        Me.col5Prefacturacion.Width = 101
        '
        'col5Logistica
        '
        Me.col5Logistica.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.col5Logistica.DefaultCellStyle = DataGridViewCellStyle5
        Me.col5Logistica.HeaderText = "Logistica"
        Me.col5Logistica.Name = "col5Logistica"
        Me.col5Logistica.ReadOnly = True
        Me.col5Logistica.Width = 74
        '
        'col5Entregados
        '
        Me.col5Entregados.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.col5Entregados.DefaultCellStyle = DataGridViewCellStyle6
        Me.col5Entregados.HeaderText = "Entregados"
        Me.col5Entregados.Name = "col5Entregados"
        Me.col5Entregados.ReadOnly = True
        Me.col5Entregados.Width = 86
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
        Me.TabPage3.Size = New System.Drawing.Size(1054, 518)
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
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.Button2)
        Me.TabPage5.Controls.Add(Me.lblTitulo)
        Me.TabPage5.Controls.Add(Me.txt2b)
        Me.TabPage5.Controls.Add(Label4)
        Me.TabPage5.Controls.Add(Label1)
        Me.TabPage5.Controls.Add(Me.txt1a)
        Me.TabPage5.Controls.Add(Me.lblBuscando)
        Me.TabPage5.Controls.Add(Label32)
        Me.TabPage5.Controls.Add(Me.txtTot)
        Me.TabPage5.Controls.Add(Me.dgv5)
        Me.TabPage5.Controls.Add(Me.Button1)
        Me.TabPage5.Controls.Add(Label31)
        Me.TabPage5.Controls.Add(Me.txt6)
        Me.TabPage5.Controls.Add(Me.txt5c)
        Me.TabPage5.Controls.Add(Me.txt5b)
        Me.TabPage5.Controls.Add(Me.txt5a)
        Me.TabPage5.Controls.Add(Me.txt4c)
        Me.TabPage5.Controls.Add(Me.txt4b)
        Me.TabPage5.Controls.Add(Me.txt4a)
        Me.TabPage5.Controls.Add(Me.txt3)
        Me.TabPage5.Controls.Add(Me.txt2)
        Me.TabPage5.Controls.Add(Me.txt1b)
        Me.TabPage5.Controls.Add(Label28)
        Me.TabPage5.Controls.Add(Label29)
        Me.TabPage5.Controls.Add(Label30)
        Me.TabPage5.Controls.Add(Label27)
        Me.TabPage5.Controls.Add(Label26)
        Me.TabPage5.Controls.Add(Label25)
        Me.TabPage5.Controls.Add(Label24)
        Me.TabPage5.Controls.Add(Label23)
        Me.TabPage5.Controls.Add(Label22)
        Me.TabPage5.Controls.Add(Label21)
        Me.TabPage5.Controls.Add(Label3)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(1054, 518)
        Me.TabPage5.TabIndex = 7
        Me.TabPage5.Text = "Totales"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(22, 481)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 80
        Me.Button2.Text = "Todo"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.Location = New System.Drawing.Point(345, 11)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(701, 13)
        Me.lblTitulo.TabIndex = 79
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txt2b
        '
        Me.txt2b.Location = New System.Drawing.Point(226, 135)
        Me.txt2b.Name = "txt2b"
        Me.txt2b.ReadOnly = True
        Me.txt2b.Size = New System.Drawing.Size(100, 20)
        Me.txt2b.TabIndex = 78
        Me.txt2b.TabStop = False
        Me.txt2b.Text = "0"
        Me.txt2b.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt1a
        '
        Me.txt1a.Location = New System.Drawing.Point(226, 46)
        Me.txt1a.Name = "txt1a"
        Me.txt1a.ReadOnly = True
        Me.txt1a.Size = New System.Drawing.Size(100, 20)
        Me.txt1a.TabIndex = 75
        Me.txt1a.TabStop = False
        Me.txt1a.Text = "0"
        Me.txt1a.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblBuscando
        '
        Me.lblBuscando.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBuscando.Location = New System.Drawing.Point(569, 219)
        Me.lblBuscando.Name = "lblBuscando"
        Me.lblBuscando.Size = New System.Drawing.Size(292, 59)
        Me.lblBuscando.TabIndex = 27
        Me.lblBuscando.Text = "Por favor, espere..."
        Me.lblBuscando.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblBuscando.Visible = False
        '
        'txtTot
        '
        Me.txtTot.Location = New System.Drawing.Point(226, 483)
        Me.txtTot.Name = "txtTot"
        Me.txtTot.ReadOnly = True
        Me.txtTot.Size = New System.Drawing.Size(100, 20)
        Me.txtTot.TabIndex = 73
        Me.txtTot.TabStop = False
        Me.txtTot.Text = "0"
        Me.txtTot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dgv5
        '
        Me.dgv5.AllowUserToAddRows = False
        Me.dgv5.AllowUserToDeleteRows = False
        Me.dgv5.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv5.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col7Fecha, Me.col7Intervencion, Me.col7Codigo, Me.col7Cliente, Me.col7Sucursal, Me.col7Cantidad, Me.col7Fecha2, Me.col7Obs, Me.col7Rep})
        Me.dgv5.ContextMenuStrip = Me.cms
        Me.dgv5.Location = New System.Drawing.Point(345, 33)
        Me.dgv5.Name = "dgv5"
        Me.dgv5.ReadOnly = True
        Me.dgv5.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv5.Size = New System.Drawing.Size(701, 479)
        Me.dgv5.TabIndex = 72
        '
        'col7Fecha
        '
        Me.col7Fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.col7Fecha.HeaderText = "Fecha a ret"
        Me.col7Fecha.Name = "col7Fecha"
        Me.col7Fecha.ReadOnly = True
        Me.col7Fecha.Width = 86
        '
        'col7Intervencion
        '
        Me.col7Intervencion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.col7Intervencion.HeaderText = "Intervencion"
        Me.col7Intervencion.Name = "col7Intervencion"
        Me.col7Intervencion.ReadOnly = True
        Me.col7Intervencion.Width = 91
        '
        'col7Codigo
        '
        Me.col7Codigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.col7Codigo.HeaderText = "Codigo"
        Me.col7Codigo.Name = "col7Codigo"
        Me.col7Codigo.ReadOnly = True
        Me.col7Codigo.Width = 65
        '
        'col7Cliente
        '
        Me.col7Cliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.col7Cliente.HeaderText = "Cliente"
        Me.col7Cliente.Name = "col7Cliente"
        Me.col7Cliente.ReadOnly = True
        '
        'col7Sucursal
        '
        Me.col7Sucursal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.col7Sucursal.HeaderText = "Sucursal"
        Me.col7Sucursal.Name = "col7Sucursal"
        Me.col7Sucursal.ReadOnly = True
        '
        'col7Cantidad
        '
        Me.col7Cantidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "N0"
        Me.col7Cantidad.DefaultCellStyle = DataGridViewCellStyle7
        Me.col7Cantidad.HeaderText = "Cantidad"
        Me.col7Cantidad.Name = "col7Cantidad"
        Me.col7Cantidad.ReadOnly = True
        Me.col7Cantidad.Width = 74
        '
        'col7Fecha2
        '
        Me.col7Fecha2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.col7Fecha2.HeaderText = "Fecha ret/pist"
        Me.col7Fecha2.Name = "col7Fecha2"
        Me.col7Fecha2.ReadOnly = True
        Me.col7Fecha2.Width = 98
        '
        'col7Obs
        '
        Me.col7Obs.HeaderText = "Obs"
        Me.col7Obs.Name = "col7Obs"
        Me.col7Obs.ReadOnly = True
        Me.col7Obs.Visible = False
        '
        'col7Rep
        '
        Me.col7Rep.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.col7Rep.HeaderText = "Rep"
        Me.col7Rep.Name = "col7Rep"
        Me.col7Rep.ReadOnly = True
        Me.col7Rep.Width = 52
        '
        'cms
        '
        Me.cms.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuVer, Me.mnuSegto, Me.mnuComentarios, Me.ToolStripMenuItem1, Me.mnuPallet})
        Me.cms.Name = "cms"
        Me.cms.Size = New System.Drawing.Size(254, 98)
        '
        'mnuVer
        '
        Me.mnuVer.Name = "mnuVer"
        Me.mnuVer.Size = New System.Drawing.Size(253, 22)
        Me.mnuVer.Text = "Ver intervencion..."
        '
        'mnuSegto
        '
        Me.mnuSegto.Name = "mnuSegto"
        Me.mnuSegto.Size = New System.Drawing.Size(253, 22)
        Me.mnuSegto.Text = "Seguimiento de documentacion..."
        '
        'mnuComentarios
        '
        Me.mnuComentarios.Name = "mnuComentarios"
        Me.mnuComentarios.Size = New System.Drawing.Size(253, 22)
        Me.mnuComentarios.Text = "Comentarios..."
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(250, 6)
        '
        'mnuPallet
        '
        Me.mnuPallet.Name = "mnuPallet"
        Me.mnuPallet.Size = New System.Drawing.Size(253, 22)
        Me.mnuPallet.Text = "Pallet..."
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(11, 6)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(328, 23)
        Me.Button1.TabIndex = 71
        Me.Button1.Text = "Calcular"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txt6
        '
        Me.txt6.Location = New System.Drawing.Point(226, 435)
        Me.txt6.Name = "txt6"
        Me.txt6.ReadOnly = True
        Me.txt6.Size = New System.Drawing.Size(100, 20)
        Me.txt6.TabIndex = 69
        Me.txt6.TabStop = False
        Me.txt6.Text = "0"
        Me.txt6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt5c
        '
        Me.txt5c.Location = New System.Drawing.Point(226, 390)
        Me.txt5c.Name = "txt5c"
        Me.txt5c.ReadOnly = True
        Me.txt5c.Size = New System.Drawing.Size(100, 20)
        Me.txt5c.TabIndex = 68
        Me.txt5c.TabStop = False
        Me.txt5c.Text = "0"
        Me.txt5c.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt5b
        '
        Me.txt5b.Location = New System.Drawing.Point(226, 364)
        Me.txt5b.Name = "txt5b"
        Me.txt5b.ReadOnly = True
        Me.txt5b.Size = New System.Drawing.Size(100, 20)
        Me.txt5b.TabIndex = 67
        Me.txt5b.TabStop = False
        Me.txt5b.Text = "0"
        Me.txt5b.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt5a
        '
        Me.txt5a.Location = New System.Drawing.Point(226, 335)
        Me.txt5a.Name = "txt5a"
        Me.txt5a.ReadOnly = True
        Me.txt5a.Size = New System.Drawing.Size(100, 20)
        Me.txt5a.TabIndex = 66
        Me.txt5a.TabStop = False
        Me.txt5a.Text = "0"
        Me.txt5a.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt4c
        '
        Me.txt4c.Location = New System.Drawing.Point(226, 269)
        Me.txt4c.Name = "txt4c"
        Me.txt4c.ReadOnly = True
        Me.txt4c.Size = New System.Drawing.Size(100, 20)
        Me.txt4c.TabIndex = 65
        Me.txt4c.TabStop = False
        Me.txt4c.Text = "0"
        Me.txt4c.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt4b
        '
        Me.txt4b.Location = New System.Drawing.Point(226, 243)
        Me.txt4b.Name = "txt4b"
        Me.txt4b.ReadOnly = True
        Me.txt4b.Size = New System.Drawing.Size(100, 20)
        Me.txt4b.TabIndex = 64
        Me.txt4b.TabStop = False
        Me.txt4b.Text = "0"
        Me.txt4b.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt4a
        '
        Me.txt4a.Location = New System.Drawing.Point(226, 216)
        Me.txt4a.Name = "txt4a"
        Me.txt4a.ReadOnly = True
        Me.txt4a.Size = New System.Drawing.Size(100, 20)
        Me.txt4a.TabIndex = 63
        Me.txt4a.TabStop = False
        Me.txt4a.Text = "0"
        Me.txt4a.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt3
        '
        Me.txt3.Location = New System.Drawing.Point(226, 159)
        Me.txt3.Name = "txt3"
        Me.txt3.ReadOnly = True
        Me.txt3.Size = New System.Drawing.Size(100, 20)
        Me.txt3.TabIndex = 62
        Me.txt3.TabStop = False
        Me.txt3.Text = "0"
        Me.txt3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt2
        '
        Me.txt2.Location = New System.Drawing.Point(226, 110)
        Me.txt2.Name = "txt2"
        Me.txt2.ReadOnly = True
        Me.txt2.Size = New System.Drawing.Size(100, 20)
        Me.txt2.TabIndex = 61
        Me.txt2.TabStop = False
        Me.txt2.Text = "0"
        Me.txt2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt1b
        '
        Me.txt1b.Location = New System.Drawing.Point(226, 72)
        Me.txt1b.Name = "txt1b"
        Me.txt1b.ReadOnly = True
        Me.txt1b.Size = New System.Drawing.Size(100, 20)
        Me.txt1b.TabIndex = 60
        Me.txt1b.TabStop = False
        Me.txt1b.Text = "0"
        Me.txt1b.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnSalir.Location = New System.Drawing.Point(983, 550)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(75, 23)
        Me.btnSalir.TabIndex = 25
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'frmRptRecargas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnSalir
        Me.ClientSize = New System.Drawing.Size(1062, 578)
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
        Me.TabPage5.ResumeLayout(False)
        Me.TabPage5.PerformLayout()
        CType(Me.dgv5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cms.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents btnSalir As System.Windows.Forms.Button
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
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents txt6 As System.Windows.Forms.TextBox
    Friend WithEvents txt5c As System.Windows.Forms.TextBox
    Friend WithEvents txt5b As System.Windows.Forms.TextBox
    Friend WithEvents txt5a As System.Windows.Forms.TextBox
    Friend WithEvents txt4c As System.Windows.Forms.TextBox
    Friend WithEvents txt4b As System.Windows.Forms.TextBox
    Friend WithEvents txt4a As System.Windows.Forms.TextBox
    Friend WithEvents txt3 As System.Windows.Forms.TextBox
    Friend WithEvents txt2 As System.Windows.Forms.TextBox
    Friend WithEvents txt1b As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents dgv5 As System.Windows.Forms.DataGridView
    Friend WithEvents txtTot As System.Windows.Forms.TextBox
    Friend WithEvents cms As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuVer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSegto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblBuscando As System.Windows.Forms.Label
    Friend WithEvents txt1a As System.Windows.Forms.TextBox
    Friend WithEvents txt2b As System.Windows.Forms.TextBox
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents mnuComentarios As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents col7Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col7Intervencion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col7Codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col7Cliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col7Sucursal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col7Cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col7Fecha2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col7Obs As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col7Rep As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuPallet As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button2 As System.Windows.Forms.Button
End Class
