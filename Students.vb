Imports MySql.Data.MySqlClient
Public Class frmStudents
    Dim MySqlConn As MySqlConnection
    Dim COMMAND As MySqlCommand
    Private Sub FrmStudents_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        MySqlConn = New MySqlConnection
        MySqlConn.ConnectionString = "server=localhost;userid=root;password=root;database=radiantraining"
        Dim SDA As New MySqlDataAdapter
        Dim dbDataSet As New DataTable
        Dim bSource As New BindingSource

        'Blank all fields on load
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
        txtWebsiteURL.Text = ""
        txtNotes.Text = ""
        txtNationalID.Text = ""
        txtPassportNo.Text = ""
        txtDriversPermitNo.Text = ""

        Try
            MySqlConn.Open()
            Dim Query As String
            Query = "select studentid as 'ID', FirstName as 'First Name', MiddleName as 'Middle Name', LastName as 'Last Name',
                Company, Address, City, Mobile, Home, Other, NationalIDNo as 'ID Number', DriversPermitNo as 'DP Number',NationalID,
                DriversPermit, Passport, Picture, Email, Notes
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
            txtFirstName.Text = row.Cells("First Name").Value.ToString
            txtMiddleName.Text = row.Cells("Middle Name").Value.ToString
            txtLastName.Text = row.Cells("Last Name").Value.ToString


        End If

    End Sub
End Class