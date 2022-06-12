Imports System.Data.OleDb

Public Class Attendance

    Dim ConnString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=EAM.mdb" '"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Personal Computer\Source\Repos\Employee-Attendance-Monitoring\EAM.mdb"

    Dim conn As New OleDbConnection(ConnString)
    Dim dateToday As DateTime = Date.Today().ToString("d")

    Dim selectedDate As DateTime

    Dim selectedEmpID
    Dim selectedEmpAttendance
    Dim selectedEmpStatus

    Public Function GetTable(ByVal dateVar) As DataTable
        Dim table As New DataTable
        Dim row As String() = New String() {"", "", "", "", "", "", ""}

        table.Columns.Add("Employee ID")
        table.Columns.Add("Employee Name")
        table.Columns.Add("Department")
        table.Columns.Add("Attendance")
        table.Columns.Add("Time-In")
        table.Columns.Add("Time-Out")
        table.Columns.Add("Employment Status")

        Dim empCount
        Dim EmployeeCounter As New OleDbCommand("SELECT COUNT(*) FROM EmployeeRoster", conn)
        conn.Open()
        empCount = EmployeeCounter.ExecuteScalar()
        conn.Close()
        conn.Open()
        For number As Integer = 1 To empCount

            Using cmd As New OleDbCommand("SELECT EmployeeID, EmployeeFName, Department, EmployeeLName FROM EmployeeRoster WHERE ID=@id", conn)

                cmd.Parameters.AddWithValue("@id", number)
                Try
                    Dim fetchEmpData As OleDbDataReader = cmd.ExecuteReader()
                    If fetchEmpData.Read = True Then
                        row(0) = fetchEmpData("EmployeeID")
                        row(1) = fetchEmpData("EmployeeFName") & " " & fetchEmpData("EmployeeLName")
                        row(2) = fetchEmpData("Department")
                        Try
                            Using getAttendance As New OleDbCommand("SELECT * FROM Employees WHERE EmployeeID=@id AND WorkDate=@date", conn)
                                getAttendance.Parameters.AddWithValue("@id", fetchEmpData("EmployeeID"))
                                getAttendance.Parameters.AddWithValue("@date", dateVar)
                                Dim fetchEmpAttendance As OleDbDataReader = getAttendance.ExecuteReader()
                                If fetchEmpAttendance.Read = True Then

                                    If fetchEmpAttendance("Attendance") = -1 Then
                                        row(3) = "PRESENT"
                                        If fetchEmpAttendance("time-in") IsNot DBNull.Value Then
                                            row(4) = fetchEmpAttendance("time-in")
                                        ElseIf fetchEmpAttendance("time-in") Is DBNull.Value Then
                                            row(4) = "Not Set"
                                        End If
                                        If fetchEmpAttendance("time-out") IsNot DBNull.Value Then
                                            row(5) = fetchEmpAttendance("time-out")
                                        ElseIf fetchEmpAttendance("time-out") Is DBNull.Value Then
                                            row(5) = "Not Set"
                                        End If
                                    ElseIf fetchEmpAttendance("Attendance") = 0 Then
                                        row(3) = "ABSENT"
                                    End If
                                ElseIf fetchEmpAttendance.Read = False Then
                                    row(3) = "Not Set"
                                    row(4) = "Not Set"
                                    row(5) = "Not Set"
                                End If
                            End Using

                            Using getEmpStatus As New OleDbCommand("SELECT TOP 1 * FROM EmployeeLogs WHERE EmployeeID=@id AND LogDate BETWEEN @date AND @today AND LogDate=@date < @today ORDER BY LogDate DESC", conn)
                                getEmpStatus.Parameters.AddWithValue("@id", fetchEmpData("EmployeeID"))
                                'FIX DATE FOR WHEN THE QUERY SHOULD START FETCHING DATA
                                Dim dateFix As DateTime = "1/1/2022"
                                getEmpStatus.Parameters.AddWithValue("@date", dateFix)
                                getEmpStatus.Parameters.AddWithValue("@today", dateVar)

                                Dim fetchEmpStatus As OleDbDataReader = getEmpStatus.ExecuteReader()
                                If fetchEmpStatus.Read = True Then
                                    'If fetchEmpStatus.HasRows = True Then
                                    '    fetchEmpStatus.NextResult()
                                    '    Dim test = fetchEmpStatus("Type")
                                    '    row(5) = test
                                    'End If
                                    Dim test = fetchEmpStatus("Type")
                                    row(6) = test
                                Else
                                    row(6) = "Not Set"
                                End If
                            End Using
                        Catch ex As Exception
                            MsgBox(ex.Message)
                        End Try

                        table.Rows.Add(row)
                    End If
                Catch ex As Exception

                End Try

            End Using
        Next
        conn.Close()
        Return table
    End Function

    Private Sub Attendance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dash_btn.FlatAppearance.BorderSize = 0
        emp_btn.FlatAppearance.BorderSize = 0
        admin_btn.FlatAppearance.BorderSize = 0
        records_btn.FlatAppearance.BorderSize = 0
        DateTimePicker1.Value = dateToday
        'MsgBox(dateToday)
        With DataGridView1
            .DataSource = GetTable(dateToday)
            .ClearSelection()
        End With
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        'MsgBox(DateTimePicker1.Value.ToString("d"))
        selectedDate = DateTimePicker1.Value.ToString("d")
        DataGridView1.DataSource = GetTable(selectedDate)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        DateTimePicker2.Value = Date.Now
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles dash_btn.Click
        Dashboard.Show()
        Dashboard.SetProfileInfo()
        Dashboard.CountTotalEmployees()
        Dashboard.SetAttendanceTable()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If selectedEmpAttendance = "Not Set" Then
            Using cmd As New OleDbCommand("INSERT INTO Employees(EmployeeID, WorkDate, Attendance) VALUES(@id, @date, Yes)", conn)
                cmd.Parameters.AddWithValue("@id", selectedEmpID)
                cmd.Parameters.AddWithValue("@date", selectedDate)
                conn.Open()
                cmd.ExecuteNonQuery()
                conn.Close()
            End Using
        ElseIf selectedEmpAttendance = "PRESENT" Then
            Dim UpdateAttendance As New OleDbCommand("UPDATE Employees SET [Attendance]=0 WHERE [EmployeeID]=@id", conn)
            UpdateAttendance.Parameters.AddWithValue("@id", selectedEmpID)
            conn.Open()
            UpdateAttendance.ExecuteNonQuery()
            conn.Close()
        ElseIf selectedEmpAttendance = "ABSENT" Then
            Dim UpdateAttendance As New OleDbCommand("UPDATE Employees SET [Attendance]=-1 WHERE [EmployeeID]=@id", conn)
            UpdateAttendance.Parameters.AddWithValue("@id", selectedEmpID)
            conn.Open()
            UpdateAttendance.ExecuteNonQuery()
            conn.Close()
        End If
        DataGridView1.DataSource = GetTable(selectedDate)
        DataGridView1.ClearSelection()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try
            selectedEmpID = DataGridView1.SelectedRows(0).Cells(0).Value.ToString()
            selectedEmpAttendance = DataGridView1.SelectedRows(0).Cells(3).Value.ToString()
            If selectedEmpAttendance = "PRESENT" Then
                Button1.Text = "Unmark Attendance"
            ElseIf selectedEmpAttendance = "Not Set" Then
                Button1.Text = "Mark Attendance"
            ElseIf selectedEmpAttendance = "ABSENT" Then
                Button1.Text = "Mark Attendance"
            End If
            selectedEmpStatus = DataGridView1.SelectedRows(0).Cells(6).Value.ToString()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If selectedEmpAttendance = "PRESENT" Then

        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

    End Sub
End Class