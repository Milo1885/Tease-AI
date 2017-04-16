Partial Class SessionState
	<Serializable>
	Friend Class StackedCallReturn
		Inherits ScriptPosition

		'store if the user was in yesorno mode when callreturn was called
		Dim yesOrNostate As Boolean

		'store all the modes variables so we can reset them on coming back
		Dim edgeMode, ruinMode, cameMode, yesMode, noMode As Mode
		Dim customModes As New Dictionary(Of String, Mode)

		Sub New(session As SessionState)
			MyBase.New(session, session.FileText, session.StrokeTauntVal, session.GotoFlag, session.FileGoto, session.ReturnSubState)
			yesOrNostate = session.YesOrNo
			edgeMode = session.edgeMode
			cameMode = session.cameMode
			ruinMode = session.ruinMode
			yesMode = session.yesMode
			noMode = session.noMode
			customModes = session.Modes
		End Sub
        Sub resumeState()
            Session.StrokeTauntVal = Line
            Session.FileText = FilePath
			Session.ReturnSubState = ReturnState
			Session.GotoFlag = GotoStatus
			Session.FileGoto = LineGoTo
			Session.YesOrNo = yesOrNostate
			Session.edgeMode = edgeMode
			Session.cameMode = cameMode
			Session.ruinMode = ruinMode
			Session.yesMode = yesMode
			Session.noMode = noMode
			Session.Modes = customModes
		End Sub
    End Class
End Class