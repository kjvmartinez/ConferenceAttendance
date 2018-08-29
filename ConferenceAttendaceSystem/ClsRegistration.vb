Imports MySql.Data.MySqlClient
Public Class ClsRegistration
    Public Property idparticipant As String
    Public Property lastname As String
    Public Property firstname As String
    Public Property middlename As String
    Public Property contactno As String
    ' Public Property idgroup As Integer
    Public Property reg_at As String

    Public Sub save()
        If (ClsConn.OpenConnection() = True) Then
            cmd = New MySqlCommand("INSERT INTO participants VALUES(@idparticipant, @lastname, @firstname, @middlename, @contactno, @reg_at)", sqlCon)
            cmd.Parameters.AddWithValue("@idparticipant", idparticipant)
            cmd.Parameters.AddWithValue("@lastname", lastname)
            cmd.Parameters.AddWithValue("@firstname", firstname)
            cmd.Parameters.AddWithValue("@middlename", middlename)
            cmd.Parameters.AddWithValue("@contactno", contactno)
            '    cmd.Parameters.AddWithValue("@idgroup", idgroup)
            cmd.Parameters.AddWithValue("@reg_at", reg_at)

            cmd.ExecuteNonQuery()
            ClsConn.CloseConnection()
        End If
    End Sub

    Public Sub update()
        If (ClsConn.OpenConnection() = True) Then
            cmd = New MySqlCommand("UPDATE participants SET lastname=@lastname, firstname=@firstname, middlename=@middlename, contactno=@contactno, reg_at=@reg_at  WHERE idparticipant=@idparticipant", sqlCon)
            cmd.Parameters.AddWithValue("@idparticipant", idparticipant)
            cmd.Parameters.AddWithValue("@lastname", lastname)
            cmd.Parameters.AddWithValue("@firstname", firstname)
            cmd.Parameters.AddWithValue("@middlename", middlename)
            cmd.Parameters.AddWithValue("@contactno", contactno)
            ' cmd.Parameters.AddWithValue("@idgroup", idgroup)
            cmd.Parameters.AddWithValue("@reg_at", reg_at)


            cmd.ExecuteNonQuery()
            ClsConn.CloseConnection()
        End If
    End Sub

    Public Sub delete(ByVal id As Integer)
        If (ClsConn.OpenConnection() = True) Then
            cmd = New MySqlCommand("DELETE FROM product WHERE idproduct=@id", sqlCon)
            cmd.Parameters.AddWithValue("@idparticipant", idparticipant)
            cmd.ExecuteNonQuery()
            ClsConn.CloseConnection()
        End If
    End Sub
End Class
