Imports System.Data.OracleClient

Public Class frmRastreo

    Private Sub txtCodigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigo.KeyPress
        Dim t As TextBox = CType(sender, TextBox)

        If Asc(e.KeyChar) = Keys.Enter AndAlso t.Text.Length > 0 Then BuscarSerie()
    End Sub

    Private Sub BuscarSerie()
        Dim Sql As String
        Dim da As OracleDataAdapter
        Dim dt As New DataTable

        If txtCodigo.Text.Trim = "" Then Exit Sub

        Sql = "SELECT mac.macnum_0 as serie, "
        Sql &= "      mac.ynrocil_0 as cilindro, "
        Sql &= "      srm.credat_0 as ingreso, "
        Sql &= "      srm.pallet_0 as pallet, "
        Sql &= "      srm.yitnnum_0 as intervencion, "
        Sql &= "      bpc.bpcnum_0 as cliente, "
        Sql &= "      bpc.bpcnam_0 as nombre, "
        Sql &= "      mac.fcyitn_0 as suc, "
        Sql &= "      bpa.bpaaddlig_0 as direccion "
        Sql &= "FROM machines mac inner join "
        Sql &= "	 sremac srm on (mac.macnum_0 = srm.macnum_0) inner join "
        Sql &= "	 bpcustomer bpc on (bpc.bpcnum_0 = mac.bpcnum_0) inner join "
        Sql &= "	 bpaddress bpa on (bpa.bpanum_0 = mac.bpcnum_0 and bpa.bpaadd_0 = mac.fcyitn_0) "
        Sql &= "where mac.macnum_0 = :codigo or mac.ynrocil_0 = :codigo "
        Sql &= "order by srm.credat_0 desc"

        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("codigo", OracleType.VarChar).Value = txtCodigo.Text

        If dgv.DataSource Is Nothing Then
            dt = New DataTable
        Else
            dt = CType(dgv.DataSource, DataTable)
        End If

        dt.Clear()
        da.Fill(dt)
        da.Dispose()

        If dgv.DataSource Is Nothing Then
            dgv.DataSource = dt

            For Each c As DataGridViewColumn In dgv.Columns
                c.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            Next

        End If

    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        BuscarSerie()
    End Sub

End Class