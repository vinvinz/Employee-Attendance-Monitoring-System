Imports System.Data.OleDb

Public Class Attendance

    Dim ConnString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=EAM.mdb"
    Dim conn As New OleDbConnection(ConnString)
    Dim dateToday As DateTime = Date.Today().ToString("d")

    Public Function GetTable(ByVal dateVar) As DataTable
        Dim table As New DataTable
        Dim row As String() = New String() {"q", "w", "e", "", "", ""}

        table.Columns.Add("Employee ID")
        table.Columns.Add("Employee Name")
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

            Using cmd As New OleDbCommand("SELECT EmployeeID, EmployeeFName, EmployeeLName FROM EmployeeRoster WHERE ID=@id", conn)

                cmd.Parameters.AddWithValue("@id", number)
                Try
                    Dim fetchEmpData As OleDbDataReader = cmd.ExecuteReader()
                    If fetchEmpData.Read = True Then
                        row(0) = fetchEmpData("EmployeeID")
                        row(1) = fetchEmpData("EmployeeFName") & " " & fetchEmpData("EmployeeLName")

                        Try
                            Using getAttendance As New OleDbCommand("SELECT * FROM Employees WHERE EmployeeID=@id AND WorkDate=@date", conn)
                                getAttendance.Parameters.AddWithValue("@id", fetchEmpData("EmployeeID"))
                                getAttendance.Parameters.AddWithValue("@date", dateVar)
                                Dim fetchEmpAttendance As OleDbDataReader = getAttendance.ExecuteReader()
                                If fetchEmpAttendance.Read = True Then

                                    If fetchEmpAttendance("Attendance") = -1 Then
                                        row(2) = "PRESENT"
                                        If fetchEmpAttendance("time-in") IsNot Nothing Then
                                            row(3) = fetchEmpAttendance("time-in")
                                        End If
                                        If fetchEmpAttendance("time-out") IsNot Nothing Then
                                            row(4) = fetchEmpAttendance("time-out")
                                        End If
                                    ElseIf fetchEmpAttendance("Attendance") = 0 Then
                                        row(2) = "ABSENT"
                                    End If
                                ElseIf fetchEmpAttendance.Read = False Then
                                    row(2) = "Not Set"
                                    row(3) = "Not Set"
                                    row(4) = "Not Set"
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
                                    row(5) = test
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
        Dim row As String() = New String() {"q", "w", "e"}
        'MsgBox(dateToday)
        With DataGridView1
            .DataSource = GetTable(dateToday)

        End With
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        'MsgBox(DateTimePicker1.Value.ToString("d"))
        DataGridView1.DataSource = GetTable(DateTimePicker1.Value.ToString("d"))
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        DateTimePicker2.Value = Date.Now
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles dash_btn.Click
        Dashboard.Show()
        Dashboard.SetProfileInfo()
        Me.Hide()
    End Sub
End Class