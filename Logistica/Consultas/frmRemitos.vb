Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.OracleClient

Public Class frmRemitos

    Private Sub btn_buscar_rto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar_rto.Click
        If rbnumero.Checked = True Then

            Dim Sql As String
            Dim da As OracleDataAdapter
            Dim dt2 As New DataTable
            Dim cliente As String = txtrto.Text

            Sql = "select sdhnum_0 as codigo, stofcy_0 as planta, bpcord_0 as codigo_cliente,bpaadd_0 as sucursal, bpdnam_0 as nombre"
            Sql &= ",(select max(ruta_0) from xrutad where vcrnum_0 = sdhnum_0) as ruta, "
            Sql &= "(select min(para_0) from xsegto where rto_0 = sdhnum_0) as sector "
            Sql &= "from sdelivery	where sdhnum_0 LIKE :bpcord_0 order by dlvdat_0 desc"
            da = New OracleDataAdapter(Sql, cn)
            da.SelectCommand.Parameters.Add("bpcord_0", OracleType.VarChar).Value = "%" & cliente
            dt2.Clear()
            da.Fill(dt2)

            If dt2.Rows.Count = 0 Then
                MsgBox("El cliente no tiene remitos")

            Else
                Dim f As New frmRemitoslist(dt2)
                f.MdiParent = frmMain
                f.Show()

            End If
        Else
            Dim Sql As String
            Dim da As OracleDataAdapter
            Dim dt2 As New DataTable
            Dim cliente As String = txtrto.Text

            Sql = "select sdhnum_0 as codigo, stofcy_0 as planta, bpcord_0 as codigo_cliente,bpaadd_0 as sucursal, bpdnam_0 as nombre"
            Sql &= ",(select max(ruta_0) from xrutad where vcrnum_0 = sdhnum_0) as ruta, "
            Sql &= "(select min(para_0) from xsegto where rto_0 = sdhnum_0) as sector "
            Sql &= "from sdelivery	where bpcord_0 = :bpcord_0 order by dlvdat_0 desc"
            da = New OracleDataAdapter(Sql, cn)
            da.SelectCommand.Parameters.Add("bpcord_0", OracleType.VarChar).Value = cliente
            dt2.Clear()
            da.Fill(dt2)

            If dt2.Rows.Count = 0 Then
                MsgBox("El cliente no tiene remitos")

            Else
                Dim f As New frmRemitoslist(dt2)
                f.MdiParent = frmMain
                f.Show()

            End If
        End If

    End Sub
End Class