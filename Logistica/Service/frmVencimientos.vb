Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.OracleClient
Imports System.IO
Imports System.Collections

Public Class frmVencimientos '2034
    Private oMail As New CorreoElectronico
    Private dMin As Date
    Private dtVencimientos As New DataTable
    Private dtDetalle As New DataTable
    Private bpc As Cliente
    Private bpa As Sucursal
    Private bpc2 As Cliente 'Tercero Pagador
    Private bpa2 As Sucursal 'Sucursal tercero pagador

    Private com As New ComentariosVencimientos(cn)

    Private da1 As OracleDataAdapter 'Resumen de Vencimientos
    Private da2 As OracleDataAdapter 'Detalle de Vencimientos
    Private da3 As OracleDataAdapter 'Consulta de ultimo proceso

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Adaptadores()

        Dim tb As New TablaVaria(cn, 407, True)
        tb.EnlazarListBox(lstTipos)

    End Sub
    Private Sub Adaptadores()
        Dim Sql As String

        'Resumen de vencimientos
        Sql = "SELECT ymc.cpnitmref_0, itm.tsicod_2, tsicod_1, SUM(mac.macqty_0) AS CANT "
        Sql &= "FROM machines  mac INNER JOIN "
        Sql &= "     ymacitm   ymc ON (mac.macnum_0 = ymc.macnum_0) INNER JOIN "
        Sql &= "     bomd      bmd ON (mac.macpdtcod_0 = bmd.itmref_0 AND ymc.cpnitmref_0 = bmd.cpnitmref_0 AND bomalt_0 = 99 AND bomseq_0 = 10) INNER JOIN "
        Sql &= "     itmmaster itm ON (mac.macpdtcod_0 = itm.itmref_0) "
        Sql &= "WHERE bomalt_0 = 99 AND "
        Sql &= "	  bomseq_0 = 10 AND "
        Sql &= "	  macitntyp_0 = 1 AND "
        Sql &= "	  datnext_0 >= to_date(:desde, 'dd/mm/yyyy') AND "
        Sql &= "	  datnext_0 <  to_date(:hasta, 'dd/mm/yyyy') AND "
        Sql &= "	  mac.bpcnum_0 = :bpcnum_0 AND "
        Sql &= "	  mac.fcyitn_0 = :fcyitn_0 AND "
        Sql &= "	  mac.xitn_0 IN (' ', 'X0') "
        Sql &= "GROUP BY ymc.cpnitmref_0, itm.tsicod_2, tsicod_1 "
        Sql &= "ORDER BY ymc.cpnitmref_0"

        da1 = New OracleDataAdapter(Sql, cn)
        da1.SelectCommand.Parameters.Add("desde", OracleType.VarChar)
        da1.SelectCommand.Parameters.Add("hasta", OracleType.VarChar)
        da1.SelectCommand.Parameters.Add("bpcnum", OracleType.VarChar)
        da1.SelectCommand.Parameters.Add("fcyitn", OracleType.VarChar)

        'Detalle de vencimientos
        Sql = "SELECT mac.macnum_0, ynrocil_0, itm.tsicod_2, tsicod_1, yfabdat_0, ' ' as itn, sysdate as ingreso "
        Sql &= "FROM machines mac INNER JOIN "
        Sql &= "     ymacitm ymc ON (mac.macnum_0 = ymc.macnum_0) INNER JOIN "
        Sql &= "     bomd bmd ON (macpdtcod_0 = bmd.itmref_0 AND ymc.cpnitmref_0 = bmd.cpnitmref_0 AND bomalt_0 = 99 AND bomseq_0 = 10) INNER JOIN "
        Sql &= "     itmmaster itm on (mac.macpdtcod_0 = itm.itmref_0) "
        Sql &= "WHERE macitntyp_0 = 1 AND "
        Sql &= "	  datnext_0 >= to_date(:desde, 'dd/mm/yyyy') AND "
        Sql &= "	  datnext_0 <  to_date(:hasta, 'dd/mm/yyyy') AND "
        Sql &= "	  mac.bpcnum_0 = :bpcnum_0 AND "
        Sql &= "	  mac.fcyitn_0 = :fcyitn_0 AND "
        Sql &= "	  mac.xitn_0 IN (' ', 'X0') AND "
        Sql &= "      itm.tsicod_3 = '301' "
        Sql &= "ORDER BY ymc.cpnitmref_0"

        da2 = New OracleDataAdapter(Sql, cn)
        da2.SelectCommand.Parameters.Add("desde", OracleType.VarChar)
        da2.SelectCommand.Parameters.Add("hasta", OracleType.VarChar)
        da2.SelectCommand.Parameters.Add("bpcnum", OracleType.VarChar)
        da2.SelectCommand.Parameters.Add("fcyitn", OracleType.VarChar)

        Sql = "select * from sremac where macnum_0 = :macnum order by credat_0 desc"
        da3 = New OracleDataAdapter(Sql, cn)
        da3.SelectCommand.Parameters.Add("macnum", OracleType.VarChar)

    End Sub

    Private Sub frmVencimientos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AddHandler dgvResumen.RowPostPaint, AddressOf NumeracionGrillas
        AddHandler dgvDetalle.RowPostPaint, AddressOf NumeracionGrillas
    End Sub
    Private Sub CargarArbol()
        Dim Sql As String
        Dim da1, da2 As OracleDataAdapter
        Dim dt1 As New DataTable    'Tabla con los vendedores que puede ver el usuario
        Dim dt2 As New DataTable    'Tabla con todos los vencimientos
        Dim dr As DataRow
        Dim bpc As String = ""  'Codigo de tercero
        Dim fcy As String = ""  'Codigo de sucursal
        Dim tNode As TreeNode = Nothing
        Dim dv1, dv2 As DataView
        Dim Perdido As Boolean = False  'Para saber si todas las sucursales estan perdidas

        btnBuscar.Enabled = False
        tree.Nodes.Clear()  'limpio arbol
        Application.DoEvents()

        'Consulto vendedores que puede ver el usuario
        Sql = "SELECT * FROM xnetvenc WHERE usr_0 = :usr_0"
        da1 = New OracleDataAdapter(Sql, cn)
        da1.SelectCommand.Parameters.Add("usr_0", OracleType.VarChar).Value = usr.Codigo

        'Consulto vencimientos
        Sql = "SELECT DISTINCT mac.bpcnum_0, "
        Sql &= "	   		   bpc.bpcnam_0, "
        Sql &= "			   mac.fcyitn_0, "
        Sql &= "			   bpa.bpaaddlig_0, "
        Sql &= "			   bpc.tsccod_1, "
        Sql &= "			   bpc.bpcpyr_0, "
        Sql &= "			   pyr.bpcnam_0 AS admin_0, "
        Sql &= "			   pyr.rep_0, "
        Sql &= "			   mac.xitn_0, "
        Sql &= "			   bpc.xabo_0, "
        Sql &= "			   bpay.web_0 "
        Sql &= "FROM machines mac INNER JOIN "
        Sql &= "	 ymacitm ymc ON (mac.macnum_0 = ymc.macnum_0) INNER JOIN "
        Sql &= "	 bomd bmd ON (macpdtcod_0 = itmref_0 AND ymc.cpnitmref_0 = bmd.cpnitmref_0) INNER JOIN "
        Sql &= "	 bpcustomer bpc ON (mac.bpcnum_0 = bpc.bpcnum_0) INNER JOIN "
        Sql &= " 	 bpaddress bpa ON (mac.bpcnum_0 = bpa.bpanum_0 AND mac.fcyitn_0 = bpa.bpaadd_0) INNER JOIN "
        Sql &= "	 bpcustomer pyr ON (bpc.bpcpyr_0 = pyr.bpcnum_0) INNER JOIN "
        Sql &= "	 bpartner bpr ON (pyr.bpcnum_0 = bpr.bprnum_0) INNER JOIN "
        Sql &= " 	 bpaddress bpay ON (bpr.bpaadd_0 = bpay.bpaadd_0 AND bpr.bprnum_0 = bpay.bpanum_0) "
        Sql &= "WHERE bomalt_0 = 99 AND "
        Sql &= "	  bomseq_0 = 10 AND "
        Sql &= "	  macitntyp_0 = 1 AND "
        Sql &= "	  datnext_0 >= to_date(:datnext_0, 'dd/mm/yyyy') AND "
        Sql &= "	  datnext_0 < to_date(:datnext_1, 'dd/mm/yyyy') AND "
        Sql &= "	  mac.xitn_0 IN (' ', 'X0') "
        Sql &= "ORDER BY bpcnum_0, fcyitn_0"
        da2 = New OracleDataAdapter(Sql, cn)
        da2.SelectCommand.Parameters.Add("datnext_0", OracleType.VarChar).Value = dMin.ToString("dd/MM/yyyy")
        da2.SelectCommand.Parameters.Add("datnext_1", OracleType.VarChar).Value = dMin.AddMonths(1).ToString("dd/MM/yyyy")

        Try
            da1.Fill(dt1)   'Tabla de vendedores que puede ver el usuario
            da2.Fill(dt2)   'Tabla con los clientes con vencimientos

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        End Try

        dv1 = New DataView(dt1)
        dv2 = New DataView(dt2)

        'Elimino los registro de vendedores que no pertenecen al usuario
        For i As Integer = dt2.Rows.Count - 1 To 0 Step -1
            dr = dt2.Rows(i)
            dv1.RowFilter = "[rep_0] = '" & dr("rep_0").ToString & "'"

            If dv1.Count = 0 Then
                'No se deberia pasar nunca por aca. Solo si no existe el vendedor en la matriz de
                'vendedores permitidos para el usuario
                dt2.Rows.Remove(dr)

            Else
                If (CInt(dr("xabo_0")) = 2 AndAlso CInt(dv1(0).Item(2)) = 1) OrElse (CInt(dr("xabo_0")) <> 2 AndAlso CInt(dv1(0).Item(3)) = 1) Then

                    'Cuando se encuentra un cliente que tiene marca X0 (perdido) borra los registros siguientes
                    'que no tenga la misma marca
                    If dr("xitn_0").ToString = "X0" Then
                        bpc = dr("bpcnum_0").ToString
                        fcy = dr("fcyitn_0").ToString
                    Else
                        If dr("bpcnum_0").ToString = bpc AndAlso dr("fcyitn_0").ToString = fcy Then
                            dt2.Rows.Remove(dr)
                        End If
                    End If

                Else
                    'El usuario no puede ver el vencimiento
                    dt2.Rows.Remove(dr)

                End If

            End If

        Next

        '----------------------------------------------------------------------------------------
        ' CODIGO PARA AGREGAR AL ARBOL LOS CONSORCIOS ADMINISTRADOS
        '----------------------------------------------------------------------------------------
        dv2.RowFilter = "[tsccod_1] = '11'"
        dv2.Sort = "[bpcpyr_0], [bpcnum_0]"
        bpc = ""
        fcy = ""

        For i As Integer = 0 To dv2.Count - 1

            If bpc <> dv2(i).Item(5).ToString Then
                If Perdido And bpc <> "" Then tNode.ForeColor = Drawing.Color.Red
                Perdido = True

                bpc = dv2(i).Item(5).ToString
                tNode = tree.Nodes.Add(bpc, bpc & " " & dv2(i).Item(6).ToString)
            End If

            'Agrego consorcio
            With tNode.Nodes.Add(dv2(i).Item(0).ToString & "/" & dv2(i).Item(2).ToString, dv2(i).Item(3).ToString)
                .Tag = dv2(i).Item(1).ToString

                '04/02/2019 MARTI MIÑO
                'Si sucursal default del tercerp pagador no tiene mail, marco en violeta
                If Not oMail.ValidarMail(dv2(i).Item(10).ToString.Trim) Then
                    .BackColor = Drawing.Color.YellowGreen
                End If

                'Si es abonado pongo color azul
                If CInt(dv2(i).Item(9)) = 2 Then
                    .ForeColor = Drawing.Color.Blue
                End If

                If dv2(i).Item(8).ToString = "X0" Then
                    .ForeColor = Drawing.Color.Red

                Else
                    Perdido = False

                End If

            End With

        Next

        '----------------------------------------------------------------------------------------
        ' CODIGO PARA AGREGAR AL ARBOL CLIENTES NO CONSORCIOS
        '----------------------------------------------------------------------------------------
        dv2.RowFilter = "[tsccod_1] <> '11'"
        dv2.Sort = "[bpcnum_0]"
        bpc = ""
        fcy = ""

        For i As Integer = 0 To dv2.Count - 1

            If bpc <> dv2(i).Item(0).ToString Then
                If Perdido And bpc <> "" Then tNode.ForeColor = Drawing.Color.Red
                Perdido = True

                bpc = dv2(i).Item(0).ToString
                tNode = tree.Nodes.Add(bpc, bpc & " " & dv2(i).Item(1).ToString)

                'Si es abonado pongo color azul
                If CInt(dv2(i).Item(9)) = 2 Then 'EsAbonado(dv2(i).Item(0).ToString) Then
                    tNode.ForeColor = Drawing.Color.Blue
                End If

            End If

            With tNode.Nodes.Add(dv2(i).Item(0).ToString & "/" & dv2(i).Item(2).ToString, dv2(i).Item(2).ToString & " - " & dv2(i).Item(3).ToString)
                .Tag = dv2(i).Item(1).ToString

                '04/02/2019 MARTI MIÑO
                'Si sucursal default del tercerp pagador no tiene mail, marco en violeta
                If Not oMail.ValidarMail(dv2(i).Item(10).ToString.Trim) Then
                    .BackColor = Drawing.Color.YellowGreen
                End If

                'Si es abonado pongo color azul
                If CInt(dv2(i).Item(9)) = 2 Then
                    .ForeColor = Drawing.Color.Blue
                End If

                If dv2(i).Item(8).ToString = "X0" Then
                    .ForeColor = Drawing.Color.Red

                Else
                    Perdido = False

                End If

            End With

        Next

        btnBuscar.Enabled = True

        da1.Dispose() : da2.Dispose()
        dt1.Dispose() : dt2.Dispose()
        dv1.Dispose() : dv2.Dispose()

        If tree.Nodes.Count = 0 Then
            MessageBox.Show("No se encontraron vencimientos", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub
    Private Sub Vencimientos(ByVal Cliente As String, ByVal Sucursal As String)
        dtVencimientos.Clear()
        dtDetalle.Clear()

        lstTipos.SelectedValue = " "

        With da1.SelectCommand.Parameters
            .Add("desde", OracleType.VarChar).Value = dMin.ToString("dd/MM/yyyy") 'Fecha Desde
            .Add("hasta", OracleType.VarChar).Value = dMin.AddMonths(1).ToString("dd/MM/yyyy")  'Fecha Hasta 30 dias
            .Add("bpcnum_0", OracleType.VarChar).Value = Cliente 'Cliente
            .Add("fcyitn_0", OracleType.VarChar).Value = Sucursal 'Sucursal
        End With
        With da2.SelectCommand.Parameters
            .Add("desde", OracleType.VarChar).Value = dMin.ToString("dd/MM/yyyy") 'Fecha Desde
            .Add("hasta", OracleType.VarChar).Value = dMin.AddMonths(1).ToString("dd/MM/yyyy")  'Fecha Hasta 30 dias
            .Add("bpcnum_0", OracleType.VarChar).Value = Cliente 'Cliente
            .Add("fcyitn_0", OracleType.VarChar).Value = Sucursal 'Sucursal
        End With

        da1.Fill(dtVencimientos)
        da2.Fill(dtDetalle)

        If dgvResumen.DataSource Is Nothing Then
            colCodigo.DataPropertyName = "cpnitmref_0"
            colCantidad.DataPropertyName = "cant"

            With colDescripcion
                .DataPropertyName = "cpnitmref_0"
                .ValueMember = "itmref_0"
                .DisplayMember = "itmdes1_0"
                .DataSource = Articulo.Tabla(cn)
            End With

            colAgente.DataPropertyName = "tsicod_2"
            colKilos.DataPropertyName = "tsicod_1"

            dgvResumen.DataSource = dtVencimientos
        End If

        If dgvDetalle.DataSource Is Nothing Then
            Dim tb As TablaVaria

            colSeriec.DataPropertyName = "macnum_0"
            colCilindro.DataPropertyName = "ynrocil_0"
            colFabricacion.DataPropertyName = "yfabdat_0"
            tb = New TablaVaria(cn, 22, True)
            tb.EnlazarComboBox(colTipo)
            colTipo.DataPropertyName = "tsicod_2"
            tb = New TablaVaria(cn, 21, True)
            tb.EnlazarComboBox(colCapacidad)
            colCapacidad.DataPropertyName = "tsicod_1"
            colItn.DataPropertyName = "itn"
            colIngreso.DataPropertyName = "ingreso"
            dgvDetalle.DataSource = dtDetalle
        End If

        'Se busca el ultimo proceso de cada extintor
        UltimaIntervencion(dtDetalle)

        EstadoControles()

        AvisoParaCanje()
        Aviso639()

        txtComentario.Text = com.getComentario(dMin, txtCodigo.Text, txtSuc.Text)

    End Sub
    Private Sub FiltrarVencimientosPorTipo()
        Dim dr As DataRow

        dtVencimientos.RejectChanges()

        'Carga de servicios dependiendo del tipo de intervencion seleccionado
        Select Case lstTipos.SelectedValue.ToString
            Case "A1"
                For Each dr In dtVencimientos.Rows
                    If dr("cpnitmref_0").ToString.StartsWith("65") OrElse _
                        dr("cpnitmref_0").ToString.StartsWith("553") Then

                    Else
                        dr.Delete()
                    End If
                Next

            Case "B1"
                For Each dr In dtVencimientos.Rows
                    If dr("cpnitmref_0").ToString.StartsWith("45") OrElse _
                       dr("cpnitmref_0").ToString.StartsWith("50") OrElse _
                       dr("cpnitmref_0").ToString = "999004" Then

                    Else
                        dr.Delete()
                    End If
                Next

            Case "B2"
                For Each dr In dtVencimientos.Rows
                    If dr("tsicod_2").ToString = "201" AndAlso _
                       dr("tsicod_1").ToString = "108" Then

                    Else
                        dr.Delete()
                    End If
                Next

            Case "D1"
                For Each dr In dtVencimientos.Rows
                    If dr("cpnitmref_0").ToString.StartsWith("45") OrElse _
                       dr("cpnitmref_0").ToString.StartsWith("50") Then

                    Else
                        dr.Delete()
                    End If
                Next

            Case "C1"
                For Each dr In dtVencimientos.Rows
                    If dr("cpnitmref_0").ToString.StartsWith("45") OrElse dr("cpnitmref_0").ToString.StartsWith("50") OrElse dr("cpnitmref_0").ToString.StartsWith("65") Then

                    Else
                        dr.Delete()
                    End If
                Next

            Case "E1"
                'For Each dr In dtVencimientos.Rows
                '    If dr("cpnitmref_0").ToString.StartsWith("55") Then

                '    Else
                '        dr.Delete()
                '    End If
                'Next

                For Each dr In dtVencimientos.Rows
                    If dr("cpnitmref_0").ToString = "551015" OrElse _
                    dr("cpnitmref_0").ToString = "551068" OrElse _
                    dr("cpnitmref_0").ToString = "551003" OrElse _
                    dr("cpnitmref_0").ToString = "551004" OrElse _
                    dr("cpnitmref_0").ToString = "551077" OrElse _
                    dr("cpnitmref_0").ToString = "551060" OrElse _
                    dr("cpnitmref_0").ToString = "551054" OrElse _
                    dr("cpnitmref_0").ToString = "551055" OrElse _
                    dr("cpnitmref_0").ToString = "551056" OrElse _
                    dr("cpnitmref_0").ToString = "551057" OrElse _
                    dr("cpnitmref_0").ToString = "551058" OrElse _
                    dr("cpnitmref_0").ToString = "551062" OrElse _
                    dr("cpnitmref_0").ToString = "551063" OrElse _
                    dr("cpnitmref_0").ToString = "551064" OrElse _
                    dr("cpnitmref_0").ToString = "551072" OrElse _
                    dr("cpnitmref_0").ToString = "551073" OrElse _
                    dr("cpnitmref_0").ToString = "551074" OrElse _
                    dr("cpnitmref_0").ToString = "551070" OrElse _
                    dr("cpnitmref_0").ToString = "551071" OrElse _
                    dr("cpnitmref_0").ToString = "551078" OrElse _
                    dr("cpnitmref_0").ToString = "551079" OrElse _
                    dr("cpnitmref_0").ToString = "551080" OrElse _
                    dr("cpnitmref_0").ToString = "659012" Then

                    Else
                        dr.Delete()

                    End If
                Next

            Case "E2"
                'Agrego a la tabla todos los artículos que son de ctrl periodicos

                For Each dr In dtVencimientos.Rows
                    If dr("cpnitmref_0").ToString = "551000" OrElse _
                        dr("cpnitmref_0").ToString = "551022" OrElse _
                        dr("cpnitmref_0").ToString = "551035" OrElse _
                        dr("cpnitmref_0").ToString = "551032" OrElse _
                        dr("cpnitmref_0").ToString = "551002" OrElse _
                        dr("cpnitmref_0").ToString = "551037" OrElse _
                        dr("cpnitmref_0").ToString = "551001" OrElse _
                        dr("cpnitmref_0").ToString = "551036" OrElse _
                        dr("cpnitmref_0").ToString = "501019" OrElse _
                        dr("cpnitmref_0").ToString = "551075" OrElse _
                        dr("cpnitmref_0").ToString = "551059" OrElse _
                        dr("cpnitmref_0").ToString = "551061" OrElse _
                        dr("cpnitmref_0").ToString = "551076" OrElse _
                        dr("cpnitmref_0").ToString = "551065" OrElse _
                        dr("cpnitmref_0").ToString = "551034" OrElse _
                        dr("cpnitmref_0").ToString = "551067" OrElse _
                        dr("cpnitmref_0").ToString = "551066" OrElse _
                        dr("cpnitmref_0").ToString = "551021" OrElse _
                        dr("cpnitmref_0").ToString = "659012" Then

                    Else
                        dr.Delete()

                    End If
                Next

            Case "F1"

                'Agrego a la tabla todos los artículos que son de ctrl periodicos
                For Each dr In dtVencimientos.Rows
                    If dr("cpnitmref_0").ToString.StartsWith("55301") OrElse _
                       dr("cpnitmref_0").ToString.StartsWith("504") OrElse _
                       dr("cpnitmref_0").ToString.StartsWith("505") Then

                    Else
                        dr.Delete()

                    End If
                Next

            Case Else
                For Each dr In dtVencimientos.Rows
                    dr.Delete()
                Next

        End Select

    End Sub

    Private Function ReagendarParque(ByVal CantidadMeses As Integer, ByVal Art As String) As Boolean
        Dim Sql As String
        Dim da As OracleDataAdapter
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim oParque As New Parque(cn)

        'Consulta que recupera los parques que vencen dentro del mes que contiene el parametro FECHA
        Sql = "SELECT ymc.* "
        Sql &= "FROM (((machines mac INNER JOIN ymacitm ymc ON (mac.macnum_0 = ymc.macnum_0)) INNER JOIN bomd bmd ON (macpdtcod_0 = itmref_0 AND ymc.cpnitmref_0 = bmd.cpnitmref_0)) INNER JOIN bpcustomer bpc ON (mac.bpcnum_0 = bpc.bpcnum_0)) INNER JOIN itmmaster itm ON (ymc.cpnitmref_0 = itm.itmref_0) "
        Sql &= "WHERE bomalt_0 = 99 AND "
        Sql &= "      bomseq_0 = 10 AND "
        Sql &= "      macitntyp_0 = 1 AND "
        Sql &= "      datnext_0 >= to_date(:datnext_0, 'dd/mm/yyyy') AND "
        Sql &= "      datnext_0 < to_date(:datnext_1, 'dd/mm/yyyy') AND "
        Sql &= "      mac.bpcnum_0 = :bpcnum_0 AND "
        Sql &= "      mac.fcyitn_0 = :fcyitn_0 AND "
        Sql &= "      mac.xitn_0 = ' ' AND "
        Sql &= "      cpnitmref_0 = :cpnitmref_0"

        da = New OracleDataAdapter(Sql, cn)
        With da.SelectCommand.Parameters
            .Add("datnext_0", OracleType.VarChar) 'Fecha Desde
            .Add("datnext_1", OracleType.VarChar) 'Fecha Hasta 30 dias
            .Add("bpcnum_0", OracleType.VarChar)  'Cliente
            .Add("fcyitn_0", OracleType.VarChar)  'Sucursal
            .Add("cpnitmref_0", OracleType.VarChar) 'Componente
        End With

        'Recorro todos los equipos que están en la pantalla en la seccion RETIRO
        For Each dr In dtVencimientos.Rows

            If dr.RowState = DataRowState.Deleted Then Continue For

            If dr("cpnitmref_0").ToString.StartsWith(Art) Or (dr("cpnitmref_0").ToString.StartsWith("50") And Art = "45") Then
                With da.SelectCommand
                    .Parameters("datnext_0").Value = dMin.ToShortDateString
                    .Parameters("datnext_1").Value = dMin.AddMonths(1).ToShortDateString
                    .Parameters("bpcnum_0").Value = txtCodigo.Text
                    .Parameters("fcyitn_0").Value = txtSuc.Text
                    .Parameters("cpnitmref_0").Value = dr("cpnitmref_0").ToString
                End With

                da.Fill(dt)

            End If
        Next

        'Cambio la fecha de vencimiento
        For Each dr In dt.Rows
            oParque.Abrir(dr("macnum_0").ToString)
            oParque.VtoCarga = dMin.AddMonths(CantidadMeses)
            oParque.Grabar()
        Next

        Return (dt.Rows.Count > 0)

        da.Dispose()
        dt.Dispose()

    End Function
    Private Sub tree_NodeMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles tree.NodeMouseClick
        Dim txt As String = ""

        'Salgo si el usuario hizo clic derecho
        If e.Button <> Windows.Forms.MouseButtons.Left Then Exit Sub

        'Muestro los vencimientos del parque del cliente seleccionado
        If e.Node.Level = 1 Then
            Dim Cli As String() = Split(e.Node.Name.ToString, "/")

            'Salgo si el usuario volvio a seleccionar el nodo activo
            If Cli(0) = txtCodigo.Text And Cli(1) = txtSuc.Text Then Exit Sub

            txtCodigo.Text = Cli(0) : txtCliente.Text = e.Node.Tag.ToString
            txtSuc.Text = Cli(1) : txtDireccion.Text = e.Node.Text

            Me.Cursor = Cursors.WaitCursor

            bpc = New Cliente(cn)
            bpc.Abrir(Cli(0))
            bpa = New Sucursal(cn, txtCodigo.Text, txtSuc.Text)

            'Tercero Pagador
            bpc2 = bpc.TerceroPagador
            'Muestro vendedor
            lblRep.Text = bpc2.Vendedor1Codigo

            If bpc.Codigo = bpc2.Codigo Then
                bpa2 = bpa
            Else
                bpa2 = bpc2.SucursalDefault
            End If



            txtTelefono.Text = bpa2.Telefono

            'Recupero los vencimiento que tiene el cliente
            Vencimientos(Cli(0), Cli(1))

            Me.Cursor = Cursors.Default

            'Si el nodo es de color azul, significa que el cliente tiene tilde de abono
            'consulto si tiene contrato de servicio activo y muestro advertencia
            If e.Node.ForeColor = Drawing.Color.Blue Then
                If Not bpc.ContratoActivo(dMin) Then
                    MessageBox.Show("Este cliente no tiene un Contrato de Servicio activo", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)

                Else
                    'Miro si el contrato vence dentro de los proximos 30 dias
                    Dim FinContrato As Date
                    Dim DiasFaltantes As Long

                    FinContrato = bpc.ContratoValidez

                    If IsNothing(FinContrato) = False Then

                        DiasFaltantes = DateDiff(DateInterval.Day, Today, FinContrato)

                        If DiasFaltantes <= 31 Then
                            txt = "El contrato de este cliente vence dentro de {dias} dia(s)" & vbCrLf & vbCrLf
                            txt &= "Fecha de vencimiento: {fecha}"

                            txt = txt.Replace("{dias}", DiasFaltantes.ToString)
                            txt = txt.Replace("{fecha}", FinContrato.ToString("dd/MM/yyyy"))

                            MessageBox.Show(txt, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If

                    End If

                End If

            End If


            'Valido si el usuario está ACTIVO/RECHAZADO
            If bpc.Activo = False Then

                txt = "No se puede generar una intervención. Cliente DESACTIVADO." & vbCrLf & vbCrLf
                'txt &= bpc.Observaciones
                'MessageBox.Show(txt, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                txt &= "Quiere pasarlo a PERDIDO?" & vbCrLf & vbCrLf
                txt &= bpc.Observaciones

                Dim result As Integer = MessageBox.Show(txt, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Stop)
                If result = DialogResult.Yes Then
                    Perder(bpc.Codigo)
                ElseIf result = DialogResult.No Then

                End If

            ElseIf bpc.Bloqueado = True Then

                txt = "No se puede generar una intervención. Cliente BLOQUEADO." & vbCrLf & vbCrLf
                txt &= "Quiere pasarlo a PERDIDO?" & vbCrLf & vbCrLf
                txt &= bpc.Observaciones

                Dim result As Integer = MessageBox.Show(txt, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Stop)
                If result = DialogResult.Yes Then
                    Perder(bpc.Codigo)
                ElseIf result = DialogResult.No Then

                End If
            End If
        Else
            txtCodigo.Clear()
            txtCliente.Clear()
            txtSuc.Clear()
            txtDireccion.Clear()
            lblRep.Text = ""
        End If

    End Sub
    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Me.Cursor = Cursors.WaitCursor
        Application.DoEvents()

        'Armado de fecha de consulta
        dtp.Value = dtp.Value.AddDays(1 - dtp.Value.Day)
        dMin = dtp.Value

        CargarArbol()

        Me.Cursor = Cursors.Default

    End Sub
    Public Sub Buscar(ByVal dp As DateTimePicker)
        Me.Cursor = Cursors.WaitCursor
        Application.DoEvents()

        'Armado de fecha de consulta
        dtp.Value = dp.Value.AddDays(1 - dp.Value.Day)
        dMin = dp.Value

        CargarArbol()

        Me.Cursor = Cursors.Default
    End Sub
    Private Sub Perder(ByVal codigo As String)

        Dim dt As New DataTable
        Dim Sql As String
        Dim cm As OracleCommand

        Sql = "UPDATE machines SET xitn_0 = 'X0' WHERE bpcnum_0 = :bpcnum_0"
        cm = New OracleCommand(Sql, cn)
        cm.Parameters.Add("bpcnum_0", OracleType.VarChar).Value = codigo 'Cliente

        Dim i As Integer = cm.ExecuteNonQuery()

        Try

            MessageBox.Show("Cantidad de parques marcados: " & i.ToString, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            If i > 0 AndAlso tree.SelectedNode IsNot Nothing Then
                tree.SelectedNode.ForeColor = Drawing.Color.Red
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

        End Try
    End Sub
    Private Sub btnReagendar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReagendar.Click

        Dim Meses As Integer = 0
        Dim Articulo As String = ""
        Dim txt As String = ""
        Dim Fecha As Date = dMin

        Select Case lstTipos.SelectedValue.ToString.Trim
            Case ""
                MessageBox.Show("Falta seleccionar tipo de intervención", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub

            Case "A1"
                txt = InputBox("Ingrese la cantidad de meses que desea correr los vencimientos", Me.Text, "")
                If txt = "" Then Exit Sub

                If IsNumeric(txt) Then
                    Meses = CInt(txt)

                    If Meses > 0 And Meses <= 4 Then

                        Articulo = "65"

                        txt = "Se reagendarán los vencimientos de CTRL. PERIODICOS para el mes {1} del año {2}{0}{0}¿Confirma la operación?"

                    Else
                        Meses = 0
                        MessageBox.Show("Solo se puede reagendar entre 1 y 4 meses", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                    End If

                Else
                    MessageBox.Show("El valor ingresado no es válido", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                End If

            Case "B1"
                Meses = 11
                Articulo = "45"

                txt = "Se reagendarán los vencimientos de RECARGAS para el mes {1} del año {2}{0}{0}¿Confirma la operación?"

            Case "E1", "E2"
                txt = InputBox("Ingrese la cantidad de meses que desea correr los vencimientos", Me.Text, "")
                If txt = "" Then Exit Sub

                If IsNumeric(txt) Then
                    Meses = CInt(txt)

                    If Meses > 0 And Meses <= 6 Then

                        Articulo = "551"

                        txt = "Se reagendarán los vencimientos de SISTEMAS FIJOS para el mes {1} del año {2}{0}{0}¿Confirma la operación?"

                    Else
                        Meses = 0
                        MessageBox.Show("Solo se puede reagendar entre 1 y 6 meses", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                    End If

                Else
                    MessageBox.Show("El valor ingresado no es válido", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                End If

            Case "F1"
                txt = InputBox("Ingrese la cantidad de meses que desea correr los vencimientos", Me.Text, "")
                If txt = "" Then Exit Sub

                If IsNumeric(txt) Then
                    Meses = CInt(txt)

                    If Meses > 0 And Meses <= 12 Then

                        Articulo = "553"

                        txt = "Se reagendarán los vencimientos de SISTEMAS FIJOS para el mes {1} del año {2}{0}{0}¿Confirma la operación?"

                    Else
                        Meses = 0
                        MessageBox.Show("Solo se puede reagendar entre 1 y 12 meses", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                    End If

                Else
                    MessageBox.Show("El valor ingresado no es válido", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                End If

            Case Else
                MessageBox.Show("No se puede reagendar vencimientos de tipo " & lstTipos.SelectedValue.ToString, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)

        End Select

        If Meses > 0 Then
            Fecha = Fecha.AddDays(Fecha.Day - 1)
            Fecha = Fecha.AddMonths(Meses)
            txt = String.Format(txt, vbCrLf, Fecha.Month.ToString, Fecha.Year.ToString)

            If MessageBox.Show(txt, Me.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then

                If ReagendarParque(Meses, Articulo) Then
                    Vencimientos(txtCodigo.Text, txtSuc.Text)
                    MessageBox.Show("Los vencimientos fueron reagendados", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

                Else
                    MessageBox.Show("No hay vencimientos para reagendar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

                End If

            End If

        End If

    End Sub
    Private Sub btnPerdido_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPerdido.Click
        Dim da As OracleDataAdapter
        Dim dt As New DataTable
        Dim Sql As String
        Dim dr As DataRow
        Dim txt As String = ""
        Dim Art1 As String = ""
        Dim Art2 As String = ""
        Dim Art3 As String = ""

        Select Case lstTipos.SelectedValue.ToString
            Case "A1"
                txt = "Se marcará el parque de CONTROLES PERIÓDICOS de este cliente como perdido{0}{0}{1}{0}{2}{0}{0}¿Confirma la operación?"
                Art1 = "65%"
                Art2 = "..."
                Art3 = "..."

            Case "B1"
                txt = "Se marcará el parque de RECARGAS de este cliente como perdido{0}{0}{1}{0}{2}{0}{0}¿Confirma la operación?"
                Art1 = "45%"
                Art2 = "50%"
                Art3 = "65%"

            Case "E1"
                txt = "Se marcará el parque de SISTEMAS FIJOS - COCINAS de este cliente como perdido{0}{0}{1}{0}{2}{0}{0}¿Confirma la operación?"
                Art1 = "551015"
                Art2 = "659012"
                Art3 = "..."

            Case "E2"
                txt = "Se marcará el parque de SISTEMAS FIJOS - DETECCION de este cliente como perdido{0}{0}{1}{0}{2}{0}{0}¿Confirma la operación?"
                Art1 = "551000"
                Art2 = "551022"
                Art3 = "659012"

            Case Else
                txt = "Acción no válida para intervenciones tipo " & lstTipos.SelectedValue.ToString
                If MessageBox.Show(txt, Me.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Cancel Then Exit Sub
                Exit Sub

        End Select

        'Pido confirmación
        txt = String.Format(txt, vbCrLf, txtCliente.Text, txtDireccion.Text)
        If MessageBox.Show(txt, Me.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Cancel Then Exit Sub


        Sql = "SELECT mac.* "
        Sql &= "FROM (((machines mac INNER JOIN ymacitm ymc ON (mac.macnum_0 = ymc.macnum_0)) INNER JOIN bomd bmd ON (macpdtcod_0 = itmref_0 AND ymc.cpnitmref_0 = bmd.cpnitmref_0)) INNER JOIN bpcustomer bpc ON (mac.bpcnum_0 = bpc.bpcnum_0)) INNER JOIN itmmaster itm ON (ymc.cpnitmref_0 = itm.itmref_0) "
        Sql &= "WHERE bomalt_0 = 99 AND "
        Sql &= "      bomseq_0 = 10 AND "
        Sql &= "      macitntyp_0 = 1 AND "
        Sql &= "      mac.bpcnum_0 = :bpcnum_0 AND "
        Sql &= "      mac.fcyitn_0 = :fcyitn_0 AND "
        Sql &= "      (ymc.cpnitmref_0 LIKE :cpnitmref_0 OR ymc.cpnitmref_0 LIKE :cpnitmref_1 OR ymc.cpnitmref_0 LIKE :cpnitmref_2) AND "
        Sql &= "      mac.xitn_0 = ' '"
        da = New OracleDataAdapter(Sql, cn)

        Sql = "UPDATE machines SET xitn_0 = :xitn_0 WHERE macnum_0 = :macnum_0"
        da.UpdateCommand = New OracleCommand(Sql, cn)

        With da
            .SelectCommand.Parameters.Add("bpcnum_0", OracleType.VarChar).Value = txtCodigo.Text 'Cliente
            .SelectCommand.Parameters.Add("fcyitn_0", OracleType.VarChar).Value = txtSuc.Text 'Sucursal
            .SelectCommand.Parameters.Add("cpnitmref_0", OracleType.VarChar).Value = Art1
            .SelectCommand.Parameters.Add("cpnitmref_1", OracleType.VarChar).Value = Art2
            .SelectCommand.Parameters.Add("cpnitmref_2", OracleType.VarChar).Value = Art3

            Parametro(.UpdateCommand, "xitn_0", OracleType.VarChar, DataRowVersion.Current)
            Parametro(.UpdateCommand, "macnum_0", OracleType.VarChar, DataRowVersion.Original)
        End With

        da.Fill(dt)

        Dim i As Integer = dt.Rows.Count

        For Each dr In dt.Rows
            dr.BeginEdit()
            dr("xitn_0") = "X0"
            dr.EndEdit()
        Next

        Try
            da.Update(dt)

            MessageBox.Show("Cantidad de parques marcados: " & i.ToString, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            If i > 0 AndAlso tree.SelectedNode IsNot Nothing Then
                tree.SelectedNode.ForeColor = Drawing.Color.Red
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            da.Dispose()
            dt.Dispose()

        End Try

    End Sub
    Private Sub btnRecuperar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecuperar.Click
        Dim da As OracleDataAdapter
        Dim dt As New DataTable
        Dim Sql As String
        Dim dr As DataRow
        Dim txt As String = ""
        Dim Art1 As String = ""
        Dim Art2 As String = "---"
        Dim Art3 As String = "---"

        Select Case lstTipos.SelectedValue.ToString
            Case "A1"
                txt = "Se recuperará el parque de CONTROLES PERIÓDICOS de este cliente{0}{0}{1}{0}{2}{0}{0}¿Confirma la operación?"
                Art1 = "65%"

            Case "B1"
                txt = "Se recuperará el parque de RECARGAS de este cliente{0}{0}{1}{0}{2}{0}{0}¿Confirma la operación?"
                Art1 = "45%"

            Case "E1"
                txt = "Se recuperará el parque de SISTEMAS FIJOS - COCINAS de este cliente{0}{0}{1}{0}{2}{0}{0}¿Confirma la operación?"
                Art1 = "551015"
                Art2 = "659012"
                Art3 = "..."

            Case "E2"
                txt = "Se recuperará el parque de SISTEMAS FIJOS - DETECCION de este cliente{0}{0}{1}{0}{2}{0}{0}¿Confirma la operación?"
                Art1 = "551000"
                Art2 = "551022"
                Art3 = "659012"

            Case Else
                txt = "Acción no válida para intervenciones tipo " & lstTipos.SelectedValue.ToString
                Art1 = ""
                MessageBox.Show(txt, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub

        End Select

        'Pido confirmación
        txt = String.Format(txt, vbCrLf, txtCliente.Text, txtDireccion.Text)
        If MessageBox.Show(txt, Me.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Cancel Then Exit Sub


        Sql = "SELECT mac.* "
        Sql &= "FROM (((machines mac INNER JOIN ymacitm ymc ON (mac.macnum_0 = ymc.macnum_0)) INNER JOIN bomd bmd ON (macpdtcod_0 = itmref_0 AND ymc.cpnitmref_0 = bmd.cpnitmref_0)) INNER JOIN bpcustomer bpc ON (mac.bpcnum_0 = bpc.bpcnum_0)) INNER JOIN itmmaster itm ON (ymc.cpnitmref_0 = itm.itmref_0) "
        Sql &= "WHERE bomalt_0 = 99 AND "
        Sql &= "      bomseq_0 = 10 AND "
        Sql &= "      macitntyp_0 = 1 AND "
        Sql &= "      mac.bpcnum_0 = :bpcnum_0 AND "
        Sql &= "      mac.fcyitn_0 = :fcyitn_0 AND "
        Sql &= "      (ymc.cpnitmref_0 LIKE :cpnitmref_0 OR ymc.cpnitmref_0 LIKE :cpnitmref_1 OR ymc.cpnitmref_0 LIKE :cpnitmref_2) AND "
        Sql &= "      mac.xitn_0 = 'X0'"
        da = New OracleDataAdapter(Sql, cn)

        Sql = "UPDATE machines SET xitn_0 = :xitn_0 WHERE macnum_0 = :macnum_0"
        da.UpdateCommand = New OracleCommand(Sql, cn)

        With da
            .SelectCommand.Parameters.Add("bpcnum_0", OracleType.VarChar).Value = txtCodigo.Text 'Cliente
            .SelectCommand.Parameters.Add("fcyitn_0", OracleType.VarChar).Value = txtSuc.Text 'Sucursal
            .SelectCommand.Parameters.Add("cpnitmref_0", OracleType.VarChar).Value = Art1
            .SelectCommand.Parameters.Add("cpnitmref_1", OracleType.VarChar).Value = Art2
            .SelectCommand.Parameters.Add("cpnitmref_2", OracleType.VarChar).Value = Art3

            Parametro(.UpdateCommand, "xitn_0", OracleType.VarChar, DataRowVersion.Current)
            Parametro(.UpdateCommand, "macnum_0", OracleType.VarChar, DataRowVersion.Original)
        End With

        da.Fill(dt)

        Dim i As Integer = dt.Rows.Count

        For Each dr In dt.Rows
            dr.BeginEdit()
            dr("xitn_0") = " "
            dr.EndEdit()
        Next

        Try
            da.Update(dt)

            MessageBox.Show("Cantidad de parques recuperados: " & i.ToString, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            If i > 0 AndAlso tree.SelectedNode IsNot Nothing Then
                tree.SelectedNode.ForeColor = Drawing.Color.Black
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            da.Dispose()
            dt.Dispose()

        End Try
    End Sub
    Private Sub cmArbol_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmArbol.Opening

        With tree
            If .SelectedNode Is Nothing OrElse .SelectedNode.Level <> 1 Then
                e.Cancel = True
            End If
        End With

    End Sub
    Private Sub mnuDistribucion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDistribucion.Click
        rptDistribucionVencimientos(txtCodigo.Text, txtSuc.Text)
    End Sub
    Private Sub lstTipos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstTipos.SelectedIndexChanged
        FiltrarVencimientosPorTipo()
    End Sub
    Private Sub UltimaIntervencion(ByVal dt As DataTable)
        Dim dr As DataRow
        Dim dt2 As New DataTable

        For Each dr In dt.Rows
            da3.SelectCommand.Parameters("macnum").Value = dr("macnum_0").ToString
            dt2.Clear()
            da3.Fill(dt2)

            dr.BeginEdit()
            If dt2.Rows.Count > 0 Then
                dr("itn") = dt2.Rows(0).Item("yitnnum_0").ToString
                dr("ingreso") = CDate(dt2.Rows(0).Item("credat_0"))
            Else
                dr("itn") = DBNull.Value
                dr("ingreso") = DBNull.Value
            End If
            dr.EndEdit()

            If CDate(dr("yfabdat_0")) = #12/31/1599# Then
                dr.BeginEdit()
                dr("yfabdat_0") = DBNull.Value
                dr.EndEdit()
            End If

        Next
    End Sub
    Private Sub btnCrearIntervención_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCrearIntervención.Click
        If lstTipos.SelectedValue.ToString = " " Then
            MessageBox.Show("Debe seleccionar un tipo de intervención", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        '---
        Dim i As Integer = 0
        For Each dr As DataRow In dtVencimientos.Rows
            If dr.RowState = DataRowState.Deleted Then Continue For
            i += 1
        Next
        If i = 0 Then
            MessageBox.Show("No hay vencimientos", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        '---

        'No se puede usar B2 para cliente NO APTO para canje
        If (lstTipos.SelectedValue.ToString = "B2" AndAlso lblCanje.Visible = False) AndAlso usr.Codigo <> "MMIN" Then
            MessageBox.Show("Cliente no apto para canje. Intervención B2 no permitida.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        CrearIntervencion()

    End Sub
    Private Sub CrearIntervencion()
        Dim f As New frmIntervencion

        btnCrearIntervención.Enabled = False
        Application.DoEvents()

        f.NuevaIntervencion()
        f.DesdeVencimiento = True

        'Datos clientes
        f.txtCodigoCliente.Text = txtCodigo.Text
        f.txtCodigoCliente.ReadOnly = True
        f.SetCliente()
        'Datos Sucursal
        f.txtSucursal.Text = txtSuc.Text
        f.txtSucursal.ReadOnly = True
        f.SetSucursal()
        'Tipo intervencion
        f.cboTipo.SelectedValue = lstTipos.SelectedValue.ToString
        f.cboTipo.Enabled = False
        'Detalle de retiros

        If lstTipos.SelectedValue.ToString = "B2" Then
            Dim CantidadCanjes As Integer = 0

            For Each dr As DataRow In dtVencimientos.Rows
                If dr.RowState = DataRowState.Deleted Then Continue For
                CantidadCanjes += CInt(dr("cant"))
            Next

            f.AgregarRetiro("451199", CantidadCanjes, 1)
            f.dgvRetiros.AllowUserToDeleteRows = False
            f.dgvRetiros.AllowUserToAddRows = False

        Else
            For Each dr As DataRow In dtVencimientos.Rows
                If dr.RowState = DataRowState.Deleted Then Continue For

                f.AgregarRetiro(dr("cpnitmref_0").ToString, CInt(dr("cant")), 1)
            Next
            f.AgregarSustitutos()
        End If


        'Pongo fecha minima si el mes no es el actual
        If dtp.Value.Month <> Date.Today.Month AndAlso lstTipos.SelectedValue.ToString <> "F1" Then
            Dim x As Date = New Date(dtp.Value.Year, dtp.Value.Month, 1)
            Dim Fer As New Feriados(cn)
            x = Fer.ObtenerSiguienteDiaHabil(x)
            f.dtpTarea.MinDate = x
        End If

        f.ShowDialog(Me)

        If f.DialogResult = Windows.Forms.DialogResult.OK Then
            If f.itn.Tipo = "B2" Then
                Dim Articulos As New ArrayList

                For Each dr As DataRow In dtVencimientos.Rows
                    If dr.RowState = DataRowState.Deleted Then Continue For
                    Articulos.Add(dr("cpnitmref_0").ToString)
                Next

                f.itn.MarcarEquipos(Articulos, dMin)

            Else
                f.itn.MarcarEquipos(dMin)
            End If


            MessageBox.Show("Se creo la intervención " & f.itn.Numero, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            Application.DoEvents()
            Vencimientos(txtCodigo.Text, txtSuc.Text)
        End If

        btnCrearIntervención.Enabled = True
        Application.DoEvents()
    End Sub
    Private Sub EstadoControles()
        Panel1.Enabled = dtVencimientos.Rows.Count > 0
        gbComentarios.Enabled = txtCodigo.Text.Trim.Length > 0
    End Sub
    Private Sub btnPresupuesto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPresupuesto.Click
        Dim f As New frmCotizadorV2
        Dim itm As New Articulo(cn)
        Dim Qty As Double = 0

        With f
            .Show(Me)
            .Nuevo(2)
            .SetCliente(txtCodigo.Text)
            .SetSucursal(txtSuc.Text)

            For Each dr As DataRow In dtVencimientos.Rows
                If dr.RowState = DataRowState.Deleted Then Continue For
                itm.Abrir(dr("cpnitmref_0").ToString)

                Qty = CDbl(dr("cant"))

                f.ctz.AgregarLinea(itm.Codigo, Qty)

                Select Case itm.Familia(4)
                    Case "521" ' Servicio Extintores
                        If itm.LlevaIram Then
                            f.ctz.AgregarLinea("705014", Qty) 'ESTAMPILLA IRAM SERVICE
                        End If
                        If itm.LlevaTarjeta Then
                            Select Case bpa.Provincia
                                Case "CFE"
                                    f.ctz.AgregarLinea("705031", Qty) 'TARJETA MUNIC DE CONTROL FICT    
                                Case "BUE"
                                    f.ctz.AgregarLinea("705017", Qty) 'TARJETA PROVINCIAL OPDS
                            End Select
                        End If
                        f.ctz.AgregarLinea("461016", Qty) 'MARBETES(VARIOS)
                        f.ctz.AgregarLinea(ARTICULO_PRESTAMO_EXT, Qty) 'PRESTAMO EXTINTOR

                    Case "522" 'Servicio Mangueras
                        f.ctz.AgregarLinea(ARTICULO_PRESTAMO_MAN, Qty) 'PRESTAMO MANGUERA

                    Case "524" 'Controles Periodicos
                        f.ctz.AgregarLinea("705035", Qty) 'ESTAMPILLA IRAM CTROL PERIOD.

                End Select

            Next

            f.Flete()

            f.dgv.Sort(f.dgv.Columns("colCodigo"), System.ComponentModel.ListSortDirection.Ascending)

        End With

    End Sub
    Private Sub AvisoParaCanje()
        Dim Sql As String
        Dim da As OracleDataAdapter
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim i As Integer = 0

        lblCanje.Visible = False

        If bpa.Provincia <> "CFE" Then Exit Sub
        If bpc.Familia2 = "10" Or bpc.Familia2 = "11" Or bpc.Familia2 = "20" Then Exit Sub
        If bpc.EsAbonado Then Exit Sub

        Sql = "select mac.macnum_0, macdes_0, yfabdat_0, datnext_0, tsicod_1, tsicod_2, tsicod_3 "
        Sql &= "from machines mac inner join "
        Sql &= "     ymacitm ymc on (mac.macnum_0 = ymc.macnum_0) inner join "
        Sql &= "     bomd bmd on (mac.macpdtcod_0 = bmd.itmref_0 and ymc.cpnitmref_0 = bmd.cpnitmref_0 and bomalt_0 = '99' and bomseq_0 = '10') inner join "
        Sql &= "     itmmaster itm on (mac.macpdtcod_0 = itm.itmref_0) inner join "
        Sql &= "     bpcustomer bpc on (mac.bpcnum_0 = bpc.bpcnum_0) "
        Sql &= "where mac.bpcnum_0 = :p1 and fcyitn_0 = :p2 and "
        Sql &= "      tsicod_3 = '301' and "
        Sql &= "	  datnext_0 >= :p3 and "
        Sql &= "	  bpc.pte_0 between '001' and '023' "

        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("p1", OracleType.VarChar).Value = bpc.Codigo
        da.SelectCommand.Parameters.Add("p2", OracleType.VarChar).Value = bpa.Sucursal
        da.SelectCommand.Parameters.Add("p3", OracleType.DateTime).Value = dMin.ToString("dd/MM/yyyy")
        da.Fill(dt)

        For Each dr In dt.Rows
            'Si no es extintor se pasa al siguiente registro
            'If dr("tsicod_3").ToString <> "301" Then Continue For
            'Salgo si no es polvo
            If dr("tsicod_2").ToString <> "201" Then Exit Sub
            'Salgo si no es 5kg
            If dr("tsicod_1").ToString <> "108" Then Exit Sub
            'Tiene mas de 9 año
            Dim f As New Date(Today.Year - 9, 1, 1)
            If CDate(dr("yfabdat_0")) <= f Then Exit Sub

            i += 1
        Next

        lblCanje.Visible = i > 0 And i <= 5

    End Sub
    Private Sub Aviso639()
        lbl639.Visible = False

        'Cliente debe ser de CABA
        If bpa.Provincia <> "CFE" Then Exit Sub
        'Tipo cliente debe ser 10, 11, 40, 50, 60, 70
        If "10 11 40 50 60 70".IndexOf(bpc.Familia2) = -1 Then Exit Sub
        'Debe tener más de 10 recargas
        If Not TieneCantidadRecargas(10) Then Exit Sub
        'No debe tener presupuesto 639 en los ultimos 3 meses
        If TienePresupuesto639() Then Exit Sub
        'No debe tener parque 639 
        If TieneParque639() Then Exit Sub

        lbl639.Visible = True

    End Sub
    Private Function TienePresupuesto639() As Boolean
        Dim Sql As String
        Dim da As OracleDataAdapter
        Dim dt As New DataTable
        Dim flg As Boolean = False

        Sql = "select * "
        Sql &= "from squote "
        Sql &= "where x415_0 = 2 and "
        Sql &= "	  bpcord_0 = :bpc and "
        Sql &= "	  bpaadd_0 = :bpa and "
        Sql &= "	  quodat_0 >= :dat"
        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("bpc", OracleType.VarChar).Value = bpc.Codigo
        da.SelectCommand.Parameters.Add("bpa", OracleType.VarChar).Value = bpa.Sucursal
        da.SelectCommand.Parameters.Add("dat", OracleType.DateTime).Value = Today.AddMonths(-3)

        Try
            dt = New DataTable
            da.Fill(dt)
            flg = dt.Rows.Count > 0

        Catch ex As Exception
        Finally
            da.Dispose()
            dt.Dispose()
        End Try

        Return flg

    End Function
    Private Function TieneParque639() As Boolean
        Dim da As OracleDataAdapter
        Dim dt As New DataTable
        Dim sql As String
        Dim f As Date = Date.Today
        Dim flg As Boolean = False

        f = New Date(f.Year, f.Month, 1)
        f = f.AddMonths(-2)

        sql = "select ymc.* "
        sql &= "from machines mac inner join "
        sql &= "	 ymacitm ymc on (mac.macnum_0 = ymc.macnum_0) "
        sql &= "where mac.bpcnum_0 = :bpcnum and "
        sql &= "	  fcyitn_0 = :fcyitn and "
        sql &= "	  ymc.cpnitmref_0 in ('553010', '553015', '553016', '553017') and "
        sql &= "	  datnext_0 >= :dat"
        da = New OracleDataAdapter(sql, cn)
        da.SelectCommand.Parameters.Add("bpcnum", OracleType.VarChar).Value = bpc.Codigo
        da.SelectCommand.Parameters.Add("fcyitn", OracleType.VarChar).Value = bpa.Sucursal
        da.SelectCommand.Parameters.Add("dat", OracleType.DateTime).Value = f

        Try
            da.Fill(dt)

            flg = dt.Rows.Count > 0

        Catch ex As Exception
            flg = False
        End Try

        Return flg

    End Function
    Private Function TieneCantidadRecargas(ByVal Cantidad As Integer) As Boolean
        Dim i As Integer = 0

        For Each dr As DataRow In dtVencimientos.Rows
            If dr("cpnitmref_0").ToString.StartsWith("45") Then
                i += CInt(dr("cant"))
            End If
        Next

        Return i > Cantidad

    End Function

    Private Sub txtComentario_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtComentario.TextChanged
        btnRegistrarComentario.Enabled = True
    End Sub
    Private Sub btnRegistrarComentario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegistrarComentario.Click
        btnRegistrarComentario.Enabled = False
        com.setComentario(dMin, txtCodigo.Text, txtSuc.Text, txtComentario.Text)
    End Sub

End Class