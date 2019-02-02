Imports System.Data.OracleClient
Public Class frmOC
    Private Sub btnbuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnbuscar.Click
        Dim Sql As String
        Dim da As OracleDataAdapter
        Dim dt2 As New DataTable
        Dim numero As String = txtbusqueda.Text.Trim

        Sql = "select sohnum_0 as codigo, cusordref_0 as OC,salfcy_0 as planta, "
        Sql &= " bpcord_0 as codigo_cliente,bpcnam_0 as cliente, "
        Sql &= " bpaadd_0 as sucursal, rep_0 as vendedor,orddat_0 as fecha "

        If rbcliente.Checked = True Then
            Sql &= "from sorder where bpcord_0 = :bpcord_0 "
            Sql &= "and (orddat_0 >= :fechadesde and orddat_0 <= :fechahasta) "
            Sql &= "order by orddat_0 desc  "
            da = New OracleDataAdapter(Sql, cn)
            da.SelectCommand.Parameters.Add("bpcord_0", OracleType.VarChar).Value = numero
            da.SelectCommand.Parameters.Add("fechadesde", OracleType.DateTime).Value = dtpdesde.Value.Date
            da.SelectCommand.Parameters.Add("fechahasta", OracleType.DateTime).Value = dtphasta.Value.Date
            dt2.Clear()
            da.Fill(dt2)
            If dt2.Rows.Count = 0 Then
                MsgBox("numero de cliente erroneo / no hay pedidos de ese cliente en esa fecha")
            Else
                Dim f As New frmOClist(dt2)
                f.MdiParent = frmMain
                f.Show()
            End If
        ElseIf rboc.Checked = True Then
            Sql &= "from sorder where cusordref_0 = :cusordref_0 "
            Sql &= "order by orddat_0 desc  "
            da = New OracleDataAdapter(Sql, cn)
            da.SelectCommand.Parameters.Add("cusordref_0", OracleType.VarChar).Value = numero
            dt2.Clear()
            da.Fill(dt2)
            If dt2.Rows.Count = 0 Then
                MsgBox("No se encunentra Orden de Compra con el valor ingresado")
            Else
                Dim f As New frmOClist(dt2)
                f.MdiParent = frmMain
                f.Show()
            End If
        ElseIf rbpedido.Checked = True Then
            Sql &= "from sorder where sohnum_0 = :sohnum_0 "
            Sql &= "order by orddat_0 desc  "
            da = New OracleDataAdapter(Sql, cn)
            da.SelectCommand.Parameters.Add("sohnum_0", OracleType.VarChar).Value = numero
            dt2.Clear()
            da.Fill(dt2)
            If dt2.Rows.Count = 0 Then
                MsgBox("No se encontro Pedido")
            Else
                Dim f As New frmOClist(dt2)
                f.MdiParent = frmMain
                f.Show()
            End If
        ElseIf rbInter.Checked = True Then
            Sql = ""
            Sql = "select num_0 as codigo, yref_0 as oc,itn.salfcy_0 as planta, bpc_0 as codigo_cliente,"
            Sql &= "bpc.bpcnam_0 as cliente, itn.bpaadd_0 as sucursal, itn.rep_0 as vendedor, itn.dat_0 as fecha "
            Sql &= "from interven itn join bpcustomer bpc on (itn.bpc_0 = bpc.bpcnum_0) where num_0 = :num_0"
            da = New OracleDataAdapter(Sql, cn)
            da.SelectCommand.Parameters.Add("num_0", OracleType.VarChar).Value = numero
            dt2.Clear()
            da.Fill(dt2)
            If dt2.Rows.Count = 0 Then
                MsgBox("No se encontro Intervencion")
            Else
                Dim f As New frmOClist(dt2)
                f.MdiParent = frmMain
                f.Show()
            End If
        Else
            MsgBox("Elija una opcion de busqueda")
        End If
    End Sub

    
    Private Sub rbcliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbcliente.CheckedChanged
        dtpdesde.Visible = True
        dtphasta.Visible = True
        Label1.Visible = True
        Label2.Visible = True
    End Sub

    Private Sub rboc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rboc.CheckedChanged
        dtpdesde.Visible = False
        dtphasta.Visible = False
        Label1.Visible = False
        Label2.Visible = False
    End Sub

    Private Sub rbpedido_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbpedido.CheckedChanged
        dtpdesde.Visible = False
        dtphasta.Visible = False
        Label1.Visible = False
        Label2.Visible = False
    End Sub
End Class