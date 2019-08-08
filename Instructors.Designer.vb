<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInstructors
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtInstructorID = New System.Windows.Forms.TextBox()
        Me.txtInstructorName = New System.Windows.Forms.TextBox()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnPrevious = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.cmbCompanyName = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(41, 70)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Instructor ID"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(14, 118)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(116, 18)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Instructor Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(55, 168)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 18)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Company"
        '
        'txtInstructorID
        '
        Me.txtInstructorID.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInstructorID.Location = New System.Drawing.Point(142, 67)
        Me.txtInstructorID.Multiline = True
        Me.txtInstructorID.Name = "txtInstructorID"
        Me.txtInstructorID.Size = New System.Drawing.Size(60, 25)
        Me.txtInstructorID.TabIndex = 3
        '
        'txtInstructorName
        '
        Me.txtInstructorName.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInstructorName.Location = New System.Drawing.Point(142, 115)
        Me.txtInstructorName.Multiline = True
        Me.txtInstructorName.Name = "txtInstructorName"
        Me.txtInstructorName.Size = New System.Drawing.Size(278, 25)
        Me.txtInstructorName.TabIndex = 4
        '
        'btnNext
        '
        Me.btnNext.BackColor = System.Drawing.Color.Coral
        Me.btnNext.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNext.Location = New System.Drawing.Point(335, 222)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(85, 30)
        Me.btnNext.TabIndex = 6
        Me.btnNext.Text = "Next"
        Me.btnNext.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(130, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(208, 22)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Approved Instructors"
        '
        'btnPrevious
        '
        Me.btnPrevious.BackColor = System.Drawing.Color.Coral
        Me.btnPrevious.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrevious.Location = New System.Drawing.Point(234, 222)
        Me.btnPrevious.Name = "btnPrevious"
        Me.btnPrevious.Size = New System.Drawing.Size(85, 30)
        Me.btnPrevious.TabIndex = 8
        Me.btnPrevious.Text = "Previous"
        Me.btnPrevious.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.Coral
        Me.btnSave.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(133, 222)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(85, 30)
        Me.btnSave.TabIndex = 9
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'btnNew
        '
        Me.btnNew.BackColor = System.Drawing.Color.Coral
        Me.btnNew.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNew.Location = New System.Drawing.Point(32, 222)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(85, 30)
        Me.btnNew.TabIndex = 10
        Me.btnNew.Text = "New"
        Me.btnNew.UseVisualStyleBackColor = False
        '
        'cmbCompanyName
        '
        Me.cmbCompanyName.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCompanyName.FormattingEnabled = True
        Me.cmbCompanyName.Location = New System.Drawing.Point(142, 160)
        Me.cmbCompanyName.Name = "cmbCompanyName"
        Me.cmbCompanyName.Size = New System.Drawing.Size(278, 26)
        Me.cmbCompanyName.TabIndex = 13
        '
        'frmInstructors
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(455, 279)
        Me.Controls.Add(Me.cmbCompanyName)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnPrevious)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.txtInstructorName)
        Me.Controls.Add(Me.txtInstructorID)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmInstructors"
        Me.Text = "Training Instructors"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtInstructorID As TextBox
    Friend WithEvents txtInstructorName As TextBox
    Friend WithEvents btnNext As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents btnPrevious As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents btnNew As Button
    Friend WithEvents cmbCompanyName As ComboBox
End Class
