Imports System.Data.OracleClient
Imports CrystalDecisions.CrystalReports.Engine
Public Class frmEstadodePedidos

    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim rpt As New ReportDocument
        Dim txt As String = ""
        rpt.Load(RPTX3 & "XSTAPED.rpt")
        rpt.SetDatabaseLogon(DB_USR, DB_PWD)
        If Len(usr.Codigo) > 2 Then
            txt = InputBox("Ingrese Vendedor", txt)
            txt = txt.Trim
            rpt.SetParameterValue("REPDEB", txt)
            rpt.SetParameterValue("REPFIN", txt)
        Else
            rpt.SetParameterValue("REPDEB", usr.Codigo)
            rpt.SetParameterValue("REPFIN", usr.Codigo)
        End If
        rpt.SetParameterValue("x3dos", X3DOS)
        rpt.SetParameterValue("X3TIT", "ESTADO DE PEDIDOS")
        rpt.SetParameterValue("X3USR", usr.Codigo)
        rpt.SetParameterValue("BPCDEB", "000000")
        rpt.SetParameterValue("BPCFIN", "999999")

        CrystalReportViewer1.ReportSource = rpt
    End Sub
End Class