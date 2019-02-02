Imports System.Data.OracleClient

Public Class frmObj

    'EVENT
    Public Sub New(Optional ByVal Combo As Boolean = False)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        cboEstado.Visible = Combo

    End Sub

    Private Sub frmObj_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim da As OracleDataAdapter
        Dim dt As New DataTable
        Dim Sql As String

        Sql = "SELECT code_0, a1_0, a2_0, n1_0, n2_0, texte_0 FROM atabdiv INNER JOIN atextra ON (numtab_0 = ident1_0) AND (code_0 = ident2_0) WHERE numtab_0 = 5003 AND codfic_0 = 'ATABDIV' AND zone_0 = 'LNGDES' ORDER BY code_0"
        da = New OracleDataAdapter(Sql, cn)

        Try
            If cboEstado.Visible Then

                da.Fill(dt)


                'Enlace con el combo
                cboEstado.DataSource = dt
                cboEstado.ValueMember = "code_0"
                cboEstado.DisplayMember = "texte_0"
                cboEstado.SelectedValue = "0"
            End If

            da.Dispose()

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

End Class