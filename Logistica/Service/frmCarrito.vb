Imports System.Data.OracleClient

Public Class frmCarrito
    Private Cant As Integer 'Cantidad de equipos que se debe retirar con la intervencion
    Private bpa As Sucursal 'Sucursal del cliente
    Private bar As Barrios
    Private cn As OracleConnection
    Private isLoad As Boolean = False
    Private Cart As Carrito

    Public Sub New(ByVal cn As OracleConnection, ByVal bpa As Sucursal, ByVal Cant As Integer, ByVal Fecha As Date)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        Dim fe As New Feriados(cn)
        Dim i As Integer = 0 'Dias que se adelanto la fecha mínima de carito

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.cn = cn
        Me.bpa = bpa
        Me.Cant = Cant

        Cart = New Carrito(Me.cn)

        txtCant.Text = Cant.ToString

        With mthFechas
            'Establezco la fecha minima a dos dia de la fecha de impresion
            .MinDate = Fecha

            'Si no es dia habil o es feriado voy corriendo la fecha un dia
            Do Until i = 2 'While .MinDate.DayOfWeek = DayOfWeek.Saturday OrElse .MinDate.DayOfWeek = DayOfWeek.Sunday OrElse fe.Existe(.MinDate)
                .MinDate = .MinDate.AddDays(1)

                If .MinDate.DayOfWeek = DayOfWeek.Saturday OrElse .MinDate.DayOfWeek = DayOfWeek.Sunday OrElse fe.Existe(.MinDate) Then

                Else
                    i += 1
                End If

            Loop
            'Establezco la fecha maxima a un mes de la fecha minima
            .MaxDate = .MinDate.AddMonths(1)
        End With

    End Sub
    Private Sub frmCarrito_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        bar = New Barrios(cn)

        MostrarCP(bpa.CodigoPostal)

        'Cargo todos los barrios
        If lstBarrios.Items.Count = 0 AndAlso txtCP.Text <> "" Then
            bar.BarriosTodos(lstBarrios)
            btnZonas.Enabled = False
        End If

        If lstBarrios.SelectedItems.Count > 0 Then MostrarCupo()

        isLoad = True

    End Sub
    Private Function EsCPValido(ByVal CodigoPostal As String) As Boolean
        Dim i As Integer
        Dim j As Integer = 0
        Dim flg As Boolean = True

        For i = 0 To CodigoPostal.Length - 1
            flg = IsNumeric(CodigoPostal.Substring(i, 1))
            If Not flg Then Exit For
            j += 1
        Next
        flg = (i = 4)
        Return flg
    End Function
    Private Sub MostrarCP(ByVal cp As String)
        Dim i As Integer
        Dim flg As Boolean = True
        Dim x As String = ""

        If cp.Trim.Length = 4 Then
            For i = 0 To cp.Length - 1
                x &= cp.Substring(i, 1)
                If Not IsNumeric(x) Then flg = False
                If Not flg Then Exit For
            Next
        Else
            For i = 1 To cp.Length - 1
                x &= cp.Substring(i, 1)
                If Not IsNumeric(x) Then flg = False
                If Not flg Then Exit For
                If x.Length = 4 Then Exit For
            Next

            If x.Length < 4 Then flg = False
        End If

        If flg Then
            txtCP.Text = x
            txtCP.Enabled = False
            bar.BarriosPorCP(txtCP.Text, lstBarrios)
        Else
            txtCP.Enabled = True
        End If

    End Sub
    Private Sub txtCP_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCP.Validating
        With txtCP
            If .Text.Length > 0 Then
                e.Cancel = Not EsCPValido(.Text)
            End If
        End With
    End Sub
    Private Sub txtCP_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCP.Validated
        bar.BarriosPorCP(txtCP.Text, lstBarrios)

        'Cargo todos los barrios
        If lstBarrios.Items.Count = 0 Then
            bar.BarriosTodos(lstBarrios)
            btnZonas.Enabled = False
            MostrarCupo()
        End If

    End Sub
    Private Sub lstBarrios_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstBarrios.SelectedIndexChanged
        If Not isLoad Then Exit Sub

        If lstBarrios.SelectedItem Is Nothing Then
            lblBarrio.Text = ""
            Exit Sub
        End If

        MostrarCupo()

    End Sub
    Private Sub MostrarCupo()

        With lstBarrios
            Dim dr As DataRow = CType(.SelectedItem, DataRowView).Row

            Cart.Abrir(CInt(lstBarrios.SelectedValue), mthFechas)

            mthFechas.Enabled = .SelectedItems.Count > 0
            mthFechas.SelectionRange.Start = Nothing
            mthFechas.SelectionRange.End = Nothing

            'Titulo del barrio seleccionado
            lblBarrio.Text = dr("nombre_0").ToString
        End With

        Cart.Cupo(Cant)

    End Sub
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim txt As String
        Dim f As Date = mthFechas.SelectionRange.Start

        If Not TieneCupo(f) Then
            txt = "No hay cupo para la fecha " & f.ToString("dd/MM/yyyy")
            MessageBox.Show(txt, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        If Not btnZonas.Enabled Then
            bar.Abrir(CInt(lstBarrios.SelectedValue))
            bar.AgregarCP(txtCP.Text)
        End If

        If txtCP.Enabled Then
            bpa.CodigoPostal = txtCP.Text
        End If

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
    Private Sub btnZonas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnZonas.Click
        bar.BarriosTodos(lstBarrios)
        btnZonas.Enabled = False
    End Sub
    Private Function TieneCupo(ByVal f As Date) As Boolean
        Dim d As Date() = mthFechas.BoldedDates
        Dim i As Integer
        Dim flg As Boolean = False

        For i = 0 To d.Length - 1
            If d(i) = f Then
                flg = True
                Exit For
            End If
        Next

        Return flg
    End Function

    Public ReadOnly Property Zona() As Integer
        Get
            Return Cart.Zona(mthFechas.SelectionRange.Start)
        End Get
    End Property
    Public ReadOnly Property Tipo() As Integer
        Get
            Return Cart.Tipo(mthFechas.SelectionRange.Start)
        End Get
    End Property

End Class