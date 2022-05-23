Imports System.Data.OleDb

Public Class test

    Dim ConnString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Personal Computer\Source\Repos\Employee-Attendance-Monitoring\EAM.mdb"
    Dim con As New OleDbConnection(ConnString)
    Dim cmd As OleDbCommand
    Dim sql As String

    Private Sub test_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            With OpenFileDialog1

                'CHECK THE SELECTED FILE IF IT EXIST OTHERWISE THE DIALOG BOX WILL DISPLAY A WARNING.
                .CheckFileExists = True

                'CHECK THE SELECTED PATH IF IT EXIST OTHERWISE THE DIALOG BOX WILL DISPLAY A WARNING.
                .CheckPathExists = True

                'GET AND SET THE DEFAULT EXTENSION
                .DefaultExt = "jpg"

                'RETURN THE FILE LINKED TO THE LNK FILE
                .DereferenceLinks = True

                'SET THE FILE NAME TO EMPTY 
                .FileName = ""

                'FILTERING THE FILES
                .Filter = "(*.jpg)|*.jpg|(*.png)|*.png|(*.jpg)|*.jpg|All files|*.*"
                'SET THIS FOR ONE FILE SELECTION ONLY.
                .Multiselect = False

                'SET THIS TO PUT THE CURRENT FOLDER BACK TO WHERE IT HAS STARTED.
                .RestoreDirectory = True

                'SET THE TITLE OF THE DIALOG BOX.
                .Title = "Select a file to open"

                'ACCEPT ONLY THE VALID WIN32 FILE NAMES.
                .ValidateNames = True

                If .ShowDialog = DialogResult.OK Then
                    Try
                        PictureBox1.Image = Image.FromFile(OpenFileDialog1.FileName)
                    Catch fileException As Exception
                        Throw fileException
                    End Try
                End If

            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, Me.Text)
        End Try
    End Sub

    Private Sub saveImage(sql As String)
        Try

            Dim arrImage() As Byte
            Dim mstream As New System.IO.MemoryStream()

            'SPECIFIES THE FILE FORMAT OF THE IMAGE
            PictureBox1.Image.Save(mstream, System.Drawing.Imaging.ImageFormat.Jpeg)

            'RETURNS THE ARRAY OF UNSIGNED BYTES FROM WHICH THIS STREAM WAS CREATED
            arrImage = mstream.GetBuffer()

            'GET THE SIZE OF THE STREAM IN BYTES
            Dim FileSize As UInt32
            FileSize = mstream.Length
            'CLOSES THE CURRENT STREAM AND RELEASE ANY RESOURCES ASSOCIATED WITH THE CURRENT STREAM
            mstream.Close()

            con.Open()

            cmd = New OleDbCommand
            With cmd
                .Connection = con
                .CommandText = sql
                .Parameters.AddWithValue("@img", arrImage)
                .ExecuteNonQuery()
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        sql = "UPDATE EmployeeRoster SET profile_img=@img WHERE ID=6"
        saveImage(sql)
        MsgBox("Image has been saved in the database")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim stream As New IO.MemoryStream()
        Using dmc As New OleDbCommand("select profile_img from EmployeeRoster where ID=6", con)
            con.Open()
            Dim image As Byte() = DirectCast(dmc.ExecuteScalar(), Byte())
            stream.Write(image, 0, image.Length)
            Dim bitmap As New Bitmap(stream)
            PictureBox2.Image = bitmap '--->I have used another picturebox to display image from database.
            stream.Close()
            con.Close()
        End Using
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim cookie As New LoginSession()
        PictureBox3.Image = cookie.GetUserImage()
    End Sub
End Class