<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSettings
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtStudentPICPath = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCertPath = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtNationalID = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtDriversPermit = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtPassport = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnTestConnection = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtDBName = New System.Windows.Forms.TextBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtUserID = New System.Windows.Forms.TextBox()
        Me.txtServerName = New System.Windows.Forms.TextBox()
        Me.btnSaveSettings = New System.Windows.Forms.Button()
        Me.btnPICBrowse = New System.Windows.Forms.Button()
        Me.btnCertPath = New System.Windows.Forms.Button()
        Me.btnNationalID = New System.Windows.Forms.Button()
        Me.btnDriversPermit = New System.Windows.Forms.Button()
        Me.btnPassport = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Navy
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Location = New System.Drawing.Point(1, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(484, 64)
        Me.Panel1.TabIndex = 17
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(33, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(257, 30)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "RADIAN System Settings"
        '
        'txtStudentPICPath
        '
        Me.txtStudentPICPath.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Radian_Training_Database.My.MySettings.Default, "PicturePath", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.txtStudentPICPath.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStudentPICPath.Location = New System.Drawing.Point(120, 114)
        Me.txtStudentPICPath.Name = "txtStudentPICPath"
        Me.txtStudentPICPath.Size = New System.Drawing.Size(272, 22)
        Me.txtStudentPICPath.TabIndex = 11
        Me.txtStudentPICPath.Text = Global.Radian_Training_Database.My.MySettings.Default.PicturePath
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(49, 120)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Picture Path"
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.Tomato
        Me.btnCancel.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(394, 360)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 30)
        Me.btnCancel.TabIndex = 22
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(35, 151)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 13)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "Certificate Path"
        '
        'txtCertPath
        '
        Me.txtCertPath.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Radian_Training_Database.My.MySettings.Default, "CertPath", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.txtCertPath.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCertPath.Location = New System.Drawing.Point(120, 145)
        Me.txtCertPath.Name = "txtCertPath"
        Me.txtCertPath.Size = New System.Drawing.Size(272, 22)
        Me.txtCertPath.TabIndex = 24
        Me.txtCertPath.Text = Global.Radian_Training_Database.My.MySettings.Default.CertPath
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(54, 182)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 13)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "National ID"
        '
        'txtNationalID
        '
        Me.txtNationalID.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Radian_Training_Database.My.MySettings.Default, "NationalIDPath", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.txtNationalID.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNationalID.Location = New System.Drawing.Point(120, 176)
        Me.txtNationalID.Name = "txtNationalID"
        Me.txtNationalID.Size = New System.Drawing.Size(272, 22)
        Me.txtNationalID.TabIndex = 26
        Me.txtNationalID.Text = Global.Radian_Training_Database.My.MySettings.Default.NationalIDPath
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(42, 213)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 13)
        Me.Label5.TabIndex = 29
        Me.Label5.Text = "Drivers Permit"
        '
        'txtDriversPermit
        '
        Me.txtDriversPermit.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Radian_Training_Database.My.MySettings.Default, "DriversPermitPath", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.txtDriversPermit.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDriversPermit.Location = New System.Drawing.Point(120, 207)
        Me.txtDriversPermit.Name = "txtDriversPermit"
        Me.txtDriversPermit.Size = New System.Drawing.Size(272, 22)
        Me.txtDriversPermit.TabIndex = 28
        Me.txtDriversPermit.Text = Global.Radian_Training_Database.My.MySettings.Default.DriversPermitPath
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(66, 244)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 13)
        Me.Label6.TabIndex = 31
        Me.Label6.Text = "Passport"
        '
        'txtPassport
        '
        Me.txtPassport.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Radian_Training_Database.My.MySettings.Default, "PassportPath", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.txtPassport.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassport.Location = New System.Drawing.Point(120, 238)
        Me.txtPassport.Name = "txtPassport"
        Me.txtPassport.Size = New System.Drawing.Size(272, 22)
        Me.txtPassport.TabIndex = 30
        Me.txtPassport.Text = Global.Radian_Training_Database.My.MySettings.Default.PassportPath
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(24, 32)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(70, 13)
        Me.Label7.TabIndex = 33
        Me.Label7.Text = "Server Name"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnTestConnection)
        Me.GroupBox1.Controls.Add(Me.txtDBName)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.txtPassword)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtUserID)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtServerName)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 300)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(343, 152)
        Me.GroupBox1.TabIndex = 34
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Connection Details"
        '
        'btnTestConnection
        '
        Me.btnTestConnection.BackColor = System.Drawing.Color.Orange
        Me.btnTestConnection.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTestConnection.Location = New System.Drawing.Point(260, 105)
        Me.btnTestConnection.Name = "btnTestConnection"
        Me.btnTestConnection.Size = New System.Drawing.Size(75, 30)
        Me.btnTestConnection.TabIndex = 35
        Me.btnTestConnection.Text = "Test"
        Me.btnTestConnection.UseVisualStyleBackColor = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(40, 116)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(54, 13)
        Me.Label10.TabIndex = 39
        Me.Label10.Text = "DB Name"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(38, 88)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(56, 13)
        Me.Label9.TabIndex = 37
        Me.Label9.Text = "Password"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(50, 60)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(44, 13)
        Me.Label8.TabIndex = 35
        Me.Label8.Text = "User ID"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnPassport)
        Me.GroupBox2.Controls.Add(Me.btnDriversPermit)
        Me.GroupBox2.Controls.Add(Me.btnNationalID)
        Me.GroupBox2.Controls.Add(Me.btnCertPath)
        Me.GroupBox2.Controls.Add(Me.btnPICBrowse)
        Me.GroupBox2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(12, 81)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(457, 200)
        Me.GroupBox2.TabIndex = 40
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "File Paths"
        '
        'txtDBName
        '
        Me.txtDBName.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDBName.Location = New System.Drawing.Point(107, 111)
        Me.txtDBName.Name = "txtDBName"
        Me.txtDBName.Size = New System.Drawing.Size(126, 22)
        Me.txtDBName.TabIndex = 38
        Me.txtDBName.Text = "radiantraining"
        '
        'txtPassword
        '
        Me.txtPassword.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassword.Location = New System.Drawing.Point(107, 83)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(126, 22)
        Me.txtPassword.TabIndex = 36
        Me.txtPassword.Text = "root"
        '
        'txtUserID
        '
        Me.txtUserID.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUserID.Location = New System.Drawing.Point(107, 55)
        Me.txtUserID.Name = "txtUserID"
        Me.txtUserID.Size = New System.Drawing.Size(126, 22)
        Me.txtUserID.TabIndex = 34
        Me.txtUserID.Text = "root"
        '
        'txtServerName
        '
        Me.txtServerName.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtServerName.Location = New System.Drawing.Point(107, 27)
        Me.txtServerName.Name = "txtServerName"
        Me.txtServerName.Size = New System.Drawing.Size(126, 22)
        Me.txtServerName.TabIndex = 32
        Me.txtServerName.Text = "localhost"
        '
        'btnSaveSettings
        '
        Me.btnSaveSettings.BackColor = System.Drawing.Color.Tomato
        Me.btnSaveSettings.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveSettings.Location = New System.Drawing.Point(394, 403)
        Me.btnSaveSettings.Name = "btnSaveSettings"
        Me.btnSaveSettings.Size = New System.Drawing.Size(75, 30)
        Me.btnSaveSettings.TabIndex = 40
        Me.btnSaveSettings.Text = "Save"
        Me.btnSaveSettings.UseVisualStyleBackColor = False
        '
        'btnPICBrowse
        '
        Me.btnPICBrowse.BackColor = System.Drawing.Color.LightGray
        Me.btnPICBrowse.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPICBrowse.Location = New System.Drawing.Point(395, 30)
        Me.btnPICBrowse.Name = "btnPICBrowse"
        Me.btnPICBrowse.Size = New System.Drawing.Size(40, 25)
        Me.btnPICBrowse.TabIndex = 41
        Me.btnPICBrowse.Text = "..."
        Me.btnPICBrowse.UseVisualStyleBackColor = False
        '
        'btnCertPath
        '
        Me.btnCertPath.BackColor = System.Drawing.Color.LightGray
        Me.btnCertPath.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCertPath.Location = New System.Drawing.Point(395, 61)
        Me.btnCertPath.Name = "btnCertPath"
        Me.btnCertPath.Size = New System.Drawing.Size(40, 25)
        Me.btnCertPath.TabIndex = 42
        Me.btnCertPath.Text = "..."
        Me.btnCertPath.UseVisualStyleBackColor = False
        '
        'btnNationalID
        '
        Me.btnNationalID.BackColor = System.Drawing.Color.LightGray
        Me.btnNationalID.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNationalID.Location = New System.Drawing.Point(395, 92)
        Me.btnNationalID.Name = "btnNationalID"
        Me.btnNationalID.Size = New System.Drawing.Size(40, 25)
        Me.btnNationalID.TabIndex = 43
        Me.btnNationalID.Text = "..."
        Me.btnNationalID.UseVisualStyleBackColor = False
        '
        'btnDriversPermit
        '
        Me.btnDriversPermit.BackColor = System.Drawing.Color.LightGray
        Me.btnDriversPermit.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDriversPermit.Location = New System.Drawing.Point(395, 123)
        Me.btnDriversPermit.Name = "btnDriversPermit"
        Me.btnDriversPermit.Size = New System.Drawing.Size(40, 25)
        Me.btnDriversPermit.TabIndex = 44
        Me.btnDriversPermit.Text = "..."
        Me.btnDriversPermit.UseVisualStyleBackColor = False
        '
        'btnPassport
        '
        Me.btnPassport.BackColor = System.Drawing.Color.LightGray
        Me.btnPassport.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPassport.Location = New System.Drawing.Point(395, 154)
        Me.btnPassport.Name = "btnPassport"
        Me.btnPassport.Size = New System.Drawing.Size(40, 25)
        Me.btnPassport.TabIndex = 45
        Me.btnPassport.Text = "..."
        Me.btnPassport.UseVisualStyleBackColor = False
        '
        'frmSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(485, 465)
        Me.Controls.Add(Me.btnSaveSettings)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtPassport)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtDriversPermit)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtNationalID)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtCertPath)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.txtStudentPICPath)
        Me.Controls.Add(Me.GroupBox2)
        Me.Name = "frmSettings"
        Me.Text = "Settings"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents txtStudentPICPath As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnCancel As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents txtCertPath As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtNationalID As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtDriversPermit As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtPassport As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtServerName As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtDBName As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtUserID As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents btnTestConnection As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btnSaveSettings As Button
    Friend WithEvents btnPassport As Button
    Friend WithEvents btnDriversPermit As Button
    Friend WithEvents btnNationalID As Button
    Friend WithEvents btnCertPath As Button
    Friend WithEvents btnPICBrowse As Button
End Class
