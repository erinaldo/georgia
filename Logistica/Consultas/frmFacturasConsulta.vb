Imports CrystalDecisions.CrystalReports.Engine

Public Class frmFacturasConsulta

    Private Sub btn_factura_consulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_factura_consulta.Click
        Dim rpt As New ReportDocument
        Dim itn As String

        rpt.Load(RPTX3 & "XFACT_ELEC5.rpt")
        rpt.SetDatabaseLogon(DB_USR, DB_PWD)
        itn = "*" & txtbox_facturas.Text
        If txtbox_facturas.Text = "" Then
            MsgBox("ingrese un numero")
        Else
            rpt.SetParameterValue("facturedeb", itn)
            rpt.SetParameterValue("x3dos", X3DOS)
            rpt.SetParameterValue("ocultar_barras", False)
            CrystalReportViewer1.ReportSource = rpt
        End If
    End Sub
End Class