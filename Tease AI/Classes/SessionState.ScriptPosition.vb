Imports System.IO
Partial Class SessionState

	<Serializable>
	Public MustInherit Class ScriptPosition
		Public Property Session As SessionState = Nothing

		Dim _FilePath As String = Nothing
		''' <summary>Get or sets the Filepath. </summary>
		''' <returns>Returns the absolute filepaths.</returns>
		''' <remarks>If the filepath is within the persomality path, it is stored internal as relative path. 
		''' This is done to support moving of application-folder between serializing and deserializing.</remarks>
		Public Property FilePath As String
			Get
				If Path.IsPathRooted(_FilePath) Then
					Return _FilePath
				Else
					Return Session.Folders.Personality & _FilePath
				End If
			End Get
			Set(value As String)
				If Path.IsPathRooted(value) AndAlso value.StartsWith(Session.Folders.Personality, StringComparison.OrdinalIgnoreCase) Then
					_FilePath = value.Replace(Session.Folders.Personality, "")
				Else
					_FilePath = value
				End If
			End Set
		End Property

		Public Property Line As Integer = -1

		''' <summary>Creates a new instance with given parameters.</summary>
		Sub New(session As SessionState, filepath As String, line As Integer)
			Me.Session = session
			Me.FilePath = filepath
			Me.Line = line
		End Sub

	End Class

End Class