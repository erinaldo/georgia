Imports System.IO
Imports Microsoft.Win32
Imports System.Data.OracleClient

Public Class frmSustitutos
    Private dtIntervencion As New DataTable
    Private daIntervencion As OracleDataAdapter

    Private dtTarjetas As New DataTable
    Private daTarjetas As OracleDataAdapter

    'SUB
    Private Sub Adaptadores()
        Dim Sql As String

        Sql = "SELECT num_0, num_0 || ' - ' || bpcnam_0 AS nam_0 FROM interven INNER JOIN bpcustomer ON (bpc_0 = bpcnum_0) WHERE num_0 = :num_0 ORDER BY num_0 DESC"
        daIntervencion = New OracleDataAdapter(Sql, cn)
        daIntervencion.SelectCommand.Parameters.Add("num_0", OracleType.VarChar)

        Sql = "SELECT 1 AS x, mac.macnum_0, mac.macpdtcod_0, macdes_0, ynrocil_0, yfabdat_0, "
        Sql &= "   (SELECT datnext_0 FROM (machines mac2 INNER JOIN ymacitm ymc ON (mac2.macnum_0 = ymc.macnum_0)) INNER JOIN bomd bom ON (ymc.cpnitmref_0 = bom.cpnitmref_0 AND mac2.macpdtcod_0 = bom.itmref_0) WHERE mac2.macnum_0 = mac.macnum_0 AND bomseq_0 = 10) AS REC, "
        Sql &= "   (SELECT datnext_0 FROM (machines mac2 INNER JOIN ymacitm ymc ON (mac2.macnum_0 = ymc.macnum_0)) INNER JOIN bomd bom ON (ymc.cpnitmref_0 = bom.cpnitmref_0 AND mac2.macpdtcod_0 = bom.itmref_0) WHERE mac2.macnum_0 = mac.macnum_0 AND bomseq_0 = 20) AS PH "
        Sql &= "FROM (machines mac INNER JOIN sremac sre ON (mac.macnum_0 = sre.macnum_0))INNER JOIN itmsales itm ON (mac.macpdtcod_0 = itm.itmref_0) "
        Sql &= "WHERE sre.yitnnum_0 = :yitnnum_0 AND mac.macitntyp_0 <> 5 "
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
            dgv.DataSource = dtTarjetas
        End If

        lblCant.Text = "Cantidad: " & dtTarjetas.Rows.Count.ToString
    End Sub

    'FUNCTION
    Private Function ObtenerConfiguracion(ByVal Planta As String, Optional ByVal Campo As String = "") As String
        Dim RegKey As RegistryKey = Registry.CurrentUser.OpenSubKey("Software", True).CreateSubKey("Georgia").CreateSubKey("IRAM")
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
        dtIntervencion.Clear()
        dtTarjetas.Clear()

        daIntervencion.SelectCommand.Parameters("num_0").Value = num.ToUpper

        Try
            daIntervencion.Fill(dtIntervencion)

            If dtIntervencion.Rows.Count > 0 Then
                txtIntervencion.Text = dtIntervencion.Rows(0).Item(1).ToString
                Tarjetas(num) 'Obtengo tarjetas

            Else
                MessageBox.Show("No se encontró la intervención " & num, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtIntervencion.Text = ""

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub
    Private Sub btnAbrir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbrir.Click

        Dim txt As String = ""

        txt = "Ingrese el número de intervención"
        txt = InputBox(txt, Me.Text)

        Abrir(txt.ToUpper)

    End Sub
    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        'Variables de puerto de impresion
        Dim Planta As String = txtIntervencion.Text.Substring(0, 3)
        Dim Puerto As String = ObtenerConfiguracion(Planta)

        If Puerto = "" Then
            MessageBox.Show("Puerto de impresión no configurado para la planta " & Planta, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        Dim Archivo As String = String.Format("{0}\IRAM_{1}.txt", Application.StartupPath, Environment.MachineName)
        Dim dr As DataRow
        Dim st As Stream = File.Open(String.Format(Archivo), FileMode.Create, FileAccess.Write, FileShare.None)
        Dim sr As New StreamWriter(st)
        Dim i As Integer = 0

        Try
            btnImprimir.Enabled = False

            dtTarjetas.AcceptChanges()

            With sr
                'Cabecera del archivo para impresion
                .WriteLine("^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR4,4~SD15^JUS^LRN^CI0^XZ")
                .WriteLine("^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR2,2~SD15^JUS^LRN^CI0^XZ")

                For Each dr In dtTarjetas.Rows
                    If CInt(dr(0)) = 1 Then
                        .WriteLine("^XA")
                        .WriteLine("^MMT")
                        .WriteLine("^PW543")
                        .WriteLine("^LL0360")
                        .WriteLine("^LS0")

                        .WriteLine(String.Format("^FT345,97^A0R,39,38^FH\^FD{0}^FS", CDate(dr("rec")).ToString("MM"))) 'MES VTO CARGA
                        .WriteLine(String.Format("^FT345,248^A0R,39,38^FH\^FD{0}^FS", CDate(dr("rec")).ToString("yy"))) 'AÑO VTO CARGA
                        .WriteLine(String.Format("^FT208,71^A0R,31,31^FH\^FD{0}^FS", CDate(dr("yfabdat_0")).ToString("MM yy"))) 'FECHA FABRICACION
                        .WriteLine(String.Format("^FT208,168^A0R,31,31^FH\^FD{0}^FS", CDate(dr("ph")).ToString("MM yy"))) 'FECHA VTO PH
                        .WriteLine(String.Format("^FT208,274^A0R,31,31^FH\^FD{0}^FS", VidaUtil(dr).ToString("MM yy"))) 'FECHA V.UTIL
                        .WriteLine(String.Format("^FT149,72^A0R,28,28^FH\^FD{0}^FS", dr("ynrocil_0").ToString)) 'CILINDRO
                        .WriteLine(String.Format("^FT149,278^A0R,28,28^FH\^FD{0}^FS", Capacidad(dr))) 'CAPACIDAD
                        .WriteLine(String.Format("^FT75,71^A0R,28,28^FH\^FD{0}^FS", Agente(dr))) 'AGENTE EXTINTOR

                        .WriteLine("^PQ1,0,1,Y^XZ")
                        i += 1
                    End If
                Next

                .Close()

            End With

            'Copio archivo al puerto paralelo para que salga por impresora
            If i > 0 Then File.Copy(Archivo, Puerto)

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            btnImprimir.Enabled = True

        End Try

    End Sub
    Private Sub btnMarcar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMarcar.Click
        Marcar()
    End Sub
    Private Sub btnDesmarcar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDesmarcar.Click
        Marcar(False)
    End Sub
    Private Function VidaUtil(ByVal dr As DataRow) As Date
        Dim f As Date

        If Mid(dr("macpdtcod_0").ToString, 3, 1) = "3" Then
            f = CDate(dr("yfabdat_0")).AddYears(30)

        Else
            f = CDate(dr("yfabdat_0")).AddYears(20)

        End If

        Return f

    End Function
    Private Function Agente(ByVal dr As DataRow) As String
        Dim Sql As String
        Dim da As OracleDataAdapter
        Dim dt As New DataTable

        Sql = "SELECT cfglindes_0 FROM tablincfg tab INNER JOIN itmmaster itm ON (tab.cfglin_0 = itm.cfglin_0) WHERE itmref_0 = :itmref_0"
        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("itmref_0", OracleType.VarChar).Value = dr("macpdtcod_0").ToString
        da.Fill(dt)
        da.Dispose()

        If dt.Rows.Count = 1 Then
            Agente = dt.Rows(0).Item(0).ToString
        Else
            Agente = ""

        End If
        dt.Dispose()

    End Function
    Private Function Capacidad(ByVal dr As DataRow) As String
        Dim Sql As String
        Dim da As OracleDataAdapter
        Dim dt As New DataTable

        Sql = "SELECT texte_0 FROM atextra atx INNER JOIN itmmaster itm ON (atx.ident2_0 = itm.tsicod_1) WHERE ident1_0 = '21' and zone_0 = 'SHODES' AND itmref_0 = :itmref_0"
        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("itmref_0", OracleType.VarChar).Value = dr("macpdtcod_0").ToString
        da.Fill(dt)
        da.Dispose()

        If dt.Rows.Count = 1 Then
            Capacidad = dt.Rows(0).Item(0).ToString
        Else
            Capacidad = ""

        End If
        dt.Dispose()

    End Function

End Class