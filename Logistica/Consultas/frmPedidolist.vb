Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.OracleClient
Imports System.IO

Public Class frmPedidolist
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
        Dim rpt As New ReportDocument
        Dim numero As String = dgv.CurrentRow.Cells("codigo").Value.ToString
        Dim crystal As frmCrystal
        rpt.Load(RPTX3 & "xpedidos2b2.rpt")
        rpt.SetDatabaseLogon(DB_USR, DB_PWD)
        rpt.SetParameterValue("pedido", numero)
        crystal = New frmCrystal(rpt)
        crystal.MdiParent = Me.ParentForm
        crystal.Show()
    End Sub

    Private Sub VerOCEscaneadaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerOCEscaneadaToolStripMenuItem.Click
        Dim numero As String = dgv.CurrentRow.Cells("codigo_cliente").Value.ToString
        Dim oc As String = dgv.CurrentRow.Cells("oc").Value.ToString
        Try
            Process.Start("\\srv\Z\oc\" & numero & "-" & oc & ".pdf")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ContextMenuStrip1_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        Dim numero As String = dgv.CurrentRow.Cells("codigo_cliente").Value.ToString
        Dim oc As String = dgv.CurrentRow.Cells("oc").Value.ToString
        If File.Exists("\\srv\Z\oc\" & numero & "-" & oc & ".pdf") Then
            VerOCEscaneadaToolStripMenuItem.Enabled = True
        Else
            VerOCEscaneadaToolStripMenuItem.Enabled = False
        End If
    End Sub

    Private Sub ZETIToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ZETIToolStripMenuItem.Click
        Dim rpt As New ReportDocument
        Dim numero As String = dgv.CurrentRow.Cells("codigo").Value.ToString
        Dim crystal As frmCrystal
        rpt.Load(RPTX3 & "ZETI.rpt")
        rpt.SetDatabaseLogon(DB_USR, DB_PWD)
        rpt.SetParameterValue("sohnum", numero)
        rpt.SetParameterValue("x3dos", X3DOS)
        crystal = New frmCrystal(rpt)
        crystal.MdiParent = Me.ParentForm
        crystal.Show()
    End Sub
End Class