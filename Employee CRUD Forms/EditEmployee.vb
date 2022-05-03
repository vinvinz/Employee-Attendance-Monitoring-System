Imports System.Data.OleDb
Public Class EditEmployee

    Dim ConnString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Personal Computer\Source\Repos\Employee-Attendance-Monitoring\EAM.mdb"
    Dim conn As New OleDbConnection(ConnString)
    Public Shared fname
    Public Shared lname
    Public Shared id

    Public Function SetData(ByVal ID, ByVal Fname, ByVal Lname)
        EditEmployee.fname = Fname
        EditEmployee.lname = Lname
        EditEmployee.id = ID
    End Function

    Private Sub EditEmployee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = fname
        TextBox2.Text = lname
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Using cmd As New OleDbCommand("UPDATE Employees SET FirstName=@fname, LastName=@lname WHERE ID=@id", conn)
            cmd.Parameters.AddWithValue("@fname", TextBox1.Text)
            cmd.Parameters.AddWithValue("@lname", TextBox2.Text)
            cmd.Parameters.AddWithValue("@id", id)
            conn.Open()
            cmd.ExecuteNonQuery()
            MsgBox("Successfully Updated")
            conn.Close()
            Me.Hide()
            Employee.DataGridView1.DataSource = Employee.GetEmployeesList()
            Employee.Show()
        End Using
    End Sub
End Class