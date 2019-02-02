<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrecios
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.dgv = New System.Windows.Forms.DataGridView
        Me.colCodigo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colDescripcion = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.colCantidad = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colPrecio0 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colPrecio1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colPrecio2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colPrecio3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colPrecio4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colPrecio5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colPrecio6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colPrecio7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colPrecio8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colPrecio9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colPrecio10 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colPrecio11 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colPrecio12 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colPrecio13 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colPrecio14 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colPrecio15 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colPrecio16 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colPrecio17 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colPrecio18 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colNuevo = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.btnImportar = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.btnExportar = New System.Windows.Forms.Button
        Me.btnRegistrar = New System.Windows.Forms.Button
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.dgv)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnImportar)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Button2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnExportar)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnRegistrar)
        Me.SplitContainer1.Size = New System.Drawing.Size(725, 467)
        Me.SplitContainer1.SplitterDistance = 417
        Me.SplitContainer1.TabIndex = 0
        '
        'dgv
        '
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colCodigo, Me.colDescripcion, Me.colCantidad, Me.colPrecio0, Me.colPrecio1, Me.colPrecio2, Me.colPrecio3, Me.colPrecio4, Me.colPrecio5, Me.colPrecio6, Me.colPrecio7, Me.colPrecio8, Me.colPrecio9, Me.colPrecio10, Me.colPrecio11, Me.colPrecio12, Me.colPrecio13, Me.colPrecio14, Me.colPrecio15, Me.colPrecio16, Me.colPrecio17, Me.colPrecio18, Me.colNuevo})
        Me.dgv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv.Location = New System.Drawing.Point(0, 0)
        Me.dgv.Name = "dgv"
        Me.dgv.Size = New System.Drawing.Size(725, 417)
        Me.dgv.TabIndex = 0
        '
        'colCodigo
        '
        Me.colCodigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.colCodigo.HeaderText = "Codigo"
        Me.colCodigo.Name = "colCodigo"
        Me.colCodigo.Width = 65
        '
        'colDescripcion
        '
        Me.colDescripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colDescripcion.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.colDescripcion.HeaderText = "Descripcion"
        Me.colDescripcion.Name = "colDescripcion"
        Me.colDescripcion.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colDescripcion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colDescripcion.Width = 88
        '
        'colCantidad
        '
        Me.colCantidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colCantidad.DefaultCellStyle = DataGridViewCellStyle1
        Me.colCantidad.HeaderText = "Cantidad"
        Me.colCantidad.Name = "colCantidad"
        Me.colCantidad.Width = 74
        '
        'colPrecio0
        '
        Me.colPrecio0.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colPrecio0.DefaultCellStyle = DataGridViewCellStyle2
        Me.colPrecio0.HeaderText = "Distribuidor A+"
        Me.colPrecio0.Name = "colPrecio0"
        '
        'colPrecio1
        '
        Me.colPrecio1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colPrecio1.DefaultCellStyle = DataGridViewCellStyle3
        Me.colPrecio1.HeaderText = "Distribuidor A"
        Me.colPrecio1.Name = "colPrecio1"
        Me.colPrecio1.Width = 94
        '
        'colPrecio2
        '
        Me.colPrecio2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colPrecio2.DefaultCellStyle = DataGridViewCellStyle4
        Me.colPrecio2.HeaderText = "Distribuidor B"
        Me.colPrecio2.Name = "colPrecio2"
        Me.colPrecio2.Width = 94
        '
        'colPrecio3
        '
        Me.colPrecio3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colPrecio3.DefaultCellStyle = DataGridViewCellStyle5
        Me.colPrecio3.HeaderText = "Distribuidor C"
        Me.colPrecio3.Name = "colPrecio3"
        Me.colPrecio3.Width = 94
        '
        'colPrecio4
        '
        Me.colPrecio4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colPrecio4.DefaultCellStyle = DataGridViewCellStyle6
        Me.colPrecio4.HeaderText = "Distribuidor D"
        Me.colPrecio4.Name = "colPrecio4"
        Me.colPrecio4.Width = 95
        '
        'colPrecio5
        '
        Me.colPrecio5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colPrecio5.DefaultCellStyle = DataGridViewCellStyle7
        Me.colPrecio5.HeaderText = "Distribuidor E"
        Me.colPrecio5.Name = "colPrecio5"
        Me.colPrecio5.Width = 94
        '
        'colPrecio6
        '
        Me.colPrecio6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colPrecio6.DefaultCellStyle = DataGridViewCellStyle8
        Me.colPrecio6.HeaderText = "Empresa A"
        Me.colPrecio6.Name = "colPrecio6"
        Me.colPrecio6.Width = 83
        '
        'colPrecio7
        '
        Me.colPrecio7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colPrecio7.DefaultCellStyle = DataGridViewCellStyle9
        Me.colPrecio7.HeaderText = "Empresa B"
        Me.colPrecio7.Name = "colPrecio7"
        Me.colPrecio7.Width = 83
        '
        'colPrecio8
        '
        Me.colPrecio8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colPrecio8.DefaultCellStyle = DataGridViewCellStyle10
        Me.colPrecio8.HeaderText = "Empresa C"
        Me.colPrecio8.Name = "colPrecio8"
        Me.colPrecio8.Width = 83
        '
        'colPrecio9
        '
        Me.colPrecio9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colPrecio9.DefaultCellStyle = DataGridViewCellStyle11
        Me.colPrecio9.HeaderText = "Empresa D"
        Me.colPrecio9.Name = "colPrecio9"
        Me.colPrecio9.Width = 84
        '
        'colPrecio10
        '
        Me.colPrecio10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colPrecio10.DefaultCellStyle = DataGridViewCellStyle12
        Me.colPrecio10.HeaderText = "Empresa E"
        Me.colPrecio10.Name = "colPrecio10"
        Me.colPrecio10.Width = 83
        '
        'colPrecio11
        '
        Me.colPrecio11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colPrecio11.DefaultCellStyle = DataGridViewCellStyle13
        Me.colPrecio11.HeaderText = "Consorcio A"
        Me.colPrecio11.Name = "colPrecio11"
        Me.colPrecio11.Width = 89
        '
        'colPrecio12
        '
        Me.colPrecio12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colPrecio12.DefaultCellStyle = DataGridViewCellStyle14
        Me.colPrecio12.HeaderText = "Consorcio B"
        Me.colPrecio12.Name = "colPrecio12"
        Me.colPrecio12.Width = 89
        '
        'colPrecio13
        '
        Me.colPrecio13.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colPrecio13.DefaultCellStyle = DataGridViewCellStyle15
        Me.colPrecio13.HeaderText = "Consorcio C"
        Me.colPrecio13.Name = "colPrecio13"
        Me.colPrecio13.Width = 89
        '
        'colPrecio14
        '
        Me.colPrecio14.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colPrecio14.DefaultCellStyle = DataGridViewCellStyle16
        Me.colPrecio14.HeaderText = "Consorcio D"
        Me.colPrecio14.Name = "colPrecio14"
        Me.colPrecio14.Width = 90
        '
        'colPrecio15
        '
        Me.colPrecio15.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colPrecio15.DefaultCellStyle = DataGridViewCellStyle17
        Me.colPrecio15.HeaderText = "Consorcio E"
        Me.colPrecio15.Name = "colPrecio15"
        Me.colPrecio15.Width = 89
        '
        'colPrecio16
        '
        Me.colPrecio16.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colPrecio16.DefaultCellStyle = DataGridViewCellStyle18
        Me.colPrecio16.HeaderText = "Directa Web"
        Me.colPrecio16.Name = "colPrecio16"
        Me.colPrecio16.Width = 92
        '
        'colPrecio17
        '
        Me.colPrecio17.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colPrecio17.DefaultCellStyle = DataGridViewCellStyle19
        Me.colPrecio17.HeaderText = "Directa ML"
        Me.colPrecio17.Name = "colPrecio17"
        Me.colPrecio17.Width = 84
        '
        'colPrecio18
        '
        Me.colPrecio18.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colPrecio18.DefaultCellStyle = DataGridViewCellStyle20
        Me.colPrecio18.HeaderText = "Directa F"
        Me.colPrecio18.Name = "colPrecio18"
        Me.colPrecio18.Width = 75
        '
        'colNuevo
        '
        Me.colNuevo.HeaderText = "Nuevo"
        Me.colNuevo.Name = "colNuevo"
        Me.colNuevo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'btnImportar
        '
        Me.btnImportar.Location = New System.Drawing.Point(174, 11)
        Me.btnImportar.Name = "btnImportar"
        Me.btnImportar.Size = New System.Drawing.Size(75, 23)
        Me.btnImportar.TabIndex = 0
        Me.btnImportar.Text = "Importar"
        Me.btnImportar.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(174, 11)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 0
        Me.Button2.Text = "Registrar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'btnExportar
        '
        Me.btnExportar.Location = New System.Drawing.Point(93, 11)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(75, 23)
        Me.btnExportar.TabIndex = 0
        Me.btnExportar.Text = "Exportar"
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'btnRegistrar
        '
        Me.btnRegistrar.Location = New System.Drawing.Point(12, 11)
        Me.btnRegistrar.Name = "btnRegistrar"
        Me.btnRegistrar.Size = New System.Drawing.Size(75, 23)
        Me.btnRegistrar.TabIndex = 0
        Me.btnRegistrar.Text = "Registrar"
        Me.btnRegistrar.UseVisualStyleBackColor = True
        '
        'frmPrecios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(725, 467)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "frmPrecios"
        Me.Text = "Lista de precios"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents btnRegistrar As System.Windows.Forms.Button
    Friend WithEvents btnImportar As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents btnExportar As System.Windows.Forms.Button
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents colCodigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDescripcion As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colCantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPrecio0 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPrecio1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPrecio2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPrecio3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPrecio4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPrecio5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPrecio6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPrecio7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPrecio8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPrecio9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPrecio10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPrecio11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPrecio12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPrecio13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPrecio14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPrecio15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPrecio16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPrecio17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPrecio18 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNuevo As System.Windows.Forms.DataGridViewComboBoxColumn
End Class
