Imports System.IO
Imports System.Runtime.Serialization
Imports System.Text.RegularExpressions

Public Enum ContactType
	[Nothing]
	Domme
	Contact1
	Contact2
	Contact3
End Enum

<Serializable>
Public Class ContactData

	Public Property Contact As ContactType = ContactType.Nothing

	Public Property ImageFolder As String = ""

	Public Property ImageList As New List(Of String)

	Public Property RecentFolders As New List(Of String)

	Public Property Index As Integer = -1

	Public ReadOnly Property TypeName As String
		Get
			If Contact = ContactType.Contact1 Then
				Return My.Settings.Glitter1
			ElseIf Contact = ContactType.Contact2 Then
				Return My.Settings.Glitter2
			ElseIf Contact = ContactType.Contact3 Then
				Return My.Settings.Glitter3
			Else
				Return My.Settings.DomName
			End If
		End Get
	End Property

	Public ReadOnly Property TypeColorHtml As String
		Get
			If Contact = ContactType.Contact1 Then
				Return Color2Html(My.Settings.GlitterNC1Color)
			ElseIf Contact = ContactType.Contact2 Then
				Return Color2Html(My.Settings.GlitterNC2Color)
			ElseIf Contact = ContactType.Contact3 Then
				Return Color2Html(My.Settings.GlitterNC3Color)
			Else
				Return My.Settings.DomColor
			End If
		End Get
	End Property

	Public ReadOnly Property TypeFont As String
		Get
			Return My.Settings.DomFont
		End Get
	End Property

	Public ReadOnly Property TypeSize As Integer
		Get
			Return My.Settings.DomFontSize
		End Get
	End Property

	Public ReadOnly Property TTSvoice As String
		Get
			Throw New NotImplementedException("Not implemented yet.")
		End Get
	End Property

	Public ReadOnly Property TTSvolume As Integer
		Get
			Return My.Settings.VVolume
		End Get
	End Property

	Public ReadOnly Property TTSrate As Integer
		Get
			Return My.Settings.VRate
		End Get
	End Property

	<NonSerialized> <OptionalField>
	Dim ImageTagCache As New Dictionary(Of String, ImageTagCacheItem)(StringComparison.OrdinalIgnoreCase)

	Sub New()
	End Sub

	Sub New(ByVal type As ContactType)
		Contact = type
		Check_ImageDir(type)
	End Sub

	''' <summary>
	''' Fixes errors caused by missing optional fields after deserialisation.
	''' </summary>
	''' <param name="sc"></param>
	<OnDeserialized>
	Sub OnDeserialized(sc As StreamingContext)
		If ImageTagCache Is Nothing Then ImageTagCache = New Dictionary(Of String, ImageTagCacheItem)(StringComparison.OrdinalIgnoreCase)
	End Sub

	Friend Function Check_ImageDir(tp As ContactType)
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

	Function FolderCheck(ByVal directoryDescription As String,
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
				If Directory.Exists(rtnPath) = False Then _
					Throw New DirectoryNotFoundException("The given slideshow base diretory """ & rtnPath & """ was not found.")

				Dim imgCount As Integer = 0

				For Each folder In myDirectory.GetDirectories(rtnPath).ToList
					If My.Settings.CBSlideshowSubDir Then
						imgCount += myDirectory.GetFilesImages(folder, SearchOption.AllDirectories).Count
					Else
						imgCount += myDirectory.GetFilesImages(folder, SearchOption.TopDirectoryOnly).Count
					End If
					If imgCount > 0 Then Exit For
				Next

				If imgCount <= 0 Then Throw New DirectoryNotFoundException(
					"There are no subdirectories conataining images in """ & rtnPath & """.")

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

	Friend Function GetRandom(tp As ContactType) As List(Of String)
		If Check_ImageDir(tp) Then
			Return LoadRandom(getCurrentBaseFolder(tp))
		Else
			Return New List(Of String)
		End If
	End Function

	Function LoadRandom(ByVal baseDirectory As String) As List(Of String)
		If Directory.Exists(baseDirectory) = False Then _
			Throw New DirectoryNotFoundException("The given slideshow base diretory """ & baseDirectory & """ was not found.")

		' Read all subdirectories in base folder.
		Dim subDirs As List(Of String) = myDirectory.GetDirectories(baseDirectory).ToList
		Dim exclude As New List(Of String)
nextSubDir:
		' Check if there are folders left.
		If subDirs.Count = 0 And exclude.Count > 0 Then
			Dim first As String = RecentFolders(0)
			RecentFolders.Remove(first)
			exclude.Remove(first)
			subDirs.Add(first)
		ElseIf subDirs.Count <= 0 And exclude.Count = 0 Then
			Throw New DirectoryNotFoundException("There are no subdirectories conataining images in """ & baseDirectory & """.")
		End If

		' Get a random folder in base directory.
		Dim rndFolder As String = subDirs(New Random().Next(0, subDirs.Count))

		If RecentFolders.Contains(rndFolder) Then
			exclude.Add(rndFolder)
			subDirs.Remove(rndFolder)
			GoTo nextSubDir
		End If

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
			RecentFolders.Add(rndFolder)
			Return imageFiles
		End If

	End Function

#Region "My.Settings"

	Function getMySettingsMember(tp As ContactType) As String
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

	Function getDefaultFolder(ByVal tp As ContactType) As String
		Return My.Settings.GetDefault(getMySettingsMember(tp))
	End Function

	Function getCurrentBaseFolder(ByVal tp As ContactType) As String
		Return My.Settings(getMySettingsMember(tp))
	End Function

	Sub SetBaseFolder(ByVal tp As ContactType, ByVal path As String)
		My.Settings(getMySettingsMember(tp)) = path
	End Sub

#End Region


	Friend Sub LoadNew()
		Me.ImageList = GetRandom(Me.Contact)
		Me.Index = 0
		ImageTagCache.Clear()
		LastreturnedImage = ""
	End Sub

	Sub CheckInit()
		If Me.Index = -1 And Me.Contact <> ContactType.Nothing Then Me.LoadNew()
		LastreturnedImage = ""
	End Sub

#Region "Navigation"

	<NonSerialized>
	Dim LastreturnedImage As String

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
			Index = ImageList.Count - 1
			Return CurrentImage()
		Else
			Return String.Empty
		End If
	End Function

#Region "Tagged Image"

	''' <summary>Used to cache tagged image results. </summary>
	Private Class ImageTagCacheItem
		Friend TagImageList As New List(Of String)
		Friend LastPicked As String = ""

		Sub New()
		End Sub
	End Class

	''' ========================================================================================================= 
	''' <summary>
	''' Searches for a tagged with the given Tags.
	''' </summary>
	''' <param name="ImageTags">The Tags, to search for.</param>
	''' <returns>Returns a String representing the ImageLocation for the found image. If none was found it will 
	''' return an empty string.</returns>
	Public Function GetTaggedImage(ByVal ImageTags As String, Optional ByVal RememberResult As Boolean = False) As String
		GetTaggedImage = ""
#If TRACE Then
		Dim Ts As New TraceSwitch("GetTaggedImage", "")
		Ts.Level = TraceLevel.Error

		Dim sw As New Stopwatch
		sw.Start()
#End If
		Try
#If TRACE Then
			If Ts.TraceVerbose Then
				Trace.WriteLine("================ GetTaggedImage ================")
				Trace.Indent()
				Trace.WriteLine(String.Format("Get image for Tag ""{0}""", ImageTags))
			ElseIf Ts.Level = TraceLevel.Info Then
				Trace.Write(String.Format("Get image for Tag ""{0}""", ImageTags))
			End If
