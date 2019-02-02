<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmIRAM
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
        Me.btnAbrir = New System.Windows.Forms.Button
        Me.dgv = New System.Windows.Forms.DataGridView
        Me.btnImprimirIRAM = New System.Windows.Forms.Button
        Me.lblCant = New System.Windows.Forms.Label
        Me.btnMarcar = New System.Windows.Forms.Button
        Me.btnDesmarcar = New System.Windows.Forms.Button
        Me.txtCliente = New System.Windows.Forms.TextBox
        Me.btnTxtGCBA = New System.Windows.Forms.Button
        Me.txtIntervencion = New System.Windows.Forms.TextBox
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.colX = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.colSerie = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colTipo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCilindro = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colFab = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colRecarga = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colPh = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colIram = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btn1Kg = New System.Windows.Forms.Button
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnAbrir
        '
        Me.btnAbrir.Location = New System.Drawing.Point(339, 12)
        Me.btnAbrir.Name = "btnAbrir"
        Me.btnAbrir.Size = New System.Drawing.Size(75, 23)
        Me.btnAbrir.TabIndex = 1
        Me.btnAbrir.Text = "Abrir"
        Me.btnAbrir.UseVisualStyleBackColor = True
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
        Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colX, Me.colSerie, Me.colTipo, Me.colCilindro, Me.colFab, Me.colRecarga, Me.colPh, Me.colIram})
        Me.dgv.Location = New System.Drawing.Point(12, 41)
        Me.dgv.Name = "dgv"
        Me.dgv.Size = New System.Drawing.Size(723, 327)
        Me.dgv.TabIndex = 2
        '
        'btnImprimirIRAM
        '
        Me.btnImprimirIRAM.Enabled = False
        Me.btnImprimirIRAM.Location = New System.Drawing.Point(420, 12)
        Me.btnImprimirIRAM.Name = "btnImprimirIRAM"
        Me.btnImprimirIRAM.Size = New System.Drawing.Size(113, 23)
        Me.btnImprimirIRAM.TabIndex = 4
        Me.btnImprimirIRAM.Text = "Imprmir IRAM"
        Me.btnImprimirIRAM.UseVisualStyleBackColor = True
        '
        'lblCant
        '
        Me.lblCant.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblCant.AutoSize = True
        Me.lblCant.Location = New System.Drawing.Point(12, 382)
        Me.lblCant.Name = "lblCant"
        Me.lblCant.Size = New System.Drawing.Size(61, 13)
        Me.lblCant.TabIndex = 3
        Me.lblCant.Text = "Cantidad: 0"
        '
        'btnMarcar
        '
        Me.btnMarcar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnMarcar.Location = New System.Drawing.Point(579, 374)
        Me.btnMarcar.Name = "btnMarcar"
        Me.btnMarcar.Size = New System.Drawing.Size(75, 23)
        Me.btnMarcar.TabIndex = 5
        Me.btnMarcar.Text = "Marcar"
        Me.btnMarcar.UseVisualStyleBackColor = True
        '
        'btnDesmarcar
        '
        Me.btnDesmarcar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnDesmarcar.Location = New System.Drawing.Point(660, 374)
        Me.btnDesmarcar.Name = "btnDesmarcar"
        Me.btnDesmarcar.Size = New System.Drawing.Size(75, 23)
        Me.btnDesmarcar.TabIndex = 6
        Me.btnDesmarcar.Text = "Desmarcar"
        Me.btnDesmarcar.UseVisualStyleBackColor = True
        '
        'txtCliente
        '
        Me.txtCliente.Location = New System.Drawing.Point(104, 12)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(229, 20)
        Me.txtCliente.TabIndex = 7
        '
        'btnTxtGCBA
        '
        Me.btnTxtGCBA.Enabled = False
        Me.btnTxtGCBA.Location = New System.Drawing.Point(622, 12)
        Me.btnTxtGCBA.Name = "btnTxtGCBA"
        Me.btnTxtGCBA.Size = New System.Drawing.Size(113, 23)
        Me.btnTxtGCBA.TabIndex = 9
        Me.btnTxtGCBA.Text = "Generar TXT GCBA"
        Me.btnTxtGCBA.UseVisualStyleBackColor = True
        '
        'txtIntervencion
        '
        Me.txtIntervencion.Location = New System.Drawing.Point(15, 12)
        Me.txtIntervencion.Name = "txtIntervencion"
        Me.txtIntervencion.ReadOnly = True
        Me.txtIntervencion.Size = New System.Drawing.Size(83, 20)
        Me.txtIntervencion.TabIndex = 10
        '
        'colX
        '
        Me.colX.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colX.FalseValue = "0"
        Me.colX.HeaderText = "X"
        Me.colX.Name = "colX"
        Me.colX.TrueValue = "1"
        Me.colX.Width = 20
        '
        'colSerie
        '
        Me.colSerie.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colSerie.HeaderText = "Serie"
        Me.colSerie.Name = "colSerie"
        Me.colSerie.ReadOnly = True
        Me.colSerie.Width = 56
        '
        'colTipo
        '
        Me.colTipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colTipo.HeaderText = "Tipo"
        Me.colTipo.Name = "colTipo"
        Me.colTipo.ReadOnly = True
        Me.colTipo.Width = 53
        '
        'colCilindro
        '
        Me.colCilindro.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colCilindro.HeaderText = "Cilindro"
        Me.colCilindro.Name = "colCilindro"
        Me.colCilindro.ReadOnly = True
        Me.colCilindro.Width = 66
        '
        'colFab
        '
        Me.colFab.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colFab.HeaderText = "Fabricación"
        Me.colFab.Name = "colFab"
        Me.colFab.ReadOnly = True
        Me.colFab.Width = 87
        '
        'colRecarga
        '
        Me.colRecarga.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colRecarga.HeaderText = "Vto. Rec"
        Me.colRecarga.Name = "colRecarga"
        Me.colRecarga.ReadOnly = True
        Me.colRecarga.Width = 74
        '
        'colPh
        '
        Me.colPh.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colPh.HeaderText = "Vto. PH"
        Me.colPh.Name = "colPh"
        Me.colPh.ReadOnly = True
        Me.colPh.Width = 69
        '
        'colIram
        '
        Me.colIram.HeaderText = "Iram"
        Me.colIram.Name = "colIram"
        Me.colIram.Visible = False
        '
        'btn1Kg
        '
        Me.btn1Kg.Enabled = False
        Me.btn1Kg.Location = New System.Drawing.Point(539, 12)
        Me.btn1Kg.Name = "btn1Kg"
        Me.btn1Kg.Size = New System.Drawing.Size(77, 23)
        Me.btn1Kg.TabIndex = 11
        Me.btn1Kg.Text = "IRAM 1 Kg"
        Me.btn1Kg.UseVisualStyleBackColor = True
        '
        'frmIRAM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(747, 404)
        Me.Controls.Add(Me.btn1Kg)
        Me.Controls.Add(Me.txtIntervencion)
        Me.Controls.Add(Me.btnTxtGCBA)
        Me.Controls.Add(Me.txtCliente)
        Me.Controls.Add(Me.btnDesmarcar)
        Me.Controls.Add(Me.btnMarcar)
        Me.Controls.Add(Me.lblCant)
        Me.Controls.Add(Me.btnImprimirIRAM)
        Me.Controls.Add(Me.dgv)
        Me.Controls.Add(Me.btnAbrir)
        Me.Name = "frmIRAM"
        Me.Text = "Impresión de Tarjetas IRAM / GCBA"
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnAbrir As System.Windows.Forms.Button
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents btnImprimirIRAM As System.Windows.Forms.Button
    Friend WithEvents lblCant As System.Windows.Forms.Label
    Friend WithEvents btnMarcar As System.Windows.Forms.Button
    Friend WithEvents btnDesmarcar As System.Windows.Forms.Button
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents btnTxtGCBA As System.Windows.Forms.Button
    Friend WithEvents txtIntervencion As System.Windows.Forms.TextBox
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents colX As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colSerie As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCilindro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFab As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRecarga As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPh As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIram As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btn1Kg As System.Windows.Forms.Button
End Class
