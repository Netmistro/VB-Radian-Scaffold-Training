Imports System.Data
Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class RADIANSETTINGS

    'Method for Centering Forms
    Public Sub CenterForm(ByVal frm As Form, Optional ByVal parent As Form = Nothing)
        'Note: call this from frm's Load event!
        Dim r As Rectangle

        If parent IsNot Nothing Then
            r = parent.RectangleToScreen(parent.ClientRectangle)
        Else
            r = Screen.FromPoint(frm.Location).WorkingArea
        End If

        Dim x = r.Left + (r.Width - frm.Width) \ 2
        Dim y = r.Top + (r.Height - frm.Height) \ 2
        frm.Location = New Point(x, y)

    End Sub

    Public Sub contactType()

        'Check to see if the local of foreign company form is open
        Dim ContactType As String

        If Application.OpenForms.OfType(Of Form).Contains(frmForeignCompany) Then

            ContactType = "Foreign"

        Else
            ContactType = "Local"

        End If

    End Sub

    Public Function ConnString() As String

        Dim connStr As String = "server='" & My.Settings.ServerName & "';
        userid='" & My.Settings.UserID & "';
        password='" & My.Settings.Password & "';
        database='" & My.Settings.DBName & "'"

        Return connStr

    End Function

End Class