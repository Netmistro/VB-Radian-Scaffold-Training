Imports MySql.Data.MySqlClient

Public Class frmInstructors
    Dim MySqlConn As MySqlConnection
    Dim COMMAND As MySqlCommand

    Private Sub Instructors_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        MySqlConn = New MySqlConnection
        MySqlConn.ConnectionString = "server=localhost;userid=root;password=root;database=radiantraining"
        Dim SDA As New MySqlDataAdapter
        Dim dbDataSet As New DataTable
        Dim bSource As New BindingSource

        'Blank all fields on load
        txtInstructorID.Text = ""
        txtInstructorName.Text = ""
        cmbCompanyName.Text = ""

        Try
            MySqlConn.Open()
            Dim Query As String
            Query = "select instructors.idInstructors as 'ID', instructors.InstructorName as 'Instructor', instructors.Company as 'Company' from radiantraining.instructors"
            COMMAND = New MySqlCommand(Query, MySqlConn)

            SDA.SelectCommand = COMMAND
            SDA.Fill(dbDataSet)
            bSource.DataSource = dbDataSet
            DataGridView1.DataSource = bSource
            SDA.Update(dbDataSet)
            DataGridView1.ColumnHeadersDefaultCellStyle.Font = New Font(DataGridView1.Font, FontStyle.Bold)
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
                cmbCompanyName.Text = ""

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
            Query = "INSERT INTO radiantraining.instructors(InstructorName, Company ) VALUES ('" & txtInstructorName.Text & "','" & cmbCompanyName.Text & "')"
            COMMAND = New MySqlCommand(Query, MySqlConn)
            READER = COMMAND.ExecuteReader

            MsgBox("Successfully Entered")
            DataGridView1.Refresh()
            MySqlConn.Close()

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        Finally

            MySqlConn.Dispose()

        End Try

    End Sub

    Private Sub BtnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click



    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

    End Sub

    Private Sub BtnAddCompany_Click(sender As Object, e As EventArgs) Handles btnAddCompany.Click

        frmForeignCompany.Show()

    End Sub
End Class