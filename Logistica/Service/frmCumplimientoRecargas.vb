Imports System.Data.OracleClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class frmCumplimientoRecargas

    Private da As OracleDataAdapter
    Private Fecha1 As Date
    Private Fecha2 As Date

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        MenuLocal(cn, 1, cboDe) : cboDe.SelectedValue = 1
        MenuLocal(cn, 1, cboHasta) : cboHasta.SelectedValue = 2

    End Sub
    Private Sub frmTableroAbonados_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AddHandler dgv1.RowPostPaint, AddressOf NumeracionGrillas
        AddHandler dgv2.RowPostPaint, AddressOf NumeracionGrillas
        AddHandler dgv3.RowPostPaint, AddressOf NumeracionGrillas
        AddHandler dgv4.RowPostPaint, AddressOf NumeracionGrillas
    End Sub
    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        Dim dt As DataTable

        btnConsultar.Enabled = False
        Me.UseWaitCursor = True

        If dgv1.DataSource IsNot Nothing Then
            dt = CType(dgv1.DataSource, DataTable)
            dt.Clear()
        End If
        If dgv2.DataSource IsNot Nothing Then
            dt = CType(dgv2.DataSource, DataTable)
            dt.Clear()
        End If
        If dgv3.DataSource IsNot Nothing Then
            dt = CType(dgv3.DataSource, DataTable)
            dt.Clear()
        End If
        If dgv4.DataSource IsNot Nothing Then
            dt = CType(dgv4.DataSource, DataTable)
            dt.Clear()
        End If

        'AJUSTO EL RANGO DE FECHA DE CONSULTA
        Fecha1 = New Date(dtp.Value.Year, dtp.Value.Month, 1)
        Fecha2 = Fecha1.AddMonths(1)
        Fecha2 = Fecha2.AddDays(-1)

        Tab.SelectedTab = TabPage1

        Consulta4()
        Consulta3()
        Consulta2()
        Consulta1()
        CalcularTotales()

        btnConsultar.Enabled = True
        Me.UseWaitCursor = False

    End Sub

    Private Sub Consulta1()
        Dim Sql As String
        Dim dt As New DataTable

        lbl.Text = "Buscando pendientes sin intervención generada"
        lbl.Visible = True
        Application.DoEvents()

        'CONSULTA DE SERVICIOS PENDIENTES SIN INTERVENCION GENERADA PARA RETIRO
        Sql = "SELECT mac.bpcnum_0, mac.fcyitn_0, bpc.bpcnam_0, bpa.bpaaddlig_0, SUM(mac.macqty_0) AS cant "
        Sql &= "FROM (((machines mac INNER JOIN ymacitm ymc ON (mac.macnum_0 = ymc.macnum_0)) "
        Sql &= "	 INNER JOIN bomd bmd ON (mac.macpdtcod_0 = bmd.itmref_0 AND ymc.cpnitmref_0 = bmd.cpnitmref_0)) "
        Sql &= "	 INNER JOIN bpcustomer bpc ON (mac.bpcnum_0 = bpc.bpcnum_0)) "
        Sql &= "	 INNER JOIN bpaddress bpa ON (mac.bpcnum_0 = bpa.bpanum_0 AND mac.fcyitn_0 = bpa.bpaadd_0)  "
        Sql &= "WHERE bomalt_0 = 99 AND bomseq_0 = 10 AND bpc.xabo_0 >= :xabo_0 AND bpc.xabo_0 <= :xabo_1 AND "
        Sql &= "	  ymc.datnext_0 BETWEEN :datini AND :datfin AND "
        Sql &= "	  mac.xitn_0 = ' ' AND mac.macitntyp_0 = 1 AND "
        Sql &= "	  (macdes_0 LIKE 'EXT.%' OR macdes_0 LIKE 'MANGU%') "
        Sql &= "GROUP BY mac.bpcnum_0, mac.fcyitn_0, bpc.bpcnam_0, bpa.bpaaddlig_0 "
        Sql &= "ORDER BY mac.bpcnum_0, mac.fcyitn_0"

        da = New OracleDataAdapter(Sql, cn)
        With da.SelectCommand.Parameters
            .Add("datini", OracleType.DateTime).Value = Fecha1
            .Add("datfin", OracleType.DateTime).Value = Fecha2
            .Add("xabo_0", OracleType.Number).Value = CInt(cboDe.SelectedValue)
            .Add("xabo_1", OracleType.Number).Value = CInt(cboHasta.SelectedValue)
        End With

        col1Cod.DataPropertyName = "bpcnum_0"
        col1suc.DataPropertyName = "fcyitn_0"
        col1Cliente.DataPropertyName = "bpcnam_0"
        col1Domicilio.DataPropertyName = "bpaaddlig_0"
        col1Cantidad.DataPropertyName = "cant"

        da.Fill(dt)
        da.Dispose()
        da = Nothing

        If CInt(cboDe.SelectedValue) = 2 AndAlso CInt(cboHasta.SelectedValue) = 2 Then Contrato(dt)
        dgv1.DataSource = dt

        lbl.Visible = False

    End Sub
    Private Sub Consulta2()
        Dim Sql As String
        Dim dt As New DataTable

        lbl.Text = "Buscando pendientes con intervención sin retirar"
        lbl.Visible = True
        Application.DoEvents()

        'CONSULTA DE SERVICIOS PENDIENTES CON INTERVENCION GENERADA AUN NO RETIRADOS
        Sql = "SELECT mac.bpcnum_0, mac.fcyitn_0, bpc.bpcnam_0, bpa.bpaaddlig_0, mac.xitn_0, itn.tripnum_0, itn.zflgtrip_0, SUM(mac.macqty_0) AS cant "
        Sql &= "FROM ((((machines mac INNER JOIN ymacitm ymc ON (mac.macnum_0 = ymc.macnum_0)) "
        Sql &= "	 INNER JOIN bomd bmd ON (mac.macpdtcod_0 = bmd.itmref_0 AND ymc.cpnitmref_0 = bmd.cpnitmref_0)) "
        Sql &= "	 INNER JOIN bpcustomer bpc ON (mac.bpcnum_0 = bpc.bpcnum_0)) "
        Sql &= "	 INNER JOIN bpaddress bpa ON (mac.bpcnum_0 = bpa.bpanum_0 AND mac.fcyitn_0 = bpa.bpaadd_0)) "
        Sql &= "	 INNER JOIN interven itn ON (mac.xitn_0 = itn.num_0) "
        Sql &= "WHERE bomalt_0 = 99 AND bomseq_0 = 10 AND bpc.xabo_0 >= :xabo_0 AND bpc.xabo_0 <= :xabo_1 AND "
        Sql &= "	  datnext_0 BETWEEN :datini AND :datfin AND "
        Sql &= "	  macitntyp_0  = 1 AND (itn.zflgtrip_0 = 1 OR (itn.zflgtrip_0 IN (6, 7) AND itn.don_0 = 1)) AND "
        Sql &= "	  (macdes_0 LIKE 'EXT.%' OR macdes_0 LIKE 'MANGU%') "
        Sql &= "GROUP BY mac.bpcnum_0, mac.fcyitn_0, bpc.bpcnam_0, bpa.bpaaddlig_0, mac.xitn_0, itn.tripnum_0, itn.zflgtrip_0 "
        Sql &= "ORDER BY mac.bpcnum_0, mac.fcyitn_0"

        da = New OracleDataAdapter(Sql, cn)
        With da.SelectCommand.Parameters
            .Add("datini", OracleType.DateTime).Value = Fecha1
            .Add("datfin", OracleType.DateTime).Value = Fecha2
            .Add("xabo_0", OracleType.Number).Value = CInt(cboDe.SelectedValue)
            .Add("xabo_1", OracleType.Number).Value = CInt(cboHasta.SelectedValue)
        End With

        col2cod.DataPropertyName = "bpcnum_0"
        col2suc.DataPropertyName = "fcyitn_0"
        col2cliente.DataPropertyName = "bpcnam_0"
        col2domicilio.DataPropertyName = "bpaaddlig_0"
        col2intervencion.DataPropertyName = "xitn_0"
        MenuLocal(cn, 2406, col2estado)
        col2estado.DataPropertyName = "zflgtrip_0"

        col2ruta.DataPropertyName = "tripnum_0"

        col2Cantidad.DataPropertyName = "cant"

        da.Fill(dt)
        da.Dispose()
        da = Nothing

        If CInt(cboDe.SelectedValue) = 2 AndAlso CInt(cboHasta.SelectedValue) = 2 Then Contrato(dt)

        dgv2.DataSource = dt

        lbl.Visible = False

    End Sub
    Private Sub Consulta3()
        Dim Sql As String
        Dim dt As New DataTable

        lbl.Text = "Buscando servicios para entregar"
        lbl.Visible = True
        Application.DoEvents()

        'CONSULTA DE SERVICIOS A ENTREGAR
        Sql = "SELECT itn.bpc_0, itn.bpaadd_0, bpc.bpcnam_0, bpa.bpaaddlig_0, itn.num_0, itn.tripnum_0, to_date('31/12/1599', 'dd/mm/yyyy') AS ingreso, itn.zflgtrip_0, COUNT(mac.macqty_0) as cant "
        Sql &= "FROM (((interven itn INNER JOIN bpcustomer bpc ON (itn.bpc_0 = bpc.bpcnum_0)) "
        Sql &= "	 INNER JOIN bpaddress bpa ON (itn.bpc_0 = bpa.bpanum_0 AND itn.bpaadd_0 = bpa.bpaadd_0)) "
        Sql &= "	 INNER JOIN sremac sre ON (itn.srvdemnum_0 = sre.srenum_0 AND itn.num_0 = sre.yitnnum_0)) "
        Sql &= "	 INNER JOIN machines mac ON (sre.macnum_0 = mac.macnum_0) "
        Sql &= "WHERE itn.dat_0 BETWEEN :datini AND :datfin AND bpc.xabo_0 >= :xabo_0 AND bpc.xabo_0 <= :xabo_1 AND itn.zflgtrip_0 IN (2, 3, 4, 6, 7) "
        Sql &= "GROUP BY itn.bpc_0, itn.bpaadd_0, bpc.bpcnam_0, bpa.bpaaddlig_0, itn.num_0, itn.tripnum_0, itn.zflgtrip_0 "
        Sql &= "UNION "
        Sql &= "SELECT mac.bpcnum_0, mac.fcyitn_0, bpc.bpcnam_0, bpa.bpaaddlig_0, mac.xitn_0, itn.tripnum_0, to_date('31/12/1599', 'dd/mm/yyyy') AS ingreso, itn.zflgtrip_0, SUM(mac.macqty_0) AS cant "
        Sql &= "FROM ((((machines mac INNER JOIN ymacitm ymc ON (mac.macnum_0 = ymc.macnum_0)) "
        Sql &= "	 INNER JOIN bomd bmd ON (mac.macpdtcod_0 = bmd.itmref_0 AND ymc.cpnitmref_0 = bmd.cpnitmref_0)) "
        Sql &= "	 INNER JOIN bpcustomer bpc ON (mac.bpcnum_0 = bpc.bpcnum_0)) "
        Sql &= "	 INNER JOIN bpaddress bpa ON (mac.bpcnum_0 = bpa.bpanum_0 AND mac.fcyitn_0 = bpa.bpaadd_0)) "
        Sql &= "	 INNER JOIN interven itn ON (mac.xitn_0 = itn.num_0) "
        Sql &= "WHERE bomalt_0 = 99 AND bomseq_0 = 10 AND bpc.xabo_0 >= :xabo_0 AND bpc.xabo_0 <= :xabo_1 AND  datnext_0 BETWEEN :datini AND :datfin AND "
        Sql &= "	  macitntyp_0  = 1 AND itn.zflgtrip_0 IN (2, 3, 4, 6, 7) AND "
        Sql &= "	  (macdes_0 LIKE 'EXT.%' OR macdes_0 LIKE 'MANGU%') "
        Sql &= "GROUP BY mac.bpcnum_0, mac.fcyitn_0, bpc.bpcnam_0, bpa.bpaaddlig_0, mac.xitn_0, itn.tripnum_0, itn.zflgtrip_0 "
        Sql &= "ORDER BY bpc_0, bpaadd_0"


        da = New OracleDataAdapter(Sql, cn)
        With da.SelectCommand.Parameters
            .Add("datini", OracleType.DateTime).Value = Fecha1
            .Add("datfin", OracleType.DateTime).Value = Fecha2
            .Add("xabo_0", OracleType.Number).Value = CInt(cboDe.SelectedValue)
            .Add("xabo_1", OracleType.Number).Value = CInt(cboHasta.SelectedValue)
        End With

        col3cod.DataPropertyName = "bpc_0"
        col3suc.DataPropertyName = "bpaadd_0"
        col3cliente.DataPropertyName = "bpcnam_0"
        col3domicilio.DataPropertyName = "bpaaddlig_0"
        col3intervencion.DataPropertyName = "num_0"
        MenuLocal(cn, 2406, col3estado)
        col3Retiro.DataPropertyName = "ingreso"
        col3estado.DataPropertyName = "zflgtrip_0"
        col3ruta.DataPropertyName = "tripnum_0"
        col3cantidad.DataPropertyName = "cant"

        da.Fill(dt)
        da.Dispose()
        da = Nothing

        If CInt(cboDe.SelectedValue) = 2 AndAlso CInt(cboHasta.SelectedValue) = 2 Then Contrato(dt)
        FechaIngreso(dt)

        dgv3.DataSource = dt

        lbl.Visible = False

    End Sub
    Private Sub Consulta4()
        Dim Sql As String
        Dim dt As New DataTable

        lbl.Text = "Buscando servicios entregados"
        lbl.Visible = True
        Application.DoEvents()

        'CONSULTA DE SERVICIOS ENTREGADOS
        Sql = "SELECT itn.bpc_0, itn.bpaadd_0, bpc.bpcnam_0, bpa.bpaaddlig_0, itn.num_0, SUM(mac.macqty_0) as cant "
        Sql &= "FROM (((interven itn INNER JOIN bpcustomer bpc ON (itn.bpc_0 = bpc.bpcnum_0)) "
        Sql &= "	 INNER JOIN bpaddress bpa ON (itn.bpc_0 = bpa.bpanum_0 AND itn.bpaadd_0 = bpa.bpaadd_0)) "
        Sql &= "	 INNER JOIN sremac sre ON (itn.srvdemnum_0 = sre.srenum_0 AND itn.num_0 = sre.yitnnum_0)) "
        Sql &= "	 INNER JOIN machines mac ON (sre.macnum_0 = mac.macnum_0) "
        Sql &= "WHERE itn.dat_0 BETWEEN :datini AND :datfin AND bpc.xabo_0 >= :xabo_0 AND bpc.xabo_0 <= :xabo_1 AND  itn.zflgtrip_0 IN (5, 8) "
        Sql &= "GROUP BY itn.bpc_0, itn.bpaadd_0, bpc.bpcnam_0, bpa.bpaaddlig_0, itn.num_0 "
        Sql &= "ORDER BY itn.bpc_0, itn.bpaadd_0"

        da = New OracleDataAdapter(Sql, cn)
        With da.SelectCommand.Parameters
            .Add("datini", OracleType.DateTime).Value = Fecha1
            .Add("datfin", OracleType.DateTime).Value = Fecha2
            .Add("xabo_0", OracleType.Number).Value = CInt(cboDe.SelectedValue)
            .Add("xabo_1", OracleType.Number).Value = CInt(cboHasta.SelectedValue)
        End With

        col4cod.DataPropertyName = "bpc_0"
        col4suc.DataPropertyName = "bpaadd_0"
        col4cliente.DataPropertyName = "bpcnam_0"
        col4domicilio.DataPropertyName = "bpaaddlig_0"
        col4intervencion.DataPropertyName = "num_0"
        col4cantidad.DataPropertyName = "cant"

        da.Fill(dt)
        da.Dispose()
        da = Nothing

        If CInt(cboDe.SelectedValue) = 2 AndAlso CInt(cboHasta.SelectedValue) = 2 Then Contrato(dt)

        dgv4.DataSource = dt

        lbl.Visible = False

    End Sub
    Private Sub CalcularTotales()
        Dim dt As DataTable
        Dim dr As DataRow
        Dim t1 As Integer
        Dim t2 As Integer
        Dim t3 As Integer
        Dim t4 As Integer
        Dim t5 As Integer

        lbl.Text = "Calculando totales..."
        lbl.Visible = True
        Application.DoEvents()

        dt = CType(dgv1.DataSource, DataTable)
        t1 = 0
        For Each dr In dt.Rows
            t1 += CInt(dr("cant"))
        Next
        txtTotal1.Text = t1.ToString("N0")

        dt = CType(dgv2.DataSource, DataTable)
        t2 = 0
        For Each dr In dt.Rows
            t2 += CInt(dr("cant"))
        Next
        txtTotal2.Text = t2.ToString("N0")

        dt = CType(dgv3.DataSource, DataTable)
        t3 = 0
        For Each dr In dt.Rows
            t3 += CInt(dr("cant"))
        Next
        txtTotal3.Text = t3.ToString("N0")

        dt = CType(dgv4.DataSource, DataTable)
        t4 = 0
        For Each dr In dt.Rows
            t4 += CInt(dr("cant"))
        Next
        txtTotal4.Text = t4.ToString("N0")

        t5 = t1 + t2 + t3 + t4
        txtTotal5.Text = t5.ToString("N0")

        If t5 > 0 Then
            txtPorc1.Text = (t1 / t5 * 100).ToString("N2") & "%"
            txtPorc2.Text = (t2 / t5 * 100).ToString("N2") & "%"
            txtPorc3.Text = (t3 / t5 * 100).ToString("N2") & "%"
            txtPorc4.Text = (t4 / t5 * 100).ToString("N2") & "%"
            txtPorc5.Text = ((t3 + t4) / t5 * 100).ToString("N2") & "%"

        Else
            txtPorc1.Text = "0.00%"
            txtPorc2.Text = "0.00%"
            txtPorc3.Text = "0.00%"
            txtPorc4.Text = "0.00%"
            txtPorc5.Text = "0.00%"

        End If
        
        lbl.Visible = False

    End Sub
    Private Sub Contrato(ByVal dt As DataTable)
        'Elimina los registros que no están incluidos en contrato
        Dim i As Integer
        Dim dr As DataRow
        Dim dt2 As New DataTable
        Dim da As OracleDataAdapter
        Dim sql As String
        Dim dv As DataView

        lbl.Text = "Eliminando sucursales fuera del contrato"
        lbl.Visible = True
        Application.DoEvents()

        sql = "SELECT DISTINCT cot.conbpc_0, cos.bpaadd_0 "
        sql &= "FROM contserv cot INNER JOIN contsuc cos ON (cot.connum_0 = cos.connum_0) "
        sql &= "WHERE rsiflg_0 = 1 AND fddflg_0 = 1 AND xsuspend_0 <> 2 "
        sql &= "ORDER BY conbpc_0, bpaadd_0"
        da = New OracleDataAdapter(sql, cn)
        da.Fill(dt2)
        da.Dispose()

        dv = New DataView(dt2)

        For i = dt.Rows.Count - 1 To 0 Step -1
            dr = dt.Rows(i)

            dv.RowFilter = "conbpc_0 = '" & dr(0).ToString & "' AND bpaadd_0 = '" & dr(1).ToString & "'"

            If dv.Count = 0 Then dt.Rows.Remove(dr)
        Next

        lbl.Visible = False

    End Sub
    Private Sub FechaIngreso(ByVal xdt As DataTable)
        'Busca para cada intervencion la fecha se retiro x hoja de ruta
        Dim Sql As String
        Dim da As OracleDataAdapter
        Dim dt As New DataTable
        Dim dr As DataRow

        Sql = "SELECT xc.fecha_0 "
        Sql &= "FROM xrutad xd INNER JOIN xrutac xc ON (xd.ruta_0 = xc.ruta_0) "
        Sql &= "WHERE tipo_0 = 'RET' AND estado_0 = 3 AND vcrnum_0 = :vcrnum_0"

        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("vcrnum_0", OracleType.VarChar)

        For Each dr In xdt.Rows
            da.SelectCommand.Parameters("vcrnum_0").Value = dr("num_0").ToString
            dt.Clear()
            da.Fill(dt)

            If dt.Rows.Count = 1 Then
                dr.BeginEdit()
                dr("ingreso") = CDate(dt.Rows(0).Item(0))
                dr.EndEdit()
            Else
                dr("ingreso") = DBNull.Value
            End If
        Next

        da.Dispose()


    End Sub

    Private Sub mnu_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mnu.Opening

        If Tab.SelectedTab Is TabPage2 Then
            e.Cancel = dgv2.SelectedRows.Count = 0

        ElseIf Tab.SelectedTab Is TabPage3 Then
            e.Cancel = dgv3.SelectedRows.Count = 0

        ElseIf Tab.SelectedTab Is TabPage4 Then
            e.Cancel = dgv4.SelectedRows.Count = 0

        Else
            e.Cancel = True

        End If

    End Sub
    Private Sub mnuIntervencion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuIntervencion.Click
        Dim txt As String = ""
        Dim rpt As New ReportDocument
        Dim f As frmCrystal

        If Tab.SelectedTab Is TabPage2 Then
            txt = dgv2.CurrentRow.Cells("col2intervencion").Value.ToString

        ElseIf Tab.SelectedTab Is TabPage3 Then
            txt = dgv3.CurrentRow.Cells("col3intervencion").Value.ToString

        ElseIf Tab.SelectedTab Is TabPage4 Then
            txt = dgv4.CurrentRow.Cells("col4intervencion").Value.ToString

        End If


        Try
            rpt.Load(RPTX3 & "itn1.rpt")
            rpt.SetParameterValue("ITN", txt)
            rpt.SetParameterValue("X3USR", usr.Codigo)

            f = New frmCrystal(rpt)
            f.MdiParent = Me.ParentForm
            f.Show()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            rpt.Close()
            rpt.Dispose() : rpt = Nothing

        End Try


    End Sub
    Private Sub mnuSegto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSegto.Click
        Dim txt As String = ""
        Dim rpt As New ReportDocument
        Dim f As frmCrystal

        If Tab.SelectedTab Is TabPage2 Then
            txt = dgv2.CurrentRow.Cells("col2intervencion").Value.ToString

        ElseIf Tab.SelectedTab Is TabPage3 Then
            txt = dgv3.CurrentRow.Cells("col3intervencion").Value.ToString

        ElseIf Tab.SelectedTab Is TabPage4 Then
            txt = dgv4.CurrentRow.Cells("col4intervencion").Value.ToString

        End If

        Try
            rpt.Load(RPTX3 & "xsegto_itn.rpt")
            rpt.SetParameterValue("itn", txt)

            f = New frmCrystal(rpt)
            f.MdiParent = Me.ParentForm
            f.Show()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            rpt.Close()
            rpt.Dispose() : rpt = Nothing

        End Try

    End Sub

End Class