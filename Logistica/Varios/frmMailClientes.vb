Imports System.Data.OracleClient

Public Class frmMailClientes

    Private daMotivos As New OracleDataAdapter
    Private cmRegistrar As OracleCommand
    Private cm1 As OracleCommand
    Private cm2 As OracleCommand

    Private dtMotivos As New DataTable
    Private dr As DataRowView

    'SUBS
    Public Sub New(ByVal dr As DataRowView)
        InitializeComponent()
        Me.dr = dr
    End Sub
    Private Sub Adaptadores()
        Dim Sql As String

        'MOTIVOS DE LLAMADOS
        Sql = "SELECT code_0, texte_0, a1_0, a2_0, n1_0, n2_0 FROM atabdiv INNER JOIN atextra ON (numtab_0 = ident1_0) AND (code_0 = ident2_0) WHERE numtab_0 = 5002 AND codfic_0 = 'ATABDIV' AND zone_0 = 'LNGDES' ORDER BY code_0"
        daMotivos.SelectCommand = New OracleCommand(Sql, cn)

        'PARA INSERTAR LOS LLAMADOS EN LA TABLA DE LLAMADOS
        Sql = "INSERT INTO xrecep values(:bpcnum_0, :dat_0, :hora_0, :rep_0, :motivo_0, :obj_0, :credat_0, :creusr_0)"
        cmRegistrar = New OracleCommand(Sql, cn)
        cmRegistrar.Parameters.Add("bpcnum_0", OracleType.Varchar)
        cmRegistrar.Parameters.Add("dat_0", OracleType.DateTime)
        cmRegistrar.Parameters.Add("hora_0", OracleType.VarChar)
        cmRegistrar.Parameters.Add("rep_0", OracleType.VarChar)
        cmRegistrar.Parameters.Add("motivo_0", OracleType.VarChar)
        cmRegistrar.Parameters.Add("obj_0", OracleType.VarChar)
        cmRegistrar.Parameters.Add("credat_0", OracleType.DateTime)
        cmRegistrar.Parameters.Add("creusr_0", OracleType.Varchar)

        'Mail vendedor
        cm1 = New OracleCommand("SELECT xanalis_0, xmail_0 FROM salesrep WHERE repnum_0 = :repnum_0", cn)
        cm1.Parameters.Add("repnum_0", OracleType.Varchar)
        'Mail analista
        cm2 = New OracleCommand("SELECT addeml_0 FROM autilis WHERE usr_0 = :usr_0", cn)
        cm2.Parameters.Add("usr_0", OracleType.Varchar)

    End Sub
    Private Sub EnviarMail()
        Dim eMail As New CorreoElectronico
        Dim txt As String
        Dim odr As OracleDataReader

        With eMail
            .Remitente(usr.Mail, usr.Nombre)
            .Asunto = "LLAMADO: " & CType(lstMotivos.SelectedItem, DataRowView).Item("texte_0").ToString
            .EsHtml = False

            AgregarMailsCopiaOculta(eMail)

            'Busco mail del vendedor
            cm1.Parameters("repnum_0").Value = dr("codrep").ToString
            odr = cm1.ExecuteReader

            If odr.Read() Then
                'Agrego dirección de mail de vendedor
                If odr("xmail_0").ToString.Trim <> "" Then .AgregarDestinatario(odr("xmail_0").ToString)

                cm2.Parameters("usr_0").Value = odr("xanalis_0").ToString
                odr.Close()
                odr = cm2.ExecuteReader

                'Busco mail de analista
                If odr.Read() Then
                    'Agrego direccion de mail de analista
                    If odr("addeml_0").ToString.Trim <> "" Then .AgregarDestinatarioCopia(odr("addeml_0").ToString)
                End If

            End If
            odr.Close()

            'Armo cuerpo del mensaje
            txt = "{0}/{2} {1}" & vbCrLf
            txt &= "{3}" & vbCrLf & vbCrLf
            txt &= "El cliente se ha comunicado y pide que lo llamen por el motivo de referencia." & vbCrLf
            txt &= vbCrLf
            txt &= "{4}" & vbCrLf
            txt &= vbCrLf
            txt &= "Fecha: {5} Hora: {6}"

            txt = String.Format(txt, txtCodigo.Text, txtNombre.Text, txtSuc.Text, txtDireccion.Text, txtNota.Text.Trim, Date.Today.ToShortDateString, Date.Today.ToString("hhmm"))
            .Cuerpo = txt


            If .CantidadTo > 0 Or .CantidadCC > 0 Then
                eMail.Enviar()

            Else
                txt = "No se encontró dirección de mail de vendedor y analista. " & vbCrLf
                txt &= "Mail no enviado"

                MessageBox.Show(txt, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

        End With

        eMail.Dispose()
        odr.Dispose()

    End Sub
    Private Sub AgregarMailsCopiaOculta(ByVal eMail As CorreoElectronico)
        'Agrego en copia oculta a todos los usuarios que tienen el tilde de Recibe mails de llamados
        Dim da As New OracleDataAdapter("SELECT DISTINCT addeml_0 FROM autilis WHERE xflgmail2_0 = 2", cn)
        Dim dt As New DataTable
        Dim dr As DataRow

        da.Fill(dt)

        For Each dr In dt.Rows
            eMail.AgregarDestinatario(dr("addeml_0").ToString, True)
        Next

        dt.Dispose()
        da.Dispose()

    End Sub

    'EVENTOS
    Private Sub frmMail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Adaptadores()

        Try
            daMotivos.Fill(dtMotivos)

            With lstMotivos
                .DataSource = dtMotivos
                .ValueMember = "code_0"
                .DisplayMember = "texte_0"
            End With

            'Cargo textbox con datos del cliente
            txtCodigo.Text = dr("codigo").ToString
            txtNombre.Text = dr("nombre").ToString
            txtSuc.Text = dr("suc").ToString
            txtDireccion.Text = dr("domicilio").ToString
            txtCiudad.Text = dr("ciudad").ToString

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub
    Private Sub frmMail_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        daMotivos.Dispose()
        dtMotivos.Dispose()
        cm1.Dispose()
        cm2.Dispose()
        cmRegistrar.Dispose()
    End Sub
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        With cmRegistrar
            .Parameters("bpcnum_0").Value = txtCodigo.Text
            .Parameters("dat_0").Value = Date.Today
            .Parameters("hora_0").Value = Date.Today.ToString("hhmm")
            .Parameters("rep_0").Value = dr("codrep").ToString
            .Parameters("motivo_0").Value = CInt(lstMotivos.SelectedValue)
            If txtNota.Text.Trim.Length > 0 Then
                .Parameters("obj_0").Value = txtNota.Text.Trim
            Else
                .Parameters("obj_0").Value = " "
            End If
            .Parameters("credat_0").Value = Date.Today
            .Parameters("creusr_0").Value = USR.Codigo
        End With

        Try
            cmRegistrar.ExecuteNonQuery()
            EnviarMail()

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            Me.Close()

        End Try

    End Sub
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
    Private Sub txtNota_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNota.GotFocus
        Me.AcceptButton = Nothing
    End Sub
    Private Sub txtNota_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNota.LostFocus
        Me.AcceptButton = btnAceptar
    End Sub

End Class