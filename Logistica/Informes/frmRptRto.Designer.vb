<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRptRto
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtboxTotal = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtVen = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtServ = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtMos = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtArch = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtLog = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtIng = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtDepo = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtCon = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtCal = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtAdm = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtAbono = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.dgv = New System.Windows.Forms.DataGridView
        Me.Menu1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ObservacionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.VerRemitoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SeguimientoDeDocumentacionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.VerRemitoEscaneadoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.btnCalcular = New System.Windows.Forms.Button
        Me.titulo = New System.Windows.Forms.Label
        Me.lblTitulo = New System.Windows.Forms.Label
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Numero = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colPedido = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cliente = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Direccion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Vendedor = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.importe = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Sector = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FechaEnvio = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Ruta = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FechaRuta = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.observa = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Menu1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtboxTotal)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.txtVen)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.txtServ)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.txtMos)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtArch)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtLog)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtIng)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtDepo)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtCon)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtCal)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtAdm)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtAbono)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 47)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(166, 350)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Sectores"
        '
        'txtboxTotal
        '
        Me.txtboxTotal.Location = New System.Drawing.Point(87, 320)
        Me.txtboxTotal.Name = "txtboxTotal"
        Me.txtboxTotal.ReadOnly = True
        Me.txtboxTotal.Size = New System.Drawing.Size(70, 20)
        Me.txtboxTotal.TabIndex = 23
        Me.txtboxTotal.TabStop = False
        Me.txtboxTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(5, 323)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(76, 13)
        Me.Label12.TabIndex = 22
        Me.Label12.Text = "Cantidad Total"
        '
        'txtVen
        '
        Me.txtVen.Location = New System.Drawing.Point(87, 71)
        Me.txtVen.Name = "txtVen"
        Me.txtVen.ReadOnly = True
        Me.txtVen.Size = New System.Drawing.Size(70, 20)
        Me.txtVen.TabIndex = 5
        Me.txtVen.TabStop = False
        Me.txtVen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(5, 74)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(40, 13)
        Me.Label11.TabIndex = 4
        Me.Label11.Text = "Ventas"
        '
        'txtServ
        '
        Me.txtServ.Location = New System.Drawing.Point(87, 279)
        Me.txtServ.Name = "txtServ"
        Me.txtServ.ReadOnly = True
        Me.txtServ.Size = New System.Drawing.Size(70, 20)
        Me.txtServ.TabIndex = 21
        Me.txtServ.TabStop = False
        Me.txtServ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(5, 282)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(43, 13)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "Service"
        '
        'txtMos
        '
        Me.txtMos.Location = New System.Drawing.Point(87, 97)
        Me.txtMos.Name = "txtMos"
        Me.txtMos.ReadOnly = True
        Me.txtMos.Size = New System.Drawing.Size(70, 20)
        Me.txtMos.TabIndex = 7
        Me.txtMos.TabStop = False
        Me.txtMos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(5, 100)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(54, 13)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "Mostrador"
        '
        'txtArch
        '
        Me.txtArch.Location = New System.Drawing.Point(87, 253)
        Me.txtArch.Name = "txtArch"
        Me.txtArch.ReadOnly = True
        Me.txtArch.Size = New System.Drawing.Size(70, 20)
        Me.txtArch.TabIndex = 19
        Me.txtArch.TabStop = False
        Me.txtArch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(5, 256)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Archivo"
        '
        'txtLog
        '
        Me.txtLog.Location = New System.Drawing.Point(87, 123)
        Me.txtLog.Name = "txtLog"
        Me.txtLog.ReadOnly = True
        Me.txtLog.Size = New System.Drawing.Size(70, 20)
        Me.txtLog.TabIndex = 9
        Me.txtLog.TabStop = False
        Me.txtLog.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(5, 126)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(49, 13)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Logistica"
        '
        'txtIng
        '
        Me.txtIng.Location = New System.Drawing.Point(87, 175)
        Me.txtIng.Name = "txtIng"
        Me.txtIng.ReadOnly = True
        Me.txtIng.Size = New System.Drawing.Size(70, 20)
        Me.txtIng.TabIndex = 13
        Me.txtIng.TabStop = False
        Me.txtIng.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(5, 178)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Ingenieria"
        '
        'txtDepo
        '
        Me.txtDepo.Location = New System.Drawing.Point(87, 227)
        Me.txtDepo.Name = "txtDepo"
        Me.txtDepo.ReadOnly = True
        Me.txtDepo.Size = New System.Drawing.Size(70, 20)
        Me.txtDepo.TabIndex = 17
        Me.txtDepo.TabStop = False
        Me.txtDepo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(5, 230)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 13)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Deposito"
        '
        'txtCon
        '
        Me.txtCon.Location = New System.Drawing.Point(87, 45)
        Me.txtCon.Name = "txtCon"
        Me.txtCon.ReadOnly = True
        Me.txtCon.Size = New System.Drawing.Size(70, 20)
        Me.txtCon.TabIndex = 3
        Me.txtCon.TabStop = False
        Me.txtCon.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(5, 48)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Contado"
        '
        'txtCal
        '
        Me.txtCal.Location = New System.Drawing.Point(87, 201)
        Me.txtCal.Name = "txtCal"
        Me.txtCal.ReadOnly = True
        Me.txtCal.Size = New System.Drawing.Size(70, 20)
        Me.txtCal.TabIndex = 15
        Me.txtCal.TabStop = False
        Me.txtCal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(5, 204)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 13)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Calidad"
        '
        'txtAdm
        '
        Me.txtAdm.Location = New System.Drawing.Point(87, 19)
        Me.txtAdm.Name = "txtAdm"
        Me.txtAdm.ReadOnly = True
        Me.txtAdm.Size = New System.Drawing.Size(70, 20)
        Me.txtAdm.TabIndex = 1
        Me.txtAdm.TabStop = False
        Me.txtAdm.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(5, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Administracion"
        '
        'txtAbono
        '
        Me.txtAbono.Location = New System.Drawing.Point(87, 149)
        Me.txtAbono.Name = "txtAbono"
        Me.txtAbono.ReadOnly = True
        Me.txtAbono.Size = New System.Drawing.Size(70, 20)
        Me.txtAbono.TabIndex = 11
        Me.txtAbono.TabStop = False
        Me.txtAbono.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 152)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Abono"
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToDeleteRows = False
        Me.dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Fecha, Me.Numero, Me.colPedido, Me.Cliente, Me.Direccion, Me.Vendedor, Me.importe, Me.Sector, Me.FechaEnvio, Me.Ruta, Me.FechaRuta, Me.observa})
        Me.dgv.ContextMenuStrip = Me.Menu1
        Me.dgv.Location = New System.Drawing.Point(184, 47)
        Me.dgv.Name = "dgv"
        Me.dgv.ReadOnly = True
        Me.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv.Size = New System.Drawing.Size(819, 350)
        Me.dgv.TabIndex = 4
        Me.dgv.TabStop = False
        '
        'Menu1
        '
        Me.Menu1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ObservacionesToolStripMenuItem, Me.VerRemitoToolStripMenuItem, Me.SeguimientoDeDocumentacionToolStripMenuItem, Me.VerRemitoEscaneadoToolStripMenuItem})
        Me.Menu1.Name = "Menu"
        Me.Menu1.Size = New System.Drawing.Size(246, 92)
        '
        'ObservacionesToolStripMenuItem
        '
        Me.ObservacionesToolStripMenuItem.Name = "ObservacionesToolStripMenuItem"
        Me.ObservacionesToolStripMenuItem.Size = New System.Drawing.Size(245, 22)
        Me.ObservacionesToolStripMenuItem.Text = "Observaciones"
        '
        'VerRemitoToolStripMenuItem
        '
        Me.VerRemitoToolStripMenuItem.Name = "VerRemitoToolStripMenuItem"
        Me.VerRemitoToolStripMenuItem.Size = New System.Drawing.Size(245, 22)
        Me.VerRemitoToolStripMenuItem.Text = "Ver remito"
        '
        'SeguimientoDeDocumentacionToolStripMenuItem
        '
        Me.SeguimientoDeDocumentacionToolStripMenuItem.Name = "SeguimientoDeDocumentacionToolStripMenuItem"
        Me.SeguimientoDeDocumentacionToolStripMenuItem.Size = New System.Drawing.Size(245, 22)
        Me.SeguimientoDeDocumentacionToolStripMenuItem.Text = "Seguimiento de Documentacion"
        '
        'VerRemitoEscaneadoToolStripMenuItem
        '
        Me.VerRemitoEscaneadoToolStripMenuItem.Name = "VerRemitoEscaneadoToolStripMenuItem"
        Me.VerRemitoEscaneadoToolStripMenuItem.Size = New System.Drawing.Size(245, 22)
        Me.VerRemitoEscaneadoToolStripMenuItem.Text = "Ver Remito Escaneado"
        '
        'btnCalcular
        '
        Me.btnCalcular.Location = New System.Drawing.Point(12, 18)
        Me.btnCalcular.Name = "btnCalcular"
        Me.btnCalcular.Size = New System.Drawing.Size(166, 23)
        Me.btnCalcular.TabIndex = 0
        Me.btnCalcular.Text = "Calcular"
        Me.btnCalcular.UseVisualStyleBackColor = True
        '
        'titulo
        '
        Me.titulo.AutoSize = True
        Me.titulo.Location = New System.Drawing.Point(271, 11)
        Me.titulo.Name = "titulo"
        Me.titulo.Size = New System.Drawing.Size(0, 13)
        Me.titulo.TabIndex = 2
        Me.titulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.Location = New System.Drawing.Point(277, 23)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(701, 13)
        Me.lblTitulo.TabIndex = 3
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Fecha
        '
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.ReadOnly = True
        '
        'Numero
        '
        Me.Numero.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Numero.HeaderText = "Numero"
        Me.Numero.Name = "Numero"
        Me.Numero.ReadOnly = True
        Me.Numero.Width = 69
        '
        'colPedido
        '
        Me.colPedido.HeaderText = "Pedido"
        Me.colPedido.Name = "colPedido"
        Me.colPedido.ReadOnly = True
        '
        'Cliente
        '
        Me.Cliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Cliente.HeaderText = "Cliente"
        Me.Cliente.Name = "Cliente"
        Me.Cliente.ReadOnly = True
        Me.Cliente.Width = 64
        '
        'Direccion
        '
        Me.Direccion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Direccion.HeaderText = "Direccion"
        Me.Direccion.Name = "Direccion"
        Me.Direccion.ReadOnly = True
        Me.Direccion.Width = 77
        '
        'Vendedor
        '
        Me.Vendedor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.Vendedor.HeaderText = "Vendedor"
        Me.Vendedor.Name = "Vendedor"
        Me.Vendedor.ReadOnly = True
        Me.Vendedor.Width = 78
        '
        'importe
        '
        Me.importe.HeaderText = "importe"
        Me.importe.Name = "importe"
        Me.importe.ReadOnly = True
        '
        'Sector
        '
        Me.Sector.HeaderText = "Sector"
        Me.Sector.Name = "Sector"
        Me.Sector.ReadOnly = True
        Me.Sector.Visible = False
        '
        'FechaEnvio
        '
        Me.FechaEnvio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.FechaEnvio.HeaderText = "Fecha de Envio"
        Me.FechaEnvio.Name = "FechaEnvio"
        Me.FechaEnvio.ReadOnly = True
        Me.FechaEnvio.Width = 74
        '
        'Ruta
        '
        Me.Ruta.HeaderText = "Ruta"
        Me.Ruta.Name = "Ruta"
        Me.Ruta.ReadOnly = True
        '
        'FechaRuta
        '
        Me.FechaRuta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.FechaRuta.HeaderText = "Fecha de Ruta"
        Me.FechaRuta.Name = "FechaRuta"
        Me.FechaRuta.ReadOnly = True
        Me.FechaRuta.Width = 74
        '
        'observa
        '
        Me.observa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.observa.HeaderText = "Comentarios"
        Me.observa.Name = "observa"
        Me.observa.ReadOnly = True
        Me.observa.Width = 90
        '
        'frmRptRto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1026, 416)
        Me.Controls.Add(Me.lblTitulo)
        Me.Controls.Add(Me.titulo)
        Me.Controls.Add(Me.btnCalcular)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgv)
        Me.Name = "frmRptRto"
        Me.Text = "Reporte Remitos sin Despachar"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Menu1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents btnCalcular As System.Windows.Forms.Button
    Friend WithEvents txtServ As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtMos As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtLog As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtIng As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtDepo As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtCon As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtCal As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtAdm As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtArch As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtAbono As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtVen As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents titulo As System.Windows.Forms.Label
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents Menu1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ObservacionesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtboxTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents VerRemitoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SeguimientoDeDocumentacionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VerRemitoEscaneadoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Numero As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPedido As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Direccion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Vendedor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents importe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Sector As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaEnvio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Ruta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaRuta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents observa As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
