Imports System.IO
Imports Microsoft.Win32
Imports System.Data.OracleClient

Public Class frmIRAM
    'Destinos para impresion de etiquetas IRAM normales
    Private Const DNY As String = "IRAM1"
    Private Const GRU As String = "IRAM2"
    Private Const MON As String = "IRAM3"
    'Destinos para impresion de etiquetas IRAM 1KG (vehiculares)
    Private Const DNY_1K As String = "IRAM4"
    Private Const GRU_1K As String = "IRAM4"
    Private Const MON_1K As String = "IRAM4"

    Private itn As New Intervencion(cn)
    Private dtTarjetas As New DataTable
    Private daTarjetas As OracleDataAdapter

    'SUB
    Private Sub Adaptadores()
        Dim Sql As String

        Sql = "SELECT 1 AS x, mac.macnum_0, macdes_0, ynrocil_0, yfabdat_0, tsicod_1, tsicod_2, macbra_0, patente_0, yflgiram_0, "
        Sql &= "   (SELECT datnext_0 FROM (machines mac2 INNER JOIN ymacitm ymc ON (mac2.macnum_0 = ymc.macnum_0)) INNER JOIN bomd bom ON (ymc.cpnitmref_0 = bom.cpnitmref_0 AND mac2.macpdtcod_0 = bom.itmref_0) WHERE mac2.macnum_0 = mac.macnum_0 AND bomseq_0 = 10) AS REC, "
        Sql &= "   (SELECT datnext_0 FROM (machines mac2 INNER JOIN ymacitm ymc ON (mac2.macnum_0 = ymc.macnum_0)) INNER JOIN bomd bom ON (ymc.cpnitmref_0 = bom.cpnitmref_0 AND mac2.macpdtcod_0 = bom.itmref_0) WHERE mac2.macnum_0 = mac.macnum_0 AND bomseq_0 = 20) AS PH "
        Sql &= "FROM ((machines mac INNER JOIN sremac sre ON (mac.macnum_0 = sre.macnum_0))INNER JOIN itmsales its ON (mac.macpdtcod_0 = its.itmref_0)) "
        Sql &= "      INNER JOIN itmmaster itm ON (itm.itmref_0 = its.itmref_0) "
        Sql &= "WHERE sre.yitnnum_0 = :yitnnum_0 AND "
        Sql &= "	  mac.macitntyp_0 <> 5 " 'AND "
        'Sql &= "	  its.yflgiram_0 = 2 "
        Sql &= "ORDER BY srelig_0"

        daTarjetas = New OracleDataAdapter(Sql, cn)
        daTarjetas.SelectCommand.Parameters.Add("yitnnum_0", OracleType.VarChar)

    End Sub
    Private Sub Marcar(Optional ByVal Estado As Boolean = True)
        Dim dr As DataRow

        For Each dr In dtTarjetas.Rows
            dr.BeginEdit()
            dr(0) = Estado
            dr.EndEdit()
        Next
        dtTarjetas.AcceptChanges()

    End Sub
    Private Sub Tarjetas(ByVal txt As String)

        dtTarjetas.Clear()
        Application.DoEvents()

        daTarjetas.SelectCommand.Parameters("yitnnum_0").Value = txt
        daTarjetas.Fill(dtTarjetas)

        'Enlazo la grilla por primera vez
        If dgv.DataSource Is Nothing Then
            colX.DataPropertyName = "X"
            colSerie.DataPropertyName = "macnum_0"
            colTipo.DataPropertyName = "macdes_0"
            colCilindro.DataPropertyName = "ynrocil_0"
            colFab.DataPropertyName = "yfabdat_0"
            colRecarga.DataPropertyName = "rec"
            colPh.DataPropertyName = "ph"
            colLinea1.DataPropertyName = "tsicod_1"
            colLinea2.DataPropertyName = "tsicod_2"
            colFabricante.DataPropertyName = "macbra_0"
            colPatente.DataPropertyName = "patente_0"
            colIram.DataPropertyName = "yflgiram_0"
            dgv.DataSource = dtTarjetas
        End If

        lblCant.Text = "Cantidad: " & dtTarjetas.Rows.Count.ToString

    End Sub

    Private Function SelectorImpresora(ByVal cpy As String, ByVal Vehicular As Boolean) As String
        Dim s As String = ""

        If Vehicular Then

            Select Case cpy
                Case "DNY"
                    s = DNY_1K

                Case "GRU", "LIA", "SCH"
                    s = GRU_1K

                Case "MON"
                    s = MON_1K

                Case Else
                    s = ""

            End Select

        Else

            Select Case cpy
                Case "DNY"
                    s = DNY

                Case "GRU", "LIA", "SCH"
                    s = GRU

                Case "MON"
                    s = MON

                Case Else
                    s = ""

            End Select

        End If

        Return s

    End Function
    Private Sub frmTarjetas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Adaptadores()
    End Sub
    Private Sub Abrir(ByVal num As String)
        dtTarjetas.Clear()

        If itn.Abrir(num) Then
            txtCliente.Text = itn.Cliente.Nombre
            txtIntervencion.Text = num.ToUpper

            btnTxtGCBA.Enabled = (itn.SucursalProvincia = "CFE")
            btnImprimirIRAM.Enabled = True

            Tarjetas(num) 'Obtengo tarjetas

        Else
            MessageBox.Show("No se encontró la intervención " & num, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtCliente.Clear()
            txtIntervencion.Clear()

        End If

    End Sub
    Private Sub btnAbrir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbrir.Click

        Dim txt As String = ""

        txt = "Ingrese el número de intervención"
        txt = InputBox(txt, Me.Text)

        Abrir(txt.ToUpper)

    End Sub
    Private Sub btnImprimirIRAM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimirIRAM.Click
        Dim Sociedad As String = itn.Planta.SociedadPlanta.Codigo
        Dim Impresora As String
        Dim prn1 As New Impresora(cn)  'Impresora Industriales
        Dim prn2 As New Impresora(cn) 'Impresora Automotor
        Dim Archivo1 As String = String.Format("{0}\IRAM1_{1}.txt", Application.StartupPath, Environment.MachineName)
        Dim Archivo2 As String = String.Format("{0}\IRAM2_{1}.txt", Application.StartupPath, Environment.MachineName)
        Dim dr As DataRow
        Dim sw1 As StreamWriter
        Dim sw2 As StreamWriter
        Dim i1 As Integer = 0 'Industriales
        Dim i2 As Integer = 0 'Automotor

        Try
            btnImprimirIRAM.Enabled = False
            dtTarjetas.AcceptChanges()

            'Abro impresora IRAM INDUSTRIALES
            Impresora = SelectorImpresora(itn.Planta.SociedadPlanta.Codigo, False)
            If Impresora = "" OrElse prn1.Abrir(Impresora) = False Then
                prn1 = Nothing
            End If
            'Abro impresora IRAM AUTOMOTOR
            Impresora = SelectorImpresora(itn.Planta.SociedadPlanta.Codigo, True)
            If Impresora = "" OrElse prn2.Abrir(Impresora) = False Then
                prn2 = Nothing
            End If

            'Creacion de Cabecera del archivo para impresion IRAM INDUSTRIALES
            sw1 = New StreamWriter(Archivo1, False)
            sw1.WriteLine("^XA~TA000~JSN^LT0^MMT^MNW^MTT^PON^PMN^LH0,0^JMA^PR2,2^MD29^JUS^LRN^CI0^XZ")
            'Creacion de Cabecera del archivo para impresion IRAM AUTOMOTOR
            sw2 = New StreamWriter(Archivo2, False)
            sw2.WriteLine("I8,A,001")
            sw2.WriteLine("Q464,024")
            sw2.WriteLine("q831")
            sw2.WriteLine("rN")
            sw2.WriteLine("S2")
            sw2.WriteLine("D13")
            sw2.WriteLine("ZT")
            sw2.WriteLine("JF")
            sw2.WriteLine("O")
            sw2.WriteLine("R80,0")
            sw2.WriteLine("f100")

            For Each dr In dtTarjetas.Rows
                'Salto si fila no está seleccionada
                If CInt(dr(0)) <> 1 Then Continue For
                'Salti si articulo no lleva iram
                If CInt(dr("yflgiram_0")) <> 2 Then Continue For

                If dr("tsicod_1").ToString <> "101" And dr("tsicod_1").ToString <> "102" Then
                    If prn1 IsNot Nothing Then
                        sw1.WriteLine("^XA^LL1119")
                        sw1.WriteLine("^PW831")
                        sw1.WriteLine(String.Format("^FT{0}^A0R,28,28^FH\^FD{1}^FS", prn1.XY("PH"), CDate(dr("ph")).ToString("MM/yyyy")))
                        sw1.WriteLine(String.Format("^FT{0}^A0R,28,28^FH\^FD{1}^FS", prn1.XY("CIL"), dr("ynrocil_0").ToString))
                        sw1.WriteLine(String.Format("^FT{0}^A0R,28,28^FH\^FD{1}^FS", prn1.XY("REC"), CDate(dr("rec")).ToString("MM/yyyy")))
                        sw1.WriteLine("^PQ1,0,1,Y^XZ")
                        i1 += 1
                    End If

                Else
                    If prn2 IsNot Nothing Then
                        sw2.WriteLine("N")
                        sw2.WriteLine(String.Format("A{0},2,3,1,1,N,{1}", prn2.XY("PH"), Chr(34) & CDate(dr("ph")).ToString("MM/yy")) & Chr(34))
                        sw2.WriteLine(String.Format("A{0},2,3,1,1,N,{1}", prn2.XY("CIL"), Chr(34) & dr("ynrocil_0").ToString) & Chr(34))
                        sw2.WriteLine(String.Format("A{0},2,3,1,1,N,{1}", prn2.XY("REC"), Chr(34) & CDate(dr("rec")).ToString("MM/yy")) & Chr(34))
                        sw2.WriteLine("P1")
                        i2 += 1
                    End If

                End If

            Next
            sw1.Close() : sw1.Dispose() : sw1 = Nothing
            sw2.Close() : sw2.Dispose() : sw2 = Nothing

            'Impresion IRAM INDUSTRIALES
            If i1 > 0 Then
                File.Copy(Archivo1, prn1.RecursoRed)
            End If
            'Impresion IRAM AUTOMOTOR
            If i2 > 0 Then
                File.Copy(Archivo2, prn2.RecursoRed)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            btnImprimirIRAM.Enabled = True

        End Try

    End Sub
    Private Sub btnMarcar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMarcar.Click
        Marcar()
    End Sub
    Private Sub btnDesmarcar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDesmarcar.Click
        Marcar(False)
    End Sub
    Private Sub btnTxtGCBA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTxtGCBA.Click
        Dim Cant As Integer
        Dim Txt As String = "Se exportaron {xx} extintor(es)"

        SaveFileDialog1.Filter = "Documentos de texto (*.txt*)|*.txt"
        SaveFileDialog1.FileName = txtIntervencion.Text ' & ".txt"

        'Salgo si el usuario cancelo el dialogo
        If SaveFileDialog1.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub

        'Genero el archivo y recupero la cantidad de extintores exportados
        Cant = TarjetasGCBA(SaveFileDialog1.FileName)

        Select Case Cant
            Case -1
                MessageBox.Show("El cliente no tiene cargado el callejero GCBA", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

            Case Else
                Txt = Txt.Replace("{xx}", Cant.ToString)
                MessageBox.Show(Txt, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

        End Select

    End Sub
    Private Function TarjetasGCBA(ByVal Archivo As String) As Integer
        Const SEP As String = "|"

        Dim bpc As Cliente = itn.Cliente
        Dim bpa As Sucursal = New Sucursal(cn, bpc.Codigo, itn.SucursalCodigo)
        Dim dr As DataRow
        Dim linea As String = ""
        Dim tab1 = New TablaVaria(cn, 22)
        Dim tab2 = New TablaVaria(cn, 21)
        Dim tab3 = New TablaVaria(cn, 408)
        Dim mac As New Parque(cn)
        Dim sw As System.IO.StreamWriter
        Dim i As Integer = 0

        'Valido que sucursal tenga cargado los datos del callejero
        If bpa.AlturaGCBA = 0 Or bpa.CallejeroGCBA = "" Then
            MessageBox.Show("Callejero no cargado", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return -1
        End If

        sw = New System.IO.StreamWriter(Archivo, False, System.Text.Encoding.Default)

        For Each dr In dtTarjetas.Rows

            mac.Abrir(dr("macnum_0").ToString)

            If bpc.TipoDoc = "80" And bpc.CUIT <> "" And bpc.Familia2 <> "11" Then
                'Empresa
                linea = "Empresa/Local" & SEP 'Campo 1
                linea &= bpc.CUIT & SEP 'Campo 2
                linea &= bpc.Nombre & SEP 'Campo 3
                linea &= SEP 'Campo 4
                linea &= SEP 'Campo 5
                linea &= SEP 'Campo 6

            Else
                'Particular
                linea = "Particular" & SEP 'Campo 1
                linea &= SEP 'Campo 2
                linea &= SEP 'Campo 3
                linea &= SEP 'Campo 4
                linea &= SEP 'Campo 5
                linea &= SEP 'Campo 6

            End If

            linea &= dr("ynrocil_0").ToString & SEP 'Campo 7 - Cilindro
            linea &= "False" & SEP 'Campo 8 - Sustituto
            linea &= "Recarga" & SEP 'Campo 9 - Venta/Recarga
            linea &= tab1.Aux1(dr("tsicod_2").ToString) & SEP 'Campo 10 - Agente Extintor
            linea &= tab2.Aux1(dr("tsicod_1").ToString) & SEP 'Campo 11 - Capacidad
            linea &= tab3.Texto(dr("macbra_0").ToString) & SEP 'Campo 12 - Empresa Fabricante
            linea &= "Matafuegos Donny S.R.L" & SEP 'Campo 13 - Empresa Recargador
            linea &= SEP 'Campo 14
            linea &= CDate(dr("yfabdat_0")).Year.ToString & SEP 'Campo 15 - 
            linea &= mac.VtoPH.ToString("MM/yyyy") & SEP 'Campo 16

            If dr("patente_0").ToString.Trim.Length > 0 Then
                'Extintor automotor
                linea &= dr("patente_0").ToString.Trim 'Campo 17

            Else
                'El extintor es industrial
                linea &= bpa.CallejeroGCBA & SEP 'Campo 17
                linea &= bpa.AlturaGCBA & SEP 'Campo 18
                linea &= SEP 'Campo 19

            End If

            sw.WriteLine(linea)

            i += 1
        Next

        sw.Close()
        sw.Dispose()

        Return i

    End Function
End Class