Public Class Form2
    Private currentIndex As Integer = 0
    Const MAX_NUMBER_OF_IMAGES = 2

    Private Sub backBtn_Click(sender As Object, e As EventArgs) Handles backBtn.Click
        Me.Hide()
        Form1.Show()
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        images.Image = indexImages(currentIndex)
    End Sub

    Private Sub Form2_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
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
        If currentIndex < MAX_NUMBER_OF_IMAGES Then
            currentIndex = 0
        End If

        images.Image = indexImages(currentIndex)
    End Sub

    Private Function indexImages(ByVal index As Integer) As Image
        Select Case index
            Case 0
                Return My.Resources.helperBG
            Case 1
                Return My.Resources.helper_icon
            Case 2
                Return My.Resources.back_button
            Case Else
                Return Nothing
        End Select
    End Function


End Class