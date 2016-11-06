Partial Class SessionState

	Friend Class FileClass
		Dim _Session As SessionState

		Sub New(session As SessionState)
			_Session = session
		End Sub

		Friend ReadOnly Property StartChecklist As String
			Get
				Return _Session.Folders.PersonalitySystem & "StartCheckList.cld"
			End Get
		End Property

		Friend ReadOnly Property ModuleChecklist As String
			Get
				Return _Session.Folders.PersonalitySystem & "ModuleCheckList.cld"
			End Get
		End Property

		Friend ReadOnly Property LinkChecklist As String
			Get
				Return _Session.Folders.PersonalitySystem & "LinkCheckList.cld"
			End Get
		End Property

		Friend ReadOnly Property EndChecklist As String
			Get
				Return _Session.Folders.PersonalitySystem & "EndCheckList.cld"
			End Get
		End Property


	End Class


End Class
