Imports System.Data.OracleClient
Public Class frmAutoCompleta
    Public texto As String

    Private Sub frmAutoCompleta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Top = CInt((Screen.PrimaryScreen.WorkingArea.Height - Me.Height) / 2)
        Me.Left = CInt((Screen.PrimaryScreen.WorkingArea.Width - Me.Width) / 2)
        cboxCliente.Select()
    End Sub
    Private Sub btnbuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnbuscar.Click
        If cboxCliente.Text.Trim <> "" Then
            'txtbCliente.Text = texto
            If IsNumeric(Microsoft.VisualBasic.Left(cboxCliente.Text, 6)) = True Then

                texto = Microsoft.VisualBasic.Left(cboxCliente.Text, 6)
            Else
                texto = Microsoft.VisualBasic.Right(cboxCliente.Text, 6)
            End If
            Me.Close()
        Else
            MsgBox("ingrese un valor")
        End If
        'If txtbCliente.Text.Trim <> "" Then
        '    'txtbCliente.Text = texto
        '    If IsNumeric(Microsoft.VisualBasic.Right(txtbCliente.Text, 6)) = True Then
        '        texto = Microsoft.VisualBasic.Right(txtbCliente.Text, 6)
        '    Else
        '        texto = Microsoft.VisualBasic.Left(txtbCliente.Text, 6)
        '    End If
        '    Me.Close()
        'Else
        '    MsgBox("ingrese un valor")
        'End If
    End Sub

    Private Sub cboxCliente_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboxCliente.Enter
        Dim cmd As New OracleCommand("select bprnum_0,bprnam_0 from bpartner", cn)
        Dim dt As New DataTable
        Dim da As New OracleDataAdapter(cmd)
        da.Fill(dt)
        Dim col As New AutoCompleteStringCollection
        Dim dr As DataRow
        For Each dr In dt.Rows
            col.Add(dr("bprnam_0").ToString & "-" & dr("bprnum_0").ToString)
            col.Add(dr("bprnum_0").ToString & "-" & dr("bprnam_0").ToString)
        Next
        'txtbCliente.AutoCompleteSource = AutoCompleteSource.CustomSource
        'txtbCliente.AutoCompleteCustomSource = col
        'txtbCliente.AutoCompleteMode = AutoCompleteMode.Suggest
        ' cboxCliente.DropDownStyle = ComboBoxStyle.DropDownList
        cboxCliente.AutoCompleteSource = AutoCompleteSource.CustomSource
        cboxCliente.AutoCompleteCustomSource = col
        cboxCliente.AutoCompleteMode = AutoCompleteMode.Suggest
    End Sub
End Class