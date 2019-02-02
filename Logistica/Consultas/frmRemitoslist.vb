Imports System.Data.OracleClient
Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO

Public Class frmRemitoslist

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
        rpt.Load(RPTX3 & "bonliv.rpt")
        rpt.SetDatabaseLogon(DB_USR, DB_PWD)
        rpt.SetParameterValue("livraisondeb", numero)
        rpt.SetParameterValue("livraisonfin", numero)
        rpt.SetParameterValue("x3dos", X3DOS)
        crystal = New frmCrystal(rpt)
        crystal.MdiParent = Me.ParentForm
        crystal.Show()
    End Sub

    Private Sub SeguimientoDocumentacionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SeguimientoDocumentacionToolStripMenuItem.Click
        Dim rpt As New ReportDocument
        Dim numero As String = dgv.CurrentRow.Cells("codigo").Value.ToString
        Dim crystal As frmCrystal
        rpt.Load(RPTX3 & "xsegto_rto.rpt")
        rpt.SetDatabaseLogon(DB_USR, DB_PWD)
        rpt.SetParameterValue("rto", numero)
        crystal = New frmCrystal(rpt)
        crystal.MdiParent = Me.ParentForm
        crystal.Show()
    End Sub

    Private Sub ContextMenuStrip1_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        Dim numero As String = dgv.CurrentRow.Cells("codigo").Value.ToString
        If File.Exists("\\srv\Z\Remitos\" & numero & ".pdf") Then
            VerEscaneadosToolStripMenuItem.Enabled = True
        Else
            VerEscaneadosToolStripMenuItem.Enabled = False
        End If


        Dim dt2 As DataTable
        dt2 = numero_ped(numero)
        If dt2.Rows.Count = 0 Then
            PedidosToolStripMenuItem.Enabled = False
        Else
            Dim dr As DataRow = dt2.Rows(0)
            Dim numero_pedido As String = dr("bpcord_0").ToString
            Dim oc As String = dr("cusordref_0").ToString
            If File.Exists("\\srv\Z\oc\" & numero_pedido & "-" & oc & ".pdf") Then
                PedidosToolStripMenuItem.Enabled = True
            Else
                PedidosToolStripMenuItem.Enabled = False
            End If
        End If

    End Sub

    Private Sub VerEscaneadosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerEscaneadosToolStripMenuItem.Click
        Dim numero As String = dgv.CurrentRow.Cells("codigo").Value.ToString
        Try
            Process.Start("\\srv\Z\Remitos\" & numero & ".pdf")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub PedidosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PedidosToolStripMenuItem.Click
        Dim numero As String = dgv.CurrentRow.Cells("codigo").Value.ToString
        Dim dt2 As DataTable
        dt2 = numero_ped(numero)
        Dim dr As DataRow = dt2.Rows(0)

        Dim numero_pedido As String = dr("bpcord_0").ToString
        Dim oc As String = dr("cusordref_0").ToString
        Try
            Process.Start("\\srv\Z\oc\" & numero_pedido & "-" & oc & ".pdf")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Function numero_ped(ByVal numero As String) As DataTable
        Dim Sql As String
        Dim da As OracleDataAdapter
        Dim dt2 As New DataTable
        Sql = "select so.bpcord_0, cusordref_0 "
        Sql &= "from sdelivery sd join sorder so on (sd.SOHNUM_0 = so.sohnum_0) where sd.sdhnum_0 = :sdhnum_0"
        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("sdhnum_0", OracleType.VarChar).Value = numero
        dt2.Clear()
        da.Fill(dt2)
        Return dt2
    End Function
End Class