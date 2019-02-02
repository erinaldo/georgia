Imports System.Data.OracleClient

Public Class frmDocEnRuta
    Public Motivo As Integer = 0
    Private daMotivos As New OracleDataAdapter("SELECT to_number(code_0) as code_0, a1_0, a2_0, n1_0, n2_0, texte_0 FROM atabdiv INNER JOIN atextra ON (numtab_0 = ident1_0) AND (code_0 = ident2_0) WHERE numtab_0 = 5000 AND codfic_0 = 'ATABDIV' AND zone_0 = 'LNGDES' AND code_0 > 1 ORDER BY code_0", cn)
    Private dtMotivos As New DataTable

    'CONSTRUCTORES
    Public Sub New(ByVal Documento As String, ByVal Ruta As String)
        Me.new()

        txtDocumento.Text = Documento
        txtRuta.Text = Ruta
    End Sub
    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    'EVENTOS
    Private Sub frmDocEnRuta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RadioButton1.Focus()

        'Cargo combo de No Conformidades
        daMotivos.Fill(dtMotivos)

        'Enlazo Combo a origen de datos
        cboMotivos.DataSource = dtMotivos
        cboMotivos.DisplayMember = "texte_0"
        cboMotivos.ValueMember = "code_0"

    End Sub
    Private Sub frmDocEnRuta_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        daMotivos.Dispose() : daMotivos = Nothing
        dtMotivos.Dispose() : dtMotivos = Nothing
    End Sub
    Private Sub RadioButton3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton3.CheckedChanged
        cboMotivos.Enabled = CType(sender, RadioButton).Checked
    End Sub
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        If RadioButton1.Checked Then
            'Se eligio no hacer nada
            Me.DialogResult = Windows.Forms.DialogResult.Cancel

        ElseIf RadioButton2.Checked Then
            'Se eligió cambio de ruta. 
            Me.DialogResult = Windows.Forms.DialogResult.Yes

        ElseIf RadioButton3.Checked Then
            'Se eligio poner en nueva ruta y registrar un motivo de rebote
            Dim dr As DataRowView = CType(cboMotivos.SelectedItem, DataRowView)
            Motivo = CType(dr("code_0"), Integer)

            Me.DialogResult = Windows.Forms.DialogResult.No

        End If

    End Sub

End Class