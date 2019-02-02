<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AltaProspecto
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
        Me.btnSalir = New System.Windows.Forms.Button
        Me.btnRegistrar = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmbox = New System.Windows.Forms.ComboBox
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.txtboxNumeroDni = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.cmboxTipoDni = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.chkterceroPagador = New System.Windows.Forms.CheckBox
        Me.txtboxTercPagador = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtboxCodigo = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtboxNomFantasia = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtboxNombre = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.cmboxIVA = New System.Windows.Forms.ComboBox
        Me.Label32 = New System.Windows.Forms.Label
        Me.cmboxCondicionPago = New System.Windows.Forms.ComboBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.cmboxComision = New System.Windows.Forms.ComboBox
        Me.cmboxRep = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmboxFliaEst3 = New System.Windows.Forms.ComboBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.cmboxFliaEst2 = New System.Windows.Forms.ComboBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.cmboxFliaEst1 = New System.Windows.Forms.ComboBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.sucdefe = New System.Windows.Forms.CheckBox
        Me.Label31 = New System.Windows.Forms.Label
        Me.txtboxTrasporte = New System.Windows.Forms.TextBox
        Me.Label30 = New System.Windows.Forms.Label
        Me.txtboxTel = New System.Windows.Forms.TextBox
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.cmboxProvincia = New System.Windows.Forms.ComboBox
        Me.Label28 = New System.Windows.Forms.Label
        Me.txtboxCiudad = New System.Windows.Forms.TextBox
        Me.txtboxmail = New System.Windows.Forms.TextBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtboxCP = New System.Windows.Forms.TextBox
        Me.txtboxAltura = New System.Windows.Forms.TextBox
        Me.txtboxDireccion = New System.Windows.Forms.TextBox
        Me.txtboxNomSuc = New System.Windows.Forms.TextBox
        Me.txtboxSuc = New System.Windows.Forms.TextBox
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(360, 10)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(75, 23)
        Me.btnSalir.TabIndex = 13
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnRegistrar
        '
        Me.btnRegistrar.Location = New System.Drawing.Point(279, 10)
        Me.btnRegistrar.Name = "btnRegistrar"
        Me.btnRegistrar.Size = New System.Drawing.Size(75, 23)
        Me.btnRegistrar.TabIndex = 12
        Me.btnRegistrar.Tag = "Alta"
        Me.btnRegistrar.Text = "Registrar"
        Me.btnRegistrar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Tipo de Cliente"
        '
        'cmbox
        '
        Me.cmbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbox.FormattingEnabled = True
        Me.cmbox.Location = New System.Drawing.Point(93, 12)
        Me.cmbox.Name = "cmbox"
        Me.cmbox.Size = New System.Drawing.Size(180, 21)
        Me.cmbox.TabIndex = 11
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.txtboxNumeroDni)
        Me.GroupBox6.Controls.Add(Me.Label7)
        Me.GroupBox6.Controls.Add(Me.cmboxTipoDni)
        Me.GroupBox6.Controls.Add(Me.Label6)
        Me.GroupBox6.Controls.Add(Me.chkterceroPagador)
        Me.GroupBox6.Controls.Add(Me.txtboxTercPagador)
        Me.GroupBox6.Controls.Add(Me.Label5)
        Me.GroupBox6.Controls.Add(Me.txtboxCodigo)
        Me.GroupBox6.Controls.Add(Me.Label4)
        Me.GroupBox6.Controls.Add(Me.txtboxNomFantasia)
        Me.GroupBox6.Controls.Add(Me.Label3)
        Me.GroupBox6.Controls.Add(Me.txtboxNombre)
        Me.GroupBox6.Controls.Add(Me.Label2)
        Me.GroupBox6.Location = New System.Drawing.Point(12, 52)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(332, 189)
        Me.GroupBox6.TabIndex = 14
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Identidad"
        '
        'txtboxNumeroDni
        '
        Me.txtboxNumeroDni.Location = New System.Drawing.Point(161, 158)
        Me.txtboxNumeroDni.MaxLength = 11
        Me.txtboxNumeroDni.Name = "txtboxNumeroDni"
        Me.txtboxNumeroDni.Size = New System.Drawing.Size(156, 20)
        Me.txtboxNumeroDni.TabIndex = 12
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(34, 161)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(117, 13)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Numero de Documento"
        '
        'cmboxTipoDni
        '
        Me.cmboxTipoDni.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmboxTipoDni.FormattingEnabled = True
        Me.cmboxTipoDni.Location = New System.Drawing.Point(145, 131)
        Me.cmboxTipoDni.Name = "cmboxTipoDni"
        Me.cmboxTipoDni.Size = New System.Drawing.Size(100, 21)
        Me.cmboxTipoDni.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(34, 134)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(86, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Tipo Documento"
        '
        'chkterceroPagador
        '
        Me.chkterceroPagador.AutoSize = True
        Me.chkterceroPagador.Location = New System.Drawing.Point(13, 39)
        Me.chkterceroPagador.Name = "chkterceroPagador"
        Me.chkterceroPagador.Size = New System.Drawing.Size(15, 14)
        Me.chkterceroPagador.TabIndex = 2
        Me.chkterceroPagador.UseVisualStyleBackColor = True
        '
        'txtboxTercPagador
        '
        Me.txtboxTercPagador.Enabled = False
        Me.txtboxTercPagador.Location = New System.Drawing.Point(145, 36)
        Me.txtboxTercPagador.Name = "txtboxTercPagador"
        Me.txtboxTercPagador.Size = New System.Drawing.Size(100, 20)
        Me.txtboxTercPagador.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(33, 39)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(87, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Tercero Pagador"
        '
        'txtboxCodigo
        '
        Me.txtboxCodigo.Enabled = False
        Me.txtboxCodigo.Location = New System.Drawing.Point(145, 13)
        Me.txtboxCodigo.Name = "txtboxCodigo"
        Me.txtboxCodigo.Size = New System.Drawing.Size(100, 20)
        Me.txtboxCodigo.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(34, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Cod. Cliente"
        '
        'txtboxNomFantasia
        '
        Me.txtboxNomFantasia.Location = New System.Drawing.Point(145, 102)
        Me.txtboxNomFantasia.MaxLength = 35
        Me.txtboxNomFantasia.Name = "txtboxNomFantasia"
        Me.txtboxNomFantasia.Size = New System.Drawing.Size(172, 20)
        Me.txtboxNomFantasia.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(34, 105)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(105, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Nombre  de Fantasia"
        '
        'txtboxNombre
        '
        Me.txtboxNombre.Location = New System.Drawing.Point(145, 76)
        Me.txtboxNombre.MaxLength = 35
        Me.txtboxNombre.Name = "txtboxNombre"
        Me.txtboxNombre.Size = New System.Drawing.Size(100, 20)
        Me.txtboxNombre.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(34, 79)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Razon Social"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.cmboxIVA)
        Me.GroupBox5.Controls.Add(Me.Label32)
        Me.GroupBox5.Controls.Add(Me.cmboxCondicionPago)
        Me.GroupBox5.Controls.Add(Me.Label24)
        Me.GroupBox5.Location = New System.Drawing.Point(12, 345)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(297, 70)
        Me.GroupBox5.TabIndex = 16
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Financieras"
        '
        'cmboxIVA
        '
        Me.cmboxIVA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmboxIVA.FormattingEnabled = True
        Me.cmboxIVA.Location = New System.Drawing.Point(120, 45)
        Me.cmboxIVA.Name = "cmboxIVA"
        Me.cmboxIVA.Size = New System.Drawing.Size(167, 21)
        Me.cmboxIVA.TabIndex = 3
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(8, 48)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(76, 13)
        Me.Label32.TabIndex = 2
        Me.Label32.Text = "Reg. Impuesto"
        '
        'cmboxCondicionPago
        '
        Me.cmboxCondicionPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmboxCondicionPago.FormattingEnabled = True
        Me.cmboxCondicionPago.Location = New System.Drawing.Point(120, 18)
        Me.cmboxCondicionPago.Name = "cmboxCondicionPago"
        Me.cmboxCondicionPago.Size = New System.Drawing.Size(167, 21)
        Me.cmboxCondicionPago.TabIndex = 1
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(8, 21)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(96, 13)
        Me.Label24.TabIndex = 0
        Me.Label24.Text = "Condicion de pago"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.cmboxComision)
        Me.GroupBox2.Controls.Add(Me.cmboxRep)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 247)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(297, 90)
        Me.GroupBox2.TabIndex = 15
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Representante"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(8, 52)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(49, 13)
        Me.Label16.TabIndex = 2
        Me.Label16.Text = "Comision"
        '
        'cmboxComision
        '
        Me.cmboxComision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmboxComision.Enabled = False
        Me.cmboxComision.FormattingEnabled = True
        Me.cmboxComision.Location = New System.Drawing.Point(67, 49)
        Me.cmboxComision.Name = "cmboxComision"
        Me.cmboxComision.Size = New System.Drawing.Size(224, 21)
        Me.cmboxComision.TabIndex = 3
        '
        'cmboxRep
        '
        Me.cmboxRep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmboxRep.FormattingEnabled = True
        Me.cmboxRep.Location = New System.Drawing.Point(67, 19)
        Me.cmboxRep.Name = "cmboxRep"
        Me.cmboxRep.Size = New System.Drawing.Size(224, 21)
        Me.cmboxRep.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(8, 22)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(53, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Vendedor"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmboxFliaEst3)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.cmboxFliaEst2)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.cmboxFliaEst1)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Location = New System.Drawing.Point(360, 52)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(404, 108)
        Me.GroupBox1.TabIndex = 17
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Familia Estadistica"
        '
        'cmboxFliaEst3
        '
        Me.cmboxFliaEst3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmboxFliaEst3.FormattingEnabled = True
        Me.cmboxFliaEst3.Location = New System.Drawing.Point(142, 75)
        Me.cmboxFliaEst3.Name = "cmboxFliaEst3"
        Me.cmboxFliaEst3.Size = New System.Drawing.Size(193, 21)
        Me.cmboxFliaEst3.TabIndex = 5
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(34, 78)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(102, 13)
        Me.Label13.TabIndex = 4
        Me.Label13.Text = "Estadistica 3 Cliente"
        '
        'cmboxFliaEst2
        '
        Me.cmboxFliaEst2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmboxFliaEst2.FormattingEnabled = True
        Me.cmboxFliaEst2.Location = New System.Drawing.Point(142, 48)
        Me.cmboxFliaEst2.Name = "cmboxFliaEst2"
        Me.cmboxFliaEst2.Size = New System.Drawing.Size(193, 21)
        Me.cmboxFliaEst2.TabIndex = 3
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(34, 51)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(102, 13)
        Me.Label14.TabIndex = 2
        Me.Label14.Text = "Estadistica 2 Cliente"
        '
        'cmboxFliaEst1
        '
        Me.cmboxFliaEst1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmboxFliaEst1.FormattingEnabled = True
        Me.cmboxFliaEst1.ItemHeight = 13
        Me.cmboxFliaEst1.Location = New System.Drawing.Point(142, 21)
        Me.cmboxFliaEst1.Name = "cmboxFliaEst1"
        Me.cmboxFliaEst1.Size = New System.Drawing.Size(193, 21)
        Me.cmboxFliaEst1.TabIndex = 1
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(34, 24)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(102, 13)
        Me.Label15.TabIndex = 0
        Me.Label15.Text = "Estadistica 1 Cliente"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label31)
        Me.GroupBox3.Controls.Add(Me.txtboxTrasporte)
        Me.GroupBox3.Controls.Add(Me.Label30)
        Me.GroupBox3.Controls.Add(Me.txtboxTel)
        Me.GroupBox3.Controls.Add(Me.CheckBox1)
        Me.GroupBox3.Controls.Add(Me.cmboxProvincia)
        Me.GroupBox3.Controls.Add(Me.Label28)
        Me.GroupBox3.Controls.Add(Me.txtboxCiudad)
        Me.GroupBox3.Controls.Add(Me.txtboxmail)
        Me.GroupBox3.Controls.Add(Me.Label25)
        Me.GroupBox3.Controls.Add(Me.Label18)
        Me.GroupBox3.Controls.Add(Me.Label20)
        Me.GroupBox3.Controls.Add(Me.Label21)
        Me.GroupBox3.Controls.Add(Me.Label26)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Controls.Add(Me.txtboxCP)
        Me.GroupBox3.Controls.Add(Me.txtboxAltura)
        Me.GroupBox3.Controls.Add(Me.txtboxDireccion)
        Me.GroupBox3.Controls.Add(Me.txtboxNomSuc)
        Me.GroupBox3.Controls.Add(Me.txtboxSuc)
        Me.GroupBox3.Location = New System.Drawing.Point(360, 166)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(404, 198)
        Me.GroupBox3.TabIndex = 18
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Sucursal"
        '
        'sucdefe
        '
        Me.sucdefe.AutoSize = True
        Me.sucdefe.Checked = True
        Me.sucdefe.CheckState = System.Windows.Forms.CheckState.Checked
        Me.sucdefe.Location = New System.Drawing.Point(796, 421)
        Me.sucdefe.Name = "sucdefe"
        Me.sucdefe.Size = New System.Drawing.Size(15, 14)
        Me.sucdefe.TabIndex = 30
        Me.sucdefe.UseVisualStyleBackColor = True
        Me.sucdefe.Visible = False
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(7, 174)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(58, 13)
        Me.Label31.TabIndex = 28
        Me.Label31.Text = "Transporte"
        '
        'txtboxTrasporte
        '
        Me.txtboxTrasporte.Location = New System.Drawing.Point(108, 171)
        Me.txtboxTrasporte.MaxLength = 40
        Me.txtboxTrasporte.Name = "txtboxTrasporte"
        Me.txtboxTrasporte.Size = New System.Drawing.Size(212, 20)
        Me.txtboxTrasporte.TabIndex = 29
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(7, 148)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(77, 13)
        Me.Label30.TabIndex = 26
        Me.Label30.Text = "Telefono / Fax"
        '
        'txtboxTel
        '
        Me.txtboxTel.Location = New System.Drawing.Point(108, 145)
        Me.txtboxTel.MaxLength = 20
        Me.txtboxTel.Name = "txtboxTel"
        Me.txtboxTel.Size = New System.Drawing.Size(212, 20)
        Me.txtboxTel.TabIndex = 27
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(83, 19)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(15, 14)
        Me.CheckBox1.TabIndex = 1
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'cmboxProvincia
        '
        Me.cmboxProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmboxProvincia.FormattingEnabled = True
        Me.cmboxProvincia.Location = New System.Drawing.Point(107, 41)
        Me.cmboxProvincia.Name = "cmboxProvincia"
        Me.cmboxProvincia.Size = New System.Drawing.Size(200, 21)
        Me.cmboxProvincia.TabIndex = 11
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(7, 100)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(40, 13)
        Me.Label28.TabIndex = 12
        Me.Label28.Text = "Ciudad"
        '
        'txtboxCiudad
        '
        Me.txtboxCiudad.Location = New System.Drawing.Point(65, 97)
        Me.txtboxCiudad.Name = "txtboxCiudad"
        Me.txtboxCiudad.Size = New System.Drawing.Size(143, 20)
        Me.txtboxCiudad.TabIndex = 13
        '
        'txtboxmail
        '
        Me.txtboxmail.Location = New System.Drawing.Point(108, 120)
        Me.txtboxmail.Name = "txtboxmail"
        Me.txtboxmail.Size = New System.Drawing.Size(212, 20)
        Me.txtboxmail.TabIndex = 19
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(7, 123)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(61, 13)
        Me.Label25.TabIndex = 18
        Me.Label25.Text = "Mail Cliente"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(6, 44)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(95, 13)
        Me.Label18.TabIndex = 10
        Me.Label18.Text = "Estado / Provincia"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(213, 100)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(27, 13)
        Me.Label20.TabIndex = 14
        Me.Label20.Text = "C.P."
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(325, 75)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(34, 13)
        Me.Label21.TabIndex = 6
        Me.Label21.Text = "Altura"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(6, 75)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(99, 13)
        Me.Label26.TabIndex = 8
        Me.Label26.Text = "Direccion Completa"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(6, 22)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(73, 13)
        Me.Label17.TabIndex = 0
        Me.Label17.Text = "Cod. Sucursal"
        '
        'txtboxCP
        '
        Me.txtboxCP.Location = New System.Drawing.Point(246, 97)
        Me.txtboxCP.MaxLength = 6
        Me.txtboxCP.Name = "txtboxCP"
        Me.txtboxCP.Size = New System.Drawing.Size(74, 20)
        Me.txtboxCP.TabIndex = 15
        '
        'txtboxAltura
        '
        Me.txtboxAltura.Location = New System.Drawing.Point(358, 72)
        Me.txtboxAltura.MaxLength = 8
        Me.txtboxAltura.Name = "txtboxAltura"
        Me.txtboxAltura.Size = New System.Drawing.Size(40, 20)
        Me.txtboxAltura.TabIndex = 7
        '
        'txtboxDireccion
        '
        Me.txtboxDireccion.Location = New System.Drawing.Point(107, 72)
        Me.txtboxDireccion.Name = "txtboxDireccion"
        Me.txtboxDireccion.Size = New System.Drawing.Size(212, 20)
        Me.txtboxDireccion.TabIndex = 9
        '
        'txtboxNomSuc
        '
        Me.txtboxNomSuc.Enabled = False
        Me.txtboxNomSuc.Location = New System.Drawing.Point(169, 19)
        Me.txtboxNomSuc.Name = "txtboxNomSuc"
        Me.txtboxNomSuc.Size = New System.Drawing.Size(130, 20)
        Me.txtboxNomSuc.TabIndex = 3
        Me.txtboxNomSuc.Text = "PRINCIPAL"
        '
        'txtboxSuc
        '
        Me.txtboxSuc.Enabled = False
        Me.txtboxSuc.Location = New System.Drawing.Point(107, 19)
        Me.txtboxSuc.Name = "txtboxSuc"
        Me.txtboxSuc.Size = New System.Drawing.Size(48, 20)
        Me.txtboxSuc.TabIndex = 2
        Me.txtboxSuc.Text = "001"
        '
        'AltaProspecto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(780, 494)
        Me.Controls.Add(Me.sucdefe)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnRegistrar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbox)
        Me.Name = "AltaProspecto"
        Me.Text = "AltaProspecto"
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents btnRegistrar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbox As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents txtboxNumeroDni As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmboxTipoDni As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents chkterceroPagador As System.Windows.Forms.CheckBox
    Friend WithEvents txtboxTercPagador As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtboxCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtboxNomFantasia As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtboxNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents cmboxIVA As System.Windows.Forms.ComboBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents cmboxCondicionPago As System.Windows.Forms.ComboBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cmboxComision As System.Windows.Forms.ComboBox
    Friend WithEvents cmboxRep As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmboxFliaEst3 As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cmboxFliaEst2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cmboxFliaEst1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents sucdefe As System.Windows.Forms.CheckBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents txtboxTrasporte As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents txtboxTel As System.Windows.Forms.TextBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents cmboxProvincia As System.Windows.Forms.ComboBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txtboxCiudad As System.Windows.Forms.TextBox
    Friend WithEvents txtboxmail As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtboxCP As System.Windows.Forms.TextBox
    Friend WithEvents txtboxAltura As System.Windows.Forms.TextBox
    Friend WithEvents txtboxDireccion As System.Windows.Forms.TextBox
    Friend WithEvents txtboxNomSuc As System.Windows.Forms.TextBox
    Friend WithEvents txtboxSuc As System.Windows.Forms.TextBox
End Class
