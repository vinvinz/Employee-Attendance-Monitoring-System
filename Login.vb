Imports System.Data.OleDb
Public Class Login
    Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=EAM.mdb")
    Dim usnFlag = 0
    Dim passFlag = 0
    Dim cookie = New LoginSession()

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs)

    End Sub

    Private Sub login_btn_Click(sender As Object, e As EventArgs) Handles login_btn.Click

        Dim cmd As OleDbCommand = New OleDbCommand("SELECT * FROM [HR_Accounts] WHERE Username='" & TextBox1.Text & "' AND StrComp([Password], '" & TextBox2.Text & "', 0) = 0", con)
        Dim user As String = ""
        Dim pass As String = ""

        con.Open()
        Dim check As OleDbDataReader = cmd.ExecuteReader()

        If check.Read = True Then
            user = check("Username")
            pass = check("Password")

            'FETCHING USER ID FOR USER SESSION
            cookie.setUserID(check.GetValue(0))
            cookie.StartSession()
            Dashboard.LinkLabel1.Text = TextBox1.Text
            Employee.LinkLabel1.Text = TextBox1.Text
            con.Close()
            If (cookie.GetUserStatus() = "enabled" Or cookie.GetUserStatus() = "disabled") Then
                MsgBox("Login Success!")
                con.Close()
                Dashboard.SetProfileInfo()
                Dashboard.Show()
                Me.Hide()
            ElseIf (cookie.GetUserStatus() = "banned") Then
                MessageBox.Show("You are banned and can't login.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            If (cookie.GetUserType() = "admin") Then
                Dashboard.Button3.Visible = True
                Employee.Button4.Visible = True
                UserProfile.Button3.Visible = True
                Attendance.admin_btn.Visible = True
            End If
            TextBox1.Clear()
                TextBox2.Clear()
            Else
                MsgBox("Nahh can't login...")
            con.Close()
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.Click
        If usnFlag = 0 Then
            Usn_lbl.Text = ""
        End If
    End Sub

    Private Sub TextBox1_TextChanged_2(sender As Object, e As EventArgs) Handles TextBox1.LostFocus
        If usnFlag = 0 Then
            Usn_lbl.Text = "Username"
        End If
    End Sub

    Private Sub TextBox1_TextChanged_3(sender As Object, e As EventArgs) Handles TextBox1.GotFocus
        If usnFlag = 0 Then
            Usn_lbl.Text = ""
        End If
    End Sub

    Private Sub TextBox1_TextChanged_1(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If (TextBox1.Text IsNot "") Then
            Usn_lbl.Text = ""
            usnFlag = 1
        ElseIf (TextBox1.Text Is "") Then
            Usn_lbl.Text = "Username"
            usnFlag = 0
        End If
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        If (TextBox2.Text IsNot "") Then
            Pass_lbl.Text = ""
            passFlag = 1
        ElseIf (TextBox2.Text Is "") Then
            Pass_lbl.Text = "Password"
            passFlag = 0
        End If
    End Sub

    Private Sub TextBox2_TextChanged_1(sender As Object, e As EventArgs) Handles TextBox2.Click
        If passFlag = 0 Then
            Pass_lbl.Text = ""
        End If
    End Sub

    Private Sub TextBox2_TextChanged_2(sender As Object, e As EventArgs) Handles TextBox2.LostFocus
        If passFlag = 0 Then
            Pass_lbl.Text = "Password"
        End If
    End Sub

    Private Sub TextBox2_TextChanged_3(sender As Object, e As EventArgs) Handles TextBox2.GotFocus
        If passFlag = 0 Then
            Pass_lbl.Text = ""
        End If
    End Sub

End Class
