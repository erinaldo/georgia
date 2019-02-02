Imports System.Data.OracleClient

Public Class frmParque

    Private WithEvents Mac As Parque
    Private Activo As Boolean = False

    'SUB
    Public Sub New(ByVal Mac As Parque)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        nudFab.Maximum = Today.Year
        nudFab.Value = Today.Year

        nudAnoPh.Maximum = Today.Year + 50

        Me.Mac = Mac

        Try
            'Si es edicion ajusto valores de los controles del formulario
            If Mac.Serie = " " Then
                lblSerie.Text &= "NUEVO"

                Activo = True
                CargarTipos("201")
                CargarCapacidades(lstTipo.SelectedValue.ToString, "108")
                CargarArticulos(lstTipo.SelectedValue.ToString, lstCapacidad.SelectedValue.ToString)

            Else
                lblSerie.Text &= Mac.Serie

                'Ajusto valores de controles
                'AgregarArticulo(Mac.ArticuloCodigo)

                Activo = False
                CargarTipos(Mac.Articulo.Familia(2))
                CargarCapacidades(lstTipo.SelectedValue.ToString, Mac.Articulo.Familia(1))
                CargarArticulos(lstTipo.SelectedValue.ToString, lstCapacidad.SelectedValue.ToString, Mac.Articulo.Codigo)
                Activo = True

                'nudCantidad.Value = Mac.Cantidad
                nudFab.Value = Mac.FabricacionCorto

                dtpVto.Value = Mac.VtoCarga

                If Mac.EsManguera Then
                    NudMesPh.Enabled = False
                    nudAnoPh.Enabled = False

                Else
                    NudMesPh.Value = Mac.VtoPH.Month
                    nudAnoPh.Value = Mac.VtoPH.Year
                    NudMesPh.Enabled = True
                    nudAnoPh.Enabled = True

                End If

                txtCilindro.Text = Mac.Cilindro

                Activo = True

                If lstTipo.SelectedItems.Count = 0 Or lstCapacidad.SelectedItems.Count = 0 Then

                    MessageBox.Show("No se puede editar. Familias mal configuradas para el articulo " & Mac.ArticuloCodigo, _
                                    Me.Text, _
                                    MessageBoxButtons.OK, _
                                    MessageBoxIcon.Stop)

                    lstCapacidad.Enabled = False
                    lstTipo.Enabled = False
                    'nudCantidad.Enabled = False
                    txtCilindro.Enabled = False
                    nudFab.Enabled = False
                    dtpVto.Enabled = False
                    NudMesPh.Enabled = False
                    nudAnoPh.Enabled = False
                    btnAceptar.Enabled = False

                End If

            End If



        Catch ex As Exception
            MessageBox.Show(ex.Message, "New()", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub
    Private Sub CargarTipos(Optional ByVal Seleccionar As String = "")
        Dim Sql As String
        Dim da As OracleDataAdapter
        Dim dt As New DataTable

        'Cargo Tipo de extintores
        Sql = "SELECT ident2_0, texte_0 "
        Sql &= "FROM atextra "
        Sql &= "WHERE codfic_0 = 'ATABDIV' AND "
        Sql &= "	  zone_0   = 'LNGDES' AND "
        Sql &= "	  langue_0   = 'SPA' AND "
        Sql &= "	  ident1_0 = '22' AND "
        Sql &= "	  ident2_0 in (SELECT DISTINCT tsicod_2 FROM itmmaster WHERE tsicod_3 in ('301', '302') AND xparque_0 = 2) "
        Sql &= "ORDER BY ident2_0"
        da = New OracleDataAdapter(Sql, cn)
        da.Fill(dt)

        With lstTipo
            .DataSource = dt
            .DisplayMember = "texte_0"
            .ValueMember = "ident2_0"
        End With

        If Seleccionar <> "" Then
            lstTipo.SelectedValue = Seleccionar
        Else
            lstCapacidad.SetSelected(0, True)
        End If

    End Sub
    Private Sub CargarCapacidades(ByVal Tipo As String, Optional ByVal Seleccionar As String = "")
        Dim Sql As String
        Dim da As OracleDataAdapter
        Dim dt As New DataTable

        'Cargo Capacidades de extintores
        Sql = "SELECT ident2_0, texte_0 "
        Sql &= "FROM atextra "
        Sql &= "WHERE codfic_0 = 'ATABDIV' AND "
        Sql &= "	  zone_0   = 'LNGDES' AND "
        Sql &= "	  langue_0 = 'SPA' AND "
        Sql &= "	  ident1_0 = '21' AND "
        Sql &= "	  ident2_0 IN (SELECT DISTINCT tsicod_1 FROM itmmaster WHERE tsicod_2 = :tsicod_2 AND tsicod_3 in ('301', '302') AND xparque_0 = 2) "
        Sql &= "ORDER BY ident2_0"
        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("tsicod_2", OracleType.VarChar).Value = Tipo

        If lstCapacidad.DataSource Is Nothing Then
            dt = New DataTable
        Else
            dt = CType(lstCapacidad.DataSource, DataTable)
        End If

        dt.Clear()
        da.Fill(dt)

        If lstCapacidad.DataSource Is Nothing Then
            With lstCapacidad
                .DataSource = dt
                .DisplayMember = "texte_0"
                .ValueMember = "ident2_0"
            End With
        End If

        If dt.Rows.Count = 0 Then Exit Sub

        If Seleccionar = "" Then
            lstCapacidad.SetSelected(0, True)
        Else
            lstCapacidad.SelectedValue = Seleccionar
        End If

    End Sub
    Private Sub CargarArticulos(ByVal Tipo As String, ByVal Capacidad As String, Optional ByVal Seleccionar As String = "")
        Dim Sql As String
        Dim da As OracleDataAdapter
        Dim dt As DataTable

        Sql = "SELECT itmref_0, itmref_0 || ' - ' || itmdes1_0 AS descr "
        Sql &= "FROM itmmaster "
        Sql &= "WHERE tsicod_1 = :tsicod_1 AND "
        Sql &= "	  tsicod_2 = :tsicod_2 AND "
        Sql &= "	  tsicod_3 in ('301', '302') AND "
        Sql &= "	  xparque_0 = 2 "
        Sql &= "ORDER BY itmref_0"

        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("tsicod_1", OracleType.VarChar).Value = Capacidad
        da.SelectCommand.Parameters.Add("tsicod_2", OracleType.VarChar).Value = Tipo

        If lstArticulos.DataSource Is Nothing Then
            dt = New DataTable
        Else
            dt = CType(lstArticulos.DataSource, DataTable)
        End If

        dt.Clear()
        da.Fill(dt)

        If lstArticulos.DataSource Is Nothing Then
            With lstArticulos
                .DataSource = dt
                .DisplayMember = "descr"
                .ValueMember = "itmref_0"
            End With
        End If

        If Seleccionar = "" Then
            lstArticulos.SetSelected(0, True)

        Else
            Dim Existe As Boolean = False
            'Busco si el articulo a seleccionar existe en la lista
            For Each dr As DataRow In dt.Rows
                If dr("itmref_0").ToString = Seleccionar Then
                    Existe = True
                    Exit For
                End If
            Next

            If Not Existe Then
                Sql = "SELECT itmref_0, itmref_0 || ' - ' || itmdes1_0 AS descr "
                Sql &= "FROM itmmaster "
                Sql &= "WHERE itmref_0 = :itmref_0 "
                da = New OracleDataAdapter(Sql, cn)
                da.SelectCommand.Parameters.Add("itmref_0", OracleType.VarChar).Value = Seleccionar
                da.Fill(dt)
            End If

            lstArticulos.SelectedValue = Seleccionar

        End If

    End Sub
    Private Sub EstablecerArticulo() 'ByVal Tipo As String, ByVal Capa As String)
        Dim itm As New Articulo(cn)

        If lstArticulos.SelectedItem IsNot Nothing Then
            itm.Abrir(lstArticulos.SelectedValue.ToString)

            Mac.ArticuloCodigo = itm.Codigo

        End If

    End Sub
    Private Sub BuscarParqueSinCilindro()
        'Busca si hay parque sin numero de cilindro para ser utilizado en lugar de crear un parque nuevo
        Dim da As OracleDataAdapter
        Dim dt As New DataTable
        Dim Sql As String = ""

        Sql = "select mac.* "
        Sql &= "from machines mac inner join "
        Sql &= "	 ymacitm ymc on (mac.macnum_0 = ymc.macnum_0) inner join "
        Sql &= "	 itmmaster itm on (macpdtcod_0 = itmref_0) inner join "
        Sql &= "	 bomd bom on (mac.macpdtcod_0 = bom.itmref_0 and ymc.cpnitmref_0 = bom.cpnitmref_0 and bomalt_0 = 99 and bomseq_0 = '10') "
        Sql &= "where mac.ynrocil_0 = ' ' and "
        Sql &= "	  mac.bpcnum_0 = :bpc and "
        Sql &= "	  mac.fcyitn_0 = :fcy and "
        Sql &= "	  tsicod_1 = :capacidad and "
        Sql &= "	  tsicod_2 = :tipo and "
        Sql &= "	  datnext_0 >= :desde and "
        Sql &= "	  datnext_0 < :hasta"

        da = New OracleDataAdapter(Sql, cn)
        With da.SelectCommand.Parameters
            .Add("bpc", OracleType.VarChar).Value = Mac.ClienteNumero
            .Add("fcy", OracleType.VarChar).Value = Mac.SucursalNumero
            Dim s1 As String = Mac.Articulo.Familia(1)
            Dim s2 As String = Mac.Articulo.Familia(2)

            .Add("capacidad", OracleType.VarChar).Value = Mac.Articulo.Familia(1)
            .Add("tipo", OracleType.VarChar).Value = Mac.Articulo.Familia(2)
            Dim d As Date = New Date(Today.Year, Today.Month, 1)
            .Add("desde", OracleType.DateTime).Value = d.AddMonths(-2)
            .Add("hasta", OracleType.DateTime).Value = d.AddMonths(3)
        End With

        da.Fill(dt)

        If dt.Rows.Count > 0 Then
            Dim dr As DataRow = dt.Rows(0)
            Mac.Abrir(dr("macnum_0").ToString)
            Mac.Observaciones = "Reutilizado sin número de cilindro"
        End If

    End Sub

    'EVENTOS
    Private Sub lstTipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstTipo.SelectedIndexChanged
        If Activo Then

            If lstTipo.SelectedValue Is Nothing Then Exit Sub
            CargarCapacidades(lstTipo.SelectedValue.ToString)

        End If

    End Sub
    Private Sub lstCapacidad_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstCapacidad.SelectedIndexChanged
        If Activo Then

            If lstTipo.SelectedValue Is Nothing OrElse lstCapacidad.SelectedValue Is Nothing Then Exit Sub
            CargarArticulos(lstTipo.SelectedValue.ToString, lstCapacidad.SelectedValue.ToString)

        End If
    End Sub
    Private Sub lstArticulos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstArticulos.SelectedIndexChanged
        If Activo Then EstablecerArticulo()
    End Sub
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        'Valido si existe cilindro
        If txtCilindro.Text.Trim = "" Then
            MessageBox.Show("Debe ingresar un número de cilindro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtCilindro.Focus()
            Exit Sub

        Else
            txtCilindro.Text = Parque.EsNumerico(txtCilindro.Text)

            'Validar que el cilindro no se repita en el cliente
            If Mac.ExisteCilindro(txtCilindro.Text) Then
                MessageBox.Show("El número de cilindro ya existe en el parque del cliente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtCilindro.Focus()
                Exit Sub
            End If

        End If

        'Validar la fecha de PH
        If Mac.TienePh Then
            Dim phActual As New Date(CInt(nudAnoPh.Value), CInt(NudMesPh.Value), 1)
            Dim PhMaximo As Date = Date.Today.AddDays(Mac.FrecuenciaPH)

            PhMaximo.AddDays(Date.DaysInMonth(PhMaximo.Year, PhMaximo.Month) - PhMaximo.Day)

            If phActual > PhMaximo Then
                MessageBox.Show("La fecha de PH no puede ser mayor a: " & PhMaximo.ToShortDateString, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

        End If

        'Busco si hay algun parque sin numero de cilindro que se pueda reutilizar
        If Mac.Serie.Trim = "" Then BuscarParqueSinCilindro()

        With Mac
            .Cantidad = 1 'CInt(nudCantidad.Value)
            .FabricacionCorto = CInt(nudFab.Value)
            .Cilindro = txtCilindro.Text

            .VtoCarga = dtpVto.Value.Date

            If .TienePh Then .VtoPH = New Date(CInt(nudAnoPh.Value), CInt(NudMesPh.Value), 1)

            .Grabar()

        End With

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub txtCilindro_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCilindro.GotFocus
        txtCilindro.SelectAll()
    End Sub
    Private Sub Mac_CambioArticulo(ByVal sender As Object, ByVal e As CambioArticuloEventArgs) Handles Mac.CambioArticulo
        NudMesPh.Enabled = e.TienePH
        nudAnoPh.Enabled = e.TienePH
    End Sub
    Private Sub Mac_CambioVencimiento(ByVal sender As Object, ByVal e As CambioVencimientoEvenArgs) Handles Mac.CambioVencimiento
        If e.TipoVencimiento = 1 Then '1 = Vencimiento de PH
            NudMesPh.Value = e.Fecha.Month
            nudAnoPh.Value = e.Fecha.Year
        End If
    End Sub

End Class