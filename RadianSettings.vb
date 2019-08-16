Imports System.Data
Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class RadianSettings

    'Method for Centering Forms
    Public Sub CenterForm(ByVal frm As Form, Optional ByVal parent As Form = Nothing)
        'Note: call this from frm's Load event!
        Dim r As Rectangle

        If parent IsNot Nothing Then
            r = parent.RectangleToScreen(parent.ClientRectangle)
        Else
            r = Screen.FromPoint(frm.Location).WorkingArea
        End If

        Dim x = r.Left + (r.Width - frm.Width) \ 2
        Dim y = r.Top + (r.Height - frm.Height) \ 2
        frm.Location = New Point(x, y)

    End Sub

    Public Sub testConnection()
        Dim MysqlConn As New MySqlConnection
        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString =
            "
            server='" & My.Settings.ServerName & "';
            userid='" & My.Settings.UserID & "';
            password='" & My.Settings.Password & "';
            database='" & My.Settings.DBName & "'
            "
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

    Public Sub connectionString()

        Dim MysqlConn As New MySqlConnection
        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString =
            "
            server='" & My.Settings.ServerName & "';
            userid='" & My.Settings.UserID & "';
            password='" & My.Settings.Password & "';
            database='" & My.Settings.DBName & "'
            "

    End Sub

End Class
