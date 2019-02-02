Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.OracleClient

Public Class frmResolver

    Dim WithEvents itn As Intervencion

    'SUB
    Private Sub Actualizar()
        Dim Sql As String
        Dim da As OracleDataAdapter
        Dim dt As New DataTable

        'daInterven1
        'Sql = "SELECT num_0, typ_0, bpc_0, bpcnam_0, bpaadd_0, add_0, cty_0, tel_0, bpc.rep_0, yhdesde1_0, yhhasta1_0, yhdesde2_0, yhhasta2_0, xsector_0 "
        'Sql &= "FROM interven INNER JOIN bpcustomer bpc ON (bpc_0 = bpcnum_0) "
        'Sql &= "WHERE zflgtrip_0 = 7"
        Sql = "SELECT num_0, typ_0, bpc_0, bpcnam_0, bpaadd_0, add_0, cty_0, tel_0, bpc.rep_0, yhdesde1_0, yhhasta1_0, yhdesde2_0, yhhasta2_0, xsector_0 ,max(xrc.fecha_0) as fecha "
        Sql &= "FROM interven itn "
        Sql &= "INNER JOIN bpcustomer bpc ON (bpc_0 = bpcnum_0) "
        Sql &= "left join xrutad xrd on (itn.num_0 = xrd.vcrnum_0) "
        Sql &= "left join xrutac xrc on (xrd.ruta_0 = xrc.ruta_0) "
        Sql &= "WHERE zflgtrip_0 = 7 "
        Sql &= "group by num_0, typ_0, bpc_0, bpcnam_0, bpaadd_0, add_0, cty_0, tel_0, bpc.rep_0, yhdesde1_0, yhhasta1_0, yhdesde2_0, yhhasta2_0, xsector_0"

        da = New OracleDataAdapter(Sql, cn)

        Application.DoEvents()

        Try
            da.Fill(dt)
            dgv.DataSource = dt
            Filtrar()

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            da.Dispose()

        End Try

    End Sub
    Private Sub Filtrar()
        Dim drv As DataGridViewRow

        Application.DoEvents()

        Try
            dgv.CurrentCell = Nothing

            For Each drv In dgv.Rows
                drv.Visible = MostrarTipo(drv.Cells("colTipo").Value.ToString)
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub
    Private Sub ComboTipos()
        Dim dr As OracleDataReader
        Dim i As Integer
        Dim cmTipos As New OracleCommand("SELECT DISTINCT typ_0 FROM interven ORDER BY typ_0", cn)

        'Agrego los tipos al Combo
        dr = cmTipos.ExecuteReader
        While dr.Read
            clbTipos.Items.Add(dr("typ_0").ToString)
        End While
        dr.Close()

        'Tildo todos los items del combo
        For i = 0 To clbTipos.Items.Count - 1
            clbTipos.SetItemChecked(i, True)
        Next

    End Sub

    'FUNCTION
    Private Function MostrarTipo(ByVal Tipo As String) As Boolean
        Dim t As String

        With clbTipos
            For i = 0 To .CheckedItems.Count - 1
                t = .Items(i).ToString

                If Tipo = .CheckedItems(i).ToString Then Return True
            Next
        End With

        Return False

    End Function
    Private Function Reagendar(ByVal NroInterven As String) As Boolean
        Dim Sql As String
        Dim dt1 As New DataTable
        Dim dt2 As New DataTable
        Dim da1 As OracleDataAdapter
        Dim da2 As OracleDataAdapter
        Dim dr As DataRow

        Sql = "SELECT mac.macnum_0, cpnitmref_0, datnext_0, xitn_0, ydayfreq_0 "
        Sql &= "FROM (machines mac INNER JOIN ymacitm ymc ON (mac.macnum_0 = ymc.macnum_0)) INNER JOIN bomd bmd ON (macpdtcod_0 = itmref_0 AND ymc.cpnitmref_0 = bmd.cpnitmref_0) "
        Sql &= "WHERE bomalt_0 = 99 AND bomseq_0 = 10 AND macitntyp_0 = 1 AND mac.xitn_0 = :xitn_0"
        da1 = New OracleDataAdapter(Sql, cn)
        Sql = "UPDATE machines SET xitn_0 = :xitn_0 WHERE macnum_0 = :macnum_0"
        da1.UpdateCommand = New OracleCommand(Sql, cn)

        With da1
            .SelectCommand.Parameters.Add("xitn_0", OracleType.VarChar).Value = NroInterven

            Parametro(.UpdateCommand, "xitn_0", OracleType.VarChar, DataRowVersion.Current)
            Parametro(.UpdateCommand, "macnum_0", OracleType.VarChar, DataRowVersion.Original)
        End With

        da2 = New OracleDataAdapter("SELECT * FROM ymacitm WHERE macnum_0 = :macnum_0", cn)
        Sql = "UPDATE ymacitm SET datnext_0 = :datnext_0 WHERE macnum_0 = :macnum_0 AND cpnitmref_0 = :cpnitmref_0"
        da2.UpdateCommand = New OracleCommand(Sql, cn)

        With da2
            .SelectCommand.Parameters.Add("macnum_0", OracleType.VarChar)

            Parametro(.UpdateCommand, "datnext_0", OracleType.DateTime, DataRowVersion.Current)
            Parametro(.UpdateCommand, "macnum_0", OracleType.VarChar, DataRowVersion.Original)
            Parametro(.UpdateCommand, "cpnitmref_0", OracleType.VarChar, DataRowVersion.Original)
        End With

        Application.DoEvents()

        da1.Fill(dt1)

        If dt1.Rows.Count > 0 Then
            Sql = "Esta intervención tiene {1} vencimientos(s) de servicios.{0}{0}¿Desea reagendar los vencimientos?"
            Sql = String.Format(Sql, vbCrLf, dt1.Rows.Count.ToString)

            Application.DoEvents()

            Select Case MessageBox.Show(Sql, Me.Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                Case Windows.Forms.DialogResult.Yes
                    'Clono la tabla
                    dt2 = dt1.Clone

                    'Importo registros y borro marca de intervencion
                    For Each dr In dt1.Rows
                        dt2.ImportRow(dr)
                        dr.BeginEdit()
                        dr("xitn_0") = " "
                        dr.EndEdit()
                    Next

                    'Cambio fecha de vencimiento
                    For Each dr In dt2.Rows
                        dr.BeginEdit()

                        If dr("cpnitmref_0").ToString.StartsWith("45") Then
                            dr("datnext_0") = Date.Today.AddMonths(11)

                        Else
                            If CInt(dr("ydayfreq_0")) > 0 Then
                                dr("datnext_0") = Date.Today.AddDays(CInt(dr("ydayfreq_0")))
                            End If

                        End If
                        dr.EndEdit()
                    Next

                    'Actualizo los registros
                    da1.Update(dt1)
                    da2.Update(dt2)

                    Reagendar = True

                Case Windows.Forms.DialogResult.No
                    Reagendar = True

                Case Windows.Forms.DialogResult.Cancel
                    Reagendar = False

            End Select

        Else
            Reagendar = True

        End If

        da1.Dispose()
        da2.Dispose()
        dt1.Dispose()
        dt2.Dispose()

    End Function

    'EVENTOS
    Private Sub frmResolver_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            ComboTipos()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Evento Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()

        End Try

        'Enlace con la grilla
        colNum.DataPropertyName = "num_0"
        colTipo.DataPropertyName = "typ_0"
        colBpcnum.DataPropertyName = "bpc_0"
        colCliente.DataPropertyName = "bpcnam_0"
        colSuc.DataPropertyName = "bpaadd_0"
        colDireccion.DataPropertyName = "add_0"
        colCty.DataPropertyName = "cty_0"
        colTel.DataPropertyName = "tel_0"
        colHD1.DataPropertyName = "yhdesde1_0"
        colHD2.DataPropertyName = "yhdesde2_0"
        colHH1.DataPropertyName = "yhhasta1_0"
        colHH2.DataPropertyName = "yhhasta2_0"
        colRep.DataPropertyName = "rep_0"
        Sector.DataPropertyName = "xsector_0"
        fecha.DataPropertyName = "Fecha"

    End Sub
    Private Sub cmdActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdActualizar.Click
        Actualizar()
    End Sub
    Private Sub cmdFiltrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFiltrar.Click
        Filtrar()
    End Sub

    'EVENTOS MENU CONTEXTUAL
    Private Sub cmnu_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmnu.Opening
        If dgv.CurrentRow Is Nothing Then e.Cancel = True
    End Sub
    Private Sub mnuReactivar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReactivar.Click
        Dim Num As String
        Dim itn As New Intervencion(cn)

        'Obtengo numero de intervencion de la fila seleccionada
        Num = dgv.CurrentRow.Cells("colNum").Value.ToString

        'Abro la intervencion usando el objeto
        itn.Abrir(Num)

        Application.DoEvents()

        'Abro ventana de observaciones de intervencion
        Dim f As New frmObj(True)
        f.txtObj.Text = itn.Observaciones
        f.cboEstado.SelectedValue = itn.MotivoNoConformidad
        f.ShowDialog()

        If f.DialogResult = Windows.Forms.DialogResult.OK Then
            'Cambio el estado a la intervencion
            itn.Estado = 6

            'Actualizo las observaciones
            itn.Observaciones = f.txtObj.Text

            'Actualizo el motivo de rechazo
            itn.MotivoNoConformidad = f.cboEstado.SelectedValue.ToString

            'Si la solicitud es de retiro (no tiene remito) y no tiene el tilde de satisfecha
            'saco tilde de efectuado y cambio la fecha de inicio/fin de la ITN
            If itn.Remito = " " AndAlso Not itn.SolicitudSatisfecha Then
                itn.Efectuado = False
                itn.FechaInicio = Date.Today.AddDays(-1)
                itn.FechaFin = Date.Today.AddDays(-1)
            End If

            itn.Grabar()

            MessageBox.Show("La intervención fue reactivada", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            Actualizar()

        End If

        f.Dispose()

    End Sub
    Private Sub mnuCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCerrar.Click
        Dim num As String
        itn = New Intervencion(cn)

        'Obtengo numero de intervencion de la fila seleccionada
        num = dgv.CurrentRow.Cells("colNum").Value.ToString

        'Abro la intervencion usando el objeto
        itn.Abrir(num)

        Application.DoEvents()

        'Abro ventana de observaciones de intervencion
        Dim f As New frmObj(True)
        f.txtObj.Text = itn.Observaciones
        f.cboEstado.SelectedValue = itn.MotivoNoConformidad
        f.ShowDialog()

        'Actualizo el motivo de rechazo
        itn.MotivoNoConformidad = f.cboEstado.SelectedValue.ToString

        If f.DialogResult = Windows.Forms.DialogResult.OK Then
            'Pongo intervencion en estado Cerrada y tildes efectuado y satisfecho, pongo obs
            itn.Estado = 8
            itn.Efectuado = True
            itn.SolicitudSatisfecha = True
            itn.Observaciones = f.txtObj.Text
            itn.Grabar()

            If Not itn.Cliente.EsAbonado Then
                With itn.SolicitudAsociada
                    .CerrarSolicitud()
                    .Grabar()
                End With
            End If

            MessageBox.Show("La intervención fue cerrada", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Actualizar()

        End If

        f.Dispose()

    End Sub
    Private Sub mnuVerDocumento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuVerDocumento.Click
        Dim rpt As New ReportDocument
        Dim f As frmCrystal
        Dim t As String = dgv.CurrentRow.Cells("colNum").Value.ToString

        Try
            If t.StartsWith("DNY") Or t.StartsWith("MON") Then
                rpt.Load(RPTX3 & "BONLIV.rpt")
                rpt.SetParameterValue("livraisondeb", t)
                rpt.SetParameterValue("livraisonfin", t)

            Else
                rpt.Load(RPTX3 & "itn1.rpt")
                rpt.SetParameterValue("ITN", t)
                rpt.SetParameterValue("X3USR", usr.Codigo)

            End If

            f = New frmCrystal(rpt)
            f.MdiParent = Me.ParentForm
            f.Show()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub
    Private Sub mnuHistorial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuHistorial.Click
        Dim rpt As New ReportDocument
        Dim f As frmCrystal

        Try
            rpt.Load(RPTX3 & "xrutaitn.rpt")
            rpt.SetParameterValue("itn", dgv.CurrentRow.Cells("colNum").Value.ToString)

            f = New frmCrystal(rpt)
            f.MdiParent = Me.ParentForm
            f.Show()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            rpt.Close()
            rpt.Dispose() : rpt = Nothing

        End Try
    End Sub

    'EVENTS
    Private Sub itn_ParquesMarcados(ByVal sender As Object, ByVal e As Intervencion.ParquesEvenArgs) Handles itn.ParquesMarcados
        Dim txt As String = "Hay {0} parque(s) afectados por esta intervención. ¿Reprograma los vencimientos?"
        txt = String.Format(txt, e.Series.Count.ToString)

        If MessageBox.Show(txt, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
            Dim mac As New Parque(cn)

            Application.DoEvents()

            For Each txt In e.Series
                mac.Abrir(txt)

                If mac.Servicio.Codigo.StartsWith("45") Then
                    'Agregar 11 meses
                    mac.VtoCarga = Date.Today.AddMonths(11)

                Else
                    'sumar frecuencia
                    mac.VtoCarga = Date.Today.AddDays(mac.FrecuenciaRecarga)

                End If

                mac.MarcaIntervencion = " "
                mac.Grabar()

            Next
        End If

    End Sub

End Class