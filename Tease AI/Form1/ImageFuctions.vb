Imports System.IO


Partial Class Form1

#Region "-------------------------------------------------- ImageDataContainer ------------------------------------------------"

    Friend Enum ImageSourceType
		Local
		Remote
	End Enum

	Enum ImageGenre
		Blog
		Butt
		Boobs
		Hardcore
		Softcore
		Lesbian
		Blowjob
		Femdom
		Lezdom
		Hentai
		Gay
		Maledom
		Captions
		General
		Liked
		Disliked
	End Enum

    ''' <summary>
    ''' Represents a Object which can store all necessary Data related to genere-Images. 
    ''' This obejct is intended for managing Images. All Data and conditions can be stored in here
    ''' and retrieved from it.
    ''' </summary>
    Friend Class ImageDataContainer
		'TODO: ImageDataContainer Improve the usage of System Ressources.
		Public Name As ImageGenre
		Public URLFile As String = ""
		Public LocalDirectory As String = ""
		Public LocalSubDirectories As Boolean = False
		Public OfflineMode As Boolean = My.Settings.OfflineMode
		Public SYS_NoPornAllowed As Boolean = False

		Public Function CountImages() As Integer
			Return ToList().Count
		End Function

		Public Function CountImages(ByRef Type As ImageSourceType) As Integer
			Return ToList(Type).Count
		End Function

		''' =========================================================================================================
		''' <summary>
		''' Checks if there are images available for the current Genre.
		''' </summary>
		''' <returns></returns>
		Public Function IsAvailable() As Boolean
			If CountImages() > 0 Then
				Return True
			Else
				Return False
			End If
		End Function

        ''' =========================================================================================================
        ''' <summary>
        ''' Returns a List of FilePaths or URLs.
        ''' </summary>
        ''' <returns>Returns a List Containing all Found Links. If none are 
        ''' Found an empty List is returned</returns>
        Public Function ToList() As List(Of String)
			Dim rtnList As New List(Of String)

			' If no Porn is allowed, then return Empty
			If SYS_NoPornAllowed Then Return rtnList

			rtnList.AddRange(ToList(ImageSourceType.Local))

            ' Load only LocalFiles if Oflline-Mode is acivated.
            If OfflineMode = False Then _
				rtnList.AddRange(ToList(ImageSourceType.Remote))

			Return rtnList
		End Function

		''' =========================================================================================================
		''' <summary>
		''' Returns a List of FilePaths or URLs for the given Type.
		''' </summary>
		''' <param name="Type">The LoationType to Search for.</param>
		''' <returns>Returns a List Containing all Found Links. If none are 
		''' Found an empty List is returned</returns>
		Public Function ToList(ByRef Type As ImageSourceType) As List(Of String)
			Dim rtnList As New List(Of String)

			' If no Porn is allowed, then return Empty
			If SYS_NoPornAllowed Then Return rtnList

			' If offline mode is activated then search only for local files.
			If OfflineMode Then Type = ImageSourceType.Local

			If Name = ImageGenre.Blog Then
				'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
				'                                   Blog Images
				'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
				If OfflineMode Or Type = ImageSourceType.Local Then GoTo exitEmpty
				Dim tmpList As New List(Of String)

				' Load threadsafe all checked Items into List.
				Dim temp As Object = FrmSettings.UIThread(Function()
															  Return FrmSettings.URLFileList.CheckedItems.Cast(Of String).ToList
														  End Function)

				tmpList.AddRange(DirectCast(temp, List(Of String)))

				' Remove Items where File does not exist.
				tmpList.RemoveAll(Function(x) Not File.Exists(Application.StartupPath & "\Images\System\URL Files\" & x & ".txt"))

				' Check Result if Files in List
				If tmpList.Count < 1 Then GoTo exitEmpty

				For Each fileName As String In tmpList
					' Read the URL-File
					Dim addList As List(Of String) = Txt2List(Application.StartupPath & "\Images\System\URL Files\" & fileName & ".txt")

					' add lines from file
					rtnList.AddRange(addList)
				Next
				'▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲
				' Blog Images - End
				'▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲
			ElseIf Name = ImageGenre.Liked
				'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
				'                                  Liked Images
				'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
				Try
					Dim addlist As List(Of String) = Txt2List(Application.StartupPath & "\Images\System\LikedImageURLs.txt")

					' Remove all URLs if Offline-Mode is activated
					If OfflineMode Or Type = ImageSourceType.Local Then
						addlist.RemoveAll(Function(x) isURL(x))
					End If

					rtnList.AddRange(addlist)
				Catch ex As Exception
					Log.WriteError(ex.Message, ex, "Error occured while loading Likelist")
					GoTo exitEmpty
				End Try
				'▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲
				' Liked Images - End
				'▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲
			ElseIf Name = ImageGenre.Disliked
				'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
				'                                Disliked Images
				'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
				Try
					Dim addlist As List(Of String) = Txt2List(Application.StartupPath & "\Images\System\DislikedImageURLs.txt")

					' Remove all URLs if Offline-Mode is activated
					If OfflineMode Or Type = ImageSourceType.Local Then
						addlist.RemoveAll(Function(x) isURL(x))
					End If

					rtnList.AddRange(addlist)
				Catch ex As Exception
					Log.WriteError(ex.Message, ex, "Error occured while loading Dislikelist")
					GoTo exitEmpty
				End Try
				'▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲
				' Disliked Images - End
				'▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲
			Else
				'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
				'                                 Regular Genres
				'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼

				' Load Local ImageList
				If Type = ImageSourceType.Local AndAlso LocalDirectory <> "" AndAlso LocalDirectory IsNot Nothing Then
					If LocalSubDirectories = False Then
						rtnList.AddRange(myDirectory.GetFilesImages(LocalDirectory, SearchOption.TopDirectoryOnly))
					Else
						rtnList.AddRange(myDirectory.GetFilesImages(LocalDirectory, SearchOption.AllDirectories))
					End If
				End If

				' Load an URL-File
				If Type = ImageSourceType.Remote And URLFile <> "" And URLFile IsNot Nothing Then
					rtnList.AddRange(Txt2List(URLFile))
				End If
				'▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲
				' Regular Genres - End
				'▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲
			End If
exitEmpty:
			Return rtnList
		End Function

		''' =========================================================================================================
		''' <summary>
		''' Returns a random Image URL or Path from all Lists and directories.
		''' </summary>
		''' <returns>Returns a FilePath or URL. If there are no Images found the 
		''' "NoLocalImagesFound-Image-Filepath is returned.</returns>
		Public Function Random() As String
			Try
				' Get List of Files
				Dim tmpList As List(Of String) = ToList()

				' Check if Links/Paths are present.
				If tmpList.Count <= 0 Then GoTo NoneFound

				' Pick a Random Image-Path
				Return tmpList(New Random().Next(0, tmpList.Count))
			Catch ex As Exception
				'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
				'						       All Errors
				'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
				Log.WriteError(ex.Message & vbCrLf & ToString(), ex, "Error while choosing a random Image.")
			End Try
NoneFound:
			' Return the Error-Image FilePath
			Return Application.StartupPath & "\Images\System\NoLocalImagesFound.jpg"
		End Function

		''' =========================================================================================================
		''' <summary>
		''' Returns a random Image for the given ImageGenre.
		''' </summary>
		''' <returns>Returns a FilePath or URL. If there are no Images found the 
		''' "NoLocalImagesFound-Image-Filepath is returned.</returns>
		Public Function Random(ByRef Type As ImageSourceType) As String
			Try
				' If offline mode is activated then search only for local files.
				If OfflineMode Then Type = ImageSourceType.Local

				' Get List of Files for Current Type
				Dim tmpList As List(Of String) = ToList(Type)

				' Check if Links/Paths are present.
				If tmpList.Count <= 0 Then GoTo NoneFound

				' Pick a Random Image-Path
				Return tmpList(New Random().Next(0, tmpList.Count))
			Catch ex As Exception
				'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
				'						       All Errors
				'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
				Log.WriteError(ex.Message & vbCrLf & ToString(), ex, "Error while choosing a random Image.")
				'SUGGESTION: 
			End Try
NoneFound:
			' Return an Error-Image FilePath
			If Type = ImageSourceType.Local _
			Then Return Application.StartupPath & "\Images\System\NoLocalImagesFound.jpg" _
			Else Return Application.StartupPath & "\Images\System\NoURLFilesSelected.jpg"
		End Function

		Public Overrides Function ToString() As String
			Return "ImageDataContainer containing:" & vbCrLf &
					"	GenreName: " & Name.ToString & vbCrLf &
					"	URLFile: " & URLFile.ToString & vbCrLf &
					"	LocalDirectory: " & LocalDirectory.ToString & vbCrLf &
					"	LocalSubDirectories: " & LocalSubDirectories.ToString & vbCrLf &
					"	OfflineMode: " & OfflineMode.ToString
			'Return MyBase.ToString()
		End Function

	End Class

#End Region ' ImageDataContainer

	Friend Function GetImageData(genre As ImageGenre) As ImageDataContainer
		Dim tmpObj As Dictionary(Of ImageGenre, ImageDataContainer) = GetImageData()

		Return tmpObj(genre)
	End Function

    ''' =========================================================================================================
    ''' <summary>
    ''' Gets a dictionary which contains all nessecary data of genere-images.
    ''' </summary>
    ''' <returns>Returns a dictionary which contains all nessecary data of genere-images.</returns>
    Friend Function GetImageData() As Dictionary(Of ImageGenre, ImageDataContainer)
		Dim rtnDic As New Dictionary(Of ImageGenre, ImageDataContainer) '(StringComparer.OrdinalIgnoreCase)
		Dim SysNoPornAllowed As Boolean = FlagExists("SYS_NoPornAllowed")
		With rtnDic
			.Add(ImageGenre.Blog, New ImageDataContainer With
				 {
					.Name = ImageGenre.Blog,
					.SYS_NoPornAllowed = SysNoPornAllowed
				 })
			.Add(ImageGenre.Liked, New ImageDataContainer With
				 {
					.Name = ImageGenre.Liked,
					.SYS_NoPornAllowed = SysNoPornAllowed
				 })
			.Add(ImageGenre.Disliked, New ImageDataContainer With
				 {
					.Name = ImageGenre.Disliked,
					.SYS_NoPornAllowed = SysNoPornAllowed
				 })

			.Add(ImageGenre.Butt, New ImageDataContainer With
				 {
					.Name = ImageGenre.Butt,
					.LocalDirectory = If(My.Settings.CBIButts, My.Settings.LBLButtPath, ""),
					.LocalSubDirectories = My.Settings.CBButtSubDir,
					.URLFile = If(My.Settings.CBURLButts, My.Settings.LBLButtURL, ""),
					.SYS_NoPornAllowed = SysNoPornAllowed
				})

			.Add(ImageGenre.Boobs, New ImageDataContainer With
				 {
					.Name = ImageGenre.Boobs,
					.LocalDirectory = If(My.Settings.CBIBoobs, My.Settings.LBLBoobPath, ""),
					.LocalSubDirectories = My.Settings.CBButtSubDir,
					.URLFile = If(My.Settings.CBURLBoobs, My.Settings.LBLBoobURL, ""),
					.SYS_NoPornAllowed = SysNoPornAllowed
				})

			.Add(ImageGenre.Hardcore, New ImageDataContainer With
				 {
					.Name = ImageGenre.Hardcore,
					.LocalDirectory = If(My.Settings.CBIHardcore, My.Settings.IHardcore, ""),
					.LocalSubDirectories = My.Settings.CBHardcore,
					.URLFile = If(My.Settings.CBURLHardcore, My.Settings.HardcoreURLFile, ""),
					.SYS_NoPornAllowed = SysNoPornAllowed
				})

			.Add(ImageGenre.Softcore, New ImageDataContainer With
				 {
					.Name = ImageGenre.Softcore,
					.LocalDirectory = If(My.Settings.CBISoftcore, My.Settings.ISoftcore, ""),
					.LocalSubDirectories = My.Settings.CBSoftcore,
					.URLFile = If(My.Settings.CBURLSoftcore, My.Settings.SoftcoreURLFile, ""),
					.SYS_NoPornAllowed = SysNoPornAllowed
				})

			.Add(ImageGenre.Lesbian, New ImageDataContainer With
				 {
					.Name = ImageGenre.Lesbian,
					.LocalDirectory = If(My.Settings.CBILesbian, My.Settings.ILesbian, ""),
					.LocalSubDirectories = My.Settings.CBLesbian,
					.URLFile = If(My.Settings.CBURLLesbian, My.Settings.LesbianURLFile, ""),
					.SYS_NoPornAllowed = SysNoPornAllowed
				})

			.Add(ImageGenre.Blowjob, New ImageDataContainer With
				 {
					.Name = ImageGenre.Blowjob,
					.LocalDirectory = If(My.Settings.CBIBlowjob, My.Settings.IBlowjob, ""),
					.LocalSubDirectories = My.Settings.CBBlowjob,
					.URLFile = If(My.Settings.CBURLBlowjob, My.Settings.BlowjobURLFile, ""),
					.SYS_NoPornAllowed = SysNoPornAllowed
				})

			.Add(ImageGenre.Femdom, New ImageDataContainer With
				 {
					.Name = ImageGenre.Femdom,
					.LocalDirectory = If(My.Settings.CBIFemdom, My.Settings.IFemdom, ""),
					.LocalSubDirectories = My.Settings.CBFemdom,
					.URLFile = If(My.Settings.CBURLFemdom, My.Settings.FemdomURLFile, ""),
					.SYS_NoPornAllowed = SysNoPornAllowed
				})

			.Add(ImageGenre.Lezdom, New ImageDataContainer With
				 {
					.Name = ImageGenre.Lezdom,
					.LocalDirectory = If(My.Settings.CBILezdom, My.Settings.ILezdom, ""),
					.LocalSubDirectories = My.Settings.ILezdomSD,
					.URLFile = If(My.Settings.CBURLLezdom, My.Settings.LezdomURLFile, ""),
					.SYS_NoPornAllowed = SysNoPornAllowed
				})

			.Add(ImageGenre.Hentai, New ImageDataContainer With
				 {
					.Name = ImageGenre.Hentai,
					.LocalDirectory = If(My.Settings.CBIHentai, My.Settings.IHentai, ""),
					.LocalSubDirectories = My.Settings.IHentaiSD,
					.URLFile = If(My.Settings.CBURLHentai, My.Settings.HentaiURLFile, ""),
					.SYS_NoPornAllowed = SysNoPornAllowed
				})

			.Add(ImageGenre.Gay, New ImageDataContainer With
				 {
					.Name = ImageGenre.Gay,
					.LocalDirectory = If(My.Settings.CBIGay, My.Settings.IGay, ""),
					.LocalSubDirectories = My.Settings.IGaySD,
					.URLFile = If(My.Settings.CBURLGay, My.Settings.GayURLFile, ""),
					.SYS_NoPornAllowed = SysNoPornAllowed
				})

			.Add(ImageGenre.Maledom, New ImageDataContainer With
				 {
					.Name = ImageGenre.Maledom,
					.LocalDirectory = If(My.Settings.CBIMaledom, My.Settings.IMaledom, ""),
					.LocalSubDirectories = My.Settings.IMaledomSD,
					.URLFile = If(My.Settings.CBURLMaledom, My.Settings.MaledomURLFile, ""),
					.SYS_NoPornAllowed = SysNoPornAllowed
				})

			.Add(ImageGenre.Captions, New ImageDataContainer With
				 {
					.Name = ImageGenre.Captions,
					.LocalDirectory = If(My.Settings.CBICaptions, My.Settings.ICaptions, ""),
					.LocalSubDirectories = My.Settings.ICaptionsSD,
					.URLFile = If(My.Settings.CBURLCaptions, My.Settings.CaptionsURLFile, ""),
					.SYS_NoPornAllowed = SysNoPornAllowed
				})

			.Add(ImageGenre.General, New ImageDataContainer With
				 {
					.Name = ImageGenre.General,
					.LocalDirectory = If(My.Settings.CBIGeneral, My.Settings.IGeneral, ""),
					.LocalSubDirectories = My.Settings.IGeneralSD,
					.URLFile = If(My.Settings.CBURLGeneral, My.Settings.GeneralURLFile, ""),
					.SYS_NoPornAllowed = SysNoPornAllowed
				})
		End With

		Return rtnDic
	End Function

