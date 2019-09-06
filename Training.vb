Imports MySql.Data.MySqlClient
Public Class frmStudentTraining
    Private Sub FrmStudentTraining_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Disable save button
        btnSave.Enabled = False

        'Centre Form
        Dim loadStndentTraining As New RadianSettings
        loadStndentTraining.CenterForm(Me)

    End Sub
End Class