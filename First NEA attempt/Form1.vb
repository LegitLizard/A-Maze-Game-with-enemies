Imports System.Collections
Public Class Form1
    Public WithEvents HeroImage As New PictureBox()
    Public WithEvents EnemyImage1 As New PictureBox()
    Public WithEvents EnemyImage2 As New PictureBox()
    Public WithEvents EnemyImage3 As New PictureBox()
    Public HeroX As Integer = 0
    Public HeroY As Integer = 0
    Public Enemy1X As Integer
    Public Enemy1Y As Integer
    Public Enemy2X As Integer
    Public Enemy2Y As Integer
    Public Enemy3X As Integer
    Public Enemy3Y As Integer
    Public test As Integer

    Public Function Hero_Load() Handles MyBase.Load
        HeroImage.Name = "Hero Image"
        HeroImage.Location = New Point(0, 0)
        HeroImage.Size = New Size(50, 50)
        HeroImage.BorderStyle = BorderStyle.None
        HeroImage.Dock = DockStyle.None
        HeroImage.Load("https://i.imgur.com/cijLVFS.jpg")
        HeroImage.SizeMode = PictureBoxSizeMode.StretchImage
        HeroImage.Visible = True
        HeroImage.BringToFront()
        Controls.Add(HeroImage)
    End Function
    Public Random As New Random

    Public Function Enemy_Load() Handles MyBase.Load
        Dim RandomX As Integer
        Dim RandomY As Integer
        EnemyImage1.Name = "Enemy Image 1"
        EnemyImage2.Name = "Enemy Image 2"
        EnemyImage3.Name = "Enemy Image 3"
        EnemyImage1.Size = New Size(50, 50)
        EnemyImage2.Size = New Size(50, 50)
        EnemyImage3.Size = New Size(50, 50)
        EnemyImage1.BorderStyle = BorderStyle.None
        EnemyImage2.BorderStyle = BorderStyle.None
        EnemyImage3.BorderStyle = BorderStyle.None
        EnemyImage1.SizeMode = PictureBoxSizeMode.StretchImage
        EnemyImage2.SizeMode = PictureBoxSizeMode.StretchImage
        EnemyImage3.SizeMode = PictureBoxSizeMode.StretchImage
        EnemyImage1.BringToFront()
        EnemyImage2.BringToFront()
        EnemyImage3.BringToFront()
        EnemyImage1.Visible = True
        EnemyImage2.Visible = True
        EnemyImage3.Visible = True
        EnemyImage1.Load("https://i.imgur.com/rb1lxvG.jpg")
        EnemyImage2.Load("https://i.imgur.com/rb1lxvG.jpg")
        EnemyImage3.Load("https://i.imgur.com/rb1lxvG.jpg")
        EnemyImage1.BorderStyle = DockStyle.None
        EnemyImage2.BorderStyle = DockStyle.None
        EnemyImage3.BorderStyle = DockStyle.None

        Do
            RandomX = Random.Next(10, 19)     'Quad 1: X = 500 to 950   Y = 0 to 450
            RandomX = RandomX * 50
            RandomY = Random.Next(0, 9)
            RandomY = RandomY * 50
            Enemy1X = RandomX
            Enemy1Y = RandomY
        Loop While Maze(RandomX, RandomY) = False
        EnemyImage1.Location = New Point(RandomX, RandomY)

        Do
            RandomX = Random.Next(0, 9)      'Quad 2: X = 0 to 450   Y = 500 to 950
            RandomX = RandomX * 50
            RandomY = Random.Next(10, 19)
            RandomY = RandomY * 50
            Enemy2X = RandomX
            Enemy2Y = RandomY
        Loop While Maze(RandomX, RandomY) = False
        EnemyImage2.Location = New Point(RandomX, RandomY)
        Do
            RandomX = Random.Next(10, 19)     'Quad 3: X = 500 to 950    Y = 500 to 950
            RandomX = RandomX * 50
            RandomY = Random.Next(10, 19)
            RandomY = RandomY * 50
            Enemy3X = RandomX
            Enemy3Y = RandomY
        Loop While Maze(RandomX, RandomY) = False
        EnemyImage3.Location = New Point(RandomX, RandomY)
        Controls.Add(EnemyImage1)
        Controls.Add(EnemyImage2)
        Controls.Add(EnemyImage3)
    End Function

    Public Function Text_Load() Handles MyBase.Load
        Dim Info As New TextBox
        Info.Name = "Info Button"
        Info.Text = "Press x to solve the maze"
        Info.Location = New Point(1020, 500)
        Info.Size = New Size(150, 50)
        Info.ReadOnly = True
        Controls.Add(Info)
    End Function

    Public Sub Form1_PicBox(sender As Object, e As EventArgs) Handles MyBase.Load
        KeyPreview = True
    End Sub

    Public Sub Form1_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown

        If HeroX = 0 And HeroY = 0 Then                       'Top left corner
            If e.KeyCode = Keys.Down And Maze(HeroX, HeroY + 50) = True Then
                HeroImage.Top += 50      'Down
                HeroY += 50
                EnemyMove()
            End If
            If e.KeyCode = Keys.Right And Maze(HeroX + 50, HeroY) = True Then
                HeroImage.Left += 50        'Right
                HeroX += 50
                EnemyMove()
            End If

        ElseIf HeroX = 0 And HeroY = 950 Then                 'Bottom left corner
            If e.KeyCode = Keys.Up And Maze(HeroX, HeroY - 50) = True And HeroY >= 50 Then
                HeroImage.Top -= 50       'Up
                HeroY -= 50
                EnemyMove()
            End If
            If e.KeyCode = Keys.Right And Maze(HeroX + 50, HeroY) = True Then
                HeroImage.Left += 50        'Right
                HeroX += 50
                EnemyMove()
            End If

        ElseIf HeroX = 950 And HeroY = 0 Then                 'Top right corner
            If e.KeyCode = Keys.Down And Maze(HeroX, HeroY + 50) = True Then
                HeroImage.Top += 50      'Down
                HeroY += 50
                EnemyMove()
            End If
            If e.KeyCode = Keys.Left And Maze(HeroX - 50, HeroY) = True Then
                HeroImage.Left -= 50        'Left
                HeroX -= 50
                EnemyMove()
            End If

        ElseIf HeroX = 950 And HeroY = 950 Then               'Bottom right corner
            If e.KeyCode = Keys.Up And Maze(HeroX, HeroY - 50) = True And HeroY >= 50 Then
                HeroImage.Top -= 50       'Up
                HeroY -= 50
                EnemyMove()
            End If
            If e.KeyCode = Keys.Left And Maze(HeroX - 50, HeroY) = True Then
                HeroImage.Left -= 50        'Left
                HeroX -= 50
                EnemyMove()
            End If

        ElseIf 49 < HeroX And HeroX < 901 And HeroY = 0 Then            'Top row
            If e.KeyCode = Keys.Down And Maze(HeroX, HeroY + 50) = True Then
                HeroImage.Top += 50      'Down
                HeroY += 50
                EnemyMove()
            End If
            If e.KeyCode = Keys.Left And Maze(HeroX - 50, HeroY) = True Then
                HeroImage.Left -= 50        'Left
                HeroX -= 50
                EnemyMove()
            End If
            If e.KeyCode = Keys.Right And Maze(HeroX + 50, HeroY) = True Then
                HeroImage.Left += 50        'Right
                HeroX += 50
                EnemyMove()
            End If

        ElseIf 49 < HeroX And HeroX < 901 And HeroY = 950 Then         'Bottom row
            If e.KeyCode = Keys.Up And Maze(HeroX, HeroY - 50) = True And HeroY >= 50 Then
                HeroImage.Top -= 50       'Up
                HeroY -= 50
                EnemyMove()
            End If
            If e.KeyCode = Keys.Left And Maze(HeroX - 50, HeroY) = True Then
                HeroImage.Left -= 50        'Left
                HeroX -= 50
                EnemyMove()
            End If
            If e.KeyCode = Keys.Right And Maze(HeroX + 50, HeroY) = True Then
                HeroImage.Left += 50        'Right
                HeroX += 50
                EnemyMove()
            End If

        ElseIf HeroX = 0 And 49 < HeroY And HeroY < 901 Then         'Left row
            If e.KeyCode = Keys.Up And Maze(HeroX, HeroY - 50) = True And HeroY >= 50 Then
                HeroImage.Top -= 50       'Up
                HeroY -= 50
                EnemyMove()
            End If
            If e.KeyCode = Keys.Down And Maze(HeroX, HeroY + 50) = True Then
                HeroImage.Top += 50      'Down
                HeroY += 50
                EnemyMove()
            End If
            If e.KeyCode = Keys.Right And Maze(HeroX + 50, HeroY) = True Then
                HeroImage.Left += 50        'Right
                HeroX += 50
                EnemyMove()
            End If

        ElseIf HeroX = 950 And 49 < HeroY And HeroY < 901 Then         'Right row
            If e.KeyCode = Keys.Up And Maze(HeroX, HeroY - 50) = True And HeroY >= 50 Then
                HeroImage.Top -= 50       'Up
                HeroY -= 50
                EnemyMove()
            End If
            If e.KeyCode = Keys.Down And Maze(HeroX, HeroY + 50) = True Then
                HeroImage.Top += 50      'Down
                HeroY += 50
                EnemyMove()
            End If
            If e.KeyCode = Keys.Left And Maze(HeroX - 50, HeroY) = True Then
                HeroImage.Left -= 50        'Left
                HeroX -= 50
                EnemyMove()
            End If

        Else                'anywhere else in the maze
            If e.KeyCode = Keys.Up And Maze(HeroX, HeroY - 50) = True And HeroY >= 50 Then
                HeroImage.Top -= 50       'Up
                HeroY -= 50
                EnemyMove()
            End If
            If e.KeyCode = Keys.Down And Maze(HeroX, HeroY + 50) = True Then
                HeroImage.Top += 50      'Down
                HeroY += 50
                EnemyMove()
            End If
            If e.KeyCode = Keys.Left And Maze(HeroX - 50, HeroY) = True Then
                HeroImage.Left -= 50        'Left
                HeroX -= 50
                EnemyMove()
            End If
            If e.KeyCode = Keys.Right And Maze(HeroX + 50, HeroY) = True Then
                HeroImage.Left += 50        'Right
                HeroX += 50
                EnemyMove()
            End If

        End If
        CheckFinish()

        If e.KeyCode = 88 And Used = False Then
            BFS()

            For i As Integer = Me.Controls.Count - 1 To 0 Step -1
                If TypeOf Me.Controls(i) Is PictureBox Then
                    Me.Controls.RemoveAt(i)
                End If
            Next
            Enemy_Load()
            Hero_Load()
            PaintSolution()
            CreatePicBoxes()
            Used = True
        End If

    End Sub

    Public Used As Boolean = False

    Public Function PaintSolution() Handles Me.Load
        Dim i As Integer = 0

        For a = 0 To RouteX.Count - 1
            Dim newPictureBox As New PictureBox
            newPictureBox.Name = "PictureBox" & i
            newPictureBox.Location = New Point(RouteX(i), RouteY(i))
            newPictureBox.BorderStyle = BorderStyle.None
            newPictureBox.Dock = DockStyle.None
            newPictureBox.Visible = True
            newPictureBox.Size = New Size(50, 50)
            newPictureBox.BackColor = Color.Pink
            newPictureBox.BringToFront()
            newPictureBox.Show()
            Controls.Add(newPictureBox)
            i += 1
        Next

    End Function

    Public Function CheckPath(ByVal x As Integer, ByVal y As Integer)
        For i = 0 To RouteX.Count - 1
            If RouteX(i) = x And RouteY(i) = y Then
                Return True
            End If
        Next
    End Function

    Public Function CreatePicBoxes() Handles Me.Load
        Dim i As Integer = 1
        For y = 0 To 950 Step 50
            For x = 0 To 950 Step 50
                Dim newPictureBox As New PictureBox()
                newPictureBox.Name = "PictureBox" & i
                newPictureBox.Location = New Point(x, y)
                newPictureBox.Size = New Size(50, 50)
                newPictureBox.BorderStyle = BorderStyle.None
                newPictureBox.Dock = DockStyle.None
                newPictureBox.Visible = True
                newPictureBox.Show()
                If x = 950 And y = 950 Then
                    newPictureBox.BackColor = Color.Green
                ElseIf Maze(x, y) = True Then
                    newPictureBox.BackColor = Color.White    'path = white
                ElseIf Maze(x, y) = False Then
                    newPictureBox.BackColor = Color.Black    'walls = black
                End If
                Controls.Add(newPictureBox)
                i += 1
            Next
        Next
    End Function

    Public Function CheckFinish() Handles MyClass.Load

        If HeroX = 950 And HeroY = 950 Then
            module1.CloseMaze()
            Form2.BackColor = Color.GreenYellow
            Check = True
            Form2.Visible = True
        End If
    End Function

    Public Check As Boolean = False
    Public Check2 As Boolean = False

    Public Function CheckDeath()

        If HeroX = Enemy1X And HeroY = Enemy1Y Or HeroX = Enemy2X And HeroY = Enemy2Y Or HeroX = Enemy3X And HeroY = Enemy3Y Then
            module1.CloseMaze()
            Form4.BackColor = Color.Red
            Form4.Visible = True
            Check2 = True
        End If
    End Function

    Public Sub EnemyMove()
        Dim random As New Random
        Dim MoveChoice As Integer

