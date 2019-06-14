Imports System.Data.OracleClient

Public Class frmABMPuestos
    Public Puesto As Puesto2
    Private Sector As Integer
    Private Tipo As Integer

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Dim tb As New TablaVaria(cn, 22, True)
        tb.EnlazarComboBox(cboAgente)

        tb = New TablaVaria(cn, 21, True)
        tb.EnlazarComboBox(cboCapacidad)

    End Sub
    Public Sub New(ByVal idPuesto As Integer)
        Me.New()

        Puesto = New Puesto2(cn)

        With Puesto
            .Abrir(idPuesto)

            txtNro.Text = .NroPuesto
            txtUbicacion.Text = .Ubicacion
            txtOrden.Text = .Orden.ToString
            cboAgente.SelectedValue = .Agente
            cboCapacidad.SelectedValue = .Capacidad

            Sector = .SectorId
            Me.Tipo = .Tipo
        End With

    End Sub
    Public Sub New(ByVal idSector As Integer, ByVal Tipo As Integer)
        Me.New()
        Me.Sector = idSector
        Me.Tipo = Tipo
    End Sub
    Private Sub frmABMPuestos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        panEquipo.Visible = (Tipo = 1)
    End Sub
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If Not EsValido() Then Exit Sub

        If Puesto Is Nothing Then
            Puesto = New Puesto2(cn)
            Puesto.Nuevo(Sector, txtNro.Text, txtUbicacion.Text, Tipo)
        End If
        Puesto.NroPuesto = txtNro.Text
        Puesto.Ubicacion = txtUbicacion.Text
        Puesto.Orden = CInt(txtOrden.Text)
        If Tipo = 1 Then
            Puesto.Agente = cboAgente.SelectedValue.ToString
            Puesto.Capacidad = cboCapacidad.SelectedValue.ToString
        End If
        Puesto.Grabar()

        Me.DialogResult = Windows.Forms.DialogResult.OK

    End Sub
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Public Function EsValido() As Boolean
        If txtNro.Text.Trim.Length <= 0 Then
            MessageBox.Show("Nro es requerido", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtNro.Focus()
            Return False
        End If

        If txtUbicacion.Text.Trim.Length <= 0 Then
            MessageBox.Show("Ubicación es requerido", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtUbicacion.Focus()
            Return False
        End If

        Return True

    End Function

End Class