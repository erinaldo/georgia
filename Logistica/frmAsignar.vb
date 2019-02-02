Imports System.Data.OracleClient

Public Class frmAsignar
    Private da As OracleDataAdapter
    Private dt As New DataTable

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Dim Sql As String

        Sql = "SELECT DISTINCT xsector_0 AS cod, xsector_0 AS des FROM xtickets ORDER BY xsector_0"
        da = New OracleDataAdapter(Sql, cn)
        da.Fill(dt)

        Sql = "SELECT repnum_0 AS cod, repnum_0 || ' - ' || repnam_0 AS des "
        Sql &= "FROM salesrep "
        Sql &= "WHERE repnum_0 NOT LIKE  'C%' "
        Sql &= "ORDER BY repnum_0"
        da = New OracleDataAdapter(Sql, cn)
        da.Fill(dt)

        With cboAsignar
            .DataSource = dt
            .DisplayMember = "des"
            .ValueMember = "cod"
        End With

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

End Class