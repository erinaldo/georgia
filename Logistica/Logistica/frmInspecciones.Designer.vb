<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInspecciones
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
        Me.dgvSigex = New System.Windows.Forms.DataGridView
        Me.colId = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colIntervencion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colFecha = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colRelevador = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colEstado = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.colCliente = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnRefrescar = New System.Windows.Forms.Button
        Me.btnTransferir = New System.Windows.Forms.Button
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.dgvAdonix = New System.Windows.Forms.DataGridView
        Label1 = New System.Windows.Forms.Label
        Label2 = New System.Windows.Forms.Label
        CType(Me.dgvSigex, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.dgvAdonix, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvSigex
        '
        Me.dgvSigex.AllowUserToAddRows = False
        Me.dgvSigex.AllowUserToDeleteRows = False
        Me.dgvSigex.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvSigex.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSigex.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colId, Me.colIntervencion, Me.colFecha, Me.colRelevador, Me.colEstado, Me.colCliente})
        Me.dgvSigex.Location = New System.Drawing.Point(3, 28)
        Me.dgvSigex.Name = "dgvSigex"
        Me.dgvSigex.ReadOnly = True
        Me.dgvSigex.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSigex.Size = New System.Drawing.Size(811, 130)
        Me.dgvSigex.TabIndex = 0
        '
        'colId
        '
        Me.colId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colId.HeaderText = "Id"
        Me.colId.Name = "colId"
        Me.colId.ReadOnly = True
        Me.colId.Width = 41
        '
        'colIntervencion
        '
        Me.colIntervencion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colIntervencion.HeaderText = "Intervencion"
        Me.colIntervencion.Name = "colIntervencion"
        Me.colIntervencion.ReadOnly = True
        Me.colIntervencion.Width = 91
        '
        'colFecha
        '
        Me.colFecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colFecha.HeaderText = "Fecha Programacion"
        Me.colFecha.Name = "colFecha"
        Me.colFecha.ReadOnly = True
        Me.colFecha.Width = 119
        '
        'colRelevador
        '
        Me.colRelevador.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colRelevador.HeaderText = "Relevador"
        Me.colRelevador.Name = "colRelevador"
        Me.colRelevador.ReadOnly = True
        Me.colRelevador.Width = 81
        '
        'colEstado
        '
        Me.colEstado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colEstado.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.colEstado.HeaderText = "Estado"
        Me.colEstado.Name = "colEstado"
        Me.colEstado.ReadOnly = True
        Me.colEstado.Width = 46
        '
        'colCliente
        '
        Me.colCliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colCliente.HeaderText = "Cliente"
        Me.colCliente.Name = "colCliente"
        Me.colCliente.ReadOnly = True
        Me.colCliente.Width = 64
        '
        'btnRefrescar
        '
        Me.btnRefrescar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefrescar.Location = New System.Drawing.Point(824, 28)
        Me.btnRefrescar.Name = "btnRefrescar"
        Me.btnRefrescar.Size = New System.Drawing.Size(75, 23)
        Me.btnRefrescar.TabIndex = 1
        Me.btnRefrescar.Text = "Refrescar"
        Me.btnRefrescar.UseVisualStyleBackColor = True
        '
        'btnTransferir
        '
        Me.btnTransferir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTransferir.Location = New System.Drawing.Point(824, 57)
        Me.btnTransferir.Name = "btnTransferir"
        Me.btnTransferir.Size = New System.Drawing.Size(75, 23)
        Me.btnTransferir.TabIndex = 2
        Me.btnTransferir.Text = "Transferir"
        Me.btnTransferir.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Label1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnRefrescar)
        Me.SplitContainer1.Panel1.Controls.Add(Me.dgvSigex)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnTransferir)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgvAdonix)
        Me.SplitContainer1.Panel2.Controls.Add(Label2)
        Me.SplitContainer1.Size = New System.Drawing.Size(911, 476)
        Me.SplitContainer1.SplitterDistance = 161
        Me.SplitContainer1.TabIndex = 2
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(3, 9)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(121, 13)
        Label1.TabIndex = 3
        Label1.Text = "Relevamientos en Sigex"
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Location = New System.Drawing.Point(3, 15)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(197, 13)
        Label2.TabIndex = 4
        Label2.Text = "Relevamientos en Adonix para confirmar"
        '
        'dgvAdonix
        '
        Me.dgvAdonix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAdonix.Location = New System.Drawing.Point(3, 31)
        Me.dgvAdonix.Name = "dgvAdonix"
        Me.dgvAdonix.Size = New System.Drawing.Size(905, 277)
        Me.dgvAdonix.TabIndex = 5
        '
        'frmRelevamientosV2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(911, 476)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "frmRelevamientosV2"
        Me.Text = "Relevamientos"
        CType(Me.dgvSigex, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.dgvAdonix, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvSigex As System.Windows.Forms.DataGridView
    Friend WithEvents btnRefrescar As System.Windows.Forms.Button
    Friend WithEvents colId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIntervencion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRelevador As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colEstado As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colCliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnTransferir As System.Windows.Forms.Button
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents dgvAdonix As System.Windows.Forms.DataGridView
End Class
