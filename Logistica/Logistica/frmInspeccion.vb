Public Class frmInspeccion

    Public Sub New(ByVal id As Integer)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Dim c As New Sigex.Control
        Dim dt As DataTable

        dt = c.VerControl(id)

        dgv.DataSource = dt

    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
End Class