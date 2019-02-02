Imports System.Data.OracleClient
Imports System.IO
Imports System.Collections

Public Class frmItnAbo

    Const TOPE_LINEA_CONSUMOS As Integer = 800

    Private dIni As Date
    Private dFin As Date
    Private dtRetiros As New DataTable
    Private WithEvents con As New ContratoServicio(cn)
    Private AlertasAdm As New ArrayList
    Private AlertasAbo As New ArrayList

    Private Sub con_Mensaje(ByVal sender As Object, ByVal e As Clases.ContratoEventArgs) Handles con.Mensaje
        AlertasAdm.Add(e.Mensaje)
    End Sub
    Private Sub frmItnAbo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Usado para obtener la estructura de la tabla YITNDET
        Dim Sql As String = "SELECT * FROM yitndet WHERE num_0 = :num_0"
        Dim da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("num_0", OracleType.VarChar)

        Try
            da.FillSchema(dtRetiros, SchemaType.Mapped)
            da.Dispose()

            'Propiedades de las columnas de la tabla YITNDET
            With dtRetiros.Columns
                .Item("numlig_0").AutoIncrement = True
                .Item("numlig_0").AutoIncrementSeed = 1000
                .Item("numlig_0").AutoIncrementStep = 1000
                .Item("num_0").DefaultValue = " "
                .Item("uom_0").DefaultValue = "UN"
                .Item("qty_0").DefaultValue = 0
                .Item("tqty_0").DefaultValue = 0
                .Item("tuom_0").DefaultValue = "UN"
                .Item("yqty2_0").DefaultValue = 0
                .Item("factura_0").DefaultValue = 1
                .Item("typlig_0").DefaultValue = 1
                .Item("amt_0").DefaultValue = 0
                .Item("srenum_0").DefaultValue = " "
            End With

        Catch ex As Exception
        End Try

    End Sub
    Private Sub btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn.Click
        btn.Enabled = False

        'Limpio cuadro de alertas
        txtAlertas.Clear()
        AlertasAbo.Clear()
        AlertasAdm.Clear()

        lstItn.Items.Clear()

        Proceso()

        btn.Enabled = True

        MessageBox.Show("Proceso finalizado", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub
    Private Sub Proceso()
        Dim ss As Solicitud
        Dim dt As New DataTable
        Dim bpa As New Sucursal(cn)
        Dim flgA1 As Boolean = False
        Dim flgC1 As Boolean = False
        Dim eml As New CorreoElectronico

        'Fechas de rango de vencimientos
        dtp.Value = New Date(dtp.Value.Year, dtp.Value.Month, 1)
        dIni = dtp.Value
        dFin = dIni.AddMonths(1)

        'Levantar todos los contratos activos
        dt = RecuperarContratos()

        'Recorro todos los contratos y elimino los que no cubren el mes seleccionado
        For i As Integer = dt.Rows.Count - 1 To 0 Step -1
            Dim dr As DataRow = dt.Rows(i)

            Dim d As Date = CDate(dr("constrdat_0"))
            Dim h As Date = CDate(dr("conenddat_0"))

            If dIni < d Or dIni > h Then dt.Rows.Remove(dr)
        Next

        With pbCon
            .Value = 0
            .Minimum = 0
            .Maximum = dt.Rows.Count
        End With

        'Recorro los contratos
        For Each dr As DataRow In dt.Rows
            pbCon.Value += 1
            Application.DoEvents()

            flgA1 = False
            flgC1 = False

            'Abro el contrato
            con.Abrir(dr("connum_0").ToString)

            'Buscar la SS con el contrato
            ss = SolicitudPorContrato(dr("connum_0").ToString)

            'Salto si no encuentro SS que tenga ese contrato
            If ss Is Nothing Then
                AlertasAdm.Add("No se encontró Solicitud de Servicio para el contrato: " & con.Numero)
                Continue For

            ElseIf ss.Estado <> Solicitud.EstadoSolicitud.Colaborador Then
                AlertasAdm.Add("La Solicitud de Servicio " & ss.Numero & " del contrato " & con.Numero & " está cerrada")
                Continue For

            End If

            'Verifico si se está alcanzando la cantidad de lineas en la SS
            If ss.CantidadConsumos >= TOPE_LINEA_CONSUMOS Then
                AlertasAdm.Add("La Solicitud de Servicio " & ss.Numero & " no tiene mas lugar y se debe generar una nueva")
                Exit Sub
            End If

            'Recorro todas las sucursales cubiertas
            For Each drSuc As DataRow In con.Sucursales.Rows
                'Salto si el codigo de sucursal está en blanco
                If drSuc(1).ToString.Trim = "" Then Continue For
                bpa.Abrir(con.Cliente, drSuc(1).ToString)

                If Not bpa.SucursalEntregaActiva Then
                    AlertasAdm.Add("La sucursal " & drSuc(1).ToString & " del cliente " & con.Cliente & " está desactivada o no es de entrega")
                    Continue For
                End If

                If ProcesoA1(dIni, dFin, con, bpa, ss) Then flgA1 = True
                If ProcesoC1(dIni, dFin, con, bpa, ss) Then flgC1 = True

            Next

            'Si el contrato vence es mes aviso mando mail con aviso
            If usr.Codigo <> "MMIN" AndAlso dFin > con.FechaHasta AndAlso (flgA1 OrElse flgC1) Then

                Dim txt As String
                Dim bpc As New Cliente(cn)

                bpc.Abrir(con.Cliente)

                txt = "El contrato nro {nro} del cliente {bpcnum} {bpcnam} vence el {vto}" & vbCrLf & vbCrLf
                txt &= "COBERTURA DEL CONTRATO" & vbCrLf
                txt &= DetalleCoberturaContrato(con)

                txt = txt.Replace("{nro}", con.Numero)
                txt = txt.Replace("{bpcnum}", bpc.Codigo)
                txt = txt.Replace("{bpcnam}", bpc.Nombre)
                txt = txt.Replace("{vto}", con.FechaHasta.ToString("dd/MM/yyyy"))

                Try
                    eml.Nuevo()
                    eml.Remitente(usr.Mail, usr.Nombre)
                    eml.AgregarDestinatario(bpc.Vendedor.Mail)
                    eml.AgregarDestinatarioArchivo("mails\contrato.txt", 1)

                    eml.Asunto = "Aviso de contrato a vencer"
                    eml.Cuerpo = txt
                    eml.EsHtml = False

                    eml.Enviar()

                Catch ex As Exception
                End Try

            End If

        Next

        'Guardo archivo log
        AlertasAbo.Sort()
        AlertasAdm.Sort()

        Dim NombreArchivo As String = "Intervenciones Automaticas Abonos_" & Now.ToString("dd-MM-yy_HHmmss") & ".log "
        Dim sw As New StreamWriter("logs\" & NombreArchivo)

        sw.WriteLine("Fecha: " & Now.ToString("dd/MM/yy HH:mm"))
        sw.WriteLine("Usuario: " & usr.Codigo & " - " & usr.Nombre)
        sw.WriteLine("Vencimientos: " & dIni.ToString("MM/yyyy"))
        sw.WriteLine("")

        For Each s As String In AlertasAdm
            sw.WriteLine(s)
        Next

        sw.WriteLine("")

        For Each s As String In AlertasAbo
            sw.WriteLine(s)
        Next

        sw.Close()

        'Envio log con los alertas
        With eml
            .Nuevo()
            .Remitente(usr.Mail) '"noreply@matafuegosgeorgia.com")
            .AgregarDestinatarioArchivo("mails\itn_auto_abonos.txt", 1)
            .Asunto = "Alertas de Intervenciones Automáticas " & Today.ToString("dd/MM/yy")
            .CuerpoDesdeArchivo("logs\" & NombreArchivo)
            .AdjuntarArchivo(NombreArchivo)
            .EsHtml = False
            .Enviar()
        End With

        txtAlertas.Text = eml.Cuerpo

    End Sub
    Private Sub CrearIntervencion(ByVal ss As Solicitud, ByVal dt As DataTable, ByVal Suc As String, ByVal Tipo As String, ByVal dIni As Date, ByVal dFin As Date)
        Dim itn As Intervencion
        Dim t As String

        'Creo la intervencion
        itn = ss.CrearIntervencion(Suc, Tipo)
        itn.AgregarDetalle(dtRetiros)
        itn.Automatico = True
        itn.FechaInicio = DiaHabil(dtp.Value)

        itn.Grabar()
        itn.MarcarEquipos(dIni, dFin)

        t = itn.Numero & "-"
        t &= itn.Tipo & " "
        t &= itn.Cliente.Codigo & "-" & itn.SucursalCodigo

        lstItn.Items.Add(t)
        Application.DoEvents()

    End Sub
    Private Sub AgregarRetiro(ByVal Art As String, ByVal Cant As Integer, Optional ByVal Tipo As Integer = 1)
        Dim dr As DataRow
        dr = dtRetiros.NewRow
        dr("itmref_0") = Art
        dr("tqty_0") = Cant
        dr("typlig_0") = Tipo
        dtRetiros.Rows.Add(dr)
    End Sub

    Private Function ProcesoA1(ByVal dIni As Date, ByVal dFin As Date, ByVal con As ContratoServicio, ByVal bpa As Sucursal, ByVal ss As Solicitud) As Boolean
        Dim Cod As String
        Dim dtVtos As DataTable
        Dim drVtos As DataRow

        dtRetiros.Clear()

        'Incluyo visita mensual
        Cod = "652006"
        If con.ArticuloCubierto(Cod) AndAlso Not ExisteIntervencionA1(con.Cliente, bpa.Sucursal, Cod) Then
            'AgregarRetiro(Cod, con.CoberturaPorArticulo("451"))
            dtVtos = Vencimientos(con, bpa.Sucursal, dIni, dFin, Cod)

            If dtVtos.Rows.Count > 0 Then
                drVtos = dtVtos.Rows(0)
                AgregarRetiro(drVtos("itmref_0").ToString, CInt(drVtos("cant")))
            ElseIf Not Vencimientos(con, bpa.Sucursal, dIni.AddMonths(-2), dFin.AddYears(+5), Cod, True).Rows.Count > 0 Then
                'Alerta(con, ss, bpa.Sucursal, "No se encontro parque " & Cod)
                AlertasAbo.Add("El contrato " & con.Numero & " cubre el servicio " & Cod & " pero no se encontró el parque en el cliente " & con.Cliente & "-" & bpa.Sucursal)
            End If
        End If
        'Incluyo visita mensual hidrantes
        Cod = "652010"
        If con.ArticuloCubierto(Cod) AndAlso Not ExisteIntervencionA1(con.Cliente, bpa.Sucursal, Cod) Then
            'AgregarRetiro(Cod, con.CoberturaPorArticulo("505"))
            dtVtos = Vencimientos(con, bpa.Sucursal, dIni, dFin, Cod)

            If dtVtos.Rows.Count > 0 Then
                drVtos = dtVtos.Rows(0)
                AgregarRetiro(drVtos("itmref_0").ToString, CInt(drVtos("cant")))
            ElseIf Not Vencimientos(con, bpa.Sucursal, dIni.AddMonths(-2), dFin.AddYears(+5), Cod, True).Rows.Count > 0 Then
                AlertasAbo.Add("El contrato " & con.Numero & " cubre el servicio " & Cod & " pero no se encontró el parque en el cliente " & con.Cliente & "-" & bpa.Sucursal)
            End If
        End If
        'Incluyo Control Periódico 652002
        Cod = "652002"
        If con.ArticuloCubierto(Cod) Then
            If Not ExisteIntervencionA1(con.Cliente, bpa.Sucursal, Cod) Then

                dtVtos = Vencimientos(con, bpa.Sucursal, dIni, dFin, Cod)

                If dtVtos.Rows.Count > 0 Then
                    drVtos = dtVtos.Rows(0)
                    AgregarRetiro(drVtos("itmref_0").ToString, CInt(drVtos("cant")))

                ElseIf Not Vencimientos(con, bpa.Sucursal, dIni.AddMonths(-2), dFin.AddYears(+5), Cod, True).Rows.Count > 0 Then
                    AlertasAbo.Add("El contrato " & con.Numero & " cubre el servicio " & Cod & " pero no se encontró el parque en el cliente " & con.Cliente & "-" & bpa.Sucursal)
                End If
            End If
        End If
        'Se incluye únicamente por si alguien cargo el codigo por error. 
        Cod = "652001"
        If con.ArticuloCubierto(Cod) Then
            If Not ExisteIntervencionA1(con.Cliente, bpa.Sucursal, Cod) Then

                dtVtos = Vencimientos(con, bpa.Sucursal, dIni, dFin, Cod)

                If dtVtos.Rows.Count > 0 Then
                    drVtos = dtVtos.Rows(0)
                    AgregarRetiro(drVtos("itmref_0").ToString, CInt(drVtos("cant")))

                ElseIf Not Vencimientos(con, bpa.Sucursal, dIni.AddMonths(-2), dFin.AddYears(+5), Cod, True).Rows.Count > 0 Then
                    AlertasAbo.Add("El contrato " & con.Numero & " cubre el servicio " & Cod & " pero no se encontró el parque en el cliente " & con.Cliente & "-" & bpa.Sucursal)
                End If
            End If
        End If

        'Incluyo Control Lavaojos
        Cod = "659021"
        If con.ArticuloCubierto(Cod) AndAlso Not ExisteIntervencionA1(con.Cliente, bpa.Sucursal, Cod) Then
            dtVtos = Vencimientos(con, bpa.Sucursal, dIni, dFin, Cod)

            If dtVtos.Rows.Count > 0 Then
                drVtos = dtVtos.Rows(0)
                AgregarRetiro(drVtos("itmref_0").ToString, CInt(drVtos("cant")))
            Else
                AlertasAbo.Add("El contrato " & con.Numero & " cubre el servicio " & Cod & " pero no se encontró el parque en el cliente " & con.Cliente & "-" & bpa.Sucursal)
            End If

        End If

        'Se eliminan los articulos que exceden cobertura
        con.EliminarCoberturaExcedida(dtRetiros, bpa)

        If dtRetiros.Rows.Count > 0 Then
            CrearIntervencion(ss, dtRetiros, bpa.Sucursal, "A1", dIni, dFin)
        End If

        Return dtRetiros.Rows.Count > 0

    End Function
    Private Function ProcesoC1(ByVal dIni As Date, ByVal dFin As Date, ByVal con As ContratoServicio, ByVal bpa As Sucursal, ByVal ss As Solicitud) As Boolean
        Dim dtVtos As DataTable
        Dim PrestamosExt As Integer = 0
        Dim PrestamosMan As Integer = 0
        Dim Cant As Integer = 0
        Dim a As String = ""

        dtRetiros.Clear()

        If con.Unificacion > 0 Then
            dIni = dIni.AddMonths(-1 * (con.Unificacion - 1))
            dFin = dFin.AddMonths(con.Unificacion - 1)
        End If

        'Si la fecha fin sobrepasa la fecha cobertura del contrato
        'If dFin > con.FechaHasta.AddDays(1) Then
        '    dFin = con.FechaHasta
        '    dFin = New Date(dFin.Year, dFin.Month, 1)
        '    dFin = dFin.AddMonths(1)
        'End If

        '******
        ' Si no hay vto en el mes actual, no se genera intervención
        Dim dtx As DataTable
        dtx = Vencimientos(con, bpa.Sucursal, dtp.Value, dtp.Value.AddMonths(1))

        If dtx.Rows.Count = 0 Then Exit Function

        dtx.Dispose()
        dtx = Nothing
        '******

        'Obtengo los vencimientos de la sucursal
        dtVtos = Vencimientos(con, bpa.Sucursal, dIni, dFin)

        'Recorro todos los vencimientos
        If dtVtos.Rows.Count = 0 Then Exit Function

        'Salgo si existe una intervencion anterior abierta
        a = ExisteIntervencionC1Abierta(con.Cliente, bpa.Sucursal)
        If a <> "" Then
            AlertasAbo.Add("Se encontró vencimiento pero aún existe pendiente de retiro la intervencion " & a & " en el cliente " & con.Cliente & "-" & bpa.Sucursal)
            Exit Function
        End If

        'Busco la fecha de la ultima intervencion
        Dim FechaItn As Date
        FechaItn = FechaUltimaIntervencion(con.Cliente, bpa.Sucursal)

        'Salto si aun falta para el proximo retiro segun la unificacion
        If FechaItn > dIni Then
            AlertasAbo.Add("Se encontró en el cliente " & con.Cliente & "-" & bpa.Sucursal & " vencimiento que debía retirarse por unificación en " & FechaItn.ToString("MMMM/yyyy") & " según contrato " & con.Numero & " (cada " & con.Unificacion & " meses)")
            Exit Function
        End If

        For Each drVtos As DataRow In dtVtos.Rows
            'Agrego si está cubierto por el contrato
            If con.ArticuloCubierto(drVtos("itmref_0").ToString) Then
                Cant = CInt(drVtos("cant"))

                If drVtos("itmref_0").ToString.StartsWith("451") Then
                    PrestamosExt += Cant
                Else
                    PrestamosMan += Cant
                End If

                Dim drRet As DataRow
                drRet = dtRetiros.NewRow

                AgregarRetiro(drVtos("itmref_0").ToString, Cant)
            End If
        Next

        If dtRetiros.Rows.Count = 0 Then Exit Function

        'Verifico que no se exceda la cobertura del contrato
        If dtRetiros.Rows.Count > 0 AndAlso Not con.VerificarCobertura(dtRetiros, bpa.Sucursal) Then
            Exit Function
        End If

        'Agrego los prestamos
        If PrestamosExt > 0 Then AgregarRetiro("601003", PrestamosExt, 2)
        If PrestamosMan > 0 Then AgregarRetiro("607003", PrestamosMan, 2)

        CrearIntervencion(ss, dtRetiros, bpa.Sucursal, "C1", dIni, dFin)

        Return True

    End Function
    Private Function RecuperarContratos(Optional ByVal Modo As Integer = 0) As DataTable
        Dim da As OracleDataAdapter
        Dim dt As New DataTable
        Dim sql As String = ""

        sql = "select distinct con.connum_0, constrdat_0, conenddat_0 "
        sql &= "from contserv con inner join contcob cob on (con.connum_0 = cob.connum_0) "
        sql &= "where rsiflg_0 <> 2 and "
        sql &= "	  fddflg_0 <> 2 and "
        sql &= "	  xsuspend_0 <> 2 and "
        sql &= "      cod_0 = '451' "

        da = New OracleDataAdapter(sql, cn)

        da.Fill(dt)
        da.Dispose()

        Return dt

    End Function
    Private Function SolicitudPorContrato(ByVal Contrato As String) As Solicitud
        Dim ss As Solicitud = Nothing
        Dim da As OracleDataAdapter
        Dim sql As String
        Dim dt As New DataTable
        Dim dr As DataRow

        sql = "select * "
        sql &= "from serrequest "
        sql &= "where conspt_0 = :cont "
        sql &= "order by credat_0 desc"

        da = New OracleDataAdapter(sql, cn)
        da.SelectCommand.Parameters.Add("cont", OracleType.VarChar).Value = Contrato
        da.Fill(dt)
        da.Dispose()

        For Each dr In dt.Rows
            ss = New Solicitud(cn)
            ss.Abrir(dr("srenum_0").ToString)
            Exit For
        Next

        Return ss

    End Function
    Private Function Vencimientos(ByVal con As ContratoServicio, ByVal suc As String, ByVal Ini As Date, ByVal Fin As Date) As DataTable
        Dim Sql As String
        Dim da As OracleDataAdapter
        Dim dt As New DataTable

        Sql = "SELECT itm.itmref_0, SUM(mac.macqty_0) AS CANT "
        Sql &= "FROM (((machines mac INNER JOIN ymacitm ymc ON (mac.macnum_0 = ymc.macnum_0)) INNER JOIN bomd bmd ON (macpdtcod_0 = itmref_0 AND ymc.cpnitmref_0 = bmd.cpnitmref_0)) INNER JOIN bpcustomer bpc ON (mac.bpcnum_0 = bpc.bpcnum_0)) INNER JOIN itmmaster itm ON (ymc.cpnitmref_0 = itm.itmref_0) "
        Sql &= "WHERE bomalt_0 = 99 AND "
        Sql &= "	  bomseq_0 = 10 AND "
        Sql &= "	  macitntyp_0 = 1 AND "
        Sql &= "	  datnext_0 >= :datnext_0a AND "
        Sql &= "	  datnext_0 <  :datnext_0b AND "
        Sql &= "	  mac.bpcnum_0 = :bpcnum_0 AND "
        Sql &= " 	  mac.fcyitn_0 = :fcyitn_0 AND "
        Sql &= "	  mac.xitn_0 IN (' ', 'X0')  and "
        Sql &= "	  cfglin_0 in ('451', '505') "
        Sql &= "GROUP BY itm.itmref_0"

        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("bpcnum_0", OracleType.VarChar).Value = con.Cliente
        da.SelectCommand.Parameters.Add("fcyitn_0", OracleType.VarChar).Value = suc
        da.SelectCommand.Parameters.Add("datnext_0a", OracleType.DateTime).Value = Ini
        da.SelectCommand.Parameters.Add("datnext_0b", OracleType.DateTime).Value = Fin

        da.Fill(dt)
        da.Dispose()

        Return dt

    End Function
    Private Function Vencimientos(ByVal con As ContratoServicio, ByVal suc As String, ByVal Ini As Date, ByVal Fin As Date, ByVal Art As String, Optional ByVal si As Boolean = False) As DataTable
        Dim Sql As String
        Dim da As OracleDataAdapter
        Dim dt As New DataTable

        Sql = "SELECT itm.itmref_0, SUM(mac.macqty_0) AS CANT "
        Sql &= "FROM (((machines mac INNER JOIN ymacitm ymc ON (mac.macnum_0 = ymc.macnum_0)) INNER JOIN bomd bmd ON (macpdtcod_0 = itmref_0 AND ymc.cpnitmref_0 = bmd.cpnitmref_0)) INNER JOIN bpcustomer bpc ON (mac.bpcnum_0 = bpc.bpcnum_0)) INNER JOIN itmmaster itm ON (ymc.cpnitmref_0 = itm.itmref_0) "
        Sql &= "WHERE bomalt_0 = 99 AND "
        Sql &= "	  bomseq_0 = 10 AND "
        Sql &= "	  macitntyp_0 = 1 AND "
        Sql &= "	  datnext_0 >= :datnext_0a AND "
        Sql &= "	  datnext_0 <  :datnext_0b AND "
        Sql &= "	  mac.bpcnum_0 = :bpcnum_0 AND "
        Sql &= " 	  mac.fcyitn_0 = :fcyitn_0 AND "
        If si = False Then
            Sql &= "	  mac.xitn_0 IN (' ', 'X0')  and "
        End If
        Sql &= "      ymc.cpnitmref_0 = :cpnitmref_0 "
        Sql &= "GROUP BY itmref_0"

        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("bpcnum_0", OracleType.VarChar).Value = con.Cliente
        da.SelectCommand.Parameters.Add("fcyitn_0", OracleType.VarChar).Value = suc
        da.SelectCommand.Parameters.Add("datnext_0a", OracleType.DateTime).Value = Ini
        da.SelectCommand.Parameters.Add("datnext_0b", OracleType.DateTime).Value = Fin
        da.SelectCommand.Parameters.Add("cpnitmref_0", OracleType.VarChar).Value = Art

        da.Fill(dt)
        da.Dispose()

        Return dt

    End Function
    Private Function FechaUltimaIntervencion(ByVal bpc As String, ByVal suc As String) As Date
        Dim da As OracleDataAdapter
        Dim dt As New DataTable
        Dim sql As String
        Dim f As Date = #12/31/1599#
        Dim i As Integer

        sql = "select xrc.fecha_0 "
        sql &= "from xrutac xrc inner join xrutad xrd on (xrc.ruta_0 = xrd.ruta_0) "
        sql &= "	 inner join interven itn on (xrd.vcrnum_0 = itn.num_0) "
        sql &= "where itn.typ_0 = 'C1' and "
        sql &= "	  estado_0 = 3 and "
        sql &= "	  itn.bpc_0 = :bpc and "
        sql &= "	  itn.bpaadd_0 = :bpaadd and "
        sql &= "	  itn.xauto_0 = 2 "
        sql &= "order by xrc.fecha_0 desc"
        da = New OracleDataAdapter(sql, cn)
        da.SelectCommand.Parameters.Add("bpc", OracleType.VarChar).Value = bpc
        da.SelectCommand.Parameters.Add("bpaadd", OracleType.VarChar).Value = suc
        da.Fill(dt)
        da.Dispose()

        If dt.Rows.Count > 0 Then f = CDate(dt.Rows(0).Item(0))

        If f <> #12/31/1599# Then
            i = f.Day - 1
            i = i * (-1)
            f = f.AddDays(i)
        End If

        Return f

    End Function
    Private Function FechaUltimaIntervencionA1(ByVal bpc As String, ByVal suc As String, ByVal Cod As String) As Date
        Dim da As OracleDataAdapter
        Dim dt As New DataTable
        Dim sql As String
        Dim f As Date = #12/31/1599#
        Dim i As Integer

        sql = "select xrc.fecha_0 "
        sql &= "from xrutac xrc inner join xrutad xrd on (xrc.ruta_0 = xrd.ruta_0) "
        sql &= "	 inner join interven itn on (xrd.vcrnum_0 = itn.num_0) "
        sql &= "     inner join yitndet yit on (itn.num_0 = yit.num_0 and typlig_0 = 1) "
        sql &= "where itn.typ_0 = 'A1' and "
        sql &= "	  estado_0 = 3 and "
        sql &= "	  itn.bpc_0 = :bpc and "
        sql &= "	  itn.bpaadd_0 = :bpaadd and "
        sql &= "      yit.itmref_0 = :itmref "
        sql &= "order by xrc.fecha_0 desc"
        da = New OracleDataAdapter(sql, cn)
        da.SelectCommand.Parameters.Add("bpc", OracleType.VarChar).Value = bpc
        da.SelectCommand.Parameters.Add("bpaadd", OracleType.VarChar).Value = suc
        da.SelectCommand.Parameters.Add("itmref", OracleType.VarChar).Value = Cod
        da.Fill(dt)
        da.Dispose()

        If dt.Rows.Count > 0 Then f = CDate(dt.Rows(0).Item(0))

        If f <> #12/31/1599# Then
            i = f.Day - 1
            i = i * (-1)
            f = f.AddDays(i)
        End If

        Return f

    End Function
    Private Function ExisteIntervencionA1(ByVal bpc As String, ByVal suc As String, ByVal cod As String) As Boolean
        Dim flg As Boolean = False
        Dim sql As String
        Dim dt As New DataTable
        Dim da As OracleDataAdapter

        sql = "select itn.* "
        sql &= "from interven itn inner join yitndet yit on (itn.num_0 = yit.num_0) "
        sql &= "where dat_0 >= :desde and dat_0 < :hasta and "
        sql &= "	 itmref_0 = :cod and "
        sql &= "	 itn.bpc_0 = :bpc and "
        sql &= "	 itn.bpaadd_0 = :suc"

        da = New OracleDataAdapter(sql, cn)
        With da.SelectCommand.Parameters
            .Add("desde", OracleType.DateTime).Value = dIni
            .Add("hasta", OracleType.DateTime).Value = dFin
            .Add("cod", OracleType.VarChar).Value = cod
            .Add("bpc", OracleType.VarChar).Value = bpc
            .Add("suc", OracleType.VarChar).Value = suc
        End With

        da.Fill(dt)
        flg = dt.Rows.Count > 0
        da.Dispose()
        dt.Dispose()

        Return flg

    End Function
    Private Function ExisteIntervencionC1Abierta(ByVal bpc As String, ByVal suc As String) As String
        Dim flg As Boolean = False
        Dim sql As String
        Dim dt As New DataTable
        Dim da As OracleDataAdapter
        Dim Nro As String = ""

        sql = "select itn.* "
        sql &= "from interven itn inner join yitndet yit on (itn.num_0 = yit.num_0) "
        sql &= "where dat_0 >= :desde and dat_0 < :hasta and "
        sql &= "	 itn.typ_0 = 'C1' and "
        sql &= "	 itn.zflgtrip_0 = 1 and "
        sql &= "	 itn.bpc_0 = :bpc and "
        sql &= "	 itn.bpaadd_0 = :suc"

        da = New OracleDataAdapter(sql, cn)
        With da.SelectCommand.Parameters
            .Add("desde", OracleType.DateTime).Value = dIni
            .Add("hasta", OracleType.DateTime).Value = dFin
            .Add("bpc", OracleType.VarChar).Value = bpc
            .Add("suc", OracleType.VarChar).Value = suc
        End With

        da.Fill(dt)

        If dt.Rows.Count > 0 Then
            Dim dr As DataRow
            dr = dt.Rows(0)

            Nro = dr("num_0").ToString
        End If

        da.Dispose()
        dt.Dispose()

        Return Nro

    End Function
    Private Function DiaHabil(ByVal f As Date) As Date
        Dim fe As New Feriados(cn)

        'Si el dia f es menor al actual
        If f <= Today Then f = Today.AddDays(1)

        Do While f.DayOfWeek = DayOfWeek.Sunday OrElse f.DayOfWeek = DayOfWeek.Saturday OrElse fe.Existe(f)
            f = f.AddDays(1)
        Loop

        fe = Nothing

        Return f

    End Function
    Private Function DetalleCoberturaContrato(ByVal con As ContratoServicio) As String
        Dim da As OracleDataAdapter
        Dim sql As String
        Dim dt As New DataTable
        Dim l As String = "{cod} {des}..... Cant: {qty}" & vbCrLf

        sql = "select cod_0, cfglindes_0 AS des_0, covqty_0 "
        sql &= "from contcob inner join tablincfg on (cod_0 = cfglin_0) "
        sql &= "where connum_0 = :con and covtyp_0 = 4"
        sql &= "union "
        sql &= "select cod_0, itmdes1_0, covqty_0 "
        sql &= "from contcob inner join itmmaster on (cod_0 = itmref_0) "
        sql &= "where connum_0 = :con and covtyp_0 = 2"
        da = New OracleDataAdapter(sql, cn)
        da.SelectCommand.Parameters.Add("con", OracleType.VarChar).Value = con.Numero

        Try
            da.Fill(dt)

        Catch ex As Exception
        End Try

        sql = ""

        For Each dr As DataRow In dt.Rows
            sql &= l
            sql = sql.Replace("{cod}", dr("cod_0").ToString)
            sql = sql.Replace("{des}", dr("des_0").ToString)
            sql = sql.Replace("{qty}", dr("covqty_0").ToString)
        Next
        da.Dispose()
        dt.Dispose()
        da = Nothing
        dt = Nothing

        Return sql

    End Function

End Class