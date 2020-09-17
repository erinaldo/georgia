Imports System.Data.OracleClient

Public Class frmTransferenciaIntervencion
    Private itnOrigen As Intervencion = Nothing
    Private itnDestino As Intervencion = Nothing
    Private da As OracleDataAdapter
    Private dt As DataTable

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Dim Sql As String

        Sql = "SELECT srenum_0, yitnnum_0, macnum_0 "
        Sql &= "FROM sremac "
        Sql &= "WHERE yitnnum_0 = :yitnnum"
        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("yitnnum", OracleType.VarChar)
        da.UpdateCommand = New OracleCommandBuilder(da).GetUpdateCommand

    End Sub
    Private Sub btnAbrirOrigen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbrirOrigen.Click
        Dim itn As Intervencion

        itn = AbrirIntervencion()

        If itn IsNot Nothing Then
            itnOrigen = itn

            txtClienteOrigen.Text = itn.Cliente.Codigo
            txtSucursalOrigen.Text = itn.SucursalCodigo
            txtIntervencionOrigen.Text = itn.Numero

            CargarEquipos(itnOrigen)

        End If

    End Sub

    Private Sub btnAbrirDestino_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbrirDestino.Click
        Dim itn As Intervencion

        itn = AbrirIntervencion()

        If itn IsNot Nothing Then
            itnDestino = itn

            txtClienteDestino.Text = itnDestino.Cliente.Codigo
            txtSucursalDestino.Text = itnDestino.SucursalCodigo
            txtIntervencionDestino.Text = itnDestino.Numero
        End If

    End Sub

    Private Function AbrirIntervencion() As Intervencion
        Dim txt As String
        Dim itn As New Intervencion(cn)

        txt = InputBox("Ingrese número de Intervención", "Abrir Intervención", "")
        txt = txt.Trim

        If txt <> "" Then
            If itn.Abrir(txt) Then
                Return itn
            Else
                MessageBox.Show("Intervención no encontrada", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
       
        End If

        Return Nothing

    End Function

    Private Sub CargarEquipos(ByVal itn As Intervencion)

        If dgv.DataSource Is Nothing Then
            colIntervención.DataPropertyName = "yitnnum_0"
            colSerie.DataPropertyName = "macnum_0"
            colSolicitud.DataPropertyName = "srenum_0"
            dt = New DataTable

        Else
            dt = CType(dgv.DataSource, DataTable)

        End If

        da.SelectCommand.Parameters("yitnnum").Value = itnOrigen.Numero
        dt.Clear()
        da.Fill(dt)

        If dgv.DataSource Is Nothing Then dgv.DataSource = dt

    End Sub

    Private Sub btnTransferir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTransferir.Click

        If itnOrigen Is Nothing Then
            MessageBox.Show("Debe abrir una Intervención de Origen", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        If itnDestino Is Nothing Then
            MessageBox.Show("Debe abrir una Intervención de Destino", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        'Valido que las intervenciones pertenezcan al mismo cliente/sucursal
        If itnOrigen.SucursalCodigo <> itnDestino.SucursalCodigo OrElse itnOrigen.Cliente.Codigo <> itnDestino.Cliente.Codigo Then
            MessageBox.Show("Las intervenciones deben ser del mismo cliente/sucursal", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If



        Dim Solicitud As String = itnDestino.SolicitudAsociada.Numero
        Dim Intervencion As String = itnDestino.Numero

        For Each dr As DataRow In dt.Rows
            dr("srenum_0") = Solicitud
            dr("yitnnum_0") = Intervencion
        Next

        da.Update(dt)

        MessageBox.Show("Transferencia realizada", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

End Class