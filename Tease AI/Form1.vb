
Imports System.IO
Imports System.Text
Imports System.Threading
Imports System.Runtime.InteropServices
Imports System.Speech.Synthesis
Imports System.Speech.AudioFormat
Imports System.Drawing.Drawing2D
Imports System.Text.RegularExpressions
Imports System.Xml.Serialization
Imports System.Xml


Public Class Form1
#Region "-------------------------------------- File Constants ------------------------------------------"
	Friend Shared ReadOnly pathLikeList As String = Application.StartupPath & "\Images\System\LikedImageURLs.txt"
	Friend Shared ReadOnly pathDislikeList As String = Application.StartupPath & "\Images\System\DislikedImageURLs.txt"
	Friend Shared ReadOnly pathImageTagList As String = Application.StartupPath & "\Images\System\LocalImageTags.txt"
	''' <summary>
	''' The default directory URL-Files are located.
	''' </summary>
	Friend Shared ReadOnly pathUrlFileDir As String = Application.StartupPath & "\Images\System\URL Files\"

	Friend Shared ReadOnly pathImageErrorOnLoading As String = Application.StartupPath & "\Images\System\ErrorLoadingImage.jpg"
#End Region ' File Constants.


	''' <summary>
	''' Shorthand Property to access My.Application.Session
	''' </summary>
	''' <returns></returns>
	Public Property ssh As My.SessionState
		Get
			Return My.Application.Session
		End Get
		Set(value As My.SessionState)
			My.Application.Session = value
		End Set
	End Property

	Public Property ssh_Chat As String
		Get
			Return ssh.Chat
		End Get
		Set(value As String)
			ssh.Chat = value
		End Set
	End Property

	Public ssh_randomizer As New Random
	Public ssh_ScriptOperator As String
	<Obsolete("Only used in Supend/resmue. Don not use anymore")>
	Public ssh_ScriptCompare As String

	Public ssh_DomTyping As Boolean

	Dim ssh_CheckYes As Boolean
	Dim ssh_CheckNo As Boolean

	Public ssh_Playlist As Boolean
	Public ssh_PlaylistFile As New List(Of String)
	Public ssh_PlaylistCurrent As Integer

	' Github Patch  Public FormLoading As Boolean
	Public FormLoading As Boolean = True

	Dim ssh_Responding As Boolean

	Public ssh_StrokeTauntVal As Integer
	Public ssh_FileText As String
	Public ssh_TempStrokeTauntVal As Integer
	Public ssh_TempFileText As String

	Public ssh_TeaseTick As Integer

	Dim ssh_StrokeTauntCount As Integer
	Dim ssh_TauntTextTotal As Integer
	Dim ssh_TauntLines As New List(Of String)
	Dim ssh_StrokeFilter As Boolean

	Public ssh_ScriptTick As Integer
	Dim ssh_StringLength As Integer
	Public ssh_FileGoto As String
	Public ssh_SkipGotoLine As Boolean

	Dim ssh_ChatString As String
	Public ssh_DomTask As String
	Public ssh_DomChat As String
	Dim ssh_TypeDelay As Integer
	Dim ssh_TempVal As Integer
	Dim ssh_NullResponse As Boolean

	Public ssh_TagCount As Integer
	Public ssh_LocalTagCount As Integer

	Dim ssh_TaskFile As String
	Dim ssh_TaskText As String
	Dim ssh_TaskTextDir As String


	Dim ssh_ResponseFile As String
	Dim ssh_ResponseLine As Integer

	Dim ssh_CBTCockActive As Boolean
	Dim ssh_CBTBallsActive As Boolean

	Dim ssh_CBTCockFlag As Boolean
	Dim ssh_CBTBallsFlag As Boolean

	Dim ssh_CBTBallsFirst As Boolean
	Dim ssh_CBTCockFirst As Boolean

	Dim ssh_CBTBallsCount As Integer
	Dim ssh_CBTCockCount As Integer

	Dim ssh_TasksCount As Integer = "0"

	Dim ssh_GotoDommeLevel As Boolean

	Dim ssh_DommeMood As Integer

	Public ssh_AFK As Boolean


	Public ssh_HypnoGen As Boolean
	Public ssh_Induction As Boolean
	Public ssh_TempHypno As String

	Public ssh_StrokeTick As Integer
	Public ssh_StrokeTauntTick As Integer

#Region "-------------------------------------- StrokePace ----------------------------------------------"
	''' <summary>
	''' Synclock Object to prevent datacorruption of <see cref="_StrokePaceMetronomeUnsynced"/>.
	''' <para>As long as this lock is hold, the metronome thread is blocked!</para>
	''' </summary>
	Private _StrokePaceMetronomeSyncLock As New Object
	''' <summary>
	'''	Stores the value of the current strokePace. 
	''' <para>Synchronized MultiThread-Object!</para>
	''' <para> Use <see cref="StrokePace"/> instead.</para>
	''' </summary>
	Private _StrokePaceMetronomeUnsynced As Integer
	''' <summary>
	''' Gets the strokepace ThreadSafe. 
	''' This property is restricted to Metronome-Thread.
	''' </summary>
	''' <returns>The current StrokePace.</returns>
	Private ReadOnly Property StrokePaceMetronome As Integer
		Get
			If Thread.CurrentThread IsNot MetroThread Then _
				Throw New AccessViolationException("Reading StrokePaceMetronome is restricted to MetronomeThread.")

			SyncLock _StrokePaceMetronomeSyncLock
				Dim tmpInt As Integer = _StrokePaceMetronomeUnsynced
				Return tmpInt
			End SyncLock
		End Get
	End Property

	''' <summary>
	''' Synclock Object to prevent datacorruption of <see cref="ssh__StrokePaceUnsynced"/>.
	''' </summary>
	Private _StrokePaceSyncLock As New Object
	''' <summary>
	'''	Stores the value of the current strokePace
	''' <para>Synchronized MultiThread-Object!</para>
	''' <para> Use <see cref="StrokePace"/> instead.</para>
	''' </summary>
	Private ssh__StrokePaceUnsynced As Integer
	''' <summary>
	''' Gets or sets the strokepace.
	''' Changing this Value will  delay the MetronomeThread, until all 
	''' registers are written into the RAM.
	''' </summary>
	''' <returns>The current StrokePace.</returns>
	Private Property StrokePace As Integer
		Get
			Return ssh__StrokePaceUnsynced
		End Get
		Set(value As Integer)
			If value <> ssh__StrokePaceUnsynced Then
				SyncLock _StrokePaceSyncLock
					ssh__StrokePaceUnsynced = value
				End SyncLock
				SyncLock _StrokePaceMetronomeSyncLock
					_StrokePaceMetronomeUnsynced = value
				End SyncLock
			End If
		End Set
	End Property

#End Region ' StrokePace



	Dim ssh_StrokeTimeTotal As Integer
	Dim ssh_HoldEdgeTime As Integer
	Dim ssh_HoldEdgeTimeTotal As Integer

	Public ssh_EdgeTauntInt As Integer

	Dim ssh_DelayTick As Integer

	Public ssh_DomTypeCheck As Boolean
	Dim ssh_TypeToggle As Boolean
	Dim ssh_IsTyping As Boolean
	Dim ssh_SubWroteLast As Boolean
	Dim ssh_YesOrNo As Boolean
	Dim ssh_GotoFlag As Boolean

	Dim ssh_CBT As Boolean

	Dim ssh_RunningScript As Boolean

	Public ssh_BeforeTease As Boolean
	Public ssh_SubStroking As Boolean
	Dim ssh_SubEdging As Boolean
	Dim ssh_SubHoldingEdge As Boolean
	Dim ssh_EndTease As Boolean

	Public ssh_ShowModule As Boolean
	Dim ssh_ModuleEnd As Boolean

	Dim ssh_DivideText As Boolean

	Public ssh_HoldEdgeTick As Integer
	Dim ssh_HoldEdgeChance As Integer

	Dim ssh_EdgeHold As Boolean
	Dim ssh_EdgeNoHold As Boolean
	Dim ssh_EdgeToRuin As Boolean
	Dim ssh_EdgeToRuinSecret As Boolean
	Dim ssh_LongEdge As Boolean

	Dim ssh_AskedToGiveUp As Boolean
	Dim ssh_AskedToGiveUpSection As Boolean
	Dim ssh_SubGaveUp As Boolean
	Dim ssh_AskedToSpeedUp As Boolean
	Dim ssh_AskedToSlowDown As Boolean

	<Obsolete("Only used in Supend/Resume")>
	Dim ThoughtEnd As Boolean

	Dim ssh_VTLength As Integer

	Dim ssh_DommeVideo As Boolean
	Dim ssh_VideoType As String
	Public ssh_CensorshipGame As Boolean
	Public ssh_CensorshipTick As Integer
	Dim ssh_CensorDuration As String
	Public ssh_AvoidTheEdgeGame As Boolean
	Public ssh_AvoidTheEdgeTick As Integer
	Dim ssh_AvoidTheEdgeTimerTick As Integer
	Dim ssh_AvoidTheEdgeDuration As String
	Public ssh_AvoidTheEdgeStroking As Boolean
	Dim ssh_AtECountdown As Integer

	Public ssh_VTPath As String
	Public ssh_NoVideo As Boolean
	Public ssh_NoSpecialVideo As Boolean
	Public ssh_VideoCheck As Boolean
	Public ssh_VideoTease As Boolean

	Public ssh_RLGLGame As Boolean
	Dim ssh_RLGLStroking As Boolean
	Public ssh_RLGLTick As Integer
	Dim ssh_RedLight As Boolean
	Dim ssh_RLGLTauntTick As Integer

	Public ssh_RandomizerVideo As Boolean
	Public ssh_RandomizerVideoTease As Boolean

	Public ssh_ScriptVideoTease As String
	Public ssh_ScriptVideoTeaseFlag As Boolean

	Dim ssh_VideoTauntTick As Integer


	Public ssh_SlideshowLoaded As Boolean
	<Obsolete("Only used in Supend/resume")>
	Dim GlitterImageAV As String = Application.StartupPath & "\Images\Glitter\01.jpg"
	<Obsolete("Only used in Supend/resume")>
	Dim GlitterTempColor As String

	Public ssh_UpdatesTick As Integer
	Dim ssh_UpdatingPost As Boolean
	Dim ssh_UpdateStage As Integer
	Dim ssh_UpdateStageTick As Integer
	Public ssh_StatusText As String
	Dim ssh_ContactNumber As Integer
	Dim ssh_ContactTick As Integer

	<Obsolete("Only used in Supend/resume. Only once set to false")>
	Dim ContactFlag As Boolean
	Dim ssh_StatusText1 As String
	Dim ssh_StatusText2 As String
	Dim ssh_StatusText3 As String

	Dim ssh_StatusChance1 As Integer
	Dim ssh_StatusChance2 As Integer
	Dim ssh_StatusChance3 As Integer

	Dim ssh_Update1 As Boolean
	Dim ssh_Update2 As Boolean
	Dim ssh_Update3 As Boolean

	Dim ssh_GetFolder As String
	Dim ssh_FileCount As Integer
	''' <summary>
	''' The highest accessible address in List. Same as:<see cref="ssh__ImageFileNames"/>.Count - 1 
	''' </summary>
	<Obsolete("Duplicate Data! Use _ImageFileNames.count -1 instead")>
	Dim ssh_FileCountMax As Integer
	Private ssh__ImageFileNames As New List(Of String)
	<Obsolete("Not used anymore. Or change Filecount to this one, to enhance readablility")>
	Private ssh__CurrentImage As Integer = -1
	Dim ssh_WithTeaseImgDir As String
	<Obsolete("Belongs to frmSettings.")>
	Public ssh_ApproveImage As Integer = 0
	<Obsolete("Not used anymore.")>
	Public ssh_WIExit As Boolean
	<Obsolete("Non threadsafe duplicate of My.Settings.RecentSlideshows. Use this instead.")>
	Public ssh_RecentSlideshows As New List(Of String)
	<Obsolete("Read data using MainPictureBox.ImageLocation. Set data using ShowImage(String, Boolean) in future releases.")>
	Dim ssh_MainPictureImage As String
	Public ssh_DomPic As String

	Dim ssh_LockImage As Boolean
	Dim ssh_LockVideo As Boolean

	Dim ssh_LocalTagImageList As New List(Of String)

	<Obsolete("Not used anymore. Never set, but once resetted.")>
	Dim ssh_Crazy As Boolean
	<Obsolete("Not used anymore. Never set, but once resetted.")>
	Dim ssh_Vulgar As Boolean
	<Obsolete("Not used anymore. Never set, but once resetted.")>
	Dim ssh_Supremacist As Boolean

	<Obsolete("Overrides the User.Config Settings on resumse Session. Not really nice.")>
	Public ssh_CockSize As Integer
	Dim ssh_PetName As String

	Dim ssh_TauntText As String
	Dim ssh_ScriptCount As Integer
	Dim ssh_TempScriptCount As Integer
	Dim ssh_TauntTextCount As Integer

	Public ssh_SlideshowTimerTick As Integer

	<Obsolete("Ambiguous used in frmSettings and Form1! Read data using MainPictureBox.ImageLocation. Set data using ShowImage(String, Boolean) in future releases.")>
	Public ssh_WebImage As String

	<Obsolete("Belongs to Form2. Unhandled Exception in execution will block the File.")>
	Public ssh_WebImageFile As StreamReader
	<Obsolete("Belongs to frmSettings.")>
	Public ssh_WebImageLines As New List(Of String)
	<Obsolete("Belongs to frmSettings.")>
	Public ssh_WebImageLine As Integer
	<Obsolete("Belongs to frmSettings. Redundant Code. Use WebimageLines.Count instead")>
	Public ssh_WebImageLineTotal As Integer
	<Obsolete("Belongs to frmSettings.")>
	Public ssh_WebImagePath As String



	Dim ssh_LastScriptCountdown As Integer
	Dim ssh_LastScript As Boolean

	Dim ssh_JustShowedBlogImage As Boolean

	Public ssh_SaidHello As Boolean

	<Obsolete("Unused variable. Set often to some values, but Metronome uses StrokePace and the the CheckBoxValue in Metronome app")>
	Public ssh_StopMetronome As Boolean

	Public ssh_AvgEdgeStroking As Integer
	Public ssh_AvgEdgeNoTouch As Integer
	Public ssh_EdgeCountTick As Integer
	Public ssh_AvgEdgeStrokingFlag As Boolean
	Public ssh_AvgEdgeCount As Integer
	Public ssh_AvgEdgeCountRest As Integer
	Dim ssh_EdgeTickCheck As Integer

	Dim ssh_EdgeNOT As Boolean

	Public ssh_AlreadyStrokingEdge As Boolean

	Dim ssh_WritingTaskLinesAmount As Integer
	Dim ssh_WritingTaskLinesWritten As Integer
	Dim ssh_WritingTaskLinesRemaining As Integer
	Dim ssh_WritingTaskMistakesAllowed As Integer
	Dim ssh_WritingTaskMistakesMade As Integer
	Dim ssh_WritingTaskFlag As Boolean

	Dim ssh_FirstRound As Boolean
	Public ssh_StartStrokingCount As Integer

	Dim ssh_TeaseJOI As Boolean
	Dim ssh_TeaseVideo As Boolean

	<Obsolete("List is splitted up into BoobList and AssList")>
	Dim ssh_TnAList As New List(Of String)
	Dim ssh_BoobList As New List(Of String)
	Dim ssh_AssList As New List(Of String)
	Dim ssh_AssImage As Boolean = False
	Dim ssh_BoobImage As Boolean = False

	Dim ssh_FoundTag As String = "Null"
	Dim ssh_TagGarment As String = "NULL"
	Dim ssh_TagUnderwear As String = "NULL"
	Dim ssh_TagTattoo As String = "NULL"
	Dim ssh_TagSexToy As String = "NULL"
	Dim ssh_TagFurniture As String = "NULL"

	Dim ssh_BookmarkModule As Boolean
	Dim ssh_BookmarkModuleFile As String
	Dim ssh_BookmarkModuleLine As Integer
	Dim ssh_BookmarkLink As Boolean
	Dim ssh_BookmarkLinkFile As String
	Dim ssh_BookmarkLinkLine As Integer

	Dim ssh_WaitTick As Integer

	Public ssh_synth As New SpeechSynthesizer
	Public ssh_synth2 As New SpeechSynthesizer



	Dim ssh_OrgasmDenied As Boolean
	Dim ssh_OrgasmAllowed As Boolean
	Dim ssh_OrgasmRuined As Boolean
	Dim ssh_LastOrgasmType As String = ""

	<Obsolete("Not used anymore.")>
	Dim StupidTick As Integer
	<Obsolete("Not used anymore.")>
	Dim StupidFlag As Boolean

	Public ssh_CaloriesConsumed As Integer
	Public ssh_CaloriesGoal As Integer

	Public ssh_GoldTokens As Integer
	Public ssh_SilverTokens As Integer
	Public ssh_BronzeTokens As Integer

	Dim ssh_EdgeFound As Boolean

	Dim ssh_OrgasmYesNo As Boolean

	Public ssh_VTFlag As Boolean

	Public Shared ssh_DomPersonality As String
	Public ssh_UpdateList As New List(Of String)

	Public ssh_GlitterDocument As String

	Dim ssh_CustomSlideshow As Boolean
	<Obsolete("Not used anymore.")>
	Dim ssh_CustomSlideshowTick As Integer
	Dim ssh_CustomSlideshowList As New List(Of String)
	Dim ssh_ImageString As String

	Dim ssh_RapidFire As Boolean

	Public ssh_GlitterTease As Boolean
	Dim ssh_AddContactTick As Integer
	Public ssh_Contact1Pics As New List(Of String)
	Public ssh_Contact2Pics As New List(Of String)
	Public ssh_Contact3Pics As New List(Of String)
	Public ssh_Contact1PicsCount As Integer
	Public ssh_Contact2PicsCount As Integer
	Public ssh_Contact3PicsCount As Integer
	Public ssh_Group As String = "D"

	Dim ssh_CustomTask As Boolean
	Dim ssh_CustomTaskFirst As Boolean
	Dim ssh_CustomTaskText As String
	Dim ssh_CustomTaskTextFirst As String
	Dim ssh_CustomTaskActive As Boolean

	Dim ssh_SubtitleCount As Integer
	Dim ssh_VidFile As String


	Public ssh_RiskyDeal As Boolean
	Public ssh_RiskyEdges As Boolean
	Public ssh_RiskyDelay As Boolean
	Public ssh_FinalRiskyPick As Boolean

	Dim ssh_SysMes As Boolean
	Dim ssh_EmoMes As Boolean

	Dim ssh_Contact1Edge As Boolean
	Dim ssh_Contact2Edge As Boolean
	Dim ssh_Contact3Edge As Boolean

	Dim ssh_Contact1Stroke As Boolean
	Dim ssh_Contact2Stroke As Boolean
	Dim ssh_Contact3Stroke As Boolean

	Dim ssh_ReturnFileText As String
	Dim ssh_ReturnStrokeTauntVal As String
	Dim ssh_ReturnSubState As String
	Dim ssh_ReturnFlag As Boolean

	Public ssh_SessionEdges As Integer

	Dim ssh_WindowCheck As Boolean

	Dim ssh_StrokeFaster As Boolean
	Dim ssh_StrokeFastest As Boolean
	Dim ssh_StrokeSlower As Boolean
	Dim ssh_StrokeSlowest As Boolean

	Dim ssh_InputFlag As Boolean
	Dim ssh_InputString As String

	Dim ssh_RapidCode As Boolean

	Dim ssh_CorrectedTypo As Boolean
	Dim ssh_CorrectedWord As String

	Public ssh_DoNotDisturb As Boolean

	Dim ssh_TypoSwitch As Integer = 1
	Dim ssh_TyposDisabled As Boolean

	Public ssh_EdgeHoldSeconds As Integer
	Public ssh_EdgeHoldFlag As Boolean

	''' <summary>
	''' Addresses the current CustomSlideshow image.
	''' </summary>
	Public ssh_SlideshowInt As Integer
	Dim ssh_JustShowedSlideshowImage As Boolean

	Dim ssh_RandomSlideshowCategory As String

	Dim ssh_ResetFlag As Boolean

	Dim ssh_DommeTags As Boolean
	Dim ssh_ThemeSettings As Boolean

	Dim ssh_InputIcon As Boolean

	Public ssh_ApplyingTheme As Boolean
	Public ssh_AdjustingWindow As Boolean

	Dim ssh_SplitContainerHeight As Integer

	Dim ssh_DommeImageFound As Boolean

	Dim ssh_LocalImageFound As Boolean
	Dim ssh_LocalImageListCheck As Boolean

	Dim ssh_CBTBothActive As Boolean
	Dim ssh_CBTBothFlag As Boolean
	Dim ssh_CBTBothCount As Integer
	Dim ssh_CBTBothFirst As Boolean

	Public MetroThread As Thread

	Public ssh_GeneralTime As String = "Afternoon"

	Dim ssh_NewDommeSlideshow As Boolean
	Dim ssh_OriginalDommeSlideshow As String

	Dim ssh_TimeoutTick As Integer

	Dim ssh_DommeImageSTR As String
	Dim ssh_LocalImageSTR As String
	''' <summary>
	''' This Variable contains the Path of origin of the displayed Image. CheckDommeTag() uses 
	''' this string to get the curremt ImageData for the DommeTagApp.
	''' </summary>
	Dim ssh_ImageLocation As String

	Dim ssh_ResponseYes As String
	Dim ssh_ResponseNo As String

	Dim ssh_SetModule As String = ""
	Dim ssh_SetLink As String = ""
	Dim ssh_SetModuleGoto As String = ""
	Dim ssh_SetLinkGoto As String = ""


	Public ssh_OrgasmRestricted As Boolean

	Dim ssh_FollowUp As String = ""

	Dim ssh_WorshipMode As Boolean
	Dim ssh_WorshipTarget As String = ""

	Dim ssh_LongHold As Boolean
	Dim ssh_ExtremeHold As Boolean
	Dim ssh_LongTaunts As Boolean

	Dim LazyEdit1 As Boolean
	Dim LazyEdit2 As Boolean
	Dim LazyEdit3 As Boolean
	Dim LazyEdit4 As Boolean
	Dim LazyEdit5 As Boolean

	Dim FormFinishedLoading As Boolean = False

	Dim ssh_MiniScript As Boolean
	Dim ssh_MiniScriptText As String
	Dim ssh_MiniTauntVal As Integer
	Dim ssh_MiniTimerCheck As Boolean


	Dim ssh_JumpVideo As Boolean
	Dim ssh_VideoTick As Integer

	Dim ssh_EdgeGoto As Boolean
	Dim ssh_EdgeMessage As Boolean
	Dim ssh_EdgeVideo As Boolean

	Dim ssh_EdgeMessageText As String
	Dim ssh_EdgeGotoLine As String

	Dim ssh_MultipleEdges As Boolean
	Dim ssh_MultipleEdgesAmount As Integer
	Dim ssh_MultipleEdgesInterval As Integer
	Dim ssh_MultipleEdgesTick As Integer
	Dim ssh_MultipleEdgesMetronome As String = ""

	Dim ssh_YesGoto As Boolean
	Dim ssh_YesVideo As Boolean
	Dim ssh_NoGoto As Boolean
	Dim ssh_NoVideo_Mode As Boolean
	Dim ssh_CameGoto As Boolean
	Dim ssh_CameVideo As Boolean
	Dim ssh_CameMessage As Boolean
	Dim ssh_CameMessageText As String
	Dim ssh_RuinedGoto As Boolean
	Dim ssh_RuinedVideo As Boolean
	Dim ssh_RuinedMessage As Boolean
	Dim ssh_RuinedMessageText As String
	Dim ssh_YesGotoLine As String
	Dim ssh_NoGotoLine As String
	Dim ssh_CameGotoLine As String
	Dim ssh_RuinedGotoLine As String

	''' <summary>
	''' Set to true if the sub is on the edge and the domme had decided to not to stop stroking.
	''' </summary>
	''' <remarks>
	''' Uses following vocabulary Files:
	''' #SYS_TauntEdging.txt when the taunting begins.
	''' #SYS_TauntEdgingAsked.txt if the sub continues to tell he's on the edge.
	''' </remarks>
	Dim ssh_TauntEdging As Boolean

	Dim ssh_Modes As New Dictionary(Of String, Mode)(System.StringComparer.OrdinalIgnoreCase)

	Dim ssh_WritingTaskCurrentTime As Single

	Private Const DISABLE_SOUNDS As Integer = 21
	Private Const SET_FEATURE_ON_PROCESS As Integer = 2

	Private Declare Function GetKeyState _
		 Lib "user32" _
		 (ByVal nVirtKey As Long) As Integer
	Private Const VK_LBUTTON = &H1
	'flag True when resizing being processed
	Private bResize As Boolean



	<DllImport("urlmon.dll")>
	Public Shared Function CoInternetSetFeatureEnabled(
	ByVal FeatureEntry As Integer, <MarshalAs(UnmanagedType.U4)> ByVal dwFlags As Integer, ByVal fEnable As Boolean) As Integer

	End Function

	Declare Function mciSendString Lib "winmm.dll" Alias "mciSendStringA" (ByVal lpstrCommand As String,
ByVal lpstrReturnString As String, ByVal uReturnLength As Integer, ByVal hwndCallback As Integer) As Integer



	Private Sub Form1_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing


		Try

			mainPictureBox.Image = Nothing
			WatchDogImageAnimator.Dispose()

			Debug.Print("Here?")

			TeaseTimer.Stop()
			TeaseAIClock.Stop()
			Timer1.Stop()
			UpdateStageTimer.Stop()
			UpdatesTimer.Stop()
			StrokeTimeTotalTimer.Stop()
			StopEverything()






			'If BeforeTease = False And My.Settings.Sys_SubLeftEarly <> 0 Then My.Settings.Sys_SubLeftEarlyTotal += 1

			If ssh_BeforeTease = False And Val(GetVariable("SYS_SubLeftEarly")) <> 0 Then SetVariable("SYS_SubLeftEarlyTotal", Val(GetVariable("SYS_SubLeftEarlyTotal")) + 1)



			'TempGif.Dispose()
			'original.Dispose()
			'resized.Dispose()

			Try
				GC.Collect()
			Catch
			End Try



			If File.Exists(Application.StartupPath & "\System\Metronome") Then
				File.SetAttributes(Application.StartupPath & "\System\Metronome", FileAttributes.Normal)
				My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\System\Metronome")
			End If

			If File.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Temp\Temp.gif") Then
				My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Temp\Temp.gif")
			End If


			Try
				For Each prog As Process In Process.GetProcesses
					If prog.ProcessName = "Tease AI Metronome" Then
						prog.Kill()
					End If
				Next
			Catch ex As Exception

			End Try


			Dim TempDate As String
			Dim TempDateNow As DateTime = DateTime.Now

			TempDate = TempDateNow.ToString("MM.dd.yyyy hhmm")

			'Github Patch Begin

			' If FrmSettings.CBSaveChatlogExit.Checked = True Then

			'If (Not System.IO.Directory.Exists(Application.StartupPath & "\Chatlogs\")) Then
			'System.IO.Directory.CreateDirectory(Application.StartupPath & "\Chatlogs\")
			'End If

			'My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Chatlogs\" & TempDate & " chatlog.html", ChatText.DocumentText, False)

			'End If

			' Github Patch End

			SaveChatLog(TempDate)

			Try
				FrmSettings.Close()
				FrmSettings.Dispose()
			Catch ex As Exception
			End Try

			Try
				FrmCardList.Close()
				FrmCardList.Dispose()
			Catch ex As Exception
			End Try

			End

			TeaseAINotify.Visible = False
			TeaseAINotify.Icon = Nothing
			TeaseAINotify.Dispose()


			System.Windows.Forms.Application.DoEvents()
		Catch ex As Exception

		Finally
			My.Settings.Save()
		End Try
	End Sub

	Private Sub SaveChatLog(LogDate As String)
		If FrmSettings.CBSaveChatlogExit.Checked = True And ChatText.DocumentText.Length > 36 Then

			If (Not System.IO.Directory.Exists(Application.StartupPath & "\Chatlogs\")) Then
				System.IO.Directory.CreateDirectory(Application.StartupPath & "\Chatlogs\")
			End If

			My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Chatlogs\" & LogDate & " chatlog.html", ChatText.DocumentText, False)

		End If
	End Sub

	Protected Overrides Sub OnClosing(ByVal e As System.ComponentModel.CancelEventArgs)

		TeaseAINotify.Visible = False

		TeaseAINotify.Dispose()

		MyBase.OnClosing(e)
	End Sub






	Private Sub Form1_Load(sender As Object, e As System.EventArgs) Handles Me.Load

		Debug.Print("Form 2 Opened")

		Dim tv As Version = My.Application.Info.Version
		Me.Text = String.Format("Tease A.I. - PATCH {0}.{1}{2}",
								tv.Minor,
								tv.Build,
								If(tv.MinorRevision > 0, "." & tv.MinorRevision, ""))

		FormLoading = True

		FrmSplash.Show()

		FrmSplash.PBSplash.Value += 1
		FrmSplash.LBLSplash.Text = "Checking orgasm limit..."     ' 1
		FrmSplash.Refresh()

		If My.Settings.OrgasmLockDate = Nothing Then My.Settings.OrgasmLockDate = FormatDateTime(Now, DateFormat.ShortDate)
		Debug.Print("OrgasmLockDate = " & My.Settings.OrgasmLockDate)



		FrmSplash.PBSplash.Value += 1
		FrmSplash.LBLSplash.Text = "Clearing Metronome settings..."
		FrmSplash.Refresh()


		StrokePace = 0

		FrmSplash.PBSplash.Value += 1
		FrmSplash.LBLSplash.Text = "Checking terms and conditions..."
		FrmSplash.Refresh()


		' If My.Settings.TCAgreed = True Then
		'frmApps.ClearAgree()
		'End If

		If File.Exists(My.Settings.BackgroundImage) Then
			Me.BackgroundImage = Image.FromFile(My.Settings.BackgroundImage)
		Else
			Me.BackgroundImage = Nothing
		End If


		ApplyThemeColor()


		If My.Settings.TC2Agreed = False Then
			Form7.Show()
			Do
				Application.DoEvents()
			Loop Until My.Settings.TC2Agreed = True
		End If



		FrmSplash.PBSplash.Value += 1
		FrmSplash.LBLSplash.Text = "Checking installed Personalities..."
		FrmSplash.Refresh()

		Dim PersonType As String

		'dompersonalityComboBox.Items.Clear()

		Debug.Print(My.Settings.DomPersonality)
		'dompersonalityComboBox.Text = My.Settings.DomPersonality

		'dompersonalityComboBox.Text = My.Settings.DomPersonality


		For Each Dir As String In myDirectory.GetDirectories(Application.StartupPath & "\Scripts\")
			PersonType = Dir

			Dim DirSplit As String() = PersonType.Split("\")
			PersonType = DirSplit(DirSplit.Length - 1)
			Debug.Print("PersonType = " & PersonType)
			'Do While PersonType.Contains("\")
			'PersonType = PersonType.Remove(0, 1)
			'Loop
			Try
				dompersonalitycombobox.Items.Add(PersonType)
			Catch
			End Try
		Next

		If dompersonalitycombobox.Items.Count < 1 Then
			MessageBox.Show(Me, "No domme Personalities were found! Many aspects of this program will not work correctly until at least one Personality is installed.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
		Else
			Try
				dompersonalitycombobox.Text = My.Settings.DomPersonality
			Catch ex As Exception
				dompersonalitycombobox.Text = dompersonalitycombobox.Items(0)
			End Try
		End If


		FrmSettings.FrmSettingsLoading = True

		FrmSettings.FrmSettingStartUp()

		Do
			Application.DoEvents()
		Loop Until FrmSettings.FrmSettingsLoading = False

		ssh_StopMetronome = True



		ssh_StrokeTimeTotal = My.Settings.StrokeTimeTotal
		StrokeTimeTotalTimer.Start()

		FrmSplash.PBSplash.Value += 1
		FrmSplash.LBLSplash.Text = "Calculating total stroke time..."
		FrmSplash.Refresh()

		Dim STT As TimeSpan = TimeSpan.FromSeconds(ssh_StrokeTimeTotal)
		FrmSettings.LBLStrokeTimeTotal.Text = String.Format("{0:0000}:{1:00}:{2:00}:{3:00}", STT.Days, STT.Hours, STT.Minutes, STT.Seconds)


		ssh_DomTask = "Null"
		ssh_DomChat = "Null"

		ssh_CBTBallsFirst = True
		ssh_CBTCockFirst = True
		ssh_CBTBothFirst = True
		ssh_CustomTaskFirst = True

		CoInternetSetFeatureEnabled(DISABLE_SOUNDS, SET_FEATURE_ON_PROCESS, True)


		FrmSplash.PBSplash.Value += 1
		FrmSplash.LBLSplash.Text = "Loading Domme and Sub avatar images..."
		FrmSplash.Refresh()

		If File.Exists(My.Settings.DomAvatarSave) Then domAvatar.Image = Image.FromFile(My.Settings.DomAvatarSave)
		'If File.Exists(My.Settings.SubAvatarSave) Then subAvatar.Image = Image.FromFile(My.Settings.SubAvatarSave)


		FrmSplash.PBSplash.Value += 1
		FrmSplash.LBLSplash.Text = "Checking recent slideshows..."
		FrmSplash.Refresh()

		For Each comboitem As String In My.Settings.RecentSlideshows
			ImageFolderComboBox.Items.Add(comboitem)
		Next

		ssh_RecentSlideshows.Clear()

		For Each comboitem As String In My.Settings.RecentSlideshows
			ssh_RecentSlideshows.Add(comboitem)
		Next

		ssh_Chat = ""
		IsTypingTimer.Start()

		FrmSplash.PBSplash.Value += 1
		FrmSplash.LBLSplash.Text = "Checking local videos..."
		FrmSplash.Refresh()

		' Checks all folders and Sets the VideoCount as LabelText
		FrmSettings.Video_CheckAllFolders()

		ssh_VideoType = "General"

		FrmSplash.PBSplash.Value += 1
		FrmSplash.LBLSplash.Text = "Loading Glitter avatar images..."
		FrmSplash.Refresh()

		If File.Exists(My.Settings.GlitterAV) Then FrmSettings.GlitterAV.Image = Image.FromFile(My.Settings.GlitterAV)
		If File.Exists(My.Settings.GlitterAV1) Then FrmSettings.GlitterAV1.Image = Image.FromFile(My.Settings.GlitterAV1)
		If File.Exists(My.Settings.GlitterAV2) Then FrmSettings.GlitterAV2.Image = Image.FromFile(My.Settings.GlitterAV2)
		If File.Exists(My.Settings.GlitterAV3) Then FrmSettings.GlitterAV3.Image = Image.FromFile(My.Settings.GlitterAV3)

		FrmSplash.PBSplash.Value += 1
		FrmSplash.LBLSplash.Text = "Loading Glitter settings..."
		FrmSplash.Refresh()

		ssh_UpdatesTick = 120
		UpdatesTimer.Start()

		Me.ActiveControl = Me.chatBox


		'If My.Settings.CBGlitterFeed = False And My.Settings.CBGlitterFeedScripts = False And My.Settings.CBGlitterFeedOff = False Then
		'My.Settings.CBGlitterFeedOff = True
		'End If

		'QUESTION: (1885) Don't know what to do about these settings. The radio buttons staunchly refuse to be DataBound and non-DataBound settings don't currently save, so ¯\_(ツ)_/¯
		'ANSWER: (Stefaf) I'll take a look at this based on this link: http://stackoverflow.com/questions/11405020/radio-buttons-and-databinding-in-vb-net
		'TODO-Next-Stefaf: Add Databinding to RadioButtons.
		If My.Settings.CBGlitterFeed = True Then FrmSettings.CBGlitterFeed.Checked = True
		If My.Settings.CBGlitterFeedScripts = True Then FrmSettings.CBGlitterFeedScripts.Checked = True
		If My.Settings.CBGlitterFeedOff = True Then FrmSettings.CBGlitterFeedOff.Checked = True


		If My.Settings.CBTease = True Then
			FrmSettings.CBTease.Checked = True
		Else
			FrmSettings.CBTease.Checked = False
		End If
		If My.Settings.CBEgotist = True Then
			FrmSettings.CBEgotist.Checked = True
		Else
			FrmSettings.CBEgotist.Checked = False
		End If
		If My.Settings.CBTrivia = True Then
			FrmSettings.CBTrivia.Checked = True
		Else
			FrmSettings.CBTrivia.Checked = False
		End If
		If My.Settings.CBDaily = True Then
			FrmSettings.CBDaily.Checked = True
		Else
			FrmSettings.CBDaily.Checked = False
		End If
		If My.Settings.CBCustom1 = True Then
			FrmSettings.CBCustom1.Checked = True
		Else
			FrmSettings.CBCustom1.Checked = False
		End If
		If My.Settings.CBCustom2 = True Then
			FrmSettings.CBCustom2.Checked = True
		Else
			FrmSettings.CBCustom2.Checked = False
		End If





		FrmSplash.PBSplash.Value += 1
		FrmSplash.LBLSplash.Text = "Loading names..."
		FrmSplash.Refresh()



		If My.Settings.DomName <> "" Then domName.Text = My.Settings.DomName
		If My.Settings.SubName <> "" Then subName.Text = My.Settings.SubName


		FrmSettings.petnameBox1.Text = My.Settings.pnSetting1
		FrmSettings.petnameBox2.Text = My.Settings.pnSetting2
		FrmSettings.petnameBox3.Text = My.Settings.pnSetting3
		FrmSettings.petnameBox4.Text = My.Settings.pnSetting4
		FrmSettings.petnameBox5.Text = My.Settings.pnSetting5
		FrmSettings.petnameBox6.Text = My.Settings.pnSetting6
		FrmSettings.petnameBox7.Text = My.Settings.pnSetting7
		FrmSettings.petnameBox8.Text = My.Settings.pnSetting8

		FrmSplash.PBSplash.Value += 1
		FrmSplash.LBLSplash.Text = "Loading General settings..."
		FrmSplash.Refresh()

		If My.Settings.CBTimeStamps = True Then
			FrmSettings.timestampCheckBox.Checked = True
		Else
			FrmSettings.timestampCheckBox.Checked = False
		End If

		If My.Settings.CBShowNames = True Then
			FrmSettings.shownamesCheckBox.Checked = True
		Else
			FrmSettings.shownamesCheckBox.Checked = False
		End If

		If My.Settings.CBInstantType = True Then
			FrmSettings.typeinstantlyCheckBox.Checked = True
		Else
			FrmSettings.typeinstantlyCheckBox.Checked = False
		End If

		FrmSettings.CBWebtease.Checked = My.Settings.CBWebtease

		If FrmSettings.CBWebtease.Checked = True Then WebteaseModeToolStripMenuItem.Checked = True


		FrmSettings.CBInputIcon.Checked = My.Settings.CBInputIcon

		If My.Settings.CBBlogImageMain = True Then
			FrmSettings.CBBlogImageWindow.Checked = True
		Else
			FrmSettings.CBBlogImageWindow.Checked = False
		End If

		If My.Settings.CBSlideshowSubDir = True Then
			FrmSettings.CBSlideshowSubDir.Checked = True
		Else
			FrmSettings.CBSlideshowSubDir.Checked = False
		End If

		If My.Settings.CBSlideshowRandom = True Then
			FrmSettings.CBSlideshowRandom.Checked = True
		Else
			FrmSettings.CBSlideshowRandom.Checked = False
		End If

		If My.Settings.CBStretchLandscape = True Then
			FrmSettings.landscapeCheckBox.Checked = True
		Else
			FrmSettings.landscapeCheckBox.Checked = False
		End If


		If My.Settings.CBSettingsPause = True Then
			FrmSettings.CBSettingsPause.Checked = True
		Else
			FrmSettings.CBSettingsPause.Checked = False
		End If


		If My.Settings.CBAutosaveChatlog = True Then
			FrmSettings.CBAutosaveChatlog.Checked = True
		Else
			FrmSettings.CBAutosaveChatlog.Checked = False
		End If

		If My.Settings.CBExitSaveChatlog = True Then
			FrmSettings.CBSaveChatlogExit.Checked = True
		Else
			FrmSettings.CBSaveChatlogExit.Checked = False
		End If

		If My.Settings.CBImageInfo = True Then
			FrmSettings.CBImageInfo.Checked = True
		Else
			FrmSettings.CBImageInfo.Checked = False
		End If

		FrmSplash.PBSplash.Value += 1
		FrmSplash.LBLSplash.Text = "Loading Domme settings..."
		FrmSplash.Refresh()

		FrmSettings.domageNumBox.Value = My.Settings.DomAge

		If My.Settings.DomLevel <> 0 Then FrmSettings.domlevelNumBox.Value = My.Settings.DomLevel

		If FrmSettings.domlevelNumBox.Value = 1 Then FrmSettings.DomLevelDescLabel.Text = "Gentle"
		If FrmSettings.domlevelNumBox.Value = 2 Then FrmSettings.DomLevelDescLabel.Text = "Lenient"
		If FrmSettings.domlevelNumBox.Value = 3 Then FrmSettings.DomLevelDescLabel.Text = "Tease"
		If FrmSettings.domlevelNumBox.Value = 4 Then FrmSettings.DomLevelDescLabel.Text = "Rough"
		If FrmSettings.domlevelNumBox.Value = 5 Then FrmSettings.DomLevelDescLabel.Text = "Sadistic"

		FrmSettings.NBDomBirthdayMonth.Value = My.Settings.DomBirthMonth
		FrmSettings.NBDomBirthdayDay.Value = My.Settings.DomBirthDay

		FrmSettings.TBDomHairColor.Text = My.Settings.DomHair
		FrmSettings.domhairlengthComboBox.Text = My.Settings.DomHairLength
		FrmSettings.TBDomEyeColor.Text = My.Settings.DomEyes
		FrmSettings.boobComboBox.Text = My.Settings.DomCup
		FrmSettings.dompubichairComboBox.Text = My.Settings.DomPubicHair

		Debug.Print("Find Exception begin")

		If My.Settings.DomTattoos = True Then
			FrmSettings.CBDomTattoos.Checked = True
		Else
			FrmSettings.CBDomTattoos.Checked = False
		End If

		If My.Settings.DomFreckles = True Then
			FrmSettings.CBDomFreckles.Checked = True
		Else
			FrmSettings.CBDomFreckles.Checked = False
		End If




		Debug.Print("Find Exception")

		If My.Settings.DomCrazy = True Then
			FrmSettings.crazyCheckBox.Checked = True
		Else
			FrmSettings.crazyCheckBox.Checked = False
		End If

		If My.Settings.DomVulgar = True Then
			FrmSettings.vulgarCheckBox.Checked = True
		Else
			FrmSettings.vulgarCheckBox.Checked = False
		End If

		If My.Settings.DomSupremacist = True Then
			FrmSettings.supremacistCheckBox.Checked = True
		Else
			FrmSettings.supremacistCheckBox.Checked = False
		End If

		If My.Settings.DomLowercase = True Then
			FrmSettings.LCaseCheckBox.Checked = True
		Else
			FrmSettings.LCaseCheckBox.Checked = False
		End If

		If My.Settings.DomNoApostrophes = True Then
			FrmSettings.apostropheCheckBox.Checked = True
		Else
			FrmSettings.apostropheCheckBox.Checked = False
		End If

		If My.Settings.DomNoCommas = True Then
			FrmSettings.commaCheckBox.Checked = True
		Else
			FrmSettings.commaCheckBox.Checked = False
		End If

		If My.Settings.DomNoPeriods = True Then
			FrmSettings.periodCheckBox.Checked = True
		Else
			FrmSettings.periodCheckBox.Checked = False
		End If

		If My.Settings.DomMeMyMine = True Then
			FrmSettings.CBMeMyMine.Checked = True
		Else
			FrmSettings.CBMeMyMine.Checked = False
		End If



		FrmSettings.TBEmote.Text = My.Settings.TBEmote
		FrmSettings.TBEmoteEnd.Text = My.Settings.TBEmoteEnd

		If FrmSettings.TBEmote.Text = "" Then FrmSettings.TBEmote.Text = "*"
		If FrmSettings.TBEmoteEnd.Text = "" Then FrmSettings.TBEmoteEnd.Text = "*"

		FrmSettings.alloworgasmComboBox.Text = My.Settings.OrgasmAllow
		FrmSettings.ruinorgasmComboBox.Text = My.Settings.OrgasmRuin

		FrmSettings.LockOrgasmChances.Checked = My.Settings.LockOrgasmChances
		FrmSettings.alloworgasmComboBox.Enabled = True
		FrmSettings.ruinorgasmComboBox.Enabled = True
		FrmSettings.CBRangeOrgasm.Enabled = True
		If FrmSettings.CBRangeOrgasm.Checked = False Then
			FrmSettings.NBAllowOften.Enabled = True
			FrmSettings.NBAllowSometimes.Enabled = True
			FrmSettings.NBAllowRarely.Enabled = True
		End If
		FrmSettings.CBRangeRuin.Enabled = True
		If FrmSettings.CBRangeRuin.Checked = False Then
			FrmSettings.NBRuinOften.Enabled = True
			FrmSettings.NBRuinSometimes.Enabled = True
			FrmSettings.NBRuinRarely.Enabled = True
		End If

		If My.Settings.DomDenialEnd = True Then
			FrmSettings.CBDomDenialEnds.Checked = True
		Else
			FrmSettings.CBDomDenialEnds.Checked = False
		End If

		If My.Settings.DomOrgasmEnd = True Then
			FrmSettings.CBDomOrgasmEnds.Checked = True
		Else
			FrmSettings.CBDomOrgasmEnds.Checked = False
		End If


		FrmSettings.orgasmsPerNumBox.Value = My.Settings.DomOrgasmPer
		FrmSettings.orgasmsperComboBox.Text = My.Settings.DomPerMonth

		If My.Settings.DomLock = True Then
			FrmSettings.orgasmsperlockButton.Enabled = False
			FrmSettings.orgasmlockrandombutton.Enabled = False
			FrmSettings.limitcheckbox.Checked = True
			FrmSettings.limitcheckbox.Enabled = False
			FrmSettings.orgasmsPerNumBox.Enabled = False
			FrmSettings.orgasmsperComboBox.Enabled = False
		End If

		FrmSettings.NBDomMoodMin.Value = My.Settings.DomMoodMin
		FrmSettings.NBDomMoodMax.Value = My.Settings.DomMoodMax
		FrmSettings.NBAvgCockMin.Value = My.Settings.AvgCockMin
		FrmSettings.NBAvgCockMax.Value = My.Settings.AvgCockMax
		FrmSettings.NBSelfAgeMin.Value = My.Settings.SelfAgeMin
		FrmSettings.NBSelfAgeMax.Value = My.Settings.SelfAgeMax
		FrmSettings.NBSubAgeMin.Value = My.Settings.SubAgeMin
		FrmSettings.NBSubAgeMax.Value = My.Settings.SubAgeMax


		Debug.Print("Find Exception end")

		FrmSplash.PBSplash.Value += 1
		FrmSplash.LBLSplash.Text = "Checking Glitter scripts..."
		FrmSplash.Refresh()

		'FrmSettings.LblGlitterSettingsDescription.Text = "Hover the cursor over any setting in the menu for a more detailed description of its function."

		Try
			FrmSettings.LBLGlitModDomType.Text = dompersonalitycombobox.Text
		Catch
			FrmSettings.LBLGlitModDomType.Text = "Error!"
		End Try

		Try
			Dim files() As String = myDirectory.GetFiles(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Apps\Glitter\" & FrmSettings.CBGlitModType.Text & "\")
			Dim GlitterScriptCount As Integer
			FrmSettings.LBGlitModScripts.Items.Clear()
			For Each file As String In files
				GlitterScriptCount += 1
				FrmSettings.LBGlitModScripts.Items.Add(Path.GetFileName(file).Replace(".txt", ""))
			Next
			FrmSettings.LBLGlitModScriptCount.Text = FrmSettings.CBGlitModType.Text & " Scripts Found (" & GlitterScriptCount & ")"
		Catch
			FrmSettings.LBLGlitModScriptCount.Text = "No Scripts Found!"
		End Try


		FrmSettings.NBWritingTaskMin.Value = My.Settings.NBWritingTaskMin
		FrmSettings.NBWritingTaskMax.Value = My.Settings.NBWritingTaskMax

		FrmSplash.PBSplash.Value += 1
		FrmSplash.LBLSplash.Text = "Loading Image settings..."
		FrmSplash.Refresh()


		FrmSplash.PBSplash.Value += 1
		FrmSplash.LBLSplash.Text = "Loading Sub settings..."
		FrmSplash.Refresh()

		FrmSettings.CockSizeNumBox.Value = My.Settings.SubCockSize
		FrmSettings.subAgeNumBox.Value = My.Settings.SubAge

		FrmSettings.TBGreeting.Text = My.Settings.SubGreeting
		FrmSettings.TBYes.Text = My.Settings.SubYes
		FrmSettings.TBNo.Text = My.Settings.SubNo
		FrmSettings.TBHonorific.Text = My.Settings.SubHonorific

		If FrmSettings.TBHonorific.Text = "" Or FrmSettings.TBHonorific.Text Is Nothing Then FrmSettings.TBHonorific.Text = "Mistress"

		If My.Settings.CBUseHonor = True Then
			FrmSettings.CBHonorificInclude.Checked = True
		Else
			FrmSettings.CBHonorificInclude.Checked = False
		End If

		If My.Settings.CBCapHonor = True Then
			FrmSettings.CBHonorificCapitalized.Checked = True
		Else
			FrmSettings.CBHonorificCapitalized.Checked = False
		End If

		FrmSplash.PBSplash.Value += 1
		FrmSplash.LBLSplash.Text = "Loading Range settings..."
		FrmSplash.Refresh()

		FrmSettings.SliderSTF.Value = My.Settings.TimerSTF
		If FrmSettings.SliderSTF.Value = 1 Then FrmSettings.LBLStf.Text = "Preoccupied"
		If FrmSettings.SliderSTF.Value = 2 Then FrmSettings.LBLStf.Text = "Distracted"
		If FrmSettings.SliderSTF.Value = 3 Then FrmSettings.LBLStf.Text = "Normal"
		If FrmSettings.SliderSTF.Value = 4 Then FrmSettings.LBLStf.Text = "Talkative"
		If FrmSettings.SliderSTF.Value = 5 Then FrmSettings.LBLStf.Text = "Verbose"

		FrmSettings.TauntSlider.Value = My.Settings.TimerVTF
		If FrmSettings.TauntSlider.Value = 1 Then FrmSettings.LBLVtf.Text = "Preoccupied"
		If FrmSettings.TauntSlider.Value = 2 Or FrmSettings.TauntSlider.Value = 3 Then FrmSettings.LBLVtf.Text = "Distracted"
		If FrmSettings.TauntSlider.Value = 4 Or FrmSettings.TauntSlider.Value = 5 Then FrmSettings.LBLVtf.Text = "Normal"
		If FrmSettings.TauntSlider.Value = 6 Or FrmSettings.TauntSlider.Value = 7 Or FrmSettings.TauntSlider.Value = 8 Then FrmSettings.LBLVtf.Text = "Talkative"
		If FrmSettings.TauntSlider.Value = 9 Or FrmSettings.TauntSlider.Value = 10 Then FrmSettings.LBLVtf.Text = "Verbose"

		FrmSettings.NBBirthdayMonth.Value = My.Settings.SubBirthMonth
		FrmSettings.NBBirthdayDay.Value = My.Settings.SubBirthDay
		FrmSettings.TBSubHairColor.Text = My.Settings.SubHair
		FrmSettings.TBSubEyeColor.Text = My.Settings.SubEyes


		FrmSettings.FontComboBoxD.Text = My.Settings.DomFont
		FrmSettings.NBFontSizeD.Text = My.Settings.DomFontSize
		FrmSettings.FontComboBox.Text = My.Settings.SubFont
		FrmSettings.NBFontSize.Text = My.Settings.SubFontSize

		FrmSplash.PBSplash.Value += 1
		FrmSplash.LBLSplash.Text = "Configuring media player..."
		FrmSplash.Refresh()

		DomWMP.Height = SplitContainer1.Panel1.Height + 60

		If My.Settings.DomAVStretch = False Then domAvatar.SizeMode = PictureBoxSizeMode.Zoom
		'If My.Settings.SubAvStretch = False Then subAvatar.SizeMode = PictureBoxSizeMode.Zoom

		ssh_HoldEdgeTimeTotal = My.Settings.HoldEdgeTimeTotal

		BTNFileTransferOpen.Visible = False
		BTNFIleTransferDismiss.Visible = False

		FrmSplash.PBSplash.Value += 1
		FrmSplash.LBLSplash.Text = "Initializing Games window..."
		FrmSplash.Refresh()


		Try
			RefreshCards()
		Catch
		End Try

		ssh_GoldTokens = My.Settings.GoldTokens
		ssh_SilverTokens = My.Settings.SilverTokens
		ssh_BronzeTokens = My.Settings.BronzeTokens

		If My.Settings.Patch45Tokens = False Then
			ssh_BronzeTokens += 100
			My.Settings.Patch45Tokens = True
			My.Settings.BronzeTokens = ssh_BronzeTokens
		End If

		If ssh_BronzeTokens < 0 Then
			ssh_BronzeTokens = 0
		End If

		If ssh_SilverTokens < 0 Then
			ssh_SilverTokens = 0
		End If

		If ssh_GoldTokens < 0 Then
			ssh_GoldTokens = 0
		End If



		ssh_DommeMood = ssh_randomizer.Next(5, 8)


		FrmSplash.PBSplash.Value += 1
		FrmSplash.LBLSplash.Text = "Checking previous orgasms..."
		FrmSplash.Refresh()

		If My.Settings.LastOrgasm = Nothing Then
			My.Settings.LastOrgasm = FormatDateTime(Now, DateFormat.ShortDate)
		End If

		FrmSettings.LBLLastOrgasm.Text = My.Settings.LastOrgasm.ToString()

		If My.Settings.LastRuined = Nothing Then
			My.Settings.LastRuined = FormatDateTime(Now, DateFormat.ShortDate)
		End If

		FrmSettings.LBLLastRuined.Text = My.Settings.LastRuined.ToString()

		FrmSplash.PBSplash.Value += 1
		FrmSplash.LBLSplash.Text = "Checking current date..."
		FrmSplash.Refresh()

		If CompareDates(My.Settings.DateStamp) <> 0 Then

			Dim LoginChance As Integer = ssh_randomizer.Next(1, 101)
			Dim LoginAmt As Integer

			If LoginChance = 100 Then LoginAmt = 100
			If LoginChance < 100 Then LoginAmt = 50
			If LoginChance < 91 Then LoginAmt = 25
			If LoginChance < 76 Then LoginAmt = 10
			If LoginChance < 51 Then LoginAmt = 5



			TeaseAINotify.BalloonTipText = "Daily login bonus: You've received " & LoginAmt & " tokens!"
			TeaseAINotify.Text = "Tease AI"
			TeaseAINotify.ShowBalloonTip(5000)

			'MessageBox.Show(Me, "You've received 5 Bronze tokens!", "Daily Login Bonus", MessageBoxButtons.OK, MessageBoxIcon.Information)
			My.Settings.DateStamp = FormatDateTime(Now, DateFormat.ShortDate)
			ssh_BronzeTokens += LoginAmt
			SaveTokens()
		End If

		Debug.Print("Break here?")


		If CompareDates(My.Settings.WishlistDate) <> 0 Then
			My.Settings.ClearWishlist = False
		End If
		Debug.Print("Test?")

		FrmSplash.PBSplash.Value += 1
		FrmSplash.LBLSplash.Text = "Calculating average edge information..."
		FrmSplash.Refresh()

		ssh_AvgEdgeStroking = My.Settings.AvgEdgeStroking
		ssh_AvgEdgeNoTouch = My.Settings.AvgEdgeNoTouch
		ssh_AvgEdgeCount = My.Settings.AvgEdgeCount
		ssh_AvgEdgeCountRest = My.Settings.AvgEdgeCountRest



		If My.Settings.AvgEdgeCount > 4 Then
			Dim TS1 As TimeSpan = TimeSpan.FromSeconds(ssh_AvgEdgeStroking)
			FrmSettings.LBLAvgEdgeStroking.Text = String.Format("{0:00}:{1:00}", TS1.Minutes, TS1.Seconds)
		Else
			FrmSettings.LBLAvgEdgeStroking.Text = "WAIT"
		End If


		If My.Settings.AvgEdgeCountRest > 4 Then
			Dim TS2 As TimeSpan = TimeSpan.FromSeconds(ssh_AvgEdgeNoTouch)
			FrmSettings.LBLAvgEdgeNoTouch.Text = String.Format("{0:00}:{1:00}", TS2.Minutes, TS2.Seconds)
		Else
			FrmSettings.LBLAvgEdgeNoTouch.Text = "WAIT"
		End If

		FrmSplash.PBSplash.Value += 1
		FrmSplash.LBLSplash.Text = "Loading Domme Personality..."
		FrmSplash.Refresh()

		ssh_DomPersonality = dompersonalitycombobox.Text

		FrmSplash.PBSplash.Value += 1
		FrmSplash.LBLSplash.Text = "Clearing temporary flags..."
		FrmSplash.Refresh()

		If Directory.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Flags\Temp\") Then
			My.Computer.FileSystem.DeleteDirectory(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Flags\Temp\", FileIO.DeleteDirectoryOption.DeleteAllContents)
		End If

		System.IO.Directory.CreateDirectory(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Flags\Temp\")

		FrmSplash.PBSplash.Value += 1
		FrmSplash.LBLSplash.Text = "Loading Glitter Contact image slideshows..."
		FrmSplash.Refresh()

		Try
			ssh.SlideshowDomme = New Slideshow(ContactType.Domme)
			ssh.SlideshowContact1 = New Slideshow(ContactType.Contact1)
			ssh.SlideshowContact2 = New Slideshow(ContactType.Contact2)
			ssh.SlideshowContact3 = New Slideshow(ContactType.Contact3)
		Catch ex As Exception

		End Try

		Contact1Pics_Load()
		Contact2Pics_Load()
		Contact3Pics_Load()

		If File.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Apps\Glitter\Contact_Descriptions.txt") Then
			Dim ContactList As New List(Of String)
			ContactList = Txt2List(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Apps\Glitter\Contact_Descriptions.txt")
			FrmSettings.GBGlitter1.Text = PoundClean(ContactList(0))
			FrmSettings.GBGlitter2.Text = PoundClean(ContactList(1))
			FrmSettings.GBGlitter3.Text = PoundClean(ContactList(2))
		Else
			FrmSettings.GBGlitter1.Text = "Contact 1"
			FrmSettings.GBGlitter2.Text = "Contact 2"
			FrmSettings.GBGlitter3.Text = "Contact 3"
		End If

		If My.Settings.Chastity = False Then
			FrmSettings.LBLChastityState.Text = "OFF"
			FrmSettings.LBLChastityState.ForeColor = Color.Red
		Else
			FrmSettings.LBLChastityState.Text = "ON"
			FrmSettings.LBLChastityState.ForeColor = Color.Green
		End If

		WMPTimer.Start()

		FrmSplash.PBSplash.Value += 1
		FrmSplash.LBLSplash.Text = "Preparing Reset state..."
		FrmSplash.Refresh()

		ssh_ResetFlag = True
		SuspendSession()

		CBShortcuts.Checked = My.Settings.Shortcuts
		CBHideShortcuts.Checked = My.Settings.ShowShortcuts
		GetShortcutChecked()

		TBShortYes.Text = My.Settings.ShortYes
		TBShortNo.Text = My.Settings.ShortNo
		TBShortEdge.Text = My.Settings.ShortEdge
		TBShortSpeedUp.Text = My.Settings.ShortSpeedUp
		TBShortSlowDown.Text = My.Settings.ShortSlowDown
		TBShortStop.Text = My.Settings.ShortStop
		TBShortStroke.Text = My.Settings.ShortStroke
		TBShortCum.Text = My.Settings.ShortCum
		TBShortGreet.Text = My.Settings.ShortGreet
		TBShortSafeword.Text = My.Settings.ShortSafeword

		FrmSplash.PBSplash.Value += 1
		FrmSplash.LBLSplash.Text = "Checking saved dimensions..."
		FrmSplash.Refresh()

		If My.Settings.WindowWidth = 0 Or My.Settings.WindowHeight = 0 Then
			Me.WindowState = FormWindowState.Maximized
		Else
			Me.Width = My.Settings.WindowWidth
			Me.Height = My.Settings.WindowHeight
		End If



		TeaseAIClock.Start()

		FrmSplash.PBSplash.Value += 1
		FrmSplash.LBLSplash.Text = "Loading theme..."
		FrmSplash.Refresh()

		CloseApp()

		LBLCalorie.Text = My.Settings.CaloriesConsumed
		Debug.Print("HOW MANY FUCKING CALORIES!!!! " & My.Settings.CaloriesConsumed)

		If File.Exists(Application.StartupPath & "\System\VitalSub\ExerciseList.cld") Then
			LoadExercise()
		End If

		ssh_CaloriesConsumed = My.Settings.CaloriesConsumed

		If File.Exists(Application.StartupPath & "\System\VitalSub\CalorieItems.txt") Then
			' Read the given File, convert List(of String) to Array and add it to ListboxItems.
			LBCalorie.Items.AddRange(Txt2List(Application.StartupPath & "\System\VitalSub\CalorieItems.txt").ToArray)
			LBLCalorie.Text = ssh_CaloriesConsumed
		Else
			ssh_CaloriesConsumed = 0
			My.Settings.CaloriesConsumed = 0
			LBLCalorie.Text = ssh_CaloriesConsumed
		End If


		CBVitalSub.Checked = My.Settings.VitalSub

		If CBVitalSub.Checked = True Then
			CBVitalSub.ForeColor = Color.LightGreen
			CBVitalSub.Text = "VitalSub Active"
		Else
			CBVitalSub.ForeColor = Color.Red
			CBVitalSub.Text = "VitalSub Inactive"
		End If

		CBVitalSubDomTask.Checked = My.Settings.VitalSubAssignments

		NBMinPace.Value = My.Settings.MinPace
		NBMaxPace.Value = My.Settings.MaxPace


		CBMetronome.Checked = My.Settings.MetroOn


		FrmSettings.CBMuteMedia.Checked = My.Settings.MuteMedia


		FormLoading = False

		Control.CheckForIllegalCrossThreadCalls = False

		MetroThread = New Thread(AddressOf MetronomeTick) With {.Name = "Metronome-Thread"}
		MetroThread.IsBackground = True
		MetroThread.Start()



		BTNLS1.Text = My.Settings.LS1

		BTNLS2.Text = My.Settings.LS2

		BTNLS3.Text = My.Settings.LS3

		BTNLS4.Text = My.Settings.LS4

		BTNLS5.Text = My.Settings.LS5




		'ImageThread.Start()

		FrmSplash.Close()
		FrmSplash.Dispose()



		If File.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Variables\SYS_OrgasmRestricted") Then
			If CompareDatesWithTime(GetDate("SYS_OrgasmRestricted")) <> 1 Then
				My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Variables\SYS_OrgasmRestricted")
				ssh_OrgasmRestricted = False
			Else
				ssh_OrgasmRestricted = True
			End If
		End If


		Me.Left = (Screen.PrimaryScreen.WorkingArea.Width - Me.Width) / 2
3:
		Me.Top = (Screen.PrimaryScreen.WorkingArea.Height - Me.Height) / 2


		Debug.Print("This getting called------------------------------?")

		mainPictureBox.Location = New Point(0, 0)
		mainPictureBox.Width = SplitContainer1.Width
		mainPictureBox.Height = SplitContainer1.Panel1.Height

		Debug.Print(SplitContainer1.Width & " & " & mainPictureBox.Width)

		AdjustWindow()

		Debug.Print(SplitContainer1.Width & " & " & mainPictureBox.Width)


		If My.Settings.SplitterDistance <> -1 Then
			If My.Settings.SplitterDistance > SplitContainer1.Height Then My.Settings.SplitterDistance = SplitContainer1.Height * 0.75
			SplitContainer1.SplitterDistance = My.Settings.SplitterDistance
		End If

		If My.Settings.SideChat = True Then
			ChatText2.Visible = True
			PNLChatBox2.Visible = True
			OpenApp()
			SideChatToolStripMenuItem1.Checked = True
		End If

		If My.Settings.LazySubAV = True Then
			PNLLazySubAV.Visible = True
			LazySubAVToolStripMenuItem1.Checked = True
		End If


		FormFinishedLoading = True

		'TabControl1.ColorScheme.TabBackground = Color.Transparent
		'TabControl1.ColorScheme.TabBackground2 = Color.Transparent
		'TabControl1.BackColor = Color.Transparent
		My.Settings.Save()
		Debug.Print("Form1 Loading Finished")

	End Sub

	Public Sub ResetButton()

		ScriptTimer.Stop()

		Dim TempDate As String
		Dim TempDateNow As DateTime = DateTime.Now

		TempDate = TempDateNow.ToString("MM.dd.yyyy hhmm")

		SaveChatLog(TempDate)

		ssh_DomTask = "@SystemMessage <b>Tease AI has been reset</b>"
		ssh_DomChat = "@SystemMessage <b>Tease AI has been reset</b>"

		StrokePace = 0

		If Directory.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Flags\Temp\") Then
			My.Computer.FileSystem.DeleteDirectory(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Flags\Temp\", FileIO.DeleteDirectoryOption.DeleteAllContents)
		End If

		System.IO.Directory.CreateDirectory(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Flags\Temp\")

		ssh_StopMetronome = True

		ssh_TauntEdging = False

		ssh_CBTBallsFirst = True
		ssh_CBTCockFirst = True
		ssh_CBTBothFirst = True
		ssh_CustomTaskFirst = True

		ssh_VideoType = "General"

		ssh_UpdatesTick = 120
		UpdatesTimer.Start()

		Me.ActiveControl = Me.chatBox

		ssh_DommeMood = ssh_randomizer.Next(5, 8)

		ssh_JustShowedBlogImage = False

		ssh_SaidHello = False
		ssh_SubWroteLast = False
		ssh_WritingTaskFlag = False

		ssh_OrgasmYesNo = False

		FrmSettings.alloworgasmComboBox.Enabled = True
		FrmSettings.ruinorgasmComboBox.Enabled = True
		FrmSettings.CBRangeOrgasm.Enabled = True
		If FrmSettings.CBRangeOrgasm.Checked = False Then
			FrmSettings.NBAllowOften.Enabled = True
			FrmSettings.NBAllowSometimes.Enabled = True
			FrmSettings.NBAllowRarely.Enabled = True
		End If
		FrmSettings.CBRangeRuin.Enabled = True
		If FrmSettings.CBRangeRuin.Checked = False Then
			FrmSettings.NBRuinOften.Enabled = True
			FrmSettings.NBRuinSometimes.Enabled = True
			FrmSettings.NBRuinRarely.Enabled = True
		End If

		ssh_ShowModule = False
		ssh_BookmarkLink = False
		ssh_BookmarkModule = False
		ssh_YesOrNo = False

		ssh_StartStrokingCount = 0


		ssh_StrokeTauntVal = -1

		ssh_EdgeToRuinSecret = True








		TeaseTimer.Stop()

		DeleteVariable("SYS_StrokeRound")

		mainPictureBox.Image = Nothing
		ssh_SlideshowLoaded = False

		FrmSettings.domlevelNumBox.Value = My.Settings.DomLevel
		FrmSettings.NBEmpathy.Value = My.Settings.DomEmpathy

		' Github Patch
		BTNPlaylist.Enabled = True

		If PNLWritingTask.Visible Then CloseApp()

	End Sub



	Private Sub sendButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sendButton.Click





		Dim CheckSpace As String = chatBox.Text

		If CheckSpace = "" Then CheckSpace = ChatBox2.Text

		CheckSpace = CheckSpace.Replace(" ", "")

		If CheckSpace = "" Then Return

		If LazyEdit1 = True Then
			If chatBox.Text <> "" Then
				BTNLS1.Text = chatBox.Text
			Else
				BTNLS1.Text = ChatBox2.Text
			End If
			BTNLS1.Visible = True
			BTNLS1Edit.BackColor = My.Settings.ButtonColor
			BTNLS1Edit.ForeColor = My.Settings.TextColor
			My.Settings.LS1 = BTNLS1.Text
			chatBox.Text = ""
			ChatBox2.Text = ""
			Return
		End If

		If LazyEdit2 = True Then
			If chatBox.Text <> "" Then
				BTNLS2.Text = chatBox.Text
			Else
				BTNLS2.Text = ChatBox2.Text
			End If
			BTNLS2.Visible = True
			BTNLS2Edit.BackColor = My.Settings.ButtonColor
			BTNLS2Edit.ForeColor = My.Settings.TextColor
			My.Settings.LS2 = BTNLS2.Text
			chatBox.Text = ""
			ChatBox2.Text = ""
			Return
		End If

		If LazyEdit3 = True Then
			If chatBox.Text <> "" Then
				BTNLS3.Text = chatBox.Text
			Else
				BTNLS3.Text = ChatBox2.Text
			End If
			BTNLS3.Visible = True
			BTNLS3Edit.BackColor = My.Settings.ButtonColor
			BTNLS3Edit.ForeColor = My.Settings.TextColor
			My.Settings.LS3 = BTNLS3.Text
			chatBox.Text = ""
			ChatBox2.Text = ""
			Return
		End If

		If LazyEdit4 = True Then
			If chatBox.Text <> "" Then
				BTNLS4.Text = chatBox.Text
			Else
				BTNLS4.Text = ChatBox2.Text
			End If
			BTNLS4.Visible = True
			BTNLS4Edit.BackColor = My.Settings.ButtonColor
			BTNLS4Edit.ForeColor = My.Settings.TextColor
			My.Settings.LS4 = BTNLS4.Text
			chatBox.Text = ""
			ChatBox2.Text = ""
			Return
		End If

		If LazyEdit5 = True Then
			If chatBox.Text <> "" Then
				BTNLS5.Text = chatBox.Text
			Else
				BTNLS5.Text = ChatBox2.Text
			End If
			BTNLS5.Visible = True
			BTNLS5Edit.BackColor = My.Settings.ButtonColor
			BTNLS5Edit.ForeColor = My.Settings.TextColor
			My.Settings.LS5 = BTNLS5.Text
			chatBox.Text = ""
			ChatBox2.Text = ""
			Return
		End If


		If TimeoutTimer.Enabled = True Then TimeoutTimer.Stop()

		If dompersonalitycombobox.Items.Count < 1 Then
			MessageBox.Show(Me, "No domme Personalities were found! Please install at least one Personality directory in the Scripts folder before using this part of the program.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Return
		End If

		ssh_ChatString = chatBox.Text

		If ssh_ChatString = "" Then ssh_ChatString = ChatBox2.Text

		If CBShortcuts.Checked = True Then

			If UCase(ssh_ChatString) = UCase(TBShortYes.Text) Then ssh_ChatString = "Yes " & FrmSettings.TBHonorific.Text
			If UCase(ssh_ChatString) = UCase(TBShortNo.Text) Then ssh_ChatString = "No " & FrmSettings.TBHonorific.Text
			If UCase(ssh_ChatString) = UCase(TBShortEdge.Text) Then ssh_ChatString = "On the edge"
			If UCase(ssh_ChatString) = UCase(TBShortSpeedUp.Text) Then ssh_ChatString = "Let me speed up"
			If UCase(ssh_ChatString) = UCase(TBShortSlowDown.Text) Then ssh_ChatString = "Let me slow down"
			If UCase(ssh_ChatString) = UCase(TBShortStop.Text) Then ssh_ChatString = "Let me stop"
			If UCase(ssh_ChatString) = UCase(TBShortStroke.Text) Then ssh_ChatString = "May I start stroking?"
			If UCase(ssh_ChatString) = UCase(TBShortCum.Text) Then ssh_ChatString = "Please let me cum!"
			If UCase(ssh_ChatString) = UCase(TBShortGreet.Text) Then ssh_ChatString = "Hello " & FrmSettings.TBHonorific.Text
			If UCase(ssh_ChatString) = UCase(TBShortSafeword.Text) Then ssh_ChatString = FrmSettings.TBSafeword.Text

		End If


		chatBox.Text = ""
		ChatBox2.Text = ""

		If ssh_ChatString.Substring(0, 1) = "@" Then

			If ssh_ChatString = "@" Then

				ssh_Chat = "<font face=""Cambria"" size=""2"" color=""Green"">" & ssh_Chat & ssh_ChatString.Replace("@", "") & "::: TYPO ::: <br>::: FileText = " & ssh_FileText & " ::: LineVal = " & ssh_StrokeTauntVal & "<br>::: TauntText = " & ssh_TauntText & " ::: LineVal = " & ssh_TauntTextCount & "<br>::: ResponseFile = " & ssh_ResponseFile & " ::: LineVal = " & ssh_ResponseLine & "<br></font>"
			Else
				ssh_Chat = "<font face=""Cambria"" size=""2"" color=""Green"">" & ssh_Chat & ssh_ChatString.Replace("@", "") & " :::  <br>::: FileText = " & ssh_FileText & " ::: LineVal = " & ssh_StrokeTauntVal & "<br>::: TauntText = " & ssh_TauntText & " ::: LineVal = " & ssh_TauntTextCount & "<br>::: ResponseFile = " & ssh_ResponseFile & " ::: LineVal = " & ssh_ResponseLine & "<br></font>"
			End If

			ssh_Chat = "<body bgcolor=""" & Color2Html(My.Settings.ChatWindowColor) & """>" & ssh_Chat & "</body>"
			ChatText.DocumentText = ssh_Chat
			ChatText2.DocumentText = ssh_Chat
			ChatReadyState()

			chatBox.Text = ""
			ChatBox2.Text = ""

			If FrmSettings.CBAutosaveChatlog.Checked = True Then My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Chatlogs\Autosave.html", ChatText.DocumentText, False)

			Return
		End If

		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then
			MsgBox("Please close the settings menu or disable ""Pause Program When Settings Menu is Visible"" option first!", , "Warning!")
			Return
		End If



		' Add timestamps to domme response if the option is checked in the menu
		If FrmSettings.timestampCheckBox.Checked = True Then
			ssh_Chat = ssh_Chat & "<font face=""Cambria"" size=""2"" color=""DimGray"">" & (Date.Now.ToString("hh:mm tt ")) & "</font>"
		End If

		If ssh_WritingTaskFlag = True Then GoTo WritingTaskLine

		Dim TextColor As String = Color2Html(My.Settings.ChatTextColor)

		If ssh_SubWroteLast = True And FrmSettings.shownamesCheckBox.Checked = False Then

			ssh_Chat = "<body style=""word-wrap:break-word;"">" & ssh_Chat & "<font face=""" & FrmSettings.FontComboBox.Text & """ size=""" & FrmSettings.NBFontSize.Value & """ color=""" & TextColor & """>" & ssh_ChatString & "<br></font></body>"
			ssh_Chat = "<body bgcolor=""" & Color2Html(My.Settings.ChatWindowColor) & """>" & ssh_Chat & "</body>"
			ChatText.DocumentText = ssh_Chat
			ChatText2.DocumentText = ssh_Chat
			ChatReadyState()


		Else

			ssh_Chat = "<body style=""word-wrap:break-word;"">" & ssh_Chat & "<font face=""Cambria"" size=""3"" font color=""" &
			 My.Settings.SubColor & """><b>" & subName.Text & ": </b></font><font face=""" & FrmSettings.FontComboBox.Text & """ size=""" & FrmSettings.NBFontSize.Value & """ color=""" & TextColor & """>" & ssh_ChatString & "<br></font></body>"
			ssh_Chat = "<body bgcolor=""" & Color2Html(My.Settings.ChatWindowColor) & """>" & ssh_Chat & "</body>"
			ChatText.DocumentText = ssh_Chat
			ChatText2.DocumentText = ssh_Chat
			ChatReadyState()

		End If



		ScrollChatDown()

		If FrmSettings.CBAutosaveChatlog.Checked = True Then My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Chatlogs\Autosave.html", ChatText.DocumentText, False)

		If ssh_IsTyping = True Then

			ChatText.DocumentText = ssh_Chat & "<font color=""DimGray""><i>" & domName.Text & " is typing...</i></font>"
			ChatText2.DocumentText = ssh_Chat & "<font color=""DimGray""><i>" & domName.Text & " is typing...</i></font>"
			ChatReadyState()
		End If



		ssh_SubWroteLast = True




		'If frmApps.CBDebugAwareness.Checked = True Then GoTo DebugAwareness



		If ssh_SaidHello = False Then
			If UCase(ssh_ChatString).Contains("TASK") Then
				Dim TaskList As New List(Of String)

				For Each TaskFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Interrupt\Start Tasks\", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
					TaskList.Add(TaskFile)
				Next
				' github patch begin
				'If TaskList.Count > 0 Then
				'BeforeTease = True
				'SaidHello = True
				'SubEdging = False
				'SubHoldingEdge = False
				'FileText = TaskList(randomizer.Next(0, TaskList.Count))
				'LockImage = False
				'StrokeTauntVal = -1
				'ScriptTick = 3
				'ScriptTimer.Start()
				'ShowModule = False
				'Else
				'MessageBox.Show(Me, "No files were found in " & Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Interrupt\Start Tasks!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				'github patch end

				If TaskList.Count > 0 Then
					If Directory.Exists(FrmSettings.LBLDomImageDir.Text) And ssh_SlideshowLoaded = False Then
						LoadDommeImageFolder()
					End If
					ssh_BeforeTease = True
					ssh_SaidHello = True
					ssh_SubEdging = False
					ssh_SubHoldingEdge = False
					ssh_FileText = TaskList(ssh_randomizer.Next(0, TaskList.Count))
					ssh_LockImage = False
					If ssh_SlideshowLoaded = True Then
						nextButton.Enabled = True
						previousButton.Enabled = True
						PicStripTSMIdommeSlideshow.Enabled = True
					End If
					ssh_StrokeTauntVal = -1
					ssh_ScriptTick = 3
					ScriptTimer.Start()
					ssh_ShowModule = False
				Else
					MessageBox.Show(Me, "No files were found in " & Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Interrupt\Start Tasks!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End If
				Return
			End If




			Dim TempGreeting As String = FrmSettings.TBGreeting.Text
			TempGreeting = "[" & TempGreeting & "] Null"
			Dim Splits As String() = TempGreeting.Split(New Char() {"]"c})
			Splits(0) = Splits(0).Replace("[", "")

			Do
				Splits(0) = Splits(0).Replace("  ", " ")
				Splits(0) = Splits(0).Replace(" ,", ",")
				Splits(0) = Splits(0).Replace(", ", ",")
				Splits(0) = Splits(0).Replace("'", "")
			Loop Until Not Splits(0).Contains("  ") And Not Splits(0).Contains(", ") And Not Splits(0).Contains(" ,") And Not Splits(0).Contains("'")

			Dim SplitParts As String() = Splits(0).Split(New Char() {","c})

			For i As Integer = 0 To SplitParts.Length - 1

				If UCase(ssh_ChatString).Contains(UCase(SplitParts(i))) Then


					If FrmSettings.CBHonorificInclude.Checked = True Then

						If WordExists(UCase(ssh_ChatString), UCase(FrmSettings.TBHonorific.Text)) = False Then

							'If InStr(UCase(ChatString), (UCase(FrmSettings.TBHonorific.Text))) = 0 Then
							'If Not UCase(ChatString).Contains(UCase(FrmSettings.TBHonorific.Text)) Then
							ssh_DomChat = SplitParts(i) & " what?"
							If FrmSettings.LCaseCheckBox.Checked = False Then
								Dim DomU As String = UCase(ssh_DomChat.Substring(0, 1))
								ssh_DomChat = ssh_DomChat.Remove(0, 1)
								ssh_DomChat = DomU & ssh_DomChat
							End If
							TypingDelay()
							Return
						End If




						If FrmSettings.CBHonorificCapitalized.Checked = True Then
							If WordExists(ssh_ChatString, Capitalize(FrmSettings.TBHonorific.Text)) = False Then
								'If Not ChatString.Contains(FrmSettings.TBHonorific.Text) Then
								ssh_DomChat = "#CapitalizeHonorific"
								TypingDelay()
								Return
							End If
						End If
					End If

					Debug.Print("CHeck")

					ssh_SaidHello = True
					ssh_BeforeTease = True



					If FrmSettings.CBTeaseLengthDD.Checked = True Then


						If FrmSettings.domlevelNumBox.Value = 1 Then ssh_TeaseTick = ssh_randomizer.Next(10, 16) * 60
						If FrmSettings.domlevelNumBox.Value = 2 Then ssh_TeaseTick = ssh_randomizer.Next(15, 21) * 60
						If FrmSettings.domlevelNumBox.Value = 3 Then ssh_TeaseTick = ssh_randomizer.Next(20, 31) * 60
						If FrmSettings.domlevelNumBox.Value = 4 Then ssh_TeaseTick = ssh_randomizer.Next(30, 46) * 60
						If FrmSettings.domlevelNumBox.Value = 5 Then ssh_TeaseTick = ssh_randomizer.Next(45, 61) * 60


					Else

						ssh_TeaseTick = ssh_randomizer.Next(FrmSettings.NBTeaseLengthMin.Value * 60, FrmSettings.NBTeaseLengthMax.Value * 60)

					End If


					TeaseTimer.Start()

					If FrmSettings.LockOrgasmChances.Checked = True Then
						FrmSettings.alloworgasmComboBox.Enabled = False
						FrmSettings.ruinorgasmComboBox.Enabled = False
						FrmSettings.CBRangeOrgasm.Enabled = False
						FrmSettings.NBAllowOften.Enabled = False
						FrmSettings.NBAllowSometimes.Enabled = False
						FrmSettings.NBAllowRarely.Enabled = False
						FrmSettings.CBRangeRuin.Enabled = False
						FrmSettings.NBRuinOften.Enabled = False
						FrmSettings.NBRuinSometimes.Enabled = False
						FrmSettings.NBRuinRarely.Enabled = False
					End If

					If ssh_PlaylistFile.Count = 0 Then GoTo NoPlaylistStartFile

					If ssh_Playlist = False Or ssh_PlaylistFile(0).Contains("Random Start") Then

NoPlaylistStartFile:

						Dim StartList As New List(Of String)
						StartList.Clear()

						Dim ChastityStartCheck As String
						If My.Settings.Chastity = True Then
							ChastityStartCheck = "*_CHASTITY.txt"
						Else
							ChastityStartCheck = "*.txt"
						End If

						For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Stroke\Start\", FileIO.SearchOption.SearchTopLevelOnly, ChastityStartCheck)
							Dim TempStart As String = foundFile
							TempStart = TempStart.Replace(".txt", "")
							Do Until Not TempStart.Contains("\")
								TempStart = TempStart.Remove(0, 1)
							Loop
							For x As Integer = 0 To FrmSettings.CLBStartList.Items.Count - 1
								If My.Settings.Chastity = True Then
									If FrmSettings.CLBStartList.Items(x) = TempStart And FrmSettings.CLBStartList.GetItemChecked(x) = True Then
										StartList.Add(foundFile)
									End If
								Else
									If FrmSettings.CLBStartList.Items(x) = TempStart And FrmSettings.CLBStartList.GetItemChecked(x) = True And Not TempStart.Contains("_CHASTITY") Then
										StartList.Add(foundFile)
									End If
								End If

							Next
						Next

						If StartList.Count < 1 Then
							If My.Settings.Chastity = True Then
								ssh_FileText = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Scripts\Start_CHASTITY.txt"
							Else
								ssh_FileText = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Scripts\Start.txt"
							End If
						Else
							ssh_FileText = StartList(ssh_randomizer.Next(0, StartList.Count))
						End If

					Else
						Debug.Print("Start situation found")
						If ssh_PlaylistFile(0).Contains("Regular-TeaseAI-Script") Then
							ssh_FileText = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Stroke\Start\" & ssh_PlaylistFile(0)
							ssh_FileText = ssh_FileText.Replace(" Regular-TeaseAI-Script", "")
							ssh_FileText = ssh_FileText & ".txt"
						Else
							ssh_FileText = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Playlist\Start\" & ssh_PlaylistFile(0) & ".txt"
						End If
					End If

					If ssh_Playlist = True Then ssh_PlaylistCurrent += 1
					ssh_LastScriptCountdown = ssh_randomizer.Next(3, 5 * FrmSettings.domlevelNumBox.Value)

					If Directory.Exists(FrmSettings.LBLDomImageDir.Text) And ssh_SlideshowLoaded = False Then
						LoadDommeImageFolder()
					End If


					ssh_StrokeTauntVal = -1
					ssh_ScriptTick = 3
					ScriptTimer.Start()


				End If


			Next

		End If




		If ssh_SaidHello = False Then Return

		If UCase(ssh_ChatString) = UCase(FrmSettings.TBSafeword.Text) Then


			Dim SafeList As New List(Of String)

			For Each SafeFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Interrupt\Safeword\", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
				SafeList.Add(SafeFile)
			Next

			If SafeList.Count > 0 Then
				StopEverything()
				ssh_FileText = SafeList(ssh_randomizer.Next(0, SafeList.Count))
				ssh_ShowModule = True
				ssh_StrokeTauntVal = -1
				ssh_ScriptTick = 2
				ScriptTimer.Start()
			Else
				MessageBox.Show(Me, "No files were found in " & Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Interrupt\Safeword!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End If
			Return
		End If

		If UCase(ssh_ChatString).Contains(UCase("stop")) Then TnASlides.Stop()

		' If UCase(ChatString).Contains(UCase("stop")) Then
		'If CustomSlideshow = True Then CustomSlideshowTimer.Stop()
		'End If


WritingTaskLine:

		If ssh_WritingTaskFlag = True Then


			If ssh_ChatString = LBLWritingTaskText.Text Then

				ssh_WritingTaskLinesWritten += 1
				ssh_WritingTaskLinesRemaining -= 1

				LBLLinesWritten.Text = ssh_WritingTaskLinesWritten
				LBLLinesRemaining.Text = ssh_WritingTaskLinesRemaining

				If ssh_SubWroteLast = True And FrmSettings.shownamesCheckBox.Checked = False Then
					ssh_Chat = "<body bgcolor=""" & Color2Html(My.Settings.ChatWindowColor) & """>" & ssh_Chat & "</body>"
					If CBWritingProgress.Checked = True Then
						ssh_Chat = "<font face=""" & FrmSettings.FontComboBox.Text & """ size=""" & FrmSettings.NBFontSize.Value & """ color=""#000000"">" & ssh_Chat & ssh_ChatString & "<br></font> " _
										& "<font face=""" & FrmSettings.FontComboBox.Text & """ size=""" & FrmSettings.NBFontSize.Value & """ color=""#006400"">" & "Correct: " & ssh_WritingTaskLinesRemaining & " lines remaining<br></font>"
						If FrmSettings.TimedWriting.Checked = True And ssh_WritingTaskCurrentTime < 1 Then ssh_Chat = ssh_Chat.Replace("Correct: " & ssh_WritingTaskLinesRemaining & " lines remaining", "Time Expired")
						ssh_Chat = ssh_Chat.Replace(" 1 lines", " 1 line")
						ssh_Chat = ssh_Chat.Replace(" 0 lines remaining", " Task Completed")
					Else
						ssh_Chat = "<font face=""" & FrmSettings.FontComboBox.Text & """ size=""" & FrmSettings.NBFontSize.Value & """ color=""#000000"">" & ssh_Chat & ssh_ChatString & "<br></font>"
					End If

					ChatText.DocumentText = ssh_Chat
					ChatText2.DocumentText = ssh_Chat
					ChatReadyState()

				Else
					ssh_Chat = "<body bgcolor=""" & Color2Html(My.Settings.ChatWindowColor) & """>" & ssh_Chat & "</body>"

					If CBWritingProgress.Checked = True Then
						ssh_Chat = ssh_Chat & "<font face=""Cambria"" size=""3"" font color=""" &
						 My.Settings.SubColor & """><b>" & subName.Text & ": </b></font><font face=""" & FrmSettings.FontComboBox.Text & """ size=""" & FrmSettings.NBFontSize.Value & """ color=""#000000"">" & ssh_ChatString & "<br></font>" _
						 & "<font face=""" & FrmSettings.FontComboBox.Text & """ size=""" & FrmSettings.NBFontSize.Value & """ color=""#006400"">" & "Correct: " & ssh_WritingTaskLinesRemaining & " lines remaining<br></font>"
						If FrmSettings.TimedWriting.Checked = True And ssh_WritingTaskCurrentTime < 1 Then ssh_Chat = ssh_Chat.Replace("Correct: " & ssh_WritingTaskLinesRemaining & " lines remaining", "Time Expired")
						ssh_Chat = ssh_Chat.Replace(" 1 lines", " 1 line")
						ssh_Chat = ssh_Chat.Replace(" 0 lines remaining", " Task Completed")
					Else
						ssh_Chat = ssh_Chat & "<font face=""Cambria"" size=""3"" font color=""" &
						 My.Settings.SubColor & """><b>" & subName.Text & ": </b></font><font face=""" & FrmSettings.FontComboBox.Text & """ size=""" & FrmSettings.NBFontSize.Value & """ color=""#000000"">" & ssh_ChatString & "<br></font>"
					End If

					ChatText.DocumentText = ssh_Chat
					ChatText2.DocumentText = ssh_Chat
					ChatReadyState()

				End If

				If FrmSettings.CBAutosaveChatlog.Checked = True Then My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Chatlogs\Autosave.html", ChatText.DocumentText, False)

				If ssh_IsTyping = True Then

					ChatText.DocumentText = ssh_Chat & "<font color=""DimGray""><i>" & domName.Text & " is typing...</i></font>"
					ChatText2.DocumentText = ssh_Chat & "<font color=""DimGray""><i>" & domName.Text & " is typing...</i></font>"
					ChatReadyState()
				End If

				chatBox.Text = ""
				ChatBox2.Text = ""

				ssh_SubWroteLast = True


				If ssh_WritingTaskLinesRemaining = 0 Then
					ClearWriteTask()
					ssh_ScriptTick = 3
					ScriptTimer.Start()
				End If

				If ssh_WritingTaskCurrentTime < 1 And My.Settings.TimedWriting = True And ssh_WritingTaskFlag = True Then
					ClearWriteTask()
					ssh_SkipGotoLine = True
					ssh_FileGoto = "Failed Writing Task"
					GetGoto()
					ssh_ScriptTick = 4
					ScriptTimer.Start()
				End If


			Else

				If ssh_SubWroteLast = True And FrmSettings.shownamesCheckBox.Checked = False Then

					If CBWritingProgress.Checked = True Then
						ssh_Chat = "<font face=""" & FrmSettings.FontComboBox.Text & """ size=""" & FrmSettings.NBFontSize.Value & """ color=""#000000"">" & ssh_Chat & "</font><font color=""#FF0000"">" & ssh_ChatString & "<br></font>" &
						"<font face=""" & FrmSettings.FontComboBox.Text & """ size=""" & FrmSettings.NBFontSize.Value & """ color=""#CD0000"">" & "Wrong: " & (ssh_WritingTaskMistakesAllowed - ssh_WritingTaskMistakesMade) - 1 &
						" mistakes remaining<br></font>"
						If FrmSettings.TimedWriting.Checked = True And ssh_WritingTaskCurrentTime < 1 Then ssh_Chat = ssh_Chat.Replace("Wrong: " & (ssh_WritingTaskMistakesAllowed - ssh_WritingTaskMistakesMade) - 1 & " mistakes remaining", "Time Expired")
						ssh_Chat = ssh_Chat.Replace(" 1 mistakes", " 1 mistake")
						ssh_Chat = ssh_Chat.Replace(" 0 mistakes remaining", " Task Failed")
					Else
						ssh_Chat = "<font face=""" & FrmSettings.FontComboBox.Text & """ size=""" & FrmSettings.NBFontSize.Value & """ color=""#000000"">" & ssh_Chat & "</font><font color=""#FF0000"">" & ssh_ChatString & "<br></font>"
					End If

					ssh_Chat = "<body bgcolor=""" & Color2Html(My.Settings.ChatWindowColor) & """>" & ssh_Chat & "</body>"
					ChatText.DocumentText = ssh_Chat
					ChatText2.DocumentText = ssh_Chat
					ChatReadyState()

				Else

					If CBWritingProgress.Checked = True Then
						ssh_Chat = ssh_Chat & "<font face=""Cambria"" size=""3"" font color=""" &
						   My.Settings.SubColor & """><b>" & subName.Text & ": </b></font><font face=""" & FrmSettings.FontComboBox.Text & """ size=""" & FrmSettings.NBFontSize.Value & """ color=""#FF0000"">" & ssh_ChatString & "<br></font>" &
						  "<font face=""" & FrmSettings.FontComboBox.Text & """ size=""" & FrmSettings.NBFontSize.Value & """ color=""#CD0000"">" & "Wrong: " & (ssh_WritingTaskMistakesAllowed - ssh_WritingTaskMistakesMade) - 1 &
						  " mistakes remaining<br></font>"
						If FrmSettings.TimedWriting.Checked = True And ssh_WritingTaskCurrentTime < 1 Then ssh_Chat = ssh_Chat.Replace("Wrong: " & (ssh_WritingTaskMistakesAllowed - ssh_WritingTaskMistakesMade) - 1 & " mistakes remaining", "Time Expired")
						ssh_Chat = ssh_Chat.Replace(" 1 mistakes", " 1 mistake")
						ssh_Chat = ssh_Chat.Replace(" 0 mistakes remaining", " Task Failed")
					Else
						ssh_Chat = ssh_Chat & "<font face=""Cambria"" size=""3"" font color=""" &
						 My.Settings.SubColor & """><b>" & subName.Text & ": </b></font><font face=""" & FrmSettings.FontComboBox.Text & """ size=""" & FrmSettings.NBFontSize.Value & """ color=""#FF0000"">" & ssh_ChatString & "<br></font>"
					End If

					ssh_Chat = "<body bgcolor=""" & Color2Html(My.Settings.ChatWindowColor) & """>" & ssh_Chat & "</body>"
					ChatText.DocumentText = ssh_Chat
					ChatText2.DocumentText = ssh_Chat
					ChatReadyState()

				End If

				If FrmSettings.CBAutosaveChatlog.Checked = True Then My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Chatlogs\Autosave.html", ChatText.DocumentText, False)

				If ssh_IsTyping = True Then

					ChatText.DocumentText = ssh_Chat & "<font color=""DimGray""><i>" & domName.Text & " is typing...</i></font>"
					ChatText2.DocumentText = ssh_Chat & "<font color=""DimGray""><i>" & domName.Text & " is typing...</i></font>"
					ChatReadyState()
				End If

				ssh_SubWroteLast = True

				ssh_WritingTaskMistakesMade += 1
				LBLMistakesMade.Text = ssh_WritingTaskMistakesMade

				If ssh_WritingTaskMistakesMade = ssh_WritingTaskMistakesAllowed Then
					ClearWriteTask()
					ssh_SkipGotoLine = True
					ssh_FileGoto = "Failed Writing Task"
					GetGoto()
					ssh_ScriptTick = 4
					ScriptTimer.Start()
				End If

				If ssh_WritingTaskCurrentTime < 1 And My.Settings.TimedWriting = True And ssh_WritingTaskFlag = True Then
					ClearWriteTask()
					ssh_SkipGotoLine = True
					ssh_FileGoto = "Failed Writing Task"
					GetGoto()
					ssh_ScriptTick = 4
					ScriptTimer.Start()
				End If

			End If

		End If

		If ssh_AFK = True Then Return

		' Previous Commas





		Dim EdgeList As New List(Of String)
		EdgeList = Txt2List(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Vocabulary\Responses\System\EdgeKEY.txt")



		Dim EdgeCheck As String = ssh_ChatString

		Dim EdgeString As String

		Debug.Print("EdgeFOund 1 = " & ssh_EdgeFound)

		For i As Integer = 0 To EdgeList.Count - 1
			EdgeString = EdgeList(i)
			EdgeString = EdgeString.Replace("'", "")
			EdgeString = EdgeString.Replace(".", "")
			EdgeString = EdgeString.Replace(",", "")
			EdgeString = EdgeString.Replace("!", "")
			Debug.Print("UCase(EdgeString)  = " & UCase(EdgeString))
			Debug.Print("EdgeCheck  = " & UCase(EdgeCheck))
			If UCase(EdgeCheck).Contains("DONT") Or UCase(EdgeCheck).Contains("NEVER") Or UCase(EdgeCheck).Contains("NOT") Then
				If UCase(EdgeCheck).Contains(UCase(EdgeString)) Then
					ssh_EdgeNOT = True
					Exit For
				End If
			End If
			If UCase(EdgeString) = UCase(EdgeCheck) Then
				ssh_EdgeFound = True
				Exit For
			End If
		Next

		Debug.Print("EdgeFOund 2 = " & ssh_EdgeFound)

		If ssh_EdgeFound = True And My.Settings.Chastity = False Then



			Debug.Print("EdgeFOund = True Called")

			ssh_EdgeFound = False


			If ssh_SubHoldingEdge = True Then
				Debug.Print("EdgeFOund = SubHoldingedge")
				ssh_DomChat = " #YoureAlreadySupposedToBeClose"
				TypingDelay()
				Return
			End If

			SetVariable("SYS_EdgeTotal", Val(GetVariable("SYS_EdgeTotal") + 1))

			If ssh_TauntEdging = True And ssh_SubEdging = False And ssh_ShowModule = False Then
				ssh_DomChat = "#SYS_TauntEdgingAsked"
				TypingDelay()

				' Recalculate TantEdging-Chance
				If ssh_randomizer.Next(1, 101) <= FrmSettings.NBTauntEdging.Value Then
					ssh_TauntEdging = False
				End If

				Exit Sub
			End If


			If ssh_EdgeVideo = True Then
				ssh_SessionEdges += 1
				ssh_EdgeVideo = False
				ssh_TeaseVideo = False
				VideoTimer.Stop()
				DomWMP.Visible = False
				DomWMP.Ctlcontrols.stop()
				mainPictureBox.Visible = True
				ssh_FileGoto = ssh_EdgeGotoLine
				ssh_SkipGotoLine = True
				GetGoto()
				Return
			End If

			If ssh_EdgeGoto = True Then
				ssh_SessionEdges += 1
				ssh_EdgeGoto = False
				ssh_FileGoto = ssh_EdgeGotoLine
				ssh_SkipGotoLine = True
				GetGoto()
				Return
			End If

			If ssh_EdgeMessage = True Then
				ssh_SessionEdges += 1
				ssh_EdgeMessage = False
				ssh_ChatString = ssh_EdgeMessageText
				GoTo DebugAwareness
			End If

			'EdgeMessageYesNo = EdgeArray(1)

			If ssh_RLGLGame = True Then
				Debug.Print("EdgeFOund = RLGL")
				ssh_DomChat = "#TryToHoldIt"
				TypingDelay()
				Return
			End If


			If ssh_AvoidTheEdgeStroking = True Then

				Debug.Print("EdgeFOund = ATE")

				AvoidTheEdgeTaunts.Stop()

				ssh_AvoidTheEdgeStroking = False
				ssh_VideoTease = False

				Dim ATEList As New List(Of String)

				For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Video\Avoid The Edge\Scripts\", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
					ATEList.Add(foundFile)
				Next

				If ATEList.Count < 1 Then
					MessageBox.Show(Me, "No Avoid The Edge scripts were found!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					Return
				End If

				DomWMP.Ctlcontrols.pause()

				ssh_StrokeTauntVal = -1
				ssh_FileText = ATEList(ssh_randomizer.Next(0, ATEList.Count))

				ssh_ScriptTick = 2
				ScriptTimer.Start()
				Return
			End If


			If ssh_SubEdging = True Then

				Debug.Print("EdgeFOund = SubEdging")

				EdgeCountTimer.Stop()

				If ssh_MultipleEdges = True Then
					ssh_MultipleEdgesAmount -= 1
					ssh_SessionEdges += 1

					If ssh_MultipleEdgesAmount < 1 Then

						ssh_MultipleEdges = False

					Else

						EdgeCountTimer.Stop()
						ssh_DomChat = "#SYS_MultipleEdgesStop"
						If ssh_Contact1Edge = True Then ssh_DomChat = "@Contact1 #SYS_MultipleEdgesStop"
						If ssh_Contact2Edge = True Then ssh_DomChat = "@Contact2 #SYS_MultipleEdgesStop"
						If ssh_Contact3Edge = True Then ssh_DomChat = "@Contact3 #SYS_MultipleEdgesStop"
						TypingDelay()
						ssh_MultipleEdgesTick = ssh_MultipleEdgesInterval
						MultipleEdgesTimer.Start()
						ssh_MultipleEdgesMetronome = "STOP"
						Return

					End If


				End If

				If ssh_SubStroking = True Then
					ssh_AvgEdgeCount += 1
					If ssh_AvgEdgeStroking = 0 Then
						ssh_AvgEdgeStroking = ssh_EdgeCountTick
					Else
						ssh_AvgEdgeStroking = (ssh_AvgEdgeStroking + ssh_EdgeCountTick) / ssh_AvgEdgeCount
					End If
					My.Settings.AvgEdgeStroking = ssh_AvgEdgeStroking
					My.Settings.AvgEdgeCount = ssh_AvgEdgeCount
				Else
					ssh_AvgEdgeCountRest += 1
					If ssh_AvgEdgeNoTouch = 0 Then
						ssh_AvgEdgeNoTouch = ssh_EdgeCountTick
					Else
						ssh_AvgEdgeNoTouch = (ssh_AvgEdgeNoTouch + ssh_EdgeCountTick) / ssh_AvgEdgeCountRest
					End If
					My.Settings.AvgEdgeNoTouch = ssh_AvgEdgeNoTouch
					My.Settings.AvgEdgeCountRest = ssh_AvgEdgeCountRest
				End If


				If My.Settings.AvgEdgeCount > 4 Then
					ssh_AvgEdgeStroking = My.Settings.AvgEdgeStroking
					Dim TS1 As TimeSpan = TimeSpan.FromSeconds(ssh_AvgEdgeStroking)
					FrmSettings.LBLAvgEdgeStroking.Text = String.Format("{0:00}:{1:00}", TS1.Minutes, TS1.Seconds)
				Else
					FrmSettings.LBLAvgEdgeStroking.Text = "WAIT"
				End If

				If My.Settings.AvgEdgeCountRest > 4 Then
					ssh_AvgEdgeNoTouch = My.Settings.AvgEdgeNoTouch
					Dim TS2 As TimeSpan = TimeSpan.FromSeconds(ssh_AvgEdgeNoTouch)
					FrmSettings.LBLAvgEdgeNoTouch.Text = String.Format("{0:00}:{1:00}", TS2.Minutes, TS2.Seconds)
				Else
					FrmSettings.LBLAvgEdgeNoTouch.Text = "WAIT"
				End If

				If FrmSettings.domlevelNumBox.Value = 1 Then ssh_HoldEdgeChance = 20
				If FrmSettings.domlevelNumBox.Value = 2 Then ssh_HoldEdgeChance = 25
				If FrmSettings.domlevelNumBox.Value = 3 Then ssh_HoldEdgeChance = 30
				If FrmSettings.domlevelNumBox.Value = 4 Then ssh_HoldEdgeChance = 40
				If FrmSettings.domlevelNumBox.Value = 5 Then ssh_HoldEdgeChance = 50

				Dim HoldEdgeInt As Integer = ssh_randomizer.Next(1, 101)

				If ssh_EdgeHold = True Then HoldEdgeInt = 0
				If ssh_EdgeNoHold = True Then HoldEdgeInt = 1000


				Debug.Print("HoldEdgeInt = " & HoldEdgeInt)

				ssh_EdgeHold = False
				ssh_EdgeNoHold = False



				If HoldEdgeInt < ssh_HoldEdgeChance Then

					Debug.Print("EdgeFOund = HOldtheedge")

					ssh_DomTypeCheck = True
					ssh_SubEdging = False
					ssh_SubStroking = False
					ssh_SubHoldingEdge = True
					EdgeTauntTimer.Stop()
					ssh_DomChat = "#HoldTheEdge"
					If ssh_Contact1Edge = True Then
						ssh_DomChat = "@Contact1 #HoldTheEdge"
						' Github Patch Contact1Edge = False
					End If
					If ssh_Contact2Edge = True Then
						ssh_DomChat = "@Contact2 #HoldTheEdge"
						' github Patch Contact2Edge = False
					End If
					If ssh_Contact3Edge = True Then
						ssh_DomChat = "@Contact3 #HoldTheEdge"
						' github patch Contact3Edge = False
					End If
					TypingDelay()


					If ssh_EdgeHoldFlag = False Then

						ssh_HoldEdgeTick = ssh_HoldEdgeChance

						Dim HoldEdgeMin As Integer
						Dim HoldEdgeMax As Integer

						HoldEdgeMin = FrmSettings.NBHoldTheEdgeMin.Value
						If FrmSettings.LBLMinHold.Text = "minutes" Then HoldEdgeMin *= 60

						HoldEdgeMax = FrmSettings.NBHoldTheEdgeMax.Value
						If FrmSettings.LBLMaxHold.Text = "minutes" Then HoldEdgeMax *= 60


						If ssh_ExtremeHold = True Then
							HoldEdgeMin = FrmSettings.NBExtremeHoldMin.Value * 60
							HoldEdgeMax = FrmSettings.NBExtremeHoldMax.Value * 60
						End If

						If ssh_LongHold = True Then
							HoldEdgeMin = FrmSettings.NBLongHoldMin.Value * 60
							HoldEdgeMax = FrmSettings.NBLongHoldMax.Value * 60
						End If

						If HoldEdgeMax < HoldEdgeMin Then HoldEdgeMax = HoldEdgeMin + 1

						ssh_HoldEdgeTick = ssh_randomizer.Next(HoldEdgeMin, HoldEdgeMax + 1)

						If ssh_HoldEdgeTick < 10 Then ssh_HoldEdgeTick = 10

					Else

						ssh_HoldEdgeTick = ssh_EdgeHoldSeconds
						ssh_EdgeHoldFlag = False

					End If

					ssh_HoldEdgeTime = 0

					HoldEdgeTimer.Start()
					HoldEdgeTauntTimer.Start()
					Return

				Else

					If ssh_EdgeToRuin = True Or ssh_OrgasmRuined = True Then
						ssh_LastOrgasmType = "RUINED"
						ssh_OrgasmRuined = False
						GoTo RuinedOrgasm
					End If

					If ssh_OrgasmAllowed = True Then
						ssh_LastOrgasmType = "ALLOWED"
						ssh_OrgasmAllowed = False
						GoTo AllowedOrgasm
					End If


					Debug.Print("Ruined Orgasm skipped")

					If ssh_OrgasmDenied = True Then

						ssh_LastOrgasmType = "DENIED"

						If FrmSettings.CBDomDenialEnds.Checked = False And ssh_TeaseTick < 1 Then

							Dim RepeatChance As Integer = ssh_randomizer.Next(0, 101)

							If RepeatChance < 10 * FrmSettings.domlevelNumBox.Value Then
								ssh_SubEdging = False
								ssh_SubStroking = False
								EdgeTauntTimer.Stop()

								Dim RepeatList As New List(Of String)

								For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Interrupt\Denial Continue\", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
									RepeatList.Add(foundFile)
								Next

								If RepeatList.Count < 1 Then GoTo NoRepeatFiles


								If FrmSettings.CBTeaseLengthDD.Checked = True Then
									If FrmSettings.domlevelNumBox.Value = 1 Then ssh_TeaseTick = ssh_randomizer.Next(10, 16) * 60
									If FrmSettings.domlevelNumBox.Value = 2 Then ssh_TeaseTick = ssh_randomizer.Next(15, 21) * 60
									If FrmSettings.domlevelNumBox.Value = 3 Then ssh_TeaseTick = ssh_randomizer.Next(20, 31) * 60
									If FrmSettings.domlevelNumBox.Value = 4 Then ssh_TeaseTick = ssh_randomizer.Next(30, 46) * 60
									If FrmSettings.domlevelNumBox.Value = 5 Then ssh_TeaseTick = ssh_randomizer.Next(45, 61) * 60
								Else
									ssh_TeaseTick = ssh_randomizer.Next(FrmSettings.NBTeaseLengthMin.Value * 60, FrmSettings.NBTeaseLengthMax.Value * 60)
								End If
								TeaseTimer.Start()

								ssh_OrgasmYesNo = False

								'Github Patch
								ssh_YesOrNo = False

								'ShowModule = True
								ssh_StrokeTauntVal = -1
								ssh_FileText = RepeatList(ssh_randomizer.Next(0, RepeatList.Count))
								ssh_ScriptTick = 2
								ScriptTimer.Start()
								ssh_OrgasmDenied = False
								ssh_OrgasmYesNo = False
								ssh_EndTease = False
								Return
							End If

						End If


					End If

NoRepeatFiles:

					ssh_DomTypeCheck = True
					ssh_OrgasmYesNo = False
					ssh_SubEdging = False
					ssh_SubStroking = False
					EdgeTauntTimer.Stop()
					ssh_DomChat = "#StopStrokingEdge"
					If ssh_Contact1Edge = True Then
						ssh_DomChat = "@Contact1 #StopStrokingEdge"
						ssh_Contact1Edge = False
					End If
					If ssh_Contact2Edge = True Then
						ssh_DomChat = "@Contact2 #StopStrokingEdge"
						ssh_Contact2Edge = False
					End If
					If ssh_Contact3Edge = True Then
						ssh_DomChat = "@Contact3 #StopStrokingEdge"
						ssh_Contact3Edge = False
					End If
					TypingDelay()
					Return

				End If

RuinedOrgasm:

				My.Settings.LastRuined = FormatDateTime(Now, DateFormat.ShortDate)
				FrmSettings.LBLLastRuined.Text = My.Settings.LastRuined

				If FrmSettings.CBDomOrgasmEnds.Checked = False And ssh_OrgasmRuined = True And ssh_TeaseTick < 1 Then

					Dim RepeatChance As Integer = ssh_randomizer.Next(0, 101)

					If RepeatChance < 8 * FrmSettings.domlevelNumBox.Value Then

						ssh_SubEdging = False
						ssh_SubStroking = False
						ssh_EdgeToRuin = False
						ssh_EdgeToRuinSecret = True
						EdgeTauntTimer.Stop()

						Dim RepeatList As New List(Of String)

						For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Interrupt\Ruin Continue\", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
							RepeatList.Add(foundFile)
						Next

						If RepeatList.Count < 1 Then GoTo NoRepeatRFiles


						If FrmSettings.CBTeaseLengthDD.Checked = True Then
							If FrmSettings.domlevelNumBox.Value = 1 Then ssh_TeaseTick = ssh_randomizer.Next(10, 16) * 60
							If FrmSettings.domlevelNumBox.Value = 2 Then ssh_TeaseTick = ssh_randomizer.Next(15, 21) * 60
							If FrmSettings.domlevelNumBox.Value = 3 Then ssh_TeaseTick = ssh_randomizer.Next(20, 31) * 60
							If FrmSettings.domlevelNumBox.Value = 4 Then ssh_TeaseTick = ssh_randomizer.Next(30, 46) * 60
							If FrmSettings.domlevelNumBox.Value = 5 Then ssh_TeaseTick = ssh_randomizer.Next(45, 61) * 60
						Else
							ssh_TeaseTick = ssh_randomizer.Next(FrmSettings.NBTeaseLengthMin.Value * 60, FrmSettings.NBTeaseLengthMax.Value * 60)
						End If
						TeaseTimer.Start()

						ssh_OrgasmYesNo = False

						'Github Patch
						ssh_YesOrNo = False

						'ShowModule = True
						ssh_StrokeTauntVal = -1
						ssh_FileText = RepeatList(ssh_randomizer.Next(0, RepeatList.Count))
						ssh_ScriptTick = 2
						ScriptTimer.Start()
						ssh_OrgasmRuined = False
						ssh_OrgasmYesNo = False
						ssh_EndTease = False
						Return
					End If

				End If



NoRepeatRFiles:


				ssh_DomTypeCheck = True
				ssh_SubEdging = False
				ssh_SubStroking = False
				ssh_EdgeToRuin = False
				ssh_EdgeToRuinSecret = True
				EdgeTauntTimer.Stop()
				ssh_OrgasmYesNo = False
				ssh_DomChat = "#RuinYourOrgasm"
				If ssh_Contact1Edge = True Then
					ssh_DomChat = "@Contact1 #RuinYourOrgasm"
					ssh_Contact1Edge = False
				End If
				If ssh_Contact2Edge = True Then
					ssh_DomChat = "@Contact2 #RuinYourOrgasm"
					ssh_Contact2Edge = False
				End If
				If ssh_Contact3Edge = True Then
					ssh_DomChat = "@Contact3 #RuinYourOrgasm"
					ssh_Contact3Edge = False
				End If
				TypingDelay()
				Return

AllowedOrgasm:

				If My.Settings.OrgasmsLocked = True Then

					If My.Settings.OrgasmsRemaining < 1 Then

						Dim NoCumList As New List(Of String)

						For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Interrupt\Out of Orgasms\", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
							NoCumList.Add(foundFile)
						Next

						If NoCumList.Count < 1 Then GoTo NoNoCumFiles


						ssh_SubEdging = False
						ssh_SubStroking = False
						EdgeTauntTimer.Stop()
						ssh_OrgasmYesNo = False

						'Github Patch
						ssh_YesOrNo = False

						'ShowModule = True
						ssh_StrokeTauntVal = -1
						ssh_FileText = NoCumList(ssh_randomizer.Next(0, NoCumList.Count))
						ssh_ScriptTick = 2
						ScriptTimer.Start()
						Return
					End If


					My.Settings.OrgasmsRemaining -= 1


				End If

NoNoCumFiles:

				My.Settings.LastOrgasm = FormatDateTime(Now, DateFormat.ShortDate)
				FrmSettings.LBLLastOrgasm.Text = My.Settings.LastOrgasm

				If FrmSettings.CBDomOrgasmEnds.Checked = False And ssh_TeaseTick < 1 Then

					Dim RepeatChance As Integer = ssh_randomizer.Next(0, 101)

					If RepeatChance < 4 * FrmSettings.domlevelNumBox.Value Then
						ssh_SubEdging = False
						ssh_SubStroking = False
						EdgeTauntTimer.Stop()

						Dim RepeatList As New List(Of String)

						For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Interrupt\Orgasm Continue\", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
							RepeatList.Add(foundFile)
						Next

						If RepeatList.Count < 1 Then GoTo NoRepeatOFiles


						If FrmSettings.CBTeaseLengthDD.Checked = True Then
							If FrmSettings.domlevelNumBox.Value = 1 Then ssh_TeaseTick = ssh_randomizer.Next(10, 16) * 60
							If FrmSettings.domlevelNumBox.Value = 2 Then ssh_TeaseTick = ssh_randomizer.Next(15, 21) * 60
							If FrmSettings.domlevelNumBox.Value = 3 Then ssh_TeaseTick = ssh_randomizer.Next(20, 31) * 60
							If FrmSettings.domlevelNumBox.Value = 4 Then ssh_TeaseTick = ssh_randomizer.Next(30, 46) * 60
							If FrmSettings.domlevelNumBox.Value = 5 Then ssh_TeaseTick = ssh_randomizer.Next(45, 61) * 60
						Else
							ssh_TeaseTick = ssh_randomizer.Next(FrmSettings.NBTeaseLengthMin.Value * 60, FrmSettings.NBTeaseLengthMax.Value * 60)
						End If
						TeaseTimer.Start()

						ssh_OrgasmYesNo = False

						'Github Patch
						ssh_YesOrNo = False

						'ShowModule = True
						ssh_StrokeTauntVal = -1
						ssh_FileText = RepeatList(ssh_randomizer.Next(0, RepeatList.Count))
						ssh_ScriptTick = 2
						ScriptTimer.Start()
						ssh_OrgasmAllowed = False
						ssh_OrgasmYesNo = False
						ssh_EndTease = False
						Return
					End If

				End If



NoRepeatOFiles:








				ssh_DomTypeCheck = True
				ssh_SubEdging = False
				ssh_SubStroking = False
				'OrgasmAllowed = False
				EdgeTauntTimer.Stop()
				ssh_OrgasmYesNo = False
				ssh_DomChat = "#CumForMe"
				If ssh_Contact1Edge = True Then
					ssh_DomChat = "@Contact1 #CumForMe"
					ssh_Contact1Edge = False
				End If
				If ssh_Contact2Edge = True Then
					ssh_DomChat = "@Contact2 #CumForMe"
					ssh_Contact2Edge = False
				End If
				If ssh_Contact3Edge = True Then
					ssh_DomChat = "@Contact3 #CumForMe"
					ssh_Contact3Edge = False
				End If
				TypingDelay()
				Return


			End If



			If ssh_SubStroking = True Then

				Dim TauntStop As Integer = ssh_randomizer.Next(1, 101)

				If TauntStop <= FrmSettings.NBTauntEdging.Value Then

					ssh_FirstRound = False
					'ShowModule = True
					StrokeTauntTimer.Stop()
					StrokeTimer.Stop()


					If ssh_BookmarkModule = True Then
						ssh_DomTypeCheck = True
						ssh_SubEdging = False
						ssh_SubStroking = False
						ssh_DomChat = "#StopStrokingEdge"
						If ssh_Contact1Edge = True Then
							ssh_DomChat = "@Contact1 #StopStrokingEdge"
							ssh_Contact1Edge = False
						End If
						If ssh_Contact2Edge = True Then
							ssh_DomChat = "@Contact2 #StopStrokingEdge"
							ssh_Contact2Edge = False
						End If
						If ssh_Contact3Edge = True Then
							ssh_DomChat = "@Contact3 #StopStrokingEdge"
							ssh_Contact3Edge = False
						End If
						TypingDelay()

						Do
							Application.DoEvents()
						Loop Until ssh_DomTypeCheck = False

						ssh_BookmarkModule = False
						ssh_FileText = ssh_BookmarkModuleFile
						ssh_StrokeTauntVal = ssh_BookmarkModuleLine
						RunFileText()
						Return
					End If

					RunModuleScript(True)

				Else

					ssh_TauntEdging = True
					ssh_DomChat = "#SYS_TauntEdging"
					TypingDelay()

				End If



			End If


			Return

		End If


		If ssh_EdgeFound = True And My.Settings.Chastity = True Then
			ssh_EdgeFound = False
			ssh_EdgeNOT = True
		End If






DebugAwareness:



		If ssh_InputFlag = True And ssh_DomTypeCheck = False Then
			My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Variables\" & ssh_InputString, ssh_ChatString, False)
			ssh_InputFlag = False
		End If

		' Remove commas and apostrophes from user's entered text
		ssh_ChatString = ssh_ChatString.Replace(",", "")
		ssh_ChatString = ssh_ChatString.Replace("'", "")
		ssh_ChatString = ssh_ChatString.Replace(".", "")


		If UCase(ssh_ChatString) = UCase("CAME") Or UCase(ssh_ChatString) = UCase("I CAME") Or UCase(ssh_ChatString) = UCase("JUST CAME") Or UCase(ssh_ChatString) = UCase("I JUST CAME") Then
			If ssh_CameMessage = True Then
				ssh_CameMessage = False
				ssh_ChatString = ssh_CameMessageText
			End If
		End If

		If UCase(ssh_ChatString) = UCase("RUINED") Or UCase(ssh_ChatString) = UCase("I RUINED") Or UCase(ssh_ChatString) = UCase("RUINED IT") Or UCase(ssh_ChatString) = UCase("I RUINED IT") Then
			If ssh_RuinedMessage = True Then
				ssh_RuinedMessage = False
				ssh_ChatString = ssh_RuinedMessageText
			End If
		End If


		' If the domme is waiting for a response, go straight to this sub-routine instead
		If ssh_YesOrNo = True And ssh_SubEdging = True Then GoTo EdgeSkip
		If ssh_YesOrNo = True And ssh_SubHoldingEdge = True Then GoTo EdgeSkip

		If ssh_YesOrNo = True And ssh_OrgasmYesNo = False And ssh_DomTypeCheck = False Then
			YesOrNoQuestions()
			Return
		End If



EdgeSkip:

		Debug.Print("Before Dom Response, YesOrNo = " & ssh_YesOrNo)

		DomResponse()

		'CalculateResponse()

	End Sub

	Public Sub DomResponse()

		Debug.Print("DomResponse Called")


		If ssh_EdgeNOT = True Then
			ssh_EdgeNOT = False
			ssh_ResponseFile = (Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Vocabulary\Responses\System\EdgeNOT.txt")
			GoTo FoundResponse
		End If





		'If BeforeTease = True And CBDebugAwareness.Checked = False Then Return

		Dim CheckResponse As String = UCase(ssh_ChatString)
		CheckResponse = CheckResponse.Replace(UCase(domName.Text), "")
		CheckResponse = CheckResponse.Replace(UCase(FrmSettings.TBHonorific.Text), "")
		CheckResponse = CheckResponse.Replace("!", "")
		CheckResponse = CheckResponse.Replace("?", "")
		CheckResponse = CheckResponse.Replace(".", "")
		CheckResponse = CheckResponse.Replace("*", "")
		CheckResponse = CheckResponse.Replace("  ", " ")

		If Not CheckResponse = UCase("please") Then CheckResponse = CheckResponse.Replace(UCase("please"), "")
		If Not CheckResponse = UCase("fucking") Then CheckResponse = CheckResponse.Replace(UCase("fucking"), "")
		If Not CheckResponse = UCase("fuckin") Then CheckResponse = CheckResponse.Replace(UCase("fuckin"), "")


		Try
			If CheckResponse.Substring(0, 1) = " " Then
				Do Until CheckResponse.Substring(0, 1) <> " "
					CheckResponse = CheckResponse.Remove(0, 1)
				Loop
			End If
		Catch
		End Try
		Try
			If CheckResponse.Substring(CheckResponse.Length - 1) = " " Then
				Do Until CheckResponse.Substring(CheckResponse.Length - 1) <> " "
					CheckResponse = CheckResponse.Remove(CheckResponse.Length - 1)
				Loop
			End If
		Catch
		End Try

		If UCase(CheckResponse) = UCase("CAME") Or UCase(CheckResponse) = UCase("I CAME") Then
			If ssh_CameGoto = True Then
				ssh_CameGoto = False
				WaitTimer.Stop()
				If TimeoutTimer.Enabled = True Then
					TimeoutTimer.Stop()
					ssh_YesOrNo = False
					ssh_InputFlag = False
				End If
				ssh_FileGoto = ssh_CameGotoLine
				ssh_SkipGotoLine = True
				GetGoto()
				Return
			End If
			If ssh_CameVideo = True Then
				ssh_CameVideo = False
				ssh_TeaseVideo = False
				VideoTimer.Stop()
				DomWMP.Visible = False
				DomWMP.Ctlcontrols.stop()
				mainPictureBox.Visible = True
				ssh_FileGoto = ssh_CameGotoLine
				ssh_SkipGotoLine = True
				GetGoto()
				Return
			End If
		End If


		If UCase(CheckResponse) = UCase("RUINED") Or UCase(CheckResponse) = UCase("I RUINED") Or UCase(CheckResponse) = UCase("RUINED IT") Or UCase(CheckResponse) = UCase("I RUINED IT") Then
			If ssh_RuinedGoto = True Then
				ssh_RuinedGoto = False
				WaitTimer.Stop()
				If TimeoutTimer.Enabled = True Then
					TimeoutTimer.Stop()
					ssh_YesOrNo = False
					ssh_InputFlag = False
				End If
				ssh_FileGoto = ssh_RuinedGotoLine
				ssh_SkipGotoLine = True
				GetGoto()
				Return
			End If
			If ssh_RuinedVideo = True Then
				ssh_RuinedVideo = False
				ssh_TeaseVideo = False
				VideoTimer.Stop()
				DomWMP.Visible = False
				DomWMP.Ctlcontrols.stop()
				mainPictureBox.Visible = True
				ssh_FileGoto = ssh_RuinedGotoLine
				ssh_SkipGotoLine = True
				GetGoto()
				Return
			End If
		End If

		If ssh_Modes.Count > 0 Then
			If ssh_Modes.Keys.Contains(CheckResponse) Then
				If ssh_Modes(CheckResponse).Type.ToUpper.Contains("GOTO") Then
					WaitTimer.Stop()
					If TimeoutTimer.Enabled = True Then
						TimeoutTimer.Stop()
						ssh_YesOrNo = False
						ssh_InputFlag = False
					End If
					ssh_FileGoto = ssh_Modes(CheckResponse).GotoLine
					ssh_SkipGotoLine = True
					GetGoto()
					ssh_Modes.Remove(CheckResponse)
					Return
				End If
				If ssh_Modes(CheckResponse).Type.ToUpper.Contains("VIDEO") Then
					ssh_TeaseVideo = False
					VideoTimer.Stop()
					DomWMP.Visible = False
					DomWMP.Ctlcontrols.stop()
					mainPictureBox.Visible = True
					ssh_FileGoto = ssh_Modes(CheckResponse).GotoLine
					ssh_SkipGotoLine = True
					GetGoto()
					ssh_Modes.Remove(CheckResponse)
					Return
				End If
			End If
		End If


		ssh_ResponseFile = ""

		Dim YesSplit As String = FrmSettings.TBYes.Text

		Do
			YesSplit = YesSplit.Replace("  ", " ")
			YesSplit = YesSplit.Replace(" ,", ",")
			YesSplit = YesSplit.Replace(", ", ",")
			YesSplit = YesSplit.Replace("'", "")
		Loop Until Not YesSplit.Contains("  ") And Not YesSplit.Contains(", ") And Not YesSplit.Contains(" ,") And Not YesSplit.Contains("'")

		If ssh_YesGoto = True Then
			Dim SplitParts As String() = YesSplit.Split(New Char() {","c})
			For i As Integer = 0 To SplitParts.Count - 1
				If UCase(CheckResponse) = UCase(SplitParts(i)) Then
					ssh_YesGoto = False
					WaitTimer.Stop()
					If TimeoutTimer.Enabled = True Then
						TimeoutTimer.Stop()
						ssh_YesOrNo = False
						ssh_InputFlag = False
					End If
					ssh_FileGoto = ssh_YesGotoLine
					ssh_SkipGotoLine = True
					GetGoto()
				End If
			Next
			If ssh_YesGoto = False Then Return
		End If

		If ssh_YesVideo = True Then
			Dim SplitParts As String() = YesSplit.Split(New Char() {","c})
			For i As Integer = 0 To SplitParts.Count - 1
				If UCase(CheckResponse) = UCase(SplitParts(i)) Then
					ssh_YesVideo = False
					ssh_TeaseVideo = False
					VideoTimer.Stop()
					DomWMP.Visible = False
					DomWMP.Ctlcontrols.stop()
					mainPictureBox.Visible = True
					ssh_FileGoto = ssh_YesGotoLine
					ssh_SkipGotoLine = True
					GetGoto()
				End If
			Next
			If ssh_YesVideo = False Then Return
		End If

		If ssh_ResponseYes <> "" And File.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Vocabulary\Responses\" & ssh_ResponseYes & ".txt") Then

			'Dim YesSplit As String = FrmSettings.TBYes.Text

			'Do
			'YesSplit = YesSplit.Replace("  ", " ")
			'YesSplit = YesSplit.Replace(" ,", ",")
			'YesSplit = YesSplit.Replace(", ", ",")
			'YesSplit = YesSplit.Replace("'", "")
			'Loop Until Not YesSplit.Contains("  ") And Not YesSplit.Contains(", ") And Not YesSplit.Contains(" ,") And Not YesSplit.Contains("'")

			Dim SplitParts As String() = YesSplit.Split(New Char() {","c})

			For i As Integer = 0 To SplitParts.Length - 1
				If UCase(CheckResponse) = UCase(SplitParts(i)) Then
					ssh_ResponseFile = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Vocabulary\Responses\" & ssh_ResponseYes & ".txt"
					GoTo FoundResponse
					Exit For
				End If
			Next
		End If

		Dim NoSplit As String = FrmSettings.TBNo.Text

		Do
			NoSplit = NoSplit.Replace("  ", " ")
			NoSplit = NoSplit.Replace(" ,", ",")
			NoSplit = NoSplit.Replace(", ", ",")
			NoSplit = NoSplit.Replace("'", "")
		Loop Until Not NoSplit.Contains("  ") And Not NoSplit.Contains(", ") And Not NoSplit.Contains(" ,") And Not NoSplit.Contains("'")

		If ssh_NoGoto = True Then
			Dim SplitParts As String() = NoSplit.Split(New Char() {","c})
			For i As Integer = 0 To SplitParts.Count - 1
				If UCase(CheckResponse) = UCase(SplitParts(i)) Then
					ssh_NoGoto = False
					WaitTimer.Stop()
					If TimeoutTimer.Enabled = True Then
						TimeoutTimer.Stop()
						ssh_YesOrNo = False
						ssh_InputFlag = False
					End If
					ssh_FileGoto = ssh_NoGotoLine
					ssh_SkipGotoLine = True
					GetGoto()
				End If
			Next
			If ssh_NoGoto = False Then Return
		End If

		If ssh_NoVideo_Mode = True Then
			Dim SplitParts As String() = NoSplit.Split(New Char() {","c})
			For i As Integer = 0 To SplitParts.Count - 1
				If UCase(CheckResponse) = UCase(SplitParts(i)) Then
					ssh_NoVideo_Mode = False
					ssh_TeaseVideo = False
					VideoTimer.Stop()
					DomWMP.Visible = False
					DomWMP.Ctlcontrols.stop()
					mainPictureBox.Visible = True
					ssh_FileGoto = ssh_NoGotoLine
					ssh_SkipGotoLine = True
					GetGoto()
				End If
			Next
			If ssh_NoVideo_Mode = False Then Return
		End If

		If ssh_ResponseNo <> "" And File.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Vocabulary\Responses\" & ssh_ResponseNo & ".txt") Then

			Dim SplitParts As String() = NoSplit.Split(New Char() {","c})

			For i As Integer = 0 To SplitParts.Length - 1
				If UCase(CheckResponse) = UCase(SplitParts(i)) Then
					ssh_ResponseFile = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Vocabulary\Responses\" & ssh_ResponseNo & ".txt"
					GoTo FoundResponse
					Exit For
				End If
			Next
		End If

		If ssh_BeforeTease = False Then
			If UCase(CheckResponse).Contains(UCase("I cum")) Or UCase(CheckResponse).Contains(UCase("me cum")) Or UCase(CheckResponse).Contains(UCase("I have an orgasm")) _
			 Or UCase(CheckResponse).Contains(UCase("me have an orgasm")) Then
				If ssh_TeaseTick > 0 Then
					ssh_ResponseFile = (Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Vocabulary\Responses\System\BegToCum.txt")
					If My.Settings.Chastity = False And ssh_OrgasmRestricted = False Then ssh_TeaseTick = ssh_TeaseTick / 2
					Debug.Print("LastScriptCountdown = " & ssh_LastScriptCountdown)
					If ssh_TeaseTick < 1 And ssh_Playlist = False And ssh_OrgasmRestricted = False Then
						StrokeTimer.Stop()
						StrokeTauntTimer.Stop()
						EdgeTauntTimer.Stop()
						ssh_SubStroking = False
						ssh_SubEdging = False
						RunLastBegScript()
						Return
					Else
						GoTo FoundResponse
					End If
				End If
			End If
		End If



		CheckResponse = CheckResponse.Replace("  ", " ")


		For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Vocabulary\Responses\System\", FileIO.SearchOption.SearchTopLevelOnly, "*KEY.txt")
			If Not foundFile = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Vocabulary\Responses\System\EdgeKEY.txt" Then

				Dim SysKeyList As New List(Of String)
				SysKeyList = Txt2List(foundFile)


				For i As Integer = 0 To SysKeyList.Count - 1

					SysKeyList(i) = SysKeyList(i).Replace(",", "")
					SysKeyList(i) = SysKeyList(i).Replace("'", "")
					SysKeyList(i) = SysKeyList(i).Replace("!", "")
					SysKeyList(i) = SysKeyList(i).Replace("?", "")
					SysKeyList(i) = SysKeyList(i).Replace(".", "")
					SysKeyList(i) = SysKeyList(i).Replace("*", "")
					SysKeyList(i) = SysKeyList(i).Replace("  ", " ")

					If UCase(CheckResponse) = UCase(SysKeyList(i)) Then
						ssh_ResponseFile = foundFile
						ssh_ResponseFile = ssh_ResponseFile.Replace("KEY", "")
						'QUESTION: (Stefaf) What does the following line?
						If UCase(CheckResponse).Contains("DONT") Or UCase(CheckResponse).Contains("NEVER") Or UCase(CheckResponse).Contains("NOT") Then ssh_ResponseFile = ssh_ResponseFile.Replace(".txt", "NOT.txt")
						GoTo FoundResponse
						Exit For
					End If
				Next
			End If

		Next

		' If frmApps.CBDebugAwareness.Checked = True Then GoTo DebugAwarenessStep2

		For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Vocabulary\Responses\", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")

			' Read the first line of the given file.
			Dim SplitText As String = TxtReadLine(foundFile)

			Dim SplitResponse As String() = SplitText.Split(New Char() {"]"c})
			SplitResponse(0) = SplitResponse(0).Replace("[", "")

			Do
				SplitResponse(0) = SplitResponse(0).Replace("  ", " ")
				SplitResponse(0) = SplitResponse(0).Replace(" ,", ",")
				SplitResponse(0) = SplitResponse(0).Replace(", ", ",")
				SplitResponse(0) = SplitResponse(0).Replace("'", "")
			Loop Until Not SplitResponse(0).Contains("  ") And Not SplitResponse(0).Contains(", ") And Not SplitResponse(0).Contains(" ,") And Not SplitResponse(0).Contains("'")

			Dim SplitParts As String() = SplitResponse(0).Split(New Char() {","c})

			For i As Integer = 0 To SplitParts.Length - 1
				If UCase(CheckResponse) = UCase(SplitParts(i)) Then
					ssh_ResponseFile = foundFile
					GoTo FoundResponse
					Exit For
				End If
			Next

		Next

DebugAwarenessStep2:

		For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Vocabulary\Responses\System\", FileIO.SearchOption.SearchTopLevelOnly, "*KEY.txt")
			If Not foundFile = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Vocabulary\Responses\System\EdgeKEY.txt" Then



				Dim SysKeyList As New List(Of String)
				SysKeyList = Txt2List(foundFile)


				For i As Integer = 0 To SysKeyList.Count - 1

					SysKeyList(i) = SysKeyList(i).Replace(",", "")
					SysKeyList(i) = SysKeyList(i).Replace("'", "")
					SysKeyList(i) = SysKeyList(i).Replace("!", "")
					SysKeyList(i) = SysKeyList(i).Replace("?", "")
					SysKeyList(i) = SysKeyList(i).Replace(".", "")
					SysKeyList(i) = SysKeyList(i).Replace("*", "")
					SysKeyList(i) = SysKeyList(i).Replace("  ", " ")

					If UCase(CheckResponse).Contains(UCase(SysKeyList(i))) Then
						ssh_ResponseFile = foundFile
						ssh_ResponseFile = ssh_ResponseFile.Replace("KEY", "")
						'QUESTION: (Stefaf) What does the following line?
						If UCase(CheckResponse).Contains("DONT") Or UCase(CheckResponse).Contains("NEVER") Or UCase(CheckResponse).Contains("NOT") Then ssh_ResponseFile = ssh_ResponseFile.Replace(".txt", "NOT.txt")
						GoTo FoundResponse
						Exit For
					End If
				Next
			End If
		Next


		'If frmApps.CBDebugAwareness.Checked = True Then GoTo FoundResponse

		Dim AccuracyLoop As Integer = 6



		For x As Integer = 0 To 5

			AccuracyLoop -= 1


			For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Vocabulary\Responses\", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")

				Application.DoEvents()

				' Read the first line of the given file.
				Dim SplitText As String = TxtReadLine(foundFile)

				Dim SplitResponse As String() = SplitText.Split(New Char() {"]"c})
				SplitResponse(0) = SplitResponse(0).Replace("[", "")

				Do
					SplitResponse(0) = SplitResponse(0).Replace("  ", " ")
					SplitResponse(0) = SplitResponse(0).Replace(" ,", ",")
					SplitResponse(0) = SplitResponse(0).Replace(", ", ",")
					SplitResponse(0) = SplitResponse(0).Replace("'", "")
				Loop Until Not SplitResponse(0).Contains("  ") And Not SplitResponse(0).Contains(", ") And Not SplitResponse(0).Contains(" ,") And Not SplitResponse(0).Contains("'")

				Dim SplitParts As String() = SplitResponse(0).Split(New Char() {","c})




				For i As Integer = 0 To SplitParts.Length - 1
					'Debug.Print("SplitParts(i) = " & SplitParts(i) & " SplitParts(i).Length = " & SplitParts(i).Length & "AccuracyLoop = " & AccuracyLoop)
					If UCase(CheckResponse).Contains(UCase(SplitParts(i))) And CountWords(SplitParts(i)) > AccuracyLoop Then
						ssh_ResponseFile = foundFile
						GoTo FoundResponse
						Exit For
					End If
				Next

			Next

		Next

		For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Vocabulary\Responses\", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")

			' Read the first line of the given file.
			Dim SplitText As String = TxtReadLine(foundFile)

			Dim SplitResponse As String() = SplitText.Split(New Char() {"]"c})
			SplitResponse(0) = SplitResponse(0).Replace("[", "")

			Do
				SplitResponse(0) = SplitResponse(0).Replace("  ", " ")
				SplitResponse(0) = SplitResponse(0).Replace(" ,", ",")
				SplitResponse(0) = SplitResponse(0).Replace(", ", ",")
				SplitResponse(0) = SplitResponse(0).Replace("'", "")
			Loop Until Not SplitResponse(0).Contains("  ") And Not SplitResponse(0).Contains(", ") And Not SplitResponse(0).Contains(" ,") And Not SplitResponse(0).Contains("'")

			Dim SplitParts As String() = SplitResponse(0).Split(New Char() {","c})

			For i As Integer = 0 To SplitParts.Length - 1

				Dim CheckResponseArray() As String = Split(UCase(SplitParts(i)))

				For j As Integer = 0 To CheckResponseArray.Length - 1
					ssh_ResponseFile = foundFile
					If Not UCase(CheckResponse).Contains(CheckResponseArray(j)) Then
						ssh_ResponseFile = ""
						Exit For
					End If
				Next

				If ssh_ResponseFile <> "" Then GoTo FoundResponse

			Next

		Next



		If ssh_CBTCockFlag = True Or ssh_CBTBallsFlag = True Or ssh_CBTBothFlag = True Or ssh_CustomTask = True Then
			ssh_TasksCount -= 1
			If ssh_TasksCount < 1 Then
				ssh_CBTCockFlag = False
				ssh_CBTBallsFlag = False
				ssh_CBTBothFlag = False
				ssh_CustomTask = False
				ssh_CBTBallsFirst = True
				ssh_CBTCockFirst = True
				ssh_CBTBothFirst = True
				ssh_CustomTaskFirst = True
				ssh_ScriptTick = 3
				ScriptTimer.Start()
			End If
		End If

		If ssh_CBTCockFlag = True Then
			CBTCock()
		End If

		If ssh_CBTBallsFlag = True Then
			CBTBalls()
		End If

		If ssh_CBTBothFlag = True Then
			CBTBoth()
		End If

		If ssh_CustomTask = True Then
			RunCustomTask()
		End If

		Return



		CheckResponse = CheckResponse.Replace(" ", "")


FoundResponse:

		' ResponseYes = ""
		' ResponseNo = ""

		'If frmApps.CBDebugAwareness.Checked = True Then
		'If DebugAwarenessLine = "Domme does not recognize this statement" Then
		'Chat = Chat & "<font color=""red"">" & DebugAwarenessLine & "<br>"
		'Else
		'Chat = Chat & "<font color=""green"">" & DebugAwarenessLine & "<br>"
		'End If
		'ChatText.DocumentText = Chat
		'Return
		'End If

		If StrokeTauntTimer.Enabled = True Then
			ssh_TempScriptCount = 0
			If FrmSettings.SliderSTF.Value = 1 Then ssh_StrokeTauntTick = ssh_randomizer.Next(120, 241)
			If FrmSettings.SliderSTF.Value = 2 Then ssh_StrokeTauntTick = ssh_randomizer.Next(75, 121)
			If FrmSettings.SliderSTF.Value = 3 Then ssh_StrokeTauntTick = ssh_randomizer.Next(45, 76)
			If FrmSettings.SliderSTF.Value = 4 Then ssh_StrokeTauntTick = ssh_randomizer.Next(25, 46)
			If FrmSettings.SliderSTF.Value = 5 Then ssh_StrokeTauntTick = ssh_randomizer.Next(15, 26)
		End If

		ssh_DomChat = ResponseClean(ssh_DomChat)

		If ssh_DomChat = "NULL" Then
			ssh_DomChat = ""
			Return
		End If

		'Debug.Print("DoNotDisturb = " & DoNotDisturb)
		'Debug.Print("DomChat = " & DomChat)

		If ssh_DoNotDisturb = True Then
			If ssh_DomChat.Contains("@Interrupt") Or ssh_DomChat.Contains("@Call(") Or ssh_DomChat.Contains("@CallRandom(") Then
				ssh_DomChat = "#SYS_InterruptsOff"
			End If
		End If




		TypingDelay()


	End Sub

	Public Function ResponseClean(ByVal CleanResponse As String) As String

		'TODO: Add Errorhandling.
		Dim DomResponse As New StreamReader(ssh_ResponseFile)
		Dim DRLines As New List(Of String)
		Dim DRLineTotal As Integer
		Dim SubState As String

		DRLineTotal = -1
		DRLines.Clear()

		Dim AddResponse As Boolean
		AddResponse = False

		If My.Settings.Chastity = True Then
			SubState = "Chastity"
			GoTo FoundState
		End If

		If ssh_BeforeTease = True Then
			SubState = "Before Tease"
			GoTo FoundState
		End If

		If ssh_FirstRound = True Then
			SubState = "First Round"
			GoTo FoundState
		End If

		If ssh_EndTease = True Then
			SubState = "After Tease"
			GoTo FoundState
		End If

		If ssh_CBTCockFlag = True Then
			SubState = "CBT Cock"
			GoTo FoundState
		End If

		If ssh_CBTBallsFlag = True Or ssh_CBTBothFlag = True Then
			SubState = "CBT Balls"
			GoTo FoundState
		End If

		If ssh_SubHoldingEdge = True Then
			SubState = "Sub Holding Edge"
			GoTo FoundState
		End If

		If ssh_SubEdging = True Then
			SubState = "Sub Edging"
			GoTo FoundState
		End If

		If ssh_SubStroking = True Then
			SubState = "Sub Stroking"
			GoTo FoundState
		End If

		SubState = "Not Stroking"

FoundState:


		If SubState = "Before Tease" Then

			While DomResponse.Peek <> -1
				DRLineTotal += 1
				DRLines.Add(DomResponse.ReadLine())
				If DRLines(DRLineTotal) = "[Before Tease]" Then
					AddResponse = True
				End If
				If DRLines(DRLineTotal) = "[Before Tease End]" Then
					AddResponse = False
				End If
				If AddResponse = False Or DRLines(DRLineTotal) = "[Before Tease]" Then
					DRLines.Remove(DRLines(DRLineTotal))
					DRLineTotal -= 1
				End If
			End While
		End If


		If SubState = "Chastity" Then

			While DomResponse.Peek <> -1
				DRLineTotal += 1
				DRLines.Add(DomResponse.ReadLine())
				If DRLines(DRLineTotal) = "[Chastity]" Then
					AddResponse = True
				End If
				If DRLines(DRLineTotal) = "[Chastity End]" Then
					AddResponse = False
				End If
				If AddResponse = False Or DRLines(DRLineTotal) = "[Chastity]" Then
					DRLines.Remove(DRLines(DRLineTotal))
					DRLineTotal -= 1
				End If
			End While
		End If

		If SubState = "First Round" Then

			While DomResponse.Peek <> -1
				DRLineTotal += 1
				DRLines.Add(DomResponse.ReadLine())
				If DRLines(DRLineTotal) = "[First Round]" Then
					AddResponse = True
				End If
				If DRLines(DRLineTotal) = "[First Round End]" Then
					AddResponse = False
				End If
				If AddResponse = False Or DRLines(DRLineTotal) = "[First Round]" Then
					DRLines.Remove(DRLines(DRLineTotal))
					DRLineTotal -= 1
				End If
			End While
		End If

		If SubState = "Sub Stroking" Then

			While DomResponse.Peek <> -1
				DRLineTotal += 1
				DRLines.Add(DomResponse.ReadLine())
				If DRLines(DRLineTotal) = "[Stroking]" Then
					AddResponse = True
				End If
				If DRLines(DRLineTotal) = "[Stroking End]" Then
					AddResponse = False
				End If
				If AddResponse = False Or DRLines(DRLineTotal) = "[Stroking]" Then
					DRLines.Remove(DRLines(DRLineTotal))
					DRLineTotal -= 1
				End If
			End While
		End If

		If SubState = "Not Stroking" Then

			While DomResponse.Peek <> -1
				DRLineTotal += 1
				DRLines.Add(DomResponse.ReadLine())
				If DRLines(DRLineTotal) = "[Not Stroking]" Then
					AddResponse = True
				End If
				If DRLines(DRLineTotal) = "[Not Stroking End]" Then
					AddResponse = False
				End If
				If AddResponse = False Or DRLines(DRLineTotal) = "[Not Stroking]" Then
					DRLines.Remove(DRLines(DRLineTotal))
					DRLineTotal -= 1
				End If
			End While
		End If

		If SubState = "Sub Edging" Then

			While DomResponse.Peek <> -1
				DRLineTotal += 1
				DRLines.Add(DomResponse.ReadLine())
				If DRLines(DRLineTotal) = "[Edging]" Then
					AddResponse = True
				End If
				If DRLines(DRLineTotal) = "[Edging End]" Then
					AddResponse = False
				End If
				If AddResponse = False Or DRLines(DRLineTotal) = "[Edging]" Then
					DRLines.Remove(DRLines(DRLineTotal))
					DRLineTotal -= 1
				End If
			End While
		End If

		If SubState = "Sub Holding Edge" Then

			While DomResponse.Peek <> -1
				DRLineTotal += 1
				DRLines.Add(DomResponse.ReadLine())
				If DRLines(DRLineTotal) = "[Holding The Edge]" Then
					AddResponse = True
				End If
				If DRLines(DRLineTotal) = "[Holding The Edge End]" Then
					AddResponse = False
				End If
				If AddResponse = False Or DRLines(DRLineTotal) = "[Holding The Edge]" Then
					DRLines.Remove(DRLines(DRLineTotal))
					DRLineTotal -= 1
				End If
			End While
		End If

		If SubState = "CBT Cock" Then

			While DomResponse.Peek <> -1
				DRLineTotal += 1
				DRLines.Add(DomResponse.ReadLine())
				If DRLines(DRLineTotal) = "[CBT Cock]" Then
					AddResponse = True
				End If
				If DRLines(DRLineTotal) = "[CBT Cock End]" Then
					AddResponse = False
				End If
				If AddResponse = False Or DRLines(DRLineTotal) = "[CBT Cock]" Then
					DRLines.Remove(DRLines(DRLineTotal))
					DRLineTotal -= 1
				End If
			End While
		End If

		If SubState = "CBT Balls" Then

			While DomResponse.Peek <> -1
				DRLineTotal += 1
				DRLines.Add(DomResponse.ReadLine())
				If DRLines(DRLineTotal) = "[CBT Balls]" Then
					AddResponse = True
				End If
				If DRLines(DRLineTotal) = "[CBT Balls End]" Then
					AddResponse = False
				End If
				If AddResponse = False Or DRLines(DRLineTotal) = "[CBT Balls]" Then
					DRLines.Remove(DRLines(DRLineTotal))
					DRLineTotal -= 1
				End If
			End While
		End If

		If SubState = "After Tease" Then

			While DomResponse.Peek <> -1
				DRLineTotal += 1
				DRLines.Add(DomResponse.ReadLine())
				If DRLines(DRLineTotal) = "[After Tease]" Then
					AddResponse = True
				End If
				If DRLines(DRLineTotal) = "[After Tease End]" Then
					AddResponse = False
				End If
				If AddResponse = False Or DRLines(DRLineTotal) = "[After Tease]" Then
					DRLines.Remove(DRLines(DRLineTotal))
					DRLineTotal -= 1
				End If
			End While
		End If

		If SubState <> "After Tease" And SubState <> "Before Tease" Then

			While DomResponse.Peek <> -1
				DRLineTotal += 1
				DRLines.Add(DomResponse.ReadLine())
				If DRLines(DRLineTotal) = "[All]" Then
					AddResponse = True
				End If
				If DRLines(DRLineTotal) = "[All End]" Then
					AddResponse = False
				End If
				If AddResponse = False Or DRLines(DRLineTotal) = "[All]" Then
					DRLines.Remove(DRLines(DRLineTotal))
					DRLineTotal -= 1
				End If
			End While

		End If



		DomResponse.Close()
		DomResponse.Dispose()


		Using DomResponseAll As New StreamReader(ssh_ResponseFile)

			While DomResponseAll.Peek <> -1
				DRLineTotal += 1
				DRLines.Add(DomResponseAll.ReadLine())
				If DRLines(DRLineTotal) = "[All]" Then
					AddResponse = True
				End If
				If DRLines(DRLineTotal) = "[All End]" Then
					AddResponse = False
				End If
				If AddResponse = False Or DRLines(DRLineTotal) = "[All]" Then
					DRLines.Remove(DRLines(DRLineTotal))
					DRLineTotal -= 1
				End If
			End While

		End Using

		' ###########

		If DRLines.Count < 1 Then
			CleanResponse = "NULL"
			GoTo NullSkip
		End If



		Try
			DRLines = FilterList(DRLines)
			ssh_ResponseLine = ssh_randomizer.Next(0, DRLines.Count)
			CleanResponse = DRLines(ssh_ResponseLine)
		Catch ex As Exception
			Log.WriteError("Tease AI did not return a valid Response line from file: " &
						   ssh_ResponseFile, ex, "ReponseClean(String)")
			CleanResponse = "ERROR: Tease AI did not return a valid Response line"
		End Try


		ssh_Responding = True

NullSkip:


		Return CleanResponse


	End Function



	Public Function CountWords(ByVal value As String) As Integer

		' Count matches.
		Dim collection As MatchCollection = Regex.Matches(value, "\S+")
		Return collection.Count

	End Function




	Public Sub YesOrNoQuestions()

		Dim TempChatString As String

		TempChatString = UCase(ssh_ChatString)

		If ssh_CBT = True Then
			If InStr(UCase(TempChatString), UCase("done")) <> 0 Or InStr(UCase(TempChatString), UCase("finish")) <> 0 Then
				ssh_YesOrNo = False
				ssh_CBT = False
				Return
			Else
				ssh_DomChat = "Hurry up and tell me when you're done"
				TypingDelay()
				Return
			End If
		End If

		Dim dir As String

		If ssh_MiniScript = True Then
			dir = ssh_MiniScriptText
		Else
			dir = ssh_FileText
		End If



		Dim AcceptLine As Integer

		' Read all lines of File
		Dim lines As List(Of String) = Txt2List(dir)
		Dim line As Integer

		If ssh_MiniScript = True Then
			line = ssh_MiniTauntVal
		Else
			line = ssh_StrokeTauntVal
		End If

		AcceptLine = 0

		Dim TempLineVal As Integer
		Do
			line += 1
			AcceptLine += 1
		Loop Until InStr(UCase(lines(line)), UCase("@AcceptAnswer")) <> 0 Or InStr(UCase(lines(line)), UCase("@DifferentAnswer")) <> 0


		TempLineVal = line

		If ssh_MiniScript = True Then
			line = ssh_MiniTauntVal
		Else
			line = ssh_StrokeTauntVal
		End If

		Dim CheckLines As String


		Do
			line += 1

			CheckLines = lines(line)


			ssh_CheckYes = False
			ssh_CheckNo = False

			If UCase(CheckLines).Contains(UCase("[yes]")) Then ssh_CheckYes = True
			If UCase(CheckLines).Contains(UCase("[no]")) Then ssh_CheckNo = True


			Dim Splits As String() = CheckLines.Split(New Char() {"]"c})
			Splits(0) = Splits(0).Replace("[", "")

			Dim ChatReplace As String = CheckLines.Replace("[" & Splits(0) & "]", "")

			If ssh_CheckYes = True Then Splits(0) = FrmSettings.TBYes.Text
			If ssh_CheckNo = True Then Splits(0) = FrmSettings.TBNo.Text



			Do
				Splits(0) = Splits(0).Replace("  ", " ")
				Splits(0) = Splits(0).Replace(" ,", ",")
				Splits(0) = Splits(0).Replace(", ", ",")
				Splits(0) = Splits(0).Replace("'", "")
			Loop Until Not Splits(0).Contains("  ") And Not Splits(0).Contains(", ") And Not Splits(0).Contains(" ,") And Not Splits(0).Contains("'")

			Dim SplitParts As String() = Splits(0).Split(New Char() {","c})

			For i As Integer = 0 To SplitParts.Length - 1

				If UCase(TempChatString) = (UCase(SplitParts(i))) Then

					If ssh_CheckYes = True Or ssh_CheckNo = True Then
						If FrmSettings.CBHonorificInclude.Checked = True Then
							If Not UCase(TempChatString).Contains(UCase(FrmSettings.TBHonorific.Text)) Then
								ssh_DomChat = SplitParts(i) & " what?"
								If FrmSettings.LCaseCheckBox.Checked = False Then
									Dim DomU As String = UCase(ssh_DomChat.Substring(0, 1))
									ssh_DomChat = ssh_DomChat.Remove(0, 1)
									ssh_DomChat = DomU & ssh_DomChat
								End If
								TypingDelay()
								Return
							End If
							If FrmSettings.CBHonorificCapitalized.Checked = True Then
								If Not ssh_ChatString.Contains(FrmSettings.TBHonorific.Text) Then
									ssh_DomChat = "#DomHonorific"
									TypingDelay()
									Return
								End If
							End If
						End If
					End If

					'Splits(0) = ""
					'DomChat = Join(Splits, "]")
					ssh_DomChat = ChatReplace

					' DomChat = Splits(1)
					GoTo FoundAnswer
				End If
			Next

		Loop Until InStr(UCase(lines(line)), UCase("@DifferentAnswer")) <> 0 Or InStr(UCase(lines(line)), UCase("@AcceptAnswer")) <> 0

		If ssh_MiniScript = True Then
			line = ssh_MiniTauntVal
		Else
			line = ssh_StrokeTauntVal
		End If

		Do
			line += 1

			CheckLines = lines(line)

			ssh_CheckYes = False
			ssh_CheckNo = False

			If UCase(CheckLines).Contains(UCase("[yes]")) Then ssh_CheckYes = True
			If UCase(CheckLines).Contains(UCase("[no]")) Then ssh_CheckNo = True



			Dim Splits As String() = CheckLines.Split(New Char() {"]"c})
			Splits(0) = Splits(0).Replace("[", "")

			Dim ChatReplace As String = CheckLines.Replace("[" & Splits(0) & "]", "")

			If ssh_CheckYes = True Then Splits(0) = FrmSettings.TBYes.Text
			If ssh_CheckNo = True Then Splits(0) = FrmSettings.TBNo.Text

			Do
				Splits(0) = Splits(0).Replace("  ", " ")
				Splits(0) = Splits(0).Replace(" ,", ",")
				Splits(0) = Splits(0).Replace(", ", ",")
				Splits(0) = Splits(0).Replace("'", "")
			Loop Until Not Splits(0).Contains("  ") And Not Splits(0).Contains(", ") And Not Splits(0).Contains(" ,") And Not Splits(0).Contains("'")

			Dim SplitParts As String() = Splits(0).Split(New Char() {","c})

			For i As Integer = 0 To SplitParts.Length - 1


				If UCase(TempChatString).Contains(UCase(SplitParts(i))) Then

					If ssh_CheckYes = True Or ssh_CheckNo = True Then
						If FrmSettings.CBHonorificInclude.Checked = True Then
							If Not UCase(TempChatString).Contains(UCase(FrmSettings.TBHonorific.Text)) Then
								ssh_DomChat = SplitParts(i) & " what?"
								If FrmSettings.LCaseCheckBox.Checked = False Then
									Dim DomU As String = UCase(ssh_DomChat.Substring(0, 1))
									ssh_DomChat = ssh_DomChat.Remove(0, 1)
									ssh_DomChat = DomU & ssh_DomChat
								End If
								TypingDelay()
								Return
							End If
							If FrmSettings.CBHonorificCapitalized.Checked = True Then
								If Not ssh_ChatString.Contains(FrmSettings.TBHonorific.Text) Then
									ssh_DomChat = "#CapitalizeHonorific"
									TypingDelay()
									Return
								End If
							End If
						End If
					End If

					'Splits(0) = ""
					'DomChat = Join(Splits, Nothing)

					'DomChat = Join(Splits, "]")
					'DomChat = DomChat.Replace(ChatReplace, "")

					ssh_DomChat = ChatReplace

					'DomChat = Splits(1)
					GoTo FoundAnswer
				End If
			Next

		Loop Until InStr(UCase(lines(line)), UCase("@DifferentAnswer")) <> 0 Or InStr(UCase(lines(line)), UCase("@AcceptAnswer")) <> 0

		GoTo NothingFound

FoundAnswer:

		If ssh_DomChat.Contains("@NullResponse") Then ssh_NullResponse = True
		If ssh_DomChat.Contains("@LoopAnswer") Then GoTo LoopAnswer

		ssh_YesOrNo = False
		YesOrNoLanguageCheck()



		If ssh_MiniScript = True Then
			If ssh_GotoFlag = False Then ssh_MiniTauntVal = TempLineVal
		Else
			If ssh_GotoFlag = False Then ssh_StrokeTauntVal = TempLineVal
		End If

		TypingDelay()

		Return


NothingFound:

		If InStr(UCase(lines(line)), UCase("DifferentAnswer")) <> 0 Then

DifferentAnswer:
			ssh_DomChat = lines(line)
			ssh_DomChat = ssh_DomChat.Replace("@DifferentAnswer ", "")

LoopAnswer:
			ssh_DomChat = ssh_DomChat.Replace("@LoopAnswer", "")
			' CleanParse()
			TypingDelay()
			Return
		End If


		If InStr(UCase(lines(line)), UCase("AcceptAnswer")) <> 0 Then
AcceptAnswer:
			ssh_DomChat = lines(TempLineVal)
			' TimedAnswerTimer.Stop()

			ssh_DomChat = ssh_DomChat.Replace("@AcceptAnswer ", "")
			ScriptTimer.Start()
			ssh_YesOrNo = False

			YesOrNoLanguageCheck()

			If ssh_GotoFlag = False Then


				If ssh_MiniScript = True Then
					ssh_MiniTauntVal = TempLineVal
				Else
					ssh_StrokeTauntVal = TempLineVal
				End If

			End If
			TypingDelay()
			Return
		End If



	End Sub

	Public Sub YesOrNoLanguageCheck()


		If InStr(UCase(ssh_DomChat), UCase("@Goto(")) <> 0 Then
			GetGotoChat()
		End If

	End Sub

	Public Sub GetGotoChat()

		ssh_GotoFlag = True

		If InStr(UCase(ssh_DomChat), UCase("@Goto")) <> 0 Then

			ssh_DomTypeCheck = True

			Dim TempGoto As String = ssh_DomChat & " some garbage"
			Dim GotoIndex As Integer = TempGoto.IndexOf("@Goto(") + 6
			TempGoto = TempGoto.Substring(GotoIndex, TempGoto.Length - GotoIndex)
			TempGoto = TempGoto.Split(")")(0)
			ssh_FileGoto = TempGoto

			Dim StripGoto As String = ssh_FileGoto

			If TempGoto.Contains(",") Then
				TempGoto = TempGoto.Replace(", ", ",")
				Dim GotoSplit As String() = TempGoto.Split(",")
				Dim GotoTemp As Integer = ssh_randomizer.Next(0, GotoSplit.Count)
				ssh_FileGoto = GotoSplit(GotoTemp)
			End If

			Dim GotoText As String

			If ssh_MiniScript = True Then
				GotoText = ssh_MiniScriptText
			Else
				GotoText = ssh_FileText
			End If

			If File.Exists(GotoText) Then
				' Read all lines of File
				Dim gotolines As List(Of String) = Txt2List(GotoText)
				Dim gotoline As Integer = -1

				If StripGoto.Substring(0, 1) <> "(" Then StripGoto = "(" & StripGoto & ")"
				If ssh_FileGoto.Substring(0, 1) <> "(" Then ssh_FileGoto = "(" & ssh_FileGoto & ")"

				ssh_DomChat = ssh_DomChat.Replace("@Goto" & StripGoto, "")
				Try
					Do
						gotoline += 1

					Loop Until gotolines(gotoline).StartsWith(ssh_FileGoto)
				Catch ex As ArgumentOutOfRangeException When ssh_MiniScript = True
					'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
					'                                 ArgumentOutOfRangeException - Miniscript
					'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
					Throw New ArgumentOutOfRangeException("The Miniscript-Goto-Destination """ & ssh_FileGoto &
														  """ in file """ & GotoText & """ was not found.", ex)
				Catch ex As ArgumentOutOfRangeException When ssh_MiniScript = True
					'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
					'                                 ArgumentOutOfRangeException - Regular Script
					'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
					Throw New ArgumentOutOfRangeException("The Goto-Destination """ & ssh_FileGoto &
														  """ in file """ & GotoText & """ was not found.", ex)
				End Try

				'QUESTION (stefaf): Is this line an error?
				ssh_StrokeTauntVal = gotoline

				If ssh_MiniScript = True Then
					ssh_MiniTauntVal = gotoline
				Else
					ssh_StrokeTauntVal = gotoline
				End If

			Else
				Throw New FileNotFoundException("The Goto-File """ & GotoText & """ was not found.")
			End If

		End If

	End Sub


	Public Sub ScriptTimer_Tick(sender As System.Object, e As System.EventArgs) Handles ScriptTimer.Tick

		FrmSettings.LBLDebugScriptTime.Text = ssh_ScriptTick
		'Debug.Print("ScriptTick = " & ScriptTick)

		If ssh_DomTyping = True Then Return
		If ssh_YesOrNo = True Then Return

		'If ChatText.IsBusy Then Return

		If WaitTimer.Enabled = True Or ssh_DomTypeCheck = True Then Return

		'Debug.Print("ScriptTimer Substroking = " & SubStroking)
		'Debug.Print("ScriptTimer StrokePaceTimer = " & StrokePaceTimer.Enabled)

		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then Return

		If playingStatus() = True Then
			If ssh_ScriptTick < 4 Then Return
		End If


		If ssh_DomTypeCheck = True And ssh_ScriptTick < 4 Then Return
		If chatBox.Text <> "" And ssh_ScriptTick < 4 Then Return
		If ChatBox2.Text <> "" And ssh_ScriptTick < 4 Then Return


		ssh_ScriptTick -= 1
		' Debug.Print("ScriptTick = " & ScriptTick)
		If ssh_ScriptTick < 1 Then



			ssh_ScriptTick = ssh_randomizer.Next(4, 7)

			RunFileText()


		End If




	End Sub

	Public Sub CBTBalls()
		Dim File2Read As String = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\CBT\CBTBalls_First.txt"

		If ssh_CBTBallsFirst = False Then
			File2Read = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\CBT\CBTBalls.txt"
		Else
			ssh_CBTBallsCount += 1
		End If

		' Read all Lines of the given File.
		Dim BallList As List(Of String) = Txt2List(File2Read)

		Try
			BallList = FilterList(BallList)
			ssh_DomTask = BallList(ssh_randomizer.Next(0, BallList.Count))
		Catch ex As Exception
			Log.WriteError("Tease AI did not return a valid @CBTBalls line from file: " &
						   File2Read, ex, "CBTBalls()")
			ssh_DomTask = "ERROR: Tease AI did not return a valid @CBTBalls line"
		End Try

		ssh_CBTBallsFirst = False

		TypingDelayGeneric()

	End Sub

	Public Sub CBTCock()

		Dim File2Read As String = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\CBT\CBTCock_First.txt"

		If ssh_CBTCockFirst = False Then
			File2Read = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\CBT\CBTCock.txt"
		Else
			ssh_CBTCockCount += 1
		End If

		' Read all Lines of the given File.
		Dim CockList As List(Of String) = Txt2List(File2Read)

		Try
			CockList = FilterList(CockList)
			ssh_DomTask = CockList(ssh_randomizer.Next(0, CockList.Count))
		Catch ex As Exception
			Log.WriteError("Tease AI did not return a valid @CBTCock line from file: " &
						   File2Read, ex, "CBTCock()")
			ssh_DomTask = "ERROR: Tease AI did not return a valid @CBTCock line"
		End Try

		ssh_CBTCockFirst = False

		TypingDelayGeneric()

	End Sub

	Public Sub CBTBoth()

		Dim File2Read As String = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\CBT\CBTBalls_First.txt"

		If ssh_CBTBothFirst = False Then
			File2Read = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\CBT\CBTBalls.txt"
		Else
			ssh_CBTBallsCount += 1
			ssh_CBTCockCount += 1
		End If

		' Read all Lines of the given File.
		Dim BothList As List(Of String) = Txt2List(File2Read)

		File2Read = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\CBT\CBTCock_First.txt"

		If ssh_CBTBothFirst = False Then
			File2Read = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\CBT\CBTCock.txt"
		Else
			ssh_CBTBallsCount += 1
			ssh_CBTCockCount += 1
		End If

		' Read all Lines of the given file and append to List.
		BothList.AddRange(Txt2List(File2Read))

		Try
			BothList = FilterList(BothList)
			ssh_DomTask = BothList(ssh_randomizer.Next(0, BothList.Count))
		Catch ex As Exception
			Log.WriteError("Tease AI did not return a valid @CBT line from file: " &
						   File2Read, ex, "CBTBoth()")
			ssh_DomTask = "ERROR: Tease AI did not return a valid @CBT line"
		End Try

		ssh_CBTBothFirst = False

		TypingDelayGeneric()

	End Sub

	Public Sub RunCustomTask()

		Dim File2Read As String = ssh_CustomTaskTextFirst

		If ssh_CustomTaskFirst = False Then
			File2Read = ssh_CustomTaskText
		End If

		' Read all Lines of the given File.
		Dim CustomList As List(Of String) = Txt2List(File2Read)

		Try
			CustomList = FilterList(CustomList)
			ssh_DomTask = CustomList(ssh_randomizer.Next(0, CustomList.Count))
		Catch ex As Exception
			Log.WriteError("Tease AI did not return a valid Custom Taks line from file: " & File2Read, ex, "RunCustomTask()")
			ssh_DomTask = "ERROR: Tease AI did not return a valid Custom Task line"
		End Try

		ssh_CustomTaskFirst = False

		TypingDelayGeneric()

	End Sub


	Public Sub RunFileText()


		'Debug.Print("ReturnFlag = " & ReturnFlag)

		'If ReturnFlag = True Then GoTo ReturnCalled

		Debug.Print("SaidHello = " & ssh_SaidHello)
		If ssh_SaidHello = False Then Return

		'Debug.Print("CBTCockFlag = " & CBTCockFlag)
		'Debug.Print("CBTBallsFlag = " & CBTBallsFlag)
		If ssh_CBTCockFlag = True Or ssh_CBTBallsFlag = True Or ssh_CBTBothFlag = True Or ssh_CustomTask = True Then Return

		'Debug.Print("WritingTaskFlag = " & WritingTaskFlag)
		If ssh_WritingTaskFlag = True Then Return

		'Debug.Print("TeaseVideo = " & TeaseVideo)
		If ssh_TeaseVideo = True Then Return



		If ssh_RiskyDelay = True Then Return

		If ssh_InputFlag = True Then Return

		If ssh_MiniScript = True Then GoTo ReturnCalled

		If ssh_CensorshipGame = True Or ssh_RLGLGame = True Or ssh_AvoidTheEdgeStroking = True Or ssh_SubEdging = True Or ssh_SubHoldingEdge = True Then Return

		If ssh_MultipleEdges = True Then Return

		'Debug.Print("RunFileText " & StrokeTauntVal)

ReturnCalled:

		Dim lines As New List(Of String)

		If ssh_MiniScript = True Then
			ssh_MiniTauntVal += 1
			lines = Txt2List(ssh_MiniScriptText)
			Try
				If ssh_MiniTauntVal < lines.Count Then
					If lines(ssh_MiniTauntVal).Substring(0, 1) = "(" Then
						Do
							ssh_MiniTauntVal += 1
						Loop Until lines(ssh_MiniTauntVal).Substring(0, 1) <> "("
					End If
				End If
			Catch
			End Try

		Else
			ssh_StrokeTauntVal += 1
			lines = Txt2List(ssh_FileText)
			Try
				If ssh_StrokeTauntVal < lines.Count - 1 Then
					If lines(ssh_StrokeTauntVal).Substring(0, 1) = "(" Then
						Do
							ssh_StrokeTauntVal += 1
						Loop Until lines(ssh_StrokeTauntVal).Substring(0, 1) <> "("
					End If
				End If
			Catch
			End Try

		End If





		Try
			If ssh_RunningScript = False And ssh_AvoidTheEdgeGame = False And ssh_ReturnFlag = False Then
				Debug.Print("End Check StrokeTauntVal = " & ssh_StrokeTauntVal)


				If ssh_MiniScript = True Then
					If lines(ssh_MiniTauntVal) = "@End" Then
						ssh_MiniScript = False
						If ssh_MiniTimerCheck = True Then
							ssh_ScriptTick = 3
							ScriptTimer.Start()
						Else
							ScriptTimer.Stop()
						End If
						Return
					End If
				Else
					If Not ssh_StrokeTauntVal > lines.Count - 1 Then
						If lines(ssh_StrokeTauntVal) = "@End" Then
							If ssh_ShowModule = True Then ssh_ModuleEnd = True
						End If
					End If
				End If
			End If
		Catch
		End Try


		'If ShowThought = True Or ShowEdgeThought = True Then
		'ThoughtTauntVal += 1
		'ScriptLineVal = ThoughtTauntVal
		'Else
		'If ShowModule = True Then
		' ModuleTauntVal += 1
		'ScriptLineVal = ModuleTauntVal
		'Else
		'StrokeTauntVal += 1
		'ScriptLineVal = StrokeTauntVal
		'End If
		'End If

		HandleScripts()
	End Sub

	Public Sub HandleScripts()

		Debug.Print("Handlescripts Called")

		'  If ThoughtEnd = True Then
		'ScriptTimer.Stop()
		'ThoughtEnd = False
		'ShowThought = False
		'ShowEdgeThought = False

		'DelayFlag = True
		'DelayTick = randomizer.Next(30, 180)

		'DelayTimer.Start()

		'Do
		'Application.DoEvents()
		'Loop Until DelayFlag = False

		'StartStroking()
		'Return
		'End If

		' ### Debug

ModuleEnd:

		If ssh_ModuleEnd = True And ssh_AvoidTheEdgeGame = False Then
			Debug.Print("Module End Called?")
			ScriptTimer.Stop()
			ssh_ModuleEnd = False
			ssh_ShowModule = False

			'DelayFlag = True
			'DelayTick = randomizer.Next(3, 6)

			'DelayTimer.Start()

			'Do
			'Application.DoEvents()
			'Loop Until DelayFlag = False

			'LastScriptCountdown -= 1
			'Debug.Print("LastScriptCountdown = " & LastScriptCountdown)

			If ssh_Playlist = True Then
				Debug.Print("Playlist True - StrokeTimer")
				If ssh_PlaylistCurrent = ssh_PlaylistFile.Count - 1 Then
					RunLastScript()
				Else
					RunLinkScript()
				End If
			Else
				If ssh_TeaseTick < 1 And ssh_BookmarkModule = False Then
					RunLastScript()
				Else
					RunLinkScript()
				End If
			End If
			Return
		End If

		If StrokeTimer.Enabled = True And ssh_MiniScript = False Then Return

		'If ShowThought = False And ShowEdgeThought = False And ShowModule = False Then HandleScriptText = FileText
		'If ShowThought = True Then HandleScriptText = (Application.StartupPath & "\Scripts\" & dompersonalityComboBox.Text & "\Thoughts\Thoughts.txt")
		'If ShowEdgeThought = True Then HandleScriptText = (Application.StartupPath & "\Scripts\" & dompersonalityComboBox.Text & "\Thoughts\EdgeThoughts.txt")
		'If ShowModule = True Then HandleScriptText = ModText

		Debug.Print("CHeck")

		Debug.Print(ssh_FileText)

		Dim CheckText As String

		If ssh_MiniScript = True Then
			CheckText = ssh_MiniScriptText
		Else
			CheckText = ssh_FileText
		End If

		'If File.Exists(HandleScriptText) Then
		If File.Exists(CheckText) Then
			'Debug.Print(StrokeTauntVal)
			'Dim ioFile As New StreamReader(HandleScriptText)
			Dim lines As List(Of String) = Txt2List(CheckText)
			Dim line As Integer

			'line = ScriptLineVal

			If ssh_MiniScript = True Then
				line = ssh_MiniTauntVal
			Else
				line = ssh_StrokeTauntVal
			End If

			If line = lines.Count Then
				If ssh_ShowModule = True Then
					ssh_ModuleEnd = True
					GoTo ModuleEnd
				Else
					GoTo NonModuleEnd
				End If
			End If

			Debug.Print("CHeck")

			If GetFilter(lines(line), True) = False Then
				RunFileText()
				Return
			End If

			If lines(line) = "@End" Then

NonModuleEnd:

				If ssh_RiskyEdges = True Then ssh_RiskyEdges = False
				If ssh_LastScript = True Then
					ssh_LastScript = False
					ssh_EndTease = True
				End If
				If ssh_HypnoGen = True Then
					If ssh_Induction = True Then
						ssh_Induction = False
						ssh_StrokeTauntVal = -1
						ssh_FileText = ssh_TempHypno
						ssh_ScriptTick = 1
						ScriptTimer.Start()
						Return
					End If
					ssh_HypnoGen = False
					ssh_AFK = False
					DomWMP.Ctlcontrols.stop()
					BTNHypnoGenStart.Text = "Guide Me!"
				End If
				If ssh_ReturnFlag = True Then
					ssh_ReturnFlag = False
					ssh_FileText = ssh_ReturnFileText
					ssh_StrokeTauntVal = ssh_ReturnStrokeTauntVal


					'github patch begin
					'If ReturnSubState = "Stroking" Then
					'If SubStroking = False Then
					'DomTask = "Get back to stroking @StartStroking"
					'TypingDelayGeneric()
					'Else
					' StrokeTimer.Start()
					' StrokeTauntTimer.Start()
					'End If
					'End If
					'If ReturnSubState = "Edging" Then

					'github patch end

					If ssh_ReturnSubState = "Stroking" Then
						If My.Settings.Chastity = True Then
							'DomTask = "Now as I was saying @StartTaunts"
							ssh_DomTask = "#Return_Chastity"
							TypingDelayGeneric()
						Else
							If ssh_SubStroking = False Then
								'DomTask = "Get back to stroking @StartStroking"
								ssh_DomTask = "#Return_Stroking"
								TypingDelayGeneric()
							Else
								StrokeTimer.Start()
								StrokeTauntTimer.Start()
							End If
						End If
					End If
					If ssh_ReturnSubState = "Edging" Then

						If ssh_SubEdging = False Then
							'DomTask = "Start getting yourself to the edge again @Edge"
							ssh_DomTask = "#Return_Edging"
							'SubStroking = True
							TypingDelayGeneric()
						Else
							EdgeTauntTimer.Start()
							EdgeCountTimer.Start()
						End If
					End If
					If ssh_ReturnSubState = "Holding The Edge" Then
						If ssh_SubEdging = False Then
							'DomTask = "Start getting yourself to the edge again @EdgeHold"
							ssh_DomTask = "#Return_Holding"
							'SubStroking = True
							TypingDelayGeneric()
						Else
							HoldEdgeTimer.Start()
							HoldEdgeTauntTimer.Start()
						End If
					End If
					If ssh_ReturnSubState = "CBTBalls" Then
						'DomTask = "Now let's get back to busting those #Balls @CBTBalls"
						ssh_DomTask = "#Return_CBTBalls"
						ssh_CBTBallsFirst = False
						TypingDelayGeneric()
					End If
					If ssh_ReturnSubState = "CBTCock" Then
						'DomTask = "Now let's get back to abusing that #Cock @CBTCock"
						ssh_DomTask = "#Return_CBTCock"
						ssh_CBTCockFirst = False
						TypingDelayGeneric()
					End If
					If ssh_ReturnSubState = "Rest" Then
						ssh_DomTypeCheck = True
						ssh_ScriptTick = 5
						ScriptTimer.Start()
						'DomTask = "Now as I was saying"
						ssh_DomTask = "#Return_Rest"
						TypingDelayGeneric()
						Return
					End If
				End If
				ScriptTimer.Stop()
				Return
			End If

			'If lines(line).Substring(0, 1) = "(" Then
			'Do
			'line += 1
			'If MiniScript = True Then
			'MiniTauntVal += 1
			'Else
			'   StrokeTauntVal += 1
			'End If

			'Loop Until lines(line).Substring(0, 1) <> "("
			'End If


			If line < lines.Count - 1 Then
				If lines(line + 1).Substring(0, 1) = "[" Then
					ssh_YesOrNo = True
					ScriptTimer.Stop()
				End If
			End If

			Debug.Print("CHeck")





			ssh_DomTask = (lines(line).Trim)





			ssh_StringLength = 1



			ssh_DomTask = ssh_DomTask.Replace("#SubName", subName.Text)

			ssh_DomTask = ssh_DomTask.Replace("#VTLength", ssh_VTLength / 60)


			If InStr(ssh_DomTask, "@CockSizeSmall") <> 0 Then ssh_DivideText = True


			If ssh_DomTask.Contains("@SearchImageBlogAgain") Then

				GetBlogImage()

			End If


			If ssh_DomTask.Contains("@SearchImageBlog") And Not ssh_DomTask.Contains("@SearchImageBlogAgain") Then

				GetBlogImage()

			End If


			'If InStr(UCase(DomTask), UCase("@Goto")) <> 0 And InStr(UCase(DomTask), UCase("@GotoDommeLevel")) = 0 And InStr(UCase(DomTask), UCase("@GotoDommeOrgasm")) = 0 And InStr(UCase(DomTask), UCase("@GotoDommeRuin")) = 0 And InStr(UCase(DomTask), UCase("@GotoDommeApathy")) = 0 And InStr(UCase(DomTask), UCase("@GotoSlideshow")) = 0 Then
			If ssh_DomTask.Contains("@Goto(") Then
				GetGoto()
			End If

			'If DomTask.Contains("@Chance") Then

			'Dim ChanceTemp As String
			'Dim TSStartIndex As Integer
			'Dim TSEndIndex As Integer

			'TSStartIndex = DomTask.IndexOf("@Chance") + 7
			'TSEndIndex = DomTask.IndexOf("@Chance") + 9

			'ChanceTemp = DomTask.Substring(TSStartIndex, TSEndIndex - TSStartIndex).Trim

			'            Dim ChanceVal As Integer

			' ChanceVal = Val(ChanceTemp)

			' 'Debug.Print("Check Substring " & ChanceTemp & " , " & ChanceVal)
			' 'Debug.Print("Check Substring " & DomTask.Substring("@Chance", 2))

			' TempVal = randomizer.Next(1, 101)

			Debug.Print("TempVal = " & ssh_TempVal)
			'Debug.Print("ChanceVal = " & ChanceVal)

			'If TempVal <= ChanceVal Then

			''Debug.Print("Goto should be called")

			'GetGoto()

			'End If

			' 'Debug.Print("ChanceTemp DomTask = " & DomTask)

			'DomTask = DomTask.Replace("@Chance" & ChanceTemp, "")

			'End If




			'  If DomTask.Contains("@CheckFlag") Then

			''Debug.Print("CheckFlagcalled")

			'Dim CheckFlag As String = DomTask

			'CheckFlag = DomTask.Split("@CheckFlag(")(1)
			'CheckFlag = CheckFlag.Split(")")(0)
			'CheckFlag = CheckFlag.Replace("CheckFlag(", "")

			'If File.Exists(Application.StartupPath & "\Scripts\" & dompersonalityComboBox.Text & "\System\Flags\" & CheckFlag & ".txt") Then
			''Debug.Print("CheckFlag = " & CheckFlag)
			'SkipGotoLine = True
			'FileGoto = CheckFlag
			'GetGoto()
			'End If

			'    DomTask = DomTask.Replace("@CheckFlag", "")

			'End If




			'If DomTask.Contains("@GotoDommeLevel") Then

			'GotoDommeLevel = True

			'Dim GotoDommeLevelString As String

			'GotoDommeLevelString = DomTask.Split("@GotoDommeLevel(")(1)
			'GotoDommeLevelString = GotoDommeLevelString.Split(")")(0)
			'GotoDommeLevelString = GotoDommeLevelString.Replace("GotoDommeLevel(", "")

			'FileGoto = "DommeLevel" & GotoDommeLevelString & FrmSettings.domlevelNumBox.Value

			'Debug.Print("GotoDommeLebel FileGoto = " & FileGoto)

			'DomTask = DomTask.Replace("GotoDommeLevel(" & GotoDommeLevelString & ")", "")

			'GetGoto()

			'End If

			' If DomTask.Contains("@VTLength") Then

			'SkipGotoLine = True

			'If FrmSettings.ComboBoxVTLength.Text = "Never" Then FileGoto = "VTLengthNo"

			'If FrmSettings.ComboBoxVTLength.Text = "Always" Then FileGoto = "VTLengthYes"

			'If FrmSettings.ComboBoxVTLength.Text = "Sometimes" Then

			'TempVal = randomizer.Next(5, 21) * FrmSettings.domlevelNumBox.Value

			' 5, 20   10, 40   15, 60   20, 80   25, 100
			'If TempVal < 10 * FrmSettings.domlevelNumBox.Value Then
			'FileGoto = "VTLengthYes"
			'Else
			'   FileGoto = "VTLengthNo"
			' End If

			'End If



			'Debug.Print("VTLength = " & FileGoto)

			'DomTask = DomTask.Replace("@VTLength", "")

			'GetGoto()

			'End If






			' If DomTask.Contains("@Module") Then
			'ShowModule = True
			'ScriptCount = 0
			'For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & dompersonalityComboBox.Text & "\Modules\", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
			' ScriptCount += 1
			'Next
			'TempVal = randomizer.Next(1, ScriptCount + 1)
			'ScriptCount = 0
			'For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & dompersonalityComboBox.Text & "\Modules\", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
			'ScriptCount += 1
			'If TempVal = ScriptCount Then ModText = foundFile
			'Next
			'DomTask = DomTask.Replace("@Module", "")
			'ModuleTauntVal = -1
			'End If

			'Debug.Print("GotoFLag = " & GotoFlag)

			'If DomTask.Contains("@PlayVideoTeaseCensorshipSucks") Then
			'ScriptVideoTease = "Censorship Sucks"
			'ScriptVideoTeaseFlag = True
			' RandomVideo()
			'DomTask = DomTask.Replace("@PlayVideoTeaseCensorshipSucks", "")
			' End If



			'If DomTask.Contains("@PauseAvoidTheEdge") Then
			'domVLC.playlist.pause()
			'AvoidTheEdgeTick = 120 / TauntSlider.Value
			'AvoidTheEdgeStroking = False
			'DomTask = DomTask.Replace("@PauseAvoidTheEdge", "")
			'End If

			'    If DomChat.Contains("@PauseAvoidTheEdge") Then
			'domVLC.playlist.pause()
			'AvoidTheEdgeTick = 120 / TauntSlider.Value
			'AvoidTheEdgeStroking = False
			'DomChat = DomChat.Replace("@PauseAvoidTheEdge", "")
			'End If

			'    If DomTask.Contains("@PauseAvoidTheEdgeNoTaunts") Then
			'AvoidTheEdge.Stop()
			'DomTask = DomTask.Replace("@PauseAvoidTheEdgeNoTaunts", "")
			'End If

			'If DomTask.Contains("@CountdownAvoidTheEdge") Then
			'ScriptTimer.Stop()
			'AtECountdown = randomizer.Next(FrmSettings.NBAvoidTheEdgeMin.Value, FrmSettings.NBAvoidTheEdgeMax.Value + 1)
			'DomTask = DomTask.Replace("@CountdownAvoidTheEdge", "")
			'AvoidTheEdgeResume.Start()
			'End If

			'    If DomTask.Contains("@ResumeAvoidTheEdge") Then
			'DomTask = DomTask.Replace("@ResumeAvoidTheEdge", "")
			'FileGoto = "AvoidTheEdgeBegin"
			'SkipGotoLine = True
			'GetGoto()
			'domVLC.playlist.play()
			'End If

			'If DomTask.Contains("@EmbedImage") Then

			'Dim EmbedImageFile As New StreamReader(Application.StartupPath & "\Scripts\" & dompersonalityComboBox.Text & "\System\ImageURLs.txt")
			'Dim ImageLines As New List(Of String)
			'Dim ImageLine As Integer

			'ImageLine = -1

			'While EmbedImageFile.Peek <> -1
			'  ImageLine += 1
			'   ImageLines.Add(EmbedImageFile.ReadLine())
			'End While
			''Debug.Print("ImageLine = " & ImageLine)
			'TempVal = randomizer.Next(0, ImageLine + 1)
			''Debug.Print("TempVal = " & TempVal)

			'subAvatar.Load(ImageLines(TempVal))


			'Dim EmbedImageDoc As New XmlDocument()

			'EmbedImageDoc.Load("http://justblowjobgifs.tumblr.com/api/read")

			'EmbedImageDoc.Save("G:\Temp\EmbedImage.xml")

			'   For Each XmlAttribute As XElement In EmbedImageDoc

			'If XmlAttribute.Attribute("type") = "photo" Then
			'MsgBox(XmlAttribute.Elements("photo-url").Value)
			'End If

			'    Next



			'RunFileText()
			'Return
			'End If

			If ssh_DomTask.Contains("@ShowTaggedImage") Then ssh_JustShowedBlogImage = True

			If ssh_DomTask.Contains("@NullResponse") Then ssh_NullResponse = True

			If ssh_HypnoGen = True Then

				If CBHypnoGenSlideshow.Checked = True Then

					If LBHypnoGenSlideshow.SelectedItem = "Boobs" Then ssh_DomTask = ssh_DomTask & " @ShowBoobsImage"
					If LBHypnoGenSlideshow.SelectedItem = "Butts" Then ssh_DomTask = ssh_DomTask & " @ShowButtImage"
					If LBHypnoGenSlideshow.SelectedItem = "Hardcore" Then ssh_DomTask = ssh_DomTask & " @ShowHardcoreImage"
					If LBHypnoGenSlideshow.SelectedItem = "Softcore" Then ssh_DomTask = ssh_DomTask & " @ShowSoftcoreImage"
					If LBHypnoGenSlideshow.SelectedItem = "Lesbian" Then ssh_DomTask = ssh_DomTask & " @ShowLesbianImage"
					If LBHypnoGenSlideshow.SelectedItem = "Blowjob" Then ssh_DomTask = ssh_DomTask & " @ShowBlowjobImage"
					If LBHypnoGenSlideshow.SelectedItem = "Femdom" Then ssh_DomTask = ssh_DomTask & " @ShowFemdomImage"
					If LBHypnoGenSlideshow.SelectedItem = "Lezdom" Then ssh_DomTask = ssh_DomTask & " @ShowLezdomImage"
					If LBHypnoGenSlideshow.SelectedItem = "Hentai" Then ssh_DomTask = ssh_DomTask & " @ShowHentaiImage"
					If LBHypnoGenSlideshow.SelectedItem = "Gay" Then ssh_DomTask = ssh_DomTask & " @ShowGayImage"
					If LBHypnoGenSlideshow.SelectedItem = "Maledom" Then ssh_DomTask = ssh_DomTask & " @ShowMaledomImage"
					If LBHypnoGenSlideshow.SelectedItem = "Captions" Then ssh_DomTask = ssh_DomTask & " @ShowCaptionsImage"
					If LBHypnoGenSlideshow.SelectedItem = "General" Then ssh_DomTask = ssh_DomTask & " @ShowGeneralImage"
					If LBHypnoGenSlideshow.SelectedItem = "Tagged" Then ssh_DomTask = ssh_DomTask & " @ShowTaggedImage @Tag" & TBHypnoGenImageTag.Text



				End If

			End If


			If ssh_DomTask <> "" Then
				TypingDelayGeneric()
			Else
				RunFileText()
			End If


		End If

	End Sub

	Public Sub GetGoto()
		'BUG: @Goto Command is sometimes searching in the wrong file. Description: https://milovana.com/forum/viewtopic.php?f=2&t=15776&p=219171#p219169

		'If FileGoto = "" Then GoTo CancelGoto

		ssh_GotoFlag = True

		Dim StripGoto As String

		If ssh_GotoDommeLevel = True Or ssh_SkipGotoLine = True Then
			StripGoto = ssh_FileGoto
			GoTo SkipGotoSearch
		End If

		Dim TempGoto As String = ssh_DomTask & " some garbage"
		Dim GotoIndex As Integer = TempGoto.IndexOf("@Goto(") + 6
		TempGoto = TempGoto.Substring(GotoIndex, TempGoto.Length - GotoIndex)
		TempGoto = TempGoto.Split(")")(0)
		ssh_FileGoto = TempGoto

		StripGoto = ssh_FileGoto

		If TempGoto.Contains(",") Then
			TempGoto = TempGoto.Replace(", ", ",")
			Dim GotoSplit As String() = TempGoto.Split(",")
			Dim GotoTemp As Integer = ssh_randomizer.Next(0, GotoSplit.Count)
			ssh_FileGoto = GotoSplit(GotoTemp)
		End If

SkipGotoSearch:


		Dim GotoText As String

		If ssh_MiniScript = True Then
			GotoText = ssh_MiniScriptText
		Else
			GotoText = ssh_FileText
		End If
		Try

			'TODO: Add Errorhandling.
			If File.Exists(GotoText) Then
				' Read all lines of the given file.
				Dim gotolines As List(Of String) = Txt2List(GotoText)
				Dim CountGotoLines As Integer = gotolines.Count

				If StripGoto.Substring(0, 1) <> "(" Then StripGoto = "(" & StripGoto & ")"
				If ssh_FileGoto.Substring(0, 1) <> "(" Then ssh_FileGoto = "(" & ssh_FileGoto & ")"

				ssh_DomTask = ssh_DomTask.Replace("@Goto" & StripGoto, "")

				Dim gotoline As Integer = -1

				Do
					gotoline += 1
					If ssh_GotoDommeLevel = True And gotoline = CountGotoLines Then
						ssh_FileGoto = "(DommeLevel)"
						GoTo SkipGotoSearch
					End If
				Loop Until gotolines(gotoline).StartsWith(ssh_FileGoto)

				If ssh_MiniScript = True Then
					ssh_MiniTauntVal = gotoline
				Else
					ssh_StrokeTauntVal = gotoline
				End If

			End If

		Catch ex As Exception
			'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
			'                                            All Errors
			'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
			Log.WriteError(ex.Message, ex, "Exception occured finding GotoLabel """ & ssh_FileGoto & """ in file """ & GotoText & """")
			Throw
		End Try

CancelGoto:

		ssh_GotoDommeLevel = False
		ssh_SkipGotoLine = False

	End Sub

	Public Sub TypingDelay()

		'Debug.Print("Typing Delay Called " & StrokeTauntVal)
		If My.Settings.OfflineMode = True Then
			ssh_DomChat = OfflineConversion(ssh_DomChat)
		End If
		ssh_TypeDelay = ssh_StringLength
		If ssh_TypeDelay > 60 Then ssh_TypeDelay = 60
		If FrmSettings.typeinstantlyCheckBox.Checked = True Or ssh_RapidCode = True = True Then ssh_TypeDelay = 0
		SendTimer.Start()


	End Sub

	Public Sub TypingDelayGeneric()
		'Debug.Print("Typing Delay Generic Called " & StrokeTauntVal)
		If My.Settings.OfflineMode = True Then
			ssh_DomTask = OfflineConversion(ssh_DomTask)
		End If
		ssh_TypeDelay = ssh_StringLength
		If ssh_TypeDelay > 60 Then ssh_TypeDelay = 60
		If FrmSettings.typeinstantlyCheckBox.Checked = True Or ssh_RapidCode = True = True Then ssh_TypeDelay = 0
		If ssh_HypnoGen = True And CBHypnoGenNoText.Checked = True Then ssh_TypeDelay = 0
		Timer1.Start()

	End Sub

	Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick

		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then Return

		ssh_DomTyping = True
		Dim ShowPicture As Boolean = False


		' Let the program know that the domme is currently typing
		ssh_DomTypeCheck = True




		If CBHypnoGenNoText.Checked = True And ssh_HypnoGen = True Then ssh_NullResponse = True
		If ssh_DomTask.Contains("@SlideshowOff") Then CustomSlideshowTimer.Stop()

		'Debug.Print("Nullresponse = " & NullResponse)
		If ssh_DomTask.Contains("@NullResponse") Then
			ssh_NullResponse = True
		Else
			ssh_RapidCode = False
		End If


		If Not ssh_Group.Contains("D") And Not ssh_DomTask.Contains("@Contact1") And Not ssh_DomTask.Contains("@Contact2") And Not ssh_DomTask.Contains("@Contact3") Then
			Dim GroupList As New List(Of String)
			GroupList.Clear()
			If ssh_Group.Contains("1") Then GroupList.Add(" @Contact1 ")
			If ssh_Group.Contains("2") Then GroupList.Add(" @Contact2 ")
			If ssh_Group.Contains("3") Then GroupList.Add(" @Contact3 ")
			ssh_DomTask = ssh_DomTask & GroupList(ssh_randomizer.Next(0, GroupList.Count))
		End If


		If ssh_NullResponse = True Then
			Timer1.Stop()
			GoTo NullResponse
		End If

		'Debug.Print("CBHypnoGenNoText.Enabled = " & CBHypnoGenNoText.Enabled)
		'Debug.Print("HypnoGen = " & HypnoGen)

		' Debug.Print("TypeToggle = " & TypeToggle)
		'Debug.Print("TypeDelay = " & TypeDelay)


		' Toggle switch to let the program know when to display "Domme is typing..." and when to remove it and display what she wrote
		If ssh_TypeToggle = 0 Then
			'Debug.Print("TypeDelay = " & TypeDelay)
			If ssh_TypeDelay > 0 Then
				ssh_TypeDelay -= 1
			Else
				Timer1.Stop()
				'Debug.Print("NullCommand DomTask = " & DomTask)
				If ssh_RiskyDeal = True Then FrmCardList.LblRiskType.Visible = True
				If ssh_NullResponse = False Then
					ssh_IsTyping = True
					Dim TypingName As String = domName.Text
					If ssh_DomTask.Contains("@Contact1") Then TypingName = FrmSettings.TBGlitter1.Text
					If ssh_DomTask.Contains("@Contact2") Then TypingName = FrmSettings.TBGlitter2.Text
					If ssh_DomTask.Contains("@Contact3") Then TypingName = FrmSettings.TBGlitter3.Text
					'If TypingName <> domName.Text Then JustShowedBlogImage = True

					If ssh_DomTask.Contains("@EmoteMessage") Then ssh_EmoMes = True

					If ssh_DomTask.Contains("@SystemMessage") Then
						ssh_SysMes = True
						ssh_TypeDelay = 0
						GoTo SkipIsTyping
					End If

					' If FrmSettings.CBWebtease.Checked = True Then GoTo SkipIsTyping

					If FrmSettings.CBWebtease.Checked = True Then

						ChatText.DocumentText = ssh_Chat & "<font color=""DimGray""><center><i>" & TypingName & " is typing...</i><center></font>"
						ChatText2.DocumentText = ssh_Chat & "<font color=""DimGray""><center><i>" & TypingName & " is typing...</i><center></font>"
						ChatReadyState()

					Else

						ChatText.DocumentText = ssh_Chat & "<font color=""DimGray""><i>" & TypingName & " is typing...</i></font>"
						ChatText2.DocumentText = ssh_Chat & "<font color=""DimGray""><i>" & TypingName & " is typing...</i></font>"
						ChatReadyState()

					End If

SkipIsTyping:

				End If




				ssh_TypeToggle = 1
				ssh_StringLength = ssh_DomTask.Length
				If ssh_DivideText = True Then
					ssh_StringLength /= 3
					ssh_DivideText = False
				End If
				If ssh_RLGLGame = True Then ssh_StringLength = 0
				If FrmSettings.typeinstantlyCheckBox.Checked = True Or ssh_RapidCode = True Then ssh_StringLength = 0
				If ssh_HypnoGen = True And CBHypnoGenNoText.Checked = True Then ssh_StringLength = 0
				TypingDelayGeneric()
			End If

		Else

			If ssh_TypeDelay > 0 Then
				ssh_TypeDelay -= 1
				If ssh_DomTask.Contains("@SystemMessage") Then ssh_TypeDelay = 0

			Else
				ssh_TypeToggle = 0
				Timer1.Stop()
				ssh_IsTyping = False
				If ssh_RiskyDeal = True Then FrmCardList.LblRiskType.Visible = False

				ssh_ResponseYes = ""
				ssh_ResponseNo = ""

				' If PreCleanString.Contains("#") Then GoTo PoundLoop

				' DomTask = PreCleanString


				If ssh_DomTask.Contains("@ShowHardcoreImage") Then ssh_JustShowedBlogImage = True
				If ssh_DomTask.Contains("@ShowSoftcoreImage") Then ssh_JustShowedBlogImage = True
				If ssh_DomTask.Contains("@ShowLesbianImage") Then ssh_JustShowedBlogImage = True
				If ssh_DomTask.Contains("@ShowBlowjobImage") Then ssh_JustShowedBlogImage = True
				If ssh_DomTask.Contains("@ShowFemdomImage") Then ssh_JustShowedBlogImage = True
				If ssh_DomTask.Contains("@ShowLezdomImage") Then ssh_JustShowedBlogImage = True
				If ssh_DomTask.Contains("@ShowHentaiImage") Then ssh_JustShowedBlogImage = True
				If ssh_DomTask.Contains("@ShowGayImage") Then ssh_JustShowedBlogImage = True
				If ssh_DomTask.Contains("@ShowMaledomImage") Then ssh_JustShowedBlogImage = True
				If ssh_DomTask.Contains("@ShowCaptionsImage") Then ssh_JustShowedBlogImage = True
				If ssh_DomTask.Contains("@ShowGeneralImage") Then ssh_JustShowedBlogImage = True
				If ssh_DomTask.Contains("@ShowImage") Then ssh_JustShowedBlogImage = True
				If ssh_DomTask.Contains("@ShowLocalImage") Then ssh_JustShowedBlogImage = True
				If ssh_DomTask.Contains("@ShowBlogImage") Then ssh_JustShowedBlogImage = True
				If ssh_DomTask.Contains("@NewBlogImage") Then ssh_JustShowedBlogImage = True

				If ssh_DomTask.Contains("@SlideshowFirst") Then ssh_JustShowedSlideshowImage = True
				If ssh_DomTask.Contains("@SlideshowNext") Then ssh_JustShowedSlideshowImage = True
				If ssh_DomTask.Contains("@SlideshowPrevious") Then ssh_JustShowedSlideshowImage = True
				If ssh_DomTask.Contains("@SlideshowLast") Then ssh_JustShowedSlideshowImage = True



				'Debug.Print("TeaseRadio = " & FrmSettings.teaseRadio.Checked)
				'Debug.Print("JustShowedBlogImage = " & JustShowedBlogImage)
				'Debug.Print("TeaseVideo  = " & TeaseVideo)
				'Debug.Print("DomTask = " & DomTask)
				'Debug.Print("NullResponse = " & NullResponse)
				'Debug.Print("SlideshowLoaded = " & SlideshowLoaded)
				'Debug.Print("SubStroking = " & SubStroking)
				'Debug.Print("SubEdging  = " & SubEdging)
				'Debug.Print("SubHoldingEdge = " & SubHoldingEdge)



				If ssh_GlitterTease = True And ssh_JustShowedBlogImage = False And ssh_LockImage = False Then GoTo TryNextWithTease


				If FrmSettings.teaseRadio.Checked = True And ssh_JustShowedBlogImage = False And ssh_TeaseVideo = False And Not ssh_DomTask.Contains("@NewBlogImage") And ssh_NullResponse = False _
					 And ssh_SlideshowLoaded = True And Not ssh_DomTask.Contains("@ShowButtImage") And Not ssh_DomTask.Contains("@ShowBoobsImage") And Not ssh_DomTask.Contains("@ShowButtsImage") _
					 And Not ssh_DomTask.Contains("@ShowBoobsImage") And ssh_LockImage = False And ssh_CustomSlideshow = False And ssh_RapidFire = False _
					 And UCase(ssh_DomTask) <> "<B>TEASE AI HAS BEEN RESET</B>" And ssh_JustShowedSlideshowImage = False Then
					If ssh_SubStroking = False Or ssh_SubEdging = True Or ssh_SubHoldingEdge = True Then
						' Begin Next Button

						' @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
TryNextWithTease:

						Dim TeaseDirection As Integer = ssh_randomizer.Next(1, 101)

						'Debug.Print("TeaseDirection = " & TeaseDirection)

						If TeaseDirection > FrmSettings.NBNextImageChance.Value Then

							ssh_FileCount -= 1
							If ssh_FileCount < 0 Then
								ssh_FileCount = 0
							End If

							If ssh_DomTask.Contains("@Contact1") Then
								ssh_Contact1PicsCount -= 1
								If ssh_Contact1PicsCount < 0 Then
									ssh_Contact1PicsCount = 0
								End If
							End If

							If ssh_DomTask.Contains("@Contact2") Then
								ssh_Contact2PicsCount -= 1
								If ssh_Contact2PicsCount < 0 Then
									ssh_Contact2PicsCount = 0
								End If
							End If

							If ssh_DomTask.Contains("@Contact3") Then
								ssh_Contact3PicsCount -= 1
								If ssh_Contact3PicsCount < 0 Then
									ssh_Contact3PicsCount = 0
								End If
							End If

						Else


							ssh_FileCount += 1
							If ssh_FileCount > ssh_FileCountMax Then
								If FrmSettings.CBNewSlideshow.Checked = True Then
									ssh_NewDommeSlideshow = True
									ssh_OriginalDommeSlideshow = ssh__ImageFileNames(0)
									LoadDommeImageFolder()
									ssh_NewDommeSlideshow = False
									ssh_DomPic = ssh__ImageFileNames(ssh_FileCount)
								Else
									ssh_FileCount = ssh_FileCountMax
								End If
							End If

							If ssh_DomTask.Contains("@Contact1") Then
								ssh_Contact1PicsCount += 1
								Try
									If ssh_Contact1PicsCount > ssh_Contact1Pics.Count - 1 Then
										ssh_Contact1PicsCount = ssh_Contact1Pics.Count - 1
									End If
								Catch
								End Try
							End If

							If ssh_DomTask.Contains("@Contact2") Then
								ssh_Contact2PicsCount += 1
								Try
									If ssh_Contact2PicsCount > ssh_Contact2Pics.Count - 1 Then
										ssh_Contact2PicsCount = ssh_Contact2Pics.Count - 1
									End If
								Catch
								End Try
							End If

							If ssh_DomTask.Contains("@Contact3") Then
								ssh_Contact3PicsCount += 1
								Try
									If ssh_Contact3PicsCount > ssh_Contact3Pics.Count - 1 Then
										ssh_Contact3PicsCount = ssh_Contact3Pics.Count - 1
									End If
								Catch
								End Try
							End If

						End If

						' @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

						If ssh__ImageFileNames(ssh_FileCount).Contains(".db") Then GoTo TryNextWithTease

						ssh_DomPic = ssh__ImageFileNames(ssh_FileCount)

						If ssh_DomTask.Contains("@Contact1") Then
							Try
								ssh_DomPic = ssh_Contact1Pics(ssh_Contact1PicsCount)
							Catch
								ssh_DomPic = ssh__ImageFileNames(ssh_FileCount)
							End Try
						End If

						If ssh_DomTask.Contains("@Contact2") Then
							Try
								ssh_DomPic = ssh_Contact2Pics(ssh_Contact2PicsCount)
							Catch
								ssh_DomPic = ssh__ImageFileNames(ssh_FileCount)
							End Try
						End If

						If ssh_DomTask.Contains("@Contact3") Then
							Try
								ssh_DomPic = ssh_Contact3Pics(ssh_Contact3PicsCount)
							Catch
								ssh_DomPic = ssh__ImageFileNames(ssh_FileCount)
							End Try
						End If

					End If
					' @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

					' github patch If FrmSettings.CBSlideshowRandom.Checked = True Then FileCount = randomizer.Next(0, FileCountMax + 1)

					If FrmSettings.CBSlideshowRandom.Checked = True Then
						ssh_FileCount = ssh_randomizer.Next(0, ssh_FileCountMax + 1)
						If ssh_Contact1Pics.Count > 0 Then ssh_Contact1PicsCount = ssh_randomizer.Next(0, ssh_Contact1Pics.Count)
						If ssh_Contact2Pics.Count > 0 Then ssh_Contact2PicsCount = ssh_randomizer.Next(0, ssh_Contact2Pics.Count)
						If ssh_Contact3Pics.Count > 0 Then ssh_Contact3PicsCount = ssh_randomizer.Next(0, ssh_Contact3Pics.Count)
					End If


					' @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

					ShowPicture = True

					' End Next Button
					'On Error GoTo TryNextWithTease
					'On Error Resume Next
					' End Next Button
				End If



NullResponse:


				If ssh_DomTask.Contains("@WritingTask(") Then
					Dim WriteFlag As String = GetParentheses(ssh_DomTask, "@WritingTask(")
					ssh_DomTask = ssh_DomTask.Replace(WriteFlag, PoundClean(WriteFlag))
				End If

				If ssh_DomTask.Contains("@Contact1") Or ssh_DomTask.Contains("@Contact2") Or ssh_DomTask.Contains("@Contact3") Then ssh_SubWroteLast = True

				Dim TypeName As String = domName.Text
				Dim TypeColor As String = My.Settings.DomColor
				Dim TypeFont As String = FrmSettings.FontComboBoxD.Text
				Dim TypeSize As String = FrmSettings.NBFontSizeD.Value
				Dim LineSpeaker As String = ""
				If ssh_DomTask.Contains("@Contact1") Then
					TypeName = FrmSettings.TBGlitter1.Text
					TypeColor = Color2Html(My.Settings.GlitterNC1Color)
					TypeFont = "Cambria"
					TypeSize = "3"
					LineSpeaker = "@Contact1 "
				End If
				If ssh_DomTask.Contains("@Contact2") Then
					TypeName = FrmSettings.TBGlitter2.Text
					TypeColor = Color2Html(My.Settings.GlitterNC2Color)
					TypeFont = "Cambria"
					TypeSize = "3"
					LineSpeaker = "@Contact2 "
				End If
				If ssh_DomTask.Contains("@Contact3") Then
					TypeName = FrmSettings.TBGlitter3.Text
					TypeColor = Color2Html(My.Settings.GlitterNC3Color)
					TypeFont = "Cambria"
					TypeSize = "3"
					LineSpeaker = "@Contact3 "
				End If


				If FrmSettings.TTSCheckBox.Checked = True And FrmSettings.TTSComboBox.Text <> "No voices installed" Then
					Dim EmoteArray() As String = Split(ssh_DomTask)
					For i As Integer = 0 To EmoteArray.Length - 1
						Try
							If EmoteArray(i).Contains("#") And LCase(EmoteArray(i)).Contains("emote") Then
								EmoteArray(i) = EmoteArray(i).Replace(EmoteArray(i), "")
							End If
						Catch
						End Try
					Next
					ssh_DomTask = Join(EmoteArray)
				End If

				'SaveBlogImage.Text = ""

				'If RiskyDeal = True Then Me.Focus()

				Dim LoopBuffer As Integer = 0



				Do
					LoopBuffer += 1

					Debug.Print("############################### DomTask = " & ssh_DomTask)

					ssh_DomTask = ssh_DomTask.Replace("#Null", "")
					ssh_DomTask = PoundClean(ssh_DomTask)
					If ssh_DomTask.Contains("@EmoteMessage") Then ssh_EmoMes = True
					ssh_DomTask = CommandClean(ssh_DomTask)
					ssh_DomTask = StripCommands(ssh_DomTask)
					ssh_DomTask = ssh_DomTask.Replace("#Null", "")
					ssh_DomTask = PoundClean(ssh_DomTask)

					If LoopBuffer > 4 Then Exit Do

				Loop Until Not ssh_DomTask.Contains("#") And Not ssh_DomTask.Contains("@")




				'Debug.Print("NullResponse = " & NullResponse)
				If CBHypnoGenNoText.Checked = True And ssh_HypnoGen = True Then GoTo HypNoResponse
				If ssh_NullResponse = True Then GoTo NoResponse

				' Dim AtArray() As String = Split(DomTask)
				' For i As Integer = 0 To AtArray.Length - 1
				'If AtArray(i) = "" Then GoTo AtBreak
				'If AtArray(i) = "" Then GoTo AtNext
				' If AtArray(i).Contains("@") Then
				'AtArray(i) = AtArray(i).Replace(AtArray(i), "")
				'End If
				'AtNext:

				' Next

				'DomTask = Join(AtArray)

				'AtBreak:


				If ssh_DomTask.Contains("(") And ssh_DomTask.Contains(")") Then
					Dim ParenReg As RegularExpressions.Regex
					ParenReg = New RegularExpressions.Regex("\(([^\)]*)\)")
					ssh_DomTask = ssh_DomTask.Replace(ParenReg.Match(ssh_DomTask).Value(), "")
				End If

				' Github Patch If SysMes = False And EmoMes = False Then
				If ssh_SysMes = False And ssh_EmoMes = False And Not ssh_DomTask = "" Then

					Try
						Dim UCASELine As String = UCase(ssh_DomTask.Substring(0, 1))
						ssh_DomTask = ssh_DomTask.Remove(0, 1).Insert(0, UCASELine)
					Catch
					End Try


					If FrmSettings.LCaseCheckBox.Checked = True Then ssh_DomTask = LCase(ssh_DomTask)
					If FrmSettings.CBMeMyMine.Checked = True Then
						Dim MeArray() As String = Split(ssh_DomTask)
						For i As Integer = MeArray.Length - 1 To 0 Step -1
							If UCase(MeArray(i)) = "ME" Then MeArray(i) = "Me"
							If UCase(MeArray(i)) = "MY" Then MeArray(i) = "My"
							If UCase(MeArray(i)) = "MINE" Then MeArray(i) = "Mine"
							If UCase(MeArray(i)) = "I" Then MeArray(i) = "I"
							If UCase(MeArray(i)) = "I'D" Then MeArray(i) = "I'd"
							If UCase(MeArray(i)) = "I'M" Then MeArray(i) = "I'm"
							If UCase(MeArray(i)) = "I'LL" Then MeArray(i) = "I'll"
							If UCase(MeArray(i)) = "YOU" Then MeArray(i) = "you"
							If UCase(MeArray(i)) = "YOUR" Then MeArray(i) = "your"
							If UCase(MeArray(i)) = "YOURS" Then MeArray(i) = "yours"
							If UCase(MeArray(i)) = "YOU'RE" Then MeArray(i) = "you're"
							If UCase(MeArray(i)) = "YOU'D" Then MeArray(i) = "you'd"
							If UCase(MeArray(i)) = "YOU'LL" Then MeArray(i) = "you'll"
						Next
						ssh_DomTask = Join(MeArray)
					End If
					If FrmSettings.apostropheCheckBox.Checked = True Then ssh_DomTask = ssh_DomTask.Replace("'", "")
					If FrmSettings.commaCheckBox.Checked = True Then ssh_DomTask = ssh_DomTask.Replace(",", "")
					If FrmSettings.periodCheckBox.Checked = True Then ssh_DomTask = ssh_DomTask.Replace(".", "")

					' Try
					'DomTask = DomTask.Replace("*", FrmSettings.domemoteComboBox.Text.Substring(0, 1))
					'Catch
					'End Try

					Dim EmoToggle As Boolean = True
					For i As Integer = ssh_DomTask.Length - 1 To 0 Step -1
						If ssh_DomTask.Substring(i, 1) = "*" Then
							If EmoToggle = False Then
								EmoToggle = True
								ssh_DomTask = ssh_DomTask.Remove(i, 1).Insert(i, FrmSettings.TBEmote.Text)
							Else
								EmoToggle = False
								ssh_DomTask = ssh_DomTask.Remove(i, 1).Insert(i, FrmSettings.TBEmoteEnd.Text)
							End If
						End If
					Next

					ssh_DomTask = ssh_DomTask.Replace(":d", ":D")
					ssh_DomTask = ssh_DomTask.Replace(": d", ": D")


					'Typo Test

					Try

						Dim RestoreDomTask As String = ssh_DomTask

						If Not ssh_DomTask.Substring(0, 1) = FrmSettings.TBEmote.Text.Substring(0, 1) And Not ssh_DomTask.Contains("<") And ssh_YesOrNo = False And ssh_TypoSwitch <> 0 And ssh_TyposDisabled = False _
							 And FrmSettings.TTSCheckBox.Checked = False Then

							Dim TypoChance As Integer = ssh_randomizer.Next(0, 101)

							If TypoChance < FrmSettings.NBTypoChance.Value Or ssh_TypoSwitch = 2 Then

								Try

									Dim TypoString As String

									Dim TypoSplit As String() = ssh_DomTask.Split(" ")

									ssh_TempVal = ssh_randomizer.Next(0, TypoSplit.Count)

									ssh_CorrectedWord = TypoSplit(ssh_TempVal)

									ssh_CorrectedWord = ssh_CorrectedWord.Replace(",", "")
									ssh_CorrectedWord = ssh_CorrectedWord.Replace(".", "")
									ssh_CorrectedWord = ssh_CorrectedWord.Replace("!", "")
									ssh_CorrectedWord = ssh_CorrectedWord.Replace("?", "")

									TypoString = "w d s f x"


									If LCase(TypoSplit(ssh_TempVal).Substring(0, 1)) = "a" Then TypoString = "q w s z x"
									If LCase(TypoSplit(ssh_TempVal).Substring(0, 1)) = "b" Then TypoString = "f v g h n"
									If LCase(TypoSplit(ssh_TempVal).Substring(0, 1)) = "c" Then TypoString = "x d f v b"
									If LCase(TypoSplit(ssh_TempVal).Substring(0, 1)) = "d" Then TypoString = "s c f x e"
									If LCase(TypoSplit(ssh_TempVal).Substring(0, 1)) = "e" Then TypoString = "s r w 3 d"
									If LCase(TypoSplit(ssh_TempVal).Substring(0, 1)) = "f" Then TypoString = "d r g v c"
									If LCase(TypoSplit(ssh_TempVal).Substring(0, 1)) = "g" Then TypoString = "f t b h y"
									If LCase(TypoSplit(ssh_TempVal).Substring(0, 1)) = "h" Then TypoString = "g b n u j"
									If LCase(TypoSplit(ssh_TempVal).Substring(0, 1)) = "i" Then TypoString = "o u j k l"
									If LCase(TypoSplit(ssh_TempVal).Substring(0, 1)) = "j" Then TypoString = "k u i n h"
									If LCase(TypoSplit(ssh_TempVal).Substring(0, 1)) = "k" Then TypoString = "j m , l i"
									If LCase(TypoSplit(ssh_TempVal).Substring(0, 1)) = "l" Then TypoString = "; p . , i"
									If LCase(TypoSplit(ssh_TempVal).Substring(0, 1)) = "m" Then TypoString = "n j k , l"
									If LCase(TypoSplit(ssh_TempVal).Substring(0, 1)) = "n" Then TypoString = "b h j k m"
									If LCase(TypoSplit(ssh_TempVal).Substring(0, 1)) = "o" Then TypoString = "p 0 i k ;"
									If LCase(TypoSplit(ssh_TempVal).Substring(0, 1)) = "p" Then TypoString = "[ - o ; l"
									If LCase(TypoSplit(ssh_TempVal).Substring(0, 1)) = "q" Then TypoString = "1 w s a 2"
									If LCase(TypoSplit(ssh_TempVal).Substring(0, 1)) = "r" Then TypoString = "4 5 t f d"
									If LCase(TypoSplit(ssh_TempVal).Substring(0, 1)) = "s" Then TypoString = "w d a z x"
									If LCase(TypoSplit(ssh_TempVal).Substring(0, 1)) = "t" Then TypoString = "5 6 g y r"
									If LCase(TypoSplit(ssh_TempVal).Substring(0, 1)) = "u" Then TypoString = "y 7 j i k"
									If LCase(TypoSplit(ssh_TempVal).Substring(0, 1)) = "v" Then TypoString = "c f g h b"
									If LCase(TypoSplit(ssh_TempVal).Substring(0, 1)) = "w" Then TypoString = "2 a e q s"
									If LCase(TypoSplit(ssh_TempVal).Substring(0, 1)) = "x" Then TypoString = "z s d f c"
									If LCase(TypoSplit(ssh_TempVal).Substring(0, 1)) = "y" Then TypoString = "t 7 h u g"
									If LCase(TypoSplit(ssh_TempVal).Substring(0, 1)) = "z" Then TypoString = "a s x d c"


									Dim UpperChance As Integer = ssh_randomizer.Next(0, 101)
									If UpperChance < 26 Then TypoString = UCase(TypoString)



									Dim GetTypo As String() = TypoString.Split(" ")

									Dim MadeTypo As String = GetTypo(ssh_randomizer.Next(0, GetTypo.Count))


									Dim DoubleChance As Integer = ssh_randomizer.Next(0, 101)
									If DoubleChance < 11 Then MadeTypo = MadeTypo & LCase(GetTypo(ssh_randomizer.Next(0, GetTypo.Count)))


									TypoSplit(ssh_TempVal) = TypoSplit(ssh_TempVal).Remove(0, 1)

									Dim SpaceChance As Integer = ssh_randomizer.Next(0, 101)
									If SpaceChance < 7 Then
										TypoSplit(ssh_TempVal) = MadeTypo & " " & TypoSplit(ssh_TempVal)
									Else
										TypoSplit(ssh_TempVal) = MadeTypo & TypoSplit(ssh_TempVal)

									End If

									ssh_DomTask = Join(TypoSplit)

									ssh_CorrectedTypo = True

								Catch

									ssh_DomTask = RestoreDomTask
									ssh_CorrectedTypo = False
								End Try

							End If

						End If

						ssh_TypoSwitch = 1

					Catch
					End Try


				End If

				ssh_DomTask = ssh_DomTask.Replace("ATSYMBOL", "@")
				ssh_DomTask = ssh_DomTask.Replace("atsymbol", "@")

				If ssh_InputIcon = True Then
					' github patch DomTask = DomTask & " <img src=""file://" & Application.StartupPath & "/Images/System/input.png""/>"
					ssh_DomTask = ssh_DomTask & " <img src=""file://" & Application.StartupPath & "/Images/System/input.png"" title=""This icon means your Domme will remember your answer!""/>"
					ssh_InputIcon = False
				End If

				ssh_DomTask = ssh_DomTask.Replace(" a a", " an a")
				ssh_DomTask = ssh_DomTask.Replace(" a e", " an e")
				ssh_DomTask = ssh_DomTask.Replace(" a i", " an i")
				ssh_DomTask = ssh_DomTask.Replace(" a o", " an o")
				ssh_DomTask = ssh_DomTask.Replace(" a u", " an u")

				ssh_DomTask = ssh_DomTask.Replace(" an uni", " a uni")
				ssh_DomTask = ssh_DomTask.Replace(" an utensil", " a utensil")
				ssh_DomTask = ssh_DomTask.Replace(" an ukulele", " a ukulele")
				ssh_DomTask = ssh_DomTask.Replace(" an use", " a use")
				ssh_DomTask = ssh_DomTask.Replace(" an urethra", " a urethra")
				ssh_DomTask = ssh_DomTask.Replace(" an urine", " a urine")
				ssh_DomTask = ssh_DomTask.Replace(" an usual", " a usual")
				ssh_DomTask = ssh_DomTask.Replace(" an utility", " a utility")
				ssh_DomTask = ssh_DomTask.Replace(" an uterus", " a uterus")
				ssh_DomTask = ssh_DomTask.Replace(" an utopia", " a utopia")


				'SUGGESTION: (Stefaf) All Writing to the Chatbox and Wating for fetched Images shoud be in a separat Function. 
				' If Sync of Reseults is activated
				' Wait for the ImageFetcher to Finish 
				If BWimageFetcher.TriggerRequired _
					Then BWimageFetcher.WaitToFinish()

				Dim TextColor As String = Color2Html(My.Settings.ChatTextColor)

				If ssh_NullResponse = False And ssh_DomTask <> "" Then

					If UCase(ssh_DomTask) = "<B>TEASE AI HAS BEEN RESET</B>" Then ssh_DomTask = "<b>Tease AI has been reset</b>"


					If ssh_SysMes = True Then
						ssh_Chat = "<body style=""word-wrap:break-word;"">" & "<font face=""" & "Cambria" & """ size=""" & "3" & """ color=""#000000"">" & ssh_Chat & "<font color=""SteelBlue""><b>" & ssh_DomTask & "</b><br></font></body>"
						ssh_SysMes = False
						ChatText.DocumentText = ssh_Chat
						ChatText2.DocumentText = ssh_Chat
						ChatReadyState()
						GoTo EndSysMes
					End If

					If ssh_EmoMes = True Then
						ssh_Chat = "<body style=""word-wrap:break-word;"">" & "<font face=""" & "Cambria" & """ size=""" & "3" & """ color=""#000000"">" & ssh_Chat & "<font color=""" &
						   TypeColor & """><b><i>" & ssh_DomTask & "</i></b><br></font></body>"
						ssh_EmoMes = False
						ChatText.DocumentText = ssh_Chat
						ChatText2.DocumentText = ssh_Chat
						ChatReadyState()
						GoTo EndSysMes
					End If

					' Add timestamps to domme response if the option is checked in the menu
					If FrmSettings.timestampCheckBox.Checked = True And FrmSettings.CBWebtease.Checked = False Then
						ssh_Chat = ssh_Chat & "<font face=""Cambria"" size=""2"" color=""DimGray"">" & (Date.Now.ToString("hh:mm tt ")) & "</font>"
					End If



					If ssh_SubWroteLast = False And FrmSettings.shownamesCheckBox.Checked = False Then


						If FrmSettings.CBWebtease.Checked = True Then
							ssh_Chat = "<body bgcolor=""" & Color2Html(My.Settings.ChatWindowColor) & """>" & "</body><body style=""word-wrap:break-word;"">" & "<font face=""" & FrmSettings.FontComboBoxD.Text & """ size=""" & FrmSettings.NBFontSizeD.Value & """ color=""" &
								 TextColor & """><center>" & ssh_DomTask & "</center><br></font></body>"
						Else
							ssh_Chat = "<body style=""word-wrap:break-word;"">" & "<font face=""" & FrmSettings.FontComboBoxD.Text & """ size=""" & FrmSettings.NBFontSizeD.Value & """ color=""" &
								 TextColor & """>" & ssh_Chat & ssh_DomTask & "<br></font></body>"
						End If


						ChatText.DocumentText = ssh_Chat
						ChatText2.DocumentText = ssh_Chat
						ChatReadyState()

						If ssh_RiskyDeal = True Then FrmCardList.WBRiskyChat.DocumentText = "<body style=""word-wrap:break-word;""><font face=""Cambria"" size=""3"" font color=""" &
						  TypeColor & """><b>" & TypeName & ": </b></font><font face=""" & TypeFont & """ size=""" & TypeSize & """ color=""" & TextColor & """>" & ssh_DomTask & "<br></font></body>"


					Else


						If FrmSettings.CBWebtease.Checked = True Then
							ssh_Chat = "<body bgcolor=""" & Color2Html(My.Settings.ChatWindowColor) & """>" & "</body><body style=""word-wrap:break-word;"">" & "<font face=""" & FrmSettings.FontComboBoxD.Text & """ size=""" & FrmSettings.NBFontSizeD.Value & """ color=""" &
							  TextColor & """><center>" & ssh_DomTask & "</center><br></font></body>"
						Else
							ssh_Chat = "<body style=""word-wrap:break-word;"">" & ssh_Chat & "<font face=""Cambria"" size=""3"" font color=""" &
							TypeColor & """><b>" & TypeName & ": </b></font><font face=""" & TypeFont & """ size=""" & TypeSize & """ color=""" & TextColor & """>" & ssh_DomTask & "<br></font></body>"
						End If





						ssh_TypeToggle = 0
						ChatText.DocumentText = ssh_Chat
						ChatText2.DocumentText = ssh_Chat
						ChatReadyState()

						If ssh_RiskyDeal = True Then FrmCardList.WBRiskyChat.DocumentText = "<body style=""word-wrap:break-word;""><font face=""Cambria"" size=""3"" font color=""" &
						  TypeColor & """><b>" & TypeName & ": </b></font><font face=""" & TypeFont & """ size=""" & TypeSize & """ color=""" & TextColor & """>" & ssh_DomTask & "<br></font></body>"

					End If

EndSysMes:



					ScrollChatDown()

					If FrmSettings.CBAutosaveChatlog.Checked = True Then My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Chatlogs\Autosave.html", ChatText.DocumentText, False)

					' Dsplay the next picture in the slideshow as the domme responds if "With Tease" radio button is checked



					ssh_SubWroteLast = False

				End If

				' If Sync of Reseults is activated
				' Wait for the ImageFetcher to Finish 
				If BWimageFetcher.TriggerRequired _
					Then BWimageFetcher.WaitToFinish()

				If ssh_JustShowedBlogImage = True Then GoTo HypNoResponse


				If ShowPicture = True Or ssh_DommeImageFound = True Then



					Try
						If ssh_RiskyDeal = True Then
							' ######################## Risky Pick #########################
							FrmCardList.PBRiskyPic.Image = Image.FromFile(ssh_DomPic)
						ElseIf ssh_DommeImageFound = True Then
							' ######################## Domme Tags #########################
							ShowImage(ssh_DommeImageSTR, True)
							ssh_DommeImageFound = False
						ElseIf ssh_LocalImageFound = True Then
							' ######################## Local Img. #########################
							ShowImage(ssh_LocalImageSTR, True)
							ssh_LocalImageFound = False
						Else
							' ######################## Slideshow ##########################
							ShowImage(ssh_DomPic, True)
						End If
					Catch ex As Exception
						'@@@@@@@@@@@@@@@@@@@@@@@ Exception @@@@@@@@@@@@@@@@@@@@@@@@
						Debug.Print(ex.Message & vbCrLf & ex.StackTrace)
						ClearMainPictureBox()
						' GoTo TryNextWithTease
					End Try
					If FrmSettings.landscapeCheckBox.Checked = True Then
						If mainPictureBox.Image.Width > mainPictureBox.Image.Height Then
							mainPictureBox.SizeMode = PictureBoxSizeMode.StretchImage
						Else
							mainPictureBox.SizeMode = PictureBoxSizeMode.Zoom
						End If
					Else
						mainPictureBox.SizeMode = PictureBoxSizeMode.Zoom
					End If

					mainPictureBox.Refresh()
					mainPictureBox.Invalidate()
					ShowPicture = False
				End If



HypNoResponse:

				If FrmSettings.TTSCheckBox.Checked = True And FrmSettings.TTSComboBox.Text <> "No voices installed" Then
					Debug.Print(ssh_DomTask)
					ssh_DomTask = StripFormat(ssh_DomTask)

					mciSendString("CLOSE Speech1", String.Empty, 0, 0)
					mciSendString("CLOSE Echo1", String.Empty, 0, 0)

					Dim SpeechDir As String = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Apps\Hypnotic Guide\TempWav.wav"

					ssh_synth2.SelectVoice(FrmSettings.TTSComboBox.Text)
					ssh_synth2.SetOutputToWaveFile(SpeechDir, New SpeechAudioFormatInfo(32000, AudioBitsPerSample.Sixteen, AudioChannel.Mono))
					ssh_synth2.Speak(ssh_DomTask)
					ssh_synth2.SetOutputToNull()

					SpeechDir = GetShortPathName(SpeechDir)

					mciSendString("OPEN " & SpeechDir & " TYPE WAVEAUDIO ALIAS Speech1", String.Empty, 0, 0)
					mciSendString("PLAY Speech1 FROM 0", String.Empty, 0, 0)



					If CBHypnoGenPhase.Checked And ssh_HypnoGen = True Then
						Delay(0.4)
						mciSendString("OPEN " & SpeechDir & " TYPE WAVEAUDIO ALIAS Echo1", String.Empty, 0, 0)
						mciSendString("PLAY Echo1 FROM 0", String.Empty, 0, 0)
					End If

				End If

NoResponse:
				' If Sync of Reseults is activated
				' Wait for the ImageFetcher to Finish 
				If BWimageFetcher.TriggerRequired _
					Then BWimageFetcher.WaitToFinish()

				If ssh_CorrectedTypo = True Then
					ssh_CorrectedTypo = False
					'DomTask = "*" & CorrectedWord
					ssh_DomTask = LineSpeaker & "*" & ssh_CorrectedWord
					TypingDelayGeneric()
					Return
				End If

				StrokeSpeedCheck()

				If ssh_SubStroking = False Then
					StrokePace = 0
					If FrmSettings.TBWebStop.Text <> "" Then
						Try
							FrmSettings.WebToy.Navigate(FrmSettings.TBWebStop.Text)
						Catch
						End Try
					End If
				End If

				If ssh_RLGLGame = True And ssh_RedLight = False Then
					If (DomWMP.playState = WMPLib.WMPPlayState.wmppsPaused) Then
						DomWMP.Ctlcontrols.play()


						ssh_AskedToSpeedUp = False
						ssh_AskedToSlowDown = False
						ssh_SubStroking = True
						ssh_SubEdging = False
						ssh_SubHoldingEdge = False
						ssh_StopMetronome = False
						StrokePace = ssh_randomizer.Next(NBMaxPace.Value, NBMinPace.Value + 1)
						StrokePace = 50 * Math.Round(StrokePace / 50)
						ssh_RLGLTauntTick = ssh_randomizer.Next(20, 31)
						' VideoTauntTick = randomizer.Next(20, 31)
						RLGLTauntTimer.Start()

					End If
				End If

				If ssh_RLGLGame = True And ssh_RedLight = True Then
					If (DomWMP.playState = WMPLib.WMPPlayState.wmppsPlaying) Then
						DomWMP.Ctlcontrols.pause()
						ssh_SubStroking = False
						ssh_StopMetronome = True
						StrokePace = 0
						'VideoTauntTimer.Stop()
					End If
				End If



				ssh_NullResponse = False

				If ssh_FollowUp <> "" Then
					ssh_DomTask = ssh_FollowUp
					Debug.Print("FollowUp DomTask = " & ssh_DomTask)
					ssh_FollowUp = ""
					TypingDelayGeneric()
					Exit Sub
				End If

				ssh_DomTypeCheck = False
				ssh_DomTyping = False
				'StringLength = 20
				ssh_StringLength = ssh_randomizer.Next(8, 16)

				If ssh_SubStroking = False Then ssh_StopMetronome = True
				If ssh_SubHoldingEdge = True Then
					StrokePace = 0
				End If
				'Debug.Print("End of DomTask #######################################################################################################################")
				'JustShowedBlogImage = False

				If ssh_TempScriptCount = 0 Then
					ssh_JustShowedBlogImage = False
					ssh_JustShowedSlideshowImage = False
				End If


				If ssh_CBTCockActive = True Then
					ssh_CBTCockActive = False
					CBTCock()
				End If

				If ssh_CBTBallsActive = True Then
					ssh_CBTBallsActive = False
					CBTBalls()
				End If

				If ssh_CBTBothActive = True Then
					ssh_CBTBothActive = False
					CBTBoth()
				End If

				If ssh_CustomTaskActive = True Then
					ssh_CustomTaskActive = False
					RunCustomTask()
				End If

				If ssh_YesOrNo = False Then
					If ssh_RapidCode = True Then
						RunFileText()
					Else
						ssh_ScriptTick = ssh_randomizer.Next(4, 7)
						If ssh_RapidFire = True Then ssh_ScriptTick = 1
						If ssh_RiskyDeal = True Then ssh_ScriptTick = 2
						ScriptTimer.Start()
					End If
				End If

				If ssh_YesOrNo = True And ssh_RiskyDeal = True Then
					FrmCardList.BTNPickIt.Visible = True
					FrmCardList.BTNRiskIt.Visible = True
					FrmCardList.HighlightCaseLabelsOffer()

				End If

				ssh_GotoFlag = False


				If ssh_SubGaveUp = True Then

					ssh_SubGaveUp = False

					ssh_AskedToGiveUpSection = False
					If TnASlides.Enabled = True Then TnASlides.Stop()

					Dim WasStroking As Boolean = ssh_SubStroking
					Dim WasEdging As Boolean = ssh_SubEdging
					Dim WasHolding As Boolean = ssh_SubHoldingEdge

					StopEverything()
					ssh_ModuleEnd = False
					ssh_ShowModule = False

					'DelayFlag = True
					'DelayTick = randomizer.Next(3, 6)

					'DelayTimer.Start()

					'Do
					'   Application.DoEvents()
					'Loop Until DelayFlag = False

					'LastScriptCountdown -= 1
					'Debug.Print("LastScriptCountdown = " & LastScriptCountdown)

					'FrmSettings.LBLOrgasmCountdown.Text = LastScriptCountdown

					'StrokeTauntVal = -1

					'If TeaseTick < 1 And Playlist = False Then
					'RunLastScript()
					'ElseIf WasStroking Then
					'RunModuleScript(False)
					'Else
					'RunLinkScript()
					'End If



					If ssh_ReturnFlag Then
						ssh_ShowModule = True
						ScriptTimer.Start()
					ElseIf ssh_TeaseTick < 1 And ssh_Playlist = False Then
						ssh_StrokeTauntVal = -1
						RunLastScript()
					ElseIf WasStroking And Not WasEdging And Not WasHolding Then
						ssh_StrokeTauntVal = -1
						RunModuleScript(False)
					Else
						ssh_StrokeTauntVal = -1
						RunLinkScript()
					End If



				End If



			End If
		End If

	End Sub
	Private Function playingStatus() As Boolean

		Dim retval As Integer
		Dim returnData As String = Space(128)

		retval = mciSendString("status Speech1 mode", returnData, 128, 0)

		If returnData.Substring(0, 7) = "playing" Then

			playingStatus = True

		Else

			playingStatus = False

		End If

	End Function

	Public Shared Function GetShortPathName(ByVal longPath As String) As String
		Const MaxPath As Int32 = 260
		Const SBStartSize As Int32 = MaxPath + 1
		Dim sb As New System.Text.StringBuilder(SBStartSize)
		Dim len As Int32 = GetShortPathName(longPath, sb, sb.Length - 1)
		Return sb.ToString()
	End Function

	<System.Runtime.InteropServices.DllImport("kernel32.dll", CharSet:=System.Runtime.InteropServices.CharSet.Ansi, EntryPoint:="GetShortPathNameA")>
	Public Shared Function GetShortPathName(ByVal lpszLongPath As String,
										<System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPStr)> ByVal lpszShortPath As System.Text.StringBuilder,
										ByVal cchBuffer As Int32) As Int32
	End Function

	Private Sub SendTimer_Tick(sender As System.Object, e As System.EventArgs) Handles SendTimer.Tick

		If ssh_DomChat.Contains("@SlideshowOff") Then CustomSlideshowTimer.Stop()
		If ssh_DomChat.Contains("@NullResponse") Then
			ssh_NullResponse = True
		Else
			ssh_RapidCode = False
		End If

		If Not ssh_Group.Contains("D") And Not ssh_DomChat.Contains("@Contact1") And Not ssh_DomChat.Contains("@Contact2") And Not ssh_DomChat.Contains("@Contact3") Then
			Dim GroupList As New List(Of String)
			GroupList.Clear()
			If ssh_Group.Contains("1") Then GroupList.Add(" @Contact1 ")
			If ssh_Group.Contains("2") Then GroupList.Add(" @Contact2 ")
			If ssh_Group.Contains("3") Then GroupList.Add(" @Contact3 ")
			ssh_DomChat = ssh_DomChat & GroupList(ssh_randomizer.Next(0, GroupList.Count))
		End If

		If ssh_NullResponse = True Then
			SendTimer.Stop()
			GoTo NullResponseLine
		End If

		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then Return

		Dim ShowPicture As Boolean = False

		' Let the program know that the domme is currently typing
		ssh_DomTypeCheck = True

		' Toggle switch to let the program know when to display "Domme is typing..." and when to remove it and display what she wrote
		If ssh_TypeToggle = 0 Then
			If ssh_TypeDelay > 0 Then
				ssh_TypeDelay -= 1
			Else

				SendTimer.Stop()

				If ssh_RiskyDeal = True Then FrmCardList.LblRiskType.Visible = True
				ssh_IsTyping = True
				Dim TypingName As String = domName.Text
				If ssh_DomChat.Contains("@Contact1") Then TypingName = FrmSettings.TBGlitter1.Text
				If ssh_DomChat.Contains("@Contact2") Then TypingName = FrmSettings.TBGlitter2.Text
				If ssh_DomChat.Contains("@Contact3") Then TypingName = FrmSettings.TBGlitter3.Text

				If ssh_DomChat.Contains("@EmoteMessage") Then ssh_EmoMes = True

				If ssh_DomChat.Contains("@SystemMessage") Then
					ssh_SysMes = True
					ssh_TypeDelay = 0
					GoTo SkipIsTyping
				End If

				If FrmSettings.CBWebtease.Checked = True Then

					ChatText.DocumentText = ssh_Chat & "<font color=""DimGray""><center><i>" & TypingName & " is typing...</i><center></font>"
					ChatText2.DocumentText = ssh_Chat & "<font color=""DimGray""><center><i>" & TypingName & " is typing...</i><center></font>"
					ChatReadyState()

				Else

					ChatText.DocumentText = ssh_Chat & "<font color=""DimGray""><i>" & TypingName & " is typing...</i></font>"
					ChatText2.DocumentText = ssh_Chat & "<font color=""DimGray""><i>" & TypingName & " is typing...</i></font>"
					ChatReadyState()

				End If





SkipIsTyping:

				ssh_TypeToggle = 1
				ssh_StringLength = ssh_DomChat.Length
				If ssh_DivideText = True Then
					ssh_StringLength /= 3
					ssh_DivideText = False
				End If
				If FrmSettings.typeinstantlyCheckBox.Checked = True Or ssh_RapidCode = True Then ssh_StringLength = 0
				TypingDelay()
			End If

		Else

			If ssh_TypeDelay > 0 Then
				ssh_TypeDelay -= 1
				If ssh_DomChat.Contains("@SystemMessage") Then ssh_TypeDelay = 0
			Else
				ssh_TypeToggle = 0
				SendTimer.Stop()
				ssh_IsTyping = False

				ssh_ResponseYes = ""
				ssh_ResponseNo = ""

				If ssh_RiskyDeal = True Then FrmCardList.LblRiskType.Visible = False

NullResponseLine:

				If ssh_DomChat.Contains("@ShowHardcoreImage") Then ssh_JustShowedBlogImage = True
				If ssh_DomChat.Contains("@ShowSoftcoreImage") Then ssh_JustShowedBlogImage = True
				If ssh_DomChat.Contains("@ShowLesbianImage") Then ssh_JustShowedBlogImage = True
				If ssh_DomChat.Contains("@ShowBlowjobImage") Then ssh_JustShowedBlogImage = True
				If ssh_DomChat.Contains("@ShowFemdomImage") Then ssh_JustShowedBlogImage = True
				If ssh_DomChat.Contains("@ShowLezdomImage") Then ssh_JustShowedBlogImage = True
				If ssh_DomChat.Contains("@ShowHentaiImage") Then ssh_JustShowedBlogImage = True
				If ssh_DomChat.Contains("@ShowGayImage") Then ssh_JustShowedBlogImage = True
				If ssh_DomChat.Contains("@ShowMaledomImage") Then ssh_JustShowedBlogImage = True
				If ssh_DomChat.Contains("@ShowCaptionsImage") Then ssh_JustShowedBlogImage = True
				If ssh_DomChat.Contains("@ShowGeneralImage") Then ssh_JustShowedBlogImage = True
				If ssh_DomChat.Contains("@ShowImage") Then ssh_JustShowedBlogImage = True
				If ssh_DomChat.Contains("@ShowLocalImage") Then ssh_JustShowedBlogImage = True
				If ssh_DomChat.Contains("@ShowBlogImage") Then ssh_JustShowedBlogImage = True
				If ssh_DomChat.Contains("@NewBlogImage") Then ssh_JustShowedBlogImage = True

				If ssh_DomChat.Contains("@SlideshowFirst") Then ssh_JustShowedSlideshowImage = True
				If ssh_DomChat.Contains("@SlideshowNext") Then ssh_JustShowedSlideshowImage = True
				If ssh_DomChat.Contains("@SlideshowPrevious") Then ssh_JustShowedSlideshowImage = True
				If ssh_DomChat.Contains("@SlideshowLast") Then ssh_JustShowedSlideshowImage = True

				If ssh_GlitterTease = True And ssh_JustShowedBlogImage = False Then GoTo TryNextWithTease

				If FrmSettings.teaseRadio.Checked = True And ssh_JustShowedBlogImage = False And ssh_TeaseVideo = False And Not ssh_DomTask.Contains("@NewBlogImage") And ssh_NullResponse = False _
					And ssh_SlideshowLoaded = True And Not ssh_DomChat.Contains("@ShowButtImage") And Not ssh_DomChat.Contains("@ShowBoobsImage") And Not ssh_DomChat.Contains("@ShowButtsImage") _
					And Not ssh_DomChat.Contains("@ShowBoobImage") And ssh_LockImage = False And ssh_CustomSlideshow = False And ssh_RapidFire = False _
					And UCase(ssh_DomChat) <> "<B>TEASE AI HAS BEEN RESET</B>" And ssh_JustShowedSlideshowImage = False Then
					If ssh_SubStroking = False Or ssh_SubEdging = True Or ssh_SubHoldingEdge = True Then
						' Begin Next Button

						' @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
TryNextWithTease:

						Dim TeaseDirection As Integer = ssh_randomizer.Next(1, 101)

						'Debug.Print("TeaseDirection = " & TeaseDirection)

						If TeaseDirection > FrmSettings.NBNextImageChance.Value Then

							ssh_FileCount -= 1
							If ssh_FileCount < 0 Then
								ssh_FileCount = 0
							End If

							If ssh_DomTask.Contains("@Contact1") Then
								ssh_Contact1PicsCount -= 1
								If ssh_Contact1PicsCount < 0 Then
									ssh_Contact1PicsCount = 0
								End If
							End If

							If ssh_DomTask.Contains("@Contact2") Then
								ssh_Contact2PicsCount -= 1
								If ssh_Contact2PicsCount < 0 Then
									ssh_Contact2PicsCount = 0
								End If
							End If

							If ssh_DomTask.Contains("@Contact3") Then
								ssh_Contact3PicsCount -= 1
								If ssh_Contact3PicsCount < 0 Then
									ssh_Contact3PicsCount = 0
								End If
							End If

						Else


							ssh_FileCount += 1
							If ssh_FileCount > ssh_FileCountMax Then
								If FrmSettings.CBNewSlideshow.Checked = True Then
									ssh_NewDommeSlideshow = True
									ssh_OriginalDommeSlideshow = ssh__ImageFileNames(0)
									LoadDommeImageFolder()
									ssh_NewDommeSlideshow = False
									ssh_DomPic = ssh__ImageFileNames(ssh_FileCount)
								Else
									ssh_FileCount = ssh_FileCountMax
								End If
							End If

							If ssh_DomTask.Contains("@Contact1") Then
								ssh_Contact1PicsCount += 1
								Try
									If ssh_Contact1PicsCount > ssh_Contact1Pics.Count - 1 Then
										ssh_Contact1PicsCount = ssh_Contact1Pics.Count - 1
									End If
								Catch
								End Try
							End If

							If ssh_DomTask.Contains("@Contact2") Then
								ssh_Contact2PicsCount += 1
								Try
									If ssh_Contact2PicsCount > ssh_Contact2Pics.Count - 1 Then
										ssh_Contact2PicsCount = ssh_Contact2Pics.Count - 1
									End If
								Catch
								End Try
							End If

							If ssh_DomTask.Contains("@Contact3") Then
								ssh_Contact3PicsCount += 1
								Try
									If ssh_Contact3PicsCount > ssh_Contact3Pics.Count - 1 Then
										ssh_Contact3PicsCount = ssh_Contact3Pics.Count - 1
									End If
								Catch
								End Try
							End If

						End If

						' @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

						If ssh__ImageFileNames(ssh_FileCount).Contains(".db") Then GoTo TryNextWithTease

						ssh_DomPic = ssh__ImageFileNames(ssh_FileCount)

						If ssh_DomChat.Contains("@Contact1") Then
							Try
								ssh_DomPic = ssh_Contact1Pics(ssh_Contact1PicsCount)
							Catch
								ssh_DomPic = ssh__ImageFileNames(ssh_FileCount)
							End Try
						End If

						If ssh_DomChat.Contains("@Contact2") Then
							Try
								ssh_DomPic = ssh_Contact2Pics(ssh_Contact2PicsCount)
							Catch
								ssh_DomPic = ssh__ImageFileNames(ssh_FileCount)
							End Try
						End If

						If ssh_DomChat.Contains("@Contact3") Then
							Try
								ssh_DomPic = ssh_Contact3Pics(ssh_Contact3PicsCount)
							Catch
								ssh_DomPic = ssh__ImageFileNames(ssh_FileCount)
							End Try
						End If

					End If
					' @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

					' github patch If FrmSettings.CBSlideshowRandom.Checked = True Then FileCount = randomizer.Next(0, FileCountMax + 1)

					If FrmSettings.CBSlideshowRandom.Checked = True Then
						If ssh_Contact1Pics.Count > 0 Then ssh_Contact1PicsCount = ssh_randomizer.Next(0, ssh_Contact1Pics.Count)
						If ssh_Contact2Pics.Count > 0 Then ssh_Contact2PicsCount = ssh_randomizer.Next(0, ssh_Contact2Pics.Count)
						If ssh_Contact3Pics.Count > 0 Then ssh_Contact3PicsCount = ssh_randomizer.Next(0, ssh_Contact3Pics.Count)
					End If


					' @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

					ShowPicture = True

					' End Next Button
					'On Error GoTo TryNextWithTease
					'On Error Resume Next
					' End Next Button
				End If

				If ssh_DomChat.Contains("@WritingTask(") Then
					Dim WriteFlag As String = GetParentheses(ssh_DomChat, "@WritingTask(")
					ssh_DomChat = ssh_DomChat.Replace(WriteFlag, PoundClean(WriteFlag))
				End If

				If ssh_DomChat.Contains("@Contact1") Or ssh_DomChat.Contains("@Contact2") Or ssh_DomChat.Contains("@Contact3") Then ssh_SubWroteLast = True

				Dim TypeName As String = domName.Text
				Dim TypeColor As String = My.Settings.DomColor
				Dim TypeFont As String = FrmSettings.FontComboBoxD.Text
				Dim TypeSize As String = FrmSettings.NBFontSizeD.Value
				If ssh_DomChat.Contains("@Contact1") Then
					TypeName = FrmSettings.TBGlitter1.Text
					TypeColor = Color2Html(My.Settings.GlitterNC1Color)
					TypeFont = "Cambria"
					TypeSize = "3"
				End If
				If ssh_DomChat.Contains("@Contact2") Then
					TypeName = FrmSettings.TBGlitter2.Text
					TypeColor = Color2Html(My.Settings.GlitterNC2Color)
					TypeFont = "Cambria"
					TypeSize = "3"
				End If
				If ssh_DomChat.Contains("@Contact3") Then
					TypeName = FrmSettings.TBGlitter3.Text
					TypeColor = Color2Html(My.Settings.GlitterNC3Color)
					TypeFont = "Cambria"
					TypeSize = "3"
				End If


				If FrmSettings.TTSCheckBox.Checked = True And FrmSettings.TTSComboBox.Text <> "No voices installed" Then
					Dim EmoteArray() As String = Split(ssh_DomChat)
					For i As Integer = 0 To EmoteArray.Length - 1
						Try
							If EmoteArray(i).Contains("#") And LCase(EmoteArray(i)).Contains("emote") Then
								EmoteArray(i) = EmoteArray(i).Replace(EmoteArray(i), "")
							End If
						Catch
						End Try
					Next
					ssh_DomChat = Join(EmoteArray)
				End If


				Dim LoopBuffer As Integer = 0

				Do

					LoopBuffer += 1

					ssh_DomChat = ssh_DomChat.Replace("#Null", "")
					ssh_DomChat = PoundClean(ssh_DomChat)
					ssh_DomChat = CommandClean(ssh_DomChat)
					ssh_DomChat = StripCommands(ssh_DomChat)
					ssh_DomChat = ssh_DomChat.Replace("#Null", "")
					ssh_DomChat = PoundClean(ssh_DomChat)

					If LoopBuffer > 4 Then Exit Do

				Loop Until Not ssh_DomChat.Contains("#") And Not ssh_DomChat.Contains("@")



				'##############

				'SaveBlogImage.Text = ""

				'  Do
				'DomChat = PoundClean(DomChat)
				'DomChat = CommandClean(DomChat)
				'DomChat = PoundClean(DomChat)
				'Loop Until Not DomChat.Contains("#") ' And Not DomChat.Contains("@")

				'    Dim AtArray() As String = Split(DomChat)
				'   For i As Integer = 0 To AtArray.Length - 1
				'Debug.Print("DomChat AtArray(i) = " & AtArray(i))
				'If AtArray(i) = "" Then GoTo AtNext
				'If AtArray(i) = "" Then GoTo AtBreak
				'If AtArray(i).Contains("@") Then
				'AtArray(i) = AtArray(i).Replace(AtArray(i), "")
				'       End If
				'atNext:
				'  Next

				' DomChat = Join(AtArray)

				'AtBreak:

				' #######################

				If ssh_SysMes = False And ssh_EmoMes = False Then

					Try
						Dim UCASELine As String = UCase(ssh_DomChat.Substring(0, 1))
						ssh_DomChat = ssh_DomChat.Remove(0, 1).Insert(0, UCASELine)
					Catch
					End Try

					If FrmSettings.LCaseCheckBox.Checked = True Then ssh_DomChat = LCase(ssh_DomChat)
					If FrmSettings.CBMeMyMine.Checked = True Then
						Dim MeArray() As String = Split(ssh_DomChat)
						For i As Integer = MeArray.Length - 1 To 0 Step -1
							If UCase(MeArray(i)) = "ME" Then MeArray(i) = "Me"
							If UCase(MeArray(i)) = "MY" Then MeArray(i) = "My"
							If UCase(MeArray(i)) = "MINE" Then MeArray(i) = "Mine"
							If UCase(MeArray(i)) = "I" Then MeArray(i) = "I"
							If UCase(MeArray(i)) = "I'D" Then MeArray(i) = "I'd"
							If UCase(MeArray(i)) = "I'M" Then MeArray(i) = "I'm"
							If UCase(MeArray(i)) = "I'LL" Then MeArray(i) = "I'll"
							If UCase(MeArray(i)) = "YOU" Then MeArray(i) = "you"
							If UCase(MeArray(i)) = "YOUR" Then MeArray(i) = "your"
							If UCase(MeArray(i)) = "YOURS" Then MeArray(i) = "yours"
							If UCase(MeArray(i)) = "YOU'RE" Then MeArray(i) = "you're"
							If UCase(MeArray(i)) = "YOU'D" Then MeArray(i) = "you'd"
							If UCase(MeArray(i)) = "YOU'LL" Then MeArray(i) = "you'll"
						Next
						ssh_DomChat = Join(MeArray)
					End If
					If FrmSettings.apostropheCheckBox.Checked = True Then ssh_DomChat = ssh_DomChat.Replace("'", "")
					If FrmSettings.commaCheckBox.Checked = True Then ssh_DomChat = ssh_DomChat.Replace(",", "")
					If FrmSettings.periodCheckBox.Checked = True Then ssh_DomChat = ssh_DomChat.Replace(".", "")

					Dim EmoToggle As Boolean = True
					For i As Integer = ssh_DomChat.Length - 1 To 0 Step -1
						If ssh_DomChat.Substring(i, 1) = "*" Then
							If EmoToggle = False Then
								EmoToggle = True
								ssh_DomChat = ssh_DomChat.Remove(i, 1).Insert(i, FrmSettings.TBEmote.Text)
							Else
								EmoToggle = False
								ssh_DomChat = ssh_DomChat.Remove(i, 1).Insert(i, FrmSettings.TBEmoteEnd.Text)
							End If
						End If
					Next

					ssh_DomChat = ssh_DomChat.Replace(":d", ":D")
					ssh_DomChat = ssh_DomChat.Replace(": d", ": D")

				End If

				ssh_DomChat = ssh_DomChat.Replace("ATSYMBOL", "@")
				ssh_DomChat = ssh_DomChat.Replace("atsymbol", "@")

				If ssh_InputIcon = True Then
					ssh_DomChat = ssh_DomChat & " <img src=""file://" & Application.StartupPath & "/Images/System/input.png""/>"
					ssh_InputIcon = False
				End If

				ssh_DomChat = ssh_DomChat.Replace(" a a", " an a")
				ssh_DomChat = ssh_DomChat.Replace(" a e", " an e")
				ssh_DomChat = ssh_DomChat.Replace(" a i", " an i")
				ssh_DomChat = ssh_DomChat.Replace(" a o", " an o")
				ssh_DomChat = ssh_DomChat.Replace(" a u", " an u")

				ssh_DomChat = ssh_DomChat.Replace(" an uni", " a uni")
				ssh_DomChat = ssh_DomChat.Replace(" an utensil", " a utensil")
				ssh_DomChat = ssh_DomChat.Replace(" an ukulele", " a ukulele")
				ssh_DomChat = ssh_DomChat.Replace(" an use", " a use")
				ssh_DomChat = ssh_DomChat.Replace(" an urethra", " a urethra")
				ssh_DomChat = ssh_DomChat.Replace(" an urine", " a urine")
				ssh_DomChat = ssh_DomChat.Replace(" an usual", " a usual")
				ssh_DomChat = ssh_DomChat.Replace(" an utility", " a utility")
				ssh_DomChat = ssh_DomChat.Replace(" an uterus", " a uterus")
				ssh_DomChat = ssh_DomChat.Replace(" an utopia", " a utopia")

				'SUGGESTION: (Stefaf) All Writing to the Chatbox and Wating for fetched Images shoud be in a separat Function. 
				' If Sync of Reseults is activated
				' Wait for the ImageFetcher to Finish 
				If BWimageFetcher.TriggerRequired _
				Then BWimageFetcher.WaitToFinish()

				If ssh_NullResponse = True Or ssh_DomChat = "" Or ssh_DomChat Is Nothing Then GoTo NullResponseLine2

				If UCase(ssh_DomChat) = "<B>TEASE AI HAS BEEN RESET</B>" Then ssh_DomChat = "<b>Tease AI has been reset</b>"

				Dim TextColor As String = Color2Html(My.Settings.ChatTextColor)

				If ssh_SysMes = True Then
					ssh_Chat = "<body style=""word-wrap:break-word;"">" & "<font face=""" & "Cambria" & """ size=""" & "3" & """ color=""#000000"">" & ssh_Chat & "<font color=""SteelBlue""><b>" & ssh_DomChat & "</b><br></font></body>"
					ssh_SysMes = False
					ChatText.DocumentText = ssh_Chat
					ChatText2.DocumentText = ssh_Chat
					ChatReadyState()
					GoTo EndSysMes
				End If

				If ssh_EmoMes = True Then
					ssh_Chat = "<body style=""word-wrap:break-word;"">" & "<font face=""" & "Cambria" & """ size=""" & "3" & """ color=""#000000"">" & ssh_Chat & "<font color=""" &
			  TypeColor & """><b><i>" & ssh_DomChat & "</i></b><br></font></body>"
					ssh_EmoMes = False
					ChatText.DocumentText = ssh_Chat
					ChatText2.DocumentText = ssh_Chat
					ChatReadyState()
					GoTo EndSysMes
				End If

				' Add timestamps to domme response if the option is checked in the menu
				If FrmSettings.timestampCheckBox.Checked = True And FrmSettings.CBWebtease.Checked = False Then
					ssh_Chat = ssh_Chat & "<font face=""Cambria"" size=""2"" color=""DimGray"">" & (Date.Now.ToString("hh:mm tt ")) & "</font>"
				End If

				'Debug.Print("DomChat = " & DomChat)

				If ssh_SubWroteLast = False And FrmSettings.shownamesCheckBox.Checked = False Then


					If FrmSettings.CBWebtease.Checked = True Then
						ssh_Chat = "<body bgcolor=""" & Color2Html(My.Settings.ChatWindowColor) & """>" & "</body><body style=""word-wrap:break-word;"">" & "<font face=""" & FrmSettings.FontComboBoxD.Text & """ size=""" & FrmSettings.NBFontSizeD.Value & """ color=""" &
						  TextColor & """><center>" & ssh_DomChat & "</center><br></font></body>"
					Else
						ssh_Chat = "<body style=""word-wrap:break-word;"">" & "<font face=""" & FrmSettings.FontComboBoxD.Text & """ size=""" & FrmSettings.NBFontSizeD.Value & """ color=""" &
						 TextColor & """>" & ssh_Chat & ssh_DomChat & "<br></font></body>"
					End If


					ChatText.DocumentText = ssh_Chat
					ChatText2.DocumentText = ssh_Chat
					ChatReadyState()

					If ssh_RiskyDeal = True Then FrmCardList.WBRiskyChat.DocumentText = "<body style=""word-wrap:break-word;""><font face=""Cambria"" size=""3"" font color=""" &
			  TypeColor & """><b>" & TypeName & ": </b></font><font face=""" & TypeFont & """ size=""" & TypeSize & """ color=""" & TextColor & """>" & ssh_DomChat & "<br></font></body>"

				Else

					If FrmSettings.CBWebtease.Checked = True Then
						ssh_Chat = "<body bgcolor=""" & Color2Html(My.Settings.ChatWindowColor) & """>" & "</body><body style=""word-wrap:break-word;"">" & "<font face=""" & FrmSettings.FontComboBoxD.Text & """ size=""" & FrmSettings.NBFontSizeD.Value & """ color=""" &
						 TextColor & """><center>" & ssh_DomChat & "</center><br></font></body>"
					Else
						ssh_Chat = "<body style=""word-wrap:break-word;"">" & ssh_Chat & "<font face=""Cambria"" size=""3"" font color=""" &
				TypeColor & """><b>" & TypeName & ": </b></font><font face=""" & TypeFont & """ size=""" & TypeSize & """ color=""" & TextColor & """>" & ssh_DomChat & "<br></font></body>"
					End If

					ssh_TypeToggle = 0
					ChatText.DocumentText = ssh_Chat
					ChatText2.DocumentText = ssh_Chat
					ChatReadyState()

					If ssh_RiskyDeal = True Then FrmCardList.WBRiskyChat.DocumentText = "<body style=""word-wrap:break-word;""><font face=""Cambria"" size=""3"" font color=""" &
			  TypeColor & """><b>" & TypeName & ": </b></font><font face=""" & TypeFont & """ size=""" & TypeSize & """ color=""" & TextColor & """>" & ssh_DomChat & "<br></font></body>"

				End If

EndSysMes:



				ScrollChatDown()


				If FrmSettings.CBAutosaveChatlog.Checked = True Then My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Chatlogs\Autosave.html", ChatText.DocumentText, False)

				ssh_SubWroteLast = False

				' If Sync of Reseults is activated
				' Wait for the ImageFetcher to Finish 
				If BWimageFetcher.TriggerRequired _
				Then BWimageFetcher.WaitToFinish()

				If ShowPicture = True Or ssh_DommeImageFound = True Then


					Try
						If ssh_RiskyDeal = True Then
							' ######################## Risky Pick #########################
							FrmCardList.PBRiskyPic.Image = Image.FromFile(ssh_DomPic)
						ElseIf ssh_DommeImageFound = True Then
							' ######################## Domme Tags #########################
							ShowImage(ssh_DommeImageSTR, True)
							ssh_DommeImageFound = False
						ElseIf ssh_LocalImageFound = True Then
							' ######################## Local Img. #########################
							ShowImage(ssh_LocalImageSTR, True)
							ssh_LocalImageFound = False
						Else
							' ######################## Slideshow ##########################
							ShowImage(ssh_DomPic, True)
						End If
					Catch ex As Exception
						'@@@@@@@@@@@@@@@@@@@@@@@ Exception @@@@@@@@@@@@@@@@@@@@@@@@
						Debug.Print(ex.Message & vbCrLf & ex.StackTrace)
						ClearMainPictureBox()
						' GoTo TryNextWithTease
					End Try

					If FrmSettings.landscapeCheckBox.Checked = True Then
						If mainPictureBox.Image.Width > mainPictureBox.Image.Height Then
							mainPictureBox.SizeMode = PictureBoxSizeMode.StretchImage
						Else
							mainPictureBox.SizeMode = PictureBoxSizeMode.Zoom
						End If
					Else
						mainPictureBox.SizeMode = PictureBoxSizeMode.Zoom
					End If

					mainPictureBox.Refresh()
					mainPictureBox.Invalidate()
					ShowPicture = False
				End If

				If FrmSettings.TTSCheckBox.Checked = True And FrmSettings.TTSComboBox.Text <> "No voices installed" Then
					ssh_DomChat = StripFormat(ssh_DomChat)
					ssh_synth.SelectVoice(FrmSettings.TTSComboBox.Text)
					ssh_synth.Speak(ssh_DomChat)
				End If

NullResponseLine2:

				' If Sync of Reseults is activated
				' Wait for the ImageFetcher to Finish 
				If BWimageFetcher.TriggerRequired _
				Then BWimageFetcher.WaitToFinish()

				If ssh_MultipleEdgesMetronome = "STOP" Then
					ssh_MultipleEdgesMetronome = ""
					StrokePace = 0
					ssh_SubStroking = False
					ssh_SubEdging = False
					DeactivateWebToy()
				End If

				If ssh_MultipleEdgesMetronome = "START" Then
					ssh_MultipleEdgesMetronome = ""
					EdgePace()
					ssh_SubStroking = True
					ssh_SubEdging = True
					ActivateWebToy()
					DisableContactStroke()
				End If

				StrokeSpeedCheck()

				If ssh_SubStroking = False Then
					StrokePace = 0
					If FrmSettings.TBWebStop.Text <> "" Then
						Try
							FrmSettings.WebToy.Navigate(FrmSettings.TBWebStop.Text)
						Catch
						End Try
					End If
				End If

				If ssh_SubHoldingEdge = True Then
					StrokePace = 0
				End If

				'Debug.Print("NullResponse = " & NullResponse)

				ssh_NullResponse = False

				If ssh_FollowUp <> "" Then
					ssh_DomChat = ssh_FollowUp
					ssh_FollowUp = ""
					TypingDelay()
					Exit Sub
				End If

				ssh_DomTypeCheck = False
				'StringLength = 20
				ssh_StringLength = ssh_randomizer.Next(8, 16)

				If ssh_SubStroking = False Then ssh_StopMetronome = True

				If ssh_TempScriptCount = 0 Then
					ssh_JustShowedBlogImage = False
					ssh_JustShowedSlideshowImage = False
				End If


				If ssh_CBTCockActive = True Then ssh_CBTCockActive = False
				If ssh_CBTBallsActive = True Then ssh_CBTBallsActive = False
				If ssh_CBTBothActive = True Then ssh_CBTBothActive = False



				If ssh_CBTCockFlag = True Or ssh_CBTBallsFlag = True Or ssh_CBTBothFlag = True Or ssh_CustomTask = True Then
					ssh_TasksCount -= 1
					If ssh_TasksCount < 1 Then
						ssh_CBTCockFlag = False
						ssh_CBTBallsFlag = False
						ssh_CBTBothFlag = False
						ssh_CustomTask = False
						ssh_CBTBallsFirst = True
						ssh_CBTCockFirst = True
						ssh_CBTBothFirst = True
						ssh_CustomTaskFirst = True
					End If
				End If

				If ssh_CBTCockFlag = True Then
					CBTCock()
				End If

				If ssh_CBTBallsFlag = True Then
					CBTBalls()
				End If

				If ssh_CBTBothFlag = True Then
					CBTBoth()
				End If

				If ssh_CustomTask = True Then
					RunCustomTask()
				End If

				If ssh_YesOrNo = False And ssh_Responding = False Then
					ssh_ScriptTick = ssh_randomizer.Next(4, 7)
					If ssh_RiskyDeal = True Then ssh_ScriptTick = 2
					ScriptTimer.Start()
				End If

				ssh_Responding = False

				If ssh_SubGaveUp = True Then

					ssh_SubGaveUp = False

					ssh_AskedToGiveUpSection = False
					If TnASlides.Enabled = True Then TnASlides.Stop()

					Dim WasStroking As Boolean = ssh_SubStroking
					Dim WasEdging As Boolean = ssh_SubEdging
					Dim WasHolding As Boolean = ssh_SubHoldingEdge

					StopEverything()
					ssh_ModuleEnd = False
					ssh_ShowModule = False

					'DelayFlag = True
					'DelayTick = randomizer.Next(3, 6)

					'DelayTimer.Start()

					'Do
					'Application.DoEvents()
					'Loop Until DelayFlag = False

					ssh_LastScriptCountdown -= 1
					'Debug.Print("LastScriptCountdown = " & LastScriptCountdown)

					'FrmSettings.LBLOrgasmCountdown.Text = LastScriptCountdown

					If ssh_ReturnFlag Then
						ssh_ShowModule = True
						ScriptTimer.Start()
					ElseIf ssh_TeaseTick < 1 And ssh_Playlist = False Then
						ssh_StrokeTauntVal = -1
						RunLastScript()
					ElseIf WasStroking And Not WasEdging And Not WasHolding Then
						ssh_StrokeTauntVal = -1
						RunModuleScript(False)
					Else
						ssh_StrokeTauntVal = -1
						RunLinkScript()
					End If

				End If
			End If
		End If

	End Sub




#Region "------------------------------------------ Images ----------------------------------------------"

	Private Sub CustomMainSlidehhowLoad(ByVal Getfolder As String)

	End Sub

	Private Sub LoadCustomizedSlideshow(sender As System.Object, e As System.EventArgs) Handles browsefolderButton.Click, ImageFolderComboBox.KeyDown, ImageFolderComboBox.SelectedIndexChanged
		'TODO-Next-Stefaf: Implement enhanced RecentSlideshows.Item handling
		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then
			MsgBox("Please close the settings menu or disable ""Pause Program When Settings Menu is Visible"" option first!", , "Warning!")
			Return
		End If
		Try
			Dim GetFolder As String = ""
			browsefolderButton.Enabled = False
			nextButton.Enabled = False
			previousButton.Enabled = False
			PicStripTSMIdommeSlideshow.Enabled = False

			If sender Is browsefolderButton Then
				'===============================================================================
				'								browsefolderButton
				'===============================================================================
				If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
					GetFolder = FolderBrowserDialog1.SelectedPath

					ssh_RecentSlideshows.Add(GetFolder)

					Do Until ssh_RecentSlideshows.Count < 11
						ssh_RecentSlideshows.Remove(ssh_RecentSlideshows(0))
					Loop

					ImageFolderComboBox.Items.Clear()

					For Each comboitem As String In ssh_RecentSlideshows
						ImageFolderComboBox.Items.Add(comboitem)
					Next

					ImageFolderComboBox.Text = GetFolder

					My.Settings.RecentSlideshows.Add(GetFolder)

					My.Settings.RecentSlideshows.Clear()

					For i As Integer = 0 To ssh_RecentSlideshows.Count - 1
						My.Settings.RecentSlideshows.Add(ssh_RecentSlideshows(i))
					Next

				End If
			ElseIf sender Is ImageFolderComboBox And TypeOf e Is KeyEventArgs
				'===============================================================================
				'						ImageFolderComboBox - KeyPressEvent
				'===============================================================================
				Dim _e As KeyEventArgs = DirectCast(e, KeyEventArgs)

				If _e.KeyCode = Keys.Enter Then
					_e.Handled = True
					GoTo chooseComboboxText
				Else
					Exit Sub
				End If
			ElseIf sender Is ImageFolderComboBox And TypeOf e Is EventArgs
				'===============================================================================
				'								ImageFolderComboBox
				'===============================================================================
chooseComboboxText:
				If Directory.Exists(ImageFolderComboBox.Text) Or isURL(ImageFolderComboBox.Text) Then
					GetFolder = ImageFolderComboBox.Text
				Else
					'TODO-Next-Stefaf: Rework Recent SlideShow Variable and remove invalid directories.
					Throw New DirectoryNotFoundException("The given directory """ & ImageFolderComboBox.Text & """ does not exist.")
				End If
			Else
				Throw New NotImplementedException("")
			End If

			If GetFolder = "" Then
				Exit Sub
			ElseIf Not isURL(GetFolder) Then
				ImageFolderComboBox.Enabled = False

				DomWMP.Visible = False
				DomWMP.Ctlcontrols.pause()
				mainPictureBox.Visible = True

				FrmSettings.timedRadio.Enabled = True
				FrmSettings.teaseRadio.Enabled = True

				ssh_SlideshowLoaded = False
				ssh_FileCount = 0
				ssh_FileCountMax = -1
				ssh__ImageFileNames.Clear()

				If FrmSettings.CBSlideshowSubDir.Checked = True Then
					ssh__ImageFileNames = myDirectory.GetFilesImages(GetFolder, SearchOption.AllDirectories)
				Else
					ssh__ImageFileNames = myDirectory.GetFilesImages(GetFolder, SearchOption.TopDirectoryOnly)
				End If

				GoTo listLoaded

			ElseIf isURL(ImageFolderComboBox.Text) And Debugger.IsAttached Then
				'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
				'						Blog SlideShow (!)Experimental
				'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
				Dim tmpReq As Net.HttpWebRequest
				Dim tmpRes As Net.HttpWebResponse

				tmpReq = Net.HttpWebRequest.Create(ImageFolderComboBox.Text & "api/read?start=" & 1 & "&num=5000")
				tmpRes = tmpReq.GetResponse

				Using reader As New Xml.XmlTextReader(tmpRes.GetResponseStream)
					Dim tmpDoc As New Xml.XmlDocument()
					tmpDoc.Load(reader)

					tmpReq.Abort()
					tmpRes.Close()

					DomWMP.Visible = False
					DomWMP.Ctlcontrols.pause()
					mainPictureBox.Visible = True

					FrmSettings.timedRadio.Enabled = True
					FrmSettings.teaseRadio.Enabled = True

					ssh_SlideshowLoaded = False
					ssh_FileCount = 0
					ssh_FileCountMax = -1
					ssh__ImageFileNames.Clear()

					For Each ___PhotoNode As Xml.XmlNode In tmpDoc.DocumentElement.SelectNodes("//photo-url")
						If CInt(___PhotoNode.Attributes.ItemOf("max-width").InnerText) = 1280 Then
							ssh__ImageFileNames.Add(___PhotoNode.InnerXml)

						End If
					Next
				End Using

				GoTo listLoaded
				'▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲
				' Blog SlideShow - End
				'▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲
			Else

				ImageFolderComboBox.Text = "Not a valid directory"

			End If
			Exit Sub

listLoaded:
			If ssh__ImageFileNames.Count <= 0 Then

				MessageBox.Show(Me, "There are no images in the specified folder.", "Error!",
									MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Exit Sub
			Else
				ssh_SlideshowLoaded = True
				ssh_FileCountMax = ssh__ImageFileNames.Count - 1
			End If

			If My.Settings.CBSlideshowRandom = True Then _
				ssh_FileCount = ssh_randomizer.Next(0, ssh__ImageFileNames.Count)

			ShowImage(ssh__ImageFileNames(ssh_FileCount), True)
			ssh_JustShowedBlogImage = False

			'TODO: FrmSettings.timedRadio.Checked - Remove CrossForm DataAccess
			If FrmSettings.timedRadio.Checked = True Then
				ssh_SlideshowTimerTick = FrmSettings.slideshowNumBox.Value
				SlideshowTimer.Start()
			End If

		Catch ex As Exception
			'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
			'                                            All Errors
			'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
			MessageBox.Show("Unable to load custom slideshow : " & vbCrLf & vbCrLf & ex.Message,
							"Open CustomSlideshow failed",
							MessageBoxButtons.OK, MessageBoxIcon.Error)
		Finally
			browsefolderButton.Enabled = True
			nextButton.Enabled = True
			previousButton.Enabled = True
			PicStripTSMIdommeSlideshow.Enabled = True
			ImageFolderComboBox.Enabled = True
		End Try
	End Sub

	Private Sub imagesNextButton_Click(sender As System.Object, e As System.EventArgs) Handles nextButton.Click, previousButton.Click
		Try
			If My.Settings.CBSettingsPause And FrmSettings.SettingsPanel.Visible = True Then
				MsgBox("Please close the settings menu or disable ""Pause Program When Settings Menu is Visible"" option first!", , "Warning!")
				Exit Sub
			End If

			If ssh_SlideshowLoaded = False Or ssh_TeaseVideo = True Then Return


Retry:
			If sender Is nextButton Then
				' ====================== Next Image =======================
				ssh_FileCount += 1
				If ssh_FileCount >= ssh__ImageFileNames.Count - 1 Then ssh_FileCount = 0
			ElseIf sender Is previousButton
				' ==================== Previous Image =====================
				ssh_FileCount -= 1
				If ssh_FileCount <= 0 Then ssh_FileCount = ssh__ImageFileNames.Count - 1
			Else
				' ======================== Error ==========================
				Throw New NotImplementedException("Action for button not implemented.")
			End If

			If Not (File.Exists(ssh__ImageFileNames(ssh_FileCount)) _
					Or isURL(ssh__ImageFileNames(ssh_FileCount))) Then
				ClearMainPictureBox()
				Return
			End If

			If ssh__ImageFileNames(ssh_FileCount).Contains(".db") Then GoTo Retry


			If My.Settings.CBSlideshowRandom = True Then ssh_FileCount = ssh_randomizer.Next(0, ssh__ImageFileNames.Count)



			Try
				browsefolderButton.Enabled = False
				ImageFolderComboBox.Enabled = False
				nextButton.Enabled = False
				previousButton.Enabled = False
				PicStripTSMIdommeSlideshow.Enabled = False

				ShowImage(ssh__ImageFileNames(ssh_FileCount), True)

				ssh_JustShowedBlogImage = False

			Catch
				GoTo Retry
			Finally
				browsefolderButton.Enabled = True
				ImageFolderComboBox.Enabled = True
				nextButton.Enabled = True
				previousButton.Enabled = True
				PicStripTSMIdommeSlideshow.Enabled = True
			End Try

		Catch ex As Exception
			'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
			'                                            All Errors
			'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
			Log.WriteError(ex.Message, ex, "Move in slideshow Failed")
			MessageBox.Show(ex.Message, "Move in Slideshow failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
		End Try
	End Sub

	Private Sub ImageFolderComboBox_MouseWheel(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles ImageFolderComboBox.MouseWheel
		Dim mwe As HandledMouseEventArgs = DirectCast(e, HandledMouseEventArgs)
		mwe.Handled = True
	End Sub

#End Region ' Images

#Region " VLC "

	Private Sub BTNLoadVideo_Click(sender As System.Object, e As System.EventArgs) Handles BTNLoadVideo.Click

		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then
			MsgBox("Please close the settings menu or disable ""Pause Program When Settings Menu is Visible"" option first!", , "Warning!")
			Return
		End If

		If (OpenFileDialog2.ShowDialog = Windows.Forms.DialogResult.OK) Then



			DomWMP.Visible = True
			DomWMP.stretchToFit = True

			' domVLC.Visible = True
			'SlideshowLoaded = False

			'programsettingsPanel.Visible = False
			mainPictureBox.Visible = False

			' domVLC.playlist.items.clear()
			' domVLC.playlist.add("file:///" & OpenFileDialog2.FileName & "")
			' 'Debug.Print("ChosenVideo = " & OpenFileDialog2.FileName)
			' domVLC.video.crop = domVLC.Width & ":" & domVLC.Height
			' domVLC.playlist.play()
			' If FrmSettings.VLCfillRadio.Checked = True Then
			'domVLC.video.crop = domVLC.Width & ":" & domVLC.Height
			'End If
			'If FrmSettings.VLC43Radio.Checked = True Then domVLC.video.crop = "4:3"
			'If FrmSettings.VLC1610Radio.Checked = True Then domVLC.video.crop = "16:10"
			' If FrmSettings.VLC169Radio.Checked = True Then domVLC.video.crop = "16:9"

			DomWMP.URL = OpenFileDialog2.FileName

		End If
	End Sub



	Private Sub BTNVideoControls_Click(sender As System.Object, e As System.EventArgs) Handles BTNVideoControls.Click

		'If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then
		'MsgBox("Please close the settings menu or disable ""Pause Program When Settings Menu is Visible"" option first!", , "Warning!")
		'Return
		'End If

		'If domVLC.Visible = True Then

		'domVLC.playlist.stop()

		'End If

		If DomWMP.Height = SplitContainer1.Panel1.Height Then
			DomWMP.Height = SplitContainer1.Panel1.Height + 60
			BTNVideoControls.Text = "Show Video Controls"
		Else
			DomWMP.Height = SplitContainer1.Panel1.Height
			BTNVideoControls.Text = "Hide Video Controls"
		End If

		DomWMP.stretchToFit = True

	End Sub



#End Region


	Private Sub StrokeTimer_Tick(sender As System.Object, e As System.EventArgs) Handles StrokeTimer.Tick


		If ssh_InputFlag = True Then Return
		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then Return
		If ssh_DomTypeCheck = True And ssh_StrokeTick < 5 Then Return
		If chatBox.Text <> "" And ssh_StrokeTick < 5 Then Return
		If ChatBox2.Text <> "" And ssh_StrokeTick < 5 Then Return
		If ssh_MiniScript = True And ssh_StrokeTick < 5 Then Return
		If ssh_FollowUp <> "" And ssh_StrokeTick < 5 Then Return


		If FrmSettings.CBDebugTauntsEndless.Checked = True And ssh_StrokeTick < 5 Then Return

		ssh_StrokeTick -= 1
		FrmSettings.LBLCycleDebugCountdown.Text = ssh_StrokeTick

		FrmSettings.LBLDebugStrokeTime.Text = ssh_StrokeTick
		'Debug.Print("StrokeTick = " & StrokeTick)

		If ssh_StrokeTick < 4 And ssh_TempScriptCount > 0 Then ssh_StrokeTick += 1

		If ssh_StrokeTick < 1 Then

			ssh_FirstRound = False

			StrokeTimer.Stop()
			StrokeTauntTimer.Stop()

			If ssh_RunningScript = True Then
				ssh_ScriptTick = 3
				ScriptTimer.Start()
			Else

				RunModuleScript(False)

			End If


		End If









	End Sub


	Public Sub StrokeLoop()


		Do

			'If InputFlag = True Or DomTyping = True Then GoTo SkipTick
			'If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then GoTo SkipTick
			'If DomTypeCheck = True And StrokeTick < 5 Then GoTo SkipTick
			'If chatBox.Text <> "" And StrokeTick < 5 Then GoTo SkipTick
			'If StrokeTick < 4 And TempScriptCount > 0 Then GoTo SkipTick

			ssh_StrokeTick -= 1
			Debug.Print("Threaded StrokeTick = " & ssh_StrokeTick)
SkipTick:

			Thread.Sleep(1000)

		Loop Until ssh_StrokeTick = 0

		If ssh_StrokeTick = 0 Then

			ssh_FirstRound = False

			StrokeTimer.Stop()
			StrokeTauntTimer.Stop()

			If ssh_RunningScript = True Then
				ssh_ScriptTick = 3
				ScriptTimer.Start()
			Else

				RunModuleScript(False)

			End If


		End If



	End Sub


	Private Sub StrokeTauntTimer_Tick(sender As System.Object, e As System.EventArgs) Handles StrokeTauntTimer.Tick

		If ssh_MiniScript = True Then Return
		If ssh_InputFlag = True Then Return

		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then Return

		If ssh_DomTyping = True Then Return
		If ssh_DomTypeCheck = True And ssh_StrokeTauntTick < 6 Then Return
		If chatBox.Text <> "" And ssh_StrokeTauntTick < 6 Then Return
		If ChatBox2.Text <> "" And ssh_StrokeTauntTick < 6 Then Return








		ssh_StrokeTauntTick -= 1

		FrmSettings.LBLDebugStrokeTauntTime.Text = ssh_StrokeTauntTick
		'Debug.Print("StrokeTauntTick = " & StrokeTauntTick)

		If ssh_StrokeTauntTick = 0 Then

			' TauntText = Application.StartupPath & "\Scripts\" & dompersonalityComboBox.Text & "\StrokeTaunts.txt"

			If ssh_TempScriptCount = 0 Then



				'Debug.Print("TempScriptCount = 0")

				If FrmSettings.teaseRadio.Checked = True And ssh_JustShowedBlogImage = False And ssh_TeaseVideo = False And Not ssh_DomTask.Contains("@NewBlogImage") And ssh_SlideshowLoaded = True And ssh_CustomSlideshow = False And ssh_RapidFire = False Then
					'If FrmSettings.teaseRadio.Checked = True And JustShowedBlogImage = False And TeaseVideo = False And Not DomTask.Contains("@NewBlogImage") Then
TryNextWithTease:

					Dim TeaseDirection As Integer = ssh_randomizer.Next(1, 101)

					If TeaseDirection > FrmSettings.NBNextImageChance.Value Then

						ssh_FileCount -= 1

						If ssh_FileCount < 0 Then
							ssh_FileCount = 0
						End If

					Else


						ssh_FileCount += 1
						If ssh_FileCount > ssh_FileCountMax Then
							If FrmSettings.CBNewSlideshow.Checked = True Then
								ssh_NewDommeSlideshow = True
								ssh_OriginalDommeSlideshow = ssh__ImageFileNames(0)
								LoadDommeImageFolder()
								ssh_NewDommeSlideshow = False
								ssh_DomPic = ssh__ImageFileNames(ssh_FileCount)
							Else
								ssh_FileCount = ssh_FileCountMax
							End If
						End If

					End If

					' @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

					If ssh__ImageFileNames(ssh_FileCount).Contains(".db") Then GoTo TryNextWithTease

					ssh_DomPic = ssh__ImageFileNames(ssh_FileCount)

					' @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

					If FrmSettings.CBSlideshowRandom.Checked = True Then ssh_FileCount = ssh_randomizer.Next(0, ssh_FileCountMax + 1)



				End If


				'BlankLineLoop:

				Dim TauntFile As String
				TauntFile = "StrokeTaunts"
				If My.Settings.Chastity = True Then TauntFile = "ChastityTaunts"
				If ssh_GlitterTease = True Then TauntFile = "GlitterTaunts"
				' ### Debug
				'TauntFile = "StrokeTaunts"

				ssh_TauntTextCount = 0
				ssh_ScriptCount = 0
				For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Stroke\", FileIO.SearchOption.SearchTopLevelOnly, TauntFile & "_*.txt")
					ssh_ScriptCount += 1
				Next

				'Dim LinScript As Integer
				' LinSelected = False

				'For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Stroke\Linear Taunts", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
				'LinScript += 1
				'Next

				Dim TauntTempVal As Integer = ssh_randomizer.Next(1, 101)

				'If LinScript = 0 Then

				If TauntTempVal < 45 Then
					TauntTempVal = 1
				Else
					TauntTempVal = ssh_randomizer.Next(1, ssh_ScriptCount + 1)
				End If

				If FrmSettings.CBDebugTaunts.Checked = True Then
					If FrmSettings.RBDebugTaunts1.Checked = True Then TauntTempVal = 1
					If FrmSettings.RBDebugTaunts2.Checked = True Then TauntTempVal = 2
					If FrmSettings.RBDebugTaunts3.Checked = True Then TauntTempVal = 3
				End If


				'Else

				'If TauntTempVal < 11 Then
				'LinSelected = True
				'End If

				'If TauntTempVal > 10 And TauntTempVal < 51 Then

				'### Debug - Why was this here? O.o
				'TauntTempVal = 1  <--- Why?



				'End If

				'If TauntTempVal > 50 Then
				'TauntTempVal = randomizer.Next(1, ScriptCount + 1)
				'End If


				' End If

				'### Debug
				'TauntTempVal = 3

				' If LinSelected = False Then
				ssh_StrokeTauntCount = TauntTempVal
				ssh_ScriptCount = 0
				For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Stroke\", FileIO.SearchOption.SearchTopLevelOnly, TauntFile & "_*.txt")
					ssh_ScriptCount += 1
					If TauntTempVal = ssh_ScriptCount Then ssh_TauntText = foundFile
				Next
				ssh_ScriptCount = TauntTempVal
				'End If

			End If

			'Debug.Print("ScriptCount = " & ScriptCount)

			'Debug.Print("TempScriptCOunt = " & TempScriptCount)





			' ##############################################################################################################






			If ssh_TempScriptCount = 0 Then 'And LinSelected = False Then

				' Uneseccary for txt2List creates a new List(of ) instance.
				ssh_TauntLines.Clear()
				' Read all lines of given File.
				ssh_TauntLines = Txt2List(ssh_TauntText)
				ssh_TauntTextTotal = ssh_TauntLines.Count

				ssh_TauntTextTotal -= 1

				ssh_StrokeFilter = True



				Try
					ssh_TauntLines = FilterList(ssh_TauntLines)
					Dim g As String = "BreakPoint"
				Catch ex As Exception
					Log.WriteError("Tease AI did not return a valid Taunt from file: " &
								   ssh_TauntText, ex, "StrokeTauntTimer.Tick")
					ssh_DomTask = "ERROR: Tease AI did not return a valid Taunt"
				End Try

				ssh_StrokeFilter = False

				ssh_TauntTextTotal = ssh_TauntLines.Count

				'Debug.Print("TauntTextTotal = " & TauntTextTotal)


			End If




			'##############################################################################################################



			If ssh_TempScriptCount = 0 Then ' And LinSelected = False Then
				'Debug.Print("Equal called")
				ssh_TempScriptCount = ssh_ScriptCount
				ssh_TauntTextTotal /= ssh_ScriptCount
				ssh_TauntTextCount = ssh_randomizer.Next(0, ssh_TauntTextTotal) * ssh_ScriptCount
				If FrmSettings.CBDebugTaunts.Checked = True Then ssh_TauntTextCount = 0
			Else
				'Debug.Print("Not equal called")
				ssh_TauntTextCount += 1
			End If

			' If TempScriptCount = 0 And LinSelected = True Then
			'Dim LinList As New List(Of String)

			'            For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Stroke\Linear Taunts", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
			'LinList.Add(foundFile)
			'Next

			'FileText = LinList(randomizer.Next(0, LinList.Count))

			'LinList.Clear()

			'LinList = Txt2List(FileText)

			'TempScriptCount = LinList.Count
			'LinLine = TempScriptCount


			'End If

			ssh_TempScriptCount -= 1




			'Debug.Print("TauntTextCount = " & TauntTextCount)




			Try
				ssh_DomTask = ssh_TauntLines(ssh_TauntTextCount)
			Catch ex As Exception
				Log.WriteError("Tease AI did not return a valid Taunt from file: " &
								   ssh_TauntText, ex, "StrokeTauntTimer.Tick")
				ssh_DomTask = "ERROR: Tease AI did not return a valid Taunt"
			End Try


			If FrmSettings.CBDebugTaunts.Checked = True Then
				ssh_DomTask = ""
				If ssh_TauntTextCount = 0 Then ssh_DomTask = FrmSettings.TBDebugTaunts1.Text
				If ssh_TauntTextCount = 1 Then ssh_DomTask = FrmSettings.TBDebugTaunts2.Text
				If ssh_TauntTextCount = 2 Then ssh_DomTask = FrmSettings.TBDebugTaunts3.Text
				If ssh_DomTask = "" Then ssh_DomTask = "@SystemMessage ERROR: Debug field is currently blank"
			End If

			If ssh_DomTask.Contains("@ShowTaggedImage") Then ssh_JustShowedBlogImage = True

			'If DomTask = "" Then GoTo BlankLineLoop

			If InStr(UCase(ssh_DomTask), UCase("@CBT")) <> 0 Then
				CBTScript()
			Else
				TypingDelayGeneric()
			End If



			If ssh_TempScriptCount = 0 Then
				If FrmSettings.SliderSTF.Value = 1 Then ssh_StrokeTauntTick = ssh_randomizer.Next(120, 241)
				If FrmSettings.SliderSTF.Value = 2 Then ssh_StrokeTauntTick = ssh_randomizer.Next(75, 121)
				If FrmSettings.SliderSTF.Value = 3 Then ssh_StrokeTauntTick = ssh_randomizer.Next(45, 76)
				If FrmSettings.SliderSTF.Value = 4 Then ssh_StrokeTauntTick = ssh_randomizer.Next(25, 46)
				If FrmSettings.SliderSTF.Value = 5 Then ssh_StrokeTauntTick = ssh_randomizer.Next(15, 26)
				'StrokeTauntTick = randomizer.Next(11, 21)
			Else
				ssh_StrokeTauntTick = ssh_randomizer.Next(5, 9)
			End If






		End If





	End Sub

	Public Sub CBTScript()

		Dim CBTAmount As Integer

		ssh_CBT = True
		ssh_YesOrNo = True
		Dim CBTCount As Integer

		Dim lines As List(Of String) = Txt2List(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\CBT\CBT.txt")
		CBTCount += lines.Count

		CBTCount = ssh_randomizer.Next(0, CBTCount)

		ssh_DomTask = lines(CBTCount)

		CBTAmount = ssh_randomizer.Next(1, 6) * 2 * FrmSettings.domlevelNumBox.Value
		ssh_DomTask = ssh_DomTask.Replace("#CBTAmount", CBTAmount)

		TypingDelayGeneric()


	End Sub



	Private Sub DelayTimer_Tick(sender As System.Object, e As System.EventArgs) Handles DelayTimer.Tick

		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then Return

		If ssh_DelayTick < 10 And chatBox.Text <> "" Then Return
		If ssh_DelayTick < 10 And ChatBox2.Text <> "" Then Return
		If ssh_DelayTick < 3 And ssh_DomTypeCheck = True Then Return

		ssh_DelayTick -= 1

		If ssh_DelayTick < 1 Then
			DelayTimer.Stop()
		End If


	End Sub

#Region "----------------------------------------------------- Video-Files ----------------------------------------------------"

	Public Sub RandomVideo()
		' Reset retentive global variables
		ssh_NoVideo = False
		ssh_DommeVideo = False

		Dim __dom As Random = New Random()
		Dim __domVideo As String
		Dim __TotalFiles As New List(Of String)

		'======================================================================================
		'									Genre Videos
		'======================================================================================
		If My.Settings.CBHardcore = True Then _
			__TotalFiles.AddRange(myDirectory.GetFilesVideo(My.Settings.VideoHardcore))

		If My.Settings.CBSoftcore = True Then _
			__TotalFiles.AddRange(myDirectory.GetFilesVideo(My.Settings.VideoSoftcore))

		If My.Settings.CBLesbian = True Then _
			__TotalFiles.AddRange(myDirectory.GetFilesVideo(My.Settings.VideoLesbian))

		If My.Settings.CBBlowjob = True Then _
			__TotalFiles.AddRange(myDirectory.GetFilesVideo(My.Settings.VideoBlowjob))

		If My.Settings.CBFemdom = True Then _
			__TotalFiles.AddRange(myDirectory.GetFilesVideo(My.Settings.VideoFemdom))

		If My.Settings.CBFemsub = True Then _
			__TotalFiles.AddRange(myDirectory.GetFilesVideo(My.Settings.VideoFemsub))

		If ssh_NoSpecialVideo = True Then GoTo SkipSpecial

		If ssh_ScriptVideoTeaseFlag = True Then
			If ssh_ScriptVideoTease = "Censorship Sucks" Or ssh_ScriptVideoTease = "Avoid The Edge" Or ssh_ScriptVideoTease = "RLGL" Then GoTo SkipSpecial
		End If

		If ssh_RandomizerVideo = True Then GoTo SkipSpecial

		'======================================================================================
		'								Special - Videos
		'======================================================================================
		If My.Settings.CBJOI = True Then _
			__TotalFiles.AddRange(myDirectory.GetFilesVideo(My.Settings.VideoJOI))

		If My.Settings.CBCH = True Then _
			__TotalFiles.AddRange(myDirectory.GetFilesVideo(My.Settings.VideoCH))

SkipSpecial:
		'======================================================================================
		'									General Videos
		'======================================================================================
		If My.Settings.CBGeneral = True Then _
			__TotalFiles.AddRange(myDirectory.GetFilesVideo(My.Settings.VideoGeneral))

		'======================================================================================
		'									Domme - Videos
		'======================================================================================
		If My.Settings.CBHardcoreD = True Then _
			__TotalFiles.AddRange(myDirectory.GetFilesVideo(My.Settings.VideoHardcoreD))

		If My.Settings.CBSoftcoreD = True Then _
			__TotalFiles.AddRange(myDirectory.GetFilesVideo(My.Settings.VideoSoftcoreD))

		If My.Settings.CBLesbianD = True Then _
			__TotalFiles.AddRange(myDirectory.GetFilesVideo(My.Settings.VideoLesbianD))

		If My.Settings.CBBlowjobD = True Then _
			__TotalFiles.AddRange(myDirectory.GetFilesVideo(My.Settings.VideoBlowjobD))

		If My.Settings.CBFemdomD = True Then _
			__TotalFiles.AddRange(myDirectory.GetFilesVideo(My.Settings.VideoFemdomD))

		If My.Settings.CBFemsubD = True Then _
			__TotalFiles.AddRange(myDirectory.GetFilesVideo(My.Settings.VideoFemsubD))

		If ssh_NoSpecialVideo = True Then GoTo SkipSpecialD
		If ssh_ScriptVideoTeaseFlag = True Then
			If ssh_ScriptVideoTease = "Censorship Sucks" Or ssh_ScriptVideoTease = "Avoid The Edge" Or ssh_ScriptVideoTease = "RLGL" Then GoTo SkipSpecialD
		End If

		If ssh_RandomizerVideo = True Then GoTo SkipSpecialD

		'======================================================================================
		'								Domme - Special - Videos
		'======================================================================================
		If My.Settings.CBJOID = True Then _
			__TotalFiles.AddRange(myDirectory.GetFilesVideo(My.Settings.VideoJOID))

		If My.Settings.CBCHD = True Then _
			__TotalFiles.AddRange(myDirectory.GetFilesVideo(My.Settings.VideoCHD))

SkipSpecialD:
		'======================================================================================
		'								Domme - General Videos
		'======================================================================================
		If My.Settings.CBGeneralD = True Then _
			__TotalFiles.AddRange(myDirectory.GetFilesVideo(My.Settings.VideoGeneralD))



		If __TotalFiles.Count = 0 Then Exit Sub

		If ssh_VideoCheck = True Then Exit Sub

GetAnotherRandomVideo:

		__domVideo = __TotalFiles(__dom.Next(0, __TotalFiles.Count))

		If __domVideo = "" Then GoTo GetAnotherRandomVideo

		'@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ Debug Line @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
		If Debugger.IsAttached AndAlso 1 = 2 Then _
			__TotalFiles.ForEach(Sub(x) Debug.Print("RndVideoCheck: " & x))


		If My.Settings.CBHardcore And InStr(__domVideo, My.Settings.VideoHardcore) <> 0 Then ssh_VideoType = "Hardcore"
		If My.Settings.CBSoftcore And InStr(__domVideo, My.Settings.VideoSoftcore) <> 0 Then ssh_VideoType = "Softcore"
		If My.Settings.CBLesbian = True And InStr(__domVideo, My.Settings.VideoLesbian) <> 0 Then ssh_VideoType = "Lesbian"
		If My.Settings.CBBlowjob = True And InStr(__domVideo, My.Settings.VideoBlowjob) <> 0 Then ssh_VideoType = "Blowjob"
		If My.Settings.CBFemdom = True And InStr(__domVideo, My.Settings.VideoFemdom) <> 0 Then ssh_VideoType = "Femdom"
		If My.Settings.CBFemsub = True And InStr(__domVideo, My.Settings.VideoFemsub) <> 0 Then ssh_VideoType = "Femsub"
		If My.Settings.CBJOI = True And InStr(__domVideo, My.Settings.VideoJOI) <> 0 Then ssh_VideoType = "JOI"
		If My.Settings.CBCH = True And InStr(__domVideo, My.Settings.VideoCH) <> 0 Then ssh_VideoType = "CH"
		If My.Settings.CBGeneral = True And InStr(__domVideo, My.Settings.VideoGeneral) <> 0 Then ssh_VideoType = "General"


		If My.Settings.CBHardcoreD And InStr(__domVideo, My.Settings.VideoHardcoreD) <> 0 Then
			ssh_VideoType = "HardcoreD"
			ssh_DommeVideo = True
		End If
		If My.Settings.CBSoftcoreD And InStr(__domVideo, My.Settings.VideoSoftcoreD) <> 0 Then
			ssh_VideoType = "SoftcoreD"
			ssh_DommeVideo = True
		End If
		If My.Settings.CBLesbianD And InStr(__domVideo, My.Settings.VideoLesbianD) <> 0 Then
			ssh_VideoType = "LesbianD"
			ssh_DommeVideo = True
		End If

		If My.Settings.CBBlowjobD And InStr(__domVideo, My.Settings.VideoBlowjobD) <> 0 Then
			ssh_VideoType = "BlowjobD"
			ssh_DommeVideo = True
		End If
		If My.Settings.CBFemdomD And InStr(__domVideo, My.Settings.VideoFemdomD) <> 0 Then
			ssh_VideoType = "FemdomD"
			ssh_DommeVideo = True
		End If
		If My.Settings.CBFemsubD And InStr(__domVideo, My.Settings.VideoFemsubD) <> 0 Then
			ssh_VideoType = "FemsubD"
			ssh_DommeVideo = True
		End If

		If My.Settings.CBJOID And InStr(__domVideo, My.Settings.VideoJOID) <> 0 Then
			ssh_VideoType = "JOID"
			ssh_DommeVideo = True
		End If

		If My.Settings.CBCHD = True And InStr(__domVideo, My.Settings.VideoCHD) <> 0 Then
			ssh_VideoType = "CHD"
			ssh_DommeVideo = True
		End If

		If My.Settings.CBGeneralD = True And InStr(__domVideo, My.Settings.VideoGeneral) <> 0 Then
			ssh_VideoType = "GeneralD"
			ssh_DommeVideo = True
		End If


		'Debug.Print("VideoType = " & VideoType)

		'        domVLC.Visible = True
		DomWMP.Visible = True
		DomWMP.stretchToFit = True

		' programsettingsPanel.Visible = False
		mainPictureBox.Visible = False
		' domVLC.playlist.items.clear()
		' domVLC.playlist.add("file:///" & RandomVideo & "")
		' 'Debug.Print("randomVideo = " & RandomVideo)
		' domVLC.video.crop = domVLC.Width & ":" & domVLC.Height
		' domVLC.playlist.play()
		'If FrmSettings.VLCfillRadio.Checked = True Then
		' domVLC.video.crop = domVLC.Width & ":" & domVLC.Height
		'End If
		'If FrmSettings.VLC43Radio.Checked = True Then domVLC.video.crop = "4:3"
		'If FrmSettings.VLC1610Radio.Checked = True Then domVLC.video.crop = "16:10"
		'If FrmSettings.VLC169Radio.Checked = True Then domVLC.video.crop = "16:9"

		DomWMP.URL = __domVideo



		If ssh_JumpVideo = True Then
			Do
				Application.DoEvents()
			Loop Until (DomWMP.playState = WMPLib.WMPPlayState.wmppsPlaying)

			VideoJump2Random(Nothing, Nothing)

		End If

		ssh_JumpVideo = False
	End Sub



	Friend Sub PlayRandomJOI()
		'ISSUE: there is no control, if a Domme-Video or a Regular JOI is played.
		'ISSUE: Redundant Code
		Dim JOIVideos As New List(Of String)
		JOIVideos.Clear()

		If FrmSettings.LblVideoJOITotal.Text <> "0" And My.Settings.CBJOI = True Then

			JOIVideos.AddRange(myDirectory.GetFilesVideo(My.Settings.VideoJOI,
														 System.IO.SearchOption.AllDirectories))
		End If

		If FrmSettings.LblVideoJOITotalD.Text <> "0" And My.Settings.CBJOID = True Then
			JOIVideos.AddRange(myDirectory.GetFilesVideo(My.Settings.VideoJOI,
														 System.IO.SearchOption.AllDirectories))
		End If

		If JOIVideos.Count < 1 Then
			'ISSUE: This Message will occur during running Scripts!
			MessageBox.Show(Me, "No JOI Videos found!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			If ssh_TeaseVideo = True Then RunFileText()
			ssh_TeaseVideo = False
			Return
		End If

		Dim JOIVideoLine As Integer = ssh_randomizer.Next(0, JOIVideos.Count)

		DomWMP.Visible = True
		DomWMP.stretchToFit = True

		mainPictureBox.Visible = False

		DomWMP.URL = JOIVideos(JOIVideoLine)


	End Sub


	Friend Sub PlayRandomCH()
		'ISSUE: there is no control, if a Domme-Video or a Regular JOI is played.
		'ISSUE: Redundant Code
		Dim CHVideos As New List(Of String)
		CHVideos.Clear()

		If FrmSettings.LblVideoCHTotal.Text <> "0" And My.Settings.CBCH = True Then
			CHVideos.AddRange(myDirectory.GetFilesVideo(My.Settings.VideoCH))
		End If
		If FrmSettings.LblVideoCHTotalD.Text <> "0" And My.Settings.CBCHD = True Then
			CHVideos.AddRange(myDirectory.GetFilesVideo(My.Settings.VideoCHD))
		End If

		If CHVideos.Count < 1 Then
			'ISSUE: This Message will occur during running Scripts!
			MessageBox.Show(Me, "No CH Videos found!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			If ssh_TeaseVideo = True Then RunFileText()
			ssh_TeaseVideo = False
			Return
		End If

		Dim CHVideoLine As Integer = ssh_randomizer.Next(0, CHVideos.Count)

		DomWMP.Visible = True
		DomWMP.stretchToFit = True

		mainPictureBox.Visible = False

		DomWMP.URL = CHVideos(CHVideoLine)


	End Sub

#End Region


	Private Sub SettingsButton_Click(sender As System.Object, e As System.EventArgs) Handles BtnToggleSettings.Click
		If FrmSettings.Visible = True Then
			FrmSettings.Visible = False
			BtnToggleSettings.Text = "Open Settings Menu"
		Else
			FrmSettings.Visible = True
			BtnToggleSettings.Text = "Close Settings Menu"
		End If
	End Sub



	Public Sub CensorshipTimer_Tick(sender As System.Object, e As System.EventArgs) Handles CensorshipTimer.Tick


		If ssh_MiniScript = True Then Return
		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then Return

		If ssh_DomTyping = True Then Return
		If ssh_DomTypeCheck = True And ssh_CensorshipTick < 6 Then Return
		If chatBox.Text <> "" And ssh_CensorshipTick < 6 Then Return
		If ChatBox2.Text <> "" And ssh_CensorshipTick < 6 Then Return
		If ssh_FollowUp <> "" And ssh_CensorshipTick < 6 Then Return

		ssh_CensorshipTick -= 1


		If ssh_CensorshipTick < 1 Then


			Dim CensorLineTemp As Integer = ssh_randomizer.Next(1, 101)


			Dim CensorVideo As String

			If FrmSettings.CBCensorConstant.Checked = True Then GoTo CensorConstant

			If CensorshipBar.Visible = True Then
				CensorshipBar.Visible = False
				ssh_CensorshipTick = ssh_randomizer.Next(FrmSettings.NBCensorHideMin.Value, FrmSettings.NBCensorHideMax.Value + 1)

				If CensorLineTemp > FrmSettings.TauntSlider.Value * 5 Then
					Return
				End If

				CensorVideo = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Video\Censorship Sucks\CensorBarOff.txt"

			Else

CensorConstant:

				Dim CensorshipBarX As Integer
				Dim CensorshipBarY As Integer
				Dim CensorshipBarY2 As Integer

				Try
					CensorshipBarY2 = ssh_randomizer.Next(200, DomWMP.Height / 2)
				Catch
					CensorshipBarY2 = 100
				End Try

				CensorshipBar.Height = CensorshipBarY2
				CensorshipBar.Width = CensorshipBarY2 * 2.6

				'QnD-BUGFIX: if CensorshipBar.Width > DomWMP.Width then ArgumentOutOfRangeException 
				CensorshipBarX = ssh_randomizer.Next(5, If(CensorshipBar.Width > DomWMP.Width, DomWMP.Width, DomWMP.Width - CensorshipBar.Width + 1))
				CensorshipBarY = ssh_randomizer.Next(5, If(CensorshipBar.Height > DomWMP.Height, DomWMP.Height, DomWMP.Height - CensorshipBar.Height + 1))
				CensorshipBar.Location = New Point(CensorshipBarX, CensorshipBarY)



				CensorshipBar.Visible = False
				CensorshipBar.Visible = True

				ssh_CensorshipTick = ssh_randomizer.Next(FrmSettings.NBCensorShowMin.Value, FrmSettings.NBCensorShowMax.Value + 1)

				If CensorLineTemp > FrmSettings.TauntSlider.Value * 5 Then
					Return
				End If

				CensorVideo = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Video\Censorship Sucks\CensorBarOn.txt"

			End If

			' Read all lines of the given file.
			Dim lines As List(Of String) = Txt2List(CensorVideo)

			Dim CensorLine As Integer





			Try
				lines = FilterList(lines)
				If lines.Count < 1 Then Return
				CensorLine = ssh_randomizer.Next(0, lines.Count)
				ssh_DomTask = lines(CensorLine)
			Catch ex As Exception
				Log.WriteError("Tease AI did not return a valid Censorship Sucks line from file: " &
							   CensorVideo, ex, "CensorshipTimer.Tick")
				ssh_DomTask = "ERROR: Tease AI did not return a valid Censorship Sucks line"
			End Try

			TypingDelayGeneric()

		End If

	End Sub


	Public Sub RLGLTimer_Tick(sender As System.Object, e As System.EventArgs) Handles RLGLTimer.Tick
		' Check all Conditions before starting scripts.
		If ssh_MiniScript = True Then Return
		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then Return

		If ssh_DomTyping = True Then Return
		If ssh_DomTypeCheck = True And ssh_RLGLTick < 6 Then Return
		If chatBox.Text <> "" And ssh_RLGLTick < 6 Then Return
		If ChatBox2.Text <> "" And ssh_RLGLTick < 6 Then Return
		If ssh_FollowUp <> "" And ssh_RLGLTick < 6 Then Return

		' Decrement TickCounter if Game is running.
		If ssh_RLGLGame = True Then ssh_RLGLTick -= 1

		' Run scripts only if time is over.
		If ssh_RLGLTick < 1 Then
			' Swap the BooleanValue
			ssh_RedLight = Not ssh_RedLight
			' Turn off TauntTimer when State is red.
			If ssh_RedLight Then RLGLTauntTimer.Stop()

			' Declare list to read
			Dim tempList As List(Of String)
			Dim file2read As String

			' Read File according to state and set the next timer-tick-duration.
			If ssh_RedLight Then
				'################################## RED - Light ##################################
				file2read = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Video\Red Light Green Light\Red Light.txt"
				tempList = Txt2List(file2read)
				ssh_RLGLTick = ssh_randomizer.Next(FrmSettings.NBRedLightMin.Value, FrmSettings.NBRedLightMax.Value + 1)
			Else
				'################################## Green - Light ################################
				file2read = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Video\Red Light Green Light\Green Light.txt"
				tempList = Txt2List(file2read)
				ssh_RLGLTick = ssh_randomizer.Next(FrmSettings.NBGreenLightMin.Value, FrmSettings.NBGreenLightMax.Value + 1)
			End If

			Try
				tempList = FilterList(tempList)
				ssh_DomTask = tempList(ssh_randomizer.Next(0, tempList.Count))
			Catch ex As Exception
				Log.WriteError("Tease AI did not return a valid RLGL line from file: " &
							   file2read, ex, "RLGLTimer.Tick")
				ssh_DomTask = "ERROR: Tease AI did not return a valid RLGL line"
			End Try

			TypingDelayGeneric()
		End If
	End Sub





	Private Sub domName_Leave(sender As System.Object, e As System.EventArgs) Handles domName.Leave
		My.Settings.DomName = domName.Text
	End Sub
	Private Sub subName_Leave(sender As System.Object, e As System.EventArgs) Handles subName.Leave
		My.Settings.SubName = subName.Text
	End Sub


	Public Sub StatusUpdatePost()


		ssh_UpdatingPost = True


		If ssh_UpdateStage > 0 Then GoTo StatusUpdateBegin

		ssh_StatusText = ssh_UpdateList(ssh_randomizer.Next(0, ssh_UpdateList.Count))

		For i As Integer = 0 To ssh_UpdateList.Count - 1
			Debug.Print(i & ". " & ssh_UpdateList(i))
		Next
		Debug.Print("STatusText = " & ssh_StatusText)
		Debug.Print("Clear stage 1")

		' Read all lines of the given File.
		Dim lines As List(Of String) = Txt2List(ssh_StatusText)


		For i As Integer = lines.Count - 1 To 0 Step -1
			If lines(i) = "" Or lines(i) Is Nothing Then
				lines.Remove(lines(i))
			End If
		Next

		ssh_StatusText = lines(0)
		Debug.Print("HEre?")
		' Github Patch  StatusText = PoundClean(StatusText)

		Dim LoopBuffer As Integer = 0
		Do
			LoopBuffer += 1

			ssh_StatusText = PoundClean(ssh_StatusText)

			If LoopBuffer > 4 Then Exit Do

		Loop Until Not ssh_DomTask.Contains("#")


		Dim AtArray() As String = Split(ssh_StatusText)
		For i As Integer = AtArray.Length - 1 To 0 Step -1
			If AtArray(i).Contains("@") Then
				AtArray(i) = AtArray(i).Replace(AtArray(i), "")
			End If
			If FrmSettings.CBHimHer.Checked = True Then
				If AtArray(i) = "He" Then AtArray(i) = AtArray(i).Replace("He", "She")
				If AtArray(i) = "he" Then AtArray(i) = AtArray(i).Replace("he", "she")
				If AtArray(i) = "Him" Then AtArray(i) = AtArray(i).Replace("Him", "Her")
				If AtArray(i) = "him" Then AtArray(i) = AtArray(i).Replace("him", "her")
				If AtArray(i) = "His" Then AtArray(i) = AtArray(i).Replace("His", "Her")
				If AtArray(i) = "his" Then AtArray(i) = AtArray(i).Replace("his", "her")
			End If
		Next
		ssh_StatusText = Join(AtArray)

		Dim DPic As String = My.Settings.GlitterAV
		DPic = "file://" & DPic
		DPic = DPic.Replace("\", "/")
		Debug.Print(DPic)

		Dim StatusName As String


		Dim TextColor As String = Color2Html(My.Settings.ChatTextColor)

		StatusName = StatusUpdates.DocumentText & "<img class=""floatright"" style="" float: left; width: 48; height: 48; border: 0;"" src=""" & DPic & """> <font face=""Cambria"" size=""3"" color=""" & My.Settings.GlitterNCDomme & """><b>" & domName.Text & "</b></font> <br><font face=""Cambria"" size=""2"" color=""DarkGray"">" & Date.Today & "</font><br><br>"
		StatusUpdates.DocumentText = StatusName & "<font face=""Cambria"" size=""2"" color=""" & TextColor & """>" & ssh_StatusText & "</font><br><br>"

		'Debug.Print(GlitterImageAV)
		Debug.Print("Clear Stage 2")




		Dim StatusLines1 As New List(Of String)
		For i As Integer = 1 To lines.Count - 1
			StatusLines1.Add(lines(i))
		Next
		ssh_ContactNumber = 1

		' For i As Integer = StatusLines1.Count - 1 To 0 Step -1
		'If StatusLines1(i) = "" Or StatusLines1(i) Is Nothing Then
		'StatusLines1.Remove(StatusLines1(i))
		'End If
		'Next

		StatusLines1 = StatusClean(StatusLines1)



		ssh_StatusText1 = StatusLines1(ssh_randomizer.Next(0, StatusLines1.Count))

		Dim StatusLines2 As New List(Of String)
		For i As Integer = 1 To lines.Count - 1
			StatusLines2.Add(lines(i))
		Next
		ssh_ContactNumber = 2

		' For i As Integer = StatusLines2.Count - 1 To 0 Step -1
		'If StatusLines2(i) = "" Or StatusLines2(i) Is Nothing Then
		'StatusLines2.Remove(StatusLines2(i))
		'End If
		'Next

		StatusLines2 = StatusClean(StatusLines2)




		Do
			ssh_StatusText2 = StatusLines2(ssh_randomizer.Next(0, StatusLines2.Count))
		Loop Until ssh_StatusText2 <> ssh_StatusText1


		Dim StatusLines3 As New List(Of String)
		For i As Integer = 1 To lines.Count - 1
			StatusLines3.Add(lines(i))
		Next
		ssh_ContactNumber = 3

		'For i As Integer = StatusLines3.Count - 1 To 0 Step -1
		'If StatusLines3(i) = "" Or StatusLines3(i) Is Nothing Then
		'StatusLines3.Remove(StatusLines3(i))
		'End If
		'Next

		StatusLines3 = StatusClean(StatusLines3)

		Do
			ssh_StatusText3 = StatusLines3(ssh_randomizer.Next(0, StatusLines3.Count))
		Loop Until ssh_StatusText3 <> ssh_StatusText2 And ssh_StatusText3 <> ssh_StatusText1

		''Debug.Print("StatusLine = " & StatusLine)




		ssh_StatusText1 = ssh_StatusText1.Replace("#ShortName", My.Settings.GlitterSN)
		ssh_StatusText2 = ssh_StatusText2.Replace("#ShortName", My.Settings.GlitterSN)
		ssh_StatusText3 = ssh_StatusText3.Replace("#ShortName", My.Settings.GlitterSN)

		ssh_StatusText1 = ssh_StatusText1.Replace("#SubName", subName.Text)
		ssh_StatusText2 = ssh_StatusText2.Replace("#SubName", subName.Text)
		ssh_StatusText3 = ssh_StatusText3.Replace("#SubName", subName.Text)

		ssh_StatusText1 = PoundClean(ssh_StatusText1)
		ssh_StatusText2 = PoundClean(ssh_StatusText2)
		ssh_StatusText3 = PoundClean(ssh_StatusText3)

		'GoTo TestSkip

		Dim AtArray1() As String = Split(ssh_StatusText1)
		For i As Integer = AtArray1.Length - 1 To 0 Step -1
			If AtArray1(i).Contains("@") Then
				AtArray1(i) = AtArray1(i).Replace(AtArray1(i), "")
			End If
			If FrmSettings.CBHimHer.Checked = True Then
				If AtArray1(i) = "He" Then AtArray1(i) = AtArray1(i).Replace("He", "She")
				If AtArray1(i) = "he" Then AtArray1(i) = AtArray1(i).Replace("he", "she")
				If AtArray1(i) = "Him" Then AtArray1(i) = AtArray1(i).Replace("Him", "Her")
				If AtArray1(i) = "him" Then AtArray1(i) = AtArray1(i).Replace("him", "her")
				If AtArray1(i) = "His" Then AtArray1(i) = AtArray1(i).Replace("His", "Her")
				If AtArray1(i) = "his" Then AtArray1(i) = AtArray1(i).Replace("his", "her")
			End If
		Next
		ssh_StatusText1 = Join(AtArray1)

		Dim AtArray2() As String = Split(ssh_StatusText2)
		For i As Integer = AtArray2.Length - 1 To 0 Step -1
			If AtArray2(i).Contains("@") Then
				AtArray2(i) = AtArray2(i).Replace(AtArray2(i), "")
			End If
			If FrmSettings.CBHimHer.Checked = True Then
				If AtArray2(i) = "He" Then AtArray2(i) = AtArray2(i).Replace("He", "She")
				If AtArray2(i) = "he" Then AtArray2(i) = AtArray2(i).Replace("he", "she")
				If AtArray2(i) = "Him" Then AtArray2(i) = AtArray2(i).Replace("Him", "Her")
				If AtArray2(i) = "him" Then AtArray2(i) = AtArray2(i).Replace("him", "her")
				If AtArray2(i) = "His" Then AtArray2(i) = AtArray2(i).Replace("His", "Her")
				If AtArray2(i) = "his" Then AtArray2(i) = AtArray2(i).Replace("his", "her")
			End If
		Next
		ssh_StatusText2 = Join(AtArray2)

		Dim AtArray3() As String = Split(ssh_StatusText3)
		For i As Integer = AtArray3.Length - 1 To 0 Step -1
			If AtArray3(i).Contains("@") Then
				AtArray3(i) = AtArray3(i).Replace(AtArray3(i), "")
			End If
			If FrmSettings.CBHimHer.Checked = True Then
				If AtArray3(i) = "He" Then AtArray3(i) = AtArray(i).Replace("He", "She")
				If AtArray3(i) = "he" Then AtArray3(i) = AtArray(i).Replace("he", "she")
				If AtArray3(i) = "Him" Then AtArray3(i) = AtArray(i).Replace("Him", "Her")
				If AtArray3(i) = "him" Then AtArray3(i) = AtArray(i).Replace("him", "her")
				If AtArray3(i) = "His" Then AtArray3(i) = AtArray(i).Replace("His", "Her")
				If AtArray3(i) = "his" Then AtArray3(i) = AtArray(i).Replace("his", "her")
			End If
		Next
		ssh_StatusText3 = Join(AtArray3)

		'TestSkip:

		ssh_Update1 = False
		ssh_Update2 = False
		ssh_Update3 = False

		ssh_StatusChance1 = ssh_randomizer.Next(1, 101)
		ssh_StatusChance2 = ssh_randomizer.Next(1, 101)
		ssh_StatusChance3 = ssh_randomizer.Next(1, 101)

		ssh_UpdateStageTick = ssh_randomizer.Next(10, 21)
		UpdateStageTimer.Start()
		ssh_UpdateStage = 1
		Return


StatusUpdateBegin:

		If ssh_Update1 = True And ssh_Update2 = True And ssh_Update3 = True Then GoTo StatusUpdateEnd

		'ContactTick = randomizer.Next(10, 21)
		'ContactFlag = True
		'ContactTimer.Start()

		'Do
		'Application.DoEvents()
		'Loop Until ContactFlag = False

		'Delay(RandomDelay)

ReRoll:

		ssh_TempVal = ssh_randomizer.Next(1, 4)
		'Debug.Print("TempVal = " & TempVal)

		If ssh_TempVal = 1 Then
			If ssh_Update1 = False Then
				GoTo StatusUpdate1
			Else
				GoTo ReRoll
			End If
		End If

		If ssh_TempVal = 2 Then
			If ssh_Update2 = False Then
				GoTo StatusUpdate2
			Else
				GoTo ReRoll
			End If
		End If

		If ssh_TempVal = 3 Then
			If ssh_Update3 = False Then
				GoTo StatusUpdate3
			Else
				GoTo ReRoll
			End If
		End If

		GoTo ReRoll

StatusUpdate1:

		Dim S1Pic As String = My.Settings.GlitterAV1
		S1Pic = "file://" & S1Pic
		S1Pic = S1Pic.Replace("\", "/")
		Debug.Print(S1Pic)

		TextColor = Color2Html(My.Settings.ChatTextColor)

		If ssh_StatusChance1 < My.Settings.Glitter1Slider * 10 And My.Settings.CBGlitter1 = True Then
			StatusName = StatusUpdates.DocumentText & "<img class=""floatright"" style="" float: left; width: 32; height: 32; border: 0;"" src=""" & S1Pic & """> <font face=""Cambria"" size=""3"" color=""" & My.Settings.GlitterNC1 & """><b>" & FrmSettings.TBGlitter1.Text & "</b></font><br> <font face=""Cambria"" size=""2"" color=""DarkGray"">" & Date.Today & "</font><br>" ' & "<font face=""Cambria"" size=""2"" color=""DarkGray"">" & TimeOfDay & "</font><br>"
			StatusUpdates.DocumentText = StatusName & "<font face=""Cambria"" size=""2"" color=""" & TextColor & """>" & ssh_StatusText1 & "</font><br><br>"


		End If

		ssh_Update1 = True

		ssh_UpdateStageTick = ssh_randomizer.Next(10, 21)
		UpdateStageTimer.Start()
		Return
		'GoTo StatusUpdateBegin

StatusUpdate2:

		Dim S2Pic As String = My.Settings.GlitterAV2
		S2Pic = "file://" & S2Pic
		S2Pic = S2Pic.Replace("\", "/")
		Debug.Print(S2Pic)

		TextColor = Color2Html(My.Settings.ChatTextColor)

		If ssh_StatusChance2 < My.Settings.Glitter2Slider * 10 And My.Settings.CBGlitter2 = True Then
			StatusName = StatusUpdates.DocumentText & "<img class=""floatright"" style="" float: left; width: 32; height: 32; border: 0;"" src=""" & S2Pic & """> <font face=""Cambria"" size=""3"" color=""" & My.Settings.GlitterNC2 & """><b>" & FrmSettings.TBGlitter2.Text & "</b></font><br> <font face=""Cambria"" size=""2"" color=""DarkGray"">" & Date.Today & "</font><br>" ' & "<font face=""Cambria"" size=""2"" color=""DarkGray"">" & TimeOfDay & "</font><br>"
			StatusUpdates.DocumentText = StatusName & "<font face=""Cambria"" size=""2"" color=""" & TextColor & """>" & ssh_StatusText2 & "</font><br><br>"


		End If

		ssh_Update2 = True
		ssh_UpdateStageTick = ssh_randomizer.Next(10, 21)
		UpdateStageTimer.Start()
		Return

		'GoTo StatusUpdateBegin

StatusUpdate3:

		Dim S3Pic As String = My.Settings.GlitterAV3
		S3Pic = "file://" & S3Pic
		S3Pic = S3Pic.Replace("\", "/")
		Debug.Print(S3Pic)

		TextColor = Color2Html(My.Settings.ChatTextColor)

		If ssh_StatusChance3 < My.Settings.Glitter3Slider * 10 And My.Settings.CBGlitter3 = True Then
			StatusName = StatusUpdates.DocumentText & "<img class=""floatright"" style="" float: left; width: 32; height: 32; border: 0;"" src=""" & S3Pic & """> <font face=""Cambria"" size=""3"" color=""" & My.Settings.GlitterNC3 & """><b>" & FrmSettings.TBGlitter3.Text & "</b></font><br> <font face=""Cambria"" size=""2"" color=""DarkGray"">" & Date.Today & "</font><br>" ' & "<font face=""Cambria"" size=""2"" color=""DarkGray"">" & TimeOfDay & "</font><br>"
			StatusUpdates.DocumentText = StatusName & "<font face=""Cambria"" size=""2"" color=""" & TextColor & """>" & ssh_StatusText3 & "</font><br><br>"


		End If

		ssh_Update3 = True

		ssh_UpdateStageTick = ssh_randomizer.Next(10, 21)
		UpdateStageTimer.Start()
		Return
		'GoTo StatusUpdateBegin

StatusUpdateEnd:

		ssh_UpdateStage = 0

		' Github Patch 'StatusText = "Null" & Environment.NewLine & "Null" & Environment.NewLine & "Null" & Environment.NewLine & "Null" & Environment.NewLine

		ssh_UpdatingPost = False


	End Sub

	Public Function StatusClean(ByVal ListClean As List(Of String)) As List(Of String)



		ListClean.Add("### BUFFER LINE ###")
		Debug.Print("ListClean.Count = " & ListClean.Count)

		If ssh_ContactNumber = 1 Then
			For i As Integer = ListClean.Count - 1 To 0 Step -1
				If ListClean(i).Contains("@Bratty") Then
					ListClean(i) = ListClean(i).Replace("@Bratty ", "")
				End If
				If ListClean(i).Contains("@Contact2") Then
					ListClean.Remove(ListClean(i))
				End If
				If ListClean(i).Contains("@Contact3") Then
					ListClean.Remove(ListClean(i))
				End If
			Next
		End If

		If ssh_ContactNumber = 2 Then
			For i As Integer = ListClean.Count - 1 To 0 Step -1
				If ListClean(i).Contains("@Caring") Then
					ListClean(i) = ListClean(i).Replace("@Caring ", "")
				End If
				If ListClean(i).Contains("@Contact1") Then
					ListClean.Remove(ListClean(i))
				End If
				If ListClean(i).Contains("@Contact3") Then
					ListClean.Remove(ListClean(i))
				End If
			Next
		End If

		If ssh_ContactNumber = 3 Then
			For i As Integer = ListClean.Count - 1 To 0 Step -1
				If ListClean(i).Contains("@Cruel") Then
					ListClean(i) = ListClean(i).Replace("@Cruel ", "")
				End If
				If ListClean(i).Contains("@Contact1") Then
					ListClean.Remove(ListClean(i))
				End If
				If ListClean(i).Contains("@Contact2") Then
					ListClean.Remove(ListClean(i))
				End If
			Next
		End If

		For i As Integer = ListClean.Count - 1 To 0 Step -1
			If ListClean(i).Contains("@Angry") Then
				ListClean.Remove(ListClean(i))
			End If
			If ListClean(i).Contains("@Custom1") Then
				ListClean.Remove(ListClean(i))
			End If
			If ListClean(i).Contains("@Custom2") Then
				ListClean.Remove(ListClean(i))
			End If
		Next



		Try
			ListClean.Remove(ListClean(ListClean.Count - 1))
		Catch
			If ssh_ContactNumber = 1 Then ssh_DomTask = "ERROR: Tease AI did not return a valid Glitter line for Contact 1"
			If ssh_ContactNumber = 2 Then ssh_DomTask = "ERROR: Tease AI did not return a valid Glitter line for Contact 2"
			If ssh_ContactNumber = 3 Then ssh_DomTask = "ERROR: Tease AI did not return a valid Glitter line for Contact 3"
		End Try

		Return ListClean

	End Function

	Private Sub Delay(ByVal Milliseconds As Integer)
		Dim Count As Integer
		Milliseconds *= 1000
		Do Until Count >= Milliseconds
			Count += 1
			Thread.Sleep(1)
			Debug.Print(Count)
			Application.DoEvents()
		Loop
	End Sub

	Private Sub domAvatar_Click(sender As System.Object, e As System.EventArgs) Handles domAvatar.Click
		If OpenFileDialog1.ShowDialog() = DialogResult.OK Then

			Try
				domAvatar.Image.Dispose()
			Catch
			End Try
			domAvatar.Image = Nothing
			GC.Collect()


			domAvatar.Image = Image.FromFile(OpenFileDialog1.FileName)
			My.Settings.DomAvatarSave = OpenFileDialog1.FileName
		End If
	End Sub

	Private Sub UpdatesTimer_Tick(sender As System.Object, e As System.EventArgs) Handles UpdatesTimer.Tick

		'Debug.Print("updates tick = " & UpdatesTick)

		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then Return

		If My.Settings.CBGlitterFeed = True And ssh_UpdatingPost = False Then

			ssh_UpdatesTick -= 1

			If ssh_UpdatesTick < 1 Then

				ssh_UpdatesTick = 1080 / My.Settings.GlitterDSlider

				ssh_UpdateList.Clear()

				If FrmSettings.CBTease.Checked = True Then
					For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Apps\Glitter\Tease\", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
						ssh_UpdateList.Add(foundFile)
					Next
				End If

				If FrmSettings.CBEgotist.Checked = True Then
					For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Apps\Glitter\Egotist\", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
						ssh_UpdateList.Add(foundFile)
					Next
				End If

				If FrmSettings.CBTrivia.Checked = True Then
					For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Apps\Glitter\Trivia\", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
						ssh_UpdateList.Add(foundFile)
					Next
				End If

				If FrmSettings.CBDaily.Checked = True Then
					For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Apps\Glitter\Daily\", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
						ssh_UpdateList.Add(foundFile)
					Next
				End If

				If FrmSettings.CBCustom1.Checked = True Then
					For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Apps\Glitter\Custom 1\", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
						ssh_UpdateList.Add(foundFile)
					Next
				End If

				If FrmSettings.CBCustom2.Checked = True Then
					For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Apps\Glitter\Custom 2\", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
						ssh_UpdateList.Add(foundFile)
					Next
				End If

				If ssh_UpdateList.Count < 1 Then
					My.Settings.CBGlitterFeed = False
					'MessageBox.Show(Me, "Tease AI attempted to create a Glitter update, but no files were found! Please make sure at least one category containing Glitter txt files has been selected.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					MessageBox.Show(Me, "Tease AI attempted to create a Glitter update, but no files were found! Please make sure at least one category containing Glitter txt files has been selected." & Environment.NewLine _
					& Environment.NewLine & "Glitter feed has been automatically disabled.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					Return
				End If



				StatusUpdatePost()



			End If

		End If
	End Sub





	Private Sub MediaButton_Click(sender As System.Object, e As System.EventArgs) Handles BtnToggleMediaPanel.Click

		If SplitContainer1.Panel2.Height < 68 Then Return

		If PNLMediaBar.Visible = True Then
			PNLMediaBar.Visible = False
			BtnToggleMediaPanel.Text = "Show Media Panel"
			'ChatText.Location = New Point(0, 0)
			'ChatText.Height = ChatText.Height + 29

			browsefolderButton.Visible = False
			previousButton.Visible = False
			nextButton.Visible = False
			BTNLoadVideo.Visible = False
			BTNVideoControls.Visible = False

		Else

			PNLMediaBar.Visible = True
			BtnToggleMediaPanel.Text = "Hide Media Panel"
			'ChatText.Location = New Point(0, 29)
			'ChatText.Height = ChatText.Height - 29

			browsefolderButton.Visible = True
			previousButton.Visible = True
			nextButton.Visible = True
			BTNLoadVideo.Visible = True
			BTNVideoControls.Visible = True

		End If

		AdjustWindow()

		ScrollChatDown()

	End Sub

	Public Function Color2Html(ByVal MyColor As Color) As String
		Return "#" & MyColor.ToArgb().ToString("x").Substring(2).ToUpper
	End Function

	Public Function SysKeywordClean(ByVal StringClean As String) As String

		If StringClean.Contains("@RandomText(") Then



			Dim RandArray As String() = StringClean.Split(")")

			For i As Integer = 0 To RandArray.Count - 1

				If RandArray(i).Contains("@RandomText(") Then

					RandArray(i) = RandArray(i) & ")"

					Dim TempText As String = GetParentheses(RandArray(i), "@RandomText(")
					Dim OriginalRand As String = TempText

					If TempText.Contains(",") Then
						TempText = FixCommas(TempText)
						Dim TextArray As String() = TempText.Split(",")
						TempText = TextArray(ssh_randomizer.Next(0, TextArray.Count))
					End If

					StringClean = StringClean.Replace("@RandomText(" & OriginalRand & ")", TempText)

				End If

			Next

		End If

		If StringClean.Contains("@RT(") Then
			Dim RandArray As String() = StringClean.Split(")")
			For i As Integer = 0 To RandArray.Count - 1
				If RandArray(i).Contains("@RT(") Then
					RandArray(i) = RandArray(i) & ")"
					Dim TempText As String = GetParentheses(RandArray(i), "@RT(")
					Dim OriginalRand As String = TempText
					If TempText.Contains(",") Then
						TempText = FixCommas(TempText)
						Dim TextArray As String() = TempText.Split(",")
						TempText = TextArray(ssh_randomizer.Next(0, TextArray.Count))
					End If
					StringClean = StringClean.Replace("@RT(" & OriginalRand & ")", TempText)
				End If
			Next
		End If



		If FrmSettings.CBCockToClit.Checked = True Then
			StringClean = StringClean.Replace("#Cock", "#CockToClit")
			StringClean = StringClean.Replace("stroking", "#StrokingToRubbing")
		End If

		If FrmSettings.CBBallsToPussy.Checked = True Then
			StringClean = StringClean.Replace("those #Balls", "that #Balls")
			StringClean = StringClean.Replace("#Balls", "#BallsToPussy")
		End If

		StringClean = StringClean.Replace("#SubName", subName.Text)
		Debug.Print("StringClean = " & StringClean)
		StringClean = StringClean.Replace("#DomName", domName.Text)
		Debug.Print("StringClean = " & StringClean)
		StringClean = StringClean.Replace("#DomHonorific", FrmSettings.TBHonorific.Text)

		StringClean = StringClean.Replace("#DomAge", FrmSettings.domageNumBox.Value)

		StringClean = StringClean.Replace("#DomLevel", FrmSettings.domlevelNumBox.Value)

		StringClean = StringClean.Replace("#DomApathy", FrmSettings.NBEmpathy.Value)

		StringClean = StringClean.Replace("#DomHair", FrmSettings.TBDomHairColor.Text)

		StringClean = StringClean.Replace("#DomHairLength", FrmSettings.domhairlengthComboBox.Text)

		StringClean = StringClean.Replace("#DomEyes", FrmSettings.TBDomEyeColor.Text)

		StringClean = StringClean.Replace("#DomCup", FrmSettings.boobComboBox.Text)

		StringClean = StringClean.Replace("#DomMoodMin", FrmSettings.NBDomMoodMin.Value)

		StringClean = StringClean.Replace("#DomMoodMax", FrmSettings.NBDomMoodMax.Value)

		StringClean = StringClean.Replace("#DomMood", ssh_DommeMood)

		StringClean = StringClean.Replace("#DomAvgCockMin", FrmSettings.NBAvgCockMin.Value)

		StringClean = StringClean.Replace("#DomAvgCockMax", FrmSettings.NBAvgCockMax.Value)

		StringClean = StringClean.Replace("#DomSmallCockMax", FrmSettings.NBAvgCockMin.Value - 1)

		StringClean = StringClean.Replace("#DomLargeCockMin", FrmSettings.NBAvgCockMax.Value + 1)

		StringClean = StringClean.Replace("#DomSelfAgeMin", FrmSettings.NBSelfAgeMin.Value)

		StringClean = StringClean.Replace("#DomSelfAgeMax", FrmSettings.NBSelfAgeMax.Value)

		StringClean = StringClean.Replace("#DomSubAgeMin", FrmSettings.NBSubAgeMin.Value)

		StringClean = StringClean.Replace("#DomSubAgeMax", FrmSettings.NBSubAgeMax.Value)

		StringClean = StringClean.Replace("#DomOrgasmRate", LCase(FrmSettings.alloworgasmComboBox.Text).Replace("allows", "allow"))

		StringClean = StringClean.Replace("#DomRuinRate", LCase(FrmSettings.ruinorgasmComboBox.Text).Replace("ruins", "ruin"))

		StringClean = StringClean.Replace("#SubAge", FrmSettings.subAgeNumBox.Value)

		StringClean = StringClean.Replace("#SubBirthdayMonth", FrmSettings.NBBirthdayMonth.Value)

		StringClean = StringClean.Replace("#SubBirthdayDay", FrmSettings.NBBirthdayDay.Value)

		StringClean = StringClean.Replace("#DomBirthdayMonth", FrmSettings.NBDomBirthdayMonth.Value)

		StringClean = StringClean.Replace("#DomBirthdayDay", FrmSettings.NBDomBirthdayDay.Value)

		StringClean = StringClean.Replace("#SubHair", FrmSettings.TBSubHairColor.Text)

		StringClean = StringClean.Replace("#SubEyes", FrmSettings.TBSubEyeColor.Text)

		StringClean = StringClean.Replace("#SubCockSize", FrmSettings.CockSizeNumBox.Value)

		StringClean = StringClean.Replace("#SubWritingTaskMin", FrmSettings.NBWritingTaskMin.Value)

		StringClean = StringClean.Replace("#SubWritingTaskMax", FrmSettings.NBWritingTaskMax.Value)

		' StringClean = StringClean.Replace("#SubWritingTaskRAND", randomizer.Next(NBWritingTaskMin.Value / 10, (NBWritingTaskMax.Value / 10) + 1)) * 10

		StringClean = StringClean.Replace("#ShortName", My.Settings.GlitterSN)

		StringClean = StringClean.Replace("#GlitterContact1", FrmSettings.TBGlitter1.Text)
		StringClean = StringClean.Replace("#Contact1", FrmSettings.TBGlitter1.Text)
		StringClean = StringClean.Replace("#GlitterContact2", FrmSettings.TBGlitter2.Text)
		StringClean = StringClean.Replace("#Contact2", FrmSettings.TBGlitter2.Text)
		StringClean = StringClean.Replace("#GlitterContact3", FrmSettings.TBGlitter3.Text)
		StringClean = StringClean.Replace("#Contact3", FrmSettings.TBGlitter3.Text)

		StringClean = StringClean.Replace("#CBTCockCount", ssh_CBTCockCount)
		StringClean = StringClean.Replace("#CBTBallsCount", ssh_CBTBallsCount)

		Debug.Print("Test")

		If My.Settings.OrgasmsLocked = True Then
			StringClean = StringClean.Replace("#OrgasmLockDate", My.Settings.OrgasmLockDate.Date.ToString())
		Else
			StringClean = StringClean.Replace("#OrgasmLockDate", "later")
		End If

		If StringClean.Contains("#RandomRound100(") Then

			Dim RandomFlag As String = GetParentheses(StringClean, "#RandomRound100(")
			Dim OriginalFlag As String = RandomFlag
			RandomFlag = FixCommas(RandomFlag)
			Dim RandInt As Integer
			Dim FlagArray() As String = RandomFlag.Split(",")

			RandInt = ssh_randomizer.Next(Val(FlagArray(0)), Val(FlagArray(1)) + 1)
			If RandInt >= 100 Then RandInt = 100 * Math.Round(RandInt / 100)
			StringClean = StringClean.Replace("#RandomRound100(" & OriginalFlag & ")", RandInt)

		End If

		If StringClean.Contains("#RandomRound10(") Then


			Dim RandomFlag As String = GetParentheses(StringClean, "#RandomRound10(")
			Dim OriginalFlag As String = RandomFlag
			RandomFlag = FixCommas(RandomFlag)
			Dim RandInt As Integer
			Dim FlagArray() As String = RandomFlag.Split(",")

			RandInt = ssh_randomizer.Next(Val(FlagArray(0)), Val(FlagArray(1)) + 1)
			If RandInt >= 10 Then RandInt = 10 * Math.Round(RandInt / 10)
			StringClean = StringClean.Replace("#RandomRound10(" & OriginalFlag & ")", RandInt)

		End If


		If StringClean.Contains("#RandomRound5(") Then


			Dim RandomFlag As String = GetParentheses(StringClean, "#RandomRound5(")
			Dim OriginalFlag As String = RandomFlag
			RandomFlag = FixCommas(RandomFlag)
			Dim RandInt As Integer
			Dim FlagArray() As String = RandomFlag.Split(",")

			RandInt = ssh_randomizer.Next(Val(FlagArray(0)), Val(FlagArray(1)) + 1)
			If RandInt >= 5 Then RandInt = 5 * Math.Round(RandInt / 5)
			StringClean = StringClean.Replace("#RandomRound5(" & OriginalFlag & ")", RandInt)

		End If


		If StringClean.Contains("#Random(") Then

			Dim RandomFlag As String = GetParentheses(StringClean, "#Random(")
			Dim OriginalFlag As String = RandomFlag
			RandomFlag = FixCommas(RandomFlag)
			Dim RandInt As Integer
			Dim FlagArray() As String = RandomFlag.Split(",")

			RandInt = ssh_randomizer.Next(Val(FlagArray(0)), Val(FlagArray(1)) + 1)
			StringClean = StringClean.Replace("#Random(" & OriginalFlag & ")", RandInt)

		End If

		If StringClean.Contains("#DateDifference(") Then

			Dim DateFlag As String = GetParentheses(StringClean, "#DateDifference(")
			Dim OriginalFlag As String = DateFlag
			DateFlag = FixCommas(DateFlag)
			Dim DateArray() As String = DateFlag.Split(",")

			Dim DDiff As Integer

			If UCase(DateArray(1)).Contains("SECOND") Then DDiff = DateDiff(DateInterval.Second, GetDate(DateArray(0)), Now)
			If UCase(DateArray(1)).Contains("MINUTE") Then DDiff = DateDiff(DateInterval.Minute, GetDate(DateArray(0)), Now)
			If UCase(DateArray(1)).Contains("HOUR") Then DDiff = DateDiff(DateInterval.Hour, GetDate(DateArray(0)), Now)
			If UCase(DateArray(1)).Contains("DAY") Then DDiff = DateDiff(DateInterval.Day, GetDate(DateArray(0)), Now)
			If UCase(DateArray(1)).Contains("WEEK") Then DDiff = DateDiff(DateInterval.Day, GetDate(DateArray(0)), Now) * 7
			If UCase(DateArray(1)).Contains("MONTH") Then DDiff = DateDiff(DateInterval.Month, GetDate(DateArray(0)), Now)
			If UCase(DateArray(1)).Contains("YEAR") Then DDiff = DateDiff(DateInterval.Year, GetDate(DateArray(0)), Now)

			StringClean = StringClean.Replace("#DateDifference(" & OriginalFlag & ")", DDiff)

		End If



		Dim PetNameVal As Integer = ssh_randomizer.Next(1, 5)

		If PetNameVal = 1 Then ssh_PetName = FrmSettings.petnameBox3.Text
		If PetNameVal = 2 Then ssh_PetName = FrmSettings.petnameBox4.Text
		If PetNameVal = 3 Then ssh_PetName = FrmSettings.petnameBox5.Text
		If PetNameVal = 4 Then ssh_PetName = FrmSettings.petnameBox6.Text

		If ssh_DommeMood < FrmSettings.NBDomMoodMin.Value Then
			PetNameVal = ssh_randomizer.Next(1, 3)
			If PetNameVal = 1 Then ssh_PetName = FrmSettings.petnameBox7.Text
			If PetNameVal = 2 Then ssh_PetName = FrmSettings.petnameBox8.Text
		End If


		If ssh_DommeMood > FrmSettings.NBDomMoodMax.Value Then
			PetNameVal = ssh_randomizer.Next(1, 3)
			If PetNameVal = 1 Then ssh_PetName = FrmSettings.petnameBox1.Text
			If PetNameVal = 2 Then ssh_PetName = FrmSettings.petnameBox2.Text
		End If


		StringClean = StringClean.Replace("#PetName", ssh_PetName)

		' If Hour(Date.Now) < 11 Then PreCleanString = PreCleanString.Replace("#GeneralTime", "this morning")
		If Hour(Date.Now) > 3 And Hour(Date.Now) < 12 Then StringClean = StringClean.Replace("#GreetSub", "#GoodMorningSub")
		'If Hour(Date.Now) > 10 And Hour(Date.Now) < 18 Then PreCleanString = PreCleanString.Replace("#GeneralTime", "today")
		If Hour(Date.Now) > 11 And Hour(Date.Now) < 18 Then StringClean = StringClean.Replace("#GreetSub", "#GoodAfternoonSub")
		'If Hour(Date.Now) > 17 Then PreCleanString = PreCleanString.Replace("#GeneralTime", "tonight")
		If Hour(Date.Now) > 17 Or Hour(Date.Now) < 4 Then StringClean = StringClean.Replace("#GreetSub", "#GoodEveningSub")


		If Hour(Date.Now) < 4 Then StringClean = StringClean.Replace("#GeneralTime", "tonight")
		If Hour(Date.Now) > 3 And Hour(Date.Now) < 11 Then StringClean = StringClean.Replace("#GeneralTime", "this morning")
		If Hour(Date.Now) > 10 And Hour(Date.Now) < 18 Then StringClean = StringClean.Replace("#GeneralTime", "today")
		If Hour(Date.Now) > 17 Then StringClean = StringClean.Replace("#GeneralTime", "tonight")

		If ssh_AssImage = True Then StringClean = StringClean.Replace("#TnAFastSlidesResult", "#BBnB_Ass")
		If ssh_BoobImage = True Then StringClean = StringClean.Replace("#TnAFastSlidesResult", "#BBnB_Boobs")

		If StringClean.Contains("#RANDNumberLow") Then
			' ### Number between 3-5 , 5-25
			ssh_TempVal = ssh_randomizer.Next(1, 6) * FrmSettings.domlevelNumBox.Value
			If ssh_TempVal > 10 Then ssh_TempVal = 5 * Math.Round(ssh_TempVal / 5)
			If ssh_TempVal < 3 Then ssh_TempVal = 3
			StringClean = StringClean.Replace("#RNDNumberLow", ssh_TempVal)
		End If


		If StringClean.Contains("#RANDNumberHigh") Then
			' ### Number between 5-25 , 25-100
			ssh_TempVal = ssh_randomizer.Next(5, 21) * FrmSettings.domlevelNumBox.Value
			If ssh_TempVal > 10 Then ssh_TempVal = 5 * Math.Round(ssh_TempVal / 5)
			StringClean = StringClean.Replace("#RNDNumberHigh", ssh_TempVal)
		End If


		If StringClean.Contains("#RANDNumber") Then
			' ### Number between 3-10 , 5-50
			ssh_TempVal = ssh_randomizer.Next(1, 11) * FrmSettings.domlevelNumBox.Value
			If ssh_TempVal > 10 Then ssh_TempVal = 5 * Math.Round(ssh_TempVal / 5)
			If ssh_TempVal < 3 Then ssh_TempVal = 3
			StringClean = StringClean.Replace("#RNDNumber", ssh_TempVal)
		End If



		StringClean = StringClean.Replace("#RP_ChosenCase", FrmCardList.RiskyPickNumber)
		StringClean = StringClean.Replace("#RP_RespondCase", FrmCardList.RiskyResponse)
		'StringClean = StringClean.Replace("#RP_CaseNumber", FrmCardList.RiskyCase)
		If FrmCardList.RiskyPickCount = 0 Then StringClean = StringClean.Replace("#RP_CaseNumber", FrmCardList.LBLPick1.Text)
		If FrmCardList.RiskyPickCount = 1 Then StringClean = StringClean.Replace("#RP_CaseNumber", FrmCardList.LBLPick2.Text)
		If FrmCardList.RiskyPickCount = 2 Then StringClean = StringClean.Replace("#RP_CaseNumber", FrmCardList.LBLPick3.Text)
		If FrmCardList.RiskyPickCount = 3 Then StringClean = StringClean.Replace("#RP_CaseNumber", FrmCardList.LBLPick4.Text)
		If FrmCardList.RiskyPickCount = 4 Then StringClean = StringClean.Replace("#RP_CaseNumber", FrmCardList.LBLPick5.Text)
		If FrmCardList.RiskyPickCount > 4 Then StringClean = StringClean.Replace("#RP_CaseNumber", FrmCardList.LBLPick6.Text)
		StringClean = StringClean.Replace("#RP_EdgeOffer", FrmCardList.RiskyEdgeOffer)
		StringClean = StringClean.Replace("#RP_TokenOffer", FrmCardList.RiskyTokenOffer)
		StringClean = StringClean.Replace("#RP_EdgesOwed", FrmCardList.EdgesOwed)
		StringClean = StringClean.Replace("#RP_TokensPaid", FrmCardList.TokensPaid)

		StringClean = StringClean.Replace("#BronzeTokens", ssh_BronzeTokens)
		StringClean = StringClean.Replace("#SilverTokens", ssh_SilverTokens)
		StringClean = StringClean.Replace("#GoldTokens", ssh_GoldTokens)

		StringClean = StringClean.Replace("#SessionEdges", ssh_SessionEdges)
		StringClean = StringClean.Replace("#SessionCBTCock", ssh_CBTCockCount)
		StringClean = StringClean.Replace("#SessionCBTBalls", ssh_CBTBallsCount)

		'StringClean = StringClean.Replace("#Sys_SubLeftEarly", My.Settings.Sys_SubLeftEarly)
		'StringClean = StringClean.Replace("#Sys_SubLeftEarlyTotal", My.Settings.Sys_SubLeftEarlyTotal)

		StringClean = StringClean.Replace("#SlideshowCount", ssh_CustomSlideshowList.Count - 1)
		StringClean = StringClean.Replace("#SlideshowCurrent", ssh_SlideshowInt)
		StringClean = StringClean.Replace("#SlideshowRemaining", (ssh_CustomSlideshowList.Count - 1) - ssh_SlideshowInt)

		StringClean = StringClean.Replace("#CurrentTime", Format(Now, "h:mm"))
		StringClean = StringClean.Replace("#CurrentDay", Format(Now, "dddd"))
		StringClean = StringClean.Replace("#CurrentMonth", Format(Now, "MMMMM"))
		StringClean = StringClean.Replace("#CurrentYear", Format(Now, "yyyy"))
		StringClean = StringClean.Replace("#CurrentDate", FormatDateTime(Date.Now, DateFormat.ShortDate))
		' StringClean = StringClean.Replace("#CurrentDate", Format(Now, "MM/dd/yyyy"))

		' 
		If StringClean.Contains("#Var[") Then

			'Dim VarSplit As String() = StringClean.Split("]")
			'For i As Integer = 0 To VarSplit.Count - 1
			'If VarSplit(i).Contains("#Var[") Then
			'Dim VarString As String = VarSplit(i) & "]"
			'Dim VarFlag As String = GetParentheses(VarString, "#Var[")
			'Debug.Print("VarFlag = " & VarFlag)
			'Dim VarFlag2 As String = GetVariable(VarFlag)
			'Debug.Print("VarFlag2 = " & VarFlag2)
			' StringClean = StringClean.Replace("#Var[" & VarFlag & "]", VarFlag2)
			'Debug.Print("Try this shit       #Var[" & VarFlag & "]")
			'StringClean = StringClean.Replace("#Var[" & VarFlag & "]", VarFlag2)
			'End If
			'    Next

			StringClean = StringClean.Replace("#Var[", "@ShowVar[")

		End If

		'BUG: #RandomSlideshowCategory does not work! The Variable RandomSlideshowCategory is never set.
		If StringClean.Contains("#RandomSlideshowCategory") Then StringClean = StringClean.Replace("#RandomSlideshowCategory", ssh_RandomSlideshowCategory)

        '▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
        '                                   ImageCount
        '▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
        If StringClean.Contains("#LocalImageCount") Then
			Dim temp As Dictionary(Of ImageGenre, ImageDataContainer) = GetImageData()
			Dim counter As Integer = 0

			For Each genre As ImageGenre In temp.Keys
				counter += temp(genre).CountImages(ImageSourceType.Local)
			Next

			StringClean = StringClean.Replace("#LocalImageCount", counter)
		End If

		If StringClean.Contains("#BlogImageCount") Then
			StringClean = StringClean.Replace("#BlogImageCount", GetImageData(ImageGenre.Blog).CountImages())
		End If

		If StringClean.Contains("#ButtImageCount") Then
			StringClean = StringClean.Replace("#ButtImageCount", GetImageData(ImageGenre.Butt).CountImages())
		End If

		If StringClean.Contains("#ButtsImageCount") Then
			StringClean = StringClean.Replace("#ButtsImageCount", GetImageData(ImageGenre.Butt).CountImages())
		End If

		If StringClean.Contains("#BoobImageCount") Then
			StringClean = StringClean.Replace("#BoobImageCount", GetImageData(ImageGenre.Boobs).CountImages())
		End If

		If StringClean.Contains("#BoobsImageCount") Then
			StringClean = StringClean.Replace("#BoobsImageCount", GetImageData(ImageGenre.Boobs).CountImages())
		End If

		If StringClean.Contains("#HardcoreImageCount") Then
			StringClean = StringClean.Replace("#HardcoreImageCount", GetImageData(ImageGenre.Hardcore).CountImages())
		End If

		If StringClean.Contains("#HardcoreImageCount") Then
			StringClean = StringClean.Replace("#HardcoreImageCount", GetImageData(ImageGenre.Hardcore).CountImages())
		End If

		If StringClean.Contains("#SoftcoreImageCount") Then
			StringClean = StringClean.Replace("#SoftcoreImageCount", GetImageData(ImageGenre.Softcore).CountImages())
		End If

		If StringClean.Contains("#LesbianImageCount") Then
			StringClean = StringClean.Replace("#LesbianImageCount", GetImageData(ImageGenre.Lesbian).CountImages())
		End If

		If StringClean.Contains("#BlowjobImageCount") Then
			StringClean = StringClean.Replace("#BlowjobImageCount", GetImageData(ImageGenre.Blowjob).CountImages())
		End If

		If StringClean.Contains("#FemdomImageCount") Then
			StringClean = StringClean.Replace("#FemdomImageCount", GetImageData(ImageGenre.Femdom).CountImages())
		End If

		If StringClean.Contains("#LezdomImageCount") Then
			StringClean = StringClean.Replace("#LezdomImageCount", GetImageData(ImageGenre.Lezdom).CountImages())
		End If

		If StringClean.Contains("#HentaiImageCount") Then
			StringClean = StringClean.Replace("#HentaiImageCount", GetImageData(ImageGenre.Hentai).CountImages())
		End If

		If StringClean.Contains("#GayImageCount") Then
			StringClean = StringClean.Replace("#GayImageCount", GetImageData(ImageGenre.Gay).CountImages())
		End If

		If StringClean.Contains("#MaledomImageCount") Then
			StringClean = StringClean.Replace("#MaledomImageCount", GetImageData(ImageGenre.Maledom).CountImages())
		End If

		If StringClean.Contains("#CaptionsImageCount") Then
			StringClean = StringClean.Replace("#CaptionsImageCount", GetImageData(ImageGenre.Captions).CountImages())
		End If

		If StringClean.Contains("#GeneralImageCount") Then
			StringClean = StringClean.Replace("#GeneralImageCount", GetImageData(ImageGenre.General).CountImages())
		End If

		If StringClean.Contains("#LikedImageCount") Then
			StringClean = StringClean.Replace("#LikedImageCount", GetImageData(ImageGenre.Liked).CountImages())
		End If

		If StringClean.Contains("#DislikedImageCount") Then
			StringClean = StringClean.Replace("#DislikedImageCount", GetImageData(ImageGenre.Disliked).CountImages())
		End If
		'▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲
		' ImageCount - End
		'▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲
		If StringClean.Contains("#EdgeHold") Then
			Dim i As Integer = FrmSettings.NBHoldTheEdgeMin.Value
			If FrmSettings.LBLMinHold.Text = "minutes" Then i *= 60

			Dim x As Integer = FrmSettings.NBHoldTheEdgeMax.Value
			If FrmSettings.LBLMaxHold.Text = "minutes" Then x *= 60

			Dim t As Integer = ssh_randomizer.Next(i, x + 1)
			If t >= 5 Then t = 5 * Math.Round(t / 5)
			Dim TConvert As String = ConvertSeconds(t)
			StringClean = StringClean.Replace("#EdgeHold", TConvert)
		End If

		If StringClean.Contains("#LongHold") Then
			Dim i As Integer = FrmSettings.NBLongHoldMin.Value
			Dim x As Integer = FrmSettings.NBLongHoldMax.Value
			Dim t As Integer = ssh_randomizer.Next(i, x + 1)
			t *= 60
			If t >= 5 Then t = 5 * Math.Round(t / 5)
			Dim TConvert As String = ConvertSeconds(t)
			StringClean = StringClean.Replace("#LongHold", TConvert)
		End If

		If StringClean.Contains("#ExtremeHold") Then
			Dim i As Integer = FrmSettings.NBExtremeHoldMin.Value
			Dim x As Integer = FrmSettings.NBExtremeHoldMax.Value
			Dim t As Integer = ssh_randomizer.Next(i, x + 1)
			t *= 60
			If t >= 5 Then t = 5 * Math.Round(t / 5)
			Dim TConvert As String = ConvertSeconds(t)
			StringClean = StringClean.Replace("#ExtremeHold", TConvert)
		End If

		StringClean = StringClean.Replace("#CurrentImage", ssh_ImageLocation)

		Return StringClean


	End Function

	Public Function ConvertSeconds(ByVal Seconds As Integer) As String

		Dim RetVal As String

		Dim SecondsDifference As Integer = Seconds
		Dim HMS = TimeSpan.FromSeconds(SecondsDifference)
		Dim H = HMS.Hours.ToString
		Dim M = HMS.Minutes.ToString
		Dim S = HMS.Seconds.ToString

		If HMS.Hours = 1 Then
			H = "1 hour"
		Else
			H = H & " hours"
		End If

		If HMS.Minutes = 1 Then
			M = "1 minute"
		Else
			Dim t As Integer = HMS.Minutes
			If t >= 5 Then t = 5 * Math.Round(t / 5)
			M = t & " minutes"
		End If

		If HMS.Minutes > 4 Or HMS.Hours > 0 Or HMS.Seconds = 0 Then
			S = ""
		Else
			If HMS.Seconds = 1 Then
				S = "1 second"
			Else
				S = S & " seconds"
			End If
		End If

		RetVal = ""

		If HMS.Hours > 0 Then
			RetVal = RetVal & H
			If HMS.Minutes > 0 Then RetVal = RetVal & " and "
		End If

		If HMS.Minutes > 0 Then
			RetVal = RetVal & M
			If HMS.Seconds > 0 And HMS.Hours < 1 And HMS.Minutes < 4 Then RetVal = RetVal & " and "
		End If

		RetVal = RetVal & S

		Return RetVal


	End Function




	Public Function PoundClean(ByVal StringClean As String) As String

		'Debug.Print("StringClean = " & StringClean)

		'DeepClean:


		StringClean = SysKeywordClean(StringClean)

		Debug.Print("PoundClean System Keyword Checkpoint")



		ssh_FoundTag = "NULL"

		Try
			If File.Exists(ssh__ImageFileNames(ssh_FileCount)) Then ssh_MainPictureImage = Path.GetDirectoryName(ssh__ImageFileNames(ssh_FileCount))
		Catch
		End Try

		'TODO: remove unsecure IO.Access to file, for there is no DirectoryCheck.
		If File.Exists(ssh_MainPictureImage & "\ImageTags.txt") Then
			' Read all lines of the given file.
			Dim TagList As List(Of String) = Txt2List(ssh_MainPictureImage & "\ImageTags.txt")

			'If SlideshowLoaded = True And Not mainPictureBox.Image Is Nothing And domVLC.Visible = False Then
			If ssh_SlideshowLoaded = True And Not mainPictureBox.Image Is Nothing And DomWMP.Visible = False Then
				Try
					For t As Integer = 0 To TagList.Count - 1
						'Debug.Print("TagList(t) = " & TagList(t))
						If TagList(t).Contains(Path.GetFileName(ssh__ImageFileNames(ssh_FileCount))) Then
							ssh_FoundTag = TagList(t)
							Dim FoundTagSplit As String() = Split(ssh_FoundTag)
							For j As Integer = 0 To FoundTagSplit.Length - 1
								If FoundTagSplit(j).Contains("TagGarment") Then
									ssh_TagGarment = FoundTagSplit(j).Replace("TagGarment", "")
									ssh_TagGarment = ssh_TagGarment.Replace("-", " ")
								End If

								If FoundTagSplit(j).Contains("TagUnderwear") Then
									ssh_TagUnderwear = FoundTagSplit(j).Replace("TagUnderwear", "")
									ssh_TagUnderwear = ssh_TagUnderwear.Replace("-", " ")
								End If

								If FoundTagSplit(j).Contains("TagTattoo") Then
									ssh_TagTattoo = FoundTagSplit(j).Replace("TagTattoo", "")
									ssh_TagTattoo = ssh_TagTattoo.Replace("-", " ")
								End If

								If FoundTagSplit(j).Contains("TagSexToy") Then
									ssh_TagSexToy = FoundTagSplit(j).Replace("TagSexToy", "")
									ssh_TagSexToy = ssh_TagSexToy.Replace("-", " ")
								End If

								If FoundTagSplit(j).Contains("TagFurniture") Then
									ssh_TagFurniture = FoundTagSplit(j).Replace("TagFurniture", "")
									ssh_TagFurniture = ssh_TagFurniture.Replace("-", " ")
								End If

							Next
							Exit For
						End If
					Next
				Catch
				End Try
			End If


			'Debug.Print("TagGarment = " & TagGarment)
			'Debug.Print("TagUnderwear = " & TagUnderwear)
			'Debug.Print("TagTattoo = " & TagTattoo)
			'Debug.Print("TagSexToy = " & TagSexToy)
			'Debug.Print("TagFurniture = " & TagFurniture)
			'Debug.Print("FoundTag = " & FoundTag)



		End If

		StringClean = StringClean.Replace("#TagGarment", ssh_TagGarment)
		StringClean = StringClean.Replace("#TagUnderwear", ssh_TagUnderwear)
		StringClean = StringClean.Replace("#TagTattoo", ssh_TagTattoo)
		StringClean = StringClean.Replace("#TagSexToy", ssh_TagSexToy)
		StringClean = StringClean.Replace("#TagFurniture", ssh_TagFurniture)


		If StringClean.Contains("#") Or StringClean.Contains("@Tag") Then


			Dim PoundArray() As String = Split(StringClean)


			For i As Integer = 0 To PoundArray.Length - 1
				Debug.Print("PoundArray(i) = " & PoundArray(i))
				'Debug.Print("PoundArray.Length = " & PoundArray.Length)

				If PoundArray(i) = "" Then GoTo PoundBreak
				If PoundArray(i).Substring(0, 1) = "#" Then

					'DoItHere:

					' PoundArray(i) = SysKeywordClean(PoundArray(i))

					'If Not PoundArray(i).Contains("#") Then GoTo PoundBreak


					PoundArray(i) = PoundArray(i).Replace(".", "")
					PoundArray(i) = PoundArray(i).Replace(",", "")
					PoundArray(i) = PoundArray(i).Replace("""", "")
					PoundArray(i) = PoundArray(i).Replace(")", "")
					PoundArray(i) = PoundArray(i).Replace("!", "")
					PoundArray(i) = PoundArray(i).Replace("?", "")
					PoundArray(i) = PoundArray(i).Replace(":", "")
					PoundArray(i) = PoundArray(i).Replace(";", "")
					PoundArray(i) = PoundArray(i).Replace("'s", "")

					If File.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Vocabulary\" & PoundArray(i) & ".txt") Then
						Dim filePath As String = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Vocabulary\" & PoundArray(i) & ".txt"
						Dim lines As List(Of String) = Txt2List(filePath)



						Try
							lines = FilterList(lines)
							ssh_Crazy = False
							ssh_Vulgar = False
							ssh_Supremacist = False
							Dim PoundVal As Integer = ssh_randomizer.Next(0, lines.Count)
							'Debug.Print("PoundLine = " & PoundLine)
							'Debug.Print("PoundVal = " & PoundVal)
							StringClean = StringClean.Replace(PoundArray(i), lines(PoundVal))
						Catch ex As Exception
							Log.WriteError("Error Processing file: " & filePath, ex,
										   "Tease AI did not return a valid line while parsing Command Filters")
							StringClean = "ERROR: Tease AI did not return a valid line while parsing Command Filters"
						End Try

						StringClean = StringClean.Replace("TagFace", "")
						StringClean = StringClean.Replace("TagBoobs", "")
						StringClean = StringClean.Replace("TagPussy", "")
						StringClean = StringClean.Replace("TagAss", "")
						StringClean = StringClean.Replace("TagFeet", "")
						StringClean = StringClean.Replace("TagFullyDressed", "")
						StringClean = StringClean.Replace("TagHalfDressed", "")
						StringClean = StringClean.Replace("TagNaked", "")
						StringClean = StringClean.Replace("TagSideView", "")
						StringClean = StringClean.Replace("TagCloseUp", "")
						StringClean = StringClean.Replace("TagMasturbating", "")
						StringClean = StringClean.Replace("TagSucking", "")
						StringClean = StringClean.Replace("TagSmiling", "")
						StringClean = StringClean.Replace("TagGlaring", "")
						StringClean = StringClean.Replace("TagSeeThrough", "")
						StringClean = StringClean.Replace("TagAllFours", "")

						'If PoundArray(i).Contains("#") Then GoTo DoItHere

					Else

						StringClean = StringClean.Replace(PoundArray(i), "<font color=""red"">" & PoundArray(i) & "</font>")

						Dim lazytext As String = "Unable to find the vocabulary file: """ & PoundArray(i) & """"
						Log.WriteError(lazytext, New Exception(lazytext), "PoundClean(String)")

					End If

				End If

PoundBreak:

			Next

			'PoundBreak:

		End If

		'Debug.Print("StringClean = " & StringClean)

		'If StringClean.Contains("#") Then GoTo DeepClean

BadVocabBreak:

		Return StringClean
	End Function

	Public Function CommandClean(ByVal StringClean As String, Optional ByVal TaskClean As Boolean = False) As String

		Debug.Print("Stringclean Intro = " & StringClean)

		If TaskClean = True Then
			Debug.Print("Tasks CommandClean")
			GoTo TaskCleanSet
		End If

RinseLatherRepeat:

		'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
		'									ImageCommands
		' - Make sure you call all Display ImageFunctions before executing @LockImages.
		'	If you don't, FilterList() will return a wrong list of lines =>
		'		=> The Domme is talking about an image, but she never showed one.
		'		=> She is talking about an new image, but never showed one.
		' - Call @DeleteLocalImage before you start to display a new Image, because they 
		'	are loaded and displayed async. Otherwise it will delete the wrong image!
		'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼

		' @DeleteLocalImage: Deletes the current displayed local image from filesystem, 
		' LiskedList, DislikedList and LocalImageTagList,  if the  current Image is 
		' not an image in the Domme- or Contacts-Image directory or their subdirectories.
		If StringClean.Contains("@DeleteLocalImage") Then
			If My.Settings.DomDeleteMedia = True Then
				Try
					DeleteCurrentImage(True)
				Catch ex As Exception
					'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
					'                   All Errors
					'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
					Log.WriteError("Command @DeleteLocalImage was unable to delete the image.",
								   ex, "@DeleteLocalImage failed")
				End Try
			End If
			StringClean = StringClean.Replace("@DeleteLocalImage", "")
		End If

		' @DeleteImage: Deletes the current displayed image from filesystem, LiskedList, 
		' DislikedList, LocalImageTagList and URL-Files, if the  current Image is 
		' not an image in the Domme- or Contacts-Image directory or their subdirectories.
		If StringClean.Contains("@DeleteImage") Then
			If My.Settings.DomDeleteMedia = True Then
				Try
					DeleteCurrentImage(False)
				Catch ex As Exception
					'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
					'                   All Errors
					'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
					Log.WriteError("Command @DeleteImage was unable to delete the image.",
								   ex, "@DeleteImage failed")
				End Try
			End If
			StringClean = StringClean.Replace("@DeleteImage", "")
		End If

		' The @UnlockImages Command allows the Domme Slideshow to resume functioning as normal.
		If StringClean.Contains("@UnlockImages") Then
			If ssh_SlideshowLoaded = True Then
				nextButton.Enabled = True
				previousButton.Enabled = True
				PicStripTSMIdommeSlideshow.Enabled = True
			End If
			ssh_LockImage = False
			StringClean = StringClean.Replace("@UnlockImages", "")
		End If

		If StringClean.Contains("@DommeTag(") Then
			Dim TagFlag As String = GetParentheses(StringClean, "@DommeTag(")
			' Try to get a Domme Image for the given Tags.
			ssh_DommeImageSTR = GetDommeImage(TagFlag)
			' Check the Result 
			If ssh_DommeImageSTR <> "" Then ssh_DommeImageFound = True
			' Clean the Text.
			StringClean = StringClean.Replace("@DommeTag(" & TagFlag & ")", "")
		End If

		If StringClean.Contains("@NewDommeSlideshow") Then
			ssh_NewDommeSlideshow = True
			ssh_OriginalDommeSlideshow = ssh__ImageFileNames(0)
			LoadDommeImageFolder()
			ssh_NewDommeSlideshow = False
			ssh_DomPic = ssh__ImageFileNames(ssh_FileCount)
			StringClean = StringClean.Replace("@NewDommeSlideshow", "")
		End If

		If StringClean.Contains("@DomTag(") Then
			Dim TagFlag As String = GetParentheses(StringClean, "@DomTag(")
			' Try to get a Domme Image for the given Tags.
			ssh_DommeImageSTR = GetDommeImage(TagFlag)
			' Check the Result 
			If ssh_DommeImageSTR <> "" Then ssh_DommeImageFound = True Else ssh_DommeImageFound = False
			StringClean = StringClean.Replace("@DomTag(" & TagFlag & ")", "")
		End If

		If StringClean.Contains("@ImageTag(") Then
			Dim TagFlag As String = GetParentheses(StringClean, "@ImageTag(")
			ShowImage(GetLocalImage(TagFlag), False)
			StringClean = StringClean.Replace("@ImageTag(" & TagFlag & ")", "")
		End If

		If StringClean.Contains("@ShowImage") And Not StringClean.Contains("@ShowImage[") Then
			ShowImage(GetRandomImage(), False)
			StringClean = StringClean.Replace("@ShowImage", "")
		End If

		If StringClean.Contains("@ShowButtImage") Or StringClean.Contains("@ShowButtsImage") Then
			ShowImage(GetImageData(ImageGenre.Butt).Random(), False)

			StringClean = StringClean.Replace("@ShowButtImage", "")
			StringClean = StringClean.Replace("@ShowButtsImage", "")
		End If

		If StringClean.Contains("@ShowBoobsImage") Or StringClean.Contains("@ShowBoobImage") Then
			ShowImage(GetImageData(ImageGenre.Boobs).Random(), False)

			StringClean = StringClean.Replace("@ShowBoobsImage", "")
			StringClean = StringClean.Replace("@ShowBoobImage", "")
		End If

		If StringClean.Contains("@ShowHardcoreImage") Then
			ShowImage(GetImageData(ImageGenre.Hardcore).Random(), False)
			StringClean = StringClean.Replace("@ShowHardcoreImage", "")
		End If

		If StringClean.Contains("@ShowSoftcoreImage") Then
			ShowImage(GetImageData(ImageGenre.Softcore).Random(), False)
			StringClean = StringClean.Replace("@ShowSoftcoreImage", "")
		End If

		If StringClean.Contains("@ShowLesbianImage") Then
			ShowImage(GetImageData(ImageGenre.Lesbian).Random(), False)
			StringClean = StringClean.Replace("@ShowLesbianImage", "")
		End If

		If StringClean.Contains("@ShowBlowjobImage") Then
			ShowImage(GetImageData(ImageGenre.Blowjob).Random(), False)
			StringClean = StringClean.Replace("@ShowBlowjobImage", "")
		End If

		If StringClean.Contains("@ShowFemdomImage") Then
			ShowImage(GetImageData(ImageGenre.Femdom).Random(), False)
			StringClean = StringClean.Replace("@ShowFemdomImage", "")
		End If

		If StringClean.Contains("@ShowLezdomImage") Then
			ShowImage(GetImageData(ImageGenre.Lezdom).Random(), False)
			StringClean = StringClean.Replace("@ShowLezdomImage", "")
		End If

		If StringClean.Contains("@ShowHentaiImage") Then
			ShowImage(GetImageData(ImageGenre.Hentai).Random(), False)
			StringClean = StringClean.Replace("@ShowHentaiImage", "")
		End If

		If StringClean.Contains("@ShowGayImage") Then
			ShowImage(GetImageData(ImageGenre.Gay).Random(), False)
			StringClean = StringClean.Replace("@ShowGayImage", "")
		End If

		If StringClean.Contains("@ShowMaledomImage") Then
			ShowImage(GetImageData(ImageGenre.Maledom).Random(), False)
			StringClean = StringClean.Replace("@ShowMaledomImage", "")
		End If

		If StringClean.Contains("@ShowCaptionsImage") Then
			ShowImage(GetImageData(ImageGenre.Captions).Random(), False)
			StringClean = StringClean.Replace("@ShowCaptionsImage", "")
		End If

		If StringClean.Contains("@ShowGeneralImage") Then
			ShowImage(GetImageData(ImageGenre.General).Random(), False)
			StringClean = StringClean.Replace("@ShowGeneralImage", "")
		End If

		If StringClean.Contains("@ShowLikedImage") Then
			ShowImage(GetImageData(ImageGenre.Liked).Random(), False)
			StringClean = StringClean.Replace("@ShowLikedImage", "")
		End If

		If StringClean.Contains("@ShowDislikedImage") Then
			ShowImage(GetImageData(ImageGenre.Disliked).Random(), False)
			StringClean = StringClean.Replace("@ShowDislikedImage", "")
		End If

		If StringClean.Contains("@ShowBlogImage") Then
			ShowImage(GetImageData(ImageGenre.Blog).Random(), False)
			StringClean = StringClean.Replace("@ShowBlogImage", "")
		End If

		' The @NewBlogImage Command is a defunct Command that has been replaced by @ShowBlogImage
		If StringClean.Contains("@NewBlogImage") Then
			ShowImage(GetImageData(ImageGenre.Blog).Random(), False)
			StringClean = StringClean.Replace("@NewBlogImage", "")
		End If

		If StringClean.Contains("@ShowLocalImage") And Not StringClean.Contains("@ShowLocalImage(") Then
			GetLocalImage()
			StringClean = StringClean.Replace("@ShowLocalImage", "")
		End If

		'===============================================================================
		'								@ShowLocalImage()
		'===============================================================================
		If StringClean.Contains("@ShowLocalImage(") Then
			Dim LocalFlag As String = GetParentheses(StringClean, "@ShowLocalImage(")
			LocalFlag = FixCommas(LocalFlag)

			Dim tmpListGenre As List(Of String) = LocalFlag.Split(",").ToList

			If LocalFlag.ToUpper.Contains("NOT") Then
				' =============== Invert the Content in Brackets ===============
				' Declare a String containing all available ImageGenres
				Dim CompareFlag As String = "Hardcore, Softcore, Lesbian, Blowjob, Femdom, Lezdom, Hentai, Gay, Maledom, Captions, General, Butts, Boobs"

				' Remove Imagegenre, when there are no local Images available or it is in the inverting bracket
				For i As Integer = tmpListGenre.Count - 1 To 0 Step -1
					If tmpListGenre(i).ToUpper.Contains("HARDCORE") Or Not GetImageData(ImageGenre.Hardcore).IsAvailable(ImageSourceType.Local) Then CompareFlag = CompareFlag.Replace("Hardcore, ", "")
					If tmpListGenre(i).ToUpper.Contains("SOFTCORE") Or Not GetImageData(ImageGenre.Softcore).IsAvailable(ImageSourceType.Local) Then CompareFlag = CompareFlag.Replace("Softcore, ", "")
					If tmpListGenre(i).ToUpper.Contains("LESBIAN") Or Not GetImageData(ImageGenre.Lesbian).IsAvailable(ImageSourceType.Local) Then CompareFlag = CompareFlag.Replace("Lesbian, ", "")
					If tmpListGenre(i).ToUpper.Contains("BLOWJOB") Or Not GetImageData(ImageGenre.Blowjob).IsAvailable(ImageSourceType.Local) Then CompareFlag = CompareFlag.Replace("Blowjob, ", "")
					If tmpListGenre(i).ToUpper.Contains("FEMDOM") Or Not GetImageData(ImageGenre.Femdom).IsAvailable(ImageSourceType.Local) Then CompareFlag = CompareFlag.Replace("Femdom, ", "")
					If tmpListGenre(i).ToUpper.Contains("LEZDOM") Or Not GetImageData(ImageGenre.Lezdom).IsAvailable(ImageSourceType.Local) Then CompareFlag = CompareFlag.Replace("Lezdom, ", "")
					If tmpListGenre(i).ToUpper.Contains("HENTAI") Or Not GetImageData(ImageGenre.Hentai).IsAvailable(ImageSourceType.Local) Then CompareFlag = CompareFlag.Replace("Hentai, ", "")
					If tmpListGenre(i).ToUpper.Contains("GAY") Or Not GetImageData(ImageGenre.Gay).IsAvailable(ImageSourceType.Local) Then CompareFlag = CompareFlag.Replace("Gay, ", "")
					If tmpListGenre(i).ToUpper.Contains("MALEDOM") Or Not GetImageData(ImageGenre.Maledom).IsAvailable(ImageSourceType.Local) Then CompareFlag = CompareFlag.Replace("Maledom, ", "")
					If tmpListGenre(i).ToUpper.Contains("CAPTIONS") Or Not GetImageData(ImageGenre.Captions).IsAvailable(ImageSourceType.Local) Then CompareFlag = CompareFlag.Replace("Captions, ", "")
					If tmpListGenre(i).ToUpper.Contains("GENERAL") Or Not GetImageData(ImageGenre.General).IsAvailable(ImageSourceType.Local) Then CompareFlag = CompareFlag.Replace("General, ", "")
					If tmpListGenre(i).ToUpper.Contains("BUTT") Or Not GetImageData(ImageGenre.Butt).IsAvailable(ImageSourceType.Local) Then CompareFlag = CompareFlag.Replace("Butts, ", "")
					If tmpListGenre(i).ToUpper.Contains("BUTTS") Then CompareFlag = CompareFlag.Replace("Butts, ", "")
					If tmpListGenre(i).ToUpper.Contains("BOOB") Or Not GetImageData(ImageGenre.Boobs).IsAvailable(ImageSourceType.Local) Then CompareFlag = CompareFlag.Replace("Boobs", "")
					If tmpListGenre(i).ToUpper.Contains("BOOBS") Then CompareFlag = CompareFlag.Replace("Boobs", "")
				Next

				' Set the inverted Array.
				tmpListGenre = CompareFlag.Split(", ").ToList
			End If

			' Pick a random entry from list
			Debug.Print("@ShowLocalImage() LocalFLag original = " & LocalFlag)
			Debug.Print("@ShowLocalImage() LocalFLag modified = " & String.Join(", ", tmpListGenre))

			' generate a list of all available Local Images. This way it is most 
			' likely, to get an image.
			Dim tmpImageLocationList As New List(Of String)

			For Each tmpStr As String In tmpListGenre
				If tmpStr.ToUpper.Contains("HARDCORE") Then
					tmpImageLocationList.AddRange(GetImageData(ImageGenre.Hardcore).ToList(ImageSourceType.Local))
				ElseIf tmpStr.ToUpper.Contains("SOFTCORE") Then
					tmpImageLocationList.AddRange(GetImageData(ImageGenre.Softcore).ToList(ImageSourceType.Local))
				ElseIf tmpStr.ToUpper.Contains("LESBIAN") Then
					tmpImageLocationList.AddRange(GetImageData(ImageGenre.Lesbian).ToList(ImageSourceType.Local))
				ElseIf tmpStr.ToUpper.Contains("BLOWJOB") Then
					tmpImageLocationList.AddRange(GetImageData(ImageGenre.Blowjob).ToList(ImageSourceType.Local))
				ElseIf tmpStr.ToUpper.Contains("FEMDOM") Then
					tmpImageLocationList.AddRange(GetImageData(ImageGenre.Femdom).ToList(ImageSourceType.Local))
				ElseIf tmpStr.ToUpper.Contains("LEZDOM") Then
					tmpImageLocationList.AddRange(GetImageData(ImageGenre.Lezdom).ToList(ImageSourceType.Local))
				ElseIf tmpStr.ToUpper.Contains("HENTAI") Then
					tmpImageLocationList.AddRange(GetImageData(ImageGenre.Hentai).ToList(ImageSourceType.Local))
				ElseIf tmpStr.ToUpper.Contains("GAY") Then
					tmpImageLocationList.AddRange(GetImageData(ImageGenre.Gay).ToList(ImageSourceType.Local))
				ElseIf tmpStr.ToUpper.Contains("MALEDOM") Then
					tmpImageLocationList.AddRange(GetImageData(ImageGenre.Maledom).ToList(ImageSourceType.Local))
				ElseIf tmpStr.ToUpper.Contains("CAPTION") Then
					tmpImageLocationList.AddRange(GetImageData(ImageGenre.Captions).ToList(ImageSourceType.Local))
				ElseIf tmpStr.ToUpper.Contains("GENERAL") Then
					tmpImageLocationList.AddRange(GetImageData(ImageGenre.General).ToList(ImageSourceType.Local))
				ElseIf tmpStr.ToUpper.Contains("BUTT") Or tmpStr.ToUpper.Contains("BUTTS") Then
					tmpImageLocationList.AddRange(GetImageData(ImageGenre.Butt).ToList(ImageSourceType.Local))
				ElseIf tmpStr.ToUpper.Contains("BOOB") Or tmpStr.ToUpper.Contains("BOOBS") Then
					tmpImageLocationList.AddRange(GetImageData(ImageGenre.Boobs).ToList(ImageSourceType.Local))
				End If
			Next
			' Declare a string for the Image to show - initialize with error Image
			Dim tmpImgToShow As String = Application.StartupPath & "\Images\System\NoLocalImagesFound.jpg"
			' If there are images, overwrite the error image.
			If tmpImageLocationList.Count > 0 Then
				tmpImgToShow = tmpImageLocationList(New Random().Next(0, tmpImageLocationList.Count))
			Else
				Log.Write("No images found For Command: @ShowLocalImage(" & LocalFlag & ")")
			End If

			ShowImage(tmpImgToShow, False)

			StringClean = StringClean.Replace("@ShowLocalImage(" & GetParentheses(StringClean, "@ShowLocalImage(") & ")", "")
		End If
		'----------------------------------------
		' @ShowLocalImage()- End
		'----------------------------------------
		'===============================================================================
		'								@ShowTaggedImage
		'===============================================================================
		If StringClean.Contains("@ShowTaggedImage") Then
			'TODO-Next: @ShowTaggedImage: Implement ShowImage(String, Boolean) and myDirectory.GetFilesImages(String). Remove references to Variable FoundString.
			'Debug.Print("ShowTaggedImage StringClean ^^^^^^^^^^^^^^^^^^^^^^ = " & StringClean)

			Dim FoundString As String

			'TODO: remove unsecure IO.Access to file, for there is no DirectoryCheck.
			If File.Exists(Application.StartupPath & "\Images\System\LocalImageTags.txt") Then
				' Read all lines of the given file.
				ssh_LocalTagImageList = Txt2List(Application.StartupPath & "\Images\System\LocalImageTags.txt")

				For i As Integer = ssh_LocalTagImageList.Count - 1 To 0 Step -1
					Dim LocalCheck As String() = Split(ssh_LocalTagImageList(i))
					Dim LocalString As String = LocalCheck(0)
					Debug.Print("LocalString = " & LocalString)
					If Not LCase(LocalString).Contains(".jpg") And Not LCase(LocalString).Contains(".jpeg") And Not LCase(LocalString).Contains(".bmp") And
					 Not LCase(LocalString).Contains(".png") And Not LCase(LocalString).Contains(".gif") Then
						Debug.Print("LocalTag Check Doesn't contain extension")
						For x As Integer = 1 To LocalCheck.Count - 1
							LocalString = LocalString & " " & LocalCheck(x)
							If LCase(LocalString).Contains(".jpg") Or LCase(LocalString).Contains(".jpeg") Or LCase(LocalString).Contains(".bmp") Or
							LCase(LocalString).Contains(".png") Or LCase(LocalString).Contains(".gif") Then Exit For
						Next
					End If
					Debug.Print("Local Tag check - " & LocalString)
					If Not File.Exists(LocalString) Then ssh_LocalTagImageList.Remove(ssh_LocalTagImageList(i))
				Next
			End If


			If StringClean.Contains("@Tag") Then
				Dim TSplit As String() = Split(StringClean)
				For i As Integer = 0 To TSplit.Length - 1
					If TSplit(i).Contains("@Tag") Then
						Dim TString As String = TSplit(i).Replace("@Tag", "")
						For j As Integer = ssh_LocalTagImageList.Count - 1 To 0 Step -1
							If Not ssh_LocalTagImageList(j).Contains(TString) Then ssh_LocalTagImageList.RemoveAt(j)
						Next
					End If
				Next
			End If

			For i As Integer = 0 To ssh_LocalTagImageList.Count - 1
				'Debug.Print(i & ". " & LocalTagImageList(i))
			Next


			If ssh_LocalTagImageList.Count = 0 Then
				FoundString = Application.StartupPath & "\Images\System\NoLocalImagesFound.jpg"
			Else
				Dim TagSplit As String() = Split(ssh_LocalTagImageList(ssh_randomizer.Next(0, ssh_LocalTagImageList.Count)))
				FoundString = TagSplit(0) & " "

				If Not LCase(FoundString).Contains(".jpg ") Or Not LCase(FoundString).Contains(".jpeg ") Or Not LCase(FoundString).Contains(".png ") Or Not LCase(FoundString).Contains(".bmp ") Or Not LCase(FoundString).Contains(".gif ") Then
					Dim FSLoop As Integer = 1
					Do Until LCase(FoundString).Contains(".jpg ") Or LCase(FoundString).Contains(".jpeg ") Or LCase(FoundString).Contains(".png ") Or LCase(FoundString).Contains(".bmp ") Or LCase(FoundString).Contains(".gif ")
						FoundString = FoundString & TagSplit(FSLoop) & " "
						FSLoop += 1
					Loop
				End If
			End If

			ssh_JustShowedBlogImage = True

			ShowImage(FoundString, False)

			StringClean = StringClean.Replace("@ShowTaggedImage", "")
		End If
		'----------------------------------------
		' @ShowTaggedImage - End
		'----------------------------------------
		'===============================================================================
		'									@ShowImage[]
		'===============================================================================
		If StringClean.Contains("@ShowImage[") Then
			Dim ImageToShow As String = GetParentheses(StringClean, "@ShowImage[")
			Try
				Dim tmpImgLoc As String = ""

				If isURL(ImageToShow) Then
					'########################## ImageURL was given #########################
					tmpImgLoc = ImageToShow
					GoTo ShowedBlogImage
				End If

				' Change evtl. wrong given Slashes
				ImageToShow = ImageToShow.Replace("/", "\")

				ImageToShow = Application.StartupPath & "\Images\" & ImageToShow
				ImageToShow = ImageToShow.Replace("\\", "\")

				If ImageToShow.Contains("*") Then
					'######################### Directory was given #########################
					Dim tmpFilter As String = Path.GetFileName(ImageToShow)
					Dim tmpDir As String = Path.GetDirectoryName(ImageToShow)
					Dim ImageList As List(Of String)

					If Directory.Exists(tmpDir) = False Then
						Throw New Exception(
						 "The given directory """ & tmpDir & """ does not exist." &
						 vbCrLf & vbCrLf &
						 "Please make sure the directory exists and it is spelled correctly in the script.")
					End If

					If tmpFilter = "*" Then
						ImageList = myDirectory.GetFilesImages(tmpDir)
					Else
						ImageList = Directory.GetFiles(tmpDir, tmpFilter, SearchOption.TopDirectoryOnly).ToList
					End If

					If ImageList.Count = 0 Then
						Throw New FileNotFoundException(
						 "No images matching the filter """ & tmpFilter &
						 """ were found in """ & tmpDir & """!" &
						 vbCrLf & vbCrLf &
						 "Please make sure that valid files exist and the wildcards are applied correctly in the script.")
					End If

					tmpImgLoc = ImageList(New Random().Next(0, ImageList.Count))
				Else
					'############################# Single Image ############################
					If File.Exists(ImageToShow) Then
						tmpImgLoc = ImageToShow
					Else
						Throw New Exception(
						 """" & Path.GetFileName(ImageToShow) & """ was not found in """ & Path.GetDirectoryName(ImageToShow) & """!" &
						 vbCrLf & vbCrLf &
						 "Please make sure the file exists and it is spelled correctly in the script.")
					End If
				End If
				'############### Display the Image ##################
ShowedBlogImage:
				ShowImage(tmpImgLoc, False)
			Catch ex As Exception
				'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
				'                   All Errors
				'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
				Log.WriteError("Command @ShowImage[] was unable to display the image.",
				   ex, "Error at @ShowImage[]")
				MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error at @ShowImage[]")
			End Try
			StringClean = StringClean.Replace("@ShowImage[" & GetParentheses(StringClean, "@ShowImage[") & "]", "")
		End If
		'----------------------------------------
		' @ShowImage[]- End
		'----------------------------------------
		'===============================================================================
		'								Legacy TnA-Slideshow
		'===============================================================================
		' @TnAFastSlides starts a fast slideshow with Boobs and Butts. Use with local images, to avoid the download delay. otherwise the images will stutter.
		' @TnASlides starts a slideshow with boobs and butts. the Speed is fixed at 1 image per second.
		' @TnASlowSlides starts a slideshow with boobs and butts. the Speed is fixed at 1 image per 5 seconds.

		If StringClean.Contains("@TnAFastSlides") Or StringClean.Contains("@TnASlowSlides") Or StringClean.Contains("@TnASlides") Then
			If StringClean.Contains("@TnAFastSlides") Then TnASlides.Interval = 334
			If StringClean.Contains("@TnASlides") Then TnASlides.Interval = 1000
			If StringClean.Contains("@TnASlowSlides") Then TnASlides.Interval = 5000

			Try
				ssh_BoobList.Clear()
				ssh_AssList.Clear()

				If ssh_BoobList.Count < 1 Then ssh_BoobList = GetImageData(ImageGenre.Boobs).ToList
				If ssh_AssList.Count < 1 Then ssh_AssList = GetImageData(ImageGenre.Butt).ToList

				If ssh_BoobList.Count < 1 Then Throw New Exception("No Boobs-images found.")
				If ssh_AssList.Count < 1 Then Throw New Exception("No Butt-images found.")

				TnASlides.Start()
			Catch ex As Exception
				Log.WriteError("Unable to start TnA Slideshow: " & vbCrLf &
					  ex.Message, ex, "CommandClean()")
			End Try

			StringClean = StringClean.Replace("@TnAFastSlides", "")
			StringClean = StringClean.Replace("@TnASlowSlides", "")
			StringClean = StringClean.Replace("@TnASlides", "")
		End If

		If StringClean.Contains("@CheckTnA") Then
			TnASlides.Stop()

			'Debug.Print("@CheckTnA called ::: AssImage = " & AssImage & " ::: BoobImage = " & BoobImage)
			If ssh_AssImage = True Then ssh_FileGoto = "(Butt)"
			If ssh_BoobImage = True Then ssh_FileGoto = "(Boobs)"
			ssh_SkipGotoLine = True
			GetGoto()
			StringClean = StringClean.Replace("@CheckTnA", "")
		End If

		If StringClean.Contains("@StopTnA") Then
			TnASlides.Stop()
			ssh_BoobList.Clear()
			ssh_BoobImage = False
			ssh_AssList.Clear()
			ssh_AssImage = False
			StringClean = StringClean.Replace("@StopTnA", "")
		End If
		'----------------------------------------
		' TnA-Slideshow - End
		'----------------------------------------
		'===============================================================================
		'								Slideshow
		'===============================================================================
		If StringClean.Contains("@Slideshow(") Then
			Dim SlideFlag As String = StringClean

			Dim SlideStart As Integer

			SlideStart = SlideFlag.IndexOf("@Slideshow(") + 11
			SlideFlag = SlideFlag.Substring(SlideStart, SlideFlag.Length - SlideStart)
			SlideFlag = SlideFlag.Split(")")(0)
			SlideFlag = SlideFlag.Replace("@Slideshow(", "")

			ssh_CustomSlideshowList.Clear()

			If SlideFlag.ToLower.Contains("hardcore") Then
				ssh_CustomSlideshowList.AddRange(GetImageData(ImageGenre.Hardcore).ToList())
			End If

			If SlideFlag.ToLower.Contains("softcore") Then
				ssh_CustomSlideshowList.AddRange(GetImageData(ImageGenre.Softcore).ToList())
			End If

			If SlideFlag.ToLower.Contains("lesbian") Then
				ssh_CustomSlideshowList.AddRange(GetImageData(ImageGenre.Lesbian).ToList())
			End If

			If SlideFlag.ToLower.Contains("blowjob") Then
				ssh_CustomSlideshowList.AddRange(GetImageData(ImageGenre.Blowjob).ToList())
			End If

			If SlideFlag.ToLower.Contains("femdom") Then
				ssh_CustomSlideshowList.AddRange(GetImageData(ImageGenre.Femdom).ToList())
			End If

			If SlideFlag.ToLower.Contains("lezdom") Then
				ssh_CustomSlideshowList.AddRange(GetImageData(ImageGenre.Lezdom).ToList())
			End If

			If SlideFlag.ToLower.Contains("hentai") Then
				ssh_CustomSlideshowList.AddRange(GetImageData(ImageGenre.Hentai).ToList())
			End If

			If SlideFlag.ToLower.Contains("gay") Then
				ssh_CustomSlideshowList.AddRange(GetImageData(ImageGenre.Gay).ToList())
			End If

			If SlideFlag.ToLower.Contains("maledom") Then
				ssh_CustomSlideshowList.AddRange(GetImageData(ImageGenre.Maledom).ToList())
			End If

			If SlideFlag.ToLower.Contains("captions") Then
				ssh_CustomSlideshowList.AddRange(GetImageData(ImageGenre.Captions).ToList())
			End If

			If SlideFlag.ToLower.Contains("general") Then
				ssh_CustomSlideshowList.AddRange(GetImageData(ImageGenre.General).ToList())
			End If

			If SlideFlag.ToLower.Contains("boob") Or LCase(SlideFlag).Contains("boobs") Then
				ssh_CustomSlideshowList.AddRange(GetImageData(ImageGenre.Boobs).ToList())
			End If

			If SlideFlag.ToLower.Contains("butt") Or LCase(SlideFlag).Contains("butts") Then
				ssh_CustomSlideshowList.AddRange(GetImageData(ImageGenre.Butt).ToList())
			End If


			CustomSlideshowTimer.Interval = 1000
			If LCase(SlideFlag).Contains("slow") Then CustomSlideshowTimer.Interval = 5000
			If LCase(SlideFlag).Contains("fast") Then CustomSlideshowTimer.Interval = 500


			StringClean = StringClean.Replace("@Slideshow(" & SlideFlag & ")", "")
		End If

		If StringClean.Contains("@SlideshowOn") Then
			If ssh_CustomSlideshowList.Count > 0 Then
				ssh_CustomSlideshow = True
				CustomSlideshowTimer.Start()
			End If
			StringClean = StringClean.Replace("@SlideshowOn", "")
		End If

		If StringClean.Contains("@SlideshowOff") Then
			ssh_CustomSlideshow = False
			CustomSlideshowTimer.Stop()
			StringClean = StringClean.Replace("@SlideshowOff", "")
		End If

		If StringClean.Contains("@SlideshowFirst") Then
			ssh_SlideshowInt = 0
			ssh_CustomSlideshow = True
			ShowImage(ssh_CustomSlideshowList(ssh_SlideshowInt), False)
			StringClean = StringClean.Replace("@SlideshowFirst", "")
		End If

		If StringClean.Contains("@SlideshowLast") Then
			ssh_SlideshowInt = ssh_CustomSlideshowList.Count - 1
			ssh_CustomSlideshow = True
			ShowImage(ssh_CustomSlideshowList(ssh_SlideshowInt), False)
			StringClean = StringClean.Replace("@SlideshowLast", "")
		End If

		If StringClean.Contains("@SlideshowNext") Then
			ssh_SlideshowInt += 1
			If ssh_SlideshowInt > ssh_CustomSlideshowList.Count - 1 Then ssh_SlideshowInt = ssh_CustomSlideshowList.Count - 1
			ssh_CustomSlideshow = True
			ShowImage(ssh_CustomSlideshowList(ssh_SlideshowInt), False)
			StringClean = StringClean.Replace("@SlideshowNext", "")
		End If

		If StringClean.Contains("@SlideshowPrevious") Then
			ssh_SlideshowInt -= 1
			If ssh_SlideshowInt < 0 Then ssh_SlideshowInt = 0
			ssh_CustomSlideshow = True
			ShowImage(ssh_CustomSlideshowList(ssh_SlideshowInt), False)
			StringClean = StringClean.Replace("@SlideshowPrevious", "")
		End If

		If StringClean.Contains("@GotoSlideshow") Then
			'BUG: @GotoCustomSlideshow is not working. There is no reference what imagegenre a image belongs to.
			If ssh_ImageString.Contains(My.Settings.IHardcore) Then ssh_FileGoto = "(Hardcore)"
			If ssh_ImageString.Contains(My.Settings.ISoftcore) Then ssh_FileGoto = "(Softcore)"
			If ssh_ImageString.Contains(My.Settings.ILesbian) Then ssh_FileGoto = "(Lesbian)"
			If ssh_ImageString.Contains(My.Settings.IBlowjob) Then ssh_FileGoto = "(Blowjob)"
			If ssh_ImageString.Contains(My.Settings.IFemdom) Then ssh_FileGoto = "(Femdom)"
			If ssh_ImageString.Contains(My.Settings.ILezdom) Then ssh_FileGoto = "(Lezdom)"
			If ssh_ImageString.Contains(My.Settings.IHentai) Then ssh_FileGoto = "(Hentai)"
			If ssh_ImageString.Contains(My.Settings.IGay) Then ssh_FileGoto = "(Gay)"
			If ssh_ImageString.Contains(My.Settings.IMaledom) Then ssh_FileGoto = "(Maledom)"
			If ssh_ImageString.Contains(My.Settings.ICaptions) Then ssh_FileGoto = "(Captions)"
			If ssh_ImageString.Contains(My.Settings.IGeneral) Then ssh_FileGoto = "(General)"
			If ssh_ImageString.Contains(My.Settings.LBLBoobPath) Then ssh_FileGoto = "(Boobs)"
			If ssh_ImageString.Contains(My.Settings.LBLButtPath) Then ssh_FileGoto = "(Butts)"

			Debug.Print("GotoSlideshow called, FileGoto = " & ssh_FileGoto)

			ssh_SkipGotoLine = True
			GetGoto()

			StringClean = StringClean.Replace("@GotoSlideshow", "")
		End If
		'----------------------------------------
		' Slideshow - End
		'----------------------------------------
		' This Command will not work in the same line, because the Images are loaded async and not available yet.
		If StringClean.Contains("@CurrentImage") Then StringClean = StringClean.Replace("@CurrentImage", ssh_ImageLocation)

		' The @LockImages Commnd prevents the Domme Slideshow from moving forward or back when set to "Tease" or "Timed". Manual operation of Domme Slideshow images is still allowed,
		' and pictures displayed through other means will still work. Images are automatically unlocked whenever Tease AI moves into a Link script, an End script, any Interrupt occurs
		' (including Long Edge and Start Stroking) or when the sub gives up.

		If StringClean.Contains("@LockImages") Then
			ssh_LockImage = True
			nextButton.Enabled = False
			previousButton.Enabled = False
			PicStripTSMIdommeSlideshow.Enabled = False
			StringClean = StringClean.Replace("@LockImages", "")
		End If
		'▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲
		'			ImageCommands - End
		'▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲

		' The @Chance Command gives a chance to either jump to the line specified, or move to the next line as normal. The odds of jumping to the specified line are indicated in the Command
		' itself. For example, @Chance50(Domme Instructions) would have a 50% chance of jumping to (Domme Instructions).

		If StringClean.Contains("@Chance") Then

			Dim ChanceTemp As String
			Dim TSStartIndex As Integer
			Dim TSEndIndex As Integer

			TSStartIndex = StringClean.IndexOf("@Chance") + 7
			TSEndIndex = StringClean.IndexOf("@Chance") + 9

			ChanceTemp = StringClean.Substring(TSStartIndex, TSEndIndex - TSStartIndex).Trim

			Dim ChanceVal As Integer

			ChanceVal = Val(ChanceTemp)

			ssh_TempVal = ssh_randomizer.Next(1, 101)

			Dim ChanceString As String = StringClean.Substring(TSStartIndex + 2, StringClean.Length - (TSStartIndex + 2)).Trim

			Dim ChanceSplit As String() = Split(ChanceString, ")")


			Debug.Print("CHanceCheck = " & "@Chance" & ChanceVal & ChanceSplit(0) & ")")
			StringClean = StringClean.Replace("@Chance" & ChanceVal & ChanceSplit(0) & ")", "")

			If ssh_TempVal <= ChanceVal Then

				ssh_FileGoto = ChanceSplit(0) & ")"
				ssh_SkipGotoLine = True

				If ssh_YesOrNo = True Then
					GetGotoChat()
				Else
					GetGoto()
				End If

			End If

		End If

		' The @CheckFlag() Command checks to see if a Flag has previously been created by @SetFlag or @TempFlag, and goes to the appropriate line if it has. If you use @CheckFlag() with just the name of
		' the flag itself, such as @CheckFlag(FlagName) , then Tease AI will move to the line (FlagName) if that Flag exists. However, you can also specify a line to go to if that Flag is found by using
		' a comma, such as @CheckFlag(FlagName, Domme Instructions) . In this case, Tease AI would move to the line (Domme Instructions) if the Flag "FlagName" exists. You can use as many @CheckFlag()
		' Commands per line that you wish. When specifiying a line to go to in a @CheckFlag Command, never put it in its own parentheses (For example, @CheckFlag(FlagName, Domme Instructions) is correct,
		' @CheckFlag(FlagName, (Domme Instructions)) is incorrect. 

		If StringClean.Contains("@CheckFlag") Then

			Dim CheckArray As String() = StringClean.Split(")")

			For i As Integer = 0 To CheckArray.Count - 1

				If CheckArray(i).Contains("@CheckFlag(") Then

					CheckArray(i) = CheckArray(i) & ")"

					Dim CheckFlag As String = GetParentheses(CheckArray(i), "@CheckFlag(")
					Dim OriginalCheck As String = CheckFlag

					If CheckFlag.Contains(",") Then

						CheckFlag = CheckFlag.Replace(", ", ",")
						CheckFlag = CheckFlag.Replace(" ,", ",")

						Dim FlagArray() As String = CheckFlag.Split(",")

						If File.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Flags\" & FlagArray(0)) Or
						  File.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Flags\Temp\" & FlagArray(0)) Then
							ssh_SkipGotoLine = True
							ssh_FileGoto = FlagArray(1)
							GetGoto()
						End If

					Else

						If File.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Flags\" & CheckFlag) Or
						 File.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Flags\Temp\" & CheckFlag) Then
							ssh_SkipGotoLine = True
							ssh_FileGoto = CheckFlag
							GetGoto()
						End If

					End If

					' CHECK FOR OTHER POSSIBLE CHECKARRAY BUGS
					'CheckArray(i) = CheckArray(i).Replace("@CheckFlag(" & OriginalCheck & ")", "")

					StringClean = StringClean.Replace("@CheckFlag(" & OriginalCheck & ")", "")

				End If

			Next

			' StringClean = Join(CheckArray, Nothing)

		End If


TaskCleanSet:


		' The @SetFlag() Command creates a Flag in System\Flags. You can use multiple @SetFlag() Commands in the same line to set multiple flags at once (For example, @SetFlag(Flag1) @SetFlag(Flag2)).
		' You can also set multiple flags at once by separating them in single @SetFlag() Commands with a comma (For example, @SetFlag(Flag1, Flag2, Flag3)).

		If StringClean.Contains("@SetFlag(") Then

			Dim SetArray As String() = StringClean.Split(")")

			For i As Integer = 0 To SetArray.Count - 1

				If SetArray(i).Contains("@SetFlag(") Then

					SetArray(i) = SetArray(i) & ")"

					Dim SetFlag As String = GetParentheses(SetArray(i), "@SetFlag(")
					Dim OriginalSet As String = SetFlag

					If SetFlag.Contains(",") Then

						SetFlag = SetFlag.Replace(", ", ",")
						SetFlag = SetFlag.Replace(" ,", ",")

						Dim FlagArray() As String = SetFlag.Split(",")

						For x As Integer = 0 To FlagArray.Count - 1

							CreateFlag(FlagArray(x))

						Next

					Else

						CreateFlag(SetFlag)

					End If

					'SetArray(i) = SetArray(i).Replace("@SetFlag(" & OriginalSet & ")", "")

					StringClean = StringClean.Replace("@SetFlag(" & OriginalSet & ")", "")

				End If

			Next

			'StringClean = Join(SetArray, Nothing)

		End If

		' The @TempFlag() Command creates a Flag in System\Flags\Temp. These work like @SetFlag() Commands, the only difference is that Flags set this way are deleted the next time Tease AI is run.
		' You can use multiple @TempFlag() Commands in the same line to set multiple flags at once (For example, @TempFlag(Flag1) @TempFlag(Flag2)).
		' You can also set multiple flags at once by separating them in single @TempFlag() Commands with a comma (For example, @TempFlag(Flag1, Flag2, Flag3)).

		If StringClean.Contains("@TempFlag(") Then

			Dim TempArray As String() = StringClean.Split(")")

			For i As Integer = 0 To TempArray.Count - 1

				If TempArray(i).Contains("@TempFlag(") Then

					TempArray(i) = TempArray(i) & ")"

					Dim TempFlag As String = GetParentheses(TempArray(i), "@TempFlag(")
					Dim OriginalTemp As String = TempFlag

					If TempFlag.Contains(",") Then

						TempFlag = TempFlag.Replace(", ", ",")
						TempFlag = TempFlag.Replace(" ,", ",")

						Dim FlagArray() As String = TempFlag.Split(",")

						For x As Integer = 0 To FlagArray.Count - 1

							CreateFlag(FlagArray(x), True)

						Next

					Else

						CreateFlag(TempFlag, True)

					End If

					'TempArray(i) = TempArray(i).Replace("@TempFlag(" & OriginalTemp & ")", "")

					StringClean = StringClean.Replace("@TempFlag(" & OriginalTemp & ")", "")

				End If

			Next

			'StringClean = Join(TempArray, Nothing)

		End If

		' The @DeleteFlag() Command deletes specified Flags in System\Flags and System\Flags\Temp.
		' You can use multiple @DeleteFlag() Commands in the same line to delete multiple flags at once (For example, @DeleteFlag(Flag1) @DeleteFlag(Flag2)).
		' You can also delete multiple flags at once by separating them in single @DeleteFlag() Commands with a comma (For example, @DeleteFlag(Flag1, Flag2, Flag3)).


		If StringClean.Contains("@DeleteFlag(") Then

			Dim DeleteArray As String() = StringClean.Split(")")

			For i As Integer = 0 To DeleteArray.Count - 1

				If DeleteArray(i).Contains("@DeleteFlag(") Then

					DeleteArray(i) = DeleteArray(i) & ")"

					Dim DFlag As String = GetParentheses(DeleteArray(i), "@DeleteFlag(")
					Dim OriginalDelete As String = DFlag

					If DFlag.Contains(",") Then

						DFlag = FixCommas(DFlag)

						Dim FlagArray() As String = DFlag.Split(",")

						For x As Integer = 0 To FlagArray.Count - 1

							DeleteFlag(FlagArray(x))

						Next

					Else

						DeleteFlag(DFlag)

					End If

					' DeleteArray(i) = DeleteArray(i).Replace("@DeleteFlag(" & OriginalDelete & ")", "")

					StringClean = StringClean.Replace("@DeleteFlag(" & OriginalDelete & ")", "")

				End If

			Next

			'StringClean = Join(DeleteArray, Nothing)

		End If

		' The @SetVar[] Command is used to set a Variable and store it in System\Variables. The syntax for using @SetVar[] is @SetVar[VariableName]=[Value].
		' For example, @SetVar[MyNumber]=[12] would save the Variable "MyNumber" as a value of 12. You can also set string Variables this way, such as @SetVar[MyString]=[lasagna]
		' Multiple @SetVar[] Commands may be used per line if you wish.
		' Variable names CANNOT contain spaces or any character not supported by Windows file naming conventions \ / : * ? " < > |

		If StringClean.Contains("@SetVar[") Then

			Dim VarArray As String() = StringClean.Split

			For i As Integer = 0 To VarArray.Count - 1

				Dim SCGotVar As String = "NULL"

				If VarArray(i).Contains("@SetVar[") Then
					SCGotVar = VarArray(i)
					VarArray(i) = ""

					SCGotVar = SCGotVar.Replace("@SetVar[", "")

					Dim SCGotVarSplit As String() = Split(SCGotVar, "]")

					Dim VarName As String = SCGotVarSplit(0)

					SCGotVarSplit(0) = ""

					SCGotVar = Join(SCGotVarSplit)

					SCGotVar = SCGotVar.Replace("=[", "")
					SCGotVar = SCGotVar.Replace(" ", "")

					My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Variables\" & VarName, SCGotVar, False)

				End If

			Next

			StringClean = Join(VarArray)

		End If

		' The @SetDate() Command allows you to set a time and date that's a specified amount of time in the future from the current time and date. Correct format is @SetDate(VarName, TimeAmount) .
		' For example, @SetDate(EdgingStop, 1 Hour) would set a Variable called "EdgingStop" whose value is 1 hour away from the current time and date. As another example, @SetDate(NextOrgasmChance, 2 Weeks)
		' would create a Variable called "NextOrgasmChance" whose value is 2 weeks from the current date.
		' The available time increments are - Seconds, Minutes, Hours, Days, Weeks, Months and Years. When designating an amount of time, capitalization and pluralization do not matter. If no increment is
		' specified, "Days" will be used.

		If StringClean.Contains("@SetDate(") Then

			Dim CheckArray As String() = StringClean.Split(")")
			Dim OriginalCheck As String

			For i As Integer = 0 To CheckArray.Count - 1

				If CheckArray(i).Contains("@SetDate(") Then

					'CheckArray(i) = CheckArray(i) & "]"

					Dim CheckFlag As String = GetParentheses(CheckArray(i), "@SetDate(")
					OriginalCheck = CheckFlag

					Debug.Print("Original Check = " & OriginalCheck)

					CheckFlag = CheckFlag.Replace(", ", ",")
					CheckFlag = CheckFlag.Replace(" ,", ",")

					Dim FlagArray() As String = CheckFlag.Split(",")

					Dim SetDate As Date = FormatDateTime(Now, DateFormat.GeneralDate)

					If UCase(FlagArray(1)).Contains(UCase("SECOND")) Then SetDate = DateAdd(DateInterval.Second, Val(FlagArray(1)), SetDate)
					If UCase(FlagArray(1)).Contains(UCase("MINUTE")) Then SetDate = DateAdd(DateInterval.Minute, Val(FlagArray(1)), SetDate)
					If UCase(FlagArray(1)).Contains(UCase("HOUR")) Then SetDate = DateAdd(DateInterval.Hour, Val(FlagArray(1)), SetDate)
					If UCase(FlagArray(1)).Contains(UCase("DAY")) Then SetDate = DateAdd(DateInterval.Day, Val(FlagArray(1)), SetDate)
					If UCase(FlagArray(1)).Contains(UCase("WEEK")) Then SetDate = DateAdd(DateInterval.Day, Val(FlagArray(1)) * 7, SetDate)
					If UCase(FlagArray(1)).Contains(UCase("MONTH")) Then SetDate = DateAdd(DateInterval.Month, Val(FlagArray(1)), SetDate)
					If UCase(FlagArray(1)).Contains(UCase("YEAR")) Then SetDate = DateAdd(DateInterval.Year, Val(FlagArray(1)), SetDate)

					If Not UCase(FlagArray(1)).Contains(UCase("SECOND")) And Not UCase(FlagArray(1)).Contains(UCase("MINUTE")) And Not UCase(FlagArray(1)).Contains(UCase("HOUR")) _
					 And Not UCase(FlagArray(1)).Contains(UCase("DAY")) And Not UCase(FlagArray(1)).Contains(UCase("WEEK")) And Not UCase(FlagArray(1)).Contains(UCase("MONTH")) _
					 And Not UCase(FlagArray(1)).Contains(UCase("YEAR")) Then SetDate = DateAdd(DateInterval.Day, Val(FlagArray(1)), SetDate)

					My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Variables\" & FlagArray(0), FormatDateTime(SetDate, DateFormat.GeneralDate), False)

					Debug.Print("CheckArray(i) = " & CheckArray(i))

					' CheckArray(i) = CheckArray(i).Replace("@SetDate(" & OriginalCheck, "")

					StringClean = StringClean.Replace("@SetDate(" & OriginalCheck & ")", "")

				End If

			Next

			'StringClean = Join(CheckArray, Nothing)

		End If


		' The @RoundVar Command is used to take an existing Variable and round it by the amount specified. The correct format is @Round[VarName]=[RoundAmount]
		' For example, @RoundVar[StrokeTotal]=[10] wound round the Variable "StrokeTotal" by 10.
		' @Round[] will only round the and save Variable, it will not display it. More than one @Round[] Command can be used per line


		If StringClean.Contains("@RoundVar[") Then

			Dim VarArray As String() = StringClean.Split

			For i As Integer = 0 To VarArray.Count - 1

				Dim SCGotVar As String = "NULL"

				If VarArray(i).Contains("@RoundVar[") Then
					SCGotVar = VarArray(i)
					VarArray(i) = ""
				End If

				SCGotVar = SCGotVar.Replace("@RoundVar[", "")

				Dim SCGotVarSplit As String() = Split(SCGotVar, "]")

				Dim VarName As String = SCGotVarSplit(0)
				Dim Val1 As Integer

				Dim VarCheck As String = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Variables\" & VarName


				'TODO: Remove unsecure IO.Access to file, for there is no DirectoryCheck.
				If File.Exists(VarCheck) Then
					' Read first line of the given file.
					Val1 = CInt(TxtReadLine(VarCheck))

					SCGotVarSplit(0) = ""

					SCGotVar = Join(SCGotVarSplit)

					SCGotVar = SCGotVar.Replace("=[", "")
					SCGotVar = SCGotVar.Replace(" ", "")

					Dim VarValue As Integer = Val(SCGotVar)

					Val1 = VarValue * Math.Round(Val1 / VarValue)

					My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Variables\" & VarName, Val1, False)

				End If

				' StringClean = StringClean.Replace("@RoundVar[" & OriginalCheck & ")", "")

			Next

			StringClean = Join(VarArray)

		End If

		' The @ChangeVar[] Command is used to Value of a new or existing Variable and round it by the amount specified. The correct format is @ChangeVar[VarName]=[Value1]+[Value2]
		' For example, @ChangeVar[StrokeTotal]=[StrokeTotal]+[100] would add 100 to the current value of "StrokeTotal" and save it. If "StrokeTotal" did not previously exist, then it would be created
		' with a value of 100 in this case, since nothing + 100 equals 100. You can use @ChangeVar[] to add, subtract, multiply or divide with the operators +, -, * and /
		'More than one @ChangeVar[] Command can be used per line.

		If StringClean.Contains("@ChangeVar[") Then

			Dim ChangeArray As String() = StringClean.Split

			For i As Integer = 0 To ChangeArray.Count - 1

				Debug.Print("CHangeVar ChangeArray(i) = " & ChangeArray(i))

				If ChangeArray(i).Contains("@ChangeVar[") Then

					Dim ChangeFlag As String = ChangeArray(i)
					Dim ChangeStart As Integer = ChangeFlag.IndexOf("@ChangeVar[") + 11

					Dim ChangeVar As String
					Dim ChangeVal1 As String
					Dim ChangeVal2 As String
					Dim ChangeOperator As String

					Dim Val1 As Integer
					Dim Val2 As Integer

					ChangeFlag = ChangeArray(i).Substring(ChangeStart, ChangeArray(i).Length - ChangeStart)
					ChangeVar = ChangeFlag.Split("]")(0)
					ChangeVal1 = ChangeFlag.Split("]")(1)
					ChangeVal2 = ChangeFlag.Split("]")(2)
					ChangeOperator = ChangeFlag.Split("]")(2)

					ChangeArray(i) = ChangeArray(i).Replace("@ChangeVar[" & ChangeVar & "]" & ChangeVal1 & "]" & ChangeVal2 & "]", "")

					ChangeVar = ChangeVar.Replace("@ChangeVar[", "")
					ChangeVal1 = ChangeVal1.Replace("=[", "")
					ChangeVal2 = ChangeVal2.Replace("+[", "")
					ChangeVal2 = ChangeVal2.Replace("-[", "")
					ChangeVal2 = ChangeVal2.Replace("*[", "")
					ChangeVal2 = ChangeVal2.Replace("/[", "")

					'@ChangeVar[TB_EdgeHoldingOwed   ]    =[TB_EdgeHoldingOwed    ]     -[1       ]

					If IsNumeric(ChangeVal1) = False Then
						'TODO: Remove unsecure IO.Access to file, for there is no DirectoryCheck.
						If File.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Variables\" & ChangeVal1) Then
							Val1 = TxtReadLine(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Variables\" & ChangeVal1)
						Else
							Val1 = 0
						End If
					Else
						Val1 = Val(ChangeVal1)
					End If

					If IsNumeric(ChangeVal2) = False Then
						'TODO: Remove unsecure IO.Access To file, for there is no DirectoryCheck.
						If File.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Variables\" & ChangeVal2) Then
							Val2 = TxtReadLine(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Variables\" & ChangeVal2)
						Else
							Val2 = 0
						End If
					Else
						Val2 = Val(ChangeVal2)
					End If

					ssh_ScriptOperator = "Null"
					If ChangeOperator.Contains("+") Then ssh_ScriptOperator = "Add"
					If ChangeOperator.Contains("-") Then ssh_ScriptOperator = "Subtract"
					If ChangeOperator.Contains("*") Then ssh_ScriptOperator = "Multiply"
					If ChangeOperator.Contains("/") Then ssh_ScriptOperator = "Divide"

					Dim ChangeVal As Integer = 0

					If ssh_ScriptOperator = "Add" Then ChangeVal = Val1 + Val2
					If ssh_ScriptOperator = "Subtract" Then ChangeVal = Val1 - Val2
					If ssh_ScriptOperator = "Multiply" Then ChangeVal = Val1 * Val2
					If ssh_ScriptOperator = "Divide" Then ChangeVal = Val1 / Val2

					My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Variables\" & ChangeVar, ChangeVal, False)

				End If

			Next

		End If

		' The @ShowVar[] Command is used to show the value of an existing Variable. The correct format is @ShowVar[VarName]
		' More than one @ShowVar[] Commands can be used per line

		If StringClean.Contains("@ShowVar[") Then

			Dim VarSplit As String() = StringClean.Split("]")

			For i As Integer = 0 To VarSplit.Count - 1

				If VarSplit(i).Contains("@ShowVar[") Then

					Dim VarString As String = VarSplit(i) & "]"

					Dim VarFlag As String = GetParentheses(VarString, "@ShowVar[")
					Debug.Print("VarFlag = " & VarFlag)
					Dim VarFlag2 As String = GetVariable(VarFlag)
					Debug.Print("VarFlag2 = " & VarFlag2)
					' StringClean = StringClean.Replace("#Var[" & VarFlag & "]", VarFlag2)

					Debug.Print("Try this shit       @ShowVar[" & VarFlag & "]")

					StringClean = StringClean.Replace("@ShowVar[" & VarFlag & "]", VarFlag2)

				End If

			Next

		End If


		If StringClean.Contains("@ChastityOn") Then
			My.Settings.Chastity = True
			FrmSettings.LBLChastityState.Text = "ON"
			FrmSettings.LBLChastityState.ForeColor = Color.Green
			StringClean = StringClean.Replace("@ChastityOn", "")
		End If

		If StringClean.Contains("@ChastityOff") Then
			My.Settings.Chastity = False
			FrmSettings.LBLChastityState.Text = "OFF"
			FrmSettings.LBLChastityState.ForeColor = Color.Red
			StringClean = StringClean.Replace("@ChastityOff", "")
		End If

		If StringClean.Contains("@AddTokens(") Then

			Dim TokenFlag As String = GetParentheses(StringClean, "@AddTokens(")
			TokenFlag = FixCommas(TokenFlag)
			Dim TokenAdd As Integer

			If TokenFlag.Contains(",") Then
				Dim TokenArray As String() = TokenFlag.Split(",")
				For i As Integer = 0 To TokenArray.Count - 1
					TokenAdd = Val(TokenArray(i))
					If UCase(TokenArray(i)).Contains("B") Then ssh_BronzeTokens += TokenAdd
					If UCase(TokenArray(i)).Contains("S") Then ssh_SilverTokens += TokenAdd
					If UCase(TokenArray(i)).Contains("G") Then ssh_GoldTokens += TokenAdd
				Next
			Else
				TokenAdd = Val(TokenFlag)
				If UCase(TokenFlag).Contains("B") Then ssh_BronzeTokens += TokenAdd
				If UCase(TokenFlag).Contains("S") Then ssh_SilverTokens += TokenAdd
				If UCase(TokenFlag).Contains("G") Then ssh_GoldTokens += TokenAdd
			End If

			My.Settings.BronzeTokens = ssh_BronzeTokens
			My.Settings.SilverTokens = ssh_SilverTokens
			My.Settings.GoldTokens = ssh_GoldTokens


			StringClean = StringClean.Replace("@AddTokens(" & TokenFlag & ")", "")

		End If


		If StringClean.Contains("@RemoveTokens(") Then

			Dim TokenFlag As String = GetParentheses(StringClean, "@RemoveTokens(")
			TokenFlag = FixCommas(TokenFlag)
			Dim TokenRemove As Integer

			If TokenFlag.Contains(",") Then
				Dim TokenArray As String() = TokenFlag.Split(",")
				For i As Integer = 0 To TokenArray.Count - 1
					TokenRemove = Val(TokenArray(i))
					If UCase(TokenArray(i)).Contains("B") Then ssh_BronzeTokens -= TokenRemove
					If UCase(TokenArray(i)).Contains("S") Then ssh_SilverTokens -= TokenRemove
					If UCase(TokenArray(i)).Contains("G") Then ssh_GoldTokens -= TokenRemove
				Next
			Else
				TokenRemove = Val(TokenFlag)
				If UCase(TokenFlag).Contains("B") Then ssh_BronzeTokens -= TokenRemove
				If UCase(TokenFlag).Contains("S") Then ssh_SilverTokens -= TokenRemove
				If UCase(TokenFlag).Contains("G") Then ssh_GoldTokens -= TokenRemove
			End If

			If ssh_BronzeTokens < 0 Then ssh_BronzeTokens = 0
			If ssh_SilverTokens < 0 Then ssh_SilverTokens = 0
			If ssh_GoldTokens < 0 Then ssh_GoldTokens = 0

			My.Settings.BronzeTokens = ssh_BronzeTokens
			My.Settings.SilverTokens = ssh_SilverTokens
			My.Settings.GoldTokens = ssh_GoldTokens


			StringClean = StringClean.Replace("@RemoveTokens(" & TokenFlag & ")", "")

		End If

		If StringClean.Contains("@Add1Token") Then
			ssh_BronzeTokens += 1
			My.Settings.BronzeTokens = ssh_BronzeTokens
			FrmCardList.UpdateBronzeTokens()
			MessageBox.Show(Me, domName.Text & " has given you 1 Bronze token!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
			StringClean = StringClean.Replace("@Add1Token", "")
		End If

		If StringClean.Contains("@Add3Tokens") Then
			ssh_BronzeTokens += 3
			My.Settings.BronzeTokens = ssh_BronzeTokens
			FrmCardList.UpdateBronzeTokens()
			MessageBox.Show(Me, domName.Text & " has given you 3 Bronze tokens!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
			StringClean = StringClean.Replace("@Add3Tokens", "")
		End If

		If StringClean.Contains("@Add5Tokens") Then
			ssh_BronzeTokens += 5
			My.Settings.BronzeTokens = ssh_BronzeTokens
			FrmCardList.UpdateBronzeTokens()
			StringClean = StringClean.Replace("@Add5Tokens", "")
			MessageBox.Show(Me, domName.Text & " has given you 5 Bronze tokens!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
		End If

		If StringClean.Contains("@Add10Tokens") Then
			ssh_BronzeTokens += 10
			My.Settings.BronzeTokens = ssh_BronzeTokens
			FrmCardList.UpdateBronzeTokens()
			MessageBox.Show(Me, domName.Text & " has given you 10 Bronze tokens!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
			StringClean = StringClean.Replace("@Add10Tokens", "")
		End If

		If StringClean.Contains("@Add25Tokens") Then
			ssh_BronzeTokens += 25
			My.Settings.BronzeTokens = ssh_BronzeTokens
			FrmCardList.UpdateBronzeTokens()
			MessageBox.Show(Me, domName.Text & " has given you 25 Bronze tokens!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
			StringClean = StringClean.Replace("@Add25Tokens", "")
		End If

		If StringClean.Contains("@Add50Tokens") Then
			ssh_BronzeTokens += 50
			My.Settings.BronzeTokens = ssh_BronzeTokens
			FrmCardList.UpdateBronzeTokens()
			MessageBox.Show(Me, domName.Text & " has given you 50 Bronze tokens!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
			StringClean = StringClean.Replace("@Add50Tokens", "")
		End If

		If StringClean.Contains("@Add100Tokens") Then
			ssh_BronzeTokens += 100
			My.Settings.BronzeTokens = ssh_BronzeTokens
			FrmCardList.UpdateBronzeTokens()
			MessageBox.Show(Me, domName.Text & " has given you 100 Bronze tokens!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
			StringClean = StringClean.Replace("@Add50Tokens", "")
		End If

		If StringClean.Contains("@Remove100Tokens") Then
			ssh_BronzeTokens -= 100
			My.Settings.BronzeTokens = ssh_BronzeTokens
			FrmCardList.UpdateBronzeTokens()
			MessageBox.Show(Me, domName.Text & " has taken 100 Bronze tokens!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
			StringClean = StringClean.Replace("@@Remove100Tokens", "")
		End If


		If StringClean.Contains("@UpdateOrgasm") Then
			My.Settings.LastOrgasm = FormatDateTime(Now, DateFormat.ShortDate)

			'Github Patch
			If My.Settings.OrgasmsLocked = True Then My.Settings.OrgasmsRemaining -= 1

			FrmSettings.LBLLastOrgasm.Text = My.Settings.LastOrgasm
			StringClean = StringClean.Replace("@UpdateOrgasm", "")
		End If

		If StringClean.Contains("@UpdateRuined") Then
			My.Settings.LastRuined = FormatDateTime(Now, DateFormat.ShortDate)

			' GithubPatch
			If My.Settings.OrgasmsLocked = True Then My.Settings.OrgasmsRemaining -= 1

			FrmSettings.LBLLastRuined.Text = My.Settings.LastRuined
			StringClean = StringClean.Replace("@UpdateRuined", "")
		End If

		If StringClean.Contains("@DeleteVar[") Then

			Dim DeleteArray As String() = StringClean.Split("]")

			For i As Integer = 0 To DeleteArray.Count - 1

				If DeleteArray(i).Contains("@DeleteVar[") Then

					DeleteArray(i) = DeleteArray(i) & "]"

					Dim DFlag As String = GetParentheses(DeleteArray(i), "@DeleteVar[")
					Dim OriginalDelete As String = DFlag

					If DFlag.Contains(",") Then

						DFlag = FixCommas(DFlag)

						Dim FlagArray() As String = DFlag.Split(",")

						For x As Integer = 0 To FlagArray.Count - 1

							DeleteVariable(FlagArray(x))

						Next

					Else

						DeleteVariable(DFlag)

					End If

					'DeleteArray(i) = DeleteArray(i).Replace("@DeleteVar[" & OriginalDelete & "]", "")

					StringClean = StringClean.Replace("@DeleteVar[" & OriginalDelete & "]", "")

				End If

			Next

			'StringClean = Join(DeleteArray, Nothing)

		End If

		If StringClean.Contains("@PornAllowedOff") Then
			CreateFlag("SYS_NoPornAllowed")
			StringClean = StringClean.Replace("@PornAllowedOff", "")
		End If

		If StringClean.Contains("@PornAllowedOn") Then
			DeleteFlag("SYS_NoPornAllowed")
			StringClean = StringClean.Replace("@PornAllowedOn", "")
		End If

		If StringClean.Contains("@RestrictOrgasm(") Then

			Dim CheckFlag As String = GetParentheses(StringClean, "@RestrictOrgasm(")

			If CheckFlag.Contains(",") Then

				CheckFlag = CheckFlag.Replace(", ", ",")
				CheckFlag = CheckFlag.Replace(" ,", ",")

				Dim FlagArray() As String = CheckFlag.Split(",")

				Dim Seconds1 As Integer = Val(FlagArray(0))
				Dim Seconds2 As Integer = Val(FlagArray(1))

				If UCase(FlagArray(0)).Contains(UCase("MINUTE")) Then Seconds1 *= 60
				If UCase(FlagArray(0)).Contains(UCase("HOUR")) Then Seconds1 *= 3600
				If UCase(FlagArray(0)).Contains(UCase("DAY")) Then Seconds1 *= 86400
				If UCase(FlagArray(0)).Contains(UCase("WEEK")) Then Seconds1 *= 604800
				If UCase(FlagArray(0)).Contains(UCase("MONTH")) Then Seconds1 *= 2419200
				If UCase(FlagArray(0)).Contains(UCase("YEAR")) Then Seconds1 *= 29030400

				If UCase(FlagArray(1)).Contains(UCase("MINUTE")) Then Seconds2 *= 60
				If UCase(FlagArray(1)).Contains(UCase("HOUR")) Then Seconds2 *= 3600
				If UCase(FlagArray(1)).Contains(UCase("DAY")) Then Seconds2 *= 86400
				If UCase(FlagArray(1)).Contains(UCase("WEEK")) Then Seconds2 *= 604800
				If UCase(FlagArray(1)).Contains(UCase("MONTH")) Then Seconds2 *= 2419200
				If UCase(FlagArray(1)).Contains(UCase("YEAR")) Then Seconds2 *= 29030400

				Dim TotalSeconds As Integer = ssh_randomizer.Next(Seconds1, Seconds2 + 1)

				Dim SetDate As Date = FormatDateTime(Now, DateFormat.GeneralDate)

				SetDate = DateAdd(DateInterval.Second, TotalSeconds, SetDate)
				My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Variables\SYS_OrgasmRestricted", FormatDateTime(SetDate, DateFormat.GeneralDate), False)

			Else

				Dim SetDate As Date = FormatDateTime(Now, DateFormat.GeneralDate)

				If UCase(CheckFlag).Contains(UCase("SECOND")) Then SetDate = DateAdd(DateInterval.Second, Val(CheckFlag), SetDate)
				If UCase(CheckFlag).Contains(UCase("MINUTE")) Then SetDate = DateAdd(DateInterval.Minute, Val(CheckFlag), SetDate)
				If UCase(CheckFlag).Contains(UCase("HOUR")) Then SetDate = DateAdd(DateInterval.Hour, Val(CheckFlag), SetDate)
				If UCase(CheckFlag).Contains(UCase("DAY")) Then SetDate = DateAdd(DateInterval.Day, Val(CheckFlag), SetDate)
				If UCase(CheckFlag).Contains(UCase("WEEK")) Then SetDate = DateAdd(DateInterval.Day, Val(CheckFlag) * 7, SetDate)
				If UCase(CheckFlag).Contains(UCase("MONTH")) Then SetDate = DateAdd(DateInterval.Month, Val(CheckFlag), SetDate)
				If UCase(CheckFlag).Contains(UCase("YEAR")) Then SetDate = DateAdd(DateInterval.Year, Val(CheckFlag), SetDate)

				If Not UCase(CheckFlag).Contains(UCase("SECOND")) And Not UCase(CheckFlag).Contains(UCase("MINUTE")) And Not UCase(CheckFlag).Contains(UCase("HOUR")) _
				 And Not UCase(CheckFlag).Contains(UCase("DAY")) And Not UCase(CheckFlag).Contains(UCase("WEEK")) And Not UCase(CheckFlag).Contains(UCase("MONTH")) _
				 And Not UCase(CheckFlag).Contains(UCase("YEAR")) Then SetDate = DateAdd(DateInterval.Day, Val(CheckFlag), SetDate)

				My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Variables\SYS_OrgasmRestricted", FormatDateTime(SetDate, DateFormat.GeneralDate), False)

			End If
			ssh_OrgasmRestricted = True
			StringClean = StringClean.Replace("@RestrictOrgasm(" & GetParentheses(StringClean, "@RestrictOrgasm(") & ")", "")
		End If

		If StringClean.Contains("@RestrictOrgasm") Then
			ssh_OrgasmRestricted = True
			StringClean = StringClean.Replace("@RestrictOrgasm", "")
		End If

		If StringClean.Contains("@DecreaseOrgasmChance") Then

			If FrmSettings.alloworgasmComboBox.Text = "Rarely Allows" Then FrmSettings.alloworgasmComboBox.Text = "Never Allows"
			If FrmSettings.alloworgasmComboBox.Text = "Sometimes Allows" Then FrmSettings.alloworgasmComboBox.Text = "Rarely Allows"
			If FrmSettings.alloworgasmComboBox.Text = "Often Allows" Then FrmSettings.alloworgasmComboBox.Text = "Sometimes Allows"
			If FrmSettings.alloworgasmComboBox.Text = "Always Allows" Then FrmSettings.alloworgasmComboBox.Text = "Often Allows"

			My.Settings.OrgasmAllow = FrmSettings.alloworgasmComboBox.Text

			StringClean = StringClean.Replace("@DecreaseOrgasmChance", "")
		End If

		If StringClean.Contains("@IncreaseOrgasmChance") Then

			If FrmSettings.alloworgasmComboBox.Text = "Often Allows" Then FrmSettings.alloworgasmComboBox.Text = "Always Allows"
			If FrmSettings.alloworgasmComboBox.Text = "Sometimes Allows" Then FrmSettings.alloworgasmComboBox.Text = "Often Allows"
			If FrmSettings.alloworgasmComboBox.Text = "Rarely Allows" Then FrmSettings.alloworgasmComboBox.Text = "Sometimes Allows"
			If FrmSettings.alloworgasmComboBox.Text = "Never Allows" Then FrmSettings.alloworgasmComboBox.Text = "Rarely Allows"

			My.Settings.OrgasmAllow = FrmSettings.alloworgasmComboBox.Text

			StringClean = StringClean.Replace("@IncreaseOrgasmChance", "")
		End If

		If StringClean.Contains("@DecreaseRuinChance") Then

			If FrmSettings.ruinorgasmComboBox.Text = "Rarely Ruins" Then FrmSettings.ruinorgasmComboBox.Text = "Never Ruins"
			If FrmSettings.ruinorgasmComboBox.Text = "Sometimes Ruins" Then FrmSettings.ruinorgasmComboBox.Text = "Rarely Ruins"
			If FrmSettings.ruinorgasmComboBox.Text = "Often Ruins" Then FrmSettings.ruinorgasmComboBox.Text = "Sometimes Ruins"
			If FrmSettings.ruinorgasmComboBox.Text = "Always Ruins" Then FrmSettings.ruinorgasmComboBox.Text = "Often Ruins"

			My.Settings.OrgasmRuin = FrmSettings.ruinorgasmComboBox.Text

			StringClean = StringClean.Replace("@DecreaseRuinChance", "")
		End If

		If StringClean.Contains("@IncreaseRuinChance") Then

			If FrmSettings.ruinorgasmComboBox.Text = "Often Ruins" Then FrmSettings.ruinorgasmComboBox.Text = "Always Ruins"
			If FrmSettings.ruinorgasmComboBox.Text = "Sometimes Ruins" Then FrmSettings.ruinorgasmComboBox.Text = "Often Ruins"
			If FrmSettings.ruinorgasmComboBox.Text = "Rarely Ruins" Then FrmSettings.ruinorgasmComboBox.Text = "Sometimes Ruins"
			If FrmSettings.ruinorgasmComboBox.Text = "Never Ruins" Then FrmSettings.ruinorgasmComboBox.Text = "Rarely Ruins"

			My.Settings.OrgasmRuin = FrmSettings.ruinorgasmComboBox.Text

			StringClean = StringClean.Replace("@IncreaseRuinChance", "")
		End If

		'@@@@@@@@@@@@@@@@@@@@@@ TASKCLEAN END

		If TaskClean = True Then Return StringClean


		' The @CheckDate() Command checks a previously saved Variable created with the @SetDate() Command and goes to the specified line if the current time and date is on or after the date in the Variable.
		' Correct format is @CheckDate(VarName, Goto Line) . For example, @CheckDate(NoPorn, Look At Porn Again) will go to the line (Look At Porn Again) if the current time and date has passed the value set
		' for the Variable "NoPorn" by @SetDate()

		If StringClean.Contains("@CheckDate(") Then

			Dim CheckArray As String() = StringClean.Split(")")

			For i As Integer = 0 To CheckArray.Count - 1

				If CheckArray(i).Contains("@CheckDate(") Then

					If CheckDateList(CheckArray(i), True) = True Then
						Dim DateFlag As String = GetParentheses(CheckArray(i), "@CheckDate(")
						DateFlag = FixCommas(DateFlag)
						Dim DateArray As String() = DateFlag.Split(",")
						ssh_SkipGotoLine = True
						ssh_FileGoto = DateArray(DateArray.Count - 1).Replace(")", "")
						GetGoto()
					End If

					StringClean = StringClean.Replace("@CheckDate(" & GetParentheses(CheckArray(i), "@CheckDate(") & ")", "")

				End If

			Next

		End If

		' The @If[] Command allows you to compare Variables and go to a specific line if the statement is true. The correct format is @If[VarName]>[varName2]Then(Goto Line)
		' For example, If[StrokeTotal]>[1000]Then(Thousand Strokes) would check if the Variable "StrokeTotal" is greater than 1000, and go to (Thousand Strokes) if so. 
		' The @If[] Command can compare any combination of Variables and numeric values with = (or ==), <>, >, <, >= and <= . String Variables can be compared with = (or ==) and <> 
		' More than one @If[] Command can be used per line. Tease AI will move to the line specified by whichever true statement happened last in the line.

		If StringClean.Contains("@If[") Then

			Do

				Dim SCIfVar As String() = Split(StringClean)
				Dim SCGotVar As String = "Null"

				For i As Integer = 0 To SCIfVar.Length - 1
					If SCIfVar(i).Contains("@If[") Then
						Dim IFJoin As Integer = 0
						If Not SCIfVar(i).Contains(")") Then
							Do
								IFJoin += 1
								SCIfVar(i) = SCIfVar(i) & " " & SCIfVar(i + IFJoin)
								SCIfVar(i + IFJoin) = ""
							Loop Until SCIfVar(i).Contains(")")
						End If
						SCGotVar = SCIfVar(i)
						SCIfVar(i) = ""
						StringClean = Join(SCIfVar)
						Do
							StringClean = StringClean.Replace("  ", " ")
						Loop Until Not StringClean.Contains("  ")
						Exit For
					End If
				Next

				If SCGotVar.Contains("]And[") Then

					Dim AndCheck As Boolean = True

					For x As Integer = 0 To SCGotVar.Replace("]And[", "").Count - 1
						If GetIf("[" & GetParentheses(SCGotVar, "@If[", 2) & "]") = False Then
							AndCheck = False
							Exit For
						End If
						SCGotVar = SCGotVar.Replace("[" & GetParentheses(SCGotVar, "@If[", 2) & "]And", "")
					Next

					If AndCheck = True Then
						ssh_FileGoto = GetParentheses(SCGotVar, "Then(")
						ssh_SkipGotoLine = True
						GetGoto()
					End If

				ElseIf SCGotVar.Contains("]Or[") Then

					Dim OrCheck As Boolean = False

					For x As Integer = 0 To SCGotVar.Replace("]Or[", "").Count - 1
						If GetIf("[" & GetParentheses(SCGotVar, "@If[", 2) & "]") = True Then
							OrCheck = True
							Exit For
						End If
						SCGotVar = SCGotVar.Replace("[" & GetParentheses(SCGotVar, "@If[", 2) & "]Or", "")
					Next

					If OrCheck = True Then
						ssh_FileGoto = GetParentheses(SCGotVar, "Then(")
						ssh_SkipGotoLine = True
						GetGoto()
					End If

				Else

					If GetIf("[" & GetParentheses(SCGotVar, "@If[", 2) & "]") = True Then
						ssh_FileGoto = GetParentheses(SCGotVar, "Then(")
						ssh_SkipGotoLine = True
						GetGoto()
					End If

				End If

			Loop Until Not StringClean.Contains("@If")

		End If

		' The @InputVar[] stops script progression and waits for the user to input his next message. Whatever the user types next will be saved as a Variable named whatever you specify in the brackets.
		' For example, if the script's line was "What's your favorite food? @InputVar[FavoriteFood]", and the user typed "lo mein", then "lo mein" would be saved as the Variable "FavoriteFood". If the
		' user has checked "Show Icon During Input Questions" in the General Settings tab, then the domme's question will be accompanied by a small question mark icon to let the user know that their next
		' response will be saved verbatim. @InputVar[] will pause Linear Scripts, as well as countdowns and taunts for Stroking, Edging and Holding The Edge.

		If StringClean.Contains("@InputVar[") Then

			ssh_InputString = GetParentheses(StringClean, "@InputVar[").Replace("]", "")
			ssh_InputFlag = True
			If FrmSettings.CBInputIcon.Checked = True Then ssh_InputIcon = True

			StringClean = StringClean.Replace("@InputVar[" & ssh_InputString & "]", "")

		End If


		' The @DislikeBlogImage Command takes the URL of the most recently viewed blog image and adds it to the "Disliked" list located in [Tease AI Root Directory]\Images\System\DislikedImageURLS.txt

		If StringClean.Contains("@DislikeBlogImage") Then

			If ssh_ImageLocation <> "" Then

				If File.Exists(Application.StartupPath & "\Images\System\DislikedImageURLs.txt") Then
					My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Images\System\DislikedImageURLs.txt", Environment.NewLine & ssh_ImageLocation, True)
				Else
					My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Images\System\DislikedImageURLs.txt", ssh_ImageLocation, True)
				End If
				StringClean = StringClean.Replace("@DislikeBlogImage", "")
			End If

		End If

		' The @LikeBlogImage Command takes the URL of the most recently viewed blog image and adds it to the "Liked" list located in [Tease AI Root Directory]\Images\System\LikedImageURLS.txt

		If StringClean.Contains("@LikeBlogImage") Then

			If ssh_ImageLocation <> "" Then

				If File.Exists(Application.StartupPath & "\Images\System\LikedImageURLs.txt") Then
					My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Images\System\LikedImageURLs.txt", Environment.NewLine & ssh_ImageLocation, True)
				Else
					My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Images\System\LikedImageURLs.txt", ssh_ImageLocation, True)
				End If
				StringClean = StringClean.Replace("@LikeBlogImage", "")
			End If

		End If

		Debug.Print("SubStroking = " & ssh_SubStroking)
		Debug.Print("SubEdging = " & ssh_SubEdging)
		Debug.Print("SubHoldingEdge = " & ssh_SubHoldingEdge)

		'  ╔═╗┌┬┐┬─┐┌─┐┬┌─┌─┐╔═╗┌─┐┌─┐┌┬┐┌─┐┬─┐
		'  ╚═╗ │ ├┬┘│ │├┴┐├┤ ╠╣ ├─┤└─┐ │ ├┤ ├┬┘
		'  ╚═╝ ┴ ┴└─└─┘┴ ┴└─┘╚  ┴ ┴└─┘ ┴ └─┘┴└─

		If StringClean.Contains("@StrokeFaster") Then
			ssh_StrokeFaster = True
			StringClean = StringClean.Replace("@StrokeFaster", "")
		End If

		'  ╔═╗┌┬┐┬─┐┌─┐┬┌─┌─┐╔═╗┬  ┌─┐┬ ┬┌─┐┬─┐
		'  ╚═╗ │ ├┬┘│ │├┴┐├┤ ╚═╗│  │ ││││├┤ ├┬┘
		'  ╚═╝ ┴ ┴└─└─┘┴ ┴└─┘╚═╝┴─┘└─┘└┴┘└─┘┴└─

		If StringClean.Contains("@StrokeSlower") Then
			ssh_StrokeSlower = True
			StringClean = StringClean.Replace("@StrokeSlower", "")
		End If

		'  ╔═╗┌┬┐┬─┐┌─┐┬┌─┌─┐╔═╗┌─┐┌─┐┌┬┐┌─┐┌─┐┌┬┐
		'  ╚═╗ │ ├┬┘│ │├┴┐├┤ ╠╣ ├─┤└─┐ │ ├┤ └─┐ │ 
		'  ╚═╝ ┴ ┴└─└─┘┴ ┴└─┘╚  ┴ ┴└─┘ ┴ └─┘└─┘ ┴ 

		If StringClean.Contains("@StrokeFastest") Then
			ssh_StrokeFastest = True
			StringClean = StringClean.Replace("@StrokeFastest", "")
		End If

		'  ╔═╗┌┬┐┬─┐┌─┐┬┌─┌─┐╔═╗┬  ┌─┐┬ ┬┌─┐┌─┐┌┬┐
		'  ╚═╗ │ ├┬┘│ │├┴┐├┤ ╚═╗│  │ ││││├┤ └─┐ │ 
		'  ╚═╝ ┴ ┴└─└─┘┴ ┴└─┘╚═╝┴─┘└─┘└┴┘└─┘└─┘ ┴ 

		If StringClean.Contains("@StrokeSlowest") Then
			ssh_StrokeSlowest = True
			StringClean = StringClean.Replace("@StrokeSlowest", "")
		End If


		If StringClean.Contains("@StartStroking") Then

			If Not File.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Variables\SYS_FirstRun") Then
				Dim SetDate As Date = FormatDateTime(Now, DateFormat.GeneralDate)
				My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Variables\SYS_FirstRun", SetDate, False)
			End If

			SetVariable("SYS_StrokeRound", Val(GetVariable("SYS_StrokeRound")) + 1)

			If FrmSettings.TBWebStart.Text <> "" Then
				Try
					FrmSettings.WebToy.Navigate(FrmSettings.TBWebStart.Text)
				Catch
				End Try
			End If
			If StringClean.Contains("@Contact1") Then ssh_Contact1Stroke = True
			If StringClean.Contains("@Contact2") Then ssh_Contact2Stroke = True
			If StringClean.Contains("@Contact3") Then ssh_Contact3Stroke = True
			ssh_AskedToGiveUpSection = False
			ssh_AskedToSpeedUp = False
			ssh_AskedToSlowDown = False
			ssh_BeforeTease = False
			ssh_SubStroking = True
			ssh_ShowModule = False
			'StrokeCycle = -1
			If ssh_StartStrokingCount = 0 Then ssh_FirstRound = True
			'If FirstRound = True Then My.Settings.Sys_SubLeftEarly += 1
			If ssh_FirstRound = True Then SetVariable("SYS_SubLeftEarly", Val(GetVariable("SYS_SubLeftEarly")) + 1)
			ssh_StartStrokingCount += 1
			ssh_StopMetronome = False
			StrokePace = ssh_randomizer.Next(NBMaxPace.Value, NBMinPace.Value + 1)
			StrokePace = 50 * Math.Round(StrokePace / 50)

			If ssh_WorshipMode = True Then
				StrokePace = NBMinPace.Value
				ssh_StrokeSlowest = True
			End If

			ClearModes()

			If FrmSettings.CBTauntCycleDD.Checked = True Then
				If FrmSettings.domlevelNumBox.Value = 1 Then ssh_StrokeTick = ssh_randomizer.Next(1, 3) * 60
				If FrmSettings.domlevelNumBox.Value = 2 Then ssh_StrokeTick = ssh_randomizer.Next(1, 4) * 60
				If FrmSettings.domlevelNumBox.Value = 3 Then ssh_StrokeTick = ssh_randomizer.Next(3, 6) * 60
				If FrmSettings.domlevelNumBox.Value = 4 Then ssh_StrokeTick = ssh_randomizer.Next(4, 8) * 60
				If FrmSettings.domlevelNumBox.Value = 5 Then ssh_StrokeTick = ssh_randomizer.Next(5, 11) * 60

				If ssh_WorshipMode = True Then
					If FrmSettings.domlevelNumBox.Value = 1 Then ssh_StrokeTick = 180
					If FrmSettings.domlevelNumBox.Value = 2 Then ssh_StrokeTick = 240
					If FrmSettings.domlevelNumBox.Value = 3 Then ssh_StrokeTick = 360
					If FrmSettings.domlevelNumBox.Value = 4 Then ssh_StrokeTick = 480
					If FrmSettings.domlevelNumBox.Value = 5 Then ssh_StrokeTick = 600
				End If

			Else
				ssh_StrokeTick = ssh_randomizer.Next(FrmSettings.NBTauntCycleMin.Value * 60, FrmSettings.NBTauntCycleMax.Value * 60)
				If ssh_WorshipMode = True Then ssh_StrokeTick = FrmSettings.NBTauntCycleMax.Value * 60
			End If



			ssh_StrokeTauntTick = ssh_randomizer.Next(11, 21)
			'StrokeThread = New Thread(AddressOf StrokeLoop)
			'StrokeThread.IsBackground = True
			'StrokeThread.SetApartmentState(ApartmentState.STA)
			'StrokeThread.Start()
			StrokeTimer.Start()
			StrokeTauntTimer.Start()
			StringClean = StringClean.Replace("@StartStroking", "")
		End If

		If StringClean.Contains("@StartTaunts") Then
			ssh_AskedToGiveUpSection = False
			ssh_AskedToSpeedUp = False
			ssh_AskedToSlowDown = False
			ssh_BeforeTease = False
			ssh_SubStroking = True
			ssh_ShowModule = False
			'StrokeCycle = -1
			If ssh_StartStrokingCount = 0 Then ssh_FirstRound = True
			ssh_StartStrokingCount += 1
			' github patch StrokePace = 0
			' github patch StrokePaceTimer.Interval = StrokePace
			ssh_StopMetronome = False

			ClearModes()

			If FrmSettings.CBTauntCycleDD.Checked = True Then
				If FrmSettings.domlevelNumBox.Value = 1 Then ssh_StrokeTick = ssh_randomizer.Next(1, 3) * 60
				If FrmSettings.domlevelNumBox.Value = 2 Then ssh_StrokeTick = ssh_randomizer.Next(1, 4) * 60
				If FrmSettings.domlevelNumBox.Value = 3 Then ssh_StrokeTick = ssh_randomizer.Next(3, 6) * 60
				If FrmSettings.domlevelNumBox.Value = 4 Then ssh_StrokeTick = ssh_randomizer.Next(4, 8) * 60
				If FrmSettings.domlevelNumBox.Value = 5 Then ssh_StrokeTick = ssh_randomizer.Next(5, 11) * 60
			Else
				ssh_StrokeTick = ssh_randomizer.Next(FrmSettings.NBTauntCycleMin.Value * 60, FrmSettings.NBTauntCycleMax.Value * 60)
			End If
			ssh_StrokeTauntTick = ssh_randomizer.Next(11, 21)
			StrokeTimer.Start()
			StrokeTauntTimer.Start()
			StringClean = StringClean.Replace("@StartTaunts", "")
		End If

		If StringClean.Contains("@StopStroking") Then
			If FrmSettings.TBWebStop.Text <> "" Then
				Try
					FrmSettings.WebToy.Navigate(FrmSettings.TBWebStop.Text)
				Catch
				End Try
			End If
			If ssh_Contact1Stroke = True Then
				StringClean = StringClean & "@Contact1"
				ssh_Contact1Stroke = False
			End If
			If ssh_Contact2Stroke = True Then
				StringClean = StringClean & "@Contact2"
				ssh_Contact2Stroke = False
			End If
			If ssh_Contact3Stroke = True Then
				StringClean = StringClean & "@Contact3"
				ssh_Contact3Stroke = False
			End If
			ssh_AskedToSpeedUp = False
			ssh_AskedToSlowDown = False
			ssh_SubStroking = False
			ssh_SubEdging = False
			ssh_SubHoldingEdge = False
			ssh_WorshipMode = False
			ssh_WorshipTarget = ""
			ssh_LongHold = False
			ssh_ExtremeHold = False
			StrokeTimer.Stop()
			StrokeTauntTimer.Stop()
			StrokePace = 0
			EdgeTauntTimer.Stop()
			HoldEdgeTauntTimer.Stop()
			StringClean = StringClean.Replace("@StopStroking", "")
		End If

		If StringClean.Contains("@StopTaunts") Then
			ssh_AskedToSpeedUp = False
			ssh_AskedToSlowDown = False
			ssh_SubStroking = False
			ssh_SubEdging = False
			ssh_SubHoldingEdge = False
			StrokeTimer.Stop()
			StrokeTauntTimer.Stop()
			EdgeTauntTimer.Stop()
			HoldEdgeTauntTimer.Stop()
			StringClean = StringClean.Replace("@StopTaunts", "")
		End If


		If StringClean.Contains("@LongHold(") Then
			Dim HoldInt As Integer = Val(GetParentheses(StringClean, "@LongHold("))
			ssh_TempVal = ssh_randomizer.Next(0, 101)
			If ssh_TempVal <= HoldInt Then ssh_LongHold = True

			StringClean = StringClean.Replace("@LongHold(" & GetParentheses(StringClean, "@LongHold(") & ")", "")
		End If

		If StringClean.Contains("@ExtremeHold(") Then
			Dim HoldInt As Integer = Val(GetParentheses(StringClean, "@ExtremeHold("))
			ssh_TempVal = ssh_randomizer.Next(0, 101)
			If ssh_TempVal <= HoldInt Then ssh_ExtremeHold = True

			StringClean = StringClean.Replace("@ExtremeHold(" & GetParentheses(StringClean, "@ExtremeHold(") & ")", "")
		End If

		If StringClean.Contains("@LongHold") Then
			ssh_LongHold = True
			StringClean = StringClean.Replace("@LongHold", "")
		End If

		If StringClean.Contains("@ExtremeHold") Then
			ssh_ExtremeHold = True
			StringClean = StringClean.Replace("@ExtremeHold", "")
		End If

		If StringClean.Contains("@MultipleEdges(") Then

			If StringClean.Contains("@Edg") Then

				Dim EdgeFlag As String = GetParentheses(StringClean, "@MultipleEdges(")
				EdgeFlag = FixCommas(EdgeFlag)
				Dim EdgeArray As String() = EdgeFlag.Split(",")

				If EdgeArray.Count = 3 Then

					If ssh_randomizer.Next(1, 101) < Val(EdgeArray(2)) Then
						ssh_MultipleEdges = True
						ssh_MultipleEdgesAmount = Val(EdgeArray(0))
						ssh_MultipleEdgesInterval = Val(EdgeArray(1))
					End If

				Else

					ssh_MultipleEdges = True
					ssh_MultipleEdgesAmount = Val(EdgeArray(0))
					ssh_MultipleEdgesInterval = Val(EdgeArray(1))

				End If

			End If

			StringClean = StringClean.Replace("@MultipleEdges(" & GetParentheses(StringClean, "@MultipleEdges(") & ")", "")

		End If


		If StringClean.Contains("@Edge(") Then

			ContactEdgeCheck(StringClean)

			Edge()

			If GetMatch(StringClean, "@Edge(", "Hold") = True Then ssh_EdgeHold = True
			If GetMatch(StringClean, "@Edge(", "NoHold") = True Then ssh_EdgeNoHold = True
			If ssh_EdgeHold = True And ssh_EdgeNoHold = True Then ssh_EdgeHold = False

			If GetMatch(StringClean, "@Edge(", "Deny") = True Then ssh_OrgasmDenied = True

			If GetMatch(StringClean, "@Edge(", "Orgasm") = True Then ssh_OrgasmAllowed = True

			If GetMatch(StringClean, "@Edge(", "Ruin") = True Then ssh_OrgasmRuined = True

			If ssh_OrgasmAllowed = True And ssh_OrgasmRuined = True Then ssh_OrgasmRuined = False

			If GetMatch(StringClean, "@Edge(", "RuinTaunts") = True Then
				If ssh_EdgeToRuin = True Then ssh_EdgeToRuinSecret = False
			End If

			If GetMatch(StringClean, "@Edge(", "LongHold") = True Then
				ssh_EdgeHold = True
				ssh_LongHold = True
			End If
			If GetMatch(StringClean, "@Edge(", "ExtremeHold") = True Then
				ssh_EdgeHold = True
				ssh_ExtremeHold = True
			End If
			If GetMatch(StringClean, "@Edge(", "HoldTaunts") = True Then
				If ssh_LongHold = True Then ssh_LongTaunts = True
			End If

		End If



		If StringClean.Contains("@EdgeMode(") Then

			Dim EdgeFlag As String = GetParentheses(StringClean, "@EdgeMode(")
			EdgeFlag = FixCommas(EdgeFlag)
			Dim EdgeArray As String() = EdgeFlag.Split(",")

			If UCase(EdgeArray(0)).Contains("GOTO") Then
				ssh_EdgeGoto = True
				ssh_EdgeGotoLine = EdgeArray(1)
			End If

			If UCase(EdgeArray(0)).Contains("MESSAGE") Then
				ssh_EdgeMessage = True
				ssh_EdgeMessageText = EdgeArray(1)
			End If

			If UCase(EdgeArray(0)).Contains("VIDEO") Then
				ssh_EdgeVideo = True
				ssh_EdgeGotoLine = EdgeArray(1)
			End If

			If UCase(EdgeArray(0)).Contains("NORMAL") Then
				ssh_EdgeGoto = False
				ssh_EdgeMessage = False
				ssh_EdgeVideo = False
			End If

			StringClean = StringClean.Replace("@EdgeMode(" & GetParentheses(StringClean, "@EdgeMode(") & ")", "")
		End If

		If StringClean.Contains("@EdgeToRuinNoHoldNoSecret") Then
			ContactEdgeCheck(StringClean)
			Edge()
			ssh_EdgeToRuin = True
			ssh_EdgeToRuinSecret = False
			StringClean = StringClean.Replace("@EdgeToRuinNoHoldNoSecret", "")
		End If

		If StringClean.Contains("@EdgeToRuinHoldNoSecret(") Then

			Dim EdgeHoldFlag As String = GetParentheses(StringClean, "@EdgeToRuinHoldNoSecret(")

			If EdgeHoldFlag.Contains(",") Then

				EdgeHoldFlag = FixCommas(EdgeHoldFlag)

				Dim EdgeFlagArray As String() = EdgeHoldFlag.Split(",")

				Dim Edge1 As Integer = Val(EdgeFlagArray(0))
				Dim Edge2 As Integer = Val(EdgeFlagArray(1))

				If UCase(EdgeFlagArray(0)).Contains("M") Then Edge1 *= 60
				If UCase(EdgeFlagArray(1)).Contains("M") Then Edge2 *= 60

				If UCase(EdgeFlagArray(0)).Contains("H") Then Edge1 *= 3600
				If UCase(EdgeFlagArray(1)).Contains("H") Then Edge2 *= 3600

				ssh_EdgeHoldSeconds = ssh_randomizer.Next(Edge1, Edge2 + 1)

			Else

				ssh_EdgeHoldSeconds = Val(EdgeHoldFlag)
				If UCase(GetParentheses(StringClean, "@EdgeToRuinHoldNoSecret(")).Contains("M") Then ssh_EdgeHoldSeconds *= 60
				If UCase(GetParentheses(StringClean, "@EdgeToRuinHoldNoSecret(")).Contains("H") Then ssh_EdgeHoldSeconds *= 3600

			End If

			EdgeHoldFlag = True

			ContactEdgeCheck(StringClean)
			Edge()
			ssh_EdgeHold = True
			ssh_EdgeToRuin = True
			ssh_EdgeToRuinSecret = False
			StringClean = StringClean.Replace("@EdgeToRuinHoldNoSecret(" & GetParentheses(StringClean, "@EdgeToRuinHoldNoSecret(") & ")", "")
		End If



		If StringClean.Contains("@EdgeToRuinHoldNoSecret") Then
			ContactEdgeCheck(StringClean)
			Edge()
			ssh_EdgeHold = True
			ssh_EdgeToRuin = True
			ssh_EdgeToRuinSecret = False
			StringClean = StringClean.Replace("@EdgeToRuinHoldNoSecret", "")
		End If

		If StringClean.Contains("@EdgeToRuinNoSecret") Then
			ContactEdgeCheck(StringClean)
			Edge()
			ssh_EdgeToRuinSecret = False
			ssh_EdgeToRuin = True
			StringClean = StringClean.Replace("@EdgeToRuinNoSecret", "")
		End If

		If StringClean.Contains("@EdgeToRuinNoHold") Then
			ContactEdgeCheck(StringClean)
			Edge()
			ssh_EdgeNoHold = True
			ssh_EdgeToRuin = True
			StringClean = StringClean.Replace("@EdgeToRuinNoHold", "")
		End If

		If StringClean.Contains("@EdgeToRuinHold(") Then

			Dim EdgeHoldFlag As String = GetParentheses(StringClean, "@EdgeToRuinHold(")

			If EdgeHoldFlag.Contains(",") Then

				EdgeHoldFlag = FixCommas(EdgeHoldFlag)

				Dim EdgeFlagArray As String() = EdgeHoldFlag.Split(",")

				Dim Edge1 As Integer = Val(EdgeFlagArray(0))
				Dim Edge2 As Integer = Val(EdgeFlagArray(1))

				If UCase(EdgeFlagArray(0)).Contains("M") Then Edge1 *= 60
				If UCase(EdgeFlagArray(1)).Contains("M") Then Edge2 *= 60

				If UCase(EdgeFlagArray(0)).Contains("H") Then Edge1 *= 3600
				If UCase(EdgeFlagArray(1)).Contains("H") Then Edge2 *= 3600

				ssh_EdgeHoldSeconds = ssh_randomizer.Next(Edge1, Edge2 + 1)

			Else

				ssh_EdgeHoldSeconds = Val(EdgeHoldFlag)
				If UCase(GetParentheses(StringClean, "@EdgeToRuinHold(")).Contains("M") Then ssh_EdgeHoldSeconds *= 60
				If UCase(GetParentheses(StringClean, "@EdgeToRuinHold(")).Contains("H") Then ssh_EdgeHoldSeconds *= 3600

			End If

			EdgeHoldFlag = True

			ContactEdgeCheck(StringClean)
			Edge()
			ssh_EdgeHold = True
			ssh_EdgeToRuin = True

			StringClean = StringClean.Replace("@EdgeToRuinHold(" & GetParentheses(StringClean, "@EdgeToRuinHold(") & ")", "")
		End If

		If StringClean.Contains("@EdgeToRuinHold") Then
			ContactEdgeCheck(StringClean)
			Edge()
			ssh_EdgeHold = True
			ssh_EdgeToRuin = True
			StringClean = StringClean.Replace("@EdgeToRuinHold", "")
		End If

		If StringClean.Contains("@EdgeToRuin") Then
			ContactEdgeCheck(StringClean)
			Edge()
			ssh_EdgeToRuin = True
			StringClean = StringClean.Replace("@EdgeToRuin", "")
		End If

		If StringClean.Contains("@EdgeNoHold") Then
			ContactEdgeCheck(StringClean)
			Edge()
			ssh_EdgeNoHold = True
			StringClean = StringClean.Replace("@EdgeNoHold", "")
		End If


		' The Commands @EdgeHold(), @EdgeToRuinHold() and @EdgeToRuinHoldNoSecret() allow you to specify the amount of time the edge is held. The defualt is in seconds, but you can use Minutes and Hours as well
		' For example: @EdgeHold(60) would have the domme make you hold the edge for 60 seconds
		' @EdgeHold(3 Minutes) or @EdgeHold(3 M) - Domme will make you hold the edge for three minutes
		' @EdgeHold(2 Hours) - Domme will make you hold the edge for 2 hours. Good luck :D
		'
		'You can also set a time range using a comma. For example, @EdgeHold(2 Minutes, 5 Minutes) - the domme would make you hold it a random amount of time bwteen 2 and 5 minutes.

		If StringClean.Contains("@EdgeHold(") Then

			Dim EdgeHoldFlag As String = GetParentheses(StringClean, "@EdgeHold(")

			If EdgeHoldFlag.Contains(",") Then

				EdgeHoldFlag = FixCommas(EdgeHoldFlag)

				Dim EdgeFlagArray As String() = EdgeHoldFlag.Split(",")

				Dim Edge1 As Integer = Val(EdgeFlagArray(0))
				Dim Edge2 As Integer = Val(EdgeFlagArray(1))

				If UCase(EdgeFlagArray(0)).Contains("M") Then Edge1 *= 60
				If UCase(EdgeFlagArray(1)).Contains("M") Then Edge2 *= 60

				If UCase(EdgeFlagArray(0)).Contains("H") Then Edge1 *= 3600
				If UCase(EdgeFlagArray(1)).Contains("H") Then Edge2 *= 3600

				ssh_EdgeHoldSeconds = ssh_randomizer.Next(Edge1, Edge2 + 1)

			Else

				ssh_EdgeHoldSeconds = Val(EdgeHoldFlag)
				If UCase(GetParentheses(StringClean, "@EdgeHold(")).Contains("M") Then ssh_EdgeHoldSeconds *= 60
				If UCase(GetParentheses(StringClean, "@EdgeHold(")).Contains("H") Then ssh_EdgeHoldSeconds *= 3600

			End If

			EdgeHoldFlag = True


			ContactEdgeCheck(StringClean)
			Edge()
			ssh_EdgeHold = True
			StringClean = StringClean.Replace("@EdgeHold(" & GetParentheses(StringClean, "@EdgeHold(") & ")", "")

		End If


		If StringClean.Contains("@EdgeHold") Then
			ContactEdgeCheck(StringClean)
			Edge()
			ssh_EdgeHold = True
			StringClean = StringClean.Replace("@EdgeHold", "")
		End If

		If StringClean.Contains("@Edge") Then
			ContactEdgeCheck(StringClean)
			Edge()
			StringClean = StringClean.Replace("@Edge", "")
		End If

		If StringClean.Contains("@CBTBalls") Then
			If FrmSettings.CBCBTBalls.Checked = True Then
				ssh_CBTBallsActive = True
				ssh_CBTBallsFlag = True
				ssh_TasksCount = ssh_randomizer.Next(FrmSettings.NBTasksMin.Value, FrmSettings.NBTasksMax.Value + 1)
			End If
			StringClean = StringClean.Replace("@CBTBalls", "")
		End If

		If StringClean.Contains("@CBTCock") Then
			If FrmSettings.CBCBTCock.Checked = True Then
				ssh_CBTCockActive = True
				ssh_CBTCockFlag = True
				ssh_TasksCount = ssh_randomizer.Next(FrmSettings.NBTasksMin.Value, FrmSettings.NBTasksMax.Value + 1)
			End If
			StringClean = StringClean.Replace("@CBTCock", "")
		End If

		If StringClean.Contains("@CBT") And Not StringClean.Contains("@CBTLevel") Then

			If FrmSettings.CBCBTCock.Checked = True And FrmSettings.CBCBTBalls.Checked = True Then
				ssh_CBTBothActive = True
				ssh_CBTBothFlag = True
				ssh_TasksCount = ssh_randomizer.Next(FrmSettings.NBTasksMin.Value, FrmSettings.NBTasksMax.Value + 1)
			End If

			StringClean = StringClean.Replace("@CBT", "")
		End If


		' The @CustomTask() Command works similarly to @CBTBalls and @CBTCock. It allows the user to have the domme run custom instructions from scripts located in Custom\Tasks. For example,
		' @CustomTask(Spanking) would pull its first instruction from Custom\Tasks\Spanking_First.txt, and all subsequent instructions would be pulled from Custom\Tasks\Spanking.txt.

		If StringClean.Contains("@CustomTask(") Then

			Dim CustomFlag As String = GetParentheses(StringClean, "@CustomTask(")

			CustomFlag = FixCommas(CustomFlag)

			Dim CustomArray As String() = CustomFlag.Split(",")

			If File.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Custom\Tasks\" & CustomArray(0) & "_First.txt") And
			 File.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Custom\Tasks\" & CustomArray(0) & ".txt") Then
				ssh_CustomTask = True
				ssh_CustomTaskActive = True
				ssh_CustomTaskText = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Custom\Tasks\" & CustomArray(0) & ".txt"
				ssh_CustomTaskTextFirst = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Custom\Tasks\" & CustomArray(0) & "_First.txt"
			End If

			If CustomArray.Count > 1 Then
				ssh_TasksCount = Val(CustomArray(1))
			Else
				ssh_TasksCount = ssh_randomizer.Next(FrmSettings.NBTasksMin.Value, FrmSettings.NBTasksMax.Value + 1)
			End If


			StringClean = StringClean.Replace("@CustomTask(" & GetParentheses(StringClean, "@CustomTask(") & ")", "")

		End If


		If StringClean.Contains("@DecideOrgasm") Then

			ssh_OrgasmDenied = False
			ssh_OrgasmAllowed = False
			ssh_OrgasmRuined = False

			Dim AllowGoto As String = "Orgasm Allow"
			Dim RuinGoto As String = "Orgasm Ruin"
			Dim DenyGoto As String = "Orgasm Deny"

			If StringClean.Contains("@DecideOrgasm(") Then

				Dim OrgasmFlag As String = GetParentheses(StringClean, "@DecideOrgasm(")
				OrgasmFlag = FixCommas(OrgasmFlag)
				Dim OrgasmArray As String() = OrgasmFlag.Split(",")

				If OrgasmArray.Count = 3 Then
					AllowGoto = OrgasmArray(0)
					RuinGoto = OrgasmArray(1)
					DenyGoto = OrgasmArray(2)
				End If

			End If


			If FrmSettings.alloworgasmComboBox.Text = "Always Allows" And FrmSettings.ruinorgasmComboBox.Text = "Always Ruins" Then
				ssh_FileGoto = RuinGoto
				ssh_OrgasmRuined = True
				GoTo OrgasmDecided
			End If

			Dim OrgasmInt As Integer = ssh_randomizer.Next(1, 101)
			'Debug.Print("OrgasmInt =" & OrgasmInt)
			Dim OrgasmThreshold As Integer

			If FrmSettings.alloworgasmComboBox.Text = "Never Allows" Then OrgasmThreshold = 0
			If FrmSettings.alloworgasmComboBox.Text = "Always Allows" Then OrgasmThreshold = 1000

			If FrmSettings.CBRangeOrgasm.Checked = True Then
				If FrmSettings.alloworgasmComboBox.Text = "Rarely Allows" Then OrgasmThreshold = 20
				If FrmSettings.alloworgasmComboBox.Text = "Sometimes Allows" Then OrgasmThreshold = 50
				If FrmSettings.alloworgasmComboBox.Text = "Often Allows" Then OrgasmThreshold = 75
			Else
				If FrmSettings.alloworgasmComboBox.Text = "Rarely Allows" Then OrgasmThreshold = FrmSettings.NBAllowRarely.Value
				If FrmSettings.alloworgasmComboBox.Text = "Sometimes Allows" Then OrgasmThreshold = FrmSettings.NBAllowSometimes.Value
				If FrmSettings.alloworgasmComboBox.Text = "Often Allows" Then OrgasmThreshold = FrmSettings.NBAllowOften.Value
			End If


			If OrgasmInt > OrgasmThreshold Then
				ssh_FileGoto = DenyGoto
				ssh_OrgasmDenied = True
				GoTo OrgasmDecided
			End If

			Dim RuinInt As Integer = ssh_randomizer.Next(1, 101)
			'Debug.Print("OrgasmInt =" & OrgasmInt)
			Dim RuinThreshold As Integer

			If FrmSettings.ruinorgasmComboBox.Text = "Never Ruins" Then RuinThreshold = 0
			If FrmSettings.ruinorgasmComboBox.Text = "Always Ruins" Then RuinThreshold = 1000


			If FrmSettings.CBRangeRuin.Checked = True Then
				If FrmSettings.ruinorgasmComboBox.Text = "Rarely Ruins" Then RuinThreshold = 20
				If FrmSettings.ruinorgasmComboBox.Text = "Sometimes Ruins" Then RuinThreshold = 50
				If FrmSettings.ruinorgasmComboBox.Text = "Often Ruins" Then RuinThreshold = 75
			Else
				If FrmSettings.ruinorgasmComboBox.Text = "Rarely Ruins" Then RuinThreshold = FrmSettings.NBRuinRarely.Value
				If FrmSettings.ruinorgasmComboBox.Text = "Sometimes Ruins" Then RuinThreshold = FrmSettings.NBRuinSometimes.Value
				If FrmSettings.ruinorgasmComboBox.Text = "Often Ruins" Then RuinThreshold = FrmSettings.NBRuinOften.Value
			End If


			If RuinInt > RuinThreshold Then
				ssh_FileGoto = AllowGoto
				ssh_OrgasmAllowed = True
			Else
				ssh_FileGoto = RuinGoto
				ssh_OrgasmRuined = True
			End If

OrgasmDecided:

			ssh_SkipGotoLine = True
			GetGoto()

			StringClean = StringClean.Replace("@DecideOrgasm", "")
		End If


		If StringClean.Contains("@OrgasmRuin") Then
			ssh_FileGoto = "Orgasm Ruin"
			ssh_OrgasmRuined = True
			ssh_SkipGotoLine = True
			GetGoto()
			StringClean = StringClean.Replace("@OrgasmRuin", "")
		End If

		If StringClean.Contains("@OrgasmDeny") Then
			ssh_FileGoto = "Orgasm Deny"
			ssh_OrgasmDenied = True
			ssh_SkipGotoLine = True
			GetGoto()
			StringClean = StringClean.Replace("@OrgasmDeny", "")
		End If

		If StringClean.Contains("@OrgasmAllow") Then
			ssh_FileGoto = "Orgasm Allow"
			ssh_OrgasmAllowed = True
			ssh_SkipGotoLine = True
			GetGoto()
			StringClean = StringClean.Replace("@OrgasmAllow", "")
		End If



		' The @Glitter Command allows to specify a specfic script from the domme's Apps\Glitter\Script directory, which will then immediately play out in the Glitter app. For example, @Glitter(About to Ruin)
		' would run the Glitter script in Apps\Glitter\Script\About to Ruin.txt.

		If StringClean.Contains("@Glitter(") Then

			' GitHub Patch: Dim GlitterFlag As Integer = GetParentheses(StringClean, "@Glitter(")
			Dim GlitterFlag As String = GetParentheses(StringClean, "@Glitter(")

			If My.Settings.CBGlitterFeedOff = False And ssh_UpdatingPost = False Then
				If File.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Apps\Glitter\Script\" & GlitterFlag & ".txt") And ssh_UpdatingPost = False Then
					ssh_UpdateList.Clear()
					ssh_UpdateList.Add(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Apps\Glitter\Script\" & GlitterFlag & ".txt")
					StatusUpdatePost()
				End If
			End If

			StringClean = StringClean.Replace("@Glitter(" & GlitterFlag & ")", "")

		End If



		If StringClean.Contains("@WritingTask(") Then

			ssh_WritingTaskFlag = True

			Dim WTTempString As String() = Split(StringClean, "@WritingTask(", 2)
			Dim WTTemp As String() = Split(WTTempString(1), ")")
			LBLWritingTaskText.Text = WTTemp(0)
			LBLWritingTaskText.Text = StripCommands(LBLWritingTaskText.Text)
			LBLWritingTaskText.Text = StripFormat(LBLWritingTaskText.Text)
			LBLWritingTaskText.Text = LBLWritingTaskText.Text.Replace("  ", " ")

			Dim WritingTaskVal As Integer = Val(LBLWritingTaskText.Text)
			'Debug.Print("WritingTaskVal = " & WritingTaskVal)

			If WritingTaskVal = 0 Then
				ssh_WritingTaskLinesAmount = ssh_randomizer.Next(FrmSettings.NBWritingTaskMin.Value, FrmSettings.NBWritingTaskMax.Value)
				ssh_WritingTaskLinesAmount = 5 * Math.Round(ssh_WritingTaskLinesAmount / 5)
			Else
				ssh_WritingTaskLinesAmount = WritingTaskVal
				LBLWritingTaskText.Text = LBLWritingTaskText.Text.Replace(WritingTaskVal, "")
			End If

			LBLLinesWritten.Text = "0"
			LBLLinesRemaining.Text = ssh_WritingTaskLinesAmount

			If PNLWritingTask.Visible = False Then
				CloseApp()
				OpenApp()
				PNLWritingTask.Visible = True
			End If

			'WritingTaskMistakesAllowed = randomizer.Next(3, 9)

			'determine error numbers based on numbers of lines to write
			ssh_WritingTaskMistakesAllowed = ssh_randomizer.Next(ssh_WritingTaskLinesAmount / 10, ssh_WritingTaskLinesAmount / 3)
			'clamps the value between 2 and 10 errors
			ssh_WritingTaskMistakesAllowed = Math.Max(2, ssh_WritingTaskMistakesAllowed)
			ssh_WritingTaskMistakesAllowed = Math.Min(ssh_WritingTaskMistakesAllowed, 10)

			LBLMistakesAllowed.Text = ssh_WritingTaskMistakesAllowed
			LBLMistakesMade.Text = "0"
			StringClean = StringClean.Replace("@WritingTask", "")
			'LBLWritingTask.Text = "Write the following line " & WritingTaskLinesAmount & " times."
			ssh_WritingTaskLinesRemaining = ssh_WritingTaskLinesAmount
			ssh_WritingTaskLinesWritten = 0
			ssh_WritingTaskMistakesMade = 0
			chatBox.ShortcutsEnabled = False
			ChatBox2.ShortcutsEnabled = False

			If My.Settings.TimedWriting = True Then

				Dim secs As Single

				'determines how many secs are given for writing each line, depending on line length and typespeed value selected by the user in the settings
				'(between 0,54 and 0,75 secs per character in the sentence at slowest typingspeed and between 0.18 and 0.25 at fastest typing speed)
				secs = (ssh_randomizer.Next(15, 25) / My.Settings.TypeSpeed) * LBLWritingTaskText.Text.Length
				'determines how much time is given (in seconds) to complete the @WritingTask() depending on how many lines you have to write and a small bonus to give some
				'more time for very short lines
				ssh_WritingTaskCurrentTime = 5 + secs * ssh_WritingTaskLinesAmount

				LBLWritingTask.Text = "Write the following line " & ssh_WritingTaskLinesAmount & " times" & vbCrLf & "In " & ConvertSeconds(ssh_WritingTaskCurrentTime)
				LBLWritingTask.Text = LBLWritingTask.Text.Replace("line 1 times", "line 1 time")
			Else
				LBLWritingTask.Text = "Write the following line " & ssh_WritingTaskLinesAmount & " times"
				LBLWritingTask.Text = LBLWritingTask.Text.Replace("line 1 times", "line 1 time")
			End If

		End If

		If StringClean.Contains("@CheckJOIVideo") Then

			If Directory.Exists(My.Settings.VideoJOI) Or Directory.Exists(My.Settings.VideoJOID) Then
				If FrmSettings.LblVideoJOITotal.Text <> "0" Or FrmSettings.LblVideoJOITotalD.Text <> "0" Then
				Else
					ssh_SkipGotoLine = True
					ssh_FileGoto = "No JOI Found"
					GetGoto()
				End If
			Else
				ssh_SkipGotoLine = True
				ssh_FileGoto = "No JOI Found"
				GetGoto()
			End If

			StringClean = StringClean.Replace("@CheckJOIVideo", "")

		End If


		If StringClean.Contains("@PlayJOIVideo") Then

			If Directory.Exists(My.Settings.VideoJOI) Or Directory.Exists(My.Settings.VideoJOID) Then

				ssh_TeaseVideo = True
				PlayRandomJOI()
			End If

			StringClean = StringClean.Replace("@PlayJOIVideo", "")

		End If

		If StringClean.Contains("@PlayCHVideo") Then

			If Directory.Exists(My.Settings.VideoCH) Or Directory.Exists(My.Settings.VideoCH) Then

				ssh_TeaseVideo = True
				PlayRandomCH()
			End If

			StringClean = StringClean.Replace("@PlayCHVideo", "")

		End If




		If StringClean.Contains("@GiveUpCheck") Then


			If ssh_AskedToGiveUpSection = True Then

				If ssh_SubGaveUp = True Then
					ssh_ResponseFile = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Vocabulary\Responses\System\GiveUpREHASH.txt"
				Else
					ssh_ResponseFile = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Vocabulary\Responses\System\GiveUpREPEAT.txt"
				End If
				'StringClean = ResponseClean(StringClean)

			Else

				ssh_AskedToGiveUpSection = True
				ssh_AskedToGiveUp = True

				Dim GiveUpCheck As Integer

				If FrmSettings.NBEmpathy.Value = 1 Then GiveUpCheck = 0
				If FrmSettings.NBEmpathy.Value = 2 Then GiveUpCheck = 25
				If FrmSettings.NBEmpathy.Value = 3 Then GiveUpCheck = 50
				If FrmSettings.NBEmpathy.Value = 4 Then GiveUpCheck = 75
				If FrmSettings.NBEmpathy.Value = 5 Then GiveUpCheck = 1000

				Dim GiveUpVal As Integer = ssh_randomizer.Next(1, 101)

				'If GiveUpVal > GiveUpCheck Then
				If GiveUpVal > GiveUpCheck And Not ssh_LastScript Then
					' you can give up
					ssh_ResponseFile = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Vocabulary\Responses\System\GiveUpALLOWED.txt"
					ssh_LockImage = False
					If ssh_SlideshowLoaded = True Then
						nextButton.Enabled = True
						previousButton.Enabled = True
						PicStripTSMIdommeSlideshow.Enabled = True
					End If
					ssh_SubGaveUp = True
					ssh_FirstRound = False
				Else
					' you can't give up
					ssh_ResponseFile = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Vocabulary\Responses\System\GiveUpDENIED.txt"
				End If



			End If

			StringClean = ResponseClean(StringClean)

		End If


		If StringClean.Contains("@EndTease") Then
			SetVariable("SYS_SubLeftEarly", 0)
			'My.Settings.Sys_SubLeftEarly = 0
			StopEverything()
			ResetButton()
			ssh_ResetFlag = True
			ResumeSession()
			StringClean = StringClean.Replace("@EndTease", "")
		End If

		If StringClean.Contains("@FinishTease") Then
			ssh_TeaseTick = 0
			StringClean = StringClean.Replace("@FinishTease", "")
		End If

		If StringClean.Contains("@DommeLevelDown") Then
			If FrmSettings.domlevelNumBox.Value > 1 Then
				FrmSettings.domlevelNumBox.Value -= 1
			End If
			StringClean = StringClean.Replace("@DommeLevelDown", "")
		End If

		If StringClean.Contains("@ApathyLevelDown") Then
			If FrmSettings.NBEmpathy.Value > 1 Then
				FrmSettings.NBEmpathy.Value -= 1
			End If
			StringClean = StringClean.Replace("@ApathyLevelDown", "")
		End If

		If StringClean.Contains("@DommeLevelUp") Then
			If FrmSettings.domlevelNumBox.Value < 5 Then
				FrmSettings.domlevelNumBox.Value += 1
			End If
			StringClean = StringClean.Replace("@DommeLevelUp", "")
		End If

		If StringClean.Contains("@ApathyLevelUp") Then
			If FrmSettings.NBEmpathy.Value < 5 Then
				FrmSettings.NBEmpathy.Value += 1
			End If
			StringClean = StringClean.Replace("@ApathyLevelUp", "")
		End If

		If StringClean.Contains("@InterruptLongEdge") Then

			Dim EdgeList As New List(Of String)

			For Each EdgeFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Interrupt\Long Edge\", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
				'Debug.Print("EdgeFile = " & EdgeFile)
				EdgeList.Add(EdgeFile)
			Next

			'Debug.Print("EdgeList.Count = " & EdgeList.Count)

			If EdgeList.Count > 0 Then

				ssh_SubEdging = False
				ssh_SubHoldingEdge = False
				EdgeTauntTimer.Stop()
				StrokeTimer.Stop()
				StrokeTauntTimer.Stop()
				ssh_FileText = EdgeList(ssh_randomizer.Next(0, EdgeList.Count))
				ssh_LockImage = False
				ssh_MiniScript = False
				If ssh_SlideshowLoaded = True Then
					nextButton.Enabled = True
					previousButton.Enabled = True
					PicStripTSMIdommeSlideshow.Enabled = True
				End If
				ssh_StrokeTauntVal = -1
				ssh_ScriptTick = 3
				ScriptTimer.Start()
				ssh_ShowModule = True

			Else
				MessageBox.Show(Me, "No files were found in " & Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Interrupt\Long Edge!" & Environment.NewLine _
				 & Environment.NewLine & "Please make sure at lease one LongEdge_ file exists.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End If
			StringClean = StringClean.Replace("@InterruptLongEdge", "")
			ssh_JustShowedBlogImage = True
		End If

		If StringClean.Contains("@InterruptStartStroking") Then

			If ssh_CensorshipGame = True Or ssh_AvoidTheEdgeGame = True Or ssh_RLGLGame = True Then
				StringClean = "Ask me later"
				GoTo VTSkip
			End If

			Dim StrokeList As New List(Of String)

			For Each StrokeFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Interrupt\Start Stroking\", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
				'Debug.Print("EdgeFile = " & EdgeFile)
				StrokeList.Add(StrokeFile)
			Next

			'Debug.Print("EdgeList.Count = " & EdgeList.Count)

			If StrokeList.Count > 0 Then

				ssh_CBTCockFlag = False
				ssh_CBTBallsFlag = False
				ssh_CBTBothFlag = False
				ssh_CustomTask = False
				ssh_SubEdging = False
				ssh_SubHoldingEdge = False
				EdgeTauntTimer.Stop()
				StrokeTimer.Stop()
				StrokeTauntTimer.Stop()
				ssh_FileText = StrokeList(ssh_randomizer.Next(0, StrokeList.Count))
				ssh_LockImage = False
				If ssh_SlideshowLoaded = True Then
					nextButton.Enabled = True
					previousButton.Enabled = True
					PicStripTSMIdommeSlideshow.Enabled = True
				End If
				ssh_StrokeTauntVal = -1
				ssh_ScriptTick = 3
				ScriptTimer.Start()
				ssh_ShowModule = True
				ssh_MiniScript = False

			Else
				MessageBox.Show(Me, "No files were found in " & Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Interrupt\Start Stroking!" & Environment.NewLine _
				 & Environment.NewLine & "Please make sure at lease one StartStroking_ file exists.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End If
			StringClean = StringClean.Replace("@InterruptStartStroking", "")
			ssh_JustShowedBlogImage = True
		End If

		If StringClean.Contains("@Interrupt(") Then
			Dim InterruptClean As String = StringClean
			Dim StartIndex As Integer = InterruptClean.IndexOf("@Interrupt(") + 11
			For i As Integer = 1 To StartIndex
				InterruptClean = InterruptClean.Remove(0, 1)
			Next
			Dim InterruptS As String() = InterruptClean.Split(")")
			InterruptClean = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Interrupt\" & InterruptS(0) & ".txt"

			If File.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Interrupt\" & InterruptS(0) & ".txt") Then

				ssh_FirstRound = False
				ssh_CBTCockFlag = False
				ssh_CBTBallsFlag = False
				ssh_CBTBothFlag = False
				ssh_CustomTask = False
				ssh_SubEdging = False
				ssh_SubHoldingEdge = False
				StrokeTimer.Stop()
				StrokeTauntTimer.Stop()

				CensorshipTimer.Stop()
				RLGLTimer.Stop()
				TnASlides.Stop()
				AvoidTheEdge.Stop()
				EdgeTauntTimer.Stop()
				HoldEdgeTimer.Stop()
				HoldEdgeTauntTimer.Stop()
				AvoidTheEdgeTaunts.Stop()
				RLGLTauntTimer.Stop()
				VideoTauntTimer.Stop()
				EdgeCountTimer.Stop()

				ssh_FileText = InterruptClean
				ssh_LockImage = False
				If ssh_SlideshowLoaded = True Then
					nextButton.Enabled = True
					previousButton.Enabled = True
					PicStripTSMIdommeSlideshow.Enabled = True
				End If
				ssh_StrokeTauntVal = -1
				ssh_ScriptTick = 3
				ScriptTimer.Start()
				ssh_ShowModule = True

				ssh_MiniScript = False

			Else
				MessageBox.Show(Me, InterruptS(0) & ".txt was not found in " & Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Interrupt!" & Environment.NewLine _
				 & Environment.NewLine & "Please make sure the file exists and that it is spelled correctly in the script.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End If
			StringClean = StringClean.Replace("@Interrupt(" & InterruptS(0) & ")", "")
			'Debug.Print("StringClean INterrupt Remove = " & "@Interrupt(" & InterruptS(0) & ")")
			ssh_JustShowedBlogImage = True
		End If

		If StringClean.Contains("@BookmarkModule") Then
			ssh_BookmarkModule = True
			ssh_BookmarkModuleFile = ssh_FileText
			ssh_BookmarkModuleLine = ssh_StrokeTauntVal + 1
			StringClean = StringClean.Replace("@BookmarkModule", "")
		End If

		If StringClean.Contains("@BookmarkLink") Then
			ssh_BookmarkLink = True
			ssh_BookmarkLinkFile = ssh_FileText
			ssh_BookmarkLinkLine = ssh_StrokeTauntVal + 1
			StringClean = StringClean.Replace("@BookmarkLink", "")
		End If

		If StringClean.Contains("@AFKOn") Then
			ssh_AFK = True
			StringClean = StringClean.Replace("@AFKOn", "")
		End If

		If StringClean.Contains("@AFKOff") Then
			ssh_AFK = False
			StringClean = StringClean.Replace("@AFKOff", "")
		End If

		If StringClean.Contains("@Wait(") Then

			Dim WaitFlag As String = GetParentheses(StringClean, "Wait(")
			Dim WaitSeconds As Integer = Val(WaitFlag)

			If UCase(WaitFlag).Contains("M") Then WaitSeconds *= 60
			If UCase(WaitFlag).Contains("H") Then WaitSeconds *= 3600

			ssh_WaitTick = WaitSeconds
			WaitTimer.Start()

			StringClean = StringClean.Replace("@Wait(" & WaitFlag & ")", "")

		End If



		If StringClean.Contains("@SendDailyTasks") Then
			CreateTaskLetter()
			StringClean = StringClean.Replace("@SendDailyTasks", "")
		End If

		If StringClean.Contains("@EdgingHold") Then

			ssh_DomTypeCheck = True
			ssh_SubEdging = False
			ssh_SubStroking = False
			ssh_SubHoldingEdge = True
			EdgeTauntTimer.Stop()
			'DomChat = "#HoldTheEdge"
			'TypingDelay()

			ssh_HoldEdgeTick = ssh_HoldEdgeChance

			Dim HoldEdgeMin As Integer = FrmSettings.NBHoldTheEdgeMin.Value
			If FrmSettings.LBLMinHold.Text = "minutes" Then HoldEdgeMin *= 60

			Dim HoldEdgeMax As Integer = FrmSettings.NBHoldTheEdgeMax.Value
			If FrmSettings.LBLMaxHold.Text = "minutes" Then HoldEdgeMax *= 60

			If ssh_ExtremeHold = True Then
				HoldEdgeMin = FrmSettings.NBExtremeHoldMin.Value * 60
				HoldEdgeMax = FrmSettings.NBExtremeHoldMax.Value * 60
			End If

			If ssh_LongHold = True Then
				HoldEdgeMin = FrmSettings.NBLongHoldMin.Value * 60
				HoldEdgeMax = FrmSettings.NBLongHoldMax.Value * 60
			End If


			If HoldEdgeMax < HoldEdgeMin Then HoldEdgeMax = HoldEdgeMin + 1

			ssh_HoldEdgeTick = ssh_randomizer.Next(HoldEdgeMin, HoldEdgeMax + 1)
			If ssh_HoldEdgeTick < 10 Then ssh_HoldEdgeTick = 10

			ssh_HoldEdgeTime = 0

			HoldEdgeTimer.Start()
			HoldEdgeTauntTimer.Start()

			Do
				Application.DoEvents()
			Loop Until ssh_DomTypeCheck = False


			StringClean = StringClean.Replace("@EdgingHold", "")
		End If

		If StringClean.Contains("@EdgingStop") Then

			ssh_DomTypeCheck = True
			ssh_SubEdging = False
			ssh_SubStroking = False
			EdgeTauntTimer.Stop()
			'DomChat = "#StopStrokingEdge"
			'TypingDelay()

			Do
				Application.DoEvents()
			Loop Until ssh_DomTypeCheck = False

			StringClean = StringClean.Replace("@EdgingStop", "")
		End If

		'Github Patch  If StringClean.Contains("@EdgingDecide") Then
		If StringClean.Contains("@DecideEdge") Then

			ssh_TempVal = ssh_randomizer.Next(0, 101)

			If ssh_TempVal < 51 Then

				ssh_DomTypeCheck = True
				ssh_SubEdging = False
				ssh_SubStroking = False
				ssh_SubHoldingEdge = True
				EdgeTauntTimer.Stop()
				StrokePace = 0
				ssh_DomChat = "#HoldTheEdge"
				If ssh_Contact1Stroke = True Then
					ssh_DomChat = "@Contact1 #HoldTheEdge"
					' Github Patch Contact1Stroke = False
				End If
				If ssh_Contact2Stroke = True Then
					ssh_DomChat = "@Contact2 #HoldTheEdge"
					' Github Patch Contact2Stroke = False
				End If
				If ssh_Contact3Stroke = True Then
					ssh_DomChat = "@Contact3 #HoldTheEdge"
					' Github Patch Contact3Stroke = False
				End If
				TypingDelay()

				ssh_HoldEdgeTick = ssh_HoldEdgeChance

				Dim HoldEdgeMin As Integer = FrmSettings.NBHoldTheEdgeMin.Value
				If FrmSettings.LBLMinHold.Text = "minutes" Then HoldEdgeMin *= 60

				Dim HoldEdgeMax As Integer = FrmSettings.NBHoldTheEdgeMax.Value
				If FrmSettings.LBLMaxHold.Text = "minutes" Then HoldEdgeMax *= 60

				If HoldEdgeMax < HoldEdgeMin Then HoldEdgeMax = HoldEdgeMin + 1

				ssh_HoldEdgeTick = ssh_randomizer.Next(HoldEdgeMin, HoldEdgeMax + 1)
				If ssh_HoldEdgeTick < 10 Then ssh_HoldEdgeTick = 10

				ssh_HoldEdgeTime = 0

				HoldEdgeTimer.Start()
				HoldEdgeTauntTimer.Start()

			Else

				ssh_DomTypeCheck = True
				ssh_SubEdging = False
				ssh_SubStroking = False
				EdgeTauntTimer.Stop()
				ssh_DomChat = "#StopStrokingEdge"
				If ssh_Contact1Stroke = True Then
					ssh_DomChat = "@Contact1 #StopStrokingEdge"
					ssh_Contact1Stroke = False
				End If
				If ssh_Contact2Stroke = True Then
					ssh_DomChat = "@Contact2 #StopStrokingEdge"
					ssh_Contact2Stroke = False
				End If
				If ssh_Contact3Stroke = True Then
					ssh_DomChat = "@Contact3 #StopStrokingEdge"
					ssh_Contact3Stroke = False
				End If
				TypingDelay()

			End If

			Do
				Application.DoEvents()
			Loop Until ssh_DomTypeCheck = False


			StringClean = StringClean.Replace("@DecideEdge", "")
		End If

		If StringClean.Contains("@CheckVideo") Then
			ssh_VideoCheck = True
			RandomVideo()
			If ssh_NoVideo = True Then
				ssh_FileGoto = "(No Videos Found)"
			Else
				ssh_FileGoto = "(Videos Found)"
			End If
			ssh_VideoCheck = False
			ssh_NoVideo = False
			ssh_SkipGotoLine = True
			GetGoto()
			StringClean = StringClean.Replace("@CheckVideo", "")
		End If

		If StringClean.Contains("@PlayCensorshipSucks") Then

			RandomVideo()

			If ssh_NoVideo = False Then
				ssh_ScriptVideoTease = "Censorship Sucks"
				ssh_ScriptVideoTeaseFlag = True
				ssh_ScriptVideoTeaseFlag = False
				ssh_CensorshipGame = True
				ssh_VideoTease = True
				ssh_CensorshipTick = ssh_randomizer.Next(FrmSettings.NBCensorHideMin.Value, FrmSettings.NBCensorHideMax.Value + 1)
				CensorshipTimer.Start()
			End If

			StringClean = StringClean.Replace("@PlayCensorshipSucks", "")
		End If

		If StringClean.Contains("@VitalSubAssignment") Then
			' Read all lines of the given file.
			Dim AssignList As List(Of String) = Txt2List(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Apps\VitalSub\Assignments.txt")

			Dim TempAssign As String

			Try
				AssignList = FilterList(AssignList)
				TempAssign = AssignList(ssh_randomizer.Next(0, AssignList.Count))
			Catch
				TempAssign = "ERROR: VitalSub Assign"
			End Try

			Dim TempArray As String() = Split(TempAssign)

			For i As Integer = TempArray.Count - 1 To 0 Step -1
				If TempArray(i).Contains("@") Then TempArray(i) = ""
			Next


			CLBExercise.Items.Add(TempAssign)
			SaveExercise()
			CBVitalSubDomTask.Checked = False
			My.Settings.VitalSubAssignments = False
			StringClean = StringClean.Replace("@VitalSubAssignment", "")
		End If

		If StringClean.Contains("@PlayAvoidTheEdge") Then
			' #### Reboot

			RandomVideo()

			If ssh_NoVideo = False Then

				ScriptTimer.Stop()
				ssh_SubStroking = True
				ssh_TempStrokeTauntVal = ssh_StrokeTauntVal
				ssh_TempFileText = ssh_FileText
				ssh_ScriptVideoTease = "Avoid The Edge"
				ssh_ScriptVideoTeaseFlag = True
				ssh_AvoidTheEdgeStroking = True
				ssh_AvoidTheEdgeGame = True
				ssh_ScriptVideoTeaseFlag = False
				ssh_VideoTease = True
				ssh_StartStrokingCount += 1
				ssh_StopMetronome = False
				StrokePace = ssh_randomizer.Next(NBMaxPace.Value, NBMinPace.Value + 1)
				StrokePace = 50 * Math.Round(StrokePace / 50)
				ssh_AvoidTheEdgeTick = 120 / FrmSettings.TauntSlider.Value
				AvoidTheEdgeTaunts.Start()

			End If

			StringClean = StringClean.Replace("@PlayAvoidTheEdge", "")
		End If

		If StringClean.Contains("@ResumeAvoidTheEdge") Then
			DomWMP.Ctlcontrols.play()
			ScriptTimer.Stop()
			ssh_AvoidTheEdgeStroking = True
			ssh_SubStroking = True
			ssh_StartStrokingCount += 1
			ssh_StopMetronome = False
			ssh_VideoTease = True
			StrokePace = ssh_randomizer.Next(NBMaxPace.Value, NBMinPace.Value + 1)
			StrokePace = 50 * Math.Round(StrokePace / 50)
			ssh_AvoidTheEdgeTick = 120 / FrmSettings.TauntSlider.Value
			AvoidTheEdgeTaunts.Start()
			StringClean = StringClean.Replace("@ResumeAvoidTheEdge", "")
		End If

		If StringClean.Contains("@PlayRedLightGreenLight") Then
			' #### Reboot

			RandomVideo()

			If ssh_NoVideo = False Then

				ScriptTimer.Stop()
				ssh_SubStroking = True
				ssh_TempStrokeTauntVal = ssh_StrokeTauntVal
				ssh_TempFileText = ssh_FileText
				ssh_ScriptVideoTease = "RLGL"
				ssh_ScriptVideoTeaseFlag = True
				'AvoidTheEdgeStroking = True
				ssh_RLGLGame = True

				ssh_ScriptVideoTeaseFlag = False
				ssh_VideoTease = True
				ssh_RLGLTick = ssh_randomizer.Next(FrmSettings.NBGreenLightMin.Value, FrmSettings.NBGreenLightMax.Value + 1)
				RLGLTimer.Start()
				ssh_StartStrokingCount += 1
				ssh_StopMetronome = False
				StrokePace = ssh_randomizer.Next(NBMaxPace.Value, NBMinPace.Value + 1)
				StrokePace = 50 * Math.Round(StrokePace / 50)
				'VideoTauntTick = randomizer.Next(20, 31)
				'VideoTauntTimer.Start()

			End If
			StringClean = StringClean.Replace("@PlayRedLightGreenLight", "")
		End If

		If StringClean.Contains("@PlayVideo[") Then

			Dim VideoFlag As String = GetParentheses(StringClean, "@PlayVideo[")
			Dim VideoClean As String

			If StringClean.Contains("@JumpVideo") Then
				ssh_JumpVideo = True
				StringClean = StringClean.Replace("@JumpVideo", "")
			End If

			If VideoFlag.Contains(":\") Then
				VideoClean = VideoFlag

				If File.Exists(VideoClean) Then
					DomWMP.URL = VideoClean
					DomWMP.Visible = True
					mainPictureBox.Visible = False
					ssh_TeaseVideo = True

					If ssh_JumpVideo = True Then

						Do
							Application.DoEvents()
						Loop Until (DomWMP.playState = WMPLib.WMPPlayState.wmppsPlaying)

						Dim VideoLength As Integer = DomWMP.currentMedia.duration
						Dim VidLow As Integer = VideoLength * 0.4
						Dim VidHigh As Integer = VideoLength * 0.9
						Dim VidPoint As Integer = ssh_randomizer.Next(VidLow, VidHigh)

						DomWMP.Ctlcontrols.currentPosition = VideoLength - VidPoint

					End If

					ssh_JumpVideo = False

				Else
					MessageBox.Show(Me, Path.GetFileName(VideoClean) & " was not found in " & Path.GetDirectoryName(VideoClean) & "!" & Environment.NewLine & Environment.NewLine &
					 "Please make sure the file exists and that it is spelled correctly in the script.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End If

				GoTo ExternalVideo

			Else
				VideoClean = Application.StartupPath & "\Video\" & VideoFlag
				VideoClean = VideoClean.Replace("\\", "\")
			End If



			Debug.Print("VideoFlag = " & VideoFlag)

			If VideoClean.Contains("*") Then

				Dim VideoList As New List(Of String)

				For Each foundFile As String In My.Computer.FileSystem.GetFiles(Path.GetDirectoryName(VideoClean), FileIO.SearchOption.SearchTopLevelOnly, Path.GetFileName(VideoClean))
					VideoList.Add(foundFile)
				Next

				If VideoList.Count > 0 Then
					DomWMP.URL = VideoList(ssh_randomizer.Next(0, VideoList.Count))
					DomWMP.Visible = True
					mainPictureBox.Visible = False
					ssh_TeaseVideo = True

					If ssh_JumpVideo = True Then

						Do
							Application.DoEvents()
						Loop Until (DomWMP.playState = WMPLib.WMPPlayState.wmppsPlaying)

						Dim VideoLength As Integer = DomWMP.currentMedia.duration
						Dim VidLow As Integer = VideoLength * 0.4
						Dim VidHigh As Integer = VideoLength * 0.9
						Dim VidPoint As Integer = ssh_randomizer.Next(VidLow, VidHigh)

						DomWMP.Ctlcontrols.currentPosition = VideoLength - VidPoint

					End If

					ssh_JumpVideo = False
				Else
					MessageBox.Show(Me, "No videos matching " & Path.GetFileName(VideoClean) & " were found in " & Path.GetDirectoryName(VideoClean) & "!" & Environment.NewLine & Environment.NewLine &
					  "Please make sure that valid files exist and that the wildcards are applied correctly in the script.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End If

			Else

				If File.Exists(VideoClean) Then
					DomWMP.URL = VideoClean
					DomWMP.Visible = True
					mainPictureBox.Visible = False
					ssh_TeaseVideo = True

					If ssh_JumpVideo = True Then

						Do
							Application.DoEvents()
						Loop Until (DomWMP.playState = WMPLib.WMPPlayState.wmppsPlaying)

						Dim VideoLength As Integer = DomWMP.currentMedia.duration
						Dim VidLow As Integer = VideoLength * 0.4
						Dim VidHigh As Integer = VideoLength * 0.9
						Dim VidPoint As Integer = ssh_randomizer.Next(VidLow, VidHigh)

						DomWMP.Ctlcontrols.currentPosition = VideoLength - VidPoint

					End If

					ssh_JumpVideo = False

				Else
					MessageBox.Show(Me, Path.GetFileName(VideoClean) & " was not found in " & Application.StartupPath & "\Video!" & Environment.NewLine & Environment.NewLine &
					 "Please make sure the file exists and that it is spelled correctly in the script.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End If

			End If

ExternalVideo:

			StringClean = StringClean.Replace("@PlayVideo[" & VideoFlag & "]", "")
		End If

		If StringClean.Contains("@PlayAudio[") Then

			Dim AudioFlag As String = GetParentheses(StringClean, "@PlayAudio[")
			' Github Patch Dim AudioClean As String = Application.StartupPath & "\Video\" & AudioFlag
			Dim AudioClean As String

			If AudioFlag.Contains(":\") And Not AudioFlag.Contains("*") Then
				AudioClean = AudioFlag

				If File.Exists(AudioClean) Then
					DomWMP.URL = AudioClean
				Else
					MessageBox.Show(Me, Path.GetFileName(AudioClean) & " was not found in " & Path.GetDirectoryName(AudioClean) & "!" & Environment.NewLine & Environment.NewLine &
					 "Please make sure the file exists and that it is spelled correctly in the script.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End If

				GoTo ExternalAudio

			Else

				AudioClean = Application.StartupPath & "\Audio\" & AudioFlag
				AudioClean = AudioClean.Replace("\\", "\")
			End If



			If AudioClean.Contains("*") Then

				Dim AudioList As New List(Of String)

				For Each foundFile As String In My.Computer.FileSystem.GetFiles(Path.GetDirectoryName(AudioClean), FileIO.SearchOption.SearchTopLevelOnly, Path.GetFileName(AudioClean))
					AudioList.Add(foundFile)
				Next

				If AudioList.Count > 0 Then
					DomWMP.URL = AudioList(ssh_randomizer.Next(0, AudioList.Count))
				Else
					MessageBox.Show(Me, "No audio files matching " & Path.GetFileName(AudioClean) & " were found in " & Path.GetDirectoryName(AudioClean) & "!" & Environment.NewLine & Environment.NewLine &
					  "Please make sure that valid files exist and that the wildcards are applied correctly in the script.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End If

			Else


				If File.Exists(AudioClean) Then
					DomWMP.URL = AudioClean
				Else
					MessageBox.Show(Me, Path.GetFileName(AudioClean) & " was not found in " & Application.StartupPath & "\Audio!" & Environment.NewLine & Environment.NewLine &
					 "Please make sure the file exists and that it is spelled correctly in the script.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End If

			End If

ExternalAudio:

			StringClean = StringClean.Replace("@PlayAudio[" & AudioFlag & "]", "")

		End If


		If StringClean.Contains("@PlayVideo(") Then


			Dim VidFlag As String = GetParentheses(StringClean, "@PlayVideo(")
			Dim VidInt As Integer = Val(VidFlag)
			If UCase(VidFlag).Contains("M") Then VidInt *= 60

			If StringClean.Contains("@JumpVideo") Then
				ssh_JumpVideo = True
				StringClean = StringClean.Replace("@JumpVideo", "")
			End If

			ssh_RandomizerVideo = True
			RandomVideo()

			If ssh_NoVideo = False Then
				ssh_TeaseVideo = True
				ssh_VideoTick = VidInt
				VideoTimer.Start()
			Else
				MessageBox.Show(Me, "No videos were found!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End If

			ssh_RandomizerVideo = False
			StringClean = StringClean.Replace("@PlayVideo", "")
		End If





		If StringClean.Contains("@PlayVideo") Then

			If StringClean.Contains("@JumpVideo") Then
				ssh_JumpVideo = True
				StringClean = StringClean.Replace("@JumpVideo", "")
			End If

			ssh_RandomizerVideo = True
			RandomVideo()

			If ssh_NoVideo = False Then
				ssh_TeaseVideo = True
			Else
				MessageBox.Show(Me, "No videos were found!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End If

			ssh_RandomizerVideo = False
			StringClean = StringClean.Replace("@PlayVideo", "")
		End If

		If StringClean.Contains("@JumpVideo") Then

			If (DomWMP.playState = WMPLib.WMPPlayState.wmppsPlaying) Then
				Dim VideoLength As Integer = DomWMP.currentMedia.duration
				Dim VidLow As Integer = VideoLength * 0.4
				Dim VidHigh As Integer = VideoLength * 0.9
				Dim VidPoint As Integer = ssh_randomizer.Next(VidLow, VidHigh)

				Debug.Print("VidLow = " & VidLow)
				Debug.Print("VidHigh = " & VidHigh)
				Debug.Print("VidPoint = " & VidPoint)

				DomWMP.Ctlcontrols.currentPosition = VideoLength - VidPoint

			End If
			StringClean = StringClean.Replace("@JumpVideo", "")
		End If


		If StringClean.Contains("@AddStrokeTime(") Then

			Dim OriginalFlag As String = ""

			If StrokeTimer.Enabled = True Then

				Dim StrokeFlag As String = GetParentheses(StringClean, "@AddStrokeTime(")
				OriginalFlag = StrokeFlag
				Dim StrokeSeconds As Integer

				If StrokeFlag.Contains(",") Then
					StrokeFlag = FixCommas(StrokeFlag)
					Dim StrokeFlagArray As String() = StrokeFlag.Split(",")
					Dim Stroke1 As Integer = Val(StrokeFlagArray(0))
					Dim Stroke2 As Integer = Val(StrokeFlagArray(1))
					If UCase(StrokeFlagArray(0)).Contains("M") Then Stroke1 *= 60
					If UCase(StrokeFlagArray(1)).Contains("M") Then Stroke2 *= 60
					If UCase(StrokeFlagArray(0)).Contains("H") Then Stroke1 *= 3600
					If UCase(StrokeFlagArray(1)).Contains("H") Then Stroke2 *= 3600
					StrokeSeconds = ssh_randomizer.Next(Stroke1, Stroke2 + 1)
				Else
					StrokeSeconds = Val(StrokeFlag)
					If UCase(GetParentheses(StringClean, "@AddStrokeTime(")).Contains("M") Then StrokeSeconds *= 60
					If UCase(GetParentheses(StringClean, "@AddStrokeTime(")).Contains("H") Then StrokeSeconds *= 3600
				End If
				ssh_StrokeTick += StrokeSeconds
			End If
			StringClean = StringClean.Replace("@AddStrokeTime(" & OriginalFlag & ")", "")
		End If

		If StringClean.Contains("@RemoveStrokeTime(") Then

			Dim OriginalFlag As String = ""

			If StrokeTimer.Enabled = True Then

				Dim StrokeFlag As String = GetParentheses(StringClean, "@RemoveStrokeTime(")
				OriginalFlag = StrokeFlag
				Dim StrokeSeconds As Integer

				If StrokeFlag.Contains(",") Then
					StrokeFlag = FixCommas(StrokeFlag)
					Dim StrokeFlagArray As String() = StrokeFlag.Split(",")
					Dim Stroke1 As Integer = Val(StrokeFlagArray(0))
					Dim Stroke2 As Integer = Val(StrokeFlagArray(1))
					If UCase(StrokeFlagArray(0)).Contains("M") Then Stroke1 *= 60
					If UCase(StrokeFlagArray(1)).Contains("M") Then Stroke2 *= 60
					If UCase(StrokeFlagArray(0)).Contains("H") Then Stroke1 *= 3600
					If UCase(StrokeFlagArray(1)).Contains("H") Then Stroke2 *= 3600
					StrokeSeconds = ssh_randomizer.Next(Stroke1, Stroke2 + 1)
				Else
					StrokeSeconds = Val(StrokeFlag)
					If UCase(GetParentheses(StringClean, "@RemoveStrokeTime(")).Contains("M") Then StrokeSeconds *= 60
					If UCase(GetParentheses(StringClean, "@RemoveStrokeTime(")).Contains("H") Then StrokeSeconds *= 3600
				End If
				ssh_StrokeTick -= StrokeSeconds
				If ssh_StrokeTick < 0 Then ssh_StrokeTick = 5
			End If
			StringClean = StringClean.Replace("@RemoveStrokeTime(" & OriginalFlag & ")", "")
		End If



		If StringClean.Contains("@AddStrokeTime") Then
			If StrokeTimer.Enabled = True Then
				If FrmSettings.CBTauntCycleDD.Checked = True Then
					If FrmSettings.domlevelNumBox.Value = 1 Then ssh_StrokeTick += ssh_randomizer.Next(1, 3) * 60
					If FrmSettings.domlevelNumBox.Value = 2 Then ssh_StrokeTick += ssh_randomizer.Next(1, 4) * 60
					If FrmSettings.domlevelNumBox.Value = 3 Then ssh_StrokeTick += ssh_randomizer.Next(3, 6) * 60
					If FrmSettings.domlevelNumBox.Value = 4 Then ssh_StrokeTick += ssh_randomizer.Next(4, 8) * 60
					If FrmSettings.domlevelNumBox.Value = 5 Then ssh_StrokeTick += ssh_randomizer.Next(5, 11) * 60
				Else
					ssh_StrokeTick += ssh_randomizer.Next(FrmSettings.NBTauntCycleMin.Value * 60, FrmSettings.NBTauntCycleMax.Value * 60)
				End If
			End If
			StringClean = StringClean.Replace("@AddStrokeTime", "")
		End If

		If StringClean.Contains("@RemoveStrokeTime") Then
			If StrokeTimer.Enabled = True Then
				ssh_StrokeTick -= ssh_StrokeTick / 2
			End If
			StringClean = StringClean.Replace("@RemoveStrokeTime", "")
		End If


		If StringClean.Contains("@AddEdgeHoldTime(") Then

			Dim OriginalFlag As String = ""

			If HoldEdgeTimer.Enabled = True Then

				Dim HoldEdgeFlag As String = GetParentheses(StringClean, "@AddEdgeHoldTime(")
				OriginalFlag = HoldEdgeFlag
				Dim HoldEdgeSeconds As Integer

				If HoldEdgeFlag.Contains(",") Then
					HoldEdgeFlag = FixCommas(HoldEdgeFlag)
					Dim HoldEdgeFlagArray As String() = HoldEdgeFlag.Split(",")
					Dim HoldEdge1 As Integer = Val(HoldEdgeFlagArray(0))
					Dim HoldEdge2 As Integer = Val(HoldEdgeFlagArray(1))
					If UCase(HoldEdgeFlagArray(0)).Contains("M") Then HoldEdge1 *= 60
					If UCase(HoldEdgeFlagArray(1)).Contains("M") Then HoldEdge2 *= 60
					If UCase(HoldEdgeFlagArray(0)).Contains("H") Then HoldEdge1 *= 3600
					If UCase(HoldEdgeFlagArray(1)).Contains("H") Then HoldEdge2 *= 3600
					HoldEdgeSeconds = ssh_randomizer.Next(HoldEdge1, HoldEdge2 + 1)
				Else
					HoldEdgeSeconds = Val(HoldEdgeFlag)
					If UCase(GetParentheses(StringClean, "@AddEdgeHoldTime(")).Contains("M") Then HoldEdgeSeconds *= 60
					If UCase(GetParentheses(StringClean, "@AddEdgeHoldTime(")).Contains("H") Then HoldEdgeSeconds *= 3600
				End If
				ssh_HoldEdgeTick += HoldEdgeSeconds
			End If
			StringClean = StringClean.Replace("@AddEdgeHoldTime(" & OriginalFlag & ")", "")
		End If

		If StringClean.Contains("@RemoveEdgeHoldTime(") Then

			Dim OriginalFlag As String = ""

			If HoldEdgeTimer.Enabled = True Then

				Dim HoldEdgeFlag As String = GetParentheses(StringClean, "@RemoveEdgeHoldTime(")
				OriginalFlag = HoldEdgeFlag
				Dim HoldEdgeSeconds As Integer

				If HoldEdgeFlag.Contains(",") Then
					HoldEdgeFlag = FixCommas(HoldEdgeFlag)
					Dim HoldEdgeFlagArray As String() = HoldEdgeFlag.Split(",")
					Dim HoldEdge1 As Integer = Val(HoldEdgeFlagArray(0))
					Dim HoldEdge2 As Integer = Val(HoldEdgeFlagArray(1))
					If UCase(HoldEdgeFlagArray(0)).Contains("M") Then HoldEdge1 *= 60
					If UCase(HoldEdgeFlagArray(1)).Contains("M") Then HoldEdge2 *= 60
					If UCase(HoldEdgeFlagArray(0)).Contains("H") Then HoldEdge1 *= 3600
					If UCase(HoldEdgeFlagArray(1)).Contains("H") Then HoldEdge2 *= 3600
					HoldEdgeSeconds = ssh_randomizer.Next(HoldEdge1, HoldEdge2 + 1)
				Else
					HoldEdgeSeconds = Val(HoldEdgeFlag)
					If UCase(GetParentheses(StringClean, "@RemoveEdgeHoldTime(")).Contains("M") Then HoldEdgeSeconds *= 60
					If UCase(GetParentheses(StringClean, "@RemoveEdgeHoldTime(")).Contains("H") Then HoldEdgeSeconds *= 3600
				End If
				ssh_HoldEdgeTick -= HoldEdgeSeconds
				If ssh_HoldEdgeTick < 5 Then ssh_HoldEdgeTick = 5
			End If
			StringClean = StringClean.Replace("@RemoveEdgeHoldTime(" & OriginalFlag & ")", "")
		End If


		If StringClean.Contains("@AddEdgeHoldTime") Then

			If HoldEdgeTimer.Enabled = True Then
				Dim HoldEdgeMin As Integer = FrmSettings.NBHoldTheEdgeMin.Value
				If FrmSettings.LBLMinHold.Text = "minutes" Then HoldEdgeMin *= 60

				Dim HoldEdgeMax As Integer = FrmSettings.NBHoldTheEdgeMax.Value
				If FrmSettings.LBLMaxHold.Text = "minutes" Then HoldEdgeMax *= 60

				If HoldEdgeMax < HoldEdgeMin Then HoldEdgeMax = HoldEdgeMin + 1

				ssh_HoldEdgeTick += ssh_randomizer.Next(HoldEdgeMin, HoldEdgeMax + 1)
				If ssh_HoldEdgeTick < 10 Then ssh_HoldEdgeTick = 10
			End If
			StringClean = StringClean.Replace("@AddEdgeHoldTime", "")
		End If

		If StringClean.Contains("@RemoveEdgeHoldTime") Then
			If HoldEdgeTimer.Enabled = True Then
				ssh_HoldEdgeTick = ssh_HoldEdgeTick / 2
				If ssh_HoldEdgeTick < 10 Then ssh_HoldEdgeTick = 10
			End If
			StringClean = StringClean.Replace("@RemoveEdgeHoldTime", "")
		End If

		If StringClean.Contains("@AddTeaseTime(") Then

			Dim OriginalFlag As String = ""

			If TeaseTimer.Enabled = True Then

				Dim TeaseFlag As String = GetParentheses(StringClean, "@AddTeaseTime(")
				OriginalFlag = TeaseFlag
				Dim TeaseSeconds As Integer

				If TeaseFlag.Contains(",") Then
					TeaseFlag = FixCommas(TeaseFlag)
					Dim TeaseFlagArray As String() = TeaseFlag.Split(",")
					Dim Tease1 As Integer = Val(TeaseFlagArray(0))
					Dim Tease2 As Integer = Val(TeaseFlagArray(1))
					If UCase(TeaseFlagArray(0)).Contains("M") Then Tease1 *= 60
					If UCase(TeaseFlagArray(1)).Contains("M") Then Tease2 *= 60
					If UCase(TeaseFlagArray(0)).Contains("H") Then Tease1 *= 3600
					If UCase(TeaseFlagArray(1)).Contains("H") Then Tease2 *= 3600
					TeaseSeconds = ssh_randomizer.Next(Tease1, Tease2 + 1)
				Else
					TeaseSeconds = Val(TeaseFlag)
					If UCase(GetParentheses(StringClean, "@AddTeaseTime(")).Contains("M") Then TeaseSeconds *= 60
					If UCase(GetParentheses(StringClean, "@AddTeaseTime(")).Contains("H") Then TeaseSeconds *= 3600
				End If
				ssh_TeaseTick += TeaseSeconds
			End If
			StringClean = StringClean.Replace("@AddTeaseTime(" & OriginalFlag & ")", "")
		End If

		If StringClean.Contains("@RemoveTeaseTime(") Then

			Dim OriginalFlag As String = ""

			If TeaseTimer.Enabled = True Then

				Dim TeaseFlag As String = GetParentheses(StringClean, "@RemoveTeaseTime(")
				OriginalFlag = TeaseFlag
				Dim TeaseSeconds As Integer

				If TeaseFlag.Contains(",") Then
					TeaseFlag = FixCommas(TeaseFlag)
					Dim TeaseFlagArray As String() = TeaseFlag.Split(",")
					Dim Tease1 As Integer = Val(TeaseFlagArray(0))
					Dim Tease2 As Integer = Val(TeaseFlagArray(1))
					If UCase(TeaseFlagArray(0)).Contains("M") Then Tease1 *= 60
					If UCase(TeaseFlagArray(1)).Contains("M") Then Tease2 *= 60
					If UCase(TeaseFlagArray(0)).Contains("H") Then Tease1 *= 3600
					If UCase(TeaseFlagArray(1)).Contains("H") Then Tease2 *= 3600
					TeaseSeconds = ssh_randomizer.Next(Tease1, Tease2 + 1)
				Else
					TeaseSeconds = Val(TeaseFlag)
					If UCase(GetParentheses(StringClean, "@RemoveTeaseTime(")).Contains("M") Then TeaseSeconds *= 60
					If UCase(GetParentheses(StringClean, "@RemoveTeaseTime(")).Contains("H") Then TeaseSeconds *= 3600
				End If
				ssh_TeaseTick -= TeaseSeconds
				If ssh_TeaseTick < 5 Then ssh_TeaseTick = 5
			End If
			StringClean = StringClean.Replace("@RemoveTeaseTime(" & OriginalFlag & ")", "")
		End If

		If StringClean.Contains("@AddTeaseTime") Then
			If TeaseTimer.Enabled = True Then
				If FrmSettings.CBTeaseLengthDD.Checked = True Then
					If FrmSettings.domlevelNumBox.Value = 1 Then ssh_TeaseTick += ssh_randomizer.Next(10, 16) * 60
					If FrmSettings.domlevelNumBox.Value = 2 Then ssh_TeaseTick += ssh_randomizer.Next(15, 21) * 60
					If FrmSettings.domlevelNumBox.Value = 3 Then ssh_TeaseTick += ssh_randomizer.Next(20, 31) * 60
					If FrmSettings.domlevelNumBox.Value = 4 Then ssh_TeaseTick += ssh_randomizer.Next(30, 46) * 60
					If FrmSettings.domlevelNumBox.Value = 5 Then ssh_TeaseTick += ssh_randomizer.Next(45, 61) * 60
				Else
					ssh_TeaseTick += ssh_randomizer.Next(FrmSettings.NBTeaseLengthMin.Value * 60, FrmSettings.NBTeaseLengthMax.Value * 60)
				End If
			End If
			StringClean = StringClean.Replace("@AddTeaseTime", "")
		End If

		If StringClean.Contains("@RemoveTeaseTime") Then
			If TeaseTimer.Enabled = True Then
				ssh_TeaseTick = ssh_TeaseTick / 2
			End If
			StringClean = StringClean.Replace("@RemoveTeaseTime", "")
		End If

		If StringClean.Contains("@PlaylistOff") Then
			ssh_Playlist = False
			StringClean = StringClean.Replace("@PlaylistOff", "")
		End If

		If StringClean.Contains("@RapidTextOn") Or StringClean.Contains("@RTOn") Then
			ssh_RapidFire = True
			StringClean = StringClean.Replace("@RapidTextOn", "")
			StringClean = StringClean.Replace("@RTOn", "")
		End If

		If StringClean.Contains("@RapidTextOff") Or StringClean.Contains("@RTOff") Then
			ssh_RapidFire = False
			StringClean = StringClean.Replace("@RapidTextOff", "")
			StringClean = StringClean.Replace("@RTOff", "")
		End If

		If StringClean.Contains("@AddContact1") Or StringClean.Contains("@RemoveContact1") Then
			ssh_AddContactTick = 2
			Contact1Timer.Start()
			StringClean = StringClean.Replace("@AddContact1", "")
			StringClean = StringClean.Replace("@RemoveContact1", "")
		End If

		If StringClean.Contains("@AddContact2") Or StringClean.Contains("@RemoveContact2") Then
			ssh_AddContactTick = 2
			Contact2Timer.Start()
			StringClean = StringClean.Replace("@AddContact2", "")
			StringClean = StringClean.Replace("@RemoveContact2", "")
		End If

		If StringClean.Contains("@AddContact3") Or StringClean.Contains("@RemoveContact3") Then
			ssh_AddContactTick = 2
			Contact3Timer.Start()
			StringClean = StringClean.Replace("@AddContact3", "")
			StringClean = StringClean.Replace("@RemoveContact3", "")
		End If

		If StringClean.Contains("@AddDomme") Or StringClean.Contains("@RemoveDomme") Then
			ssh_AddContactTick = 2
			DommeTimer.Start()
			StringClean = StringClean.Replace("@AddDomme", "")
			StringClean = StringClean.Replace("@RemoveDomme", "")
		End If


		If StringClean.Contains("@NullResponse") Then
			ssh_NullResponse = True
			StringClean = StringClean.Replace("@NullResponse", "")
			'Debug.Print("NullResponse Called")
		End If

VTSkip:

		If StringClean.Contains("@SpeedUpCheck") Then

			If ssh_AskedToSpeedUp = True Then
				ssh_ResponseFile = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Vocabulary\Responses\System\SpeedUpREPEAT.txt"
				StringClean = ResponseClean(StringClean)

			Else

				If StrokePace < 201 Then
					ssh_ResponseFile = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Vocabulary\Responses\System\SpeedUpMAX.txt"
					StringClean = ResponseClean(StringClean)

				Else

					Dim SpeedUpCheck As Integer

					If FrmSettings.domlevelNumBox.Value = 1 Then SpeedUpCheck = 70
					If FrmSettings.domlevelNumBox.Value = 2 Then SpeedUpCheck = 40
					If FrmSettings.domlevelNumBox.Value = 3 Then SpeedUpCheck = 60
					If FrmSettings.domlevelNumBox.Value = 4 Then SpeedUpCheck = 50
					If FrmSettings.domlevelNumBox.Value = 5 Then SpeedUpCheck = 65

					Dim SpeedUpVal As Integer = ssh_randomizer.Next(1, 101)

					If SpeedUpVal > SpeedUpCheck Then

						' you can speed up
						ssh_ResponseFile = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Vocabulary\Responses\System\SpeedUpALLOWED.txt"

					Else

						' you can't speed up
						ssh_AskedToSpeedUp = True
						ssh_ResponseFile = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Vocabulary\Responses\System\SpeedUpDENIED.txt"

					End If

					StringClean = ResponseClean(StringClean)

				End If

			End If

			StringClean = StringClean.Replace("@SpeedUpCheck", "")
			GoTo RinseLatherRepeat
		End If


		If StringClean.Contains("@SlowDownCheck") Then

			If ssh_AskedToSpeedUp = True Then
				ssh_ResponseFile = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Vocabulary\Responses\System\SlowDownREPEAT.txt"
				StringClean = ResponseClean(StringClean)

			Else

				If StrokePace > 999 Then
					ssh_ResponseFile = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Vocabulary\Responses\System\SlowDownMIN.txt"
					StringClean = ResponseClean(StringClean)

				Else

					Dim SpeedUpCheck As Integer

					If FrmSettings.domlevelNumBox.Value = 1 Then SpeedUpCheck = 70
					If FrmSettings.domlevelNumBox.Value = 2 Then SpeedUpCheck = 40
					If FrmSettings.domlevelNumBox.Value = 3 Then SpeedUpCheck = 60
					If FrmSettings.domlevelNumBox.Value = 4 Then SpeedUpCheck = 50
					If FrmSettings.domlevelNumBox.Value = 5 Then SpeedUpCheck = 65

					Dim SpeedUpVal As Integer = ssh_randomizer.Next(1, 101)

					If SpeedUpVal > SpeedUpCheck Then

						' you can speed up
						ssh_ResponseFile = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Vocabulary\Responses\System\SlowDownALLOWED.txt"

					Else

						' you can't speed up
						ssh_AskedToSpeedUp = True
						ssh_ResponseFile = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Vocabulary\Responses\System\SlowDownDENIED.txt"

					End If

					StringClean = ResponseClean(StringClean)

				End If

			End If

			StringClean = StringClean.Replace("@SlowDownCheck", "")
			GoTo RinseLatherRepeat

		End If


		If StringClean.Contains("@PlayRiskyPick") Then
			ssh_RiskyDeal = True
			'FrmCardList.RiskyRound += 1
			FrmCardList.TCGames.SelectTab(2)
			FrmCardList.Show()
			FrmCardList.Focus()
			FrmCardList.InitializeRiskyDeal()
			StringClean = StringClean.Replace("@PlayRiskyPick", "")
			'Debug.Print("NullResponse Called")
		End If

		If StringClean.Contains("@ChooseRiskyPick") Then
			ssh_RiskyDelay = True
			If FrmCardList.BTNRisk1.Text <> "" Then FrmCardList.BTNRisk1.Enabled = True
			If FrmCardList.BTNRisk2.Text <> "" Then FrmCardList.BTNRisk2.Enabled = True
			If FrmCardList.BTNRisk3.Text <> "" Then FrmCardList.BTNRisk3.Enabled = True
			If FrmCardList.BTNRisk4.Text <> "" Then FrmCardList.BTNRisk4.Enabled = True
			If FrmCardList.BTNRisk5.Text <> "" Then FrmCardList.BTNRisk5.Enabled = True
			If FrmCardList.BTNRisk6.Text <> "" Then FrmCardList.BTNRisk6.Enabled = True
			If FrmCardList.BTNRisk7.Text <> "" Then FrmCardList.BTNRisk7.Enabled = True
			If FrmCardList.BTNRisk8.Text <> "" Then FrmCardList.BTNRisk8.Enabled = True
			If FrmCardList.BTNRisk9.Text <> "" Then FrmCardList.BTNRisk9.Enabled = True
			If FrmCardList.BTNRisk10.Text <> "" Then FrmCardList.BTNRisk10.Enabled = True

			If FrmCardList.BTNRisk11.Text <> "" Then FrmCardList.BTNRisk11.Enabled = True
			If FrmCardList.BTNRisk12.Text <> "" Then FrmCardList.BTNRisk12.Enabled = True
			If FrmCardList.BTNRisk13.Text <> "" Then FrmCardList.BTNRisk13.Enabled = True
			If FrmCardList.BTNRisk14.Text <> "" Then FrmCardList.BTNRisk14.Enabled = True
			If FrmCardList.BTNRisk15.Text <> "" Then FrmCardList.BTNRisk15.Enabled = True
			If FrmCardList.BTNRisk16.Text <> "" Then FrmCardList.BTNRisk16.Enabled = True
			If FrmCardList.BTNRisk17.Text <> "" Then FrmCardList.BTNRisk17.Enabled = True
			If FrmCardList.BTNRisk18.Text <> "" Then FrmCardList.BTNRisk18.Enabled = True
			If FrmCardList.BTNRisk19.Text <> "" Then FrmCardList.BTNRisk19.Enabled = True
			If FrmCardList.BTNRisk20.Text <> "" Then FrmCardList.BTNRisk20.Enabled = True

			If FrmCardList.BTNRisk21.Text <> "" Then FrmCardList.BTNRisk21.Enabled = True
			If FrmCardList.BTNRisk22.Text <> "" Then FrmCardList.BTNRisk22.Enabled = True
			If FrmCardList.BTNRisk23.Text <> "" Then FrmCardList.BTNRisk23.Enabled = True
			If FrmCardList.BTNRisk24.Text <> "" Then FrmCardList.BTNRisk24.Enabled = True

			FrmCardList.RiskyChoiceCount = 0
			FrmCardList.RiskyRound += 1
			FrmCardList.RiskyPickCount = 0
			FrmCardList.RiskyChoices.Clear()
			FrmCardList.ClearCaseLabelsOffer()
			'FrmCardList.Show()
			'FrmCardList.TCGames.SelectTab(4)
			'FrmCardList.Focus()

			StringClean = StringClean.Replace("@ChooseRiskyPick", "")
			'Debug.Print("NullResponse Called")
		End If


		If StringClean.Contains("@CheckRiskyPick") Then
			'FrmCardList.Focus()
			FrmCardList.CheckRiskyPick()
			StringClean = StringClean.Replace("@CheckRiskyPick", "")
			'Debug.Print("NullResponse Called")
		End If

		If StringClean.Contains("@FinalRiskyPick") Then
			'FrmCardList.Focus()
			FrmCardList.BTNRiskIt.Text = "LAST CASE"
			FrmCardList.BTNPickIt.Text = "MY CASE"
			StringClean = StringClean.Replace("@FinalRiskyPick", "")
			'Debug.Print("NullResponse Called")
		End If

		If StringClean.Contains("@ClearRiskyLabels") Then
			'FrmCardList.Focus()
			FrmCardList.ClearCaseLabelsOffer()
			StringClean = StringClean.Replace("@ClearRiskyLabels", "")
			'Debug.Print("NullResponse Called")
		End If

		If StringClean.Contains("@RiskyPayout") Then
			If FrmSettings.CBGameSounds.Checked = True And File.Exists(Application.StartupPath & "\Audio\System\PayoutSmall.wav") Then
				FrmCardList.GameWMP.settings.setMode("loop", False)
				FrmCardList.GameWMP.settings.volume = 20
				FrmCardList.GameWMP.URL = Application.StartupPath & "\Audio\System\PayoutSmall.wav"
			End If
			ssh_BronzeTokens += FrmCardList.TokensPaid
			FrmCardList.LBLRiskTokens.Text = ssh_BronzeTokens
			My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Variables\RP_Edges", FrmCardList.EdgesOwed, False)
			StringClean = StringClean.Replace("@RiskyPayout", "")
		End If

		If StringClean.Contains("@CloseRiskyPick") Then
			FrmCardList.CloseRiskyPick()
			StringClean = StringClean.Replace("@CloseRiskyPick", "")
		End If

		If StringClean.Contains("@RevealLastCase") Then
			FrmCardList.RevealLastCase()
			StringClean = StringClean.Replace("@RevealLastCase", "")
		End If

		If StringClean.Contains("@RevealUserCase") Then
			FrmCardList.RevealUserCase()
			StringClean = StringClean.Replace("@RevealUserCase", "")
		End If

		If StringClean.Contains("@RiskyState") Then
			If FrmCardList.RiskyState = True Then
				ssh_FileGoto = "(Risky Game)"
			Else
				ssh_FileGoto = "(Risky Tease)"
			End If
			FrmCardList.RiskyState = False
			ssh_SkipGotoLine = True
			GetGoto()
			StringClean = StringClean.Replace("@RiskyState", "")
		End If

		If StringClean.Contains("@SystemMessage ") Then
			StringClean = StringClean.Replace("@SystemMessage ", "")
		End If

		If StringClean.Contains("@EmoteMessage ") Then
			StringClean = StringClean.Replace("@EmoteMessage ", "")
		End If

		If StringClean.Contains("@CallReturn(") Then


			ssh_ReturnFileText = ssh_FileText
			ssh_ReturnStrokeTauntVal = ssh_StrokeTauntVal
			GetSubState()

			StrokeTimer.Stop()
			StrokeTauntTimer.Stop()
			CensorshipTimer.Stop()
			RLGLTimer.Stop()
			TnASlides.Stop()
			AvoidTheEdge.Stop()
			EdgeTauntTimer.Stop()
			HoldEdgeTimer.Stop()
			HoldEdgeTauntTimer.Stop()
			AvoidTheEdgeTaunts.Stop()
			RLGLTauntTimer.Stop()
			VideoTauntTimer.Stop()
			EdgeCountTimer.Stop()

			ssh_CBTBallsActive = False
			ssh_CBTBallsFlag = False
			ssh_CBTCockActive = False
			ssh_CBTCockFlag = False
			ssh_CBTBothActive = False
			ssh_CBTBothFlag = False
			ssh_CustomTaskActive = False

			If Not ssh_SubGaveUp Then
				ssh_SubEdging = False
				ssh_SubHoldingEdge = False
			End If

			'StopEverything()
			ssh_ReturnFlag = True


			Dim CheckFlag As String = GetParentheses(StringClean, "@CallReturn(")
			Dim CallReplace As String = CheckFlag

			If CheckFlag.Contains(",") Then

				CheckFlag = FixCommas(CheckFlag)

				Dim CallSplit As String() = CheckFlag.Split(",")
				ssh_FileText = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\" & CallSplit(0)
				ssh_FileGoto = CallSplit(1)
				ssh_SkipGotoLine = True
				GetGoto()

			Else

				ssh_FileText = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\" & CheckFlag
				ssh_StrokeTauntVal = -1

			End If
			ssh_ScriptTick = 2
			ScriptTimer.Start()

			StringClean = StringClean.Replace("@CallReturn(" & CallReplace & ")", "")

		End If

		If StringClean.Contains("@Call(") Then

			Dim CheckFlag As String = GetParentheses(StringClean, "@Call(")
			Dim CallReplace As String = CheckFlag

			If CheckFlag.Contains(",") Then

				CheckFlag = FixCommas(CheckFlag)

				Dim CallSplit As String() = CheckFlag.Split(",")
				ssh_FileText = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\" & CallSplit(0)
				ssh_FileGoto = CallSplit(1)
				ssh_SkipGotoLine = True
				GetGoto()

			Else

				ssh_FileText = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\" & CheckFlag
				ssh_StrokeTauntVal = -1

			End If

			StringClean = StringClean.Replace("@Call(" & CallReplace & ")", "")

		End If


		If StringClean.Contains("@CallRandom(") Then

			Dim CheckFlag As String = GetParentheses(StringClean, "@CallRandom(")
			Dim CallReplace As String = CheckFlag

			If Not Directory.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\" & CheckFlag) Then
				MessageBox.Show(Me, "The current script attempted to @Call from a directory that does not exist!" & Environment.NewLine & Environment.NewLine &
				 Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\" & CheckFlag, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			Else
				Dim RandomFile As New List(Of String)
				RandomFile.Clear()
				For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\" & CheckFlag & "\", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
					RandomFile.Add(foundFile)
				Next
				If RandomFile.Count < 1 Then
					MessageBox.Show(Me, "The current script attempted to @Call from a directory that does not contain any scripts!" & Environment.NewLine & Environment.NewLine &
					  Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\" & CheckFlag, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Else
					ssh_FileText = RandomFile(ssh_randomizer.Next(0, RandomFile.Count))
					ssh_StrokeTauntVal = -1
				End If
			End If
			StringClean = StringClean.Replace("@CallRandom(" & CallReplace & ")", "")
		End If


		If StringClean.Contains("@RapidCodeOn") Then
			ssh_RapidCode = True
			StringClean = StringClean.Replace("@RapidCodeOn", "")
		End If

		If StringClean.Contains("@RapidCodeOff") Then
			ssh_RapidCode = False
			StringClean = StringClean.Replace("@RapidCodeOff", "")
		End If

		If StringClean.Contains("@InterruptsOff") Then
			ssh_DoNotDisturb = True
			StringClean = StringClean.Replace("@InterruptsOff", "")
		End If

		If StringClean.Contains("@InterruptsOn") Then
			ssh_DoNotDisturb = False
			StringClean = StringClean.Replace("@InterruptsOn", "")
		End If


		If StringClean.Contains("@NoTypo") Then
			ssh_TypoSwitch = 0
			StringClean = StringClean.Replace("@NoTypo", "")
		End If

		If StringClean.Contains("@ForceTypo") Then
			ssh_TypoSwitch = 2
			StringClean = StringClean.Replace("@ForceTypo", "")
		End If

		If StringClean.Contains("@TyposOff") Then
			ssh_TyposDisabled = True
			StringClean = StringClean.Replace("@TyposOff", "")
		End If

		If StringClean.Contains("@TyposOn") Then
			ssh_TyposDisabled = False
			StringClean = StringClean.Replace("@TyposOn", "")
		End If

		If StringClean.Contains("@GoodMood(") Then

			Dim MoodFlag As String = GetParentheses(StringClean, "@GoodMood(")

			If ssh_DommeMood > FrmSettings.NBDomMoodMax.Value Then
				ssh_FileGoto = MoodFlag
				ssh_SkipGotoLine = True
				GetGoto()
			End If

			StringClean = StringClean.Replace("@GoodMood(" & MoodFlag & ")", "")
		End If

		If StringClean.Contains("@BadMood(") Then

			Dim MoodFlag As String = GetParentheses(StringClean, "@BadMood(")

			If ssh_DommeMood < FrmSettings.NBDomMoodMin.Value Then
				ssh_FileGoto = MoodFlag
				ssh_SkipGotoLine = True
				GetGoto()
			End If

			StringClean = StringClean.Replace("@BadMood(" & MoodFlag & ")", "")
		End If

		If StringClean.Contains("@NeutralMood(") Then

			Dim MoodFlag As String = GetParentheses(StringClean, "@NeutralMood(")

			If ssh_DommeMood >= FrmSettings.NBDomMoodMin.Value And ssh_DommeMood <= FrmSettings.NBDomMoodMax.Value Then
				ssh_FileGoto = MoodFlag
				ssh_SkipGotoLine = True
				GetGoto()
			End If

			StringClean = StringClean.Replace("@NeutralMood(" & MoodFlag & ")", "")
		End If

		If StringClean.Contains("@MoodUp") Then
			ssh_DommeMood += 1
			If ssh_DommeMood > 10 Then ssh_DommeMood = 10
			StringClean = StringClean.Replace("@MoodUp", "")
		End If

		If StringClean.Contains("@MoodDown") Then
			ssh_DommeMood -= 1
			If ssh_DommeMood < 1 Then ssh_DommeMood = 1
			StringClean = StringClean.Replace("@MoodDown", "")
		End If

		If StringClean.Contains("@MoodBest") Then
			ssh_DommeMood = 10
			StringClean = StringClean.Replace("@MoodBest", "")
		End If

		If StringClean.Contains("@MoodWorst") Then
			ssh_DommeMood = 1
			StringClean = StringClean.Replace("@MoodWorst", "")
		End If

		If StringClean.Contains("@Timeout(") Then

			Dim TimeFlag As String = GetParentheses(StringClean, "@Timeout(")
			Dim OriginalFlag As String = TimeFlag

			TimeFlag = FixCommas(TimeFlag)

			Dim TimeArray As String() = TimeFlag.Split(",")

			ssh_FileGoto = TimeArray(1)
			ssh_TimeoutTick = Val(TimeArray(0))
			TimeoutTimer.Start()

			StringClean = StringClean.Replace("@Timeout(" & OriginalFlag & ")", "")
		End If

		If StringClean.Contains("@BallTorture+1") Then
			ssh_CBTBallsCount += 1
			StringClean = StringClean.Replace("@BallTorture+1", "")
		End If

		If StringClean.Contains("@CockTorture+1") Then
			ssh_CBTCockCount += 1
			StringClean = StringClean.Replace("@CockTorture+1", "")
		End If


		If StringClean.Contains("@EndTaunts") Then
			ssh_StrokeTick = 0
			StringClean = StringClean.Replace("@EndTaunts", "")
		End If


		If StringClean.Contains("@ResponseYes(") Then
			ssh_ResponseYes = GetParentheses(StringClean, "@ResponseYes(")
			StringClean = StringClean.Replace("@ResponseYes(" & GetParentheses(StringClean, "@ResponseYes(") & ")", "")
		End If

		If StringClean.Contains("@ResponseNo(") Then
			ssh_ResponseNo = GetParentheses(StringClean, "@ResponseNo(")
			StringClean = StringClean.Replace("@ResponseNo(" & GetParentheses(StringClean, "@ResponseNo(") & ")", "")
		End If


		If StringClean.Contains("@SetModule(") Then
			Dim TempMod As String = GetParentheses(StringClean, "@SetModule(")

			If TempMod.Contains(",") Then
				TempMod = FixCommas(TempMod)
				Dim TempArray As String() = TempMod.Split(",")
				TempMod = TempArray(0)
				ssh_SetModuleGoto = TempArray(1)

			End If


			If File.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Custom\Modules\" & TempMod & ".txt") Then
				ssh_SetModule = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Custom\Modules\" & TempMod & ".txt"
			End If
			If File.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Modules\" & TempMod & ".txt") Then
				ssh_SetModule = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Modules\" & TempMod & ".txt"
			End If

			If ssh_SetModule = "" Then ssh_SetModuleGoto = ""

			StringClean = StringClean.Replace("@SetModule(" & GetParentheses(StringClean, "@SetModule(") & ")", "")
		End If

		If StringClean.Contains("@SetLink(") Then
			Dim TempMod As String = GetParentheses(StringClean, "@SetLink(")
			If File.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Custom\Link\" & TempMod & ".txt") Then
				ssh_SetLink = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Custom\Link\" & TempMod & ".txt"
			End If
			If File.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Link\" & TempMod & ".txt") Then
				ssh_SetLink = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Link\" & TempMod & ".txt"
			End If
			StringClean = StringClean.Replace("@SetLink(" & GetParentheses(StringClean, "@SetLink(") & ")", "")
		End If


		'If StringClean.Contains("@RandomText(") Then
		'Dim TempText As String = GetParentheses(StringClean, "@RandomText(")
		'TempText = FixCommas(TempText)
		'Dim TextArray As String() = TempText.Split(",")
		'TempText = TextArray(randomizer.Next(0, TextArray.Count))
		'StringClean = StringClean.Replace("@RandomText(" & GetParentheses(StringClean, "@RandomText(") & ")", TempText)
		'End If


		If StringClean.Contains("@FollowUp(") And ssh_FollowUp = "" Then
			ssh_FollowUp = GetParentheses(StringClean, "@FollowUp(")
			StringClean = StringClean.Replace("@FollowUp(" & ssh_FollowUp & ")", "")
		End If


		If StringClean.Contains("@FollowUp") And ssh_FollowUp = "" Then

			Dim TSStartIndex As Integer
			Dim TSEndIndex As Integer

			TSStartIndex = StringClean.IndexOf("@FollowUp") + 9
			TSEndIndex = StringClean.IndexOf("@FollowUp") + 11

			Dim FollowVal As Integer = Val(StringClean.Substring(TSStartIndex, TSEndIndex - TSStartIndex).Trim)

			ssh_TempVal = ssh_randomizer.Next(1, 101)

			If ssh_TempVal <= FollowVal Then ssh_FollowUp = GetParentheses(StringClean, "@FollowUp" & FollowVal & "(")

			StringClean = StringClean.Replace("@FollowUp" & FollowVal & "(" & ssh_FollowUp & ")", "")

		End If

		If StringClean.Contains("@Worship(") Then
			Dim WorshipTemp As String = GetParentheses(StringClean, "@Worship(")
			Debug.Print("Worship Paren = " & WorshipTemp)
			If UCase(WorshipTemp) = "ASS" Then ssh_WorshipTarget = "Ass"
			If UCase(WorshipTemp) = "BOOBS" Then ssh_WorshipTarget = "Boobs"
			If UCase(WorshipTemp) = "PUSSY" Then ssh_WorshipTarget = "Pussy"
			ssh_WorshipMode = True
			StringClean = StringClean.Replace("@Worship(" & GetParentheses(StringClean, "@Worship(") & ")", "")
		End If

		If StringClean.Contains("@WorshipOn") Then
			ssh_WorshipMode = True
			StringClean = StringClean.Replace("@WorshipOn", "")
		End If

		If StringClean.Contains("@WorshipOff") Then
			ssh_WorshipMode = False
			ssh_WorshipTarget = ""
			StringClean = StringClean.Replace("@WorshipOff", "")
		End If

		' If StringClean.Contains("@AssWorship") Then
		'WorshipTarget = "Ass"
		'StringClean = StringClean.Replace("@AssWorship", "")
		'End If

		'If StringClean.Contains("@BoobWorship") Then
		'WorshipTarget = "Boobs"
		'StringClean = StringClean.Replace("@BoobWorship", "")
		'End If

		'If StringClean.Contains("@PussyWorship") Then
		'WorshipTarget = "Pussy"
		'StringClean = StringClean.Replace("@PussyWorship", "")
		'End If

		If StringClean.Contains("@ClearWorship") Then
			ssh_WorshipTarget = ""
			StringClean = StringClean.Replace("@ClearWorship", "")
		End If








		If StringClean.Contains("@MiniScript(") Then

			Dim MiniTemp As String = GetParentheses(StringClean, "@MiniScript(")


			If File.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Custom\MiniScripts\" & MiniTemp & ".txt") Then ' And MiniScript = False Then
				ssh_MiniScript = True
				ssh_MiniScriptText = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Custom\MiniScripts\" & MiniTemp & ".txt"
				ssh_MiniTauntVal = -1
				ssh_MiniTimerCheck = ScriptTimer.Enabled
				ssh_ScriptTick = 2
				ScriptTimer.Start()
			End If

			StringClean = StringClean.Replace("@MiniScript(" & MiniTemp & ")", "")
		End If


		If StringClean.Contains("@CheckFile(") Then

			Dim FileFlag As String = GetParentheses(StringClean, "@CheckFile(")
			FileFlag = FixCommas(FileFlag)

			Dim FileArray As String() = FileFlag.Split(",")

			If FileArray.Count = 2 Or FileArray.Count = 3 Then

				If File.Exists(FileArray(0)) Then
					ssh_SkipGotoLine = True
					ssh_FileGoto = FileArray(1)
					GetGoto()
				End If

				If Not File.Exists(FileArray(0)) And FileArray.Count = 3 Then
					ssh_SkipGotoLine = True
					ssh_FileGoto = FileArray(2)
					GetGoto()
				End If

			End If

			StringClean = StringClean.Replace("@CheckFile(" & GetParentheses(StringClean, "@CheckFile(") & ")", "")
		End If


		If StringClean.Contains("@YesMode(") Then

			Dim YesFlag As String = GetParentheses(StringClean, "@YesMode(")
			YesFlag = FixCommas(YesFlag)
			Dim YesArray As String() = YesFlag.Split(",")

			If UCase(YesArray(0)).Contains("GOTO") Then
				ssh_YesGoto = True
				ssh_YesGotoLine = YesArray(1)
			End If

			If UCase(YesArray(0)).Contains("VIDEO") Then
				ssh_YesVideo = True
				ssh_YesGotoLine = YesArray(1)
			End If

			If UCase(YesArray(0)).Contains("NORMAL") Then
				ssh_YesGoto = False
				ssh_YesVideo = False
			End If

			StringClean = StringClean.Replace("@YesMode(" & GetParentheses(StringClean, "@YesMode(") & ")", "")
		End If

		If StringClean.Contains("@NoMode(") Then

			Dim NoFlag As String = GetParentheses(StringClean, "@NoMode(")
			NoFlag = FixCommas(NoFlag)
			Dim NoArray As String() = NoFlag.Split(",")

			If UCase(NoArray(0)).Contains("GOTO") Then
				ssh_NoGoto = True
				ssh_NoGotoLine = NoArray(1)
			End If

			If UCase(NoArray(0)).Contains("VIDEO") Then
				ssh_NoVideo_Mode = True
				ssh_NoGotoLine = NoArray(1)
			End If

			If UCase(NoArray(0)).Contains("NORMAL") Then
				ssh_NoGoto = False
				ssh_NoVideo_Mode = False
			End If

			StringClean = StringClean.Replace("@NoMode(" & GetParentheses(StringClean, "@NoMode(") & ")", "")
		End If

		If StringClean.Contains("@CameMode(") Then

			Dim CameFlag As String = GetParentheses(StringClean, "@CameMode(")
			CameFlag = FixCommas(CameFlag)
			Dim CameArray As String() = CameFlag.Split(",")

			If UCase(CameArray(0)).Contains("GOTO") Then
				ssh_CameGoto = True
				ssh_CameGotoLine = CameArray(1)
			End If

			If UCase(CameArray(0)).Contains("MESSAGE") Then
				ssh_CameMessage = True
				ssh_CameMessageText = CameArray(1)
			End If

			If UCase(CameArray(0)).Contains("VIDEO") Then
				ssh_CameVideo = True
				ssh_CameGotoLine = CameArray(1)
			End If

			If UCase(CameArray(0)).Contains("NORMAL") Then
				ssh_CameGoto = False
				ssh_CameMessage = False
				ssh_CameVideo = False
			End If

			StringClean = StringClean.Replace("@CameMode(" & GetParentheses(StringClean, "@CameMode(") & ")", "")
		End If

		If StringClean.Contains("@RuinedMode(") Then

			Dim RuinedFlag As String = GetParentheses(StringClean, "@RuinedMode(")
			RuinedFlag = FixCommas(RuinedFlag)
			Dim RuinedArray As String() = RuinedFlag.Split(",")

			If UCase(RuinedArray(0)).Contains("GOTO") Then
				ssh_RuinedGoto = True
				ssh_RuinedGotoLine = RuinedArray(1)
			End If

			If UCase(RuinedArray(0)).Contains("MESSAGE") Then
				ssh_RuinedMessage = True
				ssh_RuinedMessageText = RuinedArray(1)
			End If

			If UCase(RuinedArray(0)).Contains("VIDEO") Then
				ssh_RuinedVideo = True
				ssh_RuinedGotoLine = RuinedArray(1)
			End If

			If UCase(RuinedArray(0)).Contains("NORMAL") Then
				ssh_RuinedGoto = False
				ssh_RuinedMessage = False
				ssh_RuinedVideo = False
			End If

			StringClean = StringClean.Replace("@RuinedMode(" & GetParentheses(StringClean, "@RuinedMode(") & ")", "")
		End If

		If StringClean.Contains("@CustomMode(") Then

			Dim CustomFlag As String = GetParentheses(StringClean, "@CustomMode(")
			CustomFlag = FixCommas(CustomFlag)
			Dim CustomArray As String() = CustomFlag.Split(",")

			If CustomArray.Count = 3 Then

				If ssh_Modes.Keys.Contains(CustomArray(0)) Then ssh_Modes.Remove(CustomArray(0))

				Dim NewMode As New Mode
				NewMode.Keyword = CustomArray(0)
				NewMode.Type = CustomArray(1)
				NewMode.GotoLine = CustomArray(2)
				ssh_Modes.Add(CustomArray(0), NewMode)
			End If

			If CustomArray.Count = 2 Then
				If CustomArray(1).ToUpper.Contains("NORMAL") Then
					If ssh_Modes.Keys.Contains(CustomArray(0)) Then
						ssh_Modes.Remove(CustomArray(0))
					End If
				End If
			End If

			StringClean = StringClean.Replace("@CustomMode(" & GetParentheses(StringClean, "@CustomMode(") & ")", "")

		End If


		If StringClean.Contains("@ClearModes") Then
			ClearModes()
			StringClean = StringClean.Replace("@ClearModes", "")
		End If


		If StringClean.Contains("@LockVideo") Then
			ssh_LockVideo = True
			StringClean = StringClean.Replace("@LockVideo", "")
		End If

		If StringClean.Contains("@UnlockVideo") Then
			ssh_LockVideo = False
			mainPictureBox.Visible = True
			DomWMP.Visible = False
			StringClean = StringClean.Replace("@UnlockVideo", "")
		End If

		If StringClean.Contains("@ClearChat") Then
			ClearChat()
			StringClean = StringClean.Replace("@ClearChat", "")
		End If

		If StringClean.Contains("@ChatImage[") Then
			Dim ImageDir As String = Application.StartupPath & "\Images\" & GetParentheses(StringClean, "@ChatImage[")
			ImageDir = ImageDir.Replace("/", "\")
			ImageDir = ImageDir.Replace("\\", "\")


			If File.Exists(ImageDir.Split(",")(0)) Then

				If GetCharCount(ImageDir, ",") = 2 Then

					Dim PicAttributes As String() = GetArrayString(ImageDir)

					StringClean = StringClean.Replace("@ChatImage[" & GetParentheses(StringClean, "@ChatImage[") & "]", "<img id=""ChatPic"" src=""" & PicAttributes(0) & """ width=" & PicAttributes(1) &
					 " height=" & PicAttributes(2) & """/>")

				Else
					StringClean = StringClean.Replace("@ChatImage[" & GetParentheses(StringClean, "@ChatImage[") & "]", "<img id=""ChatPic"" src=""" & ImageDir & """/>")
				End If

			Else
				StringClean = StringClean.Replace("@ChatImage[" & GetParentheses(StringClean, "@ChatImage[") & "]", "")
			End If
		End If

		If StringClean.Contains("@Debug") Then

			'Dim wy As Long = DateDiff(DateInterval.Day, Val(GetVariable("TB_AFKSlideshow")), Date.Now)

			MsgBox(GetParentheses("Testing If - @If[42]>[7]Then(Go here) okay", "@If["))
			MsgBox(GetParentheses("Testing If2 - @If[42]>[7]Then(Go here) okay", "@If[", 2))
			MsgBox(GetParentheses("Testing If2 - @If(candle) okay", "@If("))
			MsgBox(GetParentheses("Testing If2 - @If(candle)and(wax) okay", "@If(", 2))


			'MsgBox(GetVariable("Sys_EndTotal") & " less than 30? " & CheckVariable("@Variable[Sys_EndTotal]<[30] blah blah blah"))
			StringClean = StringClean.Replace("@Debug", "")
		End If


		If StringClean.Contains("@GotoDommeOrgasm") Then

			'Debug.Print("GotoDommeOrgasmCalled")


			If FrmSettings.alloworgasmComboBox.Text = "Never Allows" Then ssh_FileGoto = "(Never Allows)"
			If FrmSettings.alloworgasmComboBox.Text = "Rarely Allows" Then ssh_FileGoto = "(Rarely Allows)"
			If FrmSettings.alloworgasmComboBox.Text = "Sometimes Allows" Then ssh_FileGoto = "(Sometimes Allows)"
			If FrmSettings.alloworgasmComboBox.Text = "Often Allows" Then ssh_FileGoto = "(Often Allows)"
			If FrmSettings.alloworgasmComboBox.Text = "Always Allows" Then ssh_FileGoto = "(Always Allows)"

			'Debug.Print(FileGoto)

			ssh_SkipGotoLine = True
			GetGoto()

			StringClean = StringClean.Replace("@GotoDommeOrgasm", "")

		End If

		If StringClean.Contains("@GotoDommeRuin") Then

			Debug.Print("GotoDommeRuinedCalled")


			If FrmSettings.ruinorgasmComboBox.Text = "Never Ruins" Then ssh_FileGoto = "(Never Ruins)"
			If FrmSettings.ruinorgasmComboBox.Text = "Rarely Ruins" Then ssh_FileGoto = "(Rarely Ruins)"
			If FrmSettings.ruinorgasmComboBox.Text = "Sometimes Ruins" Then ssh_FileGoto = "(Sometimes Ruins)"
			If FrmSettings.ruinorgasmComboBox.Text = "Often Ruins" Then ssh_FileGoto = "(Often Ruins)"
			If FrmSettings.ruinorgasmComboBox.Text = "Always Ruins" Then ssh_FileGoto = "(Always Ruins)"

			'Debug.Print(FileGoto)

			ssh_SkipGotoLine = True
			GetGoto()

			StringClean = StringClean.Replace("@GotoDommeRuin", "")

		End If

		If StringClean.Contains("@GotoDommeApathy") Then

			'Debug.Print("GotoDommeApathyCalled")


			If FrmSettings.NBEmpathy.Value = 1 Then ssh_FileGoto = "(ApathyLevel1)"
			If FrmSettings.NBEmpathy.Value = 2 Then ssh_FileGoto = "(ApathyLevel2)"
			If FrmSettings.NBEmpathy.Value = 3 Then ssh_FileGoto = "(ApathyLevel3)"
			If FrmSettings.NBEmpathy.Value = 4 Then ssh_FileGoto = "(ApathyLevel4)"
			If FrmSettings.NBEmpathy.Value = 5 Then ssh_FileGoto = "(ApathyLevel5)"

			'Debug.Print(FileGoto)

			ssh_SkipGotoLine = True
			GetGoto()

			StringClean = StringClean.Replace("@GotoDommeApathy", "")

		End If

		If StringClean.Contains("@GotoDommeLevel") Then

			If FrmSettings.domlevelNumBox.Value = 1 Then ssh_FileGoto = "(DommeLevel1)"
			If FrmSettings.domlevelNumBox.Value = 2 Then ssh_FileGoto = "(DommeLevel2)"
			If FrmSettings.domlevelNumBox.Value = 3 Then ssh_FileGoto = "(DommeLevel3)"
			If FrmSettings.domlevelNumBox.Value = 4 Then ssh_FileGoto = "(DommeLevel4)"
			If FrmSettings.domlevelNumBox.Value = 5 Then ssh_FileGoto = "(DommeLevel5)"

			'Debug.Print(FileGoto)

			ssh_SkipGotoLine = True
			GetGoto()

			StringClean = StringClean.Replace("@GotoDommeLevel", "")

		End If


		If StringClean.Contains("@CheckBnB") Then
			If Not GetImageData(ImageGenre.Boobs).IsAvailable Or Not GetImageData(ImageGenre.Butt).IsAvailable Then
				ssh_FileGoto = "(No BnB)"
				ssh_SkipGotoLine = True
				GetGoto()
			End If
			StringClean = StringClean.Replace("@CheckBnB", "")
		End If







		If StringClean.Contains("@CheckStrokingState") Then
			'If SubStroking = True Then
			If ssh_SubStroking = True Or ssh_SubEdging = True Or ssh_SubHoldingEdge = True Then
				ssh_FileGoto = "(Sub Stroking)"
			Else
				ssh_FileGoto = "(Sub Not Stroking)"
			End If
			ssh_SkipGotoLine = True
			GetGoto()
			StringClean = StringClean.Replace("@CheckStrokingState", "")
		End If

		'The @SetGroup Command is a defunct Command that was created when implementing new Glitter features. It has no use in the current build of Tease AI.

		If StringClean.Contains("@SetGroup(") Then

			Dim WF As String = UCase(GetParentheses(StringClean, "@SetGroup("))

			If WF.Contains("D") And Not WF.Contains("1") And Not WF.Contains("2") And Not WF.Contains("3") Then ssh_Group = "D"
			If WF.Contains("D") And WF.Contains("1") And Not WF.Contains("2") And Not WF.Contains("3") Then ssh_Group = "D1"
			If WF.Contains("D") And WF.Contains("1") And WF.Contains("2") And Not WF.Contains("3") Then ssh_Group = "D12"
			If WF.Contains("D") And WF.Contains("1") And Not WF.Contains("2") And WF.Contains("3") Then ssh_Group = "D13"
			If WF.Contains("D") And Not WF.Contains("1") And WF.Contains("2") And WF.Contains("3") Then ssh_Group = "D23"
			If WF.Contains("D") And WF.Contains("1") And WF.Contains("2") And WF.Contains("3") Then ssh_Group = "D123"

			If Not WF.Contains("D") And WF.Contains("1") And Not WF.Contains("2") And Not WF.Contains("3") Then ssh_Group = "1"
			If Not WF.Contains("D") And WF.Contains("1") And WF.Contains("2") And Not WF.Contains("3") Then ssh_Group = "12"
			If Not WF.Contains("D") And WF.Contains("1") And WF.Contains("2") And WF.Contains("3") Then ssh_Group = "123"

			If WF.Contains("D") And Not WF.Contains("1") And WF.Contains("2") And Not WF.Contains("3") Then ssh_Group = "D2"
			If Not WF.Contains("D") And Not WF.Contains("1") And WF.Contains("2") And Not WF.Contains("3") Then ssh_Group = "2"
			If Not WF.Contains("D") And Not WF.Contains("1") And WF.Contains("2") And WF.Contains("3") Then ssh_Group = "23"

			If WF.Contains("D") And Not WF.Contains("1") And Not WF.Contains("2") And WF.Contains("3") Then ssh_Group = "D3"
			If Not WF.Contains("D") And Not WF.Contains("1") And Not WF.Contains("2") And WF.Contains("3") Then ssh_Group = "3"
			If Not WF.Contains("D") And WF.Contains("1") And Not WF.Contains("2") And WF.Contains("3") Then ssh_Group = "13"

			StringClean = StringClean.Replace("@SetGroup(" & WF & ")", "")

		End If

		Debug.Print("Command Clean Complete")

		Return StringClean

	End Function

#Region "-------------------------------------------- Webtoy --------------------------------------------"

	Public Sub ActivateWebToy()

		If FrmSettings.TBWebStart.Text <> "" Then
			Try
				FrmSettings.WebToy.Navigate(FrmSettings.TBWebStart.Text)
			Catch
			End Try
		End If

	End Sub

	Public Sub DeactivateWebToy()

		If FrmSettings.TBWebStart.Text <> "" Then
			Try
				FrmSettings.WebToy.Navigate(FrmSettings.TBWebStop.Text)
			Catch
			End Try
		End If

	End Sub

#End Region ' WebToy

#Region "-------------------------------- Script: Flags/Dates/Variables ---------------------------------"

#Region "---------------------------------------- Script-Flags ------------------------------------------"

	Public Function CreateFlag(ByVal FlagDir As String, Optional ByVal Temp As Boolean = False)

		If Temp = False Then
			FlagDir = "Flags\" & FlagDir
		Else
			FlagDir = "Flags\Temp\" & FlagDir
		End If

		Dim FlagCreate As FileStream = File.Create(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\" & FlagDir)
		FlagCreate.Close()
		FlagCreate.Dispose()

	End Function

	Public Function DeleteFlag(ByVal FlagDir As String)

		If File.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Flags\" & FlagDir) Then _
					My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Flags\" & FlagDir)

		If File.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Flags\Temp\" & FlagDir) Then _
		 My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Flags\Temp\" & FlagDir)


	End Function

	Friend Function FlagExists(ByVal FlagDir As String) As Boolean

		Dim CheckFlag As Boolean

		If File.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Flags\" & FlagDir) Or
			File.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Flags\Temp\" & FlagDir) Then
			CheckFlag = True
		Else
			CheckFlag = False
		End If

		Return CheckFlag

	End Function

#End Region ' Script-Flags

#Region "------------------------------------- Script-Variables -----------------------------------------"

	Public Function SetVariable(ByVal VarName As String, ByVal VarValue As String)

		My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Variables\" & VarName, VarValue, False)

	End Function

	Public Function DeleteVariable(ByVal FlagDir As String)

		If File.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Variables\" & FlagDir) Then _
					My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Variables\" & FlagDir)

	End Function

	Public Function ChangeVariable(ByVal ChangeVar As String, ByVal ChangeVal1 As String, ByVal ChangeOperator As String, ByVal ChangeVal2 As String)

		Dim Val1 As Integer
		Dim Val2 As Integer

		If IsNumeric(ChangeVal1) = False Then
			'TODO: Remove unsecure IO.Access To file, for there is no DirectoryCheck.
			If File.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Variables\" & ChangeVal1) Then
				Val1 = Val(TxtReadLine(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Variables\" & ChangeVal1))
			Else
				Val1 = 0
			End If
		Else
			Val1 = Val(ChangeVal1)
		End If

		If IsNumeric(ChangeVal2) = False Then
			'TODO: Remove unsecure IO.Access To file, for there is no DirectoryCheck.
			If File.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Variables\" & ChangeVal2) Then
				Val2 = Val(TxtReadLine(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Variables\" & ChangeVal2))
			Else
				Val2 = 0
			End If
		Else
			Val2 = Val(ChangeVal2)
		End If

		ssh_ScriptOperator = "Null"
		If ChangeOperator.Contains("+") Then ssh_ScriptOperator = "Add"
		If ChangeOperator.Contains("-") Then ssh_ScriptOperator = "Subtract"
		If ChangeOperator.Contains("*") Then ssh_ScriptOperator = "Multiply"
		If ChangeOperator.Contains("/") Then ssh_ScriptOperator = "Divide"

		Dim ChangeVal As Integer = 0

		If ssh_ScriptOperator = "Add" Then ChangeVal = Val1 + Val2
		If ssh_ScriptOperator = "Subtract" Then ChangeVal = Val1 - Val2
		If ssh_ScriptOperator = "Multiply" Then ChangeVal = Val1 * Val2
		If ssh_ScriptOperator = "Divide" Then ChangeVal = Val1 / Val2

		My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Variables\" & ChangeVar, ChangeVal, False)

	End Function

	Public Function GetVariable(ByVal VarName As String) As String

		Dim VarGet As String
		'TODO: Remove unsecure IO.Access To file, for there is no DirectoryCheck.
		If File.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Variables\" & VarName) Then
			'### DEBUG

			' VarGet = Val(VarReader.ReadLine())

			VarGet = TxtReadLine(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Variables\" & VarName)
		Else
			VarGet = 0
		End If

		Return VarGet


	End Function

	Public Function CheckVariable(ByVal StringCLean As String) As Boolean

		Do

			Dim SCIfVar As String() = Split(StringCLean)
			Dim SCGotVar As String = "Null"

			For i As Integer = 0 To SCIfVar.Length - 1
				If SCIfVar(i).Contains("@Variable[") Then
					Dim IFJoin As Integer = 0
					If Not SCIfVar(i).Contains("] ") Then
						Do
							IFJoin += 1
							SCIfVar(i) = SCIfVar(i) & " " & SCIfVar(i + IFJoin)
							SCIfVar(i + IFJoin) = ""
						Loop Until SCIfVar(i).Contains("] ") Or SCIfVar(i).EndsWith("]")
					End If
					SCGotVar = SCIfVar(i).Trim
					SCIfVar(i) = ""
					StringCLean = Join(SCIfVar)
					Do
						StringCLean = StringCLean.Replace("  ", " ")
					Loop Until Not StringCLean.Contains("  ")
					Exit For
				End If
			Next

			If SCGotVar.Contains("]And[") Then

				Dim AndCheck As Boolean = True

				For x As Integer = 0 To SCGotVar.Replace("]And[", "").Count - 1
					If GetIf("[" & GetParentheses(SCGotVar, "@Variable[", 2) & "]") = False Then
						AndCheck = False
						Exit For
					End If
					SCGotVar = SCGotVar.Replace("[" & GetParentheses(SCGotVar, "@Variable[", 2) & "]And", "")
				Next

				Return AndCheck

			ElseIf SCGotVar.Contains("]Or[") Then

				Dim OrCheck As Boolean = False

				For x As Integer = 0 To SCGotVar.Replace("]Or[", "").Count - 1
					If GetIf("[" & GetParentheses(SCGotVar, "@Variable[", 2) & "]") = True Then
						OrCheck = True
						Exit For
					End If
					SCGotVar = SCGotVar.Replace("[" & GetParentheses(SCGotVar, "@Variable[", 2) & "]Or", "")
				Next

				Return OrCheck

			Else

				If GetIf("[" & GetParentheses(SCGotVar, "@Variable[", 2) & "]") = True Then

					Return True

				Else

					Return False

				End If

			End If

		Loop Until Not StringCLean.Contains("@Variable")


	End Function

#End Region ' Script-Variables

#Region "---------------------------------------- Script-Dates ------------------------------------------"

	Public Function GetDate(ByVal VarName As String) As Date

		Dim VarGet As String
		'TODO: Remove unsecure IO.Access To file, for there is no DirectoryCheck.
		If File.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Variables\" & VarName) Then
			VarGet = CDate(TxtReadLine(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Variables\" & VarName))
		Else
			VarGet = FormatDateTime(Now, DateFormat.GeneralDate)
		End If

		Return VarGet


	End Function

	Public Function GetTime(ByVal VarName As String) As Date

		Dim VarGet As String
		'TODO: Remove unsecure IO.Access To file, for there is no DirectoryCheck.
		If File.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Variables\" & VarName) Then
			VarGet = CDate(TxtReadLine(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Variables\" & VarName))
		Else
			VarGet = FormatDateTime(Now, DateFormat.LongTime)
		End If

		Return VarGet


	End Function

	Public Function CheckDateList(ByVal DateString As String, Optional ByVal Linear As Boolean = False) As Boolean

		Dim DateFlag As String = GetParentheses(DateString, "@CheckDate(")

		If DateFlag.Contains(",") Then

			DateFlag = FixCommas(DateFlag)

			Dim DateArray() As String = DateFlag.Split(",")
			Dim DDiff As Long = 18855881
			Dim DDiff2 As Long = 18855881

			Dim DCompare As Long
			Dim DCompare2 As Long

			If Linear = False Then

				If DateArray.Count = 2 Then
					DDiff = GetDateDifference(DateArray(0), DateArray(1))
					DCompare = GetDateCompare(DateArray(0), DateArray(1))
					If DDiff >= DCompare Then Return True
					Return False
				End If

				If DateArray.Count = 3 Then
					DDiff = GetDateDifference(DateArray(0), DateArray(1))
					DCompare = GetDateCompare(DateArray(0), DateArray(1))
					DDiff2 = GetDateDifference(DateArray(0), DateArray(2))
					DCompare2 = GetDateCompare(DateArray(0), DateArray(2))
					If DDiff >= DCompare And DDiff2 <= DCompare2 Then Return True
					Return False
				End If

			Else

				If DateArray.Count = 2 Then
					If CompareDatesWithTime(GetDate(DateArray(0))) <> 1 Then Return True
					Return False
				End If

				If DateArray.Count = 3 Then
					DDiff = GetDateDifference(DateArray(0), DateArray(1))
					DCompare = GetDateCompare(DateArray(0), DateArray(1))
					If DDiff >= DCompare Then Return True
					Return False
				End If

				If DateArray.Count = 4 Then
					DDiff = GetDateDifference(DateArray(0), DateArray(1))
					DCompare = GetDateCompare(DateArray(0), DateArray(1))
					DDiff2 = GetDateDifference(DateArray(0), DateArray(2))
					DCompare2 = GetDateCompare(DateArray(0), DateArray(2))
					If DDiff >= DCompare And DDiff2 <= DCompare2 Then Return True
					Return False
				End If

			End If

		Else
			If CompareDatesWithTime(GetDate(DateFlag)) <> 1 Then Return True
			Return False
		End If

		Return False

	End Function

	Public Function GetDateDifference(ByVal DateVar As String, ByVal DateString As String) As Long

		Dim DDiff As Long = 0

		If UCase(DateString).Contains("SECOND") Then DDiff = DateDiff(DateInterval.Second, GetDate(DateVar), Now)
		If UCase(DateString).Contains("MINUTE") Then DDiff = DateDiff(DateInterval.Minute, GetDate(DateVar), Now) * 60
		If UCase(DateString).Contains("HOUR") Then DDiff = DateDiff(DateInterval.Hour, GetDate(DateVar), Now) * 3600
		If UCase(DateString).Contains("DAY") Then DDiff = DateDiff(DateInterval.Day, GetDate(DateVar), Now) * 86400
		If UCase(DateString).Contains("WEEK") Then DDiff = DateDiff(DateInterval.Day, GetDate(DateVar), Now) * 604800
		If UCase(DateString).Contains("MONTH") Then DDiff = DateDiff(DateInterval.Month, GetDate(DateVar), Now) * 2629746
		If UCase(DateString).Contains("YEAR") Then DDiff = DateDiff(DateInterval.Year, GetDate(DateVar), Now) * 31536000

		Return DDiff

	End Function

	Public Function GetDateCompare(ByVal DateVar As String, ByVal DateString As String) As Long

		Dim DDiff As Long = 0
		Dim Amount As Long = Val(DateString)

		If UCase(DateString).Contains("SECOND") Then DDiff = Amount
		If UCase(DateString).Contains("MINUTE") Then DDiff = Amount * 60
		If UCase(DateString).Contains("HOUR") Then DDiff = Amount * 3600
		If UCase(DateString).Contains("DAY") Then DDiff = Amount * 86400
		If UCase(DateString).Contains("WEEK") Then DDiff = Amount * 604800
		If UCase(DateString).Contains("MONTH") Then DDiff = Amount * 2629746
		If UCase(DateString).Contains("YEAR") Then DDiff = Amount * 31536000

		Return DDiff

	End Function

#End Region ' Script-Dates

#End Region ' Flags/Dates/Variables



	Public Function GetParentheses(ByVal ParenCheck As String, ByVal CommandCheck As String, Optional ByVal Iterations As Integer = 1) As String



		Dim ParenFlag As String = ParenCheck
		Dim ParenStart As Integer = ParenFlag.IndexOf(CommandCheck) + CommandCheck.Length
		'githib patch Dim ParenType As String

		Dim ParenType As String = Nothing

		' #### CHECK ALL GETPAREN!
		'If CommandCheck.Substring(CommandCheck.Length - 1, 1) = "(" Then ParenType = ")"
		'If CommandCheck.Substring(CommandCheck.Length - 1, 1) = "[" Then ParenType = "]"

		If CommandCheck.Substring(CommandCheck.Length - 1, 1) = "(" Then
			ParenType = ")"
		End If
		If CommandCheck.Substring(CommandCheck.Length - 1, 1) = "[" Then
			ParenType = "]"
		End If



		'ParenFlag = ParenFlag.Substring(ParenStart, ParenFlag.Length - ParenStart)

		'Dim ParenEnd As Integer = ParenFlag.IndexOf(ParenType, ParenStart)
		Dim ParenEnd As Integer = GetNthIndex(ParenFlag, ParenType, ParenStart, Iterations)

		Debug.Print("ParenEnd = " & ParenEnd)

		If ParenEnd = -1 Then ParenEnd = ParenFlag.Length
		ParenFlag = ParenFlag.Substring(ParenStart, ParenEnd - ParenStart)

		'ParenFlag = ParenFlag.Split(")")(0)
		'ParenFlag = ParenFlag.Split(ParenType)(0)
		'ParenFlag = ParenFlag.Replace(ParenType, "")
		'ParenFlag = ParenFlag.Substring(0, ParenFlag.Length - 1)
		Debug.Print("ParenFlag = " & ParenFlag)

		Return ParenFlag


	End Function

	Public Function GetNthIndex(searchString As String, charToFind As Char, startIndex As Integer, n As Integer) As Integer
		Dim charIndexPair = searchString.Select(Function(c, i) New With {.Character = c, .Index = i}) _
										.Where(Function(x) x.Character = charToFind And x.Index > startIndex) _
										.ElementAtOrDefault(n - 1)
		Return If(charIndexPair IsNot Nothing, charIndexPair.Index, -1)
	End Function

	Public Function FixCommas(ByVal CommaString) As String

		CommaString = CommaString.replace(", ", ",")
		CommaString = CommaString.replace(" ,", ",")

		Return CommaString

	End Function

	Public Function GetEdgeHoldMinutes(ByVal HoldTime As Integer) As Boolean

		Dim HoldEdgeCheck As Boolean = False

		If ssh_HoldEdgeTime >= HoldTime * 60 Then HoldEdgeCheck = True

		Return HoldEdgeCheck


	End Function

	''' ========================================================================================================= 
	''' <summary>
	''' Searches for a DommeImage, that is tagged with the given Domme Tags.
	''' This Function is running timeconsuming Regex and IO Operations in a differnt Task.
	''' </summary>
	''' <param name="DomTag">The DommeTags, to Search for.</param>
	''' <returns>Returns a String representing the ImageLocation for the found image. If none was found it will 
	''' return an empty string.</returns>
	''' <remarks>
	''' It is possible to Exclude Tags from Search <br></br>
	''' Examples: <br></br>
	''' You want to show a butt without feet, you can enter "Ass, NotFeet".<br></br>
	''' You want to show a closeup face without boobs: "Face, NotBoobs, Closeup"<br></br>
	''' If there is no image found for the specified Tags, the Tags will be altered and searched again:<br></br>
	''' The order of alternation is: <br></br>
	''' 1. Remove: Furniture, SexToy, Tattoo
	''' 2. Remove: Closeup, Sideview<br></br>
	''' 3. Change: Naked -> GarmentCovering <br></br>
	''' 4. Change: GarmentCovering -> HalfDressed <br></br>
	''' 5. Change: HalfDressed -> FullDressed <br></br>
	''' 6. Change: HandsCovering -> GarmentCovering <br></br>
	''' 7. Remove: Excluded Tags from the BaseTags <br></br>
	''' 8-12: Same as 1-6 without Excluded tags. If there are no excluded tags this will be skipped.<br></br>
	''' 13. Change: FullDressed -> HalfDressed <br></br>
	''' 14. Change: HalfDressed -> GarmentCovering <br></br>
	''' Before each step there is a check, if it could alter the result. If it won't the Step is skipped.<br></br> 
	''' The Tag-Order, case and count doesn't matter. 
	''' This Function should be ThreadSafe (Microsoft would propably disagree, but who really understands Threadsafty... ;-) )
	'''   </remarks>
	Public Function GetDommeImage(ByVal DomTag As String) As String
		Try
			Dim __targetFolder As String = Path.GetDirectoryName(ssh__ImageFileNames(ssh_FileCount))

			If File.Exists(__targetFolder & "\ImageTags.txt") Then
				Dim task1 As Tasks.Task(Of String) = Tasks.Task.Factory.StartNew(
					Function() As String
                        '×××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××××
                        '                           Parallel Task - Beyond this Line: INVOKE IS REQUIRED...
                        CheckForIllegalCrossThreadCalls = True  ' Plz Leave it True, and inform me, if there is an error
                        Dim ___retryStage As Integer = 0
						Dim ___DomTag_Base As String = DomTag
						Dim ___DomTag_Work As String = ___DomTag_Base

                        ' Load Taglist for current Slideshow
                        Dim ___TagList As New List(Of String)
						___TagList = Txt2List(__targetFolder & "\ImageTags.txt")
retry_WithExclusion:
                        ' Convert all overgiven DommeTags to Regex with positive Lookahead
                        Dim ___matchpattern As String = "(?<TAG>[\w]+)[,\s]*"    ' MatchPattern to get all overgiven DommeTags 
                        Dim ___replacementstring As String = "(?=.*Tag${TAG})"   ' ReplatePattern, Replace every Tag, with positve LookAhead
                        ' Execute: Search Words in Overgiven Tags and warp them in the ReplacePattern.
                        Dim ___TagPattern As String = RegularExpressions.Regex.Replace(___DomTag_Work, ___matchpattern, ___replacementstring,
																						RegularExpressions.RegexOptions.IgnoreCase)

                        ' Convert every DommeTag starting with "Not" to negativ Lookahead
                        ___matchpattern = "(\?=\.\*\bTagNot)"         ' MatchPattern FindAllTag start with "Not" 
                        ___replacementstring = "?!.*"              ' ReplatePattern, Replace those Tags, with Negative LookAhead
                        ' Execute: Search Words in Overgiven Tags and warp them in the ReplacePattern.
                        ___TagPattern = RegularExpressions.Regex.Replace(___TagPattern, ___matchpattern, ___replacementstring,
																	  RegularExpressions.RegexOptions.IgnoreCase)

                        ' Define the Regex to search for the desired Dommetags, return only Filenames.
                        Dim ___re As New RegularExpressions.Regex("(?:^.*(?:\.jpg|jpeg|png|bmp|gif)){1}" & ___TagPattern,
																	RegularExpressions.RegexOptions.IgnoreCase _
																	Or RegularExpressions.RegexOptions.Multiline)
                        ' Get the Matches.
                        Dim ___mc As RegularExpressions.MatchCollection = ___re.Matches(String.Join(vbCrLf, ___TagList))

retry_NextStage:
						' If there are no images for the given Tags and we didn't try to alternate the Tags
						' Then alternate the Tags.
						If ___mc.Count <= 0 AndAlso ___retryStage <= 14 Then
                            '▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
                            '                             TAG-Alternation-Start
                            '▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
                            ' No Match for Current TagSet found => try differnt variations
                            Select Case ___retryStage
								Case 0, 7
                                    ' Remove Accessories
                                    ___matchpattern = "(?:\bFurniture\b)|(?:\bSexToy\b)|(?:\bTattoo\b)"
									___replacementstring = ""
								Case 1, 8
                                    ' Remove View-Tag
                                    ___matchpattern = "(?:\bCloseUP\b)|(?:\bSideview\b)"
									___replacementstring = ""
								Case 2, 9
                                    ' Increase Clothing
                                    ___matchpattern = "\bNaked\b"
									___replacementstring = "GarmentCovering"
								Case 3, 10
                                    ' Increase Clothing
                                    ___matchpattern = "\bGarmentCovering\b"
									___replacementstring = "HalfDressed"
								Case 4, 11
                                    ' Increase Clothing
                                    ___matchpattern = "\bHalfDressed\b"
									___replacementstring = "FullyDressed"
								Case 5, 12
                                    ' Increase Clothing
                                    ___matchpattern = "\bHandsCovering\b"
									___replacementstring = "GarmentCovering"
								Case 6
                                    ' Use BaseTags, remove Exclusions and Start again
                                    ___DomTag_Work = ___DomTag_Base
									___matchpattern = "\bNot[\w]*\b"
									___replacementstring = ""
								Case 13
                                    ' Decrease Clothing
                                    ___matchpattern = "\bFullyDressed\b"
									___replacementstring = "HalfDressed"
								Case 14
                                    ' Decrease Clothing
                                    ___matchpattern = "\bHalfDressed\b"
									___replacementstring = "GarmentCovering"
							End Select
							___retryStage += 1
                            ' Save the actual TagList for comparison. We want to know if this Tag-Replacemtent will give another result.
                            Dim ___DomTag_Temp As String = ___DomTag_Work
							___DomTag_Work = RegularExpressions.Regex.Replace(___DomTag_Work, ___matchpattern, ___replacementstring,
																			 RegularExpressions.RegexOptions.IgnoreCase)

                            ' IF:    actual Stage is remove excluded Tags
                            ' And:   there are none
                            ' Then:  Set Stage to 11 to skip unnecessary searches
                            If ___retryStage = 6 _
							AndAlso ___DomTag_Work = ___DomTag_Temp _
							Then ___retryStage = 13

                            ' IF:   Check if the Expression changed the TagList
                            ' Then: Start Search with new Tags.
                            ' Else: Skip Search and jump to next Stage.
                            If ___DomTag_Work <> ___DomTag_Temp _
							Then GoTo retry_WithExclusion _
							Else GoTo retry_NextStage
                            '▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲
                            '             TAG-Alternation-END 
                            '▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲
                        ElseIf ___mc.Count <= 0
							' No Images Found and Tag-alternation didn't get any results => interrupt task
							' Beware: If the debugger is attached VS will beef about an "Unhandled Exception".
							'			Stupid Programm... This exacly what we want. We want to crash the thread,
							'			otherwise we can't evaluate task1.IsFaulted to rethrow the Exception...
							' So, here is a simple workaround to override this, while debugging. Only change the 
							' statement after AndAlso, otherwise it will behave wrong in the final programm.
							If Debugger.IsAttached AndAlso 1 = 1 Then Return ""
							Log.Write("No DommeImage found for Tags: '" & ___DomTag_Base & "' in directory: '" & __targetFolder & "'")
						End If
                        ' Copy Matches to editable Container
                        Dim ___FoundFiles As New List(Of String)
						For Each File As RegularExpressions.Capture In ___mc
							___FoundFiles.Add(File.Value)
						Next
FileNotFound_GetNext:
						Dim ___FileName As String = ""
						Dim ___CurrDist As Integer = 999999
						'############################### Get nearest Image ###############################
						For Each ___ForFile As String In ___FoundFiles
							' Calculate the distance of ListIndex from the FoundFile to CurrentImage
							Dim ___FileDist As Integer = ssh__ImageFileNames.IndexOf(__targetFolder & "\" & ___ForFile) - ssh_FileCount
							' Convert negative values to positive by multipling (-) x (-) = (+) 
							If ___FileDist < 0 Then ___FileDist *= -1
							' Check if the distance is bigger than the previous one
							If ___FileDist < ___CurrDist Then
								' Yes: We will set this file and save its distance
								___FileName = ___ForFile
								___CurrDist = ___FileDist
							Else
								' As for the ___FoundFiles-List is in the Same order as ImageFileNames-List
								' We can stop searching, when the value is getting bigger.
								Exit For
							End If
						Next
						If ssh_randomizer.Next(0, 100) <= 99 Then GoTo Skip_RandomFile ' 1% can be a nice surprise
						'########################+####### Get random Image ###############################
						___FileName = ___FoundFiles.Item(ssh_randomizer.Next(0, ___FoundFiles.Count))
Skip_RandomFile:
						If File.Exists(__targetFolder & "\" & ___FileName) Then
							' File Found: Return absolute path
							If ___DomTag_Base <> ___DomTag_Work Then _
									Log.Write("DommeTags have been altered in order to retrieve results: " &
									___DomTag_Base & " => " & ___DomTag_Work & " in Directory: " & __targetFolder)
							Return DirectCast(__targetFolder & "\" & ___FileName, String)
						Else
							'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
							'                           Try-Finding-Another File
							'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
							' File not Found: Get next in List
							Log.Write(String.Format(
										"DommeImage '{0}' not found, please check your DommeTags for directory '{1}'.",
										 ___FileName, __targetFolder))

                            ' Loop through ___FoundFiles until it's empty. Then interrupt Task
                            If ___FoundFiles.Count > 0 Then
                                ' Remove not found File from Container and try another File.
                                ___FoundFiles.Remove(___FileName)
								GoTo FileNotFound_GetNext
							Else
								Throw New Exception("No available DommeImage found. Tags were found, but none of the " &
													"files could be localized. Please Check your TagFile for Directory: " & __targetFolder)
							End If
                            '▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲
                            '             Try-Finding-Another File
                            '▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲
                        End If
						'°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°° END of Task °°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°
				End Function)

                ' Wait for Task to end, Withour freezing UI
                Do Until task1.IsCompleted Or task1.IsFaulted
					Application.DoEvents()
				Loop
                ' Check if there was an exception, if yes rethrow it.
                If task1.IsFaulted Then Throw task1.Exception.InnerException

				Return task1.Result

			End If
		Catch ex As Exception
            '▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
            '                                            All Errors
            '▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
            Log.WriteError("Exception in GetDommeImage()", ex, "")
			Debug.Print(ex.Message)
			Return ""
		End Try
	End Function

	Public Function GetLocalImage(ByVal LocTag As String) As String

		If File.Exists(Application.StartupPath & "\Images\System\LocalImageTags.txt") Then


			Dim TagList As New List(Of String)
			TagList = Txt2List(Application.StartupPath & "\Images\System\LocalImageTags.txt")

			LocTag = LocTag.Replace(" ,", ",")
			LocTag = LocTag.Replace(", ", ",")

			Dim LocTagArray As String() = LocTag.Split(",")

			Dim LocTag1 As String = " "
			Dim LocTag2 As String = " "
			Dim LocTag3 As String = " "

			For i As Integer = 0 To LocTagArray.Count - 1
				If i = 0 Then LocTag1 = "Tag" & LocTagArray(0)
				If i = 1 Then LocTag2 = "Tag" & LocTagArray(1)
				If i = 2 Then LocTag3 = "Tag" & LocTagArray(2)
			Next


			Dim TaggedList As New List(Of String)

			For i As Integer = 0 To TagList.Count - 1
				If TagList(i).Contains(LocTag1) And TagList(i).Contains(LocTag2) And TagList(i).Contains(LocTag3) Then
					TaggedList.Add(TagList(i))
				End If
			Next

			If TaggedList.Count > 0 Then

				Dim PicArray As String() = TaggedList(ssh_randomizer.Next(0, TaggedList.Count)).Split
				Dim PicDir As String = ""

				For p As Integer = 0 To PicArray.Count - 1
					PicDir = PicDir & PicArray(p) & " "
					If UCase(PicDir).Contains(".JPG") Or UCase(PicDir).Contains(".JPEG") Or UCase(PicDir).Contains(".PNG") Or UCase(PicDir).Contains(".BMP") Or UCase(PicDir).Contains(".GIF") Then Exit For
				Next

				If ssh_LocalImageListCheck = False Then
					'LocalImage = Image.FromFile(PicDir)
					Return PicDir
				End If
			Else
				Return String.Empty

			End If

		End If
	End Function


	Friend Sub ContactEdgeCheck(ByVal EdgeCheck As String)
		If EdgeCheck.Contains("@Contact1") Then ssh_Contact1Edge = True
		If EdgeCheck.Contains("@Contact2") Then ssh_Contact2Edge = True
		If EdgeCheck.Contains("@Contact3") Then ssh_Contact3Edge = True
	End Sub

	Public Sub DisableContactStroke()
		ssh_Contact1Stroke = False
		ssh_Contact2Stroke = False
		ssh_Contact3Stroke = False
	End Sub

	Public Sub GetSubState()

		ssh_ReturnSubState = "Rest"
		If ssh_SubStroking = True Then ssh_ReturnSubState = "Stroking"
		If ssh_SubEdging = True Then ssh_ReturnSubState = "Edging"
		If ssh_SubHoldingEdge = True Then ssh_ReturnSubState = "Holding The Edge"
		If ssh_CBTBallsFlag = True Or ssh_CBTBothFlag = True Then ssh_ReturnSubState = "CBTBalls"
		If ssh_CBTCockFlag = True Then ssh_ReturnSubState = "CBTCock"
		If ssh_CensorshipGame = True Then ssh_ReturnSubState = "Censorship Sucks"
		If ssh_AvoidTheEdgeGame = True Then ssh_ReturnSubState = "Avoid The Edge"
		If ssh_RLGLGame = True Then ssh_ReturnSubState = "RLGL"



	End Sub

	Public Sub EdgePace()

		StrokePace = ssh_randomizer.Next(NBMaxPace.Value, NBMaxPace.Value + 151)
		If StrokePace > NBMinPace.Value Then StrokePace = NBMinPace.Value
		StrokePace = 50 * Math.Round(StrokePace / 50)

	End Sub



	Public Function FilterList(ByVal ListClean As List(Of String)) As List(Of String)


		ssh_FoundTag = "NULL"

		Try
			If File.Exists(ssh__ImageFileNames(ssh_FileCount)) Then ssh_MainPictureImage = Path.GetDirectoryName(ssh__ImageFileNames(ssh_FileCount))
		Catch
		End Try

		If File.Exists(ssh_MainPictureImage & "\ImageTags.txt") Then
			Dim TagList As List(Of String) = Txt2List(ssh_MainPictureImage & "\ImageTags.txt")

			If ssh_SlideshowLoaded = True And Not mainPictureBox.Image Is Nothing And DomWMP.Visible = False Then
				Try
					For t As Integer = 0 To TagList.Count - 1
						'Debug.Print("TagList(t) = " & TagList(t))
						If TagList(t).Contains(Path.GetFileName(ssh__ImageFileNames(ssh_FileCount))) Then
							ssh_FoundTag = TagList(t)
							Dim FoundTagSplit As String() = Split(ssh_FoundTag)
							For j As Integer = 0 To FoundTagSplit.Length - 1
								If FoundTagSplit(j).Contains("TagGarment") Then
									ssh_TagGarment = FoundTagSplit(j).Replace("TagGarment", "")
									ssh_TagGarment = ssh_TagGarment.Replace("-", " ")
								End If

								If FoundTagSplit(j).Contains("TagUnderwear") Then
									ssh_TagUnderwear = FoundTagSplit(j).Replace("TagUnderwear", "")
									ssh_TagUnderwear = ssh_TagUnderwear.Replace("-", " ")
								End If

								If FoundTagSplit(j).Contains("TagTattoo") Then
									ssh_TagTattoo = FoundTagSplit(j).Replace("TagTattoo", "")
									ssh_TagTattoo = ssh_TagTattoo.Replace("-", " ")
								End If

								If FoundTagSplit(j).Contains("TagSexToy") Then
									ssh_TagSexToy = FoundTagSplit(j).Replace("TagSexToy", "")
									ssh_TagSexToy = ssh_TagSexToy.Replace("-", " ")
								End If

								If FoundTagSplit(j).Contains("TagFurniture") Then
									ssh_TagFurniture = FoundTagSplit(j).Replace("TagFurniture", "")
									ssh_TagFurniture = ssh_TagFurniture.Replace("-", " ")
								End If
							Next
							Exit For
						End If
					Next
				Catch
				End Try
			End If

		End If

		Dim FilterPass As Boolean
		Dim ListIncrement As Integer = 1
		If ssh_StrokeFilter = True Then ListIncrement = ssh_StrokeTauntCount

		'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
		'		Check if Grouped-Lines-Files have the right amount of Lines
		'▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
		' No need to go further on an empty file.
		If ListClean.Count <= 0 Then
			Log.Write("FilterList started with empty List. Skipping filter.")
			Return ListClean
		End If

		' To Avoid DivideByZeroException 
		If ListIncrement <= 0 Then
			Dim lazyText As String = "FilterList Started With LineGroupingValue """ & ListIncrement & """. "
			Log.WriteError(lazyText, New ArgumentOutOfRangeException(lazyText), "FilterList Cancelled")
			Return ListClean
		End If

		' Divide List.Count by StrokeTauntSize and get the Remainder.
		Dim InvalidLineCount As Integer = ListClean.Count Mod ListIncrement

		' If there is a Remainder, the file has not the desired Line.Count.
		If InvalidLineCount > 0 Then
			' So delete the Lines of the last and hopefully uncomplete Group. 
			ListClean.RemoveRange(ListClean.Count - InvalidLineCount, InvalidLineCount)
		End If
		'▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲
		'		Grouped-Lines-Check-END 
		'▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲

		For i As Integer = 0 To ListClean.Count - 1 Step ListIncrement

			FilterPass = True

			For x As Integer = 0 To ListIncrement - 1
				If GetFilter(ListClean(i + x)) = False Then
					FilterPass = False
					Exit For
				End If
			Next

			If FilterPass = False Then
				For x As Integer = 0 To ListIncrement - 1
					ListClean(i + x) = ListClean(i + x) & "###-INVALID-###"
				Next
			End If

		Next

		For i As Integer = ListClean.Count - 1 To 0 Step -1
			If ListClean(i).Contains("###-INVALID-###") Then ListClean.RemoveAt(i)
		Next


		For x As Integer = 0 To ListClean.Count - 1
			ListClean(x) = ListClean(x).Replace("#TagGarment", ssh_TagGarment.Replace("-", " "))
			ListClean(x) = ListClean(x).Replace("#TagUnderwear", ssh_TagUnderwear.Replace("-", " "))
			ListClean(x) = ListClean(x).Replace("#TagTattoo", ssh_TagTattoo.Replace("-", " "))
			ListClean(x) = ListClean(x).Replace("#TagSexToy", ssh_TagSexToy.Replace("-", " "))
			ListClean(x) = ListClean(x).Replace("#TagFurniture", ssh_TagFurniture.Replace("-", " "))
		Next

		Dim FilteredList As New List(Of String)

		'For i As Integer = 0 To ListClean.Count - 1
		'If Not ListClean(i).Contains("###-INVALID-###") Then FilteredList.Add(ListClean(i))
		'Next

		Return ListClean

	End Function


	Public Function GetFilter(ByVal FilterString As String, Optional ByVal Linear As Boolean = False) As Boolean


		If FilterString.ToLower.Contains("@crazy") And FrmSettings.crazyCheckBox.Checked = False Then Return False
		If FilterString.ToLower.Contains("@vulgar") And FrmSettings.vulgarCheckBox.Checked = False Then Return False
		If FilterString.ToLower.Contains("@supremacist") And FrmSettings.supremacistCheckBox.Checked = False Then Return False
		If FilterString.ToLower.Contains("@sadistic") And FrmSettings.sadisticCheckBox.Checked = False Then Return False
		If FilterString.ToLower.Contains("@degrading") And FrmSettings.degradingCheckBox.Checked = False Then Return False

		If FilterString.ToLower.Contains("@dommeLevel1") And FrmSettings.domlevelNumBox.Value <> 1 Then Return False
		If FilterString.ToLower.Contains("@dommeLevel2") And FrmSettings.domlevelNumBox.Value <> 2 Then Return False
		If FilterString.ToLower.Contains("@dommeLevel3") And FrmSettings.domlevelNumBox.Value <> 3 Then Return False
		If FilterString.ToLower.Contains("@dommeLevel4") And FrmSettings.domlevelNumBox.Value <> 4 Then Return False
		If FilterString.ToLower.Contains("@dommeLevel5") And FrmSettings.domlevelNumBox.Value <> 5 Then Return False

		If FilterString.ToLower.Contains("@selfyoung") And FrmSettings.domageNumBox.Value > FrmSettings.NBSelfAgeMin.Value - 1 Then Return False
		If FilterString.ToLower.Contains("@selfold") And FrmSettings.domageNumBox.Value < FrmSettings.NBSelfAgeMax.Value + 1 Then Return False
		If FilterString.ToLower.Contains("@selfyoung") Or FilterString.ToLower.Contains("@selfold") Then
			If ssh_VideoTease = True Or ssh_TeaseVideo = True Then Return False
		End If
		If FilterString.ToLower.Contains("@subyoung") And FrmSettings.subAgeNumBox.Value > FrmSettings.NBSubAgeMin.Value - 1 Then Return False
		If FilterString.ToLower.Contains("@subold") And FrmSettings.subAgeNumBox.Value < FrmSettings.NBSubAgeMax.Value + 1 Then Return False

		If FilterString.ToLower.Contains("@acup") Then
			If FrmSettings.boobComboBox.Text <> "A" Or ssh_JustShowedBlogImage = True Then Return False
		End If
		If FilterString.ToLower.Contains("@bcup") Then
			If FrmSettings.boobComboBox.Text <> "B" Or ssh_JustShowedBlogImage = True Then Return False
		End If
		If FilterString.ToLower.Contains("@ccup") Then
			If FrmSettings.boobComboBox.Text <> "C" Or ssh_JustShowedBlogImage = True Then Return False
		End If
		If FilterString.ToLower.Contains("@dcup") Then
			If FrmSettings.boobComboBox.Text <> "D" Or ssh_JustShowedBlogImage = True Then Return False
		End If
		If FilterString.ToLower.Contains("@ddcup") Then
			If FrmSettings.boobComboBox.Text <> "DD" Or ssh_JustShowedBlogImage = True Then Return False
		End If
		If FilterString.ToLower.Contains("@ddd+cup") Then
			If FrmSettings.boobComboBox.Text <> "DDD+" Or ssh_JustShowedBlogImage = True Then Return False
		End If

		If FilterString.Contains("@Cup(") Then
			If FilterCheck(GetParentheses(FilterString, "@Cup("), FrmSettings.boobComboBox) = False Then Return False
		End If

		If FilterString.ToLower.Contains("@tagface") And Not ssh_FoundTag.ToLower.Contains("tagface") Then Return False
		If FilterString.ToLower.Contains("@tagboobs") And Not ssh_FoundTag.ToLower.Contains("tagboobs") Then Return False
		If FilterString.ToLower.Contains("@tagpussy") And Not ssh_FoundTag.ToLower.Contains("tagpussy") Then Return False
		If FilterString.ToLower.Contains("@tagass") And Not ssh_FoundTag.ToLower.Contains("tagass") Then Return False
		If FilterString.ToLower.Contains("@tagfeet") And Not ssh_FoundTag.ToLower.Contains("tagfeet") Then Return False
		If FilterString.ToLower.Contains("@taglegs") And Not ssh_FoundTag.ToLower.Contains("taglegs") Then Return False
		If FilterString.ToLower.Contains("@tagmasturbating") And Not ssh_FoundTag.ToLower.Contains("tagmasturbating") Then Return False
		If FilterString.ToLower.Contains("@tagsucking") And Not ssh_FoundTag.ToLower.Contains("tagsucking") Then Return False
		If FilterString.ToLower.Contains("@tagfullydressed") And Not ssh_FoundTag.ToLower.Contains("tagfullydressed") Then Return False
		If FilterString.ToLower.Contains("@taghalfdressed") And Not ssh_FoundTag.ToLower.Contains("taghalfdressed") Then Return False
		If FilterString.ToLower.Contains("@taggarmentcovering") And Not ssh_FoundTag.ToLower.Contains("taggarmentcovering") Then Return False
		If FilterString.ToLower.Contains("@taghandscovering") And Not ssh_FoundTag.ToLower.Contains("taghandscovering") Then Return False
		If FilterString.ToLower.Contains("@tagnaked") And Not ssh_FoundTag.ToLower.Contains("tagnaked") Then Return False
		If FilterString.ToLower.Contains("@tagsideview") And Not ssh_FoundTag.ToLower.Contains("tagsideview") Then Return False
		If FilterString.ToLower.Contains("@tagcloseup") And Not ssh_FoundTag.ToLower.Contains("tagcloseup") Then Return False
		If FilterString.ToLower.Contains("@tagpiercing") And Not ssh_FoundTag.ToLower.Contains("tagpiercing") Then Return False
		If FilterString.ToLower.Contains("@tagsmiling") And Not ssh_FoundTag.ToLower.Contains("tagsmiling") Then Return False
		If FilterString.ToLower.Contains("@tagglaring") And Not ssh_FoundTag.ToLower.Contains("tagglaring") Then Return False
		If FilterString.ToLower.Contains("@taggarment") And Not ssh_FoundTag.ToLower.Contains("taggarment") Then Return False
		If FilterString.ToLower.Contains("@tagunderwear") And Not ssh_FoundTag.ToLower.Contains("tagunderwear") Then Return False
		If FilterString.ToLower.Contains("@tagtattoo") And Not ssh_FoundTag.ToLower.Contains("tagtattoo") Then Return False
		If FilterString.ToLower.Contains("@tagsextoy") And Not ssh_FoundTag.ToLower.Contains("tagsextoy") Then Return False
		If FilterString.ToLower.Contains("@tagfurniture") And Not ssh_FoundTag.ToLower.Contains("tagfurniture") Then Return False

		If FilterString.ToLower.Contains("@cocksmall") And FrmSettings.CockSizeNumBox.Value >= FrmSettings.NBAvgCockMin.Value Then Return False
		If FilterString.ToLower.Contains("@cockaverage") Then
			If FrmSettings.CockSizeNumBox.Value < FrmSettings.NBAvgCockMin.Value Or FrmSettings.CockSizeNumBox.Value > FrmSettings.NBAvgCockMax.Value Then Return False
		End If

		If FilterString.ToLower.Contains("@cocklarge") And FrmSettings.CockSizeNumBox.Value <= FrmSettings.NBAvgCockMax.Value Then Return False

		If FilterString.ToLower.Contains("@dombirthday") Then
			If FrmSettings.NBDomBirthdayMonth.Value <> Month(Date.Now) Or FrmSettings.NBDomBirthdayDay.Value <> DateAndTime.Day(Date.Now) Then Return False
		End If

		If FilterString.ToLower.Contains("@subbirthday") Then
			If FrmSettings.NBBirthdayMonth.Value <> Month(Date.Now) Or FrmSettings.NBBirthdayDay.Value <> DateAndTime.Day(Date.Now) Then Return False
		End If

		If FilterString.ToLower.Contains("@valentinesday") And FrmSettings.CockSizeNumBox.Value <= FrmSettings.NBAvgCockMax.Value Then Return False
		If FilterString.ToLower.Contains("@christmaseve") And FrmSettings.CockSizeNumBox.Value <= FrmSettings.NBAvgCockMax.Value Then Return False
		If FilterString.ToLower.Contains("@christmasday") And FrmSettings.CockSizeNumBox.Value <= FrmSettings.NBAvgCockMax.Value Then Return False
		If FilterString.ToLower.Contains("@newyearseve") And FrmSettings.CockSizeNumBox.Value <= FrmSettings.NBAvgCockMax.Value Then Return False
		If FilterString.ToLower.Contains("@newyearsday") And FrmSettings.CockSizeNumBox.Value <= FrmSettings.NBAvgCockMax.Value Then Return False

		If FilterString.ToLower.Contains("@firstround") And ssh_FirstRound = False Then Return False
		If FilterString.ToLower.Contains("@notfirstround") And ssh_FirstRound = True Then Return False

		If FilterString.ToLower.Contains("@strokespeedmax") And StrokePace < NBMaxPace.Value Then Return False
		If FilterString.ToLower.Contains("@strokespeedmin") And StrokePace < NBMinPace.Value Then Return False
		If FilterString.ToLower.Contains("@strokefaster") Or FilterString.ToLower.Contains("@strokefastest") Then
			If StrokePace = NBMaxPace.Value Or ssh_WorshipMode = True Then Return False
		End If
		If FilterString.ToLower.Contains("@strokeslower") Or FilterString.ToLower.Contains("@strokeslowest") Then
			If StrokePace = NBMinPace.Value Or ssh_WorshipMode = True Then Return False
		End If

		If FilterString.Contains("@AllowsOrgasm(") Then
			If FilterCheck(GetParentheses(FilterString, "@AllowsOrgasm("), FrmSettings.alloworgasmComboBox) = False Then Return False
		End If

		If FilterString.ToLower.Contains("@alwaysallowsorgasm") And FrmSettings.alloworgasmComboBox.Text <> "Always Allows" Then Return False
		If FilterString.ToLower.Contains("@oftenallowsorgasm") And FrmSettings.alloworgasmComboBox.Text <> "Often Allows" Then Return False
		If FilterString.ToLower.Contains("@sometimesallowsorgasm") And FrmSettings.alloworgasmComboBox.Text <> "Sometimes Allows" Then Return False
		If FilterString.ToLower.Contains("@rarelyallowsorgasm") And FrmSettings.alloworgasmComboBox.Text <> "Rarely Allows" Then Return False
		If FilterString.ToLower.Contains("@neverallowsorgasm") And FrmSettings.alloworgasmComboBox.Text <> "Never Allows" Then Return False

		If FilterString.Contains("@RuinsOrgasm(") Then
			If FilterCheck(GetParentheses(FilterString, "@RuinsOrgasm("), FrmSettings.ruinorgasmComboBox) = False Then Return False
		End If

		If FilterString.ToLower.Contains("@alwaysruinsorgasm") And FrmSettings.ruinorgasmComboBox.Text <> "Always Ruins" Then Return False
		If FilterString.ToLower.Contains("@oftenruinsorgasm") And FrmSettings.ruinorgasmComboBox.Text <> "Often Ruins" Then Return False
		If FilterString.ToLower.Contains("@sometimesruinsorgasm") And FrmSettings.ruinorgasmComboBox.Text <> "Sometimes Ruins" Then Return False
		If FilterString.ToLower.Contains("@rarelyruinsorgasm") And FrmSettings.ruinorgasmComboBox.Text <> "Rarely Ruins" Then Return False
		If FilterString.ToLower.Contains("@neverruinsorgasm") And FrmSettings.ruinorgasmComboBox.Text <> "Never Ruins" Then Return False

		If FilterString.ToLower.Contains("@notalwaysallowsorgasm") And FrmSettings.alloworgasmComboBox.Text = "Always Allows" Then Return False
		If FilterString.ToLower.Contains("@notneverallowsorgasm") And FrmSettings.alloworgasmComboBox.Text = "Never Allows" Then Return False
		If FilterString.ToLower.Contains("@notalwaysruinsorgasm") And FrmSettings.ruinorgasmComboBox.Text = "Always Ruins" Then Return False
		If FilterString.ToLower.Contains("@notneverruinsorgasm") And FrmSettings.ruinorgasmComboBox.Text = "Never Ruins" Then Return False


		If FilterString.Contains("@LongEdge") Then
			If ssh_LongEdge = False Or FrmSettings.CBLongEdgeTaunts.Checked = False Then Return False
		End If
		If FilterString.Contains("@InterruptLongEdge") Then
			If ssh_LongEdge = False Or FrmSettings.CBLongEdgeInterrupts.Checked = False Or ssh_TeaseTick < 1 Or ssh_RiskyEdges = True Then Return False
		End If

		If Linear = False Then

			If FilterString.Contains("@ShowHardcoreImage") Then
				If Not GetImageData(ImageGenre.Hardcore).IsAvailable Or ssh_LockImage = True Or ssh_CustomSlideshow = True Then Return False
			End If
			If FilterString.Contains("@ShowSoftcoreImage") Then
				If Not GetImageData(ImageGenre.Softcore).IsAvailable Or ssh_LockImage = True Or ssh_CustomSlideshow = True Then Return False
			End If
			If FilterString.Contains("@ShowLesbianImage") Then
				If Not GetImageData(ImageGenre.Lesbian).IsAvailable Or ssh_LockImage = True Or ssh_CustomSlideshow = True Then Return False
			End If
			If FilterString.Contains("@ShowBlowjobImage") Then
				If Not GetImageData(ImageGenre.Blowjob).IsAvailable Or ssh_LockImage = True Or ssh_CustomSlideshow = True Then Return False
			End If
			If FilterString.Contains("@ShowFemdomImage") Then
				If Not GetImageData(ImageGenre.Femdom).IsAvailable Or ssh_LockImage = True Or ssh_CustomSlideshow = True Then Return False
			End If
			If FilterString.Contains("@ShowLezdomImage") Then
				If Not GetImageData(ImageGenre.Lezdom).IsAvailable Or ssh_LockImage = True Or ssh_CustomSlideshow = True Then Return False
			End If
			If FilterString.Contains("@ShowHentaiImage") Then
				If Not GetImageData(ImageGenre.Hentai).IsAvailable Or ssh_LockImage = True Or ssh_CustomSlideshow = True Then Return False
			End If
			If FilterString.Contains("@ShowGayImage") Then
				If Not GetImageData(ImageGenre.Gay).IsAvailable Or ssh_LockImage = True Or ssh_CustomSlideshow = True Then Return False
			End If
			If FilterString.Contains("@ShowMaledomImage") Then
				If Not GetImageData(ImageGenre.Maledom).IsAvailable Or ssh_LockImage = True Or ssh_CustomSlideshow = True Then Return False
			End If
			If FilterString.Contains("@ShowCaptionsImage") Then
				If Not GetImageData(ImageGenre.Captions).IsAvailable Or ssh_LockImage = True Or ssh_CustomSlideshow = True Then Return False
			End If
			If FilterString.Contains("@ShowGeneralImage") Then
				If Not GetImageData(ImageGenre.General).IsAvailable Or ssh_LockImage = True Or ssh_CustomSlideshow = True Then Return False
			End If

			If FilterString.Contains("@ShowBlogImage") Or FilterString.Contains("@NewBlogImage") Then
				If Not GetImageData(ImageGenre.Blog).IsAvailable Or ssh_LockImage = True Or ssh_CustomSlideshow = True Then Return False
			End If
			If FilterString.Contains("@ShowLikedImage") Then
				If Not GetImageData(ImageGenre.Liked).IsAvailable Or ssh_LockImage = True Or ssh_CustomSlideshow = True Then Return False
			End If
			If FilterString.Contains("@ShowDislikedImage") Then
				If Not GetImageData(ImageGenre.Disliked).IsAvailable Or ssh_LockImage = True Or ssh_CustomSlideshow = True Then Return False
			End If

			'TODO: Add ImageDataContainerUsage to filter @ShowLocalImage correct.
			If FilterString.Contains("@ShowLocalImage") And My.Settings.CBIHardcore = False And My.Settings.CBISoftcore = False And My.Settings.CBILesbian = False And
			   My.Settings.CBIBlowjob = False And My.Settings.CBIFemdom = False And My.Settings.CBILezdom = False And My.Settings.CBIHentai = False And
				  My.Settings.CBIGay = False And My.Settings.CBIMaledom = False And My.Settings.CBICaptions = False And My.Settings.CBIGeneral = False Then Return False
			If FilterString.Contains("@ShowLocalImage") Then
				If FlagExists("SYS_NoPornAllowed") = True Or ssh_LockImage = True Then Return False
			End If
			If FilterString.Contains("@ShowButtImage") Or FilterString.Contains("@ShowButtsImage") Then
				If Not GetImageData(ImageGenre.Butt).IsAvailable Or ssh_LockImage = True Or ssh_CustomSlideshow = True Then Return False
			End If
			If FilterString.Contains("@ShowBoobsImage") Or FilterString.Contains("@ShowBoobImage") Then
				If Not GetImageData(ImageGenre.Boobs).IsAvailable Or ssh_LockImage = True Or ssh_CustomSlideshow = True Then Return False
			End If
			If FilterString.Contains("@ShowLocalImage") Or FilterString.Contains("@ShowButtImage") Or FilterString.Contains("@ShowBoobsImage") Or FilterString.Contains("@ShowButtsImage") Or FilterString.Contains("@ShowBoobsImage") Then
				If ssh_CustomSlideshow = True Or ssh_LockImage = True Then Return False
			End If
		End If

		If FilterString.Contains("@1MinuteHold") Then
			If ssh_SubHoldingEdge = False Or ssh_HoldEdgeTime < 60 Or ssh_HoldEdgeTime > 119 Then Return False
		End If
		If FilterString.Contains("@2MinuteHold") Then
			If ssh_SubHoldingEdge = False Or ssh_HoldEdgeTime < 120 Or ssh_HoldEdgeTime > 179 Then Return False
		End If
		If FilterString.Contains("@3MinuteHold") Then
			If ssh_SubHoldingEdge = False Or ssh_HoldEdgeTime < 180 Or ssh_HoldEdgeTime > 239 Then Return False
		End If
		If FilterString.Contains("@4MinuteHold") Then
			If ssh_SubHoldingEdge = False Or ssh_HoldEdgeTime < 240 Or ssh_HoldEdgeTime > 299 Then Return False
		End If
		If FilterString.Contains("@5MinuteHold") Then
			If ssh_SubHoldingEdge = False Or ssh_HoldEdgeTime < 300 Or ssh_HoldEdgeTime > 599 Then Return False
		End If
		If FilterString.Contains("@10MinuteHold") Then
			If ssh_SubHoldingEdge = False Or ssh_HoldEdgeTime < 600 Or ssh_HoldEdgeTime > 899 Then Return False
		End If
		If FilterString.Contains("@15MinuteHold") Then
			If ssh_SubHoldingEdge = False Or ssh_HoldEdgeTime < 900 Or ssh_HoldEdgeTime > 1799 Then Return False
		End If
		If FilterString.Contains("@30MinuteHold") Then
			If ssh_SubHoldingEdge = False Or ssh_HoldEdgeTime < 1800 Or ssh_HoldEdgeTime > 2699 Then Return False
		End If
		If FilterString.Contains("@45MinuteHold") Then
			If ssh_SubHoldingEdge = False Or ssh_HoldEdgeTime < 2700 Or ssh_HoldEdgeTime > 3599 Then Return False
		End If
		If FilterString.Contains("@60MinuteHold") Then
			If ssh_SubHoldingEdge = False Or ssh_HoldEdgeTime < 3600 Then Return False
		End If

		If FilterString.Contains("@CBTLevel1") And FrmSettings.CBTSlider.Value <> 1 Then Return False
		If FilterString.Contains("@CBTLevel2") And FrmSettings.CBTSlider.Value <> 2 Then Return False
		If FilterString.Contains("@CBTLevel3") And FrmSettings.CBTSlider.Value <> 3 Then Return False
		If FilterString.Contains("@CBTLevel4") And FrmSettings.CBTSlider.Value <> 4 Then Return False
		If FilterString.Contains("@CBTLevel5") And FrmSettings.CBTSlider.Value <> 5 Then Return False
		If FilterString.Contains("@SubCircumcised") And FrmSettings.CBSubCircumcised.Checked = False Then Return False
		If FilterString.Contains("@SubNotCircumcised") And FrmSettings.CBSubCircumcised.Checked = True Then Return False
		If FilterString.Contains("@SubPierced") And FrmSettings.CBSubPierced.Checked = False Then Return False
		If FilterString.Contains("@SubNotPierced") And FrmSettings.CBSubPierced.Checked = True Then Return False
		'If FilterString.Contains("@ShowTaggedImage") And LocalTagImageList.Count = 0 Then Return False
		If FilterString.Contains("@BeforeTease") And ssh_BeforeTease = False Then Return False
		If FilterString.Contains("@OrgasmDenied") And ssh_OrgasmDenied = False Then Return False
		If FilterString.Contains("@OrgasmAllowed") And ssh_OrgasmAllowed = False Then Return False
		If FilterString.Contains("@OrgasmRuined") And ssh_OrgasmRuined = False Then Return False
		If FilterString.Contains("@ApathyLevel(") Then
			If FilterCheck(GetParentheses(FilterString, "@ApathyLevel("), FrmSettings.NBEmpathy) = False Then Return False
		End If

		If FilterString.Contains("@ApathyLevel1") And FrmSettings.NBEmpathy.Value <> 1 Then Return False
		If FilterString.Contains("@ApathyLevel2") And FrmSettings.NBEmpathy.Value <> 2 Then Return False
		If FilterString.Contains("@ApathyLevel3") And FrmSettings.NBEmpathy.Value <> 3 Then Return False
		If FilterString.Contains("@ApathyLevel4") And FrmSettings.NBEmpathy.Value <> 4 Then Return False
		If FilterString.Contains("@ApathyLevel5") And FrmSettings.NBEmpathy.Value <> 5 Then Return False
		If FilterString.Contains("@InChastity") And My.Settings.Chastity = False Then Return False
		If FilterString.Contains("@NotInChastity") And My.Settings.Chastity = True Then Return False
		If FilterString.Contains("@HasChastity") And FrmSettings.CBOwnChastity.Checked = False Then Return False
		If FilterString.Contains("@DoesNotHaveChastity") And FrmSettings.CBOwnChastity.Checked = True Then Return False
		If FilterString.Contains("@ChastityPA") And FrmSettings.CBChastityPA.Checked = False Then Return False
		If FilterString.Contains("@ChastitySpikes") And FrmSettings.CBChastitySpikes.Checked = False Then Return False
		If FilterString.Contains("@VitalSub") And CBVitalSub.Checked = False Then Return False
		If FilterString.Contains("@VitalSubAssignment") Then
			If CBVitalSub.Checked = False Or CBVitalSubDomTask.Checked = False Then Return False
		End If

		If FilterString.Contains("@RuinTaunt") Then
			If ssh_EdgeToRuin = False Or ssh_EdgeToRuinSecret = True Then Return False
		End If

		If FilterString.Contains("@VideoHardcore") Then
			If ssh_VideoTease = False Or ssh_VideoType <> "Hardcore" Then Return False
		End If
		If FilterString.Contains("@VideoSoftcore") Then
			If ssh_VideoTease = False Or ssh_VideoType <> "Softcore" Then Return False
		End If
		If FilterString.Contains("@VideoLesbian") Then
			If ssh_VideoTease = False Or ssh_VideoType <> "Lesbian" Then Return False
		End If
		If FilterString.Contains("@VideoBlowjob") Then
			If ssh_VideoTease = False Or ssh_VideoType <> "Blowjob" Then Return False
		End If
		If FilterString.Contains("@VideoFemdom") Then
			If ssh_VideoTease = False Or ssh_VideoType <> "Femdom" Then Return False
		End If
		If FilterString.Contains("@VideoFemsub") Then
			If ssh_VideoTease = False Or ssh_VideoType <> "Femsub" Then Return False
		End If
		If FilterString.Contains("@VideoGeneral") Then
			If ssh_VideoTease = False Or ssh_VideoType <> "General" Then Return False
		End If

		If FilterString.Contains("@VideoHardcoreDomme") Then
			If ssh_VideoTease = False Or ssh_VideoType <> "HardcoreD" Then Return False
		End If
		If FilterString.Contains("@VideoSoftcoreDomme") Then
			If ssh_VideoTease = False Or ssh_VideoType <> "SoftcoreD" Then Return False
		End If
		If FilterString.Contains("@VideoLesbianDomme") Then
			If ssh_VideoTease = False Or ssh_VideoType <> "LesbianD" Then Return False
		End If
		If FilterString.Contains("@VideoBlowjobDomme") Then
			If ssh_VideoTease = False Or ssh_VideoType <> "BlowjobD" Then Return False
		End If
		If FilterString.Contains("@VideoFemdomDomme") Then
			If ssh_VideoTease = False Or ssh_VideoType <> "FemdomD" Then Return False
		End If
		If FilterString.Contains("@VideoFemsubDomme") Then
			If ssh_VideoTease = False Or ssh_VideoType <> "FemsubD" Then Return False
		End If
		If FilterString.Contains("@VideoGeneralDomme") Then
			If ssh_VideoTease = False Or ssh_VideoType <> "GeneralD" Then Return False
		End If


		If FilterString.Contains("@CockTorture") And FrmSettings.CBCBTCock.Checked = False Then Return False
		If FilterString.Contains("@BallTorture") And FrmSettings.CBCBTBalls.Checked = False Then Return False
		If FilterString.Contains("@BallTorture0") And ssh_CBTBallsCount <> 0 Then Return False
		If FilterString.Contains("@BallTorture1") And ssh_CBTBallsCount <> 1 Then Return False
		If FilterString.Contains("@BallTorture2") And ssh_CBTBallsCount <> 2 Then Return False
		If FilterString.Contains("@BallTorture3") And ssh_CBTBallsCount <> 3 Then Return False
		If FilterString.Contains("@BallTorture4+") And ssh_CBTBallsCount < 4 Then Return False
		If FilterString.Contains("@CockTorture0") And ssh_CBTCockCount <> 0 Then Return False
		If FilterString.Contains("@CockTorture1") And ssh_CBTCockCount <> 1 Then Return False
		If FilterString.Contains("@CockTorture2") And ssh_CBTCockCount <> 2 Then Return False
		If FilterString.Contains("@CockTorture3") And ssh_CBTCockCount <> 3 Then Return False
		If FilterString.Contains("@CockTorture4+") And ssh_CBTCockCount < 4 Then Return False
		If FilterString.Contains("@Variable[") Then
			If CheckVariable(FilterString) = False Then Return False
		End If

		If FilterString.Contains("@CheckDate(") And Linear = False Then
			If CheckDateList(FilterString) = False Then Return False
		End If

		If FilterString.Contains("@DommeTag(") Then
			Dim g As String = "breakpoint"
			Debug.Print("Domme Return -= " & GetDommeImage(GetParentheses(FilterString, "@DommeTag(")))
			If GetDommeImage(GetParentheses(FilterString, "@DommeTag(")) = "" Or ssh_LockImage = True Then Return False
		End If

		If FilterString.Contains("@ImageTag(") Then
			If GetLocalImage(GetParentheses(FilterString, "@ImageTag(")) = String.Empty Then Return False
		End If

		If FilterString.Contains("@Stroking") Or FilterString.Contains("@SubStroking") Then
			If ssh_SubStroking = False Then Return False
		End If

		If FilterString.Contains("@NotStroking") Or FilterString.Contains("@SubNotStroking") Then
			If ssh_SubStroking = True Then Return False
		End If

		If FilterString.Contains("@Edging") Or FilterString.Contains("@SubEdging") Then
			If ssh_SubEdging = False Then Return False
		End If

		If FilterString.Contains("@NotEdging") Or FilterString.Contains("@SubNotEdging") Then
			If ssh_SubEdging = True Then Return False
		End If

		If FilterString.Contains("@HoldingTheEdge") Or FilterString.Contains("@SubHoldingTheEdge") Then
			If ssh_SubHoldingEdge = False Then Return False
		End If

		If FilterString.Contains("@NotHoldingTheEdge") Or FilterString.Contains("@SubNotHoldingTheEdge") Then
			If ssh_SubHoldingEdge = True Then Return False
		End If

		If FilterString.Contains("@Morning") And ssh_GeneralTime <> "Morning" Then Return False
		If FilterString.Contains("@Afternoon") And ssh_GeneralTime <> "Afternoon" Then Return False
		If FilterString.Contains("@Night") And ssh_GeneralTime <> "Night" Then Return False
		If FilterString.Contains("@GoodMood") And ssh_DommeMood <= FrmSettings.NBDomMoodMax.Value Then Return False
		If FilterString.Contains("@BadMood") And ssh_DommeMood >= FrmSettings.NBDomMoodMin.Value Then Return False
		If FilterString.Contains("@NeutralMood") Then
			If ssh_DommeMood > FrmSettings.NBDomMoodMax.Value Or ssh_DommeMood < FrmSettings.NBDomMoodMin.Value Then Return False
		End If

		If FilterString.Contains("@SetModule(") Then
			If ssh_SetModule <> "" Or ssh_BookmarkModule = True Then Return False
		End If

		If FilterString.Contains("@OrgasmRestricted") And ssh_OrgasmRestricted = False Then Return False
		If FilterString.Contains("@OrgasmNotRestricted") And ssh_OrgasmRestricted = True Then Return False
		If FilterString.Contains("@SubWorshipping") And ssh_WorshipMode = False Then Return False
		If FilterString.Contains("@SubNotWorshipping") And ssh_WorshipMode = True Then Return False
		If FilterString.Contains("@LongHold") Then
			If ssh_LongHold = False Or ssh_SubHoldingEdge = False Then Return False
		End If

		If FilterString.Contains("@ExtremeHold") Then
			If ssh_ExtremeHold = False Or ssh_SubHoldingEdge = False Then Return False
		End If

		If FilterString.Contains("@AssWorship") Then
			If ssh_WorshipTarget <> "Ass" Or ssh_WorshipMode = False Then Return False
		End If

		If FilterString.Contains("@BoobWorship") Then
			If ssh_WorshipTarget <> "Boobs" Or ssh_WorshipMode = False Then Return False
		End If

		If FilterString.Contains("@PussyWorship") Then
			If ssh_WorshipTarget <> "Pussy" Or ssh_WorshipMode = False Then Return False
		End If

		If FilterString.Contains("@Contact1") Then
			If ssh_GlitterTease = False Or Not ssh_Group.Contains("1") Then Return False
		End If

		If FilterString.Contains("@Contact2") Then
			If ssh_GlitterTease = False Or Not ssh_Group.Contains("2") Then Return False
		End If

		If FilterString.Contains("@Contact3") Then
			If ssh_GlitterTease = False Or Not ssh_Group.Contains("3") Then Return False
		End If

		If FilterString.Contains("@Group(") Then
			Dim GroupCheck As String = GetParentheses(FilterString, "@Group(")
			If GroupCheck.Contains("D") Then
				If ssh_GlitterTease = False Or Not ssh_Group.Contains("D") Then Return False
			End If
			If GroupCheck.Contains("1") Then
				If ssh_GlitterTease = False Or Not ssh_Group.Contains("1") Then Return False
			End If
			If GroupCheck.Contains("2") Then
				If ssh_GlitterTease = False Or Not ssh_Group.Contains("2") Then Return False
			End If
			If GroupCheck.Contains("3") Then
				If ssh_GlitterTease = False Or Not ssh_Group.Contains("3") Then Return False
			End If
		End If

		If FilterString.Contains("@Flag(") Then
			Dim WriteFlag As String = GetParentheses(FilterString, "@Flag(")

			If Not File.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Flags\" & WriteFlag) And
			Not File.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Flags\Temp\" & WriteFlag) Then Return False

		End If

		If FilterString.Contains("@NotFlag(") Then
			Dim WriteFlag As String = GetParentheses(FilterString, "@NotFlag(")

			If File.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Flags\" & WriteFlag) Or
			File.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Flags\Temp\" & WriteFlag) Then Return False

		End If

		If FilterString.Contains("@Month(") Then
			If GetMatch(FilterString, "@Month(", DateAndTime.Now.Month) = False Then Return False
		End If

		If FilterString.Contains("@Day(") Then
			If GetMatch(FilterString, "@Day(", DateAndTime.Now.Day) = False Then Return False
		End If


		If FilterString.Contains("@Info") Then Return False


		If FilterString.Contains("@ShowTaggedImage") Then

			ssh_LocalTagImageList.Clear()


			'TODO: remove unsecure IO.Access to file, for there is no DirectoryCheck.
			If File.Exists(Application.StartupPath & "\Images\System\LocalImageTags.txt") Then
				' Read all lines of given file.
				ssh_LocalTagImageList = Txt2List(Application.StartupPath & "\Images\System\LocalImageTags.txt")

				'If Not supportedExtensions.Contains(Path.GetExtension(LCase(fi))) Then


				For i As Integer = ssh_LocalTagImageList.Count - 1 To 0 Step -1
					Dim LocalCheck As String() = Split(ssh_LocalTagImageList(i))
					Dim LocalString As String = LocalCheck(0)
					Debug.Print("LocalString = " & LocalString)
					If Not LCase(LocalString).Contains(".jpg") And Not LCase(LocalString).Contains(".jpeg") And Not LCase(LocalString).Contains(".bmp") And
					 Not LCase(LocalString).Contains(".png") And Not LCase(LocalString).Contains(".gif") Then
						Debug.Print("LocalTag Check Doesn't contain extension")
						For x As Integer = 1 To LocalCheck.Count - 1
							LocalString = LocalString & " " & LocalCheck(x)
							If LCase(LocalString).Contains(".jpg") Or LCase(LocalString).Contains(".jpeg") Or LCase(LocalString).Contains(".bmp") Or
							LCase(LocalString).Contains(".png") Or LCase(LocalString).Contains(".gif") Then Exit For
						Next
					End If
					Debug.Print("Local Tag check - " & LocalString)
					If Not File.Exists(LocalString) Then ssh_LocalTagImageList.Remove(ssh_LocalTagImageList(i))
				Next

			End If

			'ListCountTotal = -1
			Dim TagCount As Integer = 0


			If FilterString.Contains("@ShowTaggedImage") And FilterString.Contains("@Tag") Then
				Dim TSplit As String() = Split(FilterString)
				For j As Integer = 0 To TSplit.Length - 1
					If TSplit(j).Contains("@Tag") Then
						Dim TString As String = TSplit(j).Replace("@Tag", "")
						For k As Integer = ssh_LocalTagImageList.Count - 1 To 0 Step -1
							If ssh_LocalTagImageList(k).Contains(TString) Then TagCount += 1
						Next
						If TagCount = 0 Then Return False
						TagCount = 0
					End If
				Next
			End If



			If FilterString.Contains("@ShowTaggedImage") And ssh_LocalTagImageList.Count = 0 Then Return False


		End If



		Return True

	End Function


	Public Function GetFilter2(ByVal FilterString As String) As Boolean


		Dim __ConditionDic As New Dictionary(Of String, Boolean)(System.StringComparer.OrdinalIgnoreCase)
		Try
			'===============================================================================
			'							Dictionary Setup Description
			' 1st Parameter: "Key" this is the Command as String preceded with @
			' 2nd Parameter: "Value" These are the conditions that must be met to EXCLUDE a line.
			'
			'		 If "Value" is "True", all lines containing "Key" will be excuded.
			'
			'===============================================================================
			With __ConditionDic
				.Add("@Crazy", FrmSettings.crazyCheckBox.Checked = False)
				.Add("@Vulgar", FrmSettings.vulgarCheckBox.Checked = False)
				.Add("@Supremacist", FrmSettings.supremacistCheckBox.Checked = False)
				.Add("@Sadistic", FrmSettings.sadisticCheckBox.Checked = False)
				.Add("@Degrading", FrmSettings.degradingCheckBox.Checked = False)
				.Add("@DommeLevel1", FrmSettings.domlevelNumBox.Value <> 1)
				.Add("@DommeLevel2", FrmSettings.domlevelNumBox.Value <> 2)
				.Add("@DommeLevel3", FrmSettings.domlevelNumBox.Value <> 3)
				.Add("@DommeLevel4", FrmSettings.domlevelNumBox.Value <> 4)
				.Add("@DommeLevel5", FrmSettings.domlevelNumBox.Value <> 5)
				.Add("@SelfYoung", FrmSettings.domageNumBox.Value > FrmSettings.NBSelfAgeMin.Value - 1)
				.Add("@SelfOld", FrmSettings.domageNumBox.Value < FrmSettings.NBSelfAgeMax.Value + 1)
				.Add("@ACup", FrmSettings.boobComboBox.Text <> "A" Or ssh_JustShowedBlogImage = True)
				.Add("@BCup", FrmSettings.boobComboBox.Text <> "B" Or ssh_JustShowedBlogImage = True)
				.Add("@CCup", FrmSettings.boobComboBox.Text <> "C" Or ssh_JustShowedBlogImage = True)
				.Add("@DCup", FrmSettings.boobComboBox.Text <> "D" Or ssh_JustShowedBlogImage = True)
				.Add("@DDCup", FrmSettings.boobComboBox.Text <> "DD" Or ssh_JustShowedBlogImage = True)
				.Add("@DDD+Cup", FrmSettings.boobComboBox.Text <> "DDD+" Or ssh_JustShowedBlogImage = True)
				.Add("@CockSmall", FrmSettings.CockSizeNumBox.Value >= FrmSettings.NBAvgCockMin.Value)
				.Add("@CockLarge", FrmSettings.CockSizeNumBox.Value <= FrmSettings.NBAvgCockMax.Value)
				.Add("@CockAverage", FrmSettings.CockSizeNumBox.Value < FrmSettings.NBAvgCockMin.Value Or FrmSettings.CockSizeNumBox.Value > FrmSettings.NBAvgCockMax.Value)
				.Add("@SubYoung", FrmSettings.subAgeNumBox.Value >= FrmSettings.NBSubAgeMin.Value)
				.Add("@SubOld", FrmSettings.subAgeNumBox.Value <= FrmSettings.NBSubAgeMax.Value)
				.Add("@SubBirthday", FrmSettings.NBBirthdayMonth.Value <> Month(Date.Now) And FrmSettings.NBBirthdayDay.Value <> DateAndTime.Day(Date.Now))
				.Add("@ValentinesDay", Month(Date.Now) <> 2 And DateAndTime.Day(Date.Now) <> 14)
				.Add("@ChristmasEve", Month(Date.Now) <> 12 And DateAndTime.Day(Date.Now) <> 24)
				.Add("@ChristmasDay", Month(Date.Now) <> 12 And DateAndTime.Day(Date.Now) <> 25)
				.Add("@NewYearsEve", Month(Date.Now) <> 12 And DateAndTime.Day(Date.Now) <> 31)
				.Add("@NewYearsDay", Month(Date.Now) <> 12 And DateAndTime.Day(Date.Now) <> 25)
				.Add("@TagFace", Not ssh_FoundTag.Contains("TagFace"))
				.Add("@TagBoobs", Not ssh_FoundTag.Contains("TagBoobs"))
				.Add("@TagPussy", Not ssh_FoundTag.Contains("TagPussy"))
				.Add("@TagAss", Not ssh_FoundTag.Contains("TagAss"))
				.Add("@TagFeet", Not ssh_FoundTag.Contains("TagFeet"))
				.Add("@TagLegs", Not ssh_FoundTag.Contains("TagLegs"))
				.Add("@TagMasturbating", Not ssh_FoundTag.Contains("TagMasturbating"))
				.Add("@TagSucking", Not ssh_FoundTag.Contains("TagSucking"))
				.Add("@TagFullyDressed", Not ssh_FoundTag.Contains("TagFullyDressed"))
				.Add("@TagHalfDressed", Not ssh_FoundTag.Contains("TagHalfDressed"))
				.Add("@TagGarmentCovering", Not ssh_FoundTag.Contains("TagGarmentCovering"))
				.Add("@TagHandsCovering", Not ssh_FoundTag.Contains("TagHandsCovering"))
				.Add("@TagNaked", Not ssh_FoundTag.Contains("TagNaked"))
				.Add("@TagSideView", Not ssh_FoundTag.Contains("TagSideView"))
				.Add("@TagCloseUp", Not ssh_FoundTag.Contains("TagCloseUp"))
				.Add("@TagPiercing", Not ssh_FoundTag.Contains("TagPiercing"))
				.Add("@TagSmiling", Not ssh_FoundTag.Contains("TagSmiling"))
				.Add("@TagGlaring", Not ssh_FoundTag.Contains("TagGlaring"))
				.Add("@TagGarment", Not ssh_FoundTag.Contains("TagGarment"))
				.Add("@TagUnderwear", Not ssh_FoundTag.Contains("TagUnderwear"))
				.Add("@TagTattoo", Not ssh_FoundTag.Contains("TagTattoo"))
				.Add("@TagSexToy", Not ssh_FoundTag.Contains("TagSexToy"))
				.Add("@TagFurniture", Not ssh_FoundTag.Contains("TagFurniture"))
				.Add("@FirstRound", ssh_FirstRound = False)
				.Add("@NotFirstRound", ssh_FirstRound = True)
				.Add("@StrokeSpeedMax", StrokePace < NBMaxPace.Value)
				.Add("@StrokeSpeedMin", StrokePace > NBMinPace.Value)
				.Add("@StrokeFaster", StrokePace = NBMaxPace.Value Or ssh_WorshipMode = True)
				.Add("@StrokeFastest", StrokePace = NBMaxPace.Value Or ssh_WorshipMode = True)
				.Add("@StrokeSlower", StrokePace = NBMinPace.Value Or ssh_WorshipMode = True)
				.Add("@StrokeSlowest", StrokePace = NBMinPace.Value Or ssh_WorshipMode = True)
				.Add("@AlwaysAllowsOrgasm", FrmSettings.alloworgasmComboBox.Text <> "Always Allows")
				.Add("@OftenAllowsOrgasm", FrmSettings.alloworgasmComboBox.Text <> "Often Allows")
				.Add("@SometimesAllowsOrgasm", FrmSettings.alloworgasmComboBox.Text <> "Sometimes Allows")
				.Add("@RarelyAllowsOrgasm", FrmSettings.alloworgasmComboBox.Text <> "Rarely Allows")
				.Add("@NeverAllowsOrgasm", FrmSettings.alloworgasmComboBox.Text <> "Never Allows")
				.Add("@AlwaysRuinsOrgasm", FrmSettings.ruinorgasmComboBox.Text <> "Always Ruins")
				.Add("@OftenRuinsOrgasm", FrmSettings.ruinorgasmComboBox.Text <> "Often Ruins")
				.Add("@SometimesRuinsOrgasm", FrmSettings.ruinorgasmComboBox.Text <> "Sometimes Ruins")
				.Add("@RarelyRuinsOrgasm", FrmSettings.ruinorgasmComboBox.Text <> "Rarely Ruins")
				.Add("@NeverRuinsOrgasm", FrmSettings.ruinorgasmComboBox.Text <> "Never Ruins")
				.Add("@NotAlwaysAllowsOrgasm", FrmSettings.alloworgasmComboBox.Text = "Always Allows")
				.Add("@NotNeverAllowsOrgasm", FrmSettings.alloworgasmComboBox.Text = "Never Allows")
				.Add("@NotAlwaysRuinsOrgasm", FrmSettings.ruinorgasmComboBox.Text = "Always Ruins")
				.Add("@NotNeverRuinsOrgasm", FrmSettings.ruinorgasmComboBox.Text = "Never Allows")
				.Add("@LongEdge", ssh_LongEdge = False Or FrmSettings.CBLongEdgeTaunts.Checked = False)
				.Add("@InterruptLongEdge", ssh_LongEdge = False Or FrmSettings.CBLongEdgeInterrupts.Checked = False Or ssh_TeaseTick < 1 Or ssh_RiskyEdges = True)
				.Add("@ShowHardcoreImage", Not Directory.Exists(My.Settings.IHardcore) Or My.Settings.CBIHardcore = False Or ssh_CustomSlideshow = True Or FlagExists("SYS_NoPornAllowed") = True Or ssh_LockImage = True)
				.Add("@ShowSoftcoreImage", Not Directory.Exists(My.Settings.ISoftcore) Or My.Settings.CBISoftcore = False Or ssh_CustomSlideshow = True Or FlagExists("SYS_NoPornAllowed") = True Or ssh_LockImage = True)
				.Add("@ShowLesbianImage", Not Directory.Exists(My.Settings.ILesbian) Or My.Settings.CBILesbian = False Or ssh_CustomSlideshow = True Or FlagExists("SYS_NoPornAllowed") = True Or ssh_LockImage = True)
				.Add("@ShowBlowjobImage", Not Directory.Exists(My.Settings.IBlowjob) Or My.Settings.CBIBlowjob = False Or ssh_CustomSlideshow = True Or FlagExists("SYS_NoPornAllowed") = True Or ssh_LockImage = True)
				.Add("@ShowFemdomImage", Not Directory.Exists(My.Settings.IFemdom) Or My.Settings.CBIFemdom = False Or ssh_CustomSlideshow = True Or FlagExists("SYS_NoPornAllowed") = True Or ssh_LockImage = True)
				.Add("@ShowLezdomImage", Not Directory.Exists(My.Settings.ILezdom) Or My.Settings.CBILezdom = False Or ssh_CustomSlideshow = True Or FlagExists("SYS_NoPornAllowed") = True Or ssh_LockImage = True)
				.Add("@ShowHentaiImage", Not Directory.Exists(My.Settings.IHentai) Or My.Settings.CBIHentai = False Or ssh_CustomSlideshow = True Or FlagExists("SYS_NoPornAllowed") = True Or ssh_LockImage = True)
				.Add("@ShowGayImage", Not Directory.Exists(My.Settings.IGay) Or My.Settings.CBIGay = False Or ssh_CustomSlideshow = True Or FlagExists("SYS_NoPornAllowed") = True Or ssh_LockImage = True)
				.Add("@ShowMaledomImage", Not Directory.Exists(My.Settings.IMaledom) Or My.Settings.CBIMaledom = False Or ssh_CustomSlideshow = True Or FlagExists("SYS_NoPornAllowed") = True Or ssh_LockImage = True)
				.Add("@ShowCaptionsImage", Not Directory.Exists(My.Settings.ICaptions) Or My.Settings.CBICaptions = False Or ssh_CustomSlideshow = True Or FlagExists("SYS_NoPornAllowed") = True Or ssh_LockImage = True)
				.Add("@ShowGeneralImage", Not Directory.Exists(My.Settings.IGeneral) Or My.Settings.CBIGeneral = False Or ssh_CustomSlideshow = True Or FlagExists("SYS_NoPornAllowed") = True Or ssh_LockImage = True)
				.Add("@ShowBlogImage", FrmSettings.URLFileList.CheckedItems.Count = 0 Or ssh_CustomSlideshow = True Or FlagExists("SYS_NoPornAllowed") = True Or ssh_LockImage = True)
				.Add("@NewBlogImage", __ConditionDic("@ShowBlogImage")) ' duplicate Command, lets get the Value af the other one.
				.Add("@ShowLocalImage", FlagExists("SYS_NoPornAllowed") = True Or ssh_CustomSlideshow = True Or ssh_LockImage = True _
					  Or (My.Settings.CBIHardcore = False And My.Settings.CBISoftcore = False And My.Settings.CBILesbian = False And My.Settings.CBIBlowjob = False _
					   And My.Settings.CBIFemdom = False And My.Settings.CBILezdom = False And My.Settings.CBIHentai = False And My.Settings.CBIGay = False _
					   And My.Settings.CBIMaledom = False And My.Settings.CBICaptions = False And My.Settings.CBIGeneral = False))
				'.Add("@ShowButtImage", Not Directory.Exists(FrmSettings.LBLButtPath.Text) And Not File.Exists(FrmSettings.LBLButtURL.Text) Or FlagExists("SYS_NoPornAllowed") = True Or CustomSlideshow = True Or LockImage = True)
				'.Add("@ShowButtsImage", __ConditionDic("@ShowButtImage")) ' duplicate Command, lets get the Value af the other one.
				'.Add("@ShowBoobImage", Not Directory.Exists(FrmSettings.LBLBoobPath.Text) And Not File.Exists(FrmSettings.LBLBoobURL.Text) Or FlagExists("SYS_NoPornAllowed") = True Or CustomSlideshow = True Or LockImage = True)
				'.Add("@ShowBoobsImage", __ConditionDic("@ShowBoobImage")) ' duplicate Command, lets get the Value af the other one.
				.Add("@1MinuteHold", ssh_SubHoldingEdge = False Or ssh_HoldEdgeTime < 60 Or ssh_HoldEdgeTime > 119)
				.Add("@2MinuteHold", ssh_SubHoldingEdge = False Or ssh_HoldEdgeTime < 120 Or ssh_HoldEdgeTime > 179)
				.Add("@3MinuteHold", ssh_SubHoldingEdge = False Or ssh_HoldEdgeTime < 180 Or ssh_HoldEdgeTime > 239)
				.Add("@4MinuteHold", ssh_SubHoldingEdge = False Or ssh_HoldEdgeTime < 240 Or ssh_HoldEdgeTime > 299)
				.Add("@5MinuteHold", ssh_SubHoldingEdge = False Or ssh_HoldEdgeTime < 300 Or ssh_HoldEdgeTime > 599)
				.Add("@10MinuteHold", ssh_SubHoldingEdge = False Or ssh_HoldEdgeTime < 600 Or ssh_HoldEdgeTime > 899)
				.Add("@15MinuteHold", ssh_SubHoldingEdge = False Or ssh_HoldEdgeTime < 900 Or ssh_HoldEdgeTime > 1799)
				.Add("@30MinuteHold", ssh_SubHoldingEdge = False Or ssh_HoldEdgeTime < 1800 Or ssh_HoldEdgeTime > 2699)
				.Add("@45MinuteHold", ssh_SubHoldingEdge = False Or ssh_HoldEdgeTime < 2700 Or ssh_HoldEdgeTime > 3599)
				.Add("@60MinuteHold", ssh_SubHoldingEdge = False Or ssh_HoldEdgeTime < 3600)
				.Add("@CBTLevel1", FrmSettings.CBTSlider.Value <> 1)
				.Add("@CBTLevel2", FrmSettings.CBTSlider.Value <> 2)
				.Add("@CBTLevel3", FrmSettings.CBTSlider.Value <> 3)
				.Add("@CBTLevel4", FrmSettings.CBTSlider.Value <> 4)
				.Add("@CBTLevel5", FrmSettings.CBTSlider.Value <> 5)
				.Add("@SubCircumcised", FrmSettings.CBSubCircumcised.Checked = False)
				.Add("@SubNotCircumcised", FrmSettings.CBSubCircumcised.Checked = True)
				.Add("@SubPierced", FrmSettings.CBSubPierced.Checked = False)
				.Add("@SubNotPierced", FrmSettings.CBSubPierced.Checked = True)
				.Add("@ShowTaggedImage", ssh_LocalTagImageList.Count = 0) '=>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> For this Condition the tags have be loaded before.
				.Add("@BeforeTease", ssh_BeforeTease = False)
				.Add("@OrgasmDenied", ssh_OrgasmDenied = False)
				.Add("@OrgasmAllowed", ssh_OrgasmAllowed = False)
				.Add("@OrgasmRuined", ssh_OrgasmRuined = False)
				.Add("@ApathyLevel1", FrmSettings.NBEmpathy.Value <> 1)
				.Add("@ApathyLevel2", FrmSettings.NBEmpathy.Value <> 2)
				.Add("@ApathyLevel3", FrmSettings.NBEmpathy.Value <> 3)
				.Add("@ApathyLevel4", FrmSettings.NBEmpathy.Value <> 4)
				.Add("@ApathyLevel5", FrmSettings.NBEmpathy.Value <> 5)
				.Add("@InChastity", My.Settings.Chastity = False)
				.Add("@NotInChastity", My.Settings.Chastity = True)
				.Add("@HasChastity", FrmSettings.CBOwnChastity.Checked = False)
				.Add("@DoesNotHaveChastity", FrmSettings.CBOwnChastity.Checked = True)
				.Add("@ChastityPA", FrmSettings.CBChastityPA.Checked = False)
				.Add("@ChastitySpikes", FrmSettings.CBChastitySpikes.Checked = False)
				.Add("@VitalSub", CBVitalSub.Checked = False)
				.Add("@VitalSubAssignment", CBVitalSub.Checked = False Or CBVitalSubDomTask.Checked = False)
				.Add("@RuinTaunt", ssh_EdgeToRuin = False Or ssh_EdgeToRuinSecret = True)
				.Add("@ShowLikedImage", Not File.Exists(Application.StartupPath & "\Images\System\LikedImageURLs.txt"))
				.Add("@ShowDislikedImage", Not File.Exists(Application.StartupPath & "\Images\System\DislikedImageURLs.txt"))
				.Add("@VideoHardcore", ssh_VideoTease = False Or ssh_VideoType <> "Hardcore")
				.Add("@VideoSoftcore", ssh_VideoTease = False Or ssh_VideoType <> "Softcore")
				.Add("@VideoLesbian", ssh_VideoTease = False Or ssh_VideoType <> "Lesbian")
				.Add("@VideoBlowjob", ssh_VideoTease = False Or ssh_VideoType <> "Blowjob")
				.Add("@VideoFemdom", ssh_VideoTease = False Or ssh_VideoType <> "Femdom")
				.Add("@VideoFemsub", ssh_VideoTease = False Or ssh_VideoType <> "Femsub")
				.Add("@VideoGeneral", ssh_VideoTease = False Or ssh_VideoType <> "General")
				.Add("@VideoHardcoreDomme", ssh_VideoTease = False Or ssh_VideoType <> "HardcoreD")
				.Add("@VideoSoftcoreDomme", ssh_VideoTease = False Or ssh_VideoType <> "SoftcoreD")
				.Add("@VideoLesbianDomme", ssh_VideoTease = False Or ssh_VideoType <> "LesbianD")
				.Add("@VideoBlowjobDomme", ssh_VideoTease = False Or ssh_VideoType <> "BlowjobD")
				.Add("@VideoFemdomDomme", ssh_VideoTease = False Or ssh_VideoType <> "FemdomD")
				.Add("@VideoFemsubDomme", ssh_VideoTease = False Or ssh_VideoType <> "FemsubD")
				.Add("@VideoGeneralDomme", ssh_VideoTease = False Or ssh_VideoType <> "GeneralD")
				.Add("@CockTorture", FrmSettings.CBCBTCock.Checked = False)
				.Add("@BallTorture", FrmSettings.CBCBTBalls.Checked = False)
				.Add("@BallTorture0", ssh_CBTBallsCount <> 0)
				.Add("@BallTorture1", ssh_CBTBallsCount <> 1)
				.Add("@BallTorture2", ssh_CBTBallsCount <> 2)
				.Add("@BallTorture3", ssh_CBTBallsCount <> 3)
				.Add("@BallTorture4+", ssh_CBTBallsCount < 4)
				.Add("@CockTorture0", ssh_CBTCockCount <> 0)
				.Add("@CockTorture1", ssh_CBTCockCount <> 1)
				.Add("@CockTorture2", ssh_CBTCockCount <> 2)
				.Add("@CockTorture3", ssh_CBTCockCount <> 3)
				.Add("@CockTorture4+", ssh_CBTCockCount < 4)
				.Add("@Contact1", ssh_GlitterTease = False Or Not ssh_Group.Contains("1"))
				.Add("@Contact2", ssh_GlitterTease = False Or Not ssh_Group.Contains("2"))
				.Add("@Contact3", ssh_GlitterTease = False Or Not ssh_Group.Contains("3"))
				.Add("@Stroking", ssh_SubStroking = False)
				.Add("@SubStroking", ssh_SubStroking = False)
				.Add("@NotStroking", ssh_SubStroking = True)
				.Add("@SubNotStroking", ssh_SubStroking = True)
				.Add("@Edging", ssh_SubEdging = False)
				.Add("@SubEdging", ssh_SubEdging = False)
				.Add("@NotEdging", ssh_SubEdging = True)
				.Add("@SubNotEdging", ssh_SubEdging = True)
				.Add("@HoldingTheEdge", ssh_SubHoldingEdge = False)
				.Add("@SubHoldingTheEdge", ssh_SubHoldingEdge = False)
				.Add("@NotHoldingTheEdge", ssh_SubHoldingEdge = True)
				.Add("@SubNotHoldingTheEdge", ssh_SubHoldingEdge = True)
				.Add("@Morning", ssh_GeneralTime <> "Morning")
				.Add("@Afternoon", ssh_GeneralTime <> "Afternoon")
				.Add("@Night", ssh_GeneralTime <> "Night")
				.Add("@GoodMood", ssh_DommeMood <= FrmSettings.NBDomMoodMax.Value)
				.Add("@BadMood", ssh_DommeMood >= FrmSettings.NBDomMoodMin.Value)
				.Add("@NeutralMood", ssh_DommeMood > FrmSettings.NBDomMoodMax.Value Or ssh_DommeMood < FrmSettings.NBDomMoodMin.Value)
				.Add("@SetModule(", ssh_SetModule <> "" Or ssh_BookmarkModule = True) ' I wonder if this will work.
				.Add("@OrgasmRestricted", ssh_OrgasmRestricted = False)
				.Add("@OrgasmNotRestricted", ssh_OrgasmRestricted = True)
				.Add("@SubWorshipping", ssh_WorshipMode = False)
				.Add("@SubNotWorshipping", ssh_WorshipMode = True)
				.Add("@LongHold", ssh_LongHold = False Or ssh_SubHoldingEdge = False)
				.Add("@ExtremeHold", ssh_ExtremeHold = False Or ssh_SubHoldingEdge = False)
				.Add("@AssWorship", ssh_WorshipTarget <> "Ass" Or ssh_WorshipMode = False)
				.Add("@BoobWorship", ssh_WorshipTarget <> "Boobs" Or ssh_WorshipMode = False)
				.Add("@PussyWorship", ssh_WorshipTarget <> "Pussy" Or ssh_WorshipMode = False)
			End With
		Catch ex As ArgumentException
			'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
			'	                ArgumentException => Will occur everytime until you fix Source Code!
			'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
			Debug.Print("Error on initializing FilterList." & vbCrLf & ex.Message & vbCrLf & ex.StackTrace)
			MsgBox("Error on initializing FilterList. This Error occurs, If you try to add a duplikace Key to the dictionary." &
				"This error is major issue in Code and will occur everytime until you fix this Error. For there is no point in " &
				"further executing the Code, the application will exit after closing this Message." & vbCrLf &
				ex.Message & vbCrLf & ex.StackTrace, MsgBoxStyle.Critical, "Source Code Error")
			Application.Exit()
		End Try


		Try
			' Declare a new regex Instance, for detecting the parameters in a line.
			' Allowed chars for Commands are:		 A-Z a-z 0-9 @ 
			' Allowed Brackets are :				( [
			' Minimum length is 3 Chars, maximum Command length has no restriction.
			Dim __re As Regex = New Regex("@[@\w\d+]{3,}[\(\[]*", RegexOptions.IgnoreCase)


			' Execute regex on current line, to find all containing Commands
			Dim mc As MatchCollection = __re.Matches(FilterString)

			For Each m As Match In mc
				If __ConditionDic.Keys.Contains(m.Value) AndAlso __ConditionDic(m.Value) Then
					'===============================================================================
					'					Known Command - DELETE Condition = TRUE
					'===============================================================================
					' The Command is known and his delete condition is True -> delete line
					Return False

				ElseIf __ConditionDic.Keys.Contains(m.Value) = False Then
					'===============================================================================
					'						Unknown Command / BracketCommand
					'===============================================================================
					Dim Condition As Boolean = False

					Select Case m.Value.ToUpper
						Case "@DommeLevel(".ToUpper : Condition = FilterCheck(GetParentheses(FilterString, "@DommeLevel("), FrmSettings.domlevelNumBox)
						Case "@Cup(".ToUpper : Condition = FilterCheck(GetParentheses(FilterString, "@Cup("), FrmSettings.boobComboBox)
						Case "@AllowsOrgasm(".ToUpper : Condition = FilterCheck(GetParentheses(FilterString, "@AllowsOrgasm("), FrmSettings.alloworgasmComboBox)
						Case "@RuinsOrgasm(".ToUpper : Condition = FilterCheck(GetParentheses(FilterString, "@RuinsOrgasm("), FrmSettings.ruinorgasmComboBox)
						Case "@ApathyLevel(".ToUpper : Condition = FilterCheck(GetParentheses(FilterString, "@ApathyLevel("), FrmSettings.NBEmpathy)
						Case "@Variable[".ToUpper : Condition = CheckVariable(FilterString)
						Case "@CheckDate(".ToUpper : Condition = CheckDateList(FilterString)
						Case "@DommeTag(".ToUpper : Condition = GetDommeImage(GetParentheses(FilterString, "@DommeTag(")) = False Or ssh_LockImage = True
						Case "@ImageTag(".ToUpper : Condition = GetLocalImage(FilterString)
						Case Else
							'<= <= <= <= <= <= <= <= <= <= <= <= <= <= <= <= <= <= <= <= <= <= <= <=
							'					Unknown Command => goto next Match
							'<= <= <= <= <= <= <= <= <= <= <= <= <= <= <= <= <= <= <= <= <= <= <= <=
							Dim f As String = "" ' Debug line to add the ability to set a breakpoint.
							Exit For
					End Select
					' The Command is known and his delete condition is True -> delete line
					If Condition Then Return False
				End If
			Next ' of Regex matches (Commands)
		Catch ex As Exception
			'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
			'                                            All Errors
			'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
			'TODO: Once implemented rethrow all exceptions.
			'Throw
		End Try

		Return True




	End Function


#Region "---------------------------------------------------- Chatbox ---------------------------------------------------------"

	Private Sub ChatText_DocumentCompleted(sender As Object, e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles ChatText.DocumentCompleted
		ScrollChatDown()
	End Sub

	Private Sub ChatText_Resize(sender As Object, e As EventArgs) Handles ChatText.Resize
		If PNLMediaBar.Visible = True Then
			ChatText.Location = New Point(2, 33)
			ChatText.Height = SplitContainer1.Panel2.Height - 67
		Else
			ChatText.Location = New Point(2, 0)
			ChatText.Height = SplitContainer1.Panel2.Height - 34
		End If
	End Sub

	Private Sub ChatText2_DocumentCompleted(sender As Object, e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles ChatText2.DocumentCompleted
		Try
			ChatText2.Document.Window.ScrollTo(Int16.MaxValue, Int16.MaxValue)
		Catch
		End Try
	End Sub

	Private Sub chatBox_DragDrop(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles chatBox.DragDrop
		chatBox.Text = CType(e.Data.GetData(DataFormats.FileDrop), Array).GetValue(0).ToString
		sendButton.PerformClick()
	End Sub

	Private Sub chatBox2_DragDrop(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles ChatBox2.DragDrop
		chatBox.Text = ""
		ChatBox2.Text = CType(e.Data.GetData(DataFormats.FileDrop), Array).GetValue(0).ToString
		sendButton.PerformClick()
	End Sub

	Private Sub chatBox_DragEnter(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles chatBox.DragEnter
		If (e.Data.GetDataPresent(DataFormats.FileDrop)) Then
			e.Effect = DragDropEffects.Copy
		End If
	End Sub

	Private Sub chatBox2_DragEnter(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles ChatBox2.DragEnter
		If (e.Data.GetDataPresent(DataFormats.FileDrop)) Then
			e.Effect = DragDropEffects.Copy
		End If
	End Sub

	Private Sub chatbox_KeyDown(sender As Object, e As KeyEventArgs) Handles chatBox.KeyDown
		If e.KeyCode = Keys.Return Then
			sendButton.PerformClick()
			e.SuppressKeyPress = True
		End If
	End Sub

	Private Sub chatbox2_KeyDown(sender As Object, e As KeyEventArgs) Handles ChatBox2.KeyDown
		If e.KeyCode = Keys.Return Then
			sendButton.PerformClick()
			e.SuppressKeyPress = True
		End If
	End Sub

	Private Sub chatBox_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles chatBox.KeyPress
		If e.KeyChar = Chr(13) Then
			e.Handled = True
			' sendButton.PerformClick()
			e.KeyChar = Chr(0)
		End If
	End Sub

	Private Sub chatBox2_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles ChatBox2.KeyPress
		If e.KeyChar = Chr(13) Then
			e.Handled = True
			' sendButton.PerformClick()
			e.KeyChar = Chr(0)
		End If
	End Sub

#End Region ' Chatbox

#Region "------------------------------------ Avoid the Edge --------------------------------------------"

	Private Sub AvoidTheEdge_Tick(sender As System.Object, e As System.EventArgs) Handles AvoidTheEdge.Tick

		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then Return

		If ssh_DomTyping = True Then Return
		If ssh_DomTypeCheck = True And ssh_AvoidTheEdgeTick < 6 Then Return
		If chatBox.Text <> "" And ssh_AvoidTheEdgeTick < 6 Then Return
		If ChatBox2.Text <> "" And ssh_AvoidTheEdgeTick < 6 Then Return
		If ssh_FollowUp <> "" And ssh_AvoidTheEdgeTick < 6 Then Return

		ssh_AvoidTheEdgeTick -= 1

		If ssh_AvoidTheEdgeTick < 1 Then



			Dim AvoidTheEdgeVideo As String = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Video\AvoidTheEdge.txt"
			If ssh_DommeVideo = True Then AvoidTheEdgeVideo = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Video\AvoidTheEdgeD.txt"

			Dim AvoidTheEdgeLineStart As Integer
			Dim AvoidTheEdgeLineEnd As Integer


			If File.Exists(AvoidTheEdgeVideo) Then
			Else
				If ssh_DommeVideo = True Then
					MsgBox("AvoidTheEdgeD.txt is missing!", , "Error!")
				Else
					MsgBox("AvoidTheEdge.txt is missing!", , "Error!")
				End If
				Return
			End If



			If ssh_AvoidTheEdgeStroking = False Then


				'CensorshipTick = randomizer.Next(NBCensorHideMin.Value, NBCensorHideMax.Value + 1)

				ssh_AvoidTheEdgeTick = 120 / FrmSettings.TauntSlider.Value

				' If AvoidTheEdgeLineTemp > TauntSlider.Value * 5 Then
				'Return
				'End If

				Using ioFileA As New StreamReader(AvoidTheEdgeVideo)
					Dim linesA As New List(Of String)
					Dim TempAvoidTheEdgeLine As Integer

					TempAvoidTheEdgeLine = -1
					While ioFileA.Peek <> -1
						TempAvoidTheEdgeLine += 1
						linesA.Add(ioFileA.ReadLine())
						If ssh_VideoType = "Hardcore" And linesA(TempAvoidTheEdgeLine) = "[HardcoreStrokingOff]" Then AvoidTheEdgeLineStart = TempAvoidTheEdgeLine
						If ssh_VideoType = "Hardcore" And linesA(TempAvoidTheEdgeLine) = "[SoftcoreStrokingOn]" Then AvoidTheEdgeLineEnd = TempAvoidTheEdgeLine
						If ssh_VideoType = "Softcore" And linesA(TempAvoidTheEdgeLine) = "[SoftcoreStrokingOff]" Then AvoidTheEdgeLineStart = TempAvoidTheEdgeLine
						If ssh_VideoType = "Softcore" And linesA(TempAvoidTheEdgeLine) = "[LesbianStrokingOn]" Then AvoidTheEdgeLineEnd = TempAvoidTheEdgeLine
						If ssh_VideoType = "Lesbian" And linesA(TempAvoidTheEdgeLine) = "[LesbianStrokingOff]" Then AvoidTheEdgeLineStart = TempAvoidTheEdgeLine
						If ssh_VideoType = "Lesbian" And linesA(TempAvoidTheEdgeLine) = "[BlowjobStrokingOn]" Then AvoidTheEdgeLineEnd = TempAvoidTheEdgeLine
						If ssh_VideoType = "Blowjob" And linesA(TempAvoidTheEdgeLine) = "[BlowjobStrokingOff]" Then AvoidTheEdgeLineStart = TempAvoidTheEdgeLine
						If ssh_VideoType = "Blowjob" And linesA(TempAvoidTheEdgeLine) = "[FemdomStrokingOn]" Then AvoidTheEdgeLineEnd = TempAvoidTheEdgeLine
						If ssh_VideoType = "Femdom" And linesA(TempAvoidTheEdgeLine) = "[FemdomStrokingOff]" Then AvoidTheEdgeLineStart = TempAvoidTheEdgeLine
						If ssh_VideoType = "Femdom" And linesA(TempAvoidTheEdgeLine) = "[FemsubStrokingOn]" Then AvoidTheEdgeLineEnd = TempAvoidTheEdgeLine
						If ssh_VideoType = "Femsub" And linesA(TempAvoidTheEdgeLine) = "[FemsubStrokingOff]" Then AvoidTheEdgeLineStart = TempAvoidTheEdgeLine
						If ssh_VideoType = "Femsub" And linesA(TempAvoidTheEdgeLine) = "[JOIStrokingOn]" Then AvoidTheEdgeLineEnd = TempAvoidTheEdgeLine
						If ssh_VideoType = "JOI" And linesA(TempAvoidTheEdgeLine) = "[JOIStrokingOff]" Then AvoidTheEdgeLineStart = TempAvoidTheEdgeLine
						If ssh_VideoType = "JOI" And linesA(TempAvoidTheEdgeLine) = "[CHStrokingOn]" Then AvoidTheEdgeLineEnd = TempAvoidTheEdgeLine
						If ssh_VideoType = "CH" And linesA(TempAvoidTheEdgeLine) = "[CHStrokingOff]" Then AvoidTheEdgeLineStart = TempAvoidTheEdgeLine
						If ssh_VideoType = "CH" And linesA(TempAvoidTheEdgeLine) = "[GeneralStrokingOn]" Then AvoidTheEdgeLineEnd = TempAvoidTheEdgeLine
						If ssh_VideoType = "General" And linesA(TempAvoidTheEdgeLine) = "[GeneralStrokingOff]" Then AvoidTheEdgeLineStart = TempAvoidTheEdgeLine
						If ssh_VideoType = "General" And linesA(TempAvoidTheEdgeLine) = "[StrokingEnd]" Then AvoidTheEdgeLineEnd = TempAvoidTheEdgeLine
					End While

				End Using

			Else






				ssh_AvoidTheEdgeTick = 120 / FrmSettings.TauntSlider.Value

				Using ioFileB As New StreamReader(AvoidTheEdgeVideo)
					Dim linesB As New List(Of String)
					Dim TempAvoidTheEdgeLine As Integer

					TempAvoidTheEdgeLine = -1
					While ioFileB.Peek <> -1
						TempAvoidTheEdgeLine += 1
						linesB.Add(ioFileB.ReadLine())
						If ssh_VideoType = "Hardcore" And linesB(TempAvoidTheEdgeLine) = "[HardcoreStrokingOn]" Then AvoidTheEdgeLineStart = TempAvoidTheEdgeLine
						If ssh_VideoType = "Hardcore" And linesB(TempAvoidTheEdgeLine) = "[HardcoreStrokingOff]" Then AvoidTheEdgeLineEnd = TempAvoidTheEdgeLine
						If ssh_VideoType = "Softcore" And linesB(TempAvoidTheEdgeLine) = "[SoftcoreStrokingOn]" Then AvoidTheEdgeLineStart = TempAvoidTheEdgeLine
						If ssh_VideoType = "Softcore" And linesB(TempAvoidTheEdgeLine) = "[SoftcoreStrokingOff]" Then AvoidTheEdgeLineEnd = TempAvoidTheEdgeLine
						If ssh_VideoType = "Lesbian" And linesB(TempAvoidTheEdgeLine) = "[LesbianStrokingOn]" Then AvoidTheEdgeLineStart = TempAvoidTheEdgeLine
						If ssh_VideoType = "Lesbian" And linesB(TempAvoidTheEdgeLine) = "[LesbianStrokingOff]" Then AvoidTheEdgeLineEnd = TempAvoidTheEdgeLine
						If ssh_VideoType = "Blowjob" And linesB(TempAvoidTheEdgeLine) = "[BlowjobStrokingOn]" Then AvoidTheEdgeLineStart = TempAvoidTheEdgeLine
						If ssh_VideoType = "Blowjob" And linesB(TempAvoidTheEdgeLine) = "[BlowjobStrokingOff]" Then AvoidTheEdgeLineEnd = TempAvoidTheEdgeLine
						If ssh_VideoType = "Femdom" And linesB(TempAvoidTheEdgeLine) = "[FemdomStrokingOn]" Then AvoidTheEdgeLineStart = TempAvoidTheEdgeLine
						If ssh_VideoType = "Femdom" And linesB(TempAvoidTheEdgeLine) = "[FemdomStrokingOff]" Then AvoidTheEdgeLineEnd = TempAvoidTheEdgeLine
						If ssh_VideoType = "Femsub" And linesB(TempAvoidTheEdgeLine) = "[FemsubStrokingOn]" Then AvoidTheEdgeLineStart = TempAvoidTheEdgeLine
						If ssh_VideoType = "Femsub" And linesB(TempAvoidTheEdgeLine) = "[FemsubStrokingOff]" Then AvoidTheEdgeLineEnd = TempAvoidTheEdgeLine
						If ssh_VideoType = "JOI" And linesB(TempAvoidTheEdgeLine) = "[JOIStrokingOn]" Then AvoidTheEdgeLineStart = TempAvoidTheEdgeLine
						If ssh_VideoType = "JOI" And linesB(TempAvoidTheEdgeLine) = "[JOIStrokingOff]" Then AvoidTheEdgeLineEnd = TempAvoidTheEdgeLine
						If ssh_VideoType = "CH" And linesB(TempAvoidTheEdgeLine) = "[CHStrokingOn]" Then AvoidTheEdgeLineStart = TempAvoidTheEdgeLine
						If ssh_VideoType = "CH" And linesB(TempAvoidTheEdgeLine) = "[CHStrokingOff]" Then AvoidTheEdgeLineEnd = TempAvoidTheEdgeLine
						If ssh_VideoType = "General" And linesB(TempAvoidTheEdgeLine) = "[GeneralStrokingOn]" Then AvoidTheEdgeLineStart = TempAvoidTheEdgeLine
						If ssh_VideoType = "General" And linesB(TempAvoidTheEdgeLine) = "[GeneralStrokingOff]" Then AvoidTheEdgeLineEnd = TempAvoidTheEdgeLine
					End While

				End Using

			End If

			Dim ioFile As New StreamReader(AvoidTheEdgeVideo)
			Dim lines As New List(Of String)
			While ioFile.Peek <> -1
				lines.Add(ioFile.ReadLine())
			End While

			Dim AvoidTheEdgeLine As Integer

			'Debug.Print("AvoidTheEdgeLineStart = " & AvoidTheEdgeLineStart)
			'Debug.Print("AvoidTheEdgeLineEnd = " & AvoidTheEdgeLineEnd)

			AvoidTheEdgeLine = ssh_randomizer.Next(AvoidTheEdgeLineStart + 1, AvoidTheEdgeLineEnd)

			ssh_DomTask = lines(AvoidTheEdgeLine)

			TypingDelayGeneric()




		End If

	End Sub

	Private Sub AvoidTheEdgeResume_Tick(sender As System.Object, e As System.EventArgs) Handles AvoidTheEdgeResume.Tick

		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then Return

		If ssh_DomTyping = True Then Return
		If ssh_DomTypeCheck = True And ssh_AtECountdown < 6 Then Return
		If chatBox.Text <> "" And ssh_AtECountdown < 6 Then Return
		If ChatBox2.Text <> "" And ssh_AtECountdown < 6 Then Return

		ssh_AtECountdown -= 1
		'Debug.Print("AtECountdown = " & AtECountdown)

		If ssh_AtECountdown < 1 Then
			AvoidTheEdgeResume.Stop()

			ssh_FileGoto = "NoAvoidTheEdgeInstructions"
			ssh_SkipGotoLine = True
			GetGoto()
			'domVLC.playlist.play()
			DomWMP.Ctlcontrols.play()
			HandleScripts()
			ScriptTimer.Start()


		End If


	End Sub

#End Region ' Avoid the Edge






	Private Sub BtnToggleImageVideo_Click(sender As System.Object, e As System.EventArgs) Handles BtnToggleImageVideo.Click


		If mainPictureBox.Visible = True Then
			DomWMP.Visible = True
			mainPictureBox.Visible = False
		Else
			mainPictureBox.Visible = True
			DomWMP.Visible = False
		End If

	End Sub

	''' <summary>
	''' Displays a random Blog image. Waits to finish download before proceeding.
	''' </summary>
	Public Sub GetBlogImage()

		Try
			If FrmSettings.URLFileList.CheckedItems.Count = 0 Then
				Throw New Exception("No URL-Files selected.")
			End If

			ShowImage(GetRandomImage(ImageGenre.Blog), True)
			ssh_JustShowedBlogImage = True

		Catch ex As Exception
			GetLocalImage()
		End Try

	End Sub

	''' <summary>
	''' Displays an random local image. Waits to finish download before proceeding.
	''' </summary>
	Public Sub GetLocalImage()

		ShowImage(GetRandomImage(ImageSourceType.Local), True)
		ssh_JustShowedBlogImage = True

	End Sub


	Public Sub RunModuleScript(IsEdging As Boolean)

		ssh_ShowModule = True

		ssh_TauntEdging = False

		ssh_AskedToGiveUpSection = False
		Dim ModuleList As New List(Of String)
		ModuleList.Clear()

		Dim ChastityModuleCheck As String = "*.txt"
		If My.Settings.Chastity = True And Not IsEdging Then
			ssh_AskedToSpeedUp = False
			ssh_AskedToSlowDown = False
			ssh_SubStroking = False
			ssh_SubEdging = False
			ssh_SubHoldingEdge = False
			StrokeTimer.Stop()
			StrokeTauntTimer.Stop()
			EdgeTauntTimer.Stop()
			HoldEdgeTauntTimer.Stop()
			ChastityModuleCheck = "*_CHASTITY.txt"
		End If

		If ssh_PlaylistFile.Count = 0 Then GoTo NoPlaylistModuleFile

		If ssh_Playlist = False Or ssh_PlaylistFile(ssh_PlaylistCurrent).Contains("Random Module") Then


NoPlaylistModuleFile:

			If ssh_SetModule <> "" Then

				ssh_FileText = ssh_SetModule
			Else

				For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Modules\", FileIO.SearchOption.SearchTopLevelOnly, ChastityModuleCheck)
					Dim TempModule As String = foundFile
					TempModule = Path.GetFileName(TempModule).Replace(".txt", "")

					If IsEdging Then

						Do Until Not TempModule.Contains("\")
							TempModule = TempModule.Remove(0, 1)
						Loop
					End If

					For x As Integer = 0 To FrmSettings.CLBModuleList.Items.Count - 1
						If My.Settings.Chastity = True Then
							If FrmSettings.CLBModuleList.Items(x) = TempModule And FrmSettings.CLBModuleList.GetItemChecked(x) = True And Not foundFile.Contains("_EDGING") Then
								ModuleList.Add(foundFile)
							End If
						ElseIf IsEdging Then
							If FrmSettings.CLBModuleList.Items(x) = TempModule And FrmSettings.CLBModuleList.GetItemChecked(x) = True And foundFile.Contains("_EDGING") Then
								ModuleList.Add(foundFile)
							End If
						Else
							If FrmSettings.CLBModuleList.Items(x) = TempModule And FrmSettings.CLBModuleList.GetItemChecked(x) = True And Not foundFile.Contains("_EDGING") And Not foundFile.Contains("_CHASTITY") Then
								ModuleList.Add(foundFile)
							End If
						End If
					Next
				Next

				If ModuleList.Count < 1 Then
					If My.Settings.Chastity = True Then
						ssh_FileText = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Scripts\Module_CHASTITY.txt"
					ElseIf IsEdging Then
						ssh_FileText = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Scripts\Module_EDGING.txt"
					Else
						ssh_FileText = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Scripts\Module.txt"
					End If
				Else
					ssh_FileText = ModuleList(ssh_randomizer.Next(0, ModuleList.Count))
				End If
			End If

		Else
			If ssh_PlaylistFile(ssh_PlaylistCurrent).Contains("Regular-TeaseAI-Script") Then
				ssh_FileText = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Modules\" & ssh_PlaylistFile(ssh_PlaylistCurrent)
				ssh_FileText = ssh_FileText.Replace(" Regular-TeaseAI-Script", "")
				ssh_FileText = ssh_FileText & ".txt"
			Else
				ssh_FileText = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Playlist\Modules\" & ssh_PlaylistFile(ssh_PlaylistCurrent) & ".txt"
			End If

		End If

		ssh_SetModule = ""

		ssh_DomTask = ssh_DomTask.Replace("@Module", "")


		If ssh_SetModuleGoto <> "" Then
			ssh_FileGoto = ssh_SetModuleGoto
			ssh_SkipGotoLine = True
			GetGoto()
			ssh_SetModuleGoto = ""
		Else
			ssh_StrokeTauntVal = -1
		End If

		If ssh_Playlist = True Then ssh_PlaylistCurrent += 1

		If Not IsEdging Then

			If ssh_Playlist = True Then ssh_BookmarkModule = False

			If ssh_BookmarkModule = True Then
				ssh_BookmarkModule = False
				ssh_FileText = ssh_BookmarkModuleFile
				ssh_StrokeTauntVal = ssh_BookmarkModuleLine
			End If

			ssh_ScriptTick = 3

		Else
			ssh_ScriptTick = 4
		End If

		ScriptTimer.Start()
	End Sub



	Public Sub RunLinkScript()

		Debug.Print("RunLinkScript() Called")

		ClearModes()

		If ssh_PlaylistFile.Count = 0 Then GoTo NoPlaylistLinkFile

		If ssh_Playlist = False Or ssh_PlaylistFile(ssh_PlaylistCurrent).Contains("Random Link") Then


NoPlaylistLinkFile:


			Debug.Print("SetLink = " & ssh_SetLink)


			If ssh_SetLink <> "" Then
				Debug.Print("SetLink Called")
				ssh_FileText = ssh_SetLink
			Else


				Dim LinkList As New List(Of String)
				LinkList.Clear()


				Dim ChastityLinkCheck As String
				If My.Settings.Chastity = True Then
					ChastityLinkCheck = "*_CHASTITY.txt"
				Else
					ChastityLinkCheck = "*.txt"
				End If

				For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Stroke\Link\", FileIO.SearchOption.SearchTopLevelOnly, ChastityLinkCheck)
					Dim TempLink As String = foundFile
					TempLink = TempLink.Replace(".txt", "")
					Do Until Not TempLink.Contains("\")
						TempLink = TempLink.Remove(0, 1)
					Loop
					For x As Integer = 0 To FrmSettings.CLBLinkList.Items.Count - 1
						If My.Settings.Chastity = True Then
							If FrmSettings.CLBLinkList.Items(x) = TempLink And FrmSettings.CLBLinkList.GetItemChecked(x) = True Then
								LinkList.Add(foundFile)
							End If
						Else
							If FrmSettings.CLBLinkList.Items(x) = TempLink And FrmSettings.CLBLinkList.GetItemChecked(x) = True And Not TempLink.Contains("_CHASTITY") Then
								LinkList.Add(foundFile)
							End If
						End If

					Next
				Next

				If LinkList.Count < 1 Then
					If My.Settings.Chastity = True Then
						ssh_FileText = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Scripts\Link_CHASTITY.txt"
					Else
						ssh_FileText = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Scripts\Link.txt"
					End If
				Else
					ssh_FileText = LinkList(ssh_randomizer.Next(0, LinkList.Count))
				End If

			End If

		Else
			Debug.Print("Playlist Link Called")
			If ssh_PlaylistFile(ssh_PlaylistCurrent).Contains("Regular-TeaseAI-Script") Then
				ssh_FileText = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Stroke\Link\" & ssh_PlaylistFile(ssh_PlaylistCurrent)
				ssh_FileText = ssh_FileText.Replace(" Regular-TeaseAI-Script", "")
				ssh_FileText = ssh_FileText & ".txt"
			Else
				ssh_FileText = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Playlist\Link\" & ssh_PlaylistFile(ssh_PlaylistCurrent) & ".txt"
			End If

		End If

		ssh_SetLink = ""
		Debug.Print("SetLink = " & ssh_SetLink)


		If ssh_WorshipMode = False Then
			ssh_LockImage = False
			If ssh_SlideshowLoaded = True Then
				nextButton.Enabled = True
				previousButton.Enabled = True
				PicStripTSMIdommeSlideshow.Enabled = True
			End If
		End If


		If ssh_SetLinkGoto <> "" Then
			ssh_FileGoto = ssh_SetLinkGoto
			ssh_SkipGotoLine = True
			GetGoto()
			ssh_SetLinkGoto = ""
		Else
			ssh_StrokeTauntVal = -1
		End If


		If ssh_Playlist = True Then ssh_PlaylistCurrent += 1
		If ssh_Playlist = True Then ssh_BookmarkLink = False

		If ssh_BookmarkLink = True Then
			ssh_BookmarkLink = False
			ssh_FileText = ssh_BookmarkLinkFile
			ssh_StrokeTauntVal = ssh_BookmarkLinkLine
		End If

		Debug.Print("Link FileText Called")


		ssh_ScriptTick = 3
		ScriptTimer.Start()


	End Sub



	Public Sub RunLastScript()

		ClearModes()

		'My.Settings.Sys_SubLeftEarly = 0

		'My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Scripts\" & dompersonalityComboBox.Text & "\System\Variables\SYS_SubLeftEarly", "0", False)

		SetVariable("SYS_SubLeftEarly", 0)

		SetVariable("SYS_EndTotal", Val(GetVariable("SYS_EndTotal")) + 1)


		'My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Scripts\" & dompersonalityComboBox.Text & "\System\Variables\SYS_EndTotal", Val(GetVariable("SYS_EndTotal")) + 1, False)



		'Debug.Print("RunLastScript() Called")

		If ssh_PlaylistFile.Count = 0 Then GoTo NoPlaylistEndFile

		If ssh_Playlist = False Or ssh_PlaylistFile(ssh_PlaylistCurrent).Contains("Random End") Then

NoPlaylistEndFile:

			Dim EndList As New List(Of String)
			EndList.Clear()

			Dim ChastityEndCheck As String
			If My.Settings.Chastity = True Then
				ChastityEndCheck = "*_CHASTITY.txt"
			Else
				ChastityEndCheck = "*.txt"
			End If

			For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Stroke\End\", FileIO.SearchOption.SearchTopLevelOnly, ChastityEndCheck)
				Dim TempEnd As String = foundFile
				TempEnd = TempEnd.Replace(".txt", "")
				Do Until Not TempEnd.Contains("\")
					TempEnd = TempEnd.Remove(0, 1)
				Loop
				For x As Integer = 0 To FrmSettings.CLBEndList.Items.Count - 1
					If My.Settings.Chastity = True Then
						If FrmSettings.CLBEndList.Items(x) = TempEnd And FrmSettings.CLBEndList.GetItemChecked(x) = True And Not TempEnd.Contains("_BEG") And Not TempEnd.Contains("_RESTRICTED") Then
							EndList.Add(foundFile)
						End If
					Else

						If ssh_OrgasmRestricted = True Then
							If FrmSettings.CLBEndList.Items(x) = TempEnd And FrmSettings.CLBEndList.GetItemChecked(x) = True And TempEnd.Contains("_RESTRICTED") Then
								EndList.Add(foundFile)
							End If
						Else
							If FrmSettings.CLBEndList.Items(x) = TempEnd And FrmSettings.CLBEndList.GetItemChecked(x) = True And Not TempEnd.Contains("_BEG") And Not TempEnd.Contains("_CHASTITY") _
								And Not TempEnd.Contains("_RESTRICTED") Then
								EndList.Add(foundFile)
							End If
						End If
					End If
				Next
			Next


			If EndList.Count < 1 Then
				If My.Settings.Chastity = True Then
					ssh_FileText = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Scripts\End_CHASTITY.txt"
				Else
					If ssh_OrgasmRestricted = True Then
						ssh_FileText = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Scripts\End_RESTRICTED.txt"
					Else
						ssh_FileText = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Scripts\End.txt"
					End If
				End If
			Else
				ssh_FileText = EndList(ssh_randomizer.Next(0, EndList.Count))
			End If

		Else
			If ssh_PlaylistFile(ssh_PlaylistCurrent).Contains("Regular-TeaseAI-Script") Then
				ssh_FileText = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Stroke\End\" & ssh_PlaylistFile(ssh_PlaylistCurrent)
				ssh_FileText = ssh_FileText.Replace(" Regular-TeaseAI-Script", "")
				ssh_FileText = ssh_FileText & ".txt"
			Else
				ssh_FileText = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Playlist\End\" & ssh_PlaylistFile(ssh_PlaylistCurrent) & ".txt"
			End If
		End If

		If ssh_WorshipMode = False Then
			If ssh_SlideshowLoaded = True Then
				nextButton.Enabled = True
				previousButton.Enabled = True
				PicStripTSMIdommeSlideshow.Enabled = True
			End If
			ssh_LockImage = False
		End If


		ssh_StrokeTauntVal = -1

		ssh_LastScript = True


		ssh_ScriptTick = 3
		ScriptTimer.Start()

	End Sub

	Public Sub RunLastBegScript()

		ClearModes()

		'Debug.Print("RunLastBegScript() Called")
		Dim EndList As New List(Of String)
		EndList.Clear()

		For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Stroke\End\", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
			Dim TempEnd As String = foundFile
			TempEnd = TempEnd.Replace(".txt", "")
			Do Until Not TempEnd.Contains("\")
				TempEnd = TempEnd.Remove(0, 1)
			Loop
			For x As Integer = 0 To FrmSettings.CLBEndList.Items.Count - 1

				If ssh_OrgasmRestricted = False Then

					If FrmSettings.CLBEndList.Items(x) = TempEnd And FrmSettings.CLBEndList.GetItemChecked(x) = True And TempEnd.Contains("_BEG") Then
						EndList.Add(foundFile)
					End If
				Else
					If FrmSettings.CLBEndList.Items(x) = TempEnd And FrmSettings.CLBEndList.GetItemChecked(x) = True And TempEnd.Contains("_RESTRICTED") Then
						EndList.Add(foundFile)
					End If

				End If

			Next
		Next


		If EndList.Count < 1 Then

			If ssh_OrgasmRestricted = False Then
				ssh_FileText = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Scripts\End_BEG.txt"
			Else
				ssh_FileText = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Scripts\End_RESTRICTED.txt"
			End If
		Else
			ssh_FileText = EndList(ssh_randomizer.Next(0, EndList.Count))
		End If

		ssh_LockImage = False
		If ssh_SlideshowLoaded = True Then
			nextButton.Enabled = True
			previousButton.Enabled = True
			PicStripTSMIdommeSlideshow.Enabled = True
		End If

		ssh_StrokeTauntVal = -1
		ssh_ScriptTick = 4
		ScriptTimer.Start()
		ssh_LastScript = True

		'RunFileText()

	End Sub

	Public Sub StopEverything()

		ScriptTimer.Stop()
		StrokeTimer.Stop()
		StrokeTauntTimer.Stop()
		CensorshipTimer.Stop()
		RLGLTimer.Stop()
		TnASlides.Stop()
		AvoidTheEdge.Stop()
		EdgeTauntTimer.Stop()
		HoldEdgeTimer.Stop()
		HoldEdgeTauntTimer.Stop()
		AvoidTheEdgeTaunts.Stop()
		RLGLTauntTimer.Stop()
		VideoTauntTimer.Stop()
		EdgeCountTimer.Stop()

		ssh_SubStroking = False
		ssh_SubEdging = False
		ssh_SubHoldingEdge = False
		ssh_AskedToSpeedUp = False
		ssh_AskedToSlowDown = False

		ssh_WorshipMode = False
		ssh_WorshipTarget = ""
		ssh_LongHold = False
		ssh_ExtremeHold = False

		ssh_MiniScript = False

		FrmSettings.alloworgasmComboBox.Enabled = True
		FrmSettings.ruinorgasmComboBox.Enabled = True
		FrmSettings.CBRangeOrgasm.Enabled = True
		If FrmSettings.CBRangeOrgasm.Checked = False Then
			FrmSettings.NBAllowOften.Enabled = True
			FrmSettings.NBAllowSometimes.Enabled = True
			FrmSettings.NBAllowRarely.Enabled = True
		End If
		FrmSettings.CBRangeRuin.Enabled = True
		If FrmSettings.CBRangeRuin.Checked = False Then
			FrmSettings.NBRuinOften.Enabled = True
			FrmSettings.NBRuinSometimes.Enabled = True
			FrmSettings.NBRuinRarely.Enabled = True
		End If

		ClearModes()


		If FrmSettings.TBWebStop.Text <> "" Then
			Try
				FrmSettings.WebToy.Navigate(FrmSettings.TBWebStop.Text)
			Catch
			End Try
		End If

		StrokePace = 0

	End Sub


	Private Sub EdgeTauntTimer_Tick(sender As System.Object, e As System.EventArgs) Handles EdgeTauntTimer.Tick

		If MultipleEdgesTimer.Enabled = True Then Return
		If ssh_MiniScript = True Then Return
		If ssh_InputFlag = True Then Return

		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then Return

		If ssh_DomTyping = True Then Return
		If ssh_DomTypeCheck = True And ssh_EdgeTauntInt < 6 Then Return
		If chatBox.Text <> "" And ssh_EdgeTauntInt < 6 Then Return
		If ChatBox2.Text <> "" And ssh_EdgeTauntInt < 6 Then Return

		FrmSettings.LBLDebugEdgeTauntTime.Text = ssh_EdgeTauntInt

		'Debug.Print("EdgeTauntIn = " & EdgeTauntInt)

		ssh_EdgeTauntInt -= 1

		If ssh_EdgeTauntInt < 1 Then

			Dim File2Read As String = ""

			If ssh_GlitterTease = False Then
				File2Read = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Stroke\Edge\Edge.txt"
			Else
				File2Read = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Stroke\Edge\GroupEdge.txt"
			End If

			'Read all lines of the given file.
			Dim ETLines As List(Of String) = Txt2List(File2Read)

			Try
				ETLines = FilterList(ETLines)
				ssh_DomTask = ETLines(ssh_randomizer.Next(0, ETLines.Count))
			Catch ex As Exception
				Log.WriteError("Tease AI did not return a valid Edge Taunt from file: " &
							   File2Read, ex, "EdgeTauntTimer.Tick")
				ssh_DomTask = "ERROR: Tease AI did not return a valid Edge Taunt"
			End Try

			TypingDelayGeneric()

			ssh_EdgeTauntInt = ssh_randomizer.Next(30, 46)

		End If

	End Sub

#Region "--------------------------------------- Hold the Edge ------------------------------------------"

	Private Sub HoldEdgeTimer_Tick(sender As System.Object, e As System.EventArgs) Handles HoldEdgeTimer.Tick

		If ssh_MiniScript = True Then Return

		'Debug.Print("HoldEdgeTick = " & HoldEdgeTick)

		ssh_HoldEdgeTime += 1
		ssh_HoldEdgeTimeTotal += 1

		My.Settings.HoldEdgeTimeTotal = ssh_HoldEdgeTimeTotal

		If ssh_InputFlag = True Then Return

		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then Return


		'If DomTyping = True Then Return
		If ssh_DomTypeCheck = True And ssh_HoldEdgeTick < 4 Then Return
		If chatBox.Text <> "" And ssh_HoldEdgeTick < 4 Then Return
		If ChatBox2.Text <> "" And ssh_HoldEdgeTick < 4 Then Return
		If ssh_FollowUp <> "" And ssh_HoldEdgeTick < 4 Then Return

		ssh_HoldEdgeTick -= 1

		FrmSettings.LBLDebugHoldEdgeTime.Text = ssh_HoldEdgeTick
		'Debug.Print("HoldEdgeTick = " & HoldEdgeTick)

		If ssh_HoldEdgeTick < 1 Then

			'stop
			ssh_LongHold = False
			ssh_ExtremeHold = False
			ssh_WorshipMode = False
			ssh_WorshipTarget = ""

			'If OrgasmAllowed = True Then GoTo AllowedOrgasm
			'If EdgeToRuin = True Or OrgasmRuined = True Then GoTo RuinedOrgasm

			If ssh_EdgeToRuin = True Or ssh_OrgasmRuined = True Then
				ssh_LastOrgasmType = "RUINED"
				ssh_OrgasmRuined = False
				GoTo RuinedOrgasm
			End If

			If ssh_OrgasmAllowed = True Then
				ssh_LastOrgasmType = "ALLOWED"
				ssh_OrgasmAllowed = False
				GoTo AllowedOrgasm
			End If

			If ssh_OrgasmDenied = True Then

				ssh_LastOrgasmType = "DENIED"

				If FrmSettings.CBDomDenialEnds.Checked = False And ssh_TeaseTick < 1 Then

					Dim RepeatChance As Integer = ssh_randomizer.Next(0, 101)

					If RepeatChance < 10 * FrmSettings.domlevelNumBox.Value Then
						ssh_SubEdging = False
						ssh_SubStroking = False
						EdgeTauntTimer.Stop()

						Dim RepeatList As New List(Of String)

						For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Interrupt\Denial Continue\", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
							RepeatList.Add(foundFile)
						Next

						If RepeatList.Count < 1 Then GoTo NoRepeatFiles

						If FrmSettings.CBTeaseLengthDD.Checked = True Then
							If FrmSettings.domlevelNumBox.Value = 1 Then ssh_TeaseTick = ssh_randomizer.Next(10, 16) * 60
							If FrmSettings.domlevelNumBox.Value = 2 Then ssh_TeaseTick = ssh_randomizer.Next(15, 21) * 60
							If FrmSettings.domlevelNumBox.Value = 3 Then ssh_TeaseTick = ssh_randomizer.Next(20, 31) * 60
							If FrmSettings.domlevelNumBox.Value = 4 Then ssh_TeaseTick = ssh_randomizer.Next(30, 46) * 60
							If FrmSettings.domlevelNumBox.Value = 5 Then ssh_TeaseTick = ssh_randomizer.Next(45, 61) * 60
						Else
							ssh_TeaseTick = ssh_randomizer.Next(FrmSettings.NBTeaseLengthMin.Value * 60, FrmSettings.NBTeaseLengthMax.Value * 60)
						End If

						TeaseTimer.Start()

						'ShowModule = True
						ssh_StrokeTauntVal = -1
						ssh_FileText = RepeatList(ssh_randomizer.Next(0, RepeatList.Count))
						ssh_ScriptTick = 2
						ScriptTimer.Start()
						ssh_OrgasmDenied = False
						ssh_OrgasmYesNo = False
						ssh_EndTease = False
						Return
					End If

				End If


			End If

NoRepeatFiles:

			HoldEdgeTimer.Stop()
			HoldEdgeTauntTimer.Stop()
			ssh_SubHoldingEdge = False
			ssh_SubStroking = False
			ssh_OrgasmYesNo = False
			ssh_DomTask = "#StopStroking"
			If ssh_Contact1Edge = True Then
				ssh_DomTask = "@Contact1 #StopStroking"
				ssh_Contact1Edge = False
			End If
			If ssh_Contact2Edge = True Then
				ssh_DomTask = "@Contact2 #StopStroking"
				ssh_Contact2Edge = False
			End If
			If ssh_Contact3Edge = True Then
				ssh_DomTask = "@Contact3 #StopStroking"
				ssh_Contact3Edge = False
			End If
			TypingDelayGeneric()
			Return

RuinedOrgasm:

			My.Settings.LastRuined = FormatDateTime(Now, DateFormat.ShortDate)
			FrmSettings.LBLLastRuined.Text = My.Settings.LastRuined

			If FrmSettings.CBDomOrgasmEnds.Checked = False And ssh_OrgasmRuined = True And ssh_TeaseTick < 1 Then

				Dim RepeatChance As Integer = ssh_randomizer.Next(0, 101)

				If RepeatChance < 8 * FrmSettings.domlevelNumBox.Value Then

					EdgeTauntTimer.Stop()
					HoldEdgeTimer.Stop()
					HoldEdgeTauntTimer.Stop()
					ssh_SubHoldingEdge = False
					ssh_SubStroking = False
					ssh_EdgeToRuin = False
					ssh_EdgeToRuinSecret = True

					Dim RepeatList As New List(Of String)

					For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Interrupt\Ruin Continue\", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
						RepeatList.Add(foundFile)
					Next

					If RepeatList.Count < 1 Then GoTo NoRepeatRFiles


					If FrmSettings.CBTeaseLengthDD.Checked = True Then
						If FrmSettings.domlevelNumBox.Value = 1 Then ssh_TeaseTick = ssh_randomizer.Next(10, 16) * 60
						If FrmSettings.domlevelNumBox.Value = 2 Then ssh_TeaseTick = ssh_randomizer.Next(15, 21) * 60
						If FrmSettings.domlevelNumBox.Value = 3 Then ssh_TeaseTick = ssh_randomizer.Next(20, 31) * 60
						If FrmSettings.domlevelNumBox.Value = 4 Then ssh_TeaseTick = ssh_randomizer.Next(30, 46) * 60
						If FrmSettings.domlevelNumBox.Value = 5 Then ssh_TeaseTick = ssh_randomizer.Next(45, 61) * 60
					Else
						ssh_TeaseTick = ssh_randomizer.Next(FrmSettings.NBTeaseLengthMin.Value * 60, FrmSettings.NBTeaseLengthMax.Value * 60)
					End If
					TeaseTimer.Start()

					'ShowModule = True
					ssh_StrokeTauntVal = -1
					ssh_FileText = RepeatList(ssh_randomizer.Next(0, RepeatList.Count))
					ssh_ScriptTick = 2
					ScriptTimer.Start()
					ssh_OrgasmRuined = False
					ssh_OrgasmYesNo = False
					ssh_EndTease = False
					Return
				End If

			End If



NoRepeatRFiles:



			ssh_DomTypeCheck = True
			HoldEdgeTimer.Stop()
			HoldEdgeTauntTimer.Stop()
			ssh_SubHoldingEdge = False
			ssh_SubStroking = False
			ssh_EdgeToRuin = False
			ssh_EdgeToRuinSecret = True
			ssh_OrgasmYesNo = False
			ssh_DomChat = "#RuinYourOrgasm"
			If ssh_Contact1Edge = True Then
				ssh_DomChat = "@Contact1 #RuinYourOrgasm"
				ssh_Contact1Edge = False
			End If
			If ssh_Contact2Edge = True Then
				ssh_DomChat = "@Contact2 #RuinYourOrgasm"
				ssh_Contact2Edge = False
			End If
			If ssh_Contact3Edge = True Then
				ssh_DomChat = "@Contact3 #RuinYourOrgasm"
				ssh_Contact3Edge = False
			End If
			TypingDelay()
			Return

AllowedOrgasm:

			If My.Settings.OrgasmsLocked = True Then

				If My.Settings.OrgasmsRemaining < 1 Then

					Dim NoCumList As New List(Of String)

					For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Interrupt\Out of Orgasms\", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
						NoCumList.Add(foundFile)
					Next

					If NoCumList.Count < 1 Then GoTo NoNoCumFiles


					HoldEdgeTimer.Stop()
					HoldEdgeTauntTimer.Stop()
					ssh_SubHoldingEdge = False
					ssh_SubStroking = False
					ssh_OrgasmYesNo = False
					'ShowModule = True
					ssh_StrokeTauntVal = -1
					ssh_FileText = NoCumList(ssh_randomizer.Next(0, NoCumList.Count))
					ssh_ScriptTick = 2
					ScriptTimer.Start()
					Return
				End If


				My.Settings.OrgasmsRemaining -= 1


			End If

NoNoCumFiles:


			My.Settings.LastOrgasm = FormatDateTime(Now, DateFormat.ShortDate)
			FrmSettings.LBLLastOrgasm.Text = My.Settings.LastOrgasm

			If FrmSettings.CBDomOrgasmEnds.Checked = False And ssh_TeaseTick < 1 Then

				Dim RepeatChance As Integer = ssh_randomizer.Next(0, 101)

				If RepeatChance < 4 * FrmSettings.domlevelNumBox.Value Then

					HoldEdgeTimer.Stop()
					HoldEdgeTauntTimer.Stop()
					ssh_SubHoldingEdge = False
					ssh_SubStroking = False
					ssh_EdgeToRuin = False
					ssh_EdgeToRuinSecret = True
					EdgeTauntTimer.Stop()

					Dim RepeatList As New List(Of String)

					For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Interrupt\Orgasm Continue\", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
						RepeatList.Add(foundFile)
					Next

					If RepeatList.Count < 1 Then GoTo NoRepeatOFiles


					If FrmSettings.CBTeaseLengthDD.Checked = True Then
						If FrmSettings.domlevelNumBox.Value = 1 Then ssh_TeaseTick = ssh_randomizer.Next(10, 16) * 60
						If FrmSettings.domlevelNumBox.Value = 2 Then ssh_TeaseTick = ssh_randomizer.Next(15, 21) * 60
						If FrmSettings.domlevelNumBox.Value = 3 Then ssh_TeaseTick = ssh_randomizer.Next(20, 31) * 60
						If FrmSettings.domlevelNumBox.Value = 4 Then ssh_TeaseTick = ssh_randomizer.Next(30, 46) * 60
						If FrmSettings.domlevelNumBox.Value = 5 Then ssh_TeaseTick = ssh_randomizer.Next(45, 61) * 60
					Else
						ssh_TeaseTick = ssh_randomizer.Next(FrmSettings.NBTeaseLengthMin.Value * 60, FrmSettings.NBTeaseLengthMax.Value * 60)
					End If
					TeaseTimer.Start()

					'ShowModule = True
					ssh_StrokeTauntVal = -1
					ssh_FileText = RepeatList(ssh_randomizer.Next(0, RepeatList.Count))
					ssh_ScriptTick = 2
					ScriptTimer.Start()
					ssh_OrgasmAllowed = False
					ssh_OrgasmYesNo = False
					ssh_EndTease = False
					Return
				End If

			End If



NoRepeatOFiles:


			ssh_DomTypeCheck = True
			HoldEdgeTimer.Stop()
			HoldEdgeTauntTimer.Stop()
			ssh_SubHoldingEdge = False
			ssh_SubStroking = False
			ssh_OrgasmYesNo = False
			'OrgasmAllowed = False
			ssh_DomChat = "#CumForMe"
			If ssh_Contact1Edge = True Then
				ssh_DomChat = "@Contact1 #CumForMe"
				ssh_Contact1Edge = False
			End If
			If ssh_Contact2Edge = True Then
				ssh_DomChat = "@Contact2 #CumForMe"
				ssh_Contact2Edge = False
			End If
			If ssh_Contact3Edge = True Then
				ssh_DomChat = "@Contact3 #CumForMe"
				ssh_Contact3Edge = False
			End If
			TypingDelay()
			Return

		End If

	End Sub

	Private Sub HoldEdgeTauntTimer_Tick(sender As System.Object, e As System.EventArgs) Handles HoldEdgeTauntTimer.Tick

		If ssh_MiniScript = True Then Return
		If ssh_InputFlag = True Then Return

		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then Return

		If ssh_DomTyping = True Then Return
		If ssh_DomTypeCheck = True And ssh_EdgeTauntInt < 6 Then Return
		If chatBox.Text <> "" And ssh_EdgeTauntInt < 6 Then Return
		If ChatBox2.Text <> "" And ssh_EdgeTauntInt < 6 Then Return

		ssh_EdgeTauntInt -= 1

		If ssh_EdgeTauntInt < 1 Then

			Dim File2Read As String = ""

			If ssh_GlitterTease = False Then
				File2Read = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Stroke\HoldTheEdge\HoldTheEdge.txt"
			Else
				File2Read = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Stroke\HoldTheEdge\GroupHoldTheEdge.txt"
			End If

			' Read all lines of given file.
			Dim ETLines As List(Of String) = Txt2List(File2Read)

			Try
				ETLines = FilterList(ETLines)
				ssh_DomTask = ETLines(ssh_randomizer.Next(0, ETLines.Count))
			Catch ex As Exception
				Log.WriteError("Tease AI did not return a valid Hold the Edge Taunt from file: " &
							   File2Read, ex, "HoldEdgeTauntTimer.Tick")
				ssh_DomTask = "ERROR: Tease AI did not return a valid Hold the Edge Taunt"
			End Try

			TypingDelayGeneric()

			ssh_EdgeTauntInt = ssh_randomizer.Next(15, 31)


		End If

	End Sub

#End Region ' Hold the Edge

	Public Sub CreateTaskLetter()

		Dim TaskEntry As String

		TaskEntry = CleanTaskLines(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Tasks\Greeting.txt")
		ssh_TaskText = ssh_TaskText & TaskEntry & " " & Environment.NewLine & Environment.NewLine

		TaskEntry = CleanTaskLines(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Tasks\Intro.txt")
		ssh_TaskText = ssh_TaskText & TaskEntry & " " & Environment.NewLine & Environment.NewLine

		If ssh_GeneralTime = "Afternoon" Then GoTo Afternoon
		If ssh_GeneralTime = "Night" Then GoTo Night

		TaskEntry = CleanTaskLines(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Tasks\Task_1.txt")
		ssh_TaskText = ssh_TaskText & TaskEntry & " " & Environment.NewLine & Environment.NewLine

		TaskEntry = CleanTaskLines(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Tasks\Link_1-2.txt")
		ssh_TaskText = ssh_TaskText & TaskEntry & " " & Environment.NewLine & Environment.NewLine

Afternoon:

		TaskEntry = CleanTaskLines(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Tasks\Task_2.txt")
		ssh_TaskText = ssh_TaskText & TaskEntry & " " & Environment.NewLine & Environment.NewLine

		TaskEntry = CleanTaskLines(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Tasks\Link_2-3.txt")
		ssh_TaskText = ssh_TaskText & TaskEntry & " " & Environment.NewLine & Environment.NewLine

Night:

		TaskEntry = CleanTaskLines(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Tasks\Task_3.txt")
		ssh_TaskText = ssh_TaskText & TaskEntry & " " & Environment.NewLine & Environment.NewLine

		TaskEntry = CleanTaskLines(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Tasks\Outro.txt")
		ssh_TaskText = ssh_TaskText & TaskEntry & " " & Environment.NewLine & Environment.NewLine

		TaskEntry = CleanTaskLines(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Tasks\Signature.txt")
		ssh_TaskText = ssh_TaskText & TaskEntry & " " & Environment.NewLine & Environment.NewLine

		If FrmSettings.CBHonorificInclude.Checked = True Then
			ssh_TaskText = ssh_TaskText & FrmSettings.TBHonorific.Text & " " & domName.Text
		Else
			ssh_TaskText = ssh_TaskText & domName.Text
		End If

		ssh_TaskText = System.Text.RegularExpressions.Regex.Replace(ssh_TaskText, "[ ]{2,}", " ")

		Dim TempDate As String
		Dim TempDateNow As DateTime = DateTime.Now

		TempDate = TempDateNow.ToString("M dd")

		ssh_TaskTextDir = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Received Files\Tasks for " & TempDate & ".txt"
		My.Computer.FileSystem.WriteAllText(ssh_TaskTextDir, ssh_TaskText, False)

		ssh_TaskText = ""

		LBLFileTransfer.Text = domName.Text & " is sending you a file!"
		PNLFileTransfer.Visible = True
		PNLFileTransfer.BringToFront()

		StupidTimer.Start()

		Debug.Print("<><><><><><><><><><><><><><><><><><><><><>")
		Debug.Print("Created " & ssh_GeneralTime & " Task Letter")
		Debug.Print("<><><><><><><><><><><><><><><><><><><><><>")

	End Sub

	Public Function CleanTaskLines(ByVal dir As String) As String
		Try
			Dim TaskLines As List(Of String) = Txt2List(dir)
			Dim TaskEntry As String
			Dim TaskArray As String()
			Dim TaskList As New List(Of String)

			TaskLines = FilterList(TaskLines)
			If TaskLines.Count = 0 Then Throw New ArgumentException("The given file: """ & dir & """ was returned empty.")

			TaskEntry = TaskLines(ssh_randomizer.Next(0, TaskLines.Count))


			Dim LoopBuffer As Integer

			TaskArray = TaskEntry.Split(" ")
			For i As Integer = 0 To TaskArray.Count - 1
				TaskList.Add(TaskArray(i))
			Next
			TaskEntry = ""
			For i As Integer = 0 To TaskList.Count - 1
				Try
					LoopBuffer = 0

PoundLoop:
					LoopBuffer += 1

					TaskList(i) = TaskList(i).Replace(". #Emote", " #Emote")
					TaskList(i) = TaskList(i).Replace(". #Grin", " #Grin")
					TaskList(i) = TaskList(i).Replace(". #Lol", " #Lol.")

					TaskList(i) = PoundClean(TaskList(i))
					If TaskEntry.Contains("#") And LoopBuffer < 6 Then GoTo PoundLoop

					TaskEntry = TaskEntry & TaskList(i) & " "
				Catch
				End Try
			Next

			Dim int As Integer

			If TaskEntry.Contains("#TaskEdges") Then
				Do
					int = ssh_randomizer.Next(FrmSettings.NBTaskEdgesMin.Value, FrmSettings.NBTaskEdgesMax.Value + 1)
					If int > 5 Then int = 5 * Math.Round(int / 5)
					TaskEntry = TaskEntry.Replace("#TaskEdges", int)
				Loop Until Not TaskEntry.Contains("#TaskEdges")
			End If

			If TaskEntry.Contains("#TaskStrokes") Then
				Do
					int = ssh_randomizer.Next(FrmSettings.NBTaskStrokesMin.Value, FrmSettings.NBTaskStrokesMax.Value + 1)
					If int > 10 Then int = 10 * Math.Round(int / 10)
					TaskEntry = TaskEntry.Replace("#TaskStrokes", int)
				Loop Until Not TaskEntry.Contains("#TaskStrokes")
			End If

			If TaskEntry.Contains("#TaskHours") Then
				Do
					int = ssh_randomizer.Next(1, FrmSettings.domlevelNumBox.Value + 1) + FrmSettings.domlevelNumBox.Value
					TaskEntry = TaskEntry.Replace("#TaskHours", int)
				Loop Until Not TaskEntry.Contains("#TaskHours")
			End If

			If TaskEntry.Contains("#TaskMinutes") Then
				Do
					int = ssh_randomizer.Next(5, 13) * FrmSettings.domlevelNumBox.Value
					TaskEntry = TaskEntry.Replace("#TaskMinutes", int)
				Loop Until Not TaskEntry.Contains("#TaskMinutes")
			End If

			If TaskEntry.Contains("#TaskSeconds") Then
				Do
					int = ssh_randomizer.Next(10, 30) * FrmSettings.domlevelNumBox.Value * ssh_randomizer.Next(1, FrmSettings.domlevelNumBox.Value + 1)
					TaskEntry = TaskEntry.Replace("#TaskSeconds", int)
				Loop Until Not TaskEntry.Contains("#TaskSeconds")
			End If

			If TaskEntry.Contains("#TaskAmountLarge") Then
				Do
					int = (ssh_randomizer.Next(15, 26) * FrmSettings.domlevelNumBox.Value) * 2
					If int > 5 Then int = 5 * Math.Round(int / 5)
					TaskEntry = TaskEntry.Replace("#TaskAmountLarge", int)
				Loop Until Not TaskEntry.Contains("#TaskAmountLarge")
			End If

			If TaskEntry.Contains("#TaskAmountSmall") Then
				Do
					int = (ssh_randomizer.Next(5, 11) * FrmSettings.domlevelNumBox.Value) / 2
					If int > 5 Then int = 5 * Math.Round(int / 5)
					TaskEntry = TaskEntry.Replace("#TaskAmountSmall", int)
				Loop Until Not TaskEntry.Contains("#TaskAmountSmall")
			End If

			If TaskEntry.Contains("#TaskAmount") Then
				Do
					int = ssh_randomizer.Next(15, 26) * FrmSettings.domlevelNumBox.Value
					If int > 5 Then int = 5 * Math.Round(int / 5)
					TaskEntry = TaskEntry.Replace("#TaskAmount", int)
				Loop Until Not TaskEntry.Contains("#TaskAmount")
			End If

			If TaskEntry.Contains("#TaskStrokingTime") Then
				Do
					int = ssh_randomizer.Next(FrmSettings.NBTaskStrokingTimeMin.Value, FrmSettings.NBTaskStrokingTimeMax.Value + 1)
					int *= 60
					Dim TConvert As String = ConvertSeconds(int)
					TaskEntry = TaskEntry.Replace("#TaskStrokingTime", TConvert)
				Loop Until Not TaskEntry.Contains("#TaskStrokingTime")
			End If

			If TaskEntry.Contains("#TaskHoldTheEdgeTime") Then
				Do
					int = ssh_randomizer.Next(FrmSettings.NBTaskEdgeHoldTimeMin.Value, FrmSettings.NBTaskEdgeHoldTimeMax.Value + 1)
					int *= 60
					Dim TConvert As String = ConvertSeconds(int)
					TaskEntry = TaskEntry.Replace("#TaskHoldTheEdgeTime", TConvert)
				Loop Until Not TaskEntry.Contains("#TaskHoldTheEdgeTime")
			End If

			If TaskEntry.Contains("#TaskCBTTime") Then
				Do
					int = ssh_randomizer.Next(FrmSettings.NBTaskCBTTimeMin.Value, FrmSettings.NBTaskCBTTimeMax.Value + 1)
					int *= 60
					Dim TConvert As String = ConvertSeconds(int)
					TaskEntry = TaskEntry.Replace("#TaskCBTTime", TConvert)
				Loop Until Not TaskEntry.Contains("#TaskCBTTime")
			End If

			TaskEntry = TaskEntry.Replace("<font color=""red"">", "")
			TaskEntry = TaskEntry.Replace("</font>", "")
			TaskEntry = TaskEntry.Replace("#Null", "")

			LoopBuffer = 0

			Do
				LoopBuffer += 1
				If LoopBuffer > 4 Then Exit Do
				TaskEntry = PoundClean(TaskEntry)
			Loop Until Not TaskEntry.Contains("#") And Not TaskEntry.Contains("@RT(") And Not TaskEntry.Contains("@RandomText(")


			TaskEntry = CommandClean(TaskEntry, True)

			TaskEntry = StripCommands(TaskEntry)

			TaskEntry = Trim(TaskEntry)

			If TaskEntry.Contains("*") Then
				TaskEntry = TaskEntry.Replace(". *", " *")
				Dim EmoToggle As Boolean = True
				For i As Integer = TaskEntry.Length - 1 To 0 Step -1
					If TaskEntry.Substring(i, 1) = "*" Then
						If EmoToggle = False Then
							EmoToggle = True
							TaskEntry = TaskEntry.Remove(i, 1).Insert(i, FrmSettings.TBEmote.Text)
						Else
							EmoToggle = False
							TaskEntry = TaskEntry.Remove(i, 1).Insert(i, FrmSettings.TBEmoteEnd.Text)
						End If
					End If
				Next
			End If

			Return TaskEntry
		Catch ex As Exception
			'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
			'                                            All Errors
			'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
			Log.WriteError("Error occurred during file processing:  """ & dir & """", ex, "CleanTaskLines(String)")
			Return "ERROR: Tease AI did not return a valid Task line"
		End Try
	End Function

	Private Sub BTNFIleTransferDismiss_Click(sender As System.Object, e As System.EventArgs) Handles BTNFIleTransferDismiss.Click

		PNLFileTransfer.Visible = False
		BTNFileTransferOpen.Visible = False
		BTNFIleTransferDismiss.Visible = False
		LBLFileTransfer.Text = domName.Text & " is sending you a file!"
		PBFileTransfer.Value = 0

	End Sub

	Public Function ShellExecute(ByVal File As String) As Boolean
		Dim myProcess As New Process
		myProcess.StartInfo.FileName = File
		myProcess.StartInfo.UseShellExecute = True
		myProcess.StartInfo.RedirectStandardOutput = False
		myProcess.Start()
		myProcess.Dispose()
	End Function


	Public Sub BTNFileTransferOpen_Click(sender As System.Object, e As System.EventArgs) Handles BTNFileTransferOpen.Click

		ShellExecute(ssh_TaskTextDir)

		PNLFileTransfer.Visible = False
		BTNFileTransferOpen.Visible = False
		BTNFIleTransferDismiss.Visible = False
		LBLFileTransfer.Text = domName.Text & " is sending you a file!"
		PBFileTransfer.Value = 0

	End Sub



	Private Sub SlideshowTimer_Tick(sender As System.Object, e As System.EventArgs) Handles SlideshowTimer.Tick
		'TODO: Remove CrossForm data access
		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then Return

		If ssh_SlideshowLoaded = False Or FrmSettings.timedRadio.Checked = False Or ssh_TeaseVideo = True Or ssh_LockImage = True Or ssh_JustShowedBlogImage = True Or ssh_CustomSlideshow = True Then Return

		ssh_SlideshowTimerTick -= 1

		If ssh_SlideshowTimerTick < 1 Then

TryNext:
			'--------------FileCount += 1
			ssh_FileCount += 1
			If ssh_FileCount > ssh__ImageFileNames.Count - 1 Then
				If FrmSettings.CBNewSlideshow.Checked = True Then
					ssh_NewDommeSlideshow = True
					ssh_OriginalDommeSlideshow = ssh__ImageFileNames(0)
					LoadDommeImageFolder()
					ssh_NewDommeSlideshow = False
					ssh_DomPic = ssh__ImageFileNames(ssh_FileCount)
				Else
					ssh_FileCount = 0
				End If
			End If

			If Not (File.Exists(ssh__ImageFileNames(ssh_FileCount)) _
					Or isURL(ssh__ImageFileNames(ssh_FileCount))) Then
				ClearMainPictureBox()
				Exit Sub
			End If

			If ssh__ImageFileNames(ssh_FileCount).Contains(".db") Then GoTo TryNext



			If My.Settings.CBSlideshowRandom = True Then ssh_FileCount = ssh_randomizer.Next(0, ssh__ImageFileNames.Count)


			Try
				ShowImage(ssh__ImageFileNames(ssh_FileCount), True)
				ssh_JustShowedBlogImage = False
				ssh_JustShowedSlideshowImage = True

			Catch
				GoTo TryNext
			End Try


			ssh_SlideshowTimerTick = FrmSettings.slideshowNumBox.Value
		End If

	End Sub

	Public Sub GetEdgeTickCheck()

		If ssh_AlreadyStrokingEdge = True Then

			If ssh_AvgEdgeCount < 5 Then
				ssh_EdgeTickCheck = 60
			Else
				ssh_EdgeTickCheck = ssh_AvgEdgeStroking
			End If

		Else

			If ssh_AvgEdgeCountRest < 5 Then
				ssh_EdgeTickCheck = 300
			Else
				ssh_EdgeTickCheck = ssh_AvgEdgeNoTouch
			End If

		End If

	End Sub



	Private Sub EdgeCountTimer_Tick(sender As System.Object, e As System.EventArgs) Handles EdgeCountTimer.Tick

		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then Return

		ssh_EdgeCountTick += 1

		If FrmSettings.CBEdgeUseAvg.Checked = True Then
			If ssh_EdgeCountTick > ssh_EdgeTickCheck Then ssh_LongEdge = True
		Else
			If ssh_EdgeCountTick > FrmSettings.NBLongEdge.Value * 60 Then ssh_LongEdge = True
		End If


		Dim m As Integer = TimeSpan.FromSeconds(ssh_EdgeCountTick).Minutes
		Dim s As Integer = TimeSpan.FromSeconds(ssh_EdgeCountTick).Seconds


		Dim TST As TimeSpan = TimeSpan.FromSeconds(ssh_EdgeCountTick)

		''Debug.Print("{0:c} : {1:c}", TST.Minutes, TST.Seconds)



		'Debug.Print("EdgeCountTick = " & String.Format("{0:00}:{1:00}", TST.Minutes, TST.Seconds))
	End Sub

	Private Sub StrokeTimeTotalTimer_Tick(sender As System.Object, e As System.EventArgs) Handles StrokeTimeTotalTimer.Tick

		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then Return

		If ssh_SubStroking = False Then Return

		ssh_StrokeTimeTotal += 1
		'Debug.Print("StrokeTimeTotal = " & StrokeTimeTotal)

		My.Settings.StrokeTimeTotal = ssh_StrokeTimeTotal

		Dim STT As TimeSpan = TimeSpan.FromSeconds(ssh_StrokeTimeTotal)

		'LBLStrokeTimeTotal.Text = String.Format("{0:000} D {1:00} H {2:00} M {3:00} S", STT.Days, STT.Hours, STT.Minutes, STT.Seconds)
		FrmSettings.LBLStrokeTimeTotal.Text = String.Format("{0:0000}:{1:00}:{2:00}:{3:00}", STT.Days, STT.Hours, STT.Minutes, STT.Seconds)


	End Sub






	Private Sub TnAFastSlides_Tick(sender As System.Object, e As System.EventArgs) Handles TnASlides.Tick
		Dim tmpSw As New Stopwatch

RestartFunction:
		tmpSw.Restart()
		Try
			If ssh_BoobList.Count < 1 Then Throw New Exception("No Boobs-images loaded.")
			If ssh_AssList.Count < 1 Then Throw New Exception("No Butt-images loaded.")

			Dim tmpImageToShow As String = ""
			Dim tmpLateSet As Boolean

			If New Random().Next(0, 101) < 51 Then
				tmpImageToShow = ssh_BoobList(ssh_randomizer.Next(0, ssh_BoobList.Count))
				tmpLateSet = True
			Else
				tmpImageToShow = ssh_AssList(ssh_randomizer.Next(0, ssh_AssList.Count))
				tmpLateSet = False
			End If

			Try
				ShowImage(tmpImageToShow, True)

				If tmpLateSet Then
					ssh_BoobImage = True
					ssh_AssImage = False
				Else
					ssh_BoobImage = False
					ssh_AssImage = True
				End If

				' If the elapsed time to load an image was longer as the Timer.Interval
				' we restart the function instantly, to avoid an unnecessary delay.
				' If it took way too long and the Timer was stopped during imagedownload, 
				' we dont want the timer to restart.
				If tmpSw.ElapsedMilliseconds > TnASlides.Interval And TnASlides.Enabled Then
					GoTo RestartFunction
				End If
			Catch ex As Exception
				' @@@@@@@@@@@@@@@@ Exception while loading image @@@@@@@@@@@@@@@@@
				' Remove the ImagePath and retry.
				ssh_BoobList.RemoveAll(Function(x) x.Contains(tmpImageToShow))
				ssh_AssList.RemoveAll(Function(x) x.Contains(tmpImageToShow))
				GoTo RestartFunction
			End Try
		Catch ex As Exception
			'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
			'                                            All Errors
			'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
			TnASlides.Stop()
			Log.WriteError(ex.Message & vbCrLf & "TnA Slideshow will stop.", ex, "Exception in TnASlieds.Tick occured")
		End Try
	End Sub









#Region "---------------------------------------------------- Domme-WMP -------------------------------------------------------"

	Private Sub DomWMP_PlayStateChange(sender As Object, e As AxWMPLib._WMPOCXEvents_PlayStateChangeEvent) Handles DomWMP.PlayStateChange


		If (DomWMP.playState = WMPLib.WMPPlayState.wmppsPlaying) Then
			If FrmSettings.CBMuteMedia.Checked = True Then
				DomWMP.settings.mute = True
			End If
		End If


		If (DomWMP.playState = WMPLib.WMPPlayState.wmppsStopped) Then
			'Debug.Print("WMP Stopped Called")

			VideoTimer.Stop()

			ssh_EdgeVideo = False
			ssh_YesVideo = False
			ssh_NoVideo_Mode = False
			ssh_CameVideo = False
			ssh_RuinedVideo = False

			DomWMP.currentPlaylist.clear()


			If ssh_CensorshipGame = True Then
				CensorshipTimer.Stop()
				CensorshipBar.Visible = False
				ssh_CensorshipGame = False
				ssh_VideoTease = False

				If ssh_RandomizerVideoTease = True Then
					ScriptTimer.Stop()
					ssh_SaidHello = False
					ssh_RandomizerVideoTease = False
					StopEverything()
					Return
				End If

				RunFileText()
			End If

			If ssh_AvoidTheEdgeGame = True Then

				ssh_TeaseVideo = False
				ssh_AvoidTheEdgeGame = False
				ssh_AvoidTheEdgeStroking = False
				AvoidTheEdgeTaunts.Stop()
				ssh_VideoTease = False
				ssh_SubStroking = False


				Debug.Print("TempStrokeTauntVal = " & ssh_TempStrokeTauntVal)
				Debug.Print("TempFileText = " & ssh_TempFileText)


				If ssh_RandomizerVideoTease = True Then
					ScriptTimer.Stop()
					ssh_SaidHello = False
					ssh_RandomizerVideoTease = False
					StopEverything()
					Return
				End If

				ssh_StrokeTauntVal = ssh_TempStrokeTauntVal
				ssh_FileText = ssh_TempFileText

				ssh_ScriptTick = 2
				ScriptTimer.Start()

				'RunFileText()




				'AvoidTheEdge.Stop()
				'AvoidTheEdgeGame = False
				'SkipGotoLine = True
				'If AvoidTheEdgeTimerTick < 1 Then
				'FileGoto = "(AvoidTheEdge Video Stop)"
				'Else
				'   FileGoto = "(AvoidTheEdge Video Continue)"
				'End If
				'GetGoto()
				'RunFileText()
			End If

			If ssh_RLGLGame = True Then
				RLGLTimer.Stop()
				RLGLTauntTimer.Stop()
				ssh_RLGLGame = False
				ssh_VideoTease = False
				ssh_SubStroking = False


				If ssh_RandomizerVideoTease = True Then
					ScriptTimer.Stop()
					ssh_SaidHello = False
					ssh_RandomizerVideoTease = False
					StopEverything()
					Return
				End If

				ssh_ScriptTick = 1
				ScriptTimer.Start()

				Return
			End If


			If ssh_TeaseVideo = True Then
				ssh_TeaseVideo = False
				DomWMP.Ctlcontrols.pause()
				RunFileText()
			End If


			If ssh_LockVideo = False Then
				mainPictureBox.Visible = True
				DomWMP.Visible = False
			End If


		End If

	End Sub

	Private Sub WMPTimer_Tick(sender As System.Object, e As System.EventArgs) Handles WMPTimer.Tick


		If DomWMP.currentPlaylist.count <> 0 Then
			Try
				Dim VideoLength As Integer = DomWMP.currentMedia.duration
				Dim VideoRemaining As Integer = Math.Floor(DomWMP.currentMedia.duration - DomWMP.Ctlcontrols.currentPosition)

				Debug.Print("Video Length = " & VideoLength)
				Debug.Print("Video Remaining = " & VideoRemaining)
			Catch
			End Try
		End If





		If ssh_DomTypeCheck = True Or DomWMP.playState = WMPLib.WMPPlayState.wmppsStopped Or DomWMP.playState = WMPLib.WMPPlayState.wmppsPaused Then Return

		'Debug.Print("New movie loaded: " & DomWMP.URL.ToString)

		ssh_VidFile = Path.GetFileName(DomWMP.URL.ToString)

		Dim VidSplit As String() = ssh_VidFile.Split(".")
		ssh_VidFile = ""
		For i As Integer = 0 To VidSplit.Count - 2
			ssh_VidFile = ssh_VidFile + VidSplit(i)
		Next
		'Debug.Print(VidFile)
		If ssh_VidFile = "" Then Exit Sub
		If File.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Video\Scripts\" & ssh_VidFile & ".txt") Then
			Dim SubCheck As String()
			Dim PlayPos As Integer
			Dim WMPPos As Integer = Math.Ceiling(DomWMP.Ctlcontrols.currentPosition)

			Dim SubList As New List(Of String)
			SubList = Txt2List(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Video\Scripts\" & ssh_VidFile & ".txt")

			If Not SubList Is Nothing Then
				For i As Integer = 0 To SubList.Count - 1
					SubCheck = SubList(i).Split("]")
					SubCheck(0) = SubCheck(0).Replace("[", "")
					Dim SubCheck2 As String() = SubCheck(0).Split(":")

					PlayPos = SubCheck2(0) * 3600
					PlayPos += SubCheck2(1) * 60
					PlayPos += SubCheck2(2)

					If WMPPos = PlayPos Then
						ssh_DomTask = SubCheck(1)
						TypingDelayGeneric()
						Debug.Print(SubList(i))
					End If
				Next
			End If
		End If


	End Sub

#End Region 'Domme-WMP

	Private Sub domAvatar_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles domAvatar.MouseEnter
		If FrmSettings.Visible = False And FrmCardList.Visible = False Then domAvatar.Focus()
	End Sub

	Private Sub domAvatar_MouseWheel(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles domAvatar.MouseWheel



		If domAvatar.SizeMode = PictureBoxSizeMode.StretchImage Then
			domAvatar.SizeMode = PictureBoxSizeMode.Zoom
			My.Settings.DomAVStretch = False
		Else
			domAvatar.SizeMode = PictureBoxSizeMode.StretchImage
			My.Settings.DomAVStretch = True
		End If

	End Sub


	Private Sub WaitTimer_Tick(sender As System.Object, e As System.EventArgs) Handles WaitTimer.Tick
		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then Return

		If ssh_DomTypeCheck = True Or ssh_YesOrNo = True Then Return

		'Debug.Print("WaitTick = " & WaitTick)

		ssh_WaitTick -= 1

		If ssh_WaitTick < 1 Then
			WaitTimer.Stop()
			ssh_ScriptTick = 1
		End If


	End Sub

	Private Sub StupidTimer_Tick(sender As System.Object, e As System.EventArgs) Handles StupidTimer.Tick

		If PBFileTransfer.Value = PBFileTransfer.Maximum Then
			StupidTimer.Enabled = False

			LBLFileTransfer.Text = "Download complete!"
			BTNFileTransferOpen.Visible = True
			BTNFIleTransferDismiss.Visible = True
			Exit Sub
		End If

		PBFileTransfer.Value += 1

	End Sub










	Public Sub SaveExercise()

		If FormLoading = True Then Return

		Dim FileStream As New System.IO.FileStream(Application.StartupPath & "\System\VitalSub\ExerciseList.cld", IO.FileMode.Create)
		Dim BinaryWriter As New System.IO.BinaryWriter(FileStream)
		For i = 0 To CLBExercise.Items.Count - 1
			BinaryWriter.Write(CStr(CLBExercise.Items(i)))
			BinaryWriter.Write(CBool(CLBExercise.GetItemChecked(i)))
		Next
		BinaryWriter.Close()
		FileStream.Dispose()

	End Sub

	Public Sub LoadExercise()

		CLBExercise.Items.Clear()
		Dim FileStream As New System.IO.FileStream(Application.StartupPath & "\System\VitalSub\ExerciseList.cld", IO.FileMode.Open)
		Dim BinaryReader As New System.IO.BinaryReader(FileStream)
		CLBExercise.BeginUpdate()
		Do While FileStream.Position < FileStream.Length
			CLBExercise.Items.Add(BinaryReader.ReadString)
			CLBExercise.SetItemChecked(CLBExercise.Items.Count - 1, BinaryReader.ReadBoolean)
		Loop
		CLBExercise.EndUpdate()
		BinaryReader.Close()
		FileStream.Dispose()


	End Sub









	Public Sub RefreshCards()

		FrmCardList.GoldN1.Text = FrmSettings.GN1.Text
		FrmCardList.GoldN2.Text = FrmSettings.GN2.Text
		FrmCardList.GoldN3.Text = FrmSettings.GN3.Text
		FrmCardList.GoldN4.Text = FrmSettings.GN4.Text
		FrmCardList.GoldN5.Text = FrmSettings.GN5.Text
		FrmCardList.GoldN6.Text = FrmSettings.GN6.Text

		FrmCardList.GoldP1.Image = Image.FromFile(My.Settings.GP1)
		FrmCardList.GoldP2.Image = Image.FromFile(My.Settings.GP2)
		FrmCardList.GoldP3.Image = Image.FromFile(My.Settings.GP3)
		FrmCardList.GoldP4.Image = Image.FromFile(My.Settings.GP4)
		FrmCardList.GoldP5.Image = Image.FromFile(My.Settings.GP5)
		FrmCardList.GoldP6.Image = Image.FromFile(My.Settings.GP6)

		FrmCardList.SilverN1.Text = FrmSettings.SN1.Text
		FrmCardList.SilverN2.Text = FrmSettings.SN2.Text
		FrmCardList.SilverN3.Text = FrmSettings.SN3.Text
		FrmCardList.SilverN4.Text = FrmSettings.SN4.Text
		FrmCardList.SilverN5.Text = FrmSettings.SN5.Text
		FrmCardList.SilverN6.Text = FrmSettings.SN6.Text

		FrmCardList.SilverP1.Image = Image.FromFile(My.Settings.SP1)
		FrmCardList.SilverP2.Image = Image.FromFile(My.Settings.SP2)
		FrmCardList.SilverP3.Image = Image.FromFile(My.Settings.SP3)
		FrmCardList.SilverP4.Image = Image.FromFile(My.Settings.SP4)
		FrmCardList.SilverP5.Image = Image.FromFile(My.Settings.SP5)
		FrmCardList.SilverP6.Image = Image.FromFile(My.Settings.SP6)

		FrmCardList.BronzeN1.Text = FrmSettings.BN1.Text
		FrmCardList.BronzeN2.Text = FrmSettings.BN2.Text
		FrmCardList.BronzeN3.Text = FrmSettings.BN3.Text
		FrmCardList.BronzeN4.Text = FrmSettings.BN4.Text
		FrmCardList.BronzeN5.Text = FrmSettings.BN5.Text
		FrmCardList.BronzeN6.Text = FrmSettings.BN6.Text

		FrmCardList.BronzeP1.Image = Image.FromFile(My.Settings.BP1)
		FrmCardList.BronzeP2.Image = Image.FromFile(My.Settings.BP2)
		FrmCardList.BronzeP3.Image = Image.FromFile(My.Settings.BP3)
		FrmCardList.BronzeP4.Image = Image.FromFile(My.Settings.BP4)
		FrmCardList.BronzeP5.Image = Image.FromFile(My.Settings.BP5)
		FrmCardList.BronzeP6.Image = Image.FromFile(My.Settings.BP6)

	End Sub








	Public Sub SaveTokens()

		My.Settings.BronzeTokens = ssh_BronzeTokens
		My.Settings.SilverTokens = ssh_SilverTokens
		My.Settings.GoldTokens = ssh_GoldTokens

	End Sub

















	Private Sub VideoTauntTimer_Tick(sender As System.Object, e As System.EventArgs) Handles VideoTauntTimer.Tick

		'TODO: Merge redundant code: VideoTauntTimer_Tick, RLGLTauntTimer_Tick, AvoidTheEdgeTaunts_Tick
		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then Return
		If ssh_MiniScript = True Then Return

		If ssh_DomTyping = True Then Return
		If ssh_DomTypeCheck = True And ssh_VideoTauntTick < 6 Then Return
		If chatBox.Text <> "" And ssh_VideoTauntTick < 6 Then Return
		If ChatBox2.Text <> "" And ssh_VideoTauntTick < 6 Then Return

		ssh_VideoTauntTick -= 1


		If ssh_VideoTauntTick < 1 Then

			Dim FrequencyTemp As Integer = ssh_randomizer.Next(1, 101)
			If FrequencyTemp > FrmSettings.TauntSlider.Value * 5 Then
				ssh_VideoTauntTick = ssh_randomizer.Next(20, 31)
				Return
			End If

			Dim VTDir As String

			If ssh_RLGLGame = True Then VTDir = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Video\Red Light Green Light\Taunts.txt"
			'TODO: Prevent File.Exits() with String.Empty
			If Not File.Exists(VTDir) Then Return

			' Read all lines of the given file.
			Dim VTList As List(Of String) = Txt2List(VTDir)

			Try
				VTList = FilterList(VTList)
				If VTList.Count < 1 Then Return
				ssh_DomTask = VTList(ssh_randomizer.Next(0, VTList.Count))
			Catch ex As Exception
				Log.WriteError("Tease AI did not return a valid Video Taunt from file: " &
							   VTDir, ex, "VideoTaunTimer.Tick")
				ssh_DomTask = "ERROR: Tease AI did not return a valid Video Taunt"
			End Try

			TypingDelayGeneric()



			ssh_VideoTauntTick = ssh_randomizer.Next(20, 31)


		End If









	End Sub

	Private Sub TeaseTimer_Tick(sender As System.Object, e As System.EventArgs) Handles TeaseTimer.Tick


		FrmSettings.LBLDebugTeaseTime.Text = ssh_TeaseTick
		'Debug.Print("TeaseTick = " & TeaseTick)

		ssh_TeaseTick -= 1

		If ssh_TeaseTick < 1 Then TeaseTimer.Stop()



	End Sub

	Public Sub RLGLTauntTimer_Tick(sender As System.Object, e As System.EventArgs) Handles RLGLTauntTimer.Tick
		'TODO: Merge redundant code: VideoTauntTimer_Tick, RLGLTauntTimer_Tick, AvoidTheEdgeTaunts_Tick
		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then Return
		If ssh_MiniScript = True Then Return

		If ssh_DomTyping = True Then Return
		If ssh_DomTypeCheck = True And ssh_RLGLTauntTick < 6 Then Return
		If chatBox.Text <> "" And ssh_RLGLTauntTick < 6 Then Return
		If ChatBox2.Text <> "" And ssh_RLGLTauntTick < 6 Then Return

		ssh_RLGLTauntTick -= 1


		If ssh_RLGLTauntTick < 1 Then

			Dim FrequencyTemp As Integer = ssh_randomizer.Next(1, 101)
			If FrequencyTemp > FrmSettings.TauntSlider.Value * 5 Then
				ssh_RLGLTauntTick = ssh_randomizer.Next(20, 31)
				Return
			End If

			Dim VTDir As String

			VTDir = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Video\Red Light Green Light\Taunts.txt"

			If Not File.Exists(VTDir) Then Return

			' Read all lines of the given file.
			Dim VTList As List(Of String) = Txt2List(VTDir)

			Try
				VTList = FilterList(VTList)
				If VTList.Count < 1 Then Return
				ssh_DomTask = VTList(ssh_randomizer.Next(0, VTList.Count))
			Catch ex As Exception
				Log.WriteError("Tease AI did not return a valid Video Taunt from file: " &
							   VTDir, ex, "RLGLTauntTimer.Tick")
				ssh_DomTask = "ERROR: Tease AI did not return a valid Video Taunt"
			End Try
			TypingDelayGeneric()



			ssh_RLGLTauntTick = ssh_randomizer.Next(20, 31)


		End If



	End Sub

	Private Sub AvoidTheEdgeTaunts_Tick(sender As System.Object, e As System.EventArgs) Handles AvoidTheEdgeTaunts.Tick
		'TODO: Merge redundant code: VideoTauntTimer_Tick, RLGLTauntTimer_Tick, AvoidTheEdgeTaunts_Tick
		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then Return

		If ssh_DomTyping = True Then Return
		If ssh_DomTypeCheck = True And ssh_AvoidTheEdgeTick < 6 Then Return
		If chatBox.Text <> "" And ssh_AvoidTheEdgeTick < 6 Then Return
		If ChatBox2.Text <> "" And ssh_AvoidTheEdgeTick < 6 Then Return



		ssh_AvoidTheEdgeTick -= 1


		If ssh_AvoidTheEdgeTick < 1 Then

			Dim FrequencyTemp As Integer = ssh_randomizer.Next(1, 101)
			If FrequencyTemp > FrmSettings.TauntSlider.Value * 5 Then
				ssh_AvoidTheEdgeTick = ssh_randomizer.Next(20, 31)
				Return
			End If

			Dim VTDir As String

			VTDir = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Video\Avoid The Edge\Taunts.txt"

			If Not File.Exists(VTDir) Then Return

			' Read all lines of the given file.
			Dim VTList As List(Of String) = Txt2List(VTDir)

			Try
				VTList = FilterList(VTList)
				If VTList.Count < 1 Then Return
				ssh_DomTask = VTList(ssh_randomizer.Next(0, VTList.Count))
			Catch ex As Exception
				Log.WriteError("Tease AI did not return a valid Video Taunt from file: " &
							   VTDir, ex, "AvoidTheEdgeTaunts.Tick")
				ssh_DomTask = "ERROR: Tease AI did not return a valid Video Taunt"
			End Try
			TypingDelayGeneric()



			ssh_AvoidTheEdgeTick = ssh_randomizer.Next(20, 31)


		End If


	End Sub

#Region "-------------------------------------------------- MainPictureBox ----------------------------------------------------"

	Private Sub mainPictureBox_LoadCompleted(sender As Object, e As System.ComponentModel.AsyncCompletedEventArgs) Handles mainPictureBox.LoadCompleted
		ssh_ImageLocation = mainPictureBox.ImageLocation
		CheckDommeTags()
		Debug.Print("ImageLoadCOmpleted")
	End Sub

	Private Sub mainPictureBox_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles mainPictureBox.MouseDown
		If e.Button = MouseButtons.Right Then
			PictureStrip.Show(CType(sender, Control), e.Location)
		End If
	End Sub



#End Region ' MainPictureBox

#Region "-------------------------------------------------- PictureStrip ------------------------------------------------------"



	Private Sub PictureStrip_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles PictureStrip.Opening

		If mainPictureBox.Image IsNot Nothing Then

			If ImageAnimator.CanAnimate(mainPictureBox.Image) _
			And ImageAnimator_OnFrameChangedAdded Then
				PicStripTmsiDisableAnimation.Enabled = True

				If mreImageanimator.WaitOne(0) = True Then
					' ImageAnimations are running
					PicStripTmsiDisableAnimation.Checked = False
				Else
					' ImageAnimations are stopped
					PicStripTmsiDisableAnimation.Checked = True
				End If
			Else
				PicStripTmsiDisableAnimation.Enabled = False
				PicStripTmsiDisableAnimation.Checked = False
			End If

			If isURL(ssh_ImageLocation) Then

				PicStripTSMIsaveImage.Enabled = True
				PicStripTSMISaveImageTo.Enabled = True
				PicStripTSMIremoveFromURL.Enabled = True

			ElseIf ssh_ImageLocation = "" Or ssh__ImageFileNames.Contains(ssh_ImageLocation) Then

				PicStripTSMIcopyImageLocation.Enabled = False
				PicStripTSMIsaveImage.Enabled = False
				PicStripTSMISaveImageTo.Enabled = False
				PicStripTSMIlikeImage.Enabled = False
				PicStripTSMIlikeImage.Checked = False
				PicStripTSMIdislikeImage.Enabled = False
				PicStripTSMIdislikeImage.Checked = False
				PicStripTSMIremoveFromURL.Enabled = False

				If ssh__ImageFileNames.Contains(ssh_ImageLocation) Then
					PicStripTSMIdommeSlideshow.Enabled = True
					PicStripTSMIcopyImageLocation.Enabled = True
				End If

				Exit Sub

			End If

			PicStripTSMIcopyImageLocation.Enabled = True
			PicStripTSMIlikeImage.Enabled = True
			PicStripTSMIlikeImage.Checked = False
			PicStripTSMIdislikeImage.Enabled = True
			PicStripTSMIdislikeImage.Checked = False

			Dim tmp As List(Of String) = Txt2List(pathLikeList)
			If tmp.Contains(ssh_ImageLocation) Then PicStripTSMIlikeImage.Checked = True

			tmp = Txt2List(pathDislikeList)
			If tmp.Contains(ssh_ImageLocation) Then PicStripTSMIdislikeImage.Checked = True

		End If

	End Sub

	Private Sub PictureStripTmsiDisableAnimation_Click(sender As Object, e As EventArgs) Handles PicStripTmsiDisableAnimation.Click
		If mreImageanimator.WaitOne(0) = True Then
			' Signals the ImageAnimatorThread to pause.
			mreImageanimator.Reset()
		Else
			' Signals the ImageAnimatorThread to resume.
			mreImageanimator.Set()
		End If
	End Sub

	Private Sub PicStripTSMIcopyImageLocation_Click(sender As System.Object, e As System.EventArgs) Handles PicStripTSMIcopyImageLocation.Click

		My.Computer.Clipboard.SetText(ssh_ImageLocation)

	End Sub


	Public Sub PicStripTSMI_SaveImage(sender As System.Object, e As System.EventArgs) Handles PicStripTSMIsaveHardcore.Click,
		PicStripTSMIsaveSoftcore.Click, PicStripTSMIsaveLesbian.Click, PicStripTSMIsaveBlowjob.Click, PicStripTSMIsaveFemdom.Click,
		PicStripTSMIsaveLezdom.Click, PicStripTSMIsaveHentai.Click, PicStripTSMIsaveGay.Click, PicStripTSMIsaveMaledom.Click,
		PicStripTSMIsaveCaptions.Click, PicStripTSMIsaveGeneral.Click, PicStripTSMIsaveBoobs.Click, PicStripTSMIsaveButts.Click, PicStripTSMIsaveImage.Click
retry:
		Try
			Dim BlogPath As String = ""
			Dim fileName As String = Path.GetFileName(mainPictureBox.ImageLocation)

			If sender Is PicStripTSMIsaveHardcore Then : BlogPath = My.Settings.IHardcore
			ElseIf sender Is PicStripTSMIsaveSoftcore Then : BlogPath = My.Settings.ISoftcore
			ElseIf sender Is PicStripTSMIsaveLesbian Then : BlogPath = My.Settings.ILesbian
			ElseIf sender Is PicStripTSMIsaveBlowjob Then : BlogPath = My.Settings.IBlowjob
			ElseIf sender Is PicStripTSMIsaveFemdom Then : BlogPath = My.Settings.IFemdom
			ElseIf sender Is PicStripTSMIsaveLezdom Then : BlogPath = My.Settings.ILezdom
			ElseIf sender Is PicStripTSMIsaveHentai Then : BlogPath = My.Settings.IHentai
			ElseIf sender Is PicStripTSMIsaveGay Then : BlogPath = My.Settings.IGay
			ElseIf sender Is PicStripTSMIsaveMaledom Then : BlogPath = My.Settings.IMaledom
			ElseIf sender Is PicStripTSMIsaveCaptions Then : BlogPath = My.Settings.ICaptions
			ElseIf sender Is PicStripTSMIsaveGeneral Then : BlogPath = My.Settings.IGeneral
			ElseIf sender Is PicStripTSMIsaveBoobs Then : BlogPath = My.Settings.LBLBoobPath
			ElseIf sender Is PicStripTSMIsaveButts Then : BlogPath = My.Settings.LBLButtPath
			ElseIf sender Is PicStripTSMIsaveImage Then
				SaveFileDialog1.Filter = "jpegs|*.jpg|gifs|*.gif|pngs|*.png|Bitmaps|*.bmp"
				SaveFileDialog1.FilterIndex = 1
				SaveFileDialog1.RestoreDirectory = True
				SaveFileDialog1.FileName = fileName
				SaveFileDialog1.CheckFileExists = False

				If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
					fileName = Path.GetFileName(SaveFileDialog1.FileName)
					BlogPath = Path.GetDirectoryName(SaveFileDialog1.FileName)
				Else
					Exit Sub
				End If
			Else : Throw New NotImplementedException("Action for this button is not implemented.")
			End If

			If Directory.Exists(BlogPath) = False Then
				Throw New DirectoryNotFoundException(
							"Unable to find the directroy """ & BlogPath & """" &
							vbCrLf & vbCrLf &
							"Please check your image settings.")
			End If

			Dim fullPath As String = BlogPath & "\" & fileName

			' Save image directly
			If Not File.Exists(fullPath) Or SaveFileDialog1.CheckFileExists Then GoTo saveImage

			' Confirm overwriting the file
			If MessageBox.Show(Me, fileName & " already exists in this directory!" &
							Environment.NewLine & Environment.NewLine &
							"Do you wish to overwrite?", "Caution!",
							MessageBoxButtons.YesNo,
							MessageBoxIcon.Exclamation) = DialogResult.No Then
				Exit Sub
			End If

			My.Computer.FileSystem.DeleteFile(fullPath)
saveImage:

			mainPictureBox.Image.Save(fullPath)

		Catch ex As Exception
			'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
			'                                            All Errors
			'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
			Log.WriteError(ex.Message, ex, "Saving image failed.")
			If MessageBox.Show(ex.Message, "Saving image failed.",
							MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation,
							MessageBoxDefaultButton.Button2) = DialogResult.Retry Then GoTo retry
		End Try
	End Sub

	Private Sub PicStripTSMIlikeImage_Click(sender As System.Object, e As System.EventArgs) Handles PicStripTSMIlikeImage.Click,
																									PicStripTSMIdislikeImage.Click
		' Exit if ImageLocation is unkown
		If ssh_ImageLocation = "" Then Exit Sub

		Dim tmpFilePath As String = ""
		Dim lazytext As String = ""
		Try
			Dim tmpTsmi As ToolStripMenuItem = DirectCast(sender, ToolStripMenuItem)


			' Set the filepath to delete from or add to
			If tmpTsmi Is PicStripTSMIlikeImage Then
				tmpFilePath = pathLikeList
			ElseIf tmpTsmi Is PicStripTSMIdislikeImage
				tmpFilePath = pathDislikeList
			Else
				Throw New NotImplementedException("This Toolstripmenuitem is not implemented yet")
			End If


			If tmpTsmi.Checked Then
				' Remove from the given file 
				lazytext = "remove path from file :" & tmpFilePath
				TxtRemoveLine(tmpFilePath, ssh_ImageLocation)
				tmpTsmi.Checked = False
			ElseIf File.Exists(tmpFilePath) Then
				lazytext = "append path  to file :" & tmpFilePath
				' Append to existing file 
				My.Computer.FileSystem.WriteAllText(tmpFilePath, Environment.NewLine & ssh_ImageLocation, True)
			Else
				lazytext = "add path to new file :" & tmpFilePath
				' create a new file
				My.Computer.FileSystem.WriteAllText(tmpFilePath, ssh_ImageLocation, True)
			End If
			tmpTsmi.Checked = True
		Catch ex As Exception
			'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
			'						       All Errors
			'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
			lazytext = "Unable to " & lazytext
			Log.WriteError(lazytext, ex, "Error updating List")
			MessageBox.Show(Me, lazytext & vbCrLf _
							& ex.Message, MsgBoxStyle.Exclamation, "Error updating list.")
		End Try
	End Sub

	Private Sub PicStripTSMIremoveFromURL_Click(sender As System.Object, e As System.EventArgs) Handles PicStripTSMIremoveFromURL.Click
		Try
            ' Lock Control
            PicStripTSMIremoveFromURL.Enabled = False

			' Remove from URL-Files.
			RemoveFromUrlFiles(ssh_ImageLocation)
		Catch ex As Exception
            '▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
            '						       All Errors
            '▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
            Log.WriteError(ex.Message & vbCrLf & ToString(), ex, "Error while deleting URL-From files.")
			MsgBox("An Exception Occured while deleting the URL from Files." & vbCrLf _
				   & ex.Message, MsgBoxStyle.Exclamation, "Delete URL from Files")
		End Try
	End Sub

#Region "-------------------------------------------------- DommeSlideshow ----------------------------------------------------"

	Private Sub PicStripTSMIdommeSlideshowGoToLast_Click(sender As System.Object, e As System.EventArgs) Handles PicStripTSMIdommeSlideshowGoToLast.Click

		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then
			MsgBox("Please close the settings menu or disable ""Pause Program When Settings Menu Is Visible"" option first!", , "Warning!")
			Return
		End If

		If ssh_SlideshowLoaded = False Or ssh_TeaseVideo = True Or ssh_LockImage = True Then Return

		ssh_FileCount = ssh_FileCountMax

		Try
			ShowImage(ssh__ImageFileNames(ssh_FileCount), True)
			ssh_JustShowedBlogImage = False
		Catch

		End Try
	End Sub

	Private Sub PicStripTSMIdommeSlideshow_GoToFirst_Click(sender As System.Object, e As System.EventArgs) Handles PicStripTSMIdommeSlideshow_GoToFirst.Click

		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then
			MsgBox("Please close the settings menu or disable ""Pause Program When Settings Menu Is Visible"" option first!", , "Warning!")
			Return
		End If

		If ssh_SlideshowLoaded = False Or ssh_TeaseVideo = True Or ssh_LockImage = True Then Return

		ssh_FileCount = 0

		Try
			ShowImage(ssh__ImageFileNames(ssh_FileCount), True)
			ssh_JustShowedBlogImage = False
		Catch

		End Try
	End Sub

	Private Sub PicStripTSMIdommeSlideshowLoadNewSlideshow_Click(sender As System.Object, e As System.EventArgs) Handles PicStripTSMIdommeSlideshowLoadNewSlideshow.Click

		ssh_NewDommeSlideshow = True
		ssh_OriginalDommeSlideshow = ssh__ImageFileNames(0)
		LoadDommeImageFolder()
		ssh_NewDommeSlideshow = False
		ssh_DomPic = ssh__ImageFileNames(ssh_FileCount)

	End Sub

#End Region ' DommeSlideshow

#End Region ' PictureStrip


	Private Sub ContactTimer_Tick(sender As System.Object, e As System.EventArgs) Handles ContactTimer.Tick
		'QUESTION: (stefaF) This Timer seems to be useless. Is this correct?
		ssh_ContactTick -= 1


		If ssh_ContactTick < 1 Then
			ContactTimer.Stop()
			ContactFlag = False
		End If

	End Sub


















	Public Sub LoadDommeImageFolder()
		'TODO-Next-Stefaf: Implement ShowImage(String, Boolean) and myDirectory.GetFilesImages(String) + Rework

		Dim NewSlideshowAttempts As Integer = 0

GetDommeSlideshow:

		Dim GreetFolder As New List(Of String)
		GreetFolder.Clear()



		For Each Dir As String In myDirectory.GetDirectories(FrmSettings.LBLDomImageDir.Text)
			Try
				GreetFolder.Add(Dir)
			Catch
			End Try
		Next

		' Try
		If GreetFolder.Count < 1 Then
			MessageBox.Show(Me, "There are no directories in the specified Domme Images Directory folder." & Environment.NewLine & Environment.NewLine &
							"Please make sure the Domme Images Directory points to a location containing at least one subdirectory of images.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Return
		End If

		ssh_GetFolder = GreetFolder(ssh_randomizer.Next(0, GreetFolder.Count))

		ssh_SlideshowLoaded = True

		DomWMP.Visible = False
		DomWMP.Ctlcontrols.pause()
		mainPictureBox.Visible = True

		FrmSettings.timedRadio.Enabled = True
		FrmSettings.teaseRadio.Enabled = True

		ssh_FileCount = 0
		ssh_FileCountMax = -1
		ssh__ImageFileNames.Clear()


		If FrmSettings.CBSlideshowSubDir.Checked = True Then
			ssh__ImageFileNames = myDirectory.GetFilesImages(ssh_GetFolder, SearchOption.AllDirectories)
		Else
			ssh__ImageFileNames = myDirectory.GetFilesImages(ssh_GetFolder, SearchOption.TopDirectoryOnly)
		End If

		ssh_FileCountMax = ssh__ImageFileNames.Count - 1



		If ssh_FileCountMax < 0 Then
			MessageBox.Show(Me, "There are no images in the specified Domme Image folder!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Return
		End If

		ssh_FileCount = 0


		If ssh_NewDommeSlideshow = True Then
			NewSlideshowAttempts += 1
			If ssh__ImageFileNames(0) = ssh_OriginalDommeSlideshow And NewSlideshowAttempts < 6 Then GoTo GetDommeSlideshow
		End If



		If FrmSettings.CBSlideshowRandom.Checked = True Then ssh_FileCount = ssh_randomizer.Next(0, ssh_FileCountMax + 1)

		ShowImage(ssh__ImageFileNames(ssh_FileCount), False)
		ssh_JustShowedBlogImage = False

		nextButton.Enabled = True
		previousButton.Enabled = True
		PicStripTSMIdommeSlideshow.Enabled = True

		If ssh_RiskyDeal = True Then FrmCardList.PBRiskyPic.Image = Image.FromFile(ssh__ImageFileNames(ssh_FileCount))


		If FrmSettings.landscapeCheckBox.Checked = True Then
			If mainPictureBox.Image.Width > mainPictureBox.Image.Height Then
				mainPictureBox.SizeMode = PictureBoxSizeMode.StretchImage
			Else
				mainPictureBox.SizeMode = PictureBoxSizeMode.Zoom
			End If
		Else
			mainPictureBox.SizeMode = PictureBoxSizeMode.Zoom
		End If


		mainPictureBox.Refresh()
		mainPictureBox.Invalidate()

		If FrmSettings.timedRadio.Checked = True Then
			ssh_SlideshowTimerTick = FrmSettings.slideshowNumBox.Value
			SlideshowTimer.Start()
		End If





	End Sub

	Public Sub ScrollChatDown()

		Try
			ChatText.Document.Window.ScrollTo(Int16.MaxValue, Int16.MaxValue)
		Catch
		End Try

		Try
			ChatText2.Document.Window.ScrollTo(Int16.MaxValue, Int16.MaxValue)
		Catch
		End Try

	End Sub




	Private Sub StatusUpdates_DocumentCompleted(sender As Object, e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles StatusUpdates.DocumentCompleted
		Try
			StatusUpdates.Document.Window.ScrollTo(Int16.MaxValue, Int16.MaxValue)
		Catch
		End Try
	End Sub



	Public Function WordExists(ByVal searchString As String, ByVal findString As String) As Boolean

		Dim returnValue As Boolean = False

		If System.Text.RegularExpressions.Regex.Matches(searchString, "\b" & findString & "\b").Count > 0 Then returnValue = True
		Return returnValue

	End Function

	Function Capitalize(ByVal val As String) As String
		If String.IsNullOrEmpty(val) Then
			Return val
		End If
		Dim array() As Char = val.ToCharArray
		array(0) = Char.ToUpper(array(0))
		Return New String(array)
	End Function



	Public Function CompareDates(ByVal CheckDate As Date) As Integer

		Dim result As Integer = DateTime.Compare(FormatDateTime(CheckDate, DateFormat.ShortDate), FormatDateTime(Now, DateFormat.ShortDate))
		Debug.Print("Compare dates: " & FormatDateTime(CheckDate, DateFormat.ShortDate) & " <-> " & FormatDateTime(Now, DateFormat.ShortDate) & " = " & result)
		Return result

	End Function

	Public Function CompareDatesWithTime(ByVal CheckDate As Date) As Integer

		Dim result As Integer = DateTime.Compare(FormatDateTime(CheckDate, DateFormat.GeneralDate), FormatDateTime(Now, DateFormat.GeneralDate))
		Debug.Print("Compare dates: " & FormatDateTime(CheckDate, DateFormat.GeneralDate) & " <-> " & FormatDateTime(Now, DateFormat.GeneralDate) & " = " & result)
		Return result

	End Function

	Public Function StripBlankLines(ByVal SpaceClean As List(Of String)) As List(Of String)
		For i As Integer = SpaceClean.Count - 1 To 0 Step -1
			If SpaceClean(i) = "" Then SpaceClean.Remove(SpaceClean(i))
		Next
		Return SpaceClean
	End Function

	Public Function StripCommands(ByVal CFClean As String) As String

		Debug.Print("CFClean = " & CFClean)

		' This works as a solution to avoid all the crap I'm having to do underneath it, but I couldn't figuure out how to keep it from eating
		' words after @CommandFilters in #Keywords

		'Dim CleanReg As RegularExpressions.Regex
		'CleanReg = New RegularExpressions.Regex("(@[^)]+)\)")

		'Dim StripArray As String() = CFClean.Split(")")

		'For i As Integer = 0 To StripArray.Count - 1
		'If StripArray(i).Contains("@") Then
		'StripArray(i) = StripArray(i) & ")"
		'StripArray(i) = StripArray(i).Replace(CleanReg.Match(StripArray(i)).Value(), "")
		'End If
		'Next

		'CFClean = Join(StripArray)

		'Debug.Print("CFClean Joined = " & CFClean)


		If CFClean.Contains("@Variable[") Then
			CFClean = CFClean.Replace("@Variable[" & GetParentheses(CFClean, "@Variable[", 2) & "]", "")
			If CFClean.Contains("And[") Then CFClean = CFClean.Replace("And[" & GetParentheses(CFClean, "And[", 2) & "]", "")
			If CFClean.Contains("Or[") Then CFClean = CFClean.Replace("Or[" & GetParentheses(CFClean, "Or[", 2) & "]", "")
		End If

		If CFClean.Contains("@Cup(") Then CFClean = CFClean.Replace("@Cup(" & GetParentheses(CFClean, "@Cup(") & ")", "")
		If CFClean.Contains("@AllowsOrgasm(") Then CFClean = CFClean.Replace("@AllowsOrgasm(" & GetParentheses(CFClean, "@AllowsOrgasm(") & ")", "")
		If CFClean.Contains("@RuinsOrgasm(") Then CFClean = CFClean.Replace("@RuinsOrgasm(" & GetParentheses(CFClean, "@RuinsOrgasm(") & ")", "")
		If CFClean.Contains("@DommeLevel(") Then CFClean = CFClean.Replace("@DommeLevel(" & GetParentheses(CFClean, "@DommeLevel(") & ")", "")
		If CFClean.Contains("@ApathyLevel(") Then CFClean = CFClean.Replace("@ApathyLevel(" & GetParentheses(CFClean, "@ApathyLevel(") & ")", "")
		If CFClean.Contains("@Month(") Then CFClean = CFClean.Replace("@Month(" & GetParentheses(CFClean, "@Month(") & ")", "")
		If CFClean.Contains("@Day(") Then CFClean = CFClean.Replace("@Day(" & GetParentheses(CFClean, "@Day(") & ")", "")

		Dim AtArray() As String = Split(CFClean)
		For i As Integer = 0 To AtArray.Length - 1
			Try
				If AtArray(i).Contains("@") Then
					AtArray(i) = AtArray(i).Replace(AtArray(i), "")
				End If
			Catch
			End Try
		Next
		CFClean = Join(AtArray)
		Return CFClean

	End Function

	Public Function StripFormat(ByVal FormatClean As String) As String
		FormatClean = FormatClean.Replace("<i>", "")
		FormatClean = FormatClean.Replace("</i>", "")
		FormatClean = FormatClean.Replace("<b>", "")
		FormatClean = FormatClean.Replace("</b>", "")
		FormatClean = FormatClean.Replace("<u>", "")
		FormatClean = FormatClean.Replace("</u>", "")
		FormatClean = FormatClean.Replace(FrmSettings.TBEmote.Text, "")
		FormatClean = FormatClean.Replace(FrmSettings.TBEmoteEnd.Text, "")

		Return FormatClean
	End Function


	Private Sub CustomSlideshowTimer_Tick(sender As System.Object, e As System.EventArgs) Handles CustomSlideshowTimer.Tick
		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then Return
		Try
			CustomSlideshowTimer.Stop()

			ssh_ImageString = ssh_CustomSlideshowList(ssh_randomizer.Next(0, ssh_CustomSlideshowList.Count))

			ShowImage(ssh_ImageString, True)
		Catch ex As Exception
			Exit Sub
		Finally
			CustomSlideshowTimer.Start()
		End Try
	End Sub

	Public Shared Function ResizeImage(ByVal image As Image, ByVal size As Size, Optional ByVal preserveAspectRatio As Boolean = True) As Image

		Dim newWidth As Integer
		Dim newHeight As Integer
		If preserveAspectRatio Then
			Dim originalWidth As Integer = image.Width
			Dim originalHeight As Integer = image.Height
			Dim percentWidth As Single = CSng(size.Width) / CSng(originalWidth)
			Dim percentHeight As Single = CSng(size.Height) / CSng(originalHeight)
			Dim percent As Single = If(percentHeight < percentWidth, percentHeight, percentWidth)
			newWidth = CInt(originalWidth * percent)
			newHeight = CInt(originalHeight * percent)
		Else
			newWidth = size.Width
			newHeight = size.Height
		End If

		Dim newImage As Image = New Bitmap(newWidth, newHeight)

		Using graphicsHandle As Graphics = Graphics.FromImage(newImage)
			graphicsHandle.InterpolationMode = InterpolationMode.HighQualityBicubic
			graphicsHandle.DrawImage(image, 0, 0, newWidth, newHeight)
		End Using
		Return newImage

	End Function

#Region "-------------------------------------------------- Contact 1-3 -------------------------------------------------------"

	Public Sub Contact1Pics_Load()
		Contact1Pics_Clear()
		ssh_Contact1Pics = Slideshow.Get_Contact1Images()
	End Sub

	Public Sub Contact1Pics_Clear()
		ssh_Contact1Pics.Clear()
		ssh_Contact1PicsCount = -1
	End Sub

	Public Sub Contact2Pics_Load()
		Contact2Pics_Clear()
		ssh_Contact2Pics = Slideshow.Get_Contact2Images()
	End Sub

	Public Sub Contact2Pics_Clear()
		ssh_Contact2Pics.Clear()
		ssh_Contact2PicsCount = -1
	End Sub

	Public Sub Contact3Pics_Load()
		Contact3Pics_Clear()
		ssh_Contact3Pics = Slideshow.Get_Contact3Images()
	End Sub

	Public Sub Contact3Pics_Clear()
		ssh_Contact3Pics.Clear()
		ssh_Contact3PicsCount = -1
	End Sub


	Private Sub Contact1Timer_Tick(sender As System.Object, e As System.EventArgs) Handles Contact1Timer.Tick

		ssh_AddContactTick -= 1

		If ssh_AddContactTick < 1 Then
			Contact1Timer.Stop()
			If Not ssh_Group.Contains("1") Then
				ssh_Group = ssh_Group & "1"
				ssh_GlitterTease = True
				ssh_Chat = "<body style=""word-wrap:break-word;"">" & "<font face=""" & "Cambria" & """ size=""" & "3" & """ color=""#000000"">" & ssh_Chat & "<font color=""SteelBlue""><b>" & FrmSettings.TBGlitter1.Text & " has joined the Chat room</b>" & "<br></font></body>"
				ChatText.DocumentText = ssh_Chat
				ChatText2.DocumentText = ssh_Chat
				ChatReadyState()
			Else
				ssh_Group = ssh_Group.Replace("1", "")
				If ssh_Group = "D" Then ssh_GlitterTease = False
				ssh_Chat = "<body style=""word-wrap:break-word;"">" & "<font face=""" & "Cambria" & """ size=""" & "3" & """ color=""#000000"">" & ssh_Chat & "<font color=""SteelBlue""><b>" & FrmSettings.TBGlitter1.Text & " has left the Chat room</b>" & "<br></font></body>"
				ChatText.DocumentText = ssh_Chat
				ChatText2.DocumentText = ssh_Chat
				ChatReadyState()
			End If
		End If

	End Sub

	Private Sub Contact2Timer_Tick(sender As System.Object, e As System.EventArgs) Handles Contact2Timer.Tick

		ssh_AddContactTick -= 1

		If ssh_AddContactTick < 1 Then
			Contact2Timer.Stop()
			If Not ssh_Group.Contains("2") Then
				ssh_Group = ssh_Group & "2"
				ssh_GlitterTease = True
				ssh_Chat = "<body style=""word-wrap:break-word;"">" & "<font face=""" & "Cambria" & """ size=""" & "3" & """ color=""#000000"">" & ssh_Chat & "<font color=""SteelBlue""><b>" & FrmSettings.TBGlitter2.Text & " has joined the Chat room</b>" & "<br></font></body>"
				ChatText.DocumentText = ssh_Chat
				ChatText2.DocumentText = ssh_Chat
				ChatReadyState()
			Else
				ssh_Group = ssh_Group.Replace("2", "")
				If ssh_Group = "D" Then ssh_GlitterTease = False
				ssh_Chat = "<body style=""word-wrap:break-word;"">" & "<font face=""" & "Cambria" & """ size=""" & "3" & """ color=""#000000"">" & ssh_Chat & "<font color=""SteelBlue""><b>" & FrmSettings.TBGlitter2.Text & " has left the Chat room</b>" & "<br></font></body>"
				ChatText.DocumentText = ssh_Chat
				ChatText2.DocumentText = ssh_Chat
				ChatReadyState()
			End If
		End If

	End Sub

	Private Sub Contact3Timer_Tick(sender As System.Object, e As System.EventArgs) Handles Contact3Timer.Tick

		ssh_AddContactTick -= 1

		If ssh_AddContactTick < 1 Then
			Contact3Timer.Stop()
			If Not ssh_Group.Contains("3") Then
				ssh_Group = ssh_Group & "3"
				ssh_GlitterTease = True
				ssh_Chat = "<body style=""word-wrap:break-word;"">" & "<font face=""" & "Cambria" & """ size=""" & "3" & """ color=""#000000"">" & ssh_Chat & "<font color=""SteelBlue""><b>" & FrmSettings.TBGlitter3.Text & " has joined the Chat room</b>" & "<br></font></body>"
				ChatText.DocumentText = ssh_Chat
				ChatText2.DocumentText = ssh_Chat
				ChatReadyState()
			Else
				ssh_Group = ssh_Group.Replace("3", "")
				If ssh_Group = "D" Then ssh_GlitterTease = False
				ssh_Chat = "<body style=""word-wrap:break-word;"">" & "<font face=""" & "Cambria" & """ size=""" & "3" & """ color=""#000000"">" & ssh_Chat & "<font color=""SteelBlue""><b>" & FrmSettings.TBGlitter3.Text & " has left the Chat room</b>" & "<br></font></body>"
				ChatText.DocumentText = ssh_Chat
				ChatText2.DocumentText = ssh_Chat
				ChatReadyState()
			End If
		End If

	End Sub

#End Region

	Private Sub DommeTimer_Tick(sender As System.Object, e As System.EventArgs) Handles DommeTimer.Tick

		ssh_AddContactTick -= 1

		If ssh_AddContactTick < 1 Then
			DommeTimer.Stop()
			If Not ssh_Group.Contains("D") Then
				ssh_Group = ssh_Group & "D"
				If ssh_Group = "D" Then ssh_GlitterTease = False
				ssh_Chat = "<body style=""word-wrap:break-word;"">" & "<font face=""" & "Cambria" & """ size=""" & "3" & """ color=""#000000"">" & ssh_Chat & "<font color=""SteelBlue""><b>" & domName.Text & " has joined the Chat room</b>" & "<br></font></body>"
				ChatText.DocumentText = ssh_Chat
				ChatText2.DocumentText = ssh_Chat
				ChatReadyState()
			Else
				ssh_Group = ssh_Group.Replace("D", "")
				ssh_GlitterTease = True
				ssh_Chat = "<body style=""word-wrap:break-word;"">" & "<font face=""" & "Cambria" & """ size=""" & "3" & """ color=""#000000"">" & ssh_Chat & "<font color=""SteelBlue""><b>" & domName.Text & " has left the Chat room</b>" & "<br></font></body>"
				ChatText.DocumentText = ssh_Chat
				ChatText2.DocumentText = ssh_Chat
				ChatReadyState()
			End If
		End If

	End Sub

	Private Sub UpdateStageTimer_Tick(sender As System.Object, e As System.EventArgs) Handles UpdateStageTimer.Tick
		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then Return
		ssh_UpdateStageTick -= 1
		If ssh_UpdateStageTick < 1 Then
			UpdateStageTimer.Stop()
			StatusUpdatePost()
		End If
	End Sub

#Region "-------------------------------------------- Session Supend/Reset ----------------------------------------------------"

	Public Sub SuspendSession()


		Dim SettingsPath As String = Application.StartupPath & "\System\"
		Dim SettingsList As New List(Of String)
		SettingsList.Clear()


		SettingsList.Add("Personality: " & dompersonalitycombobox.Text)
		SettingsList.Add("ScriptOperator: " & ssh_ScriptOperator)
		SettingsList.Add("ScriptCompare: " & ssh_ScriptCompare)
		SettingsList.Add("DomTyping: " & ssh_DomTyping)
		SettingsList.Add("CheckYes: " & ssh_CheckYes)
		SettingsList.Add("CheckNo: " & ssh_CheckNo)
		SettingsList.Add("Playlist: " & ssh_Playlist)

		SettingsList.Add("PlaylistCurrent: " & ssh_PlaylistCurrent)
		SettingsList.Add("SubInChastity: --obsolete--") ' for compatibility
		' Github Patch SettingsList.Add("FormLoading:  " & FormLoading)
		SettingsList.Add("FormLoading: " & False)
		SettingsList.Add("RandomDelay: --obsolete--") ' for compatibility
		SettingsList.Add("Responding: " & ssh_Responding)
		SettingsList.Add("ScriptLineVal: --obsolete--") ' for compatibility
		SettingsList.Add("StrokeTauntVal: " & ssh_StrokeTauntVal)
		SettingsList.Add("ThoughtTauntVal: --obsolete--") ' for compatibility
		SettingsList.Add("ModuleTauntVal: --obsolete--") ' for compatibility
		SettingsList.Add("FileText: " & ssh_FileText)
		SettingsList.Add("TempStrokeTauntVal: " & ssh_TempStrokeTauntVal)
		SettingsList.Add("TempFileText: " & ssh_TempFileText)
		SettingsList.Add("ModText: --obsolete--") ' for compatibility
		SettingsList.Add("TeaseTick: " & ssh_TeaseTick)
		SettingsList.Add("StrokeTauntCount: " & ssh_StrokeTauntCount)
		SettingsList.Add("TauntTextTotal: " & ssh_TauntTextTotal)
		'SettingsList.Add("TauntLines: " & TauntLines)
		SettingsList.Add("StrokeFilter: " & ssh_StrokeFilter)
		SettingsList.Add("ScriptTick: " & ssh_ScriptTick)
		SettingsList.Add("StringLength: " & ssh_StringLength)
		SettingsList.Add("FileGoto: " & ssh_FileGoto)
		SettingsList.Add("SkipGotoLine: " & ssh_SkipGotoLine)
		SettingsList.Add("HandleScriptText: --obsolete--") ' for compatibility
		SettingsList.Add("ChatString: " & ssh_ChatString)
		SettingsList.Add("DomTask: " & ssh_DomTask)
		SettingsList.Add("DomChat: " & ssh_DomChat)
		SettingsList.Add("TypeDelay: " & ssh_TypeDelay)
		SettingsList.Add("TempVal: " & ssh_TempVal)
		SettingsList.Add("NullResponse: " & ssh_NullResponse)
		SettingsList.Add("CleanFlag: --obsolete--") ' for compatibility
		SettingsList.Add("DebugAwarenessLine: --obsolete--") ' for compatibility
		SettingsList.Add("TagCount: " & ssh_TagCount)
		SettingsList.Add("LocalTagCount: " & ssh_LocalTagCount)
		SettingsList.Add("OrgasmResult: --obsolete--") ' for compatibility
		SettingsList.Add("BeggedOrgasmDecision: --obsolete--") ' for compatibility
		SettingsList.Add("TeaseOver: --obsolete--") ' for compatibility
		SettingsList.Add("TaskFile: " & ssh_TaskFile)
		SettingsList.Add("TaskText: " & ssh_TaskText)
		SettingsList.Add("TaskTextDir: " & ssh_TaskTextDir)
		SettingsList.Add("ResponseFile: " & ssh_ResponseFile)
		SettingsList.Add("ResponseLine: " & ssh_ResponseLine)
		SettingsList.Add("CBTCockActive: " & ssh_CBTCockActive)
		SettingsList.Add("CBTBallsActive: " & ssh_CBTBallsActive)
		SettingsList.Add("CBTCockFlag: " & ssh_CBTCockFlag)
		SettingsList.Add("CBTBallsFlag: " & ssh_CBTBallsFlag)
		SettingsList.Add("CBTBallsFirst: " & ssh_CBTBallsFirst)
		SettingsList.Add("CBTCockFirst: " & ssh_CBTCockFirst)
		SettingsList.Add("CBTBallsCount: " & ssh_CBTBallsCount)
		SettingsList.Add("CBTCockCount: " & ssh_CBTCockCount)
		SettingsList.Add("ThoughtCount: --obsolete--") ' for compatibility
		SettingsList.Add("GotoDommeLevel: " & ssh_GotoDommeLevel)
		SettingsList.Add("DommeMood: " & ssh_DommeMood)
		SettingsList.Add("AFK: " & ssh_AFK)
		SettingsList.Add("HypnoGen: " & ssh_HypnoGen)
		SettingsList.Add("Induction: " & ssh_Induction)
		SettingsList.Add("TempHypno: " & ssh_TempHypno)
		SettingsList.Add("DomColor: --obsolete--") ' for compatibility
		SettingsList.Add("SubColor: --obsolete--") ' for compatibility
		SettingsList.Add("StrokeCycle: --obsolete--") ' for compatibility
		SettingsList.Add("StrokeTick: " & ssh_StrokeTick)
		SettingsList.Add("StrokeTauntTick: " & ssh_StrokeTauntTick)
		SettingsList.Add("StrokePaceRight: --obsolete--") ' for compatibility
		SettingsList.Add("StrokePace: " & StrokePace)
		SettingsList.Add("AudibleTick: --obsolete--") ' for compatibility
		SettingsList.Add("StrokeTimeTotal: " & ssh_StrokeTimeTotal)
		SettingsList.Add("HoldEdgeTime: " & ssh_HoldEdgeTime)
		SettingsList.Add("HoldEdgeTimeTotal: " & ssh_HoldEdgeTimeTotal)
		SettingsList.Add("EdgeTauntInt: " & ssh_EdgeTauntInt)
		SettingsList.Add("DelayTick: " & ssh_DelayTick)
		SettingsList.Add("DelayFlag: --obsolete--") ' for compatibility
		SettingsList.Add("PreCleanString: --obsolete--") ' for compatibility
		SettingsList.Add("DomTypeCheck: " & ssh_DomTypeCheck)
		SettingsList.Add("TypeToggle: " & ssh_TypeToggle)
		SettingsList.Add("IsTyping: " & ssh_IsTyping)
		SettingsList.Add("SubWroteLast: " & ssh_SubWroteLast)
		SettingsList.Add("YesOrNo: " & ssh_YesOrNo)
		SettingsList.Add("GotoFlag: " & ssh_GotoFlag)
		SettingsList.Add("LoopAnswer: --obsolete--") ' for compatibility
		SettingsList.Add("CBT: " & ssh_CBT)
		SettingsList.Add("NoEdge: --obsolete--") ' for compatibility
		SettingsList.Add("RunningScript: " & ssh_RunningScript)
		SettingsList.Add("RePound: --obsolete--") ' for compatibility
		SettingsList.Add("BeforeTease: " & ssh_BeforeTease)
		SettingsList.Add("SubStroking: " & ssh_SubStroking)
		SettingsList.Add("SubEdging: " & ssh_SubEdging)
		SettingsList.Add("SubHoldingEdge: " & ssh_SubHoldingEdge)
		SettingsList.Add("SubCBT: --obsolete--") ' for compatibility
		SettingsList.Add("EndTease: " & ssh_EndTease)
		SettingsList.Add("ShowThought: --obsolete--") ' for compatibility
		SettingsList.Add("ShowEdgeThought: --obsolete--") ' for compatibility
		SettingsList.Add("ShowModule: " & ssh_ShowModule)
		SettingsList.Add("ModuleEnd: " & ssh_ModuleEnd)
		SettingsList.Add("DivideText: " & ssh_DivideText)
		SettingsList.Add("HoldEdgeTick: " & ssh_HoldEdgeTick)
		SettingsList.Add("HoldEdgeChance: " & ssh_HoldEdgeChance)
		SettingsList.Add("EdgeHold: " & ssh_EdgeHold)
		SettingsList.Add("EdgeNoHold: " & ssh_EdgeNoHold)
		SettingsList.Add("EdgeToRuin: " & ssh_EdgeToRuin)
		SettingsList.Add("EdgeToRuinSecret: " & ssh_EdgeToRuinSecret)
		SettingsList.Add("LongEdge: " & ssh_LongEdge)
		SettingsList.Add("AskedToGiveUp: " & ssh_AskedToGiveUp)
		SettingsList.Add("AskedToGiveUpSection: " & ssh_AskedToGiveUpSection)
		SettingsList.Add("SubGaveUp: " & ssh_SubGaveUp)
		SettingsList.Add("AskedToSpeedUp: " & ssh_AskedToSpeedUp)
		SettingsList.Add("AskedToSlowDown: " & ssh_AskedToSlowDown)
		SettingsList.Add("ThoughtEnd: " & ThoughtEnd)
		SettingsList.Add("VTLength: " & ssh_VTLength)
		SettingsList.Add("DommeVideo: " & ssh_DommeVideo)
		SettingsList.Add("VideoType: " & ssh_VideoType)
		SettingsList.Add("CensorshipGame: " & ssh_CensorshipGame)
		SettingsList.Add("CensorshipTick: " & ssh_CensorshipTick)
		SettingsList.Add("CensorDuration: " & ssh_CensorDuration)
		SettingsList.Add("AvoidTheEdgeGame: " & ssh_AvoidTheEdgeGame)
		SettingsList.Add("AvoidTheEdgeTick: " & ssh_AvoidTheEdgeTick)
		SettingsList.Add("AvoidTheEdgeTimerTick: " & ssh_AvoidTheEdgeTimerTick)
		SettingsList.Add("AvoidTheEdgeDuration: " & ssh_AvoidTheEdgeDuration)
		SettingsList.Add("AvoidTheEdgeStroking: " & ssh_AvoidTheEdgeStroking)
		SettingsList.Add("AtECountdown: " & ssh_AtECountdown)
		SettingsList.Add("VTPath: " & ssh_VTPath)
		SettingsList.Add("NoVideo: " & ssh_NoVideo)
		SettingsList.Add("NoSpecialVideo: " & ssh_NoSpecialVideo)
		SettingsList.Add("VideoCheck: " & ssh_VideoCheck)
		SettingsList.Add("VideoTease: " & ssh_VideoTease)
		SettingsList.Add("RLGLGame: " & ssh_RLGLGame)
		SettingsList.Add("RLGLStroking: " & ssh_RLGLStroking)
		SettingsList.Add("RLGLTick: " & ssh_RLGLTick)
		SettingsList.Add("RedLight: " & ssh_RedLight)
		SettingsList.Add("RLGLTauntTick: " & ssh_RLGLTauntTick)
		SettingsList.Add("RandomizerVideo: " & ssh_RandomizerVideo)
		SettingsList.Add("RandomizerVideoTease: " & ssh_RandomizerVideoTease)
		SettingsList.Add("ScriptVideoTease: " & ssh_ScriptVideoTease)
		SettingsList.Add("ScriptVideoTeaseFlag: " & ssh_ScriptVideoTeaseFlag)
		SettingsList.Add("VideoTauntTick: " & ssh_VideoTauntTick)
		SettingsList.Add("SlideshowLoaded: " & ssh_SlideshowLoaded)
		SettingsList.Add("RefreshVideoTotal: --obsolete--") ' for compatibility
		SettingsList.Add("GlitterImageAV: " & GlitterImageAV)
		SettingsList.Add("GlitterNCDomme: --obsolete--") ' for compatibility
		SettingsList.Add("GlitterNC1: --obsolete--") ' for compatibility
		SettingsList.Add("GlitterNC2: --obsolete--") ' for compatibility
		SettingsList.Add("GlitterNC3: --obsolete--") ' for compatibility
		SettingsList.Add("GlitterTempColor: " & GlitterTempColor)
		SettingsList.Add("UpdatesTick: " & ssh_UpdatesTick)
		SettingsList.Add("UpdatingPost: " & ssh_UpdatingPost)
		SettingsList.Add("UpdateStage: " & ssh_UpdateStage)
		SettingsList.Add("UpdateStageTick: " & ssh_UpdateStageTick)
		SettingsList.Add("StatusText: " & ssh_StatusText)
		SettingsList.Add("ContactNumber: " & ssh_ContactNumber)
		SettingsList.Add("ContactTick: " & ssh_ContactTick)
		SettingsList.Add("ContactFlag: " & ContactFlag)
		SettingsList.Add("StatusText1: " & ssh_StatusText1)
		SettingsList.Add("StatusText2: " & ssh_StatusText2)
		SettingsList.Add("StatusText3: " & ssh_StatusText3)
		SettingsList.Add("StatusChance1: " & ssh_StatusChance1)
		SettingsList.Add("StatusChance2: " & ssh_StatusChance2)
		SettingsList.Add("StatusChance3: " & ssh_StatusChance3)
		SettingsList.Add("Update1: " & ssh_Update1)
		SettingsList.Add("Update2: " & ssh_Update2)
		SettingsList.Add("Update3: " & ssh_Update3)
		SettingsList.Add("LastSuccessfulImage: --obsolete--") ' for compatibility
		SettingsList.Add("GetFolder: " & ssh_GetFolder)
		SettingsList.Add("FileCount: " & ssh_FileCount)
		SettingsList.Add("FileCountMax: " & ssh_FileCountMax)
		'SettingsList.Add("_ImageFileNames: " & _ImageFileNames)
		SettingsList.Add("_CurrentImage: " & ssh__CurrentImage)
		SettingsList.Add("WithTeaseImgDir: " & ssh_WithTeaseImgDir)
		SettingsList.Add("ApproveImage: " & ssh_ApproveImage)
		SettingsList.Add("WIExit: " & ssh_WIExit)
		'SettingsList.Add("RecentSlideshows: " & RecentSlideshows)
		SettingsList.Add("MainPictureImage: " & ssh_MainPictureImage)
		SettingsList.Add("DomPic: " & ssh_DomPic)
		SettingsList.Add("LockImage: " & ssh_LockImage)
		'SettingsList.Add("LocalTagImageList: " & LocalTagImageList)
		SettingsList.Add("Crazy: " & ssh_Crazy)
		SettingsList.Add("Vulgar: " & ssh_Vulgar)
		SettingsList.Add("Supremacist: " & ssh_Supremacist)
		SettingsList.Add("CockSize: " & ssh_CockSize)
		SettingsList.Add("TempDick: --obsolete--") ' for compatibility
		SettingsList.Add("PetName: " & ssh_PetName)
		SettingsList.Add("PetName2: --obsolete--") ' for compatibility
		SettingsList.Add("TauntText: " & ssh_TauntText)
		SettingsList.Add("ScriptCount: " & ssh_ScriptCount)
		SettingsList.Add("TempScriptCount: " & ssh_TempScriptCount)
		SettingsList.Add("TauntTextCount: " & ssh_TauntTextCount)
		SettingsList.Add("StartIndex: --obsolete--") ' for compatibility
		SettingsList.Add("EndIndex: --obsolete--") ' for compatibility
		SettingsList.Add("SlideshowTimerTick: " & ssh_SlideshowTimerTick)
		SettingsList.Add("ReadBlog: --obsolete--") ' for compatibility
		SettingsList.Add("ReadBlogRate: --obsolete--") ' for compatibility
		SettingsList.Add("SearchImageBlog:  --obsolete--") ' for compatibility
		SettingsList.Add("FoundString: --obsolete--") ' for compatibility
		SettingsList.Add("WebImage: " & ssh_WebImage)
		'SettingsList.Add("WebImageLines: " & WebImageLines)
		SettingsList.Add("WebImageLine: " & ssh_WebImageLine)
		SettingsList.Add("WebImageLineTotal: " & ssh_WebImageLineTotal)
		SettingsList.Add("WebImagePath: " & ssh_WebImagePath)
		SettingsList.Add("ImageUrlFilePath: --obsolete--") ' for compatibility
		SettingsList.Add("ImageUrlFileIndex: --obsolete--") ' for compatibility
		SettingsList.Add("ReaderString: --obsolete--") ' for compatibility
		SettingsList.Add("ReaderStringTotal:  --obsolete--") ' for compatibility
		SettingsList.Add("StrokePaceInt: --obsolete--") ' for compatibility 
		SettingsList.Add("LastScriptCountdown: " & ssh_LastScriptCountdown)
		SettingsList.Add("LastScript: " & ssh_LastScript)
		SettingsList.Add("JustShowedBlogImage: " & ssh_JustShowedBlogImage)
		SettingsList.Add("SaidHello: " & ssh_SaidHello)
		SettingsList.Add("StopMetronome: " & ssh_StopMetronome)
		SettingsList.Add("AvgEdgeStroking: " & ssh_AvgEdgeStroking)
		SettingsList.Add("AvgEdgeNoTouch: " & ssh_AvgEdgeNoTouch)
		SettingsList.Add("EdgeCountTick: " & ssh_EdgeCountTick)
		SettingsList.Add("AvgEdgeStrokingFlag: " & ssh_AvgEdgeStrokingFlag)
		SettingsList.Add("AvgEdgeCount: " & ssh_AvgEdgeCount)
		SettingsList.Add("AvgEdgeCountRest: " & ssh_AvgEdgeCountRest)
		SettingsList.Add("EdgeTickCheck: " & ssh_EdgeTickCheck)
		SettingsList.Add("EdgeNOT: " & ssh_EdgeNOT)
		SettingsList.Add("AlreadyStrokingEdge: " & ssh_AlreadyStrokingEdge)
		SettingsList.Add("WritingTaskLinesAmount: " & ssh_WritingTaskLinesAmount)
		SettingsList.Add("WritingTaskLinesWritten: " & ssh_WritingTaskLinesWritten)
		SettingsList.Add("WritingTaskLinesRemaining: " & ssh_WritingTaskLinesRemaining)
		SettingsList.Add("WritingTaskMistakesAllowed: " & ssh_WritingTaskMistakesAllowed)
		SettingsList.Add("WritingTaskMistakesMade: " & ssh_WritingTaskMistakesMade)
		SettingsList.Add("WritingTaskFlag: " & ssh_WritingTaskFlag)
		SettingsList.Add("FirstRound: " & ssh_FirstRound)
		SettingsList.Add("StartStrokingCount: " & ssh_StartStrokingCount)
		SettingsList.Add("TeaseJOI: " & ssh_TeaseJOI)
		SettingsList.Add("TeaseVideo: " & ssh_TeaseVideo)
		SettingsList.Add("TnAPath: --obsolete--") ' for compatibility
		'SettingsList.Add("TnAList: " & TnAList)
		'SettingsList.Add("BoobList: " & BoobList)
		'SettingsList.Add("AssList: " & AssList)
		SettingsList.Add("AssImage: " & ssh_AssImage)
		SettingsList.Add("BoobImage: " & ssh_BoobImage)
		SettingsList.Add("FoundTag: " & ssh_FoundTag)
		SettingsList.Add("TagGarment: " & ssh_TagGarment)
		SettingsList.Add("TagUnderwear: " & ssh_TagUnderwear)
		SettingsList.Add("TagTattoo: " & ssh_TagTattoo)
		SettingsList.Add("TagSexToy: " & ssh_TagSexToy)
		SettingsList.Add("TagFurniture: " & ssh_TagFurniture)
		SettingsList.Add("ImportKeyword: --obsolete--") ' for compatibility
		SettingsList.Add("BookmarkModule: " & ssh_BookmarkModule)
		SettingsList.Add("BookmarkModuleFile: " & ssh_BookmarkModuleFile)
		SettingsList.Add("BookmarkModuleLine: " & ssh_BookmarkModuleLine)
		SettingsList.Add("BookmarkLink: " & ssh_BookmarkLink)
		SettingsList.Add("BookmarkLinkFile: " & ssh_BookmarkLinkFile)
		SettingsList.Add("BookmarkLinkLine: " & ssh_BookmarkLinkLine)
		SettingsList.Add("WaitTick: " & ssh_WaitTick)
		SettingsList.Add("OrgasmDenied: " & ssh_OrgasmDenied)
		SettingsList.Add("OrgasmAllowed: " & ssh_OrgasmAllowed)
		SettingsList.Add("OrgasmRuined: " & ssh_OrgasmRuined)
		SettingsList.Add("StupidTick: " & StupidTick)
		SettingsList.Add("StupidFlag: " & StupidFlag)
		SettingsList.Add("CaloriesConsumed: " & ssh_CaloriesConsumed)
		SettingsList.Add("CaloriesGoal: " & ssh_CaloriesGoal)
		SettingsList.Add("GoldTokens: " & ssh_GoldTokens)
		SettingsList.Add("SilverTokens: " & ssh_SilverTokens)
		SettingsList.Add("BronzeTokens: " & ssh_BronzeTokens)
		SettingsList.Add("EdgeFound: " & ssh_EdgeFound)
		SettingsList.Add("OrgasmYesNo: " & ssh_OrgasmYesNo)
		SettingsList.Add("VTFlag: " & ssh_VTFlag)
		SettingsList.Add("DomPersonality: " & ssh_DomPersonality)
		'SettingsList.Add("UpdateList: " & UpdateList)
		SettingsList.Add("GlitterDocument: " & ssh_GlitterDocument)
		SettingsList.Add("CustomSlideshow: " & ssh_CustomSlideshow)
		SettingsList.Add("CustomSlideshowTick: " & ssh_CustomSlideshowTick)
		'SettingsList.Add("CustomSlideshowList: " & CustomSlideshowList)
		SettingsList.Add("ImageString: " & ssh_ImageString)
		SettingsList.Add("RapidFire: " & ssh_RapidFire)
		SettingsList.Add("GlitterTease: " & ssh_GlitterTease)
		SettingsList.Add("AddContactTick: " & ssh_AddContactTick)
		'SettingsList.Add("Contact1Pics: " & Contact1Pics)
		'SettingsList.Add("Contact2Pics: " & Contact2Pics)
		'SettingsList.Add("Contact3Pics: " & Contact3Pics)
		SettingsList.Add("Contact1PicsCount: " & ssh_Contact1PicsCount)
		SettingsList.Add("Contact2PicsCount: " & ssh_Contact2PicsCount)
		SettingsList.Add("Contact3PicsCount: " & ssh_Contact3PicsCount)
		SettingsList.Add("Group: " & ssh_Group)
		SettingsList.Add("CustomTask: " & ssh_CustomTask)
		SettingsList.Add("CustomTaskFirst: " & ssh_CustomTaskFirst)
		SettingsList.Add("CustomTaskText: " & ssh_CustomTaskText)
		SettingsList.Add("CustomTaskTextFirst: " & ssh_CustomTaskTextFirst)
		SettingsList.Add("CustomTaskActive: " & ssh_CustomTaskActive)
		SettingsList.Add("SubtitleCount: " & ssh_SubtitleCount)
		SettingsList.Add("VidFile: " & ssh_VidFile)

		SettingsList.Add("Timer1 Enabled: " & Timer1.Enabled)
		SettingsList.Add("SendTimerTimer Enabled: " & SendTimer.Enabled)
		SettingsList.Add("IsTypingTimer Enabled: " & IsTypingTimer.Enabled)
		SettingsList.Add("StrokeTimer Enabled: " & StrokeTimer.Enabled)
		SettingsList.Add("StrokeTauntTimer Enabled: " & StrokeTauntTimer.Enabled)
		SettingsList.Add("DelayTimer Enabled: " & DelayTimer.Enabled)
		SettingsList.Add("CensorshipTimer Enabled: " & CensorshipTimer.Enabled)
		SettingsList.Add("AudibleMetronome Enabled: " & AudibleMetronome.Enabled)
		SettingsList.Add("ContactTimer Enabled: " & ContactTimer.Enabled)
		SettingsList.Add("CustomeSlideshowTimer Enabled: " & CustomSlideshowTimer.Enabled)
		SettingsList.Add("RLGLTimer Enabled: " & RLGLTimer.Enabled)
		SettingsList.Add("StrokeTimeTotalTimer Enabled: " & StrokeTimeTotalTimer.Enabled)
		SettingsList.Add("EdgeCountTimer Enabled: " & EdgeCountTimer.Enabled)
		SettingsList.Add("TnASlides Enabled: " & TnASlides.Enabled)
		SettingsList.Add("SlideshowTimer Enabled: " & SlideshowTimer.Enabled)
		SettingsList.Add("WaitTimer Enabled: " & WaitTimer.Enabled)
		SettingsList.Add("StupidTimer Enabled: " & StupidTimer.Enabled)
		SettingsList.Add("VideoTauntTimer Enabled: " & VideoTauntTimer.Enabled)
		SettingsList.Add("RLGLTauntTimer Enabled: " & RLGLTauntTimer.Enabled)
		SettingsList.Add("AvoidTheEdgeTauntsTimer Enabled: " & AvoidTheEdgeTaunts.Enabled)
		SettingsList.Add("TeaseTimer Enabled: " & TeaseTimer.Enabled)
		SettingsList.Add("UpdatesTimer Enabled: " & UpdatesTimer.Enabled)
		SettingsList.Add("AvoidTheEdgeTimer Enabled: " & AvoidTheEdge.Enabled)
		SettingsList.Add("AvoidTheEdgeResumeTimer Enabled: " & AvoidTheEdgeResume.Enabled)
		SettingsList.Add("StrokePaceTimer Enabled: --obsolete--") ' for compatibility
		SettingsList.Add("EdgeTauntTimer Enabled: " & EdgeTauntTimer.Enabled)
		SettingsList.Add("HoldEdgeTimer Enabled: " & HoldEdgeTimer.Enabled)
		SettingsList.Add("HoldEdgeTauntTimer Enabled: " & HoldEdgeTauntTimer.Enabled)
		SettingsList.Add("Contact1Timer Enabled: " & Contact1Timer.Enabled)
		SettingsList.Add("Contact2Timer Enabled: " & Contact2Timer.Enabled)
		SettingsList.Add("Contact3Timer Enabled: " & Contact3Timer.Enabled)
		SettingsList.Add("UpdateStageTimer Enabled: " & UpdateStageTimer.Enabled)
		SettingsList.Add("WMPTimer Enabled: " & WMPTimer.Enabled)

		'SettingsList.Add("PlaylistFile: " & PlaylistFile)

		SettingsList.Add("Chat: " & ssh_Chat)

		If mainPictureBox.Visible = True Then
			SettingsList.Add("MainWindow: Image")
		Else
			SettingsList.Add("MainWindow: Video")
		End If

		SettingsList.Add("DomWMP URL: " & DomWMP.URL)
		SettingsList.Add("DomWMP Position: " & DomWMP.Ctlcontrols.currentPosition)
		SettingsList.Add("DomWMP PlayState: " & DomWMP.playState)

		SettingsList.Add("RiskyDeal: " & ssh_RiskyDeal)
		SettingsList.Add("RiskyEdges: " & ssh_RiskyEdges)
		SettingsList.Add("RiskyDelay: " & ssh_RiskyDelay)
		SettingsList.Add("FinalRiskyPick: " & ssh_FinalRiskyPick)

		SettingsList.Add("SysMes: " & ssh_SysMes)
		SettingsList.Add("EmoMes: " & ssh_EmoMes)

		SettingsList.Add("Contact1Edge: " & ssh_Contact1Edge)
		SettingsList.Add("Contact2Edge: " & ssh_Contact2Edge)
		SettingsList.Add("Contact3Edge: " & ssh_Contact3Edge)

		SettingsList.Add("Contact1Stroke: " & ssh_Contact1Stroke)
		SettingsList.Add("Contact2Stroke: " & ssh_Contact2Stroke)
		SettingsList.Add("Contact3Stroke: " & ssh_Contact3Stroke)

		SettingsList.Add("ReturnFileText: " & ssh_ReturnFileText)
		SettingsList.Add("ReturnStrokeTauntVal: " & ssh_ReturnStrokeTauntVal)
		SettingsList.Add("ReturnSubState: " & ssh_ReturnSubState)
		SettingsList.Add("ReturnFlag: " & ssh_ReturnFlag)

		SettingsList.Add("SessionEdges: " & ssh_SessionEdges)
		SettingsList.Add("WindowCheck: " & ssh_WindowCheck)
		SettingsList.Add("StrokeFaster: " & ssh_StrokeFaster)
		SettingsList.Add("StrokeFastest: " & ssh_StrokeFastest)
		SettingsList.Add("StrokeSlower: " & ssh_StrokeSlower)
		SettingsList.Add("StrokeSlowest: " & ssh_StrokeSlowest)

		SettingsList.Add("InputFlag: " & ssh_InputFlag)
		SettingsList.Add("InputString: " & ssh_InputString)
		SettingsList.Add("RapidCode: " & ssh_RapidCode)
		SettingsList.Add("CorrectedTypo: " & ssh_CorrectedTypo)
		SettingsList.Add("CorrectedWord: " & ssh_CorrectedWord)
		SettingsList.Add("DoNotDisturb: " & ssh_DoNotDisturb)
		SettingsList.Add("TypoSwitch: " & ssh_TypoSwitch)
		SettingsList.Add("TyposDisabled: " & ssh_TyposDisabled)
		SettingsList.Add("EdgeHoldSeconds: " & ssh_EdgeHoldSeconds)
		SettingsList.Add("EdgeHoldFlag: " & ssh_EdgeHoldFlag)
		SettingsList.Add("SlideshowInt: " & ssh_SlideshowInt)
		SettingsList.Add("JustShowedSlideshowImage: " & ssh_JustShowedSlideshowImage)
		SettingsList.Add("DeleteLocalImageFilePath: --obsolete--") ' for compatibility
		SettingsList.Add("RandomSlideshowCategory: " & ssh_RandomSlideshowCategory)
		SettingsList.Add("ResetFlag: " & ssh_ResetFlag)
		SettingsList.Add("DommeTags: " & ssh_DommeTags)
		SettingsList.Add("ThemeSettings: " & ssh_ThemeSettings)
		SettingsList.Add("InputIcon: " & ssh_InputIcon)
		SettingsList.Add("ApplyingTheme: " & ssh_ApplyingTheme)
		SettingsList.Add("AdjustingWindow: " & ssh_AdjustingWindow)
		SettingsList.Add("SplitContainerHeight: " & ssh_SplitContainerHeight)
		SettingsList.Add("DommeImageFound: " & ssh_DommeImageFound)
		SettingsList.Add("DommeImageListCheck: --obsolete--") ' for compatibility
		SettingsList.Add("LocalImageFound: " & ssh_LocalImageFound)
		SettingsList.Add("LocalImageListCheck: " & ssh_LocalImageListCheck)
		SettingsList.Add("CBTBothActive: " & ssh_CBTBothActive)
		SettingsList.Add("CBTBothFlag: " & ssh_CBTBothFlag)
		SettingsList.Add("CBTBothCount: " & ssh_CBTBothCount)
		SettingsList.Add("CBTBothFirst: " & ssh_CBTBothFirst)
		SettingsList.Add("MetroGet: --obsolete--") ' for compatibility
		SettingsList.Add("GeneralTime: " & ssh_GeneralTime)
		SettingsList.Add("NewDommeSlideshow: " & ssh_NewDommeSlideshow)
		SettingsList.Add("OriginalDommeSlideshow: " & ssh_OriginalDommeSlideshow)
		SettingsList.Add("TimeoutTick: " & ssh_TimeoutTick)
		SettingsList.Add("PBImage: --obsolete--") ' for compatibility 
		SettingsList.Add("DommeImageSTR: " & ssh_DommeImageSTR)
		SettingsList.Add("LocalImageSTR: " & ssh_LocalImageSTR)
		SettingsList.Add("ImageLocation: " & ssh_ImageLocation)



		' WMPLib.WMPPlayState.wmppsStopped)

		Dim SettingsString As String = ""

		For i As Integer = 0 To SettingsList.Count - 1
			SettingsString = SettingsString & SettingsList(i)
			If i <> SettingsList.Count - 1 Then SettingsString = SettingsString & Environment.NewLine
		Next

		Dim ResumeState As String
		Dim ResumePrefix As String

		If ssh_ResetFlag = False Then
			ResumeState = "SavedState.txt"
			ResumePrefix = "Sus"
		Else
			ResumeState = "ResetState.txt"
			ResumePrefix = "Res"
		End If

		My.Computer.FileSystem.WriteAllText(SettingsPath & ResumeState, SettingsString, False)

		If ssh_PlaylistFile.Count > 0 Then
			SettingsString = ""
			For i As Integer = 0 To ssh_PlaylistFile.Count - 1
				SettingsString = SettingsString & ssh_PlaylistFile(i)
				If i <> ssh_PlaylistFile.Count - 1 Then SettingsString = SettingsString & Environment.NewLine
			Next
			My.Computer.FileSystem.WriteAllText(SettingsPath & ResumePrefix & "PlayListFile.txt", SettingsString, False)
		Else
			If File.Exists(SettingsPath & ResumePrefix & "PlayListFile.txt") Then My.Computer.FileSystem.DeleteFile(SettingsPath & ResumePrefix & "PlayListFile.txt")
		End If

		If ssh_TauntLines.Count > 0 Then
			SettingsString = ""
			For i As Integer = 0 To ssh_TauntLines.Count - 1
				SettingsString = SettingsString & ssh_TauntLines(i)
				If i <> ssh_TauntLines.Count - 1 Then SettingsString = SettingsString & Environment.NewLine
			Next
			My.Computer.FileSystem.WriteAllText(SettingsPath & ResumePrefix & "TauntLines.txt", SettingsString, False)
		Else
			If File.Exists(SettingsPath & ResumePrefix & "TauntLines.txt") Then My.Computer.FileSystem.DeleteFile(SettingsPath & ResumePrefix & "TauntLines.txt")
		End If

		If ssh__ImageFileNames.Count > 0 Then
			SettingsString = ""
			For i As Integer = 0 To ssh__ImageFileNames.Count - 1
				SettingsString = SettingsString & ssh__ImageFileNames(i)
				If i <> ssh__ImageFileNames.Count - 1 Then SettingsString = SettingsString & Environment.NewLine
			Next
			My.Computer.FileSystem.WriteAllText(SettingsPath & ResumePrefix & "_ImageFileNames.txt", SettingsString, False)
		Else
			If File.Exists(SettingsPath & ResumePrefix & "_ImageFileNames.txt") Then My.Computer.FileSystem.DeleteFile(SettingsPath & ResumePrefix & "_ImageFileNames.txt")
		End If

		If ssh_RecentSlideshows.Count > 0 Then
			SettingsString = ""
			For i As Integer = 0 To ssh_RecentSlideshows.Count - 1
				SettingsString = SettingsString & ssh_RecentSlideshows(i)
				If i <> ssh_RecentSlideshows.Count - 1 Then SettingsString = SettingsString & Environment.NewLine
			Next
			My.Computer.FileSystem.WriteAllText(SettingsPath & ResumePrefix & "RecentSlideshows.txt", SettingsString, False)
		Else
			If File.Exists(SettingsPath & ResumePrefix & "RecentSlideshows.txt") Then My.Computer.FileSystem.DeleteFile(SettingsPath & ResumePrefix & "RecentSlideshows.txt")
		End If

		If ssh_LocalTagImageList.Count > 0 Then
			SettingsString = ""
			For i As Integer = 0 To ssh_LocalTagImageList.Count - 1
				SettingsString = SettingsString & ssh_LocalTagImageList(i)
				If i <> ssh_LocalTagImageList.Count - 1 Then SettingsString = SettingsString & Environment.NewLine
			Next
			My.Computer.FileSystem.WriteAllText(SettingsPath & ResumePrefix & "LocalTagImageList.txt", SettingsString, False)
		Else
			If File.Exists(SettingsPath & ResumePrefix & "LocalTagImageList.txt") Then My.Computer.FileSystem.DeleteFile(SettingsPath & ResumePrefix & "LocalTagImageList.txt")
		End If

		If ssh_WebImageLines.Count > 0 Then
			SettingsString = ""
			For i As Integer = 0 To ssh_WebImageLines.Count - 1
				SettingsString = SettingsString & ssh_WebImageLines(i)
				If i <> ssh_WebImageLines.Count - 1 Then SettingsString = SettingsString & Environment.NewLine
			Next
			My.Computer.FileSystem.WriteAllText(SettingsPath & ResumePrefix & "WebImageLines.txt", SettingsString, False)
		Else
			If File.Exists(SettingsPath & ResumePrefix & "WebImageLines.txt") Then My.Computer.FileSystem.DeleteFile(SettingsPath & ResumePrefix & "WebImageLines.txt")
		End If

		If ssh_TnAList.Count > 0 Then
			SettingsString = ""
			For i As Integer = 0 To ssh_TnAList.Count - 1
				SettingsString = SettingsString & ssh_TnAList(i)
				If i <> ssh_TnAList.Count - 1 Then SettingsString = SettingsString & Environment.NewLine
			Next
			My.Computer.FileSystem.WriteAllText(SettingsPath & ResumePrefix & "TnAList.txt", SettingsString, False)
		Else
			If File.Exists(SettingsPath & ResumePrefix & "TnAList.txt") Then My.Computer.FileSystem.DeleteFile(SettingsPath & ResumePrefix & "TnAList.txt")
		End If

		If ssh_BoobList.Count > 0 Then
			SettingsString = ""
			For i As Integer = 0 To ssh_BoobList.Count - 1
				SettingsString = SettingsString & ssh_BoobList(i)
				If i <> ssh_BoobList.Count - 1 Then SettingsString = SettingsString & Environment.NewLine
			Next
			My.Computer.FileSystem.WriteAllText(SettingsPath & ResumePrefix & "BoobList.txt", SettingsString, False)
		Else
			If File.Exists(SettingsPath & ResumePrefix & "BoobList.txt") Then My.Computer.FileSystem.DeleteFile(SettingsPath & ResumePrefix & "BoobList.txt")
		End If

		If ssh_AssList.Count > 0 Then
			SettingsString = ""
			For i As Integer = 0 To ssh_AssList.Count - 1
				SettingsString = SettingsString & ssh_AssList(i)
				If i <> ssh_AssList.Count - 1 Then SettingsString = SettingsString & Environment.NewLine
			Next
			My.Computer.FileSystem.WriteAllText(SettingsPath & ResumePrefix & "AssList.txt", SettingsString, False)
		Else
			If File.Exists(SettingsPath & ResumePrefix & "AssList.txt") Then My.Computer.FileSystem.DeleteFile(SettingsPath & ResumePrefix & "AssList.txt")
		End If

		If ssh_UpdateList.Count > 0 Then
			SettingsString = ""
			For i As Integer = 0 To ssh_UpdateList.Count - 1
				SettingsString = SettingsString & ssh_UpdateList(i)
				If i <> ssh_UpdateList.Count - 1 Then SettingsString = SettingsString & Environment.NewLine
			Next
			My.Computer.FileSystem.WriteAllText(SettingsPath & ResumePrefix & "UpdateList.txt", SettingsString, False)
		Else
			If File.Exists(SettingsPath & ResumePrefix & "UpdateList.txt") Then My.Computer.FileSystem.DeleteFile(SettingsPath & ResumePrefix & "UpdateList.txt")
		End If

		If ssh_CustomSlideshowList.Count > 0 Then
			SettingsString = ""
			For i As Integer = 0 To ssh_CustomSlideshowList.Count - 1
				SettingsString = SettingsString & ssh_CustomSlideshowList(i)
				If i <> ssh_CustomSlideshowList.Count - 1 Then SettingsString = SettingsString & Environment.NewLine
			Next
			My.Computer.FileSystem.WriteAllText(SettingsPath & ResumePrefix & "CustomSlideshowList.txt", SettingsString, False)
		Else
			If File.Exists(SettingsPath & ResumePrefix & "CustomSlideshowList.txt") Then My.Computer.FileSystem.DeleteFile(SettingsPath & ResumePrefix & "CustomSlideshowList.txt")
		End If

		If ssh_Contact1Pics.Count > 0 Then
			SettingsString = ""
			For i As Integer = 0 To ssh_Contact1Pics.Count - 1
				SettingsString = SettingsString & ssh_Contact1Pics(i)
				If i <> ssh_Contact1Pics.Count - 1 Then SettingsString = SettingsString & Environment.NewLine
			Next
			My.Computer.FileSystem.WriteAllText(SettingsPath & ResumePrefix & "Contact1Pics.txt", SettingsString, False)
		Else
			If File.Exists(SettingsPath & ResumePrefix & "Contact1Pics.txt") Then My.Computer.FileSystem.DeleteFile(SettingsPath & ResumePrefix & "Contact1Pics.txt")
		End If

		If ssh_Contact2Pics.Count > 0 Then
			SettingsString = ""
			For i As Integer = 0 To ssh_Contact2Pics.Count - 1
				SettingsString = SettingsString & ssh_Contact2Pics(i)
				If i <> ssh_Contact2Pics.Count - 1 Then SettingsString = SettingsString & Environment.NewLine
			Next
			My.Computer.FileSystem.WriteAllText(SettingsPath & ResumePrefix & "Contact2Pics.txt", SettingsString, False)
		Else
			If File.Exists(SettingsPath & ResumePrefix & "Contact2Pics.txt") Then My.Computer.FileSystem.DeleteFile(SettingsPath & ResumePrefix & "Contact2Pics.txt")
		End If

		If ssh_Contact3Pics.Count > 0 Then
			SettingsString = ""
			For i As Integer = 0 To ssh_Contact3Pics.Count - 1
				SettingsString = SettingsString & ssh_Contact3Pics(i)
				If i <> ssh_Contact3Pics.Count - 1 Then SettingsString = SettingsString & Environment.NewLine
			Next
			My.Computer.FileSystem.WriteAllText(SettingsPath & ResumePrefix & "Contact3Pics.txt", SettingsString, False)
		Else
			If File.Exists(SettingsPath & ResumePrefix & "Contact3Pics.txt") Then My.Computer.FileSystem.DeleteFile(SettingsPath & ResumePrefix & "Contact3Pics.txt")
		End If

		ssh_ResetFlag = False


	End Sub

	Public Sub ResumeSession()

		Dim SettingsPath As String = Application.StartupPath & "\System\"
		Dim SettingsList As New List(Of String)

		Dim ResumeState As String
		Dim ResumePrefix As String

		If ssh_ResetFlag = False Then
			ResumeState = "SavedState.txt"
			ResumePrefix = "Sus"
		Else
			ResumeState = "ResetState.txt"
			ResumePrefix = "Res"
		End If

		Try
			'Read all lines of the given file. 
			SettingsList = Txt2List(Application.StartupPath & "\System\" & ResumeState)
			'check if file was successful read.
			If SettingsList Is Nothing Then Throw New FileLoadException()
		Catch ex As Exception
			MessageBox.Show(Me, ResumeState & " could not be read!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Return
		End Try


		dompersonalitycombobox.Text = SettingsList(0).Replace("Personality: ", "")

		ssh_ScriptOperator = SettingsList(1).Replace("ScriptOperator: ", "")
		ssh_ScriptCompare = SettingsList(2).Replace("ScriptCompare: ", "")
		ssh_DomTyping = SettingsList(3).Replace("DomTyping: ", "")
		ssh_CheckYes = SettingsList(4).Replace("CheckYes: ", "")
		ssh_CheckNo = SettingsList(5).Replace("CheckNo: ", "")
		ssh_Playlist = SettingsList(6).Replace("Playlist: ", "")
		ssh_PlaylistCurrent = SettingsList(7).Replace("PlaylistCurrent: ", "")
		'SubInChastity = SettingsList(8).Replace("SubInChastity: ", "")
		FormLoading = SettingsList(9).Replace("FormLoading: ", "")
		'RandomDelay = SettingsList(10).Replace("RandomDelay: ", "")
		ssh_Responding = SettingsList(11).Replace("Responding: ", "")
		'ScriptLineVal = SettingsList(12).Replace("ScriptLineVal: ", "")
		ssh_StrokeTauntVal = SettingsList(13).Replace("StrokeTauntVal: ", "")
		'ThoughtTauntVal = SettingsList(14).Replace("ThoughtTauntVal: ", "")
		'ModuleTauntVal = SettingsList(15).Replace("ModuleTauntVal: ", "")
		ssh_FileText = SettingsList(16).Replace("FileText: ", "")
		ssh_TempStrokeTauntVal = SettingsList(17).Replace("TempStrokeTauntVal: ", "")
		ssh_TempFileText = SettingsList(18).Replace("TempFileText: ", "")
		'ModText = SettingsList(19).Replace("ModText: ", "")
		ssh_TeaseTick = SettingsList(20).Replace("TeaseTick: ", "")
		ssh_StrokeTauntCount = SettingsList(21).Replace("StrokeTauntCount: ", "")
		ssh_TauntTextTotal = SettingsList(22).Replace("TauntTextTotal: ", "")
		ssh_StrokeFilter = SettingsList(23).Replace("StrokeFilter: ", "")
		ssh_ScriptTick = SettingsList(24).Replace("ScriptTick: ", "")
		ssh_StringLength = SettingsList(25).Replace("StringLength: ", "")
		ssh_FileGoto = SettingsList(26).Replace("FileGoto: ", "")
		ssh_SkipGotoLine = SettingsList(27).Replace("SkipGotoLine: ", "")
		'HandleScriptText = SettingsList(28).Replace("HandleScriptText: ", "")
		ssh_ChatString = SettingsList(29).Replace("ChatString: ", "")
		ssh_DomTask = SettingsList(30).Replace("DomTask: ", "")
		ssh_DomChat = SettingsList(31).Replace("DomChat: ", "")
		ssh_TypeDelay = SettingsList(32).Replace("TypeDelay: ", "")
		ssh_TempVal = SettingsList(33).Replace("TempVal: ", "")
		ssh_NullResponse = SettingsList(34).Replace("NullResponse: ", "")
		'CleanFlag = SettingsList(35).Replace("CleanFlag: ", "")
		'DebugAwarenessLine = SettingsList(36).Replace("DebugAwarenessLine: ", "")
		ssh_TagCount = SettingsList(37).Replace("TagCount: ", "")
		ssh_LocalTagCount = SettingsList(38).Replace("LocalTagCount: ", "")
		'OrgasmResult = SettingsList(39).Replace("OrgasmResult: ", "")
		'BeggedOrgasmDecision = SettingsList(40).Replace("BeggedOrgasmDecision: ", "")
		'TeaseOver = SettingsList(41).Replace("TeaseOver: ", "")
		ssh_TaskFile = SettingsList(42).Replace("TaskFile: ", "")
		ssh_TaskText = SettingsList(43).Replace("TaskText: ", "")
		ssh_TaskTextDir = SettingsList(44).Replace("TaskTextDir: ", "")
		ssh_ResponseFile = SettingsList(45).Replace("ResponseFile: ", "")
		ssh_ResponseLine = SettingsList(46).Replace("ResponseLine: ", "")
		ssh_CBTCockActive = SettingsList(47).Replace("CBTCockActive: ", "")
		ssh_CBTBallsActive = SettingsList(48).Replace("CBTBallsActive: ", "")
		ssh_CBTCockFlag = SettingsList(49).Replace("CBTCockFlag: ", "")
		ssh_CBTBallsFlag = SettingsList(50).Replace("CBTBallsFlag: ", "")
		ssh_CBTBallsFirst = SettingsList(51).Replace("CBTBallsFirst: ", "")
		ssh_CBTCockFirst = SettingsList(52).Replace("CBTCockFirst: ", "")
		ssh_CBTBallsCount = SettingsList(53).Replace("CBTBallsCount: ", "")
		ssh_CBTCockCount = SettingsList(54).Replace("CBTCockCount: ", "")
		'ThoughtCount = SettingsList(55).Replace("ThoughtCount: ", "")
		ssh_GotoDommeLevel = SettingsList(56).Replace("GotoDommeLevel: ", "")
		ssh_DommeMood = SettingsList(57).Replace("DommeMood: ", "")
		ssh_AFK = SettingsList(58).Replace("AFK: ", "")
		ssh_HypnoGen = SettingsList(59).Replace("HypnoGen: ", "")
		ssh_Induction = SettingsList(60).Replace("Induction: ", "")
		ssh_TempHypno = SettingsList(61).Replace("TempHypno: ", "")
		'DomColor = SettingsList(62).Replace("DomColor: ", "")
		'SubColor = SettingsList(63).Replace("SubColor: ", "")
		'StrokeCycle = SettingsList(64).Replace("StrokeCycle: ", "")
		ssh_StrokeTick = SettingsList(65).Replace("StrokeTick: ", "")
		ssh_StrokeTauntTick = SettingsList(66).Replace("StrokeTauntTick: ", "")
		'StrokePaceRight = SettingsList(67).Replace("StrokePaceRight: ", "")
		StrokePace = SettingsList(68).Replace("StrokePace: ", "")
		'AudibleTick = SettingsList(69).Replace("AudibleTick: ", "")
		ssh_StrokeTimeTotal = SettingsList(70).Replace("StrokeTimeTotal: ", "")
		ssh_HoldEdgeTime = SettingsList(71).Replace("HoldEdgeTime: ", "")
		ssh_HoldEdgeTimeTotal = SettingsList(72).Replace("HoldEdgeTimeTotal: ", "")
		ssh_EdgeTauntInt = SettingsList(73).Replace("EdgeTauntInt: ", "")
		ssh_DelayTick = SettingsList(74).Replace("DelayTick: ", "")
		'DelayFlag = SettingsList(75).Replace("DelayFlag: ", "")
		'PreCleanString = SettingsList(76).Replace("PreCleanString: ", "")
		ssh_DomTypeCheck = SettingsList(77).Replace("DomTypeCheck: ", "")
		ssh_TypeToggle = SettingsList(78).Replace("TypeToggle: ", "")
		ssh_IsTyping = SettingsList(79).Replace("IsTyping: ", "")
		ssh_SubWroteLast = SettingsList(80).Replace("SubWroteLast: ", "")
		ssh_YesOrNo = SettingsList(81).Replace("YesOrNo: ", "")
		ssh_GotoFlag = SettingsList(82).Replace("GotoFlag: ", "")
		'LoopAnswer = SettingsList(83).Replace("LoopAnswer: ", "")
		ssh_CBT = SettingsList(84).Replace("CBT: ", "")
		'NoEdge = SettingsList(85).Replace("NoEdge: ", "")
		ssh_RunningScript = SettingsList(86).Replace("RunningScript: ", "")
		'RePound = SettingsList(87).Replace("RePound: ", "")
		ssh_BeforeTease = SettingsList(88).Replace("BeforeTease: ", "")
		ssh_SubStroking = SettingsList(89).Replace("SubStroking: ", "")
		ssh_SubEdging = SettingsList(90).Replace("SubEdging: ", "")
		ssh_SubHoldingEdge = SettingsList(91).Replace("SubHoldingEdge: ", "")
		'SubCBT = SettingsList(92).Replace("SubCBT: ", "")
		ssh_EndTease = SettingsList(93).Replace("EndTease: ", "")
		'ShowThought = SettingsList(94).Replace("ShowThought: ", "")
		'ShowEdgeThought = SettingsList(95).Replace("ShowEdgeThought: ", "")
		ssh_ShowModule = SettingsList(96).Replace("ShowModule: ", "")
		ssh_ModuleEnd = SettingsList(97).Replace("ModuleEnd: ", "")
		ssh_DivideText = SettingsList(98).Replace("DivideText: ", "")
		ssh_HoldEdgeTick = SettingsList(99).Replace("HoldEdgeTick: ", "")
		ssh_HoldEdgeChance = SettingsList(100).Replace("HoldEdgeChance: ", "")
		ssh_EdgeHold = SettingsList(101).Replace("EdgeHold: ", "")
		ssh_EdgeNoHold = SettingsList(102).Replace("EdgeNoHold: ", "")
		ssh_EdgeToRuin = SettingsList(103).Replace("EdgeToRuin: ", "")
		ssh_EdgeToRuinSecret = SettingsList(104).Replace("EdgeToRuinSecret: ", "")
		ssh_LongEdge = SettingsList(105).Replace("LongEdge: ", "")
		ssh_AskedToGiveUp = SettingsList(106).Replace("AskedToGiveUp: ", "")
		ssh_AskedToGiveUpSection = SettingsList(107).Replace("AskedToGiveUpSection: ", "")
		ssh_SubGaveUp = SettingsList(108).Replace("SubGaveUp: ", "")
		ssh_AskedToSpeedUp = SettingsList(109).Replace("AskedToSpeedUp: ", "")
		ssh_AskedToSlowDown = SettingsList(110).Replace("AskedToSlowDown: ", "")
		ThoughtEnd = SettingsList(111).Replace("ThoughtEnd: ", "")
		ssh_VTLength = SettingsList(112).Replace("VTLength: ", "")
		ssh_DommeVideo = SettingsList(113).Replace("DommeVideo: ", "")
		ssh_VideoType = SettingsList(114).Replace("VideoType: ", "")
		ssh_CensorshipGame = SettingsList(115).Replace("CensorshipGame: ", "")
		ssh_CensorshipTick = SettingsList(116).Replace("CensorshipTick: ", "")
		ssh_CensorDuration = SettingsList(117).Replace("CensorDuration: ", "")
		ssh_AvoidTheEdgeGame = SettingsList(118).Replace("AvoidTheEdgeGame: ", "")
		ssh_AvoidTheEdgeTick = SettingsList(119).Replace("AvoidTheEdgeTick: ", "")
		ssh_AvoidTheEdgeTimerTick = SettingsList(120).Replace("AvoidTheEdgeTimerTick: ", "")
		ssh_AvoidTheEdgeDuration = SettingsList(121).Replace("AvoidTheEdgeDuration: ", "")
		ssh_AvoidTheEdgeStroking = SettingsList(122).Replace("AvoidTheEdgeStroking: ", "")
		ssh_AtECountdown = SettingsList(123).Replace("AtECountdown: ", "")
		ssh_VTPath = SettingsList(124).Replace("VTPath: ", "")
		ssh_NoVideo = SettingsList(125).Replace("NoVideo: ", "")
		ssh_NoSpecialVideo = SettingsList(126).Replace("NoSpecialVideo: ", "")
		ssh_VideoCheck = SettingsList(127).Replace("VideoCheck: ", "")
		ssh_VideoTease = SettingsList(128).Replace("VideoTease: ", "")
		ssh_RLGLGame = SettingsList(129).Replace("RLGLGame: ", "")
		ssh_RLGLStroking = SettingsList(130).Replace("RLGLStroking: ", "")
		ssh_RLGLTick = SettingsList(131).Replace("RLGLTick: ", "")
		ssh_RedLight = SettingsList(132).Replace("RedLight: ", "")
		ssh_RLGLTauntTick = SettingsList(133).Replace("RLGLTauntTick: ", "")
		ssh_RandomizerVideo = SettingsList(134).Replace("RandomizerVideo: ", "")
		ssh_RandomizerVideoTease = SettingsList(135).Replace("RandomizerVideoTease: ", "")
		ssh_ScriptVideoTease = SettingsList(136).Replace("ScriptVideoTease: ", "")
		ssh_ScriptVideoTeaseFlag = SettingsList(137).Replace("ScriptVideoTeaseFlag: ", "")
		ssh_VideoTauntTick = SettingsList(138).Replace("VideoTauntTick: ", "")
		ssh_SlideshowLoaded = SettingsList(139).Replace("SlideshowLoaded: ", "")
		'RefreshVideoTotal = SettingsList(140).Replace("RefreshVideoTotal: ", "")
		GlitterImageAV = SettingsList(141).Replace("GlitterImageAV: ", "")

		GlitterTempColor = SettingsList(146).Replace("GlitterTempColor: ", "")
		ssh_UpdatesTick = SettingsList(147).Replace("UpdatesTick: ", "")
		ssh_UpdatingPost = SettingsList(148).Replace("UpdatingPost: ", "")
		ssh_UpdateStage = SettingsList(149).Replace("UpdateStage: ", "")
		ssh_UpdateStageTick = SettingsList(150).Replace("UpdateStageTick: ", "")
		ssh_StatusText = SettingsList(151).Replace("StatusText: ", "")
		ssh_ContactNumber = SettingsList(152).Replace("ContactNumber: ", "")
		ssh_ContactTick = SettingsList(153).Replace("ContactTick: ", "")
		ContactFlag = SettingsList(154).Replace("ContactFlag: ", "")
		ssh_StatusText1 = SettingsList(155).Replace("StatusText1: ", "")
		ssh_StatusText2 = SettingsList(156).Replace("StatusText2: ", "")
		ssh_StatusText3 = SettingsList(157).Replace("StatusText3: ", "")
		ssh_StatusChance1 = SettingsList(158).Replace("StatusChance1: ", "")
		ssh_StatusChance2 = SettingsList(159).Replace("StatusChance2: ", "")
		ssh_StatusChance3 = SettingsList(160).Replace("StatusChance3: ", "")
		ssh_Update1 = SettingsList(161).Replace("Update1: ", "")
		ssh_Update2 = SettingsList(162).Replace("Update2: ", "")
		ssh_Update3 = SettingsList(163).Replace("Update3: ", "")
		'LastSuccessfulImage = SettingsList(164).Replace("LastSuccessfulImage: ", "")
		ssh_GetFolder = SettingsList(165).Replace("GetFolder: ", "")
		ssh_FileCount = SettingsList(166).Replace("FileCount: ", "")
		ssh_FileCountMax = SettingsList(167).Replace("FileCountMax: ", "")
		ssh__CurrentImage = SettingsList(168).Replace("_CurrentImage: ", "")
		ssh_WithTeaseImgDir = SettingsList(169).Replace("WithTeaseImgDir: ", "")
		ssh_ApproveImage = SettingsList(170).Replace("ApproveImage: ", "")
		ssh_WIExit = SettingsList(171).Replace("WIExit: ", "")
		ssh_MainPictureImage = SettingsList(172).Replace("MainPictureImage: ", "")
		ssh_DomPic = SettingsList(173).Replace("DomPic: ", "")
		ssh_LockImage = SettingsList(174).Replace("LockImage: ", "")
		ssh_Crazy = SettingsList(175).Replace("Crazy: ", "")
		ssh_Vulgar = SettingsList(176).Replace("Vulgar: ", "")
		ssh_Supremacist = SettingsList(177).Replace("Supremacist: ", "")
		ssh_CockSize = SettingsList(178).Replace("CockSize: ", "")
		'TempDick = SettingsList(179).Replace("TempDick: ", "")
		ssh_PetName = SettingsList(180).Replace("PetName: ", "")
		'PetName2 = SettingsList(181).Replace("PetName2: ", "")
		ssh_TauntText = SettingsList(182).Replace("TauntText: ", "")
		ssh_ScriptCount = SettingsList(183).Replace("ScriptCount: ", "")
		ssh_TempScriptCount = SettingsList(184).Replace("TempScriptCount: ", "")
		ssh_TauntTextCount = SettingsList(185).Replace("TauntTextCount: ", "")
		'StartIndex = SettingsList(186).Replace("StartIndex: ", "")
		'EndIndex = SettingsList(187).Replace("EndIndex: ", "")
		ssh_SlideshowTimerTick = SettingsList(188).Replace("SlideshowTimerTick: ", "")
		'ReadBlog = SettingsList(189).Replace("ReadBlog: ", "")
		'ReadBlogRate = SettingsList(190).Replace("ReadBlogRate: ", "")
		'SearchImageBlog = SettingsList(191).Replace("SearchImageBlog: ", "")
		'FoundString = SettingsList(192).Replace("FoundString: ", "")
		ssh_WebImage = SettingsList(193).Replace("WebImage: ", "")
		ssh_WebImageLine = SettingsList(194).Replace("WebImageLine: ", "")
		ssh_WebImageLineTotal = SettingsList(195).Replace("WebImageLineTotal: ", "")
		ssh_WebImagePath = SettingsList(196).Replace("WebImagePath: ", "")
		'ImageUrlFilePath = SettingsList(197).Replace("ImageUrlFilePath: ", "")
		'ImageUrlFileIndex = SettingsList(198).Replace("ImageUrlFileIndex: ", "")
		'ReaderString = SettingsList(199).Replace("ReaderString: ", "")
		'ReaderStringTotal = SettingsList(200).Replace("ReaderStringTotal: ", "")
		'StrokePaceInt = SettingsList(201).Replace("StrokePaceInt: ", "")
		ssh_LastScriptCountdown = SettingsList(202).Replace("LastScriptCountdown: ", "")
		ssh_LastScript = SettingsList(203).Replace("LastScript: ", "")
		ssh_JustShowedBlogImage = SettingsList(204).Replace("JustShowedBlogImage: ", "")
		ssh_SaidHello = SettingsList(205).Replace("SaidHello: ", "")
		ssh_StopMetronome = SettingsList(206).Replace("StopMetronome: ", "")
		ssh_AvgEdgeStroking = SettingsList(207).Replace("AvgEdgeStroking: ", "")
		ssh_AvgEdgeNoTouch = SettingsList(208).Replace("AvgEdgeNoTouch: ", "")
		ssh_EdgeCountTick = SettingsList(209).Replace("EdgeCountTick: ", "")
		ssh_AvgEdgeStrokingFlag = SettingsList(210).Replace("AvgEdgeStrokingFlag: ", "")
		ssh_AvgEdgeCount = SettingsList(211).Replace("AvgEdgeCount: ", "")
		ssh_AvgEdgeCountRest = SettingsList(212).Replace("AvgEdgeCountRest: ", "")
		ssh_EdgeTickCheck = SettingsList(213).Replace("EdgeTickCheck: ", "")
		ssh_EdgeNOT = SettingsList(214).Replace("EdgeNOT: ", "")
		ssh_AlreadyStrokingEdge = SettingsList(215).Replace("AlreadyStrokingEdge: ", "")
		ssh_WritingTaskLinesAmount = SettingsList(216).Replace("WritingTaskLinesAmount: ", "")
		ssh_WritingTaskLinesWritten = SettingsList(217).Replace("WritingTaskLinesWritten: ", "")
		ssh_WritingTaskLinesRemaining = SettingsList(218).Replace("WritingTaskLinesRemaining: ", "")
		ssh_WritingTaskMistakesAllowed = SettingsList(219).Replace("WritingTaskMistakesAllowed: ", "")
		ssh_WritingTaskMistakesMade = SettingsList(220).Replace("WritingTaskMistakesMade: ", "")
		ssh_WritingTaskFlag = SettingsList(221).Replace("WritingTaskFlag: ", "")
		ssh_FirstRound = SettingsList(222).Replace("FirstRound: ", "")
		ssh_StartStrokingCount = SettingsList(223).Replace("StartStrokingCount: ", "")
		ssh_TeaseJOI = SettingsList(224).Replace("TeaseJOI: ", "")
		ssh_TeaseVideo = SettingsList(225).Replace("TeaseVideo: ", "")
		'TnAPath = SettingsList(226).Replace("TnAPath: ", "") 
		ssh_AssImage = SettingsList(227).Replace("AssImage: ", "")
		ssh_BoobImage = SettingsList(228).Replace("BoobImage: ", "")
		ssh_FoundTag = SettingsList(229).Replace("FoundTag: ", "")
		ssh_TagGarment = SettingsList(230).Replace("TagGarment: ", "")
		ssh_TagUnderwear = SettingsList(231).Replace("TagUnderwear: ", "")
		ssh_TagTattoo = SettingsList(232).Replace("TagTattoo: ", "")
		ssh_TagSexToy = SettingsList(233).Replace("TagSexToy: ", "")
		ssh_TagFurniture = SettingsList(234).Replace("TagFurniture: ", "")
		'ImportKeyword = SettingsList(235).Replace("ImportKeyword: ", "")
		ssh_BookmarkModule = SettingsList(236).Replace("BookmarkModule: ", "")
		ssh_BookmarkModuleFile = SettingsList(237).Replace("BookmarkModuleFile: ", "")
		ssh_BookmarkModuleLine = SettingsList(238).Replace("BookmarkModuleLine: ", "")
		ssh_BookmarkLink = SettingsList(239).Replace("BookmarkLink: ", "")
		ssh_BookmarkLinkFile = SettingsList(240).Replace("BookmarkLinkFile: ", "")
		ssh_BookmarkLinkLine = SettingsList(241).Replace("BookmarkLinkLine: ", "")
		ssh_WaitTick = SettingsList(242).Replace("WaitTick: ", "")
		ssh_OrgasmDenied = SettingsList(243).Replace("OrgasmDenied: ", "")
		ssh_OrgasmAllowed = SettingsList(244).Replace("OrgasmAllowed: ", "")
		ssh_OrgasmRuined = SettingsList(245).Replace("OrgasmRuined: ", "")
		StupidTick = SettingsList(246).Replace("StupidTick: ", "")
		StupidFlag = SettingsList(247).Replace("StupidFlag: ", "")
		ssh_CaloriesConsumed = SettingsList(248).Replace("CaloriesConsumed: ", "")
		ssh_CaloriesGoal = SettingsList(249).Replace("CaloriesGoal: ", "")
		ssh_GoldTokens = SettingsList(250).Replace("GoldTokens: ", "")
		ssh_SilverTokens = SettingsList(251).Replace("SilverTokens: ", "")
		ssh_BronzeTokens = SettingsList(252).Replace("BronzeTokens: ", "")
		ssh_EdgeFound = SettingsList(253).Replace("EdgeFound: ", "")
		ssh_OrgasmYesNo = SettingsList(254).Replace("OrgasmYesNo: ", "")
		ssh_VTFlag = SettingsList(255).Replace("VTFlag: ", "")
		ssh_DomPersonality = SettingsList(256).Replace("DomPersonality: ", "")
		ssh_GlitterDocument = SettingsList(257).Replace("GlitterDocument: ", "")
		ssh_CustomSlideshow = SettingsList(258).Replace("CustomSlideshow: ", "")
		ssh_CustomSlideshowTick = SettingsList(259).Replace("CustomSlideshowTick: ", "")
		ssh_ImageString = SettingsList(260).Replace("ImageString: ", "")
		ssh_RapidFire = SettingsList(261).Replace("RapidFire: ", "")
		ssh_GlitterTease = SettingsList(262).Replace("GlitterTease: ", "")
		ssh_AddContactTick = SettingsList(263).Replace("AddContactTick: ", "")
		ssh_Contact1PicsCount = SettingsList(264).Replace("Contact1PicsCount: ", "")
		ssh_Contact2PicsCount = SettingsList(265).Replace("Contact2PicsCount: ", "")
		ssh_Contact3PicsCount = SettingsList(266).Replace("Contact3PicsCount: ", "")
		ssh_Group = SettingsList(267).Replace("Group: ", "")
		ssh_CustomTask = SettingsList(268).Replace("CustomTask: ", "")
		ssh_CustomTaskFirst = SettingsList(269).Replace("CustomTaskFirst: ", "")
		ssh_CustomTaskText = SettingsList(270).Replace("CustomTaskText: ", "")
		ssh_CustomTaskTextFirst = SettingsList(271).Replace("CustomTaskTextFirst: ", "")
		ssh_CustomTaskActive = SettingsList(272).Replace("CustomTaskActive: ", "")
		ssh_SubtitleCount = SettingsList(273).Replace("SubtitleCount: ", "")
		ssh_VidFile = SettingsList(274).Replace("VidFile: ", "")

		Timer1.Enabled = SettingsList(275).Replace("Timer1 Enabled: ", "")
		SendTimer.Enabled = SettingsList(276).Replace("SendTimerTimer Enabled: ", "")
		IsTypingTimer.Enabled = SettingsList(277).Replace("IsTypingTimer Enabled: ", "")
		StrokeTimer.Enabled = SettingsList(278).Replace("StrokeTimer Enabled: ", "")
		StrokeTauntTimer.Enabled = SettingsList(279).Replace("StrokeTauntTimer Enabled: ", "")
		DelayTimer.Enabled = SettingsList(280).Replace("DelayTimer Enabled: ", "")
		CensorshipTimer.Enabled = SettingsList(281).Replace("CensorshipTimer Enabled: ", "")
		AudibleMetronome.Enabled = SettingsList(282).Replace("AudibleMetronome Enabled: ", "")
		ContactTimer.Enabled = SettingsList(283).Replace("ContactTimer Enabled: ", "")
		CustomSlideshowTimer.Enabled = SettingsList(284).Replace("CustomeSlideshowTimer Enabled: ", "")
		RLGLTimer.Enabled = SettingsList(285).Replace("RLGLTimer Enabled: ", "")
		StrokeTimeTotalTimer.Enabled = SettingsList(286).Replace("StrokeTimeTotalTimer Enabled: ", "")
		EdgeCountTimer.Enabled = SettingsList(287).Replace("EdgeCountTimer Enabled: ", "")
		TnASlides.Enabled = SettingsList(288).Replace("TnASlides Enabled: ", "")
		SlideshowTimer.Enabled = SettingsList(289).Replace("SlideshowTimer Enabled: ", "")
		WaitTimer.Enabled = SettingsList(290).Replace("WaitTimer Enabled: ", "")
		StupidTimer.Enabled = SettingsList(291).Replace("StupidTimer Enabled: ", "")
		VideoTauntTimer.Enabled = SettingsList(292).Replace("VideoTauntTimer Enabled: ", "")
		RLGLTauntTimer.Enabled = SettingsList(293).Replace("RLGLTauntTimer Enabled: ", "")
		AvoidTheEdgeTaunts.Enabled = SettingsList(294).Replace("AvoidTheEdgeTauntsTimer Enabled: ", "")
		TeaseTimer.Enabled = SettingsList(295).Replace("TeaseTimer Enabled: ", "")
		UpdatesTimer.Enabled = SettingsList(296).Replace("UpdatesTimer Enabled: ", "")
		AvoidTheEdge.Enabled = SettingsList(297).Replace("AvoidTheEdgeTimer Enabled: ", "")
		AvoidTheEdgeResume.Enabled = SettingsList(298).Replace("AvoidTheEdgeResumeTimer Enabled: ", "")
		'StrokePaceTimer.Enabled = SettingsList(299).Replace("StrokePaceTimer Enabled: ", "")
		EdgeTauntTimer.Enabled = SettingsList(300).Replace("EdgeTauntTimer Enabled: ", "")
		HoldEdgeTimer.Enabled = SettingsList(301).Replace("HoldEdgeTimer Enabled: ", "")
		HoldEdgeTauntTimer.Enabled = SettingsList(302).Replace("HoldEdgeTauntTimer Enabled: ", "")
		Contact1Timer.Enabled = SettingsList(303).Replace("Contact1Timer Enabled: ", "")
		Contact2Timer.Enabled = SettingsList(304).Replace("Contact2Timer Enabled: ", "")
		Contact3Timer.Enabled = SettingsList(305).Replace("Contact3Timer Enabled: ", "")
		UpdateStageTimer.Enabled = SettingsList(306).Replace("UpdateStageTimer Enabled: ", "")
		WMPTimer.Enabled = SettingsList(307).Replace("WMPTimer Enabled: ", "")
		ssh_Chat = SettingsList(308).Replace("Chat: ", "")

		If SettingsList(309).Replace("MainWindow: ", "") = "Image" Then
			mainPictureBox.Visible = True
		Else
			DomWMP.Visible = True
			DomWMP.stretchToFit = True
			mainPictureBox.Visible = False
			DomWMP.URL = SettingsList(310).Replace("DomWMP URL: ", "")
			DomWMP.Ctlcontrols.currentPosition = SettingsList(311).Replace("DomWMP Position: ", "")
			If SettingsList(312).Replace("DomWMP PlayState: ", "") = "1" Then DomWMP.Ctlcontrols.stop()
			If SettingsList(312).Replace("DomWMP PlayState: ", "") = "2" Then DomWMP.Ctlcontrols.pause()
			If SettingsList(312).Replace("DomWMP PlayState: ", "") = "3" Then DomWMP.Ctlcontrols.play()
		End If


		ssh_RiskyDeal = SettingsList(313).Replace("RiskyDeal: ", "")
		ssh_RiskyEdges = SettingsList(314).Replace("RiskyEdges: ", "")
		ssh_RiskyDelay = SettingsList(315).Replace("RiskyDelay: ", "")
		ssh_FinalRiskyPick = SettingsList(316).Replace("FinalRiskyPick: ", "")
		ssh_SysMes = SettingsList(317).Replace("SysMes: ", "")
		ssh_EmoMes = SettingsList(318).Replace("EmoMes: ", "")
		ssh_Contact1Edge = SettingsList(319).Replace("Contact1Edge: ", "")
		ssh_Contact2Edge = SettingsList(320).Replace("Contact2Edge: ", "")
		ssh_Contact3Edge = SettingsList(321).Replace("Contact3Edge: ", "")
		ssh_Contact1Stroke = SettingsList(322).Replace("Contact1Stroke: ", "")
		ssh_Contact2Stroke = SettingsList(323).Replace("Contact2Stroke: ", "")
		ssh_Contact3Stroke = SettingsList(324).Replace("Contact3Stroke: ", "")
		ssh_ReturnFileText = SettingsList(325).Replace("ReturnFileText: ", "")
		ssh_ReturnStrokeTauntVal = SettingsList(326).Replace("ReturnStrokeTauntVal: ", "")
		ssh_ReturnSubState = SettingsList(327).Replace("ReturnSubState: ", "")
		ssh_ReturnFlag = SettingsList(328).Replace("ReturnFlag: ", "")

		ssh_SessionEdges = SettingsList(329).Replace("SessionEdges: ", "")
		ssh_WindowCheck = SettingsList(330).Replace("WindowCheck: ", "")
		ssh_StrokeFaster = SettingsList(331).Replace("StrokeFaster: ", "")
		ssh_StrokeFastest = SettingsList(332).Replace("StrokeFastest: ", "")
		ssh_StrokeSlower = SettingsList(333).Replace("StrokeSlower: ", "")
		ssh_StrokeSlowest = SettingsList(334).Replace("StrokeSlowest: ", "")


		ssh_InputFlag = SettingsList(335).Replace("InputFlag: ", "")
		ssh_InputString = SettingsList(336).Replace("InputString: ", "")
		ssh_RapidCode = SettingsList(337).Replace("RapidCode: ", "")
		ssh_CorrectedTypo = SettingsList(338).Replace("CorrectedTypo: ", "")
		ssh_CorrectedWord = SettingsList(339).Replace("CorrectedWord: ", "")
		ssh_DoNotDisturb = SettingsList(340).Replace("DoNotDisturb: ", "")
		ssh_TypoSwitch = SettingsList(341).Replace("TypoSwitch: ", "")
		ssh_TyposDisabled = SettingsList(342).Replace("TyposDisabled: ", "")
		ssh_EdgeHoldSeconds = SettingsList(343).Replace("EdgeHoldSeconds: ", "")
		ssh_EdgeHoldFlag = SettingsList(344).Replace("EdgeHoldFlag: ", "")
		ssh_SlideshowInt = SettingsList(345).Replace("SlideshowInt: ", "")
		ssh_JustShowedSlideshowImage = SettingsList(346).Replace("JustShowedSlideshowImage: ", "")
		'DeleteLocalImageFilePath = SettingsList(347).Replace("DeleteLocalImageFilePath: ", "")
		ssh_RandomSlideshowCategory = SettingsList(348).Replace("RandomSlideshowCategory: ", "")
		ssh_ResetFlag = SettingsList(349).Replace("ResetFlag: ", "")
		ssh_DommeTags = SettingsList(350).Replace("DommeTags: ", "")
		ssh_ThemeSettings = SettingsList(351).Replace("ThemeSettings: ", "")
		ssh_InputIcon = SettingsList(352).Replace("InputIcon: ", "")
		ssh_ApplyingTheme = SettingsList(353).Replace("ApplyingTheme: ", "")
		ssh_AdjustingWindow = SettingsList(354).Replace("AdjustingWindow: ", "")
		ssh_SplitContainerHeight = SettingsList(355).Replace("SplitContainerHeight: ", "")
		ssh_DommeImageFound = SettingsList(356).Replace("DommeImageFound: ", "")
		'DommeImageListCheck = SettingsList(357).Replace("DommeImageListCheck: ", "")
		ssh_LocalImageFound = SettingsList(358).Replace("LocalImageFound: ", "")
		ssh_LocalImageListCheck = SettingsList(359).Replace("LocalImageListCheck: ", "")
		ssh_CBTBothActive = SettingsList(360).Replace("CBTBothActive: ", "")
		ssh_CBTBothFlag = SettingsList(361).Replace("CBTBothFlag: ", "")
		ssh_CBTBothCount = SettingsList(362).Replace("CBTBothCount: ", "")
		ssh_CBTBothFirst = SettingsList(363).Replace("CBTBothFirst: ", "")
		'MetroGet = SettingsList(364).Replace("MetroGet: ", "")
		ssh_GeneralTime = SettingsList(365).Replace("GeneralTime: ", "")
		ssh_NewDommeSlideshow = SettingsList(366).Replace("NewDommeSlideshow: ", "")
		ssh_OriginalDommeSlideshow = SettingsList(367).Replace("OriginalDommeSlideshow: ", "")
		ssh_TimeoutTick = SettingsList(368).Replace("TimeoutTick: ", "")
		'PBImage = SettingsList(369).Replace("PBImage: ", "")
		ssh_DommeImageSTR = SettingsList(370).Replace("DommeImageSTR: ", "")
		ssh_LocalImageSTR = SettingsList(371).Replace("LocalImageSTR: ", "")
		ssh_ImageLocation = SettingsList(372).Replace("ImageLocation: ", "")


		If File.Exists(SettingsPath & ResumePrefix & "PlayListFile.txt") Then ssh_PlaylistFile = Txt2List(SettingsPath & ResumePrefix & "PlayListFile.txt")
		If File.Exists(SettingsPath & ResumePrefix & "TauntLines.txt") Then ssh_TauntLines = Txt2List(SettingsPath & ResumePrefix & "TauntLines.txt")
		If File.Exists(SettingsPath & ResumePrefix & "_ImageFileNames.txt") Then ssh__ImageFileNames = Txt2List(SettingsPath & ResumePrefix & "_ImageFileNames.txt")
		If File.Exists(SettingsPath & ResumePrefix & "RecentSlideshows.txt") Then ssh_RecentSlideshows = Txt2List(SettingsPath & ResumePrefix & "RecentSlideshows.txt")
		If File.Exists(SettingsPath & ResumePrefix & "LocalTagImageList.txt") Then ssh_LocalTagImageList = Txt2List(SettingsPath & ResumePrefix & "LocalTagImageList.txt")
		If File.Exists(SettingsPath & ResumePrefix & "WebImageLines.txt") Then ssh_WebImageLines = Txt2List(SettingsPath & ResumePrefix & "WebImageLines.txt")
		If File.Exists(SettingsPath & ResumePrefix & "TnAList.txt") Then ssh_TnAList = Txt2List(SettingsPath & ResumePrefix & "TnAList.txt")
		If File.Exists(SettingsPath & ResumePrefix & "BoobList.txt") Then ssh_BoobList = Txt2List(SettingsPath & ResumePrefix & "BoobList.txt")
		If File.Exists(SettingsPath & ResumePrefix & "AssList.txt") Then ssh_AssList = Txt2List(SettingsPath & ResumePrefix & "AssList.txt")
		If File.Exists(SettingsPath & ResumePrefix & "UpdateList.txt") Then ssh_UpdateList = Txt2List(SettingsPath & ResumePrefix & "UpdateList.txt")
		If File.Exists(SettingsPath & ResumePrefix & "CustomSlideshowList.txt") Then ssh_CustomSlideshowList = Txt2List(SettingsPath & ResumePrefix & "CustomSlideshowList.txt")
		If File.Exists(SettingsPath & ResumePrefix & "Contact1Pics.txt") Then ssh_Contact1Pics = Txt2List(SettingsPath & ResumePrefix & "Contact1Pics.txt")
		If File.Exists(SettingsPath & ResumePrefix & "Contact2Pics.txt") Then ssh_Contact2Pics = Txt2List(SettingsPath & ResumePrefix & "Contact2Pics.txt")
		' Github Patch If File.Exists(SettingsPath & ResumePrefix & "Contact3Pics.txt") Then Contact3Pics = Txt2List(SettingsPath & "Contact3Pics.txt")
		If File.Exists(SettingsPath & ResumePrefix & "Contact3Pics.txt") Then ssh_Contact3Pics = Txt2List(SettingsPath & ResumePrefix & "Contact3Pics.txt")

		If ssh_SlideshowLoaded = True Then
			If File.Exists(ssh__ImageFileNames(ssh_FileCount)) Then
				' Github Patch ImageThread.Start()
				ShowImage(ssh__ImageFileNames(ssh_FileCount), True)
			End If
		End If

		ChatText.DocumentText = ssh_Chat
		ChatText2.DocumentText = ssh_Chat
		ChatReadyState()

		ssh_ResetFlag = False

	End Sub

#End Region 'Session Supend/Reset

#Region "------------------------------------------------------ MenuStuff -----------------------------------------------------"

#Region "-------------------------------------------------------- File --------------------------------------------------------"

	Private Sub dompersonalitycombobox_LostFocus(sender As Object, e As System.EventArgs) Handles dompersonalitycombobox.LostFocus
		My.Settings.DomPersonality = dompersonalitycombobox.Text
	End Sub

	Private Sub dompersonalitycombobox_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles dompersonalitycombobox.SelectedIndexChanged
		If FormLoading = False Then

			My.Settings.DomPersonality = dompersonalitycombobox.Text

			FrmSettings.LBLGlitModDomType.Text = dompersonalitycombobox.Text

			Try
				FrmSettings.InitializeStartScripts()
				FrmSettings.InitializeModuleScripts()
				FrmSettings.InitializeLinkScripts()
				FrmSettings.InitializeEndScripts()
			Catch
			End Try

			FrmSettings.TCScripts.SelectTab(3)
			FrmSettings.TCScripts.SelectTab(2)
			FrmSettings.TCScripts.SelectTab(1)
			FrmSettings.TCScripts.SelectTab(0)

			If File.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Apps\Glitter\Contact_Descriptions.txt") Then
				Dim ContactList As New List(Of String)
				ContactList = Txt2List(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Apps\Glitter\Contact_Descriptions.txt")
				FrmSettings.GBGlitter1.Text = PoundClean(ContactList(0))
				FrmSettings.GBGlitter2.Text = PoundClean(ContactList(1))
				FrmSettings.GBGlitter3.Text = PoundClean(ContactList(2))
			Else
				FrmSettings.GBGlitter1.Text = "Contact 1"
				FrmSettings.GBGlitter2.Text = "Contact 2"
				FrmSettings.GBGlitter3.Text = "Contact 3"
			End If

			Form9.LBLPersonality.Text = dompersonalitycombobox.Text

			Debug.Print("Personality Changed")

		End If
	End Sub

	Private Sub SuspendSessionToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SuspendSessionToolStripMenuItem.Click

		If ssh_SaidHello = False Then
			MessageBox.Show(Me, "Tease AI is not currently running a session!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Return
		End If


		If File.Exists(Application.StartupPath & "\System\SavedState.xml") Then
			Dim Result As Integer = MessageBox.Show(Me, "A previous saved state already exists!" & Environment.NewLine & Environment.NewLine &
						"Do you wish to overwrite it?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
			If Result = DialogResult.No Then
				Return
			End If
		End If

		Try
			ssh.SlideshowDomme.LoadNew()
			ssh.SlideshowContact1.LoadNew()
			ssh.SlideshowContact2.LoadNew()
			ssh.SlideshowContact3.LoadNew()

			'TODO-NEXT: Add Serializing
			Dim ser As XmlSerializer = New XmlSerializer(GetType(My.SessionState))
			Dim writer As TextWriter = New StreamWriter(Application.StartupPath & "\System\SavedState.xml")
			ser.Serialize(writer, My.Application.Session)
			writer.Close()
		Catch ex As Exception
			MessageBox.Show(Me, "An error occurred and the state did not save correctly!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
		End Try

		MessageBox.Show(Me, "Session state has been saved successfully!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)

	End Sub

	Private Sub ResumeSessionToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ResumeSessionToolStripMenuItem.Click

		If Not File.Exists(Application.StartupPath & "\System\" & "SavedState.txt") Then
			MessageBox.Show(Me, "SavedState.txt could not be found!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Return
		End If

		If ssh_SaidHello = True Then
			Dim Result As Integer = MessageBox.Show(Me, "Resuming a previous state will cause you to lose your progress in this session!" & Environment.NewLine & Environment.NewLine &
												   "Do you wish to proceed?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
			If Result = DialogResult.No Then
				Return
			End If
		End If

		'TODO-NEXT: Add Deserializing

		' Construct an instance of the XmlSerializer with the type
		' of object that is being deserialized.  
		Dim mySerializer As XmlSerializer = New XmlSerializer(GetType(My.SessionState))
		' To read the file, create a FileStream.  
		Dim myFileStream As FileStream = New FileStream(Application.StartupPath & "\System\SavedState.xml", FileMode.Open)
		' Call the Deserialize method and cast to the object type.  
		My.Application.Session = CType(mySerializer.Deserialize(myFileStream), My.SessionState)

		myFileStream.Close()
	End Sub

	Private Sub ResetSessionToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ResetSessionToolStripMenuItem.Click

		If ssh_SaidHello = False Then
			MessageBox.Show(Me, "Tease AI is not currently running a session!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Return
		End If

		StopEverything()
		ResetButton()

		ssh_ResetFlag = True
		ResumeSession()

		If ssh_DomTypeCheck = False Then
			ssh_DomTask = "<b>Tease AI has been reset</b>"
			TypingDelayGeneric()
		End If

	End Sub

	Private Sub ExitToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExitToolStripMenuItem.Click,
																									ExitToolStripMenuItem1.Click
		Me.Close()
		Me.Dispose()
	End Sub

#End Region ' File

#Region "------------------------------------------------------ Settings ------------------------------------------------------"

	Private Sub GeneralSettingsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles GeneralSettingsToolStripMenuItem.Click
		FrmSettings.SettingsTabs.SelectTab(0)
		FrmSettings.Show()
		FrmSettings.Focus()
	End Sub

	Private Sub DommeToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DommeToolStripMenuItem.Click
		FrmSettings.SettingsTabs.SelectTab(1)
		FrmSettings.Show()
		FrmSettings.Focus()
	End Sub

	Private Sub SubToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SubToolStripMenuItem.Click
		FrmSettings.SettingsTabs.SelectTab(2)
		FrmSettings.Show()
		FrmSettings.Focus()
	End Sub

	Private Sub ScriptsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ScriptsToolStripMenuItem.Click
		FrmSettings.SettingsTabs.SelectTab(3)
		FrmSettings.Show()
		FrmSettings.Focus()
	End Sub

	Private Sub ImagesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ImagesToolStripMenuItem.Click
		FrmSettings.SettingsTabs.SelectTab(4)
		FrmSettings.Show()
		FrmSettings.Focus()
	End Sub

	Private Sub TaggingToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles TaggingToolStripMenuItem.Click
		FrmSettings.SettingsTabs.SelectTab(5)
		FrmSettings.Show()
		FrmSettings.Focus()
	End Sub

	Private Sub URLFilesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles URLFilesToolStripMenuItem.Click
		FrmSettings.SettingsTabs.SelectTab(6)
		FrmSettings.Show()
		FrmSettings.Focus()
	End Sub

	Private Sub VideoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles VideoToolStripMenuItem.Click
		FrmSettings.SettingsTabs.SelectTab(7)
		FrmSettings.Show()
		FrmSettings.Focus()
	End Sub

	Private Sub AppsToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles AppsToolStripMenuItem1.Click
		FrmSettings.SettingsTabs.SelectTab(8)
		FrmSettings.Show()
		FrmSettings.Focus()
	End Sub

	Private Sub RangesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RangesToolStripMenuItem.Click
		FrmSettings.SettingsTabs.SelectTab(10)
		FrmSettings.Show()
		FrmSettings.Focus()
	End Sub

	Private Sub ModdingToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ModdingToolStripMenuItem.Click
		FrmSettings.SettingsTabs.SelectTab(11)
		FrmSettings.Show()
		FrmSettings.Focus()
	End Sub

	Private Sub MiscToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles MiscToolStripMenuItem.Click
		FrmSettings.SettingsTabs.SelectTab(12)
		FrmSettings.Show()
		FrmSettings.Focus()
	End Sub

#End Region ' Settings

#Region "-------------------------------------------------------- APPs --------------------------------------------------------"

	Private Sub CloseAppPanelToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CloseAppPanelToolStripMenuItem.Click
		CloseApp()
	End Sub

	Private Sub MetronomeToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles MetronomeToolStripMenuItem.Click
		If PNLMetronome.Visible = False Then
			CloseApp()
			OpenApp()
			PNLMetronome.Visible = True
		End If
	End Sub

	Private Sub GlitterToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles GlitterToolStripMenuItem.Click
		If StatusUpdates.Visible = False Then
			CloseApp()
			StatusUpdates.Visible = True
			OpenApp()
		End If
	End Sub

	Private Sub DommeTagsToolStripMenuItem2_Click(sender As System.Object, e As System.EventArgs) Handles DommeTagsToolStripMenuItem2.Click

		If PNLDomTagBTN.Visible = False Then
			CloseApp()
			OpenApp()
			PNLDomTagBTN.Visible = True
		End If

	End Sub

	Private Sub LazySubToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles LazySubToolStripMenuItem.Click

		If PNLLazySub.Visible = False Then
			CloseApp()
			OpenApp()
			PNLLazySub.Visible = True
		End If

	End Sub

	Private Sub RandomizerToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RandomizerToolStripMenuItem.Click
		If PNLAppRandomizer.Visible = False Then
			CloseApp()
			OpenApp()
			PNLAppRandomizer.Visible = True
		End If
	End Sub

	Private Sub PlaylistToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PlaylistToolStripMenuItem.Click
		If PNLPlaylist.Visible = False Then
			CloseApp()
			OpenApp()
			PNLPlaylist.Visible = True
			LBPlaylist.Items.Clear()
			For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Playlist\", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
				LBPlaylist.Items.Add(Path.GetFileName(foundFile).Replace(".txt", ""))
			Next
		End If
	End Sub

	Private Sub WritingTasksToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles WritingTasksToolStripMenuItem.Click
		If PNLWritingTask.Visible = False Then
			CloseApp()
			OpenApp()
			PNLWritingTask.Visible = True
		End If
	End Sub

	Private Sub WishlistToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles WishlistToolStripMenuItem.Click
		If PNLWishList.Visible = False Then



			If My.Settings.ClearWishlist = True Then

				MessageBox.Show(Me, "You have already purchased " & domName.Text & "'s Wishlist item for today!" & Environment.NewLine & Environment.NewLine &
								"Please check back again tomorrow!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
				Return
			End If







			If CompareDates(My.Settings.WishlistDate) <> 0 Then


				Dim WishList As New List(Of String)
				WishList.Clear()

				For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Apps\Wishlist\Items\", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
					WishList.Add(foundFile)
				Next

				If WishList.Count < 1 Then
					MessageBox.Show(Me, "No Wishlist items found!" & Environment.NewLine & Environment.NewLine &
								"Please make sure you have item scripts located in Apps\Wishlist\Items.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					Return

				End If

				LBLWishlistDom.Text = domName.Text & "'s Wishlist"
				LBLWishlistDate.Text = FormatDateTime(Now, DateFormat.ShortDate).ToString()
				WishlistCostGold.Visible = False
				WishlistCostSilver.Visible = False
				LBLWishlistBronze.Text = ssh_BronzeTokens
				LBLWishlistSilver.Text = ssh_SilverTokens
				LBLWishlistGold.Text = ssh_GoldTokens
				LBLWishListText.Text = ""



				Dim WishDir As String = WishList(ssh_randomizer.Next(0, WishList.Count))

				WishList.Clear()
				'Read all lines of the given file.
				WishList = Txt2List(WishDir)

				LBLWishListName.Text = WishList(0)
				My.Settings.WishlistName = LBLWishListName.Text


				WishlistPreview.Load(WishList(1))
				WishlistPreview.Visible = True
				My.Settings.WishlistPreview = WishList(1)

				If WishList(2).Contains("Silver") Then
					WishlistCostSilver.Visible = True
					LBLWishlistCost.Text = WishList(2)
					LBLWishlistCost.Text = LBLWishlistCost.Text.Replace(" Silver", "")
					My.Settings.WishlistTokenType = "Silver"
				End If

				If WishList(2).Contains("Gold") Then
					WishlistCostGold.Visible = True
					LBLWishlistCost.Text = WishList(2)
					LBLWishlistCost.Text = LBLWishlistCost.Text.Replace(" Gold", "")
					My.Settings.WishlistTokenType = "Gold"
				End If

				My.Settings.WishlistCost = Val(LBLWishlistCost.Text)


				LBLWishListText.Text = WishList(3)
				My.Settings.WishlistNote = WishList(3)


				If WishlistCostGold.Visible = True Then
					If ssh_GoldTokens >= Val(LBLWishlistCost.Text) Then
						BTNWishlist.Enabled = True
						BTNWishlist.Text = "Purchase for " & domName.Text
					Else
						BTNWishlist.Enabled = False
						BTNWishlist.Text = "Not Enough Tokens!"
					End If
				End If

				If WishlistCostSilver.Visible = True Then
					If ssh_SilverTokens >= Val(LBLWishlistCost.Text) Then
						BTNWishlist.Enabled = True
						BTNWishlist.Text = "Purchase for " & domName.Text
					Else
						BTNWishlist.Enabled = False
						BTNWishlist.Text = "Not Enough Tokens!"
					End If
				End If



				My.Settings.WishlistDate = FormatDateTime(Now, DateFormat.ShortDate)







			Else



				LBLWishlistDom.Text = domName.Text & "'s Wishlist"
				LBLWishlistDate.Text = FormatDateTime(Now, DateFormat.ShortDate).ToString()
				LBLWishlistBronze.Text = ssh_BronzeTokens
				LBLWishlistSilver.Text = ssh_SilverTokens
				LBLWishlistGold.Text = ssh_GoldTokens


				LBLWishListName.Text = My.Settings.WishlistName
				Try
					WishlistPreview.Load(My.Settings.WishlistPreview)
				Catch
					WishlistPreview.Load(Application.StartupPath & "\Images\System\NoPreview.png")
				End Try

				If My.Settings.WishlistTokenType = "Silver" Then WishlistCostSilver.Visible = True
				If My.Settings.WishlistTokenType = "Gold" Then WishlistCostGold.Visible = True
				LBLWishlistCost.Text = My.Settings.WishlistCost
				LBLWishListText.Text = My.Settings.WishlistNote

				If WishlistCostGold.Visible = True Then
					If ssh_GoldTokens >= Val(LBLWishlistCost.Text) Then
						BTNWishlist.Text = "????? Gold"
						BTNWishlist.Enabled = True
					Else
						BTNWishlist.Text = "Not Enough Tokens!"
						BTNWishlist.Enabled = False
					End If
				End If

				If WishlistCostSilver.Visible = True Then
					Debug.Print("Silver Caled PPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPP")
					If ssh_SilverTokens >= Val(LBLWishlistCost.Text) Then
						BTNWishlist.Text = "???? Silver"
						BTNWishlist.Enabled = True
					Else
						BTNWishlist.Text = "Not Enough Tokens!"
						BTNWishlist.Enabled = False
					End If
				End If

			End If







			LBLWishlistBronze.Text = ssh_BronzeTokens
			LBLWishlistSilver.Text = ssh_SilverTokens
			LBLWishlistGold.Text = ssh_GoldTokens

			If WishlistCostGold.Visible = True Then
				If ssh_GoldTokens >= Val(LBLWishlistCost.Text) Then
					BTNWishlist.Text = "Purchase for " & domName.Text
					BTNWishlist.Enabled = True
				Else
					BTNWishlist.Text = "Not Enough Tokens!"
					BTNWishlist.Enabled = False
				End If
			End If

			If WishlistCostSilver.Visible = True Then
				Debug.Print("Silver Called")
				If ssh_SilverTokens >= Val(LBLWishlistCost.Text) Then
					BTNWishlist.Text = "Purchase for " & domName.Text
					BTNWishlist.Enabled = True
				Else
					BTNWishlist.Text = "Not Enough Tokens!"
					BTNWishlist.Enabled = False
				End If
			End If






			CloseApp()
			OpenApp()
			PNLWishList.Visible = True
		End If
	End Sub

	Private Sub HypnoticGuideToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles HypnoticGuideToolStripMenuItem.Click

		If PNLHypnoGen.Visible = False Then
			CloseApp()
			OpenApp()
			PNLHypnoGen.Visible = True



			LBHypnoGenInduction.Items.Clear()

			For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Apps\Hypnotic Guide\Inductions\", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")

				Dim TempUrl As String = foundFile
				TempUrl = TempUrl.Replace(".txt", "")
				Do Until Not TempUrl.Contains("\")
					TempUrl = TempUrl.Remove(0, 1)
				Loop
				LBHypnoGenInduction.Items.Add(TempUrl)

			Next

			For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Apps\Hypnotic Guide\", FileIO.SearchOption.SearchTopLevelOnly, "*.mp3")
				Dim TempUrl As String = foundFile
				Do Until Not TempUrl.Contains("\")
					TempUrl = TempUrl.Remove(0, 1)
				Loop
				ComboBoxHypnoGenTrack.Items.Add(TempUrl)
			Next



			LBHypnoGen.Items.Clear()

			For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Apps\Hypnotic Guide\Hypno Files\", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")

				Dim TempUrl As String = foundFile
				TempUrl = TempUrl.Replace(".txt", "")
				Do Until Not TempUrl.Contains("\")
					TempUrl = TempUrl.Remove(0, 1)
				Loop
				LBHypnoGen.Items.Add(TempUrl)

			Next



		End If


	End Sub

	Private Sub VitalSubToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles VitalSubToolStripMenuItem.Click

		If AppPanelVitalSub.Visible = False Then
			CloseApp()
			OpenApp()
			AppPanelVitalSub.Visible = True

			If File.Exists(Application.StartupPath & "\System\VitalSub\CalorieList.txt") And ComboBoxCalorie.Items.Count = 0 Then
				Debug.Print("called itttttttt")
				'Read all lines of the given file.
				Dim CalList As List(Of String) = Txt2List(Application.StartupPath & "\System\VitalSub\CalorieList.txt")

				For i As Integer = 0 To CalList.Count - 1
					ComboBoxCalorie.Items.Add(CalList(i))
				Next
			End If

		End If

	End Sub

#End Region ' APPs

#Region "-------------------------------------------------------- Games -------------------------------------------------------"

	Private Sub SlotsToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles SlotsToolStripMenuItem1.Click,
																									SlotsToolStripMenuItem.Click
		FrmCardList.TCGames.SelectTab(0)
		FrmCardList.Show()
		FrmCardList.Focus()
	End Sub

	Private Sub MatchGameToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles MatchGameToolStripMenuItem1.Click,
																										MatchGameToolStripMenuItem.Click
		FrmCardList.TCGames.SelectTab(1)
		FrmCardList.Show()
		FrmCardList.Focus()
	End Sub

	Private Sub RiskyPickToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles RiskyPickToolStripMenuItem1.Click,
																										RiskyPickToolStripMenuItem.Click
		FrmCardList.TCGames.SelectTab(2)
		FrmCardList.Show()
		FrmCardList.Focus()
	End Sub

	Private Sub ExchangeToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles ExchangeToolStripMenuItem1.Click,
																										ExchangeToolStripMenuItem.Click
		FrmCardList.TCGames.SelectTab(3)
		FrmCardList.Show()
		FrmCardList.Focus()
	End Sub

	Private Sub CollectionToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles CollectionToolStripMenuItem1.Click,
																										CollectionToolStripMenuItem.Click
		FrmCardList.TCGames.SelectTab(4)
		FrmCardList.Show()
		FrmCardList.Focus()
	End Sub

#End Region ' Games

#Region "----------------------------------------------------- Interface ------------------------------------------------------"

	Private Sub SwitchSidesToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles SwitchSidesToolStripMenuItem1.Click
		If My.Settings.MirrorWindows = False Then
			My.Settings.MirrorWindows = True
		Else
			My.Settings.MirrorWindows = False
		End If

		AdjustWindow()
	End Sub

	Private Sub SideChatToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles SideChatToolStripMenuItem1.Click
		If SideChatToolStripMenuItem1.Checked = True Then SideChatToolStripMenuItem1.Checked = False
		If ChatText2.Visible = False Then
			CloseApp()
			ChatText2.Visible = True
			PNLChatBox2.Visible = True
			OpenApp()
			SideChatToolStripMenuItem1.Checked = True
			My.Settings.SideChat = True
		Else
			CloseApp()
			My.Settings.SideChat = False
		End If
	End Sub

	Private Sub LazySubAVToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles LazySubAVToolStripMenuItem1.Click
		If PNLLazySubAV.Visible = False Then
			PNLLazySubAV.Visible = True
			LazySubAVToolStripMenuItem1.Checked = True
			My.Settings.LazySubAV = True
		Else
			PNLLazySubAV.Visible = False
			LazySubAVToolStripMenuItem1.Checked = False
			My.Settings.LazySubAV = False
		End If
	End Sub

	Private Sub ThemesToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles ThemesToolStripMenuItem1.Click
		FrmSettings.SettingsTabs.SelectTab(9)
		FrmSettings.Show()
		FrmSettings.Focus()
	End Sub

	Private Sub MaximizeImageToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles MaximizeImageToolStripMenuItem.Click
		SplitContainer1.SplitterDistance = SplitContainer1.Height
	End Sub

	Private Sub WebteaseModeToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles WebteaseModeToolStripMenuItem.Click
		If FrmSettings.CBWebtease.Checked = True Then
			WebteaseModeToolStripMenuItem.Checked = False
			FrmSettings.CBWebtease.Checked = False
		Else
			WebteaseModeToolStripMenuItem.Checked = True
			FrmSettings.CBWebtease.Checked = True
		End If

		My.Settings.CBWebtease = FrmSettings.CBWebtease.Checked

	End Sub

	Private Sub DefaultImageSizeToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DefaultImageSizeToolStripMenuItem.Click
		If SplitContainer1.Height > 430 Then SplitContainer1.SplitterDistance = SplitContainer1.Height - 252
	End Sub

#End Region ' Interface

#Region "------------------------------------------------------- Tools --------------------------------------------------------"

	Private Sub CommandGuideToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CommandGuideToolStripMenuItem.Click
		If Form10.Visible = False Then Form10.Show()
		Form10.Focus()
	End Sub

	Private Sub AIBoxesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AIBoxesToolStripMenuItem.Click
		If Form9.Visible = False Then Form9.Show()
		Form9.Focus()
	End Sub

	Private Sub OldDommeTagsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles OldDommeTagsToolStripMenuItem.Click
		Form8.Show()
	End Sub

#End Region ' Tools

#Region "------------------------------------------------------ Milovana ------------------------------------------------------"

	Private Sub OpenBetaThreadToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles OpenBetaThreadToolStripMenuItem.Click,
																											OpenBetaThreadToolStripMenuItem1.Click
		Process.Start("https://milovana.com/forum/viewtopic.php?f=2&t=15776")
	End Sub

	Private Sub BugReportThreadToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles BugReportThreadToolStripMenuItem.Click,
																											BugReportThreadToolStripMenuItem1.Click
		Process.Start("https://milovana.com/forum/viewtopic.php?f=2&t=16203")
	End Sub

	Private Sub WebteasesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles WebteasesToolStripMenuItem.Click,
																										WebteasesToolStripMenuItem1.Click
		Process.Start("https://milovana.com/webteases/")
	End Sub

	Private Sub AllAndEverythingToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AllAndEverythingToolStripMenuItem.Click,
																												ForumToolStripMenuItem.Click
		Process.Start("https://milovana.com/forum/")
	End Sub

#End Region ' Milovana

	Private Sub RunScriptToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RunScriptToolStripMenuItem.Click

		If OpenScriptDialog.ShowDialog() = DialogResult.OK Then

			ssh_StrokeTauntVal = -1

			If Directory.Exists(FrmSettings.LBLDomImageDir.Text) And ssh_SlideshowLoaded = False Then
				LoadDommeImageFolder()
			End If

			ssh_FileText = OpenScriptDialog.FileName
			ssh_BeforeTease = False
			ssh_ShowModule = True
			ssh_SaidHello = True
			ssh_ScriptTick = 1
			ScriptTimer.Start()

			ApplyThemeColor()

		End If

	End Sub

	Private Sub DebugMenuToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DebugMenuToolStripMenuItem.Click
		FrmSettings.SettingsTabs.SelectTab(13)
		FrmSettings.Show()
		FrmSettings.Focus()
	End Sub

	Private Sub RefreshRandomizerToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RefreshRandomizerToolStripMenuItem.Click
		ssh_randomizer = New Random(System.DateTime.Now.Ticks Mod System.Int32.MaxValue)
	End Sub

	Private Sub AboutToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AboutToolStripMenuItem.Click
		FrmSettings.SettingsTabs.SelectTab(14)
		FrmSettings.Show()
		FrmSettings.Focus()
	End Sub



#End Region ' Menu

	Private Sub Form1_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseClick
		If SplitContainer1.Width + 270 > Me.Width Then AdjustWindow()
	End Sub

	Private Sub Form1_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize

		Debug.Print("Resize Called")
		Debug.Print(Me.WindowState)
		Debug.Print(Me.ssh_WindowCheck)

		Select Case Me.WindowState

			Case FormWindowState.Maximized
				Debug.Print("Maximized")
				ssh_WindowCheck = True
				AdjustWindow()

			Case FormWindowState.Normal And ssh_WindowCheck = True
				Debug.Print("Resized From Maximized")
				ssh_WindowCheck = False
				AdjustWindow()

		End Select
	End Sub

	Private Sub Form1_ResizeEnd(sender As Object, e As System.EventArgs) Handles Me.ResizeEnd

		Debug.Print(Me.Width & " " & Me.Height)

		AdjustWindow()

		SplitContainer1.Width = Me.Width - 296

		My.Settings.WindowHeight = Me.Height
		My.Settings.WindowWidth = Me.Width

	End Sub

	Public Sub AdjustWindow()


		'Test

		SuspendLayout()

		ssh_AdjustingWindow = True

		Debug.Print("Adjust Window Called")


		If Me.Height < 734 Then Me.Height = 734
		If Me.Width < 978 Then Me.Width = 978

		' PNLAV.Location = New Point(10, Me.Height - 294)
		' PNLApp.Height = Me.Height - 84
		'If PNLTabs.Height <> 0 Then PNLTabs.Height = PNLApp.Height - 333



		'If PNLTabs.VerticalScroll.Visible = False Then
		'PNLTabs.Width = 253
		'Else
		'PNLTabs.Width = 258
		'End If

		If PNLTabs.Height <> 0 Then PNLTabs.Height = Me.Height - 426

		'subName.Location = New Point(3, PNLApp.Height - 31)
		'domAvatar.Location = New Point(3, PNLApp.Height - 212)
		'domName.Location = New Point(3, PNLApp.Height - 243)

		If PNLTabs.Height <> 0 Then StatusUpdates.Height = PNLTabs.Height - 8
		'If PNLTabs.Height <> 0 Then ChatText2.Height = PNLTabs.Height - 8
		If PNLTabs.Height <> 0 Then ChatText2.Height = PNLTabs.Height - 39
		PNLChatBox2.Location = New Point(2, ChatText2.Height)

		If My.Settings.MirrorWindows = False Then
			PNLAvatar.Location = New Point(9, Me.Height - 294)
			PNLTabs.Location = New Point(9, 120)
			PNLDate.Location = New Point(9, 37)
			SplitContainer1.Location = New Point(271, 37)
		Else
			PNLAvatar.Location = New Point(Me.Width - 278, Me.Height - 294)
			PNLTabs.Location = New Point(Me.Width - 278, 120)
			PNLDate.Location = New Point(Me.Width - 278, 37)
			SplitContainer1.Location = New Point(9, 37)
		End If






		SplitContainer1.Height = Me.Height - 83
		'SplitContainer1.Width = Me.Width - 39

		'SplitContainer1.Height = Me.Height - 58
		SplitContainer1.Width = Me.Width - 296

		'mainPictureBox.Location = New Point(0, 0)
		'mainPictureBox.Width = SplitContainer1.Width
		'mainPictureBox.Height = SplitContainer1.Panel1.Height

		'If SplitContainerHeight <> 0 Then SplitContainer1.SplitterDistance = (SplitContainer1.Height - SplitContainerHeight) - 4
		Try
			SplitContainer1.SplitterDistance = My.Settings.SplitterDistance
		Catch
		End Try


		Debug.Print("SplitContainer1.Height = " & SplitContainer1.Height)
		Debug.Print("SplitContainer1.Panel1.Height = " & SplitContainer1.Panel1.Height)
		Debug.Print("SplitContainer1.Panel2.Height = " & SplitContainer1.Panel2.Height)
		Debug.Print("SplitContainer1.SplitterDistance = " & SplitContainer1.SplitterDistance)
		Debug.Print("SplitContainerHeight = " & ssh_SplitContainerHeight)

		'SplitContainer1.Panel2.Height = My.Settings.SplitterPosition

		mainPictureBox.Location = New Point(0, 0)
		mainPictureBox.Width = SplitContainer1.Width
		mainPictureBox.Height = SplitContainer1.Panel1.Height

		If PNLMediaBar.Visible = True Then
			ChatText.Location = New Point(2, 33)
			ChatText.Height = SplitContainer1.Panel2.Height - 67
		Else
			ChatText.Location = New Point(2, 0)
			ChatText.Height = SplitContainer1.Panel2.Height - 34
		End If

		ChatText.Width = SplitContainer1.Width - 3

		PNLMediaBar.Width = SplitContainer1.Width - 367
		ImageFolderComboBox.Width = PNLMediaBar.Width - 13

		previousButton.Location = New Point(SplitContainer1.Width - 314, 0)
		nextButton.Location = New Point(SplitContainer1.Width - 257, 0)
		BTNLoadVideo.Location = New Point(SplitContainer1.Width - 200, 0)
		BTNVideoControls.Location = New Point(SplitContainer1.Width - 124, 0)



		'chatBox.Location = New Point(3, 5)

		'MediaButton.Location = New Point(0, 3)
		'SaveBlogImage.Location = New Point(114, 3)
		'SettingsButton.Location = New Point(190, 3)


		PNLChatBox.Width = SplitContainer1.Width - 318
		chatBox.Width = PNLChatBox.Width - 13

		BTNVideoControls.BringToFront()


		If PNLMediaBar.Visible = True Then
			PNLChatBox.Location = New Point(2, SplitContainer1.Panel2.Height - 32)
			PNLHope.Location = New Point(SplitContainer1.Width - 314, PNLChatBox.Location.Y)
		Else
			PNLChatBox.Location = New Point(2, SplitContainer1.Panel2.Height - 32)
			PNLHope.Location = New Point(SplitContainer1.Width - 314, PNLChatBox.Location.Y)
		End If

		'PNLHope.Location = New Point(779, 214)

		'BTNShowHideApps.Location = New Point(10, Me.Height - 292)

		'subName.Location = New Point(10, Me.Height - 69)
		'subAvatar.Location = New Point(10, Me.Height - 258)

		'PNLGlitter.Height = Me.Height - 597
		'StatusUpdates.Height = Me.Height - 602

		DomWMP.Location = New Point(0, 0)
		DomWMP.Width = SplitContainer1.Width


		If PNLTabs.Height > 476 Then
			PNLDomTagBTN.Height = PNLTabs.Height - 8
		Else
			PNLDomTagBTN.Height = 468
		End If

		If PNLTabs.Height > 452 Then
			PNLLazySub.Height = PNLTabs.Height - 8
		Else
			PNLLazySub.Height = 444
		End If

		If PNLTabs.Height > 452 Then
			PNLLazySub2.Height = PNLTabs.Height - 8
		Else
			PNLLazySub2.Height = 444
		End If

		If PNLTabs.Height > 387 Then
			PNLAppRandomizer.Height = PNLTabs.Height - 8
		Else
			PNLAppRandomizer.Height = 379
		End If

		If PNLTabs.Height > 402 Then
			PNLPlaylist.Height = PNLTabs.Height - 8
		Else
			PNLPlaylist.Height = 394
		End If

		If PNLTabs.Height > 275 Then
			PNLWritingTask.Height = PNLTabs.Height - 8
		Else
			PNLWritingTask.Height = 267
		End If

		If PNLTabs.Height > 492 Then
			PNLWishList.Height = PNLTabs.Height - 8
		Else
			PNLWishList.Height = 485
		End If

		If PNLTabs.Height > 426 Then
			PNLHypnoGen.Height = PNLTabs.Height - 8
		Else
			PNLHypnoGen.Height = 418
		End If

		If PNLTabs.Height > 431 Then
			AppPanelVitalSub.Height = PNLTabs.Height - 8
		Else
			AppPanelVitalSub.Height = 422
		End If

		If PNLTabs.Height > 175 Then
			PNLMetronome.Height = PNLTabs.Height - 8
		Else
			PNLMetronome.Height = 167
		End If


		PNLTabs.HorizontalScroll.Visible = False


		PNLTabs.HorizontalScroll.Maximum = 0
		PNLTabs.AutoScroll = False
		PNLTabs.VerticalScroll.Visible = False
		PNLTabs.AutoScroll = True

		ssh_AdjustingWindow = False

		'If My.Settings.SplitterPosition <> 0 Then SplitContainer1.SplitterDistance = My.Settings.SplitterPosition

		' SplitContainer1.Height = Me.Height - 83

		ResumeLayout()


	End Sub

	Private Sub SplitContainer1_SplitterMoved(sender As Object, e As System.Windows.Forms.SplitterEventArgs) Handles SplitContainer1.SplitterMoved

		If FormLoading = True Then Return

		If ssh_ApplyingTheme = False And ssh_AdjustingWindow = False Then

			If PNLMediaBar.Visible = True Then
				ChatText.Location = New Point(2, 33)
				ChatText.Height = SplitContainer1.Panel2.Height - 67
			Else
				ChatText.Location = New Point(2, 0)
				ChatText.Height = SplitContainer1.Panel2.Height - 68
			End If

			PNLChatBox.Location = New Point(2, SplitContainer1.Panel2.Height - 32)
			PNLHope.Location = New Point(SplitContainer1.Width - 314, PNLChatBox.Location.Y)

			ssh_SplitContainerHeight = SplitContainer1.Panel2.Height

			My.Settings.SplitterPosition = SplitContainer1.Height - SplitContainer1.Panel1.Height

			Debug.Print("SplitContainer1.Height = " & SplitContainer1.Height)
			Debug.Print("SplitContainer1.Panel1.Height = " & SplitContainer1.Panel1.Height)
			Debug.Print("SplitContainer1.Panel2.Height = " & SplitContainer1.Panel2.Height)
			Debug.Print("SplitContainer1.SplitterDistance = " & SplitContainer1.SplitterDistance)
			Debug.Print("SplitContainerHeight = " & ssh_SplitContainerHeight)




			GoTo SkipNew


		End If




		GoTo SkipNew

		If PNLMediaBar.Visible = True Then
			PNLChatBox.Location = New Point(2, ChatText.Height + 30)
			PNLHope.Location = New Point(SplitContainer1.Width - 313, ChatText.Height + 29)
		Else
			PNLChatBox.Location = New Point(2, ChatText.Height - 11)
			PNLHope.Location = New Point(SplitContainer1.Width - 313, ChatText.Height - 12)
		End If



		If PNLMediaBar.Visible = True Then
			PNLChatBox.Location = New Point(2, ChatText.Height + 30)
			PNLHope.Location = New Point(SplitContainer1.Width - 313, ChatText.Height + 29)
		Else
			PNLChatBox.Location = New Point(2, ChatText.Height - 11)
			PNLHope.Location = New Point(SplitContainer1.Width - 313, ChatText.Height - 12)
		End If

		'PNLDomTags.Height = SplitContainer1.Panel1.Height
		'PNLDomTagBTN.Location = New Point(10, (PNLDomTags.Height - 479) / 2)

		'PNLTheme.Height = SplitContainer1.Panel1.Height - 82
		'PNLThemeBTN.Location = New Point(0, (PNLTheme.Height - 480) / 2)

		' PNLTheme.HorizontalScroll.Visible = False
		' PNLThemeBTN.HorizontalScroll.Visible = False

		'If PNLDomTagBTN.Location.Y < 30 Then PNLDomTagBTN.Location = New Point(10, 30)
		'If PNLThemeBTN.Location.Y < 30 Then PNLThemeBTN.Location = New Point(0, 30)



SkipNew:


		If SplitContainer1.Panel2.Height < 68 And BtnToggleMediaPanel.Text = "Hide Media Panel" Then
			PNLMediaBar.Visible = False
			browsefolderButton.Visible = False
			previousButton.Visible = False
			nextButton.Visible = False
			BTNLoadVideo.Visible = False
			BTNVideoControls.Visible = False
		End If

		If SplitContainer1.Panel2.Height < 68 Then
			BtnToggleMediaPanel.Enabled = False
		Else
			BtnToggleMediaPanel.Enabled = True
		End If

		If SplitContainer1.Panel2.Height > 67 And BtnToggleMediaPanel.Text = "Hide Media Panel" Then
			PNLMediaBar.Visible = True
			browsefolderButton.Visible = True
			previousButton.Visible = True
			nextButton.Visible = True
			BTNLoadVideo.Visible = True
			BTNVideoControls.Visible = True
		End If


		If FormLoading = False And FormFinishedLoading = True Then
			My.Settings.SplitterDistance = SplitContainer1.SplitterDistance

		End If

		If ssh_ApplyingTheme = False And ssh_AdjustingWindow = False Then AdjustWindow()

		ScrollChatDown()




		Debug.Print("SplitContainer1.SplitterDistance = " & SplitContainer1.SplitterDistance)



	End Sub






	Private Sub TeaseAIClock_Tick(sender As System.Object, e As System.EventArgs) Handles TeaseAIClock.Tick
		' Reset the WatchdogTimer Clock. 
		WatchDogImageAnimator.Reset(TeaseAIClock.Interval * 3)


		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then
			LBLTime.Text = Format(Now, "h:mm")
			LBLAMPM.Text = Format(Now, "tt")
			LBLDate.Text = Format(Now, "Long Date")
			Return
		End If

		If ssh_WritingTaskFlag = False Or (ssh_WritingTaskFlag = True And My.Settings.TimedWriting = False) Then
			LBLTime.Text = Format(Now, "h:mm")
			LBLAMPM.Text = Format(Now, "tt")
			LBLDate.Text = Format(Now, "Long Date")
		Else
			If ssh_WritingTaskCurrentTime > 0 Then
				If My.Settings.TimedWriting = True Then
					LBLWritingTask.Text = "Write the following line " & ssh_WritingTaskLinesAmount & " times" & vbCrLf & "You have " & ConvertSeconds(ssh_WritingTaskCurrentTime)
					LBLTime.Text = Convert.ToInt16(ssh_WritingTaskCurrentTime)
				Else
					LBLWritingTask.Text = "Write the following line " & ssh_WritingTaskLinesAmount & " times"
				End If
			Else
				If My.Settings.TimedWriting = True Then
					LBLWritingTask.Text = "Write the following line " & ssh_WritingTaskLinesAmount & " times" & vbCrLf & "YOUR TIME IS UP"
					LBLTime.Text = "Time's Up"
					'immediately ends the writing task if time is up without waiting for next user input
					ClearWriteTask()
					ssh_SkipGotoLine = True
					ssh_FileGoto = "Failed Writing Task"
					GetGoto()
					ssh_ScriptTick = 4
					ScriptTimer.Start()
				Else
					LBLWritingTask.Text = "Write the following line " & ssh_WritingTaskLinesAmount & " times"
				End If

			End If
			ssh_WritingTaskCurrentTime -= 1

			LBLAMPM.Text = ""
		End If




		'If WritingTaskFlag = False Then
		'LBLTime.Text = Format(Now, "h:mm")
		'LBLAMPM.Text = Format(Now, "tt")
		'LBLDate.Text = Format(Now, "Long Date")
		'Else
		'If WritingTaskCurrentTime > 0 Then
		'LBLWritingTask.Text = "Write the following line " & WritingTaskLinesAmount & " times" & vbCrLf & "You have " & ConvertSeconds(WritingTaskCurrentTime)
		'LBLTime.Text = Convert.ToInt16(WritingTaskCurrentTime)
		'Else
		'LBLWritingTask.Text = "Write the following line " & WritingTaskLinesAmount & " times" & vbCrLf & "YOUR TIME IS UP"
		'LBLTime.Text = "Time's Up"
		'End If
		'WritingTaskCurrentTime -= 1
		'LBLAMPM.Text = ""
		'End If


		If File.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Variables\SYS_WakeUp") Then

			Dim Dates As String
			'Dates = FormatDateTime(Now, DateFormat.ShortDate) & " " & GetTime("SYS_WakeUp")
			Dates = FormatDateTime(Now, DateFormat.ShortDate) & " " & FormatDateTime(FrmSettings.TimeBoxWakeUp.Value, DateFormat.LongTime)

			Dim DDiff As Integer
			DDiff = DateDiff(DateInterval.Hour, CDate(Dates), Now)

			Dim TimeCounter As Integer = -3

			ssh_GeneralTime = "Night"
			If DDiff < -20 Then ssh_GeneralTime = "Morning"
			If DDiff > -2 And DDiff < 5 Then ssh_GeneralTime = "Morning"
			If DDiff > 4 And DDiff < 12 Then ssh_GeneralTime = "Afternoon"
			If DDiff > -21 And DDiff < -11 Then ssh_GeneralTime = "Afternoon"

		End If

		' #DEBUG

	End Sub

	Public Sub StrokeSpeedCheck()

		If ssh_StrokeFaster = True Then
			If ssh_SubStroking = True And ssh_SubEdging = False And ssh_SubHoldingEdge = False Then
				Debug.Print("Stroke Faster")
				Dim Stroke123 As Integer = ssh_randomizer.Next(1, 4)
				Stroke123 = Stroke123 * 50
				StrokePace = StrokePace - Stroke123
				If StrokePace < NBMaxPace.Value Then StrokePace = NBMaxPace.Value

			End If
			ssh_StrokeFaster = False
		End If

		If ssh_StrokeSlower = True Then
			If ssh_SubStroking = True And ssh_SubEdging = False And ssh_SubHoldingEdge = False Then
				Debug.Print("Stroke Slower")
				Dim Stroke123 As Integer = ssh_randomizer.Next(1, 4)
				Stroke123 = Stroke123 * 50
				StrokePace = StrokePace + Stroke123
				If StrokePace > NBMinPace.Value Then StrokePace = NBMinPace.Value

			End If
			ssh_StrokeSlower = False
		End If

		If ssh_StrokeFastest = True Then
			If ssh_SubStroking = True And ssh_SubEdging = False And ssh_SubHoldingEdge = False Then
				Debug.Print("Stroke Fastest")
				StrokePace = NBMaxPace.Value

			End If
			ssh_StrokeFastest = False
		End If

		If ssh_StrokeSlowest = True Then
			If ssh_SubStroking = True And ssh_SubEdging = False And ssh_SubHoldingEdge = False Then
				Debug.Print("Stroke Slowest")
				StrokePace = NBMinPace.Value

			End If
			ssh_StrokeSlowest = False
		End If

	End Sub

	Public Sub ApplyThemeColor()

		ssh_ApplyingTheme = True

		subName.BackColor = My.Settings.ButtonColor
		subName.ForeColor = My.Settings.TextColor
		'BTNShowHideApps.BackColor = My.Settings.ButtonColor
		'BTNShowHideApps.ForeColor = My.Settings.TextColor
		domName.BackColor = My.Settings.ButtonColor
		domName.ForeColor = My.Settings.TextColor

		browsefolderButton.BackColor = My.Settings.ButtonColor
		PNLMediaBar.BackColor = My.Settings.ButtonColor
		'PNLHope.BackColor = My.Settings.ButtonColor
		PNLChatBox.BackColor = My.Settings.ButtonColor
		PNLChatBox2.BackColor = My.Settings.ButtonColor

		previousButton.BackColor = My.Settings.ButtonColor
		nextButton.BackColor = My.Settings.ButtonColor
		BTNLoadVideo.BackColor = My.Settings.ButtonColor
		BTNVideoControls.BackColor = My.Settings.ButtonColor

		BtnToggleMediaPanel.BackColor = My.Settings.ButtonColor
		BtnToggleImageVideo.BackColor = My.Settings.ButtonColor
		BtnToggleSettings.BackColor = My.Settings.ButtonColor

		browsefolderButton.ForeColor = My.Settings.TextColor
		PNLMediaBar.ForeColor = My.Settings.TextColor
		PNLHope.ForeColor = My.Settings.TextColor
		PNLChatBox.ForeColor = My.Settings.TextColor
		PNLChatBox2.ForeColor = My.Settings.TextColor

		previousButton.ForeColor = My.Settings.TextColor
		nextButton.ForeColor = My.Settings.TextColor
		BTNLoadVideo.ForeColor = My.Settings.TextColor
		BTNVideoControls.ForeColor = My.Settings.TextColor

		BtnToggleMediaPanel.ForeColor = My.Settings.TextColor
		BtnToggleImageVideo.ForeColor = My.Settings.TextColor
		BtnToggleSettings.ForeColor = My.Settings.TextColor

		PNLDomTagBTN.BackColor = My.Settings.BackgroundColor

		Me.BackColor = My.Settings.BackgroundColor

		' If File.Exists(My.Settings.BackgroundImage) Then
		'FrmSettings.PBBackgroundPreview.Image = Image.FromFile(My.Settings.BackgroundImage)
		'Me.BackgroundImage = Image.FromFile(My.Settings.BackgroundImage)
		'End If


		'SplitContainer1.Panel2.BackColor = My.Settings.BackgroundColor





		'PNLLazySub.BackColor = my.settings.BackgroundColor
		'Label27.ForeColor = my.settings.BackgroundColor
		'Panel1.BackColor = my.settings.BackgroundColor
		'LBLWishListName.ForeColor = my.settings.BackgroundColor
		'Panel2.BackColor = my.settings.BackgroundColor
		'PNLPlaylist.BackColor = my.settings.BackgroundColor
		'PNLAppRandomizer.BackColor = my.settings.BackgroundColor
		'PictureBox3.BackColor = my.settings.BackgroundColor



		Try
			FrmSettings.LBLBackColor2.BackColor = My.Settings.BackgroundColor
			FrmSettings.LBLButtonColor2.BackColor = My.Settings.ButtonColor
			FrmSettings.LBLTextColor2.BackColor = My.Settings.TextColor
			FrmSettings.LBLChatWindowColor2.BackColor = My.Settings.ChatWindowColor
			FrmSettings.LBLChatTextColor2.BackColor = My.Settings.ChatTextColor
			FrmSettings.LBLDateTimeColor2.BackColor = My.Settings.DateTextColor
			FrmSettings.LBLDateBackColor2.BackColor = My.Settings.DateBackColor
		Catch
		End Try

		chatBox.BackColor = My.Settings.ChatWindowColor
		ChatBox2.BackColor = My.Settings.ChatWindowColor
		ImageFolderComboBox.BackColor = My.Settings.ChatWindowColor
		chatBox.ForeColor = My.Settings.ChatTextColor
		ChatBox2.ForeColor = My.Settings.ChatTextColor
		ImageFolderComboBox.ForeColor = My.Settings.ChatTextColor

		LBLDate.ForeColor = My.Settings.DateTextColor
		LBLTime.ForeColor = My.Settings.DateTextColor

		Try
			FrmSettings.CBTransparentTime.Checked = My.Settings.CBDateTransparent

			If FrmSettings.CBTransparentTime.Checked = True Then
				PNLDate.BackColor = Color.Transparent
			Else
				PNLDate.BackColor = My.Settings.DateBackColor
			End If
		Catch
		End Try

		' github patch
		StatusUpdates.DocumentText = "<body bgcolor=""" & Color2Html(My.Settings.ChatWindowColor) & """>" & StatusUpdates.DocumentText & "</body>"
		ssh_Chat = "<body bgcolor=""" & Color2Html(My.Settings.ChatWindowColor) & """>" & ssh_Chat & "</body>"
		ChatText.DocumentText = ssh_Chat
		ChatText2.DocumentText = ssh_Chat
		ChatReadyState()

		Try
			FrmSettings.CBStretchBack.Checked = My.Settings.BackgroundStretch

			If FrmSettings.CBStretchBack.Checked = True Then
				Me.BackgroundImageLayout = ImageLayout.Stretch
			Else
				Me.BackgroundImageLayout = ImageLayout.None
			End If
		Catch
		End Try

		PNLTabs.BackColor = My.Settings.BackgroundColor
		PNLDomTagBTN.BackColor = My.Settings.BackgroundColor
		PNLLazySub.BackColor = My.Settings.BackgroundColor
		PNLLazySub2.BackColor = My.Settings.BackgroundColor
		PNLAppRandomizer.BackColor = My.Settings.BackgroundColor
		PNLPlaylist.BackColor = My.Settings.BackgroundColor
		PNLWritingTask.BackColor = My.Settings.BackgroundColor
		PNLWishlistHeader.BackColor = My.Settings.BackgroundColor
		PNLWishlistTokenBack.BackColor = My.Settings.BackgroundColor
		PNLMetronome.BackColor = My.Settings.BackgroundColor

		PNLHypnoGen.BackColor = My.Settings.BackgroundColor

		CBHypnoGenInduction.ForeColor = My.Settings.TextColor
		LBLHypnoFile.ForeColor = My.Settings.TextColor
		CBHypnoGenSlideshow.ForeColor = My.Settings.TextColor
		LBLHypnoImageTag.ForeColor = My.Settings.TextColor
		LBLBackTrack.ForeColor = My.Settings.TextColor
		CBHypnoGenNoText.ForeColor = My.Settings.TextColor
		CBHypnoGenPhase.ForeColor = My.Settings.TextColor

		BTNHypnoGenStart.ForeColor = My.Settings.TextColor
		BTNHypnoGenStart.BackColor = My.Settings.ButtonColor

		AppPanelVitalSub.BackColor = My.Settings.BackgroundColor

		CBVitalSubDomTask.ForeColor = My.Settings.TextColor
		GBGoals.ForeColor = My.Settings.TextColor
		GBCalories.ForeColor = My.Settings.TextColor
		LBLConsumed.ForeColor = My.Settings.TextColor
		LBLGoal.ForeColor = My.Settings.TextColor
		LBLCalorie.ForeColor = My.Settings.TextColor
		TBCalorie.ForeColor = My.Settings.TextColor
		TBCalorie.BackColor = My.Settings.BackgroundColor

		BTNExercise.BackColor = My.Settings.ButtonColor
		BTNCalorie.BackColor = My.Settings.ButtonColor
		BTNExercise.ForeColor = My.Settings.TextColor
		BTNCalorie.ForeColor = My.Settings.TextColor

		BTNMetroPreview1.BackColor = My.Settings.ButtonColor
		BTNMetroPreview2.BackColor = My.Settings.ButtonColor
		BTNMetroStop1.BackColor = My.Settings.ButtonColor
		BTNMetroStop2.BackColor = My.Settings.ButtonColor

		BTNMetroPreview1.ForeColor = My.Settings.TextColor
		BTNMetroPreview2.ForeColor = My.Settings.TextColor
		BTNMetroStop1.ForeColor = My.Settings.TextColor
		BTNMetroStop2.ForeColor = My.Settings.TextColor

		CBMetronome.ForeColor = My.Settings.TextColor
		LBLMaxSpeed.ForeColor = My.Settings.TextColor
		LBLMinSpeed.ForeColor = My.Settings.TextColor
		LBLLow.ForeColor = My.Settings.TextColor
		LBLHigh.ForeColor = My.Settings.TextColor


		BTNLS1Edit.BackColor = My.Settings.ButtonColor
		BTNLS1Edit.ForeColor = My.Settings.TextColor
		BTNLS2Edit.BackColor = My.Settings.ButtonColor
		BTNLS2Edit.ForeColor = My.Settings.TextColor
		BTNLS3Edit.BackColor = My.Settings.ButtonColor
		BTNLS3Edit.ForeColor = My.Settings.TextColor
		BTNLS4Edit.BackColor = My.Settings.ButtonColor
		BTNLS4Edit.ForeColor = My.Settings.TextColor
		BTNLS5Edit.BackColor = My.Settings.ButtonColor
		BTNLS5Edit.ForeColor = My.Settings.TextColor


		Try
			If FrmSettings.CBFlipBack.Checked = True Then


				Dim BGIMage As Image = CType(Bitmap.FromFile(My.Settings.BackgroundImage), Bitmap)
				BGIMage.RotateFlip(RotateFlipType.Rotate180FlipY)

				BackgroundImage = BGIMage
				FrmSettings.PBBackgroundPreview.Image = BGIMage



			Else


				BackgroundImage = Image.FromFile(My.Settings.BackgroundImage)
				FrmSettings.PBBackgroundPreview.Image = Image.FromFile(My.Settings.BackgroundImage)

			End If

		Catch
		End Try

		ssh_ApplyingTheme = False


        'TabControl1.DefaultBackColor = My.Settings.BackgroundColor

    End Sub












	Public Sub OpenApp()

		PNLTabs.Height = Me.Height - 429

		AdjustWindow()

	End Sub

	Public Sub CloseApp()

		PNLDomTagBTN.Visible = False
		StatusUpdates.Visible = False
		If SideChatToolStripMenuItem1.Checked = False Then
			ChatText2.Visible = False
			PNLChatBox2.Visible = False
		Else
			ChatText2.SendToBack()
			PNLChatBox2.SendToBack()
		End If
		PNLLazySub.Visible = False
		PNLLazySub2.Visible = False
		PNLAppRandomizer.Visible = False
		PNLPlaylist.Visible = False
		PNLWritingTask.Visible = False
		PNLWishList.Visible = False
		PNLHypnoGen.Visible = False
		AppPanelVitalSub.Visible = False
		PNLMetronome.Visible = False

		If ChatText2.Visible = False Then
			PNLTabs.Height = 0
		Else
			OpenApp()
		End If


		AdjustWindow()
	End Sub

#Region "------------------------------------------------------- Apps ---------------------------------------------------------"

#Region "--------------------------------------------------- DommeTag APP -----------------------------------------------------"

#Region "------------------------------------------------- Regular Buttons-----------------------------------------------------"

	Private Sub Face_Click(sender As System.Object, e As System.EventArgs) Handles Face.Click
		Debug.Print(mainPictureBox.ImageLocation)
		If ssh_SlideshowLoaded = False Then Return
		If Face.BackColor = Color.White Then
			AddDommeTag("Face", "Nothing")
			Face.BackColor = Color.ForestGreen
			Face.ForeColor = Color.White
		Else
			RemoveDommeTag("Face", "Nothing")
			Face.BackColor = Color.White
			Face.ForeColor = Color.Black
		End If
	End Sub

	Private Sub Boobs_Click(sender As System.Object, e As System.EventArgs) Handles Boobs.Click
		Debug.Print(mainPictureBox.ImageLocation)
		If ssh_SlideshowLoaded = False Then Return
		If Boobs.BackColor = Color.White Then
			AddDommeTag("Boobs", "Nothing")
			Boobs.BackColor = Color.ForestGreen
			Boobs.ForeColor = Color.White
		Else
			RemoveDommeTag("Boobs", "Nothing")
			Boobs.BackColor = Color.White
			Boobs.ForeColor = Color.Black
		End If
	End Sub

	Private Sub Pussy_Click(sender As System.Object, e As System.EventArgs) Handles Pussy.Click
		Debug.Print(mainPictureBox.ImageLocation)
		If ssh_SlideshowLoaded = False Then Return
		If Pussy.BackColor = Color.White Then
			AddDommeTag("Pussy", "Nothing")
			Pussy.BackColor = Color.ForestGreen
			Pussy.ForeColor = Color.White
		Else
			RemoveDommeTag("Pussy", "Nothing")
			Pussy.BackColor = Color.White
			Pussy.ForeColor = Color.Black
		End If
	End Sub

	Private Sub Ass_Click(sender As System.Object, e As System.EventArgs) Handles Ass.Click
		Debug.Print(mainPictureBox.ImageLocation)
		If ssh_SlideshowLoaded = False Then Return
		If Ass.BackColor = Color.White Then
			AddDommeTag("Ass", "Nothing")
			Ass.BackColor = Color.ForestGreen
			Ass.ForeColor = Color.White
		Else
			RemoveDommeTag("Ass", "Nothing")
			Ass.BackColor = Color.White
			Ass.ForeColor = Color.Black
		End If
	End Sub

	Private Sub Legs_Click(sender As System.Object, e As System.EventArgs) Handles Legs.Click
		Debug.Print(mainPictureBox.ImageLocation)
		If ssh_SlideshowLoaded = False Then Return
		If Legs.BackColor = Color.White Then
			AddDommeTag("Legs", "Nothing")
			Legs.BackColor = Color.ForestGreen
			Legs.ForeColor = Color.White
		Else
			RemoveDommeTag("Legs", "Nothing")
			Legs.BackColor = Color.White
			Legs.ForeColor = Color.Black
		End If
	End Sub

	Private Sub Feet_Click(sender As System.Object, e As System.EventArgs) Handles Feet.Click
		Debug.Print(mainPictureBox.ImageLocation)
		If ssh_SlideshowLoaded = False Then Return
		If Feet.BackColor = Color.White Then
			AddDommeTag("Feet", "Nothing")
			Feet.BackColor = Color.ForestGreen
			Feet.ForeColor = Color.White
		Else
			RemoveDommeTag("Feet", "Nothing")
			Feet.BackColor = Color.White
			Feet.ForeColor = Color.Black
		End If
	End Sub

	Private Sub FullyDressed_Click(sender As System.Object, e As System.EventArgs) Handles FullyDressed.Click
		Debug.Print(mainPictureBox.ImageLocation)
		If ssh_SlideshowLoaded = False Then Return
		If FullyDressed.BackColor = Color.White Then
			AddDommeTag("FullyDressed", "Nothing")
			FullyDressed.BackColor = Color.ForestGreen
			FullyDressed.ForeColor = Color.White
		Else
			RemoveDommeTag("FullyDressed", "Nothing")
			FullyDressed.BackColor = Color.White
			FullyDressed.ForeColor = Color.Black
		End If
	End Sub

	Private Sub HalfDressed_Click(sender As System.Object, e As System.EventArgs) Handles HalfDressed.Click
		Debug.Print(mainPictureBox.ImageLocation)
		If ssh_SlideshowLoaded = False Then Return
		If HalfDressed.BackColor = Color.White Then
			AddDommeTag("HalfDressed", "Nothing")
			HalfDressed.BackColor = Color.ForestGreen
			HalfDressed.ForeColor = Color.White
		Else
			RemoveDommeTag("HalfDressed", "Nothing")
			HalfDressed.BackColor = Color.White
			HalfDressed.ForeColor = Color.Black
		End If
	End Sub

	Private Sub GarmentCovering_Click(sender As System.Object, e As System.EventArgs) Handles GarmentCovering.Click
		Debug.Print(mainPictureBox.ImageLocation)
		If ssh_SlideshowLoaded = False Then Return
		If GarmentCovering.BackColor = Color.White Then
			AddDommeTag("GarmentCovering", "Nothing")
			GarmentCovering.BackColor = Color.ForestGreen
			GarmentCovering.ForeColor = Color.White
		Else
			RemoveDommeTag("GarmentCovering", "Nothing")
			GarmentCovering.BackColor = Color.White
			GarmentCovering.ForeColor = Color.Black
		End If
	End Sub

	Private Sub HandsCovering_Click(sender As System.Object, e As System.EventArgs) Handles HandsCovering.Click
		Debug.Print(mainPictureBox.ImageLocation)
		If ssh_SlideshowLoaded = False Then Return
		If HandsCovering.BackColor = Color.White Then
			AddDommeTag("HandsCovering", "Nothing")
			HandsCovering.BackColor = Color.ForestGreen
			HandsCovering.ForeColor = Color.White
		Else
			RemoveDommeTag("HandsCovering", "Nothing")
			HandsCovering.BackColor = Color.White
			HandsCovering.ForeColor = Color.Black
		End If
	End Sub

	Private Sub Naked_Click(sender As System.Object, e As System.EventArgs) Handles Naked.Click
		Debug.Print(mainPictureBox.ImageLocation)
		If ssh_SlideshowLoaded = False Then Return
		If Naked.BackColor = Color.White Then
			AddDommeTag("Naked", "Nothing")
			Naked.BackColor = Color.ForestGreen
			Naked.ForeColor = Color.White
		Else
			RemoveDommeTag("Naked", "Nothing")
			Naked.BackColor = Color.White
			Naked.ForeColor = Color.Black
		End If
	End Sub

	Private Sub Masturbating_Click(sender As System.Object, e As System.EventArgs) Handles Masturbating.Click
		Debug.Print(mainPictureBox.ImageLocation)
		If ssh_SlideshowLoaded = False Then Return
		If Masturbating.BackColor = Color.White Then
			AddDommeTag("Masturbating", "Nothing")
			Masturbating.BackColor = Color.ForestGreen
			Masturbating.ForeColor = Color.White
		Else
			RemoveDommeTag("Masturbating", "Nothing")
			Masturbating.BackColor = Color.White
			Masturbating.ForeColor = Color.Black
		End If
	End Sub

	Private Sub Sucking_Click(sender As System.Object, e As System.EventArgs) Handles Sucking.Click
		Debug.Print(mainPictureBox.ImageLocation)
		If ssh_SlideshowLoaded = False Then Return
		If Sucking.BackColor = Color.White Then
			AddDommeTag("Sucking", "Nothing")
			Sucking.BackColor = Color.ForestGreen
			Sucking.ForeColor = Color.White
		Else
			RemoveDommeTag("Sucking", "Nothing")
			Sucking.BackColor = Color.White
			Sucking.ForeColor = Color.Black
		End If
	End Sub

	Private Sub Smiling_Click(sender As System.Object, e As System.EventArgs) Handles Smiling.Click
		Debug.Print(mainPictureBox.ImageLocation)
		If ssh_SlideshowLoaded = False Then Return
		If Smiling.BackColor = Color.White Then
			AddDommeTag("Smiling", "Nothing")
			Smiling.BackColor = Color.ForestGreen
			Smiling.ForeColor = Color.White
		Else
			RemoveDommeTag("Smiling", "Nothing")
			Smiling.BackColor = Color.White
			Smiling.ForeColor = Color.Black
		End If
	End Sub

	Private Sub Glaring_Click(sender As System.Object, e As System.EventArgs) Handles Glaring.Click
		Debug.Print(mainPictureBox.ImageLocation)
		If ssh_SlideshowLoaded = False Then Return
		If Glaring.BackColor = Color.White Then
			AddDommeTag("Glaring", "Nothing")
			Glaring.BackColor = Color.ForestGreen
			Glaring.ForeColor = Color.White
		Else
			RemoveDommeTag("Glaring", "Nothing")
			Glaring.BackColor = Color.White
			Glaring.ForeColor = Color.Black
		End If
	End Sub

	Private Sub SideView_Click(sender As System.Object, e As System.EventArgs) Handles SideView.Click
		Debug.Print(mainPictureBox.ImageLocation)
		If ssh_SlideshowLoaded = False Then Return
		If SideView.BackColor = Color.White Then
			AddDommeTag("SideView", "Nothing")
			SideView.BackColor = Color.ForestGreen
			SideView.ForeColor = Color.White
		Else
			RemoveDommeTag("SideView", "Nothing")
			SideView.BackColor = Color.White
			SideView.ForeColor = Color.Black
		End If
	End Sub

	Private Sub CloseUp_Click(sender As System.Object, e As System.EventArgs) Handles CloseUp.Click
		Debug.Print(mainPictureBox.ImageLocation)
		If ssh_SlideshowLoaded = False Then Return
		If CloseUp.BackColor = Color.White Then
			AddDommeTag("CloseUp", "Nothing")
			CloseUp.BackColor = Color.ForestGreen
			CloseUp.ForeColor = Color.White
		Else
			RemoveDommeTag("CloseUp", "Nothing")
			CloseUp.BackColor = Color.White
			CloseUp.ForeColor = Color.Black
		End If
	End Sub

	Private Sub SeeThrough_Click(sender As System.Object, e As System.EventArgs) Handles SeeThrough.Click
		Debug.Print(mainPictureBox.ImageLocation)
		If ssh_SlideshowLoaded = False Then Return
		If SeeThrough.BackColor = Color.White Then
			AddDommeTag("SeeThrough", "Nothing")
			SeeThrough.BackColor = Color.ForestGreen
			SeeThrough.ForeColor = Color.White
		Else
			RemoveDommeTag("SeeThrough", "Nothing")
			SeeThrough.BackColor = Color.White
			SeeThrough.ForeColor = Color.Black
		End If
	End Sub

	Private Sub AllFours_Click(sender As System.Object, e As System.EventArgs) Handles AllFours.Click
		Debug.Print(mainPictureBox.ImageLocation)
		If ssh_SlideshowLoaded = False Then Return
		If AllFours.BackColor = Color.White Then
			AddDommeTag("AllFours", "Nothing")
			AllFours.BackColor = Color.ForestGreen
			AllFours.ForeColor = Color.White
		Else
			RemoveDommeTag("AllFours", "Nothing")
			AllFours.BackColor = Color.White
			AllFours.ForeColor = Color.Black
		End If
	End Sub


	Private Sub Piercing_Click(sender As System.Object, e As System.EventArgs) Handles Piercing.Click
		Debug.Print(mainPictureBox.ImageLocation)
		If ssh_SlideshowLoaded = False Then Return
		If Piercing.BackColor = Color.White Then
			AddDommeTag("Piercing", "Nothing")
			Piercing.BackColor = Color.ForestGreen
			Piercing.ForeColor = Color.White
		Else
			RemoveDommeTag("Piercing", "Nothing")
			Piercing.BackColor = Color.White
			Piercing.ForeColor = Color.Black
		End If
	End Sub

	Private Sub TBGarment_TextChanged(sender As System.Object, e As System.EventArgs) Handles TBGarment.TextChanged
		If ssh_SlideshowLoaded = False Or TBGarment.Focused = False Then Return
		If TBGarment.Text = "" Then
			Garment.BackColor = Color.White
			Garment.ForeColor = Color.Black
			RemoveDommeTag("Garment", "Nothing")
		Else
			Garment.BackColor = Color.ForestGreen
			Garment.ForeColor = Color.White
			AddDommeTag("Garment", TBGarment.Text)
		End If
	End Sub

	Private Sub TBUnderwear_TextChanged(sender As System.Object, e As System.EventArgs) Handles TBUnderwear.TextChanged
		If ssh_SlideshowLoaded = False Or TBUnderwear.Focused = False Then Return
		If TBUnderwear.Text = "" Then
			Underwear.BackColor = Color.White
			Underwear.ForeColor = Color.Black
			RemoveDommeTag("Underwear", "Nothing")
		Else
			Underwear.BackColor = Color.ForestGreen
			Underwear.ForeColor = Color.White
			AddDommeTag("Underwear", TBUnderwear.Text)
		End If
	End Sub

	Private Sub TBTattoo_TextChanged(sender As System.Object, e As System.EventArgs) Handles TBTattoo.TextChanged
		If ssh_SlideshowLoaded = False Or TBTattoo.Focused = False Then Return
		If TBTattoo.Text = "" Then
			Tattoo.BackColor = Color.White
			Tattoo.ForeColor = Color.Black
			RemoveDommeTag("Tattoo", "Nothing")
		Else
			Tattoo.BackColor = Color.ForestGreen
			Tattoo.ForeColor = Color.White
			AddDommeTag("Tattoo", TBTattoo.Text)
		End If
	End Sub

	Private Sub TBSexToy_TextChanged(sender As System.Object, e As System.EventArgs) Handles TBSexToy.TextChanged
		If ssh_SlideshowLoaded = False Or TBSexToy.Focused = False Then Return
		If TBSexToy.Text = "" Then
			SexToy.BackColor = Color.White
			SexToy.ForeColor = Color.Black
			RemoveDommeTag("SexToy", "Nothing")
		Else
			SexToy.BackColor = Color.ForestGreen
			SexToy.ForeColor = Color.White
			AddDommeTag("SexToy", TBSexToy.Text)
		End If
	End Sub


	Private Sub TBFurniture_TextChanged(sender As System.Object, e As System.EventArgs) Handles TBFurniture.TextChanged
		If ssh_SlideshowLoaded = False Or TBFurniture.Focused = False Then Return
		If TBFurniture.Text = "" Then
			Furniture.BackColor = Color.White
			Furniture.ForeColor = Color.Black
			RemoveDommeTag("Furniture", "Nothing")
		Else
			Furniture.BackColor = Color.ForestGreen
			Furniture.ForeColor = Color.White
			AddDommeTag("Furniture", TBFurniture.Text)
		End If
	End Sub

#End Region ' Regular Buttons


	Public Function AddDommeTag(ByVal AddDomTag As String, ByVal AddCustomDomTag As String)
		Dim DomTag As String = "Tag" & AddDomTag
		Dim Custom As String
		If AddCustomDomTag = "Nothing" Then
			Custom = ""
		Else
			Custom = AddCustomDomTag
		End If

		Debug.Print("DomTag = " & DomTag)
		Debug.Print("Custom = " & Custom)


		'Dim TagFile As String = Path.GetDirectoryName(_ImageFileNames(FileCount)) & "\ImageTags.txt"
		Dim TagFile As String = Path.GetDirectoryName(ssh_ImageLocation) & "\ImageTags.txt"

		If File.Exists(TagFile) Then

			Dim TagList As New List(Of String)
			TagList = Txt2List(TagFile)

			Dim FoundFile As Boolean = False

			For i As Integer = 0 To TagList.Count - 1
				If TagList(i).Contains(Path.GetFileName(ssh_ImageLocation)) Then
					FoundFile = True
					If Not TagList(i).Contains(DomTag) Then
						TagList(i) = TagList(i) & " " & DomTag & Custom

					Else

						If DomTag = "TagGarment" Or DomTag = "TagUnderwear" Or DomTag = "TagTattoo" Or DomTag = "TagSexToy" Or DomTag = "TagFurniture" Then

							Dim CustomArray As String() = TagList(i).Split

							For x As Integer = 0 To CustomArray.Count - 1
								Debug.Print("CustomArray(x) = " & CustomArray(x))
								If CustomArray(x).Contains(DomTag) Then
									If DomTag = "TagGarment" And CustomArray(x).Contains("TagGarment") And Not CustomArray(x).Contains("TagGarmentCovering") Then TagList(i) = TagList(i).Replace(CustomArray(x), "")
									If DomTag = "TagUnderwear" And CustomArray(x).Contains("TagUnderwear") Then TagList(i) = TagList(i).Replace(CustomArray(x), "")
									If DomTag = "TagTattoo" And CustomArray(x).Contains("TagTattoo") Then TagList(i) = TagList(i).Replace(CustomArray(x), "")
									If DomTag = "TagSexToy" And CustomArray(x).Contains("TagSexToy") Then TagList(i) = TagList(i).Replace(CustomArray(x), "")
									If DomTag = "TagFurniture" And CustomArray(x).Contains("TagFurniture") Then TagList(i) = TagList(i).Replace(CustomArray(x), "")
								End If
							Next

							TagList(i) = TagList(i) & " " & DomTag & Custom
							TagList(i) = TagList(i).Replace("  ", " ")

						End If




					End If
				End If
			Next

			If FoundFile = False Then TagList.Add(Path.GetFileName(ssh_ImageLocation) & " " & DomTag & Custom)

			If TagList.Count > 0 Then
				Dim SettingsString As String = ""
				For i As Integer = 0 To TagList.Count - 1
					SettingsString = SettingsString & TagList(i)
					If i <> TagList.Count - 1 Then SettingsString = SettingsString & Environment.NewLine
				Next
				My.Computer.FileSystem.WriteAllText(Path.GetDirectoryName(ssh_ImageLocation) & "\ImageTags.txt", SettingsString, False)
			End If

		ElseIf Path.GetDirectoryName(ssh__ImageFileNames(ssh_FileCount)) = Path.GetDirectoryName(ssh_ImageLocation)
			' Only Create new file for the loaded Slidshow. This Prevents URL-Image-Tagging.
			My.Computer.FileSystem.WriteAllText(Path.GetDirectoryName(ssh_ImageLocation) & "\ImageTags.txt", Path.GetFileName(ssh_ImageLocation) & " " & DomTag & Custom, True)

		End If

	End Function

	Public Function RemoveDommeTag(ByVal RemoveDomTag As String, ByVal RemoveCustomDomTag As String)
		Dim DomTag As String = "Tag" & RemoveDomTag
		Dim Custom As String
		If RemoveCustomDomTag = "Nothing" Then
			Custom = ""
		Else
			Custom = RemoveCustomDomTag
		End If

		Dim SettingsString As String
		'Dim TagFile As String = Path.GetDirectoryName(_ImageFileNames(FileCount)) & "\ImageTags.txt"
		Dim TagFile As String = Path.GetDirectoryName(ssh_ImageLocation) & "\ImageTags.txt"
		Debug.Print("TagFile = " & TagFile)

		Debug.Print("DomTag & Custom = " & DomTag & Custom)

		If File.Exists(TagFile) Then

			Dim TagList As New List(Of String)
			TagList = Txt2List(TagFile)

			For i As Integer = TagList.Count - 1 To 0 Step -1
				If TagList(i).Contains(Path.GetFileName(ssh_ImageLocation)) Then
					If TagList(i).Contains(DomTag & Custom) Then

						If DomTag = "TagGarment" Or DomTag = "TagUnderwear" Or DomTag = "TagTattoo" Or DomTag = "TagSexToy" Or DomTag = "TagFurniture" Then

							Dim CustomArray As String() = TagList(i).Split

							For x As Integer = 0 To CustomArray.Count - 1
								If CustomArray(x).Contains(DomTag) Then
									If DomTag = "TagGarment" And CustomArray(x).Contains("TagGarment") And Not CustomArray(x).Contains("TagGarmentCovering") Then TagList(i) = TagList(i).Replace(CustomArray(x), "")
									If DomTag = "TagUnderwear" And CustomArray(x).Contains("TagUnderwear") Then TagList(i) = TagList(i).Replace(CustomArray(x), "")
									If DomTag = "TagTattoo" And CustomArray(x).Contains("TagTattoo") Then TagList(i) = TagList(i).Replace(CustomArray(x), "")
									If DomTag = "TagSexToy" And CustomArray(x).Contains("TagSexToy") Then TagList(i) = TagList(i).Replace(CustomArray(x), "")
									If DomTag = "TagFurniture" And CustomArray(x).Contains("TagFurniture") Then TagList(i) = TagList(i).Replace(CustomArray(x), "")
								End If
							Next
						Else

							TagList(i) = TagList(i).Replace(" " & DomTag & Custom, "")
						End If


						If Not TagList(i).Contains(" Tag") Then TagList.Remove(TagList(i))
					End If
				End If
			Next

			If TagList.Count > 0 Then
				SettingsString = ""
				For i As Integer = 0 To TagList.Count - 1
					SettingsString = SettingsString & TagList(i)
					If i <> TagList.Count - 1 Then SettingsString = SettingsString & Environment.NewLine
				Next
				My.Computer.FileSystem.WriteAllText(Path.GetDirectoryName(ssh_ImageLocation) & "\ImageTags.txt", SettingsString, False)
			Else
				If File.Exists(Path.GetDirectoryName(ssh_ImageLocation) & "\ImageTags.txt") Then My.Computer.FileSystem.DeleteFile(Path.GetDirectoryName(ssh_ImageLocation) & "\ImageTags.txt")
			End If

		End If




	End Function

	Private Sub BtnDommeTagNextImage_Click(sender As System.Object, e As System.EventArgs) Handles DommeTagBtnNextImage.Click
		nextButton.PerformClick()
	End Sub

	Private Sub BtnDommeTagLastImage_Click(sender As System.Object, e As System.EventArgs) Handles DommeTagBtnLastImage.Click
		previousButton.PerformClick()
	End Sub

	''' <summary>
	''' <para>In Order to Work, this function has to be called AFTER an Image has been loaded into the 
	''' <see cref="Form1.mainPictureBox">PictureBox</see>. Everthing else doesn't work properly.</para>
	''' <para>Right now there are only two working non-UI-Freezing posibilities: The Imagebox 
	''' LoadCompleted-Event and PBImageThread. In PBImageThread an Invoke is required!</para>
	''' This Function uses the <see cref="form1.ssh_ImageLocation">ImageLocation</see> Variable to get the
	''' current ImageFilePath. 
	''' </summary>
	''' <remarks>
	''' To Raise the PictureBoxCompleted-Event, you have to load an Image via LoadAsync(URL).
	''' </remarks>
	Public Sub CheckDommeTags()

		Face.BackColor = Color.White
		Face.ForeColor = Color.Black

		Boobs.BackColor = Color.White
		Boobs.ForeColor = Color.Black

		Pussy.BackColor = Color.White
		Pussy.ForeColor = Color.Black

		Ass.BackColor = Color.White
		Ass.ForeColor = Color.Black

		Legs.BackColor = Color.White
		Legs.ForeColor = Color.Black

		Feet.BackColor = Color.White
		Feet.ForeColor = Color.Black

		FullyDressed.BackColor = Color.White
		FullyDressed.ForeColor = Color.Black

		HalfDressed.BackColor = Color.White
		HalfDressed.ForeColor = Color.Black

		GarmentCovering.BackColor = Color.White
		GarmentCovering.ForeColor = Color.Black

		HandsCovering.BackColor = Color.White
		HandsCovering.ForeColor = Color.Black

		Naked.BackColor = Color.White
		Naked.ForeColor = Color.Black

		Masturbating.BackColor = Color.White
		Masturbating.ForeColor = Color.Black

		Sucking.BackColor = Color.White
		Sucking.ForeColor = Color.Black

		Smiling.BackColor = Color.White
		Smiling.ForeColor = Color.Black

		Glaring.BackColor = Color.White
		Glaring.ForeColor = Color.Black

		SideView.BackColor = Color.White
		SideView.ForeColor = Color.Black

		CloseUp.BackColor = Color.White
		CloseUp.ForeColor = Color.Black

		SeeThrough.BackColor = Color.White
		SeeThrough.ForeColor = Color.Black

		AllFours.BackColor = Color.White
		AllFours.ForeColor = Color.Black

		Piercing.BackColor = Color.White
		Piercing.ForeColor = Color.Black

		Garment.BackColor = Color.White
		Garment.ForeColor = Color.Black

		Underwear.BackColor = Color.White
		Underwear.ForeColor = Color.Black

		Tattoo.BackColor = Color.White
		Tattoo.ForeColor = Color.Black

		SexToy.BackColor = Color.White
		SexToy.ForeColor = Color.Black

		Furniture.BackColor = Color.White
		Furniture.ForeColor = Color.Black

		TBGarment.Text = ""
		TBUnderwear.Text = ""
		TBTattoo.Text = ""
		TBSexToy.Text = ""
		TBFurniture.Text = ""

		If ssh_ImageLocation = "" Then Exit Sub

		Dim tmpFileName As String = Path.GetFileName(ssh_ImageLocation)

		Dim TagFile As String = Path.GetDirectoryName(ssh_ImageLocation) & "\ImageTags.txt"

		If File.Exists(TagFile) Then

			Dim TagList As New List(Of String)
			TagList = Txt2List(TagFile)

			For i As Integer = TagList.Count - 1 To 0 Step -1

				If TagList(i).Contains(tmpFileName) Then
					If TagList(i).Contains("TagFace") Then
						Face.BackColor = Color.ForestGreen
						Face.ForeColor = Color.White
					End If

					If TagList(i).Contains("TagBoobs") Then
						Boobs.BackColor = Color.ForestGreen
						Boobs.ForeColor = Color.White
					End If

					If TagList(i).Contains("TagPussy") Then
						Pussy.BackColor = Color.ForestGreen
						Pussy.ForeColor = Color.White
					End If

					If TagList(i).Contains("TagAss") Then
						Ass.BackColor = Color.ForestGreen
						Ass.ForeColor = Color.White
					End If

					If TagList(i).Contains("TagLegs") Then
						Legs.BackColor = Color.ForestGreen
						Legs.ForeColor = Color.White
					End If

					If TagList(i).Contains("TagFeet") Then
						Feet.BackColor = Color.ForestGreen
						Feet.ForeColor = Color.White
					End If

					If TagList(i).Contains("TagFullyDressed") Then
						FullyDressed.BackColor = Color.ForestGreen
						FullyDressed.ForeColor = Color.White
					End If

					If TagList(i).Contains("TagHalfDressed") Then
						HalfDressed.BackColor = Color.ForestGreen
						HalfDressed.ForeColor = Color.White
					End If

					If TagList(i).Contains("TagGarmentCovering") Then
						GarmentCovering.BackColor = Color.ForestGreen
						GarmentCovering.ForeColor = Color.White
					End If

					If TagList(i).Contains("TagHandsCovering") Then
						HandsCovering.BackColor = Color.ForestGreen
						HandsCovering.ForeColor = Color.White
					End If

					If TagList(i).Contains("TagNaked") Then
						Naked.BackColor = Color.ForestGreen
						Naked.ForeColor = Color.White
					End If

					If TagList(i).Contains("TagMasturbating") Then
						Masturbating.BackColor = Color.ForestGreen
						Masturbating.ForeColor = Color.White
					End If

					If TagList(i).Contains("TagSucking") Then
						Sucking.BackColor = Color.ForestGreen
						Sucking.ForeColor = Color.White
					End If

					If TagList(i).Contains("TagSmiling") Then
						Smiling.BackColor = Color.ForestGreen
						Smiling.ForeColor = Color.White
					End If

					If TagList(i).Contains("TagGlaring") Then
						Glaring.BackColor = Color.ForestGreen
						Glaring.ForeColor = Color.White
					End If

					If TagList(i).Contains("TagSideView") Then
						SideView.BackColor = Color.ForestGreen
						SideView.ForeColor = Color.White
					End If

					If TagList(i).Contains("TagSeeThrough") Then
						SeeThrough.BackColor = Color.ForestGreen
						SeeThrough.ForeColor = Color.White
					End If

					If TagList(i).Contains("TagAllFours") Then
						AllFours.BackColor = Color.ForestGreen
						AllFours.ForeColor = Color.White
					End If

					If TagList(i).Contains("TagCloseUp") Then
						CloseUp.BackColor = Color.ForestGreen
						CloseUp.ForeColor = Color.White
					End If

					If TagList(i).Contains("TagPiercing") Then
						Piercing.BackColor = Color.ForestGreen
						Piercing.ForeColor = Color.White
					End If

					If TagList(i).Contains("TagGarment") Then
						Dim GarmentArray As String() = TagList(i).Split
						For x As Integer = 0 To GarmentArray.Count - 1
							Debug.Print("GarmentArray(x) = " & GarmentArray(x))
							If GarmentArray(x).Contains("TagGarment") And Not GarmentArray(x).Contains("TagGarmentCovering") Then
								Garment.BackColor = Color.ForestGreen
								Garment.ForeColor = Color.White
								TBGarment.Text = GarmentArray(x).Replace("TagGarment", "")
							End If
						Next

					End If

					If TagList(i).Contains("TagUnderwear") Then

						Dim UnderwearArray As String() = TagList(i).Split
						For x As Integer = 0 To UnderwearArray.Count - 1
							If UnderwearArray(x).Contains("TagUnderwear") Then
								Underwear.BackColor = Color.ForestGreen
								Underwear.ForeColor = Color.White
								TBUnderwear.Text = UnderwearArray(x).Replace("TagUnderwear", "")
							End If
						Next

					End If

					If TagList(i).Contains("TagTattoo") Then
						Dim TattooArray As String() = TagList(i).Split
						For x As Integer = 0 To TattooArray.Count - 1
							If TattooArray(x).Contains("TagTattoo") Then
								Tattoo.BackColor = Color.ForestGreen
								Tattoo.ForeColor = Color.White
								TBTattoo.Text = TattooArray(x).Replace("TagTattoo", "")
							End If
						Next

					End If

					If TagList(i).Contains("TagSexToy") Then
						Dim SexToyArray As String() = TagList(i).Split
						For x As Integer = 0 To SexToyArray.Count - 1
							If SexToyArray(x).Contains("TagSexToy") Then
								SexToy.BackColor = Color.ForestGreen
								SexToy.ForeColor = Color.White
								TBSexToy.Text = SexToyArray(x).Replace("TagSexToy", "")
							End If
						Next

					End If

					If TagList(i).Contains("TagFurniture") Then
						Dim FurnitureArray As String() = TagList(i).Split
						For x As Integer = 0 To FurnitureArray.Count - 1
							If FurnitureArray(x).Contains("TagFurniture") Then
								Furniture.BackColor = Color.ForestGreen
								Furniture.ForeColor = Color.White
								TBFurniture.Text = FurnitureArray(x).Replace("TagFurniture", "")
							End If
						Next
					End If




				End If

			Next

		End If
	End Sub


#End Region ' DommeTag APP

#Region "------------------------------------------------------ Lazy-Sub ------------------------------------------------------"

	Private Sub Button25_Click(sender As System.Object, e As System.EventArgs) Handles BTNStop.Click, Button7.Click
		chatBox.Text = "Let me stop"
		sendButton.PerformClick()
	End Sub

	Private Sub BTNYes_Click(sender As System.Object, e As System.EventArgs) Handles BTNYes.Click, Button2.Click
		Try
			chatBox.Text = "Yes " & FrmSettings.TBHonorific.Text
		Catch
			chatBox.Text = "Yes"
		End Try

		sendButton.PerformClick()
	End Sub

	Private Sub BTNNo_Click(sender As System.Object, e As System.EventArgs) Handles BTNNo.Click, Button3.Click
		Try
			chatBox.Text = "No " & FrmSettings.TBHonorific.Text
		Catch
			chatBox.Text = "No"
		End Try

		sendButton.PerformClick()
	End Sub

	Private Sub BTNEdge_Click(sender As System.Object, e As System.EventArgs) Handles BTNEdge.Click, Button4.Click
		chatBox.Text = "On the edge"
		sendButton.PerformClick()
	End Sub

	Private Sub BTNSpeedUp_Click(sender As System.Object, e As System.EventArgs) Handles BTNSpeedUp.Click, Button8.Click
		chatBox.Text = "Let me speed up"
		sendButton.PerformClick()
	End Sub

	Private Sub BTNSlowDown_Click(sender As System.Object, e As System.EventArgs) Handles BTNSlowDown.Click, Button5.Click
		chatBox.Text = "Let me slow down"
		sendButton.PerformClick()
	End Sub

	Private Sub BTNStroke_Click(sender As System.Object, e As System.EventArgs) Handles BTNStroke.Click, Button6.Click
		chatBox.Text = "May I start stroking?"
		sendButton.PerformClick()
	End Sub

	Private Sub BTNAskToCum_Click(sender As System.Object, e As System.EventArgs) Handles BTNAskToCum.Click, Button9.Click
		chatBox.Text = "Please let me cum!"
		sendButton.PerformClick()
	End Sub

	Private Sub BTNGreeting_Click(sender As System.Object, e As System.EventArgs) Handles BTNGreeting.Click, Button10.Click

		If ssh_SaidHello = True Then
			ssh_LockImage = False
			If ssh_SlideshowLoaded = True Then
				nextButton.Enabled = True
				previousButton.Enabled = True
				PicStripTSMIdommeSlideshow.Enabled = True
			End If
			ssh_RapidFire = False
			Return
		End If

		Try
			chatBox.Text = "Hello " & FrmSettings.TBHonorific.Text
		Catch
			chatBox.Text = "Hello"
		End Try

		sendButton.PerformClick()
	End Sub

	Private Sub BTNSafeword_Click(sender As System.Object, e As System.EventArgs) Handles BTNSafeword.Click, Button11.Click
		Try
			chatBox.Text = FrmSettings.TBSafeword.Text
		Catch
			chatBox.Text = "@Error"
		End Try

		sendButton.PerformClick()
	End Sub

	Private Sub CBHideShortcuts_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBHideShortcuts.CheckedChanged
		If FormLoading = False Then
			GetShortcutChecked()
			My.Settings.ShowShortcuts = CBHideShortcuts.Checked
		End If
	End Sub

	Public Sub GetShortcutChecked()

		If CBHideShortcuts.Checked = True Then
			TBShortYes.Visible = False
			TBShortNo.Visible = False
			TBShortEdge.Visible = False
			TBShortSpeedUp.Visible = False
			TBShortSlowDown.Visible = False
			TBShortStop.Visible = False
			TBShortStroke.Visible = False
			TBShortCum.Visible = False
			TBShortGreet.Visible = False
			TBShortSafeword.Visible = False


			BTNLS1.Width = 214
			BTNLS2.Width = 214
			BTNLS3.Width = 214
			BTNLS4.Width = 214
			BTNLS5.Width = 214

			BTNLS1Edit.Visible = False
			BTNLS2Edit.Visible = False
			BTNLS3Edit.Visible = False
			BTNLS4Edit.Visible = False
			BTNLS5Edit.Visible = False

		Else

			TBShortYes.Visible = True
			TBShortNo.Visible = True
			TBShortEdge.Visible = True
			TBShortSpeedUp.Visible = True
			TBShortSlowDown.Visible = True
			TBShortStop.Visible = True
			TBShortStroke.Visible = True
			TBShortCum.Visible = True
			TBShortGreet.Visible = True
			TBShortSafeword.Visible = True

			BTNLS1.Width = 163
			BTNLS2.Width = 163
			BTNLS3.Width = 163
			BTNLS4.Width = 163
			BTNLS5.Width = 163

			BTNLS1Edit.Visible = True
			BTNLS2Edit.Visible = True
			BTNLS3Edit.Visible = True
			BTNLS4Edit.Visible = True
			BTNLS5Edit.Visible = True

		End If

	End Sub

	Private Sub CBShortcuts_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBShortcuts.CheckedChanged
		If FormLoading = False Then
			My.Settings.Shortcuts = CBShortcuts.Checked
		End If
	End Sub

	Private Sub TBShortYes_LostFocus(sender As Object, e As System.EventArgs) Handles TBShortYes.LostFocus
		My.Settings.ShortYes = TBShortYes.Text
	End Sub

	Private Sub TBShortNo_LostFocus(sender As Object, e As System.EventArgs) Handles TBShortNo.LostFocus
		My.Settings.ShortNo = TBShortNo.Text
	End Sub

	Private Sub TBShortEdge_LostFocus(sender As Object, e As System.EventArgs) Handles TBShortEdge.LostFocus
		My.Settings.ShortEdge = TBShortEdge.Text
	End Sub

	Private Sub TBShortSpeedUp_LostFocus(sender As Object, e As System.EventArgs) Handles TBShortSpeedUp.LostFocus
		My.Settings.ShortSpeedUp = TBShortSpeedUp.Text
	End Sub

	Private Sub TBShortSlowDown_LostFocus(sender As Object, e As System.EventArgs) Handles TBShortSlowDown.LostFocus
		My.Settings.ShortSlowDown = TBShortSlowDown.Text
	End Sub

	Private Sub TBShortStop_LostFocus(sender As Object, e As System.EventArgs) Handles TBShortStop.LostFocus
		My.Settings.ShortStop = TBShortStop.Text
	End Sub

	Private Sub TBShortStroke_LostFocus(sender As Object, e As System.EventArgs) Handles TBShortStroke.LostFocus
		My.Settings.ShortStroke = TBShortStroke.Text
	End Sub

	Private Sub TBShortCum_LostFocus(sender As Object, e As System.EventArgs) Handles TBShortCum.LostFocus
		My.Settings.ShortCum = TBShortCum.Text
	End Sub

	Private Sub TBShortGreet_LostFocus(sender As Object, e As System.EventArgs) Handles TBShortGreet.LostFocus
		My.Settings.ShortGreet = TBShortGreet.Text
	End Sub

	Private Sub TBShortSafeword_LostFocus(sender As Object, e As System.EventArgs) Handles TBShortSafeword.LostFocus
		My.Settings.ShortSafeword = TBShortSafeword.Text
	End Sub

	Public Sub CheatCheck()

		If chatBox.Text = LBLWritingTaskText.Text Then
			chatBox.Text = "I'm a dirty cheater"
		End If

	End Sub

	Private Sub BTNLS1_Click(sender As System.Object, e As System.EventArgs) Handles BTNLS1.Click


		If BTNLS1.Text <> "" Then
			chatBox.Text = BTNLS1.Text
			If ssh_WritingTaskFlag = True Then CheatCheck()
			sendButton.PerformClick()
		End If

	End Sub

	Private Sub BTNLS1Edit_Click(sender As System.Object, e As System.EventArgs) Handles BTNLS1Edit.Click


		LazyEdit2 = False
		LazyEdit3 = False
		LazyEdit4 = False
		LazyEdit5 = False

		BTNLS2Edit.BackColor = My.Settings.ButtonColor
		BTNLS2Edit.ForeColor = My.Settings.TextColor
		BTNLS3Edit.BackColor = My.Settings.ButtonColor
		BTNLS3Edit.ForeColor = My.Settings.TextColor
		BTNLS4Edit.BackColor = My.Settings.ButtonColor
		BTNLS4Edit.ForeColor = My.Settings.TextColor
		BTNLS5Edit.BackColor = My.Settings.ButtonColor
		BTNLS5Edit.ForeColor = My.Settings.TextColor


		If LazyEdit1 = False Then
			BTNLS1Edit.BackColor = Color.ForestGreen
			BTNLS1Edit.ForeColor = Color.White
			LazyEdit1 = True
		Else
			BTNLS1Edit.BackColor = My.Settings.ButtonColor
			BTNLS1Edit.ForeColor = My.Settings.TextColor
			LazyEdit1 = False
		End If

	End Sub

	Private Sub BTNLS2_Click(sender As System.Object, e As System.EventArgs) Handles BTNLS2.Click


		If BTNLS2.Text <> "" Then
			chatBox.Text = BTNLS2.Text
			If ssh_WritingTaskFlag = True Then CheatCheck()
			sendButton.PerformClick()
		End If

	End Sub

	Private Sub BTNLS2Edit_Click(sender As System.Object, e As System.EventArgs) Handles BTNLS2Edit.Click


		LazyEdit1 = False
		LazyEdit3 = False
		LazyEdit4 = False
		LazyEdit5 = False

		BTNLS1Edit.BackColor = My.Settings.ButtonColor
		BTNLS1Edit.ForeColor = My.Settings.TextColor
		BTNLS3Edit.BackColor = My.Settings.ButtonColor
		BTNLS3Edit.ForeColor = My.Settings.TextColor
		BTNLS4Edit.BackColor = My.Settings.ButtonColor
		BTNLS4Edit.ForeColor = My.Settings.TextColor
		BTNLS5Edit.BackColor = My.Settings.ButtonColor
		BTNLS5Edit.ForeColor = My.Settings.TextColor

		If LazyEdit2 = False Then
			BTNLS2Edit.BackColor = Color.ForestGreen
			BTNLS2Edit.ForeColor = Color.White
			LazyEdit2 = True
		Else
			BTNLS2Edit.BackColor = My.Settings.ButtonColor
			BTNLS2Edit.ForeColor = My.Settings.TextColor
			LazyEdit2 = False
		End If

	End Sub

	Private Sub BTNLS3_Click(sender As System.Object, e As System.EventArgs) Handles BTNLS3.Click


		If BTNLS3.Text <> "" Then
			chatBox.Text = BTNLS3.Text
			If ssh_WritingTaskFlag = True Then CheatCheck()
			sendButton.PerformClick()
		End If

	End Sub

	Private Sub BTNLS3Edit_Click(sender As System.Object, e As System.EventArgs) Handles BTNLS3Edit.Click


		LazyEdit2 = False
		LazyEdit1 = False
		LazyEdit4 = False
		LazyEdit5 = False

		BTNLS2Edit.BackColor = My.Settings.ButtonColor
		BTNLS2Edit.ForeColor = My.Settings.TextColor
		BTNLS1Edit.BackColor = My.Settings.ButtonColor
		BTNLS1Edit.ForeColor = My.Settings.TextColor
		BTNLS4Edit.BackColor = My.Settings.ButtonColor
		BTNLS4Edit.ForeColor = My.Settings.TextColor
		BTNLS5Edit.BackColor = My.Settings.ButtonColor
		BTNLS5Edit.ForeColor = My.Settings.TextColor


		If LazyEdit3 = False Then
			BTNLS3Edit.BackColor = Color.ForestGreen
			BTNLS3Edit.ForeColor = Color.White
			LazyEdit3 = True
		Else
			BTNLS3Edit.BackColor = My.Settings.ButtonColor
			BTNLS3Edit.ForeColor = My.Settings.TextColor
			LazyEdit3 = False
		End If

	End Sub

	Private Sub BTNLS4_Click(sender As System.Object, e As System.EventArgs) Handles BTNLS4.Click


		If BTNLS4.Text <> "" Then
			chatBox.Text = BTNLS4.Text
			If ssh_WritingTaskFlag = True Then CheatCheck()
			sendButton.PerformClick()
		End If

	End Sub

	Private Sub BTNLS4Edit_Click(sender As System.Object, e As System.EventArgs) Handles BTNLS4Edit.Click


		LazyEdit2 = False
		LazyEdit3 = False
		LazyEdit1 = False
		LazyEdit5 = False

		BTNLS2Edit.BackColor = My.Settings.ButtonColor
		BTNLS2Edit.ForeColor = My.Settings.TextColor
		BTNLS3Edit.BackColor = My.Settings.ButtonColor
		BTNLS3Edit.ForeColor = My.Settings.TextColor
		BTNLS1Edit.BackColor = My.Settings.ButtonColor
		BTNLS1Edit.ForeColor = My.Settings.TextColor
		BTNLS5Edit.BackColor = My.Settings.ButtonColor
		BTNLS5Edit.ForeColor = My.Settings.TextColor


		If LazyEdit4 = False Then
			BTNLS4Edit.BackColor = Color.ForestGreen
			BTNLS4Edit.ForeColor = Color.White
			LazyEdit4 = True
		Else
			BTNLS4Edit.BackColor = My.Settings.ButtonColor
			BTNLS4Edit.ForeColor = My.Settings.TextColor
			LazyEdit4 = False
		End If

	End Sub

	Private Sub BTNLS5_Click(sender As System.Object, e As System.EventArgs) Handles BTNLS5.Click


		If BTNLS5.Text <> "" Then
			chatBox.Text = BTNLS5.Text
			If ssh_WritingTaskFlag = True Then CheatCheck()
			sendButton.PerformClick()
		End If

	End Sub

	Private Sub BTNLS5Edit_Click(sender As System.Object, e As System.EventArgs) Handles BTNLS5Edit.Click


		LazyEdit2 = False
		LazyEdit3 = False
		LazyEdit4 = False
		LazyEdit1 = False

		BTNLS2Edit.BackColor = My.Settings.ButtonColor
		BTNLS2Edit.ForeColor = My.Settings.TextColor
		BTNLS3Edit.BackColor = My.Settings.ButtonColor
		BTNLS3Edit.ForeColor = My.Settings.TextColor
		BTNLS4Edit.BackColor = My.Settings.ButtonColor
		BTNLS4Edit.ForeColor = My.Settings.TextColor
		BTNLS1Edit.BackColor = My.Settings.ButtonColor
		BTNLS1Edit.ForeColor = My.Settings.TextColor

		If LazyEdit5 = False Then
			BTNLS5Edit.BackColor = Color.ForestGreen
			BTNLS5Edit.ForeColor = Color.White
			LazyEdit5 = True
		Else
			BTNLS5Edit.BackColor = My.Settings.ButtonColor
			BTNLS5Edit.ForeColor = My.Settings.TextColor
			LazyEdit5 = False
		End If

	End Sub

#End Region ' Lazy-Sub

#Region "-------------------------------------------------- Randomizer-App ----------------------------------------------------"

	Private Sub BTNRandomBlog_Click(sender As System.Object, e As System.EventArgs) Handles BTNRandomBlog.Click
		BTNRandomBlog.Enabled = False
		GetBlogImage()
		BTNRandomBlog.Enabled = True
	End Sub

	Private Sub BTNRandomLocal_Click(sender As System.Object, e As System.EventArgs) Handles BTNRandomLocal.Click
		BTNRandomLocal.Enabled = False
		GetLocalImage()
		BTNRandomLocal.Enabled = True
	End Sub

	Private Sub BTNRandomVideo_Click(sender As System.Object, e As System.EventArgs) Handles BTNRandomVideo.Click
		ssh_RandomizerVideo = True
		RandomVideo()
		ssh_RandomizerVideo = False
	End Sub

	Private Sub BTNRandomJOI_Click(sender As System.Object, e As System.EventArgs) Handles BTNRandomJOI.Click
		PlayRandomJOI()
	End Sub

	Private Sub BTNRandomCS_Click(sender As System.Object, e As System.EventArgs) Handles BTNRandomCS.Click
		ssh_SaidHello = True
		ssh_RandomizerVideoTease = True

		ssh_ScriptVideoTease = "Censorship Sucks"
		ssh_ScriptVideoTeaseFlag = True
		RandomVideo()
		ssh_ScriptVideoTeaseFlag = False
		ssh_CensorshipGame = True
		ssh_VideoTease = True
		ssh_CensorshipTick = ssh_randomizer.Next(FrmSettings.NBCensorHideMin.Value, FrmSettings.NBCensorHideMax.Value + 1)
		CensorshipTimer.Start()
	End Sub

	Private Sub BTNRandomAtE_Click(sender As System.Object, e As System.EventArgs) Handles BTNRandomAtE.Click

		ssh_SaidHello = True
		ssh_RandomizerVideoTease = True

		ScriptTimer.Stop()
		ssh_SubStroking = True
		ssh_TempStrokeTauntVal = ssh_StrokeTauntVal
		ssh_TempFileText = ssh_FileText
		ssh_ScriptVideoTease = "Avoid The Edge"
		ssh_ScriptVideoTeaseFlag = True
		ssh_AvoidTheEdgeStroking = True
		ssh_AvoidTheEdgeGame = True
		RandomVideo()
		ssh_ScriptVideoTeaseFlag = False
		ssh_VideoTease = True
		ssh_StartStrokingCount += 1
		ssh_StopMetronome = False
		StrokePace = ssh_randomizer.Next(NBMaxPace.Value, NBMinPace.Value + 1)
		StrokePace = 50 * Math.Round(StrokePace / 50)
		ssh_AvoidTheEdgeTick = 120 / FrmSettings.TauntSlider.Value
		AvoidTheEdgeTaunts.Start()

	End Sub

	Private Sub BTNRandomRLGL_Click(sender As System.Object, e As System.EventArgs) Handles BTNRandomRLGL.Click

		ssh_SaidHello = True
		ssh_RandomizerVideoTease = True

		ScriptTimer.Stop()
		ssh_SubStroking = True
		ssh_ScriptVideoTease = "RLGL"
		ssh_ScriptVideoTeaseFlag = True
		'AvoidTheEdgeStroking = True
		ssh_RLGLGame = True
		RandomVideo()
		ssh_ScriptVideoTeaseFlag = False
		ssh_VideoTease = True
		ssh_RLGLTick = ssh_randomizer.Next(FrmSettings.NBGreenLightMin.Value, FrmSettings.NBGreenLightMax.Value + 1)
		RLGLTimer.Start()
		ssh_StartStrokingCount += 1
		ssh_StopMetronome = False
		StrokePace = ssh_randomizer.Next(NBMaxPace.Value, NBMinPace.Value + 1)
		StrokePace = 50 * Math.Round(StrokePace / 50)
		'VideoTauntTick = randomizer.Next(20, 31)
		'VideoTauntTimer.Start()

	End Sub

	Private Sub BTNRandomCH_Click_1(sender As System.Object, e As System.EventArgs) Handles BTNRandomCH.Click
		PlayRandomCH()
	End Sub

	''' =========================================================================================================
	''' <summary>
	''' Jumps to random videoposition in current video.
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	''' <ramarks>There is no need for parameter Sender and e. 
	''' Only for Designer Compatiblity with Butten Clicks.</ramarks>
	''' <exception cref="exception">Rethrows all exceptions to catcher, as long sender is nothing.</exception>
	Private Sub VideoJump2Random(sender As System.Object, e As System.EventArgs) Handles Button12.Click
		Try
			If DomWMP.currentPlaylist.count = 0 Then Throw New Exception("No Video playing - can't jump.")

			Dim VideoLength As Integer = DomWMP.currentMedia.duration
			Dim VidLow As Integer = VideoLength * 0.4
			Dim VidHigh As Integer = VideoLength * 0.9
			Dim VidPoint As Integer = ssh_randomizer.Next(VidLow, VidHigh)

			Debug.Print("VidLow = " & VidLow)
			Debug.Print("VidHigh = " & VidHigh)
			Debug.Print("VidPoint = " & VidPoint)

			DomWMP.Ctlcontrols.currentPosition = VideoLength - VidPoint
		Catch ex As Exception
			'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
			'                                            All Errors
			'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
			If sender IsNot Nothing Then
				MsgBox("Error on jumping to Random Position in Video!" & vbCrLf & ex.Message,
						vbExclamation, "Jump to random Position")
			Else
				Throw
			End If
		End Try
	End Sub

#End Region

#Region "--------------------------------------------------- Wishlist APP -----------------------------------------------------"

	Private Sub BTNPlaylist_Click(sender As System.Object, e As System.EventArgs) Handles BTNPlaylist.Click
		If LBPlaylist.SelectedItems.Count = 0 Then
			MessageBox.Show(Me, "Please select a Playlist first!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			Return
		End If

		If ssh_SaidHello = True Then
			MessageBox.Show(Me, "Please wait until you are not engaged with the domme to begin a Playlist!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			Return
		End If

		ssh_Playlist = True
		'SaidHello = True

		ssh_PlaylistFile = Txt2List(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Playlist\" & LBPlaylist.SelectedItem & ".txt")
		ssh_PlaylistFile = StripBlankLines(ssh_PlaylistFile)
		ssh_PlaylistCurrent = 0
		Try
			chatBox.Text = "Hello " & FrmSettings.TBHonorific.Text
		Catch
			chatBox.Text = "Hello"
		End Try

		sendButton.PerformClick()

		BTNPlaylist.Enabled = False
	End Sub

	Private Sub BTNWishlist_Click(sender As System.Object, e As System.EventArgs) Handles BTNWishlist.Click

		If ssh_SaidHello = True Then
			MessageBox.Show(Me, "Please wait until you are not engaged with your domme to use this feature!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			Return
		End If

		Debug.Print(WishlistCostSilver.Visible)
		Debug.Print(Val(LBLWishlistCost.Text))

		If WishlistCostSilver.Visible = True And ssh_SilverTokens >= Val(LBLWishlistCost.Text) Then

			ssh_SilverTokens -= Val(LBLWishlistCost.Text)
			My.Settings.SilverTokens = ssh_SilverTokens

			'LBLWishListText.Text = "You purchased this item for " & domName.Text & " on " & CDate(DateString) & "."
			'My.Settings.WishlistNote = LBLWishListText.Text

			My.Settings.ClearWishlist = True


			WishlistCostGold.Visible = False
			WishlistCostSilver.Visible = False
			LBLWishlistBronze.Text = ssh_BronzeTokens
			LBLWishlistSilver.Text = ssh_SilverTokens
			LBLWishlistGold.Text = ssh_GoldTokens
			LBLWishListName.Text = ""
			WishlistPreview.Visible = False
			LBLWishlistCost.Text = ""
			LBLWishListText.Text = "Thank you for your purchase! " & domName.Text & " has been notified of your generous gift. Please check back again tomorrow for a new item!"
			BTNWishlist.Enabled = False
			BTNWishlist.Text = ""


			Dim SilverList As New List(Of String)

			For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Apps\Wishlist\Silver Rewards\", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
				SilverList.Add(foundFile)
			Next

			If SilverList.Count < 1 Then
				MessageBox.Show(Me, "No Silver Reward scripts were found!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Return
			End If

			ssh_SaidHello = True
			ssh_ShowModule = True

			ssh_FileText = SilverList(ssh_randomizer.Next(0, SilverList.Count))

			If Directory.Exists(FrmSettings.LBLDomImageDir.Text) And ssh_SlideshowLoaded = False Then
				LoadDommeImageFolder()
			End If

			ssh_StrokeTauntVal = -1
			ssh_ScriptTick = 2
			ScriptTimer.Start()
			Return

		End If


		If WishlistCostGold.Visible = True And ssh_GoldTokens >= Val(LBLWishlistCost.Text) Then

			ssh_GoldTokens -= Val(LBLWishlistCost.Text)
			My.Settings.GoldTokens = ssh_GoldTokens

			My.Settings.ClearWishlist = True


			Dim GoldList As New List(Of String)

			For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Apps\Wishlist\Gold Rewards\", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
				GoldList.Add(foundFile)
			Next

			If GoldList.Count < 1 Then
				MessageBox.Show(Me, "No Gold Reward scripts were found!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Return
			End If

			ssh_SaidHello = True
			ssh_ShowModule = True

			ssh_FileText = GoldList(ssh_randomizer.Next(0, GoldList.Count))

			If Directory.Exists(FrmSettings.LBLDomImageDir.Text) And ssh_SlideshowLoaded = False Then
				LoadDommeImageFolder()
			End If

			ssh_StrokeTauntVal = -1
			ssh_ScriptTick = 2
			ScriptTimer.Start()

		End If


	End Sub

#End Region

#Region "------------------------------------------------- Hypno-Guide App ----------------------------------------------------"

	Private Sub BTNHypnoGenStart_Click(sender As System.Object, e As System.EventArgs) Handles BTNHypnoGenStart.Click



		If ssh_HypnoGen = False Then

			If CBHypnoGenInduction.Checked = True Then
				If File.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Apps\Hypnotic Guide\Inductions\" & LBHypnoGenInduction.SelectedItem & ".txt") Then
					ssh_Induction = True
					ssh_FileText = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Apps\Hypnotic Guide\Inductions\" & LBHypnoGenInduction.SelectedItem & ".txt"
				Else
					MessageBox.Show(Me, "Please select a valid Hypno Induction File or deselect the Induction option!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					Return
				End If
			End If



			If File.Exists(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Apps\Hypnotic Guide\Hypno Files\" & LBHypnoGen.SelectedItem & ".txt") Then
				If ssh_Induction = False Then
					ssh_FileText = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Apps\Hypnotic Guide\Hypno Files\" & LBHypnoGen.SelectedItem & ".txt"
				Else
					ssh_TempHypno = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Apps\Hypnotic Guide\Hypno Files\" & LBHypnoGen.SelectedItem & ".txt"
				End If
			Else
				MessageBox.Show(Me, "Please select a valid Hypno File!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Return
			End If

			ssh_StrokeTauntVal = -1
			ssh_ScriptTick = 1
			ScriptTimer.Start()
			Dim HypnoTrack As String = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Apps\Hypnotic Guide\" & ComboBoxHypnoGenTrack.SelectedItem
			If File.Exists(HypnoTrack) Then DomWMP.URL = HypnoTrack
			ssh_HypnoGen = True
			ssh_AFK = True
			ssh_SaidHello = True

			BTNHypnoGenStart.Text = "End Session"

		Else

			mciSendString("CLOSE Speech1", String.Empty, 0, 0)
			mciSendString("CLOSE Echo1", String.Empty, 0, 0)
			DomWMP.Ctlcontrols.stop()

			ScriptTimer.Stop()
			ssh_StrokeTauntVal = -1
			ssh_HypnoGen = False
			ssh_Induction = False
			ssh_AFK = False
			ssh_SaidHello = False

			BTNHypnoGenStart.Text = "Guide Me!"

		End If





	End Sub

	Private Sub CBHypnoGenSlideshow_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBHypnoGenSlideshow.CheckedChanged
		If FormLoading = False Then
			If CBHypnoGenSlideshow.Checked = True Then
				LBHypnoGenSlideshow.Enabled = True
			Else
				LBHypnoGenSlideshow.Enabled = False
			End If
		End If
	End Sub

	Private Sub CBHypnoGenInduction_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBHypnoGenInduction.CheckedChanged
		If FormLoading = False Then
			If CBHypnoGenInduction.Checked = True Then
				LBHypnoGenInduction.Enabled = True
			Else
				LBHypnoGenInduction.Enabled = False
			End If
		End If
	End Sub

	Private Sub CBHypnoGenNoText_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBHypnoGenNoText.CheckedChanged

	End Sub

#End Region

#Region "--------------------------------------------------- VitalSub APP -----------------------------------------------------"

	Private Sub BTNExercise_Click(sender As System.Object, e As System.EventArgs) Handles BTNExercise.Click
		If TBExercise.Text <> "" Then
			CLBExercise.Items.Add(TBExercise.Text)
			TBExercise.Text = ""
			SaveExercise()
		End If
	End Sub

	Private Sub BTNCalorie_Click(sender As System.Object, e As System.EventArgs) Handles BTNCalorie.Click
		If TBCalorieItem.Text <> "" And TBCalorieAmount.Text <> "" Then
			Dim CalorieString As String
			CalorieString = TBCalorieItem.Text & " " & TBCalorieAmount.Text & " Calories"
			Dim Dupecheck As Boolean = False
			For i As Integer = 0 To ComboBoxCalorie.Items.Count - 1
				If CalorieString = ComboBoxCalorie.Items(i) Then Dupecheck = True
			Next
			ComboBoxCalorie.Items.Add(CalorieString)
			LBCalorie.Items.Add(CalorieString)

			If File.Exists(Application.StartupPath & "\System\VitalSub\CalorieItems.txt") Then My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\System\VitalSub\CalorieItems.txt")
			For i As Integer = 0 To LBCalorie.Items.Count - 1
				If Not File.Exists(Application.StartupPath & "\System\VitalSub\CalorieItems.txt") Then
					My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\System\VitalSub\CalorieItems.txt", LBCalorie.Items(i), False)
				Else
					My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\System\VitalSub\CalorieItems.txt", Environment.NewLine & LBCalorie.Items(i), True)
				End If
			Next

			If Dupecheck = False Then
				If File.Exists(Application.StartupPath & "\System\VitalSub\CalorieList.txt") Then
					My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\System\VitalSub\CalorieList.txt", Environment.NewLine & CalorieString, True)
				Else
					My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\System\VitalSub\CalorieList.txt", CalorieString, False)
				End If
			End If
			Dupecheck = False
			ssh_CaloriesConsumed += TBCalorieAmount.Text
			LBLCalorie.Text = ssh_CaloriesConsumed
			My.Settings.CaloriesConsumed = ssh_CaloriesConsumed
			TBCalorieItem.Text = ""
			TBCalorieAmount.Text = ""
		End If
	End Sub

	Private Sub ComboBoxCalorie_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBoxCalorie.SelectedIndexChanged

	End Sub

	Private Sub ComboBoxCalorie_SelectionChangeCommitted(sender As Object, e As System.EventArgs) Handles ComboBoxCalorie.SelectionChangeCommitted
		If Not ComboBoxCalorie.SelectedItem Is Nothing Then
			Dim CalorieString As String = ComboBoxCalorie.SelectedItem
			LBCalorie.Items.Add(CalorieString)
			CalorieString = CalorieString.Replace(" Calories", "")
			Dim CalorieSplit As String() = Split(CalorieString)
			Dim TempCal As Integer = Val(CalorieSplit(CalorieSplit.Count - 1))
			ssh_CaloriesConsumed += TempCal
			LBLCalorie.Text = ssh_CaloriesConsumed
			My.Settings.CaloriesConsumed = ssh_CaloriesConsumed
			If File.Exists(Application.StartupPath & "\System\VitalSub\CalorieItems.txt") Then My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\System\VitalSub\CalorieItems.txt")
			For i As Integer = 0 To LBCalorie.Items.Count - 1
				If Not File.Exists(Application.StartupPath & "\System\VitalSub\CalorieItems.txt") Then
					My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\System\VitalSub\CalorieItems.txt", LBCalorie.Items(i), False)
				Else
					My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\System\VitalSub\CalorieItems.txt", Environment.NewLine & LBCalorie.Items(i), True)
				End If
			Next
		End If
	End Sub

	Private Sub CLBExercise_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles CLBExercise.SelectedIndexChanged, CLBExercise.LostFocus
		SaveExercise()
	End Sub

	Private Sub CBVitalSub_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBVitalSub.CheckedChanged
		If CBVitalSub.Checked = True Then
			CBVitalSub.ForeColor = Color.LightGreen
			CBVitalSub.Text = "VitalSub Active"
		Else
			CBVitalSub.ForeColor = Color.Red
			CBVitalSub.Text = "VitalSub Inactive"
		End If
	End Sub

	Private Sub CBVitalSub_LostFocus(sender As Object, e As System.EventArgs) Handles CBVitalSub.LostFocus
		If CBVitalSub.Checked = True Then
			My.Settings.VitalSub = True
		Else
			My.Settings.VitalSub = False
		End If
	End Sub

	Private Sub LBCalorie_DoubleClick(sender As Object, e As System.EventArgs) Handles LBCalorie.DoubleClick


		Dim CalorieString As String = LBCalorie.SelectedItem
		CalorieString = CalorieString.Replace(" Calories", "")
		Dim CalorieSplit As String() = Split(CalorieString)
		Dim TempCal As Integer = Val(CalorieSplit(CalorieSplit.Count - 1))
		ssh_CaloriesConsumed -= TempCal
		LBLCalorie.Text = ssh_CaloriesConsumed
		My.Settings.CaloriesConsumed = ssh_CaloriesConsumed
		LBCalorie.Items.Remove(LBCalorie.SelectedItem)
		If File.Exists(Application.StartupPath & "\System\VitalSub\CalorieItems.txt") Then My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\System\VitalSub\CalorieItems.txt")
		If LBCalorie.Items.Count > 0 Then
			For i As Integer = 0 To LBCalorie.Items.Count - 1
				If Not File.Exists(Application.StartupPath & "\System\VitalSub\CalorieItems.txt") Then
					My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\System\VitalSub\CalorieItems.txt", LBCalorie.Items(i), False)
				Else
					My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\System\VitalSub\CalorieItems.txt", Environment.NewLine & LBCalorie.Items(i), True)
				End If
			Next
		End If
	End Sub

	Private Sub BTNVitalSub_Click(sender As System.Object, e As System.EventArgs) Handles BTNVitalSub.Click
		If ssh_SaidHello = True Then
			MessageBox.Show(Me, "Please wait until you are not engaged with the domme to make VitalSub reports!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			Return
		End If

		ssh_SaidHello = True


		Dim VitalSubFail As Boolean = False

		If CLBExercise.Items.Count > 0 Then
			For i As Integer = 0 To CLBExercise.Items.Count - 1
				If CLBExercise.GetItemChecked(i) = False Then VitalSubFail = True
			Next
		End If

		If Val(LBLCalorie.Text) > Val(TBCalorie.Text) Then VitalSubFail = True

		Dim VitalSubState As String

		If VitalSubFail = True Then
			VitalSubState = "Punishments"
		Else
			VitalSubState = "Rewards"
		End If
		VitalSubFail = False




		Dim VitalList As New List(Of String)

		For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\Apps\VitalSub\" & VitalSubState & "\", FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
			VitalList.Add(foundFile)
		Next

		If VitalList.Count > 0 Then

			' github patch begin
			' For i As Integer = 0 To CLBExercise.Items.Count - 1
			'CLBExercise.SetItemChecked(i, False)
			'Next
			'SaveExercise()
			' github patch end

			CLBExercise.Items.Clear()
			SaveExercise()


			LBCalorie.Items.Clear()
			If File.Exists(Application.StartupPath & "\System\VitalSub\CalorieItems.txt") Then My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\System\VitalSub\CalorieItems.txt")
			LBLCalorie.Text = 0
			ssh_CaloriesConsumed = 0
			My.Settings.CaloriesConsumed = 0

			ssh_FileText = VitalList(ssh_randomizer.Next(0, VitalList.Count))

			If Directory.Exists(FrmSettings.LBLDomImageDir.Text) And ssh_SlideshowLoaded = False Then
				LoadDommeImageFolder()
			End If

			ssh_StrokeTauntVal = -1
			ssh_ScriptTick = 3
			ScriptTimer.Start()

		Else

			MessageBox.Show(Me, "No " & VitalSubState & " were found! Please make sure you have files in the VitaSub directory for this personality type!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			Return
		End If
	End Sub

	Private Sub CLBExercise_DragLeave(sender As Object, e As System.EventArgs) Handles CLBExercise.DragLeave

		CLBExercise.Items.Remove(CLBExercise.SelectedItem)
	End Sub

	Private Sub CBVitalSubDomTask_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CBVitalSubDomTask.CheckedChanged
		If FormLoading = False Then
			My.Settings.VitalSubAssignments = CBVitalSubDomTask.Checked
		End If
	End Sub

#End Region ' Vital Sub

	Public Sub MetronomeTick()

		Dim wavFilepath As String = Application.StartupPath & "\Audio\System\metronome.wav"
		Dim MetroSoundPlayer As Media.SoundPlayer = Nothing
		Dim wavStream As MemoryStream
		Dim Errorcounter As Integer = 0

restartNoFile:
		Try
			If Directory.Exists(Path.GetDirectoryName(wavFilepath)) AndAlso File.Exists(wavFilepath) Then

				wavStream = New MemoryStream(File.ReadAllBytes(wavFilepath))
				MetroSoundPlayer = New Media.SoundPlayer(wavStream)
				MetroSoundPlayer.Load()
playLoop:
				' copy variable to avoid needless locking delays
				Dim tmpStrokePace As Integer = StrokePaceMetronome

				If tmpStrokePace > 0 AndAlso CBMetronome.Checked Then
					MetroSoundPlayer.Stop()
					MetroSoundPlayer.Play()
					Thread.Sleep(tmpStrokePace)
				Else
					Thread.Sleep(1000)
				End If

				GoTo playLoop
			Else
				Thread.Sleep(10 * 1000)
				GoTo restartNoFile
			End If
		Catch ex As Exception When Errorcounter < 120
			'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
			'                                  All Errors until 119 Errors occured
			'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
			'TODO: MetronomeExceptions: Log error - but first add synclock to logging.
			Errorcounter += 1
			Thread.Sleep(1000)
			GoTo restartNoFile
		Catch ex As Exception
			'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
			'                                            All Errors
			'▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
			'TODO: MetronomeExceptions: Add possibility to restart the thread.
		End Try
	End Sub

#Region "-------------------------------------------------- Metronome-App -----------------------------------------------------"

	Private Sub BTNMetroPreview1_Click(sender As System.Object, e As System.EventArgs) Handles BTNMetroPreview1.Click
		If ssh_SubStroking = False Then StrokePace = NBMaxPace.Value
	End Sub

	Private Sub BTNMetroPreview2_Click(sender As System.Object, e As System.EventArgs) Handles BTNMetroPreview2.Click
		If ssh_SubStroking = False Then StrokePace = NBMinPace.Value
	End Sub

	Private Sub BTNMetroStop1_Click(sender As System.Object, e As System.EventArgs) Handles BTNMetroStop1.Click
		If ssh_SubStroking = False Then StrokePace = 0
	End Sub

	Private Sub BTNMetroStop2_Click(sender As System.Object, e As System.EventArgs) Handles BTNMetroStop2.Click
		If ssh_SubStroking = False Then StrokePace = 0
	End Sub

	Private Sub NBMaxPace_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NBMaxPace.ValueChanged
		If FormLoading = False Then
			If NBMaxPace.Value > NBMinPace.Value - 50 Then NBMaxPace.Value = NBMinPace.Value - 50
			If ssh_SubStroking = False Then StrokePace = NBMaxPace.Value
			My.Settings.MaxPace = NBMaxPace.Value
		End If
	End Sub

	Private Sub NBMinPace_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NBMinPace.ValueChanged
		If FormLoading = False Then
			If NBMinPace.Value < NBMaxPace.Value + 50 Then NBMinPace.Value = NBMaxPace.Value + 50
			If ssh_SubStroking = False Then StrokePace = NBMinPace.Value
			My.Settings.MinPace = NBMinPace.Value
		End If
	End Sub

	Private Sub TimeoutTimer_Tick(sender As System.Object, e As System.EventArgs) Handles TimeoutTimer.Tick

		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then Return

		Debug.Print("TimeoutTick = " & ssh_TimeoutTick)

		If chatBox.Text <> "" And ssh_TimeoutTick < 3 Then Return
		If ChatBox2.Text <> "" And ssh_TimeoutTick < 3 Then Return

		ssh_TimeoutTick -= 1

		If ssh_TimeoutTick < 1 Then

			TimeoutTimer.Stop()
			ssh_YesOrNo = False
			ssh_InputFlag = False

			ssh_SkipGotoLine = True
			GetGoto()

			RunFileText()

		End If

	End Sub

	Private Sub CBMetronome_LostFocus(sender As Object, e As System.EventArgs) Handles CBMetronome.LostFocus
		My.Settings.MetroOn = CBMetronome.Checked
	End Sub

#End Region ' Metronome App

#End Region ' Apps

	Private Sub VideoTimer_Tick(sender As System.Object, e As System.EventArgs) Handles VideoTimer.Tick

		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then Return

		ssh_VideoTick -= 1

		If ssh_VideoTick < 1 Then
			VideoTimer.Stop()
			DomWMP.Ctlcontrols.stop()
		End If


	End Sub

	Private Sub MultipleEdgesTimer_Tick(sender As System.Object, e As System.EventArgs) Handles MultipleEdgesTimer.Tick

		If ssh_DomTypeCheck = True Then Return
		If FrmSettings.CBSettingsPause.Checked = True And FrmSettings.SettingsPanel.Visible = True Then Return

		ssh_MultipleEdgesTick -= 1

		If ssh_MultipleEdgesTick < 1 Then

			MultipleEdgesTimer.Stop()

			ssh_DomChat = "#SYS_MultipleEdgesStart"
			If ssh_Contact1Edge = True Then ssh_DomChat = "@Contact1 #SYS_MultipleEdgesStart"
			If ssh_Contact2Edge = True Then ssh_DomChat = "@Contact2 #SYS_MultipleEdgesStart"
			If ssh_Contact3Edge = True Then ssh_DomChat = "@Contact3 #SYS_MultipleEdgesStart"
			TypingDelay()

			ssh_MultipleEdgesMetronome = "START"

			ssh_EdgeCountTick = 0
			EdgeCountTimer.Start()

		End If

	End Sub

	Public Function OfflineConversion(ByVal OffString As String) As String

		' Ixnay on the Wordplay

		OffString = OffString.Replace("@ShowBlogImage", "@ShowLocalImage")

		If My.Settings.CBIButts = False Then
			OffString = OffString.Replace("@ShowButtImage", "")
			OffString = OffString.Replace("@ShowButtsImage", "")
		End If

		If My.Settings.CBIBoobs = False Then
			OffString = OffString.Replace("@ShowBoobImage", "")
			OffString = OffString.Replace("@ShowBoobsImage", "")
		End If

		If OffString.Contains("@ShowImage[") Then
			Dim CheckImage As String = GetParentheses(OffString, "@ShowImage[")
			If CheckImage.Contains("://") Then
				OffString = OffString.Replace("@ShowImage[" & CheckImage & "]", "")
			End If
		End If

		Return OffString

		' You gotta keep 'em numerated

	End Function


	Private Function FilterCheck(ByVal Input As String, ByVal ConditionControl As Control) As Boolean


		Debug.Print("Input = " & Input)
		Debug.Print("ConditionControl = " & ConditionControl.ToString)

		If TypeOf ConditionControl Is NumericUpDown Then
			Debug.Print("It's a combo box" & Input)
		End If

		Dim TextCondition As String
		' Cast the Type of the Control to access it's visible TextValue
		If TypeOf ConditionControl Is NumericUpDown Then
			TextCondition = DirectCast(ConditionControl, NumericUpDown).Value
		ElseIf TypeOf ConditionControl Is ComboBox Then
			TextCondition = DirectCast(ConditionControl, ComboBox).Text
		ElseIf TypeOf ConditionControl Is CheckBox Then
			TextCondition = DirectCast(ConditionControl, CheckBox).Checked
		Else
			Throw New Exception("Type of control not implemented in Function.")
		End If

		TextCondition = UCase(TextCondition)
		Debug.Print("TextCondition = " & TextCondition)

		If TextCondition = "ALWAYS ALLOWS" Or TextCondition = "ALWAYS RUINS" Then TextCondition = "ALWAYS"
		If TextCondition = "OFTEN ALLOWS" Or TextCondition = "OFTEN RUINS" Then TextCondition = "OFTEN"
		If TextCondition = "SOMETIMES ALLOWS" Or TextCondition = "SOMETIMES RUINS" Then TextCondition = "SOMETIMES"
		If TextCondition = "RARELY ALLOWS" Or TextCondition = "RARELY RUINS" Then TextCondition = "RARELY"
		If TextCondition = "NEVER ALLOWS" Or TextCondition = "NEVER RUINS" Then TextCondition = "NEVER"


		Input = UCase(Input)
		'Input = Input.Replace(" ", "")

		If Input.Contains(",") Then
			Input = FixCommas(Input)
			Dim SplitArray() As String = Input.Split(",")

			If Input.Contains("NOT") Then
				For i As Integer = 0 To SplitArray.Count - 1
					If SplitArray(i) = TextCondition Then Return False
				Next
				Return True
			Else
				For i As Integer = 0 To SplitArray.Count - 1
					If SplitArray(i) = TextCondition Then Return True
				Next
			End If
		Else
			If Input = TextCondition Then Return True
		End If

		Return False

	End Function

	Public Sub ClearModes()

		ssh_EdgeGoto = False
		ssh_YesGoto = False
		ssh_NoGoto = False
		ssh_CameGoto = False
		ssh_RuinedGoto = False
		ssh_EdgeVideo = False
		ssh_YesVideo = False
		ssh_NoVideo_Mode = False
		ssh_CameVideo = False
		ssh_RuinedVideo = False
		ssh_EdgeMessage = False
		ssh_CameMessage = False
		ssh_RuinedMessage = False
		ssh_Modes.Clear()


	End Sub


	Public Function GetMatch(ByVal Line As String, ByVal Command As String, Match As String) As Boolean

		Debug.Print("Line = " & Line)
		Debug.Print("Command = " & Command)
		Debug.Print("Match = " & Match)

		Dim CommandFlag As String = GetParentheses(Line, Command)

		If CommandFlag.Contains(",") Then

			CommandFlag = FixCommas(CommandFlag)

			Dim CommandArray As String() = CommandFlag.Split(",")

			Dim NotFlag As Boolean = False

			For i As Integer = 0 To CommandArray.Count - 1
				If CommandArray(i).ToUpper = "NOT" Then NotFlag = True
			Next

			If NotFlag = True Then

				For i As Integer = 0 To CommandArray.Count - 1
					If CommandArray(i) = Match Then Return False
				Next

				Return True

			Else

				For i As Integer = 0 To CommandArray.Count - 1
					If CommandArray(i) = Match Then Return True
				Next

			End If

		Else

			If CommandFlag = Match Then Return True

		End If

		Return False

	End Function



	Public Sub Edge()

		If ssh_SubStroking = True Then ssh_AlreadyStrokingEdge = True
		GetEdgeTickCheck()
		ssh_SubStroking = True
		ssh_LongEdge = False
		ssh_AskedToSpeedUp = False
		ssh_AskedToSlowDown = False
		ssh_EdgeCountTick = 0
		EdgeCountTimer.Start()
		ssh_SubEdging = True
		ssh_EdgeTauntInt = ssh_randomizer.Next(15, 31)
		EdgeTauntTimer.Start()
		If ssh_OrgasmAllowed = True Or ssh_OrgasmDenied = True Or ssh_OrgasmRuined = True Then ssh_OrgasmYesNo = True
		EdgePace()
		ActivateWebToy()
		DisableContactStroke()
		ssh_SessionEdges += 1

	End Sub


	Private Sub Button15_Click(sender As System.Object, e As System.EventArgs) Handles Button15.Click
		CloseApp()
		ChatText2.Visible = True
		PNLChatBox2.Visible = True
		OpenApp()
		SideChatToolStripMenuItem1.Checked = True
		My.Settings.SideChat = True
	End Sub

	Public Sub ClearWriteTask()
		'WritingTaskTimer.Stop()
		ssh_WritingTaskCurrentTime = 0
		ssh_WritingTaskFlag = False
		chatBox.ShortcutsEnabled = True
		ChatBox2.ShortcutsEnabled = True
		CloseApp()
		If ChatText.Height < 31 Then
			ChatText2.Visible = True
			PNLChatBox2.Visible = True
			OpenApp()
			SideChatToolStripMenuItem1.Checked = True
			My.Settings.SideChat = True
		End If
	End Sub

	Public Sub ClearChat()

		ssh_Chat = "<body bgcolor=""" & Color2Html(My.Settings.ChatWindowColor) & """></body>"
		ChatText.DocumentText = ssh_Chat
		ChatText2.DocumentText = ssh_Chat
		ChatReadyState()

	End Sub

	Public Sub ChatReadyState()
		While ChatText.ReadyState <> WebBrowserReadyState.Complete Or ChatText2.ReadyState <> WebBrowserReadyState.Complete
			Application.DoEvents()
		End While
		ScrollChatDown()
	End Sub


	Public Function GetIf(ByVal CompareString As String) As Boolean

		' CompareString = [x]operator[y]

		Dim ReturnVal As Boolean = False

		Dim CompareArray As String() = CompareString.Split("]")
		Dim C_Operator As String = CompareArray(1).Split("[")(0)
		Dim Val1 As String = CompareArray(0).Replace("[", "")
		Dim Val2 As String = CompareArray(1).Replace(C_Operator & "[", "")

		If Val1.StartsWith("#") Then Val1 = PoundClean(Val1)
		If Val2.StartsWith("#") Then Val2 = PoundClean(Val2)

		Debug.Print("CompareString = " & CompareString)
		Debug.Print("C_Operator = " & C_Operator)
		Debug.Print("Val1 = " & Val1)
		Debug.Print("Val2 = " & Val2)

		If Not IsNumeric(Val1) Then
			Dim VarCheck As String = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Variables\" & Val1
			If File.Exists(VarCheck) Then Val1 = TxtReadLine(VarCheck)
		End If

		If Not IsNumeric(Val2) Then
			Dim VarCheck As String = Application.StartupPath & "\Scripts\" & dompersonalitycombobox.Text & "\System\Variables\" & Val2
			If File.Exists(VarCheck) Then Val2 = TxtReadLine(VarCheck)
		End If

		If C_Operator = "=" Or C_Operator = "==" Then
			If UCase(Val1) = UCase(Val2) Then Return True
		End If

		If C_Operator = "<>" Then
			If UCase(Val1) <> UCase(Val2) Then Return True
		End If

		If Not IsNumeric(Val1) And Not IsNumeric(Val2) Then Return False

		If C_Operator = ">" Then
			If Val(Val1) > Val(Val2) Then Return True
		End If

		If C_Operator = "<" Then
			If Val(Val1) < Val(Val2) Then Return True
		End If

		If C_Operator = ">=" Then
			If Val(Val1) >= Val(Val2) Then Return True
		End If

		If C_Operator = "<=" Then
			If Val(Val1) <= Val(Val2) Then Return True
		End If

		Return ReturnVal

	End Function

	Public Function GetArrayString(ByVal StringToSplit As String) As String()
		StringToSplit = FixCommas(StringToSplit)
		Dim ArrayString As String() = StringToSplit.Split(",")
		Return ArrayString
	End Function

	Public Function GetCharCount(ByVal StringClean As String, ByVal Character As String) As Integer
		Return Len(StringClean) - Len(Replace(StringClean, Character, ""))
	End Function


End Class
