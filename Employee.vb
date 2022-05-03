Imports System.Data
Imports System.Data.OleDb

Public Class Employee

    Dim ConnString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Personal Computer\Source\Repos\Employee-Attendance-Monitoring\EAM.mdb"
    Dim conn As New OleDbConnection(ConnString)
    Dim EmployeeID
    Dim EmployeeFname
    Dim EmployeeLname

    Private Sub Employee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridView1.DataSource = GetEmployeesList()
    End Sub

    Public Function GetEmployeesList() As DataTable

        Dim Dt As New DataTable

        Using cmd As New OleDbCommand("Select * From Employees ORDER BY ID ASC", conn)
            conn.Open()
            Dim readList As OleDbDataReader = cmd.ExecuteReader()
            Dt.Load(readList)
            conn.Close()
        End Using
        Return Dt
    End Function

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'AddEmployee.GetEmployeeID(2)'
        AddEmployee.Show()
    End Sub

    Private Sub DataGridView1_Click(sender As Object, e As EventArgs) Handles DataGridView1.Click

    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        'MsgBox("click")'
        'Dim test = DataGridView1.SelectedRows(0).Cells(0).Value.ToString()'
        'MsgBox(test)'
        EmployeeID = DataGridView1.SelectedRows(0).Cells(0).Value.ToString()
        EmployeeFname = DataGridView1.SelectedRows(0).Cells(1).Value.ToString()
        EmployeeLname = DataGridView1.SelectedRows(0).Cells(2).Value.ToString()

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        DataGridView1.DataSource = GetEmployeesList()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        EditEmployee.SetData(EmployeeID, EmployeeFname, EmployeeLname)
        Me.Hide()
        EditEmployee.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Dashboard.Show()
    End Sub
End Class