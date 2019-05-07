Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.OracleClient

Public Class frmStock
    Dim dt2 As New DataTable
    Private Sub btn_stock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_stock.Click
        buscar()
        'Dim Sql As String
        'Dim da As OracleDataAdapter
        'Dim numero As String = txtbtn_stock.Text

        'If numero.StartsWith("10") Or numero.StartsWith("11") Then
        '    Sql = "select itm.itmdes1_0 as nombre, sum(it.salsto_0) as cantidad_pedida, sum(it.physto_0) as stock "
        '    Sql &= "from itmmaster itm inner join itmmvt it on (itm.ITMREF_0 = it.itmref_0)where itm.itmref_0 = :itmref_0 or itm.itmref_0 = :itmref_1"
        '    Sql &= " group by itm.itmdes1_0"
        '    da = New OracleDataAdapter(Sql, cn)
        '    da.SelectCommand.Parameters.Add("itmref_0", OracleType.VarChar).Value = "10" & Strings.Right(numero, 4)
        '    da.SelectCommand.Parameters.Add("itmref_1", OracleType.VarChar).Value = "11" & Strings.Right(numero, 4)

        'Else
        '    Sql = "select itm.itmdes1_0 as nombre, sum(it.salsto_0) as cantidad_pedida, sum(it.physto_0) as stock "
        '    Sql &= "from itmmaster itm inner join itmmvt it on (itm.ITMREF_0 = it.itmref_0)where itm.itmref_0 = :itmref_0"
        '    Sql &= " group by itm.itmdes1_0 "
        '    da = New OracleDataAdapter(Sql, cn)
        '    da.SelectCommand.Parameters.Add("itmref_0", OracleType.VarChar).Value = numero

        'End If


        'dt2.Clear()
        'da.Fill(dt2)

        'If dt2.Rows.Count = 0 Then
        '    MsgBox("No hay item`s con ese codigo")

        'Else
        '    EnlazarGrilla()
        'End If

    End Sub
    Public Sub buscar()
        Dim Sql As String
        Dim da As OracleDataAdapter
        Dim numero As String = txtbtn_stock.Text

        If numero.StartsWith("10") Or numero.StartsWith("11") Then
            Sql = "select itm.itmdes1_0 as nombre, sum(it.salsto_0) as cantidad_pedida, sum(it.physto_0) as stock, 'Rodriguez' "
            Sql &= "from itmmaster itm inner join itmmvt it on (itm.ITMREF_0 = it.itmref_0)where (itm.itmref_0 = :itmref_0 or itm.itmref_0 = :itmref_1)  and  stofcy_0 <> 'D04'"
            Sql &= " group by itm.itmdes1_0"
            Sql &= " union all "
            Sql &= "select itm.itmdes1_0 as nombre, sum(it.salsto_0) as cantidad_pedida, sum(it.physto_0) as stock, 'Munro' "
            Sql &= "from itmmaster itm inner join itmmvt it on (itm.ITMREF_0 = it.itmref_0)where (itm.itmref_0 = :itmref_0 or itm.itmref_0 = :itmref_1) and  stofcy_0 = 'D04'"
            Sql &= " group by itm.itmdes1_0 "
            da = New OracleDataAdapter(Sql, cn)
            da.SelectCommand.Parameters.Add("itmref_0", OracleType.VarChar).Value = "10" & Strings.Right(numero, 4)
            da.SelectCommand.Parameters.Add("itmref_1", OracleType.VarChar).Value = "11" & Strings.Right(numero, 4)

        Else
            Sql = "select itm.itmdes1_0 as nombre, sum(it.salsto_0) as cantidad_pedida, sum(it.physto_0) as stock, 'Rodriguez' "
            Sql &= "from itmmaster itm inner join itmmvt it on (itm.ITMREF_0 = it.itmref_0)where (itm.itmref_0 = :itmref_0) and  stofcy_0 <> 'D04'"
            Sql &= " group by itm.itmdes1_0 "
            Sql &= " union all "
            Sql &= "select itm.itmdes1_0 as nombre, sum(it.salsto_0) as cantidad_pedida, sum(it.physto_0) as stock, 'Munro' "
            Sql &= "from itmmaster itm inner join itmmvt it on (itm.ITMREF_0 = it.itmref_0)where (itm.itmref_0 = :itmref_0) and  stofcy_0 = 'D04'"
            Sql &= " group by itm.itmdes1_0 "
            da = New OracleDataAdapter(Sql, cn)
            da.SelectCommand.Parameters.Add("itmref_0", OracleType.VarChar).Value = numero

        End If

        dt2.Clear()
        da.Fill(dt2)

        If dt2.Rows.Count = 0 Then
            MsgBox("No hay item`s con ese codigo")

        Else
            EnlazarGrilla()
        End If

    End Sub
    Private Sub EnlazarGrilla()
        If dgv.DataSource Is Nothing Then
            dgv.DataSource = dt2
            dgv.AutoResizeColumns()
            For i As Integer = 0 To dgv.Columns.Count - 1
                dgv.Columns(i).Visible = True
            Next

        End If
    End Sub
End Class