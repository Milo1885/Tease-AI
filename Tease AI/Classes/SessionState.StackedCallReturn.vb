Partial Class SessionState
	<Serializable>
	Friend Class StackedCallReturn
		Inherits ScriptPosition

		Dim yesOrNostate As Boolean

		Sub New(session As SessionState)
			MyBase.New(session, session.FileText, session.StrokeTauntVal, session.GotoFlag, session.CameGotoLine, session.ReturnSubState)
			yesOrNostate = session.YesOrNo
		End Sub
        Sub resumeState()
            Session.StrokeTauntVal = Line
            Session.FileText = FilePath
			Session.ReturnSubState = ReturnState
			Session.GotoFlag = GotoStatus
			Session.FileGoto = LineGoTo
			Session.YesOrNo = yesOrNostate
		End Sub
    End Class
End Class