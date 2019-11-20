Public Class Form2

    Public Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub WinMessage() Handles MyBase.Load
        Dim WinMsg As New TextBox
        WinMsg.Text = "Well done! You solved the maze. "
        WinMsg.Name = "Win Message"
        WinMsg.Location = New Point(250, 250)
        WinMsg.Size = New Size(170, 50)
        WinMsg.ReadOnly = True
        WinMsg.Visible = True
        Controls.Add(WinMsg)
    End Sub




End Class