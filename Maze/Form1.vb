Imports System.Threading
Public Class Form1
    ' Constants
    Const M As Integer = 10
    Public maze As Cell(,)
    ' Maze properties
    Public width As Integer
    Public height As Integer
    Public deadEndPercent As Double
    Public mazeEntryType As String
    Public mazeEntry As Point
    Public mazeExit As Point
    ' Maze Colour Customisation
    Public bgColour As Color
    Public mazeColour As Color
    Public solveColour As Color
    ' Maze Generation/Solving Inputs
    Public generationAlgorithm As String
    Public solveAlgorithm As String
    ' Controls when the from draws
    Public mazeImage As Bitmap
    Public mazeImgaeGraphics As Graphics
    ' Animations
    Public frame As Integer = 0
    Public directionList As List(Of Integer) = New List(Of Integer)
    Public nodeList As List(Of Point) = New List(Of Point)
    Public weightList As List(Of Integer) = New List(Of Integer)
    ' Gradient 
    Dim lerpList As List(Of Integer) = New List(Of Integer)
    Dim t As Double = 0.01
    Dim c1 As List(Of Integer) = New List(Of Integer)
    Dim c2 As List(Of Integer) = New List(Of Integer)
    Dim c3 As List(Of Integer) = New List(Of Integer)
    Dim c4 As List(Of Integer) = New List(Of Integer)

    Public Class Cell
        ' Postion Properties
        Public x As Integer
        Public y As Integer
        ' Wall Properties
        Public walls As List(Of Boolean) = New List(Of Boolean)
        Public wallPos(3, 1) As Point
        ' Cell Type
        Public mazeWallBool As Boolean = False
        Public mazeEntryBool As Boolean = False
        Public mazeExitBool As Boolean = False
        Public mazeSolved As Boolean = False
        Public deadEnd As Boolean = False
        ' Generate/Solve Properties
        Public weight As Integer = 0
        Public visited As Boolean = False

        ' Sets all cells with all walls 
        Public Sub New()
            For i As Integer = 0 To 3
                walls.Add(True)
            Next
        End Sub
    End Class

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        generationCombo.SelectedIndex = 0 ' Makes index 0 default displayed on the combo list(so currently shows "DFS Backtracker" initially
        solveCombo.SelectedIndex = 0 ' Default displays (Dijkstra's Algortimn)
        mazeEntryCombo.SelectedIndex = 0 ' Default displays "Random"
    End Sub

    Private Sub initializeMazeDraw()
        ' Setting up Gradient
        For i As Integer = 1 To 3
            lerpList.Add(0)
        Next
        ' First colour
        c1.Add(0)
        c1.Add(0)
        c1.Add(255)
        ' Second colour
        c2.Add(255)
        c2.Add(0)
        c2.Add(0)
        ' Third colour
        c3.Add(255)
        c3.Add(255)
        c3.Add(0)
        ' Forth colour
        c4.Add(0)
        c4.Add(255)
        c4.Add(255)
        ' Setting Maze Entry and Exit
        Select Case mazeEntryType
            Case "Random"
                Randomize()
                Dim randomType As Integer = Int((4 * Rnd()))
                ' Chooses randomly what type of maze entry it will be
                Select Case randomType
                    Case 0 ' Start at a random top postion, finish at a random bottom position
                        mazeEntry = New Point((Int(((width - 1) * Rnd()) + 1)), 1)
                        mazeExit = New Point(Int(((width - 1) * Rnd()) + 1), height - 1)
                    Case 1 ' Start at a random bottom postion, finish at a random top position
                        mazeEntry = New Point(Int(((width - 1) * Rnd()) + 1), height - 1)
                        mazeExit = New Point((Int(((width - 1) * Rnd()) + 1)), 1)
                    Case 2 ' Start at a random right postion, finish at a random left positon
                        mazeEntry = New Point(1, Int(((height - 1) * Rnd()) + 1))
                        mazeExit = New Point(width - 1, Int(((height - 1) * Rnd()) + 1))
                    Case 3 ' Start at a random left postion, finish at a random right positon
                        mazeEntry = New Point(width - 1, Int(((height - 1) * Rnd()) + 1))
                        mazeExit = New Point(1, Int(((height - 1) * Rnd()) + 1))
                End Select
                If mazeEntry.X = 0 Or mazeEntry.Y = 0 Or mazeExit.X = 0 Or mazeExit.Y = 0 Then
                    mazeEntry = New Point((Int(((width - 1) * Rnd()) + 1)), 1)
                    mazeExit = New Point(Int(((width - 1) * Rnd()) + 1), height - 1)
                End If
            Case "Top - Bottom"
                mazeEntry = New Point(Math.Round(width / 2) + 1, 1)
                mazeExit = New Point(Math.Round(width / 2) + 1, height - 1)
            Case "Right - Left"
                mazeEntry = New Point(1, Math.Round(height / 2))
                mazeExit = New Point(width - 1, Math.Round(height / 2))
            Case "Diagonal"
                mazeEntry = New Point(1, 1)
                mazeExit = New Point(width - 1, height - 1)
        End Select

        ' Initialize each cell with correct: Type and Wall Position
        maze = New Cell(width, height) {}
        mazeImage = New Bitmap((width * M) + M, (height * M) + M)
        mazeImgaeGraphics = Graphics.FromImage(mazeImage)
        For i As Integer = 0 To width
            For j As Integer = 0 To height
                maze(i, j) = New Cell
                maze(i, j).x = i * M
                maze(i, j).y = j * M


                If i = mazeEntry.X And j = mazeEntry.Y Then
                    maze(i, j).mazeEntryBool = True
                    'maze(i, j).visited = True
                ElseIf i = mazeExit.X And j = mazeExit.Y Then
                    maze(i, j).mazeExitBool = True
                    'maze(i, j).visited = True
                ElseIf i = 0 Or j = 0 Or i = width Or j = height Then
                    maze(i, j).mazeWallBool = True
                    maze(i, j).visited = True
                End If
                For k As Integer = 0 To 3
                    Select Case k
                        Case 0 ' Top line
                            ' Start Point
                            maze(i, j).wallPos(k, 0) = New Point(maze(i, j).x, maze(i, j).y)
                            ' End Point
                            maze(i, j).wallPos(k, 1) = New Point(maze(i, j).x + M, maze(i, j).y)
                        Case 1 ' Rigth line
                            ' Start Point
                            maze(i, j).wallPos(k, 0) = New Point(maze(i, j).x + M, maze(i, j).y)
                            ' End Point
                            maze(i, j).wallPos(k, 1) = New Point(maze(i, j).x + M, maze(i, j).y + M)
                        Case 2 ' Left Line
                            ' Start Point
                            maze(i, j).wallPos(k, 0) = New Point(maze(i, j).x, maze(i, j).y + M)
                            ' End Point
                            maze(i, j).wallPos(k, 1) = New Point(maze(i, j).x + M, maze(i, j).y + M)
                        Case 3 ' Bottom Line
                            ' Start Point
                            maze(i, j).wallPos(k, 0) = New Point(maze(i, j).x, maze(i, j).y)
                            ' End Point
                            maze(i, j).wallPos(k, 1) = New Point(maze(i, j).x, maze(i, j).y + M)
                    End Select
                Next
            Next
        Next
    End Sub

    Private Sub drawMaze(solve As Boolean) ' If False is passed through then the background cells will be drawn
        For Each cell In maze
            If solve = False Then
                ' The Background
                If bgColour <> Color.Empty Then
                    mazeImgaeGraphics.FillRectangle(New SolidBrush(bgColour), cell.wallPos(0, 0).X, cell.wallPos(1, 0).Y, M, M)
                Else
                    mazeImgaeGraphics.FillRectangle(New SolidBrush(Color.White), cell.wallPos(0, 0).X, cell.wallPos(1, 0).Y, M, M)
                End If
            End If
            ' Drawing mazeWalls
            If cell.mazeWallBool = True And mazeColour <> Color.Empty Then
                mazeImgaeGraphics.FillRectangle(New SolidBrush(mazeColour), cell.wallPos(0, 0).X, cell.wallPos(1, 0).Y, M, M)
            ElseIf cell.mazeWallBool = True Then ' If user hasnt selected colour
                mazeImgaeGraphics.FillRectangle(New SolidBrush(Color.Black), cell.wallPos(0, 0).X, cell.wallPos(0, 0).Y, M, M)
            End If
            ' Drawing mazeEntry
            If cell.mazeEntryBool = True Then
                mazeImgaeGraphics.FillRectangle(New SolidBrush(Color.Green), cell.wallPos(0, 0).X, cell.wallPos(1, 0).Y, M, M)
            End If
            ' Drawing mazeEntry
            If cell.mazeExitBool = True Then
                mazeImgaeGraphics.FillRectangle(New SolidBrush(Color.Red), cell.wallPos(0, 0).X, cell.wallPos(1, 0).Y, M, M)
            End If
            ' Drawing mazeSolve
            If cell.mazeSolved = True And solveColour <> Color.Empty Then
                mazeImgaeGraphics.FillRectangle(New SolidBrush(solveColour), cell.wallPos(0, 0).X, cell.wallPos(1, 0).Y, M, M)
            ElseIf cell.mazeSolved = True Then
                mazeImgaeGraphics.FillRectangle(New SolidBrush(Color.Gray), cell.wallPos(0, 0).X, cell.wallPos(1, 0).Y, M, M)
            End If
            If cell.deadEnd = True Then
                mazeImgaeGraphics.FillRectangle(New SolidBrush(Color.Purple), cell.wallPos(0, 0).X, cell.wallPos(1, 0).Y, M, M)
            End If
            ' Drawing walls between cells
            For k As Integer = 0 To 3
                If cell.walls(k) = True And mazeColour <> Color.Empty Then
                    mazeImgaeGraphics.DrawLine(New Pen(mazeColour, 3), cell.wallPos(k, 0), cell.wallPos(k, 1))
                ElseIf cell.walls(k) = True Then ' If user hasnt selected colour
                    mazeImgaeGraphics.DrawLine(New Pen(Color.Black, 3), cell.wallPos(k, 0), cell.wallPos(k, 1))
                End If
            Next

        Next
    End Sub

    Private Sub breakWall(ByVal side As Integer, ByVal x As Integer, ByVal y As Integer)
        Select Case side
            Case 0 ' Take away top wall
                maze(x, y).walls(0) = False
                Try
                    maze(x, y - 1).walls(2) = False
                Catch ex As Exception
                    ' Do nothing as this must be a maze wall
                End Try

            Case 1 ' Take away right wall
                maze(x, y).walls(1) = False
                Try
                    maze(x + 1, y).walls(3) = False
                Catch ex As Exception
                    ' Do nothing as this must be a maze wall
                End Try

            Case 2 ' Take away bottom wall
                maze(x, y).walls(2) = False
                Try
                    maze(x, y + 1).walls(0) = False
                Catch ex As Exception
                    ' Do nothing as this must be a maze wall
                End Try

            Case 3 ' Take away left wall
                maze(x, y).walls(3) = False
                Try
                    maze(x - 1, y).walls(1) = False
                Catch ex As Exception
                    ' Do nothing as this must be a maze wall
                End Try
        End Select
    End Sub

    Private Function checkUnvisitedNeighbours(x As Integer, y As Integer)
        ' If a cell has a open neighbour => output = True
        Dim neighbours As List(Of Boolean) = New List(Of Boolean)
        For pos As Integer = 0 To 3
            Select Case pos
                Case 0 ' Checking above the cell
                    Try
                        If maze(x, y - 1).visited = True Then
                            neighbours.Add(False)
                        Else
                            neighbours.Add(True)
                        End If
                    Catch ex As Exception
                        neighbours.Add(False)
                    End Try
                Case 1 ' Checking right of the cell
                    Try
                        If maze(x + 1, y).visited = True Then
                            neighbours.Add(False)
                        Else
                            neighbours.Add(True)
                        End If
                    Catch ex As Exception
                        neighbours.Add(False)
                    End Try
                Case 2 ' Checking below the cell
                    Try
                        If maze(x, y + 1).visited = True Then
                            neighbours.Add(False)
                        Else
                            neighbours.Add(True)
                        End If
                    Catch ex As Exception
                        neighbours.Add(False)
                    End Try
                Case 3 ' Checking left of the cell
                    Try
                        If maze(x - 1, y).visited = True Then
                            neighbours.Add(False)
                        Else
                            neighbours.Add(True)
                        End If
                    Catch ex As Exception
                        neighbours.Add(False)
                    End Try
            End Select
        Next
        Return neighbours
    End Function

    Private Function checkConnectedCell(x As Integer, y As Integer) ' Checks connection between one cell and its: Top, Right, Bottom, Left neigbour
        Dim connection As List(Of Point) = New List(Of Point)
        For i As Integer = 0 To 3
            Select Case i
                ' Checking [_] connection
                Case 0 ' Top
                    If maze(x, y).walls(0) = False And maze(x, y - 1).walls(2) = False And maze(x, y - 1).mazeWallBool = False Then
                        connection.Add(New Point(x, y - 1))
                    End If
                Case 1 ' Right
                    If maze(x, y).walls(1) = False And maze(x + 1, y).walls(3) = False And maze(x + 1, y).mazeWallBool = False Then
                        connection.Add(New Point(x + 1, y))
                    End If
                Case 2 ' Bottom
                    If maze(x, y).walls(2) = False And maze(x, y + 1).walls(0) = False And maze(x, y + 1).mazeWallBool = False Then
                        connection.Add(New Point(x, y + 1))
                    End If
                Case 3 ' Left
                    If maze(x, y).walls(3) = False And maze(x - 1, y).walls(1) = False And maze(x - 1, y).mazeWallBool = False Then
                        connection.Add(New Point(x - 1, y))
                    End If
            End Select
        Next
        Return connection
    End Function

    Private Function Lerp(ByVal c1 As List(Of Integer), ByVal c2 As List(Of Integer), ByVal t As Double)
        lerpList(0) = (c1(0) + ((c2(0) - c1(0)) * t))
        lerpList(1) = (c1(1) + ((c2(1) - c1(1)) * t))
        lerpList(2) = (c1(2) + ((c2(2) - c1(2)) * t))
        Return lerpList
    End Function

    Private Sub deadEndRemover()
        Dim deadEndCount As Integer = 0
        Dim deadEndPos As List(Of Point) = New List(Of Point)
        ' Count dead ends
        For Each cell In maze
            Dim wallCounter As Integer = 0
            For Each wall In cell.walls
                If wall = True And cell.mazeWallBool = False Then
                    wallCounter += 1
                End If
                If wallCounter = 3 And cell.deadEnd = False Then
                    cell.deadEnd = True
                    deadEndPos.Add(New Point(cell.x / M, cell.y / M))
                    deadEndCount += 1
                End If
            Next
        Next
        ' Calculate corrent amount of dead ends to remove



        drawMaze(False)
        mazeBox.Image = mazeImage
    End Sub

    Private Sub randomisedDFS()
        Randomize()
        ' Backtracking Stack
        Dim stack As Stack(Of Point) = New Stack(Of Point)
        ' Store Current Node
        Dim node As Point = New Point(Int((width - 1) * Rnd()) + 1, Int((height - 1) * Rnd()) + 1)
        stack.Push(node)
        ' List used to check the neigbours of a cell
        Dim neigbours As List(Of Boolean) = New List(Of Boolean)
        Dim direction As Integer

        ' Checking Quick Animations
        If quickAnimationBtn.Checked = False Then ' The want the animation to play
            ' Will loop until the stack is empty 
            While stack.Count <> 0
                neigbours = checkUnvisitedNeighbours(node.X, node.Y)
                direction = Int(4 * Rnd())
                If neigbours(0) = False And neigbours(1) = False And neigbours(2) = False And neigbours(3) = False Then ' There are no open neighbours
                    maze(node.X, node.Y).visited = True
                    node = stack.Pop()
                Else ' There is an open neighbour
                    While neigbours(direction) = False ' Makes sure it moves into an open neighbour
                        direction = Int(4 * Rnd())
                    End While
                    If stack.Peek <> node Then ' Makes sure the first node searched doesnt get inputted twice
                        stack.Push(node)
                    End If
                    maze(node.X, node.Y).visited = True
                    'breakWall(direction, node.X, node.Y)
                    directionList.Add(direction)
                    nodeList.Add(node)
                    ' Changes the value of node depending on what direction
                    Select Case direction
                        Case 0 ' Moved to the cell above
                            node = New Point(node.X, node.Y - 1)
                        Case 1 ' Moved to the cell on the right
                            node = New Point(node.X + 1, node.Y)
                        Case 2 ' Moved to the cell below
                            node = New Point(node.X, node.Y + 1)
                        Case 3 ' Moved to the cell on the left
                            node = New Point(node.X - 1, node.Y)
                    End Select
                End If
            End While
            ' Animation :: Displays the stack header to show which cell is being checked
            drawMaze(False)
            animationLock(True)
            While frame <> directionList.Count
                mazeBox.Image = mazeImage
                breakWall(directionList(frame), nodeList(frame).X, nodeList(frame).Y)
                drawMaze(False)
                mazeImgaeGraphics.FillRectangle(New SolidBrush(Color.Yellow), nodeList(frame).X * M, nodeList(frame).Y * M, M, M)
                mazeBox.Update()
                Thread.Sleep(M)
                frame += 1
            End While
        Else ' They don't want the animation to play
            ' Will loop until the stack is empty 
            While stack.Count <> 0
                neigbours = checkUnvisitedNeighbours(node.X, node.Y)
                direction = Int(4 * Rnd())
                If neigbours(0) = False And neigbours(1) = False And neigbours(2) = False And neigbours(3) = False Then ' There are no open neighbours
                    maze(node.X, node.Y).visited = True
                    node = stack.Pop()
                Else ' There is an open neighbour
                    While neigbours(direction) = False ' Makes sure it moves into an open neighbour
                        direction = Int(4 * Rnd())
                    End While
                    If stack.Peek <> node Then ' Makes sure the first node searched doesnt get inputted twice
                        stack.Push(node)
                    End If
                    maze(node.X, node.Y).visited = True
                    breakWall(direction, node.X, node.Y)
                    directionList.Add(direction)
                    nodeList.Add(node)
                    ' Changes the value of node depending on what direction
                    Select Case direction
                        Case 0 ' Moved to the cell above
                            node = New Point(node.X, node.Y - 1)
                        Case 1 ' Moved to the cell on the right
                            node = New Point(node.X + 1, node.Y)
                        Case 2 ' Moved to the cell below
                            node = New Point(node.X, node.Y + 1)
                        Case 3 ' Moved to the cell on the left
                            node = New Point(node.X - 1, node.Y)
                    End Select
                End If
            End While
        End If
        ' Resets the variables used to animate and removes animation lock
        frame = 0
        directionList.Clear()
        nodeList.Clear()
        drawMaze(False)
        mazeBox.Image = mazeImage
        animationLock(False)
    End Sub

    Private Sub dijkstra()
        Dim startNode As Point = mazeEntry
        Dim endNode As Point = mazeExit
        Dim tempNode As Point
        ' Queue used to store the next cell to be checked
        Dim queue As Queue(Of Point) = New Queue(Of Point)
        Dim visited As List(Of Point) = New List(Of Point)
        Dim weight As Integer = 0

        ' Weight the nodes
        maze(startNode.X, startNode.Y).weight = 0
        visited.Add(startNode)
        weight = 1
        For Each point In checkConnectedCell(startNode.X, startNode.Y)
            queue.Enqueue(point)
        Next
        While queue.Count <> 0 ' Will loop until the queue is empty
            For i = 0 To queue.Count - 1
                tempNode = queue.Dequeue()
                visited.Add(tempNode)
                maze(tempNode.X, tempNode.Y).weight = weight
                weightList.Add(weight)
                nodeList.Add(tempNode)
                If tempNode = endNode Then
                    Exit While
                End If
                ' Adds connected nodes to the queue
                For Each point In checkConnectedCell(tempNode.X, tempNode.Y)
                    If visited.Contains(point) = False And queue.Contains(point) = False Then
                        queue.Enqueue(point)
                    End If
                Next
            Next
            weight += 1
        End While
        ' Checking Quick Animations
        If quickAnimationBtn.Checked = False Then ' The want the animation to play

            ' Animation :: Shows the branches that are being weighted
            animationLock(True)
            lerpList = Lerp(c1, c1, t)
            While frame <> nodeList.Count()

                mazeBox.Image = mazeImage

                mazeImgaeGraphics.FillRectangle(New SolidBrush(Color.FromArgb(lerpList(0), lerpList(1), lerpList(2))), nodeList(frame).X * M, nodeList(frame).Y * M, M, M)
                If frame < 200 Then
                    lerpList = Lerp(lerpList, c2, t)
                ElseIf frame > 200 And frame < 400 Then
                    lerpList = Lerp(lerpList, c3, t)
                ElseIf frame > 400 And frame < 600 Then
                    lerpList = Lerp(lerpList, c4, t)
                ElseIf frame > 600 And frame < 800 Then
                    lerpList = Lerp(lerpList, c2, t)
                ElseIf frame > 800 And frame < 1000 Then
                    lerpList = Lerp(lerpList, c3, t)
                ElseIf frame > 1000 And frame < 1200 Then
                    lerpList = Lerp(lerpList, c4, t)
                End If
                fps.Text = frame
                fps.Update()
                drawMaze(True)
                mazeBox.Update()
                Thread.Sleep(M)
                frame += 1
            End While
            ' Resets the variables used to animate and removes animation lock
            nodeList.Clear()
            weightList.Clear()
            frame = 0
            animationLock(False)
            ' Finds the shortest path from the start node
            While endNode <> startNode
                For Each node In visited
                    If maze(node.X, node.Y).weight < maze(endNode.X, endNode.Y).weight And checkConnectedCell(endNode.X, endNode.Y).Contains(node) Then
                        nodeList.Add(node)
                        endNode = node
                        Exit For
                    End If
                Next
            End While
            nodeList.Reverse()
            ' Removes the start node to be overdrawn
            nodeList.Remove(startNode)
            maze(startNode.X, startNode.Y).mazeSolved = False
            ' Animation :: Shows the shortest path being created
            While frame <> nodeList.Count()
                mazeBox.Image = mazeImage
                maze(nodeList(frame).X, nodeList(frame).Y).mazeSolved = True
                drawMaze(True)
                mazeBox.Update()
                Thread.Sleep(M)
                frame += 1
            End While
        Else ' They don't want the animation to play
            ' Finds the shortest path from the start node
            While endNode <> startNode
                For Each node In visited
                    If maze(node.X, node.Y).weight < maze(endNode.X, endNode.Y).weight And checkConnectedCell(endNode.X, endNode.Y).Contains(node) Then
                        maze(node.X, node.Y).mazeSolved = True
                        endNode = node
                        Exit For
                    End If
                Next
            End While
            ' Removes the start node to be overdrawn
            maze(startNode.X, startNode.Y).mazeSolved = False
        End If
        ' Resets the variables used to animate and removes animation lock
        drawMaze(False)
        mazeBox.Image = mazeImage
        nodeList.Clear()
        frame = 0
        animationLock(False)
    End Sub

    Private Sub animationLock(Lock As Boolean) ' Locks all inputs to prevent backlogging and crashes
        If Lock = True Then
            ' Generate Button
            generateBtn.BackColor = Color.FromArgb(74, 145, 74)
            generateBtn.Enabled = False
            ' Solve Button
            solveBtn.BackColor = Color.FromArgb(142, 72, 72)
            solveBtn.Enabled = False
            ' Rest Button
            imageInputBtn.BackColor = Color.FromArgb(152, 158, 161)
            imageInputBtn.Enabled = False
            bgColourBtn.BackColor = Color.FromArgb(152, 158, 161)
            bgColourBtn.Enabled = False
            mazeColourBtn.BackColor = Color.FromArgb(152, 158, 161)
            mazeColourBtn.Enabled = False
            solveColourBtn.BackColor = Color.FromArgb(152, 158, 161)
            solveColourBtn.Enabled = False
            ' Rest TextBoxs
            downloadBtn.BackColor = Color.FromArgb(152, 158, 161)
            downloadBtn.Enabled = False
            viewStatsBtn.BackColor = Color.FromArgb(152, 158, 161)
            viewStatsBtn.Enabled = False
            widthTxtBox.BackColor = Color.FromArgb(152, 158, 161)
            widthTxtBox.Enabled = False
            heightTxtBox.BackColor = Color.FromArgb(152, 158, 161)
            heightTxtBox.Enabled = False
            deadEndRemoverTxtBox.BackColor = Color.FromArgb(152, 158, 161)
            deadEndRemoverTxtBox.Enabled = False
            ' Rest ComboBoxs
            generationCombo.BackColor = Color.FromArgb(152, 158, 161)
            generationCombo.Enabled = False
            solveCombo.BackColor = Color.FromArgb(152, 158, 161)
            solveCombo.Enabled = False
            mazeEntryCombo.BackColor = Color.FromArgb(152, 158, 161)
            mazeEntryCombo.Enabled = False
        Else
            ' Generate Button
            generateBtn.BackColor = Color.FromArgb(128, 255, 128)
            generateBtn.Enabled = True
            ' Solve Button
            solveBtn.BackColor = Color.FromArgb(255, 128, 128)
            solveBtn.Enabled = True
            ' Rest Button
            downloadBtn.BackColor = SystemColors.Window
            downloadBtn.Enabled = True
            viewStatsBtn.BackColor = SystemColors.Window
            viewStatsBtn.Enabled = True
            imageInputBtn.BackColor = SystemColors.Window
            imageInputBtn.Enabled = True
            bgColourBtn.BackColor = SystemColors.Window
            bgColourBtn.Enabled = True
            mazeColourBtn.BackColor = SystemColors.Window
            mazeColourBtn.Enabled = True
            solveColourBtn.BackColor = SystemColors.Window
            solveColourBtn.Enabled = True
            ' Rest TextBoxs
            widthTxtBox.BackColor = SystemColors.Window
            widthTxtBox.Enabled = True
            heightTxtBox.BackColor = SystemColors.Window
            heightTxtBox.Enabled = True
            deadEndRemoverTxtBox.BackColor = SystemColors.Window
            deadEndRemoverTxtBox.Enabled = True
            ' Rest ComboBoxs
            generationCombo.BackColor = SystemColors.Window
            generationCombo.Enabled = True
            solveCombo.BackColor = SystemColors.Window
            solveCombo.Enabled = True
            mazeEntryCombo.BackColor = SystemColors.Window
            mazeEntryCombo.Enabled = True
        End If
    End Sub

    ' USER INPUT START
    Private Sub generateBtn_Click(sender As Object, e As EventArgs) Handles generateBtn.Click
        ' Saves Maze Properties inputted by the user
        width = Int(widthTxtBox.Text) - 1
        height = Int(heightTxtBox.Text) - 1
        If Double.TryParse(deadEndRemoverTxtBox.Text, deadEndPercent) Then
            ' Input was a decimal

        End If
        ' Combo Box Inputs
        mazeEntryType = mazeEntryCombo.Text
        generationAlgorithm = generationCombo.Text

        initializeMazeDraw()
        If generationAlgorithm = "DFS Backtracker" Then
            mazeBox.Image = mazeImage
            randomisedDFS()
        End If

        deadEndRemover()

    End Sub

    Private Sub solveBtn_Click(sender As Object, e As EventArgs) Handles solveBtn.Click
        solveAlgorithm = solveCombo.Text
        ' Reset all cells that have .mazeSolved = True
        For Each cell In maze
            If cell.mazeSolved = True Then
                cell.mazeSolved = False
            End If
        Next
        drawMaze(False) ' Clear the previously drawn path

        If solveAlgorithm = "Dijkstra's Algorithm" Then
            dijkstra()
        End If
    End Sub

    ' Setting Colour Customisation
    Function selectColour() As Color ' Opens a colour picker and returns the selected colour
        colorDialog.ShowDialog() ' Opens colour picker
        Return colorDialog.Color ' Returns picked colour
    End Function

    Private Sub bgColourBtn_Click(sender As Object, e As EventArgs) Handles bgColourBtn.Click
        bgColour = selectColour() ' Selects background colour 
        bgColourBtn.Text = bgColour.ToString
    End Sub

    Private Sub mazeColourBtn_Click(sender As Object, e As EventArgs) Handles mazeColourBtn.Click
        mazeColour = selectColour() ' Selects maze colour 
        mazeColourBtn.Text = mazeColour.ToString
    End Sub

    Private Sub solveColourBtn_Click(sender As Object, e As EventArgs) Handles solveColourBtn.Click
        solveColour = selectColour() ' Selects solve colour 
        solveColourBtn.Text = solveColour.ToString
    End Sub

    Private Sub downloadBtn_Click(sender As Object, e As EventArgs) Handles downloadBtn.Click
        If mazeImage.Equals(Nothing) = False Then
            Dim openFile As New SaveFileDialog
            openFile.FileName = Nothing
            openFile.Filter = "Bitmap File's |*.svg"
            openFile.ShowDialog()
            Try
                mazeImage.Save(openFile.FileName)
            Catch ex As Exception
                ' They didn't select a file location
            End Try
        End If
    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles fps.Click

    End Sub

    ' USER INPUT END
End Class