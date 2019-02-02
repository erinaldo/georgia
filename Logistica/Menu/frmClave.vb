Imports System.Data.OracleClient

Public Class frmClave
    'EVENTOS
    Private Function ValidarCampos() As Boolean
        'Valido que el campo Nueva contraseña esté completo
        If txtNueva.Text.Trim = "" Then
            MessageBox.Show("Ingrese la nueva contraseña", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Function
        End If

        If txtNueva2.Text.Trim = "" Then
            MessageBox.Show("Repita la nueva contraseña", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Function
        End If

        'Valido que las contraseñas sean iguales
        If txtNueva.Text <> txtNueva2.Text Then
            MessageBox.Show("Las contraseñas ingresadas son distintas", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Function
        End If

        If txtAnterior.Text.Trim = "" Then txtAnterior.Text = " "

    End Function
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        ValidarCampos()

        If USR.Clave.Trim = txtAnterior.Text.Trim Then
            'Valido que la clave cumpla la politica de seguridad
            If USR.ValidarClave(txtNueva.Text) Then
                USR.Clave = txtNueva.Text
                USR.Grabar()

                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()

            Else
                MessageBox.Show("La contraseña no puede estar en blanco, ser parte de su nombre o nombre de usuario.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)

            End If

        Else
            MessageBox.Show("La contraseña anterior no es correcta", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub

        End If

    End Sub

End Class