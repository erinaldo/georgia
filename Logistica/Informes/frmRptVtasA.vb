Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.OracleClient

'REPORTE DE VENTAS ANUAL
Public Class frmRptVtasA

    Private daVend As OracleDataAdapter
    Private dtVend As New DataTable
    Private AnoConsulta As Integer = 0
    Private rpt As ReportDocument

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Adaptadores()
    End Sub
    Private Sub Adaptadores()
        Dim Sql As String

        Sql = "SELECT repnum_0, repnam_0 FROM salesrep WHERE activo_0 = 2 ORDER BY repnam_0"
        daVend = New OracleDataAdapter(Sql, cn)

    End Sub
    Private Sub frmRptVtas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        nudAno.Maximum = Date.Today.Year
        nudAno.Value = Date.Today.Year

        chkCosto.Visible = usr.Codigo.Length <> 2

        Try
            CargarVendedores()

            btnGenerar.Enabled = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub
    Private Sub AgregarVendedoresChequeados(ByVal r As ReporteVentaAnual)
        Dim str As String = ""
        Dim dr As DataRowView

        r.Vendedores.Clear()

        For Each dr In lstVendedores.CheckedItems
            r.Vendedores.Add(dr("repnum_0").ToString)
            str &= dr("repnum_0").ToString & ", "
        Next

    End Sub
    Private Sub Generar()
        Dim Reporte As New ReporteVentaAnual(cn)
        Dim TipoReporte As Integer

        Me.UseWaitCursor = True
        btnGenerar.Enabled = False
        Label1.Text = "Generando reporte..."
        Label1.Visible = True
        Application.DoEvents()

        AnoConsulta = CInt(nudAno.Value)

        If rbRpt1.Checked Then
            TipoReporte = 1
        ElseIf rbRpt2.Checked Then
            TipoReporte = 2
        Else
            TipoReporte = 3
        End If

        AgregarVendedoresChequeados(Reporte)

        With Reporte
            .usr = usr
            .AnoConsulta = CInt(nudAno.Value)
            .Costos = chkCosto.Checked
            .Iva = chkIVA.Checked
            .Presupuesto = chkPresupuesto.Checked
            .Nuevo(AnoConsulta, TipoReporte)
        End With

        If rpt IsNot Nothing Then rpt.Dispose()
        rpt = New ReportDocument
        crv.ReportSource = Nothing

        Select Case TipoReporte
            Case 1
                rpt.Load(RPTX3 & "XRPTVTASA.rpt")
                rpt.SetParameterValue("IVA", chkIVA.Checked)
                rpt.SetParameterValue("COSTOS", chkCosto.Checked)
                rpt.SetParameterValue("PRESUPUESTO", chkPresupuesto.Checked)
            Case 2
                rpt.Load(RPTX3 & "XRPTVTASA2.rpt")
                rpt.SetParameterValue("X3TIT", "Seguimiento de extintores")
            Case 3

        End Select

        rpt.SetParameterValue("X3USR", usr.Codigo)
        rpt.SetDatabaseLogon(DB_USR, DB_PWD)
        crv.ReportSource = rpt

        Me.UseWaitCursor = False
        btnGenerar.Enabled = True
        Label1.Visible = False
    End Sub
    Private Sub CargarVendedores()
        Dim i As Integer
        Dim dr As DataRow

        'Cargo combo de vendedores
        daVend.Fill(dtVend)

        'Si el usuario es vendedor, elimino de la tabla los demás vendedores
        If usr.Codigo.Length = 2 Then
            For i = dtVend.Rows.Count - 1 To 0 Step -1
                dr = dtVend.Rows(i)

                If usr.Codigo <> dr("repnum_0").ToString Then
                    dtVend.Rows.Remove(dr)
                End If
            Next
        End If

        'Enlazo la tabla al ListBox
        With lstVendedores
            .DataSource = dtVend
            .ValueMember = "repnum_0"
            .DisplayMember = "repnam_0"
        End With

        'Recorro todos los vendedores y los chequeo
        For i = 0 To lstVendedores.Items.Count - 1
            lstVendedores.SetItemChecked(i, True)
        Next

    End Sub
    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click

        'Valido que al menos haya seleccionado un vendedor
        If lstVendedores.CheckedItems.Count = 0 Then
            MessageBox.Show("Debe seleccionar al menos un vendedor", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        Generar()

    End Sub

    'MENU CONTEXTUAL DE LA LISTA DE VENDEDORES
    Private Sub mnuMarcarTodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMarcarTodos.Click
        For i As Integer = 0 To lstVendedores.Items.Count - 1
            lstVendedores.SetItemChecked(i, True)
        Next
    End Sub
    Private Sub mnuDesmarcarTodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDesmarcarTodos.Click
        For i As Integer = 0 To lstVendedores.Items.Count - 1
            lstVendedores.SetItemChecked(i, False)
        Next
    End Sub
    Private Sub rbRpt1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbRpt1.CheckedChanged
        If rbRpt1.Checked Then
            lstVendedores.Enabled = True
            chkCosto.Enabled = True
            chkPresupuesto.Enabled = True
            chkIVA.Enabled = True

        Else
            'For i As Integer = 0 To lstVendedores.Items.Count - 1
            '    lstVendedores.SetItemChecked(i, True)
            'Next
            'lstVendedores.Enabled = False

            chkCosto.Enabled = False
            chkCosto.Checked = False
            chkPresupuesto.Enabled = False
            chkPresupuesto.Checked = False
            chkIVA.Enabled = False
            chkIVA.Checked = False
        End If
    End Sub
    Private Sub chkPresupuesto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPresupuesto.CheckedChanged
        If chkPresupuesto.Checked Then chkIVA.Checked = False
    End Sub
    Private Sub chkIVA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIVA.CheckedChanged
        If chkIVA.Checked Then chkPresupuesto.Checked = False
    End Sub

End Class