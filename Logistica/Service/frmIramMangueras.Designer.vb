<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmIramMangueras
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
        Dim Label3 As System.Windows.Forms.Label
        Dim Label2 As System.Windows.Forms.Label
        Dim Label1 As System.Windows.Forms.Label
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.dgv = New System.Windows.Forms.DataGridView
        Me.colDiametro = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.colLargo = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.colMarca = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.colTipo = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.colNro = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colLargoReal = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colIram = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colPresion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colOk = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.colPuesto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colObs = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colSerie = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colSolicitud = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colIntervencion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colUsuario = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnRegistrar = New System.Windows.Forms.Button
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.mnuAcciones = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuAbrir = New System.Windows.Forms.ToolStripMenuItem
        Me.txtSucursal = New System.Windows.Forms.TextBox
        Me.txtCodigo = New System.Windows.Forms.TextBox
        Me.txtDireccion = New System.Windows.Forms.TextBox
        Me.txtNombre = New System.Windows.Forms.TextBox
        Me.txtIntervencion = New System.Windows.Forms.TextBox
        Me.btnIram = New System.Windows.Forms.Button
        Label3 = New System.Windows.Forms.Label
        Label2 = New System.Windows.Forms.Label
        Label1 = New System.Windows.Forms.Label
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label3
        '
        Label3.AutoSize = True
        Label3.Location = New System.Drawing.Point(238, 43)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(51, 13)
        Label3.TabIndex = 18
        Label3.Text = "Sucursal:"
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Location = New System.Drawing.Point(238, 15)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(42, 13)
        Label2.TabIndex = 15
        Label2.Text = "Cliente:"
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(11, 15)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(69, 13)
        Label1.TabIndex = 13
        Label1.Text = "Intervención:"
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToDeleteRows = False
        Me.dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colDiametro, Me.colLargo, Me.colMarca, Me.colTipo, Me.colNro, Me.colLargoReal, Me.colIram, Me.colPresion, Me.colOk, Me.colPuesto, Me.colObs, Me.colSerie, Me.colSolicitud, Me.colIntervencion, Me.colUsuario})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgv.Location = New System.Drawing.Point(12, 66)
        Me.dgv.Name = "dgv"
        Me.dgv.Size = New System.Drawing.Size(991, 352)
        Me.dgv.TabIndex = 0
        '
        'colDiametro
        '
        Me.colDiametro.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.colDiametro.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.colDiametro.HeaderText = "Diametro"
        Me.colDiametro.Name = "colDiametro"
        Me.colDiametro.ReadOnly = True
        Me.colDiametro.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colDiametro.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colDiametro.Width = 74
        '
        'colLargo
        '
        Me.colLargo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.colLargo.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.colLargo.HeaderText = "Largo Nominal"
        Me.colLargo.Name = "colLargo"
        Me.colLargo.ReadOnly = True
        Me.colLargo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colLargo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'colMarca
        '
        Me.colMarca.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.colMarca.HeaderText = "Marca"
        Me.colMarca.Name = "colMarca"
        Me.colMarca.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colMarca.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colMarca.Width = 62
        '
        'colTipo
        '
        Me.colTipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.colTipo.HeaderText = "Tipo"
        Me.colTipo.Name = "colTipo"
        Me.colTipo.Width = 34
        '
        'colNro
        '
        Me.colNro.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.colNro.HeaderText = "Nro"
        Me.colNro.Name = "colNro"
        Me.colNro.Width = 49
        '
        'colLargoReal
        '
        Me.colLargoReal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.colLargoReal.HeaderText = "Largo Real"
        Me.colLargoReal.Name = "colLargoReal"
        Me.colLargoReal.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colLargoReal.Width = 84
        '
        'colIram
        '
        Me.colIram.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.colIram.HeaderText = "Iram"
        Me.colIram.Name = "colIram"
        Me.colIram.Width = 52
        '
        'colPresion
        '
        Me.colPresion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.colPresion.HeaderText = "Presion"
        Me.colPresion.Name = "colPresion"
        Me.colPresion.Width = 67
        '
        'colOk
        '
        Me.colOk.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.colOk.HeaderText = "Ok"
        Me.colOk.Name = "colOk"
        Me.colOk.Width = 27
        '
        'colPuesto
        '
        Me.colPuesto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.colPuesto.HeaderText = "Puesto"
        Me.colPuesto.Name = "colPuesto"
        Me.colPuesto.Width = 65
        '
        'colObs
        '
        Me.colObs.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colObs.DefaultCellStyle = DataGridViewCellStyle2
        Me.colObs.HeaderText = "Obs"
        Me.colObs.MaxInputLength = 100
        Me.colObs.Name = "colObs"
        Me.colObs.Width = 51
        '
        'colSerie
        '
        Me.colSerie.HeaderText = "Serie"
        Me.colSerie.Name = "colSerie"
        Me.colSerie.Visible = False
        '
        'colSolicitud
        '
        Me.colSolicitud.HeaderText = "Solicitud"
        Me.colSolicitud.Name = "colSolicitud"
        Me.colSolicitud.Visible = False
        '
        'colIntervencion
        '
        Me.colIntervencion.HeaderText = "Intervencion"
        Me.colIntervencion.Name = "colIntervencion"
        Me.colIntervencion.Visible = False
        '
        'colUsuario
        '
        Me.colUsuario.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.colUsuario.HeaderText = "Usuario"
        Me.colUsuario.Name = "colUsuario"
        Me.colUsuario.Visible = False
        '
        'btnRegistrar
        '
        Me.btnRegistrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRegistrar.Location = New System.Drawing.Point(928, 424)
        Me.btnRegistrar.Name = "btnRegistrar"
        Me.btnRegistrar.Size = New System.Drawing.Size(75, 23)
        Me.btnRegistrar.TabIndex = 2
        Me.btnRegistrar.Text = "Registrar"
        Me.btnRegistrar.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuAcciones})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1015, 24)
        Me.MenuStrip1.TabIndex = 3
        Me.MenuStrip1.Text = "MenuStrip1"
        Me.MenuStrip1.Visible = False
        '
        'mnuAcciones
        '
        Me.mnuAcciones.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.mnuAcciones.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuAbrir})
        Me.mnuAcciones.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.mnuAcciones.ForeColor = System.Drawing.SystemColors.ControlText
        Me.mnuAcciones.MergeIndex = 6
        Me.mnuAcciones.Name = "mnuAcciones"
        Me.mnuAcciones.Size = New System.Drawing.Size(61, 20)
        Me.mnuAcciones.Text = "Acciones"
        '
        'mnuAbrir
        '
        Me.mnuAbrir.Name = "mnuAbrir"
        Me.mnuAbrir.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.mnuAbrir.Size = New System.Drawing.Size(192, 22)
        Me.mnuAbrir.Text = "Abrir Intervención..."
        '
        'txtSucursal
        '
        Me.txtSucursal.Location = New System.Drawing.Point(351, 12)
        Me.txtSucursal.Name = "txtSucursal"
        Me.txtSucursal.ReadOnly = True
        Me.txtSucursal.Size = New System.Drawing.Size(35, 20)
        Me.txtSucursal.TabIndex = 20
        Me.txtSucursal.TabStop = False
        '
        'txtCodigo
        '
        Me.txtCodigo.Location = New System.Drawing.Point(295, 12)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.ReadOnly = True
        Me.txtCodigo.Size = New System.Drawing.Size(50, 20)
        Me.txtCodigo.TabIndex = 16
        Me.txtCodigo.TabStop = False
        '
        'txtDireccion
        '
        Me.txtDireccion.Location = New System.Drawing.Point(295, 40)
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.ReadOnly = True
        Me.txtDireccion.Size = New System.Drawing.Size(269, 20)
        Me.txtDireccion.TabIndex = 19
        Me.txtDireccion.TabStop = False
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(392, 12)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.ReadOnly = True
        Me.txtNombre.Size = New System.Drawing.Size(172, 20)
        Me.txtNombre.TabIndex = 17
        Me.txtNombre.TabStop = False
        '
        'txtIntervencion
        '
        Me.txtIntervencion.Location = New System.Drawing.Point(86, 12)
        Me.txtIntervencion.Name = "txtIntervencion"
        Me.txtIntervencion.ReadOnly = True
        Me.txtIntervencion.Size = New System.Drawing.Size(88, 20)
        Me.txtIntervencion.TabIndex = 14
        Me.txtIntervencion.TabStop = False
        '
        'btnIram
        '
        Me.btnIram.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnIram.Location = New System.Drawing.Point(847, 424)
        Me.btnIram.Name = "btnIram"
        Me.btnIram.Size = New System.Drawing.Size(75, 23)
        Me.btnIram.TabIndex = 21
        Me.btnIram.Text = "Iram"
        Me.btnIram.UseVisualStyleBackColor = True
        '
        'frmIramMangueras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1015, 459)
        Me.Controls.Add(Me.btnIram)
        Me.Controls.Add(Me.txtSucursal)
        Me.Controls.Add(Me.txtCodigo)
        Me.Controls.Add(Me.txtDireccion)
        Me.Controls.Add(Label3)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Label2)
        Me.Controls.Add(Me.txtIntervencion)
        Me.Controls.Add(Label1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.btnRegistrar)
        Me.Controls.Add(Me.dgv)
        Me.Name = "frmIramMangueras"
        Me.Text = "PH de Mangueras"
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents btnRegistrar As System.Windows.Forms.Button
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents mnuAcciones As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuAbrir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtSucursal As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents txtDireccion As System.Windows.Forms.TextBox
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents txtIntervencion As System.Windows.Forms.TextBox
    Friend WithEvents colDiametro As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colLargo As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colMarca As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colTipo As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colNro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colLargoReal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIram As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPresion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOk As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colPuesto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colObs As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSerie As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSolicitud As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIntervencion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUsuario As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnIram As System.Windows.Forms.Button
End Class
