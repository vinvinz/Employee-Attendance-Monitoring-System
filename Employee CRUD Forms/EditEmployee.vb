Imports System.Data.OleDb

Public Class EditEmployee
    Dim ConnString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=EAM.mdb"
    Dim conn As New OleDbConnection(ConnString)
    Public Shared Id
    Public Shared empID
    Public Shared empFname
    Public Shared empLname
    Public Shared empStatus
    Public Shared empStatusTag

    Public Function setData(ByVal ID, ByVal EmpID, ByVal EmpFname, ByVal EmpLname, ByVal EmpStatus, ByVal EmpStatusTag)
        EditEmployee.Id = ID
        EditEmployee.empID = EmpID
        EditEmployee.empFname = EmpFname
        EditEmployee.empLname = EmpLname
        EditEmployee.empStatus = EmpStatus
        EditEmployee.empStatusTag = EmpStatusTag
        Return 0
    End Function

    Private Sub EditEmployee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox4.Text = empID
        TextBox1.Text = empFname
        TextBox2.Text = empLname
        ComboBox2.SelectedIndex = ComboBox2.FindString(empStatus)
        TextBox3.Text = empStatusTag
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Using cmd As New OleDbCommand("UPDATE EmployeeRoster SET EmployeeID=@empId, EmployeeFName=@fname, EmployeeLName=@lname, EmpStatus=@status, EmpStatusTag=@tag WHERE ID=@Id", conn)
            cmd.Parameters.AddWithValue("@empId", TextBox4.Text)
            cmd.Parameters.AddWithValue("@fname", TextBox1.Text)
            cmd.Parameters.AddWithValue("@lname", TextBox2.Text)
            cmd.Parameters.AddWithValue("@status", ComboBox2.Text)
            cmd.Parameters.AddWithValue("@tag", TextBox3.Text)
            cmd.Parameters.AddWithValue("@Id", Id)
            conn.Open()
            cmd.ExecuteNonQuery()
            MsgBox("Successfully Updated")
            conn.Close()
            Employee.DataGridView1.DataSource = Employee.GetEmployeesList()
            Employee.DataGridView1.ClearSelection()
            Employee.Edit_btn.Enabled = False
            Employee.Show()
            Me.Close()
        End Using
    End Sub
End Class