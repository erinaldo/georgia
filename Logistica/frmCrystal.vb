Imports CrystalDecisions.CrystalReports.Engine

Public Class frmCrystal

    Public Sub New(ByRef rpt As ReportDocument)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        rpt.SetDatabaseLogon(DB_USR, DB_PWD)
        rpt.SetParameterValue("X3DOS", X3DOS)

        CrystalReportViewer1.ReportSource = rpt

    End Sub

    Private Sub frmCrystal_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        With CrystalReportViewer1
            CType(.ReportSource, ReportDocument).Dispose()
        End With
    End Sub

End Class