Imports System.Data.OracleClient

Public Class frmEquiposEnPlanta

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim i As Integer = 0

        Button1.Enabled = False
        Me.UseWaitCursor = True

        txtbox1.Text = Calculo1(" ").ToString
        i += CInt(txtbox1.Text)
        Application.DoEvents()

        txtbox2.Text = Calculo1("SRV").ToString
        i += CInt(txtbox2.Text)
        Application.DoEvents()

        'txtbox3.Text = Calculo2("ADM").ToString
        'i += CInt(txtbox3.Text)
        'Application.DoEvents()

        'txtbox4.Text = Calculo2("VEN").ToString
        'i += CInt(txtbox4.Text)
        'Application.DoEvents()

        'txtbox5.Text = Calculo2("CTD").ToString
        'i += CInt(txtbox5.Text)
        'Application.DoEvents()

        txtbox6.Text = Calculo2("LOG").ToString
        i += CInt(txtbox6.Text)
        Application.DoEvents()

        txtbox7.Text = Calculo2("ABO").ToString
        i += CInt(txtbox7.Text)
        Application.DoEvents()

        'txtbox8.Text = Calculo2("ING").ToString
        'i += CInt(txtbox8.Text)
        'Application.DoEvents()

        txtbox9.Text = Calculo3("LOG").ToString
        i += CInt(txtbox9.Text)

        txtbox10.Text = Calculo3("ABO").ToString
        i += CInt(txtbox10.Text)

        'txtbox11.Text = Calculo3("ING").ToString
        'i += CInt(txtbox11.Text)

        'txtbox12.Text = Calculo4("MOS").ToString
        'i += CInt(txtbox12.Text)

        txtTot.Text = i.ToString

        Application.DoEvents()

        Button1.Enabled = True
        Me.UseWaitCursor = False

    End Sub
    Private Sub txt1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtbox1.DoubleClick, txtbox2.DoubleClick, txtbox6.DoubleClick, txtbox7.DoubleClick, txtbox9.DoubleClick, txtbox10.DoubleClick
        Dim txt As TextBox = CType(sender, TextBox)
        Dim dt As DataTable
        Dim flg As Boolean = False

        If dgv6.DataSource IsNot Nothing Then
            dt = CType(dgv6.DataSource, DataTable)

        Else
            ColFechaRuta.DataPropertyName = "fecha_0"
            ColNumeroRuta.DataPropertyName = "ruta_0"
            ColCodigo.DataPropertyName = "bpcnum_0"
            ColCliente.DataPropertyName = "bpcnam_0"
            ColDescripcionArticulo.DataPropertyName = "itmdes1_0"
            ColArticulo.DataPropertyName = "itmref_0"
            ColCantidad.DataPropertyName = "cant"
            ColFechaRetiro.DataPropertyName = "credat_0"
            ColObs.DataPropertyName = "yobsrec_0"
            ColItn.DataPropertyName = "Num_0"
            dt = New DataTable
            dgv6.DataSource = dt
        End If

        Me.UseWaitCursor = True
        With lblBuscando
            .Top = dgv6.Top + (dgv6.Height - .Height) \ 2
            .Left = dgv6.Left + (dgv6.Width - .Width) \ 2
            .Visible = True
            .BringToFront()
            Application.DoEvents()
            Application.DoEvents()
        End With

        If txt Is txtbox1 Then
            Calculo1(" ", dt)
            FechasRetiros(dt)
            lblTitulo.Text = "ESPERA DE PROCESO"

        ElseIf txt Is txtbox2 Then
            Calculo1("SRV", dt)
            FechasRetiros(dt)
            lblTitulo.Text = "EN PROCESO"

            'ElseIf txt Is txtbox3 Then
            '    Calculo2("ADM", dt)
            '    FechaPistoleo(dt, "ADM")
            '    lblTitulo.Text = "ADMINISTRACION DE VENTA"

            'ElseIf txt Is txtbox4 Then
            '    Calculo2("VEN", dt)
            '    FechaPistoleo(dt, "VEN")
            '    lblTitulo.Text = "VENTAS"

            'ElseIf txt Is txtbox5 Then
            '    Calculo2("CTD", dt)
            '    FechaPistoleo(dt, "CTD")
            '    lblTitulo.Text = "CONTADOS"

        ElseIf txt Is txtbox6 Then
            Calculo2("LOG", dt)
            FechaPistoleo(dt, "LOG")
            lblTitulo.Text = "PENDIENTE - LOGISTICA"

        ElseIf txt Is txtbox7 Then
            Calculo2("ABO", dt)
            FechaPistoleo(dt, "ABO")
            lblTitulo.Text = "PENDIENTE - ABONOS"

            'ElseIf txt Is txtbox8 Then
            '    Calculo2("ING", dt)
            '    FechaPistoleo(dt, "ING")
            '    lblTitulo.Text = "PENDIENTE - SISTEMAS FIJO"

        ElseIf txt Is txtbox9 Then
            Calculo3("LOG", dt)
            FechaPistoleo(dt, "LOG")
            lblTitulo.Text = "PENDIENTE CON RUTA - LOGISTICA"

        ElseIf txt Is txtbox10 Then
            Calculo3("ABO", dt)
            FechaPistoleo(dt, "ABO")
            lblTitulo.Text = "PENDIENTE CON RUTA - ABONOS"

            'ElseIf txt Is txtbox11 Then
            '    Calculo3("ING", dt)
            '    FechaPistoleo(dt, "ING")
            '    lblTitulo.Text = "PENDIENTE CON RUTA - SISTEMAS FIJO"

            'ElseIf txt Is txtbox12 Then
            '    Calculo4("MOS", dt)
            '    FechaPistoleo(dt, "MOS")
            '    lblTitulo.Text = "MOSTRADOR"
        End If

        lblBuscando.Visible = False
        Me.UseWaitCursor = False

        With dgv6
            .DataSource = dt
            .Columns(.Columns.Count - 1).Visible = False
        End With

    End Sub

    Private Function Calculo1(ByVal sector As String, Optional ByRef xdt As DataTable = Nothing, Optional ByVal txt As String = "") As Integer
        Dim da As OracleDataAdapter
        Dim Sql As String
        Dim dt As New DataTable
        Dim i As Integer = 0

        'Sql = "select xrc.FECHA_0, xrc.ruta_0,itn.num_0,bpcnum_0, bpcnam_0,itmdes1_0 , det.itmref_0, equipos_1 + equipos_3 as cant, itn.credat_0, yobsrec_0,itn.add_0 as sector "
        'Sql &= "from (interven itn  inner join xrutad xrd on (itn.num_0 = xrd.vcrnum_0)) inner join xrutac xrc on (xrd.ruta_0 = xrc.ruta_0) "
        'Sql &= "inner join bpcustomer bpc on (itn.bpc_0 = bpc.bpcnum_0) inner join yitndet det on (itn.num_0= det.num_0) "
        'Sql &= "inner join itmmaster itm on (det.itmref_0 = itm.itmref_0) "
        'Sql &= "where numlig_0 = '1000' and tipo_0 = 'RET' and typ_0 <> 'G1' and estado_0 = 3 and zflgtrip_0 = 2 and xsector_0 = :xsector and itn.bpc_0 <> '402000' "
        'Sql &= "order by num_0"

        Sql = " select xrc.FECHA_0, xrc.ruta_0,itn.num_0,bpcnum_0, bpcnam_0,macdes_0 as itmdes1_0,mac.macpdtcod_0 as itmref_0 , count(mac.macpdtcod_0) as cant,macitntyp_0 as ESTADO, itn.credat_0, yobsrec_0,itn.add_0 as sector "
        Sql &= "from (interven itn  inner join xrutad xrd on (itn.num_0 = xrd.vcrnum_0)) inner join xrutac xrc on (xrd.ruta_0 = xrc.ruta_0) "
        Sql &= "inner join bpcustomer bpc on (itn.bpc_0 = bpc.bpcnum_0) "
        Sql &= "inner join sremac sre on (sre.yitnnum_0 = itn.num_0) "
        Sql &= "inner join machines mac on (sre.macnum_0 = mac.macnum_0) "
        Sql &= " where   tipo_0 = 'RET' and typ_0 <> 'G1' and estado_0 = 3 and zflgtrip_0 = 2 and xsector_0 = :xsector and itn.bpc_0 <> '402000' "
        Sql &= "group by xrc.FECHA_0, xrc.ruta_0,itn.num_0,bpcnum_0, bpcnam_0,macdes_0 ,mac.macpdtcod_0, itn.credat_0, yobsrec_0,itn.add_0,macitntyp_0 "
        Sql &= "order by num_0 "
        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("xsector", OracleType.VarChar).Value = sector
        da.Fill(dt)
        da.Dispose()

        Sql = "select itn.num_0,bpcnum_0,bpcnam_0,  itn.credat_0, yobsrec_0,itmdes1_0 , yit.itmref_0, sum(tqty_0) as cant,itn.add_0 as sector "
        Sql &= " from (interven itn inner join yitndet yit on (itn.num_0 = yit.num_0 and typlig_0 = 1)) "
        Sql &= " inner join itmmaster itm on (yit.itmref_0 = itm.itmref_0) "
        Sql &= "      inner join bpcustomer bpc on (itn.bpc_0 = bpc.bpcnum_0) "
        Sql &= " where zflgtrip_0 = 1 and typ_0 = 'D1' and xsector_0 = :xsector and itn.bpc_0 <> '402000' "
        Sql &= " group by  itn.num_0,bpcnum_0,bpcnam_0, itn.credat_0, yobsrec_0, yit.itmref_0,itmdes1_0,itn.add_0 "

        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("xsector", OracleType.VarChar).Value = sector
        da.Fill(dt)
        da.Dispose()

        For Each dr As DataRow In dt.Rows
            i += CInt(dr("cant"))

            If txt <> "" Then
                dr.BeginEdit()
                dr("sector") = txt
                dr.EndEdit()
            End If
        Next

        If xdt IsNot Nothing Then
            xdt = dt
        End If

        Return i

    End Function
    Private Function Calculo2(ByVal Sector As String, Optional ByRef xdt As DataTable = Nothing, Optional ByVal txt As String = "") As Integer
        Dim da As OracleDataAdapter
        Dim Sql As String
        Dim dt As DataTable
        Dim i As Integer = 0

        Sql = "select xrc.FECHA_0,xrc.ruta_0, itn.bpc_0 as bpcnum_0, bpcnam_0,itmdes1_0 , yit.itmref_0, xrd.equipos_1 + xrd.equipos_3 as cant, itn.num_0, itn.credat_0, yobsrec_0 ,itn.add_0 as sector "
        Sql &= "from ((interven itn  inner join xrutad xrd on (itn.num_0 = xrd.vcrnum_0))"
        Sql &= " inner join yitndet yit on (itn.num_0 = yit.num_0 and typlig_0 = 1) "
        Sql &= "inner join itmmaster itm on (yit.itmref_0 = itm.itmref_0) "
        Sql &= "	 inner join xrutac xrc on (xrd.ruta_0 = xrc.ruta_0)) "
        Sql &= "     inner join bpcustomer bpc on (itn.bpc_0 = bpc.bpcnum_0) "
        Sql &= "where xsector_0 = '" & Sector & "' and "
        Sql &= "	  (zflgtrip_0 IN (2,3,4,6) or ((ysdhdeb_0) <> ' ' and zflgtrip_0 = 7)) and "
        Sql &= "	  estado_0 = 3 and "
        Sql &= "	  valid_0 = 1 and "
        Sql &= "	  itn.tripnum_0 = ' ' and "
        Sql &= "	  tipo_0 = 'RET' and "
        Sql &= "      typ_0 <> 'G1' and "
        Sql &= "      itn.bpc_0 <> '402000' "
        Sql &= "order by num_0"

        da = New OracleDataAdapter(Sql, cn)
        dt = New DataTable
        da.Fill(dt)

        '2016.08.31 se quita para que no aparezca duplicado
        '--------------------------------------------------
        If Sector <> "LOG" And Sector <> "ING" And Sector <> "ABO" Then
            Sql = "select  itn.num_0, itn.bpc_0 as bpcnum_0, bpcnam_0, itn.credat_0, yobsrec_0,itmdes1_0 , yit.itmref_0, sum(tqty_0) as cant,itn.add_0 as sector "
            Sql &= "from (interven itn inner join yitndet yit on (itn.num_0 = yit.num_0 and typlig_0 = 1)) "
            Sql &= "inner join itmmaster itm on (yit.itmref_0 = itm.itmref_0) "
            Sql &= "     inner join bpcustomer bpc on (itn.bpc_0 = bpc.bpcnum_0) "
            Sql &= "where zflgtrip_0 IN (2,3,4,6) and typ_0 = 'D1' and xsector_0 = :xsector "
            Sql &= "group by itn.dat_0, itn.num_0, itn.bpc_0, bpcnam_0, itn.credat_0, yobsrec_0, yit.itmref_0,itmdes1_0,itn.add_0 "
            Sql &= "order by num_0"
            da = New OracleDataAdapter(Sql, cn)
            da.SelectCommand.Parameters.Add("xsector", OracleType.VarChar).Value = Sector
            da.Fill(dt)
            da.Dispose()
        End If


        'Eliminacion de documentos duplicados


        For Each dr As DataRow In dt.Rows
            i += CInt(dr("cant"))

            If txt <> "" Then
                dr.BeginEdit()
                dr("sector") = txt
                dr.EndEdit()
            End If

        Next

        da.Dispose()
        dt.Dispose()

        If xdt IsNot Nothing Then xdt = dt
        Return i

    End Function
    Private Function Calculo3(ByVal Sector As String, Optional ByRef xdt As DataTable = Nothing, Optional ByVal txt As String = "") As Integer
        Dim da As OracleDataAdapter
        Dim Sql As String
        Dim dt As DataTable
        Dim i As Integer = 0

        'Sql = "select xrc.fecha_0,xrc.ruta_0,itn.num_0, itn.bpc_0 as bpcnum_0, bpcnam_0,itmdes1_0 , yit.itmref_0, xrd.equipos_1 + xrd.equipos_3 as cant, itn.credat_0, yobsrec_0 ,itn.add_0 as sector "
        'Sql &= "from ((interven itn  inner join xrutad xrd on (itn.num_0 = xrd.vcrnum_0))"
        'Sql &= " inner join yitndet yit on (itn.num_0 = yit.num_0 and typlig_0 = 1) "
        'Sql &= "inner join itmmaster itm on (yit.itmref_0 = itm.itmref_0) "
        'Sql &= "	 inner join xrutac xrc on (xrd.ruta_0 = xrc.ruta_0)) "
        'Sql &= "     inner join bpcustomer bpc on (itn.bpc_0 = bpc.bpcnum_0) "
        'Sql &= "where xsector_0 = '" & Sector & "' and "
        'Sql &= "	  (zflgtrip_0 IN (2,3,4,6) or ((ysdhdeb_0) <> ' ' and zflgtrip_0 = 7)) and "
        ''Sql &= "	  estado_0 = 3 and "
        ''Sql &= "	  valid_0 = 1 and "
        'Sql &= "	  itn.tripnum_0 <> ' ' and "
        'Sql &= "	  tipo_0 = 'ENT' and "
        'Sql &= "      typ_0 <> 'G1' and "
        'Sql &= "      itn.bpc_0 <> '402000' "
        'Sql &= "order by num_0"

        Sql = " select xrc.fecha_0,xrc.ruta_0,itn.num_0, itn.bpc_0 as bpcnum_0, bpcnam_0,macdes_0 as itmdes1_0,mac.macpdtcod_0 as itmref_0, count(mac.macpdtcod_0) as cant,macitntyp_0 as ESTADO, itn.credat_0, yobsrec_0 ,itn.add_0 as sector "
        Sql &= "from ((interven itn  inner join xrutad xrd on (itn.num_0 = xrd.vcrnum_0)) "
        Sql &= "inner join sremac sre on (sre.yitnnum_0 = itn.num_0) "
        Sql &= "inner join machines mac on (sre.macnum_0 = mac.macnum_0) "
        Sql &= "inner join xrutac xrc on (xrd.ruta_0 = xrc.ruta_0)) "
        Sql &= "inner join bpcustomer bpc on (itn.bpc_0 = bpc.bpcnum_0) "
        Sql &= "where xsector_0 = '" & Sector & "' and "
        Sql &= "(zflgtrip_0 IN (2,3,4,6) or ((ysdhdeb_0) <> ' ' and zflgtrip_0 = 7)) and "
        Sql &= "itn.tripnum_0 <> ' ' and "
        Sql &= "tipo_0 = 'ENT' and "
        Sql &= "typ_0 <> 'G1' and "
        Sql &= "itn.bpc_0 <> '402000' "
        Sql &= "group by xrc.FECHA_0, xrc.ruta_0,itn.num_0,itn.bpc_0, bpcnam_0,macdes_0 ,mac.macpdtcod_0, itn.credat_0, yobsrec_0,itn.add_0,macitntyp_0 "
        Sql &= "order by num_0"


        da = New OracleDataAdapter(Sql, cn)
        dt = New DataTable
        da.Fill(dt)

        Sql = "select  itn.num_0, itn.bpc_0 as bpcnum_0,itmdes1_0 ,yit.itmref_0, bpcnam_0,itn.credat_0, yobsrec_0, sum(tqty_0) as cant,itn.add_0 as sector "
        Sql &= "from (interven itn inner join yitndet yit on (itn.num_0 = yit.num_0 and typlig_0 = 1)) "
        Sql &= "     inner join bpcustomer bpc on (itn.bpc_0 = bpc.bpcnum_0) "
        Sql &= " inner join itmmaster itm on (yit.itmref_0 = itm.itmref_0) "
        Sql &= "where zflgtrip_0 IN (2,3,4,6) and typ_0 = 'D1' and xsector_0 = :xsector "
        Sql &= "group by itn.dat_0, itn.num_0, itn.bpc_0, bpcnam_0, itn.credat_0, yobsrec_0, yit.itmref_0,itmdes1_0 ,itn.add_0 "
        Sql &= "order by num_0"
        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("xsector", OracleType.VarChar).Value = Sector
        da.Fill(dt)
        da.Dispose()

        For Each dr As DataRow In dt.Rows
            i += CInt(dr("cant"))

            If txt <> "" Then
                dr.BeginEdit()
                dr("sector") = txt
                dr.EndEdit()
            End If
        Next

        da.Dispose()

        If xdt IsNot Nothing Then xdt = dt
        Return i

    End Function
    Private Function Calculo4(ByVal Sector As String, Optional ByRef xdt As DataTable = Nothing, Optional ByVal txt As String = "") As Integer
        Dim da As OracleDataAdapter
        Dim Sql As String
        Dim dt As DataTable
        Dim i As Integer = 0

        Sql = "select  itn.num_0, itn.bpc_0 as bpcnum_0, bpcnam_0, itmdes1_0 ,yit.itmref_0,  sum(tqty_0) as cant, itn.credat_0, yobsrec_0,itn.add_0 as sector "
        Sql &= "from (interven itn  inner join yitndet yit on (itn.num_0 = yit.num_0)) "
        Sql &= " inner join itmmaster itm on (yit.itmref_0 = itm.itmref_0) "
        Sql &= "	 inner join bpcustomer bpc on (itn.bpc_0 = bpc.bpcnum_0) "
        Sql &= "where xsector_0 = '" & Sector & "' and "
        Sql &= "	  (zflgtrip_0 IN (2,3,4,6) or ((ysdhdeb_0) <> ' ' and zflgtrip_0 = 7)) and "
        Sql &= "	  yit.typlig_0 = 1 and "
        Sql &= "      typ_0 <> 'G1' and "
        Sql &= "      itn.bpc_0 <> '402000' "
        Sql &= "group by dat_0, itn.num_0, itn.bpc_0, bpcnam_0, itn.credat_0, yobsrec_0,  yit.itmref_0 ,itmdes1_0,itn.add_0  "
        Sql &= "order by dat_0, num_0"

        da = New OracleDataAdapter(Sql, cn)
        dt = New DataTable
        da.Fill(dt)

        For Each dr As DataRow In dt.Rows
            i += CInt(dr("cant"))

            If txt <> "" Then
                dr.BeginEdit()
                dr("sector") = txt
                dr.EndEdit()
            End If
        Next

        da.Dispose()
        dt.Dispose()

        If xdt IsNot Nothing Then xdt = dt
        Return i

    End Function
    Private Sub FechasRetiros(ByVal dt1 As DataTable)
        Dim da As OracleDataAdapter
        Dim sql As String
        Dim dt2 As New DataTable
        Dim dr2 As DataRow
        Dim dr1 As DataRow

        sql = "SELECT xc.* "
        sql &= "FROM xrutac xc INNER JOIN xrutad xd ON (xc.ruta_0 = xd.ruta_0) "
        sql &= "WHERE vcrnum_0 = :vcrnum AND estado_0 = 3 AND tipo_0 = 'RET'"

        da = New OracleDataAdapter(sql, cn)
        da.SelectCommand.Parameters.Add("vcrnum", OracleType.VarChar)

        For Each dr1 In dt1.Rows
            da.SelectCommand.Parameters("vcrnum").Value = dr1("num_0").ToString
            dt2.Clear()
            da.Fill(dt2)

            dr1.BeginEdit()
            If dt2.Rows.Count > 0 Then
                dr2 = dt2.Rows(0)

                dr1("credat_0") = CDate(dr2("fecha_0"))

            Else
                dr1("credat_0") = #12/31/1599#

            End If
            dr1.EndEdit()

        Next

    End Sub
    Private Sub FechaPistoleo(ByVal dt1 As DataTable, ByVal sector As String)
        Dim da As OracleDataAdapter
        Dim sql As String
        Dim dt2 As New DataTable
        Dim dr2 As DataRow
        Dim dr1 As DataRow

        sql = "select * "
        sql &= "from xsegto "
        sql &= "where itn_0 = :itn and para_0 = :sector "
        sql &= "order by fecha_0 desc, hora_0 desc "

        da = New OracleDataAdapter(sql, cn)
        da.SelectCommand.Parameters.Add("itn", OracleType.VarChar)
        da.SelectCommand.Parameters.Add("sector", OracleType.VarChar)

        For Each dr1 In dt1.Rows
            da.SelectCommand.Parameters("itn").Value = dr1("num_0").ToString
            da.SelectCommand.Parameters("sector").Value = sector
            dt2.Clear()
            da.Fill(dt2)

            dr1.BeginEdit()
            If dt2.Rows.Count > 0 Then
                dr2 = dt2.Rows(0)

                dr1("credat_0") = CDate(dr2("fecha_0"))

            Else
                dr1("credat_0") = #12/31/1599#

            End If
            dr1.EndEdit()

        Next

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim dt As DataTable
        Dim dtx As New DataTable
        Dim txt As String


        If dgv6.DataSource IsNot Nothing Then
            dt = CType(dgv6.DataSource, DataTable)

        Else
            ColFechaRuta.DataPropertyName = "fecha_0"
            ColNumeroRuta.DataPropertyName = "ruta_0"
            ColCodigo.DataPropertyName = "bpcnum_0"
            ColCliente.DataPropertyName = "bpcnam_0"
            ColArticulo.DataPropertyName = "Itmref_0"
            ColDescripcionArticulo.DataPropertyName = "itmdes1_0"
            ColCantidad.DataPropertyName = "cant"
            ColFechaRetiro.DataPropertyName = "credat_0"
            ColObs.DataPropertyName = "yobsrec_0"
            ColItn.DataPropertyName = "Num_0"
            dt = New DataTable
            dgv6.DataSource = dt
        End If

        Me.UseWaitCursor = True
        With lblBuscando
            .Top = dgv6.Top + (dgv6.Height - .Height) \ 2
            .Left = dgv6.Left + (dgv6.Width - .Width) \ 2
            .Visible = True
            .BringToFront()
            Application.DoEvents()
            Application.DoEvents()
        End With

        txt = "ESPERA DE PROCESO"
        Calculo1(" ", dt, txt)
        FechasRetiros(dt)
        dt.Merge(dt)

        txt = "EN PROCESO"
        Calculo1("SRV", dtx, txt)
        FechasRetiros(dtx)
        dt.Merge(dtx)

        txt = "ADMINISTRACION DE VENTA"
        Calculo2("ADM", dtx, txt)
        FechaPistoleo(dtx, "ADM")
        dt.Merge(dtx)

        txt = "VENTAS"
        Calculo2("VEN", dtx, txt)
        FechaPistoleo(dtx, "VEN")
        dt.Merge(dtx)

        txt = "CONTADOS"
        Calculo2("CTD", dtx, txt)
        FechaPistoleo(dtx, "CTD")
        dt.Merge(dtx)

        txt = "PENDIENTE - LOGISTICA"
        Calculo2("LOG", dtx, txt)
        FechaPistoleo(dtx, "LOG")
        dt.Merge(dtx)

        txt = "PENDIENTE - ABONOS"
        Calculo2("ABO", dtx, txt)
        FechaPistoleo(dtx, "ABO")
        dt.Merge(dtx)

        txt = "PENDIENTE - SISTEMAS FIJO"
        Calculo2("ING", dtx, txt)
        FechaPistoleo(dtx, "ING")
        dt.Merge(dtx)

        txt = "PENDIENTE CON RUTA - LOGISTICA"
        Calculo3("LOG", dtx, txt)
        FechaPistoleo(dtx, "LOG")
        dt.Merge(dtx)

        txt = "PENDIENTE CON RUTA - ABONOS"
        Calculo3("ABO", dtx, txt)
        FechaPistoleo(dtx, "ABO")
        dt.Merge(dtx)

        txt = "PENDIENTE CON RUTA - SISTEMAS FIJO"
        Calculo3("ING", dtx, txt)
        FechaPistoleo(dtx, "ING")
        dt.Merge(dtx)

        txt = "MOSTRADOR"
        Calculo4("MOS", dtx, txt)
        FechaPistoleo(dtx, "MOS")
        dt.Merge(dtx)


        lblBuscando.Visible = False
        Me.UseWaitCursor = False

        With dgv6
            .DataSource = dt
            .Columns(.Columns.Count - 1).Visible = False
        End With

    End Sub

    
End Class