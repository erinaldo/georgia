Imports System.Data.OracleClient

Public Class frmMFM

    Private Sub frmMFM_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargarCombo()

        DateTimePicker1.MinDate = Date.Today
    End Sub
    Private Sub CargarCombo()
        Dim da As New OracleDataAdapter("SELECT itmref_0, itmdes1_0 FROM itmmaster WHERE itmref_0 IN ('994006') ORDER BY itmdes1_0 desc", cn)
        Dim dt As New DataTable

        da.Fill(dt)
        da.Dispose()

        With cboTipo
            .DataSource = dt
            .ValueMember = "itmref_0"
            .DisplayMember = "itmdes1_0"
        End With

    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Dim f As New frmAutoCompleta
        f.ShowDialog(Me)
        Dim txt As String = f.texto

        Dim sql As String
        Sql = "SELECT bpc.bpcnum_0, bpc.bpcnam_0, bpaaddlig_0, bpc.rep_0, bpc.bpcpyr_0, pay.bpcnam_0 AS Administracion, bpa.bpaadd_0, bpc.xactiv_0 "
        sql &= "FROM ((bpcustomer bpc INNER JOIN bpartner bpr ON (bpc.bpcnum_0 = bpr.bprnum_0)) INNER JOIN bpaddress bpa ON (bpc.bpcnum_0 = bpa.bpanum_0 AND bpr.bpaadd_0 = bpa.bpaadd_0)) INNER JOIN bpcustomer pay ON (bpc.bpcpyr_0 = pay.bpcnum_0) "
        sql &= "WHERE bpc.bpcnum_0 = :bpc "
        sql &= " ORDER BY bpcpyr_0"

        Dim da As New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("bpc", OracleType.VarChar).Value = txt
        Dim dt As New DataTable


        btnBuscar.Enabled = False
        Me.UseWaitCursor = True

        Application.DoEvents()
        Application.DoEvents()

        da.Fill(dt)
        da.Dispose()
        colCodigo.DataPropertyName = "bpcnum_0"
        colConsorcio.DataPropertyName = "bpcnam_0"
        colDomicilio.DataPropertyName = "bpaaddlig_0"
        colVendedor.DataPropertyName = "rep_0"
        colCodigoAdmin.DataPropertyName = "bpcpyr_0"
        colAdministracion.DataPropertyName = "Administracion"
        colSuc.DataPropertyName = "bpaadd_0"
        activo.DataPropertyName = "xactiv_0"
        dgv.DataSource = dt
        
        btnBuscar.Enabled = True
        Me.UseWaitCursor = False

    End Sub


    Private Sub dgv_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv.SelectionChanged
        btnCrear.Enabled = (dgv.SelectedRows.Count = 1)
        cboTipo.Enabled = (dgv.SelectedRows.Count = 1)
        DateTimePicker1.Enabled = (dgv.SelectedRows.Count = 1)
    End Sub

    Private Sub btnCrear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCrear.Click
        If dgv.SelectedRows.Count <> 1 Then
            MessageBox.Show("Debe seleccionar un solo cliente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        End If
        'Obtengo la fila seleccionada
        Dim dr As DataRow = CType(dgv.SelectedRows(0).DataBoundItem, DataRowView).Row
        Dim dt As DataTable

        'Confirmo seleccion antes de crear parque
        Dim txt As String


        txt = "¿Confirma agendar {1} para la fecha {2} " & vbCrLf
        txt &= "y 11 meses posteriores a la sucursal {3}?"
        txt = Replace(txt, "{1}", cboTipo.Text)
        txt = Replace(txt, "{2}", DateTimePicker1.Value.ToString("MMMM yyyy"))
        txt = Replace(txt, "{3}", dr("bpaadd_0").ToString)

        If MessageBox.Show(txt, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then


            For cantidad As Integer = 0 To 12
                Dim mac As New Parque(cn)
                mac.Nuevo(dr("bpcnum_0").ToString, dr("bpaadd_0").ToString)
                mac.ArticuloCodigo = cboTipo.SelectedValue.ToString
                mac.VtoCarga = DateTimePicker1.Value.AddMonths(+cantidad) 'New Date(DateTimePicker1.Value.Year, DateTimePicker1.Value.Month + cantidad, 15)
                mac.Cantidad = 1
                mac.Cilindro = "CTRL-" & dr("bpcnum_0").ToString & "-" & dr("bpaadd_0").ToString
                mac.FabricacionCorto = Today.Year
                mac.Grabar()
            Next

            txt = "Se creo el parque por 12 meses"
            'txt = Replace(txt, "{serie}", mac.Serie)

            MessageBox.Show(txt, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)


            'Eliminar la linea de la tabla
            dt = CType(dgv.DataSource, DataTable)
            dt.Rows.Remove(dr)

        End If
    End Sub
End Class