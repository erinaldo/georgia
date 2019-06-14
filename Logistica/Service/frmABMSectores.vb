Imports System.Data.OracleClient

Public Class frmABMSectores
    Private bpc As Cliente
    Private bpa As Sucursal
    Public sec As Sector2

    Public Sub New(ByVal bpc As Cliente, ByVal bpa As Sucursal)
        InitializeComponent()

        Me.bpc = bpc
        Me.bpa = bpa

    End Sub
    Public Sub New(ByVal id As Integer)
        InitializeComponent()
        sec = New Sector2(cn)

        sec.Abrir(id)
        bpc = sec.Cliente
        bpa = bpc.Sucursal(sec.SucursalId)

        txtNro.Text = sec.Numero
        txtNombre.Text = sec.Nombre

    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If Not EsValido() Then Exit Sub

        If sec Is Nothing Then
            sec = New Sector2(cn)
            sec.Nuevo(bpc.Codigo, bpa.Sucursal)
        End If

        sec.Numero = txtNro.Text
        sec.Nombre = txtNombre.Text
        sec.Grabar()

        Me.DialogResult = Windows.Forms.DialogResult.OK

    End Sub
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Public Function EsValido() As Boolean
        If txtNro.Text.Trim.Length <= 0 Then
            MessageBox.Show("Nro es requerido", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtNro.Focus()
            Return False
        End If

        If txtNombre.Text.Trim.Length <= 0 Then
            MessageBox.Show("Nombre es requerido", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtNombre.Focus()
            Return False
        End If

        Return True

    End Function

End Class