#Region "------------------------------------------------- GetRandom Image ----------------------------------------------------"

	''' <summary>
	''' Gets a random image URI from all available Sources
	''' </summary>
	''' <returns>The URI of a random Image.</returns>
	Friend Function GetRandomImage() As String
        ' Get all definitions for Images.
        Dim dicFilePaths As Dictionary(Of ImageGenre, ImageDataContainer) = GetImageData()
		Dim AllImages As New List(Of String)

        ' Fetch all available ImageLocations
        For Each genre As ImageGenre In dicFilePaths.Keys
			AllImages.AddRange(dicFilePaths(genre).ToList())
		Next

        ' Check if there are images
        If AllImages.Count = 0 Then Return Application.StartupPath & "\Images\System\NoLocalImagesFound.jpg"

        ' get an Random Image from the all available Locations
        Return AllImages(New Random().Next(0, AllImages.Count)).ToString
	End Function

    ''' <summary>
    ''' Gets a random image URI for given Genre from Local and URL-Files.
    ''' </summary>
    ''' <param name="genre">Determines the Genre to get a random image for.</param>
    ''' <returns>The URI of a random Image.</returns>
    Friend Function GetRandomImage(ByVal genre As ImageGenre) As String
        ' Get all definitions for Images.
        Dim dicFilePaths As Dictionary(Of ImageGenre, ImageDataContainer) = GetImageData()

        ' get an Random Image from the Random Genre.
        Return dicFilePaths(genre).Random()
	End Function

    ''' <summary>
    ''' Gets a random image URI for the given sourcetype (URL or Local).
    ''' </summary>
    ''' <param name="source">Determines the source to get a random image for.</param>
    ''' <returns>The URI of a random Image.</returns>
    Friend Function GetRandomImage(ByVal source As ImageSourceType) As String
        ' Get all definitions for Images.
        Dim dicFilePaths As Dictionary(Of ImageGenre, ImageDataContainer) = GetImageData()

		Dim allImages As New List(Of String)

        ' Fetch all available ImageLocations for sourceType
        For Each genre As String In dicFilePaths.Keys
			allImages.AddRange(dicFilePaths(genre).ToList(source))
		Next

        ' Check if Genres are present.
        If allImages.Count = 0 Then GoTo NoNeFound

        ' get an Random Image for the given SourceType
        Return allImages(New Random().Next(0, allImages.Count)).ToString
