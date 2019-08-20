Imports System.Data.OracleClient

Public Class frmIntervencionRechazo
    Private bpc As Cliente
    Private bpa As Sucursal
    Public Seleccionado As String = ""

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

        sql = "select itn.dat_0 as fecha, itn.num_0 as intervencion, itn.ysdhdeb_0 as rto, itn.xsector_0 as sector "
        sql &= "from interven itn inner join "
        sql &= "	 hdktask hdk on (itn.num_0 = hdk.itnnum_0) "
        sql &= "where itn.bpc_0 = :cli and "
        sql &= "      itn.bpaadd_0 = :suc and "
        sql &= "      itn.credat_0 >= :dat and "
        sql &= "      hdk.hdtitm_0 in ('453001', '503001') "
        sql &= "order by credat_0 desc "

        da = New OracleDataAdapter(sql, cn)
        da.SelectCommand.Parameters.Add("cli", OracleType.VarChar).Value = bpc.Codigo
        da.SelectCommand.Parameters.Add("suc", OracleType.VarChar).Value = bpa.Sucursal
        da.SelectCommand.Parameters.Add("dat", OracleType.DateTime).Value = Today.AddYears(-1)

        da.Fill(dt)

        dgv.DataSource = dt

        Label1.Text = bpc.Cliente.Codigo.ToString & " - " & bpc.Cliente.Nombre.ToString
        Label2.Text = bpa.Sucursal.ToString & " - " & bpa.Direccion.ToString

        btnAceptar.Enabled = dt.Rows.Count > 0

        Seleccionado = ""

    End Sub

    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim dr As DataRow

        dr = CType(dgv.SelectedRows(0).DataBoundItem, DataRowView).Row

        Seleccionado = dr("num_0").ToString

        DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class