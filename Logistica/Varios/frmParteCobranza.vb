Imports System.Data.OracleClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class frmParteCobranza

    Private Const RPT As String = ""

    Private bpc As New Cliente(cn)

    Private da1 As OracleDataAdapter 'Facturas a cobrar
    Private da2 As OracleDataAdapter 'Horarios del pagador
    Private da3 As OracleDataAdapter 'Direcciones del pagador

    Private dt1 As New DataTable 'Facturas a cobrar
    Private dt2 As New DataTable 'Horarios del pagador
    Private dt3 As New DataTable 'Direcciones del pagador

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Dim Sql As String

        '**************************************************************
        'CONSULTA DE FACTURAS IMPAGAS
        '**************************************************************
        Sql = "SELECT bpcnum_0, bpcnam_0, sih.accdat_0, dud.num_0, dud.dudlig_0, amtcur_0, duddat_0, ybprpth_0, ycobdat_0, bpc.rep_0 "
        Sql &= "FROM (gaccdudate dud INNER JOIN sinvoice sih ON (dud.num_0 = sih.num_0)) INNER JOIN bpcustomer bpc ON (sih.bpr_0 = bpc.bpcnum_0) "
        Sql &= "WHERE typ_0 IN ('FAC', 'NCC', 'NDC') AND sac_0 = 'DVL' AND amtcur_0 <> paycur_0 AND (dud.bpr_0 = :bpr OR dud.bprpay_0 = :bpr)"

        da1 = New OracleDataAdapter(Sql, cn)
        da1.SelectCommand.Parameters.Add("bpr", OracleType.VarChar)

        Sql = "UPDATE gaccdudate "
        Sql &= "SET ybprpth_0 = :ybprpth_0, ycobdat_0 = :ycobdat_0 "
        Sql &= "WHERE num_0 = :num_0 AND dudlig_0 = :dudlig_0"

        da1.UpdateCommand = New OracleCommand(Sql, cn)
        With da1
            Parametro(.UpdateCommand, "ybprpth_0", OracleType.VarChar, DataRowVersion.Current)
            Parametro(.UpdateCommand, "ycobdat_0", OracleType.DateTime, DataRowVersion.Current)
            Parametro(.UpdateCommand, "num_0", OracleType.VarChar, DataRowVersion.Original)
            Parametro(.UpdateCommand, "dudlig_0", OracleType.Number, DataRowVersion.Original)
        End With

        '**************************************************************
        ' HORARIOS DE COBRANZAS
        '**************************************************************
        Sql = "SELECT * FROM ybpc0 WHERE bpcnum_0 = :bpcnum"
        da2 = New OracleDataAdapter(Sql, cn)
        da2.SelectCommand.Parameters.Add("bpcnum", OracleType.VarChar)
        da2.InsertCommand = New OracleCommandBuilder(da2).GetInsertCommand
        da2.UpdateCommand = New OracleCommandBuilder(da2).GetUpdateCommand
        da2.DeleteCommand = New OracleCommandBuilder(da2).GetDeleteCommand
        da2.ContinueUpdateOnError = True

        '**************************************************************
        ' DIRECCIONES DEL PAGADOR
        '**************************************************************
        Sql = "SELECT bpanum_0, bpaadd_0, bpaadd_0 || ' - ' || bpaaddlig_0 AS dire "
        Sql &= "FROM bpaddress "
        Sql &= "WHERE bpanum_0 = :bpanum "
        da3 = New OracleDataAdapter(Sql, cn)
        da3.SelectCommand.Parameters.Add("bpanum", OracleType.VarChar).Value = txtCliente.Text

    End Sub
    Private Sub frmParteCobranza_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim mnu As New MenuLocal(cn)
        mnu.AbrirMenu(742, False)

        Try
            da2.FillSchema(dt2, SchemaType.Mapped)
            da3.FillSchema(dt3, SchemaType.Mapped)

            colPagador.DataPropertyName = "bpcnum_0"
            With colDomicilio
                .DisplayMember = "dire"
                .ValueMember = "bpaadd_0"
                .DisplayMember = "dire"
                .DataPropertyName = "bpaadd_0"
                .DataSource = dt3
            End With

            mnu.Enlazar(colDia)
            colDia.DataPropertyName = "dia_0"

            colDesde.DataPropertyName = "hdesde_0"
            colHasta.DataPropertyName = "hhasta_0"
            dgv2.DataSource = dt2

        Catch ex As Exception
        End Try

    End Sub
    Private Sub txtCliente_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCliente.KeyUp
        If e.KeyCode = Keys.Enter AndAlso btnBuscar.Enabled Then
            AbrirCliente()
        End If
    End Sub
    Private Sub txtCliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCliente.TextChanged
        Dim txt As TextBox = CType(sender, TextBox)
        btnBuscar.Enabled = txt.Text.Trim.Length > 0
    End Sub
    Private Sub AbrirCliente()
        Try
            
            With lblBuscando
                .Top = (Me.Height - .Height) \ 2
                .Left = (Me.Width - .Width) \ 2
                .Visible = True
                .BringToFront()
            End With

            Application.DoEvents()
            Application.DoEvents()

            txtNombre.Clear()

            If bpc.Abrir(txtCliente.Text) Then
                txtNombre.Text = bpc.Nombre

                FacturasImpagas()
                Horarios()

            Else
                MessageBox.Show("No se encontro el cliente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)

            End If

        Catch ex As Exception
        End Try


        txtCliente.Clear()
        lblBuscando.Visible = False

    End Sub
    Private Sub FacturasImpagas()
        dt1.Clear()
        da1.SelectCommand.Parameters("bpr").Value = bpc.Codigo

        Try

            If dgv1.DataSource Is Nothing Then
                dt1 = New DataTable
                dgv1.DataSource = dt1

                colCodigo.DataPropertyName = "bpcnum_0"
                colCliente.DataPropertyName = "bpcnam_0"
                colFecha.DataPropertyName = "accdat_0"
                colFactura.DataPropertyName = "num_0"
                colCuota.DataPropertyName = "dudlig_0"
                colImporte.DataPropertyName = "amtcur_0"
                colVto.DataPropertyName = "duddat_0"
                colCobrador.DataPropertyName = "ybprpth_0"
                colFechaCob.DataPropertyName = "ycobdat_0"
                colVendedor.DataPropertyName = "rep_0"

            Else
                dt1 = CType(dgv1.DataSource, DataTable)

            End If

            dt1.Clear()
            da1.Fill(dt1)

            Filtrar(dt1)

        Catch ex As Exception
        End Try

    End Sub
    Private Sub Horarios()

        da2.SelectCommand.Parameters("bpcnum").Value = txtCliente.Text
        da3.SelectCommand.Parameters("bpanum").Value = txtCliente.Text

        Try
            dt2.Clear()
            dt3.Clear()

            da3.Fill(dt3)
            da2.Fill(dt2)

            'Valores por defecto
            dt2.Columns("bpcnum_0").DefaultValue = txtCliente.Text
            dt2.Columns("bpaadd_0").DefaultValue = dt3.Rows(0).Item("bpaadd_0").ToString
            dt2.Columns("dia_0").DefaultValue = 1
            dt2.Columns("hdesde_0").DefaultValue = "0000"
            dt2.Columns("hhasta_0").DefaultValue = "0000"

        Catch ex As Exception
        End Try

    End Sub
    Private Sub Marcar()
        Dim dr As DataRow

        For Each d As DataGridViewRow In dgv1.SelectedRows
            dr = CType(d.DataBoundItem, DataRowView).Row

            dr.BeginEdit()
            If dr("ybprpth_0").ToString = " " Then
                dr("ybprpth_0") = usr.Codigo
                dr("ycobdat_0") = dtp.Value.Date
            Else
                dr("ybprpth_0") = " "
                dr("ycobdat_0") = #12/31/1599#
            End If
            dr.EndEdit()
        Next

        Try
            da1.Update(dt1)

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub Imprimir()
        Dim f As frmCrystal
        Dim rpt As New ReportDocument

        Try
            rpt.Load(RPTX3 & "xcobros2.rpt")
            rpt.SetParameterValue("FECHA", dtp.Value)
            rpt.SetParameterValue("COBRADOR", usr.Codigo)
            rpt.SetParameterValue("X3USR", usr.Codigo)

            f = New frmCrystal(rpt)
            f.MdiParent = Me.ParentForm
            f.Show()

        Catch ex As Exception

        End Try

    End Sub
    Private Sub Filtrar(ByVal dt As DataTable)
        Dim da2 As OracleDataAdapter
        Dim dt2 As New DataTable
        Dim Sql As String
        Dim dv As DataView

        Sql = "SELECT * FROM xnetvenc WHERE usr_0 = :usr_0"
        da2 = New OracleDataAdapter(Sql, cn)
        da2.SelectCommand.Parameters.Add("usr_0", OracleType.VarChar).Value = usr.Codigo

        da2.Fill(dt2)
        dv = New DataView(dt2)

        For i As Integer = dt.Rows.Count - 1 To 0 Step -1
            Dim dr As DataRow
            Dim flg As Boolean = False

            dr = dt.Rows(i)

            'Miro si el usuario logeado es el vendedor del cliente
            If dr("rep_0").ToString = usr.Codigo Then
                flg = True
            Else
                'Miro si el usuario logeado tiene permiso para ver cliente
                dv.RowFilter = "[rep_0] = '" & dr("rep_0").ToString & "'"
                If dv.Count > 0 Then
                    flg = (CInt(dv(0).Item(2)) = 1 Or CInt(dv(0).Item(3)) = 1)
                Else
                    flg = False
                End If

            End If
            'Quito el registro porque usuario no tiene permiso para este cliente
            If Not flg Then dt.Rows.Remove(dr)

        Next

    End Sub
    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        AbrirCliente()
    End Sub
    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMarcar.Click
        btnMarcar.Enabled = False
        If dgv1.SelectedRows.Count > 0 Then Marcar()
        btnMarcar.Enabled = True
    End Sub
    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        'Dim primero As Integer = 0
        'For i As Integer = 0 To dgv2.Rows.Count - 1
        '    'dgv2.CurrentCell = dgv2.Rows(i).Cells(1)
        '    If primero = 0 Then
        '        primero = CInt(dgv2.Rows(i).Cells(1).Value)
        '    ElseIf CInt(dgv2.Rows(i).Cells(1).Value) > 0 And Not primero = CInt(dgv2.Rows(i).Cells(1).Value) Then
        '        MsgBox("No se puede elegir diferente direccion de cobranza")
        '        Exit Sub
        '    End If
        'Next

        btnImprimir.Enabled = False

        Try
            da2.Update(dt2)

        Catch ex As Exception
        End Try

        Imprimir()
        btnImprimir.Enabled = True

    End Sub

    Private Sub dgv2_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dgv2.CellValidating
        If e.FormattedValue Is Nothing Then Exit Sub

        Select Case dgv2.Columns(e.ColumnIndex).Name
            Case "colDesde", "colHasta"
                If Not ValidarHora(e.FormattedValue.ToString) Then e.Cancel = True

            Case Else
                e.Cancel = e.FormattedValue Is DBNull.Value

        End Select

    End Sub

    Private Sub dgv2_RowValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgv2.RowValidating

        Dim r As DataGridViewRow = dgv2.Rows(e.RowIndex)

        For i As Integer = 0 To r.Cells.Count - 1
            If r.Cells(i).FormattedValue Is DBNull.Value Then
                e.Cancel = True
                Exit For
            End If
        Next

    End Sub

End Class