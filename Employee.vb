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


    Public Function GetEmployeesList() As DataTable

        Dim Dt As New DataTable

        Using cmd As New OleDbCommand("SELECT ID, EmployeeID, EmployeeFName, EmployeeLName, EmpStatus, EmpStatusTag FROM EmployeeRoster ORDER BY ID ASC", conn)
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
        "SELECT * FROM EmployeeRoster WHERE (
        [EmployeeFName] LIKE @searchtxt OR
        [EmployeeLName] LIKE @searchtxt OR
        [EmpStatus] LIKE @searchtxt OR
        [EmployeeID] LIKE @searchtxt)", conn)
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
        End With

        If (cookie.GetUserType() = "admin") Then
            Button4.Visible = True
        End If

        If (cookie.GetUserType() = "user") Then
            Button4.Visible = False
        End If
    End Sub

    Private Sub Add_btn_Click(sender As Object, e As EventArgs) Handles Add_btn.Click
        If (cookie.GetUserStatus() = "disabled") Then
            MessageBox.Show("You have no permission to add Data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ElseIf (cookie.GetUserStatus() = "enabled") Then
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
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Edit_btn_Click(sender As Object, e As EventArgs) Handles Edit_btn.Click
        If (cookie.GetUserStatus() = "disabled") Then
            MessageBox.Show("You have no permission to edit Data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ElseIf (cookie.GetUserStatus() = "enabled") Then
            EditEmployee.setData(ID, EmployeeID, EmployeeFname, EmployeeLname, Status, StatusTag)
            EditEmployee.Show()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Dashboard.SetProfileInfo()
        Dashboard.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Delete_btn.Click
        If (cookie.GetUserStatus() = "disabled") Then
            MessageBox.Show("You have no permission to delete Data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ElseIf (cookie.GetUserStatus() = "enabled") Then
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
        UserProfile.Show()
    End Sub
End Class