Imports MySql.Data.MySqlClient

Public Class frmCourses
    Dim MySqlConn As MySqlConnection
    Dim COMMAND As MySqlCommand

    Private Sub frmCourses_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Disable save button
        btnSave.Enabled = False

        'Centre Form
        Dim contactForm As New RADIANSETTINGS
        contactForm.CenterForm(Me)

        'Disable Controls
        txtCourseID.Enabled = False

        MySqlConn = New MySqlConnection
        Dim CString As New RADIANSETTINGS
        MySqlConn.ConnectionString = CString.ConnString
        Dim SDA As New MySqlDataAdapter
        Dim dbDataSet As New DataTable
        Dim bSource As New BindingSource

        'Blank all fields on load
        txtCourseID.Text = ""
        txtCourseCode.Text = ""
        txtCourseName.Text = ""
        txtCost.Text = FormatCurrency(0.00, 2)

        Try
            MySqlConn.Open()
            Dim Query As String
            Query = "SELECT idCourses as 'ID', CourseCode, CourseName, Cost from radiantraining.courses"
            COMMAND = New MySqlCommand(Query, MySqlConn)

            SDA.SelectCommand = COMMAND
            SDA.Fill(dbDataSet)
            bSource.DataSource = dbDataSet
            DataGridView1.DataSource = bSource
            SDA.Update(dbDataSet)
            DataGridView1.ColumnHeadersDefaultCellStyle.Font = New Font(DataGridView1.Font, FontStyle.Bold)

            'Format Datagrid View
            DataGridView1.Columns(3).DefaultCellStyle.Format = "c"
            DataGridView1.Refresh()

            MySqlConn.Close()

        Catch ex As Exception

            MessageBox.Show(ex.Message)
        Finally

            MySqlConn.Dispose()

        End Try

    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick

        MySqlConn = New MySqlConnection
        Dim CString As New RADIANSETTINGS
        MySqlConn.ConnectionString = CString.ConnString

        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow
            row = Me.DataGridView1.Rows(e.RowIndex)
            txtCourseID.Text = row.Cells("ID").Value.ToString
            txtCourseCode.Text = row.Cells("CourseCode").Value.ToString
            txtCourseName.Text = row.Cells("CourseName").Value.ToString
            If row.Cells("Cost").Value.ToString = "" Then
                txtCost.Text = FormatCurrency(0.00, 2)
            Else
                txtCost.Text = FormatCurrency(row.Cells("Cost").Value.ToString, 2)
            End If

            MySqlConn.Dispose()

        End If

    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click

        Select Case MsgBox("Would you like to create a new Course?", MsgBoxStyle.YesNo)

            Case MsgBoxResult.No

                Exit Sub

            Case MsgBoxResult.Yes

                'Enable save button
                btnSave.Enabled = True

                'Reload table data
                loadTable()

                ' Blank all text boxes
                txtCourseID.ReadOnly = True
                txtCourseCode.Text = ""
                txtCourseName.Text = ""
                txtCost.Text = ""

        End Select

    End Sub

    Private Sub loadTable()

        MySqlConn = New MySqlConnection
        Dim CString As New RADIANSETTINGS
        MySqlConn.ConnectionString = CString.ConnString
        Dim SDA As New MySqlDataAdapter
        Dim dbDataSet As New DataTable
        Dim bSource As New BindingSource

        Try
            MySqlConn.Open()
            Dim Query As String
            Query = "SELECT idCourses as 'ID', CourseCode, CourseName, Cost from radiantraining.courses"
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

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

        MySqlConn = New MySqlConnection
        Dim CString As New RADIANSETTINGS
        MySqlConn.ConnectionString = CString.ConnString
        Dim READER As MySqlDataReader

        'Try Catch Block
        Try

            MySqlConn.Open()
            Dim Query As String
            Query = "UPDATE radiantraining.courses SET
            CourseCode='" & txtCourseCode.Text & "',
            CourseName='" & txtCourseName.Text & "',
            Cost='" & txtCost.Text & "'
            WHERE idcontacts ='" & txtCourseID.Text & "'"

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

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        MySqlConn = New MySqlConnection
        'Connection String
        Dim CString As New RADIANSETTINGS
        MySqlConn.ConnectionString = CString.ConnString
        Dim READER As MySqlDataReader

        'Try Catch Block
        Try

            MySqlConn.Open()
            Dim Query As String
            Query = "DELETE from radiantraining.courses WHERE idCourses='" & txtCourseID.Text & "'"
            COMMAND = New MySqlCommand(Query, MySqlConn)
            READER = COMMAND.ExecuteReader
            Select Case (MsgBox("You are about to delete a Course!", MsgBoxStyle.YesNo))

                Case MsgBoxResult.No

                    Exit Sub

                Case MsgBoxResult.Yes

                    MsgBox("Record Deleted - " & txtCourseCode.Text & "-" & txtCourseName.Text)

            End Select

            'Refresh Data - Call function
            loadTable()
            MySqlConn.Close()

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        Finally

            'Blank all fields on load
            txtCourseID.Text = ""
            txtCourseCode.Text = ""
            txtCourseName.Text = ""
            txtCost.Text = ""

            MySqlConn.Dispose()

        End Try

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        MySqlConn = New MySqlConnection
        Dim CString As New RADIANSETTINGS
        MySqlConn.ConnectionString = CString.ConnString
        Dim READER As MySqlDataReader

        'Try Catch Block
        Try

            If txtCourseName.Text = "" And txtCourseCode.Text = "" And txtCost.Text = "" Then
                MsgBox("Please enter valid Course information!")
            Else
                MySqlConn.Open()
                Dim Query As String
                Query = "INSERT INTO radiantraining.courses (CourseCode, CourseName, Cost)
                VALUES (
                '" & txtCourseCode.Text & "',
                '" & txtCourseName.Text & "',
                '" & txtCost.Text & "'
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
End Class