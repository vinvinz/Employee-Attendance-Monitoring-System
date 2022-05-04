Imports System.Data.OleDb
Public Class Employee

    Dim ConnString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=EAM.mdb"
    Dim conn As New OleDbConnection(ConnString)
    Dim EmployeeID
    Dim EmployeeFname
    Dim EmployeeLname
    Dim Status
    Dim StatusTag

    Public Function GetEmployeesList() As DataTable

        Dim Dt As New DataTable

        Using cmd As New OleDbCommand("Select * From EmployeeRoster ORDER BY ID ASC", conn)
            conn.Open()
            Dim readList As OleDbDataReader = cmd.ExecuteReader()
            Dt.Load(readList)
            conn.Close()
        End Using
        Return Dt
    End Function

    Private Sub Employee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridView1.DataSource = GetEmployeesList()
        With DataGridView1
            .RowHeadersVisible = False
            .Columns(0).HeaderCell.Value = "ID"
            .Columns(1).HeaderCell.Value = "Employee ID"
            .Columns(2).HeaderCell.Value = "First Name"
            .Columns(3).HeaderCell.Value = "Last Name"
            .Columns(4).HeaderCell.Value = "Employee Status"
            .Columns(5).HeaderCell.Value = "Status Tag"
        End With
    End Sub

    Private Sub Add_btn_Click(sender As Object, e As EventArgs) Handles Add_btn.Click
        AddEmployee.Show()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        EmployeeID = DataGridView1.SelectedRows(0).Cells(0).Value.ToString()
        EmployeeFname = DataGridView1.SelectedRows(0).Cells(2).Value.ToString()
        EmployeeLname = DataGridView1.SelectedRows(0).Cells(3).Value.ToString()
        Status = DataGridView1.SelectedRows(0).Cells(4).Value.ToString()
        StatusTag = DataGridView1.SelectedRows(0).Cells(5).Value.ToString()
    End Sub
End Class