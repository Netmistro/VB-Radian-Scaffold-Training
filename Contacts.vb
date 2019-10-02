Imports MySql.Data.MySqlClient

Public Class frmContacts
    Dim MySqlConn As MySqlConnection
    Dim COMMAND As MySqlCommand

    Private Sub FrmForeignCompany_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Disable save button
        btnSave.Enabled = False

        'Centre Form
        Dim contactForm As New RADIANSETTINGS
        contactForm.CenterForm(Me)

        'Disable Controls
        txtContactID.Enabled = False

        'Check to see if the local of foreign company form is open
        Dim Contact As String
        Dim Company As Int32
        If Application.OpenForms.OfType(Of Form).Contains(frmForeignCompany) Then

            Contact = "Foreign"
            Company = frmForeignCompany.txtCompanyID.Text

        Else

            Contact = "Local"
            Company = frmLocalCompany.txtCompanyID.Text

        End If

        MySqlConn = New MySqlConnection
        Dim CString As New RADIANSETTINGS
        MySqlConn.ConnectionString = CString.ConnString
        Dim SDA As New MySqlDataAdapter
        Dim dbDataSet As New DataTable
        Dim bSource As New BindingSource

        'Blank all fields on load
        txtContactID.Text = ""
        txtName.Text = ""
        txtPosition.Text = ""
        txtMobile.Text = ""
        txtEmail.Text = ""

        Try
            MySqlConn.Open()
            Dim Query As String
            Query = "SELECT idcontacts as 'ID', ContactName, Position, Mobile, Email, ContactType, Company
            from radiantraining.contacts WHERE Company ='" & Company & "' AND ContactType = '" & Contact & "'"
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
        Dim CString As New RADIANSETTINGS
        MySqlConn.ConnectionString = CString.ConnString

        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow
            row = Me.DataGridView1.Rows(e.RowIndex)
            txtContactID.Text = row.Cells("ID").Value.ToString
            txtName.Text = row.Cells("ContactName").Value.ToString
            txtPosition.Text = row.Cells("Position").Value.ToString
            txtMobile.Text = row.Cells("Mobile").Value.ToString
            txtEmail.Text = row.Cells("Email").Value.ToString

            MySqlConn.Dispose()

        End If

    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click

        Select Case MsgBox("Would you like to create a new Contact?", MsgBoxStyle.YesNo)

            Case MsgBoxResult.No

                Exit Sub

            Case MsgBoxResult.Yes

                'Enable save button
                btnSave.Enabled = True

                'Reload table data
                loadTable()

                ' Blank all text boxes
                txtContactID.ReadOnly = True
                txtName.Text = ""
                txtPosition.Text = ""
                txtMobile.Text = ""
                txtEmail.Text = ""

        End Select

    End Sub

    Private Sub loadTable()

        MySqlConn = New MySqlConnection
        Dim CString As New RADIANSETTINGS
        MySqlConn.ConnectionString = CString.ConnString
        Dim SDA As New MySqlDataAdapter
        Dim dbDataSet As New DataTable
        Dim bSource As New BindingSource

        'Check to see if the local of foreign company form is open
        Dim Contact As String
        Dim Company As Int32
        If Application.OpenForms.OfType(Of Form).Contains(frmForeignCompany) Then

            Contact = "Foreign"
            Company = frmForeignCompany.txtCompanyID.Text

        Else

            Contact = "Local"
            Company = frmLocalCompany.txtCompanyID.Text

        End If

        Try
            MySqlConn.Open()
            Dim Query As String
            Query = "SELECT idcontacts as 'ID', ContactName, Position, Mobile, Email, ContactType, Company
            from radiantraining.contacts WHERE Company ='" & Company & "' AND ContactType = '" & Contact & "'"
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

        'Check to see if the local of foreign company form is open
        Dim Contact As String
        Dim Company As Int32
        If Application.OpenForms.OfType(Of Form).Contains(frmForeignCompany) Then

            Contact = "Foreign"
            Company = frmForeignCompany.txtCompanyID.Text

        Else

            Contact = "Local"
            Company = frmLocalCompany.txtCompanyID.Text

        End If

        'Try Catch Block
        Try

            MySqlConn.Open()
            Dim Query As String
            Query = "UPDATE radiantraining.contacts SET
            ContactName='" & txtName.Text & "',
            Position='" & txtPosition.Text & "',
            Mobile='" & txtMobile.Text & "',
            Email='" & txtEmail.Text & "',
            ContactType = '" & Contact & "',
            Company='" & Company & "'
            WHERE idcontacts ='" & txtContactID.Text & "'"

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
            Query = "DELETE from radiantraining.contacts WHERE idcontacts='" & txtContactID.Text & "'"
            COMMAND = New MySqlCommand(Query, MySqlConn)
            READER = COMMAND.ExecuteReader
            Select Case (MsgBox("You are about to delete a Contact!", MsgBoxStyle.YesNo))

                Case MsgBoxResult.No

                    Exit Sub

                Case MsgBoxResult.Yes

                    MsgBox("Record Deleted - " & txtName.Text)

            End Select

            'Refresh Data - Call function
            loadTable()
            MySqlConn.Close()

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        Finally

            'Blank all fields on load
            txtContactID.Text = ""
            txtName.Text = ""
            txtPosition.Text = ""
            txtMobile.Text = ""
            txtEmail.Text = ""

            MySqlConn.Dispose()

        End Try

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        MySqlConn = New MySqlConnection
        Dim CString As New RADIANSETTINGS
        MySqlConn.ConnectionString = CString.ConnString
        Dim READER As MySqlDataReader

        'Check to see if the local of foreign company form is open
        Dim Contact As String
        Dim Company As Int32
        If Application.OpenForms.OfType(Of Form).Contains(frmForeignCompany) Then

            Contact = "Foreign"
            Company = frmForeignCompany.txtCompanyID.Text

        Else

            Contact = "Local"
            Company = frmLocalCompany.txtCompanyID.Text

        End If

        'Try Catch Block
        Try

            If txtName.Text = "" Or txtMobile.Text = "" Then
                MsgBox("Please enter Contact Name and Phone number!")
            Else
                MySqlConn.Open()
                Dim Query As String
                Query = "INSERT INTO radiantraining.contacts
                (ContactName, Position, Mobile, Email, ContactType, Company)
                VALUES (
                '" & txtName.Text & "',
                '" & txtPosition.Text & "',
                '" & txtMobile.Text & "',
                '" & txtEmail.Text & "',
                '" & Contact & "',
                '" & Company & "'
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