Imports System.Data.OleDb

Public Class LoginSession

    Dim ConnString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=EAM.mdb"
    Dim conn As New OleDbConnection(ConnString)

    'GLOBAL VARIABLE FOR USAGE OF MULTIPLE FORMS
    'use Get Function to fetch values
    Public Shared UserID
    Public Shared UserType
    Public Shared UserStatus
    Public Shared Username


    'GLOBAL VARIABLES OF USER DATA
    Public Shared FullName
    Public Shared EmpID
    Public Shared EmployeeStatus
    Public Shared EmployeeStatusTag

    Public Function SetUserID(ByVal ID)
        UserID = ID
        Return 0
    End Function

    Public Function GetUserID()
        Return UserID
    End Function

    Public Function GetUsername()
        Return Username
    End Function

    Public Function GetUserType()
        Return UserType
    End Function

    Public Function GetUserStatus()
        Return UserStatus
    End Function


    Public Function GetUserFullName()
        Return FullName
    End Function

    Public Function GetEmpID()
        Return EmpID
    End Function

    Public Function GetEmpStatus()
        Return EmployeeStatus
    End Function

    Public Function GetEmpStatusTag()
        Return EmployeeStatusTag
    End Function

    Public Function GetLinkedID(ByVal IdNum)
        Dim isLinked As New OleDbCommand("SELECT EmpID FROM HR_Accounts WHERE ID=@id", conn)
        isLinked.Parameters.AddWithValue("@id", IdNum)
        conn.Open()
        Dim empID = isLinked.ExecuteScalar().ToString()
        conn.Close()
        Return empID
    End Function

    Public Function FetchUserData()
        Dim cmd As New OleDbCommand("SELECT * FROM EmployeeRoster INNER JOIN HR_Accounts ON EmployeeRoster.EmployeeID = HR_Accounts.EmpID WHERE EmployeeRoster.EmployeeID=@id", conn)
        cmd.Parameters.AddWithValue("@id", GetLinkedID(UserID))
        conn.Open()
        Try
            Dim FetchValue As OleDbDataReader = cmd.ExecuteReader()
            If (FetchValue.Read = True) Then
                FullName = FetchValue("EmployeeFName") & " " & FetchValue("EmployeeLName")
                EmpID = FetchValue("EmployeeID")
                EmployeeStatus = FetchValue("EmpStatus")
                EmployeeStatusTag = FetchValue("EmpStatusTag")
            End If
        Catch ex As Exception

        End Try
        conn.Close()
        Return Nothing
    End Function

    Public Function GetUserImage()
        If (Not (GetLinkedID(UserID) = "")) Then
            Try
                Dim cmd As New OleDbCommand("SELECT profile_img FROM EmployeeRoster INNER JOIN HR_Accounts ON EmployeeRoster.EmployeeID = HR_Accounts.EmpID WHERE EmployeeRoster.EmployeeID=@id", conn)
                cmd.Parameters.AddWithValue("@id", GetLinkedID(UserID))
                Dim stream As New IO.MemoryStream()
                conn.Open()
                Dim image As Byte() = DirectCast(cmd.ExecuteScalar(), Byte())
                stream.Write(image, 0, image.Length)
                Dim bitmap As New Bitmap(stream)
                stream.Close()
                conn.Close()
                Return bitmap
            Catch ex As Exception
                MsgBox(String.Format("Error: {0}", ex.Message))
            End Try
        End If
        Return Nothing
    End Function

    Public Function StartSession()
        Dim cmd As OleDbCommand = New OleDbCommand("SELECT * FROM HR_Accounts WHERE ID=@id", conn)
        cmd.Parameters.AddWithValue("@id", UserID)
        conn.Open()
        Dim FetchValues As OleDbDataReader = cmd.ExecuteReader()
        If (FetchValues.Read = True) Then
            Username = FetchValues("Username")
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
        Return Nothing
    End Function
End Class
