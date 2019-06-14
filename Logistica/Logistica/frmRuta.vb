Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.OracleClient

Class frmRuta
    Private ds As New DataSet

    Private Const MOSTRADOR As String = "TR029"
    Private itn As New Intervencion(cn)
    Private rto As New Remito(cn)

    Private daRutac As OracleDataAdapter
    Private WithEvents daRutad As OracleDataAdapter

    Private WithEvents dtRutac As New DataTable("Rutac")
    Private WithEvents dtRutad As New DataTable("Rutad")
    Private dtRutax As New DataTable("Rutax")   'Usada para cambios de rutas

    Private WithEvents Doc As New Documento(cn)
    Private Modo As ModoRuta
    Private BloqueoModificacion As Boolean = False

    'CONSTRUCTORES
    Public Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Dim HayError As Boolean = False

        Adaptadores()

        Try
            daRutac.FillSchema(dtRutac, SchemaType.Mapped)
            daRutad.FillSchema(dtRutad, SchemaType.Mapped)
            daRutad.FillSchema(dtRutax, SchemaType.Mapped)

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            HayError = True

        End Try

        If HayError Then Me.Close()

        With ds
            .Tables.Add(dtRutac)
            .Tables.Add(dtRutad)
            .Relations.Add("relruta", dtRutac.Columns("ruta_0"), dtRutad.Columns("ruta_0"))
        End With

        With ds.Relations("relruta").ChildKeyConstraint
            .DeleteRule = Rule.Cascade
            .UpdateRule = Rule.Cascade
            .AcceptRejectRule = AcceptRejectRule.None
        End With

        dtpFecha.Value = Date.Today.AddDays(CDbl(IIf(Date.Today.DayOfWeek = DayOfWeek.Friday, 3, 1)))

        Modo = ModoRuta.Cerrada

        Me.Text = Me.Tag.ToString

    End Sub

    'SUB
    Private Sub ActualizarControles()

        'Deshabilito todos los controles
        Select Case Modo
            Case ModoRuta.Nueva, ModoRuta.Edicion
                Grilla.AllowUserToDeleteRows = False
                Grilla.ReadOnly = False

                dtpFecha.Enabled = True
                txtDescripcion.Enabled = True
                txtVarios.Enabled = True
                lstTransportes.Enabled = True
                lstVehiculos.Enabled = True

                cboAcompante1.Enabled = True
                cboAcompante2.Enabled = True
                cboAcompante3.Enabled = True

                nudPrestamosExt.Enabled = True
                nudPrestamosMan.Enabled = True
                txtBuscar.Enabled = True

                tooTarea.Enabled = True
                toolImprimir.Enabled = Not ds.HasChanges
                toolPreparacion.Enabled = Not ds.HasChanges
                toolPreparacion2.Enabled = Not ds.HasChanges
                ToolGenEtiqu.Enabled = Not ds.HasChanges

            Case ModoRuta.Vista, ModoRuta.Cerrada
                Grilla.AllowUserToDeleteRows = False
                Grilla.ReadOnly = True

                dtpFecha.Enabled = False
                txtDescripcion.Enabled = False
                txtVarios.Enabled = False
                lstTransportes.Enabled = False
                lstVehiculos.Enabled = False
                cboAcompante1.Enabled = False
                cboAcompante2.Enabled = False
                cboAcompante3.Enabled = False

                nudPrestamosExt.Enabled = False
                nudPrestamosMan.Enabled = False
                txtBuscar.Enabled = False

                tooTarea.Enabled = False
                toolImprimir.Enabled = (Modo = ModoRuta.Vista)
                toolPreparacion.Enabled = (Modo = ModoRuta.Vista)
                toolPreparacion2.Enabled = (Modo = ModoRuta.Vista)
                ToolGenEtiqu.Enabled = (Modo = ModoRuta.Vista)

        End Select

        AcompanantesOnOff()

        'Parche para la propiedad ReadOnly de la grilla que permite modificar aunque este en True
        For i = 0 To Grilla.Rows.Count - 1
            Grilla.Rows(i).Cells("colOrden").ReadOnly = False
            Grilla.Rows(i).Cells("colsuc").ReadOnly = True
            Grilla.Rows(i).Cells("colDomicilio").ReadOnly = True
            Grilla.Rows(i).Cells("colLocalidad").ReadOnly = True
            Grilla.Rows(i).Cells("colCliente").ReadOnly = True
            Grilla.Rows(i).Cells("colNombre").ReadOnly = True
            Grilla.Rows(i).Cells("colTipo").ReadOnly = True
            Grilla.Rows(i).Cells("colDocumento").ReadOnly = True
            Grilla.Rows(i).Cells("colEquipos").ReadOnly = True
            Grilla.Rows(i).Cells("colMangas").ReadOnly = True
            Grilla.Rows(i).Cells("colPrestamoExt").ReadOnly = True
            Grilla.Rows(i).Cells("colPrestamoMan").ReadOnly = True
            Grilla.Rows(i).Cells("colInstalaciones").ReadOnly = True
            Grilla.Rows(i).Cells("colRechazoExt").ReadOnly = True
            Grilla.Rows(i).Cells("colRechazoMan").ReadOnly = True
            Grilla.Rows(i).Cells("colCobranza").ReadOnly = True
            Grilla.Rows(i).Cells("colVarios").ReadOnly = True
            Grilla.Rows(i).Cells("colPrioridad").ReadOnly = False
            Grilla.Rows(i).Cells("colHorario").ReadOnly = True
            Grilla.Rows(i).Cells("colPeso").ReadOnly = True
        Next

        toolGrabar.Enabled = ds.HasChanges
        toolDeshacer.Enabled = ds.HasChanges
        tooBorrar.Enabled = Not ds.HasChanges And dtRutad.Rows.Count = 0 And (Modo = ModoRuta.Edicion Or Modo = ModoRuta.Vista)

    End Sub
    Private Sub Adaptadores()
        Dim Sql As String

        'DATAADDAPTERS tabla cabecera de rutas
        daRutac = New OracleDataAdapter("SELECT * FROM xrutac WHERE ruta_0 = :p1", cn)
        daRutac.SelectCommand.Parameters.Add("p1", OracleType.Number)
        daRutac.InsertCommand = New OracleCommandBuilder(daRutac).GetInsertCommand
        daRutac.UpdateCommand = New OracleCommandBuilder(daRutac).GetUpdateCommand

        'DATAADDAPTERS tabla detalle de rutas
        Sql = "SELECT ruta_0, orden_0, suc_0, direccion_0, localidad_0, cliente_0, nombre_0, tipo_0, vcrnum_0, equipos_0, equipos_2, prestamos_0, prestamos_2, retencion_0, retencion_1, install_0, rechazos_0, rechazos_1, cobranza_0, varios_0, prioridad_0, hora_0, kilos_0, estado_0, noconform_0 "
        Sql &= "FROM xrutad "
        Sql &= "WHERE ruta_0 = :p1 "
        Sql &= "ORDER BY orden_0"

        daRutad = New OracleDataAdapter(Sql, cn)
        daRutad.SelectCommand.Parameters.Add("p1", OracleType.Number)

        Sql = "INSERT INTO xrutad "
        Sql &= "VALUES (:ruta_0,:tipo_0,:vcrnum_0,:suc_0,:direccion_0,:localidad_0,:cliente_0,:nombre_0,:equipos_0,:equipos_1,:equipos_2,:equipos_3,:prestamos_0,:prestamos_1,:prestamos_2,:prestamos_3,:retencion_0,:retencion_1,:install_0,:install_1,:rechazos_0,:rechazos_1,:cobranza_0,:varios_0,:prioridad_0,:hora_0,:kilos_0,:estado_0,:noconform_0,:sube_0,:orden_0,:tiempo_0,:tiempo_1,:credat_0,:creusr_0,:obs_0)"
        daRutad.InsertCommand = New OracleCommand(Sql, cn)

        Sql = "UPDATE xrutad SET orden_0 = :orden_0, prioridad_0 = :prioridad_0, estado_0 = :estado_0, noconform_0 = :noconform_0 WHERE ruta_0 = :ruta_0 AND vcrnum_0 = :vcrnum_0"
        daRutad.UpdateCommand = New OracleCommand(Sql, cn)

        Sql = "DELETE FROM xrutad WHERE ruta_0 = :ruta_0 AND vcrnum_0 = :vcrnum_0"
        daRutad.DeleteCommand = New OracleCommand(Sql, cn)

        With daRutad
            Parametro(.InsertCommand, "ruta_0", OracleType.Number, DataRowVersion.Current)
            Parametro(.InsertCommand, "tipo_0", OracleType.VarChar, DataRowVersion.Current)
            Parametro(.InsertCommand, "vcrnum_0", OracleType.VarChar, DataRowVersion.Current)
            Parametro(.InsertCommand, "suc_0", OracleType.VarChar, DataRowVersion.Current)
            Parametro(.InsertCommand, "direccion_0", OracleType.VarChar, DataRowVersion.Current)
            Parametro(.InsertCommand, "localidad_0", OracleType.VarChar, DataRowVersion.Current)
            Parametro(.InsertCommand, "cliente_0", OracleType.VarChar, DataRowVersion.Current)
            Parametro(.InsertCommand, "nombre_0", OracleType.VarChar, DataRowVersion.Current)
            Parametro(.InsertCommand, "equipos_0", OracleType.Number, DataRowVersion.Current)
            Parametro(.InsertCommand, "equipos_1", OracleType.Number, DataRowVersion.Current, , 0)
            Parametro(.InsertCommand, "equipos_2", OracleType.Number, DataRowVersion.Current)
            Parametro(.InsertCommand, "equipos_3", OracleType.Number, DataRowVersion.Current, , 0)
            Parametro(.InsertCommand, "prestamos_0", OracleType.Number, DataRowVersion.Current)
            Parametro(.InsertCommand, "prestamos_1", OracleType.Number, DataRowVersion.Current, , 0)
            Parametro(.InsertCommand, "prestamos_2", OracleType.Number, DataRowVersion.Current)
            Parametro(.InsertCommand, "prestamos_3", OracleType.Number, DataRowVersion.Current, , 0)
            Parametro(.InsertCommand, "retencion_0", OracleType.Number, DataRowVersion.Current, , 0)
            Parametro(.InsertCommand, "retencion_1", OracleType.Number, DataRowVersion.Current, , 0)
            Parametro(.InsertCommand, "install_0", OracleType.Number, DataRowVersion.Current)
            Parametro(.InsertCommand, "install_1", OracleType.Number, DataRowVersion.Current, , 0)
            Parametro(.InsertCommand, "rechazos_0", OracleType.Number, DataRowVersion.Current)
            Parametro(.InsertCommand, "rechazos_1", OracleType.Number, DataRowVersion.Current)
            Parametro(.InsertCommand, "cobranza_0", OracleType.Number, DataRowVersion.Current)
            Parametro(.InsertCommand, "varios_0", OracleType.Number, DataRowVersion.Current)
            Parametro(.InsertCommand, "prioridad_0", OracleType.Number, DataRowVersion.Current)
            Parametro(.InsertCommand, "hora_0", OracleType.VarChar, DataRowVersion.Current)
            Parametro(.InsertCommand, "kilos_0", OracleType.Number, DataRowVersion.Current)
            Parametro(.InsertCommand, "estado_0", OracleType.Number, DataRowVersion.Current, , 0)
            Parametro(.InsertCommand, "noconform_0", OracleType.Number, DataRowVersion.Current, , 0)
            Parametro(.InsertCommand, "sube_0", OracleType.Number, DataRowVersion.Current, , 1)
            Parametro(.InsertCommand, "orden_0", OracleType.Number, DataRowVersion.Current)
            Parametro(.InsertCommand, "tiempo_0", OracleType.VarChar, DataRowVersion.Current, , "0000")
            Parametro(.InsertCommand, "tiempo_1", OracleType.VarChar, DataRowVersion.Current, , "0000")
            Parametro(.InsertCommand, "credat_0", OracleType.DateTime, DataRowVersion.Current, , Date.Today)
            Parametro(.InsertCommand, "creusr_0", OracleType.VarChar, DataRowVersion.Current, , usr.Codigo)
            Parametro(.InsertCommand, "obs_0", OracleType.VarChar, DataRowVersion.Current, , " ")

            Parametro(.UpdateCommand, "orden_0", OracleType.Number, DataRowVersion.Current)
            Parametro(.UpdateCommand, "prioridad_0", OracleType.Number, DataRowVersion.Current)
            Parametro(.UpdateCommand, "estado_0", OracleType.Number, DataRowVersion.Current)
            Parametro(.UpdateCommand, "noconform_0", OracleType.Number, DataRowVersion.Current)
            Parametro(.UpdateCommand, "ruta_0", OracleType.Number, DataRowVersion.Original)
            Parametro(.UpdateCommand, "vcrnum_0", OracleType.VarChar, DataRowVersion.Original)

            Parametro(.DeleteCommand, "ruta_0", OracleType.Number, DataRowVersion.Original)
            Parametro(.DeleteCommand, "vcrnum_0", OracleType.VarChar, DataRowVersion.Original)
        End With

    End Sub
    Private Sub CalcularPesoPrestamos()
        Dim dr As DataRow
        Dim Peso As Integer = 0
        Dim Capacidad As Integer = 0
        Dim Sobrepeso As Integer = 0
        Dim PrestamosEntregaExt As Integer = 0
        Dim PrestamosEntregaMan As Integer = 0
        Dim PrestamosRetiroExt As Integer = 0
        Dim PrestamosRetiroMan As Integer = 0

        For Each dr In dtRutad.Rows
            If dr.RowState <> DataRowState.Deleted Then
                Peso += CType(dr("kilos_0"), Integer)

                'Sumo prestamos a entregar retirar
                If dr("tipo_0").ToString = "ENT" Then
                    PrestamosRetiroExt += CType(dr("prestamos_0"), Integer)
                    PrestamosRetiroMan += CType(dr("prestamos_2"), Integer)

                ElseIf dr("tipo_0").ToString = "RET" Then
                    PrestamosEntregaExt += CType(dr("prestamos_0"), Integer)
                    PrestamosEntregaMan += CType(dr("prestamos_2"), Integer)

                End If

            End If

        Next

        Peso += CType(nudPrestamosExt.Value * 9, Integer)

        txtPrestamosExtE.Text = PrestamosEntregaExt.ToString
        txtPrestamosExtR.Text = PrestamosRetiroExt.ToString
        txtPrestamosManE.Text = PrestamosEntregaMan.ToString
        txtPrestamosManR.Text = PrestamosRetiroMan.ToString
    End Sub
    Private Sub EliminarDocumentoTablaTemporal(ByVal vcrnum As String)
        Dim dr As DataRow

        For Each dr In dtRutax.Rows
            If dr.RowState = DataRowState.Deleted Then
                dr.RejectChanges()

                If dr("vcrnum_0").ToString = vcrnum Then
                    dtRutax.Rows.Remove(dr)

                Else
                    dr.Delete()

                End If

                Exit For

            Else
                If dr("vcrnum_0").ToString = vcrnum Then
                    dtRutax.Rows.Remove(dr)
                    Exit For
                End If
            End If
        Next

    End Sub
    Private Sub RutaAgregarDocumento()
        Dim dr As DataRow

        dr = dtRutad.NewRow
        dr("ruta_0") = dtRutac.Rows(0).Item("ruta_0")
        dr("orden_0") = ProximoOrden()
        dr("tipo_0") = Doc.Tipo
        dr("vcrnum_0") = Doc.Documento
        dr("suc_0") = Doc.Sucursal
        dr("direccion_0") = Doc.Domicilio
        dr("localidad_0") = Doc.Localidad
        dr("cliente_0") = Doc.Tercero
        dr("nombre_0") = Doc.Nombre
        dr("equipos_0") = Doc.Equipos
        dr("equipos_2") = Doc.Mangueras
        dr("prestamos_0") = Doc.PrestamosExtintores
        dr("prestamos_2") = Doc.PrestamosMangueras
        dr("retencion_0") = 0
        dr("retencion_1") = 0
        dr("install_0") = Doc.Instalaciones
        dr("rechazos_0") = Doc.RechazosExtintor
        dr("rechazos_1") = Doc.RechazosManguera
        dr("cobranza_0") = Doc.Cobranza
        dr("varios_0") = Doc.Varios
        dr("prioridad_0") = False
        dr("hora_0") = Doc.Hora
        dr("kilos_0") = Doc.Peso
        dr("estado_0") = 0
        dr("noconform_0") = 0
        dtRutad.Rows.Add(dr)

        ActualizarControles()

    End Sub
    Private Sub AgregarIntervencion(ByVal num As String)
        'Dim itn As New Intervencion(cn)

        'Consulto datos del documento a tratar
        num = num.Trim.ToUpper

        Dim PonerEnRuta As Boolean = False
        Dim RutaAnterior As Boolean = False

        Dim dr As DataRow = Nothing 'Fila que contiene documento en ruta anterior
        Dim dt As New DataTable 'Tabla con todas las rutas donde se encontro el documento
        Dim da As New OracleDataAdapter("SELECT xd.*, xc.valid_0 FROM xrutad xd INNER JOIN xrutac xc ON (xd.ruta_0 = xc.ruta_0) WHERE vcrnum_0 = :p1 ORDER BY xd.ruta_0 DESC", cn)

        If Not EnGrilla(num) Then 'Busco si el comprobante está en la grilla

            'Consulto el documento. Documento con datos actuales
            If Not Doc.Buscar(num) Then
                txtBuscar.Clear()
                Exit Sub
            End If

            'Consulta si el documento se encuentra en otra ruta
            da.SelectCommand.Parameters.Add("p1", OracleType.VarChar).Value = num
            da.Fill(dt)

            'Se encontro el documento en otra ruta
            If dt.Rows.Count > 0 Then
                dr = dt.Rows(0)

                Select Case CType(dr("estado_0"), Integer)
                    'El documento no tiene cargada novedad en la otra ruta. Se abre formulario
                    'para preguntar si se cambia de ruta o es un rebote
                    Case 0
                        Dim f As New frmDocEnRuta(num, dr("ruta_0").ToString)
                        f.ShowDialog(Me)

                        Select Case f.DialogResult
                            Case Windows.Forms.DialogResult.Yes
                                'El documento se saca de la ruta vieja y se pone en la nueva
                                PonerEnRuta = True
                                RutaAnterior = True
                                dr.Delete()


                            Case Windows.Forms.DialogResult.No
                                'Es un nuevo viaje a causa de un rebote. Se graba la no conformidad
                                'y se vuelve a poner el documento en ruta
                                PonerEnRuta = True
                                RutaAnterior = True

                                dr.BeginEdit()
                                dr("estado_0") = 4
                                dr("noconform_0") = f.Motivo
                                dr.EndEdit()

                        End Select

                        f.Dispose() : f = Nothing

                    Case 1, 2
                        PonerEnRuta = False

                    Case 3
                        'El documento está cumplido. Se deja poner en ruta solo si la ruta anterior es
                        'de retiro y el documento tiene remito para ser entregado
                        If dr("tipo_0").ToString = "RET" AndAlso Doc.TieneRemito Then
                            PonerEnRuta = True
                        Else
                            MessageBox.Show("Documento cerrado. No se puede volver a poner en ruta", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        End If


                    Case 4  'Documento con rebote
                        PonerEnRuta = True

                    Case Else
                        PonerEnRuta = False

                End Select

            Else 'No se encontró el documento en otra ruta

                'Consulto el documento. Documento con datos actuales
                If Not Doc.Buscar(num) Then
                    txtBuscar.Clear()
                    Exit Sub
                End If

                PonerEnRuta = True

            End If

            'Se valida si el documento es para entregar por lógistica y si la fecha de entrega
            'no es futura y si el cliente recibe entregas el dia que se programa la ruta
            If PonerEnRuta Then PonerEnRuta = ValidarEntrega()
            If PonerEnRuta = True Then
                PonerEnRuta = DocumentosPendientes(num)
            End If
            'Borra o actualiza documento en la ruta anterior
            If RutaAnterior AndAlso PonerEnRuta Then dtRutax.ImportRow(dr)

           
            If Doc.EsIntervencion Then
                itn = Doc.Intervencion

                'CANJE
                'Debe tener parte para poder poner en ruta
                If itn.Tipo = "B2" Then
                    'Abro la factura de la SS
                    Dim sih As New Factura(cn)

                    If sih.AbrirPorSolicitud(itn.SolicitudAsociada.Numero) Then

                        Dim par As New ParteCobranza(cn)
                        par.Abrir(sih.Numero)

                        If par.Cobrador.Trim = "" Then
                            MessageBox.Show("Falta parte de cobranza para esta intervención", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            PonerEnRuta = False
                        End If

                    Else
                        MessageBox.Show("Falta facturar esta intervención", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        PonerEnRuta = False

                    End If

                End If

                Dim sre As Solicitud

                sre = itn.SolicitudAsociada

                'No se permite poner en ruta retiros con solicitudes de servicio cerrada
                If Doc.Tipo = "RET" AndAlso sre.Estado = Solicitud.EstadoSolicitud.Cerrada Then
                    MessageBox.Show("No se puede poner en ruta porque la Solicitud de Servicio fue cerrada", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    PonerEnRuta = False
                End If

            End If

            'Si es intervencion de retiro con fecha de coordinacion, se verifica que no se
            'este intenta retirar antes de la fecha de coordinacion
            'If PonerEnRuta AndAlso Doc.EsIntervencion AndAlso Doc.Tipo = "RET" AndAlso itn.CarritoTipo > 0 AndAlso itn.CarritoFecha > dtpFecha.Value Then
            '    Dim txt As String
            '    txt = "Intervencion {itn}" & vbCrLf & vbCrLf
            '    txt &= "Esta intentando retirar antes de la fecha de coordinacion {fecha}"

            '    txt = txt.Replace("{itn}", itn.Numero)
            '    txt = txt.Replace("{fecha}", itn.CarritoFecha.ToString("dd/MM/yyyy")) & vbCrLf & vbCrLf
            '    txt &= "¿Confirma ponerla en ruta?"

            '    If MessageBox.Show(txt, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
            '        PonerEnRuta = False
            '    End If

            'End If


            'Flag que indica que el documento se debe poner en ruta
            If PonerEnRuta Then
                RutaAgregarDocumento()

                If Doc.EsIntervencion Then

                    If itn.Tanda Then
                        Dim txt As String
                        txt = "Esta intervencion debe ir acompañada con otra para retiro del saldo anterior"
                        MessageBox.Show(txt, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If

            End If

        End If

        CalcularPesoPrestamos()
        txtBuscar.Clear()

        dt.Dispose() : dt = Nothing
        da.Dispose() : da = Nothing
        dr = Nothing
    End Sub
    Private Sub ValoresIniciales()
        Select Case Modo
            Case ModoRuta.Cerrada, ModoRuta.Nueva
                dtpFecha.Value = Date.Today.AddDays(CDbl(IIf(Date.Today.DayOfWeek = DayOfWeek.Friday, 3, 1)))
                txtDescripcion.Clear()
                txtVarios.Clear()
                txtRuta.Clear()

                TablaTransporte(lstTransportes)

                If lstVehiculos.DataSource IsNot Nothing Then
                    CType(lstVehiculos.DataSource, DataTable).Clear()
                End If

                MenuLocal(cn, 2408, cboAcompante1, True)
                MenuLocal(cn, 2408, cboAcompante2, True)
                MenuLocal(cn, 2408, cboAcompante3, True)

                SeleccionarAcompanante(cboAcompante1, 0)
                SeleccionarAcompanante(cboAcompante2, 0)
                SeleccionarAcompanante(cboAcompante3, 0)

                nudPrestamosExt.Value = 0
                nudPrestamosMan.Value = 0

                chkMicrocentro.Checked = False

            Case ModoRuta.Edicion, ModoRuta.Vista
                txtRuta.Text = dtRutac.Rows(0).Item("ruta_0").ToString
                dtpFecha.Value = CType(dtRutac.Rows(0).Item("fecha_0"), Date)
                txtDescripcion.Text = dtRutac.Rows(0).Item("descrip_0").ToString
                txtVarios.Text = dtRutac.Rows(0).Item("varios_0").ToString

                TablaTransporte(lstTransportes, dtRutac.Rows(0).Item("transporte_0").ToString)
                TablaVehiculos(lstVehiculos, dtRutac.Rows(0).Item("transporte_0").ToString, dtRutac.Rows(0).Item("patente_0").ToString)

                cboAcompante1.SelectedValue = dtRutac.Rows(0).Item("acomp_0").ToString
                cboAcompante2.SelectedValue = dtRutac.Rows(0).Item("acomp_1").ToString

                MenuLocal(cn, 2408, cboAcompante1, True)
                MenuLocal(cn, 2408, cboAcompante2, True)
                MenuLocal(cn, 2408, cboAcompante3, True)

                SeleccionarAcompanante(cboAcompante1, CInt(dtRutac.Rows(0).Item("acomp_0")))
                SeleccionarAcompanante(cboAcompante2, CInt(dtRutac.Rows(0).Item("acomp_1")))
                SeleccionarAcompanante(cboAcompante3, CInt(dtRutac.Rows(0).Item("acomp_2")))

                nudPrestamosExt.Value = CType(dtRutac.Rows(0).Item("prestamos_0"), Decimal)
                nudPrestamosMan.Value = CType(dtRutac.Rows(0).Item("mangas_0"), Decimal)

                Me.Text = Me.Tag.ToString & " Nro. " & txtRuta.Text

                chkMicrocentro.Checked = CBool(IIf(CInt(dtRutac.Rows(0).Item("micro_0")) <> 2, False, True))
        End Select

    End Sub
    Private Sub LimpiarTablas()
        ds.EnforceConstraints = False
        dtRutac.Rows.Clear()
        dtRutad.Rows.Clear()
        dtRutax.Rows.Clear()
        ds.EnforceConstraints = True
    End Sub
    Private Function Grabar() As Boolean
        Dim dr As DataRow

        dr = dtRutac.Rows(0)

        'Valido transporte
        If lstTransportes.SelectedItems.Count = 0 Then
            MessageBox.Show("Debe seleccionar una empresa de transporte", "Transporte", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If
        If lstVehiculos.SelectedItems.Count = 0 Then
            MessageBox.Show("Debe seleccionar un vehículo", "Transporte", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If

        'Validacion cantidad de acompañantes
        Dim pat As New Camioneta(cn)
        Dim txt As String = ""
        pat.Abrir(lstTransportes.SelectedValue.ToString, lstVehiculos.SelectedValue.ToString)

        If pat.Sector = LOGISTICA And pat.Acomp <= 0 Then
            If CantidadAcompanantes() >= 2 And CantidadMovimientos() <= MOVIMIENTOS Then
                txt = "Para dos acompañantes la cantidad de movimientos debe ser mayor a " & MOVIMIENTOS.ToString
                MessageBox.Show(txt, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        End If
        pat = Nothing
        If txt.Length > 0 Then Return False


        If Modo = ModoRuta.Nueva Then
            'valido que la ruta no esté vacía
            If dtRutad.Rows.Count = 0 Then
                MessageBox.Show("La ruta está vacía", "Nueva Ruta", MessageBoxButtons.OK)
                Exit Function
            End If

            'Asigno número a la ruta
            dr.BeginEdit()
            dr("ruta_0") = ObtenerProxNumeroRuta()
            dr.EndEdit()

        ElseIf Modo = ModoRuta.Edicion Then
            dr.BeginEdit()
            dr("fecha_0") = dtpFecha.Value
            dr("descrip_0") = TextoNulo(txtDescripcion.Text)
            dr("varios_0") = TextoNulo(txtVarios.Text)
            dr("transporte_0") = lstTransportes.SelectedValue.ToString
            dr("patente_0") = lstVehiculos.SelectedValue.ToString

            If cboAcompante1.SelectedValue Is Nothing Then
                dr("acomp_0") = 0
            Else
                dr("acomp_0") = cboAcompante1.SelectedValue
            End If
            If cboAcompante2.SelectedValue Is Nothing Then
                dr("acomp_1") = 0
            Else
                dr("acomp_1") = cboAcompante2.SelectedValue
            End If
            If cboAcompante3.SelectedValue Is Nothing Then
                dr("acomp_2") = 0
            Else
                dr("acomp_2") = cboAcompante3.SelectedValue
            End If

            dr("prestamos_0") = nudPrestamosExt.Value
            dr.EndEdit()

        End If



        Dim flg As Boolean = False

        Try

            daRutac.Update(dtRutac)
            daRutad.Update(dtRutax)
            daRutad.Update(dtRutad)

            flg = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            flg = False

        End Try

        If Modo = ModoRuta.Nueva Then
            Modo = ModoRuta.Edicion
            txtRuta.Text = dr("ruta_0").ToString
            Me.Text = Me.Tag.ToString & " Nro. " & txtRuta.Text

            MessageBox.Show("Se creó la ruta Nro: " & dr("ruta_0").ToString, "Nueva Ruta", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

        ActualizarControles()

        Return flg

    End Function
    Private Sub TablaTransporte(ByVal lst As ListBox, Optional ByVal Transporte As String = "")
        Dim da As New OracleDataAdapter("SELECT bptnum_0, bptnam_0 FROM bpcarrier WHERE xbptsta_0 = 2 ORDER BY bptnam_0", cn)
        Dim dt As DataTable
        Dim dr As DataRow
        Dim i As Integer
        Dim flg As Boolean = False 'Flg para indicar que se encontro el registro

        If lst.DataSource Is Nothing Then
            dt = New DataTable
            da.FillSchema(dt, SchemaType.Source)

            lst.DataSource = dt
            lst.DisplayMember = "bptnam_0"
            lst.ValueMember = "bptnum_0"

        Else
            dt = CType(lst.DataSource, DataTable)

        End If

        dt.Clear()
        da.Fill(dt) 'Lleno la tabla con los transportes activos

        If Transporte <> "" Then 'Busco transporte en la tabla para seleccionarlo
            For Each dr In dt.Rows
                If dr("bptnum_0").ToString = Transporte Then
                    lst.SelectedValue = Transporte
                    flg = True
                    Exit For
                End If
            Next

            If Not flg Then
                'No encontre el transporte lo busco entre los inactivos
                da = New OracleDataAdapter("SELECT bptnum_0, bptnam_0 FROM bpcarrier WHERE bptnum_0 = :p1", cn)
                da.SelectCommand.Parameters.Add("p1", OracleType.VarChar).Value = Transporte

                i = da.Fill(dt)
                If i = 1 Then lst.SelectedValue = Transporte
            End If

        Else
            lst.ClearSelected()

        End If

        da.Dispose()

    End Sub
    Private Sub TablaVehiculos(ByVal lst As ListBox, ByVal Transporte As String, Optional ByVal Patente As String = "")
        Dim da As OracleDataAdapter
        Dim dt As DataTable
        Dim dr As DataRow
        Dim i As Integer
        Dim flg As Boolean = False 'Flg para indicar que se encontro el registro

        da = New OracleDataAdapter("SELECT bptnum_0, patnum_0, maxwei_0, chofer_0 FROM zunitrans WHERE xpatsta_0 = 2 AND bptnum_0 = :p1 ORDER BY chofer_0", cn)
        da.SelectCommand.Parameters.Add("p1", OracleType.VarChar).Value = Transporte

        If lst.DataSource Is Nothing Then
            dt = New DataTable
            lst.DataSource = dt

            da.FillSchema(dt, SchemaType.Source)
            lstVehiculos.DisplayMember = "chofer_0"
            lstVehiculos.ValueMember = "patnum_0"

        Else
            dt = CType(lst.DataSource, DataTable)

        End If

        dt.Clear()
        da.Fill(dt) 'Lleno la tabla con las camionetas activas

        If Patente <> "" Then 'Busco camioneta en la tabla para seleccionarla
            For Each dr In dt.Rows
                If dr("patnum_0").ToString = Patente Then
                    lst.SelectedValue = Patente
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
                If i = 1 Then lst.SelectedValue = Patente

            End If

        End If
        da.Dispose()

    End Sub
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

            'Salto si el registro fue eliminado
            If dr.RowState = DataRowState.Deleted Then Continue For
            'Si el valor evaluado está seleccionado en el combo, paso al siguiente For
            If CInt(dr(0)) = CInt(cbo.SelectedValue) Then Continue For

            'Elimino el registro si el acompañante no esta activo
            If txt.Substring(i - 1, 1).ToUpper <> "S" Then dr.Delete()

        Next

    End Sub
    Private Sub AcompanantesOnOff()
        'Si la camioneta seleccionada es de Georgia, desactiva el primer y tercer acompañante

        If lstTransportes.SelectedValue Is Nothing Then Exit Sub
        If lstVehiculos.SelectedValue Is Nothing Then Exit Sub

        Dim pat As New Camioneta(cn)
        pat.Abrir(lstTransportes.SelectedValue.ToString, lstVehiculos.SelectedValue.ToString)

        If pat.Sector = LOGISTICA Then
            'Si la camioneta es de logistica, desactivo acompañante 3
            cboAcompante3.Enabled = False '(pat.Sector <> LOGISTICA)
            cboAcompante3.SelectedValue = 0

            'Si es chofer Georgia, desactivo acompañante 1
            cboAcompante1.Enabled = (pat.Acomp <= 1)
            'y lo pongo como primer acompañante
        End If

        pat = Nothing

    End Sub

    'FUNCIONES
    Private Function ValidarEntrega() As Boolean
        Dim msg As String = ""
        Dim btn As DialogResult = Nothing

        'Validar modo de entrega
        If lstTransportes.SelectedValue Is Nothing Then
            If Doc.ModoEntrega = "2" Then
                'El documento debe ser retirado por CLIENTE pero se pone en ruta para entrega por LOGISTICA
                msg = "El modo de entrega de este documento es: CLIENTE RETIRA POR GEORGIA"
                msg &= vbCrLf & vbCrLf
                msg &= "¿Pone este documento en ruta?"

                btn = MessageBox.Show(msg, "Modo de Entrega", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If btn = Windows.Forms.DialogResult.No Then Return False

            End If

        Else

            If Doc.ModoEntrega = "1" And lstTransportes.SelectedValue.ToString = MOSTRADOR Then
                'El documento debe ser entrega por GEORGIA pero se pone en transporte MOSTRADOR
                msg = "El modo de entrega de este documento es: ENTREGA GEORGIA"
                msg &= vbCrLf
                msg &= "¿Confirma que el cliente retira por GEORGIA?"

                btn = MessageBox.Show(msg, "Modo de Entrega", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If btn = Windows.Forms.DialogResult.No Then Return False

            ElseIf Doc.ModoEntrega = "2" And lstTransportes.SelectedValue.ToString <> MOSTRADOR Then
                'El documento debe ser retirado por CLIENTE pero se pone en ruta para entrega por LOGISTICA
                msg = "El modo de entrega de este documento es: CLIENTE RETIRA POR GEORGIA"
                msg &= vbCrLf
                msg &= "¿Pone este documento en ruta?"

                btn = MessageBox.Show(msg, "Modo de Entrega", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If btn = Windows.Forms.DialogResult.No Then Return False

            End If

        End If

        'validar fecha de entrega futura
        If Doc.FechaEntrega > dtpFecha.Value Then
            msg = "Este documento debe ser entregado el " & Doc.FechaEntrega.ToShortDateString
            msg &= vbCrLf
            msg &= "¿Confirma la puesta en ruta?"

            btn = MessageBox.Show(msg, "Fecha de Entrega", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If btn = Windows.Forms.DialogResult.No Then Return False

        End If

        'valido que el cliente reciba
        If Not Doc.ValidarDiaEntrega(dtpFecha.Value) Then
            msg = "El cliente no recibe entregas el " & dtpFecha.Value.ToShortDateString
            msg &= vbCrLf
            msg &= "¿Confirma la puesta en ruta?"

            btn = MessageBox.Show(msg, "Fecha de Entrega", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If btn = Windows.Forms.DialogResult.No Then Return False

        End If

        'Todo OK
        Return True

    End Function
    Private Function EnGrilla(ByVal vcrnum As String) As Boolean
        'Busca si un comprobante ya fue cargado en la grilla
        'Si lo encuentra lo borra y devuelve True, caso contrario devuelve False
        Dim dr As DataRow
        Dim dr2 As DataRow

        For Each dr In dtRutad.Rows

            If dr.RowState = DataRowState.Deleted Then
                dr.RejectChanges()

                If dr("vcrnum_0").ToString = vcrnum Then
                    EnGrilla = True

                Else
                    dr.Delete()

                End If

            Else

                If dr("vcrnum_0").ToString = vcrnum Then

                    'Borro linea automaticamente
                    If Modo = ModoRuta.Nueva Then
                        dtRutad.Rows.Remove(dr)
                    Else
                        dr.Delete()
                    End If

                    EliminarDocumentoTablaTemporal(vcrnum)

                    EnGrilla = True

                End If

                If EnGrilla Then Exit For

            End If

        Next

        dr = Nothing
        dr2 = Nothing

    End Function
    Private Function ObtenerProxNumeroRuta() As Integer

        Dim cm As New OracleCommand("SELECT MAX(ruta_0) FROM xrutac", cn)
        Dim i As Object = cm.ExecuteScalar

        cm.Dispose() : cm = Nothing

        If IsDBNull(i) Then
            Return 1
        Else
            Return CType(i, Integer) + 1
        End If

    End Function
    Private Function ProximoOrden() As Integer
        Dim dr As DataRow
        Dim i As Integer = 0

        For Each dr In dtRutad.Rows
            If dr.RowState <> DataRowState.Deleted Then
                If CType(dr("orden_0"), Integer) > i Then i = CType(dr("orden_0"), Integer)
            End If
        Next

        i += 1
        Return i

    End Function
    Private Function TareaSecuencia() As String
        Dim aa As Integer = Date.Now.Year
        Dim mm As Integer = Date.Now.Month
        Dim dd As Integer = Date.Now.Day
        Dim h As Integer = Date.Now.Hour
        Dim m As Integer = Date.Now.Minute
        Dim s As Integer = Date.Now.Second
        Dim Valor As String

        Valor = aa.ToString
        Valor &= Strings.Right("0" & mm.ToString, 2)
        Valor &= Strings.Right("0" & dd.ToString, 2)
        Valor &= Strings.Right("0" & h.ToString, 2)
        Valor &= Strings.Right("0" & m.ToString, 2)
        Valor &= Strings.Right("0" & s.ToString, 2)

        Return Valor

    End Function
    Private Function DocumentosPendientes(ByVal documento As String) As Boolean
        Dim sql As String
        Dim cliente As String
        Dim sucursal As String
        Dim numero As String = ""
        Dim sector As String = ""
        Dim da As OracleDataAdapter
        Dim dt As New DataTable
        Dim dt2 As New DataTable
        Dim dr As DataRow
        Dim result As DialogResult

        If itn.Abrir(documento) Then
            cliente = itn.Cliente.Codigo
            sucursal = itn.SucursalCodigo
            sql = "select num_0 from interven where (zflgtrip_0 >= '1' and zflgtrip_0 <= '4' or zflgtrip_0 = '6') "
            sql &= " and bpc_0 = :bpcord_0 and bpaadd_0 = :bpaadd_0 and num_0 <> :numero"
            da = New OracleDataAdapter(sql, cn)
            da.SelectCommand.Parameters.Add("bpcord_0", OracleType.VarChar).Value = cliente
            da.SelectCommand.Parameters.Add("bpaadd_0", OracleType.VarChar).Value = sucursal
            da.SelectCommand.Parameters.Add("numero", OracleType.VarChar).Value = documento
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                dr = dt.Rows(0)
                numero = dr("num_0").ToString
            Else
                dt.Clear()
                sql = "select sdhnum_0 from sdelivery where (xflgrto_0 >= '1' and xflgrto_0 <= '4') and "
                sql &= " bpcord_0 = :bpcord_0 and bpaadd_0 = :bpaadd_0 and sdhnum_0 <> :numero"
                da = New OracleDataAdapter(sql, cn)
                da.SelectCommand.Parameters.Add("bpcord_0", OracleType.VarChar).Value = cliente
                da.SelectCommand.Parameters.Add("bpaadd_0", OracleType.VarChar).Value = sucursal
                da.SelectCommand.Parameters.Add("numero", OracleType.VarChar).Value = documento
                da.Fill(dt)

                If dt.Rows.Count > 0 Then
                    dr = dt.Rows(0)
                    numero = dr("sdhnum_0").ToString
                End If
            End If
        Else
            rto.Abrir(documento)
            cliente = rto.Cliente.Codigo
            sucursal = rto.SucursalCodigo
            sql = "select sdhnum_0 from sdelivery where (xflgrto_0 >= '1' and xflgrto_0 <= '4') and "
            sql &= " bpcord_0 = :bpcord_0 and bpaadd_0 = :bpaadd_0 and sdhnum_0 <> :numero"
            da = New OracleDataAdapter(sql, cn)
            da.SelectCommand.Parameters.Add("bpcord_0", OracleType.VarChar).Value = cliente
            da.SelectCommand.Parameters.Add("bpaadd_0", OracleType.VarChar).Value = sucursal
            da.SelectCommand.Parameters.Add("numero", OracleType.VarChar).Value = documento
            da.Fill(dt)

            If dt.Rows.Count > 0 Then
                dr = dt.Rows(0)
                numero = dr("sdhnum_0").ToString
            Else
                dt.Clear()
                sql = "select num_0 from interven where (zflgtrip_0 >= '1' and zflgtrip_0 <= '4' or zflgtrip_0 = '6') "
                sql &= " and bpc_0 = :bpcord_0 and bpaadd_0 = :bpaadd_0 and num_0 <> :numero"
                da = New OracleDataAdapter(sql, cn)
                da.SelectCommand.Parameters.Add("bpcord_0", OracleType.VarChar).Value = cliente
                da.SelectCommand.Parameters.Add("bpaadd_0", OracleType.VarChar).Value = sucursal
                da.SelectCommand.Parameters.Add("numero", OracleType.VarChar).Value = documento
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    dr = dt.Rows(0)
                    numero = dr("num_0").ToString
                End If
            End If
        End If

        If dt.Rows.Count > 0 Then
            If itn.Abrir(numero) Then
                sql = "select para_0 from xsegto where itn_0 = :numero order by fecha_0 desc"
                da = New OracleDataAdapter(sql, cn)
                da.SelectCommand.Parameters.Add("numero", OracleType.VarChar).Value = numero
            ElseIf rto.Abrir(numero) Then
                sql = "select para_0 from xsegto where rto_0 = :numero order by fecha_0 desc"
                da = New OracleDataAdapter(sql, cn)
                da.SelectCommand.Parameters.Add("numero", OracleType.VarChar).Value = numero
            End If
        End If
        da.Fill(dt2)
        If dt2.Rows.Count > 0 Then
            dr = dt2.Rows(0)
            sector = dr("para_0").ToString
        Else
            sector = "(Sin Pistolear)"
        End If
        If dt.Rows.Count > 0 Then

            result = MessageBox.Show("Para este mismo cliente (" & cliente & "), sucursal (" & sucursal & ") existe el nro de ped/int pendiente nro: " & numero & " en el sector: " & sector & " , quiere igualmente agregar este documento?", "Atencion", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then
                Return True
            ElseIf result = DialogResult.No Then
                Return False
            End If
        Else
            Return True
        End If

    End Function
    Private Function CantidadMovimientos() As Integer
        Dim c As Integer = 0

        For Each dr As DataRow In dtRutad.Rows
            If dr.RowState = DataRowState.Deleted Then Continue For

            Select Case dr("tipo_0").ToString
                Case "RET", "ENT", "NUE", "NCI"
                    c += CInt(dr("equipos_0"))
                    c += CInt(dr("equipos_2"))
                    c += CInt(dr("prestamos_0"))
                    c += CInt(dr("prestamos_2"))
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

    'EVENTOS
    Private Sub frmRuta_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If txtBuscar.Enabled Then txtBuscar.Focus()
    End Sub
    Private Sub frmRuta_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Enlace de la grilla
        colRuta.DataPropertyName = "ruta_0"
        colOrden.DataPropertyName = "orden_0"
        colSuc.DataPropertyName = "suc_0"
        colDomicilio.DataPropertyName = "direccion_0"
        colLocalidad.DataPropertyName = "localidad_0"
        colCliente.DataPropertyName = "cliente_0"
        colNombre.DataPropertyName = "nombre_0"
        colTipo.DataPropertyName = "tipo_0"
        colDocumento.DataPropertyName = "vcrnum_0"
        colEquipos.DataPropertyName = "equipos_0"
        colMangas.DataPropertyName = "equipos_2"
        colPrestamoExt.DataPropertyName = "prestamos_0"
        colPrestamoMan.DataPropertyName = "prestamos_2"
        colRetencion1.DataPropertyName = "retencion_0"
        colRetencion2.DataPropertyName = "retencion_1"
        colInstalaciones.DataPropertyName = "install_0"
        colRechazoExt.DataPropertyName = "rechazos_0"
        colRechazoMan.DataPropertyName = "rechazos_1"
        colCobranza.DataPropertyName = "cobranza_0"
        colVarios.DataPropertyName = "varios_0"
        colPrioridad.DataPropertyName = "prioridad_0"
        colHorario.DataPropertyName = "hora_0"
        colPeso.DataPropertyName = "kilos_0"
        colEstado.DataPropertyName = "estado_0"
        colNoConform.DataPropertyName = "noconform_0"

        Grilla.DataSource = dtRutad

        Dim mnu As New MenuLocal(cn, 409, True)
        mnu.Enlazar(cboZonas)

        'ValoresIniciales()
        ActualizarControles()

        CargarComboCelulares()

    End Sub
    Private Sub frmRuta_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not (e.CloseReason = CloseReason.TaskManagerClosing Or e.CloseReason = CloseReason.WindowsShutDown) Then
            If ds.HasChanges Then
                Select Case MessageBox.Show("¿Graba los cambios antes de salir?", Me.Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                    Case Windows.Forms.DialogResult.Yes
                        e.Cancel = Not Grabar()

                    Case Windows.Forms.DialogResult.Cancel
                        e.Cancel = True

                End Select
            End If
        End If

    End Sub
    Private Sub lstTransportes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstTransportes.SelectedIndexChanged
        If Not lstTransportes.SelectedValue Is Nothing Then
            TablaVehiculos(lstVehiculos, lstTransportes.SelectedValue.ToString)
            lstVehiculos.SelectedItems.Clear()
        End If
    End Sub
    Private Sub lstVehiculos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstVehiculos.SelectedIndexChanged
        If dtRutac.Rows.Count = 0 Then Exit Sub

        Dim dr As DataRowView

        If Not lstVehiculos.SelectedItem Is Nothing Then
            dr = CType(lstVehiculos.SelectedItem, DataRowView)

            If BloqueoModificacion = False Then
                With dtRutac.Rows(0)
                    .BeginEdit()
                    .Item("transporte_0") = lstTransportes.SelectedValue.ToString
                    .Item("patente_0") = lstVehiculos.SelectedValue.ToString
                    .EndEdit()
                End With

                Dim pat As New Camioneta(cn)
                pat.Abrir(lstTransportes.SelectedValue.ToString, lstVehiculos.SelectedValue.ToString)

                If pat.Sector = LOGISTICA AndAlso pat.Acomp > 1 Then
                    SeleccionarAcompanante(cboAcompante1, pat.Acomp)
                End If
                pat = Nothing

            End If

        End If

        ActualizarControles()
        CalcularPesoPrestamos()

    End Sub
    Private Sub dtpFecha_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtpFecha.Validating
        If Modo <> ModoRuta.Vista AndAlso dtpFecha.Value < Date.Today Then
            MessageBox.Show("La fecha no puede ser pasada", "Fecha")
            e.Cancel = True
        End If
    End Sub
    Private Sub dtpFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFecha.ValueChanged
        If dtRutac.Rows.Count = 0 Or BloqueoModificacion Then Exit Sub

        With dtRutac.Rows(0)
            .BeginEdit()
            .Item("fecha_0") = dtpFecha.Value
            .EndEdit()
        End With

    End Sub
    Private Sub nudPrestamos_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudPrestamosExt.ValueChanged
        If dtRutac.Rows.Count = 0 Or BloqueoModificacion Then Exit Sub

        With dtRutac.Rows(0)
            .BeginEdit()
            .Item("prestamos_0") = nudPrestamosExt.Value
            .EndEdit()
        End With

        CalcularPesoPrestamos()

    End Sub
    Private Sub nudPrestamosMan_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles nudPrestamosMan.ValueChanged
        If dtRutac.Rows.Count = 0 Or BloqueoModificacion Then Exit Sub

        With dtRutac.Rows(0)
            .BeginEdit()
            .Item("mangas_0") = nudPrestamosMan.Value
            .EndEdit()
        End With

        CalcularPesoPrestamos()

    End Sub
    Private Sub dgvGrilla_RowValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles Grilla.RowValidating
        If e.RowIndex < 0 OrElse e.RowIndex >= Grilla.Rows.Count Then Exit Sub

        Dim row As DataGridViewRow = Grilla.Rows(e.RowIndex)

        If row.Cells("colOrden").Value Is Nothing Then Exit Sub

        'Valido que si orden es 0, la linea pertenezca a ALMUERZO
        If row.Cells("colOrden").Value.ToString = "0" And row.Cells("colDocumento").Value.ToString <> "ALMUERZO" Then
            MessageBox.Show("El orden cero se encuentra reservado para ALMUERZO", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            e.Cancel = True
        End If

    End Sub
    Private Sub dgvGrilla_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles Grilla.UserDeletedRow
        CalcularPesoPrestamos()
        ActualizarControles()
    End Sub
    Private Sub dgvGrilla_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles Grilla.UserDeletingRow
        If CInt(e.Row.Cells("colEstado").Value) > 0 Then
            e.Cancel = True
        Else
            EliminarDocumentoTablaTemporal(e.Row.Cells("colDocumento").Value.ToString)

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
    Private Sub txtDescripcion_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDescripcion.LostFocus
        If dtRutac.Rows.Count = 0 Or BloqueoModificacion Then Exit Sub

        With dtRutac.Rows(0)
            If .Item("descrip_0").ToString <> txtDescripcion.Text Then

                If txtDescripcion.Text.Trim = "" Then
                    .BeginEdit()
                    .Item("descrip_0") = " "
                    .EndEdit()

                Else
                    .BeginEdit()
                    .Item("descrip_0") = txtDescripcion.Text
                    .EndEdit()

                End If

            End If

        End With

    End Sub
    Private Sub txtVarios_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtVarios.LostFocus
        If dtRutac.Rows.Count = 0 Or BloqueoModificacion Then Exit Sub

        With dtRutac.Rows(0)
            If .Item("varios_0").ToString <> txtVarios.Text Then

                If txtVarios.Text.Trim = "" Then
                    .BeginEdit()
                    .Item("varios_0") = " "
                    .EndEdit()

                Else
                    .BeginEdit()
                    .Item("varios_0") = txtVarios.Text
                    .EndEdit()

                End If

            End If

        End With

    End Sub
    Private Sub txtBuscar_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBuscar.KeyUp

        If e.KeyCode = Keys.Enter AndAlso txtBuscar.Text.Trim <> "" Then
            AgregarIntervencion(txtBuscar.Text)
        End If

    End Sub
    Private Sub dtRutac_RowChanged(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs) Handles dtRutac.RowChanged
        ActualizarControles()
    End Sub
    Private Sub dtRutad_RowChanged(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs) Handles dtRutad.RowChanged
        ActualizarControles()
    End Sub
    Private Sub dtRutad_RowDeleted(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs) Handles dtRutad.RowDeleted
        ActualizarControles()
    End Sub
    Private Sub daRutad_RowUpdated(ByVal sender As Object, ByVal e As System.Data.OracleClient.OracleRowUpdatedEventArgs) Handles daRutad.RowUpdated

        If e.Status <> UpdateStatus.Continue Then Exit Sub

        If e.StatementType = StatementType.Insert Then

            Select Case e.Row("tipo_0").ToString
                Case "RET", "CTL"
                    If itn.Abrir(e.Row("vcrnum_0").ToString) Then
                        itn.Estado = 1
                        itn.Ruta = dtRutac.Rows(0).Item("ruta_0").ToString
                        itn.Grabar()
                    End If

                Case "ENT"
                    If itn.Abrir(e.Row("vcrnum_0").ToString) Then
                        itn.Estado = 4
                        itn.Ruta = dtRutac.Rows(0).Item("ruta_0").ToString
                        itn.Grabar()
                    End If

                Case "NCI", "INS", "NUE"
                    If rto.Abrir(e.Row("vcrnum_0").ToString) Then
                        rto.Estado = 2 'En ruta
                        rto.Ruta = dtRutac.Rows(0).Item("ruta_0").ToString
                        rto.Grabar()
                    End If

            End Select

        ElseIf e.StatementType = StatementType.Delete Then

            Select Case e.Row("tipo_0", DataRowVersion.Original).ToString
                Case "RET", "CTL"
                    If itn.Abrir(e.Row("vcrnum_0", DataRowVersion.Original).ToString) Then
                        itn.Estado = 1
                        itn.Ruta = " "
                        itn.Grabar()
                    End If

                Case "ENT"
                    If itn.Abrir(e.Row("vcrnum_0", DataRowVersion.Original).ToString) Then
                        itn.Estado = 4
                        itn.Ruta = " "
                        itn.Grabar()
                    End If

                Case "NCI", "INS", "NUE"
                    If rto.Abrir(e.Row("vcrnum_0", DataRowVersion.Original).ToString) Then
                        rto.Estado = 1 'Pendiente
                        rto.Ruta = " "
                        rto.Grabar()
                    End If

            End Select

        End If

    End Sub
    Private Sub Doc_ErrorDocumento(ByVal sender As Object, ByVal e As ErrDocumentoEvenArgs) Handles Doc.ErrorDocumento
        MessageBox.Show(e.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End Sub

    'EVENTOS DE MENU CONTEXTUAL
    Private Sub mnuContextMenu_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mnuContextMenu.Opening

        If Grilla.CurrentRow Is Nothing Then
            e.Cancel = True

        Else
            Select Case Grilla.CurrentRow.Cells("colTipo").Value.ToString
                Case "CTL"
                    mnuVerDocumento.Enabled = True
                    mnuRelevamiento.Enabled = True

                Case "RET", "ENT"
                    mnuVerDocumento.Enabled = True

                    If itn.Abrir(Grilla.CurrentRow.Cells("colDocumento").Value.ToString) AndAlso itn.Tipo = "C1" Then
                        mnuRelevamiento.Enabled = True

                    Else
                        mnuRelevamiento.Enabled = False

                    End If


                Case "NUE", "NCI", "INS"
                    mnuVerDocumento.Enabled = True
                    mnuRelevamiento.Enabled = False

                Case Else
                    mnuVerDocumento.Enabled = False
                    mnuRelevamiento.Enabled = False
            End Select

        End If

    End Sub
    Private Sub mnuVerDocumento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuVerDocumento.Click
        Dim rpt As New ReportDocument
        Dim f As frmCrystal
        Dim t As String = Grilla.CurrentRow.Cells("colDocumento").Value.ToString

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

        End Try

    End Sub
    Private Sub mnuRelevamiento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRelevamiento.Click
        Dim rpt As New ReportDocument

        Dim f As frmCrystal
        Dim Cliente As String = Grilla.CurrentRow.Cells("colCliente").Value.ToString
        Dim Sucursal As String = Grilla.CurrentRow.Cells("colSuc").Value.ToString
        Dim Fecha As Date = Date.Today

        Fecha = Fecha.AddMonths(1)
        Fecha = Fecha.AddDays(-1 * Fecha.Day)

        Try
            rpt.Load(RPTX3 & "XPARQUEN3.rpt")

            rpt.SetParameterValue("BPC", Cliente)
            rpt.SetParameterValue("SUCDEB", Sucursal)
            rpt.SetParameterValue("SUCFIN", Sucursal)
            rpt.SetParameterValue("FECVENC", Fecha)
            rpt.SetParameterValue("OFF_HIDRA", False)
            rpt.SetParameterValue("X3USR", usr.Codigo)

            f = New frmCrystal(rpt)
            f.MdiParent = Me.ParentForm
            f.Show()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    'EVENTOS BARRA DE HERRAMIENTAS
    Private Sub toolNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolNuevo.Click
        Dim dr As DataRow

        LimpiarTablas()
        Modo = ModoRuta.Nueva
        ValoresIniciales()
        ActualizarControles()

        'Registro de cabecera en blanco
        dr = dtRutac.NewRow
        dr("ruta_0") = 0
        dr("fecha_0") = dtpFecha.Value
        dr("descrip_0") = " "
        dr("varios_0") = " "
        dr("transporte_0") = " "
        dr("patente_0") = " "
        dr("acomp_0") = 0
        dr("acomp_1") = 0
        dr("acomp_2") = 0
        dr("prestamos_0") = 0
        dr("prestamos_1") = 0
        dr("mangas_0") = 0
        dr("mangas_1") = 0
        dr("valid_0") = 0
        dr("hora_0") = "0000"
        dr("hora_1") = "0000"
        dr("hora_2") = "0000"
        dr("hora_3") = "0000"
        dr("credat_0") = Date.Today
        dr("creusr_0") = usr.Codigo
        dr("validusr_0") = " "
        dr("validdat_0") = #12/31/1599#
        dr("almuerzo_0") = "0000"
        dr("almuerzo_1") = "0000"
        dr("demora_0") = 0
        dr("canje_0") = 0
        dr("micro_0") = 1
        dtRutac.Rows.Add(dr)

        txtBuscar.Focus()

    End Sub
    Private Sub toolAbrir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolAbrir.Click
        Dim f As New frmSelectorRuta

        f.ShowDialog(Me)

        If f.DialogResult = Windows.Forms.DialogResult.OK Then

            BloqueoModificacion = True

            'Parametros de las consultas
            daRutac.SelectCommand.Parameters(0).Value = f.Ruta
            daRutad.SelectCommand.Parameters(0).Value = f.Ruta


            LimpiarTablas()
            daRutac.Fill(dtRutac)
            daRutad.Fill(dtRutad)

            If CInt(dtRutac.Rows(0).Item("valid_0")) = 1 Then
                Modo = ModoRuta.Vista

            Else
                Modo = ModoRuta.Edicion

            End If

            ValoresIniciales()
            ActualizarControles()
            CalcularPesoPrestamos()

            BloqueoModificacion = False

        End If

        f.Dispose() : f = Nothing

    End Sub
    Private Sub toolGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolGrabar.Click
        Grabar()
    End Sub
    Private Sub toolDeshacer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolDeshacer.Click
        ds.RejectChanges()

        If Modo = ModoRuta.Nueva Then Modo = ModoRuta.Cerrada

        ValoresIniciales()
        ActualizarControles()

    End Sub
    Private Sub tooBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tooBorrar.Click
        Dim cm As New OracleCommand("DELETE FROM xrutac WHERE ruta_0 = :p1", cn)
        cm.Parameters.Add("p1", OracleType.Number).Value = CInt(txtRuta.Text)
        cm.ExecuteNonQuery()
        cm.Dispose()

        LimpiarTablas()
        Modo = ModoRuta.Cerrada
        ValoresIniciales()
        ActualizarControles()

    End Sub
    Private Sub toolImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolImprimir.Click
        If txtRuta.Text = "" Then Exit Sub

        Dim rpt As New ReportDocument
        Dim f As frmCrystal

        Try
            rpt.Load(RPTX3 & "XHR.rpt")
            rpt.SetParameterValue("ruta", CInt(txtRuta.Text))

            f = New frmCrystal(rpt)
            f.MdiParent = Me.MdiParent
            f.Text = "Impresión Ruta Nro. " & txtRuta.Text
            f.Show()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub
    Private Sub toolPreparacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolPreparacion.Click
        If txtRuta.Text = "" Then Exit Sub

        'Valido que la ruta tenga nuevo
        Dim dr As DataRow
        Dim flg As Boolean = False

        For Each dr In dtRutad.Rows
            flg = (dr("tipo_0").ToString = "NUE" Or dr("tipo_0").ToString = "NCI")
            If flg Then Exit For
        Next
        If Not flg Then
            MessageBox.Show("Esta ruta no tiene mercaderia nueva", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim rpt As New ReportDocument
        Dim f As frmCrystal

        Try
            rpt.Load(RPTX3 & "XPREPARACION.rpt")
            rpt.SetParameterValue("RUTA", CInt(txtRuta.Text))

            f = New frmCrystal(rpt)
            f.MdiParent = Me.MdiParent
            f.Text = "Impresión Hoja Preparación: " & txtRuta.Text
            f.Show()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub
    Private Sub toolPreparacion2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolPreparacion2.Click
        If txtRuta.Text = "" Then Exit Sub

        'Valido que la ruta tenga ENT
        Dim dr As DataRow
        Dim flg As Boolean = False

        For Each dr In dtRutad.Rows
            flg = (dr("tipo_0").ToString = "ENT")
            If flg Then Exit For
        Next
        If Not flg Then
            MessageBox.Show("Esta ruta no tiene entregas de recargas", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim rpt As New ReportDocument
        Dim f As frmCrystal

        Try
            rpt.Load(RPTX3 & "XPALLET4.rpt")
            rpt.SetParameterValue("RUTA", CInt(txtRuta.Text))

            f = New frmCrystal(rpt)
            f.MdiParent = Me.MdiParent
            f.Text = "Impresión Hoja Preparación: " & txtRuta.Text
            f.Show()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub
    Private Sub tooTarea_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tooTarea.Click
        Dim f As New frmTarea
        f.ShowDialog(Me)

        If f.DialogResult = Windows.Forms.DialogResult.OK Then
            Dim dr As DataRow

            dr = dtRutad.NewRow

            If txtRuta.Text.Trim = "" Then
                dr("ruta_0") = 0
            Else
                dr("ruta_0") = CType(txtRuta.Text, Integer)
            End If

            dr("orden_0") = ProximoOrden()
            dr("tipo_0") = "---"
            dr("vcrnum_0") = TareaSecuencia()
            dr("suc_0") = " "
            dr("direccion_0") = f.txtDireccion.Text
            dr("localidad_0") = f.txtLocalidad.Text
            dr("cliente_0") = " "
            dr("nombre_0") = f.txtNombre.Text
            dr("equipos_0") = 0 'IIf(txtRuta.Text.Trim = "", 0, 1)
            dr("equipos_2") = 0 'IIf(txtRuta.Text.Trim = "", 0, 1)
            dr("prestamos_0") = 0
            dr("prestamos_2") = 0
            dr("prestamos_0") = 0
            dr("retencion_0") = 0
            dr("retencion_1") = 0
            dr("install_0") = 0
            dr("rechazos_0") = 0
            dr("rechazos_1") = 0 'Doc.Rechazos
            dr("cobranza_0") = False
            dr("varios_0") = False
            dr("prioridad_0") = f.chkPrioridad.Checked
            dr("hora_0") = f.txtHora.Text
            dr("kilos_0") = 0
            dr("estado_0") = 0
            dr("noconform_0") = 0
            dtRutad.Rows.Add(dr)

        End If

        f.Dispose() : f = Nothing
    End Sub
    Private Sub btnCamioneta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCamioneta.Click
        IntervencionesEnCarrito(1)
    End Sub
    Private Sub btnCourier_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCourier.Click
        IntervencionesEnCarrito(2)
    End Sub
    Private Sub IntervencionesEnCarrito(ByVal Tipo As Integer)
        Dim c As New Carrito(cn)
        col3Itn.DataPropertyName = "num_0"
        col3Cant.DataPropertyName = "cant"
        col3Fecha.DataPropertyName = "xcardat_0"
        c.ObtenerIntervenciones(CInt(cboZonas.SelectedValue), dtpFecha.Value, Tipo, dgvZonas)
    End Sub
    Private Sub btnZonaSelec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnZonaSelec.Click
        Dim i As Integer
        Dim dr As DataRow
        Dim txt As String

        For i = 0 To dgvZonas.SelectedRows.Count - 1
            dr = CType(dgvZonas.SelectedRows(i).DataBoundItem, DataRowView).Row
            txt = dr("num_0").ToString
            AgregarIntervencion(txt)
        Next

    End Sub
    Private Sub dgvZonas_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvZonas.CellFormatting
        On Error Resume Next

        Dim o As DataGridView = CType(sender, DataGridView)
        Dim r As DataGridViewRow = o.Rows(e.RowIndex)
        Dim c As DataGridViewCell
        Dim col As System.Drawing.Color

        If IsDBNull(r.Cells("col3Fecha").Value) Then
            col = Drawing.Color.White

        ElseIf CDate(r.Cells("col3Fecha").Value) < dtpFecha.Value Then
            col = Drawing.Color.LightPink

        Else
            col = Drawing.Color.White

        End If

        For Each c In r.Cells
            c.Style.BackColor = col
        Next
    End Sub
    Private Sub ToolGenEtiqu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolGenEtiqu.Click
        If Grilla.Rows.Count > 0 Then
            Dim colum As Integer = 0
            If MessageBox.Show("¿Confirma la impresión de las etiquetas?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> Windows.Forms.DialogResult.Yes Then
                Exit Sub
            End If
            If MessageBox.Show("La etiqueta es de una (1) columna?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                colum = 1
            Else
                colum = 2
            End If
            Dim itn As New Intervencion(cn)

            For Each c As DataGridViewRow In Grilla.Rows
                Dim tipo As String = c.Cells(8).Value.ToString
                If tipo <> "RET" Then Continue For
                Dim int As String = c.Cells(9).Value.ToString
                If itn.Abrir(int) Then
                    itn.EtiquetasEntrega("artin.txt", colum)
                End If
            Next

        Else
            MessageBox.Show("No hay filas seleccionadas", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub
    Private Sub chkMicrocentro_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkMicrocentro.CheckedChanged
        If dtRutac.Rows.Count = 0 Or BloqueoModificacion Then Exit Sub

        With dtRutac.Rows(0)
            .BeginEdit()
            .Item("micro_0") = IIf(chkMicrocentro.Checked, 2, 1)

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

    '----------------------
    Private Sub btnEnviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnviar.Click
        Dim itn As New Intervencion(cn)
        Dim fecha As Date
        Dim ControlSigex As New Sigex.Control
        Dim ControlesSigex As New Sigex.ControlesCollection
        Dim SectoresSigex As New Sigex.Sectores2Collection
        Dim ClientesSigex As New Sigex.ClientesCollection
        Dim ClienteSigex As Sigex.Cliente
        Dim SucursalSigex As Sigex.Sucursal
        Dim ContratosSigex As New Sigex.ContratosCollection
        Dim ContratoSigex As New Sigex.Contrato

        btnEnviar.Enabled = False

        'Obtengo todos los clientes cargados en Sigex
        ClientesSigex.AbrirTodos()

        For Each dr As DataRow In dtRutad.Rows
            fecha = dtpFecha.Value

            'Se intenta abrir la intervencion
            If Not itn.Abrir(dr("vcrnum_0").ToString) Then Continue For
            'La intervencion debe tener articulo 652001 o 652002
            If Not itn.ExisteRetira("652001") And Not itn.ExisteRetira("652002") Then Continue For

            'Obtengo el cliente en Sigex
            ClienteSigex = ClientesSigex.BuscarPorCodigoAdonix(itn.Cliente.Codigo)
            'Si no encontré el cliente, creo uno nuevo
            If ClienteSigex Is Nothing Then
                ClienteSigex = New Sigex.Cliente
                ClienteSigex.Nuevo(itn.Cliente.Codigo, itn.Cliente.Nombre)
                ClienteSigex.Grabar()
            End If
            'Busco si existe la sucursal en Sigex
            SucursalSigex = ClienteSigex.Sucursales.BuscarPorCodigoAdonix(itn.SucursalCodigo)
            'Creo la sucursal si no existe
            If SucursalSigex Is Nothing Then
                SucursalSigex = New Sigex.Sucursal
                SucursalSigex.Nueva(ClienteSigex, itn.SucursalCodigo, itn.SucursalCalle)
                SucursalSigex.Grabar()
            End If

            'Cargo Extintores en Adonix
            Dim Parques As ParqueCollection
            Parques = itn.Sucursal.Parque

            'Cargo Extintores en Sigex
            Dim EquiposSigex As Sigex.EquipoCollection
            EquiposSigex = SucursalSigex.Equipos

            Dim Capacidades As New Sigex.Capacidades
            Dim Agentes As New Sigex.Agentes
            Dim EquipoSigex As Sigex.Equipo

            'Recorro todos los equipos en Adonix
            For Each Mac As Parque In Parques
                If Mac.Articulo.Familia(3) <> "301" Then Continue For

                'Busco el equipo en Sigex
                EquipoSigex = EquiposSigex.BuscarPorCodigoAdonix(Mac.Serie)

                'Creo un nuevo equipo si no existe en Sigex
                If EquipoSigex Is Nothing Then
                    EquipoSigex = New Sigex.Equipo
                    EquipoSigex.Nuevo()
                    'Agrego el nuevo equipo a la coleccion
                    EquiposSigex.Add(EquipoSigex)
                End If

                With EquipoSigex
                    .Cilindro = Mac.Cilindro
                    .CodigoAdonix = Mac.Serie
                    .CodigoCliente = ClienteSigex.id
                    .CodigoSucursal = SucursalSigex.id
                    .Fabricacion = Mac.FabricacionLargo
                    .UltimaPh = Mac.VtoPH.AddDays(Mac.FrecuenciaPH)
                    .VencimientoVidaUtil = New Date(Mac.FinVidaUtil, 1, 1)
                    .VencimientoPH = Mac.VtoPH
                    .VencimientoCarga = Mac.VtoCarga
                    .Agente = Agentes.AdonixToSigex(Mac.Articulo.Familia(3))
                    .Capacidad = Capacidades.AdonixToSigex(Mac.Articulo.Familia(2))
                    .Grabar()
                End With
            Next
            '
            '
            '
            Dim SectoresAdonix As New Sectores2(cn) 'Sectores en Adonix

            'Abro sectores en Adonix
            SectoresAdonix.Abrir(itn.Cliente.Codigo, itn.SucursalCodigo)
            SectoresAdonix.EliminarSectoresSinPuestos()

            'Creo un sector en blanco
            If SectoresAdonix.Count = 0 Then
                Dim s As New Sector2(cn)
                s.Nuevo(itn.Cliente.Codigo, itn.SucursalCodigo)
                s.Numero = "X"
                s.Nombre = "sin nombre"
                s.Grabar()
                'Creo un puesto en blanco
                Dim p As New Puesto2(cn)
                p.Nuevo(s.Id, "X", "sin ubicacion", 1)
                p.Grabar()

                'Vuelvo a cargar los sectores
                SectoresAdonix.Abrir(itn.Cliente.Codigo, itn.SucursalCodigo)
            End If

            'Abro sectores en Sigex
            SectoresSigex.AbrirSectores(ClienteSigex.id, SucursalSigex.id)

            'Recorro todos los sectores en Adonix y luego los puestos
            For Each SectorAdonix As Sector2 In SectoresAdonix
                'Recupero todos los puestos en el sector Adonix
                Dim PuestosAdonix As Puestos2Collection
                PuestosAdonix = SectorAdonix.Puestos

                'Busco el sector en Sigex
                Dim SectorSigex As Sigex.Sector
                SectorSigex = SectoresSigex.BuscarSector(SectorAdonix.Id)
                If SectorSigex Is Nothing Then
                    SectorSigex = New Sigex.Sector
                    SectorSigex.Nuevo(SectorAdonix.Id.ToString, SectorAdonix.Nombre, ClienteSigex.id, SucursalSigex.id)
                    SectorSigex.Grabar()

                    SectoresSigex.Add(SectorSigex)
                End If

                'Recupero todos los puestos en el sector Sigex
                Dim PuestosSigex As Sigex.PuestosCollection
                PuestosSigex = SectorSigex.Puestos

                '1) Buscar Puesto Sector solo para cliente consorcios
                Dim PuestoSectorSigex As New Sigex.PuestoSector
                PuestoSectorSigex = PuestosSigex.BuscarPuestoSector(SectorAdonix.Id)

                If SectorAdonix.Cliente.Familia2 = "10" Then
                    If PuestoSectorSigex Is Nothing Then
                        PuestoSectorSigex = New Sigex.PuestoSector
                        PuestoSectorSigex.Nuevo(SectorAdonix.Numero, SectorAdonix.Nombre, SectorSigex.Id)
                        PuestoSectorSigex.Adonix = SectorAdonix.Id.ToString
                        PuestoSectorSigex.FotosRequeridas = False
                        PuestoSectorSigex.Grabar()
                    End If
                Else
                    If PuestoSectorSigex IsNot Nothing Then
                        PuestoSectorSigex.Borrar()
                        PuestoSectorSigex.Grabar()
                    End If
                End If

                'Recorro los puestos (Extintor y Hidrantes) dentro del sector
                For Each PuestoAdonix As Clases.Puesto2 In SectorAdonix.Puestos

                    Select Case PuestoAdonix.Tipo
                        Case 1 'Extintor
                            Dim p As Sigex.PuestoExtintor

                            p = PuestosSigex.BuscarPuestoExtintor(PuestoAdonix.id)

                            If p Is Nothing Then

                                p = New Sigex.PuestoExtintor
                                p.Nuevo(PuestoAdonix.NroPuesto, PuestoAdonix.Ubicacion, SectorSigex.Id)
                                p.Adonix = PuestoAdonix.id.ToString
                                p.Agente = Agentes.AdonixToSigex(PuestoAdonix.Agente)
                                p.Capacidad = Capacidades.AdonixToSigex(PuestoAdonix.Capacidad)

                                'Obtengo el id del equipo en el puesto
                                EquipoSigex = EquiposSigex.BuscarPorCodigoAdonix(PuestoAdonix.EquipoId)
                                If EquipoSigex Is Nothing Then
                                    p.idEquipo = 0
                                Else
                                    p.idEquipo = EquipoSigex.Id
                                End If

                                p.FotosRequeridas = True

                                p.Grabar()
                            End If

                        Case 2 'Hidrante

                            Dim p As New Sigex.PuestoHidrante

                            'Buscar Puesto Hidrantes
                            p = PuestosSigex.BuscarPuestoHidrante(PuestoAdonix.id)
                            If p Is Nothing Then
                                p = New Sigex.PuestoHidrante
                                p.Nuevo(PuestoAdonix.NroPuesto, PuestoAdonix.Ubicacion, SectorSigex.Id)
                                p.Adonix = PuestoAdonix.id.ToString
                                p.FotosRequeridas = True
                                p.Grabar()
                            End If

                    End Select

                Next
            Next

            'Busco si existe control para la intervencion
            If ControlesSigex.BuscarPorIntervencion(itn.Numero) Then
                ControlSigex = ControlesSigex.Item(0)

            Else
                'Busco si existe contrato activo
                ContratosSigex.BuscarPorClienteSucursal(ClienteSigex.id, SucursalSigex.id, True)

                If ContratosSigex.Count > 0 Then
                    ContratoSigex = ContratosSigex.Item(0)

                Else
                    ContratoSigex.Nuevo(ClienteSigex, SucursalSigex)
                    ContratoSigex.Grabar()
                End If

                'Cargo controles del contrato
                ControlesSigex = ContratoSigex.Controles

                'Creo el control para la intervencion
                ControlSigex = ControlesSigex.NuevoControl(ContratoSigex.Id, dtpFecha.Value)

            End If

            'Consulto si existe control para la intervencion
            ControlSigex.FechaProgramacion = dtpFecha.Value
            ControlSigex.Relevador = CInt(cboCelulares.SelectedValue)
            ControlSigex.Intervencion = itn.Numero
            ControlSigex.Grabar()

            'Crear todas las inspecciones para el control
            Dim InspeccionesSigex As New Sigex.InspeccionesCollection

            InspeccionesSigex.Abrir(ControlSigex.id)
            InspeccionesSigex.CrearInspecciones(SectoresSigex)

        Next

        MessageBox.Show("Listo")
        btnEnviar.Enabled = True

    End Sub
    Public Sub CargarComboCelulares()
        Try
            'Carga combo con los usuarios de Sigex
            Dim u As New Sigex.UsuariosCollection

            With cboCelulares
                .ValueMember = "id"
                .DisplayMember = "nombreCompleto"
                .DataSource = u.dt
            End With

        Catch ex As Exception

        End Try

    End Sub
    '----------------------

End Class