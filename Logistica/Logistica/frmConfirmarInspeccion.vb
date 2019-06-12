Imports System.Data.OracleClient
Imports Clases
Imports Sigex

Public Class frmConfirmarInspeccion
    Private Agentes As New Sigex.Agentes
    Private Capacidades As New Sigex.Capacidades

    Private ControlSigex As New Sigex.Control
    Private ControlAdonix As New Clases.Control(cn)
    Private ControlAdonixAnterior As Clases.Control
    Private dtInspecciones As DataTable

    Public Sub New(ByVal ControlAdonix As Clases.Control)
        InitializeComponent()

        Me.ControlAdonix = ControlAdonix
        dtInspecciones = ControlAdonix.Inspecciones.dt

        'Buscar control anterior
        BuscarControlAnterior()

    End Sub
    Private Sub frmConfirmarInspeccion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dvSectores As New DataView(dtInspecciones)
        Dim dvExtintores As New DataView(dtInspecciones)
        Dim dvHidrantes As New DataView(dtInspecciones)
        Dim tb As TablaVaria
        Dim mnu As MenuLocal

        dvSectores.RowFilter = "tipo_0 = 1"
        dvExtintores.RowFilter = "tipo_0 = 2"
        dvHidrantes.RowFilter = "tipo_0 = 3"

        ' -- dgv sectores
        col1Id.DataPropertyName = "id_0"
        col1Intervencion.DataPropertyName = "itn_0"
        col1Puesto.DataPropertyName = "idpuesto_0"
        col1Sector.DataPropertyName = "idsector_0"
        col1Tipo.DataPropertyName = "tipo_0"
        col1Nro.DataPropertyName = "nro_0"
        col1Ubicacion.DataPropertyName = "ubicacion_0"
        col1Nombre.DataPropertyName = "nombre_0"
        col1Luz.DataPropertyName = "luz_0"
        col1Cartel.DataPropertyName = "cartel_0"
        col1Cinta.DataPropertyName = "cinta_0"
        col1Equipo.DataPropertyName = "equipo_0"
        col1Agente.DataPropertyName = "agente_0"
        col1Capacidad.DataPropertyName = "capacidad_0"
        col1Cilindro.DataPropertyName = "cilindro_0"
        col1Vto.DataPropertyName = "vto_0"

        col1Vencido.DataPropertyName = "vencido_0"
        col1Ausente.DataPropertyName = "ausente_0"
        col1Obstruido.DataPropertyName = "obstruido_0"
        col1Carro.DataPropertyName = "carro_0"
        col1Usado.DataPropertyName = "usado_0"
        col1Despintado.DataPropertyName = "despintado_0"
        col1Despresurizado.DataPropertyName = "despresu_0"
        col1Altura.DataPropertyName = "altura_0"
        col1Senal.DataPropertyName = "senal_0"
        col1SenalAltura.DataPropertyName = "senalalt_0"
        col1SenalBaliza.DataPropertyName = "senalbali_0"
        col1Tarjeta.DataPropertyName = "tarjeta_0"
        col1Precinto.DataPropertyName = "precinto_0"
        col1Soporte.DataPropertyName = "soporte_0"
        col1Ruptura.DataPropertyName = "ruptura_0"
        col1Manguera.DataPropertyName = "manguera_0"
        col1Otro.DataPropertyName = "otro_0"
        col1Valvula.DataPropertyName = "valvula_0"
        col1Pico.DataPropertyName = "pico_0"
        col1Lanza.DataPropertyName = "lanza_0"
        col1Vidrio.DataPropertyName = "vidrio_0"
        col1Llave.DataPropertyName = "llave_0"
        dgvSectores.DataSource = dvSectores
        ' -- dgv extintores
        col2Id.DataPropertyName = "id_0"
        col2Intervencion.DataPropertyName = "itn_0"
        col2Puesto.DataPropertyName = "idpuesto_0"
        col2Sector.DataPropertyName = "idsector_0"
        col2Tipo.DataPropertyName = "tipo_0"
        col2Nro.DataPropertyName = "nro_0"
        col2Ubicacion.DataPropertyName = "ubicacion_0"
        col2Nombre.DataPropertyName = "nombre_0"
        col2Luz.DataPropertyName = "luz_0"
        col2Cartel.DataPropertyName = "cartel_0"
        col2Cinta.DataPropertyName = "cinta_0"
        col2Equipo.DataPropertyName = "equipo_0"

        tb = New TablaVaria(cn, 22, True)
        tb.EnlazarComboBox(col2Agente, "agente_0")

        tb = New TablaVaria(cn, 21, True)
        tb.EnlazarComboBox(col2Capacidad, "capacidad_0")

        col2Cilindro.DataPropertyName = "cilindro_0"
        col2Vto.DataPropertyName = "vto_0"

        mnu = New MenuLocal(cn, 1, False) : mnu.Enlazar(col2Vencido, "vencido_0")
        mnu = New MenuLocal(cn, 1, False) : mnu.Enlazar(col2Ausente, "ausente_0")
        mnu = New MenuLocal(cn, 1, False) : mnu.Enlazar(col2Obstruido, "obstruido_0")
        mnu = New MenuLocal(cn, 1, False) : mnu.Enlazar(col2Carro, "carro_0")
        mnu = New MenuLocal(cn, 1, False) : mnu.Enlazar(col2Usado, "usado_0")
        mnu = New MenuLocal(cn, 1, False) : mnu.Enlazar(col2Despintado, "despintado_0")
        mnu = New MenuLocal(cn, 1, False) : mnu.Enlazar(col2Despresurizado, "despresu_0")
        mnu = New MenuLocal(cn, 1, False) : mnu.Enlazar(col2Altura, "altura_0")
        mnu = New MenuLocal(cn, 1, False) : mnu.Enlazar(col2Senal, "senal_0")
        mnu = New MenuLocal(cn, 1, False) : mnu.Enlazar(col2SenalAltura, "senalalt_0")
        mnu = New MenuLocal(cn, 1, False) : mnu.Enlazar(col2SenalBaliza, "senalbali_0")
        mnu = New MenuLocal(cn, 1, False) : mnu.Enlazar(col2Tarjeta, "tarjeta_0")
        mnu = New MenuLocal(cn, 1, False) : mnu.Enlazar(col2Precinto, "precinto_0")
        mnu = New MenuLocal(cn, 1, False) : mnu.Enlazar(col2Soporte, "soporte_0")
        mnu = New MenuLocal(cn, 1, False) : mnu.Enlazar(col2Ruptura, "ruptura_0")
        mnu = New MenuLocal(cn, 1, False) : mnu.Enlazar(col2Manguera, "manguera_0")
        mnu = New MenuLocal(cn, 1, False) : mnu.Enlazar(col2Otro, "otro_0")

        col2Valvula.DataPropertyName = "valvula_0"
        col2Pico.DataPropertyName = "pico_0"
        col2Lanza.DataPropertyName = "lanza_0"
        col2Vidrio.DataPropertyName = "vidrio_0"
        col2Llave.DataPropertyName = "llave_0"
        dgvExtintores.DataSource = dvExtintores
        ' -- dgv hidrantes
        col3Id.DataPropertyName = "id_0"
        col3Intervencion.DataPropertyName = "itn_0"
        col3Puesto.DataPropertyName = "idpuesto_0"
        col3Sector.DataPropertyName = "idsector_0"
        col3Tipo.DataPropertyName = "tipo_0"
        col3Nro.DataPropertyName = "nro_0"
        col3Ubicacion.DataPropertyName = "ubicacion_0"
        col3Nombre.DataPropertyName = "nombre_0"
        col3Luz.DataPropertyName = "luz_0"
        col3Cartel.DataPropertyName = "cartel_0"
        col3Cinta.DataPropertyName = "cinta_0"
        col3Equipo.DataPropertyName = "equipo_0"
        col3Agente.DataPropertyName = "agente_0"
        col3Capacidad.DataPropertyName = "capacidad_0"
        col3Cilindro.DataPropertyName = "cilindro_0"
        col3Vto.DataPropertyName = "vto_0"
        col3Vencido.DataPropertyName = "vencido_0"
        col3Ausente.DataPropertyName = "ausente_0"
        col3Obstruido.DataPropertyName = "obstruido_0"
        col3Carro.DataPropertyName = "carro_0"
        col3Usado.DataPropertyName = "usado_0"
        col3Despintado.DataPropertyName = "despintado_0"
        col3Despresurizado.DataPropertyName = "despresu_0"
        col3Altura.DataPropertyName = "altura_0"
        col3Senal.DataPropertyName = "senal_0"
        col3SenalAltura.DataPropertyName = "senalalt_0"
        col3SenalBaliza.DataPropertyName = "senalbali_0"
        col3Tarjeta.DataPropertyName = "tarjeta_0"
        col3Precinto.DataPropertyName = "precinto_0"
        col3Soporte.DataPropertyName = "soporte_0"
        col3Ruptura.DataPropertyName = "ruptura_0"
        col3Manguera.DataPropertyName = "manguera_0"
        col3Otro.DataPropertyName = "otro_0"
        mnu = New MenuLocal(cn, 1, False) : mnu.Enlazar(col3Valvula, "valvula_0")
        mnu = New MenuLocal(cn, 1, False) : mnu.Enlazar(col3Pico, "pico_0")
        mnu = New MenuLocal(cn, 1, False) : mnu.Enlazar(col3Lanza, "lanza_0")
        mnu = New MenuLocal(cn, 1, False) : mnu.Enlazar(col3Vidrio, "vidrio_0")
        mnu = New MenuLocal(cn, 1, False) : mnu.Enlazar(col3Llave, "llave_0")
        dgvHidrantes.DataSource = dvHidrantes

        'Comparo con la inspeccion anterior
        If ControlAdonixAnterior IsNot Nothing Then
            CompararConAnterior()
        End If

    End Sub

    Private Sub ProcesarPuesto(ByVal i As Sigex.Inspeccion)

        Select Case i.Puesto.TipoId
            Case 0 'Sector


            Case 1 'Extintor
                ProcesarPuestoExtintor(CType(i, InspeccionExtintor))

            Case 2 'Hidrante
                ProcesarPuestoHidrante(CType(i, InspeccionHidrante))

        End Select

    End Sub
    Private Sub ProcesarPuestoExtintor(ByVal i As Sigex.InspeccionExtintor)
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
    Private Sub ProcesarPuestoHidrante(ByVal i As Sigex.InspeccionHidrante)
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
    Private Sub ProcesarEquipo(ByVal i As Sigex.Inspeccion)
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
    Private Sub ProcesarSector(ByVal i As Sigex.Inspeccion)
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
    Private Sub BuscarControlAnterior()
        Dim da As OracleDataAdapter
        Dim sql As String
        Dim dt As New DataTable
        Dim dr As DataRow

        sql = "SELECT itn_0 "
        sql &= "FROM xcontroles "
        sql &= "WHERE itn_0 <> :itn "
        sql &= "ORDER BY dat_0 desc"
        da = New OracleDataAdapter(sql, cn)
        da.SelectCommand.Parameters.Add("itn", OracleType.VarChar).Value = ControlAdonix.id
        da.Fill(dt)

        ControlAdonixAnterior = Nothing

        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            ControlAdonixAnterior = New Clases.Control(cn)
            ControlAdonixAnterior.Abrir(dr("itn_0").ToString)
        End If

        da.Dispose()
        dt.Dispose()

    End Sub
    Private Sub CompararConAnterior()
        Dim ii As Clases.InspeccionesCollection

        ii = ControlAdonix.Inspecciones

        For Each i As Clases.Inspeccion In ii

        Next

    End Sub

End Class