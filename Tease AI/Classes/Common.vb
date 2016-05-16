'===========================================================================================
'
'									 Common.vb
'
' This file contains general functions not related to specific Tasks in Tease-AI.
'===========================================================================================
Imports System.IO
Imports System.Net

''' <summary>
''' Exposes static methods for common tasks.
''' </summary>
Public Class Common

#Region "--------------------------------------- TextFiles ----------------------------------------------"

#Region "---------------------------------------- Caching -----------------------------------------------"

	''' =========================================================================================================
	''' <summary>
	''' Synclocked Object!
	''' <para> Do not Access directly. Use the Property instead.</para>
	''' </summary>
	Shared _txtcache As New Dictionary(Of String, List(Of String))
	''' <summary>
	''' Synclock-Storage for TxtCache.
	''' </summary>
	Shared _synclockTxtCache As New Object

	''' <summary>
	''' A Dictionary containing all textfiles read by txt3List(string)
	''' </summary>
	Private Shared Property TxtCache As Dictionary(Of String, List(Of String))
		Get
			SyncLock _synclockTxtCache
				Return _txtcache
			End SyncLock
		End Get
		Set(value As Dictionary(Of String, List(Of String)))

			SyncLock _synclockTxtCache
				value = _txtcache
			End SyncLock
		End Set
	End Property

	''' =========================================================================================================
	''' <summary>
	''' Synclocked Object!
	''' <para> Do not Access directly. Use the Property instead.</para>
	''' </summary>
	Shared _FswTxtCache As New Dictionary(Of String, FileSystemWatcher)
	''' <summary>
	''' Synclock-Storage for TxtCache.
	''' </summary>
	Shared _synclockFswTxtCache As New Object
	''' <summary>
	''' A Dictionary containing all filesystemwatchers for directories 
	''' containing files of the TxtCache.
	''' </summary>
	Shared Property FswChache As Dictionary(Of String, FileSystemWatcher)
		Get
			SyncLock _synclockFswTxtCache
				Return _FswTxtCache
			End SyncLock
		End Get
		Set(value As Dictionary(Of String, FileSystemWatcher))
			SyncLock _synclockFswTxtCache
				_FswTxtCache = value
			End SyncLock
		End Set
	End Property


	Private Shared Sub createFileSystemWatcher(ByVal Filepath As String)
		Try
			Dim tmpString As String = Path.GetDirectoryName(Filepath)

			If tmpString = Application.StartupPath Then Exit Sub
			If FswChache.Keys.Contains(tmpString) Then Exit Sub

			Dim tmpFsw As New FileSystemWatcher With
			{
				.IncludeSubdirectories = True,
				.Path = tmpString
			}

			AddHandler tmpFsw.Changed, AddressOf UpdateTextfileCache
			AddHandler tmpFsw.Renamed, AddressOf UpdateTextfileCache

			tmpFsw.EnableRaisingEvents = True

			FswChache.Add(tmpString, tmpFsw)
		Catch ex As Exception
			Debug.Print("Unable to Create FileSystemWatcher for:" & Filepath)
		End Try
	End Sub

	Private Shared Sub UpdateTextfileCache(sender As Object, e As FileSystemEventArgs)
		If TxtCache.Keys.Contains(e.FullPath.ToLower) Then
			Debug.Print("Removing modified file from cache:  " & e.FullPath)
			TxtCache.Remove(e.FullPath.ToLower)
		End If
	End Sub

