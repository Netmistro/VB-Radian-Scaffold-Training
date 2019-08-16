Imports MySql.Data.MySqlClient
Imports System.Data
Imports MySql.Data

Public Class frmLogin

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim loadLoginForm As New RadianSettings
        loadLoginForm.CenterForm(Me)
        cbAdmin.Checked = False

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

        Me.Close()

    End Sub

    Dim MysqlConn As MySqlConnection
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        MysqlConn = New MySqlConnection With {
            .ConnectionString = "server=localhost;userid=root;password=root;database=radiantraining"
        }
        Dim COMMAND As MySqlCommand
        Dim READER As MySqlDataReader

        Try
            MysqlConn.Open()
            Dim Query As String
            Query = "SELECT * from radiantraining.users where username ='" & txtUsername.Text & "' and password ='" & txtPassword.Text & "'"
            COMMAND = New MySqlCommand(Query, MysqlConn)
            READER = COMMAND.ExecuteReader

            Dim count As Integer
            count = 0

            While READER.Read

                count += +1

            End While

            If count = 1 Then

                frmMenu.Show()
                Me.Visible = False

            Else
                MessageBox.Show("Wrong Cridentials", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End If

            MysqlConn.Close()

        Catch ex As Exception

            MessageBox.Show("There was a connection error" & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            MysqlConn.Dispose()

        End Try

    End Sub

    Private Sub btnOptions_Click(sender As Object, e As EventArgs) Handles btnOptions.Click

        frmSettings.Show()

    End Sub
End Class

