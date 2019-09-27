<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBuscaClientes
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
        Dim Label1 As System.Windows.Forms.Label
        Dim Label2 As System.Windows.Forms.Label
        Dim Label3 As System.Windows.Forms.Label
        Dim Label4 As System.Windows.Forms.Label
        Dim Label6 As System.Windows.Forms.Label
        Dim Label7 As System.Windows.Forms.Label
        Dim Label8 As System.Windows.Forms.Label
        Dim Label9 As System.Windows.Forms.Label
        Dim Label10 As System.Windows.Forms.Label
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.txtMail = New System.Windows.Forms.TextBox
        Me.btnProv = New System.Windows.Forms.Button
        Me.cboprov = New System.Windows.Forms.ComboBox
        Me.txtLoc = New System.Windows.Forms.TextBox
        Me.txtfantasia = New System.Windows.Forms.TextBox
        Me.txtPresupuesto = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtCUIT = New System.Windows.Forms.TextBox
        Me.txtDireccion = New System.Windows.Forms.TextBox
        Me.txtNombre = New System.Windows.Forms.TextBox
        Me.txtCodigo = New System.Windows.Forms.TextBox
        Me.dgv = New System.Windows.Forms.DataGridView
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DatosClienteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TerceroPagadorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.IntervencionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.PedidosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PresupuestosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PresupuestoPorSucursalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PresupuestoPorClienteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.FacturasToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.FacturasDeLaSucursalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.FacturasDelClienteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ParqueDelClienteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ParqueDeLaSucursalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ParqueGeneralToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RemitosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ConsorciosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnBuscarCilindro = New System.Windows.Forms.Button
        Label1 = New System.Windows.Forms.Label
        Label2 = New System.Windows.Forms.Label
        Label3 = New System.Windows.Forms.Label
        Label4 = New System.Windows.Forms.Label
        Label6 = New System.Windows.Forms.Label
        Label7 = New System.Windows.Forms.Label
        Label8 = New System.Windows.Forms.Label
        Label9 = New System.Windows.Forms.Label
        Label10 = New System.Windows.Forms.Label
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(3, 51)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(178, 13)
        Label1.TabIndex = 2
        Label1.Text = "Buscador por código de cliente (F5):"
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Location = New System.Drawing.Point(6, 90)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(181, 13)
        Label2.TabIndex = 4
        Label2.Text = "Buscador por nombre de cliente (F6):"
        '
        'Label3
        '
        Label3.AutoSize = True
        Label3.Location = New System.Drawing.Point(9, 129)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(140, 13)
        Label3.TabIndex = 6
        Label3.Text = "Buscador por dirección (F7):"
        '
        'Label4
        '
        Label4.AutoSize = True
        Label4.Location = New System.Drawing.Point(6, 179)
        Label4.Name = "Label4"
        Label4.Size = New System.Drawing.Size(122, 13)
        Label4.TabIndex = 8
        Label4.Text = "Buscador por CUIT (F8):"
        '
        'Label6
        '
        Label6.AutoSize = True
        Label6.Location = New System.Drawing.Point(12, 301)
        Label6.Name = "Label6"
        Label6.Size = New System.Drawing.Size(155, 13)
        Label6.TabIndex = 13
        Label6.Text = "Buscador por presupuesto (F9):"
        '
        'Label7
        '
        Label7.AutoSize = True
        Label7.Location = New System.Drawing.Point(6, 12)
        Label7.Name = "Label7"
        Label7.Size = New System.Drawing.Size(184, 13)
        Label7.TabIndex = 0
        Label7.Text = "Buscador por nombre de fantasia(F4):"
        '
        'Label8
        '
        Label8.AutoSize = True
        Label8.Location = New System.Drawing.Point(6, 398)
        Label8.Name = "Label8"
        Label8.Size = New System.Drawing.Size(146, 13)
        Label8.TabIndex = 17
        Label8.Text = "Buscador por provincia (F12):"
        '
        'Label9
        '
        Label9.AutoSize = True
        Label9.Location = New System.Drawing.Point(6, 340)
        Label9.Name = "Label9"
        Label9.Size = New System.Drawing.Size(149, 13)
        Label9.TabIndex = 15
        Label9.Text = "Buscador por Localidad (F11):"
        '
        'Label10
        '
        Label10.AutoSize = True
        Label10.Location = New System.Drawing.Point(6, 225)
        Label10.Name = "Label10"
        Label10.Size = New System.Drawing.Size(143, 13)
        Label10.TabIndex = 10
        Label10.Text = "Buscador por Mail (Shift+F8):"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnBuscarCilindro)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtMail)
        Me.SplitContainer1.Panel1.Controls.Add(Label10)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnProv)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cboprov)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtLoc)
        Me.SplitContainer1.Panel1.Controls.Add(Label9)
        Me.SplitContainer1.Panel1.Controls.Add(Label8)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtfantasia)
        Me.SplitContainer1.Panel1.Controls.Add(Label7)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtPresupuesto)
        Me.SplitContainer1.Panel1.Controls.Add(Label6)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label5)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtCUIT)
        Me.SplitContainer1.Panel1.Controls.Add(Label4)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtDireccion)
        Me.SplitContainer1.Panel1.Controls.Add(Label3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtNombre)
        Me.SplitContainer1.Panel1.Controls.Add(Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtCodigo)
        Me.SplitContainer1.Panel1.Controls.Add(Label1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgv)
        Me.SplitContainer1.Size = New System.Drawing.Size(943, 516)
        Me.SplitContainer1.SplitterDistance = 249
        Me.SplitContainer1.TabIndex = 0
        '
        'txtMail
        '
        Me.txtMail.Location = New System.Drawing.Point(9, 241)
        Me.txtMail.Name = "txtMail"
        Me.txtMail.Size = New System.Drawing.Size(231, 20)
        Me.txtMail.TabIndex = 11
        Me.ToolTip1.SetToolTip(Me.txtMail, "Apriete Enter despues de ingresar  los datos")
        '
        'btnProv
        '
        Me.btnProv.Enabled = False
        Me.btnProv.Location = New System.Drawing.Point(158, 412)
        Me.btnProv.Name = "btnProv"
        Me.btnProv.Size = New System.Drawing.Size(85, 23)
        Me.btnProv.TabIndex = 19
        Me.btnProv.Text = "Buscar"
        Me.btnProv.UseVisualStyleBackColor = True
        '
        'cboprov
        '
        Me.cboprov.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboprov.FormattingEnabled = True
        Me.cboprov.Location = New System.Drawing.Point(9, 414)
        Me.cboprov.Name = "cboprov"
        Me.cboprov.Size = New System.Drawing.Size(137, 21)
        Me.cboprov.TabIndex = 18
        '
        'txtLoc
        '
        Me.txtLoc.Location = New System.Drawing.Point(9, 356)
        Me.txtLoc.Name = "txtLoc"
        Me.txtLoc.Size = New System.Drawing.Size(234, 20)
        Me.txtLoc.TabIndex = 16
        Me.ToolTip1.SetToolTip(Me.txtLoc, "Apriete Enter despues de ingresar  los datos")
        '
        'txtfantasia
        '
        Me.txtfantasia.Location = New System.Drawing.Point(6, 28)
        Me.txtfantasia.Name = "txtfantasia"
        Me.txtfantasia.Size = New System.Drawing.Size(231, 20)
        Me.txtfantasia.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.txtfantasia, "Apriete Enter despues de ingresar  los datos")
        '
        'txtPresupuesto
        '
        Me.txtPresupuesto.Location = New System.Drawing.Point(9, 317)
        Me.txtPresupuesto.Name = "txtPresupuesto"
        Me.txtPresupuesto.Size = New System.Drawing.Size(231, 20)
        Me.txtPresupuesto.TabIndex = 14
        Me.ToolTip1.SetToolTip(Me.txtPresupuesto, "Apriete Enter despues de ingresar  los datos")
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(45, 465)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(159, 42)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "No se encontraron" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "resultados"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label5.Visible = False
        '
        'txtCUIT
        '
        Me.txtCUIT.Location = New System.Drawing.Point(9, 195)
        Me.txtCUIT.Name = "txtCUIT"
        Me.txtCUIT.Size = New System.Drawing.Size(231, 20)
        Me.txtCUIT.TabIndex = 9
        Me.ToolTip1.SetToolTip(Me.txtCUIT, "Apriete Enter despues de ingresar  los datos")
        '
        'txtDireccion
        '
        Me.txtDireccion.Location = New System.Drawing.Point(6, 145)
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.Size = New System.Drawing.Size(231, 20)
        Me.txtDireccion.TabIndex = 7
        Me.ToolTip1.SetToolTip(Me.txtDireccion, "Apriete Enter despues de ingresar  los datos")
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(6, 106)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(231, 20)
        Me.txtNombre.TabIndex = 5
        Me.ToolTip1.SetToolTip(Me.txtNombre, "Apriete Enter despues de ingresar  los datos")
        '
        'txtCodigo
        '
        Me.txtCodigo.Location = New System.Drawing.Point(6, 67)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(231, 20)
        Me.txtCodigo.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.txtCodigo, "Apriete Enter despues de ingresar  los datos")
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToDeleteRows = False
        Me.dgv.AllowUserToResizeRows = False
        Me.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.ContextMenuStrip = Me.ContextMenuStrip1
        Me.dgv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv.Location = New System.Drawing.Point(0, 0)
        Me.dgv.Name = "dgv"
        Me.dgv.ReadOnly = True
        Me.dgv.RowHeadersVisible = False
        Me.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv.Size = New System.Drawing.Size(690, 516)
        Me.dgv.TabIndex = 0
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DatosClienteToolStripMenuItem, Me.TerceroPagadorToolStripMenuItem, Me.IntervencionesToolStripMenuItem, Me.ToolStripMenuItem1, Me.PedidosToolStripMenuItem, Me.PresupuestosToolStripMenuItem, Me.FacturasToolStripMenuItem1, Me.ParqueDelClienteToolStripMenuItem, Me.RemitosToolStripMenuItem, Me.ConsorciosToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(193, 224)
        '
        'DatosClienteToolStripMenuItem
        '
        Me.DatosClienteToolStripMenuItem.Name = "DatosClienteToolStripMenuItem"
        Me.DatosClienteToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.DatosClienteToolStripMenuItem.Text = "Datos cliente"
        '
        'TerceroPagadorToolStripMenuItem
        '
        Me.TerceroPagadorToolStripMenuItem.Name = "TerceroPagadorToolStripMenuItem"
        Me.TerceroPagadorToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.TerceroPagadorToolStripMenuItem.Text = "Tercero Pagador"
        '
        'IntervencionesToolStripMenuItem
        '
        Me.IntervencionesToolStripMenuItem.Name = "IntervencionesToolStripMenuItem"
        Me.IntervencionesToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.IntervencionesToolStripMenuItem.Text = "Intervenciones"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(192, 22)
        Me.ToolStripMenuItem1.Text = "Intervenciones Totales"
        '
        'PedidosToolStripMenuItem
        '
        Me.PedidosToolStripMenuItem.Name = "PedidosToolStripMenuItem"
        Me.PedidosToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.PedidosToolStripMenuItem.Text = "Pedidos"
        '
        'PresupuestosToolStripMenuItem
        '
        Me.PresupuestosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PresupuestoPorSucursalToolStripMenuItem, Me.PresupuestoPorClienteToolStripMenuItem})
        Me.PresupuestosToolStripMenuItem.Name = "PresupuestosToolStripMenuItem"
        Me.PresupuestosToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.PresupuestosToolStripMenuItem.Text = "Presupuestos"
        '
        'PresupuestoPorSucursalToolStripMenuItem
        '
        Me.PresupuestoPorSucursalToolStripMenuItem.Name = "PresupuestoPorSucursalToolStripMenuItem"
        Me.PresupuestoPorSucursalToolStripMenuItem.Size = New System.Drawing.Size(206, 22)
        Me.PresupuestoPorSucursalToolStripMenuItem.Text = "presupuesto por sucursal"
        '
        'PresupuestoPorClienteToolStripMenuItem
        '
        Me.PresupuestoPorClienteToolStripMenuItem.Name = "PresupuestoPorClienteToolStripMenuItem"
        Me.PresupuestoPorClienteToolStripMenuItem.Size = New System.Drawing.Size(206, 22)
        Me.PresupuestoPorClienteToolStripMenuItem.Text = "presupuesto por cliente"
        '
        'FacturasToolStripMenuItem1
        '
        Me.FacturasToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FacturasDeLaSucursalToolStripMenuItem, Me.FacturasDelClienteToolStripMenuItem})
        Me.FacturasToolStripMenuItem1.Name = "FacturasToolStripMenuItem1"
        Me.FacturasToolStripMenuItem1.Size = New System.Drawing.Size(192, 22)
        Me.FacturasToolStripMenuItem1.Text = "Facturas"
        '
        'FacturasDeLaSucursalToolStripMenuItem
        '
        Me.FacturasDeLaSucursalToolStripMenuItem.Name = "FacturasDeLaSucursalToolStripMenuItem"
        Me.FacturasDeLaSucursalToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.FacturasDeLaSucursalToolStripMenuItem.Text = "Facturas de la sucursal"
        '
        'FacturasDelClienteToolStripMenuItem
        '
        Me.FacturasDelClienteToolStripMenuItem.Name = "FacturasDelClienteToolStripMenuItem"
        Me.FacturasDelClienteToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.FacturasDelClienteToolStripMenuItem.Text = "Facturas del cliente"
        '
        'ParqueDelClienteToolStripMenuItem
        '
        Me.ParqueDelClienteToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ParqueDeLaSucursalToolStripMenuItem, Me.ParqueGeneralToolStripMenuItem})
        Me.ParqueDelClienteToolStripMenuItem.Name = "ParqueDelClienteToolStripMenuItem"
        Me.ParqueDelClienteToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.ParqueDelClienteToolStripMenuItem.Text = "Parque del cliente"
        '
        'ParqueDeLaSucursalToolStripMenuItem
        '
        Me.ParqueDeLaSucursalToolStripMenuItem.Name = "ParqueDeLaSucursalToolStripMenuItem"
        Me.ParqueDeLaSucursalToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.ParqueDeLaSucursalToolStripMenuItem.Text = "Parque de la sucursal"
        '
        'ParqueGeneralToolStripMenuItem
        '
        Me.ParqueGeneralToolStripMenuItem.Name = "ParqueGeneralToolStripMenuItem"
        Me.ParqueGeneralToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.ParqueGeneralToolStripMenuItem.Text = "Parque general"
        '
        'RemitosToolStripMenuItem
        '
        Me.RemitosToolStripMenuItem.Name = "RemitosToolStripMenuItem"
        Me.RemitosToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.RemitosToolStripMenuItem.Text = "Remitos"
        '
        'ConsorciosToolStripMenuItem
        '
        Me.ConsorciosToolStripMenuItem.Name = "ConsorciosToolStripMenuItem"
        Me.ConsorciosToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.ConsorciosToolStripMenuItem.Text = "Consorcios"
        '
        'btnBuscarCilindro
        '
        Me.btnBuscarCilindro.Location = New System.Drawing.Point(12, 268)
        Me.btnBuscarCilindro.Name = "btnBuscarCilindro"
        Me.btnBuscarCilindro.Size = New System.Drawing.Size(228, 23)
        Me.btnBuscarCilindro.TabIndex = 12
        Me.btnBuscarCilindro.Text = "Buscar Cilindro"
        Me.btnBuscarCilindro.UseVisualStyleBackColor = True
        '
        'frmBuscaClientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(943, 516)
        Me.Controls.Add(Me.SplitContainer1)
        Me.KeyPreview = True
        Me.Name = "frmBuscaClientes"
        Me.Tag = "frmbuscaclientes"
        Me.Text = "Buscador de clientes"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents txtCUIT As System.Windows.Forms.TextBox
    Friend WithEvents txtDireccion As System.Windows.Forms.TextBox
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtPresupuesto As System.Windows.Forms.TextBox
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DatosClienteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtfantasia As System.Windows.Forms.TextBox
    Friend WithEvents IntervencionesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PedidosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PresupuestosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FacturasToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FacturasDeLaSucursalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FacturasDelClienteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConsorciosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ParqueDelClienteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ParqueDeLaSucursalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ParqueGeneralToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtLoc As System.Windows.Forms.TextBox
    Friend WithEvents cboprov As System.Windows.Forms.ComboBox
    Friend WithEvents btnProv As System.Windows.Forms.Button
    Friend WithEvents RemitosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TerceroPagadorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PresupuestoPorSucursalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PresupuestoPorClienteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents txtMail As System.Windows.Forms.TextBox
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnBuscarCilindro As System.Windows.Forms.Button

End Class
