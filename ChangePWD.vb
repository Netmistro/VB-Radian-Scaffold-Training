Imports MySql.Data.MySqlClient

Public Class frmChangePWD
    Dim MySqlConn As MySqlConnection
    Dim COMMAND As MySqlCommand

    Private Sub ChangePWD_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Centre Form
        Dim cityForm As New RADIANSETTINGS
        cityForm.CenterForm(Me)

    End Sub

    Private Sub btnChangePWD_Click(sender As Object, e As EventArgs) Handles btnChangePWD.Click

        MySqlConn = New MySqlConnection
        Dim CString As New RADIANSETTINGS
        MySqlConn.ConnectionString = CString.ConnString

        If txtOldPWD.Text = "" Or txtNewPWD.Text = "" Or txtVerifyPWD.Text = "" Then
            MsgBox("Please fill in all fields!")
        ElseIf txtNewPWD.Text <> txtVerifyPWD.Text Then
            MsgBox("The new passwords do not match!")
        Else
            Try
                MySqlConn.Open()
                Dim Query As String
                Query = "select password from radiantraining.users WHERE username= '" & frmLogin.txtUsername.Text & "'"
                COMMAND = New MySqlCommand(Query, MySqlConn)
                Dim READER As MySqlDataReader
                READER = COMMAND.ExecuteReader

                While READER.Read

                    Dim password = READER.GetString("password")

                    READER.Dispose()

                    If txtOldPWD.Text <> password Then
                        MsgBox("Your PWD is invalid!")
                    Else
                        Dim Query2 As String
                        Query2 = "UPDATE radiantraining.users SET
                        password='" & txtNewPWD.Text & "'
                        WHERE username ='" & frmLogin.txtUsername.Text & "'"

                        COMMAND = New MySqlCommand(Query2, MySqlConn)
                        READER = COMMAND.ExecuteReader
                        MsgBox("Successfully Updated")

                    End If

                End While

                MySqlConn.Close()

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                MySqlConn.Dispose()
            End Try

        End If

    End Sub

End Class