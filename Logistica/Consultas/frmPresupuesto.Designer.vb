<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPresupuestoAnual
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
        Me.btn_presupuesto = New System.Windows.Forms.Button
        Me.txtbox_presupuesto = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'btn_presupuesto
        '
        Me.btn_presupuesto.Location = New System.Drawing.Point(167, 22)
        Me.btn_presupuesto.Name = "btn_presupuesto"
        Me.btn_presupuesto.Size = New System.Drawing.Size(75, 23)
        Me.btn_presupuesto.TabIndex = 0
        Me.btn_presupuesto.Text = "buscar"
        Me.btn_presupuesto.UseVisualStyleBackColor = True
        '
        'txtbox_presupuesto
        '
        Me.txtbox_presupuesto.Location = New System.Drawing.Point(61, 25)
        Me.txtbox_presupuesto.Name = "txtbox_presupuesto"
        Me.txtbox_presupuesto.Size = New System.Drawing.Size(100, 20)
        Me.txtbox_presupuesto.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Numero"
        '
        'frmPresupuesto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(266, 57)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtbox_presupuesto)
        Me.Controls.Add(Me.btn_presupuesto)
        Me.Name = "frmPresupuesto"
        Me.Text = "Consulta de presupuesto"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_presupuesto As System.Windows.Forms.Button
    Friend WithEvents txtbox_presupuesto As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
