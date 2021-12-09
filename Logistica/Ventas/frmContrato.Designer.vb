<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmContrato
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
        Dim Label5 As System.Windows.Forms.Label
        Dim EstadoContrato As System.Windows.Forms.Label
        Dim Label15 As System.Windows.Forms.Label
        Dim Label12 As System.Windows.Forms.Label
        Dim Label13 As System.Windows.Forms.Label
        Dim Label11 As System.Windows.Forms.Label
        Dim Label10 As System.Windows.Forms.Label
        Dim Label9 As System.Windows.Forms.Label
        Dim Label1 As System.Windows.Forms.Label
        Dim Label6 As System.Windows.Forms.Label
        Dim Label8 As System.Windows.Forms.Label
        Dim Label4 As System.Windows.Forms.Label
        Dim Label3 As System.Windows.Forms.Label
        Dim Label2 As System.Windows.Forms.Label
        Dim Label36 As System.Windows.Forms.Label
        Dim Label34 As System.Windows.Forms.Label
        Dim Label30 As System.Windows.Forms.Label
        Dim Label21 As System.Windows.Forms.Label
        Dim Label20 As System.Windows.Forms.Label
        Dim Label56 As System.Windows.Forms.Label
        Dim Label55 As System.Windows.Forms.Label
        Dim Label53 As System.Windows.Forms.Label
        Dim Label32 As System.Windows.Forms.Label
        Dim Label16 As System.Windows.Forms.Label
        Dim Label14 As System.Windows.Forms.Label
        Me.tab = New System.Windows.Forms.TabControl
        Me.TabGeneral = New System.Windows.Forms.TabPage
        Me.nudDuracion = New System.Windows.Forms.NumericUpDown
        Me.txtObs = New System.Windows.Forms.TextBox
        Me.cboVendedor = New System.Windows.Forms.ComboBox
        Me.txtDescripcion = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.chk639 = New System.Windows.Forms.CheckBox
        Me.chkMantenimientoRed = New System.Windows.Forms.CheckBox
        Me.chkMantenimientoBocas = New System.Windows.Forms.CheckBox
        Me.chkPhMangueras = New System.Windows.Forms.CheckBox
        Me.txtDetalle639 = New System.Windows.Forms.TextBox
        Me.txtMantIntRedHdri = New System.Windows.Forms.TextBox
        Me.txtMantBocasHidr = New System.Windows.Forms.TextBox
        Me.txtPhMangueras = New System.Windows.Forms.TextBox
        Me.txtOc = New System.Windows.Forms.TextBox
        Me.txtMailOperativo = New System.Windows.Forms.TextBox
        Me.txtTelefonoOperativo = New System.Windows.Forms.TextBox
        Me.dtpInicio = New System.Windows.Forms.DateTimePicker
        Me.txtMailComercial = New System.Windows.Forms.TextBox
        Me.txtTelefonoComercial = New System.Windows.Forms.TextBox
        Me.txtContactoOperativo = New System.Windows.Forms.TextBox
        Me.txtConcactoComercial = New System.Windows.Forms.TextBox
        Me.tabsecundaria = New System.Windows.Forms.TabPage
        Me.chkControlPeriodico = New System.Windows.Forms.CheckBox
        Me.chkVisita = New System.Windows.Forms.CheckBox
        Me.TxtOtrosRelevamiento = New System.Windows.Forms.TextBox
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.txtOtrosInstalacion = New System.Windows.Forms.TextBox
        Me.chkInstalacion = New System.Windows.Forms.CheckBox
        Me.chkProvision = New System.Windows.Forms.CheckBox
        Me.gbTarjetas = New System.Windows.Forms.GroupBox
        Me.optTarjeta2 = New System.Windows.Forms.RadioButton
        Me.optTarjeta3 = New System.Windows.Forms.RadioButton
        Me.optTarjeta1 = New System.Windows.Forms.RadioButton
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.nudCantidadHidrantes = New System.Windows.Forms.NumericUpDown
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.nudCantidadMatafuegos = New System.Windows.Forms.NumericUpDown
        Me.chkOtros = New System.Windows.Forms.CheckBox
        Me.chkAcetato = New System.Windows.Forms.CheckBox
        Me.chkHalogenados = New System.Windows.Forms.CheckBox
        Me.chkAfff = New System.Windows.Forms.CheckBox
        Me.chkCo2 = New System.Windows.Forms.CheckBox
        Me.chkPq = New System.Windows.Forms.CheckBox
        Me.chkPq90 = New System.Windows.Forms.CheckBox
        Me.chkPq55 = New System.Windows.Forms.CheckBox
        Me.Label29 = New System.Windows.Forms.Label
        Me.TabSucursal = New System.Windows.Forms.TabPage
        Me.btnAgregarTodas = New System.Windows.Forms.Button
        Me.btnAgregarSucursal = New System.Windows.Forms.Button
        Me.dgvSucursales = New System.Windows.Forms.DataGridView
        Me.colCodSucursal = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colDireccion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colLocalidad = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TabDocElem = New System.Windows.Forms.TabPage
        Me.GroupBox10 = New System.Windows.Forms.GroupBox
        Me.nudUnificacion = New System.Windows.Forms.NumericUpDown
        Me.GroupBox9 = New System.Windows.Forms.GroupBox
        Me.cboModoFacturacion = New System.Windows.Forms.ComboBox
        Me.nudFrecuenciaFacturacion = New System.Windows.Forms.NumericUpDown
        Me.cboCondicionPago = New System.Windows.Forms.ComboBox
        Me.txtImporteMensual = New System.Windows.Forms.TextBox
        Me.txtImporteAnual = New System.Windows.Forms.TextBox
        Me.GroupBox8 = New System.Windows.Forms.GroupBox
        Me.chkZapatosSeguridad = New System.Windows.Forms.CheckBox
        Me.txtotrosElementos = New System.Windows.Forms.TextBox
        Me.chkProtectorAuditivo = New System.Windows.Forms.CheckBox
        Me.chkBarbijo = New System.Windows.Forms.CheckBox
        Me.chkCasco = New System.Windows.Forms.CheckBox
        Me.Label49 = New System.Windows.Forms.Label
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.txtOtrosDocumentos = New System.Windows.Forms.TextBox
        Me.chkSeguroVehiculo = New System.Windows.Forms.CheckBox
        Me.chkArt = New System.Windows.Forms.CheckBox
        Me.chkAutorizacionIngreso = New System.Windows.Forms.CheckBox
        Me.Label48 = New System.Windows.Forms.Label
        Me.txtId = New System.Windows.Forms.TextBox
        Me.txtCodigoCliente = New System.Windows.Forms.TextBox
        Me.cms = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuEditar = New System.Windows.Forms.ToolStripMenuItem
        Me.txtNombreCliente = New System.Windows.Forms.TextBox
        Me.btnNuevo = New System.Windows.Forms.Button
        Me.btnAutorizar = New System.Windows.Forms.Button
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer
        Me.dgvPrincipal = New System.Windows.Forms.DataGridView
        Me.DGVnro = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGVCliente = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnBuscar = New System.Windows.Forms.Button
        Me.btnRenovaciones = New System.Windows.Forms.Button
        Me.dgvRenovar = New System.Windows.Forms.DataGridView
        Me.colNro2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCliente2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colNombre2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colVto2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colModo2 = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.cboSucursal = New System.Windows.Forms.ComboBox
        Me.BtnImprimir = New System.Windows.Forms.Button
        Me.cboEstado = New System.Windows.Forms.ComboBox
        Me.btnRegistrar = New System.Windows.Forms.Button
        Me.chkRenovacion = New System.Windows.Forms.CheckBox
        Label5 = New System.Windows.Forms.Label
        EstadoContrato = New System.Windows.Forms.Label
        Label15 = New System.Windows.Forms.Label
        Label12 = New System.Windows.Forms.Label
        Label13 = New System.Windows.Forms.Label
        Label11 = New System.Windows.Forms.Label
        Label10 = New System.Windows.Forms.Label
        Label9 = New System.Windows.Forms.Label
        Label1 = New System.Windows.Forms.Label
        Label6 = New System.Windows.Forms.Label
        Label8 = New System.Windows.Forms.Label
        Label4 = New System.Windows.Forms.Label
        Label3 = New System.Windows.Forms.Label
        Label2 = New System.Windows.Forms.Label
        Label36 = New System.Windows.Forms.Label
        Label34 = New System.Windows.Forms.Label
        Label30 = New System.Windows.Forms.Label
        Label21 = New System.Windows.Forms.Label
        Label20 = New System.Windows.Forms.Label
        Label56 = New System.Windows.Forms.Label
        Label55 = New System.Windows.Forms.Label
        Label53 = New System.Windows.Forms.Label
        Label32 = New System.Windows.Forms.Label
        Label16 = New System.Windows.Forms.Label
        Label14 = New System.Windows.Forms.Label
        Me.tab.SuspendLayout()
        Me.TabGeneral.SuspendLayout()
        CType(Me.nudDuracion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.tabsecundaria.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.gbTarjetas.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.nudCantidadHidrantes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.nudCantidadMatafuegos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabSucursal.SuspendLayout()
        CType(Me.dgvSucursales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabDocElem.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        CType(Me.nudUnificacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox9.SuspendLayout()
        CType(Me.nudFrecuenciaFacturacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.cms.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.dgvPrincipal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvRenovar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label5
        '
        Label5.AutoSize = True
        Label5.Location = New System.Drawing.Point(35, 13)
        Label5.Name = "Label5"
        Label5.Size = New System.Drawing.Size(66, 13)
        Label5.TabIndex = 4
        Label5.Text = "Descripción:"
        '
        'EstadoContrato
        '
        EstadoContrato.AutoSize = True
        EstadoContrato.Location = New System.Drawing.Point(463, 6)
        EstadoContrato.Name = "EstadoContrato"
        EstadoContrato.Size = New System.Drawing.Size(40, 13)
        EstadoContrato.TabIndex = 2
        EstadoContrato.Text = "Estado"
        '
        'Label15
        '
        Label15.AutoSize = True
        Label15.Location = New System.Drawing.Point(339, 166)
        Label15.Name = "Label15"
        Label15.Size = New System.Drawing.Size(25, 13)
        Label15.TabIndex = 25
        Label15.Text = "OC:"
        '
        'Label12
        '
        Label12.AutoSize = True
        Label12.Location = New System.Drawing.Point(441, 128)
        Label12.Name = "Label12"
        Label12.Size = New System.Drawing.Size(29, 13)
        Label12.TabIndex = 22
        Label12.Text = "Mail:"
        '
        'Label13
        '
        Label13.AutoSize = True
        Label13.Location = New System.Drawing.Point(265, 128)
        Label13.Name = "Label13"
        Label13.Size = New System.Drawing.Size(52, 13)
        Label13.TabIndex = 20
        Label13.Text = "Telefono:"
        '
        'Label11
        '
        Label11.AutoSize = True
        Label11.Location = New System.Drawing.Point(441, 101)
        Label11.Name = "Label11"
        Label11.Size = New System.Drawing.Size(29, 13)
        Label11.TabIndex = 16
        Label11.Text = "Mail:"
        '
        'Label10
        '
        Label10.AutoSize = True
        Label10.Location = New System.Drawing.Point(265, 101)
        Label10.Name = "Label10"
        Label10.Size = New System.Drawing.Size(52, 13)
        Label10.TabIndex = 14
        Label10.Text = "Telefono:"
        '
        'Label9
        '
        Label9.AutoSize = True
        Label9.Location = New System.Drawing.Point(17, 61)
        Label9.Name = "Label9"
        Label9.Size = New System.Drawing.Size(56, 13)
        Label9.TabIndex = 6
        Label9.Text = "Vendedor:"
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(441, 66)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(92, 13)
        Label1.TabIndex = 10
        Label1.Text = "Duración (meses):"
        '
        'Label6
        '
        Label6.AutoSize = True
        Label6.Location = New System.Drawing.Point(441, 40)
        Label6.Name = "Label6"
        Label6.Size = New System.Drawing.Size(86, 13)
        Label6.TabIndex = 8
        Label6.Text = "Inicio del Abono:"
        '
        'Label8
        '
        Label8.AutoSize = True
        Label8.Location = New System.Drawing.Point(17, 124)
        Label8.Name = "Label8"
        Label8.Size = New System.Drawing.Size(102, 13)
        Label8.TabIndex = 18
        Label8.Text = "Contacto Operativo:"
        '
        'Label4
        '
        Label4.AutoSize = True
        Label4.Location = New System.Drawing.Point(17, 97)
        Label4.Name = "Label4"
        Label4.Size = New System.Drawing.Size(102, 13)
        Label4.TabIndex = 12
        Label4.Text = "Contacto Comercial:"
        '
        'Label3
        '
        Label3.AutoSize = True
        Label3.Location = New System.Drawing.Point(121, 32)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(42, 13)
        Label3.TabIndex = 1
        Label3.Text = "Cliente:"
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Location = New System.Drawing.Point(178, 6)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(81, 13)
        Label2.TabIndex = 0
        Label2.Text = "Abono Numero:"
        '
        'Label36
        '
        Label36.AutoSize = True
        Label36.Location = New System.Drawing.Point(6, 38)
        Label36.Name = "Label36"
        Label36.Size = New System.Drawing.Size(117, 13)
        Label36.TabIndex = 73
        Label36.Text = "Soporte y Chapa Baliza"
        '
        'Label34
        '
        Label34.AutoSize = True
        Label34.Location = New System.Drawing.Point(8, 76)
        Label34.Name = "Label34"
        Label34.Size = New System.Drawing.Size(32, 13)
        Label34.TabIndex = 79
        Label34.Text = "Otros"
        '
        'Label30
        '
        Label30.AutoSize = True
        Label30.Location = New System.Drawing.Point(23, 31)
        Label30.Name = "Label30"
        Label30.Size = New System.Drawing.Size(113, 13)
        Label30.TabIndex = 77
        Label30.Text = "Cantidad de hidrantes:"
        '
        'Label21
        '
        Label21.AutoSize = True
        Label21.Location = New System.Drawing.Point(6, 134)
        Label21.Name = "Label21"
        Label21.Size = New System.Drawing.Size(170, 13)
        Label21.TabIndex = 20
        Label21.Text = "Frecuencia de facturación (meses)"
        '
        'Label20
        '
        Label20.AutoSize = True
        Label20.Location = New System.Drawing.Point(9, 25)
        Label20.Name = "Label20"
        Label20.Size = New System.Drawing.Size(106, 13)
        Label20.TabIndex = 20
        Label20.Text = "Cant. Visitas Anuales"
        '
        'Label56
        '
        Label56.AutoSize = True
        Label56.Location = New System.Drawing.Point(6, 101)
        Label56.Name = "Label56"
        Label56.Size = New System.Drawing.Size(97, 13)
        Label56.TabIndex = 5
        Label56.Text = "Condición de Pago"
        '
        'Label55
        '
        Label55.AutoSize = True
        Label55.Location = New System.Drawing.Point(6, 59)
        Label55.Name = "Label55"
        Label55.Size = New System.Drawing.Size(85, 13)
        Label55.TabIndex = 3
        Label55.Text = "Importe Mensual"
        '
        'Label53
        '
        Label53.AutoSize = True
        Label53.Location = New System.Drawing.Point(6, 28)
        Label53.Name = "Label53"
        Label53.Size = New System.Drawing.Size(72, 13)
        Label53.TabIndex = 1
        Label53.Text = "Importe Anual"
        '
        'Label32
        '
        Label32.AutoSize = True
        Label32.Location = New System.Drawing.Point(301, 166)
        Label32.Name = "Label32"
        Label32.Size = New System.Drawing.Size(32, 13)
        Label32.TabIndex = 100
        Label32.Text = "Otros"
        '
        'Label16
        '
        Label16.AutoSize = True
        Label16.Location = New System.Drawing.Point(6, 170)
        Label16.Name = "Label16"
        Label16.Size = New System.Drawing.Size(93, 13)
        Label16.TabIndex = 86
        Label16.Text = "Modo Facturación"
        '
        'Label14
        '
        Label14.AutoSize = True
        Label14.Location = New System.Drawing.Point(35, 314)
        Label14.Name = "Label14"
        Label14.Size = New System.Drawing.Size(78, 13)
        Label14.TabIndex = 30
        Label14.Text = "Observaciones"
        '
        'tab
        '
        Me.tab.Controls.Add(Me.TabGeneral)
        Me.tab.Controls.Add(Me.tabsecundaria)
        Me.tab.Controls.Add(Me.TabSucursal)
        Me.tab.Controls.Add(Me.TabDocElem)
        Me.tab.Location = New System.Drawing.Point(5, 65)
        Me.tab.Name = "tab"
        Me.tab.SelectedIndex = 0
        Me.tab.Size = New System.Drawing.Size(663, 409)
        Me.tab.TabIndex = 4
        '
        'TabGeneral
        '
        Me.TabGeneral.Controls.Add(Me.chkRenovacion)
        Me.TabGeneral.Controls.Add(Me.nudDuracion)
        Me.TabGeneral.Controls.Add(Label14)
        Me.TabGeneral.Controls.Add(Me.txtObs)
        Me.TabGeneral.Controls.Add(Me.cboVendedor)
        Me.TabGeneral.Controls.Add(Label5)
        Me.TabGeneral.Controls.Add(Me.txtDescripcion)
        Me.TabGeneral.Controls.Add(Me.GroupBox2)
        Me.TabGeneral.Controls.Add(Label15)
        Me.TabGeneral.Controls.Add(Me.txtOc)
        Me.TabGeneral.Controls.Add(Label12)
        Me.TabGeneral.Controls.Add(Label13)
        Me.TabGeneral.Controls.Add(Me.txtMailOperativo)
        Me.TabGeneral.Controls.Add(Me.txtTelefonoOperativo)
        Me.TabGeneral.Controls.Add(Label11)
        Me.TabGeneral.Controls.Add(Label10)
        Me.TabGeneral.Controls.Add(Label9)
        Me.TabGeneral.Controls.Add(Me.dtpInicio)
        Me.TabGeneral.Controls.Add(Label1)
        Me.TabGeneral.Controls.Add(Label6)
        Me.TabGeneral.Controls.Add(Label8)
        Me.TabGeneral.Controls.Add(Label4)
        Me.TabGeneral.Controls.Add(Me.txtMailComercial)
        Me.TabGeneral.Controls.Add(Me.txtTelefonoComercial)
        Me.TabGeneral.Controls.Add(Me.txtContactoOperativo)
        Me.TabGeneral.Controls.Add(Me.txtConcactoComercial)
        Me.TabGeneral.Location = New System.Drawing.Point(4, 22)
        Me.TabGeneral.Name = "TabGeneral"
        Me.TabGeneral.Padding = New System.Windows.Forms.Padding(3)
        Me.TabGeneral.Size = New System.Drawing.Size(655, 383)
        Me.TabGeneral.TabIndex = 0
        Me.TabGeneral.Text = "General"
        Me.TabGeneral.UseVisualStyleBackColor = True
        '
        'nudDuracion
        '
        Me.nudDuracion.Location = New System.Drawing.Point(568, 66)
        Me.nudDuracion.Maximum = New Decimal(New Integer() {12, 0, 0, 0})
        Me.nudDuracion.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudDuracion.Name = "nudDuracion"
        Me.nudDuracion.Size = New System.Drawing.Size(62, 20)
        Me.nudDuracion.TabIndex = 82
        Me.nudDuracion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nudDuracion.Value = New Decimal(New Integer() {12, 0, 0, 0})
        '
        'txtObs
        '
        Me.txtObs.Location = New System.Drawing.Point(33, 330)
        Me.txtObs.MaxLength = 200
        Me.txtObs.Multiline = True
        Me.txtObs.Name = "txtObs"
        Me.txtObs.Size = New System.Drawing.Size(592, 47)
        Me.txtObs.TabIndex = 29
        '
        'cboVendedor
        '
        Me.cboVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVendedor.Enabled = False
        Me.cboVendedor.FormattingEnabled = True
        Me.cboVendedor.Location = New System.Drawing.Point(125, 58)
        Me.cboVendedor.Name = "cboVendedor"
        Me.cboVendedor.Size = New System.Drawing.Size(214, 21)
        Me.cboVendedor.TabIndex = 28
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(144, 10)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(478, 20)
        Me.txtDescripcion.TabIndex = 5
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chk639)
        Me.GroupBox2.Controls.Add(Me.chkMantenimientoRed)
        Me.GroupBox2.Controls.Add(Me.chkMantenimientoBocas)
        Me.GroupBox2.Controls.Add(Me.chkPhMangueras)
        Me.GroupBox2.Controls.Add(Me.txtDetalle639)
        Me.GroupBox2.Controls.Add(Me.txtMantIntRedHdri)
        Me.GroupBox2.Controls.Add(Me.txtMantBocasHidr)
        Me.GroupBox2.Controls.Add(Me.txtPhMangueras)
        Me.GroupBox2.Location = New System.Drawing.Point(20, 189)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(619, 122)
        Me.GroupBox2.TabIndex = 27
        Me.GroupBox2.TabStop = False
        '
        'chk639
        '
        Me.chk639.AutoSize = True
        Me.chk639.Location = New System.Drawing.Point(343, 65)
        Me.chk639.Name = "chk639"
        Me.chk639.Size = New System.Drawing.Size(44, 17)
        Me.chk639.TabIndex = 6
        Me.chk639.Text = "639"
        Me.chk639.UseVisualStyleBackColor = True
        '
        'chkMantenimientoRed
        '
        Me.chkMantenimientoRed.AutoSize = True
        Me.chkMantenimientoRed.Location = New System.Drawing.Point(342, 16)
        Me.chkMantenimientoRed.Name = "chkMantenimientoRed"
        Me.chkMantenimientoRed.Size = New System.Drawing.Size(218, 17)
        Me.chkMantenimientoRed.TabIndex = 4
        Me.chkMantenimientoRed.Text = "Mantenimiento integral Red de Hidrantes"
        Me.chkMantenimientoRed.UseVisualStyleBackColor = True
        '
        'chkMantenimientoBocas
        '
        Me.chkMantenimientoBocas.AutoSize = True
        Me.chkMantenimientoBocas.Location = New System.Drawing.Point(13, 65)
        Me.chkMantenimientoBocas.Name = "chkMantenimientoBocas"
        Me.chkMantenimientoBocas.Size = New System.Drawing.Size(206, 17)
        Me.chkMantenimientoBocas.TabIndex = 2
        Me.chkMantenimientoBocas.Text = "Mantenimiento de Bocas de Hidrantes"
        Me.chkMantenimientoBocas.UseVisualStyleBackColor = True
        '
        'chkPhMangueras
        '
        Me.chkPhMangueras.AutoSize = True
        Me.chkPhMangueras.Location = New System.Drawing.Point(13, 19)
        Me.chkPhMangueras.Name = "chkPhMangueras"
        Me.chkPhMangueras.Size = New System.Drawing.Size(92, 17)
        Me.chkPhMangueras.TabIndex = 0
        Me.chkPhMangueras.Text = "PH Manguera"
        Me.chkPhMangueras.UseVisualStyleBackColor = True
        '
        'txtDetalle639
        '
        Me.txtDetalle639.Location = New System.Drawing.Point(342, 88)
        Me.txtDetalle639.Name = "txtDetalle639"
        Me.txtDetalle639.Size = New System.Drawing.Size(263, 20)
        Me.txtDetalle639.TabIndex = 7
        '
        'txtMantIntRedHdri
        '
        Me.txtMantIntRedHdri.Location = New System.Drawing.Point(342, 39)
        Me.txtMantIntRedHdri.Name = "txtMantIntRedHdri"
        Me.txtMantIntRedHdri.Size = New System.Drawing.Size(263, 20)
        Me.txtMantIntRedHdri.TabIndex = 5
        '
        'txtMantBocasHidr
        '
        Me.txtMantBocasHidr.Location = New System.Drawing.Point(13, 88)
        Me.txtMantBocasHidr.Name = "txtMantBocasHidr"
        Me.txtMantBocasHidr.Size = New System.Drawing.Size(295, 20)
        Me.txtMantBocasHidr.TabIndex = 3
        '
        'txtPhMangueras
        '
        Me.txtPhMangueras.Location = New System.Drawing.Point(13, 39)
        Me.txtPhMangueras.Name = "txtPhMangueras"
        Me.txtPhMangueras.Size = New System.Drawing.Size(295, 20)
        Me.txtPhMangueras.TabIndex = 1
        '
        'txtOc
        '
        Me.txtOc.Location = New System.Drawing.Point(401, 163)
        Me.txtOc.Name = "txtOc"
        Me.txtOc.Size = New System.Drawing.Size(228, 20)
        Me.txtOc.TabIndex = 26
        '
        'txtMailOperativo
        '
        Me.txtMailOperativo.Location = New System.Drawing.Point(476, 121)
        Me.txtMailOperativo.Name = "txtMailOperativo"
        Me.txtMailOperativo.Size = New System.Drawing.Size(146, 20)
        Me.txtMailOperativo.TabIndex = 23
        '
        'txtTelefonoOperativo
        '
        Me.txtTelefonoOperativo.Location = New System.Drawing.Point(335, 121)
        Me.txtTelefonoOperativo.Name = "txtTelefonoOperativo"
        Me.txtTelefonoOperativo.Size = New System.Drawing.Size(100, 20)
        Me.txtTelefonoOperativo.TabIndex = 21
        '
        'dtpInicio
        '
        Me.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpInicio.Location = New System.Drawing.Point(533, 37)
        Me.dtpInicio.Name = "dtpInicio"
        Me.dtpInicio.Size = New System.Drawing.Size(97, 20)
        Me.dtpInicio.TabIndex = 9
        '
        'txtMailComercial
        '
        Me.txtMailComercial.Location = New System.Drawing.Point(476, 94)
        Me.txtMailComercial.Name = "txtMailComercial"
        Me.txtMailComercial.Size = New System.Drawing.Size(146, 20)
        Me.txtMailComercial.TabIndex = 17
        '
        'txtTelefonoComercial
        '
        Me.txtTelefonoComercial.Location = New System.Drawing.Point(335, 94)
        Me.txtTelefonoComercial.Name = "txtTelefonoComercial"
        Me.txtTelefonoComercial.Size = New System.Drawing.Size(100, 20)
        Me.txtTelefonoComercial.TabIndex = 15
        '
        'txtContactoOperativo
        '
        Me.txtContactoOperativo.Location = New System.Drawing.Point(125, 121)
        Me.txtContactoOperativo.Name = "txtContactoOperativo"
        Me.txtContactoOperativo.Size = New System.Drawing.Size(134, 20)
        Me.txtContactoOperativo.TabIndex = 19
        '
        'txtConcactoComercial
        '
        Me.txtConcactoComercial.Location = New System.Drawing.Point(125, 94)
        Me.txtConcactoComercial.Name = "txtConcactoComercial"
        Me.txtConcactoComercial.Size = New System.Drawing.Size(134, 20)
        Me.txtConcactoComercial.TabIndex = 13
        '
        'tabsecundaria
        '
        Me.tabsecundaria.Controls.Add(Me.chkControlPeriodico)
        Me.tabsecundaria.Controls.Add(Me.chkVisita)
        Me.tabsecundaria.Controls.Add(Me.TxtOtrosRelevamiento)
        Me.tabsecundaria.Controls.Add(Label32)
        Me.tabsecundaria.Controls.Add(Me.GroupBox6)
        Me.tabsecundaria.Controls.Add(Me.gbTarjetas)
        Me.tabsecundaria.Controls.Add(Me.GroupBox4)
        Me.tabsecundaria.Controls.Add(Me.GroupBox3)
        Me.tabsecundaria.Location = New System.Drawing.Point(4, 22)
        Me.tabsecundaria.Name = "tabsecundaria"
        Me.tabsecundaria.Padding = New System.Windows.Forms.Padding(3)
        Me.tabsecundaria.Size = New System.Drawing.Size(655, 383)
        Me.tabsecundaria.TabIndex = 1
        Me.tabsecundaria.Text = "Varios"
        Me.tabsecundaria.UseVisualStyleBackColor = True
        '
        'chkControlPeriodico
        '
        Me.chkControlPeriodico.AutoSize = True
        Me.chkControlPeriodico.Location = New System.Drawing.Point(339, 143)
        Me.chkControlPeriodico.Name = "chkControlPeriodico"
        Me.chkControlPeriodico.Size = New System.Drawing.Size(106, 17)
        Me.chkControlPeriodico.TabIndex = 102
        Me.chkControlPeriodico.Text = "Control Periódico"
        Me.chkControlPeriodico.UseVisualStyleBackColor = True
        '
        'chkVisita
        '
        Me.chkVisita.AutoSize = True
        Me.chkVisita.Location = New System.Drawing.Point(339, 117)
        Me.chkVisita.Name = "chkVisita"
        Me.chkVisita.Size = New System.Drawing.Size(127, 17)
        Me.chkVisita.TabIndex = 101
        Me.chkVisita.Text = "Visita / Relevamiento"
        Me.chkVisita.UseVisualStyleBackColor = True
        '
        'TxtOtrosRelevamiento
        '
        Me.TxtOtrosRelevamiento.Location = New System.Drawing.Point(339, 166)
        Me.TxtOtrosRelevamiento.Name = "TxtOtrosRelevamiento"
        Me.TxtOtrosRelevamiento.Size = New System.Drawing.Size(238, 20)
        Me.TxtOtrosRelevamiento.TabIndex = 99
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.txtOtrosInstalacion)
        Me.GroupBox6.Controls.Add(Me.chkInstalacion)
        Me.GroupBox6.Controls.Add(Me.chkProvision)
        Me.GroupBox6.Controls.Add(Label36)
        Me.GroupBox6.Controls.Add(Label34)
        Me.GroupBox6.Location = New System.Drawing.Point(291, 216)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(357, 150)
        Me.GroupBox6.TabIndex = 75
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "INTALACIONES /PROVISIONES"
        '
        'txtOtrosInstalacion
        '
        Me.txtOtrosInstalacion.Location = New System.Drawing.Point(46, 74)
        Me.txtOtrosInstalacion.Name = "txtOtrosInstalacion"
        Me.txtOtrosInstalacion.Size = New System.Drawing.Size(238, 20)
        Me.txtOtrosInstalacion.TabIndex = 98
        '
        'chkInstalacion
        '
        Me.chkInstalacion.AutoSize = True
        Me.chkInstalacion.Location = New System.Drawing.Point(238, 37)
        Me.chkInstalacion.Name = "chkInstalacion"
        Me.chkInstalacion.Size = New System.Drawing.Size(77, 17)
        Me.chkInstalacion.TabIndex = 93
        Me.chkInstalacion.Text = "Instalacion"
        Me.chkInstalacion.UseVisualStyleBackColor = True
        '
        'chkProvision
        '
        Me.chkProvision.AutoSize = True
        Me.chkProvision.Location = New System.Drawing.Point(135, 37)
        Me.chkProvision.Name = "chkProvision"
        Me.chkProvision.Size = New System.Drawing.Size(69, 17)
        Me.chkProvision.TabIndex = 90
        Me.chkProvision.Text = "Provision"
        Me.chkProvision.UseVisualStyleBackColor = True
        '
        'gbTarjetas
        '
        Me.gbTarjetas.Controls.Add(Me.optTarjeta2)
        Me.gbTarjetas.Controls.Add(Me.optTarjeta3)
        Me.gbTarjetas.Controls.Add(Me.optTarjeta1)
        Me.gbTarjetas.Location = New System.Drawing.Point(291, 9)
        Me.gbTarjetas.Name = "gbTarjetas"
        Me.gbTarjetas.Size = New System.Drawing.Size(360, 102)
        Me.gbTarjetas.TabIndex = 74
        Me.gbTarjetas.TabStop = False
        Me.gbTarjetas.Text = "Tarjetas"
        '
        'optTarjeta2
        '
        Me.optTarjeta2.AutoSize = True
        Me.optTarjeta2.Location = New System.Drawing.Point(48, 41)
        Me.optTarjeta2.Name = "optTarjeta2"
        Me.optTarjeta2.Size = New System.Drawing.Size(182, 17)
        Me.optTarjeta2.TabIndex = 77
        Me.optTarjeta2.TabStop = True
        Me.optTarjeta2.Text = "Fotocopia Pegada En Matafuego"
        Me.optTarjeta2.UseVisualStyleBackColor = True
        '
        'optTarjeta3
        '
        Me.optTarjeta3.AutoSize = True
        Me.optTarjeta3.Location = New System.Drawing.Point(48, 67)
        Me.optTarjeta3.Name = "optTarjeta3"
        Me.optTarjeta3.Size = New System.Drawing.Size(106, 17)
        Me.optTarjeta3.TabIndex = 76
        Me.optTarjeta3.TabStop = True
        Me.optTarjeta3.Text = "Original En Mano"
        Me.optTarjeta3.UseVisualStyleBackColor = True
        '
        'optTarjeta1
        '
        Me.optTarjeta1.AutoSize = True
        Me.optTarjeta1.Location = New System.Drawing.Point(48, 19)
        Me.optTarjeta1.Name = "optTarjeta1"
        Me.optTarjeta1.Size = New System.Drawing.Size(170, 17)
        Me.optTarjeta1.TabIndex = 75
        Me.optTarjeta1.TabStop = True
        Me.optTarjeta1.Text = "Original Pegada En Matafuego"
        Me.optTarjeta1.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.nudCantidadHidrantes)
        Me.GroupBox4.Controls.Add(Label30)
        Me.GroupBox4.Location = New System.Drawing.Point(20, 285)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(257, 81)
        Me.GroupBox4.TabIndex = 73
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "HIDRANTES"
        '
        'nudCantidadHidrantes
        '
        Me.nudCantidadHidrantes.Location = New System.Drawing.Point(195, 29)
        Me.nudCantidadHidrantes.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.nudCantidadHidrantes.Name = "nudCantidadHidrantes"
        Me.nudCantidadHidrantes.Size = New System.Drawing.Size(56, 20)
        Me.nudCantidadHidrantes.TabIndex = 82
        Me.nudCantidadHidrantes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.nudCantidadMatafuegos)
        Me.GroupBox3.Controls.Add(Me.chkOtros)
        Me.GroupBox3.Controls.Add(Me.chkAcetato)
        Me.GroupBox3.Controls.Add(Me.chkHalogenados)
        Me.GroupBox3.Controls.Add(Me.chkAfff)
        Me.GroupBox3.Controls.Add(Me.chkCo2)
        Me.GroupBox3.Controls.Add(Me.chkPq)
        Me.GroupBox3.Controls.Add(Me.chkPq90)
        Me.GroupBox3.Controls.Add(Me.chkPq55)
        Me.GroupBox3.Controls.Add(Me.Label29)
        Me.GroupBox3.Location = New System.Drawing.Point(19, 9)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(258, 270)
        Me.GroupBox3.TabIndex = 72
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "MATAFUEGOS"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(17, 54)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(172, 16)
        Me.Label7.TabIndex = 82
        Me.Label7.Text = "Tildar los agentes incluidos"
        '
        'nudCantidadMatafuegos
        '
        Me.nudCantidadMatafuegos.Location = New System.Drawing.Point(196, 20)
        Me.nudCantidadMatafuegos.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.nudCantidadMatafuegos.Name = "nudCantidadMatafuegos"
        Me.nudCantidadMatafuegos.Size = New System.Drawing.Size(56, 20)
        Me.nudCantidadMatafuegos.TabIndex = 81
        Me.nudCantidadMatafuegos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chkOtros
        '
        Me.chkOtros.AutoSize = True
        Me.chkOtros.Location = New System.Drawing.Point(27, 240)
        Me.chkOtros.Name = "chkOtros"
        Me.chkOtros.Size = New System.Drawing.Size(51, 17)
        Me.chkOtros.TabIndex = 80
        Me.chkOtros.Text = "Otros"
        Me.chkOtros.UseVisualStyleBackColor = True
        '
        'chkAcetato
        '
        Me.chkAcetato.AutoSize = True
        Me.chkAcetato.Location = New System.Drawing.Point(27, 217)
        Me.chkAcetato.Name = "chkAcetato"
        Me.chkAcetato.Size = New System.Drawing.Size(63, 17)
        Me.chkAcetato.TabIndex = 79
        Me.chkAcetato.Text = "Acetato"
        Me.chkAcetato.UseVisualStyleBackColor = True
        '
        'chkHalogenados
        '
        Me.chkHalogenados.AutoSize = True
        Me.chkHalogenados.Location = New System.Drawing.Point(27, 194)
        Me.chkHalogenados.Name = "chkHalogenados"
        Me.chkHalogenados.Size = New System.Drawing.Size(89, 17)
        Me.chkHalogenados.TabIndex = 78
        Me.chkHalogenados.Text = "Halogenados"
        Me.chkHalogenados.UseVisualStyleBackColor = True
        '
        'chkAfff
        '
        Me.chkAfff.AutoSize = True
        Me.chkAfff.Location = New System.Drawing.Point(27, 171)
        Me.chkAfff.Name = "chkAfff"
        Me.chkAfff.Size = New System.Drawing.Size(92, 17)
        Me.chkAfff.TabIndex = 77
        Me.chkAfff.Text = "Espuma AFFF"
        Me.chkAfff.UseVisualStyleBackColor = True
        '
        'chkCo2
        '
        Me.chkCo2.AutoSize = True
        Me.chkCo2.Location = New System.Drawing.Point(28, 148)
        Me.chkCo2.Name = "chkCo2"
        Me.chkCo2.Size = New System.Drawing.Size(47, 17)
        Me.chkCo2.TabIndex = 76
        Me.chkCo2.Text = "CO2"
        Me.chkCo2.UseVisualStyleBackColor = True
        '
        'chkPq
        '
        Me.chkPq.AutoSize = True
        Me.chkPq.Location = New System.Drawing.Point(28, 125)
        Me.chkPq.Name = "chkPq"
        Me.chkPq.Size = New System.Drawing.Size(111, 17)
        Me.chkPq.TabIndex = 75
        Me.chkPq.Text = "Polvo Quimico BC"
        Me.chkPq.UseVisualStyleBackColor = True
        '
        'chkPq90
        '
        Me.chkPq90.AutoSize = True
        Me.chkPq90.Location = New System.Drawing.Point(28, 102)
        Me.chkPq90.Name = "chkPq90"
        Me.chkPq90.Size = New System.Drawing.Size(139, 17)
        Me.chkPq90.TabIndex = 74
        Me.chkPq90.Text = "Polvo Quimico (ABC) 90"
        Me.chkPq90.UseVisualStyleBackColor = True
        '
        'chkPq55
        '
        Me.chkPq55.AutoSize = True
        Me.chkPq55.Location = New System.Drawing.Point(28, 79)
        Me.chkPq55.Name = "chkPq55"
        Me.chkPq55.Size = New System.Drawing.Size(139, 17)
        Me.chkPq55.TabIndex = 73
        Me.chkPq55.Text = "Polvo Quimico (ABC) 55"
        Me.chkPq55.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.chkPq55.UseVisualStyleBackColor = True
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(26, 22)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(125, 13)
        Me.Label29.TabIndex = 72
        Me.Label29.Text = "Cantidad de matafuegos:"
        '
        'TabSucursal
        '
        Me.TabSucursal.Controls.Add(Me.btnAgregarTodas)
        Me.TabSucursal.Controls.Add(Me.btnAgregarSucursal)
        Me.TabSucursal.Controls.Add(Me.dgvSucursales)
        Me.TabSucursal.Location = New System.Drawing.Point(4, 22)
        Me.TabSucursal.Name = "TabSucursal"
        Me.TabSucursal.Padding = New System.Windows.Forms.Padding(3)
        Me.TabSucursal.Size = New System.Drawing.Size(655, 383)
        Me.TabSucursal.TabIndex = 2
        Me.TabSucursal.Text = "Sucursales"
        Me.TabSucursal.UseVisualStyleBackColor = True
        '
        'btnAgregarTodas
        '
        Me.btnAgregarTodas.Location = New System.Drawing.Point(135, 340)
        Me.btnAgregarTodas.Name = "btnAgregarTodas"
        Me.btnAgregarTodas.Size = New System.Drawing.Size(123, 23)
        Me.btnAgregarTodas.TabIndex = 6
        Me.btnAgregarTodas.Text = "Agregar todas"
        Me.btnAgregarTodas.UseVisualStyleBackColor = True
        '
        'btnAgregarSucursal
        '
        Me.btnAgregarSucursal.Location = New System.Drawing.Point(6, 340)
        Me.btnAgregarSucursal.Name = "btnAgregarSucursal"
        Me.btnAgregarSucursal.Size = New System.Drawing.Size(123, 23)
        Me.btnAgregarSucursal.TabIndex = 5
        Me.btnAgregarSucursal.Text = "Agregar Sucursal..."
        Me.btnAgregarSucursal.UseVisualStyleBackColor = True
        '
        'dgvSucursales
        '
        Me.dgvSucursales.AllowUserToAddRows = False
        Me.dgvSucursales.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvSucursales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSucursales.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colCodSucursal, Me.colDireccion, Me.colLocalidad})
        Me.dgvSucursales.Location = New System.Drawing.Point(6, 6)
        Me.dgvSucursales.Name = "dgvSucursales"
        Me.dgvSucursales.ReadOnly = True
        Me.dgvSucursales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSucursales.Size = New System.Drawing.Size(646, 328)
        Me.dgvSucursales.TabIndex = 0
        '
        'colCodSucursal
        '
        Me.colCodSucursal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colCodSucursal.HeaderText = "Sucursal"
        Me.colCodSucursal.Name = "colCodSucursal"
        Me.colCodSucursal.ReadOnly = True
        Me.colCodSucursal.Width = 73
        '
        'colDireccion
        '
        Me.colDireccion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colDireccion.HeaderText = "Direccion"
        Me.colDireccion.Name = "colDireccion"
        Me.colDireccion.ReadOnly = True
        Me.colDireccion.Width = 77
        '
        'colLocalidad
        '
        Me.colLocalidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colLocalidad.HeaderText = "Localidad"
        Me.colLocalidad.Name = "colLocalidad"
        Me.colLocalidad.ReadOnly = True
        Me.colLocalidad.Width = 78
        '
        'TabDocElem
        '
        Me.TabDocElem.Controls.Add(Me.GroupBox10)
        Me.TabDocElem.Controls.Add(Me.GroupBox9)
        Me.TabDocElem.Controls.Add(Me.GroupBox8)
        Me.TabDocElem.Controls.Add(Me.GroupBox7)
        Me.TabDocElem.Location = New System.Drawing.Point(4, 22)
        Me.TabDocElem.Name = "TabDocElem"
        Me.TabDocElem.Padding = New System.Windows.Forms.Padding(3)
        Me.TabDocElem.Size = New System.Drawing.Size(655, 383)
        Me.TabDocElem.TabIndex = 3
        Me.TabDocElem.Text = "Documentacion y Elementos"
        Me.TabDocElem.UseVisualStyleBackColor = True
        '
        'GroupBox10
        '
        Me.GroupBox10.Controls.Add(Me.nudUnificacion)
        Me.GroupBox10.Controls.Add(Label20)
        Me.GroupBox10.Location = New System.Drawing.Point(377, 305)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(267, 57)
        Me.GroupBox10.TabIndex = 3
        Me.GroupBox10.TabStop = False
        Me.GroupBox10.Text = "Unificacion de Vencimientos"
        '
        'nudUnificacion
        '
        Me.nudUnificacion.Location = New System.Drawing.Point(191, 23)
        Me.nudUnificacion.Maximum = New Decimal(New Integer() {12, 0, 0, 0})
        Me.nudUnificacion.Name = "nudUnificacion"
        Me.nudUnificacion.Size = New System.Drawing.Size(56, 20)
        Me.nudUnificacion.TabIndex = 83
        Me.nudUnificacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Label16)
        Me.GroupBox9.Controls.Add(Me.cboModoFacturacion)
        Me.GroupBox9.Controls.Add(Me.nudFrecuenciaFacturacion)
        Me.GroupBox9.Controls.Add(Label21)
        Me.GroupBox9.Controls.Add(Me.cboCondicionPago)
        Me.GroupBox9.Controls.Add(Label56)
        Me.GroupBox9.Controls.Add(Label55)
        Me.GroupBox9.Controls.Add(Me.txtImporteMensual)
        Me.GroupBox9.Controls.Add(Label53)
        Me.GroupBox9.Controls.Add(Me.txtImporteAnual)
        Me.GroupBox9.Location = New System.Drawing.Point(385, 33)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(259, 266)
        Me.GroupBox9.TabIndex = 2
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "Valores Comerciales (sin IVA)"
        '
        'cboModoFacturacion
        '
        Me.cboModoFacturacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboModoFacturacion.FormattingEnabled = True
        Me.cboModoFacturacion.Location = New System.Drawing.Point(107, 167)
        Me.cboModoFacturacion.Name = "cboModoFacturacion"
        Me.cboModoFacturacion.Size = New System.Drawing.Size(146, 21)
        Me.cboModoFacturacion.TabIndex = 85
        '
        'nudFrecuenciaFacturacion
        '
        Me.nudFrecuenciaFacturacion.Location = New System.Drawing.Point(197, 132)
        Me.nudFrecuenciaFacturacion.Maximum = New Decimal(New Integer() {12, 0, 0, 0})
        Me.nudFrecuenciaFacturacion.Name = "nudFrecuenciaFacturacion"
        Me.nudFrecuenciaFacturacion.Size = New System.Drawing.Size(56, 20)
        Me.nudFrecuenciaFacturacion.TabIndex = 84
        Me.nudFrecuenciaFacturacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboCondicionPago
        '
        Me.cboCondicionPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCondicionPago.FormattingEnabled = True
        Me.cboCondicionPago.Location = New System.Drawing.Point(131, 96)
        Me.cboCondicionPago.Name = "cboCondicionPago"
        Me.cboCondicionPago.Size = New System.Drawing.Size(122, 21)
        Me.cboCondicionPago.TabIndex = 6
        '
        'txtImporteMensual
        '
        Me.txtImporteMensual.Enabled = False
        Me.txtImporteMensual.Location = New System.Drawing.Point(162, 56)
        Me.txtImporteMensual.Name = "txtImporteMensual"
        Me.txtImporteMensual.Size = New System.Drawing.Size(91, 20)
        Me.txtImporteMensual.TabIndex = 2
        Me.txtImporteMensual.Text = "0.00"
        Me.txtImporteMensual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtImporteAnual
        '
        Me.txtImporteAnual.Location = New System.Drawing.Point(162, 25)
        Me.txtImporteAnual.Name = "txtImporteAnual"
        Me.txtImporteAnual.Size = New System.Drawing.Size(91, 20)
        Me.txtImporteAnual.TabIndex = 0
        Me.txtImporteAnual.Text = "0.00"
        Me.txtImporteAnual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.chkZapatosSeguridad)
        Me.GroupBox8.Controls.Add(Me.txtotrosElementos)
        Me.GroupBox8.Controls.Add(Me.chkProtectorAuditivo)
        Me.GroupBox8.Controls.Add(Me.chkBarbijo)
        Me.GroupBox8.Controls.Add(Me.chkCasco)
        Me.GroupBox8.Controls.Add(Me.Label49)
        Me.GroupBox8.Location = New System.Drawing.Point(9, 183)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(360, 179)
        Me.GroupBox8.TabIndex = 1
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Elementos"
        '
        'chkZapatosSeguridad
        '
        Me.chkZapatosSeguridad.AutoSize = True
        Me.chkZapatosSeguridad.Location = New System.Drawing.Point(44, 101)
        Me.chkZapatosSeguridad.Name = "chkZapatosSeguridad"
        Me.chkZapatosSeguridad.Size = New System.Drawing.Size(129, 17)
        Me.chkZapatosSeguridad.TabIndex = 19
        Me.chkZapatosSeguridad.Text = "Zapatos de seguridad"
        Me.chkZapatosSeguridad.UseVisualStyleBackColor = True
        '
        'txtotrosElementos
        '
        Me.txtotrosElementos.Location = New System.Drawing.Point(44, 129)
        Me.txtotrosElementos.Name = "txtotrosElementos"
        Me.txtotrosElementos.Size = New System.Drawing.Size(272, 20)
        Me.txtotrosElementos.TabIndex = 15
        '
        'chkProtectorAuditivo
        '
        Me.chkProtectorAuditivo.AutoSize = True
        Me.chkProtectorAuditivo.Location = New System.Drawing.Point(44, 78)
        Me.chkProtectorAuditivo.Name = "chkProtectorAuditivo"
        Me.chkProtectorAuditivo.Size = New System.Drawing.Size(109, 17)
        Me.chkProtectorAuditivo.TabIndex = 14
        Me.chkProtectorAuditivo.Text = "Protector auditivo"
        Me.chkProtectorAuditivo.UseVisualStyleBackColor = True
        '
        'chkBarbijo
        '
        Me.chkBarbijo.AutoSize = True
        Me.chkBarbijo.Location = New System.Drawing.Point(44, 56)
        Me.chkBarbijo.Name = "chkBarbijo"
        Me.chkBarbijo.Size = New System.Drawing.Size(58, 17)
        Me.chkBarbijo.TabIndex = 13
        Me.chkBarbijo.Text = "Barbijo"
        Me.chkBarbijo.UseVisualStyleBackColor = True
        '
        'chkCasco
        '
        Me.chkCasco.AutoSize = True
        Me.chkCasco.Location = New System.Drawing.Point(44, 31)
        Me.chkCasco.Name = "chkCasco"
        Me.chkCasco.Size = New System.Drawing.Size(56, 17)
        Me.chkCasco.TabIndex = 12
        Me.chkCasco.Text = "Casco"
        Me.chkCasco.UseVisualStyleBackColor = True
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Location = New System.Drawing.Point(6, 132)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(32, 13)
        Me.Label49.TabIndex = 11
        Me.Label49.Text = "Otros"
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.txtOtrosDocumentos)
        Me.GroupBox7.Controls.Add(Me.chkSeguroVehiculo)
        Me.GroupBox7.Controls.Add(Me.chkArt)
        Me.GroupBox7.Controls.Add(Me.chkAutorizacionIngreso)
        Me.GroupBox7.Controls.Add(Me.Label48)
        Me.GroupBox7.Location = New System.Drawing.Point(9, 33)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(360, 144)
        Me.GroupBox7.TabIndex = 0
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Documentos"
        '
        'txtOtrosDocumentos
        '
        Me.txtOtrosDocumentos.Location = New System.Drawing.Point(44, 101)
        Me.txtOtrosDocumentos.Name = "txtOtrosDocumentos"
        Me.txtOtrosDocumentos.Size = New System.Drawing.Size(272, 20)
        Me.txtOtrosDocumentos.TabIndex = 7
        '
        'chkSeguroVehiculo
        '
        Me.chkSeguroVehiculo.AutoSize = True
        Me.chkSeguroVehiculo.Location = New System.Drawing.Point(44, 74)
        Me.chkSeguroVehiculo.Name = "chkSeguroVehiculo"
        Me.chkSeguroVehiculo.Size = New System.Drawing.Size(120, 17)
        Me.chkSeguroVehiculo.TabIndex = 6
        Me.chkSeguroVehiculo.Text = "Seguro del vehiculo"
        Me.chkSeguroVehiculo.UseVisualStyleBackColor = True
        '
        'chkArt
        '
        Me.chkArt.AutoSize = True
        Me.chkArt.Location = New System.Drawing.Point(44, 52)
        Me.chkArt.Name = "chkArt"
        Me.chkArt.Size = New System.Drawing.Size(156, 17)
        Me.chkArt.TabIndex = 5
        Me.chkArt.Text = "Comprobante de pago ART"
        Me.chkArt.UseVisualStyleBackColor = True
        '
        'chkAutorizacionIngreso
        '
        Me.chkAutorizacionIngreso.AutoSize = True
        Me.chkAutorizacionIngreso.Location = New System.Drawing.Point(44, 27)
        Me.chkAutorizacionIngreso.Name = "chkAutorizacionIngreso"
        Me.chkAutorizacionIngreso.Size = New System.Drawing.Size(202, 17)
        Me.chkAutorizacionIngreso.TabIndex = 4
        Me.chkAutorizacionIngreso.Text = "Autorización del personal que ingresa"
        Me.chkAutorizacionIngreso.UseVisualStyleBackColor = True
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Location = New System.Drawing.Point(6, 104)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(32, 13)
        Me.Label48.TabIndex = 3
        Me.Label48.Text = "Otros"
        '
        'txtId
        '
        Me.txtId.Enabled = False
        Me.txtId.Location = New System.Drawing.Point(262, 4)
        Me.txtId.Name = "txtId"
        Me.txtId.ReadOnly = True
        Me.txtId.Size = New System.Drawing.Size(75, 20)
        Me.txtId.TabIndex = 1
        '
        'txtCodigoCliente
        '
        Me.txtCodigoCliente.ContextMenuStrip = Me.cms
        Me.txtCodigoCliente.Enabled = False
        Me.txtCodigoCliente.Location = New System.Drawing.Point(181, 29)
        Me.txtCodigoCliente.MaxLength = 6
        Me.txtCodigoCliente.Name = "txtCodigoCliente"
        Me.txtCodigoCliente.Size = New System.Drawing.Size(75, 20)
        Me.txtCodigoCliente.TabIndex = 2
        '
        'cms
        '
        Me.cms.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuEditar})
        Me.cms.Name = "cms"
        Me.cms.Size = New System.Drawing.Size(105, 26)
        '
        'mnuEditar
        '
        Me.mnuEditar.Name = "mnuEditar"
        Me.mnuEditar.Size = New System.Drawing.Size(104, 22)
        Me.mnuEditar.Text = "Editar"
        '
        'txtNombreCliente
        '
        Me.txtNombreCliente.Location = New System.Drawing.Point(262, 30)
        Me.txtNombreCliente.Name = "txtNombreCliente"
        Me.txtNombreCliente.ReadOnly = True
        Me.txtNombreCliente.Size = New System.Drawing.Size(182, 20)
        Me.txtNombreCliente.TabIndex = 3
        '
        'btnNuevo
        '
        Me.btnNuevo.Location = New System.Drawing.Point(9, 12)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(75, 23)
        Me.btnNuevo.TabIndex = 0
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'btnAutorizar
        '
        Me.btnAutorizar.Location = New System.Drawing.Point(501, 476)
        Me.btnAutorizar.Name = "btnAutorizar"
        Me.btnAutorizar.Size = New System.Drawing.Size(130, 23)
        Me.btnAutorizar.TabIndex = 0
        Me.btnAutorizar.Text = "Crear contrato Adonix"
        Me.btnAutorizar.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.SplitContainer2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.cboSucursal)
        Me.SplitContainer1.Panel2.Controls.Add(Me.BtnImprimir)
        Me.SplitContainer1.Panel2.Controls.Add(Me.cboEstado)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnAutorizar)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnRegistrar)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnNuevo)
        Me.SplitContainer1.Panel2.Controls.Add(EstadoContrato)
        Me.SplitContainer1.Panel2.Controls.Add(Me.tab)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtNombreCliente)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtCodigoCliente)
        Me.SplitContainer1.Panel2.Controls.Add(Label3)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtId)
        Me.SplitContainer1.Panel2.Controls.Add(Label2)
        Me.SplitContainer1.Size = New System.Drawing.Size(940, 505)
        Me.SplitContainer1.SplitterDistance = 259
        Me.SplitContainer1.TabIndex = 0
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
        Me.SplitContainer2.Panel1.Controls.Add(Me.dgvPrincipal)
        Me.SplitContainer2.Panel1.Controls.Add(Me.btnBuscar)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.btnRenovaciones)
        Me.SplitContainer2.Panel2.Controls.Add(Me.dgvRenovar)
        Me.SplitContainer2.Size = New System.Drawing.Size(259, 505)
        Me.SplitContainer2.SplitterDistance = 247
        Me.SplitContainer2.TabIndex = 0
        '
        'dgvPrincipal
        '
        Me.dgvPrincipal.AllowUserToAddRows = False
        Me.dgvPrincipal.AllowUserToDeleteRows = False
        Me.dgvPrincipal.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPrincipal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPrincipal.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DGVnro, Me.DGVCliente})
        Me.dgvPrincipal.Location = New System.Drawing.Point(3, 3)
        Me.dgvPrincipal.Name = "dgvPrincipal"
        Me.dgvPrincipal.ReadOnly = True
        Me.dgvPrincipal.RowHeadersVisible = False
        Me.dgvPrincipal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPrincipal.Size = New System.Drawing.Size(253, 198)
        Me.dgvPrincipal.TabIndex = 2
        '
        'DGVnro
        '
        Me.DGVnro.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.DGVnro.HeaderText = "Nro"
        Me.DGVnro.Name = "DGVnro"
        Me.DGVnro.ReadOnly = True
        Me.DGVnro.Width = 49
        '
        'DGVCliente
        '
        Me.DGVCliente.HeaderText = "Cliente"
        Me.DGVCliente.Name = "DGVCliente"
        Me.DGVCliente.ReadOnly = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnBuscar.Location = New System.Drawing.Point(88, 211)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(96, 23)
        Me.btnBuscar.TabIndex = 1
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'btnRenovaciones
        '
        Me.btnRenovaciones.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnRenovaciones.Location = New System.Drawing.Point(88, 225)
        Me.btnRenovaciones.Name = "btnRenovaciones"
        Me.btnRenovaciones.Size = New System.Drawing.Size(96, 23)
        Me.btnRenovaciones.TabIndex = 4
        Me.btnRenovaciones.Text = "Buscar"
        Me.btnRenovaciones.UseVisualStyleBackColor = True
        '
        'dgvRenovar
        '
        Me.dgvRenovar.AllowUserToAddRows = False
        Me.dgvRenovar.AllowUserToDeleteRows = False
        Me.dgvRenovar.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvRenovar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRenovar.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colNro2, Me.colCliente2, Me.colNombre2, Me.colVto2, Me.colModo2})
        Me.dgvRenovar.Location = New System.Drawing.Point(3, 6)
        Me.dgvRenovar.Name = "dgvRenovar"
        Me.dgvRenovar.ReadOnly = True
        Me.dgvRenovar.RowHeadersVisible = False
        Me.dgvRenovar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvRenovar.Size = New System.Drawing.Size(253, 207)
        Me.dgvRenovar.TabIndex = 3
        '
        'colNro2
        '
        Me.colNro2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colNro2.HeaderText = "Nro"
        Me.colNro2.Name = "colNro2"
        Me.colNro2.ReadOnly = True
        Me.colNro2.Width = 49
        '
        'colCliente2
        '
        Me.colCliente2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colCliente2.HeaderText = "Cliente"
        Me.colCliente2.Name = "colCliente2"
        Me.colCliente2.ReadOnly = True
        Me.colCliente2.Width = 64
        '
        'colNombre2
        '
        Me.colNombre2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colNombre2.HeaderText = "Nombre"
        Me.colNombre2.Name = "colNombre2"
        Me.colNombre2.ReadOnly = True
        Me.colNombre2.Width = 69
        '
        'colVto2
        '
        Me.colVto2.HeaderText = "Vto"
        Me.colVto2.Name = "colVto2"
        Me.colVto2.ReadOnly = True
        '
        'colModo2
        '
        Me.colModo2.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.colModo2.HeaderText = "Modo"
        Me.colModo2.Name = "colModo2"
        Me.colModo2.ReadOnly = True
        '
        'cboSucursal
        '
        Me.cboSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSucursal.Enabled = False
        Me.cboSucursal.FormattingEnabled = True
        Me.cboSucursal.Location = New System.Drawing.Point(450, 30)
        Me.cboSucursal.Name = "cboSucursal"
        Me.cboSucursal.Size = New System.Drawing.Size(214, 21)
        Me.cboSucursal.TabIndex = 30
        '
        'BtnImprimir
        '
        Me.BtnImprimir.Location = New System.Drawing.Point(115, 476)
        Me.BtnImprimir.Name = "BtnImprimir"
        Me.BtnImprimir.Size = New System.Drawing.Size(75, 23)
        Me.BtnImprimir.TabIndex = 29
        Me.BtnImprimir.Text = "Imprimir"
        Me.BtnImprimir.UseVisualStyleBackColor = True
        '
        'cboEstado
        '
        Me.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEstado.Enabled = False
        Me.cboEstado.FormattingEnabled = True
        Me.cboEstado.Location = New System.Drawing.Point(509, 3)
        Me.cboEstado.Name = "cboEstado"
        Me.cboEstado.Size = New System.Drawing.Size(155, 21)
        Me.cboEstado.TabIndex = 28
        '
        'btnRegistrar
        '
        Me.btnRegistrar.Location = New System.Drawing.Point(34, 476)
        Me.btnRegistrar.Name = "btnRegistrar"
        Me.btnRegistrar.Size = New System.Drawing.Size(75, 23)
        Me.btnRegistrar.TabIndex = 0
        Me.btnRegistrar.Text = "Registrar"
        Me.btnRegistrar.UseVisualStyleBackColor = True
        '
        'chkRenovacion
        '
        Me.chkRenovacion.AutoSize = True
        Me.chkRenovacion.Location = New System.Drawing.Point(147, 37)
        Me.chkRenovacion.Name = "chkRenovacion"
        Me.chkRenovacion.Size = New System.Drawing.Size(84, 17)
        Me.chkRenovacion.TabIndex = 8
        Me.chkRenovacion.Text = "Renovación"
        Me.chkRenovacion.UseVisualStyleBackColor = True
        '
        'frmContrato
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(940, 505)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "frmContrato"
        Me.Text = "Contratos"
        Me.tab.ResumeLayout(False)
        Me.TabGeneral.ResumeLayout(False)
        Me.TabGeneral.PerformLayout()
        CType(Me.nudDuracion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.tabsecundaria.ResumeLayout(False)
        Me.tabsecundaria.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.gbTarjetas.ResumeLayout(False)
        Me.gbTarjetas.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.nudCantidadHidrantes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.nudCantidadMatafuegos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabSucursal.ResumeLayout(False)
        CType(Me.dgvSucursales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabDocElem.ResumeLayout(False)
        Me.GroupBox10.ResumeLayout(False)
        Me.GroupBox10.PerformLayout()
        CType(Me.nudUnificacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        CType(Me.nudFrecuenciaFacturacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.cms.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.dgvPrincipal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvRenovar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tab As System.Windows.Forms.TabControl
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents TabGeneral As System.Windows.Forms.TabPage
    Friend WithEvents txtMailComercial As System.Windows.Forms.TextBox
    Friend WithEvents txtTelefonoComercial As System.Windows.Forms.TextBox
    Friend WithEvents txtContactoOperativo As System.Windows.Forms.TextBox
    Friend WithEvents txtConcactoComercial As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigoCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtNombreCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtId As System.Windows.Forms.TextBox
    Friend WithEvents dtpInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtMailOperativo As System.Windows.Forms.TextBox
    Friend WithEvents txtTelefonoOperativo As System.Windows.Forms.TextBox
    Friend WithEvents txtOc As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtDetalle639 As System.Windows.Forms.TextBox
    Friend WithEvents txtMantIntRedHdri As System.Windows.Forms.TextBox
    Friend WithEvents txtMantBocasHidr As System.Windows.Forms.TextBox
    Friend WithEvents txtPhMangueras As System.Windows.Forms.TextBox
    Friend WithEvents tabsecundaria As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents gbTarjetas As System.Windows.Forms.GroupBox
    Friend WithEvents optTarjeta2 As System.Windows.Forms.RadioButton
    Friend WithEvents optTarjeta3 As System.Windows.Forms.RadioButton
    Friend WithEvents optTarjeta1 As System.Windows.Forms.RadioButton
    Friend WithEvents TabSucursal As System.Windows.Forms.TabPage
    Friend WithEvents dgvSucursales As System.Windows.Forms.DataGridView
    Friend WithEvents TabDocElem As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents txtotrosElementos As System.Windows.Forms.TextBox
    Friend WithEvents chkProtectorAuditivo As System.Windows.Forms.CheckBox
    Friend WithEvents chkBarbijo As System.Windows.Forms.CheckBox
    Friend WithEvents chkCasco As System.Windows.Forms.CheckBox
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents txtOtrosDocumentos As System.Windows.Forms.TextBox
    Friend WithEvents chkSeguroVehiculo As System.Windows.Forms.CheckBox
    Friend WithEvents chkArt As System.Windows.Forms.CheckBox
    Friend WithEvents chkAutorizacionIngreso As System.Windows.Forms.CheckBox
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents chkZapatosSeguridad As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents txtImporteMensual As System.Windows.Forms.TextBox
    Friend WithEvents txtImporteAnual As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents dgvPrincipal As System.Windows.Forms.DataGridView
    Friend WithEvents btnAutorizar As System.Windows.Forms.Button
    Friend WithEvents chkPq55 As System.Windows.Forms.CheckBox
    Friend WithEvents chkOtros As System.Windows.Forms.CheckBox
    Friend WithEvents chkAcetato As System.Windows.Forms.CheckBox
    Friend WithEvents chkHalogenados As System.Windows.Forms.CheckBox
    Friend WithEvents chkAfff As System.Windows.Forms.CheckBox
    Friend WithEvents chkCo2 As System.Windows.Forms.CheckBox
    Friend WithEvents chkPq As System.Windows.Forms.CheckBox
    Friend WithEvents chkPq90 As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents chkInstalacion As System.Windows.Forms.CheckBox
    Friend WithEvents chkProvision As System.Windows.Forms.CheckBox
    Friend WithEvents chk639 As System.Windows.Forms.CheckBox
    Friend WithEvents chkMantenimientoRed As System.Windows.Forms.CheckBox
    Friend WithEvents chkMantenimientoBocas As System.Windows.Forms.CheckBox
    Friend WithEvents chkPhMangueras As System.Windows.Forms.CheckBox
    Friend WithEvents DGVnro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVCliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox10 As System.Windows.Forms.GroupBox
    Friend WithEvents txtOtrosInstalacion As System.Windows.Forms.TextBox
    Friend WithEvents btnRegistrar As System.Windows.Forms.Button
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents cboCondicionPago As System.Windows.Forms.ComboBox
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents colCodSucursal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDireccion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colLocalidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnAgregarSucursal As System.Windows.Forms.Button
    Friend WithEvents btnAgregarTodas As System.Windows.Forms.Button
    Friend WithEvents chkControlPeriodico As System.Windows.Forms.CheckBox
    Friend WithEvents chkVisita As System.Windows.Forms.CheckBox
    Friend WithEvents TxtOtrosRelevamiento As System.Windows.Forms.TextBox
    Friend WithEvents cboEstado As System.Windows.Forms.ComboBox
    Friend WithEvents nudCantidadHidrantes As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudCantidadMatafuegos As System.Windows.Forms.NumericUpDown
    Friend WithEvents cboVendedor As System.Windows.Forms.ComboBox
    Friend WithEvents nudUnificacion As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudFrecuenciaFacturacion As System.Windows.Forms.NumericUpDown
    Friend WithEvents cboModoFacturacion As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents BtnImprimir As System.Windows.Forms.Button
    Friend WithEvents btnRenovaciones As System.Windows.Forms.Button
    Friend WithEvents dgvRenovar As System.Windows.Forms.DataGridView
    Friend WithEvents txtObs As System.Windows.Forms.TextBox
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents colNro2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCliente2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNombre2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colVto2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colModo2 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents nudDuracion As System.Windows.Forms.NumericUpDown
    Friend WithEvents cboSucursal As System.Windows.Forms.ComboBox
    Friend WithEvents cms As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuEditar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chkRenovacion As System.Windows.Forms.CheckBox
End Class
