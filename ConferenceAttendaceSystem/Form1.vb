Imports System.IO
Imports AForge
Imports AForge.Video
Imports AForge.Video.DirectShow
Imports ZXing
Imports ZXing.Aztec
Public Class Form1
    Dim decoded As String
    Private CaptureDevice As FilterInfoCollection
    Private FinalFrame As VideoCaptureDevice

    Private Sub FinalFrame_NewFrame(ByVal sender As Object, ByVal eventArgs As NewFrameEventArgs)
        Try
            PictureBox1.Image = CType(eventArgs.Frame.Clone(), Bitmap)
        Catch ex As Exception

        End Try

    End Sub

    Public Sub ShowRegistration()
        DataGridView1.DataSource = ClsConn.LoadData("SELECT idparticipant as PARTICIPANTID, LASTNAME, FIRSTNAME, MIDDLENAME, CONTACTNO, date_format(REG_AT,'%b %d %Y %h:%i') AS `DATE REGISTERED` FROM conferencedb.participants order by reg_at desc").DefaultView
        lblcountrec.Text = lblcountrec.Text + DataGridView1.Rows.Count().ToString()


        DataGridView1.RowsDefaultCellStyle.BackColor = Color.White
        DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.PaleGoldenrod
        DataGridView1.ColumnHeadersDefaultCellStyle.WrapMode = vbFalse
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ShowRegistration()

        CaptureDevice = New FilterInfoCollection(FilterCategory.VideoInputDevice)

        For Each Device As FilterInfo In CaptureDevice
            ComboBox1.Items.Add(Device.Name)
        Next

        ComboBox1.SelectedIndex = 0
        FinalFrame = New VideoCaptureDevice()

    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        mode = Modes.add

        Timer1.Enabled = True
        Timer1.Start()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim registration As New ClsRegistration
        With registration
            .idparticipant = txtID.Text
            .lastname = txtLname.Text
            .firstname = txtFname.Text
            .middlename = txtMname.Text
            .contactno = txtContact.Text
            .reg_at = Now().ToString("yyyy-MM-dd HH:mm:ss")
            Select Case mode
                Case Modes.add
                    .save()
                    MsgBox("Record successfully added.", vbInformation)
                Case Modes.edit
                    .update()
                    MsgBox("Record successfully updated.", vbInformation)
            End Select
        End With

        ShowRegistration()
        ClearTextbox(Me)

    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If (DataGridView1.Item("idparticipant", DataGridView1.CurrentRow.Index).Value.ToString() = "") Then
            MsgBox("Choose item to edit.", vbInformation, )
        Else
            mode = Modes.edit
            txtID.Text = DataGridView1.Item("participantID", DataGridView1.CurrentRow.Index).Value.ToString()
            txtLname.Text = DataGridView1.Item("lastname", DataGridView1.CurrentRow.Index).Value.ToString()
            txtFname.Text = DataGridView1.Item("firstname", DataGridView1.CurrentRow.Index).Value.ToString()
            txtMname.Text = DataGridView1.Item("middlename", DataGridView1.CurrentRow.Index).Value.ToString()
            txtContact.Text = DataGridView1.Item("contactno", DataGridView1.CurrentRow.Index).Value.ToString()
            
        End If
    End Sub

    Private Sub txtLname_Leave(sender As Object, e As EventArgs) Handles txtLname.Leave
        txtLname.Text = StrConv(txtLname.Text, VbStrConv.ProperCase)
    End Sub

    Private Sub txtFname_Leave(sender As Object, e As EventArgs) Handles txtFname.Leave
        txtFname.Text = StrConv(txtFname.Text, VbStrConv.ProperCase)
    End Sub

    Private Sub txtMname_TextChanged(sender As Object, e As EventArgs) Handles txtMname.TextChanged
        txtMname.Text = StrConv(txtMname.Text, VbStrConv.ProperCase)
    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        FinalFrame = New VideoCaptureDevice(CaptureDevice(ComboBox1.SelectedIndex).MonikerString)
        AddHandler FinalFrame.NewFrame, AddressOf Me.FinalFrame_NewFrame
        'FinalFrame.NewFrame += New NewFrameEventHandler(AddressOf FinalFrame_NewFrame)
        FinalFrame.Start()
    End Sub

    Private Sub btnDetect_Click(sender As Object, e As EventArgs) Handles btnDetect.Click
      
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Timer1.Stop()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
     

        Try
            Dim Reader As BarcodeReader = New BarcodeReader()
            Dim result As Result = Reader.Decode(CType(PictureBox1.Image, Bitmap))
            decoded = Result.ToString().Trim()

            If decoded <> "" Then
                Timer1.[Stop]()
                txtID.Text = decoded
                MsgBox("Record successfully added.", vbInformation)
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If 1 Then
            ClearTextbox(Me)
        End If
    End Sub
End Class