#End If
			Dim ImagePaths As ImageTagCacheItem = GetImageListByTag(ImageTags)

tryNextImage:
			'===================================================================
			'                         Get nearest Image 
			Dim CurrImgIndex As Integer = ImageList.IndexOf(CurrentImage)
			Dim rtnPath As String = ""
			Dim CurrDist As Integer = 999999

			For Each str As String In ImagePaths.TagImageList
				Dim IndexInList As Integer = ImageList.IndexOf(str)
				' Calculate the distance of ListIndex from the FoundFile to CurrentImage
				Dim FileDist As Integer = IndexInList - CurrImgIndex
				' Convert negative values to positive by multipling (-) x (-) = (+) 
				If FileDist < 0 Then FileDist *= -1
				' Check if the distance is bigger than the previous one
				If FileDist <= CurrDist Then
					' Yes: We will set this file and save its distance
SetForwardImage:
					rtnPath = str
					CurrDist = FileDist
				ElseIf ImagePaths.LastPicked = rtnPath AndAlso New Random().Next(0, 101) > 60 Then
					' The last Picked image is the same as last time.
					GoTo SetForwardImage
				Else
					' As the list is in the Same order as the Slideshow-List,
					' we can stop searching, when the value is getting bigger.
					Exit For
				End If
			Next

			'===================================================================
			'								Check result
			If String.IsNullOrWhiteSpace(rtnPath) Then
				' ############### List was empty ################
				Exit Function
			ElseIf Not File.Exists(rtnPath) Then
				' ############### Image Not found ###############
