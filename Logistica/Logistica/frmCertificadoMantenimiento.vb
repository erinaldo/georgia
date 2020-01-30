Imports CrystalDecisions.CrystalReports.Engine

Public Class frmCertificadoMantenimiento
    Private Const ARCHIVO_ORIGEN As String = "XCERTIFICADO.rpt"
    Private Const ARCHIVO_ORIGENrto As String = "XCERTIFICADOrto.rpt"
    Private rto As Remito
    Private itn As Intervencion

    Public Sub New(ByVal nro As Object)
        InitializeComponent()
        'Me.itn = itn

        If TypeOf nro Is Remito Then
            Me.rto = CType(nro, Remito)

        Else
            Me.itn = CType(nro, Intervencion)

        End If
    End Sub
    Private Sub frmCertificadoMantenimiento_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If rto Is Nothing Then
            txtBpc.Text = itn.Cliente.Codigo
            txtCliente.Text = itn.Cliente.Nombre
            txtBpa.Text = itn.SucursalCodigo
            txtDomicilio.Text = itn.SucursalCalle
            txtItn.Text = itn.Numero
        Else
            txtBpc.Text = rto.Cliente.Codigo
            txtCliente.Text = rto.Cliente.Nombre
            txtBpa.Text = rto.SucursalCodigo
            txtDomicilio.Text = rto.SucursalCalle
            txtItn.Text = rto.Numero
        End If
    End Sub
    Private Sub btnOperativo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOperativo.Click
        EnviarMail(1)
        Me.Close()
    End Sub
    Private Sub btnDefectuoso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDefectuoso.Click
        EnviarMail(2)
        Me.Close()
    End Sub
    Private Sub btnInoperativo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInoperativo.Click
        EnviarMail(3)
        Me.Close()
    End Sub
    Private Sub EnviarMail(ByVal Estado As Integer)
        If DB_USR <> "GEOPROD" Then Exit Sub

        Dim eml As New CorreoElectronico
        Dim rep As Vendedor
        Dim bpc As Cliente

        If rto Is Nothing Then
            rep = itn.Cliente.Vendedor
            bpc = itn.Cliente
            itn.CertificadoEstado = Estado
            itn.Grabar()
        Else
            rep = rto.Cliente.Vendedor
            bpc = rto.Cliente
            rto.CertificadoEstado = Estado
            rto.Grabar()
        End If
        
        Dim txt As String = ""

        Panel1.Visible = False
        Application.DoEvents()
        Application.DoEvents()
        Application.DoEvents()

        eml.Nuevo()
        eml.Remitente("no-responder@georgia.com.ar", "Sistema Automático")
        eml.Asunto = "Mantenimiento de Sistema Fijo"
        eml.AgregarDestinatario(rep.Mail)

        If rto Is Nothing Then
            txt = "INTERVENCION: {itn}" & vbCrLf
        Else
            txt = "REMITO: {itn}" & vbCrLf
        End If

        txt &= "CLIENTE: {bpcnum} {bpcnam}" & vbCrLf
        txt &= "SUCURSAL: {bpaadd} {bpaaddlig}" & vbCrLf & vbCrLf

        If rto Is Nothing Then
            txt = txt.Replace("{itn}", itn.Numero)
        Else
            txt = txt.Replace("{itn}", rto.Numero)
        End If

        txt = txt.Replace("{bpcnum}", bpc.Codigo)
        txt = txt.Replace("{bpcnam}", bpc.Nombre)
        If rto Is Nothing Then
            txt = txt.Replace("{bpaadd}", itn.SucursalCodigo)
            txt = txt.Replace("{bpaaddlig}", itn.SucursalCalle)
        Else
            txt = txt.Replace("{bpaadd}", rto.SucursalCodigo)
            txt = txt.Replace("{bpaaddlig}", rto.SucursalCalle)

        End If
        If rto Is Nothing Then
            Select Case itn.CertificadoEstado
                Case 1
                    txt &= "El sistema de este cliente se encuentra OPERATIVO. Se adjunta certificado."
                    GenerarCertificado()
                    eml.AdjuntarArchivo(itn.Numero & ".pdf")

                Case Else
                    txt &= "El sistema de este cliente se encuentra DEFECTUOSO o INOPERATIVO." & vbCrLf & vbCrLf
                    txt &= "CONSULTAR CON INGENIERIA"

            End Select
        Else

            Select Case rto.CertificadoEstado

                Case 1
                    txt &= "El sistema de este cliente se encuentra OPERATIVO. Se adjunta certificado."
                    GenerarCertificado()
                    eml.AdjuntarArchivo(rto.Numero & ".pdf")

                Case Else
                    txt &= "El sistema de este cliente se encuentra DEFECTUOSO o INOPERATIVO." & vbCrLf & vbCrLf
                    txt &= "CONSULTAR CON INGENIERIA"

            End Select
        End If


        eml.Cuerpo = txt
        eml.Enviar()

    End Sub
    Private Sub GenerarCertificado()
        Dim rpt As New ReportDocument
        Dim t As String
        Try
            If rto Is Nothing Then
                rpt.Load(RPTX3 & "" & ARCHIVO_ORIGEN) 'Reporte con margen
                rpt.SetDatabaseLogon(DB_USR, "tiger")
                rpt.SetParameterValue("ITN", itn.Numero)
                rpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, itn.Numero & ".pdf")
            Else
                rpt.Load(RPTX3 & "" & ARCHIVO_ORIGENrto) 'Reporte con margen
                rpt.SetDatabaseLogon(DB_USR, "tiger")
                rpt.SetParameterValue("RTO", rto.Numero)
                rpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, rto.Numero & ".pdf")
            End If
            
        Catch ex As Exception
            t = ex.Message

        End Try

        rpt.Dispose()

    End Sub

End Class