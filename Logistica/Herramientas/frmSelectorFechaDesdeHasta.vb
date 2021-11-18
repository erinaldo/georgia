Public Class frmSelectorFechaDesdeHasta
    Public Property Desde() As Date
        Get
            Return dtpDesde.Value
        End Get
        Set(ByVal value As Date)
            dtpDesde.Value = value
        End Set
    End Property
    Public Property Hasta() As Date
        Get
            Return dtpHasta.Value
        End Get
        Set(ByVal value As Date)
            dtpHasta.Value = value
        End Set
    End Property
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
End Class