Imports Clases
Imports System.Data.OracleClient

Public Class frmUnificarParque

    Private FechaIni As Date
    Private FechaFin As Date

    Private Sub frmUnificarParque_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AddHandler dgv.RowPostPaint, AddressOf NumeracionGrillas
    End Sub
    Private Sub BuscarParqueDisperso()
        Dim da As OracleDataAdapter
        Dim txt As String
        Dim dt As New DataTable

        txt = "select bpc.tsccod_1,bpc.bpcnam_0, mac.bpcnum_0, mac.fcyitn_0, EXTRACT(MONTH FROM datnext_0) as MM, EXTRACT(YEAR FROM datnext_0) as AA, count(ymc.macnum_0) as cantidad "
        txt &= "from machines mac inner join ymacitm ymc on (mac.macnum_0 = ymc.macnum_0) inner join "
        txt &= "	 bomd bmd on (mac.macpdtcod_0 = bmd.itmref_0 and ymc.cpnitmref_0 = bmd.cpnitmref_0) inner join "
        txt &= "	 bpcustomer bpc on (mac.bpcnum_0 = bpc.bpcnum_0) "
        txt &= "where datnext_0 >= :ini and datnext_0 < :fin and "
        txt &= "	  bomalt_0 = 99 and "
        txt &= "	  bomseq_0 = 10 and "
        txt &= "	  ymc.cpnitmref_0 like '451%' and "
        txt &= "	  macitntyp_0 = 1 and "

        If chkAbonados.Checked Then
            txt &= "	  xabo_0 = 2 "
        Else
            txt &= "	  xabo_0 <> 2 "
        End If

        txt &= "group by tsccod_1, mac.bpcnum_0, mac.fcyitn_0, EXTRACT(YEAR FROM datnext_0), EXTRACT(MONTH FROM datnext_0),bpcnam_0 "
        txt &= "order by tsccod_1, bpcnum_0, fcyitn_0, AA, MM"

        da = New OracleDataAdapter(txt, cn)
        da.SelectCommand.Parameters.Add("ini", OracleType.DateTime).Value = FechaIni
        da.SelectCommand.Parameters.Add("fin", OracleType.DateTime).Value = FechaFin
        dt.Clear()
        da.Fill(dt)

        Dim dv As New DataView(dt)
        Dim i As Integer

        'Eliminar parque que ya está unificado
        For Each dr As DataRow In dt.Rows
            i += 1
            txt = "Procesando {x} de {y}"
            txt = txt.Replace("{x}", i.ToString)
            txt = txt.Replace("{y}", dt.Rows.Count.ToString)

            If i Mod 100 = 0 OrElse i >= dt.Rows.Count Then
                lbl1.Text = txt
                Application.DoEvents()
            End If

            txt = "bpcnum_0 = '{bpc}' and fcyitn_0 = '{add}'"
            txt = txt.Replace("{bpc}", dr("bpcnum_0").ToString)
            txt = txt.Replace("{add}", dr("fcyitn_0").ToString)
            dv.RowFilter = txt

            If dv.Count = 1 Then dr.Delete()

        Next

        dt.AcceptChanges()

        If dgv.DataSource Is Nothing Then
            colTipo.DataPropertyName = "tsccod_1"
            colCliente.DataPropertyName = "bpcnum_0"
            colNomCliente.DataPropertyName = "bpcnam_0"
            colSucursal.DataPropertyName = "fcyitn_0"
            colAno.DataPropertyName = "AA"
            colMes.DataPropertyName = "MM"
            colVtos.DataPropertyName = "cantidad"
        End If

        dgv.DataSource = dt

    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        btnBuscar.Enabled = False
        lbl1.Text = "Buscando..."
        lbl1.Visible = True
        Me.UseWaitCursor = True

        Application.DoEvents()
        Application.DoEvents()

        FechaIni = New Date(dtp.Value.Year, dtp.Value.Month, 1)
        FechaFin = FechaIni.AddYears(1)
        BuscarParqueDisperso()

        Me.UseWaitCursor = False
        lbl1.Visible = False
        btnBuscar.Enabled = True

        Application.DoEvents()

    End Sub

    Private Sub ContextMenuStrip1_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        Dim flg = True
        Dim dr As DataRow
        Dim Cli As String = ""
        Dim Suc As String = ""

        If dgv.SelectedRows.Count <= 1 Then
            e.Cancel = True
            Exit Sub
        End If

        For i = 0 To dgv.SelectedRows.Count - 1

            dr = CType(dgv.SelectedRows(i).DataBoundItem, DataRowView).Row

            If i = 0 Then
                Cli = dr("bpcnum_0").ToString
                Suc = dr("fcyitn_0").ToString
            Else
                If Cli <> dr("bpcnum_0").ToString Or Suc <> dr("fcyitn_0").ToString Then
                    flg = False
                End If
            End If

            If Not flg Then Exit For
        Next

        ContextMenuStrip1.Items.Clear()

        If flg Then
            Dim mnu As ToolStripMenuItem

            For i = dgv.SelectedRows.Count - 1 To 0 Step -1
                Dim f As Date
                dr = CType(dgv.SelectedRows(i).DataBoundItem, DataRowView).Row

                f = New Date(CInt(dr("AA")), CInt(dr("MM")), 1)

                mnu = New ToolStripMenuItem(f.ToString("MM/yyyy"))
                mnu.Tag = f

                AddHandler mnu.Click, AddressOf mnuUnificar_Click

                ContextMenuStrip1.Items.Add(mnu)
            Next
        End If

    End Sub

    Private Sub mnuUnificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim mnu As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        Dim NuevoVto As Date = CType(mnu.Tag, Date)
        Dim txt As String

        txt = "¿Confirma unificar " & mnu.Text & "?"
        If MessageBox.Show(txt, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2) <> Windows.Forms.DialogResult.Yes Then
            Exit Sub
        End If

        Me.Enabled = False
        Me.UseWaitCursor = True

        For i = 0 To dgv.SelectedRows.Count - 1
            Dim dr As DataRow = CType(dgv.SelectedRows(i).DataBoundItem, DataRowView).Row
            Dim MM As Integer = CInt(dr("MM"))
            Dim AA As Integer = CInt(dr("AA"))

            If Not (NuevoVto.Month = MM AndAlso NuevoVto.Year = AA) Then
                Unificar(dr("bpcnum_0").ToString, dr("fcyitn_0").ToString, CInt(dr("MM")), CInt(dr("AA")), NuevoVto)
            End If

        Next
        For i = dgv.SelectedRows.Count - 1 To 0 Step -1
            Dim dr As DataRow = CType(dgv.SelectedRows(i).DataBoundItem, DataRowView).Row
            dr.Delete()
        Next

        CType(dgv.DataSource, DataTable).AcceptChanges()

        Me.UseWaitCursor = False
        Me.Enabled = True

    End Sub

    Private Sub Unificar(ByVal bpc As String, ByVal fcy As String, ByVal MM As Integer, ByVal AA As Integer, ByVal fecha As Date)
        Dim mac As New Parque(cn)
        Dim da As OracleDataAdapter
        Dim txt As String
        Dim dt As New DataTable
        Dim f1, f2 As Date

        f1 = New Date(AA, MM, 1)
        f2 = f1.AddMonths(1)

        txt = "select mac.macnum_0 "
        txt &= "from machines mac inner join ymacitm ymc on (mac.macnum_0 = ymc.macnum_0) inner join "
        txt &= "	 bomd bmd on (mac.macpdtcod_0 = bmd.itmref_0 and ymc.cpnitmref_0 = bmd.cpnitmref_0) "
        txt &= "where datnext_0 >= :ini and datnext_0 < :fin and "
        txt &= "	  bomalt_0 = 99 and "
        txt &= "	  bomseq_0 = 10 and "
        txt &= "	  ymc.cpnitmref_0 like '451%' and "
        txt &= "	  macitntyp_0 = 1 and "
        txt &= "	  mac.bpcnum_0 = :bpc and "
        txt &= "	  mac.fcyitn_0 = :fcy "

        da = New OracleDataAdapter(txt, cn)
        da.SelectCommand.Parameters.Add("ini", OracleType.DateTime).Value = f1
        da.SelectCommand.Parameters.Add("fin", OracleType.DateTime).Value = f2
        da.SelectCommand.Parameters.Add("bpc", OracleType.VarChar).Value = bpc
        da.SelectCommand.Parameters.Add("fcy", OracleType.VarChar).Value = fcy
        dt.Clear()
        da.Fill(dt)

        For Each dr As DataRow In dt.Rows
            If mac.Abrir(dr(0).ToString) Then
                mac.VtoCarga = fecha
                mac.Observaciones = "Vto unificado el dia " & Date.Today
                mac.Grabar()
            End If
        Next

    End Sub

End Class