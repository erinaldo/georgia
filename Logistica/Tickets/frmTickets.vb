Imports System.Data.OracleClient

Public Class frmTickets
    Private dt As DataTable
    Private dv As DataView

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Dim mnu As New MenuLocal(cn)
        mnu.AbrirMenu(2409, False)
        mnu.ModificarTexto(1, "Abierto")
        mnu.ModificarTexto(2, "Resuelto")
        mnu.ModificarTexto(3, "Cerrado")
        mnu.Enlazar(colEstado)

        CargarTickets()

    End Sub
    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Dim f As New frmTicket

        f.ShowDialog()

        CargarTickets()

    End Sub
    Private Sub CargarTickets()
        Dim da As OracleDataAdapter
        Dim Sql As String
        Dim mnu As MenuLocal
        Dim txt As String = ""
        Dim dt As New DataTable


        'Consulto los sectores a los que el usuario tiene acceso
        Sql = "SELECT xsector_0 FROM xtickets WHERE usr_0 = '" & usr.Codigo & "'"
        da = New OracleDataAdapter(Sql, cn)
        da.Fill(dt)
        da.Dispose()
        da = Nothing

        For Each dr As DataRow In dt.Rows
            txt &= "'" & dr(0).ToString & "',"
        Next
        If txt.Length > 1 Then txt = Strings.Left(txt, txt.Length - 1)


        Sql = "SELECT xth.nro_0, xth.creusr_0, xth.bpcnum_0, bpcnam_0, bpaadd_0, motivo_0, xth.credat_0, xth.asigusr_0, xth.credat_0-xth.asigdat_0 AS dias, estado_0, xth.asigdat_0 "
        Sql &= "FROM bpcustomer bpc INNER JOIN "
        Sql &= "     xticketh xth ON (bpc.bpcnum_0 = xth.bpcnum_0) "
        Sql &= "WHERE xth.estado_0 IN ({estados}) AND "
        Sql &= "      (xth.creusr_0 = :usr OR xth.asigusr_0 = :usr OR xth.asigusr_0 IN ({sectores}) OR xth.creusr_0 IN ({sectores})) "

        If txt = "" Then
            Sql = Sql.Replace("{sectores}", "''")
        Else
            Sql = Sql.Replace("{sectores}", txt)
        End If

        'Si no hay filtro de estado tildado, fuerzo a abiertos
        If chkAbiertos.Checked = False And _
           chkResueltos.Checked = False And _
           chkCerrados.Checked = False Then chkAbiertos.Checked = True

        'Armado de filtro de estado
        txt = ""
        If chkAbiertos.Checked Then txt &= "1,"
        If chkResueltos.Checked Then txt &= "2,"
        If chkCerrados.Checked Then txt &= "3,"

        If txt.Length > 1 Then txt = Strings.Left(txt, txt.Length - 1)

        Sql = Sql.Replace("{estados}", txt)

        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("usr", OracleType.VarChar).Value = usr.Codigo

        If dgv.DataSource Is Nothing Then
            dt = New DataTable
        Else
            dt = CType(dgv.DataSource, DataView).Table
        End If

        dt.Clear()
        da.Fill(dt)

        'Pongo dias=0 en donde fecha es 31/12/1599
        For Each dr As DataRow In dt.Rows

            If CDate(dr("asigdat_0")) = #12/31/1599# Then
                dr.BeginEdit()
                dr("dias") = 0
                dr.EndEdit()
            End If

        Next

        If dgv.DataSource Is Nothing Then
            colNro.DataPropertyName = "nro_0"
            colOperador.DataPropertyName = "creusr_0"
            colCodigoCliente.DataPropertyName = "bpcnum_0"
            colNombreCliente.DataPropertyName = "bpcnam_0"
            colSucursal.DataPropertyName = "bpaadd_0"

            mnu = New MenuLocal(cn)
            mnu.AbrirMenu(9200, True)
            mnu.Enlazar(colMotivo, "motivo_0")

            colFechaCreacion.DataPropertyName = "credat_0"
            colAsignado.DataPropertyName = "asigusr_0"
            colDias.DataPropertyName = "dias"

            mnu = New MenuLocal(cn)
            mnu.AbrirMenu(2409, False)
            mnu.ModificarTexto(1, "Abierto")
            mnu.ModificarTexto(2, "Resuelto")
            mnu.ModificarTexto(3, "Cerrado")
            mnu.Enlazar(colEstado, "estado_0")

            colFechaAsignado.DataPropertyName = "asigdat_0"

            dv = New DataView(dt)
            dgv.DataSource = dv

        End If

    End Sub

    Private Sub dgv_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellDoubleClick
        Dim f As frmTicket
        Dim i As Integer = 0

        If e.RowIndex < 0 Then Exit Sub

        i = CInt(dgv.Rows(e.RowIndex).Cells("colNro").Value)

        f = New frmTicket(i)
        f.ShowDialog()

    End Sub

    Private Sub btnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizar.Click
        btnActualizar.Enabled = False
        CargarTickets()
        btnActualizar.Enabled = True
    End Sub

    Private Sub txtFiltroCliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFiltroCliente.TextChanged
        Dim txt As TextBox = CType(sender, TextBox)

        Try
            If txtFiltroCliente.Text = "" Then
                dv.RowFilter = ""

            Else
                dv.RowFilter = "bpcnum_0 LIKE '%" & txt.Text.ToUpper & "%'"

            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub dgv_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellContentClick

    End Sub

End Class