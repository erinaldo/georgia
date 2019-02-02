Imports System.Data.OracleClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class frmClientesSinMovimiento
    Dim dt As New DataTable
    Dim da As OracleDataAdapter
    Dim sql As String
    Dim bpc As New Cliente(cn)
    

    Private Sub VencimientosVencidosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VencimientosVencidosToolStripMenuItem.Click
        Dim rpt As New ReportDocument
        Dim cliente As String = dgv.CurrentRow.Cells("codigo").Value.ToString
        Dim crystal As frmCrystal
        rpt.Load(RPTX3 & "XPARQUE2.rpt")
        rpt.SetDatabaseLogon(DB_USR, DB_PWD)
        rpt.SetParameterValue("bpc", cliente)
        rpt.SetParameterValue("fcyitn", "001")
        rpt.SetParameterValue("x3tit", "Distribucion de vencimientos")
        rpt.SetParameterValue("x3usr", usr.Codigo)
        crystal = New frmCrystal(rpt)
        crystal.MdiParent = Me.ParentForm
        crystal.Show()


    End Sub

    Private Sub BtnCargar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCargar.Click
        If CboxTipo.SelectedItem Is Nothing Then
            MessageBox.Show("Debe elegir tipo de cliente")
            Exit Sub
        End If
        cargar()
    End Sub
    Private Sub cargar()
        dt.Clear()
        dgv.DataSource = dt

        sql = "select bpcnum_0 as codigo, bpcnam_0 as Razon_Social, bpa.web_0 as Mail, bpa.tel_0 as Telefono, bpa.xportero_0 as Contacto, bpa.xpor_tel_0 as Tel_Contacto,bpaaddlig_0  as Direccion,sat_0 as Provincia,cty_0 as Localidad, tsccod_1  as tipo,"
        sql &= "(select count(bpanum_0) from bpaddress where bpanum_0 = bpcnum_0) as Cantidad_sucursales "
        sql &= "from bpcustomer bpc inner join bpaddress bpa on (bpc.bpcnum_0 = bpa.bpanum_0 and bpa.bpaadd_0 = '001') where tsccod_1 not in ('11','50','90') and bpcsta_0 = 2 and ostctl_0 <> 3 and ( "
        sql &= "bpcnum_0 not in (select bpr_0 from sinvoice where accdat_0 > (sysdate - 730) ) and "
        sql &= "bpcnum_0 not in (select bpcord_0 from squote where quodat_0 > (sysdate - 730))) and rep_0 = '07' "
        If Not CboxTipo.SelectedItem.ToString = "TODOS" Then
            sql &= " and tsccod_1 = " & CboxTipo.SelectedItem.ToString
        Else
            sql &= "order by bpcnum_0 "
        End If

        da = New OracleDataAdapter(sql, cn)
        da.Fill(dt)

        dgv.DataSource = dt
    End Sub
    Private Sub FiltrarVencimientosPorTipo()
        Dim dr As DataRow

        dt.RejectChanges()

        'Carga de servicios dependiendo del tipo de intervencion seleccionado
        Select Case CboxTipo.SelectedItem.ToString
            Case "10"
                For Each dr In dt.Rows
                    If Not dr("tipo").ToString.StartsWith("10") Then
                        dr.Delete()
                    End If
                Next
            Case "11"
                For Each dr In dt.Rows
                    If Not dr("tipo").ToString.StartsWith("11") Then
                        dr.Delete()
                    End If
                Next
            Case "20"
                For Each dr In dt.Rows
                    If Not dr("tipo").ToString.StartsWith("20") Then
                        dr.Delete()
                    End If
                Next
            Case "30"
                For Each dr In dt.Rows
                    If Not dr("tipo").ToString.StartsWith("30") Then
                        dr.Delete()
                    End If
                Next
            Case "40"
                For Each dr In dt.Rows
                    If Not dr("tipo").ToString.StartsWith("40") Then
                        dr.Delete()
                    End If
                Next
            Case "50"
                For Each dr In dt.Rows
                    If Not dr("tipo").ToString.StartsWith("50") Then
                        dr.Delete()
                    End If
                Next
            Case "60"
                For Each dr In dt.Rows
                    If Not dr("tipo").ToString.StartsWith("60") Then
                        dr.Delete()
                    End If
                Next
            Case "70"
                For Each dr In dt.Rows
                    If Not dr("tipo").ToString.StartsWith("70") Then
                        dr.Delete()
                    End If
                Next
            Case "80"
                For Each dr In dt.Rows
                    If Not dr("tipo").ToString.StartsWith("80") Then
                        dr.Delete()
                    End If
                Next
            Case "90"
                For Each dr In dt.Rows
                    If Not dr("tipo").ToString.StartsWith("90") Then
                        dr.Delete()
                    End If
                Next
        End Select

    End Sub
   
    Private Sub CboxTipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboxTipo.SelectedIndexChanged
        'FiltrarVencimientosPorTipo()
    End Sub
End Class