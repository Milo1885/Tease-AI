Imports System.IO


Public Enum ContactType
	[Nothing]
	Domme
	Contact1
	Contact2
	Contact3
End Enum

<Serializable>
Public Class Slideshow

	Public Property Contact As ContactType = ContactType.Nothing

	Public Property ImageFolder As String = ""

	Public Property ImageList As New List(Of String)

	Public Property Index As Integer = -1

	Sub New() : End Sub

	Sub New(ByVal type As ContactType)
		Contact = type
		Check_ImageDir(type)
	End Sub

	Shared Function FolderCheck(ByVal directoryDescription As String,
												ByVal directoryPath As String,
												ByVal defaultPath As String)
		Try
			Dim rtnPath As String

			' Exit if default value.
			If directoryPath = defaultPath Then Return defaultPath

			' check it if the directory exists.
			If Directory.Exists(directoryPath) Then rtnPath = directoryPath : GoTo checkFolder

			' Tell User, the dir. wasn't found. Ask to search manually for the folder.
			If MessageBox.Show(
						   "The directory """ & directoryPath & """ was not found." & vbCrLf & "Do you want to search for it?",
						   directoryDescription & " slideshow directory not found.",
						   MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) <> DialogResult.Yes Then
set_default:
				Return defaultPath
			Else
				'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
				'								Set new Folder
				'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
set_newFolder:
				' Find the first available parent-directory. 
				' This way the user hasn't to browse through his hole IO-System.
				Dim __tmp_dir As String = directoryPath
				Do Until Directory.Exists(__tmp_dir) Or __tmp_dir Is Nothing
					__tmp_dir = Path.GetDirectoryName(__tmp_dir)
				Loop

				' Initialize new Dialog-Form
				Dim FolSel As New FolderBrowserDialog With {.SelectedPath = __tmp_dir,
														.Description = "Select " & directoryDescription & " slideshow folder." & vbCrLf &
																		"Make sure to select a folder containing at least one subdirectory of images."}
				' Display the Dialog -> Now the user has to set the new dir.
				If FolSel.ShowDialog() = DialogResult.OK Then
					rtnPath = FolSel.SelectedPath
				Else
					GoTo set_default
				End If
				'▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲
				' Set new Folder - End
				'▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲
			End If ' END IF - Messagebox.

			'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
			'							   Check folder content
			'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
checkFolder:
			Try
				LoadRandom(rtnPath)
				Return rtnPath
			Catch ex As Exception
				' @@@@@@@@@@@@@@@@@@@@@@@ Slideshow loading failed @@@@@@@@@@@@@@@@@@@@@@@@@
				If MessageBox.Show(
				   ex.Message & vbCrLf & vbCrLf &
				   "Do you want to choose another folder? " &
				   "If you click ""No"" the default value will be set.",
				   directoryDescription & " slideshow folder empty",
				   MessageBoxButtons.YesNo, MessageBoxIcon.Hand) = DialogResult.Yes Then
					GoTo set_newFolder
				Else
					GoTo set_default
				End If
			End Try
			'▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲
			' Check folder content - End
			'▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲
		Catch ex As Exception
			'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
			'                                            All Errors
			'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
			Throw
		End Try
	End Function

	Shared Function LoadRandom(ByVal baseDirectory As String) As List(Of String)
		If Directory.Exists(baseDirectory) = False Then _
			Throw New DirectoryNotFoundException("The given slideshow base diretory """ & baseDirectory & """ was not found.")

		' Read all subdirectories in base folder.
		Dim subDirs As List(Of String) = myDirectory.GetDirectories(baseDirectory).ToList

nextSubDir:
		' Check if there are folders left.
		If subDirs.Count <= 0 Then _
			Throw New DirectoryNotFoundException("There are no subdirectories conataining images in """ & baseDirectory & """.")

		' Get a random folder in base directory.
		Dim rndFolder As String = subDirs(New Random().Next(0, subDirs.Count))

		' Read all imagefiles in random folder.
		Dim imageFiles As New List(Of String)

		If My.Settings.CBSlideshowSubDir Then
			imageFiles = myDirectory.GetFilesImages(rndFolder, SearchOption.AllDirectories)
		Else
			imageFiles = myDirectory.GetFilesImages(rndFolder, SearchOption.TopDirectoryOnly)
		End If

		If imageFiles.Count <= 0 Then
			' No imagefiles in subdirectory. Remove from list and try next folder
			subDirs.Remove(rndFolder)
			GoTo nextSubDir
		Else
			' Imagefiles found -> Everything fine and done
			Return imageFiles
		End If

	End Function

#Region "My.Settings"

	Shared Function getMySettingsMember(tp As ContactType) As String
		Select Case tp
			Case ContactType.Domme
				Return "DomImageDir"
			Case ContactType.Contact1
				Return "Contact1ImageDir"
			Case ContactType.Contact2
				Return "Contact2ImageDir"
			Case ContactType.Contact3
				Return "Contact3ImageDir"
			Case Else
				Throw New NotImplementedException
		End Select
	End Function

	Shared Function getDefaultFolder(ByVal tp As ContactType) As String
		Return My.Settings.GetDefault(getMySettingsMember(tp))
	End Function

	Shared Function getCurrentBaseFolder(ByVal tp As ContactType) As String
		Return My.Settings(getMySettingsMember(tp))
	End Function

	Shared Sub SetBaseFolder(ByVal tp As ContactType, ByVal path As String)
		My.Settings(getMySettingsMember(tp)) = path
	End Sub

#End Region


	Friend Sub LoadNew()
		Me.ImageList = GetRandom(Me.Contact)
		Me.Index = 0
	End Sub

	Sub CheckInit()
		If Me.Index = -1 And Me.Contact <> ContactType.Nothing Then Me.LoadNew()
	End Sub

#Region "Navigation"

	Friend Function CurrentImage() As String
		If ImageList.Count > 0 And Index > -1 Then
			Return ImageList(Index)
		Else
			Return String.Empty
		End If
	End Function

	Friend Function NavigateFirst() As String
		CheckInit()
		If Me.ImageList.Count > 0 Then
			Index = 0
			Return CurrentImage()
		Else
			Return String.Empty
		End If
	End Function

	Friend Function NavigateForward() As String
		CheckInit()

		If ImageList.Count <= 0 Then
			' No Slideshow loaded
			Index = 0
			Return String.Empty
		ElseIf Index >= ImageList.Count - 1 AndAlso My.Settings.CBNewSlideshow Then
			' End of Slideshow load new one
			LoadNew()
		ElseIf Index >= ImageList.Count - 1 Then
			' End of Slideshow return last image
			Index = ImageList.Count - 1
		Else
			' Get next Image
			Index += 1
		End If

		Return CurrentImage()
	End Function

	Friend Function NavigateNextTease() As String
		CheckInit()

		If My.Settings.CBSlideshowRandom Then
			' get Random Image
			Index = New Random().Next(0, ImageList.Count)
		ElseIf My.Settings.NextImageChance < New Random().Next(0, 101)
			' Randomly backwards
			Index -= 1
			If Index < 0 Then Index = 0
		ElseIf Index >= ImageList.Count - 1 AndAlso My.Settings.CBNewSlideshow Then
			' End of Slideshow start new
			LoadNew()
		ElseIf Index >= ImageList.Count - 1 Then
			' End of Slideshow return last
			Index = ImageList.Count - 1
		Else
			' Next image
			Index += 1
		End If

		Return CurrentImage()
	End Function

	Friend Function NavigateBackward() As String
		CheckInit()

		If ImageList.Count <= 0 Then
			' No Slideshow loaded
			Index = 0
			Return String.Empty
		ElseIf Index <> 0 Then
			' End of Slideshow return first image
			Index -= 1
		Else
			' Get next Image
			Index = 0
		End If

		Return CurrentImage()
	End Function

	Friend Function NavigateLast() As String
		CheckInit()
		If Me.ImageList.Count > 0 Then
			Index = ImageList.Count
			Return CurrentImage()
		Else
			Return String.Empty
		End If
	End Function

#End Region

	Friend Shared Function Check_ImageDir(tp As ContactType)
		Dim def As String = getDefaultFolder(tp)
		Dim val As String = getCurrentBaseFolder(tp)
		Dim text As String = ""

		If tp = ContactType.Domme Then : text = "Domme"
		ElseIf tp = ContactType.Contact1 Then : text = "Contact 1"
		ElseIf tp = ContactType.Contact2 Then : text = "Contact 2"
		ElseIf tp = ContactType.Contact3 Then : text = "Contact 3"
		End If

		val = FolderCheck(text, val, def)

		SetBaseFolder(tp, val)

		If val = def Then
			Return False
		Else
			Return True
		End If
	End Function

	Friend Shared Function GetRandom(tp As ContactType) As List(Of String)
		If Check_ImageDir(tp) Then
			Return LoadRandom(getCurrentBaseFolder(tp))
		Else
			Return New List(Of String)
		End If
	End Function

#Region "Domme"

	Friend Shared Function Check_DommeImageDir()
		Return Check_ImageDir(ContactType.Domme)
	End Function

	Friend Shared Function Get_DommeImages() As List(Of String)
		Return GetRandom(ContactType.Domme)
	End Function

#End Region

#Region "Contact 1"

	Friend Shared Function Check_Contact1ImageDir()
		Return Check_ImageDir(ContactType.Contact1)
	End Function

	Friend Shared Function Get_Contact1Images() As List(Of String)
		Return GetRandom(ContactType.Contact1)
	End Function

#End Region

#Region "Contact 2"

	Friend Shared Function Check_Contact2ImageDir()
		Return Check_ImageDir(ContactType.Contact2)
	End Function

	Friend Shared Function Get_Contact2Images() As List(Of String)
		Return GetRandom(ContactType.Contact2)
	End Function

#End Region

#Region "Contact 3"

	Friend Shared Function Check_Contact3ImageDir()
		Return Check_ImageDir(ContactType.Contact3)
	End Function

	Friend Shared Function Get_Contact3Images() As List(Of String)
		Return GetRandom(ContactType.Contact3)
	End Function

#End Region

End Class
