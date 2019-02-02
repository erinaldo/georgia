Imports System.Data.OracleClient
Imports System.IO
Imports System.Collections

Public Class frmExportarUnigis
    Private sw As StreamWriter
    Private Fecha As Date
    Private dtPartes As New DataTable
    Private dvPartes As DataView
    Private fe As New Feriados(cn)
    'Array con los tipos de intervencion a exportar
    Private TiposIntervencion As New ArrayList

    Private Sub frmExportarUnigis_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim tb As New TablaVaria(cn, 407, False)
        tb.EnlazarListBox(lstTipoIntervencion)
    End Sub
    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        Dim f1, f2 As Date
        Dim txt As String

        If lstTipoIntervencion.SelectedItems.Count = 0 AndAlso chkExportarRemitos.Checked = False Then
            MessageBox.Show("Debe seleccionar algo para exportar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        'Pongo en el array los tipos de intervencion seleccionados por el usuario
        TiposIntervencion.Clear()
        For i As Integer = 0 To lstTipoIntervencion.SelectedItems.Count - 1
            Dim dr As DataRowView = CType(lstTipoIntervencion.SelectedItems(i), DataRowView)
            Dim s As String = dr("ident2_0").ToString
            TiposIntervencion.Add(s)
        Next

        f1 = Now

        Fecha = mcal.SelectionRange.Start

        mcal.Enabled = False
        btnExportar.Enabled = False

        Procesar()

        f2 = Now

        txt = "Proceso Finalizado" & vbCrLf & vbCrLf
        txt &= "Inicio: " & f1.ToLongTimeString & vbCrLf
        txt &= "Fin: " & f2.ToLongTimeString

        MessageBox.Show(txt, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        mcal.Enabled = True
        btnExportar.Enabled = True

    End Sub
    Private Sub Procesar()
        Dim dt As New DataTable
        Dim doc As New Documento(cn)
        Dim itn As New Intervencion(cn)
        Dim rto As New Remito(cn)
        Dim Arch As String = ""
        Dim i As Integer = 0

        'Seleccionar Archivo
        sd.ShowDialog(Me)
        If sd.FileName = "" Then Exit Sub

        sw = New StreamWriter(sd.FileName)

        'Obtengo partes de cobranzas
        ParteCobranzas()

        'Cabecera de Archivo
        CabeceraArchivo()

        'Exportación de Intervenciones
        lbl.Visible = True
        If TiposIntervencion.Count > 0 Then dt = Intervenciones()

        Dim x As Integer = dt.Rows.Count

        For Each dr As DataRow In dt.Rows
            i += 1
            lbl.Text = "Intervención " & i.ToString & " de " & dt.Rows.Count.ToString & " - " & dr(0).ToString
            Application.DoEvents()

            'Verifico que el tipo de intervencion figure en el array de intervenciones seleccionadas
            If TiposIntervencion.IndexOf(dr("typ_0").ToString) = -1 Then Continue For

            itn.Abrir(dr(0).ToString)

            'Excluir D1 en estado pendiente
            If itn.Tipo = "D1" AndAlso itn.Estado = 1 Then Continue For
            GrabarLineaDocumento(itn)
        Next

        'Exportación de Remitos
        i = 0
        dt.Clear()
        If chkExportarRemitos.Checked Then dt = Remitos()
        For Each dr As DataRow In dt.Rows
            i += 1
            lbl.Text = "Remito " & i.ToString & " de " & dt.Rows.Count.ToString & " - " & dr(0).ToString
            Application.DoEvents()
            rto.Abrir(dr(0).ToString)
            GrabarLineaDocumento(rto)
        Next

        sw.Close()
        sw.Dispose()
    End Sub
    Private Function Intervenciones() As DataTable
        Dim Sql As String
        Dim da As OracleDataAdapter
        Dim dt As New DataTable

        Sql = "SELECT num_0, typ_0 "
        Sql &= "FROM interven "
        Sql &= "WHERE zflgtrip_0 in (1,4,6) AND "
        Sql &= "      xsector_0 in (' ', 'LOG', 'ABO', 'ING') AND "
        Sql &= "      tripnum_0 = ' ' AND "
        Sql &= "      dat_0 < :dat_0 AND "
        Sql &= "      dat_0 >= to_date('01/01/2017', 'dd/mm/yyyy') and "
        Sql &= "      not (typ_0 = 'D1' AND zflgtrip_0 = 1) and "
        Sql &= "      mdl_0 = '1'"

        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("dat_0", OracleType.DateTime).Value = mcal.SelectionRange.Start
        da.Fill(dt)
        da.Dispose()

        Return dt

    End Function
    Private Function Remitos() As DataTable
        Dim Sql As String
        Dim da As OracleDataAdapter
        Dim dt As New DataTable

        Sql = "select distinct sdh.sdhnum_0 "
        Sql &= "FROM sdelivery sdh inner join sdeliveryd sdd on (sdh.sdhnum_0 = sdd.sdhnum_0) "
        Sql &= "where xsector_0 in ('LOG', 'ABO') and "
        Sql &= "	  xruta_0 = ' ' and "
        Sql &= "	  xsalio_0 <> 2 and "
        Sql &= "	  xflgrto_0 <> 5 and "
        Sql &= "	  rtnqty_0 < qty_0 and "
        Sql &= "      sdh.credat_0 >= to_date('01/01/2017', 'dd/mm/yyyy') and "
        Sql &= "      mdl_0 = '1'"

        da = New OracleDataAdapter(Sql, cn)
        da.Fill(dt)
        da.Dispose()

        Return dt

    End Function
    Private Sub ParteCobranzas()
        Dim Sql As String
        Dim da As OracleDataAdapter

        Sql = "select sih.num_0, sih.sihorinum_0 "
        Sql &= "from gaccdudate gac inner join sinvoicev sih on (gac.num_0 = sih.num_0) "
        Sql &= "where ycobdat_0 = :p1 and "
        Sql &= "	  ybprpth_0 = :p2 and "
        Sql &= "	  sihorinum_0 <> ' '"

        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("p1", OracleType.DateTime).Value = Fecha
        da.SelectCommand.Parameters.Add("p2", OracleType.VarChar).Value = "C006"

        Try
            dtPartes.Clear()
            da.Fill(dtPartes)
            dvPartes = New DataView(dtPartes)

        Catch ex As Exception
        End Try

    End Sub
    Private Function HayParte(ByVal Doc As IRuteable) As Boolean
        dvPartes.RowFilter = "sihorinum_0 = '" & Doc.Numero & "'"
        Return dvPartes.Count > 0
    End Function
    Private Sub CabeceraArchivo()
        GrabarCampo("TIPO-TAREA")
        GrabarCampo("TIPO-INTERVENCIN")
        GrabarCampo("ABONADO")
        GrabarCampo("DOCUMENTO")
        GrabarCampo("CODIGO-SUCURSAL")
        GrabarCampo("DOMICILIO")
        GrabarCampo("LOCALIDAD")
        GrabarCampo("PROVINCIA")
        GrabarCampo("CODIGO-CLIENTE")
        GrabarCampo("CLIENTE")
        GrabarCampo("EXTINTORES")
        GrabarCampo("MANGUERAS")
        GrabarCampo("EXTINTORES-PRESTAMOS")
        GrabarCampo("MANGUERA-PRESTAMOS")
        GrabarCampo("COBRANZA")
        GrabarCampo("PRIORIDAD")
        GrabarCampo("DESDE1")
        GrabarCampo("HASTA1")
        GrabarCampo("DESDE2")
        GrabarCampo("HASTA2")
        GrabarCampo("PESO")
        GrabarCampo("DEMORA")
        GrabarCampo("BAJA")
        GrabarCampo("EXPRESO")
        GrabarCampo("CARRO")
        'GrabarCampo("FECHA")
        sw.WriteLine("")
    End Sub
    Private Sub GrabarLineaDocumento(ByVal Doc As IRuteable)
        Dim bpa As Sucursal = Doc.Sucursal
        Dim bpc As Cliente = Doc.Cliente
        Dim p As Integer = 0

        'Salto si es NCI
        If Doc.TipoTarea = "NCI" Then Exit Sub
        'Salgo si es abonado
        If bpc.EsAbonado Then Exit Sub

        GrabarCampo(Doc.TipoTarea)
        GrabarCampo(Doc.Tipo)
        GrabarCampo(IIf(bpc.EsAbonado, 1, 0).ToString)
        GrabarCampo(Doc.Numero)
        GrabarCampo(bpa.Sucursal)
        GrabarCampo(bpa.Direccion.Replace("Ñ", "N"))
        GrabarCampo(bpa.Ciudad)
        GrabarCampo(bpa.ProvinciaNombre)
        GrabarCampo(bpc.Codigo)
        GrabarCampo(bpc.Nombre)
        GrabarCampo((Doc.Equipos + Doc.RechazosExtintor).ToString)
        GrabarCampo((Doc.Mangueras + Doc.RechazosManguera).ToString)
        GrabarCampo(Doc.PrestamosExtintores.ToString)
        GrabarCampo(Doc.PrestamosMangueras.ToString)
        GrabarCampo(IIf(HayParte(Doc), 1, 0).ToString)
        '=== INICIO PRIORIDAD ===3

        Dim f As Date = Doc.FechaUnigis
        p = 0
        Select Case Doc.TipoTarea
            Case "RET"

                If Doc.CarritoFecha <> #12/31/1599# AndAlso Doc.CarritoFecha <= Date.Today Then 'ok
                    p = 1

                ElseIf fe.DiferenciaDiasHabiles(f, Today) >= 10 Then
                    p = 2

                End If

            Case "CTL"
                If fe.DiferenciaDiasHabiles(f, Today) >= 25 Then 'ok
                    p = 2

                End If

            Case "NUE", "NCI"

                If HayParte(Doc) Then 'ok
                    p = 1

                ElseIf fe.DiferenciaDiasHabiles(f, Today) >= 3 Then 'ok
                    p = 2

                ElseIf fe.DiferenciaDiasHabiles(f, Today) >= 7 Then 'ok
                    p = 1

                End If

            Case Else
                If fe.DiferenciaDiasHabiles(f, Today) >= 10 Then 'ok
                    p = 2

                End If

        End Select
        GrabarCampo(p.ToString)
        '=== FINAL PRIORIDAD ===
        GrabarCampo(h(Doc.Franja1Desde))
        GrabarCampo(h(Doc.Franja1Hasta))
        GrabarCampo(h(Doc.Franja2Desde))
        GrabarCampo(h(Doc.Franja2Hasta))
        GrabarCampo(Doc.PesoUnigis.ToString.Replace(".", ","))
        GrabarCampo(CalculoDemora(Doc, bpc, bpa).ToString)
        GrabarCampo(IIf(bpa.BajaCliente, 1, 0).ToString)
        If Doc.Pedido Is Nothing Then
            GrabarCampo("")
        Else
            GrabarCampo(h(Doc.Pedido.Expreso.Trim))
        End If
        GrabarCampo(IIf(Doc.TieneCarro, 1, 0).ToString)
        'GrabarCampo(f.ToString("dd/MM/yyyy"))
        sw.WriteLine("")

    End Sub
    Private Sub GrabarCampo(ByVal txt As String, Optional ByVal Salto As Boolean = True)
        sw.Write(txt)
        If Salto Then sw.Write(vbTab)
    End Sub
    Private Function h(ByVal txt As String) As String
        Dim i As Integer
        Dim s As String = ""

        If IsNumeric(txt) Then
            i = CInt(txt)
            s = i.ToString
        End If
        Return s

        'If txt = "0000" Then Return "" Else Return txt
    End Function
    Private Function CalculoDemora(ByVal Doc As IRuteable, ByVal bpc As Cliente, ByVal bpa As Sucursal) As Integer
        Dim Total As Double
        Dim u As Double = 0 'Tiempo por unidad
        Dim c As Double = 0 ' Cantidad Movida

        Select Case Doc.TipoTarea
            Case "NCI"
                If Doc.Equipos < 5 Then
                    Total = 10 * Doc.Equipos

                Else
                    If bpa.BajaCliente Then
                        Total = 4 * Doc.Equipos
                    Else
                        Total = 8 * Doc.Equipos
                    End If
                End If

            Case "NUE"
                If Doc.Equipos > 0 AndAlso Doc.PesoUnigis / Doc.Equipos < 2.5 Then
                    Total = 0.03 * Doc.PesoUnigis
                Else
                    Total = 0.25 * Doc.PesoUnigis
                End If

            Case "INS"
                Total = 10

            Case Else

                'Obtengo la cantidad movida
                c += Doc.Equipos
                c += Doc.Mangueras
                c += Doc.RechazosExtintor
                c += Doc.RechazosManguera
                c += Doc.PrestamosExtintores
                c += Doc.PrestamosMangueras

                'Calculo según tipo de Intervencion
                Select Case Doc.Tipo
                    Case "A1"
                        Dim itn As Intervencion

                        itn = CType(Doc, Intervencion)

                        If itn.ExisteRetira("652001") Or itn.ExisteRetira("652002") Or itn.ExisteRetira("652006") Then

                            If bpc.EsAbonado Then
                                u = 2
                            Else
                                u = 1.15

                            End If

                            Total = u * c

                        ElseIf itn.ExisteRetira("652011") Then
                            u = 30
                            Total = u * c

                        ElseIf itn.ExisteRetira("553011") Then
                            u = 4
                            Total = u * c

                            If bpa.TipoSistema = 2 Then Total += 8

                        End If


                    Case "B1", "D1"
                        Dim x As Double = 0

                        If Doc.TipoTarea = "RET" Then
                            x = Doc.Equipos + Doc.Mangueras + Doc.RechazosExtintor + Doc.RechazosManguera
                        End If

                        u = 1.75 'Obtengo el valor de la unidad movidad
                        Total = u * CDbl(IIf(x > 100, 100, c))

                    Case "C1"
                        Dim x As Double = 0
                        If Doc.TipoTarea = "RET" Then
                            x = Doc.Equipos + Doc.Mangueras + Doc.RechazosExtintor + Doc.RechazosManguera
                        End If

                        'Obtengo el valor de la unidad movidad
                        u = 1.13
                        Total = u * CDbl(IIf(x > 100, 100, c))

                End Select

        End Select

        'Tiempo de Espera en el Cliente
        Total += bpa.Demora

        'Cobraza
        If HayParte(Doc) Then Total += 5

        'Tiempo de proceso minimo
        Select Case Doc.TipoTarea
            Case "NUE"
                If Total < 8 Or Total > 120 Then
                    If Total < 120 Then Total = 8
                    If Total > 120 Then Total = 120
                End If

            Case Else

                Select Case Doc.Tipo
                    Case "A1"
                        'Minimo de 5 u 8 minutos
                        If bpc.EsAbonado AndAlso Total < 8 Then
                            Total = 8
                        ElseIf bpc.EsAbonado = False AndAlso Total < 5 Then
                            Total = 5
                        End If

                    Case "B1"
                        If Total < 8 Or Total > 120 Then
                            If Total < 120 Then Total = 8
                            If Total > 120 Then Total = 120
                        End If

                    Case "C1", "D1"
                        If Total < 8 Then Total = 8

                End Select
        End Select

        Return CInt(Total)

    End Function

End Class