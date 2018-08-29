Public Class FrmSummary
    Public Sub WhenComboChange()
     
        Try
            DataGridView1.DataSource = ClsConn.LoadData(pivotattendance).DefaultView

        Catch ex As Exception

        End Try
    End Sub
    Private Sub FrmSummary_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WhenComboChange()
    End Sub
End Class