Imports Microsoft.Win32
Imports System.Data.OracleClient

Public Class frmCfgSrvIram

    Private RegKey As RegistryKey
    Private dt As New DataTable

    'SUB
    Private Sub ObtenerConfiguracion()
        Dim da As OracleDataAdapter
        Dim Dato As Object

        da = New OracleDataAdapter("SELECT fcy_0, '' AS impresora FROM facility", cn)
        da.Fill(dt)

        'Busco en el registro las impresoras para cada planta
        For Each dr As DataRow In dt.Rows
            Dato = RegKey.GetValue(dr("fcy_0").ToString)

            dr.BeginEdit()
            If Dato Is Nothing Then
                dr("impresora") = ""
            Else
                dr("impresora") = Dato.ToString
            End If
            dr.EndEdit()

        Next

        dt.AcceptChanges()

        da.Dispose()

    End Sub

    'EVENTOS
    Private Sub frmCfgSrvIram_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            'Creo o abro clave del registro
            RegKey = Registry.CurrentUser.OpenSubKey("Software", True).CreateSubKey("Georgia").CreateSubKey("IRAMv2")

            ObtenerConfiguracion()

            'Vincular grilla con datatable
            colPlanta.DataPropertyName = "fcy_0"
            colImpresora.DataPropertyName = "impresora"
            dgv.DataSource = dt

            btnAceptar.Enabled = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub
    Private Sub frmCfgSrvIram_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            RegKey.Close()
            dt.Dispose()

        Catch ex As Exception

        End Try

    End Sub
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        Try
            For Each dr As DataRow In dt.Rows
                RegKey.SetValue(dr("fcy_0").ToString, dr("impresora").ToString.Trim)
            Next

            Me.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

End Class