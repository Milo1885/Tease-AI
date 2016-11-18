
''' <summary>
''' This Class is an Extension for the Class IO.Directory based on the needs of Tease-AI.
''' Comments based on Microsoft: https://msdn.microsoft.com
''' </summary>
Public NotInheritable Class myDirectory

	''' <summary>
	''' Determines whether the given path refers to an existing directory on disk.
	''' This Function creates the Root-directory if it doesn't extists and is a subdirectory of the 
	''' Applications StartupPath. 
	''' </summary>
	''' <param name="path">The path to test. </param>
	''' <returns>true if path refers to an existing directory; false if the directory does not exist or 
	''' an error occurs when trying to determine if the specified directory exists.</returns>
	''' <remarks>BaseFunction to wrap around.</remarks>
	Private Shared Function DirectoryCheck(path As String) As Boolean
		If path.ToUpper = "No path selected".ToUpper Then Return False
		If path = Nothing Then Return False
		If path = "" Then Return False

		If System.IO.Directory.Exists(path) Then
			' The Directory exists => Nothing to do.
			Return True
		Else
			' The Directory does not exist...
			If System.IO.Directory.GetParent(path).FullName.StartsWith(Application.StartupPath) Then
				' ... Is it a SubDirectory of application, create it
				Try
					System.IO.Directory.CreateDirectory(path)
					' everthing fine, Directory has been created.
					Return True
				Catch EX As Exception
					' Error on creation => ReThrow Exception
					Throw
				End Try
			Else
				' ... The Directory does not exist and is no application Subdirectory
				Return False
			End If
		End If
	End Function

	Private Shared Function Sort(SortObject As Object)
		If TypeOf SortObject Is Array Then
			'################## Arrays ###################
			Try
				Array.Sort(DirectCast(SortObject, Array), New LogicalStringComparer)
				Return SortObject
			Catch ex As Exception
			End Try

			Array.Sort(DirectCast(SortObject, Array))
			Return SortObject

		ElseIf TypeOf SortObject Is List(Of String)
			'############## List(of String) ##############
			Try
				DirectCast(SortObject, List(Of String)).Sort(New LogicalStringComparer)
				Return SortObject
			Catch ex As Exception
			End Try

			DirectCast(SortObject, List(Of String)).Sort()
			Return SortObject

		Else
			Throw New InvalidCastException("Object Type unknown.")
		End If
	End Function

	''' <summary>
	''' Determines whether the given path refers to an existing directory on disk.
	''' This Function creates the Root-directory if it doesn't extists and is a subdirectory of the 
	''' Applications StartupPath. 
	''' </summary>
	''' <param name="path">The path to test. </param>
	''' <returns>true if path refers to an existing directory; false if the directory does not exist or 
	''' an error occurs when trying to determine if the specified file exists.</returns>
	Public Shared Function Exists(path As String) As Boolean
		' IF directory-check has failed return an empty String.Array
		Return DirectoryCheck(path)
	End Function

#Region "-------------------------------------------- GetFiles Standard -------------------------------------------------------"

	''' <summary>
	''' Returns the names of files (including their paths) in the specified directory.
	''' This Function creates the Root-directory if it doesn't extists and is a subdirectory of the 
	''' Applications StartupPath. 
	''' </summary>
	''' 
	''' <param name="path">The relative or absolute path to the directory to search. This string is not 
	''' case-sensitive.</param>
	''' 
	''' <returns>An array of the full names (including paths) for the files in the specified directory that 
	''' match the specified search pattern and option, or an empty array if no files are found.</returns>
	''' <seealso cref="System.IO.Directory.GetFiles(String)"/>
	Public Shared Function GetFiles(path) As String()
		' IF directory-check has failed return an empty String.Array
		If DirectoryCheck(path) = False Then Return New List(Of String)().ToArray

		' Read all Files 
		Dim temp() As String = System.IO.Directory.GetFiles(path)

		' Sort the result and return it
		Return Sort(temp)

	End Function

	''' <summary>
	''' Returns the names of files (including their paths) that match the specified search pattern in the 
	''' specified directory. This Function creates the Root-directory if it doesn't extists and is a 
	''' subdirectory of the Applications StartupPath. 
	''' </summary>
	''' 
	''' <param name="path">The relative or absolute path to the directory to search. This string is not 
	''' case-sensitive.</param>
	''' 
	''' <param name="searchPattern">The search string to match against the names of files in path. This 
	''' parameter can contain a combination of valid literal path and wildcard (* and ?) characters 
	''' (see Remarks), but doesn't support regular expressions.</param>
	''' 
	''' <returns>An array of the full names (including paths) for the files in the specified directory that 
	''' match the specified search pattern and option, or an empty array if no files are found.</returns>
	''' <seealso cref="System.IO.Directory.GetFiles(String, String) "/>
	Public Shared Function GetFiles(path As String, searchPattern As String) As String()
		' IF directory-check has failed return an empty String.Array
		If DirectoryCheck(path) = False Then Return New List(Of String)().ToArray

		' Read all Files with the given pattern
		Dim temp() As String = System.IO.Directory.GetFiles(path, searchPattern)

		' Sort the result and return it
		Return Sort(temp)

	End Function

	''' <summary>
	''' Returns the names of files (including their paths) that match the specified search pattern in the 
	''' specified directory, using a value to determine whether to search subdirectories.
	''' This Function creates the Root-directory if it doesn't extists and is a subdirectory of the 
	''' Applications StartupPath. 
	''' </summary>
	''' 
	''' <param name="path">The relative or absolute path to the directory to search. This string is not 
	''' case-sensitive.</param>
	''' 
	''' <param name="searchPattern">The search string to match against the names of files in path. This 
	''' parameter can contain a combination of valid literal path and wildcard (* and ?) characters 
	''' (see Remarks), but doesn't  support regular expressions.</param>
	''' 
	''' <param name="searchOption">One of the enumeration values that specifies whether the search operation 
	''' should include all subdirectories or only the current directory. </param>
	''' 
	''' <returns>An array of the full names (including paths) for the files in the specified directory that 
	''' match the specified search pattern and option, or an empty array if no files are found.</returns>
	''' <seealso cref="System.IO.Directory.GetFiles(String, String, IO.SearchOption) "/>
	Public Shared Function GetFiles(path As String, searchPattern As String, searchOption As System.IO.SearchOption) As String()
		' IF directory-check has failed return an empty String.Array
		If DirectoryCheck(path) = False Then Return New List(Of String)().ToArray

		' Read all Files with the given pattern and Searchoption
		Dim temp() As String = System.IO.Directory.GetFiles(path, searchPattern, searchOption)

		' Sort the result and return it
		Return Sort(temp)

	End Function

#End Region

#Region "---------------------------------------------- GetFiles Media --------------------------------------------------------"

	Public Shared Function GetFilesExtension(ByVal path As String,
										ByVal filter As List(Of String),
										ByVal Optional searchOption As System.IO.SearchOption = System.IO.SearchOption.AllDirectories) As List(Of String)
		Try
			' Convert all Extensions to LowerCase
			For i = 0 To filter.Count - 1
				filter(i) = filter(i).ToLower
			Next

			' Read get all Files with the given pattern
			Dim temp As List(Of String) = myDirectory.GetFiles(path, "*", searchOption) _
					.Where(Function(f) filter.Contains(System.IO.Path.GetExtension(f).ToLower())).ToList

			' Sort the result and return it
			Return Sort(temp)

		Catch ex As Exception
			Throw
		End Try
	End Function

	''' =========================================================================================================
	''' <summary>
	''' Returns the names of videofiles (including their paths) in the specified directory, using a value 
	''' to determine whether to search subdirectories. This Function creates the Root-directory it doeesn't 
	''' extist and it is a subdirectory of the Applications StartupPath. 
	''' </summary>
	''' 
	''' <param name="path">The relative or absolute path to the directory to search. This string is not 
	''' case-sensitive.</param>
	''' 
	''' <param name="searchOption">One of the enumeration values that specifies whether the search operation 
	''' should include all subdirectories or only the current directory. This parameter is optional and 
	''' standard is to search all directories.</param>
	''' 
	''' <returns>A generic list containing all video-files in the directory.</returns>
	''' <exception cref="Exception">Rethrows all exceptions.</exception>
	Public Shared Function GetFilesVideo(ByVal path As String,
										 ByVal Optional searchOption As System.IO.SearchOption = System.IO.SearchOption.AllDirectories) As List(Of String)

		Dim supportedExtension As New List(Of String) From {".wmv", ".avi", ".mp4", ".m4v", ".mpg", ".mov", ".flv"}

		Return GetFilesExtension(path, supportedExtension, searchOption)

	End Function

	''' =========================================================================================================
	''' <summary>
	''' Returns the names of videofiles (including their paths) in the specified directory, using a value 
	''' to determine whether to search subdirectories. This Function creates the Root-directory it doeesn't 
	''' extist and it is a subdirectory of the Applications StartupPath. 
	''' </summary>
	''' 
	''' <param name="path">The relative or absolute path to the directory to search. This string is not 
	''' case-sensitive.</param>
	''' 
	''' <param name="searchOption">One of the enumeration values that specifies whether the search operation 
	''' should include all subdirectories or only the current directory. This parameter is optional and 
	''' standard is to search all directories.</param>
	''' 
	''' <returns>A generic list containing all video-files in the directory.</returns>
	''' <exception cref="Exception">Rethrows all exceptions.</exception>
	Public Shared Function GetFilesImages(ByVal path As String,
										 ByVal Optional searchOption As System.IO.SearchOption = System.IO.SearchOption.AllDirectories) As List(Of String)
		Dim supportedExtension As New List(Of String) From {".png", ".jpg", ".gif", ".bmp", ".jpeg"}

		Return GetFilesExtension(path, supportedExtension, searchOption)

	End Function

#End Region

#Region "----------------------------------------- GetDirectories Standard ----------------------------------------------------"

	''' <summary>
	''' Returns the names of subdirectories (including their paths) in the specified directory.
	''' This Function creates the Root-directory if it doesn't extists and is a subdirectory of the 
	''' Applications StartupPath. 
	''' </summary>
	''' <param name="path">The relative or absolute path to the directory to search. This string is not 
	''' case-sensitive.</param>
	''' 
	''' <returns></returns>
	''' <remarks>IO.Directory.GetDirectories throws a Directory not FoundException, if the Directory of the file cannot 
	''' be found. This Functions create the Directory, as long as it is in die Application.StartupPath.
	''' </remarks>
	''' <seealso cref="System.IO.Directory.GetDirectories(String) "/>
	Public Shared Function GetDirectories(path As String) As String()
		' IF directory-check has failed return an empty String.Array
		If DirectoryCheck(path) = False Then Return New List(Of String)().ToArray

		Return System.IO.Directory.GetDirectories(path)
	End Function

	''' <summary>
	''' Returns the names of the subdirectories (including their paths) that match the specified search 
	''' pattern in the specified directory, and optionally searches subdirectories. This Function creates 
	''' the Root-directory if it doesn't extists and is a subdirectory of the Applications StartupPath. 
	''' </summary>
	''' 
	''' <param name="path">The relative or absolute path to the directory to search. This string is not 
	''' case-sensitive.</param>
	''' 
	''' <param name="searchPattern">The search string to match against the names of subdirectories in path. 
	''' This parameter can contain a combination of valid literal and wildcard characters (see Remarks), 
	''' but doesn't support regular expressions.</param>
	''' 
	''' <returns>An array of the full names (including paths) of the subdirectories that match the specified 
	''' criteria, or an empty array if no directories are found.</returns>
	''' <seealso cref="System.IO.Directory.GetDirectories(String, String, IO.SearchOption)"/>
	Public Shared Function GetDirectories(path As String, searchPattern As String) As String()
		' IF directory-check has failed return an empty String.Array
		If DirectoryCheck(path) = False Then Return New List(Of String)().ToArray

		Return System.IO.Directory.GetDirectories(path, searchPattern)
	End Function



	''' <summary>
	''' Returns the names of the subdirectories (including their paths) that match the specified search 
	''' pattern in the specified directory, and optionally searches subdirectories. This Function creates 
	''' the Root-directory if it doesn't extists and is a subdirectory of the Applications StartupPath. 
	''' </summary>
	''' 
	''' <param name="path">The relative or absolute path to the directory to search. This string is not 
	''' case-sensitive.</param>
	''' 
	''' <param name="searchPattern">The search string to match against the names of subdirectories in path. 
	''' This parameter can contain a combination of valid literal and wildcard characters (see Remarks), 
	''' but doesn't support regular expressions.</param>
	''' 
	''' <param name="searchOption">One of the enumeration values that specifies whether the search operation 
	''' should include all subdirectories or only the current directory.</param>
	''' 
	''' <returns>An array of the full names (including paths) of the subdirectories that match the specified 
	''' criteria, or an empty array if no directories are found.</returns>
	''' <seealso cref="System.IO.Directory.GetDirectories(String, String, IO.SearchOption)"/>
	Public Shared Function GetDirectories(path As String, searchPattern As String, searchOption As System.IO.SearchOption) As String()
		' IF directory-check has failed return an empty String.Array
		If DirectoryCheck(path) = False Then Return New List(Of String)().ToArray

		Return System.IO.Directory.GetDirectories(path, searchPattern, searchOption)
	End Function

#End Region

End Class
