<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSplash
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSplash))
		Me.PBSplash = New System.Windows.Forms.ProgressBar()
		Me.LBLSplash = New System.Windows.Forms.Label()
		Me.SuspendLayout()
		'
		'PBSplash
		'
		Me.PBSplash.BackColor = System.Drawing.Color.Black
		Me.PBSplash.Location = New System.Drawing.Point(53, 244)
		Me.PBSplash.Maximum = 45
		Me.PBSplash.Name = "PBSplash"
		Me.PBSplash.Size = New System.Drawing.Size(466, 23)
		Me.PBSplash.TabIndex = 0
		'
		'LBLSplash
		'
		Me.LBLSplash.BackColor = System.Drawing.Color.Black
		Me.LBLSplash.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.LBLSplash.ForeColor = System.Drawing.Color.White
		Me.LBLSplash.Location = New System.Drawing.Point(53, 274)
		Me.LBLSplash.Name = "LBLSplash"
		Me.LBLSplash.Size = New System.Drawing.Size(466, 23)
		Me.LBLSplash.TabIndex = 1
		Me.LBLSplash.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'FrmSplash
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
		Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.ClientSize = New System.Drawing.Size(576, 343)
		Me.Controls.Add(Me.LBLSplash)
		Me.Controls.Add(Me.PBSplash)
		Me.DoubleBuffered = True
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
		Me.Name = "FrmSplash"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Form6"
		Me.ResumeLayout(False)

	End Sub
	Friend WithEvents PBSplash As System.Windows.Forms.ProgressBar
	Friend WithEvents LBLSplash As System.Windows.Forms.Label
End Class
