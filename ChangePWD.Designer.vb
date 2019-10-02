<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChangePWD
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnChangePWD = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.txtOldPWD = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNewPWD = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtVerifyPWD = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(61, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(185, 30)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Change Password"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Navy
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Location = New System.Drawing.Point(2, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(322, 64)
        Me.Panel1.TabIndex = 11
        '
        'btnChangePWD
        '
        Me.btnChangePWD.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnChangePWD.Location = New System.Drawing.Point(117, 201)
        Me.btnChangePWD.Name = "btnChangePWD"
        Me.btnChangePWD.Size = New System.Drawing.Size(80, 30)
        Me.btnChangePWD.TabIndex = 14
        Me.btnChangePWD.Text = "&Ok"
        Me.btnChangePWD.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(216, 201)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(80, 30)
        Me.btnCancel.TabIndex = 15
        Me.btnCancel.Text = "&Exit"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'txtOldPWD
        '
        Me.txtOldPWD.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOldPWD.Location = New System.Drawing.Point(117, 86)
        Me.txtOldPWD.Name = "txtOldPWD"
        Me.txtOldPWD.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtOldPWD.Size = New System.Drawing.Size(179, 22)
        Me.txtOldPWD.TabIndex = 13
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(33, 91)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Old Password"
        '
        'txtNewPWD
        '
        Me.txtNewPWD.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNewPWD.Location = New System.Drawing.Point(117, 124)
        Me.txtNewPWD.Name = "txtNewPWD"
        Me.txtNewPWD.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtNewPWD.Size = New System.Drawing.Size(179, 22)
        Me.txtNewPWD.TabIndex = 17
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(29, 129)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 13)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "New Password"
        '
        'txtVerifyPWD
        '
        Me.txtVerifyPWD.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVerifyPWD.Location = New System.Drawing.Point(117, 164)
        Me.txtVerifyPWD.Name = "txtVerifyPWD"
        Me.txtVerifyPWD.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtVerifyPWD.Size = New System.Drawing.Size(179, 22)
        Me.txtVerifyPWD.TabIndex = 19
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(24, 169)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(87, 13)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Verify Password"
        '
        'frmChangePWD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(326, 247)
        Me.Controls.Add(Me.txtVerifyPWD)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtNewPWD)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnChangePWD)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.txtOldPWD)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmChangePWD"
        Me.Text = "Change Password"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label3 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnChangePWD As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents txtOldPWD As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtNewPWD As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtVerifyPWD As TextBox
    Friend WithEvents Label4 As Label
End Class
