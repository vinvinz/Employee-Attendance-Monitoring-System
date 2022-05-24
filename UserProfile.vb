Public Class UserProfile
    Dim cookie As New LoginSession()
    Private Sub UserProfile_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button1.FlatAppearance.BorderSize = 0
        Button2.FlatAppearance.BorderSize = 0
        Button3.FlatAppearance.BorderSize = 0
        LinkLabel1.LinkVisited = True

        If (cookie.GetUserType() = "admin") Then
            Button3.Visible = True
        End If

        If (cookie.GetUserType() = "user") Then
            Button3.Visible = False
        End If
    End Sub

    Public Function SetProfileInfo()
        LinkLabel1.Text = cookie.GetUsername()
        Label1.Text = Label1.Text & cookie.GetUserFullName
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
            Me.Hide()
            Login.Show()
        End If
    End Sub
End Class