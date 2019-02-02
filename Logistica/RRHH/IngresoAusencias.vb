Imports System.Data.OleDb

Public Class IngresoAusencias
    Friend dbConnection As OleDbConnection
    Friend dbDataSet As Data.DataSet
    Friend dbDataAdapter As OleDbDataAdapter
    Friend sql As String
    Friend bdd As String

    Dim dbDataTable As New Data.DataTable

    Private Sub btn_Registrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Registrar.Click
        If txt_ausentes.Text = " " Or txt_Dotacion.Text = " " Then
            MsgBox("Debe cargar informacion")
            Exit Sub
        Else
            dbDataTable.Clear()
            dbDataAdapter = New OleDbDataAdapter("select * from ausencias where fecha = ?;", dbConnection)
            dbDataAdapter.SelectCommand.Parameters.Add("fecha", OleDbType.Date)
            dbDataAdapter.SelectCommand.Parameters("fecha").Value = dtp.Value.Date
            dbDataAdapter.Fill(dbDataTable)
            If dbDataTable.Rows.Count > 0 Then
                MsgBox("Este dia ya esta cargado")
                Dim dr As DataRow
                dr = dbDataTable.Rows(0)
                txt_ausentes.Text = dr("ausencia").ToString
                txt_Dotacion.Text = dr("dotacion").ToString
            Else
                Dim dbDataTable As New Data.DataTable
                dbDataAdapter = New OleDbDataAdapter("INSERT INTO ausencias (fecha, ausencia,dotacion) VALUES(?,?,?);", dbConnection)
                dbDataAdapter.SelectCommand.Parameters.Add("fecha", OleDbType.Date)
                dbDataAdapter.SelectCommand.Parameters.Add("ausencia", OleDbType.Integer)
                dbDataAdapter.SelectCommand.Parameters.Add("Dotacion", OleDbType.Integer)
                dbDataAdapter.SelectCommand.Parameters("fecha").Value = dtp.Value.Date
                dbDataAdapter.SelectCommand.Parameters("ausencia").Value = txt_ausentes.Text
                dbDataAdapter.SelectCommand.Parameters("dotacion").Value = txt_Dotacion.Text
                dbDataAdapter.Fill(dbDataTable)
                dbDataAdapter.Dispose()
                MsgBox("se agrego la ausencia")
            End If
        End If
    End Sub

    Private Sub Btn_Modificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Modificar.Click
        If txt_ausentes.Text = " " Or txt_Dotacion.Text = " " Then
            MsgBox("Debe cargar informacion")
            Exit Sub
        Else
            Dim dbDataTable As New Data.DataTable
            dbDataAdapter = New OleDbDataAdapter("UPDATE ausencias SET ausencia =?,dotacion =? where fecha =?;", dbConnection)
            dbDataAdapter.SelectCommand.Parameters.Add("ausencia", OleDbType.Integer)
            dbDataAdapter.SelectCommand.Parameters.Add("Dotacion", OleDbType.Integer)
            dbDataAdapter.SelectCommand.Parameters.Add("fecha", OleDbType.Date)
            dbDataAdapter.SelectCommand.Parameters("ausencia").Value = txt_ausentes.Text
            dbDataAdapter.SelectCommand.Parameters("dotacion").Value = txt_Dotacion.Text
            dbDataAdapter.SelectCommand.Parameters("fecha").Value = dtp.Value.Date
            dbDataAdapter.Fill(dbDataTable)
            dbDataAdapter.Dispose()
            MsgBox("Se modifico el registro")
        End If
    End Sub

    Private Sub IngresoAusencias_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dbConnection = New OleDbConnection(CONEXIONBD)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        dbDataTable.Clear()
        dbDataAdapter = New OleDbDataAdapter("select * from ausencias where fecha = ?;", dbConnection)
        dbDataAdapter.SelectCommand.Parameters.Add("fecha", OleDbType.Date)
        dbDataAdapter.SelectCommand.Parameters("fecha").Value = dtp.Value.Date
        dbDataAdapter.Fill(dbDataTable)
        If dbDataTable.Rows.Count > 0 Then
            Dim dr As DataRow
            dr = dbDataTable.Rows(0)
            txt_ausentes.Text = dr("ausencia").ToString
            txt_Dotacion.Text = dr("dotacion").ToString
        Else
            MsgBox("Este dia no contiene datos")
        End If
    End Sub
End Class