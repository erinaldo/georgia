Imports System.Data.OracleClient

Public Class frmLicitacionDetalle
    Private da As OracleDataAdapter
    Private dt As New DataTable
    Private lic As Licitacion
    Private ds As New DataSet

    Public Sub New(ByVal lic As Licitacion)
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Adaptadores()

        Me.lic = lic

        Abrir(lic.Numero)

        colNro.DataPropertyName = "nro_0"
        colLig.DataPropertyName = "lig_0"
        colArticulo.DataPropertyName = "itmref_0"
        colDescripcion.DataPropertyName = "itmdes1_0"
        colCantidad.DataPropertyName = "qty_0"
        colPrecio.DataPropertyName = "amt_0"
        colGanada.DataPropertyName = "ganada_0"
        colCantidad2.DataPropertyName = "qty_1"
        colPrecio2.DataPropertyName = "amt_1"
        colEmpresa.DataPropertyName = "empresa_0"
        dgv.DataSource = dt

        'If dt.Rows.Count = 0 Then CargarPresupuesto(lic.NumeroPresupuesto)

    End Sub
    Private Sub Adaptadores()
        Dim Sql As String

        Sql = "SELECT * FROM xlicitad WHERE nro_0 = :nro"
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

    End Sub
    'Private Sub CargarPresupuesto(ByVal sqh As String)
    '    Dim da As OracleDataAdapter
    '    Dim sql As String
    '    Dim dt2 As New DataTable

    '    sql = "SELECT * FROM squoted WHERE sqhnum_0 = :sqhnum"
    '    da = New OracleDataAdapter(sql, cn)
    '    da.SelectCommand.Parameters.Add("sqhnum", OracleType.VarChar).Value = sqh
    '    da.Fill(dt2)

    '    For Each dr2 As DataRow In dt2.Rows
    '        Dim dr As DataRow

    '        dr = dt.NewRow
    '        dr("nro_0") = lic.Numero 'dr1("sqhnum_0").ToString
    '        dr("itmref_0") = dr2("itmref_0")
    '        dr("itmdes1_0") = dr2("itmdes1_0").ToString
    '        dr("ganada_0") = 1
    '        dr("qty_0") = dr2("qty_0")
    '        dr("qty_1") = dr2("qty_0")
    '        dr("amt_0") = CDbl(dr2("netpriati_0")) * CDbl(dr2("qty_0"))
    '        dr("amt_1") = CDbl(dr2("netpriati_0")) * CDbl(dr2("qty_0"))
    '        dr("empresa_0") = " "
    '        Me.dt.Rows.Add(dr)
    '    Next

    '    Grabar()

    'End Sub
    Private Sub Grabar()
        da.Update(dt)
    End Sub
    Private Function Validar() As Boolean
        Dim flg As Boolean = True

        'No se puede tildar campo ganada si estado < 3
        If lic.Estado <> 3 And lic.Estado <> 5 And dgv.DataSource IsNot Nothing Then
            Dim dt As DataTable = CType(dgv.DataSource, DataTable)

            For Each dr As DataRow In dt.Rows
                If CInt(dr("ganada_0")) = 1 Then
                    MessageBox.Show("Esta licitación no puede tener item en estado Ganado", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    flg = False
                    Exit For
                End If
            Next
        End If

        'Ganada debe tener precio y cantidad
        For Each dr As DataRow In dt.Rows
            If CInt(dr("ganada_0")) = 1 Then
                If CDbl(dr("qty_1")) = 0 Or CDbl(dr("amt_1")) = 0 Then
                    Dim txt As String
                    txt = "[{1}] Precio y cantidad debe ser mayor a cero"
                    txt = txt.Replace("{1}", dr("itmref_0").ToString)
                    MessageBox.Show(txt, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    flg = False
                    Exit For
                End If
            End If
        Next

        Return flg

    End Function
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click

        'Try
        If Validar() Then
            Grabar()
            Me.Close()
        End If
        'Catch ex As Exception
        'MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

        'End Try

    End Sub
    Private Sub TildarTodo(ByVal Estado As Boolean)
        Dim dt As DataTable = CType(dgv.DataSource, DataTable)

        For Each dr As DataRow In dt.Rows
            dr.BeginEdit()
            dr("ganada_0") = IIf(Estado, 1, 0)
            dr.EndEdit()
        Next

    End Sub
    Private Sub mnuTildarTodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTildarTodo.Click
        TildarTodo(True)
    End Sub
    Private Sub mnuDestildarTodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDestildarTodo.Click
        TildarTodo(False)
    End Sub
    Private Sub frmLicitacionDetalle_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If ds.HasChanges Then
            Select Case MessageBox.Show("¿Grabar los cambios al salir?", Me.Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3)
                Case Windows.Forms.DialogResult.Yes
                    Grabar()

                Case Windows.Forms.DialogResult.No

                Case Windows.Forms.DialogResult.Cancel
                    e.Cancel = True

                Case Else
                    e.Cancel = True

            End Select

        End If
    End Sub

End Class