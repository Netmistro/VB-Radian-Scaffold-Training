Imports MySql.Data.MySqlClient

Public Class frmUsers
    Private connectionString As New MySqlConnection("server=localhost;userid=root;password=root;database=radiantraining")
    Private Sub btnAllSystemUsers_Click(sender As Object, e As EventArgs) Handles btnAllSystemUsers.Click
        Dim COMMAND As MySqlCommand
        Dim Adapter As New MySqlDataAdapter
        Dim ds As New DataSet
        Dim sql As String

        sql = "SELECT * FROM users"

        Try
            connectionString.Open()
            COMMAND = New MySqlCommand(sql, connectionString)
            Adapter.SelectCommand = COMMAND
            Adapter.Fill(ds, "users")
            Dim report As New AllSystemUsers
            report.SetDataSource(ds)
            CrystalReportViewer1.ReportSource = report
            CrystalReportViewer1.Refresh()
            COMMAND.Dispose()
            Adapter.Dispose()
            ds.Dispose()
            connectionString.Dispose()

        Catch ex As Exception

            MsgBox(ex.Message)
            connectionString.Close()

        End Try

    End Sub

End Class