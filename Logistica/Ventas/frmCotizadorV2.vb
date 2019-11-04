' 04.04.2017 FECHA DE SALIDA A PRODUCCION
Imports System.Data.OracleClient
Imports System.Windows.Forms
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Collections

Public Class frmCotizadorV2

    Public WithEvents ctz As New Cotizacion(cn)
    Private NumeroCotizacionAnterior As Long = 0
    Private ActualizarDatos As Boolean = False
    Private dv As DataView 'Filtro para buscar lateral
    Private Per As Permisos
    Private TipoCambio As Double = 0

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        'Lleno Sociedades
        Sociedad.Sociedades(cn, cboSociedad, True)

        'Lleno ComboBox Modo de Entrega
        Dim mdl As New ModoEntrega(cn, True)
        mdl.ModosEntrega(cboEntrega)

        'Lleno ComboBox Estado
        Dim mnu As New MenuLocal(cn, 1240, False)
        mnu.AbrirMenu(1240, True)
        mnu.Enlazar(cboEstado)
        'Lleno ComboBox Condiciones de Pago
        CondicionPago.LlenarComboBox(cn, cboCondicionPago, True)

        'Enlace de la grilla
        colNro.DataPropertyName = "nro_0"
        colLinea.DataPropertyName = "numlig_0"
        colCodigo.DataPropertyName = "itmref_0"
        With colDescripcion
            .DisplayMember = "itmdes1_0"
            .ValueMember = "itmref_0"
            .DataPropertyName = "itmref_0"
            .DataSource = Articulo.Tabla(cn)
        End With
        colCant.DataPropertyName = "qty_0"
        colPrecio.DataPropertyName = "precio_0"
        colSugerido.DataPropertyName = "precio_1"
        colSugerido.ReadOnly = True
        colTotal.ReadOnly = True
        colTotal.DataPropertyName = "total_0"
        ctz.EnlazarGrilla(dgv)

        'Numeracion de las lineas de la grilla
        AddHandler dgv.RowPostPaint, AddressOf NumeracionGrillas
        AddHandler dgv2.RowPostPaint, AddressOf NumeracionGrillas

        'ComboBox Tipo
        mnu = New MenuLocal(cn, 1, True)
        mnu.ModificarTexto(1, "Pedido")
        mnu.ModificarTexto(2, "Presupuesto")
        mnu.Enlazar(cboTipo)
        cboTipo.SelectedValue = 0

        mnu = New MenuLocal(cn, 5003, False)
        mnu.Enlazar(cboLicitacion)
        cboTipo.SelectedValue = 0

        Per = New Permisos(cn, usr.Codigo)

    End Sub
    Private Sub frmPedidos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Buscar()
        Alerta639Pendientes()

        '05.09.2018 Cotizacion del Dolar
        Dim d As New Tarifa(cn)
        TipoCambio = d.CotizacionDolar

        grTipo.Visible = usr.Permiso.AccesoSecundario(43, "V")

    End Sub
    Private Sub chkPedidos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPedidos.CheckedChanged, chkRecargas.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)

        If chk.Checked Then
            If chk Is chkPedidos Then
                chkRecargas.Checked = False
            Else
                chkPedidos.Checked = False
            End If
        End If

    End Sub
    Private Sub dgv2_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv2.CellDoubleClick
        Dim txt As String
        Dim flg As Boolean = True

        If e.RowIndex > -1 Then
            If ctz.HasChanges Then
                txt = "El pedido actual no fue guardado" & vbCrLf & vbCrLf
                txt &= "¿Graba los cambios antes de continuar?"
                Select Case MessageBox.Show(txt, Me.Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3)
                    Case Windows.Forms.DialogResult.Yes
                        ctz.Grabar()
                        flg = True

                    Case Windows.Forms.DialogResult.No
                        flg = True

                    Case Windows.Forms.DialogResult.Cancel
                        flg = False

                End Select
            End If

            'Cargo el pedido seleccionado
            If flg Then
                Dim dr As DataRowView = CType(CType(dgv2.Rows(e.RowIndex), DataGridViewRow).DataBoundItem, DataRowView)

                ActualizarDatos = False

                ctz.Abrir(CLng(dr(0)))
                ActualizarDatosControles()
                ActualizarDatos = True
                ctz.AceptarCambios()
            End If
        End If

    End Sub
    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Buscar()
        Alerta639Pendientes()
    End Sub
    Private Sub Buscar()
        Dim da As OracleDataAdapter
        Dim dt As DataTable
        Dim Sql As String
        Dim Where As Boolean = False 'Indica si puse clausula where

        btnBuscar.Enabled = False
        Application.DoEvents()

        Sql = "SELECT distinct nro_0, dat_0, bpc.bpcnum_0, bpc.bpcnam_0, rep_0, bpaadd_0, typ_0 "
        Sql &= "FROM xcotiza xco INNER JOIN "
        Sql &= "     bpcustomer bpc ON (xco.bpcnum_0 = bpc.bpcnum_0) INNER JOIN "
        Sql &= "     xnetvenc xnet ON (bpc.rep_0 = xnet.rep_0 AND (abo_0 = 1 OR noabo_0 = 1)) "
        Sql &= "WHERE usr_0 = '" & usr.Codigo & "' "

        If chkPedidos.Checked Or chkRecargas.Checked Then
            Sql &= "AND soh_0 = ' ' AND sqh_0 <> ' ' AND typ_0 = 2 AND dat_0 > trunc(sysdate-30) AND xduplica_0 <> 2 "

        Else

            If usr.Permiso.AccesoSecundario(43, "V") Then
                If chkPendiente.Checked Then
                    Sql &= "AND estado_0 = 1 AND (typ_0 = 1 AND soh_0 = ' ' OR typ_0 = 2 AND sqh_0 = ' ') AND xduplica_0 <> 2 "
                End If

                If rbCaa.Checked Then
                    Sql &= "AND bpc.rep_0 IN ('CA', 'CAA') "
                End If
                If rbVendedores.Checked Then
                    Sql &= "AND bpc.rep_0 NOT IN ('CA', 'CAA') "
                End If

            Else

                If chkPendiente.Checked Then
                    Sql &= "AND (typ_0 = 1 AND soh_0 = ' ' OR typ_0 = 2 AND sqh_0 = ' ') AND xduplica_0 <> 2 "
                End If

            End If

            If txtBuscar.Text.Trim <> "" Then
                Sql &= "AND bpc.bpcnum_0 = '" & txtBuscar.Text.Trim & "'"
            End If

        End If
        Sql &= " ORDER BY nro_0 DESC"

        da = New OracleDataAdapter(Sql, cn)

        If dgv2.DataSource Is Nothing Then
            dt = New DataTable
            dv = New DataView(dt)
        Else
            dt = CType(dgv2.DataSource, DataView).Table
        End If

        dt.Clear()
        da.Fill(dt)
        da.Dispose()

        If chkPedidos.Checked Then
            Dim ctz As New Cotizacion(cn)

            For Each dr As DataRow In dt.Rows()
                ctz.Abrir(CLng(dr("nro_0")))
                If Not ctz.TieneArticulosTipo(2) Then dr.Delete()
            Next
            ctz = Nothing

        End If
        If chkRecargas.Checked Then
            Dim ctz As New Cotizacion(cn)

            For Each dr As DataRow In dt.Rows()
                ctz.Abrir(CLng(dr("nro_0")))
                If Not ctz.TieneArticulosTipo(1) Then
                    dr.Delete()
                Else
                    If ctz.TieneIntervencion() Then dr.Delete()
                End If
            Next
            ctz = Nothing
        End If

        If dgv2.DataSource Is Nothing Then
            col2Nro.DataPropertyName = "nro_0"
            col2Fecha.DataPropertyName = "dat_0"
            col2Cliente.DataPropertyName = "bpcnum_0"
            col2Nombre.DataPropertyName = "bpcnam_0"
            col2Vend.DataPropertyName = "rep_0"
            suc.DataPropertyName = "bpaadd_0"

            'ComboBox Tipo Lateral
            Dim mnu As MenuLocal
            mnu = New MenuLocal(cn, 1, True)
            mnu.ModificarTexto(1, "Pedido")
            mnu.ModificarTexto(2, "Presupuesto")
            mnu.Enlazar(cboTipo2)
            cboTipo2.DataPropertyName = "typ_0"

            dgv2.DataSource = dv
        End If

        btnBuscar.Enabled = True
        Application.DoEvents()

    End Sub

    'BOTONES SUPERIORES
    Private Sub btnNuevoPedido_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevoPedido.Click
        Nuevo(1)
    End Sub
    Private Sub btnNuevoPresupuesto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevoPresupuesto.Click
        Nuevo(2)
    End Sub
    Public Sub Nuevo(ByVal tipo As Integer)
        Dim flg As Boolean = False

        dgv.Enabled = True
        NumeroCotizacionAnterior = 0

        cboTipo.SelectedValue = tipo

        ctz.Nuevo(tipo)
        gbxCliente.Enabled = True

        ActualizarDatos = False
        ActualizarDatosControles()
        ActualizarDatos = True

        txtCodigoCliente.Focus()

    End Sub
    'CLIENTE
    Private Sub txtCodigoCliente_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodigoCliente.Validated
        Dim txt As TextBox = CType(sender, TextBox)

        SetCliente(txt.Text)

    End Sub
    Private Sub txtCodigoCliente_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodigoCliente.Validating
        Dim txt As TextBox = CType(sender, TextBox)
        Dim bpc As New Cliente(cn)
        Dim flg As Boolean = True

        'Salto si el campo está en blanco
        If txt.Text.Trim = "" Then Exit Sub
        'Salto si no se modifico el numero de cliente
        If ctz.Cliente IsNot Nothing AndAlso txt.Text.Trim = ctz.Cliente.Codigo Then Exit Sub
        'Intento abrir el numero de cliente ingresado
        If bpc.Abrir(txt.Text.Trim) Then
            'Controlo que el cliente sea del vendedor
            If bpc.Vendedor.Codigo <> usr.Codigo AndAlso _
                bpc.Vendedor.Analista.Codigo <> usr.Codigo AndAlso _
                bpc.AccesoUsuario(usr.Codigo) = False Then

                e.Cancel = True
                MessageBox.Show("No tiene acceso a este cliente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)

            ElseIf Not bpc.Activo OrElse bpc.Bloqueado Then
                e.Cancel = True
                MessageBox.Show("Cliente bloqueado o no está activo", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)

            ElseIf bpc.Activo = False OrElse bpc.Bloqueado = True Then
                e.Cancel = True
                MessageBox.Show("Cliente Bloqueado o no Activo", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)

            End If

        Else
            e.Cancel = True
            MessageBox.Show("Cliente no encontrado", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)

        End If

    End Sub
    Private Sub cboCondicionPago_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCondicionPago.SelectedIndexChanged
        If ctz.Cliente Is Nothing Then Exit Sub

        If cboCondicionPago.SelectedValue IsNot Nothing Then
            ctz.CondicionPago = cboCondicionPago.SelectedValue.ToString
            If ActualizarDatos Then ActualizarDatosControles()
        End If

    End Sub
    Private Sub chkFcRto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFcRto.CheckedChanged
        ctz.FcRto = chkFcRto.Checked
        If ActualizarDatos Then ActualizarDatosControles()
    End Sub
    'SUCURSAL
    Private Sub txtCodigoSucursal_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodigoSucursal.Validated
        Dim txt As TextBox = CType(sender, TextBox)

        SetSucursal(txt.Text)

    End Sub
    Private Sub txtCodigoSucursal_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodigoSucursal.Validating
        Dim txt As TextBox = CType(sender, TextBox)
        Dim bpa As New Sucursal(cn)

        'Salto si el campo está en blanco
        If txt.Text.Trim = "" Then Exit Sub
        'Salto si no se modifico el numero de sucursal
        If ctz.Sucursal IsNot Nothing AndAlso txt.Text.Trim = ctz.Sucursal.Codigo Then Exit Sub
        'Intento abrir el numero de sucursal
        If Not bpa.Abrir(ctz.Cliente.Codigo, txt.Text.Trim) Then
            MessageBox.Show("Sucursal no encontrada", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            e.Cancel = True
            Exit Sub
        End If
        'Verifico que sea sucursal de entrega
        If ctz.Tipo = 1 AndAlso Not bpa.EsDireccionEntrega Then
            MessageBox.Show("No es sucursal entrega o está inactiva", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            e.Cancel = True
            Exit Sub
        End If

    End Sub
    Private Sub cboEntrega_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboEntrega.SelectedIndexChanged
        Dim cbo As ComboBox = CType(sender, ComboBox)
        If cboEntrega.SelectedValue Is Nothing Then Exit Sub
        If cbo.SelectedValue.ToString.Length > 1 Then Exit Sub
        ctz.ModoEntrega = cbo.SelectedValue.ToString
        If ActualizarDatos Then ActualizarDatosControles()
    End Sub
    Private Sub txtCodigoExpreso_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodigoExpreso.Validated
        Dim txt As TextBox = CType(sender, TextBox)

        If txt.Text = "" And ctz.ExpresoCodigo.Trim <> "" Then
            ctz.SetExpreso()
        Else
            If ctz.ExpresoCodigo.Trim <> txt.Text Then
                ctz.SetExpreso(txt.Text)
            End If
        End If

        If ActualizarDatos Then ActualizarDatosControles()

    End Sub
    Private Sub txtCodigoExpreso_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodigoExpreso.Validating
        Dim txt As TextBox = CType(sender, TextBox)
        Dim exp As New Expreso(cn)

        'Salto si el campo está en blanco
        If txt.Text.Trim = "" Then Exit Sub
        'Salto si no se modifico el numero de expreso
        If ctz.Expreso IsNot Nothing AndAlso txt.Text.Trim = ctz.ExpresoCodigo.Trim Then Exit Sub
        'Intento abrir el numero de expreso
        If Not exp.Abrir(txt.Text.Trim) Then
            MessageBox.Show("Expreso no encontrado", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            e.Cancel = True
            Exit Sub
        End If
    End Sub
    'ORDEN DE COMPRA
    Private Sub txtOC_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOC.TextChanged
        btnExaminarOt.Enabled = txtOC.Text.Trim.Length > 0
    End Sub
    Private Sub txtOC_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtOC.Validating
        If ctz.OCF.Trim <> "" And txtOC.Text.Trim = "" Then
            MessageBox.Show("Este campo es obligatorio si existe un archivo de OC cargado", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            e.Cancel = True
        End If
    End Sub
    Private Sub txtOC_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOC.LostFocus
        Dim txt As TextBox = CType(sender, TextBox)
        txt.Text = txt.Text.Trim
        ctz.OC = txt.Text
        If ActualizarDatos Then ActualizarDatosControles()
    End Sub
    Private Sub btnExaminarOt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExaminarOt.Click
        Dim openFileDialog1 As New OpenFileDialog()

        openFileDialog1.InitialDirectory = "c:\"
        openFileDialog1.Filter = "Archivos Adobe PDF (*.pdf)|*.pdf" '|All files (*.*)|*.*"
        openFileDialog1.FilterIndex = 1
        openFileDialog1.RestoreDirectory = True

        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Dim Archivo As String = ctz.Cliente.Codigo & "-" & txtOC.Text.Trim & ".pdf"

            Try
                File.Copy(openFileDialog1.FileName, PATH_OC & Archivo, True)
                ctz.OCF = Archivo
                If ActualizarDatos Then ActualizarDatosControles()

            Catch ex As Exception
                MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If
    End Sub
    Private Sub btnVerOt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVerOt.Click
        Try
            Process.Start(PATH_OC & ctz.OCF)
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnBorrarOt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrarOt.Click
        Dim resultado As DialogResult = MessageBox.Show("Realmente quiere borrar la OC", "Aviso", MessageBoxButtons.YesNo)

        If resultado = Windows.Forms.DialogResult.Yes Then
            Try
                If File.Exists(PATH_OC & ctz.OCF) Then File.Delete(PATH_OC & ctz.OCF)
                ctz.OCF = ""
                ctz.OC = ""
                If ActualizarDatos Then ActualizarDatosControles()

            Catch ex As Exception
                MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
    'SOCIEDAD
    Private Sub cboSociedad_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSociedad.SelectedIndexChanged
        Dim cbo As ComboBox = CType(sender, ComboBox)

        If cbo.SelectedValue.ToString.Length > 3 Then Exit Sub
        ctz.SociedadCodigo = cbo.SelectedValue.ToString
        If ActualizarDatos Then ActualizarDatosControles()
    End Sub
    Private Sub chkH_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkH.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        ctz.H = chk.Checked
        If ActualizarDatos Then ActualizarDatosControles()
    End Sub
    'GRILLA
    Private Sub dgv_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgv.CellBeginEdit
        On Error Resume Next

        If dgv.Columns(e.ColumnIndex).Name = "colSugerido" Then
            e.Cancel = True

        ElseIf dgv.Columns(e.ColumnIndex).Name = "colTotal" Then
            e.Cancel = True

        End If

    End Sub
    Private Sub dgv_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dgv.CellValidating
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
                Case "colCodigo"
                    If c.Value.ToString = e.FormattedValue.ToString Then Exit Sub

                    'Consulto que el codigo existe en la lista de precios
                    If Not ctz.ExisteArticulo(e.FormattedValue.ToString) Then
                        MessageBox.Show("Artículo no encontrado: " & e.FormattedValue.ToString)
                        e.Cancel = True
                    Else
                        'Valido que el articulo esté activo
                        Dim itm As New Articulo(cn)
                        itm.Abrir(e.FormattedValue.ToString)
                        If Not itm.Activo Then
                            MessageBox.Show("Artículo ináctivo: " & e.FormattedValue.ToString)
                            e.Cancel = True
                        End If
                    End If

                Case "colCant"
                    If IsDBNull(c.Value) = True Then Exit Sub
                    If CDbl(c.Value) = CDbl(e.FormattedValue) Then Exit Sub
            End Select

        End If

    End Sub
    Private Sub dgv_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellValidated
        Dim o As DataGridView = CType(sender, DataGridView)
        Dim r As DataGridViewRow = o.Rows(e.RowIndex)
        Dim c As DataGridViewCell = r.Cells(e.ColumnIndex)

        If c.IsInEditMode Then
            'Validación segun columna
            Select Case o.Columns(e.ColumnIndex).Name
                Case "colCodigo"
                    r.Cells("colCant").Value = 0
                    r.Cells("colPrecio").Value = 0
                    r.Cells("colSugerido").Value = 0
                    r.Cells("colTotal").Value = 0

                Case "colDescripcion"
                    r.Cells("colCant").Value = 0
                    r.Cells("colPrecio").Value = 0
                    r.Cells("colSugerido").Value = 0
                    r.Cells("colTotal").Value = 0

                Case "colCant"
                    'Busco el precio según cantidad
                    If ctz.ExisteArticulo(r.Cells("colCodigo").Value.ToString) Then
                        r.Cells("colPrecio").Value = ctz.Precio(r.Cells("colCodigo").Value.ToString, CDbl(r.Cells("colCant").Value))
                        r.Cells("colSugerido").Value = ctz.Precio(r.Cells("colCodigo").Value.ToString, CDbl(r.Cells("colCant").Value))
                    End If

                    TotalLinea(r)

                Case "colPrecio"
                    TotalLinea(r)

            End Select

        End If

    End Sub
    Private Sub dgv_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgv.CellFormatting
        On Error Resume Next

        Dim o As DataGridView = CType(sender, DataGridView)
        Dim r As DataGridViewRow = o.Rows(e.RowIndex)
        Dim c As DataGridViewCell
        Dim col As System.Drawing.Color

        If IsDBNull(r.Cells("colPrecio").Value) OrElse IsDBNull(r.Cells("colSugerido")) Then
            col = Drawing.Color.White

        Else
            Dim p1 As Double = CDbl(r.Cells("colPrecio").Value)
            Dim p2 As Double = CDbl(r.Cells("colSugerido").Value)
            p2 = p2 * ctz.PORCENTAJE_DESCUENTO_AUTORIZADO

            If p1 < p2 Then
                col = Drawing.Color.LightPink

            Else
                col = Drawing.Color.LightGreen

            End If

        End If

        For Each c In r.Cells
            c.Style.BackColor = col
        Next

    End Sub
    Private Sub dgv_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgv.DataError
        MessageBox.Show("Valor inválido", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        e.Cancel = True
    End Sub
    Private Sub dgv_RowValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.RowValidated
        txtTotalAI.Text = ctz.PrecioTotalAI.ToString("N2")
    End Sub
    'BOTONES INFERIORES
    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        Dim txt As String = ""

        'VALIDACION 2 - Si tiene articulo 705020 se fije en cap o prov 
        If ctz.Cliente.Sucursal(txtCodigoSucursal.Text.ToString).Provincia = "CFE" Then
            If ctz.TieneArticulosCFE Then
                txt = "ATENCIÓN: El pedido es para capital y no se cargaron tarjetas"
                MessageBox.Show(txt, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        ElseIf ctz.TieneArticuloBUE Then
            txt = "ATENCIÓN: El domicilio cargado es en provincia y se le cargaron tarjetas de capital"
            MessageBox.Show(txt, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

        'VALIDACION 2.1 - CANTIDAD DE TARJETAS / EXTINTORES
        'If Not ctz.RelacionTarjetasExtintores Then
        '    txt = "ATENCIÓN: La cantidad de tarjetas y extintores no son iguales"
        '    MessageBox.Show(txt, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        'End If

        'VALIDACION 3 - EXTINTORES 1KG 3" 
        If Not ctz.Extintores3pulgadas Then
            txt = "La caja de extintores de 3"" es de 6 unidades"
            MessageBox.Show(txt, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        'VALIDACION 3 - EXTINTORES 1KG 4" 
        If Not ctz.Extintores4pulgadas Then
            txt = "La caja de extintores de 4"" es de 12 unidades"
            MessageBox.Show(txt, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

        If Not ValidarTelefonoContacto() Then Exit Sub

        If Grabar() Then

            'If ctz.TipoCambio = 0 Then
            '    ctz.TipoCambio = TipoCambio
            '    ctz.Grabar()
            'End If

            cboTipo.Enabled = False

            If ActualizarDatos Then ActualizarDatosControles()

        Else
            MostrarErrores()

        End If

    End Sub
    Private Function Grabar() As Boolean

        If Not ctz.Grabar() Then Return False

        If NumeroCotizacionAnterior <> 0 Then
            Dim ctz2 As New Cotizacion(cn)

            ctz2.Abrir(NumeroCotizacionAnterior)

            If Not ctz2.EsDuplicado Then
                ctz2.EsDuplicado = True
                ctz2.Grabar()

                'LICITACIONES - Aviso de duplicacion
                If CInt(cboLicitacion.SelectedValue) > 1 And txtPresupuesto.Text <> "" Then
                    EnviarMailLicitacion("Duplicacion de presupuesto de Licitacion", "")
                End If

            End If

        End If

        Return True

    End Function
    Private Sub btnBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrar.Click

        If MessageBox.Show("¿Confirma borrar la cotización?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            Try
                ActualizarDatos = False
                If ctz.Borrar() Then
                    File.Delete("\\srv\Z\OC\" & ctz.Cliente.Codigo & "-" & txtOC.Text.Trim & ".pdf")
                End If

                Nuevo(2)

            Catch ex As Exception
                MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End If

        MessageBox.Show("La cotización fue borrada", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub
    Private Sub btnDuplicar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDuplicar.Click
        If txtNro.Text = "" Then Exit Sub

        If MessageBox.Show("¿Confirma duplicar esta cotización?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            NumeroCotizacionAnterior = CLng(txtNro.Text)
            ctz.Duplicar()
            ctz.CotizacionOrigen = CInt(NumeroCotizacionAnterior)
            ActualizarDatos = False
            ActualizarDatosControles()
            ActualizarDatos = True

            cboTipo.Enabled = True

        End If

    End Sub
    Private Sub btnPedido_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPedido.Click
        Dim Alertas As ArrayList
        Dim Errores As ArrayList

        'Dim sqh As New Presupuesto(cn)
        Dim ok As Boolean = True
        Dim msg1 As String = "" 'Mensajes de Alertas
        Dim msg2 As String = "" 'Mensajes de Errores

        Dim txt As String = ""

        If EsPresupuestoAgua() And ctz.PresupuestoAdonix = "" Then
            MessageBox.Show("Para pedidos de agua primero se debe generar presupuesto", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        Alertas = ctz.Alertas(1)

        If Alertas.Count > 0 Then
            For Each txt In Alertas
                msg1 &= txt & vbCrLf
            Next
        End If

        'Errores que no permiten crear el pedido a ningun usuario
        Errores = ctz.ErroresPedido

        If Errores.Count > 0 Then
            For Each txt In Errores
                msg2 &= txt & vbCrLf
            Next
            MessageBox.Show(msg1 & vbCrLf & msg2, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        txt = ""

        If CInt(cboTipo.SelectedValue) <> 1 And ctz.PresupuestoAdonix = "" And Alertas.Count = 0 Then
            txt = "Esta cotización fue creada para hacer un presupuesto" & vbCrLf
            txt &= "¿Confirma crear un PEDIDO?"

            If MessageBox.Show(txt, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                ok = False
            End If
        End If

        'Se muestran las alertas. Si el usuario es administrador puede autorizar crear el pedido
        If ok AndAlso Alertas.Count > 0 Then
            txt = msg1

            If usr.Permiso.AccesoSecundario(43, "V") Then

                txt &= "" & vbCrLf
                txt &= "¿Confirma la creación?"

                If MessageBox.Show(txt, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                    ok = False
                End If

            Else
                'Si existe un presupuesto creado se cambia tipo de cotizacion a pedido para que le aparezca al supervisor
                If ctz.PresupuestoAdonix.Trim <> "" Then

                    txt &= "" & vbCrLf
                    txt &= "¿Quiere enviar el pedido a autorizar por un supervisor?"

                    If MessageBox.Show(txt, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                        If ctz.Tipo <> 1 Then
                            ctz.Tipo = 1
                            ctz.Grabar()
                            cboTipo.SelectedValue = ctz.Tipo
                        End If
                    End If

                    ok = False

                End If

                If ok Then MessageBox.Show(txt, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ok = False

            End If

        End If

        If ok Then
            'Vuelvo a abrir la cotización para chequear que otro usuario haya creado el pedido
            ctz.Abrir(ctz.Numero)

            'Se crea el pedido en Adonix
            If ctz.PedidoAdonix = "" Then
                Dim soh As Pedido

                soh = ctz.ConvertirEnPedido()

                If ctz.PresupuestoAdonix <> "" Then
                    soh.PresupuestoNumero = ctz.PresupuestoAdonix
                    soh.Grabar()
                End If
                'ctz.Pedido.TipoCambio = TipoCambio
                'ctz.Pedido.Grabar()

                If ActualizarDatos Then ActualizarDatosControles()

                If (ctz.OC.Trim = "" Or txtOC.Text.Trim = "") And ctz.Cliente.OC_obligatoria Then
                    Dim mail As New CorreoElectronico

                    With mail
                        .Nuevo()
                        .Remitente("noreply@matafuegosgeorgia.com", "Georgia Seguridad contra Incendios")
                        .AgregarDestinatario("jrodriguez@georgia.com.ar", False)
                        .Asunto = "Pedido creado sin OC"
                        .Cuerpo = "El cliente: " & ctz.Cliente.Codigo & "-" & ctz.Cliente.Nombre & ", con el pedido: " & ctz.PedidoAdonix & " fue creado sin OC "
                        If DB_USR = "GEOPROD" Then .Enviar()
                    End With
                End If

                'Si es licitacion se manda mail de aviso
                If CInt(cboLicitacion.SelectedValue) > 1 And txtPresupuesto.Text <> "" Then
                    EnviarMailLicitacion("Se creo un pedido para licitacion", "")
                End If

            End If

        End If

        Alerta639Pendientes()

    End Sub
    Private Sub btnPresupuesto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPresupuesto.Click
        Dim Alertas As ArrayList
        Dim msg As String = ""
        Dim txt As String = ""
        Dim ok As Boolean = True

        Alertas = ctz.Alertas

        If CInt(cboTipo.SelectedValue) <> 2 And Alertas.Count = 0 Then
            txt = "Esta cotización fue creada para hacer un pedido" & vbCrLf
            txt &= "¿Confirma crear un PRESUPUESTO?"

            If MessageBox.Show(txt, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                ok = False
            End If

        End If

        If ok AndAlso Alertas.Count > 0 Then

            For Each txt In Alertas
                msg &= txt & vbCrLf
            Next

            If usr.Permiso.AccesoSecundario(43, "V") Then
                msg &= "" & vbCrLf
                msg &= "¿Confirma la creación?"

                If MessageBox.Show(msg, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                    ok = False
                End If

            Else
                MessageBox.Show(msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ok = False
            End If

        End If

        If ok Then
            Dim Sqh As Presupuesto

            Sqh = ctz.ConvertirEnPresupuesto()

            'Si es presupuesto de agua, pego la comision segun tabla
            If EsPresupuestoAgua() Then
                Dim ComiAgua As New ComisionAgua(cn)

                Sqh.Comision = ComiAgua.ObtenerAlicuota(Sqh.TotalAI)
                Sqh.Grabar()

            End If

            '05.09.2018 Se graba el tipo de cambio
            'Sqh.TipoCambio = TipoCambio
            'Sqh.Grabar()

            If ActualizarDatos Then ActualizarDatosControles()

            'LICITACIONES
            If CInt(cboLicitacion.SelectedValue) > 1 Then

                Dim lic As New Licitacion(cn)

                sqh.Abrir(ctz.PresupuestoAdonix)

                sqh.CrearLicitacion(sqh.TipoLicitacion, sqh.NumeroLicitacion)

            End If

            EnviarPresupuestoPorMail()

        End If

        Alerta639Pendientes()

        Grabar()

    End Sub
    Private Sub ctz_PresupuestoModificado(ByVal sender As Object) Handles ctz.PresupuestoModificado
        If ActualizarDatos Then ActualizarDatosControles()
    End Sub
    Private Sub txtObs_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtObs.LostFocus
        If ctz.Obs = txtObs.Text Then Exit Sub
        ctz.Obs = txtObs.Text
        If ActualizarDatos Then ActualizarDatosControles()
    End Sub
    Private Sub TotalLinea(ByVal r As DataGridViewRow)
        Dim c As Double ' Cantidad
        Dim p As Double 'Precio Unitario
        Dim t As Double 'Total linea

        If IsDBNull(r.Cells("colCant").Value) Then
            c = 0
        Else
            c = CDbl(r.Cells("colCant").Value)
        End If
        If IsDBNull(r.Cells("colPrecio").Value) Then
            p = 0
        Else
            p = CDbl(r.Cells("colPrecio").Value)
        End If

        t = c * p

        r.Cells("colTotal").Value = t

    End Sub
    Private Sub MostrarErrores()
        Dim Errores As ArrayList = ctz.Errores
        Dim msg As String = ""

        For Each txt As String In Errores
            msg &= txt & vbCrLf
        Next

        MessageBox.Show(msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)

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
    Private Sub ActualizarDatosControles()

        txtDesaprobado.Visible = False

        txtCodigoCliente.ReadOnly = Not (ctz.PresupuestoAdonix = "" And ctz.PedidoAdonix = "")
        cboCondicionPago.Enabled = ctz.PedidoAdonix = "" '(ctz.PresupuestoAdonix = "")
        chkFcRto.Enabled = (ctz.PresupuestoAdonix = "" And ctz.PedidoAdonix = "")
        chkAVentas.Enabled = (ctz.PresupuestoAdonix = "" And ctz.PedidoAdonix = "")

        gbxSucursal.Enabled = ctz.Cliente IsNot Nothing AndAlso (ctz.PresupuestoAdonix = "" OrElse ctz.PedidoAdonix = "")
        gbxOc.Enabled = ctz.Cliente IsNot Nothing AndAlso (ctz.PresupuestoAdonix = "" OrElse ctz.PedidoAdonix = "")
        gbxSociedad.Enabled = ctz.Cliente IsNot Nothing AndAlso (ctz.PresupuestoAdonix = "" AndAlso ctz.PedidoAdonix = "")
        gbxLicitacion.Enabled = ctz.Cliente IsNot Nothing AndAlso (ctz.PresupuestoAdonix = "" OrElse ctz.PedidoAdonix = "")
        dgv.AllowUserToAddRows = ctz.Cliente IsNot Nothing AndAlso (ctz.PresupuestoAdonix = "" AndAlso ctz.PedidoAdonix = "")
        dgv.AllowUserToDeleteRows = ctz.Cliente IsNot Nothing AndAlso (ctz.PresupuestoAdonix = "" AndAlso ctz.PedidoAdonix = "")

        dgv.ReadOnly = ctz.Cliente IsNot Nothing AndAlso (ctz.PresupuestoAdonix <> "" OrElse ctz.PedidoAdonix <> "")

        btnGrabar.Enabled = ctz.HasChanges
        btnDuplicar.Enabled = ctz.Numero > 0 AndAlso (ctz.PedidoAdonix <> "" OrElse ctz.PresupuestoAdonix <> "")
        btnBorrar.Enabled = ctz.Numero > 0 AndAlso ctz.PedidoAdonix = "" AndAlso ctz.PresupuestoAdonix = ""

        btnRechazo.Enabled = gbxSociedad.Enabled AndAlso ctz.PedidoAdonix = ""

        btnDesaprobar.Enabled = ctz.Numero > 0 AndAlso ctz.PresupuestoAdonix <> "" AndAlso ctz.PedidoAdonix = ""

        If btnDesaprobar.Enabled Then
            Dim sqh As New Presupuesto(cn)
            sqh.Abrir(ctz.PresupuestoAdonix)

            btnDesaprobar.Enabled = (sqh.EstadoAprobacion = 0)

            txtDesaprobado.Visible = (sqh.EstadoAprobacion = 3)
        End If

        btnPresupuesto.Enabled = ctz.Numero > 0 AndAlso ctz.PresupuestoAdonix = "" AndAlso ctz.PedidoAdonix = "" AndAlso ctz.HasChanges = False
        btnPedido.Enabled = ctz.Numero > 0 AndAlso ctz.PedidoAdonix = "" AndAlso ctz.HasChanges = False


        btnExaminarOt.Enabled = ctz.OC.Trim <> ""
        btnBorrarOt.Enabled = ctz.OCF.Trim <> ""
        btnVerOt.Enabled = ctz.OCF.Trim <> ""

        btnFlete.Enabled = (ctz.PedidoAdonix = "" And ctz.PresupuestoAdonix = "")

        If ctz.Cliente Is Nothing Then
            txtCodigoCliente.Clear()
            txtNombreCliente.Clear()
            txtClase.Clear()

        Else
            txtCodigoCliente.Text = ctz.Cliente.Codigo
            txtNombreCliente.Text = ctz.Cliente.Nombre

            If ctz.Cliente.TerceroPagador.Codigo.Trim <> "" Then
                txtClase.Text = ctz.Cliente.TerceroPagador.TipoAbcStr
            Else
                txtClase.Text = ctz.Cliente.TipoAbcStr
            End If

        End If

        If ctz.Sucursal Is Nothing Then
            txtCodigoSucursal.Clear()
            txtDomicilio.Clear()
            txtLocalidad.Clear()
            txtNombreContacto.Clear()
            txtCelularContacto.Clear()
            txtCodigoExpreso.Clear()
            txtDesde1.Clear()
            txtDesde2.Clear()
            txtHasta1.Clear()
            txtHasta2.Clear()
            chkMunro.Checked = False

        Else
            txtCodigoSucursal.Text = ctz.Sucursal.Sucursal
            txtDomicilio.Text = ctz.Sucursal.Direccion
            txtLocalidad.Text = ctz.Sucursal.Ciudad
            txtNombreContacto.Text = ctz.Sucursal.Portero
            txtCelularContacto.Text = ctz.Sucursal.Telefono_Portero
            txtCodigoExpreso.Text = ctz.ExpresoCodigo.Trim
            txtDesde1.Text = ctz.HoraMananaDesde
            txtHasta1.Text = ctz.HoraMananaHasta
            txtDesde2.Text = ctz.HoraTardeDesde
            txtHasta2.Text = ctz.HoraTardeHasta
            chkMunro.Checked = ctz.SaleDesdeMunro

        End If

        cboEntrega.SelectedValue = ctz.ModoEntrega

        txtDesde1.Enabled = txtCodigoSucursal.Text.Trim <> ""
        txtDesde2.Enabled = txtCodigoSucursal.Text.Trim <> ""
        txtHasta1.Enabled = txtCodigoSucursal.Text.Trim <> ""
        txtHasta2.Enabled = txtCodigoSucursal.Text.Trim <> ""
        chkMunro.Enabled = txtCodigoSucursal.Text.Trim <> ""
        txtCodigoExpreso.Enabled = txtCodigoSucursal.Text.Trim <> ""
        txtCodigoSucursal.ReadOnly = ctz.Cliente IsNot Nothing AndAlso (ctz.PresupuestoAdonix <> "" OrElse ctz.PedidoAdonix <> "")

        If ctz Is Nothing OrElse ctz.Expreso Is Nothing Then
            txtCodigoExpreso.Clear()
            txtNombreExpreso.Clear()
        Else
            txtCodigoExpreso.Text = ctz.ExpresoCodigo.Trim
            txtNombreExpreso.Text = ctz.Expreso.Nombre
        End If

        cboLicitacion.SelectedValue = ctz.TipoLicitacion
        txtLicitacion.Text = ctz.NumeroLicitacion

        txtNro.Text = IIf(ctz.Numero = 0, "", ctz.Numero).ToString
        txtFecha.Text = IIf(ctz.Numero = 0, "", ctz.Fecha.ToString("dd/MM/yyyy")).ToString
        cboTipo.SelectedValue = ctz.Tipo
        cboSociedad.SelectedValue = ctz.SociedadCodigo
        chkH.Checked = ctz.H
        cboCondicionPago.SelectedValue = ctz.CondicionPago
        cboEstado.SelectedValue = ctz.Estado
        txtOC.Text = ctz.OC
        txtObs.Text = ctz.Obs
        txtTotalAI.Text = ctz.PrecioTotalAI.ToString("N2")
        txtTotalII.Text = ctz.PrecioTotalII.ToString("N2")
        txtPresupuesto.Text = ctz.PresupuestoAdonix
        txtPedido.Text = ctz.PedidoAdonix
        chkFcRto.Checked = ctz.FcRto
        txtIntervencionRechazo.Text = ctz.IntervencionRechazo
        chkAVentas.Checked = ctz.AVentasAntesEntregar

    End Sub
    Private Sub cms_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cms.Opening

        If txtCodigoCliente.Focused Then
            mnuSeleccionar.Enabled = Not txtCodigoCliente.ReadOnly
            mnuEditar.Enabled = ctz.Cliente IsNot Nothing

        ElseIf txtCodigoSucursal.Focused Then
            mnuSeleccionar.Enabled = txtCodigoSucursal.ReadOnly = False
            mnuEditar.Enabled = ctz.Sucursal IsNot Nothing AndAlso ctz.PedidoAdonix.Trim = ""

        ElseIf txtPresupuesto.Focused Then
            mnuAbrirPresupuesto.Enabled = txtPresupuesto.Text.Trim <> ""

        ElseIf txtCodigoExpreso.Focused Then
            mnuSeleccionar.Visible = ctz.Sucursal IsNot Nothing
            mnuEditar.Enabled = False

        End If

        mnuSeleccionar.Visible = Not txtPresupuesto.Focused
        mnuEditar.Visible = Not txtPresupuesto.Focused
        mnuAbrirPresupuesto.Visible = txtPresupuesto.Focused

    End Sub
    Private Sub mnuSeleccionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSeleccionar.Click
        If txtCodigoCliente.Focused Then AbrirSelectorCliente()
        If txtCodigoSucursal.Focused Then AbrirSelectorSucursal()
        If txtCodigoExpreso.Focused Then AbrirSelectorExpreso()
    End Sub
    Private Sub mnuEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEditar.Click
        If txtCodigoCliente.Focused Then
            Dim f As New frmCliente(ctz.Cliente)

            'Configuración de la pantalla
            With f
                f.BloquearEdicionDeCampos()
                'Muestro la pantalla
                f.ShowDialog(Me)
            End With
            f.Dispose()

        ElseIf txtCodigoSucursal.Focused Then
            Dim f As New frmSucursal(ctz.Cliente, ctz.Sucursal)

            With f
                .GrabarAlSalir = True
                .gbSucursal.Enabled = False
                .ShowDialog(Me)

                If .DialogResult = Windows.Forms.DialogResult.OK Then
                    ctz.SetSucursal()
                End If
            End With
            f.Dispose()

        End If
    End Sub
    Private Sub mnuAbrirPresupuesto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAbrirPresupuesto.Click
        Dim rpt As New ReportDocument
        Dim f As frmCrystal

        'Genero el PDF con la cotizacion
        If ctz.Cliente.EsProspecto Then
            rpt.Load(RPTX3 & "DEVTTC.rpt")
        Else
            rpt.Load(RPTX3 & "DEVTTC2.rpt")
        End If
        rpt.SetDatabaseLogon(DB_USR, DB_PWD)
        rpt.SetParameterValue("devisdeb", txtPresupuesto.Text)
        rpt.SetParameterValue("devisfin", txtPresupuesto.Text)

        f = New frmCrystal(rpt)
        f.MdiParent = Me.ParentForm
        f.Show()

    End Sub
    Private Sub AbrirSelectorCliente()
        Dim f As New frmSelectorClientes
        f.ShowDialog(Me)

        If f.DialogResult = Windows.Forms.DialogResult.OK Then
            txtCodigoCliente.Text = f.ClienteSeleccionado
        End If
        f.Dispose()

    End Sub
    Private Sub AbrirSelectorSucursal()
        If txtCodigoCliente.Text = "" Then Exit Sub

        Dim f As New frmSelectorSucursal(txtCodigoCliente.Text)
        f.ShowDialog(Me)

        If f.DialogResult = Windows.Forms.DialogResult.OK Then
            txtCodigoSucursal.Text = f.SucursalSeleccionada
        End If
        f.Dispose()

    End Sub
    Private Sub AbrirSelectorExpreso()
        Dim f As New frmSelectorExpreso()
        f.ShowDialog(Me)

        If f.DialogResult = Windows.Forms.DialogResult.OK Then
            txtCodigoExpreso.Text = f.Seleccion
        End If
        f.Dispose()

    End Sub
    Private Sub EnviarPresupuestoPorMail()
        'Envia el presupuesto por mail al vendedor
        Dim rpt As New ReportDocument
        Dim Archivo As String = ctz.PresupuestoAdonix & ".pdf"
        Dim eml As New CorreoElectronico

        If DB_USR <> "GEOPROD" Then
            If MessageBox.Show("¿Enviar mail?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If
        End If

        Try
            'Genero el PDF con la cotizacion
            If ctz.TieneArticulo("551015") Then

                rpt.Load(RPTX3 & "XSISFI1.rpt")
                rpt.SetDatabaseLogon(DB_USR, DB_PWD)
                rpt.SetParameterValue("SQHNUM", ctz.PresupuestoAdonix)

            ElseIf ctz.TieneArticulo("551016") Then

                rpt.Load(RPTX3 & "XSISFI2.rpt")
                rpt.SetDatabaseLogon(DB_USR, DB_PWD)
                rpt.SetParameterValue("SQHNUM", ctz.PresupuestoAdonix)

            Else

                If ctz.Cliente.EsProspecto Then
                    rpt.Load(RPTX3 & "DEVTTC.rpt")
                Else
                    rpt.Load(RPTX3 & "DEVTTC2.rpt")
                End If

                rpt.SetDatabaseLogon(DB_USR, DB_PWD)
                rpt.SetParameterValue("X3DOS", X3DOS)
                rpt.SetParameterValue("devisdeb", ctz.PresupuestoAdonix)
                rpt.SetParameterValue("devisfin", ctz.PresupuestoAdonix)

            End If

            rpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Archivo)

            eml.EsHtml = True
            eml.Remitente(usr.Mail, usr.Nombre)
            eml.Asunto = "Presupuesto " & ctz.PresupuestoAdonix & " GEORGIA Seguridad contra Incendios"
            eml.AdjuntarArchivo(Archivo)
            eml.CuerpoDesdeArchivo("plantillas\presupuesto.html")

            If Aviso639() Then
                eml.Cuerpo = eml.Cuerpo.Replace("<!--BONIFICACION-->", "Contratando el servicio de recargas puede obtener una bonificación del 5% en el mantenimiento de instalaciones fijas.")
            End If

            eml.Cuerpo = eml.Cuerpo.Replace("{CLIENTE}", ctz.Cliente.Nombre)
            eml.Cuerpo = eml.Cuerpo.Replace("{firma}", ctz.Cliente.Vendedor.Nombre)
            eml.Cuerpo = eml.Cuerpo.Replace("{interno}", ctz.Cliente.Vendedor.Interno)
            eml.Cuerpo = eml.Cuerpo.Replace("{mail_vendedor}", ctz.Cliente.Vendedor.Mail)
            eml.Cuerpo = eml.Cuerpo.Replace("{presupuesto}", ctz.PresupuestoAdonix)
            eml.Cuerpo = eml.Cuerpo.Replace("{codigo_cliente}", ctz.ClienteCodigo)

            eml.AgregarDestinatario(ctz.UsuarioCreacion.Mail)

            eml.Enviar()

            eml.Dispose()
            rpt.Dispose()

        Catch ex As Exception
        End Try

        Try
            File.Delete(archivo)

        Catch ex As Exception
        End Try

    End Sub
    Private Sub dgv_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgv.EditingControlShowing
        Dim tb As DataGridViewTextBoxEditingControl

        Try
            tb = CType(e.Control, DataGridViewTextBoxEditingControl)
            tb.ContextMenuStrip = mnu2
        Catch ex As Exception
        End Try

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
    Private Sub mnu2_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mnu2.Opening
        With dgv
            If .Columns(.CurrentCell.ColumnIndex).Name <> "colCodigo" Then e.Cancel = True
        End With
    End Sub
    Private Sub mnuSeleccionArticulo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSeleccionArticulo.Click
        AbrirSelectorArticulos()
    End Sub
    Private Sub txtDesde1_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDesde1.Validated, _
                                                                                                 txtHasta1.Validated, _
                                                                                                 txtDesde2.Validated, _
                                                                                                 txtHasta2.Validated
        Dim txt As TextBox = CType(sender, TextBox)

        If txt Is txtDesde1 AndAlso txt.Text <> ctz.HoraMananaDesde Then
            ctz.HoraMananaDesde = txt.Text
            If ActualizarDatos Then ActualizarDatosControles()
        End If
        If txt Is txtHasta1 AndAlso txt.Text <> ctz.HoraMananaHasta Then
            ctz.HoraMananaHasta = txt.Text
            If ActualizarDatos Then ActualizarDatosControles()
        End If
        If txt Is txtDesde2 AndAlso txt.Text <> ctz.HoraTardeDesde Then
            ctz.HoraTardeDesde = txt.Text
            If ActualizarDatos Then ActualizarDatosControles()
        End If
        If txt Is txtHasta2 AndAlso txt.Text <> ctz.HoraTardeHasta Then
            ctz.HoraTardeHasta = txt.Text
            If ActualizarDatos Then ActualizarDatosControles()
        End If

    End Sub
    Private Sub txtDesde1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDesde1.Validating, _
                                                                                                                       txtHasta1.Validating, _
                                                                                                                       txtDesde2.Validating, _
                                                                                                                       txtHasta2.Validating
        Dim txt As TextBox = CType(sender, TextBox)

        If Not Utiles.ValidarHora(txt.Text) Then
            MessageBox.Show("Hora no válida", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            e.Cancel = True
        End If
    End Sub
    Private Sub txtBuscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBuscar.TextChanged
        If dv IsNot Nothing Then
            Dim txt As TextBox = CType(sender, TextBox)

            If txt.Text.Trim = "" Then
                dv.RowFilter = ""
            Else
                dv.RowFilter = "bpcnum_0 like '%" & txt.Text.Trim & "%' OR bpcnam_0 like '%" & txt.Text.Trim & "%'"
            End If

        End If
    End Sub
    Private Sub cboTipo_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTipo.SelectedValueChanged
        On Error Resume Next
        ctz.Tipo = CInt(cboTipo.SelectedValue)
        If ActualizarDatos Then ActualizarDatosControles()
    End Sub
    Public Sub SetCliente(Optional ByVal Codigo As String = "")

        If Codigo.Trim = "" Then
            ctz.SetCliente()

        Else
            If ctz.Cliente Is Nothing OrElse ctz.Cliente.Codigo <> Codigo.Trim Then
                ctz.SetCliente(Codigo.Trim)

                If ctz.Cliente.EsCliente Then
                    lblHonorarios.Text = "Honorarios: " & ctz.Cliente.TerceroPagador.Honorario.ToString
                    lblHonorarios.Visible = True
                Else
                    lblHonorarios.Visible = False
                End If

                If ctz.Cliente.Observaciones.Trim <> "" Then
                    MessageBox.Show(ctz.Cliente.Observaciones, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

                '2015-01-15 TABLA XA8 - 
                'Desarrollo de Agenda de Precios Clientes
                If ctz.Cliente.MostrarObsAgendaPrecio Then
                    MessageBox.Show(ctz.Cliente.ObsAgendaPrecio, "Agenda Precios Clientes", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            End If

        End If

        If ActualizarDatos Then ActualizarDatosControles()

    End Sub
    Public Sub SetSucursal(Optional ByVal Codigo As String = "")
        If Codigo.Trim = "" Then
            ctz.SetSucursal()
        Else
            If ctz.Sucursal Is Nothing OrElse ctz.Sucursal.Sucursal <> Codigo.Trim Then
                ctz.SetSucursal(Codigo.Trim)
                ValidarTelefonoContacto()
            End If
        End If

        If ActualizarDatos Then ActualizarDatosControles()
    End Sub
    Private Sub btnFlete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFlete.Click
        Flete()
    End Sub
    Public Sub Flete()
        Dim itm As New Articulo(cn)
        Dim tar As New Tarifa(cn)
        Dim Peso As Double = 0
        Dim Articulo As String = ""

        For Each dr As DataGridViewRow In dgv.Rows
            Try
                Articulo = dr.Cells("colCodigo").Value.ToString
                'Se excluyen sustitutos
                If Articulo = ARTICULO_PRESTAMO_EXT OrElse Articulo = ARTICULO_PRESTAMO_MAN Then Continue For

                If tar.EsNuevo(Articulo) Then Continue For

                itm.Abrir(Articulo)
                Peso += itm.peso * CDbl(dr.Cells("colCant").Value)

            Catch ex As Exception
            End Try

        Next

        If Peso > 0 Then
            ctz.AgregarLinea("653001", Peso, True)
        End If
    End Sub
    Private Sub Alerta639Pendientes()
        'Mensaje al supervisor de que tiene persupuesto 639 para aprobar
        Dim sqh As New Presupuesto(cn)
        Dim dt As New DataTable
        Dim flg As Boolean = False

        'Salto si no es supervisor para presupuesto
        If Not Per.AccesoSecundario(73, "V") Then Exit Sub

        dt = sqh.PresupuestosPendientesAutorizacion(usr)

        For Each dr As DataRow In dt.Rows
            If CInt(dr("xaprob_0")) = 1 Then
                flg = True
                Exit For
            End If
        Next

        If flg Then
            MessageBox.Show("Hay presupuestos 639 para aprobar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        dt.Dispose()

    End Sub
    Private Function Aviso639() As Boolean

        'Cliente debe ser de CABA
        If ctz.Sucursal.Provincia <> "CFE" Then Return False
        'Tipo cliente debe ser 10, 11, 40, 50, 60, 70
        If "10 11 40 50 60 70".IndexOf(ctz.Cliente.Familia2) = -1 Then Return False
        'Debe tener más de 10 recargas
        If Not TieneCantidadRecargas(10) Then Return False
        'No debe tener presupuesto 639 en los ultimos 3 meses
        If TienePresupuesto639() Then Return False
        'No debe tener parque 639
        If TieneParque639() Then Return False

        Return True

    End Function
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
        da.SelectCommand.Parameters.Add("bpc", OracleType.VarChar).Value = ctz.ClienteCodigo
        da.SelectCommand.Parameters.Add("bpa", OracleType.VarChar).Value = ctz.SucursalCodigo
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
    Private Function TieneCantidadRecargas(ByVal Cantidad As Integer) As Boolean
        Dim i As Integer = 0

        For Each dr As DataRow In ctz.Lineas.Rows
            If dr("itmref_0").ToString.StartsWith("45") Then
                i += CInt(dr("qty_0"))
            End If
        Next

        Return i > Cantidad

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
        da.SelectCommand.Parameters.Add("bpcnum", OracleType.VarChar).Value = ctz.ClienteCodigo
        da.SelectCommand.Parameters.Add("fcyitn", OracleType.VarChar).Value = ctz.SucursalCodigo
        da.SelectCommand.Parameters.Add("dat", OracleType.DateTime).Value = f

        Try
            da.Fill(dt)

            flg = dt.Rows.Count > 0

        Catch ex As Exception
            flg = False
        End Try

        Return flg

    End Function
    Private Sub btnDesaprobar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDesaprobar.Click
        Dim sqh As New Presupuesto(cn)
        Dim txt As String

        If MessageBox.Show("¿Confirma marcar el presupuesto como desaprobado?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> Windows.Forms.DialogResult.Yes Then
            Exit Sub
        End If

        If ctz.PresupuestoAdonix <> "" Then
            sqh.Abrir(ctz.PresupuestoAdonix)
            sqh.EstadoAprobacion = 3
            sqh.Grabar()
        End If

        txt = "El presupuesto {sqh} se marcó como desaprobado"
        txt = txt.Replace("{sqh}", ctz.PresupuestoAdonix)

        MessageBox.Show(txt, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

        'Si es licitacion se manda mail de aviso
        If CInt(cboLicitacion.SelectedValue) > 1 Then
            EnviarMailLicitacion("Se desaprobó un presupuesto de licitación", "")
        End If

        ActualizarDatosControles()

    End Sub
    Private Sub cboLicitacion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboLicitacion.SelectedIndexChanged
        Dim cbo As ComboBox = CType(sender, ComboBox)

        If cbo.SelectedValue.ToString.Length > 3 Then Exit Sub
        ctz.TipoLicitacion = CInt(cbo.SelectedValue)
        If ActualizarDatos Then ActualizarDatosControles()
    End Sub
    Private Sub txtLicitacion_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLicitacion.Validated
        Dim txt As TextBox = CType(sender, TextBox)

        ctz.NumeroLicitacion = txt.Text
        If ActualizarDatos Then ActualizarDatosControles()
    End Sub
    Private Sub EnviarMailLicitacion(ByVal Titulo As String, ByVal Obs As String)
        Dim mail As New CorreoElectronico
        Dim txt As String

        With mail
            .Nuevo()
            .Remitente(usr.Mail, usr.Nombre)
            .AgregarDestinatarioArchivo("mails\licitaciones.txt", 0)
            .Asunto = Titulo
            .EsHtml = True

            'Cargo contenido
            .CuerpoDesdeArchivo("mails\licitaciones.htm")
            txt = .Cuerpo

            'Reemplazo campos
            txt = txt.Replace("{titulo}", Titulo)
            txt = txt.Replace("{obs}", Obs)

            txt = txt.Replace("{numero_presupuesto}", txtPresupuesto.Text.Trim)
            If txtPresupuesto.Text.Trim <> "" Then
                Dim o As New Presupuesto(cn)
                o.Abrir(ctz.PresupuestoAdonix)
                txt = txt.Replace("{fecha_presupuesto}", o.Fecha.ToString("dd/MM/yyyy"))
            End If
            txt = txt.Replace("{fecha_presupuesto}", "")

            txt = txt.Replace("{numero_pedido}", txtPedido.Text.Trim)
            If txtPedido.Text.Trim <> "" Then
                Dim o As New Pedido(cn)
                o.Abrir(ctz.PedidoAdonix)
                txt = txt.Replace("{fecha_pedido}", o.Fecha.ToString("dd/MM/yyyy"))
            End If
            txt = txt.Replace("{fecha_pedido}", "")

            txt = txt.Replace("{tipo_licitacion}", cboLicitacion.Text)
            txt = txt.Replace("{numero_licitacion}", txtLicitacion.Text.Trim)
            txt = txt.Replace("{numero_cliente}", txtCodigoCliente.Text)
            txt = txt.Replace("{nombre_cliente}", txtNombreCliente.Text)

            .Cuerpo = txt
            .Enviar()

        End With

    End Sub
    Private Sub btnRechazado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRechazo.Click

        Dim f As New frmIntervencionRechazo(ctz.Cliente, ctz.Sucursal)

        f.ShowDialog(Me)

        If f.DialogResult = Windows.Forms.DialogResult.OK Then
            'Configuración de la pantalla
            With f
                'Muestro la pantalla
                ctz.IntervencionRechazo = f.Seleccionado
                ActualizarDatosControles()
            End With

            f.Dispose()

        End If

    End Sub
    Private Sub chkAVentas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAVentas.CheckedChanged
        ctz.AVentasAntesEntregar = chkAVentas.Checked
        If ActualizarDatos Then ActualizarDatosControles()
    End Sub
    Private Function ValidarTelefonoContacto() As Boolean
        Dim flg As Boolean = True

        'El telefono de contacto debe ser unicamente numerico de 10 digitos
        If ctz.Sucursal IsNot Nothing Then
            Dim bpa As Sucursal = ctz.Sucursal

            If bpa.Telefono_Portero.Trim = "" Then
                flg = True

            Else
                flg = Utiles.ValidarTelefono(bpa.Telefono_Portero)

                If Not flg Then
                    MessageBox.Show("El formato del teléfono de contacto es inválido", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If

            End If

        End If

        Return flg

    End Function
    Private Sub dgv_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellClick
        Dim dr As DataRow
        Dim p As Double = 0
        Dim d As Double = 0

        If e.RowIndex < 0 Then Exit Sub

        lblReferencia.Text = ""

        If dgv.Rows(e.RowIndex).IsNewRow = False Then

            dr = CType(dgv.Rows(e.RowIndex).DataBoundItem, DataRowView).Row

            Select Case e.ColumnIndex
                Case 4 'Precio

                    p = CDbl(dr("precio_0"))
                    p = p / TipoCambio

                    lblReferencia.Text = "Referencia: USD " & p.ToString("N2")

                Case 5 ' Precio Sugerido
                    If ctz.TipoCambio > 0 Then
                        p = CDbl(dr("precio_1"))
                        p = p / ctz.TipoCambio

                        lblReferencia.Text = "Referencia: USD " & p.ToString("N2")

                    Else
                        lblReferencia.Text = "Referencia: USD --.--"

                    End If


                Case Else


            End Select

        End If

    End Sub
    Private Function EsPresupuestoAgua() As Boolean
        Dim flg As Boolean = False

        For Each dr As DataRow In ctz.Lineas.Rows
            If "401102-401106-402110".IndexOf(dr("itmref_0").ToString) <> -1 Then
                flg = True
                Exit For
            End If
        Next

        Return flg

    End Function

    Private Sub chkMunro_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMunro.CheckedChanged
        ctz.SaleDesdeMunro = chkMunro.Checked
    End Sub

End Class