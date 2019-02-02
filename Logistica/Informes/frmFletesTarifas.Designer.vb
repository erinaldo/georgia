<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFletesTarifas
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.dgv = New System.Windows.Forms.DataGridView
        Me.btnAceptar = New System.Windows.Forms.Button
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.colKg = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCFEint = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colGBAint = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCFEext = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colGBAext = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgv
        '
        Me.dgv.AllowUserToResizeColumns = False
        Me.dgv.AllowUserToResizeRows = False
        Me.dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colKg, Me.colCFEint, Me.colGBAint, Me.colCFEext, Me.colGBAext})
        Me.dgv.Location = New System.Drawing.Point(12, 12)
        Me.dgv.Name = "dgv"
        Me.dgv.Size = New System.Drawing.Size(561, 276)
        Me.dgv.TabIndex = 0
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.Location = New System.Drawing.Point(418, 294)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 1
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Location = New System.Drawing.Point(498, 294)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'colKg
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Format = "N2"
        Me.colKg.DefaultCellStyle = DataGridViewCellStyle1
        Me.colKg.HeaderText = "Kg"
        Me.colKg.Name = "colKg"
        Me.colKg.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'colCFEint
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N4"
        Me.colCFEint.DefaultCellStyle = DataGridViewCellStyle2
        Me.colCFEint.HeaderText = "CF (Interno)"
        Me.colCFEint.Name = "colCFEint"
        Me.colCFEint.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'colGBAint
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N4"
        Me.colGBAint.DefaultCellStyle = DataGridViewCellStyle3
        Me.colGBAint.HeaderText = "GBA (Interno)"
        Me.colGBAint.Name = "colGBAint"
        Me.colGBAint.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'colCFEext
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N4"
        Me.colCFEext.DefaultCellStyle = DataGridViewCellStyle4
        Me.colCFEext.HeaderText = "CF (Externo)"
        Me.colCFEext.Name = "colCFEext"
        '
        'colGBAext
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomRight
        DataGridViewCellStyle5.Format = "N4"
        Me.colGBAext.DefaultCellStyle = DataGridViewCellStyle5
        Me.colGBAext.HeaderText = "GBA (Externo)"
        Me.colGBAext.Name = "colGBAext"
        '
        'frmFletesTarifas
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(585, 329)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.dgv)
        Me.Name = "frmFletesTarifas"
        Me.Text = "Tarifas Fletes"
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents colKg As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCFEint As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colGBAint As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCFEext As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colGBAext As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
