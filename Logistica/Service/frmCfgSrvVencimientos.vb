Imports System.Data.OracleClient

Public Class frmCfgSrvVencimientos

    Private dtUsuarios As New DataTable
    Private WithEvents dtVendedores As New DataTable
    Private daUsuarios As OracleDataAdapter
    Private daVendedores As OracleDataAdapter

    'SUB
    Private Sub Adaptadores()
        Dim Sql As String

        Sql = "SELECT usr_0, UPPER(nomusr_0) as nomusr_0 "
        Sql &= "FROM autilis "
        Sql &= "WHERE enaflg_0 = 2 "
        Sql &= "ORDER BY nomusr_0"

        daUsuarios = New OracleDataAdapter(Sql, cn)

        'Tabla de vendedores que ve un usuario
        Sql = "SELECT usr_0, rep_0, repnam_0, abo_0, noabo_0 FROM xnetvenc, salesrep WHERE rep_0 = repnum_0 AND usr_0 = :usr_0 ORDER BY rep_0"
        daVendedores = New OracleDataAdapter(Sql, cn)

        Sql = "UPDATE xnetvenc SET abo_0 = :abo_0, noabo_0 = :noabo_0 WHERE usr_0 = :usr_0 AND rep_0 = :rep_0"
        daVendedores.UpdateCommand = New OracleCommand(Sql, cn)

        With daVendedores
            .SelectCommand.Parameters.Add("usr_0", OracleType.VarChar)

            Parametro(.UpdateCommand, "abo_0", OracleType.Int16, DataRowVersion.Current)
            Parametro(.UpdateCommand, "noabo_0", OracleType.Int16, DataRowVersion.Current)
            Parametro(.UpdateCommand, "usr_0", OracleType.VarChar, DataRowVersion.Original)
            Parametro(.UpdateCommand, "rep_0", OracleType.VarChar, DataRowVersion.Original)
        End With

    End Sub

    Private Sub frmCfg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim cm1 As New OracleCommand("DELETE FROM xnetvenc WHERE usr_0 NOT IN (SELECT usr_0 FROM xnetper WHERE fncid_0 = 8)", cn)
        Dim da1 As New OracleDataAdapter("SELECT * FROM xnetvenc ORDER BY usr_0, rep_0", cn)
        Dim da2 As New OracleDataAdapter("SELECT usr_0, repnum_0 AS rep_0 FROM salesrep, xnetper  WHERE fncid_0 = 8 and repnum_0 NOT LIKE 'C0%'", cn)
        Dim dt1 As New DataTable
        Dim dt2 As New DataTable
        Dim dr As DataRow
        Dim dv1 As DataView

        Adaptadores()

        da2.InsertCommand = New OracleCommand("INSERT INTO xnetvenc VALUES(:usr_0, :rep_0, 0, 0)", cn)

        With da2
            Parametro(.InsertCommand, "usr_0", OracleType.VarChar, DataRowVersion.Current)
            Parametro(.InsertCommand, "rep_0", OracleType.VarChar, DataRowVersion.Current)
        End With

        'Borro usuarios eliminados
        cm1.ExecuteNonQuery()

        'Cargo permisos actuales
        da1.Fill(dt1)
        dv1 = New DataView(dt1)

        'Cargo todos los permisos
        da2.Fill(dt2)

        'Comparo la tabla con permisos generales con los existentes
        For i As Integer = dt2.Rows.Count - 1 To 0 Step -1
            dr = dt2.Rows(i)

            'Filtro por usuario y vendedor
            dv1.RowFilter = String.Format("usr_0 = '{0}' AND rep_0 = '{1}'", dr("usr_0").ToString, dr("rep_0").ToString)

            If dv1.Count = 0 Then
                dr.SetAdded()
            Else
                dt2.Rows.Remove(dr)
            End If
        Next

        'Agrego registros
        da2.Update(dt2)


        'Cargo usuarios y vendedores
        daUsuarios.Fill(dtUsuarios)
        daVendedores.FillSchema(dtVendedores, SchemaType.Source)

        'Enlazo lista de usuarios
        With lstUsuarios
            .DataSource = dtUsuarios
            .DisplayMember = "nomusr_0"
            .ValueMember = "usr_0"
            .SelectedItem = Nothing
        End With

        'Enlazo grilla de vendedores
        colUsr.DataPropertyName = "usr_0"
        colRep.DataPropertyName = "rep_0"
        colNombre.DataPropertyName = "repnam_0"
        colAbo.DataPropertyName = "abo_0"
        colNoAbo.DataPropertyName = "noabo_0"
        dgvVendedores.DataSource = dtVendedores

    End Sub

    Private Sub lstUsuarios_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstUsuarios.SelectedIndexChanged
        If lstUsuarios.SelectedItem Is Nothing Then Exit Sub

        daVendedores.SelectCommand.Parameters("usr_0").Value = lstUsuarios.SelectedValue.ToString

        dtVendedores.Clear()
        daVendedores.Fill(dtVendedores)
    End Sub

    Private Sub dtVendedores_RowChanged(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs) Handles dtVendedores.RowChanged
        btnRegistrar.Enabled = True
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegistrar.Click
        daVendedores.Update(dtVendedores)
        btnRegistrar.Enabled = False
    End Sub

    Private Sub dgvVendedores_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvVendedores.CellFormatting
        If e.ColumnIndex = 3 Or e.ColumnIndex = 4 Then
            Select Case CInt(dgvVendedores.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)
                Case 0
                    e.CellStyle.BackColor = Drawing.Color.LightPink
                Case 1
                    e.CellStyle.BackColor = Drawing.Color.LightGreen
            End Select
        End If
    End Sub

    
End Class