Imports System.Data.OracleClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class frmConFacturas

    Private Sub btnconsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsulta.Click
        Dim rpt As New ReportDocument
        Dim FechaDesde As Date
        Dim FechaHasta As Date
        Dim ClienteDesde As String = "000000"
        Dim ClienteHasta As String = "999999"
        Dim txt As String = " "
        Dim crystal As frmCrystal

        rpt.Load(RPTX3 & "XFACTURAS3_V.rpt")
        rpt.SetDatabaseLogon(DB_USR, DB_PWD)

        If txtCliente.Text <> "" Then
            ClienteDesde = txtCliente.Text
            ClienteHasta = txtCliente.Text
        End If

        FechaDesde = dtpDesde.Value
        FechaHasta = dtpHasta.Value

        rpt.SetParameterValue("x3tit", " ")
        rpt.SetParameterValue("datdeb", FechaDesde)
        rpt.SetParameterValue("datfin", FechaHasta)
        rpt.SetParameterValue("clientdeb", ClienteDesde)
        rpt.SetParameterValue("clientfin", ClienteHasta)
        rpt.SetParameterValue("x3usr", usr.Codigo)

        crystal = New frmCrystal(rpt)
        crystal.MdiParent = frmMain.ParentForm
        crystal.Show()
    End Sub

End Class