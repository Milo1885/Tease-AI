<Serializable>
Public Class subAnswers

	Private checkList As New List(Of String)
	Private answerList As New List(Of String)
	Private ssh As SessionState

	Sub New(session As SessionState)
		ssh = session
		checkList.Add(My.Settings.SubGreeting)
		checkList.Add(My.Settings.SubYes)
		checkList.Add(My.Settings.SubNo)
		checkList.Add(My.Settings.SubSorry)
		checkList.Add("thank,thanks")
		checkList.Add("please")
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
				Return checkList.Item(4)
			Case "please"
				Return checkList.Item(5)
			Case Else
				Return checkList.Item(0)
		End Select
	End Function

	Public Function returnAll() As List(Of String)
		Return checkList
	End Function

	Public Function returnAnswerList() As List(Of String)
		Return answerList
	End Function

	Public Function returnSystemWord(wordList As String) As String
		For i As Integer = 0 To checkList.Count() - 1
			Dim list As String() = ssh.obtainSplitParts(checkList(i), False)
			For n As Integer = 0 To list.Count - 1
				If Trim(UCase(wordList)) = Trim((UCase(list(n)))) Then
					Select Case i
						Case 0
							Return "hi"
						Case 1
							Return "yes"
						Case 2
							Return "no"
						Case 3
							Return "sorry"
						Case 4
							Return "thanks"
						Case 5
							Return "please"
						Case Else
							Return "hi"
					End Select
				End If
			Next
		Next
		Return ""
	End Function

	Public Sub addToAnswerList(ByVal words As String)
		Dim split() = words.Split(",")
		For i As Integer = 0 To split.Count - 1
			answerList.Add(Trim(split(i)))
		Next
	End Sub

	Public Sub clearAnswers()
		answerList.Clear()
	End Sub

	Public Function triggerWord(chatstring As String) As String

		'we first order the list based on lenght of the answer option (and if equal lenght, by the order in which they are in the answer list)

		Dim sorted = answerList.OrderByDescending(Function(x) x.Length).ThenBy(Function(x) answerList.IndexOf(x)).ToArray

		'we then check only the answers with more than 1 word to see if the chat strings contain any of them

		For i As Integer = 0 To sorted.Count - 1
			If InStr(sorted(i), " ") > 0 Then If LCase(chatstring).Contains(LCase(sorted(i)).Trim) Then Return sorted(i).Trim
		Next

		'if all multiple words answers didn't return an answer, we check for the single words in the chat to see if any of them matches

		Dim singleWords() = ssh.obtainSplitParts(chatstring, True)
		For i As Integer = 0 To singleWords.Count - 1
			For n As Integer = 0 To answerList.Count - 1
				If LCase(answerList(n)) = LCase(singleWords(i)) Then Return singleWords(i)
			Next
		Next
		Return ""
	End Function

	Public Function answerNumber() As Integer
		Return answerList.Count
	End Function

End Class
