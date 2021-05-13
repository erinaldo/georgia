Imports System.Data.OracleClient
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Collections

Public Class frmPremioRelevadores
    Private Const BASE_CONTROLES As Integer = 3000

    Private Desde As Date
    Private Hasta As Date
    Private Estado(4) As Integer
    Private NoConforme(10) As Integer
    Private CantidadControles As Double
    Private CantidadRelevamientos As Double
    Private TotalDomiciliosRuteados As Integer
    Private DomiciliosVisitados As Integer
    Private DomiciliosConformes As Integer
    Private RutasEnPeriodo As New ArrayList
    Private ControlesRutas As Double
    Private ControlesDomicilios As Double
    Private Excedentes As Double
    Private Premio As Double
    Private tmp As New Temporal(cn, usr, "premios")

    Private Sub frmPremioRelevadores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim mnu = New MenuLocal(cn, 2408, False, False)
        mnu.Enlazar(cboRelevadores)

        calendario.MaxDate = Today.AddDays(+1)

        If usr.Permiso.AccesoSecundario(60, "V") Then
            txtvalor.Visible = True
            lblvalor.Visible = True
            Label21.Visible = True
            txtboxdom.Visible = True
        Else
            txtvalor.Visible = False
            lblvalor.Visible = False
            Label21.Visible = False
            txtboxdom.Visible = False

        End If
        tmp.Abrir()
        tmp.Registro(0)
        txtboxdom.Text = tmp.Numero(8).ToString
        txtvalor.Text = tmp.Numero(7).ToString

        AddHandler dgv.RowPostPaint, AddressOf NumeracionGrillas

    End Sub
    Private Sub btnReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReporte.Click
        Dim rpt As New ReportDocument
        Dim crystal As frmCrystal
        rpt.Load(RPTX3 & "xPremRel.rpt")
        rpt.SetDatabaseLogon(DB_USR, DB_PWD)
        rpt.SetParameterValue("usuario", usr.Codigo)
        rpt.SetParameterValue("x3dos", X3DOS)
        crystal = New frmCrystal(rpt)
        crystal.MdiParent = Me.ParentForm
        crystal.Show()
    End Sub
    Private Sub cmbRelevadores_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRelevadores.GotFocus
        btnReporte.Enabled = False
    End Sub
    Private Sub btnCalcular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalcular.Click
        Desde = calendario.SelectionRange.Start
        Hasta = calendario.SelectionRange.End

        Proceso(Desde, Hasta, cboRelevadores.SelectedValue.ToString)

    End Sub
    Private Sub Proceso(ByVal Desde As Date, ByVal Hasta As Date, ByVal Relevador As String)
        Dim da As New OracleDataAdapter
        Dim Sql As String
        Dim dt As New DataTable

        'Reset de variables
        For i As Integer = 0 To 10
            If i <= 3 Then Estado(i) = 0
            NoConforme(i) = 0
        Next
        CantidadControles = 0
        CantidadRelevamientos = 0
        TotalDomiciliosRuteados = 0
        DomiciliosVisitados = 0
        DomiciliosConformes = 0
        RutasEnPeriodo.Clear()
        ControlesRutas = 0
        ControlesDomicilios = 0
        Excedentes = 0
        Premio = 0

        Sql = "select xrc.fecha_0, xrd.vcrnum_0, cliente_0, nombre_0, xrc.ruta_0, equipos_1, estado_0, noconform_0, yit.itmref_0, acomp_0, acomp_1, suc_0 "
        Sql &= "from yitndet yit left join "
        Sql &= "	 xrutad xrd on (xrd.vcrnum_0 = yit.num_0)  left join "
        Sql &= "	 xrutac xrc on (xrc.ruta_0 = xrd.ruta_0) "
        Sql &= "where fecha_0 >= :fechaini and "
        Sql &= "	  fecha_0 <= :fechafin and "
        Sql &= "	  typlig_0 = 1  and "
        Sql &= "	  tipo_0 = 'CTL' and "
        Sql &= "	  (acomp_0 = :acomp or acomp_1 = :acomp) and "
        Sql &= "	  numlig_0 = '1000'"
        Sql &= "order by fecha_0"

        If dgv.DataSource Is Nothing Then
            dt = New DataTable
        Else
            dt = CType(dgv.DataSource, DataTable)
            dt.Clear()
        End If

        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("fechaini", OracleType.DateTime).Value = Desde
        da.SelectCommand.Parameters.Add("fechafin", OracleType.DateTime).Value = Hasta
        da.SelectCommand.Parameters.Add("acomp", OracleType.VarChar).Value = Relevador
        da.Fill(dt)

        If dgv.DataSource Is Nothing Then EnlazarGrilla(dt)

        For Each dr As DataRow In dt.Rows
            If RutasEnPeriodo.IndexOf(CInt(dr("ruta_0"))) = -1 Then RutasEnPeriodo.Add(CInt(dr("ruta_0")))

            Estado(CInt(dr("estado_0"))) += 1
            NoConforme(CInt(dr("noconform_0"))) += 1

            If CInt(dr("estado_0")) = 3 Then
                Dim Qty As Integer = CInt(dr("equipos_1"))
                Dim Acomp As Double

                If CInt(dr("acomp_0")) = 0 Or CInt(dr("acomp_1")) = 0 Then
                    Acomp = 1
                Else
                    Acomp = 0.5
                End If

                'Calculo de cantidades de controles y relevamientos
                Select Case dr("itmref_0").ToString
                    Case "602011" 'RELEVAMIENTO
                        CantidadRelevamientos += Qty * Acomp

                    Case "553011"
                        'Se paga doble
                        CantidadControles += Qty * Acomp * 2

                        'Si es tipo dos, sumo 2 más
                        Dim bpa As New Sucursal(cn)
                        If bpa.Abrir(dr("cliente_0").ToString, dr("suc_0").ToString) Then
                            If bpa.TipoSistema = 2 Then
                                CantidadControles += 4 * Acomp
                            End If
                        End If

                    Case Else
                        CantidadControles += Qty * Acomp

                End Select
            End If

        Next

        TotalDomiciliosRuteados = dt.Rows.Count
        DomiciliosVisitados = Estado(3) + NoConforme(2) + NoConforme(3) + NoConforme(4) + NoConforme(5) + NoConforme(7) + NoConforme(8) + NoConforme(9)
        DomiciliosConformes = Estado(3)
        ControlesRutas = (CantidadControles + CantidadRelevamientos) / RutasEnPeriodo.Count
        ControlesDomicilios = (CantidadControles + CantidadRelevamientos) / DomiciliosConformes

        Excedentes = CantidadControles + CantidadRelevamientos
        Excedentes -= BASE_CONTROLES
        If Excedentes < 0 Then Excedentes = 0

        Dim TarifaDomicilio As Double = CDbl(txtboxdom.Text)
        Dim Tarifa As Double = CDbl(txtvalor.Text)

        If chkMoto.Checked Then
            Premio = (Excedentes * 1.5) * Tarifa + (DomiciliosConformes * TarifaDomicilio)
        Else
            Premio = Excedentes * Tarifa
        End If

        'Paso info a los TextBox
        txtControles.Text = CantidadControles.ToString
        txtDomRuteado.Text = dt.Rows.Count.ToString
        txtDomVisitado.Text = DomiciliosVisitados.ToString
        txtDomConforme.Text = DomiciliosConformes.ToString
        txtRutPeriodo.Text = RutasEnPeriodo.Count.ToString
        txtConRuta.Text = (CantidadControles / RutasEnPeriodo.Count).ToString("N2")
        txtConDomicilio.Text = (CantidadControles / DomiciliosConformes).ToString("N2")
        txtRelevamientos.Text = CantidadRelevamientos.ToString
        txtCantContPremio.Text = Excedentes.ToString
        txtPremioAbonar.Text = Premio.ToString("N2")

        Dim p1 As Integer
        Dim p2 As Integer

        p1 = NoConforme(2) + NoConforme(3) + NoConforme(4) + NoConforme(5) + NoConforme(7) + NoConforme(8) + NoConforme(9) + NoConforme(10)
        p2 = dt.Rows.Count - NoConforme(6)

        txtDomRebote.Text = p1.ToString
        If p2 > 0 Then
            txtPorcRebote.Text = (p1 / p2 * 100).ToString("N2")
        End If
        txtCumParcial.Text = NoConforme(1).ToString
        txtCliNoPresente.Text = NoConforme(2).ToString
        txtFalCooDomicilio.Text = NoConforme(3).ToString
        txtFalVerDom.Text = NoConforme(4).ToString
        txtFalCooPago.Text = NoConforme(5).ToString
        txtFalCumpLogisitico.Text = NoConforme(6).ToString
        txtCliNoAceRecibir.Text = NoConforme(7).ToString
        txtVerVencimientos.Text = NoConforme(8).ToString

        TablaTemporal()

    End Sub
    Private Sub TablaTemporal()
        tmp.Abrir()
        tmp.LimpiarTabla()

        tmp.Nuevo()
        tmp.Numero(0) = CDbl(txtFalCumpLogisitico.Text)
        tmp.Numero(1) = CDbl(IIf(txtConRuta.Text.ToString = "NeuN", 0.0, (txtConRuta.Text)))
        tmp.Numero(2) = CDbl(IIf(txtConDomicilio.Text.ToString = "NeuN", 0.0, (txtConDomicilio.Text)))
        tmp.Numero(3) = CDbl(txtCantContPremio.Text)
        tmp.Numero(4) = CDbl(txtPremioAbonar.Text)
        tmp.Numero(5) = CDbl(txtDomRuteado.Text)
        tmp.Numero(6) = CDbl(cboRelevadores.SelectedValue)
        tmp.Numero(7) = CDbl(txtvalor.Text)
        tmp.Numero(8) = CDbl(txtboxdom.Text)
        tmp.Cadena(1) = txtDomConforme.Text
        tmp.Cadena(2) = txtDomRebote.Text
        tmp.Cadena(3) = txtDomVisitado.Text
        tmp.Cadena(4) = txtCumParcial.Text
        tmp.Cadena(5) = txtCliNoPresente.Text
        tmp.Cadena(6) = txtCliNoAceRecibir.Text
        tmp.Cadena(7) = txtFalCooDomicilio.Text
        tmp.Cadena(8) = txtFalCooPago.Text
        tmp.Cadena(9) = txtFalVerDom.Text
        tmp.Cadena(10) = txtVerVencimientos.Text
        tmp.Cadena(11) = txtRelevamientos.Text
        tmp.Cadena(12) = txtControles.Text
        tmp.Cadena(13) = txtRutPeriodo.Text
        tmp.Cadena(14) = txtPorcRebote.Text
        tmp.Fecha(0) = calendario.SelectionStart
        tmp.Fecha(1) = calendario.SelectionEnd
        tmp.Grabar()
        btnReporte.Enabled = True
    End Sub
    Private Sub EnlazarGrilla(ByVal dt As DataTable)

        colFecha.DataPropertyName = "fecha_0"
        colIntervencion.DataPropertyName = "vcrnum_0"
        colCodigoCliente.DataPropertyName = "cliente_0"
        colRazonSocial.DataPropertyName = "nombre_0"
        colRuta.DataPropertyName = "ruta_0"
        colEquipos.DataPropertyName = "equipos_1"
        With colEstado
            .DataPropertyName = "estado_0"
            .DataSource = TablaEstadosRuta(cn)
            .DisplayMember = "texte_0"
            .ValueMember = "code_0"
        End With
        With colNoConforme
            .DataSource = TablaMotivos(cn)
            .DisplayMember = "texte_0"
            .ValueMember = "code_0"
            .DataPropertyName = "noconform_0"
        End With
        colItemRef.DataPropertyName = "itmref_0"

        colAcomp1.DataPropertyName = "acomp_0"
        colAcomp2.DataPropertyName = "acomp_1"
        colSuc.DataPropertyName = "suc_0"

        dgv.DataSource = dt

    End Sub

End Class