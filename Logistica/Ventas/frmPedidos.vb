Imports System.Data.OracleClient
Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO

Public Class frmPedidos

    Private Sub cons_btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cons_btn.Click


        Dim sql As String
        Dim da As OracleDataAdapter
        Dim dt As New DataTable
        ' Dim dr As DataRow
        sql = "select bpcord_0, sohnum_0, bpcnam_0,dlvsta_0,invsta_0, shidat_0,ysohdes_0,bpaadd_0 "
        sql &= " from sorder where sohtyp_0 = 'PED' and "
        If ano_check.Checked = True Then
            sql &= " to_char(credat_0, 'YYYY') = '2018'and "
        End If
        If pedido_radio.Checked = True Then
            sql &= "sohnum_0 like :pedido order by sohnum_0 "
            da = New OracleDataAdapter(sql, cn)
            da.SelectCommand.Parameters.Add("pedido", OracleType.VarChar).Value = "%" & pedido_txtbox.Text
            da.Fill(dt)

        ElseIf cliente_radio.Checked = True Then
            If txtsuc.Text.Trim = "" Then
                sql &= "bpcord_0 like :cliente order by sohnum_0 "
                da = New OracleDataAdapter(sql, cn)
                da.SelectCommand.Parameters.Add("cliente", OracleType.VarChar).Value = "%" & pedido_txtbox.Text
                da.Fill(dt)
            Else
                sql &= "bpcord_0 like :cliente and bpaadd_0 = :suc order by sohnum_0 "
                da = New OracleDataAdapter(sql, cn)
                da.SelectCommand.Parameters.Add("cliente", OracleType.VarChar).Value = "%" & pedido_txtbox.Text
                da.SelectCommand.Parameters.Add("suc", OracleType.VarChar).Value = txtsuc.Text
                da.Fill(dt)
            End If


        End If
        cliente_col.DataPropertyName = "BPCORD_0"
        cliente_principal_col.DataPropertyName = "bpcnam_0"
        Sucursal.DataPropertyName = "bpaadd_0"
        'Direccion.DataPropertyName = "bpcaddlig_0"
        NumPedido_col.DataPropertyName = "sohnum_0"
        'Dim mnu As New MenuLocal(cn, 415, False)
        'mnu.Enlazar(EstadoPedido_col)
        'EstadoPedido_col.DataPropertyName = "ordsta_0"
        'mnu = New MenuLocal(cn, 416, False)
        'mnu.Enlazar(EstadoAsignacion_col)
        'EstadoAsignacion_col.DataPropertyName = "allsta_0"
        Dim mnu = New MenuLocal(cn, 417, False)
        mnu.Enlazar(EstadoEntrega_col)
        EstadoEntrega_col.DataPropertyName = "dlvsta_0"
        mnu = New MenuLocal(cn, 418, False)
        mnu.Enlazar(EstadoFactura_col)
        EstadoFactura_col.DataPropertyName = "invsta_0"
        mnu = New MenuLocal(cn, 419, False)
        FechaEntrega_col.DataPropertyName = "shidat_0"
        obs_principal_col.DataPropertyName = "ysohdes_0"
        cuadro_datagrid.DataSource = dt

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'cliente_txtbox.Text = ""
        pedido_txtbox.Text = ""

    End Sub


    Private Sub cuadro_datagrid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles cuadro_datagrid.CellContentClick
        Dim numero_pedido As String
        Dim sql As String
        Dim da As OracleDataAdapter
        Dim dt As New DataTable
        ' Dim dr As DataRow
        numero_pedido = cuadro_datagrid.Rows(e.RowIndex).Cells("numpedido_col").Value.ToString
        sql = "select dlv.sohnum_0,dlv.sdhnum_0,ru.ruta_0,ruc.fecha_0,ru.obs_0,estado_0,noconform_0 "
        sql &= "from sdelivery dlv left join xrutad ru on (dlv.sdhnum_0 = ru.vcrnum_0) "
        sql &= "left join xrutac ruc on (ru.ruta_0 = ruc.ruta_0) "
        sql &= "where sdhcat_0 = 1 and dlv.sohnum_0 = :pedido"
        da = New OracleDataAdapter(sql, cn)
        da.SelectCommand.Parameters.Add("pedido", OracleType.VarChar).Value = numero_pedido
        da.Fill(dt)
        If dt.Rows.Count > 0 Then
            pedido_col.DataPropertyName = "sohnum_0"
            remito_col.DataPropertyName = "sdhnum_0"
            ruta_col.DataPropertyName = "ruta_0"
            Fecha.DataPropertyName = "fecha_0"
            With colEstado
                .DataPropertyName = "estado_0"
                .DataSource = TablaEstadosRuta(cn)
                .DisplayMember = "texte_0"
                .ValueMember = "code_0"
            End With
            With colnoconform
                .DataSource = TablaMotivos(cn)
                .DisplayMember = "texte_0"
                .ValueMember = "code_0"
                .DataPropertyName = "noconform_0"
            End With
            'sector_col.DataPropertyName = "para_0"
            obs_adicional_col.DataPropertyName = "obs_0"

        Else
            MsgBox("El pedido no tiene remitos")
        End If
        adiciona_datagrid.DataSource = dt
    End Sub

    Private Sub adiciona_datagrid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles adiciona_datagrid.CellContentClick
        Dim numero_pedido As String
        Dim sql As String
        Dim da As OracleDataAdapter
        Dim dt As New DataTable
        ' Dim dr As DataRow
        numero_pedido = adiciona_datagrid.Rows(e.RowIndex).Cells("remito_col").Value.ToString
        sql = "select fecha_0,hora_0,rto_0,de_0,para_0 from xsegto where rto_0 = :remito order by fecha_0, hora_0"
        da = New OracleDataAdapter(sql, cn)
        da.SelectCommand.Parameters.Add("remito", OracleType.VarChar).Value = numero_pedido
        da.Fill(dt)
        If dt.Rows.Count > 0 Then
            fecha_sector_col.DataPropertyName = "fecha_0"
            hora_sector_col.DataPropertyName = "hora_0"
            remito_sector_col.DataPropertyName = "rto_0"
            desde_sector_col.DataPropertyName = "de_0"
            Para_sector_col.DataPropertyName = "para_0"
            sector_datagrid.DataSource = dt
        Else
            MsgBox("El pedido no tiene sgto")
        End If
        sector_datagrid.DataSource = dt
    End Sub

    Private Sub VerPedidoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerPedidoToolStripMenuItem.Click
        Dim rpt As New ReportDocument
        Dim numero As String = adiciona_datagrid.CurrentRow.Cells("pedido_col").Value.ToString
        Dim crystal As frmCrystal
        rpt.Load(RPTX3 & "xpedidos2b2.rpt")
        rpt.SetDatabaseLogon(DB_USR, DB_PWD)
        rpt.SetParameterValue("pedido", numero)
        crystal = New frmCrystal(rpt)
        crystal.MdiParent = Me.ParentForm
        crystal.Show()
    End Sub
    Private Sub VerPedidoToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerPedidoToolStripMenuItem1.Click
        Dim rpt As New ReportDocument
        Dim numero As String = cuadro_datagrid.CurrentRow.Cells("NumPedido_col").Value.ToString
        Dim crystal As frmCrystal
        rpt.Load(RPTX3 & "xpedidos2b2.rpt")
        rpt.SetDatabaseLogon(DB_USR, DB_PWD)
        rpt.SetParameterValue("pedido", numero)
        crystal = New frmCrystal(rpt)
        crystal.MdiParent = Me.ParentForm
        crystal.Show()
    End Sub

    Private Sub cliente_radio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cliente_radio.CheckedChanged
        txtsuc.Enabled = True
        lblsuc.Enabled = True
    End Sub
    Private Sub pedido_radio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pedido_radio.CheckedChanged
        txtsuc.Enabled = False
        lblsuc.Enabled = False
    End Sub

    Private Sub VerRemitoEscaneadoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerRemitoEscaneadoToolStripMenuItem.Click
        Dim numero As String = adiciona_datagrid.CurrentRow.Cells("remito_col").Value.ToString
        Try
            Process.Start("\\srv\Z\Remitos\" & numero & ".pdf")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ContextMenuStrip1_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        Dim numero As String = adiciona_datagrid.CurrentRow.Cells("remito_col").Value.ToString
        If File.Exists("\\srv\Z\Remitos\" & numero & ".pdf") Then
            VerRemitoEscaneadoToolStripMenuItem.Enabled = True
        Else
            VerRemitoEscaneadoToolStripMenuItem.Enabled = False
        End If
    End Sub
End Class