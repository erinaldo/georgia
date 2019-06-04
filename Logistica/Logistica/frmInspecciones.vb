Imports Sigex
Imports Clases
Imports System.Collections

Public Class frmInspecciones
    Private ControlSigex As New Sigex.Control
    Private ControlAdonix As New Clases.Control(cn)
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
        CargarControlesPendientes()
    End Sub
    Private Sub btnRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefrescar.Click
        CargarControlesPendientes()
    End Sub
    Private Sub btnTransferir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTransferir.Click
        If dgvSigex.SelectedRows.Count = 0 Then
            MessageBox.Show("No hay filas seleccionadas para transferir", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        Transferir()
    End Sub
    Private Sub CargarControlesPendientes()
        'Carga los contoles pendientes de migracion Sigex->Adonix
        Dim dt As DataTable
        Dim ctrles As New Sigex.ControlesCollection

        If dgvSigex.DataSource Is Nothing Then
            dt = New DataTable
        Else
            dt = CType(dgvSigex.DataSource, DataTable)

        End If

        ctrles.ControlesPendientes(dt)

        If dgvSigex.DataSource Is Nothing Then
            colId.DataPropertyName = "id"
            colIntervencion.DataPropertyName = "observaciones"
            colFecha.DataPropertyName = "fechaProgramacion"
            colRelevador.DataPropertyName = "nombre"

            Dim x As New ArrayList

            x.Add(New Estados(0, "Pendiente"))
            x.Add(New Estados(1, "Finalizado"))
            x.Add(New Estados(2, "En curso"))

            colEstado.DataPropertyName = "estado"
            colEstado.DataSource = x
            colEstado.DisplayMember = "desc"
            colEstado.ValueMember = "id"

            colCliente.DataPropertyName = "cliente"

            dgvSigex.DataSource = dt

        End If

    End Sub
    Private Sub Transferir()
        Dim dt As DataTable

        btnTransferir.Enabled = False

        'Salgo si la grilla no contiene controles
        If dgvSigex.DataSource Is Nothing Then Exit Sub

        'Cargo la tabla con los controles
        dt = CType(dgvSigex.DataSource, DataTable)

        'Recorro todos los controles de la grilla
        For Each dr As DataRow In dt.Rows
            'Proceso unicamente los controles que no están pendientes
            '0 = Pendiente
            '1 = Finalizado
            '2 = En curso
            If CInt(dr("estado")) > 0 Then
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
                        .Grabar()
                    End With
                End If

                'Cargo las inspecciones del control en Sigex
                InspeccionesSigex = ControlSigex.Inspecciones

                'Cargo las inspecciones que tiene el control de Adonix
                InspeccionesAdonix = ControlAdonix.Inspecciones

                ' *
                ' RECORRO TODAS LAS INSPECCIONES EN SIGEX
                ' *
                Dim UltimoSector As Integer = 0

                For Each i As Sigex.Inspeccion In InspeccionesSigex
                    If i.Estado = 0 Then Continue For

                    If UltimoSector <> i.Puesto.Sector.Id Then
                        UltimoSector = i.Puesto.Sector.Id
                        ProcesarSector(i)
                    End If

                    ProcesarPuesto(i)
                    ProcesarInspeccion(i)
                Next

                'Marco el control como transferido
                If ControlSigex.Estado = 1 Then
                    ControlSigex.Sincronizacion = True
                    ControlSigex.Grabar()
                End If

            End If
        Next

        CargarControlesPendientes()
        btnTransferir.Enabled = True

    End Sub
    Public Sub ProcesarSector(ByVal i As Sigex.Inspeccion)
        Dim ss As New Sigex.Sector
        Dim sa As New Clases.Sector2(cn)

        ss = i.Puesto.Sector

        If ss.Adonix = 0 Then
            sa.Nuevo(ControlAdonix.Cliente, ControlAdonix.Sucursal)
            sa.Grabar()

            ss.Adonix = sa.Id
            ss.Grabar()
        Else
            sa.Abrir(ss.Adonix)
        End If

        sa.Numero = ss.Numero
        sa.Nombre = ss.Sector
        sa.Grabar()
    End Sub
    Public Sub ProcesarPuesto(ByVal i As Sigex.Inspeccion)

        Select Case i.Puesto.TipoId
            Case 0 'Sector


            Case 1 'Extintor
                ProcesarPuestoExtintor(CType(i, InspeccionExtintor))

            Case 2 'Hidrante
                ProcesarPuestoHidrante(CType(i, InspeccionHidrante))

        End Select

    End Sub
    Public Sub ProcesarPuestoExtintor(ByVal i As Sigex.InspeccionExtintor)
        Dim ss As Sigex.Sector
        Dim ps As Sigex.PuestoExtintor
        Dim sa As Clases.Sector2
        Dim pa As Clases.Puesto2
        Dim es As Sigex.Equipo
        Dim mac As New Parque(cn)

        ss = New Sigex.Sector
        sa = New Clases.Sector2(cn)

        'Obtengo el puesto extintor de la inspeccion
        ps = i.Puesto.PuestoExtintor

        'Obtengo el sector Sigex del puesto
        ss = ps.Sector

        'Abro el sector en Adonix
        sa.Abrir(ss.Adonix)

        'Abro el puesto en Adonix
        pa = sa.Puestos.BuscarPuestoPorId(CInt(ps.Adonix))
        'El puesto no existe en Adonix, creo uno nuevo
        If pa Is Nothing Then
            pa = New Puesto2(cn)
            pa.Nuevo(sa.Id, ps.NroPuesto, ps.Ubicacion, ps.TipoId)
            pa.Agente = Agentes.SigexToAdonix(ps.Agente)
            pa.Capacidad = Capacidades.SigexToAdonix(ps.Capacidad)
            pa.Grabar()

            ps.Adonix = pa.id.ToString
            ps.Grabar()
        End If

        pa.NroPuesto = ps.NroPuesto
        pa.Ubicacion = ps.Ubicacion

        'Obtengo el equipo de la inspeccion
        es = i.Equipo

        If es Is Nothing Then
            pa.EquipoId = " "

        Else
            If es.CodigoAdonix = "" Then
                mac.Nuevo(sa.ClienteId, sa.SucursalId)
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

        pa.UltimaInspeccion = ControlAdonix.id
        pa.Grabar()

    End Sub
    Public Sub ProcesarPuestoHidrante(ByVal i As Sigex.InspeccionHidrante)
        Dim ss As Sigex.Sector
        Dim ps As Sigex.PuestoHidrante
        Dim sa As Clases.Sector2
        Dim pa As Clases.Puesto2

        ss = New Sigex.Sector
        sa = New Clases.Sector2(cn)

        'Obtengo el puesto extintor de la inspeccion
        ps = i.Puesto.PuestoHidrante

        'Obtengo el sector Sigex del puesto
        ss = ps.Sector

        'Abro el sector en Adonix
        sa.Abrir(ss.Adonix)

        'Abro el puesto en Adonix
        pa = sa.Puestos.BuscarPuestoPorId(CInt(ps.Adonix))
        'El puesto no existe en Adonix, creo uno nuevo
        If pa Is Nothing Then
            pa = New Puesto2(cn)
            pa.Nuevo(sa.Id, ps.NroPuesto, ps.Ubicacion, ps.TipoId)
            pa.Grabar()

            ps.Adonix = pa.id.ToString
            ps.Grabar()
        End If

        pa.NroPuesto = ps.NroPuesto
        pa.Ubicacion = ps.Ubicacion

        pa.UltimaInspeccion = ControlAdonix.id
        pa.Grabar()

    End Sub
    Public Sub ProcesarInspeccion(ByVal i As Sigex.Inspeccion)
        Dim ia As Clases.Inspeccion
        Dim pa As Puesto2 = Nothing

        'Abro el puesto Adonix
        pa = New Puesto2(cn)
        pa.Abrir(CInt(i.Puesto.Adonix))

        'Busco la inspeccion en adonix
        ia = InspeccionesAdonix.Buscar(i.id)
        If ia Is Nothing Then
            ia = New Clases.Inspeccion(cn)
            ia.Nuevo()
        End If

        ia.id = i.id
        ia.Intervencion = ControlSigex.Intervencion 'Numero de Intervencion

        If i.Puesto.TipoId = 0 Then 'Puesto sector
            ia.Puesto = i.Puesto.Sector.Adonix
            ia.Sector = ia.Puesto
        Else 'Puesto extintor o hidrante
            ia.Puesto = pa.id
            ia.Sector = pa.SectorId
        End If

        ia.Nro = i.Puesto.NroPuesto
        ia.Ubicacion = i.Puesto.Ubicacion

        If TypeOf i Is InspeccionSector Then
            Dim ii As InspeccionSector
            ii = CType(i, InspeccionSector)

            ia.Tipo = 1 '1=Puesto sector

            ia.Luz = ii.Luz
            ia.Cinta = ii.Cinta
            ia.Cartel = ii.Cartel

        ElseIf TypeOf i Is InspeccionExtintor Then
            Dim Agente As New Agentes
            Dim Capacidad As New Capacidades
            Dim ii As InspeccionExtintor
            ii = CType(i, InspeccionExtintor)

            ia.Tipo = 2 '2=Puesto Extintor
            ia.Equipo = ii.Equipo.CodigoAdonix
            ia.Agente = Agente.SigexToAdonix(ii.Equipo.Agente)
            ia.Capacidad = Capacidad.SigexToAdonix(ii.Equipo.Capacidad)
            ia.Cilindro = ii.Equipo.Cilindro
            ia.Vto = ii.Equipo.VencimientoCarga
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
    End Sub
    Public Sub ProcesarEquipo(ByVal i As Sigex.Inspeccion)
        Dim ii As InspeccionExtintor
        Dim e As Sigex.Equipo
        Dim mac As Parque
        Dim Agente As New Agentes
        Dim Capacidad As New Capacidades

        'Salgo si la inspeccion no pertenece a un sector extintor
        If TypeOf i Is InspeccionExtintor = False Then Exit Sub

        ii = CType(i, InspeccionExtintor)

        'Obtengo equipo de la inspeccion
        e = ii.Equipo

        If e.CodigoAdonix = "" Then
            'Creo el equipo en Adonix
            mac = New Parque(cn)

        End If

    End Sub

End Class