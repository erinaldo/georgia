Imports Clases
Imports System.Data.OracleClient

Public Class frm415

    Private Const ARTICULO As String = "553011"

    Private Desde As Date
    Private Hasta As Date
    Private Inicio As Date 'Usada para fecha Inicio en Intervencion
    Private f As Feriados

    Private Sub frm415_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        Dim cpy As New Sociedad(cn)
        Dim bpa As New Sucursal(cn)


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

        cpy.abrir("DNY")

        For Each dr As DataRow In dt.Rows

            If mac.Abrir(dr("macnum_0").ToString) Then
                If bpa.Abrir(mac.ClienteNumero, mac.SucursalNumero) Then
                    If Not bpa.SucursalEntregaActiva Then
                        Continue For
                    End If
                Else
                    Continue For
                End If

                'Creo la nueva Solicitud de Servicio
                sre.Nueva(mac.Cliente, cpy)

                itn = sre.CrearIntervencion(mac.SucursalNumero, "F1")
                itn.FechaInicio = dtpInicio.Value
                itn.AgregarDetalle(ARTICULO, mac.Cantidad, True, 1, 0)
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
        Sql &= "	 bpcustomer bpc ON (mac.bpcnum_0 = bpc.bpcnum_0) inner join "
        Sql &= "	 bpdlvcust bpd on (mac.bpcnum_0 = bpd.bpcnum_0 and mac.fcyitn_0 = bpd.bpaadd_0) "
        Sql &= "WHERE cpnitmref_0 = :art and "
        Sql &= "	  xitn_0 = ' ' and "
        Sql &= "	  bomalt_0 = 99 and "
        Sql &= "	  bomseq_0 = 10 and "
        Sql &= "	  datnext_0 >= :desde AND datnext_0 < :hasta and "
        Sql &= "	  bpcsta_0 = 2 and "             'cliente activo
        Sql &= "	  ostctl_0 = 2 " 'and "             'cliente libre  (no bloqueado)
        'Sql &= "	  xabo_0 <> 2"

        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("art", OracleType.VarChar).Value = ARTICULO
        da.SelectCommand.Parameters.Add("desde", OracleType.DateTime).Value = Desde
        da.SelectCommand.Parameters.Add("hasta", OracleType.DateTime).Value = Hasta

        da.Fill(dt)
        da.Dispose()
        Return dt

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