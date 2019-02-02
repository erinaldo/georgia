Imports System.Data.OracleClient
Imports Clases

Public Class frmTransferencia

    Private Sub txtCliente1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCliente1.LostFocus
        If txtCliente1.Text.Trim = "" Then Exit Sub

        Dim bpc As New Cliente(cn)

        If bpc.Abrir(txtCliente1.Text) Then
            txtClienteDe.Text = bpc.Nombre
        Else
            MessageBox.Show("Cliente no encontrado", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtCliente1.Focus()
            txtCliente1.Clear()
            txtClienteDe.Clear()
            txtSucDe.Clear()
        End If

        bpc.Dispose()
        bpc = Nothing
    End Sub
    Private Sub txtCliente2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCliente2.LostFocus
        If txtCliente2.Text.Trim = "" Then Exit Sub

        Dim bpc As New Cliente(cn)

        If bpc.Abrir(txtCliente2.Text) Then
            txtClienteHacia.Text = bpc.Nombre
        Else
            MessageBox.Show("Cliente no encontrado", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtCliente2.Focus()
            txtCliente2.Clear()
            txtClienteHacia.Clear()
            txtSucHacia.Clear()
        End If

        bpc.Dispose()
        bpc = Nothing
    End Sub
    Private Sub txtSuc1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSuc1.LostFocus
        If txtSuc1.Text.Trim = "" Then Exit Sub

        Dim bpc As New Cliente(cn)

        If bpc.Abrir(txtCliente1.Text) AndAlso bpc.ExisteSucursal(txtSuc1.Text) Then
            txtSucDe.Text = bpc.Sucursal(txtSuc1.Text).Direccion
        Else
            MessageBox.Show("Sucursal no encontrada", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtSuc1.Focus()
            txtSuc1.SelectAll()
            txtSucDe.Clear()
        End If

        bpc.Dispose()
        bpc = Nothing
    End Sub
    Private Sub txtSuc2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSuc2.LostFocus
        If txtSuc2.Text.Trim = "" Then Exit Sub

        Dim bpc As New Cliente(cn)

        If bpc.Abrir(txtCliente2.Text) AndAlso bpc.ExisteSucursal(txtSuc2.Text) Then
            txtSucHacia.Text = bpc.Sucursal(txtSuc2.Text).Direccion
        Else
            MessageBox.Show("Sucursal no encontrada", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtSuc2.Focus()
            txtSuc2.SelectAll()
            txtSucHacia.Clear()
        End If

        bpc.Dispose()
        bpc = Nothing
    End Sub
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
    Private Sub btnTransferir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTransferir.Click

        If txtCliente1.Text.Trim = "" Then
            MessageBox.Show("Ingrese el cliente origen", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtCliente1.Focus()

        ElseIf txtCliente2.Text.Trim = "" Then
            MessageBox.Show("Ingrese el cliente destino", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtCliente2.Focus()

        ElseIf txtSuc1.Text.Trim = "" Then
            MessageBox.Show("Ingrese la sucursal origen", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtSuc1.Focus()

        ElseIf txtSuc2.Text.Trim = "" Then
            MessageBox.Show("Ingrese la sucursal destino", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtSuc2.Focus()

        ElseIf txtCliente1.Text.Trim = txtCliente2.Text.Trim And txtSuc1.Text.Trim = txtSuc2.Text.Trim Then
            MessageBox.Show("El cliente origen y destino no pueden ser iguales", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)

        Else

            Dim Sql As String
            Dim cm As OracleCommand
            Dim Obs As String
            Dim i As Integer

            Obs = Today.ToString("dd/MM/yy") & " - "
            Obs &= "Transferencia " & txtCliente1.Text & "/" & txtSuc1.Text & " -> "
            Obs &= txtCliente2.Text & "/" & txtSuc2.Text & " [" & usr.Codigo & "]"


            btnTransferir.Enabled = False
            Label3.Visible = True
            Application.DoEvents()

            Sql = "UPDATE ymacitm SET bpcnum_0 = :bpcnum_1 WHERE macnum_0 IN (SELECT macnum_0 FROM machines WHERE bpcnum_0 = :bpcnum_0 AND fcyitn_0 = :fcyitn_0)"
            cm = New OracleCommand(Sql, cn)
            cm.Parameters.Add("bpcnum_1", OracleType.VarChar).Value = txtCliente2.Text
            cm.Parameters.Add("bpcnum_0", OracleType.VarChar).Value = txtCliente1.Text
            cm.Parameters.Add("fcyitn_0", OracleType.VarChar).Value = txtSuc1.Text
            cm.ExecuteNonQuery()

            Sql = "UPDATE machines "
            Sql &= "SET bpcnum_0 = :bpcnum_1, fcyitn_0 = :fcyitn_1, ple_0 = :ple_0 "
            Sql &= "WHERE bpcnum_0 = :bpcnum_0 AND fcyitn_0 = :fcyitn_0"
            cm = New OracleCommand(Sql, cn)
            cm.Parameters.Add("bpcnum_1", OracleType.VarChar).Value = txtCliente2.Text
            cm.Parameters.Add("fcyitn_1", OracleType.VarChar).Value = txtSuc2.Text
            cm.Parameters.Add("bpcnum_0", OracleType.VarChar).Value = txtCliente1.Text
            cm.Parameters.Add("fcyitn_0", OracleType.VarChar).Value = txtSuc1.Text
            cm.Parameters.Add("ple_0", OracleType.VarChar).Value = Obs
            i = cm.ExecuteNonQuery()

            Sql = "UPDATE xsectores SET bpcnum_0 = :bpcnum_1, fcyitn_0 = :fcyitn_1 WHERE bpcnum_0 = :bpcnum_0 AND fcyitn_0 = :fcyitn_0"
            cm = New OracleCommand(Sql, cn)
            cm.Parameters.Add("bpcnum_1", OracleType.VarChar).Value = txtCliente2.Text
            cm.Parameters.Add("fcyitn_1", OracleType.VarChar).Value = txtSuc2.Text
            cm.Parameters.Add("bpcnum_0", OracleType.VarChar).Value = txtCliente1.Text
            cm.Parameters.Add("fcyitn_0", OracleType.VarChar).Value = txtSuc1.Text
            cm.ExecuteNonQuery()

            btnTransferir.Enabled = True
            Label3.Visible = False
            Application.DoEvents()

            Obs = "Transferencia finalizada. " & i.ToString & " equipo(s)"

            MessageBox.Show(Obs, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

    End Sub

End Class