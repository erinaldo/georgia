<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOT
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
        Dim Label3 As System.Windows.Forms.Label
        Dim Label2 As System.Windows.Forms.Label
        Dim Label4 As System.Windows.Forms.Label
        Dim Label5 As System.Windows.Forms.Label
        Dim Label6 As System.Windows.Forms.Label
        Dim Label7 As System.Windows.Forms.Label
        Dim Label8 As System.Windows.Forms.Label
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.btnAceptar = New System.Windows.Forms.Button
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.mtbOTR = New System.Windows.Forms.MaskedTextBox
        Me.txtCliente = New System.Windows.Forms.TextBox
        Me.txtCod = New System.Windows.Forms.TextBox
        Me.cboSucursal = New System.Windows.Forms.ComboBox
        Me.nudPrestamosExt = New System.Windows.Forms.NumericUpDown
        Me.txtObserva = New System.Windows.Forms.TextBox
        Me.cboTipo = New System.Windows.Forms.ComboBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lstSS = New System.Windows.Forms.ListBox
        Me.rbSS2 = New System.Windows.Forms.RadioButton
        Me.rbSS1 = New System.Windows.Forms.RadioButton
        Me.dgv = New System.Windows.Forms.DataGridView
        Me.cboEmpresas = New System.Windows.Forms.ComboBox
        Me.nudPrestamosMan = New System.Windows.Forms.NumericUpDown
        Me.colNumlig = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colNum = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colItmref = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colAgente = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colQty = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colUom = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colTqty = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colTuom = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colYqty2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colFactura = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.colTyplig = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colAmt = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colSre = New System.Windows.Forms.DataGridViewTextBoxColumn
        Label1 = New System.Windows.Forms.Label
        Label3 = New System.Windows.Forms.Label
        Label2 = New System.Windows.Forms.Label
        Label4 = New System.Windows.Forms.Label
        Label5 = New System.Windows.Forms.Label
        Label6 = New System.Windows.Forms.Label
        Label7 = New System.Windows.Forms.Label
        Label8 = New System.Windows.Forms.Label
        CType(Me.nudPrestamosExt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudPrestamosMan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(17, 119)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(56, 13)
        Label1.TabIndex = 5
        Label1.Text = "OTR Nro.:"
        '
        'Label3
        '
        Label3.AutoSize = True
        Label3.Location = New System.Drawing.Point(16, 15)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(42, 13)
        Label3.TabIndex = 0
        Label3.Text = "Cliente:"
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Location = New System.Drawing.Point(16, 65)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(51, 13)
        Label2.TabIndex = 3
        Label2.Text = "Sucursal:"
        '
        'Label4
        '
        Label4.AutoSize = True
        Label4.Location = New System.Drawing.Point(392, 305)
        Label4.Name = "Label4"
        Label4.Size = New System.Drawing.Size(171, 13)
        Label4.TabIndex = 13
        Label4.Text = "Préstamos Entregados (Extintores):"
        '
        'Label5
        '
        Label5.AutoSize = True
        Label5.Location = New System.Drawing.Point(17, 181)
        Label5.Name = "Label5"
        Label5.Size = New System.Drawing.Size(81, 13)
        Label5.TabIndex = 9
        Label5.Text = "Observaciones:"
        '
        'Label6
        '
        Label6.AutoSize = True
        Label6.Location = New System.Drawing.Point(17, 145)
        Label6.Name = "Label6"
        Label6.Size = New System.Drawing.Size(57, 13)
        Label6.TabIndex = 7
        Label6.Text = "Categoría:"
        '
        'Label7
        '
        Label7.AutoSize = True
        Label7.Location = New System.Drawing.Point(392, 145)
        Label7.Name = "Label7"
        Label7.Size = New System.Drawing.Size(110, 13)
        Label7.TabIndex = 18
        Label7.Text = "Empresa Facturación:"
        '
        'Label8
        '
        Label8.AutoSize = True
        Label8.Location = New System.Drawing.Point(392, 331)
        Label8.Name = "Label8"
        Label8.Size = New System.Drawing.Size(178, 13)
        Label8.TabIndex = 20
        Label8.Text = "Préstamos Entregados (Mangueras):"
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(687, 326)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 15
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(768, 326)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 16
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'mtbOTR
        '
        Me.mtbOTR.Location = New System.Drawing.Point(85, 116)
        Me.mtbOTR.Mask = "9999999"
        Me.mtbOTR.Name = "mtbOTR"
        Me.mtbOTR.Size = New System.Drawing.Size(85, 20)
        Me.mtbOTR.TabIndex = 6
        Me.mtbOTR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCliente
        '
        Me.txtCliente.Location = New System.Drawing.Point(85, 31)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(290, 20)
        Me.txtCliente.TabIndex = 2
        Me.txtCliente.TabStop = False
        '
        'txtCod
        '
        Me.txtCod.Location = New System.Drawing.Point(19, 31)
        Me.txtCod.Name = "txtCod"
        Me.txtCod.Size = New System.Drawing.Size(60, 20)
        Me.txtCod.TabIndex = 1
        '
        'cboSucursal
        '
        Me.cboSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSucursal.FormattingEnabled = True
        Me.cboSucursal.Location = New System.Drawing.Point(20, 81)
        Me.cboSucursal.Name = "cboSucursal"
        Me.cboSucursal.Size = New System.Drawing.Size(355, 21)
        Me.cboSucursal.TabIndex = 4
        '
        'nudPrestamosExt
        '
        Me.nudPrestamosExt.Location = New System.Drawing.Point(591, 303)
        Me.nudPrestamosExt.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
        Me.nudPrestamosExt.Name = "nudPrestamosExt"
        Me.nudPrestamosExt.Size = New System.Drawing.Size(45, 20)
        Me.nudPrestamosExt.TabIndex = 14
        '
        'txtObserva
        '
        Me.txtObserva.Location = New System.Drawing.Point(19, 197)
        Me.txtObserva.Multiline = True
        Me.txtObserva.Name = "txtObserva"
        Me.txtObserva.Size = New System.Drawing.Size(356, 97)
        Me.txtObserva.TabIndex = 10
        '
        'cboTipo
        '
        Me.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipo.FormattingEnabled = True
        Me.cboTipo.Location = New System.Drawing.Point(85, 142)
        Me.cboTipo.Name = "cboTipo"
        Me.cboTipo.Size = New System.Drawing.Size(290, 21)
        Me.cboTipo.TabIndex = 8
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lstSS)
        Me.GroupBox1.Controls.Add(Me.rbSS2)
        Me.GroupBox1.Controls.Add(Me.rbSS1)
        Me.GroupBox1.Location = New System.Drawing.Point(388, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(459, 103)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Solicitud de Servicio"
        '
        'lstSS
        '
        Me.lstSS.Enabled = False
        Me.lstSS.FormattingEnabled = True
        Me.lstSS.Location = New System.Drawing.Point(203, 23)
        Me.lstSS.Name = "lstSS"
        Me.lstSS.Size = New System.Drawing.Size(242, 69)
        Me.lstSS.TabIndex = 2
        '
        'rbSS2
        '
        Me.rbSS2.AutoSize = True
        Me.rbSS2.Enabled = False
        Me.rbSS2.Location = New System.Drawing.Point(6, 49)
        Me.rbSS2.Name = "rbSS2"
        Me.rbSS2.Size = New System.Drawing.Size(191, 17)
        Me.rbSS2.TabIndex = 1
        Me.rbSS2.Text = "Usar una Solicitud existente abierta"
        Me.rbSS2.UseVisualStyleBackColor = True
        '
        'rbSS1
        '
        Me.rbSS1.AutoSize = True
        Me.rbSS1.Checked = True
        Me.rbSS1.Location = New System.Drawing.Point(6, 23)
        Me.rbSS1.Name = "rbSS1"
        Me.rbSS1.Size = New System.Drawing.Size(147, 17)
        Me.rbSS1.TabIndex = 0
        Me.rbSS1.TabStop = True
        Me.rbSS1.Text = "Crear una nueva Solicitud"
        Me.rbSS1.UseVisualStyleBackColor = True
        '
        'dgv
        '
        Me.dgv.AllowUserToResizeColumns = False
        Me.dgv.AllowUserToResizeRows = False
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colNumlig, Me.colNum, Me.colItmref, Me.colAgente, Me.colQty, Me.colUom, Me.colTqty, Me.colTuom, Me.colYqty2, Me.colFactura, Me.colTyplig, Me.colAmt, Me.colSre})
        Me.dgv.Location = New System.Drawing.Point(395, 195)
        Me.dgv.Name = "dgv"
        Me.dgv.Size = New System.Drawing.Size(452, 99)
        Me.dgv.TabIndex = 17
        '
        'cboEmpresas
        '
        Me.cboEmpresas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEmpresas.FormattingEnabled = True
        Me.cboEmpresas.Location = New System.Drawing.Point(517, 142)
        Me.cboEmpresas.Name = "cboEmpresas"
        Me.cboEmpresas.Size = New System.Drawing.Size(316, 21)
        Me.cboEmpresas.TabIndex = 19
        '
        'nudPrestamosMan
        '
        Me.nudPrestamosMan.Location = New System.Drawing.Point(591, 331)
        Me.nudPrestamosMan.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
        Me.nudPrestamosMan.Name = "nudPrestamosMan"
        Me.nudPrestamosMan.Size = New System.Drawing.Size(45, 20)
        Me.nudPrestamosMan.TabIndex = 21
        '
        'colNumlig
        '
        Me.colNumlig.HeaderText = "Linea"
        Me.colNumlig.Name = "colNumlig"
        Me.colNumlig.Visible = False
        '
        'colNum
        '
        Me.colNum.HeaderText = "Intervencion"
        Me.colNum.Name = "colNum"
        Me.colNum.Visible = False
        '
        'colItmref
        '
        Me.colItmref.HeaderText = "Artículo"
        Me.colItmref.Name = "colItmref"
        Me.colItmref.Width = 55
        '
        'colAgente
        '
        Me.colAgente.HeaderText = "Tipo y Capacidad"
        Me.colAgente.Name = "colAgente"
        Me.colAgente.ReadOnly = True
        Me.colAgente.Width = 280
        '
        'colQty
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colQty.DefaultCellStyle = DataGridViewCellStyle1
        Me.colQty.HeaderText = "Cantidad"
        Me.colQty.Name = "colQty"
        Me.colQty.Width = 65
        '
        'colUom
        '
        Me.colUom.HeaderText = "Uom"
        Me.colUom.Name = "colUom"
        Me.colUom.Visible = False
        '
        'colTqty
        '
        Me.colTqty.HeaderText = "Tqty"
        Me.colTqty.Name = "colTqty"
        Me.colTqty.Visible = False
        '
        'colTuom
        '
        Me.colTuom.HeaderText = "TUom"
        Me.colTuom.Name = "colTuom"
        Me.colTuom.Visible = False
        '
        'colYqty2
        '
        Me.colYqty2.HeaderText = "Yqty2"
        Me.colYqty2.Name = "colYqty2"
        Me.colYqty2.Visible = False
        '
        'colFactura
        '
        Me.colFactura.HeaderText = "Factura"
        Me.colFactura.Name = "colFactura"
        Me.colFactura.Visible = False
        '
        'colTyplig
        '
        Me.colTyplig.HeaderText = "Typlig"
        Me.colTyplig.Name = "colTyplig"
        Me.colTyplig.Visible = False
        '
        'colAmt
        '
        Me.colAmt.HeaderText = "Precio"
        Me.colAmt.Name = "colAmt"
        Me.colAmt.Visible = False
        '
        'colSre
        '
        Me.colSre.HeaderText = "Solicitud"
        Me.colSre.Name = "colSre"
        Me.colSre.Visible = False
        '
        'frmOT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(855, 353)
        Me.Controls.Add(Me.nudPrestamosMan)
        Me.Controls.Add(Label8)
        Me.Controls.Add(Label7)
        Me.Controls.Add(Me.cboEmpresas)
        Me.Controls.Add(Me.dgv)
        Me.Controls.Add(Label6)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cboTipo)
        Me.Controls.Add(Label5)
        Me.Controls.Add(Me.txtObserva)
        Me.Controls.Add(Label4)
        Me.Controls.Add(Me.nudPrestamosExt)
        Me.Controls.Add(Label2)
        Me.Controls.Add(Me.cboSucursal)
        Me.Controls.Add(Me.txtCod)
        Me.Controls.Add(Label3)
        Me.Controls.Add(Me.txtCliente)
        Me.Controls.Add(Me.mtbOTR)
        Me.Controls.Add(Label1)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmOT"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Orden de Trabajo"
        CType(Me.nudPrestamosExt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudPrestamosMan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents mtbOTR As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtCod As System.Windows.Forms.TextBox
    Friend WithEvents cboSucursal As System.Windows.Forms.ComboBox
    Friend WithEvents nudPrestamosExt As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtObserva As System.Windows.Forms.TextBox
    Friend WithEvents cboTipo As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lstSS As System.Windows.Forms.ListBox
    Friend WithEvents rbSS2 As System.Windows.Forms.RadioButton
    Friend WithEvents rbSS1 As System.Windows.Forms.RadioButton
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents cboEmpresas As System.Windows.Forms.ComboBox
    Friend WithEvents nudPrestamosMan As System.Windows.Forms.NumericUpDown
    Friend WithEvents colNumlig As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNum As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItmref As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAgente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUom As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTqty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTuom As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colYqty2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFactura As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colTyplig As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAmt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSre As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
