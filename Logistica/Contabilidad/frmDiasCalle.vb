Imports CrystalDecisions.CrystalReports.Engine

Public Class frmDiasCalle

    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        Dim dcalle As New DiaCalle(cn, usr)
        dcalle.Calcular()

        Dim rpt As New ReportDocument

        With rpt
            .Load(RPTX3 & "XDECALLE.rpt")
            .SetDatabaseLogon(DB_USR, DB_PWD)
            .SetParameterValue("USR", usr.Codigo)
        End With

        crv.ReportSource = rpt

    End Sub
End Class