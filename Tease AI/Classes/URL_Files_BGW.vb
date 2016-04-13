'===========================================================================================
'
'                                       URL-Files
'
'
'           This File contains all Functions to Create und Maintain URL-Files.
'
' Uses modified and unmodified Code from Tease-AI: https://github.com/Milo1885/Tease-AI.git
'===========================================================================================
Imports System.ComponentModel
Imports System.IO
Imports System.Net
Imports System.Xml

Namespace URL_Files

	''' =========================================================================================================
	''' <summary>
	''' This Enumeration contains the steps during the working on a URL-File.
	''' </summary>
	Public Enum WorkingStages
		Started = 0
		Dupe_Liste = 10
		Scraping = 50
		Blog_Scraping = 60
		''' <summary>
		''' The BGW is waiting for an Userinput, what to to with the Image. If you use a remanent Variable to feeed it don't forget to reset it.
		''' </summary>
		ImageApproval = 70
		Writing_File = 90
		Completed = 100
	End Enum

	''' =========================================================================================================
	''' <summary>
	''' This Enumeration Contains all predefined Functions.
	''' </summary>
	Public Enum URL_File_Tasks
		''' <summary>
		''' The BGW is free to use, for general usage.
		''' </summary>
		Idle
		''' <summary>
		''' Creates a new URL-File, with UserInteractions.
		''' If it runs not the first time and is not cancelled Dead-URLs will be removed
		''' </summary>
		CreateURLFile
		''' <summary>
		''' Refreshes all URL-Files and automatically adds new URLs.
		''' If not Cancelled, it will remove Dead-URLs.
		''' </summary>
		RefreshURLFiles
		''' <summary>
		''' Checks all URls in the URL-File-Folder. No new URLs will be added, dead one removed.
		''' If cancelled, all was for nothing...
		''' </summary>
		RebuildURLFiles
	End Enum

	''' =========================================================================================================
	''' <summary>
	''' Enumeration for Image Approval.
	''' </summary>
	Public Enum ImageApprovalStatus
		''' <summary>
		''' IF an Image is waiting for Approval, loop till the end of Time or another State. cancellation is Possible in loop.
		''' </summary>
		Pending = 0
		''' <summary>
		''' The actual Image-URL, will be written to URL-File and saved if in <see cref="URL_File_BGW.URL_FileCreate_UserInteractions">Event</see> set.
		''' </summary>
		Approved = 1
		''' <summary>
		''' The actual Image-URL, will be written to Dislike File if set in <see cref="URL_File_BGW.DislikeListPath">Property</see>.
		''' </summary>
		Declined = 2
	End Enum

	''' =========================================================================================================
	''' <summary>
	''' Class that extends the <see cref="BackgroundWorker">Backgroundworker</see> to create and maintain URL-Files.
	''' </summary>
	Public Class URL_File_BGW
		Inherits BackgroundWorker

#Region "-----------------------------------------  Inherited from BackgroundWorker -------------------------------------------"

		Sub New()
			Me.WorkerSupportsCancellation = True
			Me.WorkerReportsProgress = True
		End Sub

		''' =========================================================================================================
		''' <summary>
		''' Executes the Function needed.
		''' </summary>
		''' <param name="sender"></param>
		''' <param name="e"></param>
		Private Sub Me_DoWork(sender As Object, e As DoWorkEventArgs) Handles MyBase.DoWork
			Try
				Select Case _Work
					Case URL_File_Tasks.CreateURLFile
						e.Result = BlogToUrlFile()
					Case URL_File_Tasks.RefreshURLFiles, URL_File_Tasks.RebuildURLFiles
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

		Private Sub TAI_Backgroundworker_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles Me.RunWorkerCompleted
			Try
				If e.Error IsNot Nothing Then Throw e.Error

				_BGW_Result = e
			Catch ex As Exception
				Throw
			End Try
		End Sub
#End Region

#Region "------------------------------------------------- Visible Properties -------------------------------------------------"

		''' =========================================================================================================
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
					Throw New DirectoryNotFoundException(String.Format("Can't find the given directory: '{0}'", value))
				End If
			End Set
		End Property

		''' =========================================================================================================
		''' <summary>
		''' Stores the Filepath to Dislikelist.
		''' </summary>
		<System.ComponentModel.Category("Behavior"),
