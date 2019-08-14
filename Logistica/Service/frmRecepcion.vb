Imports Microsoft.Win32
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.OracleClient
Imports System.Drawing

Public Class frmRecepcion
    Private Const CLIENTE_EDENOR As String = "601537"

    Private WithEvents itn As Intervencion
    Private WithEvents sre As Solicitud
    Private WithEvents mac As Parque
    Private WithEvents dv As DataView  'Vista para mostrar los equipos sin marca de tarjeta impresa

    Private mlRecargador As MenuLocal
    Private PuertoImpresora As String = ""
    Private da As OracleDataAdapter
    Private dt As New DataTable 'Tabla de la grilla

    'SUB
    Private Sub Adaptadores()
        Dim Sql As String

        'SREMAC
        Sql = "SELECT sre.*, mac.macpdtcod_0, mac.macdes_0, mac.ynrocil_0, mac.yfabdat_0, mac.macitntyp_0, mac.recargador_0, mac.patente_0 "
        Sql &= "FROM sremac sre INNER JOIN machines mac ON (sre.macnum_0 = mac.macnum_0) "
        Sql &= "WHERE yitnnum_0 = :yitnnum_0"
        da = New OracleDataAdapter(Sql, cn)

        Sql = "INSERT INTO sremac "
        Sql &= "VALUES (:srenum_0, :itngru_0, :macnum_0, :pblnum_0, :covflg_0, :covspt_0, :covvcr_0, "
        Sql &= ":maccovren_0, :credat_0, :creusr_0, :upddat_0, :updusr_0, :yflgmrk_0, :yflgtrj_0, :yitnnum_0, :srelig_0, :pallet_0, "
        Sql &= ":nroiram_0, :largo_0, :ok_0, :presion_0, :obs_0, :usuario_0) "
        da.InsertCommand = New OracleCommand(Sql, cn)

        Sql = "UPDATE sremac "
        Sql &= "SET upddat_0 = :upddat_0, updusr_0 = :updusr_0, yflgtrj_0 = :yflgtrj_0, yitnnum_0 = :yitnnum_0, srelig_0 = :srelig_0, pallet_0 = :pallet_0 "
        Sql &= "WHERE yitnnum_0 = :yitnnum_0 AND macnum_0 = :macnum_0"
        da.UpdateCommand = New OracleCommand(Sql, cn)

        Sql = "DELETE FROM sremac WHERE yitnnum_0 = :yitnnum_0 AND macnum_0 = :macnum_0"
        da.DeleteCommand = New OracleCommand(Sql, cn)

        With da
            .SelectCommand.Parameters.Add("yitnnum_0", OracleType.VarChar)

            Parametro(.UpdateCommand, "upddat_0", OracleType.DateTime, DataRowVersion.Current)
            Parametro(.UpdateCommand, "updusr_0", OracleType.VarChar, DataRowVersion.Current)
            Parametro(.UpdateCommand, "yflgtrj_0", OracleType.Number, DataRowVersion.Current)
            Parametro(.UpdateCommand, "yitnnum_0", OracleType.VarChar, DataRowVersion.Current)
            Parametro(.UpdateCommand, "srelig_0", OracleType.Number, DataRowVersion.Current)
            Parametro(.UpdateCommand, "pallet_0", OracleType.Number, DataRowVersion.Current)
            Parametro(.UpdateCommand, "yitnnum_0", OracleType.VarChar, DataRowVersion.Original)
            Parametro(.UpdateCommand, "macnum_0", OracleType.VarChar, DataRowVersion.Original)

            Parametro(.InsertCommand, "srenum_0", OracleType.VarChar, DataRowVersion.Current)
            Parametro(.InsertCommand, "itngru_0", OracleType.VarChar, DataRowVersion.Current)
            Parametro(.InsertCommand, "macnum_0", OracleType.VarChar, DataRowVersion.Current)
            Parametro(.InsertCommand, "pblnum_0", OracleType.VarChar, DataRowVersion.Current)
            Parametro(.InsertCommand, "covflg_0", OracleType.Number, DataRowVersion.Current)
            Parametro(.InsertCommand, "covspt_0", OracleType.Number, DataRowVersion.Current)
            Parametro(.InsertCommand, "covvcr_0", OracleType.VarChar, DataRowVersion.Current)
            Parametro(.InsertCommand, "maccovren_0", OracleType.Number, DataRowVersion.Current)
            Parametro(.InsertCommand, "credat_0", OracleType.DateTime, DataRowVersion.Current)
            Parametro(.InsertCommand, "creusr_0", OracleType.VarChar, DataRowVersion.Current)
            Parametro(.InsertCommand, "upddat_0", OracleType.DateTime, DataRowVersion.Current)
            Parametro(.InsertCommand, "updusr_0", OracleType.VarChar, DataRowVersion.Current)
            Parametro(.InsertCommand, "yflgmrk_0", OracleType.Number, DataRowVersion.Current)
            Parametro(.InsertCommand, "yflgtrj_0", OracleType.Number, DataRowVersion.Current)
            Parametro(.InsertCommand, "yitnnum_0", OracleType.VarChar, DataRowVersion.Current)
            Parametro(.InsertCommand, "srelig_0", OracleType.Number, DataRowVersion.Current)
            Parametro(.InsertCommand, "pallet_0", OracleType.Number, DataRowVersion.Current)
            Parametro(.InsertCommand, "nroiram_0", OracleType.VarChar, DataRowVersion.Current)
            Parametro(.InsertCommand, "largo_0", OracleType.Number, DataRowVersion.Current)
            Parametro(.InsertCommand, "ok_0", OracleType.Number, DataRowVersion.Current)
            Parametro(.InsertCommand, "presion_0", OracleType.VarChar, DataRowVersion.Current)
            Parametro(.InsertCommand, "obs_0", OracleType.VarChar, DataRowVersion.Current)
            Parametro(.InsertCommand, "usuario_0", OracleType.VarChar, DataRowVersion.Current)

            Parametro(.DeleteCommand, "yitnnum_0", OracleType.VarChar, DataRowVersion.Original)
            Parametro(.DeleteCommand, "macnum_0", OracleType.VarChar, DataRowVersion.Original)
        End With

    End Sub
    Private Sub frmRecepcion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Adaptadores()

        itn = New Intervencion(cn)
        sre = New Solicitud(cn)
        mac = New Parque(cn)

        mlRecargador = New MenuLocal(cn, 8520, False)
        mlRecargador.Enlazar(cboRecargador)

        'Obtengo puerto de impresora Zebra
        PuertoImpresora = getPuerto()
        txtPuesto.Text = getPuesto()
    End Sub
    Private Sub frmRecepcion_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        GuardarResumen()
    End Sub
    Private Sub TratarVidaUtil()
        Dim f As New frmVidaUtil(mac)

        f.ShowDialog()

        Select Case f.Accion

            Case frmVidaUtil.TipoAccion.CambioAño
                mac.FabricacionCorto = CInt(f.NumericUpDown1.Value)

            Case frmVidaUtil.TipoAccion.Procesar
                'no se hace nada

            Case frmVidaUtil.TipoAccion.Rechazar
                mac.Rechazar(itn, 1, " ", 0, 0, 0, 0, 0)
                mac.ImprimirRechazo(itn, CLng(lblPallet.Tag), Application.StartupPath, PuertoImpresora)

        End Select

        f.Dispose()

    End Sub
    Private Sub ActualizarGrilla()
        Dim dr As DataRow

        For Each dr In dt.Rows
            If dr("macnum_0", DataRowVersion.Original).ToString = mac.Serie Then
                dr.Delete()
                da.Update(dt)
                Exit For
            End If
        Next

        'El equipo NO está en la Solicitud de Servicio
        dr = dt.NewRow
        dr("srenum_0") = txtSre.Text
        dr("itngru_0") = " "
        dr("macnum_0") = mac.Serie
        dr("pblnum_0") = " "
        dr("covflg_0") = 3
        dr("covspt_0") = 6
        dr("covvcr_0") = " "
        dr("maccovren_0") = 1
        dr("credat_0") = Date.Today
        dr("creusr_0") = usr.Codigo
        dr("upddat_0") = #12/31/1599#
        dr("updusr_0") = " "
        dr("yflgmrk_0") = 2

        If mac.LlevaTarjeta Then
            dr("yflgtrj_0") = IIf(mac.Rechazado, 2, 1)
            'dr("yitnnum_0") = IIf(mac.Rechazado, txtItn.Text, " ")

        Else
            dr("yflgtrj_0") = 2
            'dr("yitnnum_0") = txtItn.Text

        End If

        dr("yitnnum_0") = txtItn.Text
        dr("srelig_0") = NroLinea(dt)
        dr("pallet_0") = CLng(lblPallet.Tag)

        '--
        dr("macpdtcod_0") = mac.ArticuloCodigo
        dr("macdes_0") = mac.ArticuloDescripcion
        dr("ynrocil_0") = mac.Cilindro
        dr("yfabdat_0") = mac.FabricacionLargo
        dr("macitntyp_0") = IIf(mac.Rechazado, 5, 1)
        dr("recargador_0") = mac.UltimoRecargador
        dr("patente_0") = mac.Patente
        dr("nroiram_0") = 0
        dr("largo_0") = 0
        dr("ok_0") = 2
        dr("presion_0") = " "
        dr("obs_0") = " "
        dr("usuario_0") = " "

        dt.Rows.InsertAt(dr, 0)

        'Actualizo la tabla SREMAC
        Try
            da.Update(dt)

            'Imprimir etiqueta de codigo de barras
            If DB_USR = "GEOPROD" Then
                If Not mac.Rechazado Then mac.ImprimirEtiqueta(txtItn.Text, Application.StartupPath, PuertoImpresora, txtPuesto.Text)
            Else
                If Not mac.Rechazado AndAlso MessageBox.Show("¿Imprimir etiqueta?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    mac.ImprimirEtiqueta(txtItn.Text, Application.StartupPath, PuertoImpresora, txtPuesto.Text)
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ActualizarGrilla()", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            txtBuscar.Clear()

        End Try

    End Sub
    Private Sub BuscarSerie(ByVal txt As String)
        'Cargo el parque
        If Not mac.Abrir(txt) Then
            MessageBox.Show("No se encontró el parque", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        'Valido cliente
        If mac.ClienteNumero <> txtCodigo.Text Then

            If itn.Tipo = "B2" Then
                'Cambio automático de cliente para CANJES
                mac.ClienteNumero = txtCodigo.Text

            Else
                Dim bpa As New Sucursal(cn, mac.ClienteNumero, mac.SucursalNumero)

                txt = "Este equipo pertenece a otro cliente{0}{0}{1} {2}{0}{3}{0}{0}¿Confirma pasar el equipo de cliente?"
                txt = String.Format(txt, vbCrLf, bpa.Tercero, mac.Cliente.Nombre, bpa.Direccion)

                If MessageBox.Show(txt, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    mac.ClienteNumero = txtCodigo.Text

                Else
                    mac.Deshacer()
                    Exit Sub

                End If

            End If

        End If

        'Cambio sucursal
        mac.SucursalNumero = txtSuc.Text

        'Valido si está rechazado
        If mac.Rechazado Then
            txt = "Este equipo figura en el sistema como rechazado.{0}{0}¿Desea poner el equipo como APTO?"
            txt = String.Format(txt, vbCrLf)

            If MessageBox.Show(txt, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                mac.QuitarRechazo()
            End If

        End If

        'Valido vida util
        If mac.SuperaVidaUtil Then
            '2019.01.23 - FIN VIDA UTIL EDENOR
            'Al cliente EDENOR no se les rechaza los equipos durante su ultimo año de vida util
            If mac.ClienteNumero <> CLIENTE_EDENOR Or mac.FinVidaUtil <> Today.Year Then

                TratarVidaUtil()

            End If

        End If

        'Procesa el equipo
        If Not mac.Rechazado Then mac.ProcesarExtintor()

        '2019.01.23 - FIN VIDA UTIL EDENOR
        'Al cliente EDENOR no se les rechaza los equipos durante su ultimo año de vida util
        If mac.ClienteNumero = CLIENTE_EDENOR AndAlso mac.FinVidaUtil = Today.Year Then
            mac.VtoCarga = New Date(Today.Year, 12, 31)
        End If

        mac.UltimoRecargador = CInt(cboRecargador.SelectedValue)

        'Numero de Patente
        If mnuPatente.Checked Then TratarPatente(mac)

        'Grabo todos los cambios
        mac.Grabar()

        'Actualizo la grilla
        ActualizarGrilla()

        If Not Tab.SelectedTab Is TabIntervencion Then
            Tab.SelectedTab = TabIntervencion
        End If

    End Sub
    Private Sub TratarPatente(ByVal mac As Parque)
        Dim txt As String = mac.Patente
        Dim salir As Boolean = False

        Do
            txt = InputBox("Ingrese el número de patente", "Patente", txt)
            txt = txt.Trim

            Select Case txt.Length
                Case 0
                    If MessageBox.Show("¿Confirma no ingresar patente?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                        salir = True
                    End If

                Case 6, 7
                    salir = True

                Case Else
                    MessageBox.Show("El número de patente no es válido", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            End Select

        Loop Until salir

        If txt <> "" Then mac.Patente = txt

    End Sub
    Private Sub ImprimirPallet(ByVal Nro As Long)
        Dim rpt As New ReportDocument
        Dim da As OracleDataAdapter
        Dim dt As DataTable
        Dim txt As String

        Try
            txt = "SELECT DISTINCT pallet_0 "
            txt &= "FROM sremac "
            txt &= "WHERE yitnnum_0 IN (SELECT yitnnum_0 FROM sremac WHERE pallet_0 = :pallet) AND pallet_0 > 0 "
            txt &= "GROUP BY yitnnum_0, pallet_0 "
            txt &= "ORDER BY pallet_0"

            da = New OracleDataAdapter(txt, cn)
            da.SelectCommand.Parameters.Add("pallet", OracleType.VarChar).Value = Nro
            dt = New DataTable
            da.Fill(dt)

            rpt.Load(RPTX3 & "XPALLET2.rpt")
            rpt.SetDatabaseLogon(DB_USR, DB_PWD)

            For Each dr As DataRow In dt.Rows
                Dim x As Integer = CInt(dr(0))
                rpt.SetParameterValue("PALLET", CInt(dr(0)))
                rpt.PrintToPrinter(1, False, 1, 100)
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try
        rpt.Dispose()
        rpt = Nothing

    End Sub

    'FUNCTION
    Private Function BuscarCilindro(ByVal Cilindro As String, ByVal Cliente As String) As String
        Dim da1 As New OracleDataAdapter("SELECT * FROM machines WHERE ynrocil_0 = :ynrocil_0 AND bpcnum_0 = :bpcnum_0 ORDER BY macnum_0 DESC", cn)
        Dim da2 As New OracleDataAdapter("SELECT * FROM ymacitm WHERE macnum_0 = :macnum_0", cn)
        Dim dt1 As New DataTable
        Dim dt2 As New DataTable

        With da1
            .SelectCommand.Parameters.Add("ynrocil_0", OracleType.VarChar)
            .SelectCommand.Parameters.Add("bpcnum_0", OracleType.VarChar)
        End With

        With da2
            .SelectCommand.Parameters.Add("macnum_0", OracleType.VarChar)
        End With

        dt1.Clear()

        da1.SelectCommand.Parameters("ynrocil_0").Value = Cilindro
        da1.SelectCommand.Parameters("bpcnum_0").Value = Cliente
        da1.Fill(dt1)

        If da1.DeleteCommand Is Nothing Then
            da1.DeleteCommand = New OracleCommandBuilder(da1).GetDeleteCommand
        End If

        If dt1.Rows.Count > 1 Then
            dt2.Clear()

            For i As Integer = 1 To dt1.Rows.Count - 1
                da2.SelectCommand.Parameters("macnum_0").Value = dt1.Rows(i).Item("macnum_0").ToString
                da2.Fill(dt2)

                dt1.Rows(i).Delete()
            Next

            If da2.DeleteCommand Is Nothing Then
                da2.DeleteCommand = New OracleCommandBuilder(da2).GetDeleteCommand
            End If
            For i As Integer = 0 To dt2.Rows.Count - 1
                dt2.Rows(i).Delete()
            Next

            Try
                da1.Update(dt1)
                da2.Update(dt2)

            Catch ex As Exception
                MessageBox.Show(ex.Message, "mnuCilindro_Click()", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End If

        If dt1.Rows.Count = 0 Then
            BuscarCilindro = ""

        Else
            BuscarCilindro = dt1.Rows(0).Item("macnum_0").ToString

        End If

        dt1.Dispose()
        dt2.Dispose()
        da1.Dispose()
        da2.Dispose()

    End Function
    Private Function NroLinea(ByVal dt As DataTable) As Integer
        Dim dr As DataRow
        Dim i As Integer = 0

        For Each dr In dt.Rows
            If CInt(dr("srelig_0", DataRowVersion.Original)) > i Then
                i = CInt(dr("srelig_0", DataRowVersion.Original))
            End If
        Next

        Return i + 1

    End Function

    'EVENTOS
    Private Sub itn_IntervencionAbierta(ByVal sender As Object) Handles itn.IntervencionAbierta
        Dim itn = CType(sender, Intervencion)

        'Recupero la solicitud
        sre = itn.SolicitudAsociada

        dgv.Enabled = True

        If sre.Estado = Solicitud.EstadoSolicitud.Cerrada Then
            MessageBox.Show("La Solicitud de Servicio está cerrada", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtBuscar.Enabled = False
            'dgv.Enabled = False
            dgv.ReadOnly = True

        ElseIf itn.Remito.Trim <> "" Then
            MessageBox.Show("La intervención ya está remitada.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtBuscar.Enabled = False
            'dgv.Enabled = False
            dgv.ReadOnly = True

        ElseIf itn.Reclamo Then
            MessageBox.Show("Esta intervención está marcada como reclamo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtBuscar.Enabled = False
            'dgv.Enabled = False
            dgv.ReadOnly = True

        ElseIf itn.Tipo = "H1" Then
            MessageBox.Show("Intervencion tipo " & itn.Tipo & ". No se puede recepcionar.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtBuscar.Enabled = False
            'dgv.Enabled = False
            dgv.ReadOnly = True

        Else
            'Elimino del parque de la solicitud los equipos borrados del parque y
            'Marco Equipos Sin Tarjetas
            sre.LimpiarParque()
            sre.MarcarEquiposSinTarjetas()

            txtBuscar.Enabled = True
            dgv.Enabled = True
            dgv.ReadOnly = False

            'Pongo a la intervencion en el sector service
            itn.Sector = "SRV"
            itn.Grabar()

            'Cargo las mangueras del parque del cliente
            ObtenerParqueMangas()

        End If

        txtItn.Text = itn.Numero
        txtSre.Text = sre.Numero

        If itn.Observaciones <> "" Then MsgBox(itn.Observaciones)

        With itn.Cliente
            txtCodigo.Text = .Codigo
            txtSuc.Text = itn.SucursalCodigo
            txtNombre.Text = .Nombre
        End With

        txtDireccion.Text = itn.SucursalCalle & " (" & itn.SucursalCiudad & ")"

        'Recupero el parque cargado en la Solicitud de Servicio
        'da.SelectCommand.Parameters("srenum_0").Value = sre.Numero
        da.SelectCommand.Parameters("yitnnum_0").Value = itn.Numero
        da.Fill(dt)

        'Vista para filtrar el parque a mostrar en la grilla
        If dv Is Nothing Then dv = New DataView(dt)

        dv.RowFilter = "(yflgtrj_0 = 1 AND yitnnum_0 = ' ') OR yitnnum_0 = '" & itn.Numero & "'"

        'Enlazo la grilla
        For Each c As DataGridViewColumn In dgv.Columns
            c.DataPropertyName = c.Name
        Next
        'Enlazo el combobox de la grilla
        mlRecargador.Enlazar(recargador_0)

        dgv.DataSource = dv

    End Sub
    Private Sub dgv_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgv.RowPostPaint
        On Error Resume Next

        Dim strRowNumber = (e.RowIndex + 1).ToString()

        Dim size As System.Drawing.SizeF
        size = e.Graphics.MeasureString(strRowNumber, dgv.Font)

        If (dgv.RowHeadersWidth < CInt(size.Width + 20)) Then
            dgv.RowHeadersWidth = CInt(size.Width + 20)
        End If

        Dim b As System.Drawing.Brush = SystemBrushes.ControlText

        e.Graphics.DrawString(strRowNumber, dgv.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))

    End Sub
    Private Sub dgv_RowPrePaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles dgv.RowPrePaint

        If CInt(dgv.Rows(e.RowIndex).Cells("macitntyp_0").Value) = 5 Then
            dgv.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Drawing.Color.Red
        End If

    End Sub
    Private Sub dgv_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgv.UserDeletedRow
        Try
            da.Update(dt)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "gv_UserDeletedRow()", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            txtBuscar.Focus()

        End Try

    End Sub
    Private Sub dgv_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgv.UserDeletingRow
        If MessageBox.Show("¿Confirma la eliminación de la línea?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
            e.Cancel = True
            txtBuscar.Focus()

        Else
            e.Cancel = False

        End If
    End Sub
    Private Sub txtBuscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscar.KeyPress

        If Asc(e.KeyChar) = Keys.Enter AndAlso txtBuscar.Text.Length > 0 Then BuscarSerie(txtBuscar.Text)

    End Sub
    Private Sub mac_CambioPolvo(ByVal sender As Object, ByVal e As EventArgs) Handles mac.CambioPolvo
        MessageBox.Show("¡ATENCION!" & vbCrLf & vbCrLf & "A este equipo le corresponde cambio de polvo", "Aviso de cambio de Polvo", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    Private Sub Cerrar()
        GuardarResumen()

        txtCodigo.Clear()
        txtDireccion.Clear()
        txtItn.Clear()
        txtNombre.Clear()
        txtSre.Clear()
        txtSuc.Clear()
        txtBuscar.Enabled = False
        dt.Clear()
        dgv.Enabled = False
        mnuAlta.Enabled = False
        mnuCilindro.Enabled = False

    End Sub
    Private Sub GuardarResumen()
        'Salgo si no hay intervencion abierta
        If txtItn.Text = "" Then Exit Sub

        'Guarda en la tabla XSEGTO2 la cantidad de equipos y mangas
        'que entraron a fabrica con la intervención
        Dim xsg As New Segto2(cn)
        Dim Cant(1) As Integer
        Dim Rech(1) As Integer
        Dim dr As DataRow
        Dim i As Integer = 0

        'Inicio variable a cero
        For i = 0 To 1
            Cant(i) = 0
            Rech(i) = 0
        Next

        'Hago recuento de extintores y mangas
        For i = 0 To dv.Count - 1
            dr = dv.Item(i).Row

            If dr("macdes_0").ToString.StartsWith("EXT") Then
                If CInt(dr("macitntyp_0")) = 1 Then
                    Cant(0) += 1

                ElseIf CInt(dr("macitntyp_0")) = 5 Then
                    Rech(0) += 1

                End If

            ElseIf dr("macdes_0").ToString.StartsWith("MANG") Then
                If CInt(dr("macitntyp_0")) = 1 Then
                    Cant(1) += 1

                ElseIf CInt(dr("macitntyp_0")) = 5 Then
                    Rech(1) += 1

                End If

            End If

        Next

        If xsg.Abrir(txtItn.Text) Then 'Intento abrir la intervencion

            If xsg.FechaIngresoService = #12/31/1599# Then xsg.FechaIngresoService = Date.Today

        Else
            xsg.Nuevo(txtItn.Text)
            xsg.FechaIngresoPlanta = Date.Today
            xsg.FechaIngresoService = Date.Today
            xsg.Equipos = Cant(0) + Cant(1)
        End If

        xsg.EquiposLeidos = Cant(0)
        xsg.EquiposRechazados = Rech(0)
        xsg.MangasLeidas = Cant(1)
        xsg.MangasRechazadas = Rech(1)
        xsg.Grabar()

    End Sub

    'MENU
    Private Sub mnuAbrir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAbrir.Click

        If lblPallet.Text = "" Then
            MessageBox.Show("Primero debe abrir un Pallet", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand)
            Exit Sub
        End If

        Cerrar()

        Dim txt As String = InputBox("Escriba el número de intervención", "Abrir intervención", "")

        If txt <> "" Then
            Application.DoEvents()

            Me.Cursor = Cursors.WaitCursor

            txt = txt.ToUpper

            If Not itn.Abrir(txt) Then
                MessageBox.Show("No se encontró la intervención", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else
                mnuAlta.Enabled = True
                mnuCilindro.Enabled = True

                '***********************************************************
                ' 14.09.2017 B2 Paso equipos del cliente al parque de Donny
                '***********************************************************
                If itn.Tipo = "B2" Then PasarADonny()

            End If

            Me.Cursor = Cursors.Default

            txtBuscar.Focus()

            cboRecargador.SelectedValue = 1

        End If

    End Sub
    Private Sub mnuAlta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAlta.Click
        Dim f As frmParque

        mac.Nuevo(txtCodigo.Text, txtSuc.Text)

        f = New frmParque(mac)

        f.ShowDialog()

        If f.DialogResult = Windows.Forms.DialogResult.OK Then
            txtBuscar.Text = mac.Serie
            BuscarSerie(txtBuscar.Text)
        End If

        f.Dispose()

        f = Nothing

        txtBuscar.Focus()

    End Sub
    Private Sub mnuCilindro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCilindro.Click
        Dim txt As String

        txt = InputBox("Ingrese el número de cilindro a buscar", "Buscar por cilindro")
        txt = txt.Trim

        If txt <> "" Then
            txt = BuscarCilindro(txt, txtCodigo.Text)
            If txt <> "" Then
                BuscarSerie(txt)

            Else
                MessageBox.Show("No se encontró el cilindro en el parque del cliente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

        End If

    End Sub
    Private Sub mnuConsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuConsulta.Click
        Dim rpt As New ReportDocument
        Dim f As frmCrystal

        Try
            rpt.Load(RPTX3 & "XINGRESOS.rpt")
            rpt.SetParameterValue("DAT", Date.Today)
            rpt.SetParameterValue("X3TIT", "Ingresos del : " & Date.Today)
            f = New frmCrystal(rpt)
            f.MdiParent = Me.MdiParent
            f.Text = "Ingresos del : " & Date.Today
            f.Show()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        Exit Sub
    End Sub
    Private Sub mnuRecargadores_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRecargadores.Click
        Dim f As frmRecargador

        f = New frmRecargador(mlRecargador)
        f.ShowDialog()

        If f.DialogResult = Windows.Forms.DialogResult.OK Then
            cboRecargador.SelectedValue = f.Selecionado
        End If
        f.Dispose()

        txtBuscar.Focus()
    End Sub
    Private Sub CambiarPalletToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CambiarPalletToolStripMenuItem.Click
        Dim n As Long
        Dim txt As String

        'Si hay pallet abierto, invito imprimir antes de cambiar
        If lblPallet.Text <> "" AndAlso lblPallet.Text <> "0" Then
            txt = "¿Imprime el Pallet {PALLET} antes de cambiar?"
            txt = txt.Replace("{PALLET}", lblPallet.Text)

            If MessageBox.Show(txt, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                ImprimirPallet(CLng(lblPallet.Tag))
            End If

        End If

        'Pregunto numero de palet
        txt = InputBox("Ingrese el nuevo número de Pallet", Me.Text, "")
        txt = txt.Trim

        If txt <> "" AndAlso IsNumeric(txt) Then

            n = CLng(txt)

            lblPallet.Text = n.ToString("N0").Replace(",", ".")
            lblPallet.Tag = n

        Else
            MessageBox.Show("No se pudo abrir el Pallet", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)

        End If

    End Sub

    'CONTEXT MENU INTERVENCION
    Private Sub ContextMenuGrilla_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuGrilla.Opening

        If txtBuscar.Enabled = False Then
            e.Cancel = True

        ElseIf dgv.SelectedRows.Count = 0 Then
            e.Cancel = True

        ElseIf dgv.SelectedRows.Count = 1 Then

            Dim dgvr As DataGridViewRow = dgv.SelectedRows(0)

            If CInt(dgvr.Cells("macitntyp_0").Value) = 5 Then
                mnuEditar.Enabled = False
                mnuBaja.Enabled = False
                mnuAnularBaja.Enabled = True
            Else
                mnuEditar.Enabled = True
                mnuBaja.Enabled = True
                mnuAnularBaja.Enabled = False
            End If

            mnuImprimir.Enabled = True

        Else
            mnuEditar.Enabled = False
            mnuBaja.Enabled = False
            mnuAnularBaja.Enabled = False
            mnuImprimir.Enabled = True

        End If

    End Sub
    Private Sub mnuAnularBaja_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAnularBaja.Click
        Dim dgvr As DataGridViewRow = dgv.SelectedRows(0)
        Dim Serie As String = dgvr.Cells("macnum_0").Value.ToString

        Dim dr As DataRowView = DirectCast(dgvr.DataBoundItem, DataRowView)

        If mac.Abrir(Serie) Then
            Try
                mac.QuitarRechazo()
                mac.Grabar()

                dgvr.DefaultCellStyle.ForeColor = Drawing.Color.Black

                dr.BeginEdit()
                dr("macitntyp_0") = 1
                'dr("yflgtrj_0") = 1
                'dr("yitnnum_0") = " "
                dr.EndEdit()

                da.Update(dt)

                MessageBox.Show("El parque fue reactivado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch ex As Exception
                MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End If

        txtBuscar.Focus()

    End Sub
    Private Sub mnuBaja_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuBaja.Click

        Dim dgvr As DataGridViewRow = dgv.SelectedRows(0)
        Dim Serie As String = dgvr.Cells("macnum_0").Value.ToString
        Dim f As frmBajas

        Dim dr As DataRowView = DirectCast(dgvr.DataBoundItem, DataRowView)

        If mac.Abrir(Serie) Then

            '2019.01.31 
            'Equipos de EDENOR no se deben rechazar durante su ultimo año de vida útil
            '
            If mac.ClienteNumero = CLIENTE_EDENOR AndAlso mac.FinVidaUtil = Today.Year Then
                Dim txt As String
                txt = "¡ATENCIÓN!" & vbCrLf & vbCrLf
                txt &= "No se deben rechazar equipos de EDENOR fabricación " & mac.FinVidaUtil.ToString & vbCrLf & vbCrLf
                txt &= "¿Continúa con el rechazo del equipo?"

                If MessageBox.Show(txt, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                    Exit Sub
                End If

            End If

            f = New frmBajas(mac)

            f.ShowDialog()

            If f.DialogResult = Windows.Forms.DialogResult.OK Then
                Try
                    If mac.EsManguera Then
                        mac.Rechazar(itn, CInt(f.lstMotivos.SelectedValue), f.txtObs.Text, f.cboTipo.SelectedIndex, f.cboLongitud.SelectedIndex, CInt(f.txtReal.Text), f.cboDiametro.SelectedIndex, CInt(f.cboSello.SelectedValue))
                    Else
                        mac.Rechazar(itn, CInt(f.lstMotivos.SelectedValue), f.txtObs.Text, 0, 0, 0, 0, 0)
                    End If
                    mac.Cilindro = f.txtCilindro.Text
                    mac.Grabar()

                    dgvr.DefaultCellStyle.ForeColor = Drawing.Color.Red

                    dr.BeginEdit()
                    dr("macitntyp_0") = 5
                    dr("yflgtrj_0") = 2
                    dr("yitnnum_0") = itn.Numero
                    dr.EndEdit()

                    da.Update(dt)

                    'Imprimir etiqueta de Rechazo
                    mac.ImprimirRechazo(itn, CLng(lblPallet.Tag), Application.StartupPath, PuertoImpresora)

                    MessageBox.Show("El parque fue dado de baja.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

                Catch ex As Exception
                    MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub

                End Try

            End If

            f.Dispose()

        End If

        txtBuscar.Focus()

    End Sub
    Private Sub mnuEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEditar.Click
        Dim dgvr As DataGridViewRow = dgv.SelectedRows(0)
        Dim Serie As String = dgvr.Cells("macnum_0").Value.ToString
        Dim f As frmParque

        If mac.Abrir(Serie) Then
            f = New frmParque(mac)
            f.ShowDialog()

            If f.DialogResult = Windows.Forms.DialogResult.OK Then
                'Actualizar la informacion de la grilla
                With dgvr
                    .Cells("macpdtcod_0").Value = mac.ArticuloCodigo
                    .Cells("macdes_0").Value = mac.ArticuloDescripcion
                    .Cells("ynrocil_0").Value = mac.Cilindro
                    .Cells("yfabdat_0").Value = mac.FabricacionLargo
                End With
            End If

        End If

        txtBuscar.Focus()

    End Sub
    Private Sub mnuImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuImprimir.Click
        Dim dgvr As DataGridViewRow
        Dim Serie As String

        If DB_USR <> "GEOPROD" AndAlso MessageBox.Show("¿Imprime etiqueta?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If

        For Each dgvr In dgv.SelectedRows
            Serie = dgvr.Cells("macnum_0").Value.ToString

            If Not mac.Abrir(Serie) Then Continue For

            If mac.Rechazado Then
                mac.ImprimirRechazo(itn, CLng(lblPallet.Tag), Application.StartupPath, PuertoImpresora)
            Else
                mac.ImprimirEtiqueta(txtItn.Text, Application.StartupPath, PuertoImpresora, txtPuesto.Text)
            End If

        Next

    End Sub
    Private Sub mnuRecargador_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRecargador.Click

        Dim dgvr As DataGridViewRow
        Dim Serie As String
        Dim dr As DataRowView
        Dim f As frmRecargador

        f = New frmRecargador(mlRecargador)
        f.ShowDialog()

        If f.DialogResult = Windows.Forms.DialogResult.OK Then

            For Each dgvr In dgv.SelectedRows
                dr = DirectCast(dgvr.DataBoundItem, DataRowView)

                Serie = dgvr.Cells("macnum_0").Value.ToString

                If mac.Abrir(Serie) Then

                    mac.UltimoRecargador = f.Selecionado

                    mac.Grabar()
                    dr.BeginEdit()
                    dr("recargador_0") = mac.UltimoRecargador
                    dr.EndEdit()

                    txtBuscar.Focus()

                End If

                f.Dispose()

            Next

        End If

    End Sub
    Private Sub mnuPallet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPallet.Click
        'Modifica el Nro de Pallet de los items seleccionados en la grilla
        Dim dgvr As DataGridViewRow
        Dim dr As DataRowView
        Dim txt As String
        Dim n As Long = -1

        'Pregunto numero de palet
        txt = InputBox("Ingrese el nuevo número de Pallet", Me.Text, "")
        txt = txt.Trim

        If txt <> "" AndAlso IsNumeric(txt) Then

            n = CLng(txt)

        End If

        'Salgo si no se ingreso nro de palet
        If n < 0 Then Exit Sub

        For Each dgvr In dgv.SelectedRows
            dr = DirectCast(dgvr.DataBoundItem, DataRowView)

            dr.BeginEdit()
            dr("pallet_0") = txt
            dr.EndEdit()

            da.Update(dt)

        Next

    End Sub

    Private Sub ObtenerParqueMangas()
        Dim da As OracleDataAdapter
        Dim dt As DataTable
        Dim Sql As String

        Sql = "SELECT ynrocil_0 AS cilindro, macdes_0 AS tipo, yfabdat_0 AS fab, datnext_0 AS vto, mac.macnum_0 AS serie "
        Sql &= "FROM (machines mac INNER JOIN ymacitm ymc ON (mac.macnum_0 = ymc.macnum_0)) INNER JOIN bomd bmd ON (mac.macpdtcod_0 = itmref_0 AND ymc.cpnitmref_0 = bmd.cpnitmref_0) "
        Sql &= "WHERE macdes_0 LIKE 'MANGUERA%' AND bomalt_0 = 99 AND bomseq_0 = 10 AND mac.bpcnum_0 = :bpcnum_0 AND fcyitn_0 = :fcyitn_0 "

        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("bpcnum_0", OracleType.VarChar).Value = txtCodigo.Text
        da.SelectCommand.Parameters.Add("fcyitn_0", OracleType.VarChar).Value = txtSuc.Text

        With dgvMangas
            If .DataSource Is Nothing Then
                dt = New DataTable
            Else
                dt = CType(.DataSource, DataTable)
            End If

            dt.Clear()
            da.Fill(dt)

            If .DataSource Is Nothing Then
                .DataSource = dt
            End If

        End With

    End Sub
    Private Sub dgvMangas_DataBindingComplete(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles dgvMangas.DataBindingComplete

        With dgvMangas
            For i As Integer = 0 To .Columns.Count - 1
                .Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            Next
        End With
    End Sub

    'CONTECT MENU MANGUERAS
    Private Sub cmnMangas_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmnMangas.Opening
        If dgvMangas.SelectedRows.Count <> 1 Then e.Cancel = True
    End Sub
    Private Sub mnuAddToIntervencion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAddToIntervencion.Click
        Dim dgvr As DataGridViewRow = dgvMangas.SelectedRows(0)

        txtBuscar.Text = dgvr.Cells(4).Value.ToString
        BuscarSerie(txtBuscar.Text)

    End Sub
    Private Sub ImprimirPalletToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImprimirPalletToolStripMenuItem.Click
        Dim txt As String
        Dim n As Long

        txt = "Ingrese el número de Pallet a imprimir"
        txt = InputBox(txt, Me.Text, lblPallet.Text)

        If txt <> "" AndAlso IsNumeric(txt) Then

            n = CLng(txt)
            If n > 0 Then ImprimirPallet(n)

        Else
            MessageBox.Show("No se pudo imprimir el Pallet", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)

        End If

    End Sub
    Private Sub mnuPatente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPatente.Click
        lblPatente.Visible = mnuPatente.Checked
    End Sub

    Private Sub mnuPuerto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPuerto.Click
        Dim port As String = getPuerto()

        port = InputBox("Ingrese el nombre del recurso Z", Me.Text, port)
        port = port.Trim

        If port <> "" Then
            setPuerto(port)
            PuertoImpresora = port
        End If

    End Sub

    Private Function getPuerto() As String
        Dim RegKey As RegistryKey
        Dim s As String = ""

        Try
            'Creo o abro clave del registro
            RegKey = Registry.CurrentUser.OpenSubKey("Software", True).CreateSubKey("Georgia")
            s = RegKey.GetValue("SERVICE").ToString
            RegKey.Close()

        Catch ex As Exception
            'MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        Return s

    End Function
    Private Sub setPuerto(ByVal s As String)
        Dim RegKey As RegistryKey

        Try
            'Creo o abro clave del registro
            RegKey = Registry.CurrentUser.OpenSubKey("Software", True).CreateSubKey("Georgia")
            RegKey.SetValue("SERVICE", s)
            RegKey.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub
    Private Function getPuesto() As String
        Dim RegKey As RegistryKey
        Dim s As String = ""

        Try
            'Creo o abro clave del registro
            RegKey = Registry.CurrentUser.OpenSubKey("Software", True).CreateSubKey("Georgia")
            s = RegKey.GetValue("PUESTO").ToString
            RegKey.Close()

        Catch ex As Exception
            'MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        Return s

    End Function
    Private Sub setPuesto(ByVal s As String)
        Dim RegKey As RegistryKey

        Try
            'Creo o abro clave del registro
            RegKey = Registry.CurrentUser.OpenSubKey("Software", True).CreateSubKey("Georgia")
            RegKey.SetValue("PUESTO", s)
            RegKey.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub
    Private Sub PasarADonny()
        'Pasa los equipos marcados con esta intervención al parque de Matafuegos Donny 402000/001
        Dim sql As String
        Dim dt As New DataTable
        Dim cm As OracleCommand
        Dim I As Integer

        'Cambio numero de cliente en la tabla YMACITM
        sql = "UPDATE ymacitm SET bpcnum_0 = '402000' WHERE macnum_0 in (SELECT macnum_0 FROM machines WHERE xitn_0 = :xitn)"
        cm = New OracleCommand(sql, cn)
        cm.Parameters.Add("xitn", OracleType.VarChar).Value = itn.Numero
        I = cm.ExecuteNonQuery()

        sql = "UPDATE machines SET bpcnum_0 = '402000', maccutbpc_0 = '402000', fcyitn_0 = '001' WHERE xitn_0 = :xitn"
        cm = New OracleCommand(sql, cn)
        cm.Parameters.Add("xitn", OracleType.VarChar).Value = itn.Numero
        I = cm.ExecuteNonQuery()

    End Sub

    Private Sub ResumenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResumenToolStripMenuItem.Click
        Dim f As New frmRecepcionResumen(txtItn.Text)

        'f.MdiParent = Me.ParentForm
        f.ShowDialog()

    End Sub

    Private Sub mnuRastreo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRastreo.Click
        Dim Sql As String
        Dim Nro As String

        Nro = InputBox("Codigo de Barra", "Rastreo de equipo")
        Nro = Nro.Trim

        If Nro <> "" Then
            Sql = ""
        End If
    End Sub

    Private Sub txtPuesto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPuesto.LostFocus
        Dim t As TextBox = CType(sender, TextBox)
        setPuesto(t.Text)
    End Sub

End Class