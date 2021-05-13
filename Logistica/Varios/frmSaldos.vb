Imports System.IO
Imports System.Data.OracleClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class frmSaldos

    Private Sub frmAdministraciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AddHandler dgvSaldos.RowPostPaint, AddressOf NumeracionGrillas
        AddHandler dgvDetalle.RowPostPaint, AddressOf NumeracionGrillas

        LlenarComboTiposClientes()

        'Oculto el boton de envio de mails a los vendedores
        btnEnviar.Visible = (usr.Codigo.Length <> 2)

    End Sub

    Private Sub LlenarComboTiposClientes()
        Dim txt As String
        Dim da As OracleDataAdapter
        Dim dt As New DataTable

        txt = "SELECT ident2_0, ident2_0 || ' - ' || texte_0 AS texte_0 FROM atextra WHERE codfic_0 = 'ATABDIV' AND langue_0 = 'SPA' AND zone_0 = 'LNGDES' AND ident1_0 = '31' ORDER BY ident2_0"
        da = New OracleDataAdapter(txt, cn)
        da.Fill(dt)
        da.Dispose()

        With cboTipos
            .ValueMember = "ident2_0"
            .DisplayMember = "texte_0"
            .DataSource = dt
        End With

    End Sub
    Private Sub MarcarMails()
        Dim drv As DataGridViewRow

        For Each drv In dgvSaldos.Rows
            If Not ValidarMailAdmin(drv) Then
                drv.DefaultCellStyle.ForeColor = Drawing.Color.Red
            End If
        Next

    End Sub
    Private Sub dgvSaldos_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvSaldos.ColumnHeaderMouseClick
        MarcarMails()
    End Sub
    Private Sub dgvSaldos_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSaldos.RowEnter
        Dim Sql As String
        Dim dt As DataTable
        Dim da As OracleDataAdapter

        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Exit Sub

        Sql = "SELECT typ_0, num_0, duddat_0, bpr_0, bpcnam_0, amtloc_0 * sns_0 AS monto, payloc_0 * sns_0 AS aplicado, (amtloc_0 - payloc_0) * sns_0 AS saldo "
        Sql &= "FROM gaccdudate gac INNER JOIN "
        Sql &= "     bpcustomer bpc ON (gac.bpr_0 = bpc.bpcnum_0) "
        Sql &= "WHERE bpc.bpcpyr_0 = :bprpay_0 AND "
        Sql &= "      gac.flgcle_0 = 1 AND "
        Sql &= "      gac.sac_0 = 'DVL' AND  "
        Sql &= "      gac.typ_0 NOT IN ('CLO', 'APG') "
        Sql &= "ORDER BY duddat_0, num_0, lig_0"

        da = New OracleDataAdapter(Sql, cn)

        da.SelectCommand.Parameters.Add("bprpay_0", OracleType.VarChar).Value = dgvSaldos.Rows(e.RowIndex).Cells(0).Value.ToString

        If dgvDetalle.DataSource Is Nothing Then
            dt = New DataTable
            colTipo.DataPropertyName = "typ_0"
            colComprobante.DataPropertyName = "num_0"
            colFecha.DataPropertyName = "duddat_0"
            colCodigo2.DataPropertyName = "bpr_0"
            colConsorcio.DataPropertyName = "bpcnam_0"
            colMonto.DataPropertyName = "monto"
            colAplicado.DataPropertyName = "aplicado"
            colDeuda.DataPropertyName = "saldo"
            dgvDetalle.DataSource = dt

        Else
            dt = CType(dgvDetalle.DataSource, DataTable)

        End If

        dt.Clear()
        da.Fill(dt)
        da.Dispose()

    End Sub
    Private Sub btnSaldos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaldos.Click
        Dim Sql As String
        Dim dt As DataTable
        Dim da As OracleDataAdapter

        btnSaldos.Enabled = False
        Me.UseWaitCursor = True
        Application.DoEvents()
        Application.DoEvents()

        If cboTipos.SelectedValue.ToString = "10" Then
            Sql = "SELECT pyr.bpcnum_0, pyr.bpcnam_0, SUM((amtloc_0 - payloc_0) * sns_0) AS saldo, pyr.rep_0, pyr.xmailfc_0, bpa.web_0 "
            Sql &= "FROM bpcustomer pyr INNER JOIN "
            Sql &= "     bpcustomer bpc ON (pyr.bpcnum_0 = bpc.bpcpyr_0) INNER JOIN "
            Sql &= "     bpartner bpr on (pyr.bpcnum_0 = bpr.bprnum_0) inner join "
            Sql &= "     bpaddress bpa on (bpr.bprnum_0 = bpa.bpanum_0 and bpr.bpaadd_0 = bpa.bpaadd_0) inner join "
            Sql &= "     gaccdudate gac ON (bpc.bpcnum_0 = gac.bpr_0)  "
            Sql &= "WHERE (pyr.tsccod_1 = '10' OR (pyr.tsccod_1 = '11' AND pyr.bpcnum_0 = pyr.bpcpyr_0)) AND "
            Sql &= "      bpc.bpctyp_0 = 1 AND "
            Sql &= "      gac.flgcle_0 = 1 AND "
            Sql &= "      gac.sac_0 = 'DVL' AND "
            Sql &= "      typ_0 NOT IN ('CLO', 'APG') "
            Sql &= "{FILTRO-VENDEDOR} "
            Sql &= "GROUP BY pyr.bpcnum_0, pyr.bpcnam_0, pyr.rep_0, pyr.xmailfc_0, bpa.web_0 "
            Sql &= "HAVING SUM((amtloc_0 - payloc_0) * sns_0) > 0 "
            Sql &= "ORDER BY saldo DESC"

        Else
            Sql = "SELECT pyr.bpcnum_0, pyr.bpcnam_0, SUM((amtloc_0 - payloc_0) * sns_0) AS saldo, pyr.rep_0, pyr.xmailfc_0, bpa.web_0 "
            Sql &= "FROM bpcustomer pyr INNER JOIN "
            Sql &= "     bpcustomer bpc ON (pyr.bpcnum_0 = bpc.bpcpyr_0) INNER JOIN "
            Sql &= "     bpartner bpr on (pyr.bpcnum_0 = bpr.bprnum_0) inner join "
            Sql &= "     bpaddress bpa on (bpr.bprnum_0 = bpa.bpanum_0 and bpr.bpaadd_0 = bpa.bpaadd_0) inner join "
            Sql &= "     gaccdudate gac ON (bpc.bpcnum_0 = gac.bpr_0) "
            Sql &= "WHERE pyr.tsccod_1 = '{TIPO}' AND "
            Sql &= "      bpc.bpctyp_0 = 1 AND "
            Sql &= "      gac.flgcle_0 = 1 AND "
            Sql &= "      gac.sac_0 = 'DVL' AND "
            Sql &= "      typ_0 NOT IN ('CLO', 'APG') "
            Sql &= "{FILTRO-VENDEDOR} "
            Sql &= "GROUP BY pyr.bpcnum_0, pyr.bpcnam_0, pyr.rep_0, pyr.xmailfc_0, bpa.web_0 "
            Sql &= "HAVING SUM((amtloc_0 - payloc_0) * sns_0) > 0 "
            Sql &= "ORDER BY saldo DESC"

            Sql = Sql.Replace("{TIPO}", cboTipos.SelectedValue.ToString)

        End If

        If usr.Codigo.Length = 2 Then
            Sql = Sql.Replace("{FILTRO-VENDEDOR}", "AND pyr.rep_0 = '" & usr.Codigo & "'")
        Else
            Sql = Sql.Replace("{FILTRO-VENDEDOR}", "")
        End If

        da = New OracleDataAdapter(Sql, cn)

        If dgvSaldos.DataSource Is Nothing Then
            dt = New DataTable
            colCodigo.DataPropertyName = "bpcnum_0"
            colAdministracion.DataPropertyName = "bpcnam_0"
            colSaldo.DataPropertyName = "saldo"
            colRep.DataPropertyName = "rep_0"
            colMail.DataPropertyName = "xmailfc_0"
            colMail2.DataPropertyName = "web_0"
            dgvSaldos.DataSource = dt

        Else
            dt = CType(dgvSaldos.DataSource, DataTable)

        End If

        dt.Clear()
        da.Fill(dt)
        da.Dispose()

        MarcarMails()

        btnSaldos.Enabled = True
        Me.UseWaitCursor = False
        Application.DoEvents()
        Application.DoEvents()

    End Sub
    Private Sub btnEnviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnviar.Click

        Dim Mails() As String
        Dim Archivo As String = ""
        Dim oMail As New CorreoElectronico
        Dim Path As String = Application.StartupPath & "\TEMP\"
        Dim drv As DataGridViewRow
        Dim Mail As String = ""

        If MessageBox.Show("¿Confirma el envío de mail", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If

        btnEnviar.Enabled = False
        Me.UseWaitCursor = True
        Application.DoEvents()
        Application.DoEvents()

        'Valido si el usuario tiene un mail valido
        If Not ValidMail(Usr.Mail) Then
            MessageBox.Show("El usuario " & Usr.Nombre & " no tiene definido un mail válido", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        'Ajusto los valores de la barra de progreso
        With ProgressBar1
            .Value = 0
            .Maximum = dgvSaldos.SelectedRows.Count
            .Minimum = 0
            .Visible = True
        End With

        'Creo directorio
        Try
            Directory.CreateDirectory(Path)

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        End Try

        For Each drv In dgvSaldos.SelectedRows

            'Recupero direcciones de mail del cliente
            If ValidarMailAdmin(drv, Mail) Then
                Mails = Split(Mail, ";") 'Separo los mails

                For Each Mail In Mails 'quito espacios finales
                    Mail = Mail.Trim
                Next

                'Genero la factura electronica
                Try
                    'Armo el nombre del archivo
                    Archivo = Path
                    Archivo &= "SDO"
                    Archivo &= "-"
                    Archivo &= drv.Cells("colCodigo").Value.ToString
                    Archivo &= ".pdf"

                    GenerarArchivo(Archivo, drv.Cells("colCodigo").Value.ToString)

                    'Armo el mail a enviar
                    oMail = New CorreoElectronico

                    With oMail
                        .Nuevo()

                        For Each Mail In Mails 'Agrego destinatarios
                            .AgregarDestinatario(Mail)
                        Next

                        .Remitente(usr.Mail, usr.Nombre)
                        .AgregarDestinatario(usr.Mail, True)
                        .ResponderA("cobranzas@georgia.com.ar")
                        .Asunto = "Composición de deuda"
                        .EsHtml = True

                        .AdjuntarArchivo(Archivo)

                        If cboTipos.SelectedValue.ToString = "10" Then
                            .CuerpoDesdeArchivo("plantillas\composicion-de-deuda-1.html")

                        Else
                            .CuerpoDesdeArchivo("plantillas\composicion-de-deuda-2.html")

                        End If

                        .Enviar()

                        MessageBox.Show("Envio finalizado", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

                        .Dispose()

                    End With


                    File.Delete(Archivo)

                Catch ex As Exception
                    MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit For

                End Try

            End If

            ProgressBar1.Value += 1

        Next

        ProgressBar1.Visible = False
        btnEnviar.Enabled = True
        Me.UseWaitCursor = False

    End Sub
    Private Sub GenerarArchivo(ByVal Archivo As String, ByVal Comprobante As String)
        Dim rpt As New ReportDocument

        rpt.Load(RPTX3 & "XSDO_ADM.rpt")
        rpt.SetDatabaseLogon(DB_USR, DB_PWD)

        rpt.SetParameterValue("BPRPAY", Comprobante)

        rpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Archivo)

        rpt = Nothing

    End Sub
    Private Sub ContextMenuStrip1_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        mnuSaldos.Enabled = (dgvSaldos.SelectedRows.Count = 1)
    End Sub
    Private Sub mnuSaldos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSaldos.Click
        Dim rpt As New ReportDocument
        Dim f As frmCrystal
        Dim t As String = dgvSaldos.CurrentRow.Cells("colCodigo").Value.ToString

        Try
            rpt.Load(RPTX3 & "xsdo_adm.rpt")
            rpt.SetParameterValue("BPRPAY", t)
            rpt.SetParameterValue("X3USR", usr.Codigo)

            f = New frmCrystal(rpt)
            f.MdiParent = Me.ParentForm
            f.Show()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub
    Private Function ValidarMailAdmin(ByVal drv As DataGridViewRow, Optional ByRef Mail As String = "") As Boolean

        If drv.Cells("colMail").Value.ToString.Trim = "" Then

            If drv.Cells("colMail2").Value Is Nothing OrElse drv.Cells("colMail2").Value.ToString.Trim = "" Then
                Return False

            Else

                If Not ValidMail(drv.Cells("colMail2").Value.ToString) Then
                    Return False

                Else
                    Mail = drv.Cells("colMail2").Value.ToString
                    Return True

                End If

            End If

        Else

            If Not ValidMail(drv.Cells("colMail").Value.ToString) Then
                Return False

            Else
                Mail = drv.Cells("colMail").Value.ToString
                Return True
            End If

        End If

        Return True

    End Function
    Private Sub cboTipos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipos.SelectedIndexChanged
        Dim dt As DataTable

        If dgvDetalle.DataSource IsNot Nothing Then
            dt = CType(dgvSaldos.DataSource, DataTable)
            dt.Rows.Clear()
        End If

    End Sub

End Class