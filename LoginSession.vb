Imports System.Data.OleDb

Public Class LoginSession

    Dim ConnString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=EAM.mdb"
    Dim conn As New OleDbConnection(ConnString)

    Public Shared UserID
    Public Shared UserType
    Public Shared UserStatus

    Public Function SetUserID(ByVal ID)
        UserID = ID
        Return 0
    End Function

    Public Function GetUserID()
        Return UserID
    End Function

    Public Function GetUserType()
        Return UserType
    End Function

    Public Function GetUserStatus()
        Return UserStatus
    End Function

    Public Function StartSession()
        Dim cmd As OleDbCommand = New OleDbCommand("SELECT * FROM HR_Accounts WHERE ID=@id", conn)
        cmd.Parameters.AddWithValue("@id", UserID)
        conn.Open()
        Dim FetchValues As OleDbDataReader = cmd.ExecuteReader()
        If (FetchValues.Read = True) Then
            UserType = FetchValues("AccType")
            UserStatus = FetchValues("AccStatus")
        End If
        conn.Close()
        Return 0
    End Function

    Public Function EndSession()
        UserID = Nothing
        UserType = Nothing
        UserStatus = Nothing
        Return 0
    End Function

End Class
