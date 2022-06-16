Imports System.Data.OleDb

Public Class AddEmployee

    Dim ConnString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=EAM.mdb"
    Dim conn As New OleDbConnection(ConnString)
    Dim rowCount

    Private Sub AddEmployee_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Function GenerateEmployeeID()
        Dim EmployeeID = Nothing
        Try
            Dim count_rows As New OleDbCommand("SELECT COUNT(*) From [EmployeeRoster]", conn)
            conn.Open()
            rowCount = CInt(count_rows.ExecuteScalar())
            conn.Close()
            Dim IdCountLen = CType(rowCount + 1, String).Length
            If (IdCountLen.Equals(1)) Then
                EmployeeID = ("2022030" & rowCount + 1)
            ElseIf (IdCountLen > 1) Then
                EmployeeID = ("202203" & rowCount + 1)
            End If
        Catch ex As Exception

        End Try
        Return EmployeeID
    End Function

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

        If Not String.IsNullOrEmpty(TextBox1.Text) And Not String.IsNullOrEmpty(TextBox2.Text) And Not String.IsNullOrEmpty(TextBox4.Text) And Not String.IsNullOrEmpty(TextBox5.Text) And Not String.IsNullOrEmpty(TextBox6.Text) Then
            Try
                Using cmd As New OleDbCommand("INSERT INTO EmployeeRoster ([EmployeeID], [EmployeeFName], [EmployeeLName], [Department], [JobTitle], [Position], [profile_img]) VALUES (@empID, @fname, @lname, @dep, @title, @pos, @img)", conn)
                    'Profile Picture
                    Dim arrImage() As Byte
                    Dim mstream As New System.IO.MemoryStream()
                    PictureBox1.Image.Save(mstream, System.Drawing.Imaging.ImageFormat.Jpeg)
                    arrImage = mstream.GetBuffer()
                    Dim FileSize As UInt32
                    FileSize = mstream.Length
                    mstream.Close()

                    cmd.Parameters.AddWithValue("@empID", GenerateEmployeeID())
                    cmd.Parameters.AddWithValue("@fname", TextBox1.Text)
                    cmd.Parameters.AddWithValue("@lname", TextBox2.Text)
                    cmd.Parameters.AddWithValue("@dep", TextBox4.Text)
                    cmd.Parameters.AddWithValue("@title", TextBox5.Text)
                    cmd.Parameters.AddWithValue("@pos", TextBox6.Text)
                    cmd.Parameters.AddWithValue("@img", arrImage)

                    conn.Open()
                    cmd.ExecuteNonQuery()
                    MsgBox("Successfully Added")
                    conn.Close()
                    Employee.DataGridView1.DataSource = Employee.GetEmployeesList()
                    Employee.DataGridView1.ClearSelection()
                    Employee.Edit_btn.Enabled = False
                    Me.Close()
                    Employee.Show()
                    Attendance.DataGridView1.DataSource = Attendance.GetTable(Date.Today)
                End Using

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            MsgBox("Empty Field Detected", vbCritical, "Warning")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            With EmpOpenDialog
                .CheckFileExists = True
                .CheckPathExists = True
                .DefaultExt = "jpg"
                .DereferenceLinks = True
                .FileName = ""
                .Filter = "(*.jpg)|*.jpg|(*.png)|*.png|(*.jpg)|*.jpg|All files|*.*"
                .Multiselect = False
                .RestoreDirectory = True
                .Title = "Select a file to open"
                .ValidateNames = True

                If .ShowDialog = DialogResult.OK Then
                    PictureBox1.Image = Image.FromFile(EmpOpenDialog.FileName)
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, Me.Text)
        End Try
    End Sub

    Private Sub EmpOpenDialog_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles EmpOpenDialog.FileOk

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged

    End Sub
End Class