#End Region ' Caching









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

			Dim TextList As New List(Of String)

			If TxtCache.Keys.Contains(GetText.ToLower) Then
				Log.Write("Loading cached Text-File: " & GetText, 5)

				Txt2List = TxtCache(GetText.ToLower).ToList

				Exit Function
				'Return TxtCache(GetText.ToLower).ToList
			End If




			' Check if the given Directory exists. MyDirectory.Exists will 
			' try to create the directory, if it's an App-sub-dir.
			If myDirectory.Exists(Path.GetDirectoryName(Path.GetFullPath(GetText))) Then
				Log.Write("Reading Text-File: " & GetText, 5)
				If File.Exists(GetText) Then

					Using TextReader As New StreamReader(GetText)

						While TextReader.Peek <> -1
							TextList.Add(TextReader.ReadLine())
						End While

						' Remove all empty Lines from list.
						TextList.RemoveAll(Function(x) x = "")

						TxtCache.Add(GetText.ToLower, TextList.ToList)

						createFileSystemWatcher(GetText)
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

	''' =========================================================================================================
	''' <summary>
	''' Removes all lines containing the given string from a file.
	''' </summary>
	''' <param name="Filepath">The File to delete from</param>
	''' <param name="Searchpattern">The Filter what the line has to contain to delet it. (Case Insensitive)
	''' Has to be at least 6 chars long.
	''' </param>
	''' <returns>The count of removed lines .</returns>
	Friend Shared Function TxtRemoveLine(ByVal Filepath As String,
										 ByVal Searchpattern As String) As Integer
		Dim rtnInt As Integer = 0
		Try
			If Searchpattern = Nothing Then Throw New ArgumentException("Searchpattern was empty.")
			If Searchpattern.Count < 5 Then Throw New ArgumentException("Searchpattern has to be longer than 5 Chars.")
			' Read the TextFile
			Dim tmplist As List(Of String) = Txt2List(Filepath)

			' Check if File has lines.
			If tmplist.Count > 0 Then
				' Remove all lines containing the searchpattern
				rtnInt = tmplist.RemoveAll(Function(x) x.ToLower.Contains(Searchpattern.ToLower))

				' If there were Lines deleted, 
				If rtnInt > 0 Then File.WriteAllLines(Filepath, tmplist)
			End If

			'Return the Deleted line count 
			Return rtnInt
		Catch ex As Exception
			'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
			'						       All Errors
			'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
			Log.WriteError(ex.Message, ex, "Error removing TextLine: """ & Searchpattern &
						   """ from file """ & Filepath & """")
			Return 0
		End Try
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


	''' <summary>
	''' Download an image ffrom url.
	''' </summary>
	''' <param name="uri"></param>
	''' <param name="fileName"></param>
	Friend Shared Function DownloadRemoteImageFile(uri As String, Optional fileName As String = "") As Image
		Dim request As HttpWebRequest = DirectCast(WebRequest.Create(uri), HttpWebRequest)
		Dim response As HttpWebResponse = Nothing
		Dim rtnImage As Image = Nothing
		Try
			request.Timeout = 30000
			response = DirectCast(request.GetResponse(), HttpWebResponse)


			' Check that the remote file was found. The ContentType
			' check is performed since a request for a non-existent
			' image file might be redirected to a 404-page, which would
			' yield the StatusCode "OK", even though the image was not
			' found.
			If (response.StatusCode = HttpStatusCode.OK OrElse response.StatusCode =
			HttpStatusCode.Moved OrElse response.StatusCode = HttpStatusCode.Redirect) AndAlso
			response.ContentType.StartsWith("image", StringComparison.OrdinalIgnoreCase) Then

				' if the remote file was found, download oit
				Using inputStream As Stream = response.GetResponseStream()

					' Use a Memorystream to get a free rewindable stream
					' Otherwise gifs are not animated after saving anymore
					Dim MS As New MemoryStream
					inputStream.CopyTo(ms)
					MS.Position = 0
					rtnImage = Image.FromStream(MS)

					' Check if image has to be saved.
					If fileName = "" Then Return rtnImage
					rtnImage.Save(fileName)

					Debug.Print("Saved image: " & fileName)
				End Using
			End If
		Catch ex As Exception When rtnImage IsNot Nothing
			'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
			'                               All Errors - But image was loaded so return it.
			'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
			Debug.Print("Exception while saving image: """ & uri & "")
			Log.WriteError("Exception while saving image:  """ & uri & "", ex, "Exception while saving image")
			Return rtnImage
		Catch ex As Exception
			'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
			'                                            All Errors
			'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
			Debug.Print("Exception before saving the image from Uri: " & uri)
			Throw
		Finally
			'⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑ Finally ⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑
			If response IsNot Nothing Then response.Close()
			request.Abort()
		End Try
		Return rtnImage
	End Function




End Class
