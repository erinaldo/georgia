<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRetenciones
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnImportar = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btnExportar = New System.Windows.Forms.Button
        Me.dtp = New System.Windows.Forms.DateTimePicker
        Me.ofd = New System.Windows.Forms.OpenFileDialog
        Me.sfd = New System.Windows.Forms.SaveFileDialog
        Me.dgv = New System.Windows.Forms.DataGridView
        Me.colFechaRet = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCuit = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCertif = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colImporte = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colFechaIng = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnBuscar = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.btnImportar)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(697, 67)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Importar Retenciones"
        '
        'btnImportar
        '
        Me.btnImportar.Location = New System.Drawing.Point(57, 29)
        Me.btnImportar.Name = "btnImportar"
        Me.btnImportar.Size = New System.Drawing.Size(75, 23)
        Me.btnImportar.TabIndex = 3
        Me.btnImportar.Text = "Importar..."
        Me.btnImportar.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.btnBuscar)
        Me.GroupBox2.Controls.Add(Me.dgv)
        Me.GroupBox2.Controls.Add(Me.btnExportar)
        Me.GroupBox2.Controls.Add(Me.dtp)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 108)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(697, 292)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Exportar Retenciones"
        '
        'btnExportar
        '
        Me.btnExportar.Location = New System.Drawing.Point(607, 24)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(75, 23)
        Me.btnExportar.TabIndex = 2
        Me.btnExportar.Text = "Exportar..."
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'dtp
        '
        Me.dtp.CustomFormat = "MMM/yyyy"
        Me.dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp.Location = New System.Drawing.Point(6, 27)
        Me.dtp.Name = "dtp"
        Me.dtp.Size = New System.Drawing.Size(100, 20)
        Me.dtp.TabIndex = 0
        '
        'ofd
        '
        Me.ofd.Filter = "Archivos de Texto|*.txt|Todos los archivos|*.*"
        Me.ofd.Title = "Importar Archivo"
        '
        'sfd
        '
        Me.sfd.Filter = "Archivos de Texto|*.txt|Todos los archivos|*.*"
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToDeleteRows = False
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colFechaRet, Me.colCuit, Me.colCertif, Me.colImporte, Me.colFechaIng})
        Me.dgv.Location = New System.Drawing.Point(6, 56)
        Me.dgv.Name = "dgv"
        Me.dgv.ReadOnly = True
        Me.dgv.Size = New System.Drawing.Size(685, 227)
        Me.dgv.TabIndex = 3
        '
        'colFechaRet
        '
        Me.colFechaRet.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colFechaRet.HeaderText = "Fecha Ret"
        Me.colFechaRet.Name = "colFechaRet"
        Me.colFechaRet.Width = 82
        '
        'colCuit
        '
        Me.colCuit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colCuit.HeaderText = "CUIT"
        Me.colCuit.Name = "colCuit"
        Me.colCuit.Width = 57
        '
        'colCertif
        '
        Me.colCertif.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colCertif.HeaderText = "Certificado"
        Me.colCertif.Name = "colCertif"
        Me.colCertif.Width = 82
        '
        'colImporte
        '
        Me.colImporte.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N2"
        Me.colImporte.DefaultCellStyle = DataGridViewCellStyle3
        Me.colImporte.HeaderText = "Importe"
        Me.colImporte.Name = "colImporte"
        Me.colImporte.ReadOnly = True
        Me.colImporte.Width = 67
        '
        'colFechaIng
        '
        Me.colFechaIng.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colFechaIng.HeaderText = "Fecha Ing"
        Me.colFechaIng.Name = "colFechaIng"
        Me.colFechaIng.Width = 80
        '
        'btnBuscar
        '
        Me.btnBuscar.Location = New System.Drawing.Point(112, 24)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(75, 23)
        Me.btnBuscar.TabIndex = 4
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'frmRetenciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(721, 412)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmRetenciones"
        Me.Text = "Retenciones"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnImportar As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnExportar As System.Windows.Forms.Button
    Friend WithEvents dtp As System.Windows.Forms.DateTimePicker
    Friend WithEvents ofd As System.Windows.Forms.OpenFileDialog
    Friend WithEvents sfd As System.Windows.Forms.SaveFileDialog
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents colFechaRet As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCuit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCertif As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colImporte As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFechaIng As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
End Class
