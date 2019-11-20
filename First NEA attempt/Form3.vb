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
        module1.Main()
        Dim FirstForm As New Form1
        Dim keypress As KeyEventArgs
        FirstForm.Hero_Load()
        FirstForm.Enemy_Load()
        FirstForm.Text_Load()
        FirstForm.CreatePicBoxes()
        FirstForm.Show()
        FirstForm.Width = 1200
        FirstForm.Height = 1039
        Do
            FirstForm.Form1_KeyDown(sender, e:=keypress)
        Loop While FirstForm.Check = False Or FirstForm.Check2 = False
    End Sub

    Public Sub ExitButtonClick(ByVal sender As Object, ByVal e As EventArgs) Handles ExitButton.Click
        Close()
        Form1.Close()
        Form2.Close()
        Form4.Close()
    End Sub

End Class