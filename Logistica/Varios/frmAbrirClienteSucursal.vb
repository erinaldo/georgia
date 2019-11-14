Imports System.Data.OracleClient
Imports Clases

Public Class frmAbrirClienteSucursal
    Public bpc As Cliente
    Public bpa As Sucursal

    Private Sub txtCodigoCliente_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodigoCliente.Validated
        If bpc IsNot Nothing Then
            txtCliente.Text = bpc.Nombre
        Else
            txtCliente.Clear()
        End If

    End Sub
    Private Sub txtCodigoCliente_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodigoCliente.Validating
        Dim txt As TextBox
        txt = TryCast(sender, TextBox)

        If txt.Text.Trim <> "" Then
            If bpc Is Nothing Then bpc = New Cliente(cn)

            If Not bpc.Abrir(txt.Text.Trim) Then
                bpc = Nothing
                bpa = Nothing
                txtCliente.Clear()
                txtSucursal.Clear()

                MessageBox.Show("Cliente no encontrado", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                e.Cancel = True
            End If
        End If
    End Sub
    Private Sub txtCodigoSucursal_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodigoSucursal.Validated
        If bpa IsNot Nothing Then
            txtSucursal.Text = bpa.Direccion
        Else
            txtSucursal.Clear()
        End If
    End Sub
    Private Sub txtCodigoSucursal_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodigoSucursal.Validating
        Dim txt As TextBox
        txt = TryCast(sender, TextBox)

        If txt.Text.Trim <> "" Then
            If bpa Is Nothing Then bpa = New Sucursal(cn)

            If Not bpa.Abrir(bpc.Codigo, txtCodigoSucursal.Text.Trim) Then
                bpa = Nothing
                txtSucursal.Clear()

                MessageBox.Show("Sucursal no encontrada", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                e.Cancel = True
            End If
        End If
    End Sub
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If bpc Is Nothing OrElse bpa Is Nothing Then
            MessageBox.Show("Ingrese cliente y sucursal", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.DialogResult = Windows.Forms.DialogResult.Abort

        Else
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmAbrirClienteSucursal_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = Me.DialogResult = Windows.Forms.DialogResult.Abort
    End Sub
End Class