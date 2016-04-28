Imports System.IO
Imports System.Reflection

''' <summary>
''' Provides Static procedures to write Messages to predefined TextFiles.
''' </summary>
Public Class Log
	Public Shared Sub Write(ByVal text As String)
		'╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩
		'
		'	                       Write Data to Logfile
		'
		'╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦
		Try
			Dim Logfile As String = Application.StartupPath & "\log.txt"
			Dim DateString As String = Now.ToUniversalTime.ToString("yyyy-MM-dd HH:mm:ss")
			Dim StList As List(Of String) = Environment.StackTrace.Replace(vbLf, "").Split(vbCrLf).ToList
			StList.RemoveRange(0, 3)
			Dim StString As String = String.Join(vbCrLf, StList)
Restart:
			'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
			'                               Check File
			'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
			If File.Exists(Logfile) = False Then
				'===============================================================================
				' Create new file
				'===============================================================================
				Using sw As New StreamWriter(Logfile)
					Dim fecha As Date = IO.File.GetCreationTime(Assembly.GetExecutingAssembly().Location)
					sw.Write("======================= LogFile Created ==========================" & vbCrLf &
							 "FileDate: " & DateString & vbCrLf &
							 "Build Date: " & fecha.ToUniversalTime.ToString("yyyy-MM-dd HH:mm:ss") & vbCrLf &
							 "If you want to remove the Stacktrace use NotePad++. Search Regex with" & vbCrLf &
							 "MatchPattern: @>~@>~[^\a]*?~<@~<@+?" & vbCrLf & vbCrLf)
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
					s1.Write(DateString & " " & text & vbCrLf)
					s1.Write("@>~@>~~~~~~~~~~~~~~~Application.StackTrace~~~~~~~~~~~~~~~~~~~~~~~~~" & vbCrLf)
					s1.Write(StString & vbCrLf)
					s1.Write("~~~~~~~~~~~~~~~~~~~~Application.StackTrace~~~~~~~~~~~~~~~~~~~~<@~<@" & vbCrLf)
				End Using
			End Using
		Catch ex As Exception
			Trace.Write("Log-Error: " & ex.Message)
		End Try
	End Sub

	Friend Shared Sub WriteError(ByVal msg As String,
   ByVal Exception As Exception, ByVal title As String)
		Try
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
					s1.Write("Date/Time: " & DateTime.Now.ToString() & vbCrLf)
					s1.Write("Version: " & My.Application.Info.Version.ToString & vbCrLf)
					s1.Write("BuildDate: " & File.GetCreationTimeUtc(Assembly.GetExecutingAssembly().Location) & vbCrLf)
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
