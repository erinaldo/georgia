Imports Clases
Imports System.Data.OracleClient

Public Class frmMailsClientesMostrador

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        btnBuscar.Enabled = False
        Buscar()
        btnBuscar.Enabled = True
    End Sub
    Private Sub btnEnviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnviar.Click
        btnEnviar.Enabled = False
        Enviar()
        btnEnviar.Enabled = True
    End Sub
    Private Sub Buscar()
        Dim Sql As String
        Dim da As OracleDataAdapter
        Dim dt As DataTable

        Sql = "SELECT credat_0, num_0, bpr_0, bprnam_0, xweb_0, amtati_0  "
        Sql &= "FROM sinvoice "
        Sql &= "WHERE creusr_0 IN ('RECE', 'NZAMP') and "
        Sql &= "	  credat_0 >= :desde and "
        Sql &= "	  credat_0 <= :hasta and "
        Sql &= "	  invtyp_0 = 1 and "
        Sql &= "	  xweb_0 <> ' ' "
        Sql &= "ORDER BY credat_0, num_0"
        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("desde", OracleType.DateTime).Value = mCal.SelectionRange.Start
        da.SelectCommand.Parameters.Add("hasta", OracleType.DateTime).Value = mCal.SelectionRange.End

        If dgv.DataSource Is Nothing Then
            dt = New DataTable
        Else
            dt = CType(dgv.DataSource, DataTable)
        End If

        dt.Clear()
        da.Fill(dt)

        If dgv.DataSource Is Nothing Then
            colFecha.DataPropertyName = "credat_0"
            colComprobante.DataPropertyName = "num_0"
            colCliente.DataPropertyName = "bpr_0"
            colNombre.DataPropertyName = "bprnam_0"
            colMail.DataPropertyName = "xweb_0"
            colImporte.DataPropertyName = "amtati_0"
            dgv.DataSource = dt
        End If

    End Sub
    Private Sub Enviar()
        Dim dr As DataRow

        For Each c As DataGridViewRow In dgv.SelectedRows
            dr = CType(c.DataBoundItem, DataRowView).Row

            Enviar(dr("xweb_0").ToString)

        Next

        MessageBox.Show("Envío finalizado", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub
    Private Sub Enviar(ByVal Mail As String)
        Dim oMail As New CorreoElectronico

        oMail.Nuevo()
        oMail.Remitente("ventas@georgia.com.ar")
        oMail.AgregarDestinatario(Mail)
        oMail.EsHtml = True
        oMail.Asunto = "Calificá nuestra atención en Google y obtené un 20% de descuento"
        oMail.CuerpoDesdeArchivo("PLANTILLAS\calificanos-en-google.html")
        oMail.Enviar()
    End Sub

    Private Sub btnTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTest.Click
        Dim Mail As String

        Mail = InputBox("Ingrese la direccion de mail", Me.Text, "")

        Enviar(Mail)

    End Sub
End Class