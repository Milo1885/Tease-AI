<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dbgSessionForm
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
		Me.components = New System.ComponentModel.Container()
		Me.PropertyGrid1 = New System.Windows.Forms.PropertyGrid()
		Me.TmrUpdate = New System.Windows.Forms.Timer(Me.components)
		Me.SuspendLayout()
		'
		'PropertyGrid1
		'
		Me.PropertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.PropertyGrid1.Location = New System.Drawing.Point(0, 0)
		Me.PropertyGrid1.Name = "PropertyGrid1"
		Me.PropertyGrid1.Size = New System.Drawing.Size(511, 537)
		Me.PropertyGrid1.TabIndex = 0
		'
		'TmrUpdate
		'
		Me.TmrUpdate.Interval = 1000
		'
		'dbgForm
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(511, 537)
		Me.Controls.Add(Me.PropertyGrid1)
		Me.Name = "dbgForm"
		Me.Text = "dbgForm"
		Me.ResumeLayout(False)

	End Sub

	Friend WithEvents PropertyGrid1 As PropertyGrid
	Friend WithEvents TmrUpdate As Timer
End Class
