Imports System.Data.OleDb

Public Class Register

    Dim ConnString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=EAM.mdb"
    Dim conn As New OleDbConnection(ConnString)

    Dim usn
    Dim pass
    Dim accType

    Private Sub Register_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ctr = 0
        usn = TextBox1.Text
        pass = TextBox2.Text
        If (RadioButton1.Checked() = True) Then
            accType = "admin"
        ElseIf (RadioButton2.Checked() = True) Then
            accType = "user"
        End If
        If (usn = "" Or pass = "" Or accType = "") Then
            ctr = 1
        End If
        If (ctr = 1) Then
            MsgBox("Error")
        ElseIf (ctr = 0) Then
            Using cmd As New OleDbCommand("INSERT INTO HR_Accounts ([Username], [Password], [AccType], [AccStatus]) VALUES (@usn, @pass, @type, 'enabled')", conn)
                cmd.Parameters.AddWithValue("@usn", usn)
                cmd.Parameters.AddWithValue("@pass", pass)
                cmd.Parameters.AddWithValue("@type", accType)
                conn.Open()
                cmd.ExecuteNonQuery()
                conn.Close()
                MessageBox.Show("Account Registered Successfully")
                Admin.DataGridView1.DataSource = Admin.GetHRAccounts()
                Admin.DataGridView1.ClearSelection()
                Me.Close()
            End Using
        End If
    End Sub
End Class