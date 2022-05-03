Imports System.Configuration
Imports System.Data
Imports System.Data.OleDb

Public Class AddEmployee

    Dim EmployeeID
    Dim Conn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Personal Computer\Source\Repos\Employee-Attendance-Monitoring\EAM.mdb")
    'Provider=Microsoft.Jet.OLEDB.4.0;Data Source="C:\Users\Personal Computer\Source\Repos\Employee-Attendance-Monitoring\EAM.mdb"'

    Public Function GetEmployeeID(ByVal ID)
        EmployeeID = ID
        Return 0
    End Function
    Private Sub AddEmployee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'MsgBox("ID: " & EmployeeID)'
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Using cmd As New OleDbCommand("INSERT INTO Employees (FirstName, LastName) VALUES (@fname, @lname)", Conn)
            cmd.Parameters.AddWithValue("@fname", TextBox1.Text)
            cmd.Parameters.AddWithValue("@lname", TextBox2.Text)
            Conn.Open()
            cmd.ExecuteNonQuery()
            MsgBox("Successfully Added")
            Conn.Close()
            Me.Hide()
            Employee.DataGridView1.DataSource = Employee.GetEmployeesList()
            Employee.Show()
        End Using
    End Sub
End Class