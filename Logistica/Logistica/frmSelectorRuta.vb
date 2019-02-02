Imports System.Data.OracleClient

Public Class frmSelectorRuta

    Private dtTransportes As New DataTable
    Private dtAcompa As New DataTable
    Private dtChofer As New DataTable
    Private dtResultados As New DataTable

    Public Ruta As Integer = 0

    'EVENTOS
    Private Sub frmSelectorRuta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Sql As String
        Dim da As New OracleDataAdapter

        'TRANSPORTES
        Sql = "SELECT bptnum_0, bptnam_0 FROM bpcarrier ORDER BY bptnam_0"
        da.SelectCommand = New OracleCommand(Sql, cn)
        da.Fill(dtTransportes)

        'CHOFER
        Sql = "SELECT patnum_0, chofer_0 FROM zunitrans ORDER BY chofer_0"
        da.SelectCommand.CommandText = Sql
        da.Fill(dtChofer)

        'ACOMPAÑANTES
        Sql = "SELECT lannum_0, lanmes_0 FROM aplstd WHERE lanchp_0 = 2408 AND lan_0 = 'SPA' AND lannum_0 > 0 ORDER BY lanmes_0"
        da.SelectCommand.CommandText = Sql
        da.Fill(dtAcompa)

        'Enlace de Controles a datos
        With lstTransporte
            .DataSource = dtTransportes
            .DisplayMember = "bptnam_0"
            .ValueMember = "bptnum_0"
        End With

        With lstChofer
            .DataSource = dtChofer
            .DisplayMember = "chofer_0"
            .ValueMember = "patnum_0"
        End With

        With lstAcompa
            .DataSource = dtAcompa
            .DisplayMember = "lanmes_0"
            .ValueMember = "lannum_0"
        End With

        'ENLACE GRILLA DE RESULTADOS
        colRuta.DataPropertyName = "ruta_0"
        colFecha.DataPropertyName = "fecha_0"
        colTransporte.DataPropertyName = "transporte"
        colChofer.DataPropertyName = "chofer"
        colAcompa1.DataPropertyName = "acomp1"
        colAcompa2.DataPropertyName = "acomp2"

        dgvResultados.DataSource = dtResultados

        btnAbiertas_Click(btnAbiertas, Nothing)

        da.Dispose() : da = Nothing

    End Sub
    Private Sub frmSelectorRuta_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        dtTransportes.Dispose() : dtTransportes = Nothing
        dtAcompa.Dispose() : dtAcompa = Nothing
        dtChofer.Dispose() : dtChofer = Nothing
        dtResultados.Dispose() : dtResultados = Nothing
    End Sub
    Private Sub mtbRuta_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles mtbRuta.KeyUp
        If e.KeyCode = Keys.Enter Then
            Dim dr As OracleDataReader
            Dim cm As New OracleCommand("SELECT ruta_0 FROM xrutac WHERE ruta_0 = :p1", cn)
            cm.Parameters.Add("p1", OracleType.Varchar).Value = mtbRuta.Text

            dr = cm.ExecuteReader

            If dr.Read Then
                Ruta = CType(mtbRuta.Text, Integer)

                dr.Close()
                dr.Dispose() : dr = Nothing
                cm.Dispose() : cm = Nothing

                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()

            Else
                dr.Close()
                dr.Dispose() : dr = Nothing
                cm.Dispose() : cm = Nothing

                MessageBox.Show("No se encontró la ruta", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

        End If
    End Sub
    Private Sub btnAbiertas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbiertas.Click
        Dim Sql As String = ""

        Sql = "SELECT ruta_0, fecha_0, " & _
              "	   (SELECT bptnam_0 FROM bpcarrier WHERE bptnum_0 = transporte_0) AS transporte, " & _
              "	   (SELECT chofer_0 FROM zunitrans WHERE bptnum_0 = transporte_0 AND patnum_0 = patente_0) AS chofer, " & _
              "	   (SELECT lanmes_0 FROM aplstd WHERE lanchp_0 = 2408 AND lan_0 = 'SPA' AND lannum_0 = acomp_0) AS acomp1, " & _
              "	   (SELECT lanmes_0 FROM aplstd WHERE lanchp_0 = 2408 AND lan_0 = 'SPA' AND lannum_0 = acomp_1) AS acomp2 " & _
              "FROM xrutac " & _
              "WHERE valid_0 = 0 " & _
              "ORDER BY ruta_0 DESC"

        Dim da As New OracleDataAdapter(Sql, cn)

        dtResultados.Rows.Clear()
        da.Fill(dtResultados)

        da.Dispose() : da = Nothing
    End Sub
    Private Sub dtpFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFecha.ValueChanged
        Dim Sql As String = ""

        Sql = "SELECT ruta_0, fecha_0, " & _
              "	   (SELECT bptnam_0 FROM bpcarrier WHERE bptnum_0 = transporte_0) AS transporte, " & _
              "	   (SELECT chofer_0 FROM zunitrans WHERE bptnum_0 = transporte_0 AND patnum_0 = patente_0) AS chofer, " & _
              "	   (SELECT lanmes_0 FROM aplstd WHERE lanchp_0 = 2408 AND lan_0 = 'SPA' AND lannum_0 = acomp_0) AS acomp1, " & _
              "	   (SELECT lanmes_0 FROM aplstd WHERE lanchp_0 = 2408 AND lan_0 = 'SPA' AND lannum_0 = acomp_1) AS acomp2 " & _
              "FROM xrutac " & _
              "WHERE fecha_0 = :p1 " & _
              "ORDER BY ruta_0 DESC"

        Dim da As New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("p1", OracleType.DateTime).Value = CDate(dtpFecha.Value.ToShortDateString)

        dtResultados.Rows.Clear()
        da.Fill(dtResultados)

        da.Dispose() : da = Nothing
    End Sub
    Private Sub lstAcompa_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstAcompa.MouseDoubleClick
        Dim Sql As String = ""

        Sql = "SELECT ruta_0, fecha_0, " & _
              "	   (SELECT bptnam_0 FROM bpcarrier WHERE bptnum_0 = transporte_0) AS transporte, " & _
              "	   (SELECT chofer_0 FROM zunitrans WHERE bptnum_0 = transporte_0 AND patnum_0 = patente_0) AS chofer, " & _
              "	   (SELECT lanmes_0 FROM aplstd WHERE lanchp_0 = 2408 AND lan_0 = 'SPA' AND lannum_0 = acomp_0) AS acomp1, " & _
              "	   (SELECT lanmes_0 FROM aplstd WHERE lanchp_0 = 2408 AND lan_0 = 'SPA' AND lannum_0 = acomp_1) AS acomp2 " & _
              "FROM xrutac " & _
              "WHERE acomp_0 = :p1 OR acomp_1 = :p2 " & _
              "ORDER BY ruta_0 DESC"

        Dim da As New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("p1", OracleType.Number).Value = lstAcompa.SelectedValue
        da.SelectCommand.Parameters.Add("p2", OracleType.Number).Value = lstAcompa.SelectedValue

        dtResultados.Rows.Clear()
        da.Fill(dtResultados)

        If dtResultados.Rows.Count = 0 Then
            MessageBox.Show("No se encontraron resultados", "Resultados", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        da.Dispose() : da = Nothing

    End Sub
    Private Sub lstTransporte_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstTransporte.MouseDoubleClick
        Dim Sql As String = ""

        Sql = "SELECT ruta_0, fecha_0, " & _
              "	   (SELECT bptnam_0 FROM bpcarrier WHERE bptnum_0 = transporte_0) AS transporte, " & _
              "	   (SELECT chofer_0 FROM zunitrans WHERE bptnum_0 = transporte_0 AND patnum_0 = patente_0) AS chofer, " & _
              "	   (SELECT lanmes_0 FROM aplstd WHERE lanchp_0 = 2408 AND lan_0 = 'SPA' AND lannum_0 = acomp_0) AS acomp1, " & _
              "	   (SELECT lanmes_0 FROM aplstd WHERE lanchp_0 = 2408 AND lan_0 = 'SPA' AND lannum_0 = acomp_1) AS acomp2 " & _
              "FROM xrutac " & _
              "WHERE transporte_0 = :p1 " & _
              "ORDER BY ruta_0 DESC"

        Dim da As New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("p1", OracleType.Varchar).Value = lstTransporte.SelectedValue

        dtResultados.Rows.Clear()
        da.Fill(dtResultados)

        da.Dispose() : da = Nothing
    End Sub
    Private Sub lstChofer_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstChofer.MouseDoubleClick
        Dim Sql As String = ""

        Sql = "SELECT ruta_0, fecha_0, " & _
              "	   (SELECT bptnam_0 FROM bpcarrier WHERE bptnum_0 = transporte_0) AS transporte, " & _
              "	   (SELECT chofer_0 FROM zunitrans WHERE bptnum_0 = transporte_0 AND patnum_0 = patente_0) AS chofer, " & _
              "	   (SELECT lanmes_0 FROM aplstd WHERE lanchp_0 = 2408 AND lan_0 = 'SPA' AND lannum_0 = acomp_0) AS acomp1, " & _
              "	   (SELECT lanmes_0 FROM aplstd WHERE lanchp_0 = 2408 AND lan_0 = 'SPA' AND lannum_0 = acomp_1) AS acomp2 " & _
              "FROM xrutac " & _
              "WHERE patente_0 = :p1 " & _
              "ORDER BY ruta_0 DESC"

        Dim da As New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("p1", OracleType.Varchar).Value = lstChofer.SelectedValue

        dtResultados.Rows.Clear()
        da.Fill(dtResultados)

        da.Dispose() : da = Nothing
    End Sub
    Private Sub dgvResultados_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvResultados.CellDoubleClick
        If e.RowIndex < 0 Then Exit Sub

        Ruta = CType(dgvResultados.Rows(e.RowIndex).Cells(0).Value, Integer)
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub dgvResultados_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgvResultados.RowPostPaint
        On Error Resume Next

        Dim strRowNumber = (e.RowIndex + 1).ToString()
        Dim dgv As DataGridView = CType(sender, DataGridView)

        Dim size As System.Drawing.SizeF
        size = e.Graphics.MeasureString(strRowNumber, dgv.Font)

        If (dgv.RowHeadersWidth < CInt(size.Width + 20)) Then
            dgv.RowHeadersWidth = CInt((size.Width + 20))
        End If

        Dim b As System.Drawing.Brush = System.Drawing.SystemBrushes.ControlText

        e.Graphics.DrawString(strRowNumber, dgv.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))

        dgv = Nothing
    End Sub

End Class