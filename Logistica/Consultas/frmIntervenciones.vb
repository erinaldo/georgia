Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.OracleClient

Public Class frmIntervenciones

    Private Sub btn_buscar_itn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar_itn.Click
        If rbnumero.Checked = True Then

            Dim Sql As String
            Dim da As OracleDataAdapter
            Dim dt2 As New DataTable
            Dim cliente As String = txtbox_itn.Text

            'Sql = "select num_0 as codigo, bpc_0 as cliente, bpaadd_0 as sucursal, typ_0 as tipo, dat_0 as fecha  from interven "
            'Sql &= "where bpc_0 = :bpcord_0 order by dat_0 desc"
            Sql = "select num_0 as codigo, bpc_0 as cliente, bpaadd_0 as sucursal, typ_0 as tipo, dat_0 as fecha, "
            Sql &= "(select max(ruta_0) from xrutad where vcrnum_0 = num_0 ) as ruta ,xsector_0 as Sector, ysdhdeb_0 as remito, yref_0 as OC "
            Sql &= "from interven itn left join xrutad rtd on (itn.num_0 = rtd.vcrnum_0) "
            Sql &= "where num_0 LIKE :bpcord_0 group by num_0,bpc_0,bpaadd_0,typ_0,dat_0,xsector_0,ysdhdeb_0,yref_0 order by dat_0 desc"
            da = New OracleDataAdapter(Sql, cn)
            da.SelectCommand.Parameters.Add("bpcord_0", OracleType.VarChar).Value = "%" & cliente

            dt2.Clear()
            da.Fill(dt2)

            If dt2.Rows.Count = 0 Then
                MsgBox("El cliente no tiene intervenciones")

            Else
                Dim f As New frmItnList(dt2)
                f.MdiParent = frmMain
                f.Show()

            End If

        Else
            Dim Sql As String
            Dim da As OracleDataAdapter
            Dim dt2 As New DataTable
            Dim cliente As String = txtbox_itn.Text
            
            'Sql = "select num_0 as codigo, bpc_0 as cliente, bpaadd_0 as sucursal, typ_0 as tipo, dat_0 as fecha  from interven "
            'Sql &= "where bpc_0 = :bpcord_0 order by dat_0 desc"
            Sql = "select num_0 as codigo, bpc_0 as cliente, bpaadd_0 as sucursal, typ_0 as tipo, dat_0 as fecha, "
            Sql &= "(select max(ruta_0) from xrutad where vcrnum_0 = num_0 ) as ruta ,xsector_0 as Sector, ysdhdeb_0 as remito, yref_0 as OC "
            Sql &= "from interven itn left join xrutad rtd on (itn.num_0 = rtd.vcrnum_0) "
            Sql &= "where bpc_0 = :bpcord_0 group by num_0,bpc_0,bpaadd_0,typ_0,dat_0,xsector_0,ysdhdeb_0,yref_0 order by dat_0 desc"
            da = New OracleDataAdapter(Sql, cn)
            da.SelectCommand.Parameters.Add("bpcord_0", OracleType.VarChar).Value = cliente

            dt2.Clear()
            da.Fill(dt2)

            If dt2.Rows.Count = 0 Then
                MsgBox("El cliente no tiene intervenciones")

            Else
                Dim f As New frmItnList(dt2)
                f.MdiParent = frmMain
                f.Show()

            End If
        End If

    End Sub

End Class