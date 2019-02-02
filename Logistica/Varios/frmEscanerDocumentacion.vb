Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO

Public Class frmEscanerDocumentacion
    Const PATH_ORIGEN As String = "z:\Remitos\RemGab\"
    Const PATH_ORIGEN_ARCHIVO As String = "z:\Remitos\RemArch\"
    Const PATH_DESTINO As String = "z:\Remitos\"

    Private Sub Procesar()
        Dim Archivos() As String
        Dim a() As String
        Dim b As String 'nombre del archivo
        Dim flg As Boolean = False

        lst.Items.Clear()

        'Obtengo todos los archivos
        If usr.Codigo = "FCOL" Then 'se ua el codigo de fcolon
            Archivos = Directory.GetFiles(PATH_ORIGEN_ARCHIVO)
        Else
            Archivos = Directory.GetFiles(PATH_ORIGEN)
        End If
        
        For Each Archivo As String In Archivos
            a = Split(Archivo, "\")
            b = a(a.Length - 1)

            flg = True 'Activo error

            If b.Length = 15 Then
                Dim itn As New Intervencion(cn)

                If itn.Abrir(b.Substring(0, 11)) Then
                    If usr.Codigo = "FCOL" Then 'se ua el codigo de fcolon
                        ProcesarIntervencionArchivo(itn)
                    Else
                        ProcesarIntervencion(itn)
                    End If

                    flg = False 'Desactivo error
                End If

            ElseIf b.Length = 22 Then
                Dim rto As New Remito(cn)

                If rto.Abrir(b.Substring(0, 18)) Then
                    If usr.Codigo = "FCOL" Then 'se ua el codigo de fcolon
                        ProcesarRemitoArchivo(rto)
                    Else
                        ProcesarRemito(rto)
                    End If

                    flg = False 'Desactivo error

                Else
                    Dim itn As New Intervencion(cn)

                    If itn.AbrirRemito(b.Substring(0, 18)) Then
                        If usr.Codigo = "FCOL" Then 'se ua el codigo de fcolon
                            ProcesarIntervencionArchivo(itn)
                        Else
                            ProcesarIntervencion(itn)
                        End If

                        flg = False 'Desactivo error
                    End If

                End If
            End If
            If usr.Codigo = "FCOL" Then 'se ua el codigo de fcolon
                If Not flg Then

                    MoverArchivo(PATH_ORIGEN_ARCHIVO & b, PATH_DESTINO & b)

                Else
                    lst.Items.Add(b)
                End If
            Else
                If Not flg Then

                    MoverArchivo(PATH_ORIGEN & b, PATH_DESTINO & b)

                Else
                    lst.Items.Add(b)
                End If
            End If
        Next

    End Sub
    Private Sub MoverArchivo(ByVal Origen As String, ByVal Destino As String)
        Try

            If Not File.Exists(Destino) Then
                File.Copy(Origen, Destino)
            End If

            File.Delete(Origen)

        Catch ex As Exception

        End Try
    End Sub
    Private Sub ProcesarIntervencion(ByVal itn As Intervencion)
        Dim sto As Seguimiento

        sto = itn.Seguimiento

        If sto.UltimoSectorDestino = "ADM" Then
            sto.MarcarTodoRecibido(usr.Codigo)
            sto.Grabar()
        Else
            sto.EnviarA("ADM", usr.Codigo, True)
        End If

        ImprimeIram(itn)

    End Sub
    Private Sub ProcesarIntervencionArchivo(ByVal itn As Intervencion)
        Dim sto As Seguimiento

        sto = itn.Seguimiento

        If sto.UltimoSectorDestino = "ACH" Then
            sto.MarcarTodoRecibido(usr.Codigo)
            sto.Grabar()
        Else
            sto.EnviarA("ACH", usr.Codigo, True)
        End If

        ImprimeIram(itn)

    End Sub
    Private Sub ProcesarRemito(ByVal rto As Remito)
        Dim sto As Seguimiento

        sto = rto.Seguimiento

        If sto.UltimoSectorDestino = "ADM" Then
            sto.MarcarTodoRecibido(usr.Codigo)
            sto.Grabar()
        Else
            sto.EnviarA("ADM", usr.Codigo, True)
        End If

    End Sub
    Private Sub ProcesarRemitoArchivo(ByVal rto As Remito)
        Dim sto As Seguimiento

        sto = rto.Seguimiento

        If sto.UltimoSectorDestino = "ACH" Then
            sto.MarcarTodoRecibido(usr.Codigo)
            sto.Grabar()
        Else
            sto.EnviarA("ACH", usr.Codigo, True)
        End If

    End Sub
    Private Sub ImprimeIram(ByVal itn As Intervencion)
        Dim rpt As ReportDocument
        Dim suc As New Sucursal(cn)

        'Controles antes de imprimir
        If itn.Cliente.EsAbonado Then Exit Sub
        If itn.Estado <> 5 Then Exit Sub
        If itn.Tipo <> "A1" Then Exit Sub
        'agregado a pedido de Isa 26-09-2018
        If Not itn.ExisteArticulo("652001") Then Exit Sub

        'Abro informacion de la sucursal
        suc.Abrir(itn.Cliente.Codigo, itn.SucursalCodigo)

        Try
            rpt = New ReportDocument

            If suc.CumpleIram = False Then
                rpt.Load(RPTX3 & "XCTRL.rpt")
                rpt.SetDatabaseLogon(DB_USR, DB_PWD)
                rpt.SetParameterValue("BPC", itn.Cliente.Codigo)
                rpt.SetParameterValue("ADD", itn.SucursalCodigo)
            Else
                rpt.Load(RPTX3 & "XCTRLPE2B_2.rpt")
                rpt.SetDatabaseLogon(DB_USR, DB_PWD)
                rpt.SetParameterValue("ITN", itn.Numero)
                rpt.SetParameterValue("OBS", " ")
            End If

            rpt.PrintToPrinter(1, False, 1, 100)

            rpt.Dispose()

        Catch ex As Exception
        End Try

    End Sub

    Private Sub btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn.Click
        btn.Enabled = False
        Procesar()
        MessageBox.Show("Proceso finalizado", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        btn.Enabled = True
    End Sub

    Private Sub ContextMenuStrip1_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        mnuVer.Enabled = lst.SelectedItems.Count = 1
        mnuEliminar.Enabled = lst.SelectedItems.Count > 0
        mnuRenombrar.Enabled = lst.SelectedItems.Count = 1
    End Sub

    Private Sub mnuVer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuVer.Click
        Try
            Dim Archivo As String = CType(lst.SelectedItems(0), String)

            Process.Start(PATH_ORIGEN & Archivo)

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub
    Private Sub mnuRenombrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRenombrar.Click
        Dim newName As String
        Dim oldName As String

        oldName = CType(lst.SelectedItem, String)
        newName = InputBox("Ingrese el nombre del archivo", Me.Text, oldName)

        Try
            If newName.Trim <> "" Then
                FileSystem.Rename(PATH_ORIGEN & oldName, PATH_ORIGEN & newName)
                Procesar()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub
    Private Sub mnuEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEliminar.Click
        Dim Archivo As String

        Try
            Archivo = CType(lst.SelectedItems(0), String)

            If MessageBox.Show("¿Confirma eliminar el archivo " & Archivo & "?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                File.Delete(PATH_ORIGEN & Archivo)
                lst.Items.Remove(lst.SelectedItems(0))
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

End Class