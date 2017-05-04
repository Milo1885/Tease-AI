<Serializable>
Public Class subAnswers

	Private checkList As New List(Of String)
	Private ssh As SessionState

	Sub New(session As SessionState)
		ssh = session
		checkList.Add(My.Settings.SubGreeting)
		checkList.Add(My.Settings.SubYes)
		checkList.Add(My.Settings.SubNo)
		checkList.Add(My.Settings.SubSorry)
		checkList.Add("please")
		checkList.Add("thank,thanks")
	End Sub

	Public Function returnWords(s As String) As String
		Select Case s
			Case "hi"
				Return checkList.Item(0)
			Case "yes"
				Return checkList.Item(1)
			Case "no"
				Return checkList.Item(2)
			Case "sorry"
				Return checkList.Item(3)
			Case "thanks"
				Return checkList.Item(5)
			Case "please"
				Return checkList.Item(4)
			Case Else
				Return checkList.Item(0)
		End Select
	End Function

	Public Function returnAll() As List(Of String)
		Return checkList
	End Function

	Public Function containListedWords(wordList As String) As Boolean
		Dim list As String() = ssh.obtainSplitParts(wordList, False)
		For i As Integer = 0 To list.Length - 1
			For n As Integer = 0 To checkList.Count() - 1
				If UCase(checkList(n)).Contains(UCase(list(i))) Then Return True
			Next
		Next
		Return False
	End Function
End Class
