Imports MySql.Data.MySqlClient
Public Class frmPayment
    Dim MySqlConn As MySqlConnection
    Dim COMMAND As MySqlCommand
    Dim dbDataSet As New DataTable
    Private Sub Payment_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Centre Form
        Dim loadStudentsForm As New RadianSettings
        loadStudentsForm.CenterForm(Me)

        'Format date time pickers at load
        dtpDatePaid.Format = DateTimePickerFormat.Custom
        dtpDatePaid.CustomFormat = "dd-MMM-yyyy"

        'Format Currency
        txtAmtPaid.Text = Format(txtAmtPaid.Text, "$0.00")
        txtCost.Text = Format(txtCost.Text, "$0.00")
        txtBalance.Text = Format(txtBalance.Text, "$0.00")

        'Disable Controls
        btnSave.Enabled = False
        txtStudentID.Enabled = False
        txtFirstName.Enabled = False
        txtMiddleName.Enabled = False
        txtLastName.Enabled = False
        txtCourseName.Enabled = False
        txtTrainID.Enabled = False
        txtEnteredBy.Enabled = False
        txtBalance.Enabled = False
        txtCost.Enabled = False

        'Load previous form values
        txtStudentID.Text = frmStudentTraining.txtStudentID.Text
        txtFirstName.Text = frmStudentTraining.txtFirstName.Text
        txtMiddleName.Text = frmStudentTraining.txtMiddleName.Text
        txtLastName.Text = frmStudentTraining.txtLastName.Text
        txtCourseName.Text = frmStudentTraining.cmbCourseName.Text
        txtTrainID.Text = frmStudentTraining.txtTrainNo.Text
        txtBalance.Text = frmStudentTraining.txtBalance.Text
        txtCost.Text = frmStudentTraining.txtCost.Text

        MySqlConn = New MySqlConnection
        MySqlConn.ConnectionString = "server=localhost;userid=root;password=root;database=radiantraining"
        Dim SDA As New MySqlDataAdapter
        Dim bSource As New BindingSource

        Try
            MySqlConn.Open()
            Dim Query As String
            Query = "SELECT idPayments as 'PayID', CourseName, DatePaid, AmtPaid, Payee, Entered, ReceiptNo
            from radiantraining.payments WHERE StudentID = '" & txtStudentID.Text & "' AND TrainID = '" & txtTrainID.Text & "'"
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
            txtPayID.Text = row.Cells("PayID").Value.ToString
            txtCourseName.Text = row.Cells("CourseName").Value.ToString
            dtpDatePaid.Text = row.Cells("DatePaid").Value.ToString
            txtAmtPaid.Text = Format(row.Cells("AmtPaid").Value.ToString, "$0.00")
            txtPayee.Text = row.Cells("Payee").Value.ToString
            txtEnteredBy.Text = row.Cells("Entered").Value.ToString
            txtReceiptNo.Text = row.Cells("ReceiptNo").Value.ToString

        End If

    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

        MySqlConn = New MySqlConnection
        MySqlConn.ConnectionString = "server=localhost;userid=root;password=root;database=radiantraining"
        Dim READER As MySqlDataReader

        'Try Catch Block
        Try

            MySqlConn.Open()
            Dim Query As String
            Query = "Update radiantraining.payments SET
            DatePaid='" & dtpDatePaid.Text & "',
            AmtPaid='" & txtAmtPaid.Text & "',
            Payee='" & txtPayee.Text & "',
            ReceiptNo = '" & txtReceiptNo.Text & "',
            Entered = '" & txtEnteredBy.Text & "'
            WHERE idPayments='" & txtPayID.Text & "'"

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

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click

        Select Case MsgBox("Would you like to create a new Payment Record?", MsgBoxStyle.YesNo)

            Case MsgBoxResult.No

                Exit Sub

            Case MsgBoxResult.Yes

                'Enable save button
                btnSave.Enabled = True

                MySqlConn = New MySqlConnection
                MySqlConn.ConnectionString = "server=localhost;userid=root;password=root;database=radiantraining"

                'Reload table data
                loadTable()

                ' Blank all text boxes
                txtStudentID.ReadOnly = True
                txtFirstName.ReadOnly = True
                txtMiddleName.ReadOnly = True
                txtPayID.ReadOnly = True
                txtTrainID.ReadOnly = True
                txtCourseName.ReadOnly = True
                txtEnteredBy.ReadOnly = True
                dtpDatePaid.ResetText()
                txtTrainID.Text = frmStudentTraining.txtTrainNo.Text
                txtCost.Text = ""
                txtReceiptNo.Text = ""
                txtAmtPaid.Text = ""
                txtPayee.Text = ""
                txtEnteredBy.Text = StrConv(frmLogin.txtUsername.Text, VbStrConv.ProperCase)

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
            Query = "SELECT idPayments as 'PayID', StudentID, CourseName, DatePaid, AmtPaid, Payee, Entered, ReceiptNo
            from radiantraining.payments WHERE StudentID = '" & txtStudentID.Text & "' AND TrainID = '" & txtTrainID.Text & "'"

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

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        MySqlConn = New MySqlConnection
        MySqlConn.ConnectionString = "server=localhost;userid=root;password=root;database=radiantraining"
        Dim READER As MySqlDataReader

        'Try Catch Block
        Try

            If txtAmtPaid.Text = "" And txtPayee.Text = "" Then

                MsgBox("Please enter Amount and Payee Information!")

            Else
                MySqlConn.Open()
                Dim Query As String
                Query = "INSERT INTO radiantraining.payments
                (TrainID, StudentID, CourseName, DatePaid, AmtPaid, Payee, ReceiptNo, Entered)
                VALUES(
                '" & txtTrainID.Text & "',
                '" & txtStudentID.Text & "',
                '" & txtCourseName.Text & "',
                '" & dtpDatePaid.Text & "',
                '" & txtAmtPaid.Text & "',
                '" & txtPayee.Text & "',
                '" & txtReceiptNo.Text & "',
                '" & StrConv(frmLogin.txtUsername.Text, VbStrConv.ProperCase) & "'
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

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        MySqlConn = New MySqlConnection
        'Connection String
        MySqlConn.ConnectionString = "server=localhost;userid=root;password=root;database=radiantraining"
        Dim READER As MySqlDataReader

        'Try Catch Block
        Try

            MySqlConn.Open()
            Dim Query As String
            Query = "DELETE from radiantraining.payments WHERE idPayments='" & txtPayID.Text & "'"
            COMMAND = New MySqlCommand(Query, MySqlConn)
            READER = COMMAND.ExecuteReader
            Select Case (MsgBox("You are about to delete a Payment - '" & txtFirstName.Text & " " & txtLastName.Text & "'", MsgBoxStyle.YesNo))

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
            txtCourseName.Text = ""
            dtpDatePaid.ResetText()
            txtAmtPaid.Text = ""
            txtPayee.ResetText()

            MySqlConn.Dispose()

        End Try

    End Sub
End Class