Imports System.Data.OracleClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class frmIRAM2
    Private itn As New Intervencion(cn)
    Private rpt As New ReportDocument

    Private Sub txtItn_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtItn.KeyUp
        If e.KeyCode = Keys.Enter Then Imprimir()
    End Sub
    Private Sub txtItn_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtItn.TextChanged
        btnImprimir.Enabled = txtItn.Text.Trim <> ""
    End Sub
    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        Imprimir()
    End Sub
    Private Sub Imprimir()
        txtItn.Enabled = False
        btnImprimir.Enabled = False
        Me.UseWaitCursor = True

        Application.DoEvents()
        Application.DoEvents()

        Try
            'Veo si puedo abrir la intervencion
            Label2.Text = "Abriendo la intervención..."
            Application.DoEvents()
            Application.DoEvents()

            If itn.Abrir(txtItn.Text) Then
                'Miro si tiene articulo de control periodico
                If itn.ExisteRetira("652001") OrElse itn.ExisteRetira("652002") Then
                    'Mando a imprimir
                    Label2.Text = "Imprimiendo la planilla..."
                    Application.DoEvents()
                    Application.DoEvents()

                    With rpt
                        .Load(RPTX3 & "xctrlpe2b.rpt")
                        .SetDatabaseLogon(DB_USR, DB_PWD)
                        .SetParameterValue("X3DOS", X3DOS)
                        .SetParameterValue("ITN", txtItn.Text)
                        .SetParameterValue("CUMPLE", chkCumple.Checked)

                        If chkCumple.Checked Then
                            .SetParameterValue("OBS", "")
                        Else
                            .SetParameterValue("OBS", txtObs.Text)
                        End If

                        .PrintToPrinter(1, False, 1, 1)
                    End With

                Else
                    MessageBox.Show("No es una intervención de Control Periódico", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)

                End If

            Else
                MessageBox.Show("No se encontró la intervención", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            txtItn.Enabled = True
            btnImprimir.Enabled = True
            Me.UseWaitCursor = False

            txtItn.Clear()
            txtItn.Focus()
            If chkCumple.Checked Then txtObs.Clear()
            Label2.Text = ""
            Application.DoEvents()

        End Try

    End Sub
    Private Sub frmIRAM2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label2.Text = ""
    End Sub
    Private Sub chkCumple_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCumple.CheckedChanged
        txtObs.Enabled = Not chkCumple.Checked
    End Sub

End Class