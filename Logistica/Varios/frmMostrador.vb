Imports System.Data.OracleClient

Public Class frmMostrador
    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        AddHandler dgv.RowPostPaint, AddressOf NumeracionGrillas

    End Sub
    Private Sub CalcularVentas()
        Dim da As OracleDataAdapter
        Dim dt As DataTable
        Dim Sql As String
        Dim dr As DataRow
        Dim Ventas As Double

        Sql = "SELECT num_0, bpcnum_0, bpcnam_0, amtati_0 * sns_0 AS importe, sih.creusr_0 "
        Sql &= "FROM sinvoice sih INNER JOIN bpcustomer bpc ON (sih.bpr_0 = bpc.bpcnum_0) "
        Sql &= "WHERE accdat_0 = to_date(:accdat_0, 'dd/mm/yyyy') AND sih.creusr_0 = :creusr_0 "
        Sql &= "ORDER BY num_0"

        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("accdat_0", OracleType.VarChar).Value = dtp.Value.ToString("dd/MM/yyyy")
        da.SelectCommand.Parameters.Add("creusr_0", OracleType.VarChar).Value = "RECE" 'Usr.Codigo

        If dgv.DataSource Is Nothing Then
            dt = New DataTable
        Else
            dt = CType(dgv.DataSource, DataTable)
            dt.Clear()
        End If

        da.Fill(dt)

        Ventas = 0
        For Each dr In dt.Rows
            Ventas += CDbl(dr("importe"))
        Next
        TextBox1.Text = Ventas.ToString("N2")

        If dgv.DataSource Is Nothing Then
            colComprobante.DataPropertyName = "num_0"
            colCodigo.DataPropertyName = "bpcnum_0"
            colCliente.DataPropertyName = "bpcnam_0"
            colImporte.DataPropertyName = "importe"
            colUsuario.DataPropertyName = "creusr_0"
            dgv.DataSource = dt
        End If

        da.Dispose()

    End Sub
    Private Sub btnVer_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVer.Click
        CalcularVentas()
    End Sub

End Class