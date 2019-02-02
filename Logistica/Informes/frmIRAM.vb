Imports System.IO
Imports Microsoft.Win32
Imports System.Data.OracleClient

Public Class frmIRAM
    Private itn As New Intervencion(cn)

    Private dtTarjetas As New DataTable
    Private daTarjetas As OracleDataAdapter

    'SUB
    Private Sub Adaptadores()
        Dim Sql As String

        Sql = "SELECT 1 AS x, mac.macnum_0, macdes_0, ynrocil_0, yfabdat_0, "
        Sql &= "   (SELECT datnext_0 FROM (machines mac2 INNER JOIN ymacitm ymc ON (mac2.macnum_0 = ymc.macnum_0)) INNER JOIN bomd bom ON (ymc.cpnitmref_0 = bom.cpnitmref_0 AND mac2.macpdtcod_0 = bom.itmref_0) WHERE mac2.macnum_0 = mac.macnum_0 AND bomseq_0 = 10) AS REC, "
        Sql &= "   (SELECT datnext_0 FROM (machines mac2 INNER JOIN ymacitm ymc ON (mac2.macnum_0 = ymc.macnum_0)) INNER JOIN bomd bom ON (ymc.cpnitmref_0 = bom.cpnitmref_0 AND mac2.macpdtcod_0 = bom.itmref_0) WHERE mac2.macnum_0 = mac.macnum_0 AND bomseq_0 = 20) AS PH, "
        Sql &= "    yflgiram_0 "
        Sql &= "FROM (machines mac INNER JOIN sremac sre ON (mac.macnum_0 = sre.macnum_0))INNER JOIN itmsales itm ON (mac.macpdtcod_0 = itm.itmref_0) "
        Sql &= "WHERE sre.yitnnum_0 = :yitnnum_0 AND "
        Sql &= "	  mac.macitntyp_0 <> 5 " 'AND "
        'Sql &= "	  itm.yflgiram_0 = 2 "
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
            colIram.DataPropertyName = "yflgiram_0"
            dgv.DataSource = dtTarjetas
        End If

        lblCant.Text = "Cantidad: " & dtTarjetas.Rows.Count.ToString

    End Sub

    'FUNCTION
    Private Function ObtenerConfiguracion(ByVal Planta As String, Optional ByVal Campo As String = "") As String
        Dim RegKey As RegistryKey = Registry.CurrentUser.OpenSubKey("Software", True).CreateSubKey("Georgia").CreateSubKey("IRAMv2")
        Dim Dato As Object

        If Campo = "" Then
            Dato = RegKey.GetValue(Planta)
        Else
            Dato = RegKey.GetValue(Planta & "_" & Campo)
        End If

        RegKey.Close()

        If Dato Is Nothing Then
            Return ""

        Else
            Return Dato.ToString

        End If

    End Function

    'EVENTOS
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
        'Variables de puerto de impresion
        Dim Planta As String = itn.Planta.CodigoPlanta
        Dim Impresora As String = ObtenerConfiguracion(Planta)
        Dim prn As New Impresora(cn)

        If Impresora = "" Then
            MessageBox.Show("Impresora no configurada para la planta " & Planta, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        If Not prn.Abrir(Impresora) Then
            MessageBox.Show("Destino no encontrado en Adonix: " & Impresora, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        Dim Archivo As String = String.Format("{0}\IRAM_{1}.txt", Application.StartupPath, Environment.MachineName)
        Dim dr As DataRow
        Dim st As Stream = File.Open(String.Format(Archivo), FileMode.Create, FileAccess.Write, FileShare.None)
        Dim sr As New StreamWriter(st)
        Dim i As Integer = 0

        Try
            btnImprimirIRAM.Enabled = False

            dtTarjetas.AcceptChanges()

            With sr
                'Cabecera del archivo para impresion
                .WriteLine("^XA~TA000~JSN^LT0^MMT^MNW^MTT^PON^PMN^LH0,0^JMA^PR2,2^MD29^JUS^LRN^CI0^XZ")

                For Each dr In dtTarjetas.Rows

                    If CInt(dr(0)) = 1 AndAlso CInt(dr("yflgiram_0")) = 2 Then
                        .WriteLine("^XA^LL1119")
                        .WriteLine("^PW831")
                        .WriteLine(String.Format("^FT{0}^A0R,28,28^FH\^FD{1}^FS", prn.XY("PH"), CDate(dr("ph")).ToString("MM/yyyy")))
                        .WriteLine(String.Format("^FT{0}^A0R,28,28^FH\^FD{1}^FS", prn.XY("CIL"), dr("ynrocil_0").ToString))
                        .WriteLine(String.Format("^FT{0}^A0R,28,28^FH\^FD{1}^FS", prn.XY("REC"), CDate(dr("rec")).ToString("MM/yyyy")))
                        .WriteLine("^PQ1,0,1,Y^XZ")
                        i += 1
                    End If
                Next

                .Close()

            End With

            'Copio archivo al puerto paralelo para que salga por impresora
            If i > 0 Then File.Copy(Archivo, prn.RecursoRed)

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
        Cant = itn.ExportarArchivoMost(SaveFileDialog1.FileName)

        Select Case Cant
            Case -1
                MessageBox.Show("El cliente no tiene cargado el callejero GCBA", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

            Case Else
                Txt = Txt.Replace("{xx}", Cant.ToString)
                MessageBox.Show(Txt, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

        End Select

    End Sub

    Private Sub btn1Kg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1Kg.Click

    End Sub

End Class