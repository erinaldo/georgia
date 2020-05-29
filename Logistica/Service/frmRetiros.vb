Imports System.Data.OracleClient

Public Class frmRetiros

    Private da As OracleDataAdapter
    Private dt As New DataTable

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Dim Sql As String

        Sql = "select * from xretiros where dat_0 = :dat"
        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("dat", OracleType.DateTime)
        da.InsertCommand = New OracleCommandBuilder(da).GetInsertCommand
        da.UpdateCommand = New OracleCommandBuilder(da).GetUpdateCommand
        da.DeleteCommand = New OracleCommandBuilder(da).GetDeleteCommand

    End Sub
    Private Sub AbrirFecha(ByVal Fecha As Date)
        da.SelectCommand.Parameters("dat").Value = New Date(fecha.Year, fecha.Month, fecha.Day)
        dt.Clear()
        da.Fill(dt)

        MostrarDatos()

        txtExtintores.ReadOnly = False
        txtMangueras.ReadOnly = False
        btnGrabar.Enabled = True
    End Sub
    Private Sub MostrarDatos()
        If dt.Rows.Count = 1 Then
            Dim dr As DataRow
            dr = dt.Rows(0)
            txtExtintores.Text = dr("extintores_0").ToString
            txtMangueras.Text = dr("mangueras_0").ToString
        Else
            txtExtintores.Text = "0"
            txtMangueras.Text = "0"
        End If
    End Sub
    Private Sub mcal_DateChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DateRangeEventArgs) Handles mcal.DateChanged
        AbrirFecha(e.End)
    End Sub
    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If IsNumeric(txtExtintores.Text.Trim) And IsNumeric(txtMangueras.Text.Trim) Then
            Grabar()
        Else
            MessageBox.Show("Error al guardar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub Grabar()
        Dim dr As DataRow

        If dt.Rows.Count = 0 Then
            dr = dt.NewRow
            dr("dat_0") = mcal.SelectionRange.End
            dr("extintores_0") = CInt(txtExtintores.Text)
            dr("mangueras_0") = CInt(txtMangueras.Text)
            dt.Rows.Add(dr)
        Else
            dr = dt.Rows(0)
            dr.BeginEdit()
            dr("extintores_0") = CInt(txtExtintores.Text)
            dr("mangueras_0") = CInt(txtMangueras.Text)
            dr.EndEdit()
        End If

        da.Update(dt)

        btnGrabar.Enabled = False

    End Sub
End Class