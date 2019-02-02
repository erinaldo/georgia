Imports System.IO

Public Class frmArcibaNc

    Private Sub btnAbrir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbrir.Click

        Me.UseWaitCursor = True

        OpenFileDialog1.Filter = "Documentos de texto (*.txt*)|*.txt"

        If OpenFileDialog1.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub

        lblArchivo.Text = OpenFileDialog1.FileName

        Me.UseWaitCursor = False

    End Sub
    Private Sub btnCorregir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCorregir.Click
        Dim l As String
        Dim campos(4) As String
        Dim ArchivoCorregido As String = ""
        Dim sr As StreamReader
        Dim sw As StreamWriter

        If lblArchivo.Text = "" Then Exit Sub

        Try
            sr = New StreamReader(lblArchivo.Text)
            l = sr.ReadLine

            Do Until sr.EndOfStream
                l = l.Replace(",", ".")

                campos(0) = l.Substring(0, 23) 'base
                campos(1) = l.Substring(23, 16)
                campos(2) = l.Substring(39, 59)
                Dim xx = l.Substring(98, 16) 'impuesto
                campos(4) = l.Substring(114, 5) 'alicuota


                Dim base As Double = CDbl(campos(1))
                Dim alicuota As Double = CDbl(campos(4))
                Dim impuesto As Double = Math.Round(base * alicuota / 100, 2)

                campos(3) = Strings.FormatNumber(impuesto, 2, , , TriState.False)
                campos(3) = Strings.Right("0000000000000" & campos(3), 16)

                Select Case Len(campos(3))
                    Case 13
                        campos(3) &= ".00"
                    Case 15
                        campos(3) &= "0"
                End Select

                For i = 0 To 4
                    ArchivoCorregido &= campos(i)
                Next
                ArchivoCorregido &= vbCrLf

                l = sr.ReadLine

            Loop

            sr.Close()
            sr.Dispose()

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
        

        Try
            sw = New StreamWriter("lblArchivo.Text")
            ArchivoCorregido = ArchivoCorregido.Replace(".", ",")
            sw.Write(ArchivoCorregido)
            sw.Close()
            sw.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

End Class