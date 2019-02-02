<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmParteCobranza
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
        Dim Label2 As System.Windows.Forms.Label
        Dim Label3 As System.Windows.Forms.Label
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.txtCliente = New System.Windows.Forms.TextBox
        Me.btnBuscar = New System.Windows.Forms.Button
        Me.dgv1 = New System.Windows.Forms.DataGridView
        Me.colCodigo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCliente = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colFecha = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colFactura = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colImporte = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCuota = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colVto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCobrador = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colFechaCob = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colVendedor = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.txtNombre = New System.Windows.Forms.TextBox
        Me.dtp = New System.Windows.Forms.DateTimePicker
        Me.btnMarcar = New System.Windows.Forms.Button
        Me.btnImprimir = New System.Windows.Forms.Button
        Me.dgv2 = New System.Windows.Forms.DataGridView
        Me.colPagador = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colDomicilio = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.colDia = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.colDesde = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colHasta = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.lblBuscando = New System.Windows.Forms.Label
        Label1 = New System.Windows.Forms.Label
        Label2 = New System.Windows.Forms.Label
        Label3 = New System.Windows.Forms.Label
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(-2, 9)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(50, 13)
        Label1.TabIndex = 0
        Label1.Text = "Pagador:"
        '
        'Label2
        '
        Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Label2.AutoSize = True
        Label2.Location = New System.Drawing.Point(596, 333)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(88, 13)
        Label2.TabIndex = 6
        Label2.Text = "Fecha Cobranza:"
        '
        'Label3
        '
        Label3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Label3.AutoSize = True
        Label3.Location = New System.Drawing.Point(-2, 303)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(111, 13)
        Label3.TabIndex = 0
        Label3.Text = "Horarios de cobranza:"
        '
        'txtCliente
        '
        Me.txtCliente.Location = New System.Drawing.Point(54, 6)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(100, 20)
        Me.txtCliente.TabIndex = 1
        '
        'btnBuscar
        '
        Me.btnBuscar.Enabled = False
        Me.btnBuscar.Location = New System.Drawing.Point(166, 6)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(75, 23)
        Me.btnBuscar.TabIndex = 2
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'dgv1
        '
        Me.dgv1.AllowUserToAddRows = False
        Me.dgv1.AllowUserToDeleteRows = False
        Me.dgv1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colCodigo, Me.colCliente, Me.colFecha, Me.colFactura, Me.colImporte, Me.colCuota, Me.colVto, Me.colCobrador, Me.colFechaCob, Me.colVendedor})
        Me.dgv1.Location = New System.Drawing.Point(1, 35)
        Me.dgv1.Name = "dgv1"
        Me.dgv1.ReadOnly = True
        Me.dgv1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv1.Size = New System.Drawing.Size(725, 251)
        Me.dgv1.TabIndex = 3
        '
        'colCodigo
        '
        Me.colCodigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.colCodigo.HeaderText = "Codigo"
        Me.colCodigo.Name = "colCodigo"
        Me.colCodigo.ReadOnly = True
        Me.colCodigo.Width = 65
        '
        'colCliente
        '
        Me.colCliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.colCliente.HeaderText = "Nombre"
        Me.colCliente.Name = "colCliente"
        Me.colCliente.ReadOnly = True
        Me.colCliente.Width = 69
        '
        'colFecha
        '
        Me.colFecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colFecha.HeaderText = "Fecha"
        Me.colFecha.Name = "colFecha"
        Me.colFecha.ReadOnly = True
        Me.colFecha.Width = 62
        '
        'colFactura
        '
        Me.colFactura.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colFactura.HeaderText = "Factura"
        Me.colFactura.Name = "colFactura"
        Me.colFactura.ReadOnly = True
        Me.colFactura.Width = 68
        '
        'colImporte
        '
        Me.colImporte.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Format = "N2"
        Me.colImporte.DefaultCellStyle = DataGridViewCellStyle1
        Me.colImporte.HeaderText = "Importe"
        Me.colImporte.Name = "colImporte"
        Me.colImporte.ReadOnly = True
        Me.colImporte.Width = 67
        '
        'colCuota
        '
        Me.colCuota.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colCuota.DefaultCellStyle = DataGridViewCellStyle2
        Me.colCuota.HeaderText = "Cuota"
        Me.colCuota.Name = "colCuota"
        Me.colCuota.ReadOnly = True
        Me.colCuota.Width = 60
        '
        'colVto
        '
        Me.colVto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colVto.HeaderText = "Vto"
        Me.colVto.Name = "colVto"
        Me.colVto.ReadOnly = True
        Me.colVto.Width = 48
        '
        'colCobrador
        '
        Me.colCobrador.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.colCobrador.HeaderText = "Cobrador"
        Me.colCobrador.Name = "colCobrador"
        Me.colCobrador.ReadOnly = True
        Me.colCobrador.Width = 75
        '
        'colFechaCob
        '
        Me.colFechaCob.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colFechaCob.HeaderText = "Fecha Cob"
        Me.colFechaCob.Name = "colFechaCob"
        Me.colFechaCob.ReadOnly = True
        Me.colFechaCob.Width = 84
        '
        'colVendedor
        '
        Me.colVendedor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.colVendedor.HeaderText = "Vendedor"
        Me.colVendedor.Name = "colVendedor"
        Me.colVendedor.ReadOnly = True
        Me.colVendedor.Width = 78
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(247, 6)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.ReadOnly = True
        Me.txtNombre.Size = New System.Drawing.Size(474, 20)
        Me.txtNombre.TabIndex = 4
        '
        'dtp
        '
        Me.dtp.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtp.CustomFormat = "dd/MM/yyyy"
        Me.dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp.Location = New System.Drawing.Point(599, 349)
        Me.dtp.Name = "dtp"
        Me.dtp.Size = New System.Drawing.Size(100, 20)
        Me.dtp.TabIndex = 5
        '
        'btnMarcar
        '
        Me.btnMarcar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMarcar.Location = New System.Drawing.Point(599, 292)
        Me.btnMarcar.Name = "btnMarcar"
        Me.btnMarcar.Size = New System.Drawing.Size(118, 23)
        Me.btnMarcar.TabIndex = 7
        Me.btnMarcar.Text = "Marcar"
        Me.btnMarcar.UseVisualStyleBackColor = True
        '
        'btnImprimir
        '
        Me.btnImprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnImprimir.Location = New System.Drawing.Point(599, 400)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(118, 23)
        Me.btnImprimir.TabIndex = 8
        Me.btnImprimir.Text = "Imprimir Parte"
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'dgv2
        '
        Me.dgv2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colPagador, Me.colDomicilio, Me.colDia, Me.colDesde, Me.colHasta})
        Me.dgv2.Location = New System.Drawing.Point(1, 319)
        Me.dgv2.Name = "dgv2"
        Me.dgv2.Size = New System.Drawing.Size(574, 104)
        Me.dgv2.TabIndex = 9
        '
        'colPagador
        '
        Me.colPagador.HeaderText = "Pagador"
        Me.colPagador.Name = "colPagador"
        Me.colPagador.Visible = False
        '
        'colDomicilio
        '
        Me.colDomicilio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colDomicilio.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.colDomicilio.HeaderText = "Domicilio"
        Me.colDomicilio.Name = "colDomicilio"
        '
        'colDia
        '
        Me.colDia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colDia.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.colDia.HeaderText = "Dia"
        Me.colDia.Name = "colDia"
        Me.colDia.Width = 39
        '
        'colDesde
        '
        Me.colDesde.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.colDesde.HeaderText = "Desde"
        Me.colDesde.MaxInputLength = 4
        Me.colDesde.Name = "colDesde"
        Me.colDesde.Width = 63
        '
        'colHasta
        '
        Me.colHasta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.colHasta.HeaderText = "Hasta"
        Me.colHasta.MaxInputLength = 4
        Me.colHasta.Name = "colHasta"
        Me.colHasta.Width = 60
        '
        'lblBuscando
        '
        Me.lblBuscando.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBuscando.Location = New System.Drawing.Point(221, 161)
        Me.lblBuscando.Name = "lblBuscando"
        Me.lblBuscando.Size = New System.Drawing.Size(292, 59)
        Me.lblBuscando.TabIndex = 10
        Me.lblBuscando.Text = "Buscando..."
        Me.lblBuscando.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblBuscando.Visible = False
        '
        'frmParteCobranza
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(729, 435)
        Me.Controls.Add(Me.lblBuscando)
        Me.Controls.Add(Me.dgv2)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.btnMarcar)
        Me.Controls.Add(Label2)
        Me.Controls.Add(Me.dtp)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.dgv1)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.txtCliente)
        Me.Controls.Add(Label3)
        Me.Controls.Add(Label1)
        Me.Name = "frmParteCobranza"
        Me.Text = "Parte de cobranza"
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents dgv1 As System.Windows.Forms.DataGridView
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents dtp As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnMarcar As System.Windows.Forms.Button
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents colCodigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFactura As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colImporte As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCuota As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colVto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCobrador As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFechaCob As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colVendedor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgv2 As System.Windows.Forms.DataGridView
    Friend WithEvents lblBuscando As System.Windows.Forms.Label
    Friend WithEvents colPagador As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDomicilio As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colDia As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colDesde As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colHasta As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
