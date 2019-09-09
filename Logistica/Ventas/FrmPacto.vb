Imports Clases
Imports System.Data.OracleClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class FrmPacto
    Dim pac As New Pacto(cn)
    Dim mail As New CorreoElectronico
    Private Sub FrmPacto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Vendedor.Enlazar(cn, CmbVendedor, True)
        dgv.DataSource = pac.LLenarDt
        CBVerPendientes.Checked = True
        dgv.Columns("numero").ReadOnly = True
        dgv.Columns("Razon_Social").ReadOnly = True
        dgv.Columns("Direccion").ReadOnly = True
        dgv.Columns("Vendedor").ReadOnly = True
        dgv.Columns("Cotizar").ReadOnly = True
        dgv.Columns("Ciudad").ReadOnly = True
        dgv.Columns("Fecha_Creacion").ReadOnly = True
    End Sub
    Private Sub btnRegistrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegistrar.Click
        If TxtNumero.Text = "" Then
            If ValidarCampos() Then
                Nuevo()
                MsgBox("Se genero nuevo requisito")
                EnvioPrimerMail(usr.Mail.ToString)
                LimpiarCampos()
            End If
        Else
            If usr.RegistraPacto Then
                modificar()
                If TxtColega.Text = "" Then
                    EnvioSegundoMail()
                    LimpiarCampos()
                End If
            Else
                MsgBox("no tiene autorizacion para registrar los cambios")
            End If
        End If

    End Sub
    Private Sub Nuevo()
        pac.Nuevo()
        pac.NombreCliente = TxtRazonSocial.Text.ToString
        pac.Direccion = TxtDomicilio.Text.ToString
        pac.Ciudad = CmbUbicacion.SelectedItem.ToString
        pac.Cotizacion = CmbCotizar.SelectedItem.ToString
        pac.Vendedor = CmbVendedor.SelectedValue.ToString
        pac.Estado = "Pendiente"
        pac.grabar()
    End Sub
    Private Sub modificar()
        If pac.Abrir(CLng(TxtNumero.Text)) Then
            pac.Colega = TxtColega.Text
            '            pac.Estado = "Esperando Precios"
            If TxtColega.Text = " " Then
                MsgBox("Debe completar el campo de colega")
            Else
                If CmbEstado.SelectedItem.ToString = "Esperando Precios" Or CmbEstado.SelectedItem.ToString = "Precio Colega" Then
                    pac.Estado = CmbEstado.SelectedItem.ToString
                    pac.GrabarModificacion()
                    LimpiarCampos()
                Else
                    MsgBox("debe elegir 'Esperando Precios' o 'Precio Colega'")
                End If
            End If
        End If
    End Sub
    Private Function ValidarCampos() As Boolean
        Dim txt As String = ""
        If TxtRazonSocial.Text.Trim = "" Then txt &= "La Razon social es obligatoria" & vbCrLf
        If TxtDomicilio.Text.Trim = "" Then txt &= "El domicilio del cliente es obligatorio" & vbCrLf
        If CmbUbicacion.Text.Trim = "" Then txt &= "La ubicacion es obligatoria" & vbCrLf
        If CmbCotizar.Text.Trim = "" Then txt &= "El tipo de cotizacion es obligatoria" & vbCrLf
        If CmbVendedor.Text.Trim = "" Then txt &= "El Vendedor es obligatorio" & vbCrLf
        If txt <> "" Then
            MessageBox.Show(txt, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
        Return txt = ""
    End Function
    Private Sub LimpiarCampos()
        TxtRazonSocial.Text = " "
        TxtDomicilio.Text = " "
        CmbUbicacion.SelectedItem = " "
        TxtColega.Text = " "
        CmbCotizar.SelectedItem = ""
        CmbEstado.SelectedItem = ""
        CmbUbicacion.SelectedItem = ""
        TxtNumero.Text = ""
        Vendedor.Enlazar(cn, CmbVendedor, True)
        If CBVerPendientes.Enabled = True Then
            dgv.DataSource = pac.LlenarDtPendiente
        ElseIf CBVerTodos.Enabled = True Then
            dgv.DataSource = pac.LLenarDt
        End If
        TxtColega.Enabled = False
        CmbEstado.Enabled = False
    End Sub
    Private Sub EnvioPrimerMail(ByVal mails As String)
        mail.Nuevo()
        mail.Remitente(mails, "Matafuegos Georgia")
        mail.AgregarDestinatarioArchivo("mails\Pacto.txt", 2)
        mail.AgregarDestinatarioCopia("sdiaz@georgia.com.ar")
        mail.AgregarDestinatarioCopia(mails)
        mail.Asunto = TxtRazonSocial.Text.ToString & " " & pac.Direccion.ToString & " " & pac.Ciudad.ToString
        mail.Cuerpo = "Gracias"
        mail.Enviar()
    End Sub
    Private Sub EnvioSegundoMail()
        mail.Nuevo()
        mail.Remitente("sdiaz@georgia.com.ar", "Matafuegos Georgia")
        mail.AgregarDestinatarioArchivo("Pacto.txt", 2)
        mail.AgregarDestinatarioCopia("sdiaz@georgia.com.ar")
        mail.Asunto = "PACTO"
        mail.Cuerpo = TxtRazonSocial.Text.ToString & " " & pac.Direccion.ToString & " " & pac.Ciudad.ToString & " - " & CmbEstado.SelectedItem.ToString
        mail.Enviar()
    End Sub
    Private Sub dgv_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellDoubleClick
        If e.RowIndex = -1 Then Exit Sub
        Dim numero As String = dgv.Rows(e.RowIndex).Cells("Numero").Value.ToString
        TxtColega.Enabled = True
        CmbEstado.Enabled = True
        pac.Abrir(CLng(numero))
        TxtNumero.Text = pac.Numero.ToString
        TxtRazonSocial.Text = pac.NombreCliente
        TxtDomicilio.Text = pac.Direccion
        CmbUbicacion.SelectedItem = pac.Ciudad
        CmbEstado.SelectedItem = pac.Cotizacion
        CmbVendedor.SelectedValue = pac.Vendedor
        TxtColega.Text = pac.Colega
        CmbEstado.SelectedItem = pac.Estado
    End Sub
    Private Sub TxtDomicilio_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDomicilio.Validated
        Dim dt As New DataTable
        dt = ValidarDireccion(TxtDomicilio.Text.ToString)
        If dt.Rows.Count > 0 Then
            MsgBox("El domicilio ya tenia consulta anterior, fecha: " & dt.Rows(0).Item("credat_0").ToString & " - Estado: " & dt.Rows(0).Item("estado_0").ToString & " - Colega: " & dt.Rows(0).Item("colega_0").ToString)
        End If
    End Sub
    Private Function ValidarDireccion(ByVal direccion As String) As DataTable
        Dim da As OracleDataAdapter
        Dim dt As New DataTable
        Dim sql As String
        sql = " Select * from xpacto where direccion_0 = :direccion_0"
        da = New OracleDataAdapter(sql, cn)
        da.SelectCommand.Parameters.Add("direccion_0", OracleType.VarChar).Value = direccion
        da.Fill(dt)
        Return dt
    End Function
    Private Sub DtpDesde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtpDesde.ValueChanged
        If DtpDesde.Value > DtpHasta.Value Then DtpHasta.Value = DtpDesde.Value
    End Sub
    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        Dim rpt As New ReportDocument
        Dim crystal As frmCrystal
        rpt.Load(RPTX3 & "xpacto.rpt")
        rpt.SetDatabaseLogon(DB_USR, DB_PWD)
        rpt.SetParameterValue("datdeb", DtpDesde.Value)
        rpt.SetParameterValue("datfin", DtpHasta.Value)
        crystal = New frmCrystal(rpt)
        crystal.MdiParent = Me.ParentForm
        crystal.Show()
    End Sub
    Private Sub dgv_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellEndEdit
        Dim value As String = dgv.CurrentCell.Value.ToString
        If pac.Abrir(CLng(TxtNumero.Text)) Then
            pac.Colega = dgv.Rows(e.RowIndex).Cells("colega").Value.ToString
            If dgv.Rows(e.RowIndex).Cells("Colega").Value.ToString = " " Then
                MsgBox("Debe completar el campo de colega")
            Else
                If dgv.Rows(e.RowIndex).Cells("Estado").Value.ToString = "Esperando Precios" Or dgv.Rows(e.RowIndex).Cells("Estado").Value.ToString = "Precio Colega" Then
                    pac.Estado = dgv.Rows(e.RowIndex).Cells("Estado").Value.ToString
                    pac.GrabarModificacion()
                    LimpiarCampos()
                Else
                    MsgBox("debe elegir 'Esperando Precios' o 'Precio Colega'")
                End If
                'pac.Estado = "Esperando Precios"

            End If
        End If
    End Sub
    Private Sub BtnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLimpiar.Click
        LimpiarCampos()
    End Sub

    
    Private Sub CBVerTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBVerTodos.CheckedChanged
        If CBVerTodos.Checked = True Then
            CBVerPendientes.Checked = False
            dgv.DataSource = pac.LLenarDt
        ElseIf CBVerPendientes.Checked = True Then
            CBVerTodos.Checked = False
            dgv.DataSource = pac.LlenarDtPendiente
        End If
    End Sub

    Private Sub CBVerPendientes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBVerPendientes.CheckedChanged
        If CBVerPendientes.Checked = True Then
            CBVerTodos.Checked = False
            dgv.DataSource = pac.LlenarDtPendiente
        ElseIf CBVerTodos.Checked = True Then
            CBVerPendientes.Checked = False
            dgv.DataSource = pac.LLenarDt
        End If
    End Sub
End Class