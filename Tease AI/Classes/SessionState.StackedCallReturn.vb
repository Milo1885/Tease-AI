Partial Class SessionState
	<Serializable> Friend Class StackedCallReturn
		Public Property ReturnStrokeTauntVal As Integer
		Public Property ReturnFileText As String
		Public Property ReturnState As String
		Dim ssh As SessionState

		Sub New(session As SessionState)
			ssh = session
			ReturnStrokeTauntVal = ssh.StrokeTauntVal
			ReturnFileText = ssh.FileText
			ReturnState = ssh.ReturnSubState
		End Sub

		Sub resumeState()
			ssh.StrokeTauntVal = ReturnStrokeTauntVal
			ssh.FileText = ReturnFileText
			ssh.ReturnSubState = ReturnState
		End Sub
	End Class
End Class