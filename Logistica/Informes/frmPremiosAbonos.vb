Imports System.Data.OracleClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class frmPremiosAbonos
    Private da As OracleDataAdapter
    Private dtPrincipal As New DataTable
    Private Desde As Date
    Private Hasta As Date

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Dim Sql As String

        Sql = "select distinct c.fecha_0, c.ruta_0, d.cliente_0, d.suc_0, d.direccion_0, zut.chofer_0, c.acomp_0, c.acomp_1, c.acomp_2, adi.n1_0 "
        Sql &= "from xrutac c inner join "
        Sql &= "     xrutad d on (c.ruta_0 = d.ruta_0) inner join "
        Sql &= "     bpcustomer bpc on (d.cliente_0 = bpc.bpcnum_0) inner join "
        Sql &= "     interven itn on (d.vcrnum_0 = itn.num_0) inner join "
        Sql &= "     zunitrans zut on (zut.bptnum_0 = c.transporte_0 and zut.patnum_0 = c.patente_0) left join "
        Sql &= "     atabdiv adi on (adi.numtab_0 = 5006 and adi.code_0 = bpc.xcomplej_0) "
        Sql &= "where itn.typ_0 in ('A1', 'C1', 'T1') and "
        Sql &= "      c.valid_0 = 1 and "
        Sql &= "      d.estado_0 = 3 and "
        Sql &= "      c.fecha_0 between :desde and :hasta "
        Sql &= "order by c.fecha_0, c.ruta_0"
        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("desde", OracleType.DateTime)
        da.SelectCommand.Parameters.Add("hasta", OracleType.DateTime)

    End Sub
    Private Sub btnCalcular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalcular.Click
        btnCalcular.Enabled = False

        Desde = mCalDesde.Value
        Hasta = mCalHasta.Value

        ObtenerDatos()
        GrabarEnTemporal()
        MostrarReporte()

        btnCalcular.Enabled = True
    End Sub
    Private Sub ObtenerDatos()
        da.SelectCommand.Parameters("desde").Value = Desde
        da.SelectCommand.Parameters("hasta").Value = Hasta
        dtPrincipal.Clear()
        da.Fill(dtPrincipal)
    End Sub
    Private Sub GrabarEnTemporal()
        Dim dr As DataRow
        Dim tmp As New Temporal(cn, usr, "ABONO") 'Informacion general
        Dim tmp2 As New Temporal(cn, usr, "ABONO2") 'Resumen premio por acompañante

        tmp.Abrir()
        tmp.LimpiarTabla()

        tmp2.Abrir()
        tmp2.LimpiarTabla()

        For Each dr In dtPrincipal.Rows
            Dim CantidadAcompanantes As Integer = 1

            'If dr("cliente_0").ToString = "611448" Then Stop

            tmp.Nuevo()
            tmp.Fecha(0) = CDate(dr("fecha_0"))
            tmp.Fecha(1) = Desde
            tmp.Fecha(2) = Hasta
            tmp.Cadena(0) = dr("cliente_0").ToString
            tmp.Cadena(1) = dr("suc_0").ToString
            tmp.Cadena(2) = dr("direccion_0").ToString
            tmp.Cadena(3) = dr("chofer_0").ToString
            tmp.Numero(0) = CDbl(dr("ruta_0"))
            tmp.Numero(1) = CDbl(dr("acomp_0"))
            tmp.Numero(2) = CDbl(dr("acomp_1"))
            tmp.Numero(3) = CDbl(dr("acomp_2"))
            tmp.Numero(4) = CDbl(IIf(IsDBNull(dr("n1_0")), 0, dr("n1_0"))) 'complejidad

            'Calculo la cantidad de acompañantes
            For i As Integer = 0 To 2
                If CDbl(dr("acomp_" & i.ToString)) > 0 Then
                    CantidadAcompanantes += 1
                End If
            Next
            'Si la cantidad de acompañantes es mayor a 2 el precio
            'se divide por esa cantidad, sino no se divide
            If CantidadAcompanantes <= 2 Then CantidadAcompanantes = 1

            'Agrego los acompañantes a la tabla de resumen
            For i = 0 To 2
                If CDbl(dr("acomp_" & i.ToString)) > 0 Then
                    Dim flg As Boolean = tmp2.Buscar(0, CDbl(dr("acomp_" & i.ToString)))
                    If Not flg Then
                        tmp2.Nuevo()
                        tmp2.Numero(0) = CDbl(dr("acomp_" & i.ToString))
                    End If
                    tmp2.Numero(1) += (tmp.Numero(4) / CantidadAcompanantes)
                End If
            Next
        Next
        tmp.Grabar()
        tmp2.Grabar()

    End Sub
    Private Sub MostrarReporte()
        Dim rpt As New ReportDocument

        rpt.Load(RPTX3 & "XPREMIOSABONOS.rpt")
        rpt.SetParameterValue("USR", usr.Codigo)
        rpt.SetDatabaseLogon(DB_USR, DB_PWD)
        crv.ReportSource = rpt

    End Sub
    
End Class