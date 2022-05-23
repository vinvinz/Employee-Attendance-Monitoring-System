Public Class UploadImage
    Private Sub UploadImage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim testdia As New OpenFileDialog()
        Try
            With testdia
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

                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    Try
                        EditEmployee.PictureBox1.Image = Image.FromFile(testdia.FileName)
                    Catch fileException As Exception
                        Throw fileException
                    End Try
                End If

            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, Me.Text)
        End Try
        Me.Dispose()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub
End Class