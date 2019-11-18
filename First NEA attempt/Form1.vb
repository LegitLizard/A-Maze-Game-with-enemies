Public Class Form1
    'Public WithEvents SolveButton As Button
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
        RandomX = Random.Next(10, 19)     'Quad 1: X = 500 to 950   Y = 0 to 450
        RandomX = RandomX * 50
        RandomY = Random.Next(0, 9)
        RandomY = RandomY * 50
        Enemy1X = RandomX
        Enemy1Y = RandomY
        EnemyImage1.Location = New Point(RandomX, RandomY)
        RandomX = Random.Next(0, 9)      'Quad 2: X = 0 to 450   Y = 500 to 950
        RandomX = RandomX * 50
        RandomY = Random.Next(10, 19)
        RandomY = RandomY * 50
        Enemy2X = RandomX
        Enemy2Y = RandomY
        EnemyImage2.Location = New Point(RandomX, RandomY)
        RandomX = Random.Next(10, 19)     'Quad 3: X = 500 to 950    Y = 500 to 950
        RandomX = RandomX * 50
        RandomY = Random.Next(10, 19)
        RandomY = RandomY * 50
        Enemy3X = RandomX
        Enemy3Y = RandomY
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

    Private Sub Form1_PicBox(sender As Object, e As EventArgs) Handles MyBase.Load
        KeyPreview = True
    End Sub

    Private Sub Form1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        If HeroX = 0 And HeroY = 0 Then                       'Top left corner
            If e.KeyCode = Keys.Down And Maze(HeroX, HeroY + 50) = True Then
                HeroImage.Top += 50      'Down
                HeroY += 50
            End If
            If e.KeyCode = Keys.Right And Maze(HeroX + 50, HeroY) = True Then
                HeroImage.Left += 50        'Right
                HeroX += 50
            End If

        ElseIf HeroX = 0 And HeroY = 950 Then                 'Bottom left corner
            If e.KeyCode = Keys.Up And Maze(HeroX, HeroY - 50) = True And HeroY >= 50 Then
                HeroImage.Top -= 50       'Up
                HeroY -= 50
            End If
            If e.KeyCode = Keys.Right And Maze(HeroX + 50, HeroY) = True Then
                HeroImage.Left += 50        'Right
                HeroX += 50
            End If

        ElseIf HeroX = 950 And HeroY = 0 Then                 'Top right corner
            If e.KeyCode = Keys.Down And Maze(HeroX, HeroY + 50) = True Then
                HeroImage.Top += 50      'Down
                HeroY += 50
            End If
            If e.KeyCode = Keys.Left And Maze(HeroX - 50, HeroY) = True Then
                HeroImage.Left -= 50        'Left
                HeroX -= 50
            End If

        ElseIf HeroX = 950 And HeroY = 950 Then               'Bottom right corner
            If e.KeyCode = Keys.Up And Maze(HeroX, HeroY - 50) = True And HeroY >= 50 Then
                HeroImage.Top -= 50       'Up
                HeroY -= 50
            End If
            If e.KeyCode = Keys.Left And Maze(HeroX - 50, HeroY) = True Then
                HeroImage.Left -= 50        'Left
                HeroX -= 50
            End If

        ElseIf 49 < HeroX And HeroX < 901 And HeroY = 0 Then            'Top row
            If e.KeyCode = Keys.Down And Maze(HeroX, HeroY + 50) = True Then
                HeroImage.Top += 50      'Down
                HeroY += 50
            End If
            If e.KeyCode = Keys.Left And Maze(HeroX - 50, HeroY) = True Then
                HeroImage.Left -= 50        'Left
                HeroX -= 50
            End If
            If e.KeyCode = Keys.Right And Maze(HeroX + 50, HeroY) = True Then
                HeroImage.Left += 50        'Right
                HeroX += 50
            End If

        ElseIf 49 < HeroX And HeroX < 901 And HeroY = 950 Then         'Bottom row
            If e.KeyCode = Keys.Up And Maze(HeroX, HeroY - 50) = True And HeroY >= 50 Then
                HeroImage.Top -= 50       'Up
                HeroY -= 50
            End If
            If e.KeyCode = Keys.Left And Maze(HeroX - 50, HeroY) = True Then
                HeroImage.Left -= 50        'Left
                HeroX -= 50
            End If
            If e.KeyCode = Keys.Right And Maze(HeroX + 50, HeroY) = True Then
                HeroImage.Left += 50        'Right
                HeroX += 50
            End If

        ElseIf HeroX = 0 And 49 < HeroY And HeroY < 901 Then         'Left row
            If e.KeyCode = Keys.Up And Maze(HeroX, HeroY - 50) = True And HeroY >= 50 Then
                HeroImage.Top -= 50       'Up
                HeroY -= 50
            End If
            If e.KeyCode = Keys.Down And Maze(HeroX, HeroY + 50) = True Then
                HeroImage.Top += 50      'Down
                HeroY += 50
            End If
            If e.KeyCode = Keys.Right And Maze(HeroX + 50, HeroY) = True Then
                HeroImage.Left += 50        'Right
                HeroX += 50
            End If

        ElseIf HeroX = 950 And 49 < HeroY And HeroY < 901 Then         'Right row
            If e.KeyCode = Keys.Up And Maze(HeroX, HeroY - 50) = True And HeroY >= 50 Then
                HeroImage.Top -= 50       'Up
                HeroY -= 50
            End If
            If e.KeyCode = Keys.Down And Maze(HeroX, HeroY + 50) = True Then
                HeroImage.Top += 50      'Down
                HeroY += 50
            End If
            If e.KeyCode = Keys.Left And Maze(HeroX - 50, HeroY) = True Then
                HeroImage.Left -= 50        'Left
                HeroX -= 50
            End If

        Else                'anywhere else in the maze
            If e.KeyCode = Keys.Up And Maze(HeroX, HeroY - 50) = True And HeroY >= 50 Then
                HeroImage.Top -= 50       'Up
                HeroY -= 50
            End If
            If e.KeyCode = Keys.Down And Maze(HeroX, HeroY + 50) = True Then
                HeroImage.Top += 50      'Down
                HeroY += 50
            End If
            If e.KeyCode = Keys.Left And Maze(HeroX - 50, HeroY) = True Then
                HeroImage.Left -= 50        'Left
                HeroX -= 50
            End If
            If e.KeyCode = Keys.Right And Maze(HeroX + 50, HeroY) = True Then
                HeroImage.Left += 50        'Right
                HeroX += 50
            End If

        End If

        If e.KeyCode = 88 Then
            AStar()
            PaintSolution()
        End If

    End Sub

    Public Sub PaintSolution() Handles Me.Load
        Dim i As Integer = 1
        For y = 0 To PathY.Count - 1
            For x = 0 To PathX.Count - 1
                Dim newPictureBox As New PictureBox
                newPictureBox.Name = "PictureBox" & i
                newPictureBox.Location = New Point(PathX(x), PathY(y))
                newPictureBox.BorderStyle = BorderStyle.None
                newPictureBox.Dock = DockStyle.None
                newPictureBox.Visible = True
                newPictureBox.BackColor = Color.Pink
                Controls.Add(newPictureBox)
                i += 1
            Next
        Next
    End Sub

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

    Public Sub EnemyMove()
        Dim random As New Random
        Dim MoveChoice As Integer

        Do
            Threading.Thread.Sleep(1500)
            MoveChoice = random.Next(1, 4)

            If MoveChoice = 1 Then       'Move up
                EnemyImage1.Location = New Point(Enemy1X, Enemy1Y - 50)
                Enemy1Y -= 50
            ElseIf MoveChoice = 2 Then     'Move right
                EnemyImage1.Location = New Point(Enemy1X + 50, Enemy1Y)
                Enemy1X += 50
            ElseIf MoveChoice = 3 Then      'Move down
                EnemyImage1.Location = New Point(Enemy1X, Enemy1Y + 50)
                Enemy1Y += 50
            ElseIf MoveChoice = 4 Then      'Move left
                EnemyImage1.Location = New Point(Enemy1X - 50, Enemy1Y)
                Enemy1X -= 50
            End If

        Loop




    End Sub


End Class

