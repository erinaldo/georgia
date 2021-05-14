Imports Clases

Public Class frmNd
    Private Fc As New Factura(cn)
    Private Nd As New Factura(cn)

    Private Sub btnAsociar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAsociar.Click
        'Valido que los campos no esten vacios
        If txtNd.Text.Trim = "" Or txtFc.Text.Trim = "" Then
            MessageBox.Show("Debe completar Nd y Fc", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        'Intento abrir la ND
        If Nd.Abrir(txtNd.Text.Trim) = False Then
            MessageBox.Show("No se pudo abrir la ND", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        'Valido que el cbte sea ND
        If Nd.TipoCbte <> 3 Then
            MessageBox.Show("El comprobante debe ser de tipo ND", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtNd.Focus()
            Exit Sub
        End If
        'Intento abrir la FC
        If Fc.Abrir(txtFc.Text.Trim) = False Then
            MessageBox.Show("No se pudo abrir la FC", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        If Fc.TipoCbte <> 1 Then
            MessageBox.Show("El comprobante debe ser de tipo FC", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtFc.Focus()
            Exit Sub
        End If
        'Valido que sean del mismo cliente
        If Fc.CodigoTercero <> Nd.CodigoTercero Then
            MessageBox.Show("Los comprobantes deben pertenecer al mismo cliente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        'Valido que los cbtes sean del mismo tipo (comun o credito)
        If Fc.AFIPTipoDoc.ToString.Length <> Nd.AFIPTipoDoc.ToString.Length Then
            MessageBox.Show("Los comprobantes deben ser del mismo tipo (Comun/MiPyME)", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        Asociar()

        MessageBox.Show("Comprobante asociado", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

        txtFc.Clear()
        txtNd.Clear()
        txtNd.Focus()

    End Sub
    Private Sub Asociar()

        Nd.TipoCbteOrigen = 4
        Nd.CbteOrigenNumero = Fc.Numero
        Nd.Grabar()

    End Sub

    Private Sub txtNd_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNd.TextChanged
        btnAsociar.Enabled = (txtNd.Text.Trim.Length > 0 And txtFc.Text.Trim.Length > 0)
    End Sub

    Private Sub txtFc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFc.TextChanged
        btnAsociar.Enabled = (txtNd.Text.Trim.Length > 0 And txtFc.Text.Trim.Length > 0)
    End Sub

End Class