Jump1:
        If Enemy1X = 0 And Enemy1Y = 0 Then
            MoveChoice = random.Next(2, 4)         'Lower bound is inclusive, upper bound is exclusive
        ElseIf Enemy1X = 0 And Enemy1Y = 950 Then
            MoveChoice = random.Next(1, 3)
        ElseIf Enemy1X = 950 And Enemy1Y = 0 Then
            MoveChoice = random.Next(3, 5)
        ElseIf Enemy1X = 950 And Enemy1Y = 950 Then
            Do
                MoveChoice = random.Next(1, 5)
            Loop Until MoveChoice = 1 Or MoveChoice = 4
        ElseIf 49 < Enemy1X And Enemy1X < 901 And Enemy1Y = 0 Then
            MoveChoice = random.Next(2, 5)
        ElseIf 49 < Enemy1X And Enemy1X < 901 And Enemy1Y = 950 Then
            Do
                MoveChoice = random.Next(1, 5)
            Loop Until MoveChoice = 1 Or MoveChoice = 4 Or MoveChoice = 2
        ElseIf Enemy1X = 0 And 49 < Enemy1Y And Enemy1Y < 901 Then
            MoveChoice = random.Next(1, 4)
        ElseIf Enemy1X = 950 And 49 < Enemy1Y And Enemy1Y < 901 Then
            Do
                MoveChoice = random.Next(1, 5)
            Loop Until MoveChoice = 1 Or MoveChoice = 4 Or MoveChoice = 3
        Else
            MoveChoice = random.Next(1, 5)
        End If

        If MoveChoice = 1 Then       'Move up
            If Maze(Enemy1X, Enemy1Y - 50) = True Then
                EnemyImage1.Top -= 50
                Enemy1Y -= 50
                CheckDeath()
            Else
                GoTo Jump1
            End If
        ElseIf MoveChoice = 2 Then     'Move right
            If Maze(Enemy1X + 50, Enemy1Y) = True Then
                EnemyImage1.Left += 50
                Enemy1X += 50
                CheckDeath()
            Else
                GoTo Jump1
            End If
        ElseIf MoveChoice = 3 Then      'Move down
            If Maze(Enemy1X, Enemy1Y + 50) = True Then
                EnemyImage1.Top += 50
                Enemy1Y += 50
                CheckDeath()
            Else
                GoTo Jump1
            End If
        ElseIf MoveChoice = 4 Then  'Move left
            If Maze(Enemy1X - 50, Enemy1Y) = True Then
                EnemyImage1.Left -= 50
                Enemy1X -= 50
                CheckDeath()
            Else
                GoTo Jump1
            End If
        End If

