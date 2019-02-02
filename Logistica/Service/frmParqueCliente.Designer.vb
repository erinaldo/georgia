<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmParqueCliente
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
        Me.dgv = New System.Windows.Forms.DataGridView
        Me.btnAceptar = New System.Windows.Forms.Button
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rbTodos = New System.Windows.Forms.RadioButton
        Me.rbSinPuesto = New System.Windows.Forms.RadioButton
        Me.colSerie = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colEquipo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCilindro = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colFab = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colVto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colSuc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colDomicilio = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCiudad = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToDeleteRows = False
        Me.dgv.AllowUserToResizeRows = False
        Me.dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colSerie, Me.colEquipo, Me.colCilindro, Me.colFab, Me.colVto, Me.colSuc, Me.colDomicilio, Me.colCiudad})
        Me.dgv.Location = New System.Drawing.Point(2, 3)
        Me.dgv.Name = "dgv"
        Me.dgv.ReadOnly = True
        Me.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv.Size = New System.Drawing.Size(900, 459)
        Me.dgv.TabIndex = 0
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.Location = New System.Drawing.Point(746, 495)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 1
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Location = New System.Drawing.Point(827, 495)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.rbTodos)
        Me.GroupBox1.Controls.Add(Me.rbSinPuesto)
        Me.GroupBox1.Location = New System.Drawing.Point(2, 466)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(200, 52)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtro"
        '
        'rbTodos
        '
        Me.rbTodos.AutoSize = True
        Me.rbTodos.Location = New System.Drawing.Point(116, 19)
        Me.rbTodos.Name = "rbTodos"
        Me.rbTodos.Size = New System.Drawing.Size(55, 17)
        Me.rbTodos.TabIndex = 1
        Me.rbTodos.Text = "Todos"
        Me.rbTodos.UseVisualStyleBackColor = True
        '
        'rbSinPuesto
        '
        Me.rbSinPuesto.AutoSize = True
        Me.rbSinPuesto.Location = New System.Drawing.Point(10, 19)
        Me.rbSinPuesto.Name = "rbSinPuesto"
        Me.rbSinPuesto.Size = New System.Drawing.Size(76, 17)
        Me.rbSinPuesto.TabIndex = 0
        Me.rbSinPuesto.Text = "Sin Puesto"
        Me.rbSinPuesto.UseVisualStyleBackColor = True
        '
        'colSerie
        '
        Me.colSerie.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colSerie.HeaderText = "Serie"
        Me.colSerie.Name = "colSerie"
        Me.colSerie.Width = 56
        '
        'colEquipo
        '
        Me.colEquipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colEquipo.HeaderText = "Equipo"
        Me.colEquipo.Name = "colEquipo"
        Me.colEquipo.Width = 65
        '
        'colCilindro
        '
        Me.colCilindro.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colCilindro.HeaderText = "Cilindro"
        Me.colCilindro.Name = "colCilindro"
        Me.colCilindro.Width = 66
        '
        'colFab
        '
        Me.colFab.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colFab.HeaderText = "Fabricacion"
        Me.colFab.Name = "colFab"
        Me.colFab.Width = 87
        '
        'colVto
        '
        Me.colVto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colVto.HeaderText = "Vto"
        Me.colVto.Name = "colVto"
        Me.colVto.Width = 48
        '
        'colSuc
        '
        Me.colSuc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colSuc.HeaderText = "Sucursal"
        Me.colSuc.Name = "colSuc"
        Me.colSuc.Width = 73
        '
        'colDomicilio
        '
        Me.colDomicilio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colDomicilio.HeaderText = "Domicilio"
        Me.colDomicilio.Name = "colDomicilio"
        Me.colDomicilio.Width = 74
        '
        'colCiudad
        '
        Me.colCiudad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colCiudad.HeaderText = "Localidad"
        Me.colCiudad.Name = "colCiudad"
        Me.colCiudad.Width = 78
        '
        'frmParqueCliente
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(904, 530)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.dgv)
        Me.Name = "frmParqueCliente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Parque de Cliente"
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbTodos As System.Windows.Forms.RadioButton
    Friend WithEvents rbSinPuesto As System.Windows.Forms.RadioButton
    Friend WithEvents colSerie As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colEquipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCilindro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFab As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colVto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSuc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDomicilio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCiudad As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
