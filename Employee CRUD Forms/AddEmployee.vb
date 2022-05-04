Imports System.Data.OleDb

Public Class AddEmployee

    Dim ConnString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=EAM.mdb"
    Dim conn As New OleDbConnection(ConnString)
    Dim rowCount

    Private Sub AddEmployee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim count_rows As New OleDbCommand("SELECT COUNT(*) From [EmployeeRoster]", conn)
        conn.Open()
        rowCount = CInt(count_rows.ExecuteScalar())
        conn.Close()
        Dim IdCountLen = CType(rowCount + 1, String).Length
        If (IdCountLen.Equals(1)) Then
            TextBox4.Text = ("2022030" & rowCount + 1)
        ElseIf (IdCountLen > 1) Then
            TextBox4.Text = ("202203" & rowCount + 1)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Using cmd As New OleDbCommand("INSERT INTO EmployeeRoster (EmployeeID, EmployeeFName, EmployeeLName, EmpStatus, EmpStatusTag) VALUES (@empID, @fname, @lname, @empStatus, @empStatusTag)", conn)
            cmd.Parameters.AddWithValue("@empID", TextBox4.Text)
            cmd.Parameters.AddWithValue("@fname", TextBox1.Text)
            cmd.Parameters.AddWithValue("@lname", TextBox2.Text)
            cmd.Parameters.AddWithValue("@empStatus", ComboBox2.Text)
            cmd.Parameters.AddWithValue("@empStatusTag", TextBox3.Text)
            conn.Open()
            cmd.ExecuteNonQuery()
            MsgBox("Successfully Added")
            conn.Close()
            Me.Refresh()
            Me.Close()
            Employee.DataGridView1.DataSource = Employee.GetEmployeesList()
            Employee.Show()
        End Using
    End Sub
End Class