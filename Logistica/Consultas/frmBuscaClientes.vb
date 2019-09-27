Imports System.Data.OracleClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class frmBuscaClientes

    Private dt As New DataTable
    Private txt As TextBox

    'SUB
    Private Sub RegistrarLlamado()
        Dim dr As DataRowView
        Dim f As frmTicket
        Dim Cliente As String
        Dim Sucursal As String

        dr = CType(dgv.CurrentRow.DataBoundItem, DataRowView)

        Cliente = dr("codigo").ToString
        Sucursal = dr("suc").ToString

        f = New frmTicket
        f.ShowDialog(Me)
        f.Dispose()

    End Sub
    Private Sub EnlazarGrilla()
        If dgv.DataSource Is Nothing Then
            dgv.DataSource = dt

            For i As Integer = 0 To dgv.Columns.Count - 1
                If i = 9 Then
                    dgv.Columns(i).Visible = False
                End If
            Next
        End If

        dgv.Focus()

    End Sub

    'EVENTOS
    Private Sub frmBuscaClientes_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp

        Select Case e.KeyCode
            Case Keys.F4
                txtfantasia.Focus()

            Case Keys.F5
                txtCodigo.Focus()

            Case Keys.F6
                txtNombre.Focus()

            Case Keys.F7
                txtDireccion.Focus()

            Case Keys.F8
                If e.Shift Then
                    txtMail.Focus()
                Else
                    txtCUIT.Focus()
                End If

            Case Keys.F9
                txtPresupuesto.Focus()

            Case Keys.F11
                txtLoc.Focus()

            Case Keys.F12
                cboprov.Focus()

        End Select

    End Sub
    Private Sub mnuRegistrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If dgv.CurrentRow IsNot Nothing Then RegistrarLlamado()
    End Sub
    Private Sub dgv_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellDoubleClick
        If e.RowIndex >= 0 Then RegistrarLlamado()
    End Sub
    Private Sub dgv_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgv.KeyUp
        If e.KeyCode = Keys.Insert Then
            If Not IsNothing(dgv.CurrentRow) Then RegistrarLlamado()

        ElseIf e.KeyCode = Keys.Escape Then
            If Not IsNothing(txt) Then txt.Focus()

        End If
    End Sub
    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtfantasia.GotFocus, txtCodigo.GotFocus, txtNombre.GotFocus, txtDireccion.GotFocus, txtCUIT.GotFocus, txtPresupuesto.GotFocus, txtLoc.GotFocus, txtMail.GotFocus
        'dt.Clear()
        txt = CType(sender, TextBox) 'Guardo el Texbox que está activo
        txt.BackColor = Drawing.Color.Pink
        btnProv.Enabled = False
    End Sub
    Private Sub txt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtfantasia.LostFocus, txtCodigo.LostFocus, txtNombre.LostFocus, txtDireccion.LostFocus, txtCUIT.LostFocus, txtPresupuesto.LostFocus, txtLoc.LostFocus, txtMail.LostFocus
        With CType(sender, TextBox)
            .Clear()
            .BackColor = System.Drawing.SystemColors.Window
        End With
    End Sub
    Private Sub txt_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtfantasia.KeyUp, txtCodigo.KeyUp, txtNombre.KeyUp, txtDireccion.KeyUp, txtCUIT.KeyUp, txtPresupuesto.KeyUp, txtLoc.KeyUp, cboprov.KeyUp, txtMail.KeyUp
        Dim Sql As String
        Dim da As OracleDataAdapter

        If e.KeyCode = Keys.Escape Then
            txt.Clear()

        ElseIf e.KeyCode = Keys.Enter Then
            If txt.Text = "" Then Exit Sub 'Salgo si el campo está vacio

            If txt Is txtCodigo Then 'Armo consulta para buscar por codigo
                Sql = "SELECT bpcnum_0 AS codigo, bpclon_0 as NOMBRE_FANTASIA, bpcnam_0 AS nombre, bpaadd_0 AS suc, bpaaddlig_0 AS domicilio, cty_0 AS ciudad, rep_0 AS codrep, repnam_0 AS vendedor, xinterno_0 AS interno " & _
                      ", bpc.tsccod_1 as tipo_cliente,(case when (bpc.xabo_0 = 2) then 'Si' else 'No' end) as abonado,(case when (bpcsta_0 = 2) then 'Activo' else 'No Activo' end) as Estado FROM ((BPARTNER bpr INNER JOIN BPCUSTOMER bpc ON (bprnum_0 = bpcnum_0)) INNER JOIN BPADDRESS bpa ON (bpcnum_0 = bpanum_0)) LEFT JOIN SALESREP ON (rep_0 = repnum_0) " & _
                      "WHERE  bpcnum_0 = :bpcnum_0 " & _
                      "ORDER BY bpcnam_0, bpaaddlig_0"

                da = New OracleDataAdapter(Sql, cn)
                da.SelectCommand.Parameters.Add("bpcnum_0", OracleType.VarChar).Value = txt.Text

            ElseIf txt Is txtNombre Then 'Armo consulta para buscar por nombre
                Sql = "SELECT bpcnum_0 as CODIGO,bpclon_0 as NOMBRE_FANTASIA, bpcnam_0 AS NOMBRE, bpaadd_0 AS SUC, bpaaddlig_0 AS DOMICILIO, cty_0 AS CIUDAD, rep_0 AS CODREP, repnam_0 AS VENDEDOR, xinterno_0 AS interno " & _
                      ", bpc.tsccod_1 as tipo_cliente,(case when (bpc.xabo_0 = 2) then 'Si' else 'No' end) as abonado,(case when (bpcsta_0 = 2) then 'Activo' else 'No Activo' end) as Estado  FROM ((BPARTNER bpr INNER JOIN BPCUSTOMER bpc ON (bprnum_0 = bpcnum_0)) INNER JOIN BPADDRESS bpa ON (bpcnum_0 = bpanum_0)) LEFT JOIN SALESREP ON (rep_0 = repnum_0) " & _
                      "WHERE  bpcnam_0 LIKE :bpcnam_0 " & _
                      "ORDER BY bpcnam_0, bpaaddlig_0"

                da = New OracleDataAdapter(Sql, cn)
                da.SelectCommand.Parameters.Add("bpcnam_0", OracleType.VarChar).Value = "%" & txt.Text.ToUpper & "%"

            ElseIf txt Is txtDireccion Then 'Armo consulta para buscar por direccion
                Sql = "SELECT bpcnum_0 as CODIGO,bpclon_0 as NOMBRE_FANTASIA, bpcnam_0 AS NOMBRE, bpaadd_0 AS SUC, bpaaddlig_0 AS DOMICILIO, cty_0 AS CIUDAD, rep_0 AS CODREP, repnam_0 AS VENDEDOR, xinterno_0 AS interno " & _
                      ", bpc.tsccod_1 as tipo_cliente,(case when (bpc.xabo_0 = 2) then 'Si' else 'No' end) as abonado,(case when (bpcsta_0 = 2) then 'Activo' else 'No Activo' end) as Estado  FROM ((BPARTNER bpr INNER JOIN BPCUSTOMER bpc ON (bprnum_0 = bpcnum_0)) INNER JOIN BPADDRESS bpa ON (bpcnum_0 = bpanum_0)) LEFT JOIN SALESREP ON (rep_0 = repnum_0) " & _
                      "WHERE  bpaaddlig_0 LIKE :bpaaddlig_0 " & _
                      "ORDER BY bpcnam_0, bpaaddlig_0"

                da = New OracleDataAdapter(Sql, cn)
                da.SelectCommand.Parameters.Add("bpaaddlig_0", OracleType.VarChar).Value = "%" & txt.Text.ToUpper & "%"

            ElseIf txt Is txtCUIT Then 'Armo consulta para buscar por cuit
                Sql = "SELECT bpcnum_0 as CODIGO,bpclon_0 as NOMBRE_FANTASIA, bpcnam_0 AS NOMBRE, bpaadd_0 AS SUC, bpaaddlig_0 AS DOMICILIO, cty_0 AS CIUDAD, rep_0 AS CODREP, repnam_0 AS VENDEDOR, xinterno_0 AS interno " & _
                      ", bpc.tsccod_1 as tipo_cliente,(case when (bpc.xabo_0 = 2) then 'Si' else 'No' end) as abonado,(case when (bpcsta_0 = 2) then 'Activo' else 'No Activo' end) as Estado  FROM ((BPARTNER bpr INNER JOIN BPCUSTOMER bpc ON (bprnum_0 = bpcnum_0)) INNER JOIN BPADDRESS bpa ON (bpcnum_0 = bpanum_0)) LEFT JOIN SALESREP ON (rep_0 = repnum_0) " & _
                      "WHERE  bpc.docnum_0 = :docnum_0 " & _
                      "ORDER BY bpcnam_0, bpaaddlig_0"

                da = New OracleDataAdapter(Sql, cn)
                da.SelectCommand.Parameters.Add("docnum_0", OracleType.VarChar).Value = txt.Text

            ElseIf txt Is txtPresupuesto Then
                Sql = "SELECT bpcord_0 as CODIGO,bpcnam_0 AS NOMBRE, bpaadd_0 AS SUC, bpcaddlig_0 AS DOMICILIO, bpccty_0 AS CIUDAD, rep_0 AS CODREP, repnam_0 AS VENDEDOR, xinterno_0 AS interno "
                Sql &= "FROM squote squ LEFT JOIN salesrep ON (rep_0 = repnum_0) "
                Sql &= "WHERE sqhnum_0 LIKE :sqhnum_0 AND squ.credat_0 >= to_date(:fecha, 'dd/mm/yyyy') "
                Sql &= "ORDER BY squ.credat_0 DESC "
                da = New OracleDataAdapter(Sql, cn)
                da.SelectCommand.Parameters.Add("sqhnum_0", OracleType.VarChar).Value = "%" & txt.Text
                da.SelectCommand.Parameters.Add("fecha", OracleType.VarChar).Value = Date.Today.AddMonths(-12).ToString("dd/MM/yyyy")

            ElseIf txt Is txtfantasia Then 'Armo consulta para buscar por nombre de fantasia
                Sql = "SELECT bpcnum_0 as CODIGO,bpclon_0 as NOMBRE_FANTASIA, bpcnam_0 AS NOMBRE, bpaadd_0 AS SUC, bpaaddlig_0 AS DOMICILIO, cty_0 AS CIUDAD, rep_0 AS CODREP, repnam_0 AS VENDEDOR, xinterno_0 AS interno " & _
                      ", bpc.tsccod_1 as tipo_cliente,(case when (bpc.xabo_0 = 2) then 'Si' else 'No' end) as abonado,(case when (bpcsta_0 = 2) then 'Activo' else 'No Activo' end) as Estado  FROM ((BPARTNER bpr INNER JOIN BPCUSTOMER bpc ON (bprnum_0 = bpcnum_0)) INNER JOIN BPADDRESS bpa ON (bpcnum_0 = bpanum_0)) LEFT JOIN SALESREP ON (rep_0 = repnum_0) " & _
                      "WHERE  bpclon_0 LIKE :bpclon_0 " & _
                      "ORDER BY bpcnam_0, bpaaddlig_0"

                da = New OracleDataAdapter(Sql, cn)
                da.SelectCommand.Parameters.Add("bpclon_0", OracleType.VarChar).Value = "%" & txt.Text.ToUpper & "%"

            ElseIf txt Is txtLoc Then 'Armo consulta para buscar por localidad
                Sql = "SELECT bpcnum_0 as CODIGO,bpclon_0 as NOMBRE_FANTASIA, bpcnam_0 AS NOMBRE, bpaadd_0 AS SUC, bpaaddlig_0 AS DOMICILIO, cty_0 AS CIUDAD, rep_0 AS CODREP, repnam_0 AS VENDEDOR, xinterno_0 AS interno " & _
                      ", bpc.tsccod_1 as tipo_cliente,(case when (bpc.xabo_0 = 2) then 'Si' else 'No' end) as abonado,(case when (bpcsta_0 = 2) then 'Activo' else 'No Activo' end) as Estado  FROM ((BPARTNER bpr INNER JOIN BPCUSTOMER bpc ON (bprnum_0 = bpcnum_0)) INNER JOIN BPADDRESS bpa ON (bpcnum_0 = bpanum_0)) LEFT JOIN SALESREP ON (rep_0 = repnum_0) " & _
                      "WHERE  bpa.cty_0 LIKE :cty_0 " & _
                      "ORDER BY bpcnam_0, bpaaddlig_0"

                da = New OracleDataAdapter(Sql, cn)
                da.SelectCommand.Parameters.Add("cty_0", OracleType.VarChar).Value = "%" & txt.Text.ToUpper & "%"

            ElseIf txt Is txtMail Then
                Sql = "SELECT bpcnum_0 as CODIGO, bpclon_0 as NOMBRE_FANTASIA, bpcnam_0 AS NOMBRE, bpaadd_0 AS SUC, bpaaddlig_0 AS DOMICILIO, cty_0 AS CIUDAD, rep_0 AS CODREP, repnam_0 AS VENDEDOR, xinterno_0 AS interno, bpc.tsccod_1 as tipo_cliente,(case when (bpc.xabo_0 = 2) then 'Si' else 'No' end) as abonado,(case when (bpcsta_0 = 2) then 'Activo' else 'No Activo' end) as Estado "
                Sql &= "FROM ((bpartner bpr INNER JOIN bpcustomer bpc ON (bprnum_0 = bpcnum_0)) INNER JOIN "
                Sql &= "    bpaddress bpa ON (bpcnum_0 = bpanum_0)) LEFT JOIN "
                Sql &= "    salesrep ON (rep_0 = repnum_0) "
                Sql &= "WHERE  bpa.web_0 LIKE :p1 or bpa.xmailfc_0 LIKE :p1 or bpc.xmailfc_0 LIKE :p1 "
                Sql &= "ORDER BY bpcnam_0, bpaaddlig_0 "

                da = New OracleDataAdapter(Sql, cn)
                da.SelectCommand.Parameters.Add("p1", OracleType.VarChar).Value = "%" & txt.Text.ToLower & "%"

            Else
                Exit Sub

            End If


            Try
                dt.Clear()
                da.Fill(dt)

                If dt.Rows.Count = 0 Then
                    Label5.Visible = True
                    txt.Clear()

                Else
                    Label5.Visible = False
                    EnlazarGrilla()

                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

            Finally
                da.Dispose()
                da = Nothing

            End Try
        End If
        'If dt.Rows.Count = 0 Then
        'Else
        '    Dim codigo As String = dgv.CurrentRow.Cells("codrep").Value.ToString
        '    If usr.Permiso.AccesoSecundario(7, "V") Then
        '        ContextMenuStrip1.Enabled = True
        '    Else
        '        If usr.Codigo = codigo Then
        '            ContextMenuStrip1.Enabled = True
        '        End If
        '    End If
        'End If
    End Sub
    Private Sub DatosClienteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DatosClienteToolStripMenuItem.Click
        Dim rpt As New ReportDocument
        Dim cliente As String = dgv.CurrentRow.Cells("codigo").Value.ToString
        Dim crystal As frmCrystal
        rpt.Load(RPTX3 & "xclientesB.rpt")
        rpt.SetDatabaseLogon(DB_USR, DB_PWD)
        rpt.SetParameterValue("cliente", cliente)
        crystal = New frmCrystal(rpt)
        crystal.MdiParent = Me.ParentForm
        crystal.Show()
    End Sub
    Private Sub IntervencionesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IntervencionesToolStripMenuItem.Click
        Dim Sql As String
        Dim da As OracleDataAdapter
        Dim dt2 As New DataTable
        Dim cliente As String = dgv.CurrentRow.Cells("codigo").Value.ToString
        Dim sucursal As String = dgv.CurrentRow.Cells("suc").Value.ToString

        'Sql = "select num_0 as codigo, bpc_0 as cliente, bpaadd_0 as sucursal, typ_0 as tipo, dat_0 as fecha, xsector_0 as Sector from interven "
        'Sql &= "where bpc_0 = :bpcord_0 and bpaadd_0 = :bpaadd_0 order by dat_0 desc"
        Sql = "select num_0 as codigo, bpc_0 as cliente, bpaadd_0 as sucursal, typ_0 as tipo, dat_0 as fecha,"
        Sql &= "(select max(ruta_0) from xrutad where vcrnum_0 = num_0 ) as ruta ,xsector_0 as Sector, ysdhdeb_0 as remito, "
        Sql &= "yref_0 as OC,xcardat_0 as fecha_Carrito from interven "
        Sql &= "where bpc_0 = :bpcord_0  and bpaadd_0 = :bpaadd_0 "
        Sql &= " group by num_0,bpc_0,bpaadd_0,typ_0,dat_0,xsector_0,ysdhdeb_0,yref_0,xcardat_0 order by dat_0 desc"
        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("bpcord_0", OracleType.VarChar).Value = cliente
        da.SelectCommand.Parameters.Add("bpaadd_0", OracleType.VarChar).Value = Sucursal
        dt2.Clear()
        da.Fill(dt2)

        If dt2.Rows.Count = 0 Then
            MsgBox("El cliente no tiene intervenciones en esta sucursal")

        Else
            Dim f As New frmItnList(dt2)
            f.MdiParent = frmMain
            f.Show()

        End If

    End Sub
    Private Sub PedidosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PedidosToolStripMenuItem.Click
        Dim Sql As String
        Dim da As OracleDataAdapter
        Dim dt2 As New DataTable
        Dim cliente As String = dgv.CurrentRow.Cells("codigo").Value.ToString
        Dim sucursal As String = dgv.CurrentRow.Cells("suc").Value.ToString

        Sql = "select sohnum_0 as codigo, cusordref_0 as OC , salfcy_0 as planta, "
        Sql &= " bpcord_0 as codigo_cliente,bpcnam_0 as cliente, "
        Sql &= " bpaadd_0 as sucursal, rep_0 as vendedor,orddat_0 as fecha "
        Sql &= "from sorder where bpcord_0 = :bpcord_0 and bpaadd_0 = :bpaadd_0 "
        Sql &= "order by orddat_0 desc  "
        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("bpcord_0", OracleType.VarChar).Value = cliente
        da.SelectCommand.Parameters.Add("bpaadd_0", OracleType.VarChar).Value = sucursal
        dt2.Clear()
        da.Fill(dt2)

        If dt2.Rows.Count = 0 Then
            MsgBox("El cliente no tiene pedidos en esta sucursal")

        Else
            Dim f As New frmPedidolist(dt2)
            f.MdiParent = frmMain
            f.Show()

        End If

        'Dim rpt As New ReportDocument
        'Dim cliente As String = dgv.CurrentRow.Cells("codigo").Value.ToString
        'Dim sucursal As String = dgv.CurrentRow.Cells("suc").Value.ToString
        'Dim crystal As frmCrystal
        'rpt.Load(RPTX3 & "xpedidos2B2.rpt")
        'rpt.SetDatabaseLogon(DB_USR, DB_PWD)
        'rpt.SetParameterValue("sucursal", sucursal)
        'rpt.SetParameterValue("cliente", cliente)
        'crystal = New frmCrystal(rpt)
        'crystal.MdiParent = Me.ParentForm
        'crystal.Show()

    End Sub

    Private Sub FacturasDeLaSucursalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FacturasDeLaSucursalToolStripMenuItem.Click
        Dim Sql As String
        Dim da As OracleDataAdapter
        Dim dt2 As New DataTable
        Dim cliente As String = dgv.CurrentRow.Cells("codigo").Value.ToString
        Dim sucursal As String = dgv.CurrentRow.Cells("suc").Value.ToString

        Sql = "select fv.num_0 as codigo, fv.credat_0 as fecha, fv.bpcord_0 as cliente,fv.bpdnam_0 as nombre_cliente, "
        Sql &= "fv.bpdaddlig_0 as direccion, fv.vatnet_0 as importeAI, fv.vatamt_0 as impuestos, f.xfacte_0 as fac_elec "
        Sql &= "from sinvoicev fv join sinvoice f on (fv.NUM_0 = f.num_0) where bpcord_0 = :bpcord_0 and bpaadd_0 = :bpaadd_0 order by fv.credat_0 desc"
        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("bpcord_0", OracleType.VarChar).Value = cliente
        da.SelectCommand.Parameters.Add("bpaadd_0", OracleType.VarChar).Value = sucursal

        dt2.Clear()
        da.Fill(dt2)

        If dt2.Rows.Count = 0 Then
            MsgBox("El cliente no tiene facturas en esta sucursal")

        Else
            Dim f As New frmFacturaList(dt2)
            f.MdiParent = frmMain
            f.Show()

        End If
    End Sub
    Private Sub FacturasDelClienteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FacturasDelClienteToolStripMenuItem.Click
        Dim Sql As String
        Dim da As OracleDataAdapter
        Dim dt2 As New DataTable
        Dim cliente As String = dgv.CurrentRow.Cells("codigo").Value.ToString
        Dim sucursal As String = dgv.CurrentRow.Cells("suc").Value.ToString

        Sql = "select fv.num_0 as codigo, fv.credat_0 as fecha, fv.bpcord_0 as cliente,fv.bpdnam_0 as nombre_cliente, "
        Sql &= "fv.bpdaddlig_0 as direccion, fv.vatnet_0 as importeAI, fv.vatamt_0 as impuestos, f.xfacte_0 as fac_elec "
        Sql &= "from sinvoicev fv join sinvoice f on (fv.NUM_0 = f.num_0) where bpcord_0 = :bpcord_0 order by fv.credat_0 desc"
        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("bpcord_0", OracleType.VarChar).Value = cliente

        dt2.Clear()
        da.Fill(dt2)

        If dt2.Rows.Count = 0 Then
            MsgBox("El cliente no tiene facturas en esta sucursal")

        Else
            Dim f As New frmFacturaList(dt2)
            f.MdiParent = frmMain
            f.Show()

        End If
    End Sub
    Private Sub ConsorciosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsorciosToolStripMenuItem.Click
        Dim Sql As String
        Dim da As OracleDataAdapter
        Dim dt2 As New DataTable
        Dim tipo As String = dgv.CurrentRow.Cells("codigo").Value.ToString

        Sql = "SELECT bpcnum_0 AS codigo, bpclon_0 as NOMBRE_FANTASIA, bpcnam_0 AS nombre, bpaadd_0 AS suc, bpaaddlig_0 AS domicilio, cty_0 AS ciudad, rep_0 AS codrep, repnam_0 AS vendedor, xinterno_0 AS interno "
        Sql &= ", bpc.tsccod_1 as tipo_cliente FROM ((BPARTNER bpr INNER JOIN BPCUSTOMER bpc ON (bprnum_0 = bpcnum_0)) INNER JOIN BPADDRESS bpa ON (bpcnum_0 = bpanum_0)) LEFT JOIN SALESREP ON (rep_0 = repnum_0) "
        Sql &= "WHERE  bpcpyr_0 = :bpcpyr_0 "
        Sql &= "ORDER BY bpcnam_0, bpaaddlig_0"
        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("bpcpyr_0", OracleType.VarChar).Value = tipo

        dt2.Clear()
        da.Fill(dt2)

        If dt2.Rows.Count = 0 Then
            MsgBox("El cliente no tiene facturas en esta sucursal")
        Else
            Dim f As New frmConsorcios(dt2)
            f.MdiParent = frmMain
            f.Show()
        End If
    End Sub
    Private Sub ContextMenuStrip1_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        Dim tipo As String = dgv.CurrentRow.Cells("tipo_cliente").Value.ToString

        If tipo = "10" Then
            ConsorciosToolStripMenuItem.Enabled = True
        Else
            ConsorciosToolStripMenuItem.Enabled = False
        End If
    End Sub
    Private Sub ParqueDeLaSucursalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ParqueDeLaSucursalToolStripMenuItem.Click
        Dim abonado As String = dgv.CurrentRow.Cells("abonado").Value.ToString
        Dim rpt As New ReportDocument
        Dim txt As String = dgv.CurrentRow.Cells("codrep").Value.ToString
        Dim cliente As String = dgv.CurrentRow.Cells("codigo").Value.ToString
        Dim sucursal As String = dgv.CurrentRow.Cells("suc").Value.ToString
        Dim crystal As frmCrystal
        If abonado = "2" Then
            rpt.Load(RPTX3 & "xparquen3.rpt")
            rpt.SetParameterValue("OFF_HIDRA", False)
        Else
            rpt.Load(RPTX3 & "xparquen.rpt")
        End If
        rpt.SetDatabaseLogon(DB_USR, DB_PWD)
        rpt.SetParameterValue("SUCDEB", sucursal)
        rpt.SetParameterValue("SUCFIN", sucursal)
        rpt.SetParameterValue("bpc", cliente)
        rpt.SetParameterValue("fecvenc", Today)

        If usr.Codigo = "LVER" Or usr.Codigo = "DBAT" Or usr.Codigo = "MBARC" Then
            'txt = InputBox("Ingrese el vendedor que quiere ver en el reporte", txt)
            rpt.SetParameterValue("x3usr", txt)
        Else
            rpt.SetParameterValue("x3usr", usr.Codigo)
        End If
        crystal = New frmCrystal(rpt)
        crystal.MdiParent = Me.ParentForm
        crystal.Show()
    End Sub
    Private Sub ParqueGeneralToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ParqueGeneralToolStripMenuItem.Click
        Dim abonado As String = dgv.CurrentRow.Cells("abonado").Value.ToString
        Dim rpt As New ReportDocument
        Dim txt As String = dgv.CurrentRow.Cells("codrep").Value.ToString
        Dim cliente As String = dgv.CurrentRow.Cells("codigo").Value.ToString
        Dim crystal As frmCrystal

        '12.04.2018 //Isa pide que solo salga el reporte de parque normal
        'If abonado = "2" Then
        '    rpt.Load(RPTX3 & "xparquen3.rpt")
        '    rpt.SetParameterValue("OFF_HIDRA", False)
        'Else
        rpt.Load(RPTX3 & "xparquen.rpt")
        'End If
        rpt.SetDatabaseLogon(DB_USR, DB_PWD)
        Dim sucursal As String = "000"
        Dim sucursal2 As String = "999"
        rpt.SetParameterValue("SUCDEB", sucursal)
        rpt.SetParameterValue("SUCFIN", sucursal2)
        rpt.SetParameterValue("bpc", cliente)
        rpt.SetParameterValue("fecvenc", Today)

        If usr.Codigo = "LVER" Or usr.Codigo = "DBAT" Or usr.Codigo = "MBARC" Then
            'txt = InputBox("Ingrese el vendedor que quiere ver en el reporte", txt)
            rpt.SetParameterValue("x3usr", txt)
        Else
            rpt.SetParameterValue("x3usr", usr.Codigo)
        End If
        crystal = New frmCrystal(rpt)
        crystal.MdiParent = Me.ParentForm
        crystal.Show()

    End Sub

    Private Sub frmBuscaClientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim tb As New TablaVaria(cn, 364)
        cboprov.DataSource = tb.Tabla2
        cboprov.ValueMember = ("ident2_0")
        cboprov.DisplayMember = ("texte_0")
    End Sub

    Private Sub btnProv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProv.Click
        Dim Sql As String
        Dim da As OracleDataAdapter
        Dim dt2 As New DataTable
        Sql = "SELECT bpcnum_0 as CODIGO,bpclon_0 as NOMBRE_FANTASIA, bpcnam_0 AS NOMBRE, bpaadd_0 AS SUC, bpaaddlig_0 AS DOMICILIO, cty_0 AS CIUDAD, rep_0 AS CODREP, repnam_0 AS VENDEDOR, xinterno_0 AS interno " & _
              ", bpc.tsccod_1 as tipo_cliente,bpc.xabo_0 as abonado,bpa.sat_0 as Provincia  FROM ((BPARTNER bpr INNER JOIN BPCUSTOMER bpc ON (bprnum_0 = bpcnum_0)) INNER JOIN BPADDRESS bpa ON (bpcnum_0 = bpanum_0)) LEFT JOIN SALESREP ON (rep_0 = repnum_0) " & _
              "WHERE  bpa.sat_0 LIKE :sat_0 " & _
              "ORDER BY bpcnam_0, bpaaddlig_0"

        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("sat_0", OracleType.VarChar).Value = cboprov.SelectedValue
        Try
            dt.Clear()
            da.Fill(dt)

            If dt.Rows.Count = 0 Then
                Label5.Visible = True
                txt.Clear()

            Else
                Label5.Visible = False
                EnlazarGrilla()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            da.Dispose()
            da = Nothing

        End Try


    End Sub

    Private Sub RemitosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemitosToolStripMenuItem.Click
        Dim Sql As String
        Dim da As OracleDataAdapter
        Dim dt2 As New DataTable
        Dim cliente As String = dgv.CurrentRow.Cells("codigo").Value.ToString
        Dim sucursal As String = dgv.CurrentRow.Cells("suc").Value.ToString

        Sql = "select sdhnum_0 as codigo,dlvdat_0 as fecha, stofcy_0 as planta, bpcord_0 as codigo_cliente,bpaadd_0 as sucursal, bpdnam_0 as nombre"
        Sql &= ",(select max(ruta_0) from xrutad where vcrnum_0 = sdhnum_0) as ruta, "
        Sql &= "(select min(para_0) from xsegto where rto_0 = sdhnum_0) as sector "
        Sql &= "from sdelivery	where bpcord_0 = :bpcord_0 and bpaadd_0 = :bpaadd_0  order by dlvdat_0 desc"
        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("bpcord_0", OracleType.VarChar).Value = cliente
        da.SelectCommand.Parameters.Add("bpaadd_0", OracleType.VarChar).Value = sucursal
        dt2.Clear()
        da.Fill(dt2)

        If dt2.Rows.Count = 0 Then
            MsgBox("El cliente no tiene remitos en esta sucursal")

        Else
            Dim f As New frmRemitoslist(dt2)
            f.MdiParent = frmMain
            f.Show()

        End If
    End Sub

    Private Sub TerceroPagadorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TerceroPagadorToolStripMenuItem.Click
        Dim rpt As New ReportDocument
        Dim cliente As String = dgv.CurrentRow.Cells("codigo").Value.ToString

        'Dim Sql As String
        'Dim da As OracleDataAdapter
        Dim dt2 As New DataTable
        'Sql = "select bpcpyr_0 from bpcustomer where bpcnum_0 = :bpcpay"
        'da = New OracleDataAdapter(Sql, cn)
        'da.SelectCommand.Parameters.Add("bpcpay", OracleType.VarChar).Value = cliente
        'dt2.Clear()
        'da.Fill(dt2)
        'Dim dr As DataRow = dt2.Rows(0)
        'Dim pagador As String = dr("bpcpyr_0").ToString
        Dim crystal As frmCrystal
        rpt.Load(RPTX3 & "XBPCXPAY.rpt")
        rpt.SetDatabaseLogon(DB_USR, DB_PWD)
        rpt.SetParameterValue("BPCPYR", cliente)
        rpt.SetParameterValue("X3TIT", "Tercero Pagador")
        '  rpt.SetParameterValue("X3DOS", X3DOS)
        crystal = New frmCrystal(rpt)
        crystal.MdiParent = Me.ParentForm
        crystal.Show()
    End Sub

    Private Sub PresupuestoPorClienteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PresupuestoPorClienteToolStripMenuItem.Click
        Dim Sql As String
        Dim da As OracleDataAdapter
        Dim dt2 As New DataTable
        Dim cliente As String = dgv.CurrentRow.Cells("codigo").Value.ToString
        Dim sucursal As String = dgv.CurrentRow.Cells("suc").Value.ToString
        Dim tipo As String = dgv.CurrentRow.Cells("tipo_cliente").Value.ToString
        Sql = "select sqhnum_0 as Numero, quodat_0 as Fecha,bpcord_0 as Codigo, bpcnam_0 as Nombre, bpcaddlig_0 as Direccion, bpaadd_0 as Sucursal, quonot_0 as Total "
        Sql &= "from squote where bpcord_0 = :bpcord_0 order by quodat_0 desc "
        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("bpcord_0", OracleType.VarChar).Value = cliente
        ' da.SelectCommand.Parameters.Add("bpaadd_0", OracleType.VarChar).Value = sucursal

        dt2.Clear()
        da.Fill(dt2)

        If dt2.Rows.Count = 0 Then
            MsgBox("El cliente no tiene presupuestos ")

        Else
            Dim f As New frmPresuList(dt2, tipo)
            f.MdiParent = frmMain
            f.Show()

        End If
    End Sub

    Private Sub PresupuestoPorSucursalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PresupuestoPorSucursalToolStripMenuItem.Click
        Dim Sql As String
        Dim da As OracleDataAdapter
        Dim dt2 As New DataTable
        Dim cliente As String = dgv.CurrentRow.Cells("codigo").Value.ToString
        Dim sucursal As String = dgv.CurrentRow.Cells("suc").Value.ToString
        Dim tipo As String = dgv.CurrentRow.Cells("tipo_cliente").Value.ToString
        Sql = "select sqhnum_0 as Numero, quodat_0 as Fecha,bpcord_0 as Codigo, bpcnam_0 as Nombre, bpcaddlig_0 as Direccion, bpaadd_0 as Sucursal, quonot_0 as Total "
        Sql &= "from squote where bpcord_0 = :bpcord_0 and bpaadd_0 = :bpaadd_0 order by quodat_0 desc "
        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("bpcord_0", OracleType.VarChar).Value = cliente
        da.SelectCommand.Parameters.Add("bpaadd_0", OracleType.VarChar).Value = sucursal

        dt2.Clear()
        da.Fill(dt2)

        If dt2.Rows.Count = 0 Then
            MsgBox("El cliente no tiene presupuestos en esta sucursal")

        Else
            Dim f As New frmPresuList(dt2, tipo)
            f.MdiParent = frmMain
            f.Show()

        End If
    End Sub

    'Private Sub cboprov_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboprov.LostFocus
    '    btnProv.Enabled = False
    'End Sub
    Private Sub cboprov_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboprov.GotFocus
        btnProv.Enabled = True
    End Sub

    Private Sub cboprov_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboprov.SelectedIndexChanged
    End Sub

   
    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        Dim Sql As String
        Dim da As OracleDataAdapter
        Dim dt2 As New DataTable
        Dim cliente As String = dgv.CurrentRow.Cells("codigo").Value.ToString
        'Dim sucursal As String = dgv.CurrentRow.Cells("suc").Value.ToString

        'Sql = "select num_0 as codigo, bpc_0 as cliente, bpaadd_0 as sucursal, typ_0 as tipo, dat_0 as fecha, xsector_0 as Sector from interven "
        'Sql &= "where bpc_0 = :bpcord_0 and bpaadd_0 = :bpaadd_0 order by dat_0 desc"
        Sql = "select num_0 as codigo, bpc_0 as cliente, bpaadd_0 as sucursal, typ_0 as tipo, dat_0 as fecha,"
        Sql &= "(select max(ruta_0) from xrutad where vcrnum_0 = num_0 ) as ruta ,xsector_0 as Sector, ysdhdeb_0 as remito, "
        Sql &= "yref_0 as OC,xcardat_0 as fecha_Carrito from interven "
        Sql &= "where bpc_0 = :bpcord_0 " 'and bpaadd_0 = :bpaadd_0 "
        Sql &= " group by num_0,bpc_0,bpaadd_0,typ_0,dat_0,xsector_0,ysdhdeb_0,yref_0,xcardat_0 order by dat_0 desc"
        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("bpcord_0", OracleType.VarChar).Value = cliente
        'da.SelectCommand.Parameters.Add("bpaadd_0", OracleType.VarChar).Value = sucursal
        dt2.Clear()
        da.Fill(dt2)

        If dt2.Rows.Count = 0 Then
            MsgBox("El cliente no tiene intervenciones en esta sucursal")

        Else
            Dim f As New frmItnList(dt2)
            f.MdiParent = frmMain
            f.Show()

        End If

        'Dim rpt As New ReportDocument
        'Dim cliente As String = dgv.CurrentRow.Cells("codigo").Value.ToString
        'Dim sucursal As String = dgv.CurrentRow.Cells("suc").Value.ToString
        'Dim crystal As frmCrystal
        'rpt.Load(RPTX3 & "xintervenB2.rpt")
        'rpt.SetDatabaseLogon(DB_USR, DB_PWD)
        'rpt.SetParameterValue("sucursal", sucursal)
        'rpt.SetParameterValue("cliente", cliente)
        'crystal = New frmCrystal(rpt)
        'crystal.MdiParent = Me.ParentForm
        'crystal.Show()

    End Sub

    Private Sub btnBuscarCilindro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCilindro.Click
        Dim f As New frmRastreo

        f.ShowDialog()

    End Sub
End Class