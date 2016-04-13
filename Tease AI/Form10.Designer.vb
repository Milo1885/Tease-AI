<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form10
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
		Me.LBCommands = New System.Windows.Forms.ListBox()
		Me.comboCommandType = New System.Windows.Forms.ComboBox()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.LBLSyntax = New System.Windows.Forms.Label()
		Me.LBLExample = New System.Windows.Forms.Label()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.Label5 = New System.Windows.Forms.Label()
		Me.Panel1 = New System.Windows.Forms.Panel()
		Me.WBDescription = New System.Windows.Forms.WebBrowser()
		Me.RTBFormat = New System.Windows.Forms.RichTextBox()
		Me.Button1 = New System.Windows.Forms.Button()
		Me.Button2 = New System.Windows.Forms.Button()
		Me.Button3 = New System.Windows.Forms.Button()
		Me.Panel1.SuspendLayout()
		Me.SuspendLayout()
		'
		'LBCommands
		'
		Me.LBCommands.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.LBCommands.FormattingEnabled = True
		Me.LBCommands.ItemHeight = 16
		Me.LBCommands.Location = New System.Drawing.Point(12, 86)
		Me.LBCommands.Name = "LBCommands"
		Me.LBCommands.Size = New System.Drawing.Size(280, 564)
		Me.LBCommands.Sorted = True
		Me.LBCommands.TabIndex = 0
		'
		'comboCommandType
		'
		Me.comboCommandType.FormattingEnabled = True
		Me.comboCommandType.Items.AddRange(New Object() {"Commands", "Command Filters", "System Keywords"})
		Me.comboCommandType.Location = New System.Drawing.Point(12, 43)
		Me.comboCommandType.Name = "comboCommandType"
		Me.comboCommandType.Size = New System.Drawing.Size(280, 21)
		Me.comboCommandType.TabIndex = 0
		Me.comboCommandType.Text = "Commands"
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(13, 13)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(84, 13)
		Me.Label1.TabIndex = 3
		Me.Label1.Text = "Command Type:"
		'
		'LBLSyntax
		'
		Me.LBLSyntax.BackColor = System.Drawing.Color.Gainsboro
		Me.LBLSyntax.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.LBLSyntax.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.LBLSyntax.Location = New System.Drawing.Point(307, 43)
		Me.LBLSyntax.Name = "LBLSyntax"
		Me.LBLSyntax.Size = New System.Drawing.Size(761, 23)
		Me.LBLSyntax.TabIndex = 4
		Me.LBLSyntax.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'LBLExample
		'
		Me.LBLExample.BackColor = System.Drawing.Color.Gainsboro
		Me.LBLExample.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.LBLExample.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.LBLExample.Location = New System.Drawing.Point(307, 121)
		Me.LBLExample.Name = "LBLExample"
		Me.LBLExample.Size = New System.Drawing.Size(761, 23)
		Me.LBLExample.TabIndex = 5
		Me.LBLExample.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'Label4
		'
		Me.Label4.AutoSize = True
		Me.Label4.Location = New System.Drawing.Point(304, 13)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(42, 13)
		Me.Label4.TabIndex = 6
		Me.Label4.Text = "Syntax:"
		'
		'Label5
		'
		Me.Label5.AutoSize = True
		Me.Label5.Location = New System.Drawing.Point(304, 86)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(50, 13)
		Me.Label5.TabIndex = 7
		Me.Label5.Text = "Example:"
		'
		'Panel1
		'
		Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.Panel1.Controls.Add(Me.WBDescription)
		Me.Panel1.Location = New System.Drawing.Point(307, 169)
		Me.Panel1.Name = "Panel1"
		Me.Panel1.Size = New System.Drawing.Size(761, 480)
		Me.Panel1.TabIndex = 2
		'
		'WBDescription
		'
		Me.WBDescription.Location = New System.Drawing.Point(3, 3)
		Me.WBDescription.MinimumSize = New System.Drawing.Size(20, 20)
		Me.WBDescription.Name = "WBDescription"
		Me.WBDescription.Size = New System.Drawing.Size(751, 470)
		Me.WBDescription.TabIndex = 1
		'
		'RTBFormat
		'
		Me.RTBFormat.Location = New System.Drawing.Point(32, 272)
		Me.RTBFormat.Name = "RTBFormat"
		Me.RTBFormat.Size = New System.Drawing.Size(245, 235)
		Me.RTBFormat.TabIndex = 8
		Me.RTBFormat.Text = ""
		'
		'Button1
		'
		Me.Button1.Location = New System.Drawing.Point(38, 546)
		Me.Button1.Name = "Button1"
		Me.Button1.Size = New System.Drawing.Size(75, 23)
		Me.Button1.TabIndex = 9
		Me.Button1.Text = "Clipboard"
		Me.Button1.UseVisualStyleBackColor = True
		'
		'Button2
		'
		Me.Button2.Location = New System.Drawing.Point(107, 598)
		Me.Button2.Name = "Button2"
		Me.Button2.Size = New System.Drawing.Size(75, 23)
		Me.Button2.TabIndex = 10
		Me.Button2.Text = "Test"
		Me.Button2.UseVisualStyleBackColor = True
		'
		'Button3
		'
		Me.Button3.Location = New System.Drawing.Point(176, 546)
		Me.Button3.Name = "Button3"
		Me.Button3.Size = New System.Drawing.Size(75, 23)
		Me.Button3.TabIndex = 11
		Me.Button3.Text = "Clear"
		Me.Button3.UseVisualStyleBackColor = True
		'
		'Form10
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(1080, 658)
		Me.Controls.Add(Me.LBCommands)
		Me.Controls.Add(Me.Button3)
		Me.Controls.Add(Me.Button2)
		Me.Controls.Add(Me.Button1)
		Me.Controls.Add(Me.RTBFormat)
		Me.Controls.Add(Me.Label5)
		Me.Controls.Add(Me.Label4)
		Me.Controls.Add(Me.LBLExample)
		Me.Controls.Add(Me.LBLSyntax)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.comboCommandType)
		Me.Controls.Add(Me.Panel1)
		Me.Name = "Form10"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Tease AI Language Guide"
		Me.Panel1.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents LBCommands As System.Windows.Forms.ListBox
	Friend WithEvents comboCommandType As System.Windows.Forms.ComboBox
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents LBLSyntax As System.Windows.Forms.Label
	Friend WithEvents LBLExample As System.Windows.Forms.Label
	Friend WithEvents Label4 As System.Windows.Forms.Label
	Friend WithEvents Label5 As System.Windows.Forms.Label
	Friend WithEvents Panel1 As System.Windows.Forms.Panel
	Friend WithEvents WBDescription As System.Windows.Forms.WebBrowser
	Friend WithEvents RTBFormat As System.Windows.Forms.RichTextBox
	Friend WithEvents Button1 As System.Windows.Forms.Button
	Friend WithEvents Button2 As System.Windows.Forms.Button
	Friend WithEvents Button3 As System.Windows.Forms.Button
End Class
