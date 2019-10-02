Imports MySql.Data.MySqlClient

Public Class frmForeignCompany
    Dim MySqlConn As MySqlConnection
    Dim COMMAND As MySqlCommand
    Private Sub BtnNew_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub FrmForeignCompany_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Hide save button
        btnSaveCompany.Enabled = False

        'Centre Form
        Dim loadForeignCompany As New RADIANSETTINGS
        loadForeignCompany.CenterForm(Me)

        MySqlConn = New MySqlConnection
        Dim CString As New RADIANSETTINGS
        MySqlConn.ConnectionString = CString.ConnString
        Dim SDA As New MySqlDataAdapter
        Dim dbDataSet As New DataTable
        Dim bSource As New BindingSource

        'Blank all fields on load
        txtAddress.Text = ""
        txtCity.Text = ""
        txtCompanyID.Text = ""
        txtCompanyName.Text = ""
        txtEmail.Text = ""
        txtFax.Text = ""
        txtMainContact.Text = ""
        txtManagingDirector.Text = ""
        txtPhone1.Text = ""
        txtPhone2.Text = ""
        txtWebsite.Text = ""

        Try
            MySqlConn.Open()
            Dim Query As String
            Query = "select idfCompany as 'ID', CompanyName, ManDirector, Phone1, Phone2, Fax, Address, 
            City, MainContact, email , Website
            from radiantraining.foreigncompany"
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

    Private Sub DataGridView2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick

        MySqlConn = New MySqlConnection
        Dim CString As New RADIANSETTINGS
        MySqlConn.ConnectionString = CString.ConnString


        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow
            row = Me.DataGridView1.Rows(e.RowIndex)
            txtCompanyID.Text = row.Cells("ID").Value.ToString
            txtCompanyName.Text = row.Cells("CompanyName").Value.ToString
            txtManagingDirector.Text = row.Cells("ManDirector").Value.ToString
            txtPhone1.Text = row.Cells("Phone1").Value.ToString
            txtPhone2.Text = row.Cells("Phone2").Value.ToString
            txtFax.Text = row.Cells("Fax").Value.ToString
            txtEmail.Text = row.Cells("email").Value.ToString
            txtWebsite.Text = row.Cells("Website").Value.ToString
            txtAddress.Text = row.Cells("Address").Value.ToString
            txtCity.Text = row.Cells("City").Value.ToString
            txtMainContact.Text = row.Cells("MainContact").Value.ToString

            MySqlConn.Dispose()

        End If

    End Sub

    Private Sub btnNewCompany_Click(sender As Object, e As EventArgs) Handles btnNewCompany.Click

        Select Case MsgBox("Would you like to create a new Company?", MsgBoxStyle.YesNo)

            Case MsgBoxResult.No

                Exit Sub

            Case MsgBoxResult.Yes

                'Enable save button
                btnSaveCompany.Enabled = True

                'Reload table data
                loadTable()

                ' Blank all text boxes
                txtCompanyID.ReadOnly = True
                txtCompanyName.Text = ""
                txtManagingDirector.Text = ""
                txtPhone1.Text = ""
                txtPhone2.Text = ""
                txtFax.Text = ""
                txtEmail.Text = ""
                txtWebsite.Text = ""
                txtAddress.Text = ""
                txtCity.Text = ""
                txtMainContact.Text = ""

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
            Query = "select idfCompany as 'ID', CompanyName, ManDirector, Phone1, Phone2, Fax, Address, City, 
                MainContact, email, Website
                from radiantraining.foreigncompany"
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

    Private Sub btnUpdateCompany_Click(sender As Object, e As EventArgs) Handles btnUpdateCompany.Click

        MySqlConn = New MySqlConnection
        Dim CString As New RADIANSETTINGS
        MySqlConn.ConnectionString = CString.ConnString
        Dim READER As MySqlDataReader

        'Try Catch Block
        Try

            MySqlConn.Open()
            Dim Query As String
            Query = "Update radiantraining.foreigncompany set
            CompanyName='" & txtCompanyName.Text & "',
            ManDirector='" & txtManagingDirector.Text & "',
            Phone1='" & txtPhone1.Text & "',
            Phone2='" & txtPhone2.Text & "',
            Fax='" & txtFax.Text & "',
            Email='" & txtEmail.Text & "',
            Website='" & txtWebsite.Text & "',
            Address='" & txtAddress.Text & "',
            City='" & txtCity.Text & "',
            MainContact='" & txtMainContact.Text & "'
            where idfCompany ='" & txtCompanyID.Text & "'"

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

    Private Sub btndeleteCompany_Click(sender As Object, e As EventArgs) Handles btndeleteCompany.Click

        MySqlConn = New MySqlConnection
        'Connection String
        Dim CString As New RADIANSETTINGS
        MySqlConn.ConnectionString = CString.ConnString
        Dim READER As MySqlDataReader

        'Try Catch Block
        Try

            MySqlConn.Open()
            Dim Query As String
            Query = "DELETE from radiantraining.foreigncompany where idfCompany='" & txtCompanyID.Text & "'"
            COMMAND = New MySqlCommand(Query, MySqlConn)
            READER = COMMAND.ExecuteReader
            Select Case (MsgBox("You are about to delete a Company", MsgBoxStyle.YesNo))

                Case MsgBoxResult.No

                    Exit Sub

                Case MsgBoxResult.Yes

                    MsgBox("Record Deleted - " & txtCompanyName.Text)

            End Select

            'Refresh Data - Call function
            loadTable()
            MySqlConn.Close()

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        Finally

            'Blank all fields on load
            txtCompanyID.Text = ""
            txtCompanyName.Text = ""
            txtManagingDirector.Text = ""
            txtPhone1.Text = ""
            txtPhone2.Text = ""
            txtFax.Text = ""
            txtEmail.Text = ""
            txtWebsite.Text = ""
            txtAddress.Text = ""
            txtCity.Text = ""
            txtMainContact.Text = ""

            MySqlConn.Dispose()

        End Try

    End Sub

    Private Sub btnSaveCompany_Click(sender As Object, e As EventArgs) Handles btnSaveCompany.Click

        MySqlConn = New MySqlConnection
        Dim CString As New RADIANSETTINGS
        MySqlConn.ConnectionString = CString.ConnString
        Dim READER As MySqlDataReader

        'Try Catch Block
        Try

            If txtCompanyName.Text = "" Or txtPhone1.Text = "" Then
                MsgBox("Please enter Company Name and a Phone number!")
            Else
                MySqlConn.Open()
                Dim Query As String
                Query = "INSERT INTO radiantraining.foreigncompany
                (CompanyName, ManDirector, Phone1, Phone2, Fax, email, Website, Address, City, MainContact )
                VALUES (
                '" & txtCompanyName.Text & "',
                '" & txtManagingDirector.Text & "',
                '" & txtPhone1.Text & "',
                '" & txtPhone2.Text & "',
                '" & txtFax.Text & "',
                '" & txtEmail.Text & "',
                '" & txtWebsite.Text & "',
                '" & txtAddress.Text & "',
                '" & txtCity.Text & "',
                '" & txtMainContact.Text & "'
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

    Private Sub btnContacts_Click(sender As Object, e As EventArgs)

        frmContacts.Show()

    End Sub

    Private Sub btnContacts_Click_1(sender As Object, e As EventArgs) Handles btnContacts.Click

        If txtCompanyID.Text = "" Then

            MsgBox("Please choose a Company")

        Else

            frmContacts.Show()

        End If

    End Sub
End Class