<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UpdateAccount
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Status_combo = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.User_radio = New System.Windows.Forms.RadioButton()
        Me.Admin_radio = New System.Windows.Forms.RadioButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pass_lbl = New System.Windows.Forms.TextBox()
        Me.usn_lbl = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Status_combo)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.User_radio)
        Me.GroupBox1.Controls.Add(Me.Admin_radio)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.pass_lbl)
        Me.GroupBox1.Controls.Add(Me.usn_lbl)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(28, 30)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(326, 245)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "UPDATE ACCOUNT"
        '
        'Status_combo
        '
        Me.Status_combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Status_combo.FormattingEnabled = True
        Me.Status_combo.Items.AddRange(New Object() {"Enabled", "Disabled", "Banned"})
        Me.Status_combo.Location = New System.Drawing.Point(152, 187)
        Me.Status_combo.Name = "Status_combo"
        Me.Status_combo.Size = New System.Drawing.Size(121, 21)
        Me.Status_combo.TabIndex = 15
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(53, 190)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 13)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Account Status:"
        '
        'User_radio
        '
        Me.User_radio.AutoSize = True
        Me.User_radio.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.User_radio.Location = New System.Drawing.Point(226, 147)
        Me.User_radio.Name = "User_radio"
        Me.User_radio.Size = New System.Drawing.Size(46, 17)
        Me.User_radio.TabIndex = 13
        Me.User_radio.TabStop = True
        Me.User_radio.Text = "User"
        Me.User_radio.UseVisualStyleBackColor = True
        '
        'Admin_radio
        '
        Me.Admin_radio.AutoSize = True
        Me.Admin_radio.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Admin_radio.Location = New System.Drawing.Point(148, 147)
        Me.Admin_radio.Name = "Admin_radio"
        Me.Admin_radio.Size = New System.Drawing.Size(53, 17)
        Me.Admin_radio.TabIndex = 12
        Me.Admin_radio.TabStop = True
        Me.Admin_radio.Text = "Admin"
        Me.Admin_radio.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(53, 149)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Account Type:"
        '
        'pass_lbl
        '
        Me.pass_lbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pass_lbl.Location = New System.Drawing.Point(117, 92)
        Me.pass_lbl.Name = "pass_lbl"
        Me.pass_lbl.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.pass_lbl.Size = New System.Drawing.Size(156, 20)
        Me.pass_lbl.TabIndex = 10
        '
        'usn_lbl
        '
        Me.usn_lbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.usn_lbl.Location = New System.Drawing.Point(117, 45)
        Me.usn_lbl.Name = "usn_lbl"
        Me.usn_lbl.Size = New System.Drawing.Size(156, 20)
        Me.usn_lbl.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(53, 95)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Password:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(53, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Username:"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(145, 291)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(113, 33)
        Me.Button1.TabIndex = 16
        Me.Button1.Text = "UPDATE"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'UpdateAccount
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(398, 348)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "UpdateAccount"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "UpdateAccount"
        Me.TopMost = True
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Status_combo As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents User_radio As RadioButton
    Friend WithEvents Admin_radio As RadioButton
    Friend WithEvents Label3 As Label
    Friend WithEvents pass_lbl As TextBox
    Friend WithEvents usn_lbl As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Button1 As Button
End Class
