<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListadoRecibos
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
        Me.btn_list_pedidos = New System.Windows.Forms.Button
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.dtp_pago_inicio = New System.Windows.Forms.DateTimePicker
        Me.dtp_pago_fin = New System.Windows.Forms.DateTimePicker
        Me.SuspendLayout()
        '
        'btn_list_pedidos
        '
        Me.btn_list_pedidos.Location = New System.Drawing.Point(712, 12)
        Me.btn_list_pedidos.Name = "btn_list_pedidos"
        Me.btn_list_pedidos.Size = New System.Drawing.Size(75, 23)
        Me.btn_list_pedidos.TabIndex = 0
        Me.btn_list_pedidos.Text = "Consultar"
        Me.btn_list_pedidos.UseVisualStyleBackColor = True
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.DisplayGroupTree = False
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(12, 41)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.ShowCloseButton = False
        Me.CrystalReportViewer1.ShowGroupTreeButton = False
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(834, 413)
        Me.CrystalReportViewer1.TabIndex = 3
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(365, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Fecha "
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(510, 21)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(54, 13)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = "Fecha fin "
        '
        'dtp_pago_inicio
        '
        Me.dtp_pago_inicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_pago_inicio.Location = New System.Drawing.Point(411, 15)
        Me.dtp_pago_inicio.Name = "dtp_pago_inicio"
        Me.dtp_pago_inicio.Size = New System.Drawing.Size(93, 20)
        Me.dtp_pago_inicio.TabIndex = 20
        '
        'dtp_pago_fin
        '
        Me.dtp_pago_fin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_pago_fin.Location = New System.Drawing.Point(599, 15)
        Me.dtp_pago_fin.Name = "dtp_pago_fin"
        Me.dtp_pago_fin.Size = New System.Drawing.Size(93, 20)
        Me.dtp_pago_fin.TabIndex = 21
        '
        'frmListadoPedidos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(858, 466)
        Me.Controls.Add(Me.dtp_pago_fin)
        Me.Controls.Add(Me.dtp_pago_inicio)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Controls.Add(Me.btn_list_pedidos)
        Me.Name = "frmListadoPedidos"
        Me.Text = "Consulta de listado de Recibos"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_list_pedidos As System.Windows.Forms.Button
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dtp_pago_inicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_pago_fin As System.Windows.Forms.DateTimePicker
End Class
