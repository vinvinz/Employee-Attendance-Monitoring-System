Imports System.Data
Imports System.Data.OleDb

Public Class Employee
    Private Sub Employee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridView1.DataSource = GetEmployeesList()
    End Sub

    Public Function GetEmployeesList() As DataTable
        Dim Dt As New DataTable
        Dim ConnString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=EAM.mdb"

        Using conn As New OleDbConnection(ConnString)
            Using cmd As New OleDbCommand("Select * From Employees", conn)
                conn.Open()
                Dim readList As OleDbDataReader = cmd.ExecuteReader()
                Dt.Load(readList)
            End Using
        End Using
        Return Dt
    End Function

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'AddEmployee.GetEmployeeID(2)'
        Me.Hide()
        AddEmployee.Show()
    End Sub

    Private Sub DataGridView1_Click(sender As Object, e As EventArgs) Handles DataGridView1.Click

    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        'MsgBox("click")'
        'Dim test = DataGridView1.SelectedRows(0).Cells(0).Value.ToString()'
        'MsgBox(test)'

    End Sub
End Class