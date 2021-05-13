Imports System.Data.OracleClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class frmIntervencionesEntregar
    Dim dt As New DataTable

    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        Consultar()
    End Sub
    Private Sub Consultar()
        Dim Sql As String
        Dim da As OracleDataAdapter

        Sql = "select itn.num_0, bpc.bpcnum_0, bpc.bpcnam_0, itn.bpaadd_0, itn.add_0, xsector_0, ysdhdeb_0, min(sre.credat_0) as ingreso, count(sre.macnum_0) as cantidad, min(sre.pallet_0) as pallet_0 "
        Sql &= "from interven itn left join "
        Sql &= "     xsegto2 xsg on (itn.num_0 = xsg.itn_0) inner join "
        Sql &= "     bpcustomer bpc on (itn.bpc_0 = bpc.bpcnum_0) left join "
        Sql &= "     sremac sre on (itn.num_0 = sre.yitnnum_0) "
        Sql &= "where itn.typ_0 in ('B1', 'C1') and "
        Sql &= "      zflgtrip_0 not in (5, 8) and ysdhdeb_0 <> ' ' and "
        Sql &= "      mdl_0 = 1 and "
        Sql &= "      xsector_0 <> 'ACH' "
        Sql &= "group by itn.num_0, bpc.bpcnum_0, bpc.bpcnam_0, itn.bpaadd_0, itn.add_0, xsector_0, ysdhdeb_0, pallet_0 "
        Sql &= "order by ingreso"

        da = New OracleDataAdapter(Sql, cn)
        dt.Clear()
        da.Fill(dt)

        If dgv.DataSource Is Nothing Then
            dgv.DataSource = dt

            For Each c As DataGridViewColumn In dgv.Columns
                c.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            Next

        End If

    End Sub
    Private Sub VerSeguimientoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerSeguimientoToolStripMenuItem.Click
        Dim itn As String

        itn = dgv.CurrentRow.Cells("num_0").Value.ToString

        ConsultarSeguimiento(itn)

    End Sub
    Private Sub VerReboteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerReboteToolStripMenuItem.Click
        Dim itn As String

        itn = dgv.CurrentRow.Cells("num_0").Value.ToString

        ConsultarRebote(itn)
    End Sub
    Private Sub ConsultarSeguimiento(ByVal itn As String)
        Dim rpt As New ReportDocument
        Dim f As frmCrystal

        Try
            rpt.Load(RPTX3 & "xsegto_itn.rpt")
            rpt.SetParameterValue("itn", itn)

            f = New frmCrystal(rpt)
            f.MdiParent = Me.ParentForm
            f.Show()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            rpt.Dispose() : rpt = Nothing

        End Try
    End Sub
    Private Sub ConsultarRebote(ByVal itn As String)
        Dim Sql As String
        Dim da As OracleDataAdapter
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim tblMotivos As New TablaVaria(cn, 5000)

        Sql = "SELECT * FROM xrutad WHERE vcrnum_0 = :vcrnum ORDER BY ruta_0 desc"
        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("vcrnum", OracleType.VarChar).Value = itn
        da.Fill(dt)
        dr = dt.Rows(0)

        Sql = "Motivo Rebote: " & tblMotivos.Texto(dr("noconform_0").ToString) & vbCrLf & vbCrLf
        Sql &= "Obs: " & dr("obs_0").ToString

        MessageBox.Show(Sql, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub
End Class