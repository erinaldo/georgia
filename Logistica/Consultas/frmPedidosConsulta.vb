Imports CrystalDecisions.CrystalReports.Engine

Public Class frmPedidosConsulta

    Private Sub btn_pedidos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_pedidos.Click
        Dim rpt As New ReportDocument
        Dim itn As String

        rpt.Load(RPTX3 & "xpedidos2B.rpt")
        rpt.SetDatabaseLogon(DB_USR, DB_PWD)
        itn = "*" & txtbox_pedido.Text

        If txtbox_pedido.Text = "" Then
            MsgBox("ingrese un numero")
        Else
            rpt.SetParameterValue("pedido", itn)
            rpt.SetParameterValue("x3dos", X3DOS)
            CrystalReportViewer1.ReportSource = rpt
        End If
    End Sub
End Class