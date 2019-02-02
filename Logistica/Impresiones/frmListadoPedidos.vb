Imports CrystalDecisions.CrystalReports.Engine

Public Class frmListadoPedidos

    Private Sub btn_list_pedidos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_list_pedidos.Click
        Dim rpt As New ReportDocument
        Dim fecha_inicio As Date
        Dim fecha_fin As Date
        Dim txt As String = " "

        rpt.Load(RPTX3 & "XRECLIS_V2.rpt")
        rpt.SetDatabaseLogon(DB_USR, DB_PWD)
        fecha_inicio = dtp_pago_inicio.Value
        fecha_fin = dtp_pago_fin.Value

        rpt.SetParameterValue("datdeb", fecha_inicio)
        rpt.SetParameterValue("datfin", fecha_fin)

        If usr.Codigo = "LVER" Or usr.Codigo = "DBAT" Then
            txt = InputBox("Ingrese el vendedor que quiere ver en el reporte", txt)
            rpt.SetParameterValue("rep", txt)
        Else
            rpt.SetParameterValue("rep", usr.Codigo)
        End If
        CrystalReportViewer1.ReportSource = rpt

    End Sub
End Class