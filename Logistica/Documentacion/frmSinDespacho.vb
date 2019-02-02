Imports System.Data.OracleClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class frmSinDespacho
    Private da As OracleDataAdapter
    Private dv As DataView

    Private Sub frmSinDespacho_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Sql As String

        AddHandler dgv.RowPostPaint, AddressOf NumeracionGrillas

        Sql = "SELECT shidat_0, sdhnum_0, bpcord_0, bpdnam_0, bpdaddlig_0, ' ' AS sector_0, ' ' AS fechaenvio_0, xruta_0, ' ' AS fecharuta_0, rep_0 "
        Sql &= "FROM sdelivery "
        Sql &= "WHERE lnd_0 = 1 And xsalio_0 <> 2 AND sdhnum_0 NOT IN (SELECT DISTINCT sdhnum_0 FROM sdeliveryd WHERE rtnqty_0 > 0)"
        Sql &= "ORDER BY shidat_0, sdhnum_0"

        da = New OracleDataAdapter(Sql, cn)

    End Sub
    Private Sub btnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizar.Click
        Actualizar()
    End Sub
    Private Sub Actualizar()
        Dim dt As DataTable

        btnActualizar.Enabled = False
        Me.UseWaitCursor = True
        Application.DoEvents()

        Try
            If dgv.DataSource Is Nothing Then
                dt = New DataTable

                da.Fill(dt)
                dv = New DataView(dt)

                colFecha.DataPropertyName = "shidat_0"
                colRemito.DataPropertyName = "sdhnum_0"
                colCodigo.DataPropertyName = "bpcord_0"
                colCliente.DataPropertyName = "bpdnam_0"
                colDireccion.DataPropertyName = "bpdaddlig_0"
                With colSector
                    .DataSource = Sectores(cn, , , True)
                    .DisplayMember = "texte_0"
                    .ValueMember = "ident2_0"
                    .DataPropertyName = "sector_0"
                End With
                colFechaEnvio.DataPropertyName = "fechaenvio_0"
                colRuta.DataPropertyName = "xruta_0"
                colFechaRuta.DataPropertyName = "fecharuta_0"
                colVendedor.DataPropertyName = "rep_0"

                dgv.DataSource = dv

            Else
                dt = CType(dgv.DataSource, DataView).Table
                dt.Clear()
                da.Fill(dt)

                txtFiltrar.Clear()
                Filtrar()

            End If

            BuscarSectorRemito(dt)
            BuscarFechaRuta(dt)
            ProcesarSinGestion(dt)

            txtFiltrar.Enabled = dt.Rows.Count > 0
            btnFiltrar.Enabled = dt.Rows.Count > 0

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            btnActualizar.Enabled = True
            Me.UseWaitCursor = False

        End Try

    End Sub
    Private Sub Filtrar()
        txtFiltrar.Text = txtFiltrar.Text.Trim

        If txtFiltrar.Text = "" Then
            dv.RowFilter = ""

        Else
            dv.RowFilter = "sdhnum_0 LIKE '%" & txtFiltrar.Text & "'"

        End If

        txtFiltrar.Clear()
        txtFiltrar.Focus()

    End Sub
    Private Sub btnFiltrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFiltrar.Click
        Filtrar()
    End Sub
    Private Sub txtFiltrar_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFiltrar.KeyUp
        If e.KeyCode = Keys.Enter Then Filtrar()
    End Sub

    Private Sub BuscarSectorRemito(ByVal dtOrigen As DataTable)
        'Por cada remito, consulta cual fue el ultimo sector donde estuvo
        Dim dr As DataRow
        Dim dt As New DataTable
        Dim da As OracleDataAdapter
        Dim txt As String

        txt = "SELECT * "
        txt &= "FROM xsegto "
        txt &= "WHERE rto_0 = :rto_0 "
        txt &= "ORDER BY fecha_0 DESC, hora_0 DESC"

        da = New OracleDataAdapter(txt, cn)
        da.SelectCommand.Parameters.Add("rto_0", OracleType.VarChar)

        For Each dr In dtOrigen.Rows
            da.SelectCommand.Parameters("rto_0").Value = dr("sdhnum_0").ToString
            dt.Clear()
            da.Fill(dt)

            If dt.Rows.Count > 0 Then
                dr.BeginEdit()
                dr("sector_0") = dt.Rows(0).Item("para_0").ToString
                dr("fechaenvio_0") = CDate(dt.Rows(0).Item("fecha_0")).ToString("dd/MM/yyyy")
                dr.EndEdit()
            End If
        Next

        dtOrigen.AcceptChanges()

    End Sub
    Private Sub BuscarFechaRuta(ByVal dtOrigen As DataTable)
        'Por cada remito, consulta cual fue el ultimo sector donde estuvo
        Dim dr As DataRow
        Dim dt As New DataTable
        Dim da As OracleDataAdapter
        Dim txt As String

        txt = "SELECT fecha_0 FROM xrutac WHERE ruta_0 = :ruta_0 "

        da = New OracleDataAdapter(txt, cn)
        da.SelectCommand.Parameters.Add("ruta_0", OracleType.Number)

        For Each dr In dtOrigen.Rows

            If dr("xruta_0").ToString <> " " Then

                da.SelectCommand.Parameters("ruta_0").Value = CInt(dr("xruta_0").ToString)
                dt.Clear()
                da.Fill(dt)

                If dt.Rows.Count > 0 Then
                    dr.BeginEdit()
                    dr("fecharuta_0") = CDate(dt.Rows(0).Item("fecha_0").ToString).ToString("dd/MM/yyyy")
                    dr.EndEdit()
                End If

            End If

        Next

        dtOrigen.AcceptChanges()

    End Sub
    Private Sub ProcesarSinGestion(ByVal dt As DataTable)
        Dim dr As DataRow
        Dim i As Integer
        Dim rto As New Remito(cn)

        For i = dt.Rows.Count - 1 To 0 Step -1
            dr = dt.Rows(i)
            If rto.Abrir(dr("sdhnum_0").ToString) Then
                If Not rto.MueveStock Then
                    rto.Despachado = True
                    rto.Grabar()

                    dt.Rows.Remove(dr)

                End If
            End If
        Next

    End Sub

    'EVENTOS DE MENU CONTEXTUAL
    Private Sub mnuContextMenu_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mnuContextMenu.Opening

        If dgv.CurrentRow Is Nothing Then e.Cancel = True

    End Sub
    Private Sub mnuVerDocumento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuVerDocumento.Click
        Dim rpt As New ReportDocument
        Dim f As frmCrystal
        Dim t As String = dgv.CurrentRow.Cells("colRemito").Value.ToString

        Try

            If t.StartsWith("DNY") Or t.StartsWith("MON") Then
                rpt.Load(RPTX3 & "BONLIV.rpt")
                rpt.SetParameterValue("livraisondeb", t)
                rpt.SetParameterValue("livraisonfin", t)

            Else
                rpt.Load(RPTX3 & "itn1.rpt")
                rpt.SetParameterValue("ITN", t)
                rpt.SetParameterValue("X3USR", Usr.Codigo)

            End If

            f = New frmCrystal(rpt)
            f.MdiParent = Me.ParentForm
            f.Show()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            rpt.Close()
            rpt.Dispose() : rpt = Nothing

        End Try

    End Sub

End Class