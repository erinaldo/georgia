<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSeguimiento
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
        Dim Label5 As System.Windows.Forms.Label
        Dim Label6 As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSeguimiento))
        Me.btnSalir = New System.Windows.Forms.Button
        Me.txtDocEnv = New System.Windows.Forms.TextBox
        Me.cboPara = New System.Windows.Forms.ComboBox
        Me.dgvEnviados = New System.Windows.Forms.DataGridView
        Me.colFecha1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colHora1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colUsr1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colLinea1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colItn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colRto1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colPed1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCliente1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colNombre1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colDe1 = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.colPara1 = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.colRecibido1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.usrrecibe_arriba_col = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgvRecibidos = New System.Windows.Forms.DataGridView
        Me.colFecha2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colHora2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colUsr2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colLinea2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colItn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colRto2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colPed2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCliente2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colNombre2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colDe2 = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.colPara2 = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.colRecibido2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.usrrecibe_abajo_col = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cboDe = New System.Windows.Forms.ComboBox
        Me.btnRefrescar = New System.Windows.Forms.Button
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.txtDocRec = New System.Windows.Forms.TextBox
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Label1 = New System.Windows.Forms.Label
        Label2 = New System.Windows.Forms.Label
        Label3 = New System.Windows.Forms.Label
        Label4 = New System.Windows.Forms.Label
        Label5 = New System.Windows.Forms.Label
        Label6 = New System.Windows.Forms.Label
        CType(Me.dgvEnviados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvRecibidos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(200, 6)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(24, 13)
        Label1.TabIndex = 1
        Label1.Text = "D&e:"
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Location = New System.Drawing.Point(411, 6)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(32, 13)
        Label2.TabIndex = 3
        Label2.Text = "&Para:"
        '
        'Label3
        '
        Label3.AutoSize = True
        Label3.Location = New System.Drawing.Point(623, 6)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(65, 13)
        Label3.TabIndex = 5
        Label3.Text = "&Documento:"
        '
        'Label4
        '
        Label4.AutoSize = True
        Label4.Location = New System.Drawing.Point(623, 6)
        Label4.Name = "Label4"
        Label4.Size = New System.Drawing.Size(65, 13)
        Label4.TabIndex = 1
        Label4.Text = "Documento:"
        '
        'Label5
        '
        Label5.AutoSize = True
        Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label5.ForeColor = System.Drawing.Color.Red
        Label5.Location = New System.Drawing.Point(6, 4)
        Label5.Name = "Label5"
        Label5.Size = New System.Drawing.Size(188, 20)
        Label5.TabIndex = 0
        Label5.Text = "Documentos Enviados"
        '
        'Label6
        '
        Label6.AutoSize = True
        Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label6.ForeColor = System.Drawing.Color.Red
        Label6.Location = New System.Drawing.Point(3, 3)
        Label6.Name = "Label6"
        Label6.Size = New System.Drawing.Size(399, 20)
        Label6.TabIndex = 0
        Label6.Text = "Documentos Recibidos en espera de Aceptación"
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnSalir.Location = New System.Drawing.Point(846, 495)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(75, 23)
        Me.btnSalir.TabIndex = 3
        Me.btnSalir.TabStop = False
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'txtDocEnv
        '
        Me.txtDocEnv.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDocEnv.Location = New System.Drawing.Point(694, 3)
        Me.txtDocEnv.Name = "txtDocEnv"
        Me.txtDocEnv.Size = New System.Drawing.Size(226, 20)
        Me.txtDocEnv.TabIndex = 6
        '
        'cboPara
        '
        Me.cboPara.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPara.FormattingEnabled = True
        Me.cboPara.Location = New System.Drawing.Point(449, 3)
        Me.cboPara.Name = "cboPara"
        Me.cboPara.Size = New System.Drawing.Size(168, 21)
        Me.cboPara.TabIndex = 4
        Me.cboPara.TabStop = False
        '
        'dgvEnviados
        '
        Me.dgvEnviados.AllowUserToAddRows = False
        Me.dgvEnviados.AllowUserToResizeRows = False
        Me.dgvEnviados.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvEnviados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEnviados.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colFecha1, Me.colHora1, Me.colUsr1, Me.colLinea1, Me.colItn1, Me.colRto1, Me.colPed1, Me.colCliente1, Me.colNombre1, Me.colDe1, Me.colPara1, Me.colRecibido1, Me.usrrecibe_arriba_col})
        Me.dgvEnviados.Location = New System.Drawing.Point(3, 30)
        Me.dgvEnviados.Name = "dgvEnviados"
        Me.dgvEnviados.Size = New System.Drawing.Size(918, 208)
        Me.dgvEnviados.TabIndex = 7
        Me.dgvEnviados.TabStop = False
        '
        'colFecha1
        '
        Me.colFecha1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.colFecha1.HeaderText = "Fecha"
        Me.colFecha1.Name = "colFecha1"
        Me.colFecha1.ReadOnly = True
        Me.colFecha1.Width = 62
        '
        'colHora1
        '
        Me.colHora1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.colHora1.HeaderText = "Hora"
        Me.colHora1.Name = "colHora1"
        Me.colHora1.ReadOnly = True
        Me.colHora1.Width = 55
        '
        'colUsr1
        '
        Me.colUsr1.HeaderText = "Usuario"
        Me.colUsr1.Name = "colUsr1"
        Me.colUsr1.Visible = False
        '
        'colLinea1
        '
        Me.colLinea1.HeaderText = "Linea"
        Me.colLinea1.Name = "colLinea1"
        Me.colLinea1.Visible = False
        '
        'colItn1
        '
        Me.colItn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.colItn1.HeaderText = "Intervencion"
        Me.colItn1.Name = "colItn1"
        Me.colItn1.ReadOnly = True
        Me.colItn1.Width = 91
        '
        'colRto1
        '
        Me.colRto1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.colRto1.HeaderText = "Remito"
        Me.colRto1.Name = "colRto1"
        Me.colRto1.ReadOnly = True
        Me.colRto1.Width = 65
        '
        'colPed1
        '
        Me.colPed1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.colPed1.HeaderText = "Pedido"
        Me.colPed1.Name = "colPed1"
        Me.colPed1.ReadOnly = True
        Me.colPed1.Width = 65
        '
        'colCliente1
        '
        Me.colCliente1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.colCliente1.HeaderText = "Cliente"
        Me.colCliente1.Name = "colCliente1"
        Me.colCliente1.ReadOnly = True
        Me.colCliente1.Width = 64
        '
        'colNombre1
        '
        Me.colNombre1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colNombre1.HeaderText = "Nombre"
        Me.colNombre1.Name = "colNombre1"
        Me.colNombre1.ReadOnly = True
        '
        'colDe1
        '
        Me.colDe1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.colDe1.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.colDe1.DisplayStyleForCurrentCellOnly = True
        Me.colDe1.HeaderText = "De"
        Me.colDe1.Name = "colDe1"
        Me.colDe1.ReadOnly = True
        Me.colDe1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colDe1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colDe1.Width = 46
        '
        'colPara1
        '
        Me.colPara1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.colPara1.DisplayStyleForCurrentCellOnly = True
        Me.colPara1.HeaderText = "Para"
        Me.colPara1.Name = "colPara1"
        Me.colPara1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colPara1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colPara1.Width = 54
        '
        'colRecibido1
        '
        Me.colRecibido1.HeaderText = "Recibido"
        Me.colRecibido1.Name = "colRecibido1"
        Me.colRecibido1.Visible = False
        '
        'usrrecibe_arriba_col
        '
        Me.usrrecibe_arriba_col.HeaderText = "usuario recibe"
        Me.usrrecibe_arriba_col.Name = "usrrecibe_arriba_col"
        Me.usrrecibe_arriba_col.Visible = False
        '
        'dgvRecibidos
        '
        Me.dgvRecibidos.AllowUserToAddRows = False
        Me.dgvRecibidos.AllowUserToDeleteRows = False
        Me.dgvRecibidos.AllowUserToResizeRows = False
        Me.dgvRecibidos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvRecibidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRecibidos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colFecha2, Me.colHora2, Me.colUsr2, Me.colLinea2, Me.colItn2, Me.colRto2, Me.colPed2, Me.colCliente2, Me.colNombre2, Me.colDe2, Me.colPara2, Me.colRecibido2, Me.usrrecibe_abajo_col})
        Me.dgvRecibidos.Location = New System.Drawing.Point(0, 29)
        Me.dgvRecibidos.Name = "dgvRecibidos"
        Me.dgvRecibidos.ReadOnly = True
        Me.dgvRecibidos.Size = New System.Drawing.Size(921, 208)
        Me.dgvRecibidos.TabIndex = 3
        Me.dgvRecibidos.TabStop = False
        '
        'colFecha2
        '
        Me.colFecha2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.colFecha2.HeaderText = "Fecha"
        Me.colFecha2.Name = "colFecha2"
        Me.colFecha2.ReadOnly = True
        Me.colFecha2.Width = 62
        '
        'colHora2
        '
        Me.colHora2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.colHora2.HeaderText = "Hora"
        Me.colHora2.Name = "colHora2"
        Me.colHora2.ReadOnly = True
        Me.colHora2.Width = 55
        '
        'colUsr2
        '
        Me.colUsr2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.colUsr2.HeaderText = "Usuario"
        Me.colUsr2.Name = "colUsr2"
        Me.colUsr2.ReadOnly = True
        Me.colUsr2.Width = 68
        '
        'colLinea2
        '
        Me.colLinea2.HeaderText = "Linea"
        Me.colLinea2.Name = "colLinea2"
        Me.colLinea2.ReadOnly = True
        Me.colLinea2.Visible = False
        '
        'colItn2
        '
        Me.colItn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.colItn2.HeaderText = "Intervencion"
        Me.colItn2.Name = "colItn2"
        Me.colItn2.ReadOnly = True
        Me.colItn2.Width = 91
        '
        'colRto2
        '
        Me.colRto2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.colRto2.HeaderText = "Remito"
        Me.colRto2.Name = "colRto2"
        Me.colRto2.ReadOnly = True
        Me.colRto2.Width = 65
        '
        'colPed2
        '
        Me.colPed2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.colPed2.HeaderText = "Pedido"
        Me.colPed2.Name = "colPed2"
        Me.colPed2.ReadOnly = True
        Me.colPed2.Width = 65
        '
        'colCliente2
        '
        Me.colCliente2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.colCliente2.HeaderText = "Cliente"
        Me.colCliente2.Name = "colCliente2"
        Me.colCliente2.ReadOnly = True
        Me.colCliente2.Width = 64
        '
        'colNombre2
        '
        Me.colNombre2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colNombre2.HeaderText = "Nombre"
        Me.colNombre2.Name = "colNombre2"
        Me.colNombre2.ReadOnly = True
        '
        'colDe2
        '
        Me.colDe2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.colDe2.DisplayStyleForCurrentCellOnly = True
        Me.colDe2.HeaderText = "De"
        Me.colDe2.Name = "colDe2"
        Me.colDe2.ReadOnly = True
        Me.colDe2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colDe2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colDe2.Width = 46
        '
        'colPara2
        '
        Me.colPara2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.colPara2.DisplayStyleForCurrentCellOnly = True
        Me.colPara2.HeaderText = "Para"
        Me.colPara2.Name = "colPara2"
        Me.colPara2.ReadOnly = True
        Me.colPara2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colPara2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colPara2.Width = 54
        '
        'colRecibido2
        '
        Me.colRecibido2.HeaderText = "Recibido"
        Me.colRecibido2.Name = "colRecibido2"
        Me.colRecibido2.ReadOnly = True
        Me.colRecibido2.Visible = False
        '
        'usrrecibe_abajo_col
        '
        Me.usrrecibe_abajo_col.HeaderText = "usuario recibe"
        Me.usrrecibe_abajo_col.Name = "usrrecibe_abajo_col"
        Me.usrrecibe_abajo_col.ReadOnly = True
        Me.usrrecibe_abajo_col.Visible = False
        '
        'cboDe
        '
        Me.cboDe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDe.Enabled = False
        Me.cboDe.FormattingEnabled = True
        Me.cboDe.Location = New System.Drawing.Point(230, 3)
        Me.cboDe.Name = "cboDe"
        Me.cboDe.Size = New System.Drawing.Size(175, 21)
        Me.cboDe.TabIndex = 2
        '
        'btnRefrescar
        '
        Me.btnRefrescar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefrescar.Location = New System.Drawing.Point(558, 495)
        Me.btnRefrescar.Name = "btnRefrescar"
        Me.btnRefrescar.Size = New System.Drawing.Size(75, 23)
        Me.btnRefrescar.TabIndex = 1
        Me.btnRefrescar.TabStop = False
        Me.btnRefrescar.Text = "Refrescar"
        Me.btnRefrescar.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Label5)
        Me.SplitContainer1.Panel1.Controls.Add(Me.dgvEnviados)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cboDe)
        Me.SplitContainer1.Panel1.Controls.Add(Label3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtDocEnv)
        Me.SplitContainer1.Panel1.Controls.Add(Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cboPara)
        Me.SplitContainer1.Panel1.Controls.Add(Label1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Label6)
        Me.SplitContainer1.Panel2.Controls.Add(Label4)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtDocRec)
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgvRecibidos)
        Me.SplitContainer1.Size = New System.Drawing.Size(926, 489)
        Me.SplitContainer1.SplitterDistance = 243
        Me.SplitContainer1.TabIndex = 0
        Me.SplitContainer1.TabStop = False
        '
        'txtDocRec
        '
        Me.txtDocRec.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDocRec.Location = New System.Drawing.Point(694, 3)
        Me.txtDocRec.Name = "txtDocRec"
        Me.txtDocRec.Size = New System.Drawing.Size(226, 20)
        Me.txtDocRec.TabIndex = 2
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "NotifyIcon1"
        '
        'frmSeguimiento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnSalir
        Me.ClientSize = New System.Drawing.Size(927, 530)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.btnRefrescar)
        Me.Controls.Add(Me.btnSalir)
        Me.Name = "frmSeguimiento"
        Me.Text = "Seguimiento de documentación"
        CType(Me.dgvEnviados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvRecibidos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents txtDocEnv As System.Windows.Forms.TextBox
    Friend WithEvents cboPara As System.Windows.Forms.ComboBox
    Friend WithEvents dgvEnviados As System.Windows.Forms.DataGridView
    Friend WithEvents dgvRecibidos As System.Windows.Forms.DataGridView
    Friend WithEvents cboDe As System.Windows.Forms.ComboBox
    Friend WithEvents colFecha1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colHora1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUsr1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colLinea1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRto1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPed1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCliente1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNombre1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDe1 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colPara1 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colRecibido1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFecha2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colHora2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUsr2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colLinea2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRto2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPed2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCliente2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNombre2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDe2 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colPara2 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colRecibido2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnRefrescar As System.Windows.Forms.Button
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents txtDocRec As System.Windows.Forms.TextBox
    Friend WithEvents usrrecibe_arriba_col As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents usrrecibe_abajo_col As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
End Class
