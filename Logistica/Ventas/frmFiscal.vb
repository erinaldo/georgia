Imports System.Data.OracleClient
Imports Clases
Imports FiscalNET
Imports Microsoft.Win32
Imports System.IO

Public Class frmFiscal
    Private sih As New Factura(cn)
    Private FiscalEpson As New EpsonForm
    Private FiscalHasar As New HasarForm
    Private SociedadActual As String

    Public Sub New(ByVal cpy As String)
        InitializeComponent()

        SociedadActual = cpy

    End Sub
    Private Sub frmFiscal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim RegKey As RegistryKey = Registry.CurrentUser.OpenSubKey("Software", True).CreateSubKey("Georgia")
        Dim Dato As Object = Nothing

        'Configuraciones Iniciales Segun Sociedad
        FiscalEpson.SerialNumber = "27-0163848-435"
        FiscalHasar.SerialNumber = "27-0163848-435"

        'Obtengo puerto COM
        Dato = RegKey.GetValue(SociedadActual)
        If Dato IsNot Nothing Then txtPuerto.Text = Dato.ToString
        RegKey.Close()

        'Obtengo datos de la sociedad
        Dim cpy As New Sociedad(cn)
        cpy.abrir(SociedadActual)
        Me.Text = "Controlador Fiscal - " & cpy.Nombre
        cpy = Nothing

        'Recupero ultimos numeradores
        If AbrirPuertoFiscal() Then
            ObtenerUltimosNumeradores()
            CerrarPuertoFiscal()
        End If

    End Sub
    '-----------------------------------------------------------------------------------------
    ' VALIDACIONES DE PUERTO FISCAL
    '-----------------------------------------------------------------------------------------
    Private Sub txtPuerto_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtPuerto.Validating
        Dim txt As TextBox = CType(sender, TextBox)

        With txt
            .Text = .Text.Trim
            If .Text.Length <> 1 Then e.Cancel = True
            If IsNumeric(.Text) = False Then e.Cancel = True
        End With

    End Sub
    Private Sub txtPuerto_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPuerto.Validated
        Dim RegKey As RegistryKey = Registry.CurrentUser.OpenSubKey("Software", True).CreateSubKey("Georgia")
        RegKey.SetValue(SociedadActual, txtPuerto.Text)
        RegKey.Close()
    End Sub
    '-----------------------------------------------------------------------------------------
    ' BOTONERA PARA IMPRESION DE COMPROBANTES
    '-----------------------------------------------------------------------------------------
    Private Sub btnFcA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFcA.Click
        BuscarComprobantes("FCA")
    End Sub
    Private Sub btnFcB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFcB.Click
        BuscarComprobantes("FCB")
    End Sub
    Private Sub btnNcA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNcA.Click
        BuscarComprobantes("NCA")
    End Sub
    Private Sub btnNcB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNcB.Click
        BuscarComprobantes("NCB")
    End Sub
    Private Sub btnNdA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNdA.Click
        BuscarComprobantes("NDA")
    End Sub
    Private Sub btnNdB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNdB.Click
        BuscarComprobantes("NDB")
    End Sub
    Private Sub btnZ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCierreZ.Click
        grpImprimir.Enabled = False
        Application.DoEvents()

        CierreZFiscal()

        grpImprimir.Enabled = True

    End Sub
    '-----------------------------------------------------------------------------------------
    ' BUSQUEDA DE COMPROBANTES A IMPRIMIR
    '-----------------------------------------------------------------------------------------
    Private Sub BuscarComprobantes(ByVal Tipo As String)
        Dim Sql As String
        Dim da As OracleDataAdapter
        Dim dt As New DataTable

        grpImprimir.Enabled = False
        Application.DoEvents()

        'Recupero las facturas de IMPRESORA FISCAL que no están impresas
        Sql = "SELECT num_0 "
        Sql &= "FROM sinvoice "
        Sql &= "WHERE cpy_0    = :cpy AND "
        Sql &= "      scuvcr_0 = :scuvcr AND "
        Sql &= "      typvcr_0 = :typvcr AND "
        Sql &= "      clsvcr_0 = :clsvcr AND "
        Sql &= "      xfiscal_0 <> 2 "
        Sql &= "ORDER BY num_0"

        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("cpy", OracleType.VarChar).Value = SociedadActual
        da.SelectCommand.Parameters.Add("scuvcr", OracleType.VarChar).Value = IIf(SociedadActual = "GRU", "0003", "0001")
        da.SelectCommand.Parameters.Add("typvcr", OracleType.VarChar).Value = Tipo.Substring(0, 2)
        da.SelectCommand.Parameters.Add("clsvcr", OracleType.VarChar).Value = Tipo.Substring(2, 1)

        Try
            da.Fill(dt)
        Catch ex As Exception
            Exit Sub
        End Try

        If dt.Rows.Count > 0 Then
            ImprimirEnFiscal(dt)
        Else
            MessageBox.Show("No hay comprobantes pendientes de impresión", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        grpImprimir.Enabled = True

    End Sub
    '-----------------------------------------------------------------------------------------
    ' IMPRESION EN CONTROLADOR FISCAL
    '-----------------------------------------------------------------------------------------
    Private Sub ImprimirEnFiscal(ByVal dt As DataTable)
        Dim txt As String
        Dim e As Boolean
        '----------------------------------------------------------------------------
        ' SE ABRE EL PUERTO FISCAL
        '----------------------------------------------------------------------------
        AbrirPuertoFiscal()
        '----------------------------------------------------------------------------
        ' RECORRIDO POR TODAS LAS FACTURAS
        '----------------------------------------------------------------------------
        For Each dr As DataRow In dt.Rows
            'Usado para incluir datos de la administracion en la factura
            Dim LineaExtra1 As String = ""
            Dim LineaExtra2 As String = ""
            Dim LineaExtra3 As String = ""

            'Apertura de la factura de Adonix
            If sih.Abrir(dr(0).ToString) Then
                Dim FacturaAdonix As Long = CLng(sih.Numero.Substring(10, 8))
                'Obtengo el proximo numero a imprimir por la impresora
                Dim ProximoImprimir As Long = ObtenerUltimoImpreso(sih.TipoComprobante, sih.LetraComprobante)
                ProximoImprimir += 1

                If ProximoImprimir > FacturaAdonix Then
                    'Si el proximo a imprimir es mayor, marco la factura como impresora
                    sih.FacturaFiscalImpresa()
                    sih.Grabar()
                    Continue For

                ElseIf ProximoImprimir < FacturaAdonix Then
                    'Se crean facturas anuladas hasta para adelantar el numerador
                    For i = ProximoImprimir To FacturaAdonix - 1
                        AbrirComprobanteFiscal(sih)
                        CancelarComprobanteFiscal()
                    Next

                End If

                'Chequeo que el cuit tenga formato correcto
                If Not sih.CheckCuit Then
                    txt = "Cuit de factura " & sih.Numero & " no es válido"
                    MessageBox.Show(txt, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit For
                End If
                'Obtengo datos de la administracion para incluir en la factura
                If sih.Cliente.Codigo <> sih.Cliente.TerceroPagador.Codigo Then
                    LineaExtra1 = sih.Cliente.TerceroPagador.Codigo & " " & sih.Cliente.TerceroPagador.Nombre
                    LineaExtra2 = sih.Cliente.TerceroPagador.SucursalLegal.Direccion
                    LineaExtra3 = Strings.StrDup(30, "-")
                End If

                '-------------------------------------------------------------
                ' APERTURA DEL COMPROBANTE FISCAL
                '-------------------------------------------------------------
                If Not AbrirComprobanteFiscal(sih) Then
                    txt = "No se pudo crear el comprobante fiscal"
                    MessageBox.Show(txt, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit For
                End If
                '-------------------------------------------------------------
                ' DETALLE DEL COMPROBANTE FISCAL
                '-------------------------------------------------------------
                For Each drd As DataRow In sih.DetalleFactura.Rows

                    e = AgregarItemFiscal(drd, LineaExtra1, LineaExtra2, LineaExtra3)

                    LineaExtra1 = ""
                    LineaExtra2 = ""
                    LineaExtra3 = ""

                    If Not e Then Exit For
                Next

                'Cierre del comprobante Fiscal
                If e Then e = CerrarComprobanteFiscal()

                If e Then
                    'Marco factura como impresa
                    sih.FacturaFiscalImpresa()
                    sih.Grabar()
                Else
                    'Cancelacion del documento por error
                    CancelarComprobanteFiscal()

                    txt = "Error al imprimir el comprobante " & sih.Numero & vbCrLf & vbCrLf
                    txt &= "Debe borrar el comprobante en Adonix y volver a facturar."

                    MessageBox.Show(txt, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit For

                End If

            Else
                MessageBox.Show("No se pudo abrir la factura", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                sih = Nothing
                Exit For
            End If

        Next

        ObtenerUltimosNumeradores()
        CerrarPuertoFiscal()

    End Sub
    '-----------------------------------------------------------------------------------------
    ' COMANDOS DEL CONTROLADOR FISCAL
    '-----------------------------------------------------------------------------------------
    Private Function AbrirPuertoFiscal() As Boolean
        Dim flg As Boolean = False
        Dim e As Integer

        Select Case SociedadActual
            Case "GRU"
                e = FiscalEpson.IF_OPEN("COM" & txtPuerto.Text, 9600)

            Case "LIA", "SCH"
                e = FiscalHasar.IF_OPEN("COM" & txtPuerto.Text, 9600)
        End Select

        Return e <> -1
    End Function
    Private Function AbrirComprobanteFiscal(ByVal sih As Factura) As Boolean
        Dim e As Integer

        Select Case SociedadActual
            Case "GRU"
                e = FiscalEpson.FACTABRE(HTipo(sih.TipoComprobante), _
                                         "C", _
                                         sih.LetraComprobante, _
                                         1, _
                                         "F", _
                                         "17", _
                                         "I", _
                                         HIva(sih.TipoIVA), _
                                         H(sih.Cliente.Codigo & " " & sih.Cliente.Nombre, 80), _
                                         "", _
                                         HDoc(sih.TipoDoc), _
                                         sih.Cliente.CUIT, _
                                         "N", _
                                         H(sih.DireccionFactura, 40), _
                                         "", _
                                         "", _
                                         sih.DocOrigen, _
                                         sih.CondicionPagoFactura.Descripcion, _
                                         "C")

            Case "LIA", "SCH"
                'Datos del cliente
                e = FiscalHasar.SetCustomerData(H(sih.Cliente.Codigo & " " & sih.Cliente.Nombre, 50), _
                                                sih.Cliente.CUIT, _
                                                HIva(sih.TipoIVA), _
                                                HDoc(sih.TipoDoc), _
                                                H(sih.DireccionFactura, 50))

                'Apertura del comprobante fiscal
                Select Case sih.TipoComprobante
                    Case "FAC", "DEB"
                        e = FiscalHasar.OpenFiscalReceipt(HTipo(sih.TipoComprobante, sih.LetraComprobante), _
                                                          "S")
                    Case "ABO"
                        e = FiscalHasar.SetEmbarkNumber("2", sih.DocOrigen)

                        e = FiscalHasar.OpenDNFH(HTipo(sih.TipoComprobante, sih.LetraComprobante), _
                                               "S", _
                                               sih.DocOrigen)
                End Select

        End Select

        Return e <> -1

    End Function
    Private Function AgregarItemFiscal(ByVal dr As DataRow, Optional ByVal Extra1 As String = "", Optional ByVal Extra2 As String = "", Optional ByVal Extra3 As String = "") As Boolean
        Dim Item As String
        Dim Pvp As Double
        Dim Qty As Double
        Dim e As Integer

        Select Case SociedadActual
            Case "GRU"
                Item = H(dr("itmref_0").ToString & " " & dr("itmdes1_0").ToString, 40)
                Pvp = CDbl(IIf(sih.LetraComprobante = "A", dr("netprinot_0"), dr("netpriati_0")))
                Qty = CDbl(dr("qty_0"))

                e = FiscalEpson.FACTITEM(Item, _
                                         Qty, _
                                         Pvp, _
                                         21, _
                                         "M", _
                                         1, _
                                         0, _
                                         H(Extra1, 40), _
                                         H(Extra2, 40), _
                                         H(Extra3, 40), _
                                         0, _
                                         0)

            Case "LIA", "SCH"
                Item = H(dr("itmref_0").ToString & " " & dr("itmdes1_0").ToString, 50)
                Pvp = CDbl(dr("netpriati_0"))
                Qty = CDbl(dr("qty_0"))
                'Se agrega informacion de la administracion
                If Extra1 <> "" Then FiscalHasar.PrintFiscalText(H(Extra1, 50), "0")
                If Extra2 <> "" Then FiscalHasar.PrintFiscalText(H(Extra2, 50), "0")
                If Extra3 <> "" Then FiscalHasar.PrintFiscalText(H(Extra3, 50), "0")
                'Se agrega linea al comprobante
                e = FiscalHasar.PrintLineItem(Item, Qty, Pvp, "21", "M", "0", "0", "S")

        End Select

        Return e <> -1

    End Function
    Private Function CerrarComprobanteFiscal() As Boolean
        Dim TipoComprobante As String = ""
        Dim e As Integer

        Select Case SociedadActual
            Case "GRU"
                Select Case sih.TipoComprobante
                    Case "FAC"
                        TipoComprobante = "F"
                    Case "DEB"
                        TipoComprobante = "D"
                    Case "ABO"
                        TipoComprobante = "N"
                End Select

                e = FiscalEpson.FACTCIERRA(TipoComprobante, sih.LetraComprobante, "FINAL")

            Case "LIA", "SCH"
                Select Case sih.TipoComprobante
                    Case "FAC", "DEB"
                        e = FiscalHasar.CloseFiscalReceipt("1")
                    Case "ABO"
                        e = FiscalHasar.CloseDNFH("1")
                End Select

        End Select

        Return e <> -1

    End Function
    Private Function CerrarPuertoFiscal() As Boolean
        Dim e As Integer

        Select Case SociedadActual
            Case "GRU"
                e = FiscalEpson.IF_CLOSE()

            Case "LIA", "SCH"
                e = FiscalHasar.IF_CLOSE()

        End Select

        Return e <> -1

    End Function
    Private Function CierreZFiscal() As Boolean
        Dim e As Integer

        AbrirPuertoFiscal()

        Select Case SociedadActual
            Case "GRU"
                e = FiscalEpson.CIERREZ()

            Case "LIA", "SCH"
                e = FiscalHasar.DailyClose("Z")

        End Select
        CerrarPuertoFiscal()

        Return e <> -1
    End Function
    Private Function CancelarComprobanteFiscal() As Boolean
        Dim e As Integer

        Select Case SociedadActual
            Case "GRU"
                e = FiscalEpson.FACTCANCEL()

            Case "LIA", "SCH"
                e = FiscalHasar.Cancel()

        End Select

        Return e <> -1
    End Function
    Private Sub ObtenerUltimosNumeradores()
        Select Case SociedadActual
            Case "GRU"
                FiscalEpson.ESTADO("A")
                txtFCA.Text = FiscalEpson.IF_READ(7)
                txtFCB.Text = FiscalEpson.IF_READ(5)
                txtNCA.Text = FiscalEpson.IF_READ(11)
                txtNCB.Text = FiscalEpson.IF_READ(12)

            Case "LIA", "SCH"
                FiscalHasar.StatusRequest()
                txtFCA.Text = FiscalHasar.IF_READ(5)
                txtFCB.Text = FiscalHasar.IF_READ(3)
                txtNCA.Text = FiscalHasar.IF_READ(8)
                txtNCB.Text = FiscalHasar.IF_READ(7)

        End Select

        Application.DoEvents()
        Application.DoEvents()

    End Sub
    Private Function ObtenerUltimoImpreso(ByVal TipoComprobante As String, ByVal Letra As String) As Long
        Dim i As Long = -1

        ObtenerUltimosNumeradores()

        Select Case TipoComprobante
            Case "FAC", "DEB"
                If Letra = "A" Then
                    i = CLng(txtFCA.Text)
                Else
                    i = CLng(txtFCB.Text)
                End If

            Case "ABO"
                If Letra = "A" Then
                    i = CLng(txtNCA.Text)
                Else
                    i = CLng(txtNCB.Text)
                End If

        End Select

        Return i

    End Function
    '-----------------------------------------------------------------------------------------
    ' HELPERS
    '-----------------------------------------------------------------------------------------
    Private Function H(ByVal Str As String, Optional ByVal Longitud As Integer = 0) As String
        Str = Str.ToUpper
        Str = Str.Replace("Á", "A")
        Str = Str.Replace("É", "E")
        Str = Str.Replace("Í", "I")
        Str = Str.Replace("Ó", "O")
        Str = Str.Replace("Ú", "U")
        Str = Str.Replace("Ñ", "N")
        Str = Str.Replace("'", "")
        Str = Str.Replace(Chr(186), "") 'º
        Str = Str.Replace(Chr(34), "") '"
        Str = Str.Replace("TOTAL", "Total")
        If Str.Length = 0 Then Str = Chr(127)
        If Longitud > 0 AndAlso Longitud < Str.Length Then
            Str = Str.Substring(0, Longitud)
        End If
        Return Str
    End Function
    Private Function HTipo(ByVal Tipo As String, Optional ByVal Letra As String = "") As String
        Dim Resp As String = ""

        Select Case SociedadActual
            Case "GRU"
                Select Case Tipo
                    Case "FAC"
                        Resp = "F"
                    Case "DEB"
                        Resp = "D"
                    Case "ABO"
                        Resp = "N"

                End Select

            Case "LIA", "SCH"
                Select Case Tipo
                    Case "FAC"
                        Resp = IIf(Letra = "A", "A", "B").ToString
                    Case "DEB"
                        Resp = IIf(Letra = "A", "D", "E").ToString
                    Case "ABO"
                        Resp = IIf(Letra = "A", "R", "S").ToString

                End Select
        End Select

        Return Resp

    End Function
    Private Function HIva(ByVal Tipo As String) As String
        Dim TipoIva As String = ""

        Select Case SociedadActual
            Case "GRU"
                Select Case Tipo
                    Case "RI", "RIL"
                        TipoIva = "I" 'Responsable Inscripto

                    Case "EX", "RIE", "EXP"
                        TipoIva = "E" 'Responsable Exento

                    Case "RM", "RMC"
                        TipoIva = "M" 'Responsable Monotributo

                    Case "CF"
                        TipoIva = "F" 'Consumidor Final

                End Select

            Case "LIA", "SCH"
                Select Case Tipo
                    Case "RI", "RIL"
                        TipoIva = "I" 'Responsable Inscripto

                    Case "EX", "RIE", "EXP"
                        TipoIva = "E" 'Responsable Exento

                    Case "RM", "RMC"
                        TipoIva = "M" 'Responsable Monotributo

                    Case "CF"
                        TipoIva = "C" 'Consumidor Final

                End Select
        End Select

        Return TipoIva

    End Function
    Private Function HDoc(ByVal Tipo As String) As String
        Dim TipoDocumento As String = ""

        Select Case SociedadActual
            Case "GRU"
                Select Case Tipo
                    Case "80"
                        TipoDocumento = "CUIT"
                    Case "86"
                        TipoDocumento = "CUIL"
                    Case "96"
                        TipoDocumento = "DNI"
                End Select

            Case "LIA", "SCH"

                Select Case Tipo
                    Case "80"
                        TipoDocumento = "C"
                    Case "86"
                        TipoDocumento = "L"
                    Case "96"
                        TipoDocumento = "2"
                End Select
        End Select

        Return TipoDocumento

    End Function

End Class