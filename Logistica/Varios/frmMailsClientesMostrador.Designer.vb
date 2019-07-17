<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMailsClientesMostrador
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
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.btnBuscar = New System.Windows.Forms.Button
        Me.mCal = New System.Windows.Forms.MonthCalendar
        Me.btnTest = New System.Windows.Forms.Button
        Me.btnEnviar = New System.Windows.Forms.Button
        Me.dgv = New System.Windows.Forms.DataGridView
        Me.colFecha = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCliente = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colNombre = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colMail = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colImporte = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnBuscar)
        Me.SplitContainer1.Panel1.Controls.Add(Me.mCal)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnTest)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnEnviar)
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgv)
        Me.SplitContainer1.Size = New System.Drawing.Size(814, 364)
        Me.SplitContainer1.SplitterDistance = 251
        Me.SplitContainer1.TabIndex = 0
        '
        'btnBuscar
        '
        Me.btnBuscar.Location = New System.Drawing.Point(81, 183)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(75, 23)
        Me.btnBuscar.TabIndex = 1
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'mCal
        '
        Me.mCal.Location = New System.Drawing.Point(9, 9)
        Me.mCal.Name = "mCal"
        Me.mCal.TabIndex = 0
        '
        'btnTest
        '
        Me.btnTest.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTest.Location = New System.Drawing.Point(472, 329)
        Me.btnTest.Name = "btnTest"
        Me.btnTest.Size = New System.Drawing.Size(75, 23)
        Me.btnTest.TabIndex = 3
        Me.btnTest.Text = "Test"
        Me.btnTest.UseVisualStyleBackColor = True
        '
        'btnEnviar
        '
        Me.btnEnviar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEnviar.Location = New System.Drawing.Point(391, 329)
        Me.btnEnviar.Name = "btnEnviar"
        Me.btnEnviar.Size = New System.Drawing.Size(75, 23)
        Me.btnEnviar.TabIndex = 2
        Me.btnEnviar.Text = "Enviar"
        Me.btnEnviar.UseVisualStyleBackColor = True
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToDeleteRows = False
        Me.dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colFecha, Me.colComprobante, Me.colCliente, Me.colNombre, Me.colMail, Me.colImporte})
        Me.dgv.Location = New System.Drawing.Point(3, 3)
        Me.dgv.Name = "dgv"
        Me.dgv.ReadOnly = True
        Me.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv.Size = New System.Drawing.Size(553, 319)
        Me.dgv.TabIndex = 0
        '
        'colFecha
        '
        Me.colFecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colFecha.HeaderText = "Fecha"
        Me.colFecha.Name = "colFecha"
        Me.colFecha.ReadOnly = True
        Me.colFecha.Width = 62
        '
        'colComprobante
        '
        Me.colComprobante.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colComprobante.HeaderText = "Comprobante"
        Me.colComprobante.Name = "colComprobante"
        Me.colComprobante.ReadOnly = True
        Me.colComprobante.Width = 95
        '
        'colCliente
        '
        Me.colCliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colCliente.HeaderText = "Cliente"
        Me.colCliente.Name = "colCliente"
        Me.colCliente.ReadOnly = True
        Me.colCliente.Width = 64
        '
        'colNombre
        '
        Me.colNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colNombre.HeaderText = "Nombre"
        Me.colNombre.Name = "colNombre"
        Me.colNombre.ReadOnly = True
        Me.colNombre.Width = 69
        '
        'colMail
        '
        Me.colMail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colMail.HeaderText = "Mail"
        Me.colMail.Name = "colMail"
        Me.colMail.ReadOnly = True
        Me.colMail.Width = 51
        '
        'colImporte
        '
        Me.colImporte.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Format = "N2"
        Me.colImporte.DefaultCellStyle = DataGridViewCellStyle1
        Me.colImporte.HeaderText = "Importe"
        Me.colImporte.Name = "colImporte"
        Me.colImporte.ReadOnly = True
        Me.colImporte.Width = 67
        '
        'frmMailsClientesMostrador
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(814, 364)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "frmMailsClientesMostrador"
        Me.Text = "Mails Clientes Mostrador"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents mCal As System.Windows.Forms.MonthCalendar
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents btnTest As System.Windows.Forms.Button
    Friend WithEvents btnEnviar As System.Windows.Forms.Button
    Friend WithEvents colFecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colComprobante As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMail As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colImporte As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
