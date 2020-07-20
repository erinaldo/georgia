Imports System.Data.OracleClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class frmSectoresPuestos
    Private daSectores As OracleDataAdapter
    Private daPuestos As OracleDataAdapter
    Private daInspecciones As OracleDataAdapter
    Private dtSectores As New DataTable
    Private dtInspecciones As New DataTable
    Private WithEvents dtPuestos As New DataTable

    Private dvExtintores As DataView
    Private dvHidrantes As DataView

    Private ds As New DataSet

    Private bpc As Cliente
    Private bpa As Sucursal

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Adaptadores()

    End Sub
    Private Sub Adaptadores()
        Dim Sql As String

        'SQL para sectores
        Sql = "SELECT * FROM xsectores2 WHERE bpcnum_0 = :bpcnum_0 AND fcyitn_0 = :fcyitn_0 ORDER BY sector_0"
        daSectores = New OracleDataAdapter(Sql, cn)
        daSectores.SelectCommand.Parameters.Add("bpcnum_0", OracleType.VarChar)
        daSectores.SelectCommand.Parameters.Add("fcyitn_0", OracleType.VarChar)

        daSectores.UpdateCommand = New OracleCommandBuilder(daSectores).GetUpdateCommand
        daSectores.DeleteCommand = New OracleCommandBuilder(daSectores).GetDeleteCommand
        '-----

        'SQL para puestos
        Sql = "SELECT * "
        Sql &= "FROM xpuestos2 "
        Sql &= "WHERE idsector_0 = :idsector_0"

        daPuestos = New OracleDataAdapter(Sql, cn)
        daPuestos.SelectCommand.Parameters.Add("idsector_0", OracleType.Number)

        daPuestos.UpdateCommand = New OracleCommandBuilder(daPuestos).GetUpdateCommand
        daPuestos.DeleteCommand = New OracleCommandBuilder(daPuestos).GetDeleteCommand

        'SQL para inspecciones
        Sql = "SELECT dat_0, "
        Sql &= "	  itn_0, "
        Sql &= "	  (SELECT lanmes_0 FROM aplstd WHERE lanchp_0 = 2408 AND lan_0 = 'SPA' AND lannum_0 = acomp_0) AS relevador "
        Sql &= "FROM xcontroles xco INNER JOIN "
        Sql &= "	 xrutad xrd ON (itn_0 = vcrnum_0) INNER JOIN "
        Sql &= "	 xrutac xrc ON (xrd.ruta_0 = xrc.ruta_0) "
        Sql &= "WHERE bpcnum_0 = :bpcnum_0 AND "
        Sql &= "	  bpaadd_0 = :bpaadd_0 AND "
        Sql &= "	  xrd.estado_0 = 3"
        Sql &= "ORDER BY dat_0 DESC"

        daInspecciones = New OracleDataAdapter(Sql, cn)
        daInspecciones.SelectCommand.Parameters.Add("bpcnum_0", OracleType.VarChar)
        daInspecciones.SelectCommand.Parameters.Add("bpaadd_0", OracleType.VarChar)

    End Sub
    Private Sub CargarDatos()
        CargarSectores()
        CargarInspecciones()

        dgvSectores.Enabled = True
        dgvPuestosExtintores.Enabled = True
        dgvPuestosHidrantes.Enabled = True

    End Sub
    Private Sub frmSectoresPuestos_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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
    Private Sub frmSectoresPuestos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AddHandler dgvPuestosExtintores.RowPostPaint, AddressOf NumeracionGrillas
        AddHandler dgvSectores.RowPostPaint, AddressOf NumeracionGrillas

        ds.Tables.Add(dtPuestos)

    End Sub
    Private Sub CargarSectores()
        With daSectores.SelectCommand
            .Parameters("bpcnum_0").Value = bpc.Codigo
            .Parameters("fcyitn_0").Value = bpa.Sucursal
        End With
        dtSectores.Clear()
        daSectores.Fill(dtSectores)

        'Enlace con la grilla
        If dgvSectores.DataSource Is Nothing Then
            colSectorId.DataPropertyName = "id_0"
            colSectorCliente.DataPropertyName = "bpcnum_0"
            colSectorSucursal.DataPropertyName = "fcyitn_0"
            colSectorNro.DataPropertyName = "numero_0"
            colSectorNombre.DataPropertyName = "sector_0"
            dgvSectores.DataSource = dtSectores
        End If

        'Si no hay sectores, limpio tabla de puestos
        If dtSectores.Rows.Count = 0 Then dtPuestos.Rows.Clear()

    End Sub
    Private Sub CargarPuestos(ByVal idSector As Integer)
        daPuestos.SelectCommand.Parameters("idsector_0").Value = idSector

        dtPuestos.Clear()
        daPuestos.Fill(dtPuestos)

        EnlazarPuestosExtintores()
        EnlazarPuestosHidrantes()

    End Sub
    Private Sub CargarInspecciones()
        With daInspecciones.SelectCommand
            .Parameters("bpcnum_0").Value = bpc.Codigo
            .Parameters("bpaadd_0").Value = bpa.Sucursal
        End With
        dtInspecciones.Clear()
        daInspecciones.Fill(dtInspecciones)

        'Enlace con la grilla
        If dgvInspecciones.DataSource Is Nothing Then
            colInspeccionesFecha.DataPropertyName = "dat_0"
            colInspeccionesIntervencion.DataPropertyName = "itn_0"
            colInspeccionesRelevador.DataPropertyName = "relevador"
            dgvInspecciones.DataSource = dtInspecciones
        End If
    End Sub
    Private Sub EnlazarPuestosExtintores()
        If dgvPuestosExtintores.DataSource Is Nothing Then
            colPuestoExtintorId.DataPropertyName = "id_0"
            colPuestoExtintorNro.DataPropertyName = "nropuesto_0"
            colPuestoExtintorUbicacion.DataPropertyName = "ubicacion_0"
            colPuestoExtintorOrden.DataPropertyName = "orden_0"
            colPuestoExtintorSector.DataPropertyName = "idsector_0"
            colPuestoExtintorTipo.DataPropertyName = "tipo_0"
            colPuestoExtintorCilindro.DataPropertyName = "cilindro_0"

            Dim tb As New TablaVaria(cn, 22, True)
            tb.EnlazarComboBox(colPuestoExtintorAgente, "agente_0")

            tb = New TablaVaria(cn, 21, True)
            tb.EnlazarComboBox(colPuestoExtintorCapacidad, "capacidad_0")

            colPuestoExtintorEquipo.DataPropertyName = "equipo_0"
            colPuestoExtintorInspeccion.DataPropertyName = "inspeccion_0"

            Dim dv As New DataView(dtPuestos)
            dv.RowFilter = "tipo_0 = 1"

            dgvPuestosExtintores.DataSource = dv
        End If
    End Sub
    Private Sub EnlazarPuestosHidrantes()

        If dgvPuestosHidrantes.DataSource Is Nothing Then
            colPuestoHidranteId.DataPropertyName = "id_0"
            colPuestoHidranteNro.DataPropertyName = "nropuesto_0"
            colPuestoHidranteUbicacion.DataPropertyName = "ubicacion_0"
            colPuestoHidranteOrden.DataPropertyName = "orden_0"
            colPuestoHidranteSector.DataPropertyName = "idsector_0"
            colPuestoHidranteTipo.DataPropertyName = "tipo_0"
            colPuestoHidranteAgente.DataPropertyName = "agente_0"
            colPuestoHidranteCapacidad.DataPropertyName = "capacidad_0"
            colPuestoHidranteEquipo.DataPropertyName = "equipo_0"
            colPuestoHidranteInspeccion.DataPropertyName = "inspeccion_0"
            colPuestoHidranteCilindro.DataPropertyName = "cilindro_0"

            Dim dv As New DataView(dtPuestos)
            dv.RowFilter = "tipo_0 = 2"

            dgvPuestosHidrantes.DataSource = dv
        End If
    End Sub
    Private Sub EvitarCamposNulos(ByVal Campo As String, ByVal dr As DataRow)
        If IsDBNull(Campo) OrElse dr(Campo).ToString = "" Then
            dr.BeginEdit()
            dr(Campo) = " "
            dr.EndEdit()
        End If
    End Sub

