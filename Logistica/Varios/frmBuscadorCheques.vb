Imports System.Data.OracleClient

Public Class frmBuscadorCheques
    Private da As OracleDataAdapter
    Private dt As New DataTable

    'SUBS
    Private Sub Adaptadores()
        Dim Sql As String

        Sql = "SELECT ptd.num_0, duddat_0, chqban_0, chqnum_0, bpr_0, bpanam_0, amtcur_0, cur_0, lanmes_0 "
        Sql &= "FROM (paymentd ptd INNER JOIN paymenth pth ON (ptd.num_0 = pth.num_0)) INNER JOIN aplstd ON (sta_0 = lannum_0) "
        Sql &= "WHERE cpy_0 = :cpy_0 AND pth.sta_0 BETWEEN 1 AND 3 AND pth.paytyp_0 = 'CCHT' AND lin_0 = 1 AND lanchp_0 = 689 AND lan_0 = 'SPA'"

        da = New OracleDataAdapter(Sql, cn)

        da.SelectCommand.Parameters.Add("cpy_0", OracleType.VarChar)

    End Sub
    Private Sub ComboEmpresas()
        'Carga las sociedades al combo
        Dim da As New OracleDataAdapter("SELECT cpy_0, cpynam_0 FROM company", cn)
        Dim dt As New DataTable

        da.Fill(dt)

        'Enlazo el combo
        With cboEmpresas
            .DataSource = dt
            .ValueMember = "cpy_0"
            .DisplayMember = "cpynam_0"
        End With

        da.Dispose()

        'cboEmpresas.SelectedValue = " "

    End Sub
    Private Sub Buscar(ByVal txt As String, Optional ByVal Reset As Boolean = False)
        Dim d As DataGridViewRow
        Dim Ocultar As Boolean

        dgv.CurrentCell = Nothing

        'Muestro leyenda de busqueda
        If Not Reset Then
            Label3.Visible = True
            Application.DoEvents()
        End If

        For Each d In dgv.Rows
            If Reset Then
                Ocultar = False

            Else

                Ocultar = True

                If IsDate(txt) Then

                    Ocultar = Not (CDate(d.Cells("colVenc").Value) = CDate(txt))

                Else
                    If d.Cells("colCheque").Value.ToString = txt Then
                        Ocultar = False

                    Else
                        If d.Cells("colImporte").Value.ToString = txt Then
                            Ocultar = False
                        End If

                    End If

                End If

            End If

            d.Visible = Not Ocultar

        Next

        txtBuscar.Clear()
        Label3.Visible = False
        Application.DoEvents()

    End Sub

    'EVENTOS
    Private Sub frmBuscadorCheques_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Adaptadores()
        ComboEmpresas()

        'Levanto la estructura de la tabla de resultados
        'da.FillSchema(dt, SchemaType.Mapped)

    End Sub
    Private Sub btnBuscar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        'Limpio la tabla de resultados
        dt.Clear()

        btnBuscar.Enabled = False
        Label3.Visible = True
        Application.DoEvents()

        If dgv.DataSource Is Nothing Then
            colPago.DataPropertyName = "num_0"
            colVenc.DataPropertyName = "duddat_0"
            colBanco.DataPropertyName = "chqban_0"
            colCheque.DataPropertyName = "chqnum_0"
            colCodigo.DataPropertyName = "bpr_0"
            colTercero.DataPropertyName = "bpanam_0"
            colImporte.DataPropertyName = "amtcur_0"
            colDivisa.DataPropertyName = "cur_0"
            colEstado.DataPropertyName = "lanmes_0"
            dgv.DataSource = dt
        End If

        'Pongo parametro de sociedad a consultar
        da.SelectCommand.Parameters("cpy_0").Value = cboEmpresas.SelectedValue.ToString
        da.Fill(dt)

        btnBuscar.Enabled = True
        Label3.Visible = False
        Application.DoEvents()

    End Sub
    Private Sub txtBuscar_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBuscar.KeyUp

        Select Case e.KeyCode
            Case Keys.Enter
                Buscar(txtBuscar.Text)

            Case Keys.Escape
                Buscar("", True)

        End Select

    End Sub

End Class