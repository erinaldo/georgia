Imports System.Collections
Imports System.IO
Imports System.Data.OracleClient

Public Class frmMailsMasivos

    Private oMail As New CorreoElectronico
    Private Plantilla As String

    Private CancelarEnvio As Boolean = False

    Private Sub btnDestinos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDestinos.Click
        Dim sr As StreamReader
        Dim Result As DialogResult

        With OpenFileDialog1
            .Filter = "Documentos de texto (*.txt*)|*.txt"
            Result = .ShowDialog

            If Result = Windows.Forms.DialogResult.OK Then
                lstMail.Items.Clear()

                Try
                    sr = New StreamReader(.FileName)

                    Do Until sr.EndOfStream
                        Dim linea As String
                        Dim mails() As String
                        Dim i As Integer

                        linea = sr.ReadLine
                        mails = Split(linea, ";")

                        For i = 0 To mails.Length - 1
                            If Not ExisteMail(mails(i)) Then
                                AgregarMail(mails(i))
                            End If
                        Next
                    Loop

                    sr.Close()

                Catch ex As Exception

                End Try
            End If
        End With

    End Sub
    Private Function ExisteMail(ByVal Mail As String) As Boolean
        Dim i As Integer

        i = lstMail.Items.IndexOf(Mail)

        Return (i > -1)

    End Function
    Private Sub AgregarMail(ByVal Mail As String)

        If oMail.ValidarMail(Mail) Then
            lstMail.Items.Add(Mail)
        End If

    End Sub

    Private Sub btnPlantilla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPlantilla.Click
        Dim sr As StreamReader

        With OpenFileDialog1
            .Filter = "Documento HTML (*.htm*)|*.htm"

            If .ShowDialog = Windows.Forms.DialogResult.OK Then

                Try
                    sr = New StreamReader(.FileName)
                    Plantilla = sr.ReadToEnd
                    Label4.Text = .FileName
                    Label4.Visible = True
                    sr.Close()

                Catch ex As Exception

                End Try
            End If
        End With

    End Sub

    Private Sub btnEnviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnviar.Click
        If Not ValidarCampos() Then Exit Sub
        EnviarMails()
    End Sub

    Private Sub EnviarMails()
        Dim i As Integer
        Dim Mail As String

        If Not ValidarCampos() Then Exit Sub
        CancelarEnvio = False

        With pb
            .Minimum = 0
            .Maximum = lstMail.Items.Count
            .Value = 0
        End With

        For i = 0 To lstMail.Items.Count - 1
            If CancelarEnvio Then Exit For

            Mail = lstMail.Items(i).ToString

            With oMail
                .Nuevo()
                .Remitente(txtDe.Text)
                .AgregarDestinatario(Mail, False)
                If txtResponder.Text.Trim.Length > 0 Then
                    If .ValidarMail(txtResponder.Text) Then
                        .ResponderA(txtResponder.Text)
                    End If
                End If
                .Asunto = txtAsunto.Text
                .EsHtml = True
                .Cuerpo = Plantilla
                Try
                    .Enviar()

                Catch ex As Exception
                    Dim s As String

                    s = ex.Message

                End Try

            End With

            pb.Value += 1

            Application.DoEvents()
            Application.DoEvents()

        Next
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        CancelarEnvio = True
    End Sub

    Private Sub btnTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTest.Click
        Dim Mail As String

        Do
            Mail = InputBox("Ingrese destinatario", Me.Text)

        Loop Until Mail = "" OrElse oMail.ValidarMail(Mail)

        If Mail = "" Then Exit Sub

        Try
            With oMail
                .Nuevo()
                .Remitente(txtDe.Text, "Georgia Seguridad contra Incendios")
                .AgregarDestinatario(Mail, False)
                .Asunto = txtAsunto.Text
                .EsHtml = True
                .Cuerpo = Plantilla
                .Enviar()
            End With

            MessageBox.Show("Test Enviado", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try


    End Sub

    Private Function ValidarCampos() As Boolean
        txtDe.Text = txtDe.Text.Trim
        txtAsunto.Text = txtAsunto.Text.Trim
        txtResponder.Text = txtResponder.Text.Trim


        'De
        If Not oMail.ValidarMail(txtDe.Text) Then
            MessageBox.Show("Él campo De es inválido", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False
        End If
        'Responder A
        If txtResponder.Text <> "" AndAlso Not oMail.ValidarMail(txtResponder.Text) Then
            MessageBox.Show("Él campo Response A es inválido", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False
        End If
        'Asunto
        If txtAsunto.Text = "" Then
            MessageBox.Show("Él campo Asunto es inválido", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False
        End If
        'Plantilla
        If Plantilla.Trim.Length = 0 Then
            MessageBox.Show("Debe cargar plantilla", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False
        End If

        Return True
    End Function

End Class