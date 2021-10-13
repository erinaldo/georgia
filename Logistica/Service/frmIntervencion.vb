Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.OracleClient
Imports System.IO

Public Class frmIntervencion

    'Ubicacion para los archivos de Ordenes de Compras
    Private Const PATH_OC As String = "\\srv\Z\OC\"

    Public itn As New Intervencion(cn)
    Private sre As New Solicitud(cn)
    Private tar As New Tarifa(cn)
    Private Fer As New Feriados(cn)
    Private WithEvents con As New ContratoServicio(cn)
    'Indica que la ventana se está usando desde la de Vencimietnos
    Public DesdeVencimiento As Boolean = False

    Private dtRetiros As DataTable

    'Carrito
    Private CarritoFecha As Date = Nothing
    Private CarritoZona As Integer = 0
    Private CarritoTipo As Integer = 0

    Public Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        dgvRetiros.AutoGenerateColumns = False

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        'Enlace del ComboBox Sociedades
        Sociedad.Sociedades(cn, cboSociedad, True)
        'Enlace de ComboBox Tipo de Intervencion
        Dim tb As New TablaVaria(cn, 407, True)
        tb.EnlazarComboBox(cboTipo)

        'Recupero la estructura de la tabla Retiros (YITNDET)
        dtRetiros = Intervencion.RetirosSchema(cn)
        'Configuracion de campos de la tabla
        With dtRetiros.Columns
            .Item("numlig_0").AutoIncrement = True
            .Item("numlig_0").AutoIncrementSeed = 1000
            .Item("numlig_0").AutoIncrementStep = 1000
            .Item("num_0").DefaultValue = " "
            .Item("uom_0").DefaultValue = "UN"
            .Item("qty_0").DefaultValue = 0
            .Item("tqty_0").DefaultValue = 0
            .Item("tuom_0").DefaultValue = "UN"
            .Item("yqty2_0").DefaultValue = 0
            .Item("factura_0").DefaultValue = 1
            .Item("typlig_0").DefaultValue = 1
            .Item("amt_0").DefaultValue = 0
            .Item("srenum_0").DefaultValue = " "
        End With

        'Enlazo los campos de la grilla con la tabla
        colNumlig.DataPropertyName = "numlig_0"
        colNumlig.Visible = False
        colNum.DataPropertyName = "num_0"
        colItmref.DataPropertyName = "itmref_0"
        With colDescripcion
            .DataPropertyName = "itmref_0"
            .DisplayMember = "itmdes1_0"
            .ValueMember = "itmref_0"
            .DataSource = Articulo.Tabla(cn)
        End With
        colQty.DataPropertyName = "qty_0"
        colUom.DataPropertyName = "uom_0"
        colTqty.DataPropertyName = "tqty_0"
        colTuom.DataPropertyName = "tuom_0"
        colYqty2.DataPropertyName = "yqty2_0"
        colFactura.DataPropertyName = "factura_0"
        colTypLig.DataPropertyName = "typlig_0"
        colAmt.DataPropertyName = "amt_0"
        colSre.DataPropertyName = "srenum_0"
        dgvRetiros.DataSource = dtRetiros

        dtpTarea.Value = Fer.ObtenerSiguienteDiaHabil(Today)

        'Lleno ComboBox Modo de Entrega
        Dim mdl As New ModoEntrega(cn)
        mdl.ModosEntrega(cboModoEntrega)

        'Lleno ComboBox de Condicion de Pago
        CondicionPago.LlenarComboBox(cn, cboCondicionPago, True)
        'Habilito el ComboBox a usuarios administradores
        cboCondicionPago.Enabled = usr.Permiso.AccesoSecundario(43, "V")

    End Sub
    Private Sub frmIntervencion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If colNumlig.Visible Then colNumlig.Visible = False
    End Sub
