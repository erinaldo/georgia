Imports System.Data.OracleClient

Public Class frmPrecios
    Private da As OracleDataAdapter
    Private dt As New DataTable
    Private ds As DataSet

    Private Sub frmPrecios_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Adaptadores()

        CargarPrecios()

        colCodigo.DataPropertyName = "itmref_0"

        With colDescripcion
            .DisplayMember = "itmdes1_0"
            .ValueMember = "itmref_0"
            .DataPropertyName = "itmref_0"
            .DataSource = Articulo.Tabla(cn)
        End With

        colCantidad.DataPropertyName = "qty_0"
        colPrecio0.DataPropertyName = "precio_0"
        colPrecio1.DataPropertyName = "precio_1"
        colPrecio2.DataPropertyName = "precio_2"
        colPrecio3.DataPropertyName = "precio_3"
        colPrecio4.DataPropertyName = "precio_4"
        colPrecio5.DataPropertyName = "precio_5"
        colPrecio6.DataPropertyName = "precio_6"
        colPrecio7.DataPropertyName = "precio_7"
        colPrecio8.DataPropertyName = "precio_8"
        colPrecio9.DataPropertyName = "precio_9"
        colPrecio10.DataPropertyName = "precio_10"
        colPrecio11.DataPropertyName = "precio_11"
        colPrecio12.DataPropertyName = "precio_12"
        colPrecio13.DataPropertyName = "precio_13"
        colPrecio14.DataPropertyName = "precio_14"
        colPrecio15.DataPropertyName = "precio_15"
        colPrecio16.DataPropertyName = "precio_16"
        colPrecio17.DataPropertyName = "precio_17"
        colPrecio18.DataPropertyName = "precio_18"

        Dim m As New MenuLocal(cn, 1, True)
        m.Enlazar(colNuevo)
        colNuevo.DataPropertyName = "ped_0"

        dgv.DataSource = dt

        AddHandler dgv.RowPostPaint, AddressOf NumeracionGrillas

    End Sub
    Private Sub CargarPrecios()
        dt.Clear()
        da.Fill(dt)
    End Sub
    Private Sub Adaptadores()
        Dim Sql As String

        Sql = "SELECT itmref_0, qty_0, precio_0, precio_1, precio_2, precio_3, precio_4, precio_5, precio_6, precio_7,"
        Sql &= "      precio_8, precio_9, precio_10, precio_11, precio_12, precio_13, precio_14, precio_15, precio_16, precio_17, precio_18, ped_0 "
        Sql &= "FROM xprecios xpe"
        da = New OracleDataAdapter(Sql, cn)

        Sql = "INSERT INTO xprecios VALUES (:itmref_0, :qty_0, :precio_0, :precio_1, :precio_2, :precio_3, :precio_4, :precio_5, :precio_6, :precio_7, :precio_8, :precio_9, :precio_10, :precio_11, :precio_12, :precio_13, :precio_14, :precio_15, :precio_16, :precio_17, :precio_18, :ped_0)"
        da.InsertCommand = New OracleCommand(Sql, cn)
        Parametro(da.InsertCommand, "itmref_0", OracleType.VarChar, DataRowVersion.Current)
        Parametro(da.InsertCommand, "qty_0", OracleType.Number, DataRowVersion.Current)
        Parametro(da.InsertCommand, "precio_0", OracleType.Number, DataRowVersion.Current)
        Parametro(da.InsertCommand, "precio_1", OracleType.Number, DataRowVersion.Current)
        Parametro(da.InsertCommand, "precio_2", OracleType.Number, DataRowVersion.Current)
        Parametro(da.InsertCommand, "precio_3", OracleType.Number, DataRowVersion.Current)
        Parametro(da.InsertCommand, "precio_4", OracleType.Number, DataRowVersion.Current)
        Parametro(da.InsertCommand, "precio_5", OracleType.Number, DataRowVersion.Current)
        Parametro(da.InsertCommand, "precio_6", OracleType.Number, DataRowVersion.Current)
        Parametro(da.InsertCommand, "precio_7", OracleType.Number, DataRowVersion.Current)
        Parametro(da.InsertCommand, "precio_8", OracleType.Number, DataRowVersion.Current)
        Parametro(da.InsertCommand, "precio_9", OracleType.Number, DataRowVersion.Current)
        Parametro(da.InsertCommand, "precio_10", OracleType.Number, DataRowVersion.Current)
        Parametro(da.InsertCommand, "precio_11", OracleType.Number, DataRowVersion.Current)
        Parametro(da.InsertCommand, "precio_12", OracleType.Number, DataRowVersion.Current)
        Parametro(da.InsertCommand, "precio_13", OracleType.Number, DataRowVersion.Current)
        Parametro(da.InsertCommand, "precio_14", OracleType.Number, DataRowVersion.Current)
        Parametro(da.InsertCommand, "precio_15", OracleType.Number, DataRowVersion.Current)
        Parametro(da.InsertCommand, "precio_16", OracleType.Number, DataRowVersion.Current)
        Parametro(da.InsertCommand, "precio_17", OracleType.Number, DataRowVersion.Current)
        Parametro(da.InsertCommand, "precio_18", OracleType.Number, DataRowVersion.Current)
        Parametro(da.InsertCommand, "ped_0", OracleType.Number, DataRowVersion.Current)

        Sql = "UPDATE xprecios "
        Sql &= "SET itmref_0 = :itmref_0, qty_0 = :qty_0, "
        Sql &= "precio_0 = :precio_0, precio_1 = :precio_1, precio_2 = :precio_2, precio_3 = :precio_3, precio_4 = :precio_4, precio_5 = :precio_5, "
        Sql &= "precio_6 = :precio_6, precio_7 = :precio_7, precio_8 = :precio_8, precio_9 = :precio_9, precio_10 = :precio_10, precio_11 = :precio_11, "
        Sql &= "precio_12 = :precio_12, precio_13 = :precio_13, precio_14 = :precio_14, precio_15 = :precio_15, precio_16 = :precio_16, precio_17 = :precio_17, "
        Sql &= "precio_18 = :precio_18, ped_0 = :ped_0 "
        Sql &= "WHERE itmref_0 = :itmref_o AND qty_0 = :qty_o"
        da.UpdateCommand = New OracleCommand(Sql, cn)
        Parametro(da.UpdateCommand, "itmref_0", OracleType.VarChar, DataRowVersion.Current)
        Parametro(da.UpdateCommand, "qty_0", OracleType.Number, DataRowVersion.Current)
        Parametro(da.UpdateCommand, "precio_0", OracleType.Number, DataRowVersion.Current)
        Parametro(da.UpdateCommand, "precio_1", OracleType.Number, DataRowVersion.Current)
        Parametro(da.UpdateCommand, "precio_2", OracleType.Number, DataRowVersion.Current)
        Parametro(da.UpdateCommand, "precio_3", OracleType.Number, DataRowVersion.Current)
        Parametro(da.UpdateCommand, "precio_4", OracleType.Number, DataRowVersion.Current)
        Parametro(da.UpdateCommand, "precio_5", OracleType.Number, DataRowVersion.Current)
        Parametro(da.UpdateCommand, "precio_6", OracleType.Number, DataRowVersion.Current)
        Parametro(da.UpdateCommand, "precio_7", OracleType.Number, DataRowVersion.Current)
        Parametro(da.UpdateCommand, "precio_8", OracleType.Number, DataRowVersion.Current)
        Parametro(da.UpdateCommand, "precio_9", OracleType.Number, DataRowVersion.Current)
        Parametro(da.UpdateCommand, "precio_10", OracleType.Number, DataRowVersion.Current)
        Parametro(da.UpdateCommand, "precio_11", OracleType.Number, DataRowVersion.Current)
        Parametro(da.UpdateCommand, "precio_12", OracleType.Number, DataRowVersion.Current)
        Parametro(da.UpdateCommand, "precio_13", OracleType.Number, DataRowVersion.Current)
        Parametro(da.UpdateCommand, "precio_14", OracleType.Number, DataRowVersion.Current)
        Parametro(da.UpdateCommand, "precio_15", OracleType.Number, DataRowVersion.Current)
        Parametro(da.UpdateCommand, "precio_16", OracleType.Number, DataRowVersion.Current)
        Parametro(da.UpdateCommand, "precio_17", OracleType.Number, DataRowVersion.Current)
        Parametro(da.UpdateCommand, "precio_18", OracleType.Number, DataRowVersion.Current)

        Parametro(da.UpdateCommand, "ped_0", OracleType.VarChar, DataRowVersion.Current, "ped_0")
        Parametro(da.UpdateCommand, "itmref_o", OracleType.VarChar, DataRowVersion.Original, "itmref_0")
        Parametro(da.UpdateCommand, "qty_o", OracleType.Number, DataRowVersion.Original, "qty_0")

        Sql = "DELETE FROM xprecios WHERE itmref_0 = :itmref_0 AND qty_0 = :qty_0"
        da.DeleteCommand = New OracleCommand(Sql, cn)
        Parametro(da.DeleteCommand, "itmref_0", OracleType.VarChar, DataRowVersion.Original)
        Parametro(da.DeleteCommand, "qty_0", OracleType.Number, DataRowVersion.Original)

    End Sub
    Private Sub btnRegistrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegistrar.Click
        da.Update(dt)
    End Sub
    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        Me.UseWaitCursor = True

        SaveFileDialog1.Filter = "Documentos de texto (*.txt*)|*.txt"

        'Salgo si el usuario cancelo el dialogo
        If SaveFileDialog1.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub

        Try
            Cotizacion.Exportar(cn, SaveFileDialog1.FileName)
            MessageBox.Show("OK", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            CargarPrecios()

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)

        End Try

        Me.UseWaitCursor = False

    End Sub
    Private Sub btnImportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImportar.Click
        Me.UseWaitCursor = True

        OpenFileDialog1.Filter = "Documentos de texto (*.txt*)|*.txt"

        If OpenFileDialog1.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub

        'Try
        Cotizacion.Importar(cn, OpenFileDialog1.FileName)
        MessageBox.Show("OK", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        CargarPrecios()

        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)

        'End Try

        Me.UseWaitCursor = False

    End Sub

End Class