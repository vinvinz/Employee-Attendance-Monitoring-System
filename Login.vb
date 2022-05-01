Imports System.Data.OleDb
Public Class Login
    Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=EAM.mdb")
    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs)

    End Sub

    Private Sub login_btn_Click(sender As Object, e As EventArgs) Handles login_btn.Click

        Dim cmd As OleDbCommand = New OleDbCommand("SELECT * FROM [HR-Acc] WHERE Username='" & TextBox1.Text & "' AND StrComp([Password], '" & TextBox2.Text & "', 0) = 0", con)
        Dim user As String = ""
        Dim pass As String = ""

        con.Open()
        Dim check As OleDbDataReader = cmd.ExecuteReader()
        If check.Read = True Then
            user = check("Username")
            pass = check("Password")
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
