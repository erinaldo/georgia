<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCilindrosDuplicados
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
        Dim Label2 As System.Windows.Forms.Label
        Dim Label3 As System.Windows.Forms.Label
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.tv = New System.Windows.Forms.TreeView
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.lblRep = New System.Windows.Forms.Label
        Me.txtCodigo = New System.Windows.Forms.TextBox
        Me.txtSuc = New System.Windows.Forms.TextBox
        Me.txtDireccion = New System.Windows.Forms.TextBox
        Me.txtCliente = New System.Windows.Forms.TextBox
        Me.dgv = New System.Windows.Forms.DataGridView
        Me.btnBuscar = New System.Windows.Forms.Button
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.cms = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuEditar = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuEliminar = New System.Windows.Forms.ToolStripMenuItem
        Me.colSerie = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colTipo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCilindro = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colFabricacion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colVto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colIntervencion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCreacion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colUsuario = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colOrigen = New System.Windows.Forms.DataGridViewTextBoxColumn
        Label2 = New System.Windows.Forms.Label
        Label3 = New System.Windows.Forms.Label
        Me.GroupBox4.SuspendLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.cms.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Location = New System.Drawing.Point(4, 23)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(42, 13)
        Label2.TabIndex = 0
        Label2.Text = "Cliente:"
        '
        'Label3
        '
        Label3.AutoSize = True
        Label3.Location = New System.Drawing.Point(3, 46)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(51, 13)
        Label3.TabIndex = 3
        Label3.Text = "Sucursal:"
        '
        'tv
        '
        Me.tv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tv.Location = New System.Drawing.Point(3, 3)
        Me.tv.Name = "tv"
        Me.tv.Size = New System.Drawing.Size(273, 422)
        Me.tv.TabIndex = 3
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.lblRep)
        Me.GroupBox4.Controls.Add(Me.txtCodigo)
        Me.GroupBox4.Controls.Add(Me.txtSuc)
        Me.GroupBox4.Controls.Add(Me.txtDireccion)
        Me.GroupBox4.Controls.Add(Label2)
        Me.GroupBox4.Controls.Add(Me.txtCliente)
        Me.GroupBox4.Controls.Add(Label3)
        Me.GroupBox4.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(340, 73)
        Me.GroupBox4.TabIndex = 59
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Cliente"
        '
        'lblRep
        '
        Me.lblRep.AutoSize = True
        Me.lblRep.Location = New System.Drawing.Point(308, 23)
        Me.lblRep.Name = "lblRep"
        Me.lblRep.Size = New System.Drawing.Size(0, 13)
        Me.lblRep.TabIndex = 65
        '
        'txtCodigo
        '
        Me.txtCodigo.Location = New System.Drawing.Point(57, 19)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.ReadOnly = True
        Me.txtCodigo.Size = New System.Drawing.Size(53, 20)
        Me.txtCodigo.TabIndex = 1
        '
        'txtSuc
        '
        Me.txtSuc.Location = New System.Drawing.Point(57, 43)
        Me.txtSuc.Name = "txtSuc"
        Me.txtSuc.ReadOnly = True
        Me.txtSuc.Size = New System.Drawing.Size(53, 20)
        Me.txtSuc.TabIndex = 4
        '
        'txtDireccion
        '
        Me.txtDireccion.Location = New System.Drawing.Point(116, 43)
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.ReadOnly = True
        Me.txtDireccion.Size = New System.Drawing.Size(213, 20)
        Me.txtDireccion.TabIndex = 5
        '
        'txtCliente
        '
        Me.txtCliente.Location = New System.Drawing.Point(116, 19)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(213, 20)
        Me.txtCliente.TabIndex = 2
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToDeleteRows = False
        Me.dgv.AllowUserToOrderColumns = True
        Me.dgv.AllowUserToResizeRows = False
        Me.dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colSerie, Me.colTipo, Me.colCilindro, Me.colFabricacion, Me.colVto, Me.colIntervencion, Me.colCreacion, Me.colUsuario, Me.colOrigen})
        Me.dgv.ContextMenuStrip = Me.cms
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgv.Location = New System.Drawing.Point(3, 82)
        Me.dgv.Name = "dgv"
        Me.dgv.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgv.Size = New System.Drawing.Size(550, 343)
        Me.dgv.TabIndex = 60
        '
        'btnBuscar
        '
        Me.btnBuscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBuscar.Location = New System.Drawing.Point(201, 431)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(75, 23)
        Me.btnBuscar.TabIndex = 61
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.tv)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnBuscar)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.GroupBox4)
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgv)
        Me.SplitContainer1.Size = New System.Drawing.Size(839, 457)
        Me.SplitContainer1.SplitterDistance = 279
        Me.SplitContainer1.TabIndex = 62
        '
        'cms
        '
        Me.cms.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuEditar, Me.mnuEliminar})
        Me.cms.Name = "cms"
        Me.cms.Size = New System.Drawing.Size(118, 48)
        '
        'mnuEditar
        '
        Me.mnuEditar.Name = "mnuEditar"
        Me.mnuEditar.Size = New System.Drawing.Size(117, 22)
        Me.mnuEditar.Text = "Editar..."
        '
        'mnuEliminar
        '
        Me.mnuEliminar.Name = "mnuEliminar"
        Me.mnuEliminar.Size = New System.Drawing.Size(117, 22)
        Me.mnuEliminar.Text = "Eliminar"
        '
        'colSerie
        '
        Me.colSerie.HeaderText = "Serie"
        Me.colSerie.Name = "colSerie"
        Me.colSerie.ReadOnly = True
        Me.colSerie.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colSerie.Width = 37
        '
        'colTipo
        '
        Me.colTipo.HeaderText = "Tipo"
        Me.colTipo.Name = "colTipo"
        Me.colTipo.ReadOnly = True
        Me.colTipo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colTipo.Width = 34
        '
        'colCilindro
        '
        Me.colCilindro.HeaderText = "Cilindro"
        Me.colCilindro.Name = "colCilindro"
        Me.colCilindro.ReadOnly = True
        Me.colCilindro.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colCilindro.Width = 47
        '
        'colFabricacion
        '
        Me.colFabricacion.HeaderText = "Fabricación"
        Me.colFabricacion.Name = "colFabricacion"
        Me.colFabricacion.ReadOnly = True
        Me.colFabricacion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colFabricacion.Width = 68
        '
        'colVto
        '
        Me.colVto.HeaderText = "Vto"
        Me.colVto.Name = "colVto"
        Me.colVto.ReadOnly = True
        Me.colVto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colVto.Width = 29
        '
        'colIntervencion
        '
        Me.colIntervencion.HeaderText = "Intervencion"
        Me.colIntervencion.Name = "colIntervencion"
        Me.colIntervencion.ReadOnly = True
        Me.colIntervencion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colIntervencion.Width = 72
        '
        'colCreacion
        '
        Me.colCreacion.HeaderText = "Creacion"
        Me.colCreacion.Name = "colCreacion"
        Me.colCreacion.ReadOnly = True
        Me.colCreacion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colCreacion.Width = 55
        '
        'colUsuario
        '
        Me.colUsuario.HeaderText = "Usuario"
        Me.colUsuario.Name = "colUsuario"
        Me.colUsuario.ReadOnly = True
        Me.colUsuario.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colUsuario.Width = 49
        '
        'colOrigen
        '
        Me.colOrigen.HeaderText = "Origen"
        Me.colOrigen.Name = "colOrigen"
        Me.colOrigen.ReadOnly = True
        Me.colOrigen.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colOrigen.Width = 44
        '
        'frmCilindrosDuplicados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(839, 457)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "frmCilindrosDuplicados"
        Me.Text = "Cilindros Duplicados"
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.cms.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tv As System.Windows.Forms.TreeView
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents lblRep As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents txtSuc As System.Windows.Forms.TextBox
    Friend WithEvents txtDireccion As System.Windows.Forms.TextBox
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents cms As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuEditar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuEliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents colSerie As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCilindro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFabricacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colVto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIntervencion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCreacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUsuario As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOrigen As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
