Imports System.Drawing
Imports System.Data.OracleClient

Public Class FrmPlanillaAbonados
    Private da As OracleDataAdapter
    Private Fecha1 As Date
    Private Fecha2 As Date
    Private dt1 As New DataTable 'Contratos
    Private dt2 As New DataTable 'Parque
    Private dt3 As New DataTable 'Remitos
    Private dt4 As New DataTable 'Parque Procesado (sremac)
    Private con As New ContratoServicio(cn)

    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        btnConsultar.Enabled = False
        Me.UseWaitCursor = True

        'AJUSTO EL RANGO DE FECHA DE CONSULTA
        Fecha1 = New Date(dtp.Value.Year, dtp.Value.Month, 1)
        Fecha2 = Fecha1.AddMonths(1)
        Fecha2 = Fecha2.AddDays(-1)

        Tab.SelectedTab = TabPage1

        ConsultaContratos()

        ConsultaParque()
        ConsultaRemito()
        ConsultaParqueProcesado()

        lblInfo.Text = "Procesando datos..."
        lblInfo.Visible = True
        Application.DoEvents()

        'Completo el resto de las columnas

        For i = 0 To dt1.Rows.Count - 1
            Dim dr As DataRow

            dr = dt1.Rows(i)

            'Abro contrato
            con.Abrir(dr("connum_0").ToString)

            dr.BeginEdit()
            dr("VisitaMensual") = (con.CantidadCubierta("652006") > 0)

            Parque(dr("bpcnum_0").ToString, dr("bpaadd_0").ToString, dr)
            Remito(dr("bpcnum_0").ToString, dr("bpaadd_0").ToString, dr)
            ParqueProcesado(dr("bpcnum_0").ToString, dr("bpaadd_0").ToString, dr)
            ParqueUnificar(dr("bpcnum_0").ToString, dr("bpaadd_0").ToString, dr)
            dr.EndEdit()

            If i Mod 50 = 0 Then
                lblInfo.Text = "Procesando datos " & i.ToString & " de " & dt1.Rows.Count.ToString & "..."
                lblInfo.Visible = True
                Application.DoEvents()
            End If
        Next

        lblInfo.Text = "Proceso finalizado."

        If dgv1.DataSource Is Nothing Then
            CodCliente.DataPropertyName = "bpcnum_0"
            ColRazonSocial.DataPropertyName = "bpcnam_0"
            ColSucursal.DataPropertyName = "bpaadd_0"
            ColDomicilio.DataPropertyName = "bpaaddlig_0"
            ColLocalidad.DataPropertyName = "cty_0"
            ColNumContrato.DataPropertyName = "connum_0"
            ColFechaVencContrato.DataPropertyName = "conenddat_0"
            ColParqueTotal.DataPropertyName = "ParqueTotal"
            colParqueVencidoManuales.DataPropertyName = "ParqueVencidoManuales"
            colParqueVencidoCarros.DataPropertyName = "ParqueVencidoCarros"
            colParqueVencidoMangueras.DataPropertyName = "ParqueVencidoMangueras"
            colParqueAVencerManuales.DataPropertyName = "ParqueAVencerManuales"
            colParqueAVencerCarros.DataPropertyName = "ParqueAVencerCarros"
            colParqueAVencerMangueras.DataPropertyName = "ParqueAVencerMangueras"
            ColParqueAUnificar.DataPropertyName = "ParqueUnificar"
            colRetirado.DataPropertyName = "Retirado"
            colEntregado.DataPropertyName = "Entregado"
            ColParqueVisitaMensual.DataPropertyName = "VisitaMensual"
            ColParqueControles.DataPropertyName = "ControlPeriodico"
            ColMesVence.DataPropertyName = "FechaControl"
            ColRemitoClienteSucursalABO.DataPropertyName = "TieneRemito"
            colUnificacion.DataPropertyName = "xunifi_0"
            dgv1.DataSource = dt1
        End If

        Me.UseWaitCursor = False
        btnConsultar.Enabled = True

    End Sub
    Private Sub ConsultaContratos()
        Dim Sql As String
        Dim da As OracleDataAdapter

        lblInfo.Text = "Recuperando contratos..."
        lblInfo.Visible = True
        Application.DoEvents()

        Application.DoEvents()
        Sql = "SELECT bpcnum_0, bpcnam_0, bpa.bpaadd_0, bpa.bpaaddlig_0, cty_0, con.connum_0, conenddat_0, "
        Sql &= "       0 AS ParqueTotal, "
        Sql &= "       0 AS ParqueVencidoManuales, "
        Sql &= "       0 AS ParqueVencidoCarros, "
        Sql &= "       0 AS ParqueVencidoMangueras, "
        Sql &= "       0 AS ParqueAVencerManuales, "
        Sql &= "       0 AS ParqueAVencerCarros, "
        Sql &= "       0 AS ParqueAVencerMangueras, "
        Sql &= "       0 AS ParqueUnificar, "
        Sql &= "       0 AS Retirado, "
        Sql &= "       0 AS Entregado, "
        Sql &= "       0 AS VisitaMensual, "
        Sql &= "       0 AS ControlPeriodico, "
        Sql &= "       sysdate AS FechaControl, "
        Sql &= "       0 AS TieneRemito, "
        Sql &= "       xunifi_0 "
        Sql &= "FROM contserv con inner join "
        Sql &= "	 contsuc suc on (con.connum_0 = suc.connum_0) inner join "
        Sql &= "	 bpcustomer bpc on (con.conbpc_0 = bpc.bpcnum_0) inner join "
        Sql &= "	 bpaddress bpa on (con.conbpc_0 = bpa.bpanum_0 and suc.bpaadd_0 = bpa.bpaadd_0) "
        Sql &= "WHERE itmref_0 = '452000' AND "
        Sql &= "      conenddat_0 > :datini AND "
        Sql &= "      rsiflg_0 <> 2 AND "
        Sql &= "      fddflg_0 <> 2 "
        Sql &= "ORDER BY bpcnum_0, bpa.bpaadd_0, conenddat_0 desc"

        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("datini", OracleType.DateTime)

        If Not ChkContratosVencidos.Checked Then
            da.SelectCommand.Parameters("datini").Value = Fecha1
        Else
            da.SelectCommand.Parameters("datini").Value = Fecha1.AddMonths(-2)
        End If

        dt1.Clear()
        da.Fill(dt1)
        da.Dispose()
        da = Nothing

        'Si hay dos contratos para el mimso cliente, dejo solamente el más nuevo
        Dim Cli As String = ""
        Dim Suc As String = ""

        If ChkContratosVencidos.Checked Then
            lblInfo.Text = "Eliminando contratos duplicados..."
            lblInfo.Visible = True
            Application.DoEvents()

            For i = 0 To dt1.Rows.Count - 1
                Dim dr As DataRow = dt1.Rows(i)

                If Cli = dr("bpcnum_0").ToString And Suc = dr("bpaadd_0").ToString Then
                    dr.Delete()
                Else
                    Cli = dr("bpcnum_0").ToString
                    Suc = dr("bpaadd_0").ToString
                End If
            Next

            dt1.AcceptChanges()

        End If

    End Sub
    Private Sub ConsultaParque()
        Dim Sql As String = ""
        Dim da As OracleDataAdapter

        lblInfo.Text = "Recuperando parque..."
        lblInfo.Visible = True
        Application.DoEvents()

        Sql &= "SELECT mac.macnum_0, macpdtcod_0, macqty_0, macitntyp_0, datnext_0, xitn_0, mac.bpcnum_0, mac.fcyitn_0,tsicod_4 "
        Sql &= "FROM machines mac INNER JOIN "
        Sql &= "	    ymacitm ymc on (mac.macnum_0 = ymc.macnum_0) INNER JOIN	"
        Sql &= "	    bomd bmd on (mac.macpdtcod_0 = bmd.itmref_0 AND ymc.cpnitmref_0 = bmd.cpnitmref_0 AND bomalt_0 = 99 AND bomseq_0 = 10) INNER JOIN "
        Sql &= "	    itmmaster itm on (itm.itmref_0 = mac.macpdtcod_0) "
        Sql &= "WHERE mac.bpcnum_0 IN ( "
        Sql &= ""
        Sql &= "  SELECT DISTINCT bpcnum_0 "
        Sql &= "	 FROM contserv con inner join "
        Sql &= "	 	  contsuc suc on (con.connum_0 = suc.connum_0) inner join "
        Sql &= "	 	  bpcustomer bpc on (con.conbpc_0 = bpc.bpcnum_0) inner join "
        Sql &= "		  bpaddress bpa on (con.conbpc_0 = bpa.bpanum_0 and suc.bpaadd_0 = bpa.bpaadd_0) "
        Sql &= "	 WHERE itmref_0 = '452000' and "
        Sql &= "           conenddat_0 > :datini AND "
        Sql &= "           rsiflg_0 <> 2 AND "
        Sql &= "           fddflg_0 <> 2 "
        Sql &= ") AND "
        Sql &= "      mac.macitntyp_0 = 1 AND "
        Sql &= "      mac.xitn_0 <> 'X0' AND "
        Sql &= "      datnext_0 >= :desde "

        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("datini", OracleType.DateTime)

        'Fecha para contrato
        If Not ChkContratosVencidos.Checked Then
            da.SelectCommand.Parameters("datini").Value = Fecha1
        Else
            da.SelectCommand.Parameters("datini").Value = Fecha1.AddMonths(-2)
        End If
        'Fecha Vto Parque. A partir de 24 meses hacia atras del período seleccionado
        da.SelectCommand.Parameters.Add("desde", OracleType.DateTime).Value = Fecha1.AddYears(-2)

        dt2.Clear()
        da.Fill(dt2)
        da.Dispose()

    End Sub
    Private Sub ConsultaRemito()
        Dim Sql As String
        Dim da As OracleDataAdapter

        lblInfo.Text = "Recuperando remitos..."
        lblInfo.Visible = True
        Application.DoEvents()

        Sql = "SELECT sdh.sdhnum_0, xsector_0, sdh.credat_0, sdh.bpcord_0, sdh.bpaadd_0, itmref_0 "
        Sql &= "FROM sdelivery sdh inner join"
        Sql &= "	 sdeliveryd sdd on (sdh.sdhnum_0 = sdd.sdhnum_0)"
        Sql &= "WHERE xsector_0 = 'ABO' and"
        Sql &= "	  qty_0 - rtnqty_0 > 0 "
        Sql &= "ORDER BY credat_0 DESC"

        da = New OracleDataAdapter(Sql, cn)

        dt3.Clear()
        da.Fill(dt3)
        da.Dispose()
        da = Nothing
    End Sub
    Private Sub ConsultaParqueProcesado()
        Dim Sql As String = ""
        Dim da As OracleDataAdapter

        lblInfo.Text = "Recuperando parque procesado..."
        lblInfo.Visible = True
        Application.DoEvents()

        Sql = "SELECT bpc_0, bpaadd_0, macnum_0, zflgtrip_0, num_0, dat_0 "
        Sql &= "FROM interven itn inner join "
        Sql &= "     sremac sre on (num_0 = yitnnum_0) "
        Sql &= "WHERE dat_0 >= :datini AND  "
        Sql &= "      zflgtrip_0 in (2, 3, 4, 5) AND "
        Sql &= "      bpc_0 IN ( "
        Sql &= ""
        Sql &= "  SELECT DISTINCT bpcnum_0 "
        Sql &= "  FROM contserv con inner join "
        Sql &= "	   contsuc suc on (con.connum_0 = suc.connum_0) inner join "
        Sql &= "       bpcustomer bpc on (con.conbpc_0 = bpc.bpcnum_0) inner join "
        Sql &= "       bpaddress bpa on (con.conbpc_0 = bpa.bpanum_0 and suc.bpaadd_0 = bpa.bpaadd_0) "
        Sql &= "  WHERE itmref_0 = '452000' and "
        Sql &= "        rsiflg_0 <> 2 AND "
        Sql &= "        fddflg_0 <> 2 "
        Sql &= ") "
        da = New OracleDataAdapter(Sql, cn)

        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("datini", OracleType.DateTime)

        'Fecha para contrato
        If Not ChkContratosVencidos.Checked Then
            da.SelectCommand.Parameters("datini").Value = Fecha1
        Else
            da.SelectCommand.Parameters("datini").Value = Fecha1.AddMonths(-2)
        End If

        dt4.Clear()
        da.Fill(dt4)
        da.Dispose()

    End Sub
    Private Sub Parque(ByVal Cli As String, ByVal Suc As String, ByVal dr As DataRow)
        Dim dv As New DataView(dt2)
        Dim dr1 As DataRow
        Dim ParqueVencidoManuales As Integer = 0
        Dim ParqueVencidoCarros As Integer = 0
        Dim ParqueVencidoMangueras As Integer = 0
        Dim ParqueAVencerManuales As Integer = 0
        Dim ParqueAVencerCarros As Integer = 0
        Dim ParqueAVencerMangueras As Integer = 0
        Dim ParqueTotal As Integer = 0
        Dim ParqueARetirar As Integer = 0

        dv.RowFilter = "bpcnum_0 = '" & Cli & "' AND fcyitn_0 = '" & Suc & "'"

        dr.BeginEdit()

        dr("FechaControl") = DBNull.Value

        For i = 0 To dv.Count - 1
            dr1 = CType(dv.Item(i), DataRowView).Row

            If CDate(dr1("datnext_0")) > Fecha1.AddMonths(-5) AndAlso CDate(dr1("datnext_0")) < Fecha1 Then
                'CALCULO DE PARQUE VENCIDO
                Select Case dr1("tsicod_4").ToString
                    Case "501", "502", "521", "594"
                        ParqueVencidoManuales += CInt(dr1("macqty_0"))
                        ParqueTotal += CInt(dr1("macqty_0"))

                    Case "503"
                        ParqueVencidoCarros += CInt(dr1("macqty_0"))
                        ParqueTotal += CInt(dr1("macqty_0"))

                    Case "511", "512", "522"
                        ParqueVencidoMangueras += CInt(dr1("macqty_0"))
                        ParqueTotal += CInt(dr1("macqty_0"))

                End Select

            ElseIf CDate(dr1("datnext_0")) >= Fecha1 And CDate(dr1("datnext_0")) <= Fecha2 Then
                'CALCULO DE PARQUE A VENCER
                Select Case dr1("tsicod_4").ToString
                    Case "501", "502", "521", "594"
                        ParqueAVencerManuales += CInt(dr1("macqty_0"))
                        ParqueTotal += CInt(dr1("macqty_0"))

                        If dr1("xitn_0").ToString <> " " Then ParqueARetirar += CInt(dr1("macqty_0"))

                    Case "503"
                        ParqueAVencerCarros += CInt(dr1("macqty_0"))
                        ParqueTotal += CInt(dr1("macqty_0"))

                        If dr1("xitn_0").ToString <> " " Then ParqueARetirar += CInt(dr1("macqty_0"))

                    Case "511", "512", "522"
                        ParqueAVencerMangueras += CInt(dr1("macqty_0"))
                        ParqueTotal += CInt(dr1("macqty_0"))

                        If dr1("xitn_0").ToString <> " " Then ParqueARetirar += CInt(dr1("macqty_0"))

                End Select

            Else
                'Sumo los que vencen despues del período seleccionado
                Select Case dr1("tsicod_4").ToString
                    Case "501", "502", "521", "594", "503", "511", "512", "522"
                        ParqueTotal += CInt(dr1("macqty_0"))

                End Select

            End If

            'VISITA MENSUAL 992006
            'If dr1("macpdtcod_0").ToString = "992006" Then
            '    dr("VisitaMensual") = CInt(dr1("macqty_0"))
            'End If

            'CONTROL PERIODICO 992002
            If dr1("macpdtcod_0").ToString = "992002" Then
                dr("ControlPeriodico") = CInt(dr1("macqty_0"))
                dr("FechaControl") = CDate(dr1("datnext_0"))
            End If

        Next

        dr("ParqueTotal") = ParqueTotal
        dr("ParqueVencidoManuales") = ParqueVencidoManuales
        dr("ParqueVencidoCarros") = ParqueVencidoCarros
        dr("ParqueVencidoMangueras") = ParqueVencidoMangueras
        dr("ParqueAVencerManuales") = ParqueAVencerManuales
        dr("ParqueAVencerCarros") = ParqueAVencerCarros
        dr("ParqueAVencerMangueras") = ParqueAVencerMangueras

        dr.EndEdit()

    End Sub
    Private Sub Remito(ByVal cli As String, ByVal suc As String, ByVal dr As DataRow)
        Dim dv As New DataView(dt3)

        dv.RowFilter = "bpcord_0 = '" & cli & "' AND bpaadd_0 = '" & suc & "'"

        dr.BeginEdit()
        dr("TieneRemito") = IIf(dv.Count > 0, 1, 0)
        dr.EndEdit()

    End Sub
    Private Sub ParqueProcesado(ByVal cli As String, ByVal suc As String, ByVal dr As DataRow)
        Dim dv As New DataView(dt4)
        Dim dr1 As DataRow
        Dim Retirado As Integer = 0
        Dim Entregado As Integer = 0

        dv.RowFilter = "bpc_0 = '" & cli & "' AND bpaadd_0 = '" & suc & "'"

        For i = 0 To dv.Count - 1
            dr1 = CType(dv.Item(i), DataRowView).Row

            If CInt(dr1("zflgtrip_0")) = 5 Then
                Entregado += 1
            Else
                Retirado += 1
            End If
        Next i

        dr.BeginEdit()
        dr("Entregado") = Entregado
        dr("Retirado") = Retirado
        dr.EndEdit()

    End Sub
    Private Sub ParqueUnificar(ByVal cli As String, ByVal suc As String, ByVal dr As DataRow)
        Dim Cant As Integer = 0
        Dim FechaItn As Date
        Dim dIni As Date
        Dim dFin As Date
        Dim Unificacion As Integer

        'Sumo los vencimientos del mes actual
        Cant += CInt(dr("ParqueAVencerManuales"))
        Cant += CInt(dr("ParqueAVencerCarros"))
        Cant += CInt(dr("ParqueAVencerMangueras"))

        'Si no hay vencimientos en el mes actual no se calcula la unificacion
        If Cant = 0 Then
            dr.BeginEdit()
            dr("ParqueUnificar") = -1
            dr.EndEdit()
            Exit Sub

        End If

        Unificacion = CInt(dr("xunifi_0"))

        If Unificacion = 0 Then
            dr.BeginEdit()
            dr("ParqueUnificar") = -1
            dr.EndEdit()
            Exit Sub
        End If

        Unificacion = 12 \ Unificacion
        dIni = Fecha1
        dFin = Fecha2.AddDays(1)
        dIni = dIni.AddMonths(-1 * (Unificacion - 1))
        dFin = dFin.AddMonths(Unificacion - 1)

        'Si la fecha fin sobrepasa la fecha cobertura del contrato
        If dFin > CDate(dr("conenddat_0")).AddDays(1) Then
            dFin = CDate(dr("conenddat_0"))
            dFin = New Date(dFin.Year, dFin.Month, 1)
            dFin = dFin.AddMonths(1)
        End If

        'Busco la fechad de la última intervención
        FechaItn = FechaUltimaIntervencion(cli, suc)
        FechaItn = New Date(FechaItn.Year, FechaItn.Month, 1)
        FechaItn = FechaItn.AddMonths(-1)

        'Salto si aun falta para el proximo retiro segun la unificacion
        If FechaItn > dIni Then
            dr.BeginEdit()
            dr("ParqueUnificar") = -1
            dr.EndEdit()
            Exit Sub
        End If

        'Obtengo los vencimientos de la sucursal
        Dim dv As New DataView(dt2)

        dv.RowFilter = "bpcnum_0 = '" & cli & "' AND fcyitn_0 = '" & suc & "'"

        Cant = 0
        For i = 0 To dv.Count - 1
            Dim dr1 As DataRow = CType(dv.Item(i), DataRowView).Row

            If CDate(dr1("datnext_0")) >= Fecha1.AddMonths(1) And CDate(dr1("datnext_0")) < dFin Then

                Select Case dr1("tsicod_4").ToString
                    Case "501", "502", "521", "594", "503"
                        Cant += 1
                End Select

            End If
        Next

        dr.BeginEdit()
        dr("ParqueUnificar") = Cant
        dr.EndEdit()
    End Sub
    Private Sub btnConsultar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConsultar2.Click
        Dim dt As DataTable

        BtnConsultar2.Enabled = False
        Me.UseWaitCursor = True

        If dgv1.DataSource IsNot Nothing Then
            dt = CType(dgv1.DataSource, DataTable)
            dt.Clear()
        End If

        'AJUSTO EL RANGO DE FECHA DE CONSULTA
        Fecha1 = New Date(dtp.Value.Year, dtp.Value.Month, 1)
        Fecha2 = Fecha1.AddMonths(1)
        Fecha2 = Fecha2.AddDays(-1)

        Tab.SelectedTab = TabPage2

        Consulta2()
        Consulta3()
        Me.UseWaitCursor = False
        BtnConsultar2.Enabled = True
    End Sub
    Private Sub Consulta2()
        Dim Sql As String = ""
        Dim dt2 As New DataTable

        Sql = "SELECT dat_0,itn.num_0,bpc_0,bpcnam_0, bpaadd_0,add_0,cty_0,itmref_0, itmdes1_0,tqty_0 "
        Sql &= "FROM interven itn INNER JOIN "
        Sql &= "     yitndet itndet on ( itn.num_0 = itndet.num_0) RIGHT JOIN "
        Sql &= "     bpcustomer bpc on (itn.bpc_0 = bpc.bpcnum_0) INNER JOIN "
        Sql &= "     itmmaster itm on (itndet.itmref_0 = itm.itmref_0) "
        Sql &= "WHERE typ_0 = 'A1' and "
        Sql &= "      zflgtrip_0 in ('1','6') and "
        Sql &= "      itn.dat_0 <= :datfin and "
        Sql &= "      numlig_0 = 1000 and "
        Sql &= "      xsector_0 in ('ABO',' ') "
        Sql &= "ORDER BY dat_0"

        da = New OracleDataAdapter(Sql, cn)
        With da.SelectCommand.Parameters
            '.Add("datini", OracleType.DateTime).Value = Fecha1
            .Add("datfin", OracleType.DateTime).Value = Fecha2
        End With

        ColIntFecha.DataPropertyName = "dat_0"
        ColIntNumero.DataPropertyName = "num_0"
        ColItnCodigoCliente.DataPropertyName = "bpc_0"
        ColItnRazonSocial.DataPropertyName = "bpcnam_0"
        ColItnNroSuc.DataPropertyName = "bpaadd_0"
        ColItnDomicilio.DataPropertyName = "add_0"
        ColItnLocalidad.DataPropertyName = "cty_0"
        ColItnCodigo.DataPropertyName = "itmref_0"
        ColItnDescripcionCodigo.DataPropertyName = "itmdes1_0"
        ColItnCantidad.DataPropertyName = "tqty_0"

        da.Fill(dt2)
        da.Dispose()
        da = Nothing
        'Application.DoEvents()

        DgvIntervencion.DataSource = dt2



    End Sub
    Private Sub Consulta3()
        Dim Sql As String = ""
        Dim dt3 As New DataTable

        Sql = "select distinct(sd.sdhnum_0),dlvdat_0,sd.bpcord_0,bpcnam_0, sd.bpaadd_0, bpdaddlig_0,bpdcty_0,netwei_0,sum(qty_0) as qty_0, "
        Sql &= "(SELECT LANMES_0 FROM aplstd WHERE lanchp_0 = '2411' AND lan_0 = 'SPA' AND lannum_0 >= 0 AND lannum_0 = XFLGRTO_0) as estado from sdelivery sd   "
        Sql &= " inner join sdeliveryd sde on (sd.sdhnum_0 = sde.sdhnum_0) "
        Sql &= " inner join bpcustomer bpc on (sd.bpcord_0 = bpc.bpcnum_0) "
        Sql &= " where (credat_0 <= :datfin) and itmref_0 like ('651%')  and xsector_0 = 'ABO' "
        Sql &= " and sd.sdhnum_0 NOT IN (SELECT DISTINCT sdhnum_0 FROM sdeliveryd WHERE rtnqty_0 > 0)"
        Sql &= " group by sd.sdhnum_0,dlvdat_0,sd.bpcord_0,bpcnam_0, sd.bpaadd_0, bpdaddlig_0,bpdcty_0,netwei_0,XFLGRTO_0"
        da = New OracleDataAdapter(Sql, cn)
        With da.SelectCommand.Parameters
            '.Add("datini", OracleType.DateTime).Value = Fecha1
            .Add("datfin", OracleType.DateTime).Value = Fecha2
        End With

        ColRtoFecha.DataPropertyName = "dlvdat_0"
        ColRtoNroRemito.DataPropertyName = "sdhnum_0"
        ColRtoCodigoCliente.DataPropertyName = "bpcord_0"
        ColRtoRazonSocial.DataPropertyName = "bpcnam_0"
        ColRtoNroSucursal.DataPropertyName = "bpaadd_0"
        ColRtoDomicilio.DataPropertyName = "bpdaddlig_0"
        ColRtoLocalidad.DataPropertyName = "bpdcty_0"
        ColRtoKgTotales.DataPropertyName = "netwei_0"
        ColRtoCantTotalesInstalaciones.DataPropertyName = "qty_0"
        ColRtoEstado.DataPropertyName = "Estado"

        da.Fill(dt3)
        da.Dispose()
        da = Nothing
        'Application.DoEvents()

        DgvRemito.DataSource = dt3



    End Sub
    Private Sub FrmPlanillaAbonados_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AddHandler dgv1.RowPostPaint, AddressOf NumeracionGrillas
    End Sub
    Private Sub dgv1_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv1.CellDoubleClick
        Dim dv As DataView

        If e.RowIndex < 0 Then Exit Sub

        Dim dr As DataRow = CType(dgv1.Rows(e.RowIndex).DataBoundItem, DataRowView).Row

        lblInfo.Text = e.ColumnIndex.ToString

        Select Case e.ColumnIndex
            Case 15, 16
                dv = New DataView(dt4)
                dv.RowFilter = "bpc_0 = '" & dr("bpcnum_0").ToString & "' AND bpaadd_0 = '" & dr("bpaadd_0").ToString & "'"

            Case 20
                dv = New DataView(dt3)
                dv.RowFilter = "bpcord_0 = '" & dr("bpcnum_0").ToString & "' AND bpaadd_0 = '" & dr("bpaadd_0").ToString & "'"

            Case Else
                dv = New DataView(dt2)
                dv.RowFilter = "bpcnum_0 = '" & dr("bpcnum_0").ToString & "' AND fcyitn_0 = '" & dr("bpaadd_0").ToString & "'"

        End Select

        Dim f As New frmPlanillaAbonadosDetalle(dv)
        f.ShowDialog()
        f.Dispose()

    End Sub
    Private Function FechaUltimaIntervencion(ByVal bpc As String, ByVal suc As String) As Date
        Dim da As OracleDataAdapter
        Dim dt As New DataTable
        Dim sql As String
        Dim f As Date = #12/31/1599#
        Dim i As Integer

        sql = "select xrc.fecha_0 "
        sql &= "from xrutac xrc inner join xrutad xrd on (xrc.ruta_0 = xrd.ruta_0) "
        sql &= "	 inner join interven itn on (xrd.vcrnum_0 = itn.num_0) "
        sql &= "where itn.typ_0 = 'C1' and "
        sql &= "	  estado_0 = 3 and "
        sql &= "	  itn.bpc_0 = :bpc and "
        sql &= "	  itn.bpaadd_0 = :bpaadd and "
        sql &= "	  itn.xauto_0 = 2 "
        sql &= "order by xrc.fecha_0 desc"
        da = New OracleDataAdapter(sql, cn)
        da.SelectCommand.Parameters.Add("bpc", OracleType.VarChar).Value = bpc
        da.SelectCommand.Parameters.Add("bpaadd", OracleType.VarChar).Value = suc
        da.Fill(dt)
        da.Dispose()

        If dt.Rows.Count > 0 Then f = CDate(dt.Rows(0).Item(0))

        If f <> #12/31/1599# Then
            i = f.Day - 1
            i = i * (-1)
            f = f.AddDays(i)
        End If

        Return f

    End Function

End Class