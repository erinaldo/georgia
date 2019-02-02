<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTickets
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
        Me.dgv = New System.Windows.Forms.DataGridView
        Me.colNro = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colOperador = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCodigoCliente = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colNombreCliente = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colSucursal = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colMotivo = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.colFechaCreacion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colAsignado = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colDias = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colEstado = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.colFechaAsignado = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnNuevo = New System.Windows.Forms.Button
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.chkTodo = New System.Windows.Forms.CheckBox
        Me.txtFiltroCliente = New System.Windows.Forms.TextBox
        Me.gruEstados = New System.Windows.Forms.GroupBox
        Me.chkCerrados = New System.Windows.Forms.CheckBox
        Me.chkResueltos = New System.Windows.Forms.CheckBox
        Me.chkAbiertos = New System.Windows.Forms.CheckBox
        Me.btnActualizar = New System.Windows.Forms.Button
        Label1 = New System.Windows.Forms.Label
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.gruEstados.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(19, 289)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(66, 13)
        Label1.TabIndex = 4
        Label1.Text = "Filtrar cliente"
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToDeleteRows = False
        Me.dgv.AllowUserToResizeColumns = False
        Me.dgv.AllowUserToResizeRows = False
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colNro, Me.colOperador, Me.colCodigoCliente, Me.colNombreCliente, Me.colSucursal, Me.colMotivo, Me.colFechaCreacion, Me.colAsignado, Me.colDias, Me.colEstado, Me.colFechaAsignado})
        Me.dgv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv.Location = New System.Drawing.Point(0, 0)
        Me.dgv.Name = "dgv"
        Me.dgv.ReadOnly = True
        Me.dgv.Size = New System.Drawing.Size(1014, 495)
        Me.dgv.TabIndex = 0
        '
        'colNro
        '
        Me.colNro.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colNro.HeaderText = "Nro"
        Me.colNro.Name = "colNro"
        Me.colNro.ReadOnly = True
        Me.colNro.Width = 49
        '
        'colOperador
        '
        Me.colOperador.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colOperador.HeaderText = "Operador"
        Me.colOperador.Name = "colOperador"
        Me.colOperador.ReadOnly = True
        Me.colOperador.Width = 76
        '
        'colCodigoCliente
        '
        Me.colCodigoCliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colCodigoCliente.HeaderText = "Codigo"
        Me.colCodigoCliente.Name = "colCodigoCliente"
        Me.colCodigoCliente.ReadOnly = True
        Me.colCodigoCliente.Width = 65
        '
        'colNombreCliente
        '
        Me.colNombreCliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colNombreCliente.HeaderText = "Cliente"
        Me.colNombreCliente.Name = "colNombreCliente"
        Me.colNombreCliente.ReadOnly = True
        Me.colNombreCliente.Width = 64
        '
        'colSucursal
        '
        Me.colSucursal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colSucursal.HeaderText = "Sucursal"
        Me.colSucursal.Name = "colSucursal"
        Me.colSucursal.ReadOnly = True
        Me.colSucursal.Width = 73
        '
        'colMotivo
        '
        Me.colMotivo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colMotivo.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.colMotivo.HeaderText = "Motivo"
        Me.colMotivo.Name = "colMotivo"
        Me.colMotivo.ReadOnly = True
        Me.colMotivo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colMotivo.Width = 64
        '
        'colFechaCreacion
        '
        Me.colFechaCreacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colFechaCreacion.HeaderText = "Creacion"
        Me.colFechaCreacion.Name = "colFechaCreacion"
        Me.colFechaCreacion.ReadOnly = True
        Me.colFechaCreacion.Width = 74
        '
        'colAsignado
        '
        Me.colAsignado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colAsignado.HeaderText = "Asignado"
        Me.colAsignado.Name = "colAsignado"
        Me.colAsignado.ReadOnly = True
        Me.colAsignado.Width = 76
        '
        'colDias
        '
        Me.colDias.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colDias.HeaderText = "Dias"
        Me.colDias.Name = "colDias"
        Me.colDias.ReadOnly = True
        Me.colDias.Width = 53
        '
        'colEstado
        '
        Me.colEstado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colEstado.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.colEstado.HeaderText = "Estado"
        Me.colEstado.Name = "colEstado"
        Me.colEstado.ReadOnly = True
        Me.colEstado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colEstado.Width = 65
        '
        'colFechaAsignado
        '
        Me.colFechaAsignado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colFechaAsignado.HeaderText = "Fecha Asignado"
        Me.colFechaAsignado.Name = "colFechaAsignado"
        Me.colFechaAsignado.ReadOnly = True
        Me.colFechaAsignado.Visible = False
        '
        'btnNuevo
        '
        Me.btnNuevo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNuevo.Location = New System.Drawing.Point(12, 12)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(153, 51)
        Me.btnNuevo.TabIndex = 1
        Me.btnNuevo.Text = "Nuevo Ticket"
        Me.btnNuevo.UseVisualStyleBackColor = True
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.chkTodo)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtFiltroCliente)
        Me.SplitContainer1.Panel1.Controls.Add(Label1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.gruEstados)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnActualizar)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnNuevo)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgv)
        Me.SplitContainer1.Size = New System.Drawing.Size(1196, 495)
        Me.SplitContainer1.SplitterDistance = 178
        Me.SplitContainer1.TabIndex = 2
        '
        'chkTodo
        '
        Me.chkTodo.AutoSize = True
        Me.chkTodo.Location = New System.Drawing.Point(22, 204)
        Me.chkTodo.Name = "chkTodo"
        Me.chkTodo.Size = New System.Drawing.Size(66, 17)
        Me.chkTodo.TabIndex = 3
        Me.chkTodo.Text = "Ver todo"
        Me.chkTodo.UseVisualStyleBackColor = True
        Me.chkTodo.Visible = False
        '
        'txtFiltroCliente
        '
        Me.txtFiltroCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFiltroCliente.Location = New System.Drawing.Point(12, 305)
        Me.txtFiltroCliente.Name = "txtFiltroCliente"
        Me.txtFiltroCliente.Size = New System.Drawing.Size(153, 20)
        Me.txtFiltroCliente.TabIndex = 5
        '
        'gruEstados
        '
        Me.gruEstados.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gruEstados.Controls.Add(Me.chkCerrados)
        Me.gruEstados.Controls.Add(Me.chkResueltos)
        Me.gruEstados.Controls.Add(Me.chkAbiertos)
        Me.gruEstados.Location = New System.Drawing.Point(12, 81)
        Me.gruEstados.Name = "gruEstados"
        Me.gruEstados.Size = New System.Drawing.Size(153, 117)
        Me.gruEstados.TabIndex = 3
        Me.gruEstados.TabStop = False
        Me.gruEstados.Text = "Estados"
        '
        'chkCerrados
        '
        Me.chkCerrados.AutoSize = True
        Me.chkCerrados.Location = New System.Drawing.Point(10, 78)
        Me.chkCerrados.Name = "chkCerrados"
        Me.chkCerrados.Size = New System.Drawing.Size(68, 17)
        Me.chkCerrados.TabIndex = 2
        Me.chkCerrados.Text = "Cerrados"
        Me.chkCerrados.UseVisualStyleBackColor = True
        '
        'chkResueltos
        '
        Me.chkResueltos.AutoSize = True
        Me.chkResueltos.Location = New System.Drawing.Point(10, 55)
        Me.chkResueltos.Name = "chkResueltos"
        Me.chkResueltos.Size = New System.Drawing.Size(73, 17)
        Me.chkResueltos.TabIndex = 1
        Me.chkResueltos.Text = "Resueltos"
        Me.chkResueltos.UseVisualStyleBackColor = True
        '
        'chkAbiertos
        '
        Me.chkAbiertos.AutoSize = True
        Me.chkAbiertos.Location = New System.Drawing.Point(10, 32)
        Me.chkAbiertos.Name = "chkAbiertos"
        Me.chkAbiertos.Size = New System.Drawing.Size(64, 17)
        Me.chkAbiertos.TabIndex = 0
        Me.chkAbiertos.Text = "Abiertos"
        Me.chkAbiertos.UseVisualStyleBackColor = True
        '
        'btnActualizar
        '
        Me.btnActualizar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnActualizar.Location = New System.Drawing.Point(12, 241)
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(153, 23)
        Me.btnActualizar.TabIndex = 2
        Me.btnActualizar.Text = "Actualizar"
        Me.btnActualizar.UseVisualStyleBackColor = True
        '
        'frmTickets
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1196, 495)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "frmTickets"
        Me.Text = "Tickets"
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.gruEstados.ResumeLayout(False)
        Me.gruEstados.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents btnActualizar As System.Windows.Forms.Button
    Friend WithEvents txtFiltroCliente As System.Windows.Forms.TextBox
    Friend WithEvents gruEstados As System.Windows.Forms.GroupBox
    Friend WithEvents chkCerrados As System.Windows.Forms.CheckBox
    Friend WithEvents chkResueltos As System.Windows.Forms.CheckBox
    Friend WithEvents chkAbiertos As System.Windows.Forms.CheckBox
    Friend WithEvents colNro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOperador As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCodigoCliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNombreCliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSucursal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMotivo As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colFechaCreacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAsignado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDias As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colEstado As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colFechaAsignado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chkTodo As System.Windows.Forms.CheckBox
End Class
