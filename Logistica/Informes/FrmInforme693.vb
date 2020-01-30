Imports System.IO

Public Class FrmInforme693
    Dim bpc As New Cliente(cn)
    Dim Suc As New Sucursal(cn)

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If verificar() Then Exit Sub

        Dim openFileDialog1 As New OpenFileDialog()
        openFileDialog1.InitialDirectory = "c:\"
        openFileDialog1.Filter = "pdf files (*.pdf)|*.pdf|All files (*.*)|*.*"
        openFileDialog1.FilterIndex = 2
        openFileDialog1.RestoreDirectory = True
        If Cliente.Text.Trim <> "" Then
            If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                Dim destino As String = "\\srv\Z\Informes639\" & Cliente.Text.Trim & "-" & Sucursal.Text.Trim & "-" & dtp.Value.Year & "-" & dtp.Value.Month & "-" & dtp.Value.Day & ".pdf"
                Dim nombre As String = Cliente.Text.Trim & "-" & Sucursal.Text.Trim & "-" & dtp.Value.Year & "-" & dtp.Value.Month & "-" & dtp.Value.Day & ".pdf"
                Try
                    File.Copy(openFileDialog1.FileName, destino, True)
                    MsgBox("Se subio correctamente")
                    enviar_mail(nombre)
                Catch ex As Exception
                    MsgBox("No se pueden subir dos archivos con la misma fecha para mismo cliente y sucursal")
                End Try
            End If
        Else
            Exit Sub
        End If

    End Sub
    Private Function verificar() As Boolean
        Dim destino As String = Cliente.Text.Trim & "-" & Sucursal.Text.Trim & "-" & dtp.Value.Year & "-" & dtp.Value.Month & "-" & dtp.Value.Day & ".pdf"

        Dim folder As New DirectoryInfo("\\srv\Z\Informes639\")
        For Each file As FileInfo In folder.GetFiles(destino)
            MsgBox("No se pueden subir dos archivos con la misma fecha para mismo cliente y sucursal")
            Return True
        Next
        Return False
    End Function
    Private Sub enviar_mail(ByVal nombre As String)
        Dim Fecha As Date = Today
        Dim eMail As New CorreoElectronico
        Dim bpc As New Cliente(cn)
        Dim rep As New Vendedor(cn)
        With eMail
            Dim folder As New DirectoryInfo("\\srv\Z\Informes639\")
            For Each file As FileInfo In folder.GetFiles(nombre)
                bpc.Abrir(file.Name.Substring(0, 6))
                rep.Abrir(bpc.Representante(0))
                .Nuevo()
                .Remitente("no-responder@georgia.com.ar", "Sistema Automático")
                .Asunto = "Nuevo informe 639 Cliente: " & bpc.Codigo & " - " & bpc.Nombre
                .AgregarDestinatario(rep.Mail)
                '.AgregarDestinatario("mbarcudes@matafuegosgeorgia.com")
                '.AgregarDestinatario("ioeyen@matafuegosgeorgia.com")
                .Cuerpo = "Recuerde que este informe no fue enviado al cliente, solamente al vendedor para que evalúe la mejor forma de hacérselo llegar a su cliente"
                .Cuerpo &= " de la sucursal : " & Sucursal.Text & "-" & textoSucursal.Text
                '.Cuerpo = rep.Mail
                .AdjuntarArchivo(folder.ToString & file.ToString)
                .Enviar(True)
            Next
        End With
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ListBox1.Items.Clear()
        Dim folder As New DirectoryInfo("\\srv\Z\Informes639\")
        If Cliente.Text.Trim = "" Then
            MsgBox("Debe ingresar un cliente")
        ElseIf Sucursal.Text.Trim = "" Then
            For Each file As FileInfo In folder.GetFiles(Cliente.Text.Trim & "*")
                ListBox1.Items.Add(file.Name)
            Next
        Else
            For Each file As FileInfo In folder.GetFiles(Cliente.Text.Trim & "-" & Sucursal.Text.Trim & "*")
                ListBox1.Items.Add(file.Name)
            Next
        End If

    End Sub
    Private Sub Cliente_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cliente.Validated
        If bpc.Abrir(Cliente.Text.Trim.ToString) Then
            TextoCliente.Text = bpc.Nombre
        Else
            MsgBox("Cliente no encontrado")
            Cliente.Focus()
        End If
        ListBox1.Items.Clear()
    End Sub

    Private Sub Sucursal_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Sucursal.Validated
        If Suc.Abrir(Cliente.Text.Trim.ToString, Sucursal.Text.Trim) Then
            textoSucursal.Text = Suc.Direccion
        Else
            MsgBox("Sucursal no encontrada")
            ' Sucursal.Focus()
        End If

    End Sub

    Private Sub ListBox1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox1.DoubleClick
        Try
            Process.Start("\\srv\Z\Informes639\" & ListBox1.SelectedItem.ToString())
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        ListBox1.Items.Clear()
        Cliente.Text = ""
        Sucursal.Text = ""
        TextoCliente.Text = ""
        textoSucursal.Text = ""
    End Sub

    Private Sub FrmInforme693_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Button1.Enabled = usr.Permiso.AccesoSecundario(82, "A")

    End Sub

End Class