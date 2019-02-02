Imports System.Data.OracleClient

Public Class frmSS
    Dim sol As New Solicitud(cn)
    Dim num As String
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim sql As String
        Dim da As OracleDataAdapter
        Dim dt As New DataTable
        dt.Clear()
        sql = "select bpcnum_0 as Numero, bpcnam_0 as Cliente, rep_0 as Vendedor from bpcustomer where bpcnum_0 like :bpcnum_0 "
        da = New OracleDataAdapter(sql, cn)
        da.SelectCommand.Parameters.Add("bpcnum_0", OracleType.VarChar).Value = "%" & txtbCliente.Text
        da.Fill(dt)
        EnlazarGrilla(dt, dgv1)
        da.Dispose()
    End Sub
    Private Sub dgv1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv1.CellContentClick
        Dim Cliente As String = dgv1.Rows(e.RowIndex).Cells("Numero").Value.ToString
        Dim sql As String
        Dim da As OracleDataAdapter
        Dim dt As New DataTable
        sql = "select srenum_0 as Numero_Solicitud, sr.sredes_0 as descripcion,sr.credat_0 as Fecha, srebpc_0 as Numero, bpc.bpcnam_0 as Cliente "
        sql &= "from serrequest sr join bpcustomer bpc on (sr.srebpc_0 = bpc.bpcnum_0) "
        sql &= "where sreinvflg_0 ='2' and sreass_0 = '5' and srebpc_0 = :cliente order by sr.credat_0 desc "
        da = New OracleDataAdapter(sql, cn)
        da.SelectCommand.Parameters.Add("cliente", OracleType.VarChar).Value = Cliente
        da.Fill(dt)
        EnlazarGrilla(dt, dgv2)

        da.Dispose()
    End Sub
    Private Sub EnlazarGrilla(ByVal dt As DataTable, ByVal dgv As DataGridView)
        dgv.DataSource = dt
        dgv.AutoResizeColumns()
        For i As Integer = 0 To dgv.Columns.Count - 1
            dgv.Columns(i).Visible = True
        Next
    End Sub

    Private Sub btnRegistrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegistrar.Click
        Dim sql1 As String = "update hdktask set hdtinv_0 = 1 where srenum_0 = :srenum"
        Dim da1 As OracleDataAdapter
        Dim dt1 As New DataTable


        Dim txt As String = ""
        txt = InputBox("Observaciones", Me.Text)
        For Each rows As DataGridViewRow In dgv2.SelectedRows
            num = (rows.Cells("numero_solicitud").Value.ToString)
            sol.Abrir(num)
            da1 = New OracleDataAdapter(sql1, cn)
            da1.SelectCommand.Parameters.Add("srenum", OracleType.VarChar).Value = num
            da1.Fill(dt1)
            da1.Update(dt1)
            txt = txt.Trim
            sol.descripcion_full = txt
            sol.descripcion = txt
            sol.updusr = usr.Codigo
            sol.estado_facturacion = 1
            sol.Grabar()
        Next
    End Sub

    Private Sub frmSS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dgv2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgv1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub
End Class