#If TRACE Then
				If Ts.TraceVerbose Then Trace.WriteLine(String.Format("Image not found - remove from cache: ""{0}""", rtnPath))
#End If
				ImageTagCache(ImageTags).TagImageList.Remove(rtnPath)
				GoTo tryNextImage
			Else
				' ################ image found ##################
#If TRACE Then
				If Ts.TraceVerbose Then Trace.WriteLine("Distance of image = " & CurrDist)
#End If
				If RememberResult Then ImagePaths.LastPicked = rtnPath
				LastreturnedImage = rtnPath
				Return rtnPath

			End If
		Catch ex As Exception
			'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
			'                                            All Errors
			'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
			Log.WriteError("Exception in GetDommeImage()", ex, "")
		Finally
			'⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑ Finally ⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑
#If TRACE Then
			If Ts.TraceVerbose Then
				Trace.WriteLine("Foundimage: " & GetTaggedImage)
				Trace.WriteLine("Duration: " & sw.ElapsedMilliseconds & "ms")
				Trace.Unindent()
			ElseIf Ts.TraceInfo Then
				Trace.WriteLine(String.Format(" - Duration: {0}ms - Result: ""{1}""",
												  sw.ElapsedMilliseconds, GetTaggedImage))
			End If
#End If
		End Try
	End Function

	''' <summary>Returns a list of filepaths for the given tags.</summary>
	''' <param name="ImageTags">The tags to retrieve the list.</param>
	Private Function GetImageListByTag(ByVal ImageTags As String) As ImageTagCacheItem
		Try
#If TRACE Then
			Dim Ts As New TraceSwitch("GetTaggedImage", "")
			Ts.Level = TraceLevel.Verbose
#End If

			Dim TargetFolder As String = Path.GetDirectoryName(CurrentImage) & Path.DirectorySeparatorChar
			Dim TagListFile As String = TargetFolder & "ImageTags.txt"

redo:
			If Not File.Exists(TagListFile) Then
				'===================================================================
				'							No Tag File
				Return New ImageTagCacheItem
			ElseIf ImageTagCache.Keys.Contains(ImageTags) Then
				'===================================================================
				'						Previous cached result

#If TRACE Then
				If Ts.TraceVerbose Then Trace.WriteLine("Loading DommeTags from Cache.")
#End If
				Dim rtnItem As ImageTagCacheItem = ImageTagCache(ImageTags)

				If rtnItem.TagImageList.Count = 0 Then
					' ´############## List was empty ################
					Return New ImageTagCacheItem
				ElseIf Not rtnItem.TagImageList(0).StartsWith(TargetFolder)
					' ################ Wrong folder #################
					ImageTagCache.Remove(ImageTags)
					GoTo redo
				Else
					' ################# All fine ####################
					Return rtnItem
				End If
			Else
				'===================================================================
				'							 Read from File 
#If TRACE Then
				If Ts.TraceVerbose Then Trace.WriteLine("Loading ImageTags from File.")
