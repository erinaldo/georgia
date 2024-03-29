﻿Imports System.Data.OracleClient
Imports Clases
Imports Sigex

Public Class frmEditarInspeccion
    Private Agentes As New Sigex.Agentes
    Private Capacidades As New Sigex.Capacidades
    Private ControlSigex As New Sigex.Control
    Private ControlAdonix As New Clases.Control(cn)
    Private ControlAdonixAnterior As Clases.Control
    Private Inspecciones As Clases.InspeccionesCollection

    Public Sub New(ByVal ControlAdonix As Clases.Control)
        InitializeComponent()

        Me.ControlAdonix = ControlAdonix
        Inspecciones = ControlAdonix.Inspecciones

        'Buscar control anterior
        BuscarControlAnterior()

    End Sub
    Private Sub frmConfirmarInspeccion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dvSectores As New DataView(Inspecciones.dt)
        Dim dvExtintores As New DataView(Inspecciones.dt)
        Dim dvHidrantes As New DataView(Inspecciones.dt)
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
        mnu = New MenuLocal(cn, 1, False) : mnu.Enlazar(col1Luz, "luz_0")
        mnu = New MenuLocal(cn, 1, False) : mnu.Enlazar(col1Cartel, "cartel_0")
        mnu = New MenuLocal(cn, 1, False) : mnu.Enlazar(col1Cinta, "cinta_0")
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
        col1Obs.DataPropertyName = "obs_0"
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
        col2Obs.DataPropertyName = "obs_0"
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
        col3Obs.DataPropertyName = "obs_0"
        dgvHidrantes.DataSource = dvHidrantes

        'Comparo con la inspeccion anterior
        If ControlAdonixAnterior IsNot Nothing Then
            CompararConAnterior()
        End If

    End Sub
    Private Sub ProcesarInspecciones()
        Dim i As Clases.Inspeccion

        For Each i In Inspecciones

            Select Case i.Tipo
                Case 0 'Sector

                Case 1 'Extintor
                    ProcesarPuestoExtintor(i)

                Case 2 'Hidrante
                    ProcesarPuestoHidrante(i)

            End Select

        Next

    End Sub
    Private Sub ProcesarPuestoExtintor(ByVal i As Clases.Inspeccion)
        Dim p As Clases.Puesto2
        Dim mac As New Parque(cn)

        'Actualizo el puesto con la información de la inspeccion
        p = i.Puesto
        If p Is Nothing Then
            p = New Puesto2(cn)
            p.Nuevo(i.Sector, i.Nro, i.Ubicacion, 2)
        End If

        p.EquipoId = i.Equipo
        p.Cilindro = i.Cilindro
        p.Agente = i.Agente
        p.Capacidad = i.Capacidad
        p.NroPuesto = i.Nro
        p.Ubicacion = i.Ubicacion
        p.UltimaInspeccion = ControlAdonix.id
        p.Grabar()

    End Sub
    Private Sub ProcesarPuestoHidrante(ByVal i As Clases.Inspeccion)
        Dim p As Clases.Puesto2

        'Obtengo el puesto extintor de la inspeccion
        p = i.Puesto
        'Creo el puesto si no existe
        If p Is Nothing Then
            p = New Puesto2(cn)
            p.Nuevo(i.Sector, i.Nro, i.Ubicacion, 3)
        End If

        p.NroPuesto = i.Nro
        p.Ubicacion = i.Ubicacion
        p.UltimaInspeccion = ControlAdonix.id
        p.Grabar()

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
        sa.Nombre = ss.Nombre
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
        Dim d As DataGridViewRow
        Dim ii As Clases.InspeccionesCollection
        Dim i As Clases.Inspeccion
        Dim Campo As String

        Dim tb1 = New TablaVaria(cn, 22, True) 'agentes
        Dim tb2 = New TablaVaria(cn, 21, True) 'capacidades

        ii = ControlAdonixAnterior.Inspecciones

        'Comparacion de puestos hidrantes
        For Each d In dgvHidrantes.Rows
            Dim dr As DataRow

            'Obtengo el dr origen
            dr = CType(d.DataBoundItem, DataRowView).Row
            'Busco si existe el relevamiento anterior del puesto
            i = ii.Buscar(CInt(dr("id_0")))

            If i IsNot Nothing Then
                Campo = "col1Luz"
                If CInt(d.Cells(Campo).Value) <> i.Luces Then
                    d.Cells(Campo).ErrorText = i.Luces.ToString
                End If
                Campo = "col1Cartel"
                If CInt(d.Cells(Campo).Value) <> i.CartelAltura Then
                    d.Cells(Campo).ErrorText = i.CartelAltura.ToString
                End If
                Campo = "col1Cinta"
                If CInt(d.Cells(Campo).Value) <> i.Cinta Then
                    d.Cells(Campo).ErrorText = i.Cinta.ToString
                End If
            End If
        Next

        'Comparacion de puestos extintor
        For Each d In dgvExtintores.Rows
            Dim dr As DataRow

            'Obtengo el dr origen
            dr = CType(d.DataBoundItem, DataRowView).Row
            'Busco si existe el relevamiento anterior del puesto
            i = ii.Buscar(CInt(dr("id_0")))

            If i IsNot Nothing Then
                Campo = "col2Agente"
                If d.Cells(Campo).Value.ToString <> i.Agente Then
                    d.Cells(Campo).ErrorText = tb1.Texto(i.Agente)
                End If
                Campo = "col2Capacidad"
                If d.Cells(Campo).Value.ToString <> i.Capacidad Then
                    d.Cells(Campo).ErrorText = tb2.Texto(i.Capacidad)
                End If
                Campo = "col2Cilindro"
                If d.Cells(Campo).Value.ToString <> i.Cilindro Then
                    d.Cells(Campo).ErrorText = i.Cilindro
                End If
                Campo = "col2Vencido"
                If CBool(CInt(d.Cells(Campo).Value) - 1) <> i.Vencido Then
                    d.Cells(Campo).ErrorText = IIf(i.Vencido, "Sí", "No").ToString
                End If
                Campo = "col2Ausente"
                If CBool(CInt(d.Cells(Campo).Value) - 1) <> i.Ausente Then
                    d.Cells(Campo).ErrorText = IIf(i.Ausente, "Sí", "No").ToString
                End If
                Campo = "col2Obstruido"
                If CBool(CInt(d.Cells(Campo).Value) - 1) <> i.Obstruido Then
                    d.Cells(Campo).ErrorText = IIf(i.Obstruido, "Sí", "No").ToString
                End If
                Campo = "col2Carro"
                If CBool(CInt(d.Cells(Campo).Value) - 1) <> i.CarroDefectuoso Then
                    d.Cells(Campo).ErrorText = IIf(i.CarroDefectuoso, "Sí", "No").ToString
                End If
                Campo = "col2Usado"
                If CBool(CInt(d.Cells(Campo).Value) - 1) <> i.EquipoUsado Then
                    d.Cells(Campo).ErrorText = IIf(i.EquipoUsado, "Sí", "No").ToString
                End If
                Campo = "col2Despintado"
                If CBool(CInt(d.Cells(Campo).Value) - 1) <> i.EquipoDespintado Then
                    d.Cells(Campo).ErrorText = IIf(i.EquipoDespintado, "Sí", "No").ToString
                End If
                Campo = "col2Despresurizado"
                If CBool(CInt(d.Cells(Campo).Value) - 1) <> i.EquipoDespresurizado Then
                    d.Cells(Campo).ErrorText = IIf(i.EquipoDespresurizado, "Sí", "No").ToString
                End If
                Campo = "col2Altura"
                If CBool(CInt(d.Cells(Campo).Value) - 1) <> i.AlturaIncorrecta Then
                    d.Cells(Campo).ErrorText = IIf(i.AlturaIncorrecta, "Sí", "No").ToString
                End If
                Campo = "col2SenalAltura"
                If CBool(CInt(d.Cells(Campo).Value) - 1) <> i.FaltaSenalizacionAltura Then
                    d.Cells(Campo).ErrorText = IIf(i.FaltaSenalizacionAltura, "Sí", "No").ToString
                End If
                Campo = "col2SenalBaliza"
                If CBool(CInt(d.Cells(Campo).Value) - 1) <> i.FaltaSenalizacionBaliza Then
                    d.Cells(Campo).ErrorText = IIf(i.FaltaSenalizacionBaliza, "Sí", "No").ToString
                End If
                Campo = "col2Tarjeta"
                If CBool(CInt(d.Cells(Campo).Value) - 1) <> i.Tarjeta Then
                    d.Cells(Campo).ErrorText = IIf(i.Tarjeta, "Sí", "No").ToString
                End If
                Campo = "col2Precinto"
                If CBool(CInt(d.Cells(Campo).Value) - 1) <> i.FaltaPrecinto Then
                    d.Cells(Campo).ErrorText = IIf(i.FaltaPrecinto, "Sí", "No").ToString
                End If
                Campo = "col2Soporte"
                If CBool(CInt(d.Cells(Campo).Value) - 1) <> i.SoporteDefectuoso Then
                    d.Cells(Campo).ErrorText = IIf(i.SoporteDefectuoso, "Sí", "No").ToString
                End If
                Campo = "col2Ruptura"
                If CBool(CInt(d.Cells(Campo).Value) - 1) <> i.MedioRuptura Then
                    d.Cells(Campo).ErrorText = IIf(i.MedioRuptura, "Sí", "No").ToString
                End If
                Campo = "col2Manguera"
                If CBool(CInt(d.Cells(Campo).Value) - 1) <> i.MangueraRota Then
                    d.Cells(Campo).ErrorText = IIf(i.MangueraRota, "Sí", "No").ToString
                End If
                Campo = "col2Otro"
                If CBool(CInt(d.Cells(Campo).Value) - 1) <> i.Otro Then
                    d.Cells(Campo).ErrorText = IIf(i.Otro, "Sí", "No").ToString
                End If

            End If
        Next

        'Comparacion de puestos hidrantes
        For Each d In dgvHidrantes.Rows
            Dim dr As DataRow

            'Obtengo el dr origen
            dr = CType(d.DataBoundItem, DataRowView).Row
            'Busco si existe el relevamiento anterior del puesto
            i = ii.Buscar(CInt(dr("id_0")))

            If i IsNot Nothing Then
                Campo = "col3Valvula"
                If CBool(CInt(d.Cells(Campo).Value) - 1) <> i.Valvula Then
                    d.Cells(Campo).ErrorText = IIf(i.Valvula, "Sí", "No").ToString
                End If
                Campo = "col3Pico"
                If CBool(CInt(d.Cells(Campo).Value) - 1) <> i.Pico Then
                    d.Cells(Campo).ErrorText = IIf(i.Pico, "Sí", "No").ToString
                End If
                Campo = "col3Lanza"
                If CBool(CInt(d.Cells(Campo).Value) - 1) <> i.Lanza Then
                    d.Cells(Campo).ErrorText = IIf(i.Lanza, "Sí", "No").ToString
                End If
                Campo = "col3Vidrio"
                If CBool(CInt(d.Cells(Campo).Value) - 1) <> i.Vidrio Then
                    d.Cells(Campo).ErrorText = IIf(i.Vidrio, "Sí", "No").ToString
                End If
                Campo = "col3Llave"
                If CBool(CInt(d.Cells(Campo).Value) - 1) <> i.Llave Then
                    d.Cells(Campo).ErrorText = IIf(i.Llave, "Sí", "No").ToString
                End If

            End If
        Next

    End Sub
    Private Sub Registrar()
        Inspecciones.Grabar()
        ActualizarPuestos()
    End Sub
    Private Sub ActualizarPuestos()
        For Each i As Clases.Inspeccion In Inspecciones
            Select Case i.Tipo
                Case 2 'Extintor
                    Dim p As Clases.Puesto2

                    p = i.Puesto

                    p.EquipoId = i.Equipo
                    p.Cilindro = i.Cilindro
                    p.Agente = i.Agente
                    p.Capacidad = i.Capacidad
                    p.Grabar()

            End Select
        Next
    End Sub
    Private Sub btnRegistrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegistrar.Click
        Registrar()
    End Sub
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfirmar.Click
        If MessageBox.Show("¿Confirma la inspección?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            Registrar()

            ControlAdonix.Estado = 2
            ControlAdonix.Grabar()

            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If

    End Sub
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

End Class