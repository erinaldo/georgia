Imports System.Data.OracleClient
Imports WSAFIP
Imports System.IO

Public Class frmFce
    Private fce As WSAFIP.RegistroFce

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        fce = New WSAFIP.RegistroFce("DNY")


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim Resp As wsfce.ConsultarMontoObligadoRecepcionReturnType

        Button1.Enabled = False

        If Cliente.CheckCuit(TextBox1.Text) Then

            Label2.Text = "Consultando con AFIP..."
            Application.DoEvents()
            Application.DoEvents()

            Resp = fce.ConsultarMontoObligado(CLng(TextBox1.Text))

            If Resp.obligado = wsfce.SiNoSimpleType.S Then
                Label2.Text = "Factura de Crédito: SI a partir de $" & Resp.montoDesde.ToString("N2")
            Else
                Label2.Text = "Factura de Crédito: NO"
            End If
        Else
            MessageBox.Show("CUIT Inválido")
            TextBox1.Focus()
        End If

        Button1.Enabled = True

    End Sub

End Class