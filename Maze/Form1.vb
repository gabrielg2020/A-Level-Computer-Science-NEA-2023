Imports System.Threading
Imports System.Collections.Generic
Imports Maze.Form1
Imports System.Text.Json

Public Class Form1
    ' Class instanse used to randomize numbers
    Private rnd As New Random
    ' Drawing Variables
    Private Const PEN_SIZE As Integer = 2
    Private M As Integer = 3
    ' Maze properties
    Private maze As Cell(,)
    Private width As Integer
    Private height As Integer
    Private deadEndPercent As Double
    Private mazeEntryType As String
    Private mazeEntry As Point
    Private mazeExit As Point
    Private deadEndPos As New List(Of Point)
    ' Maze Colour Customisation
    Private bgColour As Color = Color.White
    Private mazeColour As Color = Color.Black
    Private solveColour As Color = Color.Silver
    Private pinkColor As Color = Color.FromArgb(255, 0, 220) ' Pink color
    Private purpleColor As Color = Color.FromArgb(0, 0, 124) ' Purple color
    ' Animation Variables
    Private Const T As Integer = 10
    Private passedPath As New List(Of Point)
    Private solvedVisited As New Queue(Of Point)
    Private maxWeight As Integer
    Public cancelAnimation As Boolean = False
    ' Maze Generation/Solving Inputs
    Private generationAlgorithm As String
    ' Used in Astar()
    Public gWeights As New Dictionary(Of Point, Double)
    ' Used in BFS()
    Public branchingPoints As New List(Of Point)
    Private solveAlgorithm As String
    Private mazeWallCount As Integer = 0
    Public path As New Queue(Of Point)
    Public helperPath As New Queue(Of Point)
    ' Controls when the from draws
    Private mazeImage As Bitmap
    Private mazeImageGraphics As Graphics
    Private downlaodGenerated As DialogResult
    Private downlaodSolved As DialogResult
    ' Stats Variables
    Private deadEndToShow As Integer
    Private solveTimer As New Stopwatch
    Private generationTimer As New Stopwatch
    Private drawTimer As New Stopwatch
    Private deadEndTimer As New Stopwatch
    ' Babyproofing Variables
    Private mazeGenerated As Boolean = False
    ' Image to maze Variables
    Private imageInputted As Boolean = False
    Private inputImage As Bitmap
    Private mazeWallList As New List(Of Point)
    Private luminosity As Double
    Private Const GAMMA As Double = 1.0
    Private Const R As Double = 0.2126
    Private Const G As Double = 0.7152
    Private Const B As Double = 0.0722
    Private imgComponents As New List(Of List(Of Point))
    Private largestComponent As New List(Of Point)
    ' Circular Queue Class
    Class CircularQueue(Of T)
        Private ReadOnly items As List(Of T)
        Private currentIndex As Integer

        ' Constructor
        Public Sub New(i As IEnumerable(Of T))
            ' This assigns the items in the queue
            items = New List(Of T)(i)
            currentIndex = 0
        End Sub

        ' This function return value will be same type and the input
        Public Function turnRight() As T
            If items.Count = 0 Then
                ' This helps when debugging
                Throw New InvalidOperationException("The queue is empty")
            End If


            currentIndex = (currentIndex + 1) Mod items.Count
            Dim i As T = items(currentIndex)
            Return i
        End Function

        ' This function return value will be same type and the input
        Public Function turnLeft() As T
            If items.Count = 0 Then
                ' This helps when debugging
                Throw New InvalidOperationException("The queue is empty")
            End If

            currentIndex = (currentIndex - 1 + items.Count) Mod items.Count
            Dim i As T = items(currentIndex)

            Return i
        End Function
    End Class
    ' Priority Queue Class
    Public Class PriorityQueue(Of priority As IComparable, value)
        Private ReadOnly dictionary As SortedDictionary(Of priority, Queue(Of value))

        ' Constructor
        Public Sub New()
            ' This assigns the items in the dictionary
            dictionary = New SortedDictionary(Of priority, Queue(Of value))()
        End Sub

        ' Adds values to the queue
        Public Sub Enqueue(priority As priority, value As value)
            ' If we have a new priority we create a new queue
            If Not dictionary.ContainsKey(priority) Then
                dictionary(priority) = New Queue(Of value)()
            End If
            ' Add value to queue
            dictionary(priority).Enqueue(value)
        End Sub

        ' Removes values to the queue
        Public Function Dequeue() As value
            ' This helps when debugging
            If dictionary.Count = 0 Then
                Throw New InvalidOperationException("The priority queue is empty.")
            End If

            Dim firstPair As KeyValuePair(Of priority, Queue(Of value)) = dictionary.First()
            Dim value As value = firstPair.Value.Dequeue()

            If firstPair.Value.Count = 0 Then
                dictionary.Remove(firstPair.Key)
            End If

            Return value
        End Function

        ' Checks if the whole queue is empty
        Public Function isEmpty() As Boolean
            Return dictionary.Count = 0
        End Function

        ' Returns the number of items in the queue
        Public Function Count() As Integer
            Dim totalCount As Integer = 0
            For Each q In dictionary.Values
                totalCount += q.Count
            Next
            Return totalCount
        End Function

        ' Checks if a value is in the queue
        Public Function Contains(v As value) As Boolean
            For Each q In dictionary.Values
                If q.Contains(v) Then
                    Return True
                End If
            Next
            Return False
        End Function
    End Class
    ' Cell Class
    Public Class Cell
        ' Postion Properties
        Public x As Integer
        Public y As Integer
        ' Wall Properties
        Public walls As New List(Of Boolean)
        Public wallPos(3, 1) As Point
        ' Cell Type
        Public mazeWallBool As Boolean = False
        Public mazeEntryBool As Boolean = False
        Public mazeExitBool As Boolean = False
        Public mazeSolved As Boolean = False
        Private deadEnd As Boolean = False
        ' Generate/Solve Properties
        Public weight As Integer = 0
        Public heuristicWeight As Integer = 0
        Public visited As Boolean = False
        Public connectedCell As New List(Of Point)


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
        ' Method to find dead-ends
        Public Sub deadEndFinder()
            Dim wallCount As Integer = 0
            ' Checks each wall
            For Each wall In walls
                If wall = True And mazeWallBool = False Then
                    wallCount += 1
                End If
            Next
            If wallCount = 3 And Not Form1.deadEndPos.Contains(New Point(x, y)) Then
                Form1.deadEndPos.Add(New Point(x, y))
            End If
        End Sub
        ' Method to break wall
        Public Function breakWall(ByVal d As Integer)
            ' Makes sure the cell isn't a maze wall
            If mazeWallBool = True Then
                Return Point.Empty
                Exit Function
            End If
            ' Breaks wall depending on the d (direction)
            Select Case d
                ' The wall selected must be broken but also the neighbours wall
                Case 0 ' Breaking the top wall
                    If Form1.maze(x, y - 1).mazeWallBool = True Then
                        Return Point.Empty
                        Exit Function
                    End If
                    walls(d) = False
                    Form1.maze(x, y - 1).walls(d + 2) = False
                    connectedCell.Add(New Point(x, y - 1))
                    Form1.maze(x, y - 1).connectedCell.Add(New Point(x, y))
                Case 1 ' Breaking the right wall
                    If Form1.maze(x + 1, y).mazeWallBool = True Then
                        Return Point.Empty
                        Exit Function
                    End If
                    walls(d) = False
                    Form1.maze(x + 1, y).walls(d + 2) = False
                    connectedCell.Add(New Point(x + 1, y))
                    Form1.maze(x + 1, y).connectedCell.Add(New Point(x, y))
                Case 2 ' Breaking the bottom wall
                    If Form1.maze(x, y + 1).mazeWallBool = True Then
                        Return Point.Empty
                        Exit Function
                    End If
                    walls(d) = False
                    Form1.maze(x, y + 1).walls(d - 2) = False
                    connectedCell.Add(New Point(x, y + 1))
                    Form1.maze(x, y + 1).connectedCell.Add(New Point(x, y))
                Case 3 ' Breaking the left wall
                    If Form1.maze(x - 1, y).mazeWallBool = True Then
                        Return Point.Empty
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
            Dim neighbours As New List(Of Point)

            If mazeWallBool = True Then
                Return {Point.Empty, Point.Empty, Point.Empty, Point.Empty}.ToList
                Exit Function
            End If

            If Form1.maze(x, y - 1).visited = False Then
                neighbours.Add(New Point(x, y - 1))
            Else
                neighbours.Add(Point.Empty)
            End If

            If Form1.maze(x + 1, y).visited = False Then
                neighbours.Add(New Point(x + 1, y))
            Else
                neighbours.Add(Point.Empty)
            End If

            If Form1.maze(x, y + 1).visited = False Then
                neighbours.Add(New Point(x, y + 1))
            Else
                neighbours.Add(Point.Empty)
            End If

            If Form1.maze(x - 1, y).visited = False Then
                neighbours.Add(New Point(x - 1, y))
            Else
                neighbours.Add(Point.Empty)
            End If
            Return neighbours
        End Function
        ' Returns a boolean if cell has a connecter neighbour
        Function checkConnectedCell(d As Integer)
            Select Case d
                Case 0 ' Check above
                    If connectedCell.Contains(New Point(x, y - 1)) Then
                        Return New Point(x, y - 1)
                    End If
                Case 1 ' Check Right
                    If connectedCell.Contains(New Point(x + 1, y)) Then
                        Return New Point(x + 1, y)
                    End If
                Case 2 ' Check Below
                    If connectedCell.Contains(New Point(x, y + 1)) Then
                        Return New Point(x, y + 1)
                    End If
                Case 3 ' Check Left
                    If connectedCell.Contains(New Point(x - 1, y)) Then
                        Return New Point(x - 1, y)
                    End If
            End Select
            Return Point.Empty
        End Function
    End Class

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        widthTxtBox.Text = 30
        heightTxtBox.Text = 30
        generationCombo.SelectedIndex = 0 ' Makes index 0 default displayed on the combo list(so currently shows "DFS Backtracker" initially
        solveCombo.SelectedIndex = 2 ' Default displays (Dijkstra's Algortimn)
        mazeEntryCombo.SelectedIndex = 0 ' Default displays "Random"

        solvedPathAnimationTimer.Interval = 100
        heatMapAnimationTimer.Interval = 50
        heatMapAnimationTimer.Enabled = False
        solvedPathAnimationTimer.Enabled = False

    End Sub
    Private Sub initializeMaze()
        mazeWallCount = 0

        ' Resets old timer, Starts new timer, Upates Status
        statusLbl.Text = "Status: Initializing Maze"
        statusLbl.Update()
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

                ' Setting the maze wall cells with the mazeWallBool
                If i = 0 Or j = 0 Or i = width Or j = height Or mazeWallList.Contains(New Point(i, j)) Then
                    maze(i, j).mazeWallBool = True
                    maze(i, j).visited = True
                    mazeWallCount += 1
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

        ' Setting Maze Entry and Exit
        setMazeEntryExit()
    End Sub
    Private Sub setMazeEntryExit()
        If imageInputted = True Then
            ' Randomly picks a side
            Dim side As Integer = rnd.Next(1, 2)

            If side = 1 Then
                mazeEntry = New Point(largestComponent.OrderByDescending(Function(p) p.X).First())
                mazeExit = New Point(largestComponent.OrderByDescending(Function(p) p.X).Last())
            Else
                Dim orderedList As List(Of Point) = largestComponent.OrderByDescending(Function(p) p.Y)
                mazeEntry = New Point(orderedList.First())
                mazeExit = New Point(orderedList.Last())
            End If
        Else
            Select Case mazeEntryType
                Case "Random"
                    Randomize()
                    Dim randomType As Integer = rnd.Next(0, 4)
                    ' Chooses randomly what type of maze entry it will be
                    Select Case randomType
                        Case 0 ' Start at a random top postion, finish at a random bottom position
                            mazeEntry = New Point(rnd.Next(1, width), 1)
                            mazeExit = New Point(rnd.Next(1, width), height - 1)
                        Case 1 ' Start at a random bottom postion, finish at a random top position
                            mazeEntry = New Point(rnd.Next(1, width), height - 1)
                            mazeExit = New Point(rnd.Next(1, width), 1)
                        Case 2 ' Start at a random right postion, finish at a random left positon
                            mazeEntry = New Point(1, rnd.Next(1, height))
                            mazeExit = New Point(width - 1, rnd.Next(1, height))
                        Case 3 ' Start at a random left postion, finish at a random right positon
                            mazeEntry = New Point(width - 1, rnd.Next(1, height))
                            mazeExit = New Point(1, rnd.Next(1, height))
                    End Select
                Case "Top - Bottom"
                    mazeEntry = New Point(Math.Round(width / 2), 1)
                    mazeExit = New Point(Math.Round(width / 2), height - 1)
                Case "Right - Left"
                    mazeEntry = New Point(1, Math.Round(height / 2))
                    mazeExit = New Point(width - 1, Math.Round(height / 2))
                Case "Diagonal"
                    mazeEntry = New Point(1, 1)
                    mazeExit = New Point(width - 1, height - 1)
            End Select
        End If
        ' Setting the entry cell with the mazeEntryBool
        maze(mazeEntry.X, mazeEntry.Y).mazeEntryBool = True
        maze(mazeEntry.X, mazeEntry.Y).mazeWallBool = False
        ' Setting the exit cell with the mazeExitBool
        maze(mazeExit.X, mazeExit.Y).mazeExitBool = True
        maze(mazeExit.X, mazeExit.Y).mazeWallBool = False
    End Sub
    Private Sub drawMaze() ' If False is passed through then the background cells will be drawn
        ' Resets old timer, Starts new timer, Upates Status
        drawTimer.Reset()
        drawTimer.Start()
        statusLbl.Text = "Status: Drawing Maze"
        statusLbl.Update()
        ' Create brush objects for each color
        Dim bgBrush As New SolidBrush(bgColour)
        Dim mazeBrush As New SolidBrush(mazeColour)
        Dim solvedBrush As New SolidBrush(solveColour)
        Dim entryBrush As New SolidBrush(Color.Green)
        Dim exitBrush As New SolidBrush(Color.Red)

        For Each cell In maze
            ' Determine the fill color based on cell properties
            Dim fillBrush As Brush = bgBrush
            If cell.mazeWallBool Then
                fillBrush = mazeBrush
            End If
            If cell.mazeEntryBool Then
                fillBrush = entryBrush
            End If
            If cell.mazeExitBool Then
                fillBrush = exitBrush
            End If
            If cell.mazeSolved Then
                fillBrush = solvedBrush
            End If

            ' Draw the cell background and fill
            mazeImageGraphics.FillRectangle(fillBrush, cell.wallPos(0, 0).X, cell.wallPos(1, 0).Y, M, M)

            ' Draw the walls
            cell.drawWalls()
        Next

        ' Dispose of the brush objects
        bgBrush.Dispose()
        mazeBrush.Dispose()
        entryBrush.Dispose()
        exitBrush.Dispose()
        solvedBrush.Dispose()
        drawTimer.Stop()
    End Sub
    Private Sub resetMaze()
        ' Clear the collections
        solvedVisited.Clear()
        helperPath.Clear()
        path.Clear()
        passedPath.Clear()

        ' Reset the mazeSolved property for each cell
        For x As Integer = 0 To width - 1
            For y As Integer = 0 To height - 1
                maze(x, y).mazeSolved = False
            Next
        Next

        ' Redraw the unsolved maze
        drawMaze()
        mazeBox.Image = mazeImage
        mazeBox.Update()
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
    ' Interpolate between two colors based on a ratio (0.0 to 1.0)
    Function interpolateColor(color1 As Color, color2 As Color, ratio As Double) As Color
        Dim r As Double = Int(color1.R) + (Int(color2.R) - Int(color1.R)) * ratio
        Dim g As Double = Int(color1.G) + (Int(color2.G) - Int(color1.G)) * ratio
        Dim b As Double = Int(color1.B) + (Int(color2.B) - Int(color1.B)) * ratio
        Return Color.FromArgb((r), (g), (b))
    End Function
    ' Generating
    Private Sub randomisedDFS(Optional component As List(Of Point) = Nothing)
        Randomize()
        ' Backtracking stack
        Dim stack As New Stack(Of Point)
        Dim node As Point
        ' Checking if array was inputted
        If component Is Nothing Then
            stack.Push(New Point(rnd.Next(1, width), rnd.Next(1, height)))
        Else
            stack.Push(component(rnd.Next(0, component.Count())))
        End If
        Dim neigbours As New List(Of Point)
        Dim direction As Integer
        ' Until the stack is empty
        While stack.Count <> 0
            node = stack.Pop()
            ' Check neighbours
            neigbours = maze(node.X, node.Y).checkUnvistedNeighbours()
            ' Checks if all neighbours are not empty 
            If neigbours.All(Function(p) p.Equals(Point.Empty)) = False Then
                stack.Push(node)
                ' Make a new list that only contains the non empty values from neighbour
                Dim validNeigbours As New List(Of Point)
                For Each point In neigbours
                    If point <> Point.Empty Then
                        validNeigbours.Add(point)
                    End If
                Next
                ' Randomly pick a valid neighbour. Find the index of that point within the orginal neighbour list and set that to direction
                Randomize()
                direction = neigbours.IndexOf(validNeigbours(rnd.Next(0, validNeigbours.Count())))
                ' Break the wall
                node = maze(node.X, node.Y).breakWall(direction)
                ' Push to the stack
                stack.Push(node)
                ' Mark as visted
                maze(node.X, node.Y).visited = True
            End If
        End While
    End Sub

    ' Solving 
    Private Function distanceCalc(a As Point, b As Point) As Double
        Return Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y)
    End Function
    Private Sub dijkstra()
        ' Clear the gWeight dictionary
        gWeights.Clear()

        ' Initialize the parents dictionary and the priority queue
        Dim parents As New Dictionary(Of Point, Point)
        Dim pQueue As New PriorityQueue(Of Double, Point)()

        ' Set the weight of entry to 0 and enqeueu to the priority queue
        gWeights(mazeEntry) = 0
        pQueue.Enqueue(0, mazeEntry)

        ' Continue until the proprity queue is empty
        While Not pQueue.isEmpty()
            ' Dequeue the node with the lowest weight from the priority queue
            Dim current As Point = pQueue.Dequeue()

            ' Add the dequeued node to the solvedVisited queue
            solvedVisited.Enqueue(current)

            ' Check for exit
            If current = mazeExit Then
                Exit While
            End If

            ' Go through each connect neighbour of the current node
            For Each neighbour In maze(current.X, current.Y).connectedCell
                ' Calculate weight of neighbour. In this to get to a connected node holds a weight of 1
                Dim weight As Double = gWeights(current) + 1

                ' If the neighbour's weight is not already in the dictionary, set it to a large value
                If Not gWeights.ContainsKey(neighbour) Then
                    gWeights(neighbour) = Double.MaxValue
                End If

                ' Update the neighbours weight and parent if the calculated weight is less
                If weight < gWeights(neighbour) Then
                    gWeights(neighbour) = weight
                    maxWeight = Math.Max(maxWeight, weight)
                    parents(neighbour) = current

                    ' If the neight is not in the priority queue, add it
                    If Not pQueue.Contains(neighbour) Then
                        pQueue.Enqueue(weight, neighbour)
                    End If
                End If
            Next
        End While

        ' Reconstruct the path
        Dim currentNode As Point = mazeExit
        While currentNode <> mazeEntry AndAlso parents.ContainsKey(currentNode)
            currentNode = parents(currentNode)
            If currentNode <> mazeEntry Then
                path.Enqueue(currentNode)
            End If
        End While

        ' Check If they want animations
        If instantAnimationBtn.Checked = True Then
            ' Mark the path as solved
            For Each node In path
                maze(node.X, node.Y).mazeSolved = True
            Next
            path.Clear()
        ElseIf instantAnimationBtn.Checked = False Then
            ' Enable animations and lock other controls
            animationLock(True)
            heatMapAnimationTimer.Enabled = True
        End If
    End Sub
    Private Sub BFS()
        ' Initialize the queue, parent dictionary and currentNod
        Dim queue As New Queue(Of Point)
        Dim parents As New Dictionary(Of Point, Point)()
        Dim currentNode As Point

        ' Enqueue the starting point
        queue.Enqueue(mazeEntry)

        ' Continue searching until the queue is empty
        While queue.Count <> 0
            ' Dequeue the next code in the queue
            currentNode = queue.Dequeue()

            ' Check for the exit
            If currentNode = mazeExit Then
                Exit While
            End If

            ' Go through each connected cell of currentNode
            For Each point In maze(currentNode.X, currentNode.Y).connectedCell
                If Not solvedVisited.Contains(point) Then
                    solvedVisited.Enqueue(point)
                    parents(point) = currentNode
                    queue.Enqueue(point)
                End If
            Next

            If maze(currentNode.X, currentNode.Y).connectedCell.Count > 2 Then
                branchingPoints.Add(currentNode)
            End If
        End While

        ' Reconstruct the path
        currentNode = mazeExit
        While currentNode <> mazeEntry AndAlso parents.ContainsKey(currentNode)
            currentNode = parents(currentNode)
            If currentNode <> mazeEntry Then
                path.Enqueue(currentNode)
            End If
        End While

        ' Check if they want animations
        If instantAnimationBtn.Checked = True Then
            ' Mark the path as solved
            For Each node In path
                maze(node.X, node.Y).mazeSolved = True
            Next
            path.Clear()
        ElseIf instantAnimationBtn.Checked = False Then
            ' Enable animations and lock other controls
            animationLock(True)
            heatMapAnimationTimer.Enabled = True
        End If
    End Sub
    Private Sub Astar(Optional ByVal helper As Boolean = False)
        ' Clear the gWeight dictionary
        gWeights.Clear()

        ' Initailize the parent dictionary and priority queue for open nodes
        Dim parents As New Dictionary(Of Point, Point)
        Dim pQueue As New PriorityQueue(Of Double, Point)()

        ' Set the starting points gWeight to 0 and enqueue it with its heuristic value
        gWeights(mazeEntry) = 0
        pQueue.Enqueue(distanceCalc(mazeEntry, mazeExit), mazeEntry)

        ' Continue searching until the priority queue is empty
        While Not pQueue.isEmpty()
            ' Dequeue the node with the lowest 
            Dim current As Point = pQueue.Dequeue()

            ' Add the dequeued node to the visited nodes queue
            solvedVisited.Enqueue(current)

            ' Check for exit node
            If current = mazeExit Then
                Exit While
            End If

            ' Go through each connected node of the current node
            For Each neighbour In maze(current.X, current.Y).connectedCell
                ' Calculate heuristic weight
                Dim heuristicWeight As Double = gWeights(current) + distanceCalc(current, neighbour)

                ' Set the neighbour's gWeight to a large value if its not in gWeights
                If Not gWeights.ContainsKey(neighbour) Then
                    gWeights(neighbour) = Double.MaxValue
                End If

                ' Update the neighbours gWeight and parent if the heuristic weight is lower
                If heuristicWeight < gWeights(neighbour) Then
                    parents(neighbour) = current
                    gWeights(neighbour) = heuristicWeight
                    maxWeight = Math.Max(maxWeight, heuristicWeight)
                    Dim fWeight As Double = gWeights(neighbour) + distanceCalc(neighbour, mazeExit)

                    ' If the neighbour is not in the priority queue, add it with the calculated fWeight
                    If Not pQueue.Contains(neighbour) Then
                        pQueue.Enqueue(fWeight, neighbour)
                    End If
                End If
            Next
        End While

        ' Reconstruct the path
        Dim currentNode As Point = mazeExit
        While currentNode <> mazeEntry AndAlso parents.ContainsKey(currentNode)
            currentNode = parents(currentNode)
            If currentNode <> mazeEntry Then
                path.Enqueue(currentNode)
            End If
        End While

        If helper = True Then
            helperPath = New Queue(Of Point)(path)
            path.Clear()
        Else
            ' Check if they want animations
            If instantAnimationBtn.Checked = True Then
                ' Mark the path as solved
                For Each node In path
                    maze(node.X, node.Y).mazeSolved = True
                Next
                path.Clear()
            ElseIf instantAnimationBtn.Checked = False Then
                ' Enable animations and lock other controls
                animationLock(True)
                heatMapAnimationTimer.Enabled = True
            End If
        End If
    End Sub
    Private Sub wallFollower(type As String)
        ' Initailize the current node to the entry
        Dim node As Point = mazeEntry
        ' Initailize the direction queue and index for left/right-hand rule navigation
        Dim directionQueue As New CircularQueue(Of Integer)({0, 1, 2, 3})
        Dim index As Integer

        ' If the instant animation is unchecked, call A* for the most effecient path
        If instantAnimationBtn.Checked = False Then
            Astar(helper:=True)
        End If

        ' Continue until the maze exit is reached
        While node <> mazeExit
            ' Determine next direction base on wall follower type
            If type = "LHR" Then
                index = directionQueue.turnLeft
            ElseIf type = "RHR" Then
                index = directionQueue.turnRight
            End If

            ' Check if the next cell is connected in the given direction
            If maze(node.X, node.Y).checkConnectedCell(index) <> Point.Empty Then
                node = maze(node.X, node.Y).checkConnectedCell(index)
            Else
                ' If the next cell is not connected, rotate until a connected cell in found
                Do
                    If type = "LHR" Then
                        index = directionQueue.turnRight
                    ElseIf type = "RHR" Then
                        index = directionQueue.turnLeft
                    End If
                Loop Until maze(node.X, node.Y).checkConnectedCell(index) <> Point.Empty

                ' Move to the connected cell
                node = maze(node.X, node.Y).checkConnectedCell(index)
            End If

            ' Dont add entry or exit to the path
            If node <> mazeEntry And node <> mazeExit Then
                path.Enqueue(node)
            End If
        End While

        ' Check if they want animations
        If instantAnimationBtn.Checked = True Then
            ' Mark the path as solved
            For Each node In path
                maze(node.X, node.Y).mazeSolved = True
            Next
            path.Clear()
        ElseIf instantAnimationBtn.Checked = False Then
            ' Enable animations and lock other controls
            animationLock(True)
            heatMapAnimationTimer.Enabled = True
        End If
    End Sub
    ' Animation
    Private Sub heatMapAnimationTimer_Tick(sender As Object, e As EventArgs) Handles heatMapAnimationTimer.Tick
        ' Cancel animation if needed
        If cancelAnimation = True Then
            heatMapAnimationTimer.Enabled = False
            solvedPathAnimationTimer.Enabled = False
            resetMaze()
            animationLock(False)
            cancelAnimation = False
            Exit Sub
        End If

        ' Creating the heat map
        If solveAlgorithm = "A*" Or solveAlgorithm = "Dijkstra's" Then
            ' If there are nodes in the solvedVisited
            If solvedVisited.Count > 0 Then
                Dim node As Point = solvedVisited.Dequeue
                ' If the node is not the entry or exit
                If node <> mazeEntry And node <> mazeExit Then
                    ' Calculate the normalized weight and draw heat map
                    Dim normalisedWeight As Double = gWeights(node) / maxWeight
                    mazeImageGraphics.FillRectangle(New SolidBrush(interpolateColor(pinkColor, purpleColor, normalisedWeight)), node.X * M, node.Y * M, M, M)

                    ' Draws walls and update the maze box
                    maze(node.X, node.Y).drawWalls()
                    mazeBox.Image = mazeImage
                    mazeBox.Update()
                End If
            Else
                ' Clear the solvedVisited queue, draw the maze, and enable the solvedPathAnimationTimer
                solvedVisited.Clear()
                drawMaze()
                heatMapAnimationTimer.Enabled = False
                solvedPathAnimationTimer.Enabled = True
            End If
        ElseIf solveAlgorithm = "Wall Follower LHR" Or solveAlgorithm = "Wall Follower RHR" Then
            ' If there are nodes in path
            If path.Count > 0 Then
                Dim node As Point = path.Dequeue

                ' Draw the previous cell in the solved path colour or aqua colour
                If passedPath.Count > 0 Then
                    Dim previousPath As Point = passedPath.Last()
                    If helperPath.Contains(previousPath) Then
                        mazeImageGraphics.FillRectangle(New SolidBrush(solveColour), previousPath.X * M, previousPath.Y * M, M, M)
                    Else
                        mazeImageGraphics.FillRectangle(New SolidBrush(Color.Aqua), previousPath.X * M, previousPath.Y * M, M, M)
                    End If
                    maze(previousPath.X, previousPath.Y).mazeSolved = True
                    maze(previousPath.X, previousPath.Y).drawWalls()
                End If

                ' Draw the current cell in the yellow color, draw the walls, and update the maze display
                mazeImageGraphics.FillRectangle(New SolidBrush(Color.Yellow), node.X * M, node.Y * M, M, M)
                maze(node.X, node.Y).drawWalls()
                passedPath.Add(node)
                ' Updates Maze box
                mazeBox.Image = mazeImage
                mazeBox.Update()
            Else
                ' Draw the last cell in the solved path color,draw the walls, and update the maze display
                If passedPath.Count > 0 Then
                    Dim lastPath As Point = passedPath.Last()
                    mazeImageGraphics.FillRectangle(New SolidBrush(solveColour), lastPath.X * M, lastPath.Y * M, M, M)
                    maze(lastPath.X, lastPath.Y).drawWalls()
                    maze(lastPath.X, lastPath.Y).mazeSolved = True
                    drawMaze()
                    mazeBox.Image = mazeImage
                    mazeBox.Update()
                End If
                ' Clear the helperPath, path, and passedPath queues, disable the timers, and unlock the animation
                helperPath.Clear()
                path.Clear()
                passedPath.Clear()
                animationLock(False)
                heatMapAnimationTimer.Enabled = False
                solvedPathAnimationTimer.Enabled = False
            End If
        ElseIf solveAlgorithm = "Breath Frist Search" Then
            ' If there are nodes in the solvedVisited queue
            If solvedVisited.Count > 0 Then
                Dim node As Point = solvedVisited.Dequeue
                ' If the node is not entry or exit
                If node <> mazeEntry And node <> mazeExit Then
                    ' Draw the node in yellow if it's a branching point or the solveColour otherwise
                    If branchingPoints.Contains(node) Then
                        mazeImageGraphics.FillRectangle(New SolidBrush(Color.Yellow), node.X * M, node.Y * M, M, M)
                    Else
                        mazeImageGraphics.FillRectangle(New SolidBrush(solveColour), node.X * M, node.Y * M, M, M)
                    End If
                    'Draw the walls And update the maze display
                    maze(node.X, node.Y).drawWalls()
                    mazeBox.Image = mazeImage
                    mazeBox.Update()
                End If
            Else
                ' Clear the solvedVisited queue, draw the maze, and enable the solvedPathAnimationTimer
                solvedVisited.Clear()
                drawMaze()
                solvedPathAnimationTimer.Enabled = True
                heatMapAnimationTimer.Enabled = False
            End If
        End If
    End Sub
    Private Sub solvedPathAnimationTimer_Tick(sender As Object, e As EventArgs) Handles solvedPathAnimationTimer.Tick, solvedPathAnimationTimer.Tick, solvedPathAnimationTimer.Tick
        ' Cancel animation if needed
        If cancelAnimation = True Then
            heatMapAnimationTimer.Enabled = False
            solvedPathAnimationTimer.Enabled = False
            resetMaze()
            animationLock(False)
            cancelAnimation = False
            Exit Sub
        End If
        ' Creating the Solved Path
        If path.Count > 0 Then
            Dim currentPath As Point = path.Dequeue

            ' Draw the previous cell in the solved path color
            If passedPath.Count > 0 Then
                Dim previousPath As Point = passedPath.Last()
                mazeImageGraphics.FillRectangle(New SolidBrush(solveColour), previousPath.X * M, previousPath.Y * M, M, M)
                maze(previousPath.X, previousPath.Y).drawWalls()
            End If

            ' Draw the current cell in the yellow color
            mazeImageGraphics.FillRectangle(New SolidBrush(Color.Yellow), currentPath.X * M, currentPath.Y * M, M, M)
            maze(currentPath.X, currentPath.Y).drawWalls()

            ' Add the current cell to the passedPath list and mark it as solved
            passedPath.Add(currentPath)
            maze(currentPath.X, currentPath.Y).mazeSolved = True

            ' Updates maze box
            mazeBox.Image = mazeImage
            mazeBox.Update()
        Else
            ' If there are no more cells in the path, draw the last cell in the solved path
            If passedPath.Count > 0 Then
                Dim lastPath As Point = passedPath.Last()
                mazeImageGraphics.FillRectangle(New SolidBrush(solveColour), lastPath.X * M, lastPath.Y * M, M, M)
                maze(lastPath.X, lastPath.Y).drawWalls()

                ' Updates maze box
                mazeBox.Image = mazeImage
                mazeBox.Update()
            End If

            ' Disable the solvedPathAnimationTimer, unlock the animation, and clear the path and passedPath list
            solvedPathAnimationTimer.Enabled = False
            animationLock(False)
            path.Clear()
            passedPath.Clear()
        End If
    End Sub

    Private Sub deadEndRemover()
        Dim numToBeRemoved As Integer
        Dim deadEnd As Point
        Dim node As Point
        Dim direction As Integer
        ' Find the deadends
        For Each cell In maze
            cell.deadEndFinder()
        Next
        ' Calculate the amount of dead end to remove
        numToBeRemoved = Math.Round(deadEndPos.Count() * deadEndPercent)
        Dim removed As Integer = 0
        While removed <> numToBeRemoved
            ' Pick a random cell
            deadEnd = deadEndPos(rnd.Next(0, deadEndPos.Count))
            ' Finds valid indexs
            Dim validIdexs As New List(Of Integer)
            For i As Integer = 0 To 3
                If maze(deadEnd.X, deadEnd.Y).walls(i) Then
                    validIdexs.Add(i)
                End If
            Next
            ' Pick a valid wall to break
            Do
                direction = validIdexs(rnd.Next(0, validIdexs.Count))
                node = maze(deadEnd.X, deadEnd.Y).breakWall(direction)
            Loop While node.IsEmpty
            ' Removes from dead end list as changes the number of deadends removed.
            deadEndPos.Remove(deadEnd)
            If deadEndPos.Contains(node) Then
                deadEndPos.Remove(node)
                removed += 1
            End If
            removed += 1
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
            If imageInputted = True Then
                For Each component In imgComponents
                    randomisedDFS(component)
                Next
            Else
                randomisedDFS()
            End If
        ElseIf generationAlgorithm = "Wave Function Collapse" Then
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
        If solveAlgorithm = "Dijkstra's" Then
            dijkstra()
        ElseIf solveAlgorithm = "Breath Frist Search" Then
            BFS()
        ElseIf solveAlgorithm = "A*" Then
            Astar()
        ElseIf solveAlgorithm = "Wall Follower LHR" Then
            wallFollower("LHR")
        ElseIf solveAlgorithm = "Wall Follower RHR" Then
            wallFollower("RHR")
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
    Private Function componentAnalysis(ByVal image As Bitmap) As List(Of List(Of Point))
        largestComponent.Clear()
        ' Create a list to store the components
        Dim components As New List(Of List(Of Point))()
        ' Create a 2D array to track which pixels have been visited
        Dim visited(image.Width - 1, image.Height - 1) As Boolean
        ' Loop through each pixel in the image
        For y As Integer = 0 To image.Height - 1
            For x As Integer = 0 To image.Width - 1
                ' If this pixel has not been visted and its white(255,255,255)
                If Not visited(x, y) And image.GetPixel(x, y) = Color.FromArgb(255, 255, 255) Then
                    ' Create a list to store the pixels in the component
                    Dim component As New List(Of Point)()
                    ' Create a stack to store the pixels that need to be checked
                    Dim stack As New Stack(Of Point)()
                    stack.Push(New Point(x, y))
                    ' Until all pixels have been checked
                    While stack.Count > 0
                        ' Store the current pixel
                        Dim pixel As Point = stack.Pop()
                        ' If this pixel has not been visted and is white
                        If Not visited(pixel.X, pixel.Y) And image.GetPixel(pixel.X, pixel.Y) = Color.FromArgb(255, 255, 255) Then
                            visited(pixel.X, pixel.Y) = True
                            ' Add to the componet
                            component.Add(pixel)
                            ' Add neighbours to the stack
                            If pixel.X > 0 Then
                                stack.Push(New Point(pixel.X - 1, pixel.Y))
                            End If
                            If pixel.X < image.Width - 1 Then
                                stack.Push(New Point(pixel.X + 1, pixel.Y))
                            End If
                            If pixel.Y > 0 Then
                                stack.Push(New Point(pixel.X, pixel.Y - 1))
                            End If
                            If pixel.Y < image.Height - 1 Then
                                stack.Push(New Point(pixel.X, pixel.Y + 1))
                            End If
                        End If
                    End While
                    components.Add(component)
                End If
            Next
        Next
        ' Find the largest component
        For Each component As List(Of Point) In components
            If component.Count > largestComponent.Count Then
                largestComponent = component
            End If
        Next
        Return components
    End Function

    Private Sub imageInputBtn_Click(sender As Object, e As EventArgs) Handles imageInputBtn.Click
        ' Rest variable 
        If imageInputted = True Then
            inputImage.Dispose()
            mazeWallList.Clear()
            imgComponents.Clear()
            mazeBox.Image = Nothing
            widthTxtBox.Text = 0
            heightTxtBox.Text = 0
            imageInputted = False
            imageInputBtn.Text = "Input Image"
            Exit Sub
        End If
        ' Requests and store image in memory
        openFileDialog1.FileName = ""
        openFileDialog1.Filter = "JPG Files(*.jpg)|*.jpg"
        If openFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            inputImage = New Bitmap(Image.FromFile(openFileDialog1.FileName))
            ' Calculate the new image dimensions
            Dim newWidth As Integer = inputImage.Width + 2
            Dim newHeight As Integer = inputImage.Height + 2
            ' Create the new bitmap with the larger dimensions
            Dim newImage As New Bitmap(newWidth, newHeight)
            ' Draw the original image onto the new bitmap
            Using g As Graphics = Graphics.FromImage(newImage)
                g.DrawImage(inputImage, New Point(1, 1))
            End Using
            ' Draw a border around the image
            Using g As Graphics = Graphics.FromImage(newImage)
                Using p As New Pen(Color.Black)
                    g.DrawRectangle(p, New Rectangle(0, 0, newWidth - 1, newHeight - 1))
                End Using
            End Using
            inputImage = newImage
            ' Sets width and height text boxs
            widthTxtBox.Text = inputImage.Width
            heightTxtBox.Text = inputImage.Height
        Else
            Exit Sub
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
                    inputImage.SetPixel(x, y, Color.FromArgb(0, 0, 0))
                    mazeWallList.Add(New Point(x, y))
                Else
                    inputImage.SetPixel(x, y, Color.FromArgb(255, 255, 255))
                End If
            Next
        Next
        imgComponents = componentAnalysis(inputImage)

        imageInputBtn.Text = "Cancel Image"
        imageInputted = True
    End Sub

    Private Sub helperBtn_Click(sender As Object, e As EventArgs)
        Me.Hide()
        Form2.Show()
    End Sub

    Private Sub cancelAnimationBtn_Click(sender As Object, e As EventArgs) Handles cancelAnimationBtn.Click
        cancelAnimation = True
    End Sub
    ' USER INPUT END
End Class