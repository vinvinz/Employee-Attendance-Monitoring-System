Imports System.Configuration
Imports System.Data
Imports System.Data.OleDb

Public Class Employee
    Private Sub Employee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridView1.DataSource = GetEmployeesList()
    End Sub

    Public Function GetEmployeesList() As DataTable
        Dim Dt As New DataTable
        Dim ConnString As String = ConfigurationManager.ConnectionStrings("Employee_Attendance_Monitoring.My.MySettings.EAMConnectionString1").ConnectionString

        Using conn As New OleDbConnection(ConnString)
            Using cmd As New OleDbCommand("Select * From Employees", conn)
                conn.Open()
                Dim readList As OleDbDataReader = cmd.ExecuteReader()
                Dt.Load(readList)
            End Using
        End Using
        Return Dt
    End Function
End Class