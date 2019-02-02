Imports System.IO
Imports System.Data.OracleClient

Public Class frmRetenciones
    Private cm As OracleCommand
    Private da As OracleDataAdapter
    Private dt As New DataTable

    Private Sub frmRetenciones_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Sql As String

        Sql = "insert into xreten2 values(:cuit, :fecharet, :fechaing, :certif, :total)"
        cm = New OracleCommand(Sql, cn)
        cm.Parameters.Add("cuit", OracleType.VarChar)
        cm.Parameters.Add("fecharet", OracleType.DateTime)
        cm.Parameters.Add("fechaing", OracleType.DateTime)
        cm.Parameters.Add("certif", OracleType.VarChar)
        cm.Parameters.Add("total", OracleType.Number)

        Sql = "SELECT * FROM xreten2 WHERE fechaing_0 >= :fecha1 AND fechaing_0 < :fecha2"
        da = New OracleDataAdapter(Sql, cn)
        da.SelectCommand.Parameters.Add("fecha1", OracleType.DateTime)
        da.SelectCommand.Parameters.Add("fecha2", OracleType.DateTime)
        da.InsertCommand = New OracleCommandBuilder(da).GetInsertCommand

        Try
            da.FillSchema(dt, SchemaType.Mapped)

        Catch ex As Exception

        End Try

        AddHandler dgv.RowPostPaint, AddressOf NumeracionGrillas

        dtp.Value = New Date(Today.Year, Today.Month, 1).AddMonths(-1)

    End Sub

    Private Sub btnImportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImportar.Click
        Importar()
    End Sub
    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        Exportar()
    End Sub
    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Buscar()
    End Sub
    Private Sub Buscar()
        Dim f1, f2 As Date

        'Armo fecha de consulta
        dtp.Value = New Date(dtp.Value.Year, dtp.Value.Month, 1)
        f1 = dtp.Value
        f2 = f1.AddMonths(1)

        da.SelectCommand.Parameters("fecha1").Value = f1
        da.SelectCommand.Parameters("fecha2").Value = f2
        Try
            dt.Clear()
            da.Fill(dt)

            colFechaRet.DataPropertyName = "fecharet_0"
            colCuit.DataPropertyName = "cuit_0"
            colCertif.DataPropertyName = "certif_0"
            colImporte.DataPropertyName = "total_0"
            colFechaIng.DataPropertyName = "fechaing_0"
            dgv.DataSource = dt

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub Importar()
        Dim sr As StreamReader
        Dim txt As String
        Dim cuit As String
        Dim certif As String
        Dim fechaRet As Date
        Dim fechaIng As Date
        Dim total As Double
        Dim Campos() As String
        Dim dr As DataRow

        ofd.ShowDialog()

        If ofd.FileName.Trim = "" Then Exit Sub

        Try
            sr = New StreamReader(ofd.FileName)

            dt.Clear()
            Do Until sr.EndOfStream
                txt = sr.ReadLine

                Campos = Split(txt, vbTab)

                cuit = Campos(0) 'txt.Substring(0, 11)
                If Not IsNumeric(cuit) Then Continue Do
                fechaRet = CDate(Campos(6))
                certif = Campos(7)
                total = CDbl(Campos(11).Replace(".", "").Replace(",", "."))
                fechaIng = CDate(Campos(12))


                dr = dt.NewRow
                dr("cuit_0") = cuit.Trim
                dr("fecharet_0") = fechaRet
                dr("fechaing_0") = fechaIng
                dr("total_0") = total
                dr("certif_0") = certif.Trim
                dt.Rows.Add(dr)

            Loop
            da.Update(dt)

            MessageBox.Show(dt.Rows.Count & " registros insertados", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            sr.Close()
            sr.Dispose()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub Exportar()
        If dt.Rows.Count = 0 Then Exit Sub

        Dim Archivo As String

        Dim sw As StreamWriter
        Dim dr As DataRow
        Dim l As String

        sfd.ShowDialog()
        Archivo = sfd.FileName
        If Archivo = "" Then Exit Sub

        Try
            sw = New StreamWriter(Archivo, False)

            For Each dr In dt.Rows
                l = dr("cuit_0").ToString
                l &= CDate(dr("fechaing_0")).ToString("yyyyMMdd")
                l &= "  "
                l &= Strings.Right(Space(25) & dr("certif_0").ToString, 25)
                l &= Strings.Right(Space(15) & CDbl(dr("total_0")).ToString("N2").Replace(",", ""), 15)
                sw.WriteLine(l)
            Next
            sw.Close()
            sw.Dispose()

            MessageBox.Show(dt.Rows.Count & " registros exportados", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

End Class