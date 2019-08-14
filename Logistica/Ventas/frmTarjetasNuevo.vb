Imports System.Data.OracleClient
Imports System.IO

Public Class frmTarjetasNuevo
    Const SEP As String = "|"

    Private soh As New Pedido(cn)
    Private da As OracleDataAdapter 'ZETINUE2
    Private ds As New DataSet
    Private WithEvents dt As New DataTable 'ZETINUE2

    Public Sub New()
        Dim Sql As String

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        Sql = "SELECT * FROM zetinue2 WHERE sohnum_0 = :sohnum"
        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("sohnum", OracleType.VarChar)
        da.InsertCommand = New OracleCommandBuilder(da).GetInsertCommand
        da.UpdateCommand = New OracleCommandBuilder(da).GetUpdateCommand

        AddHandler dgv.RowPostPaint, AddressOf NumeracionGrillas

        ds.Tables.Add(dt)

        Try
            da.FillSchema(dt, SchemaType.Mapped)

            colPedido.DataPropertyName = "sohnum_0"
            colLinea.DataPropertyName = "numlig_0"
            With colTipo
                .DataPropertyName = "itmref_0"
                .ValueMember = "itmref_0"
                .DisplayMember = "itmdes1_0"
                .DataSource = Articulo.Tabla(cn)
            End With
            colSerie.DataPropertyName = "macnum_0"
            colCilindro.DataPropertyName = "ynrocil_0"
            dgv.DataSource = dt

        Catch ex As Exception

        End Try

    End Sub
    Private Sub Abrir()
        Dim txt As String

        txtCliente.Clear()
        txtNro.Clear()
        dt.Clear()

        txt = InputBox("Ingrese número de pedido", Me.Text)

        If txt.Trim <> "" Then
            If soh.Abrir(txt) Then

                txtNro.Text = soh.Numero
                txtCliente.Text = soh.Cliente.Codigo & " - " & soh.Cliente.Nombre

                'Cargo datos de tabla ZETINUE2
                da.SelectCommand.Parameters("sohnum").Value = txt
                da.Fill(dt)

                'Si la tabla no contiene datos, intento cargarla desde el parque
                If dt.Rows.Count = 0 Then CargarDesdeParque()
                'Si no hay parque, creo lo registro manualmente
                If dt.Rows.Count = 0 Then CargarManualmente()

            Else
                MessageBox.Show("Pedido no encontrado", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

        End If

    End Sub
    Private Sub Registrar()
        If Not ds.HasChanges Then Exit Sub

        Try
            da.Update(dt)

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub
    Private Sub Exportar()
        If soh Is Nothing Then Exit Sub

        Dim Txt As String = "Se exportaron {xx} extintor(es)"
        Dim linea As String
        Dim bpa As Sucursal
        Dim bpc As Cliente
        Dim itm As New Articulo(cn)
        Dim sw As StreamWriter
        Dim Archivo As String
        Dim tab1 = New TablaVaria(cn, 22)
        Dim tab2 = New TablaVaria(cn, 21)
        Dim bomd As New Bomd(cn)
        Dim i As Integer = 0

        SaveFileDialog1.Filter = "Documentos de texto (*.txt*)|*.txt"
        SaveFileDialog1.FileName = soh.Numero

        'Salgo si el usuario cancelo el dialogo
        If SaveFileDialog1.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub
        Archivo = SaveFileDialog1.FileName

        bpc = soh.Cliente
        bpa = bpc.Cliente.Sucursal(soh.SucursalCodigo)

        sw = New StreamWriter(Archivo, False, System.Text.Encoding.Default)

        For Each dr As DataRow In dt.Rows
            If dr("ynrocil_0").ToString.Trim = "" Then Continue For

            itm.Abrir(dr("itmref_0").ToString)

            If bpc.TipoDoc = "80" And bpc.CUIT <> "" And bpc.Familia2 <> "11" Then
                'Empresa
                linea = "Empresa/Local" & SEP 'Campo 1
                linea &= bpc.CUIT & SEP 'Campo 2
                linea &= bpc.Nombre & SEP 'Campo 3
                linea &= SEP 'Campo 4
                linea &= SEP 'Campo 5
                linea &= SEP 'Campo 6

            Else
                'Particular
                linea = "Particular" & SEP 'Campo 1
                linea &= SEP 'Campo 2
                linea &= SEP 'Campo 3
                linea &= SEP 'Campo 4
                linea &= SEP 'Campo 5
                linea &= SEP 'Campo 6

            End If

            linea &= dr("ynrocil_0").ToString.Trim & SEP 'Campo 7
            linea &= "False" & SEP 'Campo 8
            linea &= "Venta" & SEP 'Campo 9
            linea &= tab1.Aux1(itm.Familia(2)) & SEP 'Campo 10
            linea &= tab2.Aux1(itm.Familia(1)) & SEP 'Campo 11
            linea &= "Matafuegos Donny S.R.L" & SEP 'Campo 12
            linea &= "Matafuegos Donny S.R.L" & SEP 'Campo 13
            linea &= SEP 'Campo 14
            linea &= soh.Fecha.Year.ToString & SEP 'Campo 15

            If bomd.Abrir(itm.Codigo, "20") Then
                linea &= soh.Fecha.AddDays(bomd.Dias).ToString("MM/yyyy") & SEP 'Campo 16

            ElseIf bomd.Abrir("11" & itm.Codigo.Substring(2), "20") Then
                linea &= soh.Fecha.AddDays(bomd.Dias).ToString("MM/yyyy") & SEP 'Campo 16

            Else
                linea &= soh.Fecha.AddYears(5).ToString("MM/yyyy") & SEP 'Campo 16

            End If


            linea &= bpa.CallejeroGCBA & SEP 'Campo 17
            linea &= bpa.AlturaGCBA & SEP 'Campo 18
            linea &= SEP 'Campo 19

            sw.WriteLine(linea)

            i += 1

        Next

        sw.Close()

        MessageBox.Show(i.ToString & " línea(s) exportadas", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub
    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        Dim mac As New Parque(cn)

        Try
            da.Update(dt)

            For Each dr As DataRow In dt.Rows
                If dr("macnum_0").ToString.Trim = "" Then Continue For
                If dr("ynrocil_0").ToString.Trim = "" Then Continue For

                If mac.Abrir(dr("macnum_0").ToString) Then
                    mac.Cilindro = dr("ynrocil_0").ToString
                    mac.FabricacionCorto = Year(soh.Fecha)
                    mac.Grabar()
                End If
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub
    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        If soh Is Nothing Then Exit Sub
        If dt.Rows.Count = 0 Then Exit Sub

        Dim bpa As Sucursal

        bpa = soh.Cliente.Sucursal(soh.SucursalCodigo)

        If bpa.AlturaGCBA = 0 OrElse bpa.CallejeroGCBA = "" Then
            MessageBox.Show("Este cliente no tiene cargado el callejero GCBA", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        If bpa.Provincia <> "CFE" Then
            MessageBox.Show("Este cliente no es de Capital", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        If ds.HasChanges Then Registrar()

        Exportar()

    End Sub
    Private Sub btnPedido_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPedido.Click
        Abrir()
    End Sub
    Private Sub OnOff()
        btnGrabar.Enabled = ds.HasChanges
        btnExportar.Enabled = ds.HasChanges = False And dt.Rows.Count > 0
    End Sub
    Private Sub CargarDesdeParque()
        Dim Sql As String
        Dim dr As DataRow
        Dim dt As New DataTable
        Dim da As OracleDataAdapter
        Dim i As Integer = 0

        Sql = "SELECT macnum_0, macpdtcod_0, macdes_0, ynrocil_0, yfabdat_0 "
        Sql &= "FROM machines mac INNER JOIN itmmaster itm ON (mac.macpdtcod_0 = itm.itmref_0) "
        Sql &= "WHERE macorivcr_0 IN (SELECT sdhnum_0 FROM sdelivery WHERE sohnum_0 = :ped)"
        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("ped", OracleType.VarChar).Value = soh.Numero
        da.Fill(dt)
        da.Dispose()

        For Each dr In dt.Rows
            AgregarRegistro(soh.Numero, dr("macpdtcod_0").ToString, dr("macnum_0").ToString, dr("ynrocil_0").ToString)
        Next

    End Sub
    Private Sub CargarManualmente()
        Dim Sql As String
        Dim da As OracleDataAdapter
        Dim dr As DataRow
        Dim dt As New DataTable

        Sql = "SELECT sqh.qty_0, sqh.itmref_0 "
        Sql &= "FROM sorderq sqh INNER JOIN itmsales itm ON (sqh.itmref_0 = itm.itmref_0) "
        Sql &= "WHERE itm.yflgsat_0 = 2 AND sohnum_0 = :sohnum"
        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("sohnum", OracleType.VarChar).Value = soh.Numero
        da.Fill(dt)
        da.Dispose()

        For Each dr In dt.Rows
            For i = 1 To CInt(dr("qty_0"))
                AgregarRegistro(soh.Numero, dr("itmref_0").ToString, "", "")
            Next
        Next

    End Sub
    Public Sub AgregarRegistro(ByVal Pedido As String, ByVal Articulo As String, ByVal Serie As String, ByVal cilindro As String)
        Dim dr As DataRow

        dr = dt.NewRow
        dr("sohnum_0") = Pedido
        dr("numlig_0") = dt.Rows.Count + 1
        dr("itmref_0") = Articulo
        dr("macnum_0") = IIf(Serie.Trim = "", " ", Serie)
        dr("ynrocil_0") = IIf(cilindro.Trim = "", " ", cilindro)
        dt.Rows.Add(dr)

    End Sub

    Private Sub dt_RowChanged(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs) Handles dt.RowChanged
        OnOff()
    End Sub
    Private Sub dt_RowDeleted(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs) Handles dt.RowDeleted
        OnOff()
    End Sub
    Private Sub dt_TableCleared(ByVal sender As Object, ByVal e As System.Data.DataTableClearEventArgs) Handles dt.TableCleared
        OnOff()
    End Sub
    Private Sub dt_TableNewRow(ByVal sender As Object, ByVal e As System.Data.DataTableNewRowEventArgs) Handles dt.TableNewRow
        OnOff()
    End Sub

End Class