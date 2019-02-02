<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTarjetasNuevo
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
        Me.btnPedido = New System.Windows.Forms.Button
        Me.txtNro = New System.Windows.Forms.TextBox
        Me.txtCliente = New System.Windows.Forms.TextBox
        Me.btnExportar = New System.Windows.Forms.Button
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.dgv = New System.Windows.Forms.DataGridView
        Me.colPedido = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colLinea = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colTipo = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.colSerie = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCilindro = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnGrabar = New System.Windows.Forms.Button
        Label1 = New System.Windows.Forms.Label
        Label2 = New System.Windows.Forms.Label
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(9, 19)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(63, 13)
        Label1.TabIndex = 4
        Label1.Text = "Nro. Pedido"
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Location = New System.Drawing.Point(115, 19)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(39, 13)
        Label2.TabIndex = 5
        Label2.Text = "Cliente"
        '
        'btnPedido
        '
        Me.btnPedido.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPedido.Location = New System.Drawing.Point(473, 33)
        Me.btnPedido.Name = "btnPedido"
        Me.btnPedido.Size = New System.Drawing.Size(75, 23)
        Me.btnPedido.TabIndex = 0
        Me.btnPedido.Text = "Abrir Pedido"
        Me.btnPedido.UseVisualStyleBackColor = True
        '
        'txtNro
        '
        Me.txtNro.Location = New System.Drawing.Point(12, 35)
        Me.txtNro.Name = "txtNro"
        Me.txtNro.ReadOnly = True
        Me.txtNro.Size = New System.Drawing.Size(100, 20)
        Me.txtNro.TabIndex = 1
        '
        'txtCliente
        '
        Me.txtCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCliente.Location = New System.Drawing.Point(118, 35)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(349, 20)
        Me.txtCliente.TabIndex = 3
        '
        'btnExportar
        '
        Me.btnExportar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExportar.Enabled = False
        Me.btnExportar.Location = New System.Drawing.Point(467, 358)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(75, 23)
        Me.btnExportar.TabIndex = 7
        Me.btnExportar.Text = "Exportar"
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToDeleteRows = False
        Me.dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colPedido, Me.colLinea, Me.colTipo, Me.colSerie, Me.colCilindro})
        Me.dgv.Location = New System.Drawing.Point(12, 61)
        Me.dgv.Name = "dgv"
        Me.dgv.Size = New System.Drawing.Size(530, 291)
        Me.dgv.TabIndex = 8
        '
        'colPedido
        '
        Me.colPedido.HeaderText = "Pedido"
        Me.colPedido.Name = "colPedido"
        Me.colPedido.ReadOnly = True
        Me.colPedido.Visible = False
        '
        'colLinea
        '
        Me.colLinea.HeaderText = "Linea"
        Me.colLinea.Name = "colLinea"
        Me.colLinea.ReadOnly = True
        Me.colLinea.Visible = False
        '
        'colTipo
        '
        Me.colTipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colTipo.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.colTipo.HeaderText = "Tipo"
        Me.colTipo.Name = "colTipo"
        Me.colTipo.ReadOnly = True
        '
        'colSerie
        '
        Me.colSerie.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colSerie.HeaderText = "Serie"
        Me.colSerie.Name = "colSerie"
        Me.colSerie.ReadOnly = True
        Me.colSerie.Width = 56
        '
        'colCilindro
        '
        Me.colCilindro.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colCilindro.HeaderText = "Cilindro"
        Me.colCilindro.Name = "colCilindro"
        Me.colCilindro.Width = 66
        '
        'btnGrabar
        '
        Me.btnGrabar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGrabar.Enabled = False
        Me.btnGrabar.Location = New System.Drawing.Point(386, 358)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(75, 23)
        Me.btnGrabar.TabIndex = 9
        Me.btnGrabar.Text = "Grabar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'frmTarjetasNuevo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(556, 393)
        Me.Controls.Add(Me.btnGrabar)
        Me.Controls.Add(Me.dgv)
        Me.Controls.Add(Me.btnExportar)
        Me.Controls.Add(Label2)
        Me.Controls.Add(Label1)
        Me.Controls.Add(Me.txtCliente)
        Me.Controls.Add(Me.txtNro)
        Me.Controls.Add(Me.btnPedido)
        Me.Name = "frmTarjetasNuevo"
        Me.Tag = "frmGCBAnuevo"
        Me.Text = "Tarjetas GCBA Nuevos"
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnPedido As System.Windows.Forms.Button
    Friend WithEvents txtNro As System.Windows.Forms.TextBox
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents btnExportar As System.Windows.Forms.Button
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents colPedido As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colLinea As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTipo As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colSerie As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCilindro As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
