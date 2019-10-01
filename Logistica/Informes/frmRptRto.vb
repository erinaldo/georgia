Imports System.Data.OracleClient
Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO

Public Class frmRptRto
    Private dv As DataView

    Private Function CalcularCantidad(ByVal Sector As String) As Integer
        Dim Sql As String
        Dim da As OracleDataAdapter
        Dim dt As New DataTable

        Sql = "SELECT * "
        Sql &= "FROM sdelivery "
        Sql &= "WHERE lnd_0 = 1 AND "
        Sql &= "      xsalio_0 <> 2 AND "
        Sql &= "      sdhnum_0 NOT IN (SELECT DISTINCT sdhnum_0 FROM sdeliveryd WHERE rtnqty_0 > 0) AND "
        Sql &= "      xsector_0 = :sector "

        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("sector", OracleType.VarChar).Value = Sector
        da.Fill(dt)

        If Sector = "ADM" Then
            da.SelectCommand.Parameters("sector").Value = " "
            da.Fill(dt)
        End If

        Return dt.Rows.Count

    End Function
    Private Function datos(ByVal sector As String) As DataTable
        Dim Sql As String
        Dim da As OracleDataAdapter
        Dim dt As New DataTable

        Sql = "SELECT dlvdat_0 as FechaRemito, "
        Sql &= "      sdhnum_0 as numero, "
        Sql &= "      (sdh.bpcord_0 || ' - ' || sdh.bpdnam_0) as cliente, "
        Sql &= "      sdh.bpdaddlig_0 as direccion, "
        Sql &= "      sdh.rep_0 as Vendedor, "
        Sql &= "      sdh.xsector_0 as sector, "
        Sql &= "      sysdate AS fechaenvio,"
        Sql &= "      xruta_0 as ruta, "
        Sql &= "      sysdate as fecharuta, "
        Sql &= "      xobserva_0 as obs, "
        Sql &= "      ordinvati_0 as Importe, "
        Sql &= "      sdh.sohnum_0 as pedido "
        Sql &= "FROM sdelivery sdh left join "
        Sql &= "     sorder soh on (sdh.sohnum_0 = soh.sohnum_0) "
        Sql &= "WHERE lnd_0 = 1 And "
        Sql &= "      xsalio_0 <> 2 AND "
        Sql &= "      sdhnum_0 NOT IN (SELECT DISTINCT sdhnum_0 FROM sdeliveryd WHERE rtnqty_0 > 0) and "

        If sector = "ADM" Then
            Sql &= "     (sdh.xsector_0 = :sector or sdh.xsector_0 = ' ') "
        Else
            Sql &= "      sdh.xsector_0 = :sector "
        End If

        Sql &= "order by dlvdat_0 "

        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("sector", OracleType.VarChar).Value = sector
        da.Fill(dt)

        For Each dr As DataRow In dt.Rows
            dr.BeginEdit()
            dr("fechaenvio") = DBNull.Value
            dr("fecharuta") = DBNull.Value
            dr.EndEdit()
        Next
        dt.AcceptChanges()

        Return dt
    End Function
    Private Sub btnCalcular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalcular.Click
        btnCalcular.Enabled = False
        Cantidad()
        btnCalcular.Enabled = True
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
            da.SelectCommand.Parameters("rto_0").Value = dr("numero").ToString
            dt.Clear()
            da.Fill(dt)

            dr.BeginEdit()
            If dt.Rows.Count > 0 Then
                dr("fechaenvio") = CDate(dt.Rows(0).Item("fecha_0"))
            End If
            dr.EndEdit()
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
            If dr("ruta").ToString <> " " Then
                da.SelectCommand.Parameters("ruta_0").Value = CInt(dr("ruta").ToString)
                dt.Clear()
                da.Fill(dt)

                dr.BeginEdit()
                If dt.Rows.Count > 0 Then
                    dr("fecharuta") = CDate(dt.Rows(0).Item("fecha_0")) '.ToString).ToString("dd/MM/yyyy")
                End If
                dr.EndEdit()
            End If
        Next
        dtOrigen.AcceptChanges()
        dgv.Refresh()
    End Sub
    Private Sub Cantidad()
        Dim Total As Integer = 0

        txtAdm.Text = CalcularCantidad("ADM").ToString
        Total += CInt(txtAdm.Text)

        txtAbono.Text = CalcularCantidad("ABO").ToString
        Total += CInt(txtAbono.Text)

        txtArch.Text = CalcularCantidad("ACH").ToString
        Total += CInt(txtArch.Text)

        txtCal.Text = CalcularCantidad("CAL").ToString
        Total += CInt(txtCal.Text)

        txtCon.Text = CalcularCantidad("CTD").ToString
        Total += CInt(txtCon.Text)

        txtDepo.Text = CalcularCantidad("DEP").ToString
        Total += CInt(txtDepo.Text)

        txtIng.Text = CalcularCantidad("ING").ToString
        Total += CInt(txtIng.Text)

        txtLog.Text = CalcularCantidad("LOG").ToString
        Total += CInt(txtLog.Text)

        txtMos.Text = CalcularCantidad("MOS").ToString
        Total += CInt(txtMos.Text)

        txtServ.Text = CalcularCantidad("SRV").ToString
        Total += CInt(txtServ.Text)

        txtVen.Text = CalcularCantidad("VEN").ToString
        Total += CInt(txtVen.Text)

        txtboxTotal.Text = Total.ToString

    End Sub
    Private Sub txt_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAbono.DoubleClick, txtArch.DoubleClick, txtAdm.DoubleClick, txtCal.DoubleClick, txtCon.DoubleClick, txtDepo.DoubleClick, txtIng.DoubleClick, txtLog.DoubleClick, txtMos.DoubleClick, txtServ.DoubleClick, txtVen.DoubleClick
        Dim txt As TextBox = CType(sender, TextBox)
        Dim dt As DataTable

        If dgv.DataSource IsNot Nothing Then
            dt = CType(dgv.DataSource, DataTable)

        Else
            colFecha.DataPropertyName = "FechaRemito"
            colNumero.DataPropertyName = "Numero"
            colCliente.DataPropertyName = "Cliente"
            colDireccion.DataPropertyName = "direccion"
            colVendedor.DataPropertyName = "Vendedor"
            colSector.DataPropertyName = "Sector"
            colImporte.DataPropertyName = "Importe"
            colFechaEnvio.DataPropertyName = "Fechaenvio"
            colRuta.DataPropertyName = "Ruta"
            colFechaRuta.DataPropertyName = "Fecharuta"
            colObserva.DataPropertyName = "obs"
            colPedido.DataPropertyName = "pedido"
        End If

        If txt Is txtAbono Then
            dt = datos("ABO")
            BuscarSectorRemito(dt)
            BuscarFechaRuta(dt)
            dgv.DataSource = dt
            lblTitulo.Text = "Sector Abonos"

        ElseIf txt Is txtArch Then
            dt = datos("ACH")
            BuscarSectorRemito(dt)
            BuscarFechaRuta(dt)
            dgv.DataSource = dt
            lblTitulo.Text = "Sector Archivo"

        ElseIf txt Is txtAdm Then
            dt = datos("ADM")
            BuscarSectorRemito(dt)
            BuscarFechaRuta(dt)
            dgv.DataSource = dt
            lblTitulo.Text = "Sector Administracion"

        ElseIf txt Is txtCal Then
            dt = datos("CAL")
            BuscarSectorRemito(dt)
            BuscarFechaRuta(dt)
            dgv.DataSource = dt
            lblTitulo.Text = "Sector Calidad"

        ElseIf txt Is txtCon Then
            dt = datos("CTD")
            BuscarSectorRemito(dt)
            BuscarFechaRuta(dt)
            dgv.DataSource = dt
            lblTitulo.Text = "Sector Contado"

        ElseIf txt Is txtDepo Then
            dt = datos("DEP")
            BuscarSectorRemito(dt)
            BuscarFechaRuta(dt)
            dgv.DataSource = dt
            lblTitulo.Text = "Sector Deposito"

        ElseIf txt Is txtIng Then
            dt = datos("ING")
            BuscarSectorRemito(dt)
            BuscarFechaRuta(dt)
            dgv.DataSource = dt
            lblTitulo.Text = "Sector Ingenieria"

        ElseIf txt Is txtLog Then
            dt = datos("LOG")
            BuscarSectorRemito(dt)
            BuscarFechaRuta(dt)
            dgv.DataSource = dt
            lblTitulo.Text = "Sector Logistica"

        ElseIf txt Is txtMos Then
            dt = datos("MOS")
            BuscarSectorRemito(dt)
            BuscarFechaRuta(dt)
            dgv.DataSource = dt
            lblTitulo.Text = "Sector Mostrador"

        ElseIf txt Is txtServ Then
            dt = datos("SRV")
            BuscarSectorRemito(dt)
            BuscarFechaRuta(dt)
            dgv.DataSource = dt
            lblTitulo.Text = "Sector Service"

        ElseIf txt Is txtVen Then
            dt = datos("VEN")
            BuscarSectorRemito(dt)
            BuscarFechaRuta(dt)
            dgv.DataSource = dt
            lblTitulo.Text = "Sector Ventas"

        End If

    End Sub
    Private Sub frmRptRto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AddHandler dgv.RowPostPaint, AddressOf NumeracionGrillas
        btnCalcular.Focus()
    End Sub
    Private Sub ObservacionesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ObservacionesToolStripMenuItem.Click
        Dim f As frmComentarios
        Dim dr As DataRow = CType(dgv.SelectedRows(0).DataBoundItem, DataRowView).Row
        Dim rto As New Remito(cn)
        If Not rto.Abrir(dr("numero").ToString) Then Exit Sub

        f = New frmComentarios(dr("obs").ToString.Trim)
        f.ShowDialog(Me)

        If f.DialogResult = Windows.Forms.DialogResult.OK Then
            If f.txtComentario.Text = "" Then
                rto.Observaciones = " "
            Else
                rto.Observaciones = f.txtComentario.Text
            End If
            rto.Grabar()

            dr.BeginEdit()
            dr("obs") = rto.Observaciones
            dr.EndEdit()
            dr.AcceptChanges()
        End If

        f.Dispose()

    End Sub
    Private Sub dgv_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgv.CellFormatting
        If e.ColumnIndex = 1 Then

            If dgv.Rows(e.RowIndex).Cells(9).Value.ToString.Trim = "" Then
                e.CellStyle.BackColor = Drawing.Color.White
            Else
                e.CellStyle.BackColor = Drawing.Color.Yellow
            End If

        End If

    End Sub
    Private Sub VerRemitoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerRemitoToolStripMenuItem.Click
        Dim rpt As New ReportDocument
        Dim numero As String = dgv.CurrentRow.Cells("colNumero").Value.ToString
        Dim crystal As frmCrystal
        rpt.Load(RPTX3 & "bonliv50.rpt")
        rpt.SetDatabaseLogon(DB_USR, DB_PWD)
        rpt.SetParameterValue("livraisondeb", numero)
        rpt.SetParameterValue("livraisonfin", numero)
        rpt.SetParameterValue("x3dos", X3DOS)
        crystal = New frmCrystal(rpt)
        crystal.MdiParent = Me.ParentForm
        crystal.Show()
    End Sub
    Private Sub SeguimientoDeDocumentacionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SeguimientoDeDocumentacionToolStripMenuItem.Click
        Dim rpt As New ReportDocument
        Dim numero As String = dgv.CurrentRow.Cells("colNumero").Value.ToString
        Dim crystal As frmCrystal
        rpt.Load(RPTX3 & "xsegto_rto.rpt")
        rpt.SetDatabaseLogon(DB_USR, DB_PWD)
        rpt.SetParameterValue("rto", numero)
        crystal = New frmCrystal(rpt)
        crystal.MdiParent = Me.ParentForm
        crystal.Show()
    End Sub
    Private Sub VerRemitoEscaneadoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerRemitoEscaneadoToolStripMenuItem.Click
        Dim numero As String = dgv.CurrentRow.Cells("colNumero").Value.ToString
        Try
            Process.Start("\\srv\Z\Remitos\" & numero & ".pdf")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Menu1_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Menu1.Opening
        Dim numero As String = dgv.CurrentRow.Cells("colNumero").Value.ToString
        If File.Exists("\\srv\Z\Remitos\" & numero & ".pdf") Then
            VerRemitoEscaneadoToolStripMenuItem.Enabled = True
        Else
            VerRemitoEscaneadoToolStripMenuItem.Enabled = False
        End If
    End Sub

    
End Class