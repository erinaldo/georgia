Imports System.Data.OracleClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class frmSeguimiento
    Private SECTOR_ORIGEN As String
    Private itn As New Intervencion(cn)
    Private rto As New Remito(cn)
    Private ItnRemito As New Intervencion(cn)
    Private RtoDevolucion As New Remito(cn)
    Private WithEvents daEnviados As OracleDataAdapter
    Private daRecibidos As OracleDataAdapter
    Private WithEvents dtEnviados As New DataTable
    Private dtRecibidos As New DataTable
    Private WithEvents Doc As New Documento(cn)
    Private txtActual As TextBox
    Private ds As New DataSet
    Private Lck As New Bloqueo(cn)

    Public Sub New(ByVal Sector As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.SECTOR_ORIGEN = Sector

    End Sub
    Private Sub Adaptadores()
        Dim Sql As String

        Sql = "SELECT * FROM xsegto WHERE de_0 = :de_0 AND recibido_0 = 1 ORDER BY fecha_0 DESC, hora_0 DESC"
        daEnviados = New OracleDataAdapter(Sql, cn)
        daEnviados.SelectCommand.Parameters.Add("de_0", OracleType.VarChar)

        Sql = "INSERT INTO xsegto VALUES (:fecha_0, :hora_0, :usr_0, :numlig_0, :itn_0, :rto_0, :ped_0, :bpcnum_0, :bpcnam_0, :de_0, :para_0, :recibido_0, :usrrecibe_0)"
        daEnviados.InsertCommand = New OracleCommand(Sql, cn)

        Sql = "UPDATE xsegto SET para_0 = :para_0 WHERE :fecha_0 = :fecha_0 AND hora_0 = :hora_0 AND usr_0 = :usr_0 AND numlig_0 = :numlig_0"
        daEnviados.UpdateCommand = New OracleCommand(Sql, cn)

        Sql = "DELETE FROM xsegto WHERE :fecha_0 = :fecha_0 AND hora_0 = :hora_0 AND usr_0 = :usr_0 AND numlig_0 = :numlig_0"
        daEnviados.DeleteCommand = New OracleCommand(Sql, cn)

        With daEnviados
            Parametro(.InsertCommand, "fecha_0", OracleType.DateTime, DataRowVersion.Current)
            Parametro(.InsertCommand, "hora_0", OracleType.VarChar, DataRowVersion.Current)
            Parametro(.InsertCommand, "usr_0", OracleType.VarChar, DataRowVersion.Current)
            Parametro(.InsertCommand, "numlig_0", OracleType.Number, DataRowVersion.Current)
            Parametro(.InsertCommand, "itn_0", OracleType.VarChar, DataRowVersion.Current)
            Parametro(.InsertCommand, "rto_0", OracleType.VarChar, DataRowVersion.Current)
            Parametro(.InsertCommand, "ped_0", OracleType.VarChar, DataRowVersion.Current)
            Parametro(.InsertCommand, "bpcnum_0", OracleType.VarChar, DataRowVersion.Current)
            Parametro(.InsertCommand, "bpcnam_0", OracleType.VarChar, DataRowVersion.Current)
            Parametro(.InsertCommand, "de_0", OracleType.VarChar, DataRowVersion.Current)
            Parametro(.InsertCommand, "para_0", OracleType.VarChar, DataRowVersion.Current)
            Parametro(.InsertCommand, "recibido_0", OracleType.Number, DataRowVersion.Current)
            Parametro(.InsertCommand, "usrrecibe_0", OracleType.VarChar, DataRowVersion.Current)

            Parametro(.UpdateCommand, "para_0", OracleType.VarChar, DataRowVersion.Current)
            Parametro(.UpdateCommand, "fecha_0", OracleType.DateTime, DataRowVersion.Original)
            Parametro(.UpdateCommand, "hora_0", OracleType.VarChar, DataRowVersion.Original)
            Parametro(.UpdateCommand, "usr_0", OracleType.VarChar, DataRowVersion.Original)
            Parametro(.UpdateCommand, "numlig_0", OracleType.Number, DataRowVersion.Original)

            Parametro(.DeleteCommand, "fecha_0", OracleType.DateTime, DataRowVersion.Original)
            Parametro(.DeleteCommand, "hora_0", OracleType.VarChar, DataRowVersion.Original)
            Parametro(.DeleteCommand, "usr_0", OracleType.VarChar, DataRowVersion.Original)
            Parametro(.DeleteCommand, "numlig_0", OracleType.Number, DataRowVersion.Original)
        End With


        '************************************************************************
        ' COMANDOS PARA SOLAPA DE RECIBIDOS
        '************************************************************************
        Sql = "SELECT * FROM xsegto WHERE para_0 = :para_0 AND recibido_0 = 1"
        daRecibidos = New OracleDataAdapter(Sql, cn)
        daRecibidos.SelectCommand.Parameters.Add("para_0", OracleType.VarChar)

        Sql = "UPDATE xsegto SET para_0 = :para_0, recibido_0 = :recibido_0, usrrecibe_0 = :usrrecibe_0 WHERE :fecha_0 = :fecha_0 AND hora_0 = :hora_0 AND usr_0 = :usr_0 AND numlig_0 = :numlig_0"
        daRecibidos.UpdateCommand = New OracleCommand(Sql, cn)

        With daRecibidos
            Parametro(.UpdateCommand, "para_0", OracleType.VarChar, DataRowVersion.Current)
            Parametro(.UpdateCommand, "recibido_0", OracleType.Number, DataRowVersion.Current)
            Parametro(.UpdateCommand, "usrrecibe_0", OracleType.VarChar, DataRowVersion.Current)
            Parametro(.UpdateCommand, "fecha_0", OracleType.DateTime, DataRowVersion.Original)
            Parametro(.UpdateCommand, "hora_0", OracleType.VarChar, DataRowVersion.Original)
            Parametro(.UpdateCommand, "usr_0", OracleType.VarChar, DataRowVersion.Original)
            Parametro(.UpdateCommand, "numlig_0", OracleType.Number, DataRowVersion.Original)

        End With

    End Sub
    Private Sub frmSeguimiento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Adaptadores()

        AddHandler dgvEnviados.RowPostPaint, AddressOf NumeracionGrillas
        AddHandler dgvRecibidos.RowPostPaint, AddressOf NumeracionGrillas

        With cboDe
            .DataSource = Sectores(cn, False, "")
            .ValueMember = "ident2_0"
            .DisplayMember = "texte_0"
            .SelectedValue = SECTOR_ORIGEN
        End With
        With cboPara
            .DataSource = Sectores(cn, True, SECTOR_ORIGEN)
            .ValueMember = "ident2_0"
            .DisplayMember = "texte_0"
        End With

        RecuperarRegistros()

        'Recupero el mayor valor de identidad de la columna
        Dim num As Integer = 0
        For Each dr As DataRow In dtEnviados.Rows
            If CInt(dr("numlig_0")) > num Then num = CInt(dr("numlig_0"))
        Next
        num += 1

        With dtEnviados.Columns("numlig_0")
            .AutoIncrement = True
            .AutoIncrementStep = 1
            .AutoIncrementSeed = num
        End With

        ds.Tables.Add(dtEnviados)
        ds.Tables.Add(dtRecibidos)


        'ESTABLEZCO EL CAMPO PARA POR DEFECTO
        Select Case SECTOR_ORIGEN
            Case "ADM"
                cboPara.SelectedValue = "LOG"

            Case "CTD"
                cboPara.SelectedValue = "LOG"

            Case "DEP"
                cboPara.SelectedValue = "ACH"

            Case "ING", "LOG", "MOS", "SRV", "CAL"
                cboPara.SelectedValue = "ADM"


        End Select

        txtActual = txtDocEnv
        txtActual.Focus()

    End Sub
    Private Sub frmSeguimiento_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If ds.HasChanges Then Grabar
    End Sub
    Private Sub Grabar()

        Try
            If ds.HasChanges Then
                daEnviados.Update(dtEnviados)
                daRecibidos.Update(dtRecibidos)
            End If
            
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            ds.RejectChanges()

        End Try

    End Sub
    Private Sub RecuperarRegistros()
        'Recupero datos nuevos
        dtEnviados.Clear()
        dtRecibidos.Clear()
        daEnviados.SelectCommand.Parameters("de_0").Value = SECTOR_ORIGEN
        daRecibidos.SelectCommand.Parameters("para_0").Value = SECTOR_ORIGEN
        daEnviados.Fill(dtEnviados)
        daRecibidos.Fill(dtRecibidos)

        '********************************************************************************
        'ENLACE DE DATOS A LA GRILLA ENVIADOS
        '********************************************************************************
        If dgvEnviados.DataSource Is Nothing Then
            colFecha1.DataPropertyName = "fecha_0"
            colHora1.DataPropertyName = "hora_0"
            colUsr1.DataPropertyName = "usr_0"
            colLinea1.DataPropertyName = "numlig_0"
            colItn1.DataPropertyName = "itn_0"
            colRto1.DataPropertyName = "rto_0"
            colPed1.DataPropertyName = "ped_0"
            colCliente1.DataPropertyName = "bpcnum_0"
            colNombre1.DataPropertyName = "bpcnam_0"
            With colDe1
                .DataSource = Sectores(cn)
                .DisplayMember = "texte_0"
                .ValueMember = "ident2_0"
                .DataPropertyName = "de_0"
            End With
            With colPara1
                .DataSource = Sectores(cn, True, SECTOR_ORIGEN)
                .DisplayMember = "texte_0"
                .ValueMember = "ident2_0"
                .DataPropertyName = "para_0"
            End With
            colRecibido1.DataPropertyName = "Recibido_0"
            usrrecibe_arriba_col.DataPropertyName = "usrrecibe_0"
            dgvEnviados.DataSource = dtEnviados
        End If

        '********************************************************************************
        'ENLACE DE DATOS A LA GRILLA RECIBIDOS
        '********************************************************************************
        If dgvRecibidos.DataSource Is Nothing Then
            colFecha2.DataPropertyName = "fecha_0"
            colHora2.DataPropertyName = "hora_0"
            colUsr2.DataPropertyName = "usr_0"
            colLinea2.DataPropertyName = "numlig_0"
            colItn2.DataPropertyName = "itn_0"
            colRto2.DataPropertyName = "rto_0"
            colPed2.DataPropertyName = "ped_0"
            colCliente2.DataPropertyName = "bpcnum_0"
            colNombre2.DataPropertyName = "bpcnam_0"
            With colDe2
                .DataSource = Sectores(cn)
                .DisplayMember = "texte_0"
                .ValueMember = "ident2_0"
                .DataPropertyName = "de_0"
            End With
            With colPara2
                .DataSource = Sectores(cn)
                .DisplayMember = "texte_0"
                .ValueMember = "ident2_0"
                .DataPropertyName = "para_0"
            End With
            colRecibido2.DataPropertyName = "Recibido_0"
            usrrecibe_abajo_col.DataPropertyName = "usrrecibe_0"
            Dim dv As New DataView(dtRecibidos)
            dv.RowFilter = "recibido_0 = 1"
            dgvRecibidos.DataSource = dv

        End If

    End Sub
    Private Sub ImprimeIram(ByVal documento As String)
        Dim suc As New Sucursal(cn)
        Dim itn As New Intervencion(cn)

        itn.Abrir(documento.ToUpper)

        suc.Abrir(itn.Cliente.Codigo, itn.SucursalCodigo)

        If itn.Cliente.EsAbonado = True Then Exit Sub
        If itn.Estado <> 5 Then Exit Sub
        If itn.Tipo = "A1" Then
            If suc.CumpleIram = False Then
                Dim rpt As New ReportDocument
                Try
                    rpt.Load(RPTX3 & "XCTRL.rpt")
                    rpt.SetDatabaseLogon(DB_USR, DB_PWD)
                    rpt.SetParameterValue("BPC", itn.Cliente.Codigo)
                    rpt.SetParameterValue("ADD", itn.SucursalCodigo)
                    rpt.PrintToPrinter(1, False, 1, 100)
                    MsgBox("Imprimiendo Formulario de Cumplimiento de Iram ")
                Catch ex As Exception
                End Try
                rpt.Dispose()
                rpt = Nothing

            Else
                Dim rpt As New ReportDocument

                Try
                    rpt.Load(RPTX3 & "XCTRLPE2B_2.rpt")
                    rpt.SetDatabaseLogon(DB_USR, DB_PWD)
                    rpt.SetParameterValue("ITN", itn.Numero)
                    rpt.SetParameterValue("OBS", " ")
                    rpt.PrintToPrinter(1, False, 1, 100)

                    With NotifyIcon1
                        .Visible = True
                        .BalloonTipIcon = ToolTipIcon.Info
                        .BalloonTipTitle = "Intervención " & itn.Numero
                        .BalloonTipText = "Imprimiendo Formulario de Iram no cumplido"
                        .ShowBalloonTip(8000)
                    End With

                Catch ex As Exception
                End Try

                rpt.Dispose()
                rpt = Nothing
            End If
        End If

    End Sub
    Private Sub ImprimirInformeRechazos(ByVal Numero As String)
        'Si la intervención tiene equipos rechazados, se imprime automáticamente
        'la constancia de rechazo
        Dim itn As New Intervencion(cn)

        itn.Abrir(Numero.ToUpper)

        If itn.TieneRechazos Then
            Dim rpt As New ReportDocument

            Try
                rpt.Load(RPTX3 & "XCONSBAJA3.rpt")
                rpt.SetDatabaseLogon(DB_USR, DB_PWD)
                rpt.SetParameterValue("ITN", itn.Numero)
                rpt.SetParameterValue("X3DOS", X3DOS)
                rpt.PrintToPrinter(1, False, 1, 100)

                With NotifyIcon1
                    .Visible = True
                    .BalloonTipIcon = ToolTipIcon.Info
                    .BalloonTipTitle = "Intervención " & itn.Numero
                    .BalloonTipText = "Imprimiendo constancia de rechazos"
                    .ShowBalloonTip(8000)
                End With

            Catch ex As Exception
            End Try

            rpt.Dispose()
            rpt = Nothing
        End If

    End Sub
    Private Function ValidacionRequisitosIntervenciones(ByVal itn As Intervencion, ByVal SectorOrigen As String, ByVal SectorDestino As String) As Boolean
        Dim txt As String

        Select Case SectorDestino
            Case "ACH"

                Select Case SectorOrigen
                    Case "ADM"
                        If itn.SolicitudAsociada.Facturacion <> Solicitud.FlagFacturacion.Facturada AndAlso itn.SolicitudAsociada.CantidadIntervenciones = 1 Then
                            txt = "Solicitud de Servicio no facturada" & vbCrLf & vbCrLf
                            txt &= "¿Confirma el envío a archivo?"

                            If MessageBox.Show(txt, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                                Return False
                            End If

                        End If

                    Case Else

                        If itn.SolicitudAsociada.Facturacion <> Solicitud.FlagFacturacion.Facturada Then
                            txt = "Solicitud de Servicio no facturada" & vbCrLf & vbCrLf
                            txt &= "Solo se puede enviar a Administración de Ventas"

                            MessageBox.Show(txt, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Return False

                        End If

                End Select

            Case "ADM", "VEN"
                Select Case SectorOrigen
                    Case "LOG", "ABO", "ING"
                        If itn.Estado = 1 OrElse itn.Estado = 6 Then
                            txt = "Este estado de la intervención solo se usa para ser ruteado. " & vbCrLf
                            txt &= "Para poder enviarlo al sector, el único estado permitido para trabajos no realizados es A RESOLVER"

                            MessageBox.Show(txt, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Return False
                        End If
                End Select

            Case "LOG"
                Select Case SectorOrigen
                    Case "ADM", "VEN"
                        If itn.Estado = 7 Then
                            txt = "No se puede enviar una intervención en estado A RESOLVER." & vbCrLf
                            txt &= "Debe reactivarla para poder enviarla a " & SectorDestino

                            MessageBox.Show(txt, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Return False
                        End If


                        ' CANJE CANJE CANJE CANJE CANJE CANJE CANJE CANJE CANJE CANJE CANJE CANJE CANJE CANJE CANJE CANJE CANJE
                        ' 
                        ' No se puede enviar si no tiene factura
                        ' 
                        If itn.Tipo = "B2" Then
                            'Abro la factura de la SS
                            Dim sih As New Factura(cn)

                            If Not sih.AbrirPorSolicitud(itn.SolicitudAsociada.Numero) Then

                                MessageBox.Show("Falta facturar esta intervención", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Return False

                            End If

                        End If
                End Select

        End Select

        Return True

    End Function
    Private Function ValidacionRequisitosRemitos(ByVal Rto As Remito, ByVal SectorOrigen As String, ByVal SectorDestino As String) As Boolean
        Dim txt As String

        Select Case SectorDestino
            Case "ACH"
                'Miro que rto tenga marca de entregado y que no tenga devolucion
                If Rto.Despachado = False AndAlso Rto.RemitoDevuelto = False Then
                    txt = "No se puede enviar a archivo" & vbCrLf & vbCrLf
                    txt &= "Falta marcar el remito como despachado"
                    MessageBox.Show(txt, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return False
                End If

                Select Case SectorOrigen
                    Case "ADM"
                        'Miro si el remito tiene factura
                        If Not Rto.Facturado AndAlso Rto.RemitoDevuelto = False Then
                            txt = "Este remito no fue facturado" & vbCrLf & vbCrLf
                            txt &= "Si envía este remito a archivo nunca será facturado" & vbCrLf & vbCrLf
                            txt &= "¿Está seguro de que se debe archivar este remito?"

                            If MessageBox.Show(txt, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                                Return False
                            End If
                        End If

                    Case Else
                        'Miro si el remito tiene factura
                        If Not Rto.Facturado AndAlso Rto.RemitoDevuelto = False Then
                            txt = "Remito sin factura" & vbCrLf & vbCrLf
                            txt &= "Este remito solo puede ser enviado a Administración de Ventas"
                            MessageBox.Show(txt, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Return False
                        End If

                End Select

            Case "LOG"
                If Rto.ModoEntrega = "2" Then
                    txt = "El modo de entrega de este remito es: CLIENTE RETIRA POR GEORGIA" & vbCrLf & vbCrLf
                    txt &= "¿Confirma el envío a Logistica?"

                    If MessageBox.Show(txt, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                        Return False
                    End If
                End If

        End Select

        Return True

    End Function
    Private Function EstaEnGrilla(ByVal nro As String, ByVal dt As DataTable) As Boolean
        'Funcion que devuelve verdadero si encuentra el documento en la grilla
        Dim dr As DataRow
        Dim flg As Boolean

        For Each dr In dt.Rows
            If dr("itn_0").ToString = nro AndAlso CInt(dr("recibido_0")) = 1 Then
                flg = True

            ElseIf dr("rto_0").ToString = nro AndAlso CInt(dr("recibido_0")) = 1 Then
                flg = True

            End If

            If flg Then Exit For

        Next

        Return flg

    End Function
    'TXT_BUSCAR
    Private Sub txtDocEnv_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDocEnv.KeyUp
        If e.KeyCode = Keys.Enter AndAlso txtDocEnv.Text.Trim <> "" Then

            If EstaEnGrilla(txtDocEnv.Text, dtEnviados) Then

                MessageBox.Show("Ya envió este documento", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            Else

                AgregarDocumento(txtDocEnv.Text)

            End If

            txtDocEnv.Clear()
            txtDocEnv.Focus()

        End If
    End Sub
    Private Sub txtDocRec_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDocRec.KeyUp

        If e.KeyCode = Keys.Enter AndAlso txtDocRec.Text.Trim <> "" Then

            'Miro que el documento no esté en la lista de enviados del usuario
            If EstaEnGrilla(txtDocRec.Text, dtEnviados) Then
                MessageBox.Show("No puede recibir un documento que ha enviado a otro sector", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            ElseIf MarcarComoRecibido(txtDocRec.Text) Then
                Doc.BuscarAlRecibir(txtDocRec.Text)
                Grabar()

                If txtDocRec.Text.Length = 11 Then
                    If SECTOR_ORIGEN = "ADM" Then
                        ImprimeIram(txtDocRec.Text)
                    End If
                End If

                Else 'Al no encontrar el documento... 

                    RecuperarRegistros() 'refresco la grilla

                    If MarcarComoRecibido(txtDocRec.Text) Then 'y vuelvo a intentar
                        Doc.BuscarAlRecibir(txtDocRec.Text)
                        Grabar()

                    Else 'Como sigo sin encontrarlo...

                        'Busco si fue enviado a otro sector
                        If ObtenerLineaDocumento(txtDocRec.Text) Then

                            If MarcarComoRecibido(txtDocRec.Text) Then
                                'Lo recibo y modifico el sector destino
                                Doc.BuscarAlRecibir(txtDocRec.Text)
                                Grabar()
                            End If

                        Else 'No se envio a ningun sector

                            'Recupera el registro con los datos del ultimo envio confirmado
                            Dim da As OracleDataAdapter
                            Dim dt As New DataTable
                            Dim dr As DataRow
                            Dim Sql As String

                            Sql = "SELECT * "
                            Sql += "FROM ( "
                            Sql += "    SELECT * "
                            Sql += "    FROM xsegto "
                            Sql += "    WHERE (itn_0 = :nro OR rto_0 = :nro) AND recibido_0 = 2 "
                            Sql += "    ORDER BY fecha_0 DESC, hora_0 DESC "
                            Sql += ") "
                            Sql += "WHERE rownum = 1"

                            da = New OracleDataAdapter(Sql, cn)
                            da.SelectCommand.Parameters.Add("nro", OracleType.VarChar).Value = txtDocRec.Text

                            da.Fill(dt)
                            da.Dispose()


                            If dt.Rows.Count > 0 Then

                                dr = dt.Rows(0)

                                If dr("para_0").ToString = SECTOR_ORIGEN Then

                                    MessageBox.Show("Ya marcó este documento como recibido", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                                Else

                                    Sql = "No se puede recibir el documento" & vbCrLf & vbCrLf
                                    Sql &= "El sector " & Sectores(cn, dr("para_0").ToString) & " no le envío el documento"

                                    MessageBox.Show(Sql, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                                End If

                            End If

                        End If

                    End If

                End If

                txtDocRec.Clear()
                txtDocRec.Focus()

        End If

    End Sub
    Private Sub txtDocEnv_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDocEnv.GotFocus, txtDocRec.GotFocus
        txtActual = CType(sender, TextBox)
    End Sub
    Private Sub AgregarDocumento(ByVal nro As String)
        Dim dr As DataRow
        Dim flg As Boolean = False
        nro = nro.Trim.ToUpper

        'Miro si el documento se encuentra pendiente de recepcion
        If EstaEnGrilla(nro, dtRecibidos) Then
            MessageBox.Show("Antes de enviar el documento a otro sector debe confirmar que lo ha recibido", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If itn.Abrir(nro) Then 'Abro intervencion

            'Miro si el documento lo tiene otro sector
            If Not flg Then flg = PerteneceSector(nro)
            If Not flg Then Exit Sub

            'Miro que el documento no esté abierto en Adonix
            If Lck.EstaBloqueado("ITN", itn.Numero) Then
                Dim txt As String
                txt = "No se puede enviar un documento que está abierto en ADONIX."
                MessageBox.Show(txt, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                flg = False
                If Not flg Then Exit Sub
            End If

            'Miro que no se este intentando enviar en el mismo minuto que la ultima vez
            If ExisteEnvioPosterior(nro) Then
                MessageBox.Show("Para enviar este documento debe esperar unos minutos.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            'Valido que el documento reuna los requisitos necesarios para poder ser
            'enviado al sector de destino
            flg = ValidacionRequisitosIntervenciones(itn, cboDe.SelectedValue.ToString, cboPara.SelectedValue.ToString)

            If cboDe.SelectedValue.ToString = "CTD" And cboPara.SelectedValue.ToString = "ABO" Then
                If DocumentosPendientes(itn.Numero.ToString) Then Exit Sub
            ElseIf cboDe.SelectedValue.ToString = "CTD" And cboPara.SelectedValue.ToString = "LOG" Then
                If DocumentosPendientes(itn.Numero.ToString) Then Exit Sub
            ElseIf cboDe.SelectedValue.ToString = "ADM" And cboPara.SelectedValue.ToString = "ABO" Then
                If DocumentosPendientes(itn.Numero.ToString) Then Exit Sub
            ElseIf cboDe.SelectedValue.ToString = "ADM" And cboPara.SelectedValue.ToString = "LOG" Then
                If DocumentosPendientes(itn.Numero.ToString) Then Exit Sub
            End If

            If flg Then
                dr = dtEnviados.NewRow

                dr("fecha_0") = Date.Today
                dr("hora_0") = Date.Now.ToString("HHmm")
                dr("usr_0") = usr.Codigo
                dr("itn_0") = itn.Numero
                dr("rto_0") = itn.Remito
                dr("ped_0") = " "
                With itn.Cliente
                    dr("bpcnum_0") = .Codigo
                    dr("bpcnam_0") = .Nombre
                End With
                dr("de_0") = SECTOR_ORIGEN
                dr("para_0") = cboPara.SelectedValue.ToString
                dr("recibido_0") = 1
                dr("usrrecibe_0") = " "

                dtEnviados.Rows.InsertAt(dr, 0)

                Grabar()

                'Tareas adicionales dependiendo entre qué sectores se envie el documento
                If cboDe.SelectedValue.ToString = "ADM" And cboPara.SelectedValue.ToString = "CTD" Then
                    If itn.SolicitudAsociada.CondicionPago.Codigo >= "001" And itn.SolicitudAsociada.CondicionPago.Codigo <= "023" Then
                        ProcesarTanda()

                        If itn.Estado <> 6 And itn.Estado <> 7 Then
                            'envio mail si el cliente quiere
                            If itn.Cliente.MailVta Then
                                itn.EnvioMailAvisoCordinacion()
                            End If

                        End If
                    End If
                ElseIf cboDe.SelectedValue.ToString = "MOS" And cboPara.SelectedValue.ToString = "ACH" Then
                    itn.Estado = 5
                    itn.Grabar()

                ElseIf cboDe.SelectedValue.ToString = "ADM" And cboPara.SelectedValue.ToString = "MOS" Then
                    'envio mail si el cliente quiere
                    If itn.Cliente.MailVta Then
                        itn.EnvioMailAvisoMostrador()
                    End If
                ElseIf cboDe.SelectedValue.ToString = "ADM" And cboPara.SelectedValue.ToString = "ABO" Then
                    ProcesarTanda()

                ElseIf cboDe.SelectedValue.ToString = "ADM" And cboPara.SelectedValue.ToString = "LOG" Then

                    ProcesarTanda()

                    ' CANJE CANJE CANJE CANJE CANJE CANJE CANJE CANJE CANJE CANJE CANJE CANJE CANJE CANJE CANJE CANJE
                    ' 
                    ' Se crea parte de cobranza
                    ' 
                    If itn.Tipo = "B2" Then
                        Dim par As New ParteCobranza(cn)
                        Dim sih As New Factura(cn)

                        If sih.AbrirPorSolicitud(itn.SolicitudAsociada.Numero) Then
                            par.Abrir(sih.Numero)
                            par.Marcar(itn.CarritoFecha, "C008")
                            par.Grabar()

                            'Imprimo el parte
                            Dim rpt As New ReportDocument

                            rpt.Load(RPTX3 & "XCOBROS.rpt")
                            rpt.SetDatabaseLogon(DB_USR, DB_PWD)
                            rpt.SetParameterValue("FACTURA", sih.Numero)
                            rpt.PrintToPrinter(1, False, 1, 100)

                            With NotifyIcon1
                                .Visible = True
                                .BalloonTipIcon = ToolTipIcon.Info
                                .BalloonTipTitle = "Parte de cobranza "
                                .BalloonTipText = "Se envió a la impresora parte de cobranza para intervención " & itn.Numero
                                .ShowBalloonTip(8000)
                            End With

                        End If

                    End If

                ElseIf cboPara.SelectedValue.ToString = "ADM" And itn.Estado = 7 Then
                    Dim R = New Ruta(cn)
                    Dim ru As Integer = ExtraerRuta(itn.Numero.ToString)

                    If ru <> 0 Then
                        R.Abrir(ru)
                        itn.EnvioMailAviso(ExtraerRuta(itn.Numero.ToString), R.MotivoRebote(itn.Numero), R.Observacion(itn.Numero))
                    End If

                End If

            End If

        ElseIf rto.Abrir(nro) Then 'Abro remito

            'Miro si el documento lo tiene otro sector
            If Not flg Then flg = PerteneceSector(nro)
            If Not flg Then Exit Sub

            'Valido que el documento reuna los requisitos necesarios para poder ser
            'enviado al sector de destino
            flg = ValidacionRequisitosRemitos(rto, cboDe.SelectedValue.ToString, cboPara.SelectedValue.ToString)

            If cboDe.SelectedValue.ToString = "CTD" And cboPara.SelectedValue.ToString = "ABO" Then
                If DocumentosPendientes(rto.Numero.ToString) Then Exit Sub
            ElseIf cboDe.SelectedValue.ToString = "CTD" And cboPara.SelectedValue.ToString = "LOG" Then
                If DocumentosPendientes(rto.Numero.ToString) Then Exit Sub
            ElseIf cboDe.SelectedValue.ToString = "ADM" And cboPara.SelectedValue.ToString = "ABO" Then
                If DocumentosPendientes(rto.Numero.ToString) Then Exit Sub
            ElseIf cboDe.SelectedValue.ToString = "ADM" And cboPara.SelectedValue.ToString = "LOG" Then
                If DocumentosPendientes(rto.Numero.ToString) Then Exit Sub
            End If

            If flg Then
                dr = dtEnviados.NewRow

                dr("fecha_0") = Date.Today
                dr("hora_0") = Date.Now.ToString("HHmm")
                dr("usr_0") = usr.Codigo
                dr("itn_0") = " "
                dr("rto_0") = rto.Numero
                dr("ped_0") = rto.PedidoCodigo
                With rto.Cliente
                    dr("bpcnum_0") = .Codigo
                    dr("bpcnam_0") = .Nombre
                End With
                dr("de_0") = SECTOR_ORIGEN
                dr("para_0") = cboPara.SelectedValue.ToString
                dr("recibido_0") = 1
                dr("usrrecibe_0") = " "

                dtEnviados.Rows.InsertAt(dr, 0)

                Grabar()
                rto.Sector = cboPara.SelectedValue.ToString
                rto.Grabar()
            End If

        Else
            MessageBox.Show("Documento no encontrado", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)

        End If


    End Sub
    Private Function DocumentosPendientes(ByVal documento As String) As Boolean
        Dim sql As String
        Dim cliente As String
        Dim sucursal As String
        Dim numero As String = ""
        Dim sector As String = ""
        Dim da As OracleDataAdapter
        Dim dt1 As New DataTable
        Dim dt3 As New DataTable
        Dim dr12 As DataRow
        Dim result As DialogResult

        If itn.Abrir(documento) Then
            cliente = itn.Cliente.Codigo
            sucursal = itn.SucursalCodigo
            sql = "select num_0 from interven where (zflgtrip_0 >= '1' and zflgtrip_0 <= '4' or zflgtrip_0 = '6') "
            sql &= " and bpc_0 = :bpcord_0 and bpaadd_0 = :bpaadd_0 and num_0 <> :numero"
            da = New OracleDataAdapter(sql, cn)
            da.SelectCommand.Parameters.Add("bpcord_0", OracleType.VarChar).Value = cliente
            da.SelectCommand.Parameters.Add("bpaadd_0", OracleType.VarChar).Value = sucursal
            da.SelectCommand.Parameters.Add("numero", OracleType.VarChar).Value = documento
            da.Fill(dt1)
            If dt1.Rows.Count > 0 Then
                dr12 = dt1.Rows(0)
                numero = dr12("num_0").ToString
                sql = "select para_0 from xsegto where itn_0 = :numero order by fecha_0 desc"
                da = New OracleDataAdapter(sql, cn)
                da.SelectCommand.Parameters.Add("numero", OracleType.VarChar).Value = numero
                da.Fill(dt3)
            End If
        Else
            rto.Abrir(documento)
            cliente = rto.Cliente.Codigo
            sucursal = rto.SucursalCodigo
            sql = "select sdhnum_0 from sdelivery where (xflgrto_0 >= '1' and xflgrto_0 <= '4') and "
            sql &= " bpcord_0 = :bpcord_0 and bpaadd_0 = :bpaadd_0 and sdhnum_0 <> :numero"
            da = New OracleDataAdapter(sql, cn)
            da.SelectCommand.Parameters.Add("bpcord_0", OracleType.VarChar).Value = cliente
            da.SelectCommand.Parameters.Add("bpaadd_0", OracleType.VarChar).Value = sucursal
            da.SelectCommand.Parameters.Add("numero", OracleType.VarChar).Value = documento
            da.Fill(dt1)

            If dt1.Rows.Count > 0 Then
                dr12 = dt1.Rows(0)
                numero = dr12("sdhnum_0").ToString
                RtoDevolucion.Abrir(numero)

                'que no aparezca el cartel si el remito tiene devolucion 
                If RtoDevolucion.TieneDevolucion Then Return False

                sql = "select para_0 from xsegto where rto_0 = :numero order by fecha_0 desc"
                da = New OracleDataAdapter(sql, cn)
                da.SelectCommand.Parameters.Add("numero", OracleType.VarChar).Value = numero
                da.Fill(dt3)
            End If
        End If

        If dt3.Rows.Count > 0 Then
            dr12 = dt3.Rows(0)
            sector = dr12("para_0").ToString
            ItnRemito.Abrir(numero)
            If ItnRemito.Abrir(numero) Then
                If Not ((sector = "VEN" Or sector = "ADM") AndAlso ItnRemito.Remito = " ") Then Return False
            End If
            If RtoDevolucion.Abrir(numero) Then
                If Not ((sector = "VEN" Or sector = "ADM") AndAlso RtoDevolucion.Pedido.ToString.Trim <> "") Then Return False
            End If

        Else
            sector = "(Sin Pistolear)"
            If ItnRemito.Abrir(numero) Then Return False
            If RtoDevolucion.Abrir(numero) Then
                If RtoDevolucion.PedidoNumero.ToString.Trim = "" Then Return False
            End If
        End If
        If dt1.Rows.Count > 0 Then

            result = MessageBox.Show("Para este mismo cliente (" & cliente & "), sucursal (" & sucursal & ") existe el nro de ped/int pendiente nro: " & numero & " en el sector: " & sector & " , quiere pistolear este documento?", "Atencion", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then
                Return False
            ElseIf result = DialogResult.No Then
                Return True
            End If
        Else
            Return False
        End If
    End Function
    Private Function ExtraerRuta(ByVal intervencion As String) As Integer
        Dim dt As New DataTable
        Dim da As OracleDataAdapter
        Dim sql As String = " "

        sql = "select max(ruta_0) as ruta_0 from xrutad where vcrnum_0 = :intervencion"
        da = New OracleDataAdapter(sql, cn)
        da.SelectCommand.Parameters.Add("intervencion", OracleType.VarChar).Value = intervencion
        da.Fill(dt)
        If dt.Rows(0).Item("ruta_0").ToString = "" Then
            Return 0
        Else
            Return CInt(dt.Rows(0).Item("ruta_0").ToString)
        End If
    End Function
    Private Function MarcarComoRecibido(ByVal Nro As String) As Boolean
        Dim dr As DataRow
        Dim flg As Boolean = False

        Nro = Nro.ToUpper.Trim

        'Recorro la tabla buscando el registro
        For Each dr In dtRecibidos.Rows
            If dr("itn_0").ToString = Nro OrElse (dr("rto_0").ToString = Nro And dr("itn_0").ToString = " ") Then

                If CInt(dr("recibido_0")) = 1 Then
                    dr.BeginEdit()
                    dr("para_0") = SECTOR_ORIGEN
                    dr("recibido_0") = 2
                    dr("usrrecibe_0") = usr.Codigo
                    dr.EndEdit()

                    If itn.Abrir(Nro) AndAlso itn.Sector <> SECTOR_ORIGEN Then
                        itn.Sector = SECTOR_ORIGEN
                        itn.Grabar()
                    End If

                    If SECTOR_ORIGEN = "ADM" AndAlso dr("de_0").ToString = "SRV" Then
                        'Imprimo rechazados
                        ImprimirInformeRechazos(txtDocRec.Text)
                    End If

                Else
                    MessageBox.Show("Ya marcó este documento como recibido", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                End If

                flg = True

            End If

            If flg Then Exit For

        Next

        Return flg

    End Function
    Private Function PerteneceSector(ByVal Nro As String) As Boolean
        Dim Sql As String
        Dim da As OracleDataAdapter
        Dim dt As New DataTable
        Dim flg As Boolean = False
        Dim txt As String

        Sql = "SELECT * FROM xsegto WHERE (itn_0 = :itn_0 OR rto_0 = :rto_0) ORDER BY fecha_0 DESC, hora_0 DESC"
        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("itn_0", OracleType.VarChar).Value = Nro
        da.SelectCommand.Parameters.Add("rto_0", OracleType.VarChar).Value = Nro

        da.Fill(dt)

        If dt.Rows.Count = 0 Then
            flg = True

        ElseIf dt.Rows(0).Item("para_0").ToString = SECTOR_ORIGEN Then
            flg = True

        Else
            flg = False
            txt = "El último sector en recibir este documento fue: {SECTOR}." & vbCrLf & vbCrLf
            txt &= "Solo puede ser enviado desde ese sector. "
            txt = txt.Replace("{SECTOR}", Sectores(cn, dt.Rows(0).Item("para_0").ToString))

            MessageBox.Show(txt, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

        da.Dispose()

        Return flg

    End Function
    Private Function ObtenerLineaDocumento(ByVal Nro As String) As Boolean
        'Recupera el registro con los datos del ultimo envio sin confirmar
        Dim da As OracleDataAdapter
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim Sql As String

        Sql = "SELECT * FROM xsegto WHERE (itn_0 = :nro OR rto_0 = :nro) AND recibido_0 = 1 AND de_0 <> :de"
        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("nro", OracleType.VarChar).Value = Nro
        da.SelectCommand.Parameters.Add("de", OracleType.VarChar).Value = SECTOR_ORIGEN

        da.Fill(dt)
        da.Dispose()

        If dt.Rows.Count = 0 Then
            ObtenerLineaDocumento = False

        ElseIf dt.Rows.Count = 1 Then
            dr = dt.Rows(0)
            dtRecibidos.ImportRow(dr)

            Return True

        Else
            ObtenerLineaDocumento = False

        End If

    End Function
    'DGV_ENVIADOS
    Private Sub dgvEnviados_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvEnviados.UserDeletingRow
        If MessageBox.Show("¿Confirma la eliminación de la línea?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
            e.Cancel = True
        End If
    End Sub
    Private Sub dgvEnviados_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgvEnviados.UserDeletedRow
        Grabar()
    End Sub
    'BTN_CANCELAR
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
    'BTN_REFRESCAR
    Private Sub btnRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefrescar.Click
        RecuperarRegistros()
        txtActual.Focus()
    End Sub
    'DAENVIADOS
    Private Sub daEnviados_RowUpdated(ByVal sender As Object, ByVal e As System.Data.OracleClient.OracleRowUpdatedEventArgs) Handles daEnviados.RowUpdated
        'Salgo si hubo error
        If e.Status = UpdateStatus.ErrorsOccurred Then Exit Sub

        'Obtengo la fila 
        Dim dr As DataRow = CType(e.Row, DataRow)

        If dr("ped_0", DataRowVersion.Original).ToString.Trim <> "" Then 'Cambio el estado de remitos al pasar de sector

            Select Case e.StatementType
                Case StatementType.Insert, StatementType.Update
                    'Marco el remito como entregado si se mandó a Archivo
                    If dr("PARA_0").ToString = "ACH" Then
                        rto.Abrir(dr("rto_0").ToString)
                        rto.Estado = 5
                        rto.Grabar()
                    End If
                Case StatementType.Delete
                    'La fila fue borrada. Debo restablecer el sector donde estaba
                    'los remitos anteriormente.

                    rto.Abrir(dr("rto_0", DataRowVersion.Original).ToString)
                    rto.Sector = dr("DE_0", DataRowVersion.Original).ToString
                    rto.Grabar()

            End Select

        ElseIf dr("itn_0", DataRowVersion.Original).ToString.Trim <> "" Then 'Cambio el estado de intervenciones al pasar de sector

            Select Case e.StatementType
                Case StatementType.Insert, StatementType.Update
                    'Marco la intervencion como a entregar

                    Dim xsg As New Segto2(cn)

                    itn.Abrir(dr("itn_0").ToString)

                    If dr("DE_0").ToString = "SRV" AndAlso dr("PARA_0").ToString = "ADM" Then
                        itn.Estado = 3

                        If xsg.Abrir(dr("itn_0").ToString) Then
                            xsg.FechaIngresoAdministracion = Date.Today
                            xsg.Grabar()
                        End If

                    ElseIf dr("PARA_0").ToString = "LOG" Then

                        If itn.Estado = 3 Then
                            itn.Estado = 4
                        End If

                        If xsg.Abrir(dr("itn_0").ToString) Then
                            xsg.FechaIngresoLogistica = Date.Today
                            xsg.Grabar()
                        End If

                    ElseIf dr("PARA_0").ToString = "ABO" Then

                        If itn.Estado = 3 Then
                            itn.Estado = 4
                        End If

                        If xsg.Abrir(dr("itn_0").ToString) Then
                            xsg.FechaIngresoLogistica = Date.Today
                            xsg.Grabar()
                        End If

                    ElseIf dr("PARA_0").ToString = "MOS" Then

                        If itn.Estado = 3 Then
                            itn.Estado = 4
                        End If

                        If xsg.Abrir(dr("itn_0").ToString) Then
                            xsg.FechaIngresoLogistica = Date.Today
                            xsg.Grabar()
                        End If

                    ElseIf dr("PARA_0").ToString = "ACH" Then
                        itn.Estado = 5

                        If xsg.Abrir(dr("itn_0").ToString) Then
                            xsg.FechaEntregado = Date.Today
                            xsg.Grabar()
                        End If

                    ElseIf dr("PARA_0").ToString = "SRV" Then

                        If Not xsg.Abrir(dr("itn_0").ToString) Then
                            xsg.Nuevo(dr("itn_0").ToString)
                            xsg.FechaIngresoPlanta = Date.Today
                            xsg.Equipos = itn.CantidadEquiposTeoricos
                            xsg.Grabar()
                        End If

                    End If

                    itn.Sector = dr("PARA_0").ToString
                    itn.Grabar()

                Case StatementType.Delete
                    'La fila fue borrada. Debo restablecer el sector donde estaba
                    'la intervencion anteriormente.

                    itn.Abrir(dr("itn_0", DataRowVersion.Original).ToString)
                    itn.Sector = dr("DE_0", DataRowVersion.Original).ToString
                    itn.Grabar()

            End Select

        End If

    End Sub
    Private Sub ProcesarTanda()
        Dim txt As String
        Dim sre As Solicitud
        Dim itn2 As Intervencion
        Dim TipoIntervencion As String

        txt = "No se retiro todo con esta Intervención" & vbCrLf & vbCrLf
        txt &= "¿Crea otra intervención para retirar el saldo pendiente?"

        'Si la intervencion es un parcial, se genera la nueva itn para retirar el saldo
        If itn.Tanda AndAlso MessageBox.Show(txt, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            If itn.Tipo = "C1" Then
                sre = itn.SolicitudAsociada
                TipoIntervencion = "C1"
            Else
                sre = New Solicitud(cn)
                sre.Nueva(itn.Cliente, itn.Planta.SociedadPlanta)
                TipoIntervencion = "D1"
            End If

            'Creo la nueva ITN
            itn2 = sre.CrearIntervencion(itn.SucursalCodigo, TipoIntervencion)
            itn2.AgregarDetalle(itn.RetiroSaldo)
            itn2.Observaciones = "Faltantes de Int: " & itn.Numero
            'Paso numero de ot
            If itn.Tipo = "C1" Then itn2.OTR = itn.OTR
            itn2.Grabar()

            Parque.MoverMarcaIntervencion(cn, itn.Numero, itn2.Numero)

            'Imprimir la Intervencion
            Dim rpt As New ReportDocument
            rpt.Load(RPTX3 & "itn1.rpt")
            rpt.SetParameterValue("ITN", itn2.Numero)
            rpt.SetParameterValue("X3USR", usr.Codigo)
            rpt.SetParameterValue("X3DOS", X3DOS)
            rpt.SetDatabaseLogon(DB_USR, DB_PWD)

            If DB_USR = "GEOPROD" Then rpt.PrintToPrinter(3, False, 1, 1)

            With NotifyIcon1
                .Visible = True
                .BalloonTipIcon = ToolTipIcon.Info
                .BalloonTipTitle = "Nueva Intervención " & itn2.Numero
                .BalloonTipText = "Se envió a la impresora la intervención " & itn2.Numero & " para retirar el saldo de la intervención " & itn.Numero
                .ShowBalloonTip(8000)
            End With

            itn.ActualizarRetiroTeorico()
            itn.Grabar()

        End If

    End Sub
    'DTENVIADOS
    Private Sub dtEnviados_RowChanged(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs) Handles dtEnviados.RowChanged
        If e.Action = DataRowAction.Change Then
            Dim dr As DataRow = e.Row
            Dim flg As Boolean = False

            If dr("itn_0").ToString <> " " Then
                Dim itn As New Intervencion(cn)

                itn.Abrir(dr("itn_0").ToString)

                flg = ValidacionRequisitosIntervenciones(itn, dr("de_0").ToString, dr("para_0").ToString)

            Else
                Dim rto As New Remito(cn)

                rto.Abrir(dr("rto_0").ToString)

                flg = ValidacionRequisitosRemitos(rto, dr("de_0").ToString, dr("para_0").ToString)

            End If

            If flg Then
                Grabar()
            Else
                dr.RejectChanges()

            End If

        End If
    End Sub
    Private Function ExisteEnvioPosterior(ByVal Nro As String) As Boolean
        'Funcion que devuelve True si el documento esta siendo retransmitido en el mismo momento

        Dim Sql As String = "SELECT * FROM xsegto WHERE itn_0 = :itn_0 AND fecha_0 = :fecha_0 AND hora_0 >= :hora_0"
        Dim da As New OracleDataAdapter(Sql, cn)
        Dim dt As New DataTable

        da.SelectCommand.Parameters.Add("fecha_0", OracleType.DateTime).Value = Today.Date
        da.SelectCommand.Parameters.Add("hora_0", OracleType.VarChar).Value = Date.Now.ToString("HHmm")
        da.SelectCommand.Parameters.Add("itn_0", OracleType.VarChar).Value = Nro

        da.Fill(dt)
        da.Dispose()

        Return (dt.Rows.Count > 0)

    End Function
    Private Sub NotifyIcon1_BalloonTipClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles NotifyIcon1.BalloonTipClosed
        NotifyIcon1.Visible = False
    End Sub

End Class