#End If
				Dim Include As New List(Of String)
				Dim Exclude As New List(Of String)
				Dim PathList As List(Of String) = Txt2List(TagListFile)
				Dim ValidExt As String() = Split(".jpg|.jpeg|.bmp|.png|.gif", "|")

				' Replace case insensitive "not", to safely assign tags to their lists
				ImageTags = Regex.Replace(ImageTags, "\b(not)", "--", RegexOptions.IgnoreCase)

				' Seperate Tags in given string.
				Dim S As String() = ImageTags.Split({",", " "}, StringSplitOptions.RemoveEmptyEntries)

				' Assign tags to lists.
				S.ToList.ForEach(Sub(x)
									 If x.StartsWith("--") Then
										 Exclude.Add(x.Replace("--", ""))
									 Else
										 Include.Add(x)
									 End If
								 End Sub)

				' Filter the List.
				PathList.RemoveAll(Function(x)
									   ' Remove if given include tags are missing
									   For Each tag As String In Include
										   If Not x.Contains(tag) Then Return True
									   Next
									   ' Remove if given exclude tags are present
									   For Each notTag As String In Exclude
										   If x.Contains(notTag) Then Return True
									   Next
									   ' Remove all without valid extension
									   Dim Ext As String = Path.GetExtension(Split(x)(0)).ToLower
									   If Not ValidExt.Contains(Ext) Then Return True
									   'Everything fine keep file
									   Return False
								   End Function)

				'############################### Extract Filepaths ###############################
				' Extract filepaths from list. An empty list doesn't matter here.
				Dim re As New Regex("(?:^.*(?:\.jpg|jpeg|png|bmp|gif)){1}",
									RegexOptions.IgnoreCase Or RegexOptions.Multiline)
				' Get the Matches. Since we can't search a generic list, we join it. 
				Dim mc As MatchCollection = re.Matches(String.Join(vbCrLf, PathList))

				' Write the the ImagePaths back to list.
				PathList.Clear()
				For Each ma As Match In mc
					PathList.Add(TargetFolder & ma.Value)
				Next

				' Add new item to cache and exit.
				GetImageListByTag = New ImageTagCacheItem() With {.TagImageList = PathList}
				ImageTagCache.Add(ImageTags, GetImageListByTag)
				Return GetImageListByTag
			End If
		Catch ex As Exception
			Throw
		End Try
	End Function

#End Region ' Tagged images

#End Region ' Image navigation


	Friend Function ApplyTextedTags(ByVal ModifyString As String) As String
		ApplyTextedTags = ModifyString
		Try
			' ################### Get displayed Image #####################
			Dim DisplayedImage As String

			If String.IsNullOrWhiteSpace(LastreturnedImage) Then
				DisplayedImage = CurrentImage()
			Else
				DisplayedImage = LastreturnedImage
			End If

			' #################### Get line for image #####################
			Dim TagFilePath As String = Path.GetDirectoryName(DisplayedImage) & "\ImageTags.txt"
			Dim FileName As String = Path.GetFileName(DisplayedImage)

			If Not File.Exists(TagFilePath) Then Exit Function

			' Read tagfile and find line for displayed image.
			Dim Line As String = Txt2List(TagFilePath).Find(Function(x) x.StartsWith(FileName, StringComparison.OrdinalIgnoreCase))
			If Line Is Nothing Then Exit Function

			' ################### Create Regex Pattern ####################
			'
			' Named Group <ident> is the identifier for replacement. Joined from StringArray.
			'		TagGarment is used twice. Therefore it searches for "TagGarment" not followed by "Covering".
			'
			' Named group <value> is the value to replace the identifier with. 	Allows all chars except whitespaces.
			Dim Pattern As String = String.Format("(?<ident>{0})(?<value>[^\s]+)",
												  Join({"TagGarment(?!Covering)",
														"TagUnderwear",
														"TagTattoo",
														"TagSexToy",
														"TagFurniture"}, "|"))

			' ################ Find and replace matches ###################
			Dim re As Regex = New Regex(Pattern, RegexOptions.IgnoreCase)
			Dim mc As MatchCollection = re.Matches(Line)

			For Each Tag As Match In mc
				ApplyTextedTags = ApplyTextedTags.Replace("#" & Tag.Groups("ident").Value,
														  Tag.Groups("value").Value.Replace("-", " "))
			Next

			' Replace remaining tag-keywords to mask missing tags.
			ApplyTextedTags = ApplyTextedTags.Replace("#Tag", "")

		Catch ex As Exception
			Log.WriteError(ex.Message, ex, "ApplyTextedTags(String)")
		End Try

	End Function

End Class
