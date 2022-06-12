Public Class UserProfile
    Dim cookie As New LoginSession()
    Private Sub UserProfile_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button1.FlatAppearance.BorderSize = 0
        Button2.FlatAppearance.BorderSize = 0
        Button3.FlatAppearance.BorderSize = 0
        Button6.FlatAppearance.BorderSize = 0
        LinkLabel1.LinkVisited = True

        If (cookie.GetUserType() = "admin") Then
            Button3.Visible = True
        End If

        If (cookie.GetUserType() = "user") Then
            Button3.Visible = False
        End If
    End Sub

    Public Function SetProfileInfo()
        cookie.FetchUserData()
        LinkLabel1.Text = cookie.GetUsername()
        name_txt.Text = cookie.GetUserFullName()
        empID_txt.Text = cookie.GetEmpID()
        dep_txt.Text = cookie.GetEmpDepartment()
        jobTitle_txt.Text = cookie.GetEmpJobTitle()
        position_txt.Text = cookie.GetEmpPosition()
        PictureBox1.Image = My.Resources.download
        PictureBox2.Image = My.Resources.download
        If (cookie.GetUserImage() IsNot Nothing) Then
            PictureBox1.Image = cookie.GetUserImage()
            PictureBox2.Image = cookie.GetUserImage()
        End If
        Return Nothing
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Dashboard.SetProfileInfo()
        Dashboard.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Employee.SetProfileInfo()
        Employee.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        Admin.SetProfileInfo()
        Admin.Show()
    End Sub

    Private Sub logout_btn_Click(sender As Object, e As EventArgs) Handles logout_btn.Click
        Dim choice = MsgBox("Do you want to logout?", vbYesNo, "Confirm Logout")
        If choice = vbYes Then
            cookie.EndSession()
            Button3.Visible = False
            Employee.Button4.Visible = False
            Dashboard.Button3.Visible = False
            Attendance.admin_btn.Visible = False
            Me.Hide()
            Login.Show()
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.Hide()
        Attendance.SetProfileInfo()
        Attendance.Show()
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles dep_txt.TextChanged

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub position_txt_TextChanged(sender As Object, e As EventArgs) Handles position_txt.TextChanged

    End Sub

    Private Sub jobTitle_txt_TextChanged(sender As Object, e As EventArgs) Handles jobTitle_txt.TextChanged

    End Sub
End Class