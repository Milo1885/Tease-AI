<Serializable>
Public Class Mode
	Public Keyword As String = ""
	Public Type As String = ""
	Public GotoLine As String = ""
	Public MessageText As String = ""
	Public VideoMode As Boolean = False
	Public GotoMode As Boolean = False
	Public MessageMode As Boolean = False

	Public Sub Clear()
		Keyword = ""
		Type = ""
		GotoLine = ""
		MessageText = ""
		VideoMode = False
		GotoMode = False
		MessageMode = False
	End Sub
End Class
