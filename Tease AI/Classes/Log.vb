Imports System.IO

''' <summary>
''' Provides Static procedures to write Messages to predefined TextFiles.
''' </summary>
Public Class Log

	Friend Shared Sub WriteError(ByVal msg As String,
   ByVal exception As Exception, ByVal title As String)
		Try
			Trace.Write("Exception occured: " & msg)
			Dim TargetFilePath As String = Application.StartupPath &
			"\ErrorLogs\" & Today.ToString("yyyy-MM-dd") & "_errorlog.txt"

			Dim StList As List(Of String) = Environment.StackTrace.Replace(vbLf, "").Split(vbCrLf).ToList
			StList.RemoveRange(0, 3)
			Dim StString As String = String.Join(vbCrLf, StList)

			If Not Directory.Exists(Path.GetDirectoryName(TargetFilePath)) Then
				Directory.CreateDirectory(Path.GetDirectoryName(TargetFilePath))
			End If

			'check the file
			Using fs As New FileStream(TargetFilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite)
				Using s As New StreamWriter(fs)
				End Using
			End Using

			'log it
			Using fs1 As New FileStream(TargetFilePath, FileMode.Append, FileAccess.Write)
				Using s1 As New StreamWriter(fs1)
					s1.Write("###################################################################" & vbCrLf)
					s1.Write("Date/Time: " & Now.ToString("yyyy-MM-dd HH:mm:ss") & vbCrLf)
					s1.Write("Version: " & My.Application.Info.Version.ToString & vbCrLf)
					s1.Write("Title: " & title & vbCrLf)
					s1.Write("Message: " & msg & vbCrLf)
					s1.Write("Exceptions: " & Replace(ExceptonToString(exception), vbCrLf, vbCrLf & vbTab) & vbCrLf)
					s1.Write(vbCrLf & vbCrLf)
					s1.Write("~~~~~~~~~~~~~~~~~~~~Application.StackTrace~~~~~~~~~~~~~~~~~~~~~~~~~" & vbCrLf & StString & vbCrLf & vbCrLf)
				End Using
			End Using

			My.Application.HandledException(msg, exception)
		Catch ex As Exception
			Trace.Write("Log-Error: " & ex.Message)
		End Try
	End Sub


	''' <summary>
	''' Function to format a Exception and all it's inner Exceptions.
	''' </summary>
	''' <param name="Exception"></param>
	''' <param name="PrintInnerException"></param>
	''' <returns></returns>
	Friend Shared Function ExceptonToString(ByVal Exception As Exception,
						   Optional ByVal PrintInnerException As Boolean = True) As String


		Dim rtnTExt As String = ""
next_innerException:
		rtnTExt &= vbCrLf & "================================== Exception ====================================="
		rtnTExt &= vbCrLf & "Message: " & Exception.Message.ToString
		rtnTExt &= vbCrLf & "Typ:     " & Exception.GetType.ToString
		rtnTExt &= vbCrLf & "StackTrace:"
		rtnTExt &= vbCrLf & Exception.StackTrace

		If Not Exception.InnerException Is Nothing And PrintInnerException Then
			Exception = Exception.InnerException
			GoTo next_innerException
		End If

		Return rtnTExt
	End Function

	Public Class TextTraceListener
		Inherits TraceListener

		Private LogPath As String

		Private Shared LogStreamSynclock As New Object

		<DebuggerStepThrough>
		Private Sub FileWrite(ParamArray text As String())
			SyncLock LogStreamSynclock
				CheckFile()

				Using fs As New FileStream(LogPath, FileMode.Append, FileAccess.Write), sw As New StreamWriter(fs)
					Dim indent As String = GetIndent()
					For Each str As String In text
						If str IsNot Nothing Then sw.WriteLine(Now.ToString() & " " & indent & str)
					Next
				End Using
			End SyncLock
		End Sub

		<DebuggerStepThrough>
		Private Sub FileWriteLine(ParamArray text As String())
			SyncLock LogStreamSynclock
				CheckFile()

				Using fs As New FileStream(LogPath, FileMode.Append, FileAccess.Write), sw As New StreamWriter(fs)
					Dim indent As String = GetIndent()
					For Each str As String In text
						If str IsNot Nothing Then sw.WriteLine(Now.ToString() & " " & indent & str)
					Next
				End Using
			End SyncLock
		End Sub


		<DebuggerStepThrough>
		Sub New(filePath As String)
			If Path.IsPathRooted(filePath) Then
				LogPath = filePath
			Else
				LogPath = Application.StartupPath & Path.DirectorySeparatorChar.ToString & filePath
			End If

			Me.NeedIndent = True
		End Sub


		<DebuggerStepThrough>
		Private Sub CheckFile()
			If Not Directory.Exists(Path.GetDirectoryName(LogPath)) Then _
				Directory.CreateDirectory(Path.GetDirectoryName(LogPath))
restart:
			If File.Exists(LogPath) = False Then
				'===============================================================================
				' Create new file
				'===============================================================================

				File.WriteAllText(LogPath,
								"=========================== LogFile Created =============================" & vbCrLf &
								"File Date: " & Now.ToString("yyyy-MM-dd HH:mm:ss") & vbCrLf &
								"If you want to remove the Stacktrace: Use NotePad++ and search Regex with" & vbCrLf &
								"MatchPattern: \t@>~@>~[^\a]*?~<@~<@+?\r\n" & vbCrLf &
								"ReplacePatten: Leave it Empty" & vbCrLf &
								"=========================== LogFile Created =============================" & vbCrLf)
			Else
				'===============================================================================
				' Delete File if Size > 2 MB
				'===============================================================================
				Dim MyFile As New FileInfo(LogPath)
				Dim FileSize As Long = MyFile.Length
				If FileSize > 2097152 Then

					Dim Lines As List(Of String) = File.ReadAllLines(LogPath).ToList
					Dim HeaderLines As Integer = 6

					Dim DeleteCount As Integer = (Lines.Count - HeaderLines) * 0.1

					If DeleteCount < 1 Then
						File.Delete(LogPath)
					Else
						Lines.RemoveRange(HeaderLines + 1, DeleteCount)
						File.WriteAllLines(LogPath, Lines)
					End If
					GoTo restart
				End If

			End If
		End Sub

		<DebuggerStepThrough>
		Private Function GetIndent() As String
			GetIndent = ""

			For i = 0 To Me.IndentLevel - 1
				For z = 0 To Me.IndentSize - 1
					GetIndent &= " "
				Next
			Next
		End Function

		<DebuggerStepThrough>
		Private Function GetStackTrace(ByVal stackdepth As Integer) As String
			Dim StList As List(Of String) = Environment.StackTrace.Replace(vbLf, "").Split(vbCrLf).ToList

			' Remove fist 5 Items, Because its the Call-Depth of Environment.StackTrace() and TraceStuff
			StList.RemoveRange(0, 5)

			' Save the StackTraceCount for printing
			Dim StackCountOrg As Integer = StList.Count

			' Trim Stacktrace
			If stackdepth > 0 AndAlso StList.Count > stackdepth Then
				StList.RemoveRange(stackdepth - 1, StList.Count - stackdepth)
			End If

			Return GetIndent() & "    " & "@>~@>~~~~~~~~~~~~Application.StackTrace (" & stackdepth & "/" & StackCountOrg & ")~~~~~~~~~~~~~~~~~~" & vbCrLf &
					GetIndent() & "    " & String.Join(vbCrLf & "    " & GetIndent(), StList) & vbCrLf &
					GetIndent() & "    " & "~~~~~~~~~~~~~~~~~Application.StackTrace (" & stackdepth & "/" & StackCountOrg & ")~~~~~~~~~~~~~<@~<@"

		End Function

		<DebuggerStepThrough>
		Public Overrides Sub Write(message As String)
			CheckFile()
			FileWrite(message)
		End Sub

		<DebuggerStepThrough>
		Public Overrides Sub WriteLine(message As String)
			CheckFile()
			FileWriteLine(message)
		End Sub

		<DebuggerStepThrough>
		Public Overrides Sub WriteLine(message As String, category As String)
			CheckFile()

			If category.StartsWith("TxtCache") Then
				Dim ts As TraceSwitch = New TraceSwitch("TxtCache", "")
				Dim stacktrace As String = If(ts.TraceVerbose, GetStackTrace(5), Nothing)
				FileWriteLine(New String() {category & ": " & message, stacktrace})
			Else
				FileWriteLine(message)
			End If

		End Sub

	End Class

End Class
