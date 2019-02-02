Public Class frmfecha
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
    Private Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Public Property Fecha() As Date
        Get
            Return mcfecha.SelectionRange.Start
        End Get
        Set(ByVal value As Date)
            mcfecha.SetDate(value)
        End Set
    End Property

End Class