Imports Clases
Imports System.Data.OracleClient

Public Class frmCorreo

    Private da As OracleDataAdapter
    Private cor As Correo
    Private sih As Factura
    Private dt As New DataTable
    Private ds As New DataSet

    Private Sub frmCorreo_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If ds.HasChanges Then
            Dim txt As String = ""

            txt = "No ha registrado los cambios" & vbCrLf & vbCrLf
            txt &= "¿Registra antes de salir?"

            Select Case MessageBox.Show(txt, Me.Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                Case Windows.Forms.DialogResult.Yes
                    Actualizar()

                Case Windows.Forms.DialogResult.No

                Case Windows.Forms.DialogResult.Cancel
                    e.Cancel = True

            End Select

        End If
    End Sub

    Private Sub frmCorreo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim Sql As String = ""

        ds.Tables.Add(dt)

        Sql = "SELECT * FROM xcorreo"
        da = New OracleDataAdapter(Sql, cn)
        da.InsertCommand = New OracleCommandBuilder(da).GetInsertCommand
        da.DeleteCommand = New OracleCommandBuilder(da).GetDeleteCommand
        da.UpdateCommand = New OracleCommandBuilder(da).GetUpdateCommand

        MenuLocal(cn, 1210, cboTipo)

        da.FillSchema(dt, SchemaType.Source)

        colNum.DataPropertyName = "num_0"
        colFecha.DataPropertyName = "dat_0"
        With colTipo
            .DataPropertyName = "typ_0"
            .DataSource = MenuLocal(cn, 1210)
            .DisplayMember = "lanmes_0"
            .ValueMember = "lannum_0"
        End With

        dgv.DataSource = dt

        cor = New Correo(cn)
        sih = New Factura(cn)

    End Sub

    Private Sub txtNum_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNum.KeyUp

        If e.KeyCode = Keys.Enter Then
            'Miro si la factura ya fue enviada
            If cor.Abrir(txtNum.Text) Then
                Dim txt As String

                If cor.UltimaFecha = Date.Today Then
                    txt = "El comprobante " & txtNum.Text & " ya fue enviado en el día de hoy"
                    MessageBox.Show(txt, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)

                Else
                    txt = "El comprobante " & txtNum.Text & " fue enviado el " & cor.UltimaFecha.ToString("dd/MM/yyyy") & vbCrLf & vbCrLf
                    txt &= "¿Desea volver a enviarlo?"

                    If MessageBox.Show(txt, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                        Agregar(txtNum.Text)
                    End If

                End If

            Else
                Agregar(txtNum.Text)

            End If

            txtNum.Clear()

        End If

    End Sub
    Private Sub Agregar(ByVal num As String)
        Dim dr As DataRow

        If sih.Abrir(num) Then
            dr = dt.NewRow

            dr("num_0") = num
            dr("dat_0") = Date.Today
            dr("typ_0") = CInt(cboTipo.SelectedValue)
            dt.Rows.Add(dr)

            Actualizar()

        Else
            MessageBox.Show("No se encontro el comprobante", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End If

    End Sub

    Private Sub Actualizar()
        da.Update(dt)
    End Sub

    Private Sub cmdRegistrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRegistrar.Click
        Actualizar()
    End Sub

End Class