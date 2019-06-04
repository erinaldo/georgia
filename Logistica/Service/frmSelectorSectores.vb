Imports Clases

Public Class frmSelectorSectores
    Private Sectores As New Sectores2(cn)

    Public Sub New(ByVal Cli As String, ByVal Suc As String)
        InitializeComponent()

        Sectores.Abrir(Cli, Suc)

    End Sub
    Private Sub frmSelectorSectores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With lstSectores
            .ValueMember = "id_0"
            .DisplayMember = "sector_0"
            .DataSource = Sectores.dt
        End With
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class