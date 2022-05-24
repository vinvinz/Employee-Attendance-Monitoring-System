Imports System.Data.OleDb
Imports System.IO

Public Class EditEmployee
    Dim ConnString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=EAM.mdb"
    Dim conn As New OleDbConnection(ConnString)
    Dim Id
    Dim empID
    Dim empFname
    Dim empLname
    Dim empStatus
    Dim empStatusTag

    Dim arrImage() As Byte

    Dim imgChangedFlag = 0

    Public Function setData(ByVal ID, ByVal EmpID, ByVal EmpFname, ByVal EmpLname, ByVal EmpStatus, ByVal EmpStatusTag)
        Me.Id = ID
        Me.empID = EmpID
        Me.empFname = EmpFname
        Me.empLname = EmpLname
        Me.empStatus = EmpStatus
        Me.empStatusTag = EmpStatusTag
        Return 0
    End Function

    Public Function FetchEmployeeImage()
        Dim cmd As New OleDbCommand("SELECT profile_img FROM EmployeeRoster WHERE ID=@id", conn)
        cmd.Parameters.AddWithValue("@id", Id)
        Dim stream As New IO.MemoryStream()
        conn.Open()
        Dim image As Byte() = DirectCast(cmd.ExecuteScalar(), Byte())
        stream.Write(image, 0, image.Length)
        Dim bitmap As New Bitmap(stream)
        stream.Close()
        conn.Close()
        Return bitmap
    End Function

    Public Function SaveEmployeeImage()
        Dim cmd As New OleDbCommand("SELECT profile_img FROM EmployeeRoster WHERE ID=@id", conn)
        cmd.Parameters.AddWithValue("@id", Id)
        conn.Open()
        Dim image As Byte() = DirectCast(cmd.ExecuteScalar(), Byte())
        conn.Close()
        Return image
    End Function

    Private Sub EditEmployee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            TextBox4.Text = empID
            TextBox1.Text = empFname
            TextBox2.Text = empLname
            ComboBox2.SelectedIndex = ComboBox2.FindString(empStatus)
            TextBox3.Text = empStatusTag
            PictureBox1.Image = FetchEmployeeImage()
        Catch ex As Exception

        End Try
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
        If (imgChangedFlag = 0) Then
            arrImage = SaveEmployeeImage()
        End If

        If Not String.IsNullOrEmpty(TextBox1.Text) And Not String.IsNullOrEmpty(TextBox2.Text) And Not String.IsNullOrEmpty(ComboBox2.Text) Then
            Using cmd As New OleDbCommand("UPDATE EmployeeRoster SET EmployeeID=@empId, EmployeeFName=@fname, EmployeeLName=@lname, EmpStatus=@status, EmpStatusTag=@tag, profile_img=@img WHERE ID=@Id", conn)
                cmd.Parameters.AddWithValue("@empId", TextBox4.Text)
                cmd.Parameters.AddWithValue("@fname", TextBox1.Text)
                cmd.Parameters.AddWithValue("@lname", TextBox2.Text)
                cmd.Parameters.AddWithValue("@status", ComboBox2.Text)
                cmd.Parameters.AddWithValue("@tag", TextBox3.Text)
                cmd.Parameters.AddWithValue("@img", arrImage)
                cmd.Parameters.AddWithValue("@Id", Id)
                conn.Open()
                cmd.ExecuteNonQuery()
                MsgBox("Successfully Updated")
                conn.Close()
                Employee.DataGridView1.DataSource = Employee.GetEmployeesList()
                Employee.DataGridView1.ClearSelection()
                Employee.Edit_btn.Enabled = False
                Employee.Delete_btn.Enabled = False
                Employee.Show()
                Me.Close()
            End Using
        Else
            MsgBox("Empty Field Detected", vbCritical, "Warning")
        End If
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            With OpenFileDialog1
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
                    Try
                        PictureBox1.Image = Image.FromFile(OpenFileDialog1.FileName)
                        Dim mstream As New System.IO.MemoryStream()
                        PictureBox1.Image.Save(mstream, System.Drawing.Imaging.ImageFormat.Jpeg)
                        arrImage = mstream.GetBuffer()
                        Dim FileSize As UInt32
                        FileSize = mstream.Length
                        mstream.Close()
                        imgChangedFlag = 1
                    Catch fileException As Exception
                        Throw fileException
                    End Try
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, Me.Text)
        End Try
    End Sub

End Class