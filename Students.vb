Imports MySql.Data.MySqlClient
Public Class frmStudents
    Dim MySqlConn As MySqlConnection
    Dim COMMAND As MySqlCommand
    Dim dbDataSet As New DataTable

    Private Sub FrmStudents_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Disable Save Button
        btnSave.Enabled = False

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
        txtStudentID.Text = ""
        txtStudentAddress.Text = ""
        cmbCity.Text = ""
        txtSearchStudent.Text = ""
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

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick

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

            'Try Catch Block City Name Dropdown list
            Try
                MySqlConn.Open()
                Dim Query As String
                Query = "select * from radiantraining.City"
                COMMAND = New MySqlCommand(Query, MySqlConn)
                Dim READER As MySqlDataReader
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

            'Try Catch Block Company Name Dropdown list
            Try
                MySqlConn.Open()
                Dim Query As String
                Query = "select * from radiantraining.localcompany"
                COMMAND = New MySqlCommand(Query, MySqlConn)
                Dim READER As MySqlDataReader
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

            Dim picName As String
            picName = row.Cells("Picture").Value.ToString
            Try
                Dim fs As System.IO.FileStream
                If String.IsNullOrEmpty(picName) Then
                    fs = New System.IO.FileStream(My.Settings.PicturePath & "\" & "default.jpg", IO.FileMode.Open, IO.FileAccess.ReadWrite)
                    Me.picBoxStudent.Image = System.Drawing.Image.FromStream(fs)
                Else
                    fs = New System.IO.FileStream(My.Settings.PicturePath & "\" & picName & ".jpg", IO.FileMode.Open, IO.FileAccess.ReadWrite)
                    Me.picBoxStudent.Image = System.Drawing.Image.FromStream(fs)
                End If

                fs.Close()

            Catch ex As Exception

                MsgBox(ex.Message)

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

        Select Case MsgBox("Would you like to create a new record?", MsgBoxStyle.YesNo)

            Case MsgBoxResult.No

                Exit Sub

            Case MsgBoxResult.Yes

                'Enable save button
                btnSave.Enabled = True

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
                cmbCompanyName.Text = ""
                txtDriversPermitNo.Text = ""

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

        End Select

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
            Notes='" & txtNotes.Text & "'
            where StudentID='" & txtStudentID.Text & "'"

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

        If txtNationalID.Text = "" Then

            MessageBox.Show("Please enter National ID#", "RADIAN Training", MessageBoxButtons.OK, MessageBoxIcon.Hand)

        ElseIf System.IO.File.Exists(My.Settings.NationalIDPath & "\" & txtNationalID.Text & ".pdf") = False Then

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
                    System.IO.File.Copy(strFileName, My.Settings.NationalIDPath & "\" & txtNationalID.Text & ".pdf", True)

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
                        System.IO.File.Copy(strFileName, My.Settings.NationalIDPath & "\" & txtNationalID.Text & ".pdf", True)
                    End If

            End Select

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
                Query = "INSERT INTO radiantraining.students
                (FirstName, MiddleName, LastName, Company, Address, City, Mobile, Home, Other, NationalIDNo,
                DriversPermitNo, PassportNo, Email, Notes )
                VALUES(
                '" & txtFirstName.Text & "',
                '" & txtMiddleName.Text & "',
                '" & txtLastName.Text & "',
                '" & cmbCompanyName.Text & "',
                '" & txtStudentAddress.Text & "',
                '" & cmbCity.Text & "',                
                '" & txtMobile.Text & "',
                '" & txtHome.Text & "',
                '" & txtOther.Text & "',
                '" & txtNationalID.Text & "',
                '" & txtDriversPermitNo.Text & "',
                '" & txtPassportNo.Text & "',
                '" & txtEmailAddress.Text & "',
                '" & txtNotes.Text & "'
                )"

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
        'Connection String
        MySqlConn.ConnectionString = "server=localhost;userid=root;password=root;database=radiantraining"
        Dim READER As MySqlDataReader

        'Try Catch Block
        Try

            MySqlConn.Open()
            Dim Query As String
            Query = "DELETE from radiantraining.students where StudentID='" & txtStudentID.Text & "'"
            COMMAND = New MySqlCommand(Query, MySqlConn)
            READER = COMMAND.ExecuteReader
            Select Case (MsgBox("You are about to delete a record", MsgBoxStyle.YesNo))

                Case MsgBoxResult.No

                    Exit Sub

                Case MsgBoxResult.Yes

                    MsgBox("Record Deleted - " & txtFirstName.Text & " " & txtLastName.Text)

            End Select

            'Refresh Data - Call function
            loadTable()
            MySqlConn.Close()

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        Finally

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

            MySqlConn.Dispose()

        End Try

    End Sub

    Private Sub PicBoxStudent_Click(sender As Object, e As EventArgs) Handles picBoxStudent.Click


        Dim studentFileName As String = Format(Now, "yyyy-MM-dd-hh-mm-ss")

        If System.IO.File.Exists(My.Settings.PicturePath & "\" & studentFileName & ".jpg") = True Or System.IO.File.Exists(My.Settings.PicturePath & "\default.jpg") = True Then
            Select Case MsgBox("Image already exist, would you like to replace?", MsgBoxStyle.YesNo)
                Case MsgBoxResult.No
                    Exit Sub
                Case MsgBoxResult.Yes
                    Dim fd As OpenFileDialog = New OpenFileDialog()
                    Dim strFileName As String
                    fd.Title = "Select Image File"
                    fd.InitialDirectory = "C:\"
                    fd.Filter = "JPG files |*.jpg; *.jpeg"
                    fd.FilterIndex = 2
                    fd.RestoreDirectory = True

                    If fd.ShowDialog() = DialogResult.OK Then

                        Me.picBoxStudent.Image.Dispose()
                        Me.picBoxStudent.Image = Nothing
                        System.GC.Collect()
                        System.IO.File.Delete(My.Settings.PicturePath & "\" & studentFileName & ".jpg")

                        strFileName = fd.FileName
                        MySqlConn.Open()
                        Dim Query As String
                        Dim READER As MySqlDataReader
                        Query = "Update radiantraining.students set
                                Picture='" & studentFileName & "'
                                where StudentID='" & txtStudentID.Text & "'"
                        COMMAND = New MySqlCommand(Query, MySqlConn)
                        READER = COMMAND.ExecuteReader

                        System.IO.File.Copy(strFileName, My.Settings.PicturePath & "\" & studentFileName & ".jpg", True)
                        Dim fs As System.IO.FileStream
                        fs = New System.IO.FileStream(My.Settings.PicturePath & "\" & studentFileName & ".jpg", IO.FileMode.Open, IO.FileAccess.Read)
                        picBoxStudent.Image = System.Drawing.Image.FromStream(fs)
                        fs.Close()

                        MsgBox("Student image updated...")
                        'Refresh Data
                        loadTable()
                        MySqlConn.Close()

                    End If

            End Select
        End If

    End Sub

    Private Sub BtnViewNationalID_Click(sender As Object, e As EventArgs) Handles btnViewNationalID.Click

        Try
            Process.Start(My.Settings.NationalIDPath & "\" & txtNationalID.Text & ".pdf")

        Catch ex As Exception
            MsgBox("File does not exist. Please upload.")
        End Try

    End Sub

    Private Sub BtnViewPassport_Click(sender As Object, e As EventArgs) Handles btnViewPassport.Click

        Try
            Process.Start(My.Settings.PassportPath & "\" & txtPassportNo.Text & ".pdf")

        Catch ex As Exception
            MsgBox("File does not exist. Please upload.")
        End Try

    End Sub

    Private Sub BtnViewDriversPermit_Click(sender As Object, e As EventArgs) Handles btnViewDriversPermit.Click

        Try
            Process.Start(My.Settings.DriversPermitPath & "\" & txtDriversPermitNo.Text & ".pdf")

        Catch ex As Exception
            MsgBox("File does not exist. Please upload.")
        End Try

    End Sub

    Private Sub BtnAttachPassport_Click(sender As Object, e As EventArgs) Handles btnAttachPassport.Click

        If txtPassportNo.Text = "" Then

            MessageBox.Show("Please enter Passport#", "RADIAN Training", MessageBoxButtons.OK, MessageBoxIcon.Hand)

        ElseIf System.IO.File.Exists(My.Settings.PassportPath & "\" & txtPassportNo.Text & ".pdf") = False Then

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
                    System.IO.File.Copy(strFileName, My.Settings.PassportPath & "\" & txtPassportNo.Text & ".pdf", True)

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
                        System.IO.File.Copy(strFileName, My.Settings.PassportPath & "\" & txtPassportNo.Text & ".pdf", True)
                    End If

            End Select

        End If

    End Sub

    Private Sub BtnAttachDriversPermit_Click(sender As Object, e As EventArgs) Handles btnAttachDriversPermit.Click

        If txtDriversPermitNo.Text = "" Then

            MessageBox.Show("Please enter Driver's Permit No.", "RADIAN Training", MessageBoxButtons.OK, MessageBoxIcon.Hand)

        ElseIf System.IO.File.Exists(My.Settings.DriversPermitPath & "\" & txtDriversPermitNo.Text & ".pdf") = False Then

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
                    System.IO.File.Copy(strFileName, My.Settings.DriversPermitPath & "\" & txtDriversPermitNo.Text & ".pdf", True)

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
                        System.IO.File.Copy(strFileName, My.Settings.DriversPermitPath & "\" & txtDriversPermitNo.Text & ".pdf", True)
                    End If

            End Select

        End If

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub BtnNewCompany_Click(sender As Object, e As EventArgs) Handles btnNewCompany.Click

        frmLocalCompany.Show()

    End Sub

    Private Sub BtnNewCity_Click(sender As Object, e As EventArgs) Handles btnNewCity.Click

        City.Show()

    End Sub

    Private Sub TxtPassportNo_TextChanged(sender As Object, e As EventArgs) Handles txtPassportNo.TextChanged

        Try
            txtPassportNo.MaxLength = "8"

        Catch ex As Exception
            MsgBox("Please check the amount of characters entered")
        End Try

    End Sub

    Private Sub TxtNationalID_TextChanged(sender As Object, e As EventArgs) Handles txtNationalID.TextChanged

        Try
            txtNationalID.MaxLength = "11"

        Catch ex As Exception
            MsgBox("Please check the amount of characters entered")
        End Try

    End Sub

    Private Sub TxtDriversPermitNo_TextChanged(sender As Object, e As EventArgs) Handles txtDriversPermitNo.TextChanged

        Try
            txtDriversPermitNo.MaxLength = "7"

        Catch ex As Exception
            MsgBox("Please check the amount of characters entered")
        End Try

    End Sub

    Private Sub btnTraining_Click(sender As Object, e As EventArgs) Handles btnTraining.Click

        frmStudentTraining.Show()

    End Sub
End Class