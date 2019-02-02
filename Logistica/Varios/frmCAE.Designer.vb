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
        Me.dgv = New System.Windows.Forms.DataGridView
        Me.ctxMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuVerCbte = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuPrintCbte = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator
        Me.mnuPrintAll = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator
        Me.mnuCAE = New System.Windows.Forms.ToolStripMenuItem
        Me.prn = New System.Windows.Forms.PrintDialog
        Me.Label1 = New System.Windows.Forms.Label
        Me.gbSociedades = New System.Windows.Forms.GroupBox
        Me.cboLia = New System.Windows.Forms.ComboBox
        Me.rbLia = New System.Windows.Forms.RadioButton
        Me.cboGru = New System.Windows.Forms.ComboBox
        Me.cboDny = New System.Windows.Forms.ComboBox
        Me.rbGru = New System.Windows.Forms.RadioButton
        Me.rbDny = New System.Windows.Forms.RadioButton
        Me.gbBtn = New System.Windows.Forms.GroupBox
        Me.btnFCA = New System.Windows.Forms.Button
        Me.btnNDB = New System.Windows.Forms.Button
        Me.btnNDA = New System.Windows.Forms.Button
        Me.btnFCB = New System.Windows.Forms.Button
        Me.btnNCB = New System.Windows.Forms.Button
        Me.btnNCA = New System.Windows.Forms.Button
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ctxMenu.SuspendLayout()
        Me.gbSociedades.SuspendLayout()
        Me.gbBtn.SuspendLayout()
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
        Me.dgv.ContextMenuStrip = Me.ctxMenu
        Me.dgv.Location = New System.Drawing.Point(2, 3)
        Me.dgv.MultiSelect = False
        Me.dgv.Name = "dgv"
        Me.dgv.ReadOnly = True
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
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.Location = New System.Drawing.Point(2, 337)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(863, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'gbSociedades
        '
        Me.gbSociedades.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gbSociedades.Controls.Add(Me.cboLia)
        Me.gbSociedades.Controls.Add(Me.rbLia)
        Me.gbSociedades.Controls.Add(Me.cboGru)
        Me.gbSociedades.Controls.Add(Me.cboDny)
        Me.gbSociedades.Controls.Add(Me.rbGru)
        Me.gbSociedades.Controls.Add(Me.rbDny)
        Me.gbSociedades.Location = New System.Drawing.Point(2, 319)
        Me.gbSociedades.Name = "gbSociedades"
        Me.gbSociedades.Size = New System.Drawing.Size(147, 114)
        Me.gbSociedades.TabIndex = 7
        Me.gbSociedades.TabStop = False
        Me.gbSociedades.Text = "Sociedades"
        '
        'cboLia
        '
        Me.cboLia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLia.FormattingEnabled = True
        Me.cboLia.Location = New System.Drawing.Point(77, 81)
        Me.cboLia.Name = "cboLia"
        Me.cboLia.Size = New System.Drawing.Size(52, 21)
        Me.cboLia.TabIndex = 12
        Me.cboLia.Tag = "LIA"
        '
        'rbLia
        '
        Me.rbLia.AutoSize = True
        Me.rbLia.Location = New System.Drawing.Point(6, 82)
        Me.rbLia.Name = "rbLia"
        Me.rbLia.Size = New System.Drawing.Size(41, 17)
        Me.rbLia.TabIndex = 11
        Me.rbLia.Text = "LIA"
        Me.rbLia.UseVisualStyleBackColor = True
        '
        'cboGru
        '
        Me.cboGru.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGru.FormattingEnabled = True
        Me.cboGru.Location = New System.Drawing.Point(77, 51)
        Me.cboGru.Name = "cboGru"
        Me.cboGru.Size = New System.Drawing.Size(52, 21)
        Me.cboGru.TabIndex = 10
        Me.cboGru.Tag = "GRU"
        '
        'cboDny
        '
        Me.cboDny.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDny.FormattingEnabled = True
        Me.cboDny.Location = New System.Drawing.Point(77, 21)
        Me.cboDny.Name = "cboDny"
        Me.cboDny.Size = New System.Drawing.Size(52, 21)
        Me.cboDny.TabIndex = 9
        Me.cboDny.Tag = "DNY"
        '
        'rbGru
        '
        Me.rbGru.AutoSize = True
        Me.rbGru.Location = New System.Drawing.Point(6, 51)
        Me.rbGru.Name = "rbGru"
        Me.rbGru.Size = New System.Drawing.Size(49, 17)
        Me.rbGru.TabIndex = 1
        Me.rbGru.Text = "GRU"
        Me.rbGru.UseVisualStyleBackColor = True
        '
        'rbDny
        '
        Me.rbDny.AutoSize = True
        Me.rbDny.Checked = True
        Me.rbDny.Location = New System.Drawing.Point(6, 22)
        Me.rbDny.Name = "rbDny"
        Me.rbDny.Size = New System.Drawing.Size(48, 17)
        Me.rbDny.TabIndex = 0
        Me.rbDny.TabStop = True
        Me.rbDny.Text = "DNY"
        Me.rbDny.UseVisualStyleBackColor = True
        '
        'gbBtn
        '
        Me.gbBtn.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbBtn.Controls.Add(Me.btnFCA)
        Me.gbBtn.Controls.Add(Me.btnNDB)
        Me.gbBtn.Controls.Add(Me.btnNDA)
        Me.gbBtn.Controls.Add(Me.btnFCB)
        Me.gbBtn.Controls.Add(Me.btnNCB)
        Me.gbBtn.Controls.Add(Me.btnNCA)
        Me.gbBtn.Location = New System.Drawing.Point(155, 319)
        Me.gbBtn.Name = "gbBtn"
        Me.gbBtn.Size = New System.Drawing.Size(710, 114)
        Me.gbBtn.TabIndex = 4
        Me.gbBtn.TabStop = False
        '
        'btnFCA
        '
        Me.btnFCA.Location = New System.Drawing.Point(10, 38)
        Me.btnFCA.Name = "btnFCA"
        Me.btnFCA.Size = New System.Drawing.Size(225, 23)
        Me.btnFCA.TabIndex = 0
        Me.btnFCA.Tag = "Facturas A"
        Me.btnFCA.Text = "Facturas A"
        Me.btnFCA.UseVisualStyleBackColor = True
        '
        'btnNDB
        '
        Me.btnNDB.Location = New System.Drawing.Point(472, 67)
        Me.btnNDB.Name = "btnNDB"
        Me.btnNDB.Size = New System.Drawing.Size(225, 23)
        Me.btnNDB.TabIndex = 5
        Me.btnNDB.Tag = "N Débito B"
        Me.btnNDB.Text = "N Débito B"
        Me.btnNDB.UseVisualStyleBackColor = True
        '
        'btnNDA
        '
        Me.btnNDA.Location = New System.Drawing.Point(472, 38)
        Me.btnNDA.Name = "btnNDA"
        Me.btnNDA.Size = New System.Drawing.Size(225, 23)
        Me.btnNDA.TabIndex = 4
        Me.btnNDA.Tag = "N Débito A"
        Me.btnNDA.Text = "N Débito A"
        Me.btnNDA.UseVisualStyleBackColor = True
        '
        'btnFCB
        '
        Me.btnFCB.Location = New System.Drawing.Point(10, 67)
        Me.btnFCB.Name = "btnFCB"
        Me.btnFCB.Size = New System.Drawing.Size(225, 23)
        Me.btnFCB.TabIndex = 1
        Me.btnFCB.Tag = "Facturas B"
        Me.btnFCB.Text = "Facturas B"
        Me.btnFCB.UseVisualStyleBackColor = True
        '
        'btnNCB
        '
        Me.btnNCB.Location = New System.Drawing.Point(241, 67)
        Me.btnNCB.Name = "btnNCB"
        Me.btnNCB.Size = New System.Drawing.Size(225, 23)
        Me.btnNCB.TabIndex = 3
        Me.btnNCB.Tag = "N Crédito B"
        Me.btnNCB.Text = "N Crédito B"
        Me.btnNCB.UseVisualStyleBackColor = True
        '
        'btnNCA
        '
        Me.btnNCA.Location = New System.Drawing.Point(241, 38)
        Me.btnNCA.Name = "btnNCA"
        Me.btnNCA.Size = New System.Drawing.Size(225, 23)
        Me.btnNCA.TabIndex = 2
        Me.btnNCA.Tag = "N Crédito A"
        Me.btnNCA.Text = "N Crédito A"
        Me.btnNCA.UseVisualStyleBackColor = True
        '
        'frmCAE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(868, 434)
        Me.Controls.Add(Me.gbSociedades)
        Me.Controls.Add(Me.gbBtn)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgv)
        Me.Name = "frmCAE"
        Me.Text = "Solicitud de CAE"
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ctxMenu.ResumeLayout(False)
        Me.gbSociedades.ResumeLayout(False)
        Me.gbSociedades.PerformLayout()
        Me.gbBtn.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents ctxMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuVerCbte As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPrintCbte As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuPrintAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents prn As System.Windows.Forms.PrintDialog
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents gbSociedades As System.Windows.Forms.GroupBox
    Friend WithEvents rbGru As System.Windows.Forms.RadioButton
    Friend WithEvents rbDny As System.Windows.Forms.RadioButton
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuCAE As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gbBtn As System.Windows.Forms.GroupBox
    Friend WithEvents btnFCA As System.Windows.Forms.Button
    Friend WithEvents btnNDB As System.Windows.Forms.Button
    Friend WithEvents btnNDA As System.Windows.Forms.Button
    Friend WithEvents btnFCB As System.Windows.Forms.Button
    Friend WithEvents btnNCB As System.Windows.Forms.Button
    Friend WithEvents btnNCA As System.Windows.Forms.Button
    Friend WithEvents cboGru As System.Windows.Forms.ComboBox
    Friend WithEvents cboDny As System.Windows.Forms.ComboBox
    Friend WithEvents cboLia As System.Windows.Forms.ComboBox
    Friend WithEvents rbLia As System.Windows.Forms.RadioButton
End Class
