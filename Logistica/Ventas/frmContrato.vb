Imports Clases
Imports System.Data.OracleClient
Imports System.DateTime
Imports CrystalDecisions.CrystalReports.Engine

Public Class frmContrato
    Private bpc As New Cliente(cn)
    Private bpa As New Sucursal(cn)
    Private sre As New Solicitud(cn)
    Private CpyD02 As New Sociedad(cn)

    Private Contrato As New Contratos(cn)
    Private ContratoServicio As New ContratoServicio(cn)
    Private dtSuc As New DataTable 'Tabla para DataGrid de sucursales

    Private fecha As Date = New Date(Date.Now.Year, Date.Now.Month, 1)
    Private fechafin As Date = fecha.AddYears(1).AddDays(-1)

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        'Lleno ComboBox Condiciones de Pago
        Dim CondicionPago As New CondicionPago(cn)
        CondicionPago.LlenarComboBox(cn, cboCondicionPago)

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Dim Sql As String
        Dim da As OracleDataAdapter

        Sql = "SELECT bpaadd_0, bpaaddlig_0, cty_0 FROM bpaddress WHERE 1 = 2"
        da = New OracleDataAdapter(Sql, cn)
        da.FillSchema(dtSuc, SchemaType.Mapped)

        Dim mnu As New MenuLocal(cn)
        mnu.AbrirMenu(1240, True)
        mnu.Enlazar(cboEstado)

        mnu = New MenuLocal(cn)
        mnu.AbrirMenu(2978, False)
        mnu.Enlazar(cboModoFacturacion)

        mnu = New MenuLocal(cn)
        mnu.AbrirMenu(2978, False)
        mnu.Enlazar(colModo2)

        'Enlace ComboBox vendedor
        Vendedor.Enlazar(cn, cboVendedor, True)
        cboVendedor.SelectedValue = " "

    End Sub
    Private Sub frmContrato_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        dtpInicio.Value = fecha
        'dtpFin.Value = fechafin

        colCodSucursal.DataPropertyName = "bpaadd_0"
        colCodSucursal.DataPropertyName = "bpaadd_0"

        colDireccion.DataPropertyName = "bpaaddlig_0"
        colLocalidad.DataPropertyName = "cty_0"
        dgvSucursales.DataSource = dtSuc

        llenar_dgvPrincipal()

        BuscarRenovaciones()

    End Sub

    'ACCIONES DGV
    Private Sub dgvPrincipal_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPrincipal.CellContentDoubleClick
        Dim nro As Long = CLng(dgvPrincipal.Rows(e.RowIndex).Cells("DGVnro").Value)

        Abrir(nro)

        If txtId.Text = "" Then
            BtnImprimir.Enabled = True
        ElseIf txtId.Text = " " Then
            BtnImprimir.Enabled = False
        End If
    End Sub
    Private Sub Abrir(ByVal Nro As Long)
        Contrato.Abrir(Nro)

        bpc = Contrato.Cliente
        bpa = bpc.Sucursal(Contrato.Sucursal)

        LlenarControles()
    End Sub
    Private Sub LlenarControles()

        LimpiarControles()

        With Contrato
            txtId.Text = .Numero.ToString

            txtCodigoCliente.Text = .ClienteCodigo
            cboSucursal.SelectedValue = bpa.Sucursal

            txtDescripcion.Text = .Nombre
            dtpInicio.Value = .FechaInicio
            nudDuracion.Value = .Duracion
            cboVendedor.SelectedValue = .Vendedor
            txtConcactoComercial.Text = .ContactoComercial.ToString
            txtTelefonoComercial.Text = .ContactoComercialTelefono.ToString
            txtMailComercial.Text = .ContactoComercialMail.ToString
            txtContactoOperativo.Text = .ContactoOperador.ToString
            txtTelefonoOperativo.Text = .ContactoOperadorTelefono.ToString
            txtMailOperativo.Text = .ContactoOperadorMail.ToString
            txtOc.Text = .OC.ToString
            txtObs.Text = .Observaciones
            chkPhMangueras.Checked = .PhMagueras
            txtPhMangueras.Text = .PhManguerasDetalle.ToString
            chkMantenimientoBocas.Checked = .MantBocaHidrantes
            txtMantBocasHidr.Text = .MantBocaHidrantesDetalle.ToString
            chkMantenimientoRed.Checked = .MantIntegralRedHidrantes
            txtMantIntRedHdri.Text = .MantIntegralRedHidrantesDetalle.ToString
            chk639.Checked = .M639
            txtDetalle639.Text = .M639Detalle.ToString
            nudCantidadMatafuegos.Value = .CantidadMatafuegos
            chkPq55.Checked = .PolvoQuimicoABC55
            chkPq90.Checked = .PolvoQuimicoABC90
            chkPq.Checked = .PolvoQuimicoBC
            chkCo2.Checked = .CO2
            chkAfff.Checked = .EspumaAFFF
            chkHalogenados.Checked = .HALOGENADO
            chkAcetato.Checked = .ACETATO
            chkOtros.Checked = .OtrosMatafuegos
            nudCantidadHidrantes.Value = .CantidadHidrantes

            optTarjeta1.Checked = .Tarjeta = 1
            optTarjeta2.Checked = .Tarjeta = 2
            optTarjeta3.Checked = .Tarjeta = 3

            chkVisita.Checked = .VisitaRelevamiento
            chkControlPeriodico.Checked = .ControlPeriodico
            TxtOtrosRelevamiento.Text = .OtrosRelevamientos.ToString
            chkProvision.Checked = .SoporteChapaBalizaProvision
            chkInstalacion.Checked = Contrato.SoporteChapaBalizaInstalacion
            txtOtrosInstalacion.Text = .OtrasInstalacion.ToString
            chkAutorizacionIngreso.Checked = .AutorizacionPersonal
            chkArt.Checked = .ComprobantePagoART
            chkSeguroVehiculo.Checked = .SeguroVehiculo
            txtOtrosDocumentos.Text = .EstudiosMedicosDetalle.ToString
            chkCasco.Checked = .Casco
            chkBarbijo.Checked = .Barbijo
            chkProtectorAuditivo.Checked = .ProtectorAuditivo
            chkZapatosSeguridad.Checked = .ZapatosDeSeguridad
            chkSeguroVehiculo.Checked = .SeguroVehiculo
            txtOtrosDocumentos.Text = .EstudiosMedicosDetalle.ToString
            txtotrosElementos.Text = .OtrosElementos.ToString
            nudUnificacion.Value = .Unificacion
            txtImporteAnual.Text = .ImporteAnual.ToString
            txtImporteMensual.Text = .ImporteMensual.ToString
            cboCondicionPago.SelectedValue = .CondicionPago.ToString
            cboModoFacturacion.SelectedValue = .ModoFacturacion
            cboEstado.SelectedValue = .Estado

            nudFrecuenciaFacturacion.Value = .FrecuenciaFacturacion
            chkRenovacion.Checked = .Renovacion
        End With

        txtNombreCliente.Text = bpc.Nombre.ToString
        cboVendedor.SelectedValue = bpc.Vendedor.Codigo

        'Carga de sucursales
        dtSuc.Clear()

        Dim dt As DataTable = bpc.SucursalesTabla
        Dim dv As New DataView(dt)

        'Recorro todas las sucursales cubiertas por el contrato
        For Each dr As DataRow In Contrato.Sucursales.Rows
            'Filtro dataview
            dv.RowFilter = "bpaadd_0 = '" & dr("bpaadd_0").ToString & "'"

            If dv.Count = 1 Then
                Dim dr1 = dv.Item(0).Row
                Dim dr2 As DataRow = dtSuc.NewRow

                dr2("bpaadd_0") = dr1("bpaadd_0")
                dr2("bpaaddlig_0") = dr1("bpaaddlig_0")
                dr2("cty_0") = dr1("cty_0")

                dtSuc.Rows.Add(dr2)

            End If
        Next

    End Sub
    Private Sub LimpiarControles()
        'Solapa General
        cboEstado.SelectedValue = 0
        txtId.Clear()
        txtDescripcion.Clear()
        txtCodigoCliente.Clear()
        txtNombreCliente.Clear()
        If cboSucursal.DataSource IsNot Nothing Then
            CType(cboSucursal.DataSource, DataTable).Clear()
        End If
        dtpInicio.Value = fecha
        nudDuracion.Value = 12
        txtConcactoComercial.Clear()
        txtTelefonoComercial.Clear()
        txtMailComercial.Clear()
        txtContactoOperativo.Clear()
        txtTelefonoOperativo.Clear()
        txtMailOperativo.Clear()
        cboVendedor.SelectedValue = " "
        txtOc.Clear()
        txtObs.Clear()

        chkPhMangueras.Checked = False
        txtPhMangueras.Clear()
        chkMantenimientoBocas.Checked = False
        txtMantBocasHidr.Clear()
        chkMantenimientoRed.Checked = False
        txtMantIntRedHdri.Clear()
        chk639.Checked = False
        txtDetalle639.Clear()
        'Solapa Varios
        nudCantidadMatafuegos.Value = 0
        chkPq55.Checked = False
        chkPq90.Checked = False
        chkPq.Checked = False
        chkCo2.Checked = False
        chkAfff.Checked = False
        chkHalogenados.Checked = False
        chkAcetato.Checked = False
        chkOtros.Checked = False
        nudCantidadHidrantes.Value = 0
        optTarjeta1.Checked = False
        optTarjeta2.Checked = False
        optTarjeta3.Checked = False
        chkVisita.Checked = False
        chkControlPeriodico.Checked = False
        TxtOtrosRelevamiento.Clear()
        chkProvision.Checked = False
        chkInstalacion.Checked = False
        txtOtrosInstalacion.Clear()

        'Solapa Sucursales
        dtSuc.Clear()

        'Solapa Documentacion y Elementos

        chkAutorizacionIngreso.Checked = False
        chkArt.Checked = False
        chkSeguroVehiculo.Checked = False
        txtOtrosDocumentos.Clear()
        chkCasco.Checked = False
        chkBarbijo.Checked = False
        chkProtectorAuditivo.Checked = False
        chkZapatosSeguridad.Checked = False
        txtotrosElementos.Clear()
        nudUnificacion.Value = nudUnificacion.Minimum
        txtImporteAnual.Text = "0.00"
        txtImporteMensual.Text = "0.00"

        cboModoFacturacion.SelectedValue = 2
        chkRenovacion.Checked = False

    End Sub
    Private Sub Registrar()
        'Salgo si ya fue creado el contrato en adonix
        If Contrato.Estado = 2 Then
            MessageBox.Show("Contrato ya registrado")
            Exit Sub
        End If

        'Solapa General
        With Contrato
            .Nombre = txtDescripcion.Text
            .ClienteCodigo = txtCodigoCliente.Text
            .Sucursal = cboSucursal.SelectedValue.ToString
            .FechaInicio = dtpInicio.Value
            .Duracion = CInt(nudDuracion.Value)
            .ContactoComercial = txtConcactoComercial.Text
            .ContactoComercialTelefono = txtTelefonoComercial.Text
            .ContactoComercialMail = txtMailComercial.Text
            .ContactoOperador = txtContactoOperativo.Text
            .ContactoOperadorTelefono = txtTelefonoOperativo.Text
            .ContactoOperadorMail = txtMailOperativo.Text
            .TurnoMananaDesde = "0000"
            .TurnoMananahasta = "0100"
            .TurnoTardeDesde = "1200"
            .TurnoTardehasta = "1300"
            .Vendedor = cboVendedor.SelectedValue.ToString
            .OC = txtOc.Text.Trim
            .Observaciones = txtObs.Text
            .PhMagueras = chkPhMangueras.Checked
            .PhManguerasDetalle = txtPhMangueras.Text.Trim
            .MantBocaHidrantes = chkMantenimientoBocas.Checked
            .MantBocaHidrantesDetalle = txtMantBocasHidr.Text.Trim
            .MantIntegralRedHidrantes = chkMantenimientoRed.Checked
            .MantIntegralRedHidrantesDetalle = txtMantIntRedHdri.Text.Trim
            .M639 = chk639.Checked
            .M639Detalle = txtDetalle639.Text.Trim
            .Renovacion = chkRenovacion.Checked

            'Solapa Varios
            .CantidadMatafuegos = CInt(nudCantidadMatafuegos.Value)
            .PolvoQuimicoABC55 = chkPq55.Checked
            .PolvoQuimicoABC90 = chkPq90.Checked
            .PolvoQuimicoBC = chkPq.Checked
            .CO2 = chkCo2.Checked
            .EspumaAFFF = chkAfff.Checked
            .HALOGENADO = chkHalogenados.Checked
            .ACETATO = chkAcetato.Checked
            .OtrosMatafuegos = chkOtros.Checked
            .CantidadHidrantes = CInt(nudCantidadHidrantes.Value)


            If optTarjeta1.Checked Then
                .Tarjeta = 1
            ElseIf optTarjeta2.Checked Then
                .Tarjeta = 2
            ElseIf optTarjeta3.Checked Then
                .Tarjeta = 3
            Else
                .Tarjeta = 0
            End If

            .VisitaRelevamiento = chkVisita.Checked
            .ControlPeriodico = chkControlPeriodico.Checked
            .OtrosRelevamientos = TxtOtrosRelevamiento.Text.Trim
            .SoporteChapaBalizaProvision = chkProvision.Checked
            .SoporteChapaBalizaInstalacion = chkInstalacion.Checked
            .OtrasInstalacion = txtOtrosInstalacion.Text.Trim

            'Solapa Documentacion y Elementos
            .AutorizacionPersonal = chkAutorizacionIngreso.Checked
            .ComprobantePagoART = chkArt.Checked
            .SeguroVehiculo = chkSeguroVehiculo.Checked
            .EstudiosMedicosDetalle = txtOtrosDocumentos.Text.Trim
            .Casco = chkCasco.Checked
            .Barbijo = chkBarbijo.Checked
            .ProtectorAuditivo = chkProtectorAuditivo.Checked
            .ZapatosDeSeguridad = chkZapatosSeguridad.Checked
            .OtrosElementos = txtotrosElementos.Text.Trim
            .Unificacion = CInt(nudUnificacion.Value)
            .ImporteAnual = CLng(txtImporteAnual.Text)
            .ImporteMensual = CLng(txtImporteMensual.Text)
            .CondicionPago = cboCondicionPago.SelectedValue.ToString
            .ModoFacturacion = CInt(cboModoFacturacion.SelectedValue)
            .FrecuenciaFacturacion = CInt(nudFrecuenciaFacturacion.Value)
        End With

        Contrato.SucursalesCubiertas(dtSuc)
        Contrato.Grabar()

        txtId.Text = Contrato.Numero.ToString
        cboEstado.SelectedValue = 1

        MessageBox.Show("Registro Ok", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    'LLENADO DGV
    Private Sub llenar_dgvPrincipal()
        Dim da As OracleDataAdapter
        Dim dt As DataTable
        Dim sql As String = ""

        sql = "SELECT nro_0, bpc_0 FROM xcontrato WHERE estado_0 <> 2"
        da = New OracleDataAdapter(sql, cn)

        If dgvPrincipal.DataSource Is Nothing Then
            dt = New DataTable
            DGVnro.DataPropertyName = "nro_0"
            DGVCliente.DataPropertyName = "bpc_0"
            dgvPrincipal.DataSource = dt

        Else
            dt = CType(dgvPrincipal.DataSource, DataTable)

        End If

        dt.Clear()
        da.Fill(dt)

    End Sub

    'BOTONES
    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click

        Nuevo()

    End Sub
    Private Sub Nuevo()
        Contrato.Nuevo()

        bpc = Nothing
        bpa = Nothing

        LimpiarControles()

        txtCodigoCliente.Enabled = True
        txtCodigoCliente.ReadOnly = False
        txtCodigoCliente.Focus()
    End Sub
    Private Sub btnRegistrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegistrar.Click

        If Not Controles_General() Then Exit Sub
        If Not Controles_Varios() Then Exit Sub
        If Not ControlesSucursales() Then Exit Sub
        If Not Controles_DocElementos() Then Exit Sub

        Registrar()

        llenar_dgvPrincipal()

    End Sub
    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        llenar_dgvPrincipal()
    End Sub
    Private Sub btnAutorizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAutorizar.Click
        'Salgo si el contrato ya fue creado
        If Contrato.Estado = 2 Then
            MessageBox.Show("Contrato ya creado", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        'Salgo si el precontrato no tiene numero
        If Contrato.Numero = 0 Then
            MessageBox.Show("Primero crear pre contrato", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        Contrato.Grabar()

        bpc.XPQ = CInt(IIf(Contrato.PolvoQuimicoABC55, 2, 1))
        bpc.XPQE = CInt(IIf(Contrato.PolvoQuimicoABC90, 2, 1))
        bpc.xco2 = CInt(IIf(Contrato.CO2, 2, 1))
        bpc.XESPUMA = CInt(IIf(Contrato.EspumaAFFF, 2, 1))
        bpc.XHALOG = CInt(IIf(Contrato.HALOGENADO, 2, 1))
        bpc.XACETA = CInt(IIf(Contrato.ACETATO, 2, 1))
        bpc.XHI = CInt(IIf(Contrato.Hidrantes, 2, 1))
        bpc.Grabar()

        If CrearContratoServicio() Then

            Contrato.Estado = 2
            cboEstado.SelectedValue = 2
            Contrato.ContratoAdonix = ContratoServicio.Numero


            If Not bpc.EsAbonado Then
                Dim txt As String

                txt = "Este cliente no es abonado. ¿Marcar el cliente como Abonado?"

                If MessageBox.Show(txt, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    bpc.EsAbonado = True
                    bpc.Grabar()
                End If
            End If

            llenar_dgvPrincipal()

            CpyD02.abrir("DNY")
            bpc.Abrir(Contrato.ClienteCodigo)

            sre.Nueva(bpc, CpyD02)
            sre.Contrato = ContratoServicio
            sre.ContratoTipo = "CON"
            sre.CoberturaGlobal = 4
            sre.Referencia = txtOc.Text
            sre.Grabar()

            Contrato.Solicitud = sre.Numero
            Contrato.Grabar()

            Imprimir(txtId.Text, False)

        End If

    End Sub
    Private Function CrearContratoServicio() As Boolean

        With ContratoServicio
            .Nuevo(bpc)
            .Sucursal = Contrato.Sucursal

            .OrdenCompra = Contrato.OC

            If Contrato.OC <> "" Then
                .Nombre = "Orden de Compra N° " & Contrato.OC
            Else
                .Nombre = "Contrato de Abonados"
            End If

            .categoria = "Mantenimiento"
            .CondicionesPago = Contrato.CondicionPago
            .CodigoArticulo = "452000"
            .Garantia = 0
            .categoria2 = 3
            .FechaSuscripcion = Contrato.FechaCreacion
            .FechaInicio = Contrato.FechaInicio
            .FechaFin = Contrato.FechaInicio.AddMonths(Contrato.Duracion).AddDays(-1)
            .Duracion = Contrato.Duracion
            .FrecuenciaFacturacion = Contrato.FrecuenciaFacturacion
            .ModoFacturacion = Contrato.ModoFacturacion
            .Renovacion = Contrato.Renovacion

            If .ModoFacturacion = 2 Then 'Post-Facturacion
                .FechaProximaFactua = .FechaInicio.AddMonths(.FrecuenciaFacturacion)

            Else 'Pre-Facturacion
                .FechaProximaFactua = .FechaInicio

            End If
            .FechaEnvioProximaFactura = .FechaProximaFactua

            .FrecuenciaFacturacionBase = 4
            .Coeficiente = 1
            .TipoCambio = 1
            .TipoPrecio = 1
            .FrecuenciaReevaluacion = 0
            .FrecuenciaReevaluacionbase = 6
            .MetodoRevalorizacion = 1
            .MetodoRevalorizacionBase = 1
            .Importe = Contrato.ImporteAnual
            .MontoProximaFactura = .Importe / 12 * .FrecuenciaFacturacion

            .Divisa = "ARS"
            .Unificacion = Contrato.Unificacion

            .UsuarioCreacion = usr.Codigo

            'Agregar Sucursales Cubiertas
            .AgregarSucursales(dtSuc)

            'Agregar Cobertura
            If Contrato.CantidadMatafuegos > 0 Then
                .AgregarCobertura(4, "451", Contrato.CantidadMatafuegos)
            End If
            If Contrato.CantidadHidrantes > 0 Then
                .AgregarCobertura(4, "505", Contrato.CantidadHidrantes)
            End If
            If Contrato.VisitaRelevamiento Then
                .AgregarCobertura(2, "652006", Contrato.CantidadMatafuegos * 12)
            End If
            If Contrato.ControlPeriodico Then
                .AgregarCobertura(2, "652002", Contrato.CantidadMatafuegos * 4)
            End If

            Try
                .Grabar()

                MessageBox.Show("Se creó el contrato Nro. " & .Numero, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch ex As Exception
                MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False

            End Try

        End With

        Return True

    End Function
    Private Function FechaProximaFactura() As Date
        
        Select Case Contrato.FrecuenciaFacturacion
            Case 1
                Return fecha.AddMonths(+1)
            Case 2
                Return fecha.AddMonths(+2)
            Case 3
                Return fecha.AddMonths(+3)
            Case 4
                Return fecha.AddMonths(+4)
            Case 12
                Return fecha.AddMonths(+12)
        End Select

    End Function
    'VALIDACION DE CAMPOS
    Private Function Controles_General() As Boolean
        Dim flg As Boolean = True
        Dim txt As String = ""

        If txtCodigoCliente.Text.Trim = "" Then txt &= "El código de cliente es obligatorio" & vbCrLf
        If txtDescripcion.Text.Trim = "" Then txt &= "El descripción es obligatorio" & vbCrLf
        If txtConcactoComercial.Text.Trim = "" Then txt &= "Falta contacto comercial" & vbCrLf
        If txtTelefonoComercial.Text.Trim = "" Then txt &= "Falta teléfono contacto comercial" & vbCrLf
        'If txtMailComercial.Text.Trim = "" Then txt &= "Falta mail comercial" & vbCrLf
        If txtContactoOperativo.Text.Trim = "" Then txt &= "Falta contacto operativo" & vbCrLf
        If txtTelefonoOperativo.Text.Trim = "" Then txt &= "Falta teléfono contacto operativo" & vbCrLf
        'If txtMailOperativo.Text.Trim = "" Then txt &= "Falta mail contacto operativo" & vbCrLf
        'If txtHoraDesde1.Text.Trim = "" Then txt &= "Falta franja horaria 1 (Desde)" & vbCrLf
        'If txtHoraHasta1.Text.Trim = "" Then txt &= "Falta franja horaria 1 (Hasta)" & vbCrLf
        'If txtHoraDesde2.Text.Trim = "" Then txt &= "Falta franja horaria 2 (Desde)" & vbCrLf
        'If txtHoraHasta2.Text.Trim = "" Then txt &= "Falta franja horaria 2 (Hasta)" & vbCrLf

        If txt <> "" Then
            MessageBox.Show(txt, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

        Return txt = ""
    End Function
    Private Function Controles_Varios() As Boolean
        Dim flg As Boolean = True
        Dim txt As String = ""

        If nudCantidadMatafuegos.Value = 0 And nudCantidadHidrantes.Value = 0 Then
            txt = "No pueden estar en 0 Matafuegos e Hidrantes" & vbCrLf
        End If

        If optTarjeta1.Checked = False And optTarjeta2.Checked = False And optTarjeta3.Checked = False Then
            txt &= "Falta seleccionar Tarjetas"
        End If

        If txt <> "" Then
            MessageBox.Show(txt, Me.Text, MessageBoxButtons.OK)
        End If

        Return txt = ""

    End Function
    Private Function ControlesSucursales() As Boolean
        Dim txt As String = ""
        If dgvSucursales.RowCount = 0 Then
            txt = "Debe seleccionar por lo menos una (1) sucursal"
        End If
        If txt <> "" Then
            MessageBox.Show(txt, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

        Return txt = ""
    End Function
    Private Function Controles_DocElementos() As Boolean
        Dim flg As Boolean = True
        Dim txt As String = ""

        If nudUnificacion.Value = 0 Then txt &= "Falta cantidad de visitas" & vbCrLf
        If txtImporteAnual.Text.Trim = "" Then txt &= "Falta importe anual" & vbCrLf
        If txtImporteMensual.Text.Trim = "" Then txt &= "Falta importe mensual" & vbCrLf
        If nudFrecuenciaFacturacion.Value = 0 Then txt &= "Falta frecuencia facturación" & vbCrLf
        If cboCondicionPago.SelectedValue.ToString.Trim = "" Then txt &= "Falta condición de pago" & vbCrLf
        If CInt(txtImporteAnual.Text) < 1 Then txt &= "El importe anual debe ser mayor a 0" & vbCrLf

        If txt <> "" Then
            MessageBox.Show(txt, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

        Return txt = ""

    End Function

    Private Sub ImporteAnual_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtImporteAnual.Validating
        If txtImporteAnual.Text.Trim = "" Then
        Else
            txtImporteMensual.Text = (CDbl(txtImporteAnual.Text) / 12).ToString
        End If

    End Sub
    Private Sub txtmatacantidad_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtImporteAnual.Validating, txtImporteMensual.Validating
        Dim txt As TextBox = CType(sender, TextBox)
        Dim ok As Boolean = True

        If Not IsNumeric(txt.Text) Then
            MessageBox.Show("El valor no es válido", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            ok = False
        End If

        e.Cancel = Not ok
    End Sub
    Private Sub txtCodigoCliente_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodigoCliente.Validated
        If txtCodigoCliente.Text <> "" Then
            EstablecerCliente()
        End If
    End Sub
    Private Sub EstablecerCliente()
        If bpc IsNot Nothing Then
            Contrato.ClienteCodigo = bpc.Codigo
            txtCodigoCliente.Text = bpc.Codigo
            txtNombreCliente.Text = bpc.Nombre
            txtCodigoCliente.ReadOnly = True
            tab.Enabled = True
            cboVendedor.SelectedValue = bpc.Vendedor1Codigo
            txtDescripcion.Text = "Contrato de Abonados"
            cboCondicionPago.SelectedValue = bpc.CondicionPago.Codigo.ToString

            cboSucursal.DataSource = bpc.SucursalesTabla
            cboSucursal.DisplayMember = "direccion"
            cboSucursal.ValueMember = "bpaadd_0"
            cboSucursal.SelectedValue = bpc.SucursalFactura
            cboSucursal.Enabled = True

        End If

        If txtId.Text = "" Then
            BtnImprimir.Enabled = True
        ElseIf txtId.Text = " " Then
            BtnImprimir.Enabled = False
        End If
    End Sub
    Private Sub CargarTodasSucursales()

        Dim dr As DataRow
        Dim suc As Sucursal

        dtSuc.Clear()

        For Each suc In bpc.Sucursales
            dr = dtSuc.NewRow
            dr("bpaadd_0") = suc.Sucursal
            dr("bpaaddlig_0") = suc.Direccion
            dr("cty_0") = suc.Ciudad
            dtSuc.Rows.Add(dr)
        Next

    End Sub
    Private Sub CargarSucursales(ByVal dt2 As DataTable)
        'Carga las sucursales que contiene la tabla dt2
        Dim dr1 As DataRow
        Dim dr2 As DataRow
        Dim suc As New Sucursal(cn)

        dtSuc.Clear()

        For Each dr2 In dt2.Rows
            If suc.Abrir(bpc.Codigo, dr2(1).ToString) Then
                dr1 = dtSuc.NewRow
                dr1("bpaadd_0") = dr2("bpaadd_0")
                dr1("bpaaddlig_0") = suc.Direccion
                dr1("cty_0") = suc.Ciudad
                dtSuc.Rows.Add(dr1)
            End If
        Next

        suc = Nothing

    End Sub
    Private Sub txtCodigoCliente_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodigoCliente.Validating
        Dim txt As String = ""

        txt = txtCodigoCliente.Text.Trim

        If txt <> "" Then
            If bpc Is Nothing OrElse bpc.Codigo <> txt Then
                Dim cli As New Cliente(cn)

                If Not cli.Abrir(txt) OrElse cli.Tipo <> 1 Then
                    MessageBox.Show("Cliente no encontrado", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    e.Cancel = True

                Else

                    bpc = cli
                End If
            End If
        End If

    End Sub
    Private Sub btnAgregarTodas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarTodas.Click
        CargarTodasSucursales()
    End Sub
    Private Sub btnAgregarSucursal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarSucursal.Click

        Dim txt As String

        txt = InputBox("Ingrese el codigo de sucursal", "Agregar Sucursal")

        If txt <> "" Then
            If bpc.ExisteSucursal(txt) Then
                Dim dr As DataRow

                'Verifico que no exista la sucursal en la grilla
                dtSuc.AcceptChanges()
                For Each dr In dtSuc.Rows
                    If dr("bpaadd_0").ToString = txt Then Exit Sub
                Next

                'Agrego la sucursal a la grilla
                Dim suc = bpc.Sucursal(txt)
                dr = dtSuc.NewRow
                dr("bpaadd_0") = suc.Sucursal
                dr("bpaaddlig_0") = suc.Direccion
                dr("cty_0") = suc.Ciudad
                dtSuc.Rows.Add(dr)
            Else
                MessageBox.Show("No se encontró la sucursal", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)

            End If
        End If
    End Sub
    Private Sub txtVisitasAnuales_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        Dim txt As TextBox = CType(sender, TextBox)
        Dim i As Integer

        If Not IsNumeric(txt.Text) Then
            MessageBox.Show("El dato debe ser numérico", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            e.Cancel = True
        End If

        If Not e.Cancel Then

            i = CInt(txt.Text)

            Select Case i
                Case 1, 2, 3, 12
                Case Else
                    MessageBox.Show("Valores permitidos: 1, 2, 3, 12", Me.Text, MessageBoxButtons.OK)
                    e.Cancel = True
            End Select

        End If

    End Sub
    Private Sub nudUnificacion_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles nudUnificacion.Validating

        Select Case nudUnificacion.Value
            Case 1, 2, 3, 4, 12
            Case Else
                MessageBox.Show("Valores permitidos: 1, 2, 3, 4, 12", Me.Text, MessageBoxButtons.OK)
                e.Cancel = True
        End Select

    End Sub
    Private Sub txtMailComercial_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtMailComercial.Validating
        Dim txt As TextBox = CType(sender, TextBox)

        If txt.Text.Trim = "" Then Exit Sub

        If Not Utiles.ValidarMails(txt.Text) Then
            MessageBox.Show("Mail inválido", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            e.Cancel = True
        End If
    End Sub
    Private Sub txtMailOperativo_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtMailOperativo.Validating
        Dim txt As TextBox = CType(sender, TextBox)

        If txt.Text.Trim = "" Then Exit Sub

        If Not Utiles.ValidarMails(txt.Text) Then
            MessageBox.Show("Mail inválido", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            e.Cancel = True
        End If
    End Sub
    Private Sub txtTelefonoComercial_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtTelefonoComercial.Validating
        If txtTelefonoComercial.Text.Length < 8 Then
            MessageBox.Show("La longitud minima tiene que ser de 8 caracteres", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            e.Cancel = True
        End If
    End Sub
    Private Sub txtTelefonoOperativo_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtTelefonoOperativo.Validating
        If txtTelefonoOperativo.Text.Length < 8 Then
            MessageBox.Show("La longitud minima tiene que ser de 8 caracteres", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            e.Cancel = True
        End If
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImprimir.Click

        If txtId.Text = "" Then Exit Sub

        Imprimir(txtId.Text, True)

    End Sub
    Private Sub Imprimir(ByVal Id As String, ByVal Previsualizar As Boolean)
        Dim rpt As New ReportDocument
        Dim nro As Integer = CInt(Id)
        Dim crystal As frmCrystal

        Try
            rpt.Load(RPTX3 & "xcontratos.rpt")
            rpt.SetDatabaseLogon(DB_USR, DB_PWD)
            rpt.SetParameterValue("nro", nro)
            rpt.SetParameterValue("connum", " ")

            If Previsualizar Then
                crystal = New frmCrystal(rpt)
                crystal.MdiParent = Me.ParentForm
                crystal.Show()
            Else
                rpt.PrintToPrinter(2, False, 1, 999)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub BuscarRenovaciones()
        Dim dt As DataTable
        Dim da As OracleDataAdapter
        Dim sql As String
        Dim d As Date

        'Fecha para filtrar contratos a vencer
        d = New Date(Today.Year, Today.Month, 1)

        sql = "select connum_0, bpcnum_0, bpcnam_0, conenddat_0, invmet_0 "
        sql &= "from contserv con inner join  "
        sql &= "     bpcustomer bpc on (conbpc_0 = bpcnum_0) "
        sql &= "where itmref_0 not like '5530%' and "
        sql &= "	  bpc.rep_0 in (select rep_0 from xnetvenc where usr_0 = :usr and (abo_0 = 1 or noabo_0 = 1)) and "
        sql &= "	  conenddat_0 >= :desde and "
        sql &= "	  conenddat_0 < :hasta and "
        sql &= "	  fddflg_0 <> 2 "
        sql &= "order by conenddat_0"

        da = New OracleDataAdapter(sql, cn)
        da.SelectCommand.Parameters.Add("usr", OracleType.VarChar).Value = usr.Codigo
        da.SelectCommand.Parameters.Add("desde", OracleType.DateTime).Value = d.AddMonths(-2)
        da.SelectCommand.Parameters.Add("hasta", OracleType.DateTime).Value = d.AddMonths(1)

        If dgvRenovar.DataSource Is Nothing Then
            dt = New DataTable
            colNro2.DataPropertyName = "connum_0"
            colCliente2.DataPropertyName = "bpcnum_0"
            colNombre2.DataPropertyName = "bpcnam_0"
            colVto2.DataPropertyName = "conenddat_0"
            colModo2.DataPropertyName = "invmet_0"
            dgvRenovar.DataSource = dt

        Else
            dt = CType(dgvRenovar.DataSource, DataTable)

        End If

        dt.Clear()
        da.Fill(dt)

    End Sub
    Private Sub btnRenovaciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRenovaciones.Click
        BuscarRenovaciones()
    End Sub
    Private Sub dgvRenovar_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRenovar.CellDoubleClick
        Dim dr As DataRow
        Dim con As New ContratoServicio(cn)

        dr = CType(dgvRenovar.Rows(e.RowIndex).DataBoundItem, DataRowView).Row

        con.Abrir(dr("connum_0").ToString)

        Nuevo()

        If bpc Is Nothing Then bpc = New Cliente(cn)
        bpc.Abrir(con.Cliente)
        EstablecerCliente()

        cboSucursal.SelectedValue = con.Sucursal

        CargarSucursales(con.Sucursales)

        txtImporteAnual.Text = con.Importe.ToString
        cboCondicionPago.SelectedValue = con.CondicionesPago
        nudFrecuenciaFacturacion.Value = con.FrecuenciaFacturacion
        cboModoFacturacion.SelectedValue = con.ModoFacturacion
        nudUnificacion.Value = con.Unificacion

        chkPq55.Checked = bpc.XPQ = 2 ' CInt(IIf(Contrato.PolvoQuimicoABC55, 2, 1))
        chkPq90.Checked = bpc.XPQE = 2 'CInt(IIf(Contrato.PolvoQuimicoABC90, 2, 1))
        chkCo2.Checked = bpc.xco2 = 2 'CInt(IIf(Contrato.CO2, 2, 1))
        chkAfff.Checked = bpc.XESPUMA = 2 'CInt(IIf(Contrato.EspumaAFFF, 2, 1))
        chkHalogenados.Checked = bpc.XHALOG = 2 'CInt(IIf(Contrato.HALOGENADO, 2, 1))
        chkAcetato.Checked = bpc.XACETA = 2 'CInt(IIf(Contrato.ACETATO, 2, 1))

        nudCantidadMatafuegos.Value = con.CantidadCubierta("451")
        nudCantidadHidrantes.Value = con.CantidadCubierta("505")

        chkVisita.Checked = con.CantidadCubierta("652006") > 0
        chkControlPeriodico.Checked = con.CantidadCubierta("652002") > 0

    End Sub

    Private Sub cms_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cms.Opening
        mnuEditar.Enabled = (txtCodigoCliente.Text.Trim <> "")
    End Sub

    Private Sub mnuEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEditar.Click
        Dim bpc As New Cliente(cn)

        If bpc.Abrir(txtCodigoCliente.Text.Trim) Then
            Dim f As New frmCliente(txtCodigoCliente.Text.Trim)
            f.ShowDialog(Me)
        End If

    End Sub

End Class