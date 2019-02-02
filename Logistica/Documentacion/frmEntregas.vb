Imports System.Data.OracleClient

Public Class frmEntregas
    Private da As OracleDataAdapter
    Private Rto As New Remito(cn)

    Private Sub frmDeposito_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Sql As String
        Dim dt As New DataTable

        AddHandler dgv.RowPostPaint, AddressOf NumeracionGrillas

        Sql = "SELECT sdhnum_0, bpcord_0, bpdnam_0, bpdaddlig_0, xsalio_0, xsaliousr_0, xsaliodat_0 FROM sdelivery WHERE lnd_0 = 1 AND sdhnum_0 = :sdhnum_0"
        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("sdhnum_0", OracleType.VarChar)
        da.UpdateCommand = New OracleCommandBuilder(da).GetUpdateCommand

        da.FillSchema(dt, SchemaType.Source)

        colRemtio.DataPropertyName = "sdhnum_0"
        colCodigo.DataPropertyName = "bpcord_0"
        colCliente.DataPropertyName = "bpdnam_0"
        colDireccion.DataPropertyName = "bpdaddlig_0"
        MenuLocal(cn, 1, colEntregado, True)
        colEntregado.DataPropertyName = "xsalio_0"
        colFecha.DataPropertyName = "xsaliodat_0"
        colUsuario.DataPropertyName = "xsaliousr_0"
        dgv.DataSource = dt

    End Sub
    Private Sub frmEntregas_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        da.Dispose()
    End Sub
    Private Sub txtRemito_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRemito.KeyUp
        If e.KeyCode = Keys.Enter Then
            txtRemito.Text = txtRemito.Text.ToUpper.Trim

            If txtRemito.Text <> "" Then

                'Miro si es remito suelto o numero de ruta
                If txtRemito.Text.Contains("RMR") Then
                    ProcesarRemito(txtRemito.Text)

                Else
                    If MessageBox.Show("¿Confirma el procesamiento de la HOJA DE RUTA nro. " & txtRemito.Text & "?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                        ProcesarRuta(txtRemito.Text)
                    End If

                End If

                txtRemito.Clear()

            End If

        End If
    End Sub
    Private Sub EliminarSiExisteEnGrilla(ByVal Rto As String)
        Dim dr As DataRow
        Dim dt As DataTable

        dt = CType(dgv.DataSource, DataTable)

        For Each dr In dt.Rows
            If dr("sdhnum_0").ToString = Rto Then
                dt.Rows.Remove(dr)
                Exit For
            End If
        Next

    End Sub
    Private Sub ProcesarRemito(ByVal Nro As String)
        Dim txt As String
        Dim dr As DataRow
        Dim dt As New DataTable

        'Si el remito está en la grilla, lo borro antes de procesarlo
        EliminarSiExisteEnGrilla(Nro)

        'Busco el remito en la tabla
        da.SelectCommand.Parameters("sdhnum_0").Value = Nro
        da.Fill(dt)

        If dt.Rows.Count = 1 Then 'El remito se encontro en la tabla

            dr = dt.Rows(0) 'Obtengo el registro

            Rto.Abrir(Nro)

            If Rto.RemitoDevuelto Then 'Si el remito tiene devolucion no se permite despachar
                txt = "No se puede despachar un remito con devolución"
                MessageBox.Show(txt, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub

            ElseIf CInt(dr("xsalio_0")) = 2 Then 'Miro si el usuario tiene permiso para desmarcar remitos

                If PermisoSecundario(cn, Usr.Codigo, Me.Tag.ToString, "0"c) Then
                    txt = "El remito {?rto} ya fue marcado como entregado el dia {?dia} por {?usr}" & vbCrLf & vbCrLf
                    txt &= "¿Desea quitar la marca?"
                    txt = txt.Replace("{?rto}", dr("sdhnum_0").ToString)
                    txt = txt.Replace("{?dia}", CDate(dr("xsaliodat_0")).ToString("dd/MM/yyyy"))
                    txt = txt.Replace("{?usr}", dr("xsaliousr_0").ToString)

                    If MessageBox.Show(txt, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                        dr.BeginEdit()
                        dr("xsalio_0") = 1
                        dr("xsaliousr_0") = Usr.Codigo
                        dr("xsaliodat_0") = Date.Today
                        dr.EndEdit()
                    End If

                Else
                    txt = "El remito {?rto} ya fue marcado como entregado el dia {?dia} por {?usr}" & vbCrLf & vbCrLf
                    txt &= "No tiene autorización para quitar marca de entrega. " & vbCrLf
                    txt &= "Se debe configurar el permiso secundario = 0 para habilitar la función"
                    txt = txt.Replace("{?rto}", dr("sdhnum_0").ToString)
                    txt = txt.Replace("{?dia}", CDate(dr("xsaliodat_0")).ToString("dd/MM/yyyy"))
                    txt = txt.Replace("{?usr}", dr("xsaliousr_0").ToString)

                    MessageBox.Show(txt, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub

                End If

            Else
                dr.BeginEdit()
                dr("xsalio_0") = 2
                dr("xsaliousr_0") = Usr.Codigo
                dr("xsaliodat_0") = Date.Today
                dr.EndEdit()

            End If

            Grabar(dt) 'Actualizo el registro del remito

            'Paso el remito actualizado a la tabla de la grilla
            dt = CType(dgv.DataSource, DataTable)
            dt.ImportRow(dr)

        Else 'No se encontro el remito en la tabla
            MessageBox.Show("No se encontró el remito", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtRemito.SelectAll()
            txtRemito.Focus()

        End If

    End Sub
    Private Sub ProcesarRuta(ByVal Ruta As String)
        Dim Sql As String
        Dim da As OracleDataAdapter
        Dim dt As New DataTable
        Dim dr As DataRow

        Sql = "SELECT * FROM xrutad WHERE ruta_0 = :ruta_0 AND tipo_0 IN ('NUE', 'NCI')"
        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("ruta_0", OracleType.Number).Value = CLng(Ruta)
        da.Fill(dt)

        For Each dr In dt.Rows
            ProcesarRemito(dr("vcrnum_0").ToString)
        Next
        da.Dispose()
        dt.Dispose()
    End Sub
    Private Sub Grabar(ByVal dt As DataTable)

        Try
            da.Update(dt)

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

End Class