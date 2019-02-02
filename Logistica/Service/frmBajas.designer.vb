<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBajas
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
        Dim Label3 As System.Windows.Forms.Label
        Dim Label4 As System.Windows.Forms.Label
        Dim Label5 As System.Windows.Forms.Label
        Dim Label6 As System.Windows.Forms.Label
        Dim Label7 As System.Windows.Forms.Label
        Dim Label8 As System.Windows.Forms.Label
        Dim Label9 As System.Windows.Forms.Label
        Dim Label10 As System.Windows.Forms.Label
        Me.lstMotivos = New System.Windows.Forms.ListBox
        Me.txtObs = New System.Windows.Forms.TextBox
        Me.btnAceptar = New System.Windows.Forms.Button
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.txtSerie = New System.Windows.Forms.TextBox
        Me.txtCilindro = New System.Windows.Forms.TextBox
        Me.txtEquipo = New System.Windows.Forms.TextBox
        Me.gbManga = New System.Windows.Forms.GroupBox
        Me.cboDiametro = New System.Windows.Forms.ComboBox
        Me.cboTipo = New System.Windows.Forms.ComboBox
        Me.txtReal = New System.Windows.Forms.TextBox
        Me.cboLongitud = New System.Windows.Forms.ComboBox
        Me.cboSello = New System.Windows.Forms.ComboBox
        Label1 = New System.Windows.Forms.Label
        Label2 = New System.Windows.Forms.Label
        Label3 = New System.Windows.Forms.Label
        Label4 = New System.Windows.Forms.Label
        Label5 = New System.Windows.Forms.Label
        Label6 = New System.Windows.Forms.Label
        Label7 = New System.Windows.Forms.Label
        Label8 = New System.Windows.Forms.Label
        Label9 = New System.Windows.Forms.Label
        Label10 = New System.Windows.Forms.Label
        Me.gbManga.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(8, 62)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(82, 13)
        Label1.TabIndex = 7
        Label1.Text = "Motivos de baja"
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Location = New System.Drawing.Point(12, 242)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(78, 13)
        Label2.TabIndex = 10
        Label2.Text = "Observaciones"
        '
        'Label3
        '
        Label3.AutoSize = True
        Label3.Location = New System.Drawing.Point(8, 14)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(34, 13)
        Label3.TabIndex = 0
        Label3.Text = "Serie:"
        '
        'Label4
        '
        Label4.AutoSize = True
        Label4.Location = New System.Drawing.Point(93, 14)
        Label4.Name = "Label4"
        Label4.Size = New System.Drawing.Size(41, 13)
        Label4.TabIndex = 2
        Label4.Text = "Cilindro"
        '
        'Label5
        '
        Label5.AutoSize = True
        Label5.Location = New System.Drawing.Point(227, 15)
        Label5.Name = "Label5"
        Label5.Size = New System.Drawing.Size(43, 13)
        Label5.TabIndex = 4
        Label5.Text = "Equipo:"
        '
        'Label6
        '
        Label6.AutoSize = True
        Label6.Location = New System.Drawing.Point(6, 59)
        Label6.Name = "Label6"
        Label6.Size = New System.Drawing.Size(92, 13)
        Label6.TabIndex = 2
        Label6.Text = "Longitud Nominal:"
        '
        'Label7
        '
        Label7.AutoSize = True
        Label7.Location = New System.Drawing.Point(6, 91)
        Label7.Name = "Label7"
        Label7.Size = New System.Drawing.Size(76, 13)
        Label7.TabIndex = 4
        Label7.Text = "Longitud Real:"
        '
        'Label8
        '
        Label8.AutoSize = True
        Label8.Location = New System.Drawing.Point(6, 120)
        Label8.Name = "Label8"
        Label8.Size = New System.Drawing.Size(52, 13)
        Label8.TabIndex = 6
        Label8.Text = "Diametro:"
        '
        'Label9
        '
        Label9.AutoSize = True
        Label9.Location = New System.Drawing.Point(6, 29)
        Label9.Name = "Label9"
        Label9.Size = New System.Drawing.Size(47, 13)
        Label9.TabIndex = 0
        Label9.Text = "Material:"
        '
        'lstMotivos
        '
        Me.lstMotivos.FormattingEnabled = True
        Me.lstMotivos.Location = New System.Drawing.Point(11, 78)
        Me.lstMotivos.Name = "lstMotivos"
        Me.lstMotivos.Size = New System.Drawing.Size(203, 147)
        Me.lstMotivos.TabIndex = 8
        '
        'txtObs
        '
        Me.txtObs.Location = New System.Drawing.Point(11, 258)
        Me.txtObs.MaxLength = 245
        Me.txtObs.Multiline = True
        Me.txtObs.Name = "txtObs"
        Me.txtObs.Size = New System.Drawing.Size(439, 70)
        Me.txtObs.TabIndex = 11
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(294, 334)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 12
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Location = New System.Drawing.Point(375, 334)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 0
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'txtSerie
        '
        Me.txtSerie.Location = New System.Drawing.Point(11, 30)
        Me.txtSerie.Name = "txtSerie"
        Me.txtSerie.ReadOnly = True
        Me.txtSerie.Size = New System.Drawing.Size(79, 20)
        Me.txtSerie.TabIndex = 1
        Me.txtSerie.TabStop = False
        '
        'txtCilindro
        '
        Me.txtCilindro.Location = New System.Drawing.Point(96, 30)
        Me.txtCilindro.Name = "txtCilindro"
        Me.txtCilindro.ReadOnly = True
        Me.txtCilindro.Size = New System.Drawing.Size(118, 20)
        Me.txtCilindro.TabIndex = 3
        '
        'txtEquipo
        '
        Me.txtEquipo.Location = New System.Drawing.Point(230, 30)
        Me.txtEquipo.Name = "txtEquipo"
        Me.txtEquipo.ReadOnly = True
        Me.txtEquipo.Size = New System.Drawing.Size(226, 20)
        Me.txtEquipo.TabIndex = 5
        Me.txtEquipo.TabStop = False
        '
        'gbManga
        '
        Me.gbManga.Controls.Add(Label10)
        Me.gbManga.Controls.Add(Me.cboSello)
        Me.gbManga.Controls.Add(Me.cboLongitud)
        Me.gbManga.Controls.Add(Me.cboDiametro)
        Me.gbManga.Controls.Add(Me.cboTipo)
        Me.gbManga.Controls.Add(Label9)
        Me.gbManga.Controls.Add(Me.txtReal)
        Me.gbManga.Controls.Add(Label8)
        Me.gbManga.Controls.Add(Label7)
        Me.gbManga.Controls.Add(Label6)
        Me.gbManga.Enabled = False
        Me.gbManga.Location = New System.Drawing.Point(223, 62)
        Me.gbManga.Name = "gbManga"
        Me.gbManga.Size = New System.Drawing.Size(233, 190)
        Me.gbManga.TabIndex = 9
        Me.gbManga.TabStop = False
        Me.gbManga.Text = "Manguera"
        '
        'cboDiametro
        '
        Me.cboDiametro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDiametro.FormattingEnabled = True
        Me.cboDiametro.Items.AddRange(New Object() {"Sintética", "Goma", "Lino"})
        Me.cboDiametro.Location = New System.Drawing.Point(105, 117)
        Me.cboDiametro.Name = "cboDiametro"
        Me.cboDiametro.Size = New System.Drawing.Size(122, 21)
        Me.cboDiametro.TabIndex = 7
        '
        'cboTipo
        '
        Me.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipo.FormattingEnabled = True
        Me.cboTipo.Items.AddRange(New Object() {"Sintética", "Goma", "Lino"})
        Me.cboTipo.Location = New System.Drawing.Point(105, 26)
        Me.cboTipo.Name = "cboTipo"
        Me.cboTipo.Size = New System.Drawing.Size(122, 21)
        Me.cboTipo.TabIndex = 1
        '
        'txtReal
        '
        Me.txtReal.Location = New System.Drawing.Point(105, 88)
        Me.txtReal.Name = "txtReal"
        Me.txtReal.Size = New System.Drawing.Size(123, 20)
        Me.txtReal.TabIndex = 5
        Me.txtReal.Text = "0"
        Me.txtReal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboLongitud
        '
        Me.cboLongitud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLongitud.FormattingEnabled = True
        Me.cboLongitud.Items.AddRange(New Object() {"Sintética", "Goma", "Lino"})
        Me.cboLongitud.Location = New System.Drawing.Point(104, 56)
        Me.cboLongitud.Name = "cboLongitud"
        Me.cboLongitud.Size = New System.Drawing.Size(122, 21)
        Me.cboLongitud.TabIndex = 8
        '
        'cboSello
        '
        Me.cboSello.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSello.FormattingEnabled = True
        Me.cboSello.Items.AddRange(New Object() {"Sintética", "Goma", "Lino"})
        Me.cboSello.Location = New System.Drawing.Point(104, 147)
        Me.cboSello.Name = "cboSello"
        Me.cboSello.Size = New System.Drawing.Size(122, 21)
        Me.cboSello.TabIndex = 9
        '
        'Label10
        '
        Label10.AutoSize = True
        Label10.Location = New System.Drawing.Point(6, 150)
        Label10.Name = "Label10"
        Label10.Size = New System.Drawing.Size(63, 13)
        Label10.TabIndex = 10
        Label10.Text = "Sello IRAM:"
        '
        'frmBajas
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(462, 365)
        Me.Controls.Add(Me.gbManga)
        Me.Controls.Add(Label5)
        Me.Controls.Add(Label4)
        Me.Controls.Add(Label3)
        Me.Controls.Add(Me.txtEquipo)
        Me.Controls.Add(Me.txtCilindro)
        Me.Controls.Add(Me.txtSerie)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Label2)
        Me.Controls.Add(Label1)
        Me.Controls.Add(Me.txtObs)
        Me.Controls.Add(Me.lstMotivos)
        Me.Name = "frmBajas"
        Me.Text = "Motivos de baja"
        Me.gbManga.ResumeLayout(False)
        Me.gbManga.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lstMotivos As System.Windows.Forms.ListBox
    Friend WithEvents txtObs As System.Windows.Forms.TextBox
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents txtSerie As System.Windows.Forms.TextBox
    Friend WithEvents txtCilindro As System.Windows.Forms.TextBox
    Friend WithEvents txtEquipo As System.Windows.Forms.TextBox
    Friend WithEvents gbManga As System.Windows.Forms.GroupBox
    Friend WithEvents cboTipo As System.Windows.Forms.ComboBox
    Friend WithEvents txtReal As System.Windows.Forms.TextBox
    Friend WithEvents cboDiametro As System.Windows.Forms.ComboBox
    Friend WithEvents cboSello As System.Windows.Forms.ComboBox
    Friend WithEvents cboLongitud As System.Windows.Forms.ComboBox
End Class
