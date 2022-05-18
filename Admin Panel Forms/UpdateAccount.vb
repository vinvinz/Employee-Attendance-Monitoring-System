Imports System.Data.OleDb

Public Class UpdateAccount

    Dim ConnString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=EAM.mdb"
    Dim conn As New OleDbConnection(ConnString)
    Dim id
    Dim usn
    Dim pass
    Dim type
    Dim stat
    Dim accTypes

    Public Function SetAccountData(ByVal Eid, ByVal Eusn, ByVal Epass, ByVal Etype, ByVal Estat)
        Me.id = Eid
        Me.usn = Eusn
        Me.pass = Epass
        Me.type = Etype
        Me.stat = Estat
        Return 0
    End Function

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub UpdateAccount_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        usn_lbl.Text = usn
        pass_lbl.Text = pass
        If (type = "admin") Then
            Admin_radio.Checked = True
        ElseIf (type = "user") Then
            User_radio.Checked = True
        End If
        Status_combo.SelectedIndex = Status_combo.FindString(stat)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Using cmd As New OleDbCommand("UPDATE HR_Accounts SET [Username]=@usn, [Password]=@pass, [AccType]=@type, [AccStatus]=@stat WHERE ID=@id", conn)
            cmd.Parameters.AddWithValue("@usn", usn_lbl.Text)
            cmd.Parameters.AddWithValue("@pass", pass_lbl.Text)
            If (Admin_radio.Checked = True) Then
                accTypes = "admin"
            ElseIf (User_radio.Checked = True) Then
                accTypes = "user"
            End If
            cmd.Parameters.AddWithValue("@type", accTypes)
            cmd.Parameters.AddWithValue("@stat", Status_combo.Text.ToLower)
            cmd.Parameters.AddWithValue("@id", id)
            conn.Open()
            cmd.ExecuteNonQuery()
            MsgBox("Update Success")
            conn.Close()
            Admin.DataGridView1.DataSource = Admin.GetHRAccounts()
            Admin.DataGridView1.ClearSelection()
            Admin.Button5.Enabled = False
            Admin.Button6.Enabled = False
            Me.Close()
        End Using
    End Sub
End Class