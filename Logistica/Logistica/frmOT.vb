Imports System.Data.OracleClient

Public Class frmOT
    Private daArticulos As New OracleDataAdapter
    Private daYitndet As New OracleDataAdapter

    Private dtArticulos As New DataTable
    Private dtYitndet As New DataTable

    Private bpc As New Cliente(cn)
    Private sre As New Solicitud(cn)
    Private itn As New Intervencion(cn)

    Private Sub Adaptadores()
        Dim Sql As String

        'CREACION DE ADAPTADORES PARA: ARTICULOS
        Sql = "SELECT itmref_0, itmdes1_0 FROM itmmaster WHERE itmref_0 LIKE '45%' OR itmref_0 LIKE '50%'"
        daArticulos.SelectCommand = New OracleCommand(Sql, cn)

        'CREACION DE ADAPTADORES PARA: YITNDET
        Sql = "SELECT * FROM yitndet WHERE num_0 = :p1"
        daYitndet.SelectCommand = New OracleCommand(Sql, cn)
        daYitndet.SelectCommand.Parameters.Add("p1", OracleType.VarChar)

    End Sub
    Private Sub Columnas()
        With dtYitndet.Columns
            .Item("numlig_0").AutoIncrement = True
            .Item("numlig_0").AutoIncrementSeed = 1000
            .Item("numlig_0").AutoIncrementStep = 1000
            .Item("num_0").DefaultValue = " "
            .Item("uom_0").DefaultValue = "UN"
            .Item("tqty_0").DefaultValue = 0
            .Item("tuom_0").DefaultValue = "UN"
            .Item("yqty2_0").DefaultValue = 0
            .Item("factura_0").DefaultValue = 0
            .Item("typlig_0").DefaultValue = 1
            .Item("amt_0").DefaultValue = 0
            .Item("srenum_0").DefaultValue = " "
        End With

        'Enlazar columnas
        colAmt.DataPropertyName = "amt_0"
        colFactura.DataPropertyName = "factura_0"
        colItmref.DataPropertyName = "itmref_0"
        colNum.DataPropertyName = "num_0"
        colNumlig.DataPropertyName = "numlig_0"
        colQty.DataPropertyName = "qty_0"
        colTqty.DataPropertyName = "tqty_0"
        colTuom.DataPropertyName = "tuom_0"
        colTyplig.DataPropertyName = "typlig_0"
        colUom.DataPropertyName = "uom_0"
        colYqty2.DataPropertyName = "yqty2_0"
        colSre.DataPropertyName = "srenum_0"
        dgv.DataSource = dtYitndet

    End Sub
    Private Sub ComboTipos()
        Dim dtTipo As New DataTable
        Dim daTipo As New OracleDataAdapter
        Dim Sql As String

        Sql = "SELECT ident2_0, ident2_0 || ' - ' || texte_0 AS texte_0 FROM atextra WHERE codfic_0 = 'ATABDIV' AND ident1_0 = 407 AND langue_0 = 'SPA' AND zone_0 = 'LNGDES' ORDER BY ident2_0"
        daTipo = New OracleDataAdapter(Sql, cn)

        daTipo.Fill(dtTipo)

        'Enlazar combo tipo de intervención
        With cboTipo
            .DataSource = dtTipo
            .DisplayMember = "texte_0"
            .ValueMember = "ident2_0"
        End With

        daTipo.Dispose()

    End Sub

    'FUNCIONES
    Private Function Validar() As Boolean
        'Valido que exista codigo de cliente cargado
        If txtCliente.Text.Length = 0 Then
            MessageBox.Show("Falta seleccionar cliente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False
        End If

        'Valido que haya cargado numero de OTR
        If mtbOTR.Text.Length = 0 Then
            MessageBox.Show("Falta cargar número de OTR", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False
        End If

        If nudPrestamosExt.Value = 0 Then
            If MessageBox.Show("¿Confirma que no se dejaron préstamos?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                nudPrestamosExt.Focus()
                Return False
            End If
        End If

        If rbSS1.Checked Then
            'Valido que se haya seleccionado la empresa de facturacion
            If cboEmpresas.SelectedValue.ToString = " " Then
                MessageBox.Show("Falta seleccionar empresa de facturación", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return False
            End If
        Else
            'Valido que la SS seleccionada no sea de la planta D01
            If lstSS.SelectedValue.ToString.StartsWith("D01") Then
                MessageBox.Show("Debe seleccionar una Solicitud que pertenezca a la planta de venta D02", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return False
            End If
        End If

        'Valido que se hayan cargado retiros
        If dtYitndet.Rows.Count = 0 Then
            MessageBox.Show("Falta cargar los retiros", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False
        End If

        Return True

    End Function

    'EVENTOS
    Private Sub frmOTR_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Adaptadores()

        Try
            daArticulos.Fill(dtArticulos)
            daYitndet.FillSchema(dtYitndet, SchemaType.Mapped)

            ComboTipos()

            'Lleno el combo de sociedades
            With cboEmpresas
                .DataSource = Sociedad.Sociedades(cn, True)
                .ValueMember = "cpy_0"
                .DisplayMember = "cpynam_0"
            End With

            Columnas()

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        Finally
            txtCod.Tag = False  'Usada para saber si se cambio el valor del control

        End Try

    End Sub
    Private Sub txtCod_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCod.LostFocus

        If CBool(txtCod.Tag) = True Then

            'Abro cliente
            If bpc.Abrir(txtCod.Text) Then

                txtCliente.Text = bpc.Nombre

                'Consulto sucursales del cliente y las enlazo al combo
                With cboSucursal
                    .DataSource = bpc.SucursalesTabla
                    .DisplayMember = "direccion"
                    .ValueMember = "bpaadd_0"
                End With

                'Si cliente es abonado, recupero SS abiertas
                With lstSS
                    .DataSource = bpc.SolicitudesAbiertas
                    .DisplayMember = "texto"
                    .ValueMember = "srenum_0"
                End With


                If bpc.EsAbonado Then
                    rbSS2.Checked = True
                    rbSS1.Enabled = False
                    rbSS2.Enabled = True
                Else
                    If lstSS.Items.Count = 0 Then
                        rbSS1.Checked = True
                    Else
                        rbSS2.Checked = True
                    End If

                    rbSS1.Enabled = True
                    rbSS2.Enabled = (lstSS.Items.Count > 0)
                End If

                cboEmpresas.SelectedValue = bpc.EmpresaFacturacion

            Else
                MessageBox.Show("No se encontró el cliente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtCliente.Clear()
                txtCod.Focus()
                txtCod.SelectAll()

            End If

            txtCod.Tag = False

        End If

    End Sub
    Private Sub txtCod_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCod.TextChanged
        txtCod.Tag = True
    End Sub
    Private Sub dgv_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dgv.CellValidating
        'Verifico si existe el articulo ingresado
        If e.ColumnIndex = 3 Then   'Columna articulo

            If e.FormattedValue.ToString.Trim <> "" Then
                'Filtro por el codigo de articulo ingresado en la celda
                Dim dv As New DataView(dtArticulos)

                dv.RowFilter = String.Format("[itmref_0] = '{0}'", e.FormattedValue.ToString)

                If dv.Count = 0 Then
                    MessageBox.Show("Artículo no válido", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    e.Cancel = True

                Else
                    dgv.Rows(e.RowIndex).Cells("colAgente").Value = dv(0).Item("itmdes1_0").ToString

                End If

                dv.Dispose()

            End If

        ElseIf e.ColumnIndex = 4 Then
            Dim flg As Boolean = True

            If IsNumeric(e.FormattedValue.ToString) AndAlso CInt(e.FormattedValue) <= 0 Then flg = False

            If Not flg Then
                MessageBox.Show("Cantidad obligatoria")
                e.Cancel = True
            End If

        End If

    End Sub
    Private Sub dgv_RowValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgv.RowValidating
        If dgv.Rows.Count < 2 Then Exit Sub

        With dgv.Rows(e.RowIndex)
            If .Cells("colitmref").Value Is Nothing OrElse .Cells("colitmref").Value.ToString.Trim = "" Then e.Cancel = True
        End With

    End Sub
    Private Sub dgv_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgv.DataError
        'MessageBox.Show(e.Exception.ToString, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        e.Cancel = True
    End Sub
    Private Sub dgv_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgv.KeyUp
        Dim i As Byte = 0

        If dgv.CurrentCell Is Nothing Then Exit Sub

        If e.KeyCode = Keys.F12 AndAlso dgv.CurrentCell.ColumnIndex = 3 Then
            Dim f As New frmArtRetiros
            f.ShowDialog(Me)

            If f.DialogResult = Windows.Forms.DialogResult.OK Then
                dgv.CurrentCell.Value = f.lstCod.SelectedValue.ToString
            End If

            f.Dispose()
        End If
    End Sub
    Private Sub rbSS1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSS1.CheckedChanged
        lstSS.Enabled = Not rbSS1.Checked
        cboEmpresas.Enabled = rbSS1.Checked
    End Sub
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        Dim dr As DataRow

        If Not Validar() Then Exit Sub

        If rbSS1.Checked Then
            'Creo una nueva solicitud
            Dim cpy As New Sociedad(cn)
            cpy.abrir(cboEmpresas.SelectedValue.ToString)

            'Valido que no se use la empresa MON
            If cpy.Codigo = "MON" Then
                MessageBox.Show("No se puede utilizar la sociedad MON", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            sre.Nueva(bpc, cpy)

        Else
            'Abro la solicitud seleccionada
            sre.Abrir(lstSS.SelectedValue.ToString)

        End If

        'Agrego los prestamos al detalle de la intervencion (EXTINTORES)
        If nudPrestamosExt.Value > 0 Then
            dr = dtYitndet.NewRow
            dr("num_0") = 0
            dr("itmref_0") = ARTICULO_PRESTAMO_EXT
            dr("qty_0") = nudPrestamosExt.Value
            dr("tqty_0") = nudPrestamosExt.Value
            dr("factura_0") = 2
            dr("typlig_0") = 2
            dtYitndet.Rows.Add(dr)
        End If

        'Agrego los prestamos al detalle de la intervencion (MANGUERAS)
        If nudPrestamosMan.Value > 0 Then
            dr = dtYitndet.NewRow
            dr("num_0") = 0
            dr("itmref_0") = ARTICULO_PRESTAMO_MAN
            dr("qty_0") = nudPrestamosMan.Value
            dr("tqty_0") = nudPrestamosMan.Value
            dr("factura_0") = 2
            dr("typlig_0") = 2
            dtYitndet.Rows.Add(dr)
        End If

        'Creo la nueva intervencion
        itn = sre.CrearIntervencion(cboSucursal.SelectedValue.ToString, cboTipo.SelectedValue.ToString)

        With itn
            .Observaciones = txtObserva.Text 'Observaciones
            .AgregarDetalle(dtYitndet) 'Detalle de retiro
            .Estado = 2 'Estado retirado
            .OTR = CInt(mtbOTR.Text) 'Numero de Orden de trabajo
            .Grabar() 'Grabar Intervención
        End With

        MessageBox.Show(itn.Numero)

        Me.DialogResult = Windows.Forms.DialogResult.OK

    End Sub
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    'PROPIEDADES
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
    Public ReadOnly Property Mangueras() As Integer
        Get
            Dim da As OracleDataAdapter
            Dim Sql As String
            Dim dt As New DataTable
            Dim dr As DataRow
            Dim v As Integer

            Sql = "SELECT SUM(qty_0) AS qty_0 "
            Sql &= "FROM yitndet itn INNER JOIN itmmaster itm ON (itn.itmref_0 = itm.itmref_0) "
            Sql &= "WHERE num_0 = :num_0 AND cfglin_0 = '505'"

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
    Public ReadOnly Property PrestamosExtintor() As Integer
        Get
            Return CInt(nudPrestamosExt.Value)
        End Get
    End Property
    Public ReadOnly Property PrestamosManguera() As Integer
        Get
            Return CInt(nudPrestamosMan.Value)
        End Get
    End Property
    Public ReadOnly Property Documento() As Intervencion
        Get
            Return itn
        End Get
    End Property

End Class