'===========================================================================================
'
'                                       URL-Files
'
'
'           This file contains all functions to create und maintain URL files.
'
'===========================================================================================
Imports System.ComponentModel
Imports System.IO
Imports System.Net
Imports System.Xml

Namespace URL_Files

	''' <summary>
	''' This Enumeration contains the steps during the working on a URL-File.
	''' </summary>
	Public Enum WorkingStages
		Started = 0
		Dupe_Liste = 10
		Processing = 50
		Blog_Scraping = 60
		''' <summary>
		''' The BGW is waiting for an Userinput, what to to with the Image. If you use a remanent Variable to feeed it don't forget to reset it.
		''' </summary>
		ImageApproval = 70
		Writing_File = 90
		Completed = 100
	End Enum

	''' <summary>
	''' This Enumeration Contains all predefined Functions.
	''' </summary>
	Public Enum Tasks
		''' <summary>
		''' The BGW is free to use, for general usage.
		''' </summary>
		Idle
		''' <summary>
		''' Creates a new URL-File, with UserInteractions.
		''' If it runs <b>not</b> the first time and is not cancelled Dead-URLs will be removed.
		''' </summary>
		CreateURLFile
		''' <summary>
		''' Refreshes all URL-Files and automatically adds new URLs. It will scrape the blog
		''' until a known Url is found. 
		''' </summary>
		RefreshURLFiles
		''' <summary>
		''' Checks all URls in the URL-File-Folder. No new URLs will be added, dead one removed.
		''' If cancelled, all was for nothing...
		''' </summary>
		RebuildURLFiles
	End Enum

	''' <summary>
	''' Enumeration for Image Approval.
	''' </summary>
	Public Enum ImageApprovalStates
		''' <summary>
		''' IF an Image is waiting for Approval, loop till the end of Time or another State. cancellation is Possible in loop.
		''' </summary>
		Pending = 0
		''' <summary>
		''' The actual Image-URL, will be written to URL-File and saved if in <see cref="URL_File_BGW.UserInteractions">Event</see> set.
		''' </summary>
		Approved = 1
		''' <summary>
		''' The actual Image-URL, will be written to Dislike File if set in <see cref="URL_File_BGW.DislikeListPath">Property</see>.
		''' </summary>
		Declined = 2
	End Enum

	''' <summary>
	''' Class that extends the <see cref="BackgroundWorker">Backgroundworker</see> to create and maintain URL-Files.
	''' </summary>
	Public Class URL_File_BGW
		Inherits BackgroundWorker

		Sub New()
			Me.WorkerSupportsCancellation = True
			Me.WorkerReportsProgress = True
		End Sub

#Region "Properties / Members"

#Region "------------------------------------------------- Visible Properties -------------------------------------------------"

		''' <summary>
		''' Stores the Target Directory of the URL-File to Create.
		''' </summary>
		Private _ImageURLFileDir As String = "Images\System\URL Files\"
		''' <summary>
		''' Gets or Sets the Target Directory of the URL-File to Create.
		''' </summary>
		''' <returns>Returns the Target Directory of the URL-File to Create.</returns>
		<System.ComponentModel.Category("Behavior"),
System.ComponentModel.Description("Determines the Target Directory of the URL-File.")>
		Public Property ImageURLFileDir As String
			Get
				Return _ImageURLFileDir
			End Get
			Set(value As String)
				If System.IO.Directory.Exists(value) Or Me.DesignMode = True Then
					_ImageURLFileDir = value
				Else
					Try
						' check if Folder Exists, if Not Create it
						If Not Directory.Exists(Path.GetDirectoryName(value)) Then _
							Directory.CreateDirectory(Path.GetDirectoryName(value))

						_ImageURLFileDir = value
					Catch ex As Exception
						Throw
					End Try
				End If
			End Set
		End Property

		''' <summary>
		''' Stores the Filepath to Dislikelist.
		''' </summary>
		Private _DislikeListPath As String = "Images\System\DislikedImageURLs.txt"
		''' <summary>
		''' Gets or Sets the Filepath To the Dislikelist.
		''' </summary>
		''' <returns>Returns the Filepath to the Dislikelist.</returns>
		<System.ComponentModel.Category("Behavior"),
System.ComponentModel.Description("Gets or Sets the Filepath to the Dislikelist.")>
		Public Property DislikeListPath As String
			Get
				Return _DislikeListPath
			End Get
			Set(value As String)
				If System.IO.File.Exists(value) Or Me.DesignMode = True Then
					_DislikeListPath = value
				Else
					Try
						' check if Folder Exists, if Not Create it
						If Not Directory.Exists(Path.GetDirectoryName(value)) Then _
							Directory.CreateDirectory(Path.GetDirectoryName(value))

						_DislikeListPath = value
					Catch ex As Exception
						Throw
					End Try
				End If
			End Set
		End Property

		''' <summary>
		''' Stores the Filepath to Likelist.
		''' </summary>
		Private _LikeListPath As String = "Images\System\LikedImageURLs.txt"
		''' <summary>
		''' Gets or Sets the Filepath to the Likelist.
		''' </summary>
		''' <returns>Returns the Filepath to the Likelist.</returns>
		<System.ComponentModel.Category("Behavior"),
