Imports System.Data.OracleClient
Imports System.Windows.Forms
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Collections
Imports System.Drawing

Public Class frmCotizador
    Const PORCENTAJE_DESCUENTO_AUTORIZADO As Double = 0.95

    Private WithEvents ctz As New Cotizador(cn)
    Private mail As New CorreoElectronico
    Private errores As String = ""
    Private txterror As Boolean = True
    Private btnpedidoclick As Boolean = False

    'EVENTOS CTZ
    Private Sub ctz_CotizacionAbierta(ByVal sender As Object) Handles ctz.CotizacionAbierta
        Dim o = CType(sender, Cotizador)
        Dim bpa As Sucursal = o.Sucursal
        'Actualizo controles del Form
        txtPedido.Text = o.PedidoAdonix
        txtPresupuesto.Text = o.PresupuestoAdonix
        txtFecha.Text = o.Fecha.ToString("dd/MM/yyyy")
        txtNro.Text = o.Numero.ToString
        txtTotalAI.Text = o.PrecioTotalAI.ToString("N2")
        txtTotalII.Text = o.PrecioTotalII.ToString("N2")
        cboEstado.SelectedValue = o.Estado
        txtBpcnam.Text = o.ClienteCodigo & " - " & o.Cliente.Nombre
        txtNom_fanta.Text = o.Cliente.NombreFantasia

        If bpa.EsDireccionEntrega Then
            txtDesde1.Text = bpa.TurnoMananaDesde ' o.HoraMananaDesde
            txtHasta1.Text = bpa.TurnoMananaHasta 'o.HoraTardeDesde
            txtDesde2.Text = bpa.TurnoTardeDesde 'o.HoraMananaHasta
            txtHasta2.Text = bpa.TurnoTardeHasta 'o.HoraTardeHasta
        Else
            txtDesde1.Text = "0000"
            txtDesde2.Text = "0000"
            txtHasta1.Text = "0000"
            txtHasta2.Text = "0000"
        End If
        txtObs.Text = o.Obs
        txtOC.Text = o.OC
        cboTipo.SelectedValue = o.tipo
        o.Cliente.EnlazarCombo(cboSucursal)
        Horarios()
        cboFcRto.SelectedValue = IIf(o.FcRto, 2, 1)
        chkH.Checked = o.H
        cboSucursal.SelectedValue = ctz.SucursalCodigo
        cboSociedad.SelectedValue = ctz.SociedadCodigo
        cboEntrega.SelectedValue = ctz.ModoEntrega
        cboCondicionPago.SelectedValue = ctz.CondicionPago
        txtNombre_portero.Text = bpa.Portero
        txtMail_FC.Text = bpa.MailFC
        txtPortero_celu.Text = bpa.Telefono_Portero
        If o.Cliente.OC_obligatoria Then
            chkOC.Checked = True
        Else
            chkOC.Checked = False
        End If

        cboExpreso.SelectedValue = ctz.Expreso

        EstadoControles()

    End Sub
    Private Sub ctz_CotizacionGrabada(ByVal sender As Object) Handles ctz.CotizacionGrabada
        Dim o = CType(sender, Cotizador)
        Dim bpa As Sucursal = o.Sucursal
        txtNro.Text = ctz.Numero.ToString
        txtFecha.Text = ctz.Fecha.ToString("dd/MM/yyyy")
        txtPedido.Text = ctz.PedidoAdonix
        txtPresupuesto.Text = ctz.PresupuestoAdonix
        cboEstado.SelectedValue = ctz.Estado

        txtTotalAI.Text = ctz.PrecioTotalAI.ToString("N2")
        txtTotalII.Text = ctz.PrecioTotalII.ToString("N2")
        ctz.CondicionPago = cboCondicionPago.SelectedValue.ToString

        txtNombre_portero.Text = bpa.Portero
        txtMail_FC.Text = bpa.MailFC
        txtPortero_celu.Text = bpa.Telefono_Portero

        EstadoControles()
        cboTipo.Enabled = False

    End Sub
    Private Sub ctz_CotizacionModificada(ByVal sender As Object) Handles ctz.CotizacionModificada
        Dim o = CType(sender, Cotizador)
        Dim bpa As Sucursal = o.Sucursal
        With ctz
            cboSucursal.SelectedValue = .SucursalCodigo
            cboSociedad.SelectedValue = .SociedadCodigo
            cboEntrega.SelectedValue = .ModoEntrega
            .CondicionPago = cboCondicionPago.SelectedValue.ToString
            chkH.Checked = .H
            txtPedido.Text = .PedidoAdonix
            txtTotalAI.Text = .PrecioTotalAI.ToString("N2")
            txtTotalII.Text = .PrecioTotalII.ToString("N2")
        End With

        txtNombre_portero.Text = bpa.Portero
        txtMail_FC.Text = bpa.MailFC
        txtPortero_celu.Text = bpa.Telefono_Portero

        EstadoControles()

    End Sub
    Private Sub ctz_CotizacionNueva(ByVal sender As Object) Handles ctz.CotizacionNueva
        Dim o = CType(sender, Cotizador)

        'Actualizo controles del Form
        txtPedido.Clear()
        txtPresupuesto.Clear()
        txtFecha.Clear()
        txtNro.Clear()
        txtTotalAI.Clear()
        txtTotalII.Clear()
        txtOC.Clear()
        txtObs.Clear()
        cboEstado.SelectedValue = 0
        txtBpcnam.Text = o.ClienteCodigo & " - " & o.Cliente.Nombre
        txtNom_fanta.Text = o.Cliente.NombreFantasia

        o.Cliente.EnlazarCombo(cboSucursal)

        cboFcRto.SelectedValue = o.Cliente.FcRto

        'Asigno valores a la cotizacion
        With ctz
            cboSucursal.SelectedValue = ctz.Cliente.SucursalDefault.Sucursal
            .SociedadCodigo = cboSociedad.SelectedValue.ToString
            .ModoEntrega = cboEntrega.SelectedValue.ToString
            Horarios()
        End With

        EstadoControles()

    End Sub
    Private Sub ctz_Mensaje(ByVal sender As Object, ByVal msg As String) Handles ctz.Mensaje
        If btnpedidoclick = True Then
            If usr.Permiso.AccesoSecundario(43, "V") Then
                If txterror = True Then
                    errores = msg & vbCrLf
                    txterror = False
                Else
                    errores &= msg & vbCrLf
                End If
            Else
                MessageBox.Show(msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Else
            MessageBox.Show(msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    Private Sub ctz_PresupuestoCreado(ByVal sender As Object, ByVal sqh As Clases.Presupuesto) Handles ctz.PresupuestoCreado
        'Envia el presupuesto por mail al vendedor
        Dim rpt As New ReportDocument
        Dim archivo As String = sqh.Numero & ".pdf"
        Dim eml As New CorreoElectronico

        Try
            'Genero el PDF con la cotizacion
            If ctz.Cliente.EsProspecto Then
                rpt.Load(RPTX3 & "DEVTTC.rpt")
            Else
                rpt.Load(RPTX3 & "DEVTTC2.rpt")
            End If
            rpt.SetDatabaseLogon(DB_USR, DB_PWD)
            rpt.SetParameterValue("X3DOS", X3DOS)
            rpt.SetParameterValue("devisdeb", sqh.Numero)
            rpt.SetParameterValue("devisfin", sqh.Numero)
            rpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, archivo)

            eml.Remitente(usr.Mail, usr.Nombre)
            eml.Asunto = "Presupuesto " & sqh.Numero & " Matafuegos Georgia"
            eml.AdjuntarArchivo(archivo)
            eml.Cuerpo = "Buenos días," & vbCrLf
            eml.Cuerpo &= "Adjuntamos presupuesto solicitado por Ud." & vbCrLf
            eml.Cuerpo &= "Ante cualquier consulta estamos a su disponibilidad." & vbCrLf
            eml.Cuerpo &= "Atentamente" & vbCrLf & vbCrLf
            eml.Cuerpo &= ctz.Cliente.Vendedor.Nombre & vbCrLf
            eml.Cuerpo &= ctz.Cliente.Vendedor.Interno & vbCrLf
            eml.AgregarDestinatario(ctz.Cliente.Vendedor.Mail)

            If DB_USR <> "GEOTEST" And usr.Codigo <> "MMIN" Then eml.Enviar()

            eml.Dispose()
            rpt.Dispose()

        Catch ex As Exception
        End Try


        Try
            File.Delete(archivo)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub frmPedidos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Lleno Sociedades
        Sociedad.Sociedades(cn, cboSociedad, True)

        'Lleno ComboBox Modo de Entrega
        Dim mdl As New ModoEntrega(cn)
        mdl.ModosEntrega(cboEntrega)
        'Lleno ComboBox Estado
        Dim mnu As New MenuLocal(cn, 1240, False)
        mnu.AbrirMenu(1240, True)
        mnu.Enlazar(cboEstado)
        'Lleno ComboBox FcRto
        mnu = New MenuLocal(cn, 1, False)
        mnu.Enlazar(cboFcRto)
        'Lleno ComboBox Condiciones de Pago
        CondicionPago.LlenarComboBox(cn, cboCondicionPago)

        'Muestra boton Borrar si usuario es administrador
        btnborrar.Enabled = usr.Permiso.AccesoSecundario(43, "V")

        'Enlace de la grilla
        colNro.DataPropertyName = "nro_0"
        colLinea.DataPropertyName = "numlig_0"
        'colCodigo.DataPropertyName = "itmref_0"
        With colCodigo
            .DisplayMember = "completo"
            .ValueMember = "itmref_0"
            .DataPropertyName = "itmref_0"
            .DataSource = Articulo.TablaConPrecio(cn)
        End With
        With colDescripcion
            .DisplayMember = "itmdes1_0"
            .ValueMember = "itmref_0"
            .DataPropertyName = "itmref_0"
            .DataSource = Articulo.TablaConPrecio(cn)
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

        '---------------------------------------
        'SECTOR DE CONSULTA
        '---------------------------------------
        mnu = New MenuLocal(cn, 1, False)
        mnu.Enlazar(cboBuscarEstado)
        cboBuscarEstado.SelectedValue = 2

        'ComboBox Tipo
        mnu = New MenuLocal(cn, 1, True)
        mnu.ModificarTexto(1, "Pedido")
        mnu.ModificarTexto(2, "Presupuesto")
        mnu.Enlazar(cboTipo)
        cboTipo.SelectedValue = 0

        Vendedor.Enlazar(cn, cboBuscarVend, True)

        Dim exp As New Expreso(cn)
        exp.Enlazar(cboExpreso, True)

        FiltroVendedor()

        Buscar()

    End Sub
    Private Sub FiltroVendedor()
        'Si el usuario es vendedor, elimino del combo los demás vendedores

        If usr.Codigo.Length = 2 Then
            Dim dt As DataTable = CType(cboBuscarVend.DataSource, DataTable)

            For i As Integer = dt.Rows.Count - 1 To 0 Step -1
                Dim dr As DataRow
                dr = dt.Rows(i)

                If dr("repnum_0").ToString <> usr.Codigo Then
                    If usr.Codigo = "24" And dr("repnum_0").ToString = "19" Or usr.Codigo = "19" And dr("repnum_0").ToString = "24" Then Continue For
                    dr.Delete()
                End If
            Next

            dt.AcceptChanges()

        End If

    End Sub
    Private Sub EstadoControles()
        'Activa/Desactiva los controles dependiendo del estado de la aplicacion
        dgv.ReadOnly = (txtPedido.Text.Trim <> "" And txtPresupuesto.Text <> "") Or (txtPedido.Text.Trim = "" And txtPresupuesto.Text <> "")

        dgv.AllowUserToAddRows = (txtPedido.Text.Trim = "" And txtPresupuesto.Text.Trim = "")
        cboSociedad.Enabled = (txtPedido.Text.Trim = "" And txtPresupuesto.Text.Trim = "")
        cboSucursal.Enabled = (txtPresupuesto.Text.Trim = "" And txtPedido.Text.Trim = "")
        cboEntrega.Enabled = (txtPresupuesto.Text.Trim = "" And txtPedido.Text.Trim = "")
        cboFcRto.Enabled = (txtPedido.Text.Trim = "" And txtPresupuesto.Text.Trim = "")
        txtObs.ReadOnly = (txtPedido.Text.Trim <> "")
        chkH.Enabled = (txtPedido.Text.Trim = "" And txtPresupuesto.Text.Trim = "")
        cboCondicionPago.Enabled = ((txtPedido.Text.Trim = "" And txtPresupuesto.Text.Trim = ""))
        txtDesde1.ReadOnly = (txtPedido.Text.Trim <> "")
        txtDesde2.ReadOnly = (txtPedido.Text.Trim <> "")
        txtHasta1.ReadOnly = (txtPedido.Text.Trim <> "")
        txtHasta2.ReadOnly = (txtPedido.Text.Trim <> "")
        txtOC.ReadOnly = (txtPedido.Text.Trim <> "" Or txtOC.Text.Trim <> "")
        btn_examinar.Enabled = (txtPedido.Text = "" And txtPresupuesto.Text <> "") Or (txtOC.Text.Trim <> "")
        ' btn_examinar.Enabled = (txtOC.Text.Trim <> "")
        pb.Visible = (ctz.OCF.Trim <> "")
        btver.Enabled = (txtOC.Text.Trim <> "")
        btborrar.Enabled = (txtOC.Text.Trim <> "")
        btnDuplicar.Enabled = (txtPedido.Text <> "" Or txtPresupuesto.Text <> "") And txtNro.Text <> ""
        If ctz.OCF <> " " Then
            pb.Visible = True
        End If
    End Sub
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

                    'Consulto que el codigo exista en la lista de precios
                    Dim subString As String = Microsoft.VisualBasic.Left(e.FormattedValue.ToString, 6)
                    If Not ctz.ExisteArticulo(subString) Then
                        MessageBox.Show("Artículo no encontrado: " & e.FormattedValue.ToString)
                        e.Cancel = True
                    End If
                    'If Not ctz.ExisteArticulo(e.FormattedValue.ToString) Then
                    '    MessageBox.Show("Artículo no encontrado: " & e.FormattedValue.ToString)
                    '    e.Cancel = True
                    'End If

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
            p2 = p2 * PORCENTAJE_DESCUENTO_AUTORIZADO

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
        txtTotalII.Text = ctz.PrecioTotalII.ToString("N2")
    End Sub
    Private Sub dgv2_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv2.CellDoubleClick
        pb.Visible = False
        Dim txt As String
        Dim flg As Boolean = True
        If e.RowIndex > -1 Then
            If ctz.PedidoModificado Then
                txt = "El pedido actual no fue guardado" & vbCrLf & vbCrLf
                txt &= "¿Graba los cambios antes de continuar?"
                Select Case MessageBox.Show(txt, Me.Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3)
                    Case Windows.Forms.DialogResult.Yes
                        ctz.grabar()
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

                ctz.Abrir(CLng(dr(0)))

            End If
        End If
        'MsgBox(txtPedido.Text)
        If txtPedido.Text.Trim <> "" Then
            dgv.Enabled = False
        End If
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
    Private Sub Nuevo(ByVal tipo As Integer)
        txtboxNumAnterior.Clear()
        Dim txt As String = ""
        Dim bpc As New Cliente(cn)
        Dim flg As Boolean = False
        dgv.Enabled = True

        Dim f As New frmAutoCompleta
        f.ShowDialog(Me)
        txt = f.texto

        If txt <> "" Then
            'Intento abrir el cliente
            If bpc.Abrir(txt) AndAlso (Not (bpc.EsProspecto And tipo = 1)) Then
                'Controlo que el cliente sea del vendedor
                If bpc.Vendedor.Codigo = usr.Codigo Then
                    flg = True
                ElseIf bpc.Vendedor.Analista.Codigo = usr.Codigo Then
                    flg = True
                ElseIf bpc.AccesoUsuario(usr.Codigo) Then
                    flg = True
                Else
                    flg = False
                End If

                If flg Then
                    If bpc.Activo = True And bpc.Bloqueado = False Then
                        If bpc.Observaciones.Trim = "" Then
                        Else
                            MessageBox.Show(bpc.Observaciones, "Observaciones", MessageBoxButtons.OK)
                        End If
                        cboSociedad.SelectedValue = " "
                        ctz.Nuevo(bpc, cboSociedad.SelectedValue.ToString, tipo)
                        cboTipo.SelectedValue = tipo
                        If bpc.OC_obligatoria Then
                            chkOC.Checked = True
                        Else
                            chkOC.Checked = False
                        End If
                        If ctz.Cliente.EsProspecto Then
                            cboCondicionPago.SelectedValue = "001"
                        Else
                            cboCondicionPago.SelectedValue = bpc.CondicionPago.Codigo
                        End If
                        If tipo = 1 Then buscar_presu(bpc.Codigo)

                        ctz.Expreso = cboExpreso.SelectedValue.ToString

                    Else
                        MessageBox.Show("Cliente Bloqueado o no Activo", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)

                    End If
                Else
                    MessageBox.Show("Usuario sin autorización para acceder a este cliente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If

                '2015-01-15 TABLA XA8 - 
                'Desarrollo de Agenda de Precios Clientes
                If bpc.MostrarObsAgendaPrecio Then
                    MessageBox.Show(bpc.ObsAgendaPrecio, "Agenda Precios Clientes", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            Else
                If bpc.Abrir(txt) AndAlso bpc.EsProspecto And tipo = 1 Then
                    MessageBox.Show("Cliente prospecto, solicitar pasar a cliente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    MessageBox.Show("Cliente no encontrado", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If

            End If
        End If

    End Sub
    Private Sub btnNuevoPedido_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevoPedido.Click
        Nuevo(1)
    End Sub
    Private Sub btnNuevoPresupuesto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevoPresupuesto.Click
        Nuevo(2)
    End Sub
    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If Grabar() Then
            MessageBox.Show("La cotización fue grabada", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    Private Function Grabar() As Boolean
        Dim txt As String = ""

        If txtBpcnam.Text.Trim = "" Then Exit Function

        'Tipo Presupuesto/Pedido no está definido
        If CInt(cboTipo.SelectedValue) = 0 Then
            If usr.Permiso.AccesoSecundario(43, "V") Then
                If txterror = True Then
                    errores = "Presupuesto/Pedido no definido" & vbCrLf
                    txterror = False

                Else
                    errores &= "Presupuesto/Pedido no definido" & vbCrLf

                End If
            Else
                MessageBox.Show("Presupuesto/Pedido no definido", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                If cboTipo.Enabled Then cboTipo.Focus()
                Return False
            End If

        End If

        If cboSociedad.SelectedValue.ToString.Trim = "" Then
            If usr.Permiso.AccesoSecundario(43, "V") Then
                If txterror = True Then
                    errores = "Debe seleccionar la sociedad" & vbCrLf
                    txterror = False

                Else
                    errores &= "Debe seleccionar la sociedad" & vbCrLf

                End If
            Else
                MessageBox.Show("Debe seleccionar la sociedad", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand)
                Return False
            End If

        End If

        '---------------------------------------------------------------------------------------
        '2017.02.23 | Se obliga usar LIA para clientes nuevos
        '---------------------------------------------------------------------------------------
        If LiaObligatorio() Then Return False
        '---------------------------------------------------------------------------------------

        If txtOC.Text.Trim <> "" And ctz.OCF = " " Then
            If usr.Permiso.AccesoSecundario(43, "V") Then
                If txterror = True Then
                    errores = "Debe agregar el archivo adjunto de OC" & vbCrLf
                    txterror = False

                Else
                    errores &= "Debe agregar el archivo adjunto de OC" & vbCrLf

                End If
            Else
                MessageBox.Show("Debe agregar el archivo adjunto de OC", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand)
                Return False
            End If

        End If
        If ctz.PedidoAdonix.Trim <> "" Then Return False

        Dim bpa As New Sucursal(cn, ctz.ClienteCodigo, cboSucursal.SelectedValue.ToString)
        If (txtDesde1.Text = "0000" And txtHasta1.Text = "0000" And txtDesde2.Text = "0000" And txtHasta2.Text = "0000") Then
            MessageBox.Show("Es obligatorio cargar los horarios")

        ElseIf (txtDesde1.Text >= txtHasta1.Text And txtDesde2.Text = "0000" And txtHasta2.Text = "0000") Or (txtDesde2.Text >= txtHasta2.Text And txtDesde1.Text = "0000" And txtHasta1.Text = "0000") Then
            MessageBox.Show("El horario inicial no puede ser mayor al horario final")

        End If
        If bpa.EsDireccionEntrega Then

            If ValidacionHorarios() Then
                With ctz
                    .HoraMananaDesde = txtDesde1.Text
                    .HoraMananaHasta = txtHasta1.Text
                    .HoraTardeDesde = txtDesde2.Text
                    .HoraTardeHasta = txtHasta2.Text
                End With
                With bpa
                    .TurnoMananaDesde = txtDesde1.Text
                    .TurnoMananaHasta = txtHasta1.Text
                    .TurnoTardeDesde = txtDesde2.Text
                    .TurnoTardeHasta = txtHasta2.Text
                End With

            Else
                If usr.Permiso.AccesoSecundario(43, "V") Then
                    If txterror = True Then
                        errores = "La hora no es válida" & vbCrLf
                        txterror = False

                    Else
                        errores &= "La hora no es válida" & vbCrLf

                    End If
                Else
                    MessageBox.Show("La hora no es válida", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Return False
                End If

            End If
        End If

        'VALIDACION 1 - CLIENTE DISTRIBUIDOR Y ARTICULOS 10 Y 11
        Dim itm As New Articulo(cn)
        For Each dr As DataRow In ctz.Lineas.Rows
            'Abro el articulo
            If dr.RowState = DataRowState.Deleted Then Continue For
            If Not itm.Abrir(dr("itmref_0").ToString) Then Continue For

            If itm.Familia(1) = "101" Or itm.Familia(1) = "102" Or itm.Familia(1) = "104" Then
                If Not itm.Codigo.StartsWith("10") Then

                    MessageBox.Show("Extintores de 1KG se deben cargar con código 10", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False


                End If
            Else
                If ctz.Cliente.Familia2 = "20" AndAlso itm.Codigo.StartsWith("11") Then
                    'Como el cliente es DISTRIBUIDOR - Articulos NO pueden ser 11XXXX

                    MessageBox.Show("CLIENTE DISTRIBUIDOR: No se pueden cargar artículos 11", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False


                ElseIf ctz.Cliente.Familia2 <> "20" AndAlso itm.Codigo.StartsWith("10") Then
                    'Cliente NO DISTRIBUIDOR - Articulos NO pueden ser 10XXXX
                    If ctz.Cliente.Familia2 <> "30" Then 'No aplica para supermercados

                        MessageBox.Show("CLIENTE NO DISTRIBUIDOR: No se pueden cargar artículos 10", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return False

                    End If
                End If
            End If

        Next
        itm.Dispose()
        itm = Nothing

        'VALIDACION 2 - CANTIDAD DE TARJETAS / EXTINTORES
        If Not ctz.RelacionTarjetasExtintores Then
            If usr.Permiso.AccesoSecundario(43, "V") Then
                If txterror = True Then
                    errores = "ATENCIÓN: La cantidad de tarjetas y extintores no son iguales" & vbCrLf
                    txterror = False

                Else
                    errores &= "ATENCIÓN: La cantidad de tarjetas y extintores no son iguales" & vbCrLf

                End If
            Else
                txt = "ATENCIÓN: La cantidad de tarjetas y extintores no son iguales"
                MessageBox.Show(txt, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

        End If
        'VALIDACION 3 - EXTINTORES 1KG 3" 
        If Not ctz.Extintores3pulgadas Then

            txt = "La caja de extintores de 3"" es de 10 unidades"
            MessageBox.Show(txt, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        End If
        'VALIDACION 3 - EXTINTORES 1KG 4" 
        If Not ctz.Extintores4pulgadas Then

            txt = "La caja de extintores de 4"" es de 12 unidades"
            MessageBox.Show(txt, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        End If

        If cboSociedad.SelectedValue.ToString = "MON" And chkH.Checked = False Then
            If usr.Permiso.AccesoSecundario(43, "V") Then
                If txterror = True Then
                    errores = "La sociedad MON solo se puede usar en H" & vbCrLf
                    txterror = False

                Else
                    errores &= "La sociedad MON solo se puede usar en H" & vbCrLf

                End If
            Else
                MessageBox.Show("La sociedad MON solo se puede usar en H", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return False
            End If

        End If
        If cboSociedad.SelectedValue.ToString = "LIA" AndAlso (ctz.Cliente.RegimenImpuesto = "RI" OrElse ctz.Cliente.RegimenImpuesto = "RIE") Then
            If usr.Permiso.AccesoSecundario(43, "V") Then
                If txterror = True Then
                    errores = "La sociedad LIA no puede usarse con clientes RI" & vbCrLf
                    txterror = False

                Else
                    errores &= "La sociedad LIA no puede usarse con clientes RI" & vbCrLf

                End If
            Else
                MessageBox.Show("La sociedad LIA no puede usarse con clientes RI", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return False
            End If

        End If
        If cboSociedad.SelectedValue.ToString = "GRU" Then
            MessageBox.Show("Esta sociedad no puede utilizarse", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False
        End If
        'Vuelco datos a la cabecera de la cotizacion
        ctz.SucursalCodigo = cboSucursal.SelectedValue.ToString
        ctz.ModoEntrega = cboEntrega.SelectedValue.ToString
        ctz.FcRto = CBool(IIf(CInt(cboFcRto.SelectedValue) = 2, True, False))
        ctz.CondicionPago = cboCondicionPago.SelectedValue.ToString
        ctz.OC = txtOC.Text
        ctz.Obs = txtObs.Text
        ctz.tipo = CInt(cboTipo.SelectedValue)
        ctz.Expreso = cboExpreso.SelectedValue.ToString

        Dim bpc As Cliente
        bpa.Portero = txtNombre_portero.Text
        bpa.Telefono_Portero = txtPortero_celu.Text
        bpa.MailFC = txtMail_FC.Text
        bpa.Grabar()

        bpc = ctz.Cliente
        bpc.NombreFantasia = txtNom_fanta.Text
        bpc.Grabar()

        If Not ctz.Grabar() Then

            MessageBox.Show("Error al grabar. Vuelva a intentar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False

        End If

        If txtboxNumAnterior.Text <> "" Then
            Dim ctz2 As New Cotizador(cn)
            ctz2.Abrir(CLng(txtboxNumAnterior.Text))
            ctz2.marcar_duplicado = 2
            ctz2.Grabar()
        End If

        Return True

    End Function
    Private Sub btnDuplicar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDuplicar.Click
        If txtNro.Text = "" Then Exit Sub

        If MessageBox.Show("¿Confirma duplicar esta cotización?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            txtboxNumAnterior.Text = txtNro.Text
            ctz.Duplicar()
            ctz.copiar_duplicado = CInt(txtboxNumAnterior.Text)
            'ctz.GrabarCotizacion()
            dgv.Enabled = True
            cboTipo.Enabled = True
        End If
    End Sub
    Private Sub btnPedido_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPedido.Click
        btnpedidoclick = False

        If Not Grabar() Then Exit Sub

        '************************************************************
        ' VALIDACION DE TRANSPORTE OBLIGATORIO
        ' No se permite crear pedido si el cliente es del interior y
        ' no hay expreso seleccionado
        '************************************************************
        Dim bpa As Sucursal = ctz.Sucursal
        If bpa.Provincia <> "CFE" AndAlso bpa.Provincia <> "BUE" AndAlso cboExpreso.SelectedValue.ToString = " " AndAlso cboEntrega.SelectedValue.ToString = "1" Then
            MessageBox.Show("Debe seleccionar un expreso", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        If usr.Permiso.AccesoSecundario(43, "V") Then
            btnpedidoclick = True
            UsuariosV()
        Else
            Dim txt As String = ""
            Dim sqh As New Presupuesto(cn)
            Dim flg As Boolean = True
            If txtPortero_celu.Text.Length = 10 Then
                For i = 0 To txtPortero_celu.Text.Length - 1
                    If Not IsNumeric(txtPortero_celu.Text.Substring(i, 1)) Then
                        If usr.Permiso.AccesoSecundario(43, "V") Then
                            If MessageBox.Show("El campo de telefono de contacto contiene caracteres no numericos, quiere seguir con la creacion del pedido?", "Telefono contacto", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.No Then
                                Exit Sub
                            End If
                        Else
                            MsgBox("EL campo de telefono de contacto contiene caracteres no numericos")
                            txtPortero_celu.Focus()
                            Exit Sub
                        End If
                    End If
                Next
            Else
                txtPortero_celu.Focus()
                If usr.Permiso.AccesoSecundario(43, "V") Then
                    If MessageBox.Show("El telefono de contacto debe tener 10 numeros,usted ingreso: " & txtPortero_celu.Text.Length & " ingrese los " & (10 - txtPortero_celu.Text.Length) & " restantes, incluido el codigo de area sin el 0, quiere seguir con la creacion del pedido?", "Telefono contacto, ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.No Then
                        Exit Sub
                    End If
                Else
                    MsgBox("El telefono de contacto debe tener 10 numeros,usted ingreso: " & txtPortero_celu.Text.Length & " ingrese los " & (10 - txtPortero_celu.Text.Length) & " restantes, incluido el codigo de area sin el 0")
                    txtPortero_celu.Focus()
                    Exit Sub
                End If
            End If
            Grabar()
            If cboCondicionPago.BackColor = Drawing.Color.LightPink Then
                MessageBox.Show("Se cambio la condicion de pago", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If
            '****************************************************************************************************
            '17.11.2016
            'Bloqueo clientes RI sin IIBB cargado. Solo para sociedad DNY
            '****************************************************************************************************
            If cboSociedad.SelectedValue.ToString = "DNY" Then

                With ctz.Cliente
                    If .RegimenImpuesto = "RI" AndAlso .IIBB = "" And .CondicionIb <> "4" Then
                        MessageBox.Show("IIBB obligatorio para poder crear pedido", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    End If
                End With
            End If
            If Not ctz.TieneArticulosNuevos Then
                MessageBox.Show("Esta cotizacion no tiene articulos nuevos", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If
            If ctz.PedidoAdonix = "" Then
                If (txtDesde1.Text = "0000" And txtHasta1.Text = "0000" And txtDesde2.Text = "0000" And txtHasta2.Text = "0000") Then
                    MessageBox.Show("Es obligatorio cargar los horarios")
                    Exit Sub
                ElseIf (txtDesde1.Text >= txtHasta1.Text And txtDesde2.Text = "0000" And txtHasta2.Text = "0000") Or (txtDesde2.Text >= txtHasta2.Text And txtDesde1.Text = "0000" And txtHasta1.Text = "0000") Then
                    MessageBox.Show("El horario inicial no puede ser mayor al horario final")
                    Exit Sub
                ElseIf (txtHasta1.Text > txtDesde2.Text And txtDesde2.Text <> "0000") Then
                    MessageBox.Show("El horario del turno mañana  no puede ser mayor al horario del turno tarde")
                    Exit Sub
                End If
                If cboCondicionPago.BackColor = Drawing.Color.LightPink Then
                    MessageBox.Show("no puede cambiar la condicion de pago", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
                If ctz.Cliente.EsProspecto Then
                    txt = "No se puede crear un pedido a un prospecto"
                    MessageBox.Show(txt, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

                If (CInt(cboTipo.SelectedValue) <> 1 AndAlso ctz.PresupuestoAdonix.Trim = "") Or txtPresupuesto.Text.Trim <> "" Then
                    txt = "Esta cotizacion no debe usarse para crear un pedido" & vbCrLf
                    txt &= "¿Continua igualmente?"
                    If MessageBox.Show(txt, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                        Exit Sub
                    End If
                End If
                If ctz.SociedadCodigo = "LIA" And (ctz.Cliente.RegimenImpuesto = "RI" OrElse ctz.Cliente.RegimenImpuesto = "RIE") Then
                    txt = "Esta sociedad no se puede usar con clientes RI"
                    MessageBox.Show(txt, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                If ctz.Estado = 2 OrElse usr.Permiso.AccesoSecundario(43, "V") OrElse txtPresupuesto.Text.Trim <> "" Then
                    If FaltanArticulosRelacionados() Then Exit Sub

                    'Si la cotizacion tiene un presupuesto
                    If ctz.PresupuestoAdonix.Trim <> "" Then

                        'Abro el presupuesto
                        If sqh.Abrir(ctz.PresupuestoAdonix) Then

                            'El presupuesto no debe estar vencido
                            If sqh.Vencimiento.AddDays(15) > Date.Today Then
                                flg = True
                            Else

                                'Solo usuario con privilegio puede autorizar presupuesto vencido
                                If usr.Permiso.AccesoSecundario(43, "V") Then
                                    flg = True
                                Else

                                    'Verificar si los precios de la lista de precios
                                    If ctz.Cambio_Precio Then
                                        MessageBox.Show("No se puede crear el pedido porque presupuesto está vencido", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        flg = False
                                    Else
                                        flg = True
                                    End If
                                End If
                            End If
                        End If
                    End If
                    If ctz.Sucursal.SucursalEntregaActiva = False Then
                        flg = False
                        MessageBox.Show("La sucursal no es para entregas o está desactivada")
                    End If

                    'Salgo si False
                    If Not flg Then Exit Sub
                    txt = "Se creará un pedido Adonix" & vbCrLf & vbCrLf
                    txt &= "¿Confirma?"

                    'Salto si el usuario no confirma
                    If MessageBox.Show(txt, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                        Exit Sub
                    End If

                    'Aqui convertir a pedido Adonix
                    Me.UseWaitCursor = True
                    Application.DoEvents()
                    Application.DoEvents()
                    ctz.ConvertirEnPedido()
                    txtPedido.Text = ctz.PedidoAdonix
                    Me.UseWaitCursor = False
                    Application.DoEvents()
                    txt = "Pedido creado: " & ctz.PedidoAdonix
                    If (ctz.OC = " " Or txtOC.Text = " ") And ctz.Cliente.OC_obligatoria Then
                        With mail
                            .Nuevo()
                            .Remitente("noreply@matafuegosgeorgia.com", "Matafuegos Georgia")
                            .AgregarDestinatario("jrodriguez@matafuegosgeorgia.com", False)
                            .Asunto = "Pedido creado sin OC"
                            .Cuerpo = "El cliente: " & ctz.Cliente.Codigo & "-" & ctz.Cliente.Nombre & ", con el pedido: " & ctz.PedidoAdonix & " fue creado sin OC "
                            .Enviar()
                        End With
                    End If
                Else
                    txt = "La cotización debe estar en estado Autorizado " & vbCrLf
                    txt &= "para poder convertirla en pedido"
                End If
            Else
                txt = "Ya existe un pedido creado para ésta cotización"
            End If

            MessageBox.Show(txt, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    Private Sub btnPresu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPresu.Click

        Dim txt As String = ""
        If txtPedido.Text <> "" Then Exit Sub
        If Not Grabar() Then Exit Sub

        If ctz.PresupuestoAdonix = "" Then
            If CInt(cboTipo.SelectedValue) <> 2 Then
                txt = "Esta cotizacion no debe usarse para crear un presupuesto" & vbCrLf
                txt &= "¿Continua igualmente?"
                If MessageBox.Show(txt, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                    Exit Sub
                End If
            End If
            If ctz.SociedadCodigo = "LIA" And (ctz.Cliente.RegimenImpuesto = "RI" OrElse ctz.Cliente.RegimenImpuesto = "RIE") Then
                txt = "La sociedad LIA no se puede usar con clientes RI"
                MessageBox.Show(txt, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If ctz.Estado = 2 OrElse usr.Permiso.AccesoSecundario(43, "V") Then
                If FaltanArticulosRelacionados() Then Exit Sub
                txt = "Se creará un presupuesto en Adonix" & vbCrLf & vbCrLf
                txt &= "¿Confirma?"
                'Salto si el usuario no confirma
                If MessageBox.Show(txt, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                    Exit Sub
                End If
                Me.UseWaitCursor = True
                Application.DoEvents()
                Application.DoEvents()

                ctz.ConvertirEnPresupuesto()

                txtPresupuesto.Text = ctz.PresupuestoAdonix
                EstadoControles()

                Me.UseWaitCursor = False

                Application.DoEvents()

                txt = "Presupuesto creado: " & ctz.PresupuestoAdonix

            Else
                txt = "La cotización debe estar en estado Autorizado "

            End If

        Else
            txt = "Ya existe un presupuesto creado para ésta cotización"

        End If

        MessageBox.Show(txt, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub
    Private Sub btnborrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnborrar.Click
        If txtPresupuesto.Text = "" And txtPedido.Text = "" Then
            If txtNro.Text = "" Then
                MessageBox.Show("No eligio ninguna cotizacion para borrar")
            Else
                Dim result As Integer = MessageBox.Show("Confirma el borrado", "Borrar Cotizacion", MessageBoxButtons.YesNo)
                If result = DialogResult.Yes Then
                    File.Delete("\\srv1\Compartido\OC\" & ctz.ClienteCodigo & "-" & txtOC.Text.Trim & ".pdf")
                    ctz.OCF = ""
                    ctz.OC = ""
                    txtOC.Text = ""
                    btborrar.Enabled = False
                    btver.Enabled = False
                    btn_examinar.Enabled = False
                    pb.Visible = False

                    ctz.Borrar()
                    Limpiar()
                ElseIf result = DialogResult.No Then
                    Exit Sub
                End If

            End If
        Else
            MessageBox.Show("No se puede borrar un pedido o un presupuesto")
        End If
    End Sub
    Private Sub btnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizar.Click
        Dim bpa As New Sucursal(cn, ctz.ClienteCodigo, cboSucursal.SelectedValue.ToString)
        Dim bpc As Cliente
        bpa.Portero = txtNombre_portero.Text
        bpa.Telefono_Portero = txtPortero_celu.Text
        bpa.MailFC = txtMail_FC.Text
        bpa.Grabar()
        bpc = ctz.Cliente
        bpc.NombreFantasia = txtNom_fanta.Text
        bpc.Grabar()
    End Sub
    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Buscar()
    End Sub
    Private Sub Horarios()

        Dim bpa As New Sucursal(cn, ctz.ClienteCodigo, cboSucursal.SelectedValue.ToString)

        If bpa.EsDireccionEntrega Then
            txtDesde1.Text = bpa.TurnoMananaDesde
            txtDesde2.Text = bpa.TurnoTardeDesde
            txtHasta1.Text = bpa.TurnoMananaHasta
            txtHasta2.Text = bpa.TurnoTardeHasta
            txtNombre_portero.Text = bpa.Portero
            txtPortero_celu.Text = bpa.Telefono_Portero
            txtMail_FC.Text = bpa.MailFC

            '2017.03.03 Expreso
            cboExpreso.SelectedValue = bpa.Expreso

        Else
            cboExpreso.SelectedValue = " "

        End If

    End Sub
    Private Sub cboSociedad_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSociedad.SelectedIndexChanged
        Dim cbo As ComboBox = CType(sender, ComboBox)

        If cbo.SelectedValue.ToString.Length > 3 Then Exit Sub
        ctz.SociedadCodigo = cbo.SelectedValue.ToString

        If cbo.SelectedValue.ToString <> "MON" Then
            chkH.Checked = False
        ElseIf cbo.SelectedValue.ToString = "MON" Then
            chkH.Checked = True
        End If

    End Sub
    Private Sub chkH_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkH.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)
        ctz.H = chk.Checked

        If chk.Checked AndAlso cboSociedad.SelectedValue.ToString <> "MON" Then
            cboSociedad.SelectedValue = "MON"
        End If
    End Sub
    Private Sub cboSucursal_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSucursal.SelectedIndexChanged
        Dim cbo As ComboBox = CType(sender, ComboBox)
        If cbo.SelectedValue Is Nothing Then Exit Sub
        If cbo.SelectedValue.ToString.Length > 3 Then Exit Sub

        Horarios()

    End Sub
    Private Sub cboEntrega_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboEntrega.SelectedIndexChanged
        Dim cbo As ComboBox = CType(sender, ComboBox)
        If cboEntrega.SelectedValue Is Nothing Then Exit Sub
        If cbo.SelectedValue.ToString.Length > 1 Then Exit Sub
        ctz.ModoEntrega = cbo.SelectedValue.ToString
    End Sub
    Private Sub cboFcRto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFcRto.SelectedIndexChanged
        Dim cbo As ComboBox = CType(sender, ComboBox)
        If cbo.SelectedValue Is Nothing Then Exit Sub
        If cbo.SelectedValue.ToString.Length > 1 Then Exit Sub
        ctz.FacRto(CInt(cbo.SelectedValue))
    End Sub
    Private Sub cboCondicionPago_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCondicionPago.SelectedIndexChanged

        If ctz.Cliente.TieneDatos = False Then Exit Sub
        If ctz.Cliente.EsProspecto Then Exit Sub
        If cboCondicionPago.SelectedValue Is Nothing Then Exit Sub

        If ctz.CondicionPago = " " Then
            ctz.CondicionPago = ctz.Cliente.CondicionPago.Codigo
        End If

        Dim cp As New CondicionPago(cn)
        cp.EstablecerCodigo(cboCondicionPago.SelectedValue.ToString)

        If ctz.Cliente.CondicionPago.prioridad < cp.prioridad Then
            ctz.CondicionPago = cboCondicionPago.SelectedValue.ToString
            cboCondicionPago.BackColor = Drawing.Color.LightPink
        Else
            cboCondicionPago.BackColor = Drawing.Color.LightGreen
        End If

    End Sub
    Private Sub Buscar()

        Dim da As OracleDataAdapter
        Dim dt As New DataTable
        Dim Sql As String
        Dim Where As Boolean = False 'Indica si puse clausula where


        Sql = "SELECT nro_0, dat_0, bpc.bpcnum_0, bpc.bpcnam_0, rep_0, bpaadd_0 "
        Sql &= "FROM xcotiza xco INNER JOIN bpcustomer bpc ON (xco.bpcnum_0 = bpc.bpcnum_0) "

        'Filtro codigo de cliente
        If txtBuscar.Text.Trim <> "" Then
            If Not Where Then
                Sql &= "WHERE"
                Where = True
            Else
                Sql &= " AND "
            End If
            Sql &= " xco.bpcnum_0 = '" & txtBuscar.Text.Trim & "'"
        End If
        'Filtro por vendedor
        If cboBuscarVend.SelectedValue.ToString <> " " Then
            If Not Where Then
                Sql &= "WHERE"
                Where = True
            Else
                Sql &= " AND "
            End If
            Sql &= " rep_0 = '" & cboBuscarVend.SelectedValue.ToString & "'"
        End If
        'Filtro por estado
        If cboBuscarEstado.SelectedValue.ToString <> " " Then
            If Not Where Then
                Sql &= "WHERE"
                Where = True
            Else
                Sql &= " AND "
            End If
            If chkpresu.Checked = True Or chkrecargas.Checked = True Then
                Sql &= " (soh_0 = ' ' And sqh_0 <> ' ') and typ_0 = 2 and dat_0 > trunc(sysdate-30) and xduplica_0 <> 2"
                'ElseIf chkrecargas.Checked = True Then
                '    Sql &= " (soh_0 = ' ' OR sqh_0 <> ' ') and typ_0 = 2 and dat_0 > trunc(sysdate-60) "
            Else
                If cboBuscarEstado.SelectedValue.ToString = "1" Then
                    'Cotizacion NO pendientes
                    Sql &= " (soh_0 <> ' ' OR sqh_0 <> ' ') "
                Else
                    'Cotizacion pendientes
                    Sql &= " (soh_0 = ' ' AND sqh_0 = ' ') "

                    ' Si el usuario es ADMIN, muestro solo las cotizaciones para autorizar
                    If usr.Permiso.AccesoSecundario(43, "V") Then
                        If Not Where Then
                            Sql &= "WHERE"
                            Where = True
                        Else
                            Sql &= " AND "
                        End If

                        Sql &= "estado_0 = 1 "
                    End If

                End If
            End If

        End If

        Sql &= " ORDER BY nro_0 DESC"


        da = New OracleDataAdapter(Sql, cn)
        da.Fill(dt)
        da.Dispose()

        If chkpresu.Checked = True And chkrecargas.Checked = False Then
            'MsgBox(dt.Rows.Count)
            For Each dr As DataRow In dt.Rows()
                'ctz.Abrir(CLng(dr("nro_0")))
                If Not ctz.TieneArticulosNuevo(CInt(dr("nro_0"))) Then dr.Delete()
                'If dr.RowState = DataRowState.Deleted Then Continue For

            Next
        End If
        If chkrecargas.Checked = True And chkpresu.Checked = False Then
            For Each dr As DataRow In dt.Rows()
                'ctz.Abrir(CLng(dr("nro_0")))
                If Not ctz.TieneArticulosViejo(CInt(dr("nro_0"))) Then
                    dr.Delete()
                Else
                    If ctz.tieneintervencion(CStr(dr("bpcnum_0")), CStr(dr("bpaadd_0")), CDate(dr("dat_0"))) Then dr.Delete()
                End If
                'If dr.RowState = DataRowState.Deleted Then Continue For

            Next
        End If
        If chkrecargas.Checked = True And chkpresu.Checked = True Then
            For Each dr As DataRow In dt.Rows()
                If ctz.tieneintervencion(CStr(dr("bpcnum_0")), CStr(dr("bpaadd_0")), CDate(dr("dat_0"))) Then dr.Delete()
                'If dr.RowState = DataRowState.Deleted Then Continue For

            Next
        End If



        col2Nro.DataPropertyName = "nro_0"
        col2Fecha.DataPropertyName = "dat_0"
        col2Cliente.DataPropertyName = "bpcnum_0"
        col2Nombre.DataPropertyName = "bpcnam_0"
        col2Vend.DataPropertyName = "rep_0"
        suc.DataPropertyName = "bpaadd_0"
        dgv2.DataSource = dt
        chkpresu.Checked = False
        chkrecargas.Checked = False

    End Sub
    Private Sub buscar_presu(ByVal nro As String)
        Dim da As OracleDataAdapter
        Dim dt As New DataTable
        Dim Sql As String

        Sql = "SELECT nro_0, dat_0, bpc.bpcnum_0, bpc.bpcnam_0, rep_0, bpaadd_0 "
        Sql &= "FROM xcotiza xco INNER JOIN bpcustomer bpc ON (xco.bpcnum_0 = bpc.bpcnum_0) "
        Sql &= "WHERE xco.bpcnum_0 = :bpcnum_0 and "
        Sql &= " (soh_0 = ' ' and sqh_0 <> ' ') and typ_0 = 2 and dat_0 > trunc(sysdate-30) and xduplica_0 <> 2 "

        If usr.Permiso.AccesoSecundario(43, "V") Then

            Sql &= " and estado_0 = 1 "

        End If

        Sql &= " ORDER BY nro_0 DESC"

        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("bpcnum_0", OracleType.VarChar).Value = nro
        da.Fill(dt)
        da.Dispose()
        If dt.Rows.Count > 0 Then MsgBox("Este cliente tiene presupuestos anteriores sin pedido")
        For Each dr As DataRow In dt.Rows()
            'ctz.Abrir(CLng(dr("nro_0")))
            If Not ctz.TieneArticulosNuevo(CInt(dr("nro_0"))) Then dr.Delete()
        Next

        col2Nro.DataPropertyName = "nro_0"
        col2Fecha.DataPropertyName = "dat_0"
        col2Cliente.DataPropertyName = "bpcnum_0"
        col2Nombre.DataPropertyName = "bpcnam_0"
        col2Vend.DataPropertyName = "rep_0"
        suc.DataPropertyName = "bpaadd_0"
        dgv2.DataSource = dt
        chkpresu.Checked = False
        chkrecargas.Checked = False
    End Sub
    Private Sub Limpiar()
        txtBpcnam.Clear()
        txtNom_fanta.Clear()
        txtOC.Clear()
        txtNro.Clear()
        txtFecha.Clear()
        txtPedido.Clear()
        txtPresupuesto.Clear()
        txtDesde1.Clear()
        txtDesde2.Clear()
        txtHasta1.Clear()
        txtHasta2.Clear()
        txtNombre_portero.Clear()
        txtMail_FC.Clear()
        txtPortero_celu.Clear()
        txtboxNumAnterior.Clear()
        Buscar()
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
    Private Function ValidacionHorarios() As Boolean

        If Not ValidarHora(txtDesde1.Text) Then
            txtDesde1.Focus()
            Return False
        End If
        If Not ValidarHora(txtDesde2.Text) Then
            txtDesde2.Focus()
            Return False
        End If
        If Not ValidarHora(txtHasta1.Text) Then
            txtHasta1.Focus()
            Return False
        End If
        If Not ValidarHora(txtHasta2.Text) Then
            txtHasta2.Focus()
            Return False
        End If

        Return True

    End Function
    Private Function FaltanArticulosRelacionados() As Boolean
        Dim arr As New ArrayList
        Dim txt As String = ""
        Dim itm As Articulo
        Dim flg As Boolean = False

        For Each dr As DataRow In ctz.Lineas.Rows
            itm = New Articulo(cn, dr("itmref_0").ToString)

            arr = ctz.ArticulosRelacionados(itm.Codigo)

            txt = "{itm} {des} requiere que exista: " & vbCrLf
            txt = txt.Replace("{itm}", itm.Codigo)
            txt = txt.Replace("{des}", itm.Descripcion)

            For index As Integer = 0 To arr.Count - 1
                itm = CType(arr.Item(index), Articulo)
                If Not ctz.TieneArticulo(itm.Codigo) Then
                    txt &= "- {itm} {des}" & vbCrLf
                    txt = txt.Replace("{itm}", itm.Codigo)
                    txt = txt.Replace("{des}", itm.Descripcion)
                    flg = True
                Else
                    flg = False
                    Exit For
                End If
            Next

            If Not flg Then Exit For

        Next

        If Not flg Then Return False

        If usr.Permiso.AccesoSecundario(43, "V") Then
            txt &= vbCrLf & vbCrLf
            txt &= "¿Continúa igualmente?"

            flg = MessageBox.Show(txt, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> Windows.Forms.DialogResult.Yes

        Else
            MessageBox.Show(txt, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        Return flg

    End Function
    Private Sub txtPresupuesto_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPresupuesto.DoubleClick
        If txtPresupuesto.Text.Trim = "" Then Exit Sub

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
    Private Sub btn_examinar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_examinar.Click
        Dim openFileDialog1 As New OpenFileDialog()
        openFileDialog1.InitialDirectory = "c:\"
        openFileDialog1.Filter = "pdf files (*.pdf)|*.pdf|All files (*.*)|*.*"
        openFileDialog1.FilterIndex = 2
        openFileDialog1.RestoreDirectory = True
        If txtOC.Text <> "" Then
            If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                Dim destino As String = "\\srv1\Compartido\OC\" & ctz.ClienteCodigo & "-" & txtOC.Text.Trim & ".pdf"
                File.Copy(openFileDialog1.FileName, destino, True)
                ctz.OCF = ctz.ClienteCodigo & "-" & txtOC.Text.Trim & ".pdf"
                ctz.OC = txtOC.Text.Trim
                btborrar.Enabled = True
                btver.Enabled = True
            End If
            pb.Visible = True
        Else
            Exit Sub
        End If

    End Sub
    Private Sub txtOC_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOC.LostFocus
        Dim txt As String = txtOC.Text.Trim
        If txt.IndexOf("/") <> -1 Then
            MsgBox("No se permite el simbolo /")
        End If
    End Sub
    Private Sub txtOC_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOC.TextChanged
        btn_examinar.Enabled = (txtOC.Text.Trim <> "")
    End Sub
    Private Sub btver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btver.Click
        Try
            Process.Start("\\srv1\Compartido\OC\" & ctz.ClienteCodigo & "-" & txtOC.Text.Trim & ".pdf")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub btborrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btborrar.Click
        Dim resultado As DialogResult = MessageBox.Show("Realmente quiere borrar la OC", "Aviso", MessageBoxButtons.YesNo)
        If resultado = Windows.Forms.DialogResult.Yes Then
            If File.Exists("\\srv1\Compartido\OC\" & ctz.ClienteCodigo & "-" & txtOC.Text.Trim & ".pdf") Then
                File.Delete("\\srv1\Compartido\OC\" & ctz.ClienteCodigo & "-" & txtOC.Text.Trim & ".pdf")
            End If
            ctz.OCF = ""
            ctz.OC = ""
            txtOC.Text = ""
            btborrar.Enabled = False
            btver.Enabled = False
            btn_examinar.Enabled = False
            pb.Visible = False
        ElseIf resultado = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If
    End Sub
    Private Sub chkrecargas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkrecargas.CheckedChanged
        If chkrecargas.Checked = True Then chkpresu.Checked = False
    End Sub
    Private Sub chkpresu_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkpresu.CheckedChanged
        If chkpresu.Checked = True Then chkrecargas.Checked = False
    End Sub
    Private Sub UsuariosV()
        Dim txt As String = ""
        'Dim errores As String = ""
        'Dim txterror As Boolean = True
        Dim sqh As New Presupuesto(cn)
        Dim flg As Boolean = True
        If txtPortero_celu.Text.Length = 10 Then
            For i = 0 To txtPortero_celu.Text.Length - 1
                If Not IsNumeric(txtPortero_celu.Text.Substring(i, 1)) Then
                    errores = "EL campo de telefono de contacto contiene caracteres no numericos" & vbCrLf
                    txtPortero_celu.BackColor = Color.Red
                    txterror = False
                    ' MsgBox("EL campo de telefono de contacto contiene caracteres no numericos")
                    'txtPortero_celu.Focus()
                    'Exit Sub
                End If
            Next
        Else
            If txterror = True Then
                errores = "El telefono de contacto debe tener 10 numeros,usted ingreso: " & txtPortero_celu.Text.Length & " ingrese los " & (10 - txtPortero_celu.Text.Length) & " restantes, incluido el codigo de area sin el 0" & vbCrLf
                txterror = False
            Else
                errores &= "El telefono de contacto debe tener 10 numeros,usted ingreso: " & txtPortero_celu.Text.Length & " ingrese los " & (10 - txtPortero_celu.Text.Length) & " restantes, incluido el codigo de area sin el 0" & vbCrLf
            End If
            txtPortero_celu.BackColor = Color.Red
        End If
        Grabar()

        If cboCondicionPago.BackColor = Drawing.Color.LightPink Then

            If txterror = True Then
                errores = "Se cambio la condicion de pago" & vbCrLf
                txterror = False
            Else
                errores &= "Se cambio la condicion de pago" & vbCrLf
            End If
            'Exit Sub
        End If

        If cboSociedad.SelectedValue.ToString = "DNY" Then

            With ctz.Cliente
                If .RegimenImpuesto = "RI" AndAlso .IIBB = "" And .CondicionIb <> "4" Then
                    MessageBox.Show("IIBB obligatorio para poder crear pedido", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
            End With
        End If
        If ctz.PedidoAdonix = "" Then
            If (txtDesde1.Text = "0000" And txtHasta1.Text = "0000" And txtDesde2.Text = "0000" And txtHasta2.Text = "0000") Then
                If txterror = True Then
                    errores = "Es obligatorio cargar los horarios" & vbCrLf
                    txterror = False
                Else
                    errores &= "Es obligatorio cargar los horarios" & vbCrLf
                End If
            ElseIf (txtDesde1.Text >= txtHasta1.Text And txtDesde2.Text = "0000" And txtHasta2.Text = "0000") Or (txtDesde2.Text >= txtHasta2.Text And txtDesde1.Text = "0000" And txtHasta1.Text = "0000") Then
                If txterror = True Then
                    errores = "El horario inicial no puede ser mayor al horario final" & vbCrLf
                    txterror = False
                    If txtDesde1.Text >= txtHasta1.Text And txtDesde2.Text = "0000" And txtHasta2.Text = "0000" Then txtDesde1.BackColor = Color.Red
                    If txtDesde2.Text >= txtHasta2.Text And txtDesde1.Text = "0000" And txtHasta1.Text = "0000" Then txtDesde2.BackColor = Color.Red
                Else
                    errores &= "El horario inicial no puede ser mayor al horario final" & vbCrLf
                End If
            ElseIf (txtHasta1.Text > txtDesde2.Text And txtDesde2.Text <> "0000") Then
                MessageBox.Show("El horario del turno mañana  no puede ser mayor al horario del turno tarde")
                Exit Sub
            End If
            If ctz.Cliente.EsProspecto Then
                txt = "No se puede crear un pedido a un prospecto"
                MessageBox.Show(txt, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            If (CInt(cboTipo.SelectedValue) <> 1 AndAlso ctz.PresupuestoAdonix.Trim = "") Or txtPresupuesto.Text.Trim <> "" Then
                If txterror = True Then
                    errores = "Esta cotizacion no debe usarse para crear un pedido" & vbCrLf
                    txterror = False
                Else
                    errores &= "Esta cotizacion no debe usarse para crear un pedido" & vbCrLf
                End If
            End If
            If ctz.SociedadCodigo = "LIA" And (ctz.Cliente.RegimenImpuesto = "RI" OrElse ctz.Cliente.RegimenImpuesto = "RIE") Then
                If txterror = True Then
                    errores = "La sociedad LIA no se puede usar con clientes RI" & vbCrLf
                    txterror = False
                Else
                    errores &= "La sociedad LIA no se puede usar con clientes RI" & vbCrLf
                End If
                cboSociedad.BackColor = Color.Red
            End If

            If FaltanArticulosRelacionados() Then Exit Sub

            'Si la cotizacion tiene un presupuesto
            If ctz.PresupuestoAdonix.Trim <> "" Then

                'Abro el presupuesto
                If sqh.Abrir(ctz.PresupuestoAdonix) Then
                    'El presupuesto no debe estar vencido
                    If sqh.Vencimiento.AddDays(15) > Date.Today Then
                        If txterror = True Then
                            errores = "El presupuesto está vencido" & vbCrLf
                            txterror = False
                            flg = False
                        Else
                            errores &= "El presupuesto está vencido" & vbCrLf
                            flg = False
                        End If
                    Else
                        If ctz.Cambio_Precio Then
                            If txterror = True Then
                                errores = "Se cambio de precio en el presupuesto" & vbCrLf
                                txterror = False
                            Else
                                errores &= "Se cambio de precio en el presupuesto" & vbCrLf
                            End If
                            flg = False
                        Else
                            flg = True
                        End If

                    End If
                End If
            End If
            If ctz.Sucursal.SucursalEntregaActiva = False Then
                If txterror = True Then
                    errores = "La sucursal no es para entregas o está desactivada" & vbCrLf
                    txterror = False
                    cboSucursal.BackColor = Color.Red
                Else
                    errores &= "La sucursal no es para entregas o está desactivada" & vbCrLf
                    cboSucursal.BackColor = Color.Red
                End If
                flg = False
            End If
            'Salgo si False
            If Not flg Then Exit Sub
            errores &= vbCrLf & "Quiere crear un pedido Adonix" & vbCrLf & vbCrLf
            errores &= "¿Confirma?"
            If MessageBox.Show(errores, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                errores = " "
                Exit Sub
            End If
            errores = " "
            'Aqui convertir a pedido Adonix
            Me.UseWaitCursor = True
            Application.DoEvents()
            Application.DoEvents()
            ctz.ConvertirEnPedido()
            txtPedido.Text = ctz.PedidoAdonix
            Me.UseWaitCursor = False
            Application.DoEvents()
            txt = "Pedido creado: " & ctz.PedidoAdonix
            If (ctz.OC = " " Or txtOC.Text = " ") And ctz.Cliente.OC_obligatoria Then
                With mail
                    .Nuevo()
                    .Remitente("noreply@matafuegosgeorgia.com", "Matafuegos Georgia")
                    .AgregarDestinatario("jrodriguez@matafuegosgeorgia.com", False)
                    .Asunto = "Pedido creado sin OC"
                    .Cuerpo = "El cliente: " & ctz.Cliente.Codigo & "-" & ctz.Cliente.Nombre & ", con el pedido: " & ctz.PedidoAdonix & " fue creado sin OC "
                    .Enviar()
                End With
            End If

        Else
            txt = "Ya existe un pedido creado para ésta cotización"
        End If
        MessageBox.Show(txt, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    Private Sub txtPortero_celu_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPortero_celu.TextChanged
        For i = 0 To txtPortero_celu.Text.Length - 1
            If Not IsNumeric(txtPortero_celu.Text.Substring(i, 1)) Then
                txtPortero_celu.BackColor = Color.Red
            Else
                txtPortero_celu.BackColor = Color.LightGreen
            End If
        Next

    End Sub
    Private Function LiaObligatorio() As Boolean
        Dim bpc As Cliente = ctz.Cliente

        'No es obligatorio si no es CF
        If bpc.RegimenImpuesto <> "CF" Then Return False
        'No se incluye a vendedores 22 23 28
        If bpc.Vendedor1Codigo = "22" OrElse bpc.Vendedor1Codigo = "23" OrElse bpc.Vendedor1Codigo = "28" Then Return False
        'Obligatorio para pedidos menores a MONTO_LIA_OBLIGATORIO
        If ctz.PrecioTotalAI >= MONTO_LIA_OBLIGATORIO Then Return False
        'Obligatorio si NO tiene facturas en el historico
        If bpc.TieneFacturas Then Return False
        'Debe ser LIA o H
        If Not (cboSociedad.SelectedValue.ToString = "LIA" Or chkH.Checked) Then
            Dim msg As String = "Debe usar sociedad LIA o H para este cliente"
            MessageBox.Show(msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return True
        End If

        Return False

    End Function

End Class