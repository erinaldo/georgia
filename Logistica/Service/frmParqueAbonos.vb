Imports System.Data.OracleClient

Public Class frmParqueAbonos
    Private daSectores As OracleDataAdapter
    Private dtSectores As New DataTable
    Private daPuestos As OracleDataAdapter
    Private WithEvents dtPuestos As New DataTable

    Private ds As New DataSet

    Private Sub Adaptadores()
        Dim Sql As String

        Sql = "SELECT * FROM xsectores WHERE bpcnum_0 = :bpcnum_0 AND fcyitn_0 = :fcyitn_0 ORDER BY nombre_0"
        daSectores = New OracleDataAdapter(Sql, cn)
        daSectores.SelectCommand.Parameters.Add("bpcnum_0", OracleType.VarChar)
        daSectores.SelectCommand.Parameters.Add("fcyitn_0", OracleType.VarChar)

        daSectores.InsertCommand = New OracleCommandBuilder(daSectores).GetInsertCommand
        daSectores.UpdateCommand = New OracleCommandBuilder(daSectores).GetUpdateCommand
        daSectores.DeleteCommand = New OracleCommandBuilder(daSectores).GetDeleteCommand

        Sql = "SELECT x.*, macpdtcod_0, macdes_0, ynrocil_0, EXTRACT(YEAR FROM yfabdat_0) AS yfabdat_0,"
        Sql &= "	   (SELECT datnext_0 FROM (machines mac2 INNER JOIN ymacitm ymc ON (mac2.macnum_0 = ymc.macnum_0)) INNER JOIN bomd bod ON (ymc.cpnitmref_0 = bod.cpnitmref_0 AND macpdtcod_0 = itmref_0) WHERE mac2.macnum_0 = mac.macnum_0 AND bomalt_0 = 99 AND bomseq_0 = 10) AS vto, "
        Sql &= "	   (SELECT datnext_0 FROM (machines mac2 INNER JOIN ymacitm ymc ON (mac2.macnum_0 = ymc.macnum_0)) INNER JOIN bomd bod ON (ymc.cpnitmref_0 = bod.cpnitmref_0 AND macpdtcod_0 = itmref_0) WHERE mac2.macnum_0 = mac.macnum_0 AND bomalt_0 = 99 AND bomseq_0 = 20) AS ph "
        Sql &= "FROM xpuestos x LEFT JOIN machines mac ON (x.macnum_0 = mac.macnum_0) "
        Sql &= "WHERE sector_0 IN (SELECT regid_0 FROM xsectores WHERE bpcnum_0 = :bpcnum_0 AND fcyitn_0 = :fcyitn_0)"

        daPuestos = New OracleDataAdapter(Sql, cn)
        daPuestos.SelectCommand.Parameters.Add("bpcnum_0", OracleType.VarChar)
        daPuestos.SelectCommand.Parameters.Add("fcyitn_0", OracleType.VarChar)

        Sql = "UPDATE xpuestos "
        Sql &= "SET sector_0 = :sector_0, puesto_0 = :puesto_0, tipo_0 = :tipo_0, baliza_0 = :baliza_0, soporte_0 = :soporte_0, gabinete_0 = :gabinete_0, "
        Sql &= "cartel_0 = :cartel_0, tarjeta_0 = :tarjeta_0, lanza_0 = :lanza_0, pico_0 = :pico_0, llave_0 = :llave_0, "
        Sql &= "vidrio_0 = :vidrio_0, valvula_0 = :valvula_0, macnum_0 = :macnum_0, obs_0 = :obs_0, estado_0 = :estado_0, fecha_0 = :fecha_0 "
        Sql &= "WHERE regid_0 = :regid_0"
        daPuestos.UpdateCommand = New OracleCommand(Sql, cn)

        Sql = "INSERT INTO xpuestos  (regid_0, sector_0, puesto_0, tipo_0, baliza_0, soporte_0, gabinete_0, cartel_0, tarjeta_0, lanza_0, pico_0, llave_0, vidrio_0, valvula_0, macnum_0, estado_0, obs_0, fecha_0) "
        Sql &= "VALUES              (:regid_0,:sector_0,:puesto_0,:tipo_0,:baliza_0,:soporte_0,:gabinete_0,:cartel_0,:tarjeta_0,:lanza_0,:pico_0,:llave_0,:vidrio_0,:valvula_0,:macnum_0,:estado_0,:obs_0,:fecha_0)"
        daPuestos.InsertCommand = New OracleCommand(Sql, cn)

        Sql = "DELETE FROM xpuestos WHERE regid_0 = :regid_0"
        daPuestos.DeleteCommand = New OracleCommand(Sql, cn)

        With daPuestos
            Parametro(.UpdateCommand, "sector_0", OracleType.Number, DataRowVersion.Current)
            Parametro(.UpdateCommand, "puesto_0", OracleType.VarChar, DataRowVersion.Current)
            Parametro(.UpdateCommand, "tipo_0", OracleType.VarChar, DataRowVersion.Current)
            Parametro(.UpdateCommand, "baliza_0", OracleType.VarChar, DataRowVersion.Current)
            Parametro(.UpdateCommand, "soporte_0", OracleType.VarChar, DataRowVersion.Current)
            Parametro(.UpdateCommand, "gabinete_0", OracleType.VarChar, DataRowVersion.Current)
            Parametro(.UpdateCommand, "cartel_0", OracleType.VarChar, DataRowVersion.Current)
            Parametro(.UpdateCommand, "tarjeta_0", OracleType.VarChar, DataRowVersion.Current)
            Parametro(.UpdateCommand, "lanza_0", OracleType.VarChar, DataRowVersion.Current)
            Parametro(.UpdateCommand, "pico_0", OracleType.VarChar, DataRowVersion.Current)
            Parametro(.UpdateCommand, "llave_0", OracleType.VarChar, DataRowVersion.Current)
            Parametro(.UpdateCommand, "vidrio_0", OracleType.VarChar, DataRowVersion.Current)
            Parametro(.UpdateCommand, "valvula_0", OracleType.VarChar, DataRowVersion.Current)
            Parametro(.UpdateCommand, "macnum_0", OracleType.VarChar, DataRowVersion.Current)
            Parametro(.UpdateCommand, "obs_0", OracleType.VarChar, DataRowVersion.Current)
            Parametro(.UpdateCommand, "estado_0", OracleType.VarChar, DataRowVersion.Current)
            Parametro(.UpdateCommand, "fecha_0", OracleType.DateTime, DataRowVersion.Current)
            Parametro(.UpdateCommand, "regid_0", OracleType.Number, DataRowVersion.Original)

            Parametro(.InsertCommand, "regid_0", OracleType.Number, DataRowVersion.Current)
            Parametro(.InsertCommand, "sector_0", OracleType.Number, DataRowVersion.Current)
            Parametro(.InsertCommand, "puesto_0", OracleType.VarChar, DataRowVersion.Current)
            Parametro(.InsertCommand, "tipo_0", OracleType.VarChar, DataRowVersion.Current)
            Parametro(.InsertCommand, "baliza_0", OracleType.VarChar, DataRowVersion.Current)
            Parametro(.InsertCommand, "soporte_0", OracleType.VarChar, DataRowVersion.Current)
            Parametro(.InsertCommand, "gabinete_0", OracleType.VarChar, DataRowVersion.Current)
            Parametro(.InsertCommand, "cartel_0", OracleType.VarChar, DataRowVersion.Current)
            Parametro(.InsertCommand, "tarjeta_0", OracleType.VarChar, DataRowVersion.Current)
            Parametro(.InsertCommand, "lanza_0", OracleType.VarChar, DataRowVersion.Current)
            Parametro(.InsertCommand, "pico_0", OracleType.VarChar, DataRowVersion.Current)
            Parametro(.InsertCommand, "llave_0", OracleType.VarChar, DataRowVersion.Current)
            Parametro(.InsertCommand, "vidrio_0", OracleType.VarChar, DataRowVersion.Current)
            Parametro(.InsertCommand, "valvula_0", OracleType.VarChar, DataRowVersion.Current)
            Parametro(.InsertCommand, "macnum_0", OracleType.VarChar, DataRowVersion.Current)
            Parametro(.InsertCommand, "obs_0", OracleType.VarChar, DataRowVersion.Current)
            Parametro(.InsertCommand, "estado_0", OracleType.VarChar, DataRowVersion.Current)
            Parametro(.InsertCommand, "fecha_0", OracleType.DateTime, DataRowVersion.Current)

            Parametro(.DeleteCommand, "regid_0", OracleType.Number, DataRowVersion.Original)
        End With

    End Sub
    Private Sub AbrirCliente()
        Dim da As OracleDataAdapter
        Dim sql As String
        Dim dt As DataTable

        'Busco datos cliente
        sql = "SELECT bpcnam_0 FROM bpcustomer WHERE bpcnum_0 = '" & txtCliente.Text & "'"
        da = New OracleDataAdapter(sql, cn)
        dt = New DataTable
        da.Fill(dt)
        da.Dispose()

        If dt.Rows.Count = 0 Then
            MessageBox.Show("Cliente no encontrado", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtCliente.Focus()
            dt.Dispose()
            Exit Sub
        Else
            txtNombre.Text = dt.Rows(0).Item("bpcnam_0").ToString
            txtCliente.Tag = txtCliente.Text
            dt.Dispose()
        End If

        'Cargo todas las sucursales
        sql = "SELECT bpaadd_0, bpaaddlig_0, cty_0, bpaadd_0 || ' - ' ||  bpaaddlig_0 || '(' || cty_0 || ') ' AS direccion "
        sql &= "FROM bpaddress "
        sql &= "WHERE bpanum_0 = '" & txtCliente.Tag.ToString & "'"
        sql &= "ORDER BY bpaadd_0"

        da = New OracleDataAdapter(sql, cn)

        If cboSuc.DataSource Is Nothing Then
            dt = New DataTable

        Else
            dt = CType(cboSuc.DataSource, DataTable)
            dt.Rows.Clear()

            cboSuc.DataSource = Nothing

        End If

        da.Fill(dt)
        da.Dispose()

        cboSuc.DataSource = dt

        With cboSuc
            .ValueMember = "bpaadd_0"
            .DisplayMember = "direccion"
        End With

        dgvSectores.Enabled = True
        dgvPuestos.Enabled = True

    End Sub
    Private Sub frmParqueAbonos2_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If ds.HasChanges Then
            Dim txt As String

            txt = "No se han guardados los cambios" & vbCrLf & vbCrLf
            txt &= "¿Guarda antes de salir?"

            Select Case MessageBox.Show(txt, Me.Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3)
                Case Windows.Forms.DialogResult.Yes
                    btnRegistrar_Click(Nothing, Nothing)
                    e.Cancel = False

                Case Windows.Forms.DialogResult.No
                    e.Cancel = False

                Case Windows.Forms.DialogResult.Cancel
                    e.Cancel = True

            End Select
        End If
    End Sub
    Private Sub frmParqueAbonos2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Adaptadores()

        AddHandler dgvPuestos.RowPostPaint, AddressOf NumeracionGrillas
        AddHandler dgvSectores.RowPostPaint, AddressOf NumeracionGrillas

        ds.Tables.Add(dtPuestos)

        'EliminarSectoresSueltos()

    End Sub
    Private Sub cboSuc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSuc.SelectedIndexChanged
        If cboSuc.SelectedValue Is Nothing Then Exit Sub

        With daSectores.SelectCommand
            .Parameters("bpcnum_0").Value = txtCliente.Tag.ToString
            .Parameters("fcyitn_0").Value = cboSuc.SelectedValue.ToString
        End With
        dtSectores.Clear()
        dtSectores.Clear()
        daSectores.Fill(dtSectores)

        With daPuestos.SelectCommand
            .Parameters("bpcnum_0").Value = txtCliente.Tag.ToString
            .Parameters("fcyitn_0").Value = cboSuc.SelectedValue.ToString
        End With
        dtPuestos.Clear()
        dtPuestos.Clear()
        daPuestos.Fill(dtPuestos)

        'Enlace con la grilla
        If dgvSectores.DataSource Is Nothing Then
            col1RegID.DataPropertyName = "regid_0"
            col1Cliente.DataPropertyName = "bpcnum_0"
            col1Sucursal.DataPropertyName = "fcyitn_0"
            col1Sector.DataPropertyName = "nombre_0"

            dgvSectores.DataSource = dtSectores
        End If

        'Enlace Puestos
        If dgvPuestos.DataSource Is Nothing Then
            'Enlace de la grilla de puestos
            col2Regid.DataPropertyName = "regid_0"

            With col2Sector
                .DataPropertyName = "sector_0"
                .DataSource = dtSectores
                .ValueMember = "regid_0"
                .DisplayMember = "nombre_0"
            End With

            col2Puesto.DataPropertyName = "puesto_0"
            EnlazarComboTipo(col2Tipo, "tipo_0")
            col2Serie.DataPropertyName = "macnum_0"
            col2Articulo.DataPropertyName = "macpdtcod_0"
            col2Equipo.DataPropertyName = "macdes_0"
            col2Cilindro.DataPropertyName = "ynrocil_0"
            col2Fab.DataPropertyName = "yfabdat_0"
            col2Vto1.DataPropertyName = "vto"
            col2Ph.DataPropertyName = "ph"

            EnlazarCombo(col2Baliza, "baliza_0")
            EnlazarCombo(col2Soporte, "soporte_0")
            EnlazarCombo(col2Gabinete, "gabinete_0")
            EnlazarCombo(col2Cartel, "cartel_0")
            EnlazarCombo(col2Tarjeta, "tarjeta_0")
            EnlazarCombo(col2Lanza, "lanza_0")
            EnlazarCombo(col2Pico, "pico_0")
            EnlazarCombo(col2Llave, "llave_0")
            EnlazarCombo(col2Vidrio, "vidrio_0")
            EnlazarCombo(col2Valvula, "valvula_0")
            EnlazarComboEstado(col2Estado, "estado_0")
            col2Obs.DataPropertyName = "obs_0"
            col2Fecha.DataPropertyName = "fecha_0"

            dgvPuestos.DataSource = dtPuestos
        End If

    End Sub
    Private Sub EnlazarCombo(ByVal cbo As DataGridViewComboBoxColumn, ByVal Campo As String)
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim IDs(4) As String
        Dim Txt(4) As String

        IDs(0) = " " : Txt(0) = " "
        IDs(1) = "T" : Txt(1) = "TIENE"
        IDs(2) = "F" : Txt(2) = "FALTA"
        IDs(3) = "C" : Txt(3) = "CAMBIAR"
        IDs(4) = "/" : Txt(4) = "NO CORRESPONDE"

        dt.Columns.Add("id", GetType(String)).MaxLength = 1
        dt.Columns.Add("desc", GetType(String)).MaxLength = 15

        For i = LBound(Txt) To UBound(Txt)
            dr = dt.NewRow
            dr(0) = IDs(i)
            dr(1) = IDs(i) 'Txt(i)
            dt.Rows.Add(dr)
        Next
        dt.AcceptChanges()

        cbo.DataSource = dt
        cbo.ValueMember = "id"
        cbo.DisplayMember = "desc"
        cbo.DataPropertyName = Campo
    End Sub
    Private Sub EnlazarComboEstado(ByVal cbo As DataGridViewComboBoxColumn, ByVal Campo As String)
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim IDs(8) As String
        Dim Txt(8) As String

        IDs(0) = " " : Txt(0) = " "
        IDs(1) = "00" : Txt(1) = "PUESTO VACIO"
        IDs(2) = "01" : Txt(2) = "EQUIPO USADO"
        IDs(3) = "02" : Txt(3) = "EQUIPO DESPRESURIZADO"
        IDs(4) = "03" : Txt(4) = "HAY UN SUSTITUTO"
        IDs(5) = "04" : Txt(5) = "SE RETIRO Y DEJO SUSTITUTO"
        IDs(6) = "05" : Txt(6) = "PUESTO NO ACCESIBLE"
        IDs(7) = "06" : Txt(7) = "PUESTO NO UBICADO"
        IDs(8) = "07" : Txt(8) = "LAVA OJOS A REPARAR"

        dt.Columns.Add("id", GetType(String)).MaxLength = 2
        dt.Columns.Add("desc", GetType(String)).MaxLength = 30

        For i = LBound(Txt) To UBound(Txt)
            dr = dt.NewRow
            dr("id") = IDs(i)
            dr("desc") = Txt(i)
            dt.Rows.Add(dr)
        Next
        dt.AcceptChanges()

        cbo.DataSource = dt
        cbo.ValueMember = "id"
        cbo.DisplayMember = "desc"
        cbo.DataPropertyName = Campo
    End Sub
    Private Sub EnlazarComboTipo(ByVal cbo As DataGridViewComboBoxColumn, ByVal Campo As String)
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim IDs(2) As String
        Dim Txt(2) As String

        IDs(0) = "0" : Txt(0) = "EXTINTOR"
        IDs(1) = "1" : Txt(1) = "HIDRANTE"
        IDs(2) = "2" : Txt(2) = "LAVA OJOS"

        dt.Columns.Add("id", GetType(String)).MaxLength = 2
        dt.Columns.Add("desc", GetType(String)).MaxLength = 30

        For i = LBound(Txt) To UBound(Txt)
            dr = dt.NewRow
            dr("id") = IDs(i)
            dr("desc") = Txt(i)
            dt.Rows.Add(dr)
        Next
        dt.AcceptChanges()

        cbo.DataSource = dt
        cbo.ValueMember = "id"
        cbo.DisplayMember = "desc"
        cbo.DataPropertyName = Campo
    End Sub
    Private Function ProximoValorIdentidad(ByVal Tabla As String) As Long
        Dim da As OracleDataAdapter
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim Sql As String
        Dim Valor As Long = 1

        If Tabla = "xsectores" Then
            Sql = "SELECT max(regid_0) AS valor FROM xsectores"

        Else
            Sql = "SELECT max(regid_0) AS valor FROM xpuestos"

        End If

        da = New OracleDataAdapter(Sql, cn)

        Try
            da.Fill(dt)
            dr = dt.Rows(0)

            If Not IsDBNull(dr(0)) Then
                Valor = CLng(dr(0)) + 1
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            da.Dispose()
            dt.Dispose()

        End Try

        Return Valor

    End Function
    Private Sub EvitarCamposNulos(ByVal Campo As String, ByVal dr As DataRow)
        If IsDBNull(Campo) OrElse dr(Campo).ToString = "" Then
            dr.BeginEdit()
            dr(Campo) = " "
            dr.EndEdit()
        End If
    End Sub
#Region "MENU CONTEXTUAL - Sectores"
    Private Sub cmenuSectores_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmenuSectores.Opening

    End Sub
    Private Sub mnuSectorNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSectorNuevo.Click
        Dim dr As DataRow
        Dim txt As String

        txt = InputBox("Escriba el nombre del nuevo sector", Me.Text)
        txt = txt.Trim.ToUpper

        If txt <> "" Then
            dr = dtSectores.NewRow
            dr("regid_0") = ProximoValorIdentidad("xsectores")
            dr("bpcnum_0") = txtCliente.Tag.ToString
            dr("fcyitn_0") = cboSuc.SelectedValue.ToString
            dr("nombre_0") = txt
            dtSectores.Rows.Add(dr)

            Try
                daSectores.Update(dtSectores)

            Catch ex As Exception
                MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End If

    End Sub

    Private Sub mnuSectorEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSectorEditar.Click
        Dim dr As DataRow = CType(dgvSectores.SelectedRows(0).DataBoundItem, DataRowView).Row
        Dim txt As String = dr("nombre_0").ToString

        txt = InputBox("Escriba el nuevo nombre del sector", Me.Text, txt)
        txt = txt.Trim.ToUpper

        If txt <> "" Then
            dr.BeginEdit()
            dr("nombre_0") = txt
            dr.EndEdit()

            Try
                daSectores.Update(dtSectores)
                dgvPuestos.Refresh()

            Catch ex As Exception
                MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End If

    End Sub

    Private Sub mnuSectorEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSectorEliminar.Click
        Dim dr As DataRow = CType(dgvSectores.SelectedRows(0).DataBoundItem, DataRowView).Row
        Dim txt As String = dr("nombre_0").ToString
        Dim Usado As Boolean = False


        'Verifico que el sector no se esté usando en algun puesto
        For Each dr2 As DataRow In dtPuestos.Rows
            If CLng(dr2("sector_0")) = CLng(dr("regid_0")) Then
                Usado = True
                Exit For
            End If
        Next

        'Pido confirmacion para eliminar el sector
        txt = "¿Confirma la eliminacion del puesto: " & txt & "?"
        If Usado Then
            txt = "No se puede eliminar un sector que está siendo usado por un puesto" & vbCrLf & vbCrLf
            MessageBox.Show(txt, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)

        Else

            If MessageBox.Show(txt, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                Try
                    dr.Delete()
                    daSectores.Update(dtSectores)

                Catch ex As Exception
                    MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

                End Try
            End If

        End If

    End Sub
#End Region
#Region "MENU CONTEXTUAL - Puestos"
    Private Sub mnuNuevoEquipo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNuevoEquipo.Click
        Dim f As frmParque
        Dim dr As DataRow = CType(dgvPuestos.CurrentRow.DataBoundItem, DataRowView).Row
        Dim mac As New Parque(cn)

        mac.Nuevo(txtCliente.Tag.ToString, cboSuc.SelectedValue.ToString)

        f = New frmParque(mac)
        f.ShowDialog()

        If f.DialogResult = Windows.Forms.DialogResult.OK Then
            dr.BeginEdit()
            dr("macnum_0") = mac.Serie
            dr("macpdtcod_0") = mac.ArticuloCodigo
            dr("macdes_0") = mac.ArticuloDescripcion
            dr("ynrocil_0") = mac.Cilindro
            dr("yfabdat_0") = mac.FabricacionCorto
            dr("vto") = mac.VtoCarga
            If mac.TienePh Then
                dr("ph") = mac.VtoPH
            Else
                dr("ph") = DBNull.Value
            End If
            If dr("estado_0").ToString = "00" Then dr("estado_0") = " "
            dr.EndEdit()
        End If

    End Sub
    Private Sub VaciarPuesto(ByVal dr As DataRow)
        dr.BeginEdit()
        dr("macnum_0") = " "
        dr("macpdtcod_0") = DBNull.Value
        dr("macdes_0") = DBNull.Value
        dr("yfabdat_0") = DBNull.Value
        dr("ynrocil_0") = DBNull.Value
        dr("vto") = DBNull.Value
        dr("ph") = DBNull.Value
        dr("estado_0") = "00"
        dr.EndEdit()
    End Sub
    Private Sub mnuPuestoVacio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPuestoVacio.Click
        If dgvPuestos.CurrentRow Is Nothing Then Exit Sub 'salgo si no hay fila seleccionada

        Dim dr As DataRow = CType(dgvPuestos.CurrentRow.DataBoundItem, DataRowView).Row

        If MessageBox.Show("¿Confirma marcar este puesto como vacío?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            VaciarPuesto(dr)
        End If

    End Sub
    Private Sub mnuAsociarEquipo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAsociarEquipo.Click
        Dim dt As DataTable

        If dgvPuestos.CurrentRow Is Nothing Then Exit Sub 'salgo si no hay fila seleccionada

        Dim f As New frmParqueCliente(txtCliente.Tag.ToString, cboSuc.SelectedValue.ToString)
        Dim dr As DataRow

        f.ShowDialog()

        If f.DialogResult = Windows.Forms.DialogResult.OK Then
            Dim mac As New Parque(cn)

            dr = CType(dgvPuestos.CurrentRow.DataBoundItem, DataRowView).Row

            If mac.Abrir(f.Tag.ToString) Then
                'Elimino el parque de otro puesto
                dt = CType(dgvPuestos.DataSource, DataTable)
                For Each dr2 As DataRow In dt.Rows
                    If dr2("macnum_0").ToString = mac.Serie Then
                        VaciarPuesto(dr2)
                    End If
                Next

                dr.BeginEdit()
                dr("macnum_0") = mac.Serie
                dr("macpdtcod_0") = mac.ArticuloCodigo
                dr("macdes_0") = mac.ArticuloDescripcion
                dr("ynrocil_0") = mac.Cilindro
                dr("yfabdat_0") = mac.FabricacionCorto
                dr("vto") = mac.VtoCarga
                If mac.TienePh Then
                    dr("ph") = mac.VtoPH
                Else
                    dr("ph") = DBNull.Value
                End If
                If dr("estado_0").ToString = "00" Then dr("estado_0") = " "
                dr.EndEdit()

                'Si el equipo era de otra sucursal, lo paso a la sucursal actual
                If cboSuc.SelectedValue.ToString <> mac.SucursalNumero Then
                    mac.SucursalNumero = cboSuc.SelectedValue.ToString
                    mac.Grabar()
                End If

            End If
        End If
        f.Dispose()

    End Sub
#End Region
#Region "BOTONES"
    Private Sub btnAbrir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbrir.Click
        AbrirCliente()
    End Sub
    Private Sub btnSectores_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSectores.Click
        If CInt(btnSectores.Tag) = 0 Then
            SplitContainer1.Panel1Collapsed = False
            btnSectores.Tag = 1
            btnSectores.Text = "Ocultar Sectores"
        Else
            SplitContainer1.Panel1Collapsed = True
            btnSectores.Tag = 0
            btnSectores.Text = "Mostrar Sectores"
        End If
    End Sub
    Private Sub btnRegistrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegistrar.Click
        Dim dr As DataRow
        Dim i As Long = 0

        'Miro los registros nuevos
        For Each dr In dtPuestos.Rows
            Select Case dr.RowState
                Case DataRowState.Added
                    'Busco el siguiente valor de identidad
                    If i = 0 Then
                        i = ProximoValorIdentidad("xpuestos")
                    Else
                        i += 1
                    End If

                    If IsDBNull(dr("sector_0")) Then
                        MessageBox.Show("Falta seleccionar sector", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    End If
                    If IsDBNull(dr("tipo_0")) Then
                        MessageBox.Show("Falta seleccionar tipo de puesto", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    End If
                    dr.BeginEdit()
                    dr("regid_0") = i 'Asigno el valor de identidad
                    If IsDBNull(dr("puesto_0")) OrElse dr("puesto_0").ToString = "" Then dr("puesto_0") = " "
                    If IsDBNull(dr("macnum_0")) OrElse dr("macnum_0").ToString = "" Then dr("macnum_0") = " "
                    If IsDBNull(dr("baliza_0")) Then dr("baliza_0") = " "
                    If IsDBNull(dr("soporte_0")) Then dr("soporte_0") = " "
                    If IsDBNull(dr("gabinete_0")) Then dr("gabinete_0") = " "
                    If IsDBNull(dr("cartel_0")) Then dr("cartel_0") = " "
                    If IsDBNull(dr("tarjeta_0")) Then dr("tarjeta_0") = " "
                    If IsDBNull(dr("lanza_0")) Then dr("lanza_0") = " "
                    If IsDBNull(dr("pico_0")) Then dr("pico_0") = " "
                    If IsDBNull(dr("llave_0")) Then dr("llave_0") = " "
                    If IsDBNull(dr("vidrio_0")) Then dr("vidrio_0") = " "
                    If IsDBNull(dr("valvula_0")) Then dr("valvula_0") = " "
                    If IsDBNull(dr("estado_0")) Then dr("estado_0") = " "
                    If IsDBNull(dr("obs_0")) OrElse dr("obs_0").ToString = "" Then dr("obs_0") = " "
                    dr("fecha_0") = #12/31/1599#
                    dr.EndEdit()

                Case DataRowState.Modified
                    If IsDBNull(dr("puesto_0")) OrElse dr("puesto_0").ToString = "" Then dr("puesto_0") = " "
                    If IsDBNull(dr("macnum_0")) OrElse dr("macnum_0").ToString = "" Then dr("macnum_0") = " "
                    If IsDBNull(dr("obs_0")) OrElse dr("obs_0").ToString = "" Then dr("obs_0") = " "
                    If IsDBNull(dr("fecha_0")) Then dr("fecha_0") = #12/31/1599#

            End Select
        Next


        Try
            daPuestos.Update(dtPuestos)

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        btnRegistrar.Enabled = ds.HasChanges

    End Sub
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        dtPuestos.RejectChanges()
        btnRegistrar.Enabled = ds.HasChanges
    End Sub
#End Region
    Private Sub dgvPuestos_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPuestos.CellDoubleClick
        If e.RowIndex < 0 Then Exit Sub
        If e.ColumnIndex < 0 Then Exit Sub

        If dgvPuestos.Rows(e.RowIndex).DataBoundItem Is Nothing Then Exit Sub
        If dgvPuestos.Columns(e.ColumnIndex).Name <> "col2Equipo" Then Exit Sub

        Dim dr As DataRow = CType(dgvPuestos.Rows(e.RowIndex).DataBoundItem, DataRowView).Row
        Dim mac As New Parque(cn)

        If dr("macnum_0").ToString.Trim = "" Then Exit Sub

        If mac.Abrir(dr("macnum_0").ToString) Then
            Dim f As New frmParque(mac)
            f.ShowDialog()

            If f.DialogResult = Windows.Forms.DialogResult.OK Then
                dr.BeginEdit()
                dr("macpdtcod_0") = mac.ArticuloCodigo
                dr("macdes_0") = mac.ArticuloDescripcion
                dr("ynrocil_0") = mac.Cilindro
                dr("yfabdat_0") = mac.FabricacionCorto
                dr("vto") = mac.VtoCarga
                If mac.TienePh Then
                    dr("ph") = mac.VtoPH
                Else
                    dr("ph") = DBNull.Value
                End If
                dr.EndEdit()

            End If

        End If
    End Sub
    Private Sub dtPuestos_RowChanged(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs) Handles dtPuestos.RowChanged
        btnRegistrar.Enabled = ds.HasChanges
    End Sub
    Private Sub dtPuestos_RowDeleted(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs) Handles dtPuestos.RowDeleted
        btnRegistrar.Enabled = ds.HasChanges
    End Sub
    Private Sub dtPuestos_TableNewRow(ByVal sender As Object, ByVal e As System.Data.DataTableNewRowEventArgs) Handles dtPuestos.TableNewRow
        btnRegistrar.Enabled = ds.HasChanges
    End Sub
    Private Sub txtCliente_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCliente.KeyUp
        If e.KeyCode = Keys.Enter Then
            AbrirCliente()
        End If
    End Sub
    Private Sub txtBusqueda_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBusqueda.KeyUp
        Dim dr As DataGridViewRow
        Dim i As Integer

        If e.KeyCode = Keys.Enter Then
            For i = 0 To dgvPuestos.Rows.Count - 1
                dr = dgvPuestos.Rows(i)

                If dr.Cells("col2Cilindro").Value Is Nothing Then Continue For

                If dr.Cells("col2Cilindro").Value.ToString = txtBusqueda.Text Then
                    dgvPuestos.FirstDisplayedScrollingRowIndex = i
                    dr.Selected = True
                    Exit For
                End If
            Next

            txtBusqueda.Clear()
        End If
    End Sub
    Private Sub txtCliente_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCliente.Validating
        AbrirCliente()
    End Sub
    Private Sub AsociarVariosEquiposToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AsociarVariosEquiposToolStripMenuItem.Click
        Dim f As New frmParqueCliente(txtCliente.Tag.ToString, cboSuc.SelectedValue.ToString)
        Dim dr1 As DataRow
        Dim mac As New Parque(cn)
        f.ShowDialog()
        If f.DialogResult = Windows.Forms.DialogResult.OK Then
            Dim a As Integer
            a = CInt(dtSectores.Rows(0).Item("regid_0"))
            For i As Integer = 0 To f.dgv.SelectedRows.Count - 1
                Dim dr As DataRow = CType(f.dgv.SelectedRows(i).DataBoundItem, DataRowView).Row
                mac.Abrir(dr("macnum_0").ToString)
                dr1 = dtPuestos.NewRow
                dr1("sector_0") = a
                dr1("puesto_0") = " "
                dr1("macnum_0") = dr("macnum_0").ToString
                dr1("macpdtcod_0") = mac.ArticuloCodigo
                dr1("macdes_0") = mac.ArticuloDescripcion
                dr1("ynrocil_0") = mac.Cilindro
                dr1("yfabdat_0") = mac.FabricacionCorto
                dr1("vto") = mac.VtoCarga
                dr1("ph") = mac.VtoPH
                dr1("tipo_0") = 0
                dr1("fecha_0") = #12/31/1599#
                dtPuestos.Rows.Add(dr1)
            Next
        End If
    End Sub

    Private Sub cmenuPuestos_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmenuPuestos.Opening
        If dtSectores.Rows.Count = 0 Then
            cmenuPuestos.Enabled = False
        Else
            cmenuPuestos.Enabled = True
        End If
    End Sub
End Class