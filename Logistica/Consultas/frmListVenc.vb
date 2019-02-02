Imports CrystalDecisions.CrystalReports.Engine

Public Class frmListVenc

    Private Sub btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn.Click
        Dim rpt As New ReportDocument
        Dim crystal As frmCrystal
        rpt.Load(RPTX3 & "YMACITM2.rpt")
        rpt.SetDatabaseLogon(DB_USR, DB_PWD)
        rpt.SetParameterValue("DATDEB", dtpini.Value)
        rpt.SetParameterValue("DATFIN", dtpfin.Value)
        rpt.SetParameterValue("BPCDEB", "000000")
        rpt.SetParameterValue("BPCFIN", "999999")
        rpt.SetParameterValue("REPDEB", TXTREP.Text)
        rpt.SetParameterValue("REPFIN", TXTREP.Text)
        rpt.SetParameterValue("ITMDEB", "000000")
        rpt.SetParameterValue("ITMFIN", "999999")
        rpt.SetParameterValue("X3USR", usr.Codigo)
        crystal = New frmCrystal(rpt)
        crystal.MdiParent = Me.ParentForm
        crystal.Show()
    End Sub
End Class