Jump2:
        If Enemy2X = 0 And Enemy2Y = 0 Then
            MoveChoice = random.Next(2, 4)         'Lower bound is inclusive, upper bound is exclusive
        ElseIf Enemy2X = 0 And Enemy2Y = 950 Then
            MoveChoice = random.Next(1, 3)
        ElseIf Enemy2X = 950 And Enemy2Y = 0 Then
            MoveChoice = random.Next(3, 5)
        ElseIf Enemy2X = 950 And Enemy2Y = 950 Then
            Do
                MoveChoice = random.Next(1, 5)
            Loop Until MoveChoice = 1 Or MoveChoice = 4
        ElseIf 49 < Enemy2X And Enemy2X < 901 And Enemy2Y = 0 Then
            MoveChoice = random.Next(2, 5)
        ElseIf 49 < Enemy2X And Enemy2X < 901 And Enemy2Y = 950 Then
            Do
                MoveChoice = random.Next(1, 5)
            Loop Until MoveChoice = 1 Or MoveChoice = 4 Or MoveChoice = 2
        ElseIf Enemy2X = 0 And 49 < Enemy2Y And Enemy2Y < 901 Then
            MoveChoice = random.Next(1, 4)
        ElseIf Enemy2X = 950 And 49 < Enemy2Y And Enemy2Y < 901 Then
            Do
                MoveChoice = random.Next(1, 5)
            Loop Until MoveChoice = 1 Or MoveChoice = 4 Or MoveChoice = 3
        Else
            MoveChoice = random.Next(1, 5)
        End If
        If MoveChoice = 1 Then       'Move up
            If Maze(Enemy2X, Enemy2Y - 50) = True Then
                EnemyImage2.Top -= 50
                Enemy2Y -= 50
                CheckDeath()
            Else
                GoTo Jump2
            End If
        ElseIf MoveChoice = 2 Then     'Move right
            If Maze(Enemy2X + 50, Enemy2Y) = True Then
                EnemyImage2.Left += 50
                Enemy2X += 50
                CheckDeath()
            Else
                GoTo Jump2
            End If
        ElseIf MoveChoice = 3 Then      'Move down
            If Maze(Enemy2X, Enemy2Y + 50) = True Then
                EnemyImage2.Top += 50
                Enemy2Y += 50
                CheckDeath()
            Else
                GoTo Jump2
            End If
        ElseIf MoveChoice = 4 Then      'Move left
            If Maze(Enemy2X - 50, Enemy2Y) = True Then
                EnemyImage2.Left -= 50
                Enemy2X -= 50
                CheckDeath()
            Else
                GoTo Jump2
            End If
        End If

Jump3:
        If Enemy3X = 0 And Enemy3Y = 0 Then
            MoveChoice = random.Next(2, 4)         'Lower bound is inclusive, upper bound is exclusive
        ElseIf Enemy3X = 0 And Enemy3Y = 950 Then
            MoveChoice = random.Next(1, 3)
        ElseIf Enemy3X = 950 And Enemy3Y = 0 Then
            MoveChoice = random.Next(3, 5)
        ElseIf Enemy3X = 950 And Enemy3Y = 950 Then
            Do
                MoveChoice = random.Next(1, 5)
            Loop Until MoveChoice = 1 Or MoveChoice = 4
        ElseIf 49 < Enemy3X And Enemy3X < 901 And Enemy3Y = 0 Then
            MoveChoice = random.Next(2, 5)
        ElseIf 49 < Enemy3X And Enemy3X < 901 And Enemy3Y = 950 Then
            Do
                MoveChoice = random.Next(1, 5)
            Loop Until MoveChoice = 1 Or MoveChoice = 4 Or MoveChoice = 2
        ElseIf Enemy3X = 0 And 49 < Enemy3Y And Enemy3Y < 901 Then
            MoveChoice = random.Next(1, 4)
        ElseIf Enemy3X = 950 And 49 < Enemy3Y And Enemy3Y < 901 Then
            Do
                MoveChoice = random.Next(1, 5)
            Loop Until MoveChoice = 1 Or MoveChoice = 4 Or MoveChoice = 3
        Else
            MoveChoice = random.Next(1, 5)
        End If
        If MoveChoice = 1 Then       'Move up
            If Maze(Enemy3X, Enemy3Y - 50) = True Then
                EnemyImage3.Top -= 50
                Enemy3Y -= 50
                CheckDeath()
            Else
                GoTo Jump3
            End If
        ElseIf MoveChoice = 2 Then     'Move right
            If Maze(Enemy3X + 50, Enemy3Y) = True Then
                EnemyImage3.Left += 50
                Enemy3X += 50
                CheckDeath()
            Else
                GoTo Jump3
            End If
        ElseIf MoveChoice = 3 Then      'Move down
            If Maze(Enemy3X, Enemy3Y + 50) = True Then
                EnemyImage3.Top += 50
                Enemy3Y += 50
                CheckDeath()
            Else
                GoTo Jump3
            End If
        ElseIf MoveChoice = 4 Then      'Move left
            If Maze(Enemy3X - 50, Enemy3Y) = True Then
                EnemyImage3.Left -= 50
                Enemy3X -= 50
                CheckDeath()
            Else
                GoTo Jump3
            End If
        End If

    End Sub


End Class