#Region "MENU CONTEXTUAL - Sectores"
    Private Sub mnuSectorNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSectorNuevo.Click
        Dim dr As DataRow
        Dim f As New frmABMSectores(bpc, bpa)

        'Abrir pantalla ABM sectores
        f.ShowDialog(Me)

        If f.DialogResult = Windows.Forms.DialogResult.OK Then
            dr = dtSectores.NewRow
            dr("id_0") = f.sec.Id
            dr("numero_0") = f.sec.Numero
            dr("sector_0") = f.sec.Nombre
            dr("bpcnum_0") = f.sec.ClienteId
            dr("fcyitn_0") = f.sec.SucursalId
            dtSectores.Rows.Add(dr)
            dr.AcceptChanges()

        End If

    End Sub
    Private Sub mnuSectorEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSectorEditar.Click
        Dim dr As DataRow = CType(dgvSectores.SelectedRows(0).DataBoundItem, DataRowView).Row
        Dim id As Integer = CInt(dr("id_0"))

        Dim f As New frmABMSectores(id)
        f.ShowDialog(Me)

        If f.DialogResult = Windows.Forms.DialogResult.OK Then
            dr.BeginEdit()
            dr("numero_0") = f.sec.Numero
            dr("sector_0") = f.sec.Nombre
            dr.EndEdit()
            dr.AcceptChanges()
        End If
    End Sub
    Private Sub mnuSectorEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSectorEliminar.Click
        Dim dr As DataRow = CType(dgvSectores.SelectedRows(0).DataBoundItem, DataRowView).Row
        Dim txt As String = dr("sector_0").ToString
        Dim Usado As Boolean = False

        'Verifico que el sector no se esté usando en algun puesto
        For Each dr2 As DataRow In dtPuestos.Rows
            If dr2.RowState = DataRowState.Deleted Then Continue For

            If CLng(dr2("idsector_0")) = CLng(dr("id_0")) Then
                Usado = True
                Exit For
            End If
        Next

        'Pido confirmacion para eliminar el sector
        txt = "¿Confirma la eliminacion del sector: " & txt & "?"
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
#Region "MENU CONTEXTUAL - Puestos Extintor"
    Private Sub cmenuPuestos_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mnuPuestosExtintores.Opening
        mnuPuestosExtintores.Enabled = (dtSectores.Rows.Count > 0)
    End Sub
    Private Sub mnuNuevoPuestoExtintor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNuevoPuestoExtintor.Click
        Dim dr As DataRow
        Dim f As frmABMPuestos
        Dim i As Integer

        'Obtengo el sector actual
        dr = CType(dgvSectores.SelectedRows(0).DataBoundItem, DataRowView).Row
        i = CInt(dr("id_0"))

        f = New frmABMPuestos(i, 1)
        f.ShowDialog(Me)

        If f.DialogResult = Windows.Forms.DialogResult.OK Then
            dr = dtPuestos.NewRow
            dr("id_0") = f.Puesto.id
            dr("nropuesto_0") = f.Puesto.NroPuesto
            dr("ubicacion_0") = f.Puesto.Ubicacion
            dr("orden_0") = f.Puesto.Orden
            dr("idsector_0") = f.Puesto.SectorId
            dr("tipo_0") = 1
            dr("agente_0") = f.Puesto.Agente
            dr("capacidad_0") = f.Puesto.Capacidad
            dr("equipo_0") = " "
            dr("inspeccion_0") = " "
            dtPuestos.Rows.Add(dr)
            dr.AcceptChanges()
        End If
    End Sub
    Private Sub mnuEditarPuestoExtintor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEditarPuestoExtintor.Click
        Dim idPuesto As Integer
        Dim dr As DataRow
        Dim f As frmABMPuestos

        If dgvPuestosExtintores.CurrentRow Is Nothing Then Exit Sub 'salgo si no hay fila seleccionada

        'Obtengo el puesto actual
        dr = CType(CType(dgvPuestosExtintores.CurrentRow, DataGridViewRow).DataBoundItem, DataRowView).Row
        idPuesto = CInt(dr("id_0"))

        f = New frmABMPuestos(idPuesto)
        f.ShowDialog(Me)

        If f.DialogResult = Windows.Forms.DialogResult.OK Then
            dr.BeginEdit()
            dr("nropuesto_0") = f.Puesto.NroPuesto
            dr("ubicacion_0") = f.Puesto.Ubicacion
            dr("orden_0") = f.Puesto.Orden
            dr("agente_0") = f.Puesto.Agente
            dr("capacidad_0") = f.Puesto.Capacidad
            dr.EndEdit()
            dr.AcceptChanges()
        End If

    End Sub
    Private Sub mnuNuevoEquipo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNuevoEquipo.Click
        Dim f As frmParque
        Dim dr As DataRow = CType(dgvPuestosExtintores.CurrentRow.DataBoundItem, DataRowView).Row
        Dim mac As New Parque(cn)

        mac.Nuevo(bpc.Codigo, bpa.Codigo)

        f = New frmParque(mac)
        f.ShowDialog()

        If f.DialogResult = Windows.Forms.DialogResult.OK Then
            dr.BeginEdit()
            dr("macnum_0") = mac.Serie
            dr.EndEdit()
        End If

    End Sub
    Private Sub mnuPuestoVacio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPuestoVacio.Click
        If dgvPuestosExtintores.CurrentRow Is Nothing Then Exit Sub 'salgo si no hay fila seleccionada

        Dim dr As DataRow = CType(dgvPuestosExtintores.CurrentRow.DataBoundItem, DataRowView).Row

        If MessageBox.Show("¿Confirma marcar este puesto como vacío?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            VaciarPuesto(dr)
        End If

    End Sub
    Private Sub mnuAsociarEquipo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAsociarEquipo.Click
        Dim dt As DataTable

        If dgvPuestosExtintores.CurrentRow Is Nothing Then Exit Sub 'salgo si no hay fila seleccionada

        Dim f As New frmParqueCliente(bpc.Codigo, bpa.Codigo)
        Dim dr As DataRow

        f.ShowDialog()

        If f.DialogResult = Windows.Forms.DialogResult.OK Then
            Dim mac As New Parque(cn)

            dr = CType(dgvPuestosExtintores.CurrentRow.DataBoundItem, DataRowView).Row

            If mac.Abrir(f.Tag.ToString) Then
                'Elimino el parque de otro puesto
                dt = CType(dgvPuestosExtintores.DataSource, DataView).Table
                For Each dr2 As DataRow In dt.Rows
                    If dr2("equipo_0").ToString = mac.Serie Then
                        VaciarPuesto(dr2)
                    End If
                Next

                dr.BeginEdit()
                dr("equipo_0") = mac.Serie

                'Si el equipo era de otra sucursal, lo paso a la sucursal actual
                If bpa.Codigo <> mac.SucursalNumero Then
                    mac.SucursalNumero = bpa.Codigo
                    mac.Grabar()
                End If

            End If
        End If
        f.Dispose()

    End Sub
    Private Sub VaciarPuesto(ByVal dr As DataRow)
        dr.BeginEdit()
        dr("equipo_0") = " "
        dr.EndEdit()
    End Sub
#End Region
#Region "MENU CONTEXTUAL - Puestos Hidrantes"
    Private Sub mnuNuevoPuestoHidrante_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNuevoPuestoHidrante.Click
        Dim dr As DataRow
        Dim f As frmABMPuestos
        Dim i As Integer

        'Obtengo el sector actual
        dr = CType(dgvSectores.SelectedRows(0).DataBoundItem, DataRowView).Row
        i = CInt(dr("id_0"))

        f = New frmABMPuestos(i, 2)
        f.ShowDialog(Me)

        If f.DialogResult = Windows.Forms.DialogResult.OK Then
            dr = dtPuestos.NewRow
            dr("id_0") = f.Puesto.id
            dr("nropuesto_0") = f.Puesto.NroPuesto
            dr("ubicacion_0") = f.Puesto.Ubicacion
            dr("orden_0") = f.Puesto.Orden
            dr("idsector_0") = f.Puesto.SectorId
            dr("tipo_0") = f.Puesto.Tipo
            dr("agente_0") = f.Puesto.Agente
            dr("capacidad_0") = f.Puesto.Capacidad
            dr("equipo_0") = " "
            dr("inspeccion_0") = " "
            dtPuestos.Rows.Add(dr)
            dr.AcceptChanges()
        End If
    End Sub
    Private Sub EditarPuestoHidranteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditarPuestoHidranteToolStripMenuItem.Click
        Dim idPuesto As Integer
        Dim dr As DataRow
        Dim f As frmABMPuestos

        If dgvPuestosHidrantes.CurrentRow Is Nothing Then Exit Sub 'salgo si no hay fila seleccionada

        'Obtengo el puesto actual
        dr = CType(CType(dgvPuestosHidrantes.CurrentRow, DataGridViewRow).DataBoundItem, DataRowView).Row
        idPuesto = CInt(dr("id_0"))

        f = New frmABMPuestos(idPuesto)
        f.ShowDialog(Me)

        If f.DialogResult = Windows.Forms.DialogResult.OK Then
            dr.BeginEdit()
            dr("nropuesto_0") = f.Puesto.NroPuesto
            dr("ubicacion_0") = f.Puesto.Ubicacion
            dr("orden_0") = f.Puesto.Orden
            dr("agente_0") = f.Puesto.Agente
            dr("capacidad_0") = f.Puesto.Capacidad
            dr.EndEdit()
            dr.AcceptChanges()
        End If
    End Sub
#End Region
#Region "MENU CONTEXTUAL - Inspecciones"
    Private Sub mnuVerInspeccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuVerInspeccion.Click
        VerInspeccion()
    End Sub
    Private Sub mnuVerInspeccionActualizada_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuVerInspeccionActualizada.Click
        VerInspeccionActualizada()
    End Sub
    Private Sub mnuEditarInspeccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEditarInspeccion.Click
        EditarInspeccion()
    End Sub
#End Region
#Region "BOTONES"
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
        btnCancelar.Enabled = ds.HasChanges
    End Sub
    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
#End Region
    Private Sub dgvPuestos_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPuestosExtintores.CellDoubleClick
        If e.RowIndex < 0 Then Exit Sub
        If e.ColumnIndex < 0 Then Exit Sub

        If dgvPuestosExtintores.Rows(e.RowIndex).DataBoundItem Is Nothing Then Exit Sub
        If dgvPuestosExtintores.Columns(e.ColumnIndex).Name <> "col2Equipo" Then Exit Sub

        Dim dr As DataRow = CType(dgvPuestosExtintores.Rows(e.RowIndex).DataBoundItem, DataRowView).Row
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
        btnCancelar.Enabled = ds.HasChanges
    End Sub
    Private Sub dtPuestos_RowDeleted(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs) Handles dtPuestos.RowDeleted
        btnRegistrar.Enabled = ds.HasChanges
        btnCancelar.Enabled = ds.HasChanges
    End Sub
    Private Sub dgvSectores_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvSectores.SelectionChanged

        Dim i As Integer
        Dim dr As DataRow

        If dgvSectores.SelectedRows Is Nothing Then Exit Sub
        If dgvSectores.SelectedRows.Count <= 0 Then Exit Sub

        dr = CType(dgvSectores.SelectedRows(0).DataBoundItem, DataRowView).Row

        i = CInt(dr("id_0"))

        CargarPuestos(i)

    End Sub
    Private Sub VerInspeccion()
        Dim rpt As New ReportDocument
        Dim f As frmCrystal
        Dim Itn As String
        Dim dr As DataRow

        'Obtengo la fila seleccionada
        If dgvInspecciones.CurrentRow Is Nothing Then Exit Sub 'salgo si no hay fila seleccionada

        'Obtengo el puesto actual
        dr = CType(CType(dgvInspecciones.CurrentRow, DataGridViewRow).DataBoundItem, DataRowView).Row
        Itn = dr("itn_0").ToString

        Try
            rpt.Load(RPTX3 & "XINSPECC.rpt")
            rpt.SetParameterValue("ITN", Itn)
            rpt.SetParameterValue("X3DOS", X3DOS)

            f = New frmCrystal(rpt, False)
            f.MdiParent = frmMain
            f.Show()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub
    Private Sub VerInspeccionActualizada()
        Dim rpt As New ReportDocument
        Dim f As frmCrystal
        Dim Itn As String
        Dim dr As DataRow

        'Obtengo la fila seleccionada
        If dgvInspecciones.CurrentRow Is Nothing Then Exit Sub 'salgo si no hay fila seleccionada

        'Obtengo el puesto actual
        dr = CType(CType(dgvInspecciones.CurrentRow, DataGridViewRow).DataBoundItem, DataRowView).Row
        Itn = dr("itn_0").ToString

        Try
            rpt.Load(RPTX3 & "XINSPECC2.rpt")
            rpt.SetParameterValue("ITN", Itn)
            rpt.SetParameterValue("X3DOS", X3DOS)

            f = New frmCrystal(rpt, False)
            f.MdiParent = frmMain
            f.Show()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub
    Private Sub EditarInspeccion()
        Dim dr As DataRow
        Dim x As String = ""
        Dim c As New Clases.Control(cn)

        If dgvInspecciones.CurrentRow Is Nothing Then Exit Sub 'salgo si no hay fila seleccionada

        'Obtengo el registro actual
        dr = CType(CType(dgvInspecciones.CurrentRow, DataGridViewRow).DataBoundItem, DataRowView).Row
        x = dr("itn_0").ToString

        c.Abrir(x)

        Dim f As New frmEditarInspeccion(c)
        f.ShowInTaskbar = False
        f.ShowDialog(Me)

    End Sub
    Public Sub Transferir(ByVal Cli As String, ByVal Suc As String)
        Dim da As OracleDataAdapter
        Dim dt As New DataTable
        Dim Sql As String

        Dim Secs As New Sectores2(cn)
        Dim Sec As New Sector2(cn)
        Dim Pues As Puestos2Collection
        Dim Pue As New Puesto2(cn)

        'Elimino los Sectores y Puestos actuales
        Secs.Abrir(Cli, Suc)

        For Each Sec In Secs
            Pues = Sec.Puestos

            For Each Pue In Pues
                Pue.Eliminar()
                Pue.Grabar()
            Next
            Sec.Eliminar()
            Sec.Grabar()
        Next

        Sec = New Sector2(cn)
        Pue = New Puesto2(cn)

        Sql = "select s.regid_0 as idsector, nombre_0, p.regid_0 as idpuesto, puesto_0, tipo_0, macnum_0, s.bpcnum_0, s.fcyitn_0 "
        Sql &= "from xsectores s inner join "
        Sql &= "     xpuestos p on (p.sector_0 = s.regid_0) "
        Sql &= "where bpcnum_0 = :bpcnum and "
        Sql &= "      fcyitn_0 = :fcyitn "
        Sql &= "order by s.regid_0, p.regid_0"

        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("bpcnum", OracleType.VarChar).Value = Cli
        da.SelectCommand.Parameters.Add("fcyitn", OracleType.VarChar).Value = Suc
        da.Fill(dt)

        Dim SectorActual As Integer = 0
        Dim s As Integer = 0
        Dim p As Integer = 0

        For Each dr As DataRow In dt.Rows

            If CInt(dr("idsector")) <> SectorActual Then
                s += 1
                p = 0

                SectorActual = CInt(dr("idsector"))
                Sec.Nuevo(dr("bpcnum_0").ToString, dr("fcyitn_0").ToString)
                Sec.Numero = s.ToString
                Sec.Nombre = dr("nombre_0").ToString
                Sec.Grabar()
            End If

            Dim Tipo As Integer = 1
            Dim mac As New Parque(cn)

            If dr("macnum_0").ToString.Trim <> "" Then
                If mac.Abrir(dr("macnum_0").ToString) Then
                    Try
                        Tipo = CInt(IIf(mac.EsManguera, 2, 1))

                    Catch ex As Exception
                        Continue For

                    End Try

                Else
                    mac = Nothing
                End If
            Else
                mac = Nothing
            End If

            p += 1
            Pue.Nuevo(Sec.Id, p.ToString, "ubicacion", Tipo)
            If mac IsNot Nothing Then
                Pue.EquipoId = mac.Serie
                Pue.Agente = mac.Articulo.Familia(2)
                Pue.Capacidad = mac.Articulo.Familia(1)
                Pue.Cilindro = mac.Cilindro
            End If
            Pue.Grabar()

        Next

    End Sub
    Private Sub CambiarSector(ByVal dgv As DataGridView)
        Dim dr As DataRow
        Dim f As frmSelectorSectores

        If dgv.SelectedRows Is Nothing Then Exit Sub 'salgo si no hay fila seleccionada

        f = New frmSelectorSectores(bpc.Codigo, bpa.Sucursal)
        f.ShowDialog(Me)

        For Each d As DataGridViewRow In dgv.SelectedRows
            dr = CType(d.DataBoundItem, DataRowView).Row

            If f.DialogResult = Windows.Forms.DialogResult.OK Then
                dr.BeginEdit()
                dr("idsector_0") = f.lstSectores.SelectedValue
                dr.EndEdit()
            End If
        Next

    End Sub
    Private Sub mnuCambiarSectorHidrante_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCambiarSectorHidrante.Click
        CambiarSector(dgvPuestosHidrantes)
    End Sub
    Private Sub mnuCambiarSectorExtintor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCambiarSectorExtintor.Click
        CambiarSector(dgvPuestosExtintores)
    End Sub
    Private Sub btnAbrir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbrir.Click
        Dim f As New frmAbrirClienteSucursal

        f.ShowDialog()

        If f.DialogResult = Windows.Forms.DialogResult.OK Then
            AbrirClienteSucursal(f.bpc.Codigo, f.bpa.Sucursal)
        End If
    End Sub
    Public Sub AbrirClienteSucursal(ByVal Cliente As String, ByVal Sucursal As String)

        If bpc Is Nothing Then bpc = New Cliente(cn)
        If bpa Is Nothing Then bpa = New Sucursal(cn)

        bpc.Abrir(Cliente)
        bpa.Abrir(Cliente, Sucursal)

        txtCodigoCliente.Text = bpc.Codigo
        txtCliente.Text = bpc.Nombre
        txtCodigoSucursal.Text = bpa.Sucursal
        txtSucursal.Text = bpa.Direccion

        CargarDatos()
    End Sub

End Class