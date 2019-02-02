Imports System.Data.OracleClient

Public Class frmIntervencionesPendientes
    Private da As OracleDataAdapter
    Private dt As New DataTable

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Dim Sql As String

        Sql = "SELECT itn.num_0, "
        Sql &= "      itn.typ_0, "
        Sql &= "      bpc.bpcnum_0, "
        Sql &= "      bpc.bpcnam_0, "
        Sql &= "      itn.dat_0, "
        Sql &= "      itn.bpaadd_0, "
        Sql &= "      itn.add_0, "
        Sql &= "      count(yit.tqty_0) as cantidad, "
        Sql &= "      itn.yobsrec_0 "
        Sql &= "FROM interven itn INNER JOIN "
        Sql &= "	 yitndet yit ON (itn.num_0 = yit.num_0 AND typlig_0 = 1) INNER JOIN "
        Sql &= "	 bpcustomer bpc ON (bpc_0 = bpcnum_0) "
        Sql &= "where (typ_0 in ('B1', 'B2') OR (typ_0 = 'H1' and yotr_0 = 0)) AND "
        Sql &= "	  typlig_0 = 1 AND "
        Sql &= "	  zflgtrip_0 = 1 AND "
        Sql &= "	  ysdhdeb_0 = ' ' AND "
        Sql &= "	  don_0 <> 2 AND "
        Sql &= "	  pblsol_0 <> 2 "
        Sql &= "GROUP BY itn.num_0, itn.typ_0, bpc.bpcnum_0, bpc.bpcnam_0, itn.dat_0, itn.bpaadd_0, itn.add_0, itn.yobsrec_0 "
        Sql &= "ORDER BY itn.num_0"

        da = New OracleDataAdapter(Sql, cn)

    End Sub

    Private Sub btnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizar.Click
        Dim c As DataGridViewColumn

        dt.Clear()
        da.Fill(dt)

        If dgv.DataSource Is Nothing Then
            colAdd.DataPropertyName = "add_0"
            colBpaAdd.DataPropertyName = "bpaadd_0"
            colBpcNam.DataPropertyName = "bpcnam_0"
            colBpcnum.DataPropertyName = "bpcnum_0"
            colCantidad.DataPropertyName = "cantidad"
            colDat.DataPropertyName = "dat_0"
            colNum.DataPropertyName = "num_0"
            colObservaciones.DataPropertyName = "yobsrec_0"
            colTyp.DataPropertyName = "typ_0"
            dgv.DataSource = dt

            For Each c In dgv.Columns
                c.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            Next

        End If

    End Sub

    Private Sub mnuObservaciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuObservaciones.Click
        If dgv.CurrentRow Is Nothing Then Exit Sub

        Dim f As frmComentarios
        Dim dr As DataRow = CType(dgv.CurrentRow.DataBoundItem, DataRowView).Row
        Dim itn As New Intervencion(cn)

        If Not itn.Abrir(dr("num_0").ToString) Then Exit Sub

        f = New frmComentarios(dr("yobsrec_0").ToString.Trim)
        f.ShowDialog(Me)

        If f.DialogResult = Windows.Forms.DialogResult.OK Then
            itn.ComentarioRec = f.txtComentario.Text
            itn.Grabar()

            dr.BeginEdit()
            dr("yobsrec_0") = itn.ComentarioRec
            dr.EndEdit()
            dr.AcceptChanges()
        End If

        f.Dispose()
        itn.Dispose()
    End Sub
End Class