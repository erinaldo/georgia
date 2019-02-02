Imports CrystalDecisions.CrystalReports.Engine

Public Class frmControlPeriodico



    Private Sub btn_control_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_control.Click
        Dim rpt As New ReportDocument
        Dim cliente As String
        Dim direccion As String
        Dim fecha_control As Date
        'Dim destino As String
        Dim fecha_vencimiento As Date
        Dim prox_control As Date
        Dim obs As String
        Dim cumple As Boolean
        Dim usos As String

        rpt.Load(RPTX3 & "XCTRLPE.rpt")
        rpt.SetDatabaseLogon(DB_USR, DB_PWD)
        cliente = txtbox_client.Text
        direccion = txtbox_direccion.Text
        fecha_control = dtp_control.Value.Date
        'destino = txt_destino.Text
        fecha_vencimiento = dtp_fecha_vencimiento.Value.Date
        prox_control = dtp_prox_control.Value.Date
        obs = txt_obs.Text
        If checkIRAM.Checked = True Then
            cumple = True
        Else
            cumple = False
        End If
        usos = txt_usos.Text

        rpt.SetParameterValue("client", cliente)
        rpt.SetParameterValue("add", direccion)
        rpt.SetParameterValue("dat", fecha_control)
        rpt.SetParameterValue("datprox", prox_control)
        rpt.SetParameterValue("observa", obs)
        rpt.SetParameterValue("usos", usos)
        rpt.SetParameterValue("datvenc", fecha_vencimiento)
        rpt.SetParameterValue("cumple", cumple)

        CrystalReportViewer1.ReportSource = rpt

    End Sub
End Class