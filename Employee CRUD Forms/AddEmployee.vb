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

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedChars As String = "abcdefghijklmnopqrstuvwxyz "
            If Not allowedChars.Contains(e.KeyChar.ToString.ToLower) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedChars As String = "abcdefghijklmnopqrstuvwxyz "
            If Not allowedChars.Contains(e.KeyChar.ToString.ToLower) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Not String.IsNullOrEmpty(TextBox1.Text) And Not String.IsNullOrEmpty(TextBox2.Text) And Not String.IsNullOrEmpty(ComboBox2.Text) Then
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
                Employee.DataGridView1.DataSource = Employee.GetEmployeesList()
                Employee.DataGridView1.ClearSelection()
                Employee.Edit_btn.Enabled = False
                Me.Close()
                Employee.Show()
            End Using
        Else
            MsgBox("Empty Field Detected", vbCritical, "Warning")
        End If
    End Sub

End Class