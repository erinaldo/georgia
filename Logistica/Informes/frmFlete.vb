Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.OracleClient
Imports Clases

Public Class frmFlete

    Private tmp1 As New Temporal(cn, usr, "FLETES")
    Private tmp2 As New Temporal(cn, usr, "ACOMP")
    Private dtTarifas As DataTable
    Private CantBaseCFE As Integer
    Private CantBaseGBA As Integer
    Private Minutos As Double
    Private MinutosCfe As Double
    Private MinutosGba As Double
    Private Peso As Double
    Private PesoCfe As Double
    Private PesoGba As Double
    Private RutaActual As Integer = 0
    Private FechaRuta As Date
    Private DomiciliosCfe As Integer
    Private DomiciliosGba As Integer
    Private Acomp1 As Integer = 0
    Private Acomp2 As Integer = 0
    'Private bpt As String
    'Private pat As String
    Private Vehiculo As New Camioneta(cn)
    Private ruta As New Ruta(cn)


    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
    Private Sub frmFlete_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim mnu As New MenuLocal(cn, False)

        mnu.AbrirMenu(2408, False)
        mnu.EliminarCodigoIgual("N")
        mnu.Enlazar(lstAcompanantes)
        MarcarTodos(True)

    End Sub
    Private Sub CargarTarifas()
        Dim Sql As String
        Dim da As OracleDataAdapter

        Sql = "SELECT * FROM xtarflete ORDER BY kg_0"
        da = New OracleDataAdapter(Sql, cn)
        dtTarifas = New DataTable
        da.Fill(dtTarifas)
        da.Dispose()

        'Recupero las cantidades base para CFE y GBA
        For Each dr As DataRow In dtTarifas.Rows
            If CDbl(dr("kg_0")) = -3 Then
                CantBaseCFE = CInt(dr("cfe_0"))
                CantBaseGBA = CInt(dr("gba_0"))
            End If
        Next

    End Sub
    Private Sub btnCalcular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalcular.Click
        Dim rpt As ReportDocument

        tmp1.Abrir()
        tmp2.Abrir()
        tmp1.LimpiarTabla()
        tmp2.LimpiarTabla()

        btnCalcular.Enabled = False
        dtpDesde.Enabled = False
        dtpHasta.Enabled = False

        crv1.ReportSource = Nothing
        crv2.ReportSource = Nothing

        Application.DoEvents()
        Application.DoEvents()

        CargarTarifas()

        Rutas()

        rpt = New ReportDocument
        rpt.Load(RPTX3 & "XFLETE.rpt")
        rpt.SetParameterValue("X3USR", usr.Codigo)
        rpt.SetDatabaseLogon(DB_USR, DB_PWD)
        crv1.ReportSource = rpt

        Application.DoEvents()
        Application.DoEvents()

        rpt = New ReportDocument
        rpt.Load(RPTX3 & "XACOMP.rpt")
        rpt.SetParameterValue("X3USR", usr.Codigo)
        rpt.SetParameterValue("DETALLE", chkDetallado.Checked)
        rpt.SetDatabaseLogon(DB_USR, DB_PWD)
        crv2.ReportSource = rpt

        btnCalcular.Enabled = True
        dtpDesde.Enabled = True
        dtpHasta.Enabled = True

    End Sub
    Private Sub Rutas()
        'Recupero todas las rutas y clientes a calcular
        Dim dt As New DataTable
        Dim dr As DataRow = Nothing
        Dim da As OracleDataAdapter
        Dim Sql As String

        Sql = "SELECT DISTINCT c.ruta_0, c.fecha_0, cliente_0, ' ' as suc_0, transporte_0, patente_0, bpa.sat_0, c.acomp_0, c.acomp_1, interno_0, bpagcba_0, bpaaddnro_0 "
        Sql &= "FROM xrutac c INNER JOIN xrutad d ON (c.ruta_0 = d.ruta_0) "
        Sql &= "     INNER JOIN bpaddress bpa ON (d.cliente_0 = bpa.bpanum_0 AND d.suc_0 = bpa.bpaadd_0) "
        Sql &= "     INNER JOIN zunitrans zun ON (transporte_0 = bptnum_0 AND patente_0 = patnum_0) "
        Sql &= "WHERE c.fecha_0 BETWEEN :desde AND :hasta AND "
        Sql &= "	  estado_0 in (2, 3) AND "
        Sql &= "	  tipo_0 in ('RET', 'ENT', 'NUE', 'NCI', 'CTL') AND "
        Sql &= "      sat_0 = 'CFE' "

        Sql &= "UNION "

        Sql &= "SELECT DISTINCT c.ruta_0, c.fecha_0, cliente_0, suc_0, transporte_0, patente_0, bpa.sat_0, c.acomp_0, c.acomp_1, interno_0, bpagcba_0, bpaaddnro_0 "
        Sql &= "FROM xrutac c INNER JOIN xrutad d ON (c.ruta_0 = d.ruta_0) "
        Sql &= "     INNER JOIN bpaddress bpa ON (d.cliente_0 = bpa.bpanum_0 AND d.suc_0 = bpa.bpaadd_0) "
        Sql &= "     INNER JOIN zunitrans zun ON (transporte_0 = bptnum_0 AND patente_0 = patnum_0) "
        Sql &= "WHERE c.fecha_0 BETWEEN :desde AND :hasta AND "
        Sql &= "	  estado_0 in (2, 3) AND "
        Sql &= "	  tipo_0 in ('RET', 'ENT', 'NUE', 'NCI', 'CTL') AND "
        Sql &= "      sat_0 <> 'CFE' "
        Sql &= "ORDER BY ruta_0, cliente_0, suc_0"

        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("desde", OracleType.DateTime).Value = New Date(dtpDesde.Value.Year, dtpDesde.Value.Month, dtpDesde.Value.Day)
        da.SelectCommand.Parameters.Add("hasta", OracleType.DateTime).Value = New Date(dtpHasta.Value.Year, dtpHasta.Value.Month, dtpHasta.Value.Day)

        da.Fill(dt)

        With pb
            .Value = 0
            .Minimum = 0
            .Maximum = dt.Rows.Count
        End With

        For i As Integer = 0 To dt.Rows.Count - 1
            pb.Value += 1
            Application.DoEvents()
            Application.DoEvents()

            dr = dt.Rows(i)

            'Guardo el numero de ruta actual
            RutaActual = CInt(dr("ruta_0"))
            FechaRuta = CDate(dr("fecha_0"))

            Vehiculo.Abrir(dr("transporte_0").ToString, dr("patente_0").ToString)

            'bpt = dr("transporte_0").ToString
            'pat = dr("patente_0").ToString

            Acomp1 = CInt(dr("acomp_0"))
            Acomp2 = CInt(dr("acomp_1"))

            'Calculo el peso de todas las intervenciones del cliente/sucursal en la ruta
            CalculoPesoMinutos(dr, Peso, Minutos) 'dr("ruta_0").ToString, dr("cliente_0").ToString, dr("suc_0").ToString)

            'Registro datos para calculo de FLETEROS
            With tmp1
                .Nuevo()
                .Cadena(0) = dr("transporte_0").ToString
                .Cadena(1) = dr("patente_0").ToString
                .Cadena(2) = dr("cliente_0").ToString
                .Cadena(3) = dr("suc_0").ToString
                .Numero(0) = CInt(dr("ruta_0"))
                .Numero(1) = Peso
                .Numero(2) = BuscarTarifa(Peso, dr("sat_0").ToString, CInt(dr("interno_0").ToString))
                .Fecha(0) = dtpDesde.Value
                .Fecha(1) = dtpHasta.Value
                .Fecha(2) = CDate(dr("fecha_0"))
            End With

            'Agrego al contador de domicilios realizados
            'Calculo la tarifa
            If dr("sat_0").ToString = "BUE" Then
                DomiciliosGba += 1
                PesoGba += Peso
                MinutosGba += Minutos
            Else
                DomiciliosCfe += 1
                PesoCfe += Peso
                MinutosCfe += Minutos
            End If

            If i = dt.Rows.Count - 1 Then
                GrabarLineaAcomp()
            Else
                Dim x As DataRow = dt.Rows(i + 1)
                If CInt(x("ruta_0")) <> RutaActual Then GrabarLineaAcomp()
            End If

        Next

        tmp1.Grabar()
        tmp2.Grabar()

    End Sub
    Private Sub CalculoPesoMinutos(ByVal dr As DataRow, ByRef Peso As Double, ByRef Minutos As Double)
        Dim Sql As String
        Dim da1 As OracleDataAdapter
        Dim da2 As OracleDataAdapter
        Dim da3 As OracleDataAdapter
        Dim dt1 As DataTable
        Dim dt2 As DataTable
        Dim dt3 As DataTable

        Peso = 0
        Minutos = 0

        If dr("sat_0").ToString = "CFE" Then
            Sql = "SELECT prestamos_1, prestamos_3, itmwei_0 "
            Sql &= "FROM xrutad xrd INNER JOIN "
            Sql &= "     sremac sre ON (vcrnum_0 = yitnnum_0) INNER JOIN "
            Sql &= "	 machines mac ON (sre.macnum_0 = mac.macnum_0) INNER JOIN "
            Sql &= "	 itmmaster itm ON (macpdtcod_0 = itmref_0) INNER JOIN "
            Sql &= "	 bpaddress bpa ON (cliente_0 = bpanum_0 AND suc_0 = bpaadd_0) "
            Sql &= "WHERE ruta_0 = :ruta AND "
            Sql &= "	  cliente_0 = :cliente AND "
            Sql &= "	  bpagcba_0 = :bpagcba AND "
            Sql &= "	  bpaaddnro_0 = :bpaaddnro AND "
            Sql &= "	  estado_0 = 3 AND "
            Sql &= "	  tipo_0 IN ('ENT', 'RET')"
            da1 = New OracleDataAdapter(Sql, cn)
            da1.SelectCommand.Parameters.Add("ruta", OracleType.Number).Value = CLng(dr("ruta_0"))
            da1.SelectCommand.Parameters.Add("cliente", OracleType.VarChar).Value = dr("cliente_0").ToString
            da1.SelectCommand.Parameters.Add("bpagcba", OracleType.VarChar).Value = dr("bpagcba_0").ToString
            da1.SelectCommand.Parameters.Add("bpaaddnro", OracleType.Number).Value = CLng(dr("bpaaddnro_0"))

            Sql = "SELECT kilos_0 "
            Sql &= "FROM xrutad xrd INNER JOIN "
            Sql &= "	 bpaddress bpa ON (cliente_0 = bpanum_0 AND suc_0 = bpaadd_0) "
            Sql &= "WHERE ruta_0 = :ruta AND "
            Sql &= "	  cliente_0 = :cliente AND "
            Sql &= "	  bpagcba_0 = :bpagcba AND "
            Sql &= "	  bpaaddnro_0 = :bpaaddnro AND "
            Sql &= "	  estado_0 = 3 AND "
            Sql &= "	  tipo_0 in ('NUE', 'NCI')"
            da2 = New OracleDataAdapter(Sql, cn)
            da2.SelectCommand.Parameters.Add("ruta", OracleType.Number).Value = CLng(dr("ruta_0"))
            da2.SelectCommand.Parameters.Add("cliente", OracleType.VarChar).Value = dr("cliente_0").ToString
            da2.SelectCommand.Parameters.Add("bpagcba", OracleType.VarChar).Value = dr("bpagcba_0").ToString
            da2.SelectCommand.Parameters.Add("bpaaddnro", OracleType.Number).Value = CLng(dr("bpaaddnro_0"))

            Sql = "SELECT itmref_0, itmdes1_0, xminutos_0, vcrnum_0, tqty_0 as cantidad, numlig_0 as orden "
            Sql &= "FROM xrutad xrd INNER JOIN "
            Sql &= "	 yitndet yit on (xrd.vcrnum_0 = yit.num_0 and yit.typlig_0 = 1) inner join "
            Sql &= "	 itmmaster itm on (yit.itmref_0 = itm.itmref_0 and xminutos_0 > 0) inner join "
            Sql &= "	 bpaddress bpa ON (cliente_0 = bpa.bpanum_0 AND suc_0 = bpa.bpaadd_0) "
            Sql &= "WHERE ruta_0 = :ruta AND "
            Sql &= "	  cliente_0 = :cliente AND "
            Sql &= "	  bpagcba_0 = :bpagcba AND "
            Sql &= "	  bpaaddnro_0 = :bpaaddnro AND "
            Sql &= "	  estado_0 = 3 AND "
            Sql &= "      numlig_0 = 1000 "
            Sql &= "UNION "
            Sql &= "SELECT itmref_0, itmdes1_0, xminutos_0, vcrnum_0, install_1 as cantidad, sddlin_0 as orden "
            Sql &= "FROM xrutad xrd INNER JOIN "
            Sql &= "	 sdeliveryd sdd on (sdd.sdhnum_0 = xrd.vcrnum_0) inner join "
            Sql &= "	 itmmaster itm on (sdd.itmref_0 = itm.itmref_0 and xminutos_0 > 0) inner join "
            Sql &= "	 bpaddress bpa ON (cliente_0 = bpa.bpanum_0 AND suc_0 = bpa.bpaadd_0) "
            Sql &= "WHERE ruta_0 = :ruta AND "
            Sql &= "	  cliente_0 = :cliente AND "
            Sql &= "	  bpagcba_0 = :bpagcba AND "
            Sql &= "	  bpaaddnro_0 = :bpaaddnro AND "
            Sql &= "	  estado_0 = 3 "
            Sql &= "ORDER BY vcrnum_0, orden"
            da3 = New OracleDataAdapter(Sql, cn)
            da3.SelectCommand.Parameters.Add("ruta", OracleType.Number).Value = CLng(dr("ruta_0"))
            da3.SelectCommand.Parameters.Add("cliente", OracleType.VarChar).Value = dr("cliente_0").ToString
            da3.SelectCommand.Parameters.Add("bpagcba", OracleType.VarChar).Value = dr("bpagcba_0").ToString
            da3.SelectCommand.Parameters.Add("bpaaddnro", OracleType.Number).Value = CLng(dr("bpaaddnro_0"))

        Else
            Sql = "SELECT prestamos_1, prestamos_3, itmwei_0 "
            Sql &= "FROM xrutad xrd INNER JOIN "
            Sql &= "     sremac sre on (vcrnum_0 = yitnnum_0) INNER JOIN "
            Sql &= "	 machines mac ON (sre.macnum_0 = mac.macnum_0) INNER JOIN "
            Sql &= "	 itmmaster itm ON (macpdtcod_0 = itmref_0) "
            Sql &= "WHERE ruta_0 = :ruta AND "
            Sql &= "	  cliente_0 = :cliente AND "
            Sql &= "	  suc_0 = :suc AND "
            Sql &= "	  estado_0 = 3 AND "
            Sql &= "	  tipo_0 in ('ENT', 'RET')"
            da1 = New OracleDataAdapter(Sql, cn)
            da1.SelectCommand.Parameters.Add("ruta", OracleType.Number).Value = dr("ruta_0").ToString
            da1.SelectCommand.Parameters.Add("cliente", OracleType.VarChar).Value = dr("cliente_0").ToString
            da1.SelectCommand.Parameters.Add("suc", OracleType.VarChar).Value = dr("suc_0").ToString

            Sql = "SELECT kilos_0 "
            Sql &= "FROM xrutad xrd "
            Sql &= "WHERE ruta_0 = :ruta AND "
            Sql &= "	  cliente_0 = :cliente AND "
            Sql &= "	  suc_0 = :suc AND "
            Sql &= "	  estado_0 = 3 AND "
            Sql &= "	  tipo_0 in ('NUE', 'NCI')"
            da2 = New OracleDataAdapter(Sql, cn)
            da2.SelectCommand.Parameters.Add("ruta", OracleType.Number).Value = dr("ruta_0").ToString
            da2.SelectCommand.Parameters.Add("cliente", OracleType.VarChar).Value = dr("cliente_0").ToString
            da2.SelectCommand.Parameters.Add("suc", OracleType.VarChar).Value = dr("suc_0").ToString

            Sql = "SELECT itmref_0, itmdes1_0, xminutos_0, vcrnum_0, tqty_0 as cantidad, numlig_0 as orden "
            Sql &= "FROM xrutad xrd INNER JOIN "
            Sql &= "	 yitndet yit on (xrd.vcrnum_0 = yit.num_0 and yit.typlig_0 = 1) inner join "
            Sql &= "	 itmmaster itm on (yit.itmref_0 = itm.itmref_0 and xminutos_0 > 0) "
            Sql &= "WHERE ruta_0 = :ruta AND "
            Sql &= "	  cliente_0 = :cliente AND "
            Sql &= "	  suc_0 = :suc AND "
            Sql &= "	  estado_0 = 3 AND "
            Sql &= "      numlig_0 = 1000 "
            Sql &= "UNION "
            Sql &= "SELECT itmref_0, itmdes1_0, xminutos_0, vcrnum_0, install_1 as cantidad, sddlin_0 as orden "
            Sql &= "FROM xrutad xrd INNER JOIN "
            Sql &= "	 sdeliveryd sdd on (sdd.sdhnum_0 = xrd.vcrnum_0) inner join "
            Sql &= "	 itmmaster itm on (sdd.itmref_0 = itm.itmref_0 and xminutos_0 > 0) "
            Sql &= "WHERE ruta_0 = :ruta AND "
            Sql &= "	  cliente_0 = :cliente AND "
            Sql &= "	  suc_0 = :suc AND "
            Sql &= "	  estado_0 = 3 "
            Sql &= "ORDER BY vcrnum_0, orden"
            da3 = New OracleDataAdapter(Sql, cn)
            da3.SelectCommand.Parameters.Add("ruta", OracleType.Number).Value = dr("ruta_0").ToString
            da3.SelectCommand.Parameters.Add("cliente", OracleType.VarChar).Value = dr("cliente_0").ToString
            da3.SelectCommand.Parameters.Add("suc", OracleType.VarChar).Value = dr("suc_0").ToString

        End If

        Try
            dt1 = New DataTable
            dt2 = New DataTable
            dt3 = New DataTable

            da1.Fill(dt1)
            da2.Fill(dt2)
            da3.Fill(dt3)

            For Each dr2 As DataRow In dt1.Rows
                Peso += CDbl(dr2("itmwei_0"))
            Next

            For Each dr2 As DataRow In dt2.Rows
                Peso += CDbl(dr2("kilos_0"))
            Next

            Dim d As String = ""
            For Each dr2 As DataRow In dt3.Rows
                If dr2("vcrnum_0").ToString <> d Then
                    Minutos += CDbl(dr2("cantidad")) * CDbl(dr2("xminutos_0"))
                    d = dr2("vcrnum_0").ToString
                End If

            Next

        Catch ex As Exception

        End Try

    End Sub
    Private Function BuscarTarifa(ByVal Peso As Double, ByVal sat As String, Optional ByVal Interno As Integer = 2) As Double
        Dim dr As DataRow = Nothing
        Dim tar As Double = 0
        Dim x As Integer

        For Each dr In dtTarifas.Rows
            If CDbl(dr("kg_0")) >= Peso Then Exit For
        Next

        If Interno = 2 Then x = 0 Else x = 1

        If sat = "CFE" Then
            tar = CDbl(dr("cfe_" & x.ToString))
        Else
            tar = CDbl(dr("gba_" & x.ToString))
        End If

        Return tar
    End Function
    Private Sub GrabarLineaAcomp()
        Dim Tarifa As Double = 0
        Dim Extra As Integer = 0
        Dim j As Integer = 0 'Cantidad de acompañantes

        'Calculo la cantidad de acompañantes en la ruta
        If Acomp1 > 1 Then j += 1
        If Acomp2 > 1 Then j += 1
        If j = 0 Then j = -1

        'Tarifa por kilos movido
        Tarifa += PesoCfe * BuscarTarifa(-2, "CFE")
        Tarifa += PesoGba * BuscarTarifa(-2, "GBA")

        'Tarifa por domicilios efectuados
        If DomiciliosGba > DomiciliosCfe Then
            Extra = DomiciliosCfe + DomiciliosGba - CantBaseGBA
            If Extra < 0 Then Extra = 0
            Tarifa += Extra * BuscarTarifa(-1, "GBA")

        Else
            Extra = DomiciliosCfe + DomiciliosGba - CantBaseCFE
            If Extra < 0 Then Extra = 0
            Tarifa += Extra * BuscarTarifa(-1, "CFE")

        End If

        'Tarifa por minutos
        Tarifa += MinutosCfe * BuscarTarifa(-4, "CFE")
        Tarifa += MinutosGba * BuscarTarifa(-4, "GBA")

        For i = 0 To j - 1
            'Si el acompañante está seleccionado en el ListBox
            If i = 0 AndAlso (Acomp1 = 0 OrElse isCheck(Acomp1) = False) Then Continue For
            If i = 1 AndAlso (Acomp2 = 0 OrElse isCheck(Acomp2) = False) Then Continue For

            With tmp2
                ruta.Abrir(RutaActual)
                .Nuevo(usr.Codigo, "ACOMP")

                .Cadena(0) = Vehiculo.Codigo
                .Cadena(1) = Vehiculo.Patente

                .Numero(0) = RutaActual
                .Numero(1) = CDbl(IIf(i = 0, Acomp1, Acomp2))
                .Numero(2) = j
                .Numero(3) = PesoCfe
                .Numero(4) = PesoGba
                .Numero(5) = DomiciliosCfe
                .Numero(6) = DomiciliosGba

                If Vehiculo.ChoferInterno Then
                    .Numero(7) = Tarifa / (j + 1)
                Else
                    .Numero(7) = Tarifa / j
                End If

                If ruta.EstuvoMicrocentro = 2 Then
                    .Numero(8) = 1
                End If
                .Numero(9) = MinutosCfe + MinutosGba

                .Fecha(0) = dtpDesde.Value
                .Fecha(1) = dtpHasta.Value
                .Fecha(2) = FechaRuta
            End With
        Next

        PesoCfe = 0
        PesoGba = 0
        DomiciliosCfe = 0
        DomiciliosGba = 0
        MinutosCfe = 0
        MinutosGba = 0

    End Sub
    Private Sub MarcarTodos(ByVal flg As Boolean)
        For i As Integer = 0 To lstAcompanantes.Items.Count - 1
            lstAcompanantes.SetItemChecked(i, flg)
        Next
    End Sub
    Private Function isCheck(ByVal n As Integer) As Boolean
        Dim flg As Boolean = False

        For Each dr As DataRowView In lstAcompanantes.CheckedItems
            If n = CInt(dr("lannum_0")) Then
                flg = True
                Exit For
            End If
        Next

        Return flg

    End Function

    Private Sub mnuMarcarTodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMarcarTodos.Click
        MarcarTodos(True)
    End Sub
    Private Sub mnuDesmarcarTodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDesmarcarTodos.Click
        MarcarTodos(False)
    End Sub

    Private Sub chkDetallado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDetallado.CheckedChanged

        If crv2.ReportSource IsNot Nothing Then
            Dim rpt As ReportDocument = CType(crv2.ReportSource, ReportDocument)
            rpt.SetParameterValue("X3USR", usr.Codigo)
            rpt.SetParameterValue("DETALLE", chkDetallado.Checked)
            crv2.ReportSource = rpt
        End If

    End Sub

End Class