Imports CrystalDecisions.CrystalReports.Engine

Module Reportes

    Public Sub rptDistribucionVencimientos(ByVal Cliente As String, ByVal Sucursal As String)
        Dim rpt As New ReportDocument
        Dim f As frmCrystal

        Try
            rpt.Load(RPTX3 & "xparque2.rpt")
            rpt.SetParameterValue("BPC", Cliente)
            rpt.SetParameterValue("FCYITN", Sucursal)
            rpt.SetParameterValue("X3TIT", "Distribución de Vencimientos")
            rpt.SetParameterValue("X3USR", usr.Codigo)

            f = New frmCrystal(rpt)
            f.MdiParent = frmMain
            f.Show()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Public Sub rptDistribucionVencimientosOriginal(ByVal Cliente As String, ByVal Sucursal As String)
        Dim rpt As New ReportDocument
        Dim f As frmCrystal

        Try
            rpt.Load(RPTX3 & "xparque2p.rpt")
            rpt.SetParameterValue("BPC", Cliente)
            rpt.SetParameterValue("FCYITN", Sucursal)
            rpt.SetParameterValue("X3TIT", "Distribución de Vencimientos")
            rpt.SetParameterValue("X3USR", usr.Codigo)

            f = New frmCrystal(rpt)
            f.MdiParent = frmMain
            f.Show()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub
End Module