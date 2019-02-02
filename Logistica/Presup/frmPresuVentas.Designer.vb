<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPresuVentas
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
        Me.Calendar = New System.Windows.Forms.MonthCalendar
        Me.dgv = New System.Windows.Forms.DataGridView
        Me.colCc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colRa = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colPa = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colRp = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colPv = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnGenerar = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.chkFormosa = New System.Windows.Forms.CheckBox
        Me.lblBuscando = New System.Windows.Forms.Label
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Calendar
        '
        Me.Calendar.Location = New System.Drawing.Point(9, 9)
        Me.Calendar.MaxSelectionCount = 31
        Me.Calendar.Name = "Calendar"
        Me.Calendar.TabIndex = 0
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToDeleteRows = False
        Me.dgv.AllowUserToResizeColumns = False
        Me.dgv.AllowUserToResizeRows = False
        Me.dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colCc, Me.colRa, Me.colPa, Me.colRp, Me.colPv})
        Me.dgv.Location = New System.Drawing.Point(265, 6)
        Me.dgv.Name = "dgv"
        Me.dgv.ReadOnly = True
        Me.dgv.Size = New System.Drawing.Size(818, 486)
        Me.dgv.TabIndex = 10
        '
        'colCc
        '
        Me.colCc.HeaderText = "Centro Costo"
        Me.colCc.Name = "colCc"
        Me.colCc.ReadOnly = True
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
        'colRp
        '
        Me.colRp.HeaderText = "Real Vs Presup"
        Me.colRp.Name = "colRp"
        Me.colRp.ReadOnly = True
        '
        'colPv
        '
        Me.colPv.HeaderText = "Variacion (%)"
        Me.colPv.Name = "colPv"
        Me.colPv.ReadOnly = True
        '
        'btnGenerar
        '
        Me.btnGenerar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnGenerar.Location = New System.Drawing.Point(9, 196)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(226, 33)
        Me.btnGenerar.TabIndex = 6
        Me.btnGenerar.Text = "Generar"
        Me.btnGenerar.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.chkFormosa)
        Me.Panel1.Controls.Add(Me.Calendar)
        Me.Panel1.Controls.Add(Me.btnGenerar)
        Me.Panel1.Location = New System.Drawing.Point(12, 6)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(247, 494)
        Me.Panel1.TabIndex = 11
        '
        'chkFormosa
        '
        Me.chkFormosa.AutoSize = True
        Me.chkFormosa.Location = New System.Drawing.Point(10, 173)
        Me.chkFormosa.Name = "chkFormosa"
        Me.chkFormosa.Size = New System.Drawing.Size(90, 17)
        Me.chkFormosa.TabIndex = 7
        Me.chkFormosa.Text = "Solo Formosa"
        Me.chkFormosa.UseVisualStyleBackColor = True
        '
        'lblBuscando
        '
        Me.lblBuscando.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBuscando.Location = New System.Drawing.Point(401, 223)
        Me.lblBuscando.Name = "lblBuscando"
        Me.lblBuscando.Size = New System.Drawing.Size(292, 59)
        Me.lblBuscando.TabIndex = 29
        Me.lblBuscando.Text = "Por favor, espere..."
        Me.lblBuscando.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblBuscando.Visible = False
        '
        'frmPresuVentas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1095, 504)
        Me.Controls.Add(Me.lblBuscando)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.dgv)
        Me.Name = "frmPresuVentas"
        Me.Text = "Total de Centro de costos"
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Calendar As System.Windows.Forms.MonthCalendar
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents btnGenerar As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents colCc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRa As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPa As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblBuscando As System.Windows.Forms.Label
    Friend WithEvents chkFormosa As System.Windows.Forms.CheckBox
End Class
