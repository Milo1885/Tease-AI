Imports System.IO

''' <summary> Class to process TauntFiles </summary>
Public Class TauntProcessingObject

	''' <summary> Absolute path to taunt file. </summary>
	Friend Property FilePath As String = ""

	''' <summary>gets tauntfile's name without extension. </summary>
	Friend ReadOnly Property FileName As String
		Get
			Return Path.GetFileNameWithoutExtension(FilePath)
		End Get
	End Property

	''' <summary> Filtered taunt file Lines.</summary>
	Friend Property Lines As New List(Of String)

	Dim _TauntSize As Integer = -1
	''' <summary> Gets the number of lines in a taunt. </summary>
	'''<returns>1-based value</returns>
	Friend ReadOnly Property TauntSize As Integer
		Get
			If _TauntSize = -1 AndAlso FileName.Length > 4 Then
				' get the last 4 numeric chars in filename and convert them to a number
				Dim TmpString As String = ""

				For i = FileName.Length - 1 To FileName.Length - 4 Step -1
					If IsNumeric(FileName(i)) Then
						TmpString = FileName(i) & TmpString
					Else
						Exit For
					End If
				Next

				If IsNumeric(TmpString) Then _TauntSize = CInt(TmpString)
			End If

			Return _TauntSize
		End Get
	End Property

	''' <summary>Gets a random taunt start line. </summary>
	Friend ReadOnly Property RandomTauntLine As Integer
		Get
			If Avaialable Then
				Dim GroupCount = Lines.Count / TauntSize ' 1-based
				Dim RndGroup As Integer = My.Application.Session.randomizer.Next(1, GroupCount + 1) - 1 ' 0-based
				Dim ScriptLine As Integer = RndGroup * TauntSize

				Return ScriptLine
			Else
				Return -1
			End If
		End Get
	End Property

	''' <summary> Returns if a Taunt is useable.</summary>
	''' <returns>Returns true, if taunt has valid lines and right ammount.</returns>
	ReadOnly Property Avaialable As Boolean
		Get
			If (Lines.Count > 0 And TauntSize > 0) AndAlso Lines.Count >= TauntSize Then
				Return True
			Else
				Return False
			End If
		End Get
	End Property

	''' <summary> Creates a new instance and loads the data from given filepath </summary>
	''' <param name="absolutePath">The file to load.</param>
	''' <param name="Form1Reference">Object Reference to run filtering on.</param>
	''' <remarks>Non-Threadsafe</remarks>
	Sub New(ByVal absolutePath As String, ByVal Form1Reference As Form1)
		Try
			FilePath = absolutePath

			' Set TauntSize for filtering.
			Form1Reference.ssh.StrokeTauntCount = TauntSize

			' Read lines.
			Lines = Txt2List(FilePath)

			' Filter lines.
			Form1Reference.ssh.StrokeFilter = True
			Dim linesFiltered As List(Of String) = Form1Reference.FilterList(Lines)
			Form1Reference.ssh.StrokeFilter = False

		Catch ex As Exception
			Throw
		End Try
	End Sub

End Class