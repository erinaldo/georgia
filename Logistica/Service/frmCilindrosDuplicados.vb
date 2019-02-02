Imports System.Data.OracleClient

Public Class frmCilindrosDuplicados

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        BuscarDomiciliosConCilindrosDuplicados()
    End Sub
    Private Sub BuscarDomiciliosConCilindrosDuplicados()
        Dim Sql As String = ""
        Dim da As OracleDataAdapter
        Dim dt As New DataTable
        Dim Cliente As String = ""
        Dim Sucursal As String = ""
        Dim tNode As TreeNode = Nothing

        Sql &= "select distinct bpcnum_0, bpcnam_0, fcyitn_0, bpaaddlig_0 "
        Sql &= "from ( "
        Sql &= "	select bpcnum_0, bpcnam_0, fcyitn_0, bpaaddlig_0, ynrocil_0, count(ynrocil_0) as cant "
        Sql &= "	from machines mac inner join "
        Sql &= "		 itmmaster itm on (mac.macpdtcod_0 = itm.itmref_0) inner join "
        Sql &= "		 bpcustomer bpc on (mac.bpcnum_0 = bpc.bpcnum_0) inner join "
        Sql &= "		 bpaddress bpa on (bpc.bpcnum_0 = bpa.bpanum_0 AND bpa.bpaadd_0 = fcyitn_0) "
        Sql &= "	where macpdtcod_0 <> '601003' and "
        Sql &= "		  macitntyp_0 = 1 and "
        Sql &= "		  ynrocil_0 <> ' ' and "
        Sql &= "		  tsicod_3 = '301' and "
        Sql &= "		  bpcnum_0 <> '402000' "
        Sql &= "	group by bpcnum_0, bpcnam_0, fcyitn_0, bpaaddlig_0, ynrocil_0 "
        Sql &= "	having count(ynrocil_0) > 1 "
        Sql &= ") "
        Sql &= "order by bpcnum_0, fcyitn_0"

        da = New OracleDataAdapter(Sql, cn)
        da.Fill(dt)
        da.Dispose()

        tv.Nodes.Clear()

        For Each dr As DataRow In dt.Rows
            If Cliente <> dr("bpcnum_0").ToString Then
                Cliente = dr("bpcnum_0").ToString

                tNode = tv.Nodes.Add(Cliente, Cliente & " " & dr("bpcnam_0").ToString)

            End If

            Dim tNode2 As TreeNode

            tNode2 = tNode.Nodes.Add(Cliente & "/" & dr("fcyitn_0").ToString, dr("fcyitn_0").ToString & " " & dr("bpaaddlig_0").ToString)
            tNode2.Tag = dr("bpcnam_0").ToString

        Next

    End Sub
    Private Sub CilindrosDuplicados(ByVal Cliente As String, ByVal Sucursal As String)
        Dim Sql As String
        Dim dt1 As New DataTable
        Dim dt2 As New DataTable
        Dim da As OracleDataAdapter

        Sql = "SELECT bpcnum_0, fcyitn_0, ynrocil_0, count(ynrocil_0) AS cant "
        Sql &= "FROM machines mac inner join "
        Sql &= "	 itmmaster itm ON (mac.macpdtcod_0 = itm.itmref_0) INNER JOIN "
        Sql &= "	 bpcustomer bpc ON (mac.bpcnum_0 = bpc.bpcnum_0) INNER JOIN "
        Sql &= "	 bpaddress bpa ON (bpc.bpcnum_0 = bpa.bpanum_0 AND bpa.bpaadd_0 = fcyitn_0) "
        Sql &= "WHERE macpdtcod_0 <> '601003' AND "
        Sql &= "	  macitntyp_0 = 1 AND "
        Sql &= "	  ynrocil_0 <> ' ' AND "
        Sql &= "	  tsicod_3 = '301' AND "
        Sql &= "	  bpcnum_0 = :cli AND "
        Sql &= "	  fcyitn_0 = :suc "
        Sql &= "GROUP BY bpcnum_0, fcyitn_0, ynrocil_0 "
        Sql &= "HAVING COUNT(ynrocil_0) > 1"

        'Recupero los numeros de cilindros duplicados
        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("cli", OracleType.VarChar).Value = Cliente
        da.SelectCommand.Parameters.Add("suc", OracleType.VarChar).Value = Sucursal
        da.Fill(dt1)

        Sql = "SELECT mac.macnum_0, mac.macdes_0, ynrocil_0, yfabdat_0, datnext_0, xitn_0, mac.credat_0, mac.creusr_0, mac.macorivcr_0 "
        Sql &= "FROM machines mac INNER JOIN "
        Sql &= "	 ymacitm yit on (mac.macnum_0 = yit.macnum_0) INNER JOIN "
        Sql &= "	 itmmaster itm on (mac.macpdtcod_0 = itm.itmref_0) INNER JOIN "
        Sql &= "	 bpcustomer bpc on (mac.bpcnum_0 = bpc.bpcnum_0) INNER JOIN "
        Sql &= "	 bpaddress bpa on (bpc.bpcnum_0 = bpa.bpanum_0 AND bpa.bpaadd_0 = fcyitn_0) INNER JOIN "
        Sql &= "	 bomd bmd on (mac.macpdtcod_0 = bmd.itmref_0 AND yit.cpnitmref_0 = bmd.cpnitmref_0 AND bomalt_0 = 99 AND bomseq_0 = 10) "
        Sql &= "WHERE macpdtcod_0 <> '601003' AND "
        Sql &= "	  macitntyp_0 = 1 AND "
        Sql &= "	  ynrocil_0 = :cil AND "
        Sql &= "	  tsicod_3 = '301' AND "
        Sql &= "	  bpcnum_0 = :cli AND "
        Sql &= "	  fcyitn_0 = :suc "
        Sql &= "ORDER BY credat_0"
        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("cil", OracleType.VarChar)
        da.SelectCommand.Parameters.Add("cli", OracleType.VarChar)
        da.SelectCommand.Parameters.Add("suc", OracleType.VarChar)

        If dgv.DataSource IsNot Nothing Then
            dt2 = CType(dgv.DataSource, DataTable)
        End If

        dt2.Clear()

        For Each dr As DataRow In dt1.Rows
            da.SelectCommand.Parameters("cil").Value = dr("ynrocil_0").ToString
            da.SelectCommand.Parameters("cli").Value = Cliente
            da.SelectCommand.Parameters("suc").Value = Sucursal
            da.Fill(dt2)
        Next

        If dgv.DataSource Is Nothing Then
            colSerie.DataPropertyName = "macnum_0"
            colTipo.DataPropertyName = "macdes_0"
            colCilindro.DataPropertyName = "ynrocil_0"
            colFabricacion.DataPropertyName = "yfabdat_0"
            colVto.DataPropertyName = "datnext_0"
            colIntervencion.DataPropertyName = "xitn_0"
            colCreacion.DataPropertyName = "credat_0"
            colUsuario.DataPropertyName = "creusr_0"
            colOrigen.DataPropertyName = "macorivcr_0"
            dgv.DataSource = dt2
        End If

    End Sub
    Private Sub tv_NodeMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles tv.NodeMouseClick
        Dim txt As String = ""

        'Salgo si el usuario hizo clic derecho
        If e.Button <> Windows.Forms.MouseButtons.Left Then Exit Sub

        'Muestro los vencimientos del parque del cliente seleccionado
        If e.Node.Level = 1 Then
            Dim Cli As String() = Split(e.Node.Name.ToString, "/")

            'Salgo si el usuario volvio a seleccionar el nodo activo
            If Cli(0) = txtCodigo.Text And Cli(1) = txtSuc.Text Then Exit Sub

            txtCodigo.Text = Cli(0) : txtCliente.Text = e.Node.Tag.ToString
            txtSuc.Text = Cli(1) : txtDireccion.Text = e.Node.Text

            Me.Cursor = Cursors.WaitCursor

            CilindrosDuplicados(Cli(0), Cli(1))

            Me.Cursor = Cursors.Default

        Else
            txtCodigo.Clear()
            txtCliente.Clear()
            txtSuc.Clear()
            txtDireccion.Clear()
            lblRep.Text = ""

        End If

    End Sub

    Private Sub cms_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cms.Opening
        If dgv.CurrentRow Is Nothing Then
            e.Cancel = True
            Exit Sub
        End If

        e.Cancel = dgv.CurrentRow.Index < 0

    End Sub
    Private Sub mnuEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEditar.Click
        Dim dr As DataRow
        Dim f As frmParque
        Dim mac As New Parque(cn)

        dr = CType(dgv.CurrentRow.DataBoundItem, DataRowView).Row
        mac.Abrir(dr("macnum_0").ToString)

        f = New frmParque(mac)
        f.MdiParent = Nothing
        f.ShowDialog()

        If f.DialogResult = Windows.Forms.DialogResult.OK Then
            CilindrosDuplicados(txtCliente.Text, txtSuc.Text)
        End If

    End Sub
    Private Sub mnuEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEliminar.Click
        Dim dr As DataRow

        dr = CType(dgv.CurrentRow.DataBoundItem, DataRowView).Row

        If MessageBox.Show("¿Confirma eliminar el parque " & dr("macnum_0").ToString & "?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            Dim mac As New Parque(cn)
            mac.Abrir(dr("macnum_0").ToString)
            mac.Borrar()
            dr.Delete()
        End If

    End Sub

End Class