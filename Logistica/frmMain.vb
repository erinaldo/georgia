Imports System.Globalization
Imports System.Data.OracleClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class frmMain

    'SUBS
    Private Sub MostrarLogin()

        Dim f As New frmLogin

        f.ShowDialog(Me)

        If f.DialogResult = Windows.Forms.DialogResult.OK Then

            sbDosier.Text = DB_USR
            sbNombre.Text = usr.Nombre
            sbUser.Text = usr.Codigo

            'Aqui ver activacion de menues
            usr.ObtenerPermisos(dtPermisos)

            ActivarMenues()

        Else
            Me.Close()

        End If

    End Sub
    Private Sub ActivarMenues()
        Dim dv As New DataView(dtPermisos)

        'Recorro menú en barra de menu
        For Each mnu As ToolStripMenuItem In MenuStrip1.Items
            ActivarMenuesSub(mnu, dv)
        Next

        dv.Dispose()

    End Sub
    Private Sub ActivarMenuesSub(ByVal menu As ToolStripMenuItem, ByVal dv As DataView)
        Dim item As ToolStripItem
        Dim mnu As ToolStripMenuItem

        'Recorro los submenues
        For Each item In menu.DropDownItems

            If item.GetType() Is GetType(ToolStripMenuItem) Then
                mnu = DirectCast(item, ToolStripMenuItem)

                If mnu.Tag IsNot Nothing Then

                    Select Case mnu.Tag.ToString
                        Case "LOGIN"
                            mnu.Enabled = (sbUser.Text <> "")

                        Case "LOGOUT"
                            mnu.Enabled = Not (sbUser.Text <> "")

                        Case Else
                            If (sbUser.Text <> "") Then
                                dv.RowFilter = String.Format("fnc_0 = '{0}' AND padre_0 = 0", item.Tag)
                                mnu.Enabled = (dv.Count > 0)

                            Else
                                mnu.Enabled = False

                            End If

                    End Select

                End If

                'Proceso los submenu de este item
                If mnu.DropDownItems.Count > 0 Then ActivarMenuesSub(mnu, dv)

            End If

        Next
    End Sub
    Private Sub CerrarVentanas()
        Dim f As Form

        For Each f In Me.MdiChildren
            f.Close()
        Next

    End Sub

    'FUNCTION
    Private Function Resolucion() As Boolean
        Dim w As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim h As Integer = Screen.PrimaryScreen.Bounds.Height
        Dim t As String = ""

        If w < 1024 Or h < 768 Then
            t = "Esta aplicación necesita una resolución de pantalla mínima de 1024x768" & vbCrLf & vbCrLf
            t &= "La resolución actual es " & w.ToString & "x" & h.ToString

            MessageBox.Show(t, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End
        End If

    End Function

    Private Sub frmMain_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If cn.State = ConnectionState.Open Then cn.Close()
    End Sub

    'EVENTOS
    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            cn.Open()

            Resolucion()

            Dim ci As CultureInfo = CType(Application.CurrentCulture.Clone, CultureInfo)

            With ci.NumberFormat
                .CurrencyDecimalSeparator = "."
                .CurrencyGroupSeparator = ","
                .NumberDecimalSeparator = "."
                .NumberGroupSeparator = ","
            End With

            Application.CurrentCulture = ci

            ActivarMenues()
            MostrarLogin()

        Catch ex As Exception
            MessageBox.Show("Error de base de datos", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End

        End Try

    End Sub

#Region "Menu: Menu"
    Private Sub mnuIniciarSesion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuIniciarSesion.Click
        MostrarLogin()
    End Sub
    Private Sub mnuCerrarSesion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCerrarSesion.Click
        CerrarVentanas()

        'Sesion.Logout()
        MostrarLogin()

    End Sub
    Private Sub mnuABMUsuarios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuABMUsuarios.Click
        Dim f As New frmUsuarios

        f.MdiParent = Me
        f.Show()
    End Sub
    Private Sub mnuABMFunciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuABMFunciones.Click
        Dim f As New frmFunciones

        f.MdiParent = Me
        f.Show()
    End Sub
    Private Sub mnuPermisos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPermisos.Click
        Dim f As New frmPermisos

        f.MdiParent = Me
        f.Show()
    End Sub
    Private Sub mnuClave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuClave.Click
        Dim f As New frmClave
        f.ShowDialog(Me)

        If f.DialogResult = Windows.Forms.DialogResult.OK Then
            MessageBox.Show("La contraseña fue guardada", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        f.Dispose() : f = Nothing
    End Sub
    Private Sub mnuSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSalir.Click
        Me.Close()
    End Sub
#End Region
#Region "Menu: Logistica"
    Private Sub mnuNuevaHojaRuta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNuevaHojaRuta.Click
        Dim f As New frmRuta

        f.MdiParent = Me
        f.Show()
    End Sub
    Private Sub mnuValidarRuta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuValidarRuta.Click
        Dim f As New frmValidar

        f.MdiParent = Me
        f.Show()
    End Sub
    Private Sub mnuResolver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuResolver.Click
        Dim f As New frmResolver

        f.MdiParent = Me
        f.Show()
    End Sub
    Private Sub mnuRelevamientosV2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRelevamientosV2.Click
        Dim f As New frmInspecciones

        f.MdiParent = Me
        f.Show()
    End Sub
    Private Sub mnuPrestamos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPrestamos.Click
        With frmPrestamos
            .MdiParent = Me
            .Show()
        End With
    End Sub
#End Region
#Region "Menu: Service"
    Private Sub mnuVencimientos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuVencimientos.Click
        Dim f As New frmVencimientos

        f.MdiParent = Me
        f.Show()
    End Sub
    Private Sub mnuDestribucionVenc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDestribucionVenc.Click
        Dim Cliente As String
        Dim Sucursal As String
        Dim cm1 As New OracleCommand("SELECT * FROM bpcustomer WHERE bpcnum_0 = :bpcnum_0", cn)
        Dim cm2 As New OracleCommand("SELECT * FROM xnetvenc WHERE usr_0 = :usr_0 AND rep_0 = :rep_0", cn)
        Dim dr As OracleDataReader

        cm1.Parameters.Add("bpcnum_0", OracleType.VarChar)
        cm2.Parameters.Add("usr_0", OracleType.VarChar)
        cm2.Parameters.Add("rep_0", OracleType.VarChar)

        'Valido que el cliente pueda ser consultado por el usuario actual
        Cliente = InputBox("Codigo de cliente", Me.Text)

        'Consulto vendedor del cliente
        cm1.Parameters("bpcnum_0").Value = Cliente
        dr = cm1.ExecuteReader

        If dr.Read Then
            cm2.Parameters("usr_0").Value = usr.Codigo
            cm2.Parameters("rep_0").Value = dr("rep_0").ToString
            dr.Close()
            dr = cm2.ExecuteReader

            If dr.Read Then
                If CInt(dr("abo_0")) = 1 OrElse CInt(dr("noabo_0")) = 1 Then

                    Sucursal = InputBox("Sucursal del cliente " & Cliente, Me.Text)
                    If Sucursal.Trim <> "" Then rptDistribucionVencimientos(Cliente, Sucursal)

                Else
                    MessageBox.Show("No dispone de permisos para consultar este cliente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                End If

            Else
                MessageBox.Show("No dispone de permisos para consultar este cliente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            End If


        Else
            'No se encontró el cliente
            If Cliente.Trim <> "" Then
                MessageBox.Show("No se encontró el cliente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

        End If

        dr.Close()
        cm1.Dispose()
        cm2.Dispose()

    End Sub
    Private Sub frm415_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim f As New frm415
        f.MdiParent = Me
        f.Show()
    End Sub
    Private Sub mnu11sinCP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu11sinCP.Click
        Dim f As New frm11sinCP

        f.MdiParent = Me
        f.Show()
    End Sub
    Private Sub mnuTranferencia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTranferencia.Click
        Dim f As New frmTransferencia

        f.MdiParent = Me
        f.Show()
    End Sub
    Private Sub mnuIRAM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuIRAM.Click
        Dim f As New frmIRAM
        f.MdiParent = Me
        f.Show()
    End Sub
    Private Sub mnuIRAM2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuIRAM2.Click
        Dim f As New frmIRAM2
        f.MdiParent = Me
        f.Show()
    End Sub
    Private Sub mnuSustitutos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSustitutos.Click
        Dim f As New frmSustitutos
        f.MdiParent = Me
        f.Show()
    End Sub
    Private Sub mnuParqueAbono_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuParqueAbono.Click
        Dim f As New frmParqueAbonos

        f.MdiParent = Me
        f.Show()

    End Sub
    Private Sub mnuSectoresPuestos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSectoresPuestos.Click
        Dim f As New frmSectoresPuestos

        f.MdiParent = Me
        f.Show()

    End Sub
    Private Sub mnuRecepcion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRecepcion.Click
        With frmRecepcion
            .MdiParent = Me
            .Show()
        End With
    End Sub
    Private Sub mnuCfgVencimientos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCfgVencimientos.Click
        Dim f As New frmCfgSrvVencimientos

        f.ShowInTaskbar = False
        f.ShowDialog()
        f.Dispose()
    End Sub
    Private Sub mnuCfgIram_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCfgIram.Click
        Dim f As New frmCfgSrvIram

        f.ShowInTaskbar = False
        f.ShowDialog()
        f.Dispose()
    End Sub
    Private Sub mnuCheques_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCheques.Click
        Dim f As New frmCheques

        f.MdiParent = Me
        f.Show()
    End Sub
    Private Sub mnuCilindrosDuplicados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCilindrosDuplicados.Click
        Dim f As New frmCilindrosDuplicados

        f.MdiParent = Me
        f.Show()
    End Sub
#End Region
#Region "Menu: Contabilidad"
    Private Sub mnuBuscadorCheques_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuBuscadorCheques.Click
        Dim f As New frmBuscadorCheques

        f.MdiParent = Me
        f.Show()
    End Sub
    Private Sub PresupuestoToolStripMenuItem1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PresupuestoToolStripMenuItem1.Click
        Dim f As New FrmPresupu 'estoAnual
        f.MdiParent = Me
        f.Show()
    End Sub
    Private Sub PToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PToolStripMenuItem.Click
        Dim f As New FrmPresuVentas
        f.MdiParent = Me
        f.Show()
    End Sub
    Private Sub PresupuestoDetalleToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim F As New FrmListado
        F.MdiParent = Me
        F.Show()
    End Sub
    Private Sub DetalleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DetalleToolStripMenuItem.Click
        Dim f As New FrmListadoPesos
        f.MdiParent = Me
        f.Show()
    End Sub
#End Region
#Region "Menu: Varios"
    Private Sub mnuBuscaCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Application.DoEvents()

        Dim f As New frmBuscaClientes

        f.MdiParent = Me
        f.Show()
    End Sub
    Private Sub mnuFactElec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFactElec.Click
        Application.DoEvents()

        Dim f As New frmfacturas2

        f.MdiParent = Me
        f.Show()
    End Sub
    Private Sub mnuAdministraciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAdministraciones.Click
        Application.DoEvents()

        Dim f As New frmSaldos

        f.MdiParent = Me
        f.Show()
    End Sub
    Private Sub frmCAE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles frmCAE.Click
        Dim f As New frmCAE

        With f
            .Visible = False
            .MdiParent = Me
            .Show()
        End With
    End Sub
    Private Sub mnuCorreo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCorreo.Click
        Dim f As New frmCorreo

        With f
            .Visible = False
            .MdiParent = Me
            .Show()
        End With
    End Sub
#End Region
#Region "Menu: Informes"
    Private Sub mnuRptVtas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRptVtas.Click
        With frmRptVtas
            .MdiParent = Me
            .Show()
            If .WindowState = FormWindowState.Minimized Then .WindowState = FormWindowState.Normal
            .BringToFront()
        End With
    End Sub
    Private Sub mnuRptVtasA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRptVtasA.Click
        With frmRptVtasA
            .MdiParent = Me
            .Show()
            If .WindowState = FormWindowState.Minimized Then .WindowState = FormWindowState.Normal
            .BringToFront()
        End With
    End Sub
    Private Sub mnuRptSat1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRptSat1.Click
        With frmSat1
            .MdiParent = Me
            .Show()
            If .WindowState = FormWindowState.Minimized Then .WindowState = FormWindowState.Normal
            .BringToFront()
        End With
    End Sub
    Private Sub ReporteDeVentasPorProvinciasAnualToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReporteDeVentasPorProvinciasAnualToolStripMenuItem.Click
        With frmRptSat1A
            .MdiParent = Me
            .Show()
            If .WindowState = FormWindowState.Minimized Then .WindowState = FormWindowState.Normal
            .BringToFront()
        End With
    End Sub
    Private Sub mnuRptTipo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRptTipo.Click
        With frmRptVtasTipo
            .MdiParent = Me
            .Show()
            If .WindowState = FormWindowState.Minimized Then .WindowState = FormWindowState.Normal
            .BringToFront()
        End With
    End Sub
    Private Sub ReporteDeVentasPorTipoClientesAnualToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReporteDeVentasPorTipoClientesAnualToolStripMenuItem.Click
        With frmRptVtasTipoA
            .MdiParent = Me
            .Show()
            If .WindowState = FormWindowState.Minimized Then .WindowState = FormWindowState.Normal
            .BringToFront()
        End With
    End Sub
    Private Sub mnuRptRecargas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRptRecargas.Click
        Application.DoEvents()
        Me.UseWaitCursor = True

        With frmRptRecargas
            .MdiParent = Me
            .Show()
            .BringToFront()
        End With

        Me.UseWaitCursor = False
    End Sub
    Private Sub mnuDistribuidoresInactivos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDistribuidoresInactivos.Click
        Application.DoEvents()
        Me.UseWaitCursor = True

        With frmDistribuidoresInactivos
            .MdiParent = Me
            .Show()
            .BringToFront()
        End With

        Me.UseWaitCursor = False
    End Sub
    Private Sub mnuHoras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuHoras.Click
        With frmHoras
            .MdiParent = Me
            .Show()
            If .WindowState = FormWindowState.Minimized Then .WindowState = FormWindowState.Normal
            .BringToFront()
        End With
    End Sub
#End Region
#Region "Menu: Ventana"
    Private Sub mnuCascada_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCascada.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub
    Private Sub mnuMosaicoH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMosaicoH.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub
    Private Sub mnuMosaicoV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMosaicoV.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub
    Private Sub mnuCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCerrar.Click
        CerrarVentanas()
    End Sub
#End Region
#Region "Menu: Documentacion"
    Private Sub mnuSeguimientoSrv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSeguimientoSrv.Click
        Dim f As New frmSeguimiento("SRV")

        With f
            .Visible = False
            .MdiParent = Me
            .Show()
        End With
    End Sub
    Private Sub mnuSeguimientoAdm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSeguimientoAdm.Click
        Dim f As New frmSeguimiento("ADM")

        With f
            .Visible = False
            .MdiParent = Me
            .Show()
        End With
    End Sub
    Private Sub mnuSeguimientoLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSeguimientoLog.Click
        Dim f As New frmSeguimiento("LOG")

        With f
            .Visible = False
            .MdiParent = Me
            .Show()
        End With
    End Sub
    Private Sub mnuSeguimientoCtd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSeguimientoCtd.Click
        Dim f As New frmSeguimiento("CTD")

        With f
            .Visible = False
            .MdiParent = Me
            .Show()
        End With
    End Sub
    Private Sub mnuSeguimientoIng_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSeguimientoIng.Click
        Dim f As New frmSeguimiento("ING")

        With f
            .Visible = False
            .MdiParent = Me
            .Show()
        End With
    End Sub
    Private Sub mnuSeguimientoAch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSeguimientoAch.Click
        Dim f As New frmSeguimiento("ACH")

        With f
            .Visible = False
            .MdiParent = Me
            .Show()
        End With
    End Sub
    Private Sub mnuSeguimientoMos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSeguimientoMos.Click
        Dim f As New frmSeguimiento("MOS")

        With f
            .Visible = False
            .MdiParent = Me
            .Show()
        End With
    End Sub
    Private Sub mnuSeguimientoDep_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSeguimientoDep.Click
        Dim f As New frmSeguimiento("DEP")

        With f
            .Visible = False
            .MdiParent = Me
            .Show()
        End With
    End Sub
    Private Sub mnuSeguimientoCal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSeguimientoCal.Click
        Dim f As New frmSeguimiento("CAL")

        With f
            .Visible = False
            .MdiParent = Me
            .Show()
        End With
    End Sub
    Private Sub AbonosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AbonosToolStripMenuItem.Click
        Dim f As New frmSeguimiento("ABO")

        With f
            .Visible = False
            .MdiParent = Me
            .Show()
        End With
    End Sub
    Private Sub VentasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VentasToolStripMenuItem.Click
        Dim f As New frmSeguimiento("VEN")

        With f
            .Visible = False
            .MdiParent = Me
            .Show()
        End With
    End Sub
    Private Sub frmEntregas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEntregas.Click
        With frmEntregas
            .MdiParent = Me
            .Show()
        End With
    End Sub
    Private Sub mnuSinDespachar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSinDespachar.Click
        With frmSinDespacho
            .MdiParent = Me
            .Show()
        End With
    End Sub

#End Region
#Region "Menu: Ventas"
    Private Sub mnuEstadoClientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEstadoClientes.Click
        Dim f As New frmVentas1

        f.MdiParent = Me
        f.Show()

    End Sub
    Private Sub mnuPrecios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPrecios.Click
        Dim f As New frmPrecios

        f.MdiParent = Me
        f.Show()
    End Sub
    Private Sub mnuTarjetasNuevos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTarjetasNuevos.Click
        Dim f As New frmTarjetasNuevo

        f.MdiParent = Me
        f.Show()
    End Sub
    Private Sub mnuMotors_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMotors.Click

        frmMotors.Show()

    End Sub
#End Region
    Private Sub mnuTablero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCumpliRecargas.Click
        Dim f As New frmCumplimientoRecargas

        f.MdiParent = Me
        f.Show()
    End Sub
    Private Sub mnuMostrador_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMostrador.Click
        Dim f As New frmMostrador()

        f.MdiParent = Me
        f.Show()

    End Sub
    Private Sub mnuCartelesPallet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCartelesPallet.Click
        Dim f As New frmCartelesPallet

        f.MdiParent = Me
        f.Show()

    End Sub
    Private Sub mnuConsultaPedidos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuConsultaPedidos.Click
        Dim f As New frmPedidos

        f.MdiParent = Me
        f.Show()
    End Sub
    Private Sub IntervencionesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IntervencionesToolStripMenuItem.Click
        Dim f As New frmIntervenciones
        f.MdiParent = Me
        f.Show()
    End Sub
    Private Sub StockToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockToolStripMenuItem.Click
        Dim f As New frmStock
        f.MdiParent = Me
        f.Show()
    End Sub
    Private Sub PedidosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PedidosToolStripMenuItem.Click
        Dim f As New frmPedidosConsulta
        f.MdiParent = Me
        f.Show()
    End Sub
    Private Sub mnuBuscaCliente_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuBuscaCliente.Click
        Dim f As New frmBuscaClientes
        f.MdiParent = Me
        f.Show()
    End Sub
    Private Sub FacturasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim f As New frmFacturasConsulta
        f.MdiParent = Me
        f.Show()
    End Sub
    Private Sub AcuseDeReciboToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AcuseDeReciboToolStripMenuItem.Click
        Dim f As New frmAcuseRecibo
        f.MdiParent = Me
        f.Show()
    End Sub
    Private Sub CuentaCorrienteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CuentaCorrienteToolStripMenuItem.Click
        Dim f As New frmCuentaCorriente
        f.MdiParent = Me
        f.Show()
    End Sub
    Private Sub ControlPeriodicoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ControlPeriodicoToolStripMenuItem.Click
        Dim f As New frmControlPeriodico
        f.MdiParent = Me
        f.Show()
    End Sub
    Private Sub ListadoDeRecibosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListadoDeRecibosToolStripMenuItem.Click
        Dim f As New frmListadoPedidos
        f.MdiParent = Me
        f.Show()
    End Sub
    Private Sub ReporteRecargasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReporteRecargasToolStripMenuItem.Click
        Dim rpt As New ReportDocument
        Dim rep As New Vendedor(cn)
        Dim txt As String = ""
        Dim txt1 As String = ""
        Dim VEN1 As String = "0"
        Dim VEN2 As String = "30"
        Dim crystal As frmCrystal

        txt = InputBox("ingrese fecha desde", txt)
        txt = txt.Trim
        txt1 = InputBox("ingrese fecha hasta", txt1)
        txt1 = txt1.Trim
        rpt.Load(RPTX3 & "xrepovend.rpt")
        rpt.SetDatabaseLogon(DB_USR, DB_PWD)
        rpt.SetParameterValue("datdeb", txt)
        rpt.SetParameterValue("datfin", txt1)
        If usr.Codigo = "LVER" Or usr.Codigo = "DBAT" Then
            rpt.SetParameterValue("repdeb", VEN1)
            rpt.SetParameterValue("repfin", VEN2)
        Else
            rpt.SetParameterValue("repdeb", usr.Codigo)
            rpt.SetParameterValue("repfin", usr.Codigo)
        End If
        crystal = New frmCrystal(rpt)
        crystal.MdiParent = Me.ParentForm
        crystal.Show()

    End Sub
    Private Sub mnuParte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuParte.Click
        Dim f As New frmParteCobranza
        f.MdiParent = Me
        f.Show()
    End Sub
    Private Sub ArticulosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ArticulosToolStripMenuItem.Click
        Dim f As New frmITM
        f.MdiParent = Me
        f.Show()
    End Sub
    Private Sub ListadoFacturasDeVentaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListadoFacturasDeVentaToolStripMenuItem.Click
        Dim f As New frmConFacturas
        f.MdiParent = Me
        f.Show()
    End Sub
    Private Sub RemitosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemitosToolStripMenuItem.Click
        Dim f As New frmRemitos
        f.MdiParent = Me
        f.Show()
    End Sub
    Private Sub OCToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OCToolStripMenuItem.Click
        Dim f As New frmOC
        f.MdiParent = Me
        f.Show()
    End Sub
    Private Sub SolicitudDeServicioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SolicitudDeServicioToolStripMenuItem.Click
        Dim f As New frmSS
        f.MdiParent = Me
        f.Show()
    End Sub
    'Private Sub MenuStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked
    '    If usr.Codigo = "IOEY" Or usr.Codigo = "JRODR" Or usr.Codigo = "LVER" Or usr.Codigo = "MBARC" Or usr.Codigo = "MMIN" Then
    '        SolicitudDeServicioToolStripMenuItem.Enabled = True
    '    Else
    '        SolicitudDeServicioToolStripMenuItem.Enabled = False
    '    End If
    'End Sub
    Private Sub ZetiToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ZetiToolStripMenuItem.Click
        Dim txt As String = " "
        txt = InputBox("ingrese el codigo de pedid", Me.Text)
        Dim rpt As New ReportDocument
        Dim numero As String = txt
        Dim crystal As frmCrystal
        rpt.Load(RPTX3 & "ZETI.rpt")
        rpt.SetDatabaseLogon(DB_USR, DB_PWD)
        rpt.SetParameterValue("sohnum", numero)
        rpt.SetParameterValue("x3dos", X3DOS)
        crystal = New frmCrystal(rpt)
        crystal.MdiParent = Me.ParentForm
        crystal.Show()
    End Sub
    Private Sub EstadoDePedidosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EstadoDePedidosToolStripMenuItem.Click
        Dim rpt As New ReportDocument
        Dim crystal As frmCrystal
        Dim txt As String = ""
        rpt.Load(RPTX3 & "XSTAPED.rpt")
        rpt.SetDatabaseLogon(DB_USR, DB_PWD)
        If usr.Codigo = "IOEY" Or usr.Codigo = "JRODR" Or usr.Codigo = "LVER" Or usr.Codigo = "MBARC" Or usr.Codigo = "MMIN" Then
            txt = InputBox("Ingrese Vendedor", txt)
            txt = txt.Trim
            rpt.SetParameterValue("REPDEB", txt)
            rpt.SetParameterValue("REPFIN", txt)
        Else
            rpt.SetParameterValue("REPDEB", usr.Codigo)
            rpt.SetParameterValue("REPFIN", usr.Codigo)
        End If
        rpt.SetParameterValue("x3dos", X3DOS)
        rpt.SetParameterValue("X3TIT", "ESTADO DE PEDIDOS")
        rpt.SetParameterValue("X3USR", usr.Codigo)
        rpt.SetParameterValue("BPCDEB", "000000")
        rpt.SetParameterValue("BPCFIN", "999999")
        crystal = New frmCrystal(rpt)
        crystal.MdiParent = Me.ParentForm
        crystal.Show()
    End Sub
    Private Sub mnuSS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSS.Click
        With frmSumasSaldos
            .MdiParent = Me
            .Show()
        End With
    End Sub
    Private Sub MantenimientoFijoMensualToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MantenimientoFijoMensualToolStripMenuItem.Click
        Dim f As New frmMFM
        f.MdiParent = Me
        f.Show()
    End Sub
    Private Sub ListadoDeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListadoDeToolStripMenuItem.Click
        Dim f As New frmListVenc
        f.MdiParent = Me
        f.Show()
    End Sub
    Private Sub AltaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCliente.Click
        Dim f As New frmCliente
        f.MdiParent = Me
        f.Show()
    End Sub
    Private Sub RemitosSinDespacharToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemitosSinDespacharToolStripMenuItem.Click
        Dim f As New frmRptRto
        f.MdiParent = Me
        f.Show()
    End Sub
    Private Sub frmControles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles frmControles.Click
        Dim f As New frmControles
        f.MdiParent = Me
        f.Show()

    End Sub
    Private Sub ProcesarDocumentacionEscaneadaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProcesarDocumentacionEscaneadaToolStripMenuItem.Click
        Dim f As New frmEscanerDocumentacion
        f.MdiParent = Me
        f.Show()
    End Sub
    Private Sub IngresarAusenciasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IngresarAusenciasToolStripMenuItem.Click
        Dim f As New IngresoAusencias
        f.MdiParent = Me
        f.Show()
    End Sub
    Private Sub mnuUnificacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuUnificacion.Click
        Dim f As New frmUnificarParque
        f.MdiParent = Me
        f.Show()
    End Sub
    Private Sub frmItnAbo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles frmItnAbo.Click
        Dim f As New frmItnAbo
        f.MdiParent = Me
        f.Show()
    End Sub
    Private Sub frmRetenciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles frmRetenciones.Click
        Dim f As New frmRetenciones
        f.MdiParent = Me
        f.Show()
    End Sub
    Private Sub ReporteDeVentasPorFliaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReporteDeVentasPorFliaToolStripMenuItem.Click
        Dim f As New frmRptVtasFlia
        f.MdiParent = Me
        f.Show()
    End Sub
    Private Sub PremioRelevadoresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PremioRelevadoresToolStripMenuItem.Click
        Dim f As New FrmPremioRelevadores
        f.MdiParent = Me
        f.Show()
    End Sub
    Private Sub mnuFletes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFletes.Click
        Dim f As New frmFletesTarifas
        f.MdiParent = Me
        f.Show()
    End Sub
    Private Sub CalculoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CalculoToolStripMenuItem.Click
        Dim f As New frmFlete
        f.MdiParent = Me
        f.Show()
    End Sub
    Private Sub ReporteDeVentasPorFliaAnualToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReporteDeVentasPorFliaAnualToolStripMenuItem.Click
        Dim f As New frmRptVtasfliaA
        f.MdiParent = Me
        f.Show()
    End Sub
    Private Sub frmSMS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles frmSMS.Click
        Dim f As New frmSMS
        f.MdiParent = Me
        f.Show()
    End Sub
    Private Sub frmDestinosCfg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles frmDestinosCfg.Click
        Dim f As New frmDestinos
        f.MdiParent = Me
        f.Show()
    End Sub
    Private Sub TerceroPagadorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TerceroPagadorToolStripMenuItem.Click
        Dim f As New Form1
        f.MdiParent = Me
        f.Show()
    End Sub
    Private Sub mnuFiscalGru_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFiscalGru.Click
        Dim f As New frmFiscal("GRU")
        f.MdiParent = Me
        f.Show()
    End Sub
    Private Sub mnuFiscalLia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFiscalLia.Click
        Dim f As New frmFiscal("LIA")
        f.MdiParent = Me
        f.Show()
    End Sub
    Private Sub mnuMailMasivos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMailMasivos.Click
        Dim f As New frmMailsMasivos
        f.MdiParent = Me
        f.Show()
    End Sub
    Private Sub mnuUnigisExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuUnigisExportar.Click
        Dim f As New frmExportarUnigis
        f.MdiParent = Me
        f.Show()

    End Sub
    Private Sub frmNuevoCotizador_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles frmNuevoCotizador.Click
        Dim f As New frmCotizadorV2
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub PresupuestoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PresupuestoToolStripMenuItem.Click
        Dim f As New FrmPresupuestoAnual
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub ToolStripMenuItem22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem22.Click
        Dim Cliente As String
        Dim Sucursal As String
        Dim cm1 As New OracleCommand("SELECT * FROM bpcustomer WHERE bpcnum_0 = :bpcnum_0", cn)
        Dim cm2 As New OracleCommand("SELECT * FROM xnetvenc WHERE usr_0 = :usr_0 AND rep_0 = :rep_0", cn)
        Dim dr As OracleDataReader

        cm1.Parameters.Add("bpcnum_0", OracleType.VarChar)
        cm2.Parameters.Add("usr_0", OracleType.VarChar)
        cm2.Parameters.Add("rep_0", OracleType.VarChar)

        'Valido que el cliente pueda ser consultado por el usuario actual
        Cliente = InputBox("Codigo de cliente", Me.Text)

        'Consulto vendedor del cliente
        cm1.Parameters("bpcnum_0").Value = Cliente
        dr = cm1.ExecuteReader

        If dr.Read Then
            cm2.Parameters("usr_0").Value = usr.Codigo
            cm2.Parameters("rep_0").Value = dr("rep_0").ToString
            dr.Close()
            dr = cm2.ExecuteReader

            If dr.Read Then
                If CInt(dr("abo_0")) = 1 OrElse CInt(dr("noabo_0")) = 1 Then

                    Sucursal = InputBox("Sucursal del cliente " & Cliente, Me.Text)
                    If Sucursal.Trim <> "" Then rptDistribucionVencimientosOriginal(Cliente, Sucursal)

                Else
                    MessageBox.Show("No dispone de permisos para consultar este cliente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                End If

            Else
                MessageBox.Show("No dispone de permisos para consultar este cliente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            End If


        Else
            'No se encontró el cliente
            If Cliente.Trim <> "" Then
                MessageBox.Show("No se encontró el cliente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

        End If

        dr.Close()
        cm1.Dispose()
        cm2.Dispose()
    End Sub

    Private Sub Informes639ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Informes639ToolStripMenuItem.Click
        Dim f As New FrmInforme693
        f.MdiParent = Me
        f.Show()

    End Sub

    Private Sub mnuItnAuto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuItnAuto.Click
        Dim f As New frmIntervencionesAutomaticas
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub mnuPresupuestos639_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPresupuestos639.Click
        Dim f As New frmPresupuestos639
        f.MdiParent = Me
        f.Show()

    End Sub

    Private Sub CantidadExtiToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CantidadExtiToolStripMenuItem.Click
        Dim f As New FrmCantExt
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub ClientesSinMovimientoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClientesSinMovimientoToolStripMenuItem.Click
        Dim f As New frmClientesSinMovimiento
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub ContratosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles frmContratos.Click
        Dim f As New frmContrato
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub mnuArcibaNc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuArcibaNc.Click
        Dim f As New frmArcibaNc

        f.MdiParent = Me
        f.Show()

    End Sub

    Private Sub mnuLicitaciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuLicitaciones.Click
        Dim f As New frmLicitacion

        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub PactoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PactoToolStripMenuItem.Click
        Dim f As New FrmPacto
        f.MdiParent = Me
        f.Show()

    End Sub

    Private Sub ToolStripMenuItem21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem21.Click
        Dim f As New FrmPlanillaAbonados

        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub mnuIntervencionesPendientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuIntervencionesPendientes.Click
        Dim f As New frmIntervencionesPendientes
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub TicketsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTickets.Click
        Dim f As New frmTickets

        f.MdiParent = Me
        f.Show()

    End Sub

    Private Sub ReporteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReporteToolStripMenuItem.Click
        Dim f As New frmEquiposEnPlanta
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub AtencionAlClienteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AtencionAlClienteToolStripMenuItem.Click
        Dim f As New frmSeguimiento("ATC")

        With f
            .Visible = False
            .MdiParent = Me
            .Show()
        End With
    End Sub

    Private Sub CotizadorInternoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CotizadorInternoToolStripMenuItem.Click
        Dim f As New frmCotizadorInterno
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub mnuExportarControles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExportarControles.Click
        Dim f As New frmExportarControles
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub mnuComisiones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuComisiones.Click
        Dim f As New frmComisiones
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub TableroCAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TableroCAToolStripMenuItem.Click
        Dim f As New FrmTableroCA
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub mnuIntervencion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuIntervencion.Click
        Dim f As New frmIntervencion()
        f.MdiParent = Me
        f.Show()
    End Sub
    Private Sub mnuRegistroManguera_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRegistroManguera.Click
        Dim f As New frmIramMangueras
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub mnuRelevamientos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRelevamientos.Click
        Dim f As New frmRelevamientos

        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub mnuRelevadores_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRelevadores.Click
        Dim f As New frmRelevadores

        f.MdiParent = Me
        f.Show()
    End Sub
End Class