<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelectorRuta
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.btnAbiertas = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.lstAcompa = New System.Windows.Forms.ListBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.lstChofer = New System.Windows.Forms.ListBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lstTransporte = New System.Windows.Forms.ListBox
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.mtbRuta = New System.Windows.Forms.MaskedTextBox
        Me.dgvResultados = New System.Windows.Forms.DataGridView
        Me.colRuta = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colFecha = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colTransporte = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colChofer = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colAcompa1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colAcompa2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvResultados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnAbiertas
        '
        Me.btnAbiertas.Location = New System.Drawing.Point(807, 422)
        Me.btnAbiertas.Name = "btnAbiertas"
        Me.btnAbiertas.Size = New System.Drawing.Size(91, 23)
        Me.btnAbiertas.TabIndex = 8
        Me.btnAbiertas.Text = "Rutas Abiertas"
        Me.btnAbiertas.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lstAcompa)
        Me.GroupBox3.Location = New System.Drawing.Point(9, 63)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(317, 128)
        Me.GroupBox3.TabIndex = 5
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Busqueda por Acompañante"
        '
        'lstAcompa
        '
        Me.lstAcompa.FormattingEnabled = True
        Me.lstAcompa.Location = New System.Drawing.Point(6, 19)
        Me.lstAcompa.Name = "lstAcompa"
        Me.lstAcompa.Size = New System.Drawing.Size(305, 95)
        Me.lstAcompa.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lstChofer)
        Me.GroupBox2.Location = New System.Drawing.Point(9, 331)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(317, 128)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Busqueda por Chofer"
        '
        'lstChofer
        '
        Me.lstChofer.FormattingEnabled = True
        Me.lstChofer.Location = New System.Drawing.Point(6, 19)
        Me.lstChofer.Name = "lstChofer"
        Me.lstChofer.Size = New System.Drawing.Size(302, 95)
        Me.lstChofer.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lstTransporte)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 197)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(317, 128)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Busqueda por Transporte"
        '
        'lstTransporte
        '
        Me.lstTransporte.FormattingEnabled = True
        Me.lstTransporte.Location = New System.Drawing.Point(6, 19)
        Me.lstTransporte.Name = "lstTransporte"
        Me.lstTransporte.Size = New System.Drawing.Size(305, 95)
        Me.lstTransporte.TabIndex = 0
        '
        'dtpFecha
        '
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(220, 19)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(100, 20)
        Me.dtpFecha.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(174, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Fecha:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Ir a Ruta:"
        '
        'mtbRuta
        '
        Me.mtbRuta.HidePromptOnLeave = True
        Me.mtbRuta.Location = New System.Drawing.Point(69, 19)
        Me.mtbRuta.Mask = "999999999"
        Me.mtbRuta.Name = "mtbRuta"
        Me.mtbRuta.Size = New System.Drawing.Size(100, 20)
        Me.mtbRuta.TabIndex = 1
        Me.mtbRuta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dgvResultados
        '
        Me.dgvResultados.AllowUserToAddRows = False
        Me.dgvResultados.AllowUserToDeleteRows = False
        Me.dgvResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvResultados.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colRuta, Me.colFecha, Me.colTransporte, Me.colChofer, Me.colAcompa1, Me.colAcompa2})
        Me.dgvResultados.Location = New System.Drawing.Point(332, 12)
        Me.dgvResultados.MultiSelect = False
        Me.dgvResultados.Name = "dgvResultados"
        Me.dgvResultados.ReadOnly = True
        Me.dgvResultados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvResultados.Size = New System.Drawing.Size(574, 396)
        Me.dgvResultados.TabIndex = 4
        '
        'colRuta
        '
        Me.colRuta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colRuta.DefaultCellStyle = DataGridViewCellStyle1
        Me.colRuta.HeaderText = "Ruta"
        Me.colRuta.Name = "colRuta"
        Me.colRuta.ReadOnly = True
        Me.colRuta.Width = 55
        '
        'colFecha
        '
        Me.colFecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colFecha.HeaderText = "Fecha"
        Me.colFecha.Name = "colFecha"
        Me.colFecha.ReadOnly = True
        Me.colFecha.Width = 62
        '
        'colTransporte
        '
        Me.colTransporte.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colTransporte.HeaderText = "Transporte"
        Me.colTransporte.Name = "colTransporte"
        Me.colTransporte.ReadOnly = True
        Me.colTransporte.Width = 83
        '
        'colChofer
        '
        Me.colChofer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colChofer.HeaderText = "Chofer"
        Me.colChofer.Name = "colChofer"
        Me.colChofer.ReadOnly = True
        Me.colChofer.Width = 63
        '
        'colAcompa1
        '
        Me.colAcompa1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colAcompa1.HeaderText = "Acompañante 1"
        Me.colAcompa1.Name = "colAcompa1"
        Me.colAcompa1.ReadOnly = True
        Me.colAcompa1.Width = 98
        '
        'colAcompa2
        '
        Me.colAcompa2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colAcompa2.HeaderText = "Acompañante 2"
        Me.colAcompa2.Name = "colAcompa2"
        Me.colAcompa2.ReadOnly = True
        Me.colAcompa2.Width = 98
        '
        'frmSelectorRuta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(910, 464)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.dgvResultados)
        Me.Controls.Add(Me.btnAbiertas)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.mtbRuta)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dtpFecha)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSelectorRuta"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Selector de Ruta"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgvResultados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvResultados As System.Windows.Forms.DataGridView
    Friend WithEvents mtbRuta As System.Windows.Forms.MaskedTextBox
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lstChofer As System.Windows.Forms.ListBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lstTransporte As System.Windows.Forms.ListBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lstAcompa As System.Windows.Forms.ListBox
    Friend WithEvents btnAbiertas As System.Windows.Forms.Button
    Friend WithEvents colRuta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTransporte As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colChofer As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAcompa1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAcompa2 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
