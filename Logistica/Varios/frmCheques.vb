Imports System.IO
Imports System.Drawing

Public Class frmCheques

    Const PATH As String = "Z:\CHEQUES\"

    Private FrontFileOld As String
    Private BackFileOld As String
    Private FrontFileNew As String
    Private BackFileNew As String

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCargar.Click
        Dim Folder As New DirectoryInfo(PATH)

        btnCargar.Enabled = False

        ListBox1.Items.Clear()

        Folder.GetFiles()

        For Each file As FileInfo In Folder.GetFiles("??????????????_Front.jpg")
            ListBox1.Items.Add(file.Name)
        Next

        MessageBox.Show(ListBox1.Items.Count & " cheque(s) cargados", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

        btnCargar.Enabled = True

    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        Dim Flg As Boolean = True
        Dim i As Integer = 0
        Dim n As Long

        If ListBox1.SelectedItems.Count = 0 Then
            PictureBox1.Image = Nothing
            Flg = False
        Else
            txtFile.Text = ListBox1.SelectedItems(0).ToString

            FrontFileOld = txtFile.Text
            BackFileOld = txtFile.Text
            BackFileOld = BackFileOld.Replace("_Front", "_Back")
        End If

        If Flg AndAlso Not File.Exists(PATH & FrontFileOld) Then
            Flg = False
            MessageBox.Show("No se encontro el archivo: " & FrontFileOld, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If


        If Not File.Exists(PATH & BackFileOld) Then
            n = CLng(Strings.Left(BackFileOld, 14))
            n += 1
            BackFileOld = n.ToString & "_Back.jpg"

            If Not File.Exists(PATH & BackFileOld) Then
                File.Delete(PATH & FrontFileOld)

                Flg = False

            End If

        End If

        If Flg Then
            Dim fs = New System.IO.FileStream(PATH & FrontFileOld, IO.FileMode.Open, IO.FileAccess.Read)
            PictureBox1.Image = System.Drawing.Image.FromStream(fs)
            fs.Close()
            fs.Dispose()
            fs = Nothing
        End If

        btnCargar.Enabled = Flg
        txtBco.Enabled = Flg
        txtCta.Enabled = Flg
        txtNro.Enabled = Flg
        txtSuc.Enabled = Flg
        txtZip.Enabled = Flg
        txtFile.Enabled = Flg

        txtBco.Focus()

    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click

        If Not Validar() Then Exit Sub

        txtBco.Text = Strings.Right("00" & txtBco.Text, 3)
        txtSuc.Text = Strings.Right("00" & txtSuc.Text, 3)
        txtZip.Text = Strings.Right("000" & txtZip.Text, 4)
        txtNro.Text = Strings.Right("0000000" & txtNro.Text, 8)
        txtCta.Text = Strings.Right("0000000000" & txtCta.Text, 11)

        FrontFileNew = txtBco.Text & txtSuc.Text & txtZip.Text & txtNro.Text & txtCta.Text & "_Front.jpg"
        BackFileNew = txtBco.Text & txtSuc.Text & txtZip.Text & txtNro.Text & txtCta.Text & "_Back.jpg"

        txtFile2.Text = FrontFileNew & " / " & BackFileNew

        If Not File.Exists(PATH & FrontFileNew) Then
            My.Computer.FileSystem.RenameFile(PATH & FrontFileOld, FrontFileNew)
        Else
            File.Delete(PATH & FrontFileOld)
        End If

        If Not File.Exists(PATH & BackFileNew) Then
            My.Computer.FileSystem.RenameFile(PATH & BackFileOld, BackFileNew)
        Else
            File.Delete(PATH & BackFileOld)
        End If

        MessageBox.Show("Modificación correcta", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

        With ListBox1
            .Items.RemoveAt(ListBox1.SelectedIndex)
            If .Items.Count > 0 Then .SelectedIndex = 0
        End With

    End Sub

    Public Function Validar() As Boolean

        If txtBco.Text.Length = 0 Then Return False
        If txtCta.Text.Length = 0 Then Return False
        If txtNro.Text.Length = 0 Then Return False
        If txtSuc.Text.Length = 0 Then Return False
        If txtZip.Text.Length = 0 Then Return False

        Return True

    End Function

End Class