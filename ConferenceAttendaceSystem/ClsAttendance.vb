Imports MySql.Data.MySqlClient
Public Class ClsAttendance
    Public Property idattendance As Integer
    Public Property participantid As String
    Public Property logdatetime As String


    Public Sub save()
        If (ClsConn.OpenConnection() = True) Then
            cmd = New MySqlCommand("INSERT INTO attendance VALUES(@idattendance,@participantid, @logdatetime)", sqlCon)
            cmd.Parameters.AddWithValue("@idattendance", idattendance)
            cmd.Parameters.AddWithValue("@participantid", participantid)
            cmd.Parameters.AddWithValue("@logdatetime", logdatetime)


            cmd.ExecuteNonQuery()
            ClsConn.CloseConnection()
        End If
    End Sub

    Public Sub update()
        If (ClsConn.OpenConnection() = True) Then
            ' cmd = New MySqlCommand("UPDATE classes SET classcode=@classcode, description=@description, term=@term, year_=@year_, program=@program WHERE idclasses = @idclasses", sqlCon)
            cmd.Parameters.AddWithValue("@idattendance", idattendance)
            cmd.Parameters.AddWithValue("@participantid", participantid)
            cmd.Parameters.AddWithValue("@logdatetime", logdatetime)

            cmd.ExecuteNonQuery()
            ClsConn.CloseConnection()
        End If
    End Sub

    Public Sub delete(ByVal id As Integer)
        If (ClsConn.OpenConnection() = True) Then
            ''cmd = new mysqlcommand("delete from product where idproduct=@id", sqlcon)
            ' cmd.Parameters.AddWithValue("@idclasses", idclasses)
            cmd.ExecuteNonQuery()
            ClsConn.CloseConnection()
        End If
    End Sub
End Class
