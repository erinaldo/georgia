Imports CrystalDecisions.CrystalReports.Engine

Public Class FrmPresupuestoAnual

    Private Sub btn_presupuesto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_presupuesto.Click
        Dim rpt As New ReportDocument
        Dim numero As String
        numero = txtbox_presupuesto.Text.Trim


        If txtbox_presupuesto.Text = "" Then
            MsgBox("ingrese un numero")
        Else
            Dim crystal As frmCrystal
            rpt.Load(RPTX3 & "devttc.rpt")
            rpt.SetDatabaseLogon(DB_USR, DB_PWD)
            rpt.SetParameterValue("devisdeb", Numero)
            rpt.SetParameterValue("devisfin", Numero)
            rpt.SetParameterValue("X3DOS", X3DOS)
            crystal = New frmCrystal(rpt)
            crystal.MdiParent = Me.ParentForm
            crystal.Show()
        End If
    End Sub
End Class