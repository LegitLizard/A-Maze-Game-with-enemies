Public Class Form1

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
    Dim f As New List(Of Integer)  'total cost of node  = g+h
    Dim g As New List(Of Integer)   'distance from the start
    Dim h As New List(Of Integer)   'heuristic best guess
    Dim ChildListX As New List(Of Integer)
    Dim ChildListY As New List(Of Integer)
    Dim fmin As Integer = 0
    Dim CurrentX As Integer = 0
    Dim CurrentY As Integer = 0
    Dim cost As Integer

    Function AStar()
        Dim i As Integer = 0
        Dim found As Boolean = False

        OpenListX.Add(0)
        OpenListY.Add(0)

        Do
            g.Add(i)
            h.Add(CurrentX + CurrentY)
            f.Add(h(i) + g(i))
            For b = 0 To f.Count
                If f(b) <= fmin Then
                    fmin = b
                End If
            Next
            CurrentX = OpenListX(fmin)
            CurrentY = OpenListY(fmin)
            ClosedListX.Add(CurrentX)
            ClosedListY.Add(CurrentY)
            OpenListX.RemoveAt(fmin)
            OpenListY.RemoveAt(fmin)

            If CurrentX = 950 And CurrentY = 950 Then
                found = True
            End If
            Child(CurrentX, CurrentY)

            If CheckInClosed() = True Then
                ChildListX.Clear()
                ChildListY.Clear()
                i += 1
                Continue Do
            End If

            ChildListX.Clear()
            ChildListY.Clear()
            i += 1
        Loop While OpenListX.Count <> 0 Or found = False



    End Function

    Function CheckInClosed()
        For a = 0 To ClosedListX.Count
            For b = 0 To ChildListX.Count
                If ClosedListX(a) = ChildListX(b) And ClosedListY(a) = ChildListY(b) Then
                    Return True
                End If
            Next
        Next
    End Function

    Dim ChildG As Integer
    Dim ChildH As Integer
    Dim ChildF As Integer
    Dim ParentG As New List(Of Integer)


    Function AStar2()
        Dim ParentCount = 0

        For i = 0 To ChildListX.Count
            If ChildListX(i) = 950 And ChildListY(i) = 950 Then
                Exit For
            Else
                ChildG = ParentG(ParentCount) + (ChildListX(i) - CurrentX) + (ChildListY(i) - CurrentY)
                ChildH = (950 - ChildListX(i)) + (950 - ChildListY(i))
                ChildF = ChildH + ChildG
            End If

            If ChildG = 

        Next



    End Function



    Function Child(ByVal x As Integer, ByVal y As Integer)

        If x = 0 And y = 0 Then                       'Top left corner
            If Maze(x, y - 50) = False Then
                ChildListX.Add(x)          'Down coordinate    X
                ChildListY.Add(y + 50)      'Down coordinate   Y
            End If
            If Maze(x + 50, y) = False Then
                ChildListX.Add(x + 50)      'Right coordinate    X
                ChildListY.Add(y)         'Right coordinate   Y
            End If

        ElseIf x = 0 And y = 950 Then                 'Bottom left corner
            If Maze(x, y - 50) = False Then
                ChildListX.Add(x)          'Up coordinate    X
                ChildListY.Add(y - 50)     'Up coordinate   Y
            End If
            If Maze(x + 50, y) = False Then
                ChildListX.Add(x + 50)      'Right coordinate  X
                ChildListY.Add(y)           'Right coordinate   Y
            End If

        ElseIf x = 950 And y = 0 Then                 'Top right corner
            If Maze(x, y + 50) = False Then
                ChildListX.Add(x)           'Down coordinate    X
                ChildListY.Add(y + 50)     'Down coordinate   Y
            End If
            If Maze(x - 50, y) = False Then
                ChildListX.Add(x - 50)    'Left coordinate    X
                ChildListY.Add(y)          'Left coordinate   Y

            End If

        ElseIf x = 950 And y = 950 Then               'Bottom right corner
            If Maze(x, y - 50) = False Then
                ChildListX.Add(x)        'Up coordinate    X
                ChildListY.Add(y - 50)     'Up coordinate   Y

            End If
            If Maze(x - 50, y) = False Then
                ChildListX.Add(x - 50)      'Left coordinate   X
                ChildListY.Add(y)         'Left coordinate   Y

            End If

        ElseIf x = 0 And y = 50 Then                      'special case
            If Maze(x, y + 50) = False Then
                ChildListX.Add(x)           'Down coordinate    X
                ChildListY.Add(y + 50)      'Down coordinate   Y

            End If
            If Maze(x + 50, y) = False Then
                ChildListX.Add(x + 50)     'Right coordinate    X
                ChildListY.Add(y)          'Right coordinate   Y

            End If
            If Maze(x, y - 50) = False Then
                ChildListX.Add(x)             'Up coordinate   X
                ChildListY.Add(y - 50)        'Up coordinate   Y

            End If

        ElseIf x = 0 And y = 900 Then           'special case
            If Maze(x, y + 50) = False Then
                ChildListX.Add(x)           'Down coordinate    X
                ChildListY.Add(y + 50)      'Down coordinate   Y

            End If
            If Maze(x + 50, y) = False Then
                ChildListX.Add(x + 50)     'Right coordinate    X
                ChildListY.Add(y)          'Right coordinate   Y

            End If
            If Maze(x, y - 50) = False Then
                ChildListX.Add(x)             'Up coordinate   X
                ChildListY.Add(y - 50)        'Up coordinate   Y

            End If

        ElseIf x = 50 And y = 0 Then                       'special case
            If Maze(x, y + 50) = False Then
                ChildListX.Add(x)          'Down coordinate   X
                ChildListY.Add(y + 50)     'Down coordinate   Y

            End If
            If Maze(x - 50, y) = False Then
                ChildListX.Add(x - 50)         'Left coordinate X
                ChildListY.Add(y)             'Left coordinate Y

            End If
            If Maze(x + 50, y) = False Then
                ChildListX.Add(x + 50)      'Right coordinate  X
                ChildListY.Add(y)           'Right coordinate   Y

            End If

        ElseIf x = 50 And y = 50 Then              'special case
            If Maze(x, y - 50) = False Then
                ChildListX.Add(x)           'Up coordinate    X
                ChildListY.Add(y - 50)    'Up coordinate   Y

            End If
            If Maze(x + 50, y) = False Then
                ChildListX.Add(x + 50)      'Right coordinate  X
                ChildListY.Add(y)           'Right coordinate   Y

            End If
            If Maze(x - 50, y) = False Then
                ChildListX.Add(x - 50)     'Left coordinate   X
                ChildListY.Add(y)          'Left coordinate   Y

            End If
            If Maze(x, y + 50) = False Then
                ChildListX.Add(x)        'Down coordinate X
                ChildListY.Add(y + 50)      'Down coordinate Y

            End If

        ElseIf x = 50 And 99 < y And y < 851 Then                     'special case
            If Maze(x, y - 50) = False Then
                ChildListX.Add(x)           'Up coordinat    X
                ChildListY.Add(y - 50)    'Up coordinate   Y

            End If
            If Maze(x + 50, y) = False Then
                ChildListX.Add(x + 50)      'Right coordinate  X
                ChildListY.Add(y)           'Right coordinate   Y

            End If
            If Maze(x - 50, y) = False Then
                ChildListX.Add(x - 50)     'Left coordinate   X
                ChildListY.Add(y)          'Left coordinate   Y

            End If
            If Maze(x, y + 50) = False Then
                ChildListX.Add(x)        'own coordinate X
                ChildListY.Add(y + 50)      'Down coordinate Y

            End If

        ElseIf x = 50 And y = 900 Then           'special case
            If Maze(x, y - 50) = False Then
                ChildListX.Add(x)           'Up coordinate    X
                ChildListY.Add(y - 50)    'Up coordinate   Y

            End If
            If Maze(x + 50, y) = False Then
                ChildListX.Add(x + 50)      'Right coordinate  X
                ChildListY.Add(y)           'Right coordinate   Y

            End If
            If Maze(x - 50, y) = False Then
                ChildListX.Add(x - 50)     'Left coordinate   X
                ChildListY.Add(y)          'Left coordinate   Y

            End If
            If Maze(x, y + 50) = False Then
                ChildListX.Add(x)        'Down coordinate X
                ChildListY.Add(y + 50)      'Down coordinate Y

            End If

        ElseIf x = 50 And y = 950 Then          'special case 
            If Maze(x, y - 50) = False Then
                ChildListX.Add(x)           'Up coordinate    X
                ChildListY.Add(y - 50)      'Up coordinate   Y

            End If
            If Maze(x + 50, y) = False Then
                ChildListX.Add(x + 50)      'Right coordinate  X
                ChildListY.Add(y)         'Right coordinate   Y

            End If
            If Maze(x - 50, y) = False Then
                ChildListX.Add(x - 50)      'Left coordinate   X
                ChildListY.Add(y)           'Left coordinate   Y

            End If

        ElseIf 99 < x And x < 851 And y = 50 Then                 'special case
            If Maze(x, y - 50) = False Then
                ChildListX.Add(x)           'Up coordinate    X
                ChildListY.Add(y - 50)    'Up coordinate   Y

            End If
            If Maze(x + 50, y) = False Then
                ChildListX.Add(x + 50)      'Right coordinate  X
                ChildListY.Add(y)           'Right coordinate   Y

            End If
            If Maze(x - 50, y) = False Then
                ChildListX.Add(x - 50)     'Left coordinate   X
                ChildListY.Add(y)          'Left coordinate   Y

            End If
            If Maze(x, y + 50) = False Then
                ChildListX.Add(x)        'Down coordinate X
                ChildListY.Add(y + 50)      'Down coordinate Y

            End If

        ElseIf 99 < x And x < 851 And y = 900 Then         'special case
            If Maze(x, y - 50) = False Then
                ChildListX.Add(x)           'Up coordinate    X
                ChildListY.Add(y - 50)    'Up coordinate   Y

            End If
            If Maze(x + 50, y) = False Then
                ChildListX.Add(x + 50)      'Right coordinate  X
                ChildListY.Add(y)           'Right coordinate   Y

            End If
            If Maze(x - 50, y) = False Then
                ChildListX.Add(x - 50)     'Left coordinate   X
                ChildListY.Add(y)          'Left coordinate   Y

            End If
            If Maze(x, y + 50) = False Then
                ChildListX.Add(x)        'Down coordinate X
                ChildListY.Add(y + 50)      'Down coordinate Y

            End If

        ElseIf x = 900 And y = 0 Then         'special case
            If Maze(x + 50, y) = False Then
                ChildListX.Add(x + 50)      'Right coordinate  X
                ChildListY.Add(y)           'Right coordinate   Y

            End If
            If Maze(x - 50, y) = False Then
                ChildListX.Add(x - 50)     'Left coordinate   X
                ChildListY.Add(y)          'Left coordinate   Y

            End If
            If Maze(x, y + 50) = False Then
                ChildListX.Add(x)        'Down coordinate X
                ChildListY.Add(y + 50)      'Down coordinate Y

            End If

        ElseIf x = 900 And y = 50 Then              'special case
            If Maze(x, y - 50) = False Then
                ChildListX.Add(x)           'Up coordinate    X
                ChildListY.Add(y - 50)    'Up coordinate   Y

            End If
            If Maze(x + 50, y) = False Then
                ChildListX.Add(x + 50)      'Right coordinate  X
                ChildListY.Add(y)           'Right coordinate   Y

            End If
            If Maze(x - 50, y) = False Then
                ChildListX.Add(x - 50)     'Left coordinate   X
                ChildListY.Add(y)          'Left coordinate   Y

            End If
            If Maze(x, y + 50) = False Then
                ChildListX.Add(x)        'Down coordinate X
                ChildListY.Add(y + 50)      'Down coordinate Y

            End If

        ElseIf x = 900 And 99 < y And y < 851 Then            'special case
            If Maze(x, y - 50) = False Then
                ChildListX.Add(x)           'Up coordinate    X
                ChildListY.Add(y - 50)    'Up coordinate   Y

            End If
            If Maze(x + 50, y) = False Then
                ChildListX.Add(x + 50)      'Right coordinate  X
                ChildListY.Add(y)           'Right coordinate   Y

            End If
            If Maze(x - 50, y) = False Then
                ChildListX.Add(x - 50)     'Left coordinate   X
                ChildListY.Add(y)          'Left coordinate   Y

            End If
            If Maze(x, y + 50) = False Then
                ChildListX.Add(x)        'Down coordinate X
                ChildListY.Add(y + 50)      'Down coordinate Y

            End If

        ElseIf x = 900 And y = 900 Then                     'special case
            If Maze(x, y - 50) = False Then
                ChildListX.Add(x)           'Up coordinate    X
                ChildListY.Add(y - 50)    'Up coordinate   Y

            End If
            If Maze(x + 50, y) = False Then
                ChildListX.Add(x + 50)      'Right coordinate  X
                ChildListY.Add(y)           'Right coordinate   Y

            End If
            If Maze(x - 50, y) = False Then
                ChildListX.Add(x - 50)     'Left coordinate   X
                ChildListY.Add(y)          'Left coordinate   Y

            End If
            If Maze(x, y + 50) = False Then
                ChildListX.Add(x)        'Down coordinate X
                ChildListY.Add(y + 50)      'Down coordinate Y

            End If

        ElseIf x = 900 And y = 950 Then                'special case
            If Maze(x, y - 50) = False Then
                ChildListX.Add(x)           'Up coordinate    X
                ChildListY.Add(y - 50)    'Up coordinate   Y

            End If
            If Maze(x + 50, y) = False Then
                ChildListX.Add(x + 50)      'Right coordinate  X
                ChildListY.Add(y)           'Right coordinate   Y

            End If
            If Maze(x - 50, y) = False Then
                ChildListX.Add(x - 50)     'Left coordinate   X
                ChildListY.Add(y)          'Left coordinate   Y

            End If

        ElseIf x = 950 And y = 50 Then                'special case
            If Maze(x, y - 50) = False Then
                ChildListX.Add(x)           'Up coordinate    X
                ChildListY.Add(y - 50)    'Up coordinate   Y

            End If
            If Maze(x - 50, y) = False Then
                ChildListX.Add(x - 50)     'Left coordinate   X
                ChildListY.Add(y)          'Left coordinate   Y

            End If
            If Maze(x, y + 50) = False Then
                ChildListX.Add(x)        'Down coordinate X
                ChildListY.Add(y + 50)      'Down coordinate Y

            End If

        ElseIf x = 950 And y = 900 Then             'special case
            If Maze(x, y - 50) = False Then
                ChildListX.Add(x)           'Up coordinate    X
                ChildListY.Add(y - 50)    'Up coordinate   Y

            End If
            If Maze(x - 50, y) = False Then
                ChildListX.Add(x - 50)     'Left coordinate   X
                ChildListY.Add(y)          'Left coordinate   Y

            End If
            If Maze(x, y + 50) = False Then
                ChildListX.Add(x)        'Down coordinate X
                ChildListY.Add(y + 50)      'Down coordinate Y

            End If

        ElseIf x = 0 Then                             'If the current square is at the left border
            If Maze(x, y + 50) = False Then
                ChildListX.Add(x)           'Down coordinate    X
                ChildListY.Add(y + 50)      'Down coordinate   Y

            End If
            If Maze(x + 50, y) = False Then
                ChildListX.Add(x + 50)     'Right coordinate    X
                ChildListY.Add(y)          'Right coordinate   Y

            End If
            If Maze(x, y - 50) = False Then
                ChildListX.Add(x)             'Up coordinate   X
                ChildListY.Add(y - 50)        'Up coordinate   Y

            End If

        ElseIf y = 0 Then                             'If the current square is at the top border
            If Maze(x, y + 50) = False Then
                ChildListX.Add(x)          'Down coordinate   X
                ChildListY.Add(y + 50)     'Down coordinate   Y

            End If
            If Maze(x - 50, y) = False Then
                ChildListX.Add(x - 50)         'Left coordinate X
                ChildListY.Add(y)             'Left coordinate Y

            End If
            If Maze(x + 50, y) = False Then
                ChildListX.Add(x + 50)      'Right coordinate  X
                ChildListY.Add(y)           'Right coordinate   Y

            End If

        ElseIf x = 950 Then                           'If the current square is at the right border
            If Maze(x, y - 50) = False Then
                ChildListX.Add(x)          'Up coordinate    X
                ChildListY.Add(y - 50)     'Up coordinate   Y

            End If
            If Maze(x, y + 50) = False Then
                ChildListX.Add(x)          'Down coordinate X
                ChildListY.Add(y + 50)      'Down coordinate Y

            End If
            If Maze(x - 50, y) = False Then
                ChildListX.Add(x - 50)      'Left coordinate   X
                ChildListY.Add(y)          'Left coordinate   Y

            End If

        ElseIf y = 950 Then                           'If the current square is at the bottom border
            If Maze(x, y - 50) = False Then
                ChildListX.Add(x)           'Up coordinate    X
                ChildListY.Add(y - 50)      'Up coordinate   Y

            End If
            If Maze(x + 50, y) = False Then
                ChildListX.Add(x + 50)      'Right coordinate  X
                ChildListY.Add(y)         'Right coordinate   Y

            End If
            If Maze(x - 50, y) = False Then
                ChildListX.Add(x - 50)      'Left coordinate   X
                ChildListY.Add(y)           'Left coordinate   Y

            End If

        Else                'anywhere else in the square
            If Maze(x, y - 50) = False Then
                ChildListX.Add(x)           'Up coordinate    X
                ChildListY.Add(y - 50)    'Up coordinate   Y

            End If
            If Maze(x + 50, y) = False Then
                ChildListX.Add(x + 50)      'Right coordinate  X
                ChildListY.Add(y)           'Right coordinate   Y

            End If
            If Maze(x - 50, y) = False Then
                ChildListX.Add(x - 50)     'Left coordinate   X
                ChildListY.Add(y)          'Left coordinate   Y

            End If
            If Maze(x, y + 50) = False Then
                ChildListX.Add(x)        'Down coordinate X
                ChildListY.Add(y + 50)      'Down coordinate Y

            End If

        End If

    End Function

End Module