<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Dashboard
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
        Me.components = New System.ComponentModel.Container()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series3 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series4 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.logout_btn = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.EmployeesBindingSource4 = New System.Windows.Forms.BindingSource(Me.components)
        Me.EAMDataSet3 = New Employee_Attendance_Monitoring.EAMDataSet3()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.turnover_lbl = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.attrition_lbl = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.present_lbl = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Generate = New System.Windows.Forms.Button()
        Me.EmployeesBindingSource3 = New System.Windows.Forms.BindingSource(Me.components)
        Me.EAMDataSet1BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EAMDataSet1 = New Employee_Attendance_Monitoring.EAMDataSet1()
        Me.EmployeesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EAMDataSet = New Employee_Attendance_Monitoring.EAMDataSet()
        Me.EmployeesTableAdapter = New Employee_Attendance_Monitoring.EAMDataSetTableAdapters.EmployeesTableAdapter()
        Me.EmployeesBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.EmployeesTableAdapter1 = New Employee_Attendance_Monitoring.EAMDataSet1TableAdapters.EmployeesTableAdapter()
        Me.EAMDataSet2 = New Employee_Attendance_Monitoring.EAMDataSet2()
        Me.EmployeesBindingSource2 = New System.Windows.Forms.BindingSource(Me.components)
        Me.EmployeesTableAdapter2 = New Employee_Attendance_Monitoring.EAMDataSet2TableAdapters.EmployeesTableAdapter()
        Me.EmployeesTableAdapter3 = New Employee_Attendance_Monitoring.EAMDataSet3TableAdapters.EmployeesTableAdapter()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmployeesBindingSource4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EAMDataSet3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.EmployeesBindingSource3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EAMDataSet1BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EAMDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmployeesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EAMDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmployeesBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EAMDataSet2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmployeesBindingSource2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel8.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.logout_btn)
        Me.Panel1.Location = New System.Drawing.Point(0, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(930, 38)
        Me.Panel1.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(8, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(117, 19)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "COMPANY NAME"
        '
        'logout_btn
        '
        Me.logout_btn.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.logout_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.logout_btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.logout_btn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.logout_btn.Image = Global.Employee_Attendance_Monitoring.My.Resources.Resources.Logout_Icon
        Me.logout_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.logout_btn.Location = New System.Drawing.Point(817, 3)
        Me.logout_btn.Name = "logout_btn"
        Me.logout_btn.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.logout_btn.Size = New System.Drawing.Size(96, 32)
        Me.logout_btn.TabIndex = 0
        Me.logout_btn.Text = "Logout"
        Me.logout_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.logout_btn.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.Control
        Me.Panel2.Controls.Add(Me.Button4)
        Me.Panel2.Controls.Add(Me.Button3)
        Me.Panel2.Controls.Add(Me.Button2)
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Controls.Add(Me.LinkLabel1)
        Me.Panel2.Controls.Add(Me.PictureBox1)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(149, 566)
        Me.Panel2.TabIndex = 1
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Transparent
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(0, 252)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(149, 48)
        Me.Button3.TabIndex = 5
        Me.Button3.Text = "ADMIN"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Transparent
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(0, 160)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(149, 48)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "EMPLOYEE"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(0, 113)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(149, 48)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "DASHBOARD"
        Me.Button1.UseVisualStyleBackColor = False
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
        'Panel3
        '
        Me.Panel3.Location = New System.Drawing.Point(149, 69)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(653, 381)
        Me.Panel3.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Consolas", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(168, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(200, 22)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "EMPLOYEE ATTENDANCE"
        '
        'EmployeesBindingSource4
        '
        Me.EmployeesBindingSource4.DataMember = "Employees"
        Me.EmployeesBindingSource4.DataSource = Me.EAMDataSet3
        '
        'EAMDataSet3
        '
        Me.EAMDataSet3.DataSetName = "EAMDataSet3"
        Me.EAMDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.Panel4.Controls.Add(Me.Panel7)
        Me.Panel4.Controls.Add(Me.Panel6)
        Me.Panel4.Controls.Add(Me.Panel5)
        Me.Panel4.Controls.Add(Me.DateTimePicker1)
        Me.Panel4.Controls.Add(Me.Generate)
        Me.Panel4.Location = New System.Drawing.Point(258, 78)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(575, 112)
        Me.Panel4.TabIndex = 5
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(1, Byte), Integer), CType(CType(1, Byte), Integer))
        Me.Panel7.Controls.Add(Me.turnover_lbl)
        Me.Panel7.Controls.Add(Me.Label6)
        Me.Panel7.Location = New System.Drawing.Point(301, 17)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(114, 83)
        Me.Panel7.TabIndex = 2
        '
        'turnover_lbl
        '
        Me.turnover_lbl.AutoSize = True
        Me.turnover_lbl.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold)
        Me.turnover_lbl.ForeColor = System.Drawing.Color.White
        Me.turnover_lbl.Location = New System.Drawing.Point(48, 44)
        Me.turnover_lbl.Name = "turnover_lbl"
        Me.turnover_lbl.Size = New System.Drawing.Size(21, 22)
        Me.turnover_lbl.TabIndex = 3
        Me.turnover_lbl.Text = "0"
        Me.turnover_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(18, 14)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 16)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "TURN OVER"
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.Panel6.Controls.Add(Me.attrition_lbl)
        Me.Panel6.Controls.Add(Me.Label4)
        Me.Panel6.Location = New System.Drawing.Point(172, 17)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(112, 83)
        Me.Panel6.TabIndex = 1
        '
        'attrition_lbl
        '
        Me.attrition_lbl.AutoSize = True
        Me.attrition_lbl.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold)
        Me.attrition_lbl.ForeColor = System.Drawing.Color.White
        Me.attrition_lbl.Location = New System.Drawing.Point(41, 44)
        Me.attrition_lbl.Name = "attrition_lbl"
        Me.attrition_lbl.Size = New System.Drawing.Size(27, 22)
        Me.attrition_lbl.TabIndex = 1
        Me.attrition_lbl.Text = "%"
        Me.attrition_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(23, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 16)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "ATTRITION"
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(6, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel5.Controls.Add(Me.present_lbl)
        Me.Panel5.Controls.Add(Me.Label2)
        Me.Panel5.Location = New System.Drawing.Point(39, 17)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(112, 83)
        Me.Panel5.TabIndex = 0
        '
        'present_lbl
        '
        Me.present_lbl.AutoSize = True
        Me.present_lbl.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold)
        Me.present_lbl.ForeColor = System.Drawing.Color.White
        Me.present_lbl.Location = New System.Drawing.Point(43, 44)
        Me.present_lbl.Name = "present_lbl"
        Me.present_lbl.Size = New System.Drawing.Size(21, 22)
        Me.present_lbl.TabIndex = 2
        Me.present_lbl.Text = "0"
        Me.present_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(22, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "PRESENT"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CustomFormat = "MM/dd/yyyy"
        Me.DateTimePicker1.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(431, 21)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(106, 20)
        Me.DateTimePicker1.TabIndex = 4
        Me.DateTimePicker1.Value = New Date(2022, 5, 4, 0, 0, 0, 0)
        '
        'Generate
        '
        Me.Generate.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Generate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Generate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Generate.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Generate.ForeColor = System.Drawing.Color.White
        Me.Generate.Location = New System.Drawing.Point(441, 56)
        Me.Generate.Name = "Generate"
        Me.Generate.Size = New System.Drawing.Size(91, 25)
        Me.Generate.TabIndex = 3
        Me.Generate.Text = "GENERATE"
        Me.Generate.UseVisualStyleBackColor = False
        '
        'EmployeesBindingSource3
        '
        Me.EmployeesBindingSource3.DataMember = "Employees"
        Me.EmployeesBindingSource3.DataSource = Me.EAMDataSet1BindingSource
        '
        'EAMDataSet1BindingSource
        '
        Me.EAMDataSet1BindingSource.DataSource = Me.EAMDataSet1
        Me.EAMDataSet1BindingSource.Position = 0
        '
        'EAMDataSet1
        '
        Me.EAMDataSet1.DataSetName = "EAMDataSet1"
        Me.EAMDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'EmployeesBindingSource
        '
        Me.EmployeesBindingSource.DataMember = "Employees"
        Me.EmployeesBindingSource.DataSource = Me.EAMDataSet
        '
        'EAMDataSet
        '
        Me.EAMDataSet.DataSetName = "EAMDataSet"
        Me.EAMDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'EmployeesTableAdapter
        '
        Me.EmployeesTableAdapter.ClearBeforeFill = True
        '
        'EmployeesBindingSource1
        '
        Me.EmployeesBindingSource1.DataMember = "Employees"
        Me.EmployeesBindingSource1.DataSource = Me.EAMDataSet1
        '
        'EmployeesTableAdapter1
        '
        Me.EmployeesTableAdapter1.ClearBeforeFill = True
        '
        'EAMDataSet2
        '
        Me.EAMDataSet2.DataSetName = "EAMDataSet2"
        Me.EAMDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'EmployeesBindingSource2
        '
        Me.EmployeesBindingSource2.DataMember = "Employees"
        Me.EmployeesBindingSource2.DataSource = Me.EAMDataSet2
        '
        'EmployeesTableAdapter2
        '
        Me.EmployeesTableAdapter2.ClearBeforeFill = True
        '
        'EmployeesTableAdapter3
        '
        Me.EmployeesTableAdapter3.ClearBeforeFill = True
        '
        'Chart1
        '
        ChartArea2.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea2)
        Legend2.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend2)
        Me.Chart1.Location = New System.Drawing.Point(53, 51)
        Me.Chart1.Name = "Chart1"
        Me.Chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None
        Me.Chart1.PaletteCustomColors = New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(119, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))}
        Series3.ChartArea = "ChartArea1"
        Series3.Legend = "Legend1"
        Series3.Name = "Present"
        Series3.YValuesPerPoint = 4
        Series4.ChartArea = "ChartArea1"
        Series4.Legend = "Legend1"
        Series4.Name = "Absent"
        Me.Chart1.Series.Add(Series3)
        Me.Chart1.Series.Add(Series4)
        Me.Chart1.Size = New System.Drawing.Size(631, 249)
        Me.Chart1.TabIndex = 6
        Me.Chart1.Text = "Chart1"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(50, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(135, 16)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Employee Attendance"
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.Lavender
        Me.Panel8.Controls.Add(Me.Chart1)
        Me.Panel8.Controls.Add(Me.Label5)
        Me.Panel8.Location = New System.Drawing.Point(173, 204)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(726, 336)
        Me.Panel8.TabIndex = 8
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.Transparent
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Location = New System.Drawing.Point(0, 206)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(149, 48)
        Me.Button4.TabIndex = 6
        Me.Button4.Text = "RECORDS"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Dashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.GhostWhite
        Me.ClientSize = New System.Drawing.Size(925, 566)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel8)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "Dashboard"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Dashboard"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmployeesBindingSource4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EAMDataSet3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        CType(Me.EmployeesBindingSource3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EAMDataSet1BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EAMDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmployeesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EAMDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmployeesBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EAMDataSet2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmployeesBindingSource2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents Label1 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents logout_btn As Button
    Friend WithEvents Generate As Button
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents Button2 As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents EAMDataSet As EAMDataSet
    Friend WithEvents EmployeesBindingSource As BindingSource
    Friend WithEvents EmployeesTableAdapter As EAMDataSetTableAdapters.EmployeesTableAdapter
    Friend WithEvents EAMDataSet1 As EAMDataSet1
    Friend WithEvents EmployeesBindingSource1 As BindingSource
    Friend WithEvents EmployeesTableAdapter1 As EAMDataSet1TableAdapters.EmployeesTableAdapter
    Friend WithEvents EAMDataSet1BindingSource As BindingSource
    Friend WithEvents EAMDataSet2 As EAMDataSet2
    Friend WithEvents EmployeesBindingSource2 As BindingSource
    Friend WithEvents EmployeesTableAdapter2 As EAMDataSet2TableAdapters.EmployeesTableAdapter
    Friend WithEvents EmployeesBindingSource3 As BindingSource
    Friend WithEvents EAMDataSet3 As EAMDataSet3
    Friend WithEvents EmployeesBindingSource4 As BindingSource
    Friend WithEvents EmployeesTableAdapter3 As EAMDataSet3TableAdapters.EmployeesTableAdapter
    Friend WithEvents Button3 As Button
    Friend WithEvents Chart1 As DataVisualization.Charting.Chart
    Friend WithEvents attrition_lbl As Label
    Friend WithEvents turnover_lbl As Label
    Friend WithEvents present_lbl As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Button4 As Button
End Class
