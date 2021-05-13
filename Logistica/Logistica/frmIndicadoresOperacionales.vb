Imports Clases
Imports CrystalDecisions.CrystalReports.Engine

Public Class frmIndicadoresOperacionales

    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        Dim rpt As New ReportDocument
        Dim Desde As Date
        Dim Hasta As Date

        Hasta = dtp.Value
        Desde = New Date(Hasta.Year, Hasta.Month, 1)


        rpt.Load(RPTX3 & "xindoper.rpt")
        rpt.SetParameterValue("DESDE", Desde)
        rpt.SetParameterValue("HASTA", Hasta)
        rpt.SetDatabaseLogon(DB_USR, DB_PWD)

        crv.ReportSource = rpt

    End Sub
    
End Class