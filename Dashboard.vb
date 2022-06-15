Imports System.Data.OleDb
Public Class Dashboard
    Dim conn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=EAM.mdb")
    Dim cookie = New LoginSession()
    Dim EmployeeCount

    '<a href="https//www.freepik.com/vectors/sample-logo">Sample logo vector created by rawpixel.com - www.freepik.com</a>

    Private Sub Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'EAMDataSet3.Employees' table. You can move, or remove it, as needed.
        'Me.EmployeesTableAdapter3.Fill(Me.EAMDataSet3.Employees)
        DateTimePicker1.Value = Date.Today

        Button1.FlatAppearance.BorderSize = 0
        Button2.FlatAppearance.BorderSize = 0
        Button3.FlatAppearance.BorderSize = 0
        Button4.FlatAppearance.BorderSize = 0
        Button3.Visible = False
        If (cookie.GetUserType() = "admin") Then
            Button3.Visible = True
        End If

        If (cookie.GetUserType() = "user") Then
            Button3.Visible = False
        End If
        CountTotalEmployees()
        SetAttendanceTable()
        attrition_lbl.Text = CalculateAttritionRate() & "%"
    End Sub

    Public Function SetAttendanceTable()
        Chart1.Series(0).Points.Clear()
        Chart1.Series(1).Points.Clear()
        Dim dateToday As DateTime = Date.Today()
        dateToday = dateToday.AddDays(-6)
        For a = 0 To 6
            Dim cmd As New OleDbCommand("SELECT COUNT(*) FROM Employees WHERE WorkDate=@date AND Attendance=Yes", conn)
            cmd.Parameters.AddWithValue("@date", dateToday.AddDays(a))
            conn.Open()
            'MsgBox(dateToday.AddDays(a).ToString("dddd") & " " & cmd.ExecuteScalar())
            Me.Chart1.Series("Present").Points.AddXY(dateToday.AddDays(a).ToString("dddd"), cmd.ExecuteScalar())
            Me.Chart1.Series("Absent").Points.AddXY(dateToday.AddDays(a).ToString("dddd"), EmployeeCount - CInt(cmd.ExecuteScalar()))
            'Me.Chart1.Series("Absent").Points.AddXY(dateToday.AddDays(a).ToString("dddd"), EmployeeCount)
            conn.Close()
        Next
        'MsgBox(dateToday)
        'MsgBox(dateToday.AddDays(-6))
        Return Nothing
    End Function

    Public Function CalculateAttritionRate()
        Dim dateToday As DateTime = Date.Today()
        Dim dateFrom = dateToday.AddDays(-100).ToString("d")
        Dim dateTo = dateToday.ToString("d")
        Dim term = Nothing
        Dim emp = Nothing
        'MsgBox("SELECT COUNT(*) FROM EmployeeLogs WHERE LogDate BETWEEN " & Date.Today & " AND " & dateToday.AddDays(-30))
        'MsgBox(dateFrom & " " & dateTo)

        Dim countEmployed As New OleDbCommand("SELECT COUNT(*) FROM EmployeeLogs WHERE Type='employed' AND LogDate BETWEEN @from AND @to", conn)
        countEmployed.Parameters.AddWithValue("@from", dateFrom)
        countEmployed.Parameters.AddWithValue("@to", dateTo)
        Dim countTerminated As New OleDbCommand("SELECT COUNT(*) FROM EmployeeLogs WHERE Type='terminated' AND LogDate BETWEEN @from AND @to", conn)
        countTerminated.Parameters.AddWithValue("@from", dateFrom)
        countTerminated.Parameters.AddWithValue("@to", dateTo)

        conn.Open()
        emp = countEmployed.ExecuteScalar()
        term = countTerminated.ExecuteScalar()
        conn.Close()

        Dim averageNumberOfEmp = (emp + (emp - term)) / 2
        Dim AttritionRate = (term / averageNumberOfEmp) * 100
        Return AttritionRate
    End Function

    'FOR COUNTING TOTAL NUMBER OF EMPLOYEE
    Public Function CountTotalEmployees()
        Dim totalEmp As New OleDbCommand("SELECT COUNT(*) FROM [EmployeeRoster]", conn)
        conn.Open()
        EmployeeCount = CInt(totalEmp.ExecuteScalar())
        conn.Close()
        Return Nothing
    End Function

    Public Function SetProfileInfo()
        PictureBox1.Image = My.Resources.download
        If (cookie.GetUserImage() IsNot Nothing) Then
            PictureBox1.Image = cookie.GetUserImage()
        End If
        Return Nothing
    End Function

    Private Sub Chart1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Dashboard_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Button3.Visible = False
        Me.Dispose()
        Login.Dispose()
    End Sub

    Private Sub logout_btn_Click(sender As Object, e As EventArgs) Handles logout_btn.Click

        Dim choice = MsgBox("Do you want to logout?", vbYesNo, "Confirm Logout")
        If choice = vbYes Then
            cookie.EndSession()
            Button3.Visible = False
            Employee.Button4.Visible = False
            Attendance.admin_btn.Visible = False
            Me.Hide()
            Login.Show()
        End If

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub Panel5_Paint(sender As Object, e As PaintEventArgs) Handles Panel5.Paint

    End Sub

    Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs) Handles Panel4.Paint

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Panel6_Paint(sender As Object, e As PaintEventArgs) Handles Panel6.Paint

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Generate.Click
        'Dim dtepcker As Date = DateTimePicker1.Value.Date
        conn.Open()
        Dim countPrsntToday As New OleDbCommand("SELECT COUNT(*) From [Employees] WHERE WorkDate=@date1 AND Attendance=Yes", conn)
        countPrsntToday.Parameters.AddWithValue("@date1", DateTimePicker1.Value.Date)
        Dim countPrsntGenerated = CInt(countPrsntToday.ExecuteScalar())
        present_lbl.Text = CStr(countPrsntGenerated)

        Dim countTermiEmployees As New OleDbCommand("SELECT COUNT(*) From [EmployeeRoster] WHERE EmpStatus='Terminated'", conn)
        Dim TotalTermiEmp = CInt(countTermiEmployees.ExecuteScalar())

        Dim countTotalEmployees As New OleDbCommand("SELECT COUNT(*) FROM [EmployeeRoster]", conn)
        Dim TotalEmp = CInt(countTotalEmployees.ExecuteScalar())

        Dim TurnOverRate = TotalTermiEmp / TotalEmp * 100

        turnover_lbl.Text = Math.Ceiling(TurnOverRate) & "%"

        conn.Close()
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged

    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Employee.SetProfileInfo()
        Employee.Show()
    End Sub

    Private Sub Chart1_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        Admin.SetProfileInfo()
        Admin.Show()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Me.Hide()
        UserProfile.SetProfileInfo()
        UserProfile.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Hide()
        Attendance.SetProfileInfo()
        Attendance.Show()
    End Sub
End Class