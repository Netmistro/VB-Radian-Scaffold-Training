Imports MySql.Data.MySqlClient

Public Class frmInstructors
    Dim MySqlConn As MySqlConnection
    Dim COMMAND As MySqlCommand

    Private Sub Instructors_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Centre Form
        Dim loadInstructorsForm As New RadianSettings
        loadInstructorsForm.CenterForm(Me)

        MySqlConn = New MySqlConnection
        MySqlConn.ConnectionString = "server=localhost;userid=root;password=root;database=radiantraining"
        Dim SDA As New MySqlDataAdapter
        Dim dbDataSet As New DataTable
        Dim bSource As New BindingSource

        'Blank all fields on load
        txtInstructorID.Text = ""
        txtInstructorName.Text = ""
        cmbCompanyName.Text = ""
        txtInsMobile.Text = ""
        Format(txtInsMobile.Text, ("###-###-####"))

        Try
            MySqlConn.Open()
            Dim Query As String
            Query = "select instructors.idInstructors as 'ID', instructors.InstructorName as 'Instructor', instructors.Company as 'Company', instructors.InsMobile as 'Mobile' from radiantraining.instructors"
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
                txtInsMobile.Text = ""
                cmbCompanyName.Text = ""

            End While
            'Reload table data
            loadTable()

            MySqlConn.Close()

        Catch ex As Exception

            MessageBox.Show(ex.Message)
        Finally

            MySqlConn.Dispose()

        End Try

    End Sub

    Private Sub BtnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

        MySqlConn = New MySqlConnection
        MySqlConn.ConnectionString = "server=localhost;userid=root;password=root;database=radiantraining"
        Dim READER As MySqlDataReader

        'Try Catch Block
        Try

            MySqlConn.Open()
            Dim Query As String
            Query = "
            Update radiantraining.instructors set
            idInstructors='" & txtInstructorID.Text & "',
            InstructorName='" & txtInstructorName.Text & "',
            Company='" & cmbCompanyName.Text & "',
            InsMobile='" & txtInsMobile.Text & "'
            where idInstructors='" & txtInstructorID.Text & "'"

            COMMAND = New MySqlCommand(Query, MySqlConn)
            READER = COMMAND.ExecuteReader

            MsgBox("Successfully Updated")
            'Refresh Data
            loadTable()
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

            If txtInstructorName.Text = "" Or cmbCompanyName.Text = "" Then
                MsgBox("Please enter Instructor name and Company")
            Else
                MySqlConn.Open()
                Dim Query As String
                Query = "INSERT INTO radiantraining.instructors(InstructorName, Company,InsMobile ) VALUES ('" & txtInstructorName.Text & "','" & cmbCompanyName.Text & "','" & txtInsMobile.Text & "')"
                COMMAND = New MySqlCommand(Query, MySqlConn)
                READER = COMMAND.ExecuteReader

                MsgBox("Successfully Entered")
                'Refresh Data
                loadTable()
                MySqlConn.Close()
            End If


        Catch ex As Exception

            MessageBox.Show(ex.Message)

        Finally

            MySqlConn.Dispose()

        End Try

    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        MySqlConn = New MySqlConnection
        MySqlConn.ConnectionString = "server=localhost;userid=root;password=root;database=radiantraining"
        Dim READER As MySqlDataReader

        'Try Catch Block
        Try

            MySqlConn.Open()
            Dim Query As String
            Query = "DELETE from radiantraining.instructors where idInstructors='" & txtInstructorID.Text & "'"
            COMMAND = New MySqlCommand(Query, MySqlConn)
            READER = COMMAND.ExecuteReader
            MsgBox("Record Deleted")

            'Refresh Data - Call function
            loadTable()
            MySqlConn.Close()

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        Finally

            'Blank all the rows again
            txtInstructorID.Text = ""
            txtInstructorName.Text = ""
            cmbCompanyName.Text = ""
            txtInsMobile.Text = ""

            MySqlConn.Dispose()

        End Try


    End Sub

    Private Sub BtnAddCompany_Click(sender As Object, e As EventArgs) Handles btnAddCompany.Click

        frmForeignCompany.Show()

    End Sub

    Private Sub loadTable()

        MySqlConn = New MySqlConnection
        MySqlConn.ConnectionString = "server=localhost;userid=root;password=root;database=radiantraining"
        Dim SDA As New MySqlDataAdapter
        Dim dbDataSet As New DataTable
        Dim bSource As New BindingSource

        Try
            MySqlConn.Open()
            Dim Query As String
            Query = "select instructors.idInstructors as 'ID', instructors.InstructorName as 'Instructor', instructors.Company as 'Company', instructors.InsMobile as 'Mobile' from radiantraining.instructors"
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

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        MySqlConn = New MySqlConnection
        MySqlConn.ConnectionString = "server=localhost;userid=root;password=root;database=radiantraining"

        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow
            row = Me.DataGridView1.Rows(e.RowIndex)
            txtInstructorID.Text = row.Cells("ID").Value.ToString
            txtInstructorName.Text = row.Cells("Instructor").Value.ToString
            cmbCompanyName.Text = row.Cells("Company").Value.ToString
            txtInsMobile.Text = row.Cells("Mobile").Value.ToString

        End If

    End Sub
End Class