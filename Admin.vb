Imports System.Data.OleDb

Public Class Admin

    Dim ConnString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=EAM.mdb"
    Dim conn As New OleDbConnection(ConnString)

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

    Private Sub AdminForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button1.FlatAppearance.BorderSize = 0
        Button2.FlatAppearance.BorderSize = 0
        Button3.FlatAppearance.BorderSize = 0
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
End Class