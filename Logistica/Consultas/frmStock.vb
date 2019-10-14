Imports System.Data.OracleClient

Public Class frmStock
    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        Consultar()
    End Sub
    Public Sub Consultar()
        Dim Sql As String
        Dim da As OracleDataAdapter
        Dim Codigo As String = txtCodigo.Text
        Dim dt As New DataTable
        Dim Paternal As New Datos
        Dim Munro As New Datos

        If Codigo.StartsWith("10") Or Codigo.StartsWith("11") Then
            Sql = "SELECT itm.itmref_0, stofcy_0, SUM(itv.salsto_0) AS pedidos, SUM(itv.physto_0) AS stock "
            Sql &= "FROM itmmaster itm INNER JOIN itmmvt itv ON (itm.itmref_0 = itv.itmref_0) "
            Sql &= "WHERE itm.itmref_0 = :itmref_0 OR itm.itmref_0 = :itmref_1 "
            Sql &= "GROUP BY itm.itmref_0, stofcy_0"
            da = New OracleDataAdapter(Sql, cn)
            da.SelectCommand.Parameters.Add("itmref_0", OracleType.VarChar).Value = "10" & Strings.Right(Codigo, 4)
            da.SelectCommand.Parameters.Add("itmref_1", OracleType.VarChar).Value = "11" & Strings.Right(Codigo, 4)

        Else
            Sql = "SELECT itm.itmref_0, stofcy_0, SUM(itv.salsto_0) AS pedidos, SUM(itv.physto_0) AS stock "
            Sql &= "FROM itmmaster itm INNER JOIN itmmvt itv ON (itm.itmref_0 = itv.itmref_0) "
            Sql &= "WHERE itm.itmref_0 = :itmref_0 "
            Sql &= "GROUP BY itm.itmref_0, stofcy_0"
            da = New OracleDataAdapter(Sql, cn)
            da.SelectCommand.Parameters.Add("itmref_0", OracleType.VarChar).Value = Codigo

        End If

        dt.Clear()
        da.Fill(dt)

        For Each dr As DataRow In dt.Rows
            If dr("stofcy_0").ToString.EndsWith("04") Then
                Munro.Pedidos += CDbl(dr("pedidos"))
                Munro.Stock += CDbl(dr("stock"))
            Else
                Paternal.Pedidos += CDbl(dr("pedidos"))
                Paternal.Stock += CDbl(dr("stock"))
            End If
        Next

        txtPaternalPedidos.Text = Paternal.Pedidos.ToString
        txtPaternalStock.Text = Paternal.Stock.ToString

        txtMunroPedidos.Text = Munro.Pedidos.ToString
        txtMunroStock.Text = Munro.Stock.ToString

    End Sub

    Structure Datos
        Dim Pedidos As Double
        Dim Stock As Double
    End Structure

End Class