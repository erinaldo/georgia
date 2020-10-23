<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCAE
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.dgv = New System.Windows.Forms.DataGridView
        Me.ctxMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuVerCbte = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuPrintCbte = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator
        Me.mnuPrintAll = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator
        Me.mnuCAE = New System.Windows.Forms.ToolStripMenuItem
        Me.prn = New System.Windows.Forms.PrintDialog
        Me.gbSociedades = New System.Windows.Forms.GroupBox
        Me.cboSch = New System.Windows.Forms.ComboBox
        Me.cboDny = New System.Windows.Forms.ComboBox
        Me.rbSch = New System.Windows.Forms.RadioButton
        Me.rbDny = New System.Windows.Forms.RadioButton
        Me.btnFCA = New System.Windows.Forms.Button
        Me.btnNDB = New System.Windows.Forms.Button
        Me.btnNDA = New System.Windows.Forms.Button
        Me.btnFCB = New System.Windows.Forms.Button
        Me.btnNCB = New System.Windows.Forms.Button
        Me.btnNCA = New System.Windows.Forms.Button
        Me.gbBtn1 = New System.Windows.Forms.GroupBox
        Me.gbBtn2 = New System.Windows.Forms.GroupBox
        Me.btnFCAc = New System.Windows.Forms.Button
        Me.btnNDBc = New System.Windows.Forms.Button
        Me.btnNCAc = New System.Windows.Forms.Button
        Me.btnNDAc = New System.Windows.Forms.Button
        Me.btnNCBc = New System.Windows.Forms.Button
        Me.btnFCBc = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ctxMenu.SuspendLayout()
        Me.gbSociedades.SuspendLayout()
        Me.gbBtn1.SuspendLayout()
        Me.gbBtn2.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToDeleteRows = False
        Me.dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.ContextMenuStrip = Me.ctxMenu
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgv.Location = New System.Drawing.Point(2, 3)
        Me.dgv.MultiSelect = False
        Me.dgv.Name = "dgv"
        Me.dgv.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv.Size = New System.Drawing.Size(863, 310)
        Me.dgv.TabIndex = 0
        '
        'ctxMenu
        '
        Me.ctxMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuVerCbte, Me.mnuPrintCbte, Me.ToolStripMenuItem1, Me.mnuPrintAll, Me.ToolStripMenuItem2, Me.mnuCAE})
        Me.ctxMenu.Name = "ctxMenu"
        Me.ctxMenu.Size = New System.Drawing.Size(261, 104)
        '
        'mnuVerCbte
        '
        Me.mnuVerCbte.Name = "mnuVerCbte"
        Me.mnuVerCbte.Size = New System.Drawing.Size(260, 22)
        Me.mnuVerCbte.Text = "Ver comprobante..."
        '
        'mnuPrintCbte
        '
        Me.mnuPrintCbte.Name = "mnuPrintCbte"
        Me.mnuPrintCbte.Size = New System.Drawing.Size(260, 22)
        Me.mnuPrintCbte.Text = "Imprimir comprobante..."
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(257, 6)
        '
        'mnuPrintAll
        '
        Me.mnuPrintAll.Name = "mnuPrintAll"
        Me.mnuPrintAll.Size = New System.Drawing.Size(260, 22)
        Me.mnuPrintAll.Text = "Imprimir todos los comprobantes..."
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(257, 6)
        '
        'mnuCAE
        '
        Me.mnuCAE.Name = "mnuCAE"
        Me.mnuCAE.Size = New System.Drawing.Size(260, 22)
        Me.mnuCAE.Text = "Volver a pedir CAE..."
        '
        'prn
        '
        Me.prn.AllowPrintToFile = False
        Me.prn.UseEXDialog = True
        '
        'gbSociedades
        '
        Me.gbSociedades.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gbSociedades.Controls.Add(Me.cboSch)
        Me.gbSociedades.Controls.Add(Me.cboDny)
        Me.gbSociedades.Controls.Add(Me.rbSch)
        Me.gbSociedades.Controls.Add(Me.rbDny)
        Me.gbSociedades.Location = New System.Drawing.Point(2, 332)
        Me.gbSociedades.Name = "gbSociedades"
        Me.gbSociedades.Size = New System.Drawing.Size(147, 101)
        Me.gbSociedades.TabIndex = 1
        Me.gbSociedades.TabStop = False
        Me.gbSociedades.Text = "Sociedades"
        '
        'cboSch
        '
        Me.cboSch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSch.FormattingEnabled = True
        Me.cboSch.Location = New System.Drawing.Point(77, 60)
        Me.cboSch.Name = "cboSch"
        Me.cboSch.Size = New System.Drawing.Size(52, 21)
        Me.cboSch.TabIndex = 3
        Me.cboSch.Tag = "SCH"
        '
        'cboDny
        '
        Me.cboDny.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDny.FormattingEnabled = True
        Me.cboDny.Location = New System.Drawing.Point(77, 31)
        Me.cboDny.Name = "cboDny"
        Me.cboDny.Size = New System.Drawing.Size(52, 21)
        Me.cboDny.TabIndex = 1
        Me.cboDny.Tag = "DNY"
        '
        'rbSch
        '
        Me.rbSch.AutoSize = True
        Me.rbSch.Location = New System.Drawing.Point(6, 60)
        Me.rbSch.Name = "rbSch"
        Me.rbSch.Size = New System.Drawing.Size(47, 17)
        Me.rbSch.TabIndex = 2
        Me.rbSch.Text = "SCH"
        Me.rbSch.UseVisualStyleBackColor = True
        '
        'rbDny
        '
        Me.rbDny.AutoSize = True
        Me.rbDny.Checked = True
        Me.rbDny.Location = New System.Drawing.Point(5, 31)
        Me.rbDny.Name = "rbDny"
        Me.rbDny.Size = New System.Drawing.Size(48, 17)
        Me.rbDny.TabIndex = 0
        Me.rbDny.TabStop = True
        Me.rbDny.Text = "DNY"
        Me.rbDny.UseVisualStyleBackColor = True
        '
        'btnFCA
        '
        Me.btnFCA.Location = New System.Drawing.Point(6, 31)
        Me.btnFCA.Name = "btnFCA"
        Me.btnFCA.Size = New System.Drawing.Size(97, 23)
        Me.btnFCA.TabIndex = 0
        Me.btnFCA.Tag = "Facturas A"
        Me.btnFCA.Text = "Facturas A"
        Me.btnFCA.UseVisualStyleBackColor = True
        '
        'btnNDB
        '
        Me.btnNDB.Location = New System.Drawing.Point(212, 60)
        Me.btnNDB.Name = "btnNDB"
        Me.btnNDB.Size = New System.Drawing.Size(97, 23)
        Me.btnNDB.TabIndex = 5
        Me.btnNDB.Tag = "N Débito B"
        Me.btnNDB.Text = "N Débito B"
        Me.btnNDB.UseVisualStyleBackColor = True
        '
        'btnNDA
        '
        Me.btnNDA.Location = New System.Drawing.Point(212, 31)
        Me.btnNDA.Name = "btnNDA"
        Me.btnNDA.Size = New System.Drawing.Size(97, 23)
        Me.btnNDA.TabIndex = 4
        Me.btnNDA.Tag = "N Débito A"
        Me.btnNDA.Text = "N Débito A"
        Me.btnNDA.UseVisualStyleBackColor = True
        '
        'btnFCB
        '
        Me.btnFCB.Location = New System.Drawing.Point(6, 60)
        Me.btnFCB.Name = "btnFCB"
        Me.btnFCB.Size = New System.Drawing.Size(97, 23)
        Me.btnFCB.TabIndex = 1
        Me.btnFCB.Tag = "Facturas B"
        Me.btnFCB.Text = "Facturas B"
        Me.btnFCB.UseVisualStyleBackColor = True
        '
        'btnNCB
        '
        Me.btnNCB.Location = New System.Drawing.Point(109, 60)
        Me.btnNCB.Name = "btnNCB"
        Me.btnNCB.Size = New System.Drawing.Size(97, 23)
        Me.btnNCB.TabIndex = 3
        Me.btnNCB.Tag = "N Crédito B"
        Me.btnNCB.Text = "N Crédito B"
        Me.btnNCB.UseVisualStyleBackColor = True
        '
        'btnNCA
        '
        Me.btnNCA.Location = New System.Drawing.Point(109, 31)
        Me.btnNCA.Name = "btnNCA"
        Me.btnNCA.Size = New System.Drawing.Size(97, 23)
        Me.btnNCA.TabIndex = 2
        Me.btnNCA.Tag = "N Crédito A"
        Me.btnNCA.Text = "N Crédito A"
        Me.btnNCA.UseVisualStyleBackColor = True
        '
        'gbBtn1
        '
        Me.gbBtn1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gbBtn1.Controls.Add(Me.btnFCA)
        Me.gbBtn1.Controls.Add(Me.btnNDB)
        Me.gbBtn1.Controls.Add(Me.btnNCA)
        Me.gbBtn1.Controls.Add(Me.btnNDA)
        Me.gbBtn1.Controls.Add(Me.btnNCB)
        Me.gbBtn1.Controls.Add(Me.btnFCB)
        Me.gbBtn1.Location = New System.Drawing.Point(155, 332)
        Me.gbBtn1.Name = "gbBtn1"
        Me.gbBtn1.Size = New System.Drawing.Size(327, 101)
        Me.gbBtn1.TabIndex = 3
        Me.gbBtn1.TabStop = False
        Me.gbBtn1.Text = "Facturas Electrónicas"
        '
        'gbBtn2
        '
        Me.gbBtn2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gbBtn2.Controls.Add(Me.btnFCAc)
        Me.gbBtn2.Controls.Add(Me.btnNDBc)
        Me.gbBtn2.Controls.Add(Me.btnNCAc)
        Me.gbBtn2.Controls.Add(Me.btnNDAc)
        Me.gbBtn2.Controls.Add(Me.btnNCBc)
        Me.gbBtn2.Controls.Add(Me.btnFCBc)
        Me.gbBtn2.Location = New System.Drawing.Point(488, 332)
        Me.gbBtn2.Name = "gbBtn2"
        Me.gbBtn2.Size = New System.Drawing.Size(327, 101)
        Me.gbBtn2.TabIndex = 4
        Me.gbBtn2.TabStop = False
        Me.gbBtn2.Text = "Facturas Electrónicas de Crédito"
        '
        'btnFCAc
        '
        Me.btnFCAc.Location = New System.Drawing.Point(6, 31)
        Me.btnFCAc.Name = "btnFCAc"
        Me.btnFCAc.Size = New System.Drawing.Size(97, 23)
        Me.btnFCAc.TabIndex = 0
        Me.btnFCAc.Tag = "Facturas A"
        Me.btnFCAc.Text = "Facturas A"
        Me.btnFCAc.UseVisualStyleBackColor = True
        '
        'btnNDBc
        '
        Me.btnNDBc.Location = New System.Drawing.Point(212, 60)
        Me.btnNDBc.Name = "btnNDBc"
        Me.btnNDBc.Size = New System.Drawing.Size(97, 23)
        Me.btnNDBc.TabIndex = 5
        Me.btnNDBc.Tag = "N Débito B"
        Me.btnNDBc.Text = "N Débito B"
        Me.btnNDBc.UseVisualStyleBackColor = True
        '
        'btnNCAc
        '
        Me.btnNCAc.Location = New System.Drawing.Point(109, 31)
        Me.btnNCAc.Name = "btnNCAc"
        Me.btnNCAc.Size = New System.Drawing.Size(97, 23)
        Me.btnNCAc.TabIndex = 2
        Me.btnNCAc.Tag = "N Crédito A"
        Me.btnNCAc.Text = "N Crédito A"
        Me.btnNCAc.UseVisualStyleBackColor = True
        '
        'btnNDAc
        '
        Me.btnNDAc.Location = New System.Drawing.Point(212, 31)
        Me.btnNDAc.Name = "btnNDAc"
        Me.btnNDAc.Size = New System.Drawing.Size(97, 23)
        Me.btnNDAc.TabIndex = 4
        Me.btnNDAc.Tag = "N Débito A"
        Me.btnNDAc.Text = "N Débito A"
        Me.btnNDAc.UseVisualStyleBackColor = True
        '
        'btnNCBc
        '
        Me.btnNCBc.Location = New System.Drawing.Point(109, 60)
        Me.btnNCBc.Name = "btnNCBc"
        Me.btnNCBc.Size = New System.Drawing.Size(97, 23)
        Me.btnNCBc.TabIndex = 3
        Me.btnNCBc.Tag = "N Crédito B"
        Me.btnNCBc.Text = "N Crédito B"
        Me.btnNCBc.UseVisualStyleBackColor = True
        '
        'btnFCBc
        '
        Me.btnFCBc.Location = New System.Drawing.Point(6, 60)
        Me.btnFCBc.Name = "btnFCBc"
        Me.btnFCBc.Size = New System.Drawing.Size(97, 23)
        Me.btnFCBc.TabIndex = 1
        Me.btnFCBc.Tag = "Facturas B"
        Me.btnFCBc.Text = "Facturas B"
        Me.btnFCBc.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.BackColor = System.Drawing.SystemColors.Info
        Me.Label1.Location = New System.Drawing.Point(2, 316)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(863, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmCAE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(868, 434)
        Me.Controls.Add(Me.gbBtn2)
        Me.Controls.Add(Me.gbBtn1)
        Me.Controls.Add(Me.gbSociedades)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgv)
        Me.Name = "frmCAE"
        Me.Text = "Solicitud de CAE"
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ctxMenu.ResumeLayout(False)
        Me.gbSociedades.ResumeLayout(False)
        Me.gbSociedades.PerformLayout()
        Me.gbBtn1.ResumeLayout(False)
        Me.gbBtn2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents ctxMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuVerCbte As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPrintCbte As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuPrintAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents prn As System.Windows.Forms.PrintDialog
    Friend WithEvents gbSociedades As System.Windows.Forms.GroupBox
    Friend WithEvents rbSch As System.Windows.Forms.RadioButton
    Friend WithEvents rbDny As System.Windows.Forms.RadioButton
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuCAE As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnFCA As System.Windows.Forms.Button
    Friend WithEvents btnNDB As System.Windows.Forms.Button
    Friend WithEvents btnNDA As System.Windows.Forms.Button
    Friend WithEvents btnFCB As System.Windows.Forms.Button
    Friend WithEvents btnNCB As System.Windows.Forms.Button
    Friend WithEvents btnNCA As System.Windows.Forms.Button
    Friend WithEvents cboSch As System.Windows.Forms.ComboBox
    Friend WithEvents cboDny As System.Windows.Forms.ComboBox
    Friend WithEvents gbBtn1 As System.Windows.Forms.GroupBox
    Friend WithEvents gbBtn2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnFCAc As System.Windows.Forms.Button
    Friend WithEvents btnNDBc As System.Windows.Forms.Button
    Friend WithEvents btnNCAc As System.Windows.Forms.Button
    Friend WithEvents btnNDAc As System.Windows.Forms.Button
    Friend WithEvents btnNCBc As System.Windows.Forms.Button
    Friend WithEvents btnFCBc As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
