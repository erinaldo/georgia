Imports System.Data.OracleClient
Public Class AltaProspecto

    Private Sub AltaProspecto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        carga()
    End Sub
    Private Sub carga()
        Dim dt As DataTable
        Dim dt1 As DataTable
        txtboxCodigo.Text = ""

        Dim tb As New TablaVaria(cn, 31)
        cmbox.DataSource = tb.Tabla2
        cmbox.ValueMember = ("ident2_0")
        cmbox.DisplayMember = ("texte_0")
        cmbox.SelectedValue = 0

        Dim tb1 As New TablaVaria(cn, 1002)
        cmboxTipoDni.DataSource = tb1.Tabla2
        cmboxTipoDni.ValueMember = ("ident2_0")
        cmboxTipoDni.DisplayMember = ("texte_0")
        cmboxTipoDni.SelectedValue = 0
        txtboxNumeroDni.MaxLength = 11

        dt = tb1.Tabla2
        For i = dt.Rows.Count - 1 To 0 Step -1
            Dim dr As DataRow
            dr = dt.Rows(i)
            If dr("ident2_0").ToString <> "80" And dr("ident2_0").ToString <> "96" Then dt.Rows.Remove(dr)
        Next
        Dim tb2 As New TablaVaria(cn, 30)
        cmboxFliaEst1.DataSource = tb2.Tabla2
        cmboxFliaEst1.ValueMember = ("ident2_0")
        cmboxFliaEst1.DisplayMember = ("texte_0")
        cmboxFliaEst1.SelectedValue = 0

        Dim tb3 As New TablaVaria(cn, 31)
        cmboxFliaEst2.DataSource = tb3.Tabla2
        cmboxFliaEst2.ValueMember = ("ident2_0")
        cmboxFliaEst2.DisplayMember = ("texte_0")
        cmboxFliaEst2.SelectedValue = 0

        Dim tb4 As New TablaVaria(cn, 32)
        cmboxFliaEst3.DataSource = tb4.Tabla2
        cmboxFliaEst3.ValueMember = ("ident2_0")
        cmboxFliaEst3.DisplayMember = ("texte_0")
        cmboxFliaEst3.SelectedValue = 0

        Dim tb5 As New TablaVaria(cn, 364)
        cmboxProvincia.DataSource = tb5.Tabla2
        cmboxProvincia.ValueMember = ("ident2_0")
        cmboxProvincia.DisplayMember = ("texte_0")
        cmboxProvincia.SelectedValue = 0

        Dim tb6 As New TablaVaria(cn, 1)
        cmboxIVA.DataSource = tb6.Tabla2
        cmboxIVA.ValueMember = ("ident2_0")
        cmboxIVA.DisplayMember = ("texte_0")
        dt1 = tb6.Tabla2
        For i = dt1.Rows.Count - 1 To 0 Step -1
            Dim dr As DataRow
            dr = dt1.Rows(i)
            If dr("ident2_0").ToString <> "CF" And dr("ident2_0").ToString <> "EP" And dr("ident2_0").ToString <> "EX" And dr("ident2_0").ToString <> "RI" And dr("ident2_0").ToString <> "RIE" And dr("ident2_0").ToString <> "RM" Then dt1.Rows.Remove(dr)
        Next
        cmboxIVA.SelectedValue = 0
        Vendedor.Enlazar_sin_cobranzas(cn, cmboxRep, True)


        CondicionPago.LlenarComboBox(cn, cmboxCondicionPago)
        cmboxCondicionPago.SelectedValue = 0
    End Sub
    Private Function tipo_cliente(ByVal tipo As String) As Integer
        txtboxCodigo.Text = ""
        Dim inicio As Integer = 0
        Dim fin As Integer = 0
        Dim cli As New Cliente(cn)
        Dim da As OracleDataAdapter
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim sql As String = "select bpcnum_0 from bpcustomer where tsccod_1 = :tipo"
        da = New OracleDataAdapter(sql, cn)
        da.SelectCommand.Parameters.Add("tipo", OracleType.VarChar).Value = tipo ' & "%"
        da.Fill(dt)
        dr = dt.Rows(0)
        Select Case tipo
            Case "10"
                Dim Dv As New DataView(dt)
                inicio = 102001
                fin = 110000
                While inicio < fin
                    Dv.RowFilter = "bpcnum_0 ='" & inicio & "'"
                    If Dv.Count = 0 Then
                        If cli.Abrir(inicio.ToString) = False Then
                            Return inicio
                        Else
                            inicio = inicio + 1
                        End If
                    Else
                        inicio = inicio + 1
                    End If
                End While
            Case "11"
                inicio = 118001
                fin = 200000
                Dim Dv As New DataView(dt)
                While inicio < fin
                    Dv.RowFilter = "bpcnum_0 ='" & inicio & "'"
                    If Dv.Count = 0 Then
                        If cli.Abrir(inicio.ToString) = False Then
                            Return inicio
                        Else
                            inicio = inicio + 1
                        End If
                    Else
                        inicio = inicio + 1
                    End If
                End While
            Case "20"
                inicio = 203001
                fin = 300000
                Dim Dv As New DataView(dt)
                While inicio < fin
                    Dv.RowFilter = "bpcnum_0 ='" & inicio & "'"
                    If Dv.Count = 0 Then
                        If cli.Abrir(inicio.ToString) = False Then
                            Return inicio
                        Else
                            inicio = inicio + 1
                        End If
                    Else
                        inicio = inicio + 1
                    End If
                End While
            Case "30"
                inicio = 305001
                fin = 400000
                Dim Dv As New DataView(dt)
                While inicio < fin
                    Dv.RowFilter = "bpcnum_0 ='" & inicio & "'"
                    If Dv.Count = 0 Then
                        If cli.Abrir(inicio.ToString) = False Then
                            Return inicio
                        Else
                            inicio = inicio + 1
                        End If
                    Else
                        inicio = inicio + 1
                    End If
                End While
            Case "40"
                inicio = 407001
                fin = 500000
                Dim Dv As New DataView(dt)
                While inicio < fin
                    Dv.RowFilter = "bpcnum_0 ='" & inicio & "'"
                    If Dv.Count = 0 Then
                        If cli.Abrir(inicio.ToString) = False Then
                            Return inicio
                        Else
                            inicio = inicio + 1
                        End If
                    Else
                        inicio = inicio + 1
                    End If
                End While
            Case "50"
                inicio = 509001
                fin = 600000
                Dim Dv As New DataView(dt)
                While inicio < fin
                    Dv.RowFilter = "bpcnum_0 ='" & inicio & "'"
                    If Dv.Count = 0 Then
                        If cli.Abrir(inicio.ToString) = False Then
                            Return inicio
                        Else
                            inicio = inicio + 1
                        End If
                    Else
                        inicio = inicio + 1
                    End If
                End While
            Case "60"
                inicio = 628000
                fin = 700000
                Dim Dv As New DataView(dt)
                While inicio < fin
                    Dv.RowFilter = "bpcnum_0 ='" & inicio & "'"
                    If Dv.Count = 0 Then
                        If cli.Abrir(inicio.ToString) = False Then
                            Return inicio
                        Else
                            inicio = inicio + 1
                        End If
                    Else
                        inicio = inicio + 1
                    End If
                End While
            Case "70"
                inicio = 707001
                fin = 800000
                Dim Dv As New DataView(dt)
                While inicio < fin
                    Dv.RowFilter = "bpcnum_0 ='" & inicio & "'"
                    If Dv.Count = 0 Then
                        If cli.Abrir(inicio.ToString) = False Then
                            Return inicio
                        Else
                            inicio = inicio + 1
                        End If
                    Else
                        inicio = inicio + 1
                    End If
                End While
            Case "80"
                inicio = 809001
                fin = 900000
                Dim Dv As New DataView(dt)
                While inicio < fin
                    Dv.RowFilter = "bpcnum_0 ='" & inicio & "'"
                    If Dv.Count = 0 Then
                        If cli.Abrir(inicio.ToString) = False Then
                            Return inicio
                        Else
                            inicio = inicio + 1
                        End If
                    Else
                        inicio = inicio + 1
                    End If
                End While
            Case "90"
                inicio = 900500
                fin = 999999
                Dim Dv As New DataView(dt)
                While inicio < fin
                    Dv.RowFilter = "bpcnum_0 ='" & inicio & "'"
                    If Dv.Count = 0 Then
                        If cli.Abrir(inicio.ToString) = False Then
                            Return inicio
                        Else
                            inicio = inicio + 1
                        End If
                    Else
                        inicio = inicio + 1
                    End If
                End While
        End Select


        ' Return CInt(dr("comp")) + 1

    End Function
    Private Sub cmbox_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbox.SelectionChangeCommitted
        Select Case cmbox.SelectedValue.ToString
            Case "10"
                txtboxCodigo.Text = tipo_cliente("10").ToString
                cmboxFliaEst2.SelectedValue = "10"
                cmboxFliaEst1.SelectedValue = "CP"

            Case "11"
                txtboxCodigo.Text = tipo_cliente("11").ToString
                cmboxFliaEst2.SelectedValue = "11"
                cmboxFliaEst1.SelectedValue = "CP"

            Case "20"
                txtboxCodigo.Text = tipo_cliente("20").ToString
                cmboxFliaEst2.SelectedValue = "20"
                cmboxFliaEst1.SelectedValue = "CP"

            Case "30"
                txtboxCodigo.Text = tipo_cliente("30").ToString
                cmboxFliaEst2.SelectedValue = "30"
                cmboxFliaEst1.SelectedValue = "CP"

            Case "40"
                txtboxCodigo.Text = tipo_cliente("40").ToString
                cmboxFliaEst2.SelectedValue = "40"
                cmboxFliaEst1.SelectedValue = "CP"

            Case "50"
                txtboxCodigo.Text = tipo_cliente("50").ToString
                cmboxFliaEst2.SelectedValue = "50"
                cmboxFliaEst1.SelectedValue = "CP"

            Case "60"
                txtboxCodigo.Text = tipo_cliente("60").ToString
                cmboxFliaEst2.SelectedValue = "60"
                cmboxFliaEst1.SelectedValue = "CP"

            Case "70"
                txtboxCodigo.Text = tipo_cliente("70").ToString
                cmboxFliaEst2.SelectedValue = "70"
                cmboxFliaEst1.SelectedValue = "CP"

            Case "80"
                txtboxCodigo.Text = tipo_cliente("80").ToString
                cmboxFliaEst2.SelectedValue = "80"
                cmboxFliaEst1.SelectedValue = "CP"

            Case "90"
                txtboxCodigo.Text = tipo_cliente("90").ToString
                cmboxFliaEst2.SelectedValue = "90"
                cmboxFliaEst1.SelectedValue = "CP"

        End Select
        Select Case cmboxRep.SelectedValue.ToString
            Case "03"
                If cmbox.SelectedValue.ToString = "20" Then
                    cmboxComision.SelectedValue = "6"
                Else
                    cmboxComision.SelectedValue = "1"
                End If
            Case "05"
                If cmbox.SelectedValue.ToString = "20" Then
                    cmboxComision.SelectedValue = "18"
                Else
                    cmboxComision.SelectedValue = "17"
                End If
            Case "06"
                If cmbox.SelectedValue.ToString = "20" Then
                    cmboxComision.SelectedValue = "03"
                Else
                    cmboxComision.SelectedValue = "08"
                End If
            Case "08"
                If cmbox.SelectedValue.ToString = "20" Then
                    cmboxComision.SelectedValue = "02"
                Else
                    cmboxComision.SelectedValue = "07"
                End If
            Case "09"
                If cmbox.SelectedValue.ToString = "20" Then
                    cmboxComision.SelectedValue = "02"
                Else
                    cmboxComision.SelectedValue = "07"
                End If
            Case "13"
                If cmbox.SelectedValue.ToString = "20" Then
                    cmboxComision.SelectedValue = "02"
                Else
                    cmboxComision.SelectedValue = "07"
                End If
            Case "14"
                If cmbox.SelectedValue.ToString = "20" Then
                    'cmboxComision.SelectedValue = "02"
                    cmboxComision.SelectedValue = "07"
                Else
                    'cmboxComision.SelectedValue = "07"
                    cmboxComision.SelectedValue = "02"
                End If
            Case "10"
                If cmbox.SelectedValue.ToString = "20" Then
                    cmboxComision.SelectedValue = "20"
                Else
                    cmboxComision.SelectedValue = "20"
                End If
            Case "17"
                If cmbox.SelectedValue.ToString = "20" Then
                    cmboxComision.SelectedValue = "20"
                Else
                    cmboxComision.SelectedValue = "20"
                End If
            Case "19"
                If cmbox.SelectedValue.ToString = "20" Then
                    cmboxComision.SelectedValue = "20"
                Else
                    cmboxComision.SelectedValue = "20"
                End If
            Case "12"
                If cmbox.SelectedValue.ToString = "20" Then
                    cmboxComision.SelectedValue = "19"
                Else
                    cmboxComision.SelectedValue = "19"
                End If
            Case "15"
                If cmbox.SelectedValue.ToString = "20" Then
                    cmboxComision.SelectedValue = "16"
                Else
                    cmboxComision.SelectedValue = "16"
                End If
            Case "16"
                If cmbox.SelectedValue.ToString = "20" Then
                    cmboxComision.SelectedValue = "10"
                Else
                    cmboxComision.SelectedValue = "10"
                End If
            Case "20"
                If cmbox.SelectedValue.ToString = "20" Then
                    cmboxComision.SelectedValue = "05"
                Else
                    cmboxComision.SelectedValue = "05"
                End If
            Case "21"
                If cmbox.SelectedValue.ToString = "20" Then
                    cmboxComision.SelectedValue = "05"
                Else
                    cmboxComision.SelectedValue = "05"
                End If
            Case "24"
                If cmbox.SelectedValue.ToString = "20" Then
                    cmboxComision.SelectedValue = "05"
                Else
                    cmboxComision.SelectedValue = "05"
                End If
            Case "27"
                If cmbox.SelectedValue.ToString = "20" Then
                    cmboxComision.SelectedValue = "05"
                Else
                    cmboxComision.SelectedValue = "05"
                End If
            Case "29"
                If cmbox.SelectedValue.ToString = "20" Then
                    cmboxComision.SelectedValue = "05"
                Else
                    cmboxComision.SelectedValue = "05"
                End If

            Case "30"
                If cmbox.SelectedValue.ToString = "20" Then
                    cmboxComision.SelectedValue = "05"
                Else
                    cmboxComision.SelectedValue = "05"
                End If
            Case "28"
                If cmbox.SelectedValue.ToString = "20" Then
                    cmboxComision.SelectedValue = "21"
                Else
                    cmboxComision.SelectedValue = "21"
                End If
            Case "18"
                If cmbox.SelectedValue.ToString = "20" Then
                    cmboxComision.SelectedValue = "4"
                Else
                    cmboxComision.SelectedValue = "4"
                End If
            Case "01"
                cmboxComision.SelectedValue = "12"
            Case "02"
                cmboxComision.SelectedValue = "12"
            Case "04"
                cmboxComision.SelectedValue = "12"
            Case "07"
                cmboxComision.SelectedValue = "12"
            Case "11"
                cmboxComision.SelectedValue = "12"
            Case "22"
                cmboxComision.SelectedValue = "12"
            Case "23"
                cmboxComision.SelectedValue = "12"
            Case "25"
                cmboxComision.SelectedValue = "12"
            Case "26"
                cmboxComision.SelectedValue = "12"
        End Select
        If chkterceroPagador.Checked = False Then
            txtboxTercPagador.Text = txtboxCodigo.Text
        End If
        Estado_Controles()
    End Sub
    Private Sub Estado_Controles()
        If txtboxCodigo.Text <> "" Then
            txtboxNombre.Enabled = True
            txtboxNomFantasia.Enabled = True
            cmboxTipoDni.Enabled = True
            txtboxNumeroDni.Enabled = True
            cmboxRep.Enabled = True
            cmboxFliaEst1.Enabled = True
            cmboxFliaEst2.Enabled = True
            cmboxFliaEst3.Enabled = True
            btnRegistrar.Enabled = True
            txtboxCodigo.Enabled = True
            txtboxDireccion.Enabled = True
            txtboxAltura.Enabled = True
            txtboxCP.Enabled = True
            txtboxNombre.Enabled = True
            cmboxCondicionPago.Enabled = True
            cmboxProvincia.Enabled = True
            txtboxCiudad.Enabled = True
            txtboxTel.Enabled = True
            txtboxTrasporte.Enabled = True
            CheckBox1.Enabled = True
            txtboxmail.Enabled = True
            cmboxIVA.Enabled = True
        Else
            txtboxNombre.Enabled = False
            txtboxNomFantasia.Enabled = False
            cmboxTipoDni.Enabled = False
            txtboxNumeroDni.Enabled = False
            cmboxRep.Enabled = False
            cmboxFliaEst1.Enabled = False
            cmboxFliaEst2.Enabled = False
            cmboxFliaEst3.Enabled = False
            btnRegistrar.Enabled = False
            txtboxCodigo.Enabled = False
            txtboxDireccion.Enabled = False
            txtboxAltura.Enabled = False
            txtboxCP.Enabled = False
            txtboxNombre.Enabled = False
            cmboxCondicionPago.Enabled = False
            cmboxComision.Enabled = False
            cmboxProvincia.Enabled = False
            txtboxCiudad.Enabled = False
            txtboxTel.Enabled = False
            txtboxTrasporte.Enabled = False
            CheckBox1.Enabled = False
            txtboxmail.Enabled = False
            cmboxIVA.Enabled = False
          
        End If
    End Sub
    Private Sub cmboxRep_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmboxRep.SelectionChangeCommitted
        'Dim dt As DataTable
        Dim mnu4 = New MenuLocal(cn, 403, True)
        mnu4.Enlazar(cmboxComision)

        Select Case cmboxRep.SelectedValue.ToString
            Case "03"
                If cmbox.SelectedValue.ToString = "20" Then
                    cmboxComision.SelectedValue = "06"
                Else
                    cmboxComision.SelectedValue = "01"
                End If
            Case "05"
                If cmbox.SelectedValue.ToString = "20" Then
                    cmboxComision.SelectedValue = "18"
                Else
                    cmboxComision.SelectedValue = "17"
                End If
            Case "06"
                If cmbox.SelectedValue.ToString = "20" Then
                    cmboxComision.SelectedValue = "08"
                Else
                    cmboxComision.SelectedValue = "03"
                End If
            Case "08"
                If cmbox.SelectedValue.ToString = "20" Then
                    cmboxComision.SelectedValue = "07"
                Else
                    cmboxComision.SelectedValue = "02"
                End If
            Case "09"
                If cmbox.SelectedValue.ToString = "20" Then
                    cmboxComision.SelectedValue = "07"
                Else
                    cmboxComision.SelectedValue = "02"
                End If
            Case "13"
                If cmbox.SelectedValue.ToString = "20" Then
                    cmboxComision.SelectedValue = "07"
                Else
                    cmboxComision.SelectedValue = "02"
                End If
            Case "14"
                If cmbox.SelectedValue.ToString = "20" Then
                    cmboxComision.SelectedValue = "07"
                Else
                    cmboxComision.SelectedValue = "02"
                End If
            Case "10"
                If cmbox.SelectedValue.ToString = "20" Then
                    cmboxComision.SelectedValue = "20"
                Else
                    cmboxComision.SelectedValue = "20"
                End If
            Case "17"
                If cmbox.SelectedValue.ToString = "20" Then
                    cmboxComision.SelectedValue = "20"
                Else
                    cmboxComision.SelectedValue = "20"
                End If
            Case "19"
                If cmbox.SelectedValue.ToString = "20" Then
                    cmboxComision.SelectedValue = "20"
                Else
                    cmboxComision.SelectedValue = "20"
                End If
            Case "12"
                If cmbox.SelectedValue.ToString = "20" Then
                    cmboxComision.SelectedValue = "19"
                Else
                    cmboxComision.SelectedValue = "19"
                End If
            Case "15"
                If cmbox.SelectedValue.ToString = "20" Then
                    cmboxComision.SelectedValue = "16"
                Else
                    cmboxComision.SelectedValue = "16"
                End If
            Case "16"
                If cmbox.SelectedValue.ToString = "20" Then
                    cmboxComision.SelectedValue = "10"
                Else
                    cmboxComision.SelectedValue = "10"
                End If
            Case "20"
                If cmbox.SelectedValue.ToString = "20" Then
                    cmboxComision.SelectedValue = "05"
                Else
                    cmboxComision.SelectedValue = "05"
                End If
            Case "21"
                If cmbox.SelectedValue.ToString = "20" Then
                    cmboxComision.SelectedValue = "05"
                Else
                    cmboxComision.SelectedValue = "05"
                End If
            Case "24"
                If cmbox.SelectedValue.ToString = "20" Then
                    cmboxComision.SelectedValue = "05"
                Else
                    cmboxComision.SelectedValue = "05"
                End If
            Case "25"
                If cmbox.SelectedValue.ToString = "20" Then
                    cmboxComision.SelectedValue = "06"
                ElseIf cmbox.SelectedValue.ToString = "50" Then
                    cmboxComision.SelectedValue = "04"
                Else
                    cmboxComision.SelectedValue = "01"
                End If
            Case "27"
                If cmbox.SelectedValue.ToString = "20" Then
                    cmboxComision.SelectedValue = "05"
                Else
                    cmboxComision.SelectedValue = "05"
                End If
            Case "29"
                If cmbox.SelectedValue.ToString = "20" Then
                    cmboxComision.SelectedValue = "05"
                Else
                    cmboxComision.SelectedValue = "05"
                End If

            Case "30"
                If cmbox.SelectedValue.ToString = "20" Then
                    cmboxComision.SelectedValue = "05"
                Else
                    cmboxComision.SelectedValue = "05"
                End If
            Case "28"
                If cmbox.SelectedValue.ToString = "20" Then
                    cmboxComision.SelectedValue = "21"
                Else
                    cmboxComision.SelectedValue = "21"
                End If
            Case "18"
                If cmbox.SelectedValue.ToString = "20" Then
                    cmboxComision.SelectedValue = "4"
                Else
                    cmboxComision.SelectedValue = "4"
                End If
            Case "01"
                cmboxComision.SelectedValue = "12"
            Case "02"
                cmboxComision.SelectedValue = "12"
            Case "04"
                cmboxComision.SelectedValue = "12"
            Case "07"
                cmboxComision.SelectedValue = "12"
            Case "11"
                cmboxComision.SelectedValue = "12"
            Case "22"
                cmboxComision.SelectedValue = "12"
            Case "23"
                cmboxComision.SelectedValue = "12"
            Case "26"
                cmboxComision.SelectedValue = "12"
        End Select
    End Sub
    Private Sub cmboxTipoDni_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmboxTipoDni.SelectionChangeCommitted
        If cmboxTipoDni.SelectedValue.ToString = "96" Then txtboxNumeroDni.MaxLength = 8
    End Sub
    Private Sub cmboxProvincia_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmboxProvincia.SelectionChangeCommitted
        If cmboxProvincia.SelectedValue.ToString = "CFE" Then
            txtboxCiudad.Text = "CAPITAL FEDERAL"
        Else
            txtboxCiudad.Text = ""
        End If

    End Sub
End Class