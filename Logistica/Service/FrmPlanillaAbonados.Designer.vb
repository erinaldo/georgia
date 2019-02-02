<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPlanillaAbonados
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
        Dim Label1 As System.Windows.Forms.Label
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
        Me.dtp = New System.Windows.Forms.DateTimePicker
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.dgv1 = New System.Windows.Forms.DataGridView
        Me.Tab = New System.Windows.Forms.TabControl
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.DgvIntervencion = New System.Windows.Forms.DataGridView
        Me.ColIntFecha = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColIntNumero = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColItnCodigoCliente = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColItnRazonSocial = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColItnNroSuc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColItnDomicilio = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColItnLocalidad = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColItnCodigo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColItnDescripcionCodigo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColItnCantidad = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DgvRemito = New System.Windows.Forms.DataGridView
        Me.ColRtoFecha = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColRtoNroRemito = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColRtoCodigoCliente = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColRtoRazonSocial = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColRtoNroSucursal = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColRtoDomicilio = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColRtoLocalidad = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColRtoKgTotales = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColRtoCantTotalesInstalaciones = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColRtoEstado = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ChkContratosVencidos = New System.Windows.Forms.CheckBox
        Me.btnConsultar = New System.Windows.Forms.Button
        Me.BtnConsultar2 = New System.Windows.Forms.Button
        Me.lblInfo = New System.Windows.Forms.Label
        Me.CodCliente = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColRazonSocial = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColSucursal = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColDomicilio = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColLocalidad = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColNumContrato = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColFechaVencContrato = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColParqueTotal = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colParqueVencidoManuales = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colParqueVencidoCarros = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colParqueVencidoMangueras = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colParqueAVencerManuales = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colParqueAVencerCarros = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colParqueAVencerMangueras = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColParqueAUnificar = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colRetirado = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colEntregado = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColParqueVisitaMensual = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.ColParqueControles = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.ColMesVence = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColRemitoClienteSucursalABO = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.colUnificacion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Label1 = New System.Windows.Forms.Label
        Me.TabPage1.SuspendLayout()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.DgvIntervencion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgvRemito, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(12, 16)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(85, 13)
        Label1.TabIndex = 2
        Label1.Text = "Mes a consultar:"
        '
        'dtp
        '
        Me.dtp.CustomFormat = "MMMM/yyyy"
        Me.dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp.Location = New System.Drawing.Point(110, 12)
        Me.dtp.Name = "dtp"
        Me.dtp.Size = New System.Drawing.Size(149, 20)
        Me.dtp.TabIndex = 3
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dgv1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(958, 406)
        Me.TabPage1.TabIndex = 2
        Me.TabPage1.Text = "Recarga Abonados"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'dgv1
        '
        Me.dgv1.AllowUserToAddRows = False
        Me.dgv1.AllowUserToDeleteRows = False
        Me.dgv1.AllowUserToResizeColumns = False
        Me.dgv1.AllowUserToResizeRows = False
        Me.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CodCliente, Me.ColRazonSocial, Me.ColSucursal, Me.ColDomicilio, Me.ColLocalidad, Me.ColNumContrato, Me.ColFechaVencContrato, Me.ColParqueTotal, Me.colParqueVencidoManuales, Me.colParqueVencidoCarros, Me.colParqueVencidoMangueras, Me.colParqueAVencerManuales, Me.colParqueAVencerCarros, Me.colParqueAVencerMangueras, Me.ColParqueAUnificar, Me.colRetirado, Me.colEntregado, Me.ColParqueVisitaMensual, Me.ColParqueControles, Me.ColMesVence, Me.ColRemitoClienteSucursalABO, Me.colUnificacion})
        Me.dgv1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv1.Location = New System.Drawing.Point(3, 3)
        Me.dgv1.Name = "dgv1"
        Me.dgv1.ReadOnly = True
        Me.dgv1.Size = New System.Drawing.Size(952, 400)
        Me.dgv1.TabIndex = 0
        '
        'Tab
        '
        Me.Tab.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Tab.Controls.Add(Me.TabPage1)
        Me.Tab.Controls.Add(Me.TabPage2)
        Me.Tab.Location = New System.Drawing.Point(3, 48)
        Me.Tab.Name = "Tab"
        Me.Tab.SelectedIndex = 0
        Me.Tab.Size = New System.Drawing.Size(966, 432)
        Me.Tab.TabIndex = 6
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.SplitContainer1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(793, 406)
        Me.TabPage2.TabIndex = 3
        Me.TabPage2.Text = "Otras Tareas"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.DgvIntervencion)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.DgvRemito)
        Me.SplitContainer1.Size = New System.Drawing.Size(787, 400)
        Me.SplitContainer1.SplitterDistance = 195
        Me.SplitContainer1.TabIndex = 0
        '
        'DgvIntervencion
        '
        Me.DgvIntervencion.AllowUserToAddRows = False
        Me.DgvIntervencion.AllowUserToDeleteRows = False
        Me.DgvIntervencion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvIntervencion.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColIntFecha, Me.ColIntNumero, Me.ColItnCodigoCliente, Me.ColItnRazonSocial, Me.ColItnNroSuc, Me.ColItnDomicilio, Me.ColItnLocalidad, Me.ColItnCodigo, Me.ColItnDescripcionCodigo, Me.ColItnCantidad})
        Me.DgvIntervencion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvIntervencion.Location = New System.Drawing.Point(0, 0)
        Me.DgvIntervencion.Name = "DgvIntervencion"
        Me.DgvIntervencion.ReadOnly = True
        Me.DgvIntervencion.RowHeadersVisible = False
        Me.DgvIntervencion.Size = New System.Drawing.Size(787, 195)
        Me.DgvIntervencion.TabIndex = 0
        '
        'ColIntFecha
        '
        Me.ColIntFecha.HeaderText = "Fecha"
        Me.ColIntFecha.Name = "ColIntFecha"
        Me.ColIntFecha.ReadOnly = True
        '
        'ColIntNumero
        '
        Me.ColIntNumero.HeaderText = "Numero Intervencion"
        Me.ColIntNumero.Name = "ColIntNumero"
        Me.ColIntNumero.ReadOnly = True
        '
        'ColItnCodigoCliente
        '
        Me.ColItnCodigoCliente.HeaderText = "Codigo Cliente"
        Me.ColItnCodigoCliente.Name = "ColItnCodigoCliente"
        Me.ColItnCodigoCliente.ReadOnly = True
        '
        'ColItnRazonSocial
        '
        Me.ColItnRazonSocial.HeaderText = "Razon Social"
        Me.ColItnRazonSocial.Name = "ColItnRazonSocial"
        Me.ColItnRazonSocial.ReadOnly = True
        '
        'ColItnNroSuc
        '
        Me.ColItnNroSuc.HeaderText = "Nro Sucursal"
        Me.ColItnNroSuc.Name = "ColItnNroSuc"
        Me.ColItnNroSuc.ReadOnly = True
        '
        'ColItnDomicilio
        '
        Me.ColItnDomicilio.HeaderText = "Domicilio"
        Me.ColItnDomicilio.Name = "ColItnDomicilio"
        Me.ColItnDomicilio.ReadOnly = True
        '
        'ColItnLocalidad
        '
        Me.ColItnLocalidad.HeaderText = "Localidad"
        Me.ColItnLocalidad.Name = "ColItnLocalidad"
        Me.ColItnLocalidad.ReadOnly = True
        '
        'ColItnCodigo
        '
        Me.ColItnCodigo.HeaderText = "Codigo"
        Me.ColItnCodigo.Name = "ColItnCodigo"
        Me.ColItnCodigo.ReadOnly = True
        '
        'ColItnDescripcionCodigo
        '
        Me.ColItnDescripcionCodigo.HeaderText = "Descripcion"
        Me.ColItnDescripcionCodigo.Name = "ColItnDescripcionCodigo"
        Me.ColItnDescripcionCodigo.ReadOnly = True
        '
        'ColItnCantidad
        '
        Me.ColItnCantidad.HeaderText = "Cantidad"
        Me.ColItnCantidad.Name = "ColItnCantidad"
        Me.ColItnCantidad.ReadOnly = True
        '
        'DgvRemito
        '
        Me.DgvRemito.AllowUserToAddRows = False
        Me.DgvRemito.AllowUserToDeleteRows = False
        Me.DgvRemito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvRemito.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColRtoFecha, Me.ColRtoNroRemito, Me.ColRtoCodigoCliente, Me.ColRtoRazonSocial, Me.ColRtoNroSucursal, Me.ColRtoDomicilio, Me.ColRtoLocalidad, Me.ColRtoKgTotales, Me.ColRtoCantTotalesInstalaciones, Me.ColRtoEstado})
        Me.DgvRemito.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvRemito.Location = New System.Drawing.Point(0, 0)
        Me.DgvRemito.Name = "DgvRemito"
        Me.DgvRemito.ReadOnly = True
        Me.DgvRemito.RowHeadersVisible = False
        Me.DgvRemito.Size = New System.Drawing.Size(787, 201)
        Me.DgvRemito.TabIndex = 0
        '
        'ColRtoFecha
        '
        Me.ColRtoFecha.HeaderText = "Fecha"
        Me.ColRtoFecha.Name = "ColRtoFecha"
        Me.ColRtoFecha.ReadOnly = True
        '
        'ColRtoNroRemito
        '
        Me.ColRtoNroRemito.HeaderText = "Numero Remito"
        Me.ColRtoNroRemito.Name = "ColRtoNroRemito"
        Me.ColRtoNroRemito.ReadOnly = True
        '
        'ColRtoCodigoCliente
        '
        Me.ColRtoCodigoCliente.HeaderText = "Codigo Cliente"
        Me.ColRtoCodigoCliente.Name = "ColRtoCodigoCliente"
        Me.ColRtoCodigoCliente.ReadOnly = True
        '
        'ColRtoRazonSocial
        '
        Me.ColRtoRazonSocial.HeaderText = "Razon Social"
        Me.ColRtoRazonSocial.Name = "ColRtoRazonSocial"
        Me.ColRtoRazonSocial.ReadOnly = True
        '
        'ColRtoNroSucursal
        '
        Me.ColRtoNroSucursal.HeaderText = "Nro Sucursal"
        Me.ColRtoNroSucursal.Name = "ColRtoNroSucursal"
        Me.ColRtoNroSucursal.ReadOnly = True
        '
        'ColRtoDomicilio
        '
        Me.ColRtoDomicilio.HeaderText = "Domicilio"
        Me.ColRtoDomicilio.Name = "ColRtoDomicilio"
        Me.ColRtoDomicilio.ReadOnly = True
        '
        'ColRtoLocalidad
        '
        Me.ColRtoLocalidad.HeaderText = "Localidad"
        Me.ColRtoLocalidad.Name = "ColRtoLocalidad"
        Me.ColRtoLocalidad.ReadOnly = True
        '
        'ColRtoKgTotales
        '
        Me.ColRtoKgTotales.HeaderText = "Kg Totales"
        Me.ColRtoKgTotales.Name = "ColRtoKgTotales"
        Me.ColRtoKgTotales.ReadOnly = True
        '
        'ColRtoCantTotalesInstalaciones
        '
        Me.ColRtoCantTotalesInstalaciones.HeaderText = "Cantidad Totales Instalaciones"
        Me.ColRtoCantTotalesInstalaciones.Name = "ColRtoCantTotalesInstalaciones"
        Me.ColRtoCantTotalesInstalaciones.ReadOnly = True
        '
        'ColRtoEstado
        '
        Me.ColRtoEstado.HeaderText = "ESTADO"
        Me.ColRtoEstado.Name = "ColRtoEstado"
        Me.ColRtoEstado.ReadOnly = True
        '
        'ChkContratosVencidos
        '
        Me.ChkContratosVencidos.AutoSize = True
        Me.ChkContratosVencidos.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkContratosVencidos.Location = New System.Drawing.Point(265, 15)
        Me.ChkContratosVencidos.Name = "ChkContratosVencidos"
        Me.ChkContratosVencidos.Size = New System.Drawing.Size(118, 17)
        Me.ChkContratosVencidos.TabIndex = 7
        Me.ChkContratosVencidos.Text = "Contratos Vencidos"
        Me.ChkContratosVencidos.UseVisualStyleBackColor = True
        '
        'btnConsultar
        '
        Me.btnConsultar.Location = New System.Drawing.Point(401, 9)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(75, 23)
        Me.btnConsultar.TabIndex = 8
        Me.btnConsultar.Text = "Consultar"
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'BtnConsultar2
        '
        Me.BtnConsultar2.Location = New System.Drawing.Point(482, 9)
        Me.BtnConsultar2.Name = "BtnConsultar2"
        Me.BtnConsultar2.Size = New System.Drawing.Size(75, 23)
        Me.BtnConsultar2.TabIndex = 10
        Me.BtnConsultar2.Text = "Consultar"
        Me.BtnConsultar2.UseVisualStyleBackColor = True
        '
        'lblInfo
        '
        Me.lblInfo.AutoSize = True
        Me.lblInfo.Location = New System.Drawing.Point(398, 35)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(39, 13)
        Me.lblInfo.TabIndex = 11
        Me.lblInfo.Text = "Label2"
        Me.lblInfo.Visible = False
        '
        'CodCliente
        '
        Me.CodCliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.CodCliente.HeaderText = "CodCliente"
        Me.CodCliente.Name = "CodCliente"
        Me.CodCliente.ReadOnly = True
        Me.CodCliente.Width = 83
        '
        'ColRazonSocial
        '
        Me.ColRazonSocial.HeaderText = "Razon Social"
        Me.ColRazonSocial.Name = "ColRazonSocial"
        Me.ColRazonSocial.ReadOnly = True
        '
        'ColSucursal
        '
        Me.ColSucursal.HeaderText = "Sucursal"
        Me.ColSucursal.Name = "ColSucursal"
        Me.ColSucursal.ReadOnly = True
        '
        'ColDomicilio
        '
        Me.ColDomicilio.HeaderText = "Domicilio"
        Me.ColDomicilio.Name = "ColDomicilio"
        Me.ColDomicilio.ReadOnly = True
        '
        'ColLocalidad
        '
        Me.ColLocalidad.HeaderText = "Localidad"
        Me.ColLocalidad.Name = "ColLocalidad"
        Me.ColLocalidad.ReadOnly = True
        '
        'ColNumContrato
        '
        Me.ColNumContrato.HeaderText = "Numero Contrato"
        Me.ColNumContrato.Name = "ColNumContrato"
        Me.ColNumContrato.ReadOnly = True
        '
        'ColFechaVencContrato
        '
        Me.ColFechaVencContrato.HeaderText = "Fecha Vencimiento Contrato"
        Me.ColFechaVencContrato.Name = "ColFechaVencContrato"
        Me.ColFechaVencContrato.ReadOnly = True
        '
        'ColParqueTotal
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.ColParqueTotal.DefaultCellStyle = DataGridViewCellStyle1
        Me.ColParqueTotal.HeaderText = "Parque Total"
        Me.ColParqueTotal.Name = "ColParqueTotal"
        Me.ColParqueTotal.ReadOnly = True
        '
        'colParqueVencidoManuales
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colParqueVencidoManuales.DefaultCellStyle = DataGridViewCellStyle2
        Me.colParqueVencidoManuales.HeaderText = "Manuales Vencidos"
        Me.colParqueVencidoManuales.Name = "colParqueVencidoManuales"
        Me.colParqueVencidoManuales.ReadOnly = True
        '
        'colParqueVencidoCarros
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colParqueVencidoCarros.DefaultCellStyle = DataGridViewCellStyle3
        Me.colParqueVencidoCarros.HeaderText = "Carros Vencidos"
        Me.colParqueVencidoCarros.Name = "colParqueVencidoCarros"
        Me.colParqueVencidoCarros.ReadOnly = True
        '
        'colParqueVencidoMangueras
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colParqueVencidoMangueras.DefaultCellStyle = DataGridViewCellStyle4
        Me.colParqueVencidoMangueras.HeaderText = "Mangueras Vencidas"
        Me.colParqueVencidoMangueras.Name = "colParqueVencidoMangueras"
        Me.colParqueVencidoMangueras.ReadOnly = True
        '
        'colParqueAVencerManuales
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colParqueAVencerManuales.DefaultCellStyle = DataGridViewCellStyle5
        Me.colParqueAVencerManuales.HeaderText = "Manuales A Vencer"
        Me.colParqueAVencerManuales.Name = "colParqueAVencerManuales"
        Me.colParqueAVencerManuales.ReadOnly = True
        '
        'colParqueAVencerCarros
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colParqueAVencerCarros.DefaultCellStyle = DataGridViewCellStyle6
        Me.colParqueAVencerCarros.HeaderText = "Carros A Vencer"
        Me.colParqueAVencerCarros.Name = "colParqueAVencerCarros"
        Me.colParqueAVencerCarros.ReadOnly = True
        '
        'colParqueAVencerMangueras
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colParqueAVencerMangueras.DefaultCellStyle = DataGridViewCellStyle7
        Me.colParqueAVencerMangueras.HeaderText = "Mangueras A Vencer"
        Me.colParqueAVencerMangueras.Name = "colParqueAVencerMangueras"
        Me.colParqueAVencerMangueras.ReadOnly = True
        '
        'ColParqueAUnificar
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.ColParqueAUnificar.DefaultCellStyle = DataGridViewCellStyle8
        Me.ColParqueAUnificar.HeaderText = "Parque a Unificar"
        Me.ColParqueAUnificar.Name = "ColParqueAUnificar"
        Me.ColParqueAUnificar.ReadOnly = True
        '
        'colRetirado
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colRetirado.DefaultCellStyle = DataGridViewCellStyle9
        Me.colRetirado.HeaderText = "Parque Retirado"
        Me.colRetirado.Name = "colRetirado"
        Me.colRetirado.ReadOnly = True
        '
        'colEntregado
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colEntregado.DefaultCellStyle = DataGridViewCellStyle10
        Me.colEntregado.HeaderText = "Parque Entregado"
        Me.colEntregado.Name = "colEntregado"
        Me.colEntregado.ReadOnly = True
        '
        'ColParqueVisitaMensual
        '
        Me.ColParqueVisitaMensual.FalseValue = "0"
        Me.ColParqueVisitaMensual.HeaderText = "Visita Mensual"
        Me.ColParqueVisitaMensual.Name = "ColParqueVisitaMensual"
        Me.ColParqueVisitaMensual.ReadOnly = True
        Me.ColParqueVisitaMensual.TrueValue = "1"
        '
        'ColParqueControles
        '
        Me.ColParqueControles.FalseValue = "0"
        Me.ColParqueControles.HeaderText = "Parque Controles"
        Me.ColParqueControles.Name = "ColParqueControles"
        Me.ColParqueControles.ReadOnly = True
        Me.ColParqueControles.TrueValue = "1"
        '
        'ColMesVence
        '
        Me.ColMesVence.HeaderText = "MesVence"
        Me.ColMesVence.Name = "ColMesVence"
        Me.ColMesVence.ReadOnly = True
        '
        'ColRemitoClienteSucursalABO
        '
        Me.ColRemitoClienteSucursalABO.HeaderText = "RemitoClienteSucursalABO"
        Me.ColRemitoClienteSucursalABO.Name = "ColRemitoClienteSucursalABO"
        Me.ColRemitoClienteSucursalABO.ReadOnly = True
        Me.ColRemitoClienteSucursalABO.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ColRemitoClienteSucursalABO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'colUnificacion
        '
        Me.colUnificacion.HeaderText = "Unificación"
        Me.colUnificacion.Name = "colUnificacion"
        Me.colUnificacion.ReadOnly = True
        Me.colUnificacion.Visible = False
        '
        'FrmPlanillaAbonados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(973, 491)
        Me.Controls.Add(Me.lblInfo)
        Me.Controls.Add(Me.BtnConsultar2)
        Me.Controls.Add(Me.btnConsultar)
        Me.Controls.Add(Me.ChkContratosVencidos)
        Me.Controls.Add(Me.Tab)
        Me.Controls.Add(Me.dtp)
        Me.Controls.Add(Label1)
        Me.Name = "FrmPlanillaAbonados"
        Me.Text = "FrmPlanillaAbonados"
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.DgvIntervencion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgvRemito, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtp As System.Windows.Forms.DateTimePicker
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents dgv1 As System.Windows.Forms.DataGridView
    Friend WithEvents Tab As System.Windows.Forms.TabControl
    Friend WithEvents ChkContratosVencidos As System.Windows.Forms.CheckBox
    Friend WithEvents btnConsultar As System.Windows.Forms.Button
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents DgvIntervencion As System.Windows.Forms.DataGridView
    Friend WithEvents DgvRemito As System.Windows.Forms.DataGridView
    Friend WithEvents ColIntFecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColIntNumero As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColItnCodigoCliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColItnRazonSocial As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColItnNroSuc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColItnDomicilio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColItnLocalidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColItnCodigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColItnDescripcionCodigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColItnCantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColRtoFecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColRtoNroRemito As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColRtoCodigoCliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColRtoRazonSocial As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColRtoNroSucursal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColRtoDomicilio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColRtoLocalidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColRtoKgTotales As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColRtoCantTotalesInstalaciones As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BtnConsultar2 As System.Windows.Forms.Button
    Friend WithEvents ColRtoEstado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblInfo As System.Windows.Forms.Label
    Friend WithEvents CodCliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColRazonSocial As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColSucursal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColDomicilio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColLocalidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColNumContrato As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColFechaVencContrato As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColParqueTotal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colParqueVencidoManuales As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colParqueVencidoCarros As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colParqueVencidoMangueras As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colParqueAVencerManuales As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colParqueAVencerCarros As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colParqueAVencerMangueras As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColParqueAUnificar As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRetirado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colEntregado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColParqueVisitaMensual As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ColParqueControles As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ColMesVence As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColRemitoClienteSucursalABO As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colUnificacion As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
