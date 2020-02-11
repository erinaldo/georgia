Imports System.Data.OracleClient
Imports System.IO

Public Class frmExportarControles
    Private sw As StreamWriter
    Private Fecha As Date
    Private dtPartes As New DataTable
    Private dvPartes As DataView
    Private calle As New Callejero(cn)

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Dim tb As New TablaVaria(cn, 407, False)
        tb.EnlazarComboBox(cboTipo)

    End Sub

    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        Dim f1, f2 As Date
        Dim txt As String

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
        'Recupero intervenciones
        dt = Intervenciones(cboTipo.SelectedValue.ToString)

        Dim x As Integer = dt.Rows.Count

        For Each dr As DataRow In dt.Rows
            i += 1
            lbl.Text = "Intervención " & i.ToString & " de " & dt.Rows.Count.ToString & " - " & dr(0).ToString
            Application.DoEvents()

            'Abro la intervencion
            itn.Abrir(dr(0).ToString)

            GrabarLineaDocumento(itn)

        Next

        sw.Close()
        sw.Dispose()
    End Sub
    Private Function Intervenciones(ByVal Tipo As String) As DataTable
        Dim Sql As String
        Dim da As OracleDataAdapter
        Dim dt As New DataTable

        Sql = "SELECT num_0 "
        Sql &= "FROM interven "
        Sql &= "WHERE zflgtrip_0 in (1, 6) AND "
        Sql &= "      dat_0 < :dat_0 AND "
        Sql &= "      dat_0 >= to_date('01/01/2017', 'dd/mm/yyyy') and "
        Sql &= "      typ_0 = :typ_0 and "
        Sql &= "      mdl_0 = '1' AND "
        Sql &= "      tripnum_0 = ' ' AND "
        Sql &= "      sat_0 = 'CFE'"

        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("dat_0", OracleType.DateTime).Value = mcal.SelectionRange.Start
        da.SelectCommand.Parameters.Add("typ_0", OracleType.VarChar).Value = Tipo
        da.Fill(dt)
        da.Dispose()

        Return dt

    End Function
    Private Sub CabeceraArchivo()
        GrabarCampo("MES INTERVENCION")
        GrabarCampo("NRO INTERVENCION")
        GrabarCampo("CODIGO CLIENTE")
        GrabarCampo("NOMBRE CLIENTE")
        GrabarCampo("ABONADO")
        GrabarCampo("SUCURSAL")
        GrabarCampo("DOMICILIO")
        GrabarCampo("TAREA")
        GrabarCampo("CANTIDAD")
        GrabarCampo("DEMORA")
        GrabarCampo("DESDE1")
        GrabarCampo("HASTA1")
        GrabarCampo("DESDE2")
        GrabarCampo("HASTA2")
        sw.WriteLine("")
    End Sub
    Private Sub GrabarLineaDocumento(ByVal Doc As IRuteable)
        Dim bpa As Sucursal = Doc.Sucursal
        Dim bpc As Cliente = Doc.Cliente
        Dim p As Integer = 0
        Dim itn As Intervencion

        itn = CType(Doc, Intervencion)

        'Mes interencion
        GrabarCampo(itn.FechaInicio.ToString("MM"))
        'numero de intervencion
        GrabarCampo(Doc.Numero)
        'numero de cliente
        GrabarCampo(bpc.Codigo)
        'nombre de cliente
        GrabarCampo(bpc.Nombre)
        'abonado si/no
        GrabarCampo(IIf(bpc.EsAbonado, 1, 0).ToString)
        'nro sucursal
        GrabarCampo(bpa.Sucursal)
        'domicilio (callejero combinado)
        Dim s As String
        s = calle.ObtenerCalle(bpa.CallejeroGCBA)
        s &= " " & bpa.AlturaGCBA
        GrabarCampo(s)
        'Tarea (primera linea solo el codigo)
        GrabarCampo(itn.Detalle.Item(0).Item(2).ToString)
        'Cantidad (primera linea)
        GrabarCampo(itn.Detalle.Item(0).Item(5).ToString)
        'Demora (la q teniamos ya calculada para unigis)
        GrabarCampo(CalculoDemora(Doc, bpc, bpa).ToString)
        'Horario inicio y horario fin, el 1 y el 2
        GrabarCampo(h(Doc.Franja1Desde))
        GrabarCampo(h(Doc.Franja1Hasta))
        GrabarCampo(h(Doc.Franja2Desde))
        GrabarCampo(h(Doc.Franja2Hasta))

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
End Class