Public Class frmMail

    Private cn As New OracleConnection(DB)
    Private daMotivos As New OracleDataAdapter

    Private dtMotivos As New DataTable
    Private dr As DataRow

    'SUBS
    Public Sub New(ByVal dr As DataRow)
        InitializeComponent()
        Me.dr = dr
    End Sub
    Private Sub Adaptadores()
        Dim Sql As String

        Sql = "SELECT to_number(code_0) as code_0, texte_0 FROM atabdiv INNER JOIN atextra ON (numtab_0 = ident1_0) AND (code_0 = ident2_0) WHERE numtab_0 = 5002 AND codfic_0 = 'ATABDIV' AND zone_0 = 'LNGDES' ORDER BY code_0"
        daMotivos.SelectCommand = New OracleCommand(Sql, cn)

    End Sub

    'EVENTOS
    Private Sub frmMail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Adaptadores()

        Try
            cn.Open()

            daMotivos.Fill(dtMotivos)

            With lstMotivos
                .DataSource = dtMotivos
                .ValueMember = "code_0"
                .DisplayMember = "texte_0"
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub
    Private Sub frmMail_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If cn.State = ConnectionState.Open Then cn.Close()
        cn.Dispose()
        daMotivos.Dispose()
        dtMotivos.Dispose()
    End Sub

End Class