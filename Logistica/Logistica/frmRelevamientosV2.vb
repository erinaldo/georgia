Imports Sigex
Imports Clases
Imports System.Collections

Public Class frmRelevamientosV2

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

    Private Sub CargarControlesPendientes()
        'Carga los contoles pendientes de migracion Sigex->Adonix
        Dim dt As DataTable
        Dim ctrles As New Sigex.ControlesCollection

        If dgv1.DataSource Is Nothing Then
            dt = New DataTable
        Else
            dt = CType(dgv1.DataSource, DataTable)
        End If

        ctrles.ControlesPendientes(dt)

        If dgv1.DataSource Is Nothing Then
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

            dgv1.DataSource = dt

        End If

    End Sub
    Private Sub btnRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefrescar.Click
        CargarControlesPendientes()
    End Sub
    Private Sub btnTransferir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTransferir.Click
        Transferir()

    End Sub
    Private Sub Transferir()
        Dim dt As DataTable

        'Salgo si la grilla no contiene controles
        If dgv1.DataSource Is Nothing Then Exit Sub

        'Cargo la tabla con los controles
        dt = CType(dgv1.DataSource, DataTable)

        'Recorro todos los controles de la grilla
        For Each dr As DataRow In dt.Rows
            'Proceso unicamente los controles que no están pendientes
            '0 = Pendiente
            '1 = Finalizado
            '2 = En curso
            If CInt(dr("estado")) > 0 Then

                Dim ControlSigex As New Sigex.Control
                Dim InspeccionesSigex As New Sigex.InspeccionesCollection
                'Abro el control periodico en Sigex
                ControlSigex.Abrir(CInt(dr("id")))
                'Cargo las inspecciones del control
                InspeccionesSigex = ControlSigex.Inspecciones

                'Abro el control periodico en Adonix
                Dim ControlAdonix As New Clases.Control(cn)
                Dim InspeccionesAdonix As Clases.InspeccionesCollection

                If Not ControlAdonix.Abrir(ControlSigex.Intervencion) Then
                    'No existe el control en Adonix. Se crea uno nuevo con el nro intervencion
                    With ControlAdonix
                        .Nuevo()
                        .id = ControlSigex.Intervencion
                        .Fecha = ControlSigex.FechaProgramacion
                        .Cliente = ControlSigex.Contrato.ContratoCliente
                        .Sucursal = ControlSigex.Contrato.ContratoSucursal
                        .Grabar()
                    End With
                End If
                'Cargo las inspecciones
                InspeccionesAdonix = ControlAdonix.Inspecciones

                For Each i As Sigex.Inspeccion In InspeccionesSigex
                    If i.Estado = 0 Then Continue For

                    Dim a As Clases.Inspeccion

                    'Busco la inspeccion en adonix
                    a = InspeccionesAdonix.Buscar(i.id)

                    If a Is Nothing Then
                        a = New Clases.Inspeccion(cn)
                        a.Nuevo()
                    End If

                    a.id = i.id
                    a.Intervencion = ControlSigex.Intervencion 'Numero de Intervencion
                    a.Puesto = i.idPuesto
                    a.Sector = i.Puesto.Sector
                    a.Nro = i.Puesto.NroPuesto
                    a.Ubicacion = i.Puesto.Ubicacion

                    If TypeOf i Is InspeccionSector Then
                        Dim ii As InspeccionSector
                        ii = CType(i, InspeccionSector)

                        a.Tipo = 1 '1=Puesto sector

                        a.Luz = ii.Luz
                        a.Cinta = ii.Cinta
                        a.Cartel = ii.Cartel

                    ElseIf TypeOf i Is InspeccionExtintor Then
                        Dim Agente As New Agentes
                        Dim Capacidad As New Capacidades

                        Dim ii As InspeccionExtintor
                        ii = CType(i, InspeccionExtintor)

                        a.Tipo = 2 '2=Puesto Extintor
                        a.Equipo = ii.Equipo.CodigoAdonix
                        a.Agente = Agente.SigexToAdonix(ii.Equipo.Agente)
                        a.Capacidad = Capacidad.SigexToAdonix(ii.Equipo.Capacidad)
                        a.Cilindro = ii.Equipo.Cilindro
                        a.Vto = ii.Equipo.VencimientoCarga
                        a.Vencido = ii.Vencido
                        a.Ausente = ii.Ausente
                        a.Obstruido = ii.Obstruido
                        a.CarroDefectuoso = ii.CarroDefectuoso
                        a.EquipoUsado = ii.EquipoUsado
                        a.EquipoDespintado = ii.EquipoDespintado
                        a.EquipoDespresurizado = ii.EquipoDespresurizado
                        a.AlturaIncorrecta = ii.AlturaIncorrecta
                        a.FaltaSenalizacionAltura = ii.FaltaSenalizacionAltura
                        a.FaltaSenalizacionBaliza = ii.FaltaSenalizacionBaliza
                        a.Tarjeta = ii.FaltaTarjeta
                        a.FaltaPrecinto = ii.FaltaPrecinto
                        a.SoporteDefectuoso = ii.SoporteDefectuoso
                        a.MedioRuptura = ii.MedioRuptura
                        a.MangueraRota = ii.MangueraRota
                        a.Otro = ii.Otro

                    ElseIf TypeOf i Is InspeccionHidrante Then
                        Dim ii As InspeccionHidrante
                        ii = CType(i, InspeccionHidrante)

                        a.Tipo = 3 '3=Puesto Hidrante

                        a.Valvula = ii.Valvula
                        a.Pico = ii.Pico
                        a.Lanza = ii.Lanza
                        a.Vidrio = ii.Vidrio
                        a.Llave = ii.Llave
                        a.Tarjeta = ii.Tarjeta

                    End If

                    a.Grabar()

                Next

            End If
        Next
    End Sub

End Class