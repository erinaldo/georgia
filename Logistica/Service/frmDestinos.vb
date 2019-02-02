Imports System.Data.OracleClient

Public Class frmDestinos
    Private prn As New Impresora(cn)
    Private x(2) As Integer
    Private y(2) As Integer
    Private campos(2) As String


    Private Sub frmDestinos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Cargo destinos en el ListBox
        CargarDestinos()

        campos(0) = "REC"
        campos(1) = "CIL"
        campos(2) = "PH"

    End Sub
    Private Sub CargarDestinos()
        Dim dt As New DataTable

        dt = prn.GetDestinos

        For Each dr As DataRow In dt.Rows
            If CInt(dr("enaflg_0")) = 2 Or dr("xprn_0").ToString.Trim = "" Then
                dr.Delete()
            End If
        Next
        dt.AcceptChanges()

        'Enlazo el resultado al ListBox
        With lstDestinos
            .DataSource = dt
            .DisplayMember = "des_0"
            .ValueMember = "cod_0"
        End With

    End Sub
    Private Sub lstDestinos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstDestinos.SelectedIndexChanged
        Dim cod As String

        cod = lstDestinos.SelectedValue.ToString

        If prn.Abrir(cod) Then
            ObtenerCoordenadas()
        End If

        btnRegistrar.Enabled = False
        btnCancelar.Enabled = False

    End Sub
    Private Sub ObtenerCoordenadas()

        For i As Integer = 0 To 2
            x(i) = prn.X(campos(i))
            y(i) = prn.Y(campos(i))
        Next

        txtRec.Text = prn.XY("REC")
        txtCil.Text = prn.XY("CIL")
        txtPh.Text = prn.XY("PH")

        tv.Value = 0
        th.Value = 0
        txtH.Clear()
        txtV.Clear()

        btnRegistrar.Enabled = False
        btnCancelar.Enabled = False

    End Sub
    Private Sub tv_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tv.Scroll
        txtV.Text = tv.Value.ToString
        MostrarNuevasCoordenadas()
    End Sub
    Private Sub th_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles th.Scroll
        txtH.Text = th.Value.ToString
        MostrarNuevasCoordenadas()
    End Sub
    Private Sub MostrarNuevasCoordenadas()
        Dim x(2) As Integer
        Dim y(2) As Integer

        For i As Integer = 0 To 2
            'Obtengo las coordenadas originales
            x(i) = Me.x(i)
            y(i) = Me.y(i)
            'Desplazo las coordenadas
            x(i) += tv.Value
            y(i) += th.Value

            'Muestro las coordenadas en los TextBox
            Select Case i
                Case 0 'REC
                    txtRec.Text = x(i).ToString & "," & y(i).ToString
                Case 1 'CIL
                    txtCil.Text = x(i).ToString & "," & y(i).ToString
                Case 2 'PH
                    txtPh.Text = x(i).ToString & "," & y(i).ToString
            End Select
        Next

        btnRegistrar.Enabled = True
        btnCancelar.Enabled = True

    End Sub
    Private Sub btnRegistrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegistrar.Click
        For i As Integer = 0 To 2
            prn.X(campos(i)) = prn.X(campos(i)) + tv.Value
            prn.Y(campos(i)) = prn.Y(campos(i)) + th.Value
        Next

        prn.Grabar()

        ObtenerCoordenadas()

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        ObtenerCoordenadas()
    End Sub
End Class