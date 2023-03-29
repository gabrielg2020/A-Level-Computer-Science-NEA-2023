<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(Form1))
        Title = New Label()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        Label6 = New Label()
        Label7 = New Label()
        Label8 = New Label()
        Label9 = New Label()
        Label10 = New Label()
        widthTxtBox = New TextBox()
        heightTxtBox = New TextBox()
        deadEndRemoverTxtBox = New TextBox()
        generateBtn = New Button()
        solveBtn = New Button()
        downloadBtn = New Button()
        mazeEntryCombo = New ComboBox()
        generationCombo = New ComboBox()
        solveCombo = New ComboBox()
        imageInputBtn = New Button()
        openFileDialog1 = New OpenFileDialog()
        colorDialog = New ColorDialog()
        solveColourBtn = New Button()
        mazeColourBtn = New Button()
        bgColourBtn = New Button()
        mazeBox = New PictureBox()
        FolderBrowserDialog1 = New FolderBrowserDialog()
        instantAnimationBtn = New CheckBox()
        deadEndRemoverBtn = New Button()
        statsPictureBox = New PictureBox()
        genTimeLbl = New Label()
        solveTimeLbl = New Label()
        drawTimeLbl = New Label()
        deadEndCountLbl = New Label()
        totalTimeLbl = New Label()
        statusLbl = New Label()
        deadEndTimeLbl = New Label()
        helperBtn = New PictureBox()
        solvedPathAnimationTimer = New Timer(components)
        heatMapAnimationTimer = New Timer(components)
        cancelAnimationBtn = New Button()
        CType(mazeBox, ComponentModel.ISupportInitialize).BeginInit()
        CType(statsPictureBox, ComponentModel.ISupportInitialize).BeginInit()
        CType(helperBtn, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Title
        ' 
        resources.ApplyResources(Title, "Title")
        Title.BackColor = Color.Transparent
        Title.ForeColor = Color.Transparent
        Title.Name = "Title"' 
        ' Label1
        ' 
        resources.ApplyResources(Label1, "Label1")
        Label1.BackColor = Color.Transparent
        Label1.ForeColor = Color.White
        Label1.Name = "Label1"' 
        ' Label2
        ' 
        resources.ApplyResources(Label2, "Label2")
        Label2.BackColor = Color.Transparent
        Label2.ForeColor = Color.White
        Label2.Name = "Label2"' 
        ' Label3
        ' 
        resources.ApplyResources(Label3, "Label3")
        Label3.BackColor = Color.Transparent
        Label3.ForeColor = Color.White
        Label3.Name = "Label3"' 
        ' Label4
        ' 
        resources.ApplyResources(Label4, "Label4")
        Label4.BackColor = Color.Transparent
        Label4.ForeColor = Color.White
        Label4.Name = "Label4"' 
        ' Label5
        ' 
        resources.ApplyResources(Label5, "Label5")
        Label5.BackColor = Color.Transparent
        Label5.ForeColor = Color.White
        Label5.Name = "Label5"' 
        ' Label6
        ' 
        resources.ApplyResources(Label6, "Label6")
        Label6.BackColor = Color.Transparent
        Label6.ForeColor = Color.White
        Label6.Name = "Label6"' 
        ' Label7
        ' 
        resources.ApplyResources(Label7, "Label7")
        Label7.BackColor = Color.Transparent
        Label7.ForeColor = Color.White
        Label7.Name = "Label7"' 
        ' Label8
        ' 
        resources.ApplyResources(Label8, "Label8")
        Label8.BackColor = Color.Transparent
        Label8.ForeColor = Color.White
        Label8.Name = "Label8"' 
        ' Label9
        ' 
        resources.ApplyResources(Label9, "Label9")
        Label9.BackColor = Color.Transparent
        Label9.ForeColor = Color.White
        Label9.Name = "Label9"' 
        ' Label10
        ' 
        resources.ApplyResources(Label10, "Label10")
        Label10.BackColor = Color.Transparent
        Label10.ForeColor = Color.White
        Label10.Name = "Label10"' 
        ' widthTxtBox
        ' 
        widthTxtBox.BackColor = Color.FromArgb(CByte(40), CByte(60), CByte(86))
        resources.ApplyResources(widthTxtBox, "widthTxtBox")
        widthTxtBox.ForeColor = Color.White
        widthTxtBox.Name = "widthTxtBox"' 
        ' heightTxtBox
        ' 
        heightTxtBox.BackColor = Color.FromArgb(CByte(40), CByte(60), CByte(86))
        resources.ApplyResources(heightTxtBox, "heightTxtBox")
        heightTxtBox.ForeColor = Color.White
        heightTxtBox.Name = "heightTxtBox"' 
        ' deadEndRemoverTxtBox
        ' 
        deadEndRemoverTxtBox.BackColor = Color.FromArgb(CByte(40), CByte(60), CByte(86))
        resources.ApplyResources(deadEndRemoverTxtBox, "deadEndRemoverTxtBox")
        deadEndRemoverTxtBox.ForeColor = Color.White
        deadEndRemoverTxtBox.Name = "deadEndRemoverTxtBox"' 
        ' generateBtn
        ' 
        generateBtn.BackColor = Color.ForestGreen
        generateBtn.Cursor = Cursors.Hand
        resources.ApplyResources(generateBtn, "generateBtn")
        generateBtn.ForeColor = Color.White
        generateBtn.Name = "generateBtn"
        generateBtn.UseVisualStyleBackColor = False
        ' 
        ' solveBtn
        ' 
        solveBtn.BackColor = Color.Firebrick
        solveBtn.Cursor = Cursors.Hand
        resources.ApplyResources(solveBtn, "solveBtn")
        solveBtn.ForeColor = Color.White
        solveBtn.Name = "solveBtn"
        solveBtn.UseVisualStyleBackColor = False
        ' 
        ' downloadBtn
        ' 
        downloadBtn.BackColor = Color.PaleVioletRed
        resources.ApplyResources(downloadBtn, "downloadBtn")
        downloadBtn.ForeColor = Color.White
        downloadBtn.Name = "downloadBtn"
        downloadBtn.UseVisualStyleBackColor = False
        ' 
        ' mazeEntryCombo
        ' 
        mazeEntryCombo.BackColor = Color.FromArgb(CByte(40), CByte(60), CByte(86))
        mazeEntryCombo.DropDownStyle = ComboBoxStyle.DropDownList
        resources.ApplyResources(mazeEntryCombo, "mazeEntryCombo")
        mazeEntryCombo.ForeColor = Color.White
        mazeEntryCombo.FormattingEnabled = True
        mazeEntryCombo.Items.AddRange(New Object() {resources.GetString("mazeEntryCombo.Items"), resources.GetString("mazeEntryCombo.Items1"), resources.GetString("mazeEntryCombo.Items2"), resources.GetString("mazeEntryCombo.Items3")})
        mazeEntryCombo.Name = "mazeEntryCombo"' 
        ' generationCombo
        ' 
        generationCombo.BackColor = Color.FromArgb(CByte(40), CByte(60), CByte(86))
        generationCombo.Cursor = Cursors.Hand
        resources.ApplyResources(generationCombo, "generationCombo")
        generationCombo.ForeColor = Color.White
        generationCombo.FormattingEnabled = True
        generationCombo.Items.AddRange(New Object() {resources.GetString("generationCombo.Items"), resources.GetString("generationCombo.Items1"), resources.GetString("generationCombo.Items2"), resources.GetString("generationCombo.Items3"), resources.GetString("generationCombo.Items4")})
        generationCombo.Name = "generationCombo"' 
        ' solveCombo
        ' 
        solveCombo.BackColor = Color.FromArgb(CByte(40), CByte(60), CByte(86))
        solveCombo.Cursor = Cursors.Hand
        solveCombo.DropDownStyle = ComboBoxStyle.DropDownList
        resources.ApplyResources(solveCombo, "solveCombo")
        solveCombo.ForeColor = Color.White
        solveCombo.FormattingEnabled = True
        solveCombo.Items.AddRange(New Object() {resources.GetString("solveCombo.Items"), resources.GetString("solveCombo.Items1"), resources.GetString("solveCombo.Items2"), resources.GetString("solveCombo.Items3"), resources.GetString("solveCombo.Items4")})
        solveCombo.Name = "solveCombo"' 
        ' imageInputBtn
        ' 
        imageInputBtn.BackColor = Color.FromArgb(CByte(40), CByte(60), CByte(86))
        imageInputBtn.Cursor = Cursors.Hand
        resources.ApplyResources(imageInputBtn, "imageInputBtn")
        imageInputBtn.ForeColor = Color.White
        imageInputBtn.Name = "imageInputBtn"
        imageInputBtn.UseVisualStyleBackColor = False
        ' 
        ' openFileDialog1
        ' 
        openFileDialog1.FileName = "openFileDialog"' 
        ' solveColourBtn
        ' 
        solveColourBtn.BackColor = Color.FromArgb(CByte(40), CByte(60), CByte(86))
        solveColourBtn.Cursor = Cursors.Hand
        resources.ApplyResources(solveColourBtn, "solveColourBtn")
        solveColourBtn.ForeColor = Color.White
        solveColourBtn.Name = "solveColourBtn"
        solveColourBtn.UseVisualStyleBackColor = False
        ' 
        ' mazeColourBtn
        ' 
        mazeColourBtn.BackColor = Color.FromArgb(CByte(40), CByte(60), CByte(86))
        mazeColourBtn.Cursor = Cursors.Hand
        resources.ApplyResources(mazeColourBtn, "mazeColourBtn")
        mazeColourBtn.ForeColor = Color.White
        mazeColourBtn.Name = "mazeColourBtn"
        mazeColourBtn.UseVisualStyleBackColor = False
        ' 
        ' bgColourBtn
        ' 
        bgColourBtn.BackColor = Color.FromArgb(CByte(40), CByte(60), CByte(86))
        bgColourBtn.Cursor = Cursors.Hand
        resources.ApplyResources(bgColourBtn, "bgColourBtn")
        bgColourBtn.ForeColor = Color.White
        bgColourBtn.Name = "bgColourBtn"
        bgColourBtn.UseVisualStyleBackColor = False
        ' 
        ' mazeBox
        ' 
        mazeBox.BackColor = Color.White
        resources.ApplyResources(mazeBox, "mazeBox")
        mazeBox.Name = "mazeBox"
        mazeBox.TabStop = False
        ' 
        ' instantAnimationBtn
        ' 
        resources.ApplyResources(instantAnimationBtn, "instantAnimationBtn")
        instantAnimationBtn.BackColor = Color.Transparent
        instantAnimationBtn.Checked = True
        instantAnimationBtn.CheckState = CheckState.Checked
        instantAnimationBtn.ForeColor = Color.White
        instantAnimationBtn.Name = "instantAnimationBtn"
        instantAnimationBtn.UseVisualStyleBackColor = False
        ' 
        ' deadEndRemoverBtn
        ' 
        deadEndRemoverBtn.BackColor = Color.DarkCyan
        resources.ApplyResources(deadEndRemoverBtn, "deadEndRemoverBtn")
        deadEndRemoverBtn.ForeColor = Color.White
        deadEndRemoverBtn.Name = "deadEndRemoverBtn"
        deadEndRemoverBtn.UseVisualStyleBackColor = False
        ' 
        ' statsPictureBox
        ' 
        statsPictureBox.BackColor = Color.FromArgb(CByte(40), CByte(60), CByte(86))
        resources.ApplyResources(statsPictureBox, "statsPictureBox")
        statsPictureBox.Name = "statsPictureBox"
        statsPictureBox.TabStop = False
        ' 
        ' genTimeLbl
        ' 
        resources.ApplyResources(genTimeLbl, "genTimeLbl")
        genTimeLbl.BackColor = Color.FromArgb(CByte(40), CByte(60), CByte(86))
        genTimeLbl.ForeColor = Color.White
        genTimeLbl.Name = "genTimeLbl"' 
        ' solveTimeLbl
        ' 
        resources.ApplyResources(solveTimeLbl, "solveTimeLbl")
        solveTimeLbl.BackColor = Color.FromArgb(CByte(40), CByte(60), CByte(86))
        solveTimeLbl.ForeColor = Color.White
        solveTimeLbl.Name = "solveTimeLbl"' 
        ' drawTimeLbl
        ' 
        resources.ApplyResources(drawTimeLbl, "drawTimeLbl")
        drawTimeLbl.BackColor = Color.FromArgb(CByte(40), CByte(60), CByte(86))
        drawTimeLbl.ForeColor = Color.White
        drawTimeLbl.Name = "drawTimeLbl"' 
        ' deadEndCountLbl
        ' 
        resources.ApplyResources(deadEndCountLbl, "deadEndCountLbl")
        deadEndCountLbl.BackColor = Color.FromArgb(CByte(40), CByte(60), CByte(86))
        deadEndCountLbl.ForeColor = Color.White
        deadEndCountLbl.Name = "deadEndCountLbl"' 
        ' totalTimeLbl
        ' 
        resources.ApplyResources(totalTimeLbl, "totalTimeLbl")
        totalTimeLbl.BackColor = Color.FromArgb(CByte(40), CByte(60), CByte(86))
        totalTimeLbl.ForeColor = Color.White
        totalTimeLbl.Name = "totalTimeLbl"' 
        ' statusLbl
        ' 
        resources.ApplyResources(statusLbl, "statusLbl")
        statusLbl.BackColor = Color.Transparent
        statusLbl.ForeColor = Color.White
        statusLbl.Name = "statusLbl"' 
        ' deadEndTimeLbl
        ' 
        resources.ApplyResources(deadEndTimeLbl, "deadEndTimeLbl")
        deadEndTimeLbl.BackColor = Color.FromArgb(CByte(40), CByte(60), CByte(86))
        deadEndTimeLbl.ForeColor = Color.White
        deadEndTimeLbl.Name = "deadEndTimeLbl"' 
        ' helperBtn
        ' 
        helperBtn.BackColor = Color.Transparent
        helperBtn.BackgroundImage = My.Resources.Resources.helper_icon
        helperBtn.Cursor = Cursors.Hand
        resources.ApplyResources(helperBtn, "helperBtn")
        helperBtn.Name = "helperBtn"
        helperBtn.TabStop = False
        ' 
        ' cancelAnimationBtn
        ' 
        cancelAnimationBtn.BackColor = Color.DarkSlateBlue
        resources.ApplyResources(cancelAnimationBtn, "cancelAnimationBtn")
        cancelAnimationBtn.ForeColor = Color.White
        cancelAnimationBtn.Name = "cancelAnimationBtn"
        cancelAnimationBtn.UseVisualStyleBackColor = False
        ' 
        ' Form1
        ' 
        resources.ApplyResources(Me, "$this")
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        BackgroundImage = My.Resources.Resources.formBG
        Controls.Add(cancelAnimationBtn)
        Controls.Add(helperBtn)
        Controls.Add(deadEndTimeLbl)
        Controls.Add(statusLbl)
        Controls.Add(totalTimeLbl)
        Controls.Add(deadEndCountLbl)
        Controls.Add(drawTimeLbl)
        Controls.Add(solveTimeLbl)
        Controls.Add(genTimeLbl)
        Controls.Add(statsPictureBox)
        Controls.Add(deadEndRemoverBtn)
        Controls.Add(instantAnimationBtn)
        Controls.Add(mazeBox)
        Controls.Add(bgColourBtn)
        Controls.Add(mazeColourBtn)
        Controls.Add(solveColourBtn)
        Controls.Add(imageInputBtn)
        Controls.Add(solveCombo)
        Controls.Add(generationCombo)
        Controls.Add(mazeEntryCombo)
        Controls.Add(downloadBtn)
        Controls.Add(solveBtn)
        Controls.Add(generateBtn)
        Controls.Add(deadEndRemoverTxtBox)
        Controls.Add(heightTxtBox)
        Controls.Add(widthTxtBox)
        Controls.Add(Label10)
        Controls.Add(Label9)
        Controls.Add(Label8)
        Controls.Add(Label7)
        Controls.Add(Label6)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(Title)
        MinimizeBox = False
        Name = "Form1"
        CType(mazeBox, ComponentModel.ISupportInitialize).EndInit()
        CType(statsPictureBox, ComponentModel.ISupportInitialize).EndInit()
        CType(helperBtn, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Title As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents widthTxtBox As TextBox
    Friend WithEvents heightTxtBox As TextBox
    Friend WithEvents deadEndRemoverTxtBox As TextBox
    Friend WithEvents generateBtn As Button
    Friend WithEvents solveBtn As Button
    Friend WithEvents downloadBtn As Button
    Friend WithEvents mazeEntryCombo As ComboBox
    Friend WithEvents generationCombo As ComboBox
    Friend WithEvents solveCombo As ComboBox
    Friend WithEvents imageInputBtn As Button
    Friend WithEvents openFileDialog1 As OpenFileDialog
    Friend WithEvents colorDialog As ColorDialog
    Friend WithEvents solveColourBtn As Button
    Friend WithEvents mazeColourBtn As Button
    Friend WithEvents bgColourBtn As Button
    Friend WithEvents mazeBox As PictureBox
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents instantAnimationBtn As CheckBox
    Friend WithEvents deadEndRemoverBtn As Button
    Friend WithEvents statsPictureBox As PictureBox
    Friend WithEvents genTimeLbl As Label
    Friend WithEvents solveTimeLbl As Label
    Friend WithEvents drawTimeLbl As Label
    Friend WithEvents deadEndCountLbl As Label
    Friend WithEvents totalTimeLbl As Label
    Friend WithEvents statusLbl As Label
    Friend WithEvents deadEndTimeLbl As Label
    Friend WithEvents helperBtn As PictureBox
    Friend WithEvents solvedPathAnimationTimer As Timer
    Friend WithEvents heatMapAnimationTimer As Timer
    Friend WithEvents cancelAnimationBtn As Button
End Class
