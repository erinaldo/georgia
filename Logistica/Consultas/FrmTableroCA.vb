Imports System.Data.OracleClient

Public Class FrmTableroCA
    Dim da As OracleDataAdapter
    Dim dt As DataTable
    Dim Sql As String
    Dim FechaInicio As Date
    Dim FechaFin As Date
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        FechaInicio = New Date(Calendar.SelectionRange.End.Year, Calendar.SelectionRange.End.Month, 1)
        FechaFin = Calendar.SelectionRange.End
        TxtBoxCantidadOperaciones.Text = CantidadOperaciones.ToString
        TxtBoxCantRecargasFacturadas.Text = CantidadRecargasFacturadas.ToString
        TxtBoxCant639.Text = Cantidad639Aprobadas.ToString
        TxtBoxFacturacion.Text = Facturacion.ToString
        TxtBoxClientes.Text = ClientesNuevosoRecuperados.ToString

    End Sub
    Private Function CantidadOperaciones() As Integer
        Dim dt As New DataTable
        Dim facturas As Integer = 0
        Dim abo As Integer = 0


        Sql = "select to_char(sih.accdat_0, 'YYYY-MM') AS mes , sih.sivtyp_0 as tipo, count(*) as facturas "
        Sql &= "from sinvoice sih inner join "
        Sql &= "sinvoicev siv on (sih.num_0 = siv.num_0) "
        Sql &= "where rep_0 in ('CA', 'CAA') and "
        Sql &= " (sih.sivtyp_0 = 'FAC' and sihori_0 in (3, 8) "
        Sql &= " or "
        Sql &= "sih.sivtyp_0 = 'ABO' and sihori_0 in (6)) "
        Sql &= " and accdat_0 >= :datini and accdat_0 <= :datfin "
        Sql &= "group by to_char(sih.accdat_0, 'YYYY-MM'), sih.sivtyp_0 "
        'Sql &= "order by mes, sivtyp_0 "

        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("datini", OracleType.DateTime).Value = FechaInicio
        da.SelectCommand.Parameters.Add("datfin", OracleType.DateTime).Value = FechaFin

        da.Fill(dt)
        For Each dr As DataRow In dt.Rows
            If dr("tipo").ToString = "ABO" Then
                abo = CInt(dr("facturas"))
            ElseIf dr("tipo").ToString = "FAC" Then
                facturas = CInt(dr("facturas"))
            End If
        Next

        Return Math.Abs(facturas - abo)
    End Function
    Private Function CantidadRecargasFacturadas() As Integer
        Dim dt As New DataTable
        Dim recargas As Integer = 0
        Dim abo As Integer = 0
        FechaFin = Calendar.SelectionRange.End

        Sql = "select to_char(sih.accdat_0, 'YYYY-MM') AS mes , sih.sivtyp_0 as tipo, sum(qty_0) as recargas "
        Sql &= "from sinvoice sih inner join "
        Sql &= "sinvoicev siv on (sih.num_0 = siv.num_0) "
        Sql &= "inner join  sinvoiced sivd on (sih.num_0 = sivd.num_0) "
        Sql &= "where rep_0 in ('CA', 'CAA') "
        Sql &= " and accdat_0 >= :datini and accdat_0 <= :datfin "
        Sql &= "and (sivd.tsicod_3 = '303' and sivd.TSICOD_4	= '521') "
        Sql &= "group by to_char(sih.accdat_0, 'YYYY-MM'), sih.sivtyp_0 "


        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("datini", OracleType.DateTime).Value = FechaInicio
        da.SelectCommand.Parameters.Add("datfin", OracleType.DateTime).Value = FechaFin

        da.Fill(dt)
        For Each dr As DataRow In dt.Rows
            If dr("tipo").ToString = "ABO" Then
                abo = CInt(dr("recargas"))
            ElseIf dr("tipo").ToString = "FAC" Then
                recargas = CInt(dr("recargas"))
            End If
        Next

        Return Math.Abs(recargas - abo)
    End Function
    Private Function Cantidad639Aprobadas() As Integer
        Dim dt As New DataTable
        Dim dr As DataRow
        Sql = "select count(*) as cantidad from CONTSERV  "
        Sql &= "where (constrdat_0 >= :datini and constrdat_0 <= :datfin) "
        Sql &= "and (Salrep_0 = 'CA' or salrep_0 = 'CAA') "
        Sql &= "and itmref_0 in ('553010','553015','553016','553017')"

        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("datini", OracleType.DateTime).Value = FechaInicio
        da.SelectCommand.Parameters.Add("datfin", OracleType.DateTime).Value = FechaFin
        da.Fill(dt)
        dr = dt.Rows(0)
        Return CInt(dr("cantidad").ToString)
    End Function
    Private Function Facturacion() As Double
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim valor As String
        Sql = "select sum(sih.amtnot_0 * sns_0) as Facturacion "
        Sql &= "from sinvoice sih inner join "
        Sql &= "sinvoicev siv on (sih.num_0 = siv.num_0) "
        Sql &= "where rep_0 in ('CA', 'CAA') "
        Sql &= "and (accdat_0 >= :datini and accdat_0 <= :datfin) "
        Sql &= "AND sih.sivtyp_0 <> 'PRF' "

        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("datini", OracleType.DateTime).Value = FechaInicio
        da.SelectCommand.Parameters.Add("datfin", OracleType.DateTime).Value = FechaFin

        da.Fill(dt)
        dr = dt.Rows(0)
        valor = dr("Facturacion").ToString
        Return CDbl(IIf(valor = "", 0, valor))
    End Function
    Private Function ClientesNuevosoRecuperados() As Integer
        Dim dt As New DataTable
        Dim dr As DataRow
        Sql = "select COUNT(*)  as cantidad "
        Sql &= "from sinvoice sih inner join "
        Sql &= "sinvoicev siv on (sih.num_0 = siv.num_0) "
        Sql &= "where rep_0 in ('CA', 'CAA') and "
        Sql &= "sih.sivtyp_0 = 'FAC' and "
        Sql &= "sih.accdat_0 >= :datini and sih.accdat_0 <= :datfin and "
        Sql &= "sih.bpr_0 not in ("
        Sql &= "	  	select distinct bpr_0 "
        Sql &= "        from(sinvoice) "
        Sql &= "        where accdat_0 >= :dat and accdat_0 < :datini and "
        Sql &= "        sivtyp_0 = 'FAC') "

        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("datini", OracleType.DateTime).Value = FechaInicio
        da.SelectCommand.Parameters.Add("datfin", OracleType.DateTime).Value = FechaFin
        da.SelectCommand.Parameters.Add("dat", OracleType.DateTime).Value = New Date(FechaInicio.Year - 2, FechaInicio.Month, FechaInicio.Day)
        da.Fill(dt)

        dr = dt.Rows(0)
        Return CInt(dr("cantidad").ToString)
    End Function
End Class