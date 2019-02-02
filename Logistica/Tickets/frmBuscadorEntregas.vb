Imports System.Data.OracleClient

Public Class frmBuscadorEntregas
    Private da As OracleDataAdapter
    Private dt As New DataTable
    Public Seleccionado As String = ""

    Public Sub New(ByVal Cliente As String, ByVal Sucursal As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Adaptadores()
        ConsultarEntregas(Cliente, Sucursal)
    End Sub
    Private Sub Adaptadores()
        Dim Sql As String

        Sql = "SELECT credat_0, sdhnum_0, sihnum_0, sohnum_0 "
        Sql &= "FROM sdelivery "
        Sql &= "WHERE bpcord_0 = :bpcord and "
        Sql &= "	  bpaadd_0 = :bpaadd and "
        Sql &= "      credat_0 >= :credat "
        Sql &= "ORDER BY credat_0 DESC"
        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("bpcord", OracleType.VarChar)
        da.SelectCommand.Parameters.Add("bpaadd", OracleType.VarChar)
        da.SelectCommand.Parameters.Add("credat", OracleType.DateTime)

    End Sub
    Private Sub ConsultarEntregas(ByVal Cliente As String, ByVal Sucursal As String)
        dt.Clear()
        da.SelectCommand.Parameters("bpcord").Value = Cliente
        da.SelectCommand.Parameters("bpaadd").Value = Sucursal
        da.SelectCommand.Parameters("credat").Value = Date.Today.AddYears(-1)
        da.Fill(dt)

        If dgv.DataSource Is Nothing Then
            colFecha.DataPropertyName = "credat_0"
            colEntrega.DataPropertyName = "sdhnum_0"
            colPedido.DataPropertyName = "sohnum_0"
            colFactura.DataPropertyName = "sihnum_0"
            dgv.DataSource = dt
        End If

    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        If dgv.SelectedRows.Count = 1 Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Seleccionado = dgv.SelectedRows(0).Cells("colEntrega").Value.ToString
            Me.Close()
        End If

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

End Class