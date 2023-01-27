<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.imageInputBtn = New System.Windows.Forms.Button()
        Me.bgColourBtn = New System.Windows.Forms.Button()
        Me.mazeColourBtn = New System.Windows.Forms.Button()
        Me.solveColourBtn = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.widthTxtBox = New System.Windows.Forms.TextBox()
        Me.heightTxtBox = New System.Windows.Forms.TextBox()
        Me.deadEndRemoverTxtBox = New System.Windows.Forms.TextBox()
        Me.generationCombo = New System.Windows.Forms.ComboBox()
        Me.solveCombo = New System.Windows.Forms.ComboBox()
        Me.mazeEntryCombo = New System.Windows.Forms.ComboBox()
        Me.mazeBox = New System.Windows.Forms.PictureBox()
        Me.generateBtn = New System.Windows.Forms.Button()
        Me.solveBtn = New System.Windows.Forms.Button()
        Me.downloadBtn = New System.Windows.Forms.Button()
        Me.viewStatsBtn = New System.Windows.Forms.Button()
        Me.colorDialog = New System.Windows.Forms.ColorDialog()
        Me.openFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        CType(Me.mazeBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(29, 202)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 28)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Height"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(29, 242)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(203, 28)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Generation Algorithm"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(29, 322)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(181, 28)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Dead-end Remover"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(29, 282)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(154, 28)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Solve Algorithm"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(29, 482)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(124, 28)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Solve Colour"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(29, 442)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(123, 28)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Maze Colour"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(29, 402)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(181, 28)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "Background Colour"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(29, 362)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(109, 28)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "Maze Entry"
        '
        'Label9
        '
        Me.Label9.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(250, 9)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(487, 81)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Maze Generation"
        '
        'imageInputBtn
        '
        Me.imageInputBtn.BackColor = System.Drawing.SystemColors.Window
        Me.imageInputBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.imageInputBtn.ForeColor = System.Drawing.Color.DimGray
        Me.imageInputBtn.Location = New System.Drawing.Point(256, 122)
        Me.imageInputBtn.Name = "imageInputBtn"
        Me.imageInputBtn.Size = New System.Drawing.Size(183, 29)
        Me.imageInputBtn.TabIndex = 9
        Me.imageInputBtn.Text = "Upload File"
        Me.imageInputBtn.UseVisualStyleBackColor = False
        '
        'bgColourBtn
        '
        Me.bgColourBtn.BackColor = System.Drawing.SystemColors.Window
        Me.bgColourBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bgColourBtn.ForeColor = System.Drawing.Color.DimGray
        Me.bgColourBtn.Location = New System.Drawing.Point(256, 482)
        Me.bgColourBtn.Name = "bgColourBtn"
        Me.bgColourBtn.Size = New System.Drawing.Size(183, 29)
        Me.bgColourBtn.TabIndex = 10
        Me.bgColourBtn.Text = "Select Colour"
        Me.bgColourBtn.UseVisualStyleBackColor = False
        '
        'mazeColourBtn
        '
        Me.mazeColourBtn.BackColor = System.Drawing.SystemColors.Window
        Me.mazeColourBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.mazeColourBtn.ForeColor = System.Drawing.Color.DimGray
        Me.mazeColourBtn.Location = New System.Drawing.Point(256, 442)
        Me.mazeColourBtn.Name = "mazeColourBtn"
        Me.mazeColourBtn.Size = New System.Drawing.Size(183, 29)
        Me.mazeColourBtn.TabIndex = 11
        Me.mazeColourBtn.Text = "Select Colour"
        Me.mazeColourBtn.UseVisualStyleBackColor = False
        '
        'solveColourBtn
        '
        Me.solveColourBtn.BackColor = System.Drawing.SystemColors.Window
        Me.solveColourBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.solveColourBtn.ForeColor = System.Drawing.Color.DimGray
        Me.solveColourBtn.Location = New System.Drawing.Point(256, 402)
        Me.solveColourBtn.Name = "solveColourBtn"
        Me.solveColourBtn.Size = New System.Drawing.Size(183, 29)
        Me.solveColourBtn.TabIndex = 12
        Me.solveColourBtn.Text = "Select Colour"
        Me.solveColourBtn.UseVisualStyleBackColor = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(29, 162)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(66, 28)
        Me.Label10.TabIndex = 13
        Me.Label10.Text = "Width"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(29, 122)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(117, 28)
        Me.Label11.TabIndex = 14
        Me.Label11.Text = "Image Input"
        '
        'widthTxtBox
        '
        Me.widthTxtBox.ForeColor = System.Drawing.Color.DimGray
        Me.widthTxtBox.Location = New System.Drawing.Point(256, 162)
        Me.widthTxtBox.MaxLength = 3
        Me.widthTxtBox.Name = "widthTxtBox"
        Me.widthTxtBox.Size = New System.Drawing.Size(183, 27)
        Me.widthTxtBox.TabIndex = 15
        Me.widthTxtBox.Text = "50"
        Me.widthTxtBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'heightTxtBox
        '
        Me.heightTxtBox.ForeColor = System.Drawing.Color.DimGray
        Me.heightTxtBox.Location = New System.Drawing.Point(256, 202)
        Me.heightTxtBox.MaxLength = 3
        Me.heightTxtBox.Name = "heightTxtBox"
        Me.heightTxtBox.Size = New System.Drawing.Size(183, 27)
        Me.heightTxtBox.TabIndex = 16
        Me.heightTxtBox.Text = "27"
        Me.heightTxtBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'deadEndRemoverTxtBox
        '
        Me.deadEndRemoverTxtBox.ForeColor = System.Drawing.Color.DimGray
        Me.deadEndRemoverTxtBox.Location = New System.Drawing.Point(256, 322)
        Me.deadEndRemoverTxtBox.MaxLength = 4
        Me.deadEndRemoverTxtBox.Name = "deadEndRemoverTxtBox"
        Me.deadEndRemoverTxtBox.Size = New System.Drawing.Size(183, 27)
        Me.deadEndRemoverTxtBox.TabIndex = 17
        Me.deadEndRemoverTxtBox.Text = "50"
        Me.deadEndRemoverTxtBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'generationCombo
        '
        Me.generationCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.generationCombo.FormattingEnabled = True
        Me.generationCombo.Location = New System.Drawing.Point(256, 242)
        Me.generationCombo.Name = "generationCombo"
        Me.generationCombo.Size = New System.Drawing.Size(183, 28)
        Me.generationCombo.TabIndex = 18
        '
        'solveCombo
        '
        Me.solveCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.solveCombo.FormattingEnabled = True
        Me.solveCombo.Location = New System.Drawing.Point(256, 282)
        Me.solveCombo.Name = "solveCombo"
        Me.solveCombo.Size = New System.Drawing.Size(183, 28)
        Me.solveCombo.TabIndex = 19
        '
        'mazeEntryCombo
        '
        Me.mazeEntryCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.mazeEntryCombo.FormattingEnabled = True
        Me.mazeEntryCombo.Location = New System.Drawing.Point(256, 362)
        Me.mazeEntryCombo.Name = "mazeEntryCombo"
        Me.mazeEntryCombo.Size = New System.Drawing.Size(183, 28)
        Me.mazeEntryCombo.TabIndex = 20
        '
        'mazeBox
        '
        Me.mazeBox.BackColor = System.Drawing.Color.White
        Me.mazeBox.Location = New System.Drawing.Point(466, 121)
        Me.mazeBox.Name = "mazeBox"
        Me.mazeBox.Size = New System.Drawing.Size(500, 270)
        Me.mazeBox.TabIndex = 21
        Me.mazeBox.TabStop = False
        '
        'generateBtn
        '
        Me.generateBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.generateBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.generateBtn.ForeColor = System.Drawing.Color.Black
        Me.generateBtn.Location = New System.Drawing.Point(466, 397)
        Me.generateBtn.Name = "generateBtn"
        Me.generateBtn.Size = New System.Drawing.Size(240, 29)
        Me.generateBtn.TabIndex = 22
        Me.generateBtn.Text = "Generate"
        Me.generateBtn.UseVisualStyleBackColor = False
        '
        'solveBtn
        '
        Me.solveBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.solveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.solveBtn.ForeColor = System.Drawing.Color.Black
        Me.solveBtn.Location = New System.Drawing.Point(726, 397)
        Me.solveBtn.Name = "solveBtn"
        Me.solveBtn.Size = New System.Drawing.Size(240, 29)
        Me.solveBtn.TabIndex = 23
        Me.solveBtn.Text = "Solve"
        Me.solveBtn.UseVisualStyleBackColor = False
        '
        'downloadBtn
        '
        Me.downloadBtn.BackColor = System.Drawing.SystemColors.Window
        Me.downloadBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.downloadBtn.ForeColor = System.Drawing.Color.DeepSkyBlue
        Me.downloadBtn.Location = New System.Drawing.Point(466, 437)
        Me.downloadBtn.Name = "downloadBtn"
        Me.downloadBtn.Size = New System.Drawing.Size(500, 29)
        Me.downloadBtn.TabIndex = 24
        Me.downloadBtn.Text = "Download"
        Me.downloadBtn.UseVisualStyleBackColor = False
        '
        'viewStatsBtn
        '
        Me.viewStatsBtn.BackColor = System.Drawing.SystemColors.Window
        Me.viewStatsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.viewStatsBtn.ForeColor = System.Drawing.Color.Black
        Me.viewStatsBtn.Location = New System.Drawing.Point(466, 477)
        Me.viewStatsBtn.Name = "viewStatsBtn"
        Me.viewStatsBtn.Size = New System.Drawing.Size(500, 29)
        Me.viewStatsBtn.TabIndex = 25
        Me.viewStatsBtn.Text = "View Maze Statistics"
        Me.viewStatsBtn.UseVisualStyleBackColor = False
        '
        'openFileDialog1
        '
        Me.openFileDialog1.FileName = "openFileDialog1"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackgroundImage = Global.Maze.My.Resources.Resources.backgroubd
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(997, 553)
        Me.Controls.Add(Me.viewStatsBtn)
        Me.Controls.Add(Me.downloadBtn)
        Me.Controls.Add(Me.solveBtn)
        Me.Controls.Add(Me.generateBtn)
        Me.Controls.Add(Me.mazeBox)
        Me.Controls.Add(Me.mazeEntryCombo)
        Me.Controls.Add(Me.solveCombo)
        Me.Controls.Add(Me.generationCombo)
        Me.Controls.Add(Me.deadEndRemoverTxtBox)
        Me.Controls.Add(Me.heightTxtBox)
        Me.Controls.Add(Me.widthTxtBox)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.solveColourBtn)
        Me.Controls.Add(Me.mazeColourBtn)
        Me.Controls.Add(Me.bgColourBtn)
        Me.Controls.Add(Me.imageInputBtn)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "Form1"
        CType(Me.mazeBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents imageInputBtn As System.Windows.Forms.Button
    Friend WithEvents bgColourBtn As System.Windows.Forms.Button
    Friend WithEvents mazeColourBtn As System.Windows.Forms.Button
    Friend WithEvents solveColourBtn As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents widthTxtBox As System.Windows.Forms.TextBox
    Friend WithEvents heightTxtBox As System.Windows.Forms.TextBox
    Friend WithEvents deadEndRemoverTxtBox As System.Windows.Forms.TextBox
    Friend WithEvents generationCombo As System.Windows.Forms.ComboBox
    Friend WithEvents solveCombo As System.Windows.Forms.ComboBox
    Friend WithEvents mazeEntryCombo As System.Windows.Forms.ComboBox
    Friend WithEvents mazeBox As System.Windows.Forms.PictureBox
    Friend WithEvents generateBtn As System.Windows.Forms.Button
    Friend WithEvents solveBtn As System.Windows.Forms.Button
    Friend WithEvents downloadBtn As System.Windows.Forms.Button
    Friend WithEvents viewStatsBtn As System.Windows.Forms.Button
    Friend WithEvents colorDialog As System.Windows.Forms.ColorDialog
    Friend WithEvents openFileDialog1 As System.Windows.Forms.OpenFileDialog

End Class
