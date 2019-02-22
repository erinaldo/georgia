Imports System.Data.OracleClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class frmComisiones
    Private FechaDesde As Date
    Private FechaHasta As Date
    Private dtComisiones As New DataTable
    Private Tmp As Temporal

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim Sql As String
        Dim da As OracleDataAdapter
        Dim dt As New DataTable
        'Indica el % de cobro de la factura
        Dim PorcentajeCobrado As Double
        Dim TotalFactura As Double
        Dim TotalCobrado As Double

        Button1.Enabled = False

        Label1.Text = "Eliminando último cálculo"
        Application.DoEvents()

        'Inicio objeto de tabla temporal
        Tmp = New Temporal(cn, usr.Codigo, "COMI")
        Tmp.Abrir()
        Tmp.LimpiarTabla()
        Tmp.Grabar()

        Label1.Text = "Cargando tabla de alicuotas"
        Application.DoEvents()

        'Cargo la tabla de alicuotas de comisiones
        Sql = "SELECT * FROM xcomision"
        da = New OracleDataAdapter(Sql, cn)
        da.Fill(dtComisiones)

        'Fijo la fecha de proceso de comisiones
        FechaDesde = mCal.SelectionRange.Start
        FechaDesde = FechaDesde.AddDays(-1 * (FechaDesde.Day - 1))
        FechaHasta = FechaDesde.AddMonths(1).AddDays(-1)


        Label1.Text = "Obteniendo datos"
        Application.DoEvents()

        'Sql para consultar recibos creados en el mes
        Sql = "select sih.bpr_0, pth.dat_0, pth.num_0, ptd.amtloc_0, sih.accdat_0, ptd.vcrnum_0, sih.amtati_0, sid.itmref_0, itm.tsicod_4, itm.tsicod_1, sid.amtnotlin_0, xvc.bprrat_0 "
        Sql &= "from paypth pth inner join"
        Sql &= "	 paypthdoc ptd on (pth.num_0 = ptd.num_0) inner join"
        Sql &= "	 sinvoice sih on (ptd.vcrnum_0 = sih.num_0) inner join"
        Sql &= "	 sinvoiced sid on (sih.num_0 = sid.num_0) inner join"
        Sql &= "     xvcrcom xvc on (sid.num_0 =  xvc.vcrnum_0 AND sid.sidlin_0 = xvc.vcrlin_0) inner join"
        Sql &= "     itmmaster itm on (sid.itmref_0 = itm.itmref_0) "
        Sql &= "where pth.typ_0 = 2 and"
        Sql &= "	  itm.tsicod_3 = '304' and"
        Sql &= "	  pth.dat_0 >= :FechaDesde AND pth.dat_0 <= :FechaHasta AND "
        Sql &= "	  sih.accdat_0 >= to_date('01/02/2019', 'dd/mm/yyyy')  "
        Sql &= "order by accdat_0"
        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("FechaDesde", OracleType.DateTime).Value = FechaDesde
        da.SelectCommand.Parameters.Add("FechaHasta", OracleType.DateTime).Value = FechaHasta
        da.Fill(dt)

        pb.Value = 0
        pb.Minimum = 0
        pb.Maximum = dt.Rows.Count

        Dim Max As Integer = dt.Rows.Count

        For Each dr As DataRow In dt.Rows

            pb.Value += 1
            Label1.Text = "Recibo " & pb.Value & " de " & Max.ToString
            Application.DoEvents()


            'Calculo que porcentaje se cobro de la factura
            TotalFactura = CDbl(dr("amtati_0"))
            TotalCobrado = CDbl(dr("amtloc_0"))
            PorcentajeCobrado = TotalCobrado / TotalFactura

            'Creo un nuevo registro
            Tmp.Nuevo()
            'Fecha factura
            Tmp.Fecha(0) = CDate(dr("accdat_0"))
            'Fecha recibo
            Tmp.Fecha(1) = CDate(dr("dat_0"))
            'Numero de recibo
            Tmp.Cadena(0) = dr("num_0").ToString
            'Codigo de Cliente
            Tmp.Cadena(1) = dr("bpr_0").ToString
            'Numero de Factura
            Tmp.Cadena(2) = dr("vcrnum_0").ToString
            'Codigo de Articulo
            Tmp.Cadena(3) = dr("itmref_0").ToString
            'Familias 5 y 2
            Tmp.Cadena(4) = dr("tsicod_4").ToString
            Tmp.Cadena(5) = dr("tsicod_1").ToString
            'Importe AI de la linea del artículo
            Tmp.Numero(0) = CDbl(dr("amtnotlin_0"))
            'Honorario del cliente
            Tmp.Numero(1) = CDbl(dr("bprrat_0"))
            'Alicuota comision articulo segun familias
            Tmp.Numero(2) = Alicuota(dr("tsicod_4").ToString, dr("tsicod_1").ToString)
            'Cobrado (%)
            Tmp.Numero(3) = PorcentajeCobrado

        Next

        Label1.Text = "Grabando"
        Application.DoEvents()
        Application.DoEvents()

        Tmp.Grabar()

        Button1.Enabled = True

        Label1.Text = "Listo!"
        Application.DoEvents()
        MessageBox.Show("Listo!")

        Label1.Text = "Abriendo reporte"
        Application.DoEvents()

        'Abro Crystal con los resultados
        Dim rpt As New ReportDocument

        rpt.Load(RPTX3 & "XBONANNO.rpt")
        rpt.SetDatabaseLogon(DB_USR, DB_PWD)
        rpt.SetParameterValue("USR", usr.Codigo)

        Dim f = New frmCrystal(rpt)
        f.MdiParent = Me.ParentForm
        f.Show()

        Label1.Text = ""
        Application.DoEvents()

    End Sub
    Private Function Alicuota(ByVal Fam5 As String, ByVal Fam2 As String) As Double
        Dim Valor As Double = 0

        For Each dr As DataRow In dtComisiones.Rows
            If dr("fam5_0").ToString = Fam5 And dr("fam2_0").ToString = Fam2 Then
                Valor = CDbl(dr("alicuota_0"))
                Exit For
            End If
        Next

        Return Valor
    End Function

End Class