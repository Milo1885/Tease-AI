
''' <summary>
''' This Class is an Extension for the Class IO.Directory based on the needs of Tease-AI.
''' Comments based on Microsoft: https://msdn.microsoft.com
''' </summary>
Public NotInheritable Class myDirectory

#Region "-------------------------------------------- GetFiles Standard -------------------------------------------------------"

	Private Shared Function DirectoryCheck(path As String)
		If System.IO.Directory.Exists(path) = False _
		And System.IO.Directory.GetParent(path).FullName.StartsWith(Application.StartupPath) _
		Then Return System.IO.Directory.CreateDirectory(path)
	End Function

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

		DirectoryCheck(path)

		Return System.IO.Directory.GetFiles(path)
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

		DirectoryCheck(path)

		Return System.IO.Directory.GetFiles(path, searchPattern)
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

		DirectoryCheck(path)

		Return System.IO.Directory.GetFiles(path, searchPattern, searchOption)
	End Function

#End Region

#Region "---------------------------------------------- GetFiles Media --------------------------------------------------------"

	Public Shared Function GetFilesExtension(ByVal path As String,
										ByVal filter As List(Of String),
										ByVal Optional searchOption As System.IO.SearchOption = System.IO.SearchOption.AllDirectories) As List(Of String)
		Try
			If System.IO.Directory.Exists(path) Then

				' Convert all Extensions to LowerCase
				For i = 0 To filter.Count - 1
					filter(i) = filter(i).ToLower
				Next

				Return myDirectory.GetFiles(path, "*", searchOption) _
					.Where(Function(f) filter.Contains(System.IO.Path.GetExtension(f).ToLower())).ToList
			Else
				Return New List(Of String)
			End If
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

		DirectoryCheck(path)

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

		DirectoryCheck(path)

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

		DirectoryCheck(path)

		Return System.IO.Directory.GetDirectories(path, searchPattern, searchOption)
	End Function

#End Region

End Class
