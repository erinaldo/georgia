Imports System.Data.OracleClient
Imports System.IO

Public Class FrmPresupu
    Dim dr As DataRow
    Dim dr1 As DataRow
    Dim mes As Integer
    Dim pa As New PresupuestoAnual(cn)
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.UseWaitCursor = True

        OpenFileDialog1.Filter = "Documentos de texto (*.txt*)|*.txt"

        If OpenFileDialog1.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub

        Try
            FrmPresupu.Importar(cn, OpenFileDialog1.FileName, CInt(nudAno.Value))
            MessageBox.Show("OK", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            'CargarPrecios()

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)

        End Try

        Me.UseWaitCursor = False

    End Sub
    Shared Sub Importar(ByVal cn As OracleConnection, ByVal Archivo As String, ByVal ano As Integer)
        Dim Sql As String
        Dim da As OracleDataAdapter
        Dim dt As DataTable
        Dim dr As DataRow
        Dim sr As StreamReader
        Dim linea As String
        Dim c() As String
        Dim l As Integer = 0
        Dim itm As New Articulo(cn)

        'Sql = "SELECT * FROM presupuest"
        Sql = "SELECT * FROM presupuest where extract(year  from dat_0) = :ano"
        da = New OracleDataAdapter(Sql, cn)
        da.InsertCommand = New OracleCommandBuilder(da).GetInsertCommand
        da.DeleteCommand = New OracleCommandBuilder(da).GetDeleteCommand
        da.SelectCommand.Parameters.Add("ano", OracleType.Number).Value = ano
        dt = New DataTable
        da.Fill(dt)

        sr = New StreamReader(Archivo)

        'Elimino todos los registros
        For Each dr In dt.Rows
            dr.Delete()
        Next

        'Agrego los nuevos registros
        Do Until sr.EndOfStream
            l += 1 'numero de linea del txt

            linea = sr.ReadLine
            c = Split(linea, vbTab)
            ' MsgBox(c.GetUpperBound(0))
            If c.GetUpperBound(0) <> 15 Then Continue Do
            'Chequeo si existe el articulo
            ' If Not itm.Abrir(c(0)) Then Continue Do

            dr = dt.NewRow
            dr("acc_0") = c(0)
            dr("cce_0") = c(1)
            dr("dat_0") = CDate(c(2))
            dr("mes_0") = CDbl(c(3).Replace(".", "").Replace(",", "."))
            dr("mes_1") = CDbl(c(4).Replace(".", "").Replace(",", "."))
            dr("mes_2") = CDbl(c(5).Replace(".", "").Replace(",", "."))
            dr("mes_3") = CDbl(c(6).Replace(".", "").Replace(",", "."))
            dr("mes_4") = CDbl(c(7).Replace(".", "").Replace(",", "."))
            dr("mes_5") = CDbl(c(8).Replace(".", "").Replace(",", "."))
            dr("mes_6") = CDbl(c(9).Replace(".", "").Replace(",", "."))
            dr("mes_7") = CDbl(c(10).Replace(".", "").Replace(",", "."))
            dr("mes_8") = CDbl(c(11).Replace(".", "").Replace(",", "."))
            dr("mes_9") = CDbl(c(12).Replace(".", "").Replace(",", "."))
            dr("mes_10") = CDbl(c(13).Replace(".", "").Replace(",", "."))
            dr("mes_11") = CDbl(c(14).Replace(".", "").Replace(",", "."))
            dt.Rows.Add(dr)
        Loop
        Try
            da.Update(dt)
        Catch ex As Exception
            MsgBox(ex)
        End Try

    End Sub
    Private Sub Presupu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CmboboxCContable.DataSource = cuenta()
        CmboboxCContable.ValueMember = ("acc_0")
        CmboboxCContable.DisplayMember = ("des")
        CmboboxCContable.SelectedValue = 0

        CmboboxCCostos.DataSource = cc()
        CmboboxCCostos.ValueMember = ("cce_0")
        CmboboxCCostos.DisplayMember = ("cce_0")
        CmboboxCCostos.SelectedValue = 0
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If CmboboxCCostos.SelectedValue Is Nothing Then
            MsgBox("Debe elegir un centro de costos")
            Exit Sub
        ElseIf CmboboxCContable.SelectedValue Is Nothing Then
            MsgBox("Debe elegir una Cuenta")
            Exit Sub
        Else
            Dim ano As Integer = CInt(dtp.Value.Year)
            mes = (CInt(dtp.Value.Month) - 1)
            presupuesto(ano)
            real()
            Acumulado_Presupuesto(ano)
            Acumulado_Real()
            presupuesto_total(ano)
            If Label14.Text = "0" Then
                Label29.Text = "0"
            Else
                Label29.Text = (IIf((CDbl(Label28.Text) - (CDbl(Label18.Text))) > 0, (((CDbl(Label28.Text) - (CDbl(Label18.Text))))), "0")).ToString
            End If
        End If
    End Sub
    Private Function cc() As DataTable
        Dim da As OracleDataAdapter
        Dim dt As New DataTable
        Dim sql As String = "select distinct cce_0 from presupuest "
        da = New OracleDataAdapter(sql, cn)
        da.Fill(dt)
        Return dt
    End Function
    Private Function cuenta() As DataTable
        Dim da As OracleDataAdapter
        Dim dt As New DataTable
        Dim sql As String = "select distinct acc_0,acc_0 || ' - ' || des_0 as des from GACCOUNT where (acc_0 >= 521001 and acc_0 <= 525401) order by acc_0 asc"
        da = New OracleDataAdapter(sql, cn)
        da.Fill(dt)
        Return dt
    End Function
    Private Function real(ByVal diaini As Date, ByVal diafin As Date, ByVal cna As String, ByVal cce As String) As DataTable
        Dim da As OracleDataAdapter
        Dim dt As New DataTable
        Dim sql As String
        'sql = "select sum(amtloc_0) as suma from gaccentrya where cna_0 = :cna and cce_0 = :cce and (accdat_0 >= :datini and accdat_0 <= :datend)"
        sql = "select sum(gaa.amtloc_0 * sns_0) as suma from gaccentrya GAA "
        sql &= "INNER JOIN gaccentryd gad on (gaa.num_0 = gad.num_0 and gaa.lig_0 = gad.lig_0) "
        sql &= "where gaa.cna_0 = :cna and cce_0 = :cce and (gaa.accdat_0 >= :datini and gaa.accdat_0 <= :datend) and gaa.cna_0 not in ('511102','611101','612202','114205','622002','612204')"

        da = New OracleDataAdapter(sql, cn)
        da.SelectCommand.Parameters.Add("datini", OracleType.DateTime).Value = diaini
        da.SelectCommand.Parameters.Add("datend", OracleType.DateTime).Value = diafin
        da.SelectCommand.Parameters.Add("cna", OracleType.VarChar).Value = cna
        da.SelectCommand.Parameters.Add("cce", OracleType.VarChar).Value = cce
        da.Fill(dt)
        Return dt
    End Function
    Private Function venta_real(ByVal diaini As Date, ByVal diafin As Date, ByVal cna As String, ByVal sis As Integer) As DataTable
        Dim da As OracleDataAdapter
        Dim dt As New DataTable
        Dim sql As String
        'sql = "select sum(amtloc_0) as suma from gaccentrya where cna_0 = :cna  and (accdat_0 >= :datini and accdat_0 <= :datend) AND cce_1"
        'If sis = 1 Then
        '    sql &= " <> 'SISTFIJOS'"
        'ElseIf sis = 2 Then
        '    sql &= " = 'SISTFIJOS'"
        'End If
        sql = "select sum(amtloc_0 * sns_0) as suma from gaccentryd where (accdat_0 >= :datini and accdat_0 <= :datend) and cna_0 = :cna"

        da = New OracleDataAdapter(sql, cn)
        da.SelectCommand.Parameters.Add("datini", OracleType.DateTime).Value = diaini
        da.SelectCommand.Parameters.Add("datend", OracleType.DateTime).Value = diafin
        da.SelectCommand.Parameters.Add("cna", OracleType.VarChar).Value = cna
        da.Fill(dt)
        Return dt
    End Function
    Private Function Amt() As String
        Dim num = ""
        Select Case mes + 1
            Case 1
                num = "8"
            Case 2
                num = "9"
            Case 3
                num = "10"
            Case 4
                num = "11"
            Case 5
                num = "12"
            Case 6
                num = "1"
            Case 7
                num = "2"
            Case 8
                num = "3"
            Case 9
                num = "4"
            Case 10
                num = "5"
            Case 11
                num = "6"
            Case 12
                num = "7"
        End Select
        Return num
    End Function
    Private Sub presupuesto(ByVal ano As Integer)
        If pa.Abrir(CmboboxCCostos.SelectedValue.ToString, CInt(CmboboxCContable.SelectedValue.ToString), ano) Then
            Label4.Text = pa.valor_mes(mes).ToString
        Else
            Label4.Text = "0.0"
        End If
        If CmboboxCCostos.SelectedValue.ToString = "DDVE" Then
            If pa.Abrir(CmboboxCCostos.SelectedValue.ToString, 411106, ano) Then
                Label6.Text = FormatNumber(pa.valor_mes(mes).ToString, 2)
            Else
                Label6.Text = "0.0"
            End If
        Else
            If pa.Abrir("TOT", 411106, ano) Then
                Label6.Text = FormatNumber(pa.valor_mes(mes).ToString, 2)
            Else
                Label6.Text = "0.0"
            End If
        End If
        Label12.Text = (Math.Round((CDbl(Label4.Text) / CDbl(Label6.Text)), 5) * 100).ToString("N3")

    End Sub
    Private Sub real()

        Dim dt As DataTable

        dt = real(New Date(dtp.Value.Year, dtp.Value.Month, 1), dtp.Value, CmboboxCContable.SelectedValue.ToString, CmboboxCCostos.SelectedValue.ToString)
        dr = dt.Rows(0)
        If dr("suma") Is DBNull.Value Then
            Dim suma As Double = 0.0
            Label9.Text = suma.ToString
        Else

            If dt.Rows.Count = 1 Then
                Label9.Text = dr("suma").ToString
                If Label9.Text = "" Then
                    Label9.Text = "0.0"
                End If
            End If
        End If
        Dim dt1 As DataTable
        If CmboboxCCostos.SelectedValue.ToString = "DDVE" Then
            dt1 = venta_real(New Date(dtp.Value.Year, dtp.Value.Month, 1), dtp.Value, "411106", 2)
        Else
            dt1 = venta_real(New Date(dtp.Value.Year, dtp.Value.Month, 1), dtp.Value, "411106", 1)
        End If
        dr = dt1.Rows(0)
        If dr("suma") Is DBNull.Value Then
            Dim suma As Double = 0.0
            Label11.Text = FormatNumber(suma.ToString, 2)
        Else
            Label11.Text = dr("suma").ToString
            Label11.Text = FormatNumber(Math.Abs(CDbl(Label11.Text)).ToString, 2)
        End If

        Label13.Text = (Math.Round((CDbl(Label9.Text) / CDbl(Label11.Text)), 5) * 100).ToString("N3")
    End Sub
    Private Sub Acumulado_Presupuesto(ByVal ano As Integer)
        If pa.Abrir(CmboboxCCostos.SelectedValue.ToString, CInt(CmboboxCContable.SelectedValue.ToString), ano) Then
            Dim suma As Double = 0.0
            For x As Integer = 0 To mes
                Dim a As Double = pa.valor_mes(x)
                suma = pa.valor_mes(x) + suma
                Label14.Text = suma.ToString
            Next
        Else
            Label14.Text = "0.0"
        End If
        If CmboboxCCostos.SelectedValue.ToString = "DDVE" Then
            pa.Abrir(CmboboxCCostos.SelectedValue.ToString, 411106, ano)
            Dim suma As Double = 0.0
            For x As Integer = 0 To mes
                suma = pa.valor_mes(x) + suma
                Label15.Text = FormatNumber(suma.ToString, 2)
            Next
        Else
            pa.Abrir("TOT", 411106, ano)
            Dim suma As Double = 0.0
            For x As Integer = 0 To mes
                suma = pa.valor_mes(x) + suma
                Label15.Text = FormatNumber(suma.ToString, 2)
            Next
        End If
        Label16.Text = (Math.Round((CDbl(Label14.Text) / CDbl(Label15.Text)), 5) * 100).ToString("N3")
        If pa.Abrir(CmboboxCCostos.SelectedValue.ToString, CInt(CmboboxCContable.SelectedValue.ToString), ano) Then
            Dim suma As Double = 0.0
            For x As Integer = 0 To mes
                ' Dim a As Double = pa.valor_mes(x)
                suma = pa.valor_mes(x) + suma
                Label14.Text = suma.ToString
            Next
        Else
            Label14.Text = "0.0"
        End If
        If CmboboxCCostos.SelectedValue.ToString = "DDVE" Then
            pa.Abrir(CmboboxCCostos.SelectedValue.ToString, 411106, ano)
            Dim suma As Double = 0.0
            For x As Integer = 0 To mes
                suma = pa.valor_mes(x) + suma
                Label15.Text = FormatNumber(suma.ToString, )
            Next
        Else
            pa.Abrir("TOT", 411106, ano)
            Dim suma As Double = 0.0
            For x As Integer = 0 To mes
                suma = pa.valor_mes(x) + suma
                Label15.Text = FormatNumber(suma.ToString, 2)
            Next
        End If

        Label16.Text = (Math.Round((CDbl(Label14.Text) / CDbl(Label15.Text)), 5) * 100).ToString("N3")
    End Sub
    Private Sub presupuesto_total(ByVal ano As Integer)
        If pa.Abrir(CmboboxCCostos.SelectedValue.ToString, CInt(CmboboxCContable.SelectedValue.ToString), ano) Then
            Dim suma As Double = 0.0
            For x As Integer = 0 To 11
                Dim a As Double = pa.valor_mes(x)
                suma = pa.valor_mes(x) + suma
                Label28.Text = suma.ToString
            Next
        Else
            Label28.Text = "0.0"
        End If
    End Sub
    Private Sub Acumulado_Real()
        Dim suma As Double = 0.0
        Dim dt As New DataTable

        dt = real(New Date(dtp.Value.Year, 1, 1), dtp.Value, CmboboxCContable.SelectedValue.ToString, CmboboxCCostos.SelectedValue.ToString)
        dr = dt.Rows(0)
        If dr("suma") Is DBNull.Value Then
            Label18.Text = suma.ToString
        Else
            If dt.Rows.Count = 1 Then
                Label18.Text = dr("suma").ToString
            End If
        End If
        Dim dt1 As DataTable
        If CmboboxCCostos.SelectedValue.ToString = "DDVE" Then
            dt1 = venta_real(New Date(dtp.Value.Year, 1, 1), dtp.Value, "411106", 2)
        Else
            dt1 = venta_real(New Date(dtp.Value.Year, 1, 1), dtp.Value, "411106", 1)
        End If
        dr = dt1.Rows(0)
        If dr("suma") Is DBNull.Value Then
            Label19.Text = FormatNumber(suma.ToString, 2)
        Else
            If dt1.Rows.Count = 1 Then

                Label19.Text = dr("suma").ToString
                Label19.Text = FormatNumber(Math.Abs(CDbl(Label19.Text)).ToString, 2)
            End If
        End If
        Label20.Text = (Math.Round((CDbl(Label18.Text) / CDbl(Label19.Text)), 5) * 100).ToString("N3")

    End Sub

    'Private Function calcular_real(ByVal m As Integer, ByVal contable As String, ByVal costo As String) As Double
    '    Dim dt2 As DataTable
    '    Dim suma As Double = 0.0
    '    dt2 = real(New Date(dtp.Value.Year, m, 1), New Date(dtp.Value.Year, m, 1).AddMonths(+1).AddDays(-1), contable, costo)

    '    If dt2.Rows.Count = 0 Then
    '    Else
    '        dr = dt2.Rows(0)
    '        If dt2.Rows.Count = 1 Then
    '            suma = CDbl(dr("amt_" & Amt())) + suma
    '            Label18.Text = suma.ToString
    '        Else
    '            For i As Integer = 0 To dt2.Rows.Count - 1
    '                suma = CDbl(dr("amt_" & Amt())) + suma
    '            Next
    '        End If
    '    End If
    '    Return Math.Abs(suma)
    'End Function


End Class