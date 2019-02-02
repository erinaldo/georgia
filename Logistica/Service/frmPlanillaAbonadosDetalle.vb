Public Class frmPlanillaAbonadosDetalle

    Public Sub New(ByVal dv As DataView)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        dgv.DataSource = dv

    End Sub

    Private Sub dgv_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellContentClick

    End Sub

    Private Sub dgv_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv.SelectionChanged
        Label1.Text = "Seleccionados: " & dgv.SelectedCells.Count.ToString
    End Sub
End Class