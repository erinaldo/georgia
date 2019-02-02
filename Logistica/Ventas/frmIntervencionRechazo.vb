Imports System.Data.OracleClient

Public Class frmIntervencionRechazo
    Private bpc As Cliente
    Private bpa As Sucursal

    Public Sub New(ByVal bpc As Cliente, ByVal bpa As Sucursal)
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.bpc = bpc
        Me.bpa = bpa

    End Sub

    Private Sub ItnRechazado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dt As New DataTable
        Dim da As OracleDataAdapter
        Dim sql As String = ""

        sql = "select num_0 "
        sql &= "from interven "
        sql &= "where bpc_0 = :cli and "
        sql &= "      bpaadd_0 = :suc and "
        sql &= "      credat_0 >= :dat "
        sql &= "order by credat_0 desc "

        da = New OracleDataAdapter(sql, cn)
        da.SelectCommand.Parameters.Add("cli", OracleType.VarChar).Value = bpc.Codigo
        da.SelectCommand.Parameters.Add("suc", OracleType.VarChar).Value = bpa.Sucursal
        da.SelectCommand.Parameters.Add("dat", OracleType.DateTime).Value = Today.AddYears(-1)

        da.Fill(dt)

        With cbo
            .DataSource = dt
            .DisplayMember = "num_0"
            .ValueMember = "num_0"
        End With

        Label1.Text = bpc.Cliente.Codigo.ToString & " - " & bpc.Cliente.Nombre.ToString
        Label2.Text = bpa.Sucursal.ToString & " - " & bpa.Direccion.ToString

        BtnAceptar.Enabled = dt.Rows.Count > 0

    End Sub

    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click
        DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class