<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLicitacion
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
        Me.dgv = New System.Windows.Forms.DataGridView
        Me.colNro = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colLig = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCliente = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colNombre = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colDomicilio = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colTipo = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.colLicitacion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colFechaPresupuesto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colNumeroPresupuesto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colPrecio = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colNuevo = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.colService = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.colAgua = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.colDeteccion = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.colVendedor = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colApertura = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCompras = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colEstado = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.colFechaAdjudicacion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colObs = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.btnBuscar = New System.Windows.Forms.Button
        Me.chkEstados = New System.Windows.Forms.CheckedListBox
        Me.btnExtras = New System.Windows.Forms.Button
        Me.btnFix = New System.Windows.Forms.Button
        Me.btnDetalle = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnAgregar = New System.Windows.Forms.Button
        Me.txtLicitacion = New System.Windows.Forms.TextBox
        Me.cboTipoLicitacion = New System.Windows.Forms.ComboBox
        Me.txtPresupuesto = New System.Windows.Forms.TextBox
        Me.btnGrabar = New System.Windows.Forms.Button
        Label1 = New System.Windows.Forms.Label
        Label2 = New System.Windows.Forms.Label
        Label3 = New System.Windows.Forms.Label
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(6, 16)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(66, 13)
        Label1.TabIndex = 3
        Label1.Text = "Presupuesto"
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Location = New System.Drawing.Point(122, 16)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(76, 13)
        Label2.TabIndex = 4
        Label2.Text = "Tipo Licitación"
        '
        'Label3
        '
        Label3.AutoSize = True
        Label3.Location = New System.Drawing.Point(249, 16)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(92, 13)
        Label3.TabIndex = 5
        Label3.Text = "Número Licitación"
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colNro, Me.colLig, Me.colCliente, Me.colNombre, Me.colDomicilio, Me.colTipo, Me.colLicitacion, Me.colFechaPresupuesto, Me.colNumeroPresupuesto, Me.colPrecio, Me.colNuevo, Me.colService, Me.colAgua, Me.colDeteccion, Me.colVendedor, Me.colApertura, Me.colCompras, Me.colEstado, Me.colFechaAdjudicacion, Me.colObs})
        Me.dgv.Location = New System.Drawing.Point(0, 0)
        Me.dgv.Name = "dgv"
        Me.dgv.Size = New System.Drawing.Size(814, 350)
        Me.dgv.TabIndex = 0
        '
        'colNro
        '
        Me.colNro.HeaderText = "Nro"
        Me.colNro.Name = "colNro"
        Me.colNro.ReadOnly = True
        Me.colNro.Visible = False
        '
        'colLig
        '
        Me.colLig.HeaderText = "Linea"
        Me.colLig.Name = "colLig"
        Me.colLig.Visible = False
        '
        'colCliente
        '
        Me.colCliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colCliente.HeaderText = "Cliente"
        Me.colCliente.Name = "colCliente"
        Me.colCliente.ReadOnly = True
        Me.colCliente.Width = 64
        '
        'colNombre
        '
        Me.colNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colNombre.HeaderText = "Nombre"
        Me.colNombre.Name = "colNombre"
        Me.colNombre.ReadOnly = True
        Me.colNombre.Width = 69
        '
        'colDomicilio
        '
        Me.colDomicilio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colDomicilio.HeaderText = "Domicilio"
        Me.colDomicilio.Name = "colDomicilio"
        Me.colDomicilio.ReadOnly = True
        Me.colDomicilio.Width = 74
        '
        'colTipo
        '
        Me.colTipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colTipo.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.colTipo.HeaderText = "Tipo"
        Me.colTipo.Name = "colTipo"
        Me.colTipo.ReadOnly = True
        Me.colTipo.Width = 34
        '
        'colLicitacion
        '
        Me.colLicitacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colLicitacion.HeaderText = "Licitacion"
        Me.colLicitacion.Name = "colLicitacion"
        Me.colLicitacion.ReadOnly = True
        Me.colLicitacion.Width = 77
        '
        'colFechaPresupuesto
        '
        Me.colFechaPresupuesto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colFechaPresupuesto.HeaderText = "Fecha Presupuesto"
        Me.colFechaPresupuesto.Name = "colFechaPresupuesto"
        Me.colFechaPresupuesto.ReadOnly = True
        Me.colFechaPresupuesto.Width = 114
        '
        'colNumeroPresupuesto
        '
        Me.colNumeroPresupuesto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colNumeroPresupuesto.HeaderText = "Presupuesto"
        Me.colNumeroPresupuesto.Name = "colNumeroPresupuesto"
        Me.colNumeroPresupuesto.ReadOnly = True
        Me.colNumeroPresupuesto.Width = 91
        '
        'colPrecio
        '
        Me.colPrecio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Format = "N2"
        Me.colPrecio.DefaultCellStyle = DataGridViewCellStyle1
        Me.colPrecio.HeaderText = "Precio"
        Me.colPrecio.Name = "colPrecio"
        Me.colPrecio.ReadOnly = True
        Me.colPrecio.Width = 62
        '
        'colNuevo
        '
        Me.colNuevo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colNuevo.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.colNuevo.HeaderText = "Nuevo"
        Me.colNuevo.Name = "colNuevo"
        Me.colNuevo.ReadOnly = True
        Me.colNuevo.Width = 45
        '
        'colService
        '
        Me.colService.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colService.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.colService.HeaderText = "Service"
        Me.colService.Name = "colService"
        Me.colService.ReadOnly = True
        Me.colService.Width = 49
        '
        'colAgua
        '
        Me.colAgua.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colAgua.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.colAgua.HeaderText = "Agua"
        Me.colAgua.Name = "colAgua"
        Me.colAgua.ReadOnly = True
        Me.colAgua.Width = 38
        '
        'colDeteccion
        '
        Me.colDeteccion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colDeteccion.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.colDeteccion.HeaderText = "Deteccion"
        Me.colDeteccion.Name = "colDeteccion"
        Me.colDeteccion.ReadOnly = True
        Me.colDeteccion.Width = 62
        '
        'colVendedor
        '
        Me.colVendedor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colVendedor.HeaderText = "Vendedor"
        Me.colVendedor.Name = "colVendedor"
        Me.colVendedor.ReadOnly = True
        Me.colVendedor.Width = 78
        '
        'colApertura
        '
        Me.colApertura.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colApertura.HeaderText = "Apertura"
        Me.colApertura.Name = "colApertura"
        Me.colApertura.Width = 72
        '
        'colCompras
        '
        Me.colCompras.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colCompras.HeaderText = "Compras Elec."
        Me.colCompras.Name = "colCompras"
        Me.colCompras.Width = 92
        '
        'colEstado
        '
        Me.colEstado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colEstado.HeaderText = "Estado"
        Me.colEstado.Name = "colEstado"
        Me.colEstado.Width = 46
        '
        'colFechaAdjudicacion
        '
        Me.colFechaAdjudicacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colFechaAdjudicacion.HeaderText = "Fecha Adjudicacion"
        Me.colFechaAdjudicacion.Name = "colFechaAdjudicacion"
        Me.colFechaAdjudicacion.Width = 115
        '
        'colObs
        '
        Me.colObs.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colObs.HeaderText = "Obs"
        Me.colObs.Name = "colObs"
        Me.colObs.Width = 51
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnBuscar)
        Me.SplitContainer1.Panel1.Controls.Add(Me.chkEstados)
        Me.SplitContainer1.Panel1.Controls.Add(Me.dgv)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnExtras)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnFix)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnDetalle)
        Me.SplitContainer1.Panel2.Controls.Add(Me.GroupBox1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnGrabar)
        Me.SplitContainer1.Size = New System.Drawing.Size(972, 441)
        Me.SplitContainer1.SplitterDistance = 350
        Me.SplitContainer1.TabIndex = 1
        '
        'btnBuscar
        '
        Me.btnBuscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBuscar.Location = New System.Drawing.Point(820, 298)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(149, 49)
        Me.btnBuscar.TabIndex = 3
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'chkEstados
        '
        Me.chkEstados.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkEstados.FormattingEnabled = True
        Me.chkEstados.Location = New System.Drawing.Point(820, 3)
        Me.chkEstados.Name = "chkEstados"
        Me.chkEstados.Size = New System.Drawing.Size(149, 289)
        Me.chkEstados.TabIndex = 3
        '
        'btnExtras
        '
        Me.btnExtras.Location = New System.Drawing.Point(753, 23)
        Me.btnExtras.Name = "btnExtras"
        Me.btnExtras.Size = New System.Drawing.Size(75, 50)
        Me.btnExtras.TabIndex = 4
        Me.btnExtras.Text = "Extras"
        Me.btnExtras.UseVisualStyleBackColor = True
        '
        'btnFix
        '
        Me.btnFix.Location = New System.Drawing.Point(483, 24)
        Me.btnFix.Name = "btnFix"
        Me.btnFix.Size = New System.Drawing.Size(75, 50)
        Me.btnFix.TabIndex = 3
        Me.btnFix.Text = "Fix"
        Me.btnFix.UseVisualStyleBackColor = True
        Me.btnFix.Visible = False
        '
        'btnDetalle
        '
        Me.btnDetalle.Location = New System.Drawing.Point(672, 23)
        Me.btnDetalle.Name = "btnDetalle"
        Me.btnDetalle.Size = New System.Drawing.Size(75, 50)
        Me.btnDetalle.TabIndex = 2
        Me.btnDetalle.Text = "Líneas"
        Me.btnDetalle.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Label3)
        Me.GroupBox1.Controls.Add(Label2)
        Me.GroupBox1.Controls.Add(Label1)
        Me.GroupBox1.Controls.Add(Me.btnAgregar)
        Me.GroupBox1.Controls.Add(Me.txtLicitacion)
        Me.GroupBox1.Controls.Add(Me.cboTipoLicitacion)
        Me.GroupBox1.Controls.Add(Me.txtPresupuesto)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(465, 66)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'btnAgregar
        '
        Me.btnAgregar.Location = New System.Drawing.Point(365, 33)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(75, 23)
        Me.btnAgregar.TabIndex = 2
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'txtLicitacion
        '
        Me.txtLicitacion.Location = New System.Drawing.Point(249, 33)
        Me.txtLicitacion.Name = "txtLicitacion"
        Me.txtLicitacion.Size = New System.Drawing.Size(110, 20)
        Me.txtLicitacion.TabIndex = 2
        '
        'cboTipoLicitacion
        '
        Me.cboTipoLicitacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoLicitacion.FormattingEnabled = True
        Me.cboTipoLicitacion.Location = New System.Drawing.Point(122, 32)
        Me.cboTipoLicitacion.Name = "cboTipoLicitacion"
        Me.cboTipoLicitacion.Size = New System.Drawing.Size(121, 21)
        Me.cboTipoLicitacion.TabIndex = 1
        '
        'txtPresupuesto
        '
        Me.txtPresupuesto.Location = New System.Drawing.Point(6, 32)
        Me.txtPresupuesto.Name = "txtPresupuesto"
        Me.txtPresupuesto.Size = New System.Drawing.Size(110, 20)
        Me.txtPresupuesto.TabIndex = 0
        '
        'btnGrabar
        '
        Me.btnGrabar.Location = New System.Drawing.Point(885, 23)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(75, 51)
        Me.btnGrabar.TabIndex = 0
        Me.btnGrabar.Text = "Grabar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'frmLicitacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(972, 441)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "frmLicitacion"
        Me.Text = "Licitación"
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents txtLicitacion As System.Windows.Forms.TextBox
    Friend WithEvents txtPresupuesto As System.Windows.Forms.TextBox
    Friend WithEvents btnDetalle As System.Windows.Forms.Button
    Friend WithEvents cboTipoLicitacion As System.Windows.Forms.ComboBox
    Friend WithEvents chkEstados As System.Windows.Forms.CheckedListBox
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents btnFix As System.Windows.Forms.Button
    Friend WithEvents colNro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colLig As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDomicilio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTipo As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colLicitacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFechaPresupuesto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNumeroPresupuesto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPrecio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNuevo As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colService As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colAgua As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colDeteccion As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colVendedor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colApertura As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCompras As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colEstado As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colFechaAdjudicacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colObs As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnExtras As System.Windows.Forms.Button
End Class
