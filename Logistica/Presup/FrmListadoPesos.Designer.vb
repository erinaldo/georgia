<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListadoPesos
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
        Me.dtp = New System.Windows.Forms.DateTimePicker
        Me.dgv = New System.Windows.Forms.DataGridView
        Me.colAcc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colDes = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colRa = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colPa = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colVra = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colPv = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colPr = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnGenerar = New System.Windows.Forms.Button
        Me.cboCce = New System.Windows.Forms.ComboBox
        Me.chkOcultar = New System.Windows.Forms.CheckBox
        Me.chkPorc = New System.Windows.Forms.CheckBox
        Me.lblBuscando = New System.Windows.Forms.Label
        Label1 = New System.Windows.Forms.Label
        Label2 = New System.Windows.Forms.Label
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtp
        '
        Me.dtp.CustomFormat = "MM/yyyy"
        Me.dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp.Location = New System.Drawing.Point(41, 6)
        Me.dtp.Name = "dtp"
        Me.dtp.Size = New System.Drawing.Size(69, 20)
        Me.dtp.TabIndex = 1
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(116, 9)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(88, 13)
        Label1.TabIndex = 2
        Label1.Text = "Centro de Costos"
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToDeleteRows = False
        Me.dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colAcc, Me.colDes, Me.colRa, Me.colPa, Me.colVra, Me.colPv, Me.colPr})
        Me.dgv.Location = New System.Drawing.Point(2, 33)
        Me.dgv.Name = "dgv"
        Me.dgv.ReadOnly = True
        Me.dgv.Size = New System.Drawing.Size(763, 408)
        Me.dgv.TabIndex = 3
        '
        'colAcc
        '
        Me.colAcc.HeaderText = "Código"
        Me.colAcc.Name = "colAcc"
        Me.colAcc.ReadOnly = True
        '
        'colDes
        '
        Me.colDes.HeaderText = "Cuenta"
        Me.colDes.Name = "colDes"
        Me.colDes.ReadOnly = True
        '
        'colRa
        '
        Me.colRa.HeaderText = "Real Acumulado"
        Me.colRa.Name = "colRa"
        Me.colRa.ReadOnly = True
        '
        'colPa
        '
        Me.colPa.HeaderText = "Presupuesto Acumulado"
        Me.colPa.Name = "colPa"
        Me.colPa.ReadOnly = True
        '
        'colVra
        '
        Me.colVra.HeaderText = "Real Vs Acumulado"
        Me.colVra.Name = "colVra"
        Me.colVra.ReadOnly = True
        '
        'colPv
        '
        Me.colPv.HeaderText = "Variación (%)"
        Me.colPv.Name = "colPv"
        Me.colPv.ReadOnly = True
        '
        'colPr
        '
        Me.colPr.HeaderText = "Presupuesto Restante"
        Me.colPr.Name = "colPr"
        Me.colPr.ReadOnly = True
        '
        'btnGenerar
        '
        Me.btnGenerar.Location = New System.Drawing.Point(337, 4)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(75, 23)
        Me.btnGenerar.TabIndex = 4
        Me.btnGenerar.Text = "Consultar"
        Me.btnGenerar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Location = New System.Drawing.Point(8, 9)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(27, 13)
        Label2.TabIndex = 5
        Label2.Text = "Mes"
        '
        'cboCce
        '
        Me.cboCce.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCce.FormattingEnabled = True
        Me.cboCce.Location = New System.Drawing.Point(210, 6)
        Me.cboCce.Name = "cboCce"
        Me.cboCce.Size = New System.Drawing.Size(121, 21)
        Me.cboCce.TabIndex = 7
        '
        'chkOcultar
        '
        Me.chkOcultar.AutoSize = True
        Me.chkOcultar.Checked = True
        Me.chkOcultar.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkOcultar.Location = New System.Drawing.Point(550, 8)
        Me.chkOcultar.Name = "chkOcultar"
        Me.chkOcultar.Size = New System.Drawing.Size(120, 17)
        Me.chkOcultar.TabIndex = 8
        Me.chkOcultar.Text = "Ocultar filas en cero"
        Me.chkOcultar.UseVisualStyleBackColor = True
        '
        'chkPorc
        '
        Me.chkPorc.AutoSize = True
        Me.chkPorc.Location = New System.Drawing.Point(435, 8)
        Me.chkPorc.Name = "chkPorc"
        Me.chkPorc.Size = New System.Drawing.Size(100, 17)
        Me.chkPorc.TabIndex = 9
        Me.chkPorc.Text = "Ver porcentajes"
        Me.chkPorc.UseVisualStyleBackColor = True
        '
        'lblBuscando
        '
        Me.lblBuscando.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBuscando.Location = New System.Drawing.Point(238, 192)
        Me.lblBuscando.Name = "lblBuscando"
        Me.lblBuscando.Size = New System.Drawing.Size(292, 59)
        Me.lblBuscando.TabIndex = 28
        Me.lblBuscando.Text = "Por favor, espere..."
        Me.lblBuscando.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblBuscando.Visible = False
        '
        'frmListadoPesos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(768, 443)
        Me.Controls.Add(Me.lblBuscando)
        Me.Controls.Add(Me.chkPorc)
        Me.Controls.Add(Me.chkOcultar)
        Me.Controls.Add(Me.cboCce)
        Me.Controls.Add(Label2)
        Me.Controls.Add(Me.btnGenerar)
        Me.Controls.Add(Me.dgv)
        Me.Controls.Add(Label1)
        Me.Controls.Add(Me.dtp)
        Me.Name = "frmListadoPesos"
        Me.Tag = ""
        Me.Text = "Detalle por Centro de Costo"
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtp As System.Windows.Forms.DateTimePicker
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents btnGenerar As System.Windows.Forms.Button
    Friend WithEvents cboCce As System.Windows.Forms.ComboBox
    Friend WithEvents colAcc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRa As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPa As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colVra As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chkOcultar As System.Windows.Forms.CheckBox
    Friend WithEvents chkPorc As System.Windows.Forms.CheckBox
    Friend WithEvents lblBuscando As System.Windows.Forms.Label
End Class
