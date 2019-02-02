Imports System.Data.OracleClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class frmConsorcios
    Private dt As DataTable


    Public Sub New(ByVal dt As DataTable)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.dt = dt


    End Sub
    Private Sub EnlazarGrilla()
        If dgv.DataSource Is Nothing Then
            dgv.DataSource = dt
            dgv.AutoResizeColumns()
            For i As Integer = 0 To dgv.Columns.Count - 1
                dgv.Columns(i).Visible = True
            Next

        End If
    End Sub
    Private Sub frmFacturaList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        EnlazarGrilla()
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

        Sql = "select num_0 as codigo, bpc_0 as cliente, bpaadd_0 as sucursal, typ_0 as tipo, dat_0 as fecha  from interven "
        Sql &= "where bpc_0 = :bpcord_0 and bpaadd_0 = :bpaadd_0 order by dat_0 desc"
        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("bpcord_0", OracleType.VarChar).Value = cliente
        da.SelectCommand.Parameters.Add("bpaadd_0", OracleType.VarChar).Value = sucursal

        dt2.Clear()
        da.Fill(dt2)

        If dt2.Rows.Count = 0 Then
            MsgBox("El cliente no tiene facturas en esta sucursal")

        Else
            Dim f As New frmItnList(dt2)
            f.MdiParent = frmMain
            f.Show()

        End If
    End Sub

    Private Sub PedidosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PedidosToolStripMenuItem.Click
        Dim rpt As New ReportDocument
        Dim cliente As String = dgv.CurrentRow.Cells("codigo").Value.ToString
        Dim sucursal As String = dgv.CurrentRow.Cells("suc").Value.ToString
        Dim crystal As frmCrystal
        rpt.Load(RPTX3 & "xpedidos2B2.rpt")
        rpt.SetDatabaseLogon(DB_USR, DB_PWD)
        rpt.SetParameterValue("sucursal", sucursal)
        rpt.SetParameterValue("cliente", cliente)
        crystal = New frmCrystal(rpt)
        crystal.MdiParent = Me.ParentForm
        crystal.Show()
    End Sub

    Private Sub PresupuestosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PresupuestosToolStripMenuItem.Click
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

    Private Sub FacturasCToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FacturasCToolStripMenuItem.Click
        Dim Sql As String
        Dim da As OracleDataAdapter
        Dim dt2 As New DataTable
        Dim cliente As String = dgv.CurrentRow.Cells("codigo").Value.ToString
        Dim sucursal As String = dgv.CurrentRow.Cells("suc").Value.ToString

        Sql = "select num_0 as codigo, credat_0 as fecha, bpcord_0 as cliente,bpdnam_0 as nombre_cliente, "
        Sql &= "bpdaddlig_0 as direccion, vatnet_0 as importeAI, vatamt_0 as impuestos "
        Sql &= "from sinvoicev where bpcord_0 = :bpcord_0 and bpaadd_0 = :bpaadd_0 order by credat_0 desc"
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

        Sql = "select num_0 as codigo, credat_0 as fecha, bpcord_0 as cliente,bpaadd_0 as Sucursal,bpdnam_0 as nombre_cliente, "
        Sql &= "bpdaddlig_0 as direccion, vatnet_0 as importeAI, vatamt_0 as impuestos "
        Sql &= "from sinvoicev where bpcord_0 = :bpcord_0 order by credat_0 desc"
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
End Class