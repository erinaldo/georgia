Imports System.Data.OracleClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class frmCartelesPallet

    Private da As OracleDataAdapter
    Private dt As DataTable

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Dim Sql As String

        Sql = "SELECT * FROM xpallet"
        da = New OracleDataAdapter(Sql, cn)

        da.DeleteCommand = New OracleCommandBuilder(da).GetDeleteCommand
        da.InsertCommand = New OracleCommandBuilder(da).GetInsertCommand

    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1.Click
        Dim txt As String

        txt = "¿Confirma la generación de {X} carteles?"
        txt = txt.Replace("{X}", nudCantidad.Value.ToString)

        If MessageBox.Show(txt, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            Generar()
            MostrarReporte()
        End If

    End Sub
    Private Sub Generar()
        Dim dr As DataRow
        Dim Ultimo As Long = 0

        dt = New DataTable

        da.Fill(dt)

        For Each dr In dt.Rows
            If CLng(dr("nro_0")) > Ultimo Then
                Ultimo = CLng(dr("nro_0"))
            End If

            dr.Delete()
        Next

        For i = Ultimo + 1 To Ultimo + nudCantidad.Value
            dr = dt.NewRow
            dr("nro_0") = i
            dt.Rows.Add(dr)
        Next

        da.Update(dt)

    End Sub

    Private Sub MostrarReporte()
        Dim rpt As New ReportDocument

        rpt.Load(RPTX3 & "XCARTELPALLET.rpt")
        rpt.SetDatabaseLogon(DB_USR, DB_PWD)

        crv.ReportSource = rpt

    End Sub

    Private Sub btn2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn2.Click
        MostrarReporte()
    End Sub

End Class