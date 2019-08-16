Imports MySql.Data.MySqlClient
Public Class frmStudents
    Dim MySqlConn As MySqlConnection
    Dim COMMAND As MySqlCommand
    Dim dbDataSet As New DataTable

    Private Sub FrmStudents_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Set Focus on search box
        txtSearchStudent.Select()

        'Centre Form
        Dim loadStudentsForm As New RadianSettings
        loadStudentsForm.CenterForm(Me)

        MySqlConn = New MySqlConnection
        MySqlConn.ConnectionString = "server=localhost;userid=root;password=root;database=radiantraining"
        Dim SDA As New MySqlDataAdapter
        Dim bSource As New BindingSource

        'Blank all fields on load
        txtStudentAddress.Text = ""
        cmbCity.Text = ""
        txtSearchStudent.Text = ""
        txtStudentID.Text = ""
        txtFirstName.Text = ""
        txtMiddleName.Text = ""
        txtLastName.Text = ""
        cmbCompanyName.Text = ""
        txtMobile.Text = ""
        txtHome.Text = ""
        txtOther.Text = ""
        txtEmailAddress.Text = ""
        txtNotes.Text = ""
        txtNationalID.Text = ""
        txtPassportNo.Text = ""
        txtDriversPermitNo.Text = ""

        Try
            MySqlConn.Open()
            Dim Query As String
            Query = "select studentid as 'ID', FirstName as 'FirstName', MiddleName as 'MiddleName', LastName as 'LastName',
                Company, Address, City, Mobile, Home, Other, NationalIDNo, DriversPermitNo, PassportNo,
                NationalID, DriversPermit, Passport, Picture, Email, Notes
                from radiantraining.students"
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
            txtStudentID.Text = row.Cells("ID").Value.ToString
            txtFirstName.Text = row.Cells("FirstName").Value.ToString
            txtMiddleName.Text = row.Cells("MiddleName").Value.ToString
            txtLastName.Text = row.Cells("LastName").Value.ToString
            cmbCompanyName.Text = row.Cells("Company").Value.ToString
            txtMobile.Text = row.Cells("Mobile").Value.ToString
            txtStudentAddress.Text = row.Cells("Address").Value.ToString
            cmbCity.Text = row.Cells("City").Value.ToString
            txtHome.Text = row.Cells("Home").Value.ToString
            txtOther.Text = row.Cells("Other").Value.ToString
            txtEmailAddress.Text = row.Cells("email").Value.ToString
            txtNotes.Text = row.Cells("Notes").Value.ToString
            txtNationalID.Text = row.Cells("NationalIDNo").Value.ToString
            txtPassportNo.Text = row.Cells("PassportNo").Value.ToString
            txtDriversPermitNo.Text = row.Cells("DriversPermitNo").Value.ToString

            Dim picName As String
            picName = row.Cells("Picture").Value.ToString
            Try
                picBoxStudent.Image = Image.FromFile(My.Settings.PicturePath & "\" & picName)

            Catch ex As Exception
                MsgBox("Error Loading File")
            End Try

        End If

    End Sub

    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click

        txtSearchStudent.Clear()

    End Sub

    Private Sub TxtSearchStudent_TextChanged(sender As Object, e As EventArgs) Handles txtSearchStudent.TextChanged

        Dim DV As New DataView(dbDataSet)
        DV.RowFilter = String.Format("FirstName Like '%{0}%' OR LastName Like '%{0}%' OR Company Like '%{0}%'", txtSearchStudent.Text)
        DataGridView1.DataSource = DV

    End Sub

    Private Sub BtnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click

        MySqlConn = New MySqlConnection
        MySqlConn.ConnectionString = "server=localhost;userid=root;password=root;database=radiantraining"
        Dim READER As MySqlDataReader

        'Reload table data
        loadTable()

        ' Blank all text boxes
        txtStudentID.ReadOnly = True
        txtFirstName.Text = ""
        txtMiddleName.Text = ""
        txtLastName.Text = ""
        txtMobile.Text = ""
        txtOther.Text = ""
        txtHome.Text = ""
        txtEmailAddress.Text = ""
        txtStudentAddress.Text = ""
        cmbCity.Text = ""
        txtNotes.Text = ""
        txtNationalID.Text = ""
        txtPassportNo.Text = ""
        txtPassportNo.Text = ""
        picBoxStudent = Nothing
        cmbCompanyName.Text = ""

        'Try Catch Block City Name
        Try
            MySqlConn.Open()
            Dim Query As String
            Query = "select * from radiantraining.City"
            COMMAND = New MySqlCommand(Query, MySqlConn)
            READER = COMMAND.ExecuteReader

            While READER.Read

                Dim cityName = READER.GetString("CityName")
                cmbCity.Items.Add(cityName)

            End While


            MySqlConn.Close()

        Catch ex As Exception

            MessageBox.Show(ex.Message)
        Finally

            MySqlConn.Dispose()

        End Try

        'Try Catch Block Local Company
        Try
            MySqlConn.Open()
            Dim Query As String
            Query = "select * from radiantraining.localcompany"
            COMMAND = New MySqlCommand(Query, MySqlConn)
            READER = COMMAND.ExecuteReader

            While READER.Read

                Dim companyName = READER.GetString("CompanyName")
                cmbCompanyName.Items.Add(companyName)

            End While
            MySqlConn.Close()

        Catch ex As Exception

            MessageBox.Show(ex.Message)
        Finally

            MySqlConn.Dispose()

        End Try

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
            Query = "select studentID as 'ID', FirstName, MiddleName, LastName, Company, Mobile, Home, Other, Address,
                    City, email, NationalIDNo, PassportNo, DriversPermitNo, Picture, Notes from radiantraining.students"
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

    Private Sub BtnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

        MySqlConn = New MySqlConnection
        MySqlConn.ConnectionString = "server=localhost;userid=root;password=root;database=radiantraining"
        Dim READER As MySqlDataReader

        'Try Catch Block
        Try

            MySqlConn.Open()
            Dim Query As String
            Query = "Update radiantraining.students set
            FirstName='" & txtFirstName.Text & "',
            MiddleName='" & txtMiddleName.Text & "',
            LastName='" & txtLastName.Text & "',
            Company='" & cmbCompanyName.Text & "',
            Address='" & txtStudentAddress.Text & "',
            City='" & cmbCity.Text & "',
            Mobile='" & txtMobile.Text & "',
            Home='" & txtHome.Text & "',
            Other='" & txtOther.Text & "',
            NationalIDNo='" & txtNationalID.Text & "',
            DriversPermitNo='" & txtDriversPermitNo.Text & "',
            PassportNo='" & txtPassportNo.Text & "',
            Other='" & txtOther.Text & "',
            Email='" & txtEmailAddress.Text & "',
            Notes='" & txtNotes.Text & "',
            where StudentID='" & txtStudentID.Text & "'            
            "
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

    Private Sub BtnAttachNationalID_Click(sender As Object, e As EventArgs) Handles btnAttachNationalID.Click

        Dim fd As OpenFileDialog = New OpenFileDialog()
        Dim strFileName As String

        fd.Title = "Select PDF File"
        fd.InitialDirectory = "C:\"
        fd.Filter = "PDF files (*.pdf)|*.pdf"
        fd.FilterIndex = 2
        fd.RestoreDirectory = True

        If fd.ShowDialog() = DialogResult.OK Then
            strFileName = fd.FileName
            Dim dateTime As DateTime = DateTime.Now
            dateTime.ToString("yyy-MM-dd-HH-mm-ss")
            System.IO.File.Copy(strFileName, My.Settings.NationalIDPath & "\" & dateTime.ToString & ".pdf")

        End If

    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        MySqlConn = New MySqlConnection
        MySqlConn.ConnectionString = "server=localhost;userid=root;password=root;database=radiantraining"
        Dim READER As MySqlDataReader

        'Try Catch Block
        Try

            If txtFirstName.Text = "" And txtLastName.Text = "" Then
                MsgBox("Please enter Student Name")
            Else
                MySqlConn.Open()
                Dim Query As String
                Query = "
                INSERT INTO radiantraining.students
                (FirstName, MiddleName, LastName, Company, Mobile, Home, Other, Address, City, Email, Notes, NationalIDNo, PassportNo,
                DriversPermitNo )
                VALUES(
                '" & txtFirstName.Text & "',
                '" & txtMiddleName.Text & "',
                '" & txtLastName.Text & "',
                '" & cmbCompanyName.Text & "',
                '" & txtMobile.Text & "',
                '" & txtHome.Text & "',
                '" & txtOther.Text & "',
                '" & txtStudentAddress.Text & "',
                '" & cmbCity.Text & "',
                '" & txtEmailAddress.Text & "',
                '" & txtNotes.Text & "',
                '" & txtNationalID.Text & "',
                '" & txtPassportNo.Text & "',
                '" & txtDriversPermitNo.Text & "')"
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
End Class