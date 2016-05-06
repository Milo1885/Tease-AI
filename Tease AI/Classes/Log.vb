Imports System.IO
Imports System.Reflection

''' <summary>
''' Provides Static procedures to write Messages to predefined TextFiles.
''' </summary>
Public Class Log

	''' <summary>
	''' Writes Data to a Logfifile
	''' </summary>
	''' <param name="text">The Text to append to file.</param>
	''' 
	''' <param name="stackDepth">Determines the maximum depth of Stacktrace 
	''' written with the Message.</param>
	Public Shared Sub Write(ByVal text As String, Optional ByVal stackDepth As Integer = 0)
		'╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩
		'
		'	                       Write Data to Logfile
		'
		'╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦
		Try
			Dim Logfile As String = Application.StartupPath & "\log.txt"
			Dim StList As List(Of String) = Environment.StackTrace.Replace(vbLf, "").Split(vbCrLf).ToList

			' Remove fist 3 Items, Because its the Call-Depth of Environment.StackTrace() and Write(String)
			StList.RemoveRange(0, 3)

			' Save the StackTraceCount for printing
			Dim StackCountOrg As Integer = StList.Count

			' Trim Stacktrace
			If stackDepth > 0 AndAlso StList.Count > stackDepth Then
				StList.RemoveRange(stackDepth - 1, StList.Count - stackDepth)
			End If

			Dim StString As String = String.Join(vbCrLf & vbTab, StList)
Restart:
			'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
			'                               Check File
			'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
			If File.Exists(Logfile) = False Then
				'===============================================================================
				' Create new file
				'===============================================================================
				Using sw As New StreamWriter(Logfile)
					Dim fecha As Date = IO.File.GetLastWriteTimeUtc(Assembly.GetExecutingAssembly().Location)
					sw.Write("=========================== LogFile Created =============================" & vbCrLf &
							 "Build Date (UTC): " & fecha.ToUniversalTime.ToString("yyyy-MM-dd HH:mm:ss") & vbCrLf &
							 "File Date (UTC): " & Now.ToUniversalTime.ToString("yyyy-MM-dd HH:mm:ss") & vbCrLf &
							 "If you want to remove the Stacktrace: Use NotePad++ and search Regex with" & vbCrLf &
							 "MatchPattern: \t@>~@>~[^\a]*?~<@~<@+?\r\n" & vbCrLf &
							 "ReplacePatten: Leave it Empty" & vbCrLf &
							 "=========================== LogFile Created =============================" & vbCrLf & vbCrLf)
				End Using
			Else
				'===============================================================================
				' Delete File if Size > 2 MB
				'===============================================================================
				Dim MyFile As New FileInfo(Logfile)
				Dim FileSize As Long = MyFile.Length
				If FileSize > 2097152 Then
					File.Delete(Logfile)
					GoTo Restart
				End If
			End If
			'▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲
			' CheckFile - End
			'▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲
			'===============================================================================
			' Write Text
			'===============================================================================
			Using fs1 As New FileStream(Logfile, FileMode.Append, FileAccess.Write)
				Using s1 As New StreamWriter(fs1)
					s1.Write(Now.ToString("yyyy-MM-dd HH:mm:ss") & " " & text & vbCrLf)
					If stackDepth > 0 Then
						s1.Write(vbTab & "@>~@>~~~~~~~~~~~~Application.StackTrace (" & stackDepth & "/" & StackCountOrg & ")~~~~~~~~~~~~~~~~~~" & vbCrLf)
						s1.Write(vbTab & StString & vbCrLf)
						s1.Write(vbTab & "~~~~~~~~~~~~~~~~~Application.StackTrace (" & stackDepth & "/" & StackCountOrg & ")~~~~~~~~~~~~~<@~<@" & vbCrLf)
					End If
				End Using
			End Using
		Catch ex As Exception
			Trace.Write("Log-Error: " & ex.Message)
		End Try
	End Sub

	Friend Shared Sub WriteError(ByVal msg As String,
   ByVal Exception As Exception, ByVal title As String)
		Try
			Write("Exception occured: " & msg)
			Dim TargetFilePath As String = Application.StartupPath &
			"\ErrorLogs\" & Today.ToUniversalTime.ToString("yyyy-MM-dd") & "_errorlog.txt"

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
					s1.Write("Date/Time: " & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & vbCrLf)
					s1.Write("Version: " & My.Application.Info.Version.ToString & vbCrLf)
					s1.Write("BuildDate (UTC): " & File.GetLastWriteTimeUtc(Assembly.GetExecutingAssembly().Location).ToString("yyyy-MM-dd HH:mm:ss") & vbCrLf)
					s1.Write("Title: " & title & vbCrLf)
					s1.Write("Message: " & msg & vbCrLf)
					s1.Write("Exceptions: " & Replace(ExceptonToString(Exception), vbCrLf, vbCrLf & vbTab) & vbCrLf)
					s1.Write(vbCrLf & vbCrLf)
					s1.Write("~~~~~~~~~~~~~~~~~~~~Application.StackTrace~~~~~~~~~~~~~~~~~~~~~~~~~" & vbCrLf & StString & vbCrLf & vbCrLf)
				End Using
			End Using
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

End Class
