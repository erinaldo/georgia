Imports System.Data.OracleClient

Public Class frmFletesTarifas
    Private da1 As OracleDataAdapter
    Private dt1 As DataTable
    Private ds As DataSet

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Adaptadores()

    End Sub
    Private Sub Adaptadores()
        Dim Sql As String

        Sql = "SELECT * FROM xtarflete ORDER BY kg_0"
        da1 = New OracleDataAdapter(Sql, cn)

        With da1
            .InsertCommand = New OracleCommandBuilder(da1).GetInsertCommand
            .UpdateCommand = New OracleCommandBuilder(da1).GetUpdateCommand
            .DeleteCommand = New OracleCommandBuilder(da1).GetDeleteCommand
        End With

    End Sub

    Private Sub frmFletesTarifas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ds = New DataSet
        dt1 = New DataTable
        ds.Tables.Add(dt1)

        Try
            da1.Fill(dt1)

            colKg.DataPropertyName = "kg_0"
            colCFEint.DataPropertyName = "cfe_0"
            colGBAint.DataPropertyName = "gba_0"
            colCFEext.DataPropertyName = "cfe_1"
            colGBAext.DataPropertyName = "gba_1"

            dgv.DataSource = dt1

        Catch ex As Exception
            btnAceptar.Enabled = False
            dgv.Enabled = False
        End Try
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        Try
            Grabar()
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Dim d As DialogResult
        Dim txt As String = "¿Desea guardar los cambios?"

        If ds.HasChanges Then
            d = MessageBox.Show(txt, Me.Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

            Select Case d
                Case Windows.Forms.DialogResult.Yes
                    Try
                        Grabar()
                        Me.Close()
                    Catch ex As Exception
                        MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                    
                Case Windows.Forms.DialogResult.No
                    Me.Close()
            End Select
        Else
            Grabar()
            Me.Close()
        End If

    End Sub
    Private Sub Grabar()
        da1.Update(dt1)
    End Sub

End Class