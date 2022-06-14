Imports System.Data.OleDb
Public Class Employee

    Dim ConnString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=EAM.mdb"
    Dim conn As New OleDbConnection(ConnString)
    Dim cookie = New LoginSession()

    Dim ID
    Dim EmployeeID
    Dim EmployeeFname
    Dim EmployeeLname
    Dim Status
    Dim StatusTag
    Dim EmployeeDep
    Dim EmployeeJob
    Dim EmployeePos


    Public Function GetEmployeesList() As DataTable

        Dim Dt As New DataTable

        Using cmd As New OleDbCommand("SELECT [ID], [EmployeeID], [EmployeeFName], [EmployeeLName], [EmpStatus], [EmpStatusTag], [Department], [JobTitle], [Position] FROM EmployeeRoster ORDER BY ID ASC", conn)
            conn.Open()
            Dim readList As OleDbDataReader = cmd.ExecuteReader()
            Dt.Load(readList)
            'DataGridView1.AutoResizeColumns()
            'DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            conn.Close()
        End Using
        Return Dt
    End Function

    Public Function SetProfileInfo()
        LinkLabel1.Text = cookie.GetUsername()
        PictureBox1.Image = My.Resources.download
        If (cookie.GetUserImage() IsNot Nothing) Then
            PictureBox1.Image = cookie.GetUserImage()
        End If
        Return Nothing
    End Function

    Public Function SearchEmployee() As DataTable
        Dim Test As New DataTable
        Using cmd As New OleDbCommand(
        "SELECT ID, EmployeeID, EmployeeFName, EmployeeLName, EmpStatus, EmpStatusTag, Department, JobTitle, Position FROM EmployeeRoster WHERE (
        [EmployeeFName] LIKE @searchtxt OR
        [EmployeeLName] LIKE @searchtxt OR
        [EmpStatus] LIKE @searchtxt OR
        [EmployeeID] LIKE @searchtxt OR
        [EmpStatusTag] LIKE @searchtxt)", conn)
            cmd.Parameters.AddWithValue("@searchtxt", "%" & SearchBox.Text & "%")
            conn.Open()
            Dim readList As OleDbDataReader = cmd.ExecuteReader()
            Test.Load(readList)
            'DataGridView1.AutoResizeColumns()
            'DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            conn.Close()
        End Using
        Return Test
    End Function

    Private Sub Employee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button1.FlatAppearance.BorderSize = 0
        Button2.FlatAppearance.BorderSize = 0
        Button4.FlatAppearance.BorderSize = 0
        Button6.FlatAppearance.BorderSize = 0
        Edit_btn.Enabled = False
        Delete_btn.Enabled = False
        Edit_btn.ForeColor = Color.White
        DataGridView1.DataSource = GetEmployeesList()
        DataGridView1.ClearSelection()
        With DataGridView1
            .RowHeadersVisible = False
            .Columns(0).HeaderCell.Value = "ID"
            .Columns(1).HeaderCell.Value = "Employee ID"
            .Columns(2).HeaderCell.Value = "First Name"
            .Columns(3).HeaderCell.Value = "Last Name"
            .Columns(4).HeaderCell.Value = "Status"
            .Columns(5).HeaderCell.Value = "Status Tag"
            .Columns(6).HeaderCell.Value = "Department"
            .Columns(7).HeaderCell.Value = "Job Title"
            .Columns(8).HeaderCell.Value = "Position"
        End With

        If (cookie.GetUserType() = "admin") Then
            Button4.Visible = True
        End If

        If (cookie.GetUserType() = "user") Then
            Button4.Visible = False
        End If
    End Sub

    Private Sub Add_btn_Click(sender As Object, e As EventArgs) Handles Add_btn.Click
        If (cookie.GetUserStatus() = "disabled" And cookie.GetUserType() = "user") Then
            MessageBox.Show("You have no permission to add Data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ElseIf (cookie.GetUserStatus() = "enabled" Or cookie.GetUserType() = "admin") Then
            AddEmployee.Show()
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Edit_btn.Enabled = True
        Delete_btn.Enabled = True
        Try
            ID = DataGridView1.SelectedRows(0).Cells(0).Value.ToString()
            EmployeeID = DataGridView1.SelectedRows(0).Cells(1).Value.ToString()
            EmployeeFname = DataGridView1.SelectedRows(0).Cells(2).Value.ToString()
            EmployeeLname = DataGridView1.SelectedRows(0).Cells(3).Value.ToString()
            Status = DataGridView1.SelectedRows(0).Cells(4).Value.ToString()
            StatusTag = DataGridView1.SelectedRows(0).Cells(5).Value.ToString()
            EmployeeDep = DataGridView1.SelectedRows(0).Cells(6).Value.ToString()
            EmployeeJob = DataGridView1.SelectedRows(0).Cells(7).Value.ToString()
            EmployeePos = DataGridView1.SelectedRows(0).Cells(8).Value.ToString()
            name_lbl.Text = EmployeeFname & " " & EmployeeLname
        Catch ex As Exception

        End Try
        Try
            Using dmc As New OleDbCommand("select profile_img from EmployeeRoster where ID=@id", conn)

                dmc.Parameters.AddWithValue("@id", ID)
                Dim stream As New IO.MemoryStream()
                conn.Open()
                Dim image As Byte() = DirectCast(dmc.ExecuteScalar(), Byte())
                stream.Write(image, 0, image.Length)
                Dim bitmap As New Bitmap(stream)
                PictureBox2.Image = bitmap
                stream.Close()
                conn.Close()
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Edit_btn_Click(sender As Object, e As EventArgs) Handles Edit_btn.Click
        If (cookie.GetUserStatus() = "disabled" And cookie.GetUserType() = "user") Then
            MessageBox.Show("You have no permission to edit Data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ElseIf (cookie.GetUserStatus() = "enabled" Or cookie.GetUserType() = "admin") Then
            EditEmployee.setData(ID, EmployeeFname, EmployeeLname, Status, StatusTag, EmployeeDep, EmployeeJob, EmployeePos)
            EditEmployee.Show()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Dashboard.SetProfileInfo()
        Dashboard.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Delete_btn.Click
        If (cookie.GetUserStatus() = "disabled" And cookie.GetUserType() = "user") Then
            MessageBox.Show("You have no permission to delete Data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ElseIf (cookie.GetUserStatus() = "enabled" And cookie.GetUserType() = "admin") Then
            Dim opt = MessageBox.Show("Are you sure you want to Delete Employee with " & ID & "?", "DELETE", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
            If (opt = 1) Then
                Using cmd As New OleDbCommand("DELETE FROM EmployeeRoster WHERE ID=@id", conn)
                    cmd.Parameters.AddWithValue("@id", ID)
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    MsgBox("Delete Success")
                    conn.Close()
                    DataGridView1.DataSource = GetEmployeesList()
                    DataGridView1.ClearSelection()
                    Edit_btn.Enabled = False
                    Delete_btn.Enabled = False
                End Using
            End If
        Else
            MessageBox.Show("You have no permission to delete Data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        SearchEmployee()
        DataGridView1.DataSource = SearchEmployee()
        DataGridView1.ClearSelection()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles SearchBox.TextChanged
        If (SearchBox.Text = "") Then
            DataGridView1.DataSource = GetEmployeesList()
            DataGridView1.ClearSelection()
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Hide()
        Admin.SetProfileInfo()
        Admin.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If ID = Nothing Then
            MsgBox("Please select employee from the list.")
        Else
            Profile.GetUserID(ID)
            Profile.Show()
            Profile.GetAttendance()
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Me.Hide()
        UserProfile.SetProfileInfo()
        UserProfile.ShowDialog()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.Hide()
        Attendance.SetProfileInfo()
        Attendance.Show()
    End Sub

    Private Sub logout_btn_Click(sender As Object, e As EventArgs) Handles logout_btn.Click

        Dim choice = MsgBox("Do you want to logout?", vbYesNo, "Confirm Logout")
        If choice = vbYes Then
            cookie.EndSession()
            Attendance.admin_btn.Visible = False
            Button4.Visible = False
            UserProfile.Button3.Visible = False
            Dashboard.Button3.Visible = False
            Me.Hide()
            Login.Show()
        End If

    End Sub
End Class