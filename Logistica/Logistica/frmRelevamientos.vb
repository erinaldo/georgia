Imports System.Data.OracleClient

Public Class frmRelevamientos

    Private Sub ListarRelevamientos(ByVal Procesados As Boolean)
        Dim txt As String
        Dim NodoRuta As TreeNode = Nothing
        Dim NodoCliente As TreeNode = Nothing
        Dim NodoSucursal As TreeNode = Nothing
        Dim da As OracleDataAdapter
        Dim dt As New DataTable
        Dim dr As DataRow

        If Procesados Then
            txt = "SELECT DISTINCT ruta_0, x.bpcnum_0, bpcnam_0, fcyitn_0, bpaaddlig_0 "
            txt &= "FROM (xrelev x INNER JOIN bpcustomer bpc ON (x.bpcnum_0 = bpc.bpcnum_0)) INNER JOIN bpaddress bpa ON (bpc.bpcnum_0 = bpa.bpanum_0 AND fcyitn_0 = bpaadd_0) "
            txt &= "WHERE procesado_0 = 2 "
            txt &= "ORDER BY ruta_0, x.bpcnum_0, fcyitn_0"

        Else
            txt = "SELECT DISTINCT ruta_0, x.bpcnum_0, bpcnam_0, fcyitn_0, bpaaddlig_0 "
            txt &= "FROM (xrelev x INNER JOIN bpcustomer bpc ON (x.bpcnum_0 = bpc.bpcnum_0)) INNER JOIN bpaddress bpa ON (bpc.bpcnum_0 = bpa.bpanum_0 AND fcyitn_0 = bpaadd_0) "
            txt &= "WHERE procesado_0 <> 2 "
            txt &= "ORDER BY ruta_0, x.bpcnum_0, fcyitn_0"

        End If

        da = New OracleDataAdapter(txt, cn)
        da.Fill(dt)

        treeRelevamientos.Nodes.Clear()

        For Each dr In dt.Rows
            If NodoRuta Is Nothing OrElse CInt(NodoRuta.Tag) <> CInt(dr("ruta_0")) Then
                txt = dr("ruta_0").ToString

                NodoRuta = treeRelevamientos.Nodes.Add(txt)
                NodoRuta.Tag = CInt(dr("ruta_0"))

                NodoCliente = Nothing
            End If

            If NodoCliente Is Nothing OrElse NodoCliente.Tag.ToString <> dr("bpcnum_0").ToString Then

                txt = dr("bpcnum_0").ToString & " " & dr("bpcnam_0").ToString
                NodoCliente = NodoRuta.Nodes.Add(txt)
                NodoCliente.Tag = dr("bpcnum_0").ToString

            End If

            txt = dr("fcyitn_0").ToString & " " & dr("bpaaddlig_0").ToString
            'Agrego la sucursal
            With NodoCliente.Nodes.Add(txt)
                .Tag = dr("fcyitn_0").ToString
            End With

        Next

        da.Dispose()
        dt.Dispose()

        treeRelevamientos.ExpandAll()

    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked Then
            treeRelevamientos.CheckBoxes = True
            ListarRelevamientos(False)
        End If
    End Sub
    Private Sub RadioButton2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked Then
            treeRelevamientos.CheckBoxes = False
            ListarRelevamientos(True)
        End If
    End Sub

    Private Sub treeRelevamientos_AfterCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles treeRelevamientos.AfterCheck
        If e.Node.Level < 2 Then
            Dim Nodo As TreeNode

            For Each Nodo In e.Node.Nodes
                Nodo.Checked = e.Node.Checked
            Next

        End If

    End Sub
    Private Sub treeRelevamientos_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles treeRelevamientos.AfterSelect
        Dim txt As String
        Dim da As OracleDataAdapter
        Dim dt As DataTable

        If e.Node.Level = 2 Then
            txt = "SELECT * "
            txt &= "FROM xrelev "
            txt &= "WHERE ruta_0 = :ruta_0 AND bpcnum_0 = :bpcnum_0 AND fcyitn_0 = :fcyitn_0 "
            txt &= "ORDER BY tiporeg_0"

            dt = New DataTable

            da = New OracleDataAdapter(txt, cn)
            With da.SelectCommand.Parameters
                .Add("ruta_0", OracleType.Number).Value = CInt(e.Node.Parent.Parent.Tag)
                .Add("bpcnum_0", OracleType.VarChar).Value = e.Node.Parent.Tag.ToString
                .Add("fcyitn_0", OracleType.VarChar).Value = e.Node.Tag.ToString
            End With
            da.Fill(dt)
            da.Dispose()

            dgv.DataSource = dt

        Else
            dgv.DataSource = Nothing

        End If

    End Sub

    Private Sub btnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizar.Click
        Dim Nodo As TreeNode

        btnActualizar.Enabled = False
        Me.UseWaitCursor = True

        For Each Nodo In treeRelevamientos.Nodes
            RecorrerArbol(Nodo)
        Next

        ListarRelevamientos(False)

        btnActualizar.Enabled = True
        Me.UseWaitCursor = False

        MessageBox.Show("Proceso finalizado", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub RecorrerArbol(ByVal Nodo As TreeNode)
        Dim n As TreeNode

        If Nodo.Nodes.Count > 0 Then
            For Each n In Nodo.Nodes
                RecorrerArbol(n)
            Next

        Else
            If Nodo.Level = 2 AndAlso Nodo.Checked Then
                ProcesarSectores(CInt(Nodo.Parent.Parent.Tag), Nodo.Parent.Tag.ToString, Nodo.Tag.ToString)
                ProcesarParque(CInt(Nodo.Parent.Parent.Tag), Nodo.Parent.Tag.ToString, Nodo.Tag.ToString)
                ProcesarPuestos(CInt(Nodo.Parent.Parent.Tag), Nodo.Parent.Tag.ToString, Nodo.Tag.ToString)
                MarcarComoProcesado(CInt(Nodo.Parent.Parent.Tag), Nodo.Parent.Tag.ToString, Nodo.Tag.ToString)
            End If

        End If

    End Sub
    Private Sub ProcesarSectores(ByVal Ruta As Integer, ByVal Cliente As String, ByVal Sucursal As String)
        Dim da As OracleDataAdapter
        Dim txt As String
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim ss As New Sector(cn)
        Dim cm As OracleCommand

        'Comando para actualizar los sectores en los puestos
        txt = "UPDATE xrelev SET sector_0 = :sector_new WHERE sector_0 = :sector_old"
        cm = New OracleCommand(txt, cn)
        With cm.Parameters
            .Add("sector_new", OracleType.VarChar)
            .Add("sector_old", OracleType.VarChar)
        End With

        txt = "SELECT * "
        txt &= "FROM xrelev "
        txt &= "WHERE ruta_0 = :ruta_0 AND bpcnum_0 = :bpcnum_0 AND fcyitn_0 = :fcyitn_0 AND tiporeg_0 = 1"

        da = New OracleDataAdapter(txt, cn)
        With da.SelectCommand.Parameters
            .Add("ruta_0", OracleType.Number).Value = Ruta
            .Add("bpcnum_0", OracleType.VarChar).Value = Cliente
            .Add("fcyitn_0", OracleType.VarChar).Value = Sucursal
        End With

        da.Fill(dt)
        da.Dispose()

        'Recorro todos los sectores
        For Each dr In dt.Rows

            If CInt(dr("nuevo_0")) = 1 Then 'El sector es nuevo
                With ss
                    .Nuevo()
                    .Cliente = dr("bpcnum_0").ToString
                    .Sucursal = dr("fcyitn_0").ToString
                    .Nombre = dr("sectorn_0").ToString
                    .Grabar()
                End With

                'Modifico ID de los puestos
                cm.Parameters("sector_old").Value = CLng(dr("idsector_0"))
                cm.Parameters("sector_new").Value = ss.ID
                cm.ExecuteNonQuery()

            Else    'Actualizo sector
                With ss
                    If .Abrir(CLng(dr("idsector_0"))) Then
                        ss.Nombre = dr("sectorn_0").ToString
                        ss.Grabar()
                    End If
                End With
            End If

        Next

        dt.Dispose()

    End Sub
    Private Sub ProcesarParque(ByVal Ruta As Integer, ByVal Cliente As String, ByVal Sucursal As String)
        Dim da As OracleDataAdapter
        Dim txt As String
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim mac As New Parque(cn)
        Dim cm As OracleCommand

        'Comando para actualizar series en los puestos
        txt = "UPDATE xrelev SET serie_0 = :serie_new WHERE serie_0 = :serie_old"
        cm = New OracleCommand(txt, cn)
        With cm.Parameters
            .Add("serie_new", OracleType.VarChar)
            .Add("serie_old", OracleType.VarChar)
        End With

        txt = "SELECT * "
        txt &= "FROM xrelev "
        txt &= "WHERE ruta_0 = :ruta_0 AND bpcnum_0 = :bpcnum_0 AND fcyitn_0 = :fcyitn_0 AND tiporeg_0 = 2"

        da = New OracleDataAdapter(txt, cn)
        With da.SelectCommand.Parameters
            .Add("ruta_0", OracleType.Number).Value = Ruta
            .Add("bpcnum_0", OracleType.VarChar).Value = Cliente
            .Add("fcyitn_0", OracleType.VarChar).Value = Sucursal
        End With

        da.Fill(dt)
        da.Dispose()

        'Recorro todos los sectores
        For Each dr In dt.Rows

            If dr("macnum_0").ToString.StartsWith("N") Then 'El parque es nuevo
                mac.Nuevo(dr("bpcnum_0").ToString, dr("fcyitn_0").ToString)
                mac.ArticuloCodigo = dr("macpdtcod_0").ToString
                mac.Cilindro = dr("ynrocil_0").ToString
                mac.FabricacionCorto = CDate(dr("yfabdat_0")).Year
                mac.VtoCarga = CDate(dr("vto_0"))
                If mac.TienePh Then
                    mac.VtoPH = CDate(dr("vtoph_0"))
                End If
                mac.Grabar()

                'Modifico Series en los puestos
                cm.Parameters("serie_old").Value = dr("macnum_0").ToString
                cm.Parameters("serie_new").Value = mac.Serie
                cm.ExecuteNonQuery()

            Else    'Actualizo parque
                If dr("macnum_0").ToString = "00712989" Then Stop

                If mac.Abrir(dr("macnum_0").ToString) Then

                    If mac.ArticuloCodigo <> dr("macpdtcod_0").ToString Then
                        mac.ArticuloCodigo = dr("macpdtcod_0").ToString
                    End If
                    mac.Cilindro = dr("ynrocil_0").ToString
                    mac.FabricacionCorto = CDate(dr("yfabdat_0")).Year
                    mac.VtoCarga = CDate(dr("vto_0"))
                    If mac.TienePh Then
                        mac.VtoPH = CDate(dr("vtoph_0"))
                    End If
                    mac.Grabar()
                End If
            End If
        Next

        dt.Dispose()

    End Sub
    Private Sub ProcesarPuestos(ByVal Ruta As Integer, ByVal Cliente As String, ByVal Sucursal As String)
        Dim da As OracleDataAdapter
        Dim txt As String
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim pp As New Puesto(cn)

        txt = "SELECT * "
        txt &= "FROM xrelev "
        txt &= "WHERE ruta_0 = :ruta_0 AND bpcnum_0 = :bpcnum_0 AND fcyitn_0 = :fcyitn_0 AND tiporeg_0 = 3"

        da = New OracleDataAdapter(txt, cn)
        With da.SelectCommand.Parameters
            .Add("ruta_0", OracleType.Number).Value = Ruta
            .Add("bpcnum_0", OracleType.VarChar).Value = Cliente
            .Add("fcyitn_0", OracleType.VarChar).Value = Sucursal
        End With

        da.Fill(dt)
        da.Dispose()

        'Recorro todos los puestos
        For Each dr In dt.Rows

            If CInt(dr("nuevo_0")) = 1 Then 'El sector es nuevo
                With pp
                    .Nuevo()
                    .Sector = CLng(dr("sector_0"))
                    .Puesto = dr("idpuesto_0").ToString
                    .Tipo = dr("tipo_0").ToString
                    .Baliza = dr("baliza_0").ToString
                    .Soporte = dr("soporte_0").ToString
                    .Gabinete = dr("gabinete_0").ToString
                    .Cartel = dr("cartel_0").ToString
                    .Tarjeta = dr("tarjeta_0").ToString
                    .Lanza = dr("lanza_0").ToString
                    .Pico = dr("pico_0").ToString
                    .Llave = dr("llave_0").ToString
                    .Vidrio = dr("vidrio_0").ToString
                    .Valvula = dr("valvula_0").ToString
                    .Serie = dr("serie_0").ToString
                    .Observaciones = dr("obs_0").ToString
                    'Si el puesto tiene algun estado informado, agrego la fecha en la obs
                    If dr("estado_0").ToString <> " " Then
                        .Observaciones = "[" & CDate(dr("fecha_0")).ToString("dd/MM/yyyy") & "] " & .Observaciones
                    End If
                    .Estado = dr("estado_0").ToString
                    .Fecha = CDate(dr("fecha_0"))

                    .Grabar()
                End With

            Else    'Actualizo puesto
                If pp.Abrir(CLng(dr("idpuesto_0"))) Then
                    With pp
                        .Sector = CLng(dr("sector_0"))
                        .Puesto = dr("pueston_0").ToString
                        .Tipo = dr("tipo_0").ToString
                        .Baliza = dr("baliza_0").ToString
                        .Soporte = dr("soporte_0").ToString
                        .Gabinete = dr("gabinete_0").ToString
                        .Cartel = dr("cartel_0").ToString
                        .Tarjeta = dr("tarjeta_0").ToString
                        .Lanza = dr("lanza_0").ToString
                        .Pico = dr("pico_0").ToString
                        .Llave = dr("llave_0").ToString
                        .Vidrio = dr("vidrio_0").ToString
                        .Valvula = dr("valvula_0").ToString
                        .Serie = dr("serie_0").ToString
                        .Observaciones = dr("obs_0").ToString
                        .Estado = dr("estado_0").ToString
                        .Fecha = CDate(dr("fecha_0"))

                        .Grabar()
                    End With

                End If

            End If

        Next

        dt.Dispose()

    End Sub
    Private Sub MarcarComoProcesado(ByVal Ruta As Integer, ByVal Cliente As String, ByVal Sucursal As String)
        Dim txt As String
        Dim cm As OracleCommand

        txt = "UPDATE xrelev SET procesado_0 = 2 "
        txt &= "WHERE ruta_0 = :ruta_0 AND bpcnum_0 = :bpcnum_0 AND fcyitn_0 = :fcyitn_0"

        cm = New OracleCommand(txt, cn)
        With cm.Parameters
            .Add("ruta_0", OracleType.Number).Value = Ruta
            .Add("bpcnum_0", OracleType.VarChar).Value = Cliente
            .Add("fcyitn_0", OracleType.VarChar).Value = Sucursal
        End With
        cm.ExecuteNonQuery()
        cm.Dispose()
    End Sub

End Class