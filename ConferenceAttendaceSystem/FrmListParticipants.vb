Public Class FrmListParticipants
    Public Sub ShowRegistration()
        DataGridView1.DataSource = ClsConn.LoadData("SELECT idparticipant as PARTICIPANTID, LASTNAME, FIRSTNAME, MIDDLENAME, CONTACTNO, date_format(REG_AT,'%b %d %y %h:%i') AS `DATE REGISTERED` FROM conferencedb.participants order by reg_at desc").DefaultView
        lblcountrec.Text = "Records: "
        lblcountrec.Text = lblcountrec.Text + DataGridView1.Rows.Count().ToString()

        DataGridView1.RowsDefaultCellStyle.BackColor = Color.White
        DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.PaleGoldenrod
        DataGridView1.ColumnHeadersDefaultCellStyle.WrapMode = vbFalse
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub
    Private Sub FrmListParticipants_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ShowRegistration()
    End Sub


    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Dim str As String = String.Format("SELECT idparticipant as PARTICIPANTID, LASTNAME, FIRSTNAME, MIDDLENAME, CONTACTNO, date_format(REG_AT,'%b %d %y %h:%i') AS `DATE REGISTERED` FROM conferencedb.participants WHERE lastname like '%{0}%' OR firstname like '%{0}%' order by reg_at desc", txtSearch.Text)
        DataGridView1.DataSource = ClsConn.LoadData(str).DefaultView
        lblcountrec.Text = "Records: "
        lblcountrec.Text = lblcountrec.Text + DataGridView1.Rows.Count().ToString()

        DataGridView1.RowsDefaultCellStyle.BackColor = Color.White
        DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.PaleGoldenrod
        DataGridView1.ColumnHeadersDefaultCellStyle.WrapMode = vbFalse
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub
End Class