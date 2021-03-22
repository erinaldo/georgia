Imports System.Data.OracleClient

Public Class frmLogin

    'EVENTOS
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        txtUser.Text = txtUser.Text.Trim()
        txtPass.Text = txtPass.Text.Trim()

        If txtUser.Text = "" Then
            MessageBox.Show("Ingrese el nombre de usuario", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtUser.Focus()
            Exit Sub
        End If

        'Aqui valido los datos
        If USR.IniciarSesion(txtUser.Text, txtPass.Text) Then

            'Valido si la clave cumple con la politica de seguridad
            If Not USR.ValidarClave Then
                Dim txt As String
                Dim f As New frmClave

                txt = "La contraseña no puede estar en blanco, ser parte de su nombre o nombre de usuario." & vbCrLf & vbCrLf
                txt &= "Para continuar, debe proteger su cuenta estableciendo una nueva contraseña."

                MessageBox.Show(txt, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)

                f.txtAnterior.Text = txtPass.Text
                f.txtAnterior.ReadOnly = True
                f.txtAnterior.TabStop = False

                f.ShowDialog(Me)

                If f.DialogResult = Windows.Forms.DialogResult.OK Then
                    txt = "La contraseña fue guardada." & vbCrLf & vbCrLf
                    txt &= "Debe iniciar sesión nuevamente usando su nueva contraseña."

                    txtPass.Clear()
                    txtPass.Focus()

                    MessageBox.Show(txt, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

                End If

                USR.CerrarSesion()

            Else
                'Guardo en el registro el usuario actual
                Registro.setDato("login", txtUser.Text.Trim)

                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()

            End If

        Else
            MessageBox.Show(USR.MensajeError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)

        End If

    End Sub

    Private Sub frmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Obtengo el ultimo usuario logeado
        txtUser.Text = Registro.getDato("login")
    End Sub
    
End Class