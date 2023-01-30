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
        Me.viewStatsBtn = New System.Windows.Forms.Button()
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
        CType(Me.mazeBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Title
        '
        resources.ApplyResources(Me.Title, "Title")
        Me.Title.BackColor = System.Drawing.Color.Transparent
        Me.Title.ForeColor = System.Drawing.Color.White
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
        Me.widthTxtBox.ForeColor = System.Drawing.Color.DimGray
        resources.ApplyResources(Me.widthTxtBox, "widthTxtBox")
        Me.widthTxtBox.Name = "widthTxtBox"
        '
        'heightTxtBox
        '
        Me.heightTxtBox.ForeColor = System.Drawing.Color.DimGray
        resources.ApplyResources(Me.heightTxtBox, "heightTxtBox")
        Me.heightTxtBox.Name = "heightTxtBox"
        '
        'deadEndRemoverTxtBox
        '
        Me.deadEndRemoverTxtBox.ForeColor = System.Drawing.Color.DimGray
        resources.ApplyResources(Me.deadEndRemoverTxtBox, "deadEndRemoverTxtBox")
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
        'viewStatsBtn
        '
        resources.ApplyResources(Me.viewStatsBtn, "viewStatsBtn")
        Me.viewStatsBtn.Name = "viewStatsBtn"
        Me.viewStatsBtn.UseVisualStyleBackColor = True
        '
        'mazeEntryCombo
        '
        Me.mazeEntryCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.mazeEntryCombo.ForeColor = System.Drawing.Color.DimGray
        Me.mazeEntryCombo.FormattingEnabled = True
        resources.ApplyResources(Me.mazeEntryCombo, "mazeEntryCombo")
        Me.mazeEntryCombo.Name = "mazeEntryCombo"
        '
        'generationCombo
        '
        Me.generationCombo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.generationCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.generationCombo.ForeColor = System.Drawing.Color.DimGray
        Me.generationCombo.FormattingEnabled = True
        resources.ApplyResources(Me.generationCombo, "generationCombo")
        Me.generationCombo.Name = "generationCombo"
        '
        'solveCombo
        '
        Me.solveCombo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.solveCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.solveCombo.ForeColor = System.Drawing.Color.DimGray
        Me.solveCombo.FormattingEnabled = True
        resources.ApplyResources(Me.solveCombo, "solveCombo")
        Me.solveCombo.Name = "solveCombo"
        '
        'imageInputBtn
        '
        Me.imageInputBtn.BackColor = System.Drawing.SystemColors.Window
        Me.imageInputBtn.Cursor = System.Windows.Forms.Cursors.Hand
        resources.ApplyResources(Me.imageInputBtn, "imageInputBtn")
        Me.imageInputBtn.ForeColor = System.Drawing.Color.DimGray
        Me.imageInputBtn.Name = "imageInputBtn"
        Me.imageInputBtn.UseVisualStyleBackColor = False
        '
        'openFileDialog1
        '
        Me.openFileDialog1.FileName = "openFileDialog"
        '
        'solveColourBtn
        '
        Me.solveColourBtn.BackColor = System.Drawing.SystemColors.Window
        Me.solveColourBtn.Cursor = System.Windows.Forms.Cursors.Hand
        resources.ApplyResources(Me.solveColourBtn, "solveColourBtn")
        Me.solveColourBtn.ForeColor = System.Drawing.Color.DimGray
        Me.solveColourBtn.Name = "solveColourBtn"
        Me.solveColourBtn.UseVisualStyleBackColor = False
        '
        'mazeColourBtn
        '
        Me.mazeColourBtn.BackColor = System.Drawing.SystemColors.Window
        Me.mazeColourBtn.Cursor = System.Windows.Forms.Cursors.Hand
        resources.ApplyResources(Me.mazeColourBtn, "mazeColourBtn")
        Me.mazeColourBtn.ForeColor = System.Drawing.Color.DimGray
        Me.mazeColourBtn.Name = "mazeColourBtn"
        Me.mazeColourBtn.UseVisualStyleBackColor = False
        '
        'bgColourBtn
        '
        Me.bgColourBtn.BackColor = System.Drawing.SystemColors.Window
        Me.bgColourBtn.Cursor = System.Windows.Forms.Cursors.Hand
        resources.ApplyResources(Me.bgColourBtn, "bgColourBtn")
        Me.bgColourBtn.ForeColor = System.Drawing.Color.DimGray
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
        'Form1
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Maze.My.Resources.Resources.backgroubd
        Me.Controls.Add(Me.mazeBox)
        Me.Controls.Add(Me.bgColourBtn)
        Me.Controls.Add(Me.mazeColourBtn)
        Me.Controls.Add(Me.solveColourBtn)
        Me.Controls.Add(Me.imageInputBtn)
        Me.Controls.Add(Me.solveCombo)
        Me.Controls.Add(Me.generationCombo)
        Me.Controls.Add(Me.mazeEntryCombo)
        Me.Controls.Add(Me.viewStatsBtn)
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
    Friend WithEvents viewStatsBtn As Button
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
End Class
