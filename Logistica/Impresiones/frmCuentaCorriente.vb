Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.OracleClient

Public Class frmCuentaCorriente


    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Dim rpt As New ReportDocument

        rpt.Load(RPTX3 & "XCTACTEH_V.rpt")
        rpt.SetDatabaseLogon(DB_USR, DB_PWD)
        rpt.SetParameterValue("bprdeb", txtDesde.Text)
        rpt.SetParameterValue("bprfin", txtHasta.Text)
        rpt.SetParameterValue("cpydeb", cboSociedad.SelectedValue.ToString)
        rpt.SetParameterValue("cpyfin", cboSociedad.SelectedValue.ToString)
        rpt.SetParameterValue("x3tit", "Cuenta Corriente")
        rpt.SetParameterValue("histo", chkSaldadas.Checked)
        rpt.SetParameterValue("usr", usr.Codigo)

        CrystalReportViewer1.ReportSource = rpt

    End Sub

    Private Sub frmCuentaCorriente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cboSociedad.DataSource = Sociedad.Sociedades(cn)
        cboSociedad.ValueMember = ("cpy_0")
        cboSociedad.DisplayMember = ("cpynam_0")
    End Sub

End Class