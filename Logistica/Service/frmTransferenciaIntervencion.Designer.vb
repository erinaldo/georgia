<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTransferenciaIntervencion
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
        Me.btnAbrirOrigen = New System.Windows.Forms.Button
        Me.txtIntervencionOrigen = New System.Windows.Forms.TextBox
        Me.txtClienteOrigen = New System.Windows.Forms.TextBox
        Me.txtSucursalOrigen = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtClienteDestino = New System.Windows.Forms.TextBox
        Me.btnAbrirDestino = New System.Windows.Forms.Button
        Me.txtSucursalDestino = New System.Windows.Forms.TextBox
        Me.txtIntervencionDestino = New System.Windows.Forms.TextBox
        Me.dgv = New System.Windows.Forms.DataGridView
        Me.colSolicitud = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colIntervención = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colSerie = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnTransferir = New System.Windows.Forms.Button
        Label1 = New System.Windows.Forms.Label
        Label2 = New System.Windows.Forms.Label
        Label3 = New System.Windows.Forms.Label
        Label4 = New System.Windows.Forms.Label
        Label5 = New System.Windows.Forms.Label
        Label6 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnAbrirOrigen
        '
        Me.btnAbrirOrigen.Location = New System.Drawing.Point(187, 69)
        Me.btnAbrirOrigen.Name = "btnAbrirOrigen"
        Me.btnAbrirOrigen.Size = New System.Drawing.Size(75, 23)
        Me.btnAbrirOrigen.TabIndex = 0
        Me.btnAbrirOrigen.Text = "Abrir"
        Me.btnAbrirOrigen.UseVisualStyleBackColor = True
        '
        'txtIntervencionOrigen
        '
        Me.txtIntervencionOrigen.Location = New System.Drawing.Point(6, 43)
        Me.txtIntervencionOrigen.Name = "txtIntervencionOrigen"
        Me.txtIntervencionOrigen.ReadOnly = True
        Me.txtIntervencionOrigen.Size = New System.Drawing.Size(125, 20)
        Me.txtIntervencionOrigen.TabIndex = 1
        '
        'txtClienteOrigen
        '
        Me.txtClienteOrigen.Location = New System.Drawing.Point(137, 43)
        Me.txtClienteOrigen.Name = "txtClienteOrigen"
        Me.txtClienteOrigen.ReadOnly = True
        Me.txtClienteOrigen.Size = New System.Drawing.Size(55, 20)
        Me.txtClienteOrigen.TabIndex = 2
        '
        'txtSucursalOrigen
        '
        Me.txtSucursalOrigen.Location = New System.Drawing.Point(198, 43)
        Me.txtSucursalOrigen.Name = "txtSucursalOrigen"
        Me.txtSucursalOrigen.ReadOnly = True
        Me.txtSucursalOrigen.Size = New System.Drawing.Size(64, 20)
        Me.txtSucursalOrigen.TabIndex = 3
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Label3)
        Me.GroupBox1.Controls.Add(Label2)
        Me.GroupBox1.Controls.Add(Label1)
        Me.GroupBox1.Controls.Add(Me.txtClienteOrigen)
        Me.GroupBox1.Controls.Add(Me.btnAbrirOrigen)
        Me.GroupBox1.Controls.Add(Me.txtSucursalOrigen)
        Me.GroupBox1.Controls.Add(Me.txtIntervencionOrigen)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(271, 106)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Intervención Origen"
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(6, 27)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(66, 13)
        Label1.TabIndex = 4
        Label1.Text = "Intervención"
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Location = New System.Drawing.Point(134, 27)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(39, 13)
        Label2.TabIndex = 5
        Label2.Text = "Cliente"
        '
        'Label3
        '
        Label3.AutoSize = True
        Label3.Location = New System.Drawing.Point(198, 27)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(48, 13)
        Label3.TabIndex = 6
        Label3.Text = "Sucursal"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Label4)
        Me.GroupBox2.Controls.Add(Label5)
        Me.GroupBox2.Controls.Add(Label6)
        Me.GroupBox2.Controls.Add(Me.txtClienteDestino)
        Me.GroupBox2.Controls.Add(Me.btnAbrirDestino)
        Me.GroupBox2.Controls.Add(Me.txtSucursalDestino)
        Me.GroupBox2.Controls.Add(Me.txtIntervencionDestino)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 124)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(271, 106)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Intervención Destino"
        '
        'Label4
        '
        Label4.AutoSize = True
        Label4.Location = New System.Drawing.Point(198, 27)
        Label4.Name = "Label4"
        Label4.Size = New System.Drawing.Size(48, 13)
        Label4.TabIndex = 6
        Label4.Text = "Sucursal"
        '
        'Label5
        '
        Label5.AutoSize = True
        Label5.Location = New System.Drawing.Point(134, 27)
        Label5.Name = "Label5"
        Label5.Size = New System.Drawing.Size(39, 13)
        Label5.TabIndex = 5
        Label5.Text = "Cliente"
        '
        'Label6
        '
        Label6.AutoSize = True
        Label6.Location = New System.Drawing.Point(6, 27)
        Label6.Name = "Label6"
        Label6.Size = New System.Drawing.Size(66, 13)
        Label6.TabIndex = 4
        Label6.Text = "Intervención"
        '
        'txtClienteDestino
        '
        Me.txtClienteDestino.Location = New System.Drawing.Point(137, 43)
        Me.txtClienteDestino.Name = "txtClienteDestino"
        Me.txtClienteDestino.ReadOnly = True
        Me.txtClienteDestino.Size = New System.Drawing.Size(55, 20)
        Me.txtClienteDestino.TabIndex = 2
        '
        'btnAbrirDestino
        '
        Me.btnAbrirDestino.Location = New System.Drawing.Point(187, 69)
        Me.btnAbrirDestino.Name = "btnAbrirDestino"
        Me.btnAbrirDestino.Size = New System.Drawing.Size(75, 23)
        Me.btnAbrirDestino.TabIndex = 0
        Me.btnAbrirDestino.Text = "Abrir"
        Me.btnAbrirDestino.UseVisualStyleBackColor = True
        '
        'txtSucursalDestino
        '
        Me.txtSucursalDestino.Location = New System.Drawing.Point(198, 43)
        Me.txtSucursalDestino.Name = "txtSucursalDestino"
        Me.txtSucursalDestino.ReadOnly = True
        Me.txtSucursalDestino.Size = New System.Drawing.Size(64, 20)
        Me.txtSucursalDestino.TabIndex = 3
        '
        'txtIntervencionDestino
        '
        Me.txtIntervencionDestino.Location = New System.Drawing.Point(6, 43)
        Me.txtIntervencionDestino.Name = "txtIntervencionDestino"
        Me.txtIntervencionDestino.ReadOnly = True
        Me.txtIntervencionDestino.Size = New System.Drawing.Size(125, 20)
        Me.txtIntervencionDestino.TabIndex = 1
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToDeleteRows = False
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colSolicitud, Me.colIntervención, Me.colSerie})
        Me.dgv.Location = New System.Drawing.Point(289, 14)
        Me.dgv.Name = "dgv"
        Me.dgv.ReadOnly = True
        Me.dgv.Size = New System.Drawing.Size(490, 216)
        Me.dgv.TabIndex = 8
        '
        'colSolicitud
        '
        Me.colSolicitud.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colSolicitud.HeaderText = "Solicitud"
        Me.colSolicitud.Name = "colSolicitud"
        Me.colSolicitud.ReadOnly = True
        Me.colSolicitud.Width = 72
        '
        'colIntervención
        '
        Me.colIntervención.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colIntervención.HeaderText = "Intervención"
        Me.colIntervención.Name = "colIntervención"
        Me.colIntervención.ReadOnly = True
        Me.colIntervención.Width = 91
        '
        'colSerie
        '
        Me.colSerie.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colSerie.HeaderText = "Serie"
        Me.colSerie.Name = "colSerie"
        Me.colSerie.ReadOnly = True
        Me.colSerie.Width = 56
        '
        'btnTransferir
        '
        Me.btnTransferir.Location = New System.Drawing.Point(689, 237)
        Me.btnTransferir.Name = "btnTransferir"
        Me.btnTransferir.Size = New System.Drawing.Size(75, 23)
        Me.btnTransferir.TabIndex = 7
        Me.btnTransferir.Text = "Transferir"
        Me.btnTransferir.UseVisualStyleBackColor = True
        '
        'frmTransferenciaIntervencion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(791, 272)
        Me.Controls.Add(Me.btnTransferir)
        Me.Controls.Add(Me.dgv)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmTransferenciaIntervencion"
        Me.Text = "Transferencia de Intervenciones"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnAbrirOrigen As System.Windows.Forms.Button
    Friend WithEvents txtIntervencionOrigen As System.Windows.Forms.TextBox
    Friend WithEvents txtClienteOrigen As System.Windows.Forms.TextBox
    Friend WithEvents txtSucursalOrigen As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtClienteDestino As System.Windows.Forms.TextBox
    Friend WithEvents btnAbrirDestino As System.Windows.Forms.Button
    Friend WithEvents txtSucursalDestino As System.Windows.Forms.TextBox
    Friend WithEvents txtIntervencionDestino As System.Windows.Forms.TextBox
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents btnTransferir As System.Windows.Forms.Button
    Friend WithEvents colSolicitud As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIntervención As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSerie As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
