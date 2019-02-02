<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDetalleRemitos
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
        Me.dgv = New System.Windows.Forms.DataGridView
        Me.colCodigo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colComponente = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colDescripcion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colFecha = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCantidad = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colNumero = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuFecha = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator
        Me.mnuAgregar = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuBorrar = New System.Windows.Forms.ToolStripMenuItem
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtnro = New System.Windows.Forms.TextBox
        Me.txtbcliente = New System.Windows.Forms.TextBox
        Me.txtbsuc = New System.Windows.Forms.TextBox
        Me.btnCerrar = New System.Windows.Forms.Button
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToDeleteRows = False
        Me.dgv.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colCodigo, Me.colComponente, Me.colDescripcion, Me.colFecha, Me.colCantidad, Me.colNumero})
        Me.dgv.ContextMenuStrip = Me.ContextMenuStrip1
        Me.dgv.Location = New System.Drawing.Point(3, 75)
        Me.dgv.MultiSelect = False
        Me.dgv.Name = "dgv"
        Me.dgv.RowHeadersVisible = False
        Me.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv.Size = New System.Drawing.Size(444, 200)
        Me.dgv.TabIndex = 0
        '
        'colCodigo
        '
        Me.colCodigo.HeaderText = "codigo"
        Me.colCodigo.Name = "colCodigo"
        Me.colCodigo.ReadOnly = True
        Me.colCodigo.Visible = False
        '
        'colComponente
        '
        Me.colComponente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colComponente.HeaderText = "Componente"
        Me.colComponente.Name = "colComponente"
        Me.colComponente.Width = 92
        '
        'colDescripcion
        '
        Me.colDescripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colDescripcion.HeaderText = "Descripcion"
        Me.colDescripcion.Name = "colDescripcion"
        Me.colDescripcion.ReadOnly = True
        '
        'colFecha
        '
        Me.colFecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colFecha.HeaderText = "Vto"
        Me.colFecha.Name = "colFecha"
        Me.colFecha.ReadOnly = True
        Me.colFecha.Width = 48
        '
        'colCantidad
        '
        Me.colCantidad.HeaderText = "cantidad"
        Me.colCantidad.Name = "colCantidad"
        Me.colCantidad.ReadOnly = True
        Me.colCantidad.Visible = False
        '
        'colNumero
        '
        Me.colNumero.HeaderText = "numero"
        Me.colNumero.Name = "colNumero"
        Me.colNumero.ReadOnly = True
        Me.colNumero.Visible = False
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFecha, Me.ToolStripMenuItem1, Me.mnuAgregar, Me.mnuBorrar})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(160, 76)
        '
        'mnuFecha
        '
        Me.mnuFecha.Name = "mnuFecha"
        Me.mnuFecha.Size = New System.Drawing.Size(159, 22)
        Me.mnuFecha.Text = "Modificar Fecha"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(156, 6)
        '
        'mnuAgregar
        '
        Me.mnuAgregar.Name = "mnuAgregar"
        Me.mnuAgregar.Size = New System.Drawing.Size(159, 22)
        Me.mnuAgregar.Text = "Agregar..."
        '
        'mnuBorrar
        '
        Me.mnuBorrar.Name = "mnuBorrar"
        Me.mnuBorrar.Size = New System.Drawing.Size(159, 22)
        Me.mnuBorrar.Text = "Borrar..."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Numero"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Cliente"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Sucursal"
        '
        'txtnro
        '
        Me.txtnro.Location = New System.Drawing.Point(62, 6)
        Me.txtnro.Name = "txtnro"
        Me.txtnro.ReadOnly = True
        Me.txtnro.Size = New System.Drawing.Size(100, 20)
        Me.txtnro.TabIndex = 6
        '
        'txtbcliente
        '
        Me.txtbcliente.Location = New System.Drawing.Point(62, 28)
        Me.txtbcliente.Name = "txtbcliente"
        Me.txtbcliente.ReadOnly = True
        Me.txtbcliente.Size = New System.Drawing.Size(100, 20)
        Me.txtbcliente.TabIndex = 7
        '
        'txtbsuc
        '
        Me.txtbsuc.Location = New System.Drawing.Point(62, 51)
        Me.txtbsuc.Name = "txtbsuc"
        Me.txtbsuc.ReadOnly = True
        Me.txtbsuc.Size = New System.Drawing.Size(100, 20)
        Me.txtbsuc.TabIndex = 8
        '
        'btnCerrar
        '
        Me.btnCerrar.Location = New System.Drawing.Point(372, 281)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(75, 23)
        Me.btnCerrar.TabIndex = 9
        Me.btnCerrar.Text = "Aceptar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'frmDetalleRemitos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(449, 316)
        Me.Controls.Add(Me.txtbsuc)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.txtbcliente)
        Me.Controls.Add(Me.txtnro)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgv)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDetalleRemitos"
        Me.Text = "Sistema Fijo Clientes"
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtnro As System.Windows.Forms.TextBox
    Friend WithEvents txtbcliente As System.Windows.Forms.TextBox
    Friend WithEvents txtbsuc As System.Windows.Forms.TextBox
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuFecha As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents colCodigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colComponente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDescripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNumero As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuAgregar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuBorrar As System.Windows.Forms.ToolStripMenuItem
End Class
