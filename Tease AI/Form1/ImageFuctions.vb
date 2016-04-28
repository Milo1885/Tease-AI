Imports System.IO

Partial Class Form1

#Region "-------------------------------------------------- ImageDataContainer ------------------------------------------------"

	Friend Enum ImageSourceType
		Local
		Remote
	End Enum

	''' <summary>
	''' Represents a Object which can store all necessary Data related to genere-Images
	''' </summary>
	Friend Class ImageDataContainer
		Public Name As String = ""
		Public URLFile As String = ""
		Public LocalDirectory As String = ""
		Public LocalSubDirectories As Boolean = False

		''' <summary>
		''' Returns a List of FilePaths or URLs.
		''' </summary>
		''' <returns>Returns a List Containing all Found Links. If none are 
		''' Found an empty List is returned</returns>
		Public Function ToList() As List(Of String)
			Dim rtnList As New List(Of String)

			rtnList.AddRange(ToList(ImageSourceType.Local))

			rtnList.AddRange(ToList(ImageSourceType.Remote))

			Return rtnList
		End Function


		''' <summary>
		''' Returns a List of FilePaths or URL for the given Type.
		''' </summary>
		''' <param name="Type">The LoationType to Search for.</param>
		''' <returns>Returns a List Containing all Found Links. If none are 
		''' Found an empty List is returned</returns>
		Public Function ToList(ByVal Type As ImageSourceType) As List(Of String)
			Dim rtnList As New List(Of String)

			' Load Local ImageList
			If Type = ImageSourceType.Local AndAlso LocalDirectory <> "" Then
				If LocalSubDirectories = True Then
					rtnList.AddRange(myDirectory.GetFilesImages(LocalDirectory, SearchOption.TopDirectoryOnly))
				Else
					rtnList.AddRange(myDirectory.GetFilesImages(LocalDirectory, SearchOption.AllDirectories))
				End If
			End If

			' Load an URL-File
			If Type = ImageSourceType.Remote AndAlso URLFile <> "" Then
				rtnList.AddRange(Txt2List(URLFile))
			End If

			Return rtnList
		End Function

		''' <summary>
		''' Returns a random Image from all Lists.
		''' </summary>
		''' <returns>Returns a FilePath or URL. If there are no Images found the 
		''' "NoLocalImagesFound-Image-Filepath is returned.</returns>
		Public Function Random() As String
			' Get List of Files
			Dim tmpList As List(Of String) = ToList()

			' Check if Links/Paths are present.
			If tmpList.Count > 0 Then
				' Pick a Random Image-Path
				Return tmpList(New Random().Next(0, tmpList.Count - 1))
			Else
				' Return the Error-Image FilePath
				Return Application.StartupPath & "\Images\System\NoLocalImagesFound.jpg"
			End If
		End Function

		''' <summary>
		''' Returns a random Image for the given ImageGenre.
		''' </summary>
		''' <returns>Returns a FilePath or URL. If there are no Images found the 
		''' "NoLocalImagesFound-Image-Filepath is returned.</returns>
		Public Function Random(ByVal Type As ImageSourceType) As String
			' Get List of Files for Current Type
			Dim tmpList As List(Of String) = ToList(Type)

			' Check if Links/Paths are present.
			If tmpList.Count > 0 Then
				' Pick a Random Image-Path
				Return tmpList(New Random().Next(0, tmpList.Count - 1))
			Else
				' Return an Error-Image FilePath
				If Type = ImageSourceType.Local _
				Then Return Application.StartupPath & "\Images\System\NoLocalImagesFound.jpg" _
				Else Return Application.StartupPath & "\Images\System\NoURLFilesSelected.jpg"
			End If
		End Function
	End Class

