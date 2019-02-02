Imports System.Data.OracleClient

Public Class frmMotors
    Private da As OracleDataAdapter
    Private dt As New DataTable

    Private Sub frmMotors_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Sql As String

        Sql = "SELECT sdhnum_0, bpaadd_0, bpdaddlig_0,  bpdcty_0, bpdsat_0 "
        Sql &= "FROM sdelivery "
        Sql &= "WHERE bpcord_0 = :cliente AND credat_0 = :fecha"

        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("fecha", OracleType.DateTime)
        da.SelectCommand.Parameters.Add("cliente", OracleType.VarChar)
        da.FillSchema(dt, SchemaType.Mapped)

    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click

        Try
            dt.Clear()
            da.SelectCommand.Parameters("fecha").Value = dtp.Value.Date
            da.SelectCommand.Parameters("cliente").Value = txtCliente.Text.Trim
            da.Fill(dt)

            If dgv.DataSource Is Nothing Then
                colRto.DataPropertyName = "sdhnum_0"
                colSuc.DataPropertyName = "bpaadd_0"
                colDireccion.DataPropertyName = "bpdaddlig_0"
                colLoc.DataPropertyName = "bpdcty_0"
                ColProv.DataPropertyName = "bpdsat_0"
                dgv.DataSource = dt
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        Dim Imprimir As Boolean = True

        If dgv.SelectedRows.Count > 0 Then

            If MessageBox.Show("¿Confirma la impresión de las etiquetas?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> Windows.Forms.DialogResult.Yes Then
                Imprimir = False
            End If

            Dim sdh As New Remito(cn)

            For Each c As DataGridViewRow In dgv.SelectedRows

                Dim rto As String = c.Cells(0).Value.ToString

                If sdh.Abrir(rto) Then
                    sdh.EtiquetasEntrega("etiq.txt", Imprimir)
                End If

            Next

        Else
            MessageBox.Show("No hay filas seleccionadas", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub SplitContainer1_Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles SplitContainer1.Panel1.Paint

    End Sub
End Class