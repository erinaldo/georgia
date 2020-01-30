Imports Clases
Imports System.Data.OracleClient

Public Class frmIntervencionesAutomaticas
    Private Const ARTICULO_639 As String = "553011"
    Private Const ARTICULO_CONTROLES As String = "652001"

    Private f As Feriados
    Private Desde As Date
    Private Hasta As Date
    Private Inicio As Date 'Usada para fecha Inicio en Intervencion
    Private tar As New Tarifa(cn)
    Private cpy As New Sociedad(cn)
    Private Log As New Logs

    Private Sub frmIntervencionesAutomaticas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim fecha As Date = Today.AddDays(1)

        f = New Feriados(cn)

        'Busco el primer dia habil
        While fecha.DayOfWeek = DayOfWeek.Saturday Or fecha.DayOfWeek = DayOfWeek.Sunday Or f.Existe(fecha)
            fecha = fecha.AddDays(1)
        End While

        dtpInicio.MinDate = fecha
    End Sub
    Private Sub btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn.Click
        btn.Enabled = False

        Select Case dtpInicio.Value.DayOfWeek
            Case DayOfWeek.Saturday
                MessageBox.Show("La fecha de impresion no puede ser sábado")

            Case DayOfWeek.Sunday
                MessageBox.Show("La fecha de impresion no puede ser domingo")

            Case Else
                If f.Existe(dtpInicio.Value) Then
                    MessageBox.Show("La fecha de impresion no puede ser feriado")

                Else
                    EstablecerFechas()

                    With Log
                        .Nuevo()
                        .Escribir("GENERACIÓN DE INTERVENCIONES AUTOMÁTICAS")
                        .Escribir()
                        .Escribir("FECHA: " & Now.ToString)
                        .Escribir("USUARIO: " & usr.Nombre)
                        .Escribir("----------")
                        .Escribir("Parámetros")
                        .Escribir("Desde: " & Desde.ToString & " - Hasta:" & Hasta.AddDays(-1).ToString)
                        .Escribir()
                    End With

                    GenerarIntervencionesControles()
                    GenerarIntervenciones639()
                    GenerarIntervencionesE1()
                    GenerarIntervencionesE2()

                    Log.Cerrar()

                    MessageBox.Show("Proceso finalizado", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

        End Select

        Label1.Text = ""
        Label2.Text = ""

        btn.Enabled = True

        MessageBox.Show("Proceso finalizado", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub
    Private Sub EstablecerFechas()
        'Calculo fecha Desde/Hasta
        Desde = mCal.SelectionRange.Start
        Desde = New Date(Desde.Year, Desde.Month, 1)
        Hasta = Desde.AddMonths(1)

        'Calculo el primer dia habil del mes
        Inicio = Desde
        Do While f.Existe(Inicio) Or Inicio.DayOfWeek = DayOfWeek.Saturday Or Inicio.DayOfWeek = DayOfWeek.Sunday
            Inicio = Inicio.AddDays(1)
        Loop
    End Sub
    Private Sub GenerarIntervencionesControles()
        Dim dt As New DataTable
        Dim mac As New Parque(cn)
        Dim bpc As New Cliente(cn)
        Dim itm As New Articulo(cn)
        Dim txt As String = ""
        Dim bpa As New Sucursal(cn)

        Label1.Text = "Generando Intervenciones de Controles"
        Label1.Visible = True
        Label2.Text = ""
        Label2.Visible = True
        pb.Value = 0
        pb.Minimum = 0
        pb.Maximum = 0

        itm.Abrir(ARTICULO_CONTROLES)

        'Obtengo los controles a hacer en el mes
        dt = ObtenerVencimientosControles()
        pb.Value = 0
        pb.Minimum = 0
        pb.Maximum = dt.Rows.Count

        Log.Escribir("-------------------------------------------------------------------")
        Log.Escribir("Inicio de proceso Controles Períodicos: " & dt.Rows.Count & " registro(s)")
        Log.Escribir("-------------------------------------------------------------------")

        For Each dr As DataRow In dt.Rows
            pb.Value += 1

            Label2.Text = "Registro " & pb.Value.ToString & " de " & pb.Maximum.ToString
            Application.DoEvents()

            If mac.Abrir(dr("macnum_0").ToString) Then
                bpc = mac.Cliente

                If mac.ArticuloCodigo = "992002" Then
                    Try
                        mac.ArticuloCodigo = "992001"
                        mac.Grabar()

                    Catch ex As Exception
                        txt = "Error al transformar control" & vbCrLf & vbCrLf
                        txt &= "Serie: " & mac.Serie

                        MessageBox.Show(txt, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)

                    End Try

                End If

                'No se crea si no es sucursal entrega o inactiva
                If bpa.Abrir(mac.ClienteNumero, mac.SucursalNumero) Then
                    If Not bpa.SucursalEntregaActiva Then
                        Log.Escribir("{" & mac.ClienteNumero & "} {" & mac.SucursalNumero & "} No es sucursal entrega o está inactiva")
                        Continue For
                    End If
                Else
                    Continue For
                End If

                'No se crea intervencion si la cantidad de controles no supera el minimo
                If mac.Cantidad < CP_CANTIDAD_MINIMA_REQUERIDA Then
                    Log.Escribir("{" & mac.ClienteNumero & "} {" & mac.SucursalNumero & "} No alcanza la cantidad mínima")
                    Continue For
                End If


                'Buscar que no haya intervenciones abiertas A1
                If HayIntervencionAbierta(mac.ClienteNumero, mac.SucursalNumero, "A1") Then
                    Log.Escribir("{" & mac.ClienteNumero & "} {" & mac.SucursalNumero & "} Se encontró intervención A1 abierta")
                    Continue For
                End If

                'Buscar que no haya intervencines abiertas B1
                If HayIntervencionAbierta(mac.ClienteNumero, mac.SucursalNumero, "B1") Then
                    'Se reagenda para dos meses
                    txt = Today.ToString("dd/MM/yyyy") & " - "
                    txt &= "Se reagenda para dentro de dos meses porque existe intervención B1 abierta" & vbCrLf & vbCrLf
                    txt &= "Vto: " & mac.VtoCarga.ToString("dd/MM/yyyy") & vbCrLf

                    mac.VtoCarga = Inicio.AddMonths(2)
                    txt &= "Vto Nuevo: " & mac.VtoCarga.ToString("dd/MM/yyyy")

                    mac.Observaciones = txt

                    mac.Grabar()

                    Log.Escribir("{" & mac.ClienteNumero & "} {" & mac.SucursalNumero & "} Se reagenda para dentro de dos meses porque existe intervención B1 abierta")

                    Continue For
                End If

                'Buscar que no haya vencimientos de recarga en el mismo mes
                If HayRecargasEnMes(mac.ClienteNumero, mac.SucursalNumero) Then
                    'Se reagenda para mes siguiente
                    txt = Today.ToString("dd/MM/yyyy") & " - "
                    txt &= "Se pasó el vto al mes siguiente porque se encontraron recargas en el mismo mes" & vbCrLf & vbCrLf
                    txt &= "Vto: " & mac.VtoCarga.ToString("dd/MM/yyyy") & vbCrLf

                    mac.VtoCarga = Inicio.AddMonths(1)
                    txt &= "Vto Nuevo: " & mac.VtoCarga.ToString("dd/MM/yyyy")

                    mac.Observaciones = txt

                    mac.Grabar()

                    Log.Escribir("{" & mac.ClienteNumero & "} {" & mac.SucursalNumero & "} Se pasó el vto al mes siguiente porque se encontraron recargas en el mismo mes")
                    Continue For
                End If

                '---------------------------------------------------------------------
                ' CREACION DE INTERVENCION PARA CONTROL PERIODICO
                '---------------------------------------------------------------------
                CrearIntervencion(mac, "A1")

                '---------------------------------------------------------------------
                ' CREACION DE INTERVENCION PARA 639
                '---------------------------------------------------------------------

                If bpc.Familia2 = "11" And (bpa.TipoSistema = 1 Or bpa.TipoSistema = 2) Then
                    Dim mac2 As Parque

                    'Busco Parque de 639
                    mac2 = BuscarParque639(Desde, Hasta, mac.ClienteNumero, mac.SucursalNumero)
                    'Creo intervencion para 639
                    If mac2 IsNot Nothing Then
                        CrearIntervencion(mac2, "A1")
                    End If
                End If

            End If
        Next

        Label1.Visible = False
        Label2.Visible = False

    End Sub
    Private Sub GenerarIntervenciones639()
        Dim dt As New DataTable
        Dim mac As New Parque(cn)
        Dim cpy As New Sociedad(cn)
        Dim bpa As New Sucursal(cn)
        Dim bpc As New Cliente(cn)

        Label1.Text = "Generando Intervenciones de 639"
        Label1.Visible = True
        Label2.Text = ""
        Label2.Visible = True

        'Obtengo los controles a hacer en el mes
        dt = ObtenerVencimientos639(Desde.AddMonths(-2), Hasta)
        pb.Minimum = 0
        pb.Value = 0
        pb.Maximum = dt.Rows.Count

        Log.Escribir("-------------------------------------------------------------------")
        Log.Escribir("Inicio de proceso Sistemas Fijos: " & dt.Rows.Count & " registro(s)")
        Log.Escribir("-------------------------------------------------------------------")

        cpy.abrir("DNY")

        For Each dr As DataRow In dt.Rows
            pb.Value += 1
            Label2.Text = "Registro " & pb.Value.ToString & " de " & pb.Maximum.ToString
            Application.DoEvents()

            If mac.Abrir(dr("macnum_0").ToString) Then
                If bpa.Abrir(mac.ClienteNumero, mac.SucursalNumero) Then
                    If Not bpa.SucursalEntregaActiva Then
                        Continue For
                    End If
                Else
                    Continue For
                End If

                bpc = mac.Cliente

                'Se genera intervencion si no es consorcio o 639 vencio hace 2 meses
                If bpc.Familia2 = "11" And (bpa.TipoSistema = 1 Or bpa.TipoSistema = 2) Then
                    CrearIntervencion(mac, "A1")

                Else
                    CrearIntervencion(mac, "F1")

                End If

            End If
        Next

    End Sub
    Private Sub GenerarIntervencionesE1()
        Dim dt As New DataTable
        Dim mac As New Parque(cn)
        Dim bpc As New Cliente(cn)
        Dim itm As New Articulo(cn)
        Dim txt As String = ""
        Dim bpa As New Sucursal(cn)
        Dim Cli As String = ""
        Dim Suc As String = ""
        Dim dv As DataView

        Label1.Text = "Generando Intervenciones E1"
        Label1.Visible = True
        Label2.Text = ""
        Label2.Visible = True
        pb.Value = 0
        pb.Minimum = 0
        pb.Maximum = 0

        'Obtengo los controles a hacer en el mes
        dt = ObtenerVencimientosE1()
        pb.Value = 0
        pb.Minimum = 0
        pb.Maximum = dt.Rows.Count

        Log.Escribir("-------------------------------------------------------------------")
        Log.Escribir("Inicio de proceso Intervenciones E1: " & dt.Rows.Count & " registro(s)")
        Log.Escribir("-------------------------------------------------------------------")

        dv = New DataView(dt)

        For Each dr As DataRow In dt.Rows
            pb.Value += 1
            Label2.Text = "Registro " & pb.Value.ToString & " de " & pb.Maximum.ToString
            Application.DoEvents()

            If dr("bpcnum_0").ToString <> Cli Or dr("fcyitn_0").ToString <> Suc Then
                Cli = dr("bpcnum_0").ToString
                Suc = dr("fcyitn_0").ToString

                'Filtro 
                dv.RowFilter = "bpcnum_0 = '" & Cli & "' AND fcyitn_0 = '" & Suc & "'"

                CrearIntervencion(dv, "E1")

            End If

        Next

        Label1.Visible = False
        Label2.Visible = False

    End Sub
    Private Sub GenerarIntervencionesE2()
        Dim dt As New DataTable
        Dim mac As New Parque(cn)
        Dim bpc As New Cliente(cn)
        Dim itm As New Articulo(cn)
        Dim txt As String = ""
        Dim bpa As New Sucursal(cn)
        Dim Cli As String = ""
        Dim Suc As String = ""
        Dim dv As DataView

        Label1.Text = "Generando Intervenciones E2"
        Label1.Visible = True
        Label2.Text = ""
        Label2.Visible = True
        pb.Value = 0
        pb.Minimum = 0
        pb.Maximum = 0

        'Obtengo los controles a hacer en el mes
        dt = ObtenerVencimientosE2()
        pb.Value = 0
        pb.Minimum = 0
        pb.Maximum = dt.Rows.Count

        Log.Escribir("-------------------------------------------------------------------")
        Log.Escribir("Inicio de proceso Intervenciones E2: " & dt.Rows.Count & " registro(s)")
        Log.Escribir("-------------------------------------------------------------------")

        dv = New DataView(dt)

        For Each dr As DataRow In dt.Rows
            pb.Value += 1
            Label2.Text = "Registro " & pb.Value.ToString & " de " & pb.Maximum.ToString
            Application.DoEvents()

            If dr("bpcnum_0").ToString <> Cli Or dr("fcyitn_0").ToString <> Suc Then
                Cli = dr("bpcnum_0").ToString
                Suc = dr("fcyitn_0").ToString

                'Filtro 
                dv.RowFilter = "bpcnum_0 = '" & Cli & "' AND fcyitn_0 = '" & Suc & "'"

                CrearIntervencion(dv, "E2")

            End If

        Next

        Label1.Visible = False
        Label2.Visible = False

    End Sub
    Private Function ObtenerVencimientosControles() As DataTable
        Dim Sql As String
        Dim da As OracleDataAdapter
        Dim dt As New DataTable

        Sql = "SELECT mac.macnum_0 "
        Sql &= "FROM machines mac INNER JOIN ymacitm yit ON (mac.macnum_0 = yit.macnum_0) INNER JOIN "
        Sql &= "	 bomd bod ON (mac.macpdtcod_0 = bod.itmref_0 AND yit.cpnitmref_0 = bod.cpnitmref_0) INNER JOIN "
        Sql &= "	 bpcustomer bpc ON (mac.bpcnum_0 = bpc.bpcnum_0) INNER JOIN "
        Sql &= "	 bpdlvcust bpd ON (mac.bpcnum_0 = bpd.bpcnum_0 and mac.fcyitn_0 = bpd.bpaadd_0) INNER JOIN "
        Sql &= "     bpcustomer bpy ON (bpc.bpcpyr_0 = bpy.bpcnum_0) "
        Sql &= "WHERE macpdtcod_0 IN ('992002', '992001') and "
        Sql &= "      bpc.ctrlflg_0 = 2 and "
        Sql &= "      bpy.ctrlflg_0 = 2 and "
        Sql &= "	  xitn_0 = ' ' and "
        Sql &= "	  bomalt_0 = 99 and "
        Sql &= "	  bomseq_0 = 10 and "
        Sql &= "	  datnext_0 >= :desde AND datnext_0 < :hasta and "
        Sql &= "	  bpcsta_0 = 2 and "             'cliente activo
        Sql &= "	  ostctl_0 = 2 and "             'cliente libre  (no bloqueado)
        Sql &= "	  tsccod_1 <> '50' and " 'Todo menos clientes 50
        Sql &= "	  xabo_0 <> 2"

        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("desde", OracleType.DateTime).Value = Desde
        da.SelectCommand.Parameters.Add("hasta", OracleType.DateTime).Value = Hasta

        da.Fill(dt)
        da.Dispose()

        Return dt

    End Function
    Private Function ObtenerVencimientos639(ByVal Desde As Date, ByVal hasta As Date, Optional ByVal Cliente As String = "", Optional ByVal Sucursal As String = "") As DataTable
        Dim Sql As String
        Dim da As OracleDataAdapter
        Dim dt As New DataTable

        Sql = "SELECT mac.macnum_0 "
        Sql &= "FROM machines mac INNER JOIN ymacitm yit ON (mac.macnum_0 = yit.macnum_0) INNER JOIN "
        Sql &= "	 bomd bod ON (mac.macpdtcod_0 = bod.itmref_0 AND yit.cpnitmref_0 = bod.cpnitmref_0) INNER JOIN "
        Sql &= "	 bpcustomer bpc ON (mac.bpcnum_0 = bpc.bpcnum_0) inner join "
        Sql &= "	 bpdlvcust bpd on (mac.bpcnum_0 = bpd.bpcnum_0 and mac.fcyitn_0 = bpd.bpaadd_0) "
        Sql &= "WHERE cpnitmref_0 = :art and "
        Sql &= "	  xitn_0 = ' ' and "
        Sql &= "	  bomalt_0 = 99 and "
        Sql &= "	  bomseq_0 = 10 and "
        Sql &= "	  datnext_0 >= :desde AND datnext_0 < :hasta and "
        Sql &= "	  bpcsta_0 = 2 "          'cliente activo
        'Sql &= "	  ostctl_0 = 2 "              'cliente libre  (no bloqueado)
        If Cliente <> "" And Sucursal <> "" Then
            Sql &= " AND mac.bpcnum_0 = :bpcnum AND fcyitn_0 = :fcyitn"
        End If

        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("art", OracleType.VarChar).Value = ARTICULO_639
        da.SelectCommand.Parameters.Add("desde", OracleType.DateTime).Value = Desde
        da.SelectCommand.Parameters.Add("hasta", OracleType.DateTime).Value = hasta
        If Cliente <> "" And Sucursal <> "" Then
            da.SelectCommand.Parameters.Add("bpcnum", OracleType.VarChar).Value = Cliente
            da.SelectCommand.Parameters.Add("fcyitn", OracleType.VarChar).Value = Sucursal
        End If

        da.Fill(dt)
        da.Dispose()

        Return dt

    End Function
    Private Function ObtenerVencimientosE1() As DataTable
        Dim Sql As String
        Dim da As OracleDataAdapter
        Dim dt As New DataTable

        Sql = "SELECT mac.macnum_0, mac.bpcnum_0, mac.fcyitn_0, yit.cpnitmref_0, mac.macqty_0 "
        Sql &= "FROM machines mac INNER JOIN "
        Sql &= "     ymacitm yit ON (mac.macnum_0 = yit.macnum_0) INNER JOIN "
        Sql &= "	 bomd bod ON (mac.macpdtcod_0 = bod.itmref_0 AND yit.cpnitmref_0 = bod.cpnitmref_0 AND bomalt_0 = 99 AND bomseq_0 = 10) INNER JOIN "
        Sql &= "	 bpcustomer bpc ON (mac.bpcnum_0 = bpc.bpcnum_0) INNER JOIN "
        Sql &= "	 bpdlvcust bpd ON (mac.bpcnum_0 = bpd.bpcnum_0 and mac.fcyitn_0 = bpd.bpaadd_0) "
        Sql &= "WHERE yit.cpnitmref_0 IN ('551003','551056','551058','551060','551063','551070','551073') and "
        Sql &= "	  xitn_0 = ' ' and "
        Sql &= "	  datnext_0 >= :desde AND datnext_0 < :hasta and "
        Sql &= "	  bpcsta_0 = 2 and "             'Cliente activo
        Sql &= "	  ostctl_0 = 2  "             'Cliente libre  (no bloqueado)
        Sql &= "ORDER BY mac.bpcnum_0, fcyitn_0"

        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("desde", OracleType.DateTime).Value = Desde
        da.SelectCommand.Parameters.Add("hasta", OracleType.DateTime).Value = Hasta

        da.Fill(dt)
        da.Dispose()

        Return dt

    End Function
    Private Function ObtenerVencimientosE2() As DataTable
        Dim Sql As String
        Dim da As OracleDataAdapter
        Dim dt As New DataTable

        Sql = "SELECT mac.macnum_0, mac.bpcnum_0, mac.fcyitn_0, yit.cpnitmref_0, mac.macqty_0 "
        Sql &= "FROM machines mac INNER JOIN "
        Sql &= "     ymacitm yit ON (mac.macnum_0 = yit.macnum_0) INNER JOIN "
        Sql &= "	 bomd bod ON (mac.macpdtcod_0 = bod.itmref_0 AND yit.cpnitmref_0 = bod.cpnitmref_0 AND bomalt_0 = 99 AND bomseq_0 = 10) INNER JOIN "
        Sql &= "	 bpcustomer bpc ON (mac.bpcnum_0 = bpc.bpcnum_0) INNER JOIN "
        Sql &= "	 bpdlvcust bpd ON (mac.bpcnum_0 = bpd.bpcnum_0 and mac.fcyitn_0 = bpd.bpaadd_0) "
        Sql &= "WHERE yit.cpnitmref_0 IN ('551021','551034','551035','551036','551037','551075') and "
        Sql &= "	  xitn_0 = ' ' and "
        Sql &= "	  datnext_0 >= :desde AND datnext_0 < :hasta and "
        Sql &= "	  bpcsta_0 = 2 and "             'Cliente activo
        Sql &= "	  ostctl_0 = 2  "             'Cliente libre  (no bloqueado)
        Sql &= "ORDER BY mac.bpcnum_0, fcyitn_0"

        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("desde", OracleType.DateTime).Value = Desde
        da.SelectCommand.Parameters.Add("hasta", OracleType.DateTime).Value = Hasta

        da.Fill(dt)
        da.Dispose()

        Return dt

    End Function
    Private Function BuscarParque639(ByVal Desde As Date, ByVal hasta As Date, ByVal Cliente As String, ByVal Sucursal As String) As Parque
        Dim mac As Parque = Nothing
        Dim dt As DataTable

        dt = ObtenerVencimientos639(Desde, hasta, Cliente, Sucursal)

        For Each dr As DataRow In dt.Rows
            mac = New Parque(cn, dr("macnum_0").ToString)
            Exit For
        Next

        Return mac

    End Function
    Private Function BuscarParqueControl(ByVal Desde As Date, ByVal Hasta As Date, ByVal Cliente As String, ByVal Sucursal As String) As Parque
        Dim mac As Parque = Nothing
        Dim dt As DataTable

        dt = ObtenerVencimientos639(Desde, Hasta, Cliente, Sucursal)

        For Each dr As DataRow In dt.Rows
            mac = New Parque(cn, dr("macnum_0").ToString)
            Exit For
        Next

        Return mac

    End Function
    Private Function HayIntervencionAbierta(ByVal Cliente As String, ByVal Suc As String, ByVal Tipo As String) As Boolean
        Dim Sql As String
        Dim da As OracleDataAdapter
        Dim dt As New DataTable
        Dim flg As Boolean = False
        Dim i As Integer 'Cantidad de meses para atras que se busca intervencion creada

        'Resto meses dependiendo el tipo de intervencion consultada
        i = CInt(IIf(Tipo = "A1", 1, 2)) * (-1)

        Sql = "SELECT * "
        Sql &= "FROM interven "
        Sql &= "WHERE bpc_0 = :bpc_0 AND "
        Sql &= "      bpaadd_0 = :bpaadd_0 AND "
        Sql &= "      typ_0 = :typ_0 AND "
        'Sql &= "      zflgtrip_0 NOT IN (5, 8) AND " '22.06.2016 se quita este filtro
        Sql &= "      credat_0 >= :credat_0"

        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("bpc_0", OracleType.VarChar).Value = Cliente
        da.SelectCommand.Parameters.Add("bpaadd_0", OracleType.VarChar).Value = Suc
        da.SelectCommand.Parameters.Add("typ_0", OracleType.VarChar).Value = Tipo
        da.SelectCommand.Parameters.Add("credat_0", OracleType.DateTime).Value = Desde.AddMonths(i)

        da.Fill(dt)
        da.Dispose()

        flg = dt.Rows.Count > 0

        'Ignoro intervencion A1 si tiene codigo de retiro 652011
        If Tipo = "A1" AndAlso flg Then
            Dim itn As New Intervencion(cn)

            For Each dr As DataRow In dt.Rows
                itn.Abrir(dr("num_0").ToString)
                If itn.ExisteRetira("652011") Then
                    flg = False
                    Exit For
                End If
                If itn.ExisteRetira("553011") Then
                    flg = False
                    Exit For
                End If
            Next

            itn = Nothing

        End If

        Return flg

    End Function
    Private Function HayRecargasEnMes(ByVal Cliente As String, ByVal Suc As String) As Boolean
        Dim dt As DataTable

        dt = Parque.ObtenerVtos(cn, Desde, Hasta, Cliente, Suc)

        Return dt.Rows.Count > 0

    End Function
    Private Sub CrearIntervencion(ByVal mac As Parque, ByVal Tipo As String)

        Dim sre As New Solicitud(cn)
        Dim itn As Intervencion
        Dim itm As Articulo
        Dim Precio As Double
        Dim bpa As Sucursal
        Dim bpc As Cliente = mac.Cliente
        Dim Cantidad As Integer = 0


        If bpc.EmpresaFacturacionObligatoria <> "" Then
            cpy.abrir(bpc.EmpresaFacturacionObligatoria)
        Else
            'Si el cliente es RI se fuerza DNY
            If bpc.RegimenImpuesto = "RI" Then
                cpy.abrir("DNY")
            Else
                cpy.abrir(Company(mac.ClienteNumero))
            End If
        End If

        bpa = bpc.Sucursal(mac.SucursalNumero)

        itm = mac.Servicio
        Precio = tar.ObtenerPrecio(bpc, itm.Codigo, cpy.PlantaVenta(False))

        'Creo la nueva Solicitud de Servicio
        sre.Nueva(mac.Cliente, cpy)

        itn = sre.CrearIntervencion(mac.SucursalNumero, Tipo)
        itn.FechaInicio = dtpInicio.Value

        If itm.Codigo = ARTICULO_639 AndAlso bpa.CantidadHidrantes > 0 Then
            Cantidad = bpa.CantidadHidrantes

        Else
            Cantidad = mac.Cantidad

        End If

        itn.AgregarDetalle(itm.Codigo, Cantidad, True, 1, Precio)

        itn.Automatico = True
        itn.Grabar()
        sre.Grabar()

        itn.MarcarEquipos(Desde)

        With Log
            Dim txt As String
            txt = "Intervención Creada: {cliente}-{suc} {tipo} {servicio} {cantidad} {itn}"
            txt = txt.Replace("{cliente}", mac.ClienteNumero)
            txt = txt.Replace("{suc}", mac.SucursalNumero)
            txt = txt.Replace("{tipo}", Tipo)
            txt = txt.Replace("{servicio}", itm.Codigo)
            txt = txt.Replace("{cantidad}", Cantidad.ToString)
            txt = txt.Replace("{itn}", itn.Numero)

            Log.Escribir(txt)
        End With

    End Sub
    Private Sub CrearIntervencion(ByVal dv As DataView, ByVal Tipo As String)
        Dim sre As New Solicitud(cn)
        Dim itn As Intervencion
        Dim bpa As Sucursal
        Dim bpc As New Cliente(cn)
        Dim Cantidad As Integer = 0
        Dim dr As DataRow
        Dim Cli As String
        Dim Suc As String
        Dim Cod As String

        dr = CType(dv.Item(0), DataRowView).Row
        Cli = dr("bpcnum_0").ToString
        Suc = dr("fcyitn_0").ToString

        bpc.Abrir(Cli)

        'Si el cliente es RI se fuerza DNY
        If bpc.RegimenImpuesto = "RI" Then
            cpy.abrir("DNY")
        Else
            cpy.abrir(company(Cli))
        End If

        bpa = bpc.Sucursal(Suc)

        'Creo la nueva Solicitud de Servicio
        sre.Nueva(bpc, cpy)

        itn = sre.CrearIntervencion(Suc, Tipo)
        itn.FechaInicio = dtpInicio.Value
        itn.Automatico = True

        For i = 0 To dv.Count - 1
            dr = CType(dv.Item(i), DataRowView).Row
            Cantidad = CInt(dr("macqty_0"))
            Cod = dr("cpnitmref_0").ToString

            itn.AgregarDetalle(Cod, Cantidad, True, 1, 0)
        Next

        itn.Grabar()
        sre.Grabar()
        itn.MarcarEquipos(Desde)

        With Log
            Dim txt As String
            txt = "Intervención Creada: {cliente}-{suc} {tipo} {servicio} {cantidad} {itn}"
            txt = txt.Replace("{cliente}", Cli)
            txt = txt.Replace("{suc}", Suc)
            txt = txt.Replace("{tipo}", Tipo)
            txt = txt.Replace("{servicio}", "")
            txt = txt.Replace("{cantidad}", "")
            txt = txt.Replace("{itn}", itn.Numero)

            Log.Escribir(txt)
        End With

    End Sub

End Class