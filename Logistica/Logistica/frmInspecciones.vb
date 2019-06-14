Imports Sigex
Imports Clases
Imports System.Collections
Imports System.Data.OracleClient

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
        CargarControlesParaConfirmar()
    End Sub
    Private Sub btnRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefrescar.Click
        CargarControlesPendientes()
        CargarControlesParaConfirmar()
    End Sub
    Private Sub btnTransferir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTransferir.Click
        If dgvSigex.SelectedRows.Count = 0 Then
            MessageBox.Show("No hay filas seleccionadas para transferir", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        Transferir()
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
            'Salto si el estado del control es 0=pendiente
            If CInt(dr("estado")) = 0 Then Continue For

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
                    .Estado = 1
                    .Grabar()
                End With
            End If

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

            ControlAdonix.Estado = ControlSigex.Estado
            ControlAdonix.Grabar()

        Next

        CargarControlesPendientes()
        CargarControlesParaConfirmar()

        btnTransferir.Enabled = True

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

        'Abro el puesto Adonix
        pa = New Puesto2(cn)
        pa.Abrir(CInt(i.Puesto.Adonix))

        If i.Puesto.TipoId = 0 Then 'Puesto sector
            ia.PuestoId = i.Puesto.Sector.Adonix
            ia.Sector = ia.PuestoId
        Else 'Puesto extintor o hidrante
            ia.PuestoId = pa.id
            ia.Sector = pa.SectorId
        End If

        ia.Nro = i.Puesto.NroPuesto
        ia.Ubicacion = i.Puesto.Ubicacion
        ia.Nombre = i.Puesto.Sector.Sector

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


            'Actualizacion de equipos
            es = ii.Equipo

            If es Is Nothing Then
                pa.EquipoId = " "

            Else
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
    Private Sub CargarControlesPendientes()
        'Carga los contoles pendientes de migracion Sigex->Adonix
        Dim dt As DataTable
        Dim ctrles As New Sigex.ControlesCollection
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

        End If

    End Sub
    Private Sub CargarControlesParaConfirmar()
        'Se carga la grilla con los controles que se deben comparar con el anterior
        'para confirmar o modificar
        Dim da As OracleDataAdapter
        Dim dt As New DataTable
        Dim sql As String
        Dim dv As DataGridView = dgvAdonix

        If dv.DataSource Is Nothing Then
            dt = New DataTable
        Else
            dt = CType(dv.DataSource, DataTable)

        End If

        sql = "select xco.itn_0, xco.dat_0, xco.bpcnum_0, bpc.bpcnam_0, xco.bpaadd_0, bpa.bpaaddlig_0 "
        sql &= "from xcontroles xco inner join "
        sql &= "	 bpaddress bpa on (xco.bpcnum_0 = bpa.bpanum_0 AND xco.bpaadd_0 = bpa.bpaadd_0) inner join "
        sql &= "	 bpcustomer bpc on (bpa.bpanum_0 = bpc.bpcnum_0) "
        sql &= "where xco.estado_0 = 1"
        da = New OracleDataAdapter(sql, cn)
        da.Fill(dt)

        If dv.DataSource Is Nothing Then
            col2Intervencion.DataPropertyName = "itn_0"
            col2Fecha.DataPropertyName = "dat_0"
            col2Cliente.DataPropertyName = "bpcnum_0"
            col2Nombre.DataPropertyName = "bpcnam_0"
            col2Sucursal.DataPropertyName = "bpaadd_0"
            col2Direccion.DataPropertyName = "bpaaddlig_0"
            dv.DataSource = dt
        End If

    End Sub
    Private Sub mnuVer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuVer.Click
        Dim f As frmConfirmarInspeccion
        Dim dr As DataRow

        If dgvAdonix.CurrentRow Is Nothing Then Exit Sub 'salgo si no hay fila seleccionada

        dr = CType(dgvAdonix.CurrentRow.DataBoundItem, DataRowView).Row
        ControlAdonix.Abrir(dr("itn_0").ToString)
        f = New frmConfirmarInspeccion(ControlAdonix)
        f.ShowInTaskbar = False
        f.ShowDialog(Me)

        If f.DialogResult = Windows.Forms.DialogResult.OK Then
            CargarControlesPendientes()
            CargarControlesParaConfirmar()
        End If

    End Sub

End Class