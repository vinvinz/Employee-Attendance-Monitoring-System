Imports System.Data.OleDb

Public Class Admin

    Dim ConnString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=EAM.mdb"
    Dim conn As New OleDbConnection(ConnString)
    Dim ID
    Dim Usn
    Dim Pass
    Dim Type
    Dim Status

    Public Function GetHRAccounts() As DataTable
        Dim DataTb As New DataTable

        Using cmd As New OleDbCommand("SELECT * FROM HR_Accounts ORDER BY ID ASC", conn)
            conn.Open()
            Dim readList As OleDbDataReader = cmd.ExecuteReader()
            DataTb.Load(readList)
            conn.Close()
        End Using
        Return DataTb

    End Function

    Public Function GetBannerCounts()
        Try
            conn.Open()
            Dim countAdmin As New OleDbCommand("SELECT COUNT(*) From HR_Accounts WHERE AccType='admin'", conn)
            Dim adminCount = CInt(countAdmin.ExecuteScalar())
            Dim countUser As New OleDbCommand("SELECT COUNT(*) From HR_Accounts WHERE AccType='user'", conn)
            Dim userCount = CInt(countUser.ExecuteScalar())
            Dim countEnabled As New OleDbCommand("SELECT COUNT(*) From HR_Accounts WHERE AccStatus='enabled'", conn)
            Dim enabledCount = CInt(countEnabled.ExecuteScalar())
            Dim countDisabled As New OleDbCommand("SELECT COUNT(*) From HR_Accounts WHERE AccStatus='disabled'", conn)
            Dim disabledCount = CInt(countDisabled.ExecuteScalar())
            Dim countBanned As New OleDbCommand("SELECT COUNT(*) From HR_Accounts WHERE AccStatus='banned'", conn)
            Dim bannedCount = CInt(countBanned.ExecuteScalar())
            conn.Close()
            admin_lbl.Text = adminCount
            user_lbl.Text = userCount
            enabled_lbl.Text = enabledCount
            disabled_lbl.Text = disabledCount
            banned_lbl.Text = bannedCount

        Catch ex As Exception

        End Try
        Return 0
    End Function

    Private Sub AdminForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button1.FlatAppearance.BorderSize = 0
        Button2.FlatAppearance.BorderSize = 0
        Button3.FlatAppearance.BorderSize = 0
        Button5.Enabled = False
        Button6.Enabled = False
        DataGridView1.DataSource = GetHRAccounts()
        DataGridView1.ClearSelection()
        With DataGridView1
            .RowHeadersVisible = False
            .Columns(0).HeaderCell.Value = "ID"
            .Columns(1).HeaderCell.Value = "Username"
            .Columns(2).HeaderCell.Value = "Password"
            .Columns(3).HeaderCell.Value = "Account Type"
            .Columns(4).HeaderCell.Value = "Account Status"
        End With
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Employee.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Dashboard.Show()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        GetBannerCounts()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Register.Show()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try
            ID = DataGridView1.SelectedRows(0).Cells(0).Value.ToString()
            Usn = DataGridView1.SelectedRows(0).Cells(1).Value.ToString()
            Pass = DataGridView1.SelectedRows(0).Cells(2).Value.ToString()
            Type = DataGridView1.SelectedRows(0).Cells(3).Value.ToString()
            Status = DataGridView1.SelectedRows(0).Cells(4).Value.ToString()
            Button5.Enabled = True
            Button6.Enabled = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        UpdateAccount.SetAccountData(ID, Usn, Pass, Type, Status)
        UpdateAccount.Show()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim opt = MessageBox.Show("Are you sure you want to Delete Account with " & ID & "?", "DELETE", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
        If (opt = 1) Then
            Using cmd As New OleDbCommand("DELETE FROM HR_Accounts WHERE ID=@id", conn)
                cmd.Parameters.AddWithValue("@id", ID)
                conn.Open()
                cmd.ExecuteNonQuery()
                MsgBox("Delete Success")
                conn.Close()
                DataGridView1.DataSource = GetHRAccounts()
                DataGridView1.ClearSelection()
                Button5.Enabled = False
                Button6.Enabled = False
            End Using
        End If
    End Sub
End Class