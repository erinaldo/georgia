Imports System.Data.OracleClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class frmPresupuestos639
    Const PORCENTAJE_1 As Double = 1.1
    Const PORCENTAJE_2 As Double = 1.2

    Private dt As New DataTable
    Private sqh As Presupuesto
    Private UsuarioAdmin As Boolean = False

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        'ComboBox Tipo
        Dim mnu As New MenuLocal(cn, 1, True)
        mnu.ModificarTexto(0, "Pendiente")
        mnu.ModificarTexto(1, "Enviado a supervisor")
        mnu.ModificarTexto(2, "Aprobado")
        mnu.Agregar("Quitado")
        mnu.Enlazar(colEstado)

        'mnu = New MenuLocal(cn, 1, True)
        'mnu.Enlazar(colFm200)
        'mnu = New MenuLocal(cn, 1, True)
        'mnu.Enlazar(colCo2)
        mnu = New MenuLocal(cn, 1, True)
        mnu.Enlazar(colDeteccion)

        CondicionPago.LlenarComboBox(cn, cboCondicionPago, True)

        UsuarioAdmin = usr.Permiso.AccesoSecundario(73, "V")

    End Sub

    Private Sub frmPresupuestos639_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AddHandler dgv.RowPostPaint, AddressOf NumeracionGrillas

        Buscar()

    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Buscar()
    End Sub
    Private Sub btnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizar.Click
        Actualizar()
    End Sub
    Private Sub btnAprobar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAprobar.Click
        Aprobar()
    End Sub
    Private Sub Buscar()
        Dim dt As New DataTable
        Dim sqh As New Presupuesto(cn)

        dt = TryCast(dgv.DataSource, DataTable)

        dt = sqh.PresupuestosPendientesAutorizacion(usr, dt)

        If dgv.DataSource Is Nothing Then
            colPresupuesto.DataPropertyName = "sqhnum_0"
            colFecha.DataPropertyName = "quodat_0"
            colCliente.DataPropertyName = "bpcord_0"
            colSucursal.DataPropertyName = "bpaadd_0"
            colNombre.DataPropertyName = "bpcnam_0"
            colDomicilio.DataPropertyName = "bpdaddlig_0"
            colVendedor.DataPropertyName = "rep_0"
            colImporte.DataPropertyName = "quoinvati_0"
            colEstado.DataPropertyName = "xaprob_0"
            colHidrantes.DataPropertyName = "xhidrante_0"
            'colFm200.DataPropertyName = "xfm200_0"
            'colCo2.DataPropertyName = "xco2_0"
            colDeteccion.DataPropertyName = "xdeteccion_0"
            colTipo.DataPropertyName = "xtiposist_0"

            Dim mnu As New MenuLocal(cn)
            mnu.AbrirMenu(1, False)
            mnu.Enlazar(col639)
            col639.DataPropertyName = "x415_0"

            mnu = New MenuLocal(cn)
            mnu.AbrirMenu(1, False)
            mnu.Enlazar(colRenovacion)
            colRenovacion.DataPropertyName = "xflgren_0"

            dgv.DataSource = sqh.PresupuestosPendientesAutorizacion(usr)

        End If

        sqh = Nothing

    End Sub
    Private Sub Actualizar()
        Dim i As Integer = 0

        If rbContado.Checked Then i = 1
        If rbOpcion1.Checked Then i = 2
        If rbOpcion2.Checked Then i = 3

        If txtPrecio.Text <> "" Then
            sqh.PrecioModificado = CDbl(txtPrecio.Text)
        End If

        sqh.OpcionPago = i
        sqh.Comentarios = txtObs.Text
        sqh.Grabar()

        CalculoPrecios()
        EstadoControles()
    End Sub
    Private Sub Aprobar()
        Dim txt As String = ""
        Dim i As Long
        Dim bpc As Cliente

        i = DateDiff(DateInterval.Day, sqh.Fecha, Date.Today)
        i = Math.Abs(i)

        Actualizar()

        bpc = sqh.Cliente

        If bpc.EsProspecto Then
            txt = "Debe convertir el prospecto a cliente para poder aprobar el presupuesto."
            MessageBox.Show(txt, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        If sqh.OpcionPago = 0 Then
            txt = "Falta seleccionar opción de pago"
            MessageBox.Show(txt, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        If sqh.PrecioModificado > 0 AndAlso sqh.PrecioModificado < sqh.TotalII Then
            txt &= "Percio menor al del presupuesto original" & vbCrLf

        End If

        If i > 30 Then
            txt &= "Presupuesto creado hace " & i.ToString & " días" & vbCrLf

        End If

        If rbContado.Checked Then
            Dim cp As New CondicionPago(cn)
            cp.EstablecerCodigo(cboCondicionPago.SelectedValue.ToString)

            If bpc.CondicionPago.Prioridad < cp.Prioridad Then
                txt &= "Condición de pago modificada es desfavorable" & vbCrLf
            End If

        End If

        If UsuarioAdmin And txt <> "" Then
            txt &= vbCrLf
            txt &= "¿Confirma la aprobación del presupuesto?"

            If MessageBox.Show(txt, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If

        ElseIf txt <> "" Then
            txt &= vbCrLf & vbCrLf
            txt &= "¿Quiere enviar el presupuesto a aprobar por un supervisor?"

            If MessageBox.Show(txt, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Dim dr As DataRow
                dr = CType(dgv.SelectedRows(0).DataBoundItem, DataRowView).Row
                dr.BeginEdit()
                dr("xaprob_0") = 1
                dr.EndEdit()

                sqh.EstadoAprobacion = 1
                sqh.Grabar()
                dt.AcceptChanges()

                MessageBox.Show("El presupuesto fue enviado", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            Exit Sub
        End If

        sqh.AprobarPresupuesto(usr)
        sqh.Grabar()
        EstadoControles()

        If DB_USR = "GEOPROD" Then EnviarMail()

    End Sub


    Private Sub dgv_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv.SelectionChanged
        Dim dr As DataRow

        If dgv.SelectedRows.Count > 0 Then
            If sqh Is Nothing Then sqh = New Presupuesto(cn)
            dr = CType(dgv.SelectedRows(0).DataBoundItem, DataRowView).Row
            sqh.Abrir(dr("sqhnum_0").ToString)
            txtObs.Text = ""
            CargarDatos()

        End If
    End Sub
    Private Sub CargarDatos()

        gbPago.Text = sqh.Numero
        txtPrecio.Text = sqh.PrecioModificado.ToString

        CalculoPrecios()

        rbContado.Checked = CBool(IIf(sqh.OpcionPago = 1, True, False))
        rbOpcion1.Checked = CBool(IIf(sqh.OpcionPago = 2, True, False))
        rbOpcion2.Checked = CBool(IIf(sqh.OpcionPago = 3, True, False))

        cboCondicionPago.SelectedValue = sqh.Cliente.CondicionDePago

        CalcularDescuento()
        EstadoControles()

    End Sub
    Private Sub CalcularDescuento()
        Dim i As Double = 0

        If sqh.PrecioModificado > 0 AndAlso sqh.PrecioModificado < sqh.TotalII Then
            i = 100 - (sqh.PrecioModificado / sqh.TotalII * 100)
        End If

        If i <> 0 Then
            txtDescuento.Text = i.ToString("N2") & "%"
        Else
            txtDescuento.Clear()
        End If
    End Sub
    Private Sub CalculoPrecios()
        Dim Anticipo As Double
        Dim Cuota As Integer
        Dim ValorCuota As Double
        Dim Total As Double
        Dim txt As String = "{cuotas} cuotas de {valor_cuota} = {total}"
        Dim base As Double

        base = sqh.PrecioAprobacion

        'Precio contado
        rbContado.Text = "Precio contado " & base.ToString("N2")

        'Opcion 1
        Total = base * PORCENTAJE_1
        'Anticipo = Total * 0.17
        Cuota = 6
        ValorCuota = Total / Cuota '* 0.166

        With rbOpcion1
            .Text = txt
            .Text = .Text.Replace("{anticipo}", Anticipo.ToString("N2"))
            .Text = .Text.Replace("{cuotas}", Cuota.ToString)
            .Text = .Text.Replace("{valor_cuota}", ValorCuota.ToString("N2"))
            .Text = .Text.Replace("{total}", Total.ToString("N2"))
        End With

        'Opcion 2
        Total = base * PORCENTAJE_2
        'Anticipo = Total / 12
        Cuota = 12
        ValorCuota = Total / Cuota

        With rbOpcion2
            .Text = txt
            '.Text = .Text.Replace("{anticipo}", Anticipo.ToString("N2"))
            .Text = .Text.Replace("{cuotas}", Cuota.ToString)
            .Text = .Text.Replace("{valor_cuota}", ValorCuota.ToString("N2"))
            .Text = .Text.Replace("{total}", Total.ToString("N2"))
        End With

        CalcularDescuento()

    End Sub
    Private Sub txtPrecio_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtPrecio.Validating
        e.Cancel = Not IsNumeric(txtPrecio.Text)
    End Sub
    Private Sub EstadoControles()
        gbPago.Enabled = Not sqh.Aprobado
        btnAprobar.Enabled = Not sqh.Aprobado

        cboCondicionPago.Enabled = rbContado.Checked

    End Sub
    Private Sub ResetControles()
        gbPago.Text = ""
        txtPrecio.Clear()
        rbContado.Checked = False
        rbOpcion1.Checked = False
        rbOpcion2.Checked = False
        txtObs.Text = ""
    End Sub
    Private Sub EnviarMail()
        Dim oMail As New CorreoElectronico
        Dim bpc As Cliente
        Dim bpa As Sucursal
        Dim rep As Vendedor
        Dim Pago As String = ""
        Dim Sql As String = ""
        Dim da As OracleDataAdapter
        Dim dt As New DataTable
        Dim Parque As String = ""
        bpc = sqh.Cliente
        bpa = bpc.Sucursal(sqh.SucursalCodigo)
        rep = bpc.Vendedor

        '2018.05.29 Consulto vto F1 y E2 del cliente/sucursal
        Sql = "select mac.macnum_0, yit.cpnitmref_0, itm.itmdes1_0, mac.macqty_0,yit.datnext_0, mac.bpcnum_0, mac.fcyitn_0  "
        Sql &= "from machines mac inner join "
        Sql &= "	 ymacitm yit on (mac.macnum_0 = yit.macnum_0) inner join "
        Sql &= "	 bomd bmd on (mac.macpdtcod_0 = bmd.itmref_0 AND yit.cpnitmref_0 = bmd.cpnitmref_0 AND bomalt_0 = 99 AND bomseq_0 = 10) inner join "
        Sql &= "	 itmmaster itm on (bmd.cpnitmref_0 = itm.itmref_0) "
        Sql &= "where (yit.cpnitmref_0 in ('501019','551000','551001','551002','551021','551022','551032','551034','551035','551036','551037','551059','551061','551065','551066','551067','551075','551076','659012') or "
        Sql &= "	  yit.cpnitmref_0 like '504%' or "
        Sql &= "	  yit.cpnitmref_0 like '505%' or "
        Sql &= "	  yit.cpnitmref_0 like '50301%') and "
        Sql &= "	  macitntyp_0 = 1 and "
        Sql &= "	  mac.bpcnum_0 = :bpcnum and "
        Sql &= "	  mac.fcyitn_0 = :fcyitn "
        Sql &= "order by datnext_0 "
        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("bpcnum", OracleType.VarChar).Value = bpa.Codigo
        da.SelectCommand.Parameters.Add("fcyitn", OracleType.VarChar).Value = bpa.Sucursal
        da.Fill(dt)

        For Each dr As DataRow In dt.Rows
            Parque &= "<li>"
            Parque &= dr("macqty_0").ToString & " "
            Parque &= dr("cpnitmref_0").ToString & " "
            Parque &= dr("itmdes1_0").ToString & " "
            Parque &= CDate(dr("datnext_0")).ToString("dd/MM/yyyy")
            Parque &= "</li>"
        Next
        If Parque = "" Then Parque = "<li>No se encontraron vencimientos</li>"

        With oMail
            .EsHtml = True
            .Remitente(usr.Mail, usr.Nombre)

            .AgregarDestinatario(rep.Analista.Mail)
            .AgregarDestinatarioCopia(rep.Mail)

            .Asunto = "Presupuesto 639 aprobado - " & sqh.Numero
            .CuerpoDesdeArchivo("mails\639.htm")

            .Cuerpo = .Cuerpo.Replace("{numero}", sqh.Numero)
            .Cuerpo = .Cuerpo.Replace("{numero_cliente}", bpc.Codigo)
            .Cuerpo = .Cuerpo.Replace("{nombre_cliente}", bpc.Nombre)
            .Cuerpo = .Cuerpo.Replace("{numero_sucursal}", bpa.Sucursal)
            .Cuerpo = .Cuerpo.Replace("{domicilio}", bpa.Direccion)
            .Cuerpo = .Cuerpo.Replace("{vendedor}", bpc.Vendedor1Codigo)
            .Cuerpo = .Cuerpo.Replace("{sistema}", sqh.TipoSistema.ToString)
            .Cuerpo = .Cuerpo.Replace("{obs}", txtObs.Text.ToString)
            .Cuerpo = .Cuerpo.Replace("{parque}", Parque)

            If sqh.Renovacion Then
                .Cuerpo = .Cuerpo.Replace("{renovacion}", "[RENOVACIÓN]")
            Else
                .Cuerpo = .Cuerpo.Replace("{renovacion}", "")
            End If

            .Cuerpo = .Cuerpo.Replace("{hidrantes}", IIf(sqh.Deteccion, "-", bpa.Hidrantes).ToString)

            .Cuerpo = .Cuerpo.Replace("{agua}", IIf(sqh.Agua, "Sí", "No").ToString)
            .Cuerpo = .Cuerpo.Replace("{deteccion}", IIf(sqh.Deteccion, "Sí", "No").ToString)
            .Cuerpo = .Cuerpo.Replace("{codet}", sqh.tipodeteccion)

            If rbContado.Checked Then Pago = rbContado.Text
            If rbOpcion1.Checked Then Pago = rbOpcion1.Text
            If rbOpcion2.Checked Then Pago = rbOpcion2.Text

            .Cuerpo = .Cuerpo.Replace("{importe}", Pago)
            .Cuerpo = .Cuerpo.Replace("{condicion_pago}", cboCondicionPago.SelectedValue.ToString)

            .Enviar()

        End With
    End Sub
    Private Sub VerPresupuesto()
        Dim rpt As New ReportDocument
        Dim f As frmCrystal

        'Genero el PDF con la cotizacion
        If sqh.Deteccion Then
            rpt.Load(RPTX3 & "X639DETEC.rpt")
        Else
            rpt.Load(RPTX3 & "X639.rpt")
            rpt.SetParameterValue("ocultar", 1)
        End If

        rpt.SetDatabaseLogon(DB_USR, DB_PWD)
        rpt.SetParameterValue("sqh", sqh.Numero)

        f = New frmCrystal(rpt)
        f.MdiParent = Me.ParentForm
        f.Show()
    End Sub
    Private Sub cm_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cm.Opening
        e.Cancel = (dgv.SelectedRows.Count = 0)
    End Sub
    Private Sub mnuVerPresupuesto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuVerPresupuesto.Click

        VerPresupuesto()

    End Sub
    Private Sub munQuitar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim flg As Boolean
        Dim txt As String
        Dim n As String
        Dim dr As DataRow

        txt = "¿Confirma quitar este presupuesto de la lista?" & vbCrLf

        flg = MessageBox.Show(txt, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes

        If flg Then
            dr = CType(dgv.SelectedRows(0).DataBoundItem, DataRowView).Row
            n = dr("sqhnum_0").ToString

            sqh.Abrir(n)
            sqh.EstadoAprobacion = 3
            sqh.Grabar()
            Buscar()
        End If

    End Sub
    Private Sub rbContado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbContado.CheckedChanged
        cboCondicionPago.Enabled = rbContado.Checked

        If Not rbContado.Checked Then
            cboCondicionPago.SelectedValue = sqh.Cliente.CondicionDePago
        End If

    End Sub

    Private Sub mnuQuitar1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuQuitar1.Click
        Quitar(1)
    End Sub
    Private Sub mnuQuitar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuQuitar2.Click
        Quitar(2)
    End Sub
    Private Sub mnuQuitar3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuQuitar3.Click
        Quitar(3)
    End Sub
    Private Sub mnuQuitar4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuQuitar4.Click
        Quitar(4)
    End Sub
    Private Sub Quitar(ByVal Op As Integer)
        Dim flg As Boolean
        Dim txt As String
        Dim n As String
        Dim dr As DataRow

        txt = "¿Confirma quitar este presupuesto de la lista?" & vbCrLf

        flg = MessageBox.Show(txt, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes

        If flg Then
            dr = CType(dgv.SelectedRows(0).DataBoundItem, DataRowView).Row
            n = dr("sqhnum_0").ToString

            sqh.Abrir(n)
            sqh.EstadoAprobacion = 3
            sqh.MotivoPerdida = Op
            sqh.Grabar()

            Try
                EnviarMailEliminacion(sqh)
            Catch ex As Exception
            End Try

            Buscar()
        End If

    End Sub
    Private Sub EnviarMailEliminacion(ByVal Sqh As Presupuesto)
        Dim eMail As New CorreoElectronico
        Dim txt As String
        Dim bpc As Cliente

        bpc = Sqh.Cliente

        txt = "El cliente {CLI}-{SUC} {NOMBRE} NO RENUEVA" & vbCrLf
        txt = txt.Replace("{CLI}", bpc.Codigo)
        txt = txt.Replace("{SUC}", Sqh.SucursalCodigo)
        txt = txt.Replace("{NOMBRE}", bpc.Nombre)

        With eMail
            .Nuevo()
            .Asunto = "Presupuesto " & Sqh.Numero & " eliminado"
            .Cuerpo = txt
            .EsHtml = False
            .Remitente(usr.Mail, usr.Nombre)
            .AgregarDestinatarioArchivo(PATH_MAIL & "639eliminado.txt")
            .Enviar()
        End With

    End Sub

End Class