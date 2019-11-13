Imports Sigex
Imports Clases
Imports System.Collections
Imports System.Data.OracleClient
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO

Public Class frmInspecciones
    Private ControlSigex As New Sigex.Control
    Private ControlAdonix As New Clases.Control(cn)
    Private ctrles As New Sigex.ControlesCollection
    Private InspeccionesSigex As New Sigex.InspeccionesCollection
    Private InspeccionesAdonix As Clases.InspeccionesCollection
    Private Agentes As New Sigex.Agentes
    Private Capacidades As New Sigex.Capacidades

    Structure Estados
        Private _id As Integer
        Private _desc As String

        Public Sub New(ByVal id As Integer, ByVal desc As String)
            Me._id = id
            Me._desc = desc
        End Sub
        Public ReadOnly Property id() As Integer
            Get
                Return Me._id
            End Get
        End Property
        Public ReadOnly Property desc() As String
            Get
                Return Me._desc
            End Get
        End Property
    End Structure
    Private Sub frmInspecciones_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AddHandler dgvSigex.RowPostPaint, AddressOf NumeracionGrillas
        AddHandler dgvAdonix.RowPostPaint, AddressOf NumeracionGrillas

        CargarControlesPendientes()
    End Sub
    Private Sub btnRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefrescar.Click
        CargarControlesPendientes()
    End Sub
    Private Sub Transferir(ByVal dr As DataRow)
        'Abro el control periodico en Sigex
        ControlSigex.Abrir(CInt(dr("id")))

        'Abro el control periodico en Adonix
        If Not ControlAdonix.Abrir(ControlSigex.Intervencion) Then
            With ControlAdonix
                .Nuevo()
                .id = ControlSigex.Intervencion
                .Fecha = ControlSigex.FechaProgramacion
                .Cliente = ControlSigex.Contrato.ContratoCliente
                .Sucursal = ControlSigex.Contrato.ContratoSucursal
                .Estado = 2 'Fuerzo estado finalizado
                .Grabar()
            End With
        End If

        'Migrar equipos
        MigrarEquipos(ControlSigex.Contrato.ClienteNumero, ControlSigex.Contrato.SucursalId)

        'Migrar sectores
        MigrarSectoresPuestos(ControlSigex.Contrato.ClienteNumero, ControlSigex.Contrato.SucursalId)

        'Cargo las inspecciones del control en Sigex
        InspeccionesSigex = ControlSigex.Inspecciones

        'Cargo las inspecciones que tiene el control de Adonix
        InspeccionesAdonix = ControlAdonix.Inspecciones

        For Each i As Sigex.Inspeccion In InspeccionesSigex
            If i.Estado = 0 Then Continue For
            ProcesarInspeccion(i)
        Next

        'Marco el control como transferido
        If ControlSigex.Estado = 1 Then
            ControlSigex.Sincronizacion = True
            ControlSigex.Grabar()
        End If

        ControlAdonix.Estado = 2
        ControlAdonix.Grabar()

        EnviarMail(ControlAdonix)

    End Sub
    Private Sub EnviarMail(ByVal Control As Clases.Control)
        'Se envia mail en caso que el control tenga alguna novedad par solucionar

        'Recorro todas las inspecciones
        Dim Inspecciones As Clases.InspeccionesCollection
        Dim Inspeccion As Clases.Inspeccion
        'Indica si se debe enviar mail con el control
        Dim EnviarMail As Boolean
        'Nombre del archivo del reporte a generar
        Dim Archivo As String

        Inspecciones = Control.Inspecciones

        For Each Inspeccion In Inspecciones
            If Inspeccion.EquipoDespresurizado Then EnviarMail = True
            If Inspeccion.EquipoUsado Then EnviarMail = True
            If Inspeccion.Vencido Then EnviarMail = True
            If EnviarMail Then Exit For
        Next

        If EnviarMail Then
            Dim rpt As New ReportDocument

            Archivo = Control.id & ".pdf"

            Try
                rpt.Load(RPTX3 & "XINSPECC.rpt")
                rpt.SetParameterValue("itn", Control.id)
                rpt.SetParameterValue("X3DOS", X3DOS)
                rpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Archivo)

                Dim oMail As New CorreoElectronico

                With oMail
                    .Remitente("info@matafuegosgeorgia.com")
                    .Asunto = "Control Nro. " & Control.id
                    .Cuerpo = "Verificar acciones a tomar"
                    .EsHtml = False
                    .AdjuntarArchivo(Archivo)
                    .AgregarDestinatarioArchivo("inspecciones.txt", 0)
                    .Enviar()
                End With
                oMail.Dispose()

                File.Delete(Archivo)
            Catch ex As Exception
            End Try

        End If

    End Sub
    Private Sub Eliminar(ByVal dr As DataRow)
        Try
            dr.Delete()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub MigrarSectoresPuestos(ByVal ClienteId As Integer, ByVal SucursalId As Integer)
        Dim cli As New Sigex.Cliente
        Dim Suc As New Sigex.Sucursal
        Dim bpc As New Clases.Cliente(cn)
        Dim bpa As Clases.Sucursal
        Dim s1 As New Sigex.SectoresCollection
        Dim s2 As New Clases.Sector2(cn)
        Dim p1 As Sigex.PuestosCollection
        Dim p2 As New Clases.Puesto2(cn)

        cli.Abrir(ClienteId)
        Suc.Abrir(SucursalId)

        bpc.Abrir(cli.CodigoAdonix)
        bpa = bpc.Sucursal(Suc.Codigo)

        s1.AbrirSectores(cli.id, Suc.id)

        For Each s As Sigex.Sector In s1
            'Si el sector no tiene codigo es porque no está en adonix (es nuevo)
            If s.Adonix = 0 Then
                s2.Nuevo(bpc.Codigo, bpa.Sucursal)
            Else
                s2.Abrir(s.Adonix)
            End If
            s2.Nombre = s.Nombre
            s2.Numero = s.Numero
            s2.Grabar()
            If s.Adonix = 0 Then
                s.Adonix = s2.Id
                s.Grabar()
            End If

            'Se obtienen puestos en el sector
            p1 = s.Puestos

            'Se recorren los puestos sigex
            For Each p As Sigex.Puesto In p1
                'El sector no figura en Adonix porque es nuevo
                If p.Adonix = "" Then
                    p2.Nuevo(s2.Id, p.Nro, p.Ubicacion, p.TipoId)
                Else
                    p2.Abrir(CInt(p.Adonix))
                End If

                If p.Tipo = Sigex.Puesto.PUESTO_EXTINTOR Then
                    Dim pe As Sigex.PuestoExtintor
                    pe = p.PuestoExtintor

                    p2.Agente = Agentes.SigexToAdonix(pe.Agente)
                    p2.Capacidad = Capacidades.SigexToAdonix(pe.Capacidad)

                    Dim e As Sigex.Equipo
                    e = pe.Equipo
                    If e IsNot Nothing Then
                        p2.EquipoId = e.CodigoAdonix
                    End If

                End If

                p2.NroPuesto = p.Nro
                p2.Ubicacion = p.Ubicacion
                p2.Grabar()

                If p.Adonix = "" Then
                    p.Adonix = p2.id.ToString
                    p.Grabar()
                End If

            Next


        Next

    End Sub
    Private Sub MigrarEquipos(ByVal ClienteId As Integer, ByVal SucursalId As Integer)
        Dim e1 As New Sigex.EquipoCollection
        Dim mac As New Parque(cn)
        Dim cli As New Sigex.Cliente
        Dim Suc As New Sigex.Sucursal
        Dim bpc As New Clases.Cliente(cn)
        Dim bpa As Clases.Sucursal


        cli.Abrir(ClienteId)
        Suc.Abrir(SucursalId)

        bpc.Abrir(cli.CodigoAdonix)
        bpa = bpc.Sucursal(Suc.Codigo)

        e1.AbrirParqueCliente(ClienteId, SucursalId)

        For Each e As Sigex.Equipo In e1
            If e.CodigoAdonix = "" Then
                Dim itm As New Articulo(cn)
                Dim Agente As String
                Dim Capacidad As String

                Agente = Agentes.SigexToAdonix(e.Agente)
                Capacidad = Capacidades.SigexToAdonix(e.Capacidad)

                mac.Nuevo(bpc.Codigo, bpa.Sucursal)
                mac.ArticuloCodigo = itm.ArticuloParaParque(Agente, Capacidad)
                mac.Cilindro = e.Cilindro
                mac.VtoCarga = e.VencimientoCarga
                mac.VtoPH = e.VencimientoPH
                mac.FabricacionLargo = e.Fabricacion
                mac.Observaciones = "Creado desde App Sigex"
                mac.Grabar()

                e.CodigoAdonix = mac.Serie
                e.Grabar()
            End If
        Next

    End Sub
    Private Sub ProcesarInspeccion(ByVal i As Sigex.Inspeccion)
        Dim ia As Clases.Inspeccion
        Dim pa As Puesto2 = Nothing
        Dim es As Sigex.Equipo
        Dim mac As Parque

        'Busco la inspeccion en adonix
        ia = InspeccionesAdonix.Buscar(i.id)
        If ia Is Nothing Then
            ia = New Clases.Inspeccion(cn)
            ia.Nuevo()
        End If

        ia.id = i.id
        ia.Intervencion = ControlSigex.Intervencion 'Numero de Intervencion

        If i.Puesto.TipoId = 0 Then 'Puesto sector
            ia.PuestoId = i.Puesto.Sector.Adonix
            ia.Sector = ia.PuestoId

        Else 'Puesto extintor o hidrante
            pa = New Puesto2(cn)
            pa.Abrir(CInt(i.Puesto.Adonix))

            ia.PuestoId = pa.id
            ia.Sector = pa.SectorId

        End If

        ia.Nro = i.Puesto.Nro
        ia.Ubicacion = i.Puesto.Ubicacion
        ia.Nombre = i.Puesto.Sector.Nombre
        ia.Observaciones = i.Observaciones

        If TypeOf i Is InspeccionSector Then
            Dim ii As InspeccionSector
            ii = CType(i, InspeccionSector)

            ia.Tipo = 1 '1=Puesto sector

            ia.Balizas = ii.Baldes
            ia.Gabinetes = ii.Gabinetes
            ia.CartelSalida = ii.CartelSalida
            ia.CartelSalidaEmergencia = ii.CartelSalidaEmergencia
            ia.CartelEscaleras = ii.CartelEscaleras
            ia.CartelRiesgoElectrico = ii.CartelRiesgoElectrico
            ia.CartelAscensor = ii.CartelAscensor
            ia.CartelAltura = ii.CartelAltura
            ia.Baldes = ii.Baldes
            ia.Martillos = ii.Martillos
            ia.Luces = ii.Luces
            ia.Cinta = ii.Cinta

        ElseIf TypeOf i Is InspeccionExtintor Then
            Dim Agente As New Agentes
            Dim Capacidad As New Capacidades
            Dim ii As InspeccionExtintor
            ii = CType(i, InspeccionExtintor)

            ia.Tipo = 2 '2=Puesto Extintor
            ia.Vencido = ii.Vencido
            ia.Ausente = ii.Ausente
            ia.Obstruido = ii.Obstruido
            ia.CarroDefectuoso = ii.CarroDefectuoso
            ia.EquipoUsado = ii.EquipoUsado
            ia.EquipoDespintado = ii.EquipoDespintado
            ia.EquipoDespresurizado = ii.EquipoDespresurizado
            ia.AlturaIncorrecta = ii.AlturaIncorrecta
            ia.FaltaSenalizacionAltura = ii.FaltaSenalizacionAltura
            ia.FaltaSenalizacionBaliza = ii.FaltaSenalizacionBaliza
            ia.Tarjeta = ii.FaltaTarjeta
            ia.FaltaPrecinto = ii.FaltaPrecinto
            ia.SoporteDefectuoso = ii.SoporteDefectuoso
            ia.MedioRuptura = ii.MedioRuptura
            ia.MangueraRota = ii.MangueraRota
            ia.Otro = ii.Otro

            'Actualizacion de equipos
            es = ii.Equipo

            If es Is Nothing Then
                pa.EquipoId = " "

                ia.Equipo = " "
                ia.Agente = " "
                ia.Capacidad = " "
                ia.Cilindro = " "
                ia.Vto = #12/31/1599#

            Else
                ia.Equipo = es.CodigoAdonix
                ia.Agente = Agente.SigexToAdonix(es.Agente)
                ia.Capacidad = Capacidad.SigexToAdonix(es.Capacidad)
                ia.Cilindro = ii.Equipo.Cilindro
                ia.Vto = es.VencimientoCarga

                'Si no tiene codigo adonix es porque se creo desde la app
                If es.CodigoAdonix = "" Then
                    mac = New Parque(cn)
                    mac.Nuevo(ControlAdonix.Cliente, ControlAdonix.Sucursal)
                    mac.Cilindro = es.Cilindro
                    mac.FabricacionLargo = es.Fabricacion
                    mac.setTipoExtintor(Agentes.SigexToAdonix(es.Agente), Capacidades.SigexToAdonix(es.Capacidad))
                    mac.VtoCarga = es.VencimientoCarga
                    mac.VtoPH = es.VencimientoPH
                    mac.Observaciones = "Creado en Sigex - " & Today.ToString("dd/MM/yy")
                    mac.Grabar()

                    es.CodigoAdonix = mac.Serie
                    es.Grabar()

                Else
                    pa.EquipoId = es.CodigoAdonix

                End If
            End If

            pa.Grabar()

        ElseIf TypeOf i Is InspeccionHidrante Then
            Dim ii As InspeccionHidrante
            ii = CType(i, InspeccionHidrante)

            ia.Tipo = 3 '3=Puesto Hidrante

            ia.Valvula = ii.Valvula
            ia.Pico = ii.Pico
            ia.Lanza = ii.Lanza
            ia.Vidrio = ii.Vidrio
            ia.Llave = ii.Llave
            ia.Tarjeta = ii.Tarjeta
        End If

        ia.Grabar()

        'Transferencia de fotos
        TransferirFotos(i)

    End Sub
    Private Sub TransferirFotos(ByVal i As Sigex.Inspeccion)
        Dim f As Sigex.Foto
        Dim af As New Clases.Foto(cn)

        For Each f In i.Fotos
            af.Nuevo(f.id)
            af.Descripcion = f.descripcion
            af.Foto = f.Foto
            af.Inspeccion = f.Inspeccion
            af.Grabar()
        Next

    End Sub
    Private Sub CargarControlesPendientes()
        'Carga los contoles pendientes de migracion Sigex->Adonix
        Dim dt As DataTable
        Dim dv As DataGridView = dgvSigex

        If dv.DataSource Is Nothing Then
            dt = New DataTable
        Else
            dt = CType(dv.DataSource, DataTable)

        End If

        ctrles.ControlesPendientes(dt)

        If dv.DataSource Is Nothing Then
            col1Id.DataPropertyName = "id"
            col1Intervencion.DataPropertyName = "observaciones"
            col1Fecha.DataPropertyName = "fechaProgramacion"
            col1Relevador.DataPropertyName = "nombre"

            Dim x As New ArrayList

            x.Add(New Estados(0, "Pendiente"))
            x.Add(New Estados(1, "Finalizado"))
            x.Add(New Estados(2, "En curso"))

            col1Estado.DataPropertyName = "estado"
            col1Estado.DataSource = x
            col1Estado.DisplayMember = "desc"
            col1Estado.ValueMember = "id"

            col1Cliente.DataPropertyName = "cliente"

            dv.DataSource = dt

            CorregirEstadoControles(dt)

        End If

    End Sub
    Private Sub CorregirEstadoControles(ByVal dt As DataTable)
        Dim Inspeccion As Sigex.Inspeccion
        Dim Inspecciones As Sigex.InspeccionesCollection

        For Each dr As DataRow In dt.Rows
            'Salto si ya está Finalizado
            If CInt(dr("estado")) = 1 Then Continue For

            'Abro el Control
            ControlSigex.Abrir(CInt(dr("id")))
            Inspecciones = ControlSigex.Inspecciones

            Dim i As Integer = 0

            For Each Inspeccion In Inspecciones
                If Inspeccion.Estado = 1 Then i += 1
            Next

            If i = 0 Then Continue For

            If i = Inspecciones.Count Then
                i = 1 'Finalizado
            Else
                i = 2 'En curso
            End If

            'Actualizar aqui estado control
            If i > 0 Then
                dr.BeginEdit()
                dr("estado") = i
                dr.EndEdit()

                Select Case i
                    Case 1
                        ControlSigex.ForzarFinalizado()
                    Case 2
                        ControlSigex.ForzarEnCurso()
                End Select
                ControlSigex.Grabar()
            End If
        Next

        dt.AcceptChanges()

    End Sub
    Private Sub mnuTransferir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTransferir.Click
        Dim dr As DataRow

        If dgvSigex.SelectedRows.Count <> 1 Then Exit Sub 'salgo si no hay fila seleccionada

        dr = CType(dgvSigex.SelectedRows(0).DataBoundItem, DataRowView).Row

        If CInt(dr("estado")) <> 1 Then Exit Sub

        Transferir(dr)

        CargarControlesPendientes()

    End Sub
    Private Sub mnu_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mnu.Opening
        Dim dr As DataRow

        If dgvSigex.CurrentRow Is Nothing Then Exit Sub 'salgo si no hay fila seleccionada

        dr = CType(dgvSigex.CurrentRow.DataBoundItem, DataRowView).Row

        mnuTransferir.Enabled = (CInt(dr("estado")) = 1)
        mnuForzarFinalizado.Enabled = (CInt(dr("estado")) <> 1)

    End Sub
    Private Sub dgvAdonix_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvAdonix.DoubleClick
        Dim f As frmEditarInspeccion
        Dim dr As DataRow

        If dgvAdonix.CurrentRow Is Nothing Then Exit Sub 'salgo si no hay fila seleccionada

        dr = CType(dgvAdonix.CurrentRow.DataBoundItem, DataRowView).Row
        ControlAdonix.Abrir(dr("itn_0").ToString)
        f = New frmEditarInspeccion(ControlAdonix)
        f.ShowInTaskbar = False
        f.ShowDialog(Me)

        If f.DialogResult = Windows.Forms.DialogResult.OK Then
            CargarControlesPendientes()
        End If
    End Sub
    Private Sub mnuForzarFinalizado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuForzarFinalizado.Click
        Dim dr As DataRow

        If dgvSigex.CurrentRow Is Nothing Then Exit Sub 'salgo si no hay fila seleccionada

        For Each d As DataGridViewRow In dgvSigex.SelectedRows
            dr = CType(d.DataBoundItem, DataRowView).Row

            dr.BeginEdit()
            dr("estado") = 1
            dr.EndEdit()

            Dim c As New Sigex.Control
            c.Abrir(CInt(dr("id")))
            c.ForzarFinalizado()
            c.Grabar()

        Next

        CargarControlesPendientes()

    End Sub
    Private Sub dgvSigex_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSigex.CellDoubleClick
        Dim i As Integer
        Dim Id As Integer


        i = e.RowIndex

        Id = CInt(dgvSigex.Rows(i).Cells("col1Id").Value)

        Dim f As New frmInspeccion(Id)
        f.ShowDialog()

    End Sub
    Private Sub dgvSigex_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvSigex.CellFormatting
        On Error Resume Next

        Dim o As DataGridView = CType(sender, DataGridView)
        Dim r As DataGridViewRow = o.Rows(e.RowIndex)
        Dim c As DataGridViewCell
        Dim col As System.Drawing.Color

        Select Case CInt(r.Cells("col1Estado").Value)
            Case 0
                col = Drawing.Color.LightPink
            Case 1
                col = Drawing.Color.LightGreen
            Case 2
                col = Drawing.Color.LightGoldenrodYellow
        End Select

        For Each c In r.Cells
            c.Style.BackColor = col
        Next
    End Sub
    Private Sub btnTransferirTodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTransferirFinalizados.Click
        Dim dt As DataTable
        Dim dr As DataRow

        CType(sender, Button).Enabled = False

        dt = CType(dgvSigex.DataSource, DataTable)

        For Each dr In dt.Rows
            If CInt(dr("estado")) <> 1 Then Continue For
            Transferir(dr)
        Next

        CargarControlesPendientes()

        CType(sender, Button).Enabled = True

    End Sub
    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Dim n As Integer
        Dim s As String

        n = dgvSigex.SelectedRows.Count

        s = "¿Confirma la eliminacion de "
        s &= n.ToString
        s &= " inspecciones?"

        If MessageBox.Show(s, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If

        For Each r As DataGridViewRow In dgvSigex.SelectedRows
            Try

                With CType(r.DataBoundItem, DataRowView).Row
                    If .RowState = DataRowState.Deleted Then Continue For
                    .Delete()
                End With

            Catch ex As Exception

            End Try
        Next

        ctrles.UpdateTable(CType(dgvSigex.DataSource, DataTable))

        CargarControlesPendientes()

    End Sub

End Class