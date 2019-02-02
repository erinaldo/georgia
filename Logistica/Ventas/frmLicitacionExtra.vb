Imports System.Data.OracleClient

Public Class frmLicitacionExtra
    Private da As OracleDataAdapter
    Private dt As New DataTable
    Private lic As Licitacion
    Private ds As New DataSet
    Private dr As DataRow

    Public Sub New(ByVal lic As Licitacion)
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Adaptadores()

        Me.lic = lic

        Abrir(lic.Numero)

    End Sub
    Private Sub Adaptadores()
        Dim Sql As String

        Sql = "SELECT * FROM xlicita WHERE nro_0 = :nro"
        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("nro", OracleType.VarChar)
        da.InsertCommand = New OracleCommandBuilder(da).GetInsertCommand
        da.UpdateCommand = New OracleCommandBuilder(da).GetUpdateCommand
        da.DeleteCommand = New OracleCommandBuilder(da).GetDeleteCommand

    End Sub
    Private Sub Abrir(ByVal Nro As Integer)

        da.SelectCommand.Parameters("nro").Value = Nro
        da.Fill(dt)

        ds.Tables.Add(dt)

        dr = dt.Rows(0)

        'Cargo controles
        txtPoliza.Text = dr("poliza_0").ToString.Trim
        dtpPoliza.Value = CDate(IIf(CDate(dr("polizadat_0")) = #12/31/1599#, Today, CDate(dr("polizadat_0"))))
        dtpPolizaVto.Value = CDate(IIf(CDate(dr("polizavto_0")) = #12/31/1599#, Today, CDate(dr("polizavto_0"))))
        txtFactura.Text = dr("sihnum_0").ToString.Trim
        txtRemito.Text = dr("sdhnum_0").ToString.Trim

    End Sub
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        Try
            dr("poliza_0") = IIf(txtPoliza.Text.Trim = "", " ", txtPoliza.Text.Trim)
            dr("polizadat_0") = dtpPoliza.Value
            dr("polizavto_0") = dtpPolizaVto.Value
            dr("sihnum_0") = IIf(txtFactura.Text.Trim = "", " ", txtFactura.Text.Trim)
            dr("sdhnum_0") = IIf(txtRemito.Text.Trim = "", " ", txtRemito.Text.Trim)

            da.Update(dt)
            Me.DialogResult = Windows.Forms.DialogResult.OK

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class