Imports Microsoft.VisualBasic.PowerPacks
Public Class Form1
    Public shapeCon As New ShapeContainer

    Public maze As MazeClass = New MazeClass
    ' Pen used to draw objects
    Dim pen As Pen = New Pen(Color.Black, 2)
    ' Brush used to fill polygon objects
    Public brush As New SolidBrush(Color.Black)
    ' Controls when the from draws
    Dim drawControl As String = ""

    Public Class Cell
        Public posX As Integer
        Public posY As Integer
        Public wallsBool(3)
        Public walls(3) As LineShape


        Public Sub New()
            ' A New cell will always have all 4 walls next to them
            For i As Integer = 0 To 3
                wallsBool(i) = True
                walls(i) = New LineShape
            Next
        End Sub
    End Class

    Public Class MazeClass
        Public width As Integer
        Public height As Integer
        Public grid As Cell(,)

        Public Sub initializeGrid(ByVal w, ByVal h, ByRef shapeCon)
            width = w
            height = h

            grid = New Cell(w, h) {}
            For i As Integer = 0 To width
                For j As Integer = 0 To height
                    grid(i, j) = New Cell
                    grid(i, j).posX = i
                    grid(i, j).posY = j
                    For k As Integer = 0 To 3
                        grid(i, j).walls(k).Parent = shapeCon
                        If k = 0 Then ' Top
                            grid(i, j).walls(k).StartPoint = New System.Drawing.Point(i * 10, j * 10)
                            grid(i, j).walls(k).EndPoint = New System.Drawing.Point((i * 10) + 10, j * 10)
                        ElseIf k = 1 Then ' Right
                            grid(i, j).walls(k).StartPoint = New System.Drawing.Point((i * 10) + 10, j * 10)
                            grid(i, j).walls(k).EndPoint = New System.Drawing.Point((i * 10) + 10, (j * 10) + 10)
                        ElseIf k = 2 Then ' Bottom
                            grid(i, j).walls(k).StartPoint = New System.Drawing.Point(i * 10, (j * 10) + 10)
                            grid(i, j).walls(k).EndPoint = New System.Drawing.Point((i * 10) + 10, (j * 10) + 10)
                        ElseIf k = 3 Then '  Left
                            grid(i, j).walls(k).StartPoint = New System.Drawing.Point(i * 10, j * 10)
                            grid(i, j).walls(k).EndPoint = New System.Drawing.Point(i * 10, (j * 10) + 10)
                        End If


                    Next

                Next
            Next
        End Sub
    End Class

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        shapeCon.Parent = mazeBox
        ' Populate Combobox Options
        ' Generation Combo Box
        generationCombo.Items.Add("DFS Backtracker")
        generationCombo.Items.Add("Wave Function Collapse")
        generationCombo.Items.Add("Randomised Prims")
        generationCombo.SelectedIndex = 2 ' Makes index 0 default displayed on the combo list(so currently shows "DFS Backtracker" initially
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
    Private Sub drawBaseMaze()

    End Sub
    Private Sub mazeBox_Paint(sender As Object, e As PaintEventArgs) Handles mazeBox.Paint
        Select Case drawControl
            Case drawControl = "Initialize Maze Grid"
                
        End Select
    End Sub
    Private Sub generateBtn_Click(sender As Object, e As EventArgs) Handles generateBtn.Click


        maze.initializeGrid(widthTxtBox.Text - 1, heightTxtBox.Text - 1, shapeCon)
        drawControl = "Initialize Maze Grid"
        'mazeBox.Invalidate()
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



    Private Sub solveBtn_Click(sender As Object, e As EventArgs) Handles solveBtn.Click

        shapeCon.Update()
    End Sub

    Private Sub downloadBtn_Click(sender As Object, e As EventArgs) Handles downloadBtn.Click

    End Sub

    Private Sub viewStatsBtn_Click(sender As Object, e As EventArgs) Handles viewStatsBtn.Click

    End Sub

    ' USER INPUT END


End Class
