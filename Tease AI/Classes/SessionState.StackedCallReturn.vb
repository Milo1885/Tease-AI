Partial Class SessionState
	<Serializable>
	Friend Class StackedCallReturn
		Inherits ScriptPosition

		Public Property ReturnState As String

		Sub New(session As SessionState)
            MyBase.New(session, session.FileText, session.StrokeTauntVal, session.GotoFlag, session.CameGotoLine)
            ReturnState = Me.Session.ReturnSubState
        End Sub
        Sub resumeState()
            Session.StrokeTauntVal = Line
            Session.FileText = FilePath
            Session.ReturnSubState = ReturnState
            Session.FileGoto = LineGoTo
        End Sub
    End Class
End Class