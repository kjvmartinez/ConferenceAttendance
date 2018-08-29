Public Class Main_Form

    Private Sub AddParticipantToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddParticipantToolStripMenuItem.Click
        Form1.Show()

    End Sub

    Private Sub QRCodeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QRCodeToolStripMenuItem.Click
        FrmAttendaceQR.Show()
    End Sub

    Private Sub Main_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ByNameToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ByNameToolStripMenuItem.Click
        FrmAttendancebyName.Show()
    End Sub

    Private Sub ListOfParticipantsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListOfParticipantsToolStripMenuItem.Click
        FrmListParticipants.Show()
    End Sub

    Private Sub SummaryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SummaryToolStripMenuItem.Click
        FrmSummary.Show()
    End Sub
End Class