Imports System.Data.OracleClient
Imports System.Collections
Imports CrystalDecisions.CrystalReports.Engine
Imports WSAFIP
Imports WSAFIP.wsfe
Imports System.IO

Public Class frmCAE
    Const PRINTER_FACT As String = "\\SRV\RICOH SP 3710DN PCL 6 (Administracion)"

    Private da As OracleDataAdapter
    Private dt As New DataTable

    Private Sub frmCAE_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Sql As String

        AddHandler dgv.RowPostPaint, AddressOf NumeracionGrillas

        Sql = "SELECT * "
        Sql &= "FROM sinvoice sih "
        Sql &= "WHERE sih.sivtyp_0 <> 'PRF' AND "
        Sql &= "      sih.xfacte_0 = 3 AND "
        Sql &= "      sih.xcae_0 = ' ' AND "
        Sql &= "      sih.xafipcod_0 = :xafipcod_0 AND "
        Sql &= "      sih.scuvcr_0 = :scuvcr_0 AND  "
        Sql &= "      sih.cpy_0 = :cpy_0 "
        Sql &= "ORDER BY sih.num_0"

        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("xafipcod_0", OracleType.Int16)
        da.SelectCommand.Parameters.Add("scuvcr_0", OracleType.VarChar)
        da.SelectCommand.Parameters.Add("cpy_0", OracleType.VarChar)
        da.UpdateCommand = New OracleCommandBuilder(da).GetUpdateCommand

        Try
            da.FillSchema(dt, SchemaType.Mapped)

        Catch ex As Exception
        End Try

        dgv.DataSource = dt

        'Ajusto las columnas
        For i As Integer = 0 To dgv.Columns.Count - 1
            Dim col As DataGridViewColumn = dgv.Columns(i)

            Select Case i
                Case 2
                    col.HeaderText = "Numero"

                Case 11
                    col.HeaderText = "Fecha"

                Case 41
                    col.HeaderText = "Importe"
                    col.DefaultCellStyle.Format = "N2"
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                Case 164
                    col.HeaderText = "Usuario"

                Case 177
                    col.HeaderText = "CAE"

                Case 178
                    col.HeaderText = "Vto CAE"

                Case 179
                    col.HeaderText = "Motivo"

                Case Else
                    col.Visible = False

            End Select

            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            col.SortMode = DataGridViewColumnSortMode.NotSortable

        Next

        CargarPV()

    End Sub
    Private Sub btnFCA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFCA.Click
        Dim Soc As String
        Dim PV As String

        CType(dgv.DataSource, DataTable).Clear()

        If rbDny.Checked Then
            If cboDny.SelectedValue Is Nothing Then Exit Sub

            Soc = "DNY"
            PV = Strings.Right("000" & cboDny.SelectedValue.ToString, 4)

        ElseIf rbSch.Checked Then
            If cboSch.SelectedValue Is Nothing Then Exit Sub

            Soc = "SCH"
            PV = Strings.Right("000" & cboSch.SelectedValue.ToString, 4)

        Else
            Exit Sub

        End If

        ObtenerComprobantes(Soc, 1, PV)

    End Sub
    Private Sub btnFCB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFCB.Click
        Dim Soc As String
        Dim PV As String

        CType(dgv.DataSource, DataTable).Clear()

        If rbDny.Checked Then
            If cboDny.SelectedValue Is Nothing Then Exit Sub

            Soc = "DNY"
            PV = Strings.Right("000" & cboDny.SelectedValue.ToString, 4)
        ElseIf rbSch.Checked Then
            If cboSch.SelectedValue Is Nothing Then Exit Sub

            Soc = "SCH"
            PV = Strings.Right("000" & cboSch.SelectedValue.ToString, 4)

        Else
            Exit Sub

        End If

        ObtenerComprobantes(Soc, 6, PV)

    End Sub
    Private Sub btnNCA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNCA.Click
        Dim Soc As String
        Dim PV As String

        CType(dgv.DataSource, DataTable).Clear()

        If rbDny.Checked Then
            If cboDny.SelectedValue Is Nothing Then Exit Sub

            Soc = "DNY"
            PV = Strings.Right("000" & cboDny.SelectedValue.ToString, 4)
        ElseIf rbSch.Checked Then
            If cboSch.SelectedValue Is Nothing Then Exit Sub

            Soc = "SCH"
            PV = Strings.Right("000" & cboSch.SelectedValue.ToString, 4)

        Else
            Exit Sub

        End If

        ObtenerComprobantes(Soc, 3, PV)

    End Sub
    Private Sub btnNCB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNCB.Click
        Dim Soc As String
        Dim PV As String

        CType(dgv.DataSource, DataTable).Clear()

        If rbDny.Checked Then
            If cboDny.SelectedValue Is Nothing Then Exit Sub

            Soc = "DNY"
            PV = Strings.Right("000" & cboDny.SelectedValue.ToString, 4)
        ElseIf rbSch.Checked Then
            If cboSch.SelectedValue Is Nothing Then Exit Sub

            Soc = "SCH"
            PV = Strings.Right("000" & cboSch.SelectedValue.ToString, 4)

        Else
            Exit Sub

        End If

        ObtenerComprobantes(Soc, 8, PV)

    End Sub
    Private Sub btnNDA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNDA.Click
        Dim Soc As String
        Dim PV As String

        CType(dgv.DataSource, DataTable).Clear()

        If rbDny.Checked Then
            If cboDny.SelectedValue Is Nothing Then Exit Sub

            Soc = "DNY"
            PV = Strings.Right("000" & cboDny.SelectedValue.ToString, 4)
        ElseIf rbSch.Checked Then
            If cboSch.SelectedValue Is Nothing Then Exit Sub

            Soc = "SCH"
            PV = Strings.Right("000" & cboSch.SelectedValue.ToString, 4)

        Else
            Exit Sub

        End If

        ObtenerComprobantes(Soc, 2, PV)

    End Sub
    Private Sub btnNDB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNDB.Click
        Dim Soc As String
        Dim PV As String

        CType(dgv.DataSource, DataTable).Clear()

        If rbDny.Checked Then
            If cboDny.SelectedValue Is Nothing Then Exit Sub

            Soc = "DNY"
            PV = Strings.Right("000" & cboDny.SelectedValue.ToString, 4)
        ElseIf rbSch.Checked Then
            If cboSch.SelectedValue Is Nothing Then Exit Sub

            Soc = "SCH"
            PV = Strings.Right("000" & cboSch.SelectedValue.ToString, 4)

        Else
            Exit Sub

        End If

        ObtenerComprobantes(Soc, 7, PV)

    End Sub
    Private Sub btnFCAc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFCAc.Click
        Dim Soc As String
        Dim PV As String

        CType(dgv.DataSource, DataTable).Clear()

        If rbDny.Checked Then
            If cboDny.SelectedValue Is Nothing Then Exit Sub

            Soc = "DNY"
            PV = Strings.Right("000" & cboDny.SelectedValue.ToString, 4)

        ElseIf rbSch.Checked Then
            If cboSch.SelectedValue Is Nothing Then Exit Sub

            Soc = "SCH"
            PV = Strings.Right("000" & cboSch.SelectedValue.ToString, 4)

        Else
            Exit Sub

        End If

        ObtenerComprobantes(Soc, 201, PV)

    End Sub
    Private Sub btnFCBc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFCBc.Click
        Dim Soc As String
        Dim PV As String

        CType(dgv.DataSource, DataTable).Clear()

        If rbDny.Checked Then
            If cboDny.SelectedValue Is Nothing Then Exit Sub

            Soc = "DNY"
            PV = Strings.Right("000" & cboDny.SelectedValue.ToString, 4)
        ElseIf rbSch.Checked Then
            If cboSch.SelectedValue Is Nothing Then Exit Sub

            Soc = "SCH"
            PV = Strings.Right("000" & cboSch.SelectedValue.ToString, 4)

        Else
            Exit Sub

        End If

        ObtenerComprobantes(Soc, 206, PV)

    End Sub
    Private Sub btnNCAc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNCAc.Click
        Dim Soc As String
        Dim PV As String

        CType(dgv.DataSource, DataTable).Clear()

        If rbDny.Checked Then
            If cboDny.SelectedValue Is Nothing Then Exit Sub

            Soc = "DNY"
            PV = Strings.Right("000" & cboDny.SelectedValue.ToString, 4)
        ElseIf rbSch.Checked Then
            If cboSch.SelectedValue Is Nothing Then Exit Sub

            Soc = "SCH"
            PV = Strings.Right("000" & cboSch.SelectedValue.ToString, 4)

        Else
            Exit Sub

        End If

        ObtenerComprobantes(Soc, 203, PV)

    End Sub
    Private Sub btnNCBc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNCBc.Click
        Dim Soc As String
        Dim PV As String

        CType(dgv.DataSource, DataTable).Clear()

        If rbDny.Checked Then
            If cboDny.SelectedValue Is Nothing Then Exit Sub

            Soc = "DNY"
            PV = Strings.Right("000" & cboDny.SelectedValue.ToString, 4)
        ElseIf rbSch.Checked Then
            If cboSch.SelectedValue Is Nothing Then Exit Sub

            Soc = "SCH"
            PV = Strings.Right("000" & cboSch.SelectedValue.ToString, 4)

        Else
            Exit Sub

        End If

        ObtenerComprobantes(Soc, 208, PV)

    End Sub
    Private Sub btnNDAc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNDAc.Click
        Dim Soc As String
        Dim PV As String

        CType(dgv.DataSource, DataTable).Clear()

        If rbDny.Checked Then
            If cboDny.SelectedValue Is Nothing Then Exit Sub

            Soc = "DNY"
            PV = Strings.Right("000" & cboDny.SelectedValue.ToString, 4)
        ElseIf rbSch.Checked Then
            If cboSch.SelectedValue Is Nothing Then Exit Sub

            Soc = "SCH"
            PV = Strings.Right("000" & cboSch.SelectedValue.ToString, 4)

        Else
            Exit Sub

        End If

        ObtenerComprobantes(Soc, 202, PV)

    End Sub
    Private Sub btnNDBc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNDBc.Click
        Dim Soc As String
        Dim PV As String

        CType(dgv.DataSource, DataTable).Clear()

        If rbDny.Checked Then
            If cboDny.SelectedValue Is Nothing Then Exit Sub

            Soc = "DNY"
            PV = Strings.Right("000" & cboDny.SelectedValue.ToString, 4)
        ElseIf rbSch.Checked Then
            If cboSch.SelectedValue Is Nothing Then Exit Sub

            Soc = "SCH"
            PV = Strings.Right("000" & cboSch.SelectedValue.ToString, 4)

        Else
            Exit Sub

        End If

        ObtenerComprobantes(Soc, 207, PV)

    End Sub

    Private Sub ObtenerComprobantes(ByVal Soc As String, ByVal TipoCbte As Integer, ByVal PtoVta As String)
        gbBtn1.Enabled = False
        gbBtn2.Enabled = False
        gbSociedades.Enabled = False

        Try

            Label1.Text = "Recuperando documentos a autorizar..."
            Application.DoEvents()
            Application.DoEvents()

            da.SelectCommand.Parameters("xafipcod_0").Value = TipoCbte
            da.SelectCommand.Parameters("scuvcr_0").Value = PtoVta
            da.SelectCommand.Parameters("cpy_0").Value = Soc
            dt.Clear()
            da.Fill(dt)


        Catch ex As Exception
            Exit Sub

        End Try

        Application.DoEvents()
        Application.DoEvents()
        Application.DoEvents()


        If dt.Rows.Count = 0 Then
            Label1.Text = "No se encontraron comprobantes para autorizar"
            Exit Sub
        End If

        SolicitarCAE(Soc, TipoCbte, PtoVta)

        gbBtn1.Enabled = True
        gbBtn2.Enabled = True
        gbSociedades.Enabled = True

    End Sub
    Private Sub SolicitarCAE(ByVal Soc As String, ByVal TipoCbte As Integer, ByVal PtoVta As String)
        Dim ta As Ticket
        Dim sih As New Factura(cn)
        Dim CantidadMaximaRegistros As Integer
        Dim dv As New DataView(dt)

        'Establezco la cantidad maxima de registros que se pueden enviar por Request
        'Para FCE MiPyme, la cantidad máxima es 1
        If TipoCbte > 200 Then
            CantidadMaximaRegistros = 1
        Else
            CantidadMaximaRegistros = dt.Rows.Count
        End If

        dv.RowFilter = "xcae_0 = ' '"

        Try
            While dv.Count > 0

                'Detalle
                Dim FEDetalle(CantidadMaximaRegistros - 1) As FECAEDetRequest

                For i As Integer = 0 To dv.Count - 1
                    Dim dr As DataRow = CType(dv(i), DataRowView).Row

                    Dim Iva() As AlicIva = Nothing
                    Dim Trib() As Tributo = Nothing

                    sih.Abrir(dr("num_0").ToString)

                    FEDetalle(i) = New FECAEDetRequest

                    With FEDetalle(i)
                        .Concepto = 1
                        .DocTipo = CInt(IIf(sih.TipoDoc = " ", 0, sih.TipoDoc))

                        If IsNumeric(sih.Cuit) Then
                            .DocNro = CLng(IIf(sih.Cuit = " ", 0, sih.Cuit))
                        Else
                            .DocNro = 0
                        End If

                        .CbteDesde = CLng(Strings.Right(sih.Numero, 8))
                        .CbteHasta = .CbteDesde
                        .CbteFch = sih.Fecha.ToString("yyyyMMdd")
                        .ImpTotal = sih.ImporteII ' CDbl(dr("amtati_0")) 'Importe Total
                        .ImpTotConc = 0 'Neto No Gravado
                        .ImpNeto = 0    'Neto Gravado
                        .ImpIVA = 0     'IVA
                        .ImpOpEx = 0    'Importe Exento
                        .ImpTrib = 0 'Tributos provinciales
                        .MonId = sih.Divisa.CodigoAFIP
                        .MonCotiz = sih.Cotizacion

                        'Recorro los impuetos de la factura
                        For z = 0 To sih.CantImpuestos - 1

                            Select Case sih.TipoImpuesto(z)
                                Case "I00"
                                    .ImpNeto += sih.ImpuestoBase(z)

                                    If Iva Is Nothing Then
                                        ReDim Preserve Iva(0)
                                    Else
                                        ReDim Preserve Iva(Iva.Length)
                                    End If

                                    Iva(Iva.Length - 1) = New AlicIva
                                    With Iva(Iva.Length - 1)
                                        .Id = 3
                                        .BaseImp = Math.Round(sih.ImpuestoBase(z), 2)
                                        .Importe = Math.Round(sih.ImpuestoImporte(z), 2)
                                    End With

                                Case "I10"
                                    .ImpNeto += sih.ImpuestoBase(z)
                                    .ImpIVA += sih.ImpuestoImporte(z)

                                    If Iva Is Nothing Then
                                        ReDim Preserve Iva(0)
                                    Else
                                        ReDim Preserve Iva(Iva.Length)
                                    End If

                                    Iva(Iva.Length - 1) = New AlicIva
                                    With Iva(Iva.Length - 1)
                                        .Id = 4
                                        .BaseImp = Math.Round(sih.ImpuestoBase(z), 2)
                                        .Importe = Math.Round(sih.ImpuestoImporte(z), 2)
                                    End With

                                Case "I21"
                                    .ImpNeto += sih.ImpuestoBase(z)
                                    .ImpIVA += sih.ImpuestoImporte(z)

                                    If Iva Is Nothing Then
                                        ReDim Preserve Iva(0)
                                    Else
                                        ReDim Preserve Iva(Iva.Length)
                                    End If

                                    Iva(Iva.Length - 1) = New AlicIva
                                    With Iva(Iva.Length - 1)
                                        .Id = 5
                                        .BaseImp = Math.Round(sih.ImpuestoBase(z), 2)
                                        .Importe = Math.Round(sih.ImpuestoImporte(z), 2)
                                    End With

                                Case "I99", "999"
                                    .ImpOpEx += sih.ImpuestoBase(z)

                                Case Else
                                    .ImpTrib += sih.ImpuestoImporte(z)

                                    If Trib Is Nothing Then
                                        ReDim Preserve Trib(0)
                                    Else
                                        ReDim Preserve Trib(Trib.Length)
                                    End If

                                    Trib(Trib.Length - 1) = New Tributo

                                    With Trib(Trib.Length - 1)
                                        .Id = 2 'Buscar con tiempo cual es codigo correcto.
                                        .BaseImp = Math.Round(sih.ImpuestoBase(z), 2)
                                        .Importe = Math.Round(sih.ImpuestoImporte(z), 2)
                                        .Desc = "Percepción IB CABA"
                                    End With

                            End Select
                        Next

                        If Iva IsNot Nothing Then .Iva = Iva
                        If Trib IsNot Nothing Then .Tributos = Trib

                        'FIX - Correccion de decimales
                        .ImpTotal = Math.Round(.ImpTotal, 2)
                        .ImpTotConc = Math.Round(.ImpTotConc, 2)
                        .ImpNeto = Math.Round(.ImpNeto, 2)
                        .ImpIVA = Math.Round(.ImpIVA, 2)
                        .ImpOpEx = Math.Round(.ImpOpEx, 2)
                        .ImpTrib = Math.Round(.ImpTrib, 2)

                        'Factura de Crédito Electrónica
                        Dim Opcionales() As Opcional = Nothing

                        Select Case TipoCbte
                            Case 201, 206 'Facturas A y B
                                Dim ban As Banco = sih.Banco

                                If ban IsNot Nothing Then
                                    ReDim Opcionales(1)

                                    Opcionales(0) = New Opcional
                                    Opcionales(1) = New Opcional

                                    Opcionales(0).Id = "2101" : Opcionales(0).Valor = ban.CBU
                                    Opcionales(1).Id = "2102" : Opcionales(1).Valor = ban.AAlias
                                    .Opcionales = Opcionales
                                End If

                                .FchVtoPago = sih.FechaVtoPago.ToString("yyyyMMdd")

                            Case 202, 207 'Notas de Débito
                                Dim f As Factura = sih.CbteOrigen

                                If f Is Nothing Then Exit Select

                                Dim CbteAsoc(0) As CbteAsoc

                                CbteAsoc(0) = New CbteAsoc
                                CbteAsoc(0).Tipo = f.AFIPTipoDoc
                                CbteAsoc(0).PtoVta = CInt(f.PuntoVenta)
                                CbteAsoc(0).Nro = CLng(Strings.Right(f.Numero, 8))
                                CbteAsoc(0).Cuit = f.Sociedad.Cuit
                                CbteAsoc(0).CbteFch = f.Fecha.ToString("yyyyMMdd")
                                .CbtesAsoc = CbteAsoc

                                ReDim Opcionales(0)
                                Opcionales(0) = New Opcional
                                Opcionales(0).Id = "22"
                                Opcionales(0).Valor = "N"
                                .Opcionales = Opcionales

                            Case 203, 209 'Notas de Crédito
                                ReDim Opcionales(0)
                                Opcionales(0) = New Opcional
                                Opcionales(0).Id = "22"
                                Opcionales(0).Valor = IIf(sih.FCEAnula, "S", "N").ToString
                                .Opcionales = Opcionales

                                Dim CbteAsoc(0) As CbteAsoc
                                Dim f As Factura = sih.CbteOrigen

                                CbteAsoc(0) = New CbteAsoc
                                CbteAsoc(0).Tipo = f.AFIPTipoDoc
                                CbteAsoc(0).PtoVta = CInt(f.PuntoVenta)
                                CbteAsoc(0).Nro = CLng(Strings.Right(f.Numero, 8))
                                CbteAsoc(0).Cuit = f.Sociedad.Cuit
                                CbteAsoc(0).CbteFch = f.Fecha.ToString("yyyyMMdd")
                                .CbtesAsoc = CbteAsoc

                        End Select

                    End With

                    If i + 1 = CantidadMaximaRegistros Then Exit For

                Next

                'Cabecera
                Dim FEreq As New FECAERequest
                FEreq.FeCabReq = New FECAECabRequest
                FEreq.FeCabReq.PtoVta = CInt(PtoVta)
                FEreq.FeCabReq.CbteTipo = TipoCbte
                FEreq.FeCabReq.CantReg = CantidadMaximaRegistros
                FEreq.FeDetReq = FEDetalle

                Dim res As FECAEResponse

                Label1.Text = "Solicitando autorización a AFIP..."
                Application.DoEvents()
                Application.DoEvents()

                Dim fe As FacturaElectronica = Nothing

                ta = ObtenerTicket(Soc)

                If ta Is Nothing Then
                    MessageBox.Show("No se pudo obtener un Ticket de Acceso válido", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

                Dim Cpy As New Sociedad(cn)
                Cpy.abrir(Soc)

                fe = New FacturaElectronica(ta, CLng(Cpy.Cuit))
                res = fe.SolicitarCAE(FEreq)


                'Analizo la cabecera de la respuesta
                If res.Errors IsNot Nothing Then
                    MessageBox.Show(res.Errors(0).Msg, res.Errors(0).Code.ToString, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit While

                Else
                    If ProcesarRespuestaAfip(res, Soc) Then
                        Exit While
                    End If

                End If

            End While

            ImprimirTodo()

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        Label1.Text = ""

    End Sub
    Private Function ConvertirAFecha(ByVal f As String) As Date
        Dim aa As Integer = 1599
        Dim mm As Integer = 12
        Dim dd As Integer = 31

        If f <> "" Then
            aa = CInt(f.Substring(0, 4))
            mm = CInt(f.Substring(4, 2))
            dd = CInt(f.Substring(6, 2))
        End If

        Return New Date(aa, mm, dd)
    End Function
    Private Function ConvertirCbteAdonix(ByVal Soc As String, ByVal Num As Long, ByVal Tipo As Integer, ByVal Sucursal As Integer) As String
        Dim txt As String = Soc

        Select Case Tipo
            Case 1
                txt &= "FCA"
            Case 2
                txt &= "NDA"
            Case 3
                txt &= "NCA"
            Case 6
                txt &= "FCB"
            Case 7
                txt &= "NDB"
            Case 8
                txt &= "NCB"
            Case 201
                txt &= "XFA"
            Case 202
                txt &= "XDA"
            Case 203
                txt &= "XCA"
            Case 206
                txt &= "XFB"
            Case 207
                txt &= "XDB"
            Case 208
                txt &= "XCB"

        End Select

        txt &= Strings.Right("000" & Sucursal.ToString, 4)
        txt &= Strings.Right("0000000" & Num.ToString, 8)

        Return txt

    End Function
    Private Function ProcesarRespuestaAfip(ByVal e As wsfe.FECAEResponse, ByVal cpy As String) As Boolean
        Dim txt As String = ""
        Dim dr As DataRow
        Dim Cbte As String = ""
        Dim Cancel As Boolean = False

        If e.FeDetResp IsNot Nothing Then

            For i = 0 To e.FeDetResp.Length - 1

                With e.FeDetResp(i)
                    Cbte = ConvertirCbteAdonix(cpy, .CbteDesde, e.FeCabResp.CbteTipo, e.FeCabResp.PtoVta)

                    'Cancelo por encontrar error
                    If .Resultado = "R" Then
                        txt = .Observaciones(0).Code.ToString
                        txt &= " "
                        txt &= .Observaciones(0).Msg

                        MessageBox.Show(txt, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Cancel = True

                    Else
                        'Pego CAE a la factura en la grilla
                        For Each dr In dt.Rows
                            If dr("num_0").ToString = Cbte Then
                                dr.BeginEdit()
                                dr("xcaesta_0") = 2
                                dr("xcae_0") = .CAE
                                dr("xdatvlycae_0") = ConvertirAFecha(.CAEFchVto)
                                dr("xexpflg_0") = 2
                                If .Observaciones IsNot Nothing Then
                                    dr("xmotivcae_0") = .Observaciones(0).Code.ToString
                                End If
                                dr.EndEdit()
                            End If
                        Next

                    End If

                End With

                If Cancel Then Exit For

            Next

            da.Update(dt)

        End If

        Return Cancel

    End Function
    Private Sub ctxMenu_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ctxMenu.Opening
        Dim i As Integer = 0

        If dt.Rows.Count = 0 Then
            e.Cancel = True

        Else
            mnuVerCbte.Enabled = dgv.SelectedRows.Count = 1
            mnuPrintCbte.Enabled = dgv.SelectedRows.Count = 1
            mnuPrintAll.Enabled = True

            'Sumo la cantidad de documentos sin CAE
            mnuCAE.Enabled = False
            For Each dr As DataRow In dt.Rows
                If dr("xcae_0").ToString.Trim = "" Then mnuCAE.Enabled = True
            Next

        End If

    End Sub
    Private Sub mnuVerCbte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuVerCbte.Click
        'Muestro el comprobante seleccionado
        Dim rpt As New ReportDocument
        Dim f As frmCrystal
        Dim Cbte As String = dgv.SelectedRows(0).Cells("num_0").Value.ToString

        Try
            rpt.Load(RPTX3 & "xfact_elec.rpt")
            rpt.SetParameterValue("OCULTAR_BARRAS", False)
            rpt.SetParameterValue("facturedeb", Cbte)
            rpt.SetParameterValue("facturefin", Cbte)
            rpt.SetParameterValue("CERO", False)
            rpt.SetParameterValue("X3DOS", X3DOS)
            rpt.SetParameterValue("ENVIAR", True)
            f = New frmCrystal(rpt)
            f.ShowDialog()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub
    Private Sub mnuPrintCbte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPrintCbte.Click

        Dim Cbte As String = dgv.SelectedRows(0).Cells("num_0").Value.ToString
        Dim Tipo As String
        Dim Cbt As New Factura(cn)
        Tipo = Cbte.Substring(0, 10)
        Cbt.Abrir(Cbte)
        Try
            Dim rpt As New ReportDocument
            With rpt
                .Load(RPTX3 & "xfact_elec.rpt")
                .SetParameterValue("OCULTAR_BARRAS", False)
                .SetParameterValue("facturedeb", Cbte)
                .SetParameterValue("facturefin", Cbte)
                .SetParameterValue("CERO", False)
                .SetDatabaseLogon(DB_USR, DB_PWD)
                .SetParameterValue("X3DOS", X3DOS)
                .SetParameterValue("ENVIAR", False)
                .PrintToPrinter(Copias(Tipo, Cbt.Sociedad.Codigo), False, 1, 99999)
            End With
            rpt.Dispose()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub
    Private Sub mnuPrintAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPrintAll.Click
        If MessageBox.Show("¿Confirma la impresión de todos los comprobantes?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

            ImprimirTodo()

        End If
    End Sub
    Private Sub mnuCAE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCAE.Click
        Dim Cbte As String
        Dim f As New Factura(cn)
        Dim FCr As wsfe.FECompConsultaResponse
        Dim dr As DataRow
        Dim ta As New Ticket 'ServidorAutorizacion("WSFE")
        Dim fe As FacturaElectronica = Nothing

        For Each dr In dt.Rows
            Cbte = dr("num_0").ToString

            If f.Abrir(Cbte) Then

                If fe Is Nothing Then
                    ta = ObtenerTicket(f.Sociedad.Codigo)
                    fe = New FacturaElectronica(ta, CLng(f.Sociedad.Cuit))
                End If

                Dim p As Integer = CInt(f.PuntoVenta)
                Dim t As Integer = f.AFIPTipoDoc
                Dim n As Long = CLng(Strings.Right(f.Numero, 8))

                Try
                    FCr = fe.RecuperarCAE(p, t, n)

                    If FCr.ResultGet IsNot Nothing Then
                        With FCr.ResultGet
                            f.SetCAE(.CodAutorizacion, ConvertirAFecha(.FchVto))
                            f.Grabar()

                            dr.BeginEdit()
                            dr("xcae_0") = .CodAutorizacion
                            dr("xdatvlycae_0") = ConvertirAFecha(.FchVto)
                            dr.EndEdit()

                        End With

                    Else
                        'Posiblemente no existe CAE para este comprobante
                        Exit Sub

                    End If

                Catch ex As Exception
                    MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub

                End Try

            End If
        Next

    End Sub
    Private Sub ImprimirTodo()
        If Not HayAceptados() Then Exit Sub

        Dim Usuario As String = ""
        Dim dt As DataTable = CType(dgv.DataSource, DataTable)
        Dim dr As DataRow
        Dim Cbte As New Factura(cn)
        Dim Cliente As New ArrayList
        Dim NroDocumentoDesde As String = ""
        Dim NroDocumentoHasta As String = ""
        Dim TipoDocumento As String = ""

        Label1.Text = "Imprimiendo documentos..."
        Application.DoEvents()
        Application.DoEvents()

        For i As Integer = 0 To dt.Rows.Count - 1
            dr = dt.Rows(i)

            'Imprimir Acuse de recibo
            If Cbte.Abrir(dr("num_0").ToString) Then
                'Miro si el cliente ya fue impreso
                If Not Cliente.Contains(Cbte.Cliente.Codigo) Then
                    If Cbte.Cliente.RequiereFacturaFisica Then
                        ImprimirAcuse(Cbte)
                        Cliente.Add(Cbte.Cliente.Codigo.ToString)
                    End If
                End If
            End If

            If TipoDocumento = "" Then
                'Guardo el tipo de documento DNYFCA0009 / DNYFCB0009 / GRUFCB0003 , etc...
                TipoDocumento = dr("num_0").ToString.Substring(0, 10)
                'Guardo el usuario de creación del comprobante
                Usuario = dr("creusr_0").ToString

                'Guardo el numero de comprobante
                NroDocumentoDesde = dr("num_0").ToString
                NroDocumentoHasta = dr("num_0").ToString

                'Imprimo si llegue al final de la lista
                If i = dt.Rows.Count - 1 Then
                    ImprimirFacturas(NroDocumentoDesde, NroDocumentoHasta, Usuario)
                End If

            ElseIf TipoDocumento = dr("num_0").ToString.Substring(0, 10) AndAlso Usuario = dr("creusr_0").ToString Then
                'Actualizo el ultimo comprobante
                NroDocumentoHasta = dr("num_0").ToString

                'Imprimo si llegue al final de la lista
                If i = dt.Rows.Count - 1 Then
                    ImprimirFacturas(NroDocumentoDesde, NroDocumentoHasta, Usuario)
                End If

            Else
                'Imprimo el lote por cambio de documento o usuario
                ImprimirFacturas(NroDocumentoDesde, NroDocumentoHasta, Usuario)

                'Comienzo proceso con nuevo tipo de comprobantes
                TipoDocumento = dr("num_0").ToString.Substring(0, 10)
                Usuario = dr("creusr_0").ToString
                'Guardo el numero de comprobante
                NroDocumentoDesde = dr("num_0").ToString
                NroDocumentoHasta = dr("num_0").ToString

                'Imprimo al llegar al final de la lista
                If i = dt.Rows.Count - 1 Then
                    ImprimirFacturas(NroDocumentoDesde, NroDocumentoHasta, Usuario)
                End If

            End If

        Next

        Label1.Text = ""

    End Sub
    Private Sub ImprimirFacturas(ByVal Desde As String, ByVal Hasta As String, ByVal Usuario As String, Optional ByVal AnulaFiltroRequiere As Boolean = False)
        Dim Rpt As New ReportDocument
        Dim TipoDocumento As String = Desde.Substring(3, 2)
        Dim SociedadDocumento As String = Desde.Substring(0, 3)
        Dim FiltrarRequiereFacturaFisica As Boolean

        'Para facturas de DNY solo se imprimen donde el cliente tiene tildada la opción
        'requiere factura fisica = SI. Salvo que se anule este filtro con el parametro AnulaFiltroRequiere
        FiltrarRequiereFacturaFisica = (TipoDocumento = "FC" And SociedadDocumento = "DNY" And Not AnulaFiltroRequiere)

        With Rpt
            .Load(RPTX3 & "xfact_elec.rpt")
            .SetDatabaseLogon(DB_USR, DB_PWD)
            .SetParameterValue("X3DOS", X3DOS)
            .SetParameterValue("OCULTAR_BARRAS", False)
            .SetParameterValue("facturedeb", Desde)
            .SetParameterValue("facturefin", Hasta)
            .SetParameterValue("CERO", False)
            .SetParameterValue("ENVIAR", FiltrarRequiereFacturaFisica)
        End With

        If usr.Codigo <> Usuario Then
            Rpt.PrintOptions.PrinterName = PRINTER_FACT
        End If

        Rpt.PrintToPrinter(Copias(TipoDocumento, SociedadDocumento), Ordenamiento(TipoDocumento), 1, 99999)

        Rpt.Dispose()

    End Sub
    Private Sub ImprimirAcuse(ByVal Cbte As Factura)

        Dim dr As DataRow
        Dim dt As New DataTable
        Dim da As OracleDataAdapter
        Dim Sql As String
        Dim flg As Boolean
        Dim rpt As ReportDocument

        Sql = "SELECT bpaadd_0 "
        Sql &= "FROM bpaddress "
        Sql &= "WHERE xentfac_0 = 2 AND bpanum_0 = :bpanum_0"

        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("bpanum_0", OracleType.VarChar).Value = Cbte.Cliente.Codigo

        da.Fill(dt)
        da.Dispose()

        Select Case dt.Rows.Count
            Case 0
                flg = False

            Case 1
                dr = dt.Rows(0)

                flg = (dr(0).ToString <> Cbte.Cliente.SucursalLegal.Sucursal)

            Case Else
                flg = True

        End Select

        If flg Then
            rpt = New ReportDocument
            With rpt
                .Load(RPTX3 & "XACUREC2.rpt")
                .SetDatabaseLogon(DB_USR, DB_PWD)
                .SetParameterValue("X3DOS", X3DOS)
                .SetParameterValue("num", Cbte.Numero)
            End With

            If usr.Codigo <> Cbte.UsuarioCreacion Then
                rpt.PrintOptions.PrinterName = PRINTER_FACT
            End If
            If rpt.Rows.Count > 0 Then
                rpt.PrintToPrinter(1, False, 1, 99999)
            End If

            rpt.Dispose()

        End If

    End Sub
    Private Function Ordenamiento(ByVal Tipo As String) As Boolean
        Return Tipo = "FC"
    End Function
    Private Function Copias(ByVal Tipo As String, ByVal cpy As String) As Integer
        Select Case Tipo
            Case "FC", "XF"
                If cpy = "DNY" Then
                    Return 1
                Else
                    Return 1
                End If

            Case "ND", "XD"
                Return 2

            Case "NC", "XC"
                Return 1

            Case Else
                Return 1

        End Select
    End Function
    Private Function HayAceptados() As Boolean
        Dim dr As DataRow
        Dim flg As Boolean = False

        For Each dr In dt.Rows
            If dr("xcae_0").ToString.Trim <> "" Then
                flg = True
                Exit For
            End If
        Next

        Return flg
    End Function
    Private Sub CargarPV()
        Dim cpy As New Sociedad(cn)
        Dim fe As FacturaElectronica
        Dim ta As Ticket

        For Each o As Object In gbSociedades.Controls
            If TypeOf o Is ComboBox Then
                Dim cbo As ComboBox = CType(o, ComboBox)

                If cbo.Tag Is Nothing OrElse cbo.Tag.ToString.Trim = "" Then Continue For

                cpy.abrir(cbo.Tag.ToString)
                ta = ObtenerTicket(cbo.Tag.ToString)

                If ta IsNot Nothing Then
                    Try
                        fe = New FacturaElectronica(ta, CLng(cpy.Cuit))
                        cbo.DataSource = fe.PuntosVentas.ResultGet
                        cbo.DisplayMember = "Nro"
                        cbo.ValueMember = "Nro"

                    Catch ex As Exception
                        MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

                    End Try

                End If

            End If

        Next

    End Sub

    Private Function ObtenerTicket(ByVal Sociedad As String) As Ticket
        Dim wsas As ServidorAutorizacion
        Dim ta As Ticket = Nothing
        Dim Path As String = "CERTIFICADOS\"
        Dim NombreTicket As String = ""
        Dim NombreCertificado As String = ""

        Select Case Sociedad
            Case "DNY", "GRU"
                NombreTicket = "fe_dny.xml"
                NombreCertificado = "dny.p12"

            Case "LIA"
                NombreTicket = "fe_lia.xml"
                NombreCertificado = "lia.p12"

            Case "SCH"
                NombreTicket = "fe_sch.xml"
                NombreCertificado = "sch.p12"

        End Select
        'Intento abrir un ticket existente
        Try
            If File.Exists(NombreTicket) Then
                ta = New Ticket
                ta.Load(NombreTicket)
            End If

        Catch ex As Exception
            ta = Nothing
        End Try
        'Pido nuevo ticket al servidor de afip
        If ta Is Nothing OrElse ta.ExpirationTime <= Now Then

            Try
                wsas = New ServidorAutorizacion(Path & NombreCertificado, "1234")

                ta = wsas.SolicitarTicket("wsfe")

                If ta IsNot Nothing Then ta.Save(NombreTicket)

            Catch ex As Exception
                ta = Nothing

            End Try

        End If

        Return ta

    End Function

End Class