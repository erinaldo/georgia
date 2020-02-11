Imports System.Data.OracleClient

Public Class frmTazaCierrePresupuestos

    Private PesosTotal As Double
    Private PesosAprobados As Double
    Private PesosNoAprobados As Double
    Private CantTotal As Integer
    Private CantAprobados As Integer
    Private CantNoAprobados As Integer

    Private dt As New DataTable

    Private Sub btnCalcular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalcular.Click

        btnCalcular.Enabled = False
        Application.DoEvents()
        Application.DoEvents()
        Application.DoEvents()

        If chkNuevos.Checked Then CalculoNuevo()
        If chkRecargas.Checked Then CalculoRecarga()

        btnCalcular.Enabled = True

    End Sub
    Private Sub ConsultarDatos(ByVal Tipo As Integer)
        Dim da As OracleDataAdapter
        Dim Sql As String

        Sql = "SELECT distinct xco.nro_0, sqh.sqhnum_0, sqh.quodat_0, sqh.quoinvnot_0, soh_0 "
        Sql &= "FROM xcotiza   xco INNER JOIN "
        Sql &= "	    xcotizad  xcd on (xco.nro_0 = xcd.nro_0) INNER JOIN"
        Sql &= "	    itmmaster itm on (xcd.itmref_0 = itm.itmref_0) inner join"
        Sql &= "  	xprecios  xpe on (xpe.itmref_0 = itm.itmref_0) inner join   "
        Sql &= "	    squote    sqh on (xco.sqh_0    = sqh.sqhnum_0) "
        Sql &= "WHERE sqh_0 <> ' ' AND "
        Sql &= "	  dat_0 BETWEEN :FechaDesde AND :FechaHasta AND"
        Sql &= "	  xduplica_0 <> 2 and"
        Sql &= "	  xpe.ped_0 = :tipo " '1=Recarga 2=Pedidos
        Sql &= "ORDER BY nro_0 desc"
        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("FechaDesde", OracleType.DateTime).Value = mc.SelectionRange.Start
        da.SelectCommand.Parameters.Add("FechaHasta", OracleType.DateTime).Value = mc.SelectionRange.End
        da.SelectCommand.Parameters.Add("tipo", OracleType.Number).Value = Tipo

        dt.Clear()
        da.Fill(dt)

    End Sub
    Private Sub CalculoNuevo()

        Dim dr As DataRow

        ConsultarDatos(2)

        For Each dr In dt.Rows
            If dr("soh_0").ToString.Trim <> "" Then
                CantAprobados += 1
                PesosAprobados += CDbl(dr("quoinvnot_0"))
            Else
                CantNoAprobados += 1
                PesosNoAprobados += CDbl(dr("quoinvnot_0"))
            End If

            CantTotal += 1
            PesosTotal += CDbl(dr("quoinvnot_0"))
        Next

        MostrarDatos()

    End Sub
    Private Sub CalculoRecarga()
        Dim dr As DataRow
        Dim ctz As New Cotizacion(cn)

        ConsultarDatos(1)

        For Each dr In dt.Rows

            ctz.Abrir(CLng(dr("nro_0")))

            If ctz.TieneIntervencion Then
                CantAprobados += 1
                PesosAprobados += CDbl(dr("quoinvnot_0"))
            Else
                CantNoAprobados += 1
                PesosNoAprobados += CDbl(dr("quoinvnot_0"))
            End If

            CantTotal += 1
            PesosTotal += CDbl(dr("quoinvnot_0"))
        Next


        MostrarDatos()

    End Sub
    Private Sub MostrarDatos()

        txtCantAprobados.Text = CantAprobados.ToString
        txtCantNoAprobados.Text = CantNoAprobados.ToString
        txtCantTotal.Text = CantTotal.ToString

        txtPesosAprobados.Text = PesosAprobados.ToString("N2")
        txtPesosNoAprobados.Text = PesosNoAprobados.ToString("N2")
        txtPesosTotal.Text = PesosTotal.ToString("N2")

        lblCant.Text = (CantAprobados / CantTotal * 100).ToString("N2") & "%"
        lblPesos.Text = (PesosAprobados / PesosTotal * 100).ToString("N2") & "%"

    End Sub

End Class