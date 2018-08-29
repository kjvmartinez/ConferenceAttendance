Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports System.Data.DbType
Public Class ClsConn
    Public Shared Sub Initialize()
        Dim server As String = "localhost"
        Dim database As String = "conferencedb" 'name ng database mo
        Dim username As String = "root"
        Dim passowrd As String = "admin" 'password ng database mo
        cnString = String.Format("server={0};port=3306;username={1};password={2};database={3};Allow User Variables=true", server, username, passowrd, database)
        sqlCon = New MySqlConnection(cnString)
    End Sub
    Public Shared Function OpenConnection() As Boolean
        Initialize()
        Try
            sqlCon.Open()
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        End Try
    End Function

    Public Shared Function CloseConnection() As Boolean
        Try
            sqlCon.Close()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    'gamitin pag populate ng data sa datagridview
    Public Shared Function LoadData(ByVal str As String) As DataTable
        OpenConnection()
        Dim query As String = str
        Dim table = New DataTable
        Dim da = New MySqlDataAdapter()
        Dim cmd = New MySqlCommand(query, sqlCon)
        da.SelectCommand = cmd
        da.Fill(table)

        CloseConnection()
        Return table
    End Function

    'gamitin pag count ng rows ng query, pero kung galing sa dtgv pde na ung datagridview1.rows.count
    Public Shared Function CountRec(ByVal str As String) As Integer
        OpenConnection()
        Dim query As String = str
        Dim da = New MySqlDataAdapter()
        Dim cmd = New MySqlCommand(query, sqlCon)
        da.SelectCommand = cmd
        Dim id As Integer = CInt(cmd.ExecuteScalar)

        CloseConnection()
        Return id
    End Function
    'gagamitin pag kukunin id usually sa FK
    Public Shared Function GetId(ByVal query As String) As Integer
        OpenConnection()
        Dim q As String = query
        Dim da = New MySqlDataAdapter()
        Dim cmd = New MySqlCommand(query, sqlCon)
        da.SelectCommand = cmd
        Dim id As Integer = CInt(cmd.ExecuteScalar)
        CloseConnection()
        Return id
    End Function

    'gamitin para autoincrement ung id, you can set it naman sa db pero pag may nabura na tau di na un mapapalitan ng AI lang sa db.
    Public Shared Function Generateid(ByVal query As String) As Integer
        OpenConnection()
        Dim list As New List(Of Integer)
        Dim genid As Integer = 0
        Dim cmd = New MySqlCommand(query, sqlCon)
        cmd = New MySqlCommand(query, sqlCon)
        Dim reader As MySqlDataReader = cmd.ExecuteReader()

        While reader.Read()
            list.Add(reader(0))
        End While

        Dim squares As IEnumerable(Of Integer) = Enumerable.Range(1, list.Count + 1).Except(list)

        Dim missing As Integer
        For Each missing In squares
            genid = missing
            Exit For
        Next

        Return genid

        CloseConnection()
    End Function
    Public Shared Function GetParticipantID(ByVal query As String) As String
        OpenConnection()
        Dim q As String = query
        Dim da = New MySqlDataAdapter()
        Dim cmd = New MySqlCommand(query, sqlCon)
        da.SelectCommand = cmd
        Dim id As String = CStr(cmd.ExecuteScalar)
        CloseConnection()
        Return id
    End Function


End Class
