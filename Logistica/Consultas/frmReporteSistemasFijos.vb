Imports System.Data.OracleClient

Public Class frmReporteSistemasFijos
    Private dtRecargas As New DataTable
    Private dtAgua As New DataTable
    Private dtDeteccion As New DataTable
    Private dtCocina As New DataTable
    Private Fecha As Date

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Fecha = Today.AddYears(-2)
    End Sub
    Private Sub Recargas()
        Dim Sql As String
        Dim da As OracleDataAdapter

        Sql = "SELECT DISTINCT itn.bpc_0 "
        Sql &= "FROM interven itn INNER JOIN "
        Sql &= "	 hdktask hdk ON (hdk.itnnum_0 = itn.num_0) INNER JOIN "
        Sql &= "	 itmmaster itm ON (itm.itmref_0 = hdk.hdtitm_0 AND itm.cfglin_0 = '451') INNER JOIN "
        Sql &= "	 bpcustomer bpc on (itn.bpc_0 = bpc.bpcnum_0) "
        Sql &= "WHERE itn.dat_0 >= :fecha AND "
        Sql &= "	  itn.zflgtrip_0 = 5"

        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("fecha", OracleType.DateTime).Value = fecha
        da.Fill(dtRecargas)
        da.Dispose()
    End Sub
    Private Sub Agua()
        Dim Sql As String
        Dim da As OracleDataAdapter

        Sql = "SELECT DISTINCT itn.bpc_0 "
        Sql &= "FROM interven itn INNER JOIN "
        Sql &= "	 hdktask hdk ON (hdk.itnnum_0 = itn.num_0) INNER JOIN "
        Sql &= "	 itmmaster itm ON (itm.itmref_0 = hdk.hdtitm_0 AND itm.cfglin_0 = '451') INNER JOIN "
        Sql &= "	 bpcustomer bpc on (itn.bpc_0 = bpc.bpcnum_0) "
        Sql &= "WHERE itn.dat_0 >= :fecha AND "
        Sql &= "	  itn.zflgtrip_0 = 5"

        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("fecha", OracleType.DateTime).Value = fecha
        da.Fill(dtAgua)
        da.Dispose()
    End Sub
    Private Sub Deteccion()
        Dim Sql As String
        Dim da As OracleDataAdapter

        Sql = "SELECT DISTINCT itn.bpc_0 "
        Sql &= "FROM interven itn INNER JOIN "
        Sql &= "	 hdktask hdk ON (hdk.itnnum_0 = itn.num_0) INNER JOIN "
        Sql &= "	 itmmaster itm ON (itm.itmref_0 = hdk.hdtitm_0 AND itm.cfglin_0 = '451') INNER JOIN "
        Sql &= "	 bpcustomer bpc on (itn.bpc_0 = bpc.bpcnum_0) "
        Sql &= "WHERE itn.dat_0 >= :fecha AND "
        Sql &= "	  itn.zflgtrip_0 = 5"

        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("fecha", OracleType.DateTime).Value = fecha
        da.Fill(dtDeteccion)
        da.Dispose()
    End Sub
    Private Sub Cocina()
        Dim Sql As String
        Dim da As OracleDataAdapter

        Sql = "SELECT DISTINCT itn.bpc_0 "
        Sql &= "FROM interven itn INNER JOIN "
        Sql &= "	 hdktask hdk ON (hdk.itnnum_0 = itn.num_0) INNER JOIN "
        Sql &= "	 itmmaster itm ON (itm.itmref_0 = hdk.hdtitm_0 AND itm.cfglin_0 = '451') INNER JOIN "
        Sql &= "	 bpcustomer bpc on (itn.bpc_0 = bpc.bpcnum_0) "
        Sql &= "WHERE itn.dat_0 >= :fecha AND "
        Sql &= "	  itn.zflgtrip_0 = 5"

        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("fecha", OracleType.DateTime).Value = fecha
        da.Fill(dtCocina)
        da.Dispose()
    End Sub

End Class