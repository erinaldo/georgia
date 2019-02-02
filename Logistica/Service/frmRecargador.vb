Public Class frmRecargador
    Private mLocal As MenuLocal
    Public Selecionado As Integer

    Public Sub New(ByRef mLocal As MenuLocal)
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        Me.mLocal = mLocal
        mLocal.Enlazar(lst)

        Seleccionar(1)

    End Sub
    Public Sub New(ByRef mLocal As MenuLocal, ByVal i As Integer)
        Me.New(mLocal)

        Seleccionar(i)

    End Sub
    Private Sub frmRecargador_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        mLocal = Nothing
    End Sub
    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Nuevo()
    End Sub
    Private Sub Nuevo()
        Dim str As String = "Escriba el nombre del recargador"
        Dim i As Integer

        str = InputBox(str, "Agregar Recargador")

        If str.Trim <> "" Then
            i = mLocal.Agregar(str)

            If i > 0 Then
                mLocal.Grabar()
                Seleccionar(i)
            End If

        End If

        lst.Focus()
    End Sub
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim dr As DataRowView

        If lst.SelectedItems.Count > 0 Then
            dr = CType(lst.SelectedItem, DataRowView)
            Selecionado = CInt(dr("lannum_0"))
            Me.DialogResult = Windows.Forms.DialogResult.OK
        End If

    End Sub
    Private Sub Seleccionar(ByVal n As Integer)
        Dim i As Integer
        Dim dr As DataRowView

        lst.ClearSelected()

        For i = 0 To lst.Items.Count - 1

            dr = CType(lst.Items(i), DataRowView)

            If CInt(dr("lannum_0")) = n Then
                lst.SelectedItem = lst.Items(i)
            End If

        Next

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmRecargador_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Insert Then Nuevo()
    End Sub

End Class