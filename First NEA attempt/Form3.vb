Public Class Form3
    Public WithEvents PlayButton As New Button
    Public WithEvents ExitButton As New Button

    Public Sub CreateMainMenu() Handles MyBase.Load

        PlayButton.Size = New Size(200, 100)
        PlayButton.Font = New Font("Times New Roman", 16, FontStyle.Bold)
        PlayButton.Text = "Play"
        PlayButton.Name = "Play Button"
        PlayButton.Visible = True
        PlayButton.Location = New Point(150, 100)
        PlayButton.BackColor = Color.Orange
        Controls.Add(PlayButton)
        ExitButton.Size = New Size(200, 100)
        ExitButton.Font = New Font("Times New Roman", 16, FontStyle.Bold)
        ExitButton.Text = "Exit"
        ExitButton.Name = "Exit Button"
        ExitButton.Visible = True
        ExitButton.BackColor = Color.Orange
        ExitButton.Location = New Point(150, 300)
        Controls.Add(ExitButton)
    End Sub

    Public Sub PlayButtonClick(ByVal sender As Object, ByVal e As EventArgs) Handles PlayButton.Click
        FrontierX.Clear()
        FrontierY.Clear()
        FrontierCount = 0
        Form1.Used = False
        NodeQueueX.Clear()
        NodeQueueY.Clear()
        VisitedNodesX.Clear()
        VisitedNodesY.Clear()
        RouteX.Clear()
        RouteY.Clear()
        count = 0
        Main()
        Form1.Width = 1200
        Form1.Height = 1039
        Form1.Update()
        Form1.StartPosition = 1
        Form1.Show()
        HideMenu()
    End Sub

    Public Sub ExitButtonClick(ByVal sender As Object, ByVal e As EventArgs) Handles ExitButton.Click
        Close()
        Form1.Close()
        Form2.Close()
        Form4.Close()
    End Sub

End Class
