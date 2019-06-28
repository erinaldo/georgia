Imports System.Data.SqlClient

Public Class frmABMRelevadores
    Private Const db As String = "Server=SIGEX\SQLEXPRESS;Database=sigexevolution;User Id=sa;Password=Georgia2017;"

    Private Sql As String
    Private da As SqlDataAdapter
    Private cn As New SqlConnection(db)
    Private dt As New DataTable

    Private Sub frmRelevadores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Sql = "SELECT * FROM usuarios"
        da = New SqlDataAdapter(Sql, cn)
        da.InsertCommand = New SqlCommandBuilder(da).GetInsertCommand
        da.UpdateCommand = New SqlCommandBuilder(da).GetUpdateCommand
        da.DeleteCommand = New SqlCommandBuilder(da).GetDeleteCommand

        da.Fill(dt)
        dgv.DataSource = dt

    End Sub

    Private Sub btnRegistrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegistrar.Click
        Try
            da.Update(dt)

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class