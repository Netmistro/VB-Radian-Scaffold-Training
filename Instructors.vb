Imports MySql.Data.MySqlClient

Public Class frmInstructors
    Dim MySqlConn As MySqlConnection
    Dim COMMAND As MySqlCommand

    Private Sub Instructors_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        MySqlConn = New MySqlConnection
        MySqlConn.ConnectionString = "server=localhost;userid=root;password=root;database=radiantraining"
        Dim READER As MySqlDataReader
        Dim SDA As New MySqlDataAdapter
        Dim dbDataSet As New DataTable
        Dim bSource As New BindingSource


        Try
            MySqlConn.Open()
            Dim Query As String
            Query = "select instructors.idInstructors as 'ID', instructors.InstructorName as 'Instructor', foreigncompany.CompanyName as 'Company' from radiantraining.instructors INNER JOIN foreigncompany on instructors.fkCompany = foreigncompany.idfCompany "
            COMMAND = New MySqlCommand(Query, MySqlConn)
            READER = COMMAND.ExecuteReader
            While READER.Read

                Dim instructorID = READER.GetString("ID")
                txtInstructorID.Text = instructorID

                Dim instructorName = READER.GetString("Instructor")
                txtInstructorName.Text = instructorName

                Dim companyName = READER.GetString("Company")
                cmbCompanyName.Text = companyName

            End While

            MySqlConn.Close()

        Catch ex As Exception

            MessageBox.Show(ex.Message)
        Finally

            MySqlConn.Dispose()

        End Try


    End Sub

    Private Sub BtnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        MySqlConn = New MySqlConnection
        MySqlConn.ConnectionString = "server=localhost;userid=root;password=root;database=radiantraining"
        Dim READER As MySqlDataReader

        'Try Catch Block
        Try
            MySqlConn.Open()
            Dim Query As String
            Query = "select * from radiantraining.foreigncompany"
            COMMAND = New MySqlCommand(Query, MySqlConn)
            READER = COMMAND.ExecuteReader
            While READER.Read

                Dim companyName = READER.GetString("CompanyName")
                cmbCompanyName.Items.Add(companyName)
                ' Blank all text boxes
                txtInstructorID.Text = ""
                txtInstructorID.ReadOnly = True
                txtInstructorName.Text = ""

            End While

            MySqlConn.Close()

        Catch ex As Exception

            MessageBox.Show(ex.Message)
        Finally

            MySqlConn.Dispose()

        End Try

    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        MySqlConn = New MySqlConnection
        MySqlConn.ConnectionString = "server=localhost;userid=root;password=root;database=radiantraining"
        Dim READER As MySqlDataReader

        'Try Catch Block
        Try

            MySqlConn.Open()
            Dim Query As String
            Query = "INSERT INTO radiantraining.instructors(InstructorName, fkCompany ) select '" & txtInstructorName.Text & "' AND SELECT idfCompany where '" & cmbCompanyName.Text & "'= CompanyName)"
            COMMAND = New MySqlCommand(Query, MySqlConn)
            READER = COMMAND.ExecuteReader
            MsgBox("Data Saved")
            MySqlConn.Close()

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        Finally

            MySqlConn.Dispose()

        End Try

    End Sub

    Private Sub BtnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click



    End Sub

End Class