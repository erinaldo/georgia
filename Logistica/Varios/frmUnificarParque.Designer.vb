<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUnificarParque
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.dgv = New System.Windows.Forms.DataGridView
        Me.colTipo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colNomCliente = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCliente = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colSucursal = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colMes = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colAno = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colVtos = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.dtp = New System.Windows.Forms.DateTimePicker
        Me.btnBuscar = New System.Windows.Forms.Button
        Me.lbl1 = New System.Windows.Forms.Label
        Me.chkAbonados = New System.Windows.Forms.CheckBox
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToDeleteRows = False
        Me.dgv.AllowUserToResizeColumns = False
        Me.dgv.AllowUserToResizeRows = False
        Me.dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colTipo, Me.colNomCliente, Me.colCliente, Me.colSucursal, Me.colMes, Me.colAno, Me.colVtos})
        Me.dgv.ContextMenuStrip = Me.ContextMenuStrip1
        Me.dgv.Location = New System.Drawing.Point(12, 34)
        Me.dgv.Name = "dgv"
        Me.dgv.ReadOnly = True
        Me.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv.Size = New System.Drawing.Size(444, 396)
        Me.dgv.TabIndex = 0
        '
        'colTipo
        '
        Me.colTipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colTipo.HeaderText = "Tipo"
        Me.colTipo.Name = "colTipo"
        Me.colTipo.ReadOnly = True
        Me.colTipo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colTipo.Width = 34
        '
        'colNomCliente
        '
        Me.colNomCliente.HeaderText = "Nombre Cliente"
        Me.colNomCliente.Name = "colNomCliente"
        Me.colNomCliente.ReadOnly = True
        '
        'colCliente
        '
        Me.colCliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colCliente.HeaderText = "Cliente"
        Me.colCliente.Name = "colCliente"
        Me.colCliente.ReadOnly = True
        Me.colCliente.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colCliente.Width = 45
        '
        'colSucursal
        '
        Me.colSucursal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colSucursal.HeaderText = "Sucursal"
        Me.colSucursal.Name = "colSucursal"
        Me.colSucursal.ReadOnly = True
        Me.colSucursal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colSucursal.Width = 54
        '
        'colMes
        '
        Me.colMes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Format = "00"
        Me.colMes.DefaultCellStyle = DataGridViewCellStyle1
        Me.colMes.HeaderText = "Mes"
        Me.colMes.Name = "colMes"
        Me.colMes.ReadOnly = True
        Me.colMes.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colMes.Width = 33
        '
        'colAno
        '
        Me.colAno.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colAno.DefaultCellStyle = DataGridViewCellStyle2
        Me.colAno.HeaderText = "Año"
        Me.colAno.Name = "colAno"
        Me.colAno.ReadOnly = True
        Me.colAno.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colAno.Width = 32
        '
        'colVtos
        '
        Me.colVtos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colVtos.DefaultCellStyle = DataGridViewCellStyle3
        Me.colVtos.HeaderText = "Vtos"
        Me.colVtos.Name = "colVtos"
        Me.colVtos.ReadOnly = True
        Me.colVtos.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colVtos.Width = 34
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'dtp
        '
        Me.dtp.CustomFormat = "MM/yyyy"
        Me.dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp.Location = New System.Drawing.Point(12, 8)
        Me.dtp.Name = "dtp"
        Me.dtp.Size = New System.Drawing.Size(108, 20)
        Me.dtp.TabIndex = 1
        '
        'btnBuscar
        '
        Me.btnBuscar.Location = New System.Drawing.Point(206, 4)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(75, 23)
        Me.btnBuscar.TabIndex = 2
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'lbl1
        '
        Me.lbl1.AutoSize = True
        Me.lbl1.Location = New System.Drawing.Point(287, 9)
        Me.lbl1.Name = "lbl1"
        Me.lbl1.Size = New System.Drawing.Size(64, 13)
        Me.lbl1.TabIndex = 3
        Me.lbl1.Text = "Buscando..."
        Me.lbl1.Visible = False
        '
        'chkAbonados
        '
        Me.chkAbonados.AutoSize = True
        Me.chkAbonados.Location = New System.Drawing.Point(126, 11)
        Me.chkAbonados.Name = "chkAbonados"
        Me.chkAbonados.Size = New System.Drawing.Size(74, 17)
        Me.chkAbonados.TabIndex = 4
        Me.chkAbonados.Text = "Abonados"
        Me.chkAbonados.UseVisualStyleBackColor = True
        '
        'frmUnificarParque
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(473, 442)
        Me.Controls.Add(Me.chkAbonados)
        Me.Controls.Add(Me.lbl1)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.dtp)
        Me.Controls.Add(Me.dgv)
        Me.Name = "frmUnificarParque"
        Me.Text = "Unificación de Parque"
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents dtp As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents lbl1 As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents colTipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNomCliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSucursal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colVtos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chkAbonados As System.Windows.Forms.CheckBox
End Class
