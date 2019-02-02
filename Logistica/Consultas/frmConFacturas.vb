Imports System.Data.OracleClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class frmConFacturas

    Private Sub btnconsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnconsulta.Click
        Dim rpt As New ReportDocument
        Dim fecha As String
        Dim fecha2 As String
        Dim cliente As String
        Dim cliente2 As String
        Dim txt As String = " "
        Dim crystal As frmCrystal
        Dim sociedades As String
        Dim sociedades2 As String
        Dim x3tit As String
        rpt.Load(RPTX3 & "XFACTURAS3_V.rpt")
        rpt.SetDatabaseLogon(DB_USR, DB_PWD)
        If txtcliente.Text = "" Then
            cliente = "000000"
            cliente2 = "999999"
        Else
            cliente = txtcliente.Text
            cliente2 = txtcliente.Text
        End If
        If txtsocie.Text = "" Then
            sociedades = "A00"
            sociedades2 = "Z99"
        Else
            sociedades = txtsocie.Text
            sociedades2 = txtsocie.Text
        End If
        fecha = txtfechaini.Text
        fecha2 = txtfechafin.Text
        x3tit = " "


        rpt.SetParameterValue("datdeb", fecha)
        rpt.SetParameterValue("datfin", fecha2)
        rpt.SetParameterValue("sitedeb", sociedades)
        rpt.SetParameterValue("sitefin", sociedades2)
        rpt.SetParameterValue("x3tit", x3tit)
        rpt.SetParameterValue("clientdeb", cliente)
        rpt.SetParameterValue("clientfin", cliente2)
        If usr.Codigo = "LVER" Or usr.Codigo = "DBAT" Or usr.Codigo = "MBARC" Then
            txt = InputBox("Ingrese el vendedor que quiere ver en el reporte", txt)
            rpt.SetParameterValue("x3usr", txt)
        Else
            rpt.SetParameterValue("x3usr", usr.Codigo)
        End If
        crystal = New frmCrystal(rpt)
        crystal.MdiParent = frmMain.ParentForm
        crystal.Show()
    End Sub
End Class