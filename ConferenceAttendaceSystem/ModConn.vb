Imports MySql.Data.MySqlClient
Module ModConn
    'declare mo dito lahat ng variable na feeling mo need mo sa lahat ng form para accessible sya
    Public sqlCon As New MySqlConnection
    Public cmd As New MySqlCommand
    Public mode As Integer 'gagamitin to para sa kung add, edit, delete ung mode ng process mo.
    Public cnString As String = ""
    Public query As String
    Public pivotattendance As String = <![CDATA[
    SET @sql_dynamic = (
    SELECT
		    GROUP_CONCAT(DISTINCT
			    CONCAT(
				    'SUM(IF(date(a.logdatetime) = '
				    , '"', date(a.logdatetime), '"'
				    ,',1,0)) as '
				    , '"', date_format(a.logdatetime,'%b %d %Y'),  '"'
			    )
		    )
            FROM  conferencedb.attendance a
		
    );

            SET @sql = CONCAT('SELECT p.IDPARTICIPANT, p.LASTNAME, p.FIRSTNAME, p.MIDDLENAME, ', 
					    @sql_dynamic, ' FROM conferencedb.participants p, conferencedb.attendance a WHERE p.idparticipant=a.participantid GROUP BY p.idparticipant ORDER BY p.lastname'
	               );
	 
    PREPARE stmt FROM @sql;
    EXECUTE stmt;
    DEALLOCATE PREPARE stmt;
  ]]>.Value()


    'to clear textboxes in form para di isa isa
    Public Sub ClearTextbox(ByVal x As Form)
        Dim a As Control
        For Each a In x.Controls
            If TypeOf a Is TextBox Then
                a.Text = Nothing
            End If
        Next

    End Sub
    Public Enum Modes
        add = 1
        edit = 2
        view = 3
    End Enum
End Module
