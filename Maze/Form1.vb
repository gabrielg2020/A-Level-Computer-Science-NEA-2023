﻿Public Class Form1
    ' Constants
    Public M As Integer = 30
    Public maze As Cell(,)
    ' Pen used to draw objects
    Public pen As Pen = New Pen(Color.Black, 1)
    Public brush As SolidBrush = New SolidBrush(Color.Black)
    Public brush2 As SolidBrush = New SolidBrush(Color.Black)
    ' Maze properties
    Public width As Integer
    Public height As Integer
    Public mazeEntryType As String
    Public generationType As String
    Public mazeEntry As Point
    Public mazeExit As Point
    Public mazeColour As Color
    Public solveColour As Color

    ' Controls when the from draws
    Dim drawControl As String = ""

    Public Class Cell
        Public xPos As Integer
        Public yPos As Integer
        Public walls As List(Of Boolean) = New List(Of Boolean)
        Public wallPos(3, 1) As Point
        Public mazeWallBool As Boolean = False
        Public mazeEntryBool As Boolean = False
        Public mazeExitBool As Boolean = False
        Public mazeSolved As Boolean = False


        Public weight As Integer = 0
        Public visited As Boolean = False


        Public Sub New()
            For i As Integer = 0 To 3
                walls.Add(True)
            Next
        End Sub
    End Class

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Populate Combobox Options
        ' Generation Combo Box
        generationCombo.Items.Add("DFS Backtracker")
        generationCombo.Items.Add("Wave Function Collapse")
        generationCombo.Items.Add("Randomised Prims")
        generationCombo.SelectedIndex = 0 ' Makes index 0 default displayed on the combo list(so currently shows "DFS Backtracker" initially
        ' Solve Combo Box
        solveCombo.Items.Add("Dijkstra's Algorithm")
        solveCombo.Items.Add("Breath Frist Search")
        solveCombo.SelectedIndex = 0 ' Default displays (Dijkstra's Algortimn)
        ' Maze Entry Box
        mazeEntryCombo.Items.Add("Random")
        mazeEntryCombo.Items.Add("Top - Bottom")
        mazeEntryCombo.Items.Add("Right - Left")
        mazeEntryCombo.Items.Add("Diagonal")
        mazeEntryCombo.SelectedIndex = 0 ' Default displays "Top - Bottom"
    End Sub

    ' Painting Maze Cells
    ' This paint procedure constantly runs
    Private Sub mazeBox_Paint(sender As Object, e As PaintEventArgs) Handles mazeBox.Paint
        Select Case drawControl
            Case "Generate"
                If generationCombo.Text = "DFS Backtracker" Then
                    'randomisedDFS(e)
                    createAMaze(e)
                    drawMaze(e)
                End If
            Case "Solve"
                If solveCombo.Text = "Dijkstra's Algorithm" Then
                    dijkstra()
                    drawMaze(e)
                End If
        End Select
    End Sub

    Private Sub setMazeEntryExit()
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

        mazeEntry = New Point(1, 3)
        mazeExit = New Point(3, 1)

    End Sub

    Private Sub initializeMazeDraw()
        maze = New Cell(width, height) {}
        For i As Integer = 0 To width
            For j As Integer = 0 To height
                maze(i, j) = New Cell
                maze(i, j).xPos = i * M
                maze(i, j).yPos = j * M


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
                            maze(i, j).wallPos(k, 0) = New Point(maze(i, j).xPos, maze(i, j).yPos)
                            ' End Point
                            maze(i, j).wallPos(k, 1) = New Point(maze(i, j).xPos + M, maze(i, j).yPos)
                        Case 1 ' Rigth line
                            ' Start Point
                            maze(i, j).wallPos(k, 0) = New Point(maze(i, j).xPos + M, maze(i, j).yPos)
                            ' End Point
                            maze(i, j).wallPos(k, 1) = New Point(maze(i, j).xPos + M, maze(i, j).yPos + M)
                        Case 2 ' Left Line
                            ' Start Point
                            maze(i, j).wallPos(k, 0) = New Point(maze(i, j).xPos, maze(i, j).yPos + M)
                            ' End Point
                            maze(i, j).wallPos(k, 1) = New Point(maze(i, j).xPos + M, maze(i, j).yPos + M)
                        Case 3 ' Bottom Line
                            ' Start Point
                            maze(i, j).wallPos(k, 0) = New Point(maze(i, j).xPos, maze(i, j).yPos)
                            ' End Point
                            maze(i, j).wallPos(k, 1) = New Point(maze(i, j).xPos, maze(i, j).yPos + M)
                    End Select
                Next
            Next
        Next
    End Sub
    Private Sub drawMaze(ByRef e As PaintEventArgs)
        For type As Integer = 0 To 2
            For i As Integer = 0 To width
                For j As Integer = 0 To height
                    Select Case type
                        Case 0 ' Drawing base maze
                            For k As Integer = 0 To 3
                                If maze(i, j).walls(k) = True Then
                                    e.Graphics.DrawLine(pen, maze(i, j).wallPos(k, 0), maze(i, j).wallPos(k, 1))
                                End If
                            Next
                        Case 1 ' Drawing maze walls
                            If maze(i, j).mazeWallBool = True Then
                                e.Graphics.FillRectangle(brush, maze(i, j).wallPos(0, 0).X, maze(i, j).wallPos(0, 0).Y, M, M)
                            End If
                        Case 2 ' Drawing solved
                            If maze(i, j).mazeSolved = True Then
                                brush2.Color = solveColour
                                e.Graphics.FillRectangle(brush2, maze(i, j).wallPos(0, 0).X, maze(i, j).wallPos(0, 0).Y, M, M)
                            End If
                    End Select
                Next
            Next
        Next
        If maze(mazeEntry.X, mazeEntry.Y).mazeEntryBool = True Then ' Draws the maze entry
            brush2.Color = Color.Green
            e.Graphics.FillRectangle(brush2, maze(mazeEntry.X, mazeEntry.Y).wallPos(0, 0).X, maze(mazeEntry.X, mazeEntry.Y).wallPos(0, 0).Y, M, M)
        End If
        If maze(mazeExit.X, mazeExit.Y).mazeExitBool = True Then ' Draws the maze exit
            brush2.Color = Color.Red
            e.Graphics.FillRectangle(brush2, maze(mazeExit.X, mazeExit.Y).wallPos(0, 0).X, maze(mazeExit.X, mazeExit.Y).wallPos(0, 0).Y, M, M)
        End If
    End Sub
    Private Sub breakWall(ByVal side As Integer, ByVal xPos As Integer, ByVal yPos As Integer)
        Select Case side
            Case 0 ' Take away top wall
                maze(xPos, yPos).walls(0) = False
                Try
                    maze(xPos, yPos - 1).walls(2) = False
                Catch ex As Exception
                    ' Do nothing as this must be a maze wall
                End Try

            Case 1 ' Take away right wall
                maze(xPos, yPos).walls(1) = False
                Try
                    maze(xPos + 1, yPos).walls(3) = False
                Catch ex As Exception
                    ' Do nothing as this must be a maze wall
                End Try

            Case 2 ' Take away bottom wall
                maze(xPos, yPos).walls(2) = False
                Try
                    maze(xPos, yPos + 1).walls(0) = False
                Catch ex As Exception
                    ' Do nothing as this must be a maze wall
                End Try

            Case 3 ' Take away left wall
                maze(xPos, yPos).walls(3) = False
                Try
                    maze(xPos - 1, yPos).walls(1) = False
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
    Private Sub randomisedDFS(ByRef e As PaintEventArgs)
        Dim stack As Stack(Of Point) = New Stack(Of Point)
        Randomize()
        Dim node As Point = New Point(Int((width - 1) * Rnd()) + 1, Int((height - 1) * Rnd()) + 1)
        stack.Push(node)
        Dim direction As Integer

        Dim neigbours As List(Of Boolean) = New List(Of Boolean)

        While stack.Count <> 0
            neigbours = checkUnvisitedNeighbours(node.X, node.Y)
            If node = New Point(0, 0) Then
                Debug.WriteLine("")
            End If
            Dim c As Integer = 0
            For i As Integer = 0 To 3
                If neigbours(i) = False Then
                    c += 1
                End If
            Next

            Randomize()
            direction = Int(4 * Rnd())
            If c = 4 Then ' There are no open neighbours
                maze(node.X, node.Y).visited = True
                node = stack.Pop()
            Else ' There is an open neighbour
                While neigbours(direction) = False ' Makes sure it moves into an open neighbour
                    Randomize()
                    direction = Int(4 * Rnd())
                End While
                If stack.Peek <> node Then ' Makes sure the first node searched doesnt get inputted twice
                    stack.Push(node)
                End If
                maze(node.X, node.Y).visited = True
                breakWall(direction, node.X, node.Y)
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
        ' Make sure that the entryCell and exitCell have walls broken

    End Sub
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
    Private Sub createAMaze(ByRef e As PaintEventArgs)

        maze(1, 1).walls(0) = True
        maze(1, 1).walls(1) = False
        maze(1, 1).walls(2) = False
        maze(1, 1).walls(3) = True

        maze(1, 2).walls(0) = False
        maze(1, 2).walls(1) = True
        maze(1, 2).walls(2) = False
        maze(1, 2).walls(3) = True

        maze(1, 3).walls(0) = False
        maze(1, 3).walls(1) = False
        maze(1, 3).walls(2) = True
        maze(1, 3).walls(3) = True

        maze(2, 1).walls(0) = True
        maze(2, 1).walls(1) = True
        maze(2, 1).walls(2) = False
        maze(2, 1).walls(3) = False


        maze(2, 2).walls(0) = False
        maze(2, 2).walls(1) = False
        maze(2, 2).walls(2) = True
        maze(2, 2).walls(3) = True

        maze(2, 3).walls(0) = True
        maze(2, 3).walls(1) = False
        maze(2, 3).walls(2) = True
        maze(2, 3).walls(3) = False



        maze(3, 1).walls(0) = True
        maze(3, 1).walls(1) = True
        maze(3, 1).walls(2) = False
        maze(3, 1).walls(3) = True

        maze(3, 2).walls(0) = False
        maze(3, 2).walls(1) = True
        maze(3, 2).walls(2) = False
        maze(3, 2).walls(3) = False

        maze(3, 3).walls(0) = False
        maze(3, 3).walls(1) = True
        maze(3, 3).walls(2) = True
        maze(3, 3).walls(3) = False


    End Sub

    Private Sub dijkstra()
        Dim startNode As Point = mazeEntry
        Dim tempNode As Point
        Dim queue As Queue(Of Point) = New Queue(Of Point)
        Dim visited As List(Of Point) = New List(Of Point)
        Dim weight As Integer = 0

        ' Weight the nodes
        maze(startNode.X, startNode.Y).weight = 0
        visited.Add(New Point(startNode.X, startNode.Y))
        weight = 1
        For Each point In checkConnectedCell(startNode.X, startNode.Y)
            queue.Enqueue(point)
        Next

        While queue.Count <> 0
            For i = 0 To queue.Count - 1
                tempNode = queue.Dequeue()
                maze(tempNode.X, tempNode.Y).weight = weight
                visited.Add(New Point(tempNode.X, tempNode.Y))
                For Each point In checkConnectedCell(tempNode.X, tempNode.Y)
                    If visited.Contains(point) = False And queue.Contains(point) = False Then
                        queue.Enqueue(point)
                    End If
                Next
            Next
            weight += 1
        End While

        Dim endNode As Point = mazeExit
        Dim path As List(Of Point) = New List(Of Point)
        While endNode <> startNode
            For Each node In visited
                If maze(node.X, node.Y).weight = maze(endNode.X, endNode.Y).weight - 1 And checkConnectedCell(endNode.X, endNode.Y).Contains(New Point(node.X, node.Y)) Then
                    path.Add(node)
                    endNode = node
                    Exit For
                End If
            Next
        End While
        path.Remove(startNode)



        For Each i In path
            Debug.WriteLine(Str(i.X) + "," + Str(i.Y))
        Next


    End Sub

    Private Sub generateBtn_Click(sender As Object, e As EventArgs) Handles generateBtn.Click
        'Save Maze Properties inputted by the user
        width = Int(widthTxtBox.Text) - 1
        height = Int(heightTxtBox.Text) - 1
        mazeEntryType = mazeEntryCombo.Text

        setMazeEntryExit()
        initializeMazeDraw()




        drawControl = "Generate"
        mazeBox.Invalidate()

    End Sub

    Private Sub solveBtn_Click(sender As Object, e As EventArgs) Handles solveBtn.Click
        drawControl = "Solve"
        mazeBox.Invalidate()

    End Sub


    ' USER INPUT START
    Private Sub imageInputBtn_Click(sender As Object, e As EventArgs) Handles imageInputBtn.Click
        ' Opens file explorer
        Dim image As DialogResult = openFileDialog1.ShowDialog()
        ' ||Check if image is: type == .JPEG, reselution =< 500 X 268||
    End Sub

    Private Sub bgColourBtn_Click(sender As Object, e As EventArgs) Handles bgColourBtn.Click
        Dim bgColour As Color = selectColour() ' Selects background colour 
        mazeBox.BackColor = bgColour ' Sets background = background colour
        bgColourBtn.Text = bgColour.ToString
    End Sub

    Private Sub mazeColourBtn_Click(sender As Object, e As EventArgs) Handles mazeColourBtn.Click
        mazeColour = selectColour() ' Selects maze colour 
        pen.Color = mazeColour
        brush.Color = mazeColour
        mazeColourBtn.Text = mazeColour.ToString
    End Sub

    Private Sub solveColourBtn_Click(sender As Object, e As EventArgs) Handles solveColourBtn.Click
        Dim solveColour As Color = selectColour() ' Selects solve colour 
        solveColourBtn.Text = solveColour.ToString
    End Sub

    Private Sub widthTxtBox_TextChanged(sender As Object, e As EventArgs) Handles widthTxtBox.TextChanged
        ' Must be an integer between 2-500

    End Sub

    Private Sub heightTxtBox_TextChanged(sender As Object, e As EventArgs) Handles heightTxtBox.TextChanged
        ' Must be an integer between 2-268

    End Sub

    Private Sub deadEndRemoverTxtBox_TextChanged(sender As Object, e As EventArgs) Handles deadEndRemoverTxtBox.TextChanged
        ' Must be a float 0-1
        Dim deadEndPecent = deadEndRemoverTxtBox.Text
    End Sub
    ' Opens a colour picker and returns the selected colour
    Function selectColour() As Color
        colorDialog.ShowDialog() ' Opens colour picker
        Return colorDialog.Color ' Returns picked colour
    End Function

    Private Sub generationCombo_SelectedValueChanged(sender As Object, e As EventArgs) Handles generationCombo.SelectedValueChanged
        Dim generationAlgorithm = generationCombo.SelectedItem
    End Sub

    Private Sub solveCombo_SelectedValueChanged(sender As Object, e As EventArgs) Handles solveCombo.SelectedValueChanged
        Dim solveAlgorithm = solveCombo.SelectedItem
    End Sub

    Private Sub mazeEntryCombo_SelectedValueChanged(sender As Object, e As EventArgs) Handles mazeEntryCombo.SelectedValueChanged
        Dim mazeEntry = mazeEntryCombo.SelectedItem
    End Sub

    Private Sub downloadBtn_Click(sender As Object, e As EventArgs) Handles downloadBtn.Click

    End Sub

    Private Sub viewStatsBtn_Click(sender As Object, e As EventArgs) Handles viewStatsBtn.Click

    End Sub

    Private Sub mazeBox_LoadCompleted(sender As Object, e As System.ComponentModel.AsyncCompletedEventArgs) Handles mazeBox.LoadCompleted
    End Sub



    ' USER INPUT END
End Class
