Imports System.Data.OracleClient
Imports System.Windows.Forms
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Collections
Public Class frmCotizadorInterno
    Dim bpc As New Cliente(cn)
    Dim rep As New Vendedor(cn)
    Dim cotint As New CotizacionInterna(cn)
    Private dv As DataView
    Dim correo As New CorreoElectronico

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        'Enlace de la grilla
        colNro.DataPropertyName = "nro_0"
        colLinea.DataPropertyName = "numlig_0"
        ColProveedor.DataPropertyName = "Proveedor_0"
        ColCodigoArticulo.DataPropertyName = "itmref_0"
        With ColDescripcion
            .DisplayMember = "itmdes1_0"
            .ValueMember = "itmref_0"
            .DataPropertyName = "itmref_0"
            .DataSource = Articulo.Tabla(cn)
        End With
        ColCantidad.DataPropertyName = "qty_0"
        ColPrecioUnitario.DataPropertyName = "precio_0"
        colSugerido.DataPropertyName = "precio_1"
        ColPrecioTotal.DataPropertyName = "total_0"
        cotint.EnlazarGrilla(Dgv)
        'Dgv.DataSource = cotint.dtd

        'Lleno combo estado
        Dim mnu As New MenuLocal(cn, 1242, False)
        mnu.AbrirMenu(1242, True)
        'mnu.Enlazar(cboEstado)
        With cboEstado
            .DisplayMember = "lanmes_0"
            .ValueMember = "lannum_0"
            .DataSource = mnu.Tabla1
        End With
        'AddHandler Dgv.RowPostPaint, AddressOf NumeracionGrillas

    End Sub
    Private Sub BtnNuevaCotizacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevaCotizacion.Click
        cotint.Nuevo()
        TxtBoxNumeroCotizacion.Text = "0"
        LimpiarCampos()
        TxtBoxCodigoCliente.Enabled = True
        Dgv.Enabled = True
        cboEstado.Enabled = False
        Dgv.Columns(3).ReadOnly = False
        Dgv.Columns(4).ReadOnly = False
        Dgv.Columns(5).ReadOnly = True
        Dgv.Columns(6).ReadOnly = True
        Dgv.Columns(7).ReadOnly = True
        BtnRegistrarCotizacion.Enabled = True
    End Sub
    Private Sub LimpiarCampos()
        TxtBoxCliente.Text = ""
        TxtBoxCodigoCliente.Text = ""
        TxtBoxCotizador.Text = ""
        TxtboxNombreRep.Text = ""
        TxtBoxObs.Text = ""
        dtpFechaCotizacion.Value = Date.Today
        dtpFechaRespuestaCotizacion.Value = Date.Today
        dtpVigenciaPresupuesto.Value = Date.Today
        TxtBoxRep.Text = ""
        cboEstado.SelectedIndex = 0
        BtnAprobar.Enabled = False
        BtnRechazar.Enabled = False
        BtnCotizar.Enabled = False
        BtnRegistrarCotizacion.Enabled = False

    End Sub
    Private Sub TextBox2_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtBoxCodigoCliente.Validated
        Dim txt As TextBox = CType(sender, TextBox)
        If Not bpc.Abrir(txt.Text) Then
            MsgBox("cliente no encontrado")
        Else
            TxtBoxCliente.Text = bpc.Nombre.ToString
            rep.Abrir(bpc.Representante(1))
            TxtBoxRep.Text = rep.Codigo.ToString
            TxtboxNombreRep.Text = rep.Nombre.ToString
            cboEstado.SelectedIndex = 1
        End If


    End Sub
    
    Private Sub EnviarMail(ByVal direccion As String, ByVal asunto As String, ByVal cuerpo As String)
        With correo
            .Nuevo()
            .Remitente("noreply@matafuegosgeorgia.com", "Matafuegos Georgia")
            .AgregarDestinatario(direccion)
            .Asunto = asunto
            .Cuerpo = cuerpo
            .Enviar()
        End With
    End Sub
    Private Sub cms1_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mnu2.Opening
        With Dgv
            If .Columns(.CurrentCell.ColumnIndex).Name <> "ColCodigoArticulo" Then e.Cancel = True
        End With
    End Sub
    Private Sub SeleccionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SeleccionToolStripMenuItem.Click
        AbrirSelectorArticulos()
    End Sub
    Private Sub AbrirSelectorArticulos()
        Dim f As New frmSelectorArticulos()
        Dim c As Control

        f.ShowDialog(Me)

        If f.DialogResult = Windows.Forms.DialogResult.OK Then
            'Busco el control activo
            c = FindFocussedControl(Me)

            If TypeOf c Is DataGridViewTextBoxEditingControl Then
                CType(c, DataGridViewTextBoxEditingControl).Text = f.Seleccion
            End If

        End If

        f.Dispose()

    End Sub
    Function FindFocussedControl(ByVal ctr As Control) As Control
        Dim cc As ContainerControl = TryCast(ctr, ContainerControl)

        Do While (cc IsNot Nothing)
            ctr = cc.ActiveControl
            cc = TryCast(ctr, ContainerControl)
        Loop

        Return ctr

    End Function
    Private Sub Dgv_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles Dgv.EditingControlShowing
        Dim tb As DataGridViewTextBoxEditingControl

        Try
            tb = CType(e.Control, DataGridViewTextBoxEditingControl)
            tb.ContextMenuStrip = mnu2
        Catch ex As Exception
        End Try
    End Sub
    Private Sub frmCotizadorInterno_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Buscar()
        If Not usr.Permiso.AccesoSecundario(84, "V") Then
            Dgv.Columns(6).Visible = False
        Else
            Dgv.Columns(6).Visible = True
        End If
        BtnRegistrarCotizacion.Enabled = False

    End Sub
    Private Sub Buscar()
        Dim da As OracleDataAdapter
        Dim dt As DataTable
        Dim Sql As String
        Dim Where As Boolean = False 'Indica si puse clausula where
        Dim mnu2 As New MenuLocal(cn, 1242, False)
        mnu2.AbrirMenu(1242, True)
        'btnBuscar.Enabled = False
        Application.DoEvents()

        Sql = "select * from xcotint order by nro_0 "

        da = New OracleDataAdapter(Sql, cn)

        If DgvLateral.DataSource Is Nothing Then
            dt = New DataTable
            dv = New DataView(dt)
        Else
            dt = CType(DgvLateral.DataSource, DataView).Table
        End If

        dt.Clear()
        da.Fill(dt)
        da.Dispose()
        

        
        If DgvLateral.DataSource Is Nothing Then
            ColNumero.DataPropertyName = "nro_0"
            ColFechaCot.DataPropertyName = "dat_0"
            ColFechaRespuesta.DataPropertyName = "dat_1"
            ColFechaVigencia.DataPropertyName = "dat_2"
            ColCliente.DataPropertyName = "bpcnum_0"
            With ColEstado
                .DisplayMember = "lanmes_0"
                .ValueMember = "lannum_0"
                .DataPropertyName = "estado_0"
                .DataSource = mnu2.Tabla1
            End With
            'ColEstado.DataPropertyName = "estado_0"
            ColObs.DataPropertyName = "obs_0"
            ColCotizador.DataPropertyName = "cotizador_0"
            ColUsuario.DataPropertyName = "creusr_0"

            DgvLateral.DataSource = dv
        End If

        'btnBuscar.Enabled = True
        Application.DoEvents()

    End Sub
    Private Sub dgv_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles Dgv.CellBeginEdit
        On Error Resume Next

        If Dgv.Columns(e.ColumnIndex).Name = "colSugerido" Then
            e.Cancel = True

        ElseIf Dgv.Columns(e.ColumnIndex).Name = "colTotal" Then
            e.Cancel = True

        End If

    End Sub
    Private Sub dgv_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles Dgv.CellValidating
        Dim o As DataGridView = CType(sender, DataGridView)
        Dim r As DataGridViewRow = o.Rows(e.RowIndex)
        Dim c As DataGridViewCell = r.Cells(e.ColumnIndex)

        If c.IsInEditMode Then
            'Agrego al registro el numero del pedido
            If IsDBNull(r.Cells("colNro").Value) Then r.Cells("colNro").Value = 0
            'Agrego al registro el siguiente numero de linea
            If IsDBNull(r.Cells("colLinea").Value) Then r.Cells("colLinea").Value = NroLinea(o, r)
            'Validación segun columna
            Select Case o.Columns(e.ColumnIndex).Name
                Case "ColCodigoArticulo"
                    If c.Value.ToString = e.FormattedValue.ToString Then Exit Sub
                Case "ColCantidad"
                    If IsDBNull(c.Value) = True Then Exit Sub
                    If CDbl(c.Value) = CDbl(e.FormattedValue) Then Exit Sub
            End Select

        End If

    End Sub
    Private Sub dgv_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv.CellValidated
        Dim o As DataGridView = CType(sender, DataGridView)
        Dim r As DataGridViewRow = o.Rows(e.RowIndex)
        Dim c As DataGridViewCell = r.Cells(e.ColumnIndex)

        If c.IsInEditMode Then
            'Validación segun columna
            Select Case o.Columns(e.ColumnIndex).Name
                Case "ColCodigoArticulo"
                    r.Cells("ColProveedor").Value = "Por Cotizar"
                    r.Cells("ColCantidad").Value = 0
                    r.Cells("ColPrecioUnitario").Value = 0
                    r.Cells("ColSugerido").Value = 0
                    r.Cells("ColPrecioTotal").Value = 0
                Case "ColCantidad"
                    TotalLinea(r)

                Case "ColPrecioUnitario"
                    TotalLinea(r)

            End Select

        End If

    End Sub
    'Private Sub dgv_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles Dgv.CellFormatting
    '    On Error Resume Next

    '    Dim o As DataGridView = CType(sender, DataGridView)
    '    Dim r As DataGridViewRow = o.Rows(e.RowIndex)
    '    Dim c As DataGridViewCell
    '    Dim col As System.Drawing.Color


    '    'For Each c In r.Cells
    '    '    c.Style.BackColor = col
    '    'Next

    'End Sub
    Private Sub dgv_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles Dgv.DataError
        MessageBox.Show("Valor inválido", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        e.Cancel = True

        Dim o As DataGridView = CType(sender, DataGridView)
        Dim r As DataGridViewRow = o.Rows(e.RowIndex)
        If o.Columns(e.ColumnIndex).Name = "ColDescripcion" Then
            r.Cells("ColCodigoArticulo").Value = 101010
            r.Cells("ColDescripcion").Value = ""
        End If

    End Sub

    Private Function NroLinea(ByVal o As DataGridView, ByVal r As DataGridViewRow) As Integer
        Dim Linea As Integer = 0
        Dim drd As DataGridViewRow

        For Each drd In o.Rows
            If drd Is r Then Continue For

            If CInt(drd.Cells("colLinea").Value) > Linea Then
                Linea = CInt(drd.Cells("colLinea").Value)
            End If

        Next

        Linea += 1000

        Return Linea

    End Function
    Private Sub TotalLinea(ByVal r As DataGridViewRow)
        Dim c As Double ' Cantidad
        Dim p As Double 'Precio Unitario
        Dim t As Double 'Total linea

        If IsDBNull(r.Cells("ColCantidad").Value) Then
            c = 0
        Else
            c = CDbl(r.Cells("ColCantidad").Value)
        End If
        If IsDBNull(r.Cells("ColPrecioUnitario").Value) Then
            p = 0
        Else
            p = CDbl(r.Cells("ColPrecioUnitario").Value)
        End If

        t = c * p

        r.Cells("ColPrecioTotal").Value = t

    End Sub

    Private Sub ActualizarDatosControles()
        TxtBoxCodigoCliente.Text = cotint.Cliente
        TxtBoxNumeroCotizacion.Text = cotint.Numero.ToString
        bpc.Abrir(TxtBoxCodigoCliente.Text)
        TxtBoxCliente.Text = bpc.Nombre.ToString
        rep.Abrir(bpc.Representante(1))
        TxtBoxRep.Text = rep.Codigo.ToString
        TxtboxNombreRep.Text = rep.Nombre.ToString
        cboEstado.SelectedIndex = 0
        TxtBoxCotizador.Text = usr.LoginName
        dtpFechaCotizacion.Value = cotint.FechaCotizacion
        dtpFechaRespuestaCotizacion.Value = cotint.FechaRespuestaCotizacion
        dtpVigenciaPresupuesto.Value = cotint.FechaVigenciaPresupuesto
        cboEstado.SelectedIndex = cotint.Estado
        BtnCotizar.Enabled = (cboEstado.SelectedIndex = 1)
        BtnAprobar.Enabled = (cboEstado.SelectedIndex = 2) And dtpVigenciaPresupuesto.Value < dtpFechaRespuestaCotizacion.Value.AddDays(+7)
        BtnRechazar.Enabled = (cboEstado.SelectedIndex = 2)
        TxtBoxObs.Text = cotint.observaciones
    End Sub
    Private Sub DgvLateral_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvLateral.CellDoubleClick
        Dim dr As DataRowView = CType(CType(DgvLateral.Rows(e.RowIndex), DataGridViewRow).DataBoundItem, DataRowView)

        cotint.Abrir(dr(0).ToString)
        cboEstado.Enabled = True
        ActualizarDatosControles()

        Select Case cotint.Estado
            Case 1
                'ActualizarDatosControles()
                BtnRegistrarCotizacion.Enabled = False
                Dgv.Enabled = True
                Dgv.Columns(1).ReadOnly = True
                Dgv.Columns(2).ReadOnly = False
                Dgv.Columns(3).ReadOnly = True
                Dgv.Columns(4).ReadOnly = True
                If cotint.PrecioUnitario = 0 Then
                    Dgv.Columns(5).ReadOnly = False
                Else
                    Dgv.Columns(5).ReadOnly = True
                End If
                If cotint.PrecioSugerido = 0 Then
                    Dgv.Columns(6).ReadOnly = False
                Else
                    Dgv.Columns(6).ReadOnly = True
                End If

                Dgv.Columns(7).ReadOnly = True

            Case 2
                'ActualizarDatosControles()
                Dgv.Enabled = False
                BtnRegistrarCotizacion.Enabled = False
        End Select
      
        If dtpFechaCotizacion.Value <> dtpFechaRespuestaCotizacion.Value Then Exit Sub
        dtpFechaRespuestaCotizacion.Value = Today
        dtpVigenciaPresupuesto.Value = dtpFechaRespuestaCotizacion.Value.AddDays(+7)
    End Sub
    Private Sub TxtBoxRegistrarCotizacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRegistrarCotizacion.Click
        If CInt(cotint.dtd.Rows(0).Item(4)) = 0 Then
            MsgBox("Debe completar la cantidad")
            Exit Sub
        End If
        cotint.Cliente = TxtBoxCodigoCliente.Text.ToString
        cotint.observaciones = TxtBoxObs.Text.ToString
        cotint.Estado = cboEstado.SelectedIndex

        cotint.Grabar()
        BtnRegistrarCotizacion.Enabled = False
        Buscar()
        LimpiarCampos()
        'Si es cotizacion nueva , envia mail a compras para avisar que se creo una nueva cotizacion.
        If TxtBoxNumeroCotizacion.Text = "0" Then
            EnviarMail("compras@georgia.com.ar", "Se creo un nuevo pedido de cotizacion", "Verifique ingresando a la aplicacion especialmente creada para ustedes.")
            'ElseIf TxtBoxNumeroCotizacion.Text <> "0" And cboEstado.SelectedIndex = 6 Then
            '    EnviarMail("mbarcudes@matafuegosgeorgia.com", "Se creo un nuevo pedido de cotizacion", "Verifique ingresando a la aplicacion especialmente creada para ustedes.")
        End If

    End Sub
    Private Sub BtnCotizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCotizar.Click
        If CInt(cotint.dtd.Rows(0).Item(5)) > 0 Then
            cboEstado.SelectedIndex = 2
        End If
        cotint.observaciones = TxtBoxObs.Text.ToString
        cotint.FechaRespuestaCotizacion = dtpFechaRespuestaCotizacion.Value
        cotint.FechaVigenciaPresupuesto = dtpVigenciaPresupuesto.Value
        cotint.cotizador = TxtBoxCotizador.Text.ToString
        cotint.Estado = cboEstado.SelectedIndex

        cotint.Grabar()
        Buscar()
        LimpiarCampos()

    End Sub
    Private Sub BtnAprobar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAprobar.Click
        cboEstado.SelectedIndex = 3
        cotint.Grabar()
        LimpiarCampos()
    End Sub
    Private Sub BtnRechazar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRechazar.Click
        cboEstado.SelectedIndex = 4
        cotint.Grabar()
        LimpiarCampos()
    End Sub

    Private Sub cboEstado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboEstado.SelectedIndexChanged

        If TxtBoxNumeroCotizacion.Text = "0" Then Exit Sub
        ' cotint.Abrir(TxtBoxNumeroCotizacion.Text)
        Select Case cboEstado.SelectedIndex
            Case 1
                BtnCotizar.Enabled = True
                BtnRegistrarCotizacion.Enabled = False
                BtnAprobar.Enabled = False
                BtnRechazar.Enabled = False
                Dgv.Enabled = True
                'End If
                Dgv.Columns(1).ReadOnly = True
                Dgv.Columns(2).ReadOnly = False
                Dgv.Columns(3).ReadOnly = True
                Dgv.Columns(4).ReadOnly = True
                Dgv.Columns(7).ReadOnly = True

                If CInt(cotint.dtd.Rows(0).Item(5)) > 0 Or CInt(cotint.dtd.Rows(0).Item(6)) > 0 Then
                    Dgv.Columns(5).ReadOnly = True
                    Dgv.Columns(6).ReadOnly = True
                End If

            Case 2
                BtnAprobar.Enabled = True
                BtnRechazar.Enabled = True
                BtnRegistrarCotizacion.Enabled = True
                BtnCotizar.Enabled = False
            Case 3
                MsgBox("No puede elegir este estado")
                cboEstado.SelectedIndex = cotint.Estado
                BtnAprobar.Enabled = True
                BtnRechazar.Enabled = True
                BtnRegistrarCotizacion.Enabled = False
                BtnCotizar.Enabled = False
            Case 4
                MsgBox("No puede elegir este estado")
                cboEstado.SelectedIndex = cotint.Estado
                BtnAprobar.Enabled = True
                BtnRechazar.Enabled = True
                BtnRegistrarCotizacion.Enabled = False
                BtnCotizar.Enabled = False
            Case 5
                BtnCotizar.Enabled = False
                BtnRegistrarCotizacion.Enabled = True
                BtnAprobar.Enabled = False
                BtnRechazar.Enabled = False

            Case 6
                BtnCotizar.Enabled = False
                BtnRegistrarCotizacion.Enabled = True
                BtnAprobar.Enabled = False
                BtnRechazar.Enabled = False

        End Select
       

    End Sub
End Class