System.ComponentModel.Description("Gets or Sets the Filepath to the Dislikelist.")>
		Private _DislikeListPath As String = "Images\System\DislikedImageURLs.txt"
		''' <summary>
		''' Gets or Sets the Filepath To the Dislikelist.
		''' </summary>
		''' <returns>Returns the Filepath to the Dislikelist.</returns>
		Public Property DislikeListPath As String
			Get
				Return _DislikeListPath
			End Get
			Set(value As String)
				If System.IO.File.Exists(value) Or Me.DesignMode = True Then
					_DislikeListPath = value
				Else
					Throw New DirectoryNotFoundException(String.Format("Can't find the given directory: '{0}'", value))
				End If
			End Set
		End Property
		''' =========================================================================================================
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
					Throw New DirectoryNotFoundException(String.Format("Can't find the given directory: '{0}'", value))
				End If
			End Set
		End Property

#End Region

#Region "------------------------------------------------ Internal Variables --------------------------------------------------"

		''' =========================================================================================================
		''' <summary>
		''' Stores the Result of a asynchronous Operation for marshalled use inside the Instance.
		''' </summary>
		Private _BGW_Result As RunWorkerCompletedEventArgs = Nothing
		''' =========================================================================================================
		''' <summary>
		''' Stores the Work to do, or actually is running for marshalled use inside the Instance.
		''' </summary>
		Private _Work As URL_File_Tasks = URL_File_Tasks.Idle

		Private _OverallProgress As Integer = 0

		Private _OverallProgressTotal As Integer = 0

		Private _InfoText As String = String.Empty

		Private _ImageCountAdded As Integer = 0

#End Region

#Region "--------------------------------------------- URL_File_ProgessChanged ------------------------------------------------"

		''' =========================================================================================================
		''' <summary>
		''' Returns the actual Backgroundworker-Progress when creating a URL-File.
		''' </summary>
		''' <param name="e">The Object which contains the Data.</param>
		''' <seealso cref="URL_File_ProgressChangedEventArgs"/>
		''' <remarks>This Event is triggered in the WorkerThread. Make sure to invoke the EventHandler Sub or Func.</remarks>
		Public Event URL_File_ProgressChanged(Sender As Object, ByRef e As URL_File_ProgressChangedEventArgs)
		''' =========================================================================================================
		''' <summary>
		''' Delegate to Invoke the URL_FileCreate_ProgressChanged-EventHandler.
		''' </summary>
		''' <param name="sender">The calling Class-Instance.</param>
		''' <param name="e">The Object which contains the Data.</param>
		Public Delegate Sub URL_File_ProgressChanged_Delegate(ByVal Sender As Object, ByRef e As URL_File_ProgressChangedEventArgs)
		''' =========================================================================================================
		''' <summary>
		''' Class to carry the Data of <see cref="URL_File_ProgressChangedEventArgs">
		''' URL_FileCreate_ProgressChangedEventArgs</see>/> from WorkerThread to MainTread.
		''' </summary>
		Public Class URL_File_ProgressChangedEventArgs
			Inherits System.EventArgs

			Public CurrentTask As URL_File_Tasks = URL_File_Tasks.Idle
			Public ImageCount As Integer = 0
			Public BlogPage As Integer = 0
			Public BlogPageTotal As Integer = 0
			Public ActStage As WorkingStages = WorkingStages.Completed
			Public ImageToReview As Image = Nothing
			Public OverallProgress As Integer = 0
			Public OverallProgressTotal As Integer = 0
			Public InfoText As String = Nothing
		End Class
		''' =========================================================================================================
		''' <summary>
		''' This function raises the <see cref="URL_File_ProgressChanged">URL_FileCreate_ProgressChanged</see>.
		''' </summary>
		''' <param name="ImageCount"></param>
		''' <param name="BlogPage"></param>
		''' <param name="BlogPageTotal"></param>
		''' <param name="ActStage"></param>
		''' <param name="ImageToReview"></param>
		Private Sub URL_FileCreate_OnProgressChanged(ByVal ImageCount As Integer,
												ByVal BlogPage As Integer,
												ByVal BlogPageTotal As Integer,
												ByVal ActStage As WorkingStages,
												ByVal ImageToReview As Image)
			If ActStage = WorkingStages.Writing_File Then _ImageCountAdded += ImageCount
			Dim e As New URL_File_ProgressChangedEventArgs With
		{
		.CurrentTask = Me._Work,
		.ImageCount = ImageCount,
		.BlogPage = BlogPage,
		.BlogPageTotal = BlogPageTotal,
		.ActStage = ActStage,
		.ImageToReview = ImageToReview,
		.OverallProgress = Me._OverallProgress,
		.OverallProgressTotal = Me._OverallProgressTotal,
		.InfoText = Me._InfoText
		}
			' If  Cancel is requested and the actual Stage is Writing File, then say it that way.
			If Me.CancellationPending And ActStage = WorkingStages.Writing_File Then _
		e.InfoText = "Cancel requested: " & vbCrLf & "Writing File " & e.InfoText
			RaiseEvent URL_File_ProgressChanged(Me, e)
		End Sub

