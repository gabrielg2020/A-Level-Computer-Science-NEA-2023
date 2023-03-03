﻿Imports System.Threading
Public Class Form1
    ' Drawing Variables
    Const PEN_SIZE As Integer = 2
    Private M As Integer = 3
    ' Maze properties
    Private maze As Cell(,)
    Private width As Integer
    Private height As Integer
    Private deadEndPercent As Double
    Private mazeEntryType As String
    Private mazeEntry As Point
    Private mazeExit As Point
    Private deadEndPos As List(Of Point) = New List(Of Point)
    ' Maze Colour Customisation
    Private bgColour As Color
    Private mazeColour As Color
    Private solveColour As Color
    ' Maze Generation/Solving Inputs
    Private generationAlgorithm As String
    Private solveAlgorithm As String
    ' Controls when the from draws
    Private mazeImage As Bitmap
    Private mazeImageGraphics As Graphics
    Dim downlaodGenerated As DialogResult
    Dim downlaodSolved As DialogResult
    ' Stats Variables
    Private deadEndToShow As Integer
    Private solveTimer As Stopwatch = New Stopwatch
    Private generationTimer As Stopwatch = New Stopwatch
    Private drawTimer As Stopwatch = New Stopwatch
    Private deadEndTimer As Stopwatch = New Stopwatch
    ' Babyproofing Variables
    Private mazeGenerated As Boolean = False
    ' Image to maze Variables
    Private inputImage As Bitmap
    Private mazeWallList As List(Of Point) = New List(Of Point)
    Private luminosity As Double
    Const GAMMA As Double = 1.0
    Const R As Double = 0.2126
    Const G As Double = 0.7152
    Const B As Double = 0.0722

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
        Private deadEnd As Boolean = False
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
        ' GUI Customisation
        imageInputBtn.BackColor = Color.FromArgb(40, 60, 86)
        widthTxtBox.BackColor = Color.FromArgb(40, 60, 86)
        heightTxtBox.BackColor = Color.FromArgb(40, 60, 86)
        generationCombo.BackColor = Color.FromArgb(40, 60, 86)
        solveCombo.BackColor = Color.FromArgb(40, 60, 86)
        mazeEntryCombo.BackColor = Color.FromArgb(40, 60, 86)
        deadEndRemoverTxtBox.BackColor = Color.FromArgb(40, 60, 86)
        bgColourBtn.BackColor = Color.FromArgb(40, 60, 86)
        mazeColourBtn.BackColor = Color.FromArgb(40, 60, 86)
        solveColourBtn.BackColor = Color.FromArgb(40, 60, 86)
        statsPictureBox.BackColor = Color.FromArgb(40, 60, 86)
        genTimeLbl.BackColor = Color.FromArgb(40, 60, 86)
        solveTimeLbl.BackColor = Color.FromArgb(40, 60, 86)
        drawTimeLbl.BackColor = Color.FromArgb(40, 60, 86)
        deadEndTimeLbl.BackColor = Color.FromArgb(40, 60, 86)
        deadEndCountLbl.BackColor = Color.FromArgb(40, 60, 86)
        totalTimeLbl.BackColor = Color.FromArgb(40, 60, 86)


        Me.WindowState = FormWindowState.Maximized
        generationCombo.SelectedIndex = 0 ' Makes index 0 default displayed on the combo list(so currently shows "DFS Backtracker" initially
        solveCombo.SelectedIndex = 0 ' Default displays (Dijkstra's Algortimn)
        mazeEntryCombo.SelectedIndex = 0 ' Default displays "Random"
    End Sub
    Private Sub initializeMaze()
        ' Resets old timer, Starts new timer, Upates Status
        statusLbl.Text = "Status: Initializing Maze"
        statusLbl.Update()
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
                If i = 0 Or j = 0 Or i = width Or j = height Or mazeWallList.Contains(New Point(i, j)) Then
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
        ' Resets old timer, Starts new timer, Upates Status
        drawTimer.Reset()
        drawTimer.Start()
        statusLbl.Text = "Status: Drawing Maze"
        statusLbl.Update()
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
            generateBtn.BackColor = Color.FromArgb(18, 73, 18)
            generateBtn.Enabled = False
            ' Solve Button
            solveBtn.BackColor = Color.FromArgb(112, 22, 22)
            solveBtn.Enabled = False
            ' Dead End Remover Button
            deadEndRemoverBtn.BackColor = Color.FromArgb(0, 73, 73)
            deadEndRemoverBtn.Enabled = False
            ' Download Button
            downloadBtn.BackColor = Color.FromArgb(19, 28, 40)
            downloadBtn.Enabled = False
            ' Rest Button
            imageInputBtn.BackColor = Color.FromArgb(19, 28, 40)
            imageInputBtn.Enabled = False
            bgColourBtn.BackColor = Color.FromArgb(19, 28, 40)
            bgColourBtn.Enabled = False
            mazeColourBtn.BackColor = Color.FromArgb(19, 28, 40)
            mazeColourBtn.Enabled = False
            solveColourBtn.BackColor = Color.FromArgb(19, 28, 40)
            solveColourBtn.Enabled = False
            ' Rest TextBoxs
            widthTxtBox.BackColor = Color.FromArgb(19, 28, 40)
            widthTxtBox.Enabled = False
            heightTxtBox.BackColor = Color.FromArgb(19, 28, 40)
            heightTxtBox.Enabled = False
            deadEndRemoverTxtBox.BackColor = Color.FromArgb(19, 28, 40)
            deadEndRemoverTxtBox.Enabled = False
            ' Rest ComboBoxs
            generationCombo.BackColor = Color.FromArgb(19, 28, 40)
            generationCombo.Update()
            solveCombo.BackColor = Color.FromArgb(19, 28, 40)
            solveCombo.Update()
            mazeEntryCombo.BackColor = Color.FromArgb(19, 28, 40)
            mazeEntryCombo.Update()
        Else
            ' Generate Button
            generateBtn.BackColor = Color.ForestGreen
            generateBtn.Enabled = True
            ' Solve Button
            solveBtn.BackColor = Color.Firebrick
            solveBtn.Enabled = True
            ' Dead End Remover Button
            deadEndRemoverBtn.BackColor = Color.DarkCyan
            deadEndRemoverBtn.Enabled = True
            ' Download Button
            downloadBtn.BackColor = Color.PaleVioletRed
            downloadBtn.Enabled = True
            ' Rest Button
            imageInputBtn.BackColor = Color.FromArgb(40, 60, 86)
            imageInputBtn.Enabled = True
            bgColourBtn.BackColor = Color.FromArgb(40, 60, 86)
            bgColourBtn.Enabled = True
            mazeColourBtn.BackColor = Color.FromArgb(40, 60, 86)
            mazeColourBtn.Enabled = True
            solveColourBtn.BackColor = Color.FromArgb(40, 60, 86)
            solveColourBtn.Enabled = True
            ' Rest TextBoxs
            widthTxtBox.BackColor = Color.FromArgb(40, 60, 86)
            widthTxtBox.Enabled = True
            heightTxtBox.BackColor = Color.FromArgb(40, 60, 86)
            heightTxtBox.Enabled = True
            deadEndRemoverTxtBox.BackColor = Color.FromArgb(40, 60, 86)
            deadEndRemoverTxtBox.Enabled = True
            ' Rest ComboBoxs
            generationCombo.BackColor = Color.FromArgb(40, 60, 86)
            generationCombo.Enabled = True
            solveCombo.BackColor = Color.FromArgb(40, 60, 86)
            solveCombo.Enabled = True
            mazeEntryCombo.BackColor = Color.FromArgb(40, 60, 86)
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
            ' Checks if user wants quick animations
            If instantAnimationBtn.Checked <> True Then
                ' Enable animation lock
                animationLock(True)
                ' Upadate mazeBox
                animate(New Point(deadEndPos(positionPicked).X, deadEndPos(positionPicked).Y))
            End If
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
        animationLock(False)
    End Sub
    ' USER INPUT START
    Private Sub generateBtn_Click(sender As Object, e As EventArgs) Handles generateBtn.Click
        ' Saves Maze Properties inputted by the user
        ' Checking that the values inputed for width and height are valid
        If Integer.TryParse(widthTxtBox.Text, width) And width > 2 And Integer.TryParse(heightTxtBox.Text, height) And height > 2 Then
            width -= 1
            height -= 1
        Else
            MsgBox("Make sure width and height are integers greater than 3", MsgBoxStyle.OkOnly, "Invalid Input")
            Exit Sub
        End If

        mazeEntryType = mazeEntryCombo.Text
        generationAlgorithm = generationCombo.Text


        ' Changes multiplier value depending on the maze size
        If Math.Floor(Math.Min(1220 / Int(widthTxtBox.Text), 690 / Int(heightTxtBox.Text))) < 3 Then
            downlaodGenerated = MsgBox("Maze is too big to display!" & vbCrLf & "Want to download?" & vbCrLf & "WARNING! DEPENDING ON HARDWARE THIS MAY TAKE A LONG TIME", MsgBoxStyle.OkCancel, "Maze too big!")
            ' If they want to download the maze will generate, statistics will be show and the maze will be downloaded
            If downlaodGenerated = DialogResult.OK Then
                instantAnimationBtn.Checked = True
                M = 3
            Else
                ' If they dont wan to download it will reset statistics and exit the sub
                genTimeLbl.Text = "Generation Time: "
                solveTimeLbl.Text = "Sove Time: "
                drawTimeLbl.Text = "Draw Time: "
                deadEndCountLbl.Text = "Dead End Count: "
                deadEndTimeLbl.Text = "Dead End Time: "
                totalTimeLbl.Text = "Total Time "
                Exit Sub
            End If
        Else
            ' If the multipier is below 3 that means it can be displayed on the form
            M = Math.Floor(Math.Min(1220 / Int(widthTxtBox.Text), 690 / Int(heightTxtBox.Text)))
        End If

        ' Intializes the maze
        initializeMaze()
        ' Allows program to know whether or not a maze has been generated
        mazeGenerated = True

        ' Resets old timer, Starts new timer, Upates Status
        statusLbl.Text = "Status: Generating"
        statusLbl.Update()
        generationTimer.Reset()
        generationTimer.Start()

        ' Checks what generation algorithm user has chosen
        If generationAlgorithm = "DFS Backtracker" Then
            randomisedDFS()
        End If
        generationTimer.Stop()
        ' Draws generate maze
        drawMaze()

        ' Checks if it should download the maze
        If downlaodGenerated = DialogResult.OK Then
            downloadMaze()
        Else
            ' Upadtes Maze box
            mazeBox.Image = mazeImage
        End If


        ' Updates Statistics
        ' Find the dead end count
        For Each cell In maze
            cell.deadEndFinder()
        Next
        deadEndToShow = deadEndPos.Count()
        deadEndPos.Clear()
        ' Displays Statistics
        genTimeLbl.Text = "Generation Time: " & Str(generationTimer.ElapsedMilliseconds() / 1000) & "s"
        solveTimeLbl.Text = "Sove Time: "
        drawTimeLbl.Text = "Draw Time: " & Str(drawTimer.ElapsedMilliseconds() / 1000) & "s"
        deadEndCountLbl.Text = "Dead End Count: " & Str(deadEndToShow)
        deadEndTimeLbl.Text = "Dead End Time: "
        totalTimeLbl.Text = "Total Time " & Str((generationTimer.ElapsedMilliseconds() + solveTimer.ElapsedMilliseconds() + drawTimer.ElapsedMilliseconds() + deadEndTimer.ElapsedMilliseconds()) / 1000) & "s"
        ' Resets Status, ' Resets Dialog Result
        statusLbl.Text = "Status: Doing Nothing"
        downlaodGenerated = DialogResult.Cancel
    End Sub
    Private Sub solveBtn_Click(sender As Object, e As EventArgs) Handles solveBtn.Click
        ' Makes sure a maze has been generated 
        If mazeGenerated = False Then
            MsgBox("No maze generated!" & vbCrLf & "Please press the generate button", MsgBoxStyle.OkOnly, "No maze generated")
            Exit Sub
        End If
        ' Sets solving algorithim to what the user has selected
        solveAlgorithm = solveCombo.Text

        ' Reset all cells that have .mazeSolved = True
        For Each cell In maze
            cell.mazeSolved = False
        Next

        ' Checks if the maze can be displayed
        If Math.Floor(Math.Min(1220 / Int(widthTxtBox.Text), 690 / Int(heightTxtBox.Text))) < 3 Then
            ' If it cant be displayed ask if they want to download
            downlaodSolved = MsgBox("Maze is too big to display!" & vbCrLf & "Want to download?" & vbCrLf & "WARNING! DEPENDING ON HARDWARE THIS MAY TAKE A LONG TIME", MsgBoxStyle.OkCancel, "Maze too big!")
            ' If they don't want to download exit sub
            If downlaodSolved = DialogResult.Cancel Then
                Exit Sub
            End If
        End If

        ' Resets old timer, Starts new timer, Upates Status
        solveTimer.Reset()
        solveTimer.Start()
        statusLbl.Text = "Status: Solving"
        statusLbl.Update()
        ' Checks what solving algorithm user has chosen
        If solveAlgorithm = "Dijkstra's Algorithm" Then
            dijkstra()
        End If
        solveTimer.Stop()
        ' Upadtes Maze box
        drawMaze()

        ' They want to download the solved image
        If downlaodSolved = DialogResult.OK Then
            downloadMaze()
        Else
            ' They dont want to download the solved image
            ' Check if it's drawable
            If Math.Floor(Math.Min(1220 / Int(widthTxtBox.Text), 690 / Int(heightTxtBox.Text))) >= 3 Then
                mazeBox.Image = mazeImage
            End If
        End If

        ' Displays Statistics
        solveTimeLbl.Text = "Sove Time: " & Str(solveTimer.ElapsedMilliseconds() / 1000) & "s"
        totalTimeLbl.Text = "Total Time " & Str((generationTimer.ElapsedMilliseconds() + solveTimer.ElapsedMilliseconds() + drawTimer.ElapsedMilliseconds() + deadEndTimer.ElapsedMilliseconds()) / 1000) & "s"
        ' Resets Status
        statusLbl.Text = "Status: Doing Nothing"
    End Sub
    Private Sub deadEndRemoverBtn_Click(sender As Object, e As EventArgs) Handles deadEndRemoverBtn.Click
        ' Makes sure a maze has been generated 
        If mazeGenerated = False Then
            MsgBox("No maze generated!" & vbCrLf & "Please press the generate button", MsgBoxStyle.OkOnly, "No maze generated")
            Exit Sub
        End If

        ' Saves the inputted percentage
        ' Checking that the values inputted for dead end remover is valid
        If Double.TryParse(deadEndRemoverTxtBox.Text, deadEndPercent) And deadEndPercent <= 1.0 Then
            deadEndPercent = deadEndRemoverTxtBox.Text
        Else
            MsgBox("Make sure dead end remover is a decimal number or 1", MsgBoxStyle.OkOnly, "Invalid Input")
            Exit Sub
        End If

        ' Resets old timer, Starts new timer, Upates Status
        deadEndTimer.Reset()
        deadEndTimer.Start()
        statusLbl.Text = "Status: Removing Dead Ends"
        statusLbl.Update()

        ' Removes dead ends
        deadEndRemover()
        deadEndTimer.Stop()
        ' Removes the solved value for each cell
        For Each cell In maze
            cell.mazeSolved = False
        Next

        ' Upadtes Maze box
        drawMaze()
        mazeBox.Image = mazeImage

        ' Find the dead end count
        For Each cell In maze
            cell.deadEndFinder()
        Next
        deadEndToShow = deadEndPos.Count()
        deadEndPos.Clear()
        ' Displays Statistics
        solveTimeLbl.Text = "Sove Time: "
        drawTimeLbl.Text = "Draw Time: " & Str(drawTimer.ElapsedMilliseconds() / 1000) & "s"
        deadEndCountLbl.Text = "Dead End Count: " & Str(deadEndToShow)
        deadEndTimeLbl.Text = "Dead End Time: " & Str(deadEndTimer.ElapsedMilliseconds() / 1000) & "s"
        totalTimeLbl.Text = "Total Time " & Str((generationTimer.ElapsedMilliseconds() + solveTimer.ElapsedMilliseconds() + drawTimer.ElapsedMilliseconds() + deadEndTimer.ElapsedMilliseconds()) / 1000) & "s"
        ' Resets Status
        statusLbl.Text = "Status: Doing Nothing"

    End Sub
    ' Setting Colour Customisation
    Private Function selectColour() As Color ' Opens a colour picker and returns the selected colour
        colorDialog.ShowDialog() ' Opens colour picker
        Return colorDialog.Color ' Returns picked colour
    End Function
    Private Sub downloadMaze()
        If mazeGenerated = True Then
            Dim openFile As New SaveFileDialog
            openFile.FileName = Nothing
            openFile.Filter = "JPG File's |*.jpg"
            openFile.ShowDialog()
            Try
                mazeImage.Save(openFile.FileName)
            Catch ex As Exception
                ' They didn't select a file location
            End Try
        Else
            MsgBox("No maze generated!" & vbCrLf & "Please press the generate button", MsgBoxStyle.OkOnly, "No maze generated")
        End If
    End Sub
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
        downloadMaze()
    End Sub

    Private Sub imageInputBtn_Click(sender As Object, e As EventArgs) Handles imageInputBtn.Click
        ' Requests and store image in memory
        openFileDialog1.FileName = ""
        openFileDialog1.Filter = "JPG Files(*.jpg)|*.jpg"
        If openFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            inputImage = New Bitmap(Image.FromFile(openFileDialog1.FileName))
            widthTxtBox.Text = inputImage.Width
            heightTxtBox.Text = inputImage.Height
        End If

        Dim currentPixel As Color
        ' Turns to grayscale
        For x As Integer = 0 To inputImage.Width - 1
            For y As Integer = 0 To inputImage.Height - 1
                currentPixel = inputImage.GetPixel(x, y)
                ' Finds lumiosity
                luminosity = (currentPixel.R * R) ^ GAMMA + (currentPixel.B * B) ^ GAMMA + (currentPixel.G * G) ^ GAMMA
                ' Altrting the gradient thershold
                If luminosity <= 125 Then
                    mazeWallList.Add(New Point(x, y))
                End If
            Next
        Next
    End Sub
    ' USER INPUT END
End Class
