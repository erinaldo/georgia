Imports System.Data.OracleClient

Public Class frmSelectorArticulos

    Private dt As New DataTable
    Private da As OracleDataAdapter

    Public Seleccion As String = ""

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Dim Sql As String

        Sql = "SELECT itmref_0, itmref_0 || ' - ' || itmdes1_0 AS display "
        Sql &= "FROM itmmaster "
        Sql &= "WHERE (itmref_0 like :p1 OR itmdes1_0 like :p1) AND "
        Sql &= "      itmsta_0 = 1 "
        Sql &= "ORDER BY itmref_0"

        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("p1", OracleType.VarChar)
    End Sub

    Private Sub txtBuscar_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBuscar.KeyUp
        Select Case e.KeyCode
            Case Keys.Escape
                Cerrar()
            Case Keys.Enter
                Buscar()
        End Select

    End Sub

    Private Sub Buscar()

        With txtBuscar
            .Text = .Text.Trim.ToUpper
            If .Text.Length = 0 Then Exit Sub

            da.SelectCommand.Parameters("p1").Value = "%" & .Text & "%"

            Try
                dt.Clear()
                da.Fill(dt)

                If lst.DataSource Is Nothing Then
                    lst.DisplayMember = "display"
                    lst.ValueMember = "itmref_0"
                    lst.DataSource = dt
                End If

                If dt.Rows.Count > 0 Then
                    lst.Focus()
                Else
                    txtBuscar.Focus()
                End If

                txtBuscar.Clear()

            Catch ex As Exception
            End Try
        End With

    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Buscar()
    End Sub
    Private Sub btnSeleccionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSeleccionar.Click
        Seleccionar()
    End Sub
    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Seleccionar()
        If lst.SelectedItems.Count = 0 Then Exit Sub

        Dim dr As DataRow

        dr = CType(lst.SelectedItem, DataRowView).Row

        Seleccion = dr("itmref_0").ToString

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub

    Private Sub lst_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lst.KeyUp
        Select Case e.KeyCode
            Case Keys.Escape
                txtBuscar.Focus()
            Case Keys.Enter
                Seleccionar()
        End Select
    End Sub

    Private Sub Cerrar()
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

End Class