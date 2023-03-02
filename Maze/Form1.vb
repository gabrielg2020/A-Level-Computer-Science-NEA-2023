Imports System.Threading
Public Class Form1
    ' Drawing Constants
    Const PEN_SIZE As Integer = 2
    Const M As Integer = 10
    ' Maze properties
    Public maze As Cell(,)
    Public width As Integer
    Public height As Integer
    Public deadEndPercent As Double
    Public mazeEntryType As String
    Public mazeEntry As Point
    Public mazeExit As Point
    Public deadEndPos As List(Of Point) = New List(Of Point)
    ' Maze Colour Customisation
    Public bgColour As Color
    Public mazeColour As Color
    Public solveColour As Color
    ' Maze Generation/Solving Inputs
    Public generationAlgorithm As String
    Public solveAlgorithm As String
    ' Controls when the from draws
    Public mazeImage As Bitmap
    Public mazeImageGraphics As Graphics
    ' Stats Variables
    Public deadEndToShow As Integer
    Public solveTimer As Stopwatch = New Stopwatch
    Public generationTimer As Stopwatch = New Stopwatch
    Public drawTimer As Stopwatch = New Stopwatch

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
        Public connectedCell As List(Of Point) = New List(Of Point)

        ' Sets all cells with all walls 
        Public Sub New()
            For i As Integer = 0 To 3
                walls.Add(True)
            Next
        End Sub

        ' Method to draw walls
        Public Sub drawWalls()
            For wall As Integer = 0 To 3
                If walls(wall) = True And Form1.mazeColour = Color.Empty Then
                    Form1.mazeImageGraphics.DrawLine(New Pen(Color.Black, PEN_SIZE), wallPos(wall, 0), wallPos(wall, 1))
                    Form1.mazeImageGraphics.DrawLine(New Pen(Color.Black, PEN_SIZE), wallPos(wall, 0), wallPos(wall, 1))
                ElseIf walls(wall) = True Then ' If user hasnt selected colour
                    Form1.mazeImageGraphics.DrawLine(New Pen(Form1.mazeColour, PEN_SIZE), wallPos(wall, 0), wallPos(wall, 1))
                    Form1.mazeImageGraphics.DrawLine(New Pen(Form1.mazeColour, PEN_SIZE), wallPos(wall, 0), wallPos(wall, 1))
                End If
            Next
        End Sub

        Public Sub deadEndFinder()
            Dim wallCount As Integer = 0
            ' Checks each wall
            For Each wall In walls
                If wall = True And mazeWallBool = False Then
                    wallCount += 1
                End If
                If wallCount = 3 Then
                    Form1.deadEndPos.Add(New Point(x, y))
                End If
            Next
        End Sub

        ' Method to break wall
        Public Function breakWall(ByVal d As Integer)
            ' Makes sure the cell isn't a maze wall
            If mazeWallBool = True Then
                Return Nothing
                Exit Function
            End If
            ' Breaks wall depending on the d (direction)
            Select Case d
                ' The wall selected must be broken but also the neighbours wall
                Case 0 ' Breaking the top wall
                    If Form1.maze(x, y - 1).mazeWallBool = True Then
                        Return Nothing
                        Exit Function
                    End If
                    walls(d) = False
                    Form1.maze(x, y - 1).walls(d + 2) = False
                    connectedCell.Add(New Point(x, y - 1))
                    Form1.maze(x, y - 1).connectedCell.Add(New Point(x, y))
                Case 1 ' Breaking the right wall
                    If Form1.maze(x + 1, y).mazeWallBool = True Then
                        Return Nothing
                        Exit Function
                    End If
                    walls(d) = False
                    Form1.maze(x + 1, y).walls(d + 2) = False
                    connectedCell.Add(New Point(x + 1, y))
                    Form1.maze(x + 1, y).connectedCell.Add(New Point(x, y))
                Case 2 ' Breaking the bottom wall
                    If Form1.maze(x, y + 1).mazeWallBool = True Then
                        Return Nothing
                        Exit Function
                    End If
                    walls(d) = False
                    Form1.maze(x, y + 1).walls(d - 2) = False
                    connectedCell.Add(New Point(x, y + 1))
                    Form1.maze(x, y + 1).connectedCell.Add(New Point(x, y))
                Case 3 ' Breaking the left wall
                    If Form1.maze(x - 1, y).mazeWallBool = True Then
                        Return Nothing
                        Exit Function
                    End If
                    walls(d) = False
                    Form1.maze(x - 1, y).walls(d - 2) = False
                    connectedCell.Add(New Point(x - 1, y))
                    Form1.maze(x - 1, y).connectedCell.Add(New Point(x, y))
            End Select
            Return connectedCell(connectedCell.Count() - 1)
        End Function

        ' Method to check unvisted neighbours
        Public Function checkUnvistedNeighbours()
            Dim neighbours As List(Of Point) = New List(Of Point)

            If mazeWallBool = True Then
                Return Nothing
                Exit Function
            End If

            If Form1.maze(x, y - 1).visited = False Then
                neighbours.Add(New Point(x, y - 1))
            Else
                neighbours.Add(Nothing)
            End If

            If Form1.maze(x + 1, y).visited = False Then
                neighbours.Add(New Point(x + 1, y))
            Else
                neighbours.Add(Nothing)
            End If

            If Form1.maze(x, y + 1).visited = False Then
                neighbours.Add(New Point(x, y + 1))
            Else
                neighbours.Add(Nothing)
            End If

            If Form1.maze(x - 1, y).visited = False Then
                neighbours.Add(New Point(x - 1, y))
            Else
                neighbours.Add(Nothing)
            End If
            Return neighbours
        End Function
    End Class
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        generationCombo.SelectedIndex = 0 ' Makes index 0 default displayed on the combo list(so currently shows "DFS Backtracker" initially
        solveCombo.SelectedIndex = 0 ' Default displays (Dijkstra's Algortimn)
        mazeEntryCombo.SelectedIndex = 0 ' Default displays "Random"
    End Sub
    Private Sub initializeMaze()
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
        mazeImage = New Bitmap(((width + 1) * M) + M, ((height + 1) * M) + M)
        mazeImageGraphics = Graphics.FromImage(mazeImage)
        For i As Integer = 0 To width
            For j As Integer = 0 To height
                ' Giving each cell their index
                maze(i, j) = New Cell
                maze(i, j).x = i
                maze(i, j).y = j

                ' Setting the entry cell with the mazeEntryBool
                If i = mazeEntry.X And j = mazeEntry.Y Then
                    maze(i, j).mazeEntryBool = True
                End If

                ' Setting the exit cell with the mazeExitBool
                If i = mazeExit.X And j = mazeExit.Y Then
                    maze(i, j).mazeExitBool = True
                End If

                ' Setting the maze wall cells with the mazeWallBool
                If i = 0 Or j = 0 Or i = width Or j = height Then
                    maze(i, j).mazeWallBool = True
                    maze(i, j).visited = True
                End If

                ' Giving each cell wall a start(0), end(1) and position on the screen
                Dim posi As Integer = i * M
                Dim posj As Integer = j * M
                For Each wall In maze(i, j).walls
                    ' Top Wall
                    maze(i, j).wallPos(0, 0) = New Point(posi, posj)
                    maze(i, j).wallPos(0, 1) = New Point(posi + M, posj)
                    ' Right Wall
                    maze(i, j).wallPos(1, 0) = New Point(posi + M, posj)
                    maze(i, j).wallPos(1, 1) = New Point(posi + M, posj + M)
                    ' Bottom Wall
                    maze(i, j).wallPos(2, 0) = New Point(posi, posj + M)
                    maze(i, j).wallPos(2, 1) = New Point(posi + M, posj + M)
                    ' Left Wall
                    maze(i, j).wallPos(3, 0) = New Point(posi, posj)
                    maze(i, j).wallPos(3, 1) = New Point(posi, posj + M)
                Next
            Next
        Next
    End Sub
    Private Sub drawMaze() ' If False is passed through then the background cells will be drawn
        drawTimer.Reset()
        drawTimer.Start()
        For Each cell In maze
            ' Drawing the background
            If bgColour <> Color.Empty Then
                mazeImageGraphics.FillRectangle(New SolidBrush(bgColour), cell.wallPos(0, 0).X, cell.wallPos(1, 0).Y, M, M)
            Else ' If user hasnt selected colour
                mazeImageGraphics.FillRectangle(New SolidBrush(Color.White), cell.wallPos(0, 0).X, cell.wallPos(1, 0).Y, M, M)
            End If

            ' Drawing mazeWalls
            If cell.mazeWallBool = True And mazeColour <> Color.Empty Then
                mazeImageGraphics.FillRectangle(New SolidBrush(mazeColour), cell.wallPos(0, 0).X, cell.wallPos(1, 0).Y, M, M)
            ElseIf cell.mazeWallBool = True Then ' If user hasnt selected colour
                mazeImageGraphics.FillRectangle(New SolidBrush(Color.Black), cell.wallPos(0, 0).X, cell.wallPos(1, 0).Y, M, M)
            End If

            ' Drawing the mazeEntry
            If cell.mazeEntryBool = True Then
                mazeImageGraphics.FillRectangle(New SolidBrush(Color.Green), cell.wallPos(0, 0).X, cell.wallPos(1, 0).Y, M, M)
            End If

            ' Drawing mazeExit
            If cell.mazeExitBool = True Then
                mazeImageGraphics.FillRectangle(New SolidBrush(Color.Red), cell.wallPos(0, 0).X, cell.wallPos(1, 0).Y, M, M)
            End If

            ' Drawing the solved path
            If cell.mazeSolved = True Then
                mazeImageGraphics.FillRectangle(New SolidBrush(Color.Gray), cell.wallPos(0, 0).X, cell.wallPos(1, 0).Y, M, M)
            End If

            ' Drawing the walls
            cell.drawWalls()
        Next
        drawTimer.Stop()
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
    Private Sub animate(Optional ByVal node As Point = Nothing, Optional ByVal heatList As List(Of Point) = Nothing)
        drawMaze()
        ' Wants to animate a header cell
        If node <> Nothing Then
            mazeImageGraphics.FillRectangle(New SolidBrush(Color.Yellow), node.X * M, node.Y * M, M, M)
        End If
        ' Wants a heat path to be drawn
        If heatList IsNot Nothing Then
            For Each point In heatList
                ' Don't want to draw over the maze entry
                If point <> mazeEntry Then
                    mazeImageGraphics.FillRectangle(New SolidBrush(Color.FromArgb(255, 0, 220)), point.X * M, point.Y * M, M, M)
                    ' Draws walls
                    For Each cell In maze
                        cell.drawWalls()
                    Next
                    ' Updates Maze box
                    mazeBox.Image = mazeImage
                    mazeBox.Update()
                    Thread.Sleep(10)
                End If
            Next
        End If
        ' Updates Maze box
        mazeBox.Image = mazeImage
        mazeBox.Update()
        Thread.Sleep(10)
    End Sub
    Private Sub randomisedDFS()
        ' Backtracking Stack
        Dim stack As Stack(Of Point) = New Stack(Of Point)
        ' Randomly picks a node on the maze
        Randomize()
        Dim node As Point = New Point(Int((width - 1) * Rnd()) + 1, Int((height - 1) * Rnd()) + 1)
        ' List used to store unvisted neighbours
        Dim neighbours As List(Of Point) = New List(Of Point)
        Dim direction As Integer

        ' Push current node to the stack
        stack.Push(node)
        ' Until the stack is empty:
        While stack.Count <> 0
            ' Check neighbours
            neighbours = maze(node.X, node.Y).checkUnvistedNeighbours
            ' Pick a random direction
            direction = Int(4 * Rnd())
            ' If there is no open neighbours
            If neighbours(0) = Nothing And neighbours(1) = Nothing And neighbours(2) = Nothing And neighbours(3) = Nothing Then
                maze(node.X, node.Y).visited = True
                node = stack.Pop()
            Else
                ' Makes sure it moves into an open neighbour
                While neighbours(direction) = Nothing
                    direction = Int(4 * Rnd())
                End While
                ' Makes sure the first node searched doesnt get inputted twice
                If stack.Peek <> node Then
                    stack.Push(node)
                End If
                ' Mark the cell as visted
                maze(node.X, node.Y).visited = True
                ' Break the wall between the cells and set node = postion of the cell we just broke into
                node = maze(node.X, node.Y).breakWall(direction)
                ' Checks if user wants quick animations
                If instantAnimationBtn.Checked <> True Then
                    ' Enable animation lock
                    animationLock(True)
                    ' Upadate mazeBox
                    animate(node)
                End If
            End If
        End While
        ' Disable animation lock
        animationLock(False)
    End Sub
    Private Sub dijkstra()
        ' Queue 
        Dim queue As Queue(Of Point) = New Queue(Of Point)
        Dim visitedNodes As List(Of Point) = New List(Of Point)
        ' Set the start node's weight = 0
        maze(mazeEntry.X, mazeEntry.Y).weight = 0
        ' Adds cell to the visted list
        visitedNodes.Add(mazeEntry)
        Dim weight As Integer = 1

        ' Adds all connected cells to the queue
        For Each point In maze(mazeEntry.X, mazeEntry.Y).connectedCell
            queue.Enqueue(point)
        Next

        ' Until queue is empty::
        While queue.Count <> 0
            For i = 0 To queue.Count - 1
                Dim tempNode As Point = queue.Dequeue()
                visitedNodes.Add(tempNode)
                maze(tempNode.X, tempNode.Y).weight = weight

                ' ::Or we reach the maze exit
                If tempNode = mazeExit Then
                    Exit While
                End If
                ' If the we haven't visted that cell and its not in our queue already we add it to the queue
                For Each point In maze(tempNode.X, tempNode.Y).connectedCell
                    If visitedNodes.Contains(point) = False And queue.Contains(point) = False Then
                        queue.Enqueue(point)
                    End If
                Next
            Next
            ' Increase weight
            weight += 1
        End While
        ' Checks if user wants quick animations
        If instantAnimationBtn.Checked <> True Then
            ' Enable animation lock
            animationLock(True)
            ' Shows the heat map, higher heat = higher weight
            animate(Nothing, visitedNodes)
        End If

        Dim endNode As Point = mazeExit
        ' We will traverse the maze until we reach the maze entry
        ' Until we reach the maze entry
        While endNode <> mazeEntry
            For Each node In visitedNodes
                If maze(node.X, node.Y).weight < maze(endNode.X, endNode.Y).weight And maze(endNode.X, endNode.Y).connectedCell.Contains(node) Then
                    maze(node.X, node.Y).mazeSolved = True
                    ' Checks if user wants quick animations
                    If instantAnimationBtn.Checked <> True Then
                        ' Shows the creation of the shortest path
                        animate()
                    End If

                    endNode = node
                    Exit For
                End If
            Next
        End While
        maze(mazeEntry.X, mazeEntry.Y).mazeSolved = False
        ' Disables animation lock
        animationLock(False)
    End Sub
    Private Sub deadEndRemover()
        Dim numToBeRemoved As Integer
        Dim direction As Integer
        Dim positionPicked As Integer
        Dim initalDeadEnds As Integer
        ' Finds all the dead ends
        For Each cell In maze
            cell.deadEndFinder()
        Next
        ' Calculate the amount of dead end to remove
        numToBeRemoved = Math.Round(deadEndPos.Count() * deadEndPercent)

        While numToBeRemoved <> 0
            ' Randomly pick a deadend and direction
            positionPicked = Int(deadEndPos.Count() * Rnd())
            direction = Int(4 * Rnd())
            ' Makes sure that it doesn't break into a maze wall
            While maze(deadEndPos(positionPicked).X, deadEndPos(positionPicked).Y).breakWall(direction) = Nothing
                direction = Int(4 * Rnd())
            End While

            ' Break the deadend
            maze(deadEndPos(positionPicked).X, deadEndPos(positionPicked).Y).breakWall(direction)
            initalDeadEnds = deadEndPos.Count()
            ' Find the new amount of deadends
            deadEndPos.Clear()
            For Each cell In maze
                cell.deadEndFinder()
            Next
            ' The amount needed to be removed is the amount of dead ends it had initally - the amount of dead ends it has now
            ' This is useful as removing 1 wall can remove 2 deadends
            numToBeRemoved -= initalDeadEnds - deadEndPos.Count()
            ' If we have ran out of dead ends to remove
            If deadEndPos.Count = 0 Then
                Exit While
            End If
        End While
        deadEndPos.Clear()
    End Sub
    ' USER INPUT START
    Private Sub generateBtn_Click(sender As Object, e As EventArgs) Handles generateBtn.Click
        ' Saves Maze Properties inputted by the user
        width = Int(widthTxtBox.Text) - 1
        height = Int(heightTxtBox.Text) - 1
        mazeEntryType = mazeEntryCombo.Text
        generationAlgorithm = generationCombo.Text
        deadEndPercent = deadEndRemoverTxtBox.Text
        ' Intializes the maze
        initializeMaze()

        ' Checks what generation algorithm user has chosen
        generationTimer.Reset()
        generationTimer.Start()
        If generationAlgorithm = "DFS Backtracker" Then
            randomisedDFS()
        End If
        generationTimer.Stop()
        ' Upadtes Maze box
        drawMaze()
        mazeBox.Image = mazeImage

        ' Updates Statistics
        ' Find the dead end count
        For Each cell In maze
            cell.deadEndFinder()
        Next
        deadEndToShow = deadEndPos.Count()
        deadEndPos.Clear()
        ' Displays Data
        genTimeLbl.Text = "Generation Time: " & Str(generationTimer.ElapsedMilliseconds() / 1000) & "s"
        solveTimeLbl.Text = "Sove Time: " & Str(solveTimer.ElapsedMilliseconds() / 1000) & "s"
        drawTimeLbl.Text = "Draw Time: " & Str(drawTimer.ElapsedMilliseconds() / 1000) & "s"
        deadEndCountLbl.Text = "Dead End Count: " & Str(deadEndToShow)
    End Sub

    Private Sub solveBtn_Click(sender As Object, e As EventArgs) Handles solveBtn.Click
        solveAlgorithm = solveCombo.Text
        ' Reset all cells that have .mazeSolved = True
        For Each cell In maze
            cell.mazeSolved = False
        Next

        ' Checks what solving algorithm user has chosen
        solveTimer.Reset()
        solveTimer.Start()
        If solveAlgorithm = "Dijkstra's Algorithm" Then
            dijkstra()
        End If
        solveTimer.Stop()
        ' Upadtes Maze box
        drawMaze()
        mazeBox.Image = mazeImage
    End Sub
    Private Sub deadEndRemoverBtn_Click(sender As Object, e As EventArgs) Handles deadEndRemoverBtn.Click
        ' Saves the inputted percentage
        deadEndPercent = deadEndRemoverTxtBox.Text
        ' Removes dead ends
        deadEndRemover()
        ' Removes the solved value for each cell
        For Each cell In maze
            cell.mazeSolved = False
        Next
        ' Upadtes Maze box
        drawMaze()
        mazeBox.Image = mazeImage
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
            openFile.Filter = "Bitmap File's |*.jpg"
            openFile.ShowDialog()
            Try
                mazeImage.Save(openFile.FileName)
            Catch ex As Exception
                ' They didn't select a file location
            End Try
        End If
    End Sub
    ' USER INPUT END
End Class
