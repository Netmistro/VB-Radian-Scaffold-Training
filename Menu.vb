Imports System.Data
Imports MySql.Data
Imports MySql.Data.MySqlClient
Public Class frmMenu
    Dim MysqlConn As MySqlConnection
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnCheckConnection.Click

        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString =
            "server=localhost;userid=root;password=root;database=radiantraining"
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

    Private Sub Menu_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim loadMenuForm As New RadianSettings
        loadMenuForm.CenterForm(Me)

    End Sub

    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles btnStudentTraining.Click

        frmStudentTraining.Show()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnStudentDetails.Click

        frmStudents.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnLocalCompany.Click

        frmLocalCompany.Show()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles btnInstructor.Click

        frmInstructors.Show()

    End Sub

    Private Sub BtnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click

        frmSettings.Show()

    End Sub
End Class
