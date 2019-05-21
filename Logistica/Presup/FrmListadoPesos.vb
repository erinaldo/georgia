Imports System.Data.OracleClient

Public Class frmListadoPesos
    Private Const TITULO_VTA As String = "Total de ventas sin iva"
    Private Const TITULO_TOTAL As String = "Total de Centro de costos"

    Private pa As New PresupuestoAnual(cn)
    Private dtPrincipal As New DataTable
    Private dtPorcentajes As DataTable
    Private VentaAcumulada As Double = 0
    Private dtRealAcumulado As DataTable
    Private dv As New DataView
    Private Desde As Date
    Private Hasta As Date

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Dim da As OracleDataAdapter
        Dim dt As New DataTable
        Dim Sql As String

        Sql = "SELECT DISTINCT cce_0 FROM presuperm WHERE usr_0 = :usr ORDER BY cce_0"
        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("usr", OracleType.VarChar).Value = usr.Codigo
        da.Fill(dt)

        cboCce.DataSource = dt
        cboCce.ValueMember = ("cce_0")
        cboCce.DisplayMember = ("cce_0")
    End Sub
    Private Sub frmListado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Sql As String
        Dim da As OracleDataAdapter
        Dim dr As DataRow

        Sql = "SELECT DISTINCT acc_0, des_0, 0 AS ra, 0 AS pa, 0 AS rva, 0 AS pv, 0 AS pr "
        Sql &= "FROM GACCOUNT "
        Sql &= "WHERE acc_0 >= '521001' AND acc_0 <= '525401' "
        Sql &= "ORDER BY acc_0"

        da = New OracleDataAdapter(Sql, cn)
        da.Fill(dtPrincipal)

        'Agrego título al comienzo para TOTAL DE VENTA
        dr = dtPrincipal.NewRow
        dr(0) = "0"
        dr(1) = TITULO_VTA
        For i = 2 To 6
            dr(i) = 0
        Next
        dtPrincipal.Rows.InsertAt(dr, 0)
        'Agrego título al final para TOTALES DE CENTRO DE COSTOS
        dr = dtPrincipal.NewRow
        dr(0) = "999999"
        dr(1) = TITULO_TOTAL
        For i = 2 To 6
            dr(i) = 0
        Next
        dtPrincipal.Rows.Add(dr)
        dtPrincipal.TableName = "Tabla1"

        dtPorcentajes = dtPrincipal.Clone
        dtPorcentajes.TableName = "Tabla2"

        dv = New DataView(dtPrincipal)
        OcultarFilas(True)

        'Enlace de la Tabla Principal con la Grilla
        colAcc.DataPropertyName = "acc_0"
        colDes.DataPropertyName = "des_0"
        colRa.DataPropertyName = "ra"
        colPa.DataPropertyName = "pa"
        colVra.DataPropertyName = "rva"
        colPv.DataPropertyName = "pv"
        colPr.DataPropertyName = "pr"
        dgv.DataSource = dv

        FormatearColumnas()

    End Sub
    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        If cboCce.SelectedValue Is Nothing Then
            MessageBox.Show("Debe elegir un centro de costos", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)

        ElseIf cboCce.SelectedValue.ToString = "FORMOSA" Then
            MessageBox.Show("Consulta no disponible para este centro de costo", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)

        Else

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

            Desde = New Date(dtp.Value.Year, 1, 1)
            Hasta = dtp.Value

            CalcularVentaAcumulada()

            CalcularRealAcumulado()
            pa.Abrir(Desde.Year)

            For Each dr As DataRow In dtPrincipal.Rows
                dr("ra") = RealAcumulado(dr("acc_0").ToString)
                dr("pa") = PresupuestoAcumulado(dr("acc_0").ToString)
                dr("rva") = CDbl(dr("ra")) - CDbl(dr("pa"))

                If CDbl(dr("pa")) > 0 Then
                    dr("pv") = CDbl(dr("rva")) / CDbl(dr("pa")) * 100
                Else
                    dr("pv") = 0
                End If

                If CInt(dr("acc_0")) = 0 Then

                    Select Case cboCce.SelectedValue.ToString
                        Case "DDVE", "667"
                            dr("pr") = pa.ObtenerValorAcumulado("TOT2", "411106", 12) - CDbl(dr("ra"))

                        Case Else
                            dr("pr") = pa.ObtenerValorAcumulado("TOT", "411106", 12) - CDbl(dr("ra"))

                    End Select

                Else
                    dr("pr") = PresupuestoAnual(dr("acc_0").ToString) - CDbl(dr("ra"))
                End If

                If CDbl(dr("pr")) < 0 Then dr("pr") = 0

            Next

            dtPorcentajes.Clear()
            Dim VentaReal As Double = 0
            Dim VentaPres As Double = 0
            For Each dr As DataRow In dtPrincipal.Rows
                Dim dr2 As DataRow

                dr2 = dtPorcentajes.NewRow
                For i = 0 To dtPrincipal.Columns.Count - 1
                    dr2(i) = dr(i)
                Next

                If dtPorcentajes.Rows.Count = 0 Then
                    VentaReal = CDbl(dr2("ra"))
                    VentaPres = CDbl(dr2("pa"))
                Else

                    dr2("ra") = CDbl(dr2("ra")) / VentaReal * 100
                    dr2("pa") = CDbl(dr2("pa")) / VentaPres * 100
                    dr2("rva") = CDbl(dr2("ra")) - CDbl(dr2("pa"))
                    If CDbl(dr("pa")) > 0 Then
                        dr2("pv") = CDbl(dr2("rva")) / CDbl(dr2("pa")) * 100
                    Else
                        dr2("pv") = 0
                    End If
                End If

                dtPorcentajes.Rows.Add(dr2)
            Next

            dgv.Columns(2).HeaderText = "Real Acumulado (" & Hasta.ToString("dd/MM/yy") & ")"

            Me.UseWaitCursor = False
            btnGenerar.Enabled = True
            lblBuscando.Visible = False

        End If
    End Sub
    Private Function PresupuestoAnual(ByVal cna As String) As Double
        Dim v As Double = 0

        Select Case cna
            Case "999999"
                v = pa.ObtenerValorAcumulado(cboCce.SelectedValue.ToString, 12)
                v = Math.Round(v, 5)

            Case Else
                v = pa.ObtenerValorAcumulado(cboCce.SelectedValue.ToString, cna, 12)
                v = Math.Round(v, 5)

        End Select

        Return v

    End Function
    Private Function PresupuestoAcumulado(ByVal cna As String) As Double
        Dim v As Double = 0

        Select Case cna
            Case "0"
                If cboCce.SelectedValue.ToString <> "DDVE" Then
                    v = pa.ObtenerValorAcumulado("TOT", "411106", Hasta.Month)
                Else
                    v = pa.ObtenerValorAcumulado("TOT2", "411106", Hasta.Month)
                End If


            Case "999999"
                v = pa.ObtenerValorAcumulado(cboCce.SelectedValue.ToString, Hasta.Month)
                v = Math.Round(v, 5)

            Case Else
                v = pa.ObtenerValorAcumulado(cboCce.SelectedValue.ToString, cna, Hasta.Month)
                v = Math.Round(v, 5)

        End Select

        Return v

    End Function
    Private Function RealAcumulado(ByVal cna As String) As Double

        If cna = "0" Then
            Return VentaAcumulada

        ElseIf cna = "999999" Then
            Dim Suma As Double = 0

            For Each dr As DataRow In dtRealAcumulado.Rows
                Suma += CDbl(dr("suma"))
            Next

            Return Math.Round(Suma, 5)

        Else
            Dim dv As New DataView(dtRealAcumulado)
            Dim v As Double = 0

            dv.RowFilter = "cna_0 = '" & cna.ToString & "'"

            If dv.Count > 0 Then
                v = CDbl(dv.Item(0).Row("suma"))
            End If

            Return v
        End If

    End Function
    Private Sub CalcularVentaAcumulada()
        Dim da As OracleDataAdapter
        Dim dr As DataRow
        Dim sql As String
        Dim dt As New DataTable

        sql = "select sum(sns_0 * sid.amtnotlin_0 * ratcur_0) as total "
        sql &= "from sinvoice sih inner join "
        sql &= "     sinvoiced sid on (sih.num_0 = sid.num_0) inner join "
        sql &= "     itmmaster itm on (sid.itmref_0 = itm.itmref_0) "
        sql &= "where sih.accdat_0 >= :datini and "
        sql &= "      sih.accdat_0 <= :datend and "
        sql &= "      sih.sivtyp_0 <> 'PRF'  and "
        sql &= "      sid.itmref_0 not in ('900068', '900069', '900071', '900097')"

        If cboCce.SelectedValue.ToString = "DDVE" Then sql &= " AND itm.tsicod_3 = '304'"

        da = New OracleDataAdapter(sql, cn)
        da.SelectCommand.Parameters.Add("datini", OracleType.DateTime).Value = Desde
        da.SelectCommand.Parameters.Add("datend", OracleType.DateTime).Value = Hasta
        da.Fill(dt)
        dr = dt.Rows(0)

        VentaAcumulada = CDbl(dr("total"))
        VentaAcumulada = Math.Abs(VentaAcumulada)

    End Sub
    Private Sub dgv_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellDoubleClick
        For pos As Integer = 0 To dgv.RowCount - 1
            If Me.dgv.Rows(pos).Visible = True Then
                If CInt(dgv.Rows(pos).Cells(0).Value) > 0 Then
                    If CInt(dgv.Rows(pos).Cells(0).Value) < 999999 Then
                        Me.dgv.CurrentCell = Nothing
                        Me.dgv.Rows(pos).Visible = False
                    End If
                End If
            Else
                If CInt(dgv.Rows(pos).Cells(0).Value) > 0 Then
                    If CInt(dgv.Rows(pos).Cells(0).Value) < 999999 Then
                        Me.dgv.CurrentCell = Nothing
                        Me.dgv.Rows(pos).Visible = True
                    End If
                End If
            End If
        Next

    End Sub
    Private Sub dgv_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgv.CellFormatting
        Select Case dgv.Rows(e.RowIndex).Cells(0).Value.ToString
            Case "522401", "521302", "521305", "521301", "521303", "521304", "521309", "521201", "521307", "521308", "522405"
                e.CellStyle.BackColor = Drawing.Color.LightYellow
                dgv.Rows(e.RowIndex).Cells(e.ColumnIndex).ToolTipText = "Centro por distribución"
        End Select


        If dgv.Columns(e.ColumnIndex).Name = "colPv" Then
            Dim v As Double = CDbl(dgv.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)

            If v < 0 Then
                If e.RowIndex = 0 Then
                    e.CellStyle.ForeColor = Drawing.Color.Red
                Else
                    e.CellStyle.ForeColor = Drawing.Color.Green
                End If

            ElseIf v > 0 Then
                If e.RowIndex = 0 Then
                    e.CellStyle.ForeColor = Drawing.Color.Green
                Else
                    e.CellStyle.ForeColor = Drawing.Color.Red
                End If
            End If
        End If
    End Sub
    Private Sub CalcularRealAcumulado()
        Dim da As OracleDataAdapter
        Dim sql As String

        sql = "select gaa.cna_0, sum(gaa.amtloc_0 * sns_0) as suma "
        sql &= "from gaccentrya GAA INNER JOIN gaccentryd gad on (gaa.num_0 = gad.num_0 and gaa.lig_0 = gad.lig_0) "
        sql &= "where  cce_0 = :cce and "
        sql &= "       gaa.accdat_0 >= :datini and "
        sql &= "       gaa.accdat_0 <= :datend and "
        sql &= "       gaa.cna_0 not in ('511102','611101','612202','114205','622002','612204', '611201') "
        sql &= "group by gaa.cna_0"

        da = New OracleDataAdapter(sql, cn)
        da.SelectCommand.Parameters.Add("cce", OracleType.VarChar).Value = cboCce.SelectedValue.ToString
        da.SelectCommand.Parameters.Add("datini", OracleType.DateTime).Value = Desde
        da.SelectCommand.Parameters.Add("datend", OracleType.DateTime).Value = Hasta
        dtRealAcumulado = New DataTable
        da.Fill(dtRealAcumulado)

    End Sub
    Private Function ObtenerRealAcumulado() As Double
        Dim v As Double = 0

        For Each dr As DataRow In dtRealAcumulado.Rows
            v += CDbl(dr(1))
        Next

        Return v
    End Function
    Private Function ObtenerRealAcumulado(ByVal cna As String) As Double
        Dim v As Double = 0
        Dim dv As New DataView(dtRealAcumulado)

        dv.RowFilter = "cna_0 = '" & cna & "'"

        If dv.Count > 0 Then v = CDbl(dv.Item(0).Row(1))

        Return v
    End Function
    Private Sub chkOcultar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkOcultar.CheckedChanged
        OcultarFilas(chkOcultar.Checked)
    End Sub
    Private Sub OcultarFilas(ByVal flg As Boolean)
        Dim f As String = ""

        If flg Then
            f = "ra <> 0 OR  pa <> 0 OR rva <> 0 OR pv <> 0 OR  pr <> 0"
        End If

        dv.RowFilter = f

    End Sub
    Private Sub FormatearColumnas()
        For i = 0 To dgv.Columns.Count - 1
            With dgv.Columns(i)
                Select Case i
                    Case 0
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    Case 1
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

                    Case Else
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

                        If chkPorc.Checked And i <= 4 Then
                            .DefaultCellStyle.Format = "N4"
                        Else
                            .DefaultCellStyle.Format = "N2"
                        End If
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End Select
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
        Next
    End Sub
    Private Sub chkPorc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPorc.CheckedChanged
        If chkPorc.Checked Then
            dv.Table = dtPorcentajes

        Else
            dv.Table = dtPrincipal

        End If
        OcultarFilas(chkOcultar.Checked)
        FormatearColumnas()
    End Sub

End Class