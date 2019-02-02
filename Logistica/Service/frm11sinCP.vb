Imports System.Data.OracleClient

Public Class frm11sinCP
    Dim cliente As New Cliente(cn)
    Private Sub frm11sinCP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        AddHandler dgv.RowPostPaint, AddressOf NumeracionGrillas

        CargarVendedores()
        CargarCombo()

        DateTimePicker1.MinDate = Date.Today

    End Sub
    Private Sub CargarVendedores()
        Dim i As Integer
        Dim dr As DataRow
        Dim Sql As String = "SELECT repnum_0, repnam_0 FROM salesrep WHERE length(repnum_0) = 2 ORDER BY repnam_0"
        Dim da As New OracleDataAdapter(Sql, cn)
        Dim dt As New DataTable

        da.Fill(dt)
        da.Dispose()

        'Si el usuario es vendedor, elimino de la tabla los demás vendedores
        If USR.Codigo.Length = 2 Then
            For i = dt.Rows.Count - 1 To 0 Step -1
                dr = dt.Rows(i)

                If Usr.Codigo <> dr("repnum_0").ToString Then
                    dt.Rows.Remove(dr)
                End If
            Next
        End If

        'Enlazo la tabla al ListBox
        With lstVendedores
            .DataSource = dt
            .ValueMember = "repnum_0"
            .DisplayMember = "repnam_0"
        End With

        'Recorro todos los vendedores y los chequeo
        For i = 0 To lstVendedores.Items.Count - 1
            lstVendedores.SetItemChecked(i, True)
        Next

    End Sub
    Private Sub CargarCombo()
        Dim da As New OracleDataAdapter("SELECT itmref_0, itmdes1_0 FROM itmmaster WHERE itmref_0 IN ('992001', '992002') ORDER BY itmdes1_0 desc", cn)
        Dim dt As New DataTable

        da.Fill(dt)
        da.Dispose()

        With cboTipo
            .DataSource = dt
            .ValueMember = "itmref_0"
            .DisplayMember = "itmdes1_0"
        End With

    End Sub
    Private Sub buscar()
        Dim Sql As String

        Sql = "SELECT bpc.bpcnum_0, bpc.bpcnam_0, bpaaddlig_0, bpc.rep_0, bpc.bpcpyr_0, pay.bpcnam_0 AS Administracion, bpa.bpaadd_0, bpc.xactiv_0 "
        Sql &= "FROM ((bpcustomer bpc INNER JOIN bpartner bpr ON (bpc.bpcnum_0 = bpr.bprnum_0)) INNER JOIN bpaddress bpa ON (bpc.bpcnum_0 = bpa.bpanum_0 AND bpr.bpaadd_0 = bpa.bpaadd_0)) INNER JOIN bpcustomer pay ON (bpc.bpcpyr_0 = pay.bpcnum_0) "
        Sql &= "WHERE bpc.tsccod_1 = '11' AND bpc.bpcsta_0 = 2 AND bpc.ostctl_0 <> 3 AND bpc.bpctyp_0 = 1 AND bpc.bpcnum_0 NOT IN ( "
        Sql &= "	  SELECT DISTINCT bpcnum_0 FROM machines WHERE macpdtcod_0 IN ('992001', '992002')) "
        Sql &= "and (bpc.bpcnum_0 IN (select distinct bpc_0 from interven itn inner join yitndet yitn on (itn.num_0 = yitn.num_0) where dat_0 > :dat2 and (yitn.itmref_0 <> '652011' or yitn.itmref_0 <> '553001' or yitn.itmref_0 <> '553009' or yitn.itmref_0 <> '553010'or yitn.itmref_0 <> '553011'or yitn.itmref_0 <> '553012'or yitn.itmref_0 <> '553013'or yitn.itmref_0 <> '553014'or yitn.itmref_0 <> '553020'or yitn.itmref_0 <> '553098'or yitn.itmref_0 <> '553099'))  "
        Sql &= " or bpc.bpcnum_0 IN (select distinct bpr_0 from sinvoice where accdat_0 > :dat)) "
        Sql &= " ORDER BY bpcpyr_0"

        Dim da As New OracleDataAdapter(Sql, cn)
        Dim diafac As Date = Today.AddMonths(-13)
        Dim diaitn As Date = Today.AddMonths(-12)
        da.SelectCommand.Parameters.Add("dat", OracleType.DateTime).Value = diafac
        da.SelectCommand.Parameters.Add("dat2", OracleType.DateTime).Value = diaitn
        Dim dt As New DataTable
        Dim dr As DataRow

        btnBuscar.Enabled = False
        Me.UseWaitCursor = True

        Application.DoEvents()
        Application.DoEvents()

        da.Fill(dt)
        da.Dispose()

        'Dejo solamente los vendedores chequeados
        For i = dt.Rows.Count - 1 To 0 Step -1
            dr = dt.Rows(i)
            If Not IsVendedorCheck(dr("rep_0").ToString) Then dt.Rows.Remove(dr)
        Next

        colCodigo.DataPropertyName = "bpcnum_0"
        colConsorcio.DataPropertyName = "bpcnam_0"
        colDomicilio.DataPropertyName = "bpaaddlig_0"
        colVendedor.DataPropertyName = "rep_0"
        colCodigoAdmin.DataPropertyName = "bpcpyr_0"
        colAdministracion.DataPropertyName = "Administracion"
        colSuc.DataPropertyName = "bpaadd_0"
        activo.DataPropertyName = "xactiv_0"
        dgv.DataSource = dt

        For Each Row As DataGridViewRow In dgv.Rows
            If Row.Cells("activo").Value.ToString = "1" Then
                Row.DefaultCellStyle.BackColor = Drawing.Color.Red
            End If
        Next
        btnBuscar.Enabled = True
        Me.UseWaitCursor = False

    End Sub
    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        buscar()
    End Sub
    Private Function IsVendedorCheck(ByVal Rep As String) As Boolean
        Dim flg As Boolean = False

        With lstVendedores
            For Each dr As DataRowView In .CheckedItems
                If Rep = dr("repnum_0").ToString Then
                    flg = True
                    Exit For
                End If
            Next
        End With

        Return flg

    End Function
    Private Function ContarParque(ByVal Cliente As String, ByVal Sucursal As String) As Integer
        Dim dt As New DataTable
        Dim da As New OracleDataAdapter("SELECT * FROM machines WHERE bpcnum_0 = :bpcnum_0 AND fcyitn_0 = :fcyitn_0 AND macdes_0 LIKE 'EXT.%' AND macitntyp_0 = 1", cn)
        da.SelectCommand.Parameters.Add("bpcnum_0", OracleType.VarChar).Value = Cliente
        da.SelectCommand.Parameters.Add("fcyitn_0", OracleType.VarChar).Value = Sucursal

        da.Fill(dt)
        da.Dispose()

        Return dt.Rows.Count

    End Function

    'MENU CONTEXTUAL DE LA LISTA DE VENDEDORES
    Private Sub mnuMarcarTodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMarcarTodos.Click
        For i As Integer = 0 To lstVendedores.Items.Count - 1
            lstVendedores.SetItemChecked(i, True)
        Next
    End Sub
    Private Sub mnuDesmarcarTodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDesmarcarTodos.Click
        For i As Integer = 0 To lstVendedores.Items.Count - 1
            lstVendedores.SetItemChecked(i, False)
        Next
    End Sub

    'MENU CONTEXTUAL DE LA GRILLA DE PARQUE
    Private Sub ContextMenuStrip2_Opening(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        If dgv.SelectedRows.Count <> 1 Then e.Cancel = True
    End Sub

    Private Sub btnCrear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCrear.Click
        crearparque()
    End Sub
    Private Sub crearparque()
        'Valido que haya seleccionada una linea
        If dgv.SelectedRows.Count <> 1 Then
            MessageBox.Show("Debe seleccionar un consorcio", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        End If

        'Valido que este seleccionado el tipo de ctrl
        If cboTipo.SelectedItem Is Nothing Then
            MessageBox.Show("Debe seleccionar el tipo de Control Periódico a agendar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            cboTipo.Focus()
            Exit Sub
        End If

        'Obtengo la fila seleccionada
        Dim dr As DataRow = CType(dgv.SelectedRows(0).DataBoundItem, DataRowView).Row
        Dim dt As DataTable

        'Confirmo seleccion antes de crear parque
        Dim txt As String
        Dim i As Integer

        txt = "¿Confirma agendar {1} para la fecha {2}" & vbCrLf
        txt &= "al consorcio {3}?"
        txt = Replace(txt, "{1}", cboTipo.Text)
        txt = Replace(txt, "{2}", DateTimePicker1.Value.ToString("MMMM yyyy"))
        txt = Replace(txt, "{3}", dr("bpaaddlig_0").ToString)

        If MessageBox.Show(txt, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then

            i = ContarParque(dr("bpcnum_0").ToString, dr("bpaadd_0").ToString)
            If i = 0 Then i = CP_CANTIDAD_MINIMA_REQUERIDA

            Dim mac As New Parque(cn)
            mac.Nuevo(dr("bpcnum_0").ToString, dr("bpaadd_0").ToString)
            mac.ArticuloCodigo = cboTipo.SelectedValue.ToString
            mac.VtoCarga = New Date(DateTimePicker1.Value.Year, DateTimePicker1.Value.Month, 15)
            mac.Cantidad = i
            mac.Cilindro = "CTRL-" & dr("bpcnum_0").ToString & "-" & dr("bpaadd_0").ToString
            mac.FabricacionCorto = Today.Year
            mac.Grabar()

            txt = "Se creo el parque con número de serie: {serie}"
            txt = Replace(txt, "{serie}", mac.Serie)

            MessageBox.Show(txt, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            mac = Nothing

            'Eliminar la linea de la tabla
            dt = CType(dgv.DataSource, DataTable)
            dt.Rows.Remove(dr)

        End If

    End Sub

    Private Sub dgv_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv.SelectionChanged
        btnCrear.Enabled = (dgv.SelectedRows.Count = 1)
        cboTipo.Enabled = (dgv.SelectedRows.Count = 1)
        DateTimePicker1.Enabled = (dgv.SelectedRows.Count = 1)
        btn2.Enabled = (dgv.SelectedRows.Count = 1)
    End Sub
    Private Sub RecuperadoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RecuperadoToolStripMenuItem.Click
        'If dgv.SelectedRows.Count <> 1 Then
        '    MessageBox.Show("Debe seleccionar un consorcio", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        '    Exit Sub
        'End If
        'If dgv.CurrentRow.Cells("activo").Value.ToString = "1" Then
        'cliente.Abrir(dgv.CurrentRow.Cells("colcodigo").Value.ToString)
        'cliente.ActivoControlPeriodico = 2
        'cliente.Grabar()
        'buscar()
        'End If

        Dim drg As DataGridViewRow
        For Each drg In dgv.SelectedRows
            If drg.Cells("activo").Value.ToString = "1" Then
                cliente.Abrir(drg.Cells("colcodigo").Value.ToString)
                cliente.ActivoControlPeriodico = True
                cliente.Grabar()
            End If
        Next
        buscar()
    End Sub

    Private Sub PerdidoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PerdidoToolStripMenuItem.Click
        'If dgv.SelectedRows.Count <> 1 Then
        '    MessageBox.Show("Debe seleccionar un consorcio", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        '    Exit Sub
        'End If
        Dim drg As DataGridViewRow
        For Each drg In dgv.SelectedRows
            If drg.Cells("activo").Value.ToString = "2" Then
                cliente.Abrir(drg.Cells("colcodigo").Value.ToString)
                cliente.ActivoControlPeriodico = False
                cliente.Grabar()
            End If
        Next
        buscar()
    End Sub

    Private Sub ContextMenuStrip2_Opening_1(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip2.Opening
        If dgv.CurrentRow.Cells("activo").Value.ToString = "1" Then
            RecuperadoToolStripMenuItem.Enabled = True
            PerdidoToolStripMenuItem.Enabled = False
        ElseIf dgv.CurrentRow.Cells("activo").Value.ToString = "2" Then
            RecuperadoToolStripMenuItem.Enabled = False
            PerdidoToolStripMenuItem.Enabled = True
        End If
    End Sub

   
    Private Sub dgv_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellContentClick
        For Each Row As DataGridViewRow In dgv.Rows
            If Row.Cells("activo").Value.ToString = "1" Then
                Row.DefaultCellStyle.BackColor = Drawing.Color.Red
            End If
        Next
    End Sub

    'Private Sub btn2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn2.Click
    '    Dim dr As DataRow = CType(dgv.SelectedRows(0).DataBoundItem, DataRowView).Row
    '    Dim bpc As String = dr("bpcnum_0").ToString
    '    Dim suc As String = dr("bpaadd_0").ToString
    '    crearparque()
    '    Dim f As New frmVencimientos
    '    f.MdiParent = frmMain
    '    f.Show()
    '    f.Buscar(DateTimePicker1, bpc)
    'End Sub
End Class