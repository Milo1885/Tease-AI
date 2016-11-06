Imports System.IO

Partial Class SessionState

	Public Class FoldersClass
		Dim _Parent As SessionState
		Dim _AppPath As String = Path.GetDirectoryName(Reflection.Assembly.GetExecutingAssembly.Location)

		Sub New(parent As SessionState)
			_Parent = parent
		End Sub



		''' <summary>
		''' Returns the Path for the selected personality. Ends with Backslash!
		''' </summary>
		''' <returns>The Path for the selected personality. Ends with Backslash!</returns>
		Friend ReadOnly Property Personality As String
			Get
				Return String.Format("{0}\Scripts\{1}\", _AppPath, _Parent.DomPersonality)
			End Get
		End Property

		Friend ReadOnly Property PersonalitySystem As String
			Get
				Return String.Format("{0}System\", Personality)
			End Get
		End Property
		''' <summary>
		''' Returns the Path for the selected personalities flags. Ends with Backslash!
		''' </summary>
		''' <returns>The Path for the selected personalities flags. Ends with Backslash!</returns>
		Friend ReadOnly Property Flags As String
			Get
				Return String.Format("{0}System\Flags\", Personality)
			End Get
		End Property
		''' <summary>
		''' Returns the Path for the selected personalities temporary flags. Ends with Backslash!
		''' </summary>
		''' <returns>The Path for the selected personalities temporary flags. Ends with Backslash!</returns>
		Friend ReadOnly Property TempFlags As String
			Get
				Return String.Format("{0}Temp\", Flags)
			End Get
		End Property
		''' <summary>
		''' Returns the Path for the selected personalities variables. Ends with Backslash!
		''' </summary>
		''' <returns>The Path for the selected personalities variables. Ends with Backslash!</returns>
		Friend ReadOnly Property Variables As String
			Get
				Return String.Format("{0}System\Variables\", Personality)
			End Get
		End Property

		Friend ReadOnly Property StartScripts As String
			Get
				Return String.Format("{0}Stroke\Start\", Personality)
			End Get
		End Property

		Friend ReadOnly Property LinkScripts As String
			Get
				Return String.Format("{0}Stroke\Link\", Personality)
			End Get
		End Property

		Friend ReadOnly Property ModuleScripts As String
			Get
				Return String.Format("{0}Modules\", Personality)
			End Get
		End Property

		Friend ReadOnly Property EndScripts As String
			Get
				Return String.Format("{0}Stroke\End\", Personality)
			End Get
		End Property


	End Class



End Class
