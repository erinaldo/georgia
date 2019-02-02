Imports System.Data.OracleClient

Public Class frmUsuarios

    Private ds As New DataSet

    Private daADXusuarios As New OracleDataAdapter("SELECT usr_0, nomusr_0 FROM autilis WHERE usr_0 NOT IN (SELECT usr_0 FROM xnetusr) ORDER BY nomusr_0", cn)
    Private daNETusuarios As New OracleDataAdapter("SELECT xus.usr_0, nomusr_0, xus.passe_0 FROM xnetusr xus INNER JOIN autilis aut on (xus.usr_0 = aut.usr_0)", cn)
    Private daPer As New OracleDataAdapter("SELECT * FROM xnetper", cn)

    Private dtADXusuarios As New DataTable
    Private dtNETusuarios As New DataTable
    Private dtPer As New DataTable

    'SUBS
    Private Sub Adaptadores()

        daNETusuarios.DeleteCommand = New OracleCommand("DELETE FROM xnetusr WHERE usr_0 = :p1", cn)
        With daNETusuarios.DeleteCommand.Parameters.Add("p1", OracleType.Varchar)
            .SourceColumn = "usr_0"
            .SourceVersion = DataRowVersion.Current
        End With

        daNETusuarios.InsertCommand = New OracleCommand("INSERT INTO xnetusr VALUES (:p1, ' ')", cn)
        With daNETusuarios.InsertCommand.Parameters.Add("p1", OracleType.Varchar)
            .SourceColumn = "usr_0"
            .SourceVersion = DataRowVersion.Current
        End With

        daNETusuarios.UpdateCommand = New OracleCommand("UPDATE xnetusr SET passe_0 = :p1 WHERE usr_0 = :p2", cn)
        With daNETusuarios.UpdateCommand.Parameters.Add("p1", OracleType.Varchar)
            .SourceColumn = "passe_0"
            .SourceVersion = DataRowVersion.Current
        End With
        With daNETusuarios.UpdateCommand.Parameters.Add("p2", OracleType.Varchar)
            .SourceColumn = "usr_0"
            .SourceVersion = DataRowVersion.Original
        End With

        daPer.DeleteCommand = New OracleCommand("DELETE FROM xnetper WHERE usr_0 = :p1 AND fncid_0 = :p2", cn)
        With daPer.DeleteCommand.Parameters.Add("p1", OracleType.Varchar)
            .SourceColumn = "usr_0"
            .SourceVersion = DataRowVersion.Original
        End With
        With daPer.DeleteCommand.Parameters.Add("p2", OracleType.Varchar)
            .SourceColumn = "fncid_0"
            .SourceVersion = DataRowVersion.Original
        End With

    End Sub
    Private Sub GrabarCambios()

        Try
            daPer.Update(dtPer)
            daNETusuarios.Update(dtNETusuarios)
            dtADXusuarios.AcceptChanges()

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub
    Private Sub ActivarBotones()
        btnRegistrar.Enabled = ds.HasChanges
        btnCancelar.Enabled = ds.HasChanges
    End Sub

    'EVENTOS
    Private Sub frmUsuarios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim HayError As Boolean = False

        Adaptadores()

        Try
            daADXusuarios.Fill(dtADXusuarios)
            daNETusuarios.Fill(dtNETusuarios)
            daPer.Fill(dtPer)

            With ds
                .Tables.Add(dtNETusuarios)
                .Tables.Add(dtPer)
                .Relations.Add("usrper", dtNETusuarios.Columns("usr_0"), dtPer.Columns("usr_0"))
            End With

            With ds.Relations("usrper").ChildKeyConstraint
                .DeleteRule = Rule.Cascade
                .UpdateRule = Rule.Cascade
                .AcceptRejectRule = AcceptRejectRule.Cascade
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            HayError = True

        End Try

        If HayError Then Me.Close()

        'Enlace con grilla usuarios adonix
        colADXusr.DataPropertyName = "usr_0"
        colADXNombre.DataPropertyName = "nomusr_0"
        dgvADX.DataSource = dtADXusuarios

        'Enlace con grilla usuarios NET
        colNETusr.DataPropertyName = "usr_0"
        colNETnombre.DataPropertyName = "nomusr_0"
        colNETclave.DataPropertyName = "passe_0"
        dgvNET.DataSource = dtNETusuarios



    End Sub
    Private Sub frmUsuarios_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If ds.HasChanges Then
            Select Case MessageBox.Show("¿Graba los cambios antes de salir?", Me.Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                Case Windows.Forms.DialogResult.Yes
                    GrabarCambios()

                Case Windows.Forms.DialogResult.Cancel
                    e.Cancel = True

            End Select

        End If

    End Sub
    Private Sub btnAddSel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddSel.Click
        Dim drv As DataGridViewRow
        Dim dr As DataRow

        For Each drv In dgvADX.SelectedRows
            dr = dtNETusuarios.NewRow
            dr("usr_0") = drv.Cells("colADXusr").Value
            dr("nomusr_0") = drv.Cells("colADXnombre").Value
            dr("passe_0") = " "
            dtNETusuarios.Rows.Add(dr)
            CType(drv.DataBoundItem, DataRowView).Delete()
        Next
        ActivarBotones()

    End Sub
    Private Sub btnDelSel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelSel.Click
        Dim drv As DataGridViewRow
        Dim dr As DataRow

        For Each drv In dgvNET.SelectedRows
            dr = dtADXusuarios.NewRow
            dr("usr_0") = drv.Cells("colNETusr").Value
            dr("nomusr_0") = drv.Cells("colNETnombre").Value
            dtADXusuarios.Rows.Add(dr)
            CType(drv.DataBoundItem, DataRowView).Delete()
        Next
        ActivarBotones()

    End Sub
    Private Sub btnRegistrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegistrar.Click
        If ds.HasChanges Then GrabarCambios()
        ActivarBotones()
    End Sub
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        ds.RejectChanges()
        ActivarBotones()
    End Sub
    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
    Private Sub dgvNET_CellMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvNET.CellMouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            mnuContext.Show(MousePosition.X, MousePosition.Y)
        End If
    End Sub

    'EVENTOS MENU CONTEXTUAL
    Private Sub mnuCambiarClave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCambiarClave.Click
        Dim NuevaClave As String = ""
        Dim Msg As String = "Ingrese la nueva contraseña para {0}"
        Dim row As DataGridViewRow = dgvNET.CurrentRow
        Dim dr As DataRowView

        Msg = String.Format(Msg, row.Cells("colNETnombre").Value.ToString)

        NuevaClave = InputBox(Msg, "Cambio de contraseña", "")

        If NuevaClave IsNot "" Then

            If NuevaClave = "" Then NuevaClave = " "

            dr = CType(row.DataBoundItem, DataRowView)
            dr.BeginEdit()
            dr("passe_0") = NuevaClave
            dr.EndEdit()

            ActivarBotones()

        End If

    End Sub

End Class