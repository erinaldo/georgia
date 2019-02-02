<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDestinos
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
        Me.lstDestinos = New System.Windows.Forms.ListBox
        Me.txtPh = New System.Windows.Forms.TextBox
        Me.txtCil = New System.Windows.Forms.TextBox
        Me.txtRec = New System.Windows.Forms.TextBox
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.btnRegistrar = New System.Windows.Forms.Button
        Me.txtV = New System.Windows.Forms.TextBox
        Me.txtH = New System.Windows.Forms.TextBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.tv = New System.Windows.Forms.TrackBar
        Me.th = New System.Windows.Forms.TrackBar
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.th, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.lstDestinos)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtPh)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtCil)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtRec)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnCancelar)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnRegistrar)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtV)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtH)
        Me.SplitContainer1.Panel2.Controls.Add(Me.PictureBox1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.tv)
        Me.SplitContainer1.Panel2.Controls.Add(Me.th)
        Me.SplitContainer1.Size = New System.Drawing.Size(752, 358)
        Me.SplitContainer1.SplitterDistance = 250
        Me.SplitContainer1.TabIndex = 0
        '
        'lstDestinos
        '
        Me.lstDestinos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstDestinos.FormattingEnabled = True
        Me.lstDestinos.Location = New System.Drawing.Point(0, 0)
        Me.lstDestinos.Name = "lstDestinos"
        Me.lstDestinos.Size = New System.Drawing.Size(250, 355)
        Me.lstDestinos.TabIndex = 0
        '
        'txtPh
        '
        Me.txtPh.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtPh.ForeColor = System.Drawing.Color.Red
        Me.txtPh.Location = New System.Drawing.Point(284, 195)
        Me.txtPh.Name = "txtPh"
        Me.txtPh.ReadOnly = True
        Me.txtPh.Size = New System.Drawing.Size(46, 20)
        Me.txtPh.TabIndex = 10
        Me.txtPh.Text = "0"
        Me.txtPh.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCil
        '
        Me.txtCil.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtCil.ForeColor = System.Drawing.Color.Red
        Me.txtCil.Location = New System.Drawing.Point(162, 195)
        Me.txtCil.Name = "txtCil"
        Me.txtCil.ReadOnly = True
        Me.txtCil.Size = New System.Drawing.Size(46, 20)
        Me.txtCil.TabIndex = 9
        Me.txtCil.Text = "0"
        Me.txtCil.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtRec
        '
        Me.txtRec.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtRec.ForeColor = System.Drawing.Color.Red
        Me.txtRec.Location = New System.Drawing.Point(106, 153)
        Me.txtRec.Name = "txtRec"
        Me.txtRec.ReadOnly = True
        Me.txtRec.Size = New System.Drawing.Size(46, 20)
        Me.txtRec.TabIndex = 8
        Me.txtRec.Text = "0"
        Me.txtRec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnCancelar
        '
        Me.btnCancelar.Enabled = False
        Me.btnCancelar.Location = New System.Drawing.Point(387, 323)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 7
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnRegistrar
        '
        Me.btnRegistrar.Enabled = False
        Me.btnRegistrar.Location = New System.Drawing.Point(306, 323)
        Me.btnRegistrar.Name = "btnRegistrar"
        Me.btnRegistrar.Size = New System.Drawing.Size(75, 23)
        Me.btnRegistrar.TabIndex = 5
        Me.btnRegistrar.Text = "Registrar"
        Me.btnRegistrar.UseVisualStyleBackColor = True
        '
        'txtV
        '
        Me.txtV.Location = New System.Drawing.Point(17, 22)
        Me.txtV.Name = "txtV"
        Me.txtV.ReadOnly = True
        Me.txtV.Size = New System.Drawing.Size(46, 20)
        Me.txtV.TabIndex = 4
        Me.txtV.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtH
        '
        Me.txtH.Location = New System.Drawing.Point(429, 282)
        Me.txtH.Name = "txtH"
        Me.txtH.ReadOnly = True
        Me.txtH.Size = New System.Drawing.Size(46, 20)
        Me.txtH.TabIndex = 3
        Me.txtH.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'PictureBox1
        '
        'Me.PictureBox1.Image = Global.Georgia.My.Resources.Resources.iram
        Me.PictureBox1.Location = New System.Drawing.Point(69, 48)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(354, 219)
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'tv
        '
        Me.tv.LargeChange = 20
        Me.tv.Location = New System.Drawing.Point(18, 48)
        Me.tv.Maximum = 40
        Me.tv.Minimum = -40
        Me.tv.Name = "tv"
        Me.tv.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.tv.Size = New System.Drawing.Size(45, 219)
        Me.tv.TabIndex = 1
        '
        'th
        '
        Me.th.LargeChange = 20
        Me.th.Location = New System.Drawing.Point(69, 273)
        Me.th.Maximum = 40
        Me.th.Minimum = -40
        Me.th.Name = "th"
        Me.th.Size = New System.Drawing.Size(354, 45)
        Me.th.TabIndex = 0
        '
        'frmDestinos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(752, 358)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "frmDestinos"
        Me.Text = "frmDestinos"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.th, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents tv As System.Windows.Forms.TrackBar
    Friend WithEvents th As System.Windows.Forms.TrackBar
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btnRegistrar As System.Windows.Forms.Button
    Friend WithEvents txtV As System.Windows.Forms.TextBox
    Friend WithEvents txtH As System.Windows.Forms.TextBox
    Friend WithEvents lstDestinos As System.Windows.Forms.ListBox
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents txtPh As System.Windows.Forms.TextBox
    Friend WithEvents txtCil As System.Windows.Forms.TextBox
    Friend WithEvents txtRec As System.Windows.Forms.TextBox
End Class
