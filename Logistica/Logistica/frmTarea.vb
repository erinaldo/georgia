Public Class frmTarea

    Private Modificado As Boolean = False

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDireccion.GotFocus, txtHora.GotFocus, txtLocalidad.GotFocus, txtNombre.GotFocus
        CType(sender, TextBox).SelectAll()
    End Sub
    Private Sub txt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDireccion.LostFocus, txtHora.LostFocus, txtLocalidad.LostFocus, txtNombre.LostFocus
        Dim txt As TextBox = CType(sender, TextBox)
        txt.Text = txt.Text.ToUpper
    End Sub
    Private Sub txt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDireccion.TextChanged, txtHora.TextChanged, txtLocalidad.TextChanged, txtNombre.TextChanged
        Modificado = True
    End Sub
    Private Sub frmTarea_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            If Modificado AndAlso Me.DialogResult <> Windows.Forms.DialogResult.OK Then
                If MessageBox.Show("¿Confirma que desea salir? Perderá los cambios realizados", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                    e.Cancel = True
                End If
            End If
        End If
    End Sub
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        'Valido que la dirección esté completa
        If txtDireccion.Text.Trim = "" Then
            MessageBox.Show("Debe ingresar la dirección", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtDireccion.Focus()
            Exit Sub
        End If

        'Valido que la localidad esté completa
        If txtLocalidad.Text.Trim = "" Then
            MessageBox.Show("Debe ingresar la localidad", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtLocalidad.Focus()
            Exit Sub
        End If

        If txtHora.Text.Trim = "" Then txtHora.Text = " "
        If txtNombre.Text.Trim = "" Then txtNombre.Text = " "

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub

End Class