Public Class UserProfile
    Dim cookie As New LoginSession()
    Private Sub UserProfile_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button1.FlatAppearance.BorderSize = 0
        Button2.FlatAppearance.BorderSize = 0
        Button3.FlatAppearance.BorderSize = 0
        LinkLabel1.LinkVisited = True

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

        Return Nothing
    End Function
End Class