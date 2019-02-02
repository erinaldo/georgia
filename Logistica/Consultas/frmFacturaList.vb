Imports System.Data.OracleClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class frmFacturaList
    Private dt As DataTable
   

    Public Sub New(ByVal dt As DataTable)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.dt = dt


    End Sub
    Private Sub EnlazarGrilla()
        If dgv.DataSource Is Nothing Then
            dgv.DataSource = dt
            dgv.AutoResizeColumns()
            For i As Integer = 0 To dgv.Columns.Count - 1
                dgv.Columns(i).Visible = True
            Next

        End If
    End Sub
    Private Sub frmFacturaList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        EnlazarGrilla()
    End Sub
    Private Sub ImprimirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImprimirToolStripMenuItem.Click
        Dim fac As String = dgv.CurrentRow.Cells("fac_elec").Value.ToString
        If fac = "2" Or fac = "3" Then
            Dim rpt As New ReportDocument
            Dim Numero As String = dgv.CurrentRow.Cells("codigo").Value.ToString
            Dim crystal As frmCrystal
            rpt.Load(RPTX3 & "XFACT_ELEC.rpt")
            rpt.SetDatabaseLogon(DB_USR, DB_PWD)
            rpt.SetParameterValue("facturedeb", Numero)
            rpt.SetParameterValue("facturefin", Numero)
            rpt.SetParameterValue("cero", False)
            rpt.SetParameterValue("enviar", False)
            rpt.SetParameterValue("ocultar_barras", True)
            'rpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, "FacturaElectronica.pdf")
            'Process.Start("FacturaElectronica.pdf")
            crystal = New frmCrystal(rpt)
            crystal.MdiParent = Me.ParentForm
            crystal.Show()
        ElseIf fac = "0" Or fac = "1" Then
            Dim rpt As New ReportDocument
            Dim Numero As String = dgv.CurrentRow.Cells("codigo").Value.ToString
            Dim crystal As frmCrystal
            rpt.Load(RPTX3 & "SBONFACP.rpt")
            rpt.SetDatabaseLogon(DB_USR, DB_PWD)
            rpt.SetParameterValue("facturedeb", Numero)
            rpt.SetParameterValue("facturefin", Numero)
            rpt.SetParameterValue("Leyenda", 1)
            rpt.SetParameterValue("X3DOS", X3DOS)
            crystal = New frmCrystal(rpt)
            crystal.MdiParent = Me.ParentForm
            crystal.Show()
        End If
    End Sub

End Class