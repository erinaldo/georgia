<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPremioRelevadores
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.cboRelevadores = New System.Windows.Forms.ComboBox
        Me.calendario = New System.Windows.Forms.MonthCalendar
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtDomRuteado = New System.Windows.Forms.TextBox
        Me.txtConRuta = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtPremioAbonar = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtCantContPremio = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtDomConforme = New System.Windows.Forms.TextBox
        Me.txtDomRebote = New System.Windows.Forms.TextBox
        Me.txtDomVisitado = New System.Windows.Forms.TextBox
        Me.txtRelevamientos = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtControles = New System.Windows.Forms.TextBox
        Me.txtRutPeriodo = New System.Windows.Forms.TextBox
        Me.txtPorcRebote = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtCumParcial = New System.Windows.Forms.TextBox
        Me.txtCliNoPresente = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtFalCooDomicilio = New System.Windows.Forms.TextBox
        Me.txtConDomicilio = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtVerVencimientos = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtCliNoAceRecibir = New System.Windows.Forms.TextBox
        Me.txtFalCumpLogisitico = New System.Windows.Forms.TextBox
        Me.txtFalCooPago = New System.Windows.Forms.TextBox
        Me.txtFalVerDom = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.btnCalcular = New System.Windows.Forms.Button
        Me.Label21 = New System.Windows.Forms.Label
        Me.txtboxdom = New System.Windows.Forms.TextBox
        Me.lblvalor = New System.Windows.Forms.Label
        Me.txtvalor = New System.Windows.Forms.TextBox
        Me.chkMoto = New System.Windows.Forms.CheckBox
        Me.btnReporte = New System.Windows.Forms.Button
        Me.dgv = New System.Windows.Forms.DataGridView
        Me.colFecha = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colIntervencion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCodigoCliente = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colRazonSocial = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colRuta = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colEquipos = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colEstado = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.colNoConforme = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.colItemRef = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colAcomp1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colAcomp2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colSuc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cboRelevadores
        '
        Me.cboRelevadores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRelevadores.FormattingEnabled = True
        Me.cboRelevadores.Location = New System.Drawing.Point(16, 12)
        Me.cboRelevadores.Name = "cboRelevadores"
        Me.cboRelevadores.Size = New System.Drawing.Size(227, 21)
        Me.cboRelevadores.TabIndex = 0
        '
        'calendario
        '
        Me.calendario.Location = New System.Drawing.Point(16, 45)
        Me.calendario.MaxSelectionCount = 31
        Me.calendario.Name = "calendario"
        Me.calendario.ShowToday = False
        Me.calendario.ShowTodayCircle = False
        Me.calendario.TabIndex = 42
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(312, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Domicilio rebote"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(22, 73)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Domicilio visitado"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(22, 99)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Domicilio conforme"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(138, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Total de domicilios ruteados"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(22, 151)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(80, 13)
        Me.Label17.TabIndex = 17
        Me.Label17.Text = "Controles / ruta"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(22, 177)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(107, 13)
        Me.Label18.TabIndex = 18
        Me.Label18.Text = "Controles / domicilios"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(22, 229)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(118, 13)
        Me.Label19.TabIndex = 19
        Me.Label19.Text = "Cantidad control premio"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(22, 255)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(84, 13)
        Me.Label20.TabIndex = 20
        Me.Label20.Text = "Premio a abonar"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(22, 203)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(77, 13)
        Me.Label13.TabIndex = 13
        Me.Label13.Text = "Relevamientos"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(22, 21)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(91, 13)
        Me.Label14.TabIndex = 14
        Me.Label14.Text = "Equipos controles"
        '
        'txtDomRuteado
        '
        Me.txtDomRuteado.Location = New System.Drawing.Point(166, 44)
        Me.txtDomRuteado.Name = "txtDomRuteado"
        Me.txtDomRuteado.ReadOnly = True
        Me.txtDomRuteado.Size = New System.Drawing.Size(100, 20)
        Me.txtDomRuteado.TabIndex = 43
        Me.txtDomRuteado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtConRuta
        '
        Me.txtConRuta.Location = New System.Drawing.Point(166, 148)
        Me.txtConRuta.Name = "txtConRuta"
        Me.txtConRuta.ReadOnly = True
        Me.txtConRuta.Size = New System.Drawing.Size(100, 20)
        Me.txtConRuta.TabIndex = 44
        Me.txtConRuta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(312, 73)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(87, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Cumplido parcial "
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(22, 125)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(99, 13)
        Me.Label15.TabIndex = 15
        Me.Label15.Text = "Rutas en el periodo"
        '
        'txtPremioAbonar
        '
        Me.txtPremioAbonar.Location = New System.Drawing.Point(166, 252)
        Me.txtPremioAbonar.Name = "txtPremioAbonar"
        Me.txtPremioAbonar.ReadOnly = True
        Me.txtPremioAbonar.Size = New System.Drawing.Size(100, 20)
        Me.txtPremioAbonar.TabIndex = 55
        Me.txtPremioAbonar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(312, 99)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(98, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Cliente no presente"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(312, 47)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(111, 13)
        Me.Label16.TabIndex = 16
        Me.Label16.Text = "Porcentaje de rebotes"
        '
        'txtCantContPremio
        '
        Me.txtCantContPremio.Location = New System.Drawing.Point(166, 226)
        Me.txtCantContPremio.Name = "txtCantContPremio"
        Me.txtCantContPremio.ReadOnly = True
        Me.txtCantContPremio.Size = New System.Drawing.Size(100, 20)
        Me.txtCantContPremio.TabIndex = 56
        Me.txtCantContPremio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(312, 125)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(111, 13)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Falta coordinar cliente"
        '
        'txtDomConforme
        '
        Me.txtDomConforme.Location = New System.Drawing.Point(166, 96)
        Me.txtDomConforme.Name = "txtDomConforme"
        Me.txtDomConforme.ReadOnly = True
        Me.txtDomConforme.Size = New System.Drawing.Size(100, 20)
        Me.txtDomConforme.TabIndex = 54
        Me.txtDomConforme.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtDomRebote
        '
        Me.txtDomRebote.Location = New System.Drawing.Point(456, 18)
        Me.txtDomRebote.Name = "txtDomRebote"
        Me.txtDomRebote.ReadOnly = True
        Me.txtDomRebote.Size = New System.Drawing.Size(100, 20)
        Me.txtDomRebote.TabIndex = 53
        Me.txtDomRebote.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtDomVisitado
        '
        Me.txtDomVisitado.Location = New System.Drawing.Point(166, 70)
        Me.txtDomVisitado.Name = "txtDomVisitado"
        Me.txtDomVisitado.ReadOnly = True
        Me.txtDomVisitado.Size = New System.Drawing.Size(100, 20)
        Me.txtDomVisitado.TabIndex = 52
        Me.txtDomVisitado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtRelevamientos
        '
        Me.txtRelevamientos.Location = New System.Drawing.Point(166, 200)
        Me.txtRelevamientos.Name = "txtRelevamientos"
        Me.txtRelevamientos.ReadOnly = True
        Me.txtRelevamientos.Size = New System.Drawing.Size(100, 20)
        Me.txtRelevamientos.TabIndex = 51
        Me.txtRelevamientos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(312, 151)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(110, 13)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "falta verificar domicilio"
        '
        'txtControles
        '
        Me.txtControles.Location = New System.Drawing.Point(166, 18)
        Me.txtControles.Name = "txtControles"
        Me.txtControles.ReadOnly = True
        Me.txtControles.Size = New System.Drawing.Size(100, 20)
        Me.txtControles.TabIndex = 50
        Me.txtControles.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtRutPeriodo
        '
        Me.txtRutPeriodo.Location = New System.Drawing.Point(166, 122)
        Me.txtRutPeriodo.Name = "txtRutPeriodo"
        Me.txtRutPeriodo.ReadOnly = True
        Me.txtRutPeriodo.Size = New System.Drawing.Size(100, 20)
        Me.txtRutPeriodo.TabIndex = 49
        Me.txtRutPeriodo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtPorcRebote
        '
        Me.txtPorcRebote.Location = New System.Drawing.Point(456, 44)
        Me.txtPorcRebote.Name = "txtPorcRebote"
        Me.txtPorcRebote.ReadOnly = True
        Me.txtPorcRebote.Size = New System.Drawing.Size(100, 20)
        Me.txtPorcRebote.TabIndex = 48
        Me.txtPorcRebote.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(312, 177)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(104, 13)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "Falta coordinar pago"
        '
        'txtCumParcial
        '
        Me.txtCumParcial.Location = New System.Drawing.Point(456, 70)
        Me.txtCumParcial.Name = "txtCumParcial"
        Me.txtCumParcial.ReadOnly = True
        Me.txtCumParcial.Size = New System.Drawing.Size(100, 20)
        Me.txtCumParcial.TabIndex = 47
        Me.txtCumParcial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtCliNoPresente
        '
        Me.txtCliNoPresente.Location = New System.Drawing.Point(456, 96)
        Me.txtCliNoPresente.Name = "txtCliNoPresente"
        Me.txtCliNoPresente.ReadOnly = True
        Me.txtCliNoPresente.Size = New System.Drawing.Size(100, 20)
        Me.txtCliNoPresente.TabIndex = 46
        Me.txtCliNoPresente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(312, 203)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(114, 13)
        Me.Label10.TabIndex = 10
        Me.Label10.Text = "Falta cumplimiento log."
        '
        'txtFalCooDomicilio
        '
        Me.txtFalCooDomicilio.Location = New System.Drawing.Point(456, 122)
        Me.txtFalCooDomicilio.Name = "txtFalCooDomicilio"
        Me.txtFalCooDomicilio.ReadOnly = True
        Me.txtFalCooDomicilio.Size = New System.Drawing.Size(100, 20)
        Me.txtFalCooDomicilio.TabIndex = 45
        Me.txtFalCooDomicilio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtConDomicilio
        '
        Me.txtConDomicilio.Location = New System.Drawing.Point(166, 174)
        Me.txtConDomicilio.Name = "txtConDomicilio"
        Me.txtConDomicilio.ReadOnly = True
        Me.txtConDomicilio.Size = New System.Drawing.Size(100, 20)
        Me.txtConDomicilio.TabIndex = 57
        Me.txtConDomicilio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(312, 229)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(121, 13)
        Me.Label11.TabIndex = 11
        Me.Label11.Text = "Cliente no acepta recibir"
        '
        'txtVerVencimientos
        '
        Me.txtVerVencimientos.Location = New System.Drawing.Point(456, 252)
        Me.txtVerVencimientos.Name = "txtVerVencimientos"
        Me.txtVerVencimientos.ReadOnly = True
        Me.txtVerVencimientos.Size = New System.Drawing.Size(100, 20)
        Me.txtVerVencimientos.TabIndex = 58
        Me.txtVerVencimientos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(312, 255)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(110, 13)
        Me.Label12.TabIndex = 12
        Me.Label12.Text = "Verificar vencimientos"
        '
        'txtCliNoAceRecibir
        '
        Me.txtCliNoAceRecibir.Location = New System.Drawing.Point(456, 226)
        Me.txtCliNoAceRecibir.Name = "txtCliNoAceRecibir"
        Me.txtCliNoAceRecibir.ReadOnly = True
        Me.txtCliNoAceRecibir.Size = New System.Drawing.Size(100, 20)
        Me.txtCliNoAceRecibir.TabIndex = 59
        Me.txtCliNoAceRecibir.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtFalCumpLogisitico
        '
        Me.txtFalCumpLogisitico.Location = New System.Drawing.Point(456, 200)
        Me.txtFalCumpLogisitico.Name = "txtFalCumpLogisitico"
        Me.txtFalCumpLogisitico.ReadOnly = True
        Me.txtFalCumpLogisitico.Size = New System.Drawing.Size(100, 20)
        Me.txtFalCumpLogisitico.TabIndex = 60
        Me.txtFalCumpLogisitico.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtFalCooPago
        '
        Me.txtFalCooPago.Location = New System.Drawing.Point(456, 174)
        Me.txtFalCooPago.Name = "txtFalCooPago"
        Me.txtFalCooPago.ReadOnly = True
        Me.txtFalCooPago.Size = New System.Drawing.Size(100, 20)
        Me.txtFalCooPago.TabIndex = 61
        Me.txtFalCooPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtFalVerDom
        '
        Me.txtFalVerDom.Location = New System.Drawing.Point(456, 148)
        Me.txtFalVerDom.Name = "txtFalVerDom"
        Me.txtFalVerDom.ReadOnly = True
        Me.txtFalVerDom.Size = New System.Drawing.Size(100, 20)
        Me.txtFalVerDom.TabIndex = 62
        Me.txtFalVerDom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtFalVerDom)
        Me.GroupBox1.Controls.Add(Me.txtFalCooPago)
        Me.GroupBox1.Controls.Add(Me.txtFalCumpLogisitico)
        Me.GroupBox1.Controls.Add(Me.txtCliNoAceRecibir)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.txtVerVencimientos)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.txtConDomicilio)
        Me.GroupBox1.Controls.Add(Me.txtFalCooDomicilio)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.txtCliNoPresente)
        Me.GroupBox1.Controls.Add(Me.txtCumParcial)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtPorcRebote)
        Me.GroupBox1.Controls.Add(Me.txtRutPeriodo)
        Me.GroupBox1.Controls.Add(Me.txtControles)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtRelevamientos)
        Me.GroupBox1.Controls.Add(Me.txtDomVisitado)
        Me.GroupBox1.Controls.Add(Me.txtDomRebote)
        Me.GroupBox1.Controls.Add(Me.txtDomConforme)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtCantContPremio)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtPremioAbonar)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtConRuta)
        Me.GroupBox1.Controls.Add(Me.txtDomRuteado)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(269, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(607, 286)
        Me.GroupBox1.TabIndex = 58
        Me.GroupBox1.TabStop = False
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnCalcular)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label21)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtboxdom)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblvalor)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtvalor)
        Me.SplitContainer1.Panel1.Controls.Add(Me.chkMoto)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnReporte)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.calendario)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cboRelevadores)
        Me.SplitContainer1.Panel1.Tag = ""
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgv)
        Me.SplitContainer1.Size = New System.Drawing.Size(897, 492)
        Me.SplitContainer1.SplitterDistance = 303
        Me.SplitContainer1.TabIndex = 59
        '
        'btnCalcular
        '
        Me.btnCalcular.Location = New System.Drawing.Point(16, 219)
        Me.btnCalcular.Name = "btnCalcular"
        Me.btnCalcular.Size = New System.Drawing.Size(121, 23)
        Me.btnCalcular.TabIndex = 65
        Me.btnCalcular.Text = "Calcular"
        Me.btnCalcular.UseVisualStyleBackColor = True
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(149, 272)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(32, 13)
        Me.Label21.TabIndex = 64
        Me.Label21.Text = "Dom."
        '
        'txtboxdom
        '
        Me.txtboxdom.Location = New System.Drawing.Point(195, 272)
        Me.txtboxdom.Name = "txtboxdom"
        Me.txtboxdom.Size = New System.Drawing.Size(48, 20)
        Me.txtboxdom.TabIndex = 63
        Me.txtboxdom.Text = "3.71"
        '
        'lblvalor
        '
        Me.lblvalor.AutoSize = True
        Me.lblvalor.Location = New System.Drawing.Point(149, 246)
        Me.lblvalor.Name = "lblvalor"
        Me.lblvalor.Size = New System.Drawing.Size(31, 13)
        Me.lblvalor.TabIndex = 62
        Me.lblvalor.Text = "Valor"
        '
        'txtvalor
        '
        Me.txtvalor.Location = New System.Drawing.Point(195, 246)
        Me.txtvalor.Name = "txtvalor"
        Me.txtvalor.Size = New System.Drawing.Size(48, 20)
        Me.txtvalor.TabIndex = 61
        Me.txtvalor.Text = "1.07"
        '
        'chkMoto
        '
        Me.chkMoto.AutoSize = True
        Me.chkMoto.Location = New System.Drawing.Point(152, 223)
        Me.chkMoto.Name = "chkMoto"
        Me.chkMoto.Size = New System.Drawing.Size(50, 17)
        Me.chkMoto.TabIndex = 60
        Me.chkMoto.Text = "Moto"
        Me.chkMoto.UseVisualStyleBackColor = True
        '
        'btnReporte
        '
        Me.btnReporte.Enabled = False
        Me.btnReporte.Location = New System.Drawing.Point(16, 248)
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Size = New System.Drawing.Size(121, 23)
        Me.btnReporte.TabIndex = 59
        Me.btnReporte.Text = "Reporte"
        Me.btnReporte.UseVisualStyleBackColor = True
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colFecha, Me.colIntervencion, Me.colCodigoCliente, Me.colRazonSocial, Me.colRuta, Me.colEquipos, Me.colEstado, Me.colNoConforme, Me.colItemRef, Me.colAcomp1, Me.colAcomp2, Me.colSuc})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv.Location = New System.Drawing.Point(0, 0)
        Me.dgv.Name = "dgv"
        Me.dgv.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv.Size = New System.Drawing.Size(897, 185)
        Me.dgv.TabIndex = 0
        '
        'colFecha
        '
        Me.colFecha.HeaderText = "Fecha"
        Me.colFecha.Name = "colFecha"
        Me.colFecha.ReadOnly = True
        '
        'colIntervencion
        '
        Me.colIntervencion.HeaderText = "Intervencion"
        Me.colIntervencion.Name = "colIntervencion"
        Me.colIntervencion.ReadOnly = True
        '
        'colCodigoCliente
        '
        Me.colCodigoCliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.colCodigoCliente.HeaderText = "Codigo"
        Me.colCodigoCliente.Name = "colCodigoCliente"
        Me.colCodigoCliente.ReadOnly = True
        Me.colCodigoCliente.Width = 65
        '
        'colRazonSocial
        '
        Me.colRazonSocial.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.colRazonSocial.HeaderText = "Razon Social"
        Me.colRazonSocial.Name = "colRazonSocial"
        Me.colRazonSocial.ReadOnly = True
        Me.colRazonSocial.Width = 95
        '
        'colRuta
        '
        Me.colRuta.HeaderText = "Ruta"
        Me.colRuta.Name = "colRuta"
        Me.colRuta.ReadOnly = True
        '
        'colEquipos
        '
        Me.colEquipos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.colEquipos.HeaderText = "Equipos"
        Me.colEquipos.Name = "colEquipos"
        Me.colEquipos.ReadOnly = True
        Me.colEquipos.Width = 70
        '
        'colEstado
        '
        Me.colEstado.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.colEstado.HeaderText = "Estado"
        Me.colEstado.Name = "colEstado"
        Me.colEstado.ReadOnly = True
        Me.colEstado.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colEstado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'colNoConforme
        '
        Me.colNoConforme.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.colNoConforme.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.colNoConforme.HeaderText = "No Conforme"
        Me.colNoConforme.Name = "colNoConforme"
        Me.colNoConforme.ReadOnly = True
        Me.colNoConforme.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colNoConforme.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colNoConforme.Width = 94
        '
        'colItemRef
        '
        Me.colItemRef.HeaderText = "Item"
        Me.colItemRef.Name = "colItemRef"
        Me.colItemRef.ReadOnly = True
        '
        'colAcomp1
        '
        Me.colAcomp1.HeaderText = "Acomp1"
        Me.colAcomp1.Name = "colAcomp1"
        Me.colAcomp1.ReadOnly = True
        Me.colAcomp1.Visible = False
        '
        'colAcomp2
        '
        Me.colAcomp2.HeaderText = "Acomp2"
        Me.colAcomp2.Name = "colAcomp2"
        Me.colAcomp2.ReadOnly = True
        Me.colAcomp2.Visible = False
        '
        'colSuc
        '
        Me.colSuc.HeaderText = "Suc"
        Me.colSuc.Name = "colSuc"
        Me.colSuc.ReadOnly = True
        Me.colSuc.Visible = False
        '
        'frmPremioRelevadores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(897, 492)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "frmPremioRelevadores"
        Me.Tag = "frmpremio"
        Me.Text = "PremioRelevadores"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cboRelevadores As System.Windows.Forms.ComboBox
    Friend WithEvents calendario As System.Windows.Forms.MonthCalendar
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtDomRuteado As System.Windows.Forms.TextBox
    Friend WithEvents txtConRuta As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtPremioAbonar As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtCantContPremio As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtDomConforme As System.Windows.Forms.TextBox
    Friend WithEvents txtDomRebote As System.Windows.Forms.TextBox
    Friend WithEvents txtDomVisitado As System.Windows.Forms.TextBox
    Friend WithEvents txtRelevamientos As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtControles As System.Windows.Forms.TextBox
    Friend WithEvents txtRutPeriodo As System.Windows.Forms.TextBox
    Friend WithEvents txtPorcRebote As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtCumParcial As System.Windows.Forms.TextBox
    Friend WithEvents txtCliNoPresente As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtFalCooDomicilio As System.Windows.Forms.TextBox
    Friend WithEvents txtConDomicilio As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtVerVencimientos As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtCliNoAceRecibir As System.Windows.Forms.TextBox
    Friend WithEvents txtFalCumpLogisitico As System.Windows.Forms.TextBox
    Friend WithEvents txtFalCooPago As System.Windows.Forms.TextBox
    Friend WithEvents txtFalVerDom As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents btnReporte As System.Windows.Forms.Button
    Friend WithEvents lblvalor As System.Windows.Forms.Label
    Friend WithEvents txtvalor As System.Windows.Forms.TextBox
    Friend WithEvents chkMoto As System.Windows.Forms.CheckBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtboxdom As System.Windows.Forms.TextBox
    Friend WithEvents btnCalcular As System.Windows.Forms.Button
    Friend WithEvents colFecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIntervencion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCodigoCliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRazonSocial As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRuta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colEquipos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colEstado As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colNoConforme As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colItemRef As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAcomp1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAcomp2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSuc As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
