Imports System.Data.OracleClient

Public Class frmFunciones

    Private ds As New DataSet
    Private daFnc As New OracleDataAdapter("SELECT * FROM xnetfnc", cn)
    Private daPer As New OracleDataAdapter("SELECT * FROM xnetper", cn)

    Private WithEvents dtFnc As New DataTable
    Private dtPer As New DataTable

    'SUBS
    Private Sub Adaptadores()
        daFnc.InsertCommand = New OracleCommandBuilder(daFnc).GetInsertCommand
        daFnc.DeleteCommand = New OracleCommandBuilder(daFnc).GetDeleteCommand
        daFnc.UpdateCommand = New OracleCommand("UPDATE xnetfnc SET fnc_0 = :p1, descripcio_0 = :p2, padre_0 = :p3 WHERE fnc_0 = :p4 AND padre_0 = :p5", cn)
        With daFnc.UpdateCommand.Parameters.Add("p1", OracleType.Varchar)
            .SourceColumn = "fnc_0"
            .SourceVersion = DataRowVersion.Current
        End With
        With daFnc.UpdateCommand.Parameters.Add("p2", OracleType.Varchar)
            .SourceColumn = "descripcio_0"
            .SourceVersion = DataRowVersion.Current
        End With
        With daFnc.UpdateCommand.Parameters.Add("p3", OracleType.Varchar)
            .SourceColumn = "padre_0"
            .SourceVersion = DataRowVersion.Current
        End With
        With daFnc.UpdateCommand.Parameters.Add("p4", OracleType.Varchar)
            .SourceColumn = "fnc_0"
            .SourceVersion = DataRowVersion.Original
        End With
        With daFnc.UpdateCommand.Parameters.Add("p5", OracleType.Varchar)
            .SourceColumn = "padre_0"
            .SourceVersion = DataRowVersion.Original
        End With
        '--------
        daPer.DeleteCommand = New OracleCommand("DELETE FROM xnetper WHERE usr_0 = :p1 AND fncid_0 = :p2", cn)
        With daPer.DeleteCommand.Parameters.Add("p1", OracleType.Varchar)
            .SourceColumn = "usr_0"
            .SourceVersion = DataRowVersion.Original
        End With
        With daPer.DeleteCommand.Parameters.Add("p2", OracleType.Varchar)
            .SourceColumn = "fncid_0"
            .SourceVersion = DataRowVersion.Original
        End With

        daPer.UpdateCommand = New OracleCommand("UPDATE xnetper SET fncid_0 = :p1 WHERE fncid_0 = :p2 AND usr_0 = :p3", cn)
        With daPer.UpdateCommand.Parameters.Add("p1", OracleType.Number)
            .SourceColumn = "fncid_0"
            .SourceVersion = DataRowVersion.Current
        End With
        With daPer.UpdateCommand.Parameters.Add("p2", OracleType.Number)
            .SourceColumn = "fncid_0"
            .SourceVersion = DataRowVersion.Original
        End With
        With daPer.UpdateCommand.Parameters.Add("p3", OracleType.Varchar)
            .SourceColumn = "usr_0"
            .SourceVersion = DataRowVersion.Current
        End With

    End Sub
    Private Sub GrabarCambios()
        Try
            daPer.Update(dtPer)
            daFnc.Update(dtFnc)

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        ActivarBotones()

    End Sub
    Private Sub ActivarBotones()
        btnRegistrar.Enabled = ds.HasChanges
        btnCancelar.Enabled = ds.HasChanges
    End Sub

    'EVENTOS
    Private Sub frmFunciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim HayError As Boolean = False

        Adaptadores()

        Try
            daFnc.Fill(dtFnc)
            daPer.Fill(dtPer)

            With ds
                .Tables.Add(dtFnc)
                .Tables.Add(dtPer)
                .Relations.Add("usrfnc", dtFnc.Columns("fncid_0"), dtPer.Columns("fncid_0"))
            End With

            With ds.Relations("usrfnc").ChildKeyConstraint
                .DeleteRule = Rule.Cascade
                .UpdateRule = Rule.Cascade
                .AcceptRejectRule = AcceptRejectRule.Cascade
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            HayError = True

        End Try

        If HayError Then Me.Close()

        'Enlace con la grilla
        colFncid.DataPropertyName = "fncid_0"
        colFnc.DataPropertyName = "fnc_0"
        colDescripcion.DataPropertyName = "descripcio_0"
        colPadre.DataPropertyName = "padre_0"
        dgv.DataSource = dtFnc

    End Sub
    Private Sub frmFunciones_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If ds.HasChanges Then
            Select Case MessageBox.Show("¿Graba los cambios antes de salir?", Me.Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                Case Windows.Forms.DialogResult.Yes
                    GrabarCambios()

                Case Windows.Forms.DialogResult.Cancel
                    e.Cancel = True

            End Select

        End If
    End Sub
    Private Sub frmFunciones_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        ds.Dispose()
        daFnc.Dispose()
        daPer.Dispose()
    End Sub
    Private Sub dtFnc_RowChanged(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs) Handles dtFnc.RowChanged
        ActivarBotones()
    End Sub
    Private Sub dtFnc_RowDeleted(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs) Handles dtFnc.RowDeleted
        ActivarBotones()
    End Sub
    Private Sub dtFnc_TableNewRow(ByVal sender As Object, ByVal e As System.Data.DataTableNewRowEventArgs) Handles dtFnc.TableNewRow
        ActivarBotones()
    End Sub
    Private Sub btnRegistrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegistrar.Click
        If ds.HasChanges Then GrabarCambios()
    End Sub
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        ds.RejectChanges()
        ActivarBotones()
    End Sub
    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

End Class