System.ComponentModel.Description("Gets or Sets the Filepath to the Likelist.")>
		Public Property LikeListPath As String
			Get
				Return _LikeListPath
			End Get
			Set(value As String)
				If System.IO.File.Exists(value) Or Me.DesignMode = True Then
					_LikeListPath = value
				Else
					Try
						' check if Folder Exists, if Not Create it
						If Not Directory.Exists(Path.GetDirectoryName(value)) Then _
							Directory.CreateDirectory(Path.GetDirectoryName(value))

						_LikeListPath = value
					Catch ex As Exception
						Throw
					End Try
				End If
			End Set
		End Property

#End Region

#Region "------------------------------------------------ Internal Variables --------------------------------------------------"

		''' <summary>
		''' Stores the Result of a asynchronous Operation for marshalled use inside the Instance.
		''' </summary>
		Private BGW_Result As RunWorkerCompletedEventArgs = Nothing

		''' <summary>
		''' Stores the Work to do, or actually is running for marshalled use inside the Instance.
		''' </summary>
		Private Work As Tasks = Tasks.Idle

		Private OverallProgress As Integer = 0

		Private OverallProgressTotal As Integer = 0

		Private InfoText As String = String.Empty

		Private ImageCountAdded As Integer = 0

#End Region

#End Region ' Properties / Members

		''' <summary>
		''' Executes the Function needed.
		''' </summary>
		''' <param name="sender"></param>
		''' <param name="e"></param>
		Private Sub Me_DoWork(sender As Object, e As DoWorkEventArgs) Handles MyBase.DoWork
			Try
				Select Case Work
					Case Tasks.CreateURLFile
						e.Result = BlogToUrlFile()
					Case Tasks.RefreshURLFiles, Tasks.RebuildURLFiles
						e.Result = MaintainURLFiles()
				End Select
			Catch ex As Exception
				'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
				'                                            All Errors
				'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
				' Beware: While Debugging this Point VS will moan about an unhandled Exception. This is a known VS Bug.
				e.Cancel = True
				Throw
			End Try
		End Sub

		Private Sub Me_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles Me.RunWorkerCompleted
			Try
				If e.Error IsNot Nothing Then Throw e.Error

				BGW_Result = e
			Catch ex As Exception
				Throw
			End Try
		End Sub

#Region "--------------------------------------- ProgessChanged -----------------------------------------"

		''' <summary>
		''' Returns the actual Backgroundworker-Progress when creating a URL-File.
		''' </summary>
		''' <param name="e">The Object which contains the Data.</param>
		''' <seealso cref="ProgressChangedEventArgs"/>
		''' <remarks>This Event is triggered in the WorkerThread. Make sure to invoke the EventHandler Sub or Func.</remarks>
		Public Shadows Event ProgressChanged(sender As Object, ByRef e As ProgressChangedEventArgs)

		''' <summary>
		''' Delegate to Invoke the URL_FileCreate_ProgressChanged-EventHandler.
		''' </summary>
		''' <param name="sender">The calling Class-Instance.</param>
		''' <param name="e">The Object which contains the Data.</param>
		Public Delegate Sub ProgressChangedDelegate(ByVal Sender As Object, ByRef e As ProgressChangedEventArgs)

		''' <summary>
		''' Class to carry the Data of <see cref="ProgressChangedEventArgs">
		''' URL_FileCreate_ProgressChangedEventArgs</see>/> from WorkerThread to MainTread.
		''' </summary>
		Public Class ProgressChangedEventArgs
			Inherits System.EventArgs

			Public CurrentTask As Tasks = Tasks.Idle
			Public CurrentStage As WorkingStages = WorkingStages.Completed
			Public InfoText As String = Nothing
			Public BlogPage As Integer = 0
			Public BlogPageTotal
			Public ImageCount As Integer = 0
			Public ImageCountTotal As Integer = 0
			Public ImageToReview As Image = Nothing
			Public OverallProgress As Integer = 0
			Public OverallProgressTotal As Integer = 0
		End Class

		''' <summary>
		''' This function raises the <see cref="ProgressChanged">URL_FileCreate_ProgressChanged</see>.
		''' </summary>
		''' <param name="imageCount"></param>
		''' <param name="imageCountTotal"></param>
		''' <param name="currentStage"></param>
		''' <param name="imageToReview"></param>
		Private Shadows Sub OnProgressChanged(ByVal blogPage As Integer,
											  ByVal blogPageTotal As Integer,
											  ByVal imageCount As Integer,
											  ByVal imageCountTotal As Integer,
											  ByVal currentStage As WorkingStages,
											  ByVal imageToReview As Image)
			If currentStage = WorkingStages.Writing_File Then ImageCountAdded += imageCount
			Dim e As New ProgressChangedEventArgs With
				{
				.CurrentTask = Me.Work,
				.CurrentStage = currentStage,
				.InfoText = Me.InfoText,
				.BlogPage = blogPage,
				.BlogPageTotal = blogPageTotal,
				.ImageCount = imageCount,
				.ImageCountTotal = imageCountTotal,
				.OverallProgress = Me.OverallProgress,
				.OverallProgressTotal = Me.OverallProgressTotal,
				.ImageToReview = imageToReview
				}
			' If  Cancel is requested and the actual Stage is Writing File, then say it that way.
			If Me.CancellationPending And currentStage = WorkingStages.Writing_File Then _
		e.InfoText = "Cancel requested: " & vbCrLf & "Writing File " & e.InfoText
			RaiseEvent ProgressChanged(Me, e)
		End Sub

#End Region

#Region "--------------------------------------- User Interactions --------------------------------------"

		''' <summary>
		''' Event to receive Data from the mainprogram while creating a URL-File.
		''' </summary>
		''' <param name="sender">The calling Class-Instance.</param>
		''' <param name="e">The Object which contains the Data.</param>
		''' <remarks>This Event is triggered in the WorkerThread. Make sure to invoke the EventHandler Sub or Func.</remarks>
		Public Event UserInteractions(ByVal sender As Object, ByRef e As EventArgs)

		''' <summary>
		''' Delegate to Invoke the URLCreate_UserInteractions-EventHandler.
		''' </summary>
		''' <param name="sender">The calling Class-Instance.</param>
		''' <param name="e">The Object which contains the Data.</param>
		Public Delegate Sub UserInteractionsDelegate(ByVal sender As Object, ByRef e As EventArgs)

		Public Class UserActions
			Inherits EventArgs
			Public ReviewImages As Boolean
			Public ApproveImage As ImageApprovalStates
			Public SaveImages As Boolean
			Public ImgSaveDir As String
		End Class

		''' <summary>
		''' Raises the <see cref="UserInteractionsDelegate">URL_FileCreate_UserInteractions_Delegate</see>-Event.
		''' </summary>
		''' <returns></returns>
		Private Function OnUserInteractions() As UserActions
			' Raise this Event only, while Creating an URL-File
			Dim e As New UserActions
			If Me.Work <> Tasks.CreateURLFile Then
				' Imitate User ^^
				e.ApproveImage = True
				e.SaveImages = False
				e.ImgSaveDir = ""
				e.ReviewImages = False
			Else
				' Really ask him 
				RaiseEvent UserInteractions(Me, e)
			End If
			Return e
		End Function

		''' <summary>
		''' If the User wants to review every image before adding. 
		''' </summary>
		''' <returns></returns>
		''' <remarks>For internal Use only.</remarks>
		Private ReadOnly Property ReviewImages As Boolean
			Get
				Return OnUserInteractions.ReviewImages
			End Get
		End Property

		''' <summary>
		''' Returns the actual Image Aproval Status, from the Main Programm
		''' </summary>
		''' <returns></returns>
		''' <remarks>For internal Use only.</remarks>
		Private ReadOnly Property ApproveImage As ImageApprovalStates
			Get
				Return OnUserInteractions.ApproveImage
			End Get
		End Property

		''' <summary>
		''' Returns whether the image on the plate should be stored.
		''' </summary>
		''' <returns></returns>
		''' <remarks>For internal Use only.</remarks>
		Private ReadOnly Property SaveImages As Boolean
			Get
				Return OnUserInteractions.SaveImages
			End Get
		End Property

		''' <summary>
		''' Returns the directory to save the images to.
		''' </summary>
		''' <returns></returns>
		''' <remarks>For internal Use only.</remarks>
		Private ReadOnly Property ImageSaveDir As String
			Get
				Return OnUserInteractions.ImgSaveDir
			End Get
		End Property
