Imports System.Data.OracleClient

Public Class frmPermisos

    Private Modificado As Boolean = False

    Private daUsr As New OracleDataAdapter("SELECT xus.usr_0, UPPER(nomusr_0) as nomusr_0 FROM xnetusr xus INNER JOIN autilis aut on (xus.usr_0 = aut.usr_0) ORDER BY nomusr_0", cn)
    Private daFnc As New OracleDataAdapter("SELECT * FROM xnetfnc ORDER BY descripcio_0", cn)
    Private daPer As New OracleDataAdapter("SELECT * FROM xnetper WHERE usr_0 = :p1", cn)
    Private dtUsr As New DataTable
    Private dtFnc As New DataTable
    Private dtPer As New DataTable

    'SUBS
    Private Sub Adaptadores()
        daPer.SelectCommand.Parameters.Add("p1", OracleType.Varchar)
        daPer.InsertCommand = New OracleCommandBuilder(daPer).GetInsertCommand
        daPer.DeleteCommand = New OracleCommand("DELETE FROM xnetper WHERE usr_0 = :p1 and fncid_0 = :p2", cn)
        With daPer.DeleteCommand.Parameters.Add("p1", OracleType.Varchar)
            .SourceColumn = "usr_0"
            .SourceVersion = DataRowVersion.Original
        End With
        With daPer.DeleteCommand.Parameters.Add("p2", OracleType.Number)
            .SourceColumn = "fncid_0"
            .SourceVersion = DataRowVersion.Original
        End With

    End Sub
    Private Sub ArmarArbol()
        Dim dv As New DataView(dtFnc)
        Dim tnd As TreeNode
        Dim tnd2 As TreeNode
        Dim i As Integer

        'Consulto funciones principales
        dv.RowFilter = "padre_0 = 0"

        tree.Nodes.Clear()

        For i = 0 To dv.Count - 1
            tnd = New TreeNode
            tnd.Name = dv.Item(i).Item("fncid_0").ToString
            tnd.Text = dv.Item(i).Item("descripcio_0").ToString
            tree.Nodes.Add(tnd)
        Next

        'Consulto funciones secundarias
        For Each tnd In tree.Nodes
            dv.RowFilter = "padre_0 = " & tnd.Name

            For i = 0 To dv.Count - 1
                tnd2 = New TreeNode
                tnd2.Name = dv.Item(i).Item("fncid_0").ToString
                tnd2.Text = dv.Item(i).Item("descripcio_0").ToString
                tnd.Nodes.Add(tnd2)
            Next
        Next

        'Expando todo el arbol
        tree.ExpandAll()

        tnd = Nothing
        tnd2 = Nothing
        dv.Dispose() : dv = Nothing

    End Sub
    Private Sub MarcarPermisos()
        Dim ndo1 As TreeNode
        Dim ndo2 As TreeNode
        Dim dv As New DataView(dtPer)

        'Tildo los nodos de las funciones principales
        For Each ndo1 In tree.Nodes
            dv.RowFilter = "fncid_0 = " & ndo1.Name

            If dv.Count = 1 Then
                ndo1.Checked = (dv.Count = 1)
                ndo1.Tag = dv(0).Item(2).ToString
            End If

            'Tildo los nodos de las funciones secundarias
            For Each ndo2 In ndo1.Nodes
                dv.RowFilter = "fncid_0 = " & ndo2.Name

                If dv.Count = 1 Then
                    ndo2.Checked = (dv.Count = 1)
                    ndo2.Tag = dv(0).Item(2).ToString
                End If
            Next
        Next

    End Sub
    Private Sub GrabarCambios()
        Dim dr As DataRow
        Dim ndo As TreeNode

        'Borro todos los registros de la tabla de permisos
        For Each dr In dtPer.Rows
            dr.Delete()
        Next

        'Agrego las funciones primarias con check activado
        For Each ndo In tree.Nodes
            If ndo.Checked Then
                dr = dtPer.NewRow
                dr("usr_0") = daPer.SelectCommand.Parameters("p1").Value
                dr("fncid_0") = ndo.Name
                If ndo.Tag Is Nothing Then
                    dr("flags_0") = " "
                Else
                    dr("flags_0") = ndo.Tag.ToString
                End If

                dtPer.Rows.Add(dr)

                'Agrego las funciones secundarias con check activado
                For i As Integer = 0 To ndo.Nodes.Count - 1
                    If ndo.Nodes(i).Checked Then
                        dr = dtPer.NewRow
                        dr("usr_0") = daPer.SelectCommand.Parameters("p1").Value
                        dr("fncid_0") = ndo.Nodes(i).Name
                        If ndo.Nodes(i).Tag Is Nothing Then
                            dr("flags_0") = " "
                        Else
                            dr("flags_0") = ndo.Nodes(i).Tag.ToString
                        End If
                        dtPer.Rows.Add(dr)
                    End If
                Next
            End If
        Next

        Try
            daPer.Update(dtPer)
            Modificado = False

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        ActivarBotones()

    End Sub
    Private Sub ActivarBotones()
        btnRegistrar.Enabled = Modificado
    End Sub

    'EVENTOS
    Private Sub frmPermisos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim HayError As Boolean = False

        Adaptadores()

        Try
            daUsr.Fill(dtUsr)
            daFnc.Fill(dtFnc)

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        If HayError Then Exit Sub

        'Enlazo combo
        With lstUsuarios
            .DataSource = dtUsr
            .DisplayMember = "nomusr_0"
            .ValueMember = "usr_0"
        End With

    End Sub
    Private Sub frmPermisos_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Modificado Then
            Select Case MessageBox.Show("¿Graba los cambios antes de salir?", Me.Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                Case Windows.Forms.DialogResult.Yes
                    GrabarCambios()

                Case Windows.Forms.DialogResult.Cancel
                    e.Cancel = True

            End Select
        End If
    End Sub
    Private Sub frmPermisos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        dtUsr.Dispose()
        dtFnc.Dispose()
        dtPer.Dispose()
        daUsr.Dispose()
        daFnc.Dispose()

    End Sub
    Private Sub tree_AfterCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tree.AfterCheck
        'Si el nodo se destilda, destildo los nodos hijos
        If e.Action <> TreeViewAction.Unknown And e.Node.Checked = False Then
            For i = 0 To e.Node.Nodes.Count - 1
                e.Node.Nodes(i).Checked = False
            Next

        End If

        If e.Action <> TreeViewAction.Unknown Then
            Modificado = True
            ActivarBotones()
        End If

    End Sub
    Private Sub tree_BeforeCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles tree.BeforeCheck
        'No se permite tildar un nodo hijo si el padre no está tildado
        If e.Action <> TreeViewAction.Unknown Then
            If e.Node.Parent IsNot Nothing Then
                e.Cancel = Not e.Node.Parent.Checked
            End If
        End If
    End Sub

    Private Sub btnRegistrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegistrar.Click
        GrabarCambios()
    End Sub
    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
    Private Sub lstUsuarios_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstUsuarios.SelectedIndexChanged
        If lstUsuarios.SelectedItem Is Nothing Then Exit Sub

        Dim drv As DataRowView

        'Consulto permisos del usuario seleccionado
        drv = CType(lstUsuarios.SelectedItem, DataRowView)
        daPer.SelectCommand.Parameters("p1").Value = drv("usr_0").ToString
        dtPer.Rows.Clear()
        daPer.Fill(dtPer)

        ArmarArbol()
        MarcarPermisos()

        Modificado = False
        ActivarBotones()

    End Sub

    'CONTEXT MENU
    Private Sub ContextMenuStrip1_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        e.Cancel = (tree.SelectedNode Is Nothing)

        Dim n As TreeNode = tree.SelectedNode

        mnuEliminarPermisoSecundario.Enabled = Not (n.Tag Is Nothing OrElse n.Tag.ToString.Trim = "")

    End Sub
    Private Sub mnuPermisosSecundarios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPermisosSecundarios.Click
        Dim n As TreeNode = tree.SelectedNode
        Dim txt As String

        If n.Tag Is Nothing Then
            txt = ""
        Else
            txt = n.Tag.ToString
        End If

        txt = InputBox("¿Ingrese los permisos secundarios?", Me.Text, txt)
        txt = Trim(txt)
        If txt <> "" Then
            n.Tag = Strings.Left(txt, 10)
            Modificado = True
            ActivarBotones()
        End If

    End Sub
    Private Sub mnuEliminarPermisoSecundario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEliminarPermisoSecundario.Click
        Dim n As TreeNode = tree.SelectedNode

        If MessageBox.Show("¿Confirma la eliminacion de los permisos secundarios?", Me.Text, MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            n.Tag = " "
            Modificado = True
            ActivarBotones()
        End If

    End Sub

End Class