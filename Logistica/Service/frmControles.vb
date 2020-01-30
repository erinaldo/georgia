Imports System.Data.OracleClient

Public Class frmControles
    'Cantidad minima de controles para poder crear la intervencion
    Private dtYitndet As New DataTable  'Tabla con todos los vencimientos del cliente
    Private dtRetiros As DataTable 'Tabla con los vencimientos segun tipo de intervencion (A1, B1, etc)
    Dim tar As New Tarifa(cn)
    Dim bpc As New Cliente(cn)

    Private Desde As Date
    Private Hasta As Date
    Private Inicio As Date 'Usada para fecha Inicio en Intervencion
    Private f As Feriados

    Private Sub frmControles_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim fecha As Date = Today.AddDays(1)

        f = New Feriados(cn)

        'Busco el primer dia habil
        While fecha.DayOfWeek = DayOfWeek.Saturday Or fecha.DayOfWeek = DayOfWeek.Sunday Or f.Existe(fecha)
            fecha = fecha.AddDays(1)
        End While

        dtpInicio.MinDate = fecha

    End Sub

    'Sub
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
                    GenerarIntervenciones()

                End If

        End Select

        btn.Enabled = True

    End Sub
    Private Sub GenerarIntervenciones()
        Dim dt As New DataTable
        Dim mac As New Parque(cn)
        Dim i As Integer = 0
        Dim itn As Intervencion
        Dim sre As New Solicitud(cn)
        Dim Precio As Double
        Dim Tar As New Tarifa(cn)
        Dim itm As New Articulo(cn)
        Dim txt As String = ""
        Dim bpa As New Sucursal(cn)

        itm.Abrir("652001")

        'Calculo fecha Desde/Hasta
        Desde = mCal.SelectionRange.Start
        Desde = New Date(Desde.Year, Desde.Month, 1)
        Hasta = Desde.AddMonths(1)

        'Calculo el primer dia habil del mes
        Inicio = Desde
        Do While f.Existe(Inicio) Or Inicio.DayOfWeek = DayOfWeek.Saturday Or Inicio.DayOfWeek = DayOfWeek.Sunday
            Inicio = Inicio.AddDays(1)
        Loop

        'Obtengo los controles a hacer en el mes
        dt = ObtenerVencimientos()

        For Each dr As DataRow In dt.Rows
            'If dr("macnum_0").ToString <> "00427529" Then Continue For

            If mac.Abrir(dr("macnum_0").ToString) Then

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
                    If Not bpa.SucursalEntregaActiva Then Continue For
                Else
                    Continue For
                End If
                'No se crea intervencion si la cantidad de controles no supera el minimo
                If mac.Cantidad < CP_CANTIDAD_MINIMA_REQUERIDA Then Continue For

                'Buscar que no haya intervenciones abiertas A1
                If HayIntervencionAbierta(mac.ClienteNumero, mac.SucursalNumero, "A1") Then Continue For

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

                    Continue For
                End If

                'Comienzo a crear la intervencion
                Dim cpy As New Sociedad(cn)
                cpy.abrir(company(mac.ClienteNumero))
                bpc.Abrir(mac.ClienteNumero)

                Precio = Tar.ObtenerPrecio(bpc, itm, cpy.PlantaVenta(False))

                'Creo la nueva Solicitud de Servicio
                sre.Nueva(mac.Cliente, cpy)

                itn = sre.CrearIntervencion(mac.SucursalNumero, "A1")
                itn.FechaInicio = dtpInicio.Value
                itn.AgregarDetalle(itm.Codigo, mac.Cantidad, True, 1, Precio)
                itn.Automatico = True
                itn.Grabar()
                sre.Grabar()

                itn.MarcarEquipos(Desde)

                Label1.Text = "Intervencion creada: " & itn.Numero
                Application.DoEvents()

                i += 1

            End If
        Next

        Label1.Text = "Proceso finalizado" & vbCrLf
        Label1.Text &= i.ToString & " intevenciones creadas"

        MessageBox.Show(Label1.Text, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub
    Private Function ObtenerVencimientos() As DataTable
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
    Private Sub mCal_DateChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DateRangeEventArgs) Handles mCal.DateChanged
        Dim d As Date

        d = mCal.SelectionRange.Start
        d = New Date(d.Year, d.Month, 1)

        While d.DayOfWeek = DayOfWeek.Saturday Or d.DayOfWeek = DayOfWeek.Sunday
            d = d.AddDays(1)
        End While

        If d > dtpInicio.MinDate Then dtpInicio.Value = d

    End Sub

End Class