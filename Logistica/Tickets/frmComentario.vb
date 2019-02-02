Public Class frmComentario

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Public ReadOnly Property Comentario() As String
        Get
            Dim txt As String = txtComentario.Text

            If txt.Trim = "" Then txt = " "

            Return txt

        End Get
    End Property

End Class