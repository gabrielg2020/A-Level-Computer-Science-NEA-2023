Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Populate Combobox Options
        ' Generation Combo Box
        generationCombo.Items.Add("DFS Backtracker")
        generationCombo.Items.Add("Wave Function Collapse")
        generationCombo.Items.Add("Randomised Prims")
        ' Solve Combo Box
        solveCombo.Items.Add("Dijkstra's Algorithm")
        solveCombo.Items.Add("Breath Frist Search")
        ' Maze Entry Box
        mazeEntryCombo.Items.Add("Top - Bottom")
        mazeEntryCombo.Items.Add("Diagonal")
        mazeEntryCombo.Items.Add("Right - Left")
    End Sub

    Private Sub imageInputBtn_Click(sender As Object, e As EventArgs) Handles imageInputBtn.Click
        ' Opens file explorer
        Dim image As DialogResult = openFileDialog1.ShowDialog()
        ' ||Check if image is: type == .JPEG, reselution =< 500 X 268||
    End Sub

    Private Sub bgColourBtn_Click(sender As Object, e As EventArgs) Handles bgColourBtn.Click
        Dim bgColour As Color = selectColour() ' Selects background colour 
        bgColourBtn.Text = bgColour.ToString ' Sets text to the colour
        mazePanel.BackColor = bgColour ' Sets background = background colour
    End Sub

    Private Sub mazeColourBtn_Click(sender As Object, e As EventArgs) Handles mazeColourBtn.Click
        Dim mazeColour As Color = selectColour() ' Selects maze colour 
        mazeColourBtn.Text = mazeColour.ToString ' Sets text to the colour
    End Sub

    Private Sub solveColourBtn_Click(sender As Object, e As EventArgs) Handles solveColourBtn.Click
        Dim solveColour As Color = selectColour() ' Selects solve colour 
        solveColourBtn.Text = solveColour.ToString ' Sets text to the colour
    End Sub

    Private Sub widthTxtBox_TextChanged(sender As Object, e As EventArgs) Handles widthTxtBox.TextChanged
        ' Must be an integer between 2-500
        Dim width = widthTxtBox.Text
    End Sub

    Private Sub heightTxtBox_TextChanged(sender As Object, e As EventArgs) Handles heightTxtBox.TextChanged
        ' Must be an integer between 2-268
        Dim height = heightTxtBox.Text
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
End Class
