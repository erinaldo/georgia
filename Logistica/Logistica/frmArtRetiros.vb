Imports System.Data.OracleClient

Public Class frmArtRetiros

    Dim da As New OracleDataAdapter
    Dim dt As New DataTable

    'EVENTOS
    Private Sub frmArtRetiros_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Sql As String

        Sql = "SELECT itmref_0, itmref_0 || ' | ' || itmdes1_0 AS texto FROM itmmaster WHERE tclcod_0 IN ('45', '50') ORDER BY itmref_0"
        da.SelectCommand = New OracleCommand(Sql, cn)

        Try
            da.Fill(dt)

            With lstCod
                .DataSource = dt
                .DisplayMember = "texto"
                .ValueMember = "itmref_0"
                .Focus()
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Try

    End Sub
    Private Sub frmArtRetiros_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        da.Dispose()
    End Sub
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

End Class