Module module1

    Public Maze(950, 950) As Boolean    'If True, path is present
    Public FrontierX As New List(Of Integer)   'All cells that are adjacent to a cell in the maze X coords
    Public FrontierY As New List(Of Integer)   'All cells that are adjacent to a cell in the maze Y coords
    Public FrontierCount As Integer = 0
    Public RandomNumber As Integer

    Sub CloseMaze()
        Form1.Close()
    End Sub

    Sub HideWin()
        Form2.Hide()
    End Sub

    Sub HideLose()
        Form4.Hide()
    End Sub

    Sub HideMenu()
        Form3.Hide()
    End Sub

    'Marks all cells as false, and then turns the paths true. Then go through, and for all squares false, put a wall.

    Sub Main()
        Randomize()

        For y = 0 To 950 Step 50
            For x = 0 To 950 Step 50
                Maze(x, y) = False
            Next
        Next

        MarkIn(0, 0)

        Do Until FrontierX.Count = 0
            RandomNumber = CInt(Int((FrontierX.Count) * Rnd()))          '.count starts at 1, the actual list starts at 0
            MarkIn(FrontierX(RandomNumber), FrontierY(RandomNumber))
            FrontierX.RemoveAt(RandomNumber)
            FrontierY.RemoveAt(RandomNumber)
        Loop

        Maze(950, 950) = True

        If Maze(900, 950) = False And Maze(850, 950) = False And Maze(900, 900) = False And Maze(950, 900) = False And Maze(950, 950) = False Then
            If Maze(950, 800) = True Then
                Maze(950, 850) = True
                Maze(950, 900) = True
            ElseIf Maze(800, 950) = True Then
                Maze(850, 950) = True
                Maze(900, 950) = True
            End If
        ElseIf Maze(950, 900) = False And Maze(900, 950) = False Then
            If Maze(850, 950) = True Then
                Maze(900, 950) = True
            ElseIf Maze(950, 850) = True Then
                Maze(950, 900) = True
            ElseIf Maze(900, 900) = True Then
                Maze(950, 900) = True
                Maze(900, 950) = True
            End If
        End If

    End Sub

    Function MarkIn(ByVal x As Integer, ByVal y As Integer)  'This function will mark a cell as in the maze, into the frontier list
        Dim check As Boolean
        check = False

        If x = 0 And y = 0 Then
            If Maze(x + 50, y) = False And Maze(x, y + 50) = False Then
                check = True
            End If
        ElseIf x = 950 And y = 0 Then
            If Maze(x - 50, y) = False And Maze(x, y + 50) = False Then
                check = True
            End If
        ElseIf x = 950 And y = 950 Then
            If Maze(x - 50, y) = False And Maze(x, y - 50) = False Then
                check = True
            End If
        ElseIf x = 0 And y = 950 Then
            If Maze(x, y - 50) = False And Maze(x + 50, y) = False Then
                check = True
            End If
        ElseIf 49 < x And x < 901 And y = 0 Then
            If Maze(x - 50, y) = False And Maze(x + 50, y) = False Then
                check = True
            ElseIf Maze(x - 50, y) = False And Maze(x, y + 50) = False Then
                check = True
            ElseIf Maze(x, y + 50) = False And Maze(x + 50, y) = False Then
                check = True
            End If
        ElseIf x = 950 And 49 < y And y < 901 Then
            If Maze(x, y - 50) = False And Maze(x - 50, y) = False Then
                check = True
            ElseIf Maze(x, y + 50) = False And Maze(x, y - 50) = False Then
                check = True
            ElseIf Maze(x - 50, y) = False And Maze(x, y + 50) = False Then
                check = True
            End If
        ElseIf 49 < x And x < 901 And y = 950 Then
            If Maze(x - 50, y) = False And Maze(x + 50, y) = False Then
                check = True
            ElseIf Maze(x, y - 50) = False And Maze(x + 50, y) = False Then
                check = True
            End If
        ElseIf x = 0 And 49 < y And y < 901 Then
            If Maze(x, y - 50) = False And Maze(x + 50, y) = False Then
                check = True
            ElseIf Maze(x, y + 50) = False And Maze(x + 50, y) = False Then
                check = True
            ElseIf Maze(x, y + 50) = False And Maze(x, y - 50) = False Then
                check = True
            End If
        Else
            If Maze(x, y - 50) = False And Maze(x + 50, y) = False And Maze(x, y + 50) = False Then
                check = True
            ElseIf Maze(x, y + 50) = False And Maze(x + 50, y) = False And Maze(x - 50, y) = False Then
                check = True
            ElseIf Maze(x, y + 50) = False And Maze(x, y - 50) = False And Maze(x - 50, y) = False Then
                check = True
            ElseIf Maze(x - 50, y) = False And Maze(x + 50, y) = False And Maze(x, y - 50) = False Then
                check = True
            End If
        End If

        If check = True Then
            Maze(x, y) = True
            MarkFrontier(x, y)
        End If

    End Function

    Function MarkFrontier(ByVal x As Integer, ByVal y As Integer)   'This function will mark the neighbours of the in cell as out, putting them in the frontier list, unless they are already processed.

        If x = 0 And y = 0 Then                       'Top left corner
            If Maze(x, y + 50) = False And Maze(x + 50, y + 50) = False And Maze(x, y + 100) = False Then
                FrontierX.Add(x)          'Down coordinate    X
                FrontierY.Add(y + 50)      'Down coordinate   Y
                FrontierCount += 1
            End If
            If Maze(x + 50, y) = False And Maze(x + 50, y + 50) = False And Maze(x + 100, y) = False Then
                FrontierX.Add(x + 50)      'Right coordinate    X
                FrontierY.Add(y)         'Right coordinate   Y
                FrontierCount += 1
            End If

        ElseIf x = 0 And y = 950 Then                 'Bottom left corner
            If Maze(x, y - 50) = False And Maze(x, y - 100) = False And Maze(x + 50, y - 50) = False Then
                FrontierX.Add(x)          'Up coordinate    X
                FrontierY.Add(y - 50)     'Up coordinate   Y
                FrontierCount += 1
            End If
            If Maze(x + 50, y) = False And Maze(x + 100, y) = False And Maze(x + 50, y - 50) = False Then
                FrontierX.Add(x + 50)      'Right coordinate  X
                FrontierY.Add(y)           'Right coordinate   Y
                FrontierCount += 1
            End If

        ElseIf x = 950 And y = 0 Then                 'Top right corner
            If Maze(x, y + 50) = False And Maze(x - 50, y + 50) = False And Maze(x, y + 100) = False Then
                FrontierX.Add(x)           'Down coordinate    X
                FrontierY.Add(y + 50)     'Down coordinate   Y
                FrontierCount += 1
            End If
            If Maze(x - 50, y) = False And Maze(x - 100, y) = False And Maze(x - 50, y + 50) = False Then
                FrontierX.Add(x - 50)    'Left coordinate    X
                FrontierY.Add(y)          'Left coordinate   Y
                FrontierCount += 1
            End If

        ElseIf x = 950 And y = 950 Then               'Bottom right corner
            If Maze(x, y - 50) = False And Maze(x, y - 100) = False And Maze(x - 50, y - 50) = False Then
                FrontierX.Add(x)        'Up coordinate    X
                FrontierY.Add(y - 50)     'Up coordinate   Y
                FrontierCount += 1
            End If
            If Maze(x - 50, y) = False And Maze(x - 50, y) = False And Maze(x - 50, y - 50) = False Then
                FrontierX.Add(x - 50)      'Left coordinate   X
                FrontierY.Add(y)         'Left coordinate   Y
                FrontierCount += 1
            End If

        ElseIf x = 0 And y = 50 Then                      'special case
            If Maze(x, y + 50) = False And Maze(x, y + 100) = False And Maze(x + 50, y + 50) = False Then
                FrontierX.Add(x)           'Down coordinate    X
                FrontierY.Add(y + 50)      'Down coordinate   Y
                FrontierCount += 1
            End If
            If Maze(x + 50, y) = False And Maze(x + 50, y - 50) = False And Maze(x + 100, y) = False And Maze(x + 50, y + 50) = False Then
                FrontierX.Add(x + 50)     'Right coordinate    X
                FrontierY.Add(y)          'Right coordinate   Y
                FrontierCount += 1
            End If
            If Maze(x, y - 50) = False And Maze(x + 50, y - 50) = False Then
                FrontierX.Add(x)             'Up coordinate   X
                FrontierY.Add(y - 50)        'Up coordinate   Y
                FrontierCount += 1
            End If

        ElseIf x = 0 And y = 900 Then           'special case
            If Maze(x, y + 50) = False And Maze(x + 50, y + 50) = False Then
                FrontierX.Add(x)           'Down coordinate    X
                FrontierY.Add(y + 50)      'Down coordinate   Y
                FrontierCount += 1
            End If
            If Maze(x + 50, y) = False And Maze(x + 50, y - 50) = False And Maze(x + 100, y) = False And Maze(x + 50, y + 50) = False Then
                FrontierX.Add(x + 50)     'Right coordinate    X
                FrontierY.Add(y)          'Right coordinate   Y
                FrontierCount += 1
            End If
            If Maze(x, y - 50) = False And Maze(x, y - 100) = False And Maze(x + 50, y - 50) = False Then
                FrontierX.Add(x)             'Up coordinate   X
                FrontierY.Add(y - 50)        'Up coordinate   Y
                FrontierCount += 1
            End If

        ElseIf x = 50 And y = 0 Then                       'special case
            If Maze(x, y + 50) = False And Maze(x - 50, y + 50) = False And Maze(x + 100, y) = False And Maze(x + 50, y + 50) = False Then
                FrontierX.Add(x)          'Down coordinate   X
                FrontierY.Add(y + 50)     'Down coordinate   Y
                FrontierCount += 1
            End If
            If Maze(x - 50, y) = False And Maze(x - 50, y + 50) = False Then
                FrontierX.Add(x - 50)         'Left coordinate X
                FrontierY.Add(y)             'Left coordinate Y
                FrontierCount += 1
            End If
            If Maze(x + 50, y) = False And Maze(x + 100, y) = False And Maze(x + 50, y + 50) = False Then
                FrontierX.Add(x + 50)      'Right coordinate  X
                FrontierY.Add(y)           'Right coordinate   Y
                FrontierCount += 1
            End If

        ElseIf x = 50 And y = 50 Then              'special case
            If Maze(x, y - 50) = False And Maze(x - 50, y - 50) = False And Maze(x + 50, y - 50) = False Then
                FrontierX.Add(x)           'Up coordinate    X
                FrontierY.Add(y - 50)    'Up coordinate   Y
                FrontierCount += 1
            End If
            If Maze(x + 50, y) = False And Maze(x + 50, y - 50) = False And Maze(x + 100, y) = False And Maze(x + 50, y + 50) = False Then
                FrontierX.Add(x + 50)      'Right coordinate  X
                FrontierY.Add(y)           'Right coordinate   Y
                FrontierCount += 1
            End If
            If Maze(x - 50, y) = False And Maze(x - 50, y - 50) = False And Maze(x - 50, y + 50) = False Then
                FrontierX.Add(x - 50)     'Left coordinate   X
                FrontierY.Add(y)          'Left coordinate   Y
                FrontierCount += 1
            End If
            If Maze(x, y + 50) = False And Maze(x - 50, y + 50) = False And Maze(x, y + 100) = False And Maze(x + 50, y + 50) = False Then
                FrontierX.Add(x)        'Down coordinate X
                FrontierY.Add(y + 50)      'Down coordinate Y
                FrontierCount += 1
            End If

        ElseIf x = 50 And 99 < y And y < 851 Then                     'special case
            If Maze(x, y - 50) = False And Maze(x - 50, y - 50) = False And Maze(x + 50, y - 50) = False And Maze(x, y - 100) = False Then
                FrontierX.Add(x)           'Up coordinate    X
                FrontierY.Add(y - 50)    'Up coordinate   Y
                FrontierCount += 1
            End If
            If Maze(x + 50, y) = False And Maze(x + 50, y - 50) = False And Maze(x + 100, y) = False And Maze(x + 50, y + 50) = False Then
                FrontierX.Add(x + 50)      'Right coordinate  X
                FrontierY.Add(y)           'Right coordinate   Y
                FrontierCount += 1
            End If
            If Maze(x - 50, y) = False And Maze(x - 50, y - 50) = False And Maze(x - 50, y + 50) = False Then
                FrontierX.Add(x - 50)     'Left coordinate   X
                FrontierY.Add(y)          'Left coordinate   Y
                FrontierCount += 1
            End If
            If Maze(x, y + 50) = False And Maze(x - 50, y + 50) = False And Maze(x, y + 100) = False And Maze(x + 50, y + 50) = False Then
                FrontierX.Add(x)        'Down coordinate X
                FrontierY.Add(y + 50)      'Down coordinate Y
                FrontierCount += 1
            End If

        ElseIf x = 50 And y = 900 Then           'special case
            If Maze(x, y - 50) = False And Maze(x - 50, y - 50) = False And Maze(x + 50, y - 50) = False And Maze(x, y - 100) = False Then
                FrontierX.Add(x)           'Up coordinate    X
                FrontierY.Add(y - 50)    'Up coordinate   Y
                FrontierCount += 1
            End If
            If Maze(x + 50, y) = False And Maze(x + 50, y - 50) = False And Maze(x + 100, y) = False And Maze(x + 50, y + 50) = False Then
                FrontierX.Add(x + 50)      'Right coordinate  X
                FrontierY.Add(y)           'Right coordinate   Y
                FrontierCount += 1
            End If
            If Maze(x - 50, y) = False And Maze(x - 50, y - 50) = False And Maze(x - 50, y + 50) = False Then
                FrontierX.Add(x - 50)     'Left coordinate   X
                FrontierY.Add(y)          'Left coordinate   Y
                FrontierCount += 1
            End If
            If Maze(x, y + 50) = False And Maze(x - 50, y + 50) = False And Maze(x + 50, y + 50) = False Then
                FrontierX.Add(x)        'Down coordinate X
                FrontierY.Add(y + 50)      'Down coordinate Y
                FrontierCount += 1
            End If

        ElseIf x = 50 And y = 950 Then          'special case
            If Maze(x, y - 50) = False And Maze(x - 50, y - 50) = False And Maze(x, y - 100) = False And Maze(x + 50, y - 50) = False Then
                FrontierX.Add(x)           'Up coordinate    X
                FrontierY.Add(y - 50)      'Up coordinate   Y
                FrontierCount += 1
            End If
            If Maze(x + 50, y) = False And Maze(x + 50, y - 50) = False And Maze(x + 100, y) = False Then
                FrontierX.Add(x + 50)      'Right coordinate  X
                FrontierY.Add(y)         'Right coordinate   Y
                FrontierCount += 1
            End If
            If Maze(x - 50, y) = False And Maze(x - 50, y - 50) = False Then
                FrontierX.Add(x - 50)      'Left coordinate   X
                FrontierY.Add(y)           'Left coordinate   Y
                FrontierCount += 1
            End If

        ElseIf 99 < x And x < 851 And y = 50 Then                 'special case
            If Maze(x, y - 50) = False And Maze(x - 50, y - 50) = False And Maze(x + 50, y - 50) = False Then
                FrontierX.Add(x)           'Up coordinate    X
                FrontierY.Add(y - 50)    'Up coordinate   Y
                FrontierCount += 1
            End If
            If Maze(x + 50, y) = False And Maze(x + 50, y - 50) = False And Maze(x + 100, y) = False And Maze(x + 50, y + 50) = False Then
                FrontierX.Add(x + 50)      'Right coordinate  X
                FrontierY.Add(y)           'Right coordinate   Y
                FrontierCount += 1
            End If
            If Maze(x - 50, y) = False And Maze(x - 50, y - 50) = False And Maze(x - 50, y + 50) = False And Maze(x - 100, y) = False Then
                FrontierX.Add(x - 50)     'Left coordinate   X
                FrontierY.Add(y)          'Left coordinate   Y
                FrontierCount += 1
            End If
            If Maze(x, y + 50) = False And Maze(x - 50, y + 50) = False And Maze(x + 50, y + 50) = False And Maze(x, y + 100) = False Then
                FrontierX.Add(x)        'Down coordinate X
                FrontierY.Add(y + 50)      'Down coordinate Y
                FrontierCount += 1
            End If

        ElseIf 99 < x And x < 851 And y = 900 Then         'special case
            If Maze(x, y - 50) = False And Maze(x - 50, y - 50) = False And Maze(x + 50, y - 50) = False And Maze(x, y - 100) = False Then
                FrontierX.Add(x)           'Up coordinate    X
                FrontierY.Add(y - 50)    'Up coordinate   Y
                FrontierCount += 1
            End If
            If Maze(x + 50, y) = False And Maze(x + 50, y - 50) = False And Maze(x + 100, y) = False And Maze(x + 50, y + 50) = False Then
                FrontierX.Add(x + 50)      'Right coordinate  X
                FrontierY.Add(y)           'Right coordinate   Y
                FrontierCount += 1
            End If
            If Maze(x - 50, y) = False And Maze(x - 50, y - 50) = False And Maze(x - 50, y + 50) = False And Maze(x - 100, y) = False Then
                FrontierX.Add(x - 50)     'Left coordinate   X
                FrontierY.Add(y)          'Left coordinate   Y
                FrontierCount += 1
            End If
            If Maze(x, y + 50) = False And Maze(x - 50, y + 50) = False And Maze(x + 50, y + 50) = False Then
                FrontierX.Add(x)        'Down coordinate X
                FrontierY.Add(y + 50)      'Down coordinate Y
                FrontierCount += 1
            End If

        ElseIf x = 900 And y = 0 Then         'special case
            If Maze(x + 50, y) = False And Maze(x + 50, y + 50) = False Then
                FrontierX.Add(x + 50)      'Right coordinate  X
                FrontierY.Add(y)           'Right coordinate   Y
                FrontierCount += 1
            End If
            If Maze(x - 50, y) = False And Maze(x - 50, y + 50) = False And Maze(x - 100, y) = False Then
                FrontierX.Add(x - 50)     'Left coordinate   X
                FrontierY.Add(y)          'Left coordinate   Y
                FrontierCount += 1
            End If
            If Maze(x, y + 50) = False And Maze(x - 50, y + 50) = False And Maze(x + 50, y + 50) = False And Maze(x, y + 100) = False Then
                FrontierX.Add(x)        'Down coordinate X
                FrontierY.Add(y + 50)      'Down coordinate Y
                FrontierCount += 1
            End If

        ElseIf x = 900 And y = 50 Then              'special case
            If Maze(x, y - 50) = False And Maze(x - 50, y - 50) = False And Maze(x + 50, y - 50) = False Then
                FrontierX.Add(x)           'Up coordinate    X
                FrontierY.Add(y - 50)    'Up coordinate   Y
                FrontierCount += 1
            End If
            If Maze(x + 50, y) = False And Maze(x + 50, y - 50) = False And Maze(x + 50, y + 50) = False Then
                FrontierX.Add(x + 50)      'Right coordinate  X
                FrontierY.Add(y)           'Right coordinate   Y
                FrontierCount += 1
            End If
            If Maze(x - 50, y) = False And Maze(x - 50, y - 50) = False And Maze(x - 50, y + 50) = False And Maze(x - 100, y) = False Then
                FrontierX.Add(x - 50)     'Left coordinate   X
                FrontierY.Add(y)          'Left coordinate   Y
                FrontierCount += 1
            End If
            If Maze(x, y + 50) = False And Maze(x - 50, y + 50) = False And Maze(x + 50, y + 50) = False And Maze(x, y + 100) = False Then
                FrontierX.Add(x)        'Down coordinate X
                FrontierY.Add(y + 50)      'Down coordinate Y
                FrontierCount += 1
            End If

        ElseIf x = 900 And 99 < y And y < 851 Then            'special case
            If Maze(x, y - 50) = False And Maze(x - 50, y - 50) = False And Maze(x + 50, y - 50) = False And Maze(x, y - 100) = False Then
                FrontierX.Add(x)           'Up coordinate    X
                FrontierY.Add(y - 50)    'Up coordinate   Y
                FrontierCount += 1
            End If
            If Maze(x + 50, y) = False And Maze(x + 50, y - 50) = False And Maze(x + 50, y + 50) = False Then
                FrontierX.Add(x + 50)      'Right coordinate  X
                FrontierY.Add(y)           'Right coordinate   Y
                FrontierCount += 1
            End If
            If Maze(x - 50, y) = False And Maze(x - 50, y - 50) = False And Maze(x - 50, y + 50) = False And Maze(x - 100, y) = False Then
                FrontierX.Add(x - 50)     'Left coordinate   X
                FrontierY.Add(y)          'Left coordinate   Y
                FrontierCount += 1
            End If
            If Maze(x, y + 50) = False And Maze(x - 50, y + 50) = False And Maze(x + 50, y + 50) = False And Maze(x, y + 100) = False Then
                FrontierX.Add(x)        'Down coordinate X
                FrontierY.Add(y + 50)      'Down coordinate Y
                FrontierCount += 1
            End If

        ElseIf x = 900 And y = 900 Then                     'special case
            If Maze(x, y - 50) = False And Maze(x - 50, y - 50) = False And Maze(x + 50, y - 50) = False And Maze(x, y - 100) = False Then
                FrontierX.Add(x)           'Up coordinate    X
                FrontierY.Add(y - 50)    'Up coordinate   Y
                FrontierCount += 1
            End If
            If Maze(x + 50, y) = False And Maze(x + 50, y - 50) = False And Maze(x + 50, y + 50) = False Then
                FrontierX.Add(x + 50)      'Right coordinate  X
                FrontierY.Add(y)           'Right coordinate   Y
                FrontierCount += 1
            End If
            If Maze(x - 50, y) = False And Maze(x - 50, y - 50) = False And Maze(x - 50, y + 50) = False And Maze(x - 100, y) = False Then
                FrontierX.Add(x - 50)     'Left coordinate   X
                FrontierY.Add(y)          'Left coordinate   Y
                FrontierCount += 1
            End If
            If Maze(x, y + 50) = False And Maze(x - 50, y + 50) = False And Maze(x + 50, y + 50) = False Then
                FrontierX.Add(x)        'Down coordinate X
                FrontierY.Add(y + 50)      'Down coordinate Y
                FrontierCount += 1
            End If

        ElseIf x = 900 And y = 950 Then                'special case
            If Maze(x, y - 50) = False And Maze(x - 50, y - 50) = False And Maze(x + 50, y - 50) = False And Maze(x, y - 100) = False Then
                FrontierX.Add(x)           'Up coordinate    X
                FrontierY.Add(y - 50)    'Up coordinate   Y
                FrontierCount += 1
            End If
            If Maze(x + 50, y) = False And Maze(x + 50, y - 50) = False Then
                FrontierX.Add(x + 50)      'Right coordinate  X
                FrontierY.Add(y)           'Right coordinate   Y
                FrontierCount += 1
            End If
            If Maze(x - 50, y) = False And Maze(x - 50, y - 50) = False And Maze(x - 100, y) = False Then
                FrontierX.Add(x - 50)     'Left coordinate   X
                FrontierY.Add(y)          'Left coordinate   Y
                FrontierCount += 1
            End If

        ElseIf x = 950 And y = 50 Then                'special case
            If Maze(x, y - 50) = False And Maze(x - 50, y - 50) = False Then
                FrontierX.Add(x)           'Up coordinate    X
                FrontierY.Add(y - 50)    'Up coordinate   Y
                FrontierCount += 1
            End If
            If Maze(x - 50, y) = False And Maze(x - 50, y - 50) = False And Maze(x - 100, y) = False And Maze(x - 50, y + 50) = False Then
                FrontierX.Add(x - 50)     'Left coordinate   X
                FrontierY.Add(y)          'Left coordinate   Y
                FrontierCount += 1
            End If
            If Maze(x, y + 50) = False And Maze(x - 50, y + 50) = False And Maze(x, y + 100) = False Then
                FrontierX.Add(x)        'Down coordinate X
                FrontierY.Add(y + 50)      'Down coordinate Y
                FrontierCount += 1
            End If

        ElseIf x = 950 And y = 900 Then             'special case
            If Maze(x, y - 50) = False And Maze(x - 50, y - 50) = False And Maze(x, y - 100) = False Then
                FrontierX.Add(x)           'Up coordinate    X
                FrontierY.Add(y - 50)    'Up coordinate   Y
                FrontierCount += 1
            End If
            If Maze(x - 50, y) = False And Maze(x - 50, y - 50) = False And Maze(x - 100, y) = False And Maze(x - 50, y + 50) = False Then
                FrontierX.Add(x - 50)     'Left coordinate   X
                FrontierY.Add(y)          'Left coordinate   Y
                FrontierCount += 1
            End If
            If Maze(x, y + 50) = False And Maze(x - 50, y + 50) = False Then
                FrontierX.Add(x)        'Down coordinate X
                FrontierY.Add(y + 50)      'Down coordinate Y
                FrontierCount += 1
            End If

        ElseIf x = 0 Then                             'If the current square is at the left border
            If Maze(x, y + 50) = False And Maze(x, y + 100) = False And Maze(x + 50, y + 50) = False Then
                FrontierX.Add(x)           'Down coordinate    X
                FrontierY.Add(y + 50)      'Down coordinate   Y
                FrontierCount += 1
            End If
            If Maze(x + 50, y) = False And Maze(x + 100, y) = False And Maze(x + 50, y - 50) = False And Maze(x + 50, y + 50) = False Then
                FrontierX.Add(x + 50)     'Right coordinate    X
                FrontierY.Add(y)          'Right coordinate   Y
                FrontierCount += 1
            End If
            If Maze(x, y - 50) = False And Maze(x, y - 100) = False And Maze(x + 50, y - 50) = False Then
                FrontierX.Add(x)             'Up coordinate   X
                FrontierY.Add(y - 50)        'Up coordinate   Y
                FrontierCount += 1
            End If

        ElseIf y = 0 Then                             'If the current square is at the top border
            If Maze(x, y + 50) = False And Maze(x, y + 100) = False And Maze(x + 50, y + 50) = False And Maze(x - 50, y + 50) = False Then
                FrontierX.Add(x)          'Down coordinate   X
                FrontierY.Add(y + 50)     'Down coordinate   Y
                FrontierCount += 1
            End If
            If Maze(x - 50, y) = False And Maze(x - 100, y) = False And Maze(x - 50, y + 50) = False Then
                FrontierX.Add(x - 50)         'Left coordinate X
                FrontierY.Add(y)             'Left coordinate Y
                FrontierCount += 1
            End If
            If Maze(x + 50, y) = False And Maze(x + 100, y) = False And Maze(x + 50, y + 50) = False Then
                FrontierX.Add(x + 50)      'Right coordinate  X
                FrontierY.Add(y)           'Right coordinate   Y
                FrontierCount += 1
            End If

        ElseIf x = 950 Then                           'If the current square is at the right border
            If Maze(x, y - 50) = False And Maze(x, y - 100) = False And Maze(x - 50, y - 50) = False Then
                FrontierX.Add(x)          'Up coordinate    X
                FrontierY.Add(y - 50)     'Up coordinate   Y
                FrontierCount += 1
            End If
            If Maze(x, y + 50) = False And Maze(x, y + 50) = False And Maze(x - 50, y + 50) = False Then
                FrontierX.Add(x)          'Down coordinate X
                FrontierY.Add(y + 50)      'Down coordinate Y
                FrontierCount += 1
            End If
            If Maze(x - 50, y) = False And Maze(x - 100, y) = False And Maze(x - 50, y - 50) = False And Maze(x - 50, y + 50) = False Then
                FrontierX.Add(x - 50)      'Left coordinate   X
                FrontierY.Add(y)          'Left coordinate   Y
                FrontierCount += 1
            End If

        ElseIf y = 950 Then                           'If the current square is at the bottom border
            If Maze(x, y - 50) = False And Maze(x, y - 100) = False And Maze(x - 50, y - 50) = False And Maze(x + 50, y - 50) = False Then
                FrontierX.Add(x)           'Up coordinate    X
                FrontierY.Add(y - 50)      'Up coordinate   Y
                FrontierCount += 1
            End If
            If Maze(x + 50, y) = False And Maze(x + 50, y - 50) = False And Maze(x + 100, y) = False Then
                FrontierX.Add(x + 50)      'Right coordinate  X
                FrontierY.Add(y)         'Right coordinate   Y
                FrontierCount += 1
            End If
            If Maze(x - 50, y) = False And Maze(x - 50, y - 50) = False And Maze(x - 100, y) = False Then
                FrontierX.Add(x - 50)      'Left coordinate   X
                FrontierY.Add(y)           'Left coordinate   Y
                FrontierCount += 1
            End If

        Else                'anywhere else in the square
            If Maze(x, y - 50) = False And Maze(x - 50, y - 50) = False And Maze(x + 50, y - 50) = False And Maze(x, y - 100) = False Then
                FrontierX.Add(x)           'Up coordinate    X
                FrontierY.Add(y - 50)    'Up coordinate   Y
                FrontierCount += 1
            End If
            If Maze(x + 50, y) = False And Maze(x + 50, y - 50) = False And Maze(x + 50, y + 50) = False And Maze(x + 100, y) = False Then
                FrontierX.Add(x + 50)      'Right coordinate  X
                FrontierY.Add(y)           'Right coordinate   Y
                FrontierCount += 1
            End If
            If Maze(x - 50, y) = False And Maze(x - 50, y - 50) = False And Maze(x - 50, y + 50) = False And Maze(x - 100, y) = False Then
                FrontierX.Add(x - 50)     'Left coordinate   X
                FrontierY.Add(y)          'Left coordinate   Y
                FrontierCount += 1
            End If
            If Maze(x, y + 50) = False And Maze(x - 50, y + 50) = False And Maze(x + 50, y + 50) = False And Maze(x, y + 100) = False Then
                FrontierX.Add(x)        'Down coordinate X
                FrontierY.Add(y + 50)      'Down coordinate Y
                FrontierCount += 1
            End If

        End If
    End Function

    Public Class Node
        Public ParentX As Integer
        Public ParentY As Integer
        Public CurrentX As Integer
        Public CurrentY As Integer
    End Class

    Public NodeQueueX As New Queue     'stores nodes to travel to  X
    Public NodeQueueY As New Queue    'stores nodes to travel to   Y
    Public VisitedNodesX As New List(Of Integer)    'stores nodes already traversed X
    Public VisitedNodesY As New List(Of Integer)    'stores nodes already traversed Y

    Public Function AddNode(ByVal x As Integer, ByVal y As Integer, ByVal pX As Integer, ByVal pY As Integer)
        Dot(count).ParentX = pX
        Dot(count).ParentY = pY
        Dot(count).CurrentX = x
        Dot(count).CurrentY = y
        count += 1
    End Function

    Public Dot(399) As Node
    Public count As Integer = 0

    Public Function BFS()

        For a = 0 To 399
            Dot(a) = New Node
        Next

        Search(0, 0)

        Do
            VisitedNodesX.Add(NodeQueueX.Peek)
            VisitedNodesY.Add(NodeQueueY.Peek)
            FindNeighbours(NodeQueueX.Dequeue(), NodeQueueY.Dequeue())
            If CheckIfFin() = True Then
                Exit Do
            End If
        Loop While NodeQueueX.Count <> 0

        Dim record As Integer

        For i = 0 To count - 1
            If Dot(i).CurrentX = 950 And Dot(i).CurrentY = 950 Then
                record = i
            End If
        Next

        Dim CurX As Integer
        Dim CurY As Integer

        CurX = Dot(record).CurrentX
        CurY = Dot(record).CurrentY

        Do
            For i = 0 To count

                If Dot(i).CurrentX = CurX And Dot(i).CurrentY = CurY Then
                    CurX = Dot(i).ParentX
                    CurY = Dot(i).ParentY
                    RouteX.Add(CurX)
                    RouteY.Add(CurY)
                    Exit For
                End If
            Next
        Loop Until CurX = 0 And CurY = 0

    End Function

    Public RouteX As New List(Of Integer)
    Public RouteY As New List(Of Integer)


    Function Search(ByVal x As Integer, ByVal y As Integer)
        VisitedNodesX.Add(x)
        VisitedNodesY.Add(y)
        FindNeighbours(x, y)
    End Function

    Function CheckIfFin()
        Dim CheckArrayX(NodeQueueX.Count) As Integer
        Dim CheckArrayY(NodeQueueY.Count) As Integer
        NodeQueueX.CopyTo(CheckArrayX, 0)
        NodeQueueY.CopyTo(CheckArrayY, 0)

        For i = 0 To NodeQueueY.Count
            If CheckArrayX(i) = 950 And CheckArrayY(i) = 950 Then
                Return True
            End If
        Next
        Return False
    End Function

    Function FindNeighbours(ByVal x As Integer, ByVal y As Integer)

        If x = 0 And y = 0 Then
            If Maze(x + 50, y) = True And IsInVisited(x + 50, y) = False Then    'Right
                NodeQueueX.Enqueue(x + 50)
                NodeQueueY.Enqueue(y)
                AddNode(x + 50, y, x, y)
            End If
            If Maze(x, y + 50) = True And IsInVisited(x, y + 50) = False Then    'Down
                NodeQueueX.Enqueue(x)
                NodeQueueY.Enqueue(y + 50)
                AddNode(x, y + 50, x, y)
            End If
        ElseIf x = 950 And y = 0 Then
            If Maze(x - 50, y) = True And IsInVisited(x - 50, y) = False Then      'Left
                NodeQueueX.Enqueue(x - 50)
                NodeQueueY.Enqueue(y)
                AddNode(x - 50, y, x, y)
            End If
            If Maze(x, y + 50) = True And IsInVisited(x, y + 50) = False Then      'Down
                NodeQueueX.Enqueue(x)
                NodeQueueY.Enqueue(y + 50)
                AddNode(x, y + 50, x, y)
            End If
        ElseIf x = 950 And y = 950 Then
            If Maze(x, y - 50) = True And IsInVisited(x, y - 50) = False Then      'Up
                NodeQueueX.Enqueue(x)
                NodeQueueY.Enqueue(y - 50)
                AddNode(x, y - 50, x, y)
            End If
            If Maze(x - 50, y) = True And IsInVisited(x - 50, y) = False Then      'Left
                NodeQueueX.Enqueue(x - 50)
                NodeQueueY.Enqueue(y)
                AddNode(x - 50, y, x, y)
            End If
        ElseIf x = 0 And y = 950 Then
            If Maze(x, y - 50) = True And IsInVisited(x, y - 50) = False Then      'Up
                NodeQueueX.Enqueue(x)
                NodeQueueY.Enqueue(y - 50)
                AddNode(x, y - 50, x, y)
            End If
            If Maze(x + 50, y) = True And IsInVisited(x + 50, y) = False Then    'Right
                NodeQueueX.Enqueue(x + 50)
                NodeQueueY.Enqueue(y)
                AddNode(x + 50, y, x, y)
            End If
        ElseIf 49 < x And x < 901 And y = 0 Then
            If Maze(x, y + 50) = True And IsInVisited(x, y + 50) = False Then      'Down
                NodeQueueX.Enqueue(x)
                NodeQueueY.Enqueue(y + 50)
                AddNode(x, y + 50, x, y)
            End If
            If Maze(x - 50, y) = True And IsInVisited(x - 50, y) = False Then      'Left
                NodeQueueX.Enqueue(x - 50)
                NodeQueueY.Enqueue(y)
                AddNode(x - 50, y, x, y)
            End If
            If Maze(x + 50, y) = True And IsInVisited(x + 50, y) = False Then    'Right
                NodeQueueX.Enqueue(x + 50)
                NodeQueueY.Enqueue(y)
                AddNode(x + 50, y, x, y)
            End If
        ElseIf x = 950 And 49 < y And y < 901 Then
            If Maze(x, y - 50) = True And IsInVisited(x, y - 50) = False Then      'Up
                NodeQueueX.Enqueue(x)
                NodeQueueY.Enqueue(y - 50)
                AddNode(x, y - 50, x, y)
            End If
            If Maze(x - 50, y) = True And IsInVisited(x - 50, y) = False Then      'Left
                NodeQueueX.Enqueue(x - 50)
                NodeQueueY.Enqueue(y)
                AddNode(x - 50, y, x, y)
            End If
            If Maze(x, y + 50) = True And IsInVisited(x, y + 50) = False Then      'Down
                NodeQueueX.Enqueue(x)
                NodeQueueY.Enqueue(y + 50)
                AddNode(x, y + 50, x, y)
            End If
        ElseIf 49 < x And x < 901 And y = 950 Then
            If Maze(x + 50, y) = True And IsInVisited(x + 50, y) = False Then    'Right
                NodeQueueX.Enqueue(x + 50)
                NodeQueueY.Enqueue(y)
                AddNode(x + 50, y, x, y)
            End If
            If Maze(x, y - 50) = True And IsInVisited(x, y - 50) = False Then      'Up
                NodeQueueX.Enqueue(x)
                NodeQueueY.Enqueue(y - 50)
                AddNode(x, y - 50, x, y)
            End If
            If Maze(x - 50, y) = True And IsInVisited(x - 50, y) = False Then      'Left
                NodeQueueX.Enqueue(x - 50)
                NodeQueueY.Enqueue(y)
                AddNode(x - 50, y, x, y)
            End If
        ElseIf x = 0 And 49 < y And y < 901 Then
            If Maze(x, y + 50) = True And IsInVisited(x, y + 50) = False Then      'Down
                NodeQueueX.Enqueue(x)
                NodeQueueY.Enqueue(y + 50)
                AddNode(x, y + 50, x, y)
            End If
            If Maze(x + 50, y) = True And IsInVisited(x + 50, y) = False Then    'Right
                NodeQueueX.Enqueue(x + 50)
                NodeQueueY.Enqueue(y)
                AddNode(x + 50, y, x, y)
            End If
            If Maze(x, y - 50) = True And IsInVisited(x, y - 50) = False Then      'Up
                NodeQueueX.Enqueue(x)
                NodeQueueY.Enqueue(y - 50)
                AddNode(x, y - 50, x, y)
            End If
        Else
            If Maze(x - 50, y) = True And IsInVisited(x - 50, y) = False Then      'Left
                NodeQueueX.Enqueue(x - 50)
                NodeQueueY.Enqueue(y)
                AddNode(x - 50, y, x, y)
            End If
            If Maze(x, y + 50) = True And IsInVisited(x, y + 50) = False Then      'Down
                NodeQueueX.Enqueue(x)
                NodeQueueY.Enqueue(y + 50)
                AddNode(x, y + 50, x, y)
            End If
            If Maze(x + 50, y) = True And IsInVisited(x + 50, y) = False Then    'Right
                NodeQueueX.Enqueue(x + 50)
                NodeQueueY.Enqueue(y)
                AddNode(x + 50, y, x, y)
            End If
            If Maze(x, y - 50) = True And IsInVisited(x, y - 50) = False Then      'Up
                NodeQueueX.Enqueue(x)
                NodeQueueY.Enqueue(y - 50)
                AddNode(x, y - 50, x, y)
            End If
        End If

    End Function

    Function IsInVisited(ByVal x As Integer, ByVal y As Integer)
        For i = 0 To VisitedNodesX.Count - 1
            If VisitedNodesX(i) = x And VisitedNodesY(i) = y Then
                Return True
            End If
        Next
        Return False
    End Function


End Module