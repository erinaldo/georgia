Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.OracleClient

Public Class frmValidar
    Private BloqueoModificacion As Boolean = False
    Private ds As New DataSet
    Private WithEvents daRutac As OracleDataAdapter
    Private daRutad As OracleDataAdapter
    Private WithEvents dtRutac As New DataTable
    Private WithEvents dtRutad As New DataTable

    'EVENTOS
    Private Sub frmValidar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Adaptadores()

        AddHandler dgvGrilla.RowPostPaint, AddressOf NumeracionGrillas

        ds.Tables.Add(dtRutac)
        ds.Tables.Add(dtRutad)

        Try
            daRutac.FillSchema(dtRutac, SchemaType.Mapped)
            daRutad.FillSchema(dtRutad, SchemaType.Mapped)

            'Enlace de la grilla
            colOrden.DataPropertyName = "orden_0"
            colDomicilio.DataPropertyName = "direccion_0"
            colLocalidad.DataPropertyName = "localidad_0"
            colNombre.DataPropertyName = "nombre_0"
            colTipo.DataPropertyName = "tipo_0"
            colDocumento.DataPropertyName = "vcrnum_0"
            colEquipos.DataPropertyName = "equipos_0"
            colEquipos2.DataPropertyName = "equipos_1"
            colMangas.DataPropertyName = "equipos_2"
            colMangas2.DataPropertyName = "equipos_3"
            colPrestamosExtT.DataPropertyName = "prestamos_0"
            colPrestamosExtR.DataPropertyName = "prestamos_1"
            colPrestamosManT.DataPropertyName = "prestamos_2"
            colPrestamosManR.DataPropertyName = "prestamos_3"
            colRetencion1.DataPropertyName = "retencion_0"
            colRetencion2.DataPropertyName = "retencion_1"
            colInstalaciones.DataPropertyName = "install_0"
            colInstalaciones2.DataPropertyName = "install_1"
            colRuta.DataPropertyName = "ruta_0"
            With colEstado
                .DataPropertyName = "estado_0"
                .DataSource = TablaEstadosRuta(cn)
                .DisplayMember = "texte_0"
                .ValueMember = "code_0"
            End With
            With colNoconform
                .DataSource = TablaMotivos(cn)
                .DisplayMember = "texte_0"
                .ValueMember = "code_0"
                .DataPropertyName = "noconform_0"
            End With
            With colSube
                .DataPropertyName = "sube_0"
                .DataSource = MenuLocal(cn, 1)
                .DisplayMember = "lanmes_0"
                .ValueMember = "lannum_0"
            End With
            colHoraInicio.DataPropertyName = "tiempo_0"
            colHoraFin.DataPropertyName = "tiempo_1"
            colCliente.DataPropertyName = "cliente_0"
            colSucursal.DataPropertyName = "suc_0"
            colRechazosE.DataPropertyName = "rechazos_0"
            colRechazosM.DataPropertyName = "rechazos_1"
            colCobranza.DataPropertyName = "cobranza_0"
            colVarios.DataPropertyName = "varios_0"
            colPrioridad.DataPropertyName = "Prioridad_0"
            colHora.DataPropertyName = "hora_0"
            colKilos.DataPropertyName = "kilos_0"
            colCredat.DataPropertyName = "credat_0"
            colCreusr.DataPropertyName = "creusr_0"
            colObs.DataPropertyName = "obs_0"

            dgvGrilla.DataSource = dtRutad

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub
    Private Sub frmValidar_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not (e.CloseReason = CloseReason.TaskManagerClosing Or e.CloseReason = CloseReason.WindowsShutDown) Then
            If ds.HasChanges Then
                Select Case MessageBox.Show("¿Graba los cambios antes de salir?", Me.Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                    Case Windows.Forms.DialogResult.Yes
                        Grabar()

                    Case Windows.Forms.DialogResult.Cancel
                        e.Cancel = True

                End Select
            End If
        End If
    End Sub
    Private Sub dgvGrilla_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dgvGrilla.CellValidating
        Dim row As DataGridViewRow = dgvGrilla.Rows(e.RowIndex)
        Dim col As DataGridViewColumn = dgvGrilla.Columns(e.ColumnIndex)

        Dim c As DataGridViewCell = dgvGrilla.Rows(e.RowIndex).Cells(e.ColumnIndex)

        Select Case dgvGrilla.Columns(e.ColumnIndex).Name
            Case "colEstado"
                Select Case e.FormattedValue.ToString.Substring(0, 1)
                    Case "1", "2"   '1 = Próximo Destino | 2 = En ejecución
                        MessageBox.Show("Estado no permitido", "Error en zona estado", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        e.Cancel = True

                End Select

            Case "colHoraInicio", "colHoraFin"
                If Not ValidarHora(e.FormattedValue.ToString) Then e.Cancel = True

        End Select

    End Sub
    Private Sub dgvGrilla_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvGrilla.CellValueChanged
        If e.RowIndex = -1 OrElse e.ColumnIndex = -1 Then Exit Sub

        Dim Row As DataGridViewRow = dgvGrilla.Rows(e.RowIndex)
        Dim Col As DataGridViewColumn = dgvGrilla.Columns(e.ColumnIndex)
        Dim Cell As DataGridViewCell = dgvGrilla.Rows(e.RowIndex).Cells(e.ColumnIndex)

        Select Case dgvGrilla.Columns(e.ColumnIndex).Name
            Case "colEstado"

                Select Case Cell.Value.ToString
                    Case "0"    'Pendiente
                        Row.Cells("colNoconform").Value = 0
                        Row.Cells("colEquipos2").Value = 0
                        Row.Cells("colMangas2").Value = 0
                        Row.Cells("colPrestamosExtR").Value = 0
                        Row.Cells("colPrestamosManR").Value = 0
                        Row.Cells("colInstalaciones2").Value = 0
                        Row.Cells("colHoraInicio").Value = "0000"
                        Row.Cells("colHoraFin").Value = "0000"
                        Row.Cells("colSube").Value = 1

                    Case "3"    'Cumplido
                        Row.Cells("colNoconform").Value = 0
                        Row.Cells("colEquipos2").Value = Row.Cells("colEquipos").Value
                        Row.Cells("colMangas2").Value = Row.Cells("colMangas").Value
                        Row.Cells("colPrestamosExtR").Value = Row.Cells("colPrestamosExtT").Value
                        Row.Cells("colPrestamosManR").Value = Row.Cells("colPrestamosManT").Value
                        Row.Cells("colInstalaciones2").Value = Row.Cells("colInstalaciones").Value
                        Row.Cells("colSube").Value = 1

                    Case "4"    'No conforme
                        Row.Cells("colNoconform").Value = 1
                        Row.Cells("colEquipos2").Value = 0
                        Row.Cells("colMangas2").Value = 0
                        Row.Cells("colPrestamosExtR").Value = 0
                        Row.Cells("colPrestamosManR").Value = 0
                        Row.Cells("colInstalaciones2").Value = 0

                End Select

                ActivarCeldas(Row)

            Case "colNoconform"
                'Consulto si el motivo del rebote requiere registro de horario
                Dim dtMotivos As DataTable = CType(colNoconform.DataSource, DataTable)
                Dim dv As New DataView(dtMotivos)
                dv.RowFilter = "code_0 = " & Row.Cells("colEstado").Value.ToString

                If dv.Count = 1 Then
                    Row.Cells("colHoraInicio").ReadOnly = Not CBool(dv.Item(0).Item("n1_0"))
                    Row.Cells("colHoraFin").ReadOnly = Not CBool(dv.Item(0).Item("n1_0"))
                End If

            Case "colObs"
                If Cell.Value.ToString = "" Then Cell.Value = " "

        End Select

    End Sub
    Private Sub dgvGrilla_DataBindingComplete(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles dgvGrilla.DataBindingComplete
        Dim dr As DataGridViewRow

        For Each dr In dgvGrilla.Rows
            ActivarCeldas(dr)
        Next

    End Sub
    Private Sub dtpFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFecha.ValueChanged
        If dtRutac.Rows.Count = 0 Or BloqueoModificacion Then Exit Sub

        With dtRutac.Rows(0)
            .BeginEdit()
            .Item("fecha_0") = dtpFecha.Value
            .EndEdit()
        End With
    End Sub
    Private Sub mtb_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles mtbCarga.GotFocus, mtbRegreso.GotFocus, mtbSalida.GotFocus, mtbDescarga.GotFocus
        CType(sender, MaskedTextBox).SelectAll()
    End Sub
    Private Sub mtbCarga_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles mtbCarga.LostFocus, mtbSalida.LostFocus, mtbRegreso.LostFocus, mtbDescarga.LostFocus, mtbAlmuerzoDesde.LostFocus, mtbAlmuerzoHasta.LostFocus
        If dtRutac.Rows.Count = 0 Or BloqueoModificacion Then Exit Sub

        With dtRutac.Rows(0)
            .BeginEdit()
            If CType(sender, MaskedTextBox) Is mtbCarga Then
                .Item("hora_0") = CType(sender, MaskedTextBox).Text

            ElseIf CType(sender, MaskedTextBox) Is mtbSalida Then
                .Item("hora_1") = CType(sender, MaskedTextBox).Text

            ElseIf CType(sender, MaskedTextBox) Is mtbRegreso Then
                .Item("hora_2") = CType(sender, MaskedTextBox).Text

            ElseIf CType(sender, MaskedTextBox) Is mtbDescarga Then
                .Item("hora_3") = CType(sender, MaskedTextBox).Text

            ElseIf CType(sender, MaskedTextBox) Is mtbAlmuerzoDesde Then
                .Item("almuerzo_0") = CType(sender, MaskedTextBox).Text

            ElseIf CType(sender, MaskedTextBox) Is mtbAlmuerzoHasta Then
                .Item("almuerzo_1") = CType(sender, MaskedTextBox).Text

            End If
            .EndEdit()
        End With

    End Sub
    Private Sub mtb_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mtbCarga.Validating, mtbRegreso.Validating, mtbSalida.Validating
        Dim mtb As MaskedTextBox = CType(sender, MaskedTextBox)

        If BloqueoModificacion Then Exit Sub

        If Not ValidarHora(mtb.Text) Then
            MessageBox.Show("La hora no es válida", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            e.Cancel = True
        End If

    End Sub
    Private Sub nudPrestamos_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudPrestamosExtC.ValueChanged, nudPrestamosExtD.ValueChanged, nudPrestamosManC.ValueChanged, nudPrestamosManD.ValueChanged, nudDemoras.Validated
        If dtRutac.Rows.Count = 0 Or BloqueoModificacion Then Exit Sub

        With dtRutac.Rows(0)
            .BeginEdit()
            If sender Is nudPrestamosExtC Then
                .Item("prestamos_0") = CType(sender, NumericUpDown).Value

            ElseIf sender Is nudPrestamosExtD Then
                .Item("prestamos_1") = CType(sender, NumericUpDown).Value

            ElseIf sender Is nudPrestamosManC Then
                .Item("mangas_0") = CType(sender, NumericUpDown).Value

            ElseIf sender Is nudPrestamosManD Then
                .Item("mangas_1") = CType(sender, NumericUpDown).Value

            ElseIf sender Is nudDemoras Then
                .Item("demora_0") = CType(sender, NumericUpDown).Value

            End If
            .EndEdit()
        End With

    End Sub
    Private Sub dtRutac_RowChanged(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs) Handles dtRutac.RowChanged
        ActualizarControles()
    End Sub
    Private Sub dtRutad_RowChanged(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs) Handles dtRutad.RowChanged
        ActualizarControles()
    End Sub
    Private Sub btnAbrir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbrir.Click
        Dim f As New frmSelectorRuta

        f.ShowDialog(Me)

        If f.DialogResult = Windows.Forms.DialogResult.OK Then

            'Parametros de las consultas
            daRutac.SelectCommand.Parameters(0).Value = f.Ruta
            daRutad.SelectCommand.Parameters(0).Value = f.Ruta

            dtRutac.Clear()
            dtRutad.Clear()

            Try
                daRutac.Fill(dtRutac)
                daRutad.Fill(dtRutad)

                CargarDatosCabecera()
                ActualizarControles()

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub

            End Try

        End If

        f.Dispose() : f = Nothing

    End Sub
    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        Grabar()
    End Sub
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Dim dr As DataRow = dtRutac.Rows(0)

        ds.RejectChanges()
        CargarDatosCabecera()
        ActualizarControles()
    End Sub
    Private Function validar_acomp(ByVal acompañante As String, ByVal fecha As DateTime) As Boolean

        Dim dt As New DataTable
        Dim da As OracleDataAdapter
        Dim sql As String = ""

        sql = "select * from xrutac where valid_0 = 1 and fecha_0 = :fecha "
        sql &= " and (acomp_0 = :acomp or acomp_1 = :acomp or acomp_2 = :acomp)"
        da = New OracleDataAdapter(sql, cn)
        da.SelectCommand.Parameters.Add("acomp", OracleType.VarChar).Value = acompañante
        da.SelectCommand.Parameters.Add("fecha", OracleType.DateTime).Value = fecha
        da.Fill(dt)

        Return dt.Rows.Count > 0


    End Function

    Private Function validar_horario(ByVal acompañante As String, ByVal fecha As DateTime, ByVal horainicio As Integer, ByVal horafin As Integer) As Boolean

        Dim dt As New DataTable
        Dim da As OracleDataAdapter
        Dim sql As String = ""

        sql = "select * from xrutac where valid_0 = 1 and fecha_0 = :fecha "
        sql &= " and (acomp_0 = :acomp or acomp_1 = :acomp or acomp_2 = :acomp)"
        sql &= " and (:horainicio > hora_3) "
        da = New OracleDataAdapter(sql, cn)
        da.SelectCommand.Parameters.Add("acomp", OracleType.VarChar).Value = acompañante
        da.SelectCommand.Parameters.Add("horainicio", OracleType.Int16).Value = horainicio
        da.SelectCommand.Parameters.Add("fecha", OracleType.DateTime).Value = fecha
        da.Fill(dt)

        Return dt.Rows.Count > 0


    End Function
    Private Sub btnValidar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnValidar.Click
        Dim dr As DataRow
        Dim HayError As Boolean = False

        'La ruta ya está validada
        dr = dtRutac.Rows(0)
        If CInt(dr("valid_0")) = 1 Then
            MessageBox.Show("Esta ruta ya fue validada", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        'Valida si hay otro acompañante en ruta el mismo dia
        If CInt(dr("acomp_0")) > 0 And CInt(dr("acomp_0")) <> 115 Then
            If validar_acomp(dr("acomp_0").ToString, dtpFecha.Value) Then
                If Not validar_horario(dr("acomp_0").ToString, dtpFecha.Value, CInt(mtbCarga.Text), CInt(mtbDescarga.Text)) Then
                    MsgBox("Hay Rutas Ya validadas con ese acompañante")
                    Exit Sub
                End If
            ElseIf CInt(dr("acomp_1")) > 0 And CInt(dr("acomp_1")) <> 115 Then
                If validar_acomp(dr("acomp_1").ToString, dtpFecha.Value) Then
                    If Not validar_horario(dr("acomp_1").ToString, dtpFecha.Value, CInt(mtbCarga.Text), CInt(mtbDescarga.Text)) Then
                        MsgBox("Hay Rutas Ya validadas con ese acompañante")
                        Exit Sub
                    End If
                ElseIf CInt(dr("acomp_2")) > 0 And CInt(dr("acomp_2")) <> 115 Then
                    If validar_acomp(dr("acomp_2").ToString, dtpFecha.Value) Then
                        If Not validar_horario(dr("acomp_2").ToString, dtpFecha.Value, CInt(mtbCarga.Text), CInt(mtbDescarga.Text)) Then
                            MsgBox("Hay Rutas Ya validadas con ese acompañante")
                            Exit Sub
                        End If
                    End If

                End If
            End If
        End If

        'Validacion que haya seleccionado un transporte
        If cboTransportes.SelectedValue Is Nothing OrElse cboVehiculos.SelectedValue Is Nothing Then
            MessageBox.Show("Falta seleccionar transportista", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        If ds.HasChanges Then Grabar()

        'Se valida que no existan documentos pendientes
        For Each dr In dtRutad.Rows
            If CInt(dr("estado_0")) < 3 Then
                dr.RowError = "No se puede validar una ruta con documentos pendientes"
                HayError = True
            End If
        Next

        If HayError Then
            MessageBox.Show("No se puede validar una ruta con documentos pendientes", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dgvGrilla.Refresh()
            Exit Sub
        End If
        'Verifico que hora salida sea mayor que hora carga
        If mtbSalida.Text < mtbCarga.Text Then
            MessageBox.Show("La hora de salida no puede ser menor que la hora de carga", "Hora", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            mtbSalida.Focus()
            Exit Sub
        End If
        'Verifico que la hora de regreso no sea menor que la hora de salida
        If mtbRegreso.Text <= mtbSalida.Text Then
            MessageBox.Show("La hora de regreso debe ser mayor a la hora de salida", "Hora", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            mtbRegreso.Focus()
            Exit Sub
        End If
        'Verifico que la hora de fin descarga no sea menor que la hora de regreso a fabrica
        If mtbDescarga.Text <= mtbRegreso.Text Then
            MessageBox.Show("La hora de fin de descarga debe ser mayor a la hora de regreso a fabrica", "Hora", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            mtbRegreso.Focus()
            Exit Sub
        End If

        'Validación encadenamiento de horarios
        If Not ValidarHorarios() Then Exit Sub

        'Balance de préstamos
        If Not BalancePrestamos() Then Exit Sub

        'Valido que en caso de diferencia de prestamos el campo observaciones no esté vacío
        If Not ObservacionesObligatorias() Then Exit Sub

        'Valido si hay retencion cuando faltan prestamos
        If Not ValidarRetenciones() Then Exit Sub

        'Rutina de prestamos
        MoverPrestamos()

        'CANJE: Cantidad de canjes recuperador debe ser igual a las intervenciones realizadas
        If Not ValidarCanjes() Then
            MessageBox.Show("Error en recupero de canjes", "Canje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If Not ValidarCanjesObservaciones() Then Exit Sub

        'Cambio de estado a intervenciones
        ActualizarEstadoDocumentos()

        'Marco ruta como validada
        dr = dtRutac.Rows(0)
        dr.BeginEdit()
        dr("valid_0") = 1
        dr("validusr_0") = usr.Codigo
        dr("validdat_0") = Date.Today
        dr.EndEdit()

        Try
            daRutac.Update(dtRutac)
            daRutad.Update(dtRutad)

            ProcesarControles() 'Función que reagenda controles periodicos

            Acompanantes()

            ActualizarControles()

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()

        End Try

        ActualizarFox()

    End Sub
    
    Private Sub btnOT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOT.Click
        'Dim f As frmOT
        Dim f As frmIntervencion
        Dim dr As DataRow

        If ds.HasChanges Then
            MessageBox.Show("Primero debe grabar los cambios", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        'f = New frmOT
        f = New frmIntervencion
        f.ShowDialog(Me)

        If f.DialogResult = Windows.Forms.DialogResult.OK Then
            Dim doc As New Documento(cn)

            doc.Buscar(f.Documento.Numero)

            'Agregar la intervención creada a la ruta
            With f
                dr = dtRutad.NewRow
                dr("ruta_0") = CInt(txtRuta.Text)
                dr("tipo_0") = doc.Tipo
                dr("vcrnum_0") = .Documento.Numero
                dr("suc_0") = .Documento.SucursalCodigo
                dr("direccion_0") = .Documento.SucursalCalle
                dr("localidad_0") = .Documento.SucursalCiudad
                dr("cliente_0") = .txtCodigoCliente.Text
                dr("nombre_0") = .txtNombreCliente.Text
                dr("equipos_0") = doc.Equipos
                dr("equipos_1") = doc.Equipos
                dr("equipos_2") = doc.Mangueras
                dr("equipos_3") = doc.Mangueras
                dr("prestamos_0") = doc.PrestamosExtintores
                dr("prestamos_1") = doc.PrestamosExtintores
                dr("prestamos_2") = doc.PrestamosMangueras
                dr("prestamos_3") = doc.PrestamosMangueras
                dr("retencion_0") = 0
                dr("retencion_1") = 0
                dr("install_0") = 0
                dr("install_1") = 0
                dr("rechazos_0") = 0
                dr("rechazos_1") = 0
                dr("cobranza_0") = 0
                dr("varios_0") = 0
                dr("prioridad_0") = 0
                dr("hora_0") = " "
                dr("kilos_0") = 0
                dr("estado_0") = 3
                dr("noconform_0") = 0
                dr("sube_0") = 1
                dr("orden_0") = OrdenSiguiente()
                dr("tiempo_0") = "0000"
                dr("tiempo_1") = "0000"
                dr("credat_0") = Date.Today
                dr("creusr_0") = usr.Codigo
                dr("obs_0") = " "
                dtRutad.Rows.Add(dr)
            End With

            doc = Nothing

            Grabar()

            ImprimirNuevaIntervencion(dr("vcrnum_0").ToString)

        End If

        f.Close()
        f.Dispose()
        f = Nothing
    End Sub
    Private Sub chkTeorico_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTeorico.CheckedChanged
        With dgvGrilla
            .Columns("colEquipos").Visible = chkTeorico.Checked
            .Columns("colMangas").Visible = chkTeorico.Checked
            .Columns("colPrestamosExtT").Visible = chkTeorico.Checked
            .Columns("colPrestamosManT").Visible = chkTeorico.Checked
            .Columns("colInstalaciones").Visible = chkTeorico.Checked
        End With
    End Sub
    Private Sub cboTransportes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTransportes.SelectedIndexChanged
        If BloqueoModificacion = False Then
            TablaVehiculos(cboVehiculos, cboTransportes.SelectedValue.ToString)
            cboVehiculos.SelectedItem = Nothing
        End If
    End Sub
    Private Sub cboVehiculos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboVehiculos.SelectedIndexChanged
        If BloqueoModificacion = False Then
            With dtRutac.Rows(0)
                .BeginEdit()
                .Item("transporte_0") = cboTransportes.SelectedValue.ToString
                If cboVehiculos.SelectedValue IsNot Nothing Then
                    .Item("patente_0") = cboVehiculos.SelectedValue.ToString
                End If
                .EndEdit()
            End With

            AcompanantesOnOff()

        End If
    End Sub
    Private Sub cboAcompante1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAcompante1.SelectedIndexChanged, cboAcompante2.SelectedIndexChanged, cboAcompante3.SelectedIndexChanged
        If dtRutac.Rows.Count = 0 Or BloqueoModificacion Then Exit Sub

        With dtRutac.Rows(0)
            .BeginEdit()
            If sender Is cboAcompante1 Then
                If Not cboAcompante1.SelectedValue Is Nothing Then
                    .Item("acomp_0") = cboAcompante1.SelectedValue
                End If

            ElseIf sender Is cboAcompante2 Then
                If Not cboAcompante2.SelectedValue Is Nothing Then
                    .Item("acomp_1") = cboAcompante2.SelectedValue
                End If

            ElseIf sender Is cboAcompante3 Then
                If Not cboAcompante3.SelectedValue Is Nothing Then
                    .Item("acomp_2") = cboAcompante3.SelectedValue
                End If
            End If
            .EndEdit()
        End With

    End Sub

    'SUB
    Private Sub Acompanantes()
        'Envia mail si la cantidad de acompañantes es mayor a la permitida
        'en camionetas de LOGISTICA segun la cantidad de movimientos de equipos
        Dim pat As New Camioneta(cn)

        pat.Abrir(cboTransportes.SelectedValue.ToString, cboVehiculos.SelectedValue.ToString)

        If pat.Sector = LOGISTICA AndAlso pat.Acomp <= 1 Then
            'Mas dos acompañantes con menos movimientos permitidos
            If CantidadAcompanantes() >= 2 AndAlso CantidadMovimientos() <= MOVIMIENTOS Then
                Dim txt As String

                txt = "La ruta {ruta} fue validada con {acompanantes} acompañantes y {movimientos} movimiento(s)"
                txt = txt.Replace("{ruta}", txtRuta.Text)
                txt = txt.Replace("{acompanantes}", CantidadAcompanantes.ToString)
                txt = txt.Replace("{movimientos}", CantidadMovimientos.ToString)

                Dim eMail As New CorreoElectronico
                eMail.Nuevo()
                eMail.Remitente("no-responder@georgia.com.ar", "Sistema Automatico")
                eMail.Asunto = "Validación de ruta " & txtRuta.Text
                eMail.EsHtml = False
                eMail.Cuerpo = txt
                'eMail.AgregarDestinatario("mmino@matafuegosgeorgia.com")
                eMail.AgregarDestinatario("jguzzetti@georgia.com.ar")
                eMail.Enviar()
            End If
        End If

    End Sub
    Private Sub AcompanantesOnOff()
        If cboTransportes.SelectedValue Is Nothing Then Exit Sub
        If cboVehiculos.SelectedValue Is Nothing Then Exit Sub

        Dim pat As New Camioneta(cn)

        pat.Abrir(cboTransportes.SelectedValue.ToString, cboVehiculos.SelectedValue.ToString)

        cboAcompante1.Enabled = Not (pat.Sector = LOGISTICA AndAlso pat.Acomp > 1)
        cboAcompante2.Enabled = True
        cboAcompante3.Enabled = (pat.Sector <> LOGISTICA)

        pat = Nothing

    End Sub
    Private Sub ActualizarControles()

        If dtRutac.Rows.Count < 1 Then Exit Sub

        Dim dr As DataRow = dtRutac.Rows(0)
        Dim RutaValidada As Boolean = CType(dr("valid_0"), Integer) = 1

        'Controles
        dtpFecha.Enabled = True 'Not RutaValidada
        mtbCarga.Enabled = True 'Not RutaValidada
        mtbRegreso.Enabled = True 'Not RutaValidada
        mtbSalida.Enabled = True 'Not RutaValidada
        mtbDescarga.Enabled = True

        mtbAlmuerzoDesde.Enabled = True
        mtbAlmuerzoHasta.Enabled = True

        AcompanantesOnOff()

        cboTransportes.Enabled = True
        cboVehiculos.Enabled = True

        nudDemoras.Enabled = Not RutaValidada

        grbPrestamosExt.Enabled = Not RutaValidada
        grbPrestamosMan.Enabled = Not RutaValidada
        dgvGrilla.ReadOnly = RutaValidada

        'Botones
        btnGrabar.Enabled = ds.HasChanges 'And Not RutaValidada)
        btnCancelar.Enabled = ds.HasChanges 'And Not RutaValidada)
        btnValidar.Enabled = Not (RutaValidada Or ds.HasChanges)
        btnOT.Enabled = Not RutaValidada

    End Sub
    Private Sub Adaptadores()
        'CREACION DE ADAPTADORES PARA: XRUTAC
        daRutac = New OracleDataAdapter("SELECT * FROM xrutac WHERE ruta_0 = :p1", cn)
        daRutac.SelectCommand.Parameters.Add("p1", OracleType.Number)
        daRutac.UpdateCommand = New OracleCommandBuilder(daRutac).GetUpdateCommand

        'CREACION DE ADAPTADORES PARA: XRUTAD
        daRutad = New OracleDataAdapter("SELECT orden_0, ruta_0, direccion_0, localidad_0, nombre_0, tipo_0, vcrnum_0, estado_0, noconform_0, sube_0, equipos_0, equipos_1, equipos_2, equipos_3, prestamos_0, prestamos_1, prestamos_2, prestamos_3, retencion_0, retencion_1, install_0, install_1, tiempo_0, tiempo_1, cliente_0, suc_0, rechazos_0, rechazos_1, cobranza_0, varios_0, prioridad_0, hora_0, kilos_0, credat_0, creusr_0, obs_0 FROM xrutad WHERE ruta_0 = :p1 ORDER BY orden_0", cn)
        daRutad.SelectCommand.Parameters.Add("p1", OracleType.Number)
        daRutad.InsertCommand = New OracleCommandBuilder(daRutad).GetInsertCommand
        daRutad.UpdateCommand = New OracleCommand("UPDATE xrutad SET equipos_1 = :equipos_1, equipos_3 = :equipos_3, prestamos_1 = :prestamos_1, prestamos_3 = :prestamos_3, retencion_0 = :retencion_0, retencion_1 = :retencion_1, install_1 = :install_1, estado_0 = :estado_0, noconform_0 = :noconform_0, sube_0 = :sube_0, tiempo_0 = :tiempo_0, tiempo_1 = :tiempo_1, obs_0 = :obs_0 WHERE ruta_0 = :ruta_0 AND vcrnum_0 = :vcrnum_0", cn)
        With daRutad
            Parametro(.UpdateCommand, "equipos_1", OracleType.Number, DataRowVersion.Current)
            Parametro(.UpdateCommand, "equipos_3", OracleType.Number, DataRowVersion.Current)
            Parametro(.UpdateCommand, "prestamos_1", OracleType.Number, DataRowVersion.Current)
            Parametro(.UpdateCommand, "prestamos_3", OracleType.Number, DataRowVersion.Current)
            Parametro(.UpdateCommand, "retencion_0", OracleType.Number, DataRowVersion.Current)
            Parametro(.UpdateCommand, "retencion_1", OracleType.Number, DataRowVersion.Current)
            Parametro(.UpdateCommand, "install_1", OracleType.Number, DataRowVersion.Current)
            Parametro(.UpdateCommand, "estado_0", OracleType.Number, DataRowVersion.Current)
            Parametro(.UpdateCommand, "noconform_0", OracleType.Number, DataRowVersion.Current)
            Parametro(.UpdateCommand, "sube_0", OracleType.Number, DataRowVersion.Current)
            Parametro(.UpdateCommand, "tiempo_0", OracleType.VarChar, DataRowVersion.Current)
            Parametro(.UpdateCommand, "tiempo_1", OracleType.VarChar, DataRowVersion.Current)
            Parametro(.UpdateCommand, "obs_0", OracleType.VarChar, DataRowVersion.Current)
            Parametro(.UpdateCommand, "ruta_0", OracleType.Number, DataRowVersion.Original)
            Parametro(.UpdateCommand, "vcrnum_0", OracleType.VarChar, DataRowVersion.Original)
        End With

    End Sub
    Private Sub EnviarMailPrestamos(ByVal dr As DataRow)

        Dim txt As String
        Dim eMail As New CorreoElectronico
        Dim itn As New Intervencion(cn)

        'Abro la intervención 
        itn.Abrir(dr("vcrnum_0").ToString)

        Try
            txt = "Se detectó falta de recupero de préstamo en la intervención {ITN}" & vbCrLf
            txt &= "Cliente: {CLIENTE} {NOMBRE}" & vbCrLf
            txt &= "Dirección: {DIRECCION}" & vbCrLf & vbCrLf
            txt &= "Extintores a recuperar: {EXT_A_RECUPERAR} - Recuperados: {EXT_RECUPERADOS}" & vbCrLf & vbCrLf
            txt &= "Mangueras a recuperar: {MAN_A_RECUPERAR} - Recuperadas: {MAN_RECUPERADAS}" & vbCrLf & vbCrLf & vbCrLf
            txt &= "Observaciones: {OBS}"

            txt = txt.Replace("{ITN}", dr("vcrnum_0").ToString)
            txt = txt.Replace("{CLIENTE}", dr("cliente_0").ToString)
            txt = txt.Replace("{NOMBRE}", dr("nombre_0").ToString)
            txt = txt.Replace("{DIRECCION}", dr("direccion_0").ToString & " " & dr("localidad_0").ToString)
            txt = txt.Replace("{EXT_A_RECUPERAR}", dr("prestamos_0").ToString)
            txt = txt.Replace("{EXT_RECUPERADOS}", dr("prestamos_1").ToString)
            txt = txt.Replace("{MAN_A_RECUPERAR}", dr("prestamos_2").ToString)
            txt = txt.Replace("{MAN_RECUPERADAS}", dr("prestamos_3").ToString)

            txt = txt.Replace("{OBS}", dr("obs_0").ToString)

            eMail.Remitente(usr.Mail, usr.Nombre) 'Nuevo remitente del mensaje

            With eMail
                'Agrego mail del vendedor
                With itn.SolicitudAsociada.Vendedor
                    If .Mail.Trim <> "" Then eMail.AgregarDestinatario(.Mail)
                End With
                'Agrego mail del analista
                With itn.SolicitudAsociada.Vendedor.Analista
                    If .TieneDatos Then
                        If .Mail.Trim <> "" Then eMail.AgregarDestinatario(.Mail)
                    End If
                End With

                AgregarMailsCopiaOculta(eMail) 'Agrego destinatarios con copia oculta

                .Asunto = "Recupero de Prestamos"
                .EsHtml = False
                .Cuerpo = txt

            End With

            'Envio mail
            eMail.Enviar()

            eMail.Dispose()

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub
    Private Sub CrearRegistroPrestamo(ByVal dr As DataRow)
        'Procedimiento que crea un registro en la tabla XPRESTAMOS
        'con las cantidades de equipos de prestamos no recuperados
        Dim p As New SeguimientoPrestamos(cn)

        'Creo nuevo registro o abro si ya existe
        If Not p.Abrir(dr("vcrnum_0").ToString) Then p.Nuevo()

        'Asigno los campos al registro
        p.NumeroIntervencion = dr("vcrnum_0").ToString
        p.NumeroRuta = CLng(txtRuta.Text)
        p.FaltanteExtintor = CLng(dr("prestamos_0")) - CLng(dr("prestamos_1"))
        p.FaltanteManguera = CLng(dr("prestamos_2")) - CLng(dr("prestamos_3"))
        p.RetencionExtintor = CLng(dr("retencion_0"))
        p.RetencionManguera = CLng(dr("retencion_1"))
        p.Fecha = dtpFecha.Value

        p.Grabar()

    End Sub
    Private Sub AgregarMailsCopiaOculta(ByVal eMail As CorreoElectronico)
        'Agrego en copia oculta a todos los usuarios que tienen el tilde de Recibe mails de prestamos
        Dim da As New OracleDataAdapter("SELECT DISTINCT addeml_0 FROM autilis WHERE xflgmail1_0 = 2 and enaflg_0 = 2 and usrconnect_0 = 2", cn)
        Dim dt As New DataTable
        Dim dr As DataRow

        da.Fill(dt)

        For Each dr In dt.Rows
            eMail.AgregarDestinatario(dr("addeml_0").ToString, True)
        Next

        dt.Dispose()
        da.Dispose()

    End Sub
    Private Sub ImprimirNuevaIntervencion(ByVal Numero As String)

        If MessageBox.Show("¿Imprime la nueva intervención?", "Nueva intervención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Dim rpt As New ReportDocument

            With rpt
                Try
                    .Load(RPTX3 & "itn1.rpt")
                    .SetDatabaseLogon(DB_USR, DB_PWD)
                    .SetParameterValue("X3DOS", X3DOS)
                    .SetParameterValue("ITN", Numero)
                    .SetParameterValue("X3USR", usr.Codigo)
                    .PrintToPrinter(1, False, 1, 1)

                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                Finally
                    rpt.Close()
                    rpt.Dispose()
                    rpt = Nothing

                End Try

            End With

        End If

    End Sub
    Private Sub Grabar()
        Dim dr As DataRow
        Dim HayError As Boolean = False
        Dim IsValid As Boolean = False

        dr = dtRutac.Rows(0)
        IsValid = (CInt(dr("valid_0")) = 1)

        'Validación de estados de cada fila modificada
        For Each dr In dtRutad.Rows
            If dr.RowState = DataRowState.Modified Then
                If Not IsValid AndAlso Not ValidRow(dr) Then HayError = True
            End If
        Next

        'Se valida que los campos de hora de la cebecera estén completos
        If Not ValidarHora(mtbCarga.Text) OrElse mtbCarga.Text = "0000" Then mtbCarga.Text = "0000"
        If Not ValidarHora(mtbSalida.Text) OrElse mtbSalida.Text = "0000" Then mtbSalida.Text = "0000"
        If Not ValidarHora(mtbRegreso.Text) OrElse mtbRegreso.Text = "0000" Then mtbRegreso.Text = "0000"
        If Not ValidarHora(mtbDescarga.Text) OrElse mtbDescarga.Text = "0000" Then mtbDescarga.Text = "0000"

        If Not ValidarHora(mtbAlmuerzoDesde.Text) OrElse mtbAlmuerzoDesde.Text = "0000" Then mtbAlmuerzoDesde.Text = "0000"
        If Not ValidarHora(mtbAlmuerzoHasta.Text) OrElse mtbAlmuerzoHasta.Text = "0000" Then mtbAlmuerzoHasta.Text = "0000"

        'Validacion encadenamiento de horarios
        If IsValid Then
            If Not ValidarHorarios() Then Exit Sub
        End If

        dr = dtRutac.Rows(0)
        dr.BeginEdit()
        dr("fecha_0") = dtpFecha.Value
        dr("hora_0") = mtbCarga.Text
        dr("hora_1") = mtbSalida.Text
        dr("hora_2") = mtbRegreso.Text
        dr("hora_3") = mtbDescarga.Text
        dr("almuerzo_0") = mtbAlmuerzoDesde.Text
        dr("almuerzo_1") = mtbAlmuerzoHasta.Text
        dr("demora_0") = nudDemoras.Value
        If Not IsValid Then dr("prestamos_0") = nudPrestamosExtC.Value
        If Not IsValid Then dr("prestamos_1") = nudPrestamosExtD.Value
        dr.EndEdit()

        Try
            daRutac.Update(dtRutac)
            daRutad.Update(dtRutad)

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        If HayError Then
            MessageBox.Show("Algunas líneas no se actualizaron. Revisar las filas marcadas", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        ActualizarControles()
        Me.Refresh()

    End Sub
    Private Sub ActualizarFox() 'OJO: No actualiza el fox sino la tabla xsegto que reemplazo al fox
        Dim xsg As New Segto2(cn)
        Dim dr As DataRow
        Dim itn As New Intervencion(cn)

        Try
            'Recorro todos los documentos de la ruta buscando RET y ENT cumplidos
            For Each dr In dtRutad.Rows
                If dr("tipo_0").ToString = "RET" And CInt(dr("estado_0")) = 3 Then

                    'Creo registro de la intervencion en XSEGTO2
                    If xsg.Nuevo(dr("vcrnum_0").ToString) Then
                        xsg.FechaIngresoPlanta = CDate(dtRutac.Rows(0).Item("fecha_0"))
                        xsg.Equipos = CInt(dr("equipos_1")) + CInt(dr("equipos_3"))
                        xsg.Grabar()
                    End If

                    'Pongo la intervencion en sector de service
                    'itn.Abrir(dr("vcrnum_0").ToString)
                    'itn.Sector = "SRV"
                    'itn.Grabar()

                ElseIf dr("tipo_0").ToString = "ENT" And CInt(dr("estado_0")) = 3 Then
                    'Pongo fecha de entrega
                    If xsg.Abrir(dr("vcrnum_0").ToString) Then
                        xsg.FechaEntregado = CDate(dtRutac.Rows(0).Item("fecha_0"))
                        xsg.Grabar()
                    End If

                End If
            Next

        Catch ex As Exception
            MessageBox.Show("Error al actualizar el XSEGTO2" & vbCrLf & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End Try

    End Sub
    Private Sub CargarDatosCabecera()
        Dim dr As DataRow = dtRutac.Rows(0)

        BloqueoModificacion = True

        txtRuta.Text = dr("ruta_0").ToString
        dtpFecha.Value = CType(dr("fecha_0"), Date)

        TablaTransporte(cboTransportes, dtRutac.Rows(0).Item("transporte_0").ToString)
        TablaVehiculos(cboVehiculos, dtRutac.Rows(0).Item("transporte_0").ToString, dtRutac.Rows(0).Item("patente_0").ToString)

        MenuLocal(cn, 2408, cboAcompante1, True)
        SeleccionarAcompanante(cboAcompante1, CInt(dtRutac.Rows(0).Item("acomp_0")))
        MenuLocal(cn, 2408, cboAcompante2, True)
        SeleccionarAcompanante(cboAcompante2, CInt(dtRutac.Rows(0).Item("acomp_1")))
        MenuLocal(cn, 2408, cboAcompante3, True)
        SeleccionarAcompanante(cboAcompante3, CInt(dtRutac.Rows(0).Item("acomp_2")))

        mtbCarga.Text = dr("hora_0", DataRowVersion.Original).ToString
        mtbSalida.Text = dr("hora_1", DataRowVersion.Original).ToString
        mtbRegreso.Text = dr("hora_2", DataRowVersion.Original).ToString
        mtbDescarga.Text = dr("hora_3", DataRowVersion.Original).ToString

        mtbAlmuerzoDesde.Text = dr("almuerzo_0", DataRowVersion.Original).ToString
        mtbAlmuerzoHasta.Text = dr("almuerzo_1", DataRowVersion.Original).ToString

        nudPrestamosExtC.Value = CInt(dr("prestamos_0", DataRowVersion.Original))
        nudPrestamosExtD.Value = CInt(dr("prestamos_1", DataRowVersion.Original))
        nudPrestamosManC.Value = CInt(dr("mangas_0", DataRowVersion.Original))
        nudPrestamosManD.Value = CInt(dr("mangas_1", DataRowVersion.Original))

        nudDemoras.Value = CInt(dr("demora_0", DataRowVersion.Original))

        BloqueoModificacion = False

    End Sub
    Private Sub ActivarCeldas(ByVal dr As DataGridViewRow)
        dr.Cells("colDomicilio").ReadOnly = True
        dr.Cells("colNombre").ReadOnly = True
        dr.Cells("colTipo").ReadOnly = True
        dr.Cells("colDocumento").ReadOnly = True
        dr.Cells("colEquipos").ReadOnly = True
        dr.Cells("colMangas").ReadOnly = True
        dr.Cells("colPrestamosExtT").ReadOnly = True
        dr.Cells("colPrestamosManT").ReadOnly = True
        dr.Cells("colInstalaciones").ReadOnly = True

        Select Case CType(dr.Cells("colEstado").Value, Integer)
            Case 0
                dr.Cells("colNoconform").ReadOnly = True
                dr.Cells("colEquipos2").ReadOnly = True
                dr.Cells("colMangas2").ReadOnly = True
                dr.Cells("colPrestamosExtR").ReadOnly = True
                dr.Cells("colPrestamosManR").ReadOnly = True
                dr.Cells("colRetencion1").ReadOnly = True
                dr.Cells("colRetencion2").ReadOnly = True
                dr.Cells("colInstalaciones2").ReadOnly = True
                dr.Cells("colHoraInicio").ReadOnly = True
                dr.Cells("colHoraFin").ReadOnly = True
                dr.Cells("colSube").ReadOnly = True
                dr.Cells("colObs").ReadOnly = True

            Case 3
                dr.Cells("colNoconform").ReadOnly = True
                dr.Cells("colEquipos2").ReadOnly = False
                dr.Cells("colMangas2").ReadOnly = False
                dr.Cells("colPrestamosExtR").ReadOnly = False
                dr.Cells("colPrestamosManR").ReadOnly = False
                dr.Cells("colRetencion1").ReadOnly = False
                dr.Cells("colRetencion2").ReadOnly = False
                dr.Cells("colInstalaciones2").ReadOnly = False
                dr.Cells("colHoraInicio").ReadOnly = False
                dr.Cells("colHoraFin").ReadOnly = False
                dr.Cells("colSube").ReadOnly = True
                dr.Cells("colObs").ReadOnly = False

            Case 4
                dr.Cells("colNoconform").ReadOnly = False
                dr.Cells("colEquipos2").ReadOnly = False
                dr.Cells("colMangas2").ReadOnly = False
                dr.Cells("colPrestamosExtR").ReadOnly = False
                dr.Cells("colPrestamosManR").ReadOnly = False
                dr.Cells("colRetencion1").ReadOnly = False
                dr.Cells("colRetencion2").ReadOnly = False
                dr.Cells("colInstalaciones2").ReadOnly = False
                dr.Cells("colHoraInicio").ReadOnly = False
                dr.Cells("colHoraFin").ReadOnly = False
                dr.Cells("colSube").ReadOnly = False
                dr.Cells("colObs").ReadOnly = False

        End Select

    End Sub
    Private Sub ActualizarEstadoDocumentos()
        Dim dt As DataTable
        Dim dr As DataRow
        Dim Ok As Boolean = True
        Dim txt As String = ""

        Dim itn As New Intervencion(cn)
        Dim rto As New Remito(cn)

        For Each dr In dtRutad.Rows

            dt = New DataTable

            Select Case dr("tipo_0").ToString
                Case "RET", "ENT", "CTL", "CAN"
                    If itn.Abrir(dr("vcrnum_0").ToString) Then

                        Select Case dr("tipo_0").ToString
                            Case "CAN"
                                Select Case CInt(dr("estado_0"))
                                    Case 0  'Pendiente
                                        itn.Estado = 1
                                        itn.Ruta = dtRutac.Rows(0).Item("ruta_0").ToString

                                    Case 3  'Cumplido

                                        itn.Estado = 2
                                        itn.Ruta = " "

                                    Case 4  'No Conforme

                                        If CInt(dr("sube_0")) = 2 Then
                                            itn.Estado = 7 'Pongo estado A Resolver
                                            itn.Efectuado = True

                                        Else
                                            itn.Estado = 6 'Pongo estado No Conforme

                                        End If

                                        itn.Ruta = " "

                                End Select

                            Case "RET"

                                Select Case CInt(dr("estado_0"))
                                    Case 0  'Pendiente
                                        itn.Estado = 1
                                        itn.Ruta = dtRutac.Rows(0).Item("ruta_0").ToString

                                    Case 3  'Cumplido

                                        itn.Estado = 2
                                        itn.Ruta = " "

                                        If CInt(dr("equipos_1")) < CInt(dr("equipos_0")) Then
                                            txt = "No se retiraron todos los extintores de la siguiente intervención:" & vbCrLf & vbCrLf
                                            txt &= "INTERVENCIÓN: {itn} - CLIENTE: {cod}/{suc} {nombre}" & vbCrLf
                                            txt &= "TEORICO A RETIRAR: {teorico} - RETIRADOS: {retirados}" & vbCrLf & vbCrLf
                                            txt &= "¿Hay que volver a retirar otra tanda?"

                                            txt = txt.Replace("{itn}", dr("vcrnum_0").ToString)
                                            txt = txt.Replace("{cod}", dr("cliente_0").ToString)
                                            txt = txt.Replace("{suc}", dr("suc_0").ToString)
                                            txt = txt.Replace("{nombre}", dr("nombre_0").ToString)
                                            txt = txt.Replace("{teorico}", dr("equipos_0").ToString)
                                            txt = txt.Replace("{retirados}", dr("equipos_1").ToString)

                                            If MessageBox.Show(txt, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                                                itn.Tanda = True
                                            End If
                                        End If

                                    Case 4  'No Conforme

                                        If CInt(dr("sube_0")) = 2 Then
                                            itn.Estado = 7 'Pongo estado A Resolver
                                            itn.Efectuado = True

                                        Else
                                            itn.Estado = 6 'Pongo estado No Conforme

                                        End If

                                        itn.Ruta = " "

                                End Select

                            Case "CTL"

                                Select Case CInt(dr("estado_0"))
                                    Case 0  'Pendiente
                                        itn.Estado = 1
                                        itn.Ruta = dtRutac.Rows(0).Item("ruta_0").ToString

                                    Case 3  'Cumplido
                                        itn.Estado = 5
                                        itn.Ruta = " "
                                        itn.Efectuado = True

                                        'Cierro la solicitud si es abonado y es relevamiento
                                        If itn.ExisteRetira("652011") AndAlso itn.Cliente.EsAbonado = False Then
                                            itn.SolicitudSatisfecha = True
                                            itn.SolicitudAsociada.CerrarSolicitud()
                                        End If

                                        'If itn.ExisteRetira("551003") OrElse itn.ExisteRetira("551015") OrElse itn.ExisteRetira("991003") OrElse itn.ExisteRetira("991015") OrElse itn.ExisteRetira("401114") OrElse itn.ExisteRetira("551003") Then
                                        '    Dim f As New frmDetalleRemitos(itn, CInt(txtRuta.Text))
                                        '    f.ShowDialog(Me)
                                        '    f.Dispose()

                                        '    Dim f2 As New frmCertificadoMantenimiento(itn)
                                        '    f2.ShowDialog(Me)
                                        '    f2.Dispose()

                                        'End If
                                        'Registro del estado del mantenimiento
                                        If itn.ExisteRetira("551003") OrElse itn.ExisteRetira("991003") OrElse itn.ExisteRetira("551015") OrElse itn.ExisteRetira("991015") OrElse itn.ExisteRetira("551068") OrElse itn.ExisteRetira("991068") OrElse itn.ExisteRetira("551017") Then

                                            Dim f2 As New frmCertificadoMantenimiento(itn)
                                            f2.ShowDialog(Me)
                                            f2.Dispose()

                                        End If
                                        If itn.ExisteRetira("401114") Then
                                            Dim f As New frmDetalleRemitos(itn, CInt(txtRuta.Text))
                                            f.ShowDialog(Me)
                                            f.Dispose()

                                        End If

                                    Case 4  'No Conforme
                                        If CInt(dr("sube_0")) = 2 Then
                                            itn.Estado = 7 'Pongo estado A Resolver
                                            itn.Efectuado = True

                                        Else
                                            itn.Estado = 6 'Pongo estado No Conforme

                                        End If

                                        itn.Ruta = " "

                                End Select

                            Case "ENT"

                                Select Case CInt(dr("estado_0"))
                                    Case 0  'Pendiente
                                        itn.Estado = 4
                                        itn.Ruta = dtRutac.Rows(0).Item("ruta_0").ToString

                                    Case 3  'Cumplido
                                        itn.Estado = 5
                                        itn.Transito = False
                                        itn.Ruta = " "


                                    Case 4  'No Conforme

                                        If CInt(dr("sube_0")) = 2 Then
                                            itn.Estado = 7 'Pongo estado A Resolver

                                        Else
                                            itn.Estado = 6 'Pongo estado No Conforme

                                        End If

                                        itn.Ruta = " "
                                        itn.Transito = True

                                End Select

                        End Select

                        itn.Grabar()

                    End If

                Case "NUE", "NCI"

                    If rto.Abrir(dr("vcrnum_0").ToString) Then
                        Select Case CInt(dr("estado_0"))
                            Case 0  'Pendiente
                                rto.Estado = 1  'Estado pendiente
                                rto.Ruta = " "
                            Case 3  'Cumplido
                                rto.Estado = 5  'Estado entregado
                                rto.Ruta = " "

                                If rto.ExisteArticulo("551016") Then
                                    Dim f As New frmDetalleRemitos(rto, CInt(txtRuta.Text))
                                    f.ShowDialog(Me)
                                End If
                                If rto.ExisteArticulo("401103") OrElse rto.ExisteArticulo("401104") OrElse rto.ExisteArticulo("401115") OrElse rto.ExisteArticulo("551016") Then
                                    Dim f2 As New frmCertificadoMantenimiento(rto)
                                    f2.ShowDialog(Me)
                                    f2.Dispose()
                                End If
                            Case 4  'No Conforme
                                If CInt(dr("sube_0")) = 2 Then
                                    rto.Estado = 3 'En transito a resolver por administracion
                                Else
                                    rto.Estado = 4 'En transito por falla logistica
                                End If
                                rto.Ruta = " "
                        End Select
                        rto.Grabar()
                    End If
            End Select
        Next
    End Sub
    Private Sub MoverPrestamos()
        Dim Serie As String = ""
        Dim dr As DataRow
        Dim Diferencia As Integer = 0
        Dim HayDiferencia As Boolean = False

        Dim mac As New Parque(cn)

        For Each dr In dtRutad.Rows

            HayDiferencia = False

            If dr("tipo_0").ToString = "RET" AndAlso CInt(dr("estado_0")) = 3 Then
                '************************************************************
                ' ENTREGA DE PRESTAMOS
                '************************************************************

                'Si la cantidad prestada de EXTINTORES es mayor a cero, se crea el parque de prestamo
                If CInt(dr("prestamos_1")) > 0 Then
                    mac.Nuevo(dr("cliente_0").ToString, dr("suc_0").ToString)

                    With mac
                        .ArticuloCodigo = ARTICULO_PRESTAMO_EXT
                        .Cantidad = CInt(dr("prestamos_1"))
                        .Cilindro = dr("vcrnum_0").ToString
                        .Grabar()
                    End With

                End If

                'Si la cantidad prestada de MANGUERAS es mayor a cero, se crea el parque de prestamo
                If CInt(dr("prestamos_3")) > 0 Then
                    mac.Nuevo(dr("cliente_0").ToString, dr("suc_0").ToString)

                    With mac
                        .ArticuloCodigo = ARTICULO_PRESTAMO_MAN
                        .Cantidad = CInt(dr("prestamos_3"))
                        .Cilindro = dr("vcrnum_0").ToString
                        .Grabar()
                    End With

                End If

            ElseIf dr("tipo_0").ToString = "ENT" AndAlso CInt(dr("estado_0")) = 3 Then
                '************************************************************
                ' RECUPERO DE PRESTAMOS - EXTINTORES
                '************************************************************
                'Calculo la diferencia de prestamos. (Diferencia = A Recuperar - Recuperado)
                Diferencia = CInt(dr("prestamos_0")) - CInt(dr("prestamos_1"))

                'Recupero el registro de parque de prestamo
                Serie = mac.ObtenerParquePrestamo(dr("vcrnum_0").ToString, ARTICULO_PRESTAMO_EXT)

                If Serie = "" Then 'No se encontró el parque de prestamo

                    If Diferencia > 0 Then 'Creo parque por los prestamos no recuperados
                        mac.Nuevo(dr("cliente_0").ToString, dr("suc_0").ToString)

                        With mac
                            .ArticuloCodigo = ARTICULO_PRESTAMO_EXT
                            .Cantidad = Diferencia
                            .Cilindro = dr("vcrnum_0").ToString
                            .Grabar()
                        End With

                    End If

                Else
                    mac.Abrir(Serie)

                    If Diferencia > 0 Then 'Se recupero parte del parque prestamo
                        mac.Cantidad = Diferencia
                        mac.Grabar()

                    Else
                        'Se recuperó todo el prestamo. Borro el parque
                        mac.Borrar()

                    End If

                End If

                If Diferencia > 0 Then HayDiferencia = True

                '************************************************************
                ' RECUPERO DE PRESTAMOS - MANGUERAS
                '************************************************************
                'Calculo la diferencia de prestamos. (Diferencia = A Recuperar - Recuperado)
                Diferencia = CInt(dr("prestamos_2")) - CInt(dr("prestamos_3"))

                'Recupero el registro de parque de prestamo
                Serie = mac.ObtenerParquePrestamo(dr("vcrnum_0").ToString, ARTICULO_PRESTAMO_MAN)

                If Serie = "" Then 'No se encontró el parque de prestamo

                    If Diferencia > 0 Then 'Creo parque por los prestamos no recuperados
                        mac.Nuevo(dr("cliente_0").ToString, dr("suc_0").ToString)

                        With mac
                            .ArticuloCodigo = ARTICULO_PRESTAMO_MAN
                            .Cantidad = Diferencia
                            .Cilindro = dr("vcrnum_0").ToString
                            .Grabar()
                        End With

                    End If

                Else
                    mac.Abrir(Serie)

                    If Diferencia > 0 Then 'Se recupero parte del parque prestamo
                        mac.Cantidad = Diferencia
                        mac.Grabar()

                    Else
                        'Se recuperó todo el prestamo. Borro el parque
                        mac.Borrar()

                    End If

                End If

                If Diferencia > 0 Then HayDiferencia = True

                'Envio mail si se encontro diferencia de prestamos
                If HayDiferencia Then
                    EnviarMailPrestamos(dr)
                    CrearRegistroPrestamo(dr)
                End If

            End If

        Next

    End Sub
    Private Sub ProcesarControles()
        'Funcionalidad para reagendar los vencimientos de los controles, tareas, visitas, etc.
        Dim itn As New Intervencion(cn)
        Dim sol As New Solicitud(cn)
        Dim dr As DataRow
        Dim i As Integer
        Dim Art As String
        Dim itm As New Articulo(cn)

        For Each dr In dtRutad.Rows
            'Salto si no puedo abrir la intervencion
            If Not itn.Abrir(dr("vcrnum_0").ToString) Then Continue For
            'Salgo si la intervencion no está conforme
            If CInt(dr("estado_0")) <> 3 Then Continue For

            If dr("tipo_0").ToString = "RET" Then

                If Not itn.ExisteRetira("553010") Then Continue For

            ElseIf dr("tipo_0").ToString <> "CTL" Then

                Continue For

            End If

            'Recorrer todos los servicios de la intervencion
            For i = 0 To itn.Detalle.Count - 1
                'Convierto codigo de servico a codigo de parque (ej 652001 a 992001)
                Art = itn.Detalle(i).Item(2).ToString
                Art = "99" & Strings.Right(Art, 4)

                'Carga automatica de consumos de control periodicos para clientes NO abonados
                If (Art = "992001" Or Art = "992002") AndAlso itn.Tipo = "A1" AndAlso itn.Cliente.EsAbonado = False Then
                    Dim cantidad As Integer = (CInt(dr("equipos_1")))
                    Dim articulos As String = itn.Detalle(i).Item(2).ToString
                    Dim tar As New Tarifa(cn)
                    Dim Precio As Double

                    'Agrego consumo de Control Periódico
                    itm.Abrir(articulos)
                    itn.AgregarConsumo(itm, cantidad, itn.FechaFin, CDbl(itn.Detalle(i).Item(10)))
                    'Agergo consumo de 705035 ESTAMPILLA CONTROL PERIODICO
                    itm.Abrir("705035")
                    Precio = tar.ObtenerPrecio(itn.Cliente, "705035")
                    itn.AgregarConsumo(itm, cantidad, itn.FechaFin, Precio)

                    itn.Efectuado = True
                    itn.SolicitudSatisfecha = True

                    Try
                        itn.Grabar()

                    Catch ex As Exception
                    End Try

                End If

                'Listado de codigos que no deben ser reagendados.
                If Art = "993011" Or _
                Art = "993001" Or _
                Art = "991003" Or _
                Art = "991016" Or _
                Art = "991021" Or _
                Art = "991034" Or _
                Art = "991035" Or _
                Art = "991036" Or _
                Art = "991037" Or _
                Art = "991056" Or _
                Art = "991058" Or _
                Art = "991060" Or _
                Art = "991063" Or _
                Art = "991070" Or _
                Art = "991073" Or _
                Art = "991075" Then
                    Continue For
                End If

                'Salto si no existe estructura comercial para el articulo
                If Not Parque.ExisteExtructuraComercial(cn, Art) Then Continue For

                'Elimino vencimientos segun el grupo
                Parque.LimpiarParqueGrupo(cn, itn.Cliente.Codigo, itn.SucursalCodigo, Art)

                'Reagendo el vencimiento
                ReagendarControl(itn, Art, CInt(dr("equipos_1")) + CInt(dr("equipos_3")))

                'Si el cliente no tiene parque de recargas, se crea un vencimiento futuro
                If (Art = "992002" Or Art = "992001") AndAlso itn.Cliente.TieneParque(itn.SucursalCodigo) = False Then
                    Dim mac As New Parque(cn)
                    Dim cantidad As Integer = (CInt(dr("equipos_1")))
                    mac.Nuevo(itn.Cliente.Codigo, itn.SucursalCodigo)
                    mac.ArticuloCodigo = "999003"
                    mac.Cantidad = cantidad
                    mac.Procesar(dtpFecha.Value)
                    mac.Observaciones = "Vencimiento a futuro creado automaticamente por validacion de ruta"
                    Try
                        mac.Grabar()
                    Catch ex As Exception
                    End Try

                End If

            Next

        Next

    End Sub
    Private Sub ReagendarControl(ByVal itn As Intervencion, ByVal Articulo As String, ByVal Cantidad As Integer)
        Dim mac As New Parque(cn)
        Dim Series(0) As String
        Dim dt As DataTable

        'Recupero todos los parques del cliente.
        If Not Parque.ObtenerParque(cn, Articulo, itn.Cliente.Codigo, itn.SucursalCodigo, Series) Then
            'Creo un parque nuevo para registrar el vencimiento
            mac.Nuevo(itn.Cliente.Codigo, itn.SucursalCodigo)
            mac.ArticuloCodigo = Articulo
            mac.FabricacionCorto = Date.Today.Year

        Else

            'Borro todos los parques encontrados, menos el ultimo. (No se aplica para 553011)
            If Articulo <> "553011" Then
                For i = Series.GetLowerBound(0) To Series.GetUpperBound(0)
                    mac.Abrir(Series(i))

                    If i < Series.GetUpperBound(0) Then mac.Borrar()

                Next
            End If

        End If

        mac.Cantidad = Cantidad
        mac.Procesar(dtpFecha.Value)
        mac.Observaciones = "Reagendado automáticamente por validación de ruta " & txtRuta.Text
        mac.Grabar()

        Select Case Articulo
            Case "991059"
                CaseArticulos(itn, Cantidad, 3, "991060")
            Case "991055"
                CaseArticulos(itn, Cantidad, 1, "991056")
            Case "991057"
                CaseArticulos(itn, Cantidad, 1, "991058")
            Case "991062"
                CaseArticulos(itn, Cantidad, 1, "991063")
            Case "991002"
                CaseArticulos(itn, Cantidad, 3, "991037")
            Case "991001"
                CaseArticulos(itn, Cantidad, 5, "991036")
            Case "991000"
                CaseArticulos(itn, Cantidad, 11, "991035")
            Case "991065"
                CaseArticulos(itn, Cantidad, 3, "991034")
            Case "991066"
                CaseArticulos(itn, Cantidad, 1, "991021")
            Case "991015"
                CaseArticulos(itn, Cantidad, 1, "991003")
            Case "991069"
                CaseArticulos(itn, Cantidad, 3, "991070")
            Case "993010"
                CaseArticulos(itn, Cantidad, 3, "993011")
            Case "991072"
                CaseArticulos(itn, Cantidad, 1, "991073")
            Case "991019"
                CaseArticulos(itn, Cantidad, 1, "991075")
            Case "991015"
                CaseArticulos(itn, Cantidad, 1, "991003")
            Case "991084"
                CaseArticulos(itn, Cantidad, 1, "991085")
            Case "993010"
                Dim f As Date = dtpFecha.Value

                'Elimino todos los controles 415 para agendar los nuevos
                Parque.EliminarPorCodigo(cn, itn.Cliente.Codigo, itn.SucursalCodigo, "993011")

                For i As Integer = 1 To 3
                    f = f.AddMonths(4)

                    mac.Nuevo(itn.Cliente.Codigo, itn.SucursalCodigo)
                    mac.ArticuloCodigo = "993011"
                    mac.FabricacionCorto = Date.Today.Year
                    mac.Cantidad = Cantidad
                    mac.VtoCarga = f
                    mac.Observaciones = "Creado automáticamente por validación de ruta " & txtRuta.Text & vbCrLf & vbCrLf
                    mac.Observaciones &= "Ctrl. Nro. " & i.ToString
                    mac.Grabar()
                Next

            Case "993015"
                'Elimino todos los controles 415 para agendar los nuevos
                Parque.EliminarPorCodigo(cn, itn.Cliente.Codigo, itn.SucursalCodigo, "993011")

                'Creo un mantenimiento para dentro de 6 meses
                mac.Nuevo(itn.Cliente.Codigo, itn.SucursalCodigo)
                mac.ArticuloCodigo = "993011"
                mac.FabricacionCorto = Date.Today.Year
                mac.Cantidad = Cantidad
                mac.VtoCarga = dtpFecha.Value.AddMonths(6)
                mac.Observaciones = "Creado automáticamente por validación de ruta " & txtRuta.Text & vbCrLf & vbCrLf
                mac.Observaciones &= "Ctrl. Nro. 1"
                mac.Grabar()

            Case "993016"
                Dim f As Date = dtpFecha.Value

                'Elimino todos los controles 415 para agendar los nuevos
                Parque.EliminarPorCodigo(cn, itn.Cliente.Codigo, itn.SucursalCodigo, "993011")

                'Creo dos controles cuatrimestrales
                For i As Integer = 1 To 2
                    f = f.AddMonths(4)

                    mac.Nuevo(itn.Cliente.Codigo, itn.SucursalCodigo)
                    mac.ArticuloCodigo = "993011"
                    mac.FabricacionCorto = Date.Today.Year
                    mac.Cantidad = Cantidad
                    mac.VtoCarga = f
                    mac.Observaciones = "Creado automáticamente por validación de ruta " & txtRuta.Text & vbCrLf & vbCrLf
                    mac.Observaciones &= "Ctrl. Nro. " & i.ToString
                    mac.Grabar()
                Next

            Case "993017" 'Creo 11 mantenimientos
                Dim f As Date = dtpFecha.Value

                'Elimino todos los controles 415 para agendar los nuevos
                Parque.EliminarPorCodigo(cn, itn.Cliente.Codigo, itn.SucursalCodigo, "993011")

                'Creo dos controles cuatrimestrales
                For i As Integer = 1 To 11
                    f = f.AddMonths(1)

                    mac.Nuevo(itn.Cliente.Codigo, itn.SucursalCodigo)
                    mac.ArticuloCodigo = "993011"
                    mac.FabricacionCorto = Date.Today.Year
                    mac.Cantidad = Cantidad
                    mac.VtoCarga = f
                    mac.Observaciones = "Creado automáticamente por validación de ruta " & txtRuta.Text & vbCrLf & vbCrLf
                    mac.Observaciones &= "Ctrl. Nro. " & i.ToString
                    mac.Grabar()
                Next

            Case "992001", "992002"

                If Not itn.Cliente.EsAbonado Then

                    Dim datini As Date = dtpFecha.Value
                    Dim datfin As Date = mac.VtoCarga

                    datfin = datfin.AddMonths(2)

                    datini = New Date(datini.Year, datini.Month, 1)
                    datfin = New Date(datfin.Year, datfin.Month, 1)

                    'Consulto los vencimientos dentro de un rango de fechas
                    dt = Parque.ObtenerVtos(cn, datini, datfin, itn.Cliente.Codigo, itn.SucursalCodigo)
                    If dt.Rows.Count > 0 Then
                        datini = CDate(dt.Rows(0).Item(0)).Date
                        mac.Procesar(datini)
                        mac.Grabar()
                    End If
                    dt.Dispose()

                End If

        End Select

    End Sub
    Private Sub CaseArticulos(ByVal itn As Intervencion, ByVal cantidad As Integer, ByVal qty As Integer, ByVal articulo As String)
        Dim f As Date = dtpFecha.Value
        Dim mac As New Parque(cn)
        'Elimino todos los controles 415 para agendar los nuevos
        Parque.EliminarPorCodigo(cn, itn.Cliente.Codigo, itn.SucursalCodigo, "993011")

        For i As Integer = 1 To qty
            mac.Nuevo(itn.Cliente.Codigo, itn.SucursalCodigo)
            mac.ArticuloCodigo = articulo
            mac.FabricacionCorto = Date.Today.Year
            mac.Cantidad = cantidad
            mac.Procesar(f)
            mac.Observaciones = "Creado automáticamente por validación de ruta " & txtRuta.Text & vbCrLf & vbCrLf
            mac.Observaciones &= "Ctrl. Nro. " & i.ToString
            mac.Grabar()

            f = mac.VtoCarga
        Next

    End Sub
    Private Function ValidarHorarios() As Boolean
        Dim dr As DataGridViewRow
        Dim Ok As Boolean = True
        Dim HoraPrev As String = mtbSalida.Text
        Dim ValidarHora As Boolean = False
        Dim Sql As String = ""
        Dim dtMotivos As DataTable = TablaMotivos(cn)
        Dim dv As DataView

        'Ordeno la grilla por la columna de horarios
        dgvGrilla.Sort(dgvGrilla.Columns("colHoraInicio"), System.ComponentModel.ListSortDirection.Ascending)

        'Recorro todas las filas
        For i As Integer = 0 To dgvGrilla.Rows.Count - 1
            dr = dgvGrilla.Rows(i)
            dr.ErrorText = ""

            Select Case CType(dr.Cells("colEstado").Value, Integer)
                Case 3  'Documento cumplido se debe validar horario
                    ValidarHora = True

                Case 4  'Documento con rebote.
                    If CInt(dr.Cells("colNoconform").Value) > 0 Then
                        'Consulto si el motivo de NO CONFORMIDAD requiere registro de horario
                        Sql = String.Format("code_0 = {0}", dr.Cells("colnoconform").Value.ToString)
                        dv = New DataView(dtMotivos, Sql, "code_0", DataViewRowState.CurrentRows)

                        If dv.Count = 1 Then
                            ValidarHora = CBool(dv(0).Item("n1_0"))
                        Else
                            ValidarHora = False
                        End If

                    Else
                        dr.Cells("colNoConform").ErrorText = "Debe seleccionar un motivo de rebote"

                        ValidarHora = False
                        Ok = False

                    End If

                Case Else
                    ValidarHora = False

            End Select

            If ValidarHora Then

                If dr.Cells("colHoraInicio").Value.ToString <> "0000" AndAlso dr.Cells("colHoraFin").Value.ToString <> "0000" Then

                    If dr.Cells("colHoraFin").Value.ToString <= dr.Cells("colHoraInicio").Value.ToString Then
                        'El horario se fin es menor a inicio
                        dr.ErrorText = "El horario se salida debe ser mayor al de llegada"
                        Ok = False

                    ElseIf dr.Cells("colHoraInicio").Value.ToString < HoraPrev Then
                        Ok = False
                        dr.ErrorText = "El horario de llegada es menor al de salida del domicilio anterior"

                    End If

                    HoraPrev = dr.Cells("colHoraFin").Value.ToString

                Else
                    dr.ErrorText = "Falta completar horario"
                    Ok = False

                End If

            End If

        Next

        'Aca valido que la hora de llegada sea mayor a la salida del ultimo domicilio
        If Ok Then
            If mtbRegreso.Text < HoraPrev Then
                MessageBox.Show("El horario de regreso debe ser mayor a la partida del último domicilio", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Ok = False
            End If
        End If

        'Validación de horario de almuerzo
        If Ok Then
            If mtbAlmuerzoDesde.Text > mtbAlmuerzoHasta.Text Then
                Ok = False
                MessageBox.Show("Error en el horario de almuerzo", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        End If

        'Si todo está ok restablezco el orden de la grilla
        If Ok Then
            dgvGrilla.Sort(dgvGrilla.Columns("colOrden"), System.ComponentModel.ListSortDirection.Ascending)

        Else
            MessageBox.Show("Se encontraron errores en los horarios de visita", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

        dtMotivos.Dispose()

        Return Ok

    End Function
    Private Function ValidarRetenciones() As Boolean
        'Alerta al usuario cuando se encuentra faltante de prestamo y no se retuvieron equipos al cliente
        Dim dr As DataRow
        Dim r1, r2 As Long 'Retenciones
        Dim f1, f2 As Long 'Faltantes de prestamos
        Dim txt As String

        For Each dr In dtRutad.Rows
            If dr("tipo_0").ToString = "ENT" AndAlso CInt(dr("estado_0")) = 3 Then
                f1 = CLng(dr("prestamos_0")) - CLng(dr("prestamos_1")) 'Faltante extintor
                f2 = CLng(dr("prestamos_2")) - CLng(dr("prestamos_3")) 'Faltante manguera

                r1 = CLng(dr("retencion_0")) 'retencion extintor
                r2 = CLng(dr("retencion_1")) 'retencion manguera

                If (f1 > 0 AndAlso r1 < f1) OrElse (f2 > 0 AndAlso r2 < f2) Then
                    txt = "Intervención: {ITN}" & vbCrLf & vbCrLf
                    txt &= "La cantidad de equipos retenidos al clientes es menor al faltante de préstamo" & vbCrLf & vbCrLf
                    txt &= "¿Confirma que esto es correcto?"

                    txt = txt.Replace("{ITN}", dr("vcrnum_0").ToString)

                    If MessageBox.Show(txt, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                        Return False
                    End If

                End If

            End If

        Next

        Return True

    End Function
    Private Function BalancePrestamos() As Boolean
        Dim dr As DataRow

        Dim ExtintoresInicial As Integer = CInt(nudPrestamosExtC.Value)
        Dim ExtintoresFinal As Integer = CInt(nudPrestamosExtD.Value)

        Dim ManguerasInicial As Integer = CInt(nudPrestamosManC.Value)
        Dim ManguerasFinal As Integer = CInt(nudPrestamosManD.Value)

        Dim ExtintoresEntregados As Integer = 0
        Dim ExtintoresRecuperados As Integer = 0
        Dim ManguerasEntregadas As Integer = 0
        Dim ManguerasRecuperadas As Integer = 0

        Dim txt As String

        Dim ExtintoresSaldo As Integer
        Dim ManguerasSaldo As Integer

        For Each dr In dtRutad.Rows
            Select Case dr("tipo_0").ToString
                Case "ENT"
                    ExtintoresRecuperados += CInt(dr("prestamos_1", DataRowVersion.Current))
                    ManguerasRecuperadas += CInt(dr("prestamos_3", DataRowVersion.Current))

                Case "RET"
                    ExtintoresEntregados += CInt(dr("prestamos_1", DataRowVersion.Current))
                    ManguerasEntregadas += CInt(dr("prestamos_3", DataRowVersion.Current))

            End Select
        Next

        ExtintoresSaldo = ExtintoresInicial + ExtintoresRecuperados - ExtintoresEntregados
        ManguerasSaldo = ManguerasInicial + ManguerasRecuperadas - ManguerasEntregadas

        If ExtintoresSaldo = ExtintoresFinal AndAlso ManguerasSaldo = ManguerasFinal Then
            Return True

        Else
            txt = "Error en el balance de préstamos" & vbCrLf & vbCrLf
            txt &= "Movimiento de préstamos según declaración en hora de ruta:" & vbCrLf & vbCrLf
            txt &= "Cargado al inicio del viaje: {0} extintor(es) y {1} manguera(s)" & vbCrLf & vbCrLf
            txt &= "Recuperado: {2} extintor(es) y {3} manguera(s)" & vbCrLf
            txt &= "Entregado : {4} extintor(es) y {5} manguera(s)" & vbCrLf & vbCrLf
            txt &= "Descargado al final del viaje: {6} extintor(es) y {7} manguera(s)" & vbCrLf & vbCrLf
            txt &= "El saldo final debería ser: {8} extintor(es) y {9} manguera(s)"

            txt = String.Format(txt, ExtintoresInicial, ManguerasInicial, ExtintoresRecuperados, ManguerasRecuperadas, ExtintoresEntregados, ManguerasEntregadas, ExtintoresFinal, ManguerasFinal, ExtintoresSaldo, ManguerasSaldo)

            MessageBox.Show(txt, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False

        End If

    End Function
    Private Function ObservacionesObligatorias() As Boolean
        'Funcion para controlar que las lineas de intervenciones de entregas donde hay diferencia en el recupero
        'de prestamos, el campo observaciones no este vacío.
        Dim dr As DataRow
        Dim i As Integer
        Dim txt As String

        For Each dr In dtRutad.Rows
            If dr("tipo_0").ToString = "ENT" AndAlso CInt(dr("estado_0")) = 3 Then
                i = CInt(dr("prestamos_0")) 'Prestamos teoricos a recuperar
                i -= CInt(dr("prestamos_1")) 'Descuento prestamos recuperados

                'Si hay diferencia de recupero, 
                If i > 0 AndAlso dr("obs_0").ToString.Trim = "" Then
                    txt = "Hay diferencia de recupero de préstamos en la intervencion {itn}" & vbCrLf & vbCrLf
                    txt &= "Se debe completar el campo de observaciones"
                    txt = txt.Replace("{itn}", dr("vcrnum_0").ToString)

                    MessageBox.Show(txt, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return False
                End If

            End If
        Next

        Return True

    End Function
    Private Function ValidRow(ByRef dr As DataRow) As Boolean
        Dim Ok As Boolean = True
        Dim ddr As OracleDataReader
        Dim cm As New OracleCommand("SELECT * FROM xrutad WHERE ruta_0 <> :ruta_0 AND vcrnum_0 = :vcrnum_0 AND estado_0 < :estado_0", cn)
        cm.Parameters.Add("ruta_0", OracleType.Number).Value = dr("ruta_0")
        cm.Parameters.Add("vcrnum_0", OracleType.VarChar).Value = dr("vcrnum_0")
        cm.Parameters.Add("estado_0", OracleType.Number)

        Try
            'Se modificó el estado del documento
            If CInt(dr("estado_0", DataRowVersion.Current)) <> CInt(dr("estado_0", DataRowVersion.Original)) Then

                Select Case CInt(dr("estado_0", DataRowVersion.Current))
                    Case 0  'El documento se pasó a PENDIENTE
                        'busco si el documento esta pendiente en otra ruta
                        cm.Parameters("estado_0").Value = 3
                        ddr = cm.ExecuteReader

                        If ddr.Read Then
                            dr.RowError = "No se puede cambiar a estado Pendiente. El documento figura pendiente en ruta Nro. " & ddr("ruta_0").ToString
                            Ok = False
                        End If
                        ddr.Close()
                        ddr.Dispose()

                    Case 3  'El documento se pasó a CUMPLIDO. No puede existir el mismo documento como pendiente en otra ruta
                        'busco si el documento esta pendiente en otra ruta
                        cm.Parameters("estado_0").Value = 4
                        ddr = cm.ExecuteReader

                        If ddr.Read Then

                            If CInt(ddr("estado_0")) = 3 Then
                                'Diferencio cumplido de entrega y retiro
                                If ddr("tipo_0").ToString = dr("estado_0").ToString Then
                                    dr.RejectChanges()
                                    dr.RowError = "No se puede cambiar a estado Cumplido. El documento fué cumplido en ruta Nro. " & ddr("ruta_0").ToString
                                    Ok = False
                                End If

                            Else
                                dr.RejectChanges()
                                dr.RowError = "No se puede cambiar a estado Cumplido. El documento está pendiente en ruta Nro. " & ddr("ruta_0").ToString
                                Ok = False

                            End If

                        End If
                        ddr.Close()
                        ddr.Dispose()


                End Select

            End If

            If CInt(dr("estado_0")) = 4 AndAlso CInt(dr("noconform_0")) = 0 Then
                dr.RejectChanges()
                dr.RowError = "Falta seleccionar motivo de rebote"
                Ok = False
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Ok = False

        End Try

        cm.Dispose()

        If Ok Then dr.RowError = ""
        Return Ok

    End Function
    Private Function OrdenSiguiente() As Integer
        Dim dr As DataRow
        Dim i As Integer = 0

        For Each dr In dtRutad.Rows
            If CInt(dr("orden_0")) > i Then i = CInt(dr("orden_0"))
        Next

        Return i

    End Function
    Private Function CantidadMovimientos() As Integer
        Dim c As Integer = 0

        For Each dr As DataRow In dtRutad.Rows
            If dr.RowState = DataRowState.Deleted Then Continue For

            Select Case dr("tipo_0").ToString
                Case "RET", "ENT", "NUE", "NCI"
                    c += CInt(dr("equipos_1"))
                    c += CInt(dr("equipos_3"))
                    c += CInt(dr("prestamos_1"))
                    c += CInt(dr("prestamos_3"))
            End Select
        Next

        Return c

    End Function
    Private Function CantidadAcompanantes() As Integer
        Dim c As Integer = 0

        If cboAcompante1.SelectedValue IsNot Nothing AndAlso CInt(cboAcompante1.SelectedValue) > 1 Then c += 1
        If cboAcompante2.SelectedValue IsNot Nothing AndAlso CInt(cboAcompante2.SelectedValue) > 1 Then c += 1
        If cboAcompante3.SelectedValue IsNot Nothing AndAlso CInt(cboAcompante3.SelectedValue) > 1 Then c += 1

        Return c

    End Function
    Private Sub SeleccionarAcompanante(ByVal cbo As ComboBox, Optional ByVal Numero As Integer = 0)
        Dim dt As DataTable
        Dim dr As DataRow
        Dim da As New OracleDataAdapter("SELECT lanmes_0 FROM aplstd WHERE lanchp_0 = 2408 AND lan_0 = 'SPA' AND lannum_0 = 0", cn)
        Dim txt As String
        Dim i As Integer

        dt = New DataTable
        da.Fill(dt)
        dr = dt.Rows(0)
        txt = dr(0).ToString

        cbo.SelectedValue = Numero

        dt = CType(cbo.DataSource, DataTable)

        For i = dt.Rows.Count - 1 To 1 Step -1
            dr = dt.Rows(i) 'Obtengo la fila de la tabla de acompañantes

            'Si el valor evaluado está seleccionado en el combo, paso al siguiente For
            If CInt(dr(0)) = CInt(cbo.SelectedValue) Then Continue For

            'Elimino el registro si el acompañante no esta activo
            If txt.Substring(i - 1, 1).ToUpper <> "S" Then dr.Delete()

        Next

    End Sub
    Private Sub TablaTransporte(ByVal cbo As ComboBox, Optional ByVal Transporte As String = "")
        Dim da As New OracleDataAdapter("SELECT bptnum_0, bptnam_0 FROM bpcarrier WHERE xbptsta_0 = 2 ORDER BY bptnam_0", cn)
        Dim dt As DataTable
        Dim dr As DataRow
        Dim i As Integer
        Dim flg As Boolean = False 'Flg para indicar que se encontro el registro

        If cbo.DataSource Is Nothing Then
            dt = New DataTable
            da.FillSchema(dt, SchemaType.Source)

            cbo.DataSource = dt
            cbo.DisplayMember = "bptnam_0"
            cbo.ValueMember = "bptnum_0"

        Else
            dt = CType(cbo.DataSource, DataTable)

        End If

        dt.Clear()
        da.Fill(dt) 'Lleno la tabla con los transportes activos

        If Transporte <> "" Then 'Busco transporte en la tabla para seleccionarlo
            For Each dr In dt.Rows
                If dr("bptnum_0").ToString = Transporte Then
                    cbo.SelectedValue = Transporte
                    flg = True
                    Exit For
                End If
            Next

            If Not flg Then
                'No encontre el transporte lo busco entre los inactivos
                da = New OracleDataAdapter("SELECT bptnum_0, bptnam_0 FROM bpcarrier WHERE bptnum_0 = :p1", cn)
                da.SelectCommand.Parameters.Add("p1", OracleType.VarChar).Value = Transporte

                i = da.Fill(dt)
                If i = 1 Then cbo.SelectedValue = Transporte
            End If

        Else
            cbo.SelectedItem = Nothing

        End If

        da.Dispose()

    End Sub
    Private Sub TablaVehiculos(ByVal cbo As ComboBox, ByVal Transporte As String, Optional ByVal Patente As String = "")
        Dim da As OracleDataAdapter
        Dim dt As DataTable
        Dim dr As DataRow
        Dim i As Integer
        Dim flg As Boolean = False 'Flg para indicar que se encontro el registro

        da = New OracleDataAdapter("SELECT bptnum_0, patnum_0, maxwei_0, chofer_0 FROM zunitrans WHERE xpatsta_0 = 2 AND bptnum_0 = :p1 ORDER BY chofer_0", cn)
        da.SelectCommand.Parameters.Add("p1", OracleType.VarChar).Value = Transporte

        If cbo.DataSource Is Nothing Then
            dt = New DataTable
            cbo.DataSource = dt

            da.FillSchema(dt, SchemaType.Source)
            cboVehiculos.DisplayMember = "chofer_0"
            cboVehiculos.ValueMember = "patnum_0"

        Else
            dt = CType(cbo.DataSource, DataTable)

        End If

        dt.Clear()
        da.Fill(dt) 'Lleno la tabla con las camionetas activas

        If Patente <> "" Then 'Busco camioneta en la tabla para seleccionarla
            For Each dr In dt.Rows
                If dr("patnum_0").ToString = Patente Then
                    cbo.SelectedValue = Patente
                    flg = True
                    Exit For
                End If
            Next

            If Not flg Then
                'No encontre la camioneta la busco entre las inactivas
                da = New OracleDataAdapter("SELECT bptnum_0, patnum_0, maxwei_0, chofer_0 FROM zunitrans WHERE bptnum_0 = :p1 AND patnum_0 = :p2", cn)
                da.SelectCommand.Parameters.Add("p1", OracleType.VarChar).Value = Transporte
                da.SelectCommand.Parameters.Add("p2", OracleType.VarChar).Value = Patente

                i = da.Fill(dt)
                If i = 1 Then cbo.SelectedValue = Patente

            End If

        End If
        da.Dispose()

    End Sub
    
    'EVENTOS DE MENU CONTEXTUAL
    Private Sub mnuContextMenu_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mnuContextMenu.Opening
        If dgvGrilla.CurrentRow Is Nothing Then
            e.Cancel = True

        Else
            Select Case dgvGrilla.CurrentRow.Cells("colTipo").Value.ToString
                Case "RET", "ENT", "CTL'"
                    mnuVerDocumento.Enabled = True
                    mnuHistorial.Enabled = True

                Case "NUE", "NCI", "INS"
                    mnuVerDocumento.Enabled = True
                    mnuHistorial.Enabled = True

                Case Else
                    mnuVerDocumento.Enabled = False
                    mnuHistorial.Enabled = False

            End Select

        End If

    End Sub
    Private Sub mnuVerDocumento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuVerDocumento.Click
        Dim rpt As New ReportDocument
        Dim f As frmCrystal
        Dim t As String = dgvGrilla.CurrentRow.Cells("colDocumento").Value.ToString

        Try

            If t.StartsWith("DNY") Or t.StartsWith("MON") Then
                rpt.Load(RPTX3 & "BONLIV.rpt")
                rpt.SetParameterValue("livraisondeb", t)
                rpt.SetParameterValue("livraisonfin", t)

            Else
                rpt.Load(RPTX3 & "itn1.rpt")
                rpt.SetParameterValue("ITN", t)
                rpt.SetParameterValue("X3USR", usr.Codigo)

            End If

            f = New frmCrystal(rpt)
            f.MdiParent = Me.ParentForm
            f.Show()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            rpt.Close()
            rpt.Dispose() : rpt = Nothing

        End Try

    End Sub
    Private Sub mnuVerRutas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuHistorial.Click
        Dim rpt As New ReportDocument
        Dim t As String = dgvGrilla.CurrentRow.Cells("colDocumento").Value.ToString
        Dim f As frmCrystal

        Try
            If t.StartsWith("DNY") Or t.StartsWith("MON") Then
                rpt.Load(RPTX3 & "xsegto_rto.rpt")
                rpt.SetParameterValue("rto", dgvGrilla.CurrentRow.Cells("colDocumento").Value.ToString)

            Else
                rpt.Load(RPTX3 & "xsegto_itn.rpt")
                rpt.SetParameterValue("itn", dgvGrilla.CurrentRow.Cells("colDocumento").Value.ToString)

            End If

            f = New frmCrystal(rpt)
            f.MdiParent = Me.ParentForm
            f.Show()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            rpt.Dispose() : rpt = Nothing

        End Try

    End Sub

    Private Function ValidarCanjes() As Boolean
        'Bloqueo cuando la cantidad de canje recuperado no coincide
        'con las intervenciones de canje cumplidas
        Dim dr As DataRow
        Dim i As Long = 0 'Retenciones
        Dim j As Long = 0

        j = CLng(nudCanjes.Value)

        For Each dr In dtRutad.Rows
            If dr("tipo_0").ToString = "CAN" AndAlso CInt(dr("estado_0")) = 3 Then
                i += CLng(dr("equipos_1"))
            End If
        Next

        Return j >= i

    End Function
    Private Function ValidarCanjesObservaciones() As Boolean
        Dim txt As String

        For Each dr As DataRow In dtRutad.Rows
            If dr("tipo_0").ToString = "CAN" AndAlso CInt(dr("estado_0")) = 3 Then
                If dr("obs_0").ToString = "" Then
                    txt = "Intervención {itn}" & vbCrLf & vbCrLf
                    txt = "Poner en observaciones el número de OT con la que se recuperaron los canjes"
                    MessageBox.Show(txt, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return False
                End If
            End If
        Next

        Return True
    End Function

End Class