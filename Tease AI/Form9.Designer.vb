<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form9
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form9))
		Me.CLBAIBox = New System.Windows.Forms.CheckedListBox()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.LBLFileName = New System.Windows.Forms.Label()
		Me.LBLFT = New System.Windows.Forms.Label()
		Me.LBLFileType = New System.Windows.Forms.Label()
		Me.BTNOpenAIBox = New System.Windows.Forms.Button()
		Me.BTNSaveFile = New System.Windows.Forms.Button()
		Me.BTNSkipFile = New System.Windows.Forms.Button()
		Me.BTNAddFromFile = New System.Windows.Forms.Button()
		Me.BTNAddFromFolder = New System.Windows.Forms.Button()
		Me.GroupBox1 = New System.Windows.Forms.GroupBox()
		Me.Label8 = New System.Windows.Forms.Label()
		Me.BTNOpenAIBoxText = New System.Windows.Forms.Button()
		Me.Label7 = New System.Windows.Forms.Label()
		Me.GroupBox2 = New System.Windows.Forms.GroupBox()
		Me.CBOpenText = New System.Windows.Forms.CheckBox()
		Me.CBSubDir = New System.Windows.Forms.CheckBox()
		Me.Button1 = New System.Windows.Forms.Button()
		Me.Label6 = New System.Windows.Forms.Label()
		Me.Label5 = New System.Windows.Forms.Label()
		Me.Button2 = New System.Windows.Forms.Button()
		Me.BTNOpenBox = New System.Windows.Forms.Button()
		Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
		Me.RTBAIBox = New System.Windows.Forms.RichTextBox()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.LBLPersonality = New System.Windows.Forms.Label()
		Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
		Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
		Me.Button3 = New System.Windows.Forms.Button()
		Me.Button4 = New System.Windows.Forms.Button()
		Me.GroupBox1.SuspendLayout()
		Me.GroupBox2.SuspendLayout()
		Me.SuspendLayout()
		'
		'CLBAIBox
		'
		Me.CLBAIBox.CheckOnClick = True
		Me.CLBAIBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.CLBAIBox.FormattingEnabled = True
		Me.CLBAIBox.HorizontalScrollbar = True
		Me.CLBAIBox.Location = New System.Drawing.Point(265, 52)
		Me.CLBAIBox.Name = "CLBAIBox"
		Me.CLBAIBox.Size = New System.Drawing.Size(786, 580)
		Me.CLBAIBox.TabIndex = 1
		Me.CLBAIBox.Visible = False
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label1.Location = New System.Drawing.Point(262, 20)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(75, 17)
		Me.Label1.TabIndex = 2
		Me.Label1.Text = "File Name:"
		'
		'LBLFileName
		'
		Me.LBLFileName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.LBLFileName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.LBLFileName.Location = New System.Drawing.Point(343, 20)
		Me.LBLFileName.Name = "LBLFileName"
		Me.LBLFileName.Size = New System.Drawing.Size(465, 17)
		Me.LBLFileName.TabIndex = 3
		'
		'LBLFT
		'
		Me.LBLFT.AutoSize = True
		Me.LBLFT.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.LBLFT.Location = New System.Drawing.Point(814, 21)
		Me.LBLFT.Name = "LBLFT"
		Me.LBLFT.Size = New System.Drawing.Size(70, 17)
		Me.LBLFT.TabIndex = 4
		Me.LBLFT.Text = "File Type:"
		'
		'LBLFileType
		'
		Me.LBLFileType.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.LBLFileType.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.LBLFileType.Location = New System.Drawing.Point(890, 20)
		Me.LBLFileType.Name = "LBLFileType"
		Me.LBLFileType.Size = New System.Drawing.Size(161, 17)
		Me.LBLFileType.TabIndex = 5
		'
		'BTNOpenAIBox
		'
		Me.BTNOpenAIBox.AllowDrop = True
		Me.BTNOpenAIBox.FlatAppearance.BorderSize = 0
		Me.BTNOpenAIBox.Image = CType(resources.GetObject("BTNOpenAIBox.Image"), System.Drawing.Image)
		Me.BTNOpenAIBox.Location = New System.Drawing.Point(21, 19)
		Me.BTNOpenAIBox.Name = "BTNOpenAIBox"
		Me.BTNOpenAIBox.Size = New System.Drawing.Size(75, 73)
		Me.BTNOpenAIBox.TabIndex = 6
		Me.BTNOpenAIBox.UseVisualStyleBackColor = True
		'
		'BTNSaveFile
		'
		Me.BTNSaveFile.Enabled = False
		Me.BTNSaveFile.Location = New System.Drawing.Point(147, 125)
		Me.BTNSaveFile.Name = "BTNSaveFile"
		Me.BTNSaveFile.Size = New System.Drawing.Size(79, 38)
		Me.BTNSaveFile.TabIndex = 8
		Me.BTNSaveFile.Text = "Save this File"
		Me.BTNSaveFile.UseVisualStyleBackColor = True
		'
		'BTNSkipFile
		'
		Me.BTNSkipFile.Enabled = False
		Me.BTNSkipFile.Location = New System.Drawing.Point(19, 125)
		Me.BTNSkipFile.Name = "BTNSkipFile"
		Me.BTNSkipFile.Size = New System.Drawing.Size(79, 38)
		Me.BTNSkipFile.TabIndex = 9
		Me.BTNSkipFile.Text = "Skip this File"
		Me.BTNSkipFile.UseVisualStyleBackColor = True
		'
		'BTNAddFromFile
		'
		Me.BTNAddFromFile.AllowDrop = True
		Me.BTNAddFromFile.FlatAppearance.BorderSize = 0
		Me.BTNAddFromFile.Image = CType(resources.GetObject("BTNAddFromFile.Image"), System.Drawing.Image)
		Me.BTNAddFromFile.Location = New System.Drawing.Point(21, 19)
		Me.BTNAddFromFile.Name = "BTNAddFromFile"
		Me.BTNAddFromFile.Size = New System.Drawing.Size(75, 73)
		Me.BTNAddFromFile.TabIndex = 10
		Me.BTNAddFromFile.UseVisualStyleBackColor = True
		'
		'BTNAddFromFolder
		'
		Me.BTNAddFromFolder.AllowDrop = True
		Me.BTNAddFromFolder.FlatAppearance.BorderSize = 0
		Me.BTNAddFromFolder.Image = CType(resources.GetObject("BTNAddFromFolder.Image"), System.Drawing.Image)
		Me.BTNAddFromFolder.Location = New System.Drawing.Point(149, 19)
		Me.BTNAddFromFolder.Name = "BTNAddFromFolder"
		Me.BTNAddFromFolder.Size = New System.Drawing.Size(75, 73)
		Me.BTNAddFromFolder.TabIndex = 11
		Me.BTNAddFromFolder.UseVisualStyleBackColor = True
		'
		'GroupBox1
		'
		Me.GroupBox1.Controls.Add(Me.Label8)
		Me.GroupBox1.Controls.Add(Me.BTNOpenAIBoxText)
		Me.GroupBox1.Controls.Add(Me.Label7)
		Me.GroupBox1.Controls.Add(Me.BTNOpenAIBox)
		Me.GroupBox1.Controls.Add(Me.BTNSaveFile)
		Me.GroupBox1.Controls.Add(Me.BTNSkipFile)
		Me.GroupBox1.Location = New System.Drawing.Point(10, 46)
		Me.GroupBox1.Name = "GroupBox1"
		Me.GroupBox1.Size = New System.Drawing.Size(246, 189)
		Me.GroupBox1.TabIndex = 12
		Me.GroupBox1.TabStop = False
		Me.GroupBox1.Text = "Open AI Box"
		'
		'Label8
		'
		Me.Label8.Location = New System.Drawing.Point(130, 95)
		Me.Label8.Name = "Label8"
		Me.Label8.Size = New System.Drawing.Size(111, 15)
		Me.Label8.TabIndex = 15
		Me.Label8.Text = "Open From Clipboard"
		Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'BTNOpenAIBoxText
		'
		Me.BTNOpenAIBoxText.FlatAppearance.BorderSize = 0
		Me.BTNOpenAIBoxText.Image = CType(resources.GetObject("BTNOpenAIBoxText.Image"), System.Drawing.Image)
		Me.BTNOpenAIBoxText.Location = New System.Drawing.Point(149, 19)
		Me.BTNOpenAIBoxText.Name = "BTNOpenAIBoxText"
		Me.BTNOpenAIBoxText.Size = New System.Drawing.Size(75, 73)
		Me.BTNOpenAIBoxText.TabIndex = 14
		Me.BTNOpenAIBoxText.UseVisualStyleBackColor = True
		'
		'Label7
		'
		Me.Label7.Location = New System.Drawing.Point(16, 95)
		Me.Label7.Name = "Label7"
		Me.Label7.Size = New System.Drawing.Size(90, 15)
		Me.Label7.TabIndex = 13
		Me.Label7.Text = "Open From File"
		Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'GroupBox2
		'
		Me.GroupBox2.Controls.Add(Me.CBOpenText)
		Me.GroupBox2.Controls.Add(Me.CBSubDir)
		Me.GroupBox2.Controls.Add(Me.Button1)
		Me.GroupBox2.Controls.Add(Me.Label6)
		Me.GroupBox2.Controls.Add(Me.Label5)
		Me.GroupBox2.Controls.Add(Me.BTNAddFromFile)
		Me.GroupBox2.Controls.Add(Me.BTNAddFromFolder)
		Me.GroupBox2.Location = New System.Drawing.Point(10, 241)
		Me.GroupBox2.Name = "GroupBox2"
		Me.GroupBox2.Size = New System.Drawing.Size(246, 237)
		Me.GroupBox2.TabIndex = 13
		Me.GroupBox2.TabStop = False
		Me.GroupBox2.Text = "Create AI Box"
		'
		'CBOpenText
		'
		Me.CBOpenText.Checked = True
		Me.CBOpenText.CheckState = System.Windows.Forms.CheckState.Checked
		Me.CBOpenText.Location = New System.Drawing.Point(24, 202)
		Me.CBOpenText.Name = "CBOpenText"
		Me.CBOpenText.Size = New System.Drawing.Size(205, 29)
		Me.CBOpenText.TabIndex = 19
		Me.CBOpenText.Text = "Open AI Box as .txt file when finished"
		Me.CBOpenText.UseVisualStyleBackColor = True
		'
		'CBSubDir
		'
		Me.CBSubDir.Location = New System.Drawing.Point(129, 113)
		Me.CBSubDir.Name = "CBSubDir"
		Me.CBSubDir.Size = New System.Drawing.Size(117, 29)
		Me.CBSubDir.TabIndex = 18
		Me.CBSubDir.Text = "Include Subfolders"
		Me.CBSubDir.UseVisualStyleBackColor = True
		'
		'Button1
		'
		Me.Button1.Location = New System.Drawing.Point(21, 151)
		Me.Button1.Name = "Button1"
		Me.Button1.Size = New System.Drawing.Size(205, 38)
		Me.Button1.TabIndex = 16
		Me.Button1.Text = "Create AI Box"
		Me.Button1.UseVisualStyleBackColor = True
		'
		'Label6
		'
		Me.Label6.Location = New System.Drawing.Point(145, 95)
		Me.Label6.Name = "Label6"
		Me.Label6.Size = New System.Drawing.Size(85, 15)
		Me.Label6.TabIndex = 13
		Me.Label6.Text = "Add From Folder"
		Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'Label5
		'
		Me.Label5.Location = New System.Drawing.Point(23, 95)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(75, 15)
		Me.Label5.TabIndex = 12
		Me.Label5.Text = "Add From File"
		Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'Button2
		'
		Me.Button2.Location = New System.Drawing.Point(31, 532)
		Me.Button2.Name = "Button2"
		Me.Button2.Size = New System.Drawing.Size(203, 24)
		Me.Button2.TabIndex = 17
		Me.Button2.Text = "Clear List"
		Me.Button2.UseVisualStyleBackColor = True
		'
		'BTNOpenBox
		'
		Me.BTNOpenBox.Image = CType(resources.GetObject("BTNOpenBox.Image"), System.Drawing.Image)
		Me.BTNOpenBox.Location = New System.Drawing.Point(84, 34)
		Me.BTNOpenBox.Name = "BTNOpenBox"
		Me.BTNOpenBox.Size = New System.Drawing.Size(75, 73)
		Me.BTNOpenBox.TabIndex = 6
		Me.BTNOpenBox.UseVisualStyleBackColor = True
		'
		'OpenFileDialog1
		'
		Me.OpenFileDialog1.FileName = "OpenFileDialog1"
		'
		'RTBAIBox
		'
		Me.RTBAIBox.Location = New System.Drawing.Point(265, 52)
		Me.RTBAIBox.Name = "RTBAIBox"
		Me.RTBAIBox.Size = New System.Drawing.Size(786, 589)
		Me.RTBAIBox.TabIndex = 14
		Me.RTBAIBox.Text = ""
		'
		'Label4
		'
		Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label4.Location = New System.Drawing.Point(12, 20)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(99, 17)
		Me.Label4.TabIndex = 15
		Me.Label4.Text = "Current Personality:"
		'
		'LBLPersonality
		'
		Me.LBLPersonality.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.LBLPersonality.Location = New System.Drawing.Point(117, 9)
		Me.LBLPersonality.Name = "LBLPersonality"
		Me.LBLPersonality.Size = New System.Drawing.Size(144, 34)
		Me.LBLPersonality.TabIndex = 16
		Me.LBLPersonality.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'Button3
		'
		Me.Button3.Location = New System.Drawing.Point(31, 496)
		Me.Button3.Name = "Button3"
		Me.Button3.Size = New System.Drawing.Size(75, 24)
		Me.Button3.TabIndex = 18
		Me.Button3.Text = "Select All"
		Me.Button3.UseVisualStyleBackColor = True
		'
		'Button4
		'
		Me.Button4.Location = New System.Drawing.Point(159, 496)
		Me.Button4.Name = "Button4"
		Me.Button4.Size = New System.Drawing.Size(75, 24)
		Me.Button4.TabIndex = 19
		Me.Button4.Text = "Select None"
		Me.Button4.UseVisualStyleBackColor = True
		'
		'Form9
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(1080, 658)
		Me.Controls.Add(Me.Button4)
		Me.Controls.Add(Me.Button3)
		Me.Controls.Add(Me.LBLPersonality)
		Me.Controls.Add(Me.Button2)
		Me.Controls.Add(Me.Label4)
		Me.Controls.Add(Me.GroupBox2)
		Me.Controls.Add(Me.GroupBox1)
		Me.Controls.Add(Me.LBLFileType)
		Me.Controls.Add(Me.LBLFT)
		Me.Controls.Add(Me.LBLFileName)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.RTBAIBox)
		Me.Controls.Add(Me.CLBAIBox)
		Me.Name = "Form9"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "AI Box Tools"
		Me.GroupBox1.ResumeLayout(False)
		Me.GroupBox2.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents CLBAIBox As System.Windows.Forms.CheckedListBox
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents LBLFileName As System.Windows.Forms.Label
	Friend WithEvents LBLFT As System.Windows.Forms.Label
	Friend WithEvents LBLFileType As System.Windows.Forms.Label
	Friend WithEvents BTNOpenAIBox As System.Windows.Forms.Button
	Friend WithEvents BTNSaveFile As System.Windows.Forms.Button
	Friend WithEvents BTNSkipFile As System.Windows.Forms.Button
	Friend WithEvents BTNAddFromFile As System.Windows.Forms.Button
	Friend WithEvents BTNAddFromFolder As System.Windows.Forms.Button
	Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
	Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
	Friend WithEvents Label6 As System.Windows.Forms.Label
	Friend WithEvents Label5 As System.Windows.Forms.Label
	Friend WithEvents BTNOpenBox As System.Windows.Forms.Button
	Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
	Friend WithEvents RTBAIBox As System.Windows.Forms.RichTextBox
	Friend WithEvents Button1 As System.Windows.Forms.Button
	Friend WithEvents Label4 As System.Windows.Forms.Label
	Friend WithEvents LBLPersonality As System.Windows.Forms.Label
	Friend WithEvents Button2 As System.Windows.Forms.Button
	Friend WithEvents Label8 As System.Windows.Forms.Label
	Friend WithEvents BTNOpenAIBoxText As System.Windows.Forms.Button
	Friend WithEvents Label7 As System.Windows.Forms.Label
	Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
	Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
	Friend WithEvents CBSubDir As System.Windows.Forms.CheckBox
	Friend WithEvents Button3 As System.Windows.Forms.Button
	Friend WithEvents Button4 As System.Windows.Forms.Button
	Friend WithEvents CBOpenText As System.Windows.Forms.CheckBox
End Class
