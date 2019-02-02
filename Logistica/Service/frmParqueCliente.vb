Imports System.Data.OracleClient

Public Class frmParqueCliente
    Private Cliente As String
    Private Sucursal As String

    Public Sub New(ByVal Cliente As String, ByVal Sucursal As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.Cliente = Cliente
        Me.Sucursal = Sucursal

    End Sub
    Private Sub Buscar()
        Dim Sql As String
        Dim da As OracleDataAdapter
        Dim dt As DataTable

        If rbSinPuesto.Checked Then
            Sql = "SELECT macnum_0, macdes_0, ynrocil_0, EXTRACT(YEAR FROM yfabdat_0) AS yfabdat_0, fcyitn_0, bpaaddlig_0, cty_0, "
            Sql &= "	 (SELECT datnext_0 FROM (machines mac2 INNER JOIN ymacitm ymc ON (mac2.macnum_0 = ymc.macnum_0)) INNER JOIN bomd bod ON (ymc.cpnitmref_0 = bod.cpnitmref_0 AND macpdtcod_0 = itmref_0) WHERE mac2.macnum_0 = mac.macnum_0 AND bomalt_0 = 99 AND bomseq_0 = 10) AS vto "
            Sql &= "FROM machines mac INNER JOIN "
            Sql &= "     bpaddress bpa ON (bpcnum_0 = bpanum_0 AND mac.fcyitn_0 = bpaadd_0) INNER JOIN "
            Sql &= "     itmmaster ON (macpdtcod_0 = itmref_0) "
            Sql &= "WHERE tsicod_3 IN ('301', '302') AND " '(macpdtcod_0 = '999021' OR macdes_0 LIKE 'EXT.%' OR macdes_0 LIKE 'MANGUERA%') AND"
            Sql &= "      tclcod_0 <> '60' AND "
            Sql &= "      bpcnum_0 = :bpcnum_0 AND "
            Sql &= "      macnum_0 NOT IN (SELECT macnum_0 FROM xpuestos) AND bpcnum_0 = :bpcnum_0 "

        Else
            Sql = "SELECT macnum_0, macdes_0, ynrocil_0, EXTRACT(YEAR FROM yfabdat_0) AS yfabdat_0, fcyitn_0, bpaaddlig_0, cty_0, "
            Sql &= "	  (SELECT datnext_0 FROM (machines mac2 INNER JOIN ymacitm ymc ON (mac2.macnum_0 = ymc.macnum_0)) INNER JOIN bomd bod ON (ymc.cpnitmref_0 = bod.cpnitmref_0 AND macpdtcod_0 = itmref_0) WHERE mac2.macnum_0 = mac.macnum_0 AND bomalt_0 = 99 AND bomseq_0 = 10) AS vto "
            Sql &= "FROM (machines mac INNER JOIN bpaddress bpa ON (bpcnum_0 = bpanum_0 AND mac.fcyitn_0 = bpaadd_0)) INNER JOIN itmmaster ON (macpdtcod_0 = itmref_0) "
            Sql &= "WHERE tclcod_0 <> '60' AND (macpdtcod_0 = '999021' OR macdes_0 LIKE 'EXT.%' OR macdes_0 LIKE 'MANGUERA%') AND bpcnum_0 = :bpcnum_0 "

        End If

        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("bpcnum_0", OracleType.VarChar).Value = Cliente

        If dgv.DataSource Is Nothing Then
            dt = New DataTable
            dgv.DataSource = dt
            colSerie.DataPropertyName = "macnum_0"
            colEquipo.DataPropertyName = "macdes_0"
            colCilindro.DataPropertyName = "ynrocil_0"
            colFab.DataPropertyName = "yfabdat_0"
            colVto.DataPropertyName = "vto"
            colSuc.DataPropertyName = "fcyitn_0"
            colDomicilio.DataPropertyName = "bpaaddlig_0"
            colCiudad.DataPropertyName = "cty_0"

        Else
            dt = CType(dgv.DataSource, DataTable)

        End If

        dt.Clear()
        da.Fill(dt)
        da.Dispose()

    End Sub

    Private Sub frmParqueCliente_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AddHandler dgv.RowPostPaint, AddressOf NumeracionGrillas

        rbSinPuesto.Checked = True
    End Sub

    Private Sub rbSinPuesto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSinPuesto.CheckedChanged
        If rbSinPuesto.Checked Then Buscar()
    End Sub

    Private Sub rbTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbTodos.CheckedChanged
        If rbTodos.Checked Then Buscar()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If dgv.SelectedRows.Count = 1 Then
            Dim dr As DataRow = CType(dgv.SelectedRows(0).DataBoundItem, DataRowView).Row
            Me.Tag = dr("macnum_0").ToString
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()

        ElseIf dgv.SelectedRows.Count > 1 Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Else

            MessageBox.Show("Debe seleccionar un equipo", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)

        End If

    End Sub

End Class