Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO
Imports System.Data.OracleClient

Public Class frmfacturas2

    Private dt As New DataTable
    Private cm1 As OracleCommand    'Busqueda por cliente (Condicion mayor a 027)
    Private cm2 As OracleCommand    'Busqueda por fecha (Condicion mayor a 027
    Private cm3 As OracleCommand    'Busqueda por cliente (Condicion hasta 027)
    Private cm4 As OracleCommand    'Busqueda por fecha (Condicion hasta 027
    Private da As New OracleDataAdapter

    Private Path As String

    'SUBS
    Private Sub Adaptadores()
        Dim Sql As String

        'Busqueda por cliente (Condicion mayor a 027)
        Sql = "SELECT siv.accdat_0, siv.num_0, siv.bpr_0, siv.bprnam_0, siv.amtati_0, bpa.xmailfc_0 AS Mail1, bpc.xmailfc_0 AS Mail2, sih.sihori_0, sih.sihorinum_0, siv.pte_0 " & _
              "FROM ((sinvoice siv INNER JOIN sinvoicev sih ON (siv.num_0 = sih.num_0)) INNER JOIN bpaddress bpa ON (siv.bpr_0 = bpa.bpanum_0 AND siv.bpainv_0 = bpa.bpaadd_0) INNER JOIN bpcustomer bpc ON (siv.bpr_0 = bpcnum_0)) " & _
              "WHERE (bpa.xmailfc_0 <> ' ' OR bpc.xmailfc_0 <> ' ') AND siv.xcae_0 <> ' ' AND siv.bpr_0 = :bpr_0 AND siv.pte_0 > '027' AND siv.xsendfc_0 = 2"

        cm1 = New OracleCommand(Sql, cn)
        cm1.CommandText = Sql
        cm1.Parameters.Add("bpr_0", OracleType.VarChar)

        'Busqueda por fecha (Condicion mayor a 027)
        Sql = "SELECT siv.accdat_0, siv.num_0, siv.bpr_0, siv.bprnam_0, siv.amtati_0, bpa.xmailfc_0 AS Mail1, bpc.xmailfc_0 AS Mail2, sih.sihori_0, sih.sihorinum_0, siv.pte_0 " & _
              "FROM ((sinvoice siv INNER JOIN sinvoicev sih ON (siv.num_0 = sih.num_0)) INNER JOIN bpaddress bpa ON (siv.bpr_0 = bpa.bpanum_0 AND siv.bpainv_0 = bpa.bpaadd_0) INNER JOIN bpcustomer bpc ON (siv.bpr_0 = bpcnum_0)) " & _
              "WHERE (bpa.xmailfc_0 <> ' ' OR bpc.xmailfc_0 <> ' ') AND siv.xcae_0 <> ' ' AND siv.accdat_0 = to_date(:accdat_0, 'dd/mm/yyyy') AND siv.pte_0 > '027' AND siv.xsendfc_0 = 2"
        cm2 = New OracleCommand(Sql, cn)
        cm2.Parameters.Add("accdat_0", OracleType.VarChar)

        'Busqueda por cliente (Condicion de 001..027)
        Sql = "SELECT siv.accdat_0, siv.num_0, siv.bpr_0, siv.bprnam_0, siv.amtati_0, bpa.xmailfc_0 AS Mail1, bpc.xmailfc_0 AS Mail2, sih.sihori_0, sih.sihorinum_0, siv.pte_0 " & _
              "FROM ((sinvoice siv INNER JOIN sinvoicev sih ON (siv.num_0 = sih.num_0)) INNER JOIN bpaddress bpa ON (siv.bpr_0 = bpa.bpanum_0 AND siv.bpainv_0 = bpa.bpaadd_0) INNER JOIN bpcustomer bpc ON (siv.bpr_0 = bpcnum_0)) " & _
              "WHERE (bpa.xmailfc_0 <> ' ' OR bpc.xmailfc_0 <> ' ') AND siv.xcae_0 <> ' ' AND siv.bpr_0 = :bpr_0 AND siv.pte_0 <= '027' AND siv.xsendfc_0 = 2"

        cm3 = New OracleCommand(Sql, cn)
        cm3.CommandText = Sql
        cm3.Parameters.Add("bpr_0", OracleType.VarChar)

        'Busqueda por fecha (Condicion de 001..027)
        Sql = "SELECT siv.accdat_0, siv.num_0, siv.bpr_0, siv.bprnam_0, siv.amtati_0, bpa.xmailfc_0 AS Mail1, bpc.xmailfc_0 AS Mail2, sih.sihori_0, sih.sihorinum_0, siv.pte_0 " & _
              "FROM ((sinvoice siv INNER JOIN sinvoicev sih ON (siv.num_0 = sih.num_0)) INNER JOIN bpaddress bpa ON (siv.bpr_0 = bpa.bpanum_0 AND siv.bpainv_0 = bpa.bpaadd_0) INNER JOIN bpcustomer bpc ON (siv.bpr_0 = bpcnum_0)) " & _
              "WHERE (bpa.xmailfc_0 <> ' ' OR bpc.xmailfc_0 <> ' ') AND siv.xcae_0 <> ' ' AND siv.accdat_0 = to_date(:accdat_0, 'dd/mm/yyyy') AND siv.pte_0 <= '027' AND siv.xsendfc_0 = 2"
        cm4 = New OracleCommand(Sql, cn)
        cm4.Parameters.Add("accdat_0", OracleType.VarChar)

    End Sub
    Private Sub Buscar()
        Try
            dt.Clear()
            da.Fill(dt)

        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try
    End Sub
    Private Sub GenerarArchivo(ByVal Archivo As String, ByVal Comprobante As String)
        Dim rpt As New ReportDocument

        rpt.Load(RPTX3 & "XFACT_ELEC.rpt")
        rpt.SetDatabaseLogon(DB_USR, DB_PWD)
        rpt.SetParameterValue("X3DOS", X3DOS)
        rpt.SetParameterValue("OCULTAR_BARRAS", True)
        rpt.SetParameterValue("facturedeb", Comprobante)
        rpt.SetParameterValue("facturefin", Comprobante)
        rpt.SetParameterValue("ENVIAR", False)
        rpt.SetParameterValue("CERO", False)
        rpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Archivo)

        rpt = Nothing

    End Sub

    'EVENTOS
    Private Sub frmFacturas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Adaptadores()

        Path = Application.StartupPath
        If Not Path.EndsWith("\") Then Path &= "\"

        'Enlazo las columnas de la grilla a los datos
        colFecha.DataPropertyName = "accdat_0"
        colComprobante.DataPropertyName = "num_0"
        colCodigo.DataPropertyName = "bpr_0"
        colTercero.DataPropertyName = "bprnam_0"
        colImporte.DataPropertyName = "amtati_0"
        colMail1.DataPropertyName = "mail1"
        colMail2.DataPropertyName = "mail2"
        colOrigen.DataPropertyName = "sihori_0" : MenuLocal(cn, 413, colOrigen)
        colNumeroOrigen.DataPropertyName = "sihorinum_0"
        colPte.DataPropertyName = "pte_0"
        dgv.DataSource = dt

        AddHandler dgv.RowPostPaint, AddressOf NumeracionGrillas

    End Sub
    Private Sub cmdBuscar1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBuscar1.Click

        If CheckBox1.Checked Then
            cm3.Parameters("bpr_0").Value = txtCliente.Text
            da.SelectCommand = cm3
        Else
            cm1.Parameters("bpr_0").Value = txtCliente.Text
            da.SelectCommand = cm1
        End If

        Buscar()

    End Sub
    Private Sub cmdBuscar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBuscar2.Click
        If CheckBox1.Checked Then
            cm4.Parameters("accdat_0").Value = MonthCalendar1.SelectionStart.Date.ToShortDateString
            da.SelectCommand = cm4
        Else
            cm2.Parameters("accdat_0").Value = MonthCalendar1.SelectionStart.Date.ToShortDateString
            da.SelectCommand = cm2
        End If

        Buscar()

    End Sub
    Private Sub cmdGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGuardar.Click
        Dim FolderBrowserDialog1 As New FolderBrowserDialog
        Dim Archivo As String
        Dim Carpeta As String = ""

        'Valido que haya al menos una fila seleccionada
        If dgv.SelectedRows.Count = 0 Then
            MessageBox.Show("Debe seleccionar al menos una fila", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        'Dialogo para seleccionar Carpeta
        With FolderBrowserDialog1
            If Carpeta <> "" Then .SelectedPath = Carpeta
            .Description = "Seleccione la carpeta donde guardar las facturas electrónicas"
            .ShowDialog()

            If .SelectedPath.Trim = "" Then Exit Sub

            Carpeta = IIf(.SelectedPath.EndsWith("\"), .SelectedPath, .SelectedPath & "\").ToString

        End With

        cmdGuardar.Enabled = False

        'Recorro las lineas marcadas para generar PDF
        Try
            With ProgressBar1
                .Value = 0
                .Maximum = dgv.SelectedRows.Count
                .Minimum = 0
            End With

            For Each dgvr As DataGridViewRow In dgv.SelectedRows
                ProgressBar1.Value += 1

                Archivo = Carpeta
                Archivo &= dgvr.Cells(2).Value.ToString
                Archivo &= "-"
                Archivo &= dgvr.Cells(1).Value.ToString
                Archivo &= ".pdf"

                GenerarArchivo(Archivo, dgvr.Cells(1).Value.ToString)

            Next

            MessageBox.Show("Exportación finalizada", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            ProgressBar1.Value = 0

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            cmdGuardar.Enabled = True

        End Try

    End Sub
    Private Sub cmdEnviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnviar.Click
        Dim Mail As String
        Dim Mails() As String
        Dim Seguir As Boolean = True
        Dim Archivo As String = ""
        Dim oMail As New CorreoElectronico
        Dim HuboError As Boolean = False
        Dim Path As String = Application.StartupPath & "\MAILFC\"

        'Valido si el usuario tiene un mail valido
        If Not ValidMail(USR.Mail) Then
            MessageBox.Show("El usuario no " & USR.Mail & " no tiene definido un mail válido", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        'Ajusto los valores de la barra de progreso
        With ProgressBar1
            .Value = 0
            .Maximum = dgv.SelectedRows.Count
            .Minimum = 0
        End With

        'Creo directorio
        Try
            Directory.CreateDirectory(Path)

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        End Try

        cmdEnviar.Enabled = False

        For Each dgvr As DataGridViewRow In dgv.SelectedRows

            Seguir = True

            'Recupero direcciones de mail del cliente
            If dgvr.Cells(6).Value.ToString.Trim <> "" Then
                Mail = dgvr.Cells(6).Value.ToString.Trim

            Else
                Mail = dgvr.Cells(5).Value.ToString.Trim

            End If

            Mails = Split(Mail, ";")

            'Valido que las direcciones de mails
            For Each Mail In Mails
                Mail = Mail.Trim
                If Not ValidMail(Mail) Then
                    dgvr.ErrorText = "Mail no válido: " & Mail
                    Seguir = False
                    HuboError = True
                    Exit For
                Else
                    dgvr.ErrorText = ""
                End If
            Next

            If Not Seguir Then Exit For 'Si hay error en mails salto al siguiente registro

            'Genero la factura electronica
            Try
                'Armo el nombre del archivo
                Archivo = dgvr.Cells(1).Value.ToString & ".pdf"

                GenerarArchivo(Path & Archivo, dgvr.Cells(1).Value.ToString)

                'Armo el mail a enviar
                oMail.Nuevo()
                With oMail
                    For Each Mail In Mails 'Agrego destinatarios
                        .AgregarDestinatario(Mail)
                    Next

                    .Remitente(usr.Mail, usr.Nombre)
                    .ResponderA("cobranzas@matafuegosgeorgia.com")
                    .Asunto = "Factura " & dgvr.Cells(1).Value.ToString & " - MATAFUEGOS DONNY S.R.L."
                    .EsHtml = True
                    .Prioridad = Net.Mail.MailPriority.High
                    .AdjuntarArchivo(Path & Archivo)

                    .Cuerpo = "<pre>" & vbCrLf
                    .Cuerpo &= dgvr.Cells(2).Value.ToString & vbCrLf
                    .Cuerpo &= dgvr.Cells(3).Value.ToString & vbCrLf
                    .Cuerpo &= "" & vbCrLf
                    .Cuerpo &= "Cumplimos en enviarle de manera electronica, mediante archivo adjunto," & vbCrLf
                    .Cuerpo &= "la documentacion generada por Matafuegos Donny S.R.L." & vbCrLf
                    .Cuerpo &= "" & vbCrLf
                    .Cuerpo &= "Para su comodidad, podra cancelar la misma coordinando con nuestro departamento" & vbCrLf
                    .Cuerpo &= "de cobranzas la gestion de un cobrador a domicilio; mediante transferencia o" & vbCrLf
                    .Cuerpo &= "deposito bancario en nuestras cuentas habilitadas." & vbCrLf
                    .Cuerpo &= "" & vbCrLf
                    .Cuerpo &= "BANCO SANTANDER RIO" & vbCrLf
                    .Cuerpo &= "Cta. Cte.: 050-12128/6" & vbCrLf
                    .Cuerpo &= "CBU: 07200502-20000001212868" & vbCrLf
                    .Cuerpo &= "Titular: MATAFUEGOS DONNY S.R.L. (CUIT: 30-62702896-9)" & vbCrLf
                    .Cuerpo &= "---" & vbCrLf
                    .Cuerpo &= "" & vbCrLf
                    .Cuerpo &= "BANCO GALICIA" & vbCrLf
                    .Cuerpo &= "Cta. Cte.: 2918-4 158-1" & vbCrLf
                    .Cuerpo &= "CBU: 00701583 20000002918413" & vbCrLf
                    .Cuerpo &= "Titular: MATAFUEGOS DONNY S.R.L. (CUIT: 30-62702896-9)" & vbCrLf
                    .Cuerpo &= "---" & vbCrLf
                    .Cuerpo &= "" & vbCrLf
                    .Cuerpo &= "BANCO DE LA NACION ARGENTINA" & vbCrLf
                    .Cuerpo &= "Cta. Cte.: 125898/81" & vbCrLf
                    .Cuerpo &= "CBU: 01100204-20000125898814" & vbCrLf
                    .Cuerpo &= "Titular: MATAFUEGOS DONNY S.R.L. (CUIT: 30-62702896-9)" & vbCrLf
                    .Cuerpo &= "---" & vbCrLf
                    .Cuerpo &= "" & vbCrLf
                    .Cuerpo &= "BANCO DE LA PROVINCIA DE BUENOS AIRES" & vbCrLf
                    .Cuerpo &= "Cta. Cte.: 4007-22728/1" & vbCrLf
                    .Cuerpo &= "CBU: 01400076 01400702272814" & vbCrLf
                    .Cuerpo &= "Titular: MATAFUEGOS DONNY S.R.L. (CUIT: 30-62702896-9)" & vbCrLf
                    .Cuerpo &= "---" & vbCrLf
                    .Cuerpo &= "" & vbCrLf
                    .Cuerpo &= "BANCO CIUDAD DE BUENOS AIRES" & vbCrLf
                    .Cuerpo &= "Cta. Cte.: 029-792/6" & vbCrLf
                    .Cuerpo &= "CBU: 02900292 00000000079264" & vbCrLf
                    .Cuerpo &= "Titular: MATAFUEGOS DONNY S.R.L. (CUIT: 30-62702896-9)" & vbCrLf
                    .Cuerpo &= "" & vbCrLf
                    .Cuerpo &= "" & vbCrLf
                    .Cuerpo &= "Atentamente" & vbCrLf
                    .Cuerpo &= "" & vbCrLf
                    .Cuerpo &= "" & vbCrLf
                    .Cuerpo &= "" & vbCrLf
                    .Cuerpo &= "MATAFUEGOS DONNY S.R.L." & vbCrLf
                    .Cuerpo &= "Departamento de Cobranzas" & vbCrLf
                    .Cuerpo &= "+54 (11) 4585-4400" & vbCrLf
                    .Cuerpo &= "cobranzas@matafuegosgeorgia.com" & vbCrLf
                    .Cuerpo &= "www.matafuegosgeorgia.com" & vbCrLf
                    .Cuerpo &= "</pre>"

                End With

                oMail.Enviar()

                oMail.Dispose()

                ProgressBar1.Value += 1

                File.Delete(Path & Archivo)

            Catch ex As Exception
                MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub

            Finally
                cmdEnviar.Enabled = True

            End Try

        Next

        If HuboError Then
            MessageBox.Show("Envío terminado" & vbCrLf & vbCrLf & "No se pudo enviar algunos documentos", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

        Else
            MessageBox.Show("Envío terminado", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

        ProgressBar1.Value = 0

        cmdEnviar.Enabled = True

    End Sub

End Class