Imports System.Data.OracleClient

Public Class frmITM
    Private dt As New DataTable

    Private Sub EnlazarGrilla()
        If dgv.DataSource Is Nothing Then
            dgv.DataSource = dt
            dgv.AutoResizeColumns()
            For i As Integer = 0 To dgv.Columns.Count - 1
                dgv.Columns(i).Visible = True
            Next
            'Dim mnu = New MenuLocal(cn, 246, False)
            'Dim estado As New DataGridViewComboBoxColumn
            'estado.Name = "Estado"
            'dgv.Columns.Add(estado)
            'mnu.Enlazar(estado)
            'estado.DataPropertyName = dgv.Columns(5).ValueType.Name
        End If
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Dim Sql As String
        Dim da As OracleDataAdapter

        Sql = "select itmref_0 as CODIGO, itmdes1_0 AS DES_1, itmdes2_0 AS DES_2, itmdes3_0 AS DES_3,itmdes_0 as des_larga from itmmaster where "
        If radioNombre.Checked = True Then
            Sql &= "itmsta_0 = '1' and itmdes1_0 like :itmdes_0 order by itmref_0"
            da = New OracleDataAdapter(Sql, cn)
            da.SelectCommand.Parameters.Add("itmdes_0", OracleType.VarChar).Value = "%" & txt.Text.ToUpper & "%"
        ElseIf radioCod.Checked = True Then
            Sql &= "itmsta_0 = '1' and itmref_0 like :itmref_0 order by itmref_0"
            da = New OracleDataAdapter(Sql, cn)
            da.SelectCommand.Parameters.Add("itmref_0", OracleType.VarChar).Value = "%" & txt.Text & "%"
        ElseIf rdblarga.Checked = True Then
            Sql &= "itmsta_0 = '1' and itmdes_0 like :itmdes_0 order by itmref_0"
            da = New OracleDataAdapter(Sql, cn)
            da.SelectCommand.Parameters.Add("itmdes_0", OracleType.VarChar).Value = "%" & txt.Text.ToLower & "%"

        Else
            Exit Sub

        End If

        Try
            dt.Clear()
            da.Fill(dt)

            If dt.Rows.Count = 0 Then
                Label5.Visible = True
                txt.Clear()

            Else
                Label5.Visible = False
                EnlazarGrilla()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

   
    Private Sub VerStockToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerStockToolStripMenuItem.Click
        Dim numero As String = dgv.CurrentRow.Cells("codigo").Value.ToString
        Dim f As New frmStock
        f.txtbtn_stock.Text = numero
        f.buscar()
        f.Show()
    End Sub
End Class