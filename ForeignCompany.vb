Imports MySql.Data.MySqlClient

Public Class frmForeignCompany
    Dim MySqlConn As MySqlConnection
    Dim COMMAND As MySqlCommand
    Private Sub BtnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click

    End Sub

    Private Sub FrmForeignCompany_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        MySqlConn = New MySqlConnection
        MySqlConn.ConnectionString = "server=localhost;userid=root;password=root;database=radiantraining"
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
            Query = "select idfCompany as 'ID', CompanyName as 'Company', ManDirector as 'Director/CEO', Phone1 as 'Phone1', Phone2 as 'Phone2', Fax as 'Fax', Address as 'Address', City as 'City', MainContact as 'Main Contact', email as 'e-mail', Website as 'Website'  from radiantraining.foreigncompany"
            COMMAND = New MySqlCommand(Query, MySqlConn)

            SDA.SelectCommand = COMMAND
            SDA.Fill(dbDataSet)
            bSource.DataSource = dbDataSet
            DataGridView2.DataSource = bSource
            SDA.Update(dbDataSet)
            DataGridView2.ColumnHeadersDefaultCellStyle.Font = New Font(DataGridView2.Font, FontStyle.Bold)
            MySqlConn.Close()

        Catch ex As Exception

            MessageBox.Show(ex.Message)
        Finally

            MySqlConn.Dispose()

        End Try


    End Sub
End Class