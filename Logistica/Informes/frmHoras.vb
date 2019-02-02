Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.OleDb

Public Class frmHoras
    Private Const RPT_FILE As String = "\\servidor2\reloj\hs.rpt"

    Private Sub dtpInicio_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpInicio.ValueChanged
        If dtpInicio.Value > dtpFin.Value Then dtpFin.Value = dtpInicio.Value
    End Sub

    Private Sub dtpFin_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFin.ValueChanged
        If dtpFin.Value < dtpInicio.Value Then
            MessageBox.Show("Fecha Hasta no puede ser menor a fecha Desde", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dtpFin.Value = dtpInicio.Value
        End If
    End Sub

    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        Dim rpt As New ReportDocument

        Try
            rpt.Load(RPT_FILE)
            rpt.SetParameterValue("FECHA_INI", dtpInicio.Value.ToString("yyyyMMdd"))
            rpt.SetParameterValue("FECHA_FIN", dtpFin.Value.ToString("yyyyMMdd"))

            crv.ReportSource = rpt

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

End Class