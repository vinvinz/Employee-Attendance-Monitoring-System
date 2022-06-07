Imports System.Data.OleDb

Public Class Link

    Dim ConnString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=EAM.mdb"
    Dim conn As New OleDbConnection(ConnString)
    Dim contentClickFlag

    Dim TableID
    Dim EmpID
    Dim FName
    Dim LName

    Public Function SearchEmployee() As DataTable
        Dim Test As New DataTable
        Using cmd As New OleDbCommand(
        "SELECT EmployeeID, EmployeeFName, EmployeeLName FROM EmployeeRoster WHERE (
        [EmployeeFName] LIKE @searchtxt OR
        [EmployeeLName] LIKE @searchtxt OR
        [EmployeeID] LIKE @searchtxt)", conn)
            cmd.Parameters.AddWithValue("@searchtxt", "%" & TextBox1.Text & "%")
            conn.Open()
            Dim readList As OleDbDataReader = cmd.ExecuteReader()
            Test.Load(readList)
            conn.Close()
        End Using
        Return Test
    End Function

    Public Function SetTableID(ByVal ID)
        TableID = ID
        Return Nothing
    End Function

    Private Sub Link_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridView1.DataSource = GetEmployeesList()
        With DataGridView1
            .RowHeadersVisible = False
            .Columns(0).HeaderCell.Value = "Employee ID"
            .Columns(1).HeaderCell.Value = "First Name"
            .Columns(2).HeaderCell.Value = "Last Name"
        End With
        DataGridView1.ClearSelection()
    End Sub

    Public Function GetEmployeesList() As DataTable

        Dim Dt As New DataTable

        Using cmd As New OleDbCommand("SELECT EmployeeID, EmployeeFName, EmployeeLName FROM EmployeeRoster ORDER BY ID ASC", conn)
            conn.Open()
            Dim readList As OleDbDataReader = cmd.ExecuteReader()
            Dt.Load(readList)
            'DataGridView1.AutoResizeColumns()
            'DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            conn.Close()
        End Using
        Return Dt
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        DataGridView1.DataSource = SearchEmployee()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If (contentClickFlag = True) Then
            EmpID = DataGridView1.SelectedRows(0).Cells(0).Value.ToString()
            FName = DataGridView1.SelectedRows(0).Cells(1).Value.ToString()
            LName = DataGridView1.SelectedRows(0).Cells(2).Value.ToString()
            Dim choice = MessageBox.Show("Link HR Account with Employee " & "(" & EmpID & ")", "Link Account", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If (choice = MsgBoxResult.Yes) Then
                Using cmd As New OleDbCommand("UPDATE HR_Accounts SET [EmpID]=@empID WHERE ID=@id", conn)
                    'MsgBox("EMPID" & EmpID & " " & TableID)
                    cmd.Parameters.AddWithValue("@empID", EmpID)
                    cmd.Parameters.AddWithValue("@id", TableID)
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    conn.Close()
                End Using
                MessageBox.Show("Successfully Linked Account with Employee Data.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Admin.DataGridView1.DataSource = Admin.GetHRAccounts()
                Admin.DataGridView1.ClearSelection()
                Admin.Button5.Enabled = False
                Admin.Button6.Enabled = False
                Admin.Button7.Enabled = False
                Me.Close()
            End If
        Else
                MessageBox.Show("Click Employee from the list before proceeding.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        contentClickFlag = True
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Admin.Button5.Enabled = False
        Admin.Button6.Enabled = False
        Admin.Button7.Enabled = False
        Admin.DataGridView1.ClearSelection()
        Me.Close()
    End Sub
End Class