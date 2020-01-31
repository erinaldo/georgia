Imports System.Data.OracleClient

Public Class frmPresupuestosRecargaPendientes

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        dtpFechaDesde.Value = Today.AddMonths(-1)

    End Sub
    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        Dim da As OracleDataAdapter
        Dim dt As DataTable
        Dim Sql As String

        Sql = "SELECT xco.nro_0, sqh.sqhnum_0, sqh.quodat_0, sqh.quoinvnot_0, bpc.bpcnum_0, bpc.bpcnam_0, bpaadd_0, bpa.bpaaddlig_0, rep_0 "
        Sql &= "FROM xcotiza    xco INNER JOIN "
        Sql &= "	 bpcustomer bpc ON (xco.bpcnum_0 = bpc.bpcnum_0) inner join "
        Sql &= "	 bpaddress  bpa on (xco.bpcnum_0 = bpa.bpanum_0 AND xco.bpaadd_0 = bpa.bpaadd_0) inner join "
        Sql &= "	 squote     sqh on (xco.sqh_0    = sqh.sqhnum_0) "
        Sql &= "WHERE soh_0 = ' ' AND sqh_0 <> ' ' AND typ_0 = 2 AND dat_0 >= :fecha AND xduplica_0 <> 2"
        Sql &= "ORDER BY nro_0 desc"
        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("fecha", OracleType.DateTime).Value = dtpFechaDesde.Value

        If dgv.DataSource Is Nothing Then
            dt = New DataTable
        Else
            dt = CType(dgv.DataSource, DataTable)

        End If

        dt.Clear()
        da.Fill(dt)

        Dim ctz As New Cotizacion(cn)

        For Each dr As DataRow In dt.Rows()
            ctz.Abrir(CLng(dr("nro_0")))
            If Not ctz.TieneArticulosTipo(1) Then
                dr.Delete()
            Else
                If ctz.TieneIntervencion() Then dr.Delete()
            End If
        Next
        ctz = Nothing


        If dgv.DataSource Is Nothing Then
            colNro.DataPropertyName = "nro_0"
            colPresupuesto.DataPropertyName = "sqhnum_0"
            colFecha.DataPropertyName = "quodat_0"
            colImporte.DataPropertyName = "quoinvnot_0"
            colCliente.DataPropertyName = "bpcnum_0"
            colNombre.DataPropertyName = "bpcnam_0"
            colSucursal.DataPropertyName = "bpaadd_0"
            colDireccion.DataPropertyName = "bpaaddlig_0"
            colVendedor.DataPropertyName = "rep_0"
            dgv.DataSource = dt
        End If

    End Sub

End Class