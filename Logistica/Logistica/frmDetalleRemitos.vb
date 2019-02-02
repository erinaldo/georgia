Imports System.Data.OracleClient

Public Class frmDetalleRemitos
    Private Doc As IRuteable
    Private da As OracleDataAdapter
    Private dt As New DataTable
    Private Ruta As Integer

    Public Sub New(ByVal Doc As IRuteable, ByVal Ruta As Integer)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Dim Sql As String

        Me.Doc = Doc
        Me.Ruta = ruta

        Sql = "SELECT mac.macnum_0, cpnitmref_0, ymc.datnext_0, mac.macqty_0, mac.macpdtcod_0, itmma.itmdes1_0 "
        Sql &= "FROM machines mac INNER JOIN ymacitm ymc ON (mac.macnum_0 = ymc.macnum_0) INNER JOIN itmmaster itmma ON (ymc.cpnitmref_0 = itmma.itmref_0) "
        Sql &= "WHERE (ymc.cpnitmref_0 = '551003' OR ymc.cpnitmref_0 = '551015') AND mac.bpcnum_0 = :bpcnum_0 AND mac.fcyitn_0 = :fcyitn_0"
        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("bpcnum_0", OracleType.VarChar)
        da.SelectCommand.Parameters.Add("fcyitn_0", OracleType.VarChar)

    End Sub
    Private Sub frmDetalleRemitos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        txtnro.Text = Doc.Numero
        txtbcliente.Text = Doc.Cliente.Codigo
        txtbsuc.Text = Doc.Sucursal.Sucursal

        Cargar()

        'Vuelvo a cargar si hubo division de Parque
        If DividirParque() Then Cargar()

    End Sub
    Private Sub Cargar()
        da.SelectCommand.Parameters("bpcnum_0").Value = txtbcliente.Text
        da.SelectCommand.Parameters("fcyitn_0").Value = txtbsuc.Text

        dt.Clear()
        da.Fill(dt)

        If dgv.DataSource Is Nothing Then
            colNumero.DataPropertyName = "macnum_0"
            colComponente.DataPropertyName = "cpnitmref_0"
            colFecha.DataPropertyName = "datnext_0"
            colCantidad.DataPropertyName = "macqty_0"
            colCodigo.DataPropertyName = "macpdtcod_0"
            colDescripcion.DataPropertyName = "itmdes1_0"
            dgv.DataSource = dt
        End If

    End Sub
    Private Function DividirParque() As Boolean
        Dim dr As DataRow
        Dim mac As New Parque(cn)
        Dim flg As Boolean = False

        For Each dr In dt.Rows

            If CInt(dr("macqty_0")) = 1 Then Continue For
            flg = True

            mac.Abrir(dr("macnum_0").ToString)

            For i = 1 To mac.Cantidad - 1
                NuevoParque(CDate(dr("datnext_0")))
            Next

            mac.Cantidad = 1
            mac.Grabar()

        Next

        Return flg 'Devuelvo True si al menos se dividio un parque

    End Function
    Private Sub NuevoParque(ByVal Fecha As Date)
        Dim mac As New Parque(cn)

        mac.Nuevo(txtbcliente.Text, txtbsuc.Text)
        mac.ArticuloCodigo = "991015"
        mac.Cantidad = 1
        mac.VtoCarga = Fecha
        mac.FabricacionCorto = Today.Year
        mac.Grabar()

    End Sub
    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub ContextMenuStrip1_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        mnuBorrar.Enabled = dgv.SelectedRows.Count > 0
        mnuFecha.Enabled = dgv.SelectedRows.Count > 0
    End Sub
    Private Sub ModificarFechaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFecha.Click
        Dim f As New frmfecha
        Dim p As New Parque(cn)
        Dim macnum As String = dgv.CurrentRow.Cells("colNumero").Value.ToString

        p.Abrir(macnum)

        f.Fecha = p.VtoCarga
        f.ShowDialog(Me)

        If f.DialogResult = Windows.Forms.DialogResult.OK Then
            p.VtoCarga = f.Fecha
            p.MarcaIntervencion = ""
            p.Grabar()

            Cargar()
        End If

        f.Dispose()

    End Sub
    Private Sub mnuAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAgregar.Click

        Dim f As New frmfecha
        f.Fecha = Date.Today
        f.ShowDialog()

        If f.DialogResult = Windows.Forms.DialogResult.OK Then
            NuevoParque(f.Fecha)
            Cargar()
        End If

        f.Dispose()

    End Sub
    Private Sub mnuBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuBorrar.Click
        Dim txt As String
        Dim mac As New Parque(cn)
        Dim dr As DataRow

        If MessageBox.Show("¿Confirma la eliminación?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            dr = CType(dgv.CurrentRow.DataBoundItem, DataRowView).Row

            txt = dr("macnum_0").ToString

            If mac.Abrir(txt) Then
                mac.Borrar()
                dt.Rows.Remove(dr)
            End If
        End If
    End Sub

End Class