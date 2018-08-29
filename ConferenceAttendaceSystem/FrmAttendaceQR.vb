Imports System.IO
Imports AForge
Imports AForge.Video
Imports AForge.Video.DirectShow
Imports ZXing
Imports ZXing.Aztec
Public Class FrmAttendaceQR
    Dim decoded As String
    Private CaptureDevice As FilterInfoCollection
    Private FinalFrame As VideoCaptureDevice
    Public Sub CountAttendance()
        lblam.Text = ClsConn.CountRec("SELECT COUNT(DISTINCT participantid) FROM conferencedb.attendance WHERE date(logdatetime)=date(now()) and date_format(logdatetime, '%p')='AM';").ToString()
        lblpm.Text = ClsConn.CountRec("SELECT COUNT(DISTINCT participantid) FROM conferencedb.attendance WHERE date(logdatetime)=date(now()) and date_format(logdatetime, '%p')='PM';").ToString()
    End Sub

    Private Sub FinalFrame_NewFrame(ByVal sender As Object, ByVal eventArgs As NewFrameEventArgs)
        Try
            PictureBox1.Image = CType(eventArgs.Frame.Clone(), Bitmap)
        Catch ex As Exception

        End Try

    End Sub
    Private Sub FrmAttendaceQR_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CaptureDevice = New FilterInfoCollection(FilterCategory.VideoInputDevice)

        For Each Device As FilterInfo In CaptureDevice
            ComboBox1.Items.Add(Device.Name)
        Next

        ComboBox1.SelectedIndex = 0
        FinalFrame = New VideoCaptureDevice()
        CountAttendance()

    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        FinalFrame = New VideoCaptureDevice(CaptureDevice(ComboBox1.SelectedIndex).MonikerString)
        AddHandler FinalFrame.NewFrame, AddressOf Me.FinalFrame_NewFrame

        FinalFrame.Start()
    End Sub

    Private Sub btnDetect_Click(sender As Object, e As EventArgs) Handles btnDetect.Click
        Timer1.Enabled = True
        Timer1.Start()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If FinalFrame.IsRunning = True Then
            FinalFrame.[Stop]()
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        Try
            Dim Reader As BarcodeReader = New BarcodeReader()
            Dim result As Result = Reader.Decode(CType(PictureBox1.Image, Bitmap))

            decoded = Result.ToString().Trim()

            If decoded <> "" Then
                Timer1.[Stop]()
                    Dim attendance As New ClsAttendance
                    With attendance
                    .idattendance = ClsConn.Generateid("SELECT idattendance FROM conferencedb.attendance")
                    .participantid = decoded.ToString()
                    .logdatetime = Now.ToString("yyyy-MM-dd HH:mm:ss")
                    .save()
                    MsgBox("Record successfully added.", vbInformation)
                    CountAttendance()
                End With

                Timer1.Start()
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub FrmAttendaceQR_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If FinalFrame.IsRunning = True Then
            FinalFrame.[Stop]()
        End If
    End Sub
End Class