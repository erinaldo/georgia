<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRetiros
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
        Me.mcal = New System.Windows.Forms.MonthCalendar
        Me.btnGrabar = New System.Windows.Forms.Button
        Me.txtExtintores = New System.Windows.Forms.MaskedTextBox
        Me.txtMangueras = New System.Windows.Forms.MaskedTextBox
        Label1 = New System.Windows.Forms.Label
        Label2 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'mcal
        '
        Me.mcal.Location = New System.Drawing.Point(4, 6)
        Me.mcal.MaxSelectionCount = 1
        Me.mcal.Name = "mcal"
        Me.mcal.TabIndex = 0
        '
        'btnGrabar
        '
        Me.btnGrabar.Location = New System.Drawing.Point(243, 146)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(75, 23)
        Me.btnGrabar.TabIndex = 5
        Me.btnGrabar.Text = "Grabar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'txtExtintores
        '
        Me.txtExtintores.Location = New System.Drawing.Point(227, 34)
        Me.txtExtintores.Mask = "99999"
        Me.txtExtintores.Name = "txtExtintores"
        Me.txtExtintores.ReadOnly = True
        Me.txtExtintores.Size = New System.Drawing.Size(100, 20)
        Me.txtExtintores.TabIndex = 2
        Me.txtExtintores.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtExtintores.ValidatingType = GetType(Integer)
        '
        'txtMangueras
        '
        Me.txtMangueras.Location = New System.Drawing.Point(227, 85)
        Me.txtMangueras.Mask = "99999"
        Me.txtMangueras.Name = "txtMangueras"
        Me.txtMangueras.ReadOnly = True
        Me.txtMangueras.Size = New System.Drawing.Size(100, 20)
        Me.txtMangueras.TabIndex = 4
        Me.txtMangueras.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtMangueras.ValidatingType = GetType(Integer)
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(227, 13)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(53, 13)
        Label1.TabIndex = 1
        Label1.Text = "Extintores"
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Location = New System.Drawing.Point(224, 69)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(60, 13)
        Label2.TabIndex = 3
        Label2.Text = "Mangueras"
        '
        'frmRetiros
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(384, 188)
        Me.Controls.Add(Label2)
        Me.Controls.Add(Label1)
        Me.Controls.Add(Me.txtMangueras)
        Me.Controls.Add(Me.txtExtintores)
        Me.Controls.Add(Me.btnGrabar)
        Me.Controls.Add(Me.mcal)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRetiros"
        Me.Text = "Retiros"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents mcal As System.Windows.Forms.MonthCalendar
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents txtExtintores As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtMangueras As System.Windows.Forms.MaskedTextBox
End Class