#End Region

#Region "----------------------------------------- URL_FileCreate_UserInteractions --------------------------------------------"

		''' =========================================================================================================
		''' <summary>
		''' Event to receive Data from the mainprogram while creating a URL-File.
		''' </summary>
		''' <param name="sender">The calling Class-Instance.</param>
		''' <param name="e">The Object which contains the Data.</param>
		''' <remarks>This Event is triggered in the WorkerThread. Make sure to invoke the EventHandler Sub or Func.</remarks>
		Public Event URL_FileCreate_UserInteractions(ByVal Sender As URL_File_BGW, ByRef e As UserActions)
		''' =========================================================================================================
		''' <summary>
		''' Delegate to Invoke the URLCreate_UserInteractions-EventHandler.
		''' </summary>
		''' <param name="sender">The calling Class-Instance.</param>
		''' <param name="e">The Object which contains the Data.</param>
		Public Delegate Sub URL_FileCreate_UserInteractions_Delegate(ByVal Sender As URL_File_BGW, ByRef e As URL_File_BGW.UserActions)

		Public Class UserActions
			Public ReviewImages As Boolean
			Public ApproveImage As ImageApprovalStatus
			Public SaveImages As Boolean
			Public ImgSaveDir As String
		End Class

		''' <summary>
		''' Raises the <see cref="URL_FileCreate_UserInteractions_Delegate">URL_FileCreate_UserInteractions_Delegate</see>-Event.
		''' </summary>
		''' <returns></returns>
		Private Function OnURL_FileCreate_UserInteractions() As UserActions
			' Raise this Event only, while Creating an URL-File
			Dim e As New UserActions
			If Me._Work <> URL_File_Tasks.CreateURLFile Then
				' Imitate User ^^
				e.ApproveImage = True
				e.SaveImages = False
				e.ImgSaveDir = ""
				e.ReviewImages = False
			Else
				' Really ask him 
				RaiseEvent URL_FileCreate_UserInteractions(Me, e)
			End If
			Return e
		End Function
		''' =========================================================================================================
		''' <summary>
		''' If the User wants to review every image before adding. 
		''' </summary>
		''' <returns></returns>
		''' <remarks>For internal Use only.</remarks>
		Private ReadOnly Property ReviewImages As Boolean
			Get
				Return OnURL_FileCreate_UserInteractions.ReviewImages
			End Get
		End Property
		''' =========================================================================================================
		''' <summary>
		''' Returns the actual Image Aproval Status, from the Main Programm
		''' </summary>
		''' <returns></returns>
		''' <remarks>For internal Use only.</remarks>
		Private ReadOnly Property ApproveImage As ImageApprovalStatus
			Get
				Return OnURL_FileCreate_UserInteractions.ApproveImage
			End Get
		End Property
		''' =========================================================================================================
		''' <summary>
		''' Returns whether the image on the plate should be stored.
		''' </summary>
		''' <returns></returns>
		''' <remarks>For internal Use only.</remarks>
		Private ReadOnly Property SaveImages As Boolean
			Get
				Return OnURL_FileCreate_UserInteractions.SaveImages
			End Get
		End Property
		''' =========================================================================================================
		''' <summary>
		''' Returns the directory to save the images to.
		''' </summary>
		''' <returns></returns>
		'''     ''' <remarks>For internal Use only.</remarks>
		Private ReadOnly Property ImageSaveDir As String
			Get
				Return OnURL_FileCreate_UserInteractions.ImgSaveDir
			End Get
		End Property
