<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmControlPeriodico
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
        Me.btn_control = New System.Windows.Forms.Button
        Me.txtbox_client = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtbox_direccion = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txt_obs = New System.Windows.Forms.TextBox
        Me.dtp_control = New System.Windows.Forms.DateTimePicker
        Me.dtp_fecha_vencimiento = New System.Windows.Forms.DateTimePicker
        Me.dtp_prox_control = New System.Windows.Forms.DateTimePicker
        Me.txt_usos = New System.Windows.Forms.TextBox
        Me.checkIRAM = New System.Windows.Forms.CheckBox
        Me.SuspendLayout()
        '
        'btn_control
        '
        Me.btn_control.Location = New System.Drawing.Point(314, 98)
        Me.btn_control.Name = "btn_control"
        Me.btn_control.Size = New System.Drawing.Size(75, 23)
        Me.btn_control.TabIndex = 0
        Me.btn_control.Text = "buscar"
        Me.btn_control.UseVisualStyleBackColor = True
        '
        'txtbox_client
        '
        Me.txtbox_client.Location = New System.Drawing.Point(314, 24)
        Me.txtbox_client.Name = "txtbox_client"
        Me.txtbox_client.Size = New System.Drawing.Size(100, 20)
        Me.txtbox_client.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(257, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Cliente"
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.DisplayGroupTree = False
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(12, 129)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.ShowCloseButton = False
        Me.CrystalReportViewer1.ShowExportButton = False
        Me.CrystalReportViewer1.ShowGotoPageButton = False
        Me.CrystalReportViewer1.ShowGroupTreeButton = False
        Me.CrystalReportViewer1.ShowZoomButton = False
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(929, 339)
        Me.CrystalReportViewer1.TabIndex = 3
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(257, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Sucursal"
        '
        'txtbox_direccion
        '
        Me.txtbox_direccion.Location = New System.Drawing.Point(314, 50)
        Me.txtbox_direccion.Name = "txtbox_direccion"
        Me.txtbox_direccion.Size = New System.Drawing.Size(100, 20)
        Me.txtbox_direccion.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(449, 50)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Destino"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(449, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(87, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Fecha de control"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(449, 102)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 13)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Proximo control"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(449, 76)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(112, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Fecha de vencimiento"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(619, 21)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(64, 13)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Cumple iram"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(619, 50)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(78, 13)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Observaciones"
        '
        'txt_obs
        '
        Me.txt_obs.Location = New System.Drawing.Point(703, 47)
        Me.txt_obs.Name = "txt_obs"
        Me.txt_obs.Size = New System.Drawing.Size(133, 20)
        Me.txt_obs.TabIndex = 14
        '
        'dtp_control
        '
        Me.dtp_control.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_control.Location = New System.Drawing.Point(542, 18)
        Me.dtp_control.Name = "dtp_control"
        Me.dtp_control.Size = New System.Drawing.Size(71, 20)
        Me.dtp_control.TabIndex = 19
        '
        'dtp_fecha_vencimiento
        '
        Me.dtp_fecha_vencimiento.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha_vencimiento.Location = New System.Drawing.Point(567, 69)
        Me.dtp_fecha_vencimiento.Name = "dtp_fecha_vencimiento"
        Me.dtp_fecha_vencimiento.Size = New System.Drawing.Size(71, 20)
        Me.dtp_fecha_vencimiento.TabIndex = 20
        '
        'dtp_prox_control
        '
        Me.dtp_prox_control.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_prox_control.Location = New System.Drawing.Point(534, 96)
        Me.dtp_prox_control.Name = "dtp_prox_control"
        Me.dtp_prox_control.Size = New System.Drawing.Size(71, 20)
        Me.dtp_prox_control.TabIndex = 21
        '
        'txt_usos
        '
        Me.txt_usos.Location = New System.Drawing.Point(498, 44)
        Me.txt_usos.Name = "txt_usos"
        Me.txt_usos.Size = New System.Drawing.Size(100, 20)
        Me.txt_usos.TabIndex = 22
        '
        'checkIRAM
        '
        Me.checkIRAM.AutoSize = True
        Me.checkIRAM.Location = New System.Drawing.Point(690, 21)
        Me.checkIRAM.Name = "checkIRAM"
        Me.checkIRAM.Size = New System.Drawing.Size(15, 14)
        Me.checkIRAM.TabIndex = 23
        Me.checkIRAM.UseVisualStyleBackColor = True
        '
        'frmControlPeriodico
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(955, 471)
        Me.Controls.Add(Me.checkIRAM)
        Me.Controls.Add(Me.txt_usos)
        Me.Controls.Add(Me.dtp_prox_control)
        Me.Controls.Add(Me.dtp_fecha_vencimiento)
        Me.Controls.Add(Me.dtp_control)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txt_obs)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtbox_direccion)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtbox_client)
        Me.Controls.Add(Me.btn_control)
        Me.Name = "frmControlPeriodico"
        Me.Text = "frmControlPeriodico"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_control As System.Windows.Forms.Button
    Friend WithEvents txtbox_client As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtbox_direccion As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txt_obs As System.Windows.Forms.TextBox
    Friend WithEvents dtp_control As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_fecha_vencimiento As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_prox_control As System.Windows.Forms.DateTimePicker
    Friend WithEvents txt_usos As System.Windows.Forms.TextBox
    Friend WithEvents checkIRAM As System.Windows.Forms.CheckBox
End Class
