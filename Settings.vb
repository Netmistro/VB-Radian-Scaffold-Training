Imports System.Data
Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class frmSettings

    Dim MysqlConn As New MySqlConnection
    Private Sub FrmSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Centre Form
        Dim loadSettingsForm As New RADIANSETTINGS
        loadSettingsForm.CenterForm(Me)

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

        Me.Close()

    End Sub

    Private Sub btnTestConnection_Click(sender As Object, e As EventArgs) Handles btnTestConnection.Click



    End Sub

    Private Sub BtnSaveSettings_Click(sender As Object, e As EventArgs) Handles btnSaveSettings.Click

        'Save the configuration
        My.Settings.ServerName = txtServerName.Text
        My.Settings.UserID = txtUserID.Text
        My.Settings.Password = txtPassword.Text
        My.Settings.DBName = txtDBName.Text
        My.Settings.PicturePath = txtStudentPICPath.Text
        My.Settings.CertPath = txtCertPath.Text
        My.Settings.NationalIDPath = txtNationalID.Text
        My.Settings.DriversPermitPath = txtDriversPermit.Text
        My.Settings.PassportPath = txtPassport.Text

        MsgBox("Settings Saved Successfully!")


    End Sub

    Private Sub TxtStudentPICPath_TextChanged(sender As Object, e As EventArgs) Handles txtStudentPICPath.TextChanged

    End Sub

    Private Sub BtnPICBrowse_Click(sender As Object, e As EventArgs) Handles btnPICBrowse.Click

        Dim fd As FolderBrowserDialog = New FolderBrowserDialog()

        If fd.ShowDialog() = DialogResult.OK Then

            txtStudentPICPath.Text = fd.SelectedPath

        End If

    End Sub

    Private Sub BtnCertPath_Click(sender As Object, e As EventArgs) Handles btnCertPath.Click

        Dim fd As FolderBrowserDialog = New FolderBrowserDialog()

        If fd.ShowDialog() = DialogResult.OK Then

            txtStudentPICPath.Text = fd.SelectedPath

        End If

    End Sub

    Private Sub BtnNationalID_Click(sender As Object, e As EventArgs) Handles btnNationalID.Click

        Dim fd As FolderBrowserDialog = New FolderBrowserDialog()

        If fd.ShowDialog() = DialogResult.OK Then

            txtStudentPICPath.Text = fd.SelectedPath

        End If

    End Sub

    Private Sub BtnDriversPermit_Click(sender As Object, e As EventArgs) Handles btnDriversPermit.Click

        Dim fd As FolderBrowserDialog = New FolderBrowserDialog()

        If fd.ShowDialog() = DialogResult.OK Then

            txtStudentPICPath.Text = fd.SelectedPath

        End If

    End Sub

    Private Sub BtnPassport_Click(sender As Object, e As EventArgs) Handles btnPassport.Click

        Dim fd As FolderBrowserDialog = New FolderBrowserDialog()

        If fd.ShowDialog() = DialogResult.OK Then

            txtStudentPICPath.Text = fd.SelectedPath

        End If

    End Sub
End Class