#End Region

		Public Class CreateUrlFileResult
			Public Cancelled As Boolean = False
			Public ImagesAdded As Integer = 0
			Public ImagesTotal As Integer = 0
			Public Filename As String
			Public _Error As Exception

			Sub New()
			End Sub
		End Class

		Public Class MaintainUrlFilesResult
			''' <summary>
			''' The number of removed/added Links
			''' </summary>
			Public ModifiedLinkCount As Integer = 0
			''' <summary>
			''' The Number of all Processed URLs.
			''' </summary>
			Public LinkCountTotal As Integer = 0
			''' <summary>
			''' The maintained URL-Filenames without extension.
			''' </summary>
			Public MaintainedUrlFiles As New List(Of String)
			''' <summary>
			''' If an Error occurs, while processing an URL-File, the ErrorMessage will added here.
			''' </summary>
			Public ErrorText As New List(Of String)
			Public Cancelled As Boolean = False

			Sub New()
			End Sub
		End Class

		''' <summary>
		''' This Method asks the User for a Blog-URL and Scrapes the Blog asynchronous.
		''' </summary>
		Public Function CreateURLFileAsync() As CreateUrlFileResult
			Try
				Return StartAllWorkAsync(Tasks.CreateURLFile)
			Catch
				Throw
			End Try
		End Function

		''' <summary>
		''' Refreshes all URL-Files and automatically adds new URLs. If not Cancelled, it will remove Dead-URLs.
		''' </summary>
		''' <returns>Returns an Object of <see cref="MaintainUrlFilesResult">MaintainUrlResult</see>/>.</returns>
		Public Function RefreshURLFilesAsync() As MaintainUrlFilesResult
			Try
				Return StartAllWorkAsync(Tasks.RefreshURLFiles)
			Catch
				Throw
			End Try
		End Function

		''' <summary>
		''' Checks all URls in the URL-File-Folder. No new URLs will be added, dead one removed
		''' </summary>
		''' <returns>Returns an Object of <see cref="MaintainUrlFilesResult">MaintainUrlResult</see>/>.</returns>
		Public Function RebuildURLFilesAsync() As MaintainUrlFilesResult
			Try
				Return StartAllWorkAsync(Tasks.RebuildURLFiles)
			Catch
				Throw
			End Try
		End Function

		''' <summary>
		''' Starts the overgiven Work.
		''' </summary>
		''' <param name="workToStart">The task to Start.</param>
		''' <returns></returns>
		Private Function StartAllWorkAsync(ByVal workToStart As Tasks) As Object
			Try
				Me.Work = workToStart
				Me.RunWorkerAsync()

				Do Until Me.IsBusy = False
					Application.DoEvents()
				Loop

				If BGW_Result.Error IsNot Nothing Then Throw BGW_Result.Error
				If BGW_Result.Cancelled = True Then Throw New DivideByZeroException("Action was cancelled.")
				Return BGW_Result.Result
			Catch
				Throw
			Finally
				Me.Work = Tasks.Idle
			End Try
		End Function

		''' <summary>
		''' Creates, refreshes or maintains an URL file for the given URL.
		''' </summary>
		''' <param name="imageBlogUrl">Optional. The URL for Imageblog to scrape from. If empty it will prompt for it.</param>
		''' <remarks>This Function is prepared to use with a Backgroundworker. 
		''' <return>Returns an <see cref="CreateUrlFileResult">CreateUrlFileResult-Object</see>/>.</return>
		''' </remarks>
		Private Function BlogToUrlFile(ByVal Optional imageBlogUrl As String = "") As CreateUrlFileResult
			'===============================================================================
			' Declaration of variables
			'===============================================================================
			Me.OnProgressChanged(0, 0, 0, 0, WorkingStages.Started, Nothing)
			If Me.CancellationPending = True Then Return Nothing

			Dim ImageCountAdded As Integer = 0
			Dim UrlListOld, UrlListNew, DislikeList As New List(Of String)

			' This Var is to Save any occuring Error, to return it to caller.
			Dim ExCache As Exception = Nothing

			If imageBlogUrl = "" Then imageBlogUrl = InputBox("Enter an image blog", "URL File Generator", "http://(Blog Name).tumblr.com/")
			If imageBlogUrl = "" Then Me.CancelAsync() : Return New CreateUrlFileResult With {.Cancelled = True}

			Try
				'===============================================================================
				' Connection Try
				'===============================================================================
				Dim Request As HttpWebRequest
				Dim Response As HttpWebResponse

				Request = WebRequest.Create(imageBlogUrl)
				Request.ReadWriteTimeout = 60000
				Response = Request.GetResponse()
				Request.Abort()

				Request = Nothing
				Response = Nothing
				'===============================================================================
				' Convert URL for local filesystem.
				'===============================================================================
				Dim TargetFileName As String
				TargetFileName = imageBlogUrl
				TargetFileName = TargetFileName.Replace("http://", "")
				TargetFileName = TargetFileName.Replace("https://", "")
				TargetFileName = TargetFileName.Replace("/", "")

				Dim TargetFilePath As String = _ImageURLFileDir & TargetFileName & ".txt"
				'===============================================================================
				' Load liked and disliked image links.
				'===============================================================================
				UrlListOld = ReadFileContent(TargetFilePath)
				DislikeList = ReadFileContent(_DislikeListPath)


				Dim BlogCycle As Integer = 0
				Dim BlogCycleSize As Integer = 50
				Dim TotalPostCount As Integer = -1

				Do
					' >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> Cancel <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
					If Me.CancellationPending AndAlso TotalPostCount = -1 Then Return New CreateUrlFileResult With {.Cancelled = True}
					If Me.CancellationPending Then GoTo ExitScrape

					'===============================================================================
					'								Fetch XML Sitemap
					'===============================================================================
					Dim doc As XmlDocument = New XmlDocument()
					Dim ImageURLs As New List(Of String)

					Dim ReadAPI As String = imageBlogUrl & "/api/read?start=" & BlogCycle & "&num=" & BlogCycleSize
					ReadAPI = ReadAPI.Replace("//api", "/api")

					Request = WebRequest.Create(ReadAPI)
					Response = Request.GetResponse()

					Dim Reader As New XmlTextReader(Response.GetResponseStream)
					doc.Load(Reader)
					Request.Abort()	' Otherwise you cant't run it a seccond time on the same URL that session!
					Response.Close()

					' Get total post count on first run.
					If TotalPostCount = -1 Then
						Me.OnProgressChanged(0, 0, 0, 0, WorkingStages.Blog_Scraping, Nothing)

						For Each node As XmlNode In doc.DocumentElement.SelectNodes("//posts")
							TotalPostCount = CInt(node.Attributes.ItemOf("total").InnerText)
						Next
					Else
						Me.OnProgressChanged(BlogCycle / BlogCycleSize + 1,
							  Math.Ceiling(TotalPostCount / BlogCycleSize),
							  0, ImageURLs.Count,
							  WorkingStages.Blog_Scraping, Nothing)
					End If

					' Read all image urls in given range.
					For Each photoNode As XmlNode In doc.DocumentElement.SelectNodes("//photo-url")
						If CInt(photoNode.Attributes.ItemOf("max-width").InnerText) = 1280 Then
							ImageURLs.Add(photoNode.InnerXml)
						End If
					Next

					Me.OnProgressChanged(BlogCycle / BlogCycleSize + 1,
						  Math.Ceiling(TotalPostCount / BlogCycleSize),
						  0, ImageURLs.Count,
						  WorkingStages.Blog_Scraping, Nothing)


					For i = 0 To ImageURLs.Count - 1
						Dim TempImg As Bitmap = Nothing
						Dim ImageUrl As String = ImageURLs(i)

						Try
							' >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> Cancel <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
							If Me.CancellationPending Then GoTo ExitScrape

							Me.OnProgressChanged(BlogCycle / BlogCycleSize + 1,
								  Math.Ceiling(TotalPostCount / BlogCycleSize),
								  i + 1, ImageURLs.Count,
								  WorkingStages.Processing, Nothing)

							'===============================================================================
							'                         Check what to do with URL
							'===============================================================================
							If DislikeList.Contains(ImageUrl) Or UrlListNew.Contains(ImageUrl) Then
								'############################ ALL - Disliked & Added #############################
								' Always skip disliked and already added URLs.
								GoTo NextImage
							ElseIf Me.Work = Tasks.RebuildURLFiles AndAlso UrlListOld.Contains(ImageUrl) Then
								'########################### URL-Rebuild - Known URL #############################
								' If rebuilding URL-File add only previous known links.
								UrlListNew.Add(ImageUrl)							' Add to new list
								GoTo NextImage										' No Saving or Reviewing    
							ElseIf Me.Work = Tasks.RebuildURLFiles Then
								'########################## URL-Rebuild - Unknown URL ############################
								' If rebuilding URL-File skip previous unkwown URLs.
								GoTo NextImage
							ElseIf Me.Work = Tasks.RefreshURLFiles AndAlso UrlListOld.Contains(ImageUrl) Then
								'############################# Refresh - Known URL ###############################
								' If refreshing URL-File stop scraping at first known URL.
								GoTo ExitScrape
							ElseIf UrlListOld.Contains(ImageUrl) Then
								'############################## Create - Known URL ###############################
								UrlListNew.Add(ImageUrl)							' Add to new list
								GoTo NextImage										' No Saving or Reviewing    
							End If
							'===============================================================================
							'                                 Review Image
							'===============================================================================
							If ReviewImages = True Then
								' Downlaod Image
								TempImg = New Bitmap(New IO.MemoryStream(New WebClient().DownloadData(ImageUrl)))

								' Report to MainApplication, the BGW is waiting for the Image Approval.
								Me.OnProgressChanged(BlogCycle / BlogCycleSize + 1,
									 Math.Ceiling(TotalPostCount / BlogCycleSize),
									 i + 1, ImageURLs.Count,
									 WorkingStages.Processing, TempImg)

								' Wait For User Approval
								Do
									Application.DoEvents()
									' >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> Cancel <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
									If Me.CancellationPending Then GoTo ExitScrape
								Loop Until ApproveImage <> ImageApprovalStates.Pending

								' If Img declined and DislikeFile is set, write URL to DislikeFile
								If ApproveImage = ImageApprovalStates.Declined _
							   And _DislikeListPath <> String.Empty Then
									' Add the URL to DislikeList
									DislikeList.Add(ImageUrl)
									' If DislikeFile exists: Append URL Else create new File
									If File.Exists(_DislikeListPath) Then
										My.Computer.FileSystem.WriteAllText(_DislikeListPath, Environment.NewLine & ImageUrl, True)
									Else
										My.Computer.FileSystem.WriteAllText(_DislikeListPath, ImageUrl, True)
									End If
								End If
							End If

							'===============================================================================
							'                                 Image Approved
							'===============================================================================
							If ApproveImage = ImageApprovalStates.Approved Or ReviewImages = False Then
								' --------------------------SAVE IMAGE TO DISK --------------------------
								If SaveImages = True Then
									Dim TmpImagePath As String = ImageUrl
									Dim TmpDirSplit As String() = TmpImagePath.Split("/")
									TmpImagePath = TmpDirSplit(TmpDirSplit.Length - 1)

									Dim imgDir As String = ImageSaveDir
									If Not File.Exists(imgDir & "\" & TmpImagePath.Replace("\\", "\")) Then
										' Downloaded Picture already for Review?
										If TempImg IsNot Nothing Then
											' YES: Save it from Stream
											TempImg.Save(imgDir & "\" & TmpImagePath.Replace("\\", "\"))
										Else
											' NO: Go download it.
											My.Computer.Network.DownloadFile(ImageUrl, imgDir & "\" & TmpImagePath.Replace("\\", "\"))
										End If
									End If
								End If
								' -------------------------- ADD IMAGE TO LIST --------------------------
								UrlListNew.Add(ImageUrl)
								ImageCountAdded += 1
							End If
						Catch ex As WebException
							'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨ WebException ▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
							' On a Webexception like a 404,410 and stuff like that, goto next image.
							GoTo NextImage
						Catch ex As Exception
							'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
							'						       All Errors
							'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
							' On any other Error, we want to write the data and Exit.
							ExCache = ex
							GoTo ExitScrape
						End Try
NextImage:
						TempImg = Nothing ' Reset Image
					Next

					BlogCycle += BlogCycleSize
				Loop Until BlogCycle >= TotalPostCount

				' Alternate ImageCounting on URL-FileRebuild.
				If Me.Work = Tasks.RebuildURLFiles Then ImageCountAdded = UrlListOld.Count - UrlListNew.Count
ExitScrape:
				Me.OnProgressChanged(100, 100, 0, 0, WorkingStages.Writing_File, Nothing)

				' IF:   Work is Cancelled? Or do we refresh the file? Or did an Error occur?
				' Then: Write a combined copy of  new and old List
				' Else: Write only New List. This removes Dead links.
				Dim UrlListFinal As New List(Of String)
				If Me.CancellationPending = True _
				Or Me.Work = Tasks.RefreshURLFiles _
				Or ExCache IsNot Nothing _
				Then UrlListFinal = UrlListOld.Union(UrlListNew).ToList _
				Else UrlListFinal = UrlListNew
				'===============================================================================
				' Delete old URL-File: Retry delayed 10 times if the File is blocked by use.
				'===============================================================================
				Dim RetryCounter As Integer = 0
RetryDeleteFile:
				Try
					If File.Exists(TargetFilePath) Then My.Computer.FileSystem.DeleteFile(TargetFilePath)
				Catch ex As IO.IOException
					'@@@@@@@@@@@@@@@@@@@@@@@@ IO.Exception @@@@@@@@@@@@@@@@@@@@@@@@
					RetryCounter += 1
					If RetryCounter > 10 Then
						' Wait and try again.
						Threading.Thread.Sleep(500)
						GoTo RetryDeleteFile
					Else
						' Tried enough -> cancel action.
						Throw
					End If
				End Try
				'===============================================================================
				' Write the new URL-File -> Join Lines with Newline together.
				'===============================================================================
				File.WriteAllText(TargetFilePath, String.Join(vbCrLf, UrlListFinal))


				Me.OnProgressChanged(0, 0, 0, 0, WorkingStages.Completed, Nothing)

				Return New CreateUrlFileResult With {.Cancelled = Me.CancellationPending,
				 .Filename = TargetFileName,
				 .ImagesAdded = ImageCountAdded,
				 .ImagesTotal = UrlListFinal.Count,
				 ._Error = ExCache
				 }
			Catch ex As WebException
				'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
				'                                           Webexception
				'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
				' Set Error, to inform user about it.
				ExCache = ex
				' Write data to Disk and Exit.
				GoTo ExitScrape
			Catch ex As Exception
				'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
				'                                            All Errors
				'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
				Throw
			End Try
		End Function

		''' <summary>
		''' Connects to a tumblr blog and reads all available image URLs.
		''' </summary>
		''' <param name="blogURL">The URL of the blog to search.</param>
		''' <returns>Returns a list of all image URLs in given blog or NOTHING/NULL
		''' when a cancelation is pending.</returns>
		Private Function TumblrGetImageURLs(blogURL As String) As List(Of String)

			Dim rtnList As New List(Of String)
			Dim doc As XmlDocument = New XmlDocument()
			Dim req As HttpWebRequest
			Dim res As HttpWebResponse

			Try

				blogURL = blogURL.Replace("/", "")
				blogURL = blogURL.Replace("http:", "http://")
				Debug.Print("ImageBlogURL = " & blogURL)

				Dim BlogCycle As Integer = 0
				Dim BlogCycleSize As Integer = 50
				Dim TotalPostCount As Integer = -1

				Do
					' >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> Cancel <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
					If Me.CancellationPending Then Return Nothing

					req = WebRequest.Create(blogURL & "/api/read?start=" & BlogCycle & "&num=" & BlogCycleSize)
					res = req.GetResponse()

					Dim Reader As New XmlTextReader(res.GetResponseStream)
					doc.Load(Reader)
					req.Abort() ' Otherwise you cant't run it a seccond time on the same URL that session!
					res.Close()

					' Get total post count on first run.
					If TotalPostCount = -1 Then
						For Each node As XmlNode In doc.DocumentElement.SelectNodes("//posts")
							TotalPostCount = CInt(node.Attributes.ItemOf("total").InnerText)
						Next
					End If

					' Read all image urls in given range.
					For Each photoNode As XmlNode In doc.DocumentElement.SelectNodes("//photo-url")
						If CInt(photoNode.Attributes.ItemOf("max-width").InnerText) = 1280 Then
							If rtnList.Contains(photoNode.InnerXml) Then
								Dim t = 0
							End If
							rtnList.Add(photoNode.InnerXml)
						End If
					Next

					BlogCycle += BlogCycleSize
				Loop Until BlogCycle >= TotalPostCount

				Return rtnList

			Catch ex As Exception
				'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
				'						       All Errors
				'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
				Throw
			End Try
		End Function


		Shared Function ReadFileContent(path As String) As List(Of String)
			Try
				Dim rtnList As New List(Of String)

				' Check directory and file existance.
				If IO.Directory.Exists(IO.Path.GetDirectoryName(path)) AndAlso File.Exists(path) Then

					' Read all lines of given file without any blank lines.
					rtnList.AddRange(File.ReadAllLines(path).Where(Function(x)
																	   Return String.IsNullOrWhiteSpace(x) = False
																   End Function))

				End If
				Return rtnList
			Catch ex As Exception
				Throw
			End Try
		End Function

		''' <summary>
		''' Function for Maintaining URL-Files. Basicly it loops through the Folder and gives UI-Feedback.
		''' </summary>
		''' <returns></returns>
		Private Function MaintainURLFiles() As MaintainUrlFilesResult
			Dim RtnResult As New MaintainUrlFilesResult
			With RtnResult
				Try
					Me.OverallProgress = 0
					Me.OverallProgressTotal = 0
					Me.InfoText = String.Empty


					' Get all TxtFiles in specified Folder 
					.MaintainedUrlFiles.AddRange(My.Computer.FileSystem.GetFiles(Me._ImageURLFileDir, FileIO.SearchOption.SearchTopLevelOnly, "*.txt"))

					' Display selection dialog 
					Dim ff As New SelectURLFileDialog(.MaintainedUrlFiles)

					If Not ff.ShowDialog = DialogResult.OK Then
						Me.CancelAsync()
					Else
						Dim NewList As New List(Of String)

						For Each tmpStr As String In .MaintainedUrlFiles
							If ff.SelectedItems.Contains(Path.GetFileName(tmpStr)) Then
								NewList.Add(tmpStr)
							End If
						Next

						.MaintainedUrlFiles.Clear()
						.MaintainedUrlFiles.AddRange(NewList)
					End If

					ff.Dispose()

					For i = 0 To .MaintainedUrlFiles.Count - 1
						' Extract Name and set Infotext, for UI and Debug
						Dim ___tmpFileName As String = Path.GetFileName(.MaintainedUrlFiles(i)).Replace(".txt", "")
						Try
							Me.InfoText = If(Me.Work = Tasks.RefreshURLFiles, "Refreshing: ", "Rebuilding: ") & ___tmpFileName

							Dim tmpresult As CreateUrlFileResult = BlogToUrlFile("http://" & ___tmpFileName)
							'>>>>>>>>>>>>>>>>>>>>>>>> Cancellation <<<<<<<<<<<<<<<<<<<<<<<<<
							If tmpresult.Cancelled = True And tmpresult.Filename = String.Empty Then Exit Try
							' Set the Clear FileName 
							.MaintainedUrlFiles(i) = tmpresult.Filename

							' Set the Values for returning to UI
							Me.OverallProgress = i + 1
							Me.OverallProgressTotal = .MaintainedUrlFiles.Count + 1

							' Calculate Totals
							.ModifiedLinkCount += tmpresult.ImagesAdded
							.LinkCountTotal += tmpresult.ImagesTotal
						Catch ex As Exception When Me.CancellationPending
							'>>>>>>>>>>>>>>>>>>>>>>>> Cancellation <<<<<<<<<<<<<<<<<<<<<<<<<
							' On Cancellation an ArgumentOutOfBla Exc. Occurs.
							If Me.CancellationPending Then Return RtnResult
						Catch ex As Exception
							'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨  All Errors  ▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
							.MaintainedUrlFiles(i) = ___tmpFileName
							RtnResult.ErrorText.Add(String.Format("Error {0} URL-File '{1}': {2}",
																If(Me.Work = Tasks.RefreshURLFiles, "refreshing", "rebuilding"),
																___tmpFileName,
																ex.Message))
						End Try
						'>>>>>>>>>>>>>>>>>>>>>>>> Cancellation <<<<<<<<<<<<<<<<<<<<<<<<<
						If Me.CancellationPending Then Exit For
					Next

					Return RtnResult
				Catch ex As Exception
					'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
					'                                            All Errors
					'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
					Throw
				Finally
					'⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑ Finally ⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑⚑
					If Me.CancellationPending Then
						.Cancelled = True
						.MaintainedUrlFiles.RemoveAll(Function(x) x <> Path.GetFileName(x).Replace(".txt", ""))
						.MaintainedUrlFiles.Capacity = .MaintainedUrlFiles.Count
					End If
				End Try
			End With

		End Function

	End Class

	Class SelectURLFileDialog
		Inherits Form

		Dim lbSel As ListBox
		Dim BtnOk As Button
		Dim BtnCn As Button

		Dim StoredItems As List(Of String)

		Public Property SelectionMode As SelectionMode
			Get
				Return lbSel.SelectionMode
			End Get
			Set(value As SelectionMode)
				lbSel.SelectionMode = value
			End Set
		End Property

		Public ReadOnly Property SelectedItems As ListBox.SelectedObjectCollection
			Get
				SelectedItems = New ListBox.SelectedObjectCollection(lbSel)

				For Each tmpStr As String In StoredItems
					If lbSel.SelectedItems.Contains(Path.GetFileName(tmpStr)) Then
						SelectedItems.Add(tmpStr)
					End If
				Next

			End Get
		End Property

		Sub New(listItems As List(Of String))
			Dim Marg As Integer = 8

			StartPosition = FormStartPosition.CenterParent
			FormBorderStyle = FormBorderStyle.SizableToolWindow
			Size = New Size(350, 400)
			Text = "Select URL files."
			TopMost = True
			Padding = New Padding(8)

			lbSel = New ListBox With
				{
				.SelectionMode = SelectionMode.MultiExtended,
				.Sorted = True,
				.Dock = DockStyle.Top, .Anchor = AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Top Or AnchorStyles.Bottom
				}

			Dim AsBtn As AnchorStyles = AnchorStyles.Right Or AnchorStyles.Bottom

			BtnOk = New Button With {.Text = "OK", .DialogResult = DialogResult.OK, .Anchor = AsBtn}
			BtnCn = New Button With {.Text = "Cancel", .DialogResult = DialogResult.Cancel, .Anchor = AsBtn}

			Controls.AddRange({lbSel, BtnOk, BtnCn})
			BtnOk.Location = New Point(ClientRectangle.Width - BtnOk.Width - BtnCn.Width - Marg * 2,
									   ClientRectangle.Height - BtnOk.Height - Marg)

			BtnCn.Location = New Point(ClientRectangle.Width - BtnCn.Width - Marg,
									   ClientRectangle.Height - BtnCn.Height - Marg)
			lbSel.Size = New Size(ClientRectangle.Width - Marg * 2,
								  ClientRectangle.Height - BtnCn.Height - Marg * 2 - Marg / 2)
			lbSel.Location = New Point(Marg, Marg)

			' Store unedited items, because the listbox displays only the filename.
			StoredItems = listItems

			' Add items and select all.
			For Each TmpStr In listItems
				lbSel.Items.Add(Path.GetFileName(TmpStr))
			Next

			For i = 0 To lbSel.Items.Count - 1
				lbSel.SetSelected(i, True)
			Next

			' Set OK as standard button.
			BtnOk.Select()
		End Sub


	End Class

End Namespace