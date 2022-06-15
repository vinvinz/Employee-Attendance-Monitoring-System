Imports System.Data.OleDb

Public Class Attendance
    Dim cookie = New LoginSession()

    Dim ConnString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=EAM.mdb"
    '"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Personal Computer\Source\Repos\Employee-Attendance-Monitoring\EAM.mdb"
    Dim conn As New OleDbConnection(ConnString)
    Dim dateToday As DateTime = Date.Today().ToString("d")

    Dim selectedDate As DateTime

    Dim selectedEmpID
    Dim selectedEmpAttendance
    Dim selectedEmpStatus



    Public Function SetProfileInfo()
        LinkLabel1.Text = cookie.GetUsername()
        PictureBox1.Image = My.Resources.download
        If (cookie.GetUserImage() IsNot Nothing) Then
            PictureBox1.Image = cookie.GetUserImage()
        End If
        Return Nothing
    End Function

    Public Function GetTable(ByVal dateVar) As DataTable
        Dim table As New DataTable
        Dim row As String() = New String() {"Not Set", "Not Set", "Not Set", "Not Set", "Not Set", "Not Set", "Not Set"}

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
                                        'DataGridView1.Item(number)
                                        If IsDBNull(fetchEmpAttendance("time-in")) = False Then
                                            row(4) = fetchEmpAttendance("time-in")
                                        ElseIf IsDBNull(fetchEmpAttendance("time-in")) = True Then
                                            row(4) = "Not Set"
                                        Else
                                            row(4) = "Not Set"
                                        End If
                                        If IsDBNull(fetchEmpAttendance("time-out")) = False Then
                                            row(5) = fetchEmpAttendance("time-out")
                                        ElseIf IsDBNull(fetchEmpAttendance("time-out")) = True Then
                                            row(5) = "Not Set"
                                        Else
                                            row(4) = "Not Set"
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
                                    If test = "employed" Then
                                        test = "Employed"
                                    ElseIf test = "terminated" Then
                                        test = "Terminated"
                                    End If
                                    row(6) = test
                                Else
                                    row(6) = "Not Set"
                                End If
                            End Using
                            table.Rows.Add(row)
                            row = {"Not Set", "Not Set", "Not Set", "Not Set", "Not Set", "Not Set", "Not Set"}
                        Catch ex As Exception
                            MsgBox(ex.Message)
                        End Try
                    End If
                Catch ex As Exception

                End Try

            End Using
        Next
        conn.Close()
        Return table
    End Function

    Public Function ColorTable()
        For num As Integer = 0 To DataGridView1.RowCount
            If DataGridView1.Rows(num).Cells(2).Value = "I.T." Then
                DataGridView1.Rows(num).Cells(2).Style.BackColor = Color.Green
            End If
        Next
        Return Nothing
    End Function

    Private Sub Attendance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dash_btn.FlatAppearance.BorderSize = 0
        emp_btn.FlatAppearance.BorderSize = 0
        admin_btn.FlatAppearance.BorderSize = 0
        records_btn.FlatAppearance.BorderSize = 0
        DateTimePicker1.Value = dateToday
        admin_btn.Visible = False
        'MsgBox(dateToday)
        With DataGridView1
            .DataSource = GetTable(dateToday)
            .ClearSelection()
        End With
        DateTimePicker1.MaxDate = dateToday

        If (cookie.GetUserType() = "admin") Then
            admin_btn.Visible = True
        End If

        If (cookie.GetUserType() = "user") Then
            admin_btn.Visible = False
        End If

    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        'MsgBox(DateTimePicker1.Value.ToString("d"))
        selectedDate = DateTimePicker1.Value.ToString("d")
        DataGridView1.DataSource = GetTable(selectedDate)
        DataGridView1.ClearSelection()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        timePicker.Value = Date.Now
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles dash_btn.Click
        Me.Hide()
        Dashboard.SetProfileInfo()
        Dashboard.CountTotalEmployees()
        Dashboard.SetAttendanceTable()
        Dashboard.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (cookie.GetUserStatus() = "disabled" And cookie.GetUserType() = "user") Then
            MessageBox.Show("You have no permission to modify Records.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ElseIf (cookie.GetUserStatus() = "enabled" Or cookie.GetUserType() = "admin") Then
            If selectedEmpStatus = "Employed" Then
                If selectedEmpAttendance = "Not Set" Then
                    Using cmd As New OleDbCommand("INSERT INTO Employees(EmployeeID, WorkDate, Attendance) VALUES(@id, @date, Yes)", conn)
                        cmd.Parameters.AddWithValue("@id", selectedEmpID)
                        cmd.Parameters.AddWithValue("@date", selectedDate)
                        conn.Open()
                        cmd.ExecuteNonQuery()
                        conn.Close()
                    End Using
                ElseIf selectedEmpAttendance = "PRESENT" Then
                    Dim UpdateAttendance As New OleDbCommand("UPDATE Employees SET [time-in]=@timein, [time-out]=@timeout, [Attendance]=0 WHERE [EmployeeID]=@id AND [WorkDate]=@date", conn)
                    UpdateAttendance.Parameters.AddWithValue("@timein", DBNull.Value)
                    UpdateAttendance.Parameters.AddWithValue("@timeout", DBNull.Value)
                    UpdateAttendance.Parameters.AddWithValue("@id", selectedEmpID)
                    UpdateAttendance.Parameters.AddWithValue("@date", selectedDate)
                    conn.Open()
                    UpdateAttendance.ExecuteNonQuery()
                    conn.Close()
                ElseIf selectedEmpAttendance = "ABSENT" Then
                    Dim UpdateAttendance As New OleDbCommand("UPDATE Employees SET [Attendance]=-1 WHERE [EmployeeID]=@id AND [WorkDate]=@date", conn)
                    UpdateAttendance.Parameters.AddWithValue("@id", selectedEmpID)
                    UpdateAttendance.Parameters.AddWithValue("@date", selectedDate)
                    conn.Open()
                    UpdateAttendance.ExecuteNonQuery()
                    conn.Close()
                End If
                DataGridView1.DataSource = GetTable(selectedDate)
                DataGridView1.ClearSelection()
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try
            selectedEmpID = DataGridView1.SelectedRows(0).Cells(0).Value.ToString()
            selectedEmpAttendance = DataGridView1.SelectedRows(0).Cells(3).Value.ToString()
            selectedEmpStatus = DataGridView1.SelectedRows(0).Cells(6).Value.ToString()

            If selectedEmpAttendance = "PRESENT" Then
                Button1.Text = "UNMARK ATTENDANCE"
            ElseIf selectedEmpAttendance = "Not Set" Then
                Button1.Text = "MARK ATTENDANCE"
            ElseIf selectedEmpAttendance = "ABSENT" Then
                Button1.Text = "MARK ATTENDANCE"
            End If

            If selectedEmpStatus = "Not Set" Then
                Button5.Text = "MARK AS EMPLOYED"
            ElseIf selectedEmpStatus = "Employed" Then
                Button5.Text = "MARK AS TERMINATED"
            ElseIf selectedEmpStatus = "Terminated" Then
                Button5.Text = "MARK AS EMPLOYED"
            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If (cookie.GetUserStatus() = "disabled" And cookie.GetUserType() = "user") Then
            MessageBox.Show("You have no permission to modify Records.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ElseIf (cookie.GetUserStatus() = "enabled" Or cookie.GetUserType() = "admin") Then
            If selectedEmpAttendance = "PRESENT" Then
                Dim UpdateTimeIn As New OleDbCommand("UPDATE Employees SET [time-in]=@time WHERE EmployeeID=@id AND WorkDate=@date", conn)
                UpdateTimeIn.Parameters.AddWithValue("@time", timePicker.Value.ToString("H:mm"))
                UpdateTimeIn.Parameters.AddWithValue("@id", selectedEmpID)
                UpdateTimeIn.Parameters.AddWithValue("@date", selectedDate)
                conn.Open()
                UpdateTimeIn.ExecuteNonQuery()
                conn.Close()
                DataGridView1.DataSource = GetTable(selectedDate)
                DataGridView1.ClearSelection()
            End If
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If (cookie.GetUserStatus() = "disabled" And cookie.GetUserType() = "user") Then
            MessageBox.Show("You have no permission to modify Records.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ElseIf (cookie.GetUserStatus() = "enabled" Or cookie.GetUserType() = "admin") Then
            If selectedEmpAttendance = "PRESENT" Then
                Dim UpdateTimeOut As New OleDbCommand("UPDATE Employees SET [time-out]=@time WHERE EmployeeID=@id AND WorkDate=@date", conn)
                UpdateTimeOut.Parameters.AddWithValue("@time", timePicker.Value.ToString("H:mm"))
                UpdateTimeOut.Parameters.AddWithValue("@id", selectedEmpID)
                UpdateTimeOut.Parameters.AddWithValue("@date", selectedDate)
                conn.Open()
                UpdateTimeOut.ExecuteNonQuery()
                conn.Close()
                DataGridView1.DataSource = GetTable(selectedDate)
                DataGridView1.ClearSelection()
            End If
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim latestLogType
        Dim latestLogDate = Nothing
        Try
            Using getLatestEmpStatus As New OleDbCommand("SELECT TOP 1 * FROM EmployeeLogs WHERE EmployeeID=@id AND LogDate=@date < @today ORDER BY LogDate DESC", conn)
                getLatestEmpStatus.Parameters.AddWithValue("@id", selectedEmpID)
                Dim dateFix As DateTime = "1/1/2022"
                getLatestEmpStatus.Parameters.AddWithValue("@date", dateFix)
                getLatestEmpStatus.Parameters.AddWithValue("@today", dateToday)
                conn.Open()
                Dim fetchEmpStatus As OleDbDataReader = getLatestEmpStatus.ExecuteReader()
                If fetchEmpStatus.Read = True Then
                    latestLogType = fetchEmpStatus("Type")
                    latestLogDate = fetchEmpStatus("LogDate")
                End If
                conn.Close()
            End Using
        Catch ex As Exception

        End Try

        'Dim getLatestStatus As New OleDbCommand("SELECT TOP 1 * FROM EmployeeLogs WHERE EmployeeID=@id AND LogDate=@date > @today ORDER BY LogDate ASC", conn)
        'getLatestStatus.Parameters.AddWithValue("@id", selectedEmpID)
        'getLatestStatus.Parameters.AddWithValue("@date", selectedDate)
        'getLatestStatus.Parameters.AddWithValue("@today", dateToday)
        'conn.Open()
        'Dim readResults As OleDbDataReader = getLatestStatus.ExecuteReader()
        'If readResults.Read = True Then
        '    MsgBox(readResults("EmployeeID") & " " & readResults("LogDate"))
        'End If
        'conn.Close()
        If (cookie.GetUserStatus() = "disabled" And cookie.GetUserType() = "user") Then
            MessageBox.Show("You have no permission to modify Records.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ElseIf (cookie.GetUserStatus() = "enabled" Or cookie.GetUserType() = "admin") Then

            If selectedDate >= latestLogDate Then
                If selectedEmpStatus = "Employed" Then
                    Dim InsertEmpStatus As New OleDbCommand("INSERT INTO EmployeeLogs(Type, Logdate, EmployeeID) VALUES(@type, @date, @id)", conn)
                    InsertEmpStatus.Parameters.AddWithValue("@type", "terminated")
                    InsertEmpStatus.Parameters.AddWithValue("@date", selectedDate)
                    InsertEmpStatus.Parameters.AddWithValue("@id", selectedEmpID)

                    Dim UpdateEmployeeStatus As New OleDbCommand("UPDATE EmployeeRoster SET EmpStatus=@status WHERE EmployeeID=@id", conn)
                    UpdateEmployeeStatus.Parameters.AddWithValue("@status", "Terminated")
                    UpdateEmployeeStatus.Parameters.AddWithValue("@id", selectedEmpID)

                    conn.Open()
                    InsertEmpStatus.ExecuteNonQuery()
                    UpdateEmployeeStatus.ExecuteNonQuery()
                    conn.Close()

                    DataGridView1.DataSource = GetTable(selectedDate)
                    DataGridView1.ClearSelection()
                ElseIf selectedEmpStatus = "Terminated" Then
                    Dim InsertEmpStatus As New OleDbCommand("INSERT INTO EmployeeLogs(Type, Logdate, EmployeeID) VALUES(@type, @date, @id)", conn)
                    InsertEmpStatus.Parameters.AddWithValue("@type", "employed")
                    InsertEmpStatus.Parameters.AddWithValue("@date", selectedDate)
                    InsertEmpStatus.Parameters.AddWithValue("@id", selectedEmpID)

                    Dim UpdateEmployeeStatus As New OleDbCommand("UPDATE EmployeeRoster SET EmpStatus=@status WHERE EmployeeID=@id", conn)
                    UpdateEmployeeStatus.Parameters.AddWithValue("@status", "Employed")
                    UpdateEmployeeStatus.Parameters.AddWithValue("@id", selectedEmpID)

                    conn.Open()
                    InsertEmpStatus.ExecuteNonQuery()
                    UpdateEmployeeStatus.ExecuteNonQuery()
                    conn.Close()

                    DataGridView1.DataSource = GetTable(selectedDate)
                    DataGridView1.ClearSelection()
                ElseIf selectedEmpStatus = "Not Set" Then
                    Dim InsertEmpStatus As New OleDbCommand("INSERT INTO EmployeeLogs(Type, Logdate, EmployeeID) VALUES(@type, @date, @id)", conn)
                    InsertEmpStatus.Parameters.AddWithValue("@type", "employed")
                    InsertEmpStatus.Parameters.AddWithValue("@date", selectedDate)
                    InsertEmpStatus.Parameters.AddWithValue("@id", selectedEmpID)

                    Dim UpdateEmployeeStatus As New OleDbCommand("UPDATE EmployeeRoster SET EmpStatus=@status WHERE EmployeeID=@id", conn)
                    UpdateEmployeeStatus.Parameters.AddWithValue("@status", "Employed")
                    UpdateEmployeeStatus.Parameters.AddWithValue("@id", selectedEmpID)
                    conn.Open()
                    InsertEmpStatus.ExecuteNonQuery()
                    UpdateEmployeeStatus.ExecuteNonQuery()
                    conn.Close()
                    DataGridView1.DataSource = GetTable(selectedDate)
                    DataGridView1.ClearSelection()
                End If
                Employee.DataGridView1.DataSource = Employee.GetEmployeesList()
            End If
        End If
    End Sub

    Private Sub emp_btn_Click(sender As Object, e As EventArgs) Handles emp_btn.Click
        Me.Hide()
        Employee.SetProfileInfo()
        Employee.Show()
    End Sub

    Private Sub admin_btn_Click(sender As Object, e As EventArgs) Handles admin_btn.Click
        Me.Hide()
        Admin.SetProfileInfo()
        Admin.Show()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Me.Hide()
        UserProfile.SetProfileInfo()
        UserProfile.ShowDialog()
    End Sub

    Private Sub logout_btn_Click(sender As Object, e As EventArgs) Handles logout_btn.Click

        Dim choice = MsgBox("Do you want to logout?", vbYesNo, "Confirm Logout")
        If choice = vbYes Then
            cookie.EndSession()
            admin_btn.Visible = False
            Employee.Button4.Visible = False
            UserProfile.Button3.Visible = False
            Dashboard.Button3.Visible = False
            Me.Hide()
            Login.Show()
        End If

    End Sub

End Class