#End Region ' ImageDataContainer


	''' <summary>
	''' Gets a dictionary which contains all nessecary data of genere-images.
	''' </summary>
	''' <returns>Returns a dictionary which contains all nessecary data of genere-images.</returns>
	Friend Function GetImageData() As Dictionary(Of String, ImageDataContainer)
		Dim rtnDic As New Dictionary(Of String, ImageDataContainer)(StringComparer.OrdinalIgnoreCase)
		With rtnDic
			.Add("Butt", New ImageDataContainer With
				 {
					.Name = "Butt",
					.LocalDirectory = If(My.Settings.CBIButts, My.Settings.LBLButtPath, ""),
					.LocalSubDirectories = My.Settings.CBButtSubDir,
					.URLFile = If(My.Settings.CBURLButts, My.Settings.LBLButtURL, "")
				})

			.Add("Boobs", New ImageDataContainer With
				 {
					.Name = "Butt",
					.LocalDirectory = If(My.Settings.CBIBoobs, My.Settings.LBLBoobPath, ""),
					.LocalSubDirectories = My.Settings.CBButtSubDir,
					.URLFile = If(My.Settings.CBURLBoobs, My.Settings.LBLBoobURL, "")
				})

			.Add("Hardcore", New ImageDataContainer With
				 {
					.Name = "Hardcore",
					.LocalDirectory = If(My.Settings.CBIHardcore, My.Settings.IHardcore, ""),
					.LocalSubDirectories = My.Settings.CBHardcore,
					.URLFile = If(My.Settings.CBURLHardcore, My.Settings.HardcoreURLFile, "")
				})

			.Add("Softcore", New ImageDataContainer With
				 {
					.Name = "Softcore",
					.LocalDirectory = If(My.Settings.CBISoftcore, My.Settings.ISoftcore, ""),
					.LocalSubDirectories = My.Settings.CBSoftcore,
					.URLFile = If(My.Settings.CBURLSoftcore, My.Settings.SoftcoreURLFile, "")
				})

			.Add("Lesbian", New ImageDataContainer With
				 {
					.Name = "Lesbian",
					.LocalDirectory = If(My.Settings.CBILesbian, My.Settings.ILesbian, ""),
					.LocalSubDirectories = My.Settings.CBLesbian,
					.URLFile = If(My.Settings.CBURLLesbian, My.Settings.LesbianURLFile, "")
				})

			.Add("Blowjob", New ImageDataContainer With
				 {
					.Name = "Blowjob",
					.LocalDirectory = If(My.Settings.CBIBlowjob, My.Settings.IBlowjob, ""),
					.LocalSubDirectories = My.Settings.CBBlowjob,
					.URLFile = If(My.Settings.CBURLBlowjob, My.Settings.BlowjobURLFile, "")
				})

			.Add("Femdom", New ImageDataContainer With
				 {
					.Name = "Femdom",
					.LocalDirectory = If(My.Settings.CBIFemdom, My.Settings.IFemdom, ""),
					.LocalSubDirectories = My.Settings.CBFemdom,
					.URLFile = If(My.Settings.CBURLFemdom, My.Settings.FemdomURLFile, "")
				})

			.Add("Lezdom", New ImageDataContainer With
				 {
					.Name = "Lezdom",
					.LocalDirectory = If(My.Settings.CBILezdom, My.Settings.ILezdom, ""),
					.LocalSubDirectories = My.Settings.ILezdomSD,
					.URLFile = If(My.Settings.CBURLLezdom, My.Settings.LezdomURLFile, "")
				})

			.Add("Hentai", New ImageDataContainer With
				 {
					.Name = "Hentai",
					.LocalDirectory = If(My.Settings.CBIHentai, My.Settings.IHentai, ""),
					.LocalSubDirectories = My.Settings.IHentaiSD,
					.URLFile = If(My.Settings.CBURLHentai, My.Settings.HentaiURLFile, "")
				})

			.Add("Gay", New ImageDataContainer With
				 {
					.Name = "Gay",
					.LocalDirectory = If(My.Settings.CBIGay, My.Settings.IGay, ""),
					.LocalSubDirectories = My.Settings.IGaySD,
					.URLFile = If(My.Settings.CBURLGay, My.Settings.GayURLFile, "")
				})

			.Add("Maledom", New ImageDataContainer With
				 {
					.Name = "Maledom",
					.LocalDirectory = If(My.Settings.CBIMaledom, My.Settings.IMaledom, ""),
					.LocalSubDirectories = My.Settings.IMaledomSD,
					.URLFile = If(My.Settings.CBURLMaledom, My.Settings.MaledomURLFile, "")
				})

			.Add("Captions", New ImageDataContainer With
				 {
					.Name = "Captions",
					.LocalDirectory = If(My.Settings.CBICaptions, My.Settings.ICaptions, ""),
					.LocalSubDirectories = My.Settings.ICaptionsSD,
					.URLFile = If(My.Settings.CBURLCaptions, My.Settings.CaptionsURLFile, "")
				})

			.Add("General", New ImageDataContainer With
				 {
					.Name = "General",
					.LocalDirectory = If(My.Settings.CBIGeneral, My.Settings.IGeneral, ""),
					.LocalSubDirectories = My.Settings.IGeneralSD,
					.URLFile = If(My.Settings.CBURLGeneral, My.Settings.GeneralURLFile, "")
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
		Dim dicFilePaths As Dictionary(Of String, ImageDataContainer) = GetImageData()

		'Count the Genres.
		Dim GenreCount As Integer = dicFilePaths.Keys.Count

		' Check if Genres are present.
		If GenreCount = 0 Then Return Application.StartupPath & "\Images\System\NoLocalImagesFound.jpg"

		' Dertmine a Random ImageGenre.
		Dim RandomGenre As String = dicFilePaths.Keys(New Random().Next(0, GenreCount - 1)).ToString

		' get an Random Image from the Random Genre.
		Return dicFilePaths(RandomGenre).Random()
	End Function

	''' <summary>
	''' Gets a random image URI for given Genre from Local and URL-Files.
	''' </summary>
	''' <param name="genre">Determines the Genre to get a random image for.</param>
	''' <returns>The URI of a random Image.</returns>
	Friend Function GetRandomImage(ByVal genre As String) As String
		' Get all definitions for Images.
		Dim dicFilePaths As Dictionary(Of String, ImageDataContainer) = GetImageData()

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
		Dim dicFilePaths As Dictionary(Of String, ImageDataContainer) = GetImageData()

		'Count the Genres.
		Dim GenreCount As Integer = dicFilePaths.Keys.Count

		' Check if Genres are present.
		If GenreCount = 0 Then GoTo NoNeFound

		' Dertmine a Random ImageGenre.
		Dim RandomGenre As String = dicFilePaths.Keys(New Random().Next(0, GenreCount - 1)).ToString

		' get an Random Image from the Random Genre.
		Return dicFilePaths(RandomGenre).Random(source)
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
	Friend Function GetRandomImage(ByVal genre As String, ByVal source As ImageSourceType) As String
		' Get all definitions for Images.
		Dim dicFilePaths As Dictionary(Of String, ImageDataContainer) = GetImageData()

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


	Public Function BeginImageFetch(ByVal OnlineImage As String) As String
		' 
		Dim ImageToCache As String = ""

		If OnlineImage = "Blog" Then
			Dim tmpList As New List(Of String)

			' Load all checked Items into List.
			tmpList.AddRange(FrmSettings.URLFileList.CheckedItems.Cast(Of String))

			' Remove Items where File does not exist.
			tmpList.RemoveAll(Function(x) Not File.Exists(Application.StartupPath & "\Images\System\URL Files\" & x & ".txt"))
NextUrlFile:
			' Check Result if Files in List
			If tmpList.Count < 1 Then Return ImageToCache

			' Get a random URL-File 
			ImageUrlFilePath = tmpList(randomizer.Next(0, tmpList.Count - 1)) & ".txt"

			' Read the URL-File
			Dim linesGB As List(Of String) = Txt2List(Application.StartupPath & "\Images\System\URL Files\" & ImageUrlFilePath)

			' Check if File is empty... 
			If linesGB.Count = 0 Then
				'... If yes then remove file From List and try again.
				tmpList.Remove(ImageUrlFilePath)
				GoTo NextUrlFile
			End If

			' Get a random Entry 
			Do
				ImageUrlFileIndex = randomizer.Next(0, linesGB.Count - 1)
				FoundString = linesGB(ImageUrlFileIndex)
			Loop Until FoundString <> ""

			' Set image to load
			ImageToCache = FoundString
		Else

			ImageToCache = GetRandomImage(OnlineImage)
		End If

		' Start the Image-Download, with manual Event-triggering.
		If ImageToCache <> "" Then ShowImage(ImageToCache, False)

		Return ImageToCache
	End Function

End Class