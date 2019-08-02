Imports System.Data
Imports MySql.Data
Imports MySql.Data.MySqlClient
Public Class frmMenu
    Dim MysqlConn As MySqlConnection
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnCheckConnection.Click

        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString =
            "server=localhost;userid=root;password=root;database=test"
        Try
            MysqlConn.Open()
            MessageBox.Show("Connection Successful", "Successful Connection", MessageBoxButtons.OK, MessageBoxIcon.Information)
            MysqlConn.Close()
        Catch ex As Exception
            MessageBox.Show("There was a connection error" & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            MysqlConn.Dispose()
        End Try
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
End Class
