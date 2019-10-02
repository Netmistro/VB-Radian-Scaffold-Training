Imports MySql.Data.MySqlClient
Public Class frmLocalCompany
    Dim MySqlConn As MySqlConnection
    Dim COMMAND As MySqlCommand
    Dim dbDataSet As New DataTable
    Private Sub FrmLocalCompany_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Centre Form
        Dim loadLocalCompany As New RADIANSETTINGS
        loadLocalCompany.CenterForm(Me)

        'Disable Save Button
        btnSaveCompany.Enabled = False

        'Set Focus on search box
        txtSearchCompany.Select()

        'Centre Form
        Dim loadStudentsForm As New RADIANSETTINGS
        loadStudentsForm.CenterForm(Me)

        MySqlConn = New MySqlConnection
        Dim CString As New RADIANSETTINGS
        MySqlConn.ConnectionString = CString.ConnString
        Dim SDA As New MySqlDataAdapter
        Dim bSource As New BindingSource

        'Blank all fields on load
        txtSearchCompany.Text = ""
        txtCompanyID.Text = ""
        txtCompanyName.Text = ""
        txtManagingDirector.Text = ""
        txtPhone1.Text = ""
        txtPhone2.Text = ""
        txtFax.Text = ""
        txtEmail.Text = ""
        txtWebsite.Text = ""
        txtAddress.Text = ""
        cmbCity.Text = ""
        txtMainContact.Text = ""

        Try
            MySqlConn.Open()
            Dim Query As String
            Query = "select idcompany as 'ID', CompanyName, ManagingDirector, Phone1, Phone2, Fax, CompanyAddress, City, 
                MainContact, email, website
                from radiantraining.localcompany"
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
            txtCompanyID.Text = row.Cells("ID").Value.ToString
            txtCompanyName.Text = row.Cells("CompanyName").Value.ToString
            txtManagingDirector.Text = row.Cells("ManagingDirector").Value.ToString
            txtPhone1.Text = row.Cells("Phone1").Value.ToString
            txtPhone2.Text = row.Cells("Phone2").Value.ToString
            txtFax.Text = row.Cells("Fax").Value.ToString
            txtEmail.Text = row.Cells("Email").Value.ToString
            txtWebsite.Text = row.Cells("Website").Value.ToString
            txtAddress.Text = row.Cells("CompanyAddress").Value.ToString
            cmbCity.Text = row.Cells("City").Value.ToString
            txtMainContact.Text = row.Cells("MainContact").Value.ToString

            'Try Catch Block City Name Dropdown list
            Try
                MySqlConn.Open()
                Dim Query As String
                Query = "select * from radiantraining.city"
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


        End If

    End Sub

    Private Sub TxtSearchCompany_TextChanged(sender As Object, e As EventArgs) Handles txtSearchCompany.TextChanged

        Dim DV As New DataView(dbDataSet)
        DV.RowFilter = String.Format("CompanyName Like '%{0}%' OR ManagingDirector Like '%{0}%' OR MainContact Like '%{0}%'", txtSearchCompany.Text)
        DataGridView1.DataSource = DV

    End Sub

    Private Sub BtnNewCompany_Click(sender As Object, e As EventArgs) Handles btnNewCompany.Click

        Select Case MsgBox("Would you like to create a new Company?", MsgBoxStyle.YesNo)

            Case MsgBoxResult.No

                Exit Sub

            Case MsgBoxResult.Yes

                'Enable save button
                btnSaveCompany.Enabled = True

                MySqlConn = New MySqlConnection
                Dim CString As New RADIANSETTINGS
                MySqlConn.ConnectionString = CString.ConnString
                Dim READER As MySqlDataReader

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
                cmbCity.Text = ""
                txtMainContact.Text = ""


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
            Query = "select idcompany as 'ID', CompanyName, ManagingDirector, Phone1, Phone2, Fax, CompanyAddress, City, 
                MainContact, email, website
                from radiantraining.localcompany"
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

    Private Sub BtnUpdateCompany_Click(sender As Object, e As EventArgs) Handles btnUpdateCompany.Click

        MySqlConn = New MySqlConnection
        Dim CString As New RADIANSETTINGS
        MySqlConn.ConnectionString = CString.ConnString
        Dim READER As MySqlDataReader

        'Try Catch Block
        Try

            MySqlConn.Open()
            Dim Query As String
            Query = "Update radiantraining.localcompany set
            CompanyName='" & txtCompanyName.Text & "',
            ManagingDirector='" & txtManagingDirector.Text & "',
            Phone1='" & txtPhone1.Text & "',
            Phone2='" & txtPhone2.Text & "',
            Fax='" & txtFax.Text & "',
            Email='" & txtEmail.Text & "',
            Website='" & txtWebsite.Text & "',
            CompanyAddress='" & txtAddress.Text & "',
            City='" & cmbCity.Text & "',
            MainContact='" & txtMainContact.Text & "'
            where idCompany ='" & txtCompanyID.Text & "'"

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

    Private Sub BtndeleteCompany_Click(sender As Object, e As EventArgs) Handles btndeleteCompany.Click

        MySqlConn = New MySqlConnection
        'Connection String
        Dim CString As New RADIANSETTINGS
        MySqlConn.ConnectionString = CString.ConnString
        Dim READER As MySqlDataReader

        'Try Catch Block
        Try

            MySqlConn.Open()
            Dim Query As String
            Query = "DELETE from radiantraining.localcompany where idCompany='" & txtCompanyID.Text & "'"
            COMMAND = New MySqlCommand(Query, MySqlConn)
            READER = COMMAND.ExecuteReader
            Select Case (MsgBox("You are about to delete a record", MsgBoxStyle.YesNo))

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
            txtSearchCompany.Text = ""
            txtCompanyID.Text = ""
            txtCompanyName.Text = ""
            txtManagingDirector.Text = ""
            txtPhone1.Text = ""
            txtPhone2.Text = ""
            txtFax.Text = ""
            txtEmail.Text = ""
            txtWebsite.Text = ""
            txtAddress.Text = ""
            cmbCity.Text = ""
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
                Query = "INSERT INTO radiantraining.localcompany
                (CompanyName, ManagingDirector, Phone1, Phone2, Fax, email, Website, CompanyAddress, City, MainContact )
                VALUES (
                '" & txtCompanyName.Text & "',
                '" & txtManagingDirector.Text & "',
                '" & txtPhone1.Text & "',
                '" & txtPhone2.Text & "',
                '" & txtFax.Text & "',
                '" & txtEmail.Text & "',
                '" & txtWebsite.Text & "',
                '" & txtAddress.Text & "',
                '" & cmbCity.Text & "',
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

    Private Sub btnContacts_Click(sender As Object, e As EventArgs) Handles btnContacts.Click

        If txtCompanyID.Text = "" Then

            MsgBox("Please choose a Company")

        Else

            frmContacts.Show()

        End If

    End Sub
End Class