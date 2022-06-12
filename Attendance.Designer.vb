<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Attendance
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
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.records_btn = New System.Windows.Forms.Button()
        Me.admin_btn = New System.Windows.Forms.Button()
        Me.emp_btn = New System.Windows.Forms.Button()
        Me.dash_btn = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle15.Padding = New System.Windows.Forms.Padding(1)
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle15
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Arial", 9.75!)
        DataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle16
        Me.DataGridView1.Location = New System.Drawing.Point(196, 95)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(789, 310)
        Me.DataGridView1.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(196, 428)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(159, 47)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Mark as Present"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CustomFormat = ""
        Me.DateTimePicker1.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right
        Me.DateTimePicker1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker1.Location = New System.Drawing.Point(706, 65)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(279, 24)
        Me.DateTimePicker1.TabIndex = 2
        '
        'Button2
        '
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(752, 428)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(98, 47)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Time-In"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Location = New System.Drawing.Point(887, 428)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(98, 47)
        Me.Button3.TabIndex = 4
        Me.Button3.Text = "Time-Out"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.CausesValidation = False
        Me.DateTimePicker2.CustomFormat = "H:mm tt"
        Me.DateTimePicker2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker2.Location = New System.Drawing.Point(517, 65)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.ShowUpDown = True
        Me.DateTimePicker2.Size = New System.Drawing.Size(94, 24)
        Me.DateTimePicker2.TabIndex = 5
        '
        'Button4
        '
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Location = New System.Drawing.Point(617, 66)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(83, 23)
        Me.Button4.TabIndex = 6
        Me.Button4.Text = "Time Now"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Location = New System.Drawing.Point(-41, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1050, 38)
        Me.Panel1.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(53, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(117, 19)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "COMPANY NAME"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.LinkColor = System.Drawing.SystemColors.MenuHighlight
        Me.LinkLabel1.Location = New System.Drawing.Point(65, 65)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(77, 15)
        Me.LinkLabel1.TabIndex = 2
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Employee 1"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Employee_Attendance_Monitoring.My.Resources.Resources.download
        Me.PictureBox1.Location = New System.Drawing.Point(12, 53)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(40, 41)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.Control
        Me.Panel2.Controls.Add(Me.records_btn)
        Me.Panel2.Controls.Add(Me.admin_btn)
        Me.Panel2.Controls.Add(Me.emp_btn)
        Me.Panel2.Controls.Add(Me.dash_btn)
        Me.Panel2.Controls.Add(Me.LinkLabel1)
        Me.Panel2.Controls.Add(Me.PictureBox1)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(149, 506)
        Me.Panel2.TabIndex = 8
        '
        'records_btn
        '
        Me.records_btn.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.records_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.records_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.records_btn.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.records_btn.ForeColor = System.Drawing.Color.White
        Me.records_btn.Location = New System.Drawing.Point(0, 207)
        Me.records_btn.Name = "records_btn"
        Me.records_btn.Size = New System.Drawing.Size(149, 48)
        Me.records_btn.TabIndex = 11
        Me.records_btn.Text = "RECORDS"
        Me.records_btn.UseVisualStyleBackColor = False
        '
        'admin_btn
        '
        Me.admin_btn.BackColor = System.Drawing.Color.Transparent
        Me.admin_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.admin_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.admin_btn.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.admin_btn.Location = New System.Drawing.Point(0, 253)
        Me.admin_btn.Name = "admin_btn"
        Me.admin_btn.Size = New System.Drawing.Size(149, 48)
        Me.admin_btn.TabIndex = 10
        Me.admin_btn.Text = "ADMIN"
        Me.admin_btn.UseVisualStyleBackColor = False
        '
        'emp_btn
        '
        Me.emp_btn.BackColor = System.Drawing.Color.Transparent
        Me.emp_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.emp_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.emp_btn.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.emp_btn.ForeColor = System.Drawing.Color.Black
        Me.emp_btn.Location = New System.Drawing.Point(0, 160)
        Me.emp_btn.Name = "emp_btn"
        Me.emp_btn.Size = New System.Drawing.Size(149, 48)
        Me.emp_btn.TabIndex = 4
        Me.emp_btn.Text = "EMPLOYEE"
        Me.emp_btn.UseVisualStyleBackColor = False
        '
        'dash_btn
        '
        Me.dash_btn.BackColor = System.Drawing.Color.Transparent
        Me.dash_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dash_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.dash_btn.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dash_btn.ForeColor = System.Drawing.Color.Black
        Me.dash_btn.Location = New System.Drawing.Point(0, 113)
        Me.dash_btn.Name = "dash_btn"
        Me.dash_btn.Size = New System.Drawing.Size(149, 48)
        Me.dash_btn.TabIndex = 3
        Me.dash_btn.Text = "DASHBOARD"
        Me.dash_btn.UseVisualStyleBackColor = False
        '
        'Panel3
        '
        Me.Panel3.Location = New System.Drawing.Point(149, 69)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(653, 381)
        Me.Panel3.TabIndex = 0
        '
        'Attendance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.GhostWhite
        Me.ClientSize = New System.Drawing.Size(1005, 506)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.DateTimePicker2)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "Attendance"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Attendance"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Button1 As Button
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents DateTimePicker2 As DateTimePicker
    Friend WithEvents Button4 As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents admin_btn As Button
    Friend WithEvents emp_btn As Button
    Friend WithEvents dash_btn As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents records_btn As Button
End Class
