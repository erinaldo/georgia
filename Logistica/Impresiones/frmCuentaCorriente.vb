Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.OracleClient
Public Class frmCuentaCorriente


    Private Sub btn_acuse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_acuse.Click
        Dim rpt As New ReportDocument
        Dim itn As String
        Dim itn2 As String
        Dim txt As String = " "
        Dim sociedades As String = ""
        Dim x3tit As String
        Dim valida As Boolean

        rpt.Load(RPTX3 & "XCTACTEH2.rpt")
        rpt.SetDatabaseLogon(DB_USR, DB_PWD)
        If chkfac.Checked = False Then
            valida = False
        Else
            valida = True
        End If
        itn = txtbox_ctacte.Text
        itn2 = txtbox_ctacte2.text
        x3tit = " "
        sociedades = cbox_sociedad.SelectedValue.ToString
        rpt.SetParameterValue("bprdeb", itn)
        rpt.SetParameterValue("bprfin", itn2)
        rpt.SetParameterValue("cpydeb", sociedades)
        rpt.SetParameterValue("cpyfin", sociedades)
        rpt.SetParameterValue("x3tit", x3tit)
        rpt.SetParameterValue("histo", valida)

        If usr.Codigo = "LVER" Or usr.Codigo = "DBAT" Or usr.Codigo = "MBARC" Then
            txt = InputBox("Ingrese el vendedor que quiere ver en el reporte", txt)
            rpt.SetParameterValue("rep", txt)
        Else

            rpt.SetParameterValue("rep", usr.Codigo)
        End If
        CrystalReportViewer1.ReportSource = rpt

    End Sub

    Private Sub frmCuentaCorriente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cbox_sociedad.DataSource = Sociedad.Sociedades(cn)
        cbox_sociedad.ValueMember = ("cpy_0")
        cbox_sociedad.DisplayMember = ("cpynam_0")
    End Sub
End Class