#Region "Datos del cliente"
    Private Sub txtCodigoCliente_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodigoCliente.Validating
        Dim txt As TextBox = CType(sender, TextBox)
        Dim bpc As New Cliente(cn)
        Dim flg As Boolean = True

        With txt
            .Text = .Text.Trim

            If .Text.Length > 0 Then
                flg = bpc.Abrir(.Text)
                If Not flg OrElse bpc.EsProspecto = True Then
                    flg = False
                    MessageBox.Show("Código de cliente incorrecto", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If

                If flg AndAlso Not bpc.AccesoUsuario(usr.Codigo) Then
                    MessageBox.Show("El usuario no tiene permiso para acceder a este cliente")
                    txtCodigoCliente.Clear()
                    txtCodigoCliente.Focus()
                    flg = False
                End If

                bpc.Dispose()
            End If

        End With

        e.Cancel = Not flg

    End Sub
    Private Sub txtCodigoCliente_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodigoCliente.Validated
        Dim txt As TextBox = CType(sender, TextBox)

        With txt
            If .Text.Length = 0 Then
                LimpiarDatosCliente()
                LimpiarDatosSucursal()
            Else
                If .Tag Is Nothing OrElse .Tag.ToString <> .Text Then
                    SetCliente()
                End If
            End If

        End With
    End Sub
    Private Sub txtCodigoCliente_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigoCliente.KeyUp
        If e.KeyCode = Keys.F12 Then AbrirSelectorCliente()
    End Sub
    Public Sub SetCliente()
        Dim bpc As New Cliente(cn)
        bpc.Abrir(txtCodigoCliente.Text)
        MostrarDatosCliente(bpc)
        txtCodigoCliente.Tag = txtCodigoCliente.Text
        LimpiarDatosSucursal()
    End Sub
    Public Sub SetSucursal()
        Dim bpa As New Sucursal(cn)
        bpa.Abrir(txtCodigoCliente.Text, txtSucursal.Text)
        MostrarDatosSucursal(bpa)
        txtSucursal.Tag = txtSucursal.Text
    End Sub

    Private Sub MostrarDatosCliente(ByVal bpc As Cliente)

        txtNombreCliente.Text = bpc.Nombre.Trim
        txtNombreFantasia.Text = bpc.NombreFantasia.Trim
        cboCondicionPago.SelectedValue = " "

        'Seleccion automática de la sociedad de facturacion
        If bpc.EmpresaFacturacionObligatoria <> "" Then
            cboSociedad.SelectedValue = bpc.EmpresaFacturacionObligatoria

        Else
            If bpc.EsAbonado Then
                cboSociedad.SelectedValue = "DNY"
            Else
                cboSociedad.SelectedValue = bpc.EmpresaFacturacion
            End If
        End If
        

        'Bloqueo seleccion de empresa si es abonado
        cboSociedad.Enabled = Not bpc.EsAbonado
        'Muestro condicion de pago del cliente
        With bpc.CondicionPago
            If .TieneDatos Then
                cboCondicionPago.SelectedValue = .Codigo

            Else
                If bpc.EsAbonado Then
                    cboCondicionPago.SelectedValue = .Codigo
                Else
                    cboCondicionPago.SelectedValue = " "
                End If

            End If
        End With

        'Carga de Solicitudes Abiertas
        IntervencionesAbiertas(bpc.Codigo)

    End Sub
    Private Sub LimpiarDatosCliente()
        txtNombreCliente.Clear()
        txtNombreFantasia.Clear()
        cboCondicionPago.SelectedValue = " "
        lvDocumentos.Items.Clear()
    End Sub
#End Region
    
#Region "Datos de la sucursal"
    Private Sub txtSucursal_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtSucursal.Validating
        Dim txt As TextBox = CType(sender, TextBox)
        Dim bpa As New Sucursal(cn)
        Dim Cancelar As Boolean = False
        Dim t As String = ""

        With txt
            .Text = .Text.Trim

            If .Text.Length > 0 Then
                If txtCodigoCliente.Text = "" Then
                    Cancelar = True

                Else
                    If bpa.Abrir(txtCodigoCliente.Text, .Text) Then
                        Cancelar = Not bpa.EsDireccionEntrega
                        t = "Sucursal no permitida para entregas"
                    Else
                        Cancelar = True
                        t = "No existe la sucursal " & txt.Text
                    End If
                End If

            End If

        End With

        e.Cancel = Cancelar

        If e.Cancel AndAlso t <> "" Then MessageBox.Show(t, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)

    End Sub
    Private Sub txtSucursal_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSucursal.Validated
        Dim txt As TextBox = CType(sender, TextBox)

        With txt
            'Salto si no hay dato ingresado
            If .Text.Length = 0 Then
                LimpiarDatosSucursal()
            Else
                'Salto si no hay codigo de cliente
                If txtCodigoCliente.Text = "" Then Exit Sub

                'Establezco el nuevo cliente
                If .Tag Is Nothing OrElse .Tag.ToString <> .Text Then
                    SetSucursal()
                End If
            End If
        End With
    End Sub
    Private Sub txtSucursal_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSucursal.KeyUp
        If e.KeyCode = Keys.F12 Then AbrirSelectorSucursal()
    End Sub
    Private Sub MostrarDatosSucursal(ByVal bpa As Sucursal)
        With bpa
            txtDireccion.Text = .Direccion
            txtTelefonoSucursal.Text = .Telefono
            txtPortero.Text = .Portero
            txtPorteroCelu.Text = .Telefono_Portero
            txtTelefonoSucursal.Text = .Telefono
            txtMailSucursal.Text = .Mail

            txtDesde1.Text = .TurnoMananaDesde
            txtHasta1.Text = .TurnoMananaHasta
            txtDesde2.Text = .TurnoTardeDesde
            txtHasta2.Text = .TurnoTardeHasta

            cboModoEntrega.SelectedValue = bpa.ModoEntrega

        End With

    End Sub
    Private Sub LimpiarDatosSucursal()
        txtSucursal.Clear()
        txtSucursal.Tag = ""

        txtDireccion.Clear()
        txtTelefonoSucursal.Clear()
        txtMailSucursal.Clear()
    End Sub
#End Region
#Region "Ordenes de compra"
    Private Sub txtOT_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtOT.Validating
        'Valida que el dato sea 6 caracteres numericos
        Dim Cancelar As Boolean = False
        Dim txt As TextBox = CType(sender, TextBox)
        txt.Text = txt.Text.Trim

        If txt.Text.Length > 0 Then
            For i = 0 To txt.Text.Length - 1
                Cancelar = Not IsNumeric(txt.Text.Substring(i, 1))
                If Cancelar Then Exit For
            Next
            'El numero debe tener 6 digitos
            If txt.Text.Length <> 6 Then
                MessageBox.Show("El número de OT debe tener 6 dígitos", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Cancelar = True
            End If
        End If

        e.Cancel = Cancelar
    End Sub
    Private Sub btnExaminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExaminar.Click
        'Salgo si el campo OC o cliente están vacío
        txtOC.Text = txtOC.Text.Trim
        If txtOC.Text.Length = 0 Or txtCodigoCliente.Text.Length = 0 Then Exit Sub

        'Variable para armar la ruta destino donde se guardará el archivo
        Dim Destino As String

        OpenFileDialog1.InitialDirectory = "c:\"
        OpenFileDialog1.Filter = "PDF Files (*.pdf)|*.pdf|All files (*.*)|*.*"
        openFileDialog1.FilterIndex = 2
        OpenFileDialog1.RestoreDirectory = True

        If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Destino = PATH_OC & txtCodigoCliente.Text.Trim & "-" & txtOC.Text.Trim & ".pdf"

            Try
                File.Copy(OpenFileDialog1.FileName, destino, True)

            Catch ex As Exception

            End Try

        End If
    End Sub
    Private Sub btnBorrarOC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrarOC.Click
        Dim Resp As DialogResult

        Resp = MessageBox.Show("¿Realmente quiere borrar la OC?", "Aviso", MessageBoxButtons.YesNo)

        If Resp = Windows.Forms.DialogResult.Yes Then

            Try
                If File.Exists(PATH_OC & txtCodigoCliente.Text.Trim & "-" & txtOC.Text.Trim & ".pdf") Then
                    File.Delete(PATH_OC & txtCodigoCliente.Text.Trim & "-" & txtOC.Text.Trim & ".pdf")
                End If
                txtOC.Text = ""

            Catch ex As Exception
            End Try

            btnExaminar.Enabled = False

        End If
    End Sub
    Private Sub btnVerOC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVerOC.Click
        Try
            Process.Start(PATH_OC & txtCodigoCliente.Text.Trim & "-" & txtOC.Text.Trim & ".pdf")

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region
#Region "Solicitudes abiertas"
    Private Sub IntervencionesAbiertas(ByVal Cliente As String)
        Dim dr As OracleDataReader
        Dim cm As New OracleCommand
        Dim Sql As String

        'Limpio
        lvDocumentos.Items.Clear()

        'Consulta de Solicitudes de servicios abiertas
        Sql = "SELECT srenum_0, credat_0, creusr_0 "
        Sql &= "FROM serrequest "
        Sql &= "WHERE srebpc_0 = :p1 AND sreass_0 <> 5 "
        Sql &= "ORDER BY credat_0 DESC"
        cm.CommandText = Sql
        cm.Parameters.Add("p1", OracleType.VarChar).Value = Cliente
        cm.Connection = cn

        dr = cm.ExecuteReader
        While dr.Read
            With lvDocumentos.Items.Add(dr("srenum_0").ToString, dr("srenum_0").ToString)
                .SubItems.Add(CDate(dr("credat_0")).ToShortDateString)
                .SubItems.Add("")
                .SubItems.Add(dr("creusr_0").ToString)
                .Group = lvDocumentos.Groups("lvgSS")
            End With
        End While
        dr.Close()

        cm.Dispose()
        dr.Dispose()

    End Sub
    Private Sub lvDocumentos_ItemChecked(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckedEventArgs) Handles lvDocumentos.ItemChecked

        If e.Item.Checked Then
            Dim bpc As New Cliente(cn)
            bpc.Abrir(txtCodigoCliente.Text)

            If bpc.EsAbonado Then
                If e.Item.SubItems(2).Text = "" Then
                    For Each i As ListViewItem In lvDocumentos.Items
                        If i IsNot e.Item Then i.Checked = False
                    Next

                Else
                    e.Item.Checked = False

                End If

            Else
                e.Item.Checked = False

            End If

        End If

    End Sub
#End Region

    Private Sub dgv_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dgvRetiros.CellValidating
        'Referencia a la DataGridView
        Dim o As DataGridView = CType(sender, DataGridView)
        'Referencia a la FILA modificada
        Dim r As DataGridViewRow = o.Rows(e.RowIndex)
        'Referencia a la CELDA modificada
        Dim c As DataGridViewCell = r.Cells(e.ColumnIndex)

        If c.IsInEditMode Then
            'Validaciones globales
            If txtCodigoCliente.Text = "" Then e.Cancel = True

            If e.Cancel = False Then
                'Validación segun columna
                Select Case o.Columns(e.ColumnIndex).Name
                    Case "colItmref"
                        'Salto si el nuevo valor es igual al anterior
                        If c.Value.ToString = e.FormattedValue.ToString Then Exit Sub
                        'Valido que el codigo ingresado exista en el maestro de articulos
                        Dim itm As New Articulo(cn)
                        If Not itm.Abrir(e.FormattedValue.ToString) Then
                            MessageBox.Show("Artículo no encontrado", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            e.Cancel = True
                        ElseIf itm.Activo = False Then
                            MessageBox.Show("Artículo inactivo", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            e.Cancel = True
                        End If
                        itm.Dispose()
                        itm = Nothing

                    Case "colTqty" 'Validación del campo cantidad
                        'Salto si el nuevo valor es igual al anterior
                        If c.Value.ToString = e.FormattedValue.ToString Then Exit Sub
                        'Valido que el valor ingresado sea numerico y mayor a cero
                        'e.Cancel = Not (IsNumeric(e.FormattedValue.ToString) AndAlso CInt(e.FormattedValue) > 0)
                        If Not (IsNumeric(e.FormattedValue.ToString) AndAlso CInt(e.FormattedValue) > 0) Then
                            e.Cancel = True
                        End If

                    Case "colAmt"
                        'Salto si el nuevo valor es igual al anterior
                        If c.Value.ToString = e.FormattedValue.ToString Then Exit Sub
                        'Valido que el valor ingresado sea numerico
                        e.Cancel = Not IsNumeric(e.FormattedValue.ToString)

                End Select
            End If

        End If

    End Sub
    Private Sub dgv_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRetiros.CellValidated
        Dim o As DataGridView = CType(sender, DataGridView)
        Dim r As DataGridViewRow = o.Rows(e.RowIndex)
        Dim c As DataGridViewCell = r.Cells(e.ColumnIndex)

        If c.IsInEditMode Then
            'Validación segun columna
            Select Case o.Columns(e.ColumnIndex).Name
                Case "colItmref"
                    r.Cells("colTqty").Value = 0
                    r.Cells("colAmt").Value = 0

                Case "colTqty"
                    'Busco el precio según cantidad si Tipo <> C1
                    Dim Articulo As String
                    Dim Cantidad As Double
                    Dim Precio As Double

                    If cboTipo.SelectedValue.ToString <> "C1" Then
                        Articulo = r.Cells("colItmref").Value.ToString
                        Cantidad = CDbl(r.Cells("colTqty").Value)
                        Precio = Me.Precio(txtCodigoCliente.Text, Articulo, Cantidad)
                    Else
                        Precio = 0
                    End If

                    r.Cells("colAmt").Value = Precio
            End Select

        End If

    End Sub
    Private Sub dgv_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvRetiros.DataError
        MessageBox.Show("Valor inválido", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        e.Cancel = True
    End Sub
    Private Sub btnCarrito_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCarrito.Click
        Dim f As frmCarrito
        Dim Cant As Integer = 0
        Dim txt As String = ""
        Dim itm As New Articulo(cn)
        Dim HayCarros As Boolean = False
        Dim bpa As New Sucursal(cn)

        If txtCodigoCliente.Text = "" Or txtSucursal.Text = "" Then Exit Sub

        bpa.Abrir(txtCodigoCliente.Text, txtSucursal.Text)

        'La sucursal del cliente debe ser de capital
        If bpa.Provincia <> "CFE" Then
            txt = "Opción disponible solo para cliente de Capital"
            MessageBox.Show(txt, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        'No se permite usar la opcion si la cantidad es mayor a 45 y hay
        'carros en la lista de retiros
        For Each dr As DataRow In dtRetiros.Rows
            Cant += CInt(dr("tqty_0"))

            'Abro el articulo para ver si es un carro
            If itm.Abrir(dr("itmref_0").ToString) Then
                If itm.Familia(2) = "391" Then HayCarros = True
            End If
        Next

        If HayCarros Then
            txt = "Opción no disponible para retirar carros"
            MessageBox.Show(txt, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        'Si la cantidad es mayor a 45 no abro la ventana
        If Cant > 45 Then
            txt = "Opción no disponible para mas de 45 equipos"
            MessageBox.Show(txt, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        'Tipo de Intervenciones permitidas para esta funcionalidad
        If "B1B2".IndexOf(cboTipo.SelectedValue.ToString) = -1 Then
            txt = "Opción no disponible para intervenciones tipo " & cboTipo.SelectedValue.ToString
            MessageBox.Show(txt, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        If Cant > 0 Then
            f = New frmCarrito(cn, bpa, Cant, dtpTarea.Value)
            f.ShowDialog()

            If f.DialogResult = Windows.Forms.DialogResult.OK Then
                CarritoFecha = f.mthFechas.SelectionRange.Start
                CarritoZona = f.Zona
                CarritoTipo = f.Tipo
                txtCarrito.Text = CarritoFecha.ToString("dd/MM/yyyy")

                dtpTarea.Enabled = False
            End If

            f.Dispose()

        End If
    End Sub
    Private Sub EstadoControles(ByVal flg As Boolean)
        'Activo/desactivo GroupBox
        For Each x As Object In Me.Controls
            If TypeOf (x) Is GroupBox Then
                CType(x, GroupBox).Enabled = flg
            End If
        Next
        btnCrear.Enabled = flg
        btnNueva.Enabled = Not flg

    End Sub
    Private Sub ResetGroupBox(ByVal grp As GroupBox)
        Dim o As Object

        For Each o In grp.Controls
            If TypeOf o Is TextBox Then
                CType(o, TextBox).Clear()
            End If
            If TypeOf o Is ComboBox Then
                CType(o, ComboBox).SelectedValue = " "
            End If
            If TypeOf o Is DateTimePicker Then
                CType(o, DateTimePicker).Value = Fer.ObtenerSiguienteDiaHabil(Today)
            End If
            If TypeOf o Is CheckBox Then
                CType(o, CheckBox).Checked = False
            End If
        Next
    End Sub
    Private Sub btnNueva_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNueva.Click
        NuevaIntervencion()
    End Sub
    Public Sub NuevaIntervencion()
        ResetGroupBox(GroupBox1)
        ResetGroupBox(GroupBox2)
        ResetGroupBox(GroupBox3)
        ResetGroupBox(GroupBox6)
        ResetGroupBox(GroupBox7)
        ResetGroupBox(GroupBox8)
        ResetGroupBox(GroupBox9)

        If Me.ParentForm IsNot frmVencimientos Then
            dtRetiros.Clear()
            lvDocumentos.Items.Clear()
        End If

        txtCodigoCliente.Tag = Nothing
        txtCodigoCliente.Focus()
        txtSucursal.Tag = Nothing

        txtIntervencion.Visible = False
        btnImprimir.Enabled = False

        CarritoFecha = Nothing
        CarritoTipo = 0
        CarritoZona = 0

        EstadoControles(True)

    End Sub
    Private Sub btnCrear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCrear.Click
        'Valido que estén todos los datos necesarios para crear una intervencion
        If Not ValidacionDeDatos() Then Exit Sub

        If CrearIntervencion() Then
            'Desactivo todos los controles del formulario
            EstadoControles(False)

            txtIntervencion.Text = itn.Numero
            txtIntervencion.Visible = True
            btnImprimir.Enabled = cboTipo.SelectedValue.ToString = "D1" Or cboTipo.SelectedValue.ToString = "H1"

            TraspasoDeParque()

            Me.DialogResult = Windows.Forms.DialogResult.OK

            If DesdeVencimiento Then Me.Close()
        End If

    End Sub
    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub mnu_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mnu.Opening
        Dim txt As TextBox = Nothing

        'Obtengo el control que tiene el foco
        If txtCodigoCliente.Focused Then txt = txtCodigoCliente
        If txtSucursal.Focused Then txt = txtSucursal

        If txt Is Nothing Then
            e.Cancel = True
        Else
            mnuSeleccion.Enabled = Not txt.ReadOnly
            mnuEditar.Enabled = txt.Text.Length > 0
        End If

    End Sub
    Private Sub mnuSeleccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSeleccion.Click
        If txtCodigoCliente.Focused Then AbrirSelectorCliente()
        If txtSucursal.Focused Then AbrirSelectorSucursal()
    End Sub
    Private Sub mnuEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEditar.Click
        If txtCodigoCliente.Focused Then
            Dim bpc As New Cliente(cn)
            bpc.Abrir(txtCodigoCliente.Text)

            Dim f As New frmCliente(bpc)

            'Configuración de la pantalla
            With f
                f.BloquearEdicionDeCampos()
                'Muestro la pantalla
                f.ShowDialog(Me)
            End With

            If f.DialogResult = Windows.Forms.DialogResult.OK Then
                MostrarDatosCliente(bpc)
            End If
            f.Dispose()

        End If

        If txtSucursal.Focused Then
            Dim bpc As New Cliente(cn)
            bpc.Abrir(txtCodigoCliente.Text)
            Dim bpa As New Sucursal(cn, txtCodigoCliente.Text, txtSucursal.Text)

            Dim f As New frmSucursal(bpc, bpa)

            With f
                .GrabarAlSalir = True
                .gbSucursal.Enabled = False

                .ShowDialog(Me)
            End With

            If f.DialogResult = Windows.Forms.DialogResult.OK Then
                MostrarDatosSucursal(bpa)
            End If
            f.Dispose()

        End If
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
            txtSucursal.Text = f.SucursalSeleccionada
        End If
        f.Dispose()
    End Sub
    Private Sub AbrirSelectorArticulos()
        Dim f As New frmSelectorArticulos()
        Dim c As System.Windows.Forms.Control

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
    Private Sub TraspasoDeParque()
        Dim dr As DataRow
        Dim dt As DataTable
        Dim da As OracleDataAdapter
        Dim cm As OracleCommand
        Dim itn As Intervencion = Nothing
        Dim sql As String
        Dim flg As Boolean = False
        Dim i As Integer

        '1.- Busco intervencion que termine con los numeros del campo OT.
        sql = "SELECT * FROM interven WHERE num_0 like :p1 and zflgtrip_0 <= 3"
        da = New OracleDataAdapter(sql, cn)
        da.SelectCommand.Parameters.Add("p1", OracleType.VarChar).Value = "%" & txtOT.Text.Trim
        Try
            dt = New DataTable
            da.Fill(dt)

            If dt.Rows.Count = 1 Then
                dr = dt.Rows(0)
                itn = New Intervencion(cn)
                itn.Abrir(dr("num_0").ToString)

                sql = "¿El número de OT se refiere a la intervención " & itn.Numero & "?" & vbCrLf & vbCrLf
                sql &= "¿Confirma cerrar intervención y tranferir el parque?"

                If MessageBox.Show(sql, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then flg = True

                If flg Then
                    itn.SolicitudSatisfecha = True
                    itn.Estado = 8
                    itn.Observaciones = "Intervencion reemplazada por " & txtIntervencion.Text
                    itn.Grabar()

                    If Not itn.Cliente.EsAbonado Then
                        itn.SolicitudAsociada.CerrarSolicitud()
                        itn.SolicitudAsociada.Grabar()
                    End If

                End If

            End If

        Catch ex As Exception
        End Try

        If flg AndAlso itn IsNot Nothing Then
            'Muevo Parque de un cliente a otro
            If itn.Cliente.Codigo <> Me.itn.Cliente.Codigo Then
                Try
                    'Muevo parque en tabla machine
                    sql = "UPDATE machines "
                    sql &= "SET maccutbpc_0 = :p1, bpcnum_0 = :p1, fcyitn_0 = :p2 "
                    sql &= "WHERE macnum_0 IN (SELECT macnum_0 FROM sremac WHERE yitnnum_0 = :p3)"
                    cm = New OracleCommand(sql, cn)
                    cm.Parameters.Add("p1", OracleType.VarChar).Value = Me.itn.Cliente.Codigo
                    cm.Parameters.Add("p2", OracleType.VarChar).Value = Me.itn.SucursalCodigo
                    cm.Parameters.Add("p3", OracleType.VarChar).Value = itn.Numero
                    i = cm.ExecuteNonQuery()
                    'Muevo parque en tabla ymacitm
                    sql = "UPDATE ymacitm "
                    sql &= "SET bpcnum_0 = :p1 "
                    sql &= "WHERE macnum_0 IN (SELECT macnum_0 FROM sremac WHERE yitnnum_0 = :p3)"
                    cm = New OracleCommand(sql, cn)
                    cm.Parameters.Add("p1", OracleType.VarChar).Value = Me.itn.Cliente.Codigo
                    cm.Parameters.Add("p3", OracleType.VarChar).Value = itn.Numero
                    i = cm.ExecuteNonQuery()

                Catch ex As Exception
                End Try

            End If

            'Muevo el parque leido de una intervencion a otra
            Try
                sql = "UPDATE sremac SET srenum_0 = :p1, yitnnum_0 = :p2 WHERE yitnnum_0 = :p3"
                cm = New OracleCommand(sql, cn)
                cm.Parameters.Add("p1", OracleType.VarChar).Value = Me.itn.SolicitudAsociada.Numero
                cm.Parameters.Add("p2", OracleType.VarChar).Value = Me.itn.Numero
                cm.Parameters.Add("p3", OracleType.VarChar).Value = itn.Numero
                i = cm.ExecuteNonQuery()
            Catch ex As Exception
                MessageBox.Show("Error al mover parque leido", Me.Text, MessageBoxButtons.OK)
            End Try

            'Cambio intervencion pegada a los parques
            Try
                sql = "UPDATE machines SET xitn_0 = :p1 WHERE xitn_0 = :p2"
                cm = New OracleCommand(sql, cn)
                cm.Parameters.Add("p1", OracleType.VarChar).Value = Me.itn.Numero
                cm.Parameters.Add("p2", OracleType.VarChar).Value = itn.Numero
                i = cm.ExecuteNonQuery()
            Catch ex As Exception
                MessageBox.Show("Error al mover parque en machines", Me.Text, MessageBoxButtons.OK)
            End Try

            'Cambio intervencion a los prestamos
            Try
                sql = "UPDATE machines "
                sql &= "SET ynrocil_0 = :p1, maccutbpc_0 = :p2, bpcnum_0 = :p2, fcyitn_0 = :p3 "
                sql &= "WHERE ynrocil_0 = :p4"
                cm = New OracleCommand(sql, cn)
                cm.Parameters.Add("p1", OracleType.VarChar).Value = Me.itn.Numero
                cm.Parameters.Add("p2", OracleType.VarChar).Value = Me.itn.Cliente.Codigo
                cm.Parameters.Add("p3", OracleType.VarChar).Value = Me.itn.SucursalCodigo
                cm.Parameters.Add("p4", OracleType.VarChar).Value = itn.Numero
                i = cm.ExecuteNonQuery()

            Catch ex As Exception
                MessageBox.Show("Error al mover parque prestamos", Me.Text, MessageBoxButtons.OK)

            End Try

        End If

    End Sub
    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        Dim rpt As New ReportDocument

        If txtIntervencion.Text = "" OrElse cboTipo.SelectedValue.ToString <> "D1" Then

            If cboTipo.SelectedValue.ToString <> "H1" Then
                Exit Sub
            End If
        End If
        Try
            rpt.Load(RPTX3 & "ITN1.rpt")
            rpt.SetDatabaseLogon(DB_USR, DB_PWD)
            rpt.SetParameterValue("ITN", txtIntervencion.Text)
            rpt.SetParameterValue("X3USR", usr.Codigo)
            rpt.SetParameterValue("X3DOS", X3DOS)
            rpt.PrintToPrinter(1, False, 1, 100)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub
    Private Sub con_Mensaje(ByVal sender As Object, ByVal e As Clases.ContratoEventArgs) Handles con.Mensaje
        MessageBox.Show(e.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
    End Sub
    Private Sub dgvRetiros_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvRetiros.EditingControlShowing
        Dim tb As DataGridViewTextBoxEditingControl

        tb = CType(e.Control, DataGridViewTextBoxEditingControl)
        tb.ContextMenuStrip = mnu2

    End Sub
    Private Sub mnuSeleccionArticulo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSeleccionArticulo.Click
        AbrirSelectorArticulos()
    End Sub
    Private Sub mnu2_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mnu2.Opening
        With dgvRetiros
            If .Columns(.CurrentCell.ColumnIndex).Name <> "colItmref" Then e.Cancel = True
        End With
    End Sub
    Public Sub AgregarRetiro(ByVal Articulo As String, ByVal Cantidad As Integer, ByVal Tipo As Integer)
        Dim dr As DataRow

        dr = dtRetiros.NewRow
        dr("num_0") = " "
        dr("itmref_0") = Articulo
        dr("qty_0") = 0
        dr("uom_0") = "UN"
        dr("tqty_0") = Cantidad
        dr("tuom_0") = "UN"
        dr("yqty2_0") = 0
        dr("factura_0") = 1
        dr("typlig_0") = Tipo
        dr("amt_0") = Precio(txtCodigoCliente.Text, Articulo, Cantidad)
        dr("srenum_0") = " "
        dtRetiros.Rows.Add(dr)

    End Sub
    Public Sub AgregarSustitutos()
        Dim PrestamosExtintores As Integer = 0
        Dim PrestamosMangueras As Integer = 0

        For Each dr As DataRow In dtRetiros.Rows
            If dr.RowState = DataRowState.Deleted Then Continue For

            If dr("itmref_0").ToString.StartsWith("45") Then
                PrestamosExtintores += CInt(dr("tqty_0"))
            ElseIf dr("itmref_0").ToString.StartsWith("45") Then
                PrestamosMangueras += CInt(dr("tqty_0"))
            End If
        Next

        If PrestamosExtintores > 0 Then
            AgregarRetiro(ARTICULO_PRESTAMO_EXT, PrestamosExtintores, 2)
        End If
        If PrestamosMangueras > 0 Then
            AgregarRetiro(ARTICULO_PRESTAMO_MAN, PrestamosMangueras, 2)
        End If

    End Sub
    Private Sub txtCodigoCliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigoCliente.TextChanged

    End Sub

    Private Function CrearIntervencion() As Boolean
        sre = New Solicitud(cn)
        Dim bpc As New Cliente(cn)

        bpc.Abrir(txtCodigoCliente.Text)

        'Recorro los articulos de la solapa retiros y pongo TYPLIG=2 a los sustitutos
        For Each dr As DataRow In dtRetiros.Rows
            dr.BeginEdit()
            Select Case dr("itmref_0").ToString
                Case ARTICULO_PRESTAMO_EXT, ARTICULO_PRESTAMO_MAN
                    dr("typlig_0") = 2
                Case Else
                    dr("typlig_0") = 1
            End Select
            dr.EndEdit()
        Next

        'Creo una nueva solicitud o abro una existente para clientes abonados
        If lvDocumentos.CheckedItems.Count = 1 Then
            sre.Abrir(lvDocumentos.CheckedItems(0).Text)

            'Si la SS tiene contrato se valida
            If cboTipo.SelectedValue.ToString <> "G1" Then
                If Not chkReclamo.Checked Then
                    If Not ValidarContrato(sre) Then Return False
                End If
            End If

        Else
            Dim cpy As New Sociedad(cn)
            cpy.abrir(cboSociedad.SelectedValue.ToString)

            sre.Nueva(bpc, cpy)

            If txtOC.Text.Trim <> "" Then
                sre.Referencia = txtOC.Text.Trim
                sre.Grabar()
            End If

        End If

        'Creo una nueva intervencion
        itn = sre.CrearIntervencion(txtSucursal.Text, cboTipo.SelectedValue.ToString, txtDesde1.Text, txtHasta1.Text, txtDesde2.Text, txtHasta2.Text)
        itn.FechaInicio = dtpTarea.Value
        itn.Observaciones = txtObj.Text
        itn.AgregarDetalle(dtRetiros)
        itn.ModoEntrega = cboModoEntrega.SelectedValue.ToString
        itn.Reclamo = chkReclamo.Checked

        If txtOT.Text.Trim <> "" Then itn.OTR = CInt(txtOT.Text)

        'OC
        Dim oc As String = " "
        If txtOC.Text.Trim <> "" Then
            oc = itn.Cliente.Codigo & "-" & txtOC.Text.Trim & ".pdf"
            itn.OCF = oc
        End If
        If multiline.Text.Trim <> "" Then
            itn.ficheComment = multiline.Text
        End If

        'Grabo datos del carrito
        If CarritoTipo > 0 Then
            itn.CarritoFecha = CarritoFecha
            itn.CarritoTipo = CarritoTipo
            itn.CarritoZona = CarritoZona
        End If

        'Marco H si es MON
        itn.Referencia = IIf(chkH.Checked, "H", oc).ToString

        'Grabar Intervención
        itn.Grabar()

        Return True

    End Function
    Private Function ValidacionDeDatos() As Boolean
        Dim flg As Boolean = False
        Dim txt As String = ""
        Dim bpc As New Cliente(cn)
        Dim bpa As New Sucursal(cn)

        bpc.Abrir(txtCodigoCliente.Text)
        bpa.Abrir(txtCodigoCliente.Text, txtSucursal.Text)

        '--------------------------------------------------------------------------------
        ' VALIDACIONES DEL CLIENTE
        '--------------------------------------------------------------------------------
        If txtCodigoCliente.Text.Trim = "" Then
            MessageBox.Show("Falta cargar código de cliente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False
        End If
        If bpc.Activo = False Then
            MessageBox.Show("Cliente inactivo", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False
        End If
        '--------------------------------------------------------------------------------
        ' VALIDACIONES DE LA SUCURSAL
        '--------------------------------------------------------------------------------
        If txtSucursal.Text.Trim = "" Then
            MessageBox.Show("Falta cargar código de sucursal", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False
        End If
        If Not bpa.SucursalEntregaActiva Then
            MessageBox.Show("La sucursal no es de entrega o está inactiva", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If
        '--------------------------------------------------------------------------------
        ' VALIDACIONES DE HORARIOS SI ES ENTREGA GEORGIA
        '--------------------------------------------------------------------------------
        If CInt(cboModoEntrega.SelectedValue) = 1 Then
            'Validacion que las horas tengan un formato correcto
            If Not ValidacionHorarios() Then
                MessageBox.Show("La hora no es válida", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return False
            End If
            'Validacion de primer franja horaria
            If txtDesde1.Text <> "0000" Or txtHasta1.Text <> "0000" Then
                If txtDesde1.Text >= txtHasta1.Text Then
                    MessageBox.Show("Error en la primer franja horaria", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Return False
                End If
            End If
            'Validacion de la segunda franja horaria
            If txtDesde2.Text <> "0000" Or txtHasta2.Text <> "0000" Then
                If txtHasta1.Text > txtDesde2.Text Then
                    MessageBox.Show("Error en la segunda franja horaria", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Return False
                End If
                If txtDesde2.Text > txtHasta2.Text Then
                    MessageBox.Show("Error en la segunda franja horaria", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Return False
                End If

            End If
            'Ventana horaria de 3 horas
            If VentanaHoraria(txtDesde1.Text, txtHasta1.Text) < 3 And VentanaHoraria(txtDesde2.Text, txtHasta2.Text) < 3 Then
                MessageBox.Show("Se requiere una ventana horaria de 3 horas", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return False
            End If
            'La fecha del carrito debe coincidir con el dia de atencion del cliente
            If CarritoFecha <> Nothing Then
                txt = ""
                If CarritoFecha.DayOfWeek = DayOfWeek.Monday AndAlso bpa.AtencionLunes = False Then
                    txt = "El cliente no atiende los lunes"
                End If
                If CarritoFecha.DayOfWeek = DayOfWeek.Tuesday AndAlso bpa.AtencionMartes = False Then
                    txt = "El cliente no atiende los martes"
                End If
                If CarritoFecha.DayOfWeek = DayOfWeek.Wednesday AndAlso bpa.AtencionMiercoles = False Then
                    txt = "El cliente no atiende los miércoles"
                End If
                If CarritoFecha.DayOfWeek = DayOfWeek.Thursday AndAlso bpa.AtencionJueves = False Then
                    txt = "El cliente no atiende los jueves"
                End If
                If CarritoFecha.DayOfWeek = DayOfWeek.Friday AndAlso bpa.AtencionViernes = False Then
                    txt = "El cliente no atiende los viernes"
                End If

                If txt <> "" Then
                    MessageBox.Show(txt, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return False
                End If
            End If

        End If
        '--------------------------------------------------------------------------------
        ' FECHA DE IMPRESION DE INTERVENCION
        '--------------------------------------------------------------------------------
        If dtpTarea.Value.DayOfWeek = DayOfWeek.Saturday OrElse _
           dtpTarea.Value.DayOfWeek = DayOfWeek.Sunday OrElse _
           Fer.Existe(dtpTarea.Value) Then

            MessageBox.Show("La fecha de impresión no es un día hábil", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False
        End If
        '--------------------------------------------------------------------------------
        ' VALIDACIONES DE EMPRESA DE FACTURACION
        '--------------------------------------------------------------------------------
        If cboSociedad.SelectedValue.ToString = " " Then
            MessageBox.Show("Falta seleccionar Empresa de Facturación", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False
        End If

        If bpc.EmpresaFacturacionObligatoria = "" Then

            If LiaObligatorio() Then Return False

        Else

            If bpc.EmpresaFacturacionObligatoria <> cboSociedad.SelectedValue.ToString Then
                MessageBox.Show("Este cliente se factura solo en: " & bpc.EmpresaFacturacionObligatoria, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return False
            End If
        End If

        'Valido que no se pueda usar MON y que para GRU el cliente no sea RI
        Dim cpy As New Sociedad(cn)
        cpy.abrir(cboSociedad.SelectedValue.ToString)

        Select Case cpy.Codigo
            Case "GRU", "LIA"
                MessageBox.Show("Esta sociedad no se puede utilizar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return False

            Case "SCH"
                If bpc.RegimenImpuesto = "RI" OrElse bpc.RegimenImpuesto = "RIE" Then
                    MessageBox.Show("Esta sociedad no se puede utilizar con clientes RI", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return False
                End If

            Case "MON"
                If chkH.Checked = False Then
                    MessageBox.Show("Sociedad MON solo se puede usar para H", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return False
                End If
        End Select
        If chkH.Checked AndAlso cboSociedad.SelectedValue.ToString <> "MON" Then
            MessageBox.Show("La sociedad no permite hacer H", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False
        End If

        '--------------------------------------------------------------------------------
        ' VALIDACIONES DE TIPO DE INTERVENCION
        '--------------------------------------------------------------------------------
        Select Case cboTipo.SelectedValue.ToString
            Case " "
                MessageBox.Show("Debe seleccionar un tipo de intervencion (A1, B2...)", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                cboTipo.Focus()
                Return False

            Case "A1"
                If bpc.EsAbonado Then
                    If lvDocumentos.CheckedItems.Count = 0 Then
                        txt = "ATENCIÓN:" & vbCrLf
                        txt &= "No seleccionó la solicitud de servicio del cliente abonado." & vbCrLf & vbCrLf
                        txt &= "¿Confirma crear una nueva solicitud de servicio?" & vbCrLf

                        If MessageBox.Show(txt, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                            Return False
                        End If

                    Else
                        'Valido que la solicitud seleccionada sea de la planta D02 factura electronica
                        If lvDocumentos.CheckedItems(0).Text.StartsWith("D01") Then
                            MessageBox.Show("Debe seleccionar una Solicitud de Planta de venta D02", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Return False
                        End If

                    End If
                End If

            Case "B1"
                If txtPortero.Text.Trim = "" Then
                    MessageBox.Show("El nombre del contacto es obligatorio", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    If txtPorteroCelu.Text.Trim = "" Then txtPorteroCelu.Focus()
                    If txtPortero.Text.Trim = "" Then txtPortero.Focus()
                    Return False
                End If
                '--
                If Not Utiles.ValidarTelefono(txtPorteroCelu.Text) Then
                    MessageBox.Show("Falta teléfono del contacto o es inválido", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    txtPorteroCelu.Focus()
                    Return False
                End If
                '--
                If bpc.EsAbonado Then
                    MessageBox.Show("Tipo de intervención no permitida para clientes ABONADOS", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    cboTipo.Focus()
                    Return False

                End If

            Case "C1", "C2"
                If bpc.EsAbonado Or tiene_articulo("451021") Then

                    If lvDocumentos.CheckedItems.Count = 1 Then

                        'Valido que la solicitud sea de la planta D02 factura electronica
                        If lvDocumentos.CheckedItems.Count = 1 AndAlso lvDocumentos.CheckedItems(0).Text.StartsWith("D01") Then
                            MessageBox.Show("Debe seleccionar una Solicitud de Planta de venta D02", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Return False
                        End If
                        'Valido que la solicitud tenga contrato
                        Dim sre2 As New Solicitud(cn)
                        Dim con2 As ContratoServicio

                        sre2.Abrir(lvDocumentos.CheckedItems(0).Text)
                        con2 = sre2.Contrato

                        If Not (con2.Numero <> "" And (sre2.TipoCovertura = 1 Or sre2.TipoCovertura = 4)) Then
                            MessageBox.Show("Debe seleccionar una Solicitud cubierta por contrato", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            sre2 = Nothing
                            Return False
                        End If
                        sre2 = Nothing

                    Else

                        If usr.PuedeCrearSolicitudAbonados Then
                            txt = "ATENCIÓN:" & vbCrLf
                            txt &= "No seleccionó la solicitud de servicio del cliente abonado." & vbCrLf & vbCrLf
                            txt &= "¿Confirma crear una nueva solicitud de servicio?" & vbCrLf

                            If MessageBox.Show(txt, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                                Return False
                            End If

                        Else

                            MessageBox.Show("Debe seleccionar una Solicitud de Servicio", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Return False

                        End If

                    End If

                Else
                    MessageBox.Show("Tipo de intervención no permitida para clientes NO abonados", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    cboTipo.Focus()
                    Return False

                End If

                If Not Sustitutos() Then Return False

            Case "D1"
                If txtOT.Text = "" Then
                    MessageBox.Show("Debe ingresar el número de OT (seis digitos)", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    txtOT.Focus()
                    Return False
                End If

                If bpc.EsAbonado Then
                    If lvDocumentos.CheckedItems.Count = 0 Then

                        'Permito que vendedores no tengan que seleccionar SS
                        If usr.PuedeCrearSolicitudAbonados Then
                            txt = "ATENCIÓN:" & vbCrLf
                            txt &= "¿Está seguro que este trabajo no está incluido en el contrato?" & vbCrLf & vbCrLf
                            txt &= "¿Confirma crear una nueva solicitud de servicio?" & vbCrLf

                            If MessageBox.Show(txt, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                                MessageBox.Show("Debe seleccionar una Solicitud de Servicio", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Return False
                            End If

                        Else
                            MessageBox.Show("Debe seleccionar una Solicitud de Servicio", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Return False

                        End If

                    Else

                        'Valido que la solicitud sea de la planta D02 factura electronica
                        If lvDocumentos.CheckedItems.Count > 0 AndAlso lvDocumentos.CheckedItems(0).Text.StartsWith("D01") Then
                            MessageBox.Show("Debe seleccionar una Solicitud de Planta de venta D02", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Return False
                        End If

                    End If

                End If

            Case "E1", "E2"
                If bpc.EsAbonado AndAlso lvDocumentos.CheckedItems.Count = 0 Then
                    txt = "ATENCIÓN:" & vbCrLf
                    txt &= "¿Está seguro que este trabajo no está incluido en el contrato?" & vbCrLf & vbCrLf
                    txt &= "¿Confirma crear una nueva solicitud de servicio?" & vbCrLf

                    'Permito que vendedores no tengan que seleccionar SS
                    If usr.PuedeCrearSolicitudAbonados Then
                        If MessageBox.Show(txt, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                            MessageBox.Show("Debe seleccionar una Solicitud de Servicio", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Return False
                        End If

                    Else
                        MessageBox.Show("Debe seleccionar una Solicitud de Servicio", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Return False

                    End If

                Else
                    'Valido que la solicitud sea de la planta D02 factura electronica
                    If lvDocumentos.CheckedItems.Count > 0 AndAlso lvDocumentos.CheckedItems(0).Text.StartsWith("D01") Then
                        MessageBox.Show("Debe seleccionar una Solicitud de Planta de venta D02", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return False
                    End If

                End If

            Case "F1"
                If bpc.EsAbonado Then
                    If lvDocumentos.CheckedItems.Count = 0 Then
                        txt = "ATENCIÓN:" & vbCrLf
                        txt &= "¿Está seguro que este trabajo no está incluido en el contrato?" & vbCrLf & vbCrLf
                        txt &= "¿Confirma crear una nueva solicitud de servicio?" & vbCrLf

                        'Permito que vendedores no tengan que seleccionar SS
                        If usr.PuedeCrearSolicitudAbonados Then
                            If MessageBox.Show(txt, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                                MessageBox.Show("Debe seleccionar una Solicitud de Servicio", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Return False
                            End If

                        Else
                            MessageBox.Show("Debe seleccionar una Solicitud de Servicio", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Return False
                        End If

                    Else
                        'Valido que la solicitud seleccionada sea de la planta D02 factura electronica
                        If lvDocumentos.CheckedItems(0).Text.StartsWith("D01") Then
                            MessageBox.Show("Debe seleccionar una Solicitud de Planta de venta D02", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Return False
                        End If

                    End If
                End If

                'No deben existir articulos 50* y 55* en la misma intervencion
                Dim flg50 As Boolean = False
                Dim flg55 As Boolean = False

                For Each dr As DataRow In dtRetiros.Rows
                    If dr("itmref_0").ToString.StartsWith("50") Then flg50 = True
                    If dr("itmref_0").ToString.StartsWith("55") Then flg55 = True
                Next

                If flg50 And flg55 Then
                    MessageBox.Show("No se pueden incluir articulos 50* y 55* en la misma intervención", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return False
                End If

            Case "G1"

            Case "H1"

            Case "T1"

            Case Else
                MessageBox.Show("Tipo de intervención desconocida", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                cboTipo.Focus()
                Return False
        End Select
        '--------------------------------------------------------------------------------
        ' VALIDACION ARTICULOS SEGUN TIPO DE INTERVENCIÓN
        '--------------------------------------------------------------------------------
        For Each dr As DataRow In dtRetiros.Rows
            If Not PermiteArticuloEnIntervencion(dr("itmref_0").ToString, cboTipo.SelectedValue.ToString) Then
                txt = "El artículo " & dr("itmref_0").ToString & _
                      " no se permite en intervención tipo " & cboTipo.SelectedValue.ToString

                MessageBox.Show(txt, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return False
            End If
        Next
        '--------------------------------------------------------------------------------
        ' VALIDACION CONDICIONES DE PAGO
        '--------------------------------------------------------------------------------
        Select Case cboTipo.SelectedValue.ToString
            Case "A1", "E1", "F1"
                'Se ignora esta validacion para estos articulos
                If cboTipo.SelectedValue.ToString = "A1" Then
                    'Recorro las lineas de retiro
                    For Each dr As DataRow In dtRetiros.Rows
                        If dr("itmref_0").ToString = "652011" Then Exit Select
                    Next
                ElseIf cboTipo.SelectedValue.ToString = "E1" Then
                    For Each dr As DataRow In dtRetiros.Rows
                        If dr("itmref_0").ToString = "659012" Then Exit Select
                    Next
                ElseIf cboTipo.SelectedValue.ToString = "F1" Then
                    For Each dr As DataRow In dtRetiros.Rows
                        If dr("itmref_0").ToString = "553001" Then Exit Select
                    Next
                End If

                txt = "Condición de pago no permitida para la creación de intervenciones tipo " & cboTipo.SelectedValue.ToString & vbCrLf & vbCrLf

                If lvDocumentos.CheckedItems.Count = 1 Then
                    Dim xSre As New Solicitud(cn)

                    xSre.Abrir(lvDocumentos.CheckedItems(0).Text)

                    If xSre.CondicionPago.Codigo >= "001" AndAlso xSre.CondicionPago.Codigo <= "021" Then

                        txt &= "La condición de pago de la solicitud es: " & xSre.CondicionPago.Codigo & " " & xSre.CondicionPago.Descripcion
                        MessageBox.Show(txt, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Return False
                    End If

                Else

                    'If bpc.CondicionPago.Codigo >= "001" AndAlso bpc.CondicionPago.Codigo <= "021" Then
                    If cboCondicionPago.SelectedValue.ToString >= "001" AndAlso cboCondicionPago.SelectedValue.ToString <= "021" Then
                        txt &= "La condición de pago seleccionada es: " & cboCondicionPago.SelectedValue.ToString
                        MessageBox.Show(txt, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Return False
                    End If

                End If

                txt = ""

        End Select
        '--------------------------------------------------------------------------------
        ' VALIDACIONES DE GRILLA DE RETIROS
        '--------------------------------------------------------------------------------
        If dtRetiros.Rows.Count = 0 Then
            MessageBox.Show("Falta cargar Retiros/Sustitutos", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False
        End If
        '--------------------------------------------------------------------------------
        ' VALIDACIONES DE GRILLA DE RETIROS - CANTIDADES EN CERO
        '--------------------------------------------------------------------------------
        For Each dr As DataRow In dtRetiros.Rows
            If CInt(dr("tqty_0")) = 0 Then
                MessageBox.Show("Cantidades deben ser mayor a cero", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return False
            End If
        Next
        '--------------------------------------------------------------------------------
        ' VALIDACION DE PRECIOS EN CERO
        '--------------------------------------------------------------------------------
        If Not chkReclamo.Checked Then
            If txtCodigoCliente.Text <> "402000" AndAlso cboTipo.SelectedValue.ToString <> "C1" AndAlso PreciosEnCero(dtRetiros, "451") Then
                MessageBox.Show("Hay artículos 451 sin precio", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return False
            End If
            If cboTipo.SelectedValue.ToString <> "E1" AndAlso cboTipo.SelectedValue.ToString <> "E2" Then
                If PreciosEnCero(dtRetiros, "551000") Then
                    MessageBox.Show("Artículo 551000 sin precio", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return False
                End If
                If PreciosEnCero(dtRetiros, "551022") Then
                    MessageBox.Show("Artículo 551022 sin precio", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return False
                End If
                If PreciosEnCero(dtRetiros, "551015") Then
                    MessageBox.Show("Artículo 551015 sin precio", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return False
                End If
            End If
        End If
        '--------------------------------------------------------------------------------
        ' VALIDACIONES DE LOGISTICA
        '--------------------------------------------------------------------------------
        If txtCarrito.Text.Trim <> "" Then
            If dtpTarea.Value >= CarritoFecha Then
                MessageBox.Show("La fecha de impresión debe ser anterior a la de coordinacion", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                dtpTarea.Focus()
                Return False
            End If
        End If
        'La fecha de impresion debe ser mayor a hoy
        If dtpTarea.Value <= Date.Today Then
            MessageBox.Show("La fecha de impresión debe ser mayor a hoy", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            dtpTarea.Focus()
            Return False
        End If
        '--------------------------------------------------------------------------------
        ' VALIDACIONES DE CARRITO
        '--------------------------------------------------------------------------------
        If CarritoTipo > 0 AndAlso "B1B2".IndexOf(cboTipo.SelectedValue.ToString) = -1 Then
            MessageBox.Show("No se puede usar carrito con intervenciones " & cboTipo.SelectedValue.ToString, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False
        End If
        '--------------------------------------------------------------------------------
        ' VALIDACION DE INTEVENCION EXISTENTE CREADA DENTRO DE LOS ULTIMOS 7 DIAS
        '--------------------------------------------------------------------------------
        If Not cboTipo.SelectedValue.ToString = "C1" Then
            Dim xItn As Intervencion = Nothing
            Dim dias As Integer

            If "B1B2".IndexOf(cboTipo.SelectedValue.ToString) > -1 Then
                xItn = ExiteItervencion90Dias(txtCodigoCliente.Text, txtSucursal.Text, chkReclamo.Checked)
                dias = 90
            ElseIf cboTipo.SelectedValue.ToString = "E1" Then
                For Each dr As DataRow In dtRetiros.Rows
                    xItn = ExiteItervencion90DiasE1(txtCodigoCliente.Text, txtSucursal.Text, dr("itmref_0").ToString, chkReclamo.Checked)
                    dias = 90
                    If xItn IsNot Nothing Then Continue For
                Next
            Else
                xItn = ExiteItervencion7Dias(txtCodigoCliente.Text, txtSucursal.Text, cboTipo.SelectedValue.ToString, chkReclamo.Checked)
                dias = 7
            End If

            If xItn IsNot Nothing Then
                txt = "Se encontró la intervención {tipo}-{num} creada en los últimos {dias} días "
                txt &= "para el mismo clientes/sucursal." & vbCrLf & vbCrLf

                txt = txt.Replace("{tipo}", xItn.Tipo)
                txt = txt.Replace("{num}", xItn.Numero)
                txt = txt.Replace("{dias}", dias.ToString)

                Select Case cboTipo.SelectedValue.ToString
                    Case "A1", "B1", "E1", "H1"
                        txt &= "No es posible crear la intervención"
                        MessageBox.Show(txt, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Function

                    Case Else
                        txt &= "¿Igualmente desea crear la intervención?"
                        If MessageBox.Show(txt, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                            Exit Function
                        End If

                End Select

            End If
        End If
        '---------------------------------------------------------------------------------
        ' VALIDACION DE NUMERO DE OT
        '--------------------------------------------------------------------------------
        Select Case cboTipo.SelectedValue.ToString
            Case "A1", "B1", "E1"
                If txtOT.Text.Trim <> "" Then
                    txt = "No se permite número de OT a intervenciones tipo " & cboTipo.SelectedValue.ToString
                    MessageBox.Show(txt, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Function
                End If

        End Select

        '-------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'Bloquear la creacion de intervencion C1 si existe otra intervencion C1 para el mismo cliente/sucursal en estado Pendiente y con el mismo valor en el campo reclamo.
        '-------------------------------------------------------------------------------------------------------------------------------------------------------------------
        If cboTipo.SelectedValue.ToString = "C1" AndAlso TieneC1Igual(txtCodigoCliente.Text.ToString, txtSucursal.Text.ToString, CInt(IIf(chkReclamo.Checked, 1, 2))) Then
            Return False
        End If

        Return True

    End Function
    Private Function TieneC1Igual(ByVal cliente As String, ByVal sucursal As String, ByVal reclamo As Integer) As Boolean
        Dim Sql As String
        Dim da As OracleDataAdapter
        Dim dt As New DataTable
        Dim itn As Intervencion = Nothing

        Sql = "SELECT * "
        Sql &= "FROM interven "
        Sql &= "WHERE bpc_0 = :bpc_0 AND bpaadd_0 = :suc AND zflgtrip_0 in ('1','6','7') and ymrkitn_0 = :re and typ_0 = 'C1' "
        Sql &= "ORDER BY credat_0 desc"

        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("bpc_0", OracleType.VarChar).Value = cliente
        da.SelectCommand.Parameters.Add("suc", OracleType.VarChar).Value = sucursal
        da.SelectCommand.Parameters.Add("re", OracleType.Int16).Value = reclamo

        da.Fill(dt)
        da.Dispose()

        If dt.Rows.Count > 0 Then
            Dim dr As DataRow = dt.Rows(0)
            Dim txt As String

            txt = "Se encontró la intervención {itn} en estado NO cerrada. No se puede crear una nueva intervención."
            txt = txt.Replace("{itn}", dr("num_0").ToString)

            MessageBox.Show(txt, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)

            Return True
        End If

        Return False

    End Function
    Private Function tiene_articulo(ByVal art As String) As Boolean
        Dim flg As Boolean = False
        For Each dr As DataRow In dtRetiros.Rows
            If dr("itmref_0").ToString = art Then flg = True
        Next
        Return flg
    End Function
    Private Function PermiteArticuloEnIntervencion(ByVal Articulo As String, ByVal Tipo As String) As Boolean
        'Valida si el articulo puede ser incluido en una intervención del tipo
        Dim flg As Boolean = False

        Select Case Tipo
            Case "A1"

                If Articulo.StartsWith("65") Then
                    flg = True
                End If

            Case "B1", "D1"

                If Articulo.StartsWith("45") OrElse _
                   Articulo.StartsWith("50") OrElse _
                   Articulo.StartsWith("60") Then

                    flg = True
                End If

            Case "C1", "C2"

                If Articulo.StartsWith("45") OrElse _
                   Articulo.StartsWith("50") OrElse _
                   Articulo.StartsWith("60") Then

                    flg = True
                End If

            Case "E1"
                If usr.Codigo.Length = 2 Then
                    If Articulo = "551015" Or _
              Articulo = "551068" Or _
              Articulo = "551004" Or _
              Articulo = "551054" Or _
              Articulo = "551055" Or _
              Articulo = "551057" Or _
              Articulo = "551062" Or _
              Articulo = "551064" Or _
              Articulo = "551072" Or _
              Articulo = "551074" Or _
              Articulo = "551071" Or _
              Articulo = "551014" Or _
              Articulo = "659012" Then
                        flg = True
                    End If
                Else
                    If Articulo = "551015" Or _
              Articulo = "551068" Or _
              Articulo = "551003" Or _
              Articulo = "551004" Or _
              Articulo = "551060" Or _
              Articulo = "551054" Or _
              Articulo = "551055" Or _
              Articulo = "551056" Or _
              Articulo = "551057" Or _
              Articulo = "551058" Or _
              Articulo = "551062" Or _
              Articulo = "551063" Or _
              Articulo = "551064" Or _
              Articulo = "551072" Or _
              Articulo = "551073" Or _
              Articulo = "551074" Or _
              Articulo = "551070" Or _
              Articulo = "551071" Or _
              Articulo = "551078" Or _
              Articulo = "551079" Or _
              Articulo = "551080" Or _
              Articulo = "551014" Or _
              Articulo = "659012" Then
                        flg = True
                    End If
                End If


            Case "E2"
                If usr.Codigo.Length = 2 Then
                    If Articulo = "551000" Or _
                    Articulo = "551012" Or _
                    Articulo = "551013" Or _
                    Articulo = "551022" Or _
                    Articulo = "659012" Or _
                    Articulo = "551002" Or _
                    Articulo = "551005" Or _
                    Articulo = "551006" Or _
                    Articulo = "551007" Or _
                    Articulo = "551022" Or _
                    Articulo = "551001" Or _
                    Articulo = "551059" Or _
                    Articulo = "551061" Or _
                    Articulo = "501019" Or _
                    Articulo = "551076" Or _
                    Articulo = "551065" Or _
                    Articulo = "551067" Or _
                    Articulo = "551066" Or _
                    Articulo = "551077" Or _
                    Articulo = "551086" Or _
                    Articulo = "551087" Or _
                    Articulo = "551090" Or _
                    Articulo = "551093" Or _
                    Articulo = "551094" Or _
                    Articulo = "551032" Then
                        flg = True
                    End If
                Else
                    If Articulo = "551000" Or _
                       Articulo = "551005" Or _
                       Articulo = "551006" Or _
                       Articulo = "551007" Or _
                       Articulo = "551012" Or _
                       Articulo = "551013" Or _
                       Articulo = "551022" Or _
                       Articulo = "659012" Or _
                       Articulo = "551002" Or _
                       Articulo = "551037" Or _
                       Articulo = "551022" Or _
                       Articulo = "551001" Or _
                       Articulo = "551036" Or _
                       Articulo = "551059" Or _
                       Articulo = "551061" Or _
                       Articulo = "551035" Or _
                       Articulo = "501019" Or _
                       Articulo = "551075" Or _
                       Articulo = "551076" Or _
                       Articulo = "551065" Or _
                       Articulo = "551034" Or _
                       Articulo = "551067" Or _
                       Articulo = "551066" Or _
                       Articulo = "551021" Or _
                       Articulo = "551077" Or _
                       Articulo = "551086" Or _
                       Articulo = "551087" Or _
                       Articulo = "551093" Or _
                       Articulo = "551094" Or _
                       Articulo = "551032" Then
                        flg = True
                    End If
                End If

            Case "F1"

                If Articulo.StartsWith("5530") OrElse _
                   Articulo.StartsWith("504") OrElse _
                   Articulo.StartsWith("505") OrElse _
                   Articulo = "659012" Or _
                   Articulo.StartsWith("60") Then
                    flg = True
                End If

            Case "G1"
                If Articulo = "601003" Or Articulo = "607003" Then
                    flg = True
                End If

            Case "H1"
                If Articulo.StartsWith("459") Then
                    flg = True
                End If

            Case "T1"
                Return Articulo = "992014"

        End Select

        Return flg

    End Function
    Private Function ExiteItervencion7Dias(ByVal Cliente As String, ByVal Sucursal As String, ByVal TipoIntervencion As String, ByVal Reclamo As Boolean) As Intervencion
        Dim Sql As String
        Dim da As OracleDataAdapter
        Dim dt As New DataTable
        Dim itn As Intervencion = Nothing

        Sql = "SELECT * "
        Sql &= "FROM interven "
        Sql &= "WHERE bpc_0 = :bpc_0 AND "
        Sql &= "      bpaadd_0 = :suc AND "
        Sql &= "      typ_0 = :tipo and "
        Sql &= "      credat_0 > trunc(sysdate-7) and "
        Sql &= "      ymrkitn_0 = :reclamo "
        Sql &= "ORDER BY credat_0 desc"

        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("bpc_0", OracleType.VarChar).Value = Cliente
        da.SelectCommand.Parameters.Add("suc", OracleType.VarChar).Value = Sucursal
        da.SelectCommand.Parameters.Add("tipo", OracleType.VarChar).Value = TipoIntervencion
        da.SelectCommand.Parameters.Add("reclamo", OracleType.Number).Value = IIf(Reclamo, 1, 2)
        da.Fill(dt)
        da.Dispose()

        If dt.Rows.Count > 0 Then
            Dim dr As DataRow = dt.Rows(0)

            itn = New Intervencion(cn)
            itn.Abrir(dr("num_0").ToString)
        End If

        Return itn

    End Function
    Private Function Precio(ByVal Cliente As String, ByVal CodigoArticulo As String, ByVal Cantidad As Double) As Double
        Return tar.ObtenerPrecio(Cliente, CodigoArticulo, Cantidad)
    End Function
    Private Function ExiteItervencion90Dias(ByVal Cliente As String, ByVal Sucursal As String, ByVal Reclamo As Boolean) As Intervencion
        Dim Sql As String
        Dim da As OracleDataAdapter
        Dim dt As New DataTable
        Dim itn As Intervencion = Nothing

        Sql = "SELECT * "
        Sql &= "FROM interven "
        Sql &= "WHERE bpc_0 = :bpc_0 AND "
        Sql &= "      bpaadd_0 = :suc AND "
        Sql &= "      typ_0 in ('B1', 'B2') and "
        Sql &= "      credat_0 > trunc(sysdate-90) and "
        Sql &= "      zflgtrip_0 in (1, 6, 7) and "
        Sql &= "      ymrkitn_0 = :reclamo "
        Sql &= "ORDER BY credat_0 desc"

        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("bpc_0", OracleType.VarChar).Value = Cliente
        da.SelectCommand.Parameters.Add("suc", OracleType.VarChar).Value = Sucursal
        da.SelectCommand.Parameters.Add("reclamo", OracleType.Number).Value = IIf(Reclamo, 1, 2)
        da.Fill(dt)
        da.Dispose()

        If dt.Rows.Count > 0 Then
            Dim dr As DataRow = dt.Rows(0)

            itn = New Intervencion(cn)
            itn.Abrir(dr("num_0").ToString)
        End If

        Return itn

    End Function
    Private Function ExiteItervencion90DiasE1(ByVal Cliente As String, ByVal Sucursal As String, ByVal item As String, ByVal Reclamo As Boolean) As Intervencion
        Dim Sql As String
        Dim da As OracleDataAdapter
        Dim dt As New DataTable
        Dim itn As Intervencion = Nothing

        Sql = "SELECT * "
        Sql &= "FROM interven itn inner join yitndet yitn on (itn.num_0 = yitn.num_0) "
        Sql &= "WHERE typ_0 in ('E1') and "
        Sql &= "      credat_0 > trunc(sysdate-90) and "
        Sql &= "      bpc_0 = :bpc_0 AND "
        Sql &= "      bpaadd_0 = :suc AND "
        Sql &= "      itmref_0 = :articulo and "
        Sql &= "      ymrkitn_0 = :reclamo "
        Sql &= "ORDER BY credat_0 desc"

        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("bpc_0", OracleType.VarChar).Value = Cliente
        da.SelectCommand.Parameters.Add("suc", OracleType.VarChar).Value = Sucursal
        da.SelectCommand.Parameters.Add("articulo", OracleType.VarChar).Value = item
        da.SelectCommand.Parameters.Add("reclamo", OracleType.Number).Value = IIf(Reclamo, 1, 2)
        da.Fill(dt)
        da.Dispose()

        If dt.Rows.Count > 0 Then
            Dim dr As DataRow = dt.Rows(0)

            itn = New Intervencion(cn)
            itn.Abrir(dr("num_0").ToString)
        End If

        Return itn

    End Function
    Private Function ValidacionHorarios() As Boolean

        If Not Utiles.ValidarHora(txtDesde1.Text) Then
            txtDesde1.Focus()
            Return False
        End If
        If Not Utiles.ValidarHora(txtDesde2.Text) Then
            txtDesde2.Focus()
            Return False
        End If
        If Not Utiles.ValidarHora(txtHasta1.Text) Then
            txtHasta1.Focus()
            Return False
        End If
        If Not Utiles.ValidarHora(txtHasta2.Text) Then
            txtHasta2.Focus()
            Return False
        End If

        Return True

    End Function
    Private Function ValidarContrato(ByVal ss As Solicitud) As Boolean
        Dim txt As String
        Dim flg As Boolean = True

        txt = "No se puede crear la intervención" & vbCrLf & vbCrLf

        con = ss.Contrato

        If con IsNot Nothing Then

            'Salgo si no tiene contrato
            If con.Numero = "" Then Return True

            With con
                'Verifico que el contrato este activo
                If .Cerrado Then
                    txt &= "La solicitud está asociada a un contrato cerrado (" & con.Numero & ")"
                    flg = False
                End If

                'Verifico que no este rescindido
                If flg AndAlso .Rescindido Then
                    txt &= "La solicitud está asociada a un contrato rescindido (" & con.Numero & ")"
                    flg = False
                End If

                'Verifico que este vigente (fecha)
                If flg AndAlso Not .ContratoVigente(dtpTarea.Value) Then
                    txt &= "La solicitud está asociada a un contrato que no cubre la fecha " & dtpTarea.Value.ToShortDateString
                    flg = False
                End If

                'Verifico que la sucursal este incluida en el contrato
                If flg AndAlso Not .IncluyeSucursal(txtSucursal.Text) Then
                    txt &= "La solicitud está asociada a un contrato que no incluye a la sucursal " & txtSucursal.Text
                    flg = False
                End If

                'Verificar las cantidades de cobertura
                If Not chkReclamo.Checked Then
                    If flg AndAlso Not .VerificarCobertura(dtRetiros, txtSucursal.Text) Then
                        flg = False
                        Return flg
                    End If
                End If

            End With

        End If

        If Not flg Then MessageBox.Show(txt, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)

        Return flg

    End Function
    Private Function PreciosEnCero(ByVal dt As DataTable, Optional ByVal Codigo As String = "") As Boolean
        Dim dr As DataRow
        Dim flg = False

        For Each dr In dt.Rows
            If Codigo = "" AndAlso CSng(dr("amt_0")) <= 0.0! Then
                flg = True
            ElseIf dr("itmref_0").ToString.StartsWith(Codigo) AndAlso CSng(dr("amt_0")) <= 0.0! Then
                flg = True
            End If

            If flg Then Exit For

        Next

        Return flg

    End Function
    Private Function VentanaHoraria(ByVal Hora1 As String, ByVal Hora2 As String) As Double
        Dim h1, h2 As Double
        Dim hh, mm As Integer

        hh = CInt(Hora1.Substring(0, 2))
        mm = CInt(Hora1.Substring(2, 2))
        h1 = hh + mm / 60

        hh = CInt(Hora2.Substring(0, 2))
        mm = CInt(Hora2.Substring(2, 2))
        h2 = hh + mm / 60

        Return h2 - h1

    End Function
    Private Function Sustitutos() As Boolean
        'Extintores
        Dim Equipos1 As Integer = 0
        Dim Prestamos1 As Integer = 0
        'Mangueras
        Dim Equipos2 As Integer = 0
        Dim Prestamos2 As Integer = 0

        Dim Art As String = ""
        Dim Qty As Integer = 0

        Dim flg As Boolean = False

        For Each dr As DataRow In dtRetiros.Rows
            Art = dr("itmref_0").ToString
            Qty = CInt(dr("tqty_0"))

            Select Case Art
                Case ARTICULO_PRESTAMO_EXT
                    Prestamos1 += Qty

                Case ARTICULO_PRESTAMO_MAN
                    Prestamos2 += Qty

                Case Else

                    If Art.StartsWith("45") Then
                        Equipos1 += Qty

                    ElseIf Art.StartsWith("50") Then
                        Equipos2 += Qty

                    End If
            End Select
        Next

        If Equipos1 <> Prestamos1 Then
            Art = "No coincide la cantidad de exintores y sustitutos"

        ElseIf Equipos2 <> Prestamos2 Then
            Art = "No coincide la cantidad de mangueras y sustitutos"

        Else
            flg = True
            Art = ""
        End If

        If Art <> "" Then
            Art &= vbCrLf
            Art &= vbCrLf
            Art &= "¿Continua de todas formas?"

            If MessageBox.Show(Art, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                flg = True
            Else
                flg = False
            End If
        End If

        Return flg

    End Function
    Private Function FindFocussedControl(ByVal ctr As System.Windows.Forms.Control) As System.Windows.Forms.Control
        Dim cc As ContainerControl = TryCast(ctr, ContainerControl)

        Do While (cc IsNot Nothing)
            ctr = cc.ActiveControl
            cc = TryCast(ctr, ContainerControl)
        Loop

        Return ctr

    End Function
    Private Function LiaObligatorio() As Boolean
        'No obligatorio si es Retira por Georgia
        If CInt(cboModoEntrega.SelectedValue) = 2 Then Return False

        Dim bpc As New Cliente(cn)

        bpc.Abrir(txtCodigoCliente.Text)

        'No es obligatorio si no es CF
        If bpc.RegimenImpuesto <> "CF" Then Return False
        'No se incluye a vendedores 22 23 28
        If bpc.Vendedor1Codigo = "22" OrElse bpc.Vendedor1Codigo = "23" OrElse bpc.Vendedor1Codigo = "28" Then Return False
        'Obligatorio para pedidos menores a MONTO_LIA_OBLIGATORIO
        If PrecioTotal() >= MONTO_LIA_OBLIGATORIO Then Return False
        'Obligatorio si NO tiene facturas en el historico
        If bpc.TieneFacturas Then Return False
        'Debe ser LIA o H
        If Not (cboSociedad.SelectedValue.ToString = "SCH" Or chkH.Checked) Then
            Dim msg As String = "Debe usar sociedad SCH o H para este cliente"
            MessageBox.Show(msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return True
        End If

        Return False

    End Function
    Private Function PrecioTotal() As Double
        Dim p As Double = 0

        For Each dr As DataRow In dtRetiros.Rows
            Dim c As Double = CDbl(dr("tqty_0"))
            Dim t As Double = CDbl(dr("amt_0"))

            p += c * t
        Next

        Return p
    End Function

    Public ReadOnly Property Documento() As Intervencion
        Get
            Return itn
        End Get
    End Property
    Public ReadOnly Property Equipos() As Integer
        Get
            Dim da As OracleDataAdapter
            Dim Sql As String
            Dim dt As New DataTable
            Dim dr As DataRow
            Dim v As Integer

            Sql = "SELECT SUM(qty_0) AS qty_0 "
            sql &= "FROM yitndet itn INNER JOIN itmmaster itm ON (itn.itmref_0 = itm.itmref_0) "
            Sql &= "WHERE num_0 = :num_0 AND cfglin_0 = '451'"

            da = New OracleDataAdapter(Sql, cn)
            da.SelectCommand.Parameters.Add("num_0", OracleType.VarChar).Value = itn.Numero

            da.Fill(dt)

            dr = dt.Rows(0)

            If IsDBNull(dr(0)) Then
                v = 0

            Else
                v = CInt(dr(0))

            End If
            da.Dispose()
            dt.Dispose()

            Return v

        End Get
    End Property

    Private Sub cboTipo_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTipo.SelectedValueChanged
        If cboTipo.SelectedValue.ToString = "D1" Then
            cboModoEntrega.SelectedValue = 2
        End If
    End Sub

End Class