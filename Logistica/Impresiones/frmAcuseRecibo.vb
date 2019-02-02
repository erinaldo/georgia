Imports CrystalDecisions.CrystalReports.Engine

Public Class frmAcuseRecibo

    Private Sub btn_acuse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_acuse.Click
        Dim rpt As New ReportDocument
        Dim itn As String
        Dim itn2 As String
        Dim suc As String
        rpt.Load(RPTX3 & "XACUREC.rpt")
        rpt.SetDatabaseLogon(DB_USR, DB_PWD)
        itn = txtbox_acuse.Text
        itn2 = txtbox_obs.Text
        suc = txtsuc.Text
        If txtbox_acuse.Text = "" Then
            MsgBox("ingrese un numero")
        Else
            rpt.SetParameterValue("client", itn)
            rpt.SetParameterValue("suc", suc)
            rpt.SetParameterValue("observa", itn2)
            CrystalReportViewer1.ReportSource = rpt
        End If
    End Sub
End Class