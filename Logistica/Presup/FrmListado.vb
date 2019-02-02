Imports System.Data.OracleClient

Public Class FrmListado
    Dim mes As Integer
    Dim pa As New PresupuestoAnual(cn)

    Private Sub FrmListado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CmboboxCCostos.DataSource = cc()
        CmboboxCCostos.ValueMember = ("cce_0")
        CmboboxCCostos.DisplayMember = ("cce_0")
        CmboboxCCostos.SelectedValue = 0
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        If CmboboxCCostos.SelectedValue Is Nothing Then
            MsgBox("Debe elegir un centro de costos")
            Exit Sub
        Else
            Me.UseWaitCursor = True
            Application.DoEvents()
            btnGenerar.Enabled = False
           
            Dim dt As New DataTable
            Dim dt1 As New DataTable
            mes = (CInt(dtp.Value.Month) - 1)
            Dim ano As Integer = (CInt(dtp.Value.Year))
            dt = cuentas()
            dt1 = real1(New Date(dtp.Value.Year, 1, 1), dtp.Value, CmboboxCCostos.SelectedValue.ToString)
            Dim venta As Double = Math.Abs(venta_acumulada(New Date(dtp.Value.Year, 1, 1), dtp.Value))
            Dim dr As DataRow = dt.Rows(0)
            For Each dr In dt.Rows
                dr("Real_acumulado") = porce1(dt1, dr("numero").ToString, venta)
                dr("Presupuesto_acumulado") = IIf(dr("numero").ToString = "0", venta_presupuesto(ano), total1(dr("numero").ToString, ano))
                dr("Variación_Real_vs_Presupuesto") = Variacion(dt1, dr("numero").ToString, venta, ano)
                dr("Porcentaje_Variacion") = porcentaje(dt1, dr("numero").ToString, venta, ano)
                dr("Presupuesto_Restante") = IIf(dr("numero").ToString = "0", "$ " & FormatNumber((CDbl(venta_presupuesto(ano)) - venta).ToString, 2), "$ " & presupuesto_total(dr("numero").ToString, ano))
            Next
            vincular(dt)
            Me.UseWaitCursor = False
            btnGenerar.Enabled = True

        End If
    End Sub
    Private Sub vincular(ByVal datos As DataTable)
        dgv.DataSource = datos
        dgv.AutoResizeColumns()
    End Sub
    Private Function total(ByVal cna As String, ByVal ano As Integer) As String
        Dim a As String = "0.0"
        Dim b As String = "0.0"
        Dim c As String
        If pa.Abrir(CmboboxCCostos.SelectedValue.ToString, CInt(cna), ano) Then
            Dim suma As Double = 0.0
            For x As Integer = 0 To mes
                suma = pa.valor_mes(x) + suma
                a = suma.ToString
            Next
        Else
            a = "0"
        End If
        If a = "0" Then a = "-"
        If CmboboxCCostos.SelectedValue.ToString = "DDVE" Then
            pa.Abrir(CmboboxCCostos.SelectedValue.ToString, 411106, ano)
            Dim suma As Double = 0.0
            For x As Integer = 0 To mes
                suma = pa.valor_mes(x) + suma
                b = suma.ToString
            Next
        Else
            pa.Abrir("TOT", 411106, ano)
            Dim suma As Double = 0.0
            For x As Integer = 0 To mes
                suma = pa.valor_mes(x) + suma
                b = suma.ToString
            Next
        End If
        If a = "-" Or b = "-" Then Return "-"
        c = ((Math.Round((CDbl(a) / CDbl(b)), 5)) * 100).ToString("N3")

        Return "%" & FormatNumber(c, 3)

    End Function
    Private Function total1(ByVal cna As String, ByVal ano As Integer) As String
        If cna = "999999" Then
            Dim a As String = "0.0"
            Dim b As String = "0.0"
            Dim c As String
            If pa.Abrir(CmboboxCCostos.SelectedValue.ToString, ano) Then
                Dim suma As Double = 0.0
                For x As Integer = 0 To mes
                    suma = pa.valor_mes_suma(x) + suma
                    a = suma.ToString
                Next
            Else
                a = "0"
            End If
         
            c = ((Math.Round((CDbl(a)), 5))).ToString("N2")

            Return "$ " & c
        Else
            Dim a As String = "0.0"
            Dim b As String = "0.0"
            Dim c As String
            If pa.Abrir(CmboboxCCostos.SelectedValue.ToString, CInt(cna), ano) Then
                Dim suma As Double = 0.0
                For x As Integer = 0 To mes
                    suma = pa.valor_mes(x) + suma
                    a = suma.ToString
                Next
            Else
                a = "0"
            End If
            pa.Abrir("TOT", 411106, ano)
            Dim suma1 As Double = 0.0
            For z As Integer = 0 To mes
                suma1 = pa.valor_mes(z) + suma1
            Next
            ' Return "$ " & FormatNumber(suma.ToString, 2)

            If a = "0" Then a = "-"
            If a = "-" Then Return "-"
            c = (((Math.Round((CDbl(a)), 5)) / suma1) * 100).ToString("N3")

            Return "% " & c
        End If
    End Function
    Private Function cuentas() As DataTable
        Dim sql As String
        Dim da As OracleDataAdapter
        Dim dt As New DataTable
        
        sql = "select '0' as numero, 'Total de ventas sin iva' as descripcion, '' as Real_acumulado,'' as Presupuesto_acumulado, ''  as Variación_Real_vs_Presupuesto, '' as Porcentaje_Variacion  , ' ' as Presupuesto_Restante from dual"
        sql &= " union all "
        sql &= " select distinct acc_0 as numero,des_0 as descripcion, ' ' as Real_acumulado, ' ' as Presupuesto_acumulado, ''  as Variación_Real_vs_Presupuesto, '' as Porcentaje_Variacion ,' ' as Presupuesto_Restante from GACCOUNT where (acc_0 >= 521001 and acc_0 <= 525401)" ' order by numero asc"
        sql &= " union all "
        sql &= "select '999999' as numero, 'Total de Centro de costos' as descripcion, '' as Real_acumulado,'' as Presupuesto_acumulado, ''  as Variacion_Real_vs_Presupuesto , '' as Porcentaje_Variacion, ' ' as Presupuesto_Restante from dual order by numero asc"
        da = New OracleDataAdapter(sql, cn)
        da.Fill(dt)
        Return dt
    End Function
    Private Function cc() As DataTable
        Dim da As OracleDataAdapter
        Dim dt As New DataTable
        Dim sql As String = "select distinct cce_0 from presupuest where cce_0 <> 'TOT' "
        da = New OracleDataAdapter(sql, cn)
        da.Fill(dt)
        Return dt
    End Function
    Private Function venta_presupuesto(ByVal ano As Integer) As String
       
        pa.Abrir("TOT", 411106, ano)
        Dim suma As Double = 0.0
        For z As Integer = 0 To mes
            suma = pa.valor_mes(z) + suma
        Next
        Return "$ " & FormatNumber(suma.ToString, 2)
    End Function
    Private Function porce(ByVal datos As DataTable, ByVal cna As String, ByVal vent As Double) As String
        If cna = "0" Then
            Return "$" & FormatNumber(vent.ToString, 2)
           
        Else
            Dim dv As New DataView(datos)
            Dim division As Double
            dv.RowFilter = "cna_0 =" & cna.ToString
            If dv.Count > 0 Then
                division = (Math.Round((CDbl(dv.Item(0).Item(1)) / vent), 5) * 100)
                If division = 0 Then Return "-"
                Return "%" & division.ToString("N3")
            Else
                Return "-"
            End If
        End If

    End Function
    Private Function porce1(ByVal datos As DataTable, ByVal cna As String, ByVal vent As Double) As String
        If cna = "0" Then
            Return "$ " & FormatNumber(vent.ToString, 2)
        ElseIf cna = "999999" Then
            If datos.Rows.Count = 0 Then Return "-"
            Dim dr As DataRow = datos.Rows(0)
            Dim suma As Double = 0.0
            For Each dr In datos.Rows
                suma += CDbl(dr("suma"))
            Next
            suma = Math.Round(suma, 5)
            Return "$ " & suma.ToString("N2")
        Else
                Dim dv As New DataView(datos)
                Dim division As Double
                dv.RowFilter = "cna_0 =" & cna.ToString
                If dv.Count > 0 Then
                division = ((Math.Round((CDbl(dv.Item(0).Item(1))), 5) / vent)) * 100
                    If division = 0 Then Return "-"
                Return "% " & division.ToString("N3")
                Else
                    Return "-"
                End If
        End If

    End Function
    Private Function presupuesto_total(ByVal cna As String, ByVal ano As Integer) As String
        Dim c As Double
        Dim d As Double
        Dim dr As DataRow
        If pa.Abrir(CmboboxCCostos.SelectedValue.ToString, CInt(cna), ano) Then
            Dim suma As Double = 0.0
            For x As Integer = 0 To 11
                Dim a As Double = pa.valor_mes(x)
                suma = pa.valor_mes(x) + suma
                c = suma
            Next
        Else
            Return "-"
        End If

        Dim suma1 As Double = 0.0
        Dim dt As DataTable
        dt = real(New Date(dtp.Value.Year, 1, 1), dtp.Value, CmboboxCCostos.SelectedValue.ToString, cna)
        dr = dt.Rows(0)
        If dr("suma") Is DBNull.Value Then

        Else
            'dr = dt.Rows(0)
            If dt.Rows.Count = 1 Then
                d = CDbl(dr("suma"))
            End If
        End If

        If c = 0.0 And d = 0.0 Then
            Return "-"
        ElseIf c = 0.0 Then
            Return "-"
        ElseIf d = 0.0 Then
            Return FormatNumber((c).ToString, 2)
        End If
        If (c - d) < 0 Then Return "-"
        Return FormatNumber((c - d).ToString, 2)

    End Function
    Private Function real(ByVal diaini As Date, ByVal diafin As Date, ByVal cce As String, ByVal cna As String) As DataTable
        Dim da As OracleDataAdapter
        Dim dt As New DataTable
        Dim sql As String
        'sql = " select cna_0,sum(amtloc_0)as suma "
        'sql &= " from gaccentrya where cce_0 = :cce and (accdat_0 >= :datini and accdat_0 <= :datend) and cna_0 = :cna group by cna_0"
        sql = "select sum(gaa.amtloc_0 * sns_0) as suma from gaccentrya GAA "
        sql &= "INNER JOIN gaccentryd gad on (gaa.num_0 = gad.num_0 and gaa.lig_0 = gad.lig_0)"
        sql &= "where gaa.cna_0 = :cna and cce_0 = :cce and (gaa.accdat_0 >= :datini and gaa.accdat_0 <= :datend) and gaa.cna_0 not in ('511102','611101','612202','114205','622002','612204')"
        da = New OracleDataAdapter(sql, cn)
        da.SelectCommand.Parameters.Add("datini", OracleType.DateTime).Value = diaini
        da.SelectCommand.Parameters.Add("datend", OracleType.DateTime).Value = diafin
        da.SelectCommand.Parameters.Add("cna", OracleType.VarChar).Value = cna
        da.SelectCommand.Parameters.Add("cce", OracleType.VarChar).Value = cce
        da.Fill(dt)
        Return dt
    End Function
    Private Function real1(ByVal diaini As Date, ByVal diafin As Date, ByVal cce As String) As DataTable
        Dim da As OracleDataAdapter
        Dim dt As New DataTable
        Dim sql As String
        'sql = " select cna_0,sum(amtloc_0)as suma "
        'sql &= " from gaccentrya where cce_0 = :cce and (accdat_0 >= :datini and accdat_0 <= :datend) and cna_0 not in ('114205','622002','612204') group by cna_0"
        sql = "select gaa.cna_0 ,sum(gaa.amtloc_0 * sns_0) as suma from gaccentrya GAA "
        sql &= "INNER JOIN gaccentryd gad on (gaa.num_0 = gad.num_0 and gaa.lig_0 = gad.lig_0) "
        sql &= "where  cce_0 = :cce and (gaa.accdat_0 >= :datini and gaa.accdat_0 <= :datend) and gaa.cna_0 not in ('511102','611101','612202','114205','622002','612204') group by gaa.cna_0 "

        da = New OracleDataAdapter(sql, cn)
        da.SelectCommand.Parameters.Add("datini", OracleType.DateTime).Value = diaini
        da.SelectCommand.Parameters.Add("datend", OracleType.DateTime).Value = diafin
        da.SelectCommand.Parameters.Add("cce", OracleType.VarChar).Value = cce
        da.Fill(dt)
        Return dt
    End Function
    Private Function venta_acumulada(ByVal diaini As Date, ByVal diafin As Date) As Double
        Dim da As OracleDataAdapter
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim sql As String
        Dim total As Double
        sql = "(select abs(sum(amtloc_0 * sns_0)) as total from gaccentryd where (accdat_0 >= :datini and accdat_0 <= :datend) and cna_0 = '411106' )"
        da = New OracleDataAdapter(sql, cn)
        da.SelectCommand.Parameters.Add("datini", OracleType.DateTime).Value = diaini
        da.SelectCommand.Parameters.Add("datend", OracleType.DateTime).Value = diafin
        da.Fill(dt)
        dr = dt.Rows(0)
        total = CDbl(dr("total"))
        Return total
    End Function
    Private Function porcentaje(ByVal datos As DataTable, ByVal cna As String, ByVal vent As Double, ByVal ano As Integer) As String
        ' Dim a As Double = 0.0

        If cna = "0" Then
            Dim porcen As Double
            Dim b As Double = 0.0
            If CmboboxCCostos.SelectedValue.ToString = "DDVE" Then
                pa.Abrir(CmboboxCCostos.SelectedValue.ToString, 411106, ano)
                Dim suma As Double = 0.0
                For z As Integer = 0 To mes
                    suma = pa.valor_mes(z) + suma
                Next
                b = suma

            Else
                pa.Abrir("TOT", 411106, ano)
                Dim suma As Double = 0.0
                For z As Integer = 0 To mes
                    suma = pa.valor_mes(z) + suma
                Next
                b = suma

            End If
            porcen = ((vent / b) - 1) * 100

            Return "%" & porcen.ToString("N2")

        ElseIf cna = "999999" Then
            If datos.Rows.Count = 0 Then Return "-"
            Dim dr As DataRow = datos.Rows(0)
            Dim suma1 As Double = 0.0
            For Each dr In datos.Rows
                suma1 += CDbl(dr("suma"))
            Next
            suma1 = Math.Round(suma1, 5)


            Dim a1 As String = "0.0"
            Dim b As String = "0.0"
            Dim c As String
            If pa.Abrir(CmboboxCCostos.SelectedValue.ToString, ano) Then
                Dim suma As Double = 0.0
                For x As Integer = 0 To mes
                    suma = pa.valor_mes_suma(x) + suma
                    a1 = suma.ToString
                Next
            Else
                a1 = "0"
            End If
          
            c = (((suma1 / (Math.Round((CDbl(a1)), 5))) - 1) * 100).ToString("N2")

            Return "% " & c
        Else
            '    If pa.Abrir(CmboboxCCostos.SelectedValue.ToString, CInt(cna), ano) Then
            '        Dim suma As Double = 0.0
            '        For x As Integer = 0 To mes
            '            suma = pa.valor_mes(x) + suma
            '            a = suma
            '        Next
            '    Else
            '        Return "-"
            '    End If
            'End If
            'Dim dv As New DataView(datos)
            'Dim division As Double
            'dv.RowFilter = "cna_0 =" & cna.ToString
            'If dv.Count > 0 Then
            '    division = ((Math.Round((CDbl(dv.Item(0).Item(1)) / a), 5) - 1) * 100)
            '    If division = 0 Or a = 0.0 Then Return "-"
            '    Return "%" & division.ToString("N2")
            'Else
            '    Return "-"
            Dim dv As New DataView(datos)
            Dim division As Double
            dv.RowFilter = "cna_0 =" & cna.ToString
            If dv.Count > 0 Then
                division = ((Math.Round((CDbl(dv.Item(0).Item(1))), 5) / vent)) * 100
            Else
                division = 0.0
            End If
            Dim a As String = "0.0"
            Dim b As String = "0.0"
            Dim c As Double = 0.0
            If pa.Abrir(CmboboxCCostos.SelectedValue.ToString, CInt(cna), ano) Then
                Dim suma As Double = 0.0
                For x As Integer = 0 To mes
                    suma = pa.valor_mes(x) + suma
                    a = suma.ToString
                Next
            Else
                a = "0"
            End If
            pa.Abrir("TOT", 411106, ano)
            Dim suma1 As Double = 0.0
            For z As Integer = 0 To mes
                suma1 = pa.valor_mes(z) + suma1
            Next
            ' Return "$ " & FormatNumber(suma.ToString, 2)
            'If a = "0" Then a = "-"
            'If a = "-" Then Return "-"
            c = (((Math.Round((CDbl(a)), 5)) / suma1)) * 100


            If division = 0.0 And c <> 0.0 Then Return "% -100" ' & ((c - 1) * 100).ToString("N3")
            If division <> 0.0 And c = 0.0 Then Return "% 0 " '& ((division - 1) * 100).ToString("N3")
            If c = 0.0 And division = 0.0 Then Return "-"
            c = ((division / c) - 1) * 100
            Return "% " & c.ToString("N3")

        End If

    End Function
    Private Function Variacion(ByVal datos As DataTable, ByVal cna As String, ByVal vent As Double, ByVal ano As Integer) As String
        If cna = "0" Then
            Dim porcen2 As Double
            Dim b1 As Double = 0.0

            pa.Abrir("TOT", 411106, ano)
            Dim suma As Double = 0.0
            For z As Integer = 0 To mes
                suma = pa.valor_mes(z) + suma
            Next
            b1 = suma
            porcen2 = (vent - b1)
            Return "$ " & porcen2.ToString("N2")

        ElseIf cna = "999999" Then

            Dim a1 As String = "0.0"
            'Dim b2 As String = "0.0"
            Dim c As String
            If pa.Abrir(CmboboxCCostos.SelectedValue.ToString, ano) Then
                Dim suma As Double = 0.0
                For x As Integer = 0 To mes
                    suma = pa.valor_mes_suma(x) + suma
                    a1 = suma.ToString
                Next
            Else
                a1 = "0"
            End If
            If datos.Rows.Count = 0 Then
                c = "-" & (((Math.Round((CDbl(a1)), 5)))).ToString("N2")
            Else
                Dim dr As DataRow = datos.Rows(0)
                Dim suma2 As Double = 0.0
                For Each dr In datos.Rows
                    suma2 += CDbl(dr("suma"))
                Next
                suma2 = Math.Round(suma2, 5)

                c = ((suma2 - (Math.Round((CDbl(a1)), 5)))).ToString("N2")
            End If

            Return "$ " & c

        Else
            Dim dv As New DataView(datos)
            Dim division As Double
            dv.RowFilter = "cna_0 =" & cna.ToString
            If dv.Count > 0 Then
                division = ((Math.Round((CDbl(dv.Item(0).Item(1))), 5) / vent)) * 100
            Else
                division = 0.0
            End If

            Dim a As String = "0.0"
            Dim b As String = "0.0"
            Dim c As Double = 0.0
            If pa.Abrir(CmboboxCCostos.SelectedValue.ToString, CInt(cna), ano) Then
                Dim suma As Double = 0.0
                For x As Integer = 0 To mes
                    suma = pa.valor_mes(x) + suma
                    a = suma.ToString
                Next
            Else
                a = "0"
            End If
            pa.Abrir("TOT", 411106, ano)
            Dim suma1 As Double = 0.0
            For z As Integer = 0 To mes
                suma1 = pa.valor_mes(z) + suma1
            Next
            ' Return "$ " & FormatNumber(suma.ToString, 2)

            'If a = "0" Then a = "-"
            'If a = "-" Then Return "-"
            c = (((Math.Round((CDbl(a)), 5)) / suma1) * 100)

            If division = 0.0 And c <> 0.0 Then Return "% -" & c.ToString("N3")
            If division <> 0.0 And c = 0.0 Then Return "% " & division.ToString("N3")
            If c = 0.0 And division = 0.0 Then Return "-"
            c = (division - c)
            Return "% " & c.ToString("N3")

        End If

    End Function

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

        Me.dgv.Columns("Real_acumulado").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.dgv.Columns("Presupuesto_acumulado").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.dgv.Columns("Variación_Real_vs_Presupuesto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.dgv.Columns("Porcentaje_Variacion").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.dgv.Columns("Presupuesto_Restante").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        Select Case CInt(dgv.Rows(e.RowIndex).Cells(0).Value)
            Case 522401
                e.CellStyle.BackColor = Drawing.Color.LightPink
            Case 521302
                e.CellStyle.BackColor = Drawing.Color.LightPink
            Case 521305
                e.CellStyle.BackColor = Drawing.Color.LightPink
            Case 521301
                e.CellStyle.BackColor = Drawing.Color.LightPink
            Case 521303
                e.CellStyle.BackColor = Drawing.Color.LightPink
            Case 521304
                e.CellStyle.BackColor = Drawing.Color.LightPink
            Case 521309
                e.CellStyle.BackColor = Drawing.Color.LightPink
            Case 521201
                e.CellStyle.BackColor = Drawing.Color.LightPink
            Case 521307
                e.CellStyle.BackColor = Drawing.Color.LightPink
            Case 521308
                e.CellStyle.BackColor = Drawing.Color.LightPink
            Case 522405
                e.CellStyle.BackColor = Drawing.Color.LightPink
        End Select
    End Sub

End Class
