Imports System.Data.OracleClient

Public Class frmVentas1
    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        Dim Sql As String
        Dim da As OracleDataAdapter
        Dim dt As New DataTable

        btnConsultar.Enabled = False
        Me.UseWaitCursor = True
        Label1.Text = "Recuperando vendedores..."
        Label1.Visible = True
        Application.DoEvents()

        'Recupero todos los vendedores
        Sql = "SELECT repnum_0, repnam_0, 0 as total, 0 as Activos, 0 AS Regulares, 0 AS Recuperados, 0 AS Recuperar, 0 AS Nuevos, 0 AS Facturas, 0 AS Facturados "
        Sql &= "FROM salesrep "
        Sql &= "WHERE repnum_0 BETWEEN '00' and '99'"
        da = New OracleDataAdapter(Sql, cn)
        da.Fill(dt)

        dgv.DataSource = dt

        Application.DoEvents()

        CarteraTotal(dt)
        Activos(dt)
        Regulares(dt)
        Recuperados(dt)
        Recuperar(dt)
        Nuevos(dt)
        Facturas(dt)
        ClientesFacturas(dt)
        Totales(dt)

        Label1.Visible = False
        btnConsultar.Enabled = True
        Me.UseWaitCursor = False


    End Sub
    Private Sub CarteraTotal(ByVal dt2 As DataTable)
        'Todos los clientes activos
        Dim Sql As String
        Dim da As OracleDataAdapter
        Dim dt1 As New DataTable
        Dim Fecha As Date

        Label1.Text = "Recuperando Cartera Total..."
        Application.DoEvents()

        Fecha = New Date(dtp.Value.Year, dtp.Value.Month, 1)

        Sql = "SELECT rep_0, COUNT(bpcnum_0) "
        Sql &= "FROM bpcustomer "
        Sql &= "WHERE bpctyp_0 = 1 AND bpcsta_0 = 2 "
        Sql &= "GROUP BY rep_0 "
        Sql &= "ORDER BY rep_0 "

        da = New OracleDataAdapter(Sql, cn)
        da.Fill(dt1)

        Merge(dt1, dt2, "total")

    End Sub
    Private Sub Activos(ByVal dt2 As DataTable)
        'Todos los clientes que tienen una factura en los ultimos 18 meses
        Dim Sql As String
        Dim da As OracleDataAdapter
        Dim dt1 As New DataTable
        Dim Fecha As Date

        Label1.Text = "Buscando Clientes Activos..."
        Application.DoEvents()

        Fecha = New Date(dtp.Value.Year, dtp.Value.Month, 1)

        Sql = "SELECT bpc.rep_0, COUNT(DISTINCT bpr_0) "
        Sql &= "FROM (sinvoice sih INNER JOIN sinvoicev siv ON (sih.num_0 = siv.num_0)) INNER JOIN bpcustomer bpc ON (sih.bpr_0 = bpc.bpcnum_0) "
        Sql &= "WHERE accdat_0 >= :fecha_ini AND accdat_0 < :fecha_fin  AND sih.invtyp_0 = 1 "
        Sql &= "GROUP by bpc.rep_0"

        da = New OracleDataAdapter(Sql, cn)
        With da.SelectCommand.Parameters
            .Add("fecha_ini", OracleType.DateTime).Value = Fecha.AddMonths(-18)
            .Add("fecha_fin", OracleType.DateTime).Value = Fecha.AddMonths(1)
        End With

        da.Fill(dt1)

        Merge(dt1, dt2, "activos")

    End Sub
    Private Sub Regulares(ByVal dt2 As DataTable)
        'Todos los clientes que tienen más de una factura en los ultimos 11 meses
        Dim Sql As String
        Dim da As OracleDataAdapter
        Dim dt1 As New DataTable
        Dim Fecha As Date

        Label1.Text = "Buscando Clientes Regulares..."
        Application.DoEvents()

        Fecha = New Date(dtp.Value.Year, dtp.Value.Month, 1)

        Sql = "SELECT rep_0, COUNT(bpr_0) FROM ( "
        Sql &= "    SELECT bpc.rep_0, bpr_0, count(sih.num_0) "
        Sql &= "    FROM (sinvoice sih INNER JOIN sinvoicev siv ON (sih.num_0 = siv.num_0)) INNER JOIN bpcustomer bpc ON (sih.bpr_0 = bpc.bpcnum_0) "
        Sql &= "    WHERE accdat_0 >= :fecha_ini AND accdat_0 < :fecha_fin AND sih.invtyp_0 = 1 "
        Sql &= "    GROUP by bpc.rep_0, bpr_0 "
        Sql &= "    HAVING count(sih.num_0) > 1 "
        Sql &= "    ORDER BY bpc.rep_0, bpr_0 "
        Sql &= ") "
        Sql &= "GROUP BY rep_0 "
        Sql &= "ORDER BY rep_0"

        da = New OracleDataAdapter(Sql, cn)
        With da.SelectCommand.Parameters
            .Add("fecha_ini", OracleType.DateTime).Value = Fecha.AddMonths(-11)
            .Add("fecha_fin", OracleType.DateTime).Value = Fecha.AddMonths(1)
        End With

        da.Fill(dt1)

        Merge(dt1, dt2, "regulares")

    End Sub
    Private Sub Recuperados(ByVal dt2 As DataTable)
        'Clientes con factura en el mes seleccionado y sin facturas en los
        'ultimos 12 meses anteriores
        Dim Sql As String
        Dim da As OracleDataAdapter
        Dim dt1 As New DataTable
        Dim Fecha As Date

        Label1.Text = "Buscando Clientes Recuperados..."
        Application.DoEvents()

        Fecha = New Date(dtp.Value.Year, dtp.Value.Month, 1)

        Sql = "SELECT bpc.rep_0, count(bpr_0) "
        Sql &= "FROM (sinvoice sih INNER JOIN sinvoicev siv ON (sih.num_0 = siv.num_0)) INNER JOIN bpcustomer bpc ON (sih.bpr_0 = bpc.bpcnum_0) "
        Sql &= "WHERE sih.invtyp_0 = 1 AND accdat_0 >= :fecha1_ini AND accdat_0 < :fecha1_fin AND bpr_0 NOT IN ( "
        Sql &= "	  SELECT bpr_0 "
        Sql &= "	  FROM sinvoice "
        Sql &= "	  WHERE accdat_0 >= :fecha2_ini AND accdat_0 < :fecha2_fin  AND invtyp_0 = 1 "
        Sql &= ") "
        Sql &= "GROUP BY rep_0 "
        Sql &= "ORDER by rep_0 "

        da = New OracleDataAdapter(Sql, cn)
        With da.SelectCommand.Parameters
            'Mes seleccionado
            .Add("fecha1_ini", OracleType.DateTime).Value = Fecha
            .Add("fecha1_fin", OracleType.DateTime).Value = Fecha.AddMonths(1)
            'Ultimos 12 meses
            .Add("fecha2_ini", OracleType.DateTime).Value = Fecha.AddYears(-1)
            .Add("fecha2_fin", OracleType.DateTime).Value = Fecha
        End With

        da.Fill(dt1)

        Merge(dt1, dt2, "recuperados")

    End Sub
    Private Sub Recuperar(ByVal dt2 As DataTable)
        'Clientes que no compraron en los ultimos 13 meses
        Dim Sql As String
        Dim da As OracleDataAdapter
        Dim dt1 As New DataTable
        Dim Fecha As Date

        Label1.Text = "Buscando Clientes a Recuperar..."
        Application.DoEvents()

        Fecha = New Date(dtp.Value.Year, dtp.Value.Month, 1)

        Sql = "SELECT rep_0, COUNT(bpcnum_0) "
        Sql &= "FROM bpcustomer "
        Sql &= "WHERE bpcsta_0 = 2 AND bpctyp_0 = 1 AND bpcnum_0 NOT IN ( "
        Sql &= "	  SELECT DISTINCT bpr_0 "
        Sql &= "	  FROM sinvoice "
        Sql &= "	  WHERE accdat_0 >= :fecha_ini AND accdat_0 < :fecha_fin AND invtyp_0 = 1 "
        Sql &= ") "
        Sql &= "GROUP BY rep_0 "
        Sql &= "ORDER by rep_0 "

        da = New OracleDataAdapter(Sql, cn)
        With da.SelectCommand.Parameters
            'Mes seleccionado
            .Add("fecha_ini", OracleType.DateTime).Value = Fecha.AddMonths(-13)
            .Add("fecha_fin", OracleType.DateTime).Value = Fecha
        End With

        da.Fill(dt1)

        Merge(dt1, dt2, "recuperar")
    End Sub
    Private Sub Nuevos(ByVal dt2 As DataTable)
        'Clientes nuevos en el mes
        Dim Sql As String
        Dim da As OracleDataAdapter
        Dim dt1 As New DataTable
        Dim Fecha As Date

        Fecha = New Date(dtp.Value.Year, dtp.Value.Month, 1)

        Label1.Text = "Buscando Clientes nuevos..."
        Application.DoEvents()

        Fecha = New Date(dtp.Value.Year, dtp.Value.Month, 1)

        Sql = "SELECT rep_0, COUNT(bpcnum_0) "
        Sql &= "FROM bpcustomer "
        Sql &= "WHERE bpctyp_0 = 1 AND bpcsta_0 = 2 AND credat_0 >= :fecha_ini AND credat_0 < :fecha_fin "
        Sql &= "GROUP BY rep_0 "
        Sql &= "ORDER BY rep_0 "

        da = New OracleDataAdapter(Sql, cn)
        With da.SelectCommand.Parameters
            .Add("fecha_ini", OracleType.DateTime).Value = Fecha
            .Add("fecha_fin", OracleType.DateTime).Value = Fecha.AddMonths(1)
        End With

        da.Fill(dt1)

        Merge(dt1, dt2, "nuevos")

    End Sub
    Private Sub Facturas(ByVal dt2 As DataTable)
        'Cantidad de facturas realizadas en el mes
        Dim Sql As String
        Dim da As OracleDataAdapter
        Dim dt1 As New DataTable
        Dim Fecha As Date

        Label1.Text = "Calculando cantidad de facturas en el mes..."
        Application.DoEvents()

        Fecha = New Date(dtp.Value.Year, dtp.Value.Month, 1)


        Sql = "SELECT bpc.rep_0, count(sih.num_0) "
        Sql &= "FROM (sinvoice sih INNER JOIN sinvoicev siv ON (sih.num_0 = siv.num_0)) INNER JOIN bpcustomer bpc ON (sih.bpr_0 = bpc.bpcnum_0) "
        Sql &= "WHERE accdat_0 >= :fecha_ini AND accdat_0 < :fecha_fin AND sih.invtyp_0 = 1 "
        Sql &= "GROUP BY bpc.rep_0 "
        Sql &= "ORDER BY bpc.rep_0"

        da = New OracleDataAdapter(Sql, cn)
        With da.SelectCommand.Parameters
            .Add("fecha_ini", OracleType.DateTime).Value = Fecha
            .Add("fecha_fin", OracleType.DateTime).Value = Fecha.AddMonths(1)
        End With

        da.Fill(dt1)

        Merge(dt1, dt2, "Facturas")
    End Sub
    Private Sub ClientesFacturas(ByVal dt2 As DataTable)
        'Cantidad de clientes facturados en el mes
        Dim Sql As String
        Dim da As OracleDataAdapter
        Dim dt1 As New DataTable
        Dim Fecha As Date

        Label1.Text = "Calculando cantidad de clientes facturados en el mes..."
        Application.DoEvents()

        Fecha = New Date(dtp.Value.Year, dtp.Value.Month, 1)

        Sql = "SELECT rep_0, COUNT(DISTINCT bpr_0) AS cant "
        Sql &= "FROM sinvoice sih INNER JOIN bpcustomer bpc ON (bpr_0 = bpcnum_0) "
        Sql &= "WHERE accdat_0 >= :fecha_ini AND accdat_0 < :fecha_fin AND invtyp_0 = 1 "
        Sql &= "GROUP BY rep_0 "
        Sql &= "ORDER BY rep_0"

        da = New OracleDataAdapter(Sql, cn)
        With da.SelectCommand.Parameters
            .Add("fecha_ini", OracleType.DateTime).Value = Fecha
            .Add("fecha_fin", OracleType.DateTime).Value = Fecha.AddMonths(1)
        End With

        da.Fill(dt1)

        Merge(dt1, dt2, "Facturados")

    End Sub
    Private Sub Totales(ByVal dt As DataTable)
        Dim dr As DataRow
        Dim Total As Integer = 0
        Dim Activos As Integer = 0
        Dim Regulares As Integer = 0
        Dim Recuperados As Integer = 0
        Dim Recuperar As Integer = 0
        Dim Facturas As Integer = 0
        Dim Facturados As Integer = 0
        Dim Nuevos As Integer = 0

        Label1.Text = "Calculando totales..."
        Application.DoEvents()

        For Each dr In dt.Rows
            Total += CInt(dr("Total"))
            Activos += CInt(dr("Activos"))
            Regulares += CInt(dr("Regulares"))
            Recuperados += CInt(dr("Recuperados"))
            Recuperar += CInt(dr("Recuperar"))
            Nuevos += CInt(dr("Nuevos"))
            Facturas += CInt(dr("Facturas"))
            Facturados += CInt(dr("Facturados"))
        Next

        txtTotal.Text = Total.ToString("N0")
        txtActivos.Text = Activos.ToString("N0")
        txtRegulares.Text = Regulares.ToString("N0")
        txtRecuperados.Text = Recuperados.ToString("N0")
        txtRecuperar.Text = Recuperar.ToString("N0")
        txtNuevos.Text = Nuevos.ToString("N0")
        txtFacturas.Text = Facturas.ToString("N0")
        txtFacturados.Text = Facturados.ToString("N0")

    End Sub
    Private Sub Merge(ByVal dt1 As DataTable, ByVal dt2 As DataTable, ByVal campo As String)
        Dim dr1, dr2 As DataRow

        For Each dr1 In dt1.Rows
            For Each dr2 In dt2.Rows
                If dr2(0).ToString = dr1(0).ToString Then
                    dr2.BeginEdit()
                    dr2(campo) = dr1(1)
                    dr2.EndEdit()
                    Exit For
                End If
            Next
        Next

        Application.DoEvents()

    End Sub
    Private Sub frmVentas1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        colTotal.DataPropertyName = "total"
        colCod.DataPropertyName = "repnum_0"
        colVendedor.DataPropertyName = "repnam_0"
        colActivos.DataPropertyName = "activos"
        colRegulares.DataPropertyName = "regulares"
        colRecuperados.DataPropertyName = "recuperados"
        colRecuperar.DataPropertyName = "recuperar"
        colFacturas.DataPropertyName = "facturas"
        colFacturados.DataPropertyName = "facturados"
        colNuevos.DataPropertyName = "nuevos"

    End Sub

End Class