#End Region

#Region "---------------------------------------------------- Create URL Files --------------------------------------------------"

		Public Class CreateUrlFileResult
			Public Cancelled As Boolean = False
			Public ImagesAdded As Integer = 0
			Public ImagesTotal As Integer = 0
			Public Filename As String

			Sub New()
			End Sub
		End Class

		''' =========================================================================================================
		''' <summary>
		''' This Method asks the User for a Blog-URL and Scrapes the Blog asynchronous.
		''' </summary>
		Public Function CreateURLFileAsync() As CreateUrlFileResult
			Try
				Return StartAllWorkAsync(URL_File_Tasks.CreateURLFile)
			Catch
				Throw
			End Try
		End Function

		''' =========================================================================================================
		''' <summary>
		''' This Method Asks the User for a Blog-URL and Scrapes the Blog.
		''' </summary>
		''' <param name="___ImageBlogUrl">Optional. The URL for Imageblog to scrape from. If empty it will prompt for it.</param>
		''' <remarks>This Function is prepared to use with a Backgroundworker. 
		''' <return>Returns an <see cref="CreateUrlFileResult">CreateUrlFileResult-Object</see>/>.</return>
		''' Improvements :
		''' - Fixed all CrossthreadCalls, wich caused the System not to work, with UserInteraction.
		''' - Removed all hard-coded Folder and File Strings.
		''' - Removed redundant Code.
		''' - If you review and downloaded images, the image was downloaded twice.
		''' - The Blog-XML was downloaded with XML-Doc. After you scrapted an URL, you sometimes couldn't scrape it again.
		''' - Deadlinks were imported again.
		''' - Adding an URL to DislikeList was only writing to File, so a disliked URL could get into File, 
		'''   if a Blog Contains it twice.
		''' </remarks>
		Private Function BlogToUrlFile(ByVal Optional ___ImageBlogUrl As String = "") As CreateUrlFileResult
			Try
				'===============================================================================
				' Declaration of Variables
				'===============================================================================
				Me.URL_FileCreate_OnProgressChanged(0, 0, 0, WorkingStages.Started, Nothing)
				If Me.CancellationPending = True Then Return Nothing
				Dim ___ExactPostsCount As Integer = -1 ' If its -1, then the First Pass has not been done
				Dim ___RoundPostsCount As Integer = -1
				Dim ___ImageCountAdded As Integer = 0
				Dim ___ImageCountTotal As Integer = 0
				Dim ___BlogCycle As Integer = 0
				Dim ___BlogCycleSize As Integer = 50

				Dim ___BlogListOld, ___BlogListNew, ___DislikeList As New List(Of String)

				If ___ImageBlogUrl = "" Then ___ImageBlogUrl = InputBox("Enter an image blog", "URL File Generator", "http://(Blog Name).tumblr.com/")
				If ___ImageBlogUrl = "" Then Me.CancelAsync() : Return New CreateUrlFileResult With {.Cancelled = True}

				Dim ___req As HttpWebRequest
				Dim ___res As HttpWebResponse

				Dim ___TempImg As Bitmap = Nothing
				'===============================================================================
				' Connection Try
				'===============================================================================
				___req = WebRequest.Create(___ImageBlogUrl)
				___req.ReadWriteTimeout = 60000
				___res = ___req.GetResponse()
				___req.Abort()
				'===============================================================================
				' Convert URL For Local Filesystem
				'===============================================================================
				Dim ___ModifiedUrl As String
				___ModifiedUrl = ___ImageBlogUrl
				___ModifiedUrl = ___ModifiedUrl.Replace("http://", "")
				___ModifiedUrl = ___ModifiedUrl.Replace("/", "")

				Dim ___ImageURLPath As String = _ImageURLFileDir & ___ModifiedUrl & ".txt"
				'===============================================================================
				' Load the old File if possible, to avoid Duplicate Files
				'===============================================================================
				If File.Exists(___ImageURLPath) Then
					' ReadFile
					Using __UrlFileReader As New StreamReader(___ImageURLPath)
						Try
							While __UrlFileReader.Peek <> -1
								___BlogListOld.Add(__UrlFileReader.ReadLine)
							End While
						Catch
							Throw
						Finally
							__UrlFileReader.Close()
						End Try
					End Using
				End If
				'===============================================================================
				'                           Load Dislike List. 
				'===============================================================================
				If File.Exists(_DislikeListPath) Then
					Using __DislikeFileReader As New StreamReader(_DislikeListPath)
						Try
							While __DislikeFileReader.Peek <> -1
								___DislikeList.Add(__DislikeFileReader.ReadLine())
							End While
						Catch
							Throw
						Finally
							__DislikeFileReader.Close()
						End Try
					End Using
				End If
				'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
				'                         Start Page-Scraping
				'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
Scrape:
				' >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> Cancel <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
				If Me.CancellationPending AndAlso ___ExactPostsCount = -1 Then Return New CreateUrlFileResult With {.Cancelled = True}
				If Me.CancellationPending Then GoTo ExitScrape
				'===============================================================================
				'                      Download Single-XML-Blog-Page
				'===============================================================================
				Dim ___doc As XmlDocument = New XmlDocument()

				___ImageBlogUrl = ___ImageBlogUrl.Replace("/", "")
				___ImageBlogUrl = ___ImageBlogUrl.Replace("http:", "http://")
				Debug.Print("ImageBlogURL = " & ___ImageBlogUrl)

				___req = WebRequest.Create(___ImageBlogUrl & "/api/read?start=" & ___BlogCycle & "&num=50")
				___res = ___req.GetResponse()

				Dim Reader As New XmlTextReader(___res.GetResponseStream)
				___doc.Load(Reader)
				___req.Abort() ' You need to do this, otherwise you cant't run it a seccond time on the same URL that session!
				___res.Close()
				'===============================================================================
				'                         Read Total Blog-Posts
				'===============================================================================
				If ___ExactPostsCount = -1 Then
					Try
						For Each node As XmlNode In ___doc.DocumentElement.SelectNodes("//posts")
							___ExactPostsCount = CInt(node.Attributes.ItemOf("total").InnerText)
							___RoundPostsCount = RoundUpToNearest(___ExactPostsCount, 50)

							Debug.Print("Round-PostsCount = " & ___RoundPostsCount)
						Next
					Catch
						Throw New Exception("Unable to read site api!!")
					End Try
				End If
				'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
				'                             Blog-Loop-Start 
				'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
				For Each ___PhotoNode As XmlNode In ___doc.DocumentElement.SelectNodes("//photo-url")
					Application.DoEvents()
					' >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> Cancel <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
					If Me.CancellationPending Then GoTo ExitScrape
					If CInt(___PhotoNode.Attributes.ItemOf("max-width").InnerText) = 1280 Then

						Me.URL_FileCreate_OnProgressChanged(___ImageCountTotal, ___BlogCycle / ___BlogCycleSize, ___RoundPostsCount / ___BlogCycleSize, WorkingStages.Blog_Scraping, Nothing)
						'===============================================================================
						'                         Check what to do with URL
						'===============================================================================
						If ___DislikeList.Contains(___PhotoNode.InnerXml) Or ___BlogListNew.Contains(___PhotoNode.InnerXml) Then
							'############################ ALL - Disliked & Added #############################
							' Always Skip Disliked Urls and already added URLs.
							GoTo NextImage
						ElseIf Me._Work = URL_File_Tasks.RebuildURLFiles AndAlso ___BlogListOld.Contains(___PhotoNode.InnerXml) Then
							'########################### URL-Rebuild - Known URL #############################
							' If rebuilding URL-File, only add files which were known before.
							___BlogListNew.Add(___PhotoNode.InnerXml)           ' Add to new list
							___ImageCountTotal += 1                             ' Increment Image Counter.
							GoTo NextImage                                      ' No Saving or Reviewing    
						ElseIf Me._Work = URL_File_Tasks.RebuildURLFiles
							'########################## URL-Rebuild - Unknown URL ############################
							' If Rebuilding URL-File skip Urls not previous known.
							GoTo NextImage
						ElseIf ___BlogListOld.Contains(___PhotoNode.InnerXml)
							'########################## Create/Refresh - Known URL ###########################
							___BlogListNew.Add(___PhotoNode.InnerXml)           ' Add to new list
							___ImageCountTotal += 1                             ' Increment Image Counter.
							GoTo NextImage                                      ' No Saving or Reviewing    
						End If
						'===============================================================================
						'                                 Review Image
						'===============================================================================
						If ReviewImages = True Then
							' Downlaod Image
							___TempImg = New Bitmap(New IO.MemoryStream(New WebClient().DownloadData(___PhotoNode.InnerXml)))

							Me.URL_FileCreate_OnProgressChanged(___ImageCountTotal, ___BlogCycle, ___RoundPostsCount, WorkingStages.ImageApproval, ___TempImg)

							' Wait For User Approval
							Do
								Application.DoEvents()
								' >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> Cancel <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
								If Me.CancellationPending Then GoTo ExitScrape
							Loop Until ApproveImage <> ImageApprovalStatus.Pending

							' If Img declined and DislikeFile is set, write URL to DislikeFile
							If ApproveImage = ImageApprovalStatus.Declined _
					And _DislikeListPath <> String.Empty Then
								' Add the URL to DislikeList
								___DislikeList.Add(___PhotoNode.InnerXml)
								' If DislikeFile exists: Append URL Else create new File
								If File.Exists(_DislikeListPath) Then
									My.Computer.FileSystem.WriteAllText(_DislikeListPath, Environment.NewLine & ___PhotoNode.InnerXml, True)
								Else
									My.Computer.FileSystem.WriteAllText(_DislikeListPath, ___PhotoNode.InnerXml, True)
								End If
							End If
						End If

						'===============================================================================
						'                                 Image Approved
						'===============================================================================
						If ApproveImage = ImageApprovalStatus.Approved Or ReviewImages = False Then
							Try
								' --------------------------SAVE IMAGE TO DISK --------------------------
								If SaveImages = True Then
									Dim ___XMLImagePath As String = ___PhotoNode.InnerXml

									Dim ___DirSplit As String() = ___XMLImagePath.Split("/")
									___XMLImagePath = ___DirSplit(___DirSplit.Length - 1)

									Dim imgDir As String = ImageSaveDir
									If Not File.Exists(imgDir & "\" & ___XMLImagePath.Replace("\\", "\")) Then
										' Downloaded Picture already for Review?
										If ___TempImg IsNot Nothing Then
											' YES: Save it from Stream
											___TempImg.Save(imgDir & "\" & ___XMLImagePath.Replace("\\", "\"))
										Else
											' NO: Go download it.
											My.Computer.Network.DownloadFile(___PhotoNode.InnerXml, imgDir & "\" & ___XMLImagePath.Replace("\\", "\"))
										End If
									End If
								End If
								' -------------------------- ADD IMAGE TO LIST --------------------------
								___BlogListNew.Add(___PhotoNode.InnerXml)
								___ImageCountTotal += 1
								___ImageCountAdded += 1
							Catch ex As Exception
								GoTo ExitScrape
							End Try

						End If
NextImage:
					End If
					___TempImg = Nothing ' Reset Image
				Next
				'▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲
				'             Blog-Loop-END 
				'▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲
				___BlogCycle += ___BlogCycleSize
				If ___BlogCycle < ___RoundPostsCount And Not Me.CancellationPending Then GoTo Scrape
				'▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲
				'         Blog-Page-Scraping-END
				'▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲
				' Alternate ImageCounting on URL-FileRebuild.
				If Me._Work = URL_File_Tasks.RebuildURLFiles Then ___ImageCountAdded = ___BlogListOld.Count - ___BlogListNew.Count
ExitScrape:
				Me.URL_FileCreate_OnProgressChanged(___ImageCountTotal, ___BlogCycle / ___BlogCycleSize, ___RoundPostsCount / ___BlogCycleSize, WorkingStages.Writing_File, Nothing)

				' IF:   Work is Cancelled?
				' Then: Write Combined New and Old List
				' Else: Write only New List. This removes Dead links.
				Dim ___BlogListCombine As New List(Of String)
				If Me.CancellationPending = True _
		Then ___BlogListCombine = ___BlogListOld.Union(___BlogListNew).ToList _
		Else ___BlogListCombine = ___BlogListNew
				'===============================================================================
				' Delete old URL-File: Retry delayed 10 times if the File is blocked by use.
				'===============================================================================
				Dim ___retryCounter As Integer = 0
RetryDeleteFile:
				Try
					If File.Exists(___ImageURLPath) Then My.Computer.FileSystem.DeleteFile(___ImageURLPath)
				Catch ex As IO.IOException
					'@@@@@@@@@@@@@@@@@@@@@@@@ IO.Exception @@@@@@@@@@@@@@@@@@@@@@@@
					___retryCounter += 1
					If ___retryCounter > 10 Then
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
				File.WriteAllText(___ImageURLPath, String.Join(vbCrLf, ___BlogListCombine))


				___doc = Nothing
				___req = Nothing
				___res = Nothing

				Me.URL_FileCreate_OnProgressChanged(0, 0, 0, WorkingStages.Completed, Nothing)

				Return New CreateUrlFileResult With {.Cancelled = Me.CancellationPending,
												.Filename = ___ModifiedUrl,
												.ImagesAdded = ___ImageCountAdded,
												.ImagesTotal = ___ImageCountTotal
											}
			Catch ex As Exception
				'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
				'                                            All Errors
				'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
				Throw
			End Try
		End Function

#End Region

#Region "-------------------------------------------------- Maintain URL Files --------------------------------------------------"

		Public Class MaintainUrlResult
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

		''' =========================================================================================================
		''' <summary>
		''' Checks all URls in the URL-File-Folder. No new URLs will be added, dead one removed
		''' </summary>
		''' <returns>Returns an Object of <see cref="MaintainUrlResult">MaintainUrlResult</see>/>.</returns>
		Public Function RebuildURLFilesAsync() As MaintainUrlResult
			Try
				Return StartAllWorkAsync(URL_File_Tasks.RebuildURLFiles)
			Catch
				Throw
			End Try
		End Function

		''' =========================================================================================================
		''' <summary>
		''' Refreshes all URL-Files and automatically adds new URLs. If not Cancelled, it will remove Dead-URLs.
		''' </summary>
		''' <returns>Returns an Object of <see cref="MaintainUrlResult">MaintainUrlResult</see>/>.</returns>
		Public Function RefreshURLFilesAsync() As MaintainUrlResult
			Try
				Return StartAllWorkAsync(URL_File_Tasks.RefreshURLFiles)
			Catch
				Throw
			End Try
		End Function

		''' =========================================================================================================
		''' <summary>
		''' Function for Maintaining URL-Files. Basicly it loops through the Folder and gives UI-Feedback.
		''' </summary>
		''' <returns></returns>
		Private Function MaintainURLFiles() As MaintainUrlResult
			Dim ___rtnResult As New MaintainUrlResult
			With ___rtnResult
				Try
					Me._OverallProgress = 0
					Me._OverallProgressTotal = 0
					Me._InfoText = String.Empty


					' Get all TxtFiles in specified Folder 
					.MaintainedUrlFiles.AddRange(My.Computer.FileSystem.GetFiles(Me._ImageURLFileDir, FileIO.SearchOption.SearchTopLevelOnly, "*.txt"))
					For i = 0 To .MaintainedUrlFiles.Count - 1
						' Extract Name and set Infotext, for UI and Debug
						Dim ___tmpFileName As String = Path.GetFileName(.MaintainedUrlFiles(i)).Replace(".txt", "")
						Try
							Me._InfoText = If(Me._Work = URL_File_Tasks.RefreshURLFiles, "Refreshing: ", "Rebuilding: ") & ___tmpFileName

							Dim tmpresult As CreateUrlFileResult = BlogToUrlFile("http://" & ___tmpFileName)
							'>>>>>>>>>>>>>>>>>>>>>>>> Cancellation <<<<<<<<<<<<<<<<<<<<<<<<<
							If tmpresult.Cancelled = True And tmpresult.Filename = String.Empty Then Exit Try
							' Set the Clear FileName 
							.MaintainedUrlFiles(i) = tmpresult.Filename

							' Set the Values for returning to UI
							Me._OverallProgress = i
							Me._OverallProgressTotal = .MaintainedUrlFiles.Count

							' Calculate Totals
							.ModifiedLinkCount += tmpresult.ImagesAdded
							.LinkCountTotal += tmpresult.ImagesTotal
						Catch ex As Exception When Me.CancellationPending
							'>>>>>>>>>>>>>>>>>>>>>>>> Cancellation <<<<<<<<<<<<<<<<<<<<<<<<<
							' On Cancellation an ArgumentOutOfBla Exc. Occurs.
							If Me.CancellationPending Then Return ___rtnResult
						Catch ex As Exception
							'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨  All Errors  ▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
							.MaintainedUrlFiles(i) = ___tmpFileName
							___rtnResult.ErrorText.Add(String.Format("Error {0} URL-File '{1}': {2}",
																If(Me._Work = URL_File_Tasks.RefreshURLFiles, "refreshing", "rebuilding"),
																___tmpFileName,
																ex.Message))
						End Try
						'>>>>>>>>>>>>>>>>>>>>>>>> Cancellation <<<<<<<<<<<<<<<<<<<<<<<<<
						If Me.CancellationPending Then Exit For
					Next

					Return ___rtnResult
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

#End Region

#Region "-------------------------------------------------- Misc. Functions ---------------------------------------------------"

		''' =========================================================================================================
		''' <summary>
		''' Starts the overgiven Work.
		''' </summary>
		''' <param name="WorkToStart">The task to Start.</param>
		''' <returns></returns>
		Private Function StartAllWorkAsync(ByVal WorkToStart As URL_File_Tasks) As Object
			Try
				Me._Work = WorkToStart
				Me.RunWorkerAsync()

				Do Until Me.IsBusy = False
					Application.DoEvents()
				Loop

				If _BGW_Result.Error IsNot Nothing Then Throw _BGW_Result.Error
				If _BGW_Result.Cancelled = True Then Throw New DivideByZeroException("Action was cancelled.")
				Return _BGW_Result.Result
			Catch
				Throw
			Finally
				Me._Work = URL_File_Tasks.Idle
			End Try
		End Function

		Private Function RoundUpToNearest(Value As Integer, nearest As Integer) As Integer
			Return CInt(Math.Ceiling(Value / nearest) * nearest)
		End Function

#End Region

	End Class

End Namespace