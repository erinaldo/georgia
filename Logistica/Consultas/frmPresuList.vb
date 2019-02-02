Imports System.Data.OracleClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class frmPresuList

    Private dt As DataTable
    Private tipo As String


    Public Sub New(ByVal dt As DataTable, ByVal tipo As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.dt = dt
        Me.tipo = tipo

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

    Private Sub frmPresuList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        EnlazarGrilla()
    End Sub

    Private Sub ImprimirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImprimirToolStripMenuItem.Click

        If tipo = "10" Then
            Dim rpt As New ReportDocument
            Dim Numero As String = dgv.CurrentRow.Cells("numero").Value.ToString
            Dim crystal As frmCrystal
            rpt.Load(RPTX3 & "devttc2.rpt")
            rpt.SetDatabaseLogon(DB_USR, DB_PWD)
            rpt.SetParameterValue("devisdeb", Numero)
            rpt.SetParameterValue("devisfin", Numero)
            rpt.SetParameterValue("X3DOS", X3DOS)
            crystal = New frmCrystal(rpt)
            crystal.MdiParent = Me.ParentForm
            crystal.Show()
        Else
            Dim rpt As New ReportDocument
            Dim Numero As String = dgv.CurrentRow.Cells("numero").Value.ToString
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