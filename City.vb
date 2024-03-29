﻿Imports MySql.Data.MySqlClient

Public Class frmCity
    Dim MySqlConn As MySqlConnection
    Dim COMMAND As MySqlCommand
    Private Sub FrmCity_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Disable save button
        btnSave.Enabled = False

        'Centre Form
        Dim cityForm As New RADIANSETTINGS
        cityForm.CenterForm(Me)

        'Disable Controls
        txtCityID.Enabled = False

        MySqlConn = New MySqlConnection
        Dim CString As New RADIANSETTINGS
        MySqlConn.ConnectionString = CString.ConnString
        Dim SDA As New MySqlDataAdapter
        Dim dbDataSet As New DataTable
        Dim bSource As New BindingSource

        'Blank all fields on load
        txtCityID.Text = ""
        txtCityName.Text = ""

        Try
            MySqlConn.Open()
            Dim Query As String
            Query = "SELECT idCity as 'ID', CityName from radiantraining.city"
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
            txtCityID.Text = row.Cells("ID").Value.ToString
            txtCityName.Text = row.Cells("CityName").Value.ToString

            MySqlConn.Dispose()

        End If

    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click

        ' Disable update button
        btnUpdate.Enabled = False

        Select Case MsgBox("Would you like to create a new City Name?", MsgBoxStyle.YesNo)

            Case MsgBoxResult.No

                Exit Sub

            Case MsgBoxResult.Yes

                'Enable save button
                btnSave.Enabled = True

                'Reload table data
                loadTable()

                ' Blank all text boxes
                txtCityID.ReadOnly = True
                txtCityName.Text = ""

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
            Query = "SELECT idCity as 'ID', CityName from radiantraining.city"
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
            Query = "UPDATE radiantraining.city SET
            CityName='" & txtCityName.Text & "'
            WHERE idCity ='" & txtCityID.Text & "'"

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
            Query = "DELETE from radiantraining.city WHERE idCity='" & txtCityID.Text & "'"
            COMMAND = New MySqlCommand(Query, MySqlConn)
            READER = COMMAND.ExecuteReader
            Select Case (MsgBox("You are about to delete a City!", MsgBoxStyle.YesNo))

                Case MsgBoxResult.No

                    Exit Sub

                Case MsgBoxResult.Yes

                    MsgBox("Record Deleted - " & txtCityName.Text)

            End Select

            'Refresh Data - Call function
            loadTable()
            MySqlConn.Close()

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        Finally

            'Blank all fields on load
            txtCityID.Text = ""
            txtCityName.Text = ""

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

            If txtCityName.Text = "" Then
                MsgBox("Please enter a valid City Name!")
            Else
                MySqlConn.Open()
                Dim Query As String
                Query = "INSERT INTO radiantraining.city
                (CityName)
                VALUES ('" & txtCityName.Text & "')"
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