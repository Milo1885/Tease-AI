'===========================================================================================
'
'									 Common.vb
'
' This file contains general functions not related to specific Tasks in Tease-AI.
'===========================================================================================
Imports System.IO


''' <summary>
''' Exposes static methods for common tasks.
''' </summary>
Public Class Common

#Region "--------------------------------------- TextFiles ----------------------------------------------"

	''' =========================================================================================================
	''' <summary>
	''' Reads a TextFile into a generic List(of String). EmptyLines are removed from the list.
	''' </summary>
	''' <param name="GetText">The Filepath to read.</param>
	''' <returns>A List(of String) containing all Lines of the given File. Returns 
	''' an empty List if the specified file doesn't exists, or an exception occurs.</returns>
	''' <remarks>This Method will create the given DirectoryStructure for the given
	''' Filepath if it doesn't exist.</remarks>
	Friend Shared Function Txt2List(ByVal GetText As String) As List(Of String)
		Try
			If GetText Is Nothing Then
				Throw New ArgumentNullException("The given filepath was NULL.")
			End If

			If GetText Is Nothing Or GetText = "" Then
				Throw New ArgumentException("The given filepath was empty """ & GetText & """")
			End If

			' Check if the given Directory exists. MyDirectory.Exists will 
			' try to create the directory, if it's an App-sub-dir.
			If myDirectory.Exists(Path.GetDirectoryName(Path.GetFullPath(GetText))) Then
				Log.Write("Loading Text-File: " & GetText, 5)
				If File.Exists(GetText) Then
					Using TextReader As New StreamReader(GetText)
						Dim TextList As New List(Of String)

						While TextReader.Peek <> -1
							TextList.Add(TextReader.ReadLine())
						End While

						' Remove all empty Lines from list.
						TextList.RemoveAll(Function(x) x = "")

						Return TextList
					End Using
				Else
					Throw New FileNotFoundException("Can't locate the file: """ & GetText & """")
				End If
			Else
				Throw New DirectoryNotFoundException("Can't locate the directory """ & Path.GetDirectoryName(GetText) & """")
			End If
		Catch ex As Exception
			'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
			'						       All Errors
			'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
			Log.WriteError(ex.Message, ex, "Error loading TextFile: """ & GetText & """")
		End Try
		Return New List(Of String)
	End Function

	''' =========================================================================================================
	''' <summary>
	''' Reads the First line of the given textfile.
	''' </summary>
	''' <param name="GetText">On success the first line as string. Otherwise an
	''' empty String.</param>
	''' <returns></returns>
	Friend Shared Function TxtReadLine(ByVal GetText As String) As String
		Try
			If GetText Is Nothing Then
				Throw New ArgumentNullException("The given filepath was NULL.")
			End If

			If GetText Is Nothing Or GetText = "" Then
				Throw New ArgumentException("The given filepath was empty """ & GetText & """")
			End If

			' Check if the given Directory exists. MyDirectory.Exists will 
			' try to create the directory, if it's an App-sub-dir.
			If myDirectory.Exists(Path.GetDirectoryName(Path.GetFullPath(GetText))) Then
				If File.Exists(GetText) Then
					Using TextReader As New StreamReader(GetText)
						Return TextReader.ReadLine
					End Using
				Else
					Throw New FileNotFoundException("Can't locate the file: """ & GetText & """")
				End If
			Else
				Throw New DirectoryNotFoundException("Can't locate the directory """ & Path.GetDirectoryName(GetText) & """")
			End If
		Catch ex As Exception
			'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
			'						       All Errors
			'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
			Log.WriteError(ex.Message, ex, "Error loading TextLine:  " & GetText)
		End Try
		Return ""
	End Function

#End Region ' TextFiles

	''' =========================================================================================================
	''' <summary>
	''' Checks if the given string is an URL.
	''' </summary>
	''' <param name="path">The string to be tested.</param>
	''' <returns>True if the given string is an URL.</returns>
	Friend Shared Function isURL(path As String) As Boolean
		If path.Contains("/") And path.Contains("://") Then
			Return True
		Else
			Return False
		End If
	End Function

End Class