NoNeFound:
		' Return an Error-Image FilePath
		If source = ImageSourceType.Local _
		Then Return Application.StartupPath & "\Images\System\NoLocalImagesFound.jpg" _
		Else Return Application.StartupPath & "\Images\System\NoURLFilesSelected.jpg"
	End Function

    ''' <summary>
    ''' Gets a random image URI for the given genre and sourcetype (URL or Local)..
    ''' </summary>
    ''' <param name="genre">Determines the genre to get a random image for.</param>
    ''' <param name="source">Determines the source to get a random image for.</param>
    ''' <returns>The URI of a random Image.</returns>
    Friend Function GetRandomImage(ByVal genre As ImageGenre, ByVal source As ImageSourceType) As String
        ' Get all definitions for Images.
        Dim dicFilePaths As Dictionary(Of ImageGenre, ImageDataContainer) = GetImageData()

        ' Check if the given Genre is found.
        If dicFilePaths.Keys.Contains(genre) Then
            ' get an Random Image
            Return dicFilePaths(genre).Random(source)
		Else
            ' Return the Error-Image FilePath
            If source = ImageSourceType.Local _
			Then Return Application.StartupPath & "\Images\System\NoLocalImagesFound.jpg" _
			Else Return Application.StartupPath & "\Images\System\NoURLFilesSelected.jpg"
		End If
	End Function