Module module1

    Public Maze(950, 950) As Boolean    'If True, path is present
    Dim FrontierX As New List(Of Integer)   'All cells that are adjacent to a cell in the maze X coords
    Dim FrontierY As New List(Of Integer)   'All cells that are adjacent to a cell in the maze Y coords
    Dim FrontierCount As Integer = 0
    Dim RandomNumber As Integer

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

    Dim OpenListX As New List(Of Integer)
    Dim OpenListY As New List(Of Integer)
    Dim ClosedListX As New List(Of Integer)
    Dim ClosedListY As New List(Of Integer)
    Dim fmin As Integer = 0
    Dim CurrentX As Integer = 0
    Dim CurrentY As Integer = 0
    Dim count As Integer = 0        'holds the highest item number
    Public Item() As Node
    Public PathX As New List(Of Integer)
    Public PathY As New List(Of Integer)
    Dim KeepTrack As Integer = 0

    Public Class Node
        Public ParentX As Integer = 0
        Public ParentY As Integer = 0
        Public PresentX As Integer = 0
        Public PresentY As Integer = 0
        Public ChildX() As Integer
        Public ChildY() As Integer
        Public f As Integer = 0    'total cost of node  = g+h
        Public g As Integer = 0      'distance from the start following path
        Public h As Integer = 0        'heuristic best guess
    End Class

    Function AStar()

        OpenListX.Add(0)
        OpenListY.Add(0)



        Item(0).g = 0
        Item(0).h = CurrentX + CurrentY
        Item(0).f = Item(0).g + Item(0).h

        Do
            Dim CheckInOpen As Boolean = False
            Dim Position As Integer

            For b = 0 To Item.Length - 1
                If Item(b).f <= fmin Then
                    fmin = b
                End If
            Next

            For a = 0 To OpenListX.Count - 1
                If Item(fmin).PresentX = OpenListX(a) And Item(fmin).PresentY = OpenListY(a) Then
                    CheckInOpen = True
                    Position = a
                End If
            Next

            If CheckInOpen = True Then
                CurrentX = OpenListX(Position)
                CurrentY = OpenListY(Position)
                ClosedListX.Add(CurrentX)
                ClosedListY.Add(CurrentY)
                OpenListX.RemoveAt(Position)
                OpenListY.RemoveAt(Position)
            End If

            Child(CurrentX, CurrentY)

        Loop While OpenListX.Count <> 0 Or CheckInClosed(CurrentX, CurrentY) = True Or CurrentX <> 950 And CurrentY <> 950

        CurrentX = 950
        CurrentY = 950

        Do
            FindCount()
        Loop While CheckStart() = False

    End Function

    Function FindCount()

        For a = 0 To Item.Count
            For b = 0 To Item(a).ChildX.Count
                If Item(a).ChildX(b) = CurrentX And Item(a).ChildY(b) = CurrentY Then
                    PathX.Add(Item(a).ChildX(b))
                    PathY.Add(Item(a).ChildY(b))
                    CurrentX = Item(a).PresentX
                    CurrentY = Item(a).PresentY
                End If
            Next
        Next

    End Function

    Function CheckStart()
        For a = 0 To PathX.Count - 1
            If PathX(a) = 0 And PathY(a) = 0 Then
                Return True
            End If
        Next
        Return False

    End Function

    Function CheckInClosed(ByVal x As Integer, ByVal y As Integer)

        For a = 0 To ClosedListX.Count - 1
            If x = ClosedListX(a) And y = ClosedListY(a) Then
                Return True
            End If
        Next
        Return False

    End Function

    Function CheckInOpen(ByVal x As Integer, ByVal y As Integer)

        For a = 0 To OpenListX.Count - 1
            If x = OpenListX(a) And y = OpenListY(a) Then
                Return True
            End If
        Next
        Return False

    End Function

    Function Child(ByVal x As Integer, ByVal y As Integer)

        If x = 0 And y = 0 Then                       'Top left corner
            If Maze(x, y + 50) = False And CheckInOpen(x, y + 50) = False Then
                Item(count).ChildX(0) = x          'Down coordinate    X
                Item(count).ChildY(0) = (y + 50)      'Down coordinate   Y
                Item(count + 1).ParentX = x
                Item(count + 1).ParentY = y
                Item(count + 1).PresentX = x
                Item(count + 1).PresentY = y + 50
                Item(count + 1).g = Item(count).g + 1
                Item(count + 1).h = (950 - Item(count + 1).PresentX) + (950 - Item(count + 1).PresentY)
                Item(count + 1).f = Item(count + 1).g + Item(count + 1).h
            End If

            If Maze(x + 50, y) = False And CheckInOpen(x, y + 50) = False Then
                Item(count).ChildX(1) = x + 50      'Right coordinate    X
                Item(count).ChildY(1) = (y)         'Right coordinate   Y
                Item(count + 2).ParentX = x
                Item(count + 2).ParentY = y
                Item(count + 2).PresentX = x + 50
                Item(count + 2).PresentY = y
                Item(count + 2).g = Item(count).g + 1
                Item(count + 2).h = (950 - Item(count + 2).PresentX) + (950 - Item(count + 2).PresentY)
                Item(count + 2).f = Item(count + 2).g + Item(count + 2).h
            End If
            count += 3
        ElseIf x = 0 And y = 950 Then                 'Bottom left corner
            If Maze(x, y - 50) = False And CheckInOpen(x, y + 50) = False Then
                Item(count).ChildX(0) = x          'Up coordinate    X
                Item(count).ChildY(0) = (y - 50)     'Up coordinate   Y
                Item(count + 1).ParentX = x
                Item(count + 1).ParentY = y
                Item(count + 1).PresentX = x
                Item(count + 1).PresentY = y - 50
                Item(count + 1).g = Item(count).g + 1
                Item(count + 1).h = (950 - Item(count + 1).PresentX) + (950 - Item(count + 1).PresentY)
                Item(count + 1).f = Item(count + 1).g + Item(count + 1).h
            End If
            If Maze(x + 50, y) = False And CheckInOpen(x, y + 50) = False Then
                Item(count).ChildX(1) = x + 50      'Right coordinate  X
                Item(count).ChildY(1) = (y)           'Right coordinate Y
                Item(count + 2).ParentX = x
                Item(count + 2).ParentY = y
                Item(count + 2).PresentX = x + 50
                Item(count + 2).PresentY = y
                Item(count + 2).g = Item(count).g + 1
                Item(count + 2).h = (950 - Item(count + 2).PresentX) + (950 - Item(count + 2).PresentY)
                Item(count + 2).f = Item(count + 2).g + Item(count + 2).h
            End If
            count += 3
        ElseIf x = 950 And y = 0 Then                 'Top right corner
            If Maze(x, y + 50) = False And CheckInOpen(x, y + 50) = False Then
                Item(count).ChildX(0) = x           'Down coordinate    X
                Item(count).ChildY(0) = (y + 50)     'Down coordinate   Y
                Item(count + 1).ParentX = x
                Item(count + 1).ParentY = y
                Item(count + 1).PresentX = x
                Item(count + 1).PresentY = y + 50
                Item(count + 1).g = Item(count).g + 1
                Item(count + 1).h = (950 - Item(count + 1).PresentX) + (950 - Item(count + 1).PresentY)
                Item(count + 1).f = Item(count + 1).g + Item(count + 1).h
            End If
            If Maze(x - 50, y) = False And CheckInOpen(x, y + 50) = False Then
                Item(count).ChildX(1) = (x - 50)    'Left coordinate    X
                Item(count).ChildY(1) = (y)          'Left coordinate   Y
                Item(count + 2).ParentX = x
                Item(count + 2).ParentY = y
                Item(count + 2).PresentX = x - 50
                Item(count + 2).PresentY = y
                Item(count + 2).g = Item(count).g + 1
                Item(count + 2).h = (950 - Item(count + 2).PresentX) + (950 - Item(count + 2).PresentY)
                Item(count + 2).f = Item(count + 2).g + Item(count + 2).h
            End If
            count += 3
        ElseIf x = 950 And y = 950 Then               'Bottom right corner
            Return True
        ElseIf x = 0 And y = 50 Then                      'special case
            If Maze(x, y + 50) = False And CheckInOpen(x, y + 50) = False Then
                Item(count).ChildX(0) = (x)           'Down coordinate    X
                Item(count).ChildY(0) = (y + 50)      'Down coordinate   Y
                Item(count + 1).ParentX = x
                Item(count + 1).ParentY = y
                Item(count + 1).PresentX = x
                Item(count + 1).PresentY = y + 50
                Item(count + 1).g = Item(count).g + 1
                Item(count + 1).h = (950 - Item(count + 1).PresentX) + (950 - Item(count + 1).PresentY)
                Item(count + 1).f = Item(count + 1).g + Item(count + 1).h
            End If
            If Maze(x + 50, y) = False And CheckInOpen(x, y + 50) = False Then
                Item(count).ChildX(1) = (x + 50)     'Right coordinate    X
                Item(count).ChildY(1) = (y)          'Right coordinate   Y
                Item(count + 2).ParentX = x
                Item(count + 2).ParentY = y
                Item(count + 2).PresentX = x + 50
                Item(count + 2).PresentY = y
                Item(count + 2).g = Item(count).g + 1
                Item(count + 2).h = (950 - Item(count + 2).PresentX) + (950 - Item(count + 2).PresentY)
                Item(count + 2).f = Item(count + 2).g + Item(count + 2).h
            End If
            If Maze(x, y - 50) = False And CheckInOpen(x, y + 50) = False Then
                Item(count).ChildX(2) = (x)             'Up coordinate   X
                Item(count).ChildY(2) = (y - 50)        'Up coordinate   Y
                Item(count + 3).ParentX = x
                Item(count + 3).ParentY = y
                Item(count + 3).PresentX = x
                Item(count + 3).PresentY = y - 50
                Item(count + 3).g = Item(count).g + 1
                Item(count + 3).h = (950 - Item(count + 3).PresentX) + (950 - Item(count + 3).PresentY)
                Item(count + 3).f = Item(count + 3).g + Item(count + 3).h
            End If
            count += 4
        ElseIf x = 0 And y = 900 Then           'special case
            If Maze(x, y + 50) = False And CheckInOpen(x, y + 50) = False Then
                Item(count).ChildX(0) = (x)           'Down coordinate    X
                Item(count).ChildY(0) = (y + 50)      'Down coordinate   Y
                Item(count + 1).ParentX = x
                Item(count + 1).ParentY = y
                Item(count + 1).PresentX = x
                Item(count + 1).PresentY = y + 50
                Item(count + 1).g = Item(count).g + 1
                Item(count + 1).h = (950 - Item(count + 1).PresentX) + (950 - Item(count + 1).PresentY)
                Item(count + 1).f = Item(count + 1).g + Item(count + 1).h
            End If
            If Maze(x + 50, y) = False And CheckInOpen(x, y + 50) = False Then
                Item(count).ChildX(1) = (x + 50)     'Right coordinate    X
                Item(count).ChildY(1) = (y)          'Right coordinate   Y
                Item(count + 2).ParentX = x
                Item(count + 2).ParentY = y
                Item(count + 2).PresentX = x + 50
                Item(count + 2).PresentY = y
                Item(count + 2).g = Item(count).g + 1
                Item(count + 2).h = (950 - Item(count + 2).PresentX) + (950 - Item(count + 2).PresentY)
                Item(count + 2).f = Item(count + 2).g + Item(count + 2).h
            End If
            If Maze(x, y - 50) = False And CheckInOpen(x, y + 50) = False Then
                Item(count).ChildX(2) = (x)             'Up coordinate   X
                Item(count).ChildY(2) = (y - 50)        'Up coordinate   Y
                Item(count + 3).ParentX = x
                Item(count + 3).ParentY = y
                Item(count + 3).PresentX = x
                Item(count + 3).PresentY = y - 50
                Item(count + 3).g = Item(count).g + 1
                Item(count + 3).h = (950 - Item(count + 3).PresentX) + (950 - Item(count + 3).PresentY)
                Item(count + 3).f = Item(count + 3).g + Item(count + 3).h
            End If
            count += 4
        ElseIf x = 50 And y = 0 Then                       'special case
            If Maze(x, y + 50) = False And CheckInOpen(x, y + 50) = False Then
                Item(count).ChildX(0) = (x)          'Down coordinate   X
                Item(count).ChildY(0) = (y + 50)     'Down coordinate   Y
                Item(count + 1).ParentX = x
                Item(count + 1).ParentY = y
                Item(count + 1).PresentX = x
                Item(count + 1).PresentY = y + 50
                Item(count + 1).g = Item(count).g + 1
                Item(count + 1).h = (950 - Item(count + 1).PresentX) + (950 - Item(count + 1).PresentY)
                Item(count + 1).f = Item(count + 1).g + Item(count + 1).h
            End If
            If Maze(x - 50, y) = False And CheckInOpen(x, y + 50) = False Then
                Item(count).ChildX(1) = (x - 50)         'Left coordinate X
                Item(count).ChildY(1) = (y)             'Left coordinate Y
                Item(count + 2).ParentX = x
                Item(count + 2).ParentY = y
                Item(count + 2).PresentX = x - 50
                Item(count + 2).PresentY = y
                Item(count + 2).g = Item(count).g + 1
                Item(count + 2).h = (950 - Item(count + 2).PresentX) + (950 - Item(count + 2).PresentY)
                Item(count + 2).f = Item(count + 2).g + Item(count + 2).h
            End If
            If Maze(x + 50, y) = False And CheckInOpen(x, y + 50) = False Then
                Item(count).ChildX(2) = (x + 50)      'Right coordinate  X
                Item(count).ChildY(2) = (y)           'Right coordinate   Y
                Item(count + 3).ParentX = x
                Item(count + 3).ParentY = y
                Item(count + 3).PresentX = x + 50
                Item(count + 3).PresentY = y
                Item(count + 3).g = Item(count).g + 1
                Item(count + 3).h = (950 - Item(count + 3).PresentX) + (950 - Item(count + 3).PresentY)
                Item(count + 3).f = Item(count + 3).g + Item(count + 3).h
            End If
            count += 4
        ElseIf x = 50 And y = 50 Then              'special case
            If Maze(x, y - 50) = False And CheckInOpen(x, y + 50) = False Then
                Item(count).ChildX(0) = (x)           'Up coordinate    X
                Item(count).ChildY(0) = (y - 50)    'Up coordinate   Y
                Item(count + 1).ParentX = x
                Item(count + 1).ParentY = y
                Item(count + 1).PresentX = x
                Item(count + 1).PresentY = y - 50
                Item(count + 1).g = Item(count).g + 1
                Item(count + 1).h = (950 - Item(count + 1).PresentX) + (950 - Item(count + 1).PresentY)
                Item(count + 1).f = Item(count + 1).g + Item(count + 1).h
            End If
            If Maze(x + 50, y) = False And CheckInOpen(x, y + 50) = False Then
                Item(count).ChildX(1) = (x + 50)      'Right coordinate  X
                Item(count).ChildY(1) = (y)           'Right coordinate   Y
                Item(count + 2).ParentX = x
                Item(count + 2).ParentY = y
                Item(count + 2).PresentX = x + 50
                Item(count + 2).PresentY = y
                Item(count + 2).g = Item(count).g + 1
                Item(count + 2).h = (950 - Item(count + 2).PresentX) + (950 - Item(count + 2).PresentY)
                Item(count + 2).f = Item(count + 2).g + Item(count + 2).h
            End If
            If Maze(x - 50, y) = False And CheckInOpen(x, y + 50) = False Then
                Item(count).ChildX(2) = (x - 50)     'Left coordinate   X
                Item(count).ChildY(2) = (y)          'Left coordinate   Y
                Item(count + 3).ParentX = x
                Item(count + 3).ParentY = y
                Item(count + 3).PresentX = x - 50
                Item(count + 3).PresentY = y
                Item(count + 3).g = Item(count).g + 1
                Item(count + 3).h = (950 - Item(count + 3).PresentX) + (950 - Item(count + 3).PresentY)
                Item(count + 3).f = Item(count + 3).g + Item(count + 3).h
            End If
            If Maze(x, y + 50) = False And CheckInOpen(x, y + 50) = False Then
                Item(count).ChildX(3) = (x)        'Down coordinate X
                Item(count).ChildY(3) = (y + 50)      'Down coordinate Y
                Item(count + 4).ParentX = x
                Item(count + 4).ParentY = y
                Item(count + 4).PresentX = x
                Item(count + 4).PresentY = y + 50
                Item(count + 4).g = Item(count).g + 1
                Item(count + 4).h = (950 - Item(count + 4).PresentX) + (950 - Item(count + 4).PresentY)
                Item(count + 4).f = Item(count + 4).g + Item(count + 4).h
            End If
            count += 5
        ElseIf x = 50 And 99 < y And y < 851 Then                     'special case
            If Maze(x, y - 50) = False And CheckInOpen(x, y + 50) = False Then
                Item(count).ChildX(0) = (x)           'Up coordinat    X
                Item(count).ChildY(0) = (y - 50)    'Up coordinate   Y
                Item(count + 1).ParentX = x
                Item(count + 1).ParentY = y
                Item(count + 1).PresentX = x
                Item(count + 1).PresentY = y - 50
                Item(count + 1).g = Item(count).g + 1
                Item(count + 1).h = (950 - Item(count + 1).PresentX) + (950 - Item(count + 1).PresentY)
                Item(count + 1).f = Item(count + 1).g + Item(count + 1).h
            End If
            If Maze(x + 50, y) = False And CheckInOpen(x, y + 50) = False Then
                Item(count).ChildX(1) = (x + 50)      'Right coordinate  X
                Item(count).ChildY(1) = (y)           'Right coordinate   Y
                Item(count + 2).ParentX = x
                Item(count + 2).ParentY = y
                Item(count + 2).PresentX = x + 50
                Item(count + 2).PresentY = y
                Item(count + 2).g = Item(count).g + 1
                Item(count + 2).h = (950 - Item(count + 2).PresentX) + (950 - Item(count + 2).PresentY)
                Item(count + 2).f = Item(count + 2).g + Item(count + 2).h
            End If
            If Maze(x - 50, y) = False And CheckInOpen(x, y + 50) = False Then
                Item(count).ChildX(2) = (x - 50)     'Left coordinate   X
                Item(count).ChildY(2) = (y)          'Left coordinate   Y
                Item(count + 3).ParentX = x
                Item(count + 3).ParentY = y
                Item(count + 3).PresentX = x - 50
                Item(count + 3).PresentY = y
                Item(count + 3).g = Item(count).g + 1
                Item(count + 3).h = (950 - Item(count + 3).PresentX) + (950 - Item(count + 3).PresentY)
                Item(count + 3).f = Item(count + 3).g + Item(count + 3).h
            End If
            If Maze(x, y + 50) = False And CheckInOpen(x, y + 50) = False Then
                Item(count).ChildX(3) = x        'own coordinate X
                Item(count).ChildY(3) = (y + 50)      'Down coordinate Y
                Item(count + 4).ParentX = x
                Item(count + 4).ParentY = y
                Item(count + 4).PresentX = x
                Item(count + 4).PresentY = y + 50
                Item(count + 4).g = Item(count).g + 1
                Item(count + 4).h = (950 - Item(count + 4).PresentX) + (950 - Item(count + 4).PresentY)
                Item(count + 4).f = Item(count + 4).g + Item(count + 4).h
            End If
            count += 5
        ElseIf x = 50 And y = 900 Then           'special case
            If Maze(x, y - 50) = False And CheckInOpen(x, y + 50) = False Then
                Item(count).ChildX(0) = (x)           'Up coordinate    X
                Item(count).ChildY(0) = (y - 50)    'Up coordinate   Y
                Item(count + 1).ParentX = x
                Item(count + 1).ParentY = y
                Item(count + 1).PresentX = x
                Item(count + 1).PresentY = y - 50
                Item(count + 1).g = Item(count).g + 1
                Item(count + 1).h = (950 - Item(count + 1).PresentX) + (950 - Item(count + 1).PresentY)
                Item(count + 1).f = Item(count + 1).g + Item(count + 1).h
            End If
            If Maze(x + 50, y) = False And CheckInOpen(x, y + 50) = False Then
                Item(count).ChildX(1) = (x + 50)      'Right coordinate  X
                Item(count).ChildY(1) = (y)           'Right coordinate   Y
                Item(count + 2).ParentX = x
                Item(count + 2).ParentY = y
                Item(count + 2).PresentX = x + 50
                Item(count + 2).PresentY = y
                Item(count + 2).g = Item(count).g + 1
                Item(count + 2).h = (950 - Item(count + 2).PresentX) + (950 - Item(count + 2).PresentY)
                Item(count + 2).f = Item(count + 2).g + Item(count + 2).h
            End If
            If Maze(x - 50, y) = False And CheckInOpen(x, y + 50) = False Then
                Item(count).ChildX(2) = (x - 50)     'Left coordinate   X
                Item(count).ChildY(2) = (y)          'Left coordinate   Y
                Item(count + 3).ParentX = x
                Item(count + 3).ParentY = y
                Item(count + 3).PresentX = x - 50
                Item(count + 3).PresentY = y
                Item(count + 3).g = Item(count).g + 1
                Item(count + 3).h = (950 - Item(count + 3).PresentX) + (950 - Item(count + 3).PresentY)
                Item(count + 3).f = Item(count + 3).g + Item(count + 3).h
            End If
            If Maze(x, y + 50) = False And CheckInOpen(x, y + 50) = False Then
                Item(count).ChildX(3) = (x)        'Down coordinate X
                Item(count).ChildY(3) = (y + 50)      'Down coordinate Y
                Item(count + 4).ParentX = x
                Item(count + 4).ParentY = y
                Item(count + 4).PresentX = x
                Item(count + 4).PresentY = y + 50
                Item(count + 4).g = Item(count).g + 1
                Item(count + 4).h = (950 - Item(count + 4).PresentX) + (950 - Item(count + 4).PresentY)
                Item(count + 4).f = Item(count + 4).g + Item(count + 4).h
            End If
            count += 5
        ElseIf x = 50 And y = 950 Then          'special case
            If Maze(x, y - 50) = False And CheckInOpen(x, y + 50) = False Then
                Item(count).ChildX(0) = (x)           'Up coordinate    X
                Item(count).ChildY(0) = (y - 50)      'Up coordinate   Y
                Item(count + 1).ParentX = x
                Item(count + 1).ParentY = y
                Item(count + 1).PresentX = x
                Item(count + 1).PresentY = y - 50
                Item(count + 1).g = Item(count).g + 1
                Item(count + 1).h = (950 - Item(count + 1).PresentX) + (950 - Item(count + 1).PresentY)
                Item(count + 1).f = Item(count + 1).g + Item(count + 1).h
            End If
            If Maze(x + 50, y) = False And CheckInOpen(x, y + 50) = False Then
                Item(count).ChildX(1) = (x + 50)      'Right coordinate  X
                Item(count).ChildY(1) = (y)         'Right coordinate   Y
                Item(count + 2).ParentX = x
                Item(count + 2).ParentY = y
                Item(count + 2).PresentX = x + 50
                Item(count + 2).PresentY = y
                Item(count + 2).g = Item(count).g + 1
                Item(count + 2).h = (950 - Item(count + 2).PresentX) + (950 - Item(count + 2).PresentY)
                Item(count + 2).f = Item(count + 2).g + Item(count + 2).h
            End If
            If Maze(x - 50, y) = False And CheckInOpen(x, y + 50) = False Then
                Item(count).ChildX(2) = (x - 50)      'Left coordinate   X
                Item(count).ChildY(2) = (y)           'Left coordinate   Y
                Item(count + 3).ParentX = x
                Item(count + 3).ParentY = y
                Item(count + 3).PresentX = x - 50
                Item(count + 3).PresentY = y
                Item(count + 3).g = Item(count).g + 1
                Item(count + 3).h = (950 - Item(count + 3).PresentX) + (950 - Item(count + 3).PresentY)
                Item(count + 3).f = Item(count + 3).g + Item(count + 3).h
            End If
            count += 4
        ElseIf 99 < x And x < 851 And y = 50 Then                 'special case
            If Maze(x, y - 50) = False And CheckInOpen(x, y + 50) = False Then
                Item(count).ChildX(0) = (x)           'Up coordinate    X
                Item(count).ChildY(0) = (y - 50)    'Up coordinate   Y
                Item(count + 1).ParentX = x
                Item(count + 1).ParentY = y
                Item(count + 1).PresentX = x
                Item(count + 1).PresentY = y - 50
                Item(count + 1).g = Item(count).g + 1
                Item(count + 1).h = (950 - Item(count + 1).PresentX) + (950 - Item(count + 1).PresentY)
                Item(count + 1).f = Item(count + 1).g + Item(count + 1).h
            End If
            If Maze(x + 50, y) = False And CheckInOpen(x, y + 50) = False Then
                Item(count).ChildX(1) = (x + 50)      'Right coordinate  X
                Item(count).ChildY(1) = (y)           'Right coordinate   Y
                Item(count + 2).ParentX = x
                Item(count + 2).ParentY = y
                Item(count + 2).PresentX = x + 50
                Item(count + 2).PresentY = y
                Item(count + 2).g = Item(count).g + 1
                Item(count + 2).h = (950 - Item(count + 2).PresentX) + (950 - Item(count + 2).PresentY)
                Item(count + 2).f = Item(count + 2).g + Item(count + 2).h
            End If
            If Maze(x - 50, y) = False And CheckInOpen(x, y + 50) = False Then
                Item(count).ChildX(2) = (x - 50)     'Left coordinate   X
                Item(count).ChildY(2) = (y)          'Left coordinate   Y
                Item(count + 3).ParentX = x
                Item(count + 3).ParentY = y
                Item(count + 3).PresentX = x - 50
                Item(count + 3).PresentY = y
                Item(count + 3).g = Item(count).g + 1
                Item(count + 3).h = (950 - Item(count + 3).PresentX) + (950 - Item(count + 3).PresentY)
                Item(count + 3).f = Item(count + 3).g + Item(count + 3).h
            End If
            If Maze(x, y + 50) = False And CheckInOpen(x, y + 50) = False Then
                Item(count).ChildX(3) = (x)        'Down coordinate X
                Item(count).ChildY(3) = (y + 50)      'Down coordinate Y
                Item(count + 4).ParentX = x
                Item(count + 4).ParentY = y
                Item(count + 4).PresentX = x
                Item(count + 4).PresentY = y + 50
                Item(count + 4).g = Item(count).g + 1
                Item(count + 4).h = (950 - Item(count + 4).PresentX) + (950 - Item(count + 4).PresentY)
                Item(count + 4).f = Item(count + 4).g + Item(count + 4).h
            End If
            count += 5
        ElseIf 99 < x And x < 851 And y = 900 Then         'special case
            If Maze(x, y - 50) = False And CheckInOpen(x, y + 50) = False Then
                Item(count).ChildX(0) = (x)           'Up coordinate    X
                Item(count).ChildY(0) = (y - 50)    'Up coordinate   Y
                Item(count + 1).ParentX = x
                Item(count + 1).ParentY = y
                Item(count + 1).PresentX = x
                Item(count + 1).PresentY = y - 50
                Item(count + 1).g = Item(count).g + 1
                Item(count + 1).h = (950 - Item(count + 1).PresentX) + (950 - Item(count + 1).PresentY)
                Item(count + 1).f = Item(count + 1).g + Item(count + 1).h
            End If
            If Maze(x + 50, y) = False And CheckInOpen(x, y + 50) = False Then
                Item(count).ChildX(1) = (x + 50)      'Right coordinate  X
                Item(count).ChildY(1) = (y)           'Right coordinate   Y
                Item(count + 2).ParentX = x
                Item(count + 2).ParentY = y
                Item(count + 2).PresentX = x + 50
                Item(count + 2).PresentY = y
                Item(count + 2).g = Item(count).g + 1
                Item(count + 2).h = (950 - Item(count + 2).PresentX) + (950 - Item(count + 2).PresentY)
                Item(count + 2).f = Item(count + 2).g + Item(count + 2).h
            End If
            If Maze(x - 50, y) = False And CheckInOpen(x, y + 50) = False Then
                Item(count).ChildX(2) = (x - 50)     'Left coordinate   X
                Item(count).ChildY(2) = (y)          'Left coordinate   Y
                Item(count + 3).ParentX = x
                Item(count + 3).ParentY = y
                Item(count + 3).PresentX = x - 50
                Item(count + 3).PresentY = y
                Item(count + 3).g = Item(count).g + 1
                Item(count + 3).h = (950 - Item(count + 3).PresentX) + (950 - Item(count + 3).PresentY)
                Item(count + 3).f = Item(count + 3).g + Item(count + 3).h
            End If
            If Maze(x, y + 50) = False And CheckInOpen(x, y + 50) = False Then
                Item(count).ChildX(3) = (x)        'Down coordinate X
                Item(count).ChildY(3) = (y + 50)      'Down coordinate Y
                Item(count + 4).ParentX = x
                Item(count + 4).ParentY = y
                Item(count + 4).PresentX = x
                Item(count + 4).PresentY = y + 50
                Item(count + 4).g = Item(count).g + 1
                Item(count + 4).h = (950 - Item(count + 4).PresentX) + (950 - Item(count + 4).PresentY)
                Item(count + 4).f = Item(count + 4).g + Item(count + 4).h
            End If
            count += 5
        ElseIf x = 900 And y = 0 Then         'special case
            If Maze(x + 50, y) = False And CheckInOpen(x, y + 50) = False Then
                Item(count).ChildX(0) = (x + 50)      'Right coordinate  X
                Item(count).ChildY(0) = (y)           'Right coordinate   Y
                Item(count + 1).ParentX = x
                Item(count + 1).ParentY = y
                Item(count + 1).PresentX = x + 50
                Item(count + 1).PresentY = y
                Item(count + 1).g = Item(count).g + 1
                Item(count + 1).h = (950 - Item(count + 1).PresentX) + (950 - Item(count + 1).PresentY)
                Item(count + 1).f = Item(count + 1).g + Item(count + 1).h
            End If
            If Maze(x - 50, y) = False And CheckInOpen(x, y + 50) = False Then
                Item(count).ChildX(1) = (x - 50)     'Left coordinate   X
                Item(count).ChildY(1) = (y)          'Left coordinate   Y
                Item(count + 2).ParentX = x
                Item(count + 2).ParentY = y
                Item(count + 2).PresentX = x - 50
                Item(count + 2).PresentY = y
                Item(count + 2).g = Item(count).g + 1
                Item(count + 2).h = (950 - Item(count + 2).PresentX) + (950 - Item(count + 2).PresentY)
                Item(count + 2).f = Item(count + 2).g + Item(count + 2).h
            End If
            If Maze(x, y + 50) = False And CheckInOpen(x, y + 50) = False Then
                Item(count).ChildX(2) = (x)        'Down coordinate X
                Item(count).ChildY(2) = (y + 50)      'Down coordinate Y
                Item(count + 3).ParentX = x
                Item(count + 3).ParentY = y
                Item(count + 3).PresentX = x
                Item(count + 3).PresentY = y + 50
                Item(count + 3).g = Item(count).g + 1
                Item(count + 3).h = (950 - Item(count + 3).PresentX) + (950 - Item(count + 3).PresentY)
                Item(count + 3).f = Item(count + 3).g + Item(count + 3).h
            End If
            count += 4
        ElseIf x = 900 And y = 50 Then              'special case
            If Maze(x, y - 50) = False And CheckInOpen(x, y + 50) = False Then
                Item(count).ChildX(0) = (x)           'Up coordinate    X
                Item(count).ChildY(0) = (y - 50)    'Up coordinate   Y
                Item(count + 1).ParentX = x
                Item(count + 1).ParentY = y
                Item(count + 1).PresentX = x
                Item(count + 1).PresentY = y - 50
                Item(count + 1).g = Item(count).g + 1
                Item(count + 1).h = (950 - Item(count + 1).PresentX) + (950 - Item(count + 1).PresentY)
                Item(count + 1).f = Item(count + 1).g + Item(count + 1).h
            End If
            If Maze(x + 50, y) = False And CheckInOpen(x, y + 50) = False Then
                Item(count).ChildX(1) = (x + 50)      'Right coordinate  X
                Item(count).ChildY(1) = (y)           'Right coordinate   Y
                Item(count + 2).ParentX = x
                Item(count + 2).ParentY = y
                Item(count + 2).PresentX = x + 50
                Item(count + 2).PresentY = y
                Item(count + 2).g = Item(count).g + 1
                Item(count + 2).h = (950 - Item(count + 2).PresentX) + (950 - Item(count + 2).PresentY)
                Item(count + 2).f = Item(count + 2).g + Item(count + 2).h
            End If
            If Maze(x - 50, y) = False And CheckInOpen(x, y + 50) = False Then
                Item(count).ChildX(2) = (x - 50)     'Left coordinate   X
                Item(count).ChildY(2) = (y)          'Left coordinate   Y
                Item(count + 3).ParentX = x
                Item(count + 3).ParentY = y
                Item(count + 3).PresentX = x - 50
                Item(count + 3).PresentY = y
                Item(count + 3).g = Item(count).g + 1
                Item(count + 3).h = (950 - Item(count + 3).PresentX) + (950 - Item(count + 3).PresentY)
                Item(count + 3).f = Item(count + 3).g + Item(count + 3).h
            End If
            If Maze(x, y + 50) = False And CheckInOpen(x, y + 50) = False Then
                Item(count).ChildX(3) = (x)        'Down coordinate X
                Item(count).ChildY(3) = (y + 50)      'Down coordinate Y
                Item(count + 4).ParentX = x
                Item(count + 4).ParentY = y
                Item(count + 4).PresentX = x
                Item(count + 4).PresentY = y + 50
                Item(count + 4).g = Item(count).g + 1
                Item(count + 4).h = (950 - Item(count + 4).PresentX) + (950 - Item(count + 4).PresentY)
                Item(count + 4).f = Item(count + 4).g + Item(count + 4).h
            End If
            count += 5
        ElseIf x = 900 And 99 < y And y < 851 Then            'special case
            If Maze(x, y - 50) = False And CheckInOpen(x, y + 50) = False Then
                Item(count).ChildX(0) = (x)           'Up coordinate    X
                Item(count).ChildY(0) = (y - 50)    'Up coordinate   Y
                Item(count + 1).ParentX = x
                Item(count + 1).ParentY = y
                Item(count + 1).PresentX = x
                Item(count + 1).PresentY = y - 50
                Item(count + 1).g = Item(count).g + 1
                Item(count + 1).h = (950 - Item(count + 1).PresentX) + (950 - Item(count + 1).PresentY)
                Item(count + 1).f = Item(count + 1).g + Item(count + 1).h
            End If
            If Maze(x + 50, y) = False And CheckInOpen(x, y + 50) = False Then
                Item(count).ChildX(1) = (x + 50)      'Right coordinate  X
                Item(count).ChildY(1) = (y)           'Right coordinate   Y
                Item(count + 2).ParentX = x
                Item(count + 2).ParentY = y
                Item(count + 2).PresentX = x + 50
                Item(count + 2).PresentY = y
                Item(count + 2).g = Item(count).g + 1
                Item(count + 2).h = (950 - Item(count + 2).PresentX) + (950 - Item(count + 2).PresentY)
                Item(count + 2).f = Item(count + 2).g + Item(count + 2).h
            End If
            If Maze(x - 50, y) = False And CheckInOpen(x, y + 50) = False Then
                Item(count).ChildX(2) = (x - 50)     'Left coordinate   X
                Item(count).ChildY(2) = (y)          'Left coordinate   Y
                Item(count + 3).ParentX = x
                Item(count + 3).ParentY = y
                Item(count + 3).PresentX = x - 50
                Item(count + 3).PresentY = y
                Item(count + 3).g = Item(count).g + 1
                Item(count + 3).h = (950 - Item(count + 3).PresentX) + (950 - Item(count + 3).PresentY)
                Item(count + 3).f = Item(count + 3).g + Item(count + 3).h
            End If
            If Maze(x, y + 50) = False And CheckInOpen(x, y + 50) = False Then
                Item(count).ChildX(3) = x        'Down coordinate X
                Item(count).ChildY(3) = (y + 50)      'Down coordinate Y
                Item(count + 4).ParentX = x
                Item(count + 4).ParentY = y
                Item(count + 4).PresentX = x
                Item(count + 4).PresentY = y + 50
                Item(count + 4).g = Item(count).g + 1
                Item(count + 4).h = (950 - Item(count + 4).PresentX) + (950 - Item(count + 4).PresentY)
                Item(count + 4).f = Item(count + 4).g + Item(count + 4).h
            End If
            count += 5
        ElseIf x = 900 And y = 900 Then                     'special case
            If Maze(x, y - 50) = False And CheckInOpen(x, y + 50) = False Then
                Item(count).ChildX(0) = (x)           'Up coordinate    X
                Item(count).ChildY(0) = (y - 50)    'Up coordinate   Y
                Item(count + 1).ParentX = x
                Item(count + 1).ParentY = y
                Item(count + 1).PresentX = x
                Item(count + 1).PresentY = y - 50
                Item(count + 1).g = Item(count).g + 1
                Item(count + 1).h = (950 - Item(count + 1).PresentX) + (950 - Item(count + 1).PresentY)
                Item(count + 1).f = Item(count + 1).g + Item(count + 1).h
            End If
            If Maze(x + 50, y) = False And CheckInOpen(x, y + 50) = False Then
                Item(count).ChildX(1) = (x + 50)      'Right coordinate  X
                Item(count).ChildY(1) = (y)           'Right coordinate   Y
                Item(count + 2).ParentX = x
                Item(count + 2).ParentY = y
                Item(count + 2).PresentX = x + 50
                Item(count + 2).PresentY = y
                Item(count + 2).g = Item(count).g + 1
                Item(count + 2).h = (950 - Item(count + 2).PresentX) + (950 - Item(count + 2).PresentY)
                Item(count + 2).f = Item(count + 2).g + Item(count + 2).h
            End If
            If Maze(x - 50, y) = False And CheckInOpen(x, y + 50) = False Then
                Item(count).ChildX(2) = (x - 50)     'Left coordinate   X
                Item(count).ChildY(2) = y         'Left coordinate   Y
                Item(count + 3).ParentX = x
                Item(count + 3).ParentY = y
                Item(count + 3).PresentX = x - 50
                Item(count + 3).PresentY = y
                Item(count + 3).g = Item(count).g + 1
                Item(count + 3).h = (950 - Item(count + 3).PresentX) + (950 - Item(count + 3).PresentY)
                Item(count + 3).f = Item(count + 3).g + Item(count + 3).h
            End If
            If Maze(x, y + 50) = False And CheckInOpen(x, y + 50) = False Then
                Item(count).ChildX(3) = (x)        'Down coordinate X
                Item(count).ChildY(3) = (y + 50)      'Down coordinate Y
                Item(count + 4).ParentX = x
                Item(count + 4).ParentY = y
                Item(count + 4).PresentX = x
                Item(count + 4).PresentY = y + 50
                Item(count + 4).g = Item(count).g + 1
                Item(count + 4).h = (950 - Item(count + 4).PresentX) + (950 - Item(count + 4).PresentY)
                Item(count + 4).f = Item(count + 4).g + Item(count + 4).h
            End If
            count += 5
        ElseIf x = 900 And y = 950 Then                'special case
            If Maze(x, y - 50) = False And CheckInOpen(x, y + 50) = False Then
                Item(count).ChildX(0) = (x)           'Up coordinate    X
                Item(count).ChildY(0) = (y - 50)    'Up coordinate   Y
                Item(count + 1).ParentX = x
                Item(count + 1).ParentY = y
                Item(count + 1).PresentX = x
                Item(count + 1).PresentY = y - 50
                Item(count + 1).g = Item(count).g + 1
                Item(count + 1).h = (950 - Item(count + 1).PresentX) + (950 - Item(count + 1).PresentY)
                Item(count + 1).f = Item(count + 1).g + Item(count + 1).h
            End If
            If Maze(x + 50, y) = False And CheckInOpen(x, y + 50) = False Then
                Item(count).ChildX(1) = (x + 50)      'Right coordinate  X
                Item(count).ChildY(1) = (y)           'Right coordinate   Y
                Item(count + 2).ParentX = x
                Item(count + 2).ParentY = y
                Item(count + 2).PresentX = x + 50
                Item(count + 2).PresentY = y
                Item(count + 2).g = Item(count).g + 1
                Item(count + 2).h = (950 - Item(count + 2).PresentX) + (950 - Item(count + 2).PresentY)
                Item(count + 2).f = Item(count + 2).g + Item(count + 2).h
            End If
            If Maze(x - 50, y) = False And CheckInOpen(x, y + 50) = False Then
                Item(count).ChildX(2) = (x - 50)     'Left coordinate   X
                Item(count).ChildY(2) = (y)          'Left coordinate   Y
                Item(count + 3).ParentX = x
                Item(count + 3).ParentY = y
                Item(count + 3).PresentX = x - 50
                Item(count + 3).PresentY = y
                Item(count + 3).g = Item(count).g + 1
                Item(count + 3).h = (950 - Item(count + 3).PresentX) + (950 - Item(count + 3).PresentY)
                Item(count + 3).f = Item(count + 3).g + Item(count + 3).h
            End If
            count += 4
        ElseIf x = 950 And y = 50 Then                'special case
            If Maze(x, y - 50) = False And CheckInOpen(x, y + 50) = False Then
                Item(count).ChildX(0) = (x)           'Up coordinate    X
                Item(count).ChildY(0) = (y - 50)    'Up coordinate   Y
                Item(count + 1).ParentX = x
                Item(count + 1).ParentY = y
                Item(count + 1).PresentX = x
                Item(count + 1).PresentY = y - 50
                Item(count + 1).g = Item(count).g + 1
                Item(count + 1).h = (950 - Item(count + 1).PresentX) + (950 - Item(count + 1).PresentY)
                Item(count + 1).f = Item(count + 1).g + Item(count + 1).h
            End If
            If Maze(x - 50, y) = False And CheckInOpen(x, y + 50) = False Then
                Item(count).ChildX(1) = (x - 50)     'Left coordinate   X
                Item(count).ChildY(1) = (y)          'Left coordinate   Y
                Item(count + 2).ParentX = x
                Item(count + 2).ParentY = y
                Item(count + 2).PresentX = x - 50
                Item(count + 2).PresentY = y
                Item(count + 2).g = Item(count).g + 1
                Item(count + 2).h = (950 - Item(count + 2).PresentX) + (950 - Item(count + 2).PresentY)
                Item(count + 2).f = Item(count + 2).g + Item(count + 2).h
            End If
            If Maze(x, y + 50) = False And CheckInOpen(x, y + 50) = False Then
                Item(count).ChildX(2) = (x)        'Down coordinate X
                Item(count).ChildY(2) = (y + 50)      'Down coordinate Y
                Item(count + 3).ParentX = x
                Item(count + 3).ParentY = y
                Item(count + 3).PresentX = x
                Item(count + 3).PresentY = y + 50
                Item(count + 3).g = Item(count).g + 1
                Item(count + 3).h = (950 - Item(count + 3).PresentX) + (950 - Item(count + 3).PresentY)
                Item(count + 3).f = Item(count + 3).g + Item(count + 3).h
            End If
            count += 4
        ElseIf x = 950 And y = 900 Then             'special case
            If Maze(x, y - 50) = False And CheckInOpen(x, y + 50) = False Then
                Item(count).ChildX(0) = x           'Up coordinate    X
                Item(count).ChildY(0) = (y - 50)    'Up coordinate   Y
                Item(count + 1).ParentX = x
                Item(count + 1).ParentY = y
                Item(count + 1).PresentX = x
                Item(count + 1).PresentY = y - 50
                Item(count + 1).g = Item(count).g + 1
                Item(count + 1).h = (950 - Item(count + 1).PresentX) + (950 - Item(count + 1).PresentY)
                Item(count + 1).f = Item(count + 1).g + Item(count + 1).h
            End If
            If Maze(x - 50, y) = False And CheckInOpen(x, y + 50) = False Then
                Item(count).ChildX(1) = (x - 50)     'Left coordinate   X
                Item(count).ChildY(1) = (y)          'Left coordinate   Y
                Item(count + 2).ParentX = x
                Item(count + 2).ParentY = y
                Item(count + 2).PresentX = x - 50
                Item(count + 2).PresentY = y
                Item(count + 2).g = Item(count).g + 1
                Item(count + 2).h = (950 - Item(count + 2).PresentX) + (950 - Item(count + 2).PresentY)
                Item(count + 2).f = Item(count + 2).g + Item(count + 2).h
            End If
            If Maze(x, y + 50) = False And CheckInOpen(x, y + 50) = False Then
                Item(count).ChildX(2) = (x)        'Down coordinate X
                Item(count).ChildY(2) = (y + 50)      'Down coordinate Y
                Item(count + 3).ParentX = x
                Item(count + 3).ParentY = y
                Item(count + 3).PresentX = x
                Item(count + 3).PresentY = y + 50
                Item(count + 3).g = Item(count).g + 1
                Item(count + 3).h = (950 - Item(count + 3).PresentX) + (950 - Item(count + 3).PresentY)
                Item(count + 3).f = Item(count + 3).g + Item(count + 3).h
            End If
            count += 4
        ElseIf x = 0 Then                             'If the current square is at the left border
            If Maze(x, y + 50) = False And CheckInOpen(x, y + 50) = False Then
                Item(count).ChildX(0) = (x)           'Down coordinate    X
                Item(count).ChildY(0) = (y + 50)      'Down coordinate   Y
                Item(count + 1).ParentX = x
                Item(count + 1).ParentY = y
                Item(count + 1).PresentX = x
                Item(count + 1).PresentY = y + 50
                Item(count + 1).g = Item(count).g + 1
                Item(count + 1).h = (950 - Item(count + 1).PresentX) + (950 - Item(count + 1).PresentY)
                Item(count + 1).f = Item(count + 1).g + Item(count + 1).h
            End If
            If Maze(x + 50, y) = False And CheckInOpen(x, y + 50) = False Then
                Item(count).ChildX(1) = (x + 50)     'Right coordinate    X
                Item(count).ChildY(1) = (y)          'Right coordinate   Y
                Item(count + 2).ParentX = x
                Item(count + 2).ParentY = y
                Item(count + 2).PresentX = x + 50
                Item(count + 2).PresentY = y
                Item(count + 2).g = Item(count).g + 1
                Item(count + 2).h = (950 - Item(count + 2).PresentX) + (950 - Item(count + 2).PresentY)
                Item(count + 2).f = Item(count + 2).g + Item(count + 2).h
            End If
            If Maze(x, y - 50) = False And CheckInOpen(x, y + 50) = False Then
                Item(count).ChildX(2) = (x)             'Up coordinate   X
                Item(count).ChildY(2) = (y - 50)        'Up coordinate   Y
                Item(count + 3).ParentX = x
                Item(count + 3).ParentY = y
                Item(count + 3).PresentX = x
                Item(count + 3).PresentY = y - 50
                Item(count + 3).g = Item(count).g + 1
                Item(count + 3).h = (950 - Item(count + 3).PresentX) + (950 - Item(count + 3).PresentY)
                Item(count + 3).f = Item(count + 3).g + Item(count + 3).h
            End If
            count += 4
        ElseIf y = 0 Then                             'If the current square is at the top border
            If Maze(x, y + 50) = False And CheckInOpen(x, y + 50) = False Then
                Item(count).ChildX(0) = (x)          'Down coordinate   X
                Item(count).ChildY(0) = (y + 50)     'Down coordinate   Y
                Item(count + 1).ParentX = x
                Item(count + 1).ParentY = y
                Item(count + 1).PresentX = x
                Item(count + 1).PresentY = y + 50
                Item(count + 1).g = Item(count).g + 1
                Item(count + 1).h = (950 - Item(count + 1).PresentX) + (950 - Item(count + 1).PresentY)
                Item(count + 1).f = Item(count + 1).g + Item(count + 1).h
            End If
            If Maze(x - 50, y) = False And CheckInOpen(x, y + 50) = False Then
                Item(count).ChildX(1) = (x - 50)         'Left coordinate X
                Item(count).ChildY(1) = (y)             'Left coordinate Y
                Item(count + 2).ParentX = x
                Item(count + 2).ParentY = y
                Item(count + 2).PresentX = x - 50
                Item(count + 2).PresentY = y
                Item(count + 2).g = Item(count).g + 1
                Item(count + 2).h = (950 - Item(count + 2).PresentX) + (950 - Item(count + 2).PresentY)
                Item(count + 2).f = Item(count + 2).g + Item(count + 2).h
            End If
            If Maze(x + 50, y) = False And CheckInOpen(x, y + 50) = False Then
                Item(count).ChildX(2) = (x + 50)      'Right coordinate  X
                Item(count).ChildY(2) = (y)           'Right coordinate   Y
                Item(count + 3).ParentX = x
                Item(count + 3).ParentY = y
                Item(count + 3).PresentX = x + 50
                Item(count + 3).PresentY = y
                Item(count + 3).g = Item(count).g + 1
                Item(count + 3).h = (950 - Item(count + 3).PresentX) + (950 - Item(count + 3).PresentY)
                Item(count + 3).f = Item(count + 3).g + Item(count + 3).h
            End If
            count += 4
        ElseIf x = 950 Then                           'If the current square is at the right border
            If Maze(x, y - 50) = False And CheckInOpen(x, y + 50) = False Then
                Item(count).ChildX(0) = (x)          'Up coordinate    X
                Item(count).ChildY(0) = (y - 50)     'Up coordinate   Y
                Item(count + 1).ParentX = x
                Item(count + 1).ParentY = y
                Item(count + 1).PresentX = x
                Item(count + 1).PresentY = y - 50
                Item(count + 1).g = Item(count).g + 1
                Item(count + 1).h = (950 - Item(count + 1).PresentX) + (950 - Item(count + 1).PresentY)
                Item(count + 1).f = Item(count + 1).g + Item(count + 1).h
            End If
            If Maze(x, y + 50) = False And CheckInOpen(x, y + 50) = False Then
                Item(count).ChildX(1) = (x)          'Down coordinate X
                Item(count).ChildY(1) = (y + 50)      'Down coordinate Y
                Item(count + 2).ParentX = x
                Item(count + 2).ParentY = y
                Item(count + 2).PresentX = x
                Item(count + 2).PresentY = y + 50
                Item(count + 2).g = Item(count).g + 1
                Item(count + 2).h = (950 - Item(count + 2).PresentX) + (950 - Item(count + 2).PresentY)
                Item(count + 2).f = Item(count + 2).g + Item(count + 2).h
            End If
            If Maze(x - 50, y) = False And CheckInOpen(x, y + 50) = False Then
                Item(count).ChildX(2) = x - 50      'Left coordinate   X
                Item(count).ChildY(2) = y          'Left coordinate   Y
                Item(count + 3).ParentX = x
                Item(count + 3).ParentY = y
                Item(count + 3).PresentX = x - 50
                Item(count + 3).PresentY = y
                Item(count + 3).g = Item(count).g + 1
                Item(count + 3).h = (950 - Item(count + 3).PresentX) + (950 - Item(count + 3).PresentY)
                Item(count + 3).f = Item(count + 3).g + Item(count + 3).h
            End If
            count += 4
        ElseIf y = 950 Then                           'If the current square is at the bottom border
            If Maze(x, y - 50) = False And CheckInOpen(x, y + 50) = False Then
                Item(count).ChildX(0) = x           'Up coordinate    X
                Item(count).ChildY(0) = y - 50      'Up coordinate   Y
                Item(count + 1).ParentX = x
                Item(count + 1).ParentY = y
                Item(count + 1).PresentX = x
                Item(count + 1).PresentY = y - 50
                Item(count + 1).g = Item(count).g + 1
                Item(count + 1).h = (950 - Item(count + 1).PresentX) + (950 - Item(count + 1).PresentY)
                Item(count + 1).f = Item(count + 1).g + Item(count + 1).h
            End If
            If Maze(x + 50, y) = False And CheckInOpen(x, y + 50) = False Then
                Item(count).ChildX(1) = x + 50      'Right coordinate  X
                Item(count).ChildY(1) = y         'Right coordinate   Y
                Item(count + 2).ParentX = x
                Item(count + 2).ParentY = y
                Item(count + 2).PresentX = x + 50
                Item(count + 2).PresentY = y
                Item(count + 2).g = Item(count).g + 1
                Item(count + 2).h = (950 - Item(count + 2).PresentX) + (950 - Item(count + 2).PresentY)
                Item(count + 2).f = Item(count + 2).g + Item(count + 2).h
            End If
            If Maze(x - 50, y) = False And CheckInOpen(x, y + 50) = False Then
                Item(count).ChildX(2) = x - 50      'Left coordinate   X
                Item(count).ChildY(2) = y           'Left coordinate   Y
                Item(count + 3).ParentX = x
                Item(count + 3).ParentY = y
                Item(count + 3).PresentX = x - 50
                Item(count + 3).PresentY = y
                Item(count + 3).g = Item(count).g + 1
                Item(count + 3).h = (950 - Item(count + 3).PresentX) + (950 - Item(count + 3).PresentY)
                Item(count + 3).f = Item(count + 3).g + Item(count + 3).h
            End If
            count += 1
        Else                'anywhere else in the square
            If Maze(x, y - 50) = False And CheckInOpen(x, y + 50) = False Then
                Item(count).ChildX(0) = x           'Up coordinate    X
                Item(count).ChildY(0) = y - 50    'Up coordinate   Y
                Item(count + 1).ParentX = x
                Item(count + 1).ParentY = y
                Item(count + 1).PresentX = x
                Item(count + 1).PresentY = y - 50
                Item(count + 1).g = Item(count).g + 1
                Item(count + 1).h = (950 - Item(count + 1).PresentX) + (950 - Item(count + 1).PresentY)
                Item(count + 1).f = Item(count + 1).g + Item(count + 1).h
            End If
            If Maze(x + 50, y) = False And CheckInOpen(x, y + 50) = False Then
                Item(count).ChildX(1) = x + 50      'Right coordinate  X
                Item(count).ChildY(1) = y           'Right coordinate   Y
                Item(count + 2).ParentX = x
                Item(count + 2).ParentY = y
                Item(count + 2).PresentX = x + 50
                Item(count + 2).PresentY = y
                Item(count + 2).g = Item(count).g + 1
                Item(count + 2).h = (950 - Item(count + 2).PresentX) + (950 - Item(count + 2).PresentY)
                Item(count + 2).f = Item(count + 2).g + Item(count + 2).h
            End If
            If Maze(x - 50, y) = False And CheckInOpen(x, y + 50) = False Then
                Item(count).ChildX(2) = x - 50     'Left coordinate   X
                Item(count).ChildY(2) = y          'Left coordinate   Y
                Item(count + 3).ParentX = x
                Item(count + 3).ParentY = y
                Item(count + 3).PresentX = x - 50
                Item(count + 3).PresentY = y
                Item(count + 3).g = Item(count).g + 1
                Item(count + 3).h = (950 - Item(count + 3).PresentX) + (950 - Item(count + 3).PresentY)
                Item(count + 3).f = Item(count + 3).g + Item(count + 3).h
            End If
            If Maze(x, y + 50) = False And CheckInOpen(x, y + 50) = False Then
                Item(count).ChildX(3) = x        'Down coordinate X
                Item(count).ChildY(3) = y + 50      'Down coordinate Y
                Item(count + 4).ParentX = x
                Item(count + 4).ParentY = y
                Item(count + 4).PresentX = x
                Item(count + 4).PresentY = y + 50
                Item(count + 4).g = Item(count).g + 1
                Item(count + 4).h = (950 - Item(count + 4).PresentX) + (950 - Item(count + 4).PresentY)
                Item(count + 4).f = Item(count + 4).g + Item(count + 4).h
            End If
            count += 5
        End If

    End Function

End Module