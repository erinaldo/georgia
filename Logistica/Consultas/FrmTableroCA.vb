Imports System.Data.OracleClient

Public Class FrmTableroCA
    Dim da As OracleDataAdapter
    Dim dt As DataTable
    Dim Sql As String
    Dim FechaInicio As Date
    Dim FechaFin As Date

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalcular.Click

        FechaFin = Calendar.SelectionRange.Start
        FechaInicio = New Date(FechaFin.Year, FechaFin.Month, 1)

        lbl.Text = "Consulta desde " & FechaInicio.ToString("dd/MM/yy") & " hasta " & FechaFin.ToString("dd/MM/yy")
        lbl.Visible = True

        TxtBoxCantidadOperaciones.Text = CantidadOperaciones.ToString
        TxtBoxCantRecargasFacturadas.Text = CantidadRecargasFacturadas.ToString
        TxtBoxCant639.Text = Cantidad639Aprobadas.ToString
        TxtBoxFacturacion.Text = Facturacion.ToString("N2")
        TxtBoxClientes.Text = ClientesNuevosoRecuperados.ToString

    End Sub
    Private Function CantidadOperaciones() As Integer
        Dim dt As New DataTable
        Dim facturas As Integer = 0
        Dim abo As Integer = 0

        Sql = "SELECT to_char(sih.accdat_0, 'YYYY-MM') AS mes , sih.sivtyp_0 AS tipo, count(*) AS facturas "
        Sql &= "FROM sinvoice sih INNER JOIN "
        Sql &= "     sinvoicev siv on (sih.num_0 = siv.num_0) "
        Sql &= "WHERE rep_0 IN ('CA', 'CAA') and "
        Sql &= "      (sih.sivtyp_0 = 'FAC' and sihori_0 in (3, 8) or sih.sivtyp_0 = 'ABO' and sihori_0 in (6)) AND "
        Sql &= "      accdat_0 >= :datini AND accdat_0 <= :datfin "
        Sql &= "GROUP BY to_char(sih.accdat_0, 'YYYY-MM'), sih.sivtyp_0 "

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
        Sql &= "     sinvoicev siv on (sih.num_0 = siv.num_0) inner join "
        Sql &= "     sinvoiced sivd on (sih.num_0 = sivd.num_0) "
        Sql &= "where rep_0 in ('CA', 'CAA') and "
        Sql &= "      accdat_0 >= :datini and accdat_0 <= :datfin and "
        Sql &= "      (sivd.tsicod_3 = '303' and sivd.TSICOD_4	= '521') "
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
        Sql &= "where constrdat_0 >= :datini and constrdat_0 <= :datfin AND "
        Sql &= "      salrep_0 IN ('CA', 'CAA') AND "
        Sql &= "      itmref_0 in ('553010','553015','553016','553017')"

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
        Sql = "SELECT sum(sih.amtnot_0 * sns_0) AS Facturacion "
        Sql &= "FROM sinvoice sih inner join "
        Sql &= "     sinvoicev siv on (sih.num_0 = siv.num_0) "
        Sql &= "WHERE rep_0 in ('CA', 'CAA') AND "
        Sql &= "      accdat_0 >= :datini and accdat_0 <= :datfin "
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
        Sql &= "     sinvoicev siv on (sih.num_0 = siv.num_0) "
        Sql &= "where rep_0 in ('CA', 'CAA') and "
        Sql &= "      sih.invtyp_0 = 1 and "
        Sql &= "      sih.accdat_0 >= :datini and sih.accdat_0 <= :datfin and "
        Sql &= "      sih.bpr_0 not in ("
        Sql &= "	  	select distinct bpr_0 "
        Sql &= "        from(sinvoice) "
        Sql &= "        where accdat_0 >= :dat and accdat_0 <= :datini and "
        Sql &= "        sivtyp_0 = 'FAC') "

        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("datini", OracleType.DateTime).Value = FechaInicio
        da.SelectCommand.Parameters.Add("datfin", OracleType.DateTime).Value = FechaFin
        da.SelectCommand.Parameters.Add("dat", OracleType.DateTime).Value = FechaInicio.AddYears(-2)
        da.Fill(dt)

        dr = dt.Rows(0)
        Return CInt(dr("cantidad").ToString)
    End Function

End Class