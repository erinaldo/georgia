<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmABMPuestos
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
        Me.btnAceptar = New System.Windows.Forms.Button
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.txtNro = New System.Windows.Forms.TextBox
        Me.txtUbicacion = New System.Windows.Forms.TextBox
        Me.txtOrden = New System.Windows.Forms.TextBox
        Me.cboAgente = New System.Windows.Forms.ComboBox
        Me.cboCapacidad = New System.Windows.Forms.ComboBox
        Me.panEquipo = New System.Windows.Forms.Panel
        Label1 = New System.Windows.Forms.Label
        Label2 = New System.Windows.Forms.Label
        Label3 = New System.Windows.Forms.Label
        Label4 = New System.Windows.Forms.Label
        Label5 = New System.Windows.Forms.Label
        Me.panEquipo.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(12, 9)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(27, 13)
        Label1.TabIndex = 0
        Label1.Text = "Nro:"
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Location = New System.Drawing.Point(70, 9)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(58, 13)
        Label2.TabIndex = 2
        Label2.Text = "Ubicación:"
        '
        'Label3
        '
        Label3.AutoSize = True
        Label3.Location = New System.Drawing.Point(297, 9)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(39, 13)
        Label3.TabIndex = 4
        Label3.Text = "Orden:"
        '
        'Label4
        '
        Label4.AutoSize = True
        Label4.Location = New System.Drawing.Point(3, 9)
        Label4.Name = "Label4"
        Label4.Size = New System.Drawing.Size(44, 13)
        Label4.TabIndex = 6
        Label4.Text = "Agente:"
        '
        'Label5
        '
        Label5.AutoSize = True
        Label5.Location = New System.Drawing.Point(178, 9)
        Label5.Name = "Label5"
        Label5.Size = New System.Drawing.Size(61, 13)
        Label5.TabIndex = 8
        Label5.Text = "Capacidad:"
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnAceptar.Location = New System.Drawing.Point(358, 79)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 12
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Location = New System.Drawing.Point(358, 108)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 13
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'txtNro
        '
        Me.txtNro.Location = New System.Drawing.Point(12, 25)
        Me.txtNro.Name = "txtNro"
        Me.txtNro.Size = New System.Drawing.Size(52, 20)
        Me.txtNro.TabIndex = 1
        '
        'txtUbicacion
        '
        Me.txtUbicacion.Location = New System.Drawing.Point(70, 25)
        Me.txtUbicacion.Name = "txtUbicacion"
        Me.txtUbicacion.Size = New System.Drawing.Size(222, 20)
        Me.txtUbicacion.TabIndex = 3
        '
        'txtOrden
        '
        Me.txtOrden.Location = New System.Drawing.Point(300, 25)
        Me.txtOrden.Name = "txtOrden"
        Me.txtOrden.Size = New System.Drawing.Size(52, 20)
        Me.txtOrden.TabIndex = 5
        '
        'cboAgente
        '
        Me.cboAgente.FormattingEnabled = True
        Me.cboAgente.Location = New System.Drawing.Point(3, 25)
        Me.cboAgente.Name = "cboAgente"
        Me.cboAgente.Size = New System.Drawing.Size(172, 21)
        Me.cboAgente.TabIndex = 7
        '
        'cboCapacidad
        '
        Me.cboCapacidad.FormattingEnabled = True
        Me.cboCapacidad.Location = New System.Drawing.Point(181, 25)
        Me.cboCapacidad.Name = "cboCapacidad"
        Me.cboCapacidad.Size = New System.Drawing.Size(121, 21)
        Me.cboCapacidad.TabIndex = 9
        '
        'panEquipo
        '
        Me.panEquipo.Controls.Add(Me.cboAgente)
        Me.panEquipo.Controls.Add(Me.cboCapacidad)
        Me.panEquipo.Controls.Add(Label4)
        Me.panEquipo.Controls.Add(Label5)
        Me.panEquipo.Location = New System.Drawing.Point(15, 51)
        Me.panEquipo.Name = "panEquipo"
        Me.panEquipo.Size = New System.Drawing.Size(337, 66)
        Me.panEquipo.TabIndex = 14
        '
        'frmABMPuestos
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(450, 143)
        Me.Controls.Add(Me.panEquipo)
        Me.Controls.Add(Me.txtOrden)
        Me.Controls.Add(Label3)
        Me.Controls.Add(Me.txtUbicacion)
        Me.Controls.Add(Me.txtNro)
        Me.Controls.Add(Label2)
        Me.Controls.Add(Label1)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmABMPuestos"
        Me.Text = "Puesto Extintor"
        Me.panEquipo.ResumeLayout(False)
        Me.panEquipo.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents txtNro As System.Windows.Forms.TextBox
    Friend WithEvents txtUbicacion As System.Windows.Forms.TextBox
    Friend WithEvents txtOrden As System.Windows.Forms.TextBox
    Friend WithEvents cboAgente As System.Windows.Forms.ComboBox
    Friend WithEvents cboCapacidad As System.Windows.Forms.ComboBox
    Friend WithEvents panEquipo As System.Windows.Forms.Panel
End Class
