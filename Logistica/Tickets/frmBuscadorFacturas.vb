Imports System.Data.OracleClient

Public Class frmBuscadorFacturas
    Private da As OracleDataAdapter
    Private dt As New DataTable
    Public Seleccionado As String = ""

    Public Sub New(ByVal Cliente As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Adaptadores()
        ConsultarEntregas(Cliente)
    End Sub
    Private Sub Adaptadores()
        Dim Sql As String

        Sql = "SELECT sih.accdat_0, sih.num_0, sih.amtati_0, siv.sihori_0, siv.sihorinum_0 "
        Sql &= "FROM sinvoice sih  INNER JOIN "
        Sql &= "     sinvoicev siv ON (sih.num_0 = siv.num_0) "
        Sql &= "WHERE sih.bpr_0 = :bpr and "
        Sql &= "      sih.credat_0 >= :credat "
        Sql &= "ORDER BY sih.credat_0 DESC"
        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("bpr", OracleType.VarChar)
        da.SelectCommand.Parameters.Add("credat", OracleType.DateTime)

    End Sub
    Private Sub ConsultarEntregas(ByVal Cliente As String)
        dt.Clear()
        da.SelectCommand.Parameters("bpr").Value = Cliente
        da.SelectCommand.Parameters("credat").Value = Date.Today.AddYears(-1)
        da.Fill(dt)

        If dgv.DataSource Is Nothing Then
            Dim mnu As New MenuLocal(cn)
            mnu.AbrirMenu(413, True)

            colFecha.DataPropertyName = "accdat_0"
            colFactura.DataPropertyName = "num_0"
            colImporte.DataPropertyName = "amtati_0"

            mnu.Enlazar(colOrigen)
            colOrigen.DataPropertyName = "sihori_0"

            colOrigenNumero.DataPropertyName = "sihorinum_0"
            dgv.DataSource = dt
        End If

    End Sub
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        If dgv.SelectedRows.Count = 1 Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Seleccionado = dgv.SelectedRows(0).Cells("colFactura").Value.ToString
            Me.Close()
        End If

    End Sub
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

End Class