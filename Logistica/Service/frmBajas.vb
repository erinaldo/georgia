Imports System.Data.OracleClient

Public Class frmBajas

    Private mac As Parque
    Private TipoManguera(2) As String
    Private Diametros(3) As Double
    Private Nominal(3) As String

    'NEW
    Public Sub New(ByVal Mac As Parque)
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        Me.mac = Mac

        TipoManguera(0) = "Sintética"
        TipoManguera(1) = "Goma"
        TipoManguera(2) = "Lino"

        Diametros(0) = 38
        Diametros(1) = 45
        Diametros(2) = 51
        Diametros(3) = 63.5

        Nominal(0) = "15 mts"
        Nominal(1) = "20 mts"
        Nominal(2) = "25 mts"
        Nominal(3) = "30 mts"

    End Sub

    'EVENTOS
    Private Sub frmBajas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim daMotivos As OracleDataAdapter
        Dim dtMotivos As New DataTable
        Dim Sql As String
        Dim dr As DataRow
        Dim LineaCero As String
        Dim Tipo As String

        Sql = "SELECT lannum_0, lanmes_0 FROM aplstd WHERE lanchp_0 = 2410 and lan_0 = 'SPA' ORDER BY lannum_0" 'AND lannum_0 > 0"
        daMotivos = New OracleDataAdapter(Sql, cn)

        Tipo = IIf(mac.EsManguera, "M", "E").ToString

        Try
            daMotivos.Fill(dtMotivos)

            'Recupero la linea 0 del menu local
            dr = dtMotivos.Rows(0)
            LineaCero = dr("lanmes_0").ToString
            dtMotivos.Rows.Remove(dr)
            dtMotivos.AcceptChanges()

            For i As Integer = dtMotivos.Rows.Count - 1 To 0 Step -1
                dr = dtMotivos.Rows(i)
                If LineaCero.Substring(i, 1) <> Tipo Then dr.Delete()
            Next
            dtMotivos.AcceptChanges()

            With lstMotivos
                .DisplayMember = "lanmes_0"
                .ValueMember = "lannum_0"
                .DataSource = dtMotivos
            End With

            'Completo los campos con los datos del equipo
            txtSerie.Text = mac.Serie
            txtCilindro.Text = mac.Cilindro
            txtEquipo.Text = mac.ArticuloDescripcion

            'Si el equipo está rechazado
            If mac.RechazoMotivo > 0 Then lstMotivos.SelectedValue = mac.RechazoMotivo

            txtObs.Text = mac.RechazoObservacion

            'Lleno el combo
            cboTipo.DataSource = TipoManguera
            'Lleno el combo de diametros
            cboDiametro.DataSource = Diametros
            'Lleno el combo de Longitudes Nominal
            cboLongitud.DataSource = Nominal
            'Lleno combo sello
            Dim mnu As New MenuLocal(cn, 1, False)
            mnu.Enlazar(cboSello)

            gbManga.Enabled = mac.EsManguera
            txtCilindro.ReadOnly = Not mac.EsManguera

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        End Try

    End Sub
    Private Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
    Private Sub btnAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If txtObs.Text.Trim = "" Then txtObs.Text = " "

        If Not IsNumeric(txtReal.Text) Then
            MessageBox.Show("Longitud Real inválida", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        Me.DialogResult = Windows.Forms.DialogResult.OK

    End Sub
    Private Sub lstMotivos_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstMotivos.SelectedValueChanged

        If CInt(lstMotivos.SelectedValue) = 2 Then
            txtObs.Text = "VER DETALLE DE CÁLCULO ADJUNTO"
        Else
            txtObs.Clear()
        End If

    End Sub
    
End Class