Imports System.Data.OracleClient

Public Class frmLicitacion
    Private da As OracleDataAdapter
    Private WithEvents ds As New DataSet
    Private WithEvents dt As DataTable
    Private Sql As String

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Adaptadores()

    End Sub
    Private Sub Adaptadores()
        Sql = "SELECT nro_0, bpcnum_0, bpcnam_0, bpaaddlig_0, licitatyp_0, licitanum_0, sqhdat_0, sqhnum_0, sqhamt_0, nuevo_0, service_0, agua_0, deteccion_0, rep_0, apertura_0, compras_0, estado_0, adjudidat_0, obs_0 "
        Sql &= "FROM xlicita "

        da = New OracleDataAdapter(Sql, cn)

        da.InsertCommand = New OracleCommandBuilder(da).GetInsertCommand
        da.UpdateCommand = New OracleCommandBuilder(da).GetUpdateCommand
        da.DeleteCommand = New OracleCommandBuilder(da).GetDeleteCommand

    End Sub
    Private Sub frmLicitacion_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If ds.HasChanges Then
            Select Case MessageBox.Show("¿Grabar los cambios al salir?", Me.Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3)
                Case Windows.Forms.DialogResult.Yes
                    Grabar()

                Case Windows.Forms.DialogResult.No

                Case Windows.Forms.DialogResult.Cancel
                    e.Cancel = True

            End Select

        End If
    End Sub
    Private Sub frmLicitacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim mnu As New MenuLocal(cn)
        mnu.AbrirMenu(5003, False)
        mnu.Enlazar(cboTipoLicitacion)

        mnu = New MenuLocal(cn)
        mnu.AbrirMenu(5004, True)
        mnu.Enlazar(chkEstados)

        For i As Integer = 0 To chkEstados.Items.Count - 1
            chkEstados.SetItemChecked(i, True)
        Next

        btnFix.Visible = usr.Codigo = "MMIN"
    End Sub
    Private Sub CargarDatos()
        Dim mnu As MenuLocal

        If dgv.DataSource Is Nothing Then
            dt = New DataTable
            ds.Tables.Add(dt)

            mnu = New MenuLocal(cn)
            mnu.AbrirMenu(1, True)
            mnu.Enlazar(colAgua)
            colAgua.DataPropertyName = "agua_0"

            colApertura.DataPropertyName = "apertura_0"
            colCliente.DataPropertyName = "bpcnum_0"
            colCompras.DataPropertyName = "compras_0"

            mnu = New MenuLocal(cn)
            mnu.AbrirMenu(1, True)
            mnu.Enlazar(colDeteccion)
            colDeteccion.DataPropertyName = "deteccion_0"

            colDomicilio.DataPropertyName = "bpaaddlig_0"
            colFechaPresupuesto.DataPropertyName = "sqhdat_0"
            colLicitacion.DataPropertyName = "licitanum_0"
            colNombre.DataPropertyName = "bpcnam_0"

            colNro.DataPropertyName = "nro_0"

            mnu = New MenuLocal(cn)
            mnu.AbrirMenu(1, True)
            mnu.Enlazar(colNuevo)
            colNuevo.DataPropertyName = "nuevo_0"

            colNumeroPresupuesto.DataPropertyName = "sqhnum_0"
            colPrecio.DataPropertyName = "sqhamt_0"

            mnu = New MenuLocal(cn)
            mnu.AbrirMenu(1, True)
            mnu.Enlazar(colService)
            colService.DataPropertyName = "service_0"

            mnu = New MenuLocal(cn)
            mnu.AbrirMenu(5003, True)
            mnu.Enlazar(colTipo)
            colTipo.DataPropertyName = "licitatyp_0"

            colVendedor.DataPropertyName = "rep_0"

            mnu = New MenuLocal(cn)
            mnu.AbrirMenu(5004, True)
            mnu.Enlazar(colEstado)
            colEstado.DataPropertyName = "estado_0"

            colFechaAdjudicacion.DataPropertyName = "adjudidat_0"
            colObs.DataPropertyName = "obs_0"

            dgv.DataSource = dt

        Else
            dt = CType(dgv.DataSource, DataTable)

        End If

        da.SelectCommand.CommandText = Sql & " WHERE estado_0 in (" & FiltrarEstado() & ")"

        dt.Clear()
        da.Fill(dt)

    End Sub
    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        Grabar()
    End Sub
    Public Sub Grabar()
        If dgv.DataSource Is Nothing Then Exit Sub

        Dim dt As DataTable = CType(dgv.DataSource, DataTable)

        da.Update(dt)

        btnGrabar.Enabled = False

    End Sub
    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Dim Sqh As New Presupuesto(cn)

        If txtPresupuesto.Text.Trim <> "" Then
            If Sqh.Abrir(txtPresupuesto.Text) Then
                If Not ExisteLicitacion(Sqh.Numero) Then

                    If CInt(cboTipoLicitacion.SelectedValue) > 1 AndAlso txtLicitacion.Text.Trim <> "" Then

                        Sqh.CrearLicitacion(CInt(cboTipoLicitacion.SelectedValue), txtLicitacion.Text)

                        txtPresupuesto.Clear()
                        cboTipoLicitacion.SelectedValue = 0
                        txtLicitacion.Clear()

                        CargarDatos()

                    Else
                        MessageBox.Show("Tipo y número de licitación obligatorio", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)

                    End If

                Else
                    MessageBox.Show("Ya existe una licitación con este presupuesto", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)

                End If


            Else
                MessageBox.Show("Presupuesto no encontrado", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)

            End If

        Else
            MessageBox.Show("Ingrese un número de presupuesto", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)

        End If

    End Sub
    Private Function ExisteLicitacion(ByVal Num As String) As Boolean
        Dim da As OracleDataAdapter
        Dim dt As New DataTable
        Dim Sql As String

        Sql = "SELECT * FROM xlicita WHERE sqhnum_0 = :sqhnum"
        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("sqhnum", OracleType.VarChar).Value = Num.ToUpper
        da.Fill(dt)
        da.Dispose()

        Return dt.Rows.Count > 0

    End Function
    Private Sub dt_RowChanged(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs) Handles dt.RowChanged
        btnGrabar.Enabled = True
    End Sub
    Private Sub dt_TableNewRow(ByVal sender As Object, ByVal e As System.Data.DataTableNewRowEventArgs) Handles dt.TableNewRow
        btnGrabar.Enabled = True
    End Sub
    Private Sub btnDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDetalle.Click
        If dgv.CurrentRow.Index < 0 Then Exit Sub

        If CInt(dgv.CurrentRow.Cells("colEstado").Value) < 3 Then
            MessageBox.Show("Detalle no disponible en este estado", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        Grabar()

        Dim Nro As Integer = CInt(dgv.CurrentRow.Cells("colNro").Value)
        Dim lic As New Licitacion(cn)
        lic.Abrir(Nro)

        Dim f As New frmLicitacionDetalle(lic)
        f.ShowDialog()

    End Sub

    Private Sub dgv_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellDoubleClick
        MessageBox.Show(e.ColumnIndex.ToString)
    End Sub
    Private Sub dgv_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dgv.CellValidating

        Select Case e.ColumnIndex
            Case 7, 15, 18 'Campos de fechas
                If Not IsDate(e.FormattedValue) Then
                    e.Cancel = True
                    MessageBox.Show("El formato de fecha debe ser: dd/mm/aaaa", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If

        End Select

    End Sub
    Private Function FiltrarEstado() As String
        Dim flg As Boolean = False
        Dim drv As DataRowView
        Dim txt As String = ""

        For j As Integer = 0 To chkEstados.CheckedItems.Count - 1
            drv = CType(chkEstados.CheckedItems(j), DataRowView)

            If flg Then txt &= ", " 'Pongo coma de separacion de valores

            txt &= drv(2).ToString

            flg = True

        Next

        If txt = "" Then txt = "-1"

        Return txt

    End Function
    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        CargarDatos()
    End Sub

    Private Sub btnFix_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFix.Click
        '1- Consulto los ID que no tienen detalle
        Dim Sql As String
        Dim dt1 As New DataTable
        Dim da1 As OracleDataAdapter
        Dim dt2 As New DataTable
        Dim da2 As OracleDataAdapter
        Dim Lic As New Licitacion(cn)

        Sql = "select * from xlicita where nro_0 not in (select distinct nro_0 from xlicitad)"
        da1 = New OracleDataAdapter(Sql, cn)
        da1.Fill(dt1)

        Sql = "SELECT * FROM squoted where sqhnum_0 = :sqhnum_0"
        da2 = New OracleDataAdapter(Sql, cn)
        da2.SelectCommand.Parameters.Add("sqhnum_0", OracleType.VarChar)


        For Each dr1 As DataRow In dt1.Rows
            dt2.Clear()
            da2.SelectCommand.Parameters("sqhnum_0").Value = dr1("sqhnum_0").ToString
            da2.Fill(dt2)

            'Abro licitacion
            Lic.Abrir(CInt(dr1("nro_0")))
            Lic.AgregarDetalle(dt2)
            Lic.Grabar()
        Next


        MessageBox.Show("Listo")

    End Sub

    Private Sub btnExtras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExtras.Click
        If dgv.CurrentRow.Index < 0 Then Exit Sub
        Grabar()

        Dim Nro As Integer = CInt(dgv.CurrentRow.Cells("colNro").Value)
        Dim lic As New Licitacion(cn)
        lic.Abrir(Nro)

        Dim f As New frmLicitacionExtra(lic)
        f.ShowDialog()

    End Sub

    Private Sub dgv_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgv.UserDeletedRow
        btnGrabar.Enabled = True
    End Sub

    Private Sub dgv_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgv.UserDeletingRow
        Dim flg As DialogResult
        Dim txt As String

        txt = "¿Confirma la eliminación?"

        flg = MessageBox.Show(txt, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)

        e.Cancel = flg <> Windows.Forms.DialogResult.Yes

    End Sub

End Class