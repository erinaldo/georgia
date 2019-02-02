Imports Clases
Imports System.Data.OracleClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class Form1
    Dim bpc As New Cliente(cn)
    Dim suc As New Sucursal(cn)
    Dim tmp As New Temporal(cn, usr.Codigo, "vencimientos")
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        tmp.Abrir()
        tmp.LimpiarTabla()
        tmp.Grabar()
        Dim dt As New DataTable
        dt = pagador(TextBox1.Text)
        Dim dr As DataRow = dt.Rows(0)
        For Each dr In dt.Rows
            tmp.Abrir()
            bpc.Abrir(dr("bpcnum_0").ToString)
            'MsgBox(dr("fcyitn_0").ToString)
            If dr("fcyitn_0").ToString <> "" Then
                suc.Abrir(dr("bpcnum_0").ToString, dr("fcyitn_0").ToString)
            Else
                suc.Abrir(dr("bpcnum_0").ToString, "001")
            End If
            tmp.Nuevo()
            tmp.Cadena(0) = bpc.Codigo
            tmp.Cadena(1) = suc.Direccion
            tmp.Cadena(2) = suc.Telefono_Portero
            tmp.Cadena(3) = TextBox1.Text
            tmp.Fecha(0) = fecha(bpc.Codigo.ToString, suc.Sucursal.ToString, "652")
            tmp.Fecha(1) = fecha(bpc.Codigo.ToString, suc.Sucursal.ToString, "553")
            tmp.Fecha(2) = fecha(bpc.Codigo.ToString, suc.Sucursal.ToString, "451")
            tmp.Grabar()
        Next
        reporte()
    End Sub
    Private Sub reporte()
        Dim rpt As New ReportDocument
        Dim cliente As String = usr.Codigo
        Dim crystal As frmCrystal
        rpt.Load(RPTX3 & "XREPORTL.rpt")
        rpt.SetDatabaseLogon(DB_USR, DB_PWD)
        rpt.SetParameterValue("usr", cliente)
        crystal = New frmCrystal(rpt)
        crystal.MdiParent = Me.ParentForm
        crystal.Show()
    End Sub
    Private Function pagador(ByVal codigo As String) As DataTable
        Dim dt As New DataTable
        Dim da As OracleDataAdapter
        Dim sql As String
        sql = "select bpc.bpcnum_0, mac.fcyitn_0 from bpcustomer bpc left join machines mac on (bpc.bpcnum_0 = mac.bpcnum_0) where bpcpyr_0 = :pagador group by bpc.bpcnum_0, mac.fcyitn_0"
        da = New OracleDataAdapter(sql, cn)
        da.SelectCommand.Parameters.Add("pagador", OracleType.VarChar).Value = codigo
        da.Fill(dt)
        Return dt
    End Function
    Private Function fecha(ByVal cliente As String, ByVal suc As String, ByVal tipo As String) As Date
        Dim dr As DataRow
        Dim dt As New DataTable
        Dim da As OracleDataAdapter
        Dim sql As String
        sql = "select datnext_0 as fecha from machines mac "
        sql &= "inner join ymacitm ym on ( mac.macnum_0 = ym.macnum_0)"
        sql &= "inner join itmmaster itm on (ym.cpnitmref_0 = itm.itmref_0)"
        sql &= "where mac.bpcnum_0 = :bpc and mac.fcyitn_0 = :suc and itm.cfglin_0 = :linea and datnext_0 >= :primero and itm.ITMREF_0 not in ('553011') and mac.xitn_0 <> 'X0' "
        sql &= " order by datnext_0 asc"
        da = New OracleDataAdapter(sql, cn)
        da.SelectCommand.Parameters.Add("bpc", OracleType.VarChar).Value = cliente
        da.SelectCommand.Parameters.Add("suc", OracleType.VarChar).Value = suc
        da.SelectCommand.Parameters.Add("linea", OracleType.VarChar).Value = tipo
        da.SelectCommand.Parameters.Add("primero", OracleType.DateTime).Value = New Date(Year(Today), Month(Today), 1)
        da.Fill(dt)
        If dt.Rows.Count = 0 Then
            sql = "select datnext_0 as fecha from machines mac "
            sql &= "inner join ymacitm ym on ( mac.macnum_0 = ym.macnum_0)"
            sql &= "inner join itmmaster itm on (ym.cpnitmref_0 = itm.itmref_0)"
            sql &= "where mac.bpcnum_0 = :bpc and mac.fcyitn_0 = :suc and itm.cfglin_0 = :linea and datnext_0 <= :primero and itm.ITMREF_0 not in ('553011')and mac.xitn_0 <> 'X0' "
            sql &= " order by datnext_0 desc"
            da = New OracleDataAdapter(sql, cn)
            da.SelectCommand.Parameters.Add("bpc", OracleType.VarChar).Value = cliente
            da.SelectCommand.Parameters.Add("suc", OracleType.VarChar).Value = suc
            da.SelectCommand.Parameters.Add("linea", OracleType.VarChar).Value = tipo
            da.SelectCommand.Parameters.Add("primero", OracleType.DateTime).Value = New Date(Year(Today), Month(Today), 1)
            da.Fill(dt)
        End If
        If dt.Rows.Count = 0 Then Return CDate("31/12/1599")
        dr = dt.Rows(0)
        Return CDate(dr("fecha"))
    End Function
End Class