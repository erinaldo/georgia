Imports System.Data.OracleClient

Public Class frmRecepcionResumen

    Public Sub New(ByVal itn As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Dim da As OracleDataAdapter
        Dim dt As New DataTable
        Dim Sql As String = ""

        Sql = "select at2.texte_0 as tipo, at1.texte_0 as capacidad, count(sre.macnum_0) as cantidad  "
        Sql &= "from sremac sre inner join "
        Sql &= "	 machines mac on (sre.macnum_0 = mac.macnum_0) inner join "
        Sql &= "	 itmmaster itm on (mac.macpdtcod_0 = itm.itmref_0) inner join "
        Sql &= "	 atextra at2 on (itm.tsicod_2 = at2.ident2_0 and at2.ident1_0 = '22' and at2.codfic_0 = 'ATABDIV' and at2.zone_0 = 'LNGDES') inner join "
        Sql &= "	 atextra at1 on (itm.tsicod_1 = at1.ident2_0 and at1.ident1_0 = '21' and at1.codfic_0 = 'ATABDIV' and at1.zone_0 = 'LNGDES') "
        Sql &= "where yitnnum_0 = :itn "
        Sql &= "group by at2.texte_0, at1.texte_0 "
        Sql &= "order by at2.texte_0, at1.texte_0 "

        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("itn", OracleType.VarChar).Value = itn
        da.Fill(dt)
        da.Dispose()

        colTipo.DataPropertyName = "tipo"
        colCapacidad.DataPropertyName = "capacidad"
        colCantidad.DataPropertyName = "cantidad"
        dgv.DataSource = dt

    End Sub
    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

End Class