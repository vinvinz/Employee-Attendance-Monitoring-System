Imports System.Data.OleDb

Public Class Profile

    Dim ConnString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=EAM.mdb"
    Dim conn As New OleDbConnection(ConnString)
    Dim userID
    Dim name
    Dim EmpStat
    Dim StatTag

    Public Function GetUserID(ByVal ID)
        Me.userID = ID
        Return 0
    End Function

    Private Sub Profile_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim cmd As New OleDbCommand("SELECT * FROM EmployeeRoster WHERE ID=@id", conn)
        cmd.Parameters.AddWithValue("@id", userID)
        conn.Open()

        Dim fetch As OleDbDataReader = cmd.ExecuteReader()
        If (fetch.Read = True) Then
            name = fetch("EmployeeFName") & " " & fetch("EmployeeLName")
            EmpStat = fetch("EmpStatus")
            StatTag = fetch("EmpStatusTag")
        End If
        conn.Close()
        Try
            name_lbl.Text = name_lbl.Text & "" & name
            empstatus_lbl.Text = empstatus_lbl.Text & "" & EmpStat
            TextBox1.Text = StatTag
        Catch ex As Exception

        End Try
        Try
            Using dmc As New OleDbCommand("select profile_img from EmployeeRoster where ID=@id", conn)

                dmc.Parameters.AddWithValue("@id", userID)
                Dim stream As New IO.MemoryStream()
                conn.Open()
                Dim image As Byte() = DirectCast(dmc.ExecuteScalar(), Byte())
                stream.Write(image, 0, image.Length)
                Dim bitmap As New Bitmap(stream)
                PictureBox1.Image = bitmap '--->I have used another picturebox to display image from database.
                stream.Close()
                conn.Close()
            End Using
        Catch ex As Exception

        End Try
    End Sub
End Class