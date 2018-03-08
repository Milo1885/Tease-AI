Partial Class SessionState
	<Serializable>
	Friend Class StackedCallReturn
		Inherits ScriptPosition

		'store if the user was in yesorno mode when callreturn was called
		Dim yesOrNostate As Boolean

		'store wheter we are currently running a module or we are in a stroking cycle
		Dim showingModule As Boolean

		'store the isLink status (useful for the "safenet" that will allow to start the stroke cycle even if the script doesn't contain a @StartStroking/Taunt
		'when it reaches the end of a link/beforeScript)
		Dim isALink As Boolean

		'store the rapidcode status so we can resume it when coming back if the script was in this mode
		Dim rapidText, rapidCode As Boolean

		'store all the modes variables so we can reset them on coming back
		Dim edgeMode, ruinMode, cameMode, yesMode, noMode As New Mode()
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
			showingModule = session.ShowModule
			isALink = session.isLink
			rapidCode = session.RapidCode
			rapidText = session.RapidFire
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
			Session.ShowModule = showingModule
			Session.isLink = isALink
			Session.RapidCode = rapidCode
			Session.RapidFire = rapidText
		End Sub
    End Class
End Class