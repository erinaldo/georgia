Imports System.Data.OracleClient

Public Class frmSelectorSucursal

    Private dt As New DataTable
    Public SucursalSeleccionada As String = ""
    Private dv As DataView

    Public Sub New(ByVal bpc As Cliente)
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.New(bpc.Codigo)
    End Sub
    Public Sub New(ByVal Cliente As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Dim Sql As String
        Dim da As OracleDataAdapter

        Sql = "SELECT bpaadd_0, bpaaddlig_0, cty_0, sat_0 "
        Sql &= "FROM bpaddress "
        Sql &= "WHERE bpanum_0 = :bpanum"

        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("bpanum", OracleType.VarChar).Value = Cliente
        Try
            da.Fill(dt)
            da.Dispose()

        Catch ex As Exception

        End Try
    End Sub
    Private Sub frmSelectorSucursal_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        dv = New DataView(dt)

        colSuc.DataPropertyName = "bpaadd_0"
        colDomicilio.DataPropertyName = "bpaaddlig_0"
        colLocalidad.DataPropertyName = "cty_0"
        colProvincia.DataPropertyName = "sat_0"
        dgv.DataSource = dv

        dgv.Focus()

    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Seleccionar()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Seleccionar()
        Dim dr As DataRow

        If dgv.SelectedRows.Count = 1 Then
            dr = CType(dgv.SelectedRows(0).DataBoundItem, DataRowView).Row
            SucursalSeleccionada = dr(0).ToString
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub txtFiltro_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFiltro.TextChanged
        Dim s As String = txtFiltro.Text.Trim.ToUpper

        If s <> "" Then
            dv.RowFilter = "bpaaddlig_0 like '%" & s & "%'"
        Else
            dv.RowFilter = ""
        End If

    End Sub

End Class