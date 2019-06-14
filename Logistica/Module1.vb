Imports System.Data.OracleClient
Imports System.Text.RegularExpressions

Module Module1

    Public Const CONEXIONBD As String = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=\\srv\z\programas\ausencias\ausencias.mdb;"
    Public Const DB_USR As String = "GEOTEST"
    Public Const DB_PWD As String = "tiger"
    Public Const DB_SRV As String = "adx"
    Public Const DB_POR As String = "1801"
    Public Const DB_SID As String = "ADX_X3V4"
    Public Const X3DOS As String = DB_USR & ";" & DB_SRV & ";" & DB_POR & ";140;SPA"
    Public Const RPTX3 As String = "\\" & DB_SRV & "\Folders\" & DB_USR & "\REPORT\SPA\"
    Public Const PATH_OC As String = "\\srv\Z\OC\"
    Public Const PATH_SCAN As String = "\\srv\z\remitos\"
    Public Const DB As String = "Data Source=" & DB_SID & ";User ID=" & DB_USR & ";Password=" & DB_PWD
    Public Const ARTICULO_PRESTAMO_EXT As String = "601003"
    Public Const ARTICULO_PRESTAMO_MAN As String = "607003"
    Public Const CP_CANTIDAD_MINIMA_REQUERIDA As Integer = 4
    Public Const MOVIMIENTOS As Integer = 90
    Public Const LOGISTICA As Integer = 2
    Public Const MONTO_LIA_OBLIGATORIO As Double = 4958.67

    Public cn As New OracleConnection(DB)
    Public usr As New Usuario(cn)
    Public dtPermisos As New DataTable 'Tabla con los permisos del usuario logeado

    Public Enum ModoRuta
        Cerrada
        Nueva
        Edicion
        Vista
    End Enum
    Public Sub Parametro(ByVal cm As OracleCommand, ByVal Nombre As String, ByVal Tipo As OracleType, ByVal Version As DataRowVersion, Optional ByVal Campo As String = "", Optional ByVal Valor As Object = Nothing)
        With cm.Parameters
            With .Add(Nombre, Tipo)
                If Valor Is Nothing Then
                    .SourceVersion = Version
                    If Campo = "" Then
                        .SourceColumn = .ParameterName
                    Else
                        .SourceColumn = Campo
                    End If

                Else
                    .Value = Valor

                End If

            End With
        End With

    End Sub

    'FUNCIONES
    Public Function TextoNulo(ByVal Texto As String) As String
        If Texto.Trim.Length = 0 Then
            Return " "
        Else
            Return Texto.Trim
        End If
    End Function
    Public Function NombreTransporte(ByVal id As String) As String
        Dim dr As OracleDataReader
        Dim cm As New OracleCommand("SELECT bptnam_0 FROM bpcarrier WHERE bptnum_0 = :p1", cn)
        cm.Parameters.Add("p1", OracleType.VarChar).Value = id

        Try
            dr = cm.ExecuteReader

            If dr.Read Then
                NombreTransporte = dr(0).ToString
            Else
                NombreTransporte = ""
            End If

            dr.Close()
            dr.Dispose() : dr = Nothing

        Catch ex As Exception
            NombreTransporte = ""

        End Try

        cm.Dispose() : cm = Nothing

    End Function
    Public Function NombreChofer(ByVal transporte As String, ByVal patente As String) As String
        Dim dr As OracleDataReader
        Dim cm As New OracleCommand("SELECT chofer_0 FROM zunitrans WHERE bptnum_0 = :p1 AND patnum_0 = :p2", cn)
        cm.Parameters.Add("p1", OracleType.VarChar).Value = transporte
        cm.Parameters.Add("p2", OracleType.VarChar).Value = patente

        Try
            dr = cm.ExecuteReader

            If dr.Read Then
                NombreChofer = dr(0).ToString
            Else
                NombreChofer = ""
            End If

            dr.Close()
            dr.Dispose() : dr = Nothing

        Catch ex As Exception
            NombreChofer = ""

        End Try

        cm.Dispose() : cm = Nothing

    End Function
    Public Function NombreAcomp(ByVal id As Integer) As String
        Dim dr As OracleDataReader
        Dim cm As New OracleCommand("SELECT lanmes_0 FROM aplstd WHERE lanchp_0 = 2408 AND lan_0 = 'SPA' AND lannum_0 = :p1", cn)

        If id = 0 Then
            NombreAcomp = ""

        Else

            cm.Parameters.Add("p1", OracleType.Number).Value = id

            Try
                dr = cm.ExecuteReader

                If dr.Read Then
                    NombreAcomp = dr(0).ToString
                Else
                    NombreAcomp = ""
                End If

                dr.Close()
                dr.Dispose() : dr = Nothing

            Catch ex As Exception
                NombreAcomp = ""

            End Try

        End If

        cm.Dispose() : cm = Nothing

    End Function
    Public Function ValidarHora(ByVal hora As String) As Boolean
        Dim c As Char

        'Si cadena tiene menos de 4 caracteres la hora es invalida
        If hora.Trim.Length < 4 Then Return False

        'Valido que todos los caracteres sean numeros
        For i As Integer = 0 To 3
            c = hora.Chars(i)
            If Not IsNumeric(c) Then Return False
        Next

        Dim hh As Integer = CInt(hora.Substring(0, 2))
        Dim mm As Integer = CInt(hora.Substring(2, 2))

        If hh > 23 Then Return False
        If mm > 59 Then Return False

        Return True

    End Function
    Public Function PermisoSecundario(ByVal cn As OracleConnection, ByVal Usr As String, ByVal Funcion As String, ByVal Valor As Char) As Boolean
        Dim txt As String
        Dim da As OracleDataAdapter
        Dim dt As New DataTable
        Dim dr As DataRow

        txt = "SELECT flags_0 "
        txt &= "FROM xnetper xp INNER JOIN xnetfnc xf ON (xp.fncid_0 = xf.fncid_0) "
        txt &= "WHERE usr_0 = :usr_0 AND fnc_0 = :fnc_0"

        da = New OracleDataAdapter(txt, cn)
        With da.SelectCommand.Parameters
            .Add("usr_0", OracleType.VarChar).Value = Usr
            .Add("fnc_0", OracleType.VarChar).Value = Funcion
        End With

        da.Fill(dt)
        da.Dispose()

        If dt.Rows.Count = 0 Then
            Return False

        Else
            dr = dt.Rows(0)

            Dim i As Integer = dr(0).ToString.IndexOf(Valor)
            Return (i > -1)

        End If

    End Function
    Public Function TablaMotivos(ByVal cn As OracleConnection) As DataTable
        Dim da As New OracleDataAdapter("SELECT to_number(code_0) AS code_0, a1_0, a2_0, n1_0, n2_0, texte_0 FROM atabdiv INNER JOIN atextra ON (numtab_0 = ident1_0) AND (code_0 = ident2_0) WHERE numtab_0 = 5000 AND codfic_0 = 'ATABDIV' AND zone_0 = 'LNGDES' ORDER BY code_0", cn)
        Dim dt As New DataTable

        da.Fill(dt)
        da.Dispose()

        Return dt

    End Function
    Public Function TablaEstadosRuta(ByVal cn As OracleConnection) As DataTable
        Dim da As New OracleDataAdapter("SELECT to_number(code_0) AS code_0, a1_0, a2_0, n1_0, n2_0, code_0 || ' - ' || texte_0 AS texte_0 FROM atabdiv INNER JOIN atextra ON (numtab_0 = ident1_0) AND (code_0 = ident2_0) WHERE numtab_0 = 5001 AND codfic_0 = 'ATABDIV' AND zone_0 = 'LNGDES' ORDER BY code_0", cn)
        Dim dt As New DataTable

        da.Fill(dt)
        da.Dispose()

        Return dt

    End Function
    Public Function MenuLocal(ByVal cn As OracleConnection, ByVal Menu As Integer) As DataTable
        Dim dt As New DataTable
        Dim da As New OracleDataAdapter("SELECT lannum_0, lanmes_0 FROM aplstd WHERE lanchp_0 = :lanchp_0 AND lan_0 = 'SPA' AND lannum_0 > 0 ORDER BY lannum_0", cn)
        da.SelectCommand.Parameters.Add("lanchp_0", OracleType.Number).Value = Menu

        da.Fill(dt)
        da.Dispose()

        Return dt

    End Function
    Public Sub MenuLocal(ByVal cn As OracleConnection, ByVal Menu As Integer, ByVal cbo As DataGridViewComboBoxColumn, Optional ByVal Blanco As Boolean = False)
        Dim dr As DataRow
        Dim dt As New DataTable
        Dim da As New OracleDataAdapter("SELECT lannum_0, lanmes_0 FROM aplstd WHERE lanchp_0 = :lanchp_0 AND lan_0 = 'SPA' AND lannum_0 > 0 ORDER BY lannum_0", cn)
        da.SelectCommand.Parameters.Add("lanchp_0", OracleType.Number).Value = Menu

        da.Fill(dt)
        da.Dispose()

        If Blanco Then
            dr = dt.NewRow
            dr("lannum_0") = 0
            dr("lanmes_0") = " "
            dt.Rows.InsertAt(dr, 0)
        End If

        cbo.DataSource = dt
        cbo.DisplayMember = "lanmes_0"
        cbo.ValueMember = "lannum_0"

    End Sub
    Public Sub MenuLocal(ByVal cn As OracleConnection, ByVal Menu As Integer, ByVal cbo As ComboBox, Optional ByVal Blanco As Boolean = False)
        Dim dr As DataRow
        Dim dt As New DataTable
        Dim da As New OracleDataAdapter("SELECT lannum_0, lanmes_0 FROM aplstd WHERE lanchp_0 = :lanchp_0 AND lan_0 = 'SPA' AND lannum_0 > 0 ORDER BY lannum_0", cn)
        da.SelectCommand.Parameters.Add("lanchp_0", OracleType.Number).Value = Menu

        da.Fill(dt)
        da.Dispose()

        If Blanco Then
            dr = dt.NewRow
            dr("lannum_0") = 0
            dr("lanmes_0") = " "
            dt.Rows.InsertAt(dr, 0)
        End If

        cbo.DataSource = dt
        cbo.DisplayMember = "lanmes_0"
        cbo.ValueMember = "lannum_0"

    End Sub
    Public Function TablaVaria(ByVal cn As OracleConnection, ByVal Numero As Integer) As DataTable
        Dim dt As New DataTable
        Dim da As New OracleDataAdapter("SELECT ident2_0, texte_0 FROM atextra WHERE codfic_0 = 'ATABDIV' AND ident1_0 = :ident1_0 AND langue_0 = 'SPA' AND zone_0 = 'LNGDES'", cn)
        da.SelectCommand.Parameters.Add("ident1_0", OracleType.VarChar).Value = Numero.ToString

        da.Fill(dt)
        da.Dispose()

        Return dt

    End Function
    Public Function Sectores(ByVal cn As OracleConnection, Optional ByVal QuitarOrigen As Boolean = False, Optional ByVal Sector As String = "", Optional ByVal Blanco As Boolean = False) As DataTable
        Dim Sql As String
        Dim da As OracleDataAdapter
        Dim dt As New DataTable
        Dim dr As DataRow

        If QuitarOrigen Then
            Sql = "SELECT ident2_0, texte_0 "
            Sql &= "FROM atextra "
            Sql &= "WHERE codfic_0 = 'ATABDIV' and zone_0 = 'LNGDES' and langue_0 = 'SPA' AND ident1_0 = '5004' AND ident2_0 <> :ident2_0"

            da = New OracleDataAdapter(Sql, cn)
            da.SelectCommand.Parameters.Add("ident2_0", OracleType.VarChar).Value = Sector
        Else
            Sql = "SELECT ident2_0, texte_0 "
            Sql &= "FROM atextra "
            Sql &= "WHERE codfic_0 = 'ATABDIV' and zone_0 = 'LNGDES' and langue_0 = 'SPA' AND ident1_0 = '5004'"

            da = New OracleDataAdapter(Sql, cn)
        End If

        da.Fill(dt)

        If Blanco Then
            dr = dt.NewRow
            dr("ident2_0") = " "
            dr("texte_0") = " "
            dt.Rows.InsertAt(dr, 0)
            dt.AcceptChanges()
        End If

        da.Dispose()

        Return dt

    End Function
    Public Function Sectores(ByVal cn As OracleConnection, ByVal Codigo As String) As String
        Dim Sql As String
        Dim da As OracleDataAdapter
        Dim dt As New DataTable

        Sql = "SELECT ident2_0, texte_0 "
        Sql &= "FROM atextra "
        Sql &= "WHERE codfic_0 = 'ATABDIV' and zone_0 = 'LNGDES' and langue_0 = 'SPA' AND ident1_0 = '5004' AND ident2_0 = :ident2_0"

        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("ident2_0", OracleType.VarChar).Value = Codigo

        da.Fill(dt)
        da.Dispose()

        Return dt.Rows(0).Item("texte_0").ToString

    End Function
    Public Function ValidMail(ByVal eMail As String) As Boolean
        Dim txt As String = "^(([^<;>;()[\]\\.,;:\s@\""]+(\.[^<;>;()[\]\\.,;:\s@\""]+)*)|(\"".+\""))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$"
        Dim l_reg As New Regex(txt)
        Dim Mails As String()
        Dim Flag As Boolean
        Dim i As Integer

        Mails = Split(eMail, ";")

        For i = 0 To UBound(Mails)
            Mails(i) = Mails(i).Trim
            Flag = l_reg.IsMatch(Mails(i))

            If Not Flag Then Exit For
        Next

        Return Flag

    End Function
    Public Function ValidarMail(ByVal sMail As String) As Boolean
        Return Regex.IsMatch(sMail, "^([\w-]+\.)*?[\w-]+@[\w-]+\.([\w-]+\.)*?[\w]+$")
    End Function

    'DGV
    Public Sub NumeracionGrillas(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs)
        On Error Resume Next

        Dim strRowNumber = (e.RowIndex + 1).ToString()
        Dim dgv As DataGridView = CType(sender, DataGridView)

        Dim size As System.Drawing.SizeF
        size = e.Graphics.MeasureString(strRowNumber, dgv.Font)

        If (dgv.RowHeadersWidth < CInt(size.Width + 20)) Then
            dgv.RowHeadersWidth = CInt((size.Width + 20))
        End If

        Dim b As System.Drawing.Brush = System.Drawing.SystemBrushes.ControlText

        e.Graphics.DrawString(strRowNumber, dgv.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))

        dgv = Nothing

    End Sub

End Module