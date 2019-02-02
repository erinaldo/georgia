Imports Clases
Imports System.Data.OracleClient

Public Class FrmCantExt

    Private Sub BtnCalcular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCalcular.Click
        If cmbox.SelectedIndex = -1 Then Exit Sub
        dgvPrincipalLogistica.DataSource = dtprincipal(2, cmbox.SelectedItem.ToString)
        dgvAdicionalLogistica.DataSource = dtAdicional(2, cmbox.SelectedItem.ToString)
        dgvPrincipalAbonos.DataSource = dtprincipal(3, cmbox.SelectedItem.ToString)
        dgvAdicionalAbonos.DataSource = dtAdicional(3, cmbox.SelectedItem.ToString)
        dgvPrincipalVarios.DataSource = dtprincipal(1, cmbox.SelectedItem.ToString)
        dgvAdicionalVarios.DataSource = dtAdicional(1, cmbox.SelectedItem.ToString)
        AcumuladoLogistica.Text = ValorAcumulado(2, cmbox.SelectedItem.ToString)
        AcumuladoAbonos.Text = ValorAcumulado(3, cmbox.SelectedItem.ToString)
        SumaLogistica.Text = ValorAcumuladoDia(2, cmbox.SelectedItem.ToString)
        SumaAbonos.Text = ValorAcumuladoDia(3, cmbox.SelectedItem.ToString)
    End Sub
    Private Function dtprincipal(ByVal sector As Integer, ByVal tipo As String) As DataTable
        Dim dt As New DataTable
        Dim da As OracleDataAdapter
        Dim sql As String

        sql = "select fecha_0,chofer_0 as Camioneta,sum(equipos_1) as Ext from xrutad xrd "
        sql &= "inner join xrutac xrc on (xrd.ruta_0 = xrc.ruta_0) "
        sql &= "inner join zunitrans z on (z.bptnum_0 = xrc.transporte_0 and z.patnum_0 = xrc.patente_0) where "
        sql &= "tipo_0 = :tipo and estado_0 = 3 and fecha_0 = :fechainicio and xsector_0 = :sector "
        sql &= "group by fecha_0,chofer_0 order by fecha_0 "
        da = New OracleDataAdapter(sql, cn)
        da.SelectCommand.Parameters.Add("fechainicio", OracleType.DateTime).Value = dtp.Value.Date
        da.SelectCommand.Parameters.Add("sector", OracleType.Int16).Value = sector
        da.SelectCommand.Parameters.Add("tipo", OracleType.VarChar).Value = tipo
        da.Fill(dt)
        Return dt
    End Function
    Private Function dtAdicional(ByVal sector As Integer, ByVal tipo As String) As DataTable
        Dim dt As New DataTable
        Dim da As OracleDataAdapter
        Dim sql As String

        sql = "select chofer_0 as Camioneta, sum(equipos_1) as Ext from xrutad xrd "
        sql &= "inner join xrutac xrc on (xrd.ruta_0 = xrc.ruta_0) "
        sql &= "inner join zunitrans z on (z.bptnum_0 = xrc.transporte_0 and z.patnum_0 = xrc.patente_0) where "
        sql &= "tipo_0 = :tipo and estado_0 = 3 and (fecha_0 >= :fechainicio and fecha_0 <= :fechafin) and xsector_0 = :sector  "
        sql &= "group by chofer_0 "
        da = New OracleDataAdapter(sql, cn)
        da.SelectCommand.Parameters.Add("fechainicio", OracleType.DateTime).Value = New Date(dtp.Value.Year, dtp.Value.Month, 1)
        da.SelectCommand.Parameters.Add("fechafin", OracleType.DateTime).Value = dtp.Value.Date
        da.SelectCommand.Parameters.Add("sector", OracleType.Int16).Value = sector
        da.SelectCommand.Parameters.Add("tipo", OracleType.VarChar).Value = tipo
        da.Fill(dt)
        Return dt
    End Function

    Private Function ValorAcumulado(ByVal sector As Integer, ByVal tipo As String) As String
        Dim dt As New DataTable
        Dim da As OracleDataAdapter
        Dim sql As String
        Dim dr As DataRow

        sql = "select sum(equipos_1) as Ext from xrutad xrd "
        sql &= "inner join xrutac xrc on (xrd.ruta_0 = xrc.ruta_0) "
        sql &= "inner join zunitrans z on (z.bptnum_0 = xrc.transporte_0 and z.patnum_0 = xrc.patente_0) where "
        sql &= "tipo_0 = :tipo and estado_0 = 3 and (fecha_0 >= :fechainicio and fecha_0 <= :fechafin) and xsector_0 = :sector  "
        da = New OracleDataAdapter(sql, cn)
        da.SelectCommand.Parameters.Add("fechainicio", OracleType.DateTime).Value = New Date(dtp.Value.Year, dtp.Value.Month, 1)
        da.SelectCommand.Parameters.Add("fechafin", OracleType.DateTime).Value = dtp.Value.Date
        da.SelectCommand.Parameters.Add("sector", OracleType.Int16).Value = sector
        da.SelectCommand.Parameters.Add("tipo", OracleType.VarChar).Value = tipo
        da.Fill(dt)
        dr = dt.Rows(0)
        Return dr("ext").ToString
    End Function
    Private Function ValorAcumuladoDia(ByVal sector As Integer, ByVal tipo As String) As String
        Dim dt As New DataTable
        Dim da As OracleDataAdapter
        Dim sql As String
        Dim dr As DataRow

        sql = "select sum(equipos_1) as Ext from xrutad xrd "
        sql &= "inner join xrutac xrc on (xrd.ruta_0 = xrc.ruta_0) "
        sql &= "inner join zunitrans z on (z.bptnum_0 = xrc.transporte_0 and z.patnum_0 = xrc.patente_0) where "
        sql &= "tipo_0 = :tipo and estado_0 = 3 and fecha_0 = :fechainicio and xsector_0 = :sector  "
        da = New OracleDataAdapter(sql, cn)
        da.SelectCommand.Parameters.Add("fechainicio", OracleType.DateTime).Value = dtp.Value.Date
        da.SelectCommand.Parameters.Add("tipo", OracleType.VarChar).Value = tipo
        da.SelectCommand.Parameters.Add("sector", OracleType.Int16).Value = sector
        da.Fill(dt)
        dr = dt.Rows(0)
        Return dr("ext").ToString
    End Function
End Class