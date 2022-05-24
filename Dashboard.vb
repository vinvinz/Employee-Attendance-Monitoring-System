Imports System.Data.OleDb
Public Class Dashboard

    Dim cookie = New LoginSession()

    Private Sub Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'EAMDataSet3.Employees' table. You can move, or remove it, as needed.
        Me.EmployeesTableAdapter3.Fill(Me.EAMDataSet3.Employees)

        Button1.FlatAppearance.BorderSize = 0
        Button2.FlatAppearance.BorderSize = 0
        Button3.FlatAppearance.BorderSize = 0
        Button3.Visible = False
        If (cookie.GetUserType() = "admin") Then
            Button3.Visible = True
        End If

        If (cookie.GetUserType() = "user") Then
            Button3.Visible = False
        End If

    End Sub

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

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Panel6_Paint(sender As Object, e As PaintEventArgs) Handles Panel6.Paint

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Generate.Click
        'Dim dtepcker As Date = DateTimePicker1.Value.Date

        Dim conn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=EAM.mdb")
        conn.Open()
        Dim countPrsntToday As New OleDbCommand("SELECT COUNT(*) From [Employees] WHERE WorkDate=@date1", conn)
        countPrsntToday.Parameters.AddWithValue("@date1", DateTimePicker1.Value.Date)
        Dim countPrsntGenerated = CInt(countPrsntToday.ExecuteScalar())
        TextBox1.Text = CStr(countPrsntGenerated)

        Dim countTermiEmployees As New OleDbCommand("SELECT COUNT(*) From [EmployeeRoster] WHERE EmpStatus='Terminated'", conn)
        Dim TotalTermiEmp = CInt(countTermiEmployees.ExecuteScalar())

        Dim countTotalEmployees As New OleDbCommand("SELECT COUNT(*) FROM [EmployeeRoster]", conn)
        Dim TotalEmp = CInt(countTotalEmployees.ExecuteScalar())

        Dim TurnOverRate = TotalTermiEmp / TotalEmp * 100

        TextBox2.Text = Math.Ceiling(TurnOverRate) & "%"

        conn.Close()
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged

    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Employee.SetProfileInfo()
        Employee.Show()
    End Sub

    Private Sub Chart1_Click_1(sender As Object, e As EventArgs) Handles Chart1.Click

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

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
End Class