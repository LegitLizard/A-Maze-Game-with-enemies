Public Class Form4
    Public WithEvents MenuButton As New Button

    Public Sub CreateLoseForm() Handles MyBase.Load

        Dim LoseMsg As New TextBox With {
            .Text = "Too bad. Better luck next time.",
            .Name = "Lose Message",
            .Location = New Point(50, 250),
            .Size = New Size(300, 100),
            .Font = New Font("Times New Roman", 18, FontStyle.Regular),
            .ReadOnly = True,
            .Visible = True,
            .BorderStyle = BorderStyle.None,
            .BackColor = Color.Red
        }
        MenuButton.Size = New Size(200, 100)
        MenuButton.Font = New Font("Times New Roman", 16, FontStyle.Bold)
        MenuButton.Text = "Main Menu"
        MenuButton.Name = "Menu Button"
        MenuButton.Visible = True
        MenuButton.Location = New Point(150, 100)
        Controls.Add(MenuButton)
        Controls.Add(LoseMsg)
    End Sub

    Private Sub MenuClick(ByVal sender As Object, ByVal e As EventArgs) Handles MenuButton.Click
        Form3.BackColor = Color.Orange
        Form3.Visible = True
        module1.HideLose()
    End Sub
End Class