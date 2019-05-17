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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefrescar.Click
        CargarControlesPendientes()
    End Sub

    Private Sub btnTransferir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTransferir.Click
        Dim dt As DataTable

        'Salgo si la grilla no contiene controles
        If dgv1.DataSource Is Nothing Then Exit Sub

        'Cargo la tabla con los controles
        dt = CType(dgv1.DataSource, DataTable)

        'Recorro todos los controles de la grilla
        For Each dr As DataRow In dt.Rows
            'Proceso unicamente los controles que no están pendientes
            '0=Pendiente
            '1=Finalizado
            '2=En curso
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
                    Dim a As Clases.Inspeccion

                    'Busco la inspeccion en adonix
                    a = InspeccionesAdonix.Buscar(i.id)

                    If a Is Nothing Then
                        a = New Clases.Inspeccion(cn)
                        a.Nuevo()
                    End If

                    a.id = 0
                    a.Control = 0
                    a.Sector = 0

                    If TypeOf i Is InspeccionSector Then
                        a.Luz = False
                        a.Cinta = False
                        a.Cartel = False
                        a.Tipo = 0 '0=Puesto sector

                    ElseIf TypeOf i Is InspeccionExtintor Then
                        a.Equipo = " "
                        a.Agente = " "
                        a.Capacidad = " "
                        a.Cilindro = " "
                        a.Vto = Today
                        a.Vencido = False
                        a.Ausente = False
                        a.Obstruido = False
                        a.Carro = False
                        a.Usado = False
                        a.Despintado = False
                        a.Despresurizado = False
                        a.Altura = False
                        a.Senalizacion = False
                        a.SenalizacionAltura = False
                        a.SenalizacionBaliza = False
                        a.Tarjeta = False
                        a.Precinto = False
                        a.Soporte = False
                        a.Ruptura = False
                        a.Manguera = False
                        a.Otro = False

                    ElseIf TypeOf i Is InspeccionHidrante Then
                        a.Valvula = False
                        a.Pico = False
                        a.Lanza = False
                        a.Vidrio = False
                        a.Llave = False
                        a.Tarjeta = False

                    End If

                    a.Grabar()

                Next

            End If
        Next

    End Sub
End Class