Imports System.Data.OracleClient

Public Class frmBuscadorIntervenciones

    Private da As OracleDataAdapter
    Private dt As New DataTable
    Public Seleccionado As String = ""

    Public Sub New(ByVal Cliente As String, ByVal Sucursal As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Adaptadores()
        ConsultarIntervenciones(Cliente, Sucursal)
    End Sub
    Private Sub Adaptadores()
        Dim Sql As String

        Sql = "SELECT itn.dat_0, itn.srvdemnum_0, itn.typ_0, itn.num_0 as itn, itn.ysdhdeb_0, siv.num_0 as sih, itn.zflgtrip_0, itn.xsector_0 "
        Sql &= "FROM interven   itn inner join "
        Sql &= "     serrequest sre on (itn.srvdemnum_0 = sre.srenum_0) left join "
        Sql &= "	 sinvoicev siv on (sre.srenum_0 = siv.sihorinum_0) "
        Sql &= "WHERE itn.bpc_0 = :cliente and "
        Sql &= "      itn.bpaadd_0 >= :sucursal and "
        Sql &= "      itn.credat_0 >= :credat "
        Sql &= "ORDER BY itn.dat_0 DESC"
        da = New OracleDataAdapter(Sql, cn)

        da.SelectCommand.Parameters.Add("cliente", OracleType.VarChar)
        da.SelectCommand.Parameters.Add("sucursal", OracleType.VarChar)
        da.SelectCommand.Parameters.Add("credat", OracleType.DateTime)

    End Sub
    Private Sub ConsultarIntervenciones(ByVal Cliente As String, ByVal Sucursal As String)
        dt.Clear()
        da.SelectCommand.Parameters("cliente").Value = Cliente
        da.SelectCommand.Parameters("sucursal").Value = Sucursal
        da.SelectCommand.Parameters("credat").Value = Date.Today.AddYears(-1)
        da.Fill(dt)

        If dgv.DataSource Is Nothing Then
            Dim mnu As New MenuLocal(cn)
            mnu.AbrirMenu(2406, True)

            colFecha.DataPropertyName = "dat_0"
            colSolicitud.DataPropertyName = "srvdemnum_0"
            colTipo.DataPropertyName = "typ_0"
            colIntervencion.DataPropertyName = "itn"
            colRemito.DataPropertyName = "ysdhdeb_0"
            colFactura.DataPropertyName = "sih"
            mnu.Enlazar(colEstado)
            colEstado.DataPropertyName = "zflgtrip_0"
            colSector.DataPropertyName = "xsector_0"
            dgv.DataSource = dt

        End If

    End Sub
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If dgv.SelectedRows.Count = 1 Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Seleccionado = dgv.SelectedRows(0).Cells("colIntervencion").Value.ToString
            Me.Close()
        End If
    End Sub
    Private Sub dgv_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellDoubleClick
        Dim n As String

        If e.RowIndex < 0 Then Exit Sub

        n = dgv.Rows(e.RowIndex).Cells("colIntervencion").Value.ToString

        Try
            Dim itn As New Intervencion(cn)

            itn.Abrir(n)

            MessageBox.Show(itn.AnalizarEstado, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception

        End Try

    End Sub

End Class