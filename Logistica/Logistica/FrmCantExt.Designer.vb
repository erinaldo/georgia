<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCantExt
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.dgvPrincipalLogistica = New System.Windows.Forms.DataGridView
        Me.BtnCalcular = New System.Windows.Forms.Button
        Me.dtp = New System.Windows.Forms.DateTimePicker
        Me.dgvAdicionalLogistica = New System.Windows.Forms.DataGridView
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.dgvAdicionalAbonos = New System.Windows.Forms.DataGridView
        Me.dgvPrincipalAbonos = New System.Windows.Forms.DataGridView
        Me.Label3 = New System.Windows.Forms.Label
        Me.dgvAdicionalVarios = New System.Windows.Forms.DataGridView
        Me.dgvPrincipalVarios = New System.Windows.Forms.DataGridView
        Me.AcumuladoLogistica = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.AcumuladoAbonos = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.SumaAbonos = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.SumaLogistica = New System.Windows.Forms.TextBox
        Me.cmbox = New System.Windows.Forms.ComboBox
        CType(Me.dgvPrincipalLogistica, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvAdicionalLogistica, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvAdicionalAbonos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvPrincipalAbonos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvAdicionalVarios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvPrincipalVarios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvPrincipalLogistica
        '
        Me.dgvPrincipalLogistica.AllowUserToAddRows = False
        Me.dgvPrincipalLogistica.AllowUserToDeleteRows = False
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPrincipalLogistica.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvPrincipalLogistica.Location = New System.Drawing.Point(12, 81)
        Me.dgvPrincipalLogistica.Name = "dgvPrincipalLogistica"
        Me.dgvPrincipalLogistica.ReadOnly = True
        Me.dgvPrincipalLogistica.RowHeadersVisible = False
        Me.dgvPrincipalLogistica.Size = New System.Drawing.Size(327, 150)
        Me.dgvPrincipalLogistica.TabIndex = 0
        '
        'BtnCalcular
        '
        Me.BtnCalcular.Location = New System.Drawing.Point(137, 11)
        Me.BtnCalcular.Name = "BtnCalcular"
        Me.BtnCalcular.Size = New System.Drawing.Size(75, 19)
        Me.BtnCalcular.TabIndex = 1
        Me.BtnCalcular.Text = "Calcular"
        Me.BtnCalcular.UseVisualStyleBackColor = True
        '
        'dtp
        '
        Me.dtp.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp.Location = New System.Drawing.Point(28, 10)
        Me.dtp.Name = "dtp"
        Me.dtp.Size = New System.Drawing.Size(103, 20)
        Me.dtp.TabIndex = 2
        '
        'dgvAdicionalLogistica
        '
        Me.dgvAdicionalLogistica.AllowUserToAddRows = False
        Me.dgvAdicionalLogistica.AllowUserToDeleteRows = False
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvAdicionalLogistica.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dgvAdicionalLogistica.Location = New System.Drawing.Point(71, 237)
        Me.dgvAdicionalLogistica.Name = "dgvAdicionalLogistica"
        Me.dgvAdicionalLogistica.ReadOnly = True
        Me.dgvAdicionalLogistica.RowHeadersVisible = False
        Me.dgvAdicionalLogistica.Size = New System.Drawing.Size(222, 150)
        Me.dgvAdicionalLogistica.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(127, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Logisitica"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(494, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Abonos"
        '
        'dgvAdicionalAbonos
        '
        Me.dgvAdicionalAbonos.AllowUserToAddRows = False
        Me.dgvAdicionalAbonos.AllowUserToDeleteRows = False
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvAdicionalAbonos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgvAdicionalAbonos.Location = New System.Drawing.Point(398, 237)
        Me.dgvAdicionalAbonos.Name = "dgvAdicionalAbonos"
        Me.dgvAdicionalAbonos.ReadOnly = True
        Me.dgvAdicionalAbonos.RowHeadersVisible = False
        Me.dgvAdicionalAbonos.Size = New System.Drawing.Size(222, 150)
        Me.dgvAdicionalAbonos.TabIndex = 6
        '
        'dgvPrincipalAbonos
        '
        Me.dgvPrincipalAbonos.AllowUserToAddRows = False
        Me.dgvPrincipalAbonos.AllowUserToDeleteRows = False
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPrincipalAbonos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.dgvPrincipalAbonos.Location = New System.Drawing.Point(345, 81)
        Me.dgvPrincipalAbonos.Name = "dgvPrincipalAbonos"
        Me.dgvPrincipalAbonos.ReadOnly = True
        Me.dgvPrincipalAbonos.RowHeadersVisible = False
        Me.dgvPrincipalAbonos.Size = New System.Drawing.Size(327, 150)
        Me.dgvPrincipalAbonos.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(857, 65)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 13)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Sin Clasificar"
        '
        'dgvAdicionalVarios
        '
        Me.dgvAdicionalVarios.AllowUserToAddRows = False
        Me.dgvAdicionalVarios.AllowUserToDeleteRows = False
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvAdicionalVarios.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.dgvAdicionalVarios.Location = New System.Drawing.Point(770, 237)
        Me.dgvAdicionalVarios.Name = "dgvAdicionalVarios"
        Me.dgvAdicionalVarios.ReadOnly = True
        Me.dgvAdicionalVarios.RowHeadersVisible = False
        Me.dgvAdicionalVarios.Size = New System.Drawing.Size(222, 150)
        Me.dgvAdicionalVarios.TabIndex = 12
        '
        'dgvPrincipalVarios
        '
        Me.dgvPrincipalVarios.AllowUserToAddRows = False
        Me.dgvPrincipalVarios.AllowUserToDeleteRows = False
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPrincipalVarios.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.dgvPrincipalVarios.Location = New System.Drawing.Point(707, 81)
        Me.dgvPrincipalVarios.Name = "dgvPrincipalVarios"
        Me.dgvPrincipalVarios.ReadOnly = True
        Me.dgvPrincipalVarios.RowHeadersVisible = False
        Me.dgvPrincipalVarios.Size = New System.Drawing.Size(327, 150)
        Me.dgvPrincipalVarios.TabIndex = 11
        '
        'AcumuladoLogistica
        '
        Me.AcumuladoLogistica.Location = New System.Drawing.Point(186, 393)
        Me.AcumuladoLogistica.Name = "AcumuladoLogistica"
        Me.AcumuladoLogistica.Size = New System.Drawing.Size(100, 20)
        Me.AcumuladoLogistica.TabIndex = 14
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(118, 396)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 13)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Acumulado"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(429, 396)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 13)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Acumulado"
        '
        'AcumuladoAbonos
        '
        Me.AcumuladoAbonos.Location = New System.Drawing.Point(497, 393)
        Me.AcumuladoAbonos.Name = "AcumuladoAbonos"
        Me.AcumuladoAbonos.Size = New System.Drawing.Size(100, 20)
        Me.AcumuladoAbonos.TabIndex = 16
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(429, 422)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 13)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = "Suma Dia"
        '
        'SumaAbonos
        '
        Me.SumaAbonos.Location = New System.Drawing.Point(497, 419)
        Me.SumaAbonos.Name = "SumaAbonos"
        Me.SumaAbonos.Size = New System.Drawing.Size(100, 20)
        Me.SumaAbonos.TabIndex = 20
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(118, 422)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 13)
        Me.Label7.TabIndex = 19
        Me.Label7.Text = "Suma Dia"
        '
        'SumaLogistica
        '
        Me.SumaLogistica.Location = New System.Drawing.Point(186, 419)
        Me.SumaLogistica.Name = "SumaLogistica"
        Me.SumaLogistica.Size = New System.Drawing.Size(100, 20)
        Me.SumaLogistica.TabIndex = 18
        '
        'cmbox
        '
        Me.cmbox.FormattingEnabled = True
        Me.cmbox.Items.AddRange(New Object() {"RET", "ENT"})
        Me.cmbox.Location = New System.Drawing.Point(218, 9)
        Me.cmbox.Name = "cmbox"
        Me.cmbox.Size = New System.Drawing.Size(121, 21)
        Me.cmbox.TabIndex = 22
        '
        'FrmCantExt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1042, 460)
        Me.Controls.Add(Me.cmbox)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.SumaAbonos)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.SumaLogistica)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.AcumuladoAbonos)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.AcumuladoLogistica)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dgvAdicionalVarios)
        Me.Controls.Add(Me.dgvPrincipalVarios)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dgvAdicionalAbonos)
        Me.Controls.Add(Me.dgvPrincipalAbonos)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgvAdicionalLogistica)
        Me.Controls.Add(Me.dtp)
        Me.Controls.Add(Me.BtnCalcular)
        Me.Controls.Add(Me.dgvPrincipalLogistica)
        Me.Name = "FrmCantExt"
        Me.Text = "FrmCantExt"
        CType(Me.dgvPrincipalLogistica, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvAdicionalLogistica, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvAdicionalAbonos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvPrincipalAbonos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvAdicionalVarios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvPrincipalVarios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvPrincipalLogistica As System.Windows.Forms.DataGridView
    Friend WithEvents BtnCalcular As System.Windows.Forms.Button
    Friend WithEvents dtp As System.Windows.Forms.DateTimePicker
    Friend WithEvents dgvAdicionalLogistica As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dgvAdicionalAbonos As System.Windows.Forms.DataGridView
    Friend WithEvents dgvPrincipalAbonos As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dgvAdicionalVarios As System.Windows.Forms.DataGridView
    Friend WithEvents dgvPrincipalVarios As System.Windows.Forms.DataGridView
    Friend WithEvents AcumuladoLogistica As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents AcumuladoAbonos As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents SumaAbonos As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents SumaLogistica As System.Windows.Forms.TextBox
    Friend WithEvents cmbox As System.Windows.Forms.ComboBox
End Class
