Imports System.Data.OracleClient

Public Class frmIramMangueras
    Private ds As New DataSet
    Private da1 As OracleDataAdapter 'sremac
    Private da2 As OracleDataAdapter 'machines
    Private WithEvents dt1 As New DataTable
    Private itn As New Intervencion(cn)

    Public Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Dim tb As TablaVaria
        Dim mnu As MenuLocal

        Adaptadores()

        colNro.DataPropertyName = "nromanga_0"

        tb = New TablaVaria(cn, 22, False)
        tb.EnlazarComboBox(colDiametro)
        colDiametro.DataPropertyName = "tsicod_2"

        tb = New TablaVaria(cn, 21, False)
        tb.EnlazarComboBox(colLargo)
        colLargo.DataPropertyName = "tsicod_1"

        colLargoReal.DataPropertyName = "largo_0"

        mnu = New MenuLocal(cn, 1, True)
        mnu.Enlazar(colOk)
        colOk.DataPropertyName = "ok_0"

        tb = New TablaVaria(cn, 408, True)
        tb.EnlazarComboBox(colMarca)
        colMarca.DataPropertyName = "macbra_0"

        mnu = New MenuLocal(cn, 9201, True)
        mnu.Enlazar(colTipo)
        colTipo.DataPropertyName = "tipomanga_0"

        colIram.DataPropertyName = "nroiram_0"

        colObs.DataPropertyName = "obs_0"

        colPresion.DataPropertyName = "presion_0"

        colSerie.DataPropertyName = "macnum_0"

        colPuesto.DataPropertyName = "ynrocil_0"

        mnu = New MenuLocal(cn, 9202, True)
        mnu.Enlazar(colTipo)
        colTipo.DataPropertyName = "tipomanga_0"

        colSolicitud.DataPropertyName = "srenum_0"
        colIntervencion.DataPropertyName = "yitnnum_0"
        colUsuario.DataPropertyName = "usuario_0"

        dgv.DataSource = dt1

    End Sub
    Private Sub Adaptadores()
        Dim Sql As String

        Sql = "SELECT mac.nromanga_0, " _
            & "       itm.tsicod_2, " _
            & "       itm.tsicod_1, " _
            & "       mac.macbra_0, " _
            & "       srm.largo_0, " _
            & "       srm.nroiram_0, " _
            & "       srm.presion_0, " _
            & "       mac.ynrocil_0, " _
            & "       srm.ok_0, " _
            & "       srm.obs_0, " _
            & "       mac.tipomanga_0, " _
            & "       srm.macnum_0, " _
            & "       srm.srenum_0, " _
            & "       srm.yitnnum_0, " _
            & "       srm.usuario_0 " _
            & "FROM sremac srm INNER JOIN " _
            & "	    machines mac on (srm.macnum_0 = mac.macnum_0) INNER JOIN " _
            & "	    itmmaster itm on (itm.itmref_0 = mac.macpdtcod_0) " _
            & "WHERE yitnnum_0 = :itn AND " _
            & "      itm.tsicod_3 = '302' " _
            & "ORDER BY srm.srelig_0"
        da1 = New OracleDataAdapter(Sql, cn)
        da2 = New OracleDataAdapter(Sql, cn)

        da1.SelectCommand.Parameters.Add("itn", OracleType.VarChar).Value = ""
        da1.Fill(dt1)
        ds.Tables.Add(dt1)

        Sql = "UPDATE sremac " _
            & "SET nroiram_0 = :nroiram_0 , " _
            & "    largo_0   = :largo_0   , " _
            & "    ok_0      = :ok_0      , " _
            & "    presion_0 = :presion_0 , " _
            & "    usuario_0 = :usuario_0 , " _
            & "    obs_0     = :obs_0       " _
            & "WHERE srenum_0  = :srenum_0 and " _
            & "      macnum_0  = :macnum_0 and " _
            & "      yitnnum_0 = :yitnnum_0 "

        da1.UpdateCommand = New OracleCommand(Sql, cn)
        With da1
            Parametro(.UpdateCommand, "nroiram_0", OracleType.VarChar, DataRowVersion.Current)
            Parametro(.UpdateCommand, "largo_0", OracleType.Number, DataRowVersion.Current)
            Parametro(.UpdateCommand, "ok_0", OracleType.Number, DataRowVersion.Current)
            Parametro(.UpdateCommand, "presion_0", OracleType.VarChar, DataRowVersion.Current)
            Parametro(.UpdateCommand, "obs_0", OracleType.VarChar, DataRowVersion.Current)
            Parametro(.UpdateCommand, "usuario_0", OracleType.VarChar, DataRowVersion.Current)

            Parametro(.UpdateCommand, "srenum_0", OracleType.VarChar, DataRowVersion.Original)
            Parametro(.UpdateCommand, "macnum_0", OracleType.VarChar, DataRowVersion.Original)
            Parametro(.UpdateCommand, "yitnnum_0", OracleType.VarChar, DataRowVersion.Original)
        End With

        Sql = "UPDATE machines " _
            & "SET tipomanga_0 = :tipomanga_0, " _
            & "    nromanga_0  = :nromanga_0," _
            & "    macbra_0    = :macbra_0, " _
            & "    ynrocil_0   = :ynrocil_0 " _
            & "WHERE macnum_0 = :macnum_0 "
        da2.UpdateCommand = New OracleCommand(Sql, cn)
        With da2
            Parametro(.UpdateCommand, "tipomanga_0", OracleType.Number, DataRowVersion.Current)
            Parametro(.UpdateCommand, "nromanga_0", OracleType.Number, DataRowVersion.Current)
            Parametro(.UpdateCommand, "macbra_0", OracleType.VarChar, DataRowVersion.Current)
            Parametro(.UpdateCommand, "ynrocil_0", OracleType.VarChar, DataRowVersion.Current)
            Parametro(.UpdateCommand, "macnum_0", OracleType.VarChar, DataRowVersion.Original)
        End With

    End Sub
    Private Sub AbrirIntervencion(ByVal Nro As String)
        dt1.Clear()
        txtIntervencion.Clear()
        txtCodigo.Clear()
        txtNombre.Clear()
        txtSucursal.Clear()
        txtDireccion.Clear()

        If itn.Abrir(Nro) Then
            Dim bpc As Cliente
            bpc = itn.Cliente

            txtIntervencion.Text = itn.Numero
            txtCodigo.Text = bpc.Codigo
            txtNombre.Text = bpc.Nombre
            txtSucursal.Text = itn.SucursalCodigo
            txtDireccion.Text = itn.SucursalCalle

            CargarMangueras()
            CompletarCamposVacios()
            Registrar()

        End If

    End Sub
    Private Sub CompletarCamposVacios()
        For Each dr As DataRow In dt1.Rows
            If CLng(dr("nromanga_0")) = 0 Then
                dr.BeginEdit()
                dr("nromanga_0") = CLng(dr("macnum_0"))
                dr.EndEdit()
            End If
            If dr("presion_0").ToString.Trim = "" Then
                dr.BeginEdit()
                dr("presion_0") = "1.2"
                dr.EndEdit()
            End If
        Next
    End Sub
    Private Sub CargarMangueras()
        dt1.Clear()
        da1.SelectCommand.Parameters("itn").Value = itn.Numero
        da1.Fill(dt1)

        If dgv.DataSource Is Nothing Then
            dgv.DataSource = dt1
        End If

    End Sub
    Private Sub btnRegistrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegistrar.Click
        PruebaRealizadaPor()
        Registrar()
    End Sub
    Private Sub Registrar()
        Dim dt2 As DataTable

        'Clono la tabla principal
        dt2 = dt1.Clone

        For Each dr As DataRow In dt1.Rows
            'Agrego la filas modificadas a la tabla clonada
            If dr.RowState = DataRowState.Modified Then
                Dim dr2 As DataRow

                'copio los datos de todos los campos
                dr2 = dt2.NewRow

                For i = 0 To dt1.Columns.Count - 1
                    dr2(i) = dr(i)
                Next

                dt2.Rows.Add(dr2)

            End If
        Next

        dt2.AcceptChanges()

        For Each dr As DataRow In dt2.Rows
            dr.SetModified()
        Next

        'Actualizo la tabla principal (SREMAC)
        da1.Update(dt1)
        'Actualizo la tabla machines
        da2.Update(dt2)

    End Sub
    Private Sub PruebaRealizadaPor()
        'Pone el nombre de la persona que hizo las pruebas en las mangueras
        Dim dr As DataRow
        Dim HaySinNombre As Boolean = False
        Dim Nombre As String = "" 'Nombre del empleado que hizo las ph

        'Miro si hay registro sin nombre de empleado
        For Each dr In dt1.Rows
            If dr("usuario_0").ToString.Trim = "" Then
                HaySinNombre = True
            Else
                If Nombre = "" Then Nombre = dr("usuario_0").ToString
            End If
            'Salgo si ya encontré registros con y sin nombre
            If HaySinNombre And Nombre <> "" Then Exit For
        Next

        'Pido nombre de empleado que hizo ph si encontré registros sin nombre
        If HaySinNombre Then
            While Nombre = ""
                Nombre = InputBox("Escriba el nombre de quien hizo las PH", Me.Text)
                Nombre = Nombre.Trim
            End While

            'Maximo que cadena nombre 25 caracteres
            If Nombre.Length > 25 Then Nombre = Strings.Left(Nombre, 25)

            'Pongo nombre a los registros que no lo tienen
            For Each dr In dt1.Rows
                If dr("usuario_0").ToString.Trim = "" Then
                    dr.BeginEdit()
                    dr("usuario_0") = Nombre
                    dr.EndEdit
                End If
            Next

        End If

    End Sub
    Private Sub mnuAbrir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAbrir.Click
        Dim Nro As String

        Nro = InputBox("Número de intervencion")
        Nro = Nro.Trim

        If Nro <> "" Then AbrirIntervencion(Nro)

    End Sub
    Private Sub frmIramMangueras_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If ds.HasChanges Then
            Dim txt As String
            Dim d As DialogResult

            txt = "¿Desea guardar los cambios?"

            d = MessageBox.Show(txt, Me.Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3)

            Select Case d
                Case Windows.Forms.DialogResult.Yes
                    PruebaRealizadaPor()
                    Registrar()
                    e.Cancel = False

                Case Windows.Forms.DialogResult.No
                    e.Cancel = False

                Case Windows.Forms.DialogResult.Cancel
                    e.Cancel = True

            End Select

        End If

    End Sub
    Private Sub EstadoBoton()
        btnRegistrar.Enabled = ds.HasChanges
    End Sub
    Private Sub dt1_RowChanged(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs) Handles dt1.RowChanged
        EstadoBoton()
    End Sub

    Private Sub btnIram_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIram.Click
        Dim i, j As Integer
        Dim t As String

        t = "Ingrese el número de la primer estampilla"
        t = InputBox(t, Me.Text)

        If IsNumeric(t) Then
            i = CInt(t)

            For j = 0 To dt1.Rows.Count - 1
                Dim dr As DataRow
                dr = dt1.Rows(j)

                'Salto si OK = NO
                If CInt(dr("ok_0")) <> 2 Then Continue For

                dr.BeginEdit()
                dr("nroiram_0") = i
                dr.EndEdit()

                i += 1
            Next

        Else
            MessageBox.Show("El valor ingresado no es numérico", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)

        End If

    End Sub
End Class