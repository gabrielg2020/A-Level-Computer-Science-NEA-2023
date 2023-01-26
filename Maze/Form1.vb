Public Class Form1
    Public maze As mazeClass = New mazeClass
    ' Pen used to draw objects
    Dim pen As Pen = New Pen(Color.Black, 2)
    ' Brush used to fill polygon objects
    Public brush As New SolidBrush(Color.Black)
    ' Controls when the from draws
    Dim drawControl As String = ""

    Public Class mazeClass
        ' Class Attributes
        Public width As Integer ' Width of the grid  Stores 1 less than the actual width, for working with arrays
        Public height As Integer ' Height of the grid; Stores 1 less than the actual height, for working with arrays
        ' This stores the cells that the maze uses
        Public grid As Rectangle(,)
        ' Creates the array that will be used to manipulate the maze
        Public Sub createGrid(ByVal w As Integer, ByVal h As Integer)
            grid = New Rectangle(w, h) {}
            width = w
            height = h
            ' Fills the array with the cells to be drawn
            For i As Integer = 0 To w
                For j As Integer = 0 To h
                    grid(i, j) = New Rectangle(i * 10, j * 10, 10, 10)

                Next
            Next

        End Sub
    End Class

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Populate Combobox Options
        ' Generation Combo Box
        generationCombo.Items.Add("DFS Backtracker")
        generationCombo.Items.Add("Wave Function Collapse")
        generationCombo.Items.Add("Randomised Prims")
        generationCombo.SelectedIndex = 1 ' Makes index 0 default displayed on the combo list(so currently shows "DFS Backtracker" initially
        ' Solve Combo Box
        solveCombo.Items.Add("Dijkstra's Algorithm")
        solveCombo.Items.Add("Breath Frist Search")
        solveCombo.SelectedIndex = 1 ' Default displays (Dijkstra's Algortimn)
        ' Maze Entry Box
        mazeEntryCombo.Items.Add("Top - Bottom")
        mazeEntryCombo.Items.Add("Diagonal")
        mazeEntryCombo.Items.Add("Right - Left")
        mazeEntryCombo.SelectedIndex = 0 ' Default displays "Top - Bottom"
    End Sub

    ' Painting Maze Cells
    ' This paint procedure constantly runs
    Private Sub mazeBox_Paint(sender As Object, e As PaintEventArgs) Handles mazeBox.Paint
        Select Case drawControl
            Case "Initialize Maze Grid" ' Allows the drawing of the maze to start
                ' Draws an empty maze, Allows control of every maze cell
                For w As Integer = 0 To maze.width
                    For h As Integer = 0 To maze.height
                        ' If the cell is on the edge then it will be filled in and be a maze border
                        If w = 0 Or h = 0 Or w = maze.width Or h = maze.height Then
                            e.Graphics.FillRectangle(brush, maze.grid(w, h))
                        End If
                        e.Graphics.DrawRectangle(pen, maze.grid(w, h))
                    Next
                Next
                generateMazeEntryExit(e)
            Case "DFS Backtracker"
                '
                dfsBacktracker(e)


                '
            Case 0
        End Select

    End Sub


    Public Sub generateMazeEntryExit(ByRef e As PaintEventArgs)
        Dim x1, y1, x2, y2 As Integer
        Randomize()
        Select Case mazeEntryCombo.Text
            Case "Top - Bottom"
                ' Start Coordiantes
                x1 = Int(((maze.width - 1) * Rnd()) + 1)
                y1 = 0
                ' End Coordiantes
                x2 = Int(((maze.width - 1) * Rnd()) + 1)
                y2 = maze.height
            Case "Diagonal"
                ' Start Coordiantes
                x1 = 0
                y1 = (maze.height - ((maze.height - 1)))
                ' End Coordianates
                x2 = maze.width
                y2 = (maze.height - 1)
            Case "Right - Left"
                x1 = 0
                y1 = Int(((maze.height - 1) * Rnd()) + 1)
                ' End Coordiantes
                x2 = maze.width
                y2 = Int(((maze.height - 1) * Rnd()) + 1)
        End Select
        ' Marks the entry and exit points on the maze
        Dim tempColour = brush.Color
        brush.Color = Color.White
        e.Graphics.FillRectangle(brush, maze.grid(x1, y1))
        e.Graphics.FillRectangle(brush, maze.grid(x2, y2))
        brush.Color = tempColour

    End Sub

    Private Sub dfsBacktracker(ByRef e As PaintEventArgs)


    End Sub

    ' USER INPUT START
    Private Sub imageInputBtn_Click(sender As Object, e As EventArgs) Handles imageInputBtn.Click
        ' Opens file explorer
        Dim image As DialogResult = openFileDialog1.ShowDialog()
        ' ||Check if image is: type == .JPEG, reselution =< 500 X 268||
    End Sub

    Private Sub bgColourBtn_Click(sender As Object, e As EventArgs) Handles bgColourBtn.Click
        Dim bgColour As Color = selectColour() ' Selects background colour 
        bgColourBtn.Text = bgColour.ToString ' Sets text to the colour
        mazeBox.BackColor = bgColour ' Sets background = background colour
    End Sub

    Private Sub mazeColourBtn_Click(sender As Object, e As EventArgs) Handles mazeColourBtn.Click
        Dim mazeColour As Color = selectColour() ' Selects maze colour 
        brush.Color = mazeColour
        pen.Color = mazeColour
        mazeColourBtn.Text = mazeColour.ToString ' Sets text to the colour
    End Sub

    Private Sub solveColourBtn_Click(sender As Object, e As EventArgs) Handles solveColourBtn.Click
        Dim solveColour As Color = selectColour() ' Selects solve colour 
        solveColourBtn.Text = solveColour.ToString ' Sets text to the colour
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

    Private Sub generateBtn_Click(sender As Object, e As EventArgs) Handles generateBtn.Click


        Dim x As Integer = 0
        Dim y As Integer = 0

        ' This will try and convert the width and height inputs to integers and make sure the integers > 3
        ' If successful x and y will equal width and height and the program will run
        If Integer.TryParse(widthTxtBox.Text, x) And x > 2 And Integer.TryParse(heightTxtBox.Text, y) And y > 2 Then
            maze.createGrid(x - 1, y - 1)
            drawControl = "Initialize Maze Grid"
            mazeBox.Invalidate()
            If generationCombo.Text = "DFS Backtracker" Then
                drawControl = "DFS Backtracker"
            End If
        Else
            ' Error Messsage
            MsgBox("Make sure width and height are integers greater than 3")
        End If


    End Sub

    Private Sub solveBtn_Click(sender As Object, e As EventArgs) Handles solveBtn.Click

    End Sub

    Private Sub downloadBtn_Click(sender As Object, e As EventArgs) Handles downloadBtn.Click

    End Sub

    Private Sub viewStatsBtn_Click(sender As Object, e As EventArgs) Handles viewStatsBtn.Click

    End Sub

    Private Sub mazeBox_LoadCompleted(sender As Object, e As System.ComponentModel.AsyncCompletedEventArgs) Handles mazeBox.LoadCompleted
    End Sub

    ' USER INPUT END
End Class
