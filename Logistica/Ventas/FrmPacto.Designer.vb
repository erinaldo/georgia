<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPacto
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
        Me.CBVerPendientes = New System.Windows.Forms.CheckBox
        Me.CBVerTodos = New System.Windows.Forms.CheckBox
        Me.BtnLimpiar = New System.Windows.Forms.Button
        Me.Reporte = New System.Windows.Forms.GroupBox
        Me.BtnBuscar = New System.Windows.Forms.Button
        Me.DtpHasta = New System.Windows.Forms.DateTimePicker
        Me.DtpDesde = New System.Windows.Forms.DateTimePicker
        Me.CmbCotizar = New System.Windows.Forms.ComboBox
        Me.TxtNumero = New System.Windows.Forms.TextBox
        Me.CmbEstado = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtColega = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.CmbVendedor = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.CmbUbicacion = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.TxtDomicilio = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxtRazonSocial = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnRegistrar = New System.Windows.Forms.Button
        Me.dgv = New System.Windows.Forms.DataGridView
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Reporte.SuspendLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.CBVerPendientes)
        Me.SplitContainer1.Panel1.Controls.Add(Me.CBVerTodos)
        Me.SplitContainer1.Panel1.Controls.Add(Me.BtnLimpiar)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Reporte)
        Me.SplitContainer1.Panel1.Controls.Add(Me.CmbCotizar)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TxtNumero)
        Me.SplitContainer1.Panel1.Controls.Add(Me.CmbEstado)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TxtColega)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.CmbVendedor)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label7)
        Me.SplitContainer1.Panel1.Controls.Add(Me.CmbUbicacion)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label6)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label5)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TxtDomicilio)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TxtRazonSocial)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnRegistrar)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgv)
        Me.SplitContainer1.Size = New System.Drawing.Size(792, 517)
        Me.SplitContainer1.SplitterDistance = 180
        Me.SplitContainer1.TabIndex = 0
        '
        'CBVerPendientes
        '
        Me.CBVerPendientes.AutoSize = True
        Me.CBVerPendientes.Location = New System.Drawing.Point(657, 161)
        Me.CBVerPendientes.Name = "CBVerPendientes"
        Me.CBVerPendientes.Size = New System.Drawing.Size(98, 17)
        Me.CBVerPendientes.TabIndex = 28
        Me.CBVerPendientes.Text = "Ver Pendientes"
        Me.CBVerPendientes.UseVisualStyleBackColor = True
        '
        'CBVerTodos
        '
        Me.CBVerTodos.AutoSize = True
        Me.CBVerTodos.Location = New System.Drawing.Point(657, 145)
        Me.CBVerTodos.Name = "CBVerTodos"
        Me.CBVerTodos.Size = New System.Drawing.Size(75, 17)
        Me.CBVerTodos.TabIndex = 27
        Me.CBVerTodos.Text = "Ver Todos"
        Me.CBVerTodos.UseVisualStyleBackColor = True
        '
        'BtnLimpiar
        '
        Me.BtnLimpiar.Location = New System.Drawing.Point(448, 116)
        Me.BtnLimpiar.Name = "BtnLimpiar"
        Me.BtnLimpiar.Size = New System.Drawing.Size(75, 23)
        Me.BtnLimpiar.TabIndex = 26
        Me.BtnLimpiar.Text = "Limpiar"
        Me.BtnLimpiar.UseVisualStyleBackColor = True
        '
        'Reporte
        '
        Me.Reporte.Controls.Add(Me.BtnBuscar)
        Me.Reporte.Controls.Add(Me.DtpHasta)
        Me.Reporte.Controls.Add(Me.DtpDesde)
        Me.Reporte.Location = New System.Drawing.Point(620, 14)
        Me.Reporte.Name = "Reporte"
        Me.Reporte.Size = New System.Drawing.Size(158, 125)
        Me.Reporte.TabIndex = 25
        Me.Reporte.TabStop = False
        Me.Reporte.Text = "Reporte"
        '
        'BtnBuscar
        '
        Me.BtnBuscar.Location = New System.Drawing.Point(43, 91)
        Me.BtnBuscar.Name = "BtnBuscar"
        Me.BtnBuscar.Size = New System.Drawing.Size(75, 23)
        Me.BtnBuscar.TabIndex = 2
        Me.BtnBuscar.Text = "Buscar"
        Me.BtnBuscar.UseVisualStyleBackColor = True
        '
        'DtpHasta
        '
        Me.DtpHasta.Location = New System.Drawing.Point(10, 64)
        Me.DtpHasta.Name = "DtpHasta"
        Me.DtpHasta.Size = New System.Drawing.Size(134, 20)
        Me.DtpHasta.TabIndex = 1
        '
        'DtpDesde
        '
        Me.DtpDesde.Location = New System.Drawing.Point(10, 34)
        Me.DtpDesde.Name = "DtpDesde"
        Me.DtpDesde.Size = New System.Drawing.Size(134, 20)
        Me.DtpDesde.TabIndex = 0
        '
        'CmbCotizar
        '
        Me.CmbCotizar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbCotizar.FormattingEnabled = True
        Me.CmbCotizar.Items.AddRange(New Object() {"", "Nuevos", "Recarga", "639"})
        Me.CmbCotizar.Location = New System.Drawing.Point(132, 111)
        Me.CmbCotizar.Name = "CmbCotizar"
        Me.CmbCotizar.Size = New System.Drawing.Size(164, 21)
        Me.CmbCotizar.TabIndex = 22
        '
        'TxtNumero
        '
        Me.TxtNumero.Location = New System.Drawing.Point(302, 82)
        Me.TxtNumero.Name = "TxtNumero"
        Me.TxtNumero.Size = New System.Drawing.Size(83, 20)
        Me.TxtNumero.TabIndex = 21
        Me.TxtNumero.Visible = False
        '
        'CmbEstado
        '
        Me.CmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbEstado.Enabled = False
        Me.CmbEstado.FormattingEnabled = True
        Me.CmbEstado.Items.AddRange(New Object() {"", "Pendiente", "Liberado", "Esperando Precios", "Precio Colega"})
        Me.CmbEstado.Location = New System.Drawing.Point(448, 83)
        Me.CmbEstado.Name = "CmbEstado"
        Me.CmbEstado.Size = New System.Drawing.Size(164, 21)
        Me.CmbEstado.TabIndex = 20
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(388, 86)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Estado"
        '
        'TxtColega
        '
        Me.TxtColega.Enabled = False
        Me.TxtColega.Location = New System.Drawing.Point(448, 52)
        Me.TxtColega.Name = "TxtColega"
        Me.TxtColega.Size = New System.Drawing.Size(164, 20)
        Me.TxtColega.TabIndex = 18
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(388, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Colega"
        '
        'CmbVendedor
        '
        Me.CmbVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbVendedor.FormattingEnabled = True
        Me.CmbVendedor.Location = New System.Drawing.Point(448, 22)
        Me.CmbVendedor.Name = "CmbVendedor"
        Me.CmbVendedor.Size = New System.Drawing.Size(164, 21)
        Me.CmbVendedor.TabIndex = 16
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(53, 86)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(58, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Ubicacion:"
        '
        'CmbUbicacion
        '
        Me.CmbUbicacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbUbicacion.FormattingEnabled = True
        Me.CmbUbicacion.Items.AddRange(New Object() {"", "Capital ", "Provincia"})
        Me.CmbUbicacion.Location = New System.Drawing.Point(132, 82)
        Me.CmbUbicacion.Name = "CmbUbicacion"
        Me.CmbUbicacion.Size = New System.Drawing.Size(164, 21)
        Me.CmbUbicacion.TabIndex = 14
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(53, 112)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Cotizar:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(388, 26)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Vendedor"
        '
        'TxtDomicilio
        '
        Me.TxtDomicilio.Location = New System.Drawing.Point(132, 54)
        Me.TxtDomicilio.Name = "TxtDomicilio"
        Me.TxtDomicilio.Size = New System.Drawing.Size(230, 20)
        Me.TxtDomicilio.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(53, 57)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Domicilio:"
        '
        'TxtRazonSocial
        '
        Me.TxtRazonSocial.Location = New System.Drawing.Point(132, 22)
        Me.TxtRazonSocial.Name = "TxtRazonSocial"
        Me.TxtRazonSocial.Size = New System.Drawing.Size(230, 20)
        Me.TxtRazonSocial.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(53, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Razon Social:"
        '
        'btnRegistrar
        '
        Me.btnRegistrar.Location = New System.Drawing.Point(537, 117)
        Me.btnRegistrar.Name = "btnRegistrar"
        Me.btnRegistrar.Size = New System.Drawing.Size(75, 23)
        Me.btnRegistrar.TabIndex = 0
        Me.btnRegistrar.Text = "Registrar"
        Me.btnRegistrar.UseVisualStyleBackColor = True
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToDeleteRows = False
        Me.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv.Location = New System.Drawing.Point(0, 0)
        Me.dgv.Name = "dgv"
        Me.dgv.RowHeadersVisible = False
        Me.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv.Size = New System.Drawing.Size(792, 333)
        Me.dgv.TabIndex = 0
        '
        'FrmPacto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(792, 517)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "FrmPacto"
        Me.Text = "Pacto"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.Reporte.ResumeLayout(False)
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtDomicilio As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtRazonSocial As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnRegistrar As System.Windows.Forms.Button
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents CmbUbicacion As System.Windows.Forms.ComboBox
    Friend WithEvents CmbVendedor As System.Windows.Forms.ComboBox
    Friend WithEvents TxtColega As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CmbEstado As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtNumero As System.Windows.Forms.TextBox
    Friend WithEvents CmbCotizar As System.Windows.Forms.ComboBox
    Friend WithEvents Reporte As System.Windows.Forms.GroupBox
    Friend WithEvents BtnBuscar As System.Windows.Forms.Button
    Friend WithEvents DtpHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtpDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents BtnLimpiar As System.Windows.Forms.Button
    Friend WithEvents CBVerPendientes As System.Windows.Forms.CheckBox
    Friend WithEvents CBVerTodos As System.Windows.Forms.CheckBox
End Class
