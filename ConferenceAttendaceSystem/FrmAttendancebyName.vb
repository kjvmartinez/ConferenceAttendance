Public Class FrmAttendancebyName
    Private Sub FrmAttendancebyName_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim autoitem As New AutoCompleteStringCollection()
            For Each row As DataRow In ClsConn.LoadData("SELECT concat(lastname,', ',firstname) FROM conferencedb.participants").Rows
                autoitem.Add(row.ItemArray(0).ToString())
            Next

            If (txtName.Text = "") Then
                txtName.AutoCompleteMode = AutoCompleteMode.Suggest
                txtName.AutoCompleteSource = AutoCompleteSource.CustomSource
                txtName.AutoCompleteCustomSource = autoitem
            End If

        Catch ex As Exception

        End Try

        CountAttendance()
    End Sub
    Public Sub CountAttendance()
        lblam.Text = ClsConn.CountRec("SELECT COUNT(DISTINCT participantid) FROM conferencedb.attendance WHERE date(logdatetime)=date(now()) and date_format(logdatetime, '%p')='AM';").ToString()
        lblpm.Text = ClsConn.CountRec("SELECT COUNT(DISTINCT participantid) FROM conferencedb.attendance WHERE date(logdatetime)=date(now()) and date_format(logdatetime, '%p')='PM';").ToString()
    End Sub
    Private Sub txtName_Leave(sender As Object, e As EventArgs) Handles txtName.Leave
        lblParticipantid.Text = ClsConn.GetParticipantID("SELECT idparticipant FROM conferencedb.participants WHERE concat(lastname,', ',firstname)='" + txtName.Text + "'")
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim attendance As New ClsAttendance
        With attendance
            .idattendance = ClsConn.Generateid("SELECT idattendance FROM conferencedb.attendance")
            .participantid = lblParticipantid.Text.ToString()
            .logdatetime = Now.ToString("yyyy-MM-dd HH:mm:ss")
            .save()
            MsgBox("Record successfully added.", vbInformation)
        End With
        CountAttendance()
    End Sub


End Class