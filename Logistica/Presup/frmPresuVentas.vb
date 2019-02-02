Imports System.Data.OracleClient

Public Class frmPresuVentas
    Private Mes As Integer
    Private pa As New PresupuestoAnual(cn)
    Private SumaReal As Double
    Private SumaPresupuesto As Double
    Private Desde As Date
    Private Hasta As Date
    Private dtEstructura As DataTable
    Private dtRealAcumulado As DataTable
    Private dtPresupuesto As DataTable
    Private VentaAcumulada As Double = 0

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        Me.UseWaitCursor = True
        btnGenerar.Enabled = False
        With lblBuscando
            .Top = dgv.Top + (dgv.Height - .Height) \ 2
            .Left = dgv.Left + (dgv.Width - .Width) \ 2
            .Visible = True
            .BringToFront()
            Application.DoEvents()
            Application.DoEvents()
        End With

        Desde = New Date(Calendar.SelectionRange.Start.Year, 1, 1)
        Hasta = Calendar.SelectionRange.Start
        Mes = Hasta.Month

        CargarEstructuraGeneral()
        CalcularVentaAcumulada()
        CalcularRealAcumulado()
        pa.Abrir(Desde.Year)

        SumaReal = 0
        SumaPresupuesto = 0

        For Each dr As DataRow In dtEstructura.Rows
            dr("ra") = REAL(dr("CC").ToString)
            dr("pa") = PaCu(dr("cc").ToString)
            dr("rp") = CDbl(dr("ra")) - CDbl(dr("pa"))
            If CDbl(dr("pa")) > 0 Then
                dr("pv") = CDbl(dr("ra")) / CDbl(dr("pa")) * 100 - 100
            End If
        Next

        dgv.Columns(1).HeaderText = "Real Acumulado (" & Hasta.ToString("dd/MM/yy") & ")"

        Me.UseWaitCursor = False
        btnGenerar.Enabled = True
        lblBuscando.Visible = False

    End Sub
    Private Sub CalcularVentaAcumulada()
        Dim da As OracleDataAdapter
        Dim dr As DataRow
        Dim sql As String
        Dim dt As New DataTable

        sql = "SELECT ABS(SUM(amtloc_0 * sns_0)) as total "
        sql &= "FROM gaccentryd "
        sql &= "WHERE (accdat_0 >= :datini AND accdat_0 <= :datend) AND cna_0 = '411106'"
        da = New OracleDataAdapter(sql, cn)
        da.SelectCommand.Parameters.Add("datini", OracleType.DateTime).Value = Desde
        da.SelectCommand.Parameters.Add("datend", OracleType.DateTime).Value = Hasta
        da.Fill(dt)
        dr = dt.Rows(0)

        VentaAcumulada = CDbl(dr("total"))
        VentaAcumulada = Math.Abs(VentaAcumulada)

    End Sub
    Private Function PaCu(ByVal cc As String) As Double
        If cc = "Total de ventas sin iva" Then
            Return pa.ObtenerValorAcumulado("TOT", "411106", Mes)

        ElseIf cc = "Total" Then
            Return SumaPresupuesto

        Else
            Dim a = pa.ObtenerValorAcumulado(cc, Mes)

            SumaPresupuesto += Math.Round(a, 5)

            Return Math.Round(a, 5)

        End If

    End Function
    Private Sub CalcularRealAcumulado()
        Dim da As OracleDataAdapter
        Dim sql As String

        sql = "select cce_0, sum(gaa.amtloc_0 * sns_0)as suma "
        sql &= "from gaccentrya GAA  INNER JOIN gaccentryd gad on (gaa.num_0 = gad.num_0 and gaa.lig_0 = gad.lig_0) "
        sql &= "where (gaa.accdat_0 >= :datini and gaa.accdat_0 <= :datend) and "
        sql &= "	  gaa.cna_0 not in ('511102','611101','612202','114205','622002','612204', '611201') "
        sql &= "group by cce_0"

        da = New OracleDataAdapter(sql, cn)
        da.SelectCommand.Parameters.Add("datini", OracleType.DateTime).Value = Desde
        da.SelectCommand.Parameters.Add("datend", OracleType.DateTime).Value = Hasta
        dtRealAcumulado = New DataTable
        da.Fill(dtRealAcumulado)

    End Sub
    Private Function REAL(ByVal cce As String) As Double
        If cce = "Total de ventas sin iva" Then
            Return VentaAcumulada

        ElseIf cce = "Total" Then
            Return SumaReal

        Else
            Dim dv As New DataView(dtRealAcumulado)
            Dim suma As Double = 0.0

            dv.RowFilter = "cce_0 = '" & cce & "'"

            If dv.Count > 0 Then
                suma = CDbl(dv.Item(0).Row("suma"))
            End If

            suma = Math.Round(suma, 5)
            SumaReal = Math.Round(suma, 5) + SumaReal

            Return suma
        End If
    End Function
    Private Sub CargarEstructuraGeneral()
        Dim sql As String
        Dim da As OracleDataAdapter
        Dim dr As DataRow

        sql = "SELECT DISTINCT cce_0 AS cc, 0 AS ra, 0 AS rp, 0 AS pa, 0 AS pv "
        sql &= "FROM presuperm "
        If chkFormosa.Checked Then
            sql &= "WHERE usr_0 = :usr AND cce_0 = 'FORMOSA' "
        Else
            sql &= "WHERE usr_0 = :usr AND cce_0 <> 'FORMOSA' "
        End If
        sql &= "ORDER BY cce_0"

        da = New OracleDataAdapter(sql, cn)
        da.SelectCommand.Parameters.Add("usr", OracleType.VarChar).Value = usr.Codigo
        dtEstructura = New DataTable
        da.Fill(dtEstructura)

        If Not chkFormosa.Checked Then
            dr = dtEstructura.NewRow
            dr(0) = "Total de ventas sin iva"
            For i = 1 To 4
                dr(i) = 0
            Next
            dtEstructura.Rows.InsertAt(dr, 0)

            dr = dtEstructura.NewRow
            dr(0) = "Total"
            For i = 1 To 4
                dr(i) = 0
            Next
            dtEstructura.Rows.Add(dr)
        End If

        colCc.DataPropertyName = "cc"
        colRa.DataPropertyName = "ra"
        colPa.DataPropertyName = "pa"
        colRp.DataPropertyName = "rp"
        colPv.DataPropertyName = "pv"
        dgv.DataSource = dtEstructura

        For i As Integer = 0 To dgv.Columns.Count - 1
            Select Case i
                Case 1, 2, 3, 4
                    dgv.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    dgv.Columns(i).DefaultCellStyle.Format = "N2"
            End Select

            dgv.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            dgv.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
        Next

    End Sub
    Private Sub dgv_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellDoubleClick
        If e.RowIndex <= 0 Or e.RowIndex >= dgv.Rows.Count - 1 Then Exit Sub

        Dim f As New frmListadoPesos
        f.cboCce.SelectedValue = dgv.Rows(e.RowIndex).Cells(0).Value.ToString
        f.dtp.Value = Calendar.SelectionRange.End
        f.MdiParent = Me.ParentForm
        f.Show()
    End Sub
    Private Sub dgv_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgv.CellFormatting
        If dgv.Columns(e.ColumnIndex).Name = "colPv" Then
            Dim v As Double = CDbl(dgv.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)

            If e.RowIndex <> 0 OrElse dgv.Rows(e.RowIndex).Cells(0).Value.ToString = "FORMOSA" Then
                If v < 0 Then
                    e.CellStyle.ForeColor = Drawing.Color.Green
                ElseIf v > 0 Then
                    e.CellStyle.ForeColor = Drawing.Color.Red
                End If
            Else
                If v < 0 Then
                    e.CellStyle.ForeColor = Drawing.Color.Red
                ElseIf v > 0 Then
                    e.CellStyle.ForeColor = Drawing.Color.Green
                End If
            End If

        End If
    End Sub

End Class