#End Region ' Get Random Image

#Region "---------------------------------------------------- BWimageSync -----------------------------------------------------"

#Region "---------------------------------------------------- Declarations ----------------------------------------------------"

	''' <summary>
	''' Modified Backgroundworker to load and save images on a different thread, with tth possibility to trigger 
	''' the RunWorkerCompleted-Event manually
	''' </summary>
	Private WithEvents BWimageFetcher As New Tease_AI.BackgroundWorkerSyncable

	''' <summary>
	''' Object to pass data to a differnt thread.
	''' </summary>
	Private Class ImageFetchObject
		Public ImageLocation As String = ""

		Public Source As ImageSourceType

		Private _SaveImageDirectory As String = ""

		Public Property SaveImageDirectory As String
			Get
				Return _SaveImageDirectory
			End Get
			Set(value As String)
				If Not value.EndsWith("\") Then
					_SaveImageDirectory = value & "\"
				Else
					_SaveImageDirectory = value

				End If
			End Set
		End Property

		Public FetchedImage As Image = Nothing
	End Class

#End Region ' Declarations


	''' <summary>
	''' Invokes included! This function should be used in a thread.
	''' </summary>
	Private Sub BWimageFetcher_DoWork(ByVal sender As Object,
							 ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BWimageFetcher.DoWork

		If TypeOf e.Argument Is ImageFetchObject Then
			Dim FetchContainer As ImageFetchObject = e.Argument
			Try
				With FetchContainer
					If .ImageLocation.Contains("/") And .ImageLocation.Contains("://") Then
                        ' ###################### Online Image #########################
                        .Source = ImageSourceType.Remote
                        ' Download the image
                        .FetchedImage = New Bitmap(New IO.MemoryStream(New System.Net.WebClient().DownloadData(.ImageLocation)))
						'check if Folder is set and exists.
						If .SaveImageDirectory <> "" _
					AndAlso Directory.Exists(.SaveImageDirectory) Then
							'Check if the destination Filename exists.
							If Not File.Exists(.SaveImageDirectory & Path.GetFileName(.ImageLocation)) Then
								.FetchedImage.Save(.SaveImageDirectory & Path.GetFileName(.ImageLocation))
							End If
						End If
					Else
                        ' ####################### Local Image #########################
                        .Source = ImageSourceType.Local
						.FetchedImage = Image.FromFile(.ImageLocation)
					End If
				End With
			Catch ex As Exception
				' Do nothing, Just for Debug.
				Throw
			End Try
			' Return the fetched data to the UI-Thread
			e.Result = FetchContainer
		End If
		Debug.Print("ImageFetch - DoWork - Done")
	End Sub

	Private Sub BWimageFetcher_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BWimageFetcher.RunWorkerCompleted
		If TypeOf e.Error Is TimeoutException Then Debug.Print(e.Error.Message)
		If e.Error IsNot Nothing Then Exit Sub

		If e.Cancelled Then Exit Sub

		If TypeOf e.Result Is ImageFetchObject Then
			Dim FetchResult As ImageFetchObject = e.Result
			Dim OldImage As Image = mainPictureBox.Image
			Dim NewImage As Bitmap = FetchResult.FetchedImage.Clone

			mainPictureBox.Image = NewImage
			mainPictureBox.Invalidate()
			mainPictureBox.Refresh()

			PBImage = FetchResult.ImageLocation
			ImageLocation = FetchResult.ImageLocation
			LBLImageInfo.Text = FetchResult.ImageLocation

			If OldImage IsNot Nothing Then
				OldImage.Dispose()
			End If
			GC.Collect()
			CheckDommeTags()

			If FetchResult.Source = ImageSourceType.Local Then
				Debug.Print("Local Image PictureStrip")

				If _ImageFileNames.Contains(FetchResult.ImageLocation) Then _
					DeleteLocalImageFilePath = FetchResult.ImageLocation

				CurrentImage = FetchResult.ImageLocation

                'CopyImageLocation
                ToolStripMenuItem5.Enabled = True

                'Save Image
                ToolStripMenuItem1.Enabled = False

				SaveImageToToolStripMenuItem.Enabled = False

                'Like Image
                ToolStripMenuItem2.Enabled = False
                'DislikeImage
                ToolStripMenuItem3.Enabled = False
                'Remove from URLFile
                ToolStripMenuItem4.Enabled = False

			Else
				Debug.Print("Blog Image PictureStrip")
				CurrentImage = FoundString

                'CopyImageLocation
                ToolStripMenuItem5.Enabled = True

                'Save Image
                ToolStripMenuItem1.Enabled = True

				SaveImageToToolStripMenuItem.Enabled = True

                'Like Image
                ToolStripMenuItem2.Enabled = True
                'DislikeImage
                ToolStripMenuItem3.Enabled = True
                'Remove from URLFile
                ToolStripMenuItem4.Enabled = True

			End If

			Debug.Print("ImageFetch - RunWorkerCompleted - Done" & vbCrLf &
						"	ImageLocation: " & FetchResult.ImageLocation)
		End If
	End Sub

#End Region ' BWimageSync

	Public Sub ShowImage(ByVal ImageToShow As String, ByVal WaitToFinish As Boolean)
		If FormLoading = True Then Return

		Debug.Print(
				"    _____                                  ______     _         _      " & vbCrLf &
				"   |_   _|                                |  ____|   | |       | |     " & vbCrLf &
				"     | |   _ __ ___    __ _   __ _   ___  | |__  ___ | |_  ___ | |__   " & vbCrLf &
				"     | |  | '_ ` _ \  / _` | / _` | / _ \ |  __|/ _ \| __|/ __|| '_ \  " & vbCrLf &
				"    _| |_ | | | | | || (_| || (_| ||  __/ | |  |  __/| |_| (__ | | | | " & vbCrLf &
				"   |_____||_| |_| |_| \__,_| \__, | \___| |_|   \___| \__|\___||_| |_| " & vbCrLf &
				"                              __/ |                                    " & vbCrLf &
				"                             |___/                                     " & vbCrLf &
				" ImageLocation: " & ImageToShow & vbCrLf &
				" WaitToFinish:  " & WaitToFinish)
		If BWimageFetcher.isBusy Then BWimageFetcher.CancelTrigger()

		Dim FetchContainer As New ImageFetchObject
		FetchContainer.ImageLocation = ImageToShow

		If FrmSettings.CBBlogImageWindow.Checked = True _
		Then FetchContainer.SaveImageDirectory = Application.StartupPath & "\Images\Session Images\" _
		Else FetchContainer.SaveImageDirectory = ""

		BWimageFetcher.RunWorkerAsync(FetchContainer, True)


		If WaitToFinish Then BWimageFetcher.WaitToFinish()

	End Sub


    ''' <summary>
    ''' Starts to Download an Image on Background. Make sure, to tell the Backgroundworker, 
    ''' when you finished your work and waiting for him to complete.
    ''' </summary>
    ''' <param name="genre"></param>
    ''' <returns></returns>
    Public Function BeginImageFetch(ByVal genre As ImageGenre) As String


		Dim ImageToCache As String = GetRandomImage(genre)

        ' Start the Image-Download, with manual Event-triggering.
        If ImageToCache <> "" And ImageToCache IsNot Nothing _
		Then ShowImage(ImageToCache, False)

		Return ImageToCache
	End Function

End Class