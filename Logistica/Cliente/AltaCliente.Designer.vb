﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AltaCliente
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
        Dim Label3 As System.Windows.Forms.Label
        Dim Label4 As System.Windows.Forms.Label
        Dim Label5 As System.Windows.Forms.Label
        Dim Label6 As System.Windows.Forms.Label
        Dim Label7 As System.Windows.Forms.Label
        Dim Label13 As System.Windows.Forms.Label
        Dim Label14 As System.Windows.Forms.Label
        Dim Label15 As System.Windows.Forms.Label
        Dim Label24 As System.Windows.Forms.Label
        Dim Label8 As System.Windows.Forms.Label
        Dim Label32 As System.Windows.Forms.Label
        Dim Label1 As System.Windows.Forms.Label
        Me.txtNombre = New System.Windows.Forms.TextBox
        Me.txtFantasia = New System.Windows.Forms.TextBox
        Me.txtCodigoCliente = New System.Windows.Forms.TextBox
        Me.txtCodigoPagador = New System.Windows.Forms.TextBox
        Me.cboTipoDoc = New System.Windows.Forms.ComboBox
        Me.txtNumDoc = New System.Windows.Forms.TextBox
        Me.cboFamilia3 = New System.Windows.Forms.ComboBox
        Me.cboFamilia2 = New System.Windows.Forms.ComboBox
        Me.cboFamilia1 = New System.Windows.Forms.ComboBox
        Me.gbFamilias = New System.Windows.Forms.GroupBox
        Me.btnRegistrar = New System.Windows.Forms.Button
        Me.cboCondicionPago = New System.Windows.Forms.ComboBox
        Me.gbRepresentante = New System.Windows.Forms.GroupBox
        Me.cboVendedor = New System.Windows.Forms.ComboBox
        Me.gbFinancieras = New System.Windows.Forms.GroupBox
        Me.chkRequiereFactura = New System.Windows.Forms.CheckBox
        Me.txtMailFc = New System.Windows.Forms.TextBox
        Me.cboIva = New System.Windows.Forms.ComboBox
        Me.gbIdentidad = New System.Windows.Forms.GroupBox
        Me.txtNombrePagador = New System.Windows.Forms.TextBox
        Me.btnProponer = New System.Windows.Forms.Button
        Me.cboCondicionIb = New System.Windows.Forms.ComboBox
        Me.txtIIBB = New System.Windows.Forms.TextBox
        Me.txtObservaciones = New System.Windows.Forms.TextBox
        Me.gbObservaciones = New System.Windows.Forms.GroupBox
        Me.gbSucursales = New System.Windows.Forms.GroupBox
        Me.btnEditarSucursal = New System.Windows.Forms.Button
        Me.btnAgregarSucursal = New System.Windows.Forms.Button
        Me.dgv = New System.Windows.Forms.DataGridView
        Me.btnSalir = New System.Windows.Forms.Button
        Me.gbFiscal = New System.Windows.Forms.GroupBox
        Label2 = New System.Windows.Forms.Label
        Label3 = New System.Windows.Forms.Label
        Label4 = New System.Windows.Forms.Label
        Label5 = New System.Windows.Forms.Label
        Label6 = New System.Windows.Forms.Label
        Label7 = New System.Windows.Forms.Label
        Label13 = New System.Windows.Forms.Label
        Label14 = New System.Windows.Forms.Label
        Label15 = New System.Windows.Forms.Label
        Label24 = New System.Windows.Forms.Label
        Label8 = New System.Windows.Forms.Label
        Label32 = New System.Windows.Forms.Label
        Label1 = New System.Windows.Forms.Label
        Me.gbFamilias.SuspendLayout()
        Me.gbRepresentante.SuspendLayout()
        Me.gbFinancieras.SuspendLayout()
        Me.gbIdentidad.SuspendLayout()
        Me.gbObservaciones.SuspendLayout()
        Me.gbSucursales.SuspendLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbFiscal.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Location = New System.Drawing.Point(6, 72)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(70, 13)
        Label2.TabIndex = 6
        Label2.Text = "Razon Social"
        '
        'Label3
        '
        Label3.AutoSize = True
        Label3.Location = New System.Drawing.Point(6, 98)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(105, 13)
        Label3.TabIndex = 8
        Label3.Text = "Nombre  de Fantasia"
        '
        'Label4
        '
        Label4.AutoSize = True
        Label4.Location = New System.Drawing.Point(6, 20)
        Label4.Name = "Label4"
        Label4.Size = New System.Drawing.Size(64, 13)
        Label4.TabIndex = 0
        Label4.Text = "Cod. Cliente"
        '
        'Label5
        '
        Label5.AutoSize = True
        Label5.Location = New System.Drawing.Point(6, 46)
        Label5.Name = "Label5"
        Label5.Size = New System.Drawing.Size(87, 13)
        Label5.TabIndex = 3
        Label5.Text = "Tercero Pagador"
        '
        'Label6
        '
        Label6.AutoSize = True
        Label6.Location = New System.Drawing.Point(6, 22)
        Label6.Name = "Label6"
        Label6.Size = New System.Drawing.Size(86, 13)
        Label6.TabIndex = 0
        Label6.Text = "Tipo Documento"
        '
        'Label7
        '
        Label7.AutoSize = True
        Label7.Location = New System.Drawing.Point(6, 49)
        Label7.Name = "Label7"
        Label7.Size = New System.Drawing.Size(27, 13)
        Label7.TabIndex = 3
        Label7.Text = "IIBB"
        '
        'Label13
        '
        Label13.AutoSize = True
        Label13.Location = New System.Drawing.Point(6, 76)
        Label13.Name = "Label13"
        Label13.Size = New System.Drawing.Size(66, 13)
        Label13.TabIndex = 4
        Label13.Text = "Est 3 Cliente"
        '
        'Label14
        '
        Label14.AutoSize = True
        Label14.Location = New System.Drawing.Point(6, 49)
        Label14.Name = "Label14"
        Label14.Size = New System.Drawing.Size(66, 13)
        Label14.TabIndex = 2
        Label14.Text = "Est 2 Cliente"
        '
        'Label15
        '
        Label15.AutoSize = True
        Label15.Location = New System.Drawing.Point(6, 22)
        Label15.Name = "Label15"
        Label15.Size = New System.Drawing.Size(66, 13)
        Label15.TabIndex = 0
        Label15.Text = "Est 1 Cliente"
        '
        'Label24
        '
        Label24.AutoSize = True
        Label24.Location = New System.Drawing.Point(8, 21)
        Label24.Name = "Label24"
        Label24.Size = New System.Drawing.Size(96, 13)
        Label24.TabIndex = 0
        Label24.Text = "Condicion de pago"
        '
        'Label8
        '
        Label8.AutoSize = True
        Label8.Location = New System.Drawing.Point(8, 26)
        Label8.Name = "Label8"
        Label8.Size = New System.Drawing.Size(53, 13)
        Label8.TabIndex = 0
        Label8.Text = "Vendedor"
        '
        'Label32
        '
        Label32.AutoSize = True
        Label32.Location = New System.Drawing.Point(8, 48)
        Label32.Name = "Label32"
        Label32.Size = New System.Drawing.Size(76, 13)
        Label32.TabIndex = 2
        Label32.Text = "Reg. Impuesto"
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(8, 79)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(81, 13)
        Label1.TabIndex = 4
        Label1.Text = "Mail envío Fact"
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(123, 69)
        Me.txtNombre.MaxLength = 35
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(207, 20)
        Me.txtNombre.TabIndex = 7
        '
        'txtFantasia
        '
        Me.txtFantasia.Location = New System.Drawing.Point(123, 95)
        Me.txtFantasia.MaxLength = 35
        Me.txtFantasia.Name = "txtFantasia"
        Me.txtFantasia.Size = New System.Drawing.Size(207, 20)
        Me.txtFantasia.TabIndex = 9
        '
        'txtCodigoCliente
        '
        Me.txtCodigoCliente.Location = New System.Drawing.Point(123, 17)
        Me.txtCodigoCliente.MaxLength = 6
        Me.txtCodigoCliente.Name = "txtCodigoCliente"
        Me.txtCodigoCliente.Size = New System.Drawing.Size(51, 20)
        Me.txtCodigoCliente.TabIndex = 1
        '
        'txtCodigoPagador
        '
        Me.txtCodigoPagador.Location = New System.Drawing.Point(123, 43)
        Me.txtCodigoPagador.MaxLength = 6
        Me.txtCodigoPagador.Name = "txtCodigoPagador"
        Me.txtCodigoPagador.Size = New System.Drawing.Size(51, 20)
        Me.txtCodigoPagador.TabIndex = 4
        '
        'cboTipoDoc
        '
        Me.cboTipoDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoDoc.FormattingEnabled = True
        Me.cboTipoDoc.Location = New System.Drawing.Point(123, 19)
        Me.cboTipoDoc.Name = "cboTipoDoc"
        Me.cboTipoDoc.Size = New System.Drawing.Size(114, 21)
        Me.cboTipoDoc.TabIndex = 1
        '
        'txtNumDoc
        '
        Me.txtNumDoc.Location = New System.Drawing.Point(243, 19)
        Me.txtNumDoc.MaxLength = 11
        Me.txtNumDoc.Name = "txtNumDoc"
        Me.txtNumDoc.Size = New System.Drawing.Size(84, 20)
        Me.txtNumDoc.TabIndex = 2
        '
        'cboFamilia3
        '
        Me.cboFamilia3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFamilia3.FormattingEnabled = True
        Me.cboFamilia3.Location = New System.Drawing.Point(123, 73)
        Me.cboFamilia3.Name = "cboFamilia3"
        Me.cboFamilia3.Size = New System.Drawing.Size(207, 21)
        Me.cboFamilia3.TabIndex = 5
        '
        'cboFamilia2
        '
        Me.cboFamilia2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFamilia2.FormattingEnabled = True
        Me.cboFamilia2.Location = New System.Drawing.Point(123, 46)
        Me.cboFamilia2.Name = "cboFamilia2"
        Me.cboFamilia2.Size = New System.Drawing.Size(207, 21)
        Me.cboFamilia2.TabIndex = 3
        '
        'cboFamilia1
        '
        Me.cboFamilia1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFamilia1.FormattingEnabled = True
        Me.cboFamilia1.ItemHeight = 13
        Me.cboFamilia1.Location = New System.Drawing.Point(123, 19)
        Me.cboFamilia1.Name = "cboFamilia1"
        Me.cboFamilia1.Size = New System.Drawing.Size(207, 21)
        Me.cboFamilia1.TabIndex = 1
        '
        'gbFamilias
        '
        Me.gbFamilias.Controls.Add(Me.cboFamilia3)
        Me.gbFamilias.Controls.Add(Label13)
        Me.gbFamilias.Controls.Add(Me.cboFamilia2)
        Me.gbFamilias.Controls.Add(Label14)
        Me.gbFamilias.Controls.Add(Me.cboFamilia1)
        Me.gbFamilias.Controls.Add(Label15)
        Me.gbFamilias.Location = New System.Drawing.Point(12, 12)
        Me.gbFamilias.Name = "gbFamilias"
        Me.gbFamilias.Size = New System.Drawing.Size(336, 108)
        Me.gbFamilias.TabIndex = 0
        Me.gbFamilias.TabStop = False
        Me.gbFamilias.Text = "Familia Estadistica"
        '
        'btnRegistrar
        '
        Me.btnRegistrar.Location = New System.Drawing.Point(828, 484)
        Me.btnRegistrar.Name = "btnRegistrar"
        Me.btnRegistrar.Size = New System.Drawing.Size(75, 23)
        Me.btnRegistrar.TabIndex = 7
        Me.btnRegistrar.Tag = "Alta"
        Me.btnRegistrar.Text = "Registrar"
        Me.btnRegistrar.UseVisualStyleBackColor = True
        '
        'cboCondicionPago
        '
        Me.cboCondicionPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCondicionPago.FormattingEnabled = True
        Me.cboCondicionPago.Location = New System.Drawing.Point(123, 18)
        Me.cboCondicionPago.Name = "cboCondicionPago"
        Me.cboCondicionPago.Size = New System.Drawing.Size(204, 21)
        Me.cboCondicionPago.TabIndex = 1
        '
        'gbRepresentante
        '
        Me.gbRepresentante.Controls.Add(Me.cboVendedor)
        Me.gbRepresentante.Controls.Add(Label8)
        Me.gbRepresentante.Location = New System.Drawing.Point(354, 388)
        Me.gbRepresentante.Name = "gbRepresentante"
        Me.gbRepresentante.Size = New System.Drawing.Size(300, 88)
        Me.gbRepresentante.TabIndex = 5
        Me.gbRepresentante.TabStop = False
        Me.gbRepresentante.Text = "Representante"
        '
        'cboVendedor
        '
        Me.cboVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVendedor.FormattingEnabled = True
        Me.cboVendedor.Location = New System.Drawing.Point(87, 23)
        Me.cboVendedor.Name = "cboVendedor"
        Me.cboVendedor.Size = New System.Drawing.Size(204, 21)
        Me.cboVendedor.TabIndex = 1
        '
        'gbFinancieras
        '
        Me.gbFinancieras.Controls.Add(Me.chkRequiereFactura)
        Me.gbFinancieras.Controls.Add(Me.txtMailFc)
        Me.gbFinancieras.Controls.Add(Label1)
        Me.gbFinancieras.Controls.Add(Me.cboIva)
        Me.gbFinancieras.Controls.Add(Label32)
        Me.gbFinancieras.Controls.Add(Me.cboCondicionPago)
        Me.gbFinancieras.Controls.Add(Label24)
        Me.gbFinancieras.Location = New System.Drawing.Point(12, 340)
        Me.gbFinancieras.Name = "gbFinancieras"
        Me.gbFinancieras.Size = New System.Drawing.Size(336, 136)
        Me.gbFinancieras.TabIndex = 3
        Me.gbFinancieras.TabStop = False
        Me.gbFinancieras.Text = "Financieras"
        '
        'chkRequiereFactura
        '
        Me.chkRequiereFactura.AutoSize = True
        Me.chkRequiereFactura.Location = New System.Drawing.Point(123, 103)
        Me.chkRequiereFactura.Name = "chkRequiereFactura"
        Me.chkRequiereFactura.Size = New System.Drawing.Size(140, 17)
        Me.chkRequiereFactura.TabIndex = 6
        Me.chkRequiereFactura.Text = "Requiere Factura Física"
        Me.chkRequiereFactura.UseVisualStyleBackColor = True
        '
        'txtMailFc
        '
        Me.txtMailFc.Location = New System.Drawing.Point(123, 76)
        Me.txtMailFc.MaxLength = 35
        Me.txtMailFc.Name = "txtMailFc"
        Me.txtMailFc.Size = New System.Drawing.Size(204, 20)
        Me.txtMailFc.TabIndex = 5
        '
        'cboIva
        '
        Me.cboIva.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboIva.FormattingEnabled = True
        Me.cboIva.Location = New System.Drawing.Point(123, 45)
        Me.cboIva.Name = "cboIva"
        Me.cboIva.Size = New System.Drawing.Size(204, 21)
        Me.cboIva.TabIndex = 3
        '
        'gbIdentidad
        '
        Me.gbIdentidad.Controls.Add(Me.txtNombrePagador)
        Me.gbIdentidad.Controls.Add(Me.btnProponer)
        Me.gbIdentidad.Controls.Add(Me.txtCodigoPagador)
        Me.gbIdentidad.Controls.Add(Label5)
        Me.gbIdentidad.Controls.Add(Me.txtCodigoCliente)
        Me.gbIdentidad.Controls.Add(Label4)
        Me.gbIdentidad.Controls.Add(Me.txtFantasia)
        Me.gbIdentidad.Controls.Add(Label3)
        Me.gbIdentidad.Controls.Add(Me.txtNombre)
        Me.gbIdentidad.Controls.Add(Label2)
        Me.gbIdentidad.Location = New System.Drawing.Point(12, 126)
        Me.gbIdentidad.Name = "gbIdentidad"
        Me.gbIdentidad.Size = New System.Drawing.Size(336, 124)
        Me.gbIdentidad.TabIndex = 1
        Me.gbIdentidad.TabStop = False
        Me.gbIdentidad.Text = "Identidad"
        '
        'txtNombrePagador
        '
        Me.txtNombrePagador.Location = New System.Drawing.Point(180, 43)
        Me.txtNombrePagador.MaxLength = 35
        Me.txtNombrePagador.Name = "txtNombrePagador"
        Me.txtNombrePagador.ReadOnly = True
        Me.txtNombrePagador.Size = New System.Drawing.Size(150, 20)
        Me.txtNombrePagador.TabIndex = 5
        Me.txtNombrePagador.TabStop = False
        '
        'btnProponer
        '
        Me.btnProponer.Location = New System.Drawing.Point(180, 15)
        Me.btnProponer.Name = "btnProponer"
        Me.btnProponer.Size = New System.Drawing.Size(75, 23)
        Me.btnProponer.TabIndex = 2
        Me.btnProponer.TabStop = False
        Me.btnProponer.Tag = ""
        Me.btnProponer.Text = "Proponer"
        Me.btnProponer.UseVisualStyleBackColor = True
        '
        'cboCondicionIb
        '
        Me.cboCondicionIb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCondicionIb.FormattingEnabled = True
        Me.cboCondicionIb.Location = New System.Drawing.Point(123, 46)
        Me.cboCondicionIb.Name = "cboCondicionIb"
        Me.cboCondicionIb.Size = New System.Drawing.Size(114, 21)
        Me.cboCondicionIb.TabIndex = 4
        '
        'txtIIBB
        '
        Me.txtIIBB.Location = New System.Drawing.Point(243, 46)
        Me.txtIIBB.MaxLength = 15
        Me.txtIIBB.Name = "txtIIBB"
        Me.txtIIBB.Size = New System.Drawing.Size(84, 20)
        Me.txtIIBB.TabIndex = 5
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtObservaciones.Location = New System.Drawing.Point(3, 16)
        Me.txtObservaciones.MaxLength = 250
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(324, 72)
        Me.txtObservaciones.TabIndex = 0
        '
        'gbObservaciones
        '
        Me.gbObservaciones.Controls.Add(Me.txtObservaciones)
        Me.gbObservaciones.Location = New System.Drawing.Point(660, 385)
        Me.gbObservaciones.Name = "gbObservaciones"
        Me.gbObservaciones.Size = New System.Drawing.Size(330, 91)
        Me.gbObservaciones.TabIndex = 6
        Me.gbObservaciones.TabStop = False
        Me.gbObservaciones.Text = "Observaciones"
        '
        'gbSucursales
        '
        Me.gbSucursales.Controls.Add(Me.btnEditarSucursal)
        Me.gbSucursales.Controls.Add(Me.btnAgregarSucursal)
        Me.gbSucursales.Controls.Add(Me.dgv)
        Me.gbSucursales.Location = New System.Drawing.Point(354, 12)
        Me.gbSucursales.Name = "gbSucursales"
        Me.gbSucursales.Size = New System.Drawing.Size(636, 367)
        Me.gbSucursales.TabIndex = 4
        Me.gbSucursales.TabStop = False
        Me.gbSucursales.Text = "Sucursales"
        '
        'btnEditarSucursal
        '
        Me.btnEditarSucursal.Location = New System.Drawing.Point(87, 335)
        Me.btnEditarSucursal.Name = "btnEditarSucursal"
        Me.btnEditarSucursal.Size = New System.Drawing.Size(75, 23)
        Me.btnEditarSucursal.TabIndex = 2
        Me.btnEditarSucursal.Tag = ""
        Me.btnEditarSucursal.Text = "Editar"
        Me.btnEditarSucursal.UseVisualStyleBackColor = True
        '
        'btnAgregarSucursal
        '
        Me.btnAgregarSucursal.Location = New System.Drawing.Point(6, 335)
        Me.btnAgregarSucursal.Name = "btnAgregarSucursal"
        Me.btnAgregarSucursal.Size = New System.Drawing.Size(75, 23)
        Me.btnAgregarSucursal.TabIndex = 1
        Me.btnAgregarSucursal.Tag = ""
        Me.btnAgregarSucursal.Text = "Agregar"
        Me.btnAgregarSucursal.UseVisualStyleBackColor = True
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToDeleteRows = False
        Me.dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Location = New System.Drawing.Point(6, 19)
        Me.dgv.Name = "dgv"
        Me.dgv.ReadOnly = True
        Me.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv.Size = New System.Drawing.Size(624, 310)
        Me.dgv.TabIndex = 0
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(909, 484)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(75, 23)
        Me.btnSalir.TabIndex = 8
        Me.btnSalir.Tag = "Alta"
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'gbFiscal
        '
        Me.gbFiscal.Controls.Add(Me.cboCondicionIb)
        Me.gbFiscal.Controls.Add(Label6)
        Me.gbFiscal.Controls.Add(Me.cboTipoDoc)
        Me.gbFiscal.Controls.Add(Me.txtIIBB)
        Me.gbFiscal.Controls.Add(Label7)
        Me.gbFiscal.Controls.Add(Me.txtNumDoc)
        Me.gbFiscal.Location = New System.Drawing.Point(12, 256)
        Me.gbFiscal.Name = "gbFiscal"
        Me.gbFiscal.Size = New System.Drawing.Size(333, 78)
        Me.gbFiscal.TabIndex = 2
        Me.gbFiscal.TabStop = False
        Me.gbFiscal.Text = "Fiscal"
        '
        'AltaCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1006, 519)
        Me.Controls.Add(Me.gbFiscal)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.gbSucursales)
        Me.Controls.Add(Me.gbObservaciones)
        Me.Controls.Add(Me.gbIdentidad)
        Me.Controls.Add(Me.gbFinancieras)
        Me.Controls.Add(Me.gbRepresentante)
        Me.Controls.Add(Me.btnRegistrar)
        Me.Controls.Add(Me.gbFamilias)
        Me.Name = "AltaCliente"
        Me.Text = "Clientes"
        Me.gbFamilias.ResumeLayout(False)
        Me.gbFamilias.PerformLayout()
        Me.gbRepresentante.ResumeLayout(False)
        Me.gbRepresentante.PerformLayout()
        Me.gbFinancieras.ResumeLayout(False)
        Me.gbFinancieras.PerformLayout()
        Me.gbIdentidad.ResumeLayout(False)
        Me.gbIdentidad.PerformLayout()
        Me.gbObservaciones.ResumeLayout(False)
        Me.gbObservaciones.PerformLayout()
        Me.gbSucursales.ResumeLayout(False)
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbFiscal.ResumeLayout(False)
        Me.gbFiscal.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents txtFantasia As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigoCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigoPagador As System.Windows.Forms.TextBox
    Friend WithEvents cboTipoDoc As System.Windows.Forms.ComboBox
    Friend WithEvents txtNumDoc As System.Windows.Forms.TextBox
    Friend WithEvents cboFamilia3 As System.Windows.Forms.ComboBox
    Friend WithEvents cboFamilia2 As System.Windows.Forms.ComboBox
    Friend WithEvents cboFamilia1 As System.Windows.Forms.ComboBox
    Friend WithEvents gbFamilias As System.Windows.Forms.GroupBox
    Friend WithEvents btnRegistrar As System.Windows.Forms.Button
    Friend WithEvents cboCondicionPago As System.Windows.Forms.ComboBox
    Friend WithEvents gbRepresentante As System.Windows.Forms.GroupBox
    Friend WithEvents cboVendedor As System.Windows.Forms.ComboBox
    Friend WithEvents gbFinancieras As System.Windows.Forms.GroupBox
    Friend WithEvents cboIva As System.Windows.Forms.ComboBox
    Friend WithEvents gbIdentidad As System.Windows.Forms.GroupBox
    Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents gbObservaciones As System.Windows.Forms.GroupBox
    Friend WithEvents txtIIBB As System.Windows.Forms.TextBox
    Friend WithEvents gbSucursales As System.Windows.Forms.GroupBox
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents btnEditarSucursal As System.Windows.Forms.Button
    Friend WithEvents btnAgregarSucursal As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents btnProponer As System.Windows.Forms.Button
    Friend WithEvents cboCondicionIb As System.Windows.Forms.ComboBox
    Friend WithEvents gbFiscal As System.Windows.Forms.GroupBox
    Friend WithEvents txtNombrePagador As System.Windows.Forms.TextBox
    Friend WithEvents txtMailFc As System.Windows.Forms.TextBox
    Friend WithEvents chkRequiereFactura As System.Windows.Forms.CheckBox
End Class
