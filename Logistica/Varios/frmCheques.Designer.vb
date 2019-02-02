<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCheques
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
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.btnCargar = New System.Windows.Forms.Button
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.txtFile2 = New System.Windows.Forms.TextBox
        Me.txtFile = New System.Windows.Forms.TextBox
        Me.btnGrabar = New System.Windows.Forms.Button
        Me.txtCta = New System.Windows.Forms.TextBox
        Me.txtNro = New System.Windows.Forms.TextBox
        Me.txtZip = New System.Windows.Forms.TextBox
        Me.txtSuc = New System.Windows.Forms.TextBox
        Me.txtBco = New System.Windows.Forms.TextBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnCargar)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ListBox1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtFile2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtFile)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnGrabar)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtCta)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtNro)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtZip)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtSuc)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtBco)
        Me.SplitContainer1.Panel2.Controls.Add(Me.PictureBox1)
        Me.SplitContainer1.Size = New System.Drawing.Size(919, 479)
        Me.SplitContainer1.SplitterDistance = 306
        Me.SplitContainer1.TabIndex = 0
        '
        'btnCargar
        '
        Me.btnCargar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCargar.Location = New System.Drawing.Point(3, 444)
        Me.btnCargar.Name = "btnCargar"
        Me.btnCargar.Size = New System.Drawing.Size(300, 23)
        Me.btnCargar.TabIndex = 1
        Me.btnCargar.Text = "Cargar Cheques"
        Me.btnCargar.UseVisualStyleBackColor = True
        '
        'ListBox1
        '
        Me.ListBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(0, 0)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(303, 433)
        Me.ListBox1.TabIndex = 0
        '
        'txtFile2
        '
        Me.txtFile2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFile2.Location = New System.Drawing.Point(3, 255)
        Me.txtFile2.MaxLength = 8
        Me.txtFile2.Name = "txtFile2"
        Me.txtFile2.ReadOnly = True
        Me.txtFile2.Size = New System.Drawing.Size(603, 20)
        Me.txtFile2.TabIndex = 8
        '
        'txtFile
        '
        Me.txtFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFile.Location = New System.Drawing.Point(3, 229)
        Me.txtFile.MaxLength = 8
        Me.txtFile.Name = "txtFile"
        Me.txtFile.ReadOnly = True
        Me.txtFile.Size = New System.Drawing.Size(603, 20)
        Me.txtFile.TabIndex = 7
        '
        'btnGrabar
        '
        Me.btnGrabar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnGrabar.Location = New System.Drawing.Point(212, 428)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(113, 23)
        Me.btnGrabar.TabIndex = 6
        Me.btnGrabar.Text = "Grabar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'txtCta
        '
        Me.txtCta.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtCta.Location = New System.Drawing.Point(212, 402)
        Me.txtCta.MaxLength = 11
        Me.txtCta.Name = "txtCta"
        Me.txtCta.Size = New System.Drawing.Size(113, 20)
        Me.txtCta.TabIndex = 5
        Me.txtCta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNro
        '
        Me.txtNro.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtNro.Location = New System.Drawing.Point(212, 376)
        Me.txtNro.MaxLength = 8
        Me.txtNro.Name = "txtNro"
        Me.txtNro.Size = New System.Drawing.Size(113, 20)
        Me.txtNro.TabIndex = 4
        Me.txtNro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtZip
        '
        Me.txtZip.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtZip.Location = New System.Drawing.Point(286, 350)
        Me.txtZip.MaxLength = 4
        Me.txtZip.Name = "txtZip"
        Me.txtZip.Size = New System.Drawing.Size(39, 20)
        Me.txtZip.TabIndex = 3
        Me.txtZip.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtSuc
        '
        Me.txtSuc.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtSuc.Location = New System.Drawing.Point(294, 324)
        Me.txtSuc.MaxLength = 3
        Me.txtSuc.Name = "txtSuc"
        Me.txtSuc.Size = New System.Drawing.Size(31, 20)
        Me.txtSuc.TabIndex = 2
        Me.txtSuc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtBco
        '
        Me.txtBco.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtBco.Location = New System.Drawing.Point(294, 298)
        Me.txtBco.MaxLength = 3
        Me.txtBco.Name = "txtBco"
        Me.txtBco.Size = New System.Drawing.Size(31, 20)
        Me.txtBco.TabIndex = 1
        Me.txtBco.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Location = New System.Drawing.Point(3, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(603, 220)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'frmCheques
        '
        Me.AcceptButton = Me.btnGrabar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(919, 479)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "frmCheques"
        Me.Tag = ""
        Me.Text = "FixCheques"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents txtCta As System.Windows.Forms.TextBox
    Friend WithEvents txtNro As System.Windows.Forms.TextBox
    Friend WithEvents txtZip As System.Windows.Forms.TextBox
    Friend WithEvents txtSuc As System.Windows.Forms.TextBox
    Friend WithEvents txtBco As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btnCargar As System.Windows.Forms.Button
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents txtFile As System.Windows.Forms.TextBox
    Friend WithEvents txtFile2 As System.Windows.Forms.TextBox
End Class
