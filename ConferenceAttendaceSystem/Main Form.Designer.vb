<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main_Form
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.RegistrationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddParticipantToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ListOfParticipantsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AttendanceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.QRCodeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ByNameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SummaryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RegistrationToolStripMenuItem, Me.AttendanceToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(331, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'RegistrationToolStripMenuItem
        '
        Me.RegistrationToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddParticipantToolStripMenuItem, Me.ListOfParticipantsToolStripMenuItem})
        Me.RegistrationToolStripMenuItem.Name = "RegistrationToolStripMenuItem"
        Me.RegistrationToolStripMenuItem.Size = New System.Drawing.Size(82, 20)
        Me.RegistrationToolStripMenuItem.Text = "Registration"
        '
        'AddParticipantToolStripMenuItem
        '
        Me.AddParticipantToolStripMenuItem.Name = "AddParticipantToolStripMenuItem"
        Me.AddParticipantToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.AddParticipantToolStripMenuItem.Text = "Add Participant"
        '
        'ListOfParticipantsToolStripMenuItem
        '
        Me.ListOfParticipantsToolStripMenuItem.Name = "ListOfParticipantsToolStripMenuItem"
        Me.ListOfParticipantsToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.ListOfParticipantsToolStripMenuItem.Text = "List of Participants"
        '
        'AttendanceToolStripMenuItem
        '
        Me.AttendanceToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.QRCodeToolStripMenuItem, Me.ByNameToolStripMenuItem, Me.SummaryToolStripMenuItem})
        Me.AttendanceToolStripMenuItem.Name = "AttendanceToolStripMenuItem"
        Me.AttendanceToolStripMenuItem.Size = New System.Drawing.Size(80, 20)
        Me.AttendanceToolStripMenuItem.Text = "Attendance"
        '
        'QRCodeToolStripMenuItem
        '
        Me.QRCodeToolStripMenuItem.Name = "QRCodeToolStripMenuItem"
        Me.QRCodeToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
        Me.QRCodeToolStripMenuItem.Text = "By QR Code"
        '
        'ByNameToolStripMenuItem
        '
        Me.ByNameToolStripMenuItem.Name = "ByNameToolStripMenuItem"
        Me.ByNameToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
        Me.ByNameToolStripMenuItem.Text = "By Name"
        '
        'SummaryToolStripMenuItem
        '
        Me.SummaryToolStripMenuItem.Name = "SummaryToolStripMenuItem"
        Me.SummaryToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.SummaryToolStripMenuItem.Text = "Summary"
        '
        'Main_Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(331, 321)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Main_Form"
        Me.Text = "Main Form"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents RegistrationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddParticipantToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ListOfParticipantsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AttendanceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents QRCodeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ByNameToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SummaryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
