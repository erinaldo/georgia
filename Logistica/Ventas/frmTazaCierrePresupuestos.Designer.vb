<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTazaCierrePresupuestos
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
        Dim Label2 As System.Windows.Forms.Label
        Dim Label3 As System.Windows.Forms.Label
        Dim Label4 As System.Windows.Forms.Label
        Dim Label5 As System.Windows.Forms.Label
        Dim Label6 As System.Windows.Forms.Label
        Me.mc = New System.Windows.Forms.MonthCalendar
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnCalcular = New System.Windows.Forms.Button
        Me.chkNuevos = New System.Windows.Forms.RadioButton
        Me.chkRecargas = New System.Windows.Forms.RadioButton
        Me.txtCantAprobados = New System.Windows.Forms.TextBox
        Me.txtPesosAprobados = New System.Windows.Forms.TextBox
        Me.txtCantNoAprobados = New System.Windows.Forms.TextBox
        Me.txtPesosNoAprobados = New System.Windows.Forms.TextBox
        Me.txtCantTotal = New System.Windows.Forms.TextBox
        Me.txtPesosTotal = New System.Windows.Forms.TextBox
        Me.lblCant = New System.Windows.Forms.Label
        Me.lblPesos = New System.Windows.Forms.Label
        Label2 = New System.Windows.Forms.Label
        Label3 = New System.Windows.Forms.Label
        Label4 = New System.Windows.Forms.Label
        Label5 = New System.Windows.Forms.Label
        Label6 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Location = New System.Drawing.Point(258, 80)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(58, 13)
        Label2.TabIndex = 11
        Label2.Text = "Aprobados"
        '
        'Label3
        '
        Label3.AutoSize = True
        Label3.Location = New System.Drawing.Point(258, 103)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(75, 13)
        Label3.TabIndex = 12
        Label3.Text = "No Aprobados"
        '
        'Label4
        '
        Label4.AutoSize = True
        Label4.Location = New System.Drawing.Point(258, 129)
        Label4.Name = "Label4"
        Label4.Size = New System.Drawing.Size(31, 13)
        Label4.TabIndex = 13
        Label4.Text = "Total"
        '
        'Label5
        '
        Label5.AutoSize = True
        Label5.Location = New System.Drawing.Point(344, 58)
        Label5.Name = "Label5"
        Label5.Size = New System.Drawing.Size(49, 13)
        Label5.TabIndex = 14
        Label5.Text = "Cantidad"
        '
        'Label6
        '
        Label6.AutoSize = True
        Label6.Location = New System.Drawing.Point(461, 58)
        Label6.Name = "Label6"
        Label6.Size = New System.Drawing.Size(42, 13)
        Label6.TabIndex = 15
        Label6.Text = "Importe"
        '
        'mc
        '
        Me.mc.Location = New System.Drawing.Point(18, 30)
        Me.mc.MaxSelectionCount = 31
        Me.mc.Name = "mc"
        Me.mc.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(166, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Seleccionar un Rango de Fechas"
        '
        'btnCalcular
        '
        Me.btnCalcular.Location = New System.Drawing.Point(18, 227)
        Me.btnCalcular.Name = "btnCalcular"
        Me.btnCalcular.Size = New System.Drawing.Size(227, 23)
        Me.btnCalcular.TabIndex = 2
        Me.btnCalcular.Text = "Calcular"
        Me.btnCalcular.UseVisualStyleBackColor = True
        '
        'chkNuevos
        '
        Me.chkNuevos.AutoSize = True
        Me.chkNuevos.Checked = True
        Me.chkNuevos.Location = New System.Drawing.Point(21, 194)
        Me.chkNuevos.Name = "chkNuevos"
        Me.chkNuevos.Size = New System.Drawing.Size(62, 17)
        Me.chkNuevos.TabIndex = 3
        Me.chkNuevos.TabStop = True
        Me.chkNuevos.Text = "Nuevos"
        Me.chkNuevos.UseVisualStyleBackColor = True
        '
        'chkRecargas
        '
        Me.chkRecargas.AutoSize = True
        Me.chkRecargas.Location = New System.Drawing.Point(155, 194)
        Me.chkRecargas.Name = "chkRecargas"
        Me.chkRecargas.Size = New System.Drawing.Size(71, 17)
        Me.chkRecargas.TabIndex = 4
        Me.chkRecargas.Text = "Recargas"
        Me.chkRecargas.UseVisualStyleBackColor = True
        '
        'txtCantAprobados
        '
        Me.txtCantAprobados.Location = New System.Drawing.Point(347, 74)
        Me.txtCantAprobados.Name = "txtCantAprobados"
        Me.txtCantAprobados.ReadOnly = True
        Me.txtCantAprobados.Size = New System.Drawing.Size(111, 20)
        Me.txtCantAprobados.TabIndex = 5
        Me.txtCantAprobados.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtPesosAprobados
        '
        Me.txtPesosAprobados.Location = New System.Drawing.Point(464, 74)
        Me.txtPesosAprobados.Name = "txtPesosAprobados"
        Me.txtPesosAprobados.ReadOnly = True
        Me.txtPesosAprobados.Size = New System.Drawing.Size(100, 20)
        Me.txtPesosAprobados.TabIndex = 6
        Me.txtPesosAprobados.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCantNoAprobados
        '
        Me.txtCantNoAprobados.Location = New System.Drawing.Point(347, 100)
        Me.txtCantNoAprobados.Name = "txtCantNoAprobados"
        Me.txtCantNoAprobados.ReadOnly = True
        Me.txtCantNoAprobados.Size = New System.Drawing.Size(111, 20)
        Me.txtCantNoAprobados.TabIndex = 7
        Me.txtCantNoAprobados.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtPesosNoAprobados
        '
        Me.txtPesosNoAprobados.Location = New System.Drawing.Point(464, 100)
        Me.txtPesosNoAprobados.Name = "txtPesosNoAprobados"
        Me.txtPesosNoAprobados.ReadOnly = True
        Me.txtPesosNoAprobados.Size = New System.Drawing.Size(100, 20)
        Me.txtPesosNoAprobados.TabIndex = 8
        Me.txtPesosNoAprobados.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCantTotal
        '
        Me.txtCantTotal.Location = New System.Drawing.Point(347, 126)
        Me.txtCantTotal.Name = "txtCantTotal"
        Me.txtCantTotal.ReadOnly = True
        Me.txtCantTotal.Size = New System.Drawing.Size(111, 20)
        Me.txtCantTotal.TabIndex = 9
        Me.txtCantTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtPesosTotal
        '
        Me.txtPesosTotal.Location = New System.Drawing.Point(464, 126)
        Me.txtPesosTotal.Name = "txtPesosTotal"
        Me.txtPesosTotal.ReadOnly = True
        Me.txtPesosTotal.Size = New System.Drawing.Size(100, 20)
        Me.txtPesosTotal.TabIndex = 10
        Me.txtPesosTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCant
        '
        Me.lblCant.Location = New System.Drawing.Point(400, 58)
        Me.lblCant.Name = "lblCant"
        Me.lblCant.Size = New System.Drawing.Size(55, 13)
        Me.lblCant.TabIndex = 16
        Me.lblCant.Text = "0%"
        Me.lblCant.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblPesos
        '
        Me.lblPesos.Location = New System.Drawing.Point(509, 58)
        Me.lblPesos.Name = "lblPesos"
        Me.lblPesos.Size = New System.Drawing.Size(55, 13)
        Me.lblPesos.TabIndex = 17
        Me.lblPesos.Text = "0%"
        Me.lblPesos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmTazaCierrePresupuestos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(625, 269)
        Me.Controls.Add(Me.lblPesos)
        Me.Controls.Add(Me.lblCant)
        Me.Controls.Add(Label6)
        Me.Controls.Add(Label5)
        Me.Controls.Add(Label4)
        Me.Controls.Add(Label3)
        Me.Controls.Add(Label2)
        Me.Controls.Add(Me.txtPesosTotal)
        Me.Controls.Add(Me.txtCantTotal)
        Me.Controls.Add(Me.txtPesosNoAprobados)
        Me.Controls.Add(Me.txtCantNoAprobados)
        Me.Controls.Add(Me.txtPesosAprobados)
        Me.Controls.Add(Me.txtCantAprobados)
        Me.Controls.Add(Me.chkRecargas)
        Me.Controls.Add(Me.chkNuevos)
        Me.Controls.Add(Me.btnCalcular)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.mc)
        Me.Name = "frmTazaCierrePresupuestos"
        Me.Text = "Taza de Cierre"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents mc As System.Windows.Forms.MonthCalendar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnCalcular As System.Windows.Forms.Button
    Friend WithEvents chkNuevos As System.Windows.Forms.RadioButton
    Friend WithEvents chkRecargas As System.Windows.Forms.RadioButton
    Friend WithEvents txtCantAprobados As System.Windows.Forms.TextBox
    Friend WithEvents txtPesosAprobados As System.Windows.Forms.TextBox
    Friend WithEvents txtCantNoAprobados As System.Windows.Forms.TextBox
    Friend WithEvents txtPesosNoAprobados As System.Windows.Forms.TextBox
    Friend WithEvents txtCantTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtPesosTotal As System.Windows.Forms.TextBox
    Friend WithEvents lblCant As System.Windows.Forms.Label
    Friend WithEvents lblPesos As System.Windows.Forms.Label
End Class
