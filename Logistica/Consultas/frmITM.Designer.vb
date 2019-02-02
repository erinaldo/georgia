<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmITM
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
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.VerStockToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.btnBuscar = New System.Windows.Forms.Button
        Me.txt = New System.Windows.Forms.TextBox
        Me.radioCod = New System.Windows.Forms.RadioButton
        Me.radioNombre = New System.Windows.Forms.RadioButton
        Me.Label5 = New System.Windows.Forms.Label
        Me.rdblarga = New System.Windows.Forms.RadioButton
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToDeleteRows = False
        Me.dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.ContextMenuStrip = Me.ContextMenuStrip1
        Me.dgv.Location = New System.Drawing.Point(12, 57)
        Me.dgv.Name = "dgv"
        Me.dgv.ReadOnly = True
        Me.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv.Size = New System.Drawing.Size(758, 336)
        Me.dgv.TabIndex = 0
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.VerStockToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(124, 26)
        '
        'VerStockToolStripMenuItem
        '
        Me.VerStockToolStripMenuItem.Name = "VerStockToolStripMenuItem"
        Me.VerStockToolStripMenuItem.Size = New System.Drawing.Size(123, 22)
        Me.VerStockToolStripMenuItem.Text = "Ver Stock"
        '
        'btnBuscar
        '
        Me.btnBuscar.Location = New System.Drawing.Point(437, 8)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(149, 20)
        Me.btnBuscar.TabIndex = 1
        Me.btnBuscar.Text = " Consultar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'txt
        '
        Me.txt.Location = New System.Drawing.Point(160, 8)
        Me.txt.Name = "txt"
        Me.txt.Size = New System.Drawing.Size(271, 20)
        Me.txt.TabIndex = 2
        '
        'radioCod
        '
        Me.radioCod.AutoSize = True
        Me.radioCod.Checked = True
        Me.radioCod.Location = New System.Drawing.Point(160, 34)
        Me.radioCod.Name = "radioCod"
        Me.radioCod.Size = New System.Drawing.Size(58, 17)
        Me.radioCod.TabIndex = 3
        Me.radioCod.TabStop = True
        Me.radioCod.Text = "Codigo"
        Me.radioCod.UseVisualStyleBackColor = True
        '
        'radioNombre
        '
        Me.radioNombre.AutoSize = True
        Me.radioNombre.Location = New System.Drawing.Point(224, 34)
        Me.radioNombre.Name = "radioNombre"
        Me.radioNombre.Size = New System.Drawing.Size(108, 17)
        Me.radioNombre.TabIndex = 4
        Me.radioNombre.Text = "Descripcion corta"
        Me.radioNombre.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(592, 8)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(159, 42)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "No se encontraron" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "resultados"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label5.Visible = False
        '
        'rdblarga
        '
        Me.rdblarga.AutoSize = True
        Me.rdblarga.Location = New System.Drawing.Point(338, 34)
        Me.rdblarga.Name = "rdblarga"
        Me.rdblarga.Size = New System.Drawing.Size(111, 17)
        Me.rdblarga.TabIndex = 10
        Me.rdblarga.Text = "Descripcion Larga"
        Me.rdblarga.UseVisualStyleBackColor = True
        '
        'frmITM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(783, 439)
        Me.Controls.Add(Me.rdblarga)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.radioNombre)
        Me.Controls.Add(Me.radioCod)
        Me.Controls.Add(Me.txt)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.dgv)
        Me.Name = "frmITM"
        Me.Text = " Consulta Articulo"
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents txt As System.Windows.Forms.TextBox
    Friend WithEvents radioCod As System.Windows.Forms.RadioButton
    Friend WithEvents radioNombre As System.Windows.Forms.RadioButton
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents rdblarga As System.Windows.Forms.RadioButton
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents VerStockToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
