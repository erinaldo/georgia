<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVentas1
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim Label8 As System.Windows.Forms.Label
        Dim Label9 As System.Windows.Forms.Label
        Me.dgv = New System.Windows.Forms.DataGridView
        Me.colCod = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colVendedor = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colTotal = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colActivos = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colRegulares = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colRecuperados = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colRecuperar = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colNuevos = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colFacturas = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colFacturados = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnConsultar = New System.Windows.Forms.Button
        Me.dtp = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtTotal = New System.Windows.Forms.TextBox
        Me.txtActivos = New System.Windows.Forms.TextBox
        Me.txtRegulares = New System.Windows.Forms.TextBox
        Me.txtRecuperados = New System.Windows.Forms.TextBox
        Me.txtRecuperar = New System.Windows.Forms.TextBox
        Me.txtNuevos = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtFacturados = New System.Windows.Forms.TextBox
        Me.txtFacturas = New System.Windows.Forms.TextBox
        Label2 = New System.Windows.Forms.Label
        Label3 = New System.Windows.Forms.Label
        Label4 = New System.Windows.Forms.Label
        Label5 = New System.Windows.Forms.Label
        Label6 = New System.Windows.Forms.Label
        Label7 = New System.Windows.Forms.Label
        Label8 = New System.Windows.Forms.Label
        Label9 = New System.Windows.Forms.Label
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Location = New System.Drawing.Point(6, 23)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(68, 13)
        Label2.TabIndex = 5
        Label2.Text = "Total Cartera"
        '
        'Label3
        '
        Label3.AutoSize = True
        Label3.Location = New System.Drawing.Point(145, 23)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(42, 13)
        Label3.TabIndex = 7
        Label3.Text = "Activos"
        '
        'Label4
        '
        Label4.AutoSize = True
        Label4.Location = New System.Drawing.Point(293, 22)
        Label4.Name = "Label4"
        Label4.Size = New System.Drawing.Size(55, 13)
        Label4.TabIndex = 9
        Label4.Text = "Regulares"
        '
        'Label5
        '
        Label5.AutoSize = True
        Label5.Location = New System.Drawing.Point(145, 53)
        Label5.Name = "Label5"
        Label5.Size = New System.Drawing.Size(71, 13)
        Label5.TabIndex = 11
        Label5.Text = "Recuperados"
        '
        'Label6
        '
        Label6.AutoSize = True
        Label6.Location = New System.Drawing.Point(6, 53)
        Label6.Name = "Label6"
        Label6.Size = New System.Drawing.Size(62, 13)
        Label6.TabIndex = 13
        Label6.Text = "A recuperar"
        '
        'Label7
        '
        Label7.AutoSize = True
        Label7.Location = New System.Drawing.Point(293, 50)
        Label7.Name = "Label7"
        Label7.Size = New System.Drawing.Size(44, 13)
        Label7.TabIndex = 15
        Label7.Text = "Nuevos"
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToDeleteRows = False
        Me.dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colCod, Me.colVendedor, Me.colTotal, Me.colActivos, Me.colRegulares, Me.colRecuperados, Me.colRecuperar, Me.colNuevos, Me.colFacturas, Me.colFacturados})
        Me.dgv.Location = New System.Drawing.Point(12, 52)
        Me.dgv.Name = "dgv"
        Me.dgv.ReadOnly = True
        Me.dgv.Size = New System.Drawing.Size(751, 280)
        Me.dgv.TabIndex = 0
        '
        'colCod
        '
        Me.colCod.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.colCod.HeaderText = "Cod"
        Me.colCod.Name = "colCod"
        Me.colCod.ReadOnly = True
        Me.colCod.Width = 51
        '
        'colVendedor
        '
        Me.colVendedor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colVendedor.HeaderText = "Vendedor"
        Me.colVendedor.Name = "colVendedor"
        Me.colVendedor.ReadOnly = True
        '
        'colTotal
        '
        Me.colTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Format = "N0"
        Me.colTotal.DefaultCellStyle = DataGridViewCellStyle1
        Me.colTotal.HeaderText = "Total Cartera"
        Me.colTotal.Name = "colTotal"
        Me.colTotal.ReadOnly = True
        Me.colTotal.ToolTipText = "Clientes activos"
        Me.colTotal.Width = 86
        '
        'colActivos
        '
        Me.colActivos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N0"
        Me.colActivos.DefaultCellStyle = DataGridViewCellStyle2
        Me.colActivos.HeaderText = "Activos"
        Me.colActivos.Name = "colActivos"
        Me.colActivos.ReadOnly = True
        Me.colActivos.ToolTipText = "Con facturas en los 18 meses"
        Me.colActivos.Width = 67
        '
        'colRegulares
        '
        Me.colRegulares.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N0"
        Me.colRegulares.DefaultCellStyle = DataGridViewCellStyle3
        Me.colRegulares.HeaderText = "Regulares"
        Me.colRegulares.Name = "colRegulares"
        Me.colRegulares.ReadOnly = True
        Me.colRegulares.ToolTipText = "Con mas de 1 Fc en los 11 meses"
        Me.colRegulares.Width = 80
        '
        'colRecuperados
        '
        Me.colRecuperados.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N0"
        Me.colRecuperados.DefaultCellStyle = DataGridViewCellStyle4
        Me.colRecuperados.HeaderText = "Recuperados"
        Me.colRecuperados.Name = "colRecuperados"
        Me.colRecuperados.ReadOnly = True
        Me.colRecuperados.ToolTipText = "Con Fc en el mes y sin fc en los 12 meses"
        Me.colRecuperados.Width = 96
        '
        'colRecuperar
        '
        Me.colRecuperar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N0"
        Me.colRecuperar.DefaultCellStyle = DataGridViewCellStyle5
        Me.colRecuperar.HeaderText = "A recuperar"
        Me.colRecuperar.Name = "colRecuperar"
        Me.colRecuperar.ReadOnly = True
        Me.colRecuperar.ToolTipText = "Sin facturas en los 13 meses"
        Me.colRecuperar.Width = 80
        '
        'colNuevos
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "N0"
        Me.colNuevos.DefaultCellStyle = DataGridViewCellStyle6
        Me.colNuevos.HeaderText = "Nuevos"
        Me.colNuevos.Name = "colNuevos"
        Me.colNuevos.ReadOnly = True
        '
        'colFacturas
        '
        Me.colFacturas.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "N0"
        Me.colFacturas.DefaultCellStyle = DataGridViewCellStyle7
        Me.colFacturas.HeaderText = "Facturas en Mes"
        Me.colFacturas.Name = "colFacturas"
        Me.colFacturas.ReadOnly = True
        Me.colFacturas.Width = 84
        '
        'colFacturados
        '
        Me.colFacturados.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Format = "N0"
        Me.colFacturados.DefaultCellStyle = DataGridViewCellStyle8
        Me.colFacturados.HeaderText = "Clientes Facturados"
        Me.colFacturados.Name = "colFacturados"
        Me.colFacturados.ReadOnly = True
        Me.colFacturados.Width = 115
        '
        'btnConsultar
        '
        Me.btnConsultar.Location = New System.Drawing.Point(112, 13)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(75, 23)
        Me.btnConsultar.TabIndex = 1
        Me.btnConsultar.Text = "Consultar"
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'dtp
        '
        Me.dtp.CustomFormat = "MM/yyyy"
        Me.dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp.Location = New System.Drawing.Point(12, 12)
        Me.dtp.Name = "dtp"
        Me.dtp.Size = New System.Drawing.Size(94, 20)
        Me.dtp.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(193, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Label1"
        Me.Label1.Visible = False
        '
        'txtTotal
        '
        Me.txtTotal.Location = New System.Drawing.Point(80, 20)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(54, 20)
        Me.txtTotal.TabIndex = 4
        Me.txtTotal.Text = "0"
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtActivos
        '
        Me.txtActivos.Location = New System.Drawing.Point(233, 20)
        Me.txtActivos.Name = "txtActivos"
        Me.txtActivos.ReadOnly = True
        Me.txtActivos.Size = New System.Drawing.Size(54, 20)
        Me.txtActivos.TabIndex = 6
        Me.txtActivos.Text = "0"
        Me.txtActivos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtRegulares
        '
        Me.txtRegulares.Location = New System.Drawing.Point(374, 19)
        Me.txtRegulares.Name = "txtRegulares"
        Me.txtRegulares.ReadOnly = True
        Me.txtRegulares.Size = New System.Drawing.Size(54, 20)
        Me.txtRegulares.TabIndex = 8
        Me.txtRegulares.Text = "0"
        Me.txtRegulares.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtRecuperados
        '
        Me.txtRecuperados.Location = New System.Drawing.Point(233, 50)
        Me.txtRecuperados.Name = "txtRecuperados"
        Me.txtRecuperados.ReadOnly = True
        Me.txtRecuperados.Size = New System.Drawing.Size(54, 20)
        Me.txtRecuperados.TabIndex = 10
        Me.txtRecuperados.Text = "0"
        Me.txtRecuperados.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtRecuperar
        '
        Me.txtRecuperar.Location = New System.Drawing.Point(80, 50)
        Me.txtRecuperar.Name = "txtRecuperar"
        Me.txtRecuperar.ReadOnly = True
        Me.txtRecuperar.Size = New System.Drawing.Size(54, 20)
        Me.txtRecuperar.TabIndex = 12
        Me.txtRecuperar.Text = "0"
        Me.txtRecuperar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNuevos
        '
        Me.txtNuevos.Location = New System.Drawing.Point(374, 46)
        Me.txtNuevos.Name = "txtNuevos"
        Me.txtNuevos.ReadOnly = True
        Me.txtNuevos.Size = New System.Drawing.Size(54, 20)
        Me.txtNuevos.TabIndex = 14
        Me.txtNuevos.Text = "0"
        Me.txtNuevos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Label8)
        Me.GroupBox1.Controls.Add(Me.txtFacturados)
        Me.GroupBox1.Controls.Add(Me.txtFacturas)
        Me.GroupBox1.Controls.Add(Label9)
        Me.GroupBox1.Controls.Add(Label2)
        Me.GroupBox1.Controls.Add(Label7)
        Me.GroupBox1.Controls.Add(Label3)
        Me.GroupBox1.Controls.Add(Me.txtNuevos)
        Me.GroupBox1.Controls.Add(Me.txtTotal)
        Me.GroupBox1.Controls.Add(Label6)
        Me.GroupBox1.Controls.Add(Me.txtActivos)
        Me.GroupBox1.Controls.Add(Me.txtRecuperar)
        Me.GroupBox1.Controls.Add(Me.txtRecuperados)
        Me.GroupBox1.Controls.Add(Label5)
        Me.GroupBox1.Controls.Add(Me.txtRegulares)
        Me.GroupBox1.Controls.Add(Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 339)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(751, 79)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Totales"
        '
        'Label8
        '
        Label8.AutoSize = True
        Label8.Location = New System.Drawing.Point(443, 51)
        Label8.Name = "Label8"
        Label8.Size = New System.Drawing.Size(65, 13)
        Label8.TabIndex = 19
        Label8.Text = "Clientes Fac"
        '
        'txtFacturados
        '
        Me.txtFacturados.Location = New System.Drawing.Point(524, 47)
        Me.txtFacturados.Name = "txtFacturados"
        Me.txtFacturados.ReadOnly = True
        Me.txtFacturados.Size = New System.Drawing.Size(54, 20)
        Me.txtFacturados.TabIndex = 18
        Me.txtFacturados.Text = "0"
        Me.txtFacturados.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFacturas
        '
        Me.txtFacturas.Location = New System.Drawing.Point(524, 20)
        Me.txtFacturas.Name = "txtFacturas"
        Me.txtFacturas.ReadOnly = True
        Me.txtFacturas.Size = New System.Drawing.Size(54, 20)
        Me.txtFacturas.TabIndex = 16
        Me.txtFacturas.Text = "0"
        Me.txtFacturas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Label9.AutoSize = True
        Label9.Location = New System.Drawing.Point(443, 23)
        Label9.Name = "Label9"
        Label9.Size = New System.Drawing.Size(48, 13)
        Label9.TabIndex = 17
        Label9.Text = "Facturas"
        '
        'frmVentas1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(775, 430)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtp)
        Me.Controls.Add(Me.btnConsultar)
        Me.Controls.Add(Me.dgv)
        Me.Name = "frmVentas1"
        Me.Text = "Estado de clientes"
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents btnConsultar As System.Windows.Forms.Button
    Friend WithEvents dtp As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtActivos As System.Windows.Forms.TextBox
    Friend WithEvents txtRegulares As System.Windows.Forms.TextBox
    Friend WithEvents txtRecuperados As System.Windows.Forms.TextBox
    Friend WithEvents txtRecuperar As System.Windows.Forms.TextBox
    Friend WithEvents txtNuevos As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents colCod As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colVendedor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTotal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colActivos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRegulares As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRecuperados As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRecuperar As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNuevos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFacturas As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFacturados As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtFacturados As System.Windows.Forms.TextBox
    Friend WithEvents txtFacturas As System.Windows.Forms.TextBox
End Class
