Public Class Form2
    Private currentIndex As Integer = 0
    Const MAX_NUMBER_OF_IMAGES = 10
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub backBtn_Click(sender As Object, e As EventArgs) Handles backBtn.Click
        Me.Hide()
        Form1.Show()
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        images.Image = indexImages(currentIndex)

    End Sub

    Private Sub Form2_FormClosed(sender As Object, e As FormClosedEventArgs)
        Me.Hide()
        Form1.Show()
    End Sub

    Private Sub goLeftbtn_Click(sender As Object, e As EventArgs) Handles goLeftbtn.Click
        currentIndex -= 1
        If currentIndex < 0 Then
            currentIndex = MAX_NUMBER_OF_IMAGES
        End If

        images.Image = indexImages(currentIndex)
    End Sub

    Private Sub goRightBtn_Click(sender As Object, e As EventArgs) Handles goRightBtn.Click
        currentIndex += 1
        If currentIndex > MAX_NUMBER_OF_IMAGES Then
            currentIndex = 0
        End If

        images.Image = indexImages(currentIndex)
    End Sub

    Private Function indexImages(ByVal index As Integer) As Image
        Select Case index
            Case 0 ' Width/Height
                tutorialTxt.Text = "You can change the size of your maze using the width and height textboxs. Values between 3-7722."
                Return My.Resources.width_height
            Case 1 ' Maze Entry
                tutorialTxt.Text = "You can change where the maze entry and exit cells are."
                Return My.Resources.maze_entry
            Case 2 ' Dead End Remover
                tutorialTxt.Text = "You can remove a percentage of dead ends using dead end remover textbox. Values between 0-1."
                Return My.Resources.dead_end_remover
            Case 3 ' Colours
                tutorialTxt.Text = "You can customise the background, maze and solve colours."
                Return My.Resources.colours
            '|NEED DOING|
            Case 4 ' Generation Algorithim
                tutorialTxt.Text = "You can change which algorithim generates the maze."
            '|NEED DOING|
            Case 5 ' Solving Algorithim
                tutorialTxt.Text = "You can change which algorithim solves the maze"
            '|NEED DOING|
            Case 6 ' Instant Animation
                tutorialTxt.Text = "You can see how each algorithim works (includes: Generation, Solving and Dead End Removal algoritim)."
            Case 7 ' Download Button
                tutorialTxt.Text = "You can download any maze that is currently being displayed."
                Return My.Resources.download
            '|NEED DOING|
            Case 8 ' Image Input
                tutorialTxt.Text = "You can input a .JPG image to turn it into a maze."
            '|NEED DOING|
            Case 9 ' Stats
                tutorialTxt.Text = "You can see the statisitics of each maze being displayed."
            '|NEED DOING|
            Case 10 ' Status
                tutorialTxt.Text = "You can see how far along the maze generation is."

            Case Else
                Return Nothing
        End Select
    End Function


End Class