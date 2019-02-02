Imports System.Data.OracleClient

Public Class frmSelectorExpreso
    Private dt As DataTable
    Private dv As DataView
    Public Seleccion As String = ""

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Dim exp As New Expreso(cn)

        dt = exp.ObtenerTodos
        dv = New DataView(dt)

        colCodigo.DataPropertyName = "tranum_0"
        colNombre.DataPropertyName = "nombre_0"
        colDomicilio.DataPropertyName = "domicilio_0"
        colLocalidad.DataPropertyName = "ciudad_0"
        dgv.DataSource = dv

    End Sub
    Private Sub txtBuscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBuscar.TextChanged
        With txtBuscar

            If .Text.Trim = "" Then
                dv.RowFilter = ""
            Else
                dv.RowFilter = "tranum_0 like '%" & txtBuscar.Text.Trim & "%' or nombre_0 like  '%" & txtBuscar.Text.Trim & "%'"
            End If

        End With
    End Sub

    Private Sub btnSeleccionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSeleccionar.Click
        If dgv.SelectedRows.Count = 0 Then Exit Sub

        Dim dr As DataRow

        dr = CType(CType(dgv.SelectedRows(0), DataGridViewRow).DataBoundItem, DataRowView).Row

        Seleccion = dr("tranum_0").ToString

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

End Class