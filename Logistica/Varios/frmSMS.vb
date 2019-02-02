Public Class frmSMS
    Private Sub frmSMS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ArmarNumero()
    End Sub
    Private Sub btnEnviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnviar.Click
        Dim oSms As New Sms

        If Not ArmarNumero() Then
            MessageBox.Show("El número celular no es válido", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtNumero.Focus()
            Exit Sub
        End If
        If txtTexto.Text.Length = 0 Then
            MessageBox.Show("Escriba el texto a enviar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtTexto.Focus()
            Exit Sub
        End If

        oSms.Nuevo()
        oSms.Tos = lblTos.Text
        oSms.Texto = txtTexto.Text
        oSms.Test = chkTest.Checked
        If txtID.Text.Trim.Length > 0 Then oSms.Id = txtID.Text.Trim

        Try
            oSms.Enviar()
            MessageBox.Show(oSms.Respuesta, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            txtArea.Text = "11"
            txtNumero.Clear()
            txtID.Clear()
            txtTexto.Clear()
            ArmarNumero()

            txtNumero.Focus()

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim i As Integer
        Dim oSms As New Sms
        Dim txt As String

        Try
            i = oSms.ObtenerEnviados

            txt = i.ToString & " mensaje(s) enviado(s)"

        Catch ex As Exception
            txt = ex.Message

        End Try

        MessageBox.Show(txt, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub txtArea_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtArea.TextChanged
        ArmarNumero()
    End Sub
    Private Sub txtNumero_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumero.TextChanged
        ArmarNumero()
    End Sub
    Private Function ArmarNumero() As Boolean
        Dim n1, n2 As String
        Dim i As Integer
        Dim n As String
        Dim flg As Boolean = True

        n1 = ""
        For i = 0 To txtArea.Text.Length - 1
            n = txtArea.Text.Substring(i, 1)
            If IsNumeric(n) Then n1 &= n
        Next
        n2 = ""
        For i = 0 To txtNumero.Text.Length - 1
            n = txtNumero.Text.Substring(i, 1)
            If IsNumeric(n) Then n2 &= n
        Next

        If n1 = "" Or n1.StartsWith("0") Then flg = False
        If n2 = "" Or n2.StartsWith("15") Then flg = False
        If n1.Length + n2.Length <> 10 Then flg = False

        If flg Then
            lblTos.Text = n1 & n2
        Else
            lblTos.Text = "Número celular no válido"
        End If

        Return flg

    End Function

End Class