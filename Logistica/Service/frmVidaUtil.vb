Imports System.Data.OracleClient

Public Class frmVidaUtil
    Public Accion As TipoAccion
    Private mac As Parque

    Public Enum TipoAccion
        CambioAño
        Rechazar
        Procesar
    End Enum

    Public Sub New(ByVal mac As Parque)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        With NumericUpDown1
            .Minimum = 1599
            .Maximum = Today.Year
            .Value = mac.FabricacionCorto
        End With

        TextBox1.Text = mac.ArticuloDescripcion
        TextBox2.Text = mac.Cilindro
        TextBox3.Text = mac.TiempoVidaUtil.ToString
        TextBox4.Text = mac.FinVidaUtil.ToString

        Me.mac = mac

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCambiar.Click
        Cambiar()
    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRechazar.Click
        Rechazar()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesar.Click
        Procesar()
    End Sub

    Private Sub frmVidaUtil_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        Select Case e.KeyCode
            Case Keys.F5
                Procesar()
            Case Keys.F7
                Cambiar()
            Case Keys.F8
                Rechazar()
        End Select
    End Sub
    Private Sub Procesar()
        Accion = TipoAccion.Procesar
        Me.Close()
    End Sub
    Private Sub Cambiar()
        If Not mac.SimularVidaUtil(CInt(NumericUpDown1.Value)) Then
            Accion = TipoAccion.CambioAño
            Me.Close()

        Else
            MessageBox.Show("El equipo continúa vencido para el año de fabricación: " & NumericUpDown1.Value.ToString, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        End If
    End Sub
    Private Sub Rechazar()
        Accion = TipoAccion.Rechazar
        Me.Close()
    End Sub

End Class