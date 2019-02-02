<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCarrito
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
        Me.txtCP = New System.Windows.Forms.TextBox
        Me.lstBarrios = New System.Windows.Forms.ListBox
        Me.mthFechas = New System.Windows.Forms.MonthCalendar
        Me.btnAceptar = New System.Windows.Forms.Button
        Me.btnZonas = New System.Windows.Forms.Button
        Me.txtCant = New System.Windows.Forms.TextBox
        Me.lblBarrio = New System.Windows.Forms.Label
        Label1 = New System.Windows.Forms.Label
        Label2 = New System.Windows.Forms.Label
        Label3 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(8, 12)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(122, 13)
        Label1.TabIndex = 1
        Label1.Text = "Código postal del cliente"
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Location = New System.Drawing.Point(8, 49)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(154, 13)
        Label2.TabIndex = 3
        Label2.Text = "Seleccionar el barrio del cliente"
        '
        'Label3
        '
        Label3.AutoSize = True
        Label3.Location = New System.Drawing.Point(340, 12)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(52, 13)
        Label3.TabIndex = 8
        Label3.Text = "Cantidad:"
        '
        'txtCP
        '
        Me.txtCP.Location = New System.Drawing.Point(168, 9)
        Me.txtCP.MaxLength = 4
        Me.txtCP.Name = "txtCP"
        Me.txtCP.Size = New System.Drawing.Size(57, 20)
        Me.txtCP.TabIndex = 0
        '
        'lstBarrios
        '
        Me.lstBarrios.FormattingEnabled = True
        Me.lstBarrios.Location = New System.Drawing.Point(8, 65)
        Me.lstBarrios.Name = "lstBarrios"
        Me.lstBarrios.Size = New System.Drawing.Size(213, 173)
        Me.lstBarrios.TabIndex = 2
        '
        'mthFechas
        '
        Me.mthFechas.Enabled = False
        Me.mthFechas.Location = New System.Drawing.Point(230, 65)
        Me.mthFechas.MaxSelectionCount = 1
        Me.mthFechas.Name = "mthFechas"
        Me.mthFechas.TabIndex = 4
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(230, 231)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(227, 37)
        Me.btnAceptar.TabIndex = 5
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnZonas
        '
        Me.btnZonas.Location = New System.Drawing.Point(8, 245)
        Me.btnZonas.Name = "btnZonas"
        Me.btnZonas.Size = New System.Drawing.Size(213, 23)
        Me.btnZonas.TabIndex = 6
        Me.btnZonas.Text = "El barrio no aparece en la lista"
        Me.btnZonas.UseVisualStyleBackColor = True
        '
        'txtCant
        '
        Me.txtCant.Location = New System.Drawing.Point(398, 9)
        Me.txtCant.MaxLength = 4
        Me.txtCant.Name = "txtCant"
        Me.txtCant.ReadOnly = True
        Me.txtCant.Size = New System.Drawing.Size(57, 20)
        Me.txtCant.TabIndex = 7
        '
        'lblBarrio
        '
        Me.lblBarrio.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblBarrio.Location = New System.Drawing.Point(230, 49)
        Me.lblBarrio.Name = "lblBarrio"
        Me.lblBarrio.Size = New System.Drawing.Size(227, 13)
        Me.lblBarrio.TabIndex = 9
        Me.lblBarrio.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmCarrito
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(467, 279)
        Me.Controls.Add(Me.lblBarrio)
        Me.Controls.Add(Label3)
        Me.Controls.Add(Me.txtCant)
        Me.Controls.Add(Me.btnZonas)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.mthFechas)
        Me.Controls.Add(Label2)
        Me.Controls.Add(Me.lstBarrios)
        Me.Controls.Add(Label1)
        Me.Controls.Add(Me.txtCP)
        Me.Name = "frmCarrito"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Agenda de Recorridos"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtCP As System.Windows.Forms.TextBox
    Friend WithEvents lstBarrios As System.Windows.Forms.ListBox
    Friend WithEvents mthFechas As System.Windows.Forms.MonthCalendar
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnZonas As System.Windows.Forms.Button
    Friend WithEvents txtCant As System.Windows.Forms.TextBox
    Friend WithEvents lblBarrio As System.Windows.Forms.Label
End Class
