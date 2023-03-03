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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Title = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.widthTxtBox = New System.Windows.Forms.TextBox()
        Me.heightTxtBox = New System.Windows.Forms.TextBox()
        Me.deadEndRemoverTxtBox = New System.Windows.Forms.TextBox()
        Me.generateBtn = New System.Windows.Forms.Button()
        Me.solveBtn = New System.Windows.Forms.Button()
        Me.downloadBtn = New System.Windows.Forms.Button()
        Me.mazeEntryCombo = New System.Windows.Forms.ComboBox()
        Me.generationCombo = New System.Windows.Forms.ComboBox()
        Me.solveCombo = New System.Windows.Forms.ComboBox()
        Me.imageInputBtn = New System.Windows.Forms.Button()
        Me.openFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.colorDialog = New System.Windows.Forms.ColorDialog()
        Me.solveColourBtn = New System.Windows.Forms.Button()
        Me.mazeColourBtn = New System.Windows.Forms.Button()
        Me.bgColourBtn = New System.Windows.Forms.Button()
        Me.mazeBox = New System.Windows.Forms.PictureBox()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.instantAnimationBtn = New System.Windows.Forms.CheckBox()
        Me.deadEndRemoverBtn = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.genTimeLbl = New System.Windows.Forms.Label()
        Me.solveTimeLbl = New System.Windows.Forms.Label()
        Me.drawTimeLbl = New System.Windows.Forms.Label()
        Me.deadEndCountLbl = New System.Windows.Forms.Label()
        Me.totalTimeLbl = New System.Windows.Forms.Label()
        Me.statusLbl = New System.Windows.Forms.Label()
        CType(Me.mazeBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Title
        '
        resources.ApplyResources(Me.Title, "Title")
        Me.Title.BackColor = System.Drawing.Color.Transparent
        Me.Title.ForeColor = System.Drawing.Color.Transparent
        Me.Title.Name = "Title"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Name = "Label1"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Name = "Label2"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Name = "Label3"
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Name = "Label4"
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Name = "Label5"
        '
        'Label6
        '
        resources.ApplyResources(Me.Label6, "Label6")
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Name = "Label6"
        '
        'Label7
        '
        resources.ApplyResources(Me.Label7, "Label7")
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Name = "Label7"
        '
        'Label8
        '
        resources.ApplyResources(Me.Label8, "Label8")
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Name = "Label8"
        '
        'Label9
        '
        resources.ApplyResources(Me.Label9, "Label9")
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Name = "Label9"
        '
        'Label10
        '
        resources.ApplyResources(Me.Label10, "Label10")
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Name = "Label10"
        '
        'widthTxtBox
        '
        Me.widthTxtBox.BackColor = System.Drawing.Color.White
        resources.ApplyResources(Me.widthTxtBox, "widthTxtBox")
        Me.widthTxtBox.ForeColor = System.Drawing.Color.Black
        Me.widthTxtBox.Name = "widthTxtBox"
        '
        'heightTxtBox
        '
        Me.heightTxtBox.BackColor = System.Drawing.Color.White
        resources.ApplyResources(Me.heightTxtBox, "heightTxtBox")
        Me.heightTxtBox.ForeColor = System.Drawing.Color.Black
        Me.heightTxtBox.Name = "heightTxtBox"
        '
        'deadEndRemoverTxtBox
        '
        Me.deadEndRemoverTxtBox.BackColor = System.Drawing.Color.White
        resources.ApplyResources(Me.deadEndRemoverTxtBox, "deadEndRemoverTxtBox")
        Me.deadEndRemoverTxtBox.ForeColor = System.Drawing.Color.Black
        Me.deadEndRemoverTxtBox.Name = "deadEndRemoverTxtBox"
        '
        'generateBtn
        '
        Me.generateBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.generateBtn.Cursor = System.Windows.Forms.Cursors.Hand
        resources.ApplyResources(Me.generateBtn, "generateBtn")
        Me.generateBtn.Name = "generateBtn"
        Me.generateBtn.UseVisualStyleBackColor = False
        '
        'solveBtn
        '
        Me.solveBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.solveBtn.Cursor = System.Windows.Forms.Cursors.Hand
        resources.ApplyResources(Me.solveBtn, "solveBtn")
        Me.solveBtn.Name = "solveBtn"
        Me.solveBtn.UseVisualStyleBackColor = False
        '
        'downloadBtn
        '
        resources.ApplyResources(Me.downloadBtn, "downloadBtn")
        Me.downloadBtn.ForeColor = System.Drawing.Color.DeepSkyBlue
        Me.downloadBtn.Name = "downloadBtn"
        Me.downloadBtn.UseVisualStyleBackColor = True
        '
        'mazeEntryCombo
        '
        Me.mazeEntryCombo.BackColor = System.Drawing.Color.White
        Me.mazeEntryCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.mazeEntryCombo, "mazeEntryCombo")
        Me.mazeEntryCombo.ForeColor = System.Drawing.Color.Black
        Me.mazeEntryCombo.FormattingEnabled = True
        Me.mazeEntryCombo.Items.AddRange(New Object() {resources.GetString("mazeEntryCombo.Items"), resources.GetString("mazeEntryCombo.Items1"), resources.GetString("mazeEntryCombo.Items2"), resources.GetString("mazeEntryCombo.Items3")})
        Me.mazeEntryCombo.Name = "mazeEntryCombo"
        '
        'generationCombo
        '
        Me.generationCombo.BackColor = System.Drawing.Color.White
        Me.generationCombo.Cursor = System.Windows.Forms.Cursors.Hand
        resources.ApplyResources(Me.generationCombo, "generationCombo")
        Me.generationCombo.ForeColor = System.Drawing.Color.Black
        Me.generationCombo.FormattingEnabled = True
        Me.generationCombo.Items.AddRange(New Object() {resources.GetString("generationCombo.Items"), resources.GetString("generationCombo.Items1"), resources.GetString("generationCombo.Items2")})
        Me.generationCombo.Name = "generationCombo"
        '
        'solveCombo
        '
        Me.solveCombo.BackColor = System.Drawing.Color.White
        Me.solveCombo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.solveCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.solveCombo, "solveCombo")
        Me.solveCombo.ForeColor = System.Drawing.Color.Black
        Me.solveCombo.FormattingEnabled = True
        Me.solveCombo.Items.AddRange(New Object() {resources.GetString("solveCombo.Items"), resources.GetString("solveCombo.Items1")})
        Me.solveCombo.Name = "solveCombo"
        '
        'imageInputBtn
        '
        Me.imageInputBtn.BackColor = System.Drawing.Color.White
        Me.imageInputBtn.Cursor = System.Windows.Forms.Cursors.Hand
        resources.ApplyResources(Me.imageInputBtn, "imageInputBtn")
        Me.imageInputBtn.ForeColor = System.Drawing.Color.Black
        Me.imageInputBtn.Name = "imageInputBtn"
        Me.imageInputBtn.UseVisualStyleBackColor = False
        '
        'openFileDialog1
        '
        Me.openFileDialog1.FileName = "openFileDialog"
        '
        'solveColourBtn
        '
        Me.solveColourBtn.BackColor = System.Drawing.Color.White
        Me.solveColourBtn.Cursor = System.Windows.Forms.Cursors.Hand
        resources.ApplyResources(Me.solveColourBtn, "solveColourBtn")
        Me.solveColourBtn.ForeColor = System.Drawing.Color.Black
        Me.solveColourBtn.Name = "solveColourBtn"
        Me.solveColourBtn.UseVisualStyleBackColor = False
        '
        'mazeColourBtn
        '
        Me.mazeColourBtn.BackColor = System.Drawing.Color.White
        Me.mazeColourBtn.Cursor = System.Windows.Forms.Cursors.Hand
        resources.ApplyResources(Me.mazeColourBtn, "mazeColourBtn")
        Me.mazeColourBtn.ForeColor = System.Drawing.Color.Black
        Me.mazeColourBtn.Name = "mazeColourBtn"
        Me.mazeColourBtn.UseVisualStyleBackColor = False
        '
        'bgColourBtn
        '
        Me.bgColourBtn.BackColor = System.Drawing.Color.White
        Me.bgColourBtn.Cursor = System.Windows.Forms.Cursors.Hand
        resources.ApplyResources(Me.bgColourBtn, "bgColourBtn")
        Me.bgColourBtn.ForeColor = System.Drawing.Color.Black
        Me.bgColourBtn.Name = "bgColourBtn"
        Me.bgColourBtn.UseVisualStyleBackColor = False
        '
        'mazeBox
        '
        Me.mazeBox.BackColor = System.Drawing.Color.White
        resources.ApplyResources(Me.mazeBox, "mazeBox")
        Me.mazeBox.Name = "mazeBox"
        Me.mazeBox.TabStop = False
        '
        'instantAnimationBtn
        '
        resources.ApplyResources(Me.instantAnimationBtn, "instantAnimationBtn")
        Me.instantAnimationBtn.BackColor = System.Drawing.Color.Transparent
        Me.instantAnimationBtn.Checked = True
        Me.instantAnimationBtn.CheckState = System.Windows.Forms.CheckState.Checked
        Me.instantAnimationBtn.ForeColor = System.Drawing.Color.White
        Me.instantAnimationBtn.Name = "instantAnimationBtn"
        Me.instantAnimationBtn.UseVisualStyleBackColor = False
        '
        'deadEndRemoverBtn
        '
        Me.deadEndRemoverBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        resources.ApplyResources(Me.deadEndRemoverBtn, "deadEndRemoverBtn")
        Me.deadEndRemoverBtn.ForeColor = System.Drawing.Color.Black
        Me.deadEndRemoverBtn.Name = "deadEndRemoverBtn"
        Me.deadEndRemoverBtn.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        resources.ApplyResources(Me.PictureBox1, "PictureBox1")
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.TabStop = False
        '
        'genTimeLbl
        '
        resources.ApplyResources(Me.genTimeLbl, "genTimeLbl")
        Me.genTimeLbl.BackColor = System.Drawing.Color.White
        Me.genTimeLbl.Name = "genTimeLbl"
        '
        'solveTimeLbl
        '
        resources.ApplyResources(Me.solveTimeLbl, "solveTimeLbl")
        Me.solveTimeLbl.BackColor = System.Drawing.Color.White
        Me.solveTimeLbl.Name = "solveTimeLbl"
        '
        'drawTimeLbl
        '
        resources.ApplyResources(Me.drawTimeLbl, "drawTimeLbl")
        Me.drawTimeLbl.BackColor = System.Drawing.Color.White
        Me.drawTimeLbl.Name = "drawTimeLbl"
        '
        'deadEndCountLbl
        '
        resources.ApplyResources(Me.deadEndCountLbl, "deadEndCountLbl")
        Me.deadEndCountLbl.BackColor = System.Drawing.Color.White
        Me.deadEndCountLbl.Name = "deadEndCountLbl"
        '
        'totalTimeLbl
        '
        resources.ApplyResources(Me.totalTimeLbl, "totalTimeLbl")
        Me.totalTimeLbl.BackColor = System.Drawing.Color.White
        Me.totalTimeLbl.Name = "totalTimeLbl"
        '
        'statusLbl
        '
        resources.ApplyResources(Me.statusLbl, "statusLbl")
        Me.statusLbl.BackColor = System.Drawing.Color.Transparent
        Me.statusLbl.ForeColor = System.Drawing.Color.White
        Me.statusLbl.Name = "statusLbl"
        '
        'Form1
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = Global.Maze.My.Resources.Resources.form_background_image1
        Me.Controls.Add(Me.statusLbl)
        Me.Controls.Add(Me.totalTimeLbl)
        Me.Controls.Add(Me.deadEndCountLbl)
        Me.Controls.Add(Me.drawTimeLbl)
        Me.Controls.Add(Me.solveTimeLbl)
        Me.Controls.Add(Me.genTimeLbl)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.deadEndRemoverBtn)
        Me.Controls.Add(Me.instantAnimationBtn)
        Me.Controls.Add(Me.mazeBox)
        Me.Controls.Add(Me.bgColourBtn)
        Me.Controls.Add(Me.mazeColourBtn)
        Me.Controls.Add(Me.solveColourBtn)
        Me.Controls.Add(Me.imageInputBtn)
        Me.Controls.Add(Me.solveCombo)
        Me.Controls.Add(Me.generationCombo)
        Me.Controls.Add(Me.mazeEntryCombo)
        Me.Controls.Add(Me.downloadBtn)
        Me.Controls.Add(Me.solveBtn)
        Me.Controls.Add(Me.generateBtn)
        Me.Controls.Add(Me.deadEndRemoverTxtBox)
        Me.Controls.Add(Me.heightTxtBox)
        Me.Controls.Add(Me.widthTxtBox)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Title)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        CType(Me.mazeBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

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
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents genTimeLbl As Label
    Friend WithEvents solveTimeLbl As Label
    Friend WithEvents drawTimeLbl As Label
    Friend WithEvents deadEndCountLbl As Label
    Friend WithEvents totalTimeLbl As Label
    Friend WithEvents statusLbl As Label
End Class
