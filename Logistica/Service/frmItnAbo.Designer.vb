<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmItnAbo
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
        Me.btn = New System.Windows.Forms.Button
        Me.dtp = New System.Windows.Forms.DateTimePicker
        Me.pbCon = New System.Windows.Forms.ProgressBar
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtAlertas = New System.Windows.Forms.TextBox
        Me.lstItn = New System.Windows.Forms.ListBox
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn
        '
        Me.btn.Location = New System.Drawing.Point(107, 13)
        Me.btn.Name = "btn"
        Me.btn.Size = New System.Drawing.Size(75, 23)
        Me.btn.TabIndex = 0
        Me.btn.Text = "Procesar"
        Me.btn.UseVisualStyleBackColor = True
        '
        'dtp
        '
        Me.dtp.CustomFormat = "MMM/yyyy"
        Me.dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp.Location = New System.Drawing.Point(12, 12)
        Me.dtp.Name = "dtp"
        Me.dtp.Size = New System.Drawing.Size(89, 20)
        Me.dtp.TabIndex = 1
        '
        'pbCon
        '
        Me.pbCon.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbCon.Location = New System.Drawing.Point(188, 13)
        Me.pbCon.Name = "pbCon"
        Me.pbCon.Size = New System.Drawing.Size(316, 23)
        Me.pbCon.TabIndex = 2
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.txtAlertas)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 42)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(492, 406)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Alertas"
        '
        'txtAlertas
        '
        Me.txtAlertas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtAlertas.Location = New System.Drawing.Point(3, 16)
        Me.txtAlertas.Multiline = True
        Me.txtAlertas.Name = "txtAlertas"
        Me.txtAlertas.ReadOnly = True
        Me.txtAlertas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtAlertas.Size = New System.Drawing.Size(486, 387)
        Me.txtAlertas.TabIndex = 0
        '
        'lstItn
        '
        Me.lstItn.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstItn.FormattingEnabled = True
        Me.lstItn.Location = New System.Drawing.Point(507, 13)
        Me.lstItn.Name = "lstItn"
        Me.lstItn.Size = New System.Drawing.Size(248, 433)
        Me.lstItn.TabIndex = 5
        '
        'frmItnAbo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(760, 452)
        Me.Controls.Add(Me.lstItn)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btn)
        Me.Controls.Add(Me.dtp)
        Me.Controls.Add(Me.pbCon)
        Me.Name = "frmItnAbo"
        Me.Text = "Generar Intervenciones Abonados"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn As System.Windows.Forms.Button
    Friend WithEvents dtp As System.Windows.Forms.DateTimePicker
    Friend WithEvents pbCon As System.Windows.Forms.ProgressBar
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtAlertas As System.Windows.Forms.TextBox
    Friend WithEvents lstItn As System.Windows.Forms.ListBox
End Class
