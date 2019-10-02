Imports MySql.Data.MySqlClient
Public Class frmTraining
    Dim MysqlConn As New MySqlConnection
    Dim COMMAND As New MySqlCommand
    Dim dbDataSet As New DataTable
    Private Sub FrmStudentTraining_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Format date time pickers at load
        dtpStartDate.Format = DateTimePickerFormat.Custom
        dtpStartDate.CustomFormat = "dd-MMM-yyyy"
        dtpEndDate.Format = DateTimePickerFormat.Custom
        dtpEndDate.CustomFormat = "dd-MMM-yyyy"

        'Disable save button
        btnSave.Enabled = False

        'Centre Form
        Dim loadStndentTraining As New RADIANSETTINGS
        loadStndentTraining.CenterForm(Me)

        'Disable a few text boxes
        txtStudentID.Enabled = False
        txtFirstName.Enabled = False
        txtMiddleName.Enabled = False
        txtLastName.Enabled = False
        txtTrainNo.Enabled = False

        'Carry over data from previous form
        txtStudentID.Text = frmStudents.txtStudentID.Text
        txtFirstName.Text = frmStudents.txtFirstName.Text
        txtMiddleName.Text = frmStudents.txtMiddleName.Text
        txtLastName.Text = frmStudents.txtLastName.Text

        MysqlConn = New MySqlConnection
        Dim CString As New RADIANSETTINGS
        MysqlConn.ConnectionString = CString.ConnString
        Dim SDA As New MySqlDataAdapter
        Dim bSource As New BindingSource

        Try

            Dim Query As String
            Query = "SELECT TrainingID as 'ID', 
            fkStudentID as 'Student', Course, CertNo, Instructor, StartDate, EndDate, Certificate, Company, Notes, Cost
            FROM radiantraining.training WHERE fkStudentID = '" & txtStudentID.Text & "'"
            COMMAND = New MySqlCommand(Query, MysqlConn)

            MysqlConn.Open()
            SDA.SelectCommand = COMMAND
            SDA.Fill(dbDataSet)
            bSource.DataSource = dbDataSet
            DataGridView1.DataSource = bSource
            SDA.Update(dbDataSet)
            DataGridView1.ColumnHeadersDefaultCellStyle.Font = New Font(DataGridView1.Font, FontStyle.Bold)

            'Format Datagrid View
            DataGridView1.Columns(10).DefaultCellStyle.Format = "c"
            DataGridView1.Refresh()
            MysqlConn.Close()


        Catch ex As Exception

            MessageBox.Show(ex.Message)

        Finally

            MysqlConn.Close()

        End Try


    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick

        MysqlConn = New MySqlConnection
        Dim CString As New RADIANSETTINGS
        MysqlConn.ConnectionString = CString.ConnString

        DataGridView1.Refresh()

        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow
            row = Me.DataGridView1.Rows(e.RowIndex)
            txtTrainNo.Text = row.Cells("ID").Value.ToString
            cmbCourseName.Text = row.Cells("Course").Value.ToString
            txtCertNo.Text = row.Cells("CertNo").Value.ToString
            cmbInstructor.Text = row.Cells("Instructor").Value.ToString
            dtpStartDate.Text = row.Cells("StartDate").Value.ToString
            dtpEndDate.Text = row.Cells("EndDate").Value.ToString
            cmbCompany.Text = row.Cells("Company").Value.ToString
            txtNotes.Text = row.Cells("Notes").Value.ToString
            txtCost.Text = row.Cells("Cost").Value.ToString

            'Try Catch Block Courses Dropdown list
            Try
                MysqlConn.Open()
                Dim Query As String
                Query = "SELECT * from radiantraining.courses"
                COMMAND = New MySqlCommand(Query, MysqlConn)
                Dim READER As MySqlDataReader
                READER = COMMAND.ExecuteReader

                While READER.Read

                    Dim courseName = READER.GetString("CourseName")
                    cmbCourseName.Items.Add(courseName)

                End While

                MysqlConn.Close()

            Catch ex As Exception

                MessageBox.Show(ex.Message)
            Finally

                MysqlConn.Dispose()

            End Try

            'Try Catch Block Company Dropdown list
            Try
                MysqlConn.Open()
                Dim Query As String
                Query = "SELECT * from radiantraining.localcompany"
                COMMAND = New MySqlCommand(Query, MysqlConn)
                Dim READER As MySqlDataReader
                READER = COMMAND.ExecuteReader

                While READER.Read

                    Dim companyName = READER.GetString("CompanyName")
                    cmbCompany.Items.Add(companyName)

                End While

                MysqlConn.Close()

            Catch ex As Exception

                MessageBox.Show(ex.Message)
            Finally

                MysqlConn.Dispose()

            End Try

            'Try Catch Block Balance
            Try
                MysqlConn.Open()
                Dim Query As String
                Query = "SELECT * from radiantraining.payments WHERE TrainID='" & txtTrainNo.Text & "' 
                        AND StudentID='" & txtStudentID.Text & "'"
                COMMAND = New MySqlCommand(Query, MysqlConn)
                Dim READER As MySqlDataReader
                READER = COMMAND.ExecuteReader

                While READER.Read

                    Dim AmtPaid = Decimal.Parse(READER.GetString("AmtPaid"))
                    Dim Sum As Decimal
                    Sum = Sum + AmtPaid

                    Dim Cost As Decimal = txtCost.Text
                    txtBalance.Text = FormatCurrency((Cost - Sum), 2)

                End While

                MysqlConn.Close()

            Catch ex As Exception

                MessageBox.Show(ex.Message)

            Finally

                MysqlConn.Dispose()

            End Try

            'Try Catch Block Instructors Dropdown list
            Try
                MysqlConn.Open()
                Dim Query As String
                Query = "SELECT * from radiantraining.instructors"
                COMMAND = New MySqlCommand(Query, MysqlConn)
                Dim READER As MySqlDataReader
                READER = COMMAND.ExecuteReader

                While READER.Read

                    Dim instructorName = READER.GetString("InstructorName")
                    cmbInstructor.Items.Add(instructorName)

                End While

                MysqlConn.Close()

            Catch ex As Exception

                MessageBox.Show(ex.Message)
            Finally

                MysqlConn.Dispose()

            End Try

        Else

            MsgBox(e.ToString)

        End If

        txtCost.Text = FormatCurrency(txtCost.Text, 2)
        'Format Datagrid View
        DataGridView1.Columns(10).DefaultCellStyle.Format = "c"
        DataGridView1.Refresh()

    End Sub

    Private Sub btnPayment_Click(sender As Object, e As EventArgs) Handles btnPayment.Click

        If txtTrainNo.Text = "" And cmbCourseName.Text = "" Then

            MsgBox("Please select a Student Record!", vbOKOnly)

        Else

            frmPayment.Show()

        End If



    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click

        Select Case MsgBox("Would you like to create a new Training Record?", MsgBoxStyle.YesNo)

            Case MsgBoxResult.No

                Exit Sub
                btnSave.Enabled = False

            Case MsgBoxResult.Yes

                'Enable save button
                btnSave.Enabled = True

                MysqlConn = New MySqlConnection
                Dim CString As New RADIANSETTINGS
                MysqlConn.ConnectionString = CString.ConnString
                Dim READER As MySqlDataReader

                'Reload table data
                loadTable()

                ' Blank all text boxes
                txtTrainNo.ReadOnly = True
                cmbCourseName.Text = ""
                txtCertNo.Text = ""
                cmbInstructor.Text = ""
                dtpStartDate.ResetText()
                dtpEndDate.ResetText()
                cmbCompany.Text = ""
                txtNotes.Text = ""

                'Try Catch Block Course Name
                Try
                    MysqlConn.Open()
                    Dim Query As String
                    Query = "select * from radiantraining.courses"
                    COMMAND = New MySqlCommand(Query, MysqlConn)
                    READER = COMMAND.ExecuteReader

                    While READER.Read

                        Dim courseName = READER.GetString("courseName")
                        cmbCourseName.Items.Add(courseName)

                    End While

                    MysqlConn.Close()

                Catch ex As Exception

                    MessageBox.Show(ex.Message)
                Finally

                    MysqlConn.Dispose()

                End Try

                'Try Catch Block Instructor
                Try
                    MysqlConn.Open()
                    Dim Query As String
                    Query = "select * from radiantraining.instructors"
                    COMMAND = New MySqlCommand(Query, MysqlConn)
                    READER = COMMAND.ExecuteReader

                    While READER.Read

                        Dim instructorName = READER.GetString("InstructorName")
                        cmbInstructor.Items.Add(instructorName)

                    End While
                    MysqlConn.Close()

                Catch ex As Exception

                    MessageBox.Show(ex.Message)
                Finally

                    MysqlConn.Dispose()

                End Try

                'Try Catch Block Company
                Try
                    MysqlConn.Open()
                    Dim Query As String
                    Query = "select * from radiantraining.localcompany"
                    COMMAND = New MySqlCommand(Query, MysqlConn)
                    READER = COMMAND.ExecuteReader

                    While READER.Read

                        Dim localCompanyName = READER.GetString("companyName")
                        cmbCompany.Items.Add(localCompanyName)

                    End While
                    MysqlConn.Close()

                Catch ex As Exception

                    MessageBox.Show(ex.Message)
                Finally

                    MysqlConn.Dispose()

                End Try

        End Select

    End Sub

    Private Sub loadTable()

        MysqlConn = New MySqlConnection
        Dim CString As New RADIANSETTINGS
        MysqlConn.ConnectionString = CString.ConnString
        Dim SDA As New MySqlDataAdapter
        Dim dbDataSet As New DataTable
        Dim bSource As New BindingSource

        Try
            MysqlConn.Open()
            Dim Query As String
            Query = "select TrainingID as 'ID', 
            fkStudentID as 'Student', Course, CertNo, Instructor, StartDate, EndDate, Certificate, Notes, Company
            from radiantraining.training WHERE fkStudentID ='" & txtStudentID.Text & "'"

            COMMAND = New MySqlCommand(Query, MysqlConn)
            SDA.SelectCommand = COMMAND
            SDA.Fill(dbDataSet)
            bSource.DataSource = dbDataSet
            DataGridView1.DataSource = bSource
            SDA.Update(dbDataSet)
            DataGridView1.ColumnHeadersDefaultCellStyle.Font = New Font(DataGridView1.Font, FontStyle.Bold)
            MysqlConn.Close()

        Catch ex As Exception

            MessageBox.Show(ex.Message)
        Finally

            MysqlConn.Dispose()

        End Try

    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

        MysqlConn = New MySqlConnection
        Dim CString As New RADIANSETTINGS
        MysqlConn.ConnectionString = CString.ConnString
        Dim READER As MySqlDataReader

        'Try Catch Block
        Try

            MysqlConn.Open()
            Dim Query As String
            Query = "Update radiantraining.training SET
            Course='" & cmbCourseName.Text & "',
            CertNo='" & txtCertNo.Text & "',
            Instructor='" & cmbInstructor.Text & "',
            StartDate='" & dtpStartDate.Text & "',
            Notes='" & txtNotes.Text & "',
            Company='" & cmbCompany.Text & "',
            Cost = '" & txtCost.Text & "'
            WHERE fkStudentID='" & txtStudentID.Text & "' AND TrainingID='" & txtTrainNo.Text & "'"

            COMMAND = New MySqlCommand(Query, MysqlConn)
            READER = COMMAND.ExecuteReader

            MsgBox("Successfully Updated")
            'Refresh Data
            loadTable()
            MysqlConn.Close()

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        Finally

            MysqlConn.Dispose()

        End Try

    End Sub

    Private Sub btndelete_Click(sender As Object, e As EventArgs) Handles btndelete.Click

        MysqlConn = New MySqlConnection
        'Connection String
        Dim CString As New RADIANSETTINGS
        MysqlConn.ConnectionString = CString.ConnString
        Dim READER As MySqlDataReader

        'Try Catch Block
        Try

            MysqlConn.Open()
            Dim Query As String
            Query = "DELETE from radiantraining.training WHERE fkStudentID='" & txtStudentID.Text & "' AND TrainingID='" & txtTrainNo.Text & "'"
            COMMAND = New MySqlCommand(Query, MysqlConn)
            READER = COMMAND.ExecuteReader
            Select Case (MsgBox("You are about to delete a Record - '" & txtFirstName.Text & " " & txtLastName.Text & "'", MsgBoxStyle.YesNo))

                Case MsgBoxResult.No

                    Exit Sub

                Case MsgBoxResult.Yes

                    MsgBox("Record Deleted - " & txtFirstName.Text & " " & txtLastName.Text)

            End Select

            'Refresh Data - Call function
            loadTable()
            MysqlConn.Close()

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        Finally

            'Blank all fields on load
            cmbCourseName.Text = ""
            txtCertNo.Text = ""
            cmbInstructor.Text = ""
            dtpStartDate.ResetText()
            dtpEndDate.ResetText()
            cmbCompany.Text = ""
            txtNotes.Text = ""
            txtCost.Text = ""

            MysqlConn.Dispose()

        End Try

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        MysqlConn = New MySqlConnection
        Dim CString As New RADIANSETTINGS
        MysqlConn.ConnectionString = CString.ConnString
        Dim READER As MySqlDataReader

        'Refresh the data
        DataGridView1.Refresh()

        'Try Catch Block
        Try

            If cmbCourseName.Text = "" Or cmbInstructor.Text = "" Or txtCertNo.Text = "" Then
                MsgBox("Please enter Valid Information!")

            Else
                MysqlConn.Open()
                Dim Query As String
                Query = "INSERT INTO radiantraining.training
                (fkStudentID, Course, CertNo, Instructor, StartDate, EndDate, Company, Notes, Cost)
                VALUES(
                '" & txtStudentID.Text & "',
                '" & cmbCourseName.Text & "',
                '" & txtCertNo.Text & "',
                '" & cmbInstructor.Text & "',
                '" & dtpStartDate.Text & "',
                '" & dtpEndDate.Text & "',
                '" & cmbCompany.Text & "',                
                '" & txtNotes.Text & "',
                '" & txtCost.Text & "'
                 )"

                COMMAND = New MySqlCommand(Query, MysqlConn)
                READER = COMMAND.ExecuteReader

                MsgBox("Successfully Entered")

                'Refresh Data
                loadTable()
                MysqlConn.Close()

            End If

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        Finally

            MysqlConn.Dispose()

        End Try

    End Sub

    Private Sub btnAttach_Click(sender As Object, e As EventArgs) Handles btnAttach.Click

        If txtCertNo.Text = "" Then

            MessageBox.Show("Please enter Certificate#", "RADIAN Training", MessageBoxButtons.OK, MessageBoxIcon.Hand)

        ElseIf System.IO.File.Exists(My.Settings.CertPath & "\" & txtFirstName.Text.ToLower() & "_" & txtLastName.Text.ToLower() & "_" & txtCertNo.Text & ".pdf") = False Then

            Dim fd As OpenFileDialog = New OpenFileDialog()
            Dim strFileName As String
            fd.Title = "Select PDF File"
            fd.InitialDirectory = "C:\"
            fd.Filter = "PDF files (*.pdf)|*.pdf"
            fd.FilterIndex = 2
            fd.RestoreDirectory = True

            If fd.ShowDialog() = DialogResult.OK Then
                Try

                    strFileName = fd.FileName
                    System.IO.File.Copy(strFileName, My.Settings.CertPath & "\" & txtFirstName.Text.ToLower() & "_" & txtLastName.Text.ToLower() & "_" & txtCertNo.Text & ".pdf", True)
                    MsgBox("File Successfully Uploaded - " & txtCertNo.Text & ".pdf")

                Catch ex As Exception
                    MsgBox(ex.Message)

                End Try

            End If

        Else

            Select Case MsgBox("File already exists!" & vbCrLf & "Would you like to replace?", MsgBoxStyle.YesNo)

                Case MsgBoxResult.No
                    Exit Sub
                Case MsgBoxResult.Yes

                    Dim fd As OpenFileDialog = New OpenFileDialog()
                    Dim strFileName As String

                    fd.Title = "Select PDF File"
                    fd.InitialDirectory = "C:\"
                    fd.Filter = "PDF files (*.pdf)|*.pdf"
                    fd.FilterIndex = 2
                    fd.RestoreDirectory = True

                    If fd.ShowDialog() = DialogResult.OK Then

                        strFileName = fd.FileName
                        System.IO.File.Copy(strFileName, My.Settings.CertPath & "\" & txtFirstName.Text.ToLower() & "_" & txtLastName.Text.ToLower() & "_" & txtCertNo.Text & ".pdf", True)
                        MsgBox("File replaced - " & txtCertNo.Text & ".pdf")

                    End If


            End Select

        End If

    End Sub

    Private Sub btnViewNationalID_Click(sender As Object, e As EventArgs) Handles btnViewNationalID.Click

        Try
            Process.Start(My.Settings.CertPath & "\" & txtFirstName.Text & "_" & txtLastName.Text & "_" & txtCertNo.Text & ".pdf")

        Catch ex As Exception
            MsgBox("File does not exist. Please upload.")
        End Try

    End Sub

    Private Sub cmbCourseName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCourseName.SelectedIndexChanged

        MysqlConn = New MySqlConnection
        Dim CString As New RADIANSETTINGS
        MysqlConn.ConnectionString = CString.ConnString
        Dim READER As MySqlDataReader

        'Try Catch Block Cost
        Try
            MysqlConn.Open()
            Dim Query As String
            Query = "SELECT * from radiantraining.courses WHERE CourseName = '" & cmbCourseName.Text & "'"
            COMMAND = New MySqlCommand(Query, MysqlConn)
            READER = COMMAND.ExecuteReader

            While READER.Read

                Dim cost = READER.GetString("Cost")
                txtCost.Text = cost

            End While

            MysqlConn.Close()

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        Finally

            MysqlConn.Dispose()

        End Try

    End Sub

End Class