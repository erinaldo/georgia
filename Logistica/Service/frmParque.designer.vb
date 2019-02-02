<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmParque
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
        Dim Label3 As System.Windows.Forms.Label
        Dim Label4 As System.Windows.Forms.Label
        Dim Label5 As System.Windows.Forms.Label
        Dim Label6 As System.Windows.Forms.Label
        Dim Label7 As System.Windows.Forms.Label
        Dim Label8 As System.Windows.Forms.Label
        Me.btnAceptar = New System.Windows.Forms.Button
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.txtCilindro = New System.Windows.Forms.TextBox
        Me.lstTipo = New System.Windows.Forms.ListBox
        Me.nudFab = New System.Windows.Forms.NumericUpDown
        Me.NudMesPh = New System.Windows.Forms.NumericUpDown
        Me.nudAnoPh = New System.Windows.Forms.NumericUpDown
        Me.dtpVto = New System.Windows.Forms.DateTimePicker
        Me.lblSerie = New System.Windows.Forms.Label
        Me.lstCapacidad = New System.Windows.Forms.ListBox
        Me.lstArticulos = New System.Windows.Forms.ListBox
        Label1 = New System.Windows.Forms.Label
        Label3 = New System.Windows.Forms.Label
        Label4 = New System.Windows.Forms.Label
        Label5 = New System.Windows.Forms.Label
        Label6 = New System.Windows.Forms.Label
        Label7 = New System.Windows.Forms.Label
        Label8 = New System.Windows.Forms.Label
        CType(Me.nudFab, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudMesPh, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudAnoPh, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(12, 3)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(31, 13)
        Label1.TabIndex = 0
        Label1.Text = "Tipo:"
        '
        'Label3
        '
        Label3.AutoSize = True
        Label3.Location = New System.Drawing.Point(20, 245)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(44, 13)
        Label3.TabIndex = 7
        Label3.Text = "Cilindro:"
        '
        'Label4
        '
        Label4.AutoSize = True
        Label4.Location = New System.Drawing.Point(20, 275)
        Label4.Name = "Label4"
        Label4.Size = New System.Drawing.Size(65, 13)
        Label4.TabIndex = 9
        Label4.Text = "Fabricación:"
        '
        'Label5
        '
        Label5.AutoSize = True
        Label5.Location = New System.Drawing.Point(209, 277)
        Label5.Name = "Label5"
        Label5.Size = New System.Drawing.Size(66, 13)
        Label5.TabIndex = 13
        Label5.Text = "PH Extintor::"
        '
        'Label6
        '
        Label6.AutoSize = True
        Label6.Location = New System.Drawing.Point(209, 249)
        Label6.Name = "Label6"
        Label6.Size = New System.Drawing.Size(68, 13)
        Label6.TabIndex = 11
        Label6.Text = "Vencimiento:"
        '
        'Label7
        '
        Label7.AutoSize = True
        Label7.Location = New System.Drawing.Point(202, 3)
        Label7.Name = "Label7"
        Label7.Size = New System.Drawing.Size(61, 13)
        Label7.TabIndex = 2
        Label7.Text = "Capacidad:"
        '
        'Label8
        '
        Label8.AutoSize = True
        Label8.Location = New System.Drawing.Point(323, 3)
        Label8.Name = "Label8"
        Label8.Size = New System.Drawing.Size(52, 13)
        Label8.TabIndex = 4
        Label8.Text = "Artículos:"
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.Location = New System.Drawing.Point(428, 275)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 16
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Location = New System.Drawing.Point(509, 275)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 17
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'txtCilindro
        '
        Me.txtCilindro.Location = New System.Drawing.Point(104, 242)
        Me.txtCilindro.Name = "txtCilindro"
        Me.txtCilindro.Size = New System.Drawing.Size(92, 20)
        Me.txtCilindro.TabIndex = 8
        '
        'lstTipo
        '
        Me.lstTipo.FormattingEnabled = True
        Me.lstTipo.Location = New System.Drawing.Point(12, 19)
        Me.lstTipo.Name = "lstTipo"
        Me.lstTipo.Size = New System.Drawing.Size(184, 173)
        Me.lstTipo.TabIndex = 1
        '
        'nudFab
        '
        Me.nudFab.Location = New System.Drawing.Point(104, 273)
        Me.nudFab.Maximum = New Decimal(New Integer() {1599, 0, 0, 0})
        Me.nudFab.Minimum = New Decimal(New Integer() {1599, 0, 0, 0})
        Me.nudFab.Name = "nudFab"
        Me.nudFab.Size = New System.Drawing.Size(92, 20)
        Me.nudFab.TabIndex = 10
        Me.nudFab.Value = New Decimal(New Integer() {1599, 0, 0, 0})
        '
        'NudMesPh
        '
        Me.NudMesPh.Location = New System.Drawing.Point(293, 275)
        Me.NudMesPh.Maximum = New Decimal(New Integer() {12, 0, 0, 0})
        Me.NudMesPh.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudMesPh.Name = "NudMesPh"
        Me.NudMesPh.Size = New System.Drawing.Size(38, 20)
        Me.NudMesPh.TabIndex = 14
        Me.NudMesPh.Value = New Decimal(New Integer() {12, 0, 0, 0})
        '
        'nudAnoPh
        '
        Me.nudAnoPh.Location = New System.Drawing.Point(337, 275)
        Me.nudAnoPh.Maximum = New Decimal(New Integer() {1599, 0, 0, 0})
        Me.nudAnoPh.Minimum = New Decimal(New Integer() {1599, 0, 0, 0})
        Me.nudAnoPh.Name = "nudAnoPh"
        Me.nudAnoPh.Size = New System.Drawing.Size(48, 20)
        Me.nudAnoPh.TabIndex = 15
        Me.nudAnoPh.Value = New Decimal(New Integer() {1599, 0, 0, 0})
        '
        'dtpVto
        '
        Me.dtpVto.CustomFormat = "MM/yyyy"
        Me.dtpVto.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpVto.Location = New System.Drawing.Point(293, 245)
        Me.dtpVto.Name = "dtpVto"
        Me.dtpVto.Size = New System.Drawing.Size(92, 20)
        Me.dtpVto.TabIndex = 12
        '
        'lblSerie
        '
        Me.lblSerie.AutoSize = True
        Me.lblSerie.Location = New System.Drawing.Point(20, 211)
        Me.lblSerie.Name = "lblSerie"
        Me.lblSerie.Size = New System.Drawing.Size(37, 13)
        Me.lblSerie.TabIndex = 6
        Me.lblSerie.Text = "Serie: "
        '
        'lstCapacidad
        '
        Me.lstCapacidad.FormattingEnabled = True
        Me.lstCapacidad.Location = New System.Drawing.Point(202, 19)
        Me.lstCapacidad.Name = "lstCapacidad"
        Me.lstCapacidad.Size = New System.Drawing.Size(118, 173)
        Me.lstCapacidad.TabIndex = 3
        '
        'lstArticulos
        '
        Me.lstArticulos.FormattingEnabled = True
        Me.lstArticulos.Location = New System.Drawing.Point(326, 19)
        Me.lstArticulos.Name = "lstArticulos"
        Me.lstArticulos.Size = New System.Drawing.Size(258, 173)
        Me.lstArticulos.TabIndex = 5
        '
        'frmParque
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(596, 311)
        Me.ControlBox = False
        Me.Controls.Add(Label8)
        Me.Controls.Add(Me.lstArticulos)
        Me.Controls.Add(Me.lstCapacidad)
        Me.Controls.Add(Label7)
        Me.Controls.Add(Me.lblSerie)
        Me.Controls.Add(Label6)
        Me.Controls.Add(Me.dtpVto)
        Me.Controls.Add(Me.nudAnoPh)
        Me.Controls.Add(Me.NudMesPh)
        Me.Controls.Add(Me.nudFab)
        Me.Controls.Add(Me.lstTipo)
        Me.Controls.Add(Label5)
        Me.Controls.Add(Label4)
        Me.Controls.Add(Label3)
        Me.Controls.Add(Label1)
        Me.Controls.Add(Me.txtCilindro)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmParque"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Alta de parque"
        CType(Me.nudFab, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudMesPh, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudAnoPh, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents txtCilindro As System.Windows.Forms.TextBox
    Friend WithEvents lstTipo As System.Windows.Forms.ListBox
    Friend WithEvents nudFab As System.Windows.Forms.NumericUpDown
    Friend WithEvents NudMesPh As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudAnoPh As System.Windows.Forms.NumericUpDown
    Friend WithEvents dtpVto As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblSerie As System.Windows.Forms.Label
    Friend WithEvents lstCapacidad As System.Windows.Forms.ListBox
    Friend WithEvents lstArticulos As System.Windows.Forms.ListBox
End Class
