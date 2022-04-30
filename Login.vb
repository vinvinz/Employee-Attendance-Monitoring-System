Imports System.Data.OleDb
Public Class Login
    Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\EAM.accdb")
    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs)

    End Sub

    Private Sub login_btn_Click(sender As Object, e As EventArgs) Handles login_btn.Click

        Dim cmd As OleDbCommand = New OleDbCommand("SELECT * FROM [HR-Acc] WHERE username='" & TextBox1.Text & "' AND password='" & TextBox2.Text & "'", con)
        Dim user As String = ""
        Dim pass As String = ""

        con.Open()
        Dim check As OleDbDataReader = cmd.ExecuteReader()
        If check.Read = True Then
            user = check("username")
            pass = check("password")
            MsgBox("Login Success!")
            con.Close()
            Dashboard.Show()
            Me.Hide()
        Else
            MsgBox("Nahh can't login...")
            con.Close()
        End If
    End Sub
End Class
