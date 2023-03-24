<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        images = New PictureBox()
        goRightBtn = New Button()
        goLeftbtn = New Button()
        tutorialTxt = New TextBox()
        backBtn = New PictureBox()
        Title = New Label()
        CType(images, ComponentModel.ISupportInitialize).BeginInit()
        CType(backBtn, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' images
        ' 
        images.Location = New Point(119, 117)
        images.Name = "images"
        images.Size = New Size(751, 500)
        images.TabIndex = 0
        images.TabStop = False
        ' 
        ' goRightBtn
        ' 
        goRightBtn.BackColor = Color.Firebrick
        goRightBtn.Cursor = Cursors.Hand
        goRightBtn.FlatStyle = FlatStyle.Flat
        goRightBtn.Font = New Font("Segoe UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point)
        goRightBtn.ForeColor = Color.White
        goRightBtn.Location = New Point(876, 117)
        goRightBtn.Name = "goRightBtn"
        goRightBtn.Size = New Size(89, 500)
        goRightBtn.TabIndex = 3
        goRightBtn.Text = ">"
        goRightBtn.UseVisualStyleBackColor = False
        ' 
        ' goLeftbtn
        ' 
        goLeftbtn.BackColor = Color.Firebrick
        goLeftbtn.Cursor = Cursors.Hand
        goLeftbtn.FlatStyle = FlatStyle.Flat
        goLeftbtn.Font = New Font("Segoe UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point)
        goLeftbtn.ForeColor = Color.White
        goLeftbtn.Location = New Point(24, 117)
        goLeftbtn.Name = "goLeftbtn"
        goLeftbtn.Size = New Size(89, 500)
        goLeftbtn.TabIndex = 4
        goLeftbtn.Text = "<"
        goLeftbtn.UseVisualStyleBackColor = False
        ' 
        ' tutorialTxt
        ' 
        tutorialTxt.Font = New Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point)
        tutorialTxt.Location = New Point(119, 623)
        tutorialTxt.Multiline = True
        tutorialTxt.Name = "tutorialTxt"
        tutorialTxt.Size = New Size(751, 72)
        tutorialTxt.TabIndex = 5
        tutorialTxt.TextAlign = HorizontalAlignment.Center
        ' 
        ' backBtn
        ' 
        backBtn.BackColor = Color.Transparent
        backBtn.BackgroundImage = My.Resources.Resources.back_button
        backBtn.Cursor = Cursors.Hand
        backBtn.ImeMode = ImeMode.NoControl
        backBtn.Location = New Point(12, 12)
        backBtn.Name = "backBtn"
        backBtn.Size = New Size(64, 64)
        backBtn.TabIndex = 46
        backBtn.TabStop = False
        ' 
        ' Title
        ' 
        Title.AutoSize = True
        Title.BackColor = Color.Transparent
        Title.Font = New Font("Segoe UI", 72F, FontStyle.Regular, GraphicsUnit.Point)
        Title.ForeColor = Color.Transparent
        Title.ImeMode = ImeMode.NoControl
        Title.Location = New Point(281, -14)
        Title.Name = "Title"
        Title.Size = New Size(416, 128)
        Title.TabIndex = 47
        Title.Text = "Tutorials"' 
        ' Form2
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = My.Resources.Resources.helperBG
        ClientSize = New Size(984, 716)
        Controls.Add(Title)
        Controls.Add(backBtn)
        Controls.Add(tutorialTxt)
        Controls.Add(goLeftbtn)
        Controls.Add(goRightBtn)
        Controls.Add(images)
        Name = "Form2"
        Text = "Form2"
        CType(images, ComponentModel.ISupportInitialize).EndInit()
        CType(backBtn, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents images As PictureBox
    Friend WithEvents goRightBtn As Button
    Friend WithEvents goLeftbtn As Button
    Friend WithEvents tutorialTxt As TextBox
    Friend WithEvents backBtn As PictureBox
    Friend WithEvents Title As Label
End Class
