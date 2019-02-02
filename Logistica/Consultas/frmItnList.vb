Imports System.Data.OracleClient
Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO

Public Class frmItnList
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
        rpt.Load(RPTX3 & "itn1.rpt")
        rpt.SetDatabaseLogon(DB_USR, DB_PWD)
        rpt.SetParameterValue("itn", numero)
        rpt.SetParameterValue("x3usr", usr.Codigo)
        rpt.SetParameterValue("x3dos", X3DOS)
        crystal = New frmCrystal(rpt)
        crystal.MdiParent = Me.ParentForm
        crystal.Show()
    End Sub

    Private Sub SeguimientoDocumentacionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SeguimientoDocumentacionToolStripMenuItem.Click
        Dim rpt As New ReportDocument
        Dim numero As String = dgv.CurrentRow.Cells("codigo").Value.ToString
        Dim crystal As frmCrystal
        rpt.Load(RPTX3 & "xsegto_itn.rpt")
        rpt.SetDatabaseLogon(DB_USR, DB_PWD)
        rpt.SetParameterValue("itn", numero)
        crystal = New frmCrystal(rpt)
        crystal.MdiParent = Me.ParentForm
        crystal.Show()
    End Sub

    
    Private Sub EquiposRechazadosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EquiposRechazadosToolStripMenuItem.Click
        Dim rpt As New ReportDocument
        Dim numero As String = dgv.CurrentRow.Cells("codigo").Value.ToString
        Dim crystal As frmCrystal
        rpt.Load(RPTX3 & "xconsbaja3.rpt")
        rpt.SetDatabaseLogon(DB_USR, DB_PWD)
        rpt.SetParameterValue("itn", numero)
        crystal = New frmCrystal(rpt)
        crystal.MdiParent = Me.ParentForm
        crystal.Show()
    End Sub

    Private Sub VerEscaneadosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerEscaneadosToolStripMenuItem.Click
        Dim numero As String = dgv.CurrentRow.Cells("codigo").Value.ToString
        Try
            Process.Start("\\srv\Z\Remitos\" & numero & ".pdf")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub ContextMenuStrip1_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        Dim numero As String = dgv.CurrentRow.Cells("codigo").Value.ToString
        If File.Exists("\\srv\Z\Remitos\" & numero & ".pdf") Then
            VerEscaneadosToolStripMenuItem.Enabled = True
        Else
            VerEscaneadosToolStripMenuItem.Enabled = False
        End If
        Dim numero2 As String = dgv.CurrentRow.Cells("remito").Value.ToString
        If File.Exists("\\srv\Z\Remitos\" & numero2 & ".pdf") Then
            VerRemitoEscaneadoToolStripMenuItem.Enabled = True
        Else
            VerRemitoEscaneadoToolStripMenuItem.Enabled = False
        End If
        Dim cliente As String = dgv.CurrentRow.Cells("cliente").Value.ToString
        Dim oc As String = dgv.CurrentRow.Cells("OC").Value.ToString
        If File.Exists("\\srv\Z\OC\" & cliente & "-" & oc & ".pdf") Then
            VerOCEscaneadaToolStripMenuItem.Enabled = True
        Else
            VerOCEscaneadaToolStripMenuItem.Enabled = False
        End If
    End Sub

    Private Sub VerRemitoEscaneadoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerRemitoEscaneadoToolStripMenuItem.Click
        Dim numero As String = dgv.CurrentRow.Cells("remito").Value.ToString
        Try
            Process.Start("\\srv\Z\Remitos\" & numero & ".pdf")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub VerOCEscaneadaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerOCEscaneadaToolStripMenuItem.Click
        Dim cliente As String = dgv.CurrentRow.Cells("cliente").Value.ToString
        Dim oc As String = dgv.CurrentRow.Cells("OC").Value.ToString
        Try
            Process.Start("\\srv\Z\OC\" & cliente & "-" & oc & ".pdf")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub VerDetalleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerDetalleToolStripMenuItem.Click
        Dim rpt As New ReportDocument
        Dim numero As String = dgv.CurrentRow.Cells("codigo").Value.ToString
        Dim crystal As frmCrystal
        rpt.Load(RPTX3 & "intdetalle.rpt")
        rpt.SetDatabaseLogon(DB_USR, DB_PWD)
        rpt.SetParameterValue("num", numero)
        crystal = New frmCrystal(rpt)
        crystal.MdiParent = Me.ParentForm
        crystal.Show()
    End Sub
End Class