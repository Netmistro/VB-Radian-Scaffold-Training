Imports System.Data
Imports MySql.Data
Imports MySql.Data.MySqlClient
Public Class frmMenu
    Dim MysqlConn As MySqlConnection
    Private Sub btnCheckConnection_Click(sender As Object, e As EventArgs) Handles btnCheckConnection.Click


        MessageBox.Show("Connection Successful", "Successful Connection", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub Menu_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim loadMenuForm As New RADIANSETTINGS
        loadMenuForm.CenterForm(Me)

    End Sub

    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs)

        frmTraining.Show()

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

    Private Sub btnStudentListing_Click(sender As Object, e As EventArgs) Handles btnStudentListing.Click

        frmUsers.Show()

    End Sub

    Private Sub btnForeignCompany_Click(sender As Object, e As EventArgs) Handles btnForeignCompany.Click

        frmForeignCompany.Show()

    End Sub

    Private Sub btnCity_Click(sender As Object, e As EventArgs) Handles btnCity.Click

        frmCity.Show()

    End Sub

    Private Sub btnCourses_Click(sender As Object, e As EventArgs) Handles btnCourses.Click

        frmCourses.